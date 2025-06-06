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
using Sias.Emissao.DB2.EM0010B;

namespace Code
{
    public class EM0010B
    {
        public bool IsCall { get; set; }

        public EM0010B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *REMARKS.                                                               */
        /*"      **                                                               *      */
        /*"      *      ADMINISTRACAO INTEGRADA DE SEGUROS   -  EMISSAO           *      */
        /*"      *                                                                *      */
        /*"      *        SISTEMA ............ EMISSAO                            *      */
        /*"      *        PROGRAMA............ EM0010B                            *      */
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
        /*"V.70  * VERSAO  : 070                                                  *      */
        /*"      * MOTIVO  : ABEND NA ROTINA EM0905S                              *      */
        /*"      * JAZZ    : ABEND 287298                                         *      */
        /*"      * DATA    : 04/05/2021                                           *      */
        /*"      * NOME    : MILLENIUM                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.69  * VERSAO  : 069                                                  *      */
        /*"      * MOTIVO  : AJUSTAR ROTINA DE CALCULO LT3214S PROD 1803 E 1805   *      */
        /*"      * JAZZ    : 248622/248624                                        *      */
        /*"      * DATA    : 23/03/2021                                           *      */
        /*"      * NOME    : MILLENIUM                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.68  * VERSAO  : 068                                                  *      */
        /*"      * MOTIVO  : AJUSTAR PRODUTO LOTERICO DATA VENCIMENTO DEMAIS PCLS *      */
        /*"      * JAZZ    : 248622/248624                                        *      */
        /*"      * DATA    : 01/03/2021                                           *      */
        /*"      * NOME    : MILLENIUM                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.67  * VERSAO  : 067                                                  *      */
        /*"      * MOTIVO  : AJUSTAR PRODUTO LOTERICO DATA VENCIMENTO DEMAIS PCLS *      */
        /*"      * JAZZ    : 248622/248624                                        *      */
        /*"      * DATA    : 26/02/2021                                           *      */
        /*"      * NOME    : MILLENIUM                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.66  * VERSAO  : 066                                                  *      */
        /*"      * MOTIVO  : AJUSTAR PRODUTO LOTERICO PARA RENOVACAO 2021         *      */
        /*"      * JAZZ    : 248622/248624                                               */
        /*"      * DATA    : 08/12/2020                                           *      */
        /*"      * NOME    : MILLENIUM                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.65  * VERSAO  : 065                                                  *      */
        /*"      * MOTIVO  : AJUSTAR SELECT TRATAR CAMPO NULO                     *      */
        /*"      *           E DIFEREN�A DO IOF DE 6 PARA 2 DECIMAIS              *      */
        /*"      * CADMUS  : 182790                                                      */
        /*"      * DATA    : 09/06/2020                                           *      */
        /*"      * NOME    : OLIVEIRA                                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.64  * VERSAO  : 064                                                  *      */
        /*"      * MOTIVO  : EXCLUIR DO PROCESSAMENTO AS APLOICES DO BANCO LUSO   *      */
        /*"      *           0106100000011 E 0106800000024                               */
        /*"      *           ESTAS APOLICES ERAM PROCESSADAS PELO EFP E NAO FORAM        */
        /*"      *           MIGRADAS PARA O SMART. OS ENDOSSOS ESTAO SENDO              */
        /*"      *           GERADOS PELO SIAS                                           */
        /*"      *           QUE PASSAM A SER PROCESSADAS PELO ==>  EM0030B              */
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
        /*"      *               ERRO INSERT V0HISTOPARC EM0010B *                       */
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
        public EM0010B_WS_DT_AUX WS_DT_AUX { get; set; } = new EM0010B_WS_DT_AUX();
        public class EM0010B_WS_DT_AUX : VarBasis
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
        /*"77  W1                       PIC S9(04) COMP.*/
        public IntBasis W1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        public EM0010B_WABEND WABEND { get; set; } = new EM0010B_WABEND();
        public class EM0010B_WABEND : VarBasis
        {
            /*"   05 FILLER                      PIC X(10) VALUE      ' EM0010B  '.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @" EM0010B  ");
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
        private _REDEF_EM0010B_WS_COMPL_ENDER_R _ws_compl_ender_r { get; set; }
        public _REDEF_EM0010B_WS_COMPL_ENDER_R WS_COMPL_ENDER_R
        {
            get { _ws_compl_ender_r = new _REDEF_EM0010B_WS_COMPL_ENDER_R(); _.Move(WS_COMPL_ENDER, _ws_compl_ender_r); VarBasis.RedefinePassValue(WS_COMPL_ENDER, _ws_compl_ender_r, WS_COMPL_ENDER); _ws_compl_ender_r.ValueChanged += () => { _.Move(_ws_compl_ender_r, WS_COMPL_ENDER); }; return _ws_compl_ender_r; }
            set { VarBasis.RedefinePassValue(value, _ws_compl_ender_r, WS_COMPL_ENDER); }
        }  //Redefines
        public class _REDEF_EM0010B_WS_COMPL_ENDER_R : VarBasis
        {
            /*"     10 WS-COMPL-CLASSE          PIC   X(01).*/
            public StringBasis WS_COMPL_CLASSE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     10 WS-COMPL-INDICE          PIC   9(02).*/
            public IntBasis WS_COMPL_INDICE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10 FILLER                   PIC   X(12).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
            /*"01  WS-SQLCODE                   PIC ---9.*/

            public _REDEF_EM0010B_WS_COMPL_ENDER_R()
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
        /*"01  WS-PERIODO-RENOVACAO         PIC S9(004)  COMP VALUE 2021.*/
        public IntBasis WS_PERIODO_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), 2021);
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
        /*"01          WS-VALOR-AUX2       PIC S9(15)V9(02) COMP-3.*/
        public DoubleBasis WS_VALOR_AUX2 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(02)"), 2);
        /*"01  W-FONTE                     PIC  9(04) VALUE ZEROS.*/
        public IntBasis W_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  W-NRCAP                     PIC  9(09) VALUE ZEROS.*/
        public IntBasis W_NRCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  W-HORA.*/
        public EM0010B_W_HORA W_HORA { get; set; } = new EM0010B_W_HORA();
        public class EM0010B_W_HORA : VarBasis
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
        private _REDEF_EM0010B_FILLER_4 _filler_4 { get; set; }
        public _REDEF_EM0010B_FILLER_4 FILLER_4
        {
            get { _filler_4 = new _REDEF_EM0010B_FILLER_4(); _.Move(WTIME_DAY, _filler_4); VarBasis.RedefinePassValue(WTIME_DAY, _filler_4, WTIME_DAY); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTIME_DAY); }; return _filler_4; }
            set { VarBasis.RedefinePassValue(value, _filler_4, WTIME_DAY); }
        }  //Redefines
        public class _REDEF_EM0010B_FILLER_4 : VarBasis
        {
            /*"  05         WTIME-DAYR.*/
            public EM0010B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM0010B_WTIME_DAYR();
            public class EM0010B_WTIME_DAYR : VarBasis
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

                public EM0010B_WTIME_DAYR()
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

            public _REDEF_EM0010B_FILLER_4()
            {
                WTIME_DAYR.ValueChanged += OnValueChanged;
                WTIME_2PT3.ValueChanged += OnValueChanged;
                WTIME_CCSE.ValueChanged += OnValueChanged;
            }

        }
        public EM0010B_WS_TIME WS_TIME { get; set; } = new EM0010B_WS_TIME();
        public class EM0010B_WS_TIME : VarBasis
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
        public EM0010B_WHOR_REL_LIT WHOR_REL_LIT { get; set; } = new EM0010B_WHOR_REL_LIT();
        public class EM0010B_WHOR_REL_LIT : VarBasis
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
        public EM0010B_W_HORA_EDITADA W_HORA_EDITADA { get; set; } = new EM0010B_W_HORA_EDITADA();
        public class EM0010B_W_HORA_EDITADA : VarBasis
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
        public EM0010B_W_DTTERVIG W_DTTERVIG { get; set; } = new EM0010B_W_DTTERVIG();
        public class EM0010B_W_DTTERVIG : VarBasis
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
        public EM0010B_W_DATA_EDITADA W_DATA_EDITADA { get; set; } = new EM0010B_W_DATA_EDITADA();
        public class EM0010B_W_DATA_EDITADA : VarBasis
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
        public EM0010B_W_DATA_DEBITO W_DATA_DEBITO { get; set; } = new EM0010B_W_DATA_DEBITO();
        public class EM0010B_W_DATA_DEBITO : VarBasis
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
            /*"01  W-DATA-VENCTO.*/
        }
        public EM0010B_W_DATA_VENCTO W_DATA_VENCTO { get; set; } = new EM0010B_W_DATA_VENCTO();
        public class EM0010B_W_DATA_VENCTO : VarBasis
        {
            /*"    03  W-ANO-VENCTO            PIC  9(04).*/
            public IntBasis W_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '-'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    03  W-MES-VENCTO            PIC  9(02).*/
            public IntBasis W_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '-'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    03  W-DIA-VENCTO            PIC  9(02).*/
            public IntBasis W_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01  W-DATA-DB2.*/
        }
        public EM0010B_W_DATA_DB2 W_DATA_DB2 { get; set; } = new EM0010B_W_DATA_DB2();
        public class EM0010B_W_DATA_DB2 : VarBasis
        {
            /*"    03  W-ANO-DB2               PIC  9(04).*/
            public IntBasis W_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '-'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    03  W-MES-DB2               PIC  9(02).*/
            public IntBasis W_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  FILLER                  PIC  X(01) VALUE '-'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"    03  W-DIA-DB2               PIC  9(02).*/
            public IntBasis W_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"01      VENCIMENTOS.*/
        }
        public EM0010B_VENCIMENTOS VENCIMENTOS { get; set; } = new EM0010B_VENCIMENTOS();
        public class EM0010B_VENCIMENTOS : VarBasis
        {
            /*" 05     TABELA-VENCIMENTOS.*/
            public EM0010B_TABELA_VENCIMENTOS TABELA_VENCIMENTOS { get; set; } = new EM0010B_TABELA_VENCIMENTOS();
            public class EM0010B_TABELA_VENCIMENTOS : VarBasis
            {
                /*"  10    TBVEN-MASCARA.*/
                public EM0010B_TBVEN_MASCARA TBVEN_MASCARA { get; set; } = new EM0010B_TBVEN_MASCARA();
                public class EM0010B_TBVEN_MASCARA : VarBasis
                {
                    /*"   15   FILLER                  PIC  9(002)    VALUE  ZEROS.*/
                    public IntBasis FILLER_19 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   15   FILLER                  PIC  X(010)    VALUE  SPACES.*/
                    public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"   15   FILLER                  PIC  9(002)    VALUE  ZEROS.*/
                    public IntBasis FILLER_21 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   15   FILLER                  PIC  X(010)    VALUE  SPACES.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"   15   TBVEN-DATAS.*/
                    public EM0010B_TBVEN_DATAS TBVEN_DATAS { get; set; } = new EM0010B_TBVEN_DATAS();
                    public class EM0010B_TBVEN_DATAS : VarBasis
                    {
                        /*"    20  TBVEN-CAMPOS            OCCURS 12 TIMES INDEXED BY IX1.*/
                        public ListBasis<EM0010B_TBVEN_CAMPOS> TBVEN_CAMPOS { get; set; } = new ListBasis<EM0010B_TBVEN_CAMPOS>(12);
                        public class EM0010B_TBVEN_CAMPOS : VarBasis
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
            public EM0010B_W_DATA_M15 W_DATA_M15 { get; set; } = new EM0010B_W_DATA_M15();
            public class EM0010B_W_DATA_M15 : VarBasis
            {
                /*"   10   W-ANO-M15               PIC  9(004).*/
                public IntBasis W_ANO_M15 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10   FILLER                  PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10   W-MES-M15               PIC  9(002).*/
                public IntBasis W_MES_M15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10   FILLER                  PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"   10   W-DIA-M15               PIC  9(002).*/
                public IntBasis W_DIA_M15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05     LDIFE.*/
            }
            public EM0010B_LDIFE LDIFE { get; set; } = new EM0010B_LDIFE();
            public class EM0010B_LDIFE : VarBasis
            {
                /*"  10    LDIFE01.*/
                public EM0010B_LDIFE01 LDIFE01 { get; set; } = new EM0010B_LDIFE01();
                public class EM0010B_LDIFE01 : VarBasis
                {
                    /*"   15   LDIFE01-DD              PIC  9(002).*/
                    public IntBasis LDIFE01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   15   LDIFE01-MM              PIC  9(002).*/
                    public IntBasis LDIFE01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   15   LDIFE01-AA              PIC  9(004).*/
                    public IntBasis LDIFE01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"  10    LDIFE02.*/
                }
                public EM0010B_LDIFE02 LDIFE02 { get; set; } = new EM0010B_LDIFE02();
                public class EM0010B_LDIFE02 : VarBasis
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
            private _REDEF_EM0010B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_EM0010B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_EM0010B_FILLER_25(); _.Move(WC_DATA, _filler_25); VarBasis.RedefinePassValue(WC_DATA, _filler_25, WC_DATA); _filler_25.ValueChanged += () => { _.Move(_filler_25, WC_DATA); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WC_DATA); }
            }  //Redefines
            public class _REDEF_EM0010B_FILLER_25 : VarBasis
            {
                /*"  10    WC-DIA                  PIC  9(002).*/
                public IntBasis WC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10    WC-MES                  PIC  9(002).*/
                public IntBasis WC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  10    WC-ANO                  PIC  9(004).*/
                public IntBasis WC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01      WS-VERSAO               PIC  X(090)  VALUE       'EM0010B - V.63 - 08/01/2020 - CADMUS 179615            '*/

                public _REDEF_EM0010B_FILLER_25()
                {
                    WC_DIA.ValueChanged += OnValueChanged;
                    WC_MES.ValueChanged += OnValueChanged;
                    WC_ANO.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "90", "X(090)"), @"EM0010B - V.63 - 08/01/2020 - CADMUS 179615            ");
        /*"01  W-DATA.*/
        public EM0010B_W_DATA W_DATA { get; set; } = new EM0010B_W_DATA();
        public class EM0010B_W_DATA : VarBasis
        {
            /*"    03  W-DD                    PIC  9(02).*/
            public IntBasis W_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-MM                    PIC  9(02).*/
            public IntBasis W_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  W-AA                    PIC  9(04).*/
            public IntBasis W_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"01           PROSOMW099.*/
        }
        public EM0010B_PROSOMW099 PROSOMW099 { get; set; } = new EM0010B_PROSOMW099();
        public class EM0010B_PROSOMW099 : VarBasis
        {
            /*"    03       PROSOM-DATA01     PIC  9(08).*/
            public IntBasis PROSOM_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    03       PROSOM-QTDIA      PIC S9(05)  COMP-3.*/
            public IntBasis PROSOM_QTDIA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(05)"));
            /*"    03       PROSOM-DATA02     PIC  9(08).*/
            public IntBasis PROSOM_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"01           EM0925W099.*/
        }
        public EM0010B_EM0925W099 EM0925W099 { get; set; } = new EM0010B_EM0925W099();
        public class EM0010B_EM0925W099 : VarBasis
        {
            /*"    03       EM0925-DATA01     PIC  9(008).*/
            public IntBasis EM0925_DATA01 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03       EM0925-DATA02     PIC  9(008).*/
            public IntBasis EM0925_DATA02 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    03       EM0925-QTMES      PIC S9(005)    COMP-3.*/
            public IntBasis EM0925_QTMES { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"01 PARAM-APORTE-CAIXA.*/
        }
        public EM0010B_PARAM_APORTE_CAIXA PARAM_APORTE_CAIXA { get; set; } = new EM0010B_PARAM_APORTE_CAIXA();
        public class EM0010B_PARAM_APORTE_CAIXA : VarBasis
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
        public EM0010B_TAB_IMPSEG TAB_IMPSEG { get; set; } = new EM0010B_TAB_IMPSEG();
        public class EM0010B_TAB_IMPSEG : VarBasis
        {
            /*"     10 TB-IMPSEG       PIC S9(10)V99 COMP-3 OCCURS    20 TIMES.*/
            public ListBasis<DoubleBasis, double> TB_IMPSEG { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "10", "S9(10)V99"), 20);
            /*"01 TAB-TAXAS     COMP-3.*/
        }
        public EM0010B_TAB_TAXAS TAB_TAXAS { get; set; } = new EM0010B_TAB_TAXAS();
        public class EM0010B_TAB_TAXAS : VarBasis
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
        private _REDEF_EM0010B_FILLER_26 _filler_26 { get; set; }
        public _REDEF_EM0010B_FILLER_26 FILLER_26
        {
            get { _filler_26 = new _REDEF_EM0010B_FILLER_26(); _.Move(W_NUMR_TITULO, _filler_26); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_26, W_NUMR_TITULO); _filler_26.ValueChanged += () => { _.Move(_filler_26, W_NUMR_TITULO); }; return _filler_26; }
            set { VarBasis.RedefinePassValue(value, _filler_26, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_EM0010B_FILLER_26 : VarBasis
        {
            /*"    03  WTITL-ZEROS             PIC  9(02).*/
            public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    03  WTITL-NRTITULO.*/
            public EM0010B_WTITL_NRTITULO WTITL_NRTITULO { get; set; } = new EM0010B_WTITL_NRTITULO();
            public class EM0010B_WTITL_NRTITULO : VarBasis
            {
                /*"     05 WTITL-SEQUENCIA         PIC  9(10).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                /*"     05 WTITL-DIGITO1           PIC  9(01).*/
                public IntBasis WTITL_DIGITO1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"01  CH-ENDOSSO                  PIC  X(01)    VALUE SPACES.*/

                public EM0010B_WTITL_NRTITULO()
                {
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO1.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_EM0010B_FILLER_26()
            {
                WTITL_ZEROS.ValueChanged += OnValueChanged;
                WTITL_NRTITULO.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis CH_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  CH-APOLCOSCED               PIC  X(01)    VALUE SPACES.*/
        public StringBasis CH_APOLCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  W.*/
        public EM0010B_W W { get; set; } = new EM0010B_W();
        public class EM0010B_W : VarBasis
        {
            /*"    05   WW-ORDEM-ORDE          PIC  9(15)    VALUE ZEROS.*/
            public IntBasis WW_ORDEM_ORDE { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"    05   FILLER                 REDEFINES     WW-ORDEM-ORDE.*/
            private _REDEF_EM0010B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_EM0010B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_EM0010B_FILLER_27(); _.Move(WW_ORDEM_ORDE, _filler_27); VarBasis.RedefinePassValue(WW_ORDEM_ORDE, _filler_27, WW_ORDEM_ORDE); _filler_27.ValueChanged += () => { _.Move(_filler_27, WW_ORDEM_ORDE); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WW_ORDEM_ORDE); }
            }  //Redefines
            public class _REDEF_EM0010B_FILLER_27 : VarBasis
            {
                /*"      10 WW-LIDER-ORDE          PIC  9(05).*/
                public IntBasis WW_LIDER_ORDE { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"      10 WW-ORGAO-ORDE          PIC  9(03).*/
                public IntBasis WW_ORGAO_ORDE { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WW-NRORD-ORDE          PIC  9(07).*/
                public IntBasis WW_NRORD_ORDE { get; set; } = new IntBasis(new PIC("9", "7", "9(07)."));
                /*"01              LPARM01X.*/

                public _REDEF_EM0010B_FILLER_27()
                {
                    WW_LIDER_ORDE.ValueChanged += OnValueChanged;
                    WW_ORGAO_ORDE.ValueChanged += OnValueChanged;
                    WW_NRORD_ORDE.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM0010B_LPARM01X LPARM01X { get; set; } = new EM0010B_LPARM01X();
        public class EM0010B_LPARM01X : VarBasis
        {
            /*"  03            LPARM01         PIC  9(010).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_EM0010B_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_EM0010B_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_EM0010B_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_EM0010B_LPARM01_R : VarBasis
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

                public _REDEF_EM0010B_LPARM01_R()
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
        public EM0010B_EM0901W099 EM0901W099 { get; set; } = new EM0010B_EM0901W099();
        public class EM0010B_EM0901W099 : VarBasis
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
            private _REDEF_EM0010B_W01A0077R _w01a0077r { get; set; }
            public _REDEF_EM0010B_W01A0077R W01A0077R
            {
                get { _w01a0077r = new _REDEF_EM0010B_W01A0077R(); _.Move(W01A0077, _w01a0077r); VarBasis.RedefinePassValue(W01A0077, _w01a0077r, W01A0077); _w01a0077r.ValueChanged += () => { _.Move(_w01a0077r, W01A0077); }; return _w01a0077r; }
                set { VarBasis.RedefinePassValue(value, _w01a0077r, W01A0077); }
            }  //Redefines
            public class _REDEF_EM0010B_W01A0077R : VarBasis
            {
                /*"     05         FILLER                 PIC  X(06).*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
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
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "51", "X(51)."), @"");
                /*"    03          NRRCAP                 PIC S9(09)       COMP.*/

                public _REDEF_EM0010B_W01A0077R()
                {
                    FILLER_28.ValueChanged += OnValueChanged;
                    W01A0077_VERSAO.ValueChanged += OnValueChanged;
                    W01A0077_TIPCOB.ValueChanged += OnValueChanged;
                    W01A0077_QTPARC.ValueChanged += OnValueChanged;
                    W01A0077_CODPRO.ValueChanged += OnValueChanged;
                    W01A0077_INIVIG.ValueChanged += OnValueChanged;
                    FILLER_29.ValueChanged += OnValueChanged;
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
        public EM0010B_FILLER_30 FILLER_30 { get; set; } = new EM0010B_FILLER_30();
        public class EM0010B_FILLER_30 : VarBasis
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
        public EM0010B_WS000_AREA_AUX_RAMO68 WS000_AREA_AUX_RAMO68 { get; set; } = new EM0010B_WS000_AREA_AUX_RAMO68();
        public class EM0010B_WS000_AREA_AUX_RAMO68 : VarBasis
        {
            /*"    03  WS000-IOF-RAMO68     PIC S9(015)V9(002) VALUE +0 COMP-3.*/
            public DoubleBasis WS000_IOF_RAMO68 { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(002)"), 2);
            /*"    03  WS000-IOF-RAMO68-IX  PIC S9(015)V9(002) VALUE +0 COMP-3.*/
            public DoubleBasis WS000_IOF_RAMO68_IX { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(015)V9(002)"), 2);
            /*"    03  WCH-APOL-HABIT       PIC  X(001)        VALUE 'N'.*/
            public StringBasis WCH_APOL_HABIT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"01 WS-NUM-IDLG.*/
        }
        public EM0010B_WS_NUM_IDLG WS_NUM_IDLG { get; set; } = new EM0010B_WS_NUM_IDLG();
        public class EM0010B_WS_NUM_IDLG : VarBasis
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
        private _REDEF_EM0010B_FILLER_31 _filler_31 { get; set; }
        public _REDEF_EM0010B_FILLER_31 FILLER_31
        {
            get { _filler_31 = new _REDEF_EM0010B_FILLER_31(); _.Move(WS_NOSSO_NUMERO_SAP, _filler_31); VarBasis.RedefinePassValue(WS_NOSSO_NUMERO_SAP, _filler_31, WS_NOSSO_NUMERO_SAP); _filler_31.ValueChanged += () => { _.Move(_filler_31, WS_NOSSO_NUMERO_SAP); }; return _filler_31; }
            set { VarBasis.RedefinePassValue(value, _filler_31, WS_NOSSO_NUMERO_SAP); }
        }  //Redefines
        public class _REDEF_EM0010B_FILLER_31 : VarBasis
        {
            /*"   10 WS-NOSSO-IDEN               PIC 9(04).*/
            public IntBasis WS_NOSSO_IDEN { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   10 WS-NOSSO-NR-TITULO          PIC 9(13).*/
            public IntBasis WS_NOSSO_NR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   10 WS-NOSSO-NR                 PIC 9(01).*/
            public IntBasis WS_NOSSO_NR { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));

            public _REDEF_EM0010B_FILLER_31()
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
        public Copies.LBLT3201 LBLT3201 { get; set; } = new Copies.LBLT3201();
        public Copies.LBLT3214 LBLT3214 { get; set; } = new Copies.LBLT3214();
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
        public Dclgens.LT028 LT028 { get; set; } = new Dclgens.LT028();
        public EM0010B_V0ENDOS V0ENDOS { get; set; } = new EM0010B_V0ENDOS();
        public EM0010B_V1COBERAPOL V1COBERAPOL { get; set; } = new EM0010B_V1COBERAPOL();
        public EM0010B_V0APOLCOS V0APOLCOS { get; set; } = new EM0010B_V0APOLCOS();
        public EM0010B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new EM0010B_V1RCAPCOMP();
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
            /*" -1591- DISPLAY 'EM0010B VERSAO V.68 - INICIO PROCESSAMENTO EM  ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"EM0010B VERSAO V.68 - INICIO PROCESSAMENTO EM  {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1593- PERFORM A0000-INICIO THRU A0000-999-EXIT. */

            A0000_INICIO_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: A0000_999_EXIT*/


            /*" -1596- PERFORM B0000-PROCESSA THRU B9999-999-EXIT UNTIL CH-ENDOSSO EQUAL '1' . */

            while (!(CH_ENDOSSO == "1"))
            {

                B0000_PROCESSA_SECTION();

                B0010_LEITURA();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B9999_999_EXIT*/

            }

            /*" -1598- PERFORM B4210-00-INCLUI-RELATORIO. */

            B4210_00_INCLUI_RELATORIO_SECTION();

            /*" -1599- IF CEDENTE-NUM-TITULO NOT EQUAL WSHOST-NRTIT13 */

            if (CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO != WSHOST_NRTIT13)
            {

                /*" -1600- MOVE 60 TO CEDENTE-COD-CEDENTE */
                _.Move(60, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -1602- MOVE WSHOST-NRTIT13 TO CEDENTE-NUM-TITULO */
                _.Move(WSHOST_NRTIT13, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

                /*" -1603- PERFORM R2060-00-ALTERA-V0CEDENTE */

                R2060_00_ALTERA_V0CEDENTE_SECTION();

                /*" -1605- END-IF */
            }


            /*" -1606- IF WSHOST-ORIG-FACIL NOT = WSHOST-TIT-FACIL */

            if (WSHOST_ORIG_FACIL != WSHOST_TIT_FACIL)
            {

                /*" -1607- MOVE WSHOST-TIT-FACIL TO CEDENTE-NUM-TITULO */
                _.Move(WSHOST_TIT_FACIL, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);

                /*" -1609- MOVE 59 TO CEDENTE-COD-CEDENTE */
                _.Move(59, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -1610- PERFORM R2060-00-ALTERA-V0CEDENTE */

                R2060_00_ALTERA_V0CEDENTE_SECTION();

                /*" -1612- END-IF */
            }


            /*" -1612- PERFORM C0000-FIM. */

            C0000_FIM_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_999_EXIT*/

        [StopWatch]
        /*" A0000-INICIO-SECTION */
        private void A0000_INICIO_SECTION()
        {
            /*" -1620- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1622- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1624- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1628- PERFORM A1000-LE-SISTEMA. */

            A1000_LE_SISTEMA_SECTION();

            /*" -1630- PERFORM A1100-OBTEM-VENCIMENTO-MINIMO */

            A1100_OBTEM_VENCIMENTO_MINIMO_SECTION();

            /*" -1632- PERFORM A1500-LE-V1PARAMRAMO. */

            A1500_LE_V1PARAMRAMO_SECTION();

            /*" -1634- PERFORM A1600-LE-V1PARAMETRO. */

            A1600_LE_V1PARAMETRO_SECTION();

            /*" -1636- MOVE 59 TO CEDENTE-COD-CEDENTE */
            _.Move(59, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -1638- PERFORM R0320-00-SELECT-V0CEDENTE. */

            R0320_00_SELECT_V0CEDENTE_SECTION();

            /*" -1640- MOVE WSHOST-NRTIT13 TO WSHOST-TIT-FACIL WSHOST-ORIG-FACIL */
            _.Move(WSHOST_NRTIT13, WSHOST_TIT_FACIL, WSHOST_ORIG_FACIL);

            /*" -1642- MOVE 60 TO CEDENTE-COD-CEDENTE. */
            _.Move(60, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

            /*" -1644- PERFORM R0320-00-SELECT-V0CEDENTE. */

            R0320_00_SELECT_V0CEDENTE_SECTION();

            /*" -1646- PERFORM R2000-DECLARE-V0ENDOSSO. */

            R2000_DECLARE_V0ENDOSSO_SECTION();

            /*" -1646- PERFORM A3000-LE-V0ENDOSSO. */

            A3000_LE_V0ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A0000_999_EXIT*/

        [StopWatch]
        /*" A1000-LE-SISTEMA-SECTION */
        private void A1000_LE_SISTEMA_SECTION()
        {
            /*" -1657- MOVE 'A1000' TO WNR-EXEC-SQL. */
            _.Move("A1000", WABEND.WNR_EXEC_SQL);

            /*" -1665- PERFORM A1000_LE_SISTEMA_DB_SELECT_1 */

            A1000_LE_SISTEMA_DB_SELECT_1();

            /*" -1668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1669- DISPLAY 'EM0010B - NAO HA MOVIMENTO ABERTO P/ EMISSAO' */
                _.Display($"EM0010B - NAO HA MOVIMENTO ABERTO P/ EMISSAO");

                /*" -1670- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1672- END-IF */
            }


            /*" -1678- PERFORM A1000_LE_SISTEMA_DB_SELECT_2 */

            A1000_LE_SISTEMA_DB_SELECT_2();

            /*" -1681- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1682- DISPLAY 'EM0010B - DATA NAO CADASTRADA SISTEMA CO' */
                _.Display($"EM0010B - DATA NAO CADASTRADA SISTEMA CO");

                /*" -1683- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1689- END-IF. */
            }


            /*" -1690- DISPLAY 'DATA DO SISTEMA EM: ' SIST-DTMOVABE ' SISTEMA CO: ' SIST-DTMOVABE-CO. */

            $"DATA DO SISTEMA EM: {SIST_DTMOVABE} SISTEMA CO: {SIST_DTMOVABE_CO}"
            .Display();

        }

        [StopWatch]
        /*" A1000-LE-SISTEMA-DB-SELECT-1 */
        public void A1000_LE_SISTEMA_DB_SELECT_1()
        {
            /*" -1665- EXEC SQL SELECT DTMOVABE ,CURRENT DATE INTO :SIST-DTMOVABE ,:WHOST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' WITH UR END-EXEC */

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
            /*" -1678- EXEC SQL SELECT DTMOVABE INTO :SIST-DTMOVABE-CO FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CO' WITH UR END-EXEC */

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
            /*" -1701- MOVE SIST-DTMOVABE-CO TO W-DATA-EDITADA */
            _.Move(SIST_DTMOVABE_CO, W_DATA_EDITADA);

            /*" -1702- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -1703- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -1704- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -1705- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -1706- MOVE 1 TO PROSOM-QTDIA */
            _.Move(1, PROSOMW099.PROSOM_QTDIA);

            /*" -1708- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -1710- CALL 'PROSOCU1' USING PROSOMW099 */
            _.Call("PROSOCU1", PROSOMW099);

            /*" -1711- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -1712- MOVE W-DD TO W-DIA */
            _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

            /*" -1713- MOVE W-MM TO W-MES */
            _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

            /*" -1714- MOVE W-AA TO W-ANO */
            _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

            /*" -1718- MOVE W-DATA-EDITADA TO W-DATA-MIN-1 */
            _.Move(W_DATA_EDITADA, W_DATA_MIN_1);

            /*" -1719- MOVE SIST-DTMOVABE-CO TO W-DATA-EDITADA */
            _.Move(SIST_DTMOVABE_CO, W_DATA_EDITADA);

            /*" -1720- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -1721- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -1722- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -1723- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -1724- MOVE 2 TO PROSOM-QTDIA */
            _.Move(2, PROSOMW099.PROSOM_QTDIA);

            /*" -1726- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -1728- CALL 'PROSOCU1' USING PROSOMW099 */
            _.Call("PROSOCU1", PROSOMW099);

            /*" -1729- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -1730- MOVE W-DD TO W-DIA */
            _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

            /*" -1731- MOVE W-MM TO W-MES */
            _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

            /*" -1732- MOVE W-AA TO W-ANO */
            _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

            /*" -1736- MOVE W-DATA-EDITADA TO W-DATA-MIN-2 */
            _.Move(W_DATA_EDITADA, W_DATA_MIN_2);

            /*" -1737- MOVE SIST-DTMOVABE-CO TO W-DATA-EDITADA */
            _.Move(SIST_DTMOVABE_CO, W_DATA_EDITADA);

            /*" -1738- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -1739- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -1740- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -1741- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -1742- MOVE 15 TO PROSOM-QTDIA */
            _.Move(15, PROSOMW099.PROSOM_QTDIA);

            /*" -1744- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -1746- CALL 'PROSOMC1' USING PROSOMW099 */
            _.Call("PROSOMC1", PROSOMW099);

            /*" -1747- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -1748- MOVE W-DD TO W-DIA */
            _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

            /*" -1749- MOVE W-MM TO W-MES */
            _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

            /*" -1750- MOVE W-AA TO W-ANO */
            _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

            /*" -1752- MOVE W-DATA-EDITADA TO W-DATA-MIN-15. */
            _.Move(W_DATA_EDITADA, W_DATA_MIN_15);

            /*" -1754- DISPLAY 'W-DATA-MIN-1: ' W-DATA-MIN-1 ' W-DATA-MIN-2 ' W-DATA-MIN-2 ' W-DATA-MIN-15 ' W-DATA-MIN-15. */

            $"W-DATA-MIN-1: {W_DATA_MIN_1} W-DATA-MIN-2 {W_DATA_MIN_2} W-DATA-MIN-15 {W_DATA_MIN_15}"
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A1100_999_EXIT*/

        [StopWatch]
        /*" A1500-LE-V1PARAMRAMO-SECTION */
        private void A1500_LE_V1PARAMRAMO_SECTION()
        {
            /*" -1765- MOVE 'A1500' TO WNR-EXEC-SQL. */
            _.Move("A1500", WABEND.WNR_EXEC_SQL);

            /*" -1774- PERFORM A1500_LE_V1PARAMRAMO_DB_SELECT_1 */

            A1500_LE_V1PARAMRAMO_DB_SELECT_1();

            /*" -1777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1778- DISPLAY 'EM0010B - NAO HA TABELA DE PARAMETROS/RAMO  ' */
                _.Display($"EM0010B - NAO HA TABELA DE PARAMETROS/RAMO  ");

                /*" -1778- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A1500-LE-V1PARAMRAMO-DB-SELECT-1 */
        public void A1500_LE_V1PARAMRAMO_DB_SELECT_1()
        {
            /*" -1774- EXEC SQL SELECT RAMO_VG, RAMO_AP, RAMO_VGAPC, RAMO_SAUDE, RAMO_EDUCACAO INTO :PARM-RAMO-VG, :PARM-RAMO-AP, :PARM-RAMO-VGAPC, :PARM-RAMO-SAUDE, :PARM-RAMO-PRESTA FROM SEGUROS.V1PARAMRAMO WITH UR END-EXEC. */

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
            /*" -1789- MOVE 'A1600' TO WNR-EXEC-SQL. */
            _.Move("A1600", WABEND.WNR_EXEC_SQL);

            /*" -1794- PERFORM A1600_LE_V1PARAMETRO_DB_SELECT_1 */

            A1600_LE_V1PARAMETRO_DB_SELECT_1();

            /*" -1797- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1798- DISPLAY 'EM0010B - NAO EXISTE V1PARAMETRO ' */
                _.Display($"EM0010B - NAO EXISTE V1PARAMETRO ");

                /*" -1798- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A1600-LE-V1PARAMETRO-DB-SELECT-1 */
        public void A1600_LE_V1PARAMETRO_DB_SELECT_1()
        {
            /*" -1794- EXEC SQL SELECT CODLIDER INTO :PARM-CODLIDER FROM SEGUROS.V1PARAMETRO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

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
            /*" -1809- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -1855- PERFORM R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1 */

            R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1();

            /*" -1857- PERFORM R2000_DECLARE_V0ENDOSSO_DB_OPEN_1 */

            R2000_DECLARE_V0ENDOSSO_DB_OPEN_1();

            /*" -1860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1861- DISPLAY 'R2000 - ERRO NO OPEN DA ENDOSSOS' */
                _.Display($"R2000 - ERRO NO OPEN DA ENDOSSOS");

                /*" -1861- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-DECLARE-V0ENDOSSO-DB-DECLARE-1 */
        public void R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1()
        {
            /*" -1855- EXEC SQL DECLARE V0ENDOS CURSOR FOR SELECT NUM_APOLICE ,NRENDOS ,CODSUBES ,FONTE ,NRPROPOS ,ORGAO ,RAMO ,DATPRO ,DATA_LIBERACAO ,DTEMIS ,DTINIVIG ,DTTERVIG ,PCENTRAD ,PCADICIO ,PCDESCON ,PRESTA1 ,QTPARCEL ,COD_MOEDA_PRM ,NRRCAP ,VLRCAP ,DATARCAP ,TIPO_ENDOSSO ,BCORCAP ,AGERCAP ,BCOCOBR ,AGECOBR ,ISENTA_CUSTO ,TIPAPO ,QTITENS ,CORRECAO ,DTVENCTO ,NUMBIL ,CODPRODU ,PODPUBL ,TIPSEGU ,VLCUSEMI ,COD_USUARIO ,CFPREFIX ,COD_EMPRESA FROM SEGUROS.V1ENDOSSO WHERE SITUACAO = ' ' AND NUM_APOLICE NOT IN (0106100000011 , 0106800000024) ORDER BY NUM_APOLICE, NRENDOS WITH UR END-EXEC. */
            V0ENDOS = new EM0010B_V0ENDOS(false);
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
							AND NUM_APOLICE NOT IN (0106100000011
							, 0106800000024) 
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
            /*" -1857- EXEC SQL OPEN V0ENDOS END-EXEC. */

            V0ENDOS.Open();

        }

        [StopWatch]
        /*" A4500-LE-COBERAPOL-DB-DECLARE-1 */
        public void A4500_LE_COBERAPOL_DB_DECLARE_1()
        {
            /*" -2185- EXEC SQL DECLARE V1COBERAPOL CURSOR FOR SELECT PRM_TARIFARIO_VAR ,PRM_TARIFARIO_IX FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND NUM_ITEM = 0 AND COD_COBERTURA = 0 WITH UR END-EXEC. */
            V1COBERAPOL = new EM0010B_V1COBERAPOL(true);
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
            /*" -1870- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM A3000_LE */

            A3000_LE();

        }

        [StopWatch]
        /*" A3000-LE */
        private void A3000_LE(bool isPerform = false)
        {
            /*" -1874- MOVE 'A3000' TO WNR-EXEC-SQL. */
            _.Move("A3000", WABEND.WNR_EXEC_SQL);

            /*" -1915- PERFORM A3000_LE_DB_FETCH_1 */

            A3000_LE_DB_FETCH_1();

            /*" -1918- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1918- PERFORM A3000_LE_DB_CLOSE_1 */

                A3000_LE_DB_CLOSE_1();

                /*" -1920- MOVE '1' TO CH-ENDOSSO */
                _.Move("1", CH_ENDOSSO);

                /*" -1922- GO TO A3999-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_999_EXIT*/ //GOTO
                return;
            }


            /*" -1923- IF VIND-VLCUSEMI LESS ZEROS */

            if (VIND_VLCUSEMI < 00)
            {

                /*" -1925- MOVE ZEROS TO ENDO-VLCUSEMI */
                _.Move(0, ENDO_VLCUSEMI);

                /*" -1927- IF ENDO-TIPSEGU NOT = '1' */

                if (ENDO_TIPSEGU != "1")
                {

                    /*" -1929- GO TO A3000-LE. */
                    new Task(() => A3000_LE()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1931- IF ENDO-ISECUSTO-I LESS ZEROS */

            if (ENDO_ISECUSTO_I < 00)
            {

                /*" -1933- MOVE SPACES TO ENDO-ISENTA-CUSTO. */
                _.Move("", ENDO_ISENTA_CUSTO);
            }


            /*" -1934- IF ENDO-DATARCAP-I LESS 0 */

            if (ENDO_DATARCAP_I < 0)
            {

                /*" -1936- MOVE -1 TO ENDO-DATARCAP-I */
                _.Move(-1, ENDO_DATARCAP_I);

                /*" -1938- MOVE SPACES TO ENDO-DATARCAP. */
                _.Move("", ENDO_DATARCAP);
            }


            /*" -1939- IF VIND-DTVENCTO LESS 0 */

            if (VIND_DTVENCTO < 0)
            {

                /*" -1941- MOVE -1 TO VIND-DTVENCTO */
                _.Move(-1, VIND_DTVENCTO);

                /*" -1943- MOVE SPACES TO ENDO-DTVENCTO. */
                _.Move("", ENDO_DTVENCTO);
            }


            /*" -1944- IF VIND-CODPRODU LESS 0 */

            if (VIND_CODPRODU < 0)
            {

                /*" -1945- MOVE -1 TO VIND-CODPRODU */
                _.Move(-1, VIND_CODPRODU);

                /*" -1947- MOVE ZEROS TO ENDO-CODPRODU. */
                _.Move(0, ENDO_CODPRODU);
            }


            /*" -1948- IF VIND-CFPREFIX LESS 0 */

            if (VIND_CFPREFIX < 0)
            {

                /*" -1949- MOVE -1 TO VIND-CFPREFIX */
                _.Move(-1, VIND_CFPREFIX);

                /*" -1951- MOVE ZEROS TO ENDO-CFPREFIX. */
                _.Move(0, ENDO_CFPREFIX);
            }


            /*" -1952- IF VIND-COD-EMPRESA LESS 0 */

            if (VIND_COD_EMPRESA < 0)
            {

                /*" -1953- MOVE -1 TO VIND-COD-EMPRESA */
                _.Move(-1, VIND_COD_EMPRESA);

                /*" -1955- MOVE ZEROS TO ENDO-COD-EMPRESA. */
                _.Move(0, ENDO_COD_EMPRESA);
            }


            /*" -1956- ADD 1 TO AC-COUNT. */
            AC_COUNT.Value = AC_COUNT + 1;

            /*" -1976- ADD 1 TO AC-L-V1ENDOSSO. */
            AC_L_V1ENDOSSO.Value = AC_L_V1ENDOSSO + 1;

            /*" -1976- PERFORM B1100-LE-V2RAMO. */

            B1100_LE_V2RAMO_SECTION();

        }

        [StopWatch]
        /*" A3000-LE-DB-FETCH-1 */
        public void A3000_LE_DB_FETCH_1()
        {
            /*" -1915- EXEC SQL FETCH V0ENDOS INTO :ENDO-NUM-APOLICE ,:ENDO-NRENDOS ,:ENDO-CODSUBES ,:ENDO-FONTE ,:ENDO-NRPROPOS ,:ENDO-ORGAO ,:ENDO-RAMO ,:ENDO-DATPRO ,:ENDO-DT-LIBERACAO ,:ENDO-DTEMIS ,:ENDO-DTINIVIG ,:ENDO-DTTERVIG ,:ENDO-PCENTRAD ,:ENDO-PCADICIO ,:ENDO-PCDESCON ,:ENDO-PRESTA1 ,:ENDO-QTPARCEL ,:ENDO-COD-MOEDA-PRM ,:ENDO-NRRCAP ,:ENDO-VLRCAP ,:ENDO-DATARCAP:ENDO-DATARCAP-I ,:ENDO-TIPO-ENDOSSO ,:ENDO-BCORCAP ,:ENDO-AGERCAP ,:ENDO-BCOCOBR ,:ENDO-AGECOBR ,:ENDO-ISENTA-CUSTO:ENDO-ISECUSTO-I ,:ENDO-TIPO-APOL ,:ENDO-QTITENS ,:ENDO-CORRECAO ,:ENDO-DTVENCTO:VIND-DTVENCTO ,:ENDO-NUMBIL ,:ENDO-CODPRODU:VIND-CODPRODU ,:ENDO-PODPUBL ,:ENDO-TIPSEGU ,:ENDO-VLCUSEMI:VIND-VLCUSEMI ,:ENDO-COD-USUARIO ,:ENDO-CFPREFIX :VIND-CFPREFIX ,:ENDO-COD-EMPRESA :VIND-COD-EMPRESA END-EXEC. */

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
            /*" -1918- EXEC SQL CLOSE V0ENDOS END-EXEC */

            V0ENDOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A3999_999_EXIT*/

        [StopWatch]
        /*" A3500-LE-SUBGRUPO-SECTION */
        private void A3500_LE_SUBGRUPO_SECTION()
        {
            /*" -1987- MOVE 'A3500' TO WNR-EXEC-SQL. */
            _.Move("A3500", WABEND.WNR_EXEC_SQL);

            /*" -1993- PERFORM A3500_LE_SUBGRUPO_DB_SELECT_1 */

            A3500_LE_SUBGRUPO_DB_SELECT_1();

            /*" -1996- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1996- MOVE '2' TO SUB-OPC-CORRETAGEM. */
                _.Move("2", SUB_OPC_CORRETAGEM);
            }


        }

        [StopWatch]
        /*" A3500-LE-SUBGRUPO-DB-SELECT-1 */
        public void A3500_LE_SUBGRUPO_DB_SELECT_1()
        {
            /*" -1993- EXEC SQL SELECT OPCAO_CORRETAGEM INTO :SUB-OPC-CORRETAGEM FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND COD_SUBGRUPO = :ENDO-CODSUBES WITH UR END-EXEC. */

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
            /*" -2007- MOVE 'A3510' TO WNR-EXEC-SQL. */
            _.Move("A3510", WABEND.WNR_EXEC_SQL);

            /*" -2016- PERFORM A3510_LE_RAMOIND_DB_SELECT_1 */

            A3510_LE_RAMOIND_DB_SELECT_1();

            /*" -2019- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2020- MOVE ZEROS TO RAMOIND-PCIOF. */
                _.Move(0, RAMOIND_PCIOF);
            }


        }

        [StopWatch]
        /*" A3510-LE-RAMOIND-DB-SELECT-1 */
        public void A3510_LE_RAMOIND_DB_SELECT_1()
        {
            /*" -2016- EXEC SQL SELECT PCIOF / 100 + 1 , PCIOF / 100 INTO :RAMOIND-PCIOF , :RAMO-PERC-IOF FROM SEGUROS.V0RAMOIND WHERE RAMO = :ENDO-RAMO AND DTINIVIG <= :SIST-DTMOVABE AND DTTERVIG >= :SIST-DTMOVABE WITH UR END-EXEC. */

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
            /*" -2086- MOVE 'A4000' TO WNR-EXEC-SQL. */
            _.Move("A4000", WABEND.WNR_EXEC_SQL);

            /*" -2111- PERFORM A4000_LE_APOLICE_DB_SELECT_1 */

            A4000_LE_APOLICE_DB_SELECT_1();

            /*" -2114- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2116- DISPLAY 'A4000- NAO EXISTE NA V1APOLICE' ' ' ENDO-NUM-APOLICE */

                $"A4000- NAO EXISTE NA V1APOLICE {ENDO_NUM_APOLICE}"
                .Display();

                /*" -2116- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A4000-LE-APOLICE-DB-SELECT-1 */
        public void A4000_LE_APOLICE_DB_SELECT_1()
        {
            /*" -2111- EXEC SQL SELECT CODCLIEN, NUM_APOLICE, MODALIDA, ORGAO, RAMO, TIPSGU, TIPAPO, TIPCALC, IDEMAN, PCDESCON, PCIOCC, TPCOSCED, QTCOSSEG, PCTCED, TPPESSOA INTO :APOL-COD-CLIENTE ,:APOL-NUM-APOLICE ,:APOL-MODALIDA ,:APOL-ORGAO ,:APOL-RAMO ,:APOL-TIPO-SEGURO ,:APOL-TIPO-APOLICE ,:APOL-TIPO-CALCULO ,:APOL-IND-ENDOS-MAN ,:APOL-PCDESCON ,:APOL-PCIOCC ,:APOL-TPCOSSEG ,:APOL-QTCOSSEG ,:APOL-PCCOSSEG ,:APOL-TIPO-PESSOA FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :ENDO-NUM-APOLICE WITH UR END-EXEC. */

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
            /*" -2127- MOVE 'A4100' TO WNR-EXEC-SQL. */
            _.Move("A4100", WABEND.WNR_EXEC_SQL);

            /*" -2136- PERFORM A4100_LE_PROPCOB_DB_SELECT_1 */

            A4100_LE_PROPCOB_DB_SELECT_1();

            /*" -2139- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2140- MOVE ' ' TO PRCB-TIPO-COBRANCA */
                _.Move(" ", PRCB_TIPO_COBRANCA);

                /*" -2142- MOVE ZEROS TO PRCB-DIA-DEBITO. */
                _.Move(0, PRCB_DIA_DEBITO);
            }


            /*" -2143- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -2144- MOVE PRCB-DIA-DEBITO TO W-DIA-DEBITO. */
                _.Move(PRCB_DIA_DEBITO, VENCIMENTOS.W_DIA_DEBITO);
            }


        }

        [StopWatch]
        /*" A4100-LE-PROPCOB-DB-SELECT-1 */
        public void A4100_LE_PROPCOB_DB_SELECT_1()
        {
            /*" -2136- EXEC SQL SELECT TIPO_COBRANCA ,DIA_DEBITO INTO :PRCB-TIPO-COBRANCA ,:PRCB-DIA-DEBITO FROM SEGUROS.V0PROPCOB WHERE FONTE = :ENDO-FONTE AND NRPROPOS = :ENDO-NRPROPOS WITH UR END-EXEC. */

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
            /*" -2154- MOVE 'A4200' TO WNR-EXEC-SQL. */
            _.Move("A4200", WABEND.WNR_EXEC_SQL);

            /*" -2161- PERFORM A4200_LE_AU085_DB_SELECT_1 */

            A4200_LE_AU085_DB_SELECT_1();

            /*" -2164- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2165- DISPLAY 'A4200- ERRO NO SELECT AU085' */
                _.Display($"A4200- ERRO NO SELECT AU085");

                /*" -2165- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" A4200-LE-AU085-DB-SELECT-1 */
        public void A4200_LE_AU085_DB_SELECT_1()
        {
            /*" -2161- EXEC SQL SELECT VALUE(IND_FORMA_PAGTO_AD, '0' ) INTO :AU085-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_PROPOSTA_COMPL WHERE COD_FONTE = :ENDO-FONTE AND NUM_PROPOSTA = :ENDO-NRPROPOS WITH UR END-EXEC. */

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
            /*" -2176- MOVE 'A4500' TO WNR-EXEC-SQL. */
            _.Move("A4500", WABEND.WNR_EXEC_SQL);

            /*" -2185- PERFORM A4500_LE_COBERAPOL_DB_DECLARE_1 */

            A4500_LE_COBERAPOL_DB_DECLARE_1();

            /*" -2187- PERFORM A4500_LE_COBERAPOL_DB_OPEN_1 */

            A4500_LE_COBERAPOL_DB_OPEN_1();

            /*" -2189- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2190- DISPLAY ' A4500- ERRO NO OPEN DA COBERAPOL' */
                _.Display($" A4500- ERRO NO OPEN DA COBERAPOL");

                /*" -2192- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2193- MOVE ZEROS TO COBE-TARIFARIO-VAR. */
            _.Move(0, COBE_TARIFARIO_VAR);

            /*" -2193- MOVE ZEROS TO COBE-TARIFARIO-IX. */
            _.Move(0, COBE_TARIFARIO_IX);

            /*" -0- FLUXCONTROL_PERFORM A4501_LE_V1COBERAPOL */

            A4501_LE_V1COBERAPOL();

        }

        [StopWatch]
        /*" A4500-LE-COBERAPOL-DB-OPEN-1 */
        public void A4500_LE_COBERAPOL_DB_OPEN_1()
        {
            /*" -2187- EXEC SQL OPEN V1COBERAPOL END-EXEC. */

            V1COBERAPOL.Open();

        }

        [StopWatch]
        /*" B0100-DECLARE-V0APOLCOSCED-DB-DECLARE-1 */
        public void B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1()
        {
            /*" -2678- EXEC SQL DECLARE V0APOLCOS CURSOR FOR SELECT CODCOSS FROM SEGUROS.V0APOLCOSCED WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG WITH UR END-EXEC. */
            V0APOLCOS = new EM0010B_V0APOLCOS(true);
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
            /*" -2199- MOVE 'A4501' TO WNR-EXEC-SQL. */
            _.Move("A4501", WABEND.WNR_EXEC_SQL);

            /*" -2202- PERFORM A4501_LE_V1COBERAPOL_DB_FETCH_1 */

            A4501_LE_V1COBERAPOL_DB_FETCH_1();

            /*" -2205- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2205- PERFORM A4501_LE_V1COBERAPOL_DB_CLOSE_1 */

                A4501_LE_V1COBERAPOL_DB_CLOSE_1();

                /*" -2208- GO TO A4500-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: A4500_999_EXIT*/ //GOTO
                return;
            }


            /*" -2209- ADD COBT-TARIFARIO-VAR TO COBE-TARIFARIO-VAR. */
            COBE_TARIFARIO_VAR.Value = COBE_TARIFARIO_VAR + COBT_TARIFARIO_VAR;

            /*" -2211- ADD COBT-TARIFARIO-IX TO COBE-TARIFARIO-IX. */
            COBE_TARIFARIO_IX.Value = COBE_TARIFARIO_IX + COBT_TARIFARIO_IX;

            /*" -2211- GO TO A4501-LE-V1COBERAPOL. */
            new Task(() => A4501_LE_V1COBERAPOL()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" A4501-LE-V1COBERAPOL-DB-FETCH-1 */
        public void A4501_LE_V1COBERAPOL_DB_FETCH_1()
        {
            /*" -2202- EXEC SQL FETCH V1COBERAPOL INTO :COBT-TARIFARIO-VAR, :COBT-TARIFARIO-IX END-EXEC. */

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
            /*" -2205- EXEC SQL CLOSE V1COBERAPOL END-EXEC */

            V1COBERAPOL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: A4500_999_EXIT*/

        [StopWatch]
        /*" A4600-LE-MR-APOL-COBER-SECTION */
        private void A4600_LE_MR_APOL_COBER_SECTION()
        {
            /*" -2246- MOVE 'A4600' TO WNR-EXEC-SQL. */
            _.Move("A4600", WABEND.WNR_EXEC_SQL);

            /*" -2257- PERFORM A4600_LE_MR_APOL_COBER_DB_SELECT_1 */

            A4600_LE_MR_APOL_COBER_DB_SELECT_1();

            /*" -2260- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2263- DISPLAY 'A4600- ERRO LE MR-APOL-ITEM' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $"A4600- ERRO LE MR-APOL-ITEM {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -2265- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2266- IF PCT-DESCONTO-TOTAL NOT EQUAL 0 */

            if (PCT_DESCONTO_TOTAL != 0)
            {

                /*" -2268- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR ENDO-TIPO-ENDOSSO EQUAL '1' */

                if (ENDO_TIPO_ENDOSSO == "0" || ENDO_TIPO_ENDOSSO == "1")
                {

                    /*" -2272- COMPUTE COBE-TARIFARIO-VAR = COBE-TARIFARIO-VAR * (1 - (PCT-DESCONTO-TOTAL / 100)) */
                    COBE_TARIFARIO_VAR.Value = COBE_TARIFARIO_VAR * (1 - (PCT_DESCONTO_TOTAL / 100f));

                    /*" -2275- COMPUTE COBE-TARIFARIO-IX = COBE-TARIFARIO-IX * (1 - (PCT-DESCONTO-TOTAL / 100)). */
                    COBE_TARIFARIO_IX.Value = COBE_TARIFARIO_IX * (1 - (PCT_DESCONTO_TOTAL / 100f));
                }

            }


        }

        [StopWatch]
        /*" A4600-LE-MR-APOL-COBER-DB-SELECT-1 */
        public void A4600_LE_MR_APOL_COBER_DB_SELECT_1()
        {
            /*" -2257- EXEC SQL SELECT VALUE(SUM(PCT_DESC_FIDEL + PCT_DESC_AGRUP + PCT_DESC_FUNC_PUBL + PCT_DESC_EXPER),0) INTO :PCT-DESCONTO-TOTAL FROM SEGUROS.MR_APOLICE_ITEM WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS AND NUM_ITEM = :ENDO-QTITENS WITH UR END-EXEC. */

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
            /*" -2286- MOVE 'A5000' TO WNR-EXEC-SQL. */
            _.Move("A5000", WABEND.WNR_EXEC_SQL);

            /*" -2295- PERFORM A5000_LE_APOLITEM_DB_SELECT_1 */

            A5000_LE_APOLITEM_DB_SELECT_1();

            /*" -2299- IF VIND-QTITENS LESS ZEROS OR VIND-TARIFARIO LESS ZEROS */

            if (VIND_QTITENS < 00 || VIND_TARIFARIO < 00)
            {

                /*" -2300- MOVE ZEROS TO APIT-QTITENS */
                _.Move(0, APIT_QTITENS);

                /*" -2302- MOVE ZEROS TO APIT-TARIFARIO-IX. */
                _.Move(0, APIT_TARIFARIO_IX);
            }


            /*" -2303- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2304- MOVE ZEROS TO APIT-QTITENS */
                _.Move(0, APIT_QTITENS);

                /*" -2304- MOVE ZEROS TO APIT-TARIFARIO-IX. */
                _.Move(0, APIT_TARIFARIO_IX);
            }


        }

        [StopWatch]
        /*" A5000-LE-APOLITEM-DB-SELECT-1 */
        public void A5000_LE_APOLITEM_DB_SELECT_1()
        {
            /*" -2295- EXEC SQL SELECT COUNT(*), SUM(PRM_TARIFARIO_IX) INTO :APIT-QTITENS:VIND-QTITENS, :APIT-TARIFARIO-IX:VIND-TARIFARIO FROM SEGUROS.V1APOLITEM WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND SITUACAO = '0' WITH UR END-EXEC. */

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
            /*" -2364- MOVE 'A6200' TO WNR-EXEC-SQL. */
            _.Move("A6200", WABEND.WNR_EXEC_SQL);

            /*" -2370- PERFORM A6200_000_LE_RCAP_DB_SELECT_1 */

            A6200_000_LE_RCAP_DB_SELECT_1();

            /*" -2373- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -2374- GO TO A6200-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/ //GOTO
                return;

                /*" -2375- ELSE */
            }
            else
            {


                /*" -2376- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2379- DISPLAY 'A6200 1 - RCAP NAO CADASTRADO ' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                    $"A6200 1 - RCAP NAO CADASTRADO  {ENDO_FONTE} {ENDO_NRRCAP}"
                    .Display();

                    /*" -2380- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2381- ELSE */
                }
                else
                {


                    /*" -2382- IF SQLCODE NOT EQUAL -810 AND -811 */

                    if (!DB.SQLCODE.In("-810", "-811"))
                    {

                        /*" -2385- DISPLAY 'A6200 1 - ERRO NO ACESSO A RCAP' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                        $"A6200 1 - ERRO NO ACESSO A RCAP {ENDO_FONTE} {ENDO_NRRCAP}"
                        .Display();

                        /*" -2386- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2387- ELSE */
                    }
                    else
                    {


                        /*" -2394- PERFORM A6200_000_LE_RCAP_DB_SELECT_2 */

                        A6200_000_LE_RCAP_DB_SELECT_2();

                        /*" -2396- IF SQLCODE EQUAL 0 */

                        if (DB.SQLCODE == 0)
                        {

                            /*" -2397- GO TO A6200-999-EXIT */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/ //GOTO
                            return;

                            /*" -2398- ELSE */
                        }
                        else
                        {


                            /*" -2399- IF SQLCODE NOT EQUAL 100 */

                            if (DB.SQLCODE != 100)
                            {

                                /*" -2402- DISPLAY 'A6200 2 - ERRO NO ACESSO A RCAP' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                                $"A6200 2 - ERRO NO ACESSO A RCAP {ENDO_FONTE} {ENDO_NRRCAP}"
                                .Display();

                                /*" -2403- GO TO 999-999-ROT-ERRO */

                                M_999_999_ROT_ERRO_SECTION(); //GOTO
                                return;

                                /*" -2404- ELSE */
                            }
                            else
                            {


                                /*" -2411- PERFORM A6200_000_LE_RCAP_DB_SELECT_3 */

                                A6200_000_LE_RCAP_DB_SELECT_3();

                                /*" -2413- IF SQLCODE EQUAL 0 */

                                if (DB.SQLCODE == 0)
                                {

                                    /*" -2414- GO TO A6200-999-EXIT */
                                    /*Método Suprimido por falta de linha ou apenas EXIT nome: A6200_999_EXIT*/ //GOTO
                                    return;

                                    /*" -2415- ELSE */
                                }
                                else
                                {


                                    /*" -2416- IF SQLCODE EQUAL 100 */

                                    if (DB.SQLCODE == 100)
                                    {

                                        /*" -2419- DISPLAY 'A6200 3 - RCAP NAO CADASTRADO ' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                                        $"A6200 3 - RCAP NAO CADASTRADO  {ENDO_FONTE} {ENDO_NRRCAP}"
                                        .Display();

                                        /*" -2420- GO TO 999-999-ROT-ERRO */

                                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                                        return;

                                        /*" -2421- ELSE */
                                    }
                                    else
                                    {


                                        /*" -2424- DISPLAY 'A6200 3 - ERRO NO ACESSO A RCAP' ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                                        $"A6200 3 - ERRO NO ACESSO A RCAP {ENDO_FONTE} {ENDO_NRRCAP}"
                                        .Display();

                                        /*" -2425- GO TO 999-999-ROT-ERRO. */

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
            /*" -2370- EXEC SQL SELECT NRTIT INTO :V0RCAP-NRTIT FROM SEGUROS.V0RCAP WHERE NRRCAP = :ENDO-NRRCAP WITH UR END-EXEC. */

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
            /*" -2394- EXEC SQL SELECT NRTIT INTO :V0RCAP-NRTIT FROM SEGUROS.V0RCAP WHERE FONTE = :ENDO-FONTE AND NRRCAP = :ENDO-NRRCAP WITH UR END-EXEC */

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
            /*" -2494- MOVE ZEROS TO RAMOIND-PCIOF. */
            _.Move(0, RAMOIND_PCIOF);

            /*" -2500- IF ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-SAUDE OR PARM-RAMO-PRESTA */

            if (ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_SAUDE.ToString(), PARM_RAMO_PRESTA.ToString()))
            {

                /*" -2502- PERFORM A3500-LE-SUBGRUPO. */

                A3500_LE_SUBGRUPO_SECTION();
            }


            /*" -2506- IF ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-PRESTA */

            if (ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_PRESTA.ToString()))
            {

                /*" -2515- PERFORM A3510-LE-RAMOIND. */

                A3510_LE_RAMOIND_SECTION();
            }


            /*" -2517- PERFORM A4000-LE-APOLICE. */

            A4000_LE_APOLICE_SECTION();

            /*" -2519- PERFORM A4100-LE-PROPCOB. */

            A4100_LE_PROPCOB_SECTION();

            /*" -2523- IF ((ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -2524- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -2525- PERFORM A4200-LE-AU085 */

                    A4200_LE_AU085_SECTION();

                    /*" -2526- ELSE */
                }
                else
                {


                    /*" -2527- MOVE '0' TO AU085-IND-FORMA-PAGTO-AD */
                    _.Move("0", AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);

                    /*" -2528- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

                    if (ENDO_TIPO_ENDOSSO == "4")
                    {

                        /*" -2529- MOVE ENDO-DTINIVIG TO ENDO-DTVENCTO */
                        _.Move(ENDO_DTINIVIG, ENDO_DTVENCTO);

                        /*" -2530- ELSE */
                    }
                    else
                    {


                        /*" -2532- MOVE SIST-DTMOVABE TO ENDO-DTVENCTO. */
                        _.Move(SIST_DTMOVABE, ENDO_DTVENCTO);
                    }

                }

            }


            /*" -2537- PERFORM A4500-LE-COBERAPOL. */

            A4500_LE_COBERAPOL_SECTION();

            /*" -2538- IF ENDO-CODPRODU EQUAL 1403 OR 1404 */

            if (ENDO_CODPRODU.In("1403", "1404"))
            {

                /*" -2549- PERFORM A4600-LE-MR-APOL-COBER. */

                A4600_LE_MR_APOL_COBER_SECTION();
            }


            /*" -2550- IF APOL-QTCOSSEG NOT EQUAL ZEROS */

            if (APOL_QTCOSSEG != 00)
            {

                /*" -2552- MOVE ' ' TO CH-APOLCOSCED */
                _.Move(" ", CH_APOLCOSCED);

                /*" -2553- PERFORM B0100-DECLARE-V0APOLCOSCED */

                B0100_DECLARE_V0APOLCOSCED_SECTION();

                /*" -2554- PERFORM B0200-FETCH-V0APOLCOSCED */

                B0200_FETCH_V0APOLCOSCED_SECTION();

                /*" -2556- PERFORM B1000-GRAVA-V0ORDECOSCED THRU B1000-999-EXIT UNTIL CH-APOLCOSCED EQUAL '1' */

                while (!(CH_APOLCOSCED == "1"))
                {

                    B1000_GRAVA_V0ORDECOSCED_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: B1000_999_EXIT*/

                }

                /*" -2558- END-IF */
            }


            /*" -2559- MOVE ENDO-COD-MOEDA-PRM TO COD-MOEDA. */
            _.Move(ENDO_COD_MOEDA_PRM, EM0901W099.COD_MOEDA);

            /*" -2561- MOVE ENDO-ISENTA-CUSTO TO ISENTA-CUSTO. */
            _.Move(ENDO_ISENTA_CUSTO, EM0901W099.ISENTA_CUSTO);

            /*" -2562- MOVE ENDO-QTPARCEL TO QTPARCEL. */
            _.Move(ENDO_QTPARCEL, EM0901W099.QTPARCEL);

            /*" -2564- MOVE COBE-TARIFARIO-VAR TO VL-PREMIO-BASE. */
            _.Move(COBE_TARIFARIO_VAR, EM0901W099.VL_PREMIO_BASE);

            /*" -2565- IF ENDO-TIPO-APOL EQUAL '6' */

            if (ENDO_TIPO_APOL == "6")
            {

                /*" -2566- MOVE ENDO-DTTERVIG TO W-DATA-EDITADA */
                _.Move(ENDO_DTTERVIG, W_DATA_EDITADA);

                /*" -2568- MOVE 01 TO W-DIA */
                _.Move(01, W_DATA_EDITADA.W_DIA);

                /*" -2569- IF W-MES EQUAL 12 */

                if (W_DATA_EDITADA.W_MES == 12)
                {

                    /*" -2570- MOVE 01 TO W-MES */
                    _.Move(01, W_DATA_EDITADA.W_MES);

                    /*" -2571- ADD 1 TO W-ANO */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                    /*" -2572- ELSE */
                }
                else
                {


                    /*" -2573- ADD 1 TO W-MES */
                    W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                    /*" -2574- ELSE */
                }

            }
            else
            {


                /*" -2580- IF ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-SAUDE OR PARM-RAMO-PRESTA */

                if (ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_SAUDE.ToString(), PARM_RAMO_PRESTA.ToString()))
                {

                    /*" -2581- IF ENDO-CODPRODU EQUAL 80 */

                    if (ENDO_CODPRODU == 80)
                    {

                        /*" -2582- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                        _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                        /*" -2583- ELSE */
                    }
                    else
                    {


                        /*" -2584- IF ENDO-NRRCAP GREATER ZEROS */

                        if (ENDO_NRRCAP > 00)
                        {

                            /*" -2585- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                            _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                            /*" -2586- ELSE */
                        }
                        else
                        {


                            /*" -2587- IF ENDO-DTVENCTO GREATER ENDO-DTTERVIG */

                            if (ENDO_DTVENCTO > ENDO_DTTERVIG)
                            {

                                /*" -2588- MOVE ENDO-DTTERVIG TO W-DATA-EDITADA */
                                _.Move(ENDO_DTTERVIG, W_DATA_EDITADA);

                                /*" -2589- MOVE W-DIA TO W-DD */
                                _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

                                /*" -2590- MOVE W-MES TO W-MM */
                                _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

                                /*" -2591- MOVE W-ANO TO W-AA */
                                _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

                                /*" -2592- MOVE W-DATA TO PROSOM-DATA01 */
                                _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

                                /*" -2593- MOVE 1 TO PROSOM-QTDIA */
                                _.Move(1, PROSOMW099.PROSOM_QTDIA);

                                /*" -2594- MOVE ZEROS TO PROSOM-DATA02 */
                                _.Move(0, PROSOMW099.PROSOM_DATA02);

                                /*" -2595- CALL 'PROSOCU1' USING PROSOMW099 */
                                _.Call("PROSOCU1", PROSOMW099);

                                /*" -2596- MOVE PROSOM-DATA02 TO W-DATA */
                                _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

                                /*" -2597- MOVE W-DD TO W-DIA */
                                _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

                                /*" -2598- MOVE W-MM TO W-MES */
                                _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

                                /*" -2599- MOVE W-AA TO W-ANO */
                                _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

                                /*" -2600- ELSE */
                            }
                            else
                            {


                                /*" -2601- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                                _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                                /*" -2602- ELSE */
                            }

                        }

                    }

                }
                else
                {


                    /*" -2604- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA. */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);
                }

            }


            /*" -2612- MOVE W-DATA-EDITADA TO DTINIVIG */
            _.Move(W_DATA_EDITADA, EM0901W099.DTINIVIG);

            /*" -2613- IF ENDO-DTVENCTO NOT EQUAL SPACES */

            if (!ENDO_DTVENCTO.IsEmpty())
            {

                /*" -2614- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                /*" -2615- MOVE W-DIA TO W-DIA-BASE */
                _.Move(W_DATA_EDITADA.W_DIA, W_DIA_BASE);

                /*" -2616- ELSE */
            }
            else
            {


                /*" -2617- IF PRCB-DIA-DEBITO NOT EQUAL ZEROS */

                if (PRCB_DIA_DEBITO != 00)
                {

                    /*" -2618- MOVE PRCB-DIA-DEBITO TO W-DIA-BASE */
                    _.Move(PRCB_DIA_DEBITO, W_DIA_BASE);

                    /*" -2619- ELSE */
                }
                else
                {


                    /*" -2620- IF ENDO-NRRCAP GREATER ZEROS */

                    if (ENDO_NRRCAP > 00)
                    {

                        /*" -2621- MOVE ENDO-DATARCAP TO W-DATA-EDITADA */
                        _.Move(ENDO_DATARCAP, W_DATA_EDITADA);

                        /*" -2622- MOVE W-DIA TO W-DIA-BASE */
                        _.Move(W_DATA_EDITADA.W_DIA, W_DIA_BASE);

                        /*" -2623- ELSE */
                    }
                    else
                    {


                        /*" -2624- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                        _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                        /*" -2628- MOVE W-DIA TO W-DIA-BASE. */
                        _.Move(W_DATA_EDITADA.W_DIA, W_DIA_BASE);
                    }

                }

            }


            /*" -2629- IF APOL-RAMO EQUAL 32 */

            if (APOL_RAMO == 32)
            {

                /*" -2630- IF APOL-MODALIDA EQUAL 0 OR 2 OR 3 */

                if (APOL_MODALIDA.In("0", "2", "3"))
                {

                    /*" -2631- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                    /*" -2632- ELSE */
                }
                else
                {


                    /*" -2633- MOVE SIST-DTMOVABE TO W-DATA-EDITADA */
                    _.Move(SIST_DTMOVABE, W_DATA_EDITADA);

                    /*" -2634- ELSE */
                }

            }
            else
            {


                /*" -2635- IF VIND-DTVENCTO EQUAL -1 */

                if (VIND_DTVENCTO == -1)
                {

                    /*" -2636- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                    /*" -2637- ELSE */
                }
                else
                {


                    /*" -2639- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);
                }

            }


            /*" -2641- MOVE ENDO-QTPARCEL TO QTPARCEL. */
            _.Move(ENDO_QTPARCEL, EM0901W099.QTPARCEL);

            /*" -2642- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -2643- MOVE 0 TO W-PARCEL */
                _.Move(0, W_PARCEL);

                /*" -2644- ELSE */
            }
            else
            {


                /*" -2646- MOVE 1 TO W-PARCEL. */
                _.Move(1, W_PARCEL);
            }


            /*" -2652- MOVE 'N' TO WCH-APOL-HABIT. */
            _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

            /*" -2655- PERFORM B2000-GRAVA-PARCELA UNTIL W-PARCEL GREATER ENDO-QTPARCEL. */

            while (!(W_PARCEL > ENDO_QTPARCEL))
            {

                B2000_GRAVA_PARCELA_SECTION();
            }

            /*" -2655- PERFORM B4000-ATUALIZA-ENDOSSO. */

            B4000_ATUALIZA_ENDOSSO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM B0010_LEITURA */

            B0010_LEITURA();

        }

        [StopWatch]
        /*" A6200-000-LE-RCAP-DB-SELECT-3 */
        public void A6200_000_LE_RCAP_DB_SELECT_3()
        {
            /*" -2411- EXEC SQL SELECT NRTIT INTO :V0RCAP-NRTIT FROM SEGUROS.V0RCAP WHERE FONTE = 010 AND NRRCAP = :ENDO-NRRCAP WITH UR END-EXEC */

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
            /*" -2659- PERFORM A3000-LE-V0ENDOSSO. */

            A3000_LE_V0ENDOSSO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B9999_999_EXIT*/

        [StopWatch]
        /*" B0100-DECLARE-V0APOLCOSCED-SECTION */
        private void B0100_DECLARE_V0APOLCOSCED_SECTION()
        {
            /*" -2671- MOVE 'B0100' TO WNR-EXEC-SQL */
            _.Move("B0100", WABEND.WNR_EXEC_SQL);

            /*" -2678- PERFORM B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1 */

            B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1();

            /*" -2680- PERFORM B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1 */

            B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1();

            /*" -2682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2683- DISPLAY ' B0100- ERRO NO OPEN DA APOLCOS ' */
                _.Display($" B0100- ERRO NO OPEN DA APOLCOS ");

                /*" -2684- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2684- END-IF. */
            }


        }

        [StopWatch]
        /*" B0100-DECLARE-V0APOLCOSCED-DB-OPEN-1 */
        public void B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1()
        {
            /*" -2680- EXEC SQL OPEN V0APOLCOS END-EXEC. */

            V0APOLCOS.Open();

        }

        [StopWatch]
        /*" B2200-020-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -6874- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE, NRRCAP, NRRCAPCO, OPERACAO, DTMOVTO, HORAOPER, SITUACAO, BCOAVISO, AGEAVISO, NRAVISO, VLRCAP, DATARCAP, DTCADAST, SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND SITUACAO = '0' WITH UR END-EXEC. */
            V1RCAPCOMP = new EM0010B_V1RCAPCOMP(true);
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
            /*" -2695- MOVE 'B0200' TO WNR-EXEC-SQL. */
            _.Move("B0200", WABEND.WNR_EXEC_SQL);

            /*" -2697- PERFORM B0200_FETCH_V0APOLCOSCED_DB_FETCH_1 */

            B0200_FETCH_V0APOLCOSCED_DB_FETCH_1();

            /*" -2700- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2701- MOVE '1' TO CH-APOLCOSCED */
                _.Move("1", CH_APOLCOSCED);

                /*" -2701- PERFORM B0200_FETCH_V0APOLCOSCED_DB_CLOSE_1 */

                B0200_FETCH_V0APOLCOSCED_DB_CLOSE_1();

                /*" -2702- END-IF. */
            }


        }

        [StopWatch]
        /*" B0200-FETCH-V0APOLCOSCED-DB-FETCH-1 */
        public void B0200_FETCH_V0APOLCOSCED_DB_FETCH_1()
        {
            /*" -2697- EXEC SQL FETCH V0APOLCOS INTO :COSS-CODCOSS END-EXEC. */

            if (V0APOLCOS.Fetch())
            {
                _.Move(V0APOLCOS.COSS_CODCOSS, COSS_CODCOSS);
            }

        }

        [StopWatch]
        /*" B0200-FETCH-V0APOLCOSCED-DB-CLOSE-1 */
        public void B0200_FETCH_V0APOLCOSCED_DB_CLOSE_1()
        {
            /*" -2701- EXEC SQL CLOSE V0APOLCOS END-EXEC */

            V0APOLCOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B0200_999_EXIT*/

        [StopWatch]
        /*" B1000-GRAVA-V0ORDECOSCED-SECTION */
        private void B1000_GRAVA_V0ORDECOSCED_SECTION()
        {
            /*" -2713- PERFORM B1050-LE-NUMERO-COSCED. */

            B1050_LE_NUMERO_COSCED_SECTION();

            /*" -2716- COMPUTE NORD-NRORDEM = NUME-NRORDEM + 1. */
            NORD_NRORDEM.Value = NUME_NRORDEM + 1;

            /*" -2717- MOVE COSS-CODCOSS TO WW-LIDER-ORDE. */
            _.Move(COSS_CODCOSS, W.FILLER_27.WW_LIDER_ORDE);

            /*" -2718- MOVE ENDO-ORGAO TO WW-ORGAO-ORDE. */
            _.Move(ENDO_ORGAO, W.FILLER_27.WW_ORGAO_ORDE);

            /*" -2719- MOVE NORD-NRORDEM TO WW-NRORD-ORDE. */
            _.Move(NORD_NRORDEM, W.FILLER_27.WW_NRORD_ORDE);

            /*" -2721- MOVE WW-ORDEM-ORDE TO WORD-NRORDEM. */
            _.Move(W.WW_ORDEM_ORDE, WORD_NRORDEM);

            /*" -2723- PERFORM B1060-ATU-NUMERO-COSCED. */

            B1060_ATU_NUMERO_COSCED_SECTION();

            /*" -2724- MOVE ENDO-NRENDOS TO NORD-NRENDOS. */
            _.Move(ENDO_NRENDOS, NORD_NRENDOS);

            /*" -2725- MOVE ENDO-NUM-APOLICE TO NORD-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, NORD_NUM_APOLICE);

            /*" -2726- MOVE -1 TO NORD-EMPRESA-I. */
            _.Move(-1, NORD_EMPRESA_I);

            /*" -2728- MOVE COSS-CODCOSS TO NORD-CODCOSS. */
            _.Move(COSS_CODCOSS, NORD_CODCOSS);

            /*" -2730- MOVE 'B1000' TO WNR-EXEC-SQL. */
            _.Move("B1000", WABEND.WNR_EXEC_SQL);

            /*" -2736- PERFORM B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1 */

            B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1();

            /*" -2739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2740- DISPLAY 'EM0010B - ERRO INSERT V0ORDECOSCED ------------' */
                _.Display($"EM0010B - ERRO INSERT V0ORDECOSCED ------------");

                /*" -2741- DISPLAY 'NUM_APOLICE  = ' NORD-NUM-APOLICE */
                _.Display($"NUM_APOLICE  = {NORD_NUM_APOLICE}");

                /*" -2742- DISPLAY 'NRENDOS      = ' NORD-NRENDOS */
                _.Display($"NRENDOS      = {NORD_NRENDOS}");

                /*" -2743- DISPLAY 'CODCOSS      = ' NORD-CODCOSS */
                _.Display($"CODCOSS      = {NORD_CODCOSS}");

                /*" -2744- DISPLAY 'ORDEM_CEDIDO = ' WORD-NRORDEM */
                _.Display($"ORDEM_CEDIDO = {WORD_NRORDEM}");

                /*" -2745- DISPLAY 'COD_EMPRESA  = ' NORD-COD-EMPRESA */
                _.Display($"COD_EMPRESA  = {NORD_COD_EMPRESA}");

                /*" -2746- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -2748- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2750- ADD 1 TO AC-I-V0ORDCOSCED. */
            AC_I_V0ORDCOSCED.Value = AC_I_V0ORDCOSCED + 1;

            /*" -2751- MOVE 'EM0103B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0103B1", V0EDIA_CODRELAT);

            /*" -2752- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -2753- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -2754- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -2755- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -2756- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -2757- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -2758- MOVE ZEROS TO V0EDIA-FONTE. */
            _.Move(0, V0EDIA_FONTE);

            /*" -2759- MOVE COSS-CODCOSS TO V0EDIA-CONGENER. */
            _.Move(COSS_CODCOSS, V0EDIA_CONGENER);

            /*" -2760- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -2762- MOVE NORD-EMPRESA-I TO V0EDIA-COD-EMP. */
            _.Move(NORD_EMPRESA_I, V0EDIA_COD_EMP);

            /*" -2765- PERFORM B4200-INCLUI-V0EMISDIARIA. */

            B4200_INCLUI_V0EMISDIARIA_SECTION();

            /*" -2767- IF ENDO-RAMO EQUAL 31 OR 53 NEXT SENTENCE */

            if (ENDO_RAMO.In("31", "53"))
            {

                /*" -2768- ELSE */
            }
            else
            {


                /*" -2769- MOVE ENDO-FONTE TO V0EDIA-FONTE */
                _.Move(ENDO_FONTE, V0EDIA_FONTE);

                /*" -2770- MOVE 'EM0105B1' TO V0EDIA-CODRELAT */
                _.Move("EM0105B1", V0EDIA_CODRELAT);

                /*" -2772- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -2772- PERFORM B0200-FETCH-V0APOLCOSCED. */

            B0200_FETCH_V0APOLCOSCED_SECTION();

        }

        [StopWatch]
        /*" B1000-GRAVA-V0ORDECOSCED-DB-INSERT-1 */
        public void B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1()
        {
            /*" -2736- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:NORD-NUM-APOLICE, :NORD-NRENDOS, :NORD-CODCOSS , :WORD-NRORDEM, :NORD-COD-EMPRESA:NORD-EMPRESA-I, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2783- MOVE 'B1050' TO WNR-EXEC-SQL. */
            _.Move("B1050", WABEND.WNR_EXEC_SQL);

            /*" -2790- PERFORM B1050_LE_NUMERO_COSCED_DB_SELECT_1 */

            B1050_LE_NUMERO_COSCED_DB_SELECT_1();

            /*" -2793- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2798- DISPLAY 'NAO EXISTE NA V1NUMERO_COSSEGURO ... ' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS ' ' ENDO-ORGAO ' ' COSS-CODCOSS */

                $"NAO EXISTE NA V1NUMERO_COSSEGURO ...  {ENDO_NUM_APOLICE} {ENDO_NRENDOS} {ENDO_ORGAO} {COSS_CODCOSS}"
                .Display();

                /*" -2798- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B1050-LE-NUMERO-COSCED-DB-SELECT-1 */
        public void B1050_LE_NUMERO_COSCED_DB_SELECT_1()
        {
            /*" -2790- EXEC SQL SELECT NRORDEM INTO :NUME-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :ENDO-ORGAO AND CONGENER = :COSS-CODCOSS WITH UR END-EXEC. */

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
            /*" -2809- MOVE 'B1060' TO WNR-EXEC-SQL. */
            _.Move("B1060", WABEND.WNR_EXEC_SQL);

            /*" -2815- PERFORM B1060_ATU_NUMERO_COSCED_DB_UPDATE_1 */

            B1060_ATU_NUMERO_COSCED_DB_UPDATE_1();

            /*" -2818- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2820- DISPLAY 'ERRO ACESSO V0NUMERO_COSSEGURO ' ENDO-ORGAO ' ' COSS-CODCOSS */

                $"ERRO ACESSO V0NUMERO_COSSEGURO {ENDO_ORGAO} {COSS_CODCOSS}"
                .Display();

                /*" -2820- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B1060-ATU-NUMERO-COSCED-DB-UPDATE-1 */
        public void B1060_ATU_NUMERO_COSCED_DB_UPDATE_1()
        {
            /*" -2815- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :NORD-NRORDEM, TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :ENDO-ORGAO AND CONGENER = :COSS-CODCOSS END-EXEC. */

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
            /*" -2831- MOVE 'B1100' TO WNR-EXEC-SQL. */
            _.Move("B1100", WABEND.WNR_EXEC_SQL);

            /*" -2840- PERFORM B1100_LE_V2RAMO_DB_SELECT_1 */

            B1100_LE_V2RAMO_DB_SELECT_1();

            /*" -2843- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2845- DISPLAY 'EM0010B - RAMO NAO CADASTRADO NA V2RAMO ... ' ' ' ENDO-RAMO */

                $"EM0010B - RAMO NAO CADASTRADO NA V2RAMO ...  {ENDO_RAMO}"
                .Display();

                /*" -2845- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B1100-LE-V2RAMO-DB-SELECT-1 */
        public void B1100_LE_V2RAMO_DB_SELECT_1()
        {
            /*" -2840- EXEC SQL SELECT TIPOFRAC INTO :RAMO-TIPOFRAC FROM SEGUROS.V2RAMO WHERE RAMO = :ENDO-RAMO AND MODALIDA = 0 AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG WITH UR END-EXEC. */

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
            /*" -2855- MOVE ENDO-RAMO TO RAMO. */
            _.Move(ENDO_RAMO, EM0901W099.RAMO);

            /*" -2856- MOVE W-PARCEL TO NRPARCEL. */
            _.Move(W_PARCEL, EM0901W099.NRPARCEL);

            /*" -2857- MOVE ENDO-PCENTRAD TO PCENTRAD. */
            _.Move(ENDO_PCENTRAD, EM0901W099.PCENTRAD);

            /*" -2858- MOVE ENDO-PCADICIO TO PCJUROS. */
            _.Move(ENDO_PCADICIO, EM0901W099.PCJUROS);

            /*" -2860- MOVE ENDO-PCDESCON TO PCDESCON. */
            _.Move(ENDO_PCDESCON, EM0901W099.PCDESCON);

            /*" -2863- IF ((RAMO-TIPOFRAC EQUAL '2' ) AND (ENDO-CODPRODU NOT EQUAL 98) AND (ENDO-PCADICIO GREATER 0)) */

            if (((RAMO_TIPOFRAC == "2") && (ENDO_CODPRODU != 98) && (ENDO_PCADICIO > 0)))
            {

                /*" -2864- MOVE 'S' TO IND-FRAC */
                _.Move("S", EM0901W099.IND_FRAC);

                /*" -2865- MOVE COBE-TARIFARIO-VAR TO VL-PREMIO-BASE */
                _.Move(COBE_TARIFARIO_VAR, EM0901W099.VL_PREMIO_BASE);

                /*" -2866- ELSE */
            }
            else
            {


                /*" -2870- MOVE 'N' TO IND-FRAC. */
                _.Move("N", EM0901W099.IND_FRAC);
            }


            /*" -2871- IF ENDO-CODPRODU EQUAL 6700 OR 6701 */

            if (ENDO_CODPRODU.In("6700", "6701"))
            {

                /*" -2872- PERFORM R5000-00-LE-PCIOCC */

                R5000_00_LE_PCIOCC_SECTION();

                /*" -2873- MOVE V1RAMO-PCIOF TO PCIOF */
                _.Move(V1RAMO_PCIOF, EM0901W099.PCIOF);

                /*" -2874- ELSE */
            }
            else
            {


                /*" -2875- MOVE APOL-PCIOCC TO PCIOF */
                _.Move(APOL_PCIOCC, EM0901W099.PCIOF);

                /*" -2879- END-IF. */
            }


            /*" -2880- IF ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' */

            if (ENDO_TIPO_ENDOSSO.In("3", "5"))
            {

                /*" -2881- MOVE ZEROS TO PCIOF */
                _.Move(0, EM0901W099.PCIOF);

                /*" -2883- MOVE 'N' TO WCH-APOL-HABIT */
                _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                /*" -2884- IF ENDO-NUM-APOLICE EQUAL 0106800000007 OR 0106500000001 */

                if (ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -2885- MOVE 'S' TO WCH-APOL-HABIT */
                    _.Move("S", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                    /*" -2886- PERFORM B2040-SELECT-V0APOL-HABIT */

                    B2040_SELECT_V0APOL_HABIT_SECTION();

                    /*" -2888- END-IF */
                }


                /*" -2889- IF ENDO-NUM-APOLICE EQUAL 0106800000007 OR 0106500000001 */

                if (ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -2890- MOVE ZEROS TO PCIOF */
                    _.Move(0, EM0901W099.PCIOF);

                    /*" -2891- PERFORM B2081-SELECT-V0PREMIO-HAB */

                    B2081_SELECT_V0PREMIO_HAB_SECTION();

                    /*" -2893- END-IF */
                }


                /*" -2895- MOVE ENDO-DTINIVIG TO WHOST-DTINIVIG */
                _.Move(ENDO_DTINIVIG, WHOST_DTINIVIG);

                /*" -2897- PERFORM B2500-LE-MOEDA */

                B2500_LE_MOEDA_SECTION();

                /*" -2899- COMPUTE WS000-IOF-RAMO68-IX ROUNDED = WS000-IOF-RAMO68 / MOED-VALOR */
                WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68_IX.Value = WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68 / MOED_VALOR;

                /*" -2900- ELSE */
            }
            else
            {


                /*" -2902- MOVE 'N' TO WCH-APOL-HABIT */
                _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                /*" -2904- IF ENDO-NUM-APOLICE EQUAL 0106800000007 OR 0106500000001 */

                if (ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -2905- MOVE 'S' TO WCH-APOL-HABIT */
                    _.Move("S", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                    /*" -2906- PERFORM B2040-SELECT-V0APOL-HABIT */

                    B2040_SELECT_V0APOL_HABIT_SECTION();

                    /*" -2908- END-IF */
                }


                /*" -2909- IF ENDO-NUM-APOLICE EQUAL 106800000007 OR 106500000001 */

                if (ENDO_NUM_APOLICE.In("106800000007", "106500000001"))
                {

                    /*" -2910- MOVE ZEROS TO PCIOF */
                    _.Move(0, EM0901W099.PCIOF);

                    /*" -2911- PERFORM B2080-SELECT-V0PREMIO-HAB */

                    B2080_SELECT_V0PREMIO_HAB_SECTION();

                    /*" -2913- END-IF */
                }


                /*" -2915- MOVE ENDO-DTINIVIG TO WHOST-DTINIVIG */
                _.Move(ENDO_DTINIVIG, WHOST_DTINIVIG);

                /*" -2917- PERFORM B2500-LE-MOEDA */

                B2500_LE_MOEDA_SECTION();

                /*" -2920- COMPUTE WS000-IOF-RAMO68-IX ROUNDED = WS000-IOF-RAMO68 / MOED-VALOR. */
                WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68_IX.Value = WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68 / MOED_VALOR;
            }


            /*" -2922- MOVE ENDO-NRRCAP TO NRRCAP */
            _.Move(ENDO_NRRCAP, EM0901W099.NRRCAP);

            /*" -2939- MOVE ZEROS TO VL-DESC-IX VL-LIQ-IX VL-TARIFARIO-IX VL-ADIC-IX VL-CUSTO-IX VL-IOF-IX VL-TOTAL-IX VL-TARIFA VL-DESCONTO VL-LIQUIDO VL-ADICIONAL VL-CUSTO VL-IOF VL-TOTAL VL-COBER-ASSIST PCDESCON-ADIC PCDESCON-BONUS. */
            _.Move(0, EM0901W099.VL_DESC_IX, EM0901W099.VL_LIQ_IX, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_ADIC_IX, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_IOF_IX, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TARIFA, EM0901W099.VL_DESCONTO, EM0901W099.VL_LIQUIDO, EM0901W099.VL_ADICIONAL, EM0901W099.VL_CUSTO, EM0901W099.VL_IOF, EM0901W099.VL_TOTAL, EM0901W099.VL_COBER_ASSIST, EM0901W099.PCDESCON_ADIC, EM0901W099.PCDESCON_BONUS);

            /*" -2942- MOVE SPACES TO W01A0077. */
            _.Move("", EM0901W099.W01A0077);

            /*" -2945- IF ENDO-CODPRODU EQUAL 1403 OR 1404 OR 1804 */

            if (ENDO_CODPRODU.In("1403", "1404", "1804"))
            {

                /*" -2946- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

                if (ENDO_TIPO_ENDOSSO == "4")
                {

                    /*" -2948- MOVE ZEROS TO VL-PREMIO-BASE VL-TARIFARIO-IX */
                    _.Move(0, EM0901W099.VL_PREMIO_BASE, EM0901W099.VL_TARIFARIO_IX);

                    /*" -2951- GO TO B2001-CONTINUA. */

                    B2001_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -2953- MOVE 0 TO AUTA-NRPRRESS */
            _.Move(0, AUTA_NRPRRESS);

            /*" -2954- IF ENDO-RAMO EQUAL ( 31 OR 53 ) */

            if (ENDO_RAMO.In("31", "53"))
            {

                /*" -2965- PERFORM B2000_GRAVA_PARCELA_DB_SELECT_1 */

                B2000_GRAVA_PARCELA_DB_SELECT_1();

                /*" -2968- IF SQLCODE NOT = ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2969- MOVE 'B2000' TO WNR-EXEC-SQL */
                    _.Move("B2000", WABEND.WNR_EXEC_SQL);

                    /*" -2971- DISPLAY 'EM0010B - ERRO NO SELECT AUTOAPOL ... ' ' ' ENDO-NUM-APOLICE */

                    $"EM0010B - ERRO NO SELECT AUTOAPOL ...  {ENDO_NUM_APOLICE}"
                    .Display();

                    /*" -2972- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2974- END-IF */
                }


                /*" -2975- IF AUTA-NRPRRESS GREATER 205 */

                if (AUTA_NRPRRESS > 205)
                {

                    /*" -2976- MOVE ENDO-VLCUSEMI TO VL-CUSTO */
                    _.Move(ENDO_VLCUSEMI, EM0901W099.VL_CUSTO);

                    /*" -2977- ELSE */
                }
                else
                {


                    /*" -2978- MOVE ZEROS TO VL-CUSTO */
                    _.Move(0, EM0901W099.VL_CUSTO);

                    /*" -2980- END-IF */
                }


                /*" -2981- MOVE AUTA-NRPRRESS TO W01A0077-VERSAO */
                _.Move(AUTA_NRPRRESS, EM0901W099.W01A0077R.W01A0077_VERSAO);

                /*" -2982- MOVE AUTA-TIPO-COBRANCA TO W01A0077-TIPCOB */
                _.Move(AUTA_TIPO_COBRANCA, EM0901W099.W01A0077R.W01A0077_TIPCOB);

                /*" -2983- MOVE ENDO-QTPARCEL TO W01A0077-QTPARC */
                _.Move(ENDO_QTPARCEL, EM0901W099.W01A0077R.W01A0077_QTPARC);

                /*" -2984- MOVE ENDO-CODPRODU TO W01A0077-CODPRO */
                _.Move(ENDO_CODPRODU, EM0901W099.W01A0077R.W01A0077_CODPRO);

                /*" -2986- MOVE ENDO-DTINIVIG TO W01A0077-INIVIG */
                _.Move(ENDO_DTINIVIG, EM0901W099.W01A0077R.W01A0077_INIVIG);

                /*" -2988- END-IF. */
            }


            /*" -2989- IF ENDO-CODPRODU EQUAL 1403 OR 1404 */

            if (ENDO_CODPRODU.In("1403", "1404"))
            {

                /*" -2994- MOVE 111 TO W01A0077-VERSAO. */
                _.Move(111, EM0901W099.W01A0077R.W01A0077_VERSAO);
            }


            /*" -2995- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -2996- IF ENDO-TIPO-ENDOSSO EQUAL '0' */

                if (ENDO_TIPO_ENDOSSO == "0")
                {

                    /*" -2997- IF W-PARCEL EQUAL 0 OR 1 */

                    if (W_PARCEL.In("0", "1"))
                    {

                        /*" -2998- PERFORM B2060-CHAMA-LT3116S */

                        B2060_CHAMA_LT3116S_SECTION();

                        /*" -2999- END-IF */
                    }


                    /*" -3000- PERFORM B2062-MONTA-PARCELA */

                    B2062_MONTA_PARCELA_SECTION();

                    /*" -3001- ELSE */
                }
                else
                {


                    /*" -3002- IF W-PARCEL EQUAL 0 OR 1 */

                    if (W_PARCEL.In("0", "1"))
                    {

                        /*" -3003- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

                        if (ENDO_TIPO_ENDOSSO == "4")
                        {

                            /*" -3004- INITIALIZE LT2118S-AREA-PARAMETROS */
                            _.Initialize(
                                LBLT2118.LT2118S_AREA_PARAMETROS
                            );

                            /*" -3005- ELSE */
                        }
                        else
                        {


                            /*" -3006- PERFORM B2063-CHAMA-LT2118S */

                            B2063_CHAMA_LT2118S_SECTION();

                            /*" -3007- END-IF */
                        }


                        /*" -3008- END-IF */
                    }


                    /*" -3009- PERFORM B2065-MONTA-PARCELA */

                    B2065_MONTA_PARCELA_SECTION();

                    /*" -3010- END-IF */
                }


                /*" -3019- GO TO B2000-CONTINUA. */

                B2000_CONTINUA(); //GOTO
                return;
            }


            /*" -3030- IF (ENDO-NUM-APOLICE EQUAL 106800000012 OR EQUAL 106000000003 OR EQUAL 106000000004 OR EQUAL 107700000015 OR EQUAL 107700000016 OR EQUAL 104800000052 OR EQUAL 104800000053 OR EQUAL 104800000054 OR EQUAL 104800000055 OR EQUAL 104800000058 OR EQUAL 101402541676) */

            if ((ENDO_NUM_APOLICE.In("106800000012", "106000000003", "106000000004", "107700000015", "107700000016", "104800000052", "104800000053", "104800000054", "104800000055", "104800000058", "101402541676")))
            {

                /*" -3032- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                {

                    /*" -3033- IF W-PARCEL EQUAL 0 OR 1 */

                    if (W_PARCEL.In("0", "1"))
                    {

                        /*" -3034- PERFORM B2090-00-SELECT-EFPREMIO */

                        B2090_00_SELECT_EFPREMIO_SECTION();

                        /*" -3035- END-IF */
                    }


                    /*" -3036- PERFORM B2092-00-MONTA-PARCELA-EF-CONS */

                    B2092_00_MONTA_PARCELA_EF_CONS_SECTION();

                    /*" -3037- GO TO B2000-CONTINUA */

                    B2000_CONTINUA(); //GOTO
                    return;

                    /*" -3038- ELSE */
                }
                else
                {


                    /*" -3039- GO TO B2000-CONTINUA */

                    B2000_CONTINUA(); //GOTO
                    return;

                    /*" -3040- END-IF */
                }


                /*" -3052- END-IF. */
            }


            /*" -3075- IF (ENDO-RAMO EQUAL 68 OR 61 OR 65) OR (ENDO-NUM-APOLICE EQUAL 0107700000022 OR 0101402541675 OR 0107700000021 OR 0107700000023 OR 0107700000038 OR 0101402541678 OR 0107700000026 OR 0106100000018 OR 0101402541679 OR 0106100000030 OR 0101402541682 OR 0106100000033 OR 0101402541681 OR 0106100000036 OR 0101402541683 OR 0107700000049 OR 0107700000050 OR 0107700000058 OR 0107700000046 OR 0101402541680) */

            if ((ENDO_RAMO.In("68", "61", "65")) || (ENDO_NUM_APOLICE.In("0107700000022", "0101402541675", "0107700000021", "0107700000023", "0107700000038", "0101402541678", "0107700000026", "0106100000018", "0101402541679", "0106100000030", "0101402541682", "0106100000033", "0101402541681", "0106100000036", "0101402541683", "0107700000049", "0107700000050", "0107700000058", "0107700000046", "0101402541680")))
            {

                /*" -3078- IF ENDO-NUM-APOLICE NOT EQUAL 0106800000007 AND NOT EQUAL 0106500000001 */

                if (!ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -3080- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                    if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                    {

                        /*" -3081- IF W-PARCEL EQUAL 0 OR 1 */

                        if (W_PARCEL.In("0", "1"))
                        {

                            /*" -3082- PERFORM B2091-00-SELECT-EFPREMIO */

                            B2091_00_SELECT_EFPREMIO_SECTION();

                            /*" -3083- END-IF */
                        }


                        /*" -3084- PERFORM B2093-00-MONTA-PARCELA-EF-HABI */

                        B2093_00_MONTA_PARCELA_EF_HABI_SECTION();

                        /*" -3085- GO TO B2000-CONTINUA */

                        B2000_CONTINUA(); //GOTO
                        return;

                        /*" -3086- ELSE */
                    }
                    else
                    {


                        /*" -3087- GO TO B2000-CONTINUA */

                        B2000_CONTINUA(); //GOTO
                        return;

                        /*" -3088- END-IF */
                    }


                    /*" -3089- END-IF */
                }


                /*" -3091- END-IF. */
            }


            /*" -3092- IF ENDO-RAMO EQUAL 48 OR 70 */

            if (ENDO_RAMO.In("48", "70"))
            {

                /*" -3094- IF ENDO-CODPRODU EQUAL 4801 OR 4808 OR 4812 OR 7001 */

                if (ENDO_CODPRODU.In("4801", "4808", "4812", "7001"))
                {

                    /*" -3096- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                    if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                    {

                        /*" -3097- IF W-PARCEL EQUAL 0 OR 1 */

                        if (W_PARCEL.In("0", "1"))
                        {

                            /*" -3098- PERFORM B2091-00-SELECT-EFPREMIO */

                            B2091_00_SELECT_EFPREMIO_SECTION();

                            /*" -3099- END-IF */
                        }


                        /*" -3100- PERFORM B2093-00-MONTA-PARCELA-EF-HABI */

                        B2093_00_MONTA_PARCELA_EF_HABI_SECTION();

                        /*" -3101- GO TO B2000-CONTINUA */

                        B2000_CONTINUA(); //GOTO
                        return;

                        /*" -3102- ELSE */
                    }
                    else
                    {


                        /*" -3103- GO TO B2000-CONTINUA */

                        B2000_CONTINUA(); //GOTO
                        return;

                        /*" -3104- END-IF */
                    }


                    /*" -3105- END-IF */
                }


                /*" -3107- END-IF. */
            }


            /*" -3108- IF ENDO-RAMO EQUAL 77 */

            if (ENDO_RAMO == 77)
            {

                /*" -3109- IF ENDO-CODPRODU EQUAL 7704 */

                if (ENDO_CODPRODU == 7704)
                {

                    /*" -3111- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                    if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                    {

                        /*" -3112- IF W-PARCEL EQUAL 0 OR 1 */

                        if (W_PARCEL.In("0", "1"))
                        {

                            /*" -3113- PERFORM B2091-00-SELECT-EFPREMIO */

                            B2091_00_SELECT_EFPREMIO_SECTION();

                            /*" -3114- END-IF */
                        }


                        /*" -3115- PERFORM B2093-00-MONTA-PARCELA-EF-HABI */

                        B2093_00_MONTA_PARCELA_EF_HABI_SECTION();

                        /*" -3116- GO TO B2000-CONTINUA */

                        B2000_CONTINUA(); //GOTO
                        return;

                        /*" -3117- ELSE */
                    }
                    else
                    {


                        /*" -3118- GO TO B2000-CONTINUA */

                        B2000_CONTINUA(); //GOTO
                        return;

                        /*" -3119- END-IF */
                    }


                    /*" -3120- END-IF */
                }


                /*" -3126- END-IF. */
            }


            /*" -3128- IF ENDO-CODPRODU EQUAL 1804 AND ENDO-COD-EMPRESA EQUAL 0 */

            if (ENDO_CODPRODU == 1804 && ENDO_COD_EMPRESA == 0)
            {

                /*" -3129- GO TO B2000-PROC-1804 */

                B2000_PROC_1804(); //GOTO
                return;

                /*" -3131- END-IF. */
            }


            /*" -3133- IF ENDO-CODPRODU EQUAL 6701 AND ENDO-NRENDOS GREATER ZEROS */

            if (ENDO_CODPRODU == 6701 && ENDO_NRENDOS > 00)
            {

                /*" -3134- PERFORM R3000-LE-CUSTO-APOLICE */

                R3000_LE_CUSTO_APOLICE_SECTION();

                /*" -3135- MOVE PARC-OTNCUSTO TO ENDO-VLCUSEMI */
                _.Move(PARC_OTNCUSTO, ENDO_VLCUSEMI);

                /*" -3137- END-IF. */
            }


            /*" -3141- IF ((ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND (ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -3142- PERFORM R1100-00-PARCELA-AUTO-FACIL */

                R1100_00_PARCELA_AUTO_FACIL_SECTION();

                /*" -3144- END-IF */
            }


            /*" -3146- IF ENDO-RAMO EQUAL ( 31 OR 53 ) AND AUTA-NRPRRESS GREATER 195 */

            if (ENDO_RAMO.In("31", "53") && AUTA_NRPRRESS > 195)
            {

                /*" -3147- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                _.Move("EM0903S", WS_SUBROT_CALC);

                /*" -3148- CALL 'EM0903S' USING EM0901W099 */
                _.Call("EM0903S", EM0901W099);

                /*" -3149- ELSE */
            }
            else
            {


                /*" -3150- MOVE ENDO-VLCUSEMI TO VL-CUSTO */
                _.Move(ENDO_VLCUSEMI, EM0901W099.VL_CUSTO);

                /*" -3156- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802) AND ENDO-COD-EMPRESA EQUAL 0)) */

                if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802) && ENDO_COD_EMPRESA == 0)))
                {

                    /*" -3158- IF ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1602 */

                    if (ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1602)
                    {

                        /*" -3159- PERFORM B2020-SELECT-MR021 */

                        B2020_SELECT_MR021_SECTION();

                        /*" -3160- MOVE MR021-PCT-DESC-COBERTURA TO PCDESCON-ADIC */
                        _.Move(MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_DESC_COBERTURA, EM0901W099.PCDESCON_ADIC);

                        /*" -3161- MOVE MR021-PCT-BONUS-RENOVCAO TO PCDESCON-BONUS */
                        _.Move(MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_BONUS_RENOVCAO, EM0901W099.PCDESCON_BONUS);

                        /*" -3162- MOVE MR021-PCT-DESC-CORRETOR TO PCDESCON */
                        _.Move(MR021.DCLMR_APOL_ITEM_COND.MR021_PCT_DESC_CORRETOR, EM0901W099.PCDESCON);

                        /*" -3163- ELSE */
                    }
                    else
                    {


                        /*" -3164- PERFORM B2030-SELECT-MR022 */

                        B2030_SELECT_MR022_SECTION();

                        /*" -3165- MOVE MR022-PCT-DESC-COBERTURA TO PCDESCON-ADIC */
                        _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA, EM0901W099.PCDESCON_ADIC);

                        /*" -3166- MOVE MR022-PCT-BONUS-RENOVCAO TO PCDESCON-BONUS */
                        _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO, EM0901W099.PCDESCON_BONUS);

                        /*" -3167- MOVE MR022-PCT-DESC-CORRETOR TO PCDESCON */
                        _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_CORRETOR, EM0901W099.PCDESCON);

                        /*" -3168- END-IF */
                    }


                    /*" -3170- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' AND ENDO-TIPO-ENDOSSO NOT EQUAL '1' */

                    if (ENDO_TIPO_ENDOSSO != "0" && ENDO_TIPO_ENDOSSO != "1")
                    {

                        /*" -3173- MOVE ZEROS TO PCDESCON-ADIC PCDESCON-BONUS PCDESCON */
                        _.Move(0, EM0901W099.PCDESCON_ADIC, EM0901W099.PCDESCON_BONUS, EM0901W099.PCDESCON);

                        /*" -3174- END-IF */
                    }


                    /*" -3175- PERFORM B2035-SELECT-MRAPOCOB */

                    B2035_SELECT_MRAPOCOB_SECTION();

                    /*" -3176- MOVE MRAPOCOB-PRM-TARIFARIO-IX TO VL-COBER-ASSIST */
                    _.Move(MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX, EM0901W099.VL_COBER_ASSIST);

                    /*" -3177- MOVE ENDO-CFPREFIX TO VL-ADICIONAL */
                    _.Move(ENDO_CFPREFIX, EM0901W099.VL_ADICIONAL);

                    /*" -3178- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                    if (EM0901W099.VL_PREMIO_BASE <= 00)
                    {

                        /*" -3181- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                        _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                        /*" -3182- END-IF */
                    }


                    /*" -3183- MOVE 'EM0904S' TO WS-SUBROT-CALC */
                    _.Move("EM0904S", WS_SUBROT_CALC);

                    /*" -3184- CALL 'EM0904S' USING EM0901W099 */
                    _.Call("EM0904S", EM0901W099);

                    /*" -3185- ELSE */
                }
                else
                {


                    /*" -3187- IF ENDO-CODPRODU EQUAL 1403 OR ENDO-CODPRODU EQUAL 1404 */

                    if (ENDO_CODPRODU == 1403 || ENDO_CODPRODU == 1404)
                    {

                        /*" -3188- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                        if (EM0901W099.VL_PREMIO_BASE <= 00)
                        {

                            /*" -3191- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                            _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                            /*" -3192- END-IF */
                        }


                        /*" -3193- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                        _.Move("EM0903S", WS_SUBROT_CALC);

                        /*" -3194- CALL 'EM0903S' USING EM0901W099 */
                        _.Call("EM0903S", EM0901W099);

                        /*" -3195- ELSE */
                    }
                    else
                    {


                        /*" -3197- IF ENDO-CODPRODU EQUAL 6701 AND ENDO-NRENDOS GREATER ZEROS */

                        if (ENDO_CODPRODU == 6701 && ENDO_NRENDOS > 00)
                        {

                            /*" -3198- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                            if (EM0901W099.VL_PREMIO_BASE <= 00)
                            {

                                /*" -3201- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                                _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                                /*" -3202- END-IF */
                            }


                            /*" -3203- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                            _.Move("EM0903S", WS_SUBROT_CALC);

                            /*" -3204- CALL 'EM0903S' USING EM0901W099 */
                            _.Call("EM0903S", EM0901W099);

                            /*" -3205- ELSE */
                        }
                        else
                        {


                            /*" -3206- IF ENDO-VLCUSEMI EQUAL ZEROS */

                            if (ENDO_VLCUSEMI == 00)
                            {

                                /*" -3207- MOVE 'EM0901S' TO WS-SUBROT-CALC */
                                _.Move("EM0901S", WS_SUBROT_CALC);

                                /*" -3208- CALL 'EM0901S' USING EM0901W099 */
                                _.Call("EM0901S", EM0901W099);

                                /*" -3210- ELSE */
                            }
                            else
                            {


                                /*" -3211- IF VL-PREMIO-BASE NOT GREATER ZEROS */

                                if (EM0901W099.VL_PREMIO_BASE <= 00)
                                {

                                    /*" -3214- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                                    _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                                    /*" -3216- END-IF */
                                }


                                /*" -3217- MOVE 'EM0903S' TO WS-SUBROT-CALC */
                                _.Move("EM0903S", WS_SUBROT_CALC);

                                /*" -3218- CALL 'EM0903S' USING EM0901W099 */
                                _.Call("EM0903S", EM0901W099);

                                /*" -3220- END-IF. */
                            }

                        }

                    }

                }

            }


            /*" -3221- IF W01A0077 NOT EQUAL SPACES */

            if (!EM0901W099.W01A0077.IsEmpty())
            {

                /*" -3222- DISPLAY 'PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S' */
                _.Display($"PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S");

                /*" -3223- DISPLAY 'PROBLEMAS CALL SUB-ROTINA ' WS-SUBROT-CALC */
                _.Display($"PROBLEMAS CALL SUB-ROTINA {WS_SUBROT_CALC}");

                /*" -3224- DISPLAY 'APOLICE ... ' ENDO-NUM-APOLICE */
                _.Display($"APOLICE ... {ENDO_NUM_APOLICE}");

                /*" -3225- DISPLAY 'ENDOSSO ... ' ENDO-NRENDOS */
                _.Display($"ENDOSSO ... {ENDO_NRENDOS}");

                /*" -3226- DISPLAY 'ENDO-COD-MOEDA-PRM = ' ENDO-COD-MOEDA-PRM */
                _.Display($"ENDO-COD-MOEDA-PRM = {ENDO_COD_MOEDA_PRM}");

                /*" -3227- DISPLAY 'W-DATA-EDITADA     = ' W-DATA-EDITADA */
                _.Display($"W-DATA-EDITADA     = {W_DATA_EDITADA}");

                /*" -3228- DISPLAY 'COD-MOEDA          = ' COD-MOEDA */
                _.Display($"COD-MOEDA          = {EM0901W099.COD_MOEDA}");

                /*" -3229- DISPLAY 'DTINIVIG           = ' DTINIVIG */
                _.Display($"DTINIVIG           = {EM0901W099.DTINIVIG}");

                /*" -3230- DISPLAY '------------------------------------' */
                _.Display($"------------------------------------");

                /*" -3231- DISPLAY 'W01A0077-VERSAO    = ' W01A0077-VERSAO */
                _.Display($"W01A0077-VERSAO    = {EM0901W099.W01A0077R.W01A0077_VERSAO}");

                /*" -3232- DISPLAY 'W01A0077-TIPCOB    = ' W01A0077-TIPCOB */
                _.Display($"W01A0077-TIPCOB    = {EM0901W099.W01A0077R.W01A0077_TIPCOB}");

                /*" -3233- DISPLAY 'W01A0077-QTPARC    = ' W01A0077-QTPARC */
                _.Display($"W01A0077-QTPARC    = {EM0901W099.W01A0077R.W01A0077_QTPARC}");

                /*" -3234- DISPLAY 'W01A0077-CODPRO    = ' W01A0077-CODPRO */
                _.Display($"W01A0077-CODPRO    = {EM0901W099.W01A0077R.W01A0077_CODPRO}");

                /*" -3235- DISPLAY 'W01A0077-INIVIG    = ' W01A0077-INIVIG */
                _.Display($"W01A0077-INIVIG    = {EM0901W099.W01A0077R.W01A0077_INIVIG}");

                /*" -3236- DISPLAY '------------------------------------' */
                _.Display($"------------------------------------");

                /*" -3237- DISPLAY '                   = ' */
                _.Display($"                   = ");

                /*" -3238- DISPLAY 'CODIGO DE ERRO ' W01A0077 */
                _.Display($"CODIGO DE ERRO {EM0901W099.W01A0077}");

                /*" -3240- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3244- IF ((ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND (ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -3246- GO TO B2002-CONTINUA. */

                B2002_CONTINUA(); //GOTO
                return;
            }


            /*" -3246- GO TO B2000-CONTINUA. */

            B2000_CONTINUA(); //GOTO
            return;

        }

        [StopWatch]
        /*" B2000-GRAVA-PARCELA-DB-SELECT-1 */
        public void B2000_GRAVA_PARCELA_DB_SELECT_1()
        {
            /*" -2965- EXEC SQL SELECT DISTINCT NRPRRESS, TIPO_COBRANCA INTO :AUTA-NRPRRESS, :AUTA-TIPO-COBRANCA FROM SEGUROS.V0AUTOAPOL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND SITUACAO = ' ' ORDER BY 1,2 WITH UR END-EXEC */

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
            /*" -3252- MOVE ENDO-VLCUSEMI TO VL-CUSTO */
            _.Move(ENDO_VLCUSEMI, EM0901W099.VL_CUSTO);

            /*" -3253- PERFORM B2030-SELECT-MR022 */

            B2030_SELECT_MR022_SECTION();

            /*" -3255- PERFORM B2031-SELECT-MRAPOITE */

            B2031_SELECT_MRAPOITE_SECTION();

            /*" -3256- MOVE MR022-PCT-DESC-COBERTURA TO PCDESCON-ADIC */
            _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_DESC_COBERTURA, EM0901W099.PCDESCON_ADIC);

            /*" -3257- MOVE MR022-PCT-BONUS-RENOVCAO TO PCDESCON-BONUS */
            _.Move(MR022.DCLMR_APOL_ITEM_EMPR.MR022_PCT_BONUS_RENOVCAO, EM0901W099.PCDESCON_BONUS);

            /*" -3259- MOVE MRAPOITE-PCT-DESC-FIDEL TO PCDESCON */
            _.Move(MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_FIDEL, EM0901W099.PCDESCON);

            /*" -3262- MOVE MRAPOITE-PCT-DESC-COMERCIAL TO PCDESCON-COMERC */
            _.Move(MRAPOITE.DCLMR_APOLICE_ITEM.MRAPOITE_PCT_DESC_COMERCIAL, EM0901W099.PCDESCON_COMERC);

            /*" -3264- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' AND ENDO-TIPO-ENDOSSO NOT EQUAL '1' */

            if (ENDO_TIPO_ENDOSSO != "0" && ENDO_TIPO_ENDOSSO != "1")
            {

                /*" -3268- MOVE ZEROS TO PCDESCON-ADIC PCDESCON-BONUS PCDESCON PCDESCON-COMERC */
                _.Move(0, EM0901W099.PCDESCON_ADIC, EM0901W099.PCDESCON_BONUS, EM0901W099.PCDESCON, EM0901W099.PCDESCON_COMERC);

                /*" -3270- END-IF. */
            }


            /*" -3272- PERFORM B2035-SELECT-MRAPOCOB */

            B2035_SELECT_MRAPOCOB_SECTION();

            /*" -3273- MOVE MRAPOCOB-PRM-TARIFARIO-IX TO VL-COBER-ASSIST */
            _.Move(MRAPOCOB.DCLMR_APOLICE_COBER.MRAPOCOB_PRM_TARIFARIO_IX, EM0901W099.VL_COBER_ASSIST);

            /*" -3275- MOVE ENDO-CFPREFIX TO VL-ADICIONAL */
            _.Move(ENDO_CFPREFIX, EM0901W099.VL_ADICIONAL);

            /*" -3276- IF VL-PREMIO-BASE NOT GREATER ZEROS */

            if (EM0901W099.VL_PREMIO_BASE <= 00)
            {

                /*" -3279- MOVE ZEROS TO VL-CUSTO PCIOF VL-ADICIONAL */
                _.Move(0, EM0901W099.VL_CUSTO, EM0901W099.PCIOF, EM0901W099.VL_ADICIONAL);

                /*" -3287- END-IF */
            }


            /*" -3288- MOVE 'EM0905S' TO WS-SUBROT-CALC */
            _.Move("EM0905S", WS_SUBROT_CALC);

            /*" -3294- CALL 'EM0905S' USING EM0901W099. */
            _.Call("EM0905S", EM0901W099);

            /*" -3295- IF W01A0077 NOT EQUAL SPACES */

            if (!EM0901W099.W01A0077.IsEmpty())
            {

                /*" -3296- DISPLAY 'PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S' */
                _.Display($"PROBLEMAS CALL SUB-ROTINA EM0901S/EM0903S/EM0904S");

                /*" -3297- DISPLAY 'PROBLEMAS CALL SUB-ROTINA ' WS-SUBROT-CALC */
                _.Display($"PROBLEMAS CALL SUB-ROTINA {WS_SUBROT_CALC}");

                /*" -3298- DISPLAY 'APOLICE ... ' ENDO-NUM-APOLICE */
                _.Display($"APOLICE ... {ENDO_NUM_APOLICE}");

                /*" -3299- DISPLAY 'ENDOSSO ... ' ENDO-NRENDOS */
                _.Display($"ENDOSSO ... {ENDO_NRENDOS}");

                /*" -3300- DISPLAY 'ENDO-COD-MOEDA-PRM = ' ENDO-COD-MOEDA-PRM */
                _.Display($"ENDO-COD-MOEDA-PRM = {ENDO_COD_MOEDA_PRM}");

                /*" -3301- DISPLAY 'W-DATA-EDITADA    = ' W-DATA-EDITADA */
                _.Display($"W-DATA-EDITADA    = {W_DATA_EDITADA}");

                /*" -3302- DISPLAY 'COD-MOEDA          = ' COD-MOEDA */
                _.Display($"COD-MOEDA          = {EM0901W099.COD_MOEDA}");

                /*" -3303- DISPLAY 'DTINIVIG           = ' DTINIVIG */
                _.Display($"DTINIVIG           = {EM0901W099.DTINIVIG}");

                /*" -3304- DISPLAY 'CODIGO DE ERRO ' W01A0077 */
                _.Display($"CODIGO DE ERRO {EM0901W099.W01A0077}");

                /*" -3304- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2000-CONTINUA */
        private void B2000_CONTINUA(bool isPerform = false)
        {
            /*" -3310- MOVE 'B1998' TO WNR-EXEC-SQL. */
            _.Move("B1998", WABEND.WNR_EXEC_SQL);

            /*" -3317- PERFORM B2000_CONTINUA_DB_SELECT_1 */

            B2000_CONTINUA_DB_SELECT_1();

            /*" -3320- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3322- MOVE 'B1999' TO WNR-EXEC-SQL */
                _.Move("B1999", WABEND.WNR_EXEC_SQL);

                /*" -3329- PERFORM B2000_CONTINUA_DB_SELECT_2 */

                B2000_CONTINUA_DB_SELECT_2();

                /*" -3332- IF SQLCODE EQUAL ZEROES */

                if (DB.SQLCODE == 00)
                {

                    /*" -3334- MOVE FATU-VLPRMTOT TO VL-TOTAL VL-TOTAL-IX */
                    _.Move(FATU_VLPRMTOT, EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

                    /*" -3337- MOVE FATU-VLIOCC TO VL-IOF VL-IOF-IX. */
                    _.Move(FATU_VLIOCC, EM0901W099.VL_IOF, EM0901W099.VL_IOF_IX);
                }

            }


            /*" -3367- IF (ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-PRESTA) AND SQLCODE EQUAL 100 AND RAMOIND-PCIOF NOT EQUAL ZEROS AND ENDO-NUM-APOLICE NOT EQUAL 107700000010 AND 107700000015 AND 107700000016 AND 107700000022 AND 101402541675 AND 107700000021 AND 107700000023 AND 107700000038 AND 101402541678 AND 107700000026 AND 106100000018 AND 101402541679 AND 106100000030 AND 101402541682 AND 106100000033 AND 101402541681 AND 106100000036 AND 101402541683 AND 107700000047 AND 107700000049 AND 107700000050 AND 107700000058 */

            if ((ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_PRESTA.ToString())) && DB.SQLCODE == 100 && RAMOIND_PCIOF != 00 && !ENDO_NUM_APOLICE.In("107700000010", "107700000015", "107700000016", "107700000022", "101402541675", "107700000021", "107700000023", "107700000038", "101402541678", "107700000026", "106100000018", "101402541679", "106100000030", "101402541682", "106100000033", "101402541681", "106100000036", "101402541683", "107700000047", "107700000049", "107700000050", "107700000058"))
            {

                /*" -3369- COMPUTE VL-TOTAL = VL-PREMIO-BASE * RAMOIND-PCIOF */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_PREMIO_BASE * RAMOIND_PCIOF;

                /*" -3370- MOVE VL-TOTAL TO VL-TOTAL-IX */
                _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

                /*" -3372- COMPUTE VL-IOF = VL-TOTAL - VL-PREMIO-BASE */
                EM0901W099.VL_IOF.Value = EM0901W099.VL_TOTAL - EM0901W099.VL_PREMIO_BASE;

                /*" -3374- MOVE VL-IOF TO VL-IOF-IX */
                _.Move(EM0901W099.VL_IOF, EM0901W099.VL_IOF_IX);

                /*" -3381- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802 OR ENDO-CODPRODU EQUAL 1804) AND ENDO-COD-EMPRESA EQUAL 0)) */

                if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802 || ENDO_CODPRODU == 1804) && ENDO_COD_EMPRESA == 0)))
                {

                    /*" -3383- GO TO B2001-CONTINUA. */

                    B2001_CONTINUA(); //GOTO
                    return;
                }

            }


            /*" -3384- IF W-PARCEL EQUAL 1 */

            if (W_PARCEL == 1)
            {

                /*" -3385- IF ENDO-VLRCAP NOT EQUAL ZEROS */

                if (ENDO_VLRCAP != 00)
                {

                    /*" -3386- PERFORM B2400-AJUSTA-PARCELA */

                    B2400_AJUSTA_PARCELA_SECTION();

                    /*" -3390- ELSE */
                }
                else
                {


                    /*" -3391- IF ENDO-PCADICIO EQUAL ZEROS */

                    if (ENDO_PCADICIO == 00)
                    {

                        /*" -3392- IF ENDO-CODPRODU NOT EQUAL 1804 */

                        if (ENDO_CODPRODU != 1804)
                        {

                            /*" -3394- COMPUTE VL-PREMIO-BASE = VL-PREMIO-BASE - VL-TARIFARIO-IX */
                            EM0901W099.VL_PREMIO_BASE.Value = EM0901W099.VL_PREMIO_BASE - EM0901W099.VL_TARIFARIO_IX;

                            /*" -3394- END-IF. */
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" B2000-CONTINUA-DB-SELECT-1 */
        public void B2000_CONTINUA_DB_SELECT_1()
        {
            /*" -3317- EXEC SQL SELECT VAL_FATURA, VLIOCC INTO :FATU-VLPRMTOT, :FATU-VLIOCC FROM SEGUROS.V0FATURAS WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS WITH UR END-EXEC. */

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
            /*" -3398- IF (ENDO-CODPRODU = 1803 OR 1805) */

            if ((ENDO_CODPRODU.In("1803", "1805")))
            {

                /*" -3399- MOVE VL-IOF-IX TO WS-VALOR-AUX2 */
                _.Move(EM0901W099.VL_IOF_IX, WS_VALOR_AUX2);

                /*" -3400- MOVE WS-VALOR-AUX2 TO VL-IOF-IX */
                _.Move(WS_VALOR_AUX2, EM0901W099.VL_IOF_IX);

                /*" -3401- MOVE VL-DIFIOC-IX TO WS-VALOR-AUX2 */
                _.Move(FILLER_30.VL_DIFIOC_IX, WS_VALOR_AUX2);

                /*" -3402- MOVE WS-VALOR-AUX2 TO VL-DIFIOC-IX */
                _.Move(WS_VALOR_AUX2, FILLER_30.VL_DIFIOC_IX);

                /*" -3406- DISPLAY ' B2001 CONVERTE TO 2 DEC ' ' W-PARCEL :' W-PARCEL ' VL-IOF-IX:' VL-IOF-IX ' VL-DIFIOC-IX:' VL-DIFIOC-IX */

                $" B2001 CONVERTE TO 2 DEC  W-PARCEL :{W_PARCEL} VL-IOF-IX:{EM0901W099.VL_IOF_IX} VL-DIFIOC-IX:{FILLER_30.VL_DIFIOC_IX}"
                .Display();

                /*" -3411- END-IF */
            }


            /*" -3412- IF W-PARCEL GREATER 1 */

            if (W_PARCEL > 1)
            {

                /*" -3414- COMPUTE VL-TARIFARIO-IX = VL-TARIFARIO-IX - VL-DIFTAR-IX */
                EM0901W099.VL_TARIFARIO_IX.Value = EM0901W099.VL_TARIFARIO_IX - FILLER_30.VL_DIFTAR_IX;

                /*" -3416- COMPUTE VL-DESC-IX = VL-DESC-IX - VL-DIFDESC-IX */
                EM0901W099.VL_DESC_IX.Value = EM0901W099.VL_DESC_IX - FILLER_30.VL_DIFDESC_IX;

                /*" -3418- COMPUTE VL-LIQ-IX = VL-LIQ-IX - VL-DIFLIQ-IX */
                EM0901W099.VL_LIQ_IX.Value = EM0901W099.VL_LIQ_IX - FILLER_30.VL_DIFLIQ_IX;

                /*" -3420- COMPUTE VL-ADIC-IX = VL-ADIC-IX - VL-DIFADI-IX */
                EM0901W099.VL_ADIC_IX.Value = EM0901W099.VL_ADIC_IX - FILLER_30.VL_DIFADI_IX;

                /*" -3422- COMPUTE VL-CUSTO-IX = VL-CUSTO-IX - VL-DIFCUS-IX */
                EM0901W099.VL_CUSTO_IX.Value = EM0901W099.VL_CUSTO_IX - FILLER_30.VL_DIFCUS_IX;

                /*" -3424- COMPUTE VL-IOF-IX = VL-IOF-IX - VL-DIFIOC-IX */
                EM0901W099.VL_IOF_IX.Value = EM0901W099.VL_IOF_IX - FILLER_30.VL_DIFIOC_IX;

                /*" -3426- COMPUTE VL-TOTAL-IX = VL-TOTAL-IX - VL-DIFTOT-IX */
                EM0901W099.VL_TOTAL_IX.Value = EM0901W099.VL_TOTAL_IX - FILLER_30.VL_DIFTOT_IX;

                /*" -3428- COMPUTE VL-TARIFA = VL-TARIFA - VL-DIFTAR */
                EM0901W099.VL_TARIFA.Value = EM0901W099.VL_TARIFA - FILLER_30.VL_DIFTAR;

                /*" -3430- COMPUTE VL-DESCONTO = VL-DESCONTO - VL-DIFDESC */
                EM0901W099.VL_DESCONTO.Value = EM0901W099.VL_DESCONTO - FILLER_30.VL_DIFDESC;

                /*" -3432- COMPUTE VL-LIQUIDO = VL-LIQUIDO - VL-DIFLIQ */
                EM0901W099.VL_LIQUIDO.Value = EM0901W099.VL_LIQUIDO - FILLER_30.VL_DIFLIQ;

                /*" -3434- COMPUTE VL-ADICIONAL = VL-ADICIONAL - VL-DIFADI */
                EM0901W099.VL_ADICIONAL.Value = EM0901W099.VL_ADICIONAL - FILLER_30.VL_DIFADI;

                /*" -3436- COMPUTE VL-CUSTO = VL-CUSTO - VL-DIFCUS */
                EM0901W099.VL_CUSTO.Value = EM0901W099.VL_CUSTO - FILLER_30.VL_DIFCUS;

                /*" -3438- COMPUTE VL-IOF = VL-IOF - VL-DIFIOC */
                EM0901W099.VL_IOF.Value = EM0901W099.VL_IOF - FILLER_30.VL_DIFIOC;

                /*" -3440- COMPUTE VL-TOTAL = VL-TOTAL - VL-DIFTOT */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_TOTAL - FILLER_30.VL_DIFTOT;

                /*" -3441- IF W-PARCEL EQUAL ENDO-QTPARCEL */

                if (W_PARCEL == ENDO_QTPARCEL)
                {

                    /*" -3455- MOVE ZEROS TO VL-DIFTAR VL-DIFDESC VL-DIFLIQ VL-DIFADI VL-DIFCUS VL-DIFIOC VL-DIFTOT VL-DIFTAR-IX VL-DIFDESC-IX VL-DIFLIQ-IX VL-DIFADI-IX VL-DIFCUS-IX VL-DIFIOC-IX VL-DIFTOT-IX. */
                    _.Move(0, FILLER_30.VL_DIFTAR, FILLER_30.VL_DIFDESC, FILLER_30.VL_DIFLIQ, FILLER_30.VL_DIFADI, FILLER_30.VL_DIFCUS, FILLER_30.VL_DIFIOC, FILLER_30.VL_DIFTOT, FILLER_30.VL_DIFTAR_IX, FILLER_30.VL_DIFDESC_IX, FILLER_30.VL_DIFLIQ_IX, FILLER_30.VL_DIFADI_IX, FILLER_30.VL_DIFCUS_IX, FILLER_30.VL_DIFIOC_IX, FILLER_30.VL_DIFTOT_IX);
                }

            }


        }

        [StopWatch]
        /*" B2000-CONTINUA-DB-SELECT-2 */
        public void B2000_CONTINUA_DB_SELECT_2()
        {
            /*" -3329- EXEC SQL SELECT VAL_FATURA, VLIOCC INTO :FATU-VLPRMTOT, :FATU-VLIOCC FROM SEGUROS.V0FATURASFIL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS WITH UR END-EXEC. */

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
            /*" -3466- IF ((ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND (ENDO-ORGAO EQUAL 10) AND (ENDO-RAMO EQUAL 53) AND (ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304)) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304"))))
            {

                /*" -3468- IF W-PARCEL LESS 2 AND ENDO-QTPARCEL GREATER 1 */

                if (W_PARCEL < 2 && ENDO_QTPARCEL > 1)
                {

                    /*" -3471- PERFORM B2600-00-AJUSTA-ULTIMA. */

                    B2600_00_AJUSTA_ULTIMA_SECTION();
                }

            }


            /*" -3472- MOVE ENDO-NUM-APOLICE TO PARC-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, PARC_NUM_APOLICE);

            /*" -3473- MOVE ENDO-NRENDOS TO PARC-NRENDOS. */
            _.Move(ENDO_NRENDOS, PARC_NRENDOS);

            /*" -3474- MOVE '0' TO PARC-DACPARC. */
            _.Move("0", PARC_DACPARC);

            /*" -3475- MOVE W-PARCEL TO PARC-NRPARCEL. */
            _.Move(W_PARCEL, PARC_NRPARCEL);

            /*" -3476- MOVE ENDO-FONTE TO PARC-FONTE. */
            _.Move(ENDO_FONTE, PARC_FONTE);

            /*" -3477- MOVE VL-TARIFARIO-IX TO PARC-TARIFARIO-IX. */
            _.Move(EM0901W099.VL_TARIFARIO_IX, PARC_TARIFARIO_IX);

            /*" -3478- MOVE VL-DESC-IX TO PARC-DESCONTO-IX. */
            _.Move(EM0901W099.VL_DESC_IX, PARC_DESCONTO_IX);

            /*" -3479- MOVE VL-LIQ-IX TO PARC-OTNPRLIQ. */
            _.Move(EM0901W099.VL_LIQ_IX, PARC_OTNPRLIQ);

            /*" -3480- MOVE VL-IOF-IX TO PARC-OTNIOF. */
            _.Move(EM0901W099.VL_IOF_IX, PARC_OTNIOF);

            /*" -3481- MOVE VL-ADIC-IX TO PARC-OTNADFRA. */
            _.Move(EM0901W099.VL_ADIC_IX, PARC_OTNADFRA);

            /*" -3482- MOVE VL-CUSTO-IX TO PARC-OTNCUSTO. */
            _.Move(EM0901W099.VL_CUSTO_IX, PARC_OTNCUSTO);

            /*" -3486- MOVE VL-TOTAL-IX TO PARC-OTNTOTAL. */
            _.Move(EM0901W099.VL_TOTAL_IX, PARC_OTNTOTAL);

            /*" -3488- IF ENDO-RAMO EQUAL 68 OR 48 OR 70 OR 61 OR 65 */

            if (ENDO_RAMO.In("68", "48", "70", "61", "65"))
            {

                /*" -3489- IF WCH-APOL-HABIT EQUAL 'S' */

                if (WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT == "S")
                {

                    /*" -3491- MOVE WS000-IOF-RAMO68-IX TO PARC-OTNIOF */
                    _.Move(WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68_IX, PARC_OTNIOF);

                    /*" -3498- COMPUTE PARC-OTNTOTAL = PARC-OTNPRLIQ + PARC-OTNADFRA + PARC-OTNCUSTO + PARC-OTNIOF. */
                    PARC_OTNTOTAL.Value = PARC_OTNPRLIQ + PARC_OTNADFRA + PARC_OTNCUSTO + PARC_OTNIOF;
                }

            }


            /*" -3515- IF ((ENDO-NRRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) OR ((ENDO-NUMBIL NOT EQUAL ZEROS) AND (ENDO-CODPRODU NOT EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) OR ((ENDO-CODPRODU EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (ENDO-AGERCAP EQUAL 9000) AND (W-PARCEL EQUAL 0 OR 1)) OR ((ENDO-CODPRODU EQUAL 83) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NRRCAP > 0) && (W_PARCEL.In("0", "1"))) || ((ENDO_NUMBIL != 00) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 0) && (ENDO_AGERCAP == 9000) && (W_PARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3516- MOVE 2 TO PARC-OCORHIST */
                _.Move(2, PARC_OCORHIST);

                /*" -3517- MOVE '1' TO PARC-SITUACAO */
                _.Move("1", PARC_SITUACAO);

                /*" -3518- ELSE */
            }
            else
            {


                /*" -3519- MOVE 1 TO PARC-OCORHIST */
                _.Move(1, PARC_OCORHIST);

                /*" -3523- MOVE '0' TO PARC-SITUACAO. */
                _.Move("0", PARC_SITUACAO);
            }


            /*" -3524- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

            if (ENDO_TIPO_ENDOSSO == "4")
            {

                /*" -3530- MOVE '1' TO PARC-SITUACAO. */
                _.Move("1", PARC_SITUACAO);
            }


            /*" -3533- IF (ENDO-CODPRODU EQUAL 1803 OR 1805) AND ENDO-TIPO-ENDOSSO EQUAL '5' AND VL-TOTAL EQUAL 0 */

            if ((ENDO_CODPRODU.In("1803", "1805")) && ENDO_TIPO_ENDOSSO == "5" && EM0901W099.VL_TOTAL == 0)
            {

                /*" -3534- IF W-PARCEL EQUAL 0 OR 1 */

                if (W_PARCEL.In("0", "1"))
                {

                    /*" -3539- MOVE '1' TO PARC-SITUACAO. */
                    _.Move("1", PARC_SITUACAO);
                }

            }


            /*" -3551- MOVE ZEROS TO W-NUMR-TITULO. */
            _.Move(0, W_NUMR_TITULO);

            /*" -3556- IF (( ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' ) AND ( ENDO-ORGAO EQUAL 10 ) AND ( ENDO-RAMO EQUAL 53 ) AND ( ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 ) AND ( ENDO-BCOCOBR EQUAL 104 )) */

            if (((ENDO_TIPO_ENDOSSO.In("0", "1")) && (ENDO_ORGAO == 10) && (ENDO_RAMO == 53) && (ENDO_CODPRODU.In("5302", "5303", "5304")) && (ENDO_BCOCOBR == 104)))
            {

                /*" -3557- PERFORM B2018-RECUPERA-AU084 */

                B2018_RECUPERA_AU084_SECTION();

                /*" -3561- IF ((AU084-IND-FORMA-PAGTO-AD EQUAL '0' AND W-PARCEL LESS 2) OR (PRCB-TIPO-COBRANCA EQUAL ' ' OR '0' )) */

                if (((AU084.DCLAU_APOLICE_COMPL.AU084_IND_FORMA_PAGTO_AD == "0" && W_PARCEL < 2) || (PRCB_TIPO_COBRANCA.In(" ", "0"))))
                {

                    /*" -3562- PERFORM R6100-NOVO-TITULO-CEF */

                    R6100_NOVO_TITULO_CEF_SECTION();

                    /*" -3563- ELSE */
                }
                else
                {


                    /*" -3564- MOVE ZEROS TO W-NUMR-TITULO */
                    _.Move(0, W_NUMR_TITULO);

                    /*" -3565- ELSE */
                }

            }
            else
            {


                /*" -3567- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -3568- IF ENDO-BCOCOBR EQUAL 104 */

                    if (ENDO_BCOCOBR == 104)
                    {

                        /*" -3569- IF ENDO-ORGAO NOT EQUAL 100 */

                        if (ENDO_ORGAO != 100)
                        {

                            /*" -3571- PERFORM R6100-NOVO-TITULO-CEF. */

                            R6100_NOVO_TITULO_CEF_SECTION();
                        }

                    }

                }

            }


            /*" -3572- MOVE W-NUMR-TITULO TO PARC-NRTIT. */
            _.Move(W_NUMR_TITULO, PARC_NRTIT);

            /*" -3573- MOVE ZEROS TO PARC-QTDDOC. */
            _.Move(0, PARC_QTDDOC);

            /*" -3575- MOVE -1 TO PARC-EMPRESA-I. */
            _.Move(-1, PARC_EMPRESA_I);

            /*" -3577- IF PRCB-TIPO-COBRANCA NOT EQUAL ' ' AND PRCB-TIPO-COBRANCA NOT EQUAL '0' */

            if (PRCB_TIPO_COBRANCA != " " && PRCB_TIPO_COBRANCA != "0")
            {

                /*" -3578- MOVE SPACES TO PARC-SIT-COBRANCA */
                _.Move("", PARC_SIT_COBRANCA);

                /*" -3579- MOVE ZEROS TO PARC-COBRANCA-I */
                _.Move(0, PARC_COBRANCA_I);

                /*" -3580- ELSE */
            }
            else
            {


                /*" -3582- MOVE -1 TO PARC-COBRANCA-I. */
                _.Move(-1, PARC_COBRANCA_I);
            }


            /*" -3584- MOVE 'B2000' TO WNR-EXEC-SQL. */
            _.Move("B2000", WABEND.WNR_EXEC_SQL);

            /*" -3585- IF PARC-TARIFARIO-IX < 0 */

            if (PARC_TARIFARIO_IX < 0)
            {

                /*" -3587- COMPUTE PARC-TARIFARIO-IX = PARC-TARIFARIO-IX * -1. */
                PARC_TARIFARIO_IX.Value = PARC_TARIFARIO_IX * -1;
            }


            /*" -3588- IF PARC-DESCONTO-IX < 0 */

            if (PARC_DESCONTO_IX < 0)
            {

                /*" -3590- COMPUTE PARC-DESCONTO-IX = PARC-DESCONTO-IX * -1. */
                PARC_DESCONTO_IX.Value = PARC_DESCONTO_IX * -1;
            }


            /*" -3591- IF PARC-OTNPRLIQ < 0 */

            if (PARC_OTNPRLIQ < 0)
            {

                /*" -3593- COMPUTE PARC-OTNPRLIQ = PARC-OTNPRLIQ * -1. */
                PARC_OTNPRLIQ.Value = PARC_OTNPRLIQ * -1;
            }


            /*" -3594- IF PARC-OTNADFRA < 0 */

            if (PARC_OTNADFRA < 0)
            {

                /*" -3596- COMPUTE PARC-OTNADFRA = PARC-OTNADFRA * -1. */
                PARC_OTNADFRA.Value = PARC_OTNADFRA * -1;
            }


            /*" -3597- IF PARC-OTNCUSTO < 0 */

            if (PARC_OTNCUSTO < 0)
            {

                /*" -3599- COMPUTE PARC-OTNCUSTO = PARC-OTNCUSTO * -1. */
                PARC_OTNCUSTO.Value = PARC_OTNCUSTO * -1;
            }


            /*" -3600- IF PARC-OTNIOF < 0 */

            if (PARC_OTNIOF < 0)
            {

                /*" -3602- COMPUTE PARC-OTNIOF = PARC-OTNIOF * -1. */
                PARC_OTNIOF.Value = PARC_OTNIOF * -1;
            }


            /*" -3603- IF PARC-OTNTOTAL < 0 */

            if (PARC_OTNTOTAL < 0)
            {

                /*" -3605- COMPUTE PARC-OTNTOTAL = PARC-OTNTOTAL * -1. */
                PARC_OTNTOTAL.Value = PARC_OTNTOTAL * -1;
            }


            /*" -3606- IF WS-VL-IOF-IGUAIS = 'S' */

            if (WS_VL_IOF_IGUAIS == "S")
            {

                /*" -3607- PERFORM B2005-TRATAR-VALORES */

                B2005_TRATAR_VALORES_SECTION();

                /*" -3616- END-IF. */
            }


            /*" -3638- PERFORM B2002_CONTINUA_DB_INSERT_1 */

            B2002_CONTINUA_DB_INSERT_1();

            /*" -3641- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3642- DISPLAY 'EM0010B - ERRO INSERT V0PARCELA --------------' */
                _.Display($"EM0010B - ERRO INSERT V0PARCELA --------------");

                /*" -3643- DISPLAY 'PARC-NUM-APOLICE = ' PARC-NUM-APOLICE */
                _.Display($"PARC-NUM-APOLICE = {PARC_NUM_APOLICE}");

                /*" -3644- DISPLAY 'PARC-NRENDOS     = ' PARC-NRENDOS */
                _.Display($"PARC-NRENDOS     = {PARC_NRENDOS}");

                /*" -3645- DISPLAY 'PARC-NRPARCEL    = ' PARC-NRPARCEL */
                _.Display($"PARC-NRPARCEL    = {PARC_NRPARCEL}");

                /*" -3646- DISPLAY 'PARC-DACPARC     = ' PARC-DACPARC */
                _.Display($"PARC-DACPARC     = {PARC_DACPARC}");

                /*" -3647- DISPLAY 'PARC-FONTE       = ' PARC-FONTE */
                _.Display($"PARC-FONTE       = {PARC_FONTE}");

                /*" -3648- DISPLAY 'PARC-NRTIT       = ' PARC-NRTIT */
                _.Display($"PARC-NRTIT       = {PARC_NRTIT}");

                /*" -3649- DISPLAY 'PARC-TARIFARIO-IX= ' PARC-TARIFARIO-IX */
                _.Display($"PARC-TARIFARIO-IX= {PARC_TARIFARIO_IX}");

                /*" -3650- DISPLAY 'PARC-DESCONTO-IX = ' PARC-DESCONTO-IX */
                _.Display($"PARC-DESCONTO-IX = {PARC_DESCONTO_IX}");

                /*" -3651- DISPLAY 'PARC-OTNPRLIQ    = ' PARC-OTNPRLIQ */
                _.Display($"PARC-OTNPRLIQ    = {PARC_OTNPRLIQ}");

                /*" -3652- DISPLAY 'PARC-OTNADFRA    = ' PARC-OTNADFRA */
                _.Display($"PARC-OTNADFRA    = {PARC_OTNADFRA}");

                /*" -3653- DISPLAY 'PARC-OTNCUSTO    = ' PARC-OTNCUSTO */
                _.Display($"PARC-OTNCUSTO    = {PARC_OTNCUSTO}");

                /*" -3654- DISPLAY 'PARC-OTNIOF      = ' PARC-OTNIOF */
                _.Display($"PARC-OTNIOF      = {PARC_OTNIOF}");

                /*" -3655- DISPLAY 'PARC-OTNTOTAL    = ' PARC-OTNTOTAL */
                _.Display($"PARC-OTNTOTAL    = {PARC_OTNTOTAL}");

                /*" -3656- DISPLAY 'PARC-OCORHIST    = ' PARC-OCORHIST */
                _.Display($"PARC-OCORHIST    = {PARC_OCORHIST}");

                /*" -3657- DISPLAY 'PARC-QTDDOC      = ' PARC-QTDDOC */
                _.Display($"PARC-QTDDOC      = {PARC_QTDDOC}");

                /*" -3658- DISPLAY 'PARC-SITUACAO    = ' PARC-SITUACAO */
                _.Display($"PARC-SITUACAO    = {PARC_SITUACAO}");

                /*" -3659- DISPLAY 'PARC-COD-EMPRESA = ' PARC-COD-EMPRESA */
                _.Display($"PARC-COD-EMPRESA = {PARC_COD_EMPRESA}");

                /*" -3660- DISPLAY 'PARC-SIT-COBRANCA= ' PARC-SIT-COBRANCA */
                _.Display($"PARC-SIT-COBRANCA= {PARC_SIT_COBRANCA}");

                /*" -3661- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -3663- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3665- ADD 1 TO AC-I-V0PARCELA. */
            AC_I_V0PARCELA.Value = AC_I_V0PARCELA + 1;

            /*" -3666- MOVE 0101 TO HIST-OPERACAO. */
            _.Move(0101, HIST_OPERACAO);

            /*" -3667- MOVE 1 TO HIST-OCORHIST. */
            _.Move(1, HIST_OCORHIST);

            /*" -3668- MOVE VL-TARIFA TO HIST-PRM-TARIFARIO. */
            _.Move(EM0901W099.VL_TARIFA, HIST_PRM_TARIFARIO);

            /*" -3669- MOVE VL-DESCONTO TO HIST-VAL-DESCONTO. */
            _.Move(EM0901W099.VL_DESCONTO, HIST_VAL_DESCONTO);

            /*" -3670- MOVE VL-LIQUIDO TO HIST-VLPRMLIQ. */
            _.Move(EM0901W099.VL_LIQUIDO, HIST_VLPRMLIQ);

            /*" -3671- MOVE VL-ADICIONAL TO HIST-VLADIFRA. */
            _.Move(EM0901W099.VL_ADICIONAL, HIST_VLADIFRA);

            /*" -3672- MOVE VL-CUSTO TO HIST-VLCUSEMI. */
            _.Move(EM0901W099.VL_CUSTO, HIST_VLCUSEMI);

            /*" -3673- MOVE VL-IOF TO HIST-VLIOCC. */
            _.Move(EM0901W099.VL_IOF, HIST_VLIOCC);

            /*" -3674- MOVE VL-TOTAL TO HIST-VLPRMTOT. */
            _.Move(EM0901W099.VL_TOTAL, HIST_VLPRMTOT);

            /*" -3676- MOVE VL-TOTAL TO HIST-VLPREMIO. */
            _.Move(EM0901W099.VL_TOTAL, HIST_VLPREMIO);

            /*" -3677- MOVE ZEROS TO HIST-NRAVISO. */
            _.Move(0, HIST_NRAVISO);

            /*" -3678- MOVE ENDO-AGECOBR TO HIST-AGECOBR. */
            _.Move(ENDO_AGECOBR, HIST_AGECOBR);

            /*" -3682- MOVE -1 TO HIST-DTQITBCO-I. */
            _.Move(-1, HIST_DTQITBCO_I);

            /*" -3684- IF ENDO-RAMO = ( 68 OR 48 OR 70 OR 61 OR 65 ) */

            if (ENDO_RAMO.In("68", "48", "70", "61", "65"))
            {

                /*" -3685- IF WCH-APOL-HABIT EQUAL 'S' */

                if (WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT == "S")
                {

                    /*" -3686- MOVE WS000-IOF-RAMO68 TO HIST-VLIOCC */
                    _.Move(WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68, HIST_VLIOCC);

                    /*" -3690- COMPUTE HIST-VLPRMTOT = HIST-VLPRMLIQ + HIST-VLADIFRA + HIST-VLCUSEMI + HIST-VLIOCC */
                    HIST_VLPRMTOT.Value = HIST_VLPRMLIQ + HIST_VLADIFRA + HIST_VLCUSEMI + HIST_VLIOCC;

                    /*" -3699- MOVE HIST-VLPRMTOT TO HIST-VLPREMIO. */
                    _.Move(HIST_VLPRMTOT, HIST_VLPREMIO);
                }

            }


            /*" -3703- IF ((ENDO-CODPRODU EQUAL 4005 OR 6701 OR 7501) AND (ENDO-VLRCAP GREATER ZEROS) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU.In("4005", "6701", "7501")) && (ENDO_VLRCAP > 00) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3704- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3705- MOVE 'MOV11-DTVENCTO      ' TO WS-MOV-DTVENCTO */
                _.Move("MOV11-DTVENCTO      ", WS_MOV_DTVENCTO);

                /*" -3707- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3716- IF (ENDO-RAMO EQUAL PARM-RAMO-VG OR PARM-RAMO-AP OR PARM-RAMO-VGAPC OR PARM-RAMO-SAUDE OR PARM-RAMO-PRESTA) AND (ENDO-CODPRODU EQUAL ZEROS) */

            if ((ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_VGAPC.ToString(), PARM_RAMO_SAUDE.ToString(), PARM_RAMO_PRESTA.ToString())) && (ENDO_CODPRODU == 00))
            {

                /*" -3717- IF VIND-DTVENCTO EQUAL -1 */

                if (VIND_DTVENCTO == -1)
                {

                    /*" -3718- MOVE ENDO-DTINIVIG TO W-DATA-EDITADA */
                    _.Move(ENDO_DTINIVIG, W_DATA_EDITADA);

                    /*" -3719- MOVE W-DIA TO W-DD */
                    _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

                    /*" -3720- MOVE W-MES TO W-MM */
                    _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

                    /*" -3721- MOVE W-ANO TO W-AA */
                    _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

                    /*" -3722- MOVE W-DATA TO PROSOM-DATA01 */
                    _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

                    /*" -3723- MOVE 30 TO PROSOM-QTDIA */
                    _.Move(30, PROSOMW099.PROSOM_QTDIA);

                    /*" -3724- MOVE ZEROS TO PROSOM-DATA02 */
                    _.Move(0, PROSOMW099.PROSOM_DATA02);

                    /*" -3725- CALL 'PROSOCU1' USING PROSOMW099 */
                    _.Call("PROSOCU1", PROSOMW099);

                    /*" -3726- MOVE PROSOM-DATA02 TO W-DATA */
                    _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

                    /*" -3727- MOVE W-DD TO W-DIA */
                    _.Move(W_DATA.W_DD, W_DATA_EDITADA.W_DIA);

                    /*" -3728- MOVE W-MM TO W-MES */
                    _.Move(W_DATA.W_MM, W_DATA_EDITADA.W_MES);

                    /*" -3729- MOVE W-AA TO W-ANO */
                    _.Move(W_DATA.W_AA, W_DATA_EDITADA.W_ANO);

                    /*" -3730- MOVE W-DATA-EDITADA TO HIST-DTVENCTO */
                    _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

                    /*" -3731- MOVE 'MOV10-DTVENCTO  ' TO WS-MOV-DTVENCTO */
                    _.Move("MOV10-DTVENCTO  ", WS_MOV_DTVENCTO);

                    /*" -3732- GO TO B2000-GRAVA */

                    B2000_GRAVA(); //GOTO
                    return;

                    /*" -3733- ELSE */
                }
                else
                {


                    /*" -3734- MOVE ENDO-DTVENCTO TO HIST-DTVENCTO */
                    _.Move(ENDO_DTVENCTO, HIST_DTVENCTO);

                    /*" -3735- MOVE 'MOV9-DTVENCTO   ' TO WS-MOV-DTVENCTO */
                    _.Move("MOV9-DTVENCTO   ", WS_MOV_DTVENCTO);

                    /*" -3737- GO TO B2000-GRAVA. */

                    B2000_GRAVA(); //GOTO
                    return;
                }

            }


            /*" -3739- IF (ENDO-RAMO EQUAL 33 OR 34 OR 35) AND (W-PARCEL EQUAL 0 OR 1) */

            if ((ENDO_RAMO.In("33", "34", "35")) && (W_PARCEL.In("0", "1")))
            {

                /*" -3740- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3741- MOVE 'MOV8-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV8-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3743- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3757- IF (ENDO-NUM-APOLICE EQUAL 106800000012 OR EQUAL 106000000003 OR EQUAL 106000000004 OR EQUAL 107700000015 OR EQUAL 107700000016 OR EQUAL 104800000052 OR EQUAL 104800000053 OR EQUAL 104800000054 OR EQUAL 104800000055 OR EQUAL 104800000058 OR EQUAL 101402541676) AND (ENDO-TIPO-ENDOSSO = '1' ) */

            if ((ENDO_NUM_APOLICE.In("106800000012", "106000000003", "106000000004", "107700000015", "107700000016", "104800000052", "104800000053", "104800000054", "104800000055", "104800000058", "101402541676")) && (ENDO_TIPO_ENDOSSO == "1"))
            {

                /*" -3758- MOVE ENDO-DTVENCTO TO HIST-DTVENCTO */
                _.Move(ENDO_DTVENCTO, HIST_DTVENCTO);

                /*" -3759- MOVE 'MOV7-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV7-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3761- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3766- IF ((ENDO-NUMBIL GREATER ZEROS) AND (ENDO-CODPRODU NOT EQUAL 32) AND (ENDO-VLRCAP GREATER ZEROS) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NUMBIL > 00) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 00) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3767- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3768- MOVE 'MOV6-DTVENCTO    ' TO WS-MOV-DTVENCTO */
                _.Move("MOV6-DTVENCTO    ", WS_MOV_DTVENCTO);

                /*" -3770- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3775- IF ((ENDO-CODPRODU EQUAL 32) AND (ENDO-VLRCAP GREATER ZEROS) AND (ENDO-AGERCAP EQUAL 9000) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 00) && (ENDO_AGERCAP == 9000) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3776- MOVE ENDO-DTINIVIG TO HIST-DTVENCTO */
                _.Move(ENDO_DTINIVIG, HIST_DTVENCTO);

                /*" -3777- MOVE 'MOV5-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV5-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3779- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3783- IF (ENDO-CODPRODU EQUAL 83) AND (ENDO-VLRCAP GREATER ZEROS) AND (W-PARCEL EQUAL 0 OR 1) */

            if ((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 00) && (W_PARCEL.In("0", "1")))
            {

                /*" -3784- MOVE ENDO-DATARCAP TO HIST-DTVENCTO */
                _.Move(ENDO_DATARCAP, HIST_DTVENCTO);

                /*" -3785- MOVE 'MOV4-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV4-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3787- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3791- IF ((ENDO-AGERCAP EQUAL 9000) AND (ENDO-NRRCAP EQUAL ZEROS) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_AGERCAP == 9000) && (ENDO_NRRCAP == 00) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3792- MOVE SIST-DTMOVABE TO HIST-DTVENCTO */
                _.Move(SIST_DTMOVABE, HIST_DTVENCTO);

                /*" -3793- MOVE 'MOV3-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV3-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3797- GO TO B2000-GRAVA. */

                B2000_GRAVA(); //GOTO
                return;
            }


            /*" -3799- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -3800- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -3801- PERFORM B2050-VENCTO-AUTO-FACIL */

                    B2050_VENCTO_AUTO_FACIL_SECTION();

                    /*" -3802- ELSE */
                }
                else
                {


                    /*" -3803- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                    /*" -3805- END-IF */
                }


                /*" -3806- MOVE W-DATA-EDITADA TO HIST-DTVENCTO */
                _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

                /*" -3807- MOVE 'MOV2-DTVENCTO     ' TO WS-MOV-DTVENCTO */
                _.Move("MOV2-DTVENCTO     ", WS_MOV_DTVENCTO);

                /*" -3808- GO TO B2000-GRAVA */

                B2000_GRAVA(); //GOTO
                return;

                /*" -3809- ELSE */
            }
            else
            {


                /*" -3811- IF (ENDO-NRRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1) */

                if ((ENDO_NRRCAP > 0) && (W_PARCEL.In("0", "1")))
                {

                    /*" -3812- MOVE ENDO-DATARCAP TO HIST-DTVENCTO */
                    _.Move(ENDO_DATARCAP, HIST_DTVENCTO);

                    /*" -3813- MOVE 'MOV1-DTVENCTO   ' TO WS-MOV-DTVENCTO */
                    _.Move("MOV1-DTVENCTO   ", WS_MOV_DTVENCTO);

                    /*" -3814- MOVE ENDO-DATARCAP TO W-DATA-EDITADA */
                    _.Move(ENDO_DATARCAP, W_DATA_EDITADA);

                    /*" -3836- GO TO B2000-GRAVA. */

                    B2000_GRAVA(); //GOTO
                    return;
                }

            }


            /*" -3836- PERFORM B2010-CALCULA-VENCIMENTO. */

            B2010_CALCULA_VENCIMENTO_SECTION();

        }

        [StopWatch]
        /*" B2002-CONTINUA-DB-INSERT-1 */
        public void B2002_CONTINUA_DB_INSERT_1()
        {
            /*" -3638- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:PARC-NUM-APOLICE ,:PARC-NRENDOS ,:PARC-NRPARCEL ,:PARC-DACPARC ,:PARC-FONTE ,:PARC-NRTIT ,:PARC-TARIFARIO-IX ,:PARC-DESCONTO-IX ,:PARC-OTNPRLIQ ,:PARC-OTNADFRA ,:PARC-OTNCUSTO ,:PARC-OTNIOF ,:PARC-OTNTOTAL ,:PARC-OCORHIST ,:PARC-QTDDOC ,:PARC-SITUACAO ,:PARC-COD-EMPRESA:PARC-EMPRESA-I , CURRENT TIMESTAMP ,:PARC-SIT-COBRANCA:PARC-COBRANCA-I ) END-EXEC. */

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
            /*" -3842- PERFORM B3000-GRAVA-HISTOPARC. */

            B3000_GRAVA_HISTOPARC_SECTION();

            /*" -3843- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -3844- PERFORM R7000-00-GRAVA-PARC-COMPL */

                R7000_00_GRAVA_PARC_COMPL_SECTION();

                /*" -3855- END-IF. */
            }


            /*" -3857- MOVE SPACES TO WFIM-V1RCAPCOMP. */
            _.Move("", WFIM_V1RCAPCOMP);

            /*" -3869- PERFORM B3100-SELECT-V1RCAPCOMP. */

            B3100_SELECT_V1RCAPCOMP_SECTION();

            /*" -3872- IF ((ENDO-NRRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NRRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3873- IF WFIM-V1RCAPCOMP EQUAL SPACES */

                if (WFIM_V1RCAPCOMP.IsEmpty())
                {

                    /*" -3874- PERFORM B2100-MONTA-201 */

                    B2100_MONTA_201_SECTION();

                    /*" -3875- PERFORM B3000-GRAVA-HISTOPARC */

                    B3000_GRAVA_HISTOPARC_SECTION();

                    /*" -3876- PERFORM B2200-000-BAIXA-RCAP */

                    B2200_000_BAIXA_RCAP_SECTION();

                    /*" -3877- ELSE */
                }
                else
                {


                    /*" -3879- PERFORM B3160-ALTERA-V0PARCELA. */

                    B3160_ALTERA_V0PARCELA_SECTION();
                }

            }


            /*" -3884- IF ((ENDO-NUMBIL GREATER 0) AND (ENDO-CODPRODU NOT EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_NUMBIL > 0) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3885- PERFORM B2110-MONTA-208 */

                B2110_MONTA_208_SECTION();

                /*" -3887- PERFORM B3000-GRAVA-HISTOPARC. */

                B3000_GRAVA_HISTOPARC_SECTION();
            }


            /*" -3891- IF ((ENDO-CODPRODU EQUAL 32) AND (ENDO-VLRCAP GREATER 0) AND (ENDO-AGERCAP EQUAL 9000) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 0) && (ENDO_AGERCAP == 9000) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3892- PERFORM B2110-MONTA-208 */

                B2110_MONTA_208_SECTION();

                /*" -3894- PERFORM B3000-GRAVA-HISTOPARC. */

                B3000_GRAVA_HISTOPARC_SECTION();
            }


            /*" -3897- IF ((ENDO-CODPRODU EQUAL 83) AND (ENDO-VLRCAP GREATER 0) AND (W-PARCEL EQUAL 0 OR 1)) */

            if (((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 0) && (W_PARCEL.In("0", "1"))))
            {

                /*" -3898- PERFORM B2110-MONTA-208 */

                B2110_MONTA_208_SECTION();

                /*" -3901- PERFORM B3000-GRAVA-HISTOPARC. B2000-900-SEGUE. */

                B3000_GRAVA_HISTOPARC_SECTION();
            }


            /*" -3901- ADD 1 TO W-PARCEL. */
            W_PARCEL.Value = W_PARCEL + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2000_999_EXIT*/

        [StopWatch]
        /*" B2005-TRATAR-VALORES-SECTION */
        private void B2005_TRATAR_VALORES_SECTION()
        {
            /*" -3911- IF (ENDO-NUM-APOLICE = 106800000018 AND ENDO-CODPRODU = 6821) OR (ENDO-NUM-APOLICE = 106800000011 AND ENDO-CODPRODU = 6812) */

            if ((ENDO_NUM_APOLICE == 106800000018 && ENDO_CODPRODU == 6821) || (ENDO_NUM_APOLICE == 106800000011 && ENDO_CODPRODU == 6812))
            {

                /*" -3913- COMPUTE PARC-TARIFARIO-IX = PARC-TARIFARIO-IX - PARC-OTNIOF */
                PARC_TARIFARIO_IX.Value = PARC_TARIFARIO_IX - PARC_OTNIOF;

                /*" -3914- COMPUTE PARC-OTNPRLIQ = PARC-OTNPRLIQ - PARC-OTNIOF */
                PARC_OTNPRLIQ.Value = PARC_OTNPRLIQ - PARC_OTNIOF;

                /*" -3915- COMPUTE PARC-OTNTOTAL = PARC-OTNTOTAL - PARC-OTNIOF */
                PARC_OTNTOTAL.Value = PARC_OTNTOTAL - PARC_OTNIOF;

                /*" -3915- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2005_999_EXIT*/

        [StopWatch]
        /*" B2010-CALCULA-VENCIMENTO-SECTION */
        private void B2010_CALCULA_VENCIMENTO_SECTION()
        {
            /*" -3924- MOVE 'B2010' TO WNR-EXEC-SQL. */
            _.Move("B2010", WABEND.WNR_EXEC_SQL);

            /*" -3925- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -3926- PERFORM B2011-VENCIMENTO-1A-PARCELA */

                B2011_VENCIMENTO_1A_PARCELA_SECTION();

                /*" -3927- ELSE */
            }
            else
            {


                /*" -3928- IF W-PARCEL EQUAL 2 */

                if (W_PARCEL == 2)
                {

                    /*" -3929- PERFORM B2012-VENCIMENTO-2A-PARCELA */

                    B2012_VENCIMENTO_2A_PARCELA_SECTION();

                    /*" -3930- ELSE */
                }
                else
                {


                    /*" -3930- PERFORM B2013-VENCIMENTO-DEMAIS. */

                    B2013_VENCIMENTO_DEMAIS_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2010_999_EXIT*/

        [StopWatch]
        /*" B2011-VENCIMENTO-1A-PARCELA-SECTION */
        private void B2011_VENCIMENTO_1A_PARCELA_SECTION()
        {
            /*" -3948- MOVE 'B2011' TO WNR-EXEC-SQL. */
            _.Move("B2011", WABEND.WNR_EXEC_SQL);

            /*" -3949- IF VIND-DTVENCTO EQUAL -1 */

            if (VIND_DTVENCTO == -1)
            {

                /*" -3950- PERFORM B2014-SOMA-1-MES */

                B2014_SOMA_1_MES_SECTION();

                /*" -3951- PERFORM B2017-VERIFICA-DIA-BASE */

                B2017_VERIFICA_DIA_BASE_SECTION();

                /*" -3952- ELSE */
            }
            else
            {


                /*" -3961- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
                _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);
            }


            /*" -3964- IF (ENDO-CODPRODU = 1803 OR 1805) AND (ENDO-NRENDOS = 0) NEXT SENTENCE */

            if ((ENDO_CODPRODU.In("1803", "1805")) && (ENDO_NRENDOS == 0))
            {

                /*" -3965- ELSE */
            }
            else
            {


                /*" -3967- PERFORM B2016-VERIFICA-DATA-MINIMA. */

                B2016_VERIFICA_DATA_MINIMA_SECTION();
            }


            /*" -3968- MOVE W-DATA-EDITADA TO HIST-DTVENCTO. */
            _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

            /*" -3968- MOVE 'B2011-VENCIMENTO-1A-PARCELA' TO WS-MOV-DTVENCTO. */
            _.Move("B2011-VENCIMENTO-1A-PARCELA", WS_MOV_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2011_999_EXIT*/

        [StopWatch]
        /*" B2012-VENCIMENTO-2A-PARCELA-SECTION */
        private void B2012_VENCIMENTO_2A_PARCELA_SECTION()
        {
            /*" -3992- MOVE 'B2012' TO WNR-EXEC-SQL. */
            _.Move("B2012", WABEND.WNR_EXEC_SQL);

            /*" -3993- IF ENDO-CODPRODU = 1805 AND ENDO-NRENDOS = 0 */

            if (ENDO_CODPRODU == 1805 && ENDO_NRENDOS == 0)
            {

                /*" -3995- MOVE ENDO-CODPRODU TO LTSOLPAR-COD-PRODUTO */
                _.Move(ENDO_CODPRODU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

                /*" -3997- END-IF */
            }


            /*" -3998- IF VIND-DTVENCTO EQUAL -1 */

            if (VIND_DTVENCTO == -1)
            {

                /*" -3999- PERFORM B2014-SOMA-1-MES */

                B2014_SOMA_1_MES_SECTION();

                /*" -4000- PERFORM B2017-VERIFICA-DIA-BASE */

                B2017_VERIFICA_DIA_BASE_SECTION();

                /*" -4001- IF ENDO-NRRCAP GREATER 0 */

                if (ENDO_NRRCAP > 0)
                {

                    /*" -4002- PERFORM B2016-VERIFICA-DATA-MINIMA */

                    B2016_VERIFICA_DATA_MINIMA_SECTION();

                    /*" -4003- END-IF */
                }


                /*" -4004- ELSE */
            }
            else
            {


                /*" -4005- IF ENDO-NRRCAP GREATER 0 */

                if (ENDO_NRRCAP > 0)
                {

                    /*" -4006- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                    /*" -4007- PERFORM B2016-VERIFICA-DATA-MINIMA */

                    B2016_VERIFICA_DATA_MINIMA_SECTION();

                    /*" -4008- ELSE */
                }
                else
                {


                    /*" -4009- PERFORM B2014-SOMA-1-MES */

                    B2014_SOMA_1_MES_SECTION();

                    /*" -4015- PERFORM B2017-VERIFICA-DIA-BASE. */

                    B2017_VERIFICA_DIA_BASE_SECTION();
                }

            }


            /*" -4016- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -4017- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -4018- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -4022- MOVE W-DATA TO EM0925-DATA01 */
            _.Move(W_DATA, EM0925W099.EM0925_DATA01);

            /*" -4024- MOVE ENDO-DTTERVIG TO W-DTTERVIG */
            _.Move(ENDO_DTTERVIG, W_DTTERVIG);

            /*" -4025- IF W-DIA GREATER W-DDTERVIG */

            if (W_DATA_EDITADA.W_DIA > W_DTTERVIG.W_DDTERVIG)
            {

                /*" -4026- MOVE W-DIA TO W-DDTERVIG */
                _.Move(W_DATA_EDITADA.W_DIA, W_DTTERVIG.W_DDTERVIG);

                /*" -4027- SUBTRACT 1 FROM W-MMTERVIG */
                W_DTTERVIG.W_MMTERVIG.Value = W_DTTERVIG.W_MMTERVIG - 1;

                /*" -4028- IF W-MMTERVIG EQUAL ZEROS */

                if (W_DTTERVIG.W_MMTERVIG == 00)
                {

                    /*" -4029- MOVE 12 TO W-MMTERVIG */
                    _.Move(12, W_DTTERVIG.W_MMTERVIG);

                    /*" -4030- SUBTRACT 1 FROM W-AATERVIG */
                    W_DTTERVIG.W_AATERVIG.Value = W_DTTERVIG.W_AATERVIG - 1;

                    /*" -4031- END-IF */
                }


                /*" -4032- ELSE */
            }
            else
            {


                /*" -4034- MOVE W-DIA TO W-DDTERVIG. */
                _.Move(W_DATA_EDITADA.W_DIA, W_DTTERVIG.W_DDTERVIG);
            }


            /*" -4035- MOVE W-DDTERVIG TO W-DD */
            _.Move(W_DTTERVIG.W_DDTERVIG, W_DATA.W_DD);

            /*" -4036- MOVE W-MMTERVIG TO W-MM */
            _.Move(W_DTTERVIG.W_MMTERVIG, W_DATA.W_MM);

            /*" -4037- MOVE W-AATERVIG TO W-AA */
            _.Move(W_DTTERVIG.W_AATERVIG, W_DATA.W_AA);

            /*" -4039- MOVE W-DATA TO EM0925-DATA02 */
            _.Move(W_DATA, EM0925W099.EM0925_DATA02);

            /*" -4041- MOVE ZEROS TO EM0925-QTMES */
            _.Move(0, EM0925W099.EM0925_QTMES);

            /*" -4056- CALL 'EM0925S' USING EM0925W099 */
            _.Call("EM0925S", EM0925W099);

            /*" -4066- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -4067- MOVE ENDO-QTPARCEL TO EM0925-QTMES */
                _.Move(ENDO_QTPARCEL, EM0925W099.EM0925_QTMES);

                /*" -4069- END-IF */
            }


            /*" -4073- IF (ENDO-COD-USUARIO EQUAL 'SAS6239' AND (ENDO-CODPRODU EQUAL 1601 OR 1801) AND ENDO-COD-EMPRESA EQUAL 0) NEXT SENTENCE */

            if ((ENDO_COD_USUARIO == "SAS6239" && (ENDO_CODPRODU.In("1601", "1801")) && ENDO_COD_EMPRESA == 0))
            {

                /*" -4074- ELSE */
            }
            else
            {


                /*" -4075- IF EM0925-QTMES LESS ENDO-QTPARCEL */

                if (EM0925W099.EM0925_QTMES < ENDO_QTPARCEL)
                {

                    /*" -4082- DISPLAY 'EM0010B - QTDE DE MESES MENOR QUE DE PARCELAS' ' MESES ' EM0925-QTMES ' PARCELA ' ENDO-QTPARCEL ' APOLICE ' ENDO-NUM-APOLICE ' ENDOSSO ' ENDO-NRENDOS ' FONTE ' ENDO-FONTE ' PROPOSTA ' ENDO-NRPROPOS */

                    $"EM0010B - QTDE DE MESES MENOR QUE DE PARCELAS MESES {EM0925W099.EM0925_QTMES} PARCELA {ENDO_QTPARCEL} APOLICE {ENDO_NUM_APOLICE} ENDOSSO {ENDO_NRENDOS} FONTE {ENDO_FONTE} PROPOSTA {ENDO_NRPROPOS}"
                    .Display();

                    /*" -4083- DISPLAY '***************   ATENCAO  ****************' */
                    _.Display($"***************   ATENCAO  ****************");

                    /*" -4084- DISPLAY 'SR. OPERADOR :                             ' */
                    _.Display($"SR. OPERADOR :                             ");

                    /*" -4085- DISPLAY 'O ABEND CAUSADO NO PROGRAMA POR ESTE MOTIVO' */
                    _.Display($"O ABEND CAUSADO NO PROGRAMA POR ESTE MOTIVO");

                    /*" -4086- DISPLAY 'PERMITE QUE O PROGRAMA SEJA REESTARTADO.   ' */
                    _.Display($"PERMITE QUE O PROGRAMA SEJA REESTARTADO.   ");

                    /*" -4087- DISPLAY 'POR FAVOR QUEIRA REESTARTA-LO.             ' */
                    _.Display($"POR FAVOR QUEIRA REESTARTA-LO.             ");

                    /*" -4088- DISPLAY '                                           ' */
                    _.Display($"                                           ");

                    /*" -4089- DISPLAY ' ESTE ABEND DEVERA CONSTAR NO NOTES ENVIADO' */
                    _.Display($" ESTE ABEND DEVERA CONSTAR NO NOTES ENVIADO");

                    /*" -4090- DISPLAY 'DIARIAMENTE PELA PRODUCAO A DESENVOLVIMENTO' */
                    _.Display($"DIARIAMENTE PELA PRODUCAO A DESENVOLVIMENTO");

                    /*" -4091- DISPLAY '                                           ' */
                    _.Display($"                                           ");

                    /*" -4092- DISPLAY ' COM CONHECIMENTO DO ANALISTA RESPONSAVEL  ' */
                    _.Display($" COM CONHECIMENTO DO ANALISTA RESPONSAVEL  ");

                    /*" -4093- DISPLAY '*******************************************' */
                    _.Display($"*******************************************");

                    /*" -4095- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -4096- MOVE W-DATA-EDITADA TO HIST-DTVENCTO. */
            _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

            /*" -4096- MOVE 'B2012-VENCIMENTO-2A-PARCELA' TO WS-MOV-DTVENCTO. */
            _.Move("B2012-VENCIMENTO-2A-PARCELA", WS_MOV_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2012_999_EXIT*/

        [StopWatch]
        /*" B2013-VENCIMENTO-DEMAIS-SECTION */
        private void B2013_VENCIMENTO_DEMAIS_SECTION()
        {
            /*" -4110- MOVE 'B2013' TO WNR-EXEC-SQL. */
            _.Move("B2013", WABEND.WNR_EXEC_SQL);

            /*" -4111- PERFORM B2014-SOMA-1-MES */

            B2014_SOMA_1_MES_SECTION();

            /*" -4113- PERFORM B2017-VERIFICA-DIA-BASE */

            B2017_VERIFICA_DIA_BASE_SECTION();

            /*" -4114- MOVE W-DATA-EDITADA TO HIST-DTVENCTO. */
            _.Move(W_DATA_EDITADA, HIST_DTVENCTO);

            /*" -4114- MOVE 'B2013-VENCIMENTO-DEMAIS' TO WS-MOV-DTVENCTO. */
            _.Move("B2013-VENCIMENTO-DEMAIS", WS_MOV_DTVENCTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2013_999_EXIT*/

        [StopWatch]
        /*" B2014-SOMA-1-MES-SECTION */
        private void B2014_SOMA_1_MES_SECTION()
        {
            /*" -4127- MOVE 'B2014' TO WNR-EXEC-SQL. */
            _.Move("B2014", WABEND.WNR_EXEC_SQL);

            /*" -4129- ADD 1 TO W-MES. */
            W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

            /*" -4130- IF W-MES GREATER 12 */

            if (W_DATA_EDITADA.W_MES > 12)
            {

                /*" -4131- MOVE 1 TO W-MES */
                _.Move(1, W_DATA_EDITADA.W_MES);

                /*" -4131- ADD 1 TO W-ANO. */
                W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2014_999_EXIT*/

        [StopWatch]
        /*" B2015-VERIFICA-ULTIMO-DIA-SECTION */
        private void B2015_VERIFICA_ULTIMO_DIA_SECTION()
        {
            /*" -4144- MOVE 'B2015' TO WNR-EXEC-SQL. */
            _.Move("B2015", WABEND.WNR_EXEC_SQL);

            /*" -4145- IF W-MES EQUAL 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (W_DATA_EDITADA.W_MES.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -4146- MOVE 31 TO W-ULTIMO-DIA */
                _.Move(31, W_ULTIMO_DIA);

                /*" -4147- ELSE */
            }
            else
            {


                /*" -4148- IF W-MES EQUAL 4 OR 6 OR 9 OR 11 */

                if (W_DATA_EDITADA.W_MES.In("4", "6", "9", "11"))
                {

                    /*" -4149- MOVE 30 TO W-ULTIMO-DIA */
                    _.Move(30, W_ULTIMO_DIA);

                    /*" -4150- ELSE */
                }
                else
                {


                    /*" -4154- DIVIDE W-ANO BY 4 GIVING W-INTEIRO REMAINDER W-RESTO */
                    _.Divide(W_DATA_EDITADA.W_ANO, 4, W_INTEIRO, W_RESTO);

                    /*" -4155- IF W-RESTO EQUAL ZEROS */

                    if (W_RESTO == 00)
                    {

                        /*" -4156- MOVE 29 TO W-ULTIMO-DIA */
                        _.Move(29, W_ULTIMO_DIA);

                        /*" -4157- ELSE */
                    }
                    else
                    {


                        /*" -4161- MOVE 28 TO W-ULTIMO-DIA. */
                        _.Move(28, W_ULTIMO_DIA);
                    }

                }

            }


            /*" -4162- IF W-DIA GREATER W-ULTIMO-DIA */

            if (W_DATA_EDITADA.W_DIA > W_ULTIMO_DIA)
            {

                /*" -4162- MOVE W-ULTIMO-DIA TO W-DIA. */
                _.Move(W_ULTIMO_DIA, W_DATA_EDITADA.W_DIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2015_999_EXIT*/

        [StopWatch]
        /*" B2016-VERIFICA-DATA-MINIMA-SECTION */
        private void B2016_VERIFICA_DATA_MINIMA_SECTION()
        {
            /*" -4174- MOVE 'B2016' TO WNR-EXEC-SQL. */
            _.Move("B2016", WABEND.WNR_EXEC_SQL);

            /*" -4175- IF (ENDO-CODPRODU = 1803 OR 1805) AND (ENDO-NRENDOS = 0) */

            if ((ENDO_CODPRODU.In("1803", "1805")) && (ENDO_NRENDOS == 0))
            {

                /*" -4176- GO TO B2016-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2016_999_EXIT*/ //GOTO
                return;

                /*" -4187- END-IF */
            }


            /*" -4188- IF VIND-DTVENCTO NOT EQUAL -1 */

            if (VIND_DTVENCTO != -1)
            {

                /*" -4189- IF W-DATA-EDITADA LESS W-DATA-MIN-1 */

                if (W_DATA_EDITADA < W_DATA_MIN_1)
                {

                    /*" -4190- MOVE W-DATA-MIN-1 TO W-DATA-EDITADA */
                    _.Move(W_DATA_MIN_1, W_DATA_EDITADA);

                    /*" -4191- END-IF */
                }


                /*" -4192- ELSE */
            }
            else
            {


                /*" -4193- IF PRCB-TIPO-COBRANCA EQUAL '1' OR '2' */

                if (PRCB_TIPO_COBRANCA.In("1", "2"))
                {

                    /*" -4194- IF W-DATA-EDITADA LESS W-DATA-MIN-2 */

                    if (W_DATA_EDITADA < W_DATA_MIN_2)
                    {

                        /*" -4195- MOVE W-DATA-MIN-2 TO W-DATA-EDITADA */
                        _.Move(W_DATA_MIN_2, W_DATA_EDITADA);

                        /*" -4196- END-IF */
                    }


                    /*" -4197- ELSE */
                }
                else
                {


                    /*" -4198- IF W-DATA-EDITADA LESS W-DATA-MIN-15 */

                    if (W_DATA_EDITADA < W_DATA_MIN_15)
                    {

                        /*" -4199- MOVE W-DATA-MIN-15 TO W-DATA-EDITADA */
                        _.Move(W_DATA_MIN_15, W_DATA_EDITADA);

                        /*" -4200- END-IF */
                    }


                    /*" -4201- END-IF */
                }


                /*" -4203- END-IF */
            }


            /*" -4203- PERFORM B2017-VERIFICA-DIA-BASE. */

            B2017_VERIFICA_DIA_BASE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2016_999_EXIT*/

        [StopWatch]
        /*" B2017-VERIFICA-DIA-BASE-SECTION */
        private void B2017_VERIFICA_DIA_BASE_SECTION()
        {
            /*" -4217- MOVE 'B2017' TO WNR-EXEC-SQL. */
            _.Move("B2017", WABEND.WNR_EXEC_SQL);

            /*" -4218- IF W-DIA-BASE LESS W-DIA */

            if (W_DIA_BASE < W_DATA_EDITADA.W_DIA)
            {

                /*" -4220- PERFORM B2014-SOMA-1-MES. */

                B2014_SOMA_1_MES_SECTION();
            }


            /*" -4222- MOVE W-DIA-BASE TO W-DIA */
            _.Move(W_DIA_BASE, W_DATA_EDITADA.W_DIA);

            /*" -4222- PERFORM B2015-VERIFICA-ULTIMO-DIA. */

            B2015_VERIFICA_ULTIMO_DIA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2017_999_EXIT*/

        [StopWatch]
        /*" B2018-RECUPERA-AU084-SECTION */
        private void B2018_RECUPERA_AU084_SECTION()
        {
            /*" -4233- MOVE 'B2018' TO WNR-EXEC-SQL. */
            _.Move("B2018", WABEND.WNR_EXEC_SQL);

            /*" -4240- PERFORM B2018_RECUPERA_AU084_DB_SELECT_1 */

            B2018_RECUPERA_AU084_DB_SELECT_1();

            /*" -4243- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4244- DISPLAY 'ERRO SELECT AU_APOLICE_COMPL' */
                _.Display($"ERRO SELECT AU_APOLICE_COMPL");

                /*" -4244- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2018-RECUPERA-AU084-DB-SELECT-1 */
        public void B2018_RECUPERA_AU084_DB_SELECT_1()
        {
            /*" -4240- EXEC SQL SELECT IND_FORMA_PAGTO_AD INTO :AU084-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_APOLICE_COMPL WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS WITH UR END-EXEC. */

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
            /*" -4255- MOVE 'B2020' TO WNR-EXEC-SQL. */
            _.Move("B2020", WABEND.WNR_EXEC_SQL);

            /*" -4271- PERFORM B2020_SELECT_MR021_DB_SELECT_1 */

            B2020_SELECT_MR021_DB_SELECT_1();

            /*" -4274- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4275- DISPLAY 'ERRO SELECT MR_APOL_ITEM_COND' */
                _.Display($"ERRO SELECT MR_APOL_ITEM_COND");

                /*" -4275- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2020-SELECT-MR021-DB-SELECT-1 */
        public void B2020_SELECT_MR021_DB_SELECT_1()
        {
            /*" -4271- EXEC SQL SELECT VALUE(A.PCT_DESC_COBERTURA,0), VALUE(A.PCT_BONUS_RENOVCAO,0), VALUE(A.PCT_DESC_CORRETOR,0) INTO :MR021-PCT-DESC-COBERTURA, :MR021-PCT-BONUS-RENOVCAO, :MR021-PCT-DESC-CORRETOR FROM SEGUROS.MR_APOL_ITEM_COND A WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDO-NRENDOS AND A.NUM_ITEM = (SELECT MAX(B.NUM_ITEM) FROM SEGUROS.MR_APOL_ITEM_COND B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO) WITH UR END-EXEC. */

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
            /*" -4287- MOVE 'B2025' TO WNR-EXEC-SQL. */
            _.Move("B2025", WABEND.WNR_EXEC_SQL);

            /*" -4297- PERFORM B2025_TRATA_2PCELA_CCA_DB_SELECT_1 */

            B2025_TRATA_2PCELA_CCA_DB_SELECT_1();

            /*" -4300- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4301- DISPLAY 'ERRO SELECT LT_SOLICITA_PARAM' */
                _.Display($"ERRO SELECT LT_SOLICITA_PARAM");

                /*" -4303- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4306- IF LTMVPROP-DT-INIVIG-PROPOSTA >= '2015-11-01' AND ENDO-NRRCAP GREATER ZEROS */

            if (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA >= "2015-11-01" && ENDO_NRRCAP > 00)
            {

                /*" -4307- DISPLAY 'AQUI ESTOU 5 ' W-DATA-EDITADA */
                _.Display($"AQUI ESTOU 5 {W_DATA_EDITADA}");

                /*" -4308- PERFORM B2014-SOMA-1-MES */

                B2014_SOMA_1_MES_SECTION();

                /*" -4310- END-IF */
            }


            /*" -4311- IF LTSOLPAR-PARAM-DATE03 GREATER LTMVPROP-DT-INIVIG-PROPOSTA */

            if (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03 > LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA)
            {

                /*" -4313- MOVE 01 TO W-DIA W-DIA-BASE */
                _.Move(01, W_DATA_EDITADA.W_DIA, W_DIA_BASE);

                /*" -4315- END-IF. */
            }


            /*" -4315- MOVE W-DATA-EDITADA TO ENDO-DTVENCTO. */
            _.Move(W_DATA_EDITADA, ENDO_DTVENCTO);

        }

        [StopWatch]
        /*" B2025-TRATA-2PCELA-CCA-DB-SELECT-1 */
        public void B2025_TRATA_2PCELA_CCA_DB_SELECT_1()
        {
            /*" -4297- EXEC SQL SELECT PARAM_DATE03 INTO :LTSOLPAR-PARAM-DATE03 FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = 'SPBLTPRM' AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO AND PARAM_SMINT01 = 74 AND :LTMVPROP-DT-INIVIG-PROPOSTA BETWEEN PARAM_DATE01 AND PARAM_DATE02 WITH UR END-EXEC */

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
            /*" -4328- MOVE 'B2030' TO WNR-EXEC-SQL. */
            _.Move("B2030", WABEND.WNR_EXEC_SQL);

            /*" -4350- PERFORM B2030_SELECT_MR022_DB_SELECT_1 */

            B2030_SELECT_MR022_DB_SELECT_1();

            /*" -4353- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4354- DISPLAY 'ERRO SELECT MR_APOL_ITEM_EMPR' */
                _.Display($"ERRO SELECT MR_APOL_ITEM_EMPR");

                /*" -4354- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2030-SELECT-MR022-DB-SELECT-1 */
        public void B2030_SELECT_MR022_DB_SELECT_1()
        {
            /*" -4350- EXEC SQL SELECT VALUE(A.PCT_DESC_COBERTURA,0), VALUE(A.PCT_BONUS_RENOVCAO,0), VALUE(A.PCT_DESC_CORRETOR,0) INTO :MR022-PCT-DESC-COBERTURA, :MR022-PCT-BONUS-RENOVCAO, :MR022-PCT-DESC-CORRETOR FROM SEGUROS.MR_APOL_ITEM_EMPR A WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDO-NRENDOS AND A.NUM_ITEM = (SELECT MAX(B.NUM_ITEM) FROM SEGUROS.MR_APOL_ITEM_EMPR B WHERE B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO) AND A.NUM_SUB_ITEM = (SELECT MAX(C.NUM_SUB_ITEM) FROM SEGUROS.MR_APOL_ITEM_EMPR C WHERE C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = A.NUM_ENDOSSO AND C.NUM_ITEM = A.NUM_ITEM) WITH UR END-EXEC. */

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
            /*" -4365- MOVE 'B2031' TO WNR-EXEC-SQL. */
            _.Move("B2031", WABEND.WNR_EXEC_SQL);

            /*" -4374- PERFORM B2031_SELECT_MRAPOITE_DB_SELECT_1 */

            B2031_SELECT_MRAPOITE_DB_SELECT_1();

            /*" -4377- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4380- DISPLAY 'ERRO SELECT MR_APOLICE_ITEM' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $"ERRO SELECT MR_APOLICE_ITEM {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -4380- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2031-SELECT-MRAPOITE-DB-SELECT-1 */
        public void B2031_SELECT_MRAPOITE_DB_SELECT_1()
        {
            /*" -4374- EXEC SQL SELECT VALUE(MAX(PCT_DESC_FIDEL),0), VALUE(MAX(PCT_DESC_COMERCIAL),0) INTO :MRAPOITE-PCT-DESC-FIDEL , :MRAPOITE-PCT-DESC-COMERCIAL FROM SEGUROS.MR_APOLICE_ITEM WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS WITH UR END-EXEC. */

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
            /*" -4391- MOVE 'B2035' TO WNR-EXEC-SQL. */
            _.Move("B2035", WABEND.WNR_EXEC_SQL);

            /*" -4399- PERFORM B2035_SELECT_MRAPOCOB_DB_SELECT_1 */

            B2035_SELECT_MRAPOCOB_DB_SELECT_1();

            /*" -4402- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4403- DISPLAY 'ERRO SELECT MR_APOLICE_COBER' */
                _.Display($"ERRO SELECT MR_APOLICE_COBER");

                /*" -4403- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2035-SELECT-MRAPOCOB-DB-SELECT-1 */
        public void B2035_SELECT_MRAPOCOB_DB_SELECT_1()
        {
            /*" -4399- EXEC SQL SELECT VALUE(SUM(A.PRM_TARIFARIO_IX),0) INTO :MRAPOCOB-PRM-TARIFARIO-IX FROM SEGUROS.MR_APOLICE_COBER A WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDO-NRENDOS AND A.COD_COBERTURA = 99 WITH UR END-EXEC. */

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
            /*" -4413- MOVE 'B2040' TO WNR-EXEC-SQL. */
            _.Move("B2040", WABEND.WNR_EXEC_SQL);

            /*" -4421- PERFORM B2040_SELECT_V0APOL_HABIT_DB_SELECT_1 */

            B2040_SELECT_V0APOL_HABIT_DB_SELECT_1();

            /*" -4424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4425- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4426- MOVE 'N' TO WCH-APOL-HABIT */
                    _.Move("N", WS000_AREA_AUX_RAMO68.WCH_APOL_HABIT);

                    /*" -4427- GO TO B2040-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: B2040_999_EXIT*/ //GOTO
                    return;

                    /*" -4428- ELSE */
                }
                else
                {


                    /*" -4429- DISPLAY 'ERRO SELECT V0APOL-HABIT' */
                    _.Display($"ERRO SELECT V0APOL-HABIT");

                    /*" -4429- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B2040-SELECT-V0APOL-HABIT-DB-SELECT-1 */
        public void B2040_SELECT_V0APOL_HABIT_DB_SELECT_1()
        {
            /*" -4421- EXEC SQL SELECT A.CODCLIEN INTO :V0PRHA-CODCLIEN FROM SEGUROS.V0APOLICE A, SEGUROS.V0APOLICE_HABIT B WHERE B.NUM_APOLICE = :ENDO-NUM-APOLICE AND B.NUM_APOLICE = A.NUM_APOLICE WITH UR END-EXEC. */

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
            /*" -4440- MOVE 'B2050' TO WNR-EXEC-SQL. */
            _.Move("B2050", WABEND.WNR_EXEC_SQL);

            /*" -4441- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -4443- PERFORM B2051-MONTA-VENCIMENTOS. */

                B2051_MONTA_VENCIMENTOS_SECTION();
            }


            /*" -4444- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -4444- MOVE TBV-DT-VENC-PAR(IX1) TO W-DATA-EDITADA. */
            _.Move(VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_PAR, W_DATA_EDITADA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2050_999_EXIT*/

        [StopWatch]
        /*" B2051-MONTA-VENCIMENTOS-SECTION */
        private void B2051_MONTA_VENCIMENTOS_SECTION()
        {
            /*" -4454- MOVE 'B2051' TO WNR-EXEC-SQL. */
            _.Move("B2051", WABEND.WNR_EXEC_SQL);

            /*" -4456- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
            _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

            /*" -4457- MOVE W-DIA TO W-DD */
            _.Move(W_DATA_EDITADA.W_DIA, W_DATA.W_DD);

            /*" -4458- MOVE W-MES TO W-MM */
            _.Move(W_DATA_EDITADA.W_MES, W_DATA.W_MM);

            /*" -4459- MOVE W-ANO TO W-AA */
            _.Move(W_DATA_EDITADA.W_ANO, W_DATA.W_AA);

            /*" -4460- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -4461- MOVE 15 TO PROSOM-QTDIA */
            _.Move(15, PROSOMW099.PROSOM_QTDIA);

            /*" -4463- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -4465- CALL 'PROSOMC1' USING PROSOMW099 */
            _.Call("PROSOMC1", PROSOMW099);

            /*" -4466- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -4467- MOVE W-AA TO W-ANO-M15 */
            _.Move(W_DATA.W_AA, VENCIMENTOS.W_DATA_M15.W_ANO_M15);

            /*" -4468- MOVE W-MM TO W-MES-M15 */
            _.Move(W_DATA.W_MM, VENCIMENTOS.W_DATA_M15.W_MES_M15);

            /*" -4470- MOVE W-DD TO W-DIA-M15. */
            _.Move(W_DATA.W_DD, VENCIMENTOS.W_DATA_M15.W_DIA_M15);

            /*" -4471- MOVE W-ANO-M15 TO WC-ANO */
            _.Move(VENCIMENTOS.W_DATA_M15.W_ANO_M15, VENCIMENTOS.FILLER_25.WC_ANO);

            /*" -4472- MOVE W-MES-M15 TO WC-MES */
            _.Move(VENCIMENTOS.W_DATA_M15.W_MES_M15, VENCIMENTOS.FILLER_25.WC_MES);

            /*" -4473- MOVE W-DIA-DEBITO TO W-DIA-M15 */
            _.Move(VENCIMENTOS.W_DIA_DEBITO, VENCIMENTOS.W_DATA_M15.W_DIA_M15);

            /*" -4474- MOVE W-DIA-M15 TO WC-DIA */
            _.Move(VENCIMENTOS.W_DATA_M15.W_DIA_M15, VENCIMENTOS.FILLER_25.WC_DIA);

            /*" -4476- MOVE WC-DATA TO LDIFE01. */
            _.Move(VENCIMENTOS.WC_DATA, VENCIMENTOS.LDIFE.LDIFE01);

            /*" -4477- MOVE W-ANO-M15 TO W-ANO-DEB */
            _.Move(VENCIMENTOS.W_DATA_M15.W_ANO_M15, W_DATA_DEBITO.W_ANO_DEB);

            /*" -4478- MOVE W-MES-M15 TO W-MES-DEB */
            _.Move(VENCIMENTOS.W_DATA_M15.W_MES_M15, W_DATA_DEBITO.W_MES_DEB);

            /*" -4480- MOVE W-DIA-M15 TO W-DIA-DEB */
            _.Move(VENCIMENTOS.W_DATA_M15.W_DIA_M15, W_DATA_DEBITO.W_DIA_DEB);

            /*" -4481- MOVE W-DIA TO WC-DIA */
            _.Move(W_DATA_EDITADA.W_DIA, VENCIMENTOS.FILLER_25.WC_DIA);

            /*" -4482- MOVE W-MES TO WC-MES */
            _.Move(W_DATA_EDITADA.W_MES, VENCIMENTOS.FILLER_25.WC_MES);

            /*" -4483- MOVE W-ANO TO WC-ANO */
            _.Move(W_DATA_EDITADA.W_ANO, VENCIMENTOS.FILLER_25.WC_ANO);

            /*" -4485- MOVE WC-DATA TO LDIFE02. */
            _.Move(VENCIMENTOS.WC_DATA, VENCIMENTOS.LDIFE.LDIFE02);

            /*" -4487- MOVE ZEROS TO LDIFE03. */
            _.Move(0, VENCIMENTOS.LDIFE.LDIFE03);

            /*" -4491- CALL 'PRODIFC1' USING LDIFE. */
            _.Call("PRODIFC1", VENCIMENTOS.LDIFE);

            /*" -4492- IF LDIFE03 NOT > 15 */

            if (VENCIMENTOS.LDIFE.LDIFE03 <= 15)
            {

                /*" -4493- MOVE W-DATA-M15 TO W-DATA-EDITADA */
                _.Move(VENCIMENTOS.W_DATA_M15, W_DATA_EDITADA);

                /*" -4494- MOVE W-DIA-DEBITO TO W-DIA */
                _.Move(VENCIMENTOS.W_DIA_DEBITO, W_DATA_EDITADA.W_DIA);

                /*" -4495- ADD 1 TO W-MES */
                W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                /*" -4496- IF W-MES GREATER 12 */

                if (W_DATA_EDITADA.W_MES > 12)
                {

                    /*" -4497- MOVE 1 TO W-MES */
                    _.Move(1, W_DATA_EDITADA.W_MES);

                    /*" -4498- ADD 1 TO W-ANO */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                    /*" -4499- END-IF */
                }


                /*" -4500- MOVE W-DATA-EDITADA TO W-DATA-DEBITO */
                _.Move(W_DATA_EDITADA, W_DATA_DEBITO);

                /*" -4501- ELSE */
            }
            else
            {


                /*" -4502- MOVE W-DIA-DEBITO TO W-DIA */
                _.Move(VENCIMENTOS.W_DIA_DEBITO, W_DATA_EDITADA.W_DIA);

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


                /*" -4517- MOVE W-DATA-EDITADA TO W-DATA-DEBITO. */
                _.Move(W_DATA_EDITADA, W_DATA_DEBITO);
            }


            /*" -4519- IF AU085-IND-FORMA-PAGTO-AD NOT EQUAL '4' */

            if (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD != "4")
            {

                /*" -4520- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA */
                _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);

                /*" -4521- ELSE */
            }
            else
            {


                /*" -4522- IF W-DATA-M15 GREATER ENDO-DTVENCTO */

                if (VENCIMENTOS.W_DATA_M15 > ENDO_DTVENCTO)
                {

                    /*" -4524- MOVE ENDO-DTVENCTO TO W-DATA-EDITADA. */
                    _.Move(ENDO_DTVENCTO, W_DATA_EDITADA);
                }

            }


            /*" -4524- PERFORM B2052-CALCULA-DATAS. */

            B2052_CALCULA_DATAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2051_999_EXIT*/

        [StopWatch]
        /*" B2052-CALCULA-DATAS-SECTION */
        private void B2052_CALCULA_DATAS_SECTION()
        {
            /*" -4534- MOVE 'B2052' TO WNR-EXEC-SQL. */
            _.Move("B2052", WABEND.WNR_EXEC_SQL);

            /*" -4536- MOVE TBVEN-MASCARA TO TBVEN-DATAS. */
            _.Move(VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS);

            /*" -4538- PERFORM B2053-SOMA-MESES. */

            B2053_SOMA_MESES_SECTION();

            /*" -4538- PERFORM B2055-VENCIMENTOS. */

            B2055_VENCIMENTOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2052_999_EXIT*/

        [StopWatch]
        /*" B2053-SOMA-MESES-SECTION */
        private void B2053_SOMA_MESES_SECTION()
        {
            /*" -4547- MOVE 'B2053' TO WNR-EXEC-SQL. */
            _.Move("B2053", WABEND.WNR_EXEC_SQL);

            /*" -4548- SET IX1 TO WZEROS. */
            IX1.Value = WZEROS;

            /*" -4548- MOVE ZEROS TO WTBV-NUM-PARCELA. */
            _.Move(0, VENCIMENTOS.WTBV_NUM_PARCELA);

            /*" -0- FLUXCONTROL_PERFORM B2053_LOOP */

            B2053_LOOP();

        }

        [StopWatch]
        /*" B2053-LOOP */
        private void B2053_LOOP(bool isPerform = false)
        {
            /*" -4553- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -4554- IF IX1 GREATER +12 */

            if (IX1 > +12)
            {

                /*" -4556- GO TO B2053-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2053_999_EXIT*/ //GOTO
                return;
            }


            /*" -4557- IF IX1 GREATER +1 */

            if (IX1 > +1)
            {

                /*" -4558- IF IX1 EQUAL +2 */

                if (IX1 == +2)
                {

                    /*" -4560- IF W-DIA-DEBITO GREATER W-DIA-M15 AND W-MES-M15 EQUAL W-MES */

                    if (VENCIMENTOS.W_DIA_DEBITO > VENCIMENTOS.W_DATA_M15.W_DIA_M15 && VENCIMENTOS.W_DATA_M15.W_MES_M15 == W_DATA_EDITADA.W_MES)
                    {

                        /*" -4561- MOVE W-DIA-DEBITO TO W-DIA */
                        _.Move(VENCIMENTOS.W_DIA_DEBITO, W_DATA_EDITADA.W_DIA);

                        /*" -4563- IF W-DATA-EDITADA EQUAL TBV-DT-VENC-CLC(1) */

                        if (W_DATA_EDITADA == VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[1].TBV_DT_VENC_CLC)
                        {

                            /*" -4564- ADD 1 TO W-MES */
                            W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                            /*" -4565- IF W-MES GREATER 12 */

                            if (W_DATA_EDITADA.W_MES > 12)
                            {

                                /*" -4566- MOVE 1 TO W-MES */
                                _.Move(1, W_DATA_EDITADA.W_MES);

                                /*" -4567- ADD 1 TO W-ANO */
                                W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                                /*" -4568- END-IF */
                            }


                            /*" -4569- END-IF */
                        }


                        /*" -4570- ELSE */
                    }
                    else
                    {


                        /*" -4571- MOVE W-DATA-DEBITO TO W-DATA-EDITADA */
                        _.Move(W_DATA_DEBITO, W_DATA_EDITADA);

                        /*" -4573- IF W-DATA-EDITADA EQUAL TBV-DT-VENC-CLC(1) */

                        if (W_DATA_EDITADA == VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[1].TBV_DT_VENC_CLC)
                        {

                            /*" -4574- ADD 1 TO W-MES */
                            W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                            /*" -4575- IF W-MES GREATER 12 */

                            if (W_DATA_EDITADA.W_MES > 12)
                            {

                                /*" -4576- MOVE 1 TO W-MES */
                                _.Move(1, W_DATA_EDITADA.W_MES);

                                /*" -4577- ADD 1 TO W-ANO */
                                W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;

                                /*" -4578- END-IF */
                            }


                            /*" -4579- END-IF */
                        }


                        /*" -4580- ELSE */
                    }

                }
                else
                {


                    /*" -4581- ADD 1 TO W-MES */
                    W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                    /*" -4582- IF W-MES GREATER 12 */

                    if (W_DATA_EDITADA.W_MES > 12)
                    {

                        /*" -4583- MOVE 1 TO W-MES */
                        _.Move(1, W_DATA_EDITADA.W_MES);

                        /*" -4585- ADD 1 TO W-ANO. */
                        W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;
                    }

                }

            }


            /*" -4587- PERFORM B2054-ULTIMO-DIA */

            B2054_ULTIMO_DIA_SECTION();

            /*" -4588- ADD 1 TO WTBV-NUM-PARCELA. */
            VENCIMENTOS.WTBV_NUM_PARCELA.Value = VENCIMENTOS.WTBV_NUM_PARCELA + 1;

            /*" -4589- MOVE WTBV-NUM-PARCELA TO TBV-NUM-PARCELA(IX1). */
            _.Move(VENCIMENTOS.WTBV_NUM_PARCELA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_NUM_PARCELA);

            /*" -4590- MOVE W-DATA-EDITADA TO TBV-DT-VENC-CLC(IX1). */
            _.Move(W_DATA_EDITADA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_CLC);

            /*" -4592- MOVE W-ULTIMO-DIA TO TBV-DIA-MES(IX1). */
            _.Move(W_ULTIMO_DIA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DIA_MES);

            /*" -4592- GO TO B2053-LOOP. */
            new Task(() => B2053_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2053_999_EXIT*/

        [StopWatch]
        /*" B2054-ULTIMO-DIA-SECTION */
        private void B2054_ULTIMO_DIA_SECTION()
        {
            /*" -4602- MOVE 'B2054' TO WNR-EXEC-SQL. */
            _.Move("B2054", WABEND.WNR_EXEC_SQL);

            /*" -4604- IF W-MES EQUAL 1 OR 3 OR 5 OR 7 OR 8 OR 10 OR 12 */

            if (W_DATA_EDITADA.W_MES.In("1", "3", "5", "7", "8", "10", "12"))
            {

                /*" -4605- MOVE 31 TO W-ULTIMO-DIA */
                _.Move(31, W_ULTIMO_DIA);

                /*" -4606- ELSE */
            }
            else
            {


                /*" -4607- IF W-MES EQUAL 4 OR 6 OR 9 OR 11 */

                if (W_DATA_EDITADA.W_MES.In("4", "6", "9", "11"))
                {

                    /*" -4608- MOVE 30 TO W-ULTIMO-DIA */
                    _.Move(30, W_ULTIMO_DIA);

                    /*" -4609- ELSE */
                }
                else
                {


                    /*" -4612- DIVIDE W-ANO BY 4 GIVING W-INTEIRO REMAINDER W-RESTO */
                    _.Divide(W_DATA_EDITADA.W_ANO, 4, W_INTEIRO, W_RESTO);

                    /*" -4613- IF W-RESTO EQUAL ZEROS */

                    if (W_RESTO == 00)
                    {

                        /*" -4614- MOVE 29 TO W-ULTIMO-DIA */
                        _.Move(29, W_ULTIMO_DIA);

                        /*" -4615- ELSE */
                    }
                    else
                    {


                        /*" -4615- MOVE 28 TO W-ULTIMO-DIA. */
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
            /*" -4624- MOVE 'B2055' TO WNR-EXEC-SQL. */
            _.Move("B2055", WABEND.WNR_EXEC_SQL);

            /*" -4624- SET IX1 TO WZEROS. */
            IX1.Value = WZEROS;

            /*" -0- FLUXCONTROL_PERFORM B2055_LOOP */

            B2055_LOOP();

        }

        [StopWatch]
        /*" B2055-LOOP */
        private void B2055_LOOP(bool isPerform = false)
        {
            /*" -4629- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -4630- IF IX1 GREATER +12 */

            if (IX1 > +12)
            {

                /*" -4631- SET IX1 TO WZEROS */
                IX1.Value = WZEROS;

                /*" -4633- GO TO B2055-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2055_999_EXIT*/ //GOTO
                return;
            }


            /*" -4634- MOVE TBV-DT-VENC-CLC(IX1) TO W-DATA-EDITADA */
            _.Move(VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_CLC, W_DATA_EDITADA);

            /*" -4636- IF W-DIA GREATER TBV-DIA-MES(IX1) */

            if (W_DATA_EDITADA.W_DIA > VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DIA_MES)
            {

                /*" -4637- MOVE 1 TO W-DIA */
                _.Move(1, W_DATA_EDITADA.W_DIA);

                /*" -4638- ADD 1 TO W-MES */
                W_DATA_EDITADA.W_MES.Value = W_DATA_EDITADA.W_MES + 1;

                /*" -4639- IF W-MES GREATER 12 */

                if (W_DATA_EDITADA.W_MES > 12)
                {

                    /*" -4640- MOVE 1 TO W-MES */
                    _.Move(1, W_DATA_EDITADA.W_MES);

                    /*" -4642- ADD 1 TO W-ANO. */
                    W_DATA_EDITADA.W_ANO.Value = W_DATA_EDITADA.W_ANO + 1;
                }

            }


            /*" -4645- MOVE W-DATA-EDITADA TO TBV-DT-VENC-PAR(IX1). */
            _.Move(W_DATA_EDITADA, VENCIMENTOS.TABELA_VENCIMENTOS.TBVEN_MASCARA.TBVEN_DATAS.TBVEN_CAMPOS[IX1].TBV_DT_VENC_PAR);

            /*" -4645- GO TO B2055-LOOP. */
            new Task(() => B2055_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2055_999_EXIT*/

        [StopWatch]
        /*" B2060-CHAMA-LT3116S-SECTION */
        private void B2060_CHAMA_LT3116S_SECTION()
        {
            /*" -4655- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -4656- IF WS-PERIODO-RENOVACAO >= 2006 AND <= 2008 */

            if (WS_PERIODO_RENOVACAO >= 2006 && WS_PERIODO_RENOVACAO <= 2008)
            {

                /*" -4657- PERFORM B2060-CHAMA-LT3117S */

                B2060_CHAMA_LT3117S_SECTION();

                /*" -4658- ELSE */
            }
            else
            {


                /*" -4659- IF WS-PERIODO-RENOVACAO < 2021 */

                if (WS_PERIODO_RENOVACAO < 2021)
                {

                    /*" -4660- PERFORM B2060-CHAMA-LT3151S */

                    B2060_CHAMA_LT3151S_SECTION();

                    /*" -4661- ELSE */
                }
                else
                {


                    /*" -4662- PERFORM B2060-CHAMA-LT3201S */

                    B2060_CHAMA_LT3201S_SECTION();

                    /*" -4663- END-IF */
                }


                /*" -4664- END-IF */
            }


            /*" -4664- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_999_EXIT*/

        [StopWatch]
        /*" B2060-CHAMA-LT3117S-SECTION */
        private void B2060_CHAMA_LT3117S_SECTION()
        {
            /*" -4676- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -4720- MOVE ZEROS TO LKIO-PREMIO-INCENDIO LKIO-PREMIO-VALORES LKIO-PREMIO-DANELET LKIO-PREMIO-AP-EMPGDR LKIO-PREMIO-AP-EMP LKIO-PREMIO-RC LKIO-TX-PREMIO-INCENDIO LKIO-TX-PREMIO-VALORES LKIO-TX-PREMIO-DANELET LKIO-TX-PREMIO-AP-EMPGDR LKIO-TX-PREMIO-AP-EMP LKIO-TX-PREMIO-RC LKIO-VL-IS-INCENDIO LKIO-VL-IS-VALORES LKIO-VL-IS-DANELET LKIO-VL-IS-AP-EMPGDR LKIO-VL-IS-AP-EMP LKIO-VL-IS-RC LKIO-CUSTO-APOLICE LKIO-IOF-PCL1 LKIO-ADICIONAL-FRAC-PCL1 LKIO-JUROS-PCL1 LKIO-PERC-JUROS-PCL1 LKIO-VL-PREMIO-LIQ-PCL1 LKIO-VL-PREMIO-PCL1 LKIO-IOF-PCLN LKIO-ADICIONAL-FRAC-PCLN LKIO-JUROS-PCLN LKIO-PERC-JUROS-PCLN LKIO-VL-PREMIO-LIQ-PCLN LKIO-VL-PREMIO-PCLN LKIO-VL-PREMIO-TOTAL LKIO-JURO-TOTAL LKIO-IOF-TOTAL LKIO-COD-RETORNO LKIO-PREMIO-TAR-INC LKIO-PREMIO-TAR-VAL LKIO-PREMIO-TAR-DAN LKIO-PREMIO-TAR-AP-EMPGDR LKIO-PREMIO-TAR-AP-EMP LKIO-PREMIO-TAR-RC */
            _.Move(0, LBHLT027.LKIO_PREMIO_INCENDIO, LBHLT027.LKIO_PREMIO_VALORES, LBHLT027.LKIO_PREMIO_DANELET, LBHLT027.LKIO_PREMIO_AP_EMPGDR, LBHLT027.LKIO_PREMIO_AP_EMP, LBHLT027.LKIO_PREMIO_RC, LBHLT027.LKIO_TX_PREMIO_INCENDIO, LBHLT027.LKIO_TX_PREMIO_VALORES, LBHLT027.LKIO_TX_PREMIO_DANELET, LBHLT027.LKIO_TX_PREMIO_AP_EMPGDR, LBHLT027.LKIO_TX_PREMIO_AP_EMP, LBHLT027.LKIO_TX_PREMIO_RC, LBHLT027.LKIO_VL_IS_INCENDIO, LBHLT027.LKIO_VL_IS_VALORES, LBHLT027.LKIO_VL_IS_DANELET, LBHLT027.LKIO_VL_IS_AP_EMPGDR, LBHLT027.LKIO_VL_IS_AP_EMP, LBHLT027.LKIO_VL_IS_RC, LBHLT027.LKIO_CUSTO_APOLICE, LBHLT027.LKIO_IOF_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1, LBHLT027.LKIO_JUROS_PCL1, LBHLT027.LKIO_PERC_JUROS_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1, LBHLT027.LKIO_IOF_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN, LBHLT027.LKIO_JUROS_PCLN, LBHLT027.LKIO_PERC_JUROS_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_TOTAL, LBHLT027.LKIO_JURO_TOTAL, LBHLT027.LKIO_IOF_TOTAL, LBHLT027.LKIO_COD_RETORNO, LBHLT027.LKIO_PREMIO_TAR_INC, LBHLT027.LKIO_PREMIO_TAR_VAL, LBHLT027.LKIO_PREMIO_TAR_DAN, LBHLT027.LKIO_PREMIO_TAR_AP_EMPGDR, LBHLT027.LKIO_PREMIO_TAR_AP_EMP, LBHLT027.LKIO_PREMIO_TAR_RC);

            /*" -4721- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -4722- MOVE 1 TO LT3117-QTD-PARCELAS */
                _.Move(1, LBLT3117.LT3117_QTD_PARCELAS);

                /*" -4723- ELSE */
            }
            else
            {


                /*" -4725- MOVE ENDO-QTPARCEL TO LT3117-QTD-PARCELAS. */
                _.Move(ENDO_QTPARCEL, LBLT3117.LT3117_QTD_PARCELAS);
            }


            /*" -4729- PERFORM B2061-SELECT-LTMVPROP */

            B2061_SELECT_LTMVPROP_SECTION();

            /*" -4733- MOVE 0 TO LT3117-COD-RETORNO LT3117-VL-PREMIO-PCL1 LT3117-VL-PREMIO-PCLN LT3117-VL-PREMIO-TOTAL */
            _.Move(0, LBLT3117.LT3117_COD_RETORNO, LBLT3117.LT3117_VL_PREMIO_PCL1, LBLT3117.LT3117_VL_PREMIO_PCLN, LBLT3117.LT3117_VL_PREMIO_TOTAL);

            /*" -4735- MOVE LTMVPROP-VLR-CUSTO-APOLICE TO LT3117-CUSTO-APOLICE LKIO-CUSTO-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE, LBLT3117.LT3117_CUSTO_APOLICE, LBHLT027.LKIO_CUSTO_APOLICE);

            /*" -4736- MOVE LTMVPROP-PCT-JUROS TO LT3117-PCT-IOF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_JUROS, LBLT3117.LT3117_PCT_IOF);

            /*" -4737- MOVE ' ' TO LT3117-TIPO-OPERACAO */
            _.Move(" ", LBLT3117.LT3117_TIPO_OPERACAO);

            /*" -4738- MOVE ' ' TO LT3117-TIPO-CALCULO */
            _.Move(" ", LBLT3117.LT3117_TIPO_CALCULO);

            /*" -4739- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3117-COD-LOTERICO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3117.LT3117_COD_LOTERICO);

            /*" -4740- MOVE ENDO-NUM-APOLICE TO LT3117-NUM-APOLICE */
            _.Move(ENDO_NUM_APOLICE, LBLT3117.LT3117_NUM_APOLICE);

            /*" -4741- MOVE LTMVPROP-DT-INIVIG-PROPOSTA TO LT3117-DTINIVIG-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA, LBLT3117.LT3117_DTINIVIG_APOLICE);

            /*" -4743- MOVE SPACES TO LT3117-DTTERVIG-APOLICE */
            _.Move("", LBLT3117.LT3117_DTTERVIG_APOLICE);

            /*" -4749- MOVE LTMVPROP-NUM-CLASSE-ADESAO TO LT3117-NUM-CLASSE-ADESAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO, LBLT3117.LT3117_NUM_CLASSE_ADESAO);

            /*" -4750- MOVE TB-IMPSEG (01) TO LT3117-VL-IS-INCENDIO. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[01], LBLT3117.LT3117_VL_IS_INCENDIO);

            /*" -4751- MOVE TB-IMPSEG (02) TO LT3117-VL-IS-VALORES. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[02], LBLT3117.LT3117_VL_IS_VALORES);

            /*" -4752- MOVE TB-IMPSEG (03) TO LT3117-VL-IS-DANELET. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[03], LBLT3117.LT3117_VL_IS_DANELET);

            /*" -4753- MOVE TB-IMPSEG (04) TO LT3117-VL-IS-AP-EMPGDR. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[04], LBLT3117.LT3117_VL_IS_AP_EMPGDR);

            /*" -4754- MOVE TB-IMPSEG (05) TO LT3117-VL-IS-AP-EMP. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[05], LBLT3117.LT3117_VL_IS_AP_EMP);

            /*" -4756- MOVE TB-IMPSEG (06) TO LT3117-VL-IS-RC. */
            _.Move(TAB_IMPSEG.TB_IMPSEG[06], LBLT3117.LT3117_VL_IS_RC);

            /*" -4757- MOVE TB-TAXAS (01) TO LT3117-TX-INCENDIO. */
            _.Move(TAB_TAXAS.TB_TAXAS[01], LBLT3117.LT3117_TX_INCENDIO);

            /*" -4758- MOVE TB-TAXAS (02) TO LT3117-TX-VALORES. */
            _.Move(TAB_TAXAS.TB_TAXAS[02], LBLT3117.LT3117_TX_VALORES);

            /*" -4759- MOVE TB-TAXAS (03) TO LT3117-TX-DANELET. */
            _.Move(TAB_TAXAS.TB_TAXAS[03], LBLT3117.LT3117_TX_DANELET);

            /*" -4760- MOVE TB-TAXAS (04) TO LT3117-TX-AP-EMPGDR. */
            _.Move(TAB_TAXAS.TB_TAXAS[04], LBLT3117.LT3117_TX_AP_EMPGDR);

            /*" -4761- MOVE TB-TAXAS (05) TO LT3117-TX-AP-EMP. */
            _.Move(TAB_TAXAS.TB_TAXAS[05], LBLT3117.LT3117_TX_AP_EMP);

            /*" -4764- MOVE TB-TAXAS (06) TO LT3117-TX-RC. */
            _.Move(TAB_TAXAS.TB_TAXAS[06], LBLT3117.LT3117_TX_RC);

            /*" -4812- CALL 'LT3117S' USING LT3117-TIPO-OPERACAO , LT3117-COD-LOTERICO , LT3117-NUM-CLASSE-ADESAO , LT3117-NUM-APOLICE , LT3117-DTINIVIG-APOLICE , LT3117-DTTERVIG-APOLICE , LT3117-QTD-PARCELAS , LT3117-TIPO-CALCULO , LT3117-CUSTO-APOLICE , LT3117-PCT-IOF , LT3117-TX-INCENDIO , LT3117-TX-VALORES , LT3117-TX-DANELET , LT3117-TX-AP-EMPGDR , LT3117-TX-AP-EMP , LT3117-TX-RC , LT3117-VL-IS-INCENDIO , LT3117-VL-IS-VALORES , LT3117-VL-IS-DANELET , LT3117-VL-IS-AP-EMPGDR , LT3117-VL-IS-AP-EMP , LT3117-VL-IS-RC , LT3117-IOF-PCL1 , LT3117-ADICIONAL-FRAC-PCL1 , LT3117-JUROS-PCL1 , LT3117-PERC-JUROS-PCL1 , LT3117-VL-PREMIO-LIQ-PCL1 , LT3117-VL-PREMIO-PCL1 , LT3117-IOF-PCLN , LT3117-ADICIONAL-FRAC-PCLN , LT3117-JUROS-PCLN , LT3117-PERC-JUROS-PCLN , LT3117-VL-PREMIO-LIQ-PCLN , LT3117-VL-PREMIO-PCLN , LT3117-VL-PREMIO-TOTAL , LT3117-VL-PREMIO-TOTAL-1PCL , LT3117-JURO-TOTAL , LT3117-IOF-TOTAL , LT3117-ADICIONAL-TOTAL , LT3117-PREMIO-INCENDIO , LT3117-PREMIO-VALORES , LT3117-PREMIO-DANELET , LT3117-PREMIO-AP-EMPGDR , LT3117-PREMIO-AP-EMP , LT3117-PREMIO-RC , LT3117-COD-RETORNO . */
            _.Call("LT3117S", LBLT3117, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM);

            /*" -4813- IF LT3117-COD-RETORNO > 0 */

            if (LBLT3117.LT3117_COD_RETORNO > 0)
            {

                /*" -4814- DISPLAY ' =========================================' */
                _.Display($" =========================================");

                /*" -4815- DISPLAY ' LT3117S-ERRO NO CALL LT3117S-CALCULO     ' */
                _.Display($" LT3117S-ERRO NO CALL LT3117S-CALCULO     ");

                /*" -4816- DISPLAY ' LOT=' LT3117-COD-LOTERICO */
                _.Display($" LOT={LBLT3117.LT3117_COD_LOTERICO}");

                /*" -4817- DISPLAY ' NUM-CLASSE=' LT3117-NUM-CLASSE-ADESAO */
                _.Display($" NUM-CLASSE={LBLT3117.LT3117_NUM_CLASSE_ADESAO}");

                /*" -4818- DISPLAY ' APOL=' LT3117-NUM-APOLICE */
                _.Display($" APOL={LBLT3117.LT3117_NUM_APOLICE}");

                /*" -4819- DISPLAY ' DTINIVIG=' LT3117-DTINIVIG-APOLICE */
                _.Display($" DTINIVIG={LBLT3117.LT3117_DTINIVIG_APOLICE}");

                /*" -4820- DISPLAY ' DTTERVIG=' LT3117-DTTERVIG-APOLICE */
                _.Display($" DTTERVIG={LBLT3117.LT3117_DTTERVIG_APOLICE}");

                /*" -4821- DISPLAY ' QTD PCL=' LT3117-QTD-PARCELAS */
                _.Display($" QTD PCL={LBLT3117.LT3117_QTD_PARCELAS}");

                /*" -4822- DISPLAY ' TIPO CAL=' LT3117-TIPO-CALCULO */
                _.Display($" TIPO CAL={LBLT3117.LT3117_TIPO_CALCULO}");

                /*" -4823- DISPLAY ' CUSTO =' LT3117-CUSTO-APOLICE */
                _.Display($" CUSTO ={LBLT3117.LT3117_CUSTO_APOLICE}");

                /*" -4824- DISPLAY '                  ' */
                _.Display($"                  ");

                /*" -4825- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4826- ELSE */
            }
            else
            {


                /*" -4827- MOVE LT3117-PREMIO-INCENDIO TO LKIO-PREMIO-INCENDIO */
                _.Move(LBLT3117.LT3117_PREMIO_INCENDIO, LBHLT027.LKIO_PREMIO_INCENDIO);

                /*" -4828- MOVE LT3117-PREMIO-VALORES TO LKIO-PREMIO-VALORES */
                _.Move(LBLT3117.LT3117_PREMIO_VALORES, LBHLT027.LKIO_PREMIO_VALORES);

                /*" -4829- MOVE LT3117-PREMIO-DANELET TO LKIO-PREMIO-DANELET */
                _.Move(LBLT3117.LT3117_PREMIO_DANELET, LBHLT027.LKIO_PREMIO_DANELET);

                /*" -4830- MOVE LT3117-PREMIO-AP-EMPGDR TO LKIO-PREMIO-AP-EMPGDR */
                _.Move(LBLT3117.LT3117_PREMIO_AP_EMPGDR, LBHLT027.LKIO_PREMIO_AP_EMPGDR);

                /*" -4831- MOVE LT3117-PREMIO-AP-EMP TO LKIO-PREMIO-AP-EMP */
                _.Move(LBLT3117.LT3117_PREMIO_AP_EMP, LBHLT027.LKIO_PREMIO_AP_EMP);

                /*" -4832- MOVE LT3117-PREMIO-RC TO LKIO-PREMIO-RC */
                _.Move(LBLT3117.LT3117_PREMIO_RC, LBHLT027.LKIO_PREMIO_RC);

                /*" -4833- MOVE LT3117-IOF-PCL1 TO LKIO-IOF-PCL1 */
                _.Move(LBLT3117.LT3117_IOF_PCL1, LBHLT027.LKIO_IOF_PCL1);

                /*" -4834- MOVE LT3117-ADICIONAL-FRAC-PCL1 TO LKIO-ADICIONAL-FRAC-PCL1 */
                _.Move(LBLT3117.LT3117_ADICIONAL_FRAC_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1);

                /*" -4835- MOVE LT3117-JUROS-PCL1 TO LKIO-JUROS-PCL1 */
                _.Move(LBLT3117.LT3117_JUROS_PCL1, LBHLT027.LKIO_JUROS_PCL1);

                /*" -4836- MOVE LT3117-PERC-JUROS-PCL1 TO LKIO-PERC-JUROS-PCL1 */
                _.Move(LBLT3117.LT3117_PERC_JUROS_PCL1, LBHLT027.LKIO_PERC_JUROS_PCL1);

                /*" -4837- MOVE LT3117-VL-PREMIO-LIQ-PCL1 TO LKIO-VL-PREMIO-LIQ-PCL1 */
                _.Move(LBLT3117.LT3117_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1);

                /*" -4838- MOVE LT3117-VL-PREMIO-PCL1 TO LKIO-VL-PREMIO-PCL1 */
                _.Move(LBLT3117.LT3117_VL_PREMIO_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1);

                /*" -4839- MOVE LT3117-IOF-PCLN TO LKIO-IOF-PCLN */
                _.Move(LBLT3117.LT3117_IOF_PCLN, LBHLT027.LKIO_IOF_PCLN);

                /*" -4840- MOVE LT3117-ADICIONAL-FRAC-PCLN TO LKIO-ADICIONAL-FRAC-PCLN */
                _.Move(LBLT3117.LT3117_ADICIONAL_FRAC_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN);

                /*" -4841- MOVE LT3117-JUROS-PCLN TO LKIO-JUROS-PCLN */
                _.Move(LBLT3117.LT3117_JUROS_PCLN, LBHLT027.LKIO_JUROS_PCLN);

                /*" -4842- MOVE LT3117-PERC-JUROS-PCLN TO LKIO-PERC-JUROS-PCLN */
                _.Move(LBLT3117.LT3117_PERC_JUROS_PCLN, LBHLT027.LKIO_PERC_JUROS_PCLN);

                /*" -4843- MOVE LT3117-VL-PREMIO-LIQ-PCLN TO LKIO-VL-PREMIO-LIQ-PCLN */
                _.Move(LBLT3117.LT3117_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN);

                /*" -4843- MOVE LT3117-VL-PREMIO-PCLN TO LKIO-VL-PREMIO-PCLN. */
                _.Move(LBLT3117.LT3117_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_99_SAIDA_3117_EXIT*/

        [StopWatch]
        /*" B2060-CHAMA-LT3151S-SECTION */
        private void B2060_CHAMA_LT3151S_SECTION()
        {
            /*" -4892- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -4894- INITIALIZE LT3151-AREA-PARAMETROS. */
            _.Initialize(
                LBLT3151.LT3151_AREA_PARAMETROS
            );

            /*" -4895- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -4896- MOVE 1 TO LT3151-QTD-PARCELAS */
                _.Move(1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS);

                /*" -4897- ELSE */
            }
            else
            {


                /*" -4898- MOVE ENDO-QTPARCEL TO LT3151-QTD-PARCELAS */
                _.Move(ENDO_QTPARCEL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS);

                /*" -4899- END-IF */
            }


            /*" -4901- PERFORM B2061-SELECT-LTMVPROP */

            B2061_SELECT_LTMVPROP_SECTION();

            /*" -4905- MOVE 0 TO LT3151-COD-RETORNO LT3151-VL-PREMIO-PCL1 LT3151-VL-PREMIO-PCLN LT3151-VL-PREMIO-TOTAL */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL);

            /*" -4906- MOVE LTMVPROP-VLR-CUSTO-APOLICE TO LT3151-CUSTO-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE);

            /*" -4907- MOVE LTMVPROP-PCT-IOF TO LT3151-PCT-IOF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_IOF, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF);

            /*" -4908- MOVE ' ' TO LT3151-TIPO-OPERACAO */
            _.Move(" ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_OPERACAO);

            /*" -4909- MOVE ' ' TO LT3151-TIPO-CALCULO */
            _.Move(" ", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO);

            /*" -4911- MOVE 'S' TO LT3151-DISPLAY */
            _.Move("S", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DISPLAY);

            /*" -4912- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3151-COD-LOTERICO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO);

            /*" -4913- MOVE LTMVPROP-NUM-APOLICE TO LT3151-NUM-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_APOLICE, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOLICE);

            /*" -4914- MOVE LTMVPROP-DT-INIVIG-PROPOSTA TO LT3151-DTINIVIG-APOLICE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE);

            /*" -4915- MOVE SPACES TO LT3151-DTTERVIG-APOLICE */
            _.Move("", LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE);

            /*" -4917- MOVE LTMVPROP-NUM-CLASSE-ADESAO TO LT3151-NUM-CLASSE-ADESAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO);

            /*" -4918- MOVE LTMVPROP-CGCCPF TO LT3151-CGCCPF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_CGCCPF, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CGCCPF);

            /*" -4919- MOVE LTMVPROP-IND-REGIAO TO LT3151-COD-REGIAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_REGIAO);

            /*" -4920- MOVE LTMVPROP-PCT-DESC-FIDEL TO LT3151-PCT-DESC-FIDEL */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_FIDEL, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_FIDEL);

            /*" -4921- MOVE LTMVPROP-PCT-DESC-EXP TO LT3151-PCT-DESC-EXP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EXP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_EXP);

            /*" -4922- MOVE LTMVPROP-PCT-DESC-AGRUP TO LT3151-PCT-DESC-AGRUP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_AGRUP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_AGRUP);

            /*" -4923- MOVE LTMVPROP-PCT-DESC-EQUIP TO LT3151-PCT-DESC-COFRE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EQUIP, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_COFRE);

            /*" -4926- MOVE LTMVPROP-PCT-DESC-BLINDAGEM TO LT3151-PCT-DESC-BLINDAGEM */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_BLINDAGEM, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_DESC_BLINDAGEM);

            /*" -4927- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                /*" -4928- MOVE TB-IMPSEG (WS-IND) TO LT3151-IMPSEG (WS-IND) */
                _.Move(TAB_IMPSEG.TB_IMPSEG[WS_IND], LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_IMPSEG.LT3151_TAB_IMPSEG[WS_IND].LT3151_IMPSEG);

                /*" -4929- MOVE TB-TAXAS (WS-IND) TO LT3151-TAXAS (WS-IND) */
                _.Move(TAB_TAXAS.TB_TAXAS[WS_IND], LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TABELA_TAXAS.LT3151_TAB_TAXAS[WS_IND].LT3151_TAXAS);

                /*" -4934- END-PERFORM */
            }

            /*" -4935- MOVE 0 TO LT3151-CRITICAR-PRMLIQ */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CRITICAR_PRMLIQ);

            /*" -4936- MOVE 0 TO LT3151-VLR-MIN-SAP */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_SAP);

            /*" -4937- MOVE 0 TO LT3151-VLR-MIN-PRMLIQ */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_MIN_PRMLIQ);

            /*" -4939- MOVE 0 TO LT3151-VLR-TAXA-ADESAO */
            _.Move(0, LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VLR_TAXA_ADESAO);

            /*" -4941- CALL 'LT3151S' USING LT3151-AREA-PARAMETROS */
            _.Call("LT3151S", LBLT3151.LT3151_AREA_PARAMETROS);

            /*" -4942- IF LT3151-COD-RETORNO > 0 */

            if (LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO > 0)
            {

                /*" -4943- DISPLAY ' =========================================' */
                _.Display($" =========================================");

                /*" -4944- DISPLAY ' LT3151S-ERRO NO CALL LT3151S-CALCULO     ' */
                _.Display($" LT3151S-ERRO NO CALL LT3151S-CALCULO     ");

                /*" -4945- DISPLAY ' LOT=' LT3151-COD-LOTERICO */
                _.Display($" LOT={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_LOTERICO}");

                /*" -4946- DISPLAY ' NUM-CLASSE=' LT3151-NUM-CLASSE-ADESAO */
                _.Display($" NUM-CLASSE={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO}");

                /*" -4947- DISPLAY ' APOL=' LT3151-NUM-APOLICE */
                _.Display($" APOL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_APOLICE}");

                /*" -4948- DISPLAY ' DTINIVIG=' LT3151-DTINIVIG-APOLICE */
                _.Display($" DTINIVIG={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTINIVIG_APOLICE}");

                /*" -4949- DISPLAY ' DTTERVIG=' LT3151-DTTERVIG-APOLICE */
                _.Display($" DTTERVIG={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_DTTERVIG_APOLICE}");

                /*" -4950- DISPLAY ' QTD PCL=' LT3151-QTD-PARCELAS */
                _.Display($" QTD PCL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS}");

                /*" -4951- DISPLAY ' TIPO CAL=' LT3151-TIPO-CALCULO */
                _.Display($" TIPO CAL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_TIPO_CALCULO}");

                /*" -4952- DISPLAY ' CUSTO =' LT3151-CUSTO-APOLICE */
                _.Display($" CUSTO ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE}");

                /*" -4953- DISPLAY ' IOF   =' LT3151-PCT-IOF */
                _.Display($" IOF   ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_PCT_IOF}");

                /*" -4954- DISPLAY ' PREMIO LIQ  =' LT3151-VL-PREMIO-LIQ */
                _.Display($" PREMIO LIQ  ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ}");

                /*" -4955- DISPLAY ' PREMIO TOTAL=' LT3151-VL-PREMIO-TOTAL */
                _.Display($" PREMIO TOTAL={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_TOTAL}");

                /*" -4956- DISPLAY ' NUM-CLASSE  =' LT3151-NUM-CLASSE-ADESAO */
                _.Display($" NUM-CLASSE  ={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_NUM_CLASSE_ADESAO}");

                /*" -4957- DISPLAY ' QTD-PARCELAS=' LT3151-QTD-PARCELAS */
                _.Display($" QTD-PARCELAS={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS}");

                /*" -4958- DISPLAY ' =========================================' */
                _.Display($" =========================================");

                /*" -4959- DISPLAY 'COD-RET=' LT3151-COD-RETORNO */
                _.Display($"COD-RET={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_COD_RETORNO}");

                /*" -4960- DISPLAY 'MSG-RET=' LT3151-MSG-RETORNO */
                _.Display($"MSG-RET={LBLT3151.LT3151_AREA_PARAMETROS.LT3151_MSG_RETORNO}");

                /*" -4961- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4963- END-IF */
            }


            /*" -4965- MOVE LT3151-CUSTO-APOLICE TO LKIO-CUSTO-APOLICE */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_CUSTO_APOLICE, LBHLT027.LKIO_CUSTO_APOLICE);

            /*" -4967- MOVE LT3151-QTD-PARCELAS TO LKIO-QTD-PARCELAS */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_QTD_PARCELAS, LBHLT027.LKIO_QTD_PARCELAS);

            /*" -4968- MOVE LT3151-VL-PREMIO-LIQ-PCL1 TO LKIO-VL-PREMIO-LIQ-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1);

            /*" -4969- MOVE LT3151-JUROS-PCL1 TO LKIO-ADICIONAL-FRAC-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1);

            /*" -4970- MOVE LT3151-IOF-PCL1 TO LKIO-IOF-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCL1, LBHLT027.LKIO_IOF_PCL1);

            /*" -4972- MOVE LT3151-VL-PREMIO-PCL1 TO LKIO-VL-PREMIO-PCL1 */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1);

            /*" -4973- MOVE LT3151-VL-PREMIO-LIQ-PCLN TO LKIO-VL-PREMIO-LIQ-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN);

            /*" -4974- MOVE LT3151-JUROS-PCLN TO LKIO-ADICIONAL-FRAC-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_JUROS_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN);

            /*" -4975- MOVE LT3151-IOF-PCLN TO LKIO-IOF-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_IOF_PCLN, LBHLT027.LKIO_IOF_PCLN);

            /*" -4992- MOVE LT3151-VL-PREMIO-PCLN TO LKIO-VL-PREMIO-PCLN */
            _.Move(LBLT3151.LT3151_AREA_PARAMETROS.LT3151_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN);

            /*" -4992- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_99_SAIDA_3151*/

        [StopWatch]
        /*" B2060-CHAMA-LT3201S-SECTION */
        private void B2060_CHAMA_LT3201S_SECTION()
        {
            /*" -5004- MOVE 'B2060' TO WNR-EXEC-SQL. */
            _.Move("B2060", WABEND.WNR_EXEC_SQL);

            /*" -5011- PERFORM B2061-SELECT-LTMVPROP */

            B2061_SELECT_LTMVPROP_SECTION();

            /*" -5013- INITIALIZE LT3201-AREA-PARAMETROS */
            _.Initialize(
                LBLT3201.LT3201_AREA_PARAMETROS
            );

            /*" -5014- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                /*" -5016- IF TB-IMPSEG(WS-IND) > 0 AND TB-TAXAS(WS-IND) > 0 */

                if (TAB_IMPSEG.TB_IMPSEG[WS_IND] > 0 && TAB_TAXAS.TB_TAXAS[WS_IND] > 0)
                {

                    /*" -5017- MOVE TB-IMPSEG(WS-IND) TO LT3201-IMPSEG(WS-IND) */
                    _.Move(TAB_IMPSEG.TB_IMPSEG[WS_IND], LBLT3201.LT3201_AREA_PARAMETROS.LT3201_TABELA_IMPSEG.LT3201_TAB_IMPSEG[WS_IND].LT3201_IMPSEG);

                    /*" -5018- END-IF */
                }


                /*" -5022- END-PERFORM */
            }

            /*" -5026- MOVE 0 TO LT3201-COD-RETORNO LT3201-VL-PREMIO-PCL1 LT3201-VL-PREMIO-PCLN LT3201-VL-PREMIO-TOTAL */
            _.Move(0, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_COD_RETORNO, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_VL_PREMIO_PCL1, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_VL_PREMIO_PCLN, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_VL_PREMIO_TOTAL);

            /*" -5027- MOVE 0 TO LT3201-CUSTO-APOLICE */
            _.Move(0, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_CUSTO_APOLICE);

            /*" -5028- MOVE 0 TO LT3201-PCT-IOF */
            _.Move(0, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_PCT_IOF);

            /*" -5029- MOVE '01' TO LT3201-TIPO-OPERACAO */
            _.Move("01", LBLT3201.LT3201_AREA_PARAMETROS.LT3201_TIPO_OPERACAO);

            /*" -5030- MOVE ' ' TO LT3201-TIPO-CALCULO */
            _.Move(" ", LBLT3201.LT3201_AREA_PARAMETROS.LT3201_TIPO_CALCULO);

            /*" -5031- MOVE SPACES TO LT3201-DISPLAY */
            _.Move("", LBLT3201.LT3201_AREA_PARAMETROS.LT3201_DISPLAY);

            /*" -5038- MOVE LTMVPROP-QTD-PARCELAS TO LT3201-QTD-PARCELAS */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_QTD_PARCELAS, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_QTD_PARCELAS);

            /*" -5039- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3201-COD-LOTERICO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_COD_LOTERICO);

            /*" -5040- MOVE 0 TO LT3201-NUM-APOLICE */
            _.Move(0, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_NUM_APOLICE);

            /*" -5042- MOVE LTMVPROP-DT-INIVIG-PROPOSTA TO LT3201-DTINIVIG-PROPOSTA */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_DTINIVIG_PROPOSTA);

            /*" -5043- MOVE SPACES TO LT3201-DTTERVIG-PROPOSTA */
            _.Move("", LBLT3201.LT3201_AREA_PARAMETROS.LT3201_DTTERVIG_PROPOSTA);

            /*" -5045- MOVE LTMVPROP-COD-CLASSE-ADESAO TO LT3201-NUM-CLASSE-ADESAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_CLASSE_ADESAO, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_NUM_CLASSE_ADESAO);

            /*" -5046- MOVE LTMVPROP-CGCCPF TO LT3201-CGCCPF */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_CGCCPF, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_CGCCPF);

            /*" -5048- MOVE LTMVPROP-IND-REGIAO TO LT3201-COD-REGIAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_COD_REGIAO);

            /*" -5051- MOVE 0 TO LT3201-VLR-ADIC-COBER */
            _.Move(0, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_VLR_ADIC_COBER);

            /*" -5106- MOVE LTMVPROP-IND-TIPO-VIGENCIA TO LT3201-IND-VIGENCIA-PLURI */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_VIGENCIA, LBLT3201.LT3201_AREA_PARAMETROS.LT3201_IND_VIGENCIA_PLURI);

            /*" -5108- INITIALIZE LT3214-AREA-PARAMETROS. */
            _.Initialize(
                LBLT3214.LT3214_AREA_PARAMETROS
            );

            /*" -5110- MOVE LTMVPROP-IND-TIPO-VIGENCIA TO W1 */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_VIGENCIA, W1);

            /*" -5111- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3214-COD-LOTERICO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_LOTERICO);

            /*" -5112- MOVE LTMVPROP-SEQ-PROPOSTA TO LT3214-SEQ-PROPOSTA */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_SEQ_PROPOSTA);

            /*" -5113- MOVE LTMVPROP-NUM-PROPOSTA-SIM TO LT3214-NUM-PROPOSTA-SIM */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA_SIM, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_NUM_PROPOSTA_SIM);

            /*" -5114- MOVE LTMVPROP-DATA-MOVIMENTO TO LT3214-DATA-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_DATA_MOVIMENTO);

            /*" -5116- MOVE LTMVPROP-HORA-MOVIMENTO TO LT3214-HORA-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_HORA_MOVIMENTO);

            /*" -5118- CALL 'LT3214S' USING LT3214-AREA-PARAMETROS. */
            _.Call("LT3214S", LBLT3214.LT3214_AREA_PARAMETROS);

            /*" -5119- IF LT3214-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO != 00)
            {

                /*" -5120- DISPLAY 'R1800 - ERRO RETORNO LT3214S' */
                _.Display($"R1800 - ERRO RETORNO LT3214S");

                /*" -5121- ELSE */
            }
            else
            {


                /*" -5122- DISPLAY 'R1800 -PROCESSAMENTO LT3214S COM SUCESSO' */
                _.Display($"R1800 -PROCESSAMENTO LT3214S COM SUCESSO");

                /*" -5126- END-IF. */
            }


            /*" -5127- MOVE LT3214-VL-CUSTO-EMISSAO(W1) TO LKIO-CUSTO-APOLICE */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_CUSTO_EMISSAO, LBHLT027.LKIO_CUSTO_APOLICE);

            /*" -5129- MOVE LT3214-QTD-PARCELAS(W1) TO LKIO-QTD-PARCELAS */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_QTD_PARCELAS, LBHLT027.LKIO_QTD_PARCELAS);

            /*" -5130- MOVE LT3214-VL-PREMIO-LIQ-PCL1(W1) TO LKIO-VL-PREMIO-LIQ-PCL1 */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_PREMIO_LIQ_PCL1, LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1);

            /*" -5131- MOVE LT3214-VL-ADICIONAL-PCL1(W1) TO LKIO-ADICIONAL-FRAC-PCL1 */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_ADICIONAL_PCL1, LBHLT027.LKIO_ADICIONAL_FRAC_PCL1);

            /*" -5132- MOVE LT3214-VL-IOF-PCL1(W1) TO LKIO-IOF-PCL1 */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_IOF_PCL1, LBHLT027.LKIO_IOF_PCL1);

            /*" -5134- MOVE LT3214-VL-PREMIO-PCL1(W1) TO LKIO-VL-PREMIO-PCL1 */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_PREMIO_PCL1, LBHLT027.LKIO_VL_PREMIO_PCL1);

            /*" -5135- MOVE LT3214-VL-PREMIO-LIQ-PCLN(W1) TO LKIO-VL-PREMIO-LIQ-PCLN */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_PREMIO_LIQ_PCLN, LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN);

            /*" -5136- MOVE LT3214-VL-ADICIONAL-PCLN(W1) TO LKIO-ADICIONAL-FRAC-PCLN */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_ADICIONAL_PCLN, LBHLT027.LKIO_ADICIONAL_FRAC_PCLN);

            /*" -5137- MOVE LT3214-VL-IOF-PCLN(W1) TO LKIO-IOF-PCLN */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_IOF_PCLN, LBHLT027.LKIO_IOF_PCLN);

            /*" -5139- MOVE LT3214-VL-PREMIO-PCLN(W1) TO LKIO-VL-PREMIO-PCLN */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1].LT3214_VL_PREMIO_PCLN, LBHLT027.LKIO_VL_PREMIO_PCLN);

            /*" -5140- DISPLAY '**** CALCULO DA LT3214S LIDO NA LT_PREMIO *******' */
            _.Display($"**** CALCULO DA LT3214S LIDO NA LT_PREMIO *******");

            /*" -5141- DISPLAY 'LOTERICO           :' LTMVPROP-COD-EXT-SEGURADO */
            _.Display($"LOTERICO           :{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}");

            /*" -5142- DISPLAY 'APOLICE            :' ENDO-NUM-APOLICE */
            _.Display($"APOLICE            :{ENDO_NUM_APOLICE}");

            /*" -5143- DISPLAY 'CUSTO-APOLICE      :' LT3214-VL-CUSTO-EMISSAO(W1) */
            _.Display($"CUSTO-APOLICE      :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5144- DISPLAY 'QTD-PARCELAS       :' LT3214-QTD-PARCELAS(W1) */
            _.Display($"QTD-PARCELAS       :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5145- DISPLAY '                    ' */
            _.Display($"                    ");

            /*" -5146- DISPLAY 'VL-PREMIO-LIQ-PCL1 :' LT3214-VL-PREMIO-LIQ-PCL1(W1) */
            _.Display($"VL-PREMIO-LIQ-PCL1 :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5147- DISPLAY 'ADICIONAL-FRAC-PCL1:' LT3214-VL-ADICIONAL-PCL1(W1) */
            _.Display($"ADICIONAL-FRAC-PCL1:{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5148- DISPLAY 'IOF-PCL1           :' LT3214-VL-IOF-PCL1(W1) */
            _.Display($"IOF-PCL1           :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5149- DISPLAY 'VL-PREMIO-PCL1     :' LT3214-VL-PREMIO-PCL1(W1) */
            _.Display($"VL-PREMIO-PCL1     :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5150- DISPLAY '                    ' */
            _.Display($"                    ");

            /*" -5151- DISPLAY 'VL-PREMIO-LIQ-PCLN :' LT3214-VL-PREMIO-LIQ-PCLN(W1) */
            _.Display($"VL-PREMIO-LIQ-PCLN :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5152- DISPLAY 'ADICIONAL-FRAC-PCLN:' LT3214-VL-ADICIONAL-PCLN(W1) */
            _.Display($"ADICIONAL-FRAC-PCLN:{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5153- DISPLAY 'IOF-PCLN           :' LT3214-VL-IOF-PCLN(W1) */
            _.Display($"IOF-PCLN           :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5154- DISPLAY 'VL-PREMIO-PCLN     :' LT3214-VL-PREMIO-PCLN(W1) */
            _.Display($"VL-PREMIO-PCLN     :{LBLT3201.LT3201_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[W1]}");

            /*" -5156- DISPLAY ' ' */
            _.Display($" ");

            /*" -5156- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2060_99_SAIDA_3201*/

        [StopWatch]
        /*" B2061-SELECT-LTMVPROP-SECTION */
        private void B2061_SELECT_LTMVPROP_SECTION()
        {
            /*" -5165- MOVE 'B2061' TO WNR-EXEC-SQL. */
            _.Move("B2061", WABEND.WNR_EXEC_SQL);

            /*" -5173- PERFORM B2061_SELECT_LTMVPROP_DB_SELECT_1 */

            B2061_SELECT_LTMVPROP_DB_SELECT_1();

            /*" -5176- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5178- DISPLAY ' B2061 -ERRO SELECT MAX SEQ LT_MOV_PROPOSTA' ' ' ENDO-NUM-APOLICE */

                $" B2061 -ERRO SELECT MAX SEQ LT_MOV_PROPOSTA {ENDO_NUM_APOLICE}"
                .Display();

                /*" -5180- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5243- PERFORM B2061_SELECT_LTMVPROP_DB_SELECT_2 */

            B2061_SELECT_LTMVPROP_DB_SELECT_2();

            /*" -5246- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5249- DISPLAY 'B2061-ERRO SELECT LT_MOV_PROPOSTA' 'APO=' ENDO-NUM-APOLICE 'SEQ=' LTMVPROP-SEQ-PROPOSTA */

                $"B2061-ERRO SELECT LT_MOV_PROPOSTAAPO={ENDO_NUM_APOLICE}SEQ={LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA}"
                .Display();

                /*" -5251- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5252- MOVE LTMVPROP-COD-EXT-SEGURADO TO LTMVPRCO-COD-EXT-SEGURADO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_EXT_SEGURADO);

            /*" -5253- MOVE LTMVPROP-DATA-MOVIMENTO TO LTMVPRCO-DATA-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_DATA_MOVIMENTO);

            /*" -5254- MOVE LTMVPROP-HORA-MOVIMENTO TO LTMVPRCO-HORA-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_HORA_MOVIMENTO);

            /*" -5255- MOVE LTMVPROP-COD-PRODUTO TO LTMVPRCO-COD-PRODUTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_PRODUTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_PRODUTO);

            /*" -5256- MOVE LTMVPROP-COD-EXT-ESTIP TO LTMVPRCO-COD-EXT-ESTIP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_ESTIP, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_EXT_ESTIP);

            /*" -5258- MOVE LTMVPROP-COD-MOVIMENTO TO LTMVPRCO-COD-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_MOVIMENTO);

            /*" -5259- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20 */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                /*" -5261- MOVE 0 TO TB-IMPSEG (WS-IND) TB-TAXAS (WS-IND) */
                _.Move(0, TAB_IMPSEG.TB_IMPSEG[WS_IND], TAB_TAXAS.TB_TAXAS[WS_IND]);

                /*" -5263- END-PERFORM. */
            }

            /*" -5269- PERFORM B2061-00-SELECT-COBER VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > 20. */

            for (WS_IND.Value = 1; !(WS_IND > 20); WS_IND.Value += 1)
            {

                B2061_00_SELECT_COBER_SECTION();
            }

            /*" -5269- . */

        }

        [StopWatch]
        /*" B2061-SELECT-LTMVPROP-DB-SELECT-1 */
        public void B2061_SELECT_LTMVPROP_DB_SELECT_1()
        {
            /*" -5173- EXEC SQL SELECT VALUE(MAX(SEQ_PROPOSTA),0) INTO :LTMVPROP-SEQ-PROPOSTA FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO IN ( '1' , 'T' ) WITH UR END-EXEC. */

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
            /*" -5243- EXEC SQL SELECT COD_EXT_SEGURADO , COD_CLASSE_ADESAO , NUM_CLASSE_ADESAO , COMPL_ENDER , DT_INIVIG_PROPOSTA , NUM_APOLICE , QTD_PARCELAS , VLR_JUROS_MENSAL , VLR_CUSTO_APOLICE , PCT_JUROS , DATA_MOVIMENTO , HORA_MOVIMENTO , COD_MOVIMENTO , SIT_MOVIMENTO , COD_PRODUTO , COD_EXT_ESTIP , PCT_IOF , CGCCPF , VALUE(IND_REGIAO,0) , VALUE(PCT_DESC_FIDEL,0) , VALUE(PCT_DESC_EXP,0) , VALUE(PCT_DESC_AGRUP,0) , VALUE(PCT_DESC_EQUIP,0) , VALUE(PCT_DESC_BLINDAGEM,0) , VALUE(NUM_PROPOSTA_SIM,0) , VALUE(IND_TIPO_VIGENCIA,0) , VALUE(QTD_REN_SEM_SINI,0) , VALUE(QTD_REN_SEM_SINI_INF,0) INTO :LTMVPROP-COD-EXT-SEGURADO , :LTMVPROP-COD-CLASSE-ADESAO , :LTMVPROP-NUM-CLASSE-ADESAO , :LTMVPROP-COMPL-ENDER , :LTMVPROP-DT-INIVIG-PROPOSTA , :LTMVPROP-NUM-APOLICE , :LTMVPROP-QTD-PARCELAS , :LTMVPROP-VLR-JUROS-MENSAL , :LTMVPROP-VLR-CUSTO-APOLICE , :LTMVPROP-PCT-JUROS , :LTMVPROP-DATA-MOVIMENTO , :LTMVPROP-HORA-MOVIMENTO , :LTMVPROP-COD-MOVIMENTO , :LTMVPROP-SIT-MOVIMENTO , :LTMVPROP-COD-PRODUTO , :LTMVPROP-COD-EXT-ESTIP , :LTMVPROP-PCT-IOF , :LTMVPROP-CGCCPF , :LTMVPROP-IND-REGIAO , :LTMVPROP-PCT-DESC-FIDEL , :LTMVPROP-PCT-DESC-EXP , :LTMVPROP-PCT-DESC-AGRUP , :LTMVPROP-PCT-DESC-EQUIP , :LTMVPROP-PCT-DESC-BLINDAGEM , :LTMVPROP-NUM-PROPOSTA-SIM , :LTMVPROP-IND-TIPO-VIGENCIA , :LTMVPROP-QTD-REN-SEM-SINI , :LTMVPROP-QTD-REN-SEM-SINI-INF FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND SEQ_PROPOSTA = :LTMVPROP-SEQ-PROPOSTA AND COD_MOVIMENTO = '9' AND SIT_MOVIMENTO IN ( '1' , 'T' ) WITH UR END-EXEC. */

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
                _.Move(executed_1.LTMVPROP_NUM_PROPOSTA_SIM, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA_SIM);
                _.Move(executed_1.LTMVPROP_IND_TIPO_VIGENCIA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_VIGENCIA);
                _.Move(executed_1.LTMVPROP_QTD_REN_SEM_SINI, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_QTD_REN_SEM_SINI);
                _.Move(executed_1.LTMVPROP_QTD_REN_SEM_SINI_INF, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_QTD_REN_SEM_SINI_INF);
            }


        }

        [StopWatch]
        /*" B2061-00-SELECT-COBER-SECTION */
        private void B2061_00_SELECT_COBER_SECTION()
        {
            /*" -5279- MOVE WS-IND TO LTMVPRCO-COD-COBERTURA. */
            _.Move(WS_IND, LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_COD_COBERTURA);

            /*" -5293- PERFORM B2061_00_SELECT_COBER_DB_SELECT_1 */

            B2061_00_SELECT_COBER_DB_SELECT_1();

            /*" -5299- IF SQLCODE NOT EQUAL TO ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5301- GO TO B2061-99-SAIDA-COBER. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2061_99_SAIDA_COBER*/ //GOTO
                return;
            }


            /*" -5302- MOVE LTMVPRCO-VAL-TAXA-PREMIO TO TB-TAXAS (WS-IND) */
            _.Move(LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_VAL_TAXA_PREMIO, TAB_TAXAS.TB_TAXAS[WS_IND]);

            /*" -5302- MOVE LTMVPRCO-VAL-IMP-SEGURADA TO TB-IMPSEG (WS-IND). */
            _.Move(LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_VAL_IMP_SEGURADA, TAB_IMPSEG.TB_IMPSEG[WS_IND]);

        }

        [StopWatch]
        /*" B2061-00-SELECT-COBER-DB-SELECT-1 */
        public void B2061_00_SELECT_COBER_DB_SELECT_1()
        {
            /*" -5293- EXEC SQL SELECT LTMVPRCO.VAL_IMP_SEGURADA , LTMVPRCO.VAL_TAXA_PREMIO INTO :LTMVPRCO-VAL-IMP-SEGURADA , :LTMVPRCO-VAL-TAXA-PREMIO FROM SEGUROS.LT_MOV_PROP_COBER LTMVPRCO WHERE LTMVPRCO.COD_EXT_SEGURADO = :LTMVPRCO-COD-EXT-SEGURADO AND LTMVPRCO.DATA_MOVIMENTO = :LTMVPRCO-DATA-MOVIMENTO AND LTMVPRCO.HORA_MOVIMENTO = :LTMVPRCO-HORA-MOVIMENTO AND LTMVPRCO.COD_PRODUTO = :LTMVPRCO-COD-PRODUTO AND LTMVPRCO.COD_EXT_ESTIP = :LTMVPRCO-COD-EXT-ESTIP AND LTMVPRCO.COD_COBERTURA = :LTMVPRCO-COD-COBERTURA AND LTMVPRCO.COD_MOVIMENTO = :LTMVPRCO-COD-MOVIMENTO WITH UR END-EXEC. */

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
        /*" B2061-10-00-LER-PREMIO-2021-SECTION */
        private void B2061_10_00_LER_PREMIO_2021_SECTION()
        {
            /*" -5313- MOVE LTMVPROP-NUM-PROPOSTA-SIM TO LT028-NUM-PROPOSTA-SIM */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA_SIM, LT028.DCLLT_PREMIO.LT028_NUM_PROPOSTA_SIM);

            /*" -5315- MOVE LTMVPROP-IND-TIPO-VIGENCIA TO LT028-IND-TIPO-VIGENCIA */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_VIGENCIA, LT028.DCLLT_PREMIO.LT028_IND_TIPO_VIGENCIA);

            /*" -5317- IF LTMVPROP-NUM-PROPOSTA-SIM EQUAL ZEROS OR LTMVPROP-IND-TIPO-VIGENCIA EQUAL ZEROS */

            if (LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA_SIM == 00 || LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_TIPO_VIGENCIA == 00)
            {

                /*" -5318- DISPLAY 'R2061-10-00 PROPOSTA SIMMULACAO ZERADA ZERADA' */
                _.Display($"R2061-10-00 PROPOSTA SIMMULACAO ZERADA ZERADA");

                /*" -5319- GO TO R2021-10-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2021_10_99_SAIDA*/ //GOTO
                return;

                /*" -5322- END-IF */
            }


            /*" -5329- PERFORM B2061_10_00_LER_PREMIO_2021_DB_SELECT_1 */

            B2061_10_00_LER_PREMIO_2021_DB_SELECT_1();

            /*" -5332- IF SQLCODE NOT EQUAL TO ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -5333- DISPLAY 'R2021-10-ERRO LER LT-PREMIO....' */
                _.Display($"R2021-10-ERRO LER LT-PREMIO....");

                /*" -5334- DISPLAY ' NUM_PROPOSTA_SIM  :' LT028-NUM-PROPOSTA-SIM */
                _.Display($" NUM_PROPOSTA_SIM  :{LT028.DCLLT_PREMIO.LT028_NUM_PROPOSTA_SIM}");

                /*" -5335- DISPLAY ' IND_TIPO_VIGENCIA :' LT028-IND-TIPO-VIGENCIA */
                _.Display($" IND_TIPO_VIGENCIA :{LT028.DCLLT_PREMIO.LT028_IND_TIPO_VIGENCIA}");

                /*" -5336- DISPLAY ' SLCODE:' SQLCODE */
                _.Display($" SLCODE:{DB.SQLCODE}");

                /*" -5337- GO TO R2021-10-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2021_10_99_SAIDA*/ //GOTO
                return;

                /*" -5340- END-IF. */
            }


            /*" -5341- MOVE ENDO-DTVENCTO TO W-DATA-VENCTO */
            _.Move(ENDO_DTVENCTO, W_DATA_VENCTO);

            /*" -5342- MOVE LT028-DIA-VENC-DEMAIS-PARCELAS TO W-DIA-VENCTO */
            _.Move(LT028.DCLLT_PREMIO.LT028_DIA_VENC_DEMAIS_PARCELAS, W_DATA_VENCTO.W_DIA_VENCTO);

            /*" -5344- MOVE W-DATA-VENCTO TO ENDO-DTVENCTO */
            _.Move(W_DATA_VENCTO, ENDO_DTVENCTO);

            /*" -5347- DISPLAY 'R2021-10-SAIDA' ' DATAVENTO :' ENDO-DTVENCTO */

            $"R2021-10-SAIDA DATAVENTO :{ENDO_DTVENCTO}"
            .Display();

            /*" -5347- . */

        }

        [StopWatch]
        /*" B2061-10-00-LER-PREMIO-2021-DB-SELECT-1 */
        public void B2061_10_00_LER_PREMIO_2021_DB_SELECT_1()
        {
            /*" -5329- EXEC SQL SELECT DIA_VENC_DEMAIS_PARCELAS INTO :LT028-DIA-VENC-DEMAIS-PARCELAS FROM SEGUROS.LT_PREMIO WHERE NUM_PROPOSTA_SIM = :LT028-NUM-PROPOSTA-SIM AND IND_TIPO_VIGENCIA = :LT028-IND-TIPO-VIGENCIA WITH UR END-EXEC */

            var b2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1 = new B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1()
            {
                LT028_IND_TIPO_VIGENCIA = LT028.DCLLT_PREMIO.LT028_IND_TIPO_VIGENCIA.ToString(),
                LT028_NUM_PROPOSTA_SIM = LT028.DCLLT_PREMIO.LT028_NUM_PROPOSTA_SIM.ToString(),
            };

            var executed_1 = B2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1.Execute(b2061_10_00_LER_PREMIO_2021_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LT028_DIA_VENC_DEMAIS_PARCELAS, LT028.DCLLT_PREMIO.LT028_DIA_VENC_DEMAIS_PARCELAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2021_10_99_SAIDA*/

        [StopWatch]
        /*" B2062-MONTA-PARCELA-SECTION */
        private void B2062_MONTA_PARCELA_SECTION()
        {
            /*" -5361- MOVE 'B2062' TO WNR-EXEC-SQL. */
            _.Move("B2062", WABEND.WNR_EXEC_SQL);

            /*" -5364- MOVE ZEROS TO VL-DESC-IX VL-DESCONTO */
            _.Move(0, EM0901W099.VL_DESC_IX, EM0901W099.VL_DESCONTO);

            /*" -5365- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -5368- COMPUTE WS-PREMIO-LIQ = LKIO-VL-PREMIO-LIQ-PCL1 - LKIO-ADICIONAL-FRAC-PCL1 */
                WS_PREMIO_LIQ.Value = LBHLT027.LKIO_VL_PREMIO_LIQ_PCL1 - LBHLT027.LKIO_ADICIONAL_FRAC_PCL1;

                /*" -5371- MOVE LKIO-ADICIONAL-FRAC-PCL1 TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBHLT027.LKIO_ADICIONAL_FRAC_PCL1, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5373- MOVE LKIO-CUSTO-APOLICE TO VL-CUSTO-IX VL-CUSTO */
                _.Move(LBHLT027.LKIO_CUSTO_APOLICE, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5375- MOVE LKIO-IOF-PCL1 TO VL-IOF-IX VL-IOF */
                _.Move(LBHLT027.LKIO_IOF_PCL1, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5377- MOVE LKIO-VL-PREMIO-PCL1 TO VL-TOTAL-IX VL-TOTAL */
                _.Move(LBHLT027.LKIO_VL_PREMIO_PCL1, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);

                /*" -5378- ELSE */
            }
            else
            {


                /*" -5381- COMPUTE WS-PREMIO-LIQ = LKIO-VL-PREMIO-LIQ-PCLN - LKIO-ADICIONAL-FRAC-PCLN */
                WS_PREMIO_LIQ.Value = LBHLT027.LKIO_VL_PREMIO_LIQ_PCLN - LBHLT027.LKIO_ADICIONAL_FRAC_PCLN;

                /*" -5384- MOVE LKIO-ADICIONAL-FRAC-PCLN TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBHLT027.LKIO_ADICIONAL_FRAC_PCLN, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5386- MOVE ZEROS TO VL-CUSTO-IX VL-CUSTO */
                _.Move(0, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5388- MOVE LKIO-IOF-PCLN TO VL-IOF-IX VL-IOF */
                _.Move(LBHLT027.LKIO_IOF_PCLN, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5391- MOVE LKIO-VL-PREMIO-PCLN TO VL-TOTAL-IX VL-TOTAL. */
                _.Move(LBHLT027.LKIO_VL_PREMIO_PCLN, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);
            }


            /*" -5394- MOVE WS-PREMIO-LIQ TO VL-LIQ-IX VL-LIQUIDO VL-TARIFARIO-IX VL-TARIFA. */
            _.Move(WS_PREMIO_LIQ, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2062_999_EXIT*/

        [StopWatch]
        /*" B2063-CHAMA-LT2118S-SECTION */
        private void B2063_CHAMA_LT2118S_SECTION()
        {
            /*" -5407- MOVE 'B2063' TO WNR-EXEC-SQL. */
            _.Move("B2063", WABEND.WNR_EXEC_SQL);

            /*" -5409- INITIALIZE LT2118S-AREA-PARAMETROS. */
            _.Initialize(
                LBLT2118.LT2118S_AREA_PARAMETROS
            );

            /*" -5414- PERFORM B2064-SELECT-LTMVPROP */

            B2064_SELECT_LTMVPROP_SECTION();

            /*" -5415- MOVE 1 TO LT2118S-TIPO-CALCULO */
            _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_TIPO_CALCULO);

            /*" -5416- MOVE LTMVPROP-COD-MOVIMENTO TO LT2118S-COD-MOVIMENTO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_MOVIMENTO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_COD_MOVIMENTO);

            /*" -5417- MOVE ENDO-NUM-APOLICE TO LT2118S-NUM-APOLICE */
            _.Move(ENDO_NUM_APOLICE, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_APOLICE);

            /*" -5418- MOVE ENDO-DTINIVIG TO LT2118S-DATA-INIVIGENCIA */
            _.Move(ENDO_DTINIVIG, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_DATA_INIVIGENCIA);

            /*" -5420- MOVE LTMVPROP-NUM-CLASSE-ADESAO TO LT2118S-NUM-CLASSE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_CLASSE_ADESAO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_NUM_CLASSE);

            /*" -5421- MOVE LTMVPROP-IND-REGIAO TO LT2118S-IND-REGIAO */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_IND_REGIAO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_IND_REGIAO);

            /*" -5422- MOVE LTMVPROP-PCT-DESC-AGRUP TO LT2118S-PCT-DESC-AGRUP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_AGRUP, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_AGRUP);

            /*" -5423- MOVE LTMVPROP-PCT-DESC-FIDEL TO LT2118S-PCT-DESC-FIDEL */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_FIDEL, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_FIDEL);

            /*" -5424- MOVE LTMVPROP-PCT-DESC-EXP TO LT2118S-PCT-DESC-EXP */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EXP, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_EXP);

            /*" -5425- MOVE LTMVPROP-PCT-DESC-EQUIP TO LT2118S-PCT-DESC-COFRE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_EQUIP, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_COFRE);

            /*" -5428- MOVE LTMVPROP-PCT-DESC-BLINDAGEM TO LT2118S-PCT-DESC-BLINDAGEM */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_PCT_DESC_BLINDAGEM, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PCT_DESC_BLINDAGEM);

            /*" -5429- MOVE ENDO-ISENTA-CUSTO TO LT2118S-ISENTA-CUSTO */
            _.Move(ENDO_ISENTA_CUSTO, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_ISENTA_CUSTO);

            /*" -5430- MOVE COBE-TARIFARIO-VAR TO LT2118S-PRM-TARIFARIO-TOTAL */
            _.Move(COBE_TARIFARIO_VAR, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL);

            /*" -5431- MOVE 0 TO LT2118S-PRM-TARIFARIO-1PCL */
            _.Move(0, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL);

            /*" -5437- MOVE LTMVPROP-VLR-CUSTO-APOLICE TO LT2118S-CUSTO-EMISSAO-1 */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_VLR_CUSTO_APOLICE, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1);

            /*" -5438- IF ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' */

            if (ENDO_TIPO_ENDOSSO.In("3", "5"))
            {

                /*" -5441- COMPUTE LT2118S-PRM-TARIFARIO-TOTAL = LT2118S-PRM-TARIFARIO-TOTAL * -1. */
                LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_TOTAL * -1;
            }


            /*" -5442- IF ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' */

            if (ENDO_TIPO_ENDOSSO.In("3", "5"))
            {

                /*" -5447- COMPUTE LT2118S-PRM-TARIFARIO-1PCL = LT2118S-PRM-TARIFARIO-1PCL * -1. */
                LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL.Value = LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_PRM_TARIFARIO_1PCL * -1;
            }


            /*" -5448- IF ENDO-QTPARCEL EQUAL 0 */

            if (ENDO_QTPARCEL == 0)
            {

                /*" -5449- MOVE 1 TO LT2118S-QTD-PARCELAS */
                _.Move(1, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS);

                /*" -5450- ELSE */
            }
            else
            {


                /*" -5452- MOVE ENDO-QTPARCEL TO LT2118S-QTD-PARCELAS. */
                _.Move(ENDO_QTPARCEL, LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA.LT2118S_QTD_PARCELAS);
            }


            /*" -5454- CALL 'LT2118S' USING LT2118S-AREA-PARAMETROS. */
            _.Call("LT2118S", LBLT2118.LT2118S_AREA_PARAMETROS);

            /*" -5455- IF LT2118S-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_COD_RETORNO != 00)
            {

                /*" -5457- DISPLAY ' PROBLEMAS NA ROTINA LT2118S:' ' ' LT2118S-MSG-RETORNO */

                $" PROBLEMAS NA ROTINA LT2118S: {LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_ERRO.LT2118S_MSG_RETORNO}"
                .Display();

                /*" -5459- DISPLAY ' PARAMETROS DE ENTRADA:' ' ' LT2118S-ENTRADA */

                $" PARAMETROS DE ENTRADA: {LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_ENTRADA}"
                .Display();

                /*" -5460- DISPLAY 'APOLICE ... ' ENDO-NUM-APOLICE */
                _.Display($"APOLICE ... {ENDO_NUM_APOLICE}");

                /*" -5461- DISPLAY 'ENDOSSO ... ' ENDO-NRENDOS */
                _.Display($"ENDOSSO ... {ENDO_NRENDOS}");

                /*" -5461- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2063_999_EXIT*/

        [StopWatch]
        /*" B2064-SELECT-LTMVPROP-SECTION */
        private void B2064_SELECT_LTMVPROP_SECTION()
        {
            /*" -5471- MOVE 'B2064' TO WNR-EXEC-SQL. */
            _.Move("B2064", WABEND.WNR_EXEC_SQL);

            /*" -5498- PERFORM B2064_SELECT_LTMVPROP_DB_SELECT_1 */

            B2064_SELECT_LTMVPROP_DB_SELECT_1();

            /*" -5501- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -5504- DISPLAY 'ERRO SELECT LT_MOV_PROPOSTA' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $"ERRO SELECT LT_MOV_PROPOSTA {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -5504- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2064-SELECT-LTMVPROP-DB-SELECT-1 */
        public void B2064_SELECT_LTMVPROP_DB_SELECT_1()
        {
            /*" -5498- EXEC SQL SELECT COD_MOVIMENTO , VLR_JUROS_MENSAL , VLR_CUSTO_APOLICE , NUM_CLASSE_ADESAO , IND_REGIAO , VALUE(PCT_DESC_AGRUP,0) , VALUE(PCT_DESC_FIDEL,0) , VALUE(PCT_DESC_EXP,0) , VALUE(PCT_DESC_EQUIP,0) , VALUE(PCT_DESC_BLINDAGEM,0) INTO :LTMVPROP-COD-MOVIMENTO , :LTMVPROP-VLR-JUROS-MENSAL , :LTMVPROP-VLR-CUSTO-APOLICE , :LTMVPROP-NUM-CLASSE-ADESAO , :LTMVPROP-IND-REGIAO , :LTMVPROP-PCT-DESC-AGRUP , :LTMVPROP-PCT-DESC-FIDEL , :LTMVPROP-PCT-DESC-EXP , :LTMVPROP-PCT-DESC-EQUIP , :LTMVPROP-PCT-DESC-BLINDAGEM FROM SEGUROS.LT_MOV_PROPOSTA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NUM_ENDOSSO = :ENDO-NRENDOS AND COD_MOVIMENTO IN ( 'A' , 'C' , 'T' ) AND SIT_MOVIMENTO = '1' WITH UR END-EXEC. */

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
            /*" -5519- MOVE 'B2065' TO WNR-EXEC-SQL. */
            _.Move("B2065", WABEND.WNR_EXEC_SQL);

            /*" -5522- MOVE ZEROS TO VL-DESC-IX VL-DESCONTO */
            _.Move(0, EM0901W099.VL_DESC_IX, EM0901W099.VL_DESCONTO);

            /*" -5523- IF W-PARCEL EQUAL 0 OR 1 */

            if (W_PARCEL.In("0", "1"))
            {

                /*" -5525- MOVE LT2118S-PRM-LIQUIDO-1 TO VL-LIQ-IX VL-LIQUIDO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_LIQUIDO_1, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO);

                /*" -5528- MOVE LT2118S-PRM-TARIFARIO-1 TO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TARIFARIO_1, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -5531- MOVE LT2118S-ADICIONAL-FRACIO-1 TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_ADICIONAL_FRACIO_1, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5534- MOVE LT2118S-CUSTO-EMISSAO-1 TO VL-CUSTO-IX VL-CUSTO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_CUSTO_EMISSAO_1, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5536- MOVE LT2118S-VAL-IOCC-1 TO VL-IOF-IX VL-IOF */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_VAL_IOCC_1, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5538- MOVE LT2118S-PRM-TOTAL-1 TO VL-TOTAL-IX VL-TOTAL */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELA1.LT2118S_PRM_TOTAL_1, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);

                /*" -5539- ELSE */
            }
            else
            {


                /*" -5541- MOVE LT2118S-PRM-LIQUIDO-N TO VL-LIQ-IX VL-LIQUIDO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_LIQUIDO_N, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO);

                /*" -5544- MOVE LT2118S-PRM-TARIFARIO-N TO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TARIFARIO_N, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -5547- MOVE LT2118S-ADICIONAL-FRACIO-N TO VL-ADIC-IX VL-ADICIONAL */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_ADICIONAL_FRACIO_N, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL);

                /*" -5550- MOVE LT2118S-CUSTO-EMISSAO-N TO VL-CUSTO-IX VL-CUSTO */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_CUSTO_EMISSAO_N, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -5552- MOVE LT2118S-VAL-IOCC-N TO VL-IOF-IX VL-IOF */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_VAL_IOCC_N, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -5553- MOVE LT2118S-PRM-TOTAL-N TO VL-TOTAL-IX VL-TOTAL. */
                _.Move(LBLT2118.LT2118S_AREA_PARAMETROS.LT2118S_SAIDA_PARCELAN.LT2118S_PRM_TOTAL_N, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2065_999_EXIT*/

        [StopWatch]
        /*" B2070-SELECT-V0NOVACAO-SECTION */
        private void B2070_SELECT_V0NOVACAO_SECTION()
        {
            /*" -5564- MOVE 'B2070' TO WNR-EXEC-SQL. */
            _.Move("B2070", WABEND.WNR_EXEC_SQL);

            /*" -5574- PERFORM B2070_SELECT_V0NOVACAO_DB_SELECT_1 */

            B2070_SELECT_V0NOVACAO_DB_SELECT_1();

            /*" -5577- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5578- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5580- DISPLAY 'B2070 - ENDOSSO NAO CADASTRADO NA V0NOVACAO' */
                    _.Display($"B2070 - ENDOSSO NAO CADASTRADO NA V0NOVACAO");

                    /*" -5583- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'ENDOSSO:  ' ENDO-NRENDOS '  ' 'DTINIVIG: ' ENDO-DTINIVIG */

                    $"APOLICE:  {ENDO_NUM_APOLICE}  ENDOSSO:  {ENDO_NRENDOS}  DTINIVIG: {ENDO_DTINIVIG}"
                    .Display();

                    /*" -5584- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5585- ELSE */
                }
                else
                {


                    /*" -5586- DISPLAY 'ERRO SELECT V0NOVACAO' */
                    _.Display($"ERRO SELECT V0NOVACAO");

                    /*" -5588- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5589- COMPUTE WS000-IOF-RAMO68 = V0NOVA-VL-IOF-MIP + V0NOVA-VL-IOF-DFI. */
            WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68.Value = V0NOVA_VL_IOF_MIP + V0NOVA_VL_IOF_DFI;

        }

        [StopWatch]
        /*" B2070-SELECT-V0NOVACAO-DB-SELECT-1 */
        public void B2070_SELECT_V0NOVACAO_DB_SELECT_1()
        {
            /*" -5574- EXEC SQL SELECT VALUE(SUM(VAL_IOF_MIP),0), VALUE(SUM(VAL_IOF_DFI),0) INTO :V0NOVA-VL-IOF-MIP, :V0NOVA-VL-IOF-DFI FROM SEGUROS.V0NOVACAO WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND DTMOVTO = :ENDO-DTINIVIG WITH UR END-EXEC. */

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
            /*" -5598- MOVE 'B2080' TO WNR-EXEC-SQL. */
            _.Move("B2080", WABEND.WNR_EXEC_SQL);

            /*" -5599- IF ENDO-CODSUBES = 0 */

            if (ENDO_CODSUBES == 0)
            {

                /*" -5615- PERFORM B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1 */

                B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1();

                /*" -5617- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5619- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5620- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5621- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5623- DISPLAY 'B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5626- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5628- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5629- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5630- ELSE */
                    }
                    else
                    {


                        /*" -5631- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5633- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5634- IF ENDO-CODSUBES > 0 */

            if (ENDO_CODSUBES > 0)
            {

                /*" -5654- PERFORM B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2 */

                B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2();

                /*" -5656- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5658- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5659- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5660- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5662- DISPLAY 'B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2080 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5665- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5667- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5668- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5669- ELSE */
                    }
                    else
                    {


                        /*" -5670- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5672- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5672- MOVE V0PRHA-VAL-IOF-TOTAL TO WS000-IOF-RAMO68. */
            _.Move(V0PRHA_VAL_IOF_TOTAL, WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68);

        }

        [StopWatch]
        /*" B2080-SELECT-V0PREMIO-HAB-DB-SELECT-1 */
        public void B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1()
        {
            /*" -5615- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_TOT),0) + VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM < '3' AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO WITH UR END-EXEC */

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
            /*" -5654- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_TOT),0) + VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C, SEGUROS.V0AGENTE_FINANC A WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM < '3' AND R.COD_SUBESTIPULANTE = A.COD_AGENTE AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO AND A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.COD_SUBGRUPO = :ENDO-CODSUBES WITH UR END-EXEC */

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
            /*" -5683- MOVE 'B2081' TO WNR-EXEC-SQL. */
            _.Move("B2081", WABEND.WNR_EXEC_SQL);

            /*" -5684- IF ENDO-CODSUBES = 0 */

            if (ENDO_CODSUBES == 0)
            {

                /*" -5700- PERFORM B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1 */

                B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1();

                /*" -5702- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5704- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5705- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5706- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5708- DISPLAY 'B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5711- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5713- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5714- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5715- ELSE */
                    }
                    else
                    {


                        /*" -5716- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5718- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5719- IF ENDO-CODSUBES > 0 */

            if (ENDO_CODSUBES > 0)
            {

                /*" -5739- PERFORM B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2 */

                B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2();

                /*" -5741- MOVE V0PRHA-VAL-IOF-TOTAL TO V0PRHA-VAL-IOF-TOTAL-ABS */
                _.Move(V0PRHA_VAL_IOF_TOTAL, V0PRHA_VAL_IOF_TOTAL_ABS);

                /*" -5743- MOVE V0PRHA-VAL-IOF-TOTAL-ABS TO V0PRHA-VAL-IOF-TOTAL */
                _.Move(V0PRHA_VAL_IOF_TOTAL_ABS, V0PRHA_VAL_IOF_TOTAL);

                /*" -5744- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5745- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -5747- DISPLAY 'B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT' */
                        _.Display($"B2081 - ENDOSSO NAO CADASTRADO NA V0RESUMO-HABIT");

                        /*" -5750- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE '  ' 'DTINIVIG: ' ENDO-DTINIVIG 'ENDOSSO:  ' ENDO-NRENDOS */

                        $"APOLICE:  {ENDO_NUM_APOLICE}  DTINIVIG: {ENDO_DTINIVIG}ENDOSSO:  {ENDO_NRENDOS}"
                        .Display();

                        /*" -5752- DISPLAY 'CLIENTE:  ' V0PRHA-CODCLIEN '  ' 'PRODUTO:  ' ENDO-CODPRODU */

                        $"CLIENTE:  {V0PRHA_CODCLIEN}  PRODUTO:  {ENDO_CODPRODU}"
                        .Display();

                        /*" -5753- GO TO 999-999-ROT-ERRO */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -5754- ELSE */
                    }
                    else
                    {


                        /*" -5755- DISPLAY 'ERRO SELECT V0RESUMO-HABIT' */
                        _.Display($"ERRO SELECT V0RESUMO-HABIT");

                        /*" -5757- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -5757- MOVE V0PRHA-VAL-IOF-TOTAL TO WS000-IOF-RAMO68. */
            _.Move(V0PRHA_VAL_IOF_TOTAL, WS000_AREA_AUX_RAMO68.WS000_IOF_RAMO68);

        }

        [StopWatch]
        /*" B2081-SELECT-V0PREMIO-HAB-DB-SELECT-1 */
        public void B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1()
        {
            /*" -5700- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM = '3' AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO WITH UR END-EXEC */

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
            /*" -5739- EXEC SQL SELECT VALUE(SUM(R.VAL_IOF_ATRASO),0) + VALUE(SUM(R.VAL_CORR_IOF_TOT),0) INTO :V0PRHA-VAL-IOF-TOTAL FROM SEGUROS.V0RESUMO_HABIT R, SEGUROS.V0CONTRO_REL_HABIT C, SEGUROS.V0AGENTE_FINANC A WHERE R.COD_PRODUTO = :ENDO-CODPRODU AND R.COD_CLIENTE = :V0PRHA-CODCLIEN AND R.COD_ITEM = '3' AND R.COD_SUBESTIPULANTE = A.COD_AGENTE AND C.COD_PRODUTO = :ENDO-CODPRODU AND C.COD_CLIENTE = :V0PRHA-CODCLIEN AND C.NUM_DOC = :ENDO-NRENDOS AND C.DATA_MOVIMENTO = R.DATA_MOVIMENTO AND A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.COD_SUBGRUPO = :ENDO-CODSUBES WITH UR END-EXEC */

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
        /*" B2090-00-SELECT-EFPREMIO-SECTION */
        private void B2090_00_SELECT_EFPREMIO_SECTION()
        {
            /*" -5780- MOVE 'B2090-0' TO WNR-EXEC-SQL. */
            _.Move("B2090-0", WABEND.WNR_EXEC_SQL);

            /*" -5835- PERFORM B2090_00_SELECT_EFPREMIO_DB_SELECT_1 */

            B2090_00_SELECT_EFPREMIO_DB_SELECT_1();

            /*" -5838- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5839- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5841- DISPLAY 'B2090 - ENDOSSO NAO CADASTRADO NAS TABELAS EF   ' */
                    _.Display($"B2090 - ENDOSSO NAO CADASTRADO NAS TABELAS EF   ");

                    /*" -5844- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE 'ENDOSSO:  ' ENDO-NRENDOS 'PRODUTO:  ' ENDO-CODPRODU */

                    $"APOLICE:  {ENDO_NUM_APOLICE}ENDOSSO:  {ENDO_NRENDOS}PRODUTO:  {ENDO_CODPRODU}"
                    .Display();

                    /*" -5845- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5846- ELSE */
                }
                else
                {


                    /*" -5847- DISPLAY 'R2090-ERRO SELECT TABELAS EF ' */
                    _.Display($"R2090-ERRO SELECT TABELAS EF ");

                    /*" -5849- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5851- IF WS-EF-VLR-EMISSAO EQUAL 0 AND WS-EF-VLR-CREDITO EQUAL 0 */

            if (WS_EF_VLR_EMISSAO == 0 && WS_EF_VLR_CREDITO == 0)
            {

                /*" -5855- PERFORM B2090-10-SELECT-EFFATURA. */

                B2090_10_SELECT_EFFATURA_SECTION();
            }


            /*" -5857- IF WS-EF-IOF-CREDITO EQUAL 0 AND WS-EF-IOF-EMISSAO EQUAL 0 */

            if (WS_EF_IOF_CREDITO == 0 && WS_EF_IOF_EMISSAO == 0)
            {

                /*" -5858- PERFORM A3510-LE-RAMOIND */

                A3510_LE_RAMOIND_SECTION();

                /*" -5860- COMPUTE WS-EF-IOF-CREDITO = WS-EF-VLR-CREDITO * RAMO-PERC-IOF */
                WS_EF_IOF_CREDITO.Value = WS_EF_VLR_CREDITO * RAMO_PERC_IOF;

                /*" -5862- COMPUTE WS-EF-IOF-EMISSAO = WS-EF-VLR-EMISSAO * RAMO-PERC-IOF */
                WS_EF_IOF_EMISSAO.Value = WS_EF_VLR_EMISSAO * RAMO_PERC_IOF;

                /*" -5864- COMPUTE WS-EF-VLR-EMISSAO = WS-EF-VLR-EMISSAO - WS-EF-IOF-EMISSAO */
                WS_EF_VLR_EMISSAO.Value = WS_EF_VLR_EMISSAO - WS_EF_IOF_EMISSAO;

                /*" -5865- IF WS-EF-IOF-EMISSAO > WS-EF-IOF-CREDITO */

                if (WS_EF_IOF_EMISSAO > WS_EF_IOF_CREDITO)
                {

                    /*" -5867- COMPUTE WS-EF-IOF-EMISSAO = WS-EF-IOF-EMISSAO + WS-EF-IOF-CREDITO */
                    WS_EF_IOF_EMISSAO.Value = WS_EF_IOF_EMISSAO + WS_EF_IOF_CREDITO;

                    /*" -5868- END-IF */
                }


                /*" -5870- MOVE ZEROS TO WS-EF-IOF-CREDITO. */
                _.Move(0, WS_EF_IOF_CREDITO);
            }


            /*" -5871- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -5873- MOVE 0 TO WS-EF-IOF-CREDITO WS-EF-VLR-CREDITO */
                _.Move(0, WS_EF_IOF_CREDITO, WS_EF_VLR_CREDITO);

                /*" -5874- ELSE */
            }
            else
            {


                /*" -5875- MOVE 0 TO WS-EF-VLR-EMISSAO WS-EF-IOF-EMISSAO. */
                _.Move(0, WS_EF_VLR_EMISSAO, WS_EF_IOF_EMISSAO);
            }


        }

        [StopWatch]
        /*" B2090-00-SELECT-EFPREMIO-DB-SELECT-1 */
        public void B2090_00_SELECT_EFPREMIO_DB_SELECT_1()
        {
            /*" -5835- EXEC SQL SELECT VALUE( SUM(CASE WHEN PE.IND_TIPO_PREMIO = '1' OR PE.IND_TIPO_PREMIO = '3' THEN VALUE(VLR_PREMIO_TARIF, 0.0) ELSE 0 END),0) CASE_VLR_EMISSAO ,VALUE( SUM(CASE WHEN PE.IND_TIPO_PREMIO = '2' THEN VALUE(VLR_PREMIO_TARIF, 0.0) ELSE 0 END),0) CASE_VLR_CREDITO ,VALUE( SUM(CASE WHEN PE.IND_TIPO_PREMIO = '1' OR PE.IND_TIPO_PREMIO = '3' THEN VALUE(VLR_IOF, 0.0) ELSE 0 END),0) CASE_VLR_IOF_EMIS ,VALUE( SUM(CASE WHEN PE.IND_TIPO_PREMIO = '2' THEN VALUE(VLR_IOF, 0.0) ELSE 0 END),0) CASE_VLR_IOF_CRED INTO :WS-EF-VLR-EMISSAO , :WS-EF-VLR-CREDITO , :WS-EF-IOF-EMISSAO , :WS-EF-IOF-CREDITO FROM SEGUROS.EF_ENDOSSO E, SEGUROS.EF_FATURAS_ENDOSSO FE, SEGUROS.EF_FATURA F, SEGUROS.EF_PREMIOS_FATURA PF, SEGUROS.EF_PREMIO_EMITIDO PE WHERE E.NUM_ENDOSSO = :ENDO-NRENDOS AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO AND F.COD_PRODUTO = :ENDO-CODPRODU AND F.NUM_CONTRATO = PF.NUM_CONTRATO_APOL AND F.SEQ_OPERACAO = PF.SEQ_OPERACAO_FATUR AND PF.NUM_CONTRATO_SEGUR = PE.NUM_CONTRATO_SEGUR AND PF.SEQ_PREMIO = PE.SEQ_PREMIO AND PF.NUM_CONTRATO_APOL = PF.NUM_CONTRATO_APOL WITH UR END-EXEC */

            var b2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1 = new B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1()
            {
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1.Execute(b2090_00_SELECT_EFPREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EF_VLR_EMISSAO, WS_EF_VLR_EMISSAO);
                _.Move(executed_1.WS_EF_VLR_CREDITO, WS_EF_VLR_CREDITO);
                _.Move(executed_1.WS_EF_IOF_EMISSAO, WS_EF_IOF_EMISSAO);
                _.Move(executed_1.WS_EF_IOF_CREDITO, WS_EF_IOF_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2090_999_EXIT*/

        [StopWatch]
        /*" B2090-10-SELECT-EFFATURA-SECTION */
        private void B2090_10_SELECT_EFFATURA_SECTION()
        {
            /*" -5912- MOVE 'B2090-1' TO WNR-EXEC-SQL. */
            _.Move("B2090-1", WABEND.WNR_EXEC_SQL);

            /*" -5938- PERFORM B2090_10_SELECT_EFFATURA_DB_SELECT_1 */

            B2090_10_SELECT_EFFATURA_DB_SELECT_1();

            /*" -5941- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5942- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5944- DISPLAY 'B2090-10 - ENDOSSO NAO CADASTRADO NA TAB EF-FATURA ' */
                    _.Display($"B2090-10 - ENDOSSO NAO CADASTRADO NA TAB EF-FATURA ");

                    /*" -5947- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE 'ENDOSSO:  ' ENDO-NRENDOS 'PRODUTO:  ' ENDO-CODPRODU */

                    $"APOLICE:  {ENDO_NUM_APOLICE}ENDOSSO:  {ENDO_NRENDOS}PRODUTO:  {ENDO_CODPRODU}"
                    .Display();

                    /*" -5948- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5949- ELSE */
                }
                else
                {


                    /*" -5950- DISPLAY 'B2090-10-ERRO SELECT TABELAS EF ' */
                    _.Display($"B2090-10-ERRO SELECT TABELAS EF ");

                    /*" -5952- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -5953- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -5955- MOVE 0 TO WS-EF-IOF-CREDITO WS-EF-VLR-CREDITO */
                _.Move(0, WS_EF_IOF_CREDITO, WS_EF_VLR_CREDITO);

                /*" -5956- ELSE */
            }
            else
            {


                /*" -5957- MOVE 0 TO WS-EF-VLR-EMISSAO WS-EF-IOF-EMISSAO. */
                _.Move(0, WS_EF_VLR_EMISSAO, WS_EF_IOF_EMISSAO);
            }


        }

        [StopWatch]
        /*" B2090-10-SELECT-EFFATURA-DB-SELECT-1 */
        public void B2090_10_SELECT_EFFATURA_DB_SELECT_1()
        {
            /*" -5938- EXEC SQL SELECT VALUE(SUM(VLR_EMISSAO - VALUE(VLR_IOF_EMISSAO,0)),0) ,VALUE(SUM(VLR_CREDITO - VALUE(VLR_IOF_CREDITO,0)),0) ,VALUE(SUM(VLR_IOF_EMISSAO),0) ,VALUE(SUM(VLR_IOF_CREDITO),0) INTO :WS-EF-VLR-EMISSAO , :WS-EF-VLR-CREDITO , :WS-EF-IOF-EMISSAO , :WS-EF-IOF-CREDITO FROM SEGUROS.EF_ENDOSSO E, SEGUROS.EF_FATURAS_ENDOSSO FE, SEGUROS.EF_FATURA F WHERE E.NUM_ENDOSSO = :ENDO-NRENDOS AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO AND F.COD_PRODUTO = :ENDO-CODPRODU WITH UR END-EXEC */

            var b2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1 = new B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1()
            {
                ENDO_CODPRODU = ENDO_CODPRODU.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1.Execute(b2090_10_SELECT_EFFATURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EF_VLR_EMISSAO, WS_EF_VLR_EMISSAO);
                _.Move(executed_1.WS_EF_VLR_CREDITO, WS_EF_VLR_CREDITO);
                _.Move(executed_1.WS_EF_IOF_EMISSAO, WS_EF_IOF_EMISSAO);
                _.Move(executed_1.WS_EF_IOF_CREDITO, WS_EF_IOF_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2090_10_99_EXIT*/

        [StopWatch]
        /*" B2091-00-SELECT-EFPREMIO-SECTION */
        private void B2091_00_SELECT_EFPREMIO_SECTION()
        {
            /*" -5973- MOVE 'B2091' TO WNR-EXEC-SQL. */
            _.Move("B2091", WABEND.WNR_EXEC_SQL);

            /*" -6002- PERFORM B2091_00_SELECT_EFPREMIO_DB_SELECT_1 */

            B2091_00_SELECT_EFPREMIO_DB_SELECT_1();

            /*" -6005- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6006- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6008- DISPLAY 'B2091 - ENDOSSO NAO CADASTRADO NAS TABELAS EF   ' */
                    _.Display($"B2091 - ENDOSSO NAO CADASTRADO NAS TABELAS EF   ");

                    /*" -6011- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE 'ENDOSSO:  ' ENDO-NRENDOS 'PRODUTO:  ' ENDO-CODPRODU */

                    $"APOLICE:  {ENDO_NUM_APOLICE}ENDOSSO:  {ENDO_NRENDOS}PRODUTO:  {ENDO_CODPRODU}"
                    .Display();

                    /*" -6012- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6013- ELSE */
                }
                else
                {


                    /*" -6014- DISPLAY 'R2091-ERRO SELECT TABELAS EF ' */
                    _.Display($"R2091-ERRO SELECT TABELAS EF ");

                    /*" -6024- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -6026- IF ENDO-NUM-APOLICE EQUAL 107700000022 OR 101402541675 OR 107700000026 OR 101402541678 */

            if (ENDO_NUM_APOLICE.In("107700000022", "101402541675", "107700000026", "101402541678"))
            {

                /*" -6028- MOVE ZEROS TO WS-EF-VLR-EMISSAO WS-EF-VLR-CREDITO WS-EF-IOF-EMISSAO WS-EF-IOF-CREDITO */
                _.Move(0, WS_EF_VLR_EMISSAO, WS_EF_VLR_CREDITO, WS_EF_IOF_EMISSAO, WS_EF_IOF_CREDITO);

                /*" -6029- PERFORM B2091-10-CALL-EF148S */

                B2091_10_CALL_EF148S_SECTION();

                /*" -6030- PERFORM B2091-20-SEL-EFPRM-POR-COB */

                B2091_20_SEL_EFPRM_POR_COB_SECTION();

                /*" -6034- END-IF */
            }


            /*" -6036- IF ENDO-NUM-APOLICE EQUAL 101402541679 OR 101402541682 OR 101402541681 OR 101402541683 */

            if (ENDO_NUM_APOLICE.In("101402541679", "101402541682", "101402541681", "101402541683"))
            {

                /*" -6042- MOVE ZEROS TO WS-EF-VLR-EMISSAO WS-EF-VLR-CREDITO WS-EF-IOF-EMISSAO WS-EF-IOF-CREDITO WS-EF-VLR-EMISSAO-14 WS-EF-VLR-CREDITO-14 WS-EF-IOF-EMISSAO-14 WS-EF-IOF-CREDITO-14 */
                _.Move(0, WS_EF_VLR_EMISSAO, WS_EF_VLR_CREDITO, WS_EF_IOF_EMISSAO, WS_EF_IOF_CREDITO, WS_EF_VLR_EMISSAO_14, WS_EF_VLR_CREDITO_14, WS_EF_IOF_EMISSAO_14, WS_EF_IOF_CREDITO_14);

                /*" -6043- PERFORM B2091-32-SEL-EFPRM-POR-COB-RD */

                B2091_32_SEL_EFPRM_POR_COB_RD_SECTION();

                /*" -6044- MOVE WS-EF-VLR-EMISSAO-14 TO WS-EF-VLR-EMISSAO */
                _.Move(WS_EF_VLR_EMISSAO_14, WS_EF_VLR_EMISSAO);

                /*" -6045- MOVE WS-EF-VLR-CREDITO-14 TO WS-EF-VLR-CREDITO */
                _.Move(WS_EF_VLR_CREDITO_14, WS_EF_VLR_CREDITO);

                /*" -6046- MOVE WS-EF-IOF-EMISSAO-14 TO WS-EF-IOF-EMISSAO */
                _.Move(WS_EF_IOF_EMISSAO_14, WS_EF_IOF_EMISSAO);

                /*" -6047- MOVE WS-EF-IOF-CREDITO-14 TO WS-EF-IOF-CREDITO */
                _.Move(WS_EF_IOF_CREDITO_14, WS_EF_IOF_CREDITO);

                /*" -6048- PERFORM B2096-ALTERA-V0COBERAPOL-EF */

                B2096_ALTERA_V0COBERAPOL_EF_SECTION();

                /*" -6051- END-IF */
            }


            /*" -6053- IF ENDO-NUM-APOLICE EQUAL 106100000018 OR 106100000030 OR 106100000033 OR 106100000036 */

            if (ENDO_NUM_APOLICE.In("106100000018", "106100000030", "106100000033", "106100000036"))
            {

                /*" -6061- MOVE ZEROS TO WS-EF-VLR-EMISSAO WS-EF-VLR-CREDITO WS-EF-IOF-EMISSAO WS-EF-IOF-CREDITO WS-EF-VLR-EMISSAO-61 WS-EF-VLR-EMISSAO-65 WS-EF-VLR-CREDITO-61 WS-EF-VLR-CREDITO-65 WS-EF-IOF-EMISSAO-61 WS-EF-IOF-EMISSAO-65 WS-EF-IOF-CREDITO-61 WS-EF-IOF-CREDITO-65 */
                _.Move(0, WS_EF_VLR_EMISSAO, WS_EF_VLR_CREDITO, WS_EF_IOF_EMISSAO, WS_EF_IOF_CREDITO, WS_EF_VLR_EMISSAO_61, WS_EF_VLR_EMISSAO_65, WS_EF_VLR_CREDITO_61, WS_EF_VLR_CREDITO_65, WS_EF_IOF_EMISSAO_61, WS_EF_IOF_EMISSAO_65, WS_EF_IOF_CREDITO_61, WS_EF_IOF_CREDITO_65);

                /*" -6062- PERFORM B2091-10-CALL-EF148S */

                B2091_10_CALL_EF148S_SECTION();

                /*" -6063- PERFORM B2091-20-SEL-EFPRM-POR-COB */

                B2091_20_SEL_EFPRM_POR_COB_SECTION();

                /*" -6064- MOVE WS-EF-VLR-EMISSAO TO WS-EF-VLR-EMISSAO-61 */
                _.Move(WS_EF_VLR_EMISSAO, WS_EF_VLR_EMISSAO_61);

                /*" -6065- MOVE WS-EF-VLR-CREDITO TO WS-EF-VLR-CREDITO-61 */
                _.Move(WS_EF_VLR_CREDITO, WS_EF_VLR_CREDITO_61);

                /*" -6066- MOVE WS-EF-IOF-EMISSAO TO WS-EF-IOF-EMISSAO-61 */
                _.Move(WS_EF_IOF_EMISSAO, WS_EF_IOF_EMISSAO_61);

                /*" -6069- MOVE WS-EF-IOF-CREDITO TO WS-EF-IOF-CREDITO-61 */
                _.Move(WS_EF_IOF_CREDITO, WS_EF_IOF_CREDITO_61);

                /*" -6071- PERFORM B2091-31-SEL-EFPRM-POR-COB-DFI */

                B2091_31_SEL_EFPRM_POR_COB_DFI_SECTION();

                /*" -6072- ADD WS-EF-VLR-EMISSAO-65 TO WS-EF-VLR-EMISSAO */
                WS_EF_VLR_EMISSAO.Value = WS_EF_VLR_EMISSAO + WS_EF_VLR_EMISSAO_65;

                /*" -6073- ADD WS-EF-VLR-CREDITO-65 TO WS-EF-VLR-CREDITO */
                WS_EF_VLR_CREDITO.Value = WS_EF_VLR_CREDITO + WS_EF_VLR_CREDITO_65;

                /*" -6074- ADD WS-EF-IOF-EMISSAO-65 TO WS-EF-IOF-EMISSAO */
                WS_EF_IOF_EMISSAO.Value = WS_EF_IOF_EMISSAO + WS_EF_IOF_EMISSAO_65;

                /*" -6077- ADD WS-EF-IOF-CREDITO-65 TO WS-EF-IOF-CREDITO */
                WS_EF_IOF_CREDITO.Value = WS_EF_IOF_CREDITO + WS_EF_IOF_CREDITO_65;

                /*" -6078- PERFORM B2095-ALTERA-V0COBERAPOL-EF */

                B2095_ALTERA_V0COBERAPOL_EF_SECTION();

                /*" -6093- END-IF. */
            }


            /*" -6095- MOVE SPACES TO WS-VL-IOF-IGUAIS */
            _.Move("", WS_VL_IOF_IGUAIS);

            /*" -6096- IF WS-EF-IOF-CREDITO = WS-EF-IOF-EMISSAO */

            if (WS_EF_IOF_CREDITO == WS_EF_IOF_EMISSAO)
            {

                /*" -6097- MOVE 'S' TO WS-VL-IOF-IGUAIS */
                _.Move("S", WS_VL_IOF_IGUAIS);

                /*" -6100- END-IF */
            }


            /*" -6101- IF WS-EF-IOF-CREDITO < WS-EF-IOF-EMISSAO */

            if (WS_EF_IOF_CREDITO < WS_EF_IOF_EMISSAO)
            {

                /*" -6103- COMPUTE WS-EF-IOF-EMISSAO = WS-EF-IOF-EMISSAO - WS-EF-IOF-CREDITO */
                WS_EF_IOF_EMISSAO.Value = WS_EF_IOF_EMISSAO - WS_EF_IOF_CREDITO;

                /*" -6105- COMPUTE WS-EF-VLR-EMISSAO = WS-EF-VLR-EMISSAO - WS-EF-IOF-EMISSAO */
                WS_EF_VLR_EMISSAO.Value = WS_EF_VLR_EMISSAO - WS_EF_IOF_EMISSAO;

                /*" -6108- MOVE ZEROS TO WS-EF-IOF-CREDITO. */
                _.Move(0, WS_EF_IOF_CREDITO);
            }


            /*" -6109- IF WS-EF-IOF-CREDITO > WS-EF-IOF-EMISSAO */

            if (WS_EF_IOF_CREDITO > WS_EF_IOF_EMISSAO)
            {

                /*" -6113- COMPUTE WS-EF-VLR-EMISSAO = WS-EF-VLR-EMISSAO - WS-EF-IOF-EMISSAO */
                WS_EF_VLR_EMISSAO.Value = WS_EF_VLR_EMISSAO - WS_EF_IOF_EMISSAO;

                /*" -6116- COMPUTE WS-EF-VLR-CREDITO = WS-EF-VLR-CREDITO - WS-EF-IOF-EMISSAO */
                WS_EF_VLR_CREDITO.Value = WS_EF_VLR_CREDITO - WS_EF_IOF_EMISSAO;

                /*" -6118- MOVE ZEROS TO WS-EF-IOF-EMISSAO WS-EF-IOF-CREDITO. */
                _.Move(0, WS_EF_IOF_EMISSAO, WS_EF_IOF_CREDITO);
            }


        }

        [StopWatch]
        /*" B2091-00-SELECT-EFPREMIO-DB-SELECT-1 */
        public void B2091_00_SELECT_EFPREMIO_DB_SELECT_1()
        {
            /*" -6002- EXEC SQL SELECT VALUE(SUM(F.VLR_EMISSAO),0) , (VALUE(SUM(F.VLR_CREDITO) * -1,0)) , VALUE(SUM(F.VLR_IOF_EMISSAO),0) , (VALUE(SUM(F.VLR_IOF_CREDITO) * -1,0)) INTO :WS-EF-VLR-EMISSAO , :WS-EF-VLR-CREDITO , :WS-EF-IOF-EMISSAO , :WS-EF-IOF-CREDITO FROM SEGUROS.EF_ENDOSSO E, SEGUROS.EF_FATURAS_ENDOSSO FE, SEGUROS.EF_FATURA F , SEGUROS.EF_APOLICE A WHERE E.NUM_ENDOSSO = :ENDO-NRENDOS AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO AND A.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR AND A.NUM_APOLICE = :ENDO-NUM-APOLICE WITH UR END-EXEC. */

            var b2091_00_SELECT_EFPREMIO_DB_SELECT_1_Query1 = new B2091_00_SELECT_EFPREMIO_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2091_00_SELECT_EFPREMIO_DB_SELECT_1_Query1.Execute(b2091_00_SELECT_EFPREMIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EF_VLR_EMISSAO, WS_EF_VLR_EMISSAO);
                _.Move(executed_1.WS_EF_VLR_CREDITO, WS_EF_VLR_CREDITO);
                _.Move(executed_1.WS_EF_IOF_EMISSAO, WS_EF_IOF_EMISSAO);
                _.Move(executed_1.WS_EF_IOF_CREDITO, WS_EF_IOF_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2091_999_EXIT*/

        [StopWatch]
        /*" B2091-10-CALL-EF148S-SECTION */
        private void B2091_10_CALL_EF148S_SECTION()
        {
            /*" -6130- MOVE 'B2091-10' TO WNR-EXEC-SQL. */
            _.Move("B2091-10", WABEND.WNR_EXEC_SQL);

            /*" -6132- INITIALIZE PARAM-APORTE-CAIXA. */
            _.Initialize(
                PARAM_APORTE_CAIXA
            );

            /*" -6133- MOVE 'C' TO EF148-OPERACAO. */
            _.Move("C", PARAM_APORTE_CAIXA.EF148_OPERACAO);

            /*" -6134- MOVE ENDO-CODPRODU TO EF148-COD-PRODUTO-14 . */
            _.Move(ENDO_CODPRODU, PARAM_APORTE_CAIXA.EF148_COD_PRODUTO_14);

            /*" -6135- MOVE SIST-DTMOVABE TO EF148-DTH-INI-VIGENCIA. */
            _.Move(SIST_DTMOVABE, PARAM_APORTE_CAIXA.EF148_DTH_INI_VIGENCIA);

            /*" -6144- MOVE ENDO-NUM-APOLICE TO EF148-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, PARAM_APORTE_CAIXA.EF148_NUM_APOLICE);

            /*" -6161- CALL 'EF148S' USING PARAM-APORTE-CAIXA. */
            _.Call("EF148S", PARAM_APORTE_CAIXA);

            /*" -6162- IF EF148-RETORNO NOT EQUAL ZERO */

            if (PARAM_APORTE_CAIXA.EF148_RETORNO != 00)
            {

                /*" -6164- DISPLAY 'B2091-10 - ERRO CHAMADA EF148S - EF-PROD-ACESSORIO ' */
                _.Display($"B2091-10 - ERRO CHAMADA EF148S - EF-PROD-ACESSORIO ");

                /*" -6167- DISPLAY 'APOLICE:  ' ENDO-NUM-APOLICE 'ENDOSSO:  ' ENDO-NRENDOS 'PRODUTO:  ' ENDO-CODPRODU */

                $"APOLICE:  {ENDO_NUM_APOLICE}ENDOSSO:  {ENDO_NRENDOS}PRODUTO:  {ENDO_CODPRODU}"
                .Display();

                /*" -6176- DISPLAY 'RETORNO:  ' EF148-RETORNO 'OPERACA:  ' EF148-OPERACAO 'NCNTRAP:  ' EF148-NUM-CONTRATO-APOL 'PRODUTO:  ' EF148-COD-PRODUTO 'COBERTU:  ' EF148-COD-COBERTURA 'PROD-AC:  ' EF148-COD-PRODUTO-14 'COBE-AC:  ' EF148-COD-COBERTURA-ACESS 'DTINIVI:  ' EF148-DTH-INI-VIGENCIA 'APOL-EF:  ' EF148-NUM-APOLICE-EF */

                $"RETORNO:  {PARAM_APORTE_CAIXA.EF148_RETORNO}OPERACA:  {PARAM_APORTE_CAIXA.EF148_OPERACAO}NCNTRAP:  {PARAM_APORTE_CAIXA.EF148_NUM_CONTRATO_APOL}PRODUTO:  {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO}COBERTU:  {PARAM_APORTE_CAIXA.EF148_COD_COBERTURA}PROD-AC:  {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO_14}COBE-AC:  {PARAM_APORTE_CAIXA.EF148_COD_COBERTURA_ACESS}DTINIVI:  {PARAM_APORTE_CAIXA.EF148_DTH_INI_VIGENCIA}APOL-EF:  {PARAM_APORTE_CAIXA.EF148_NUM_APOLICE_EF}"
                .Display();

                /*" -6178- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6179- MOVE EF148-NUM-APOLICE-EF TO WHOST-NUM-APOLICE-EF. */
            _.Move(PARAM_APORTE_CAIXA.EF148_NUM_APOLICE_EF, WHOST_NUM_APOLICE_EF);

            /*" -6179- MOVE EF148-COD-COBERTURA TO WHOST-COD-COBERTURA. */
            _.Move(PARAM_APORTE_CAIXA.EF148_COD_COBERTURA, WHOST_COD_COBERTURA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2091_10_999_EXIT*/

        [StopWatch]
        /*" B2091-20-SEL-EFPRM-POR-COB-SECTION */
        private void B2091_20_SEL_EFPRM_POR_COB_SECTION()
        {
            /*" -6194- MOVE 'B2091-20' TO WNR-EXEC-SQL. */
            _.Move("B2091-20", WABEND.WNR_EXEC_SQL);

            /*" -6220- PERFORM B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1 */

            B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1();

            /*" -6223- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6224- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6226- DISPLAY 'B2091-20 - ENDOSSO NAO CADASTRADO NAS TABELAS EF' */
                    _.Display($"B2091-20 - ENDOSSO NAO CADASTRADO NAS TABELAS EF");

                    /*" -6230- DISPLAY 'APOLICE:  ' WHOST-NUM-APOLICE-EF 'ENDOSSO:  ' ENDO-NRENDOS 'PRODUTO:  ' EF148-COD-PRODUTO 'COBERTU:  ' WHOST-COD-COBERTURA */

                    $"APOLICE:  {WHOST_NUM_APOLICE_EF}ENDOSSO:  {ENDO_NRENDOS}PRODUTO:  {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO}COBERTU:  {WHOST_COD_COBERTURA}"
                    .Display();

                    /*" -6231- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6232- ELSE */
                }
                else
                {


                    /*" -6233- DISPLAY 'R2091-20-ERRO SELECT TABELAS EF ' */
                    _.Display($"R2091-20-ERRO SELECT TABELAS EF ");

                    /*" -6233- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B2091-20-SEL-EFPRM-POR-COB-DB-SELECT-1 */
        public void B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1()
        {
            /*" -6220- EXEC SQL SELECT VALUE(SUM(F.VLR_EMISSAO),0) , (VALUE(SUM(F.VLR_CREDITO) * -1,0)) , VALUE(SUM(F.VLR_IOF_EMISSAO),0) , (VALUE(SUM(F.VLR_IOF_CREDITO) * -1,0)) INTO :WS-EF-VLR-EMISSAO , :WS-EF-VLR-CREDITO , :WS-EF-IOF-EMISSAO , :WS-EF-IOF-CREDITO FROM SEGUROS.EF_ENDOSSO E, SEGUROS.EF_FATURAS_ENDOSSO FE, SEGUROS.EF_FATURA F , SEGUROS.EF_APOLICE A WHERE E.NUM_ENDOSSO = :ENDO-NRENDOS AND E.NUM_ENDOSSO = FE.NUM_ENDOSSO AND E.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR AND FE.NUM_CONTRATO_FATUR = F.NUM_CONTRATO AND FE.SEQ_OPERACAO_FATUR = F.SEQ_OPERACAO AND A.NUM_CONTRATO = FE.NUM_CONTRATO_FATUR AND A.NUM_APOLICE = :WHOST-NUM-APOLICE-EF AND F.COD_COBERTURA = :WHOST-COD-COBERTURA WITH UR END-EXEC. */

            var b2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1_Query1 = new B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1_Query1()
            {
                WHOST_NUM_APOLICE_EF = WHOST_NUM_APOLICE_EF.ToString(),
                WHOST_COD_COBERTURA = WHOST_COD_COBERTURA.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1_Query1.Execute(b2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EF_VLR_EMISSAO, WS_EF_VLR_EMISSAO);
                _.Move(executed_1.WS_EF_VLR_CREDITO, WS_EF_VLR_CREDITO);
                _.Move(executed_1.WS_EF_IOF_EMISSAO, WS_EF_IOF_EMISSAO);
                _.Move(executed_1.WS_EF_IOF_CREDITO, WS_EF_IOF_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2091_20_999_EXIT*/

        [StopWatch]
        /*" B2091-31-SEL-EFPRM-POR-COB-DFI-SECTION */
        private void B2091_31_SEL_EFPRM_POR_COB_DFI_SECTION()
        {
            /*" -6257- MOVE 'B2091-31' TO WNR-EXEC-SQL. */
            _.Move("B2091-31", WABEND.WNR_EXEC_SQL);

            /*" -6316- PERFORM B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1 */

            B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1();

            /*" -6319- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6320- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6322- DISPLAY 'B2091-31-SEL-EFPRM-POR-COB-DFI' ' - ENDOSSO NAO CADASTRADO NAS TABELAS EF' */
                    _.Display($"B2091-31-SEL-EFPRM-POR-COB-DFI - ENDOSSO NAO CADASTRADO NAS TABELAS EF");

                    /*" -6329- DISPLAY '  ENDOSSO : ' ENDO-NRENDOS '  APOLICE : ' ENDO-NUM-APOLICE '  COD COB : ' WHOST-COD-COBERTURA ' P. ACESS : ' EF148-COD-PRODUTO-14 '  APOL EF : ' WHOST-NUM-APOLICE-EF '   COB EF : ' EF148-COD-COBERTURA '  PROD EF : ' EF148-COD-PRODUTO */

                    $"  ENDOSSO : {ENDO_NRENDOS}  APOLICE : {ENDO_NUM_APOLICE}  COD COB : {WHOST_COD_COBERTURA} P. ACESS : {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO_14}  APOL EF : {WHOST_NUM_APOLICE_EF}   COB EF : {PARAM_APORTE_CAIXA.EF148_COD_COBERTURA}  PROD EF : {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO}"
                    .Display();

                    /*" -6330- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6331- ELSE */
                }
                else
                {


                    /*" -6332- DISPLAY 'R2091-31-ERRO SELECT TABELAS EF ' */
                    _.Display($"R2091-31-ERRO SELECT TABELAS EF ");

                    /*" -6333- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6334- END-IF */
                }


                /*" -6334- END-IF. */
            }


        }

        [StopWatch]
        /*" B2091-31-SEL-EFPRM-POR-COB-DFI-DB-SELECT-1 */
        public void B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1()
        {
            /*" -6316- EXEC SQL SELECT VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1 OR EF066.IND_TIPO_PREMIO = 3 THEN EF157.VLR_PREMIO_ACESS + EF157.VLR_IOF_ACESS ELSE 0 END),0) VLR_EMISSAO_A_65 ,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2 THEN EF157.VLR_PREMIO_ACESS + EF157.VLR_IOF_ACESS ELSE 0 END),0) * -1) VLR_CREDITO_A_65 ,VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1 OR EF066.IND_TIPO_PREMIO = 3 THEN EF157.VLR_IOF_ACESS ELSE 0 END),0) VLR_IOF_EMISSAO_A_65 ,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2 THEN EF157.VLR_IOF_ACESS ELSE 0 END),0) * -1) VLR_IOF_CREDITO_A_65 INTO :WS-EF-VLR-EMISSAO-65 , :WS-EF-VLR-CREDITO-65 , :WS-EF-IOF-EMISSAO-65 , :WS-EF-IOF-CREDITO-65 FROM SEGUROS.EF_ENDOSSO EF053 JOIN SEGUROS.EF_FATURAS_ENDOSSO EF054 ON EF054.NUM_ENDOSSO = EF053.NUM_ENDOSSO AND EF054.NUM_CONTRATO_FATUR = EF053.NUM_CONTRATO JOIN SEGUROS.EF_FATURA EF056 ON EF056.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR AND EF056.SEQ_OPERACAO = EF054.SEQ_OPERACAO_FATUR JOIN SEGUROS.EF_APOLICE EF063 ON EF063.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR JOIN SEGUROS.ENDOSSOS ENDOS ON ENDOS.NUM_ENDOSSO = EF053.NUM_ENDOSSO AND ENDOS.NUM_APOLICE = EF063.NUM_APOLICE JOIN SEGUROS.EF_PREMIOS_FATURA EF060 ON EF060.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO AND EF060.SEQ_OPERACAO_FATUR = EF056.SEQ_OPERACAO JOIN SEGUROS.EF_PREMIO_EMITIDO EF066 ON EF066.NUM_CONTRATO_SEGUR = EF060.NUM_CONTRATO_SEGUR AND EF066.SEQ_PREMIO = EF060.SEQ_PREMIO JOIN SEGUROS.EF_PREMIO_COB_ACESS EF157 ON EF157.NUM_CONTRATO_SEGUR = EF066.NUM_CONTRATO_SEGUR AND EF157.SEQ_PREMIO = EF066.SEQ_PREMIO AND EF157.COD_COB_ACESS = EF066.COD_COBERTURA WHERE EF053.NUM_ENDOSSO = :ENDO-NRENDOS AND EF063.NUM_APOLICE = :ENDO-NUM-APOLICE WITH UR END-EXEC. */

            var b2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1_Query1 = new B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1_Query1.Execute(b2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EF_VLR_EMISSAO_65, WS_EF_VLR_EMISSAO_65);
                _.Move(executed_1.WS_EF_VLR_CREDITO_65, WS_EF_VLR_CREDITO_65);
                _.Move(executed_1.WS_EF_IOF_EMISSAO_65, WS_EF_IOF_EMISSAO_65);
                _.Move(executed_1.WS_EF_IOF_CREDITO_65, WS_EF_IOF_CREDITO_65);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2091_00_999_EXIC*/

        [StopWatch]
        /*" B2091-32-SEL-EFPRM-POR-COB-RD-SECTION */
        private void B2091_32_SEL_EFPRM_POR_COB_RD_SECTION()
        {
            /*" -6349- MOVE 'B2091-32' TO WNR-EXEC-SQL. */
            _.Move("B2091-32", WABEND.WNR_EXEC_SQL);

            /*" -6415- PERFORM B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1 */

            B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1();

            /*" -6418- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6419- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -6421- DISPLAY 'B2091-32-SEL-EFPRM-POR-COB-RD' ' - ENDOSSO NAO CADASTRADO NAS TABELAS EF' */
                    _.Display($"B2091-32-SEL-EFPRM-POR-COB-RD - ENDOSSO NAO CADASTRADO NAS TABELAS EF");

                    /*" -6428- DISPLAY '  ENDOSSO : ' ENDO-NRENDOS '  APOLICE : ' ENDO-NUM-APOLICE '  COD COB : ' WHOST-COD-COBERTURA ' P. ACESS : ' EF148-COD-PRODUTO-14 '  APOL EF : ' WHOST-NUM-APOLICE-EF '   COB EF : ' EF148-COD-COBERTURA '  PROD EF : ' EF148-COD-PRODUTO */

                    $"  ENDOSSO : {ENDO_NRENDOS}  APOLICE : {ENDO_NUM_APOLICE}  COD COB : {WHOST_COD_COBERTURA} P. ACESS : {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO_14}  APOL EF : {WHOST_NUM_APOLICE_EF}   COB EF : {PARAM_APORTE_CAIXA.EF148_COD_COBERTURA}  PROD EF : {PARAM_APORTE_CAIXA.EF148_COD_PRODUTO}"
                    .Display();

                    /*" -6429- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6430- ELSE */
                }
                else
                {


                    /*" -6431- DISPLAY 'R2091-32-ERRO SELECT TABELAS EF ' */
                    _.Display($"R2091-32-ERRO SELECT TABELAS EF ");

                    /*" -6432- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6433- END-IF */
                }


                /*" -6433- END-IF. */
            }


        }

        [StopWatch]
        /*" B2091-32-SEL-EFPRM-POR-COB-RD-DB-SELECT-1 */
        public void B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1()
        {
            /*" -6415- EXEC SQL SELECT VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1 OR EF066.IND_TIPO_PREMIO = 3 THEN EF157.VLR_PREMIO_ACESS + EF157.VLR_IOF_ACESS ELSE 0 END),0) VLR_EMISSAO_A_14 ,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2 THEN EF157.VLR_PREMIO_ACESS + EF157.VLR_IOF_ACESS ELSE 0 END),0) * -1) VLR_CREDITO_A_14 ,VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 1 OR EF066.IND_TIPO_PREMIO = 3 THEN EF157.VLR_IOF_ACESS ELSE 0 END),0) VLR_IOF_EMISSAO_A_14 ,(VALUE(SUM(CASE WHEN EF066.IND_TIPO_PREMIO = 2 THEN EF157.VLR_IOF_ACESS ELSE 0 END),0) * -1) VLR_IOF_CREDITO_A_14 INTO :WS-EF-VLR-EMISSAO-14 , :WS-EF-VLR-CREDITO-14 , :WS-EF-IOF-EMISSAO-14 , :WS-EF-IOF-CREDITO-14 FROM SEGUROS.EF_ENDOSSO EF053 JOIN SEGUROS.EF_FATURAS_ENDOSSO EF054 ON EF054.NUM_ENDOSSO = EF053.NUM_ENDOSSO AND EF054.NUM_CONTRATO_FATUR = EF053.NUM_CONTRATO JOIN SEGUROS.EF_FATURA EF056 ON EF056.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR AND EF056.SEQ_OPERACAO = EF054.SEQ_OPERACAO_FATUR JOIN SEGUROS.EF_APOLICE EF063 ON EF063.NUM_CONTRATO = EF054.NUM_CONTRATO_FATUR JOIN SEGUROS.EF_PROD_ACESSORIO EF148 ON EF148.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO AND EF148.COD_PRODUTO = EF056.COD_PRODUTO AND EF148.COD_COBERTURA = EF056.COD_COBERTURA AND EF056.DTH_REFERENCIA BETWEEN EF148.DTH_INI_VIGENCIA AND EF148.DTH_FIM_VIGENCIA JOIN SEGUROS.ENDOSSOS ENDOS ON ENDOS.NUM_ENDOSSO = EF053.NUM_ENDOSSO AND ENDOS.NUM_APOLICE = EF148.NUM_APOLICE JOIN SEGUROS.EF_PREMIOS_FATURA EF060 ON EF060.NUM_CONTRATO_APOL = EF056.NUM_CONTRATO AND EF060.SEQ_OPERACAO_FATUR = EF056.SEQ_OPERACAO JOIN SEGUROS.EF_PREMIO_EMITIDO EF066 ON EF066.NUM_CONTRATO_SEGUR = EF060.NUM_CONTRATO_SEGUR AND EF066.SEQ_PREMIO = EF060.SEQ_PREMIO JOIN SEGUROS.EF_PREMIO_COB_ACESS EF157 ON EF157.NUM_CONTRATO_SEGUR = EF066.NUM_CONTRATO_SEGUR AND EF157.SEQ_PREMIO = EF066.SEQ_PREMIO AND EF157.COD_COB_ACESS = EF148.COD_COBERTURA_ACESS WHERE EF053.NUM_ENDOSSO = :ENDO-NRENDOS AND EF148.NUM_APOLICE = :ENDO-NUM-APOLICE WITH UR END-EXEC. */

            var b2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1 = new B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1()
            {
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            var executed_1 = B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1.Execute(b2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_EF_VLR_EMISSAO_14, WS_EF_VLR_EMISSAO_14);
                _.Move(executed_1.WS_EF_VLR_CREDITO_14, WS_EF_VLR_CREDITO_14);
                _.Move(executed_1.WS_EF_IOF_EMISSAO_14, WS_EF_IOF_EMISSAO_14);
                _.Move(executed_1.WS_EF_IOF_CREDITO_14, WS_EF_IOF_CREDITO_14);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2091_999_EXIC*/

        [StopWatch]
        /*" B2092-00-MONTA-PARCELA-EF-CONS-SECTION */
        private void B2092_00_MONTA_PARCELA_EF_CONS_SECTION()
        {
            /*" -6451- MOVE 'B2092' TO WNR-EXEC-SQL. */
            _.Move("B2092", WABEND.WNR_EXEC_SQL);

            /*" -6452- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -6456- MOVE WS-EF-VLR-EMISSAO TO VL-LIQ-IX VL-LIQUIDO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(WS_EF_VLR_EMISSAO, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -6460- MOVE 0 TO VL-ADIC-IX VL-ADICIONAL VL-CUSTO-IX VL-CUSTO */
                _.Move(0, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -6463- MOVE WS-EF-IOF-EMISSAO TO VL-IOF-IX VL-IOF */
                _.Move(WS_EF_IOF_EMISSAO, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -6467- COMPUTE VL-TOTAL = VL-TARIFARIO-IX + VL-ADICIONAL + VL-CUSTO + VL-IOF */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_TARIFARIO_IX + EM0901W099.VL_ADICIONAL + EM0901W099.VL_CUSTO + EM0901W099.VL_IOF;

                /*" -6469- MOVE VL-TOTAL TO VL-TOTAL-IX */
                _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

                /*" -6471- ELSE */
            }
            else
            {


                /*" -6472- COMPUTE WS-EF-VLR-CREDITO = WS-EF-VLR-CREDITO * -1 */
                WS_EF_VLR_CREDITO.Value = WS_EF_VLR_CREDITO * -1;

                /*" -6473- COMPUTE WS-EF-IOF-CREDITO = WS-EF-IOF-CREDITO * -1 */
                WS_EF_IOF_CREDITO.Value = WS_EF_IOF_CREDITO * -1;

                /*" -6477- MOVE WS-EF-VLR-CREDITO TO VL-LIQ-IX VL-LIQUIDO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(WS_EF_VLR_CREDITO, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -6481- MOVE 0 TO VL-ADIC-IX VL-ADICIONAL VL-CUSTO-IX VL-CUSTO */
                _.Move(0, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -6484- MOVE WS-EF-IOF-CREDITO TO VL-IOF-IX VL-IOF */
                _.Move(WS_EF_IOF_CREDITO, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -6488- COMPUTE VL-TOTAL = VL-TARIFARIO-IX + VL-ADICIONAL + VL-CUSTO + VL-IOF */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_TARIFARIO_IX + EM0901W099.VL_ADICIONAL + EM0901W099.VL_CUSTO + EM0901W099.VL_IOF;

                /*" -6488- MOVE VL-TOTAL TO VL-TOTAL-IX. */
                _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2092_999_EXIT*/

        [StopWatch]
        /*" B2093-00-MONTA-PARCELA-EF-HABI-SECTION */
        private void B2093_00_MONTA_PARCELA_EF_HABI_SECTION()
        {
            /*" -6505- MOVE 'B2093' TO WNR-EXEC-SQL. */
            _.Move("B2093", WABEND.WNR_EXEC_SQL);

            /*" -6506- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -6510- MOVE WS-EF-VLR-EMISSAO TO VL-LIQ-IX VL-LIQUIDO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(WS_EF_VLR_EMISSAO, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -6514- MOVE 0 TO VL-ADIC-IX VL-ADICIONAL VL-CUSTO-IX VL-CUSTO */
                _.Move(0, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -6517- MOVE WS-EF-IOF-EMISSAO TO VL-IOF-IX VL-IOF */
                _.Move(WS_EF_IOF_EMISSAO, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -6521- COMPUTE VL-TOTAL = VL-TARIFARIO-IX + VL-ADICIONAL + VL-CUSTO + VL-IOF */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_TARIFARIO_IX + EM0901W099.VL_ADICIONAL + EM0901W099.VL_CUSTO + EM0901W099.VL_IOF;

                /*" -6523- MOVE VL-TOTAL TO VL-TOTAL-IX */
                _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

                /*" -6525- ELSE */
            }
            else
            {


                /*" -6529- MOVE WS-EF-VLR-CREDITO TO VL-LIQ-IX VL-LIQUIDO VL-TARIFARIO-IX VL-TARIFA */
                _.Move(WS_EF_VLR_CREDITO, EM0901W099.VL_LIQ_IX, EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_TARIFA);

                /*" -6533- MOVE 0 TO VL-ADIC-IX VL-ADICIONAL VL-CUSTO-IX VL-CUSTO */
                _.Move(0, EM0901W099.VL_ADIC_IX, EM0901W099.VL_ADICIONAL, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_CUSTO);

                /*" -6536- MOVE WS-EF-IOF-CREDITO TO VL-IOF-IX VL-IOF */
                _.Move(WS_EF_IOF_CREDITO, EM0901W099.VL_IOF_IX, EM0901W099.VL_IOF);

                /*" -6540- COMPUTE VL-TOTAL = VL-TARIFARIO-IX + VL-ADICIONAL + VL-CUSTO + VL-IOF */
                EM0901W099.VL_TOTAL.Value = EM0901W099.VL_TARIFARIO_IX + EM0901W099.VL_ADICIONAL + EM0901W099.VL_CUSTO + EM0901W099.VL_IOF;

                /*" -6543- MOVE VL-TOTAL TO VL-TOTAL-IX. */
                _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);
            }


            /*" -6545- IF ENDO-NUM-APOLICE = 106800000024 OR ENDO-NUM-APOLICE = 106100000011 */

            if (ENDO_NUM_APOLICE == 106800000024 || ENDO_NUM_APOLICE == 106100000011)
            {

                /*" -6546- MOVE COBT-TARIFARIO-IX TO VL-TOTAL-IX VL-TOTAL */
                _.Move(COBT_TARIFARIO_IX, EM0901W099.VL_TOTAL_IX, EM0901W099.VL_TOTAL);

                /*" -6546- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2093_999_EXIT*/

        [StopWatch]
        /*" B2094-ALTERA-V0COBERAPOL-SECTION */
        private void B2094_ALTERA_V0COBERAPOL_SECTION()
        {
            /*" -6556- MOVE 'B2094' TO WNR-EXEC-SQL. */
            _.Move("B2094", WABEND.WNR_EXEC_SQL);

            /*" -6563- PERFORM B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1 */

            B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1();

            /*" -6566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6569- DISPLAY ' R2094-ERRO UPDATE V0COBERAPOL -P/EF ' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $" R2094-ERRO UPDATE V0COBERAPOL -P/EF  {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -6569- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2094-ALTERA-V0COBERAPOL-DB-UPDATE-1 */
        public void B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -6563- EXEC SQL UPDATE SEGUROS.V1COBERAPOL SET PRM_TARIFARIO_VAR = :WS-VL-COB, PRM_TARIFARIO_IX = :WS-VL-COB, PCT_COBERTURA = 100 WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

            var b2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1 = new B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1()
            {
                WS_VL_COB = WS_VL_COB.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1.Execute(b2094_ALTERA_V0COBERAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2094_999_EXIT*/

        [StopWatch]
        /*" B2095-ALTERA-V0COBERAPOL-EF-SECTION */
        private void B2095_ALTERA_V0COBERAPOL_EF_SECTION()
        {
            /*" -6586- MOVE 'B2095' TO WNR-EXEC-SQL. */
            _.Move("B2095", WABEND.WNR_EXEC_SQL);

            /*" -6587- IF WS-EF-IOF-CREDITO-61 < WS-EF-IOF-EMISSAO-61 */

            if (WS_EF_IOF_CREDITO_61 < WS_EF_IOF_EMISSAO_61)
            {

                /*" -6589- COMPUTE WS-EF-IOF-EMISSAO-61 = WS-EF-IOF-EMISSAO-61 - WS-EF-IOF-CREDITO-61 */
                WS_EF_IOF_EMISSAO_61.Value = WS_EF_IOF_EMISSAO_61 - WS_EF_IOF_CREDITO_61;

                /*" -6591- COMPUTE WS-EF-VLR-EMISSAO-61 = WS-EF-VLR-EMISSAO-61 - WS-EF-IOF-EMISSAO-61 */
                WS_EF_VLR_EMISSAO_61.Value = WS_EF_VLR_EMISSAO_61 - WS_EF_IOF_EMISSAO_61;

                /*" -6592- MOVE ZEROS TO WS-EF-IOF-CREDITO-61 */
                _.Move(0, WS_EF_IOF_CREDITO_61);

                /*" -6594- END-IF */
            }


            /*" -6595- IF WS-EF-IOF-CREDITO-61 > WS-EF-IOF-EMISSAO-61 */

            if (WS_EF_IOF_CREDITO_61 > WS_EF_IOF_EMISSAO_61)
            {

                /*" -6597- COMPUTE WS-EF-VLR-EMISSAO-61 = WS-EF-VLR-EMISSAO-61 - WS-EF-IOF-EMISSAO-61 */
                WS_EF_VLR_EMISSAO_61.Value = WS_EF_VLR_EMISSAO_61 - WS_EF_IOF_EMISSAO_61;

                /*" -6599- COMPUTE WS-EF-VLR-CREDITO-61 = WS-EF-VLR-CREDITO-61 - WS-EF-IOF-CREDITO-61 */
                WS_EF_VLR_CREDITO_61.Value = WS_EF_VLR_CREDITO_61 - WS_EF_IOF_CREDITO_61;

                /*" -6602- END-IF */
            }


            /*" -6603- IF WS-EF-IOF-CREDITO-65 < WS-EF-IOF-EMISSAO-65 */

            if (WS_EF_IOF_CREDITO_65 < WS_EF_IOF_EMISSAO_65)
            {

                /*" -6605- COMPUTE WS-EF-IOF-EMISSAO-65 = WS-EF-IOF-EMISSAO-65 - WS-EF-IOF-CREDITO-65 */
                WS_EF_IOF_EMISSAO_65.Value = WS_EF_IOF_EMISSAO_65 - WS_EF_IOF_CREDITO_65;

                /*" -6607- COMPUTE WS-EF-VLR-EMISSAO-65 = WS-EF-VLR-EMISSAO-65 - WS-EF-IOF-EMISSAO-65 */
                WS_EF_VLR_EMISSAO_65.Value = WS_EF_VLR_EMISSAO_65 - WS_EF_IOF_EMISSAO_65;

                /*" -6608- MOVE ZEROS TO WS-EF-IOF-CREDITO-65 */
                _.Move(0, WS_EF_IOF_CREDITO_65);

                /*" -6610- END-IF */
            }


            /*" -6611- IF WS-EF-IOF-CREDITO-65 > WS-EF-IOF-EMISSAO-65 */

            if (WS_EF_IOF_CREDITO_65 > WS_EF_IOF_EMISSAO_65)
            {

                /*" -6613- COMPUTE WS-EF-VLR-EMISSAO-65 = WS-EF-VLR-EMISSAO-65 - WS-EF-IOF-EMISSAO-65 */
                WS_EF_VLR_EMISSAO_65.Value = WS_EF_VLR_EMISSAO_65 - WS_EF_IOF_EMISSAO_65;

                /*" -6615- COMPUTE WS-EF-VLR-CREDITO-65 = WS-EF-VLR-CREDITO-65 - WS-EF-IOF-CREDITO-65 */
                WS_EF_VLR_CREDITO_65.Value = WS_EF_VLR_CREDITO_65 - WS_EF_IOF_CREDITO_65;

                /*" -6617- END-IF */
            }


            /*" -6618- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -6625- COMPUTE WS-APOLICOB-PCT-COB-61 ROUNDED = ( WS-EF-VLR-EMISSAO-61 / (WS-EF-VLR-EMISSAO-61 + WS-EF-VLR-EMISSAO-65) ) * 100 ON SIZE ERROR MOVE ZEROS TO WS-APOLICOB-PCT-COB-61 END-COMPUTE */
                if (WS_EF_VLR_EMISSAO_61.Value + WS_EF_VLR_EMISSAO_65.Value == 0)
                    _.Move(0, WS_APOLICOB_PCT_COB_61);
                else

                    WS_APOLICOB_PCT_COB_61.Value = (WS_EF_VLR_EMISSAO_61 / (WS_EF_VLR_EMISSAO_61 + WS_EF_VLR_EMISSAO_65)) * 100;

                /*" -6626- ELSE */
            }
            else
            {


                /*" -6632- COMPUTE WS-APOLICOB-PCT-COB-61 ROUNDED = ( WS-EF-VLR-CREDITO-61 / (WS-EF-VLR-CREDITO-61 + WS-EF-VLR-CREDITO-65) ) * 100 ON SIZE ERROR MOVE ZEROS TO WS-APOLICOB-PCT-COB-61 END-COMPUTE */
                if (WS_EF_VLR_CREDITO_61.Value + WS_EF_VLR_CREDITO_65.Value == 0)
                    _.Move(0, WS_APOLICOB_PCT_COB_61);
                else

                    WS_APOLICOB_PCT_COB_61.Value = (WS_EF_VLR_CREDITO_61 / (WS_EF_VLR_CREDITO_61 + WS_EF_VLR_CREDITO_65)) * 100;

                /*" -6634- END-IF */
            }


            /*" -6640- PERFORM B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1 */

            B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1();

            /*" -6646- COMPUTE WS-APOLICOB-PCT-COB-65 = 100,00 - WS-APOLICOB-PCT-COB-61 */
            WS_APOLICOB_PCT_COB_65.Value = 100.00 - WS_APOLICOB_PCT_COB_61;

            /*" -6647- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -6655- PERFORM B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2 */

                B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2();

                /*" -6657- ELSE */
            }
            else
            {


                /*" -6665- PERFORM B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3 */

                B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3();

                /*" -6668- END-IF */
            }


            /*" -6669- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6672- DISPLAY ' R2095-ERRO UPDATE V1COBERAPOL -P/EF ' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $" R2095-ERRO UPDATE V1COBERAPOL -P/EF  {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -6673- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6674- END-IF */
            }


            /*" -6674- . */

        }

        [StopWatch]
        /*" B2095-ALTERA-V0COBERAPOL-EF-DB-UPDATE-1 */
        public void B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1()
        {
            /*" -6640- EXEC SQL UPDATE SEGUROS.V1COBERAPOL SET PCT_COBERTURA = :WS-APOLICOB-PCT-COB-61 WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS AND RAMOFR = 61 END-EXEC */

            var b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1 = new B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1()
            {
                WS_APOLICOB_PCT_COB_61 = WS_APOLICOB_PCT_COB_61.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1.Execute(b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2095_999_EXIT*/

        [StopWatch]
        /*" B2095-ALTERA-V0COBERAPOL-EF-DB-UPDATE-2 */
        public void B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2()
        {
            /*" -6655- EXEC SQL UPDATE SEGUROS.V1COBERAPOL A SET A.PCT_COBERTURA = :WS-APOLICOB-PCT-COB-65 , A.PRM_TARIFARIO_IX = :WS-EF-VLR-EMISSAO-65 , A.PRM_TARIFARIO_VAR = :WS-EF-VLR-EMISSAO-65 WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NRENDOS = :ENDO-NRENDOS AND A.RAMOFR = 65 END-EXEC */

            var b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1 = new B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1()
            {
                WS_APOLICOB_PCT_COB_65 = WS_APOLICOB_PCT_COB_65.ToString(),
                WS_EF_VLR_EMISSAO_65 = WS_EF_VLR_EMISSAO_65.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1.Execute(b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" B2096-ALTERA-V0COBERAPOL-EF-SECTION */
        private void B2096_ALTERA_V0COBERAPOL_EF_SECTION()
        {
            /*" -6690- MOVE 'B2096' TO WNR-EXEC-SQL. */
            _.Move("B2096", WABEND.WNR_EXEC_SQL);

            /*" -6691- IF WS-EF-IOF-CREDITO-14 < WS-EF-IOF-EMISSAO-14 */

            if (WS_EF_IOF_CREDITO_14 < WS_EF_IOF_EMISSAO_14)
            {

                /*" -6693- COMPUTE WS-EF-IOF-EMISSAO-14 = WS-EF-IOF-EMISSAO-14 - WS-EF-IOF-CREDITO-14 */
                WS_EF_IOF_EMISSAO_14.Value = WS_EF_IOF_EMISSAO_14 - WS_EF_IOF_CREDITO_14;

                /*" -6695- COMPUTE WS-EF-VLR-EMISSAO-14 = WS-EF-VLR-EMISSAO-14 - WS-EF-IOF-EMISSAO-14 */
                WS_EF_VLR_EMISSAO_14.Value = WS_EF_VLR_EMISSAO_14 - WS_EF_IOF_EMISSAO_14;

                /*" -6696- MOVE ZEROS TO WS-EF-IOF-CREDITO-14 */
                _.Move(0, WS_EF_IOF_CREDITO_14);

                /*" -6698- END-IF */
            }


            /*" -6699- IF WS-EF-IOF-CREDITO-14 > WS-EF-IOF-EMISSAO-14 */

            if (WS_EF_IOF_CREDITO_14 > WS_EF_IOF_EMISSAO_14)
            {

                /*" -6701- COMPUTE WS-EF-VLR-EMISSAO-14 = WS-EF-VLR-EMISSAO-14 - WS-EF-IOF-EMISSAO-14 */
                WS_EF_VLR_EMISSAO_14.Value = WS_EF_VLR_EMISSAO_14 - WS_EF_IOF_EMISSAO_14;

                /*" -6703- COMPUTE WS-EF-VLR-CREDITO-14 = WS-EF-VLR-CREDITO-14 - WS-EF-IOF-CREDITO-14 */
                WS_EF_VLR_CREDITO_14.Value = WS_EF_VLR_CREDITO_14 - WS_EF_IOF_CREDITO_14;

                /*" -6705- END-IF */
            }


            /*" -6706- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -6712- COMPUTE WS-APOLICOB-PCT-COB-14 ROUNDED = ( WS-EF-VLR-EMISSAO-14 / (WS-EF-VLR-EMISSAO-14 ) ) * 100 ON SIZE ERROR MOVE ZEROS TO WS-APOLICOB-PCT-COB-14 END-COMPUTE */
                if (WS_EF_VLR_EMISSAO_14.Value == 0)
                    _.Move(0, WS_APOLICOB_PCT_COB_14);
                else

                    WS_APOLICOB_PCT_COB_14.Value = (WS_EF_VLR_EMISSAO_14 / (WS_EF_VLR_EMISSAO_14)) * 100;

                /*" -6719- PERFORM B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1 */

                B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1();

                /*" -6722- ELSE */
            }
            else
            {


                /*" -6728- COMPUTE WS-APOLICOB-PCT-COB-14 ROUNDED = ( WS-EF-VLR-CREDITO-14 / (WS-EF-VLR-CREDITO-14) ) * 100 ON SIZE ERROR MOVE ZEROS TO WS-APOLICOB-PCT-COB-14 END-COMPUTE */
                if (WS_EF_VLR_CREDITO_14.Value == 0)
                    _.Move(0, WS_APOLICOB_PCT_COB_14);
                else

                    WS_APOLICOB_PCT_COB_14.Value = (WS_EF_VLR_CREDITO_14 / (WS_EF_VLR_CREDITO_14)) * 100;

                /*" -6735- PERFORM B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2 */

                B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2();

                /*" -6738- END-IF */
            }


            /*" -6739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6742- DISPLAY ' R2096-ERRO UPDATE V1COBERAPOL -P/EF ' ' ' ENDO-NUM-APOLICE ' ' ENDO-NRENDOS */

                $" R2096-ERRO UPDATE V1COBERAPOL -P/EF  {ENDO_NUM_APOLICE} {ENDO_NRENDOS}"
                .Display();

                /*" -6743- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6744- END-IF */
            }


            /*" -6744- . */

        }

        [StopWatch]
        /*" B2096-ALTERA-V0COBERAPOL-EF-DB-UPDATE-1 */
        public void B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1()
        {
            /*" -6719- EXEC SQL UPDATE SEGUROS.V1COBERAPOL SET PCT_COBERTURA = :WS-APOLICOB-PCT-COB-14 ,PRM_TARIFARIO_IX = :WS-EF-VLR-EMISSAO-14 ,PRM_TARIFARIO_VAR = :WS-EF-VLR-EMISSAO-14 WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC */

            var b2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1 = new B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1()
            {
                WS_APOLICOB_PCT_COB_14 = WS_APOLICOB_PCT_COB_14.ToString(),
                WS_EF_VLR_EMISSAO_14 = WS_EF_VLR_EMISSAO_14.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1.Execute(b2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" B2095-ALTERA-V0COBERAPOL-EF-DB-UPDATE-3 */
        public void B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3()
        {
            /*" -6665- EXEC SQL UPDATE SEGUROS.V1COBERAPOL A SET A.PCT_COBERTURA = :WS-APOLICOB-PCT-COB-65 , A.PRM_TARIFARIO_IX = :WS-EF-VLR-CREDITO-65 , A.PRM_TARIFARIO_VAR = :WS-EF-VLR-CREDITO-65 WHERE A.NUM_APOLICE = :ENDO-NUM-APOLICE AND A.NRENDOS = :ENDO-NRENDOS AND A.RAMOFR = 65 END-EXEC */

            var b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1 = new B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1()
            {
                WS_APOLICOB_PCT_COB_65 = WS_APOLICOB_PCT_COB_65.ToString(),
                WS_EF_VLR_CREDITO_65 = WS_EF_VLR_CREDITO_65.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1.Execute(b2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" B2096-ALTERA-V0COBERAPOL-EF-DB-UPDATE-2 */
        public void B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2()
        {
            /*" -6735- EXEC SQL UPDATE SEGUROS.V1COBERAPOL SET PCT_COBERTURA = :WS-APOLICOB-PCT-COB-14 ,PRM_TARIFARIO_IX = :WS-EF-VLR-CREDITO-14 ,PRM_TARIFARIO_VAR = :WS-EF-VLR-CREDITO-14 WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC */

            var b2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1 = new B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1()
            {
                WS_APOLICOB_PCT_COB_14 = WS_APOLICOB_PCT_COB_14.ToString(),
                WS_EF_VLR_CREDITO_14 = WS_EF_VLR_CREDITO_14.ToString(),
                ENDO_NUM_APOLICE = ENDO_NUM_APOLICE.ToString(),
                ENDO_NRENDOS = ENDO_NRENDOS.ToString(),
            };

            B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1.Execute(b2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2096_999_EXIT*/

        [StopWatch]
        /*" B2100-MONTA-201-SECTION */
        private void B2100_MONTA_201_SECTION()
        {
            /*" -6753- MOVE 0201 TO HIST-OPERACAO. */
            _.Move(0201, HIST_OPERACAO);

            /*" -6754- MOVE PCOM-NRAVISO TO HIST-NRAVISO. */
            _.Move(PCOM_NRAVISO, HIST_NRAVISO);

            /*" -6755- MOVE PCOM-AGEAVISO TO HIST-AGECOBR. */
            _.Move(PCOM_AGEAVISO, HIST_AGECOBR);

            /*" -6756- MOVE 2 TO HIST-OCORHIST. */
            _.Move(2, HIST_OCORHIST);

            /*" -6757- MOVE ENDO-DATARCAP TO HIST-DTQITBCO. */
            _.Move(ENDO_DATARCAP, HIST_DTQITBCO);

            /*" -6758- MOVE 'MOV2-DTQITBCO                ' TO WS-MOV-DTQITBCO */
            _.Move("MOV2-DTQITBCO                ", WS_MOV_DTQITBCO);

            /*" -6759- MOVE ENDO-VLRCAP TO HIST-VLPREMIO. */
            _.Move(ENDO_VLRCAP, HIST_VLPREMIO);

            /*" -6759- MOVE 0 TO HIST-DTQITBCO-I. */
            _.Move(0, HIST_DTQITBCO_I);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2100_999_EXIT*/

        [StopWatch]
        /*" B2110-MONTA-208-SECTION */
        private void B2110_MONTA_208_SECTION()
        {
            /*" -6769- MOVE 0208 TO HIST-OPERACAO. */
            _.Move(0208, HIST_OPERACAO);

            /*" -6770- MOVE ZEROS TO HIST-NRAVISO. */
            _.Move(0, HIST_NRAVISO);

            /*" -6771- MOVE ZEROS TO HIST-AGECOBR. */
            _.Move(0, HIST_AGECOBR);

            /*" -6772- MOVE 2 TO HIST-OCORHIST. */
            _.Move(2, HIST_OCORHIST);

            /*" -6773- MOVE ENDO-DTINIVIG TO HIST-DTQITBCO. */
            _.Move(ENDO_DTINIVIG, HIST_DTQITBCO);

            /*" -6774- MOVE 'MOV1-DTQITBCO' TO WS-MOV-DTQITBCO */
            _.Move("MOV1-DTQITBCO", WS_MOV_DTQITBCO);

            /*" -6775- MOVE ENDO-VLRCAP TO HIST-VLPREMIO. */
            _.Move(ENDO_VLRCAP, HIST_VLPREMIO);

            /*" -6775- MOVE 0 TO HIST-DTQITBCO-I. */
            _.Move(0, HIST_DTQITBCO_I);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2110_999_EXIT*/

        [StopWatch]
        /*" B2200-000-BAIXA-RCAP-SECTION */
        private void B2200_000_BAIXA_RCAP_SECTION()
        {
            /*" -6786- MOVE 'B2200' TO WNR-EXEC-SQL. */
            _.Move("B2200", WABEND.WNR_EXEC_SQL);

            /*" -6787- MOVE PCOM-FONTE TO V0RCAP-FONTE */
            _.Move(PCOM_FONTE, V0RCAP_FONTE);

            /*" -6787- MOVE PCOM-NRRCAP TO V0RCAP-NRRCAP. */
            _.Move(PCOM_NRRCAP, V0RCAP_NRRCAP);

            /*" -0- FLUXCONTROL_PERFORM B2200_010_ALTERA_V0RCAP */

            B2200_010_ALTERA_V0RCAP();

        }

        [StopWatch]
        /*" B2200-010-ALTERA-V0RCAP */
        private void B2200_010_ALTERA_V0RCAP(bool isPerform = false)
        {
            /*" -6839- MOVE 'B2210' TO WNR-EXEC-SQL. */
            _.Move("B2210", WABEND.WNR_EXEC_SQL);

            /*" -6849- PERFORM B2200_010_ALTERA_V0RCAP_DB_UPDATE_1 */

            B2200_010_ALTERA_V0RCAP_DB_UPDATE_1();

            /*" -6852- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6855- DISPLAY 'B2210 - PROBLEMAS UPDATE V0RCAP ' ' ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                $"B2210 - PROBLEMAS UPDATE V0RCAP  {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                .Display();

                /*" -6857- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6858- . */

            /*" -6858- PERFORM B2200-020-DECLARE-V0RCAPCOMP. */

            B2200_020_DECLARE_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" B2200-010-ALTERA-V0RCAP-DB-UPDATE-1 */
        public void B2200_010_ALTERA_V0RCAP_DB_UPDATE_1()
        {
            /*" -6849- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' ,OPERACAO = 220 ,NUM_APOLICE = :HIST-NUM-APOLICE ,NRENDOS = :HIST-NRENDOS ,NRPARCEL = :HIST-NRPARCEL ,TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

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
            /*" -6863- MOVE 'B2220' TO WNR-EXEC-SQL. */
            _.Move("B2220", WABEND.WNR_EXEC_SQL);

            /*" -6874- PERFORM B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -6876- PERFORM B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -6879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6882- DISPLAY 'B2220 - PROBLEMAS DECLARE V0RCAPCOMP ' ' ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                $"B2220 - PROBLEMAS DECLARE V0RCAPCOMP  {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                .Display();

                /*" -6882- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2200-020-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -6876- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" B2200-030-FETCH-V0RCAPCOMP */
        private void B2200_030_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -6888- MOVE 'B2230' TO WNR-EXEC-SQL. */
            _.Move("B2230", WABEND.WNR_EXEC_SQL);

            /*" -6894- PERFORM B2200_030_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            B2200_030_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -6897- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -6897- PERFORM B2200_030_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                B2200_030_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                /*" -6900- GO TO B2200-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B2200_999_EXIT*/ //GOTO
                return;
            }


            /*" -6901- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6904- DISPLAY 'B2230 - PROBLEMAS FETCH V0RCAPCOMP ' ' ' V0RCAP-FONTE ' ' V0RCAP-NRRCAP */

                $"B2230 - PROBLEMAS FETCH V0RCAPCOMP  {V0RCAP_FONTE} {V0RCAP_NRRCAP}"
                .Display();

                /*" -6906- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6910- IF PCOM-OPERACAO EQUAL 200 OR 210 OR 220 OR 400 */

            if (PCOM_OPERACAO.In("200", "210", "220", "400"))
            {

                /*" -6912- GO TO B2200-030-FETCH-V0RCAPCOMP. */
                new Task(() => B2200_030_FETCH_V0RCAPCOMP()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -6912- PERFORM B2200-040-ALTERA-V0RCAPCOMP. */

            B2200_040_ALTERA_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" B2200-030-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void B2200_030_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -6894- EXEC SQL FETCH V1RCAPCOMP INTO :PCOM-FONTE, :PCOM-NRRCAP, :PCOM-NRRCAPCO, :PCOM-OPERACAO, :PCOM-DTMOVTO, :PCOM-HORAOPER, :PCOM-SITUACAO, :PCOM-BCOAVISO, :PCOM-AGEAVISO, :PCOM-NRAVISO, :PCOM-VLRCAP, :PCOM-DATARCAP, :PCOM-DTCADAST, :PCOM-SITCONTB END-EXEC. */

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
            /*" -6897- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" B2200-040-ALTERA-V0RCAPCOMP */
        private void B2200_040_ALTERA_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -6917- MOVE 'B2240' TO WNR-EXEC-SQL. */
            _.Move("B2240", WABEND.WNR_EXEC_SQL);

            /*" -6927- PERFORM B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1 */

            B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1();

            /*" -6930- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6933- DISPLAY 'B2240 - PROBLEMAS UPDATE V0RCAPCOMP ' ' ' PCOM-FONTE ' ' PCOM-NRRCAP */

                $"B2240 - PROBLEMAS UPDATE V0RCAPCOMP  {PCOM_FONTE} {PCOM_NRRCAP}"
                .Display();

                /*" -6935- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -6935- PERFORM B2200-050-INCLUI-V0RCAPCOMP. */

            B2200_050_INCLUI_V0RCAPCOMP(true);

        }

        [StopWatch]
        /*" B2200-040-ALTERA-V0RCAPCOMP-DB-UPDATE-1 */
        public void B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -6927- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :PCOM-FONTE AND NRRCAP = :PCOM-NRRCAP AND NRRCAPCO = :PCOM-NRRCAPCO AND OPERACAO = :PCOM-OPERACAO AND DTMOVTO = :PCOM-DTMOVTO AND HORAOPER = :PCOM-HORAOPER END-EXEC. */

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
            /*" -6940- MOVE 'B2250' TO WNR-EXEC-SQL. */
            _.Move("B2250", WABEND.WNR_EXEC_SQL);

            /*" -6941- MOVE '0' TO PCOM-SITCONTB. */
            _.Move("0", PCOM_SITCONTB);

            /*" -6942- MOVE '0' TO PCOM-SITUACAO. */
            _.Move("0", PCOM_SITUACAO);

            /*" -6948- MOVE 220 TO PCOM-OPERACAO. */
            _.Move(220, PCOM_OPERACAO);

            /*" -6949- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -6950- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_TIME.WS_HH_TIME, FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -6951- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -6952- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_TIME.WS_MM_TIME, FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -6953- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -6954- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_TIME.WS_SS_TIME, FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -6956- MOVE WTIME-DAYR TO PCOM-HORAOPER. */
            _.Move(FILLER_4.WTIME_DAYR, PCOM_HORAOPER);

            /*" -6989- PERFORM B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1 */

            B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1();

            /*" -6992- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -6993- DISPLAY 'B2250 - PROBLEMAS INSERT V0RCAPCOMP ----------' */
                _.Display($"B2250 - PROBLEMAS INSERT V0RCAPCOMP ----------");

                /*" -6994- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -6995- DISPLAY 'SQLCODE ' WSQLCODE */
                _.Display($"SQLCODE {WABEND.WSQLCODE}");

                /*" -6996- DISPLAY 'PCOM-AGEAVISO = ' PCOM-AGEAVISO */
                _.Display($"PCOM-AGEAVISO = {PCOM_AGEAVISO}");

                /*" -6997- DISPLAY 'PCOM-BCOAVISO = ' PCOM-BCOAVISO */
                _.Display($"PCOM-BCOAVISO = {PCOM_BCOAVISO}");

                /*" -6998- DISPLAY 'PCOM-DATARCAP = ' PCOM-DATARCAP */
                _.Display($"PCOM-DATARCAP = {PCOM_DATARCAP}");

                /*" -6999- DISPLAY 'PCOM-DTCADAST = ' PCOM-DTCADAST */
                _.Display($"PCOM-DTCADAST = {PCOM_DTCADAST}");

                /*" -7000- DISPLAY 'SIST-DTMOVABE = ' SIST-DTMOVABE */
                _.Display($"SIST-DTMOVABE = {SIST_DTMOVABE}");

                /*" -7001- DISPLAY 'PCOM-FONTE    = ' PCOM-FONTE */
                _.Display($"PCOM-FONTE    = {PCOM_FONTE}");

                /*" -7002- DISPLAY 'PCOM-HORAOPER = ' PCOM-HORAOPER */
                _.Display($"PCOM-HORAOPER = {PCOM_HORAOPER}");

                /*" -7003- DISPLAY 'PCOM-NRAVISO  = ' PCOM-NRAVISO */
                _.Display($"PCOM-NRAVISO  = {PCOM_NRAVISO}");

                /*" -7004- DISPLAY 'PCOM-NRRCAP   = ' PCOM-NRRCAP */
                _.Display($"PCOM-NRRCAP   = {PCOM_NRRCAP}");

                /*" -7005- DISPLAY 'PCOM-NRRCAPCO = ' PCOM-NRRCAPCO */
                _.Display($"PCOM-NRRCAPCO = {PCOM_NRRCAPCO}");

                /*" -7006- DISPLAY 'PCOM-OPERACAO = ' PCOM-OPERACAO */
                _.Display($"PCOM-OPERACAO = {PCOM_OPERACAO}");

                /*" -7007- DISPLAY 'PCOM-SITCONTB = ' PCOM-SITCONTB */
                _.Display($"PCOM-SITCONTB = {PCOM_SITCONTB}");

                /*" -7008- DISPLAY 'PCOM-SITUACAO = ' PCOM-SITUACAO */
                _.Display($"PCOM-SITUACAO = {PCOM_SITUACAO}");

                /*" -7009- DISPLAY 'PCOM-VLRCAP   = ' PCOM-VLRCAP */
                _.Display($"PCOM-VLRCAP   = {PCOM_VLRCAP}");

                /*" -7010- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -7012- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7015- ADD 1 TO AC-I-V0RCAPCOMP. */
            AC_I_V0RCAPCOMP.Value = AC_I_V0RCAPCOMP + 1;

            /*" -7016- MOVE PCOM-BCOAVISO TO V1ASAL-BCOAVISO */
            _.Move(PCOM_BCOAVISO, V1ASAL_BCOAVISO);

            /*" -7017- MOVE PCOM-AGEAVISO TO V1ASAL-AGEAVISO */
            _.Move(PCOM_AGEAVISO, V1ASAL_AGEAVISO);

            /*" -7018- MOVE PCOM-NRAVISO TO V1ASAL-NRAVISO */
            _.Move(PCOM_NRAVISO, V1ASAL_NRAVISO);

            /*" -7019- MOVE SPACES TO WFIM-V1AVISALDOS */
            _.Move("", WFIM_V1AVISALDOS);

            /*" -7020- PERFORM B3200-SELECT-V1AVISALDOS */

            B3200_SELECT_V1AVISALDOS_SECTION();

            /*" -7021- IF WFIM-V1AVISALDOS EQUAL SPACES */

            if (WFIM_V1AVISALDOS.IsEmpty())
            {

                /*" -7023- PERFORM B3300-ALTERA-V0AVISALDOS. */

                B3300_ALTERA_V0AVISALDOS_SECTION();
            }


            /*" -7023- GO TO B2200-030-FETCH-V0RCAPCOMP. */

            B2200_030_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" B2200-050-INCLUI-V0RCAPCOMP-DB-INSERT-1 */
        public void B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -6989- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP (AGEAVISO, BCOAVISO, DATARCAP, DTCADAST, DTMOVTO, FONTE, HORAOPER, NRAVISO, NRRCAP, NRRCAPCO, OPERACAO, SITCONTB, SITUACAO, VLRCAP, TIMESTAMP) VALUES (:PCOM-AGEAVISO, :PCOM-BCOAVISO, :PCOM-DATARCAP, :PCOM-DTCADAST, :SIST-DTMOVABE, :PCOM-FONTE, :PCOM-HORAOPER, :PCOM-NRAVISO, :PCOM-NRRCAP, :PCOM-NRRCAPCO, :PCOM-OPERACAO, :PCOM-SITCONTB, :PCOM-SITUACAO, :PCOM-VLRCAP, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -7034- MOVE VL-TARIFA TO VL-TARIFAW. */
            _.Move(EM0901W099.VL_TARIFA, FILLER_30.VL_TARIFAW);

            /*" -7035- MOVE VL-DESCONTO TO VL-DESCW. */
            _.Move(EM0901W099.VL_DESCONTO, FILLER_30.VL_DESCW);

            /*" -7036- MOVE VL-LIQUIDO TO VL-LIQW. */
            _.Move(EM0901W099.VL_LIQUIDO, FILLER_30.VL_LIQW);

            /*" -7037- MOVE VL-ADICIONAL TO VL-ADICW. */
            _.Move(EM0901W099.VL_ADICIONAL, FILLER_30.VL_ADICW);

            /*" -7038- MOVE VL-CUSTO TO VL-CUSTOW. */
            _.Move(EM0901W099.VL_CUSTO, FILLER_30.VL_CUSTOW);

            /*" -7039- MOVE VL-IOF TO VL-IOCCW. */
            _.Move(EM0901W099.VL_IOF, FILLER_30.VL_IOCCW);

            /*" -7040- MOVE VL-TOTAL TO VL-TOTALW. */
            _.Move(EM0901W099.VL_TOTAL, FILLER_30.VL_TOTALW);

            /*" -7041- MOVE VL-TARIFARIO-IX TO VL-TARIFAW-IX. */
            _.Move(EM0901W099.VL_TARIFARIO_IX, FILLER_30.VL_TARIFAW_IX);

            /*" -7042- MOVE VL-DESC-IX TO VL-DESCW-IX. */
            _.Move(EM0901W099.VL_DESC_IX, FILLER_30.VL_DESCW_IX);

            /*" -7043- MOVE VL-LIQ-IX TO VL-LIQW-IX. */
            _.Move(EM0901W099.VL_LIQ_IX, FILLER_30.VL_LIQW_IX);

            /*" -7044- MOVE VL-ADIC-IX TO VL-ADICW-IX. */
            _.Move(EM0901W099.VL_ADIC_IX, FILLER_30.VL_ADICW_IX);

            /*" -7045- MOVE VL-CUSTO-IX TO VL-CUSTOW-IX. */
            _.Move(EM0901W099.VL_CUSTO_IX, FILLER_30.VL_CUSTOW_IX);

            /*" -7046- MOVE VL-IOF-IX TO VL-IOCCW-IX. */
            _.Move(EM0901W099.VL_IOF_IX, FILLER_30.VL_IOCCW_IX);

            /*" -7048- MOVE VL-TOTAL-IX TO VL-TOTALW-IX. */
            _.Move(EM0901W099.VL_TOTAL_IX, FILLER_30.VL_TOTALW_IX);

            /*" -7050- MOVE ENDO-VLRCAP TO VL-TOTAL. */
            _.Move(ENDO_VLRCAP, EM0901W099.VL_TOTAL);

            /*" -7053- COMPUTE PCIOF ROUNDED = 1 + (PCIOF / 100). */
            EM0901W099.PCIOF.Value = 1 + (EM0901W099.PCIOF / 100f);

            /*" -7056- COMPUTE VL-IOF ROUNDED = VL-TOTAL / PCIOF. */
            EM0901W099.VL_IOF.Value = EM0901W099.VL_TOTAL / EM0901W099.PCIOF;

            /*" -7059- COMPUTE VL-IOF = VL-TOTAL - VL-IOF. */
            EM0901W099.VL_IOF.Value = EM0901W099.VL_TOTAL - EM0901W099.VL_IOF;

            /*" -7064- COMPUTE VL-LIQUIDO = VL-TOTAL - VL-IOF - VL-CUSTO - VL-ADICIONAL. */
            EM0901W099.VL_LIQUIDO.Value = EM0901W099.VL_TOTAL - EM0901W099.VL_IOF - EM0901W099.VL_CUSTO - EM0901W099.VL_ADICIONAL;

            /*" -7072- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802 OR ENDO-CODPRODU EQUAL 1804) AND ENDO-COD-EMPRESA EQUAL 0)) NEXT SENTENCE */

            if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802 || ENDO_CODPRODU == 1804) && ENDO_COD_EMPRESA == 0)))
            {

                /*" -7073- ELSE */
            }
            else
            {


                /*" -7077- COMPUTE VL-TARIFA ROUNDED = VL-LIQUIDO / ( 1 - ( PCDESCON / 100 ) ). */
                EM0901W099.VL_TARIFA.Value = EM0901W099.VL_LIQUIDO / (1 - (EM0901W099.PCDESCON / 100f));
            }


            /*" -7080- COMPUTE VL-DESCONTO = VL-TARIFA - VL-LIQUIDO. */
            EM0901W099.VL_DESCONTO.Value = EM0901W099.VL_TARIFA - EM0901W099.VL_LIQUIDO;

            /*" -7082- MOVE ENDO-DTINIVIG TO WHOST-DTINIVIG */
            _.Move(ENDO_DTINIVIG, WHOST_DTINIVIG);

            /*" -7084- PERFORM B2500-LE-MOEDA. */

            B2500_LE_MOEDA_SECTION();

            /*" -7088- COMPUTE VL-TARIFARIO-IX ROUNDED = VL-TARIFA / MOED-VALOR. */
            EM0901W099.VL_TARIFARIO_IX.Value = EM0901W099.VL_TARIFA / MOED_VALOR;

            /*" -7092- COMPUTE VL-LIQ-IX ROUNDED = VL-LIQUIDO / MOED-VALOR. */
            EM0901W099.VL_LIQ_IX.Value = EM0901W099.VL_LIQUIDO / MOED_VALOR;

            /*" -7095- COMPUTE VL-DESC-IX = VL-TARIFARIO-IX - VL-LIQ-IX. */
            EM0901W099.VL_DESC_IX.Value = EM0901W099.VL_TARIFARIO_IX - EM0901W099.VL_LIQ_IX;

            /*" -7098- COMPUTE VL-IOF-IX ROUNDED = VL-IOF / MOED-VALOR. */
            EM0901W099.VL_IOF_IX.Value = EM0901W099.VL_IOF / MOED_VALOR;

            /*" -7103- COMPUTE VL-TOTAL-IX = VL-LIQ-IX + VL-ADIC-IX + VL-CUSTO-IX + VL-IOF-IX. */
            EM0901W099.VL_TOTAL_IX.Value = EM0901W099.VL_LIQ_IX + EM0901W099.VL_ADIC_IX + EM0901W099.VL_CUSTO_IX + EM0901W099.VL_IOF_IX;

            /*" -7104- IF ENDO-PCADICIO EQUAL ZEROS */

            if (ENDO_PCADICIO == 00)
            {

                /*" -7112- IF (((ENDO-CODPRODU EQUAL 1601 OR ENDO-CODPRODU EQUAL 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR ENDO-CODPRODU EQUAL 1802 OR ENDO-CODPRODU EQUAL 1804) AND ENDO-COD-EMPRESA EQUAL 0)) NEXT SENTENCE */

                if ((((ENDO_CODPRODU == 1601 || ENDO_CODPRODU == 1801) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU == 1602 || ENDO_CODPRODU == 1802 || ENDO_CODPRODU == 1804) && ENDO_COD_EMPRESA == 0)))
                {

                    /*" -7113- ELSE */
                }
                else
                {


                    /*" -7117- COMPUTE VL-PREMIO-BASE = VL-PREMIO-BASE - VL-TARIFAW-IX. */
                    EM0901W099.VL_PREMIO_BASE.Value = EM0901W099.VL_PREMIO_BASE - FILLER_30.VL_TARIFAW_IX;
                }

            }


            /*" -7120- COMPUTE VL-DIFTAR-IX = VL-TARIFARIO-IX - VL-TARIFAW-IX. */
            FILLER_30.VL_DIFTAR_IX.Value = EM0901W099.VL_TARIFARIO_IX - FILLER_30.VL_TARIFAW_IX;

            /*" -7123- COMPUTE VL-DIFDESC-IX = VL-DESC-IX - VL-DESCW-IX. */
            FILLER_30.VL_DIFDESC_IX.Value = EM0901W099.VL_DESC_IX - FILLER_30.VL_DESCW_IX;

            /*" -7126- COMPUTE VL-DIFLIQ-IX = VL-LIQ-IX - VL-LIQW-IX. */
            FILLER_30.VL_DIFLIQ_IX.Value = EM0901W099.VL_LIQ_IX - FILLER_30.VL_LIQW_IX;

            /*" -7129- COMPUTE VL-DIFADI-IX = VL-ADIC-IX - VL-ADICW-IX. */
            FILLER_30.VL_DIFADI_IX.Value = EM0901W099.VL_ADIC_IX - FILLER_30.VL_ADICW_IX;

            /*" -7132- COMPUTE VL-DIFCUS-IX = VL-CUSTO-IX - VL-CUSTOW-IX. */
            FILLER_30.VL_DIFCUS_IX.Value = EM0901W099.VL_CUSTO_IX - FILLER_30.VL_CUSTOW_IX;

            /*" -7135- COMPUTE VL-DIFIOC-IX = VL-IOF-IX - VL-IOCCW-IX. */
            FILLER_30.VL_DIFIOC_IX.Value = EM0901W099.VL_IOF_IX - FILLER_30.VL_IOCCW_IX;

            /*" -7138- COMPUTE VL-DIFTOT-IX = VL-TOTAL-IX - VL-TOTALW-IX. */
            FILLER_30.VL_DIFTOT_IX.Value = EM0901W099.VL_TOTAL_IX - FILLER_30.VL_TOTALW_IX;

            /*" -7141- COMPUTE VL-DIFTAR = VL-TARIFA - VL-TARIFAW. */
            FILLER_30.VL_DIFTAR.Value = EM0901W099.VL_TARIFA - FILLER_30.VL_TARIFAW;

            /*" -7144- COMPUTE VL-DIFDESC = VL-DESCONTO - VL-DESCW. */
            FILLER_30.VL_DIFDESC.Value = EM0901W099.VL_DESCONTO - FILLER_30.VL_DESCW;

            /*" -7147- COMPUTE VL-DIFLIQ = VL-LIQUIDO - VL-LIQW. */
            FILLER_30.VL_DIFLIQ.Value = EM0901W099.VL_LIQUIDO - FILLER_30.VL_LIQW;

            /*" -7150- COMPUTE VL-DIFADI = VL-ADICIONAL - VL-ADICW. */
            FILLER_30.VL_DIFADI.Value = EM0901W099.VL_ADICIONAL - FILLER_30.VL_ADICW;

            /*" -7153- COMPUTE VL-DIFCUS = VL-CUSTO - VL-CUSTOW. */
            FILLER_30.VL_DIFCUS.Value = EM0901W099.VL_CUSTO - FILLER_30.VL_CUSTOW;

            /*" -7156- COMPUTE VL-DIFIOC = VL-IOF - VL-IOCCW. */
            FILLER_30.VL_DIFIOC.Value = EM0901W099.VL_IOF - FILLER_30.VL_IOCCW;

            /*" -7161- COMPUTE VL-DIFTOT = VL-TOTAL - VL-TOTALW. */
            FILLER_30.VL_DIFTOT.Value = EM0901W099.VL_TOTAL - FILLER_30.VL_TOTALW;

            /*" -7164- COMPUTE VL-DIFTAR-IX = VL-DIFTAR-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFTAR_IX.Value = FILLER_30.VL_DIFTAR_IX / (ENDO_QTPARCEL - 1);

            /*" -7167- COMPUTE VL-DIFDESC-IX = VL-DIFDESC-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFDESC_IX.Value = FILLER_30.VL_DIFDESC_IX / (ENDO_QTPARCEL - 1);

            /*" -7170- COMPUTE VL-DIFLIQ-IX = VL-DIFLIQ-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFLIQ_IX.Value = FILLER_30.VL_DIFLIQ_IX / (ENDO_QTPARCEL - 1);

            /*" -7173- COMPUTE VL-DIFADI-IX = VL-DIFADI-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFADI_IX.Value = FILLER_30.VL_DIFADI_IX / (ENDO_QTPARCEL - 1);

            /*" -7176- COMPUTE VL-DIFCUS-IX = VL-DIFCUS-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFCUS_IX.Value = FILLER_30.VL_DIFCUS_IX / (ENDO_QTPARCEL - 1);

            /*" -7179- COMPUTE VL-DIFIOC-IX = VL-DIFIOC-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFIOC_IX.Value = FILLER_30.VL_DIFIOC_IX / (ENDO_QTPARCEL - 1);

            /*" -7182- COMPUTE VL-DIFTOT-IX = VL-DIFTOT-IX / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFTOT_IX.Value = FILLER_30.VL_DIFTOT_IX / (ENDO_QTPARCEL - 1);

            /*" -7185- COMPUTE VL-DIFTAR = VL-DIFTAR / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFTAR.Value = FILLER_30.VL_DIFTAR / (ENDO_QTPARCEL - 1);

            /*" -7188- COMPUTE VL-DIFDESC = VL-DIFDESC / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFDESC.Value = FILLER_30.VL_DIFDESC / (ENDO_QTPARCEL - 1);

            /*" -7191- COMPUTE VL-DIFLIQ = VL-DIFLIQ / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFLIQ.Value = FILLER_30.VL_DIFLIQ / (ENDO_QTPARCEL - 1);

            /*" -7194- COMPUTE VL-DIFADI = VL-DIFADI / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFADI.Value = FILLER_30.VL_DIFADI / (ENDO_QTPARCEL - 1);

            /*" -7197- COMPUTE VL-DIFCUS = VL-DIFCUS / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFCUS.Value = FILLER_30.VL_DIFCUS / (ENDO_QTPARCEL - 1);

            /*" -7200- COMPUTE VL-DIFIOC = VL-DIFIOC / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFIOC.Value = FILLER_30.VL_DIFIOC / (ENDO_QTPARCEL - 1);

            /*" -7203- COMPUTE VL-DIFTOT = VL-DIFTOT / ( ENDO-QTPARCEL - 1 ). */
            FILLER_30.VL_DIFTOT.Value = FILLER_30.VL_DIFTOT / (ENDO_QTPARCEL - 1);

            /*" -7204- IF (ENDO-CODPRODU = 1803 OR 1805) */

            if ((ENDO_CODPRODU.In("1803", "1805")))
            {

                /*" -7205- MOVE VL-DIFIOC-IX TO WS-VALOR-AUX2 */
                _.Move(FILLER_30.VL_DIFIOC_IX, WS_VALOR_AUX2);

                /*" -7206- MOVE WS-VALOR-AUX2 TO VL-DIFIOC-IX */
                _.Move(WS_VALOR_AUX2, FILLER_30.VL_DIFIOC_IX);

                /*" -7207- DISPLAY ' B2400 CONVERTE 2 DEC.:' VL-DIFIOC-IX */
                _.Display($" B2400 CONVERTE 2 DEC.:{FILLER_30.VL_DIFIOC_IX}");

                /*" -7207- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2499_999_EXIT*/

        [StopWatch]
        /*" B2500-LE-MOEDA-SECTION */
        private void B2500_LE_MOEDA_SECTION()
        {
            /*" -7218- MOVE 'B2500' TO WNR-EXEC-SQL. */
            _.Move("B2500", WABEND.WNR_EXEC_SQL);

            /*" -7227- PERFORM B2500_LE_MOEDA_DB_SELECT_1 */

            B2500_LE_MOEDA_DB_SELECT_1();

            /*" -7230- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -7231- DISPLAY 'PROBLEMAS NA COTACAO DE MOEDA' */
                _.Display($"PROBLEMAS NA COTACAO DE MOEDA");

                /*" -7231- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" B2500-LE-MOEDA-DB-SELECT-1 */
        public void B2500_LE_MOEDA_DB_SELECT_1()
        {
            /*" -7227- EXEC SQL SELECT VLCRUZAD INTO :MOED-VALOR FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ENDO-COD-MOEDA-PRM AND DTINIVIG <= :WHOST-DTINIVIG AND DTTERVIG >= :WHOST-DTINIVIG AND SITUACAO = '0' WITH UR END-EXEC. */

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
            /*" -7242- MOVE VL-LIQUIDO TO VL-LIQW */
            _.Move(EM0901W099.VL_LIQUIDO, FILLER_30.VL_LIQW);

            /*" -7243- MOVE VL-IOF TO VL-IOCCW */
            _.Move(EM0901W099.VL_IOF, FILLER_30.VL_IOCCW);

            /*" -7246- MOVE VL-TOTAL TO VL-TOTALW. */
            _.Move(EM0901W099.VL_TOTAL, FILLER_30.VL_TOTALW);

            /*" -7249- COMPUTE VL-IOCCPT = VL-IOF * ENDO-QTPARCEL */
            FILLER_30.VL_IOCCPT.Value = EM0901W099.VL_IOF * ENDO_QTPARCEL;

            /*" -7254- COMPUTE VL-TOTALPT = VL-TOTAL * ENDO-QTPARCEL */
            FILLER_30.VL_TOTALPT.Value = EM0901W099.VL_TOTAL * ENDO_QTPARCEL;

            /*" -7256- MOVE AU077-VLR-PREMIO-TOTAL TO VL-TOTAL */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_TOTAL, EM0901W099.VL_TOTAL);

            /*" -7260- COMPUTE VL-DIFTOT = VL-TOTAL - VL-TOTALPT */
            FILLER_30.VL_DIFTOT.Value = EM0901W099.VL_TOTAL - FILLER_30.VL_TOTALPT;

            /*" -7261- MOVE AU077-VLR-IOF TO VL-IOF */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_IOF, EM0901W099.VL_IOF);

            /*" -7266- COMPUTE VL-DIFIOC = VL-IOF - VL-IOCCPT */
            FILLER_30.VL_DIFIOC.Value = EM0901W099.VL_IOF - FILLER_30.VL_IOCCPT;

            /*" -7270- COMPUTE VL-TOTAL = VL-TOTALW + VL-DIFTOT */
            EM0901W099.VL_TOTAL.Value = FILLER_30.VL_TOTALW + FILLER_30.VL_DIFTOT;

            /*" -7272- COMPUTE VL-LIQUIDO ROUNDED = VL-TOTAL / (WS-PCT-IOF + 1) */
            EM0901W099.VL_LIQUIDO.Value = EM0901W099.VL_TOTAL / (WS_PCT_IOF + 1);

            /*" -7275- MOVE VL-LIQUIDO TO VL-TARIFA. */
            _.Move(EM0901W099.VL_LIQUIDO, EM0901W099.VL_TARIFA);

            /*" -7280- COMPUTE VL-IOF ROUNDED = VL-LIQUIDO * WS-PCT-IOF */
            EM0901W099.VL_IOF.Value = EM0901W099.VL_LIQUIDO * WS_PCT_IOF;

            /*" -7289- MOVE ZEROS TO VL-TARIFARIO-IX VL-DESC-IX VL-LIQ-IX VL-IOF-IX VL-ADIC-IX VL-CUSTO-IX VL-TOTAL-IX. */
            _.Move(0, EM0901W099.VL_TARIFARIO_IX, EM0901W099.VL_DESC_IX, EM0901W099.VL_LIQ_IX, EM0901W099.VL_IOF_IX, EM0901W099.VL_ADIC_IX, EM0901W099.VL_CUSTO_IX, EM0901W099.VL_TOTAL_IX);

            /*" -7290- MOVE VL-TARIFA TO VL-TARIFARIO-IX */
            _.Move(EM0901W099.VL_TARIFA, EM0901W099.VL_TARIFARIO_IX);

            /*" -7291- MOVE VL-DESCONTO TO VL-DESC-IX */
            _.Move(EM0901W099.VL_DESCONTO, EM0901W099.VL_DESC_IX);

            /*" -7292- MOVE VL-LIQUIDO TO VL-LIQ-IX */
            _.Move(EM0901W099.VL_LIQUIDO, EM0901W099.VL_LIQ_IX);

            /*" -7293- MOVE VL-IOF TO VL-IOF-IX */
            _.Move(EM0901W099.VL_IOF, EM0901W099.VL_IOF_IX);

            /*" -7294- MOVE VL-ADICIONAL TO VL-ADIC-IX */
            _.Move(EM0901W099.VL_ADICIONAL, EM0901W099.VL_ADIC_IX);

            /*" -7295- MOVE VL-CUSTO TO VL-CUSTO-IX */
            _.Move(EM0901W099.VL_CUSTO, EM0901W099.VL_CUSTO_IX);

            /*" -7298- MOVE VL-TOTAL TO VL-TOTAL-IX */
            _.Move(EM0901W099.VL_TOTAL, EM0901W099.VL_TOTAL_IX);

            /*" -7299- MOVE VL-TARIFARIO-IX TO VLAF-TARIFARIO-IX */
            _.Move(EM0901W099.VL_TARIFARIO_IX, VLAF_TARIFARIO_IX);

            /*" -7300- MOVE VL-DESC-IX TO VLAF-DESC-IX */
            _.Move(EM0901W099.VL_DESC_IX, VLAF_DESC_IX);

            /*" -7301- MOVE VL-LIQ-IX TO VLAF-LIQ-IX */
            _.Move(EM0901W099.VL_LIQ_IX, VLAF_LIQ_IX);

            /*" -7302- MOVE VL-IOF-IX TO VLAF-IOF-IX */
            _.Move(EM0901W099.VL_IOF_IX, VLAF_IOF_IX);

            /*" -7303- MOVE VL-ADIC-IX TO VLAF-ADIC-IX */
            _.Move(EM0901W099.VL_ADIC_IX, VLAF_ADIC_IX);

            /*" -7304- MOVE VL-CUSTO-IX TO VLAF-CUSTO-IX */
            _.Move(EM0901W099.VL_CUSTO_IX, VLAF_CUSTO_IX);

            /*" -7306- MOVE VL-TOTAL-IX TO VLAF-TOTAL-IX. */
            _.Move(EM0901W099.VL_TOTAL_IX, VLAF_TOTAL_IX);

            /*" -7307- MOVE VLAF-TARIFARIO-IX TO VL-TARIFARIO-IX */
            _.Move(VLAF_TARIFARIO_IX, EM0901W099.VL_TARIFARIO_IX);

            /*" -7308- MOVE VLAF-DESC-IX TO VL-DESC-IX */
            _.Move(VLAF_DESC_IX, EM0901W099.VL_DESC_IX);

            /*" -7309- MOVE VLAF-LIQ-IX TO VL-LIQ-IX */
            _.Move(VLAF_LIQ_IX, EM0901W099.VL_LIQ_IX);

            /*" -7310- MOVE VLAF-IOF-IX TO VL-IOF-IX */
            _.Move(VLAF_IOF_IX, EM0901W099.VL_IOF_IX);

            /*" -7311- MOVE VLAF-ADIC-IX TO VL-ADIC-IX */
            _.Move(VLAF_ADIC_IX, EM0901W099.VL_ADIC_IX);

            /*" -7312- MOVE VLAF-CUSTO-IX TO VL-CUSTO-IX */
            _.Move(VLAF_CUSTO_IX, EM0901W099.VL_CUSTO_IX);

            /*" -7312- MOVE VLAF-TOTAL-IX TO VL-TOTAL-IX. */
            _.Move(VLAF_TOTAL_IX, EM0901W099.VL_TOTAL_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B2699_999_EXIT*/

        [StopWatch]
        /*" B3000-GRAVA-HISTOPARC-SECTION */
        private void B3000_GRAVA_HISTOPARC_SECTION()
        {
            /*" -7323- MOVE 'B3000' TO WNR-EXEC-SQL. */
            _.Move("B3000", WABEND.WNR_EXEC_SQL);

            /*" -7324- MOVE ENDO-NUM-APOLICE TO HIST-NUM-APOLICE. */
            _.Move(ENDO_NUM_APOLICE, HIST_NUM_APOLICE);

            /*" -7325- MOVE ENDO-NRENDOS TO HIST-NRENDOS. */
            _.Move(ENDO_NRENDOS, HIST_NRENDOS);

            /*" -7326- MOVE PARC-NRPARCEL TO HIST-NRPARCEL. */
            _.Move(PARC_NRPARCEL, HIST_NRPARCEL);

            /*" -7327- MOVE PARC-DACPARC TO HIST-DACPARC. */
            _.Move(PARC_DACPARC, HIST_DACPARC);

            /*" -7329- MOVE SIST-DTMOVABE TO HIST-DTMOVTO. */
            _.Move(SIST_DTMOVABE, HIST_DTMOVTO);

            /*" -7331- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WS_TIME);

            /*" -7332- MOVE WS-HH-TIME TO WTIME-HORA */
            _.Move(WS_TIME.WS_HH_TIME, FILLER_4.WTIME_DAYR.WTIME_HORA);

            /*" -7333- MOVE '.' TO WTIME-2PT1 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT1);

            /*" -7334- MOVE WS-MM-TIME TO WTIME-MINU */
            _.Move(WS_TIME.WS_MM_TIME, FILLER_4.WTIME_DAYR.WTIME_MINU);

            /*" -7335- MOVE '.' TO WTIME-2PT2 */
            _.Move(".", FILLER_4.WTIME_DAYR.WTIME_2PT2);

            /*" -7336- MOVE WS-SS-TIME TO WTIME-SEGU */
            _.Move(WS_TIME.WS_SS_TIME, FILLER_4.WTIME_DAYR.WTIME_SEGU);

            /*" -7338- MOVE WTIME-DAYR TO HIST-HORAOPER. */
            _.Move(FILLER_4.WTIME_DAYR, HIST_HORAOPER);

            /*" -7342- MOVE ENDO-BCOCOBR TO HIST-BCOCOBR. */
            _.Move(ENDO_BCOCOBR, HIST_BCOCOBR);

            /*" -7346- MOVE ZEROS TO HIST-NRENDOCA HIST-SITCONTB HIST-RNUDOC. */
            _.Move(0, HIST_NRENDOCA, HIST_SITCONTB, HIST_RNUDOC);

            /*" -7347- MOVE ' ' TO HIST-COD-USUARIO. */
            _.Move(" ", HIST_COD_USUARIO);

            /*" -7349- MOVE -1 TO HIST-EMPRESA-I. */
            _.Move(-1, HIST_EMPRESA_I);

            /*" -7350- IF HIST-PRM-TARIFARIO < 0 */

            if (HIST_PRM_TARIFARIO < 0)
            {

                /*" -7352- COMPUTE HIST-PRM-TARIFARIO = HIST-PRM-TARIFARIO * -1. */
                HIST_PRM_TARIFARIO.Value = HIST_PRM_TARIFARIO * -1;
            }


            /*" -7353- IF HIST-VAL-DESCONTO < 0 */

            if (HIST_VAL_DESCONTO < 0)
            {

                /*" -7355- COMPUTE HIST-VAL-DESCONTO = HIST-VAL-DESCONTO * -1. */
                HIST_VAL_DESCONTO.Value = HIST_VAL_DESCONTO * -1;
            }


            /*" -7356- IF HIST-VLPRMLIQ < 0 */

            if (HIST_VLPRMLIQ < 0)
            {

                /*" -7358- COMPUTE HIST-VLPRMLIQ = HIST-VLPRMLIQ * -1. */
                HIST_VLPRMLIQ.Value = HIST_VLPRMLIQ * -1;
            }


            /*" -7359- IF HIST-VLADIFRA < 0 */

            if (HIST_VLADIFRA < 0)
            {

                /*" -7361- COMPUTE HIST-VLADIFRA = HIST-VLADIFRA * -1. */
                HIST_VLADIFRA.Value = HIST_VLADIFRA * -1;
            }


            /*" -7362- IF HIST-VLCUSEMI < 0 */

            if (HIST_VLCUSEMI < 0)
            {

                /*" -7364- COMPUTE HIST-VLCUSEMI = HIST-VLCUSEMI * -1. */
                HIST_VLCUSEMI.Value = HIST_VLCUSEMI * -1;
            }


            /*" -7365- IF HIST-VLIOCC < 0 */

            if (HIST_VLIOCC < 0)
            {

                /*" -7367- COMPUTE HIST-VLIOCC = HIST-VLIOCC * -1. */
                HIST_VLIOCC.Value = HIST_VLIOCC * -1;
            }


            /*" -7368- IF HIST-VLPRMTOT < 0 */

            if (HIST_VLPRMTOT < 0)
            {

                /*" -7370- COMPUTE HIST-VLPRMTOT = HIST-VLPRMTOT * -1. */
                HIST_VLPRMTOT.Value = HIST_VLPRMTOT * -1;
            }


            /*" -7371- IF HIST-VLPREMIO < 0 */

            if (HIST_VLPREMIO < 0)
            {

                /*" -7373- COMPUTE HIST-VLPREMIO = HIST-VLPREMIO * -1. */
                HIST_VLPREMIO.Value = HIST_VLPREMIO * -1;
            }


            /*" -7374- IF WS-VL-IOF-IGUAIS = 'S' */

            if (WS_VL_IOF_IGUAIS == "S")
            {

                /*" -7375- PERFORM B3010-TRATAR-VALORES */

                B3010_TRATAR_VALORES_SECTION();

                /*" -7377- END-IF. */
            }


            /*" -7380- IF ENDO-ORGAO = 10 AND ENDO-RAMO = 53 AND HIST-NRENDOS = 0 AND HIST-NRPARCEL = 2 */

            if (ENDO_ORGAO == 10 && ENDO_RAMO == 53 && HIST_NRENDOS == 0 && HIST_NRPARCEL == 2)
            {

                /*" -7400- IF (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26854706) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857299) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857301) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857302) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857303) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26857305) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26866284) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26866285) OR (ENDO-FONTE = 1 AND ENDO-NRPROPOS = 26869095) OR (ENDO-FONTE = 16 AND ENDO-NRPROPOS = 4539046) OR (ENDO-FONTE = 20 AND ENDO-NRPROPOS = 13042624) OR (ENDO-FONTE = 20 AND ENDO-NRPROPOS = 13042625) OR (ENDO-FONTE = 20 AND ENDO-NRPROPOS = 13045059) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12145129) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12173294) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12175575) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12175576) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12175577) OR (ENDO-FONTE = 21 AND ENDO-NRPROPOS = 12178684) */

                if ((ENDO_FONTE == 1 && ENDO_NRPROPOS == 26854706) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857299) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857301) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857302) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857303) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26857305) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26866284) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26866285) || (ENDO_FONTE == 1 && ENDO_NRPROPOS == 26869095) || (ENDO_FONTE == 16 && ENDO_NRPROPOS == 4539046) || (ENDO_FONTE == 20 && ENDO_NRPROPOS == 13042624) || (ENDO_FONTE == 20 && ENDO_NRPROPOS == 13042625) || (ENDO_FONTE == 20 && ENDO_NRPROPOS == 13045059) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12145129) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12173294) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12175575) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12175576) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12175577) || (ENDO_FONTE == 21 && ENDO_NRPROPOS == 12178684))
                {

                    /*" -7404- DISPLAY 'ALTERANDO DATA VENCIMENTO: ' ENDO-FONTE '-' ENDO-NRPROPOS '-' HIST-DTVENCTO */

                    $"ALTERANDO DATA VENCIMENTO: {ENDO_FONTE}-{ENDO_NRPROPOS}-{HIST_DTVENCTO}"
                    .Display();

                    /*" -7406- MOVE '2018-04-25' TO HIST-DTVENCTO */
                    _.Move("2018-04-25", HIST_DTVENCTO);

                    /*" -7407- END-IF */
                }


                /*" -7409- END-IF */
            }


            /*" -7411- MOVE HIST-DTVENCTO TO WS-DT-AUX. */
            _.Move(HIST_DTVENCTO, WS_DT_AUX);

            /*" -7417- IF WS-DIA-AUX NOT EQUAL '01' AND '02' AND '03' AND '04' AND '05' AND '06' AND '07' AND '08' AND '09' AND '10' AND '11' AND '12' AND '13' AND '14' AND '15' AND '16' AND '17' AND '18' AND '19' AND '20' AND '21' AND '22' AND '23' AND '24' AND '25' AND '26' AND '27' AND '28' AND '29' AND '30' AND '31' */

            if (!WS_DT_AUX.WS_DIA_AUX.In("01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"))
            {

                /*" -7418- PERFORM B3005-PEGAR-ULTIMO-DIA */

                B3005_PEGAR_ULTIMO_DIA_SECTION();

                /*" -7428- END-IF. */
            }


            /*" -7429- IF ENDO-ORGAO = 10 AND ENDO-RAMO = 53 */

            if (ENDO_ORGAO == 10 && ENDO_RAMO == 53)
            {

                /*" -7432- IF PRCB-TIPO-COBRANCA = '0' AND PARC-NRPARCEL > 1 AND HIST-OPERACAO = 101 */

                if (PRCB_TIPO_COBRANCA == "0" && PARC_NRPARCEL > 1 && HIST_OPERACAO == 101)
                {

                    /*" -7433- PERFORM R7220-00-CONSULTA-NN */

                    R7220_00_CONSULTA_NN_SECTION();

                    /*" -7434- END-IF */
                }


                /*" -7437- END-IF */
            }


            /*" -7438- IF ENDO-NUM-APOLICE = 106100000011 OR 106800000024 */

            if (ENDO_NUM_APOLICE.In("106100000011", "106800000024"))
            {

                /*" -7439- COMPUTE WS-VLR-IOF ROUNDED = (HIST-VLPREMIO * 0,0738) */
                WS_VLR_IOF.Value = (HIST_VLPREMIO * 0.0738);

                /*" -7441- COMPUTE WS-VLR-PRM-LIQ ROUNDED = HIST-VLPREMIO - WS-VLR-IOF */
                WS_VLR_PRM_LIQ.Value = HIST_VLPREMIO - WS_VLR_IOF;

                /*" -7442- MOVE WS-VLR-PRM-LIQ TO HIST-PRM-TARIFARIO */
                _.Move(WS_VLR_PRM_LIQ, HIST_PRM_TARIFARIO);

                /*" -7443- MOVE WS-VLR-PRM-LIQ TO HIST-VLPRMLIQ */
                _.Move(WS_VLR_PRM_LIQ, HIST_VLPRMLIQ);

                /*" -7444- MOVE WS-VLR-IOF TO HIST-VLIOCC */
                _.Move(WS_VLR_IOF, HIST_VLIOCC);

                /*" -7446- END-IF */
            }


            /*" -7475- PERFORM B3000_GRAVA_HISTOPARC_DB_INSERT_1 */

            B3000_GRAVA_HISTOPARC_DB_INSERT_1();

            /*" -7478- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, WS_SQLCODE);

            /*" -7479- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7480- DISPLAY ENDO-FONTE, '     ' , ENDO-NRPROPOS */

                $"{ENDO_FONTE}     {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.FILLER}{ENDO_NRPROPOS}"
                .Display();

                /*" -7481- DISPLAY 'EM0010B - ERRO INSERT V0HISTOPARC' */
                _.Display($"EM0010B - ERRO INSERT V0HISTOPARC");

                /*" -7482- PERFORM B3001-DISPLAY-DADOS-INSERT */

                B3001_DISPLAY_DADOS_INSERT_SECTION();

                /*" -7484- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7485- ADD 1 TO AC-I-V0HISTOPARC. */
            AC_I_V0HISTOPARC.Value = AC_I_V0HISTOPARC + 1;

            /*" -7485- PERFORM B3001-DISPLAY-DADOS-INSERT. */

            B3001_DISPLAY_DADOS_INSERT_SECTION();

        }

        [StopWatch]
        /*" B3000-GRAVA-HISTOPARC-DB-INSERT-1 */
        public void B3000_GRAVA_HISTOPARC_DB_INSERT_1()
        {
            /*" -7475- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:HIST-NUM-APOLICE , :HIST-NRENDOS , :HIST-NRPARCEL , :HIST-DACPARC , :HIST-DTMOVTO , :HIST-OPERACAO , :HIST-HORAOPER , :HIST-OCORHIST , :HIST-PRM-TARIFARIO , :HIST-VAL-DESCONTO , :HIST-VLPRMLIQ , :HIST-VLADIFRA , :HIST-VLCUSEMI , :HIST-VLIOCC , :HIST-VLPRMTOT , :HIST-VLPREMIO , :HIST-DTVENCTO , :HIST-BCOCOBR , :HIST-AGECOBR , :HIST-NRAVISO , :HIST-NRENDOCA , :HIST-SITCONTB , :HIST-COD-USUARIO , :HIST-RNUDOC , :HIST-DTQITBCO:HIST-DTQITBCO-I, :HIST-COD-EMPRESA:HIST-EMPRESA-I, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -7495- DISPLAY 'EM0010B - DADOS DO INSERT DA V0HISTOPARC ----------' */
            _.Display($"EM0010B - DADOS DO INSERT DA V0HISTOPARC ----------");

            /*" -7496- DISPLAY 'SQLCODE DO INSERT  = ' WS-SQLCODE */
            _.Display($"SQLCODE DO INSERT  = {WS_SQLCODE}");

            /*" -7497- DISPLAY 'HIST-NUM-APOLICE   = ' HIST-NUM-APOLICE */
            _.Display($"HIST-NUM-APOLICE   = {HIST_NUM_APOLICE}");

            /*" -7498- DISPLAY 'HIST-NRENDOS       = ' HIST-NRENDOS */
            _.Display($"HIST-NRENDOS       = {HIST_NRENDOS}");

            /*" -7499- DISPLAY 'HIST-NRPARCEL      = ' HIST-NRPARCEL */
            _.Display($"HIST-NRPARCEL      = {HIST_NRPARCEL}");

            /*" -7500- DISPLAY 'HIST-DACPARC       = ' HIST-DACPARC */
            _.Display($"HIST-DACPARC       = {HIST_DACPARC}");

            /*" -7501- DISPLAY 'HIST-DTMOVTO       = ' HIST-DTMOVTO */
            _.Display($"HIST-DTMOVTO       = {HIST_DTMOVTO}");

            /*" -7502- DISPLAY 'HIST-OPERACAO      = ' HIST-OPERACAO */
            _.Display($"HIST-OPERACAO      = {HIST_OPERACAO}");

            /*" -7503- DISPLAY 'HIST-HORAOPER      = ' HIST-HORAOPER */
            _.Display($"HIST-HORAOPER      = {HIST_HORAOPER}");

            /*" -7504- DISPLAY 'HIST-OCORHIST      = ' HIST-OCORHIST */
            _.Display($"HIST-OCORHIST      = {HIST_OCORHIST}");

            /*" -7505- DISPLAY 'HIST-PRM-TARIFARIO = ' HIST-PRM-TARIFARIO */
            _.Display($"HIST-PRM-TARIFARIO = {HIST_PRM_TARIFARIO}");

            /*" -7506- DISPLAY 'HIST-VAL-DESCONTO  = ' HIST-VAL-DESCONTO */
            _.Display($"HIST-VAL-DESCONTO  = {HIST_VAL_DESCONTO}");

            /*" -7507- DISPLAY 'HIST-VLPRMLIQ      = ' HIST-VLPRMLIQ */
            _.Display($"HIST-VLPRMLIQ      = {HIST_VLPRMLIQ}");

            /*" -7508- DISPLAY 'HIST-VLADIFRA      = ' HIST-VLADIFRA */
            _.Display($"HIST-VLADIFRA      = {HIST_VLADIFRA}");

            /*" -7509- DISPLAY 'HIST-VLCUSEMI      = ' HIST-VLCUSEMI */
            _.Display($"HIST-VLCUSEMI      = {HIST_VLCUSEMI}");

            /*" -7510- DISPLAY 'HIST-VLIOCC        = ' HIST-VLIOCC */
            _.Display($"HIST-VLIOCC        = {HIST_VLIOCC}");

            /*" -7511- DISPLAY 'HIST-VLPRMTOT      = ' HIST-VLPRMTOT */
            _.Display($"HIST-VLPRMTOT      = {HIST_VLPRMTOT}");

            /*" -7512- DISPLAY 'HIST-VLPREMIO      = ' HIST-VLPREMIO */
            _.Display($"HIST-VLPREMIO      = {HIST_VLPREMIO}");

            /*" -7513- DISPLAY 'HIST-DTVENCTO      = ' HIST-DTVENCTO */
            _.Display($"HIST-DTVENCTO      = {HIST_DTVENCTO}");

            /*" -7514- DISPLAY 'HIST-BCOCOBR       = ' HIST-BCOCOBR */
            _.Display($"HIST-BCOCOBR       = {HIST_BCOCOBR}");

            /*" -7515- DISPLAY 'HIST-AGECOBR       = ' HIST-AGECOBR */
            _.Display($"HIST-AGECOBR       = {HIST_AGECOBR}");

            /*" -7516- DISPLAY 'HIST-NRAVISO       = ' HIST-NRAVISO */
            _.Display($"HIST-NRAVISO       = {HIST_NRAVISO}");

            /*" -7517- DISPLAY 'HIST-NRENDOCA      = ' HIST-NRENDOCA */
            _.Display($"HIST-NRENDOCA      = {HIST_NRENDOCA}");

            /*" -7518- DISPLAY 'HIST-SITCONTB      = ' HIST-SITCONTB */
            _.Display($"HIST-SITCONTB      = {HIST_SITCONTB}");

            /*" -7519- DISPLAY 'HIST-COD-USUARIO   = ' HIST-COD-USUARIO */
            _.Display($"HIST-COD-USUARIO   = {HIST_COD_USUARIO}");

            /*" -7520- DISPLAY 'HIST-RNUDOC        = ' HIST-RNUDOC */
            _.Display($"HIST-RNUDOC        = {HIST_RNUDOC}");

            /*" -7521- DISPLAY 'HIST-DTQITBCO      = ' HIST-DTQITBCO */
            _.Display($"HIST-DTQITBCO      = {HIST_DTQITBCO}");

            /*" -7522- DISPLAY 'HIST-COD-EMPRESA   = ' HIST-COD-EMPRESA */
            _.Display($"HIST-COD-EMPRESA   = {HIST_COD_EMPRESA}");

            /*" -7523- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -7524- DISPLAY 'MOVEU A HIST-DTVENCTO => ' WS-MOV-DTVENCTO */
            _.Display($"MOVEU A HIST-DTVENCTO => {WS_MOV_DTVENCTO}");

            /*" -7525- DISPLAY 'MOVEU A HIST-DTQITBCO => ' WS-MOV-DTQITBCO */
            _.Display($"MOVEU A HIST-DTQITBCO => {WS_MOV_DTQITBCO}");

            /*" -7526- DISPLAY 'WS-DT-AUX = ' WS-DT-AUX */
            _.Display($"WS-DT-AUX = {WS_DT_AUX}");

            /*" -7526- DISPLAY 'WS-DIA-AUX = ' WS-DIA-AUX. */
            _.Display($"WS-DIA-AUX = {WS_DT_AUX.WS_DIA_AUX}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3001_999_EXIT*/

        [StopWatch]
        /*" B3005-PEGAR-ULTIMO-DIA-SECTION */
        private void B3005_PEGAR_ULTIMO_DIA_SECTION()
        {
            /*" -7535- MOVE '01' TO WS-DIA-AUX. */
            _.Move("01", WS_DT_AUX.WS_DIA_AUX);

            /*" -7537- MOVE WS-DT-AUX TO CALENDAR-DATA-CALENDARIO */
            _.Move(WS_DT_AUX, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);

            /*" -7543- PERFORM B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1 */

            B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1();

            /*" -7546- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7547- DISPLAY 'EM0010B - ERRO SELECT CALENDARIO ' */
                _.Display($"EM0010B - ERRO SELECT CALENDARIO ");

                /*" -7548- DISPLAY 'DATA-CALENDARIO = ' CALENDAR-DATA-CALENDARIO */
                _.Display($"DATA-CALENDARIO = {CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO}");

                /*" -7549- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -7551- END-IF. */
            }


            /*" -7552- MOVE CALENDAR-DTH-ULT-DIA-MES(9:2) TO WS-DIA-AUX. */
            _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DTH_ULT_DIA_MES.Substring(9, 2), WS_DT_AUX.WS_DIA_AUX);

            /*" -7553- MOVE WS-DT-AUX TO HIST-DTVENCTO. */
            _.Move(WS_DT_AUX, HIST_DTVENCTO);

            /*" -7553- DISPLAY 'HIST-DTVENCTO = ' HIST-DTVENCTO. */
            _.Display($"HIST-DTVENCTO = {HIST_DTVENCTO}");

        }

        [StopWatch]
        /*" B3005-PEGAR-ULTIMO-DIA-DB-SELECT-1 */
        public void B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1()
        {
            /*" -7543- EXEC SQL SELECT DTH_ULT_DIA_MES INTO :CALENDAR-DTH-ULT-DIA-MES FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :CALENDAR-DATA-CALENDARIO WITH UR END-EXEC. */

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
            /*" -7564- IF (ENDO-NUM-APOLICE = 106800000018 AND ENDO-CODPRODU = 6821) OR (ENDO-NUM-APOLICE = 106800000011 AND ENDO-CODPRODU = 6812) OR (ENDO-NUM-APOLICE = 106100000002 AND ENDO-CODPRODU = 6103) OR (ENDO-NUM-APOLICE = 106800000020 AND ENDO-CODPRODU = 6823) */

            if ((ENDO_NUM_APOLICE == 106800000018 && ENDO_CODPRODU == 6821) || (ENDO_NUM_APOLICE == 106800000011 && ENDO_CODPRODU == 6812) || (ENDO_NUM_APOLICE == 106100000002 && ENDO_CODPRODU == 6103) || (ENDO_NUM_APOLICE == 106800000020 && ENDO_CODPRODU == 6823))
            {

                /*" -7566- COMPUTE HIST-PRM-TARIFARIO = HIST-PRM-TARIFARIO - HIST-VLIOCC */
                HIST_PRM_TARIFARIO.Value = HIST_PRM_TARIFARIO - HIST_VLIOCC;

                /*" -7567- COMPUTE HIST-VLPRMLIQ = HIST-VLPRMLIQ - HIST-VLIOCC */
                HIST_VLPRMLIQ.Value = HIST_VLPRMLIQ - HIST_VLIOCC;

                /*" -7568- COMPUTE HIST-VLPRMTOT = HIST-VLPRMTOT - HIST-VLIOCC */
                HIST_VLPRMTOT.Value = HIST_VLPRMTOT - HIST_VLIOCC;

                /*" -7569- COMPUTE HIST-VLPREMIO = HIST-VLPREMIO - HIST-VLIOCC */
                HIST_VLPREMIO.Value = HIST_VLPREMIO - HIST_VLIOCC;

                /*" -7569- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B3010_999_EXIT*/

        [StopWatch]
        /*" B3100-SELECT-V1RCAPCOMP-SECTION */
        private void B3100_SELECT_V1RCAPCOMP_SECTION()
        {
            /*" -7579- MOVE 'B3100' TO WNR-EXEC-SQL. */
            _.Move("B3100", WABEND.WNR_EXEC_SQL);

            /*" -7597- PERFORM B3100_SELECT_V1RCAPCOMP_DB_SELECT_1 */

            B3100_SELECT_V1RCAPCOMP_DB_SELECT_1();

            /*" -7600- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -7601- MOVE '*' TO WFIM-V1RCAPCOMP */
                _.Move("*", WFIM_V1RCAPCOMP);

                /*" -7602- ELSE */
            }
            else
            {


                /*" -7603- IF SQLCODE EQUAL -810 OR -811 */

                if (DB.SQLCODE.In("-810", "-811"))
                {

                    /*" -7604- PERFORM B3150-SELECT-V1RCAPCOMP */

                    B3150_SELECT_V1RCAPCOMP_SECTION();

                    /*" -7605- ELSE */
                }
                else
                {


                    /*" -7606- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -7607- DISPLAY 'ERRO SELECT V1RCAPCOMP' */
                        _.Display($"ERRO SELECT V1RCAPCOMP");

                        /*" -7610- GO TO 999-999-ROT-ERRO. */

                        M_999_999_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -7611- IF WFIM-V1RCAPCOMP NOT EQUAL SPACES */

            if (!WFIM_V1RCAPCOMP.IsEmpty())
            {

                /*" -7614- GO TO B3100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B3100_999_EXIT*/ //GOTO
                return;
            }


            /*" -7618- IF PCOM-OPERACAO EQUAL 200 OR 210 OR 220 OR 400 */

            if (PCOM_OPERACAO.In("200", "210", "220", "400"))
            {

                /*" -7618- MOVE '*' TO WFIM-V1RCAPCOMP. */
                _.Move("*", WFIM_V1RCAPCOMP);
            }


        }

        [StopWatch]
        /*" B3100-SELECT-V1RCAPCOMP-DB-SELECT-1 */
        public void B3100_SELECT_V1RCAPCOMP_DB_SELECT_1()
        {
            /*" -7597- EXEC SQL SELECT FONTE , NRRCAP , BCOAVISO , AGEAVISO , NRAVISO , OPERACAO INTO :PCOM-FONTE , :PCOM-NRRCAP , :PCOM-BCOAVISO , :PCOM-AGEAVISO , :PCOM-NRAVISO , :PCOM-OPERACAO FROM SEGUROS.V1RCAPCOMP WHERE NRRCAP = :ENDO-NRRCAP AND NRRCAPCO = 0 AND SITUACAO = '0' WITH UR END-EXEC. */

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
            /*" -7630- MOVE 'B3150' TO WNR-EXEC-SQL. */
            _.Move("B3150", WABEND.WNR_EXEC_SQL);

            /*" -7649- PERFORM B3150_SELECT_V1RCAPCOMP_DB_SELECT_1 */

            B3150_SELECT_V1RCAPCOMP_DB_SELECT_1();

            /*" -7652- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -7653- MOVE '*' TO WFIM-V1RCAPCOMP */
                _.Move("*", WFIM_V1RCAPCOMP);

                /*" -7654- ELSE */
            }
            else
            {


                /*" -7655- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -7656- DISPLAY 'ERRO SELECT V1RCAPCOMP' */
                    _.Display($"ERRO SELECT V1RCAPCOMP");

                    /*" -7657- DISPLAY ' ' ENDO-FONTE ' ' ENDO-NRRCAP */

                    $" {ENDO_FONTE} {ENDO_NRRCAP}"
                    .Display();

                    /*" -7657- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B3150-SELECT-V1RCAPCOMP-DB-SELECT-1 */
        public void B3150_SELECT_V1RCAPCOMP_DB_SELECT_1()
        {
            /*" -7649- EXEC SQL SELECT FONTE , NRRCAP , BCOAVISO , AGEAVISO , NRAVISO , OPERACAO INTO :PCOM-FONTE , :PCOM-NRRCAP , :PCOM-BCOAVISO , :PCOM-AGEAVISO , :PCOM-NRAVISO , :PCOM-OPERACAO FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :ENDO-FONTE AND NRRCAP = :ENDO-NRRCAP AND NRRCAPCO = 0 AND SITUACAO = '0' WITH UR END-EXEC. */

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
            /*" -7669- MOVE 'B3160' TO WNR-EXEC-SQL. */
            _.Move("B3160", WABEND.WNR_EXEC_SQL);

            /*" -7676- PERFORM B3160_ALTERA_V0PARCELA_DB_UPDATE_1 */

            B3160_ALTERA_V0PARCELA_DB_UPDATE_1();

            /*" -7679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7682- DISPLAY 'ERRO UPDATE V0PARCELA      ' ' ' PARC-NUM-APOLICE ' ' PARC-NRENDOS ' ' PARC-NRPARCEL. */

                $"ERRO UPDATE V0PARCELA       {PARC_NUM_APOLICE} {PARC_NRENDOS} {PARC_NRPARCEL}"
                .Display();
            }


        }

        [StopWatch]
        /*" B3160-ALTERA-V0PARCELA-DB-UPDATE-1 */
        public void B3160_ALTERA_V0PARCELA_DB_UPDATE_1()
        {
            /*" -7676- EXEC SQL UPDATE SEGUROS.V0PARCELA SET OCORHIST = 1, SITUACAO = '0' WHERE NUM_APOLICE = :PARC-NUM-APOLICE AND NRENDOS = :PARC-NRENDOS AND NRPARCEL = :PARC-NRPARCEL END-EXEC. */

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
            /*" -7694- MOVE 'B3200' TO WNR-EXEC-SQL. */
            _.Move("B3200", WABEND.WNR_EXEC_SQL);

            /*" -7702- PERFORM B3200_SELECT_V1AVISALDOS_DB_SELECT_1 */

            B3200_SELECT_V1AVISALDOS_DB_SELECT_1();

            /*" -7705- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7706- MOVE '*' TO WFIM-V1AVISALDOS */
                _.Move("*", WFIM_V1AVISALDOS);

                /*" -7709- DISPLAY 'ERRO SELECT V1AVISALDOS' ' ' V1ASAL-BCOAVISO ' ' V1ASAL-AGEAVISO ' ' V1ASAL-NRAVISO. */

                $"ERRO SELECT V1AVISALDOS {V1ASAL_BCOAVISO} {V1ASAL_AGEAVISO} {V1ASAL_NRAVISO}"
                .Display();
            }


        }

        [StopWatch]
        /*" B3200-SELECT-V1AVISALDOS-DB-SELECT-1 */
        public void B3200_SELECT_V1AVISALDOS_DB_SELECT_1()
        {
            /*" -7702- EXEC SQL SELECT SDOATU INTO :V1ASAL-SDOATU FROM SEGUROS.V1AVISOS_SALDOS WHERE BCOAVISO = :V1ASAL-BCOAVISO AND AGEAVISO = :V1ASAL-AGEAVISO AND NRAVISO = :V1ASAL-NRAVISO WITH UR END-EXEC. */

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
            /*" -7729- MOVE 'B3300' TO WNR-EXEC-SQL. */
            _.Move("B3300", WABEND.WNR_EXEC_SQL);

            /*" -7732- COMPUTE V1ASAL-SDOATU EQUAL V1ASAL-SDOATU - PCOM-VLRCAP. */
            V1ASAL_SDOATU.Value = V1ASAL_SDOATU - PCOM_VLRCAP;

            /*" -7739- PERFORM B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1 */

            B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1();

            /*" -7742- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7745- DISPLAY 'ERRO UPDATE V0AVISOS_SALDOS' ' ' PCOM-BCOAVISO ' ' PCOM-AGEAVISO ' ' PCOM-NRAVISO. */

                $"ERRO UPDATE V0AVISOS_SALDOS {PCOM_BCOAVISO} {PCOM_AGEAVISO} {PCOM_NRAVISO}"
                .Display();
            }


        }

        [StopWatch]
        /*" B3300-ALTERA-V0AVISALDOS-DB-UPDATE-1 */
        public void B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1()
        {
            /*" -7739- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = :V1ASAL-SDOATU, TIMESTAMP = CURRENT TIMESTAMP WHERE BCOAVISO = :V1ASAL-BCOAVISO AND AGEAVISO = :V1ASAL-AGEAVISO AND NRAVISO = :V1ASAL-NRAVISO END-EXEC. */

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
            /*" -7887- MOVE 'B4000' TO WNR-EXEC-SQL. */
            _.Move("B4000", WABEND.WNR_EXEC_SQL);

            /*" -7902- IF ((ENDO-NRRCAP > 0) AND (ENDO-QTPARCEL = 0 OR 1)) OR ((ENDO-NUMBIL > 0) AND (ENDO-CODPRODU NOT = 32) AND (ENDO-VLRCAP > 0) AND (ENDO-QTPARCEL = 0 OR 1)) OR ((ENDO-CODPRODU = 32) AND (ENDO-VLRCAP > 0) AND (ENDO-AGERCAP = 9000) AND (ENDO-QTPARCEL = 0 OR 1)) OR ((ENDO-CODPRODU = 83) AND (ENDO-VLRCAP > 0) AND (ENDO-QTPARCEL = 0 OR 1)) */

            if (((ENDO_NRRCAP > 0) && (ENDO_QTPARCEL.In("0", "1"))) || ((ENDO_NUMBIL > 0) && (ENDO_CODPRODU != 32) && (ENDO_VLRCAP > 0) && (ENDO_QTPARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 32) && (ENDO_VLRCAP > 0) && (ENDO_AGERCAP == 9000) && (ENDO_QTPARCEL.In("0", "1"))) || ((ENDO_CODPRODU == 83) && (ENDO_VLRCAP > 0) && (ENDO_QTPARCEL.In("0", "1"))))
            {

                /*" -7903- MOVE '1' TO WSITUACAO */
                _.Move("1", WSITUACAO);

                /*" -7904- ELSE */
            }
            else
            {


                /*" -7909- MOVE '0' TO WSITUACAO. */
                _.Move("0", WSITUACAO);
            }


            /*" -7910- IF ENDO-TIPO-ENDOSSO EQUAL '4' */

            if (ENDO_TIPO_ENDOSSO == "4")
            {

                /*" -7912- MOVE '1' TO WSITUACAO. */
                _.Move("1", WSITUACAO);
            }


            /*" -7919- PERFORM B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1 */

            B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1();

            /*" -7922- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -7923- DISPLAY 'EM0010B - ERRO UPDATE V0ENDOSSO' */
                _.Display($"EM0010B - ERRO UPDATE V0ENDOSSO");

                /*" -7927- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -7938- IF (ENDO-CODPRODU EQUAL 1803 OR 1805) AND (ENDO-NRENDOS EQUAL 0 ) */

            if ((ENDO_CODPRODU.In("1803", "1805")) && (ENDO_NRENDOS == 0))
            {

                /*" -7940- PERFORM B4050-00-INSERT-SOL-TITULO-CAP */

                B4050_00_INSERT_SOL_TITULO_CAP_SECTION();

                /*" -7942- END-IF. */
            }


            /*" -7943- MOVE 'EM0100B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0100B1", V0EDIA_CODRELAT);

            /*" -7944- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -7945- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -7946- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -7947- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -7948- MOVE APOL-ORGAO TO V0EDIA-ORGAO. */
            _.Move(APOL_ORGAO, V0EDIA_ORGAO);

            /*" -7949- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -7950- MOVE ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(ENDO_FONTE, V0EDIA_FONTE);

            /*" -7951- MOVE ZEROS TO V0EDIA-CONGENER. */
            _.Move(0, V0EDIA_CONGENER);

            /*" -7952- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -7959- MOVE HIST-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(HIST_COD_EMPRESA, V0EDIA_COD_EMP);

            /*" -7961- IF ENDO-CODPRODU EQUAL 1803 OR 1805 NEXT SENTENCE */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -7962- ELSE */
            }
            else
            {


                /*" -7964- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -7971- MOVE 'EM0090B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0090B1", V0EDIA_CODRELAT);

            /*" -7973- IF ENDO-CODPRODU EQUAL 1803 OR 1805 NEXT SENTENCE */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -7974- ELSE */
            }
            else
            {


                /*" -7976- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -7978- MOVE 'EM0101B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0101B1", V0EDIA_CODRELAT);

            /*" -7985- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -7987- IF ENDO-CODPRODU EQUAL 1803 OR 1805 NEXT SENTENCE */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -7988- ELSE */
            }
            else
            {


                /*" -7990- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -7991- IF ENDO-RAMO EQUAL ( 31 OR 53 ) */

            if (ENDO_RAMO.In("31", "53"))
            {

                /*" -7992- MOVE 'AU0050B1' TO V0EDIA-CODRELAT */
                _.Move("AU0050B1", V0EDIA_CODRELAT);

                /*" -7994- MOVE ZEROS TO V0EDIA-ORGAO */
                _.Move(0, V0EDIA_ORGAO);

                /*" -7996- PERFORM B4200-INCLUI-V0EMISDIARIA */

                B4200_INCLUI_V0EMISDIARIA_SECTION();

                /*" -7997- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -7998- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -8000- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8002- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                    if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                    {

                        /*" -8003- IF ENDO-QTPARCEL EQUAL ZEROS */

                        if (ENDO_QTPARCEL == 00)
                        {

                            /*" -8004- MOVE ZEROS TO V0EDIA-NRPARCEL */
                            _.Move(0, V0EDIA_NRPARCEL);

                            /*" -8005- ELSE */
                        }
                        else
                        {


                            /*" -8007- MOVE 1 TO V0EDIA-NRPARCEL */
                            _.Move(1, V0EDIA_NRPARCEL);

                            /*" -8009- END-IF */
                        }


                        /*" -8011- PERFORM B4200-INCLUI-V0EMISDIARIA */

                        B4200_INCLUI_V0EMISDIARIA_SECTION();

                        /*" -8013- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                        if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                        {

                            /*" -8014- MOVE ZEROS TO V0EDIA-NRPARCEL */
                            _.Move(0, V0EDIA_NRPARCEL);

                            /*" -8015- MOVE 'AU2060B1' TO V0EDIA-CODRELAT */
                            _.Move("AU2060B1", V0EDIA_CODRELAT);

                            /*" -8016- MOVE ZEROS TO V0EDIA-ORGAO */
                            _.Move(0, V0EDIA_ORGAO);

                            /*" -8017- PERFORM B4200-INCLUI-V0EMISDIARIA */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();

                            /*" -8018- MOVE 'AU2070B1' TO V0EDIA-CODRELAT */
                            _.Move("AU2070B1", V0EDIA_CODRELAT);

                            /*" -8019- MOVE ZEROS TO V0EDIA-ORGAO */
                            _.Move(0, V0EDIA_ORGAO);

                            /*" -8021- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();
                        }

                    }

                }

            }


            /*" -8025- IF ENDO-RAMO EQUAL 53 AND ENDO-ORGAO EQUAL 10 AND ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

            if (ENDO_RAMO == 53 && ENDO_ORGAO == 10 && ENDO_CODPRODU.In("5302", "5303", "5304"))
            {

                /*" -8026- IF ENDO-TIPO-ENDOSSO EQUAL '4' OR '5' */

                if (ENDO_TIPO_ENDOSSO.In("4", "5"))
                {

                    /*" -8027- MOVE 'AU2060B1' TO V0EDIA-CODRELAT */
                    _.Move("AU2060B1", V0EDIA_CODRELAT);

                    /*" -8028- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8031- PERFORM B4200-INCLUI-V0EMISDIARIA */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();

                    /*" -8032- MOVE 'AU2070B1' TO V0EDIA-CODRELAT */
                    _.Move("AU2070B1", V0EDIA_CODRELAT);

                    /*" -8033- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8035- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -8036- IF ENDO-RAMO EQUAL (40 OR 67 OR 45 OR 75) */

            if (ENDO_RAMO.In("40", "67", "45", "75"))
            {

                /*" -8037- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -8038- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -8039- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8041- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -8042- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

            if (ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -8049- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' OR '5' OR '3' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1", "5", "3"))
                {

                    /*" -8050- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -8051- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8069- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -8080- IF (ENDO-NUM-APOLICE EQUAL 106800000012 OR EQUAL 106000000003 OR EQUAL 106000000004 OR EQUAL 107700000015 OR EQUAL 107700000016 OR EQUAL 104800000052 OR EQUAL 104800000053 OR EQUAL 104800000054 OR EQUAL 104800000055 OR EQUAL 104800000058 OR EQUAL 101402541676) */

            if ((ENDO_NUM_APOLICE.In("106800000012", "106000000003", "106000000004", "107700000015", "107700000016", "104800000052", "104800000053", "104800000054", "104800000055", "104800000058", "101402541676")))
            {

                /*" -8082- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                {

                    /*" -8084- COMPUTE WS-VL-COB = WS-EF-VLR-EMISSAO + WS-EF-VLR-CREDITO */
                    WS_VL_COB.Value = WS_EF_VLR_EMISSAO + WS_EF_VLR_CREDITO;

                    /*" -8085- PERFORM B2094-ALTERA-V0COBERAPOL */

                    B2094_ALTERA_V0COBERAPOL_SECTION();

                    /*" -8086- END-IF */
                }


                /*" -8088- END-IF. */
            }


            /*" -8104- IF (ENDO-RAMO EQUAL 68 OR 61 OR 65) OR (ENDO-NUM-APOLICE EQUAL 0107700000022 OR 0101402541675 OR 0107700000021 OR 0107700000023 OR 0107700000038 OR 0101402541678 OR 0107700000026 OR 0106100000030 OR 0101402541682 OR 0106100000033 OR 0101402541681 OR 0106100000036 OR 0101402541683 OR 0106100000018 OR 0101402541679) */

            if ((ENDO_RAMO.In("68", "61", "65")) || (ENDO_NUM_APOLICE.In("0107700000022", "0101402541675", "0107700000021", "0107700000023", "0107700000038", "0101402541678", "0107700000026", "0106100000030", "0101402541682", "0106100000033", "0101402541681", "0106100000036", "0101402541683", "0106100000018", "0101402541679")))
            {

                /*" -8107- IF ENDO-NUM-APOLICE NOT EQUAL 0106800000007 AND NOT EQUAL 0106500000001 */

                if (!ENDO_NUM_APOLICE.In("0106800000007", "0106500000001"))
                {

                    /*" -8109- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                    if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                    {

                        /*" -8110- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                        if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                        {

                            /*" -8111- MOVE WS-EF-VLR-EMISSAO TO WS-VL-COB */
                            _.Move(WS_EF_VLR_EMISSAO, WS_VL_COB);

                            /*" -8112- ELSE */
                        }
                        else
                        {


                            /*" -8113- MOVE WS-EF-VLR-CREDITO TO WS-VL-COB */
                            _.Move(WS_EF_VLR_CREDITO, WS_VL_COB);

                            /*" -8115- END-IF */
                        }


                        /*" -8116- END-IF */
                    }


                    /*" -8117- END-IF */
                }


                /*" -8121- END-IF. */
            }


            /*" -8122- IF ENDO-RAMO EQUAL 48 OR 70 */

            if (ENDO_RAMO.In("48", "70"))
            {

                /*" -8124- IF ENDO-CODPRODU NOT EQUAL 4801 OR 4808 OR 4812 OR 7001 */

                if (!ENDO_CODPRODU.In("4801", "4808", "4812", "7001"))
                {

                    /*" -8126- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                    if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                    {

                        /*" -8127- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                        if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                        {

                            /*" -8128- MOVE WS-EF-VLR-EMISSAO TO WS-VL-COB */
                            _.Move(WS_EF_VLR_EMISSAO, WS_VL_COB);

                            /*" -8129- ELSE */
                        }
                        else
                        {


                            /*" -8130- MOVE WS-EF-VLR-CREDITO TO WS-VL-COB */
                            _.Move(WS_EF_VLR_CREDITO, WS_VL_COB);

                            /*" -8132- END-IF */
                        }


                        /*" -8133- END-IF */
                    }


                    /*" -8134- END-IF */
                }


                /*" -8136- END-IF. */
            }


            /*" -8137- IF ENDO-RAMO EQUAL 77 */

            if (ENDO_RAMO == 77)
            {

                /*" -8138- IF ENDO-CODPRODU EQUAL 7704 */

                if (ENDO_CODPRODU == 7704)
                {

                    /*" -8140- IF ENDO-TIPO-ENDOSSO NOT EQUAL '4' AND ENDO-NRENDOS NOT EQUAL ZEROS */

                    if (ENDO_TIPO_ENDOSSO != "4" && ENDO_NRENDOS != 00)
                    {

                        /*" -8141- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                        if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                        {

                            /*" -8142- MOVE WS-EF-VLR-EMISSAO TO WS-VL-COB */
                            _.Move(WS_EF_VLR_EMISSAO, WS_VL_COB);

                            /*" -8143- ELSE */
                        }
                        else
                        {


                            /*" -8144- MOVE WS-EF-VLR-CREDITO TO WS-VL-COB */
                            _.Move(WS_EF_VLR_CREDITO, WS_VL_COB);

                            /*" -8146- END-IF */
                        }


                        /*" -8147- END-IF */
                    }


                    /*" -8148- END-IF */
                }


                /*" -8151- END-IF. */
            }


            /*" -8153- IF ENDO-RAMO EQUAL 14 AND (ENDO-CODPRODU EQUAL 1403 OR 1404) */

            if (ENDO_RAMO == 14 && (ENDO_CODPRODU.In("1403", "1404")))
            {

                /*" -8154- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -8155- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -8156- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8158- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -8163- IF (ENDO-RAMO EQUAL 16 AND (ENDO-CODPRODU EQUAL 1601 AND ENDO-COD-EMPRESA EQUAL 5495) OR (ENDO-CODPRODU EQUAL 1602 AND ENDO-COD-EMPRESA EQUAL 0)) */

            if ((ENDO_RAMO == 16 && (ENDO_CODPRODU == 1601 && ENDO_COD_EMPRESA == 5495) || (ENDO_CODPRODU == 1602 && ENDO_COD_EMPRESA == 0)))
            {

                /*" -8164- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -8165- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -8166- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8168- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -8175- IF (ENDO-RAMO EQUAL 18 AND (ENDO-CODPRODU EQUAL 1801 AND ENDO-COD-EMPRESA EQUAL 5495) OR (ENDO-CODPRODU EQUAL 1802 AND ENDO-COD-EMPRESA EQUAL 0) OR (ENDO-CODPRODU EQUAL 1804 AND ENDO-COD-EMPRESA EQUAL 0)) */

            if ((ENDO_RAMO == 18 && (ENDO_CODPRODU == 1801 && ENDO_COD_EMPRESA == 5495) || (ENDO_CODPRODU == 1802 && ENDO_COD_EMPRESA == 0) || (ENDO_CODPRODU == 1804 && ENDO_COD_EMPRESA == 0)))
            {

                /*" -8176- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

                if (ENDO_TIPO_ENDOSSO.In("0", "1"))
                {

                    /*" -8177- MOVE 'EM0015B1' TO V0EDIA-CODRELAT */
                    _.Move("EM0015B1", V0EDIA_CODRELAT);

                    /*" -8178- MOVE ZEROS TO V0EDIA-ORGAO */
                    _.Move(0, V0EDIA_ORGAO);

                    /*" -8180- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                    B4200_INCLUI_V0EMISDIARIA_SECTION();
                }

            }


            /*" -8182- MOVE 'EM0102B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0102B1", V0EDIA_CODRELAT);

            /*" -8184- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -8186- PERFORM B4100-LE-V1APOLCORRET. */

            B4100_LE_V1APOLCORRET_SECTION();

            /*" -8188- PERFORM B4200-INCLUI-V0EMISDIARIA. */

            B4200_INCLUI_V0EMISDIARIA_SECTION();

            /*" -8189- MOVE APOL-ORGAO TO V0EDIA-ORGAO. */
            _.Move(APOL_ORGAO, V0EDIA_ORGAO);

            /*" -8204- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -8205- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' */

            if (ENDO_TIPO_ENDOSSO != "0")
            {

                /*" -8207- IF APOL-RAMO EQUAL 31 OR 53 OR 81 OR 20 NEXT SENTENCE */

                if (APOL_RAMO.In("31", "53", "81", "20"))
                {

                    /*" -8208- ELSE */
                }
                else
                {


                    /*" -8209- IF ENDO-NUMBIL EQUAL ZEROS */

                    if (ENDO_NUMBIL == 00)
                    {

                        /*" -8217- IF ((ENDO-CODPRODU EQUAL 1403 OR 1404) OR ((ENDO-CODPRODU EQUAL 1601 OR 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR 1802 OR 1804) AND ENDO-COD-EMPRESA EQUAL 0) OR (ENDO-CODPRODU EQUAL 1803 OR 1805)) NEXT SENTENCE */

                        if (((ENDO_CODPRODU.In("1403", "1404")) || ((ENDO_CODPRODU.In("1601", "1801")) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU.In("1602", "1802", "1804")) && ENDO_COD_EMPRESA == 0) || (ENDO_CODPRODU.In("1803", "1805"))))
                        {

                            /*" -8218- ELSE */
                        }
                        else
                        {


                            /*" -8219- MOVE 'EM0200B1' TO V0EDIA-CODRELAT */
                            _.Move("EM0200B1", V0EDIA_CODRELAT);

                            /*" -8221- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();
                        }

                    }

                }

            }


            /*" -8222- IF ENDO-TIPO-ENDOSSO EQUAL '0' OR '1' */

            if (ENDO_TIPO_ENDOSSO.In("0", "1"))
            {

                /*" -8223- IF ENDO-NUMBIL EQUAL ZEROS */

                if (ENDO_NUMBIL == 00)
                {

                    /*" -8224- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL */
                    _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

                    /*" -8225- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS */
                    _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

                    /*" -8226- MOVE ZEROS TO V0EDIA-NRPARCEL */
                    _.Move(0, V0EDIA_NRPARCEL);

                    /*" -8227- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO */
                    _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

                    /*" -8228- MOVE APOL-ORGAO TO V0EDIA-ORGAO */
                    _.Move(APOL_ORGAO, V0EDIA_ORGAO);

                    /*" -8229- MOVE APOL-RAMO TO V0EDIA-RAMO */
                    _.Move(APOL_RAMO, V0EDIA_RAMO);

                    /*" -8230- MOVE ENDO-FONTE TO V0EDIA-FONTE */
                    _.Move(ENDO_FONTE, V0EDIA_FONTE);

                    /*" -8231- MOVE ZEROS TO V0EDIA-CONGENER */
                    _.Move(0, V0EDIA_CONGENER);

                    /*" -8232- PERFORM B4100-LE-V1APOLCORRET */

                    B4100_LE_V1APOLCORRET_SECTION();

                    /*" -8245- MOVE HIST-COD-EMPRESA TO V0EDIA-COD-EMP */
                    _.Move(HIST_COD_EMPRESA, V0EDIA_COD_EMP);

                    /*" -8247- IF PRCB-TIPO-COBRANCA EQUAL ' ' OR PRCB-TIPO-COBRANCA EQUAL '0' */

                    if (PRCB_TIPO_COBRANCA == " " || PRCB_TIPO_COBRANCA == "0")
                    {

                        /*" -8248- MOVE 'EM0230B1' TO V0EDIA-CODRELAT */
                        _.Move("EM0230B1", V0EDIA_CODRELAT);

                        /*" -8254- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                        B4200_INCLUI_V0EMISDIARIA_SECTION();
                    }

                }

            }


            /*" -8256- IF APOL-RAMO EQUAL 31 OR 53 OR 81 OR 20 NEXT SENTENCE */

            if (APOL_RAMO.In("31", "53", "81", "20"))
            {

                /*" -8257- ELSE */
            }
            else
            {


                /*" -8261- IF ENDO-CODPRODU GREATER ZEROS */

                if (ENDO_CODPRODU > 00)
                {

                    /*" -8262- IF ENDO-NUMBIL EQUAL ZEROS */

                    if (ENDO_NUMBIL == 00)
                    {

                        /*" -8270- IF ((ENDO-CODPRODU EQUAL 1403 OR 1404) OR ((ENDO-CODPRODU EQUAL 1601 OR 1801) AND ENDO-COD-EMPRESA EQUAL 5495) OR ((ENDO-CODPRODU EQUAL 1602 OR 1802 OR 1804) AND ENDO-COD-EMPRESA EQUAL 0) OR (ENDO-CODPRODU EQUAL 1803 OR 1805)) NEXT SENTENCE */

                        if (((ENDO_CODPRODU.In("1403", "1404")) || ((ENDO_CODPRODU.In("1601", "1801")) && ENDO_COD_EMPRESA == 5495) || ((ENDO_CODPRODU.In("1602", "1802", "1804")) && ENDO_COD_EMPRESA == 0) || (ENDO_CODPRODU.In("1803", "1805"))))
                        {

                            /*" -8271- ELSE */
                        }
                        else
                        {


                            /*" -8272- MOVE 'EM0200B1' TO V0EDIA-CODRELAT */
                            _.Move("EM0200B1", V0EDIA_CODRELAT);

                            /*" -8273- PERFORM B4200-INCLUI-V0EMISDIARIA */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();

                            /*" -8274- END-IF */
                        }


                        /*" -8275- ELSE */
                    }
                    else
                    {


                        /*" -8276- PERFORM B4201-00-V1PRODUTO */

                        B4201_00_V1PRODUTO_SECTION();

                        /*" -8277- IF V1PROD-IDEIMPESPC EQUAL 'S' */

                        if (V1PROD_IDEIMPESPC == "S")
                        {

                            /*" -8278- MOVE 'PE0220B1' TO V0EDIA-CODRELAT */
                            _.Move("PE0220B1", V0EDIA_CODRELAT);

                            /*" -8283- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                            B4200_INCLUI_V0EMISDIARIA_SECTION();
                        }

                    }

                }

            }


            /*" -8285- IF (ENDO-TIPO-ENDOSSO EQUAL '3' OR '5' ) AND ENDO-CODPRODU NOT EQUAL 1803 AND 1805 */

            if ((ENDO_TIPO_ENDOSSO.In("3", "5")) && !ENDO_CODPRODU.In("1803", "1805"))
            {

                /*" -8286- MOVE 'EM0202B1' TO V0EDIA-CODRELAT */
                _.Move("EM0202B1", V0EDIA_CODRELAT);

                /*" -8287- MOVE APOL-RAMO TO V0EDIA-RAMO */
                _.Move(APOL_RAMO, V0EDIA_RAMO);

                /*" -8289- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -8290- IF ENDO-TIPO-ENDOSSO EQUAL '5' */

            if (ENDO_TIPO_ENDOSSO == "5")
            {

                /*" -8291- MOVE 'EM0120B1' TO V0EDIA-CODRELAT */
                _.Move("EM0120B1", V0EDIA_CODRELAT);

                /*" -8293- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -8294- IF APOL-RAMO EQUAL 31 OR 53 OR 81 OR 20 */

            if (APOL_RAMO.In("31", "53", "81", "20"))
            {

                /*" -8295- MOVE 'EM0290B1' TO V0EDIA-CODRELAT */
                _.Move("EM0290B1", V0EDIA_CODRELAT);

                /*" -8297- PERFORM B4200-INCLUI-V0EMISDIARIA. */

                B4200_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -8301- IF APOL-RAMO EQUAL 40 OR APOL-RAMO EQUAL 67 OR APOL-RAMO EQUAL 45 OR APOL-RAMO EQUAL 75 */

            if (APOL_RAMO == 40 || APOL_RAMO == 67 || APOL_RAMO == 45 || APOL_RAMO == 75)
            {

                /*" -8302- MOVE 'EM0292B1' TO V0EDIA-CODRELAT */
                _.Move("EM0292B1", V0EDIA_CODRELAT);

                /*" -8304- PERFORM B4292-INCLUI-V0EMISDIARIA. */

                B4292_INCLUI_V0EMISDIARIA_SECTION();
            }


            /*" -8305- IF APOL-RAMO EQUAL 71 */

            if (APOL_RAMO == 71)
            {

                /*" -8306- IF VIND-CODPRODU NOT LESS ZEROS */

                if (VIND_CODPRODU >= 00)
                {

                    /*" -8307- IF ENDO-CODPRODU EQUAL 7114 */

                    if (ENDO_CODPRODU == 7114)
                    {

                        /*" -8308- MOVE 'EM0292B1' TO V0EDIA-CODRELAT */
                        _.Move("EM0292B1", V0EDIA_CODRELAT);

                        /*" -8310- PERFORM B4292-INCLUI-V0EMISDIARIA. */

                        B4292_INCLUI_V0EMISDIARIA_SECTION();
                    }

                }

            }


            /*" -8311- IF ENDO-RAMO EQUAL 14 OR 18 OR 71 OR 31 OR 53 */

            if (ENDO_RAMO.In("14", "18", "71", "31", "53"))
            {

                /*" -8312- IF ENDO-DATPRO > ENDO-DTINIVIG */

                if (ENDO_DATPRO > ENDO_DTINIVIG)
                {

                    /*" -8313- MOVE ENDO-DTINIVIG TO ENDO-DATPRO */
                    _.Move(ENDO_DTINIVIG, ENDO_DATPRO);

                    /*" -8314- PERFORM B4295-00-UPDATE-DATAPROP */

                    B4295_00_UPDATE_DATAPROP_SECTION();

                    /*" -8315- END-IF */
                }


                /*" -8315- END-IF. */
            }


        }

        [StopWatch]
        /*" B4000-ATUALIZA-ENDOSSO-DB-UPDATE-1 */
        public void B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1()
        {
            /*" -7919- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = :WSITUACAO ,DTEMIS = :SIST-DTMOVABE ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

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
            /*" -8326- MOVE 'B4050' TO WNR-EXEC-SQL. */
            _.Move("B4050", WABEND.WNR_EXEC_SQL);

            /*" -8327- PERFORM B4055-00-VALIDA-TITULO-CAP */

            B4055_00_VALIDA_TITULO_CAP_SECTION();

            /*" -8328- IF WS-ERRO > 0 */

            if (WS_ERRO > 0)
            {

                /*" -8329- GO TO B4050-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4050_999_EXIT*/ //GOTO
                return;

                /*" -8331- END-IF */
            }


            /*" -8333- INITIALIZE LT3164S-AREA-PARAMETROS */
            _.Initialize(
                LBLT3164.LT3164S_AREA_PARAMETROS
            );

            /*" -8334- MOVE ENDO-CODPRODU TO LT3164S-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PRODUTO);

            /*" -8336- MOVE LTMVPROP-COD-EXT-SEGURADO TO LT3164S-COD-CLIENTE */
            _.Move(LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_CLIENTE);

            /*" -8337- MOVE ENDO-NUM-APOLICE TO LT3164S-NUM-APOLICE */
            _.Move(ENDO_NUM_APOLICE, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_NUM_APOLICE);

            /*" -8338- MOVE 'LT2006B1' TO LT3164S-COD-PROGRAMA */
            _.Move("LT2006B1", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PROGRAMA);

            /*" -8339- MOVE '0' TO LT3164S-TIPO-SOLICITACAO */
            _.Move("0", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_TIPO_SOLICITACAO);

            /*" -8340- MOVE 'EM0010B' TO LT3164S-COD-USUARIO */
            _.Move("EM0010B", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_USUARIO);

            /*" -8341- MOVE '0' TO LT3164S-SIT-SOLICITACAO */
            _.Move("0", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_SIT_SOLICITACAO);

            /*" -8342- MOVE ENDO-DTINIVIG TO LT3164S-PARAM-DATE01 */
            _.Move(ENDO_DTINIVIG, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE01);

            /*" -8343- MOVE ENDO-DTTERVIG TO LT3164S-PARAM-DATE02 */
            _.Move(ENDO_DTTERVIG, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE02);

            /*" -8344- MOVE SIST-DTMOVABE TO LT3164S-PARAM-DATE03 */
            _.Move(SIST_DTMOVABE, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_DATE03);

            /*" -8345- MOVE 0 TO LT3164S-PARAM-SMINT01 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT01);

            /*" -8346- MOVE 0 TO LT3164S-PARAM-SMINT02 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT02);

            /*" -8347- MOVE 0 TO LT3164S-PARAM-SMINT03 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_SMINT03);

            /*" -8348- MOVE 0 TO LT3164S-PARAM-INTG01 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG01);

            /*" -8349- MOVE 0 TO LT3164S-PARAM-INTG02 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG02);

            /*" -8350- MOVE 0 TO LT3164S-PARAM-INTG03 */
            _.Move(0, LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_INTG03);

            /*" -8351- MOVE ' ' TO LT3164S-PARAM-CHAR01 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR01);

            /*" -8352- MOVE ' ' TO LT3164S-PARAM-CHAR02 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR02);

            /*" -8353- MOVE ' ' TO LT3164S-PARAM-CHAR03 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR03);

            /*" -8354- MOVE ' ' TO LT3164S-PARAM-CHAR04 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR04);

            /*" -8356- MOVE ' ' TO LT3164S-PARAM-CHAR05 */
            _.Move(" ", LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_PARAM_CHAR05);

            /*" -8358- CALL 'LT3164S' USING LT3164S-AREA-PARAMETROS. */
            _.Call("LT3164S", LBLT3164.LT3164S_AREA_PARAMETROS);

            /*" -8359- IF LT3164S-COD-RETORNO NOT EQUAL ZEROS */

            if (LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO != 00)
            {

                /*" -8364- DISPLAY 'B4050 - ERRO RETORNO LT3164S' ' APOL:' LT3164S-NUM-APOLICE ' PROD:' LT3164S-COD-PRODUTO ' COD-ERRO:' LT3164S-COD-RETORNO ' MSG-ERRO:' LT3164S-MSG-RETORNO */

                $"B4050 - ERRO RETORNO LT3164S APOL:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_NUM_APOLICE} PROD:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_PRODUTO} COD-ERRO:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_COD_RETORNO} MSG-ERRO:{LBLT3164.LT3164S_AREA_PARAMETROS.LT3164S_MSG_RETORNO}"
                .Display();

                /*" -8365- ELSE */
            }
            else
            {


                /*" -8371- ADD 1 TO AC-I-TITCAP-LOT */
                AC_I_TITCAP_LOT.Value = AC_I_TITCAP_LOT + 1;

                /*" -8371- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B4050_999_EXIT*/

        [StopWatch]
        /*" B4055-00-VALIDA-TITULO-CAP-SECTION */
        private void B4055_00_VALIDA_TITULO_CAP_SECTION()
        {
            /*" -8382- MOVE 'B4055' TO WNR-EXEC-SQL. */
            _.Move("B4055", WABEND.WNR_EXEC_SQL);

            /*" -8383- MOVE 0 TO WS-ERRO */
            _.Move(0, WS_ERRO);

            /*" -8384- MOVE 'SPBLTPRM' TO LTSOLPAR-COD-PROGRAMA */
            _.Move("SPBLTPRM", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA);

            /*" -8385- MOVE '0' TO LTSOLPAR-SIT-SOLICITACAO */
            _.Move("0", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO);

            /*" -8386- MOVE ENDO-CODPRODU TO LTSOLPAR-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO);

            /*" -8387- MOVE 87 TO LTSOLPAR-PARAM-SMINT01 */
            _.Move(87, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01);

            /*" -8388- MOVE SIST-DTMOVABE TO LTSOLPAR-PARAM-DATE01 */
            _.Move(SIST_DTMOVABE, LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01);

            /*" -8390- MOVE SPACES TO LTSOLPAR-PARAM-DATE03 */
            _.Move("", LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03);

            /*" -8400- PERFORM B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1 */

            B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1();

            /*" -8405- IF (SQLCODE NOT EQUAL ZEROS ) OR (LTSOLPAR-PARAM-DATE03 EQUAL SPACES ) OR (LTSOLPAR-PARAM-DATE03 < '1999-01-01' ) */

            if ((DB.SQLCODE != 00) || (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.IsEmpty()) || (LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03 < "1999-01-01"))
            {

                /*" -8413- DISPLAY 'B4055-ERRO ' ' SQLCODE:' SQLCODE ' PROG:' LTSOLPAR-COD-PROGRAMA ' PROD:' LTSOLPAR-COD-PRODUTO ' SMINT01:' LTSOLPAR-PARAM-SMINT01 ' DATE01:' LTSOLPAR-PARAM-DATE01 ' APOL:' ENDO-NUM-APOLICE ' PARAM DT COMPRA CAP NAO ENCONTRADO' */

                $"B4055-ERRO  SQLCODE:{DB.SQLCODE} PROG:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA} PROD:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO} SMINT01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01} DATE01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01} APOL:{ENDO_NUM_APOLICE} PARAM DT COMPRA CAP NAO ENCONTRADO"
                .Display();

                /*" -8414- MOVE 1 TO WS-ERRO */
                _.Move(1, WS_ERRO);

                /*" -8415- GO TO B4055-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4055_999_EXIT*/ //GOTO
                return;

                /*" -8417- END-IF */
            }


            /*" -8425- DISPLAY 'B4055-' ' PROG:' LTSOLPAR-COD-PROGRAMA ' PROD:' LTSOLPAR-COD-PRODUTO ' SMINT01:' LTSOLPAR-PARAM-SMINT01 ' DATE01:' LTSOLPAR-PARAM-DATE01 ' APOL:' ENDO-NUM-APOLICE ' TIT CAP SOLICITACAO COM SUCESSO' */

            $"B4055- PROG:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA} PROD:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO} SMINT01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01} DATE01:{LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01} APOL:{ENDO_NUM_APOLICE} TIT CAP SOLICITACAO COM SUCESSO"
            .Display();

            /*" -8425- . */

        }

        [StopWatch]
        /*" B4055-00-VALIDA-TITULO-CAP-DB-SELECT-1 */
        public void B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1()
        {
            /*" -8400- EXEC SQL SELECT PARAM_DATE03 INTO :LTSOLPAR-PARAM-DATE03 FROM SEGUROS.LT_SOLICITA_PARAM WHERE COD_PROGRAMA = :LTSOLPAR-COD-PROGRAMA AND SIT_SOLICITACAO = '0' AND PARAM_SMINT01 = :LTSOLPAR-PARAM-SMINT01 AND :LTSOLPAR-PARAM-DATE01 BETWEEN PARAM_DATE01 AND PARAM_DATE02 AND COD_PRODUTO = :LTSOLPAR-COD-PRODUTO END-EXEC. */

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
            /*" -8434- MOVE 'B4100' TO WNR-EXEC-SQL. */
            _.Move("B4100", WABEND.WNR_EXEC_SQL);

            /*" -8435- IF ENDO-TIPO-ENDOSSO NOT EQUAL '0' */

            if (ENDO_TIPO_ENDOSSO != "0")
            {

                /*" -8435- GO TO B4102-SELECT-ENDOSSO. */

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
            /*" -8441- MOVE 'B4101' TO WNR-EXEC-SQL. */
            _.Move("B4101", WABEND.WNR_EXEC_SQL);

            /*" -8453- PERFORM B4101_SELECT_APOLICE_DB_SELECT_1 */

            B4101_SELECT_APOLICE_DB_SELECT_1();

            /*" -8456- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -8457- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8458- MOVE ZEROS TO V0EDIA-CODCORR */
                    _.Move(0, V0EDIA_CODCORR);

                    /*" -8462- ELSE */
                }
                else
                {


                    /*" -8464- DISPLAY 'B4101-PROBLEMAS NO CORRETOR DA APOLICE ' ENDO-NUM-APOLICE */
                    _.Display($"B4101-PROBLEMAS NO CORRETOR DA APOLICE {ENDO_NUM_APOLICE}");

                    /*" -8466- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -8466- GO TO B4100-999-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: B4100_999_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" B4101-SELECT-APOLICE-DB-SELECT-1 */
        public void B4101_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -8453- EXEC SQL SELECT DISTINCT(CODCORR) INTO :V0EDIA-CODCORR FROM SEGUROS.V1APOLCORRET WHERE INDCRT = '1' AND TIPCOM = '1' AND NUM_APOLICE = :ENDO-NUM-APOLICE AND CODSUBES = :ENDO-CODSUBES AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG ORDER BY CODCORR WITH UR END-EXEC. */

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
            /*" -8472- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -8474- MOVE 'B4102' TO WNR-EXEC-SQL. */
            _.Move("B4102", WABEND.WNR_EXEC_SQL);

            /*" -8485- PERFORM B4102_SELECT_ENDOSSO_DB_SELECT_1 */

            B4102_SELECT_ENDOSSO_DB_SELECT_1();

            /*" -8488- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -8489- MOVE ZEROS TO V0EDIA-CODCORR */
                _.Move(0, V0EDIA_CODCORR);

                /*" -8492- DISPLAY 'B4102-PROBLEMAS NO CORRETOR DA APOLICE ' ENDO-NUM-APOLICE '  DESPREZADO' */

                $"B4102-PROBLEMAS NO CORRETOR DA APOLICE {ENDO_NUM_APOLICE}  DESPREZADO"
                .Display();

                /*" -8494- GO TO B4100-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4100_999_EXIT*/ //GOTO
                return;
            }


            /*" -8495- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -8501- IF (ENDO-RAMO NOT EQUAL PARM-RAMO-VG AND PARM-RAMO-AP AND PARM-RAMO-PRESTA) OR (SUB-OPC-CORRETAGEM NOT EQUAL '2' ) */

                if ((!ENDO_RAMO.In(PARM_RAMO_VG.ToString(), PARM_RAMO_AP.ToString(), PARM_RAMO_PRESTA.ToString())) || (SUB_OPC_CORRETAGEM != "2"))
                {

                    /*" -8503- DISPLAY 'B4102-PROBLEMAS NO CORRETOR DA APOLICE ' ENDO-NUM-APOLICE */
                    _.Display($"B4102-PROBLEMAS NO CORRETOR DA APOLICE {ENDO_NUM_APOLICE}");

                    /*" -8503- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B4102-SELECT-ENDOSSO-DB-SELECT-1 */
        public void B4102_SELECT_ENDOSSO_DB_SELECT_1()
        {
            /*" -8485- EXEC SQL SELECT DISTINCT(CODCORR) INTO :V0EDIA-CODCORR FROM SEGUROS.V1APOLCORRET WHERE INDCRT = '1' AND TIPCOM = '1' AND CODSUBES = :ENDO-CODSUBES AND NUM_APOLICE = :ENDO-NUM-APOLICE AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG ORDER BY CODCORR WITH UR END-EXEC. */

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
            /*" -8513- MOVE 'B4200' TO WNR-EXEC-SQL. */
            _.Move("B4200", WABEND.WNR_EXEC_SQL);

            /*" -8514- MOVE '0' TO V0EDIA-SITUACAO. */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -8520- IF V0EDIA-CODRELAT NOT EQUAL ( 'EM0201B1' AND 'EM0202B1' AND 'EM0120B1' AND 'EM0230B1' AND 'EM0015B1' AND 'AU0050B1' ) */

            if (!V0EDIA_CODRELAT.In("EM0201B1", "EM0202B1", "EM0120B1", "EM0230B1", "EM0015B1", "AU0050B1"))
            {

                /*" -8521- IF VIND-CODPRODU NOT LESS ZEROS */

                if (VIND_CODPRODU >= 00)
                {

                    /*" -8522- IF ENDO-CODPRODU EQUAL 3101 OR 3102 OR 3105 */

                    if (ENDO_CODPRODU.In("3101", "3102", "3105"))
                    {

                        /*" -8535- MOVE '1' TO V0EDIA-SITUACAO. */
                        _.Move("1", V0EDIA_SITUACAO);
                    }

                }

            }


            /*" -8537- IF V0EDIA-CODRELAT EQUAL 'EM0200B1' OR 'EM0220B1' */

            if (V0EDIA_CODRELAT.In("EM0200B1", "EM0220B1"))
            {

                /*" -8538- IF VIND-CODPRODU NOT LESS ZEROS */

                if (VIND_CODPRODU >= 00)
                {

                    /*" -8539- IF ENDO-CODPRODU EQUAL 1803 OR 1805 */

                    if (ENDO_CODPRODU.In("1803", "1805"))
                    {

                        /*" -8543- MOVE '1' TO V0EDIA-SITUACAO . */
                        _.Move("1", V0EDIA_SITUACAO);
                    }

                }

            }


            /*" -8558- PERFORM B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -8561- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -8562- DISPLAY 'B4200-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B4200-00 (REGISTRO DUPLICADO) ... ");

                /*" -8564- GO TO B4200-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4200_999_EXIT*/ //GOTO
                return;
            }


            /*" -8565- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8566- DISPLAY 'B4200-00 (PROBLEMAS NA INSERCAO) -------------' */
                _.Display($"B4200-00 (PROBLEMAS NA INSERCAO) -------------");

                /*" -8567- DISPLAY 'V0EDIA-CODRELAT = ' V0EDIA-CODRELAT */
                _.Display($"V0EDIA-CODRELAT = {V0EDIA_CODRELAT}");

                /*" -8568- DISPLAY 'V0EDIA-NUM-APOL = ' V0EDIA-NUM-APOL */
                _.Display($"V0EDIA-NUM-APOL = {V0EDIA_NUM_APOL}");

                /*" -8569- DISPLAY 'V0EDIA-NRENDOS  = ' V0EDIA-NRENDOS */
                _.Display($"V0EDIA-NRENDOS  = {V0EDIA_NRENDOS}");

                /*" -8570- DISPLAY 'V0EDIA-NRPARCEL = ' V0EDIA-NRPARCEL */
                _.Display($"V0EDIA-NRPARCEL = {V0EDIA_NRPARCEL}");

                /*" -8571- DISPLAY 'V0EDIA-DTMOVTO  = ' V0EDIA-DTMOVTO */
                _.Display($"V0EDIA-DTMOVTO  = {V0EDIA_DTMOVTO}");

                /*" -8572- DISPLAY 'V0EDIA-ORGAO    = ' V0EDIA-ORGAO */
                _.Display($"V0EDIA-ORGAO    = {V0EDIA_ORGAO}");

                /*" -8573- DISPLAY 'V0EDIA-RAMO     = ' V0EDIA-RAMO */
                _.Display($"V0EDIA-RAMO     = {V0EDIA_RAMO}");

                /*" -8574- DISPLAY 'V0EDIA-FONTE    = ' V0EDIA-FONTE */
                _.Display($"V0EDIA-FONTE    = {V0EDIA_FONTE}");

                /*" -8575- DISPLAY 'V0EDIA-CONGENER = ' V0EDIA-CONGENER */
                _.Display($"V0EDIA-CONGENER = {V0EDIA_CONGENER}");

                /*" -8576- DISPLAY 'V0EDIA-CODCORR  = ' V0EDIA-CODCORR */
                _.Display($"V0EDIA-CODCORR  = {V0EDIA_CODCORR}");

                /*" -8577- DISPLAY 'V0EDIA-SITUACAO = ' V0EDIA-SITUACAO */
                _.Display($"V0EDIA-SITUACAO = {V0EDIA_SITUACAO}");

                /*" -8578- DISPLAY 'V0EDIA-COD-EMP  = ' V0EDIA-COD-EMP */
                _.Display($"V0EDIA-COD-EMP  = {V0EDIA_COD_EMP}");

                /*" -8579- DISPLAY '----------------------------------------------' */
                _.Display($"----------------------------------------------");

                /*" -8581- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8581- ADD 1 TO AC-I-V0EMISDIARIA. */
            AC_I_V0EMISDIARIA.Value = AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" B4200-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -8558- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -8594- MOVE 'B4201' TO WNR-EXEC-SQL. */
            _.Move("B4201", WABEND.WNR_EXEC_SQL);

            /*" -8604- PERFORM B4201_00_V1PRODUTO_DB_SELECT_1 */

            B4201_00_V1PRODUTO_DB_SELECT_1();

            /*" -8608- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8609- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -8610- MOVE 'N' TO V1PROD-IDEIMPESPC */
                    _.Move("N", V1PROD_IDEIMPESPC);

                    /*" -8611- ELSE */
                }
                else
                {


                    /*" -8612- DISPLAY 'B4201-00 (PROBLEMAS NO SELECT DA VIPRODUTOR)..' */
                    _.Display($"B4201-00 (PROBLEMAS NO SELECT DA VIPRODUTOR)..");

                    /*" -8612- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" B4201-00-V1PRODUTO-DB-SELECT-1 */
        public void B4201_00_V1PRODUTO_DB_SELECT_1()
        {
            /*" -8604- EXEC SQL SELECT VALUE(IDEIMPESPC, 'N' ) INTO :V1PROD-IDEIMPESPC FROM SEGUROS.V1PRODUTO WHERE CODPRODU = :ENDO-CODPRODU WITH UR END-EXEC. */

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
            /*" -8624- MOVE 'B4210' TO WNR-EXEC-SQL. */
            _.Move("B4210", WABEND.WNR_EXEC_SQL);

            /*" -8625- MOVE 'EM0010B' TO V0RELA-CODUSU */
            _.Move("EM0010B", V0RELA_CODUSU);

            /*" -8626- MOVE SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -8627- MOVE 'AU' TO V0RELA-IDSISTEM */
            _.Move("AU", V0RELA_IDSISTEM);

            /*" -8628- MOVE 'AU0010B1' TO V0RELA-CODRELAT */
            _.Move("AU0010B1", V0RELA_CODRELAT);

            /*" -8629- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -8630- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -8631- MOVE SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -8632- MOVE SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -8633- MOVE SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -8634- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -8635- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -8636- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -8637- MOVE ENDO-FONTE TO V0RELA-FONTE */
            _.Move(ENDO_FONTE, V0RELA_FONTE);

            /*" -8638- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -8639- MOVE 31 TO V0RELA-RAMO */
            _.Move(31, V0RELA_RAMO);

            /*" -8640- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -8641- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -8642- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -8643- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -8644- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -8645- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -8646- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -8647- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -8648- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -8649- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -8650- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -8651- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -8652- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -8653- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -8654- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -8655- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -8656- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -8657- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -8658- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -8659- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -8660- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -8661- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -8662- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -8663- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -8665- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -8708- PERFORM B4210_00_INCLUI_RELATORIO_DB_INSERT_1 */

            B4210_00_INCLUI_RELATORIO_DB_INSERT_1();

            /*" -8711- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -8712- DISPLAY 'B4210-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B4210-00 (REGISTRO DUPLICADO) ... ");

                /*" -8714- GO TO B4210-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4210_999_EXIT*/ //GOTO
                return;
            }


            /*" -8715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8716- DISPLAY 'B4210-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"B4210-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -8718- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8718- ADD 1 TO AC-I-V0RELATORIO. */
            AC_I_V0RELATORIO.Value = AC_I_V0RELATORIO + 1;

        }

        [StopWatch]
        /*" B4210-00-INCLUI-RELATORIO-DB-INSERT-1 */
        public void B4210_00_INCLUI_RELATORIO_DB_INSERT_1()
        {
            /*" -8708- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -8729- MOVE 'B4292' TO WNR-EXEC-SQL. */
            _.Move("B4292", WABEND.WNR_EXEC_SQL);

            /*" -8730- MOVE '0' TO V0EDIA-SITUACAO. */
            _.Move("0", V0EDIA_SITUACAO);

            /*" -8731- MOVE ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -8732- MOVE ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -8733- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -8734- MOVE SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -8735- MOVE APOL-ORGAO TO V0EDIA-ORGAO. */
            _.Move(APOL_ORGAO, V0EDIA_ORGAO);

            /*" -8736- MOVE APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(APOL_RAMO, V0EDIA_RAMO);

            /*" -8737- MOVE ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(ENDO_FONTE, V0EDIA_FONTE);

            /*" -8738- MOVE ZEROS TO V0EDIA-CONGENER. */
            _.Move(0, V0EDIA_CONGENER);

            /*" -8739- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -8741- MOVE HIST-COD-EMPRESA TO V0EDIA-COD-EMP. */
            _.Move(HIST_COD_EMPRESA, V0EDIA_COD_EMP);

            /*" -8756- PERFORM B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -8759- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -8760- DISPLAY 'B4292-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B4292-00 (REGISTRO DUPLICADO) ... ");

                /*" -8762- GO TO B4292-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B4292_999_EXIT*/ //GOTO
                return;
            }


            /*" -8763- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8764- DISPLAY 'B4292-00 (PROBLEMAS NA INSERCAO) ------------' */
                _.Display($"B4292-00 (PROBLEMAS NA INSERCAO) ------------");

                /*" -8765- DISPLAY 'V0EDIA-CODRELAT = ' V0EDIA-CODRELAT */
                _.Display($"V0EDIA-CODRELAT = {V0EDIA_CODRELAT}");

                /*" -8766- DISPLAY 'V0EDIA-NUM-APOL = ' V0EDIA-NUM-APOL */
                _.Display($"V0EDIA-NUM-APOL = {V0EDIA_NUM_APOL}");

                /*" -8767- DISPLAY 'V0EDIA-NRENDOS  = ' V0EDIA-NRENDOS */
                _.Display($"V0EDIA-NRENDOS  = {V0EDIA_NRENDOS}");

                /*" -8768- DISPLAY 'V0EDIA-NRPARCEL = ' V0EDIA-NRPARCEL */
                _.Display($"V0EDIA-NRPARCEL = {V0EDIA_NRPARCEL}");

                /*" -8769- DISPLAY 'V0EDIA-DTMOVTO  = ' V0EDIA-DTMOVTO */
                _.Display($"V0EDIA-DTMOVTO  = {V0EDIA_DTMOVTO}");

                /*" -8770- DISPLAY 'V0EDIA-ORGAO    = ' V0EDIA-ORGAO */
                _.Display($"V0EDIA-ORGAO    = {V0EDIA_ORGAO}");

                /*" -8771- DISPLAY 'V0EDIA-RAMO     = ' V0EDIA-RAMO */
                _.Display($"V0EDIA-RAMO     = {V0EDIA_RAMO}");

                /*" -8772- DISPLAY 'V0EDIA-FONTE    = ' V0EDIA-FONTE */
                _.Display($"V0EDIA-FONTE    = {V0EDIA_FONTE}");

                /*" -8773- DISPLAY 'V0EDIA-CONGENER = ' V0EDIA-CONGENER */
                _.Display($"V0EDIA-CONGENER = {V0EDIA_CONGENER}");

                /*" -8774- DISPLAY 'V0EDIA-CODCORR  = ' V0EDIA-CODCORR */
                _.Display($"V0EDIA-CODCORR  = {V0EDIA_CODCORR}");

                /*" -8775- DISPLAY 'V0EDIA-SITUACAO = ' V0EDIA-SITUACAO */
                _.Display($"V0EDIA-SITUACAO = {V0EDIA_SITUACAO}");

                /*" -8776- DISPLAY 'V0EDIA-COD-EMP  = ' V0EDIA-COD-EMP */
                _.Display($"V0EDIA-COD-EMP  = {V0EDIA_COD_EMP}");

                /*" -8777- DISPLAY '---------------------------------------------' */
                _.Display($"---------------------------------------------");

                /*" -8779- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8779- ADD 1 TO AC-I-V0EMISDIARIA. */
            AC_I_V0EMISDIARIA.Value = AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" B4292-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -8756- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , :V0EDIA-COD-EMP , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -8790- PERFORM B4295_00_UPDATE_DATAPROP_DB_UPDATE_1 */

            B4295_00_UPDATE_DATAPROP_DB_UPDATE_1();

            /*" -8793- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8797- DISPLAY 'B4295-00  ERRO UPDATE V0ENDOSSO' ' APOL=' ENDO-NUM-APOLICE ' ENDO=' ENDO-NRENDOS ' DATA=' ENDO-DATPRO */

                $"B4295-00  ERRO UPDATE V0ENDOSSO APOL={ENDO_NUM_APOLICE} ENDO={ENDO_NRENDOS} DATA={ENDO_DATPRO}"
                .Display();

                /*" -8798- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -8798- END-IF. */
            }


        }

        [StopWatch]
        /*" B4295-00-UPDATE-DATAPROP-DB-UPDATE-1 */
        public void B4295_00_UPDATE_DATAPROP_DB_UPDATE_1()
        {
            /*" -8790- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET DATPRO = :ENDO-DATPRO WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

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
            /*" -8815- MOVE 'R0320' TO WNR-EXEC-SQL. */
            _.Move("R0320", WABEND.WNR_EXEC_SQL);

            /*" -8833- PERFORM R0320_00_SELECT_V0CEDENTE_DB_SELECT_1 */

            R0320_00_SELECT_V0CEDENTE_DB_SELECT_1();

            /*" -8836- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8837- MOVE ZEROS TO CEDENTE-COD-CEDENTE */
                _.Move(0, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);

                /*" -8838- ELSE */
            }
            else
            {


                /*" -8839- IF CEDENTE-OPERACAO-CONTA NOT EQUAL 870 */

                if (CEDENTE.DCLCEDENTE.CEDENTE_OPERACAO_CONTA != 870)
                {

                    /*" -8842- MOVE ZEROS TO CEDENTE-COD-CEDENTE. */
                    _.Move(0, CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE);
                }

            }


            /*" -8843- IF CEDENTE-COD-CEDENTE EQUAL ZEROS */

            if (CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE == 00)
            {

                /*" -8844- DISPLAY 'CEDENTE DEMAIS PARCELAS NAO CADASTRADO ' */
                _.Display($"CEDENTE DEMAIS PARCELAS NAO CADASTRADO ");

                /*" -8846- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -8848- MOVE CEDENTE-NUM-TITULO TO WSHOST-NRTIT13. */
            _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WSHOST_NRTIT13);

            /*" -8849- DISPLAY 'LEITURA CEDENTE: ' CEDENTE-COD-CEDENTE ' TITULO ' CEDENTE-NUM-TITULO. */

            $"LEITURA CEDENTE: {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE} TITULO {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}"
            .Display();

        }

        [StopWatch]
        /*" R0320-00-SELECT-V0CEDENTE-DB-SELECT-1 */
        public void R0320_00_SELECT_V0CEDENTE_DB_SELECT_1()
        {
            /*" -8833- EXEC SQL SELECT COD_CEDENTE ,OPERACAO_CONTA ,NUM_TITULO INTO :CEDENTE-COD-CEDENTE ,:CEDENTE-OPERACAO-CONTA ,:CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = :CEDENTE-COD-CEDENTE WITH UR END-EXEC. */

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
            /*" -8859- MOVE ENDO-CODPRODU TO AU080-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO);

            /*" -8861- MOVE AUTA-TIPO-COBRANCA TO AU080-IND-FORMA-PGTO */
            _.Move(AUTA_TIPO_COBRANCA, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO);

            /*" -8862- IF ENDO-QTPARCEL EQUAL ZEROS */

            if (ENDO_QTPARCEL == 00)
            {

                /*" -8863- MOVE 1 TO AU080-QTD-PARCELA */
                _.Move(1, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA);

                /*" -8864- ELSE */
            }
            else
            {


                /*" -8866- MOVE ENDO-QTPARCEL TO AU080-QTD-PARCELA. */
                _.Move(ENDO_QTPARCEL, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA);
            }


            /*" -8868- MOVE ENDO-DTINIVIG TO AU080-DTA-INI-VIGENCIA */
            _.Move(ENDO_DTINIVIG, AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA);

            /*" -8869- PERFORM R1110-00-RECUPERA-AU080 */

            R1110_00_RECUPERA_AU080_SECTION();

            /*" -8871- MOVE AU080-COD-PRODUTO TO AU077-COD-PRODUTO */
            _.Move(AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO, AU077.DCLAU_PROD_COBERTURA.AU077_COD_PRODUTO);

            /*" -8874- MOVE AU080-DTA-INI-VIGENCIA TO AU077-DTA-INI-VIGENCIA */
            _.Move(AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA, AU077.DCLAU_PROD_COBERTURA.AU077_DTA_INI_VIGENCIA);

            /*" -8875- PERFORM R1120-00-RECUPERA-AU077 */

            R1120_00_RECUPERA_AU077_SECTION();

            /*" -8877- MOVE AU077-VLR-PREMIO-TOTAL TO VL-PREMIO-BASE */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_TOTAL, EM0901W099.VL_PREMIO_BASE);

            /*" -8880- MOVE AU077-VLR-PREMIO-LIQUIDO TO VL-TARIFARIO-IX. */
            _.Move(AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_LIQUIDO, EM0901W099.VL_TARIFARIO_IX);

            /*" -8886- COMPUTE WS-PCT-IOF = AU077-VLR-IOF / (AU077-VLR-PREMIO-LIQUIDO + AU077-VLR-CUSTO) + 0,000005. */
            WS_PCT_IOF.Value = AU077.DCLAU_PROD_COBERTURA.AU077_VLR_IOF / (AU077.DCLAU_PROD_COBERTURA.AU077_VLR_PREMIO_LIQUIDO + AU077.DCLAU_PROD_COBERTURA.AU077_VLR_CUSTO) + 0.000005;

            /*" -8886- MOVE WS-PCT-IOF TO VL-IOF-IX. */
            _.Move(WS_PCT_IOF, EM0901W099.VL_IOF_IX);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-RECUPERA-AU080-SECTION */
        private void R1110_00_RECUPERA_AU080_SECTION()
        {
            /*" -8899- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", WABEND.WNR_EXEC_SQL);

            /*" -8911- PERFORM R1110_00_RECUPERA_AU080_DB_SELECT_1 */

            R1110_00_RECUPERA_AU080_DB_SELECT_1();

            /*" -8914- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8919- DISPLAY 'R1110-00 (PROBLEMAS SELECT AU_PARAM_PLANO)' ' ' AU080-COD-PRODUTO ' ' AU080-IND-FORMA-PGTO ' ' AU080-QTD-PARCELA ' ' AU080-DTA-INI-VIGENCIA */

                $"R1110-00 (PROBLEMAS SELECT AU_PARAM_PLANO) {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_COD_PRODUTO} {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_IND_FORMA_PGTO} {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_QTD_PARCELA} {AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA}"
                .Display();

                /*" -8919- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1110-00-RECUPERA-AU080-DB-SELECT-1 */
        public void R1110_00_RECUPERA_AU080_DB_SELECT_1()
        {
            /*" -8911- EXEC SQL SELECT PCT_TOTAL_ENCARGO INTO :AU080-PCT-TOTAL-ENCARGO FROM SEGUROS.AU_PARAM_PLANO_PRDTO WHERE COD_PRODUTO = :AU080-COD-PRODUTO AND IND_FORMA_PGTO = :AU080-IND-FORMA-PGTO AND QTD_PARCELA = :AU080-QTD-PARCELA AND DTA_INI_VIGENCIA <= :AU080-DTA-INI-VIGENCIA AND DTA_FIM_VIGENCIA >= :AU080-DTA-INI-VIGENCIA WITH UR END-EXEC. */

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
            /*" -8932- MOVE 'R1120' TO WNR-EXEC-SQL. */
            _.Move("R1120", WABEND.WNR_EXEC_SQL);

            /*" -8948- PERFORM R1120_00_RECUPERA_AU077_DB_SELECT_1 */

            R1120_00_RECUPERA_AU077_DB_SELECT_1();

            /*" -8951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8954- DISPLAY 'R1110-00 (PROBLEMAS SELECT AU_PROD_COBERTURA)' ' ' AU077-COD-PRODUTO ' ' AU077-DTA-INI-VIGENCIA */

                $"R1110-00 (PROBLEMAS SELECT AU_PROD_COBERTURA) {AU077.DCLAU_PROD_COBERTURA.AU077_COD_PRODUTO} {AU077.DCLAU_PROD_COBERTURA.AU077_DTA_INI_VIGENCIA}"
                .Display();

                /*" -8954- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-RECUPERA-AU077-DB-SELECT-1 */
        public void R1120_00_RECUPERA_AU077_DB_SELECT_1()
        {
            /*" -8948- EXEC SQL SELECT VALUE(SUM(VLR_PREMIO_LIQUIDO), 0), VALUE(SUM(VLR_CUSTO), 0), VALUE(SUM(VLR_IOF), 0), VALUE(SUM(VLR_PREMIO_TOTAL), 0) INTO :AU077-VLR-PREMIO-LIQUIDO, :AU077-VLR-CUSTO , :AU077-VLR-IOF , :AU077-VLR-PREMIO-TOTAL FROM SEGUROS.AU_PROD_COBERTURA WHERE COD_PRODUTO = :AU077-COD-PRODUTO AND DTA_INI_VIGENCIA <= :AU077-DTA-INI-VIGENCIA AND DTA_FIM_VIGENCIA >= :AU077-DTA-INI-VIGENCIA END-EXEC. */

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
            /*" -8965- MOVE 'R2060' TO WNR-EXEC-SQL. */
            _.Move("R2060", WABEND.WNR_EXEC_SQL);

            /*" -8968- DISPLAY 'ALTERANDO .CEDENTE: ' CEDENTE-COD-CEDENTE ' TITULO ' CEDENTE-NUM-TITULO */

            $"ALTERANDO .CEDENTE: {CEDENTE.DCLCEDENTE.CEDENTE_COD_CEDENTE} TITULO {CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO}"
            .Display();

            /*" -8972- PERFORM R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1 */

            R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1();

            /*" -8975- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -8976- DISPLAY 'R2060-00 - PROBLEMAS NO UPDATE(CEDENTE) ' */
                _.Display($"R2060-00 - PROBLEMAS NO UPDATE(CEDENTE) ");

                /*" -8976- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2060-00-ALTERA-V0CEDENTE-DB-UPDATE-1 */
        public void R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1()
        {
            /*" -8972- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = :CEDENTE-NUM-TITULO WHERE COD_CEDENTE = :CEDENTE-COD-CEDENTE END-EXEC. */

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
            /*" -8987- MOVE 'R3000' TO WNR-EXEC-SQL. */
            _.Move("R3000", WABEND.WNR_EXEC_SQL);

            /*" -8998- PERFORM R3000_LE_CUSTO_APOLICE_DB_SELECT_1 */

            R3000_LE_CUSTO_APOLICE_DB_SELECT_1();

            /*" -9001- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -9002- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9003- MOVE ZEROS TO PARC-OTNCUSTO */
                    _.Move(0, PARC_OTNCUSTO);

                    /*" -9004- ELSE */
                }
                else
                {


                    /*" -9006- DISPLAY 'R3000-PROBLEMAS NO SELECT CUSTO EMISSAO' ENDO-NUM-APOLICE */
                    _.Display($"R3000-PROBLEMAS NO SELECT CUSTO EMISSAO{ENDO_NUM_APOLICE}");

                    /*" -9007- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3000-LE-CUSTO-APOLICE-DB-SELECT-1 */
        public void R3000_LE_CUSTO_APOLICE_DB_SELECT_1()
        {
            /*" -8998- EXEC SQL SELECT SUM(OTNCUSTO) INTO :PARC-OTNCUSTO FROM SEGUROS.V0PARCELA WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = 0 WITH UR END-EXEC. */

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
            /*" -9017- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", WABEND.WNR_EXEC_SQL);

            /*" -9025- PERFORM R5000_00_LE_PCIOCC_DB_SELECT_1 */

            R5000_00_LE_PCIOCC_DB_SELECT_1();

            /*" -9028- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -9029- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -9030- MOVE ZEROS TO V1RAMO-PCIOF */
                    _.Move(0, V1RAMO_PCIOF);

                    /*" -9031- ELSE */
                }
                else
                {


                    /*" -9033- DISPLAY 'R5000-PROBLEMAS NO SELECT PERC DE IOF' ENDO-NUM-APOLICE */
                    _.Display($"R5000-PROBLEMAS NO SELECT PERC DE IOF{ENDO_NUM_APOLICE}");

                    /*" -9033- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5000-00-LE-PCIOCC-DB-SELECT-1 */
        public void R5000_00_LE_PCIOCC_DB_SELECT_1()
        {
            /*" -9025- EXEC SQL SELECT PCIOF INTO :V1RAMO-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :ENDO-RAMO AND DTINIVIG <= :ENDO-DTINIVIG AND DTTERVIG >= :ENDO-DTINIVIG WITH UR END-EXEC. */

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
            /*" -9044- MOVE 'R6100' TO WNR-EXEC-SQL. */
            _.Move("R6100", WABEND.WNR_EXEC_SQL);

            /*" -9045- IF W-PARCEL LESS 02 */

            if (W_PARCEL < 02)
            {

                /*" -9046- IF ENDO-NRRCAP EQUAL ZEROS */

                if (ENDO_NRRCAP == 00)
                {

                    /*" -9048- IF PRCB-TIPO-COBRANCA EQUAL ' ' OR PRCB-TIPO-COBRANCA EQUAL '0' */

                    if (PRCB_TIPO_COBRANCA == " " || PRCB_TIPO_COBRANCA == "0")
                    {

                        /*" -9049- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                        if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                        {

                            /*" -9050- ADD 1 TO WSHOST-TIT-FACIL */
                            WSHOST_TIT_FACIL.Value = WSHOST_TIT_FACIL + 1;

                            /*" -9051- MOVE WSHOST-TIT-FACIL TO W-NUMR-TITULO */
                            _.Move(WSHOST_TIT_FACIL, W_NUMR_TITULO);

                            /*" -9052- ELSE */
                        }
                        else
                        {


                            /*" -9053- ADD 1 TO WSHOST-NRTIT13 */
                            WSHOST_NRTIT13.Value = WSHOST_NRTIT13 + 1;

                            /*" -9054- MOVE WSHOST-NRTIT13 TO W-NUMR-TITULO */
                            _.Move(WSHOST_NRTIT13, W_NUMR_TITULO);

                            /*" -9055- END-IF */
                        }


                        /*" -9057- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -9058- ELSE */
                    }

                }
                else
                {


                    /*" -9059- PERFORM A6200-000-LE-RCAP */

                    A6200_000_LE_RCAP_SECTION();

                    /*" -9060- MOVE V0RCAP-NRTIT TO W-NUMR-TITULO */
                    _.Move(V0RCAP_NRTIT, W_NUMR_TITULO);

                    /*" -9061- ELSE */
                }

            }
            else
            {


                /*" -9062- IF ENDO-CODPRODU EQUAL 5302 OR 5303 OR 5304 */

                if (ENDO_CODPRODU.In("5302", "5303", "5304"))
                {

                    /*" -9063- IF PRCB-TIPO-COBRANCA EQUAL ' ' OR '0' */

                    if (PRCB_TIPO_COBRANCA.In(" ", "0"))
                    {

                        /*" -9064- ADD 1 TO WSHOST-TIT-FACIL */
                        WSHOST_TIT_FACIL.Value = WSHOST_TIT_FACIL + 1;

                        /*" -9065- MOVE WSHOST-TIT-FACIL TO W-NUMR-TITULO */
                        _.Move(WSHOST_TIT_FACIL, W_NUMR_TITULO);

                        /*" -9066- END-IF */
                    }


                    /*" -9067- ELSE */
                }
                else
                {


                    /*" -9068- ADD 1 TO WSHOST-NRTIT13 */
                    WSHOST_NRTIT13.Value = WSHOST_NRTIT13 + 1;

                    /*" -9068- MOVE WSHOST-NRTIT13 TO W-NUMR-TITULO. */
                    _.Move(WSHOST_NRTIT13, W_NUMR_TITULO);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6100_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-GRAVA-PARC-COMPL-SECTION */
        private void R7000_00_GRAVA_PARC_COMPL_SECTION()
        {
            /*" -9082- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", WABEND.WNR_EXEC_SQL);

            /*" -9083- MOVE PARC-NUM-APOLICE TO AU071-NUM-APOLICE */
            _.Move(PARC_NUM_APOLICE, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE);

            /*" -9084- MOVE PARC-NRENDOS TO AU071-NUM-ENDOSSO */
            _.Move(PARC_NRENDOS, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO);

            /*" -9086- MOVE PARC-NRTIT TO AU071-NUM-RECIBO-CONV */
            _.Move(PARC_NRTIT, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_RECIBO_CONV);

            /*" -9089- MOVE PARC-NRPARCEL TO AU071-NUM-PARCELA */
            _.Move(PARC_NRPARCEL, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA);

            /*" -9090- MOVE 1 TO AU071-NUM-VENCTO */
            _.Move(1, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

            /*" -9091- MOVE HIST-DTVENCTO TO AU071-DTA-VENCTO */
            _.Move(HIST_DTVENCTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);

            /*" -9093- MOVE PARC-OTNPRLIQ TO AU071-VLR-PREMIO-LIQUIDO */
            _.Move(PARC_OTNPRLIQ, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO);

            /*" -9094- MOVE ZEROS TO AU071-VLR-JUROS */
            _.Move(0, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS);

            /*" -9095- MOVE ZEROS TO AU071-VLR-MULTA */
            _.Move(0, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);

            /*" -9096- MOVE PARC-OTNADFRA TO AU071-VLR-ADIC-FRAC */
            _.Move(PARC_OTNADFRA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC);

            /*" -9097- MOVE PARC-OTNCUSTO TO AU071-VLR-CUSTO */
            _.Move(PARC_OTNCUSTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO);

            /*" -9098- MOVE PARC-OTNIOF TO AU071-VLR-IOF */
            _.Move(PARC_OTNIOF, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF);

            /*" -9100- MOVE PARC-OTNTOTAL TO AU071-VLR-PREMIO-TOTAL */
            _.Move(PARC_OTNTOTAL, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL);

            /*" -9103- PERFORM R7100-00-INCLUI-PARC-COMPL. */

            R7100_00_INCLUI_PARC_COMPL_SECTION();

            /*" -9104- IF PRCB-TIPO-COBRANCA NOT EQUAL '0' AND ' ' */

            if (!PRCB_TIPO_COBRANCA.In("0", " "))
            {

                /*" -9106- GO TO R7000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -9107- MOVE 2 TO AU071-NUM-VENCTO */
            _.Move(2, AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO);

            /*" -9108- MOVE HIST-DTVENCTO TO W-DATA-DB2 */
            _.Move(HIST_DTVENCTO, W_DATA_DB2);

            /*" -9109- MOVE W-DIA-DB2 TO W-DD */
            _.Move(W_DATA_DB2.W_DIA_DB2, W_DATA.W_DD);

            /*" -9110- MOVE W-MES-DB2 TO W-MM */
            _.Move(W_DATA_DB2.W_MES_DB2, W_DATA.W_MM);

            /*" -9111- MOVE W-ANO-DB2 TO W-AA */
            _.Move(W_DATA_DB2.W_ANO_DB2, W_DATA.W_AA);

            /*" -9112- MOVE W-DATA TO PROSOM-DATA01 */
            _.Move(W_DATA, PROSOMW099.PROSOM_DATA01);

            /*" -9113- MOVE 10 TO PROSOM-QTDIA */
            _.Move(10, PROSOMW099.PROSOM_QTDIA);

            /*" -9115- MOVE ZEROS TO PROSOM-DATA02 */
            _.Move(0, PROSOMW099.PROSOM_DATA02);

            /*" -9117- CALL 'PROSOCU1' USING PROSOMW099 */
            _.Call("PROSOCU1", PROSOMW099);

            /*" -9118- MOVE PROSOM-DATA02 TO W-DATA */
            _.Move(PROSOMW099.PROSOM_DATA02, W_DATA);

            /*" -9119- MOVE W-DD TO W-DIA-DB2 */
            _.Move(W_DATA.W_DD, W_DATA_DB2.W_DIA_DB2);

            /*" -9120- MOVE W-MM TO W-MES-DB2 */
            _.Move(W_DATA.W_MM, W_DATA_DB2.W_MES_DB2);

            /*" -9121- MOVE W-AA TO W-ANO-DB2 */
            _.Move(W_DATA.W_AA, W_DATA_DB2.W_ANO_DB2);

            /*" -9122- MOVE W-DATA-DB2 TO AU071-DTA-VENCTO */
            _.Move(W_DATA_DB2, AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO);

            /*" -9125- MOVE PARC-OTNPRLIQ TO AU071-VLR-PREMIO-LIQUIDO */
            _.Move(PARC_OTNPRLIQ, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO);

            /*" -9127- PERFORM R7200-00-CALC-VLR-COBRAR */

            R7200_00_CALC_VLR_COBRAR_SECTION();

            /*" -9128- MOVE WS-VLR-JUROS TO AU071-VLR-JUROS */
            _.Move(WS_VLR_JUROS, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_JUROS);

            /*" -9129- MOVE WS-VLR-MULTA TO AU071-VLR-MULTA */
            _.Move(WS_VLR_MULTA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_MULTA);

            /*" -9130- MOVE PARC-OTNADFRA TO AU071-VLR-ADIC-FRAC */
            _.Move(PARC_OTNADFRA, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_ADIC_FRAC);

            /*" -9131- MOVE PARC-OTNCUSTO TO AU071-VLR-CUSTO */
            _.Move(PARC_OTNCUSTO, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_CUSTO);

            /*" -9133- MOVE PARC-OTNIOF TO AU071-VLR-IOF */
            _.Move(PARC_OTNIOF, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF);

            /*" -9134- MOVE WS-VLR-COBRAR TO AU071-VLR-PREMIO-TOTAL */
            _.Move(WS_VLR_COBRAR, AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL);

            /*" -9134- PERFORM R7100-00-INCLUI-PARC-COMPL. */

            R7100_00_INCLUI_PARC_COMPL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-INCLUI-PARC-COMPL-SECTION */
        private void R7100_00_INCLUI_PARC_COMPL_SECTION()
        {
            /*" -9148- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", WABEND.WNR_EXEC_SQL);

            /*" -9165- PERFORM R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1 */

            R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1();

            /*" -9168- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9173- DISPLAY 'R7100-00 (PROBLEMAS INSERT PARCELA_AUTO_COMPL)' ' ' AU071-NUM-APOLICE ' ' AU071-NUM-ENDOSSO ' ' AU071-NUM-PARCELA ' ' AU071-NUM-VENCTO */

                $"R7100-00 (PROBLEMAS INSERT PARCELA_AUTO_COMPL) {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO}"
                .Display();

                /*" -9175- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -9175- ADD +1 TO AC-I-AU071. */
            AC_I_AU071.Value = AC_I_AU071 + +1;

        }

        [StopWatch]
        /*" R7100-00-INCLUI-PARC-COMPL-DB-INSERT-1 */
        public void R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1()
        {
            /*" -9165- EXEC SQL INSERT INTO SEGUROS.PARCELA_AUTO_COMPL VALUES (:AU071-NUM-APOLICE , :AU071-NUM-ENDOSSO , :AU071-NUM-PARCELA , :AU071-DTA-VENCTO , :AU071-NUM-VENCTO , :AU071-VLR-PREMIO-LIQUIDO , :AU071-VLR-JUROS , :AU071-VLR-ADIC-FRAC , :AU071-VLR-MULTA , :AU071-VLR-CUSTO , :AU071-VLR-IOF , :AU071-VLR-PREMIO-TOTAL , :AU071-NUM-RECIBO-CONV , 'EM0010B' , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -9188- MOVE '7200' TO WNR-EXEC-SQL. */
            _.Move("7200", WABEND.WNR_EXEC_SQL);

            /*" -9189- MOVE AU071-DTA-VENCTO TO WHOST-DTCALEND1. */
            _.Move(AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO, WHOST_DTCALEND1);

            /*" -9191- MOVE WHOST-DTCURRENT TO WHOST-DTCALEND2. */
            _.Move(WHOST_DTCURRENT, WHOST_DTCALEND2);

            /*" -9193- PERFORM R7210-00-APURA-QTD-DIAS */

            R7210_00_APURA_QTD_DIAS_SECTION();

            /*" -9198- COMPUTE WS-PCT-JUROS = ((WHOST-QTDIAS * 0,03) / 100). */
            WS_PCT_JUROS.Value = ((WHOST_QTDIAS * 0.03) / 100f);

            /*" -9201- COMPUTE WS-VLR-JUROS = ((AU071-VLR-PREMIO-TOTAL * 7,5) / 100). */
            WS_VLR_JUROS.Value = ((AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_TOTAL * 7.5) / 100f);

            /*" -9205- MOVE ZEROS TO WS-VLR-MULTA */
            _.Move(0, WS_VLR_MULTA);

            /*" -9209- COMPUTE WS-VLR-COBRAR = AU071-VLR-PREMIO-LIQUIDO + AU071-VLR-IOF + WS-VLR-JUROS + WS-VLR-MULTA. */
            WS_VLR_COBRAR.Value = AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_PREMIO_LIQUIDO + AU071.DCLPARCELA_AUTO_COMPL.AU071_VLR_IOF + WS_VLR_JUROS + WS_VLR_MULTA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7200_99_SAIDA*/

        [StopWatch]
        /*" R7210-00-APURA-QTD-DIAS-SECTION */
        private void R7210_00_APURA_QTD_DIAS_SECTION()
        {
            /*" -9220- MOVE 'R7210' TO WNR-EXEC-SQL. */
            _.Move("R7210", WABEND.WNR_EXEC_SQL);

            /*" -9231- PERFORM R7210_00_APURA_QTD_DIAS_DB_SELECT_1 */

            R7210_00_APURA_QTD_DIAS_DB_SELECT_1();

            /*" -9234- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9241- DISPLAY 'R7210-00 (PROBLEMAS SELECT CALENDARIO)' ' ' AU071-NUM-APOLICE ' ' AU071-NUM-ENDOSSO ' ' AU071-NUM-PARCELA ' ' AU071-NUM-VENCTO ' ' WHOST-DTCALEND1 ' ' WHOST-DTCALEND2 */

                $"R7210-00 (PROBLEMAS SELECT CALENDARIO) {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_APOLICE} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_ENDOSSO} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_PARCELA} {AU071.DCLPARCELA_AUTO_COMPL.AU071_NUM_VENCTO} {WHOST_DTCALEND1} {WHOST_DTCALEND2}"
                .Display();

                /*" -9241- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7210-00-APURA-QTD-DIAS-DB-SELECT-1 */
        public void R7210_00_APURA_QTD_DIAS_DB_SELECT_1()
        {
            /*" -9231- EXEC SQL SELECT COUNT(*) INTO :WHOST-QTDIAS FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :WHOST-DTCALEND1 AND DATA_CALENDARIO <= :WHOST-DTCALEND2 WITH UR END-EXEC. */

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
            /*" -9251- MOVE 'R7220' TO WNR-EXEC-SQL */
            _.Move("R7220", WABEND.WNR_EXEC_SQL);

            /*" -9255- MOVE ZEROS TO APOLIAUT-CANAL-PROPOSTA APOLIAUT-NUM-PROPOSTA-CONV APOLIAUT-COD-FONTE */
            _.Move(0, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE);

            /*" -9267- PERFORM R7220_00_CONSULTA_NN_DB_SELECT_1 */

            R7220_00_CONSULTA_NN_DB_SELECT_1();

            /*" -9270- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -9271- DISPLAY 'R7220 (PROBLEMAS SELECT APOLICE_AUTO)' */
                _.Display($"R7220 (PROBLEMAS SELECT APOLICE_AUTO)");

                /*" -9272- DISPLAY 'APOLICE ' PARC-NUM-APOLICE */
                _.Display($"APOLICE {PARC_NUM_APOLICE}");

                /*" -9273- DISPLAY 'ENDOSSO ' PARC-NRENDOS */
                _.Display($"ENDOSSO {PARC_NRENDOS}");

                /*" -9274- DISPLAY 'PARCELA ' PARC-NRPARCEL */
                _.Display($"PARCELA {PARC_NRPARCEL}");

                /*" -9275- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -9277- END-IF */
            }


            /*" -9279- INITIALIZE REGISTRO-LINKAGE-GE0350S */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -9280- MOVE 01 TO LK-GE350-COD-FUNCAO */
            _.Move(01, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -9281- MOVE 'EM0010B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0010B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -9282- MOVE PARC-NUM-APOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(PARC_NUM_APOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -9283- MOVE PARC-NRENDOS TO LK-GE350-NUM-ENDOSSO */
            _.Move(PARC_NRENDOS, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -9284- MOVE PARC-NRPARCEL TO LK-GE350-NUM-PARCELA */
            _.Move(PARC_NRPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -9287- MOVE APOLIAUT-NUM-PROPOSTA-CONV TO LK-GE350-NUM-PROPOSTA */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -9289- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -9290- IF LK-GE350-COD-RETORNO NOT = '2' */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "2")
            {

                /*" -9291- DISPLAY 'ERRO NA EXECUCAO DO CALL GE0350S' */
                _.Display($"ERRO NA EXECUCAO DO CALL GE0350S");

                /*" -9292- DISPLAY 'SQLCODE: ' LK-GE350-SQLCODE */
                _.Display($"SQLCODE: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -9293- DISPLAY 'MSG ERRO: ' LK-GE350-MSG-RETORNO */
                _.Display($"MSG ERRO: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}");

                /*" -9294- DISPLAY '--------- DADOS DE SAIDA GE0350S ---------- ' */
                _.Display($"--------- DADOS DE SAIDA GE0350S ---------- ");

                /*" -9295- DISPLAY '=> COD-FUNCAO       ' LK-GE350-COD-FUNCAO */
                _.Display($"=> COD-FUNCAO       {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

                /*" -9296- DISPLAY '=> NUM-PROPOSTA     ' LK-GE350-NUM-PROPOSTA */
                _.Display($"=> NUM-PROPOSTA     {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -9297- DISPLAY '=> NUM-APOLICE      ' LK-GE350-NUM-APOLICE */
                _.Display($"=> NUM-APOLICE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -9298- DISPLAY '=> NUM-ENDOSSO      ' LK-GE350-NUM-ENDOSSO */
                _.Display($"=> NUM-ENDOSSO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -9299- DISPLAY '=> NUM-PARCELA      ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NUM-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -9300- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -9302- END-IF */
            }


            /*" -9303- MOVE 07 TO LK-GE350-COD-FUNCAO */
            _.Move(07, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -9305- MOVE PARC-NUM-APOLICE TO LK-GE350-NUM-CONTA-CNTRO WS-NUM-IDLG-APOLICE */
            _.Move(PARC_NUM_APOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CONTA_CNTRO, WS_NUM_IDLG.WS_NUM_IDLG_APOLICE);

            /*" -9306- MOVE PARC-NRENDOS TO WS-NUM-IDLG-ENDOSSO */
            _.Move(PARC_NRENDOS, WS_NUM_IDLG.WS_NUM_IDLG_ENDOSSO);

            /*" -9307- MOVE PARC-NRPARCEL TO WS-NUM-IDLG-PARCELA */
            _.Move(PARC_NRPARCEL, WS_NUM_IDLG.WS_NUM_IDLG_PARCELA);

            /*" -9308- MOVE ENDO-CODPRODU TO LK-GE350-COD-PRODUTO */
            _.Move(ENDO_CODPRODU, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -9309- MOVE ENDO-QTPARCEL TO LK-GE350-QTD-PARCELA */
            _.Move(ENDO_QTPARCEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

            /*" -9310- MOVE ENDO-DTINIVIG TO LK-GE350-DTA-MOVIMENTO */
            _.Move(ENDO_DTINIVIG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -9311- MOVE APOL-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
            _.Move(APOL_COD_CLIENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -9312- MOVE HIST-VLPRMTOT TO LK-GE350-VLR-PREMIO-TOTAL */
            _.Move(HIST_VLPRMTOT, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL);

            /*" -9313- MOVE HIST-VLIOCC TO LK-GE350-VLR-IOF */
            _.Move(HIST_VLIOCC, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF);

            /*" -9314- MOVE HIST-DTVENCTO TO LK-GE350-DTA-VENCIMENTO */
            _.Move(HIST_DTVENCTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -9316- MOVE WS-NUM-IDLG TO LK-GE350-NUM-IDLG */
            _.Move(WS_NUM_IDLG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

            /*" -9317- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -9318- MOVE 'SIAS' TO LK-GE350-COD-SISTEMA */
            _.Move("SIAS", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SISTEMA);

            /*" -9319- MOVE 'SIAS_09518' TO LK-GE350-COD-EVENTO */
            _.Move("SIAS_09518", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_EVENTO);

            /*" -9320- MOVE APOLIAUT-CANAL-PROPOSTA TO LK-GE350-COD-CANAL */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_CANAL_PROPOSTA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CANAL);

            /*" -9321- MOVE 'R' TO LK-GE350-COD-TP-CONVENIO */
            _.Move("R", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_TP_CONVENIO);

            /*" -9322- MOVE 'AU' TO LK-GE350-IDE-SISTEMA */
            _.Move("AU", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -9323- MOVE 'EM0010B' TO LK-GE350-COD-USUARIO */
            _.Move("EM0010B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -9324- MOVE 'A' TO LK-GE350-COD-SITUACAO */
            _.Move("A", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

            /*" -9326- MOVE APOLIAUT-COD-FONTE TO LK-GE350-COD-FONTE */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FONTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FONTE);

            /*" -9328- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -9330- IF LK-GE350-COD-RETORNO NOT = '0' */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
            {

                /*" -9331- DISPLAY 'R7220-00-NAO CONSEGUIU GERAR BOLETO' */
                _.Display($"R7220-00-NAO CONSEGUIU GERAR BOLETO");

                /*" -9332- DISPLAY '  APOLICE ' LK-GE350-NUM-APOLICE */
                _.Display($"  APOLICE {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -9333- DISPLAY '  ENDOSSO ' LK-GE350-NUM-ENDOSSO */
                _.Display($"  ENDOSSO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -9334- DISPLAY '  PARCELA ' LK-GE350-NUM-PARCELA */
                _.Display($"  PARCELA {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -9335- DISPLAY '  PROPOST ' LK-GE350-NUM-PROPOSTA */
                _.Display($"  PROPOST {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -9337- DISPLAY '  IDLG    ' LK-GE350-NUM-IDLG */
                _.Display($"  IDLG    {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -9338- MOVE 02 TO LK-GE350-COD-FUNCAO */
                _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

                /*" -9340- MOVE 'P' TO LK-GE350-COD-SITUACAO */
                _.Move("P", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -9342- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
                _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

                /*" -9343- IF LK-GE350-COD-RETORNO NOT = '0' */

                if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0")
                {

                    /*" -9344- DISPLAY 'ERRO NA EXECUCAO DO CALL GE0350S' */
                    _.Display($"ERRO NA EXECUCAO DO CALL GE0350S");

                    /*" -9345- DISPLAY 'SQLCODE: ' LK-GE350-SQLCODE */
                    _.Display($"SQLCODE: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                    /*" -9346- DISPLAY 'MSG ERRO: ' LK-GE350-MSG-RETORNO */
                    _.Display($"MSG ERRO: {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_MSG_RETORNO}");

                    /*" -9347- DISPLAY '--------- DADOS DE SAIDA GE0350S ---------- ' */
                    _.Display($"--------- DADOS DE SAIDA GE0350S ---------- ");

                    /*" -9348- DISPLAY '=> COD-FUNCAO       ' LK-GE350-COD-FUNCAO */
                    _.Display($"=> COD-FUNCAO       {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO}");

                    /*" -9349- DISPLAY '=> COD-CLIENTE      ' LK-GE350-COD-CLIENTE */
                    _.Display($"=> COD-CLIENTE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE}");

                    /*" -9350- DISPLAY '=> NUM-PROPOSTA     ' LK-GE350-NUM-PROPOSTA */
                    _.Display($"=> NUM-PROPOSTA     {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                    /*" -9351- DISPLAY '=> NUM-APOLICE      ' LK-GE350-NUM-APOLICE */
                    _.Display($"=> NUM-APOLICE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                    /*" -9352- DISPLAY '=> NUM-ENDOSSO      ' LK-GE350-NUM-ENDOSSO */
                    _.Display($"=> NUM-ENDOSSO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                    /*" -9353- DISPLAY '=> NUM-PARCELA      ' LK-GE350-NUM-PARCELA */
                    _.Display($"=> NUM-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                    /*" -9354- DISPLAY '=> NUM-IDLG         ' LK-GE350-NUM-IDLG */
                    _.Display($"=> NUM-IDLG         {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                    /*" -9355- DISPLAY '=> COD-PRODUTO      ' LK-GE350-COD-PRODUTO */
                    _.Display($"=> COD-PRODUTO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO}");

                    /*" -9356- DISPLAY '=> DTA-MOVIMENTO    ' LK-GE350-DTA-MOVIMENTO */
                    _.Display($"=> DTA-MOVIMENTO    {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

                    /*" -9357- DISPLAY '=> DTA-VENCIMENTO   ' LK-GE350-DTA-VENCIMENTO */
                    _.Display($"=> DTA-VENCIMENTO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO}");

                    /*" -9359- DISPLAY '=> VLR-PREMIO-TOTAL ' LK-GE350-VLR-PREMIO-TOTAL */
                    _.Display($"=> VLR-PREMIO-TOTAL {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL}");

                    /*" -9360- DISPLAY '=> QTD-PARCELA      ' LK-GE350-QTD-PARCELA */
                    _.Display($"=> QTD-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA}");

                    /*" -9362- DISPLAY '=> QTD-DIAS-CUSTODI ' LK-GE350-QTD-DIAS-CUSTODIA */
                    _.Display($"=> QTD-DIAS-CUSTODI {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA}");

                    /*" -9364- DISPLAY '=> NOSSO-NUMERO-SAP ' LK-GE350-NOSSO-NUMERO-SAP */
                    _.Display($"=> NOSSO-NUMERO-SAP {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                    /*" -9365- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -9366- END-IF */
                }


                /*" -9368- END-IF */
            }


            /*" -9370- IF LK-GE350-COD-FUNCAO = 07 AND LK-GE350-NOSSO-NUMERO-SAP = 0 */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO == 07 && LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP == 0)
            {

                /*" -9371- DISPLAY 'NOSSO-NUMERO-SAP ESTA ZERADO' */
                _.Display($"NOSSO-NUMERO-SAP ESTA ZERADO");

                /*" -9372- DISPLAY '=> NUM-APOLICE      ' LK-GE350-NUM-APOLICE */
                _.Display($"=> NUM-APOLICE      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -9373- DISPLAY '=> NUM-ENDOSSO      ' LK-GE350-NUM-ENDOSSO */
                _.Display($"=> NUM-ENDOSSO      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -9374- DISPLAY '=> NUM-PARCELA      ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NUM-PARCELA      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -9375- DISPLAY '=> NUM-IDLG         ' LK-GE350-NUM-IDLG */
                _.Display($"=> NUM-IDLG         {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -9376- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -9378- END-IF */
            }


            /*" -9379- IF LK-GE350-COD-FUNCAO = 02 */

            if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO == 02)
            {

                /*" -9380- GO TO R7220-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7220_99_SAIDA*/ //GOTO
                return;

                /*" -9382- END-IF */
            }


            /*" -9383- MOVE LK-GE350-NOSSO-NUMERO-SAP TO WS-NOSSO-NUMERO-SAP */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, WS_NOSSO_NUMERO_SAP);

            /*" -9385- MOVE WS-NOSSO-NR-TITULO TO PARC-NRTIT */
            _.Move(FILLER_31.WS_NOSSO_NR_TITULO, PARC_NRTIT);

            /*" -9391- PERFORM R7220_00_CONSULTA_NN_DB_UPDATE_1 */

            R7220_00_CONSULTA_NN_DB_UPDATE_1();

            /*" -9394- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -9395- DISPLAY 'R7220 (PROBLEMAS ATUALIZACAO PARCELAS)' */
                _.Display($"R7220 (PROBLEMAS ATUALIZACAO PARCELAS)");

                /*" -9396- DISPLAY 'APOLICE ' PARC-NUM-APOLICE */
                _.Display($"APOLICE {PARC_NUM_APOLICE}");

                /*" -9397- DISPLAY 'ENDOSSO ' PARC-NRENDOS */
                _.Display($"ENDOSSO {PARC_NRENDOS}");

                /*" -9398- DISPLAY 'PARCELA ' PARC-NRPARCEL */
                _.Display($"PARCELA {PARC_NRPARCEL}");

                /*" -9399- DISPLAY 'TITULO  ' PARC-NRTIT */
                _.Display($"TITULO  {PARC_NRTIT}");

                /*" -9400- GO TO 999-999-ROT-ERRO */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -9400- END-IF. */
            }


        }

        [StopWatch]
        /*" R7220-00-CONSULTA-NN-DB-SELECT-1 */
        public void R7220_00_CONSULTA_NN_DB_SELECT_1()
        {
            /*" -9267- EXEC SQL SELECT CANAL_PROPOSTA ,NUM_PROPOSTA_CONV ,COD_FONTE INTO :APOLIAUT-CANAL-PROPOSTA ,:APOLIAUT-NUM-PROPOSTA-CONV ,:APOLIAUT-COD-FONTE FROM SEGUROS.APOLICE_AUTO WHERE NUM_APOLICE = :PARC-NUM-APOLICE AND NUM_ENDOSSO = :PARC-NRENDOS AND NUM_ITEM = 101 WITH UR END-EXEC */

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
            /*" -9391- EXEC SQL UPDATE SEGUROS.PARCELAS SET NUM_TITULO = :PARC-NRTIT WHERE NUM_APOLICE = :PARC-NUM-APOLICE AND NUM_ENDOSSO = :PARC-NRENDOS AND NUM_PARCELA = :PARC-NRPARCEL END-EXEC */

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
        /*" C0000-FIM-SECTION */
        private void C0000_FIM_SECTION()
        {
            /*" -9410- MOVE 'C0000' TO WNR-EXEC-SQL. */
            _.Move("C0000", WABEND.WNR_EXEC_SQL);

            /*" -9410- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -9416- DISPLAY 'ENDOSSOS LIDOS        ' AC-L-V1ENDOSSO. */
            _.Display($"ENDOSSOS LIDOS        {AC_L_V1ENDOSSO}");

            /*" -9417- DISPLAY 'DOCUMENTOS INSERIDOS  ' */
            _.Display($"DOCUMENTOS INSERIDOS  ");

            /*" -9418- DISPLAY ' . V0PARCELA          ' AC-I-V0PARCELA. */
            _.Display($" . V0PARCELA          {AC_I_V0PARCELA}");

            /*" -9419- DISPLAY ' . V0HISTOPARC        ' AC-I-V0HISTOPARC. */
            _.Display($" . V0HISTOPARC        {AC_I_V0HISTOPARC}");

            /*" -9420- DISPLAY ' . V0ORDCOSCED        ' AC-I-V0ORDCOSCED. */
            _.Display($" . V0ORDCOSCED        {AC_I_V0ORDCOSCED}");

            /*" -9421- DISPLAY ' . V0RCAPCOMP         ' AC-I-V0RCAPCOMP. */
            _.Display($" . V0RCAPCOMP         {AC_I_V0RCAPCOMP}");

            /*" -9422- DISPLAY ' . V0EMISDIARIA       ' AC-I-V0EMISDIARIA. */
            _.Display($" . V0EMISDIARIA       {AC_I_V0EMISDIARIA}");

            /*" -9423- DISPLAY ' . V0RELATORIOS       ' AC-I-V0RELATORIO. */
            _.Display($" . V0RELATORIOS       {AC_I_V0RELATORIO}");

            /*" -9424- DISPLAY ' . PARCELA_AUTO_COMPL ' AC-I-AU071 . */
            _.Display($" . PARCELA_AUTO_COMPL {AC_I_AU071}");

            /*" -9425- DISPLAY ' . TITULOS CAP LOT    ' AC-I-TITCAP-LOT. */
            _.Display($" . TITULOS CAP LOT    {AC_I_TITCAP_LOT}");

            /*" -9427- DISPLAY 'EM0010B - FIM NORMAL ' . */
            _.Display($"EM0010B - FIM NORMAL ");

            /*" -9429- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -9429- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: C0000_999_EXIT*/

        [StopWatch]
        /*" M-99999-DISPLAY-SECTION */
        private void M_99999_DISPLAY_SECTION()
        {
            /*" -9439- DISPLAY 'RAMO           = ' RAMO */
            _.Display($"RAMO           = {EM0901W099.RAMO}");

            /*" -9440- DISPLAY 'COD-MOEDA      = ' COD-MOEDA */
            _.Display($"COD-MOEDA      = {EM0901W099.COD_MOEDA}");

            /*" -9441- DISPLAY 'DTINIVIG       = ' DTINIVIG */
            _.Display($"DTINIVIG       = {EM0901W099.DTINIVIG}");

            /*" -9442- DISPLAY 'NRPARCEL       = ' NRPARCEL */
            _.Display($"NRPARCEL       = {EM0901W099.NRPARCEL}");

            /*" -9443- DISPLAY 'QTPARCEL       = ' QTPARCEL */
            _.Display($"QTPARCEL       = {EM0901W099.QTPARCEL}");

            /*" -9444- DISPLAY 'IND-FRAC       = ' IND-FRAC */
            _.Display($"IND-FRAC       = {EM0901W099.IND_FRAC}");

            /*" -9445- DISPLAY 'ISENTA-CUSTO   = ' ISENTA-CUSTO */
            _.Display($"ISENTA-CUSTO   = {EM0901W099.ISENTA_CUSTO}");

            /*" -9446- DISPLAY 'PCIOF          = ' PCIOF */
            _.Display($"PCIOF          = {EM0901W099.PCIOF}");

            /*" -9447- DISPLAY 'PCENTRAD       = ' PCENTRAD */
            _.Display($"PCENTRAD       = {EM0901W099.PCENTRAD}");

            /*" -9448- DISPLAY 'PCJUROS        = ' PCJUROS */
            _.Display($"PCJUROS        = {EM0901W099.PCJUROS}");

            /*" -9449- DISPLAY 'PCDESCON       = ' PCDESCON */
            _.Display($"PCDESCON       = {EM0901W099.PCDESCON}");

            /*" -9450- DISPLAY 'VL-PREMIO-BASE = ' VL-PREMIO-BASE */
            _.Display($"VL-PREMIO-BASE = {EM0901W099.VL_PREMIO_BASE}");

            /*" -9451- DISPLAY 'VL-TARIFARIO-IX= ' VL-TARIFARIO-IX */
            _.Display($"VL-TARIFARIO-IX= {EM0901W099.VL_TARIFARIO_IX}");

            /*" -9452- DISPLAY 'VL-DESC-IX     = ' VL-DESC-IX */
            _.Display($"VL-DESC-IX     = {EM0901W099.VL_DESC_IX}");

            /*" -9453- DISPLAY 'VL-LIQ-IX      = ' VL-LIQ-IX */
            _.Display($"VL-LIQ-IX      = {EM0901W099.VL_LIQ_IX}");

            /*" -9454- DISPLAY 'VL-ADIC-IX     = ' VL-ADIC-IX */
            _.Display($"VL-ADIC-IX     = {EM0901W099.VL_ADIC_IX}");

            /*" -9455- DISPLAY 'VL-CUSTO-IX    = ' VL-CUSTO-IX */
            _.Display($"VL-CUSTO-IX    = {EM0901W099.VL_CUSTO_IX}");

            /*" -9456- DISPLAY 'VL-IOF-IX      = ' VL-IOF-IX */
            _.Display($"VL-IOF-IX      = {EM0901W099.VL_IOF_IX}");

            /*" -9457- DISPLAY 'VL-TOTAL-IX    = ' VL-TOTAL-IX */
            _.Display($"VL-TOTAL-IX    = {EM0901W099.VL_TOTAL_IX}");

            /*" -9458- DISPLAY 'VL-TARIFA      = ' VL-TARIFA */
            _.Display($"VL-TARIFA      = {EM0901W099.VL_TARIFA}");

            /*" -9459- DISPLAY 'VL-DESCONTO    = ' VL-DESCONTO */
            _.Display($"VL-DESCONTO    = {EM0901W099.VL_DESCONTO}");

            /*" -9460- DISPLAY 'VL-LIQUIDO     = ' VL-LIQUIDO */
            _.Display($"VL-LIQUIDO     = {EM0901W099.VL_LIQUIDO}");

            /*" -9461- DISPLAY 'VL-ADICIONA    = ' VL-ADICIONAL */
            _.Display($"VL-ADICIONA    = {EM0901W099.VL_ADICIONAL}");

            /*" -9462- DISPLAY 'VL-CUSTO       = ' VL-CUSTO */
            _.Display($"VL-CUSTO       = {EM0901W099.VL_CUSTO}");

            /*" -9463- DISPLAY 'VL-IOF         = ' VL-IOF */
            _.Display($"VL-IOF         = {EM0901W099.VL_IOF}");

            /*" -9464- DISPLAY 'VL-TOTAL       = ' VL-TOTAL */
            _.Display($"VL-TOTAL       = {EM0901W099.VL_TOTAL}");

            /*" -9465- DISPLAY 'NRRCAP         = ' NRRCAP */
            _.Display($"NRRCAP         = {EM0901W099.NRRCAP}");

            /*" -9466- DISPLAY 'VL-COBER-ASSIST= ' VL-COBER-ASSIST */
            _.Display($"VL-COBER-ASSIST= {EM0901W099.VL_COBER_ASSIST}");

            /*" -9467- DISPLAY 'PCDESCON-ADIC  = ' PCDESCON-ADIC */
            _.Display($"PCDESCON-ADIC  = {EM0901W099.PCDESCON_ADIC}");

            /*" -9468- DISPLAY 'PCDESCON-BONUS = ' PCDESCON-BONUS */
            _.Display($"PCDESCON-BONUS = {EM0901W099.PCDESCON_BONUS}");

            /*" -9468- DISPLAY 'VL-TARIFARIO-IX  =' VL-TARIFARIO-IX. */
            _.Display($"VL-TARIFARIO-IX  ={EM0901W099.VL_TARIFARIO_IX}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_99999_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -9478- IF SQLCODE EQUAL -911 */

            if (DB.SQLCODE == -911)
            {

                /*" -9480- GO TO 999-999-SEM-UPDATE. */

                M_999_999_SEM_UPDATE_SECTION(); //GOTO
                return;
            }


            /*" -9481- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9482- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -9483- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -9484- MOVE SQLERRD(1) TO WERRO */
                _.Move(DB.SQLERRD[1], WERRO);

                /*" -9485- DISPLAY 'SQLERRD(1) ' WERRO */
                _.Display($"SQLERRD(1) {WERRO}");

                /*" -9486- MOVE SQLERRD(2) TO WERRO */
                _.Move(DB.SQLERRD[2], WERRO);

                /*" -9487- DISPLAY 'SQLERRD(2) ' WERRO. */
                _.Display($"SQLERRD(2) {WERRO}");
            }


            /*" -9489- DISPLAY 'SQLSTATE   ' SQLSTATE. */
            _.Display($"SQLSTATE   {DB.SQLSTATE}");

            /*" -9490- DISPLAY 'ROTINA 999-999-ROT-ERRO' */
            _.Display($"ROTINA 999-999-ROT-ERRO");

            /*" -9491- DISPLAY 'FONTE..... ' ENDO-FONTE. */
            _.Display($"FONTE..... {ENDO_FONTE}");

            /*" -9492- DISPLAY 'RAMO...... ' ENDO-RAMO. */
            _.Display($"RAMO...... {ENDO_RAMO}");

            /*" -9493- DISPLAY 'PROPOSTA.. ' ENDO-NRPROPOS. */
            _.Display($"PROPOSTA.. {ENDO_NRPROPOS}");

            /*" -9494- DISPLAY 'APOLICE... ' ENDO-NUM-APOLICE. */
            _.Display($"APOLICE... {ENDO_NUM_APOLICE}");

            /*" -9496- DISPLAY 'ENDOSSO... ' ENDO-NRENDOS. */
            _.Display($"ENDOSSO... {ENDO_NRENDOS}");

            /*" -9496- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -9498- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -9509- PERFORM M_999_999_ROT_ERRO_DB_UPDATE_1 */

            M_999_999_ROT_ERRO_DB_UPDATE_1();

            /*" -9511- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -9515- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -9515- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-999-999-ROT-ERRO-DB-UPDATE-1 */
        public void M_999_999_ROT_ERRO_DB_UPDATE_1()
        {
            /*" -9509- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET SITUACAO = 'E' WHERE NUM_APOLICE = :ENDO-NUM-APOLICE AND NRENDOS = :ENDO-NRENDOS END-EXEC. */

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
            /*" -9525- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -9526- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -9527- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -9528- MOVE SQLERRD(1) TO WERRO */
                _.Move(DB.SQLERRD[1], WERRO);

                /*" -9529- DISPLAY 'SQLERRD(1) ' WERRO */
                _.Display($"SQLERRD(1) {WERRO}");

                /*" -9530- MOVE SQLERRD(2) TO WERRO */
                _.Move(DB.SQLERRD[2], WERRO);

                /*" -9532- DISPLAY 'SQLERRD(2) ' WERRO. */
                _.Display($"SQLERRD(2) {WERRO}");
            }


            /*" -9533- DISPLAY ' ' */
            _.Display($" ");

            /*" -9534- DISPLAY 'ULTIMO CURSOR LIDO NO DECLARE PRINCIPAL' */
            _.Display($"ULTIMO CURSOR LIDO NO DECLARE PRINCIPAL");

            /*" -9535- DISPLAY 'FONTE..... ' ENDO-FONTE. */
            _.Display($"FONTE..... {ENDO_FONTE}");

            /*" -9536- DISPLAY 'RAMO...... ' ENDO-RAMO. */
            _.Display($"RAMO...... {ENDO_RAMO}");

            /*" -9537- DISPLAY 'PROPOSTA.. ' ENDO-NRPROPOS. */
            _.Display($"PROPOSTA.. {ENDO_NRPROPOS}");

            /*" -9538- DISPLAY 'APOLICE... ' ENDO-NUM-APOLICE. */
            _.Display($"APOLICE... {ENDO_NUM_APOLICE}");

            /*" -9540- DISPLAY 'ENDOSSO... ' ENDO-NRENDOS. */
            _.Display($"ENDOSSO... {ENDO_NRENDOS}");

            /*" -9541- DISPLAY ' ' */
            _.Display($" ");

            /*" -9542- DISPLAY '##################################################' */
            _.Display($"##################################################");

            /*" -9543- DISPLAY 'ATENCAO: EM CASO DE ABEND FAVOR RESTARTAR NO MESMO' */
            _.Display($"ATENCAO: EM CASO DE ABEND FAVOR RESTARTAR NO MESMO");

            /*" -9544- DISPLAY '         STEP QUANTAS VEZES FOR NECESSARIO  ATE  O' */
            _.Display($"         STEP QUANTAS VEZES FOR NECESSARIO  ATE  O");

            /*" -9545- DISPLAY '         PROCESSAMENTO COM TERMINO NORMAL         ' */
            _.Display($"         PROCESSAMENTO COM TERMINO NORMAL         ");

            /*" -9547- DISPLAY '##################################################' */
            _.Display($"##################################################");

            /*" -9547- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -9549- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -9553- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -9553- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}