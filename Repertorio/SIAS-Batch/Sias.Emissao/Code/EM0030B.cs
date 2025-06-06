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
using Sias.Emissao.DB2.EM0030B;

namespace Code
{
    public class EM0030B
    {
        public bool IsCall { get; set; }

        public EM0030B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *REMARKS.                                                               */
        /*"      **                                                               *      */
        /*"      *  # A T E N C A O # A T E N C A O # A T E N C A O # A T E N C A O      */
        /*"      *  # A T E N C A O # A T E N C A O # A T E N C A O # A T E N C A O      */
        /*"      *  # A T E N C A O # A T E N C A O # A T E N C A O # A T E N C A O      */
        /*"      *  # A T E N C A O # A T E N C A O # A T E N C A O # A T E N C A O      */
        /*"      *  # A T E N C A O # A T E N C A O # A T E N C A O # A T E N C A O      */
        /*"      *  # A T E N C A O # A T E N C A O # A T E N C A O # A T E N C A O      */
        /*"      *                                                                *      */
        /*"      *    ESTE PROGRAMA EH COPIA DO ==>  EM0010B VERSAO 63  <==              */
        /*"      *    PARA PROCESSAMENTO EXCLUSIVO DAS APOLICES DO BANCO LUSO            */
        /*"      *    0106100000011 E 0106800000024 QUE ERAM PREOCESSADOS PELO           */
        /*"      *    EFP. NAO FOI MIGRADO PARA O SMART E OS ENDOSSOS ESTAO SENDO        */
        /*"      *    EMITIDOS PELO SIAS.                                                */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *      ADMINISTRACAO INTEGRADA DE SEGUROS   -  EMISSAO           *      */
        /*"      *                                                                *      */
        /*"      *        SISTEMA ............ EMISSAO                            *      */
        /*"      *        PROGRAMA............ EM0030B                            *      */
        /*"      *        FUNCAO.............. ATUALIZACAO BANCO DE DADOS APOLICE *      */
        /*"      *                             GERACAO DE PARCELAS/HISTORICOS     *      */
        /*"      *        ANALISTA............ DONIZETE/BUENO                     *      */
        /*"      *        PROGRAMADOR......... HELIO                              *      */
        /*"      *        VERSAO ............. 29012009 17:00HS                   *      */
        /*"      *        DATA CODIFICACAO.... AGOSTO/1991                        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                A L T E R A C O E S                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.64  * VERSAO  : V.64                                                 *      */
        /*"      * MOTIVO  : TRATAMENTO ESPECIFICO PARA O HABITACIONAL - BANCO    *      */
        /*"      *           LUSO.                                                *      */
        /*"      *           APOS E ENCERRAMENTO DO EFP OS ENDOSSOS DO BANCO LUSO        */
        /*"      *           ESTAO SENDO EMITIDOS PELO SIAS NA OPCAO OUTRO RAMOS         */
        /*"      *           NAO FORAM FEITAS LIMPESAS DOS ACESSOS AO EFP.               */
        /*"      *           APENAS AJUSTE NAS MOVIMENTACOES DA PARCELA E HISTOPARC      */
        /*"      *           A IMPLEMENTACAO SERA SOLICITADA PARA 05/03/2020             */
        /*"v.64  * CADMUS  : 226496                                               *      */
        /*"      * DATA    : 05/03/2020                                           *      */
        /*"      * NOME    : HEIDER COELHO                                        *      */
        /*"      * MARCADOR: V.64                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.63  * VERSAO  : 063                                                  *      */
        /*"      * MOTIVO  : ALTERACAO DO COMANDO DO BOOKLIB - LOTERICO           *      */
        /*"      * CADMUS  : 179615                                               *      */
        /*"      * DATA    : 08/01/2020                                           *      */
        /*"      * NOME    : FLAVIO                                               *      */
        /*"      * MARCADOR: V.63                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.62  * VERSAO  : 062                                                  *      */
        /*"      * MOTIVO  : AJUSTES NA COMPRA DE TIT CAP LOT/CCA                 *      */
        /*"      * JAZZ    : 221095                                               *      */
        /*"      * DATA    : 12/12/2019                                           *      */
        /*"      * NOME    : OLIVEIRA                                             *      */
        /*"      * MARCADOR: V.62                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.61  * VERSAO  : 061                                                  *      */
        /*"      * MOTIVO  : AJUSTES TAXA DE IOF PARA BANCO LUSO                  *      */
        /*"      * JIRAR   : 1192                                                 *      */
        /*"      * DATA    : 24/06/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.61                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.60  * VERSAO  : 060                                                  *      */
        /*"      * MOTIVO  : AJUSTES PARA EMISSAO DE ENDOSSO BANCO LUSO           *      */
        /*"      * JIRAR   : 1192                                                 *      */
        /*"      * DATA    : 24/06/2019                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.60                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.59  * VERSAO  : 059                                                  *      */
        /*"      * MOTIVO  : COMPRA DE TITULO DE CAP PROD 1803/1805 NOVA CHAMADA  *      */
        /*"      * CADMUS  : CAD168681                                            *      */
        /*"      * DATA    : 03/10/2018                                           *      */
        /*"      * NOME    : OLIVEIRA                                             *      */
        /*"      * MARCADOR: V.59                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.58  * VERSAO  : 058                                                  *      */
        /*"      * MOTIVO  : CADASTRAR APOLICE 6121 COM REPASSE DE PREMIO DFC 1414*      */
        /*"      * JIRA    : ADD-5237                                             *      */
        /*"      * DATA    : 05/09/2018                                           *      */
        /*"      * NOME    : FELIPE AUGUSTO                                       *      */
        /*"      * MARCADOR: VER.58                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.57  * VERSAO  : 057                                                  *      */
        /*"      * MOTIVO  : CADASTRAR APOLICE 6132 COM REPASSE DE PREMIO DFC 1412*      */
        /*"      * JIRA    : ADD-5211                                             *      */
        /*"      * DATA    : 05/09/2018                                           *      */
        /*"      * NOME    : FELIPE AUGUSTO                                       *      */
        /*"      * MARCADOR: VER.57                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.56  * VERSAO  : 056                                                  *      */
        /*"      * MOTIVO  : REPASSE DE PREMIO(DFC) - PRODUTO 1413                *      */
        /*"      * JIRA    : ADD-4699                                             *      */
        /*"      * DATA    : 25/04/2018                                           *      */
        /*"      * NOME    : TULIO MALAQUIAS NASCIMENTO                           *      */
        /*"      * MARCADOR: VER.56                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.55  * VERSAO  : 055                                                  *      */
        /*"      * MOTIVO  : ALTERAR DATA DE VENCIMENTO DE ALGUMAS PROPOSTAS DO   *      */
        /*"      *           AUTO FACIL                                           *      */
        /*"      * CADMUS  : 163048                                               *      */
        /*"      * DATA    : 10/04/2018                                           *      */
        /*"      * NOME    : LISIANE BRAGANCA SOARES                              *      */
        /*"      * MARCADOR: VER.55                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.54  * VERSAO  : 054                                                  *      */
        /*"      * MOTIVO  : ZERAR VALORES DE IOF QUANDO O RESTITUICAO > EMISSAO  *      */
        /*"      *           ALTERACAO PARA APOLICES DO HABITACIONAL              *      */
        /*"      * CADMUS  : 157423                                               *      */
        /*"      * DATA    : 16/03/2018                                           *      */
        /*"      * NOME    : FELIPE AUGUSTO                                       *      */
        /*"      * MARCADOR: VER.54                                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.53  * VERSAO  : 053                                                  *      */
        /*"      * MOTIVO  : COMPRAR TIT DE CAP PARA PROD 1805 PERIODO 2017/2018  *      */
        /*"      * CADMUS  : 161183                                               *      */
        /*"      * DATA    : 16/02/2018                                           *      */
        /*"      * NOME    : OLIVEIRA                                             *      */
        /*"      * MARCADOR: V.53                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.52  * VERSAO  : 052                                                  *      */
        /*"      * MOTIVO  : COMPRAR TIT DE CAP PARA PROD 1803 PERIODO 2018/2019  *      */
        /*"      * CADMUS  : 154909                                               *      */
        /*"      * DATA    : 12/12/2017                                           *      */
        /*"      * NOME    : OLIVEIRA                                             *      */
        /*"      * MARCADOR: V.52                                                 *      */
        /*"      * PROMOVIDO EM                                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  * VERSAO  : 051                                                  *      */
        /*"      * MOTIVO  : RENOVACAO CCA PARA O PERIODO 2017/2018               *      */
        /*"      * CADMUS  : 151911                                               *      */
        /*"      * DATA    : 11/09/2017                                           *      */
        /*"      * NOME    : LISIANE BRAGANCA SOARES                              *      */
        /*"      * MARCADOR: V.51                                                 *      */
        /*"      * PROMOVIDO EM                                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.50  * VERSAO  : 050                                                  *      */
        /*"      * MOTIVO  : AJUSTAR DATA DA PROPOSTA SE MAIOR QUE DATA INIVIGENC *      */
        /*"      * CADMUS  : 150420                                               *      */
        /*"      * DATA    : 31/05/2017                                           *      */
        /*"      * NOME    : JOSE G OLIVEIRA                                      *      */
        /*"      * MARCADOR: V.50                                                 *      */
        /*"      * PROMOVIDO EM 01/06/2017                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.49  * VERSAO  : 049                                                  *      */
        /*"      * MOTIVO  : CORRIGIR DT DE VENCIMENTO DAS PARCELAS DO CCA E LOT  *      */
        /*"      * CADMUS  : 150543                                               *      */
        /*"      * DATA    : 03/05/2017                                           *      */
        /*"      * NOME    : LISIANE BRAGANCA SOARES                              *      */
        /*"      * MARCADOR: V.49                                                 *      */
        /*"      * PROMOVIDO EM 01/06/2017                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.48  * VERSAO  : 048                                                  *      */
        /*"      * MOTIVO  : PROJETO SIGCB - CHAMAR ROTINA GE0350S                *      */
        /*"      * CADMUS  : 144133                                               *      */
        /*"      * DATA    : 07/12/2016                                           *      */
        /*"      * NOME    : LISIANE BRAGANCA SOARES                              *      */
        /*"      * MARCADOR: V.48                                                 *      */
        /*"      * PROMOVIDO EM 01/06/2017                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.47  * VERSAO  : 047                                                  *      */
        /*"      * MOTIVO  : INCLUIR APOLICES ESPECIFICAS DOS PRODUTOS            *      */
        /*"      *           MIP-7722 (107700000046) E DFI-1411 (101402541680)    *      */
        /*"      * CADMUS  : 142504                                               *      */
        /*"      * DATA    : 09/12/2016                                           *      */
        /*"      * NOME    : LUIZ GUSTAVO LOPES                                   *      */
        /*"      * MARCADOR: V.47                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.46  * VERSAO  : 046                                                  *      */
        /*"      * MOTIVO  : RETIRAR DESCONTO DAS DEMAIS PARCELAS PRODUTO 1804    *      */
        /*"      * CADMUS  : 142070                                               *      */
        /*"      * DATA    : 13/09/2016                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.46                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 45.0 - INCLUIR APOLICE  ESPECIFICA  Do PROD.PRESTAMIS-*      */
        /*"      *                 TA 7726 APOLICE  107700000058                  *      */
        /*"      *              107700000050 PARA CALCULAR IOF. CADMUS 112064     *      */
        /*"      *                                                                *      */
        /*"      *   FELIPE AUGUSTO - 17/12/2015              CADMUS 120770       *      */
        /*"      *                                            PROCURE VER.45      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 44.0 - PERMITIR EMISSAO PARA APOLICES COM RCAP        *      */
        /*"      *                 APROPRIADO APOS O PAGAMENTO. NORMALMENTE MES   *      */
        /*"      *                 SUBSEQUENTE.                                   *      */
        /*"      *                                                                *      */
        /*"      *   GUILHERME CORREIA - 22/12/2015           ABEND 127322        *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE V.44        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43.0 - INCLUIR APOLICES ESPECIFICAS DE PROD.PRESTAMIS-*      */
        /*"      *                 TA (7724 e 7723 ) APOLICES 107700000049        *      */
        /*"      *              107700000050 PARA CALCULAR IOF. CADMUS 112064     *      */
        /*"      *                                                                *      */
        /*"      *   FELIPE AUGUSTO - 17/12/2015              CADMUS 122178       *      */
        /*"      *                                            PROCURE VER.43      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                            PROCURAR V.40       *      */
        /*"      *   VERSAO 42.0 - A APOLICE 107700000047 SERA FATURADA AGORA NO  *      */
        /*"      *                 SIAS, A VERSAO 40 (v.40) TRATAVA ESTA APOLICE  *      */
        /*"      *                 PELO EF, SENDO ASSIM PRECISOU SER ASTERISCADA  *      */
        /*"      *                                                                *      */
        /*"      *   LUIZ GUSTAVO LOPES - 25/11/2015                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41.0 - ABEND CAUSADO PELA SOMA INDEVIDA DE 1 MES      *      */
        /*"      *                 NAS DEMAIS PARCELAS DO CCA.                    *      */
        /*"      *                                                                *      */
        /*"      *   GUILHERME CORREIA - 10/11/2015                               *      */
        /*"      *                                            PROCURAR V.41       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40.0 - INCLUIR APOLICES ESPECIFICAS DE PROD.PRESTAMIS-*      */
        /*"      *                 TA (7706) PARA CALCULAR IOF. CADMUS 112064     *      */
        /*"      *                                                                *      */
        /*"      *   ANA PAULA/TEREZA - 08/09/2015                                *      */
        /*"      *                                            PROCURAR V.40       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39.0 - RENOVACAO CCA 2015/2016                        *      */
        /*"      *                                                                *      */
        /*"      *                   SOMA 1 MES NA DATA DA 2 PARCELA PARA CASOS   *      */
        /*"      *                   QUE A PRIMEIRA PARCELA JA FOI COBRADA.       *      */
        /*"      *                                                                *      */
        /*"      *   GUILHERME CORREIA - 20/08/2015                               *      */
        /*"      *                                            PROCURAR V.39       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38.0 - incluir as apolices:                           *      */
        /*"      *                                                   CADMUS 113795*      */
        /*"      *                                                                *      */
        /*"      *   EVERTON ALMEIDA   - 26/07/2015                               *      */
        /*"      *                                            PROCURAR V.38       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37.0 - ajuste no faturamento do Lar mais              *      */
        /*"      *                 - 6118 - lar mais - 106100000018   cadmus 91538*      */
        /*"      *                 - 1409 - lar mais - 101402541679               *      */
        /*"      *                                                                *      */
        /*"      *   Rogerio Almeida   - 27/12/2014                               *      */
        /*"      *                                            PROCURAR V.37       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36.0 - ajuste no faturamento do Lar mais              *      */
        /*"      *                 - 6118 - lar mais - 106100000018   cadmus 91538*      */
        /*"      *                 - 1409 - lar mais - 101402541679               *      */
        /*"      *                                                                *      */
        /*"      *   Rogerio Almeida   - 22/11/2014                               *      */
        /*"      *                                            PROCURAR V.36       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35.0 - ABEND ENDOSSO CCA - ABEND 105374               *      */
        /*"      *                                                                *      */
        /*"      *                   NAO VERIFICA PARCELA PARA ENDOSSO            *      */
        /*"      *                                                                *      */
        /*"      *   GUILHERME CORREIA - 04/11/2014                               *      */
        /*"      *                                            PROCURAR V.35       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34.0 - incluir as apolices:                           *      */
        /*"      *                 - 6118 - lar mais - 106100000018   cadmus 91538*      */
        /*"      *                 - 1409 - lar mais - 101402541679               *      */
        /*"      *                                                                *      */
        /*"      *   Rogerio Almeida   - 24/09/2014                               *      */
        /*"      *                                            PROCURAR V.34       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33.0 - PARA O PRODUTO 1805 CCA - AS DEMAIS PARCELAS   *      */
        /*"      *                 SERAO SEMPRE NO DIA 01 DO MES SE O PAGAMENTO DA*      */
        /*"      *                 ADESAO OU A EMISSAO AUTOMATICA FOR ANTES DO DIA*      */
        /*"      *                 05/11. CASO CONTRARIO SERA SEMPRE D+7          *      */
        /*"      *                                                                *      */
        /*"      *                 ESSA ALTERACAO SUBISTITUI A REGRA SOLICITADA   *      */
        /*"      *                 NA RENOVACAO ONDE TODAS SERIAM DIA 01          *      */
        /*"      *                                                                *      */
        /*"      *   GUILHERME CORREIA - 06/10/2014                               *      */
        /*"      *                                                                *      */
        /*"      *                      CADMUS: 103847        PROCURAR V.33       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32.0 - incluir as apolices:                           *      */
        /*"      *                 - 4817 - 104800000058 - SQG MOTO   CADMUS 97142*      */
        /*"      *                                                                *      */
        /*"      *   EVERTON ALMEIDA   - 26/08/2014                               *      */
        /*"      *                                            PROCURAR V.32       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31.0 - incluir as apolices:                           *      */
        /*"      *                 - 7716 - 107700000038 - SIAPX CCA  cadmus 91538*      */
        /*"      *                 - 1410 - 101402541678 - PR Banco   cadmus 90231*      */
        /*"      *                 - 7714 - 107700000026 - PR Banco   cadmus 90231*      */
        /*"      *                                                                *      */
        /*"      *   Rogerio Almeida   - 26/12/2013                               *      */
        /*"      *                                            PROCURAR V.31       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30.0 - incluir apolice 101402541676(prod.1406) para   *      */
        /*"      *                 emissao.                                       *      */
        /*"      *                                                                *      */
        /*"      *   Delmar Brito      - 20/12/2013           CADMUS 88336        *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURAR V.30       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 29.0 - ajuste vencimentos com forma de adesao 4       *      */
        /*"      *                (cartao demais bancos)                          *      */
        /*"      *                                                                *      */
        /*"      *   COREON            - 08/11/2013           CADMUS 74582        *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURAR V.29       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28.0 - INCLUSAO MENSAGEM P/OPERADOR EM CASO DE        *      */
        /*"      *                 CANCELAMENTO (SOLICITACAO GEINF)               *      */
        /*"      *                                                                *      */
        /*"      *   BRICE HO          - 23/10/2013           CADMUS 89147        *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURAR V.28       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26.0 - INCLUSAO PRODUTO 1805 - CORRESPONDENTE CAIXA   *      */
        /*"      *   AQUI                                                         *      */
        /*"      *                                                                *      */
        /*"      *   GUILHERME CORREIA - 09/09/2013           CADMUS 82475        *      */
        /*"      *                                                                *      */
        /*"      *                                             PROCURAR V.27      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26   - ABEND NO INSERT V0HISTOPARC => SQLCODE -180    *      */
        /*"      *   CADMUS 87810                  DIOGO MATHEUS   PROCURAR V.26  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25.0 - INCLUIR APOLICES DOS PRODUTOS  4814, 4815      *      */
        /*"      *   CADMUS 86863                  DELMAR BRITO    PROCURAR V25.0 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 24 - PROJETO AUTO FACIL    CADMUS 74582               *      */
        /*"      *   EM 05/08/2013 - COREON            PROCURAR: V.24             *      */
        /*"      *                  (AJUSTAR SOLICITACAO NA EMISSAO_DIARIA PARA   *      */
        /*"      *                   EM0015B - GERACAO DA MOVTO_DEBITOCC_CEF      *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 23 - PROJETO AUTO FACIL    CADMUS 74582               *      */
        /*"      *   EM 16/07/2013 - COREON            PROCURAR: V.23             *      */
        /*"      *                  (AJUSTAR CALCULO VENCIMENTO DEMAIS PARCELAS E *      */
        /*"      *                   PERMITIR IMPRESSAO FOLHETARIA PARA ENDOSSOS  *      */
        /*"      *                   COM RESTITUICAO)                             *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 - PROJETO AUTO FACIL    CADMUS 74582               *      */
        /*"      *   EM 09/01/2013 - COREON            PROCURAR: V.22             *      */
        /*"      *   EM 12/06/2013 - COREON            PROCURAR: V.22B            *      */
        /*"      *                  (NAO GERAR MULTA PARA O SEGUNDO VENCIMENTO)   *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21 - CAD 78619/2013                                   *      */
        /*"      *   ALTERACOES PARA AJUSTE DO PREMIO LIQUIDO A PARTIR DE 08/04/13       */
        /*"      *                                     PROCURAR: V.21                    */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20 - CAD 67607/2012 - INCLUIR AS APOLICES 107700000021*      */
        /*"      *          E 107700000023 / MIN. DO EXERCITO E SIAPX             *      */
        /*"      *   EM 01/10/2012 - JEFFERSON P. O.   PROCURAR: V.20             *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19 - CAD 67607/2012 - JOGAR 100 NO PCT_COBERTURA      *      */
        /*"      *   EM 27/09/2012 - JEFFERSON P. O.   PROCURAR: V.19             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18 - CAD 67607/2012 - IMPLEMENTACAO APORTE CAIXA      *      */
        /*"      * IF    5/06/2012 - JEFFERSON P. O.   PROCURAR: V.18             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *       AO 17 - CAD 71481      - SUBTRAIR VALOR DO IOF           *      */
        /*"      * END-IF APOLICES 106800000018 E PRODUTO 6821                    *      */
        /*"      *                 106800000011 E PRODUTO 6812.                   *      */
        /*"      *   EM 06/07/2012 - DIOGO MATHEUS     PROCURAR: V.17             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17 - CAD 64885/2011 - CORRIGIR ENDOSSO DE 1,00        *      */
        /*"      *   EM 23/12/2011 - ROGERIO S. A.     PROCURAR: V.16             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16 - CAD 64885/2011 - CORRIGIR ENDOSSO DE 1,00        *      */
        /*"      *   EM 23/12/2011 - ROGERIO S. A.     PROCURAR: V.16             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15 - CAD 61050/2011 - REN 2012 - ALTERADA ROTINA      *      */
        /*"      *              LT3151S E LT2118S - DESCONTO BLINDAGEM            *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 - CAD 61509/2011 - REABILITAR A RECUPERACAO DO IOF *      */
        /*"      *               CALCULADO NO EF PARA A APOLICE DO BANCO LUSO QUE *      */
        /*"      *               FOI INIBIDO NA VERSAO 10.                        *      */
        /*"      *                                                                *      */
        /*"      *               INCLUIR O SUM NA CONSULTA DO PARAGRAFO B2090-10  *      */
        /*"      *               PARA EVITAR ABEND.                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/09/2011 - ROGERIO S. A.     PROCURAR: V.14             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - CAD 58647/2011 - NAO ESTA SENDO CALCULADO O IOF  *      */
        /*"      *               PARA O PRODUTO PRESTAMISTA 7709 E 7701. O PROGRA-*      */
        /*"      *               MA DEVERA PASSAR A FAZER O CALCULO DO IOF.       *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/07/2011 - JEFFERSON P. O.   PROCURAR: V.13             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 56869/2011 - INCIDENTE EMISSAO CONSORCIO     *      */
        /*"      *               NAO FOI GERADO PREMIO CONS. NA EF_PREMIO_EMITIDO,*      */
        /*"      *               MAS FOI CRIADA UMA APLICACAO QUE CADASTRA MANU-  *      */
        /*"      *               ALMENTE PREMIO E IOF NA EF_FATURA PELO EFP. ALTE-*      */
        /*"      *               RADA A CHAMADA DO PREMIO E IOF NO PROC. B2090.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/05/2011 - JEFFERSON P. O.   PROCURAR: V.12             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD 47494/2010 - CIRCULAR 395                    *      */
        /*"      *               NAO IRA MAIS FAZER O UPDATE NA TABELA APOLICE_   *      */
        /*"      *               COBERTURAS, POIS QUEM IRA FAZER A GRAVACAO SEM   *      */
        /*"      *               O IOF, SERA A ROTINA DO EFP WEB QUANDO DA SOLI-  *      */
        /*"      *               CITACAO DO ENDOSSO.                              *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/01/2011 - JEFFERSON P. O.   PROCURAR: V.11             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10 - CAD 51506/2010 - CORRECAO DE ABEND               *      */
        /*"      *               APOLICE 106800000024 DO PRODUTO 6825 (BCO LUSO)  *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/12/2010 - DIOGO MATHEUS     PROCURAR: V.10             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09 - CAD 51492/2010 - CORRECAO DE ABEND               *      */
        /*"      *               ERRO INSERT V0HISTOPARC EM0030B *                       */
        /*"      *                                                                *      */
        /*"      *   EM 14/12/2010 - DIOGO MATHEUS     PROCURAR: V.9              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08 - CAD 49938/2010 - CORRECAO DE ABEND               *      */
        /*"      *               INCLUIR A MOVIMENTACAO DO CAMPO                  *      */
        /*"      *               LTMVPROP-PCT-DESC-EQUIP P/ LT3151-PCT-DESC-COFRE *      */
        /*"      *               ANTES DA CHAMADA DA SUBROTINA LT3151S            *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2010 - ALCIONE ARAUJO    PROCURAR: V08              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 47494/2010 - CIRCULAR 395                    *      */
        /*"      *               SUPORTAR O NOVO RAMO DE COMERCIALIZAçãO DO       *      */
        /*"      *               HABITACIONAL, FORA DO SFH; SUPORTAR O NOVO       *      */
        /*"      *               RAMO DE COMERCIALIZAçãO DO SEGURO GARANTIA       *      */
        /*"      *               CONSTRUTOR - SETOR PúBLICO E PRIVADO E SU-       *      */
        /*"      *               PORTAR NOVOS PRODUTOS QUE SERãO CRIADOS NO       *      */
        /*"      *               RAMO 48 DOS CONTRATOS DO CONSóRCIO.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/10/2010 - MARCELO NEVES     PROCURAR: V07              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 27655/2009 - TRATAMENTO DE ABEND             *      */
        /*"      *               INCLUSAO DE TRATAMENTO PARA EMISSAO DE APOLICE.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/07/2009 - ALCIONE ARAUJO    PROCURAR: V06              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - CAD 18.768/2008                                  *      */
        /*"      *               INCLUSAO DE DESCONTO COMERCIAL PARA O PRODUTO    *      */
        /*"      *               1804                                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/02/2009 - FAST COMPUTER                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - CAD 13.696/2008                                  *      */
        /*"      *               ALTERACAO DE PESQUISA DE RCAP EM DUPLICIDADE.    *      */
        /*"      *               ROTINA - A6200                                   *      */
        /*"      *                                                                *      */
        /*"BRSEG1*   NAO GERAR VALORES PARA ENDOSSOS SEM MOVTO DO MULTIRISCO      *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/10/2008 - CELIA  (CAIXASEG) ALTERACAO NO SELECT        *      */
        /*"      *                   DA ROTINA 2091 EM FUNCAO DO EFP GERAR O      *      */
        /*"      *                   MESMO NUMERO DE ENDOSSO PARA RAMOS DIFERENTES*      */
        /*"      *   EM 19/09/2008 - CELIA  (CAIXASEG) WITH UR NOS SELECTS        *      */
        /*"      *   EM 02/09/2008 - WANGER (FAST COMPUTER)   PROCURE POR V.04    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 13/07/2008 - GILSON PINTO DA SILVA                             *      */
        /*"      *              PROJETO FGV                                       *      */
        /*"      *              INIBIR O COMANDO DISPLAY  - PROCURAR GP0708       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - SSI 20.640/2008                                  *      */
        /*"      *               NA EMISSAO DE ENDOSSOS DOS PRODUTOS 6700 E 6701  *      */
        /*"      *               O IOF DEVERA SER O DO INICIO DE VIGENCIA.        *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/02/2008 - FAST COMPUTER            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - SSI 20.603/2008                                  *      */
        /*"      *               AS APOLICES DO PRODUTO 7114 ESTAO SAINDO COM     *      */
        /*"      *               VALORES DE IMP.SEGURADA, PREMIO COM VALORES      *      */
        /*"      *               ZERADOS.                                         *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/02/2008 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - SSI 20.606/2008                                  *      */
        /*"      *               O PRODUTO 6701 DEVERA SAIR COM CUSTO DE R$ 60,00 *      */
        /*"      *               QUANDO DA EMISSãO DO ENDOSSO.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/02/2008 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"KT001 *  *                                                             *      */
        /*"KT001 *  *     EM 05.12.95 POR KITA (PROCAS) .... PROCURE POR /KT001   *      */
        /*"KT001 *  *     . INIBIDA A EMISSAO DE TODOS OS FORMULARIOS ESPECIAIS   *      */
        /*"KT001 *  *     EXCETO FICHAS DE COMPENSACAO E NOTAS DE SEGURO PARA O   *      */
        /*"KT001 *  *     PRODUTO AZULCAR (SASSE) ..... CODPRODU 3101-3102        *      */
        /*"KT001 *  *     . INCLUSAO DA SOLICITACAO DO RELATORIO EM0015B          *      */
        /*"KT001 *  *                                                             *      */
        /*"KT001 *  ***************************************************************      */
        /*"KT002 *  *     EM 11.06.96 POR KITA (PROCASEG)... PROCURE POR /KT002   *      */
        /*"KT002 *  *     . EM FUNCAO DE ERRO NO PROCESSAMENTO.                   *      */
        /*"KT002 *  *                                                             *      */
        /*"KT002 *  ***************************************************************      */
        /*"FO001 *  ***************************************************************      */
        /*"FO001 *  *     EM 16.07.98 POR FONSECA .......... PROCURE POR /FO001   *      */
        /*"FO001 *  *     . FEITO O AJUSTE DO IOF DAS APOLICES DO VIDA.           *      */
        /*"FO001 *  *       O PGM PASSA A LER A V0FATURAS E V0FATURASFIL PARA     *      */
        /*"FO001 *  *       RECUPERAR O PREMIO BRUTO TOTAL E RECALCULA O IOF      *      */
        /*"FO001 *  *       PELA DIFERENCA ENTRE ESSE PREMIO E O LIQUIDO, A FIM   *      */
        /*"FO001 *  *       DE QUE O IOF E O PREMIO BRUTO SEJAM IGUAIS AOS        *      */
        /*"FO001 *  *       CALCULADOS NA FATURA DO VIDA.                         *      */
        /*"FO001 *  *                                                             *      */
        /*"FO001 *  ***************************************************************      */
        /*"      *  ***************************************************************      */
        /*"      *  *                                                             *      */
        /*"      *  *     EM 23.07.98 POR CLOVIS ........... PROCURE POR /CL001   *      */
        /*"      *  *     . O PROGRAMA ESTAVA PERMITINDO QUE HOUVESSE BAIXAS      *      */
        /*"      *  *       DE MAIS DE UMA PARCELA PARA O MESMO RCAP.             *      */
        /*"      *  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"      *  *                                                             *      */
        /*"      *  *     EM 05.10.98 POR CLOVIS ........... PROCURE POR /CL002   *      */
        /*"      *  *     . ATUALIZA O SALDO DO AVISO QDO HOUVER BAIXA DO RCAP.   *      */
        /*"      *  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"      *  * 29/12/98 - CONSEDA4                                         *      */
        /*"      *  * ALTERACAO DO CALCULO DO IOF - ACESSO A TABELA V2RAMO        *      */
        /*"      *  ***************************************************************      */
        /*"      *  * 09/11/2000 - EDUARDO (PRODEXTER)                            *      */
        /*"      *  * EXCLUSAO DE DISPLAY DE VARIAVEIS - PROCURAR POR ED1100      *      */
        /*"      *  ***************************************************************      */
        /*"      *  * 10/11/2000 - EDUARDO (PRODEXTER)                            *      */
        /*"      *  * ACERTO NO CALCULO DAS DATAS DE VENCIMENTO                   *      */
        /*"      *  ***************************************************************      */
        /*"      *  * 19/12/2000 - EDUARDO (PRODEXTER)                            *      */
        /*"      *  * VERIFICA DIA BASE APOS CALCULO DA DATA DE VENCIMENTO        *      */
        /*"      *  ***************************************************************      */
        /*"      *  * 30/01/2001 - EDUARDO (PRODEXTER)                            *      */
        /*"      *  * VERIFICA SE VENCIMENTO COMANDADOS > DIA + 1 UTIL            *      */
        /*"      *  ***************************************************************      */
        /*"      *  * 10/03/2003 - TERCIO CARVALHO                                *      */
        /*"      *  * PASSA A TRATAR O RAMO 77 - APOLICES VIDA PRESTAMISTA.       *      */
        /*"      *  ***************************************************************      */
        /*"CL0503*  * 08/05/2003 - CLOVIS    VER  CL0503  E  *CL5*                *      */
        /*"      *  *              NOVA NUMERACAO DE TITULO                       *      */
        /*"      *  *              DEIXA DE UTILIZAR A NUMERACAO DA V0BANCO       *      */
        /*"      *  *              PASSANDO A UTILIZAR A NUMERACAO DA V0CEDENTE   *      */
        /*"      *  *              CODCDT = 60                                    *      */
        /*"      *  *                                                             *      */
        /*"      *  * PROCESSOS INIBIDOS           PROCESSOS INCLUIDOS            *      */
        /*"      *  *                                                             *      */
        /*"      *  * A3600-LE-V0BANCO             R0320-00-SELECT-V0CEDENTE      *      */
        /*"      *  * A3700-ATU-V0BANCO            R2060-00-ALTERA-V0CEDENTE      *      */
        /*"      *  * A6100-TITULO-CEF             R6100-NOVO-TITULO-CEF          *      */
        /*"      *  * A7000-CALCULA-DIGITO                                        *      */
        /*"      *  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"      *  ***************************************************************      */
        /*"LF1610*  *     ALTERACOES                                              *      */
        /*"LF1610*  *                                                             *      */
        /*"LF1610*  *     EM 16.10.03 POR FERNANDO ........ PROCURE POR /LF1610   *      */
        /*"LF1610*  *     . INCLUSAO DA SOLICITACAO DO RELATORIO EM0015B PARA OS  *      */
        /*"LF1610*  *       RAMOS 40 E 67.                                        *      */
        /*"LF1610*  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"      *  ***************************************************************      */
        /*"      *  ***************************************************************      */
        /*"OL0305*  *     ALTERACOES                                              *      */
        /*"OL0305*  *                                                             *      */
        /*"OL0305*  *     EM 03/05/04 POR OLIVEIRA ........ PROCURE POR /OL0305   *      */
        /*"OL0305*  *     . COLOCA SITUACAO '1' PARA EM0200B E EM0220B NA         *      */
        /*"OL0305*  *     . GERACAO DA EMISDIARIA - SE PRODUTO 1803               *      */
        /*"OL0305*  *       PRODUTO 1803 ( LOTERICOS ) - EMISSAO ESPECIAL         *      */
        /*"OL0305*  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"CHICON*  *     ALTERACOES                                              *      */
        /*"CHICON*  *                                                             *      */
        /*"CHICON*  *     EM 03/07/05 POR CHICON A ........ PROCURE POR /CHICON   *      */
        /*"CHICON*  *     . MULTIPLICA VALORES DAS TABELAS PARCELAS E             *      */
        /*"CHICON*  *     . PARCELA_HISTORICO POR -1 QUANDO OS MESMOS FOREM       *      */
        /*"CHICON*  *       NEGATIVOS                                             *      */
        /*"CHICON*  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"      *  ***************************************************************      */
        /*"      *  *     ALTERACOES                                              *      */
        /*"      *  *                                                             *      */
        /*"      *  *     EM 07/03/07 POR TERCIO .......... PROCURE POR /FC0703   *      */
        /*"      *  *     . PASSA A CONSIDERAR O DESCONTO DE FIDELIZACAO PARA     *      */
        /*"      *  *       O MULTIRISCO EMPRESARIAL E TRATAR O PRODUTO 1804      *      */
        /*"      *  *                                                             *      */
        /*"      *  *                                                             *      */
        /*"      *  ***************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis IX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  WS-DT-AUX.*/
        public EM0030B_WS_DT_AUX WS_DT_AUX { get; set; } = new EM0030B_WS_DT_AUX();
        public class EM0030B_WS_DT_AUX : VarBasis
        {
            /*"    03 WS-ANO-AUX            PIC  X(04) VALUE SPACES.*/
            public StringBasis WS_ANO_AUX { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"    03 WS-P1-AUX             PIC  X(01) VALUE SPACES.*/
            public StringBasis WS_P1_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03 WS-MES-AUX            PIC  X(02) VALUE SPACES.*/
            public StringBasis WS_MES_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"    03 WS-P2-AUX             PIC  X(01) VALUE SPACES.*/
            public StringBasis WS_P2_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    03 WS-DIA-AUX            PIC  X(02) VALUE SPACES.*/
            public StringBasis WS_DIA_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"77  WS-VL-IOF-IGUAIS         PIC  X(01) VALUE SPACES.*/
        }
        public StringBasis WS_VL_IOF_IGUAIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  WHOST-NUM-APOLICE-EF     PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUM_APOLICE_EF { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  WHOST-COD-COBERTURA      PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WS-APOLICOB-PCT-COB-61   PIC S9(03)V9(3) COMP-3 VALUE +0.*/
        public DoubleBasis WS_APOLICOB_PCT_COB_61 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(3)"), 3);
        /*"77  WS-APOLICOB-PCT-COB-65   PIC S9(03)V9(3) COMP-3 VALUE +0.*/
        public DoubleBasis WS_APOLICOB_PCT_COB_65 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(3)"), 3);
        /*"77  WS-APOLICOB-PCT-COB-14   PIC S9(03)V9(3) COMP-3 VALUE +0.*/
        public DoubleBasis WS_APOLICOB_PCT_COB_14 { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(3)"), 3);
        /*"77  WHOST-DTINIVIG           PIC  X(10).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  WHOST-DTCURRENT          PIC  X(10) VALUE SPACES.*/
        public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  WHOST-DTCALEND1          PIC  X(10) VALUE SPACES.*/
        public StringBasis WHOST_DTCALEND1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  WHOST-DTCALEND2          PIC  X(10) VALUE SPACES.*/
        public StringBasis WHOST_DTCALEND2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  WHOST-QTDIAS             PIC S9(09) VALUE +0 COMP.*/
        public IntBasis WHOST_QTDIAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  WS-PCT-IOF               PIC S9(003)V9(5)  VALUE +0.*/
        public DoubleBasis WS_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(5)"), 5);
        /*"77  WS-MOV-DTVENCTO          PIC X(050) VALUE SPACES.*/
        public StringBasis WS_MOV_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"77  WS-MOV-DTQITBCO          PIC X(050) VALUE SPACES.*/
        public StringBasis WS_MOV_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
        /*"77  WSITUACAO                PIC  X(01).*/
        public StringBasis WSITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  VIND-QTITENS             PIC S9(04) COMP.*/
        public IntBasis VIND_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-TARIFARIO           PIC S9(04) COMP.*/
        public IntBasis VIND_TARIFARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTVENCTO            PIC S9(04) COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-CODPRODU            PIC S9(04) COMP.*/
        public IntBasis VIND_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-DTLIBER             PIC S9(04) COMP.*/
        public IntBasis VIND_DTLIBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-VLCUSEMI            PIC S9(04) COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-CFPREFIX            PIC S9(04) COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  VIND-COD-EMPRESA         PIC S9(04) COMP.*/
        public IntBasis VIND_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PCT-DESCONTO-TOTAL       PIC S9(3)V9(4) COMP-3.*/
        public DoubleBasis PCT_DESCONTO_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"77  WPARM01-AUX              PIC S9(009) COMP-3  VALUE  ZEROS.*/
        public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  WQUOCIENTE               PIC S9(004) COMP-3  VALUE  ZEROS.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WRESTO                   PIC S9(004) COMP-3  VALUE  ZEROS.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77           SIST-DTMOVABE               PIC X(010).*/
        public StringBasis SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77           SIST-DTMOVABE-CO            PIC X(010).*/
        public StringBasis SIST_DTMOVABE_CO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  PARM-RAMO-VG            PIC S9(04) COMP.*/
        public IntBasis PARM_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARM-RAMO-AP            PIC S9(04) COMP.*/
        public IntBasis PARM_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARM-RAMO-VGAPC         PIC S9(04) COMP.*/
        public IntBasis PARM_RAMO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARM-RAMO-SAUDE         PIC S9(04) COMP.*/
        public IntBasis PARM_RAMO_SAUDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARM-RAMO-PRESTA        PIC S9(04) COMP.*/
        public IntBasis PARM_RAMO_PRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARM-CODLIDER           PIC S9(04) COMP.*/
        public IntBasis PARM_CODLIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  SUB-OPC-CORRETAGEM      PIC  X(01).*/
        public StringBasis SUB_OPC_CORRETAGEM { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-NUM-APOLICE        PIC S9(13) COMP-3.*/
        public IntBasis APOL_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  APOL-COD-CLIENTE        PIC S9(09) COMP.*/
        public IntBasis APOL_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  APOL-COD-EMPRESA        PIC S9(09) COMP.*/
        public IntBasis APOL_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  APOL-MODALIDA           PIC S9(04) COMP.*/
        public IntBasis APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  APOL-IND-ENDOS-MAN      PIC X(01).*/
        public StringBasis APOL_IND_ENDOS_MAN { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-NUM-ITEM           PIC S9(09) COMP.*/
        public IntBasis APOL_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  APOL-ORGAO              PIC S9(04) COMP.*/
        public IntBasis APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  APOL-PCCOSSEG           PIC S9(04)V9(05) COMP-3.*/
        public DoubleBasis APOL_PCCOSSEG { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(04)V9(05)"), 5);
        /*"77  APOL-PCDESCON           PIC S9(03)V9(02) COMP-3.*/
        public DoubleBasis APOL_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"77  APOL-PCIOCC             PIC S9(03)V9(02) COMP-3.*/
        public DoubleBasis APOL_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"77  APOL-QTCOSSEG           PIC S9(04) COMP.*/
        public IntBasis APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  APOL-BCOCOBR            PIC S9(04) COMP.*/
        public IntBasis APOL_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  APOL-AGECOBR            PIC S9(04) COMP.*/
        public IntBasis APOL_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  APOL-RAMO               PIC S9(04) COMP.*/
        public IntBasis APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  APOL-TIPO-APOLICE       PIC X(01).*/
        public StringBasis APOL_TIPO_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-TIPO-CALCULO       PIC X(01).*/
        public StringBasis APOL_TIPO_CALCULO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-TPCOSSEG           PIC X(01).*/
        public StringBasis APOL_TPCOSSEG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-TIPO-SEGURO        PIC X(01).*/
        public StringBasis APOL_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  APOL-TIPO-PESSOA        PIC X(01).*/
        public StringBasis APOL_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  RAMO-ISENTA-CUSTO           PIC  X(01).*/
        public StringBasis RAMO_ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  RAMO-TIPOFRAC               PIC  X(01).*/
        public StringBasis RAMO_TIPOFRAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  RAMOIND-PCIOF               PIC S9(03)V9999 COMP-3 VALUE +0.*/
        public DoubleBasis RAMOIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"77  RAMO-PERC-IOF               PIC S9(03)V9999 COMP-3 VALUE +0.*/
        public DoubleBasis RAMO_PERC_IOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
        /*"77  V1RAMO-PCIOF                PIC S9(003)V99 COMP-3 VALUE +0.*/
        public DoubleBasis V1RAMO_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"77  CONT-SITUACAO               PIC  X(01).*/
        public StringBasis CONT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  CONT-PENVIS                 PIC  X(01).*/
        public StringBasis CONT_PENVIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  CONT-OCORHIST               PIC S9(04)      COMP   VALUE +0.*/
        public IntBasis CONT_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ACOM-FONTE                  PIC S9(04)      COMP.*/
        public IntBasis ACOM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ACOM-NRPROPOS               PIC S9(09)      COMP.*/
        public IntBasis ACOM_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  ACOM-OPERACAO               PIC S9(04)      COMP.*/
        public IntBasis ACOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ACOM-DATOPR                 PIC  X(10).*/
        public StringBasis ACOM_DATOPR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ACOM-HORAOPER               PIC  X(08).*/
        public StringBasis ACOM_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  ACOM-OCORHIST               PIC S9(09)      COMP.*/
        public IntBasis ACOM_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  ACOM-CODUSU                 PIC  X(08).*/
        public StringBasis ACOM_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  ACOM-COD-EMPRESA            PIC S9(09)      COMP.*/
        public IntBasis ACOM_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  ACOM-EMPRESA-I              PIC S9(04)      COMP.*/
        public IntBasis ACOM_EMPRESA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-OCORHIST                  PIC S9(04)      COMP.*/
        public IntBasis W_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-NUM-APOLICE        PIC S9(13)       COMP-3.*/
        public IntBasis ENDO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  ENDO-NRENDOS            PIC S9(09) COMP.*/
        public IntBasis ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  ENDO-NRPROPOS           PIC S9(09) COMP.*/
        public IntBasis ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  ENDO-CODSUBES           PIC S9(04) COMP.*/
        public IntBasis ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-ORGAO              PIC S9(04) COMP.*/
        public IntBasis ENDO_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-RAMO               PIC S9(04) COMP.*/
        public IntBasis ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-FONTE              PIC S9(04) COMP.*/
        public IntBasis ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-BCOCOBR            PIC S9(04) COMP.*/
        public IntBasis ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-AGECOBR            PIC S9(04) COMP.*/
        public IntBasis ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-COD-MOEDA-PRM      PIC S9(04) COMP.*/
        public IntBasis ENDO_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-DTEMIS             PIC  X(10).*/
        public StringBasis ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-DATPRO             PIC  X(10).*/
        public StringBasis ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-DTINIVIG           PIC  X(10).*/
        public StringBasis ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-DTTERVIG           PIC  X(10).*/
        public StringBasis ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-DT-LIBERACAO       PIC  X(10).*/
        public StringBasis ENDO_DT_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-OCORHIST           PIC S9(04) COMP.*/
        public IntBasis ENDO_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-PCADICIO           PIC S9(03)V9(02) COMP-3.*/
        public DoubleBasis ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"77  ENDO-PCENTRAD           PIC S9(03)V9(02) COMP-3.*/
        public DoubleBasis ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"77  ENDO-PCDESCON           PIC S9(03)V9(02) COMP-3.*/
        public DoubleBasis ENDO_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
        /*"77  ENDO-QTPARCEL           PIC S9(04) COMP.*/
        public IntBasis ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-PRESTA1            PIC S9(04) COMP.*/
        public IntBasis ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-SITUACAO           PIC  X(01).*/
        public StringBasis ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-TIPO-ENDOSSO       PIC  X(01).*/
        public StringBasis ENDO_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-NRRCAP             PIC S9(09) COMP.*/
        public IntBasis ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  ENDO-VLRCAP             PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  ENDO-DATARCAP           PIC  X(10).*/
        public StringBasis ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-DATARCAP-I         PIC S9(04) COMP.*/
        public IntBasis ENDO_DATARCAP_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-BCORCAP            PIC S9(04) COMP.*/
        public IntBasis ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-AGERCAP            PIC S9(04) COMP.*/
        public IntBasis ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-ISENTA-CUSTO       PIC  X(01).*/
        public StringBasis ENDO_ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-ISECUSTO-I         PIC S9(04) COMP.*/
        public IntBasis ENDO_ISECUSTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-TIPO-APOL          PIC X(01).*/
        public StringBasis ENDO_TIPO_APOL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-QTITENS            PIC S9(04) COMP.*/
        public IntBasis ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-DTVENCTO           PIC  X(10).*/
        public StringBasis ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  ENDO-CORRECAO           PIC  X(01).*/
        public StringBasis ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-NUMBIL             PIC S9(15) COMP-3.*/
        public IntBasis ENDO_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  ENDO-CODPRODU           PIC S9(04) COMP.*/
        public IntBasis ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-PODPUBL            PIC  X(01).*/
        public StringBasis ENDO_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-TIPSEGU            PIC  X(01).*/
        public StringBasis ENDO_TIPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  ENDO-VLCUSEMI           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  ENDO-COD-USUARIO        PIC  X(08).*/
        public StringBasis ENDO_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  ENDO-COD-EMPRESA        PIC S9(04) COMP.*/
        public IntBasis ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  ENDO-CFPREFIX           PIC S9(4)V9(5)   COMP-3.*/
        public DoubleBasis ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"77  AUTA-NRPRRESS           PIC S9(09) COMP.*/
        public IntBasis AUTA_NRPRRESS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  AUTA-TIPO-COBRANCA      PIC  X(01).*/
        public StringBasis AUTA_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PRCB-TIPO-COBRANCA      PIC  X(01).*/
        public StringBasis PRCB_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PRCB-DIA-DEBITO         PIC S9(04) COMP.*/
        public IntBasis PRCB_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARC-NUM-APOLICE        PIC S9(13)       COMP-3.*/
        public IntBasis PARC_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  PARC-NRENDOS            PIC S9(09) COMP.*/
        public IntBasis PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  PARC-NRPARCEL           PIC S9(04) COMP.*/
        public IntBasis PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARC-DACPARC            PIC  X(01).*/
        public StringBasis PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PARC-NRTIT              PIC S9(13)       COMP-3.*/
        public IntBasis PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  PARC-DACPARCEL          PIC X(01).*/
        public StringBasis PARC_DACPARCEL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PARC-OCORHIST           PIC S9(04) COMP.*/
        public IntBasis PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARC-PCADICIO           PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-FONTE              PIC S9(04) COMP.*/
        public IntBasis PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARC-TARIFARIO-IX       PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-DESCONTO-IX        PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_DESCONTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-OTNPRLIQ           PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-OTNADFRA           PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-OTNCUSTO           PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-OTNIOF             PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-OTNTOTAL           PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  PARC-QTDDOC             PIC S9(04) COMP.*/
        public IntBasis PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARC-SITUACAO           PIC X(01).*/
        public StringBasis PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PARC-COD-EMPRESA        PIC S9(09) COMP.*/
        public IntBasis PARC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  PARC-SIT-COBRANCA       PIC  X(01).*/
        public StringBasis PARC_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  PARC-EMPRESA-I          PIC S9(04) COMP.*/
        public IntBasis PARC_EMPRESA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  PARC-COBRANCA-I         PIC S9(04) COMP.*/
        public IntBasis PARC_COBRANCA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-NUM-APOLICE        PIC S9(13) COMP-3.*/
        public IntBasis HIST_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HIST-NRENDOS            PIC S9(09) COMP.*/
        public IntBasis HIST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HIST-NRPARCEL           PIC S9(04) COMP.*/
        public IntBasis HIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-DACPARC            PIC  X(01).*/
        public StringBasis HIST_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  HIST-DTMOVTO            PIC  X(10).*/
        public StringBasis HIST_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HIST-OPERACAO           PIC S9(04) COMP.*/
        public IntBasis HIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-HORAOPER           PIC X(08).*/
        public StringBasis HIST_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  HIST-OCORHIST           PIC S9(04) COMP.*/
        public IntBasis HIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-PRM-TARIFARIO      PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_PRM_TARIFARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VAL-DESCONTO       PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VLPRMLIQ           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VLADIFRA           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VLCUSEMI           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VLIOCC             PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VLPRMTOT           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-VLPREMIO           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis HIST_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  HIST-DTVENCTO           PIC X(10).*/
        public StringBasis HIST_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HIST-BCOCOBR            PIC S9(04) COMP.*/
        public IntBasis HIST_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-AGECOBR            PIC S9(04) COMP.*/
        public IntBasis HIST_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-NRAVISO            PIC S9(09) COMP.*/
        public IntBasis HIST_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HIST-NRENDOCA           PIC S9(09) COMP.*/
        public IntBasis HIST_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HIST-SITCONTB           PIC  X(01).*/
        public StringBasis HIST_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  HIST-COD-USUARIO        PIC  X(08).*/
        public StringBasis HIST_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  HIST-RNUDOC             PIC S9(09) COMP.*/
        public IntBasis HIST_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HIST-COD-EMPRESA        PIC S9(09) COMP.*/
        public IntBasis HIST_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  HIST-EMPRESA-I          PIC S9(04) COMP.*/
        public IntBasis HIST_EMPRESA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HIST-DTQITBCO           PIC  X(10).*/
        public StringBasis HIST_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HIST-DTQITBCO-I         PIC S9(04) COMP.*/
        public IntBasis HIST_DTQITBCO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  MOED-VALOR              PIC S9(06)V9(09) COMP-3.*/
        public DoubleBasis MOED_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(09)"), 9);
        /*"77  BANC-BANCO              PIC S9(04)       COMP.*/
        public IntBasis BANC_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  BANC-NRTIT              PIC S9(13)       COMP-3.*/
        public IntBasis BANC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  WHOS-NRTIT              PIC S9(13)       COMP-3  VALUE +0.*/
        public IntBasis WHOS_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  COSS-CODCOSS            PIC S9(04)       COMP.*/
        public IntBasis COSS_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  NORD-NUM-APOLICE        PIC S9(15)       COMP-3.*/
        public IntBasis NORD_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  NORD-NRENDOS            PIC S9(09)       COMP.*/
        public IntBasis NORD_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  NORD-CODCOSS            PIC S9(04)       COMP.*/
        public IntBasis NORD_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  NORD-NRORDEM            PIC S9(15)       COMP-3.*/
        public IntBasis NORD_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  NORD-COD-EMPRESA        PIC S9(09) COMP.*/
        public IntBasis NORD_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  NORD-EMPRESA-I          PIC S9(04) COMP.*/
        public IntBasis NORD_EMPRESA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WORD-NRORDEM            PIC S9(15)       COMP-3.*/
        public IntBasis WORD_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  NUME-NRORDEM            PIC S9(09)       COMP.*/
        public IntBasis NUME_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  COBE-TARIFARIO-VAR      PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis COBE_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  COBE-TARIFARIO-IX       PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis COBE_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  COBT-TARIFARIO-VAR      PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis COBT_TARIFARIO_VAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  COBT-TARIFARIO-IX       PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis COBT_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  APIT-TARIFARIO-IX       PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis APIT_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"77  APIT-QTITENS            PIC S9(04)       COMP.*/
        public IntBasis APIT_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RCAP-FONTE            PIC S9(004)      COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RCAP-DTMOVTO          PIC  X(010).*/
        public StringBasis V0RCAP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0RCAP-NRRCAP           PIC S9(009)      COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0RCAP-NRTIT            PIC S9(013)      COMP-3.*/
        public IntBasis V0RCAP_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  PCOM-AGEAVISO           PIC S9(004)      COMP.*/
        public IntBasis PCOM_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PCOM-BCOAVISO           PIC S9(004)      COMP.*/
        public IntBasis PCOM_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PCOM-DATARCAP           PIC  X(010).*/
        public StringBasis PCOM_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  PCOM-DTCADAST           PIC  X(010).*/
        public StringBasis PCOM_DTCADAST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  PCOM-DTMOVTO            PIC  X(010).*/
        public StringBasis PCOM_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  PCOM-FONTE              PIC S9(004)      COMP.*/
        public IntBasis PCOM_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PCOM-HORAOPER           PIC  X(008).*/
        public StringBasis PCOM_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  PCOM-NRAVISO            PIC S9(009)      COMP.*/
        public IntBasis PCOM_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  PCOM-NRRCAP             PIC S9(009)      COMP.*/
        public IntBasis PCOM_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  PCOM-NRRCAPCO           PIC S9(009)      COMP.*/
        public IntBasis PCOM_NRRCAPCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  PCOM-OPERACAO           PIC S9(004)      COMP.*/
        public IntBasis PCOM_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  PCOM-SITCONTB           PIC  X(001).*/
        public StringBasis PCOM_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  PCOM-SITUACAO           PIC  X(001).*/
        public StringBasis PCOM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  PCOM-VLRCAP             PIC S9(013)V99   COMP-3.*/
        public DoubleBasis PCOM_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V0EDIA-CODRELAT         PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77  V0EDIA-NUM-APOL         PIC S9(013)      COMP-3.*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  V0EDIA-NRENDOS          PIC S9(009)      COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0EDIA-NRPARCEL         PIC S9(004)      COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0EDIA-DTMOVTO          PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0EDIA-ORGAO            PIC S9(004)      COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0EDIA-RAMO             PIC S9(004)      COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0EDIA-FONTE            PIC S9(004)      COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0EDIA-CONGENER         PIC S9(004)      COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0EDIA-CODCORR          PIC S9(009)      COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0EDIA-SITUACAO         PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77  V0EDIA-COD-EMP          PIC S9(004)      COMP.*/
        public IntBasis V0EDIA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0RELA-CODUSU               PIC X(8).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0RELA-DATA-SOLICITACAO     PIC X(10).*/
        public StringBasis V0RELA_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-IDSISTEM             PIC X(2).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"77  V0RELA-CODRELAT             PIC X(8).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0RELA-NRCOPIAS             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-QUANTIDADE           PIC S9(04) COMP.*/
        public IntBasis V0RELA_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-PERI-INICIAL         PIC X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-PERI-FINAL           PIC X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-DATA-REFERENCIA      PIC X(10).*/
        public StringBasis V0RELA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-MES-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-ANO-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-ORGAO                PIC S9(04) COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-MODALIDA             PIC S9(04) COMP.*/
        public IntBasis V0RELA_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CONGENER             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NRCERTIF             PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0RELA-NRTIT                PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-CODSUBES             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-COD-PLANO            PIC S9(04) COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-OCORHIST             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-APOLIDER             PIC X(15).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-ENDOSLID             PIC X(15).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-NUM-PARC-LIDER       PIC S9(04) COMP.*/
        public IntBasis V0RELA_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NUM-SINISTRO         PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis V0RELA_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-NUM-ORDEM            PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0RELA-CODUNIMO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CORRECAO             PIC X(1).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-SITUACAO             PIC X(1).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-PREVIA-DEFINITIVA    PIC X(1).*/
        public StringBasis V0RELA_PREVIA_DEFINITIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-ANAL-RESUMO          PIC X(1).*/
        public StringBasis V0RELA_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-PERI-RENOVACAO       PIC S9(04) COMP.*/
        public IntBasis V0RELA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-PCT-AUMENTO          PIC S9(3)V9(2) COMP-3.*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"77  V0RELA-TIMESTAMP            PIC X(26).*/
        public StringBasis V0RELA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77  V1ASAL-SDOATU             PIC S9(013)V99   VALUE +0  COMP-3.*/
        public DoubleBasis V1ASAL_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  V1ASAL-BCOAVISO           PIC S9(004)      COMP.*/
        public IntBasis V1ASAL_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1ASAL-AGEAVISO           PIC S9(004)      COMP.*/
        public IntBasis V1ASAL_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1ASAL-NRAVISO            PIC S9(009)      COMP.*/
        public IntBasis V1ASAL_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V1PROD-IDEIMPESPC   PIC  X(001).*/
        public StringBasis V1PROD_IDEIMPESPC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0FOLP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0FOLP-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-NRPARCEL     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-DACPARC      PIC  X(001).*/
        public StringBasis V0FOLP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0FOLP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FOLP-HORAOPER     PIC  X(008).*/
        public StringBasis V0FOLP_HORAOPER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77         V0FOLP-VLPREMIO     PIC S9(013)V99   VALUE +0  COMP-3*/
        public DoubleBasis V0FOLP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0FOLP-BCOAVISO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-AGEAVISO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-NRAVISO      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-CODBAIXA     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_CODBAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-CDERRO01     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO02     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO03     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO04     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO05     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-CDERRO06     PIC  X(001).*/
        public StringBasis V0FOLP_CDERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-SITUACAO     PIC  X(001).*/
        public StringBasis V0FOLP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-SITCONTB     PIC  X(001).*/
        public StringBasis V0FOLP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0FOLP-OPERACAO     PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0FOLP-DTLIBER      PIC  X(010).*/
        public StringBasis V0FOLP_DTLIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FOLP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0FOLP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0FOLP-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0FOLP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0FOLP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0FOLP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"77         V1PRFI-VL-IOF-DFI   PIC  S9(006)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V1PRFI_VL_IOF_DFI { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V99"), 2);
        /*"77         V1PRFI-VL-IOF-MIP   PIC  S9(006)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V1PRFI_VL_IOF_MIP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V99"), 2);
        /*"77         V0NOVA-VL-IOF-MIP   PIC  S9(006)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V0NOVA_VL_IOF_MIP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V99"), 2);
        /*"77         V0NOVA-VL-IOF-DFI   PIC  S9(006)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V0NOVA_VL_IOF_DFI { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V99"), 2);
        /*"77  V0PRHA-CODPRODU            PIC  S9(004)             COMP.*/
        public IntBasis V0PRHA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V0PRHA-CODCLIEN            PIC  S9(009)             COMP.*/
        public IntBasis V0PRHA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V0PRHA-VAL-IOF-TOTAL       PIC  S9(006)V99 VALUE +0 COMP-3.*/
        public DoubleBasis V0PRHA_VAL_IOF_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V99"), 2);
        /*"77  V0PRHA-DTINIVIG            PIC   X(010).*/
        public StringBasis V0PRHA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V0PRHA-VAL-IOF-TOTAL-ABS   PIC   9(006)V99 VALUE  0 COMP-3.*/
        public DoubleBasis V0PRHA_VAL_IOF_TOTAL_ABS { get; set; } = new DoubleBasis(new PIC("9", "6", "9(006)V99"), 2);
        /*"77  FATU-VLPRMTOT           PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis FATU_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  FATU-VLIOCC             PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis FATU_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"77  WSHOST-NRTIT13          PIC S9(013)      COMP-3.*/
        public IntBasis WSHOST_NRTIT13 { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WSHOST-TIT-FACIL        PIC S9(013)      COMP-3.*/
        public IntBasis WSHOST_TIT_FACIL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  WSHOST-ORIG-FACIL       PIC S9(013)      COMP-3.*/
        public IntBasis WSHOST_ORIG_FACIL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01 WABEND.*/
        public EM0030B_WABEND WABEND { get; set; } = new EM0030B_WABEND();
        public class EM0030B_WABEND : VarBasis
        {
            /*"   05 FILLER                      PIC X(10) VALUE      ' EM0030B  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" EM0030B  ");
            /*"   05 FILLER                      PIC X(28) VALUE      ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"   05 WNR-EXEC-SQL                PIC X(08) VALUE '00000000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"00000000");
            /*"   05 FILLER                      PIC X(11) VALUE      ' SQLCODE = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @" SQLCODE = ");
            /*"   05 WSQLCODE                    PIC ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01 WERRO               PIC  S9(09)    VALUE ZEROS.*/
        }
        public IntBasis WERRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01          WZEROS              PIC  S9(13)    VALUE +0 COMP-3.*/
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01          WDIFER              PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WDIFER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01          WDIFER-IX           PIC S9(10)V9(05) COMP-3.*/
        public DoubleBasis WDIFER_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
        /*"01          WS-PREMIO-LIQ       PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01          WS-SUBROT-CALC      PIC  X(10).*/
        public StringBasis WS_SUBROT_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WS-COMPL-ENDER           PIC   X(015).*/
        public StringBasis WS_COMPL_ENDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"01  WS-COMPL-ENDER-R REDEFINES WS-COMPL-ENDER.*/
        private _REDEF_EM0030B_WS_COMPL_ENDER_R _ws_compl_ender_r { get; set; }
        public _REDEF_EM0030B_WS_COMPL_ENDER_R WS_COMPL_ENDER_R
        {
            get { _ws_compl_ender_r = new _REDEF_EM0030B_WS_COMPL_ENDER_R(); _.Move(WS_COMPL_ENDER, _ws_compl_ender_r); VarBasis.RedefinePassValue(WS_COMPL_ENDER, _ws_compl_ender_r, WS_COMPL_ENDER); _ws_compl_ender_r.ValueChanged += () => { _.Move(_ws_compl_ender_r, WS_COMPL_ENDER); }; return _ws_compl_ender_r; }
            set { VarBasis.RedefinePassValue(value, _ws_compl_ender_r, WS_COMPL_ENDER); }
        }  //Redefines
        public class _REDEF_EM0030B_WS_COMPL_ENDER_R : VarBasis
        {
            /*"     10 WS-COMPL-CLASSE          PIC   X(01).*/
            public StringBasis WS_COMPL_CLASSE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     10 WS-COMPL-INDICE          PIC   9(02).*/
            public IntBasis WS_COMPL_INDICE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10 FILLER                   PIC   X(12).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
            /*"01  WS-SQLCODE                   PIC ---9.*/

            public _REDEF_EM0030B_WS_COMPL_ENDER_R()
            {
                WS_COMPL_CLASSE.ValueChanged += OnValueChanged;
                WS_COMPL_INDICE.ValueChanged += OnValueChanged;
                FILLER_3.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
        /*"01  WS-VLR-IOF                PIC S9(09)V99 USAGE COMP-3.*/
        public DoubleBasis WS_VLR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2);
        /*"01  WS-VLR-PRM-LIQ            PIC S9(10)V99 USAGE COMP-3.*/
        public DoubleBasis WS_VLR_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V99"), 2);
        /*"01  WS-PERIODO-RENOVACAO         PIC S9(004)  COMP VALUE 2009.*/
        public IntBasis WS_PERIODO_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 2009);
        /*"01  WS-IND                       PIC S9(004)  COMP VALUE 0.*/
        public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-ERRO                      PIC S9(004)  COMP VALUE 0.*/
        public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       LT3121S-NUM-APOLICE     PIC S9(013)  COMP-3.*/
        public IntBasis LT3121S_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01       LT3121S-COD-RETORNO     PIC S9(004)  COMP.*/
        public IntBasis LT3121S_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WS-EF-VLR-EMISSAO       PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-CREDITO       PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-EMISSAO       PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_EMISSAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-CREDITO       PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-EMISSAO-14    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_EMISSAO_14 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-CREDITO-14    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_CREDITO_14 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-EMISSAO-14    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_EMISSAO_14 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-CREDITO-14    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_CREDITO_14 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-EMISSAO-65    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_EMISSAO_65 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-CREDITO-65    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_CREDITO_65 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-EMISSAO-65    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_EMISSAO_65 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-CREDITO-65    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_CREDITO_65 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-EMISSAO-61    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_EMISSAO_61 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-VLR-CREDITO-61    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_VLR_CREDITO_61 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-EMISSAO-61    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_EMISSAO_61 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-EF-IOF-CREDITO-61    PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_EF_IOF_CREDITO_61 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-VL-COB               PIC S9(13)V9(02) COMP-3.*/
        public DoubleBasis WS_VL_COB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(02)"), 2);
        /*"01    WS-PCT-JUROS           PIC S9(003)V9(6) VALUE +0 COMP-3.*/
        public DoubleBasis WS_PCT_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    WS-VLR-MULTA           PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WS_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-VLR-JUROS           PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WS_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WS-VLR-COBRAR          PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis WS_VLR_COBRAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    VLAF-TARIFARIO-IX      PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01    VLAF-DESC-IX           PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_DESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01    VLAF-LIQ-IX            PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_LIQ_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01    VLAF-ADIC-IX           PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_ADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01    VLAF-CUSTO-IX          PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_CUSTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01    VLAF-IOF-IX            PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_IOF_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01    VLAF-TOTAL-IX          PIC S9(12)V9(02) VALUE +0 COMP-3.*/
        public DoubleBasis VLAF_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "12", "S9(12)V9(02)"), 2);
        /*"01          AC-L-V1ENDOSSO      PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_L_V1ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-V0ORDCOSCED    PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_V0ORDCOSCED { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-V0PARCELA      PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-V0RCAPCOMP     PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-V0HISTOPARC    PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-V0EMISDIARIA   PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_V0EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-V0RELATORIO    PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_V0RELATORIO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-AU071          PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_AU071 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-I-TITCAP-LOT     PIC  9(007)   VALUE ZEROS.*/
        public IntBasis AC_I_TITCAP_LOT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"01          AC-COUNT            PIC  9(004)   VALUE ZEROS.*/
        public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"01          WFIM-V1BANCOS       PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_V1BANCOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          WFIM-V1AVISALDOS    PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_V1AVISALDOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          WFIM-V1RCAPCOMP     PIC  X(001)   VALUE SPACES.*/
        public StringBasis WFIM_V1RCAPCOMP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  W-FONTE                     PIC  9(04) VALUE ZEROS.*/
        public IntBasis W_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  W-NRCAP                     PIC  9(09) VALUE ZEROS.*/
        public IntBasis W_NRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  W-HORA.*/
        public EM0030B_W_HORA W_HORA { get; set; } = new EM0030B_W_HORA();
        public class EM0030B_W_HORA : VarBasis
        {
            /*"    03  W-HH                    PIC  9(02).*/
            public IntBasis W_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-MN                    PIC  9(02).*/
            public IntBasis W_MN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-SG                    PIC  9(02).*/
            public IntBasis W_SG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-CC                    PIC  9(02).*/
            public IntBasis W_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01           WTIME-DAY         PIC  99.99.99.99.*/
        }
        public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"01           FILLER            REDEFINES      WTIME-DAY.*/
        private _REDEF_EM0030B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_EM0030B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_EM0030B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
        }  //Redefines
        public class _REDEF_EM0030B_FILLER_4 : VarBasis
        {
            /*"  05         WTIME-DAYR.*/
            public EM0030B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM0030B_WTIME_DAYR();
            public class EM0030B_WTIME_DAYR : VarBasis
            {
                /*"    10       WTIME-HORA        PIC  X(002).*/
                public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WTIME-2PT1        PIC  X(001).*/
                public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-MINU        PIC  X(002).*/
                public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       WTIME-2PT2        PIC  X(001).*/
                public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WTIME-SEGU        PIC  X(002).*/
                public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WTIME-2PT3        PIC  X(001).*/

                public EM0030B_WTIME_DAYR()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_2PT1.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_2PT2.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05         WTIME-CCSE        PIC  X(002).*/
            public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"01           WS-TIME.*/

            public _REDEF_EM0030B_FILLER_4()
            {
                WTIME_DAYR.ValueChanged += OnValueChanged;
                WTIME_2PT3.ValueChanged += OnValueChanged;
                WTIME_CCSE.ValueChanged += OnValueChanged;
            }

        }
        public EM0030B_WS_TIME WS_TIME { get; set; } = new EM0030B_WS_TIME();
        public class EM0030B_WS_TIME : VarBasis
        {
            /*"  05         WS-HH-TIME        PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WS-MM-TIME        PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WS-SS-TIME        PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WS-CC-TIME        PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01           WHOR-REL-LIT.*/
        }
        public EM0030B_WHOR_REL_LIT WHOR_REL_LIT { get; set; } = new EM0030B_WHOR_REL_LIT();
        public class EM0030B_WHOR_REL_LIT : VarBasis
        {
            /*"  05         WHOR-LIT-HH       PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHOR_LIT_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         FILLER            PIC  X(001)    VALUE ':'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"  05         WHOR-LIT-MM       PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHOR_LIT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         FILLER            PIC  X(001)    VALUE ':'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
            /*"  05         WHOR-LIT-SS       PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WHOR_LIT_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"01  W-HORA-EDITADA.*/
        }
        public EM0030B_W_HORA_EDITADA W_HORA_EDITADA { get; set; } = new EM0030B_W_HORA_EDITADA();
        public class EM0030B_W_HORA_EDITADA : VarBasis
        {
            /*"    03  W-HO                    PIC  9(02).*/
            public IntBasis W_HO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '.'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
            /*"    03  W-MI                    PIC  9(02).*/
            public IntBasis W_MI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '.'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
            /*"    03  W-SS                    PIC  9(02).*/
            public IntBasis W_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-INTEIRO                   PIC  9(04).*/
        }
        public IntBasis W_INTEIRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  W-RESTO                     PIC  9(04).*/
        public IntBasis W_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
        /*"01  W-DATA-MIN-1                PIC  X(10).*/
        public StringBasis W_DATA_MIN_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-DATA-MIN-2                PIC  X(10).*/
        public StringBasis W_DATA_MIN_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-DATA-MIN-15               PIC  X(10).*/
        public StringBasis W_DATA_MIN_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  W-DIA-BASE                  PIC  9(02).*/
        public IntBasis W_DIA_BASE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  W-ULTIMO-DIA                PIC  9(02).*/
        public IntBasis W_ULTIMO_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
        /*"01  W-DTTERVIG.*/
        public EM0030B_W_DTTERVIG W_DTTERVIG { get; set; } = new EM0030B_W_DTTERVIG();
        public class EM0030B_W_DTTERVIG : VarBasis
        {
            /*"    03  W-AATERVIG              PIC  9(04).*/
            public IntBasis W_AATERVIG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MMTERVIG              PIC  9(02).*/
            public IntBasis W_MMTERVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DDTERVIG              PIC  9(02).*/
            public IntBasis W_DDTERVIG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-DATA-EDITADA.*/
        }
        public EM0030B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new EM0030B_W_DATA_EDITADA();
        public class EM0030B_W_DATA_EDITADA : VarBasis
        {
            /*"    03  W-ANO                   PIC  9(04).*/
            public IntBasis W_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES                   PIC  9(02).*/
            public IntBasis W_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DIA                   PIC  9(02).*/
            public IntBasis W_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-DATA-DEBITO.*/
        }
        public EM0030B_W_DATA_DEBITO W_DATA_DEBITO { get; set; } = new EM0030B_W_DATA_DEBITO();
        public class EM0030B_W_DATA_DEBITO : VarBasis
        {
            /*"    03  W-ANO-DEB               PIC  9(04).*/
            public IntBasis W_ANO_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-MES-DEB               PIC  9(02).*/
            public IntBasis W_MES_DEB { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03  W-DIA-DEB               PIC  9(02).*/
            public IntBasis W_DIA_DEB { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-DATA-DB2.*/
        }
        public EM0030B_W_DATA_DB2 W_DATA_DB2 { get; set; } = new EM0030B_W_DATA_DB2();
        public class EM0030B_W_DATA_DB2 : VarBasis
        {
            /*"    03  W-ANO-DB2               PIC  9(04).*/
            public IntBasis W_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '-'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    03  W-MES-DB2               PIC  9(02).*/
            public IntBasis W_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '-'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    03  W-DIA-DB2               PIC  9(02).*/
            public IntBasis W_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01      VENCIMENTOS.*/
        }
        public EM0030B_VENCIMENTOS VENCIMENTOS { get; set; } = new EM0030B_VENCIMENTOS();
        public class EM0030B_VENCIMENTOS : VarBasis
        {
            /*" 05     TABELA-VENCIMENTOS.*/
            public EM0030B_TABELA_VENCIMENTOS TABELA_VENCIMENTOS { get; set; } = new EM0030B_TABELA_VENCIMENTOS();
            public class EM0030B_TABELA_VENCIMENTOS : VarBasis
            {
                /*"  10    TBVEN-MASCARA.*/
                public EM0030B_TBVEN_MASCARA TBVEN_MASCARA { get; set; } = new EM0030B_TBVEN_MASCARA();
                public class EM0030B_TBVEN_MASCARA : VarBasis
                {
                    /*"   15   FILLER                  PIC  9(002)    VALUE  ZEROS.*/
                    public IntBasis FILLER_17 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   15   FILLER                  PIC  X(010)    VALUE  SPACES.*/
                    public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"   15   FILLER                  PIC  9(002)    VALUE  ZEROS.*/
                    public IntBasis FILLER_19 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   15   FILLER                  PIC  X(010)    VALUE  SPACES.*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"   15   TBVEN-DATAS.*/
                    public EM0030B_TBVEN_DATAS TBVEN_DATAS { get; set; } = new EM0030B_TBVEN_DATAS();
                    public class EM0030B_TBVEN_DATAS : VarBasis
                    {
                        /*"    20  TBVEN-CAMPOS            OCCURS 12 TIMES INDEXED BY IX1.*/
                        public ListBasis<EM0030B_TBVEN_CAMPOS> TBVEN_CAMPOS { get; set; } = new ListBasis<EM0030B_TBVEN_CAMPOS>(12);
                        public class EM0030B_TBVEN_CAMPOS : VarBasis
                        {
                            /*"     25 TBV-NUM-PARCELA         PIC  9(002).*/
                            public IntBasis TBV_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                            /*"     25 TBV-DT-VENC-CLC         PIC  X(010).*/
                            public StringBasis TBV_DT_VENC_CLC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                            /*"     25 TBV-DIA-MES             PIC  9(002).*/
                            public IntBasis TBV_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                            /*"     25 TBV-DT-VENC-PAR         PIC  X(010).*/
                            public StringBasis TBV_DT_VENC_PAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                            /*" 05     W-DIA-DEBITO            PIC  9(002).*/
                        }
                    }
                }
            }
            public IntBasis W_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*" 05     WTBV-NUM-PARCELA        PIC  9(002).*/
            public IntBasis WTBV_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*" 05     W-FLAG-DATA             PIC  X(001).*/
            public StringBasis W_FLAG_DATA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*" 05     W-DATA-M15.*/
            public EM0030B_W_DATA_M15 W_DATA_M15 { get; set; } = new EM0030B_W_DATA_M15();
            public class EM0030B_W_DATA_M15 : VarBasis
            {
                /*"   10   W-ANO-M15               PIC  9(004).*/
                public IntBasis W_ANO_M15 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10   FILLER                  PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10   W-MES-M15               PIC  9(002).*/
                public IntBasis W_MES_M15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10   FILLER                  PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10   W-DIA-M15               PIC  9(002).*/
                public IntBasis W_DIA_M15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05     LDIFE.*/
            }
            public EM0030B_LDIFE LDIFE { get; set; } = new EM0030B_LDIFE();
            public class EM0030B_LDIFE : VarBasis
            {
                /*"  10    LDIFE01.*/
                public EM0030B_LDIFE01 LDIFE01 { get; set; } = new EM0030B_LDIFE01();
                public class EM0030B_LDIFE01 : VarBasis
                {
                    /*"   15   LDIFE01-DD              PIC  9(002).*/
                    public IntBasis LDIFE01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   15   LDIFE01-MM              PIC  9(002).*/
                    public IntBasis LDIFE01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   15   LDIFE01-AA              PIC  9(004).*/
                    public IntBasis LDIFE01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  10    LDIFE02.*/
                }
                public EM0030B_LDIFE02 LDIFE02 { get; set; } = new EM0030B_LDIFE02();
                public class EM0030B_LDIFE02 : VarBasis
                {
                    /*"   15   LDIFE02-DD              PIC  9(002).*/
                    public IntBasis LDIFE02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   15   LDIFE02-MM              PIC  9(002).*/
                    public IntBasis LDIFE02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   15   LDIFE02-AA              PIC  9(004).*/
                    public IntBasis LDIFE02_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  10    LDIFE03                 PIC S9(005)    COMP-3.*/
                }
                public IntBasis LDIFE03 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*" 05     WC-DATA                 PIC  9(008)    VALUE  ZEROS.*/
            }
            public IntBasis WC_DATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*" 05     FILLER                  REDEFINES      WC-DATA.*/
            private _REDEF_EM0030B_FILLER_23 _filler_23 { get; set; }
            public _REDEF_EM0030B_FILLER_23 FILLER_23
            {
                get { _filler_23 = new _REDEF_EM0030B_FILLER_23(); _.Move(WC_DATA, _filler_23); VarBasis.RedefinePassValue(WC_DATA, _filler_23, WC_DATA); _filler_23.ValueChanged += () => { _.Move(_filler_23, WC_DATA); }; return _filler_23; }
                set { VarBasis.RedefinePassValue(value, _filler_23, WC_DATA); }
            }  //Redefines
            public class _REDEF_EM0030B_FILLER_23 : VarBasis
            {
                /*"  10    WC-DIA                  PIC  9(002).*/
                public IntBasis WC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10    WC-MES                  PIC  9(002).*/
                public IntBasis WC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10    WC-ANO                  PIC  9(004).*/
                public IntBasis WC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01      WS-VERSAO               PIC  X(090)  VALUE       'EM0030B - V.63 - 08/01/2020 - CADMUS 179615            '*/

                public _REDEF_EM0030B_FILLER_23()
                {
                    WC_DIA.ValueChanged += OnValueChanged;
                    WC_MES.ValueChanged += OnValueChanged;
                    WC_ANO.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"EM0030B - V.63 - 08/01/2020 - CADMUS 179615            ");
        /*"01  W-DATA.*/
        public EM0030B_W_DATA W_DATA { get; set; } = new EM0030B_W_DATA();
        public class EM0030B_W_DATA : VarBasis
        {
            /*"    03  W-DD                    PIC  9(02).*/
            public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-MM                    PIC  9(02).*/
            public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-AA                    PIC  9(04).*/
            public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01           PROSOMW099.*/
        }
        public EM0030B_PROSOMW099 PROSOMW099 { get; set; } = new EM0030B_PROSOMW099();
        public class EM0030B_PROSOMW099 : VarBasis
        {
            /*"    03       PROSOM-DATA01     PIC  9(08).*/
            public IntBasis PROSOM_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    03       PROSOM-QTDIA      PIC S9(05)  COMP-3.*/
            public IntBasis PROSOM_QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
            /*"    03       PROSOM-DATA02     PIC  9(08).*/
            public IntBasis PROSOM_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"01           EM0925W099.*/
        }
        public EM0030B_EM0925W099 EM0925W099 { get; set; } = new EM0030B_EM0925W099();
        public class EM0030B_EM0925W099 : VarBasis
        {
            /*"    03       EM0925-DATA01     PIC  9(008).*/
            public IntBasis EM0925_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03       EM0925-DATA02     PIC  9(008).*/
            public IntBasis EM0925_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03       EM0925-QTMES      PIC S9(005)    COMP-3.*/
            public IntBasis EM0925_QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01 PARAM-APORTE-CAIXA.*/
        }
        public EM0030B_PARAM_APORTE_CAIXA PARAM_APORTE_CAIXA { get; set; } = new EM0030B_PARAM_APORTE_CAIXA();
        public class EM0030B_PARAM_APORTE_CAIXA : VarBasis
        {
            /*"   03 EF148-RETORNO             PIC 9(5).*/
            public IntBasis EF148_RETORNO { get; set; } = new IntBasis(new PIC("9", "5", "9(5)."));
            /*"   03 EF148-OPERACAO            PIC X(1).*/
            public StringBasis EF148_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
            /*"   03 EF148-NUM-CONTRATO-APOL   PIC 9(16).*/
            public IntBasis EF148_NUM_CONTRATO_APOL { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
            /*"   03 EF148-COD-PRODUTO         PIC 9(04).*/
            public IntBasis EF148_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   03 EF148-COD-COBERTURA       PIC 9(04).*/
            public IntBasis EF148_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   03 EF148-DTH-INI-VIGENCIA    PIC X(10).*/
            public StringBasis EF148_DTH_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   03 EF148-NUM-RAMO-CONTABIL   PIC 9(04).*/
            public IntBasis EF148_NUM_RAMO_CONTABIL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   03 EF148-COD-PRODUTO-14      PIC 9(04).*/
            public IntBasis EF148_COD_PRODUTO_14 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   03 EF148-COD-COBERTURA-ACESS PIC 9(04).*/
            public IntBasis EF148_COD_COBERTURA_ACESS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   03 EF148-NUM-APOLICE         PIC 9(16).*/
            public IntBasis EF148_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
            /*"   03 EF148-DTH-FIM-VIGENCIA    PIC X(10).*/
            public StringBasis EF148_DTH_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   03 EF148-NUM-APOLICE-EF      PIC 9(16).*/
            public IntBasis EF148_NUM_APOLICE_EF { get; set; } = new IntBasis(new PIC("9", "16", "9(16)."));
            /*"01 TAB-IMPSEG   COMP-3.*/
        }
        public EM0030B_TAB_IMPSEG TAB_IMPSEG { get; set; } = new EM0030B_TAB_IMPSEG();
        public class EM0030B_TAB_IMPSEG : VarBasis
        {
            /*"     10 TB-IMPSEG       PIC S9(10)V99 COMP-3 OCCURS    20 TIMES.*/
            public ListBasis<DoubleBasis, double> TB_IMPSEG { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "10", "S9(10)V99"), 20);
            /*"01 TAB-TAXAS     COMP-3.*/
        }
        public EM0030B_TAB_TAXAS TAB_TAXAS { get; set; } = new EM0030B_TAB_TAXAS();
        public class EM0030B_TAB_TAXAS : VarBasis
        {
            /*"     10 TB-TAXAS        PIC S9(03)V9(09) COMP-3 OCCURS 20 TIMES.*/
            public ListBasis<DoubleBasis, double> TB_TAXAS { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "3", "S9(03)V9(09)"), 20);
            /*"01  W-PARCEL                    PIC S9(04)  VALUE +0 COMP.*/
        }
        public IntBasis W_PARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WCALC-MESES                 PIC S9(05)  VALUE +0 COMP-3.*/
        public IntBasis WCALC_MESES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
        /*"01  W-NUMR-TITULO               PIC  9(13)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"01  FILLER                      REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_EM0030B_FILLER_24 _filler_24 { get; set; }
        public _REDEF_EM0030B_FILLER_24 FILLER_24
        {
            get { _filler_24 = new _REDEF_EM0030B_FILLER_24(); _.Move(W_NUMR_TITULO, _filler_24); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_24, W_NUMR_TITULO); _filler_24.ValueChanged += () => { _.Move(_filler_24, W_NUMR_TITULO); }; return _filler_24; }
            set { VarBasis.RedefinePassValue(value, _filler_24, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_EM0030B_FILLER_24 : VarBasis
        {
            /*"    03  WTITL-ZEROS             PIC  9(02).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  WTITL-NRTITULO.*/
            public EM0030B_WTITL_NRTITULO WTITL_NRTITULO { get; set; } = new EM0030B_WTITL_NRTITULO();
            public class EM0030B_WTITL_NRTITULO : VarBasis
            {
                /*"     05 WTITL-SEQUENCIA         PIC  9(10).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                /*"     05 WTITL-DIGITO1           PIC  9(01).*/
                public IntBasis WTITL_DIGITO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"01  CH-ENDOSSO                  PIC  X(01)    VALUE SPACES.*/

                public EM0030B_WTITL_NRTITULO()
                {
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO1.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_EM0030B_FILLER_24()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_NRTITULO.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis CH_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  CH-APOLCOSCED               PIC  X(01)    VALUE SPACES.*/
        public StringBasis CH_APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  W-VALOR-IS                  PIC S9(15)V99 VALUE ZEROS.*/
        public DoubleBasis W_VALOR_IS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
        /*"01  W-VALOR-PREMIO              PIC S9(15)V99 VALUE ZEROS.*/
        public DoubleBasis W_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
        /*"01  W-VALOR-IOF                 PIC S9(15)V99 VALUE ZEROS.*/
        public DoubleBasis W_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
        /*"01  W-VALOR-TOTAL-PREMIO        PIC S9(15)V99 VALUE ZEROS.*/
        public DoubleBasis W_VALOR_TOTAL_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
        /*"01  W-EDICAO1                   PIC ZZZ.ZZZ.ZZ9,99-.*/
        public DoubleBasis W_EDICAO1 { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
        /*"01  W-FIM-APOLICE-COBERTURA     PIC  X(03)  VALUE SPACES.*/
        public StringBasis W_FIM_APOLICE_COBERTURA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  W.*/
        public EM0030B_W W { get; set; } = new EM0030B_W();
        public class EM0030B_W : VarBasis
        {
            /*"    05   WW-ORDEM-ORDE          PIC  9(15)    VALUE ZEROS.*/
            public IntBasis WW_ORDEM_ORDE { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05   FILLER                 REDEFINES     WW-ORDEM-ORDE.*/
            private _REDEF_EM0030B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_EM0030B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_EM0030B_FILLER_25(); _.Move(WW_ORDEM_ORDE, _filler_25); VarBasis.RedefinePassValue(WW_ORDEM_ORDE, _filler_25, WW_ORDEM_ORDE); _filler_25.ValueChanged += () => { _.Move(_filler_25, WW_ORDEM_ORDE); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WW_ORDEM_ORDE); }
            }  //Redefines
            public class _REDEF_EM0030B_FILLER_25 : VarBasis
            {
                /*"      10 WW-LIDER-ORDE          PIC  9(05).*/
                public IntBasis WW_LIDER_ORDE { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"      10 WW-ORGAO-ORDE          PIC  9(03).*/
                public IntBasis WW_ORGAO_ORDE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WW-NRORD-ORDE          PIC  9(07).*/
                public IntBasis WW_NRORD_ORDE { get; set; } = new IntBasis(new PIC("9", "7", "9(07)."));
                /*"01              LPARM01X.*/

                public _REDEF_EM0030B_FILLER_25()
                {
                    WW_LIDER_ORDE.ValueChanged += OnValueChanged;
                    WW_ORGAO_ORDE.ValueChanged += OnValueChanged;
                    WW_NRORD_ORDE.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM0030B_LPARM01X LPARM01X { get; set; } = new EM0030B_LPARM01X();
        public class EM0030B_LPARM01X : VarBasis
        {
            /*"  03            LPARM01         PIC  9(010).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_EM0030B_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_EM0030B_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_EM0030B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_EM0030B_LPARM01_R : VarBasis
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
                /*"    05          LPARM01-7       PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-8       PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-9       PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-10      PIC  9(001).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03            LPARM01-D1      PIC  9(001).*/

                public _REDEF_EM0030B_LPARM01_R()
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
                }

            }
            public IntBasis LPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              EM0901W099.*/
        }
        public EM0030B_EM0901W099 EM0901W099 { get; set; } = new EM0030B_EM0901W099();
        public class EM0030B_EM0901W099 : VarBasis
        {
            /*"    03          RAMO                   PIC S9(04)     COMP.*/
            public IntBasis RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    03          COD-MOEDA              PIC  9(04).*/
            public IntBasis COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03          DTINIVIG               PIC  X(10).*/
            public StringBasis DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    03          NRPARCEL               PIC  9(02).*/
            public IntBasis NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03          QTPARCEL               PIC  9(02).*/
            public IntBasis QTPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03          IND-FRAC               PIC  X(01).*/
            public StringBasis IND_FRAC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03          ISENTA-CUSTO           PIC  X(01).*/
            public StringBasis ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    03          PCIOF                  PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03          PCENTRAD               PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03          PCDESCON-COMERC        REDEFINES                PCENTRAD               PIC S9(03)V9(02) COMP-3.*/
            private _REDEF_DoubleBasis _pcdescon_comerc { get; set; }
            public _REDEF_DoubleBasis PCDESCON_COMERC
            {
                get { _pcdescon_comerc = new _REDEF_DoubleBasis(new PIC("S9", "03", "S9(03)V9(02)"), 2); ; _.Move(PCENTRAD, _pcdescon_comerc); VarBasis.RedefinePassValue(PCENTRAD, _pcdescon_comerc, PCENTRAD); _pcdescon_comerc.ValueChanged += () => { _.Move(_pcdescon_comerc, PCENTRAD); }; return _pcdescon_comerc; }
                set { VarBasis.RedefinePassValue(value, _pcdescon_comerc, PCENTRAD); }
            }  //Redefines
            /*"    03          PCJUROS                PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCJUROS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03          PCDESCON               PIC S9(03)V9(02) COMP-3.*/
            public DoubleBasis PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9(02)"), 2);
            /*"    03          VL-PREMIO-BASE         PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_PREMIO_BASE { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-TARIFARIO-IX        PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DESC-IX             PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_DESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-LIQ-IX              PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_LIQ_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-ADIC-IX             PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_ADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-CUSTO-IX            PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_CUSTO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-IOF-IX              PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_IOF_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-TOTAL-IX            PIC S9(10)V9(05) COMP-3.*/
            public DoubleBasis VL_TOTAL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-TARIFA              PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DESCONTO            PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-LIQUIDO             PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_LIQUIDO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-ADICIONAL           PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_ADICIONAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-CUSTO               PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_CUSTO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-IOF                 PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_IOF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-TOTAL               PIC S9(15)V9(02) COMP-3.*/
            public DoubleBasis VL_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          W01A0077               PIC  X(77).*/
            public StringBasis W01A0077 { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"    03          W01A0077R REDEFINES W01A0077.*/
            private _REDEF_EM0030B_W01A0077R _w01a0077r { get; set; }
            public _REDEF_EM0030B_W01A0077R W01A0077R
            {
                get { _w01a0077r = new _REDEF_EM0030B_W01A0077R(); _.Move(W01A0077, _w01a0077r); VarBasis.RedefinePassValue(W01A0077, _w01a0077r, W01A0077); _w01a0077r.ValueChanged += () => { _.Move(_w01a0077r, W01A0077); }; return _w01a0077r; }
                set { VarBasis.RedefinePassValue(value, _w01a0077r, W01A0077); }
            }  //Redefines
            public class _REDEF_EM0030B_W01A0077R : VarBasis
            {
                /*"     05         FILLER                 PIC  X(06).*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"     05         W01A0077-VERSAO        PIC  9(03).*/
                public IntBasis W01A0077_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"     05         W01A0077-TIPCOB        PIC  X(01).*/
                public StringBasis W01A0077_TIPCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     05         W01A0077-QTPARC        PIC  9(02).*/
                public IntBasis W01A0077_QTPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     05         W01A0077-CODPRO        PIC  9(04).*/
                public IntBasis W01A0077_CODPRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     05         W01A0077-INIVIG        PIC  X(10).*/
                public StringBasis W01A0077_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     05         FILLER                 PIC  X(51).*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)."), @"");
                /*"    03          NRRCAP                 PIC S9(09)       COMP.*/

                public _REDEF_EM0030B_W01A0077R()
                {
                    FILLER_26.ValueChanged += OnValueChanged;
                    W01A0077_VERSAO.ValueChanged += OnValueChanged;
                    W01A0077_TIPCOB.ValueChanged += OnValueChanged;
                    W01A0077_QTPARC.ValueChanged += OnValueChanged;
                    W01A0077_CODPRO.ValueChanged += OnValueChanged;
                    W01A0077_INIVIG.ValueChanged += OnValueChanged;
                    FILLER_27.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    03          VL-COBER-ASSIST        PIC S9(15)V99    COMP-3.*/
            public DoubleBasis VL_COBER_ASSIST { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V99"), 2);
            /*"    03          PCDESCON-ADIC          PIC S9(03)V9999  COMP-3.*/
            public DoubleBasis PCDESCON_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
            /*"    03          PCDESCON-BONUS         PIC S9(03)V9999  COMP-3.*/
            public DoubleBasis PCDESCON_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(03)V9999"), 4);
            /*"01              FILLER.*/
        }
        public EM0030B_FILLER_28 FILLER_28 { get; set; } = new EM0030B_FILLER_28();
        public class EM0030B_FILLER_28 : VarBasis
        {
            /*"    03          VL-TARIFAW     PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_TARIFAW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DESCW       PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DESCW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-LIQW        PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_LIQW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-ADICW       PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_ADICW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-CUSTOW      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_CUSTOW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-IOCCW       PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_IOCCW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-IOCCPT      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_IOCCPT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-TOTALW      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_TOTALW { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-TOTALPT     PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_TOTALPT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-TARIFAW-IX  PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_TARIFAW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DESCW-IX    PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DESCW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-LIQW-IX     PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_LIQW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-ADICW-IX    PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_ADICW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-CUSTOW-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_CUSTOW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-IOCCW-IX    PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_IOCCW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-TOTALW-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_TOTALW_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFTAR      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFTAR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFDESC     PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFDESC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFLIQ      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFLIQ { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFADI      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFADI { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFCUS      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFCUS { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFIOC      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFIOC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFTOT      PIC S9(15)V9(02) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFTOT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
            /*"    03          VL-DIFTAR-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFTAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFDESC-IX  PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFDESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFLIQ-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFLIQ_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFADI-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFADI_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFCUS-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFCUS_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFIOC-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFIOC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"    03          VL-DIFTOT-IX   PIC S9(10)V9(05) VALUE +0 COMP-3.*/
            public DoubleBasis VL_DIFTOT_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(05)"), 5);
            /*"01  WS000-AREA-AUX-RAMO68.*/
        }
        public EM0030B_WS000_AREA_AUX_RAMO68 WS000_AREA_AUX_RAMO68 { get; set; } = new EM0030B_WS000_AREA_AUX_RAMO68();
        public class EM0030B_WS000_AREA_AUX_RAMO68 : VarBasis
        {
            /*"    03  WS000-IOF-RAMO68     PIC S9(015)V9(002) VALUE +0 COMP-3.*/
            public DoubleBasis WS000_IOF_RAMO68 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(002)"), 2);
            /*"    03  WS000-IOF-RAMO68-IX  PIC S9(015)V9(002) VALUE +0 COMP-3.*/
            public DoubleBasis WS000_IOF_RAMO68_IX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(002)"), 2);
            /*"    03  WCH-APOL-HABIT       PIC  X(001)        VALUE 'N'.*/
            public StringBasis WCH_APOL_HABIT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"01 WS-NUM-IDLG.*/
        }
        public EM0030B_WS_NUM_IDLG WS_NUM_IDLG { get; set; } = new EM0030B_WS_NUM_IDLG();
        public class EM0030B_WS_NUM_IDLG : VarBasis
        {
            /*"   10 WS-NUM-IDLG-EMPRESA         PIC X(04) VALUE 'C000'.*/
            public StringBasis WS_NUM_IDLG_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"C000");
            /*"   10 WS-NUM-IDLG-SISTEMA         PIC X(04) VALUE 'SIAS'.*/
            public StringBasis WS_NUM_IDLG_SISTEMA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"SIAS");
            /*"   10 WS-NUM-IDLG-TIPO            PIC X(06) VALUE 'ONLINE'.*/
            public StringBasis WS_NUM_IDLG_TIPO { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"ONLINE");
            /*"   10 WS-NUM-IDLG-APOLICE         PIC 9(13).*/
            public IntBasis WS_NUM_IDLG_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   10 WS-NUM-IDLG-ENDOSSO         PIC 9(04).*/
            public IntBasis WS_NUM_IDLG_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 WS-NUM-IDLG-PARCELA         PIC 9(03).*/
            public IntBasis WS_NUM_IDLG_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"   10 WS-NUM-IDLG-INDICADOR-2VIA  PIC X(01) VALUE ' '.*/
            public StringBasis WS_NUM_IDLG_INDICADOR_2VIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"01 WS-NOSSO-NUMERO-SAP            PIC 9(18).*/
        }
        public IntBasis WS_NOSSO_NUMERO_SAP { get; set; } = new IntBasis(new PIC("9", "18", "9(18)."));
        /*"01 FILLER REDEFINES WS-NOSSO-NUMERO-SAP.*/
        private _REDEF_EM0030B_FILLER_29 _filler_29 { get; set; }
        public _REDEF_EM0030B_FILLER_29 FILLER_29
        {
            get { _filler_29 = new _REDEF_EM0030B_FILLER_29(); _.Move(WS_NOSSO_NUMERO_SAP, _filler_29); VarBasis.RedefinePassValue(WS_NOSSO_NUMERO_SAP, _filler_29, WS_NOSSO_NUMERO_SAP); _filler_29.ValueChanged += () => { _.Move(_filler_29, WS_NOSSO_NUMERO_SAP); }; return _filler_29; }
            set { VarBasis.RedefinePassValue(value, _filler_29, WS_NOSSO_NUMERO_SAP); }
        }  //Redefines
        public class _REDEF_EM0030B_FILLER_29 : VarBasis
        {
            /*"   10 WS-NOSSO-IDEN               PIC 9(04).*/
            public IntBasis WS_NOSSO_IDEN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 WS-NOSSO-NR-TITULO          PIC 9(13).*/
            public IntBasis WS_NOSSO_NR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   10 WS-NOSSO-NR                 PIC 9(01).*/
            public IntBasis WS_NOSSO_NR { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));

            public _REDEF_EM0030B_FILLER_29()
            {
                WS_NOSSO_IDEN.ValueChanged += OnValueChanged;
                WS_NOSSO_NR_TITULO.ValueChanged += OnValueChanged;
                WS_NOSSO_NR.ValueChanged += OnValueChanged;
            }

        }


        public Copies.LBHLT027 LBHLT027 { get; set; } = new Copies.LBHLT027();
        public Copies.LBLT3117 LBLT3117 { get; set; } = new Copies.LBLT3117();
        public Copies.LBLT3164 LBLT3164 { get; set; } = new Copies.LBLT3164();
        public Copies.LBLT3151 LBLT3151 { get; set; } = new Copies.LBLT3151();
        public Copies.LBLT2118 LBLT2118 { get; set; } = new Copies.LBLT2118();
        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.LTMVPRCO LTMVPRCO { get; set; } = new Dclgens.LTMVPRCO();
        public Dclgens.MR021 MR021 { get; set; } = new Dclgens.MR021();
        public Dclgens.MR022 MR022 { get; set; } = new Dclgens.MR022();
        public Dclgens.MRAPOITE MRAPOITE { get; set; } = new Dclgens.MRAPOITE();
        public Dclgens.MRAPOCOB MRAPOCOB { get; set; } = new Dclgens.MRAPOCOB();
        public Dclgens.AU071 AU071 { get; set; } = new Dclgens.AU071();
        public Dclgens.AU077 AU077 { get; set; } = new Dclgens.AU077();
        public Dclgens.AU080 AU080 { get; set; } = new Dclgens.AU080();
        public Dclgens.AU085 AU085 { get; set; } = new Dclgens.AU085();
        public Dclgens.AU084 AU084 { get; set; } = new Dclgens.AU084();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.SX104 SX104 { get; set; } = new Dclgens.SX104();
        public EM0030B_V0ENDOS V0ENDOS { get; set; } = new EM0030B_V0ENDOS();
        public EM0030B_V1COBERAPOL V1COBERAPOL { get; set; } = new EM0030B_V1COBERAPOL();
        public EM0030B_V0APOLCOS V0APOLCOS { get; set; } = new EM0030B_V0APOLCOS();
        public EM0030B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new EM0030B_V1RCAPCOMP();
        public EM0030B_APOLICE_COBERTURAS APOLICE_COBERTURAS { get; set; } = new EM0030B_APOLICE_COBERTURAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-ROTINA-PRINCIPAL-SECTION */

                M_0000_ROTINA_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-ROTINA-PRINCIPAL-SECTION */
        private void M_0000_ROTINA_PRINCIPAL_SECTION()
        {
            /*" -1561- DISPLAY ' ' */
            _.Display($" ");

            /*" -1568- DISPLAY 'EM0030B VERSAO V.01 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"EM0030B VERSAO V.01 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1569- DISPLAY 'EM0030B EH COPIA DO EM0010B' */
            _.Display($"EM0030B EH COPIA DO EM0010B");

            /*" -1570- DISPLAY ' ' */
            _.Display($" ");

            /*" -1572- DISPLAY 'GERACAO DO ENDOSSO DO COBRANCA EM SUBSTITUICAO AO EF 'P' */
            _.Display($"GERACAO DO ENDOSSO DO COBRANCA EM SUBSTITUICAO AO EF P");

            /*" -1573- DISPLAY 'APOLICES 0106100000011 E 0106800000024 - BANCO LUSO' */
            _.Display($"APOLICES 0106100000011 E 0106800000024 - BANCO LUSO");

            /*" -1575- DISPLAY ' ' */
            _.Display($" ");

            /*" -1577- PERFORM A0000-INICIO THRU A0000-999-EXIT. */

            A0000_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: A0000_999_EXIT*/


            /*" -1580- PERFORM B0000-PROCESSA THRU B9999-999-EXIT UNTIL CH-ENDOSSO EQUAL '1' . */

            while (!(CH_ENDOSSO == "1"))
            {

                B0000_PROCESSA_SECTION();

                B0010_LEITURA();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B9999_999_EXIT*/

            }

            /*" -1582- PERFORM B4210-00-INCLUI-RELATORIO. */

            B4210_00_INCLUI_RELATORIO_SECTION();

            /*" -1583- IF CEDENTE-NUM-TITULO NOT EQUAL WSHOST-NRTIT13 */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO != WSHOST_NRTIT13)
            {

                /*" -1584- MOVE 60 TO CEDENTE-COD-CEDENTE */
                _.Move(60, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -1586- MOVE WSHOST-NRTIT13 TO CEDENTE-NUM-TITULO */
                _.Move(WSHOST_NRTIT13, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

                /*" -1587- PERFORM R2060-00-ALTERA-V0CEDENTE */

                R2060_00_ALTERA_V0CEDENTE_SECTION();

                /*" -1589- END-IF */
            }


            /*" -1590- IF WSHOST-ORIG-FACIL NOT = WSHOST-TIT-FACIL */

            if (WSHOST_ORIG_FACIL != WSHOST_TIT_FACIL)
            {

                /*" -1591- MOVE WSHOST-TIT-FACIL TO CEDENTE-NUM-TITULO */
                _.Move(WSHOST_TIT_FACIL, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

                /*" -1593- MOVE 59 TO CEDENTE-COD-CEDENTE */
                _.Move(59, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -1594- PERFORM R2060-00-ALTERA-V0CEDENTE */

                R2060_00_ALTERA_V0CEDENTE_SECTION();

                /*" -1596- END-IF */
            }


            /*" -1596- PERFORM C0000-FIM. */

            C0000_FIM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_999_EXIT*/

        [StopWatch]
        /*" A0000-INICIO-SECTION */
        private void A0000_INICIO_SECTION()
        {
            /*" -1604- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1606- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1608- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1612- PERFORM A1000-LE-SISTEMA. */

            A1000_LE_SISTEMA_SECTION();

            /*" -1614- PERFORM A1100-OBTEM-VENCIMENTO-MINIMO */

            A1100_OBTEM_VENCIMENTO_MINIMO_SECTION();

            /*" -1616- PERFORM A1500-LE-V1PARAMRAMO. */

            A1500_LE_V1PARAMRAMO_SECTION();

            /*" -1618- PERFORM A1600-LE-V1PARAMETRO. */

            A1600_LE_V1PARAMETRO_SECTION();

            /*" -1620- MOVE 59 TO CEDENTE-COD-CEDENTE */
            _.Move(59, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -1622- PERFORM R0320-00-SELECT-V0CEDENTE. */

            R0320_00_SELECT_V0CEDENTE_SECTION();

            /*" -1624- MOVE WSHOST-NRTIT13 TO WSHOST-TIT-FACIL WSHOST-ORIG-FACIL */
            _.Move(WSHOST_NRTIT13, WSHOST_TIT_FACIL, WSHOST_ORIG_FACIL);

            /*" -1626- MOVE 60 TO CEDENTE-COD-CEDENTE. */
            _.Move(60, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -1628- PERFORM R0320-00-SELECT-V0CEDENTE. */

            R0320_00_SELECT_V0CEDENTE_SECTION();

            /*" -1630- PERFORM R2000-DECLARE-V0ENDOSSO. */

            R2000_DECLARE_V0ENDOSSO_SECTION();

            /*" -1630- PERFORM A3000-LE-V0ENDOSSO. */

            A3000_LE_V0ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A0000_999_EXIT*/

        [StopWatch]
        /*" A1000-LE-SISTEMA-SECTION */
        private void A1000_LE_SISTEMA_SECTION()
        {
            /*" -1641- MOVE 'A1000' TO WNR-EXEC-SQL. */
            _.Move("A1000", WABEND.WNR_EXEC_SQL);

            /*" -1649- PERFORM A1000_LE_SISTEMA_DB_SELECT_1 */

            A1000_LE_SISTEMA_DB_SELECT_1();

            /*" -1652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1653- DISPLAY 'EM0030B - NAO HA MOVIMENTO ABERTO P/ EMISSAO' */
                _.Display($"EM0030B - NAO HA MOVIMENTO ABERTO P/ EMISSAO");

                /*" -1654- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1656- END-IF */
            }


            /*" -1662- PERFORM A1000_LE_SISTEMA_DB_SELECT_2 */

            A1000_LE_SISTEMA_DB_SELECT_2();

            /*" -1665- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1666- DISPLAY 'EM0030B - DATA NAO CADASTRADA SISTEMA CO' */
                _.Display($"EM0030B - DATA NAO CADASTRADA SISTEMA CO");

                /*" -1667- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1673- END-IF. */
            }


            /*" -1674- DISPLAY 'DATA DO SISTEMA EM: ' SIST-DTMOVABE ' SISTEMA CO: ' SIST-DTMOVABE-CO. */

            $"DATA DO SISTEMA EM: {SIST_DTMOVABE} SISTEMA CO: {SIST_DTMOVABE_CO}"
            .Display();

        }

        [StopWatch]
        /*" A1000-LE-SISTEMA-DB-SELECT-1 */
        public void A1000_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -1649- EXEC SQL SELECT DTMOVABE ,CURRENT DATE INTO :SIST-DTMOVABE ,:WHOST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' WITH UR END-EXEC */

            var a1000_LE_SISTEMA_DB_SELECT_1_Query1 = new A1000_LE_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = A1000_LE_SISTEMA_DB_SELECT_1_Query1.Execute(a1000_LE_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE, SIST_DTMOVABE);
                _.Move(executed_1.WHOST_DTCURRENT, WHOST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1999_999_EXIT*/

        [StopWatch]
        /*" A1000-LE-SISTEMA-DB-SELECT-2 */
        public void A1000_LE_SISTEMA_DB_SELECT_2()
        {
            /*" -1662- EXEC SQL SELECT DTMOVABE INTO :SIST-DTMOVABE-CO FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CO' WITH UR END-EXEC */

            var a1000_LE_SISTEMA_DB_SELECT_2_Query1 = new A1000_LE_SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = A1000_LE_SISTEMA_DB_SELECT_2_Query1.Execute(a1000_LE_SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIST_DTMOVABE_CO, SIST_DTMOVABE_CO);
            }


        }

        [StopWatch]
        /*" A1100-OBTEM-VENCIMENTO-MINIMO-SECTION */
        private void A1100_OBTEM_VENCIMENTO_MINIMO_SECTION()
        {
            /*" -1686- MOVE SIST-DTMOVABE-CO TO W-DATA-EDITADA */
            _.Move(SIST_DTMOVABE_CO, W_DATA_EDITADA);

            /*" -1687- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -1688- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -1689- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -1690- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -1691- MOVE 1 TO PROSOM-QTDIA */
            _.Move(1, PROSOMW099.PROSOM_QTDIA);

            /*" -1693- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -1695- CALL 'PROSOCU1' USING PROSOMW099 */
            _.Call("PROSOCU1", PROSOMW099);

            /*" -1696- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -1697- MOVE W-DD TO W-DIA */
            _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

            /*" -1698- MOVE W-MM TO W-MES */
            _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

            /*" -1699- MOVE W-AA TO W-ANO */
            _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

            /*" -1703- MOVE W-DATA-EDITADA TO W-DATA-MIN-1 */
            _.Move(W_DATA_EDITADA, W_DATA_MIN_1);

            /*" -1704- MOVE SIST-DTMOVABE-CO TO W-DATA-EDITADA */
            _.Move(SIST_DTMOVABE_CO, W_DATA_EDITADA);

            /*" -1705- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -1706- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -1707- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -1708- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -1709- MOVE 2 TO PROSOM-QTDIA */
            _.Move(2, PROSOMW099.PROSOM_QTDIA);

            /*" -1711- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -1713- CALL 'PROSOCU1' USING PROSOMW099 */
            _.Call("PROSOCU1", PROSOMW099);

            /*" -1714- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -1715- MOVE W-DD TO W-DIA */
            _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

            /*" -1716- MOVE W-MM TO W-MES */
            _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

            /*" -1717- MOVE W-AA TO W-ANO */
            _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

            /*" -1721- MOVE W-DATA-EDITADA TO W-DATA-MIN-2 */
            _.Move(W_DATA_EDITADA, W_DATA_MIN_2);

            /*" -1722- MOVE SIST-DTMOVABE-CO TO W-DATA-EDITADA */
            _.Move(SIST_DTMOVABE_CO, W_DATA_EDITADA);

            /*" -1723- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -1724- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -1725- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -1726- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -1727- MOVE 15 TO PROSOM-QTDIA */
            _.Move(15, PROSOMW099.PROSOM_QTDIA);

            /*" -1729- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -1731- CALL 'PROSOMC1' USING PROSOMW099 */
            _.Call("PROSOMC1", PROSOMW099);

            /*" -1732- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -1733- MOVE W-DD TO W-DIA */
            _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

            /*" -1734- MOVE W-MM TO W-MES */
            _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

            /*" -1735- MOVE W-AA TO W-ANO */
            _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

            /*" -1737- MOVE W-DATA-EDITADA TO W-DATA-MIN-15. */
            _.Move(W_DATA_EDITADA, W_DATA_MIN_15);

            /*" -1740- DISPLAY 'W-DATA-MIN-1: ' W-DATA-MIN-1 ' W-DATA-MIN-2 ' W-DATA-MIN-2 ' W-DATA-MIN-15 ' W-DATA-MIN-15. */

            $"W-DATA-MIN-1: {W_DATA_MIN_1} W-DATA-MIN-2 {W_DATA_MIN_2} W-DATA-MIN-15 {W_DATA_MIN_15}"
            .Display();

            /*" -1740- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1100_999_EXIT*/

        [StopWatch]
        /*" A1500-LE-V1PARAMRAMO-SECTION */
        private void A1500_LE_V1PARAMRAMO_SECTION()
        {
            /*" -1751- MOVE 'A1500' TO WNR-EXEC-SQL. */
            _.Move("A1500", WABEND.WNR_EXEC_SQL);

            /*" -1760- PERFORM A1500_LE_V1PARAMRAMO_DB_SELECT_1 */

            A1500_LE_V1PARAMRAMO_DB_SELECT_1();

            /*" -1763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1764- DISPLAY 'EM0030B - NAO HA TABELA DE PARAMETROS/RAMO  ' */
                _.Display($"EM0030B - NAO HA TABELA DE PARAMETROS/RAMO  ");

                /*" -1764- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A1500-LE-V1PARAMRAMO-DB-SELECT-1 */
        public void A1500_LE_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -1760- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC, RAMO_SAUDE, RAMO_EDUCACAO INTO :PARM-RAMO-VG, :PARM-RAMO-AP, :PARM-RAMO-VGAPC, :PARM-RAMO-SAUDE, :PARM-RAMO-PRESTA FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

            var a1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1 = new A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = A1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1.Execute(a1500_LE_V1PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARM_RAMO_VG, PARM_RAMO_VG);
                _.Move(executed_1.PARM_RAMO_AP, PARM_RAMO_AP);
                _.Move(executed_1.PARM_RAMO_VGAPC, PARM_RAMO_VGAPC);
                _.Move(executed_1.PARM_RAMO_SAUDE, PARM_RAMO_SAUDE);
                _.Move(executed_1.PARM_RAMO_PRESTA, PARM_RAMO_PRESTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1500_999_EXIT*/

        [StopWatch]
        /*" A1600-LE-V1PARAMETRO-SECTION */
        private void A1600_LE_V1PARAMETRO_SECTION()
        {
            /*" -1775- MOVE 'A1600' TO WNR-EXEC-SQL. */
            _.Move("A1600", WABEND.WNR_EXEC_SQL);

            /*" -1780- PERFORM A1600_LE_V1PARAMETRO_DB_SELECT_1 */

            A1600_LE_V1PARAMETRO_DB_SELECT_1();

            /*" -1783- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1784- DISPLAY 'EM0030B - NAO EXISTE V1PARAMETRO ' */
                _.Display($"EM0030B - NAO EXISTE V1PARAMETRO ");

                /*" -1784- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A1600-LE-V1PARAMETRO-DB-SELECT-1 */
        public void A1600_LE_V1PARAMETRO_DB_SELECT_1()
        {
            /*" -1780- EXEC SQL SELECT CODLIDER INTO :PARM-CODLIDER FROM SEGUROS.V1PARAMETRO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var a1600_LE_V1PARAMETRO_DB_SELECT_1_Query1 = new A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = A1600_LE_V1PARAMETRO_DB_SELECT_1_Query1.Execute(a1600_LE_V1PARAMETRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARM_CODLIDER, PARM_CODLIDER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1600_999_EXIT*/

        [StopWatch]
        /*" R2000-DECLARE-V0ENDOSSO-SECTION */
        private void R2000_DECLARE_V0ENDOSSO_SECTION()
        {
            /*" -1795- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -1842- PERFORM R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1 */

            R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1();

            /*" -1844- PERFORM R2000_DECLARE_V0ENDOSSO_DB_OPEN_1 */

            R2000_DECLARE_V0ENDOSSO_DB_OPEN_1();

            /*" -1847- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1848- DISPLAY 'R2000 - ERRO NO OPEN DA ENDOSSOS' */
                _.Display($"R2000 - ERRO NO OPEN DA ENDOSSOS");

                /*" -1848- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-DECLARE-V0ENDOSSO-DB-DECLARE-1 */
        public void R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1()
        {
            /*" -1842- EXEC SQL DECLARE V0ENDOS CURSOR FOR SELECT NUM_APOLICE ,NRENDOS ,CODSUBES ,FONTE ,NRPROPOS ,ORGAO ,RAMO ,DATPRO ,DATA_LIBERACAO ,DTEMIS ,DTINIVIG ,DTTERVIG ,PCENTRAD ,PCADICIO ,PCDESCON ,PRESTA1 ,QTPARCEL ,COD_MOEDA_PRM ,NRRCAP ,VLRCAP ,DATARCAP ,TIPO_ENDOSSO ,BCORCAP ,AGERCAP ,BCOCOBR ,AGECOBR ,ISENTA_CUSTO ,TIPAPO ,QTITENS ,CORRECAO ,DTVENCTO ,NUMBIL ,CODPRODU ,PODPUBL ,TIPSEGU ,VLCUSEMI ,COD_USUARIO ,CFPREFIX ,COD_EMPRESA FROM SEGUROS.V1ENDOSSO WHERE SITUACAO = ' ' AND NUM_APOLICE IN ( 0106100000011 , 0106800000024 ) AND TIPO_ENDOSSO = 1 ORDER BY NUM_APOLICE, NRENDOS WITH UR END-EXEC. */
            V0ENDOS = new EM0030B_V0ENDOS(false);
            string GetQuery_V0ENDOS()
            {
                var query = @$"SELECT NUM_APOLICE 
							,NRENDOS 
							,CODSUBES 
							,FONTE 
							,NRPROPOS 
							,ORGAO 
							,RAMO 
							,DATPRO 
							,DATA_LIBERACAO 
							,DTEMIS 
							,DTINIVIG 
							,DTTERVIG 
							,PCENTRAD 
							,PCADICIO 
							,PCDESCON 
							,PRESTA1 
							,QTPARCEL 
							,COD_MOEDA_PRM 
							,NRRCAP 
							,VLRCAP 
							,DATARCAP 
							,TIPO_ENDOSSO 
							,BCORCAP 
							,AGERCAP 
							,BCOCOBR 
							,AGECOBR 
							,ISENTA_CUSTO 
							,TIPAPO 
							,QTITENS 
							,CORRECAO 
							,DTVENCTO 
							,NUMBIL 
							,CODPRODU 
							,PODPUBL 
							,TIPSEGU 
							,VLCUSEMI 
							,COD_USUARIO 
							,CFPREFIX 
							,COD_EMPRESA 
							FROM SEGUROS.V1ENDOSSO 
							WHERE SITUACAO = ' ' 
							AND NUM_APOLICE IN ( 0106100000011
							, 0106800000024 ) 
							AND TIPO_ENDOSSO = 1 
							ORDER BY NUM_APOLICE
							, NRENDOS";

                return query;
            }
            V0ENDOS.GetQueryEvent += GetQuery_V0ENDOS;

        }

        [StopWatch]
        /*" R2000-DECLARE-V0ENDOSSO-DB-OPEN-1 */
        public void R2000_DECLARE_V0ENDOSSO_DB_OPEN_1()
        {
            /*" -1844- EXEC SQL OPEN V0ENDOS END-EXEC. */

            V0ENDOS.Open();

        }

        [StopWatch]
        /*" A4500-LE-COBERAPOL-DB-DECLARE-1 */
        public void A4500_LE_COBERAPOL_DB_DECLARE_1()
        {
            /*" -2172- EXEC SQL DECLARE V1COBERAPOL CURSOR FOR SELECT PRM_TARIFARIO_VAR ,PRM_TARIFARIO_IX FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND NUM_ITEM = 0 AND COD_COBERTURA = 0 WITH UR END-EXEC. */
            V1COBERAPOL = new EM0030B_V1COBERAPOL(true);
            string GetQuery_V1COBERAPOL()
            {
                var query = @$"SELECT PRM_TARIFARIO_VAR 
							,PRM_TARIFARIO_IX 
							FROM SEGUROS.V1COBERAPOL 
							WHERE NUM_APOLICE = '{ENDO_NUM_APOLICE}' 
							AND NRENDOS = '{ENDO_NRENDOS}' 
							AND NUM_ITEM = 0 
							AND COD_COBERTURA = 0";

                return query;
            }
            V1COBERAPOL.GetQueryEvent += GetQuery_V1COBERAPOL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A2999_999_EXIT*/

        [StopWatch]
        /*" A3000-LE-V0ENDOSSO-SECTION */
        private void A3000_LE_V0ENDOSSO_SECTION()
        {
            /*" -1857- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM A3000_LE */

            A3000_LE();

        }

        [StopWatch]
        /*" A3000-LE */
        private void A3000_LE(bool isPerform = false)
        {
            /*" -1861- MOVE 'A3000' TO WNR-EXEC-SQL. */
            _.Move("A3000", WABEND.WNR_EXEC_SQL);

            /*" -1902- PERFORM A3000_LE_DB_FETCH_1 */

            A3000_LE_DB_FETCH_1();

            /*" -1905- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1905- PERFORM A3000_LE_DB_CLOSE_1 */

                A3000_LE_DB_CLOSE_1();

                /*" -1907- MOVE '1' TO CH-ENDOSSO */
                _.Move("1", CH_ENDOSSO);

                /*" -1909- GO TO A3999-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_999_EXIT*/ //GOTO
                return;
            }


            /*" -1910- IF VIND-VLCUSEMI LESS ZEROS */

            if (VIND_VLCUSEMI < 00)
            {

                /*" -1912- MOVE ZEROS TO ENDO-VLCUSEMI */
                _.Move(0, ENDO_VLCUSEMI);

                /*" -1914- IF ENDO-TIPSEGU NOT = '1' */

                if (ENDO_TIPSEGU != "1")
                {

                    /*" -1916- GO TO A3000-LE. */
                    new Task(() => A3000_LE()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1918- IF ENDO-ISECUSTO-I LESS ZEROS */

            if (ENDO_ISECUSTO_I < 00)
            {

                /*" -1920- MOVE SPACES TO ENDO-ISENTA-CUSTO. */
                _.Move("", ENDO_ISENTA_CUSTO);
            }


            /*" -1921- IF ENDO-DATARCAP-I LESS 0 */

            if (ENDO_DATARCAP_I < 0)
            {

                /*" -1923- MOVE -1 TO ENDO-DATARCAP-I */
                _.Move(-1, ENDO_DATARCAP_I);

                /*" -1925- MOVE SPACES TO ENDO-DATARCAP. */
                _.Move("", ENDO_DATARCAP);
            }


            /*" -1926- IF VIND-DTVENCTO LESS 0 */

            if (VIND_DTVENCTO < 0)
            {

                /*" -1928- MOVE -1 TO VIND-DTVENCTO */
                _.Move(-1, VIND_DTVENCTO);

                /*" -1930- MOVE SPACES TO ENDO-DTVENCTO. */
                _.Move("", ENDO_DTVENCTO);
            }


            /*" -1931- IF VIND-CODPRODU LESS 0 */

            if (VIND_CODPRODU < 0)
            {

                /*" -1932- MOVE -1 TO VIND-CODPRODU */
                _.Move(-1, VIND_CODPRODU);

                /*" -1934- MOVE ZEROS TO ENDO-CODPRODU. */
                _.Move(0, ENDO_CODPRODU);
            }


            /*" -1935- IF VIND-CFPREFIX LESS 0 */

            if (VIND_CFPREFIX < 0)
            {

                /*" -1936- MOVE -1 TO VIND-CFPREFIX */
                _.Move(-1, VIND_CFPREFIX);

                /*" -1938- MOVE ZEROS TO ENDO-CFPREFIX. */
                _.Move(0, ENDO_CFPREFIX);
            }


            /*" -1939- IF VIND-COD-EMPRESA LESS 0 */

            if (VIND_COD_EMPRESA < 0)
            {

                /*" -1940- MOVE -1 TO VIND-COD-EMPRESA */
                _.Move(-1, VIND_COD_EMPRESA);

                /*" -1942- MOVE ZEROS TO ENDO-COD-EMPRESA. */
                _.Move(0, ENDO_COD_EMPRESA);
            }


            /*" -1943- ADD 1 TO AC-COUNT. */
            AC_COUNT.Value = AC_COUNT + 1;

            /*" -1963- ADD 1 TO AC-L-V1ENDOSSO. */
            AC_L_V1ENDOSSO.Value = AC_L_V1ENDOSSO + 1;

            /*" -1963- PERFORM B1100-LE-V2RAMO. */

            B1100_LE_V2RAMO_SECTION();

        }

        [StopWatch]
        /*" A3000-LE-DB-FETCH-1 */
        public void A3000_LE_DB_FETCH_1()
        {
            /*" -1902- EXEC SQL FETCH V0ENDOS INTO :ENDO-NUM-APOLICE ,:ENDO-NRENDOS ,:ENDO-CODSUBES ,:ENDO-FONTE ,:ENDO-NRPROPOS ,:ENDO-ORGAO ,:ENDO-RAMO ,:ENDO-DATPRO ,:ENDO-DT-LIBERACAO ,:ENDO-DTEMIS ,:ENDO-DTINIVIG ,:ENDO-DTTERVIG ,:ENDO-PCENTRAD ,:ENDO-PCADICIO ,:ENDO-PCDESCON ,:ENDO-PRESTA1 ,:ENDO-QTPARCEL ,:ENDO-COD-MOEDA-PRM ,:ENDO-NRRCAP ,:ENDO-VLRCAP ,:ENDO-DATARCAP:ENDO-DATARCAP-I ,:ENDO-TIPO-ENDOSSO ,:ENDO-BCORCAP ,:ENDO-AGERCAP ,:ENDO-BCOCOBR ,:ENDO-AGECOBR ,:ENDO-ISENTA-CUSTO:ENDO-ISECUSTO-I ,:ENDO-TIPO-APOL ,:ENDO-QTITENS ,:ENDO-CORRECAO ,:ENDO-DTVENCTO:VIND-DTVENCTO ,:ENDO-NUMBIL ,:ENDO-CODPRODU:VIND-CODPRODU ,:ENDO-PODPUBL ,:ENDO-TIPSEGU ,:ENDO-VLCUSEMI:VIND-VLCUSEMI ,:ENDO-COD-USUARIO ,:ENDO-CFPREFIX :VIND-CFPREFIX ,:ENDO-COD-EMPRESA :VIND-COD-EMPRESA END-EXEC. */

            if (V0ENDOS.Fetch())
            {
                _.Move(V0ENDOS.ENDO_NUM_APOLICE, ENDO_NUM_APOLICE);
                _.Move(V0ENDOS.ENDO_NRENDOS, ENDO_NRENDOS);
                _.Move(V0ENDOS.ENDO_CODSUBES, ENDO_CODSUBES);
                _.Move(V0ENDOS.ENDO_FONTE, ENDO_FONTE);
                _.Move(V0ENDOS.ENDO_NRPROPOS, ENDO_NRPROPOS);
                _.Move(V0ENDOS.ENDO_ORGAO, ENDO_ORGAO);
                _.Move(V0ENDOS.ENDO_RAMO, ENDO_RAMO);
                _.Move(V0ENDOS.ENDO_DATPRO, ENDO_DATPRO);
                _.Move(V0ENDOS.ENDO_DT_LIBERACAO, ENDO_DT_LIBERACAO);
                _.Move(V0ENDOS.ENDO_DTEMIS, ENDO_DTEMIS);
                _.Move(V0ENDOS.ENDO_DTINIVIG, ENDO_DTINIVIG);
                _.Move(V0ENDOS.ENDO_DTTERVIG, ENDO_DTTERVIG);
                _.Move(V0ENDOS.ENDO_PCENTRAD, ENDO_PCENTRAD);
                _.Move(V0ENDOS.ENDO_PCADICIO, ENDO_PCADICIO);
                _.Move(V0ENDOS.ENDO_PCDESCON, ENDO_PCDESCON);
                _.Move(V0ENDOS.ENDO_PRESTA1, ENDO_PRESTA1);
                _.Move(V0ENDOS.ENDO_QTPARCEL, ENDO_QTPARCEL);
                _.Move(V0ENDOS.ENDO_COD_MOEDA_PRM, ENDO_COD_MOEDA_PRM);
                _.Move(V0ENDOS.ENDO_NRRCAP, ENDO_NRRCAP);
                _.Move(V0ENDOS.ENDO_VLRCAP, ENDO_VLRCAP);
                _.Move(V0ENDOS.ENDO_DATARCAP, ENDO_DATARCAP);
                _.Move(V0ENDOS.ENDO_DATARCAP_I, ENDO_DATARCAP_I);
                _.Move(V0ENDOS.ENDO_TIPO_ENDOSSO, ENDO_TIPO_ENDOSSO);
                _.Move(V0ENDOS.ENDO_BCORCAP, ENDO_BCORCAP);
                _.Move(V0ENDOS.ENDO_AGERCAP, ENDO_AGERCAP);
                _.Move(V0ENDOS.ENDO_BCOCOBR, ENDO_BCOCOBR);
                _.Move(V0ENDOS.ENDO_AGECOBR, ENDO_AGECOBR);
                _.Move(V0ENDOS.ENDO_ISENTA_CUSTO, ENDO_ISENTA_CUSTO);
                _.Move(V0ENDOS.ENDO_ISECUSTO_I, ENDO_ISECUSTO_I);
                _.Move(V0ENDOS.ENDO_TIPO_APOL, ENDO_TIPO_APOL);
                _.Move(V0ENDOS.ENDO_QTITENS, ENDO_QTITENS);
                _.Move(V0ENDOS.ENDO_CORRECAO, ENDO_CORRECAO);
                _.Move(V0ENDOS.ENDO_DTVENCTO, ENDO_DTVENCTO);
                _.Move(V0ENDOS.VIND_DTVENCTO, VIND_DTVENCTO);
                _.Move(V0ENDOS.ENDO_NUMBIL, ENDO_NUMBIL);
                _.Move(V0ENDOS.ENDO_CODPRODU, ENDO_CODPRODU);
                _.Move(V0ENDOS.VIND_CODPRODU, VIND_CODPRODU);
                _.Move(V0ENDOS.ENDO_PODPUBL, ENDO_PODPUBL);
                _.Move(V0ENDOS.ENDO_TIPSEGU, ENDO_TIPSEGU);
                _.Move(V0ENDOS.ENDO_VLCUSEMI, ENDO_VLCUSEMI);
                _.Move(V0ENDOS.VIND_VLCUSEMI, VIND_VLCUSEMI);
                _.Move(V0ENDOS.ENDO_COD_USUARIO, ENDO_COD_USUARIO);
                _.Move(V0ENDOS.ENDO_CFPREFIX, ENDO_CFPREFIX);
                _.Move(V0ENDOS.VIND_CFPREFIX, VIND_CFPREFIX);
                _.Move(V0ENDOS.ENDO_COD_EMPRESA, ENDO_COD_EMPRESA);
                _.Move(V0ENDOS.VIND_COD_EMPRESA, VIND_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" A3000-LE-DB-CLOSE-1 */
        public void A3000_LE_DB_CLOSE_1()
        {
            /*" -1905- EXEC SQL CLOSE V0ENDOS END-EXEC */

            V0ENDOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_999_EXIT*/

        [StopWatch]
        /*" A3500-LE-SUBGRUPO-SECTION */
        private void A3500_LE_SUBGRUPO_SECTION()
        {
            /*" -1974- MOVE 'A3500' TO WNR-EXEC-SQL. */
            _.Move("A3500", WABEND.WNR_EXEC_SQL);

            /*" -1980- PERFORM A3500_LE_SUBGRUPO_DB_SELECT_1 */

            A3500_LE_SUBGRUPO_DB_SELECT_1();

            /*" -1983- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1983- MOVE '2' TO SUB-OPC-CORRETAGEM. */
                _.Move("2", SUB_OPC_CORRETAGEM);
            }


        }

        [StopWatch]
        /*" A3500-LE-SUBGRUPO-DB-SELECT-1 */
        public void A3500_LE_SUBGRUPO_DB_SELECT_1()
        {
            /*" -1980- EXEC SQL SELECT OPCAO_CORRETAGEM INTO :SUB-OPC-CORRETAGEM FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND COD_SUBGRUPO = :ENDO-CODSUBES WITH UR END-EXEC. */

            var a3500_LE_SUBGRUPO_DB_SELECT_1_Query1 = new A3500_LE_SUBGRUPO_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_CODSUBES = ENDO_CODSUBES.ToString(),
            };

            var executed_1 = A3500_LE_SUBGRUPO_DB_SELECT_1_Query1.Execute(a3500_LE_SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUB_OPC_CORRETAGEM, SUB_OPC_CORRETAGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3500_999_EXIT*/

        [StopWatch]
        /*" A3510-LE-RAMOIND-SECTION */
        private void A3510_LE_RAMOIND_SECTION()
        {
            /*" -1994- MOVE 'A3510' TO WNR-EXEC-SQL. */
            _.Move("A3510", WABEND.WNR_EXEC_SQL);

            /*" -2003- PERFORM A3510_LE_RAMOIND_DB_SELECT_1 */

            A3510_LE_RAMOIND_DB_SELECT_1();

            /*" -2006- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2007- MOVE ZEROS TO RAMOIND-PCIOF. */
                _.Move(0, RAMOIND_PCIOF);
            }


        }

        [StopWatch]
        /*" A3510-LE-RAMOIND-DB-SELECT-1 */
        public void A3510_LE_RAMOIND_DB_SELECT_1()
        {
            /*" -2003- EXEC SQL SELECT PCIOF / 100 + 1 , PCIOF / 100 INTO :RAMOIND-PCIOF , :RAMO-PERC-IOF FROM SEGUROS.V0RAMOIND WHERE RAMO = :ENDO-RAMO AND DTINIVIG <= :SIST-DTMOVABE AND DTTERVIG >= :SIST-DTMOVABE WITH UR END-EXEC. */

            var a3510_LE_RAMOIND_DB_SELECT_1_Query1 = new A3510_LE_RAMOIND_DB_SELECT_1_Query1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
                ENDO_RAMO = ENDO_RAMO.ToString(),
            };

            var executed_1 = A3510_LE_RAMOIND_DB_SELECT_1_Query1.Execute(a3510_LE_RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOIND_PCIOF, RAMOIND_PCIOF);
                _.Move(executed_1.RAMO_PERC_IOF, RAMO_PERC_IOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3510_999_EXIT*/

        [StopWatch]
        /*" A4000-LE-APOLICE-SECTION */
        private void A4000_LE_APOLICE_SECTION()
        {
            /*" -2073- MOVE 'A4000' TO WNR-EXEC-SQL. */
            _.Move("A4000", WABEND.WNR_EXEC_SQL);

            /*" -2098- PERFORM A4000_LE_APOLICE_DB_SELECT_1 */

            A4000_LE_APOLICE_DB_SELECT_1();

            /*" -2101- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2103- DISPLAY 'A4000- NAO EXISTE NA V1APOLICE' ' ' ENDO-NUM-APOLICE */

                $"A4000- NAO EXISTE NA V1APOLICE {ENDO_NUM_APOLICE}"
                .Display();

                /*" -2103- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A4000-LE-APOLICE-DB-SELECT-1 */
        public void A4000_LE_APOLICE_DB_SELECT_1()
        {
            /*" -2098- EXEC SQL SELECT CODCLIEN, NUM_APOLICE, MODALIDA, ORGAO, RAMO, TIPSGU, TIPAPO, TIPCALC, IDEMAN, PCDESCON, PCIOCC, TPCOSCED, QTCOSSEG, PCTCED, TPPESSOA INTO :APOL-COD-CLIENTE ,:APOL-NUM-APOLICE ,:APOL-MODALIDA ,:APOL-ORGAO ,:APOL-RAMO ,:APOL-TIPO-SEGURO ,:APOL-TIPO-APOLICE ,:APOL-TIPO-CALCULO ,:APOL-IND-ENDOS-MAN ,:APOL-PCDESCON ,:APOL-PCIOCC ,:APOL-TPCOSSEG ,:APOL-QTCOSSEG ,:APOL-PCCOSSEG ,:APOL-TIPO-PESSOA FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :ENDO-NUM-APOLICE WITH UR END-EXEC. */

            var a4000_LE_APOLICE_DB_SELECT_1_Query1 = new A4000_LE_APOLICE_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
            };

            var executed_1 = A4000_LE_APOLICE_DB_SELECT_1_Query1.Execute(a4000_LE_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_COD_CLIENTE, APOL_COD_CLIENTE);
                _.Move(executed_1.APOL_NUM_APOLICE, APOL_NUM_APOLICE);
                _.Move(executed_1.APOL_MODALIDA, APOL_MODALIDA);
                _.Move(executed_1.APOL_ORGAO, APOL_ORGAO);
                _.Move(executed_1.APOL_RAMO, APOL_RAMO);
                _.Move(executed_1.APOL_TIPO_SEGURO, APOL_TIPO_SEGURO);
                _.Move(executed_1.APOL_TIPO_APOLICE, APOL_TIPO_APOLICE);
                _.Move(executed_1.APOL_TIPO_CALCULO, APOL_TIPO_CALCULO);
                _.Move(executed_1.APOL_IND_ENDOS_MAN, APOL_IND_ENDOS_MAN);
                _.Move(executed_1.APOL_PCDESCON, APOL_PCDESCON);
                _.Move(executed_1.APOL_PCIOCC, APOL_PCIOCC);
                _.Move(executed_1.APOL_TPCOSSEG, APOL_TPCOSSEG);
                _.Move(executed_1.APOL_QTCOSSEG, APOL_QTCOSSEG);
                _.Move(executed_1.APOL_PCCOSSEG, APOL_PCCOSSEG);
                _.Move(executed_1.APOL_TIPO_PESSOA, APOL_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4000_999_EXIT*/

        [StopWatch]
        /*" A4100-LE-PROPCOB-SECTION */
        private void A4100_LE_PROPCOB_SECTION()
        {
            /*" -2114- MOVE 'A4100' TO WNR-EXEC-SQL. */
            _.Move("A4100", WABEND.WNR_EXEC_SQL);

            /*" -2123- PERFORM A4100_LE_PROPCOB_DB_SELECT_1 */

            A4100_LE_PROPCOB_DB_SELECT_1();

            /*" -2126- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2127- MOVE ' ' TO PRCB-TIPO-COBRANCA */
                _.Move(" ", PRCB_TIPO_COBRANCA);

                /*" -2129- MOVE ZEROS TO PRCB-DIA-DEBITO. */
                _.Move(0, PRCB_DIA_DEBITO);
            }


            /*" -2130- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -2131- MOVE PRCB-DIA-DEBITO TO W-DIA-DEBITO. */
                _.Move(PRCB_DIA_DEBITO, VENCIMENTOS.W_DIA_DEBITO);
            }


        }

        [StopWatch]
        /*" A4100-LE-PROPCOB-DB-SELECT-1 */
        public void A4100_LE_PROPCOB_DB_SELECT_1()
        {
            /*" -2123- EXEC SQL SELECT TIPO_COBRANCA ,DIA_DEBITO INTO :PRCB-TIPO-COBRANCA ,:PRCB-DIA-DEBITO FROM SEGUROS.V0PROPCOB WHERE FONTE = :ENDO-FONTE AND NRPROPOS = :ENDO-NRPROPOS WITH UR END-EXEC. */

            var a4100_LE_PROPCOB_DB_SELECT_1_Query1 = new A4100_LE_PROPCOB_DB_SELECT_1_Query1()
            {
                ENDO_NRPROPOS = ENDO_NRPROPOS.ToString(),
                ENDO_FONTE = ENDO_FONTE.ToString(),
            };

            var executed_1 = A4100_LE_PROPCOB_DB_SELECT_1_Query1.Execute(a4100_LE_PROPCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRCB_TIPO_COBRANCA, PRCB_TIPO_COBRANCA);
                _.Move(executed_1.PRCB_DIA_DEBITO, PRCB_DIA_DEBITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4100_999_EXIT*/

        [StopWatch]
        /*" A4200-LE-AU085-SECTION */
        private void A4200_LE_AU085_SECTION()
        {
            /*" -2141- MOVE 'A4200' TO WNR-EXEC-SQL. */
            _.Move("A4200", WABEND.WNR_EXEC_SQL);

            /*" -2148- PERFORM A4200_LE_AU085_DB_SELECT_1 */

            A4200_LE_AU085_DB_SELECT_1();

            /*" -2151- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2152- DISPLAY 'A4200- ERRO NO SELECT AU085' */
                _.Display($"A4200- ERRO NO SELECT AU085");

                /*" -2152- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A4200-LE-AU085-DB-SELECT-1 */
        public void A4200_LE_AU085_DB_SELECT_1()
        {
            /*" -2148- EXEC SQL SELECT VALUE(IND_FORMA_PAGTO_AD, '0' ) INTO :AU085-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_PROPOSTA_COMPL WHERE COD_FONTE = :ENDO-FONTE AND NUM_PROPOSTA = :ENDO-NRPROPOS WITH UR END-EXEC. */

            var a4200_LE_AU085_DB_SELECT_1_Query1 = new A4200_LE_AU085_DB_SELECT_1_Query1()
            {
                ENDO_NRPROPOS = ENDO_NRPROPOS.ToString(),
                ENDO_FONTE = ENDO_FONTE.ToString(),
            };

            var executed_1 = A4200_LE_AU085_DB_SELECT_1_Query1.Execute(a4200_LE_AU085_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU085_IND_FORMA_PAGTO_AD, AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4200_999_EXIT*/

        [StopWatch]
        /*" A4500-LE-COBERAPOL-SECTION */
        private void A4500_LE_COBERAPOL_SECTION()
        {
            /*" -2163- MOVE 'A4500' TO WNR-EXEC-SQL. */
            _.Move("A4500", WABEND.WNR_EXEC_SQL);

            /*" -2172- PERFORM A4500_LE_COBERAPOL_DB_DECLARE_1 */

            A4500_LE_COBERAPOL_DB_DECLARE_1();

            /*" -2174- PERFORM A4500_LE_COBERAPOL_DB_OPEN_1 */

            A4500_LE_COBERAPOL_DB_OPEN_1();

            /*" -2176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2177- DISPLAY ' A4500- ERRO NO OPEN DA COBERAPOL' */
                _.Display($" A4500- ERRO NO OPEN DA COBERAPOL");

                /*" -2179- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2180- MOVE ZEROS TO COBE-TARIFARIO-VAR. */
            _.Move(0, COBE_TARIFARIO_VAR);

            /*" -2180- MOVE ZEROS TO COBE-TARIFARIO-IX. */
            _.Move(0, COBE_TARIFARIO_IX);

            /*" -0- FLUXCONTROL_PERFORM A4501_LE_V1COBERAPOL */

            A4501_LE_V1COBERAPOL();

        }

        [StopWatch]
        /*" A4500-LE-COBERAPOL-DB-OPEN-1 */
        public void A4500_LE_COBERAPOL_DB_OPEN_1()
        {
            /*" -2174- EXEC SQL OPEN V1COBERAPOL END-EXEC. */

            V1COBERAPOL.Open();

        }

        [StopWatch]
        /*" B0100-DECLARE-V0APOLCOSCED-DB-DECLARE-1 */
        public void B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1()
        {
            /*" -2665- EXEC SQL DECLARE V0APOLCOS CURSOR FOR SELECT CODCOSS FROM SEGUROS.V0APOLCOSCED WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG WITH UR END-EXEC. */
            V0APOLCOS = new EM0030B_V0APOLCOS(true);
            string GetQuery_V0APOLCOS()
            {
                var query = @$"SELECT CODCOSS 
							FROM SEGUROS.V0APOLCOSCED 
							WHERE NUM_APOLICE = '{ENDO_NUM_APOLICE}' 
							AND DTINIVIG <= '{ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{ENDO_DTINIVIG}'";

                return query;
            }
            V0APOLCOS.GetQueryEvent += GetQuery_V0APOLCOS;

        }

        [StopWatch]
        /*" A4501-LE-V1COBERAPOL */
        private void A4501_LE_V1COBERAPOL(bool isPerform = false)
        {
            /*" -2186- MOVE 'A4501' TO WNR-EXEC-SQL. */
            _.Move("A4501", WABEND.WNR_EXEC_SQL);

            /*" -2189- PERFORM A4501_LE_V1COBERAPOL_DB_FETCH_1 */

            A4501_LE_V1COBERAPOL_DB_FETCH_1();

            /*" -2192- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2192- PERFORM A4501_LE_V1COBERAPOL_DB_CLOSE_1 */

                A4501_LE_V1COBERAPOL_DB_CLOSE_1();

                /*" -2195- GO TO A4500-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: A4500_999_EXIT*/ //GOTO
                return;
            }


            /*" -2196- ADD COBT-TARIFARIO-VAR TO COBE-TARIFARIO-VAR. */
            COBE_TARIFARIO_VAR.Value = COBE_TARIFARIO_VAR + COBT_TARIFARIO_VAR;

            /*" -2198- ADD COBT-TARIFARIO-IX TO COBE-TARIFARIO-IX. */
            COBE_TARIFARIO_IX.Value = COBE_TARIFARIO_IX + COBT_TARIFARIO_IX;

            /*" -2198- GO TO A4501-LE-V1COBERAPOL. */
            new Task(() => A4501_LE_V1COBERAPOL()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" A4501-LE-V1COBERAPOL-DB-FETCH-1 */
        public void A4501_LE_V1COBERAPOL_DB_FETCH_1()
        {
            /*" -2189- EXEC SQL FETCH V1COBERAPOL INTO :COBT-TARIFARIO-VAR, :COBT-TARIFARIO-IX END-EXEC. */

            if (V1COBERAPOL.Fetch())
            {
                _.Move(V1COBERAPOL.COBT_TARIFARIO_VAR, COBT_TARIFARIO_VAR);
                _.Move(V1COBERAPOL.COBT_TARIFARIO_IX, COBT_TARIFARIO_IX);
            }

        }

        [StopWatch]
        /*" A4501-LE-V1COBERAPOL-DB-CLOSE-1 */
        public void A4501_LE_V1COBERAPOL_DB_CLOSE_1()
        {
            /*" -2192- EXEC SQL CLOSE V1COBERAPOL END-EXEC */

            V1COBERAPOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4500_999_EXIT*/

        [StopWatch]
        /*" A4600-LE-MR-APOL-COBER-SECTION */
        private void A4600_LE_MR_APOL_COBER_SECTION()
        {
            /*" -2233- MOVE 'A4600' TO WNR-EXEC-SQL. */
            _.Move("A4600", WABEND.WNR_EXEC_SQL);

            /*" -2244- PERFORM A4600_LE_MR_APOL_COBER_DB_SELECT_1 */

            A4600_LE_MR_APOL_COBER_DB_SELECT_1();

            /*" -2247- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2250- DISPLAY 'A4600- ERRO LE MR-APOL-ITEM' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $"A4600- ERRO LE MR-APOL-ITEM {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -2252- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2253- IF PCT-DESCONTO-TOTAL NOT EQUAL 0 */

            if (PCT_DESCONTO_TOTAL != 0)
            {

                /*" -2255- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR ENDO-TIPO-ENDOSSO EQUAL '1' */

                if (ENDO_TIPO_ENDOSSO == "0" || ENDO_TIPO_ENDOSSO == "1")
                {

                    /*" -2259- COMPUTE COBE-TARIFARIO-VAR = COBE-TARIFARIO-VAR * (1 - (PCT-DESCONTO-TOTAL / 100)) */
                    COBE_TARIFARIO_VAR.Value = COBE_TARIFARIO_VAR * (1 - (PCT_DESCONTO_TOTAL / 100f));

                    /*" -2262- COMPUTE COBE-TARIFARIO-IX = COBE-TARIFARIO-IX * (1 - (PCT-DESCONTO-TOTAL / 100)). */
                    COBE_TARIFARIO_IX.Value = COBE_TARIFARIO_IX * (1 - (PCT_DESCONTO_TOTAL / 100f));
                }

            }


        }

        [StopWatch]
        /*" A4600-LE-MR-APOL-COBER-DB-SELECT-1 */
        public void A4600_LE_MR_APOL_COBER_DB_SELECT_1()
        {
            /*" -2244- EXEC SQL SELECT VALUE(SUM(PCT_DESC_FIDEL + PCT_DESC_AGRUP + PCT_DESC_FUNC_PUBL + PCT_DESC_EXPER),0) INTO :PCT-DESCONTO-TOTAL FROM SEGUROS.MR_APOLICE_ITEM WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS AND NUM_ITEM = :ENDO-QTITENS WITH UR END-EXEC. */

            var a4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1 = new A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
                ENDO_QTITENS = ENDO_QTITENS.ToString(),
            };

            var executed_1 = A4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1.Execute(a4600_LE_MR_APOL_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PCT_DESCONTO_TOTAL, PCT_DESCONTO_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4600_999_EXIT*/

        [StopWatch]
        /*" A5000-LE-APOLITEM-SECTION */
        private void A5000_LE_APOLITEM_SECTION()
        {
            /*" -2273- MOVE 'A5000' TO WNR-EXEC-SQL. */
            _.Move("A5000", WABEND.WNR_EXEC_SQL);

            /*" -2282- PERFORM A5000_LE_APOLITEM_DB_SELECT_1 */

            A5000_LE_APOLITEM_DB_SELECT_1();

            /*" -2286- IF VIND-QTITENS LESS ZEROS OR VIND-TARIFARIO LESS ZEROS */

            if (VIND_QTITENS < 00 || VIND_TARIFARIO < 00)
            {

                /*" -2287- MOVE ZEROS TO APIT-QTITENS */
                _.Move(0, APIT_QTITENS);

                /*" -2289- MOVE ZEROS TO APIT-TARIFARIO-IX. */
                _.Move(0, APIT_TARIFARIO_IX);
            }


            /*" -2290- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2291- MOVE ZEROS TO APIT-QTITENS */
                _.Move(0, APIT_QTITENS);

                /*" -2291- MOVE ZEROS TO APIT-TARIFARIO-IX. */
                _.Move(0, APIT_TARIFARIO_IX);
            }


        }

        [StopWatch]
        /*" A5000-LE-APOLITEM-DB-SELECT-1 */
        public void A5000_LE_APOLITEM_DB_SELECT_1()
        {
            /*" -2282- EXEC SQL SELECT COUNT(*), SUM(PRM_TARIFARIO_IX) INTO :APIT-QTITENS:VIND-QTITENS, :APIT-TARIFARIO-IX:VIND-TARIFARIO FROM SEGUROS.V1APOLITEM WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND SITUACAO = '0' WITH UR END-EXEC. */

            var a5000_LE_APOLITEM_DB_SELECT_1_Query1 = new A5000_LE_APOLITEM_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = A5000_LE_APOLITEM_DB_SELECT_1_Query1.Execute(a5000_LE_APOLITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APIT_QTITENS, APIT_QTITENS);
                _.Move(executed_1.VIND_QTITENS, VIND_QTITENS);
                _.Move(executed_1.APIT_TARIFARIO_IX, APIT_TARIFARIO_IX);
                _.Move(executed_1.VIND_TARIFARIO, VIND_TARIFARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A5000_999_EXIT*/

        [StopWatch]
        /*" A6200-000-LE-RCAP-SECTION */
        private void A6200_000_LE_RCAP_SECTION()
        {
            /*" -2351- MOVE 'A6200' TO WNR-EXEC-SQL. */
            _.Move("A6200", WABEND.WNR_EXEC_SQL);

            /*" -2357- PERFORM A6200_000_LE_RCAP_DB_SELECT_1 */

            A6200_000_LE_RCAP_DB_SELECT_1();

            /*" -2360- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2361- GO TO A6200-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/ //GOTO
                return;

                /*" -2362- ELSE */
            }
            else
            {


                /*" -2363- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2366- DISPLAY 'A6200 1 - RCAP NAO CADASTRADO ' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                    $"A6200 1 - RCAP NAO CADASTRADO  {ENDO_FONTE} {ENDO_NRRCAP}"
                    .Display();

                    /*" -2367- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2368- ELSE */
                }
                else
                {


                    /*" -2369- IF SQLCODE NOT EQUAL -810 AND -811 */

                    if (!DB.SQLCODE.In("-810", "-811"))
                    {

                        /*" -2372- DISPLAY 'A6200 1 - ERRO NO ACESSO A RCAP' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                        $"A6200 1 - ERRO NO ACESSO A RCAP {ENDO_FONTE} {ENDO_NRRCAP}"
                        .Display();

                        /*" -2373- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2374- ELSE */
                    }
                    else
                    {


                        /*" -2381- PERFORM A6200_000_LE_RCAP_DB_SELECT_2 */

                        A6200_000_LE_RCAP_DB_SELECT_2();

                        /*" -2383- IF SQLCODE EQUAL 0 */

                        if (DB.SQLCODE == 0)
                        {

                            /*" -2384- GO TO A6200-999-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/ //GOTO
                            return;

                            /*" -2385- ELSE */
                        }
                        else
                        {


                            /*" -2386- IF SQLCODE NOT EQUAL 100 */

                            if (DB.SQLCODE != 100)
                            {

                                /*" -2389- DISPLAY 'A6200 2 - ERRO NO ACESSO A RCAP' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                                $"A6200 2 - ERRO NO ACESSO A RCAP {ENDO_FONTE} {ENDO_NRRCAP}"
                                .Display();

                                /*" -2390- GO TO 999-999-ROT-ERRO */

                                M_999_999_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -2391- ELSE */
                            }
                            else
                            {


                                /*" -2398- PERFORM A6200_000_LE_RCAP_DB_SELECT_3 */

                                A6200_000_LE_RCAP_DB_SELECT_3();

                                /*" -2400- IF SQLCODE EQUAL 0 */

                                if (DB.SQLCODE == 0)
                                {

                                    /*" -2401- GO TO A6200-999-EXIT */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/ //GOTO
                                    return;

                                    /*" -2402- ELSE */
                                }
                                else
                                {


                                    /*" -2403- IF SQLCODE EQUAL 100 */

                                    if (DB.SQLCODE == 100)
                                    {

                                        /*" -2406- DISPLAY 'A6200 3 - RCAP NAO CADASTRADO ' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                                        $"A6200 3 - RCAP NAO CADASTRADO  {ENDO_FONTE} {ENDO_NRRCAP}"
                                        .Display();

                                        /*" -2407- GO TO 999-999-ROT-ERRO */

                                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                                        return;

                                        /*" -2408- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2411- DISPLAY 'A6200 3 - ERRO NO ACESSO A RCAP' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                                        $"A6200 3 - ERRO NO ACESSO A RCAP {ENDO_FONTE} {ENDO_NRRCAP}"
                                        .Display();

                                        /*" -2412- GO TO 999-999-ROT-ERRO. */

                                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                                        return;
                                    }

                                }

                            }

                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" A6200-000-LE-RCAP-DB-SELECT-1 */
        public void A6200_000_LE_RCAP_DB_SELECT_1()
        {
            /*" -2357- EXEC SQL SELECT NRTIT INTO :V0RCAP-NRTIT FROM SEGUROS.V0RCAP WHERE NRRCAP = :ENDO-NRRCAP WITH UR END-EXEC. */

            var a6200_000_LE_RCAP_DB_SELECT_1_Query1 = new A6200_000_LE_RCAP_DB_SELECT_1_Query1()
            {
                ENDO_NRRCAP = ENDO_NRRCAP.ToString(),
            };

            var executed_1 = A6200_000_LE_RCAP_DB_SELECT_1_Query1.Execute(a6200_000_LE_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_NRTIT, V0RCAP_NRTIT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/

        [StopWatch]
        /*" A6200-000-LE-RCAP-DB-SELECT-2 */
        public void A6200_000_LE_RCAP_DB_SELECT_2()
        {
            /*" -2381- EXEC SQL SELECT NRTIT INTO :V0RCAP-NRTIT FROM SEGUROS.V0RCAP WHERE FONTE = :ENDO-FONTE AND NRRCAP = :ENDO-NRRCAP WITH UR END-EXEC */

            var a6200_000_LE_RCAP_DB_SELECT_2_Query1 = new A6200_000_LE_RCAP_DB_SELECT_2_Query1()
            {
                ENDO_NRRCAP = ENDO_NRRCAP.ToString(),
                ENDO_FONTE = ENDO_FONTE.ToString(),
            };

            var executed_1 = A6200_000_LE_RCAP_DB_SELECT_2_Query1.Execute(a6200_000_LE_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_NRTIT, V0RCAP_NRTIT);
            }


        }

        [StopWatch]
        /*" B0000-PROCESSA-SECTION */
        private void B0000_PROCESSA_SECTION()
        {
            /*" -2481- MOVE ZEROS TO RAMOIND-PCIOF. */
            _.Move(0, RAMOIND_PCIOF);

            /*" -2487- IF ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-SAUDE OR PARM-RAMO-PRESTA */

            if (ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_SAUDE.ToString(), PARM_RAMO_PRESTA.ToString()))
            {

                /*" -2489- PERFORM A3500-LE-SUBGRUPO. */

                A3500_LE_SUBGRUPO_SECTION();
            }


            /*" -2493- IF ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-PRESTA */

            if (ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_PRESTA.ToString()))
            {

                /*" -2502- PERFORM A3510-LE-RAMOIND. */

                A3510_LE_RAMOIND_SECTION();
            }


            /*" -2504- PERFORM A4000-LE-APOLICE. */

            A4000_LE_APOLICE_SECTION();

            /*" -2506- PERFORM A4100-LE-PROPCOB. */

            A4100_LE_PROPCOB_SECTION();

            /*" -2510- IF ((ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -2511- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -2512- PERFORM A4200-LE-AU085 */

                    A4200_LE_AU085_SECTION();

                    /*" -2513- ELSE */
                }
                else
                {


                    /*" -2514- MOVE '0' TO AU085-IND-FORMA-PAGTO-AD */
                    _.Move("0", AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);

                    /*" -2515- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

                    if (ENDO_TIPO_ENDOSSO == "4")
                    {

                        /*" -2516- MOVE ENDO-DTINIVIG TO ENDO-DTVENCTO */
                        _.Move(ENDO_DTINIVIG, ENDO_DTVENCTO);

                        /*" -2517- ELSE */
                    }
                    else
                    {


                        /*" -2519- MOVE SIST-DTMOVABE TO ENDO-DTVENCTO. */
                        _.Move(SIST_DTMOVABE, ENDO_DTVENCTO);
                    }

                }

            }


            /*" -2524- PERFORM A4500-LE-COBERAPOL. */

            A4500_LE_COBERAPOL_SECTION();

            /*" -2525- IF ENDO-CODPRODU EQUAL 1403 OR 1404 */

            if (ENDO_CODPRODU.In("1403", "1404"))
            {

                /*" -2536- PERFORM A4600-LE-MR-APOL-COBER. */

                A4600_LE_MR_APOL_COBER_SECTION();
            }


            /*" -2537- IF APOL-QTCOSSEG NOT EQUAL ZEROS */

            if (APOL_QTCOSSEG != 00)
            {

                /*" -2539- MOVE ' ' TO CH-APOLCOSCED */
                _.Move(" ", CH_APOLCOSCED);

                /*" -2540- PERFORM B0100-DECLARE-V0APOLCOSCED */

                B0100_DECLARE_V0APOLCOSCED_SECTION();

                /*" -2541- PERFORM B0200-FETCH-V0APOLCOSCED */

                B0200_FETCH_V0APOLCOSCED_SECTION();

                /*" -2543- PERFORM B1000-GRAVA-V0ORDECOSCED THRU B1000-999-EXIT UNTIL CH-APOLCOSCED EQUAL '1' */

                while (!(CH_APOLCOSCED == "1"))
                {

                    B1000_GRAVA_V0ORDECOSCED_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: B1000_999_EXIT*/

                }

                /*" -2545- END-IF */
            }


            /*" -2546- MOVE ENDO-COD-MOEDA-PRM TO COD-MOEDA. */
            _.Move(ENDO_COD_MOEDA_PRM, EM0901W099.COD_MOEDA);

            /*" -2548- MOVE ENDO-ISENTA-CUSTO TO ISENTA-CUSTO. */
            _.Move(ENDO_ISENTA_CUSTO, EM0901W099.ISENTA_CUSTO);

            /*" -2549- MOVE ENDO-QTPARCEL TO QTPARCEL. */
            _.Move(ENDO_QTPARCEL, EM0901W099.QTPARCEL);

            /*" -2551- MOVE COBE-TARIFARIO-VAR TO VL-PREMIO-BASE. */
            _.Move(COBE_TARIFARIO_VAR, EM0901W099.VL_PREMIO_BASE);

            /*" -2552- IF ENDO-TIPO-APOL EQUAL '6' */

            if (ENDO_TIPO_APOL == "6")
            {

                /*" -2553- MOVE ENDO-DTTERVIG TO W-DATA-EDITADA */
                _.Move(ENDO_DTTERVIG, W_DATA_EDITADA);

                /*" -2555- MOVE 01 TO W-DIA */
                _.Move(01, W_DATA_EDITADA.W_DIA);

                /*" -2556- IF W-MES EQUAL 12 */

                if (W_DATA_EDITADA.W_MES == 12)
                {

                    /*" -2557- MOVE 01 TO W-MES */
                    _.Move(01, W_DATA_EDITADA.W_MES);

                    /*" -2558- ADD 1 TO W-ANO */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                    /*" -2559- ELSE */
                }
                else
                {


                    /*" -2560- ADD 1 TO W-MES */
                    W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                    /*" -2561- ELSE */
                }

            }
            else
            {


                /*" -2567- IF ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-SAUDE OR PARM-RAMO-PRESTA */

                if (ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_SAUDE.ToString(), PARM_RAMO_PRESTA.ToString()))
                {

                    /*" -2568- IF ENDO-CODPRODU EQUAL 80 */

                    if (ENDO_CODPRODU == 80)
                    {

                        /*" -2569- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                        _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                        /*" -2570- ELSE */
                    }
                    else
                    {


                        /*" -2571- IF ENDO-NRRCAP GREATER ZEROS */

                        if (ENDO_NRRCAP > 00)
                        {

                            /*" -2572- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                            _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                            /*" -2573- ELSE */
                        }
                        else
                        {


                            /*" -2574- IF ENDO-DTVENCTO GREATER ENDO-DTTERVIG */

                            if (ENDO_DTVENCTO > ENDO_DTTERVIG)
                            {

                                /*" -2575- MOVE ENDO-DTTERVIG TO W-DATA-EDITADA */
                                _.Move(ENDO_DTTERVIG, W_DATA_EDITADA);

                                /*" -2576- MOVE W-DIA TO W-DD */
                                _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

                                /*" -2577- MOVE W-MES TO W-MM */
                                _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

                                /*" -2578- MOVE W-ANO TO W-AA */
                                _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

                                /*" -2579- MOVE W-DATA TO PROSOM-DATA01 */
                                _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

                                /*" -2580- MOVE 1 TO PROSOM-QTDIA */
                                _.Move(1, PROSOMW099.PROSOM_QTDIA);

                                /*" -2581- MOVE ZEROS TO PROSOM-DATA02 */
                                _.Move(0, PROSOMW099.PROSOM_DATA02);

                                /*" -2582- CALL 'PROSOCU1' USING PROSOMW099 */
                                _.Call("PROSOCU1", PROSOMW099);

                                /*" -2583- MOVE PROSOM-DATA02 TO W-DATA */
                                _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

                                /*" -2584- MOVE W-DD TO W-DIA */
                                _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

                                /*" -2585- MOVE W-MM TO W-MES */
                                _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

                                /*" -2586- MOVE W-AA TO W-ANO */
                                _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

                                /*" -2587- ELSE */
                            }
                            else
                            {


                                /*" -2588- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                                _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                                /*" -2589- ELSE */
                            }

                        }

                    }

                }
                else
                {


                    /*" -2591- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA. */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);
                }

            }


            /*" -2599- MOVE W-DATA-EDITADA TO DTINIVIG */
            _.Move(W_DATA_EDITADA, EM0901W099.DTINIVIG);

            /*" -2600- IF ENDO-DTVENCTO NOT EQUAL SPACES */

            if (!ENDO_DTVENCTO.IsEmpty())
            {

                /*" -2601- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                /*" -2602- MOVE W-DIA TO W-DIA-BASE */
                _.Move(W_DATA_EDITADA.W_DIA, W_DIA_BASE);

                /*" -2603- ELSE */
            }
            else
            {


                /*" -2604- IF PRCB-DIA-DEBITO NOT EQUAL ZEROS */

                if (PRCB_DIA_DEBITO != 00)
                {

                    /*" -2605- MOVE PRCB-DIA-DEBITO TO W-DIA-BASE */
                    _.Move(PRCB_DIA_DEBITO, W_DIA_BASE);

                    /*" -2606- ELSE */
                }
                else
                {


                    /*" -2607- IF ENDO-NRRCAP GREATER ZEROS */

                    if (ENDO_NRRCAP > 00)
                    {

                        /*" -2608- MOVE ENDO-DATARCAP TO W-DATA-EDITADA */
                        _.Move(ENDO_DATARCAP, W_DATA_EDITADA);

                        /*" -2609- MOVE W-DIA TO W-DIA-BASE */
                        _.Move(W_DATA_EDITADA.W_DIA, W_DIA_BASE);

                        /*" -2610- ELSE */
                    }
                    else
                    {


                        /*" -2611- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                        _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                        /*" -2615- MOVE W-DIA TO W-DIA-BASE. */
                        _.Move(W_DATA_EDITADA.W_DIA, W_DIA_BASE);
                    }

                }

            }


            /*" -2616- IF APOL-RAMO EQUAL 32 */

            if (APOL_RAMO == 32)
            {

                /*" -2617- IF APOL-MODALIDA EQUAL 0 OR 2 OR 3 */

                if (APOL_MODALIDA.In("0", "2", "3"))
                {

                    /*" -2618- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                    /*" -2619- ELSE */
                }
                else
                {


                    /*" -2620- MOVE SIST-DTMOVABE TO W-DATA-EDITADA */
                    _.Move(SIST_DTMOVABE, W_DATA_EDITADA);

                    /*" -2621- ELSE */
                }

            }
            else
            {


                /*" -2622- IF VIND-DTVENCTO EQUAL -1 */

                if (VIND_DTVENCTO == -1)
                {

                    /*" -2623- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                    /*" -2624- ELSE */
                }
                else
                {


                    /*" -2626- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);
                }

            }


            /*" -2628- MOVE ENDO-QTPARCEL TO QTPARCEL. */
            _.Move(ENDO_QTPARCEL, EM0901W099.QTPARCEL);

            /*" -2629- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -2630- MOVE 0 TO W-PARCEL */
                _.Move(0, W_PARCEL);

                /*" -2631- ELSE */
            }
            else
            {


                /*" -2633- MOVE 1 TO W-PARCEL. */
                _.Move(1, W_PARCEL);
            }


            /*" -2639- MOVE 'N' TO WCH-APOL-HABIT. */
            _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

            /*" -2642- PERFORM B2000-GRAVA-PARCELA UNTIL W-PARCEL GREATER ENDO-QTPARCEL. */

            while (!(W_PARCEL > ENDO_QTPARCEL))
            {

                B2000_GRAVA_PARCELA_SECTION();
            }

            /*" -2642- PERFORM B4000-ATUALIZA-ENDOSSO. */

            B4000_ATUALIZA_ENDOSSO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM B0010_LEITURA */

            B0010_LEITURA();

        }

        [StopWatch]
        /*" A6200-000-LE-RCAP-DB-SELECT-3 */
        public void A6200_000_LE_RCAP_DB_SELECT_3()
        {
            /*" -2398- EXEC SQL SELECT NRTIT INTO :V0RCAP-NRTIT FROM SEGUROS.V0RCAP WHERE FONTE = 010 AND NRRCAP = :ENDO-NRRCAP WITH UR END-EXEC */

            var a6200_000_LE_RCAP_DB_SELECT_3_Query1 = new A6200_000_LE_RCAP_DB_SELECT_3_Query1()
            {
                ENDO_NRRCAP = ENDO_NRRCAP.ToString(),
            };

            var executed_1 = A6200_000_LE_RCAP_DB_SELECT_3_Query1.Execute(a6200_000_LE_RCAP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_NRTIT, V0RCAP_NRTIT);
            }


        }

        [StopWatch]
        /*" B0010-LEITURA */
        private void B0010_LEITURA(bool isPerform = false)
        {
            /*" -2646- PERFORM A3000-LE-V0ENDOSSO. */

            A3000_LE_V0ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B9999_999_EXIT*/

        [StopWatch]
        /*" B0100-DECLARE-V0APOLCOSCED-SECTION */
        private void B0100_DECLARE_V0APOLCOSCED_SECTION()
        {
            /*" -2658- MOVE 'B0100' TO WNR-EXEC-SQL */
            _.Move("B0100", WABEND.WNR_EXEC_SQL);

            /*" -2665- PERFORM B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1 */

            B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1();

            /*" -2667- PERFORM B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1 */

            B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1();

            /*" -2669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2670- DISPLAY ' B0100- ERRO NO OPEN DA APOLCOS ' */
                _.Display($" B0100- ERRO NO OPEN DA APOLCOS ");

                /*" -2670- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B0100-DECLARE-V0APOLCOSCED-DB-OPEN-1 */
        public void B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1()
        {
            /*" -2667- EXEC SQL OPEN V0APOLCOS END-EXEC. */

            V0APOLCOS.Open();

        }

        [StopWatch]
        /*" B2200-020-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -5598- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE, NRRCAP, NRRCAPCO, OPERACAO, DTMOVTO, HORAOPER, SITUACAO, BCOAVISO, AGEAVISO, NRAVISO, VLRCAP, DATARCAP, DTCADAST, SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND SITUACAO = '0' WITH UR END-EXEC. */
            V1RCAPCOMP = new EM0030B_V1RCAPCOMP(true);
            string GetQuery_V1RCAPCOMP()
            {
                var query = @$"SELECT FONTE
							, NRRCAP
							, NRRCAPCO
							, OPERACAO
							, 
							DTMOVTO
							, HORAOPER
							, SITUACAO
							, BCOAVISO
							, 
							AGEAVISO
							, NRAVISO
							, VLRCAP
							, DATARCAP
							, 
							DTCADAST
							, SITCONTB 
							FROM SEGUROS.V1RCAPCOMP 
							WHERE FONTE = '{V0RCAP_FONTE}' 
							AND NRRCAP = '{V0RCAP_NRRCAP}' 
							AND SITUACAO = '0'";

                return query;
            }
            V1RCAPCOMP.GetQueryEvent += GetQuery_V1RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B0100_999_EXIT*/

        [StopWatch]
        /*" B0200-FETCH-V0APOLCOSCED-SECTION */
        private void B0200_FETCH_V0APOLCOSCED_SECTION()
        {
            /*" -2681- MOVE 'B0200' TO WNR-EXEC-SQL. */
            _.Move("B0200", WABEND.WNR_EXEC_SQL);

            /*" -2683- PERFORM B0200_FETCH_V0APOLCOSCED_DB_FETCH_1 */

            B0200_FETCH_V0APOLCOSCED_DB_FETCH_1();

            /*" -2686- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2687- MOVE '1' TO CH-APOLCOSCED */
                _.Move("1", CH_APOLCOSCED);

                /*" -2687- PERFORM B0200_FETCH_V0APOLCOSCED_DB_CLOSE_1 */

                B0200_FETCH_V0APOLCOSCED_DB_CLOSE_1();

                /*" -2688- END-IF. */
            }


        }

        [StopWatch]
        /*" B0200-FETCH-V0APOLCOSCED-DB-FETCH-1 */
        public void B0200_FETCH_V0APOLCOSCED_DB_FETCH_1()
        {
            /*" -2683- EXEC SQL FETCH V0APOLCOS INTO :COSS-CODCOSS END-EXEC. */

            if (V0APOLCOS.Fetch())
            {
                _.Move(V0APOLCOS.COSS_CODCOSS, COSS_CODCOSS);
            }

        }

        [StopWatch]
        /*" B0200-FETCH-V0APOLCOSCED-DB-CLOSE-1 */
        public void B0200_FETCH_V0APOLCOSCED_DB_CLOSE_1()
        {
            /*" -2687- EXEC SQL CLOSE V0APOLCOS END-EXEC */

            V0APOLCOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B0200_999_EXIT*/

        [StopWatch]
        /*" B1000-GRAVA-V0ORDECOSCED-SECTION */
        private void B1000_GRAVA_V0ORDECOSCED_SECTION()
        {
            /*" -2699- PERFORM B1050-LE-NUMERO-COSCED. */

            B1050_LE_NUMERO_COSCED_SECTION();

            /*" -2702- COMPUTE NORD-NRORDEM = NUME-NRORDEM + 1. */
            NORD_NRORDEM.Value = NUME_NRORDEM + 1;

            /*" -2703- MOVE COSS-CODCOSS TO WW-LIDER-ORDE. */
            _.Move(COSS_CODCOSS, W.FILLER_25.WW_LIDER_ORDE);

            /*" -2704- MOVE ENDO-ORGAO TO WW-ORGAO-ORDE. */
            _.Move(ENDO_ORGAO, W.FILLER_25.WW_ORGAO_ORDE);

            /*" -2705- MOVE NORD-NRORDEM TO WW-NRORD-ORDE. */
            _.Move(NORD_NRORDEM, W.FILLER_25.WW_NRORD_ORDE);

            /*" -2707- MOVE WW-ORDEM-ORDE TO WORD-NRORDEM. */
            _.Move(W.WW_ORDEM_ORDE, WORD_NRORDEM);

            /*" -2709- PERFORM B1060-ATU-NUMERO-COSCED. */

            B1060_ATU_NUMERO_COSCED_SECTION();

            /*" -2710- MOVE ENDO-NRENDOS TO NORD-NRENDOS. */
            _.Move(ENDO_NRENDOS, NORD_NRENDOS);

            /*" -2711- MOVE ENDO-NUM-APOLICE TO NORD-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, NORD_NUM_APOLICE);

            /*" -2712- MOVE -1 TO NORD-EMPRESA-I. */
            _.Move(-1, NORD_EMPRESA_I);

            /*" -2714- MOVE COSS-CODCOSS TO NORD-CODCOSS. */
            _.Move(COSS_CODCOSS, NORD_CODCOSS);

            /*" -2716- MOVE 'B1000' TO WNR-EXEC-SQL. */
            _.Move("B1000", WABEND.WNR_EXEC_SQL);

            /*" -2722- PERFORM B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1 */

            B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1();

            /*" -2725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2726- DISPLAY 'EM0030B - ERRO INSERT V0ORDECOSCED ------------' */
                _.Display($"EM0030B - ERRO INSERT V0ORDECOSCED ------------");

                /*" -2727- DISPLAY 'NUM_APOLICE  = ' NORD-NUM-APOLICE */
                _.Display($"NUM_APOLICE  = {NORD_NUM_APOLICE}");

                /*" -2728- DISPLAY 'NRENDOS      = ' NORD-NRENDOS */
                _.Display($"NRENDOS      = {NORD_NRENDOS}");

                /*" -2729- DISPLAY 'CODCOSS      = ' NORD-CODCOSS */
                _.Display($"CODCOSS      = {NORD_CODCOSS}");

                /*" -2730- DISPLAY 'ORDEM_CEDIDO = ' WORD-NRORDEM */
                _.Display($"ORDEM_CEDIDO = {WORD_NRORDEM}");

                /*" -2731- DISPLAY 'COD_EMPRESA  = ' NORD-COD-EMPRESA */
                _.Display($"COD_EMPRESA  = {NORD_COD_EMPRESA}");

                /*" -2732- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -2734- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2736- ADD 1 TO AC-I-V0ORDCOSCED. */
            AC_I_V0ORDCOSCED.Value = AC_I_V0ORDCOSCED + 1;

            /*" -2737- MOVE 'EM0103B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0103B1", V0EDIA_CODRELAT);

            /*" -2738- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -2739- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -2740- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -2741- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -2742- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -2743- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -2744- MOVE ZEROS TO V0EDIA-FONTE. */
            _.Move(0, V0EDIA_FONTE);

            /*" -2745- MOVE COSS-CODCOSS TO V0EDIA-CONGENER. */
            _.Move(COSS_CODCOSS, V0EDIA_CONGENER);

            /*" -2746- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -2748- MOVE NORD-EMPRESA-I TO V0EDIA-COD-EMP. */
            _.Move(NORD_EMPRESA_I, V0EDIA_COD_EMP);

            /*" -2751- PERFORM B4200-INCLUI-V0EMISDIARIA. */

            B4200_INCLUI_V0EMISDIARIA_SECTION();

            /*" -2753- IF ENDO-RAMO EQUAL 31 OR 53 NEXT SENTENCE */

            if (ENDO_RAMO.In("31", "53"))
            {

                /*" -2754- ELSE */
            }
            else
            {


                /*" -2755- MOVE ENDO-FONTE TO V0EDIA-FONTE */
                _.Move(ENDO_FONTE, V0EDIA_FONTE);

                /*" -2756- MOVE 'EM0105B1' TO V0EDIA-CODRELAT */
                _.Move("EM0105B1", V0EDIA_CODRELAT);

                /*" -2758- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -2758- PERFORM B0200-FETCH-V0APOLCOSCED. */

            B0200_FETCH_V0APOLCOSCED_SECTION();

        }

        [StopWatch]
        /*" B1000-GRAVA-V0ORDECOSCED-DB-INSERT-1 */
        public void B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1()
        {
            /*" -2722- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:NORD-NUM-APOLICE, :NORD-NRENDOS, :NORD-CODCOSS , :WORD-NRORDEM, :NORD-COD-EMPRESA:NORD-EMPRESA-I, CURRENT TIMESTAMP) END-EXEC. */

            var b1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1 = new B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1()
            {
                NORD_NUM_APOLICE = NORD_NUM_APOLICE.ToString(),
                NORD_NRENDOS = NORD_NRENDOS.ToString(),
                NORD_CODCOSS = NORD_CODCOSS.ToString(),
                WORD_NRORDEM = WORD_NRORDEM.ToString(),
                NORD_COD_EMPRESA = NORD_COD_EMPRESA.ToString(),
                NORD_EMPRESA_I = NORD_EMPRESA_I.ToString(),
            };

            B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1.Execute(b1000_GRAVA_V0ORDECOSCED_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B1000_999_EXIT*/

        [StopWatch]
        /*" B1050-LE-NUMERO-COSCED-SECTION */
        private void B1050_LE_NUMERO_COSCED_SECTION()
        {
            /*" -2769- MOVE 'B1050' TO WNR-EXEC-SQL. */
            _.Move("B1050", WABEND.WNR_EXEC_SQL);

            /*" -2776- PERFORM B1050_LE_NUMERO_COSCED_DB_SELECT_1 */

            B1050_LE_NUMERO_COSCED_DB_SELECT_1();

            /*" -2779- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2784- DISPLAY 'NAO EXISTE NA V1NUMERO_COSSEGURO ... ' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS ' ' ENDO-ORGAO ' ' COSS-CODCOSS */

                $"NAO EXISTE NA V1NUMERO_COSSEGURO ...  {ENDO_NUM_APOLICE} {ENDO_NRENDOS} {ENDO_ORGAO} {COSS_CODCOSS}"
                .Display();

                /*" -2784- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B1050-LE-NUMERO-COSCED-DB-SELECT-1 */
        public void B1050_LE_NUMERO_COSCED_DB_SELECT_1()
        {
            /*" -2776- EXEC SQL SELECT NRORDEM INTO :NUME-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :ENDO-ORGAO AND CONGENER = :COSS-CODCOSS WITH UR END-EXEC. */

            var b1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1 = new B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1()
            {
                COSS_CODCOSS = COSS_CODCOSS.ToString(),
                ENDO_ORGAO = ENDO_ORGAO.ToString(),
            };

            var executed_1 = B1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1.Execute(b1050_LE_NUMERO_COSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUME_NRORDEM, NUME_NRORDEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B1050_999_EXIT*/

        [StopWatch]
        /*" B1060-ATU-NUMERO-COSCED-SECTION */
        private void B1060_ATU_NUMERO_COSCED_SECTION()
        {
            /*" -2795- MOVE 'B1060' TO WNR-EXEC-SQL. */
            _.Move("B1060", WABEND.WNR_EXEC_SQL);

            /*" -2801- PERFORM B1060_ATU_NUMERO_COSCED_DB_UPDATE_1 */

            B1060_ATU_NUMERO_COSCED_DB_UPDATE_1();

            /*" -2804- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2806- DISPLAY 'ERRO ACESSO V0NUMERO_COSSEGURO ' ENDO-ORGAO ' ' COSS-CODCOSS */

                $"ERRO ACESSO V0NUMERO_COSSEGURO {ENDO_ORGAO} {COSS_CODCOSS}"
                .Display();

                /*" -2806- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B1060-ATU-NUMERO-COSCED-DB-UPDATE-1 */
        public void B1060_ATU_NUMERO_COSCED_DB_UPDATE_1()
        {
            /*" -2801- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :NORD-NRORDEM, TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :ENDO-ORGAO AND CONGENER = :COSS-CODCOSS END-EXEC. */

            var b1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1 = new B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1()
            {
                NORD_NRORDEM = NORD_NRORDEM.ToString(),
                COSS_CODCOSS = COSS_CODCOSS.ToString(),
                ENDO_ORGAO = ENDO_ORGAO.ToString(),
            };

            B1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1.Execute(b1060_ATU_NUMERO_COSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B1060_999_EXIT*/

        [StopWatch]
        /*" B1100-LE-V2RAMO-SECTION */
        private void B1100_LE_V2RAMO_SECTION()
        {
            /*" -2817- MOVE 'B1100' TO WNR-EXEC-SQL. */
            _.Move("B1100", WABEND.WNR_EXEC_SQL);

            /*" -2826- PERFORM B1100_LE_V2RAMO_DB_SELECT_1 */

            B1100_LE_V2RAMO_DB_SELECT_1();

            /*" -2829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2831- DISPLAY 'EM0030B - RAMO NAO CADASTRADO NA V2RAMO ... ' ' ' ENDO-RAMO */

                $"EM0030B - RAMO NAO CADASTRADO NA V2RAMO ...  {ENDO_RAMO}"
                .Display();

                /*" -2831- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B1100-LE-V2RAMO-DB-SELECT-1 */
        public void B1100_LE_V2RAMO_DB_SELECT_1()
        {
            /*" -2826- EXEC SQL SELECT TIPOFRAC INTO :RAMO-TIPOFRAC FROM SEGUROS.V2RAMO WHERE RAMO = :ENDO-RAMO AND MODALIDA = 0 AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG WITH UR END-EXEC. */

            var b1100_LE_V2RAMO_DB_SELECT_1_Query1 = new B1100_LE_V2RAMO_DB_SELECT_1_Query1()
            {
                ENDO_DTINIVIG = ENDO_DTINIVIG.ToString(),
                ENDO_RAMO = ENDO_RAMO.ToString(),
            };

            var executed_1 = B1100_LE_V2RAMO_DB_SELECT_1_Query1.Execute(b1100_LE_V2RAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMO_TIPOFRAC, RAMO_TIPOFRAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B1100_999_EXIT*/

        [StopWatch]
        /*" B2000-GRAVA-PARCELA-SECTION */
        private void B2000_GRAVA_PARCELA_SECTION()
        {
            /*" -2841- MOVE ENDO-RAMO TO RAMO. */
            _.Move(ENDO_RAMO, EM0901W099.RAMO);

            /*" -2842- MOVE W-PARCEL TO NRPARCEL. */
            _.Move(W_PARCEL, EM0901W099.NRPARCEL);

            /*" -2843- MOVE ENDO-PCENTRAD TO PCENTRAD. */
            _.Move(ENDO_PCENTRAD, EM0901W099.PCENTRAD);

            /*" -2844- MOVE ENDO-PCADICIO TO PCJUROS. */
            _.Move(ENDO_PCADICIO, EM0901W099.PCJUROS);

            /*" -2846- MOVE ENDO-PCDESCON TO PCDESCON. */
            _.Move(ENDO_PCDESCON, EM0901W099.PCDESCON);

            /*" -2849- IF ((RAMO-TIPOFRAC EQUAL '2' ) AND (ENDO-CODPRODU NOT EQUAL 98) AND (ENDO-PCADICIO GREATER 0)) */

            if (((RAMO_TIPOFRAC == "2") && (ENDO_CODPRODU != 98) && (ENDO_PCADICIO > 0)))
            {

                /*" -2850- MOVE 'S' TO IND-FRAC */
                _.Move("S", EM0901W099.IND_FRAC);

                /*" -2851- MOVE COBE-TARIFARIO-VAR TO VL-PREMIO-BASE */
                _.Move(COBE_TARIFARIO_VAR, EM0901W099.VL_PREMIO_BASE);

                /*" -2852- ELSE */
            }
            else
            {


                /*" -2856- MOVE 'N' TO IND-FRAC. */
                _.Move("N", EM0901W099.IND_FRAC);
            }


            /*" -2857- IF ENDO-CODPRODU EQUAL 6700 OR 6701 */

            if (ENDO_CODPRODU.In("6700", "6701"))
            {

                /*" -2858- PERFORM R5000-00-LE-PCIOCC */

                R5000_00_LE_PCIOCC_SECTION();

                /*" -2859- MOVE V1RAMO-PCIOF TO PCIOF */
                _.Move(V1RAMO_PCIOF, EM0901W099.PCIOF);

                /*" -2860- ELSE */
            }
            else
            {


                /*" -2861- MOVE APOL-PCIOCC TO PCIOF */
                _.Move(APOL_PCIOCC, EM0901W099.PCIOF);

                /*" -2865- END-IF. */
            }


            /*" -2866- IF ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' */

            if (ENDO_TIPO_ENDOSSO.In("3", "5"))
            {

                /*" -2867- MOVE ZEROS TO PCIOF */
                _.Move(0, EM0901W099.PCIOF);

                /*" -2869- MOVE 'N' TO WCH-APOL-HABIT */
                _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                /*" -2870- IF ENDO-NUM-APOLICE EQUAL 0106800000007 OR 0106500000001 */

                if (ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -2871- MOVE 'S' TO WCH-APOL-HABIT */
                    _.Move("S", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                    /*" -2872- PERFORM B2040-SELECT-V0APOL-HABIT */

                    B2040_SELECT_V0APOL_HABIT_SECTION();

                    /*" -2874- END-IF */
                }


                /*" -2875- IF ENDO-NUM-APOLICE EQUAL 0106800000007 OR 0106500000001 */

                if (ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -2876- MOVE ZEROS TO PCIOF */
                    _.Move(0, EM0901W099.PCIOF);

                    /*" -2877- PERFORM B2081-SELECT-V0PREMIO-HAB */

                    B2081_SELECT_V0PREMIO_HAB_SECTION();

                    /*" -2879- END-IF */
                }


                /*" -2881- MOVE ENDO-DTINIVIG TO WHOST-DTINIVIG */
                _.Move(ENDO_DTINIVIG, WHOST_DTINIVIG);

                /*" -2883- PERFORM B2500-LE-MOEDA */

                B2500_LE_MOEDA_SECTION();

                /*" -2885- COMPUTE WS000-IOF-RAMO68-IX ROUNDED = WS000-IOF-RAMO68 / MOED-VALOR */
                WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68_IX.Value = WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68 / MOED_VALOR;

                /*" -2886- ELSE */
            }
            else
            {


                /*" -2888- MOVE 'N' TO WCH-APOL-HABIT */
                _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                /*" -2890- IF ENDO-NUM-APOLICE EQUAL 0106800000007 OR 0106500000001 */

                if (ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -2891- MOVE 'S' TO WCH-APOL-HABIT */
                    _.Move("S", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                    /*" -2892- PERFORM B2040-SELECT-V0APOL-HABIT */

                    B2040_SELECT_V0APOL_HABIT_SECTION();

                    /*" -2894- END-IF */
                }


                /*" -2895- IF ENDO-NUM-APOLICE EQUAL 106800000007 OR 106500000001 */

                if (ENDO_NUM_APOLICE.In("106800000007", "106500000001"))
                {

                    /*" -2896- MOVE ZEROS TO PCIOF */
                    _.Move(0, EM0901W099.PCIOF);

                    /*" -2897- PERFORM B2080-SELECT-V0PREMIO-HAB */

                    B2080_SELECT_V0PREMIO_HAB_SECTION();

                    /*" -2899- END-IF */
                }


                /*" -2901- MOVE ENDO-DTINIVIG TO WHOST-DTINIVIG */
                _.Move(ENDO_DTINIVIG, WHOST_DTINIVIG);

                /*" -2903- PERFORM B2500-LE-MOEDA */

                B2500_LE_MOEDA_SECTION();

                /*" -2906- COMPUTE WS000-IOF-RAMO68-IX ROUNDED = WS000-IOF-RAMO68 / MOED-VALOR. */
                WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68_IX.Value = WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68 / MOED_VALOR;
            }


            /*" -2908- MOVE ENDO-NRRCAP TO NRRCAP */
            _.Move(ENDO_NRRCAP, EM0901W099.NRRCAP);

            /*" -2925- MOVE ZEROS TO VL-DESC-IX VL-LIQ-IX VL-TARIFARIO-IX VL-ADIC-IX VL-CUSTO-IX VL-IOF-IX VL-TOTAL-IX VL-TARIFA VL-DESCONTO VL-LIQUIDO VL-ADICIONAL VL-CUSTO VL-IOF VL-TOTAL VL-COBER-ASSIST PCDESCON-ADIC PCDESCON-BONUS. */
            _.Move(0, EM0901W099.VL_DESC_IX, EM0901W099.VL_LIQ_IX, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_ADIC_IX, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_IOF_IX, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TARIFA, EM0901W099.VL_DESCONTO, EM0901W099.VL_LIQUIDO, EM0901W099.VL_ADICIONAL, EM0901W099.VL_CUSTO, EM0901W099.VL_IOF, EM0901W099.VL_TOTAL, EM0901W099.VL_COBER_ASSIST, EM0901W099.PCDESCON_ADIC, EM0901W099.PCDESCON_BONUS);

            /*" -2928- MOVE SPACES TO W01A0077. */
            _.Move("", EM0901W099.W01A0077);

            /*" -2931- IF ENDO-CODPRODU EQUAL 1403 OR 1404 OR 1804 */

            if (ENDO_CODPRODU.In("1403", "1404", "1804"))
            {

                /*" -2932- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

                if (ENDO_TIPO_ENDOSSO == "4")
                {

                    /*" -2934- MOVE ZEROS TO VL-PREMIO-BASE VL-TARIFARIO-IX */
                    _.Move(0, EM0901W099.VL_PREMIO_BASE, EM0901W099.VL_TARIFARIO_IX);

                    /*" -2937- GO TO B2001-CONTINUA. */

                    B2001_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2939- MOVE 0 TO AUTA-NRPRRESS */
            _.Move(0, AUTA_NRPRRESS);

            /*" -2940- IF ENDO-RAMO EQUAL ( 31 OR 53 ) */

            if (ENDO_RAMO.In("31", "53"))
            {

                /*" -2951- PERFORM B2000_GRAVA_PARCELA_DB_SELECT_1 */

                B2000_GRAVA_PARCELA_DB_SELECT_1();

                /*" -2954- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2955- MOVE 'B2000' TO WNR-EXEC-SQL */
                    _.Move("B2000", WABEND.WNR_EXEC_SQL);

                    /*" -2957- DISPLAY 'EM0030B - ERRO NO SELECT AUTOAPOL ... ' ' ' ENDO-NUM-APOLICE */

                    $"EM0030B - ERRO NO SELECT AUTOAPOL ...  {ENDO_NUM_APOLICE}"
                    .Display();

                    /*" -2958- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2960- END-IF */
                }


                /*" -2961- IF AUTA-NRPRRESS GREATER 205 */

                if (AUTA_NRPRRESS > 205)
                {

                    /*" -2962- MOVE ENDO-VLCUSEMI TO VL-CUSTO */
                    _.Move(ENDO_VLCUSEMI, EM0901W099.VL_CUSTO);

                    /*" -2963- ELSE */
                }
                else
                {


                    /*" -2964- MOVE ZEROS TO VL-CUSTO */
                    _.Move(0, EM0901W099.VL_CUSTO);

                    /*" -2966- END-IF */
                }


                /*" -2967- MOVE AUTA-NRPRRESS TO W01A0077-VERSAO */
                _.Move(AUTA_NRPRRESS, EM0901W099.W01A0077R.W01A0077_VERSAO);

                /*" -2968- MOVE AUTA-TIPO-COBRANCA TO W01A0077-TIPCOB */
                _.Move(AUTA_TIPO_COBRANCA, EM0901W099.W01A0077R.W01A0077_TIPCOB);

                /*" -2969- MOVE ENDO-QTPARCEL TO W01A0077-QTPARC */
                _.Move(ENDO_QTPARCEL, EM0901W099.W01A0077R.W01A0077_QTPARC);

                /*" -2970- MOVE ENDO-CODPRODU TO W01A0077-CODPRO */
                _.Move(ENDO_CODPRODU, EM0901W099.W01A0077R.W01A0077_CODPRO);

                /*" -2972- MOVE ENDO-DTINIVIG TO W01A0077-INIVIG */
                _.Move(ENDO_DTINIVIG, EM0901W099.W01A0077R.W01A0077_INIVIG);

                /*" -2974- END-IF. */
            }


            /*" -2975- IF ENDO-CODPRODU EQUAL 1403 OR 1404 */

            if (ENDO_CODPRODU.In("1403", "1404"))
            {

                /*" -2980- MOVE 111 TO W01A0077-VERSAO. */
                _.Move(111, EM0901W099.W01A0077R.W01A0077_VERSAO);
            }


            /*" -2981- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -2982- IF ENDO-TIPO-ENDOSSO EQUAL '0' */

                if (ENDO_TIPO_ENDOSSO == "0")
                {

                    /*" -2983- IF W-PARCEL EQUAL 0 OR 1 */

                    if (W_PARCEL.In("0", "1"))
                    {

                        /*" -2984- PERFORM B2060-CHAMA-LT3116S */

                        B2060_CHAMA_LT3116S_SECTION();

                        /*" -2985- END-IF */
                    }


                    /*" -2986- PERFORM B2062-MONTA-PARCELA */

                    B2062_MONTA_PARCELA_SECTION();

                    /*" -2987- ELSE */
                }
                else
                {


                    /*" -2988- IF W-PARCEL EQUAL 0 OR 1 */

                    if (W_PARCEL.In("0", "1"))
                    {

                        /*" -2989- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

                        if (ENDO_TIPO_ENDOSSO == "4")
                        {

                            /*" -2990- INITIALIZE LT2118S-AREA-PARAMETROS */
                            _.Initialize(
                                LBLT2118.LT2118S_AREA_PARAMETROS
                            );

                            /*" -2991- ELSE */
                        }
                        else
                        {


                            /*" -2992- PERFORM B2063-CHAMA-LT2118S */

                            B2063_CHAMA_LT2118S_SECTION();

                            /*" -2993- END-IF */
                        }


                        /*" -2994- END-IF */
                    }


                    /*" -2995- PERFORM B2065-MONTA-PARCELA */

                    B2065_MONTA_PARCELA_SECTION();

                    /*" -2996- END-IF */
                }


                /*" -3000- GO TO B2000-CONTINUA. */

                B2000_CONTINUA(); //GOTO
                return;
            }


            /*" -3002- IF ENDO-CODPRODU EQUAL 1804 AND ENDO-COD-EMPRESA EQUAL 0 */

            if (ENDO_CODPRODU == 1804 && ENDO_COD_EMPRESA == 0)
            {

                /*" -3003- GO TO B2000-PROC-1804 */

                B2000_PROC_1804(); //GOTO
                return;

                /*" -3005- END-IF. */
            }


            /*" -3007- IF ENDO-CODPRODU EQUAL 6701 AND ENDO-NRENDOS GREATER ZEROS */

            if (ENDO_CODPRODU == 6701 && ENDO_NRENDOS > 00)
            {

                /*" -3008- PERFORM R3000-LE-CUSTO-APOLICE */

                R3000_LE_CUSTO_APOLICE_SECTION();

                /*" -3009- MOVE PARC-OTNCUSTO TO ENDO-VLCUSEMI */
                _.Move(PARC_OTNCUSTO, ENDO_VLCUSEMI);

                /*" -3011- END-IF. */
            }


            /*" -3015- IF ((ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND (ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -3016- PERFORM R1100-00-PARCELA-AUTO-FACIL */

                R1100_00_PARCELA_AUTO_FACIL_SECTION();

                /*" -3018- END-IF */
            }


            /*" -3020- IF ENDO-RAMO EQUAL ( 31 OR 53 ) AND AUTA-NRPRRESS GREATER 195 */

            if (ENDO_RAMO.In("31", "53") && AUTA_NRPRRESS > 195)
            {

                /*" -3021- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                _.Move("EM0903S", WS_SUBROT_CALC);

                /*" -3022- CALL 'EM0903S' USING EM0901W099 */
                _.Call("EM0903S", EM0901W099);

                /*" -3023- ELSE */
            }
            else
            {


                /*" -3024- MOVE ENDO-VLCUSEMI TO VL-CUSTO */
                _.Move(ENDO_VLCUSEMI, EM0901W099.VL_CUSTO);

                /*" -3030- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802) AND ENDO-COD-EMPRESA EQUAL 0)) */

                if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802) && ENDO_COD_EMPRESA == 0)))
                {

                    /*" -3032- IF ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1602 */

                    if (ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1602)
                    {

                        /*" -3033- PERFORM B2020-SELECT-MR021 */

                        B2020_SELECT_MR021_SECTION();

                        /*" -3034- MOVE MR021-PCT-DESC-COBERTURA TO PCDESCON-ADIC */
                        _.Move(MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_DESC_COBERTURA, EM0901W099.PCDESCON_ADIC);

                        /*" -3035- MOVE MR021-PCT-BONUS-RENOVCAO TO PCDESCON-BONUS */
                        _.Move(MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_BONUS_RENOVCAO, EM0901W099.PCDESCON_BONUS);

                        /*" -3036- MOVE MR021-PCT-DESC-CORRETOR TO PCDESCON */
                        _.Move(MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_DESC_CORRETOR, EM0901W099.PCDESCON);

                        /*" -3037- ELSE */
                    }
                    else
                    {


                        /*" -3038- PERFORM B2030-SELECT-MR022 */

                        B2030_SELECT_MR022_SECTION();

                        /*" -3039- MOVE MR022-PCT-DESC-COBERTURA TO PCDESCON-ADIC */
                        _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA, EM0901W099.PCDESCON_ADIC);

                        /*" -3040- MOVE MR022-PCT-BONUS-RENOVCAO TO PCDESCON-BONUS */
                        _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO, EM0901W099.PCDESCON_BONUS);

                        /*" -3041- MOVE MR022-PCT-DESC-CORRETOR TO PCDESCON */
                        _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_CORRETOR, EM0901W099.PCDESCON);

                        /*" -3042- END-IF */
                    }


                    /*" -3044- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' AND ENDO-TIPO-ENDOSSO NOT EQUAL '1' */

                    if (ENDO_TIPO_ENDOSSO != "0" && ENDO_TIPO_ENDOSSO != "1")
                    {

                        /*" -3047- MOVE ZEROS TO PCDESCON-ADIC PCDESCON-BONUS PCDESCON */
                        _.Move(0, EM0901W099.PCDESCON_ADIC, EM0901W099.PCDESCON_BONUS, EM0901W099.PCDESCON);

                        /*" -3048- END-IF */
                    }


                    /*" -3049- PERFORM B2035-SELECT-MRAPOCOB */

                    B2035_SELECT_MRAPOCOB_SECTION();

                    /*" -3050- MOVE MRAPOCOB-PRM-TARIFARIO-IX TO VL-COBER-ASSIST */
                    _.Move(MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX, EM0901W099.VL_COBER_ASSIST);

                    /*" -3051- MOVE ENDO-CFPREFIX TO VL-ADICIONAL */
                    _.Move(ENDO_CFPREFIX, EM0901W099.VL_ADICIONAL);

                    /*" -3052- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                    if (EM0901W099.VL_PREMIO_BASE <= 00)
                    {

                        /*" -3055- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                        _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                        /*" -3056- END-IF */
                    }


                    /*" -3057- MOVE 'EM0904S' TO WS-SUBROT-CALC */
                    _.Move("EM0904S", WS_SUBROT_CALC);

                    /*" -3058- CALL 'EM0904S' USING EM0901W099 */
                    _.Call("EM0904S", EM0901W099);

                    /*" -3059- ELSE */
                }
                else
                {


                    /*" -3061- IF ENDO-CODPRODU EQUAL 1403 OR ENDO-CODPRODU EQUAL 1404 */

                    if (ENDO_CODPRODU == 1403 || ENDO_CODPRODU == 1404)
                    {

                        /*" -3062- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                        if (EM0901W099.VL_PREMIO_BASE <= 00)
                        {

                            /*" -3065- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                            _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                            /*" -3066- END-IF */
                        }


                        /*" -3067- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                        _.Move("EM0903S", WS_SUBROT_CALC);

                        /*" -3068- CALL 'EM0903S' USING EM0901W099 */
                        _.Call("EM0903S", EM0901W099);

                        /*" -3069- ELSE */
                    }
                    else
                    {


                        /*" -3071- IF ENDO-CODPRODU EQUAL 6701 AND ENDO-NRENDOS GREATER ZEROS */

                        if (ENDO_CODPRODU == 6701 && ENDO_NRENDOS > 00)
                        {

                            /*" -3072- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                            if (EM0901W099.VL_PREMIO_BASE <= 00)
                            {

                                /*" -3075- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                                _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                                /*" -3076- END-IF */
                            }


                            /*" -3077- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                            _.Move("EM0903S", WS_SUBROT_CALC);

                            /*" -3078- CALL 'EM0903S' USING EM0901W099 */
                            _.Call("EM0903S", EM0901W099);

                            /*" -3079- ELSE */
                        }
                        else
                        {


                            /*" -3080- IF ENDO-VLCUSEMI EQUAL ZEROS */

                            if (ENDO_VLCUSEMI == 00)
                            {

                                /*" -3081- MOVE 'EM0901S' TO WS-SUBROT-CALC */
                                _.Move("EM0901S", WS_SUBROT_CALC);

                                /*" -3082- CALL 'EM0901S' USING EM0901W099 */
                                _.Call("EM0901S", EM0901W099);

                                /*" -3084- ELSE */
                            }
                            else
                            {


                                /*" -3085- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                                if (EM0901W099.VL_PREMIO_BASE <= 00)
                                {

                                    /*" -3088- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                                    _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                                    /*" -3090- END-IF */
                                }


                                /*" -3091- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                                _.Move("EM0903S", WS_SUBROT_CALC);

                                /*" -3092- CALL 'EM0903S' USING EM0901W099 */
                                _.Call("EM0903S", EM0901W099);

                                /*" -3094- END-IF. */
                            }

                        }

                    }

                }

            }


            /*" -3095- IF W01A0077 NOT EQUAL SPACES */

            if (!EM0901W099.W01A0077.IsEmpty())
            {

                /*" -3096- DISPLAY 'PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S' */
                _.Display($"PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S");

                /*" -3097- DISPLAY 'PROBLEMAS CALL SUB-ROTINA ' WS-SUBROT-CALC */
                _.Display($"PROBLEMAS CALL SUB-ROTINA {WS_SUBROT_CALC}");

                /*" -3098- DISPLAY 'APOLICE ... ' ENDO-NUM-APOLICE */
                _.Display($"APOLICE ... {ENDO_NUM_APOLICE}");

                /*" -3099- DISPLAY 'ENDOSSO ... ' ENDO-NRENDOS */
                _.Display($"ENDOSSO ... {ENDO_NRENDOS}");

                /*" -3100- DISPLAY 'ENDO-COD-MOEDA-PRM = ' ENDO-COD-MOEDA-PRM */
                _.Display($"ENDO-COD-MOEDA-PRM = {ENDO_COD_MOEDA_PRM}");

                /*" -3101- DISPLAY 'W-DATA-EDITADA     = ' W-DATA-EDITADA */
                _.Display($"W-DATA-EDITADA     = {W_DATA_EDITADA}");

                /*" -3102- DISPLAY 'COD-MOEDA          = ' COD-MOEDA */
                _.Display($"COD-MOEDA          = {EM0901W099.COD_MOEDA}");

                /*" -3103- DISPLAY 'DTINIVIG           = ' DTINIVIG */
                _.Display($"DTINIVIG           = {EM0901W099.DTINIVIG}");

                /*" -3104- DISPLAY '------------------------------------' */
                _.Display($"------------------------------------");

                /*" -3105- DISPLAY 'W01A0077-VERSAO    = ' W01A0077-VERSAO */
                _.Display($"W01A0077-VERSAO    = {EM0901W099.W01A0077R.W01A0077_VERSAO}");

                /*" -3106- DISPLAY 'W01A0077-TIPCOB    = ' W01A0077-TIPCOB */
                _.Display($"W01A0077-TIPCOB    = {EM0901W099.W01A0077R.W01A0077_TIPCOB}");

                /*" -3107- DISPLAY 'W01A0077-QTPARC    = ' W01A0077-QTPARC */
                _.Display($"W01A0077-QTPARC    = {EM0901W099.W01A0077R.W01A0077_QTPARC}");

                /*" -3108- DISPLAY 'W01A0077-CODPRO    = ' W01A0077-CODPRO */
                _.Display($"W01A0077-CODPRO    = {EM0901W099.W01A0077R.W01A0077_CODPRO}");

                /*" -3109- DISPLAY 'W01A0077-INIVIG    = ' W01A0077-INIVIG */
                _.Display($"W01A0077-INIVIG    = {EM0901W099.W01A0077R.W01A0077_INIVIG}");

                /*" -3110- DISPLAY '------------------------------------' */
                _.Display($"------------------------------------");

                /*" -3111- DISPLAY '                   = ' */
                _.Display($"                   = ");

                /*" -3112- DISPLAY 'CODIGO DE ERRO ' W01A0077 */
                _.Display($"CODIGO DE ERRO {EM0901W099.W01A0077}");

                /*" -3114- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3118- IF ((ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND (ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -3120- GO TO B2002-CONTINUA. */

                B2002_CONTINUA(); //GOTO
                return;
            }


            /*" -3120- GO TO B2000-CONTINUA. */

            B2000_CONTINUA(); //GOTO
            return;

        }

        [StopWatch]
        /*" B2000-GRAVA-PARCELA-DB-SELECT-1 */
        public void B2000_GRAVA_PARCELA_DB_SELECT_1()
        {
            /*" -2951- EXEC SQL SELECT DISTINCT NRPRRESS, TIPO_COBRANCA INTO :AUTA-NRPRRESS, :AUTA-TIPO-COBRANCA FROM SEGUROS.V0AUTOAPOL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND SITUACAO = ' ' ORDER BY 1,2 WITH UR END-EXEC */

            var b2000_GRAVA_PARCELA_DB_SELECT_1_Query1 = new B2000_GRAVA_PARCELA_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2000_GRAVA_PARCELA_DB_SELECT_1_Query1.Execute(b2000_GRAVA_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AUTA_NRPRRESS, AUTA_NRPRRESS);
                _.Move(executed_1.AUTA_TIPO_COBRANCA, AUTA_TIPO_COBRANCA);
            }


        }

        [StopWatch]
        /*" B2000-PROC-1804 */
        private void B2000_PROC_1804(bool isPerform = false)
        {
            /*" -3126- MOVE ENDO-VLCUSEMI TO VL-CUSTO */
            _.Move(ENDO_VLCUSEMI, EM0901W099.VL_CUSTO);

            /*" -3127- PERFORM B2030-SELECT-MR022 */

            B2030_SELECT_MR022_SECTION();

            /*" -3129- PERFORM B2031-SELECT-MRAPOITE */

            B2031_SELECT_MRAPOITE_SECTION();

            /*" -3130- MOVE MR022-PCT-DESC-COBERTURA TO PCDESCON-ADIC */
            _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA, EM0901W099.PCDESCON_ADIC);

            /*" -3131- MOVE MR022-PCT-BONUS-RENOVCAO TO PCDESCON-BONUS */
            _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO, EM0901W099.PCDESCON_BONUS);

            /*" -3133- MOVE MRAPOITE-PCT-DESC-FIDEL TO PCDESCON */
            _.Move(MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL, EM0901W099.PCDESCON);

            /*" -3136- MOVE MRAPOITE-PCT-DESC-COMERCIAL TO PCDESCON-COMERC */
            _.Move(MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_COMERCIAL, EM0901W099.PCDESCON_COMERC);

            /*" -3138- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' AND ENDO-TIPO-ENDOSSO NOT EQUAL '1' */

            if (ENDO_TIPO_ENDOSSO != "0" && ENDO_TIPO_ENDOSSO != "1")
            {

                /*" -3142- MOVE ZEROS TO PCDESCON-ADIC PCDESCON-BONUS PCDESCON PCDESCON-COMERC */
                _.Move(0, EM0901W099.PCDESCON_ADIC, EM0901W099.PCDESCON_BONUS, EM0901W099.PCDESCON, EM0901W099.PCDESCON_COMERC);

                /*" -3144- END-IF. */
            }


            /*" -3146- PERFORM B2035-SELECT-MRAPOCOB */

            B2035_SELECT_MRAPOCOB_SECTION();

            /*" -3147- MOVE MRAPOCOB-PRM-TARIFARIO-IX TO VL-COBER-ASSIST */
            _.Move(MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX, EM0901W099.VL_COBER_ASSIST);

            /*" -3149- MOVE ENDO-CFPREFIX TO VL-ADICIONAL */
            _.Move(ENDO_CFPREFIX, EM0901W099.VL_ADICIONAL);

            /*" -3150- IF VL-PREMIO-BASE NOT GREATER ZEROS */

            if (EM0901W099.VL_PREMIO_BASE <= 00)
            {

                /*" -3153- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                /*" -3161- END-IF */
            }


            /*" -3162- MOVE 'EM0905S' TO WS-SUBROT-CALC */
            _.Move("EM0905S", WS_SUBROT_CALC);

            /*" -3168- CALL 'EM0905S' USING EM0901W099. */
            _.Call("EM0905S", EM0901W099);

            /*" -3169- IF W01A0077 NOT EQUAL SPACES */

            if (!EM0901W099.W01A0077.IsEmpty())
            {

                /*" -3170- DISPLAY 'PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S' */
                _.Display($"PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S");

                /*" -3171- DISPLAY 'PROBLEMAS CALL SUB-ROTINA ' WS-SUBROT-CALC */
                _.Display($"PROBLEMAS CALL SUB-ROTINA {WS_SUBROT_CALC}");

                /*" -3172- DISPLAY 'APOLICE ... ' ENDO-NUM-APOLICE */
                _.Display($"APOLICE ... {ENDO_NUM_APOLICE}");

                /*" -3173- DISPLAY 'ENDOSSO ... ' ENDO-NRENDOS */
                _.Display($"ENDOSSO ... {ENDO_NRENDOS}");

                /*" -3174- DISPLAY 'ENDO-COD-MOEDA-PRM = ' ENDO-COD-MOEDA-PRM */
                _.Display($"ENDO-COD-MOEDA-PRM = {ENDO_COD_MOEDA_PRM}");

                /*" -3175- DISPLAY 'W-DATA-EDITADA    = ' W-DATA-EDITADA */
                _.Display($"W-DATA-EDITADA    = {W_DATA_EDITADA}");

                /*" -3176- DISPLAY 'COD-MOEDA          = ' COD-MOEDA */
                _.Display($"COD-MOEDA          = {EM0901W099.COD_MOEDA}");

                /*" -3177- DISPLAY 'DTINIVIG           = ' DTINIVIG */
                _.Display($"DTINIVIG           = {EM0901W099.DTINIVIG}");

                /*" -3178- DISPLAY 'CODIGO DE ERRO ' W01A0077 */
                _.Display($"CODIGO DE ERRO {EM0901W099.W01A0077}");

                /*" -3178- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2000-CONTINUA */
        private void B2000_CONTINUA(bool isPerform = false)
        {
            /*" -3184- MOVE 'B1998' TO WNR-EXEC-SQL. */
            _.Move("B1998", WABEND.WNR_EXEC_SQL);

            /*" -3191- PERFORM B2000_CONTINUA_DB_SELECT_1 */

            B2000_CONTINUA_DB_SELECT_1();

            /*" -3194- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3196- MOVE 'B1999' TO WNR-EXEC-SQL */
                _.Move("B1999", WABEND.WNR_EXEC_SQL);

                /*" -3203- PERFORM B2000_CONTINUA_DB_SELECT_2 */

                B2000_CONTINUA_DB_SELECT_2();

                /*" -3206- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -3208- MOVE FATU-VLPRMTOT TO VL-TOTAL VL-TOTAL-IX */
                    _.Move(FATU_VLPRMTOT, EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

                    /*" -3211- MOVE FATU-VLIOCC TO VL-IOF VL-IOF-IX. */
                    _.Move(FATU_VLIOCC, EM0901W099.VL_IOF, EM0901W099.VL_IOF_IX);
                }

            }


            /*" -3241- IF (ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-PRESTA) AND SQLCODE EQUAL 100 AND RAMOIND-PCIOF NOT EQUAL ZEROS AND ENDO-NUM-APOLICE NOT EQUAL 107700000010 AND 107700000015 AND 107700000016 AND 107700000022 AND 101402541675 AND 107700000021 AND 107700000023 AND 107700000038 AND 101402541678 AND 107700000026 AND 106100000018 AND 101402541679 AND 106100000030 AND 101402541682 AND 106100000033 AND 101402541681 AND 106100000036 AND 101402541683 AND 107700000047 AND 107700000049 AND 107700000050 AND 107700000058 */

            if ((ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_PRESTA.ToString())) && DB.SQLCODE == 100 && RAMOIND_PCIOF != 00 && !ENDO_NUM_APOLICE.In("107700000010", "107700000015", "107700000016", "107700000022", "101402541675", "107700000021", "107700000023", "107700000038", "101402541678", "107700000026", "106100000018", "101402541679", "106100000030", "101402541682", "106100000033", "101402541681", "106100000036", "101402541683", "107700000047", "107700000049", "107700000050", "107700000058"))
            {

                /*" -3243- COMPUTE VL-TOTAL = VL-PREMIO-BASE * RAMOIND-PCIOF */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_PREMIO_BASE * RAMOIND_PCIOF;

                /*" -3244- MOVE VL-TOTAL TO VL-TOTAL-IX */
                _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

                /*" -3246- COMPUTE VL-IOF = VL-TOTAL - VL-PREMIO-BASE */
                EM0901W099.VL_IOF.Value = EM0901W099.VL_TOTAL - EM0901W099.VL_PREMIO_BASE;

                /*" -3248- MOVE VL-IOF TO VL-IOF-IX */
                _.Move(EM0901W099.VL_IOF, EM0901W099.VL_IOF_IX);

                /*" -3255- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802 OR ENDO-CODPRODU EQUAL 1804) AND ENDO-COD-EMPRESA EQUAL 0)) */

                if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802 || ENDO_CODPRODU == 1804) && ENDO_COD_EMPRESA == 0)))
                {

                    /*" -3257- GO TO B2001-CONTINUA. */

                    B2001_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -3258- IF W-PARCEL EQUAL 1 */

            if (W_PARCEL == 1)
            {

                /*" -3259- IF ENDO-VLRCAP NOT EQUAL ZEROS */

                if (ENDO_VLRCAP != 00)
                {

                    /*" -3260- PERFORM B2400-AJUSTA-PARCELA */

                    B2400_AJUSTA_PARCELA_SECTION();

                    /*" -3264- ELSE */
                }
                else
                {


                    /*" -3265- IF ENDO-PCADICIO EQUAL ZEROS */

                    if (ENDO_PCADICIO == 00)
                    {

                        /*" -3266- IF ENDO-CODPRODU NOT EQUAL 1804 */

                        if (ENDO_CODPRODU != 1804)
                        {

                            /*" -3268- COMPUTE VL-PREMIO-BASE = VL-PREMIO-BASE - VL-TARIFARIO-IX */
                            EM0901W099.VL_PREMIO_BASE.Value = EM0901W099.VL_PREMIO_BASE - EM0901W099.VL_TARIFARIO_IX;

                            /*" -3268- END-IF. */
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" B2000-CONTINUA-DB-SELECT-1 */
        public void B2000_CONTINUA_DB_SELECT_1()
        {
            /*" -3191- EXEC SQL SELECT VAL_FATURA, VLIOCC INTO :FATU-VLPRMTOT, :FATU-VLIOCC FROM SEGUROS.V0FATURAS WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS WITH UR END-EXEC. */

            var b2000_CONTINUA_DB_SELECT_1_Query1 = new B2000_CONTINUA_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2000_CONTINUA_DB_SELECT_1_Query1.Execute(b2000_CONTINUA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATU_VLPRMTOT, FATU_VLPRMTOT);
                _.Move(executed_1.FATU_VLIOCC, FATU_VLIOCC);
            }


        }

        [StopWatch]
        /*" B2001-CONTINUA */
        private void B2001_CONTINUA(bool isPerform = false)
        {
            /*" -3276- IF W-PARCEL GREATER 1 */

            if (W_PARCEL > 1)
            {

                /*" -3278- COMPUTE VL-TARIFARIO-IX = VL-TARIFARIO-IX - VL-DIFTAR-IX */
                EM0901W099.VL_TARIFARIO_IX.Value = EM0901W099.VL_TARIFARIO_IX - FILLER_28.VL_DIFTAR_IX;

                /*" -3280- COMPUTE VL-DESC-IX = VL-DESC-IX - VL-DIFDESC-IX */
                EM0901W099.VL_DESC_IX.Value = EM0901W099.VL_DESC_IX - FILLER_28.VL_DIFDESC_IX;

                /*" -3282- COMPUTE VL-LIQ-IX = VL-LIQ-IX - VL-DIFLIQ-IX */
                EM0901W099.VL_LIQ_IX.Value = EM0901W099.VL_LIQ_IX - FILLER_28.VL_DIFLIQ_IX;

                /*" -3284- COMPUTE VL-ADIC-IX = VL-ADIC-IX - VL-DIFADI-IX */
                EM0901W099.VL_ADIC_IX.Value = EM0901W099.VL_ADIC_IX - FILLER_28.VL_DIFADI_IX;

                /*" -3286- COMPUTE VL-CUSTO-IX = VL-CUSTO-IX - VL-DIFCUS-IX */
                EM0901W099.VL_CUSTO_IX.Value = EM0901W099.VL_CUSTO_IX - FILLER_28.VL_DIFCUS_IX;

                /*" -3288- COMPUTE VL-IOF-IX = VL-IOF-IX - VL-DIFIOC-IX */
                EM0901W099.VL_IOF_IX.Value = EM0901W099.VL_IOF_IX - FILLER_28.VL_DIFIOC_IX;

                /*" -3290- COMPUTE VL-TOTAL-IX = VL-TOTAL-IX - VL-DIFTOT-IX */
                EM0901W099.VL_TOTAL_IX.Value = EM0901W099.VL_TOTAL_IX - FILLER_28.VL_DIFTOT_IX;

                /*" -3292- COMPUTE VL-TARIFA = VL-TARIFA - VL-DIFTAR */
                EM0901W099.VL_TARIFA.Value = EM0901W099.VL_TARIFA - FILLER_28.VL_DIFTAR;

                /*" -3294- COMPUTE VL-DESCONTO = VL-DESCONTO - VL-DIFDESC */
                EM0901W099.VL_DESCONTO.Value = EM0901W099.VL_DESCONTO - FILLER_28.VL_DIFDESC;

                /*" -3296- COMPUTE VL-LIQUIDO = VL-LIQUIDO - VL-DIFLIQ */
                EM0901W099.VL_LIQUIDO.Value = EM0901W099.VL_LIQUIDO - FILLER_28.VL_DIFLIQ;

                /*" -3298- COMPUTE VL-ADICIONAL = VL-ADICIONAL - VL-DIFADI */
                EM0901W099.VL_ADICIONAL.Value = EM0901W099.VL_ADICIONAL - FILLER_28.VL_DIFADI;

                /*" -3300- COMPUTE VL-CUSTO = VL-CUSTO - VL-DIFCUS */
                EM0901W099.VL_CUSTO.Value = EM0901W099.VL_CUSTO - FILLER_28.VL_DIFCUS;

                /*" -3302- COMPUTE VL-IOF = VL-IOF - VL-DIFIOC */
                EM0901W099.VL_IOF.Value = EM0901W099.VL_IOF - FILLER_28.VL_DIFIOC;

                /*" -3304- COMPUTE VL-TOTAL = VL-TOTAL - VL-DIFTOT */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_TOTAL - FILLER_28.VL_DIFTOT;

                /*" -3305- IF W-PARCEL EQUAL ENDO-QTPARCEL */

                if (W_PARCEL == ENDO_QTPARCEL)
                {

                    /*" -3319- MOVE ZEROS TO VL-DIFTAR VL-DIFDESC VL-DIFLIQ VL-DIFADI VL-DIFCUS VL-DIFIOC VL-DIFTOT VL-DIFTAR-IX VL-DIFDESC-IX VL-DIFLIQ-IX VL-DIFADI-IX VL-DIFCUS-IX VL-DIFIOC-IX VL-DIFTOT-IX. */
                    _.Move(0, FILLER_28.VL_DIFTAR, FILLER_28.VL_DIFDESC, FILLER_28.VL_DIFLIQ, FILLER_28.VL_DIFADI, FILLER_28.VL_DIFCUS, FILLER_28.VL_DIFIOC, FILLER_28.VL_DIFTOT, FILLER_28.VL_DIFTAR_IX, FILLER_28.VL_DIFDESC_IX, FILLER_28.VL_DIFLIQ_IX, FILLER_28.VL_DIFADI_IX, FILLER_28.VL_DIFCUS_IX, FILLER_28.VL_DIFIOC_IX, FILLER_28.VL_DIFTOT_IX);
                }

            }


            /*" -3320- PERFORM B2002-CONTINUA. */

            B2002_CONTINUA(true);

        }

        [StopWatch]
        /*" B2000-CONTINUA-DB-SELECT-2 */
        public void B2000_CONTINUA_DB_SELECT_2()
        {
            /*" -3203- EXEC SQL SELECT VAL_FATURA, VLIOCC INTO :FATU-VLPRMTOT, :FATU-VLIOCC FROM SEGUROS.V0FATURASFIL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS WITH UR END-EXEC. */

            var b2000_CONTINUA_DB_SELECT_2_Query1 = new B2000_CONTINUA_DB_SELECT_2_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2000_CONTINUA_DB_SELECT_2_Query1.Execute(b2000_CONTINUA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATU_VLPRMTOT, FATU_VLPRMTOT);
                _.Move(executed_1.FATU_VLIOCC, FATU_VLIOCC);
            }


        }

        [StopWatch]
        /*" B2002-CONTINUA */
        private void B2002_CONTINUA(bool isPerform = false)
        {
            /*" -3331- IF ((ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND (ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -3333- IF W-PARCEL LESS 2 AND ENDO-QTPARCEL GREATER 1 */

                if (W_PARCEL < 2 && ENDO_QTPARCEL > 1)
                {

                    /*" -3336- PERFORM B2600-00-AJUSTA-ULTIMA. */

                    B2600_00_AJUSTA_ULTIMA_SECTION();
                }

            }


            /*" -3337- MOVE ENDO-NUM-APOLICE TO PARC-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, PARC_NUM_APOLICE);

            /*" -3338- MOVE ENDO-NRENDOS TO PARC-NRENDOS. */
            _.Move(ENDO_NRENDOS, PARC_NRENDOS);

            /*" -3339- MOVE '0' TO PARC-DACPARC. */
            _.Move("0", PARC_DACPARC);

            /*" -3340- MOVE W-PARCEL TO PARC-NRPARCEL. */
            _.Move(W_PARCEL, PARC_NRPARCEL);

            /*" -3341- MOVE ENDO-FONTE TO PARC-FONTE. */
            _.Move(ENDO_FONTE, PARC_FONTE);

            /*" -3342- MOVE VL-TARIFARIO-IX TO PARC-TARIFARIO-IX. */
            _.Move(EM0901W099.VL_TARIFARIO_IX, PARC_TARIFARIO_IX);

            /*" -3343- MOVE VL-DESC-IX TO PARC-DESCONTO-IX. */
            _.Move(EM0901W099.VL_DESC_IX, PARC_DESCONTO_IX);

            /*" -3344- MOVE VL-LIQ-IX TO PARC-OTNPRLIQ. */
            _.Move(EM0901W099.VL_LIQ_IX, PARC_OTNPRLIQ);

            /*" -3345- MOVE VL-IOF-IX TO PARC-OTNIOF. */
            _.Move(EM0901W099.VL_IOF_IX, PARC_OTNIOF);

            /*" -3346- MOVE VL-ADIC-IX TO PARC-OTNADFRA. */
            _.Move(EM0901W099.VL_ADIC_IX, PARC_OTNADFRA);

            /*" -3347- MOVE VL-CUSTO-IX TO PARC-OTNCUSTO. */
            _.Move(EM0901W099.VL_CUSTO_IX, PARC_OTNCUSTO);

            /*" -3350- MOVE VL-TOTAL-IX TO PARC-OTNTOTAL. */
            _.Move(EM0901W099.VL_TOTAL_IX, PARC_OTNTOTAL);

            /*" -3367- IF ((ENDO-NRRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) OR ((ENDO-NUMBIL NOT EQUAL ZEROS) AND (ENDO-CODPRODU NOT EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) OR ((ENDO-CODPRODU EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (ENDO-AGERCAP EQUAL 9000) AND (W-PARCEL EQUAL 0 OR 1)) OR ((ENDO-CODPRODU EQUAL 83) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NRRCAP > 0) && (W_PARCEL.In("0", "1"))) || ((ENDO_NUMBIL != 00) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 0) && (ENDO_AGERCAP == 9000) && (W_PARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3368- MOVE 2 TO PARC-OCORHIST */
                _.Move(2, PARC_OCORHIST);

                /*" -3369- MOVE '1' TO PARC-SITUACAO */
                _.Move("1", PARC_SITUACAO);

                /*" -3370- ELSE */
            }
            else
            {


                /*" -3371- MOVE 1 TO PARC-OCORHIST */
                _.Move(1, PARC_OCORHIST);

                /*" -3375- MOVE '0' TO PARC-SITUACAO. */
                _.Move("0", PARC_SITUACAO);
            }


            /*" -3376- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

            if (ENDO_TIPO_ENDOSSO == "4")
            {

                /*" -3382- MOVE '1' TO PARC-SITUACAO. */
                _.Move("1", PARC_SITUACAO);
            }


            /*" -3385- IF (ENDO-CODPRODU EQUAL 1803 OR 1805) AND ENDO-TIPO-ENDOSSO EQUAL '5' AND VL-TOTAL EQUAL 0 */

            if ((ENDO_CODPRODU.In("1803", "1805")) && ENDO_TIPO_ENDOSSO == "5" && EM0901W099.VL_TOTAL == 0)
            {

                /*" -3386- IF W-PARCEL EQUAL 0 OR 1 */

                if (W_PARCEL.In("0", "1"))
                {

                    /*" -3391- MOVE '1' TO PARC-SITUACAO. */
                    _.Move("1", PARC_SITUACAO);
                }

            }


            /*" -3403- MOVE ZEROS TO W-NUMR-TITULO. */
            _.Move(0, W_NUMR_TITULO);

            /*" -3408- IF (( ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND ( ENDO-ORGAO EQUAL 10 ) AND ( ENDO-RAMO EQUAL 53 ) AND ( ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 ) AND ( ENDO-BCOCOBR EQUAL 104 )) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304")) && (ENDO_BCOCOBR == 104)))
            {

                /*" -3409- PERFORM B2018-RECUPERA-AU084 */

                B2018_RECUPERA_AU084_SECTION();

                /*" -3413- IF ((AU084-IND-FORMA-PAGTO-AD EQUAL '0' AND W-PARCEL LESS 2) OR (PRCB-TIPO-COBRANCA EQUAL ' ' OR '0' )) */

                if (((AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD == "0" && W_PARCEL < 2) || (PRCB_TIPO_COBRANCA.In(" ", "0"))))
                {

                    /*" -3414- PERFORM R6100-NOVO-TITULO-CEF */

                    R6100_NOVO_TITULO_CEF_SECTION();

                    /*" -3415- ELSE */
                }
                else
                {


                    /*" -3416- MOVE ZEROS TO W-NUMR-TITULO */
                    _.Move(0, W_NUMR_TITULO);

                    /*" -3417- ELSE */
                }

            }
            else
            {


                /*" -3419- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -3420- IF ENDO-BCOCOBR EQUAL 104 */

                    if (ENDO_BCOCOBR == 104)
                    {

                        /*" -3421- IF ENDO-ORGAO NOT EQUAL 100 */

                        if (ENDO_ORGAO != 100)
                        {

                            /*" -3423- PERFORM R6100-NOVO-TITULO-CEF. */

                            R6100_NOVO_TITULO_CEF_SECTION();
                        }

                    }

                }

            }


            /*" -3424- MOVE W-NUMR-TITULO TO PARC-NRTIT. */
            _.Move(W_NUMR_TITULO, PARC_NRTIT);

            /*" -3425- MOVE ZEROS TO PARC-QTDDOC. */
            _.Move(0, PARC_QTDDOC);

            /*" -3427- MOVE -1 TO PARC-EMPRESA-I. */
            _.Move(-1, PARC_EMPRESA_I);

            /*" -3429- IF PRCB-TIPO-COBRANCA NOT EQUAL ' ' AND PRCB-TIPO-COBRANCA NOT EQUAL '0' */

            if (PRCB_TIPO_COBRANCA != " " && PRCB_TIPO_COBRANCA != "0")
            {

                /*" -3430- MOVE SPACES TO PARC-SIT-COBRANCA */
                _.Move("", PARC_SIT_COBRANCA);

                /*" -3431- MOVE ZEROS TO PARC-COBRANCA-I */
                _.Move(0, PARC_COBRANCA_I);

                /*" -3432- ELSE */
            }
            else
            {


                /*" -3434- MOVE -1 TO PARC-COBRANCA-I. */
                _.Move(-1, PARC_COBRANCA_I);
            }


            /*" -3436- MOVE 'B2000' TO WNR-EXEC-SQL. */
            _.Move("B2000", WABEND.WNR_EXEC_SQL);

            /*" -3437- IF PARC-TARIFARIO-IX < 0 */

            if (PARC_TARIFARIO_IX < 0)
            {

                /*" -3439- COMPUTE PARC-TARIFARIO-IX = PARC-TARIFARIO-IX * -1. */
                PARC_TARIFARIO_IX.Value = PARC_TARIFARIO_IX * -1;
            }


            /*" -3440- IF PARC-DESCONTO-IX < 0 */

            if (PARC_DESCONTO_IX < 0)
            {

                /*" -3442- COMPUTE PARC-DESCONTO-IX = PARC-DESCONTO-IX * -1. */
                PARC_DESCONTO_IX.Value = PARC_DESCONTO_IX * -1;
            }


            /*" -3443- IF PARC-OTNPRLIQ < 0 */

            if (PARC_OTNPRLIQ < 0)
            {

                /*" -3445- COMPUTE PARC-OTNPRLIQ = PARC-OTNPRLIQ * -1. */
                PARC_OTNPRLIQ.Value = PARC_OTNPRLIQ * -1;
            }


            /*" -3446- IF PARC-OTNADFRA < 0 */

            if (PARC_OTNADFRA < 0)
            {

                /*" -3448- COMPUTE PARC-OTNADFRA = PARC-OTNADFRA * -1. */
                PARC_OTNADFRA.Value = PARC_OTNADFRA * -1;
            }


            /*" -3449- IF PARC-OTNCUSTO < 0 */

            if (PARC_OTNCUSTO < 0)
            {

                /*" -3451- COMPUTE PARC-OTNCUSTO = PARC-OTNCUSTO * -1. */
                PARC_OTNCUSTO.Value = PARC_OTNCUSTO * -1;
            }


            /*" -3452- IF PARC-OTNIOF < 0 */

            if (PARC_OTNIOF < 0)
            {

                /*" -3454- COMPUTE PARC-OTNIOF = PARC-OTNIOF * -1. */
                PARC_OTNIOF.Value = PARC_OTNIOF * -1;
            }


            /*" -3455- IF PARC-OTNTOTAL < 0 */

            if (PARC_OTNTOTAL < 0)
            {

                /*" -3457- COMPUTE PARC-OTNTOTAL = PARC-OTNTOTAL * -1. */
                PARC_OTNTOTAL.Value = PARC_OTNTOTAL * -1;
            }


            /*" -3458- IF WS-VL-IOF-IGUAIS = 'S' */

            if (WS_VL_IOF_IGUAIS == "S")
            {

                /*" -3459- PERFORM B2005-TRATAR-VALORES */

                B2005_TRATAR_VALORES_SECTION();

                /*" -3475- END-IF. */
            }


            /*" -3478- IF ENDO-NUM-APOLICE EQUAL 0106800000024 OR 0106100000011 AND ENDO-TIPO-ENDOSSO EQUAL '1' */

            if (ENDO_NUM_APOLICE.In("0106800000024", "0106100000011") && ENDO_TIPO_ENDOSSO == "1")
            {

                /*" -3480- PERFORM R8000-HABIT-BANCO-LUSO */

                R8000_HABIT_BANCO_LUSO_SECTION();

                /*" -3481- MOVE 0 TO PARC-TARIFARIO-IX */
                _.Move(0, PARC_TARIFARIO_IX);

                /*" -3482- MOVE 0 TO PARC-DESCONTO-IX */
                _.Move(0, PARC_DESCONTO_IX);

                /*" -3483- MOVE 0 TO PARC-OTNPRLIQ */
                _.Move(0, PARC_OTNPRLIQ);

                /*" -3484- MOVE 0 TO PARC-OTNADFRA */
                _.Move(0, PARC_OTNADFRA);

                /*" -3485- MOVE 0 TO PARC-OTNCUSTO */
                _.Move(0, PARC_OTNCUSTO);

                /*" -3486- MOVE 0 TO PARC-OTNIOF */
                _.Move(0, PARC_OTNIOF);

                /*" -3488- MOVE 0 TO PARC-OTNTOTAL */
                _.Move(0, PARC_OTNTOTAL);

                /*" -3490- MOVE W-VALOR-PREMIO TO PARC-TARIFARIO-IX PARC-OTNPRLIQ */
                _.Move(W_VALOR_PREMIO, PARC_TARIFARIO_IX, PARC_OTNPRLIQ);

                /*" -3491- MOVE W-VALOR-IOF TO PARC-OTNIOF */
                _.Move(W_VALOR_IOF, PARC_OTNIOF);

                /*" -3492- MOVE W-VALOR-TOTAL-PREMIO TO PARC-OTNTOTAL */
                _.Move(W_VALOR_TOTAL_PREMIO, PARC_OTNTOTAL);

                /*" -3495- END-IF. */
            }


            /*" -3496- DISPLAY ' ' */
            _.Display($" ");

            /*" -3497- DISPLAY 'EM0030B - INSERT V0PARCELA --------------' */
            _.Display($"EM0030B - INSERT V0PARCELA --------------");

            /*" -3498- DISPLAY ' ' */
            _.Display($" ");

            /*" -3499- DISPLAY 'PARC-NUM-APOLICE = ' PARC-NUM-APOLICE */
            _.Display($"PARC-NUM-APOLICE = {PARC_NUM_APOLICE}");

            /*" -3500- DISPLAY 'PARC-NRENDOS     = ' PARC-NRENDOS */
            _.Display($"PARC-NRENDOS     = {PARC_NRENDOS}");

            /*" -3501- DISPLAY 'PARC-NRPARCEL    = ' PARC-NRPARCEL */
            _.Display($"PARC-NRPARCEL    = {PARC_NRPARCEL}");

            /*" -3502- DISPLAY 'PARC-NRTIT       = ' PARC-NRTIT */
            _.Display($"PARC-NRTIT       = {PARC_NRTIT}");

            /*" -3504- DISPLAY 'PARC-SITUACAO    = ' PARC-SITUACAO */
            _.Display($"PARC-SITUACAO    = {PARC_SITUACAO}");

            /*" -3505- MOVE PARC-TARIFARIO-IX TO W-EDICAO1 */
            _.Move(PARC_TARIFARIO_IX, W_EDICAO1);

            /*" -3506- DISPLAY 'PARC-TARIFARIO-IX = ' W-EDICAO1 */
            _.Display($"PARC-TARIFARIO-IX = {W_EDICAO1}");

            /*" -3507- MOVE PARC-DESCONTO-IX TO W-EDICAO1 */
            _.Move(PARC_DESCONTO_IX, W_EDICAO1);

            /*" -3508- DISPLAY 'PARC-DESCONTO-IX  = ' W-EDICAO1 */
            _.Display($"PARC-DESCONTO-IX  = {W_EDICAO1}");

            /*" -3509- MOVE PARC-OTNPRLIQ TO W-EDICAO1 */
            _.Move(PARC_OTNPRLIQ, W_EDICAO1);

            /*" -3510- DISPLAY 'PARC-OTNPRLIQ     = ' W-EDICAO1 */
            _.Display($"PARC-OTNPRLIQ     = {W_EDICAO1}");

            /*" -3511- MOVE PARC-OTNADFRA TO W-EDICAO1 */
            _.Move(PARC_OTNADFRA, W_EDICAO1);

            /*" -3512- DISPLAY 'PARC-OTNADFRA     = ' W-EDICAO1 */
            _.Display($"PARC-OTNADFRA     = {W_EDICAO1}");

            /*" -3513- MOVE PARC-OTNCUSTO TO W-EDICAO1 */
            _.Move(PARC_OTNCUSTO, W_EDICAO1);

            /*" -3514- DISPLAY 'PARC-OTNCUSTO     = ' W-EDICAO1 */
            _.Display($"PARC-OTNCUSTO     = {W_EDICAO1}");

            /*" -3515- MOVE PARC-OTNIOF TO W-EDICAO1 */
            _.Move(PARC_OTNIOF, W_EDICAO1);

            /*" -3516- DISPLAY 'PARC-OTNIOF       = ' W-EDICAO1 */
            _.Display($"PARC-OTNIOF       = {W_EDICAO1}");

            /*" -3517- MOVE PARC-OTNTOTAL TO W-EDICAO1 */
            _.Move(PARC_OTNTOTAL, W_EDICAO1);

            /*" -3519- DISPLAY 'PARC-OTNTOTAL     = ' W-EDICAO1 . */
            _.Display($"PARC-OTNTOTAL     = {W_EDICAO1}");

            /*" -3560- PERFORM B2002_CONTINUA_DB_INSERT_1 */

            B2002_CONTINUA_DB_INSERT_1();

            /*" -3563- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3564- DISPLAY 'EM0030B - ERRO INSERT V0PARCELA --------------' */
                _.Display($"EM0030B - ERRO INSERT V0PARCELA --------------");

                /*" -3565- MOVE SQLCODE TO W-EDICAO1 */
                _.Move(DB.SQLCODE, W_EDICAO1);

                /*" -3566- DISPLAY '  =>>>>>>  SQLCODE = ' W-EDICAO1 */
                _.Display($"  =>>>>>>  SQLCODE = {W_EDICAO1}");

                /*" -3567- DISPLAY 'PARC-NUM-APOLICE = ' PARC-NUM-APOLICE */
                _.Display($"PARC-NUM-APOLICE = {PARC_NUM_APOLICE}");

                /*" -3568- DISPLAY 'PARC-NRENDOS     = ' PARC-NRENDOS */
                _.Display($"PARC-NRENDOS     = {PARC_NRENDOS}");

                /*" -3569- DISPLAY 'PARC-NRPARCEL    = ' PARC-NRPARCEL */
                _.Display($"PARC-NRPARCEL    = {PARC_NRPARCEL}");

                /*" -3570- DISPLAY 'PARC-DACPARC     = ' PARC-DACPARC */
                _.Display($"PARC-DACPARC     = {PARC_DACPARC}");

                /*" -3571- DISPLAY 'PARC-FONTE       = ' PARC-FONTE */
                _.Display($"PARC-FONTE       = {PARC_FONTE}");

                /*" -3572- DISPLAY 'PARC-NRTIT       = ' PARC-NRTIT */
                _.Display($"PARC-NRTIT       = {PARC_NRTIT}");

                /*" -3573- DISPLAY 'PARC-TARIFARIO-IX= ' PARC-TARIFARIO-IX */
                _.Display($"PARC-TARIFARIO-IX= {PARC_TARIFARIO_IX}");

                /*" -3574- DISPLAY 'PARC-DESCONTO-IX = ' PARC-DESCONTO-IX */
                _.Display($"PARC-DESCONTO-IX = {PARC_DESCONTO_IX}");

                /*" -3575- DISPLAY 'PARC-OTNPRLIQ    = ' PARC-OTNPRLIQ */
                _.Display($"PARC-OTNPRLIQ    = {PARC_OTNPRLIQ}");

                /*" -3576- DISPLAY 'PARC-OTNADFRA    = ' PARC-OTNADFRA */
                _.Display($"PARC-OTNADFRA    = {PARC_OTNADFRA}");

                /*" -3577- DISPLAY 'PARC-OTNCUSTO    = ' PARC-OTNCUSTO */
                _.Display($"PARC-OTNCUSTO    = {PARC_OTNCUSTO}");

                /*" -3578- DISPLAY 'PARC-OTNIOF      = ' PARC-OTNIOF */
                _.Display($"PARC-OTNIOF      = {PARC_OTNIOF}");

                /*" -3579- DISPLAY 'PARC-OTNTOTAL    = ' PARC-OTNTOTAL */
                _.Display($"PARC-OTNTOTAL    = {PARC_OTNTOTAL}");

                /*" -3580- DISPLAY 'PARC-OCORHIST    = ' PARC-OCORHIST */
                _.Display($"PARC-OCORHIST    = {PARC_OCORHIST}");

                /*" -3581- DISPLAY 'PARC-QTDDOC      = ' PARC-QTDDOC */
                _.Display($"PARC-QTDDOC      = {PARC_QTDDOC}");

                /*" -3582- DISPLAY 'PARC-SITUACAO    = ' PARC-SITUACAO */
                _.Display($"PARC-SITUACAO    = {PARC_SITUACAO}");

                /*" -3583- DISPLAY 'PARC-COD-EMPRESA = ' PARC-COD-EMPRESA */
                _.Display($"PARC-COD-EMPRESA = {PARC_COD_EMPRESA}");

                /*" -3584- DISPLAY 'PARC-SIT-COBRANCA= ' PARC-SIT-COBRANCA */
                _.Display($"PARC-SIT-COBRANCA= {PARC_SIT_COBRANCA}");

                /*" -3585- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -3587- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3589- ADD 1 TO AC-I-V0PARCELA. */
            AC_I_V0PARCELA.Value = AC_I_V0PARCELA + 1;

            /*" -3590- MOVE 0101 TO HIST-OPERACAO. */
            _.Move(0101, HIST_OPERACAO);

            /*" -3591- MOVE 1 TO HIST-OCORHIST. */
            _.Move(1, HIST_OCORHIST);

            /*" -3592- MOVE VL-TARIFA TO HIST-PRM-TARIFARIO. */
            _.Move(EM0901W099.VL_TARIFA, HIST_PRM_TARIFARIO);

            /*" -3593- MOVE VL-DESCONTO TO HIST-VAL-DESCONTO. */
            _.Move(EM0901W099.VL_DESCONTO, HIST_VAL_DESCONTO);

            /*" -3594- MOVE VL-LIQUIDO TO HIST-VLPRMLIQ. */
            _.Move(EM0901W099.VL_LIQUIDO, HIST_VLPRMLIQ);

            /*" -3595- MOVE VL-ADICIONAL TO HIST-VLADIFRA. */
            _.Move(EM0901W099.VL_ADICIONAL, HIST_VLADIFRA);

            /*" -3596- MOVE VL-CUSTO TO HIST-VLCUSEMI. */
            _.Move(EM0901W099.VL_CUSTO, HIST_VLCUSEMI);

            /*" -3597- MOVE VL-IOF TO HIST-VLIOCC. */
            _.Move(EM0901W099.VL_IOF, HIST_VLIOCC);

            /*" -3598- MOVE VL-TOTAL TO HIST-VLPRMTOT. */
            _.Move(EM0901W099.VL_TOTAL, HIST_VLPRMTOT);

            /*" -3600- MOVE VL-TOTAL TO HIST-VLPREMIO. */
            _.Move(EM0901W099.VL_TOTAL, HIST_VLPREMIO);

            /*" -3601- MOVE ZEROS TO HIST-NRAVISO. */
            _.Move(0, HIST_NRAVISO);

            /*" -3602- MOVE ENDO-AGECOBR TO HIST-AGECOBR. */
            _.Move(ENDO_AGECOBR, HIST_AGECOBR);

            /*" -3606- MOVE -1 TO HIST-DTQITBCO-I. */
            _.Move(-1, HIST_DTQITBCO_I);

            /*" -3608- IF ENDO-RAMO = ( 68 OR 48 OR 70 OR 61 OR 65 ) */

            if (ENDO_RAMO.In("68", "48", "70", "61", "65"))
            {

                /*" -3609- IF WCH-APOL-HABIT EQUAL 'S' */

                if (WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT == "S")
                {

                    /*" -3610- MOVE WS000-IOF-RAMO68 TO HIST-VLIOCC */
                    _.Move(WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68, HIST_VLIOCC);

                    /*" -3614- COMPUTE HIST-VLPRMTOT = HIST-VLPRMLIQ + HIST-VLADIFRA + HIST-VLCUSEMI + HIST-VLIOCC */
                    HIST_VLPRMTOT.Value = HIST_VLPRMLIQ + HIST_VLADIFRA + HIST_VLCUSEMI + HIST_VLIOCC;

                    /*" -3623- MOVE HIST-VLPRMTOT TO HIST-VLPREMIO. */
                    _.Move(HIST_VLPRMTOT, HIST_VLPREMIO);
                }

            }


            /*" -3627- IF ((ENDO-CODPRODU EQUAL 4005 OR 6701 OR 7501) AND (ENDO-VLRCAP GREATER ZEROS) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU.In("4005", "6701", "7501")) && (ENDO_VLRCAP > 00) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3628- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3629- MOVE 'MOV11-DTVENCTO      ' TO WS-MOV-DTVENCTO */
                _.Move("MOV11-DTVENCTO      ", WS_MOV_DTVENCTO);

                /*" -3631- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3640- IF (ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-SAUDE OR PARM-RAMO-PRESTA) AND (ENDO-CODPRODU EQUAL ZEROS) */

            if ((ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_SAUDE.ToString(), PARM_RAMO_PRESTA.ToString())) && (ENDO_CODPRODU == 00))
            {

                /*" -3641- IF VIND-DTVENCTO EQUAL -1 */

                if (VIND_DTVENCTO == -1)
                {

                    /*" -3642- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                    /*" -3643- MOVE W-DIA TO W-DD */
                    _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

                    /*" -3644- MOVE W-MES TO W-MM */
                    _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

                    /*" -3645- MOVE W-ANO TO W-AA */
                    _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

                    /*" -3646- MOVE W-DATA TO PROSOM-DATA01 */
                    _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

                    /*" -3647- MOVE 30 TO PROSOM-QTDIA */
                    _.Move(30, PROSOMW099.PROSOM_QTDIA);

                    /*" -3648- MOVE ZEROS TO PROSOM-DATA02 */
                    _.Move(0, PROSOMW099.PROSOM_DATA02);

                    /*" -3649- CALL 'PROSOCU1' USING PROSOMW099 */
                    _.Call("PROSOCU1", PROSOMW099);

                    /*" -3650- MOVE PROSOM-DATA02 TO W-DATA */
                    _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

                    /*" -3651- MOVE W-DD TO W-DIA */
                    _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

                    /*" -3652- MOVE W-MM TO W-MES */
                    _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

                    /*" -3653- MOVE W-AA TO W-ANO */
                    _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

                    /*" -3654- MOVE W-DATA-EDITADA TO HIST-DTVENCTO */
                    _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

                    /*" -3655- MOVE 'MOV10-DTVENCTO  ' TO WS-MOV-DTVENCTO */
                    _.Move("MOV10-DTVENCTO  ", WS_MOV_DTVENCTO);

                    /*" -3656- GO TO B2000-GRAVA */

                    B2000_GRAVA(); //GOTO
                    return;

                    /*" -3657- ELSE */
                }
                else
                {


                    /*" -3658- MOVE ENDO-DTVENCTO TO HIST-DTVENCTO */
                    _.Move(ENDO_DTVENCTO, HIST_DTVENCTO);

                    /*" -3659- MOVE 'MOV9-DTVENCTO   ' TO WS-MOV-DTVENCTO */
                    _.Move("MOV9-DTVENCTO   ", WS_MOV_DTVENCTO);

                    /*" -3661- GO TO B2000-GRAVA. */

                    B2000_GRAVA(); //GOTO
                    return;
                }

            }


            /*" -3663- IF (ENDO-RAMO EQUAL 33 OR 34 OR 35) AND (W-PARCEL EQUAL 0 OR 1) */

            if ((ENDO_RAMO.In("33", "34", "35")) && (W_PARCEL.In("0", "1")))
            {

                /*" -3664- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3665- MOVE 'MOV8-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV8-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3667- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3681- IF (ENDO-NUM-APOLICE EQUAL 106800000012 OR EQUAL 106000000003 OR EQUAL 106000000004 OR EQUAL 107700000015 OR EQUAL 107700000016 OR EQUAL 104800000052 OR EQUAL 104800000053 OR EQUAL 104800000054 OR EQUAL 104800000055 OR EQUAL 104800000058 OR EQUAL 101402541676) AND (ENDO-TIPO-ENDOSSO = '1' ) */

            if ((ENDO_NUM_APOLICE.In("106800000012", "106000000003", "106000000004", "107700000015", "107700000016", "104800000052", "104800000053", "104800000054", "104800000055", "104800000058", "101402541676")) && (ENDO_TIPO_ENDOSSO == "1"))
            {

                /*" -3682- MOVE ENDO-DTVENCTO TO HIST-DTVENCTO */
                _.Move(ENDO_DTVENCTO, HIST_DTVENCTO);

                /*" -3683- MOVE 'MOV7-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV7-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3685- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3690- IF ((ENDO-NUMBIL GREATER ZEROS) AND (ENDO-CODPRODU NOT EQUAL 32) AND (ENDO-VLRCAP GREATER ZEROS) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NUMBIL > 00) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 00) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3691- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3692- MOVE 'MOV6-DTVENCTO    ' TO WS-MOV-DTVENCTO */
                _.Move("MOV6-DTVENCTO    ", WS_MOV_DTVENCTO);

                /*" -3694- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3699- IF ((ENDO-CODPRODU EQUAL 32) AND (ENDO-VLRCAP GREATER ZEROS) AND (ENDO-AGERCAP EQUAL 9000) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 00) && (ENDO_AGERCAP == 9000) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3700- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3701- MOVE 'MOV5-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV5-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3703- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3707- IF (ENDO-CODPRODU EQUAL 83) AND (ENDO-VLRCAP GREATER ZEROS) AND (W-PARCEL EQUAL 0 OR 1) */

            if ((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 00) && (W_PARCEL.In("0", "1")))
            {

                /*" -3708- MOVE ENDO-DATARCAP TO HIST-DTVENCTO */
                _.Move(ENDO_DATARCAP, HIST_DTVENCTO);

                /*" -3709- MOVE 'MOV4-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV4-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3711- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3715- IF ((ENDO-AGERCAP EQUAL 9000) AND (ENDO-NRRCAP EQUAL ZEROS) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_AGERCAP == 9000) && (ENDO_NRRCAP == 00) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3716- MOVE SIST-DTMOVABE TO HIST-DTVENCTO */
                _.Move(SIST_DTMOVABE, HIST_DTVENCTO);

                /*" -3717- MOVE 'MOV3-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV3-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3721- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3723- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -3724- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -3725- PERFORM B2050-VENCTO-AUTO-FACIL */

                    B2050_VENCTO_AUTO_FACIL_SECTION();

                    /*" -3726- ELSE */
                }
                else
                {


                    /*" -3727- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                    /*" -3729- END-IF */
                }


                /*" -3730- MOVE W-DATA-EDITADA TO HIST-DTVENCTO */
                _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

                /*" -3731- MOVE 'MOV2-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV2-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3732- GO TO B2000-GRAVA */

                B2000_GRAVA(); //GOTO
                return;

                /*" -3733- ELSE */
            }
            else
            {


                /*" -3735- IF (ENDO-NRRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1) */

                if ((ENDO_NRRCAP > 0) && (W_PARCEL.In("0", "1")))
                {

                    /*" -3736- MOVE ENDO-DATARCAP TO HIST-DTVENCTO */
                    _.Move(ENDO_DATARCAP, HIST_DTVENCTO);

                    /*" -3737- MOVE 'MOV1-DTVENCTO   ' TO WS-MOV-DTVENCTO */
                    _.Move("MOV1-DTVENCTO   ", WS_MOV_DTVENCTO);

                    /*" -3738- MOVE ENDO-DATARCAP TO W-DATA-EDITADA */
                    _.Move(ENDO_DATARCAP, W_DATA_EDITADA);

                    /*" -3760- GO TO B2000-GRAVA. */

                    B2000_GRAVA(); //GOTO
                    return;
                }

            }


            /*" -3762- PERFORM B2010-CALCULA-VENCIMENTO. */

            B2010_CALCULA_VENCIMENTO_SECTION();

            /*" -3762- PERFORM B2000-GRAVA. */

            B2000_GRAVA(true);

        }

        [StopWatch]
        /*" B2002-CONTINUA-DB-INSERT-1 */
        public void B2002_CONTINUA_DB_INSERT_1()
        {
            /*" -3560- EXEC SQL INSERT INTO SEGUROS.V0PARCELA ( NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , FONTE , NRTIT , PRM_TARIFARIO_IX , VAL_DESCONTO_IX , OTNPRLIQ , OTNADFRA , OTNCUSTO , OTNIOF , OTNTOTAL , OCORHIST , QTDDOC , SITUACAO , COD_EMPRESA , TIMESTAMP , SIT_COBRANCA ) VALUES (:PARC-NUM-APOLICE ,:PARC-NRENDOS ,:PARC-NRPARCEL ,:PARC-DACPARC ,:PARC-FONTE ,:PARC-NRTIT ,:PARC-TARIFARIO-IX ,:PARC-DESCONTO-IX ,:PARC-OTNPRLIQ ,:PARC-OTNADFRA ,:PARC-OTNCUSTO ,:PARC-OTNIOF ,:PARC-OTNTOTAL ,:PARC-OCORHIST ,:PARC-QTDDOC ,:PARC-SITUACAO ,:PARC-COD-EMPRESA:PARC-EMPRESA-I , CURRENT TIMESTAMP ,:PARC-SIT-COBRANCA:PARC-COBRANCA-I ) END-EXEC. */

            var b2002_CONTINUA_DB_INSERT_1_Insert1 = new B2002_CONTINUA_DB_INSERT_1_Insert1()
            {
                PARC_NUM_APOLICE = PARC_NUM_APOLICE.ToString(),
                PARC_NRENDOS = PARC_NRENDOS.ToString(),
                PARC_NRPARCEL = PARC_NRPARCEL.ToString(),
                PARC_DACPARC = PARC_DACPARC.ToString(),
                PARC_FONTE = PARC_FONTE.ToString(),
                PARC_NRTIT = PARC_NRTIT.ToString(),
                PARC_TARIFARIO_IX = PARC_TARIFARIO_IX.ToString(),
                PARC_DESCONTO_IX = PARC_DESCONTO_IX.ToString(),
                PARC_OTNPRLIQ = PARC_OTNPRLIQ.ToString(),
                PARC_OTNADFRA = PARC_OTNADFRA.ToString(),
                PARC_OTNCUSTO = PARC_OTNCUSTO.ToString(),
                PARC_OTNIOF = PARC_OTNIOF.ToString(),
                PARC_OTNTOTAL = PARC_OTNTOTAL.ToString(),
                PARC_OCORHIST = PARC_OCORHIST.ToString(),
                PARC_QTDDOC = PARC_QTDDOC.ToString(),
                PARC_SITUACAO = PARC_SITUACAO.ToString(),
                PARC_COD_EMPRESA = PARC_COD_EMPRESA.ToString(),
                PARC_EMPRESA_I = PARC_EMPRESA_I.ToString(),
                PARC_SIT_COBRANCA = PARC_SIT_COBRANCA.ToString(),
                PARC_COBRANCA_I = PARC_COBRANCA_I.ToString(),
            };

            B2002_CONTINUA_DB_INSERT_1_Insert1.Execute(b2002_CONTINUA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" B2000-GRAVA */
        private void B2000_GRAVA(bool isPerform = false)
        {
            /*" -3767- PERFORM B3000-GRAVA-HISTOPARC. */

            B3000_GRAVA_HISTOPARC_SECTION();

            /*" -3768- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -3769- PERFORM R7000-00-GRAVA-PARC-COMPL */

                R7000_00_GRAVA_PARC_COMPL_SECTION();

                /*" -3780- END-IF. */
            }


            /*" -3782- MOVE SPACES TO WFIM-V1RCAPCOMP. */
            _.Move("", WFIM_V1RCAPCOMP);

            /*" -3794- PERFORM B3100-SELECT-V1RCAPCOMP. */

            B3100_SELECT_V1RCAPCOMP_SECTION();

            /*" -3797- IF ((ENDO-NRRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NRRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3798- IF WFIM-V1RCAPCOMP EQUAL SPACES */

                if (WFIM_V1RCAPCOMP.IsEmpty())
                {

                    /*" -3799- PERFORM B2100-MONTA-201 */

                    B2100_MONTA_201_SECTION();

                    /*" -3800- PERFORM B3000-GRAVA-HISTOPARC */

                    B3000_GRAVA_HISTOPARC_SECTION();

                    /*" -3801- PERFORM B2200-000-BAIXA-RCAP */

                    B2200_000_BAIXA_RCAP_SECTION();

                    /*" -3802- ELSE */
                }
                else
                {


                    /*" -3804- PERFORM B3160-ALTERA-V0PARCELA. */

                    B3160_ALTERA_V0PARCELA_SECTION();
                }

            }


            /*" -3809- IF ((ENDO-NUMBIL GREATER 0) AND (ENDO-CODPRODU NOT EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NUMBIL > 0) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3810- PERFORM B2110-MONTA-208 */

                B2110_MONTA_208_SECTION();

                /*" -3812- PERFORM B3000-GRAVA-HISTOPARC. */

                B3000_GRAVA_HISTOPARC_SECTION();
            }


            /*" -3816- IF ((ENDO-CODPRODU EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (ENDO-AGERCAP EQUAL 9000) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 0) && (ENDO_AGERCAP == 9000) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3817- PERFORM B2110-MONTA-208 */

                B2110_MONTA_208_SECTION();

                /*" -3819- PERFORM B3000-GRAVA-HISTOPARC. */

                B3000_GRAVA_HISTOPARC_SECTION();
            }


            /*" -3822- IF ((ENDO-CODPRODU EQUAL 83) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3823- PERFORM B2110-MONTA-208 */

                B2110_MONTA_208_SECTION();

                /*" -3825- PERFORM B3000-GRAVA-HISTOPARC. */

                B3000_GRAVA_HISTOPARC_SECTION();
            }


            /*" -3825- PERFORM B2000-900-SEGUE. */

            B2000_900_SEGUE(true);

        }

        [StopWatch]
        /*" B2000-900-SEGUE */
        private void B2000_900_SEGUE(bool isPerform = false)
        {
            /*" -3829- ADD 1 TO W-PARCEL. */
            W_PARCEL.Value = W_PARCEL + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2000_999_EXIT*/

        [StopWatch]
        /*" B2005-TRATAR-VALORES-SECTION */
        private void B2005_TRATAR_VALORES_SECTION()
        {
            /*" -3840- IF (ENDO-NUM-APOLICE = 106800000018 AND ENDO-CODPRODU = 6821) OR (ENDO-NUM-APOLICE = 106800000011 AND ENDO-CODPRODU = 6812) */

            if ((ENDO_NUM_APOLICE == 106800000018 && ENDO_CODPRODU == 6821) || (ENDO_NUM_APOLICE == 106800000011 && ENDO_CODPRODU == 6812))
            {

                /*" -3842- COMPUTE PARC-TARIFARIO-IX = PARC-TARIFARIO-IX - PARC-OTNIOF */
                PARC_TARIFARIO_IX.Value = PARC_TARIFARIO_IX - PARC_OTNIOF;

                /*" -3843- COMPUTE PARC-OTNPRLIQ = PARC-OTNPRLIQ - PARC-OTNIOF */
                PARC_OTNPRLIQ.Value = PARC_OTNPRLIQ - PARC_OTNIOF;

                /*" -3844- COMPUTE PARC-OTNTOTAL = PARC-OTNTOTAL - PARC-OTNIOF */
                PARC_OTNTOTAL.Value = PARC_OTNTOTAL - PARC_OTNIOF;

                /*" -3844- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2005_999_EXIT*/

        [StopWatch]
        /*" B2010-CALCULA-VENCIMENTO-SECTION */
        private void B2010_CALCULA_VENCIMENTO_SECTION()
        {
            /*" -3853- MOVE 'B2010' TO WNR-EXEC-SQL. */
            _.Move("B2010", WABEND.WNR_EXEC_SQL);

            /*" -3854- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -3855- PERFORM B2011-VENCIMENTO-1A-PARCELA */

                B2011_VENCIMENTO_1A_PARCELA_SECTION();

                /*" -3856- ELSE */
            }
            else
            {


                /*" -3857- IF W-PARCEL EQUAL 2 */

                if (W_PARCEL == 2)
                {

                    /*" -3858- PERFORM B2012-VENCIMENTO-2A-PARCELA */

                    B2012_VENCIMENTO_2A_PARCELA_SECTION();

                    /*" -3859- ELSE */
                }
                else
                {


                    /*" -3859- PERFORM B2013-VENCIMENTO-DEMAIS. */

                    B2013_VENCIMENTO_DEMAIS_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2010_999_EXIT*/

        [StopWatch]
        /*" B2011-VENCIMENTO-1A-PARCELA-SECTION */
        private void B2011_VENCIMENTO_1A_PARCELA_SECTION()
        {
            /*" -3877- MOVE 'B2011' TO WNR-EXEC-SQL. */
            _.Move("B2011", WABEND.WNR_EXEC_SQL);

            /*" -3878- IF VIND-DTVENCTO EQUAL -1 */

            if (VIND_DTVENCTO == -1)
            {

                /*" -3879- PERFORM B2014-SOMA-1-MES */

                B2014_SOMA_1_MES_SECTION();

                /*" -3880- PERFORM B2017-VERIFICA-DIA-BASE */

                B2017_VERIFICA_DIA_BASE_SECTION();

                /*" -3881- ELSE */
            }
            else
            {


                /*" -3890- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
                _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);
            }


            /*" -3893- IF (ENDO-CODPRODU = 1803 OR 1805) AND (ENDO-NRENDOS = 0) NEXT SENTENCE */

            if ((ENDO_CODPRODU.In("1803", "1805")) && (ENDO_NRENDOS == 0))
            {

                /*" -3894- ELSE */
            }
            else
            {


                /*" -3896- PERFORM B2016-VERIFICA-DATA-MINIMA. */

                B2016_VERIFICA_DATA_MINIMA_SECTION();
            }


            /*" -3897- MOVE W-DATA-EDITADA TO HIST-DTVENCTO. */
            _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

            /*" -3897- MOVE 'B2011-VENCIMENTO-1A-PARCELA' TO WS-MOV-DTVENCTO. */
            _.Move("B2011-VENCIMENTO-1A-PARCELA", WS_MOV_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2011_999_EXIT*/

        [StopWatch]
        /*" B2012-VENCIMENTO-2A-PARCELA-SECTION */
        private void B2012_VENCIMENTO_2A_PARCELA_SECTION()
        {
            /*" -3921- MOVE 'B2012' TO WNR-EXEC-SQL. */
            _.Move("B2012", WABEND.WNR_EXEC_SQL);

            /*" -3922- IF ENDO-CODPRODU = 1805 AND ENDO-NRENDOS = 0 */

            if (ENDO_CODPRODU == 1805 && ENDO_NRENDOS == 0)
            {

                /*" -3924- MOVE ENDO-CODPRODU TO LTSOLPAR-COD-PRODUTO */
                _.Move(ENDO_CODPRODU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

                /*" -3926- END-IF */
            }


            /*" -3927- IF VIND-DTVENCTO EQUAL -1 */

            if (VIND_DTVENCTO == -1)
            {

                /*" -3928- PERFORM B2014-SOMA-1-MES */

                B2014_SOMA_1_MES_SECTION();

                /*" -3929- PERFORM B2017-VERIFICA-DIA-BASE */

                B2017_VERIFICA_DIA_BASE_SECTION();

                /*" -3930- IF ENDO-NRRCAP GREATER 0 */

                if (ENDO_NRRCAP > 0)
                {

                    /*" -3931- PERFORM B2016-VERIFICA-DATA-MINIMA */

                    B2016_VERIFICA_DATA_MINIMA_SECTION();

                    /*" -3932- END-IF */
                }


                /*" -3933- ELSE */
            }
            else
            {


                /*" -3934- IF ENDO-NRRCAP GREATER 0 */

                if (ENDO_NRRCAP > 0)
                {

                    /*" -3935- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                    /*" -3936- PERFORM B2016-VERIFICA-DATA-MINIMA */

                    B2016_VERIFICA_DATA_MINIMA_SECTION();

                    /*" -3937- ELSE */
                }
                else
                {


                    /*" -3938- PERFORM B2014-SOMA-1-MES */

                    B2014_SOMA_1_MES_SECTION();

                    /*" -3944- PERFORM B2017-VERIFICA-DIA-BASE. */

                    B2017_VERIFICA_DIA_BASE_SECTION();
                }

            }


            /*" -3945- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -3946- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -3947- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -3951- MOVE W-DATA TO EM0925-DATA01 */
            _.Move(W_DATA, EM0925W099.EM0925_DATA01);

            /*" -3953- MOVE ENDO-DTTERVIG TO W-DTTERVIG */
            _.Move(ENDO_DTTERVIG, W_DTTERVIG);

            /*" -3954- IF W-DIA GREATER W-DDTERVIG */

            if (W_DATA_EDITADA.W_DIA > W_DTTERVIG.W_DDTERVIG)
            {

                /*" -3955- MOVE W-DIA TO W-DDTERVIG */
                _.Move(W_DATA_EDITADA.W_DIA, W_DTTERVIG.W_DDTERVIG);

                /*" -3956- SUBTRACT 1 FROM W-MMTERVIG */
                W_DTTERVIG.W_MMTERVIG.Value = W_DTTERVIG.W_MMTERVIG - 1;

                /*" -3957- IF W-MMTERVIG EQUAL ZEROS */

                if (W_DTTERVIG.W_MMTERVIG == 00)
                {

                    /*" -3958- MOVE 12 TO W-MMTERVIG */
                    _.Move(12, W_DTTERVIG.W_MMTERVIG);

                    /*" -3959- SUBTRACT 1 FROM W-AATERVIG */
                    W_DTTERVIG.W_AATERVIG.Value = W_DTTERVIG.W_AATERVIG - 1;

                    /*" -3960- END-IF */
                }


                /*" -3961- ELSE */
            }
            else
            {


                /*" -3963- MOVE W-DIA TO W-DDTERVIG. */
                _.Move(W_DATA_EDITADA.W_DIA, W_DTTERVIG.W_DDTERVIG);
            }


            /*" -3964- MOVE W-DDTERVIG TO W-DD */
            _.Move(W_DTTERVIG.W_DDTERVIG, W_DATA.W_DD);

            /*" -3965- MOVE W-MMTERVIG TO W-MM */
            _.Move(W_DTTERVIG.W_MMTERVIG, W_DATA.W_MM);

            /*" -3966- MOVE W-AATERVIG TO W-AA */
            _.Move(W_DTTERVIG.W_AATERVIG, W_DATA.W_AA);

            /*" -3968- MOVE W-DATA TO EM0925-DATA02 */
            _.Move(W_DATA, EM0925W099.EM0925_DATA02);

            /*" -3970- MOVE ZEROS TO EM0925-QTMES */
            _.Move(0, EM0925W099.EM0925_QTMES);

            /*" -3985- CALL 'EM0925S' USING EM0925W099 */
            _.Call("EM0925S", EM0925W099);

            /*" -3995- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -3996- MOVE ENDO-QTPARCEL TO EM0925-QTMES */
                _.Move(ENDO_QTPARCEL, EM0925W099.EM0925_QTMES);

                /*" -3998- END-IF */
            }


            /*" -4002- IF (ENDO-COD-USUARIO EQUAL 'SAS6239' AND (ENDO-CODPRODU EQUAL 1601 OR 1801) AND ENDO-COD-EMPRESA EQUAL 0) NEXT SENTENCE */

            if ((ENDO_COD_USUARIO == "SAS6239" && (ENDO_CODPRODU.In("1601", "1801")) && ENDO_COD_EMPRESA == 0))
            {

                /*" -4003- ELSE */
            }
            else
            {


                /*" -4004- IF EM0925-QTMES LESS ENDO-QTPARCEL */

                if (EM0925W099.EM0925_QTMES < ENDO_QTPARCEL)
                {

                    /*" -4011- DISPLAY 'EM0030B - QTDE DE MESES MENOR QUE DE PARCELAS' ' MESES ' EM0925-QTMES ' PARCELA ' ENDO-QTPARCEL ' APOLICE ' ENDO-NUM-APOLICE ' ENDOSSO ' ENDO-NRENDOS ' FONTE ' ENDO-FONTE ' PROPOSTA ' ENDO-NRPROPOS */

                    $"EM0030B - QTDE DE MESES MENOR QUE DE PARCELAS MESES {EM0925W099.EM0925_QTMES} PARCELA {ENDO_QTPARCEL} APOLICE {ENDO_NUM_APOLICE} ENDOSSO {ENDO_NRENDOS} FONTE {ENDO_FONTE} PROPOSTA {ENDO_NRPROPOS}"
                    .Display();

                    /*" -4012- DISPLAY '***************   ATENCAO  ****************' */
                    _.Display($"***************   ATENCAO  ****************");

                    /*" -4013- DISPLAY 'SR. OPERADOR :                             ' */
                    _.Display($"SR. OPERADOR :                             ");

                    /*" -4014- DISPLAY 'O ABEND CAUSADO NO PROGRAMA POR ESTE MOTIVO' */
                    _.Display($"O ABEND CAUSADO NO PROGRAMA POR ESTE MOTIVO");

                    /*" -4015- DISPLAY 'PERMITE QUE O PROGRAMA SEJA REESTARTADO.   ' */
                    _.Display($"PERMITE QUE O PROGRAMA SEJA REESTARTADO.   ");

                    /*" -4016- DISPLAY 'POR FAVOR QUEIRA REESTARTA-LO.             ' */
                    _.Display($"POR FAVOR QUEIRA REESTARTA-LO.             ");

                    /*" -4017- DISPLAY '                                           ' */
                    _.Display($"                                           ");

                    /*" -4018- DISPLAY ' ESTE ABEND DEVERA CONSTAR NO NOTES ENVIADO' */
                    _.Display($" ESTE ABEND DEVERA CONSTAR NO NOTES ENVIADO");

                    /*" -4019- DISPLAY 'DIARIAMENTE PELA PRODUCAO A DESENVOLVIMENTO' */
                    _.Display($"DIARIAMENTE PELA PRODUCAO A DESENVOLVIMENTO");

                    /*" -4020- DISPLAY '                                           ' */
                    _.Display($"                                           ");

                    /*" -4021- DISPLAY ' COM CONHECIMENTO DO ANALISTA RESPONSAVEL  ' */
                    _.Display($" COM CONHECIMENTO DO ANALISTA RESPONSAVEL  ");

                    /*" -4022- DISPLAY '*******************************************' */
                    _.Display($"*******************************************");

                    /*" -4024- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4025- MOVE W-DATA-EDITADA TO HIST-DTVENCTO. */
            _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

            /*" -4025- MOVE 'B2012-VENCIMENTO-2A-PARCELA' TO WS-MOV-DTVENCTO. */
            _.Move("B2012-VENCIMENTO-2A-PARCELA", WS_MOV_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2012_999_EXIT*/

        [StopWatch]
        /*" B2013-VENCIMENTO-DEMAIS-SECTION */
        private void B2013_VENCIMENTO_DEMAIS_SECTION()
        {
            /*" -4039- MOVE 'B2013' TO WNR-EXEC-SQL. */
            _.Move("B2013", WABEND.WNR_EXEC_SQL);

            /*" -4040- PERFORM B2014-SOMA-1-MES */

            B2014_SOMA_1_MES_SECTION();

            /*" -4042- PERFORM B2017-VERIFICA-DIA-BASE */

            B2017_VERIFICA_DIA_BASE_SECTION();

            /*" -4043- MOVE W-DATA-EDITADA TO HIST-DTVENCTO. */
            _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

            /*" -4043- MOVE 'B2013-VENCIMENTO-DEMAIS' TO WS-MOV-DTVENCTO. */
            _.Move("B2013-VENCIMENTO-DEMAIS", WS_MOV_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2013_999_EXIT*/

        [StopWatch]
        /*" B2014-SOMA-1-MES-SECTION */
        private void B2014_SOMA_1_MES_SECTION()
        {
            /*" -4056- MOVE 'B2014' TO WNR-EXEC-SQL. */
            _.Move("B2014", WABEND.WNR_EXEC_SQL);

            /*" -4058- ADD 1 TO W-MES. */
            W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

            /*" -4059- IF W-MES GREATER 12 */

            if (W_DATA_EDITADA.W_MES > 12)
            {

                /*" -4060- MOVE 1 TO W-MES */
                _.Move(1, W_DATA_EDITADA.W_MES);

                /*" -4060- ADD 1 TO W-ANO. */
                W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2014_999_EXIT*/

        [StopWatch]
        /*" B2015-VERIFICA-ULTIMO-DIA-SECTION */
        private void B2015_VERIFICA_ULTIMO_DIA_SECTION()
        {
            /*" -4073- MOVE 'B2015' TO WNR-EXEC-SQL. */
            _.Move("B2015", WABEND.WNR_EXEC_SQL);

            /*" -4074- IF W-MES EQUAL 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (W_DATA_EDITADA.W_MES.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -4075- MOVE 31 TO W-ULTIMO-DIA */
                _.Move(31, W_ULTIMO_DIA);

                /*" -4076- ELSE */
            }
            else
            {


                /*" -4077- IF W-MES EQUAL 4 OR 6 OR 9 OR 11 */

                if (W_DATA_EDITADA.W_MES.In("4", "6", "9", "11"))
                {

                    /*" -4078- MOVE 30 TO W-ULTIMO-DIA */
                    _.Move(30, W_ULTIMO_DIA);

                    /*" -4079- ELSE */
                }
                else
                {


                    /*" -4083- DIVIDE W-ANO BY 4 GIVING W-INTEIRO REMAINDER W-RESTO */
                    _.Divide(W_DATA_EDITADA.W_ANO, 4, W_INTEIRO, W_RESTO);

                    /*" -4084- IF W-RESTO EQUAL ZEROS */

                    if (W_RESTO == 00)
                    {

                        /*" -4085- MOVE 29 TO W-ULTIMO-DIA */
                        _.Move(29, W_ULTIMO_DIA);

                        /*" -4086- ELSE */
                    }
                    else
                    {


                        /*" -4090- MOVE 28 TO W-ULTIMO-DIA. */
                        _.Move(28, W_ULTIMO_DIA);
                    }

                }

            }


            /*" -4091- IF W-DIA GREATER W-ULTIMO-DIA */

            if (W_DATA_EDITADA.W_DIA > W_ULTIMO_DIA)
            {

                /*" -4091- MOVE W-ULTIMO-DIA TO W-DIA. */
                _.Move(W_ULTIMO_DIA, W_DATA_EDITADA.W_DIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2015_999_EXIT*/

        [StopWatch]
        /*" B2016-VERIFICA-DATA-MINIMA-SECTION */
        private void B2016_VERIFICA_DATA_MINIMA_SECTION()
        {
            /*" -4103- MOVE 'B2016' TO WNR-EXEC-SQL. */
            _.Move("B2016", WABEND.WNR_EXEC_SQL);

            /*" -4104- IF (ENDO-CODPRODU = 1803 OR 1805) AND (ENDO-NRENDOS = 0) */

            if ((ENDO_CODPRODU.In("1803", "1805")) && (ENDO_NRENDOS == 0))
            {

                /*" -4105- GO TO B2016-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2016_999_EXIT*/ //GOTO
                return;

                /*" -4116- END-IF */
            }


            /*" -4117- IF VIND-DTVENCTO NOT EQUAL -1 */

            if (VIND_DTVENCTO != -1)
            {

                /*" -4118- IF W-DATA-EDITADA LESS W-DATA-MIN-1 */

                if (W_DATA_EDITADA < W_DATA_MIN_1)
                {

                    /*" -4119- MOVE W-DATA-MIN-1 TO W-DATA-EDITADA */
                    _.Move(W_DATA_MIN_1, W_DATA_EDITADA);

                    /*" -4120- END-IF */
                }


                /*" -4121- ELSE */
            }
            else
            {


                /*" -4122- IF PRCB-TIPO-COBRANCA EQUAL '1' OR '2' */

                if (PRCB_TIPO_COBRANCA.In("1", "2"))
                {

                    /*" -4123- IF W-DATA-EDITADA LESS W-DATA-MIN-2 */

                    if (W_DATA_EDITADA < W_DATA_MIN_2)
                    {

                        /*" -4124- MOVE W-DATA-MIN-2 TO W-DATA-EDITADA */
                        _.Move(W_DATA_MIN_2, W_DATA_EDITADA);

                        /*" -4125- END-IF */
                    }


                    /*" -4126- ELSE */
                }
                else
                {


                    /*" -4127- IF W-DATA-EDITADA LESS W-DATA-MIN-15 */

                    if (W_DATA_EDITADA < W_DATA_MIN_15)
                    {

                        /*" -4128- MOVE W-DATA-MIN-15 TO W-DATA-EDITADA */
                        _.Move(W_DATA_MIN_15, W_DATA_EDITADA);

                        /*" -4129- END-IF */
                    }


                    /*" -4130- END-IF */
                }


                /*" -4132- END-IF */
            }


            /*" -4132- PERFORM B2017-VERIFICA-DIA-BASE. */

            B2017_VERIFICA_DIA_BASE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2016_999_EXIT*/

        [StopWatch]
        /*" B2017-VERIFICA-DIA-BASE-SECTION */
        private void B2017_VERIFICA_DIA_BASE_SECTION()
        {
            /*" -4146- MOVE 'B2017' TO WNR-EXEC-SQL. */
            _.Move("B2017", WABEND.WNR_EXEC_SQL);

            /*" -4147- IF W-DIA-BASE LESS W-DIA */

            if (W_DIA_BASE < W_DATA_EDITADA.W_DIA)
            {

                /*" -4149- PERFORM B2014-SOMA-1-MES. */

                B2014_SOMA_1_MES_SECTION();
            }


            /*" -4151- MOVE W-DIA-BASE TO W-DIA */
            _.Move(W_DIA_BASE, W_DATA_EDITADA.W_DIA);

            /*" -4151- PERFORM B2015-VERIFICA-ULTIMO-DIA. */

            B2015_VERIFICA_ULTIMO_DIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2017_999_EXIT*/

        [StopWatch]
        /*" B2018-RECUPERA-AU084-SECTION */
        private void B2018_RECUPERA_AU084_SECTION()
        {
            /*" -4162- MOVE 'B2018' TO WNR-EXEC-SQL. */
            _.Move("B2018", WABEND.WNR_EXEC_SQL);

            /*" -4169- PERFORM B2018_RECUPERA_AU084_DB_SELECT_1 */

            B2018_RECUPERA_AU084_DB_SELECT_1();

            /*" -4172- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4173- DISPLAY 'ERRO SELECT AU_APOLICE_COMPL' */
                _.Display($"ERRO SELECT AU_APOLICE_COMPL");

                /*" -4173- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2018-RECUPERA-AU084-DB-SELECT-1 */
        public void B2018_RECUPERA_AU084_DB_SELECT_1()
        {
            /*" -4169- EXEC SQL SELECT IND_FORMA_PAGTO_AD INTO :AU084-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_APOLICE_COMPL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS WITH UR END-EXEC. */

            var b2018_RECUPERA_AU084_DB_SELECT_1_Query1 = new B2018_RECUPERA_AU084_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2018_RECUPERA_AU084_DB_SELECT_1_Query1.Execute(b2018_RECUPERA_AU084_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU084_IND_FORMA_PAGTO_AD, AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2018_999_EXIT*/

        [StopWatch]
        /*" B2020-SELECT-MR021-SECTION */
        private void B2020_SELECT_MR021_SECTION()
        {
            /*" -4184- MOVE 'B2020' TO WNR-EXEC-SQL. */
            _.Move("B2020", WABEND.WNR_EXEC_SQL);

            /*" -4200- PERFORM B2020_SELECT_MR021_DB_SELECT_1 */

            B2020_SELECT_MR021_DB_SELECT_1();

            /*" -4203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4204- DISPLAY 'ERRO SELECT MR_APOL_ITEM_COND' */
                _.Display($"ERRO SELECT MR_APOL_ITEM_COND");

                /*" -4204- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2020-SELECT-MR021-DB-SELECT-1 */
        public void B2020_SELECT_MR021_DB_SELECT_1()
        {
            /*" -4200- EXEC SQL SELECT VALUE(A.PCT_DESC_COBERTURA,0), VALUE(A.PCT_BONUS_RENOVCAO,0), VALUE(A.PCT_DESC_CORRETOR,0) INTO :MR021-PCT-DESC-COBERTURA, :MR021-PCT-BONUS-RENOVCAO, :MR021-PCT-DESC-CORRETOR FROM SEGUROS.MR_APOL_ITEM_COND A WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDO-NRENDOS AND A.NUM_ITEM = (SELECT MAX(B.NUM_ITEM) FROM SEGUROS.MR_APOL_ITEM_COND B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO) WITH UR END-EXEC. */

            var b2020_SELECT_MR021_DB_SELECT_1_Query1 = new B2020_SELECT_MR021_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2020_SELECT_MR021_DB_SELECT_1_Query1.Execute(b2020_SELECT_MR021_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MR021_PCT_DESC_COBERTURA, MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_DESC_COBERTURA);
                _.Move(executed_1.MR021_PCT_BONUS_RENOVCAO, MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_BONUS_RENOVCAO);
                _.Move(executed_1.MR021_PCT_DESC_CORRETOR, MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_DESC_CORRETOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2020_999_EXIT*/

        [StopWatch]
        /*" B2025-TRATA-2PCELA-CCA-SECTION */
        private void B2025_TRATA_2PCELA_CCA_SECTION()
        {
            /*" -4216- MOVE 'B2025' TO WNR-EXEC-SQL. */
            _.Move("B2025", WABEND.WNR_EXEC_SQL);

            /*" -4226- PERFORM B2025_TRATA_2PCELA_CCA_DB_SELECT_1 */

            B2025_TRATA_2PCELA_CCA_DB_SELECT_1();

            /*" -4229- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4230- DISPLAY 'ERRO SELECT LT_SOLICITA_PARAM' */
                _.Display($"ERRO SELECT LT_SOLICITA_PARAM");

                /*" -4232- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4235- IF LTMVPROP-DT-INIVIG-PROPOSTA >= '2015-11-01' AND ENDO-NRRCAP GREATER ZEROS */

            if (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA >= "2015-11-01" && ENDO_NRRCAP > 00)
            {

                /*" -4236- DISPLAY 'AQUI ESTOU 5 ' W-DATA-EDITADA */
                _.Display($"AQUI ESTOU 5 {W_DATA_EDITADA}");

                /*" -4237- PERFORM B2014-SOMA-1-MES */

                B2014_SOMA_1_MES_SECTION();

                /*" -4239- END-IF */
            }


            /*" -4240- IF LTSOLPAR-PARAM-DATE03 GREATER LTMVPROP-DT-INIVIG-PROPOSTA */

            if (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03 > LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA)
            {

                /*" -4242- MOVE 01 TO W-DIA W-DIA-BASE */
                _.Move(01, W_DATA_EDITADA.W_DIA, W_DIA_BASE);

                /*" -4244- END-IF. */
            }


            /*" -4244- MOVE W-DATA-EDITADA TO ENDO-DTVENCTO. */
            _.Move(W_DATA_EDITADA, ENDO_DTVENCTO);

        }

        [StopWatch]
        /*" B2025-TRATA-2PCELA-CCA-DB-SELECT-1 */
        public void B2025_TRATA_2PCELA_CCA_DB_SELECT_1()
        {
            /*" -4226- EXEC SQL SELECT PARAM_DATE03 INTO :LTSOLPAR-PARAM-DATE03 FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = 'SPBLTPRM' AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO AND PARAM_SMINT01 = 74 AND :LTMVPROP-DT-INIVIG-PROPOSTA BETWEEN PARAM_DATE01 AND PARAM_DATE02 WITH UR END-EXEC */

            var b2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1 = new B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1()
            {
                LTMVPROP_DT_INIVIG_PROPOSTA = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            var executed_1 = B2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1.Execute(b2025_TRATA_2PCELA_CCA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTSOLPAR_PARAM_DATE03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2025_999_EXIT*/

        [StopWatch]
        /*" B2030-SELECT-MR022-SECTION */
        private void B2030_SELECT_MR022_SECTION()
        {
            /*" -4257- MOVE 'B2030' TO WNR-EXEC-SQL. */
            _.Move("B2030", WABEND.WNR_EXEC_SQL);

            /*" -4279- PERFORM B2030_SELECT_MR022_DB_SELECT_1 */

            B2030_SELECT_MR022_DB_SELECT_1();

            /*" -4282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4283- DISPLAY 'ERRO SELECT MR_APOL_ITEM_EMPR' */
                _.Display($"ERRO SELECT MR_APOL_ITEM_EMPR");

                /*" -4283- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2030-SELECT-MR022-DB-SELECT-1 */
        public void B2030_SELECT_MR022_DB_SELECT_1()
        {
            /*" -4279- EXEC SQL SELECT VALUE(A.PCT_DESC_COBERTURA,0), VALUE(A.PCT_BONUS_RENOVCAO,0), VALUE(A.PCT_DESC_CORRETOR,0) INTO :MR022-PCT-DESC-COBERTURA, :MR022-PCT-BONUS-RENOVCAO, :MR022-PCT-DESC-CORRETOR FROM SEGUROS.MR_APOL_ITEM_EMPR A WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDO-NRENDOS AND A.NUM_ITEM = (SELECT MAX(B.NUM_ITEM) FROM SEGUROS.MR_APOL_ITEM_EMPR B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO) AND A.NUM_SUB_ITEM = (SELECT MAX(C.NUM_SUB_ITEM) FROM SEGUROS.MR_APOL_ITEM_EMPR C WHERE C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.NUM_ITEM = A.NUM_ITEM) WITH UR END-EXEC. */

            var b2030_SELECT_MR022_DB_SELECT_1_Query1 = new B2030_SELECT_MR022_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2030_SELECT_MR022_DB_SELECT_1_Query1.Execute(b2030_SELECT_MR022_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MR022_PCT_DESC_COBERTURA, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA);
                _.Move(executed_1.MR022_PCT_BONUS_RENOVCAO, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO);
                _.Move(executed_1.MR022_PCT_DESC_CORRETOR, MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_CORRETOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2030_999_EXIT*/

        [StopWatch]
        /*" B2031-SELECT-MRAPOITE-SECTION */
        private void B2031_SELECT_MRAPOITE_SECTION()
        {
            /*" -4294- MOVE 'B2031' TO WNR-EXEC-SQL. */
            _.Move("B2031", WABEND.WNR_EXEC_SQL);

            /*" -4303- PERFORM B2031_SELECT_MRAPOITE_DB_SELECT_1 */

            B2031_SELECT_MRAPOITE_DB_SELECT_1();

            /*" -4306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4309- DISPLAY 'ERRO SELECT MR_APOLICE_ITEM' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $"ERRO SELECT MR_APOLICE_ITEM {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -4309- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2031-SELECT-MRAPOITE-DB-SELECT-1 */
        public void B2031_SELECT_MRAPOITE_DB_SELECT_1()
        {
            /*" -4303- EXEC SQL SELECT VALUE(MAX(PCT_DESC_FIDEL),0), VALUE(MAX(PCT_DESC_COMERCIAL),0) INTO :MRAPOITE-PCT-DESC-FIDEL , :MRAPOITE-PCT-DESC-COMERCIAL FROM SEGUROS.MR_APOLICE_ITEM WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS WITH UR END-EXEC. */

            var b2031_SELECT_MRAPOITE_DB_SELECT_1_Query1 = new B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2031_SELECT_MRAPOITE_DB_SELECT_1_Query1.Execute(b2031_SELECT_MRAPOITE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MRAPOITE_PCT_DESC_FIDEL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL);
                _.Move(executed_1.MRAPOITE_PCT_DESC_COMERCIAL, MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_COMERCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2031_999_EXIT*/

        [StopWatch]
        /*" B2035-SELECT-MRAPOCOB-SECTION */
        private void B2035_SELECT_MRAPOCOB_SECTION()
        {
            /*" -4320- MOVE 'B2035' TO WNR-EXEC-SQL. */
            _.Move("B2035", WABEND.WNR_EXEC_SQL);

            /*" -4328- PERFORM B2035_SELECT_MRAPOCOB_DB_SELECT_1 */

            B2035_SELECT_MRAPOCOB_DB_SELECT_1();

            /*" -4331- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4332- DISPLAY 'ERRO SELECT MR_APOLICE_COBER' */
                _.Display($"ERRO SELECT MR_APOLICE_COBER");

                /*" -4332- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2035-SELECT-MRAPOCOB-DB-SELECT-1 */
        public void B2035_SELECT_MRAPOCOB_DB_SELECT_1()
        {
            /*" -4328- EXEC SQL SELECT VALUE(SUM(A.PRM_TARIFARIO_IX),0) INTO :MRAPOCOB-PRM-TARIFARIO-IX FROM SEGUROS.MR_APOLICE_COBER A WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDO-NRENDOS AND A.COD_COBERTURA = 99 WITH UR END-EXEC. */

            var b2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1 = new B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1.Execute(b2035_SELECT_MRAPOCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MRAPOCOB_PRM_TARIFARIO_IX, MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2035_999_EXIT*/

        [StopWatch]
        /*" B2040-SELECT-V0APOL-HABIT-SECTION */
        private void B2040_SELECT_V0APOL_HABIT_SECTION()
        {
            /*" -4342- MOVE 'B2040' TO WNR-EXEC-SQL. */
            _.Move("B2040", WABEND.WNR_EXEC_SQL);

            /*" -4350- PERFORM B2040_SELECT_V0APOL_HABIT_DB_SELECT_1 */

            B2040_SELECT_V0APOL_HABIT_DB_SELECT_1();

            /*" -4353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4354- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4355- MOVE 'N' TO WCH-APOL-HABIT */
                    _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                    /*" -4356- GO TO B2040-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: B2040_999_EXIT*/ //GOTO
                    return;

                    /*" -4357- ELSE */
                }
                else
                {


                    /*" -4358- DISPLAY 'ERRO SELECT V0APOL-HABIT' */
                    _.Display($"ERRO SELECT V0APOL-HABIT");

                    /*" -4358- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B2040-SELECT-V0APOL-HABIT-DB-SELECT-1 */
        public void B2040_SELECT_V0APOL_HABIT_DB_SELECT_1()
        {
            /*" -4350- EXEC SQL SELECT A.CODCLIEN INTO :V0PRHA-CODCLIEN FROM SEGUROS.V0APOLICE A, SEGUROS.V0APOLICE_HABIT B WHERE B.NUM_APOLICE = :ENDO-NUM-APOLICE AND B.NUM_APOLICE = A.NUM_APOLICE WITH UR END-EXEC. */

            var b2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1 = new B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
            };

            var executed_1 = B2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1.Execute(b2040_SELECT_V0APOL_HABIT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRHA_CODCLIEN, V0PRHA_CODCLIEN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2040_999_EXIT*/

        [StopWatch]
        /*" B2050-VENCTO-AUTO-FACIL-SECTION */
        private void B2050_VENCTO_AUTO_FACIL_SECTION()
        {
            /*" -4369- MOVE 'B2050' TO WNR-EXEC-SQL. */
            _.Move("B2050", WABEND.WNR_EXEC_SQL);

            /*" -4370- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -4372- PERFORM B2051-MONTA-VENCIMENTOS. */

                B2051_MONTA_VENCIMENTOS_SECTION();
            }


            /*" -4373- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -4373- MOVE TBV-DT-VENC-PAR(IX1) TO W-DATA-EDITADA. */
            _.Move(VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_PAR, W_DATA_EDITADA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2050_999_EXIT*/

        [StopWatch]
        /*" B2051-MONTA-VENCIMENTOS-SECTION */
        private void B2051_MONTA_VENCIMENTOS_SECTION()
        {
            /*" -4383- MOVE 'B2051' TO WNR-EXEC-SQL. */
            _.Move("B2051", WABEND.WNR_EXEC_SQL);

            /*" -4385- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
            _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

            /*" -4386- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -4387- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -4388- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -4389- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -4390- MOVE 15 TO PROSOM-QTDIA */
            _.Move(15, PROSOMW099.PROSOM_QTDIA);

            /*" -4392- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -4394- CALL 'PROSOMC1' USING PROSOMW099 */
            _.Call("PROSOMC1", PROSOMW099);

            /*" -4395- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -4396- MOVE W-AA TO W-ANO-M15 */
            _.Move(W_DATA.W_AA, VENCIMENTOS.W_DATA_M15.W_ANO_M15);

            /*" -4397- MOVE W-MM TO W-MES-M15 */
            _.Move(W_DATA.W_MM, VENCIMENTOS.W_DATA_M15.W_MES_M15);

            /*" -4399- MOVE W-DD TO W-DIA-M15. */
            _.Move(W_DATA.W_DD, VENCIMENTOS.W_DATA_M15.W_DIA_M15);

            /*" -4400- MOVE W-ANO-M15 TO WC-ANO */
            _.Move(VENCIMENTOS.W_DATA_M15.W_ANO_M15, VENCIMENTOS.FILLER_23.WC_ANO);

            /*" -4401- MOVE W-MES-M15 TO WC-MES */
            _.Move(VENCIMENTOS.W_DATA_M15.W_MES_M15, VENCIMENTOS.FILLER_23.WC_MES);

            /*" -4402- MOVE W-DIA-DEBITO TO W-DIA-M15 */
            _.Move(VENCIMENTOS.W_DIA_DEBITO, VENCIMENTOS.W_DATA_M15.W_DIA_M15);

            /*" -4403- MOVE W-DIA-M15 TO WC-DIA */
            _.Move(VENCIMENTOS.W_DATA_M15.W_DIA_M15, VENCIMENTOS.FILLER_23.WC_DIA);

            /*" -4405- MOVE WC-DATA TO LDIFE01. */
            _.Move(VENCIMENTOS.WC_DATA, VENCIMENTOS.LDIFE.LDIFE01);

            /*" -4406- MOVE W-ANO-M15 TO W-ANO-DEB */
            _.Move(VENCIMENTOS.W_DATA_M15.W_ANO_M15, W_DATA_DEBITO.W_ANO_DEB);

            /*" -4407- MOVE W-MES-M15 TO W-MES-DEB */
            _.Move(VENCIMENTOS.W_DATA_M15.W_MES_M15, W_DATA_DEBITO.W_MES_DEB);

            /*" -4409- MOVE W-DIA-M15 TO W-DIA-DEB */
            _.Move(VENCIMENTOS.W_DATA_M15.W_DIA_M15, W_DATA_DEBITO.W_DIA_DEB);

            /*" -4410- MOVE W-DIA TO WC-DIA */
            _.Move(W_DATA_EDITADA.W_DIA, VENCIMENTOS.FILLER_23.WC_DIA);

            /*" -4411- MOVE W-MES TO WC-MES */
            _.Move(W_DATA_EDITADA.W_MES, VENCIMENTOS.FILLER_23.WC_MES);

            /*" -4412- MOVE W-ANO TO WC-ANO */
            _.Move(W_DATA_EDITADA.W_ANO, VENCIMENTOS.FILLER_23.WC_ANO);

            /*" -4414- MOVE WC-DATA TO LDIFE02. */
            _.Move(VENCIMENTOS.WC_DATA, VENCIMENTOS.LDIFE.LDIFE02);

            /*" -4416- MOVE ZEROS TO LDIFE03. */
            _.Move(0, VENCIMENTOS.LDIFE.LDIFE03);

            /*" -4420- CALL 'PRODIFC1' USING LDIFE. */
            _.Call("PRODIFC1", VENCIMENTOS.LDIFE);

            /*" -4421- IF LDIFE03 NOT > 15 */

            if (VENCIMENTOS.LDIFE.LDIFE03 <= 15)
            {

                /*" -4422- MOVE W-DATA-M15 TO W-DATA-EDITADA */
                _.Move(VENCIMENTOS.W_DATA_M15, W_DATA_EDITADA);

                /*" -4423- MOVE W-DIA-DEBITO TO W-DIA */
                _.Move(VENCIMENTOS.W_DIA_DEBITO, W_DATA_EDITADA.W_DIA);

                /*" -4424- ADD 1 TO W-MES */
                W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                /*" -4425- IF W-MES GREATER 12 */

                if (W_DATA_EDITADA.W_MES > 12)
                {

                    /*" -4426- MOVE 1 TO W-MES */
                    _.Move(1, W_DATA_EDITADA.W_MES);

                    /*" -4427- ADD 1 TO W-ANO */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                    /*" -4428- END-IF */
                }


                /*" -4429- MOVE W-DATA-EDITADA TO W-DATA-DEBITO */
                _.Move(W_DATA_EDITADA, W_DATA_DEBITO);

                /*" -4430- ELSE */
            }
            else
            {


                /*" -4431- MOVE W-DIA-DEBITO TO W-DIA */
                _.Move(VENCIMENTOS.W_DIA_DEBITO, W_DATA_EDITADA.W_DIA);

                /*" -4432- ADD 1 TO W-MES */
                W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                /*" -4433- IF W-MES GREATER 12 */

                if (W_DATA_EDITADA.W_MES > 12)
                {

                    /*" -4434- MOVE 1 TO W-MES */
                    _.Move(1, W_DATA_EDITADA.W_MES);

                    /*" -4435- ADD 1 TO W-ANO */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                    /*" -4436- END-IF */
                }


                /*" -4446- MOVE W-DATA-EDITADA TO W-DATA-DEBITO. */
                _.Move(W_DATA_EDITADA, W_DATA_DEBITO);
            }


            /*" -4448- IF AU085-IND-FORMA-PAGTO-AD NOT EQUAL '4' */

            if (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD != "4")
            {

                /*" -4449- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                /*" -4450- ELSE */
            }
            else
            {


                /*" -4451- IF W-DATA-M15 GREATER ENDO-DTVENCTO */

                if (VENCIMENTOS.W_DATA_M15 > ENDO_DTVENCTO)
                {

                    /*" -4453- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);
                }

            }


            /*" -4453- PERFORM B2052-CALCULA-DATAS. */

            B2052_CALCULA_DATAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2051_999_EXIT*/

        [StopWatch]
        /*" B2052-CALCULA-DATAS-SECTION */
        private void B2052_CALCULA_DATAS_SECTION()
        {
            /*" -4463- MOVE 'B2052' TO WNR-EXEC-SQL. */
            _.Move("B2052", WABEND.WNR_EXEC_SQL);

            /*" -4465- MOVE TBVEN-MASCARA TO TBVEN-DATAS. */
            _.Move(VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS);

            /*" -4467- PERFORM B2053-SOMA-MESES. */

            B2053_SOMA_MESES_SECTION();

            /*" -4467- PERFORM B2055-VENCIMENTOS. */

            B2055_VENCIMENTOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2052_999_EXIT*/

        [StopWatch]
        /*" B2053-SOMA-MESES-SECTION */
        private void B2053_SOMA_MESES_SECTION()
        {
            /*" -4476- MOVE 'B2053' TO WNR-EXEC-SQL. */
            _.Move("B2053", WABEND.WNR_EXEC_SQL);

            /*" -4477- SET IX1 TO WZEROS. */
            IX1.Value = WZEROS;

            /*" -4477- MOVE ZEROS TO WTBV-NUM-PARCELA. */
            _.Move(0, VENCIMENTOS.WTBV_NUM_PARCELA);

            /*" -0- FLUXCONTROL_PERFORM B2053_LOOP */

            B2053_LOOP();

        }

        [StopWatch]
        /*" B2053-LOOP */
        private void B2053_LOOP(bool isPerform = false)
        {
            /*" -4482- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -4483- IF IX1 GREATER +12 */

            if (IX1 > +12)
            {

                /*" -4485- GO TO B2053-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2053_999_EXIT*/ //GOTO
                return;
            }


            /*" -4486- IF IX1 GREATER +1 */

            if (IX1 > +1)
            {

                /*" -4487- IF IX1 EQUAL +2 */

                if (IX1 == +2)
                {

                    /*" -4489- IF W-DIA-DEBITO GREATER W-DIA-M15 AND W-MES-M15 EQUAL W-MES */

                    if (VENCIMENTOS.W_DIA_DEBITO > VENCIMENTOS.W_DATA_M15.W_DIA_M15 && VENCIMENTOS.W_DATA_M15.W_MES_M15 == W_DATA_EDITADA.W_MES)
                    {

                        /*" -4490- MOVE W-DIA-DEBITO TO W-DIA */
                        _.Move(VENCIMENTOS.W_DIA_DEBITO, W_DATA_EDITADA.W_DIA);

                        /*" -4492- IF W-DATA-EDITADA EQUAL TBV-DT-VENC-CLC(1) */

                        if (W_DATA_EDITADA == VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[1].TBV_DT_VENC_CLC)
                        {

                            /*" -4493- ADD 1 TO W-MES */
                            W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                            /*" -4494- IF W-MES GREATER 12 */

                            if (W_DATA_EDITADA.W_MES > 12)
                            {

                                /*" -4495- MOVE 1 TO W-MES */
                                _.Move(1, W_DATA_EDITADA.W_MES);

                                /*" -4496- ADD 1 TO W-ANO */
                                W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                                /*" -4497- END-IF */
                            }


                            /*" -4498- END-IF */
                        }


                        /*" -4499- ELSE */
                    }
                    else
                    {


                        /*" -4500- MOVE W-DATA-DEBITO TO W-DATA-EDITADA */
                        _.Move(W_DATA_DEBITO, W_DATA_EDITADA);

                        /*" -4502- IF W-DATA-EDITADA EQUAL TBV-DT-VENC-CLC(1) */

                        if (W_DATA_EDITADA == VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[1].TBV_DT_VENC_CLC)
                        {

                            /*" -4503- ADD 1 TO W-MES */
                            W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                            /*" -4504- IF W-MES GREATER 12 */

                            if (W_DATA_EDITADA.W_MES > 12)
                            {

                                /*" -4505- MOVE 1 TO W-MES */
                                _.Move(1, W_DATA_EDITADA.W_MES);

                                /*" -4506- ADD 1 TO W-ANO */
                                W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                                /*" -4507- END-IF */
                            }


                            /*" -4508- END-IF */
                        }


                        /*" -4509- ELSE */
                    }

                }
                else
                {


                    /*" -4510- ADD 1 TO W-MES */
                    W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                    /*" -4511- IF W-MES GREATER 12 */

                    if (W_DATA_EDITADA.W_MES > 12)
                    {

                        /*" -4512- MOVE 1 TO W-MES */
                        _.Move(1, W_DATA_EDITADA.W_MES);

                        /*" -4514- ADD 1 TO W-ANO. */
                        W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;
                    }

                }

            }


            /*" -4516- PERFORM B2054-ULTIMO-DIA */

            B2054_ULTIMO_DIA_SECTION();

            /*" -4517- ADD 1 TO WTBV-NUM-PARCELA. */
            VENCIMENTOS.WTBV_NUM_PARCELA.Value = VENCIMENTOS.WTBV_NUM_PARCELA + 1;

            /*" -4518- MOVE WTBV-NUM-PARCELA TO TBV-NUM-PARCELA(IX1). */
            _.Move(VENCIMENTOS.WTBV_NUM_PARCELA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_NUM_PARCELA);

            /*" -4519- MOVE W-DATA-EDITADA TO TBV-DT-VENC-CLC(IX1). */
            _.Move(W_DATA_EDITADA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_CLC);

            /*" -4521- MOVE W-ULTIMO-DIA TO TBV-DIA-MES(IX1). */
            _.Move(W_ULTIMO_DIA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DIA_MES);

            /*" -4521- GO TO B2053-LOOP. */
            new Task(() => B2053_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2053_999_EXIT*/

        [StopWatch]
        /*" B2054-ULTIMO-DIA-SECTION */
        private void B2054_ULTIMO_DIA_SECTION()
        {
            /*" -4531- MOVE 'B2054' TO WNR-EXEC-SQL. */
            _.Move("B2054", WABEND.WNR_EXEC_SQL);

            /*" -4533- IF W-MES EQUAL 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (W_DATA_EDITADA.W_MES.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -4534- MOVE 31 TO W-ULTIMO-DIA */
                _.Move(31, W_ULTIMO_DIA);

                /*" -4535- ELSE */
            }
            else
            {


                /*" -4536- IF W-MES EQUAL 4 OR 6 OR 9 OR 11 */

                if (W_DATA_EDITADA.W_MES.In("4", "6", "9", "11"))
                {

                    /*" -4537- MOVE 30 TO W-ULTIMO-DIA */
                    _.Move(30, W_ULTIMO_DIA);

                    /*" -4538- ELSE */
                }
                else
                {


                    /*" -4541- DIVIDE W-ANO BY 4 GIVING W-INTEIRO REMAINDER W-RESTO */
                    _.Divide(W_DATA_EDITADA.W_ANO, 4, W_INTEIRO, W_RESTO);

                    /*" -4542- IF W-RESTO EQUAL ZEROS */

                    if (W_RESTO == 00)
                    {

                        /*" -4543- MOVE 29 TO W-ULTIMO-DIA */
                        _.Move(29, W_ULTIMO_DIA);

                        /*" -4544- ELSE */
                    }
                    else
                    {


                        /*" -4544- MOVE 28 TO W-ULTIMO-DIA. */
                        _.Move(28, W_ULTIMO_DIA);
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2054_999_EXIT*/

        [StopWatch]
        /*" B2055-VENCIMENTOS-SECTION */
        private void B2055_VENCIMENTOS_SECTION()
        {
            /*" -4553- MOVE 'B2055' TO WNR-EXEC-SQL. */
            _.Move("B2055", WABEND.WNR_EXEC_SQL);

            /*" -4553- SET IX1 TO WZEROS. */
            IX1.Value = WZEROS;

            /*" -0- FLUXCONTROL_PERFORM B2055_LOOP */

            B2055_LOOP();

        }

        [StopWatch]
        /*" B2055-LOOP */
        private void B2055_LOOP(bool isPerform = false)
        {
            /*" -4558- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -4559- IF IX1 GREATER +12 */

            if (IX1 > +12)
            {

                /*" -4560- SET IX1 TO WZEROS */
                IX1.Value = WZEROS;

                /*" -4562- GO TO B2055-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2055_999_EXIT*/ //GOTO
                return;
            }


            /*" -4563- MOVE TBV-DT-VENC-CLC(IX1) TO W-DATA-EDITADA */
            _.Move(VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_CLC, W_DATA_EDITADA);

            /*" -4565- IF W-DIA GREATER TBV-DIA-MES(IX1) */

            if (W_DATA_EDITADA.W_DIA > VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DIA_MES)
            {

                /*" -4566- MOVE 1 TO W-DIA */
                _.Move(1, W_DATA_EDITADA.W_DIA);

                /*" -4567- ADD 1 TO W-MES */
                W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                /*" -4568- IF W-MES GREATER 12 */

                if (W_DATA_EDITADA.W_MES > 12)
                {

                    /*" -4569- MOVE 1 TO W-MES */
                    _.Move(1, W_DATA_EDITADA.W_MES);

                    /*" -4571- ADD 1 TO W-ANO. */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;
                }

            }


            /*" -4574- MOVE W-DATA-EDITADA TO TBV-DT-VENC-PAR(IX1). */
            _.Move(W_DATA_EDITADA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_PAR);

            /*" -4574- GO TO B2055-LOOP. */
            new Task(() => B2055_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2055_999_EXIT*/

        [StopWatch]
        /*" B2060-CHAMA-LT3116S-SECTION */
        private void B2060_CHAMA_LT3116S_SECTION()
        {
            /*" -4584- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -4585- IF WS-PERIODO-RENOVACAO >= 2006 AND <= 2008 */

            if (WS_PERIODO_RENOVACAO >= 2006 && WS_PERIODO_RENOVACAO <= 2008)
            {

                /*" -4586- PERFORM B2060-CHAMA-LT3117S */

                B2060_CHAMA_LT3117S_SECTION();

                /*" -4587- ELSE */
            }
            else
            {


                /*" -4588- PERFORM B2060-CHAMA-LT3151S */

                B2060_CHAMA_LT3151S_SECTION();

                /*" -4589- END-IF */
            }


            /*" -4589- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_999_EXIT*/

        [StopWatch]
        /*" B2060-CHAMA-LT3117S-SECTION */
        private void B2060_CHAMA_LT3117S_SECTION()
        {
            /*" -4601- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -4645- MOVE ZEROS TO LKIO-PREMIO-INCENDIO LKIO-PREMIO-VALORES LKIO-PREMIO-DANELET LKIO-PREMIO-AP-EMPGDR LKIO-PREMIO-AP-EMP LKIO-PREMIO-RC LKIO-TX-PREMIO-INCENDIO LKIO-TX-PREMIO-VALORES LKIO-TX-PREMIO-DANELET LKIO-TX-PREMIO-AP-EMPGDR LKIO-TX-PREMIO-AP-EMP LKIO-TX-PREMIO-RC LKIO-VL-IS-INCENDIO LKIO-VL-IS-VALORES LKIO-VL-IS-DANELET LKIO-VL-IS-AP-EMPGDR LKIO-VL-IS-AP-EMP LKIO-VL-IS-RC LKIO-CUSTO-APOLICE LKIO-IOF-PCL1 LKIO-ADICIONAL-FRAC-PCL1 LKIO-JUROS-PCL1 LKIO-PERC-JUROS-PCL1 LKIO-VL-PREMIO-LIQ-PCL1 LKIO-VL-PREMIO-PCL1 LKIO-IOF-PCLN LKIO-ADICIONAL-FRAC-PCLN LKIO-JUROS-PCLN LKIO-PERC-JUROS-PCLN LKIO-VL-PREMIO-LIQ-PCLN LKIO-VL-PREMIO-PCLN LKIO-VL-PREMIO-TOTAL LKIO-JURO-TOTAL LKIO-IOF-TOTAL LKIO-COD-RETORNO LKIO-PREMIO-TAR-INC LKIO-PREMIO-TAR-VAL LKIO-PREMIO-TAR-DAN LKIO-PREMIO-TAR-AP-EMPGDR LKIO-PREMIO-TAR-AP-EMP LKIO-PREMIO-TAR-RC */
            _.Move(0, LBHLT027.LKIO_PREMIO_INCENDIO, LBHLT027.LKIO_PREMIO_VALORES, LBHLT027.LKIO_PREMIO_DANELET, LBHLT027.LKIO_PREMIO_AP_EMPGDR, LBHLT027.LKIO_PREMIO_AP_EMP, LBHLT027.LKIO_PREMIO_RC, LBHLT027.LKIO_TX_PREMIO_INCENDIO, LBHLT027.LKIO_TX_PREMIO_VALORES, LBHLT027.LKIO_TX_PREMIO_DANELET, LBHLT027.LKIO_TX_PREMIO_AP_EMPGDR, LBHLT027.LKIO_TX_PREMIO_AP_EMP, LBHLT027.LKIO_TX_PREMIO_RC, LBHLT027.LKIO_VL_IS_INCENDIO, LBHLT027.LKIO_VL_IS_VALORES, LBHLT027.LKIO_VL_IS_DANELET, LBHLT027.LKIO_VL_IS_AP_EMPGDR, LBHLT027.LKIO_VL_IS_AP_EMP, LBHLT027.LKIO_VL_IS_RC, LBHLT027.LKIO_CUSTO_APOLICE, LBHLT027.LKIO_IOF_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1, LBHLT027.LKIO_JUROS_PCL1, LBHLT027.LKIO_PERC_JUROS_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1, LBHLT027.LKIO_IOF_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN, LBHLT027.LKIO_JUROS_PCLN, LBHLT027.LKIO_PERC_JUROS_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_TOTAL, LBHLT027.LKIO_JURO_TOTAL, LBHLT027.LKIO_IOF_TOTAL, LBHLT027.LKIO_COD_RETORNO, LBHLT027.LKIO_PREMIO_TAR_INC, LBHLT027.LKIO_PREMIO_TAR_VAL, LBHLT027.LKIO_PREMIO_TAR_DAN, LBHLT027.LKIO_PREMIO_TAR_AP_EMPGDR, LBHLT027.LKIO_PREMIO_TAR_AP_EMP, LBHLT027.LKIO_PREMIO_TAR_RC);

            /*" -4646- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -4647- MOVE 1 TO LT3117-QTD-PARCELAS */
                _.Move(1, LBLT3117.LT3117_QTD_PARCELAS);

                /*" -4648- ELSE */
            }
            else
            {


                /*" -4650- MOVE ENDO-QTPARCEL TO LT3117-QTD-PARCELAS. */
                _.Move(ENDO_QTPARCEL, LBLT3117.LT3117_QTD_PARCELAS);
            }


            /*" -4654- PERFORM B2061-SELECT-LTMVPROP */

            B2061_SELECT_LTMVPROP_SECTION();

            /*" -4658- MOVE 0 TO LT3117-COD-RETORNO LT3117-VL-PREMIO-PCL1 LT3117-VL-PREMIO-PCLN LT3117-VL-PREMIO-TOTAL */
            _.Move(0, LBLT3117.LT3117_COD_RETORNO, LBLT3117.LT3117_VL_PREMIO_PCL1, LBLT3117.LT3117_VL_PREMIO_PCLN, LBLT3117.LT3117_VL_PREMIO_TOTAL);

            /*" -4660- MOVE LTMVPROP-VLR-CUSTO-APOLICE TO LT3117-CUSTO-APOLICE LKIO-CUSTO-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE, LBLT3117.LT3117_CUSTO_APOLICE, LBHLT027.LKIO_CUSTO_APOLICE);

            /*" -4661- MOVE LTMVPROP-PCT-JUROS TO LT3117-PCT-IOF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_JUROS, LBLT3117.LT3117_PCT_IOF);

            /*" -4662- MOVE ' ' TO LT3117-TIPO-OPERACAO */
            _.Move(" ", LBLT3117.LT3117_TIPO_OPERACAO);

            /*" -4663- MOVE ' ' TO LT3117-TIPO-CALCULO */
            _.Move(" ", LBLT3117.LT3117_TIPO_CALCULO);

            /*" -4664- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3117-COD-LOTERICO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3117.LT3117_COD_LOTERICO);

            /*" -4665- MOVE ENDO-NUM-APOLICE TO LT3117-NUM-APOLICE */
            _.Move(ENDO_NUM_APOLICE, LBLT3117.LT3117_NUM_APOLICE);

            /*" -4666- MOVE LTMVPROP-DT-INIVIG-PROPOSTA TO LT3117-DTINIVIG-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA, LBLT3117.LT3117_DTINIVIG_APOLICE);

            /*" -4668- MOVE SPACES TO LT3117-DTTERVIG-APOLICE */
            _.Move("", LBLT3117.LT3117_DTTERVIG_APOLICE);

            /*" -4674- MOVE LTMVPROP-NUM-CLASSE-ADESAO TO LT3117-NUM-CLASSE-ADESAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO, LBLT3117.LT3117_NUM_CLASSE_ADESAO);

            /*" -4675- MOVE TB-IMPSEG (01) TO LT3117-VL-IS-INCENDIO. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[01], LBLT3117.LT3117_VL_IS_INCENDIO);

            /*" -4676- MOVE TB-IMPSEG (02) TO LT3117-VL-IS-VALORES. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[02], LBLT3117.LT3117_VL_IS_VALORES);

            /*" -4677- MOVE TB-IMPSEG (03) TO LT3117-VL-IS-DANELET. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[03], LBLT3117.LT3117_VL_IS_DANELET);

            /*" -4678- MOVE TB-IMPSEG (04) TO LT3117-VL-IS-AP-EMPGDR. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[04], LBLT3117.LT3117_VL_IS_AP_EMPGDR);

            /*" -4679- MOVE TB-IMPSEG (05) TO LT3117-VL-IS-AP-EMP. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[05], LBLT3117.LT3117_VL_IS_AP_EMP);

            /*" -4681- MOVE TB-IMPSEG (06) TO LT3117-VL-IS-RC. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[06], LBLT3117.LT3117_VL_IS_RC);

            /*" -4682- MOVE TB-TAXAS (01) TO LT3117-TX-INCENDIO. */
            _.Move(TAB_TAXAS.TB_TAXAS[01], LBLT3117.LT3117_TX_INCENDIO);

            /*" -4683- MOVE TB-TAXAS (02) TO LT3117-TX-VALORES. */
            _.Move(TAB_TAXAS.TB_TAXAS[02], LBLT3117.LT3117_TX_VALORES);

            /*" -4684- MOVE TB-TAXAS (03) TO LT3117-TX-DANELET. */
            _.Move(TAB_TAXAS.TB_TAXAS[03], LBLT3117.LT3117_TX_DANELET);

            /*" -4685- MOVE TB-TAXAS (04) TO LT3117-TX-AP-EMPGDR. */
            _.Move(TAB_TAXAS.TB_TAXAS[04], LBLT3117.LT3117_TX_AP_EMPGDR);

            /*" -4686- MOVE TB-TAXAS (05) TO LT3117-TX-AP-EMP. */
            _.Move(TAB_TAXAS.TB_TAXAS[05], LBLT3117.LT3117_TX_AP_EMP);

            /*" -4689- MOVE TB-TAXAS (06) TO LT3117-TX-RC. */
            _.Move(TAB_TAXAS.TB_TAXAS[06], LBLT3117.LT3117_TX_RC);

            /*" -4737- CALL 'LT3117S' USING LT3117-TIPO-OPERACAO , LT3117-COD-LOTERICO , LT3117-NUM-CLASSE-ADESAO , LT3117-NUM-APOLICE , LT3117-DTINIVIG-APOLICE , LT3117-DTTERVIG-APOLICE , LT3117-QTD-PARCELAS , LT3117-TIPO-CALCULO , LT3117-CUSTO-APOLICE , LT3117-PCT-IOF , LT3117-TX-INCENDIO , LT3117-TX-VALORES , LT3117-TX-DANELET , LT3117-TX-AP-EMPGDR , LT3117-TX-AP-EMP , LT3117-TX-RC , LT3117-VL-IS-INCENDIO , LT3117-VL-IS-VALORES , LT3117-VL-IS-DANELET , LT3117-VL-IS-AP-EMPGDR , LT3117-VL-IS-AP-EMP , LT3117-VL-IS-RC , LT3117-IOF-PCL1 , LT3117-ADICIONAL-FRAC-PCL1 , LT3117-JUROS-PCL1 , LT3117-PERC-JUROS-PCL1 , LT3117-VL-PREMIO-LIQ-PCL1 , LT3117-VL-PREMIO-PCL1 , LT3117-IOF-PCLN , LT3117-ADICIONAL-FRAC-PCLN , LT3117-JUROS-PCLN , LT3117-PERC-JUROS-PCLN , LT3117-VL-PREMIO-LIQ-PCLN , LT3117-VL-PREMIO-PCLN , LT3117-VL-PREMIO-TOTAL , LT3117-VL-PREMIO-TOTAL-1PCL , LT3117-JURO-TOTAL , LT3117-IOF-TOTAL , LT3117-ADICIONAL-TOTAL , LT3117-PREMIO-INCENDIO , LT3117-PREMIO-VALORES , LT3117-PREMIO-DANELET , LT3117-PREMIO-AP-EMPGDR , LT3117-PREMIO-AP-EMP , LT3117-PREMIO-RC , LT3117-COD-RETORNO . */
            _.Call("LT3117S", LBLT3117, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM);

            /*" -4738- IF LT3117-COD-RETORNO > 0 */

            if (LBLT3117.LT3117_COD_RETORNO > 0)
            {

                /*" -4739- DISPLAY ' =========================================' */
                _.Display($" =========================================");

                /*" -4740- DISPLAY ' LT3117S-ERRO NO CALL LT3117S-CALCULO     ' */
                _.Display($" LT3117S-ERRO NO CALL LT3117S-CALCULO     ");

                /*" -4741- DISPLAY ' LOT=' LT3117-COD-LOTERICO */
                _.Display($" LOT={LBLT3117.LT3117_COD_LOTERICO}");

                /*" -4742- DISPLAY ' NUM-CLASSE=' LT3117-NUM-CLASSE-ADESAO */
                _.Display($" NUM-CLASSE={LBLT3117.LT3117_NUM_CLASSE_ADESAO}");

                /*" -4743- DISPLAY ' APOL=' LT3117-NUM-APOLICE */
                _.Display($" APOL={LBLT3117.LT3117_NUM_APOLICE}");

                /*" -4744- DISPLAY ' DTINIVIG=' LT3117-DTINIVIG-APOLICE */
                _.Display($" DTINIVIG={LBLT3117.LT3117_DTINIVIG_APOLICE}");

                /*" -4745- DISPLAY ' DTTERVIG=' LT3117-DTTERVIG-APOLICE */
                _.Display($" DTTERVIG={LBLT3117.LT3117_DTTERVIG_APOLICE}");

                /*" -4746- DISPLAY ' QTD PCL=' LT3117-QTD-PARCELAS */
                _.Display($" QTD PCL={LBLT3117.LT3117_QTD_PARCELAS}");

                /*" -4747- DISPLAY ' TIPO CAL=' LT3117-TIPO-CALCULO */
                _.Display($" TIPO CAL={LBLT3117.LT3117_TIPO_CALCULO}");

                /*" -4748- DISPLAY ' CUSTO =' LT3117-CUSTO-APOLICE */
                _.Display($" CUSTO ={LBLT3117.LT3117_CUSTO_APOLICE}");

                /*" -4749- DISPLAY '                  ' */
                _.Display($"                  ");

                /*" -4750- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4751- ELSE */
            }
            else
            {


                /*" -4752- MOVE LT3117-PREMIO-INCENDIO TO LKIO-PREMIO-INCENDIO */
                _.Move(LBLT3117.LT3117_PREMIO_INCENDIO, LBHLT027.LKIO_PREMIO_INCENDIO);

                /*" -4753- MOVE LT3117-PREMIO-VALORES TO LKIO-PREMIO-VALORES */
                _.Move(LBLT3117.LT3117_PREMIO_VALORES, LBHLT027.LKIO_PREMIO_VALORES);

                /*" -4754- MOVE LT3117-PREMIO-DANELET TO LKIO-PREMIO-DANELET */
                _.Move(LBLT3117.LT3117_PREMIO_DANELET, LBHLT027.LKIO_PREMIO_DANELET);

                /*" -4755- MOVE LT3117-PREMIO-AP-EMPGDR TO LKIO-PREMIO-AP-EMPGDR */
                _.Move(LBLT3117.LT3117_PREMIO_AP_EMPGDR, LBHLT027.LKIO_PREMIO_AP_EMPGDR);

                /*" -4756- MOVE LT3117-PREMIO-AP-EMP TO LKIO-PREMIO-AP-EMP */
                _.Move(LBLT3117.LT3117_PREMIO_AP_EMP, LBHLT027.LKIO_PREMIO_AP_EMP);

                /*" -4757- MOVE LT3117-PREMIO-RC TO LKIO-PREMIO-RC */
                _.Move(LBLT3117.LT3117_PREMIO_RC, LBHLT027.LKIO_PREMIO_RC);

                /*" -4758- MOVE LT3117-IOF-PCL1 TO LKIO-IOF-PCL1 */
                _.Move(LBLT3117.LT3117_IOF_PCL1, LBHLT027.LKIO_IOF_PCL1);

                /*" -4759- MOVE LT3117-ADICIONAL-FRAC-PCL1 TO LKIO-ADICIONAL-FRAC-PCL1 */
                _.Move(LBLT3117.LT3117_ADICIONAL_FRAC_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1);

                /*" -4760- MOVE LT3117-JUROS-PCL1 TO LKIO-JUROS-PCL1 */
                _.Move(LBLT3117.LT3117_JUROS_PCL1, LBHLT027.LKIO_JUROS_PCL1);

                /*" -4761- MOVE LT3117-PERC-JUROS-PCL1 TO LKIO-PERC-JUROS-PCL1 */
                _.Move(LBLT3117.LT3117_PERC_JUROS_PCL1, LBHLT027.LKIO_PERC_JUROS_PCL1);

                /*" -4762- MOVE LT3117-VL-PREMIO-LIQ-PCL1 TO LKIO-VL-PREMIO-LIQ-PCL1 */
                _.Move(LBLT3117.LT3117_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1);

                /*" -4763- MOVE LT3117-VL-PREMIO-PCL1 TO LKIO-VL-PREMIO-PCL1 */
                _.Move(LBLT3117.LT3117_VL_PREMIO_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1);

                /*" -4764- MOVE LT3117-IOF-PCLN TO LKIO-IOF-PCLN */
                _.Move(LBLT3117.LT3117_IOF_PCLN, LBHLT027.LKIO_IOF_PCLN);

                /*" -4765- MOVE LT3117-ADICIONAL-FRAC-PCLN TO LKIO-ADICIONAL-FRAC-PCLN */
                _.Move(LBLT3117.LT3117_ADICIONAL_FRAC_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN);

                /*" -4766- MOVE LT3117-JUROS-PCLN TO LKIO-JUROS-PCLN */
                _.Move(LBLT3117.LT3117_JUROS_PCLN, LBHLT027.LKIO_JUROS_PCLN);

                /*" -4767- MOVE LT3117-PERC-JUROS-PCLN TO LKIO-PERC-JUROS-PCLN */
                _.Move(LBLT3117.LT3117_PERC_JUROS_PCLN, LBHLT027.LKIO_PERC_JUROS_PCLN);

                /*" -4768- MOVE LT3117-VL-PREMIO-LIQ-PCLN TO LKIO-VL-PREMIO-LIQ-PCLN */
                _.Move(LBLT3117.LT3117_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN);

                /*" -4768- MOVE LT3117-VL-PREMIO-PCLN TO LKIO-VL-PREMIO-PCLN. */
                _.Move(LBLT3117.LT3117_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_99_SAIDA_3117_EXIT*/

        [StopWatch]
        /*" B2060-CHAMA-LT3151S-SECTION */
        private void B2060_CHAMA_LT3151S_SECTION()
        {
            /*" -4817- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -4819- INITIALIZE LT3151-AREA-PARAMETROS. */
            _.Initialize(
                LBLT3151.LT3151_AREA_PARAMETROS
            );

            /*" -4820- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -4821- MOVE 1 TO LT3151-QTD-PARCELAS */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS);

                /*" -4822- ELSE */
            }
            else
            {


                /*" -4823- MOVE ENDO-QTPARCEL TO LT3151-QTD-PARCELAS */
                _.Move(ENDO_QTPARCEL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS);

                /*" -4824- END-IF */
            }


            /*" -4826- PERFORM B2061-SELECT-LTMVPROP */

            B2061_SELECT_LTMVPROP_SECTION();

            /*" -4830- MOVE 0 TO LT3151-COD-RETORNO LT3151-VL-PREMIO-PCL1 LT3151-VL-PREMIO-PCLN LT3151-VL-PREMIO-TOTAL */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL);

            /*" -4831- MOVE LTMVPROP-VLR-CUSTO-APOLICE TO LT3151-CUSTO-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE);

            /*" -4832- MOVE LTMVPROP-PCT-IOF TO LT3151-PCT-IOF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_IOF, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF);

            /*" -4833- MOVE ' ' TO LT3151-TIPO-OPERACAO */
            _.Move(" ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_OPERACAO);

            /*" -4834- MOVE ' ' TO LT3151-TIPO-CALCULO */
            _.Move(" ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO);

            /*" -4836- MOVE 'S' TO LT3151-DISPLAY */
            _.Move("S", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DISPLAY);

            /*" -4837- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3151-COD-LOTERICO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO);

            /*" -4838- MOVE LTMVPROP-NUM-APOLICE TO LT3151-NUM-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOLICE);

            /*" -4839- MOVE LTMVPROP-DT-INIVIG-PROPOSTA TO LT3151-DTINIVIG-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE);

            /*" -4840- MOVE SPACES TO LT3151-DTTERVIG-APOLICE */
            _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE);

            /*" -4842- MOVE LTMVPROP-NUM-CLASSE-ADESAO TO LT3151-NUM-CLASSE-ADESAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO);

            /*" -4843- MOVE LTMVPROP-CGCCPF TO LT3151-CGCCPF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_CGCCPF, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CGCCPF);

            /*" -4844- MOVE LTMVPROP-IND-REGIAO TO LT3151-COD-REGIAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_REGIAO);

            /*" -4845- MOVE LTMVPROP-PCT-DESC-FIDEL TO LT3151-PCT-DESC-FIDEL */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_FIDEL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_FIDEL);

            /*" -4846- MOVE LTMVPROP-PCT-DESC-EXP TO LT3151-PCT-DESC-EXP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EXP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_EXP);

            /*" -4847- MOVE LTMVPROP-PCT-DESC-AGRUP TO LT3151-PCT-DESC-AGRUP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_AGRUP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_AGRUP);

            /*" -4848- MOVE LTMVPROP-PCT-DESC-EQUIP TO LT3151-PCT-DESC-COFRE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EQUIP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_COFRE);

            /*" -4851- MOVE LTMVPROP-PCT-DESC-BLINDAGEM TO LT3151-PCT-DESC-BLINDAGEM */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_BLINDAGEM, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_BLINDAGEM);

            /*" -4852- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                /*" -4853- MOVE TB-IMPSEG (WS-IND) TO LT3151-IMPSEG (WS-IND) */
                _.Move(TAB_IMPSEG.TB_IMPSEG[WS_IND], LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_IND].LT3151_IMPSEG);

                /*" -4854- MOVE TB-TAXAS (WS-IND) TO LT3151-TAXAS (WS-IND) */
                _.Move(TAB_TAXAS.TB_TAXAS[WS_IND], LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_IND].LT3151_TAXAS);

                /*" -4859- END-PERFORM */
            }

            /*" -4860- MOVE 0 TO LT3151-CRITICAR-PRMLIQ */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ);

            /*" -4861- MOVE 0 TO LT3151-VLR-MIN-SAP */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP);

            /*" -4862- MOVE 0 TO LT3151-VLR-MIN-PRMLIQ */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ);

            /*" -4864- MOVE 0 TO LT3151-VLR-TAXA-ADESAO */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO);

            /*" -4866- CALL 'LT3151S' USING LT3151-AREA-PARAMETROS */
            _.Call("LT3151S", LBLT3151.LT3151_AREA_PARAMETROS);

            /*" -4867- IF LT3151-COD-RETORNO > 0 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO > 0)
            {

                /*" -4868- DISPLAY ' =========================================' */
                _.Display($" =========================================");

                /*" -4869- DISPLAY ' LT3151S-ERRO NO CALL LT3151S-CALCULO     ' */
                _.Display($" LT3151S-ERRO NO CALL LT3151S-CALCULO     ");

                /*" -4870- DISPLAY ' LOT=' LT3151-COD-LOTERICO */
                _.Display($" LOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO}");

                /*" -4871- DISPLAY ' NUM-CLASSE=' LT3151-NUM-CLASSE-ADESAO */
                _.Display($" NUM-CLASSE={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO}");

                /*" -4872- DISPLAY ' APOL=' LT3151-NUM-APOLICE */
                _.Display($" APOL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOLICE}");

                /*" -4873- DISPLAY ' DTINIVIG=' LT3151-DTINIVIG-APOLICE */
                _.Display($" DTINIVIG={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE}");

                /*" -4874- DISPLAY ' DTTERVIG=' LT3151-DTTERVIG-APOLICE */
                _.Display($" DTTERVIG={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE}");

                /*" -4875- DISPLAY ' QTD PCL=' LT3151-QTD-PARCELAS */
                _.Display($" QTD PCL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS}");

                /*" -4876- DISPLAY ' TIPO CAL=' LT3151-TIPO-CALCULO */
                _.Display($" TIPO CAL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO}");

                /*" -4877- DISPLAY ' CUSTO =' LT3151-CUSTO-APOLICE */
                _.Display($" CUSTO ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE}");

                /*" -4878- DISPLAY ' IOF   =' LT3151-PCT-IOF */
                _.Display($" IOF   ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF}");

                /*" -4879- DISPLAY ' PREMIO LIQ  =' LT3151-VL-PREMIO-LIQ */
                _.Display($" PREMIO LIQ  ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ}");

                /*" -4880- DISPLAY ' PREMIO TOTAL=' LT3151-VL-PREMIO-TOTAL */
                _.Display($" PREMIO TOTAL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL}");

                /*" -4881- DISPLAY ' NUM-CLASSE  =' LT3151-NUM-CLASSE-ADESAO */
                _.Display($" NUM-CLASSE  ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO}");

                /*" -4882- DISPLAY ' QTD-PARCELAS=' LT3151-QTD-PARCELAS */
                _.Display($" QTD-PARCELAS={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS}");

                /*" -4883- DISPLAY ' =========================================' */
                _.Display($" =========================================");

                /*" -4884- DISPLAY 'COD-RET=' LT3151-COD-RETORNO */
                _.Display($"COD-RET={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO}");

                /*" -4885- DISPLAY 'MSG-RET=' LT3151-MSG-RETORNO */
                _.Display($"MSG-RET={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO}");

                /*" -4886- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4888- END-IF */
            }


            /*" -4890- MOVE LT3151-CUSTO-APOLICE TO LKIO-CUSTO-APOLICE */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE, LBHLT027.LKIO_CUSTO_APOLICE);

            /*" -4892- MOVE LT3151-QTD-PARCELAS TO LKIO-QTD-PARCELAS */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS, LBHLT027.LKIO_QTD_PARCELAS);

            /*" -4893- MOVE LT3151-VL-PREMIO-LIQ-PCL1 TO LKIO-VL-PREMIO-LIQ-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1);

            /*" -4894- MOVE LT3151-JUROS-PCL1 TO LKIO-ADICIONAL-FRAC-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1);

            /*" -4895- MOVE LT3151-IOF-PCL1 TO LKIO-IOF-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1, LBHLT027.LKIO_IOF_PCL1);

            /*" -4897- MOVE LT3151-VL-PREMIO-PCL1 TO LKIO-VL-PREMIO-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1);

            /*" -4898- MOVE LT3151-VL-PREMIO-LIQ-PCLN TO LKIO-VL-PREMIO-LIQ-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN);

            /*" -4899- MOVE LT3151-JUROS-PCLN TO LKIO-ADICIONAL-FRAC-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN);

            /*" -4900- MOVE LT3151-IOF-PCLN TO LKIO-IOF-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN, LBHLT027.LKIO_IOF_PCLN);

            /*" -4917- MOVE LT3151-VL-PREMIO-PCLN TO LKIO-VL-PREMIO-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN);

            /*" -4917- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_99_SAIDA_3151*/

        [StopWatch]
        /*" B2061-SELECT-LTMVPROP-SECTION */
        private void B2061_SELECT_LTMVPROP_SECTION()
        {
            /*" -4927- MOVE 'B2061' TO WNR-EXEC-SQL. */
            _.Move("B2061", WABEND.WNR_EXEC_SQL);

            /*" -4935- PERFORM B2061_SELECT_LTMVPROP_DB_SELECT_1 */

            B2061_SELECT_LTMVPROP_DB_SELECT_1();

            /*" -4938- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4940- DISPLAY ' B2061 -ERRO SELECT MAX SEQ LT_MOV_PROPOSTA' ' ' ENDO-NUM-APOLICE */

                $" B2061 -ERRO SELECT MAX SEQ LT_MOV_PROPOSTA {ENDO_NUM_APOLICE}"
                .Display();

                /*" -4942- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4997- PERFORM B2061_SELECT_LTMVPROP_DB_SELECT_2 */

            B2061_SELECT_LTMVPROP_DB_SELECT_2();

            /*" -5000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5003- DISPLAY 'B2061-ERRO SELECT LT_MOV_PROPOSTA' 'APO=' ENDO-NUM-APOLICE 'SEQ=' LTMVPROP-SEQ-PROPOSTA */

                $"B2061-ERRO SELECT LT_MOV_PROPOSTAAPO={ENDO_NUM_APOLICE}SEQ={LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA}"
                .Display();

                /*" -5005- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5006- MOVE LTMVPROP-COD-EXT-SEGURADO TO LTMVPRCO-COD-EXT-SEGURADO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_EXT_SEGURADO);

            /*" -5007- MOVE LTMVPROP-DATA-MOVIMENTO TO LTMVPRCO-DATA-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_DATA_MOVIMENTO);

            /*" -5008- MOVE LTMVPROP-HORA-MOVIMENTO TO LTMVPRCO-HORA-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_HORA_MOVIMENTO);

            /*" -5009- MOVE LTMVPROP-COD-PRODUTO TO LTMVPRCO-COD-PRODUTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PRODUTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_PRODUTO);

            /*" -5010- MOVE LTMVPROP-COD-EXT-ESTIP TO LTMVPRCO-COD-EXT-ESTIP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_ESTIP, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_EXT_ESTIP);

            /*" -5012- MOVE LTMVPROP-COD-MOVIMENTO TO LTMVPRCO-COD-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_MOVIMENTO);

            /*" -5013- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                /*" -5015- MOVE 0 TO TB-IMPSEG (WS-IND) TB-TAXAS (WS-IND) */
                _.Move(0, TAB_IMPSEG.TB_IMPSEG[WS_IND], TAB_TAXAS.TB_TAXAS[WS_IND]);

                /*" -5017- END-PERFORM. */
            }

            /*" -5018- PERFORM B2061-00-SELECT-COBER VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20. */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                B2061_00_SELECT_COBER_SECTION();
            }

        }

        [StopWatch]
        /*" B2061-SELECT-LTMVPROP-DB-SELECT-1 */
        public void B2061_SELECT_LTMVPROP_DB_SELECT_1()
        {
            /*" -4935- EXEC SQL SELECT VALUE(MAX(SEQ_PROPOSTA),0) INTO :LTMVPROP-SEQ-PROPOSTA FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO IN ( '1' , 'T' ) WITH UR END-EXEC. */

            var b2061_SELECT_LTMVPROP_DB_SELECT_1_Query1 = new B2061_SELECT_LTMVPROP_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
            };

            var executed_1 = B2061_SELECT_LTMVPROP_DB_SELECT_1_Query1.Execute(b2061_SELECT_LTMVPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_SEQ_PROPOSTA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2061_999_EXIT*/

        [StopWatch]
        /*" B2061-SELECT-LTMVPROP-DB-SELECT-2 */
        public void B2061_SELECT_LTMVPROP_DB_SELECT_2()
        {
            /*" -4997- EXEC SQL SELECT COD_EXT_SEGURADO , COD_CLASSE_ADESAO , NUM_CLASSE_ADESAO , COMPL_ENDER , DT_INIVIG_PROPOSTA , NUM_APOLICE , QTD_PARCELAS , VLR_JUROS_MENSAL , VLR_CUSTO_APOLICE , PCT_JUROS , DATA_MOVIMENTO , HORA_MOVIMENTO , COD_MOVIMENTO , SIT_MOVIMENTO , COD_PRODUTO , COD_EXT_ESTIP , PCT_IOF , CGCCPF , IND_REGIAO , PCT_DESC_FIDEL , PCT_DESC_EXP , PCT_DESC_AGRUP , PCT_DESC_EQUIP , PCT_DESC_BLINDAGEM INTO :LTMVPROP-COD-EXT-SEGURADO , :LTMVPROP-COD-CLASSE-ADESAO , :LTMVPROP-NUM-CLASSE-ADESAO , :LTMVPROP-COMPL-ENDER , :LTMVPROP-DT-INIVIG-PROPOSTA , :LTMVPROP-NUM-APOLICE , :LTMVPROP-QTD-PARCELAS , :LTMVPROP-VLR-JUROS-MENSAL , :LTMVPROP-VLR-CUSTO-APOLICE , :LTMVPROP-PCT-JUROS , :LTMVPROP-DATA-MOVIMENTO , :LTMVPROP-HORA-MOVIMENTO , :LTMVPROP-COD-MOVIMENTO , :LTMVPROP-SIT-MOVIMENTO , :LTMVPROP-COD-PRODUTO , :LTMVPROP-COD-EXT-ESTIP , :LTMVPROP-PCT-IOF , :LTMVPROP-CGCCPF , :LTMVPROP-IND-REGIAO , :LTMVPROP-PCT-DESC-FIDEL , :LTMVPROP-PCT-DESC-EXP , :LTMVPROP-PCT-DESC-AGRUP , :LTMVPROP-PCT-DESC-EQUIP , :LTMVPROP-PCT-DESC-BLINDAGEM FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND SEQ_PROPOSTA = :LTMVPROP-SEQ-PROPOSTA AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO IN ( '1' , 'T' ) WITH UR END-EXEC. */

            var b2061_SELECT_LTMVPROP_DB_SELECT_2_Query1 = new B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1()
            {
                LTMVPROP_SEQ_PROPOSTA = LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
            };

            var executed_1 = B2061_SELECT_LTMVPROP_DB_SELECT_2_Query1.Execute(b2061_SELECT_LTMVPROP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_COD_EXT_SEGURADO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO);
                _.Move(executed_1.LTMVPROP_COD_CLASSE_ADESAO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_CLASSE_ADESAO);
                _.Move(executed_1.LTMVPROP_NUM_CLASSE_ADESAO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO);
                _.Move(executed_1.LTMVPROP_COMPL_ENDER, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COMPL_ENDER);
                _.Move(executed_1.LTMVPROP_DT_INIVIG_PROPOSTA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA);
                _.Move(executed_1.LTMVPROP_NUM_APOLICE, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE);
                _.Move(executed_1.LTMVPROP_QTD_PARCELAS, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_QTD_PARCELAS);
                _.Move(executed_1.LTMVPROP_VLR_JUROS_MENSAL, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_JUROS_MENSAL);
                _.Move(executed_1.LTMVPROP_VLR_CUSTO_APOLICE, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE);
                _.Move(executed_1.LTMVPROP_PCT_JUROS, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_JUROS);
                _.Move(executed_1.LTMVPROP_DATA_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_HORA_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_COD_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_SIT_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SIT_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_COD_PRODUTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PRODUTO);
                _.Move(executed_1.LTMVPROP_COD_EXT_ESTIP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_ESTIP);
                _.Move(executed_1.LTMVPROP_PCT_IOF, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_IOF);
                _.Move(executed_1.LTMVPROP_CGCCPF, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_CGCCPF);
                _.Move(executed_1.LTMVPROP_IND_REGIAO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO);
                _.Move(executed_1.LTMVPROP_PCT_DESC_FIDEL, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_FIDEL);
                _.Move(executed_1.LTMVPROP_PCT_DESC_EXP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EXP);
                _.Move(executed_1.LTMVPROP_PCT_DESC_AGRUP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_AGRUP);
                _.Move(executed_1.LTMVPROP_PCT_DESC_EQUIP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EQUIP);
                _.Move(executed_1.LTMVPROP_PCT_DESC_BLINDAGEM, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_BLINDAGEM);
            }


        }

        [StopWatch]
        /*" B2061-00-SELECT-COBER-SECTION */
        private void B2061_00_SELECT_COBER_SECTION()
        {
            /*" -5030- MOVE WS-IND TO LTMVPRCO-COD-COBERTURA. */
            _.Move(WS_IND, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_COBERTURA);

            /*" -5044- PERFORM B2061_00_SELECT_COBER_DB_SELECT_1 */

            B2061_00_SELECT_COBER_DB_SELECT_1();

            /*" -5050- IF SQLCODE NOT EQUAL TO ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5052- GO TO B2061-99-SAIDA-COBER. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2061_99_SAIDA_COBER*/ //GOTO
                return;
            }


            /*" -5053- MOVE LTMVPRCO-VAL-TAXA-PREMIO TO TB-TAXAS (WS-IND) */
            _.Move(LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_VAL_TAXA_PREMIO, TAB_TAXAS.TB_TAXAS[WS_IND]);

            /*" -5053- MOVE LTMVPRCO-VAL-IMP-SEGURADA TO TB-IMPSEG (WS-IND). */
            _.Move(LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_VAL_IMP_SEGURADA, TAB_IMPSEG.TB_IMPSEG[WS_IND]);

        }

        [StopWatch]
        /*" B2061-00-SELECT-COBER-DB-SELECT-1 */
        public void B2061_00_SELECT_COBER_DB_SELECT_1()
        {
            /*" -5044- EXEC SQL SELECT LTMVPRCO.VAL_IMP_SEGURADA , LTMVPRCO.VAL_TAXA_PREMIO INTO :LTMVPRCO-VAL-IMP-SEGURADA , :LTMVPRCO-VAL-TAXA-PREMIO FROM SEGUROS.LT_MOV_PROP_COBER LTMVPRCO WHERE LTMVPRCO.COD_EXT_SEGURADO = :LTMVPRCO-COD-EXT-SEGURADO AND LTMVPRCO.DATA_MOVIMENTO = :LTMVPRCO-DATA-MOVIMENTO AND LTMVPRCO.HORA_MOVIMENTO = :LTMVPRCO-HORA-MOVIMENTO AND LTMVPRCO.COD_PRODUTO = :LTMVPRCO-COD-PRODUTO AND LTMVPRCO.COD_EXT_ESTIP = :LTMVPRCO-COD-EXT-ESTIP AND LTMVPRCO.COD_COBERTURA = :LTMVPRCO-COD-COBERTURA AND LTMVPRCO.COD_MOVIMENTO = :LTMVPRCO-COD-MOVIMENTO WITH UR END-EXEC. */

            var b2061_00_SELECT_COBER_DB_SELECT_1_Query1 = new B2061_00_SELECT_COBER_DB_SELECT_1_Query1()
            {
                LTMVPRCO_COD_EXT_SEGURADO = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_EXT_SEGURADO.ToString(),
                LTMVPRCO_DATA_MOVIMENTO = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_DATA_MOVIMENTO.ToString(),
                LTMVPRCO_HORA_MOVIMENTO = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_HORA_MOVIMENTO.ToString(),
                LTMVPRCO_COD_EXT_ESTIP = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_EXT_ESTIP.ToString(),
                LTMVPRCO_COD_COBERTURA = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_COBERTURA.ToString(),
                LTMVPRCO_COD_MOVIMENTO = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_MOVIMENTO.ToString(),
                LTMVPRCO_COD_PRODUTO = LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_PRODUTO.ToString(),
            };

            var executed_1 = B2061_00_SELECT_COBER_DB_SELECT_1_Query1.Execute(b2061_00_SELECT_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPRCO_VAL_IMP_SEGURADA, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_VAL_IMP_SEGURADA);
                _.Move(executed_1.LTMVPRCO_VAL_TAXA_PREMIO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_VAL_TAXA_PREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2061_99_SAIDA_COBER*/

        [StopWatch]
        /*" B2062-MONTA-PARCELA-SECTION */
        private void B2062_MONTA_PARCELA_SECTION()
        {
            /*" -5067- MOVE 'B2062' TO WNR-EXEC-SQL. */
            _.Move("B2062", WABEND.WNR_EXEC_SQL);

            /*" -5070- MOVE ZEROS TO VL-DESC-IX VL-DESCONTO */
            _.Move(0, EM0901W099.VL_DESC_IX, EM0901W099.VL_DESCONTO);

            /*" -5071- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -5074- COMPUTE WS-PREMIO-LIQ = LKIO-VL-PREMIO-LIQ-PCL1 - LKIO-ADICIONAL-FRAC-PCL1 */
                WS_PREMIO_LIQ.Value = LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1 - LBHLT027.LKIO_ADICIONAL_FRAC_PCL1;

                /*" -5077- MOVE LKIO-ADICIONAL-FRAC-PCL1 TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBHLT027.LKIO_ADICIONAL_FRAC_PCL1, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5079- MOVE LKIO-CUSTO-APOLICE TO VL-CUSTO-IX VL-CUSTO */
                _.Move(LBHLT027.LKIO_CUSTO_APOLICE, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5081- MOVE LKIO-IOF-PCL1 TO VL-IOF-IX VL-IOF */
                _.Move(LBHLT027.LKIO_IOF_PCL1, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5083- MOVE LKIO-VL-PREMIO-PCL1 TO VL-TOTAL-IX VL-TOTAL */
                _.Move(LBHLT027.LKIO_VL_PREMIO_PCL1, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);

                /*" -5084- ELSE */
            }
            else
            {


                /*" -5087- COMPUTE WS-PREMIO-LIQ = LKIO-VL-PREMIO-LIQ-PCLN - LKIO-ADICIONAL-FRAC-PCLN */
                WS_PREMIO_LIQ.Value = LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN - LBHLT027.LKIO_ADICIONAL_FRAC_PCLN;

                /*" -5090- MOVE LKIO-ADICIONAL-FRAC-PCLN TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBHLT027.LKIO_ADICIONAL_FRAC_PCLN, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5092- MOVE ZEROS TO VL-CUSTO-IX VL-CUSTO */
                _.Move(0, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5094- MOVE LKIO-IOF-PCLN TO VL-IOF-IX VL-IOF */
                _.Move(LBHLT027.LKIO_IOF_PCLN, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5097- MOVE LKIO-VL-PREMIO-PCLN TO VL-TOTAL-IX VL-TOTAL. */
                _.Move(LBHLT027.LKIO_VL_PREMIO_PCLN, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);
            }


            /*" -5100- MOVE WS-PREMIO-LIQ TO VL-LIQ-IX VL-LIQUIDO VL-TARIFARIO-IX VL-TARIFA. */
            _.Move(WS_PREMIO_LIQ, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2062_999_EXIT*/

        [StopWatch]
        /*" B2063-CHAMA-LT2118S-SECTION */
        private void B2063_CHAMA_LT2118S_SECTION()
        {
            /*" -5113- MOVE 'B2063' TO WNR-EXEC-SQL. */
            _.Move("B2063", WABEND.WNR_EXEC_SQL);

            /*" -5115- INITIALIZE LT2118S-AREA-PARAMETROS. */
            _.Initialize(
                LBLT2118.LT2118S_AREA_PARAMETROS
            );

            /*" -5120- PERFORM B2064-SELECT-LTMVPROP */

            B2064_SELECT_LTMVPROP_SECTION();

            /*" -5121- MOVE 1 TO LT2118S-TIPO-CALCULO */
            _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_TIPO_CALCULO);

            /*" -5122- MOVE LTMVPROP-COD-MOVIMENTO TO LT2118S-COD-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO);

            /*" -5123- MOVE ENDO-NUM-APOLICE TO LT2118S-NUM-APOLICE */
            _.Move(ENDO_NUM_APOLICE, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE);

            /*" -5124- MOVE ENDO-DTINIVIG TO LT2118S-DATA-INIVIGENCIA */
            _.Move(ENDO_DTINIVIG, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA);

            /*" -5126- MOVE LTMVPROP-NUM-CLASSE-ADESAO TO LT2118S-NUM-CLASSE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_CLASSE);

            /*" -5127- MOVE LTMVPROP-IND-REGIAO TO LT2118S-IND-REGIAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_IND_REGIAO);

            /*" -5128- MOVE LTMVPROP-PCT-DESC-AGRUP TO LT2118S-PCT-DESC-AGRUP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_AGRUP, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_AGRUP);

            /*" -5129- MOVE LTMVPROP-PCT-DESC-FIDEL TO LT2118S-PCT-DESC-FIDEL */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_FIDEL, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_FIDEL);

            /*" -5130- MOVE LTMVPROP-PCT-DESC-EXP TO LT2118S-PCT-DESC-EXP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EXP, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_EXP);

            /*" -5131- MOVE LTMVPROP-PCT-DESC-EQUIP TO LT2118S-PCT-DESC-COFRE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EQUIP, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_COFRE);

            /*" -5134- MOVE LTMVPROP-PCT-DESC-BLINDAGEM TO LT2118S-PCT-DESC-BLINDAGEM */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_BLINDAGEM, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_BLINDAGEM);

            /*" -5135- MOVE ENDO-ISENTA-CUSTO TO LT2118S-ISENTA-CUSTO */
            _.Move(ENDO_ISENTA_CUSTO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO);

            /*" -5136- MOVE COBE-TARIFARIO-VAR TO LT2118S-PRM-TARIFARIO-TOTAL */
            _.Move(COBE_TARIFARIO_VAR, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL);

            /*" -5137- MOVE 0 TO LT2118S-PRM-TARIFARIO-1PCL */
            _.Move(0, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL);

            /*" -5143- MOVE LTMVPROP-VLR-CUSTO-APOLICE TO LT2118S-CUSTO-EMISSAO-1 */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1);

            /*" -5144- IF ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' */

            if (ENDO_TIPO_ENDOSSO.In("3", "5"))
            {

                /*" -5147- COMPUTE LT2118S-PRM-TARIFARIO-TOTAL = LT2118S-PRM-TARIFARIO-TOTAL * -1. */
                LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * -1;
            }


            /*" -5148- IF ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' */

            if (ENDO_TIPO_ENDOSSO.In("3", "5"))
            {

                /*" -5153- COMPUTE LT2118S-PRM-TARIFARIO-1PCL = LT2118S-PRM-TARIFARIO-1PCL * -1. */
                LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL * -1;
            }


            /*" -5154- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -5155- MOVE 1 TO LT2118S-QTD-PARCELAS */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS);

                /*" -5156- ELSE */
            }
            else
            {


                /*" -5158- MOVE ENDO-QTPARCEL TO LT2118S-QTD-PARCELAS. */
                _.Move(ENDO_QTPARCEL, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS);
            }


            /*" -5160- CALL 'LT2118S' USING LT2118S-AREA-PARAMETROS. */
            _.Call("LT2118S", LBLT2118.LT2118S_AREA_PARAMETROS);

            /*" -5161- IF LT2118S-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO != 00)
            {

                /*" -5163- DISPLAY ' PROBLEMAS NA ROTINA LT2118S:' ' ' LT2118S-MSG-RETORNO */

                $" PROBLEMAS NA ROTINA LT2118S: {LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO}"
                .Display();

                /*" -5165- DISPLAY ' PARAMETROS DE ENTRADA:' ' ' LT2118S-ENTRADA */

                $" PARAMETROS DE ENTRADA: {LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA}"
                .Display();

                /*" -5166- DISPLAY 'APOLICE ... ' ENDO-NUM-APOLICE */
                _.Display($"APOLICE ... {ENDO_NUM_APOLICE}");

                /*" -5167- DISPLAY 'ENDOSSO ... ' ENDO-NRENDOS */
                _.Display($"ENDOSSO ... {ENDO_NRENDOS}");

                /*" -5167- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2063_999_EXIT*/

        [StopWatch]
        /*" B2064-SELECT-LTMVPROP-SECTION */
        private void B2064_SELECT_LTMVPROP_SECTION()
        {
            /*" -5177- MOVE 'B2064' TO WNR-EXEC-SQL. */
            _.Move("B2064", WABEND.WNR_EXEC_SQL);

            /*" -5204- PERFORM B2064_SELECT_LTMVPROP_DB_SELECT_1 */

            B2064_SELECT_LTMVPROP_DB_SELECT_1();

            /*" -5207- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -5210- DISPLAY 'ERRO SELECT LT_MOV_PROPOSTA' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $"ERRO SELECT LT_MOV_PROPOSTA {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -5210- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2064-SELECT-LTMVPROP-DB-SELECT-1 */
        public void B2064_SELECT_LTMVPROP_DB_SELECT_1()
        {
            /*" -5204- EXEC SQL SELECT COD_MOVIMENTO , VLR_JUROS_MENSAL , VLR_CUSTO_APOLICE , NUM_CLASSE_ADESAO , IND_REGIAO , PCT_DESC_AGRUP , PCT_DESC_FIDEL , PCT_DESC_EXP , PCT_DESC_EQUIP , PCT_DESC_BLINDAGEM INTO :LTMVPROP-COD-MOVIMENTO , :LTMVPROP-VLR-JUROS-MENSAL , :LTMVPROP-VLR-CUSTO-APOLICE , :LTMVPROP-NUM-CLASSE-ADESAO , :LTMVPROP-IND-REGIAO , :LTMVPROP-PCT-DESC-AGRUP , :LTMVPROP-PCT-DESC-FIDEL , :LTMVPROP-PCT-DESC-EXP , :LTMVPROP-PCT-DESC-EQUIP , :LTMVPROP-PCT-DESC-BLINDAGEM FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS AND COD_MOVIMENTO IN ( 'A' , 'C' , 'T' ) AND SIT_MOVIMENTO = '1' WITH UR END-EXEC. */

            var b2064_SELECT_LTMVPROP_DB_SELECT_1_Query1 = new B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2064_SELECT_LTMVPROP_DB_SELECT_1_Query1.Execute(b2064_SELECT_LTMVPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTMVPROP_COD_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO);
                _.Move(executed_1.LTMVPROP_VLR_JUROS_MENSAL, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_JUROS_MENSAL);
                _.Move(executed_1.LTMVPROP_VLR_CUSTO_APOLICE, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE);
                _.Move(executed_1.LTMVPROP_NUM_CLASSE_ADESAO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO);
                _.Move(executed_1.LTMVPROP_IND_REGIAO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO);
                _.Move(executed_1.LTMVPROP_PCT_DESC_AGRUP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_AGRUP);
                _.Move(executed_1.LTMVPROP_PCT_DESC_FIDEL, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_FIDEL);
                _.Move(executed_1.LTMVPROP_PCT_DESC_EXP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EXP);
                _.Move(executed_1.LTMVPROP_PCT_DESC_EQUIP, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EQUIP);
                _.Move(executed_1.LTMVPROP_PCT_DESC_BLINDAGEM, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_BLINDAGEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2064_999_EXIT*/

        [StopWatch]
        /*" B2065-MONTA-PARCELA-SECTION */
        private void B2065_MONTA_PARCELA_SECTION()
        {
            /*" -5225- MOVE 'B2065' TO WNR-EXEC-SQL. */
            _.Move("B2065", WABEND.WNR_EXEC_SQL);

            /*" -5228- MOVE ZEROS TO VL-DESC-IX VL-DESCONTO */
            _.Move(0, EM0901W099.VL_DESC_IX, EM0901W099.VL_DESCONTO);

            /*" -5229- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -5231- MOVE LT2118S-PRM-LIQUIDO-1 TO VL-LIQ-IX VL-LIQUIDO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO);

                /*" -5234- MOVE LT2118S-PRM-TARIFARIO-1 TO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -5237- MOVE LT2118S-ADICIONAL-FRACIO-1 TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5240- MOVE LT2118S-CUSTO-EMISSAO-1 TO VL-CUSTO-IX VL-CUSTO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5242- MOVE LT2118S-VAL-IOCC-1 TO VL-IOF-IX VL-IOF */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_VAL_IOCC_1, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5244- MOVE LT2118S-PRM-TOTAL-1 TO VL-TOTAL-IX VL-TOTAL */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TOTAL_1, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);

                /*" -5245- ELSE */
            }
            else
            {


                /*" -5247- MOVE LT2118S-PRM-LIQUIDO-N TO VL-LIQ-IX VL-LIQUIDO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_LIQUIDO_N, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO);

                /*" -5250- MOVE LT2118S-PRM-TARIFARIO-N TO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TARIFARIO_N, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -5253- MOVE LT2118S-ADICIONAL-FRACIO-N TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_ADICIONAL_FRACIO_N, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5256- MOVE LT2118S-CUSTO-EMISSAO-N TO VL-CUSTO-IX VL-CUSTO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_CUSTO_EMISSAO_N, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5258- MOVE LT2118S-VAL-IOCC-N TO VL-IOF-IX VL-IOF */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_VAL_IOCC_N, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5259- MOVE LT2118S-PRM-TOTAL-N TO VL-TOTAL-IX VL-TOTAL. */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TOTAL_N, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2065_999_EXIT*/

        [StopWatch]
        /*" B2070-SELECT-V0NOVACAO-SECTION */
        private void B2070_SELECT_V0NOVACAO_SECTION()
        {
            /*" -5270- MOVE 'B2070' TO WNR-EXEC-SQL. */
            _.Move("B2070", WABEND.WNR_EXEC_SQL);

            /*" -5280- PERFORM B2070_SELECT_V0NOVACAO_DB_SELECT_1 */

            B2070_SELECT_V0NOVACAO_DB_SELECT_1();

            /*" -5283- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5284- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5286- DISPLAY 'B2070 - ENDOSSO NAO CADASTRADO NA V0NOVACAO' */
                    _.Display($"B2070 - ENDOSSO NAO CADASTRADO NA V0NOVACAO");

                    /*" -5289- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'ENDOSSO:  ' ENDO-NRENDOS '  ' 'DTINIVIG: ' ENDO-DTINIVIG */

                    $"APOLICE:  {ENDO_NUM_APOLICE}  ENDOSSO:  {ENDO_NRENDOS}  DTINIVIG: {ENDO_DTINIVIG}"
                    .Display();

                    /*" -5290- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5291- ELSE */
                }
                else
                {


                    /*" -5292- DISPLAY 'ERRO SELECT V0NOVACAO' */
                    _.Display($"ERRO SELECT V0NOVACAO");

                    /*" -5294- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5295- COMPUTE WS000-IOF-RAMO68 = V0NOVA-VL-IOF-MIP + V0NOVA-VL-IOF-DFI. */
            WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68.Value = V0NOVA_VL_IOF_MIP + V0NOVA_VL_IOF_DFI;

        }

        [StopWatch]
        /*" B2070-SELECT-V0NOVACAO-DB-SELECT-1 */
        public void B2070_SELECT_V0NOVACAO_DB_SELECT_1()
        {
            /*" -5280- EXEC SQL SELECT VALUE(SUM(VAL_IOF_MIP),0), VALUE(SUM(VAL_IOF_DFI),0) INTO :V0NOVA-VL-IOF-MIP, :V0NOVA-VL-IOF-DFI FROM SEGUROS.V0NOVACAO WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND DTMOVTO = :ENDO-DTINIVIG WITH UR END-EXEC. */

            var b2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1 = new B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_DTINIVIG = ENDO_DTINIVIG.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1.Execute(b2070_SELECT_V0NOVACAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0NOVA_VL_IOF_MIP, V0NOVA_VL_IOF_MIP);
                _.Move(executed_1.V0NOVA_VL_IOF_DFI, V0NOVA_VL_IOF_DFI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2070_999_EXIT*/

        [StopWatch]
        /*" B2080-SELECT-V0PREMIO-HAB-SECTION */
        private void B2080_SELECT_V0PREMIO_HAB_SECTION()
        {
            /*" -5304- MOVE 'B2080' TO WNR-EXEC-SQL. */
            _.Move("B2080", WABEND.WNR_EXEC_SQL);

            /*" -5305- IF ENDO-CODSUBES = 0 */

            if (ENDO_CODSUBES == 0)
            {

                /*" -5321- PERFORM B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1 */

                B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1();

                /*" -5323- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5325- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5326- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5327- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5329- DISPLAY 'B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5332- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5334- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5335- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5336- ELSE */
                    }
                    else
                    {


                        /*" -5337- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5339- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5340- IF ENDO-CODSUBES > 0 */

            if (ENDO_CODSUBES > 0)
            {

                /*" -5360- PERFORM B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2 */

                B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2();

                /*" -5362- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5364- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5365- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5366- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5368- DISPLAY 'B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5371- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5373- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5374- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5375- ELSE */
                    }
                    else
                    {


                        /*" -5376- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5378- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5378- MOVE V0PRHA-VAL-IOF-TOTAL TO WS000-IOF-RAMO68. */
            _.Move(V0PRHA_VAL_IOF_TOTAL, WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68);

        }

        [StopWatch]
        /*" B2080-SELECT-V0PREMIO-HAB-DB-SELECT-1 */
        public void B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1()
        {
            /*" -5321- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_TOT),0) + VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM < '3' AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO WITH UR END-EXEC */

            var b2080_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1 = new B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1()
            {
                V0PRHA_CODCLIEN = V0PRHA_CODCLIEN.ToString(),
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1.Execute(b2080_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2080_999_EXIT*/

        [StopWatch]
        /*" B2080-SELECT-V0PREMIO-HAB-DB-SELECT-2 */
        public void B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2()
        {
            /*" -5360- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_TOT),0) + VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C, SEGUROS.V0AGENTE_FINANC A WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM < '3' AND R.COD_SUBESTIPULANTE = A.COD_AGENTE AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO AND A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.COD_SUBGRUPO = :ENDO-CODSUBES WITH UR END-EXEC */

            var b2080_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1 = new B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                V0PRHA_CODCLIEN = V0PRHA_CODCLIEN.ToString(),
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
                ENDO_CODSUBES = ENDO_CODSUBES.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1.Execute(b2080_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL);
            }


        }

        [StopWatch]
        /*" B2081-SELECT-V0PREMIO-HAB-SECTION */
        private void B2081_SELECT_V0PREMIO_HAB_SECTION()
        {
            /*" -5389- MOVE 'B2081' TO WNR-EXEC-SQL. */
            _.Move("B2081", WABEND.WNR_EXEC_SQL);

            /*" -5390- IF ENDO-CODSUBES = 0 */

            if (ENDO_CODSUBES == 0)
            {

                /*" -5406- PERFORM B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1 */

                B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1();

                /*" -5408- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5410- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5411- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5412- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5414- DISPLAY 'B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5417- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5419- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5420- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5421- ELSE */
                    }
                    else
                    {


                        /*" -5422- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5424- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5425- IF ENDO-CODSUBES > 0 */

            if (ENDO_CODSUBES > 0)
            {

                /*" -5445- PERFORM B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2 */

                B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2();

                /*" -5447- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5449- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5450- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5451- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5453- DISPLAY 'B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5456- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5458- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5459- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5460- ELSE */
                    }
                    else
                    {


                        /*" -5461- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5463- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5463- MOVE V0PRHA-VAL-IOF-TOTAL TO WS000-IOF-RAMO68. */
            _.Move(V0PRHA_VAL_IOF_TOTAL, WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68);

        }

        [StopWatch]
        /*" B2081-SELECT-V0PREMIO-HAB-DB-SELECT-1 */
        public void B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1()
        {
            /*" -5406- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM = '3' AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO WITH UR END-EXEC */

            var b2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1 = new B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1()
            {
                V0PRHA_CODCLIEN = V0PRHA_CODCLIEN.ToString(),
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1.Execute(b2081_SELECT_V0PREMIO_HAB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2081_999_EXIT*/

        [StopWatch]
        /*" B2081-SELECT-V0PREMIO-HAB-DB-SELECT-2 */
        public void B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2()
        {
            /*" -5445- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C, SEGUROS.V0AGENTE_FINANC A WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM = '3' AND R.COD_SUBESTIPULANTE = A.COD_AGENTE AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO AND A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.COD_SUBGRUPO = :ENDO-CODSUBES WITH UR END-EXEC */

            var b2081_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1 = new B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                V0PRHA_CODCLIEN = V0PRHA_CODCLIEN.ToString(),
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
                ENDO_CODSUBES = ENDO_CODSUBES.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1.Execute(b2081_SELECT_V0PREMIO_HAB_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL);
            }


        }

        [StopWatch]
        /*" B2100-MONTA-201-SECTION */
        private void B2100_MONTA_201_SECTION()
        {
            /*" -5477- MOVE 0201 TO HIST-OPERACAO. */
            _.Move(0201, HIST_OPERACAO);

            /*" -5478- MOVE PCOM-NRAVISO TO HIST-NRAVISO. */
            _.Move(PCOM_NRAVISO, HIST_NRAVISO);

            /*" -5479- MOVE PCOM-AGEAVISO TO HIST-AGECOBR. */
            _.Move(PCOM_AGEAVISO, HIST_AGECOBR);

            /*" -5480- MOVE 2 TO HIST-OCORHIST. */
            _.Move(2, HIST_OCORHIST);

            /*" -5481- MOVE ENDO-DATARCAP TO HIST-DTQITBCO. */
            _.Move(ENDO_DATARCAP, HIST_DTQITBCO);

            /*" -5482- MOVE 'MOV2-DTQITBCO                ' TO WS-MOV-DTQITBCO */
            _.Move("MOV2-DTQITBCO                ", WS_MOV_DTQITBCO);

            /*" -5483- MOVE ENDO-VLRCAP TO HIST-VLPREMIO. */
            _.Move(ENDO_VLRCAP, HIST_VLPREMIO);

            /*" -5483- MOVE 0 TO HIST-DTQITBCO-I. */
            _.Move(0, HIST_DTQITBCO_I);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2100_999_EXIT*/

        [StopWatch]
        /*" B2110-MONTA-208-SECTION */
        private void B2110_MONTA_208_SECTION()
        {
            /*" -5493- MOVE 0208 TO HIST-OPERACAO. */
            _.Move(0208, HIST_OPERACAO);

            /*" -5494- MOVE ZEROS TO HIST-NRAVISO. */
            _.Move(0, HIST_NRAVISO);

            /*" -5495- MOVE ZEROS TO HIST-AGECOBR. */
            _.Move(0, HIST_AGECOBR);

            /*" -5496- MOVE 2 TO HIST-OCORHIST. */
            _.Move(2, HIST_OCORHIST);

            /*" -5497- MOVE ENDO-DTINIVIG TO HIST-DTQITBCO. */
            _.Move(ENDO_DTINIVIG, HIST_DTQITBCO);

            /*" -5498- MOVE 'MOV1-DTQITBCO' TO WS-MOV-DTQITBCO */
            _.Move("MOV1-DTQITBCO", WS_MOV_DTQITBCO);

            /*" -5499- MOVE ENDO-VLRCAP TO HIST-VLPREMIO. */
            _.Move(ENDO_VLRCAP, HIST_VLPREMIO);

            /*" -5499- MOVE 0 TO HIST-DTQITBCO-I. */
            _.Move(0, HIST_DTQITBCO_I);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2110_999_EXIT*/

        [StopWatch]
        /*" B2200-000-BAIXA-RCAP-SECTION */
        private void B2200_000_BAIXA_RCAP_SECTION()
        {
            /*" -5510- MOVE 'B2200' TO WNR-EXEC-SQL. */
            _.Move("B2200", WABEND.WNR_EXEC_SQL);

            /*" -5511- MOVE PCOM-FONTE TO V0RCAP-FONTE */
            _.Move(PCOM_FONTE, V0RCAP_FONTE);

            /*" -5559- MOVE PCOM-NRRCAP TO V0RCAP-NRRCAP. */
            _.Move(PCOM_NRRCAP, V0RCAP_NRRCAP);

            /*" -5559- PERFORM B2200-010-ALTERA-V0RCAP. */

            B2200_010_ALTERA_V0RCAP();

            /*" -0- FLUXCONTROL_PERFORM B2200_010_ALTERA_V0RCAP */

            B2200_010_ALTERA_V0RCAP();

        }

        [StopWatch]
        /*" B2200-010-ALTERA-V0RCAP */
        private void B2200_010_ALTERA_V0RCAP(bool isPerform = false)
        {
            /*" -5564- MOVE 'B2210' TO WNR-EXEC-SQL. */
            _.Move("B2210", WABEND.WNR_EXEC_SQL);

            /*" -5574- PERFORM B2200_010_ALTERA_V0RCAP_DB_UPDATE_1 */

            B2200_010_ALTERA_V0RCAP_DB_UPDATE_1();

            /*" -5577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5580- DISPLAY 'B2210 - PROBLEMAS UPDATE V0RCAP ' ' ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                $"B2210 - PROBLEMAS UPDATE V0RCAP  {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                .Display();

                /*" -5582- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5582- PERFORM B2200-020-DECLARE-V0RCAPCOMP. */

            B2200_020_DECLARE_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" B2200-010-ALTERA-V0RCAP-DB-UPDATE-1 */
        public void B2200_010_ALTERA_V0RCAP_DB_UPDATE_1()
        {
            /*" -5574- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' ,OPERACAO = 220 ,NUM_APOLICE = :HIST-NUM-APOLICE ,NRENDOS = :HIST-NRENDOS ,NRPARCEL = :HIST-NRPARCEL ,TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var b2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1 = new B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1()
            {
                HIST_NUM_APOLICE = HIST_NUM_APOLICE.ToString(),
                HIST_NRPARCEL = HIST_NRPARCEL.ToString(),
                HIST_NRENDOS = HIST_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            B2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1.Execute(b2200_010_ALTERA_V0RCAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" B2200-020-DECLARE-V0RCAPCOMP */
        private void B2200_020_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5587- MOVE 'B2220' TO WNR-EXEC-SQL. */
            _.Move("B2220", WABEND.WNR_EXEC_SQL);

            /*" -5598- PERFORM B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -5600- PERFORM B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -5603- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5606- DISPLAY 'B2220 - PROBLEMAS DECLARE V0RCAPCOMP ' ' ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                $"B2220 - PROBLEMAS DECLARE V0RCAPCOMP  {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                .Display();

                /*" -5606- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2200-020-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -5600- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R8010-DECLARE-APOLICE-COBER-DB-DECLARE-1 */
        public void R8010_DECLARE_APOLICE_COBER_DB_DECLARE_1()
        {
            /*" -8144- EXEC SQL DECLARE APOLICE_COBERTURAS CURSOR FOR SELECT NUM_APOLICE , NUM_ENDOSSO , RAMO_COBERTURA , MODALI_COBERTURA , COD_COBERTURA , IMP_SEGURADA_IX , PRM_TARIFARIO_IX , DATA_INIVIGENCIA , DATA_TERVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS APOLICOB WHERE NUM_APOLICE = :APOLICOB-NUM-APOLICE AND NUM_ENDOSSO = :APOLICOB-NUM-ENDOSSO ORDER BY NUM_APOLICE , NUM_ENDOSSO, RAMO_COBERTURA, COD_COBERTURA WITH UR END-EXEC. */
            APOLICE_COBERTURAS = new EM0030B_APOLICE_COBERTURAS(true);
            string GetQuery_APOLICE_COBERTURAS()
            {
                var query = @$"SELECT NUM_APOLICE 
							, NUM_ENDOSSO 
							, RAMO_COBERTURA 
							, MODALI_COBERTURA 
							, COD_COBERTURA 
							, IMP_SEGURADA_IX 
							, PRM_TARIFARIO_IX 
							, DATA_INIVIGENCIA 
							, DATA_TERVIGENCIA 
							FROM SEGUROS.APOLICE_COBERTURAS APOLICOB 
							WHERE NUM_APOLICE = '{APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}' 
							AND NUM_ENDOSSO = '{APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}' 
							ORDER BY NUM_APOLICE
							, NUM_ENDOSSO
							, 
							RAMO_COBERTURA
							, COD_COBERTURA";

                return query;
            }
            APOLICE_COBERTURAS.GetQueryEvent += GetQuery_APOLICE_COBERTURAS;

        }

        [StopWatch]
        /*" B2200-030-FETCH-V0RCAPCOMP */
        private void B2200_030_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5612- MOVE 'B2230' TO WNR-EXEC-SQL. */
            _.Move("B2230", WABEND.WNR_EXEC_SQL);

            /*" -5618- PERFORM B2200_030_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            B2200_030_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -5621- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5621- PERFORM B2200_030_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                B2200_030_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                /*" -5624- GO TO B2200-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2200_999_EXIT*/ //GOTO
                return;
            }


            /*" -5625- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5628- DISPLAY 'B2230 - PROBLEMAS FETCH V0RCAPCOMP ' ' ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                $"B2230 - PROBLEMAS FETCH V0RCAPCOMP  {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                .Display();

                /*" -5630- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5634- IF PCOM-OPERACAO EQUAL 200 OR 210 OR 220 OR 400 */

            if (PCOM_OPERACAO.In("200", "210", "220", "400"))
            {

                /*" -5636- GO TO B2200-030-FETCH-V0RCAPCOMP. */
                new Task(() => B2200_030_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -5636- PERFORM B2200-040-ALTERA-V0RCAPCOMP. */

            B2200_040_ALTERA_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" B2200-030-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void B2200_030_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -5618- EXEC SQL FETCH V1RCAPCOMP INTO :PCOM-FONTE, :PCOM-NRRCAP, :PCOM-NRRCAPCO, :PCOM-OPERACAO, :PCOM-DTMOVTO, :PCOM-HORAOPER, :PCOM-SITUACAO, :PCOM-BCOAVISO, :PCOM-AGEAVISO, :PCOM-NRAVISO, :PCOM-VLRCAP, :PCOM-DATARCAP, :PCOM-DTCADAST, :PCOM-SITCONTB END-EXEC. */

            if (V1RCAPCOMP.Fetch())
            {
                _.Move(V1RCAPCOMP.PCOM_FONTE, PCOM_FONTE);
                _.Move(V1RCAPCOMP.PCOM_NRRCAP, PCOM_NRRCAP);
                _.Move(V1RCAPCOMP.PCOM_NRRCAPCO, PCOM_NRRCAPCO);
                _.Move(V1RCAPCOMP.PCOM_OPERACAO, PCOM_OPERACAO);
                _.Move(V1RCAPCOMP.PCOM_DTMOVTO, PCOM_DTMOVTO);
                _.Move(V1RCAPCOMP.PCOM_HORAOPER, PCOM_HORAOPER);
                _.Move(V1RCAPCOMP.PCOM_SITUACAO, PCOM_SITUACAO);
                _.Move(V1RCAPCOMP.PCOM_BCOAVISO, PCOM_BCOAVISO);
                _.Move(V1RCAPCOMP.PCOM_AGEAVISO, PCOM_AGEAVISO);
                _.Move(V1RCAPCOMP.PCOM_NRAVISO, PCOM_NRAVISO);
                _.Move(V1RCAPCOMP.PCOM_VLRCAP, PCOM_VLRCAP);
                _.Move(V1RCAPCOMP.PCOM_DATARCAP, PCOM_DATARCAP);
                _.Move(V1RCAPCOMP.PCOM_DTCADAST, PCOM_DTCADAST);
                _.Move(V1RCAPCOMP.PCOM_SITCONTB, PCOM_SITCONTB);
            }

        }

        [StopWatch]
        /*" B2200-030-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void B2200_030_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -5621- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" B2200-040-ALTERA-V0RCAPCOMP */
        private void B2200_040_ALTERA_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5641- MOVE 'B2240' TO WNR-EXEC-SQL. */
            _.Move("B2240", WABEND.WNR_EXEC_SQL);

            /*" -5651- PERFORM B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1 */

            B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1();

            /*" -5654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5657- DISPLAY 'B2240 - PROBLEMAS UPDATE V0RCAPCOMP ' ' ' PCOM-FONTE ' ' PCOM-NRRCAP */

                $"B2240 - PROBLEMAS UPDATE V0RCAPCOMP  {PCOM_FONTE} {PCOM_NRRCAP}"
                .Display();

                /*" -5659- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5659- PERFORM B2200-050-INCLUI-V0RCAPCOMP. */

            B2200_050_INCLUI_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" B2200-040-ALTERA-V0RCAPCOMP-DB-UPDATE-1 */
        public void B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -5651- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PCOM-FONTE AND NRRCAP = :PCOM-NRRCAP AND NRRCAPCO = :PCOM-NRRCAPCO AND OPERACAO = :PCOM-OPERACAO AND DTMOVTO = :PCOM-DTMOVTO AND HORAOPER = :PCOM-HORAOPER END-EXEC. */

            var b2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1 = new B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                PCOM_NRRCAPCO = PCOM_NRRCAPCO.ToString(),
                PCOM_OPERACAO = PCOM_OPERACAO.ToString(),
                PCOM_HORAOPER = PCOM_HORAOPER.ToString(),
                PCOM_DTMOVTO = PCOM_DTMOVTO.ToString(),
                PCOM_NRRCAP = PCOM_NRRCAP.ToString(),
                PCOM_FONTE = PCOM_FONTE.ToString(),
            };

            B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(b2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" B2200-050-INCLUI-V0RCAPCOMP */
        private void B2200_050_INCLUI_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -5664- MOVE 'B2250' TO WNR-EXEC-SQL. */
            _.Move("B2250", WABEND.WNR_EXEC_SQL);

            /*" -5665- MOVE '0' TO PCOM-SITCONTB. */
            _.Move("0", PCOM_SITCONTB);

            /*" -5666- MOVE '0' TO PCOM-SITUACAO. */
            _.Move("0", PCOM_SITUACAO);

            /*" -5672- MOVE 220 TO PCOM-OPERACAO. */
            _.Move(220, PCOM_OPERACAO);

            /*" -5673- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -5674- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_TIME.WS_HH_TIME, FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -5675- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -5676- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_TIME.WS_MM_TIME, FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -5677- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -5678- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_TIME.WS_SS_TIME, FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -5680- MOVE WTIME-DAYR TO PCOM-HORAOPER. */
            _.Move(FILLER_4.WTIME_DAYR, PCOM_HORAOPER);

            /*" -5713- PERFORM B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1 */

            B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1();

            /*" -5716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5717- DISPLAY 'B2250 - PROBLEMAS INSERT V0RCAPCOMP ----------' */
                _.Display($"B2250 - PROBLEMAS INSERT V0RCAPCOMP ----------");

                /*" -5718- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -5719- DISPLAY 'SQLCODE ' WSQLCODE */
                _.Display($"SQLCODE {WABEND.WSQLCODE}");

                /*" -5720- DISPLAY 'PCOM-AGEAVISO = ' PCOM-AGEAVISO */
                _.Display($"PCOM-AGEAVISO = {PCOM_AGEAVISO}");

                /*" -5721- DISPLAY 'PCOM-BCOAVISO = ' PCOM-BCOAVISO */
                _.Display($"PCOM-BCOAVISO = {PCOM_BCOAVISO}");

                /*" -5722- DISPLAY 'PCOM-DATARCAP = ' PCOM-DATARCAP */
                _.Display($"PCOM-DATARCAP = {PCOM_DATARCAP}");

                /*" -5723- DISPLAY 'PCOM-DTCADAST = ' PCOM-DTCADAST */
                _.Display($"PCOM-DTCADAST = {PCOM_DTCADAST}");

                /*" -5724- DISPLAY 'SIST-DTMOVABE = ' SIST-DTMOVABE */
                _.Display($"SIST-DTMOVABE = {SIST_DTMOVABE}");

                /*" -5725- DISPLAY 'PCOM-FONTE    = ' PCOM-FONTE */
                _.Display($"PCOM-FONTE    = {PCOM_FONTE}");

                /*" -5726- DISPLAY 'PCOM-HORAOPER = ' PCOM-HORAOPER */
                _.Display($"PCOM-HORAOPER = {PCOM_HORAOPER}");

                /*" -5727- DISPLAY 'PCOM-NRAVISO  = ' PCOM-NRAVISO */
                _.Display($"PCOM-NRAVISO  = {PCOM_NRAVISO}");

                /*" -5728- DISPLAY 'PCOM-NRRCAP   = ' PCOM-NRRCAP */
                _.Display($"PCOM-NRRCAP   = {PCOM_NRRCAP}");

                /*" -5729- DISPLAY 'PCOM-NRRCAPCO = ' PCOM-NRRCAPCO */
                _.Display($"PCOM-NRRCAPCO = {PCOM_NRRCAPCO}");

                /*" -5730- DISPLAY 'PCOM-OPERACAO = ' PCOM-OPERACAO */
                _.Display($"PCOM-OPERACAO = {PCOM_OPERACAO}");

                /*" -5731- DISPLAY 'PCOM-SITCONTB = ' PCOM-SITCONTB */
                _.Display($"PCOM-SITCONTB = {PCOM_SITCONTB}");

                /*" -5732- DISPLAY 'PCOM-SITUACAO = ' PCOM-SITUACAO */
                _.Display($"PCOM-SITUACAO = {PCOM_SITUACAO}");

                /*" -5733- DISPLAY 'PCOM-VLRCAP   = ' PCOM-VLRCAP */
                _.Display($"PCOM-VLRCAP   = {PCOM_VLRCAP}");

                /*" -5734- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -5736- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5739- ADD 1 TO AC-I-V0RCAPCOMP. */
            AC_I_V0RCAPCOMP.Value = AC_I_V0RCAPCOMP + 1;

            /*" -5740- MOVE PCOM-BCOAVISO TO V1ASAL-BCOAVISO */
            _.Move(PCOM_BCOAVISO, V1ASAL_BCOAVISO);

            /*" -5741- MOVE PCOM-AGEAVISO TO V1ASAL-AGEAVISO */
            _.Move(PCOM_AGEAVISO, V1ASAL_AGEAVISO);

            /*" -5742- MOVE PCOM-NRAVISO TO V1ASAL-NRAVISO */
            _.Move(PCOM_NRAVISO, V1ASAL_NRAVISO);

            /*" -5743- MOVE SPACES TO WFIM-V1AVISALDOS */
            _.Move("", WFIM_V1AVISALDOS);

            /*" -5744- PERFORM B3200-SELECT-V1AVISALDOS */

            B3200_SELECT_V1AVISALDOS_SECTION();

            /*" -5745- IF WFIM-V1AVISALDOS EQUAL SPACES */

            if (WFIM_V1AVISALDOS.IsEmpty())
            {

                /*" -5747- PERFORM B3300-ALTERA-V0AVISALDOS. */

                B3300_ALTERA_V0AVISALDOS_SECTION();
            }


            /*" -5747- GO TO B2200-030-FETCH-V0RCAPCOMP. */

            B2200_030_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" B2200-050-INCLUI-V0RCAPCOMP-DB-INSERT-1 */
        public void B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -5713- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP (AGEAVISO, BCOAVISO, DATARCAP, DTCADAST, DTMOVTO, FONTE, HORAOPER, NRAVISO, NRRCAP, NRRCAPCO, OPERACAO, SITCONTB, SITUACAO, VLRCAP, TIMESTAMP) VALUES (:PCOM-AGEAVISO, :PCOM-BCOAVISO, :PCOM-DATARCAP, :PCOM-DTCADAST, :SIST-DTMOVABE, :PCOM-FONTE, :PCOM-HORAOPER, :PCOM-NRAVISO, :PCOM-NRRCAP, :PCOM-NRRCAPCO, :PCOM-OPERACAO, :PCOM-SITCONTB, :PCOM-SITUACAO, :PCOM-VLRCAP, CURRENT TIMESTAMP) END-EXEC. */

            var b2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1 = new B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                PCOM_AGEAVISO = PCOM_AGEAVISO.ToString(),
                PCOM_BCOAVISO = PCOM_BCOAVISO.ToString(),
                PCOM_DATARCAP = PCOM_DATARCAP.ToString(),
                PCOM_DTCADAST = PCOM_DTCADAST.ToString(),
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
                PCOM_FONTE = PCOM_FONTE.ToString(),
                PCOM_HORAOPER = PCOM_HORAOPER.ToString(),
                PCOM_NRAVISO = PCOM_NRAVISO.ToString(),
                PCOM_NRRCAP = PCOM_NRRCAP.ToString(),
                PCOM_NRRCAPCO = PCOM_NRRCAPCO.ToString(),
                PCOM_OPERACAO = PCOM_OPERACAO.ToString(),
                PCOM_SITCONTB = PCOM_SITCONTB.ToString(),
                PCOM_SITUACAO = PCOM_SITUACAO.ToString(),
                PCOM_VLRCAP = PCOM_VLRCAP.ToString(),
            };

            B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(b2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2200_999_EXIT*/

        [StopWatch]
        /*" B2400-AJUSTA-PARCELA-SECTION */
        private void B2400_AJUSTA_PARCELA_SECTION()
        {
            /*" -5758- MOVE VL-TARIFA TO VL-TARIFAW. */
            _.Move(EM0901W099.VL_TARIFA, FILLER_28.VL_TARIFAW);

            /*" -5759- MOVE VL-DESCONTO TO VL-DESCW. */
            _.Move(EM0901W099.VL_DESCONTO, FILLER_28.VL_DESCW);

            /*" -5760- MOVE VL-LIQUIDO TO VL-LIQW. */
            _.Move(EM0901W099.VL_LIQUIDO, FILLER_28.VL_LIQW);

            /*" -5761- MOVE VL-ADICIONAL TO VL-ADICW. */
            _.Move(EM0901W099.VL_ADICIONAL, FILLER_28.VL_ADICW);

            /*" -5762- MOVE VL-CUSTO TO VL-CUSTOW. */
            _.Move(EM0901W099.VL_CUSTO, FILLER_28.VL_CUSTOW);

            /*" -5763- MOVE VL-IOF TO VL-IOCCW. */
            _.Move(EM0901W099.VL_IOF, FILLER_28.VL_IOCCW);

            /*" -5764- MOVE VL-TOTAL TO VL-TOTALW. */
            _.Move(EM0901W099.VL_TOTAL, FILLER_28.VL_TOTALW);

            /*" -5765- MOVE VL-TARIFARIO-IX TO VL-TARIFAW-IX. */
            _.Move(EM0901W099.VL_TARIFARIO_IX, FILLER_28.VL_TARIFAW_IX);

            /*" -5766- MOVE VL-DESC-IX TO VL-DESCW-IX. */
            _.Move(EM0901W099.VL_DESC_IX, FILLER_28.VL_DESCW_IX);

            /*" -5767- MOVE VL-LIQ-IX TO VL-LIQW-IX. */
            _.Move(EM0901W099.VL_LIQ_IX, FILLER_28.VL_LIQW_IX);

            /*" -5768- MOVE VL-ADIC-IX TO VL-ADICW-IX. */
            _.Move(EM0901W099.VL_ADIC_IX, FILLER_28.VL_ADICW_IX);

            /*" -5769- MOVE VL-CUSTO-IX TO VL-CUSTOW-IX. */
            _.Move(EM0901W099.VL_CUSTO_IX, FILLER_28.VL_CUSTOW_IX);

            /*" -5770- MOVE VL-IOF-IX TO VL-IOCCW-IX. */
            _.Move(EM0901W099.VL_IOF_IX, FILLER_28.VL_IOCCW_IX);

            /*" -5772- MOVE VL-TOTAL-IX TO VL-TOTALW-IX. */
            _.Move(EM0901W099.VL_TOTAL_IX, FILLER_28.VL_TOTALW_IX);

            /*" -5774- MOVE ENDO-VLRCAP TO VL-TOTAL. */
            _.Move(ENDO_VLRCAP, EM0901W099.VL_TOTAL);

            /*" -5777- COMPUTE PCIOF ROUNDED = 1 + (PCIOF / 100). */
            EM0901W099.PCIOF.Value = 1 + (EM0901W099.PCIOF / 100f);

            /*" -5780- COMPUTE VL-IOF ROUNDED = VL-TOTAL / PCIOF. */
            EM0901W099.VL_IOF.Value = EM0901W099.VL_TOTAL / EM0901W099.PCIOF;

            /*" -5783- COMPUTE VL-IOF = VL-TOTAL - VL-IOF. */
            EM0901W099.VL_IOF.Value = EM0901W099.VL_TOTAL - EM0901W099.VL_IOF;

            /*" -5788- COMPUTE VL-LIQUIDO = VL-TOTAL - VL-IOF - VL-CUSTO - VL-ADICIONAL. */
            EM0901W099.VL_LIQUIDO.Value = EM0901W099.VL_TOTAL - EM0901W099.VL_IOF - EM0901W099.VL_CUSTO - EM0901W099.VL_ADICIONAL;

            /*" -5796- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802 OR ENDO-CODPRODU EQUAL 1804) AND ENDO-COD-EMPRESA EQUAL 0)) NEXT SENTENCE */

            if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802 || ENDO_CODPRODU == 1804) && ENDO_COD_EMPRESA == 0)))
            {

                /*" -5797- ELSE */
            }
            else
            {


                /*" -5801- COMPUTE VL-TARIFA ROUNDED = VL-LIQUIDO / ( 1 - ( PCDESCON / 100 ) ). */
                EM0901W099.VL_TARIFA.Value = EM0901W099.VL_LIQUIDO / (1 - (EM0901W099.PCDESCON / 100f));
            }


            /*" -5804- COMPUTE VL-DESCONTO = VL-TARIFA - VL-LIQUIDO. */
            EM0901W099.VL_DESCONTO.Value = EM0901W099.VL_TARIFA - EM0901W099.VL_LIQUIDO;

            /*" -5806- MOVE ENDO-DTINIVIG TO WHOST-DTINIVIG */
            _.Move(ENDO_DTINIVIG, WHOST_DTINIVIG);

            /*" -5808- PERFORM B2500-LE-MOEDA. */

            B2500_LE_MOEDA_SECTION();

            /*" -5812- COMPUTE VL-TARIFARIO-IX ROUNDED = VL-TARIFA / MOED-VALOR. */
            EM0901W099.VL_TARIFARIO_IX.Value = EM0901W099.VL_TARIFA / MOED_VALOR;

            /*" -5816- COMPUTE VL-LIQ-IX ROUNDED = VL-LIQUIDO / MOED-VALOR. */
            EM0901W099.VL_LIQ_IX.Value = EM0901W099.VL_LIQUIDO / MOED_VALOR;

            /*" -5819- COMPUTE VL-DESC-IX = VL-TARIFARIO-IX - VL-LIQ-IX. */
            EM0901W099.VL_DESC_IX.Value = EM0901W099.VL_TARIFARIO_IX - EM0901W099.VL_LIQ_IX;

            /*" -5822- COMPUTE VL-IOF-IX ROUNDED = VL-IOF / MOED-VALOR. */
            EM0901W099.VL_IOF_IX.Value = EM0901W099.VL_IOF / MOED_VALOR;

            /*" -5827- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            EM0901W099.VL_TOTAL_IX.Value = EM0901W099.VL_LIQ_IX + EM0901W099.VL_ADIC_IX + EM0901W099.VL_CUSTO_IX + EM0901W099.VL_IOF_IX;

            /*" -5828- IF ENDO-PCADICIO EQUAL ZEROS */

            if (ENDO_PCADICIO == 00)
            {

                /*" -5836- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802 OR ENDO-CODPRODU EQUAL 1804) AND ENDO-COD-EMPRESA EQUAL 0)) NEXT SENTENCE */

                if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802 || ENDO_CODPRODU == 1804) && ENDO_COD_EMPRESA == 0)))
                {

                    /*" -5837- ELSE */
                }
                else
                {


                    /*" -5841- COMPUTE VL-PREMIO-BASE = VL-PREMIO-BASE - VL-TARIFAW-IX. */
                    EM0901W099.VL_PREMIO_BASE.Value = EM0901W099.VL_PREMIO_BASE - FILLER_28.VL_TARIFAW_IX;
                }

            }


            /*" -5844- COMPUTE VL-DIFTAR-IX = VL-TARIFARIO-IX - VL-TARIFAW-IX. */
            FILLER_28.VL_DIFTAR_IX.Value = EM0901W099.VL_TARIFARIO_IX - FILLER_28.VL_TARIFAW_IX;

            /*" -5847- COMPUTE VL-DIFDESC-IX = VL-DESC-IX - VL-DESCW-IX. */
            FILLER_28.VL_DIFDESC_IX.Value = EM0901W099.VL_DESC_IX - FILLER_28.VL_DESCW_IX;

            /*" -5850- COMPUTE VL-DIFLIQ-IX = VL-LIQ-IX - VL-LIQW-IX. */
            FILLER_28.VL_DIFLIQ_IX.Value = EM0901W099.VL_LIQ_IX - FILLER_28.VL_LIQW_IX;

            /*" -5853- COMPUTE VL-DIFADI-IX = VL-ADIC-IX - VL-ADICW-IX. */
            FILLER_28.VL_DIFADI_IX.Value = EM0901W099.VL_ADIC_IX - FILLER_28.VL_ADICW_IX;

            /*" -5856- COMPUTE VL-DIFCUS-IX = VL-CUSTO-IX - VL-CUSTOW-IX. */
            FILLER_28.VL_DIFCUS_IX.Value = EM0901W099.VL_CUSTO_IX - FILLER_28.VL_CUSTOW_IX;

            /*" -5859- COMPUTE VL-DIFIOC-IX = VL-IOF-IX - VL-IOCCW-IX. */
            FILLER_28.VL_DIFIOC_IX.Value = EM0901W099.VL_IOF_IX - FILLER_28.VL_IOCCW_IX;

            /*" -5862- COMPUTE VL-DIFTOT-IX = VL-TOTAL-IX - VL-TOTALW-IX. */
            FILLER_28.VL_DIFTOT_IX.Value = EM0901W099.VL_TOTAL_IX - FILLER_28.VL_TOTALW_IX;

            /*" -5865- COMPUTE VL-DIFTAR = VL-TARIFA - VL-TARIFAW. */
            FILLER_28.VL_DIFTAR.Value = EM0901W099.VL_TARIFA - FILLER_28.VL_TARIFAW;

            /*" -5868- COMPUTE VL-DIFDESC = VL-DESCONTO - VL-DESCW. */
            FILLER_28.VL_DIFDESC.Value = EM0901W099.VL_DESCONTO - FILLER_28.VL_DESCW;

            /*" -5871- COMPUTE VL-DIFLIQ = VL-LIQUIDO - VL-LIQW. */
            FILLER_28.VL_DIFLIQ.Value = EM0901W099.VL_LIQUIDO - FILLER_28.VL_LIQW;

            /*" -5874- COMPUTE VL-DIFADI = VL-ADICIONAL - VL-ADICW. */
            FILLER_28.VL_DIFADI.Value = EM0901W099.VL_ADICIONAL - FILLER_28.VL_ADICW;

            /*" -5877- COMPUTE VL-DIFCUS = VL-CUSTO - VL-CUSTOW. */
            FILLER_28.VL_DIFCUS.Value = EM0901W099.VL_CUSTO - FILLER_28.VL_CUSTOW;

            /*" -5880- COMPUTE VL-DIFIOC = VL-IOF - VL-IOCCW. */
            FILLER_28.VL_DIFIOC.Value = EM0901W099.VL_IOF - FILLER_28.VL_IOCCW;

            /*" -5885- COMPUTE VL-DIFTOT = VL-TOTAL - VL-TOTALW. */
            FILLER_28.VL_DIFTOT.Value = EM0901W099.VL_TOTAL - FILLER_28.VL_TOTALW;

            /*" -5888- COMPUTE VL-DIFTAR-IX = VL-DIFTAR-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFTAR_IX.Value = FILLER_28.VL_DIFTAR_IX / (ENDO_QTPARCEL - 1);

            /*" -5891- COMPUTE VL-DIFDESC-IX = VL-DIFDESC-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFDESC_IX.Value = FILLER_28.VL_DIFDESC_IX / (ENDO_QTPARCEL - 1);

            /*" -5894- COMPUTE VL-DIFLIQ-IX = VL-DIFLIQ-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFLIQ_IX.Value = FILLER_28.VL_DIFLIQ_IX / (ENDO_QTPARCEL - 1);

            /*" -5897- COMPUTE VL-DIFADI-IX = VL-DIFADI-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFADI_IX.Value = FILLER_28.VL_DIFADI_IX / (ENDO_QTPARCEL - 1);

            /*" -5900- COMPUTE VL-DIFCUS-IX = VL-DIFCUS-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFCUS_IX.Value = FILLER_28.VL_DIFCUS_IX / (ENDO_QTPARCEL - 1);

            /*" -5903- COMPUTE VL-DIFIOC-IX = VL-DIFIOC-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFIOC_IX.Value = FILLER_28.VL_DIFIOC_IX / (ENDO_QTPARCEL - 1);

            /*" -5906- COMPUTE VL-DIFTOT-IX = VL-DIFTOT-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFTOT_IX.Value = FILLER_28.VL_DIFTOT_IX / (ENDO_QTPARCEL - 1);

            /*" -5909- COMPUTE VL-DIFTAR = VL-DIFTAR / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFTAR.Value = FILLER_28.VL_DIFTAR / (ENDO_QTPARCEL - 1);

            /*" -5912- COMPUTE VL-DIFDESC = VL-DIFDESC / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFDESC.Value = FILLER_28.VL_DIFDESC / (ENDO_QTPARCEL - 1);

            /*" -5915- COMPUTE VL-DIFLIQ = VL-DIFLIQ / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFLIQ.Value = FILLER_28.VL_DIFLIQ / (ENDO_QTPARCEL - 1);

            /*" -5918- COMPUTE VL-DIFADI = VL-DIFADI / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFADI.Value = FILLER_28.VL_DIFADI / (ENDO_QTPARCEL - 1);

            /*" -5921- COMPUTE VL-DIFCUS = VL-DIFCUS / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFCUS.Value = FILLER_28.VL_DIFCUS / (ENDO_QTPARCEL - 1);

            /*" -5924- COMPUTE VL-DIFIOC = VL-DIFIOC / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFIOC.Value = FILLER_28.VL_DIFIOC / (ENDO_QTPARCEL - 1);

            /*" -5925- COMPUTE VL-DIFTOT = VL-DIFTOT / ( ENDO-QTPARCEL - 1 ). */
            FILLER_28.VL_DIFTOT.Value = FILLER_28.VL_DIFTOT / (ENDO_QTPARCEL - 1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2499_999_EXIT*/

        [StopWatch]
        /*" B2500-LE-MOEDA-SECTION */
        private void B2500_LE_MOEDA_SECTION()
        {
            /*" -5936- MOVE 'B2500' TO WNR-EXEC-SQL. */
            _.Move("B2500", WABEND.WNR_EXEC_SQL);

            /*" -5945- PERFORM B2500_LE_MOEDA_DB_SELECT_1 */

            B2500_LE_MOEDA_DB_SELECT_1();

            /*" -5948- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -5949- DISPLAY 'PROBLEMAS NA COTACAO DE MOEDA' */
                _.Display($"PROBLEMAS NA COTACAO DE MOEDA");

                /*" -5949- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2500-LE-MOEDA-DB-SELECT-1 */
        public void B2500_LE_MOEDA_DB_SELECT_1()
        {
            /*" -5945- EXEC SQL SELECT VLCRUZAD INTO :MOED-VALOR FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ENDO-COD-MOEDA-PRM AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND SITUACAO = '0' WITH UR END-EXEC. */

            var b2500_LE_MOEDA_DB_SELECT_1_Query1 = new B2500_LE_MOEDA_DB_SELECT_1_Query1()
            {
                ENDO_COD_MOEDA_PRM = ENDO_COD_MOEDA_PRM.ToString(),
                WHOST_DTINIVIG = WHOST_DTINIVIG.ToString(),
            };

            var executed_1 = B2500_LE_MOEDA_DB_SELECT_1_Query1.Execute(b2500_LE_MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOED_VALOR, MOED_VALOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2500_999_EXIT*/

        [StopWatch]
        /*" B2600-00-AJUSTA-ULTIMA-SECTION */
        private void B2600_00_AJUSTA_ULTIMA_SECTION()
        {
            /*" -5960- MOVE VL-LIQUIDO TO VL-LIQW */
            _.Move(EM0901W099.VL_LIQUIDO, FILLER_28.VL_LIQW);

            /*" -5961- MOVE VL-IOF TO VL-IOCCW */
            _.Move(EM0901W099.VL_IOF, FILLER_28.VL_IOCCW);

            /*" -5964- MOVE VL-TOTAL TO VL-TOTALW. */
            _.Move(EM0901W099.VL_TOTAL, FILLER_28.VL_TOTALW);

            /*" -5967- COMPUTE VL-IOCCPT = VL-IOF * ENDO-QTPARCEL */
            FILLER_28.VL_IOCCPT.Value = EM0901W099.VL_IOF * ENDO_QTPARCEL;

            /*" -5972- COMPUTE VL-TOTALPT = VL-TOTAL * ENDO-QTPARCEL */
            FILLER_28.VL_TOTALPT.Value = EM0901W099.VL_TOTAL * ENDO_QTPARCEL;

            /*" -5974- MOVE AU077-VLR-PREMIO-TOTAL TO VL-TOTAL */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_TOTAL, EM0901W099.VL_TOTAL);

            /*" -5978- COMPUTE VL-DIFTOT = VL-TOTAL - VL-TOTALPT */
            FILLER_28.VL_DIFTOT.Value = EM0901W099.VL_TOTAL - FILLER_28.VL_TOTALPT;

            /*" -5979- MOVE AU077-VLR-IOF TO VL-IOF */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_IOF, EM0901W099.VL_IOF);

            /*" -5984- COMPUTE VL-DIFIOC = VL-IOF - VL-IOCCPT */
            FILLER_28.VL_DIFIOC.Value = EM0901W099.VL_IOF - FILLER_28.VL_IOCCPT;

            /*" -5988- COMPUTE VL-TOTAL = VL-TOTALW + VL-DIFTOT */
            EM0901W099.VL_TOTAL.Value = FILLER_28.VL_TOTALW + FILLER_28.VL_DIFTOT;

            /*" -5990- COMPUTE VL-LIQUIDO ROUNDED = VL-TOTAL / (WS-PCT-IOF + 1) */
            EM0901W099.VL_LIQUIDO.Value = EM0901W099.VL_TOTAL / (WS_PCT_IOF + 1);

            /*" -5993- MOVE VL-LIQUIDO TO VL-TARIFA. */
            _.Move(EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFA);

            /*" -5998- COMPUTE VL-IOF ROUNDED = VL-LIQUIDO * WS-PCT-IOF */
            EM0901W099.VL_IOF.Value = EM0901W099.VL_LIQUIDO * WS_PCT_IOF;

            /*" -6007- MOVE ZEROS TO VL-TARIFARIO-IX VL-DESC-IX VL-LIQ-IX VL-IOF-IX VL-ADIC-IX VL-CUSTO-IX VL-TOTAL-IX. */
            _.Move(0, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_DESC_IX, EM0901W099.VL_LIQ_IX, EM0901W099.VL_IOF_IX, EM0901W099.VL_ADIC_IX, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_TOTAL_IX);

            /*" -6008- MOVE VL-TARIFA TO VL-TARIFARIO-IX */
            _.Move(EM0901W099.VL_TARIFA, EM0901W099.VL_TARIFARIO_IX);

            /*" -6009- MOVE VL-DESCONTO TO VL-DESC-IX */
            _.Move(EM0901W099.VL_DESCONTO, EM0901W099.VL_DESC_IX);

            /*" -6010- MOVE VL-LIQUIDO TO VL-LIQ-IX */
            _.Move(EM0901W099.VL_LIQUIDO, EM0901W099.VL_LIQ_IX);

            /*" -6011- MOVE VL-IOF TO VL-IOF-IX */
            _.Move(EM0901W099.VL_IOF, EM0901W099.VL_IOF_IX);

            /*" -6012- MOVE VL-ADICIONAL TO VL-ADIC-IX */
            _.Move(EM0901W099.VL_ADICIONAL, EM0901W099.VL_ADIC_IX);

            /*" -6013- MOVE VL-CUSTO TO VL-CUSTO-IX */
            _.Move(EM0901W099.VL_CUSTO, EM0901W099.VL_CUSTO_IX);

            /*" -6016- MOVE VL-TOTAL TO VL-TOTAL-IX */
            _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

            /*" -6017- MOVE VL-TARIFARIO-IX TO VLAF-TARIFARIO-IX */
            _.Move(EM0901W099.VL_TARIFARIO_IX, VLAF_TARIFARIO_IX);

            /*" -6018- MOVE VL-DESC-IX TO VLAF-DESC-IX */
            _.Move(EM0901W099.VL_DESC_IX, VLAF_DESC_IX);

            /*" -6019- MOVE VL-LIQ-IX TO VLAF-LIQ-IX */
            _.Move(EM0901W099.VL_LIQ_IX, VLAF_LIQ_IX);

            /*" -6020- MOVE VL-IOF-IX TO VLAF-IOF-IX */
            _.Move(EM0901W099.VL_IOF_IX, VLAF_IOF_IX);

            /*" -6021- MOVE VL-ADIC-IX TO VLAF-ADIC-IX */
            _.Move(EM0901W099.VL_ADIC_IX, VLAF_ADIC_IX);

            /*" -6022- MOVE VL-CUSTO-IX TO VLAF-CUSTO-IX */
            _.Move(EM0901W099.VL_CUSTO_IX, VLAF_CUSTO_IX);

            /*" -6024- MOVE VL-TOTAL-IX TO VLAF-TOTAL-IX. */
            _.Move(EM0901W099.VL_TOTAL_IX, VLAF_TOTAL_IX);

            /*" -6025- MOVE VLAF-TARIFARIO-IX TO VL-TARIFARIO-IX */
            _.Move(VLAF_TARIFARIO_IX, EM0901W099.VL_TARIFARIO_IX);

            /*" -6026- MOVE VLAF-DESC-IX TO VL-DESC-IX */
            _.Move(VLAF_DESC_IX, EM0901W099.VL_DESC_IX);

            /*" -6027- MOVE VLAF-LIQ-IX TO VL-LIQ-IX */
            _.Move(VLAF_LIQ_IX, EM0901W099.VL_LIQ_IX);

            /*" -6028- MOVE VLAF-IOF-IX TO VL-IOF-IX */
            _.Move(VLAF_IOF_IX, EM0901W099.VL_IOF_IX);

            /*" -6029- MOVE VLAF-ADIC-IX TO VL-ADIC-IX */
            _.Move(VLAF_ADIC_IX, EM0901W099.VL_ADIC_IX);

            /*" -6030- MOVE VLAF-CUSTO-IX TO VL-CUSTO-IX */
            _.Move(VLAF_CUSTO_IX, EM0901W099.VL_CUSTO_IX);

            /*" -6030- MOVE VLAF-TOTAL-IX TO VL-TOTAL-IX. */
            _.Move(VLAF_TOTAL_IX, EM0901W099.VL_TOTAL_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2699_999_EXIT*/

        [StopWatch]
        /*" B3000-GRAVA-HISTOPARC-SECTION */
        private void B3000_GRAVA_HISTOPARC_SECTION()
        {
            /*" -6041- MOVE 'B3000' TO WNR-EXEC-SQL. */
            _.Move("B3000", WABEND.WNR_EXEC_SQL);

            /*" -6042- MOVE ENDO-NUM-APOLICE TO HIST-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, HIST_NUM_APOLICE);

            /*" -6043- MOVE ENDO-NRENDOS TO HIST-NRENDOS. */
            _.Move(ENDO_NRENDOS, HIST_NRENDOS);

            /*" -6044- MOVE PARC-NRPARCEL TO HIST-NRPARCEL. */
            _.Move(PARC_NRPARCEL, HIST_NRPARCEL);

            /*" -6045- MOVE PARC-DACPARC TO HIST-DACPARC. */
            _.Move(PARC_DACPARC, HIST_DACPARC);

            /*" -6047- MOVE SIST-DTMOVABE TO HIST-DTMOVTO. */
            _.Move(SIST_DTMOVABE, HIST_DTMOVTO);

            /*" -6049- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -6050- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_TIME.WS_HH_TIME, FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -6051- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -6052- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_TIME.WS_MM_TIME, FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -6053- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -6054- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_TIME.WS_SS_TIME, FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -6056- MOVE WTIME-DAYR TO HIST-HORAOPER. */
            _.Move(FILLER_4.WTIME_DAYR, HIST_HORAOPER);

            /*" -6060- MOVE ENDO-BCOCOBR TO HIST-BCOCOBR. */
            _.Move(ENDO_BCOCOBR, HIST_BCOCOBR);

            /*" -6064- MOVE ZEROS TO HIST-NRENDOCA HIST-SITCONTB HIST-RNUDOC. */
            _.Move(0, HIST_NRENDOCA, HIST_SITCONTB, HIST_RNUDOC);

            /*" -6065- MOVE ' ' TO HIST-COD-USUARIO. */
            _.Move(" ", HIST_COD_USUARIO);

            /*" -6067- MOVE -1 TO HIST-EMPRESA-I. */
            _.Move(-1, HIST_EMPRESA_I);

            /*" -6068- IF HIST-PRM-TARIFARIO < 0 */

            if (HIST_PRM_TARIFARIO < 0)
            {

                /*" -6070- COMPUTE HIST-PRM-TARIFARIO = HIST-PRM-TARIFARIO * -1. */
                HIST_PRM_TARIFARIO.Value = HIST_PRM_TARIFARIO * -1;
            }


            /*" -6071- IF HIST-VAL-DESCONTO < 0 */

            if (HIST_VAL_DESCONTO < 0)
            {

                /*" -6073- COMPUTE HIST-VAL-DESCONTO = HIST-VAL-DESCONTO * -1. */
                HIST_VAL_DESCONTO.Value = HIST_VAL_DESCONTO * -1;
            }


            /*" -6074- IF HIST-VLPRMLIQ < 0 */

            if (HIST_VLPRMLIQ < 0)
            {

                /*" -6076- COMPUTE HIST-VLPRMLIQ = HIST-VLPRMLIQ * -1. */
                HIST_VLPRMLIQ.Value = HIST_VLPRMLIQ * -1;
            }


            /*" -6077- IF HIST-VLADIFRA < 0 */

            if (HIST_VLADIFRA < 0)
            {

                /*" -6079- COMPUTE HIST-VLADIFRA = HIST-VLADIFRA * -1. */
                HIST_VLADIFRA.Value = HIST_VLADIFRA * -1;
            }


            /*" -6080- IF HIST-VLCUSEMI < 0 */

            if (HIST_VLCUSEMI < 0)
            {

                /*" -6082- COMPUTE HIST-VLCUSEMI = HIST-VLCUSEMI * -1. */
                HIST_VLCUSEMI.Value = HIST_VLCUSEMI * -1;
            }


            /*" -6083- IF HIST-VLIOCC < 0 */

            if (HIST_VLIOCC < 0)
            {

                /*" -6085- COMPUTE HIST-VLIOCC = HIST-VLIOCC * -1. */
                HIST_VLIOCC.Value = HIST_VLIOCC * -1;
            }


            /*" -6086- IF HIST-VLPRMTOT < 0 */

            if (HIST_VLPRMTOT < 0)
            {

                /*" -6088- COMPUTE HIST-VLPRMTOT = HIST-VLPRMTOT * -1. */
                HIST_VLPRMTOT.Value = HIST_VLPRMTOT * -1;
            }


            /*" -6089- IF HIST-VLPREMIO < 0 */

            if (HIST_VLPREMIO < 0)
            {

                /*" -6091- COMPUTE HIST-VLPREMIO = HIST-VLPREMIO * -1. */
                HIST_VLPREMIO.Value = HIST_VLPREMIO * -1;
            }


            /*" -6092- IF WS-VL-IOF-IGUAIS = 'S' */

            if (WS_VL_IOF_IGUAIS == "S")
            {

                /*" -6093- PERFORM B3010-TRATAR-VALORES */

                B3010_TRATAR_VALORES_SECTION();

                /*" -6095- END-IF. */
            }


            /*" -6098- IF ENDO-ORGAO = 10 AND ENDO-RAMO = 53 AND HIST-NRENDOS = 0 AND HIST-NRPARCEL = 2 */

            if (ENDO_ORGAO == 10 && ENDO_RAMO == 53 && HIST_NRENDOS == 0 && HIST_NRPARCEL == 2)
            {

                /*" -6118- IF (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26854706) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857299) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857301) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857302) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857303) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857305) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26866284) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26866285) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26869095) OR (ENDO-FONTE = 16 AND ENDO-NRPROPOS = 4539046) OR (ENDO-FONTE = 20 AND ENDO-NRPROPOS = 13042624) OR (ENDO-FONTE = 20 AND ENDO-NRPROPOS = 13042625) OR (ENDO-FONTE = 20 AND ENDO-NRPROPOS = 13045059) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12145129) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12173294) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12175575) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12175576) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12175577) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12178684) */

                if ((ENDO_FONTE == 1 && ENDO_NRPROPOS == 26854706) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857299) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857301) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857302) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857303) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857305) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26866284) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26866285) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26869095) || (ENDO_FONTE == 16 && ENDO_NRPROPOS == 4539046) || (ENDO_FONTE == 20 && ENDO_NRPROPOS == 13042624) || (ENDO_FONTE == 20 && ENDO_NRPROPOS == 13042625) || (ENDO_FONTE == 20 && ENDO_NRPROPOS == 13045059) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12145129) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12173294) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12175575) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12175576) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12175577) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12178684))
                {

                    /*" -6122- DISPLAY 'ALTERANDO DATA VENCIMENTO: ' ENDO-FONTE '-' ENDO-NRPROPOS '-' HIST-DTVENCTO */

                    $"ALTERANDO DATA VENCIMENTO: {ENDO_FONTE}-{ENDO_NRPROPOS}-{HIST_DTVENCTO}"
                    .Display();

                    /*" -6124- MOVE '2018-04-25' TO HIST-DTVENCTO */
                    _.Move("2018-04-25", HIST_DTVENCTO);

                    /*" -6125- END-IF */
                }


                /*" -6127- END-IF */
            }


            /*" -6129- MOVE HIST-DTVENCTO TO WS-DT-AUX. */
            _.Move(HIST_DTVENCTO, WS_DT_AUX);

            /*" -6135- IF WS-DIA-AUX NOT EQUAL '01' AND '02' AND '03' AND '04' AND '05' AND '06' AND '07' AND '08' AND '09' AND '10' AND '11' AND '12' AND '13' AND '14' AND '15' AND '16' AND '17' AND '18' AND '19' AND '20' AND '21' AND '22' AND '23' AND '24' AND '25' AND '26' AND '27' AND '28' AND '29' AND '30' AND '31' */

            if (!WS_DT_AUX.WS_DIA_AUX.In("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"))
            {

                /*" -6136- PERFORM B3005-PEGAR-ULTIMO-DIA */

                B3005_PEGAR_ULTIMO_DIA_SECTION();

                /*" -6146- END-IF. */
            }


            /*" -6147- IF ENDO-ORGAO = 10 AND ENDO-RAMO = 53 */

            if (ENDO_ORGAO == 10 && ENDO_RAMO == 53)
            {

                /*" -6150- IF PRCB-TIPO-COBRANCA = '0' AND PARC-NRPARCEL > 1 AND HIST-OPERACAO = 101 */

                if (PRCB_TIPO_COBRANCA == "0" && PARC_NRPARCEL > 1 && HIST_OPERACAO == 101)
                {

                    /*" -6151- PERFORM R7220-00-CONSULTA-NN */

                    R7220_00_CONSULTA_NN_SECTION();

                    /*" -6152- END-IF */
                }


                /*" -6155- END-IF */
            }


            /*" -6156- IF ENDO-NUM-APOLICE = 106100000011 OR 106800000024 */

            if (ENDO_NUM_APOLICE.In("106100000011", "106800000024"))
            {

                /*" -6157- COMPUTE WS-VLR-IOF ROUNDED = (HIST-VLPREMIO * 0,0738) */
                WS_VLR_IOF.Value = (HIST_VLPREMIO * 0.0738);

                /*" -6159- COMPUTE WS-VLR-PRM-LIQ ROUNDED = HIST-VLPREMIO - WS-VLR-IOF */
                WS_VLR_PRM_LIQ.Value = HIST_VLPREMIO - WS_VLR_IOF;

                /*" -6161- MOVE WS-VLR-PRM-LIQ TO HIST-PRM-TARIFARIO */
                _.Move(WS_VLR_PRM_LIQ, HIST_PRM_TARIFARIO);

                /*" -6162- MOVE 0 TO HIST-VLPRMLIQ */
                _.Move(0, HIST_VLPRMLIQ);

                /*" -6163- MOVE WS-VLR-IOF TO HIST-VLIOCC */
                _.Move(WS_VLR_IOF, HIST_VLIOCC);

                /*" -6165- END-IF */
            }


            /*" -6166- IF ENDO-NUM-APOLICE = 106100000011 OR 106800000024 */

            if (ENDO_NUM_APOLICE.In("106100000011", "106800000024"))
            {

                /*" -6168- MOVE PARC-TARIFARIO-IX TO HIST-PRM-TARIFARIO HIST-VLPRMLIQ */
                _.Move(PARC_TARIFARIO_IX, HIST_PRM_TARIFARIO, HIST_VLPRMLIQ);

                /*" -6169- MOVE PARC-OTNIOF TO HIST-VLIOCC */
                _.Move(PARC_OTNIOF, HIST_VLIOCC);

                /*" -6170- MOVE PARC-OTNTOTAL TO HIST-VLPRMTOT */
                _.Move(PARC_OTNTOTAL, HIST_VLPRMTOT);

                /*" -6171- MOVE 0 TO HIST-VLPREMIO */
                _.Move(0, HIST_VLPREMIO);

                /*" -6173- END-IF. */
            }


            /*" -6230- PERFORM B3000_GRAVA_HISTOPARC_DB_INSERT_1 */

            B3000_GRAVA_HISTOPARC_DB_INSERT_1();

            /*" -6233- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -6234- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6235- DISPLAY ENDO-FONTE, '     ' , ENDO-NRPROPOS */

                $"{ENDO_FONTE}     {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.FILLER}{ENDO_NRPROPOS}"
                .Display();

                /*" -6236- DISPLAY 'EM0030B - ERRO INSERT V0HISTOPARC' */
                _.Display($"EM0030B - ERRO INSERT V0HISTOPARC");

                /*" -6237- PERFORM B3001-DISPLAY-DADOS-INSERT */

                B3001_DISPLAY_DADOS_INSERT_SECTION();

                /*" -6239- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6240- ADD 1 TO AC-I-V0HISTOPARC. */
            AC_I_V0HISTOPARC.Value = AC_I_V0HISTOPARC + 1;

            /*" -6240- PERFORM B3001-DISPLAY-DADOS-INSERT. */

            B3001_DISPLAY_DADOS_INSERT_SECTION();

        }

        [StopWatch]
        /*" B3000-GRAVA-HISTOPARC-DB-INSERT-1 */
        public void B3000_GRAVA_HISTOPARC_DB_INSERT_1()
        {
            /*" -6230- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC ( NUM_APOLICE , NRENDOS , NRPARCEL , DACPARC , DTMOVTO , OPERACAO , HORAOPER , OCORHIST , PRM_TARIFARIO , VAL_DESCONTO , VLPRMLIQ , VLADIFRA , VLCUSEMI , VLIOCC , VLPRMTOT , VLPREMIO , DTVENCTO , BCOCOBR , AGECOBR , NRAVISO , NRENDOCA , SITCONTB , COD_USUARIO , RNUDOC , DTQITBCO , COD_EMPRESA , TIMESTAMP ) VALUES (:HIST-NUM-APOLICE , :HIST-NRENDOS , :HIST-NRPARCEL , :HIST-DACPARC , :HIST-DTMOVTO , :HIST-OPERACAO , :HIST-HORAOPER , :HIST-OCORHIST , :HIST-PRM-TARIFARIO , :HIST-VAL-DESCONTO , :HIST-VLPRMLIQ , :HIST-VLADIFRA , :HIST-VLCUSEMI , :HIST-VLIOCC , :HIST-VLPRMTOT , :HIST-VLPREMIO , :HIST-DTVENCTO , :HIST-BCOCOBR , :HIST-AGECOBR , :HIST-NRAVISO , :HIST-NRENDOCA , :HIST-SITCONTB , :HIST-COD-USUARIO , :HIST-RNUDOC , :HIST-DTQITBCO:HIST-DTQITBCO-I, :HIST-COD-EMPRESA:HIST-EMPRESA-I, CURRENT TIMESTAMP) END-EXEC. */

            var b3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1 = new B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1()
            {
                HIST_NUM_APOLICE = HIST_NUM_APOLICE.ToString(),
                HIST_NRENDOS = HIST_NRENDOS.ToString(),
                HIST_NRPARCEL = HIST_NRPARCEL.ToString(),
                HIST_DACPARC = HIST_DACPARC.ToString(),
                HIST_DTMOVTO = HIST_DTMOVTO.ToString(),
                HIST_OPERACAO = HIST_OPERACAO.ToString(),
                HIST_HORAOPER = HIST_HORAOPER.ToString(),
                HIST_OCORHIST = HIST_OCORHIST.ToString(),
                HIST_PRM_TARIFARIO = HIST_PRM_TARIFARIO.ToString(),
                HIST_VAL_DESCONTO = HIST_VAL_DESCONTO.ToString(),
                HIST_VLPRMLIQ = HIST_VLPRMLIQ.ToString(),
                HIST_VLADIFRA = HIST_VLADIFRA.ToString(),
                HIST_VLCUSEMI = HIST_VLCUSEMI.ToString(),
                HIST_VLIOCC = HIST_VLIOCC.ToString(),
                HIST_VLPRMTOT = HIST_VLPRMTOT.ToString(),
                HIST_VLPREMIO = HIST_VLPREMIO.ToString(),
                HIST_DTVENCTO = HIST_DTVENCTO.ToString(),
                HIST_BCOCOBR = HIST_BCOCOBR.ToString(),
                HIST_AGECOBR = HIST_AGECOBR.ToString(),
                HIST_NRAVISO = HIST_NRAVISO.ToString(),
                HIST_NRENDOCA = HIST_NRENDOCA.ToString(),
                HIST_SITCONTB = HIST_SITCONTB.ToString(),
                HIST_COD_USUARIO = HIST_COD_USUARIO.ToString(),
                HIST_RNUDOC = HIST_RNUDOC.ToString(),
                HIST_DTQITBCO = HIST_DTQITBCO.ToString(),
                HIST_DTQITBCO_I = HIST_DTQITBCO_I.ToString(),
                HIST_COD_EMPRESA = HIST_COD_EMPRESA.ToString(),
                HIST_EMPRESA_I = HIST_EMPRESA_I.ToString(),
            };

            B3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1.Execute(b3000_GRAVA_HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3000_999_EXIT*/

        [StopWatch]
        /*" B3001-DISPLAY-DADOS-INSERT-SECTION */
        private void B3001_DISPLAY_DADOS_INSERT_SECTION()
        {
            /*" -6250- DISPLAY ' ' */
            _.Display($" ");

            /*" -6251- DISPLAY 'EM0030B - DADOS DO INSERT DA V0HISTOPARC ----------' */
            _.Display($"EM0030B - DADOS DO INSERT DA V0HISTOPARC ----------");

            /*" -6252- DISPLAY ' ' */
            _.Display($" ");

            /*" -6253- DISPLAY 'SQLCODE DO INSERT  = ' WS-SQLCODE */
            _.Display($"SQLCODE DO INSERT  = {WS_SQLCODE}");

            /*" -6254- DISPLAY 'HIST-NUM-APOLICE   = ' HIST-NUM-APOLICE */
            _.Display($"HIST-NUM-APOLICE   = {HIST_NUM_APOLICE}");

            /*" -6255- DISPLAY 'HIST-NRENDOS       = ' HIST-NRENDOS */
            _.Display($"HIST-NRENDOS       = {HIST_NRENDOS}");

            /*" -6256- DISPLAY 'HIST-NRPARCEL      = ' HIST-NRPARCEL */
            _.Display($"HIST-NRPARCEL      = {HIST_NRPARCEL}");

            /*" -6257- DISPLAY 'HIST-DACPARC       = ' HIST-DACPARC */
            _.Display($"HIST-DACPARC       = {HIST_DACPARC}");

            /*" -6258- DISPLAY 'HIST-DTMOVTO       = ' HIST-DTMOVTO */
            _.Display($"HIST-DTMOVTO       = {HIST_DTMOVTO}");

            /*" -6259- DISPLAY 'HIST-OPERACAO      = ' HIST-OPERACAO */
            _.Display($"HIST-OPERACAO      = {HIST_OPERACAO}");

            /*" -6260- DISPLAY 'HIST-HORAOPER      = ' HIST-HORAOPER */
            _.Display($"HIST-HORAOPER      = {HIST_HORAOPER}");

            /*" -6262- DISPLAY 'HIST-OCORHIST      = ' HIST-OCORHIST */
            _.Display($"HIST-OCORHIST      = {HIST_OCORHIST}");

            /*" -6263- MOVE HIST-PRM-TARIFARIO TO W-EDICAO1 */
            _.Move(HIST_PRM_TARIFARIO, W_EDICAO1);

            /*" -6264- DISPLAY 'HIST-PRM-TARIFARIO = ' W-EDICAO1 */
            _.Display($"HIST-PRM-TARIFARIO = {W_EDICAO1}");

            /*" -6265- MOVE HIST-VAL-DESCONTO TO W-EDICAO1 */
            _.Move(HIST_VAL_DESCONTO, W_EDICAO1);

            /*" -6266- DISPLAY 'HIST-VAL-DESCONTO  = ' W-EDICAO1 */
            _.Display($"HIST-VAL-DESCONTO  = {W_EDICAO1}");

            /*" -6267- MOVE HIST-VLPRMLIQ TO W-EDICAO1 */
            _.Move(HIST_VLPRMLIQ, W_EDICAO1);

            /*" -6268- DISPLAY 'HIST-VLPRMLIQ      = ' W-EDICAO1 */
            _.Display($"HIST-VLPRMLIQ      = {W_EDICAO1}");

            /*" -6269- MOVE HIST-VLADIFRA TO W-EDICAO1 */
            _.Move(HIST_VLADIFRA, W_EDICAO1);

            /*" -6270- DISPLAY 'HIST-VLADIFRA      = ' W-EDICAO1 */
            _.Display($"HIST-VLADIFRA      = {W_EDICAO1}");

            /*" -6271- MOVE HIST-VLCUSEMI TO W-EDICAO1 */
            _.Move(HIST_VLCUSEMI, W_EDICAO1);

            /*" -6272- DISPLAY 'HIST-VLCUSEMI      = ' W-EDICAO1 */
            _.Display($"HIST-VLCUSEMI      = {W_EDICAO1}");

            /*" -6273- MOVE HIST-VLIOCC TO W-EDICAO1 */
            _.Move(HIST_VLIOCC, W_EDICAO1);

            /*" -6274- DISPLAY 'HIST-VLIOCC        = ' W-EDICAO1 */
            _.Display($"HIST-VLIOCC        = {W_EDICAO1}");

            /*" -6275- MOVE HIST-VLPRMTOT TO W-EDICAO1 */
            _.Move(HIST_VLPRMTOT, W_EDICAO1);

            /*" -6276- DISPLAY 'HIST-VLPRMTOT      = ' W-EDICAO1 */
            _.Display($"HIST-VLPRMTOT      = {W_EDICAO1}");

            /*" -6277- MOVE HIST-VLPREMIO TO W-EDICAO1 */
            _.Move(HIST_VLPREMIO, W_EDICAO1);

            /*" -6279- DISPLAY 'HIST-VLPREMIO      = ' W-EDICAO1 */
            _.Display($"HIST-VLPREMIO      = {W_EDICAO1}");

            /*" -6280- DISPLAY 'HIST-DTVENCTO      = ' HIST-DTVENCTO */
            _.Display($"HIST-DTVENCTO      = {HIST_DTVENCTO}");

            /*" -6281- DISPLAY 'HIST-BCOCOBR       = ' HIST-BCOCOBR */
            _.Display($"HIST-BCOCOBR       = {HIST_BCOCOBR}");

            /*" -6282- DISPLAY 'HIST-AGECOBR       = ' HIST-AGECOBR */
            _.Display($"HIST-AGECOBR       = {HIST_AGECOBR}");

            /*" -6283- DISPLAY 'HIST-NRAVISO       = ' HIST-NRAVISO */
            _.Display($"HIST-NRAVISO       = {HIST_NRAVISO}");

            /*" -6284- DISPLAY 'HIST-NRENDOCA      = ' HIST-NRENDOCA */
            _.Display($"HIST-NRENDOCA      = {HIST_NRENDOCA}");

            /*" -6285- DISPLAY 'HIST-SITCONTB      = ' HIST-SITCONTB */
            _.Display($"HIST-SITCONTB      = {HIST_SITCONTB}");

            /*" -6286- DISPLAY 'HIST-COD-USUARIO   = ' HIST-COD-USUARIO */
            _.Display($"HIST-COD-USUARIO   = {HIST_COD_USUARIO}");

            /*" -6287- DISPLAY 'HIST-RNUDOC        = ' HIST-RNUDOC */
            _.Display($"HIST-RNUDOC        = {HIST_RNUDOC}");

            /*" -6288- DISPLAY 'HIST-DTQITBCO      = ' HIST-DTQITBCO */
            _.Display($"HIST-DTQITBCO      = {HIST_DTQITBCO}");

            /*" -6289- DISPLAY 'HIST-COD-EMPRESA   = ' HIST-COD-EMPRESA . */
            _.Display($"HIST-COD-EMPRESA   = {HIST_COD_EMPRESA}");

            /*" -6294- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -6294- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3001_999_EXIT*/

        [StopWatch]
        /*" B3005-PEGAR-ULTIMO-DIA-SECTION */
        private void B3005_PEGAR_ULTIMO_DIA_SECTION()
        {
            /*" -6301- MOVE '01' TO WS-DIA-AUX. */
            _.Move("01", WS_DT_AUX.WS_DIA_AUX);

            /*" -6303- MOVE WS-DT-AUX TO CALENDAR-DATA-CALENDARIO */
            _.Move(WS_DT_AUX, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -6309- PERFORM B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1 */

            B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1();

            /*" -6312- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6313- DISPLAY 'EM0030B - ERRO SELECT CALENDARIO ' */
                _.Display($"EM0030B - ERRO SELECT CALENDARIO ");

                /*" -6314- DISPLAY 'DATA-CALENDARIO = ' CALENDAR-DATA-CALENDARIO */
                _.Display($"DATA-CALENDARIO = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

                /*" -6315- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6317- END-IF. */
            }


            /*" -6318- MOVE CALENDAR-DTH-ULT-DIA-MES(9:2) TO WS-DIA-AUX. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES.Substring(9, 2), WS_DT_AUX.WS_DIA_AUX);

            /*" -6319- MOVE WS-DT-AUX TO HIST-DTVENCTO. */
            _.Move(WS_DT_AUX, HIST_DTVENCTO);

            /*" -6319- DISPLAY 'HIST-DTVENCTO = ' HIST-DTVENCTO. */
            _.Display($"HIST-DTVENCTO = {HIST_DTVENCTO}");

        }

        [StopWatch]
        /*" B3005-PEGAR-ULTIMO-DIA-DB-SELECT-1 */
        public void B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1()
        {
            /*" -6309- EXEC SQL SELECT DTH_ULT_DIA_MES INTO :CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

            var b3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1 = new B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1()
            {
                CALENDAR_DATA_CALENDARIO = CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.ToString(),
            };

            var executed_1 = B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1.Execute(b3005_PEGAR_ULTIMO_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CALENDAR_DTH_ULT_DIA_MES, CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3005_999_EXIT*/

        [StopWatch]
        /*" B3010-TRATAR-VALORES-SECTION */
        private void B3010_TRATAR_VALORES_SECTION()
        {
            /*" -6330- IF (ENDO-NUM-APOLICE = 106800000018 AND ENDO-CODPRODU = 6821) OR (ENDO-NUM-APOLICE = 106800000011 AND ENDO-CODPRODU = 6812) OR (ENDO-NUM-APOLICE = 106100000002 AND ENDO-CODPRODU = 6103) OR (ENDO-NUM-APOLICE = 106800000020 AND ENDO-CODPRODU = 6823) */

            if ((ENDO_NUM_APOLICE == 106800000018 && ENDO_CODPRODU == 6821) || (ENDO_NUM_APOLICE == 106800000011 && ENDO_CODPRODU == 6812) || (ENDO_NUM_APOLICE == 106100000002 && ENDO_CODPRODU == 6103) || (ENDO_NUM_APOLICE == 106800000020 && ENDO_CODPRODU == 6823))
            {

                /*" -6332- COMPUTE HIST-PRM-TARIFARIO = HIST-PRM-TARIFARIO - HIST-VLIOCC */
                HIST_PRM_TARIFARIO.Value = HIST_PRM_TARIFARIO - HIST_VLIOCC;

                /*" -6333- COMPUTE HIST-VLPRMLIQ = HIST-VLPRMLIQ - HIST-VLIOCC */
                HIST_VLPRMLIQ.Value = HIST_VLPRMLIQ - HIST_VLIOCC;

                /*" -6334- COMPUTE HIST-VLPRMTOT = HIST-VLPRMTOT - HIST-VLIOCC */
                HIST_VLPRMTOT.Value = HIST_VLPRMTOT - HIST_VLIOCC;

                /*" -6335- COMPUTE HIST-VLPREMIO = HIST-VLPREMIO - HIST-VLIOCC */
                HIST_VLPREMIO.Value = HIST_VLPREMIO - HIST_VLIOCC;

                /*" -6335- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3010_999_EXIT*/

        [StopWatch]
        /*" B3100-SELECT-V1RCAPCOMP-SECTION */
        private void B3100_SELECT_V1RCAPCOMP_SECTION()
        {
            /*" -6345- MOVE 'B3100' TO WNR-EXEC-SQL. */
            _.Move("B3100", WABEND.WNR_EXEC_SQL);

            /*" -6363- PERFORM B3100_SELECT_V1RCAPCOMP_DB_SELECT_1 */

            B3100_SELECT_V1RCAPCOMP_DB_SELECT_1();

            /*" -6366- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -6367- MOVE '*' TO WFIM-V1RCAPCOMP */
                _.Move("*", WFIM_V1RCAPCOMP);

                /*" -6368- ELSE */
            }
            else
            {


                /*" -6369- IF SQLCODE EQUAL -810 OR -811 */

                if (DB.SQLCODE.In("-810", "-811"))
                {

                    /*" -6370- PERFORM B3150-SELECT-V1RCAPCOMP */

                    B3150_SELECT_V1RCAPCOMP_SECTION();

                    /*" -6371- ELSE */
                }
                else
                {


                    /*" -6372- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -6373- DISPLAY 'ERRO SELECT V1RCAPCOMP' */
                        _.Display($"ERRO SELECT V1RCAPCOMP");

                        /*" -6376- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -6377- IF WFIM-V1RCAPCOMP NOT EQUAL SPACES */

            if (!WFIM_V1RCAPCOMP.IsEmpty())
            {

                /*" -6380- GO TO B3100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B3100_999_EXIT*/ //GOTO
                return;
            }


            /*" -6384- IF PCOM-OPERACAO EQUAL 200 OR 210 OR 220 OR 400 */

            if (PCOM_OPERACAO.In("200", "210", "220", "400"))
            {

                /*" -6384- MOVE '*' TO WFIM-V1RCAPCOMP. */
                _.Move("*", WFIM_V1RCAPCOMP);
            }


        }

        [StopWatch]
        /*" B3100-SELECT-V1RCAPCOMP-DB-SELECT-1 */
        public void B3100_SELECT_V1RCAPCOMP_DB_SELECT_1()
        {
            /*" -6363- EXEC SQL SELECT FONTE , NRRCAP , BCOAVISO , AGEAVISO , NRAVISO , OPERACAO INTO :PCOM-FONTE , :PCOM-NRRCAP , :PCOM-BCOAVISO , :PCOM-AGEAVISO , :PCOM-NRAVISO , :PCOM-OPERACAO FROM SEGUROS.V1RCAPCOMP WHERE NRRCAP = :ENDO-NRRCAP AND NRRCAPCO = 0 AND SITUACAO = '0' WITH UR END-EXEC. */

            var b3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1 = new B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1()
            {
                ENDO_NRRCAP = ENDO_NRRCAP.ToString(),
            };

            var executed_1 = B3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1.Execute(b3100_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PCOM_FONTE, PCOM_FONTE);
                _.Move(executed_1.PCOM_NRRCAP, PCOM_NRRCAP);
                _.Move(executed_1.PCOM_BCOAVISO, PCOM_BCOAVISO);
                _.Move(executed_1.PCOM_AGEAVISO, PCOM_AGEAVISO);
                _.Move(executed_1.PCOM_NRAVISO, PCOM_NRAVISO);
                _.Move(executed_1.PCOM_OPERACAO, PCOM_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3100_999_EXIT*/

        [StopWatch]
        /*" B3150-SELECT-V1RCAPCOMP-SECTION */
        private void B3150_SELECT_V1RCAPCOMP_SECTION()
        {
            /*" -6396- MOVE 'B3150' TO WNR-EXEC-SQL. */
            _.Move("B3150", WABEND.WNR_EXEC_SQL);

            /*" -6415- PERFORM B3150_SELECT_V1RCAPCOMP_DB_SELECT_1 */

            B3150_SELECT_V1RCAPCOMP_DB_SELECT_1();

            /*" -6418- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -6419- MOVE '*' TO WFIM-V1RCAPCOMP */
                _.Move("*", WFIM_V1RCAPCOMP);

                /*" -6420- ELSE */
            }
            else
            {


                /*" -6421- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -6422- DISPLAY 'ERRO SELECT V1RCAPCOMP' */
                    _.Display($"ERRO SELECT V1RCAPCOMP");

                    /*" -6423- DISPLAY ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                    $" {ENDO_FONTE} {ENDO_NRRCAP}"
                    .Display();

                    /*" -6423- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B3150-SELECT-V1RCAPCOMP-DB-SELECT-1 */
        public void B3150_SELECT_V1RCAPCOMP_DB_SELECT_1()
        {
            /*" -6415- EXEC SQL SELECT FONTE , NRRCAP , BCOAVISO , AGEAVISO , NRAVISO , OPERACAO INTO :PCOM-FONTE , :PCOM-NRRCAP , :PCOM-BCOAVISO , :PCOM-AGEAVISO , :PCOM-NRAVISO , :PCOM-OPERACAO FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :ENDO-FONTE AND NRRCAP = :ENDO-NRRCAP AND NRRCAPCO = 0 AND SITUACAO = '0' WITH UR END-EXEC. */

            var b3150_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1 = new B3150_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1()
            {
                ENDO_NRRCAP = ENDO_NRRCAP.ToString(),
                ENDO_FONTE = ENDO_FONTE.ToString(),
            };

            var executed_1 = B3150_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1.Execute(b3150_SELECT_V1RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PCOM_FONTE, PCOM_FONTE);
                _.Move(executed_1.PCOM_NRRCAP, PCOM_NRRCAP);
                _.Move(executed_1.PCOM_BCOAVISO, PCOM_BCOAVISO);
                _.Move(executed_1.PCOM_AGEAVISO, PCOM_AGEAVISO);
                _.Move(executed_1.PCOM_NRAVISO, PCOM_NRAVISO);
                _.Move(executed_1.PCOM_OPERACAO, PCOM_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3150_999_EXIT*/

        [StopWatch]
        /*" B3160-ALTERA-V0PARCELA-SECTION */
        private void B3160_ALTERA_V0PARCELA_SECTION()
        {
            /*" -6435- MOVE 'B3160' TO WNR-EXEC-SQL. */
            _.Move("B3160", WABEND.WNR_EXEC_SQL);

            /*" -6442- PERFORM B3160_ALTERA_V0PARCELA_DB_UPDATE_1 */

            B3160_ALTERA_V0PARCELA_DB_UPDATE_1();

            /*" -6445- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6448- DISPLAY 'ERRO UPDATE V0PARCELA      ' ' ' PARC-NUM-APOLICE ' ' PARC-NRENDOS ' ' PARC-NRPARCEL. */

                $"ERRO UPDATE V0PARCELA       {PARC_NUM_APOLICE} {PARC_NRENDOS} {PARC_NRPARCEL}"
                .Display();
            }


        }

        [StopWatch]
        /*" B3160-ALTERA-V0PARCELA-DB-UPDATE-1 */
        public void B3160_ALTERA_V0PARCELA_DB_UPDATE_1()
        {
            /*" -6442- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = 1, SITUACAO = '0' WHERE NUM_APOLICE = :PARC-NUM-APOLICE AND NRENDOS = :PARC-NRENDOS AND NRPARCEL = :PARC-NRPARCEL END-EXEC. */

            var b3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1 = new B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1()
            {
                PARC_NUM_APOLICE = PARC_NUM_APOLICE.ToString(),
                PARC_NRPARCEL = PARC_NRPARCEL.ToString(),
                PARC_NRENDOS = PARC_NRENDOS.ToString(),
            };

            B3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1.Execute(b3160_ALTERA_V0PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3160_999_EXIT*/

        [StopWatch]
        /*" B3200-SELECT-V1AVISALDOS-SECTION */
        private void B3200_SELECT_V1AVISALDOS_SECTION()
        {
            /*" -6460- MOVE 'B3200' TO WNR-EXEC-SQL. */
            _.Move("B3200", WABEND.WNR_EXEC_SQL);

            /*" -6468- PERFORM B3200_SELECT_V1AVISALDOS_DB_SELECT_1 */

            B3200_SELECT_V1AVISALDOS_DB_SELECT_1();

            /*" -6471- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6472- MOVE '*' TO WFIM-V1AVISALDOS */
                _.Move("*", WFIM_V1AVISALDOS);

                /*" -6475- DISPLAY 'ERRO SELECT V1AVISALDOS' ' ' V1ASAL-BCOAVISO ' ' V1ASAL-AGEAVISO ' ' V1ASAL-NRAVISO. */

                $"ERRO SELECT V1AVISALDOS {V1ASAL_BCOAVISO} {V1ASAL_AGEAVISO} {V1ASAL_NRAVISO}"
                .Display();
            }


        }

        [StopWatch]
        /*" B3200-SELECT-V1AVISALDOS-DB-SELECT-1 */
        public void B3200_SELECT_V1AVISALDOS_DB_SELECT_1()
        {
            /*" -6468- EXEC SQL SELECT SDOATU INTO :V1ASAL-SDOATU FROM SEGUROS.V1AVISOS_SALDOS WHERE BCOAVISO = :V1ASAL-BCOAVISO AND AGEAVISO = :V1ASAL-AGEAVISO AND NRAVISO = :V1ASAL-NRAVISO WITH UR END-EXEC. */

            var b3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1 = new B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1()
            {
                V1ASAL_BCOAVISO = V1ASAL_BCOAVISO.ToString(),
                V1ASAL_AGEAVISO = V1ASAL_AGEAVISO.ToString(),
                V1ASAL_NRAVISO = V1ASAL_NRAVISO.ToString(),
            };

            var executed_1 = B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1.Execute(b3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1ASAL_SDOATU, V1ASAL_SDOATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3200_999_EXIT*/

        [StopWatch]
        /*" B3300-ALTERA-V0AVISALDOS-SECTION */
        private void B3300_ALTERA_V0AVISALDOS_SECTION()
        {
            /*" -6495- MOVE 'B3300' TO WNR-EXEC-SQL. */
            _.Move("B3300", WABEND.WNR_EXEC_SQL);

            /*" -6498- COMPUTE V1ASAL-SDOATU EQUAL V1ASAL-SDOATU - PCOM-VLRCAP. */
            V1ASAL_SDOATU.Value = V1ASAL_SDOATU - PCOM_VLRCAP;

            /*" -6505- PERFORM B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1 */

            B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1();

            /*" -6508- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6511- DISPLAY 'ERRO UPDATE V0AVISOS_SALDOS' ' ' PCOM-BCOAVISO ' ' PCOM-AGEAVISO ' ' PCOM-NRAVISO. */

                $"ERRO UPDATE V0AVISOS_SALDOS {PCOM_BCOAVISO} {PCOM_AGEAVISO} {PCOM_NRAVISO}"
                .Display();
            }


        }

        [StopWatch]
        /*" B3300-ALTERA-V0AVISALDOS-DB-UPDATE-1 */
        public void B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1()
        {
            /*" -6505- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = :V1ASAL-SDOATU, TIMESTAMP = CURRENT TIMESTAMP WHERE BCOAVISO = :V1ASAL-BCOAVISO AND AGEAVISO = :V1ASAL-AGEAVISO AND NRAVISO = :V1ASAL-NRAVISO END-EXEC. */

            var b3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1 = new B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1()
            {
                V1ASAL_SDOATU = V1ASAL_SDOATU.ToString(),
                V1ASAL_BCOAVISO = V1ASAL_BCOAVISO.ToString(),
                V1ASAL_AGEAVISO = V1ASAL_AGEAVISO.ToString(),
                V1ASAL_NRAVISO = V1ASAL_NRAVISO.ToString(),
            };

            B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1.Execute(b3300_ALTERA_V0AVISALDOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3300_999_EXIT*/

        [StopWatch]
        /*" B4000-ATUALIZA-ENDOSSO-SECTION */
        private void B4000_ATUALIZA_ENDOSSO_SECTION()
        {
            /*" -6653- MOVE 'B4000' TO WNR-EXEC-SQL. */
            _.Move("B4000", WABEND.WNR_EXEC_SQL);

            /*" -6668- IF ((ENDO-NRRCAP > 0) AND (ENDO-QTPARCEL = 0 OR 1)) OR ((ENDO-NUMBIL > 0) AND (ENDO-CODPRODU NOT = 32) AND (ENDO-VLRCAP > 0) AND (ENDO-QTPARCEL = 0 OR 1)) OR ((ENDO-CODPRODU = 32) AND (ENDO-VLRCAP > 0) AND (ENDO-AGERCAP = 9000) AND (ENDO-QTPARCEL = 0 OR 1)) OR ((ENDO-CODPRODU = 83) AND (ENDO-VLRCAP > 0) AND (ENDO-QTPARCEL = 0 OR 1)) */

            if (((ENDO_NRRCAP > 0) && (ENDO_QTPARCEL.In("0", "1"))) || ((ENDO_NUMBIL > 0) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 0) && (ENDO_QTPARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 0) && (ENDO_AGERCAP == 9000) && (ENDO_QTPARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 0) && (ENDO_QTPARCEL.In("0", "1"))))
            {

                /*" -6669- MOVE '1' TO WSITUACAO */
                _.Move("1", WSITUACAO);

                /*" -6670- ELSE */
            }
            else
            {


                /*" -6675- MOVE '0' TO WSITUACAO. */
                _.Move("0", WSITUACAO);
            }


            /*" -6676- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

            if (ENDO_TIPO_ENDOSSO == "4")
            {

                /*" -6678- MOVE '1' TO WSITUACAO. */
                _.Move("1", WSITUACAO);
            }


            /*" -6685- PERFORM B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1 */

            B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1();

            /*" -6688- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6689- DISPLAY 'EM0030B - ERRO UPDATE V0ENDOSSO' */
                _.Display($"EM0030B - ERRO UPDATE V0ENDOSSO");

                /*" -6693- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6704- IF (ENDO-CODPRODU EQUAL 1803 OR 1805) AND (ENDO-NRENDOS EQUAL 0 ) */

            if ((ENDO_CODPRODU.In("1803", "1805")) && (ENDO_NRENDOS == 0))
            {

                /*" -6706- PERFORM B4050-00-INSERT-SOL-TITULO-CAP */

                B4050_00_INSERT_SOL_TITULO_CAP_SECTION();

                /*" -6708- END-IF. */
            }


            /*" -6709- MOVE 'EM0100B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0100B1", V0EDIA_CODRELAT);

            /*" -6710- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -6711- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -6712- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -6713- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -6714- MOVE APOL-ORGAO TO V0EDIA-ORGAO. */
            _.Move(APOL_ORGAO, V0EDIA_ORGAO);

            /*" -6715- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -6716- MOVE ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(ENDO_FONTE, V0EDIA_FONTE);

            /*" -6717- MOVE ZEROS TO V0EDIA-CONGENER. */
            _.Move(0, V0EDIA_CONGENER);

            /*" -6718- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -6725- MOVE HIST-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(HIST_COD_EMPRESA, V0EDIA_COD_EMP);

            /*" -6727- IF ENDO-CODPRODU EQUAL 1803 OR 1805 NEXT SENTENCE */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -6728- ELSE */
            }
            else
            {


                /*" -6730- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6737- MOVE 'EM0090B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0090B1", V0EDIA_CODRELAT);

            /*" -6739- IF ENDO-CODPRODU EQUAL 1803 OR 1805 NEXT SENTENCE */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -6740- ELSE */
            }
            else
            {


                /*" -6742- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6744- MOVE 'EM0101B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0101B1", V0EDIA_CODRELAT);

            /*" -6751- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -6753- IF ENDO-CODPRODU EQUAL 1803 OR 1805 NEXT SENTENCE */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -6754- ELSE */
            }
            else
            {


                /*" -6756- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6757- IF ENDO-RAMO EQUAL ( 31 OR 53 ) */

            if (ENDO_RAMO.In("31", "53"))
            {

                /*" -6758- MOVE 'AU0050B1' TO V0EDIA-CODRELAT */
                _.Move("AU0050B1", V0EDIA_CODRELAT);

                /*" -6760- MOVE ZEROS TO V0EDIA-ORGAO */
                _.Move(0, V0EDIA_ORGAO);

                /*" -6762- PERFORM B4200-INCLUI-V0EMISDIARIA */

                B4200_INCLUI_V0EMISDIARIA_SECTION();

                /*" -6763- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -6764- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -6766- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6768- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                    if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                    {

                        /*" -6769- IF ENDO-QTPARCEL EQUAL ZEROS */

                        if (ENDO_QTPARCEL == 00)
                        {

                            /*" -6770- MOVE ZEROS TO V0EDIA-NRPARCEL */
                            _.Move(0, V0EDIA_NRPARCEL);

                            /*" -6771- ELSE */
                        }
                        else
                        {


                            /*" -6773- MOVE 1 TO V0EDIA-NRPARCEL */
                            _.Move(1, V0EDIA_NRPARCEL);

                            /*" -6775- END-IF */
                        }


                        /*" -6777- PERFORM B4200-INCLUI-V0EMISDIARIA */

                        B4200_INCLUI_V0EMISDIARIA_SECTION();

                        /*" -6779- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                        if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                        {

                            /*" -6780- MOVE ZEROS TO V0EDIA-NRPARCEL */
                            _.Move(0, V0EDIA_NRPARCEL);

                            /*" -6781- MOVE 'AU2060B1' TO V0EDIA-CODRELAT */
                            _.Move("AU2060B1", V0EDIA_CODRELAT);

                            /*" -6782- MOVE ZEROS TO V0EDIA-ORGAO */
                            _.Move(0, V0EDIA_ORGAO);

                            /*" -6783- PERFORM B4200-INCLUI-V0EMISDIARIA */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();

                            /*" -6784- MOVE 'AU2070B1' TO V0EDIA-CODRELAT */
                            _.Move("AU2070B1", V0EDIA_CODRELAT);

                            /*" -6785- MOVE ZEROS TO V0EDIA-ORGAO */
                            _.Move(0, V0EDIA_ORGAO);

                            /*" -6787- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();
                        }

                    }

                }

            }


            /*" -6791- IF ENDO-RAMO EQUAL 53 AND ENDO-ORGAO EQUAL 10 AND ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_RAMO == 53 && ENDO_ORGAO == 10 && ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -6792- IF ENDO-TIPO-ENDOSSO EQUAL '4' OR '5' */

                if (ENDO_TIPO_ENDOSSO.In("4", "5"))
                {

                    /*" -6793- MOVE 'AU2060B1' TO V0EDIA-CODRELAT */
                    _.Move("AU2060B1", V0EDIA_CODRELAT);

                    /*" -6794- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6797- PERFORM B4200-INCLUI-V0EMISDIARIA */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();

                    /*" -6798- MOVE 'AU2070B1' TO V0EDIA-CODRELAT */
                    _.Move("AU2070B1", V0EDIA_CODRELAT);

                    /*" -6799- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6801- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -6802- IF ENDO-RAMO EQUAL (40 OR 67 OR 45 OR 75) */

            if (ENDO_RAMO.In("40", "67", "45", "75"))
            {

                /*" -6803- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -6804- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -6805- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6807- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -6808- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -6815- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' OR '5' OR '3' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1", "5", "3"))
                {

                    /*" -6816- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -6817- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6831- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -6833- IF ENDO-RAMO EQUAL 14 AND (ENDO-CODPRODU EQUAL 1403 OR 1404) */

            if (ENDO_RAMO == 14 && (ENDO_CODPRODU.In("1403", "1404")))
            {

                /*" -6834- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -6835- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -6836- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6838- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -6843- IF (ENDO-RAMO EQUAL 16 AND (ENDO-CODPRODU EQUAL 1601 AND ENDO-COD-EMPRESA EQUAL 5495) OR (ENDO-CODPRODU EQUAL 1602 AND ENDO-COD-EMPRESA EQUAL 0)) */

            if ((ENDO_RAMO == 16 && (ENDO_CODPRODU == 1601 && ENDO_COD_EMPRESA == 5495) || (ENDO_CODPRODU == 1602 && ENDO_COD_EMPRESA == 0)))
            {

                /*" -6844- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -6845- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -6846- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6848- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -6855- IF (ENDO-RAMO EQUAL 18 AND (ENDO-CODPRODU EQUAL 1801 AND ENDO-COD-EMPRESA EQUAL 5495) OR (ENDO-CODPRODU EQUAL 1802 AND ENDO-COD-EMPRESA EQUAL 0) OR (ENDO-CODPRODU EQUAL 1804 AND ENDO-COD-EMPRESA EQUAL 0)) */

            if ((ENDO_RAMO == 18 && (ENDO_CODPRODU == 1801 && ENDO_COD_EMPRESA == 5495) || (ENDO_CODPRODU == 1802 && ENDO_COD_EMPRESA == 0) || (ENDO_CODPRODU == 1804 && ENDO_COD_EMPRESA == 0)))
            {

                /*" -6856- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -6857- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -6858- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -6860- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -6862- MOVE 'EM0102B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0102B1", V0EDIA_CODRELAT);

            /*" -6864- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -6866- PERFORM B4100-LE-V1APOLCORRET. */

            B4100_LE_V1APOLCORRET_SECTION();

            /*" -6868- PERFORM B4200-INCLUI-V0EMISDIARIA. */

            B4200_INCLUI_V0EMISDIARIA_SECTION();

            /*" -6869- MOVE APOL-ORGAO TO V0EDIA-ORGAO. */
            _.Move(APOL_ORGAO, V0EDIA_ORGAO);

            /*" -6884- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -6885- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' */

            if (ENDO_TIPO_ENDOSSO != "0")
            {

                /*" -6887- IF APOL-RAMO EQUAL 31 OR 53 OR 81 OR 20 NEXT SENTENCE */

                if (APOL_RAMO.In("31", "53", "81", "20"))
                {

                    /*" -6888- ELSE */
                }
                else
                {


                    /*" -6889- IF ENDO-NUMBIL EQUAL ZEROS */

                    if (ENDO_NUMBIL == 00)
                    {

                        /*" -6897- IF ((ENDO-CODPRODU EQUAL 1403 OR 1404) OR ((ENDO-CODPRODU EQUAL 1601 OR 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR 1802 OR 1804) AND ENDO-COD-EMPRESA EQUAL 0) OR (ENDO-CODPRODU EQUAL 1803 OR 1805)) NEXT SENTENCE */

                        if (((ENDO_CODPRODU.In("1403", "1404")) || ((ENDO_CODPRODU.In("1601", "1801")) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU.In("1602", "1802", "1804")) && ENDO_COD_EMPRESA == 0) || (ENDO_CODPRODU.In("1803", "1805"))))
                        {

                            /*" -6898- ELSE */
                        }
                        else
                        {


                            /*" -6899- MOVE 'EM0200B1' TO V0EDIA-CODRELAT */
                            _.Move("EM0200B1", V0EDIA_CODRELAT);

                            /*" -6901- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();
                        }

                    }

                }

            }


            /*" -6902- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -6903- IF ENDO-NUMBIL EQUAL ZEROS */

                if (ENDO_NUMBIL == 00)
                {

                    /*" -6904- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL */
                    _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

                    /*" -6905- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS */
                    _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

                    /*" -6906- MOVE ZEROS TO V0EDIA-NRPARCEL */
                    _.Move(0, V0EDIA_NRPARCEL);

                    /*" -6907- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO */
                    _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

                    /*" -6908- MOVE APOL-ORGAO TO V0EDIA-ORGAO */
                    _.Move(APOL_ORGAO, V0EDIA_ORGAO);

                    /*" -6909- MOVE APOL-RAMO TO V0EDIA-RAMO */
                    _.Move(APOL_RAMO, V0EDIA_RAMO);

                    /*" -6910- MOVE ENDO-FONTE TO V0EDIA-FONTE */
                    _.Move(ENDO_FONTE, V0EDIA_FONTE);

                    /*" -6911- MOVE ZEROS TO V0EDIA-CONGENER */
                    _.Move(0, V0EDIA_CONGENER);

                    /*" -6912- PERFORM B4100-LE-V1APOLCORRET */

                    B4100_LE_V1APOLCORRET_SECTION();

                    /*" -6925- MOVE HIST-COD-EMPRESA TO V0EDIA-COD-EMP */
                    _.Move(HIST_COD_EMPRESA, V0EDIA_COD_EMP);

                    /*" -6927- IF PRCB-TIPO-COBRANCA EQUAL ' ' OR PRCB-TIPO-COBRANCA EQUAL '0' */

                    if (PRCB_TIPO_COBRANCA == " " || PRCB_TIPO_COBRANCA == "0")
                    {

                        /*" -6928- MOVE 'EM0230B1' TO V0EDIA-CODRELAT */
                        _.Move("EM0230B1", V0EDIA_CODRELAT);

                        /*" -6934- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                        B4200_INCLUI_V0EMISDIARIA_SECTION();
                    }

                }

            }


            /*" -6936- IF APOL-RAMO EQUAL 31 OR 53 OR 81 OR 20 NEXT SENTENCE */

            if (APOL_RAMO.In("31", "53", "81", "20"))
            {

                /*" -6937- ELSE */
            }
            else
            {


                /*" -6941- IF ENDO-CODPRODU GREATER ZEROS */

                if (ENDO_CODPRODU > 00)
                {

                    /*" -6942- IF ENDO-NUMBIL EQUAL ZEROS */

                    if (ENDO_NUMBIL == 00)
                    {

                        /*" -6950- IF ((ENDO-CODPRODU EQUAL 1403 OR 1404) OR ((ENDO-CODPRODU EQUAL 1601 OR 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR 1802 OR 1804) AND ENDO-COD-EMPRESA EQUAL 0) OR (ENDO-CODPRODU EQUAL 1803 OR 1805)) NEXT SENTENCE */

                        if (((ENDO_CODPRODU.In("1403", "1404")) || ((ENDO_CODPRODU.In("1601", "1801")) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU.In("1602", "1802", "1804")) && ENDO_COD_EMPRESA == 0) || (ENDO_CODPRODU.In("1803", "1805"))))
                        {

                            /*" -6951- ELSE */
                        }
                        else
                        {


                            /*" -6952- MOVE 'EM0200B1' TO V0EDIA-CODRELAT */
                            _.Move("EM0200B1", V0EDIA_CODRELAT);

                            /*" -6953- PERFORM B4200-INCLUI-V0EMISDIARIA */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();

                            /*" -6954- END-IF */
                        }


                        /*" -6955- ELSE */
                    }
                    else
                    {


                        /*" -6956- PERFORM B4201-00-V1PRODUTO */

                        B4201_00_V1PRODUTO_SECTION();

                        /*" -6957- IF V1PROD-IDEIMPESPC EQUAL 'S' */

                        if (V1PROD_IDEIMPESPC == "S")
                        {

                            /*" -6958- MOVE 'PE0220B1' TO V0EDIA-CODRELAT */
                            _.Move("PE0220B1", V0EDIA_CODRELAT);

                            /*" -6963- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();
                        }

                    }

                }

            }


            /*" -6965- IF (ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' ) AND ENDO-CODPRODU NOT EQUAL 1803 AND 1805 */

            if ((ENDO_TIPO_ENDOSSO.In("3", "5")) && !ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -6966- MOVE 'EM0202B1' TO V0EDIA-CODRELAT */
                _.Move("EM0202B1", V0EDIA_CODRELAT);

                /*" -6967- MOVE APOL-RAMO TO V0EDIA-RAMO */
                _.Move(APOL_RAMO, V0EDIA_RAMO);

                /*" -6969- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6970- IF ENDO-TIPO-ENDOSSO EQUAL '5' */

            if (ENDO_TIPO_ENDOSSO == "5")
            {

                /*" -6971- MOVE 'EM0120B1' TO V0EDIA-CODRELAT */
                _.Move("EM0120B1", V0EDIA_CODRELAT);

                /*" -6973- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6974- IF APOL-RAMO EQUAL 31 OR 53 OR 81 OR 20 */

            if (APOL_RAMO.In("31", "53", "81", "20"))
            {

                /*" -6975- MOVE 'EM0290B1' TO V0EDIA-CODRELAT */
                _.Move("EM0290B1", V0EDIA_CODRELAT);

                /*" -6977- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6981- IF APOL-RAMO EQUAL 40 OR APOL-RAMO EQUAL 67 OR APOL-RAMO EQUAL 45 OR APOL-RAMO EQUAL 75 */

            if (APOL_RAMO == 40 || APOL_RAMO == 67 || APOL_RAMO == 45 || APOL_RAMO == 75)
            {

                /*" -6982- MOVE 'EM0292B1' TO V0EDIA-CODRELAT */
                _.Move("EM0292B1", V0EDIA_CODRELAT);

                /*" -6984- PERFORM B4292-INCLUI-V0EMISDIARIA. */

                B4292_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -6985- IF APOL-RAMO EQUAL 71 */

            if (APOL_RAMO == 71)
            {

                /*" -6986- IF VIND-CODPRODU NOT LESS ZEROS */

                if (VIND_CODPRODU >= 00)
                {

                    /*" -6987- IF ENDO-CODPRODU EQUAL 7114 */

                    if (ENDO_CODPRODU == 7114)
                    {

                        /*" -6988- MOVE 'EM0292B1' TO V0EDIA-CODRELAT */
                        _.Move("EM0292B1", V0EDIA_CODRELAT);

                        /*" -6990- PERFORM B4292-INCLUI-V0EMISDIARIA. */

                        B4292_INCLUI_V0EMISDIARIA_SECTION();
                    }

                }

            }


            /*" -6991- IF ENDO-RAMO EQUAL 14 OR 18 OR 71 OR 31 OR 53 */

            if (ENDO_RAMO.In("14", "18", "71", "31", "53"))
            {

                /*" -6992- IF ENDO-DATPRO > ENDO-DTINIVIG */

                if (ENDO_DATPRO > ENDO_DTINIVIG)
                {

                    /*" -6993- MOVE ENDO-DTINIVIG TO ENDO-DATPRO */
                    _.Move(ENDO_DTINIVIG, ENDO_DATPRO);

                    /*" -6994- PERFORM B4295-00-UPDATE-DATAPROP */

                    B4295_00_UPDATE_DATAPROP_SECTION();

                    /*" -6995- END-IF */
                }


                /*" -6995- END-IF. */
            }


        }

        [StopWatch]
        /*" B4000-ATUALIZA-ENDOSSO-DB-UPDATE-1 */
        public void B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1()
        {
            /*" -6685- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = :WSITUACAO ,DTEMIS = :SIST-DTMOVABE WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

            var b4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1 = new B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1()
            {
                SIST_DTMOVABE = SIST_DTMOVABE.ToString(),
                WSITUACAO = WSITUACAO.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1.Execute(b4000_ATUALIZA_ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4000_999_EXIT*/

        [StopWatch]
        /*" B4050-00-INSERT-SOL-TITULO-CAP-SECTION */
        private void B4050_00_INSERT_SOL_TITULO_CAP_SECTION()
        {
            /*" -7006- MOVE 'B4050' TO WNR-EXEC-SQL. */
            _.Move("B4050", WABEND.WNR_EXEC_SQL);

            /*" -7007- PERFORM B4055-00-VALIDA-TITULO-CAP */

            B4055_00_VALIDA_TITULO_CAP_SECTION();

            /*" -7008- IF WS-ERRO > 0 */

            if (WS_ERRO > 0)
            {

                /*" -7009- GO TO B4050-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4050_999_EXIT*/ //GOTO
                return;

                /*" -7011- END-IF */
            }


            /*" -7013- INITIALIZE LT3164S-AREA-PARAMETROS */
            _.Initialize(
                LBLT3164.LT3164S_AREA_PARAMETROS
            );

            /*" -7014- MOVE ENDO-CODPRODU TO LT3164S-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PRODUTO);

            /*" -7016- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3164S-COD-CLIENTE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_CLIENTE);

            /*" -7017- MOVE ENDO-NUM-APOLICE TO LT3164S-NUM-APOLICE */
            _.Move(ENDO_NUM_APOLICE, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_NUM_APOLICE);

            /*" -7018- MOVE 'LT2006B1' TO LT3164S-COD-PROGRAMA */
            _.Move("LT2006B1", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PROGRAMA);

            /*" -7019- MOVE '0' TO LT3164S-TIPO-SOLICITACAO */
            _.Move("0", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_TIPO_SOLICITACAO);

            /*" -7020- MOVE 'EM0030B' TO LT3164S-COD-USUARIO */
            _.Move("EM0030B", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_USUARIO);

            /*" -7021- MOVE '0' TO LT3164S-SIT-SOLICITACAO */
            _.Move("0", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_SIT_SOLICITACAO);

            /*" -7022- MOVE ENDO-DTINIVIG TO LT3164S-PARAM-DATE01 */
            _.Move(ENDO_DTINIVIG, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE01);

            /*" -7023- MOVE ENDO-DTTERVIG TO LT3164S-PARAM-DATE02 */
            _.Move(ENDO_DTTERVIG, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE02);

            /*" -7024- MOVE SIST-DTMOVABE TO LT3164S-PARAM-DATE03 */
            _.Move(SIST_DTMOVABE, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE03);

            /*" -7025- MOVE 0 TO LT3164S-PARAM-SMINT01 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT01);

            /*" -7026- MOVE 0 TO LT3164S-PARAM-SMINT02 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT02);

            /*" -7027- MOVE 0 TO LT3164S-PARAM-SMINT03 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT03);

            /*" -7028- MOVE 0 TO LT3164S-PARAM-INTG01 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG01);

            /*" -7029- MOVE 0 TO LT3164S-PARAM-INTG02 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG02);

            /*" -7030- MOVE 0 TO LT3164S-PARAM-INTG03 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG03);

            /*" -7031- MOVE ' ' TO LT3164S-PARAM-CHAR01 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR01);

            /*" -7032- MOVE ' ' TO LT3164S-PARAM-CHAR02 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR02);

            /*" -7033- MOVE ' ' TO LT3164S-PARAM-CHAR03 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR03);

            /*" -7034- MOVE ' ' TO LT3164S-PARAM-CHAR04 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR04);

            /*" -7036- MOVE ' ' TO LT3164S-PARAM-CHAR05 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR05);

            /*" -7038- CALL 'LT3164S' USING LT3164S-AREA-PARAMETROS. */
            _.Call("LT3164S", LBLT3164.LT3164S_AREA_PARAMETROS);

            /*" -7039- IF LT3164S-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO != 00)
            {

                /*" -7044- DISPLAY 'B4050 - ERRO RETORNO LT3164S' ' APOL:' LT3164S-NUM-APOLICE ' PROD:' LT3164S-COD-PRODUTO ' COD-ERRO:' LT3164S-COD-RETORNO ' MSG-ERRO:' LT3164S-MSG-RETORNO */

                $"B4050 - ERRO RETORNO LT3164S APOL:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_NUM_APOLICE} PROD:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PRODUTO} COD-ERRO:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO} MSG-ERRO:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_MSG_RETORNO}"
                .Display();

                /*" -7045- ELSE */
            }
            else
            {


                /*" -7051- ADD 1 TO AC-I-TITCAP-LOT */
                AC_I_TITCAP_LOT.Value = AC_I_TITCAP_LOT + 1;

                /*" -7051- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4050_999_EXIT*/

        [StopWatch]
        /*" B4055-00-VALIDA-TITULO-CAP-SECTION */
        private void B4055_00_VALIDA_TITULO_CAP_SECTION()
        {
            /*" -7062- MOVE 'B4055' TO WNR-EXEC-SQL. */
            _.Move("B4055", WABEND.WNR_EXEC_SQL);

            /*" -7063- MOVE 0 TO WS-ERRO */
            _.Move(0, WS_ERRO);

            /*" -7064- MOVE 'SPBLTPRM' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("SPBLTPRM", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -7065- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -7066- MOVE ENDO-CODPRODU TO LTSOLPAR-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -7067- MOVE 87 TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(87, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -7068- MOVE SIST-DTMOVABE TO LTSOLPAR-PARAM-DATE01 */
            _.Move(SIST_DTMOVABE, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -7070- MOVE SPACES TO LTSOLPAR-PARAM-DATE03 */
            _.Move("", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -7080- PERFORM B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1 */

            B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1();

            /*" -7085- IF (SQLCODE NOT EQUAL ZEROS ) OR (LTSOLPAR-PARAM-DATE03 EQUAL SPACES ) OR (LTSOLPAR-PARAM-DATE03 < '1999-01-01' ) */

            if ((DB.SQLCODE != 00) || (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.IsEmpty()) || (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03 < "1999-01-01"))
            {

                /*" -7093- DISPLAY 'B4055-ERRO ' ' SQLCODE:' SQLCODE ' PROG:' LTSOLPAR-COD-PROGRAMA ' PROD:' LTSOLPAR-COD-PRODUTO ' SMINT01:' LTSOLPAR-PARAM-SMINT01 ' DATE01:' LTSOLPAR-PARAM-DATE01 ' APOL:' ENDO-NUM-APOLICE ' PARAM DT COMPRA CAP NAO ENCONTRADO' */

                $"B4055-ERRO  SQLCODE:{DB.SQLCODE} PROG:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA} PROD:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO} SMINT01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01} DATE01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01} APOL:{ENDO_NUM_APOLICE} PARAM DT COMPRA CAP NAO ENCONTRADO"
                .Display();

                /*" -7094- MOVE 1 TO WS-ERRO */
                _.Move(1, WS_ERRO);

                /*" -7095- GO TO B4055-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4055_999_EXIT*/ //GOTO
                return;

                /*" -7097- END-IF */
            }


            /*" -7105- DISPLAY 'B4055-' ' PROG:' LTSOLPAR-COD-PROGRAMA ' PROD:' LTSOLPAR-COD-PRODUTO ' SMINT01:' LTSOLPAR-PARAM-SMINT01 ' DATE01:' LTSOLPAR-PARAM-DATE01 ' APOL:' ENDO-NUM-APOLICE ' TIT CAP SOLICITACAO COM SUCESSO' */

            $"B4055- PROG:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA} PROD:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO} SMINT01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01} DATE01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01} APOL:{ENDO_NUM_APOLICE} TIT CAP SOLICITACAO COM SUCESSO"
            .Display();

            /*" -7105- . */

        }

        [StopWatch]
        /*" B4055-00-VALIDA-TITULO-CAP-DB-SELECT-1 */
        public void B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1()
        {
            /*" -7080- EXEC SQL SELECT PARAM_DATE03 INTO :LTSOLPAR-PARAM-DATE03 FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND SIT_SOLICITACAO = '0' AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC. */

            var b4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1 = new B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1()
            {
                LTSOLPAR_PARAM_SMINT01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.ToString(),
                LTSOLPAR_COD_PROGRAMA = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.ToString(),
                LTSOLPAR_PARAM_DATE01 = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.ToString(),
                LTSOLPAR_COD_PRODUTO = LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.ToString(),
            };

            var executed_1 = B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1.Execute(b4055_00_VALIDA_TITULO_CAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LTSOLPAR_PARAM_DATE03, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4055_999_EXIT*/

        [StopWatch]
        /*" B4100-LE-V1APOLCORRET-SECTION */
        private void B4100_LE_V1APOLCORRET_SECTION()
        {
            /*" -7114- MOVE 'B4100' TO WNR-EXEC-SQL. */
            _.Move("B4100", WABEND.WNR_EXEC_SQL);

            /*" -7115- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' */

            if (ENDO_TIPO_ENDOSSO != "0")
            {

                /*" -7115- GO TO B4102-SELECT-ENDOSSO. */

                B4102_SELECT_ENDOSSO(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM B4101_SELECT_APOLICE */

            B4101_SELECT_APOLICE();

        }

        [StopWatch]
        /*" B4101-SELECT-APOLICE */
        private void B4101_SELECT_APOLICE(bool isPerform = false)
        {
            /*" -7121- MOVE 'B4101' TO WNR-EXEC-SQL. */
            _.Move("B4101", WABEND.WNR_EXEC_SQL);

            /*" -7133- PERFORM B4101_SELECT_APOLICE_DB_SELECT_1 */

            B4101_SELECT_APOLICE_DB_SELECT_1();

            /*" -7136- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -7137- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7138- MOVE ZEROS TO V0EDIA-CODCORR */
                    _.Move(0, V0EDIA_CODCORR);

                    /*" -7142- ELSE */
                }
                else
                {


                    /*" -7144- DISPLAY 'B4101-PROBLEMAS NO CORRETOR DA APOLICE ' ENDO-NUM-APOLICE */
                    _.Display($"B4101-PROBLEMAS NO CORRETOR DA APOLICE {ENDO_NUM_APOLICE}");

                    /*" -7146- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -7146- GO TO B4100-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: B4100_999_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" B4101-SELECT-APOLICE-DB-SELECT-1 */
        public void B4101_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -7133- EXEC SQL SELECT DISTINCT(CODCORR) INTO :V0EDIA-CODCORR FROM SEGUROS.V1APOLCORRET WHERE INDCRT = '1' AND TIPCOM = '1' AND NUM_APOLICE = :ENDO-NUM-APOLICE AND CODSUBES = :ENDO-CODSUBES AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG ORDER BY CODCORR WITH UR END-EXEC. */

            var b4101_SELECT_APOLICE_DB_SELECT_1_Query1 = new B4101_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_CODSUBES = ENDO_CODSUBES.ToString(),
                ENDO_DTINIVIG = ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = B4101_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(b4101_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0EDIA_CODCORR, V0EDIA_CODCORR);
            }


        }

        [StopWatch]
        /*" B4102-SELECT-ENDOSSO */
        private void B4102_SELECT_ENDOSSO(bool isPerform = false)
        {
            /*" -7152- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -7154- MOVE 'B4102' TO WNR-EXEC-SQL. */
            _.Move("B4102", WABEND.WNR_EXEC_SQL);

            /*" -7165- PERFORM B4102_SELECT_ENDOSSO_DB_SELECT_1 */

            B4102_SELECT_ENDOSSO_DB_SELECT_1();

            /*" -7168- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -7169- MOVE ZEROS TO V0EDIA-CODCORR */
                _.Move(0, V0EDIA_CODCORR);

                /*" -7172- DISPLAY 'B4102-PROBLEMAS NO CORRETOR DA APOLICE ' ENDO-NUM-APOLICE '  DESPREZADO' */

                $"B4102-PROBLEMAS NO CORRETOR DA APOLICE {ENDO_NUM_APOLICE}  DESPREZADO"
                .Display();

                /*" -7174- GO TO B4100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4100_999_EXIT*/ //GOTO
                return;
            }


            /*" -7175- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -7181- IF (ENDO-RAMO NOT EQUAL PARM-RAMO-VG AND PARM-RAMO-AP AND PARM-RAMO-PRESTA) OR (SUB-OPC-CORRETAGEM NOT EQUAL '2' ) */

                if ((!ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_PRESTA.ToString())) || (SUB_OPC_CORRETAGEM != "2"))
                {

                    /*" -7183- DISPLAY 'B4102-PROBLEMAS NO CORRETOR DA APOLICE ' ENDO-NUM-APOLICE */
                    _.Display($"B4102-PROBLEMAS NO CORRETOR DA APOLICE {ENDO_NUM_APOLICE}");

                    /*" -7183- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B4102-SELECT-ENDOSSO-DB-SELECT-1 */
        public void B4102_SELECT_ENDOSSO_DB_SELECT_1()
        {
            /*" -7165- EXEC SQL SELECT DISTINCT(CODCORR) INTO :V0EDIA-CODCORR FROM SEGUROS.V1APOLCORRET WHERE INDCRT = '1' AND TIPCOM = '1' AND CODSUBES = :ENDO-CODSUBES AND NUM_APOLICE = :ENDO-NUM-APOLICE AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG ORDER BY CODCORR WITH UR END-EXEC. */

            var b4102_SELECT_ENDOSSO_DB_SELECT_1_Query1 = new B4102_SELECT_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_CODSUBES = ENDO_CODSUBES.ToString(),
                ENDO_DTINIVIG = ENDO_DTINIVIG.ToString(),
            };

            var executed_1 = B4102_SELECT_ENDOSSO_DB_SELECT_1_Query1.Execute(b4102_SELECT_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0EDIA_CODCORR, V0EDIA_CODCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4100_999_EXIT*/

        [StopWatch]
        /*" B4200-INCLUI-V0EMISDIARIA-SECTION */
        private void B4200_INCLUI_V0EMISDIARIA_SECTION()
        {
            /*" -7193- MOVE 'B4200' TO WNR-EXEC-SQL. */
            _.Move("B4200", WABEND.WNR_EXEC_SQL);

            /*" -7194- MOVE '0' TO V0EDIA-SITUACAO. */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -7200- IF V0EDIA-CODRELAT NOT EQUAL ( 'EM0201B1' AND 'EM0202B1' AND 'EM0120B1' AND 'EM0230B1' AND 'EM0015B1' AND 'AU0050B1' ) */

            if (!V0EDIA_CODRELAT.In("EM0201B1", "EM0202B1", "EM0120B1", "EM0230B1", "EM0015B1", "AU0050B1"))
            {

                /*" -7201- IF VIND-CODPRODU NOT LESS ZEROS */

                if (VIND_CODPRODU >= 00)
                {

                    /*" -7202- IF ENDO-CODPRODU EQUAL 3101 OR 3102 OR 3105 */

                    if (ENDO_CODPRODU.In("3101", "3102", "3105"))
                    {

                        /*" -7215- MOVE '1' TO V0EDIA-SITUACAO. */
                        _.Move("1", V0EDIA_SITUACAO);
                    }

                }

            }


            /*" -7217- IF V0EDIA-CODRELAT EQUAL 'EM0200B1' OR 'EM0220B1' */

            if (V0EDIA_CODRELAT.In("EM0200B1", "EM0220B1"))
            {

                /*" -7218- IF VIND-CODPRODU NOT LESS ZEROS */

                if (VIND_CODPRODU >= 00)
                {

                    /*" -7219- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

                    if (ENDO_CODPRODU.In("1803", "1805"))
                    {

                        /*" -7223- MOVE '1' TO V0EDIA-SITUACAO . */
                        _.Move("1", V0EDIA_SITUACAO);
                    }

                }

            }


            /*" -7238- PERFORM B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -7241- DISPLAY ' ' */
            _.Display($" ");

            /*" -7242- DISPLAY 'GRAVANDO A V0EMISDIARIA - SQLCODE: ' SQLCODE */
            _.Display($"GRAVANDO A V0EMISDIARIA - SQLCODE: {DB.SQLCODE}");

            /*" -7243- DISPLAY 'V0EDIA-CODRELAT = ' V0EDIA-CODRELAT */
            _.Display($"V0EDIA-CODRELAT = {V0EDIA_CODRELAT}");

            /*" -7244- DISPLAY 'V0EDIA-NUM-APOL = ' V0EDIA-NUM-APOL */
            _.Display($"V0EDIA-NUM-APOL = {V0EDIA_NUM_APOL}");

            /*" -7245- DISPLAY 'V0EDIA-NRENDOS  = ' V0EDIA-NRENDOS */
            _.Display($"V0EDIA-NRENDOS  = {V0EDIA_NRENDOS}");

            /*" -7246- DISPLAY 'V0EDIA-NRPARCEL = ' V0EDIA-NRPARCEL */
            _.Display($"V0EDIA-NRPARCEL = {V0EDIA_NRPARCEL}");

            /*" -7247- DISPLAY 'V0EDIA-DTMOVTO  = ' V0EDIA-DTMOVTO */
            _.Display($"V0EDIA-DTMOVTO  = {V0EDIA_DTMOVTO}");

            /*" -7248- DISPLAY 'V0EDIA-ORGAO    = ' V0EDIA-ORGAO */
            _.Display($"V0EDIA-ORGAO    = {V0EDIA_ORGAO}");

            /*" -7249- DISPLAY 'V0EDIA-RAMO     = ' V0EDIA-RAMO */
            _.Display($"V0EDIA-RAMO     = {V0EDIA_RAMO}");

            /*" -7250- DISPLAY 'V0EDIA-FONTE    = ' V0EDIA-FONTE */
            _.Display($"V0EDIA-FONTE    = {V0EDIA_FONTE}");

            /*" -7251- DISPLAY 'V0EDIA-CONGENER = ' V0EDIA-CONGENER */
            _.Display($"V0EDIA-CONGENER = {V0EDIA_CONGENER}");

            /*" -7252- DISPLAY 'V0EDIA-CODCORR  = ' V0EDIA-CODCORR */
            _.Display($"V0EDIA-CODCORR  = {V0EDIA_CODCORR}");

            /*" -7253- DISPLAY 'V0EDIA-SITUACAO = ' V0EDIA-SITUACAO */
            _.Display($"V0EDIA-SITUACAO = {V0EDIA_SITUACAO}");

            /*" -7255- DISPLAY 'V0EDIA-COD-EMP  = ' V0EDIA-COD-EMP . */
            _.Display($"V0EDIA-COD-EMP  = {V0EDIA_COD_EMP}");

            /*" -7256- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -7257- DISPLAY 'B4200-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B4200-00 (REGISTRO DUPLICADO) ... ");

                /*" -7259- GO TO B4200-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4200_999_EXIT*/ //GOTO
                return;
            }


            /*" -7260- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7261- DISPLAY 'B4200-00 (PROBLEMAS NA INSERCAO) -------------' */
                _.Display($"B4200-00 (PROBLEMAS NA INSERCAO) -------------");

                /*" -7262- DISPLAY 'V0EDIA-CODRELAT = ' V0EDIA-CODRELAT */
                _.Display($"V0EDIA-CODRELAT = {V0EDIA_CODRELAT}");

                /*" -7263- DISPLAY 'V0EDIA-NUM-APOL = ' V0EDIA-NUM-APOL */
                _.Display($"V0EDIA-NUM-APOL = {V0EDIA_NUM_APOL}");

                /*" -7264- DISPLAY 'V0EDIA-NRENDOS  = ' V0EDIA-NRENDOS */
                _.Display($"V0EDIA-NRENDOS  = {V0EDIA_NRENDOS}");

                /*" -7265- DISPLAY 'V0EDIA-NRPARCEL = ' V0EDIA-NRPARCEL */
                _.Display($"V0EDIA-NRPARCEL = {V0EDIA_NRPARCEL}");

                /*" -7266- DISPLAY 'V0EDIA-DTMOVTO  = ' V0EDIA-DTMOVTO */
                _.Display($"V0EDIA-DTMOVTO  = {V0EDIA_DTMOVTO}");

                /*" -7267- DISPLAY 'V0EDIA-ORGAO    = ' V0EDIA-ORGAO */
                _.Display($"V0EDIA-ORGAO    = {V0EDIA_ORGAO}");

                /*" -7268- DISPLAY 'V0EDIA-RAMO     = ' V0EDIA-RAMO */
                _.Display($"V0EDIA-RAMO     = {V0EDIA_RAMO}");

                /*" -7269- DISPLAY 'V0EDIA-FONTE    = ' V0EDIA-FONTE */
                _.Display($"V0EDIA-FONTE    = {V0EDIA_FONTE}");

                /*" -7270- DISPLAY 'V0EDIA-CONGENER = ' V0EDIA-CONGENER */
                _.Display($"V0EDIA-CONGENER = {V0EDIA_CONGENER}");

                /*" -7271- DISPLAY 'V0EDIA-CODCORR  = ' V0EDIA-CODCORR */
                _.Display($"V0EDIA-CODCORR  = {V0EDIA_CODCORR}");

                /*" -7272- DISPLAY 'V0EDIA-SITUACAO = ' V0EDIA-SITUACAO */
                _.Display($"V0EDIA-SITUACAO = {V0EDIA_SITUACAO}");

                /*" -7273- DISPLAY 'V0EDIA-COD-EMP  = ' V0EDIA-COD-EMP */
                _.Display($"V0EDIA-COD-EMP  = {V0EDIA_COD_EMP}");

                /*" -7274- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -7276- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7276- ADD 1 TO AC-I-V0EMISDIARIA. */
            AC_I_V0EMISDIARIA.Value = AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" B4200-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -7238- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var b4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1 = new B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1()
            {
                V0EDIA_CODRELAT = V0EDIA_CODRELAT.ToString(),
                V0EDIA_NUM_APOL = V0EDIA_NUM_APOL.ToString(),
                V0EDIA_NRENDOS = V0EDIA_NRENDOS.ToString(),
                V0EDIA_NRPARCEL = V0EDIA_NRPARCEL.ToString(),
                V0EDIA_DTMOVTO = V0EDIA_DTMOVTO.ToString(),
                V0EDIA_ORGAO = V0EDIA_ORGAO.ToString(),
                V0EDIA_RAMO = V0EDIA_RAMO.ToString(),
                V0EDIA_FONTE = V0EDIA_FONTE.ToString(),
                V0EDIA_CONGENER = V0EDIA_CONGENER.ToString(),
                V0EDIA_CODCORR = V0EDIA_CODCORR.ToString(),
                V0EDIA_SITUACAO = V0EDIA_SITUACAO.ToString(),
                V0EDIA_COD_EMP = V0EDIA_COD_EMP.ToString(),
            };

            B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(b4200_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4200_999_EXIT*/

        [StopWatch]
        /*" B4201-00-V1PRODUTO-SECTION */
        private void B4201_00_V1PRODUTO_SECTION()
        {
            /*" -7289- MOVE 'B4201' TO WNR-EXEC-SQL. */
            _.Move("B4201", WABEND.WNR_EXEC_SQL);

            /*" -7299- PERFORM B4201_00_V1PRODUTO_DB_SELECT_1 */

            B4201_00_V1PRODUTO_DB_SELECT_1();

            /*" -7303- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7304- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7305- MOVE 'N' TO V1PROD-IDEIMPESPC */
                    _.Move("N", V1PROD_IDEIMPESPC);

                    /*" -7306- ELSE */
                }
                else
                {


                    /*" -7307- DISPLAY 'B4201-00 (PROBLEMAS NO SELECT DA VIPRODUTOR)..' */
                    _.Display($"B4201-00 (PROBLEMAS NO SELECT DA VIPRODUTOR)..");

                    /*" -7307- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B4201-00-V1PRODUTO-DB-SELECT-1 */
        public void B4201_00_V1PRODUTO_DB_SELECT_1()
        {
            /*" -7299- EXEC SQL SELECT VALUE(IDEIMPESPC, 'N' ) INTO :V1PROD-IDEIMPESPC FROM SEGUROS.V1PRODUTO WHERE CODPRODU = :ENDO-CODPRODU WITH UR END-EXEC. */

            var b4201_00_V1PRODUTO_DB_SELECT_1_Query1 = new B4201_00_V1PRODUTO_DB_SELECT_1_Query1()
            {
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
            };

            var executed_1 = B4201_00_V1PRODUTO_DB_SELECT_1_Query1.Execute(b4201_00_V1PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PROD_IDEIMPESPC, V1PROD_IDEIMPESPC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4201_999_EXIT*/

        [StopWatch]
        /*" B4210-00-INCLUI-RELATORIO-SECTION */
        private void B4210_00_INCLUI_RELATORIO_SECTION()
        {
            /*" -7319- MOVE 'B4210' TO WNR-EXEC-SQL. */
            _.Move("B4210", WABEND.WNR_EXEC_SQL);

            /*" -7320- MOVE 'EM0030B' TO V0RELA-CODUSU */
            _.Move("EM0030B", V0RELA_CODUSU);

            /*" -7321- MOVE SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -7322- MOVE 'AU' TO V0RELA-IDSISTEM */
            _.Move("AU", V0RELA_IDSISTEM);

            /*" -7323- MOVE 'AU0010B1' TO V0RELA-CODRELAT */
            _.Move("AU0010B1", V0RELA_CODRELAT);

            /*" -7324- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -7325- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -7326- MOVE SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -7327- MOVE SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -7328- MOVE SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -7329- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -7330- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -7331- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -7332- MOVE ENDO-FONTE TO V0RELA-FONTE */
            _.Move(ENDO_FONTE, V0RELA_FONTE);

            /*" -7333- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -7334- MOVE 31 TO V0RELA-RAMO */
            _.Move(31, V0RELA_RAMO);

            /*" -7335- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -7336- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -7337- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -7338- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -7339- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -7340- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -7341- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -7342- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -7343- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -7344- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -7345- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -7346- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -7347- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -7348- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -7349- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -7350- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -7351- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -7352- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -7353- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -7354- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -7355- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -7356- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -7357- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -7358- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -7360- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -7403- PERFORM B4210_00_INCLUI_RELATORIO_DB_INSERT_1 */

            B4210_00_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -7406- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -7407- DISPLAY 'B4210-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B4210-00 (REGISTRO DUPLICADO) ... ");

                /*" -7409- GO TO B4210-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4210_999_EXIT*/ //GOTO
                return;
            }


            /*" -7410- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7411- DISPLAY 'B4210-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"B4210-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -7413- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7413- ADD 1 TO AC-I-V0RELATORIO. */
            AC_I_V0RELATORIO.Value = AC_I_V0RELATORIO + 1;

        }

        [StopWatch]
        /*" B4210-00-INCLUI-RELATORIO-DB-INSERT-1 */
        public void B4210_00_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -7403- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var b4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1 = new B4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DATA_SOLICITACAO = V0RELA_DATA_SOLICITACAO.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QUANTIDADE = V0RELA_QUANTIDADE.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFERENCIA = V0RELA_DATA_REFERENCIA.ToString(),
                V0RELA_MES_REFERENCIA = V0RELA_MES_REFERENCIA.ToString(),
                V0RELA_ANO_REFERENCIA = V0RELA_ANO_REFERENCIA.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALIDA = V0RELA_MODALIDA.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOLICE = V0RELA_NUM_APOLICE.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOLIDER = V0RELA_APOLIDER.ToString(),
                V0RELA_ENDOSLID = V0RELA_ENDOSLID.ToString(),
                V0RELA_NUM_PARC_LIDER = V0RELA_NUM_PARC_LIDER.ToString(),
                V0RELA_NUM_SINISTRO = V0RELA_NUM_SINISTRO.ToString(),
                V0RELA_NUM_SINI_LIDER = V0RELA_NUM_SINI_LIDER.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PREVIA_DEFINITIVA = V0RELA_PREVIA_DEFINITIVA.ToString(),
                V0RELA_ANAL_RESUMO = V0RELA_ANAL_RESUMO.ToString(),
                V0RELA_COD_EMPRESA = V0RELA_COD_EMPRESA.ToString(),
                V0RELA_PERI_RENOVACAO = V0RELA_PERI_RENOVACAO.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
            };

            B4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1.Execute(b4210_00_INCLUI_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4210_999_EXIT*/

        [StopWatch]
        /*" B4292-INCLUI-V0EMISDIARIA-SECTION */
        private void B4292_INCLUI_V0EMISDIARIA_SECTION()
        {
            /*" -7424- MOVE 'B4292' TO WNR-EXEC-SQL. */
            _.Move("B4292", WABEND.WNR_EXEC_SQL);

            /*" -7425- MOVE '0' TO V0EDIA-SITUACAO. */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -7426- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -7427- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -7428- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -7429- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -7430- MOVE APOL-ORGAO TO V0EDIA-ORGAO. */
            _.Move(APOL_ORGAO, V0EDIA_ORGAO);

            /*" -7431- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -7432- MOVE ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(ENDO_FONTE, V0EDIA_FONTE);

            /*" -7433- MOVE ZEROS TO V0EDIA-CONGENER. */
            _.Move(0, V0EDIA_CONGENER);

            /*" -7434- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -7436- MOVE HIST-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(HIST_COD_EMPRESA, V0EDIA_COD_EMP);

            /*" -7451- PERFORM B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -7454- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -7455- DISPLAY 'B4292-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B4292-00 (REGISTRO DUPLICADO) ... ");

                /*" -7457- GO TO B4292-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4292_999_EXIT*/ //GOTO
                return;
            }


            /*" -7458- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7459- DISPLAY 'B4292-00 (PROBLEMAS NA INSERCAO) ------------' */
                _.Display($"B4292-00 (PROBLEMAS NA INSERCAO) ------------");

                /*" -7460- DISPLAY 'V0EDIA-CODRELAT = ' V0EDIA-CODRELAT */
                _.Display($"V0EDIA-CODRELAT = {V0EDIA_CODRELAT}");

                /*" -7461- DISPLAY 'V0EDIA-NUM-APOL = ' V0EDIA-NUM-APOL */
                _.Display($"V0EDIA-NUM-APOL = {V0EDIA_NUM_APOL}");

                /*" -7462- DISPLAY 'V0EDIA-NRENDOS  = ' V0EDIA-NRENDOS */
                _.Display($"V0EDIA-NRENDOS  = {V0EDIA_NRENDOS}");

                /*" -7463- DISPLAY 'V0EDIA-NRPARCEL = ' V0EDIA-NRPARCEL */
                _.Display($"V0EDIA-NRPARCEL = {V0EDIA_NRPARCEL}");

                /*" -7464- DISPLAY 'V0EDIA-DTMOVTO  = ' V0EDIA-DTMOVTO */
                _.Display($"V0EDIA-DTMOVTO  = {V0EDIA_DTMOVTO}");

                /*" -7465- DISPLAY 'V0EDIA-ORGAO    = ' V0EDIA-ORGAO */
                _.Display($"V0EDIA-ORGAO    = {V0EDIA_ORGAO}");

                /*" -7466- DISPLAY 'V0EDIA-RAMO     = ' V0EDIA-RAMO */
                _.Display($"V0EDIA-RAMO     = {V0EDIA_RAMO}");

                /*" -7467- DISPLAY 'V0EDIA-FONTE    = ' V0EDIA-FONTE */
                _.Display($"V0EDIA-FONTE    = {V0EDIA_FONTE}");

                /*" -7468- DISPLAY 'V0EDIA-CONGENER = ' V0EDIA-CONGENER */
                _.Display($"V0EDIA-CONGENER = {V0EDIA_CONGENER}");

                /*" -7469- DISPLAY 'V0EDIA-CODCORR  = ' V0EDIA-CODCORR */
                _.Display($"V0EDIA-CODCORR  = {V0EDIA_CODCORR}");

                /*" -7470- DISPLAY 'V0EDIA-SITUACAO = ' V0EDIA-SITUACAO */
                _.Display($"V0EDIA-SITUACAO = {V0EDIA_SITUACAO}");

                /*" -7471- DISPLAY 'V0EDIA-COD-EMP  = ' V0EDIA-COD-EMP */
                _.Display($"V0EDIA-COD-EMP  = {V0EDIA_COD_EMP}");

                /*" -7472- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -7474- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7474- ADD 1 TO AC-I-V0EMISDIARIA. */
            AC_I_V0EMISDIARIA.Value = AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" B4292-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -7451- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

            var b4292_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1 = new B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1()
            {
                V0EDIA_CODRELAT = V0EDIA_CODRELAT.ToString(),
                V0EDIA_NUM_APOL = V0EDIA_NUM_APOL.ToString(),
                V0EDIA_NRENDOS = V0EDIA_NRENDOS.ToString(),
                V0EDIA_NRPARCEL = V0EDIA_NRPARCEL.ToString(),
                V0EDIA_DTMOVTO = V0EDIA_DTMOVTO.ToString(),
                V0EDIA_ORGAO = V0EDIA_ORGAO.ToString(),
                V0EDIA_RAMO = V0EDIA_RAMO.ToString(),
                V0EDIA_FONTE = V0EDIA_FONTE.ToString(),
                V0EDIA_CONGENER = V0EDIA_CONGENER.ToString(),
                V0EDIA_CODCORR = V0EDIA_CODCORR.ToString(),
                V0EDIA_SITUACAO = V0EDIA_SITUACAO.ToString(),
                V0EDIA_COD_EMP = V0EDIA_COD_EMP.ToString(),
            };

            B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(b4292_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4292_999_EXIT*/

        [StopWatch]
        /*" B4295-00-UPDATE-DATAPROP-SECTION */
        private void B4295_00_UPDATE_DATAPROP_SECTION()
        {
            /*" -7485- PERFORM B4295_00_UPDATE_DATAPROP_DB_UPDATE_1 */

            B4295_00_UPDATE_DATAPROP_DB_UPDATE_1();

            /*" -7488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7492- DISPLAY 'B4295-00  ERRO UPDATE V0ENDOSSO' ' APOL=' ENDO-NUM-APOLICE ' ENDO=' ENDO-NRENDOS ' DATA=' ENDO-DATPRO */

                $"B4295-00  ERRO UPDATE V0ENDOSSO APOL={ENDO_NUM_APOLICE} ENDO={ENDO_NRENDOS} DATA={ENDO_DATPRO}"
                .Display();

                /*" -7493- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7493- END-IF. */
            }


        }

        [StopWatch]
        /*" B4295-00-UPDATE-DATAPROP-DB-UPDATE-1 */
        public void B4295_00_UPDATE_DATAPROP_DB_UPDATE_1()
        {
            /*" -7485- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET DATPRO = :ENDO-DATPRO WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

            var b4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1 = new B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1()
            {
                ENDO_DATPRO = ENDO_DATPRO.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1.Execute(b4295_00_UPDATE_DATAPROP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4295_999_EXIT*/

        [StopWatch]
        /*" R0320-00-SELECT-V0CEDENTE-SECTION */
        private void R0320_00_SELECT_V0CEDENTE_SECTION()
        {
            /*" -7510- MOVE 'R0320' TO WNR-EXEC-SQL. */
            _.Move("R0320", WABEND.WNR_EXEC_SQL);

            /*" -7528- PERFORM R0320_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0320_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -7531- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7532- MOVE ZEROS TO CEDENTE-COD-CEDENTE */
                _.Move(0, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -7533- ELSE */
            }
            else
            {


                /*" -7534- IF CEDENTE-OPERACAO-CONTA NOT EQUAL 870 */

                if (CEDENTE.DCLCEDENTE.CEDENTE_OPERACAO_CONTA != 870)
                {

                    /*" -7537- MOVE ZEROS TO CEDENTE-COD-CEDENTE. */
                    _.Move(0, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);
                }

            }


            /*" -7538- IF CEDENTE-COD-CEDENTE EQUAL ZEROS */

            if (CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE == 00)
            {

                /*" -7539- DISPLAY 'CEDENTE DEMAIS PARCELAS NAO CADASTRADO ' */
                _.Display($"CEDENTE DEMAIS PARCELAS NAO CADASTRADO ");

                /*" -7541- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7543- MOVE CEDENTE-NUM-TITULO TO WSHOST-NRTIT13. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WSHOST_NRTIT13);

            /*" -7544- DISPLAY 'LEITURA CEDENTE: ' CEDENTE-COD-CEDENTE ' TITULO ' CEDENTE-NUM-TITULO. */

            $"LEITURA CEDENTE: {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE} TITULO {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}"
            .Display();

        }

        [StopWatch]
        /*" R0320-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0320_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -7528- EXEC SQL SELECT COD_CEDENTE ,OPERACAO_CONTA ,NUM_TITULO INTO :CEDENTE-COD-CEDENTE ,:CEDENTE-OPERACAO-CONTA ,:CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = :CEDENTE-COD-CEDENTE WITH UR END-EXEC. */

            var r0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1 = new R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1()
            {
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            var executed_1 = R0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1.Execute(r0320_00_SELECT_V0CEDENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_COD_CEDENTE, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);
                _.Move(executed_1.CEDENTE_OPERACAO_CONTA, CEDENTE.DCLCEDENTE.CEDENTE_OPERACAO_CONTA);
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PARCELA-AUTO-FACIL-SECTION */
        private void R1100_00_PARCELA_AUTO_FACIL_SECTION()
        {
            /*" -7554- MOVE ENDO-CODPRODU TO AU080-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO);

            /*" -7556- MOVE AUTA-TIPO-COBRANCA TO AU080-IND-FORMA-PGTO */
            _.Move(AUTA_TIPO_COBRANCA, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO);

            /*" -7557- IF ENDO-QTPARCEL EQUAL ZEROS */

            if (ENDO_QTPARCEL == 00)
            {

                /*" -7558- MOVE 1 TO AU080-QTD-PARCELA */
                _.Move(1, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA);

                /*" -7559- ELSE */
            }
            else
            {


                /*" -7561- MOVE ENDO-QTPARCEL TO AU080-QTD-PARCELA. */
                _.Move(ENDO_QTPARCEL, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA);
            }


            /*" -7563- MOVE ENDO-DTINIVIG TO AU080-DTA-INI-VIGENCIA */
            _.Move(ENDO_DTINIVIG, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA);

            /*" -7564- PERFORM R1110-00-RECUPERA-AU080 */

            R1110_00_RECUPERA_AU080_SECTION();

            /*" -7566- MOVE AU080-COD-PRODUTO TO AU077-COD-PRODUTO */
            _.Move(AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO, AU077.DCLAU_PROD_COBERTURA.AU077_COD_PRODUTO);

            /*" -7569- MOVE AU080-DTA-INI-VIGENCIA TO AU077-DTA-INI-VIGENCIA */
            _.Move(AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA, AU077.DCLAU_PROD_COBERTURA.AU077_DTA_INI_VIGENCIA);

            /*" -7570- PERFORM R1120-00-RECUPERA-AU077 */

            R1120_00_RECUPERA_AU077_SECTION();

            /*" -7572- MOVE AU077-VLR-PREMIO-TOTAL TO VL-PREMIO-BASE */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_TOTAL, EM0901W099.VL_PREMIO_BASE);

            /*" -7575- MOVE AU077-VLR-PREMIO-LIQUIDO TO VL-TARIFARIO-IX. */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_LIQUIDO, EM0901W099.VL_TARIFARIO_IX);

            /*" -7581- COMPUTE WS-PCT-IOF = AU077-VLR-IOF / (AU077-VLR-PREMIO-LIQUIDO + AU077-VLR-CUSTO) + 0,000005. */
            WS_PCT_IOF.Value = AU077.DCLAU_PROD_COBERTURA.AU077_VLR_IOF / (AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_LIQUIDO + AU077.DCLAU_PROD_COBERTURA.AU077_VLR_CUSTO) + 0.000005;

            /*" -7581- MOVE WS-PCT-IOF TO VL-IOF-IX. */
            _.Move(WS_PCT_IOF, EM0901W099.VL_IOF_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-RECUPERA-AU080-SECTION */
        private void R1110_00_RECUPERA_AU080_SECTION()
        {
            /*" -7594- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", WABEND.WNR_EXEC_SQL);

            /*" -7606- PERFORM R1110_00_RECUPERA_AU080_DB_SELECT_1 */

            R1110_00_RECUPERA_AU080_DB_SELECT_1();

            /*" -7609- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7614- DISPLAY 'R1110-00 (PROBLEMAS SELECT AU_PARAM_PLANO)' ' ' AU080-COD-PRODUTO ' ' AU080-IND-FORMA-PGTO ' ' AU080-QTD-PARCELA ' ' AU080-DTA-INI-VIGENCIA */

                $"R1110-00 (PROBLEMAS SELECT AU_PARAM_PLANO) {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO} {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO} {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA} {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA}"
                .Display();

                /*" -7614- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1110-00-RECUPERA-AU080-DB-SELECT-1 */
        public void R1110_00_RECUPERA_AU080_DB_SELECT_1()
        {
            /*" -7606- EXEC SQL SELECT PCT_TOTAL_ENCARGO INTO :AU080-PCT-TOTAL-ENCARGO FROM SEGUROS.AU_PARAM_PLANO_PRDTO WHERE COD_PRODUTO = :AU080-COD-PRODUTO AND IND_FORMA_PGTO = :AU080-IND-FORMA-PGTO AND QTD_PARCELA = :AU080-QTD-PARCELA AND DTA_INI_VIGENCIA <= :AU080-DTA-INI-VIGENCIA AND DTA_FIM_VIGENCIA >= :AU080-DTA-INI-VIGENCIA WITH UR END-EXEC. */

            var r1110_00_RECUPERA_AU080_DB_SELECT_1_Query1 = new R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1()
            {
                AU080_DTA_INI_VIGENCIA = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA.ToString(),
                AU080_IND_FORMA_PGTO = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO.ToString(),
                AU080_COD_PRODUTO = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO.ToString(),
                AU080_QTD_PARCELA = AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA.ToString(),
            };

            var executed_1 = R1110_00_RECUPERA_AU080_DB_SELECT_1_Query1.Execute(r1110_00_RECUPERA_AU080_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU080_PCT_TOTAL_ENCARGO, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_PCT_TOTAL_ENCARGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-RECUPERA-AU077-SECTION */
        private void R1120_00_RECUPERA_AU077_SECTION()
        {
            /*" -7627- MOVE 'R1120' TO WNR-EXEC-SQL. */
            _.Move("R1120", WABEND.WNR_EXEC_SQL);

            /*" -7643- PERFORM R1120_00_RECUPERA_AU077_DB_SELECT_1 */

            R1120_00_RECUPERA_AU077_DB_SELECT_1();

            /*" -7646- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7649- DISPLAY 'R1110-00 (PROBLEMAS SELECT AU_PROD_COBERTURA)' ' ' AU077-COD-PRODUTO ' ' AU077-DTA-INI-VIGENCIA */

                $"R1110-00 (PROBLEMAS SELECT AU_PROD_COBERTURA) {AU077.DCLAU_PROD_COBERTURA.AU077_COD_PRODUTO} {AU077.DCLAU_PROD_COBERTURA.AU077_DTA_INI_VIGENCIA}"
                .Display();

                /*" -7649- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-RECUPERA-AU077-DB-SELECT-1 */
        public void R1120_00_RECUPERA_AU077_DB_SELECT_1()
        {
            /*" -7643- EXEC SQL SELECT VALUE(SUM(VLR_PREMIO_LIQUIDO), 0), VALUE(SUM(VLR_CUSTO), 0), VALUE(SUM(VLR_IOF), 0), VALUE(SUM(VLR_PREMIO_TOTAL), 0) INTO :AU077-VLR-PREMIO-LIQUIDO, :AU077-VLR-CUSTO , :AU077-VLR-IOF , :AU077-VLR-PREMIO-TOTAL FROM SEGUROS.AU_PROD_COBERTURA WHERE COD_PRODUTO = :AU077-COD-PRODUTO AND DTA_INI_VIGENCIA <= :AU077-DTA-INI-VIGENCIA AND DTA_FIM_VIGENCIA >= :AU077-DTA-INI-VIGENCIA END-EXEC. */

            var r1120_00_RECUPERA_AU077_DB_SELECT_1_Query1 = new R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1()
            {
                AU077_DTA_INI_VIGENCIA = AU077.DCLAU_PROD_COBERTURA.AU077_DTA_INI_VIGENCIA.ToString(),
                AU077_COD_PRODUTO = AU077.DCLAU_PROD_COBERTURA.AU077_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1120_00_RECUPERA_AU077_DB_SELECT_1_Query1.Execute(r1120_00_RECUPERA_AU077_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU077_VLR_PREMIO_LIQUIDO, AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_LIQUIDO);
                _.Move(executed_1.AU077_VLR_CUSTO, AU077.DCLAU_PROD_COBERTURA.AU077_VLR_CUSTO);
                _.Move(executed_1.AU077_VLR_IOF, AU077.DCLAU_PROD_COBERTURA.AU077_VLR_IOF);
                _.Move(executed_1.AU077_VLR_PREMIO_TOTAL, AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R2060-00-ALTERA-V0CEDENTE-SECTION */
        private void R2060_00_ALTERA_V0CEDENTE_SECTION()
        {
            /*" -7660- MOVE 'R2060' TO WNR-EXEC-SQL. */
            _.Move("R2060", WABEND.WNR_EXEC_SQL);

            /*" -7663- DISPLAY 'ALTERANDO .CEDENTE: ' CEDENTE-COD-CEDENTE ' TITULO ' CEDENTE-NUM-TITULO */

            $"ALTERANDO .CEDENTE: {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE} TITULO {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}"
            .Display();

            /*" -7667- PERFORM R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1 */

            R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1();

            /*" -7670- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7671- DISPLAY 'R2060-00 - PROBLEMAS NO UPDATE(CEDENTE) ' */
                _.Display($"R2060-00 - PROBLEMAS NO UPDATE(CEDENTE) ");

                /*" -7671- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2060-00-ALTERA-V0CEDENTE-DB-UPDATE-1 */
        public void R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -7667- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO WHERE COD_CEDENTE = :CEDENTE-COD-CEDENTE END-EXEC. */

            var r2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1 = new R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1()
            {
                CEDENTE_NUM_TITULO = CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO.ToString(),
                CEDENTE_COD_CEDENTE = CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE.ToString(),
            };

            R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1.Execute(r2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_99_SAIDA*/

        [StopWatch]
        /*" R3000-LE-CUSTO-APOLICE-SECTION */
        private void R3000_LE_CUSTO_APOLICE_SECTION()
        {
            /*" -7682- MOVE 'R3000' TO WNR-EXEC-SQL. */
            _.Move("R3000", WABEND.WNR_EXEC_SQL);

            /*" -7693- PERFORM R3000_LE_CUSTO_APOLICE_DB_SELECT_1 */

            R3000_LE_CUSTO_APOLICE_DB_SELECT_1();

            /*" -7696- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -7697- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7698- MOVE ZEROS TO PARC-OTNCUSTO */
                    _.Move(0, PARC_OTNCUSTO);

                    /*" -7699- ELSE */
                }
                else
                {


                    /*" -7701- DISPLAY 'R3000-PROBLEMAS NO SELECT CUSTO EMISSAO' ENDO-NUM-APOLICE */
                    _.Display($"R3000-PROBLEMAS NO SELECT CUSTO EMISSAO{ENDO_NUM_APOLICE}");

                    /*" -7702- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3000-LE-CUSTO-APOLICE-DB-SELECT-1 */
        public void R3000_LE_CUSTO_APOLICE_DB_SELECT_1()
        {
            /*" -7693- EXEC SQL SELECT SUM(OTNCUSTO) INTO :PARC-OTNCUSTO FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = 0 WITH UR END-EXEC. */

            var r3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1 = new R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
            };

            var executed_1 = R3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1.Execute(r3000_LE_CUSTO_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARC_OTNCUSTO, PARC_OTNCUSTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_999_EXIT*/

        [StopWatch]
        /*" R5000-00-LE-PCIOCC-SECTION */
        private void R5000_00_LE_PCIOCC_SECTION()
        {
            /*" -7712- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", WABEND.WNR_EXEC_SQL);

            /*" -7720- PERFORM R5000_00_LE_PCIOCC_DB_SELECT_1 */

            R5000_00_LE_PCIOCC_DB_SELECT_1();

            /*" -7723- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -7724- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -7725- MOVE ZEROS TO V1RAMO-PCIOF */
                    _.Move(0, V1RAMO_PCIOF);

                    /*" -7726- ELSE */
                }
                else
                {


                    /*" -7728- DISPLAY 'R5000-PROBLEMAS NO SELECT PERC DE IOF' ENDO-NUM-APOLICE */
                    _.Display($"R5000-PROBLEMAS NO SELECT PERC DE IOF{ENDO_NUM_APOLICE}");

                    /*" -7728- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5000-00-LE-PCIOCC-DB-SELECT-1 */
        public void R5000_00_LE_PCIOCC_DB_SELECT_1()
        {
            /*" -7720- EXEC SQL SELECT PCIOF INTO :V1RAMO-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :ENDO-RAMO AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG WITH UR END-EXEC. */

            var r5000_00_LE_PCIOCC_DB_SELECT_1_Query1 = new R5000_00_LE_PCIOCC_DB_SELECT_1_Query1()
            {
                ENDO_DTINIVIG = ENDO_DTINIVIG.ToString(),
                ENDO_RAMO = ENDO_RAMO.ToString(),
            };

            var executed_1 = R5000_00_LE_PCIOCC_DB_SELECT_1_Query1.Execute(r5000_00_LE_PCIOCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RAMO_PCIOF, V1RAMO_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6100-NOVO-TITULO-CEF-SECTION */
        private void R6100_NOVO_TITULO_CEF_SECTION()
        {
            /*" -7739- MOVE 'R6100' TO WNR-EXEC-SQL. */
            _.Move("R6100", WABEND.WNR_EXEC_SQL);

            /*" -7740- IF W-PARCEL LESS 02 */

            if (W_PARCEL < 02)
            {

                /*" -7741- IF ENDO-NRRCAP EQUAL ZEROS */

                if (ENDO_NRRCAP == 00)
                {

                    /*" -7743- IF PRCB-TIPO-COBRANCA EQUAL ' ' OR PRCB-TIPO-COBRANCA EQUAL '0' */

                    if (PRCB_TIPO_COBRANCA == " " || PRCB_TIPO_COBRANCA == "0")
                    {

                        /*" -7744- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                        if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                        {

                            /*" -7745- ADD 1 TO WSHOST-TIT-FACIL */
                            WSHOST_TIT_FACIL.Value = WSHOST_TIT_FACIL + 1;

                            /*" -7746- MOVE WSHOST-TIT-FACIL TO W-NUMR-TITULO */
                            _.Move(WSHOST_TIT_FACIL, W_NUMR_TITULO);

                            /*" -7747- ELSE */
                        }
                        else
                        {


                            /*" -7748- ADD 1 TO WSHOST-NRTIT13 */
                            WSHOST_NRTIT13.Value = WSHOST_NRTIT13 + 1;

                            /*" -7749- MOVE WSHOST-NRTIT13 TO W-NUMR-TITULO */
                            _.Move(WSHOST_NRTIT13, W_NUMR_TITULO);

                            /*" -7750- END-IF */
                        }


                        /*" -7752- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -7753- ELSE */
                    }

                }
                else
                {


                    /*" -7754- PERFORM A6200-000-LE-RCAP */

                    A6200_000_LE_RCAP_SECTION();

                    /*" -7755- MOVE V0RCAP-NRTIT TO W-NUMR-TITULO */
                    _.Move(V0RCAP_NRTIT, W_NUMR_TITULO);

                    /*" -7756- ELSE */
                }

            }
            else
            {


                /*" -7757- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                {

                    /*" -7758- IF PRCB-TIPO-COBRANCA EQUAL ' ' OR '0' */

                    if (PRCB_TIPO_COBRANCA.In(" ", "0"))
                    {

                        /*" -7759- ADD 1 TO WSHOST-TIT-FACIL */
                        WSHOST_TIT_FACIL.Value = WSHOST_TIT_FACIL + 1;

                        /*" -7760- MOVE WSHOST-TIT-FACIL TO W-NUMR-TITULO */
                        _.Move(WSHOST_TIT_FACIL, W_NUMR_TITULO);

                        /*" -7761- END-IF */
                    }


                    /*" -7762- ELSE */
                }
                else
                {


                    /*" -7763- ADD 1 TO WSHOST-NRTIT13 */
                    WSHOST_NRTIT13.Value = WSHOST_NRTIT13 + 1;

                    /*" -7763- MOVE WSHOST-NRTIT13 TO W-NUMR-TITULO. */
                    _.Move(WSHOST_NRTIT13, W_NUMR_TITULO);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-GRAVA-PARC-COMPL-SECTION */
        private void R7000_00_GRAVA_PARC_COMPL_SECTION()
        {
            /*" -7777- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", WABEND.WNR_EXEC_SQL);

            /*" -7778- MOVE PARC-NUM-APOLICE TO AU071-NUM-APOLICE */
            _.Move(PARC_NUM_APOLICE, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE);

            /*" -7779- MOVE PARC-NRENDOS TO AU071-NUM-ENDOSSO */
            _.Move(PARC_NRENDOS, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO);

            /*" -7781- MOVE PARC-NRTIT TO AU071-NUM-RECIBO-CONV */
            _.Move(PARC_NRTIT, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_RECIBO_CONV);

            /*" -7784- MOVE PARC-NRPARCEL TO AU071-NUM-PARCELA */
            _.Move(PARC_NRPARCEL, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA);

            /*" -7785- MOVE 1 TO AU071-NUM-VENCTO */
            _.Move(1, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

            /*" -7786- MOVE HIST-DTVENCTO TO AU071-DTA-VENCTO */
            _.Move(HIST_DTVENCTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);

            /*" -7788- MOVE PARC-OTNPRLIQ TO AU071-VLR-PREMIO-LIQUIDO */
            _.Move(PARC_OTNPRLIQ, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO);

            /*" -7789- MOVE ZEROS TO AU071-VLR-JUROS */
            _.Move(0, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS);

            /*" -7790- MOVE ZEROS TO AU071-VLR-MULTA */
            _.Move(0, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);

            /*" -7791- MOVE PARC-OTNADFRA TO AU071-VLR-ADIC-FRAC */
            _.Move(PARC_OTNADFRA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC);

            /*" -7792- MOVE PARC-OTNCUSTO TO AU071-VLR-CUSTO */
            _.Move(PARC_OTNCUSTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO);

            /*" -7793- MOVE PARC-OTNIOF TO AU071-VLR-IOF */
            _.Move(PARC_OTNIOF, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF);

            /*" -7795- MOVE PARC-OTNTOTAL TO AU071-VLR-PREMIO-TOTAL */
            _.Move(PARC_OTNTOTAL, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL);

            /*" -7798- PERFORM R7100-00-INCLUI-PARC-COMPL. */

            R7100_00_INCLUI_PARC_COMPL_SECTION();

            /*" -7799- IF PRCB-TIPO-COBRANCA NOT EQUAL '0' AND ' ' */

            if (!PRCB_TIPO_COBRANCA.In("0", " "))
            {

                /*" -7801- GO TO R7000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7802- MOVE 2 TO AU071-NUM-VENCTO */
            _.Move(2, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

            /*" -7803- MOVE HIST-DTVENCTO TO W-DATA-DB2 */
            _.Move(HIST_DTVENCTO, W_DATA_DB2);

            /*" -7804- MOVE W-DIA-DB2 TO W-DD */
            _.Move(W_DATA_DB2.W_DIA_DB2, W_DATA.W_DD);

            /*" -7805- MOVE W-MES-DB2 TO W-MM */
            _.Move(W_DATA_DB2.W_MES_DB2, W_DATA.W_MM);

            /*" -7806- MOVE W-ANO-DB2 TO W-AA */
            _.Move(W_DATA_DB2.W_ANO_DB2, W_DATA.W_AA);

            /*" -7807- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -7808- MOVE 10 TO PROSOM-QTDIA */
            _.Move(10, PROSOMW099.PROSOM_QTDIA);

            /*" -7810- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -7812- CALL 'PROSOCU1' USING PROSOMW099 */
            _.Call("PROSOCU1", PROSOMW099);

            /*" -7813- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -7814- MOVE W-DD TO W-DIA-DB2 */
            _.Move(W_DATA.W_DD, W_DATA_DB2.W_DIA_DB2);

            /*" -7815- MOVE W-MM TO W-MES-DB2 */
            _.Move(W_DATA.W_MM, W_DATA_DB2.W_MES_DB2);

            /*" -7816- MOVE W-AA TO W-ANO-DB2 */
            _.Move(W_DATA.W_AA, W_DATA_DB2.W_ANO_DB2);

            /*" -7817- MOVE W-DATA-DB2 TO AU071-DTA-VENCTO */
            _.Move(W_DATA_DB2, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);

            /*" -7820- MOVE PARC-OTNPRLIQ TO AU071-VLR-PREMIO-LIQUIDO */
            _.Move(PARC_OTNPRLIQ, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO);

            /*" -7822- PERFORM R7200-00-CALC-VLR-COBRAR */

            R7200_00_CALC_VLR_COBRAR_SECTION();

            /*" -7823- MOVE WS-VLR-JUROS TO AU071-VLR-JUROS */
            _.Move(WS_VLR_JUROS, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS);

            /*" -7824- MOVE WS-VLR-MULTA TO AU071-VLR-MULTA */
            _.Move(WS_VLR_MULTA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);

            /*" -7825- MOVE PARC-OTNADFRA TO AU071-VLR-ADIC-FRAC */
            _.Move(PARC_OTNADFRA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC);

            /*" -7826- MOVE PARC-OTNCUSTO TO AU071-VLR-CUSTO */
            _.Move(PARC_OTNCUSTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO);

            /*" -7828- MOVE PARC-OTNIOF TO AU071-VLR-IOF */
            _.Move(PARC_OTNIOF, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF);

            /*" -7829- MOVE WS-VLR-COBRAR TO AU071-VLR-PREMIO-TOTAL */
            _.Move(WS_VLR_COBRAR, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL);

            /*" -7829- PERFORM R7100-00-INCLUI-PARC-COMPL. */

            R7100_00_INCLUI_PARC_COMPL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-INCLUI-PARC-COMPL-SECTION */
        private void R7100_00_INCLUI_PARC_COMPL_SECTION()
        {
            /*" -7843- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", WABEND.WNR_EXEC_SQL);

            /*" -7860- PERFORM R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1 */

            R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1();

            /*" -7863- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7868- DISPLAY 'R7100-00 (PROBLEMAS INSERT PARCELA_AUTO_COMPL)' ' ' AU071-NUM-APOLICE ' ' AU071-NUM-ENDOSSO ' ' AU071-NUM-PARCELA ' ' AU071-NUM-VENCTO */

                $"R7100-00 (PROBLEMAS INSERT PARCELA_AUTO_COMPL) {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO}"
                .Display();

                /*" -7870- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7870- ADD +1 TO AC-I-AU071. */
            AC_I_AU071.Value = AC_I_AU071 + +1;

        }

        [StopWatch]
        /*" R7100-00-INCLUI-PARC-COMPL-DB-INSERT-1 */
        public void R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1()
        {
            /*" -7860- EXEC SQL INSERT INTO SEGUROS.PARCELA_AUTO_COMPL VALUES (:AU071-NUM-APOLICE , :AU071-NUM-ENDOSSO , :AU071-NUM-PARCELA , :AU071-DTA-VENCTO , :AU071-NUM-VENCTO , :AU071-VLR-PREMIO-LIQUIDO , :AU071-VLR-JUROS , :AU071-VLR-ADIC-FRAC , :AU071-VLR-MULTA , :AU071-VLR-CUSTO , :AU071-VLR-IOF , :AU071-VLR-PREMIO-TOTAL , :AU071-NUM-RECIBO-CONV , 'EM0030B' , CURRENT TIMESTAMP) END-EXEC. */

            var r7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1 = new R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1()
            {
                AU071_NUM_APOLICE = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE.ToString(),
                AU071_NUM_ENDOSSO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO.ToString(),
                AU071_NUM_PARCELA = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA.ToString(),
                AU071_DTA_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO.ToString(),
                AU071_NUM_VENCTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO.ToString(),
                AU071_VLR_PREMIO_LIQUIDO = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO.ToString(),
                AU071_VLR_JUROS = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS.ToString(),
                AU071_VLR_ADIC_FRAC = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC.ToString(),
                AU071_VLR_MULTA = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA.ToString(),
                AU071_VLR_CUSTO = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO.ToString(),
                AU071_VLR_IOF = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF.ToString(),
                AU071_VLR_PREMIO_TOTAL = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL.ToString(),
                AU071_NUM_RECIBO_CONV = AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_RECIBO_CONV.ToString(),
            };

            R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1.Execute(r7100_00_INCLUI_PARC_COMPL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R7200-00-CALC-VLR-COBRAR-SECTION */
        private void R7200_00_CALC_VLR_COBRAR_SECTION()
        {
            /*" -7883- MOVE '7200' TO WNR-EXEC-SQL. */
            _.Move("7200", WABEND.WNR_EXEC_SQL);

            /*" -7884- MOVE AU071-DTA-VENCTO TO WHOST-DTCALEND1. */
            _.Move(AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO, WHOST_DTCALEND1);

            /*" -7886- MOVE WHOST-DTCURRENT TO WHOST-DTCALEND2. */
            _.Move(WHOST_DTCURRENT, WHOST_DTCALEND2);

            /*" -7888- PERFORM R7210-00-APURA-QTD-DIAS */

            R7210_00_APURA_QTD_DIAS_SECTION();

            /*" -7893- COMPUTE WS-PCT-JUROS = ((WHOST-QTDIAS * 0,03) / 100). */
            WS_PCT_JUROS.Value = ((WHOST_QTDIAS * 0.03) / 100f);

            /*" -7896- COMPUTE WS-VLR-JUROS = ((AU071-VLR-PREMIO-TOTAL * 7,5) / 100). */
            WS_VLR_JUROS.Value = ((AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL * 7.5) / 100f);

            /*" -7900- MOVE ZEROS TO WS-VLR-MULTA */
            _.Move(0, WS_VLR_MULTA);

            /*" -7904- COMPUTE WS-VLR-COBRAR = AU071-VLR-PREMIO-LIQUIDO + AU071-VLR-IOF + WS-VLR-JUROS + WS-VLR-MULTA. */
            WS_VLR_COBRAR.Value = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO + AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF + WS_VLR_JUROS + WS_VLR_MULTA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7210-00-APURA-QTD-DIAS-SECTION */
        private void R7210_00_APURA_QTD_DIAS_SECTION()
        {
            /*" -7915- MOVE 'R7210' TO WNR-EXEC-SQL. */
            _.Move("R7210", WABEND.WNR_EXEC_SQL);

            /*" -7926- PERFORM R7210_00_APURA_QTD_DIAS_DB_SELECT_1 */

            R7210_00_APURA_QTD_DIAS_DB_SELECT_1();

            /*" -7929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7936- DISPLAY 'R7210-00 (PROBLEMAS SELECT CALENDARIO)' ' ' AU071-NUM-APOLICE ' ' AU071-NUM-ENDOSSO ' ' AU071-NUM-PARCELA ' ' AU071-NUM-VENCTO ' ' WHOST-DTCALEND1 ' ' WHOST-DTCALEND2 */

                $"R7210-00 (PROBLEMAS SELECT CALENDARIO) {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO} {WHOST_DTCALEND1} {WHOST_DTCALEND2}"
                .Display();

                /*" -7936- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7210-00-APURA-QTD-DIAS-DB-SELECT-1 */
        public void R7210_00_APURA_QTD_DIAS_DB_SELECT_1()
        {
            /*" -7926- EXEC SQL SELECT COUNT(*) INTO :WHOST-QTDIAS FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :WHOST-DTCALEND1 AND DATA_CALENDARIO <= :WHOST-DTCALEND2 WITH UR END-EXEC. */

            var r7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1 = new R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1()
            {
                WHOST_DTCALEND1 = WHOST_DTCALEND1.ToString(),
                WHOST_DTCALEND2 = WHOST_DTCALEND2.ToString(),
            };

            var executed_1 = R7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1.Execute(r7210_00_APURA_QTD_DIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDIAS, WHOST_QTDIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7210_99_SAIDA*/

        [StopWatch]
        /*" R7220-00-CONSULTA-NN-SECTION */
        private void R7220_00_CONSULTA_NN_SECTION()
        {
            /*" -7946- MOVE 'R7220' TO WNR-EXEC-SQL */
            _.Move("R7220", WABEND.WNR_EXEC_SQL);

            /*" -7950- MOVE ZEROS TO APOLIAUT-CANAL-PROPOSTA APOLIAUT-NUM-PROPOSTA-CONV APOLIAUT-COD-FONTE */
            _.Move(0, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE);

            /*" -7962- PERFORM R7220_00_CONSULTA_NN_DB_SELECT_1 */

            R7220_00_CONSULTA_NN_DB_SELECT_1();

            /*" -7965- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -7966- DISPLAY 'R7220 (PROBLEMAS SELECT APOLICE_AUTO)' */
                _.Display($"R7220 (PROBLEMAS SELECT APOLICE_AUTO)");

                /*" -7967- DISPLAY 'APOLICE ' PARC-NUM-APOLICE */
                _.Display($"APOLICE {PARC_NUM_APOLICE}");

                /*" -7968- DISPLAY 'ENDOSSO ' PARC-NRENDOS */
                _.Display($"ENDOSSO {PARC_NRENDOS}");

                /*" -7969- DISPLAY 'PARCELA ' PARC-NRPARCEL */
                _.Display($"PARCELA {PARC_NRPARCEL}");

                /*" -7970- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7972- END-IF */
            }


            /*" -7974- INITIALIZE REGISTRO-LINKAGE-GE0350S */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -7975- MOVE 01 TO LK-GE350-COD-FUNCAO */
            _.Move(01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -7976- MOVE 'EM0030B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0030B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -7977- MOVE PARC-NUM-APOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(PARC_NUM_APOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -7978- MOVE PARC-NRENDOS TO LK-GE350-NUM-ENDOSSO */
            _.Move(PARC_NRENDOS, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -7979- MOVE PARC-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(PARC_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -7982- MOVE APOLIAUT-NUM-PROPOSTA-CONV TO LK-GE350-NUM-PROPOSTA */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -7984- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -7985- IF LK-GE350-COD-RETORNO NOT = '2' */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "2")
            {

                /*" -7986- DISPLAY 'ERRO NA EXECUCAO DO CALL GE0350S' */
                _.Display($"ERRO NA EXECUCAO DO CALL GE0350S");

                /*" -7987- DISPLAY 'SQLCODE: ' LK-GE350-SQLCODE */
                _.Display($"SQLCODE: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -7988- DISPLAY 'MSG ERRO: ' LK-GE350-MSG-RETORNO */
                _.Display($"MSG ERRO: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}");

                /*" -7989- DISPLAY '--------- DADOS DE SAIDA GE0350S ---------- ' */
                _.Display($"--------- DADOS DE SAIDA GE0350S ---------- ");

                /*" -7990- DISPLAY '=> COD-FUNCAO       ' LK-GE350-COD-FUNCAO */
                _.Display($"=> COD-FUNCAO       {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

                /*" -7991- DISPLAY '=> NUM-PROPOSTA     ' LK-GE350-NUM-PROPOSTA */
                _.Display($"=> NUM-PROPOSTA     {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -7992- DISPLAY '=> NUM-APOLICE      ' LK-GE350-NUM-APOLICE */
                _.Display($"=> NUM-APOLICE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -7993- DISPLAY '=> NUM-ENDOSSO      ' LK-GE350-NUM-ENDOSSO */
                _.Display($"=> NUM-ENDOSSO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -7994- DISPLAY '=> NUM-PARCELA      ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NUM-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -7995- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7997- END-IF */
            }


            /*" -7998- MOVE 07 TO LK-GE350-COD-FUNCAO */
            _.Move(07, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -8000- MOVE PARC-NUM-APOLICE TO LK-GE350-NUM-CONTA-CNTRO WS-NUM-IDLG-APOLICE */
            _.Move(PARC_NUM_APOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CONTA_CNTRO, WS_NUM_IDLG.WS_NUM_IDLG_APOLICE);

            /*" -8001- MOVE PARC-NRENDOS TO WS-NUM-IDLG-ENDOSSO */
            _.Move(PARC_NRENDOS, WS_NUM_IDLG.WS_NUM_IDLG_ENDOSSO);

            /*" -8002- MOVE PARC-NRPARCEL TO WS-NUM-IDLG-PARCELA */
            _.Move(PARC_NRPARCEL, WS_NUM_IDLG.WS_NUM_IDLG_PARCELA);

            /*" -8003- MOVE ENDO-CODPRODU TO LK-GE350-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -8004- MOVE ENDO-QTPARCEL TO LK-GE350-QTD-PARCELA */
            _.Move(ENDO_QTPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

            /*" -8005- MOVE ENDO-DTINIVIG TO LK-GE350-DTA-MOVIMENTO */
            _.Move(ENDO_DTINIVIG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -8006- MOVE APOL-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
            _.Move(APOL_COD_CLIENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -8007- MOVE HIST-VLPRMTOT TO LK-GE350-VLR-PREMIO-TOTAL */
            _.Move(HIST_VLPRMTOT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

            /*" -8008- MOVE HIST-VLIOCC TO LK-GE350-VLR-IOF */
            _.Move(HIST_VLIOCC, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

            /*" -8009- MOVE HIST-DTVENCTO TO LK-GE350-DTA-VENCIMENTO */
            _.Move(HIST_DTVENCTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -8011- MOVE WS-NUM-IDLG TO LK-GE350-NUM-IDLG */
            _.Move(WS_NUM_IDLG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

            /*" -8012- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -8013- MOVE 'SIAS' TO LK-GE350-COD-SISTEMA */
            _.Move("SIAS", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA);

            /*" -8014- MOVE 'SIAS_09518' TO LK-GE350-COD-EVENTO */
            _.Move("SIAS_09518", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_EVENTO);

            /*" -8015- MOVE APOLIAUT-CANAL-PROPOSTA TO LK-GE350-COD-CANAL */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CANAL);

            /*" -8016- MOVE 'R' TO LK-GE350-COD-TP-CONVENIO */
            _.Move("R", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO);

            /*" -8017- MOVE 'AU' TO LK-GE350-IDE-SISTEMA */
            _.Move("AU", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -8018- MOVE 'EM0030B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0030B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -8019- MOVE 'A' TO LK-GE350-COD-SITUACAO */
            _.Move("A", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -8021- MOVE APOLIAUT-COD-FONTE TO LK-GE350-COD-FONTE */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FONTE);

            /*" -8023- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -8025- IF LK-GE350-COD-RETORNO NOT = '0' */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
            {

                /*" -8026- DISPLAY 'R7220-00-NAO CONSEGUIU GERAR BOLETO' */
                _.Display($"R7220-00-NAO CONSEGUIU GERAR BOLETO");

                /*" -8027- DISPLAY '  APOLICE ' LK-GE350-NUM-APOLICE */
                _.Display($"  APOLICE {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -8028- DISPLAY '  ENDOSSO ' LK-GE350-NUM-ENDOSSO */
                _.Display($"  ENDOSSO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -8029- DISPLAY '  PARCELA ' LK-GE350-NUM-PARCELA */
                _.Display($"  PARCELA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -8030- DISPLAY '  PROPOST ' LK-GE350-NUM-PROPOSTA */
                _.Display($"  PROPOST {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -8032- DISPLAY '  IDLG    ' LK-GE350-NUM-IDLG */
                _.Display($"  IDLG    {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -8033- MOVE 02 TO LK-GE350-COD-FUNCAO */
                _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

                /*" -8035- MOVE 'P' TO LK-GE350-COD-SITUACAO */
                _.Move("P", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -8037- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
                _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

                /*" -8038- IF LK-GE350-COD-RETORNO NOT = '0' */

                if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
                {

                    /*" -8039- DISPLAY 'ERRO NA EXECUCAO DO CALL GE0350S' */
                    _.Display($"ERRO NA EXECUCAO DO CALL GE0350S");

                    /*" -8040- DISPLAY 'SQLCODE: ' LK-GE350-SQLCODE */
                    _.Display($"SQLCODE: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                    /*" -8041- DISPLAY 'MSG ERRO: ' LK-GE350-MSG-RETORNO */
                    _.Display($"MSG ERRO: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}");

                    /*" -8042- DISPLAY '--------- DADOS DE SAIDA GE0350S ---------- ' */
                    _.Display($"--------- DADOS DE SAIDA GE0350S ---------- ");

                    /*" -8043- DISPLAY '=> COD-FUNCAO       ' LK-GE350-COD-FUNCAO */
                    _.Display($"=> COD-FUNCAO       {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

                    /*" -8044- DISPLAY '=> COD-CLIENTE      ' LK-GE350-COD-CLIENTE */
                    _.Display($"=> COD-CLIENTE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

                    /*" -8045- DISPLAY '=> NUM-PROPOSTA     ' LK-GE350-NUM-PROPOSTA */
                    _.Display($"=> NUM-PROPOSTA     {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                    /*" -8046- DISPLAY '=> NUM-APOLICE      ' LK-GE350-NUM-APOLICE */
                    _.Display($"=> NUM-APOLICE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                    /*" -8047- DISPLAY '=> NUM-ENDOSSO      ' LK-GE350-NUM-ENDOSSO */
                    _.Display($"=> NUM-ENDOSSO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                    /*" -8048- DISPLAY '=> NUM-PARCELA      ' LK-GE350-NUM-PARCELA */
                    _.Display($"=> NUM-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                    /*" -8049- DISPLAY '=> NUM-IDLG         ' LK-GE350-NUM-IDLG */
                    _.Display($"=> NUM-IDLG         {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                    /*" -8050- DISPLAY '=> COD-PRODUTO      ' LK-GE350-COD-PRODUTO */
                    _.Display($"=> COD-PRODUTO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}");

                    /*" -8051- DISPLAY '=> DTA-MOVIMENTO    ' LK-GE350-DTA-MOVIMENTO */
                    _.Display($"=> DTA-MOVIMENTO    {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

                    /*" -8052- DISPLAY '=> DTA-VENCIMENTO   ' LK-GE350-DTA-VENCIMENTO */
                    _.Display($"=> DTA-VENCIMENTO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

                    /*" -8054- DISPLAY '=> VLR-PREMIO-TOTAL ' LK-GE350-VLR-PREMIO-TOTAL */
                    _.Display($"=> VLR-PREMIO-TOTAL {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}");

                    /*" -8055- DISPLAY '=> QTD-PARCELA      ' LK-GE350-QTD-PARCELA */
                    _.Display($"=> QTD-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}");

                    /*" -8057- DISPLAY '=> QTD-DIAS-CUSTODI ' LK-GE350-QTD-DIAS-CUSTODIA */
                    _.Display($"=> QTD-DIAS-CUSTODI {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

                    /*" -8059- DISPLAY '=> NOSSO-NUMERO-SAP ' LK-GE350-NOSSO-NUMERO-SAP */
                    _.Display($"=> NOSSO-NUMERO-SAP {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                    /*" -8060- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -8061- END-IF */
                }


                /*" -8063- END-IF */
            }


            /*" -8065- IF LK-GE350-COD-FUNCAO = 07 AND LK-GE350-NOSSO-NUMERO-SAP = 0 */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO == 07 && LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP == 0)
            {

                /*" -8066- DISPLAY 'NOSSO-NUMERO-SAP ESTA ZERADO' */
                _.Display($"NOSSO-NUMERO-SAP ESTA ZERADO");

                /*" -8067- DISPLAY '=> NUM-APOLICE      ' LK-GE350-NUM-APOLICE */
                _.Display($"=> NUM-APOLICE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -8068- DISPLAY '=> NUM-ENDOSSO      ' LK-GE350-NUM-ENDOSSO */
                _.Display($"=> NUM-ENDOSSO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -8069- DISPLAY '=> NUM-PARCELA      ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NUM-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -8070- DISPLAY '=> NUM-IDLG         ' LK-GE350-NUM-IDLG */
                _.Display($"=> NUM-IDLG         {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -8071- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8073- END-IF */
            }


            /*" -8074- IF LK-GE350-COD-FUNCAO = 02 */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO == 02)
            {

                /*" -8075- GO TO R7220-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7220_99_SAIDA*/ //GOTO
                return;

                /*" -8077- END-IF */
            }


            /*" -8078- MOVE LK-GE350-NOSSO-NUMERO-SAP TO WS-NOSSO-NUMERO-SAP */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, WS_NOSSO_NUMERO_SAP);

            /*" -8080- MOVE WS-NOSSO-NR-TITULO TO PARC-NRTIT */
            _.Move(FILLER_29.WS_NOSSO_NR_TITULO, PARC_NRTIT);

            /*" -8086- PERFORM R7220_00_CONSULTA_NN_DB_UPDATE_1 */

            R7220_00_CONSULTA_NN_DB_UPDATE_1();

            /*" -8089- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -8090- DISPLAY 'R7220 (PROBLEMAS ATUALIZACAO PARCELAS)' */
                _.Display($"R7220 (PROBLEMAS ATUALIZACAO PARCELAS)");

                /*" -8091- DISPLAY 'APOLICE ' PARC-NUM-APOLICE */
                _.Display($"APOLICE {PARC_NUM_APOLICE}");

                /*" -8092- DISPLAY 'ENDOSSO ' PARC-NRENDOS */
                _.Display($"ENDOSSO {PARC_NRENDOS}");

                /*" -8093- DISPLAY 'PARCELA ' PARC-NRPARCEL */
                _.Display($"PARCELA {PARC_NRPARCEL}");

                /*" -8094- DISPLAY 'TITULO  ' PARC-NRTIT */
                _.Display($"TITULO  {PARC_NRTIT}");

                /*" -8095- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8095- END-IF. */
            }


        }

        [StopWatch]
        /*" R7220-00-CONSULTA-NN-DB-SELECT-1 */
        public void R7220_00_CONSULTA_NN_DB_SELECT_1()
        {
            /*" -7962- EXEC SQL SELECT CANAL_PROPOSTA ,NUM_PROPOSTA_CONV ,COD_FONTE INTO :APOLIAUT-CANAL-PROPOSTA ,:APOLIAUT-NUM-PROPOSTA-CONV ,:APOLIAUT-COD-FONTE FROM SEGUROS.APOLICE_AUTO WHERE NUM_APOLICE = :PARC-NUM-APOLICE AND NUM_ENDOSSO = :PARC-NRENDOS AND NUM_ITEM = 101 WITH UR END-EXEC */

            var r7220_00_CONSULTA_NN_DB_SELECT_1_Query1 = new R7220_00_CONSULTA_NN_DB_SELECT_1_Query1()
            {
                PARC_NUM_APOLICE = PARC_NUM_APOLICE.ToString(),
                PARC_NRENDOS = PARC_NRENDOS.ToString(),
            };

            var executed_1 = R7220_00_CONSULTA_NN_DB_SELECT_1_Query1.Execute(r7220_00_CONSULTA_NN_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLIAUT_CANAL_PROPOSTA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA);
                _.Move(executed_1.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV);
                _.Move(executed_1.APOLIAUT_COD_FONTE, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE);
            }


        }

        [StopWatch]
        /*" R7220-00-CONSULTA-NN-DB-UPDATE-1 */
        public void R7220_00_CONSULTA_NN_DB_UPDATE_1()
        {
            /*" -8086- EXEC SQL UPDATE SEGUROS.PARCELAS SET NUM_TITULO = :PARC-NRTIT WHERE NUM_APOLICE = :PARC-NUM-APOLICE AND NUM_ENDOSSO = :PARC-NRENDOS AND NUM_PARCELA = :PARC-NRPARCEL END-EXEC */

            var r7220_00_CONSULTA_NN_DB_UPDATE_1_Update1 = new R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1()
            {
                PARC_NRTIT = PARC_NRTIT.ToString(),
                PARC_NUM_APOLICE = PARC_NUM_APOLICE.ToString(),
                PARC_NRPARCEL = PARC_NRPARCEL.ToString(),
                PARC_NRENDOS = PARC_NRENDOS.ToString(),
            };

            R7220_00_CONSULTA_NN_DB_UPDATE_1_Update1.Execute(r7220_00_CONSULTA_NN_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7220_99_SAIDA*/

        [StopWatch]
        /*" R8000-HABIT-BANCO-LUSO-SECTION */
        private void R8000_HABIT_BANCO_LUSO_SECTION()
        {
            /*" -8103- MOVE 0 TO W-VALOR-IS . */
            _.Move(0, W_VALOR_IS);

            /*" -8104- MOVE 0 TO W-VALOR-PREMIO . */
            _.Move(0, W_VALOR_PREMIO);

            /*" -8105- MOVE 0 TO W-VALOR-IOF . */
            _.Move(0, W_VALOR_IOF);

            /*" -8107- MOVE 0 TO W-VALOR-TOTAL-PREMIO. */
            _.Move(0, W_VALOR_TOTAL_PREMIO);

            /*" -8109- MOVE 'NAO' TO W-FIM-APOLICE-COBERTURA. */
            _.Move("NAO", W_FIM_APOLICE_COBERTURA);

            /*" -8111- PERFORM R8010-DECLARE-APOLICE-COBER. */

            R8010_DECLARE_APOLICE_COBER_SECTION();

            /*" -8113- PERFORM R8015-FETCH-APOLICE-COBERTURA. */

            R8015_FETCH_APOLICE_COBERTURA_SECTION();

            /*" -8114- PERFORM R8020-PROCESSA-APOLICE-COBER UNTIL W-FIM-APOLICE-COBERTURA EQUAL 'SIM' . */

            while (!(W_FIM_APOLICE_COBERTURA == "SIM"))
            {

                R8020_PROCESSA_APOLICE_COBER_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_EXIT*/

        [StopWatch]
        /*" R8010-DECLARE-APOLICE-COBER-SECTION */
        private void R8010_DECLARE_APOLICE_COBER_SECTION()
        {
            /*" -8122- INITIALIZE DCLAPOLICE-COBERTURAS. */
            _.Initialize(
                APOLICOB.DCLAPOLICE_COBERTURAS
            );

            /*" -8123- MOVE ENDO-NUM-APOLICE TO APOLICOB-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -8125- MOVE ENDO-NRENDOS TO APOLICOB-NUM-ENDOSSO. */
            _.Move(ENDO_NRENDOS, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -8127- MOVE 'R8010' TO WNR-EXEC-SQL. */
            _.Move("R8010", WABEND.WNR_EXEC_SQL);

            /*" -8144- PERFORM R8010_DECLARE_APOLICE_COBER_DB_DECLARE_1 */

            R8010_DECLARE_APOLICE_COBER_DB_DECLARE_1();

            /*" -8146- PERFORM R8010_DECLARE_APOLICE_COBER_DB_OPEN_1 */

            R8010_DECLARE_APOLICE_COBER_DB_OPEN_1();

            /*" -8149- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8150- DISPLAY 'R8010 - ERRO NO OPEN APOLICE_COBERTURAS' */
                _.Display($"R8010 - ERRO NO OPEN APOLICE_COBERTURAS");

                /*" -8150- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8010-DECLARE-APOLICE-COBER-DB-OPEN-1 */
        public void R8010_DECLARE_APOLICE_COBER_DB_OPEN_1()
        {
            /*" -8146- EXEC SQL OPEN APOLICE_COBERTURAS END-EXEC. */

            APOLICE_COBERTURAS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8010_EXIT*/

        [StopWatch]
        /*" R8015-FETCH-APOLICE-COBERTURA-SECTION */
        private void R8015_FETCH_APOLICE_COBERTURA_SECTION()
        {
            /*" -8158- MOVE 'R8015' TO WNR-EXEC-SQL. */
            _.Move("R8015", WABEND.WNR_EXEC_SQL);

            /*" -8169- PERFORM R8015_FETCH_APOLICE_COBERTURA_DB_FETCH_1 */

            R8015_FETCH_APOLICE_COBERTURA_DB_FETCH_1();

            /*" -8172- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -8172- PERFORM R8015_FETCH_APOLICE_COBERTURA_DB_CLOSE_1 */

                R8015_FETCH_APOLICE_COBERTURA_DB_CLOSE_1();

                /*" -8174- MOVE 'SIM' TO W-FIM-APOLICE-COBERTURA */
                _.Move("SIM", W_FIM_APOLICE_COBERTURA);

                /*" -8176- GO TO R8015-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8015_EXIT*/ //GOTO
                return;
            }


            /*" -8177- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -8178- DISPLAY 'R8015 - ERRO FETCH  APOLICE_COBERTURAS' */
                _.Display($"R8015 - ERRO FETCH  APOLICE_COBERTURAS");

                /*" -8178- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R8015-FETCH-APOLICE-COBERTURA-DB-FETCH-1 */
        public void R8015_FETCH_APOLICE_COBERTURA_DB_FETCH_1()
        {
            /*" -8169- EXEC SQL FETCH APOLICE_COBERTURAS INTO :APOLICOB-NUM-APOLICE ,:APOLICOB-NUM-ENDOSSO ,:APOLICOB-RAMO-COBERTURA ,:APOLICOB-MODALI-COBERTURA ,:APOLICOB-COD-COBERTURA ,:APOLICOB-IMP-SEGURADA-IX ,:APOLICOB-PRM-TARIFARIO-IX ,:APOLICOB-DATA-INIVIGENCIA ,:APOLICOB-DATA-TERVIGENCIA END-EXEC. */

            if (APOLICE_COBERTURAS.Fetch())
            {
                _.Move(APOLICE_COBERTURAS.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(APOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);
                _.Move(APOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(APOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);
                _.Move(APOLICE_COBERTURAS.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(APOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(APOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(APOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(APOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
            }

        }

        [StopWatch]
        /*" R8015-FETCH-APOLICE-COBERTURA-DB-CLOSE-1 */
        public void R8015_FETCH_APOLICE_COBERTURA_DB_CLOSE_1()
        {
            /*" -8172- EXEC SQL CLOSE APOLICE_COBERTURAS END-EXEC */

            APOLICE_COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8015_EXIT*/

        [StopWatch]
        /*" R8020-PROCESSA-APOLICE-COBER-SECTION */
        private void R8020_PROCESSA_APOLICE_COBER_SECTION()
        {
            /*" -8187- COMPUTE W-VALOR-IS = W-VALOR-IS + APOLICOB-IMP-SEGURADA-IX. */
            W_VALOR_IS.Value = W_VALOR_IS + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX;

            /*" -8190- COMPUTE W-VALOR-PREMIO = W-VALOR-PREMIO + APOLICOB-PRM-TARIFARIO-IX. */
            W_VALOR_PREMIO.Value = W_VALOR_PREMIO + APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX;

            /*" -8191- IF APOLICOB-RAMO-COBERTURA EQUAL 61 */

            if (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA == 61)
            {

                /*" -8194- COMPUTE W-VALOR-IOF = (APOLICOB-PRM-TARIFARIO-IX * 0,38) / 100 + W-VALOR-IOF */
                W_VALOR_IOF.Value = (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * 0.38) / 100f + W_VALOR_IOF;

                /*" -8195- ELSE */
            }
            else
            {


                /*" -8196- IF APOLICOB-RAMO-COBERTURA EQUAL 65 OR 68 */

                if (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.In("65", "68"))
                {

                    /*" -8199- COMPUTE W-VALOR-IOF = (APOLICOB-PRM-TARIFARIO-IX * 7,38) / 100 + W-VALOR-IOF */
                    W_VALOR_IOF.Value = (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX * 7.38) / 100f + W_VALOR_IOF;

                    /*" -8200- ELSE */
                }
                else
                {


                    /*" -8201- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -8202- DISPLAY 'R8020 - RAMO COBERTURA NAO PREVISTO' */
                    _.Display($"R8020 - RAMO COBERTURA NAO PREVISTO");

                    /*" -8203- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -8205- DISPLAY 'APOLICOB-RAMO-COBERTURA = ' APOLICOB-RAMO-COBERTURA */
                    _.Display($"APOLICOB-RAMO-COBERTURA = {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                    /*" -8206- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -8208- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -8212- COMPUTE W-VALOR-TOTAL-PREMIO = W-VALOR-PREMIO + W-VALOR-IOF. */
            W_VALOR_TOTAL_PREMIO.Value = W_VALOR_PREMIO + W_VALOR_IOF;

            /*" -8213- DISPLAY ' ' */
            _.Display($" ");

            /*" -8214- DISPLAY 'LEITURA DA APOLICE_COBERTURA' */
            _.Display($"LEITURA DA APOLICE_COBERTURA");

            /*" -8216- DISPLAY 'APOLICOB-NUM-APOLICE: ' APOLICOB-NUM-APOLICE ' APOLICOB-NUM-ENDOSSO: ' APOLICOB-NUM-ENDOSSO */

            $"APOLICOB-NUM-APOLICE: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE} APOLICOB-NUM-ENDOSSO: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}"
            .Display();

            /*" -8218- DISPLAY 'APOLICOB-RAMO-COBERTURA: ' APOLICOB-RAMO-COBERTURA */
            _.Display($"APOLICOB-RAMO-COBERTURA: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

            /*" -8219- MOVE APOLICOB-PRM-TARIFARIO-IX TO W-EDICAO1 */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX, W_EDICAO1);

            /*" -8220- DISPLAY 'APOLICOB-PRM-TARIFARIO-IX...: ' W-EDICAO1 */
            _.Display($"APOLICOB-PRM-TARIFARIO-IX...: {W_EDICAO1}");

            /*" -8221- MOVE W-VALOR-PREMIO TO W-EDICAO1 */
            _.Move(W_VALOR_PREMIO, W_EDICAO1);

            /*" -8222- DISPLAY 'W-VALOR-PREMIO..............: ' W-EDICAO1 */
            _.Display($"W-VALOR-PREMIO..............: {W_EDICAO1}");

            /*" -8223- MOVE W-VALOR-IOF TO W-EDICAO1. */
            _.Move(W_VALOR_IOF, W_EDICAO1);

            /*" -8224- DISPLAY 'W-VALOR-IOF.................: ' W-EDICAO1. */
            _.Display($"W-VALOR-IOF.................: {W_EDICAO1}");

            /*" -8225- MOVE W-VALOR-TOTAL-PREMIO TO W-EDICAO1 */
            _.Move(W_VALOR_TOTAL_PREMIO, W_EDICAO1);

            /*" -8227- DISPLAY 'W-VALOR-TOTAL-PREMIO .......: ' W-EDICAO1 */
            _.Display($"W-VALOR-TOTAL-PREMIO .......: {W_EDICAO1}");

            /*" -8227- PERFORM R8015-FETCH-APOLICE-COBERTURA . */

            R8015_FETCH_APOLICE_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8020_EXIT*/

        [StopWatch]
        /*" C0000-FIM-SECTION */
        private void C0000_FIM_SECTION()
        {
            /*" -8236- MOVE 'C0000' TO WNR-EXEC-SQL. */
            _.Move("C0000", WABEND.WNR_EXEC_SQL);

            /*" -8236- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -8240- DISPLAY 'ENDOSSOS LIDOS        ' AC-L-V1ENDOSSO. */
            _.Display($"ENDOSSOS LIDOS        {AC_L_V1ENDOSSO}");

            /*" -8241- DISPLAY 'DOCUMENTOS INSERIDOS  ' */
            _.Display($"DOCUMENTOS INSERIDOS  ");

            /*" -8242- DISPLAY ' . V0PARCELA          ' AC-I-V0PARCELA. */
            _.Display($" . V0PARCELA          {AC_I_V0PARCELA}");

            /*" -8243- DISPLAY ' . V0HISTOPARC        ' AC-I-V0HISTOPARC. */
            _.Display($" . V0HISTOPARC        {AC_I_V0HISTOPARC}");

            /*" -8244- DISPLAY ' . V0ORDCOSCED        ' AC-I-V0ORDCOSCED. */
            _.Display($" . V0ORDCOSCED        {AC_I_V0ORDCOSCED}");

            /*" -8245- DISPLAY ' . V0RCAPCOMP         ' AC-I-V0RCAPCOMP. */
            _.Display($" . V0RCAPCOMP         {AC_I_V0RCAPCOMP}");

            /*" -8246- DISPLAY ' . V0EMISDIARIA       ' AC-I-V0EMISDIARIA. */
            _.Display($" . V0EMISDIARIA       {AC_I_V0EMISDIARIA}");

            /*" -8247- DISPLAY ' . V0RELATORIOS       ' AC-I-V0RELATORIO. */
            _.Display($" . V0RELATORIOS       {AC_I_V0RELATORIO}");

            /*" -8248- DISPLAY ' . PARCELA_AUTO_COMPL ' AC-I-AU071 . */
            _.Display($" . PARCELA_AUTO_COMPL {AC_I_AU071}");

            /*" -8249- DISPLAY ' . TITULOS CAP LOT    ' AC-I-TITCAP-LOT. */
            _.Display($" . TITULOS CAP LOT    {AC_I_TITCAP_LOT}");

            /*" -8251- DISPLAY 'EM0030B - FIM NORMAL ' . */
            _.Display($"EM0030B - FIM NORMAL ");

            /*" -8253- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -8253- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: C0000_999_EXIT*/

        [StopWatch]
        /*" M-99999-DISPLAY-SECTION */
        private void M_99999_DISPLAY_SECTION()
        {
            /*" -8263- DISPLAY 'RAMO           = ' RAMO */
            _.Display($"RAMO           = {EM0901W099.RAMO}");

            /*" -8264- DISPLAY 'COD-MOEDA      = ' COD-MOEDA */
            _.Display($"COD-MOEDA      = {EM0901W099.COD_MOEDA}");

            /*" -8265- DISPLAY 'DTINIVIG       = ' DTINIVIG */
            _.Display($"DTINIVIG       = {EM0901W099.DTINIVIG}");

            /*" -8266- DISPLAY 'NRPARCEL       = ' NRPARCEL */
            _.Display($"NRPARCEL       = {EM0901W099.NRPARCEL}");

            /*" -8267- DISPLAY 'QTPARCEL       = ' QTPARCEL */
            _.Display($"QTPARCEL       = {EM0901W099.QTPARCEL}");

            /*" -8268- DISPLAY 'IND-FRAC       = ' IND-FRAC */
            _.Display($"IND-FRAC       = {EM0901W099.IND_FRAC}");

            /*" -8269- DISPLAY 'ISENTA-CUSTO   = ' ISENTA-CUSTO */
            _.Display($"ISENTA-CUSTO   = {EM0901W099.ISENTA_CUSTO}");

            /*" -8270- DISPLAY 'PCIOF          = ' PCIOF */
            _.Display($"PCIOF          = {EM0901W099.PCIOF}");

            /*" -8271- DISPLAY 'PCENTRAD       = ' PCENTRAD */
            _.Display($"PCENTRAD       = {EM0901W099.PCENTRAD}");

            /*" -8272- DISPLAY 'PCJUROS        = ' PCJUROS */
            _.Display($"PCJUROS        = {EM0901W099.PCJUROS}");

            /*" -8273- DISPLAY 'PCDESCON       = ' PCDESCON */
            _.Display($"PCDESCON       = {EM0901W099.PCDESCON}");

            /*" -8274- DISPLAY 'VL-PREMIO-BASE = ' VL-PREMIO-BASE */
            _.Display($"VL-PREMIO-BASE = {EM0901W099.VL_PREMIO_BASE}");

            /*" -8275- DISPLAY 'VL-TARIFARIO-IX= ' VL-TARIFARIO-IX */
            _.Display($"VL-TARIFARIO-IX= {EM0901W099.VL_TARIFARIO_IX}");

            /*" -8276- DISPLAY 'VL-DESC-IX     = ' VL-DESC-IX */
            _.Display($"VL-DESC-IX     = {EM0901W099.VL_DESC_IX}");

            /*" -8277- DISPLAY 'VL-LIQ-IX      = ' VL-LIQ-IX */
            _.Display($"VL-LIQ-IX      = {EM0901W099.VL_LIQ_IX}");

            /*" -8278- DISPLAY 'VL-ADIC-IX     = ' VL-ADIC-IX */
            _.Display($"VL-ADIC-IX     = {EM0901W099.VL_ADIC_IX}");

            /*" -8279- DISPLAY 'VL-CUSTO-IX    = ' VL-CUSTO-IX */
            _.Display($"VL-CUSTO-IX    = {EM0901W099.VL_CUSTO_IX}");

            /*" -8280- DISPLAY 'VL-IOF-IX      = ' VL-IOF-IX */
            _.Display($"VL-IOF-IX      = {EM0901W099.VL_IOF_IX}");

            /*" -8281- DISPLAY 'VL-TOTAL-IX    = ' VL-TOTAL-IX */
            _.Display($"VL-TOTAL-IX    = {EM0901W099.VL_TOTAL_IX}");

            /*" -8282- DISPLAY 'VL-TARIFA      = ' VL-TARIFA */
            _.Display($"VL-TARIFA      = {EM0901W099.VL_TARIFA}");

            /*" -8283- DISPLAY 'VL-DESCONTO    = ' VL-DESCONTO */
            _.Display($"VL-DESCONTO    = {EM0901W099.VL_DESCONTO}");

            /*" -8284- DISPLAY 'VL-LIQUIDO     = ' VL-LIQUIDO */
            _.Display($"VL-LIQUIDO     = {EM0901W099.VL_LIQUIDO}");

            /*" -8285- DISPLAY 'VL-ADICIONA    = ' VL-ADICIONAL */
            _.Display($"VL-ADICIONA    = {EM0901W099.VL_ADICIONAL}");

            /*" -8286- DISPLAY 'VL-CUSTO       = ' VL-CUSTO */
            _.Display($"VL-CUSTO       = {EM0901W099.VL_CUSTO}");

            /*" -8287- DISPLAY 'VL-IOF         = ' VL-IOF */
            _.Display($"VL-IOF         = {EM0901W099.VL_IOF}");

            /*" -8288- DISPLAY 'VL-TOTAL       = ' VL-TOTAL */
            _.Display($"VL-TOTAL       = {EM0901W099.VL_TOTAL}");

            /*" -8289- DISPLAY 'NRRCAP         = ' NRRCAP */
            _.Display($"NRRCAP         = {EM0901W099.NRRCAP}");

            /*" -8290- DISPLAY 'VL-COBER-ASSIST= ' VL-COBER-ASSIST */
            _.Display($"VL-COBER-ASSIST= {EM0901W099.VL_COBER_ASSIST}");

            /*" -8291- DISPLAY 'PCDESCON-ADIC  = ' PCDESCON-ADIC */
            _.Display($"PCDESCON-ADIC  = {EM0901W099.PCDESCON_ADIC}");

            /*" -8292- DISPLAY 'PCDESCON-BONUS = ' PCDESCON-BONUS */
            _.Display($"PCDESCON-BONUS = {EM0901W099.PCDESCON_BONUS}");

            /*" -8292- DISPLAY 'VL-TARIFARIO-IX  =' VL-TARIFARIO-IX. */
            _.Display($"VL-TARIFARIO-IX  ={EM0901W099.VL_TARIFARIO_IX}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_99999_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -8302- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -8304- GO TO 999-999-SEM-UPDATE. */

                M_999_999_SEM_UPDATE_SECTION(); //GOTO
                return;
            }


            /*" -8305- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8306- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -8307- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -8308- MOVE SQLERRD(1) TO WERRO */
                _.Move(DB.SQLERRD[1], WERRO);

                /*" -8309- DISPLAY 'SQLERRD(1) ' WERRO */
                _.Display($"SQLERRD(1) {WERRO}");

                /*" -8310- MOVE SQLERRD(2) TO WERRO */
                _.Move(DB.SQLERRD[2], WERRO);

                /*" -8311- DISPLAY 'SQLERRD(2) ' WERRO. */
                _.Display($"SQLERRD(2) {WERRO}");
            }


            /*" -8313- DISPLAY 'SQLSTATE   ' SQLSTATE. */
            _.Display($"SQLSTATE   {DB.SQLSTATE}");

            /*" -8314- DISPLAY 'ROTINA 999-999-ROT-ERRO' */
            _.Display($"ROTINA 999-999-ROT-ERRO");

            /*" -8315- DISPLAY 'FONTE..... ' ENDO-FONTE. */
            _.Display($"FONTE..... {ENDO_FONTE}");

            /*" -8316- DISPLAY 'RAMO...... ' ENDO-RAMO. */
            _.Display($"RAMO...... {ENDO_RAMO}");

            /*" -8317- DISPLAY 'PROPOSTA.. ' ENDO-NRPROPOS. */
            _.Display($"PROPOSTA.. {ENDO_NRPROPOS}");

            /*" -8318- DISPLAY 'APOLICE... ' ENDO-NUM-APOLICE. */
            _.Display($"APOLICE... {ENDO_NUM_APOLICE}");

            /*" -8320- DISPLAY 'ENDOSSO... ' ENDO-NRENDOS. */
            _.Display($"ENDOSSO... {ENDO_NRENDOS}");

            /*" -8320- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -8322- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -8333- PERFORM M_999_999_ROT_ERRO_DB_UPDATE_1 */

            M_999_999_ROT_ERRO_DB_UPDATE_1();

            /*" -8335- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -8340- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -8340- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-999-999-ROT-ERRO-DB-UPDATE-1 */
        public void M_999_999_ROT_ERRO_DB_UPDATE_1()
        {
            /*" -8333- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = 'E' WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

            var m_999_999_ROT_ERRO_DB_UPDATE_1_Update1 = new M_999_999_ROT_ERRO_DB_UPDATE_1_Update1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            M_999_999_ROT_ERRO_DB_UPDATE_1_Update1.Execute(m_999_999_ROT_ERRO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_999_999_EXIT*/

        [StopWatch]
        /*" M-999-999-SEM-UPDATE-SECTION */
        private void M_999_999_SEM_UPDATE_SECTION()
        {
            /*" -8350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8351- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -8352- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -8353- MOVE SQLERRD(1) TO WERRO */
                _.Move(DB.SQLERRD[1], WERRO);

                /*" -8354- DISPLAY 'SQLERRD(1) ' WERRO */
                _.Display($"SQLERRD(1) {WERRO}");

                /*" -8355- MOVE SQLERRD(2) TO WERRO */
                _.Move(DB.SQLERRD[2], WERRO);

                /*" -8357- DISPLAY 'SQLERRD(2) ' WERRO. */
                _.Display($"SQLERRD(2) {WERRO}");
            }


            /*" -8358- DISPLAY ' ' */
            _.Display($" ");

            /*" -8359- DISPLAY 'ULTIMO CURSOR LIDO NO DECLARE PRINCIPAL' */
            _.Display($"ULTIMO CURSOR LIDO NO DECLARE PRINCIPAL");

            /*" -8360- DISPLAY 'FONTE..... ' ENDO-FONTE. */
            _.Display($"FONTE..... {ENDO_FONTE}");

            /*" -8361- DISPLAY 'RAMO...... ' ENDO-RAMO. */
            _.Display($"RAMO...... {ENDO_RAMO}");

            /*" -8362- DISPLAY 'PROPOSTA.. ' ENDO-NRPROPOS. */
            _.Display($"PROPOSTA.. {ENDO_NRPROPOS}");

            /*" -8363- DISPLAY 'APOLICE... ' ENDO-NUM-APOLICE. */
            _.Display($"APOLICE... {ENDO_NUM_APOLICE}");

            /*" -8365- DISPLAY 'ENDOSSO... ' ENDO-NRENDOS. */
            _.Display($"ENDOSSO... {ENDO_NRENDOS}");

            /*" -8366- DISPLAY ' ' */
            _.Display($" ");

            /*" -8367- DISPLAY '##################################################' */
            _.Display($"##################################################");

            /*" -8368- DISPLAY 'ATENCAO: EM CASO DE ABEND FAVOR RESTARTAR NO MESMO' */
            _.Display($"ATENCAO: EM CASO DE ABEND FAVOR RESTARTAR NO MESMO");

            /*" -8369- DISPLAY '         STEP QUANTAS VEZES FOR NECESSARIO  ATE  O' */
            _.Display($"         STEP QUANTAS VEZES FOR NECESSARIO  ATE  O");

            /*" -8370- DISPLAY '         PROCESSAMENTO COM TERMINO NORMAL         ' */
            _.Display($"         PROCESSAMENTO COM TERMINO NORMAL         ");

            /*" -8372- DISPLAY '##################################################' */
            _.Display($"##################################################");

            /*" -8372- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -8374- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -8378- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -8378- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}