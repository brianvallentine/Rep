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
using Sias.VidaEmGrupo.DB2.VG0139B;

namespace Code
{
    public class VG0139B
    {
        public bool IsCall { get; set; }

        public VG0139B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDAZUL EMPRESARIAL/PESSOA JURIDICA*      */
        /*"      *   PROGRAMA ...............  VG0139B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *   PROGRAMADOR ............  FONSECA                            *      */
        /*"      *   DATA CODIFICACAO .......  10/11/1997                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO HISTORICO DE           *      */
        /*"      *                             CONTABILIZACAO DE PARCELAS         *      */
        /*"      *                             (V0HISTCONTABILVA), GERA O ENDOSSO *      */
        /*"      *                             CORRESPONDENTE PARA REGISTRAR A    *      */
        /*"      *                             EMISSAO E A COBRANCA               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * COPIA MODIFICADA DO VG0139A PARA ATENDER O NOVO FATURAMENTO    *      */
        /*"      * DAS APOLICES ESPECIFICAS / VIDAZUL EMPRESARIAL                 *      */
        /*"      *    FREDERICO FONSECA - 20/03/2002.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                  A L T E R A C O E S                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 42 - HIST 181.584                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 41 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - PASSA A APROPRIAR O CODIGO DE                    *      */
        /*"      *                             PRODUTO DA PRODUTOS_VG;            *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/05/2018 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.41    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 40 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - MOVE MODALIDADE CADASTRADA NA TABELA APOLICES    *      */
        /*"      *                                                                *      */
        /*"      *   EM 03/05/2018 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.40    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 39 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - LIBERA FATURAS DE COBRANCA PARA ADESAO DESDE     *      */
        /*"      *               QUE NAO EXISTA SOLICITACAO DE DEVOLUCAO.         *      */
        /*"      *             - LIBERA FATURAS DE RESTITUICAO PARA ADESAO DESDE  *      */
        /*"      *               QUE EXISTA FATURAS DE COBRANCA EMITIDAS.         *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/11/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.39    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 38 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - DATA DE EMISSAO NA TABELA ENDOSSOS TEM QUE SER   *      */
        /*"      *               IGUAL A DATA DO SISTEMA.                         *      */
        /*"      *             - SE A DATA DE EMISSAO FOR MENOR QUE DATA DA       *      */
        /*"      *               PROPOSTA REPRESA EMISSAO DA FATURA ATE QUE       *      */
        /*"      *               DATA DE EMISSAO SEJA MAIOR OU IGUAL.             *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/11/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.38    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 37 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - LIBERA FATURAS DE CERTIFICADOS CANCELADOS        *      */
        /*"      *               PARA DEMAIS PARCELAS.                            *      */
        /*"      *             - PRIMEIRA PARCELA FICA PENDENTE PARA ANALISE      *      */
        /*"      *               CONFORME ALTERACAO EFETUADA NA  V.34,            *      */
        /*"      *               EVITANDO PAGAMENTO DE COMISSAO P/ CERTIFICADOS   *      */
        /*"      *               DECLINADOS PELA SEGURADORA.                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/11/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.37    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 36 - CADMUS 154.177                                   *      */
        /*"      *                                                                *      */
        /*"      *             - DEMANDA CONFORMIDADE 2017 - CORRIGIR FALHA DE    *      */
        /*"      *               DATA DA EMISSAO MENOR QUE DATA DA PROPOSTA.      *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2017 - FRANK CARVALHO                               *      */
        /*"      *                                            PROCURE POR V.36    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 35 -                                                  *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTA VIGENCIA DO ENDOSSO                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.35    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 34 - CADMUS 152.341                                   *      */
        /*"      *                                                                *      */
        /*"      *             - FATURAR PARCELAS PAGAS APENAS PARA APOLICES EMITI*      */
        /*"      *               DAS, EVITANDO PAGAMENTO DE COMISSAO P/ CERTIFICA-*      */
        /*"      *               DOS DECLINADOS PELA SEGURADORA.                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/07/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.34    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 33 - CADMUS 152.347                                   *      */
        /*"      *                                                                *      */
        /*"      *             - CORRECAO NO SELECT DE OPCAO_PAG COM INIVIGENCIA  *      */
        /*"      *               POSTERIOR A DATA DE PAGAMENTO DA FATURA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/07/2017 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.33    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32 - CADMUS 142715                                    *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTA DIVERGENCIAS CADASTRADAS NA BASE DADOS.   *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/06/2017 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.32    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 31 - CADMUS 125115 - ABEND - DIVISAO POR ZERO         *      */
        /*"      *             - CR�TICA DO CAMPO V0PARC-OTNPRLIQ PARA CASO SEJA  *      */
        /*"      *   ZERO, DESVIE PARA GRAVACAO DE ERRO E N�O DIVIDA              *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/11/2015 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.31    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 30 - CADMUS 97223                                     *      */
        /*"      *             - AJUSTE NO PROCESSO R2100-00-TRATA-COBERAPOL      *      */
        /*"      *   A GECOL IDENTIFICOU QUE NO REGISTRO OFICIAL FOI LAN�ADO OS VAL      */
        /*"      *   ORES REFERENTE A AP�LICE 107700000007 NO RAMO 93 PARA OS ENDOS      */
        /*"      *   SOS 806740, 808144, 809461, 809506 E 810305                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/07/2014 - ALEXANDRE ANDRE                              *      */
        /*"      *                                            PROCURE POR V.30    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 29 - CADMUS 97244                                     *      */
        /*"      *             - RETIRADA DE DISPLAYS DESNECESSARIOS              *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2014 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.29    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28 - CADMUS 97244                                     *      */
        /*"      *                                                                *      */
        /*"      *             - VG0139B ERRO EXEC SQL NUMERO 1210 SQLCODE 811-   *      */
        /*"      *             - DESPREZA VERSAO V.27 IMPLANTADA EM 25/04/2014    *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/04/2014 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - CADMUS 95.972                                    *      */
        /*"      *                                                                *      */
        /*"      *           - ATENDIMENTO DA CIRC-SUSEP 360:                     *      */
        /*"      *             DATA DA PROPOSTA NAO PODE SER MAIOR QUE A DATA     *      */
        /*"      *             DE INICIO DE VIGENCIA NA TABELA DE ENDOSSOS        *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/04/2014 - RIBAMAR MARQUES                              *      */
        /*"      *                                            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 25 - CADMUS 89959                                     *      */
        /*"      *                                                                *      */
        /*"      *             - AJUSTA VIGENCIA DO ENDOSSO                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/11/2013 - CLOVIS                                       *      */
        /*"      *                                            PROCURE POR V.25    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 24 - CAD 85.017                                       *      */
        /*"      *                                                                *      */
        /*"      *             - DIVISAO DO VALOR DIT CONFORME CADASTRADO NA CIRC *      */
        /*"      *               SUSEP 395 NO RAMO 90 E MODALIDADE 05             *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/11/2013 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                            PROCURE POR V.24    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 23 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.23      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 22  - CAD 88.107                                      *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRAR CRITICA DE CODIGO DE OPERACAO           *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 - ELIERMES OLIVEIRA A PEDIDO DO CLOVIS         *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.22      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 21  - CAD 88.107                                      *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTE DA CRITICA DE AP�LICE COM VIG�NCIA       *      */
        /*"      *                VENCIDA. A DATA DE VENCIMENTO DA PARCELA        *      */
        /*"      *                DEVER� EST� NO PER�ODO DE VIG�NCIA DA AP�LICE   *      */
        /*"      *                PARA PAGAMENTO DE COMISS�ES.                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 20  - CAD 85.017                                      *      */
        /*"      *                                                                *      */
        /*"      *              - AJUSTA PROGRAMA NO CALCULO E INSERT DAS         *      */
        /*"      *                COBERTURAS.                                     *      */
        /*"      *              - AJUSTA PROGRAMA PARA PAGAMENTO DE COSSEGURO.    *      */
        /*"      *              - GERA ARQUIVO DE CRITICAS.                       *      */
        /*"      *                                                                *      */
        /*"      *              - ENTROU EM PRODUCAO EM 29/08/2013                *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2013 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.20         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 19  - CAD 84.799                                      *      */
        /*"      *                                                                *      */
        /*"      *              - DESABILITA FATURAMENTO DAS AP�LICES DO EMPRE-   *      */
        /*"      *                SARIAL GLOBAL NA ROTINA R0510-00-FETCH-HCTBVA   *      */
        /*"      *                                                                *      */
        /*"      *              - ENTROU EM PRODUCAO EM 01/08/2013                *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/08/2013 - BARDUCCO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 18  - CAD 85.251                                      *      */
        /*"      *                                                                *      */
        /*"      *              - REABILITA O FATURAMENTO DAS AP�LICES DO EMPRE-  *      */
        /*"      *                SARIAL GLOBAL NA ROTINA R0510-00-FETCH-HCTBVA   *      */
        /*"      *                                                                *      */
        /*"      *              - ENTROU EM PRODUCAO EM 25/07/2013                *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/07/2013 - BARDUCCO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 17  - CAD 84.799                                      *      */
        /*"      *                                                                *      */
        /*"      *              - CORRIGE TRANSACAO DE COMMIT                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2013 - BARDUCCO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16  - CAD 84.799                                      *      */
        /*"      *                                                                *      */
        /*"      *              - DESABILITA O FATURAMENTO DAS APOLICES DO EMPRE- *      */
        /*"      *                SARIAL GLOBAL NA ROTINA R0510-00-FETCH-HCTBVA   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/07/2013 - BARDUCCO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.17         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 16  - CAD 82.238                                      *      */
        /*"      *                                                                *      */
        /*"      *              - CORRECAO DO ABEND SQLCODE = -438 NA TABELA      *      */
        /*"      *                SEGUROS.V0ENDOSSO (A DATA DE INICIO DE VIGENCIA *      */
        /*"      *                NAO PODE SER MAIOR OU IGUAL A DATA DE TERVIGEN- *      */
        /*"      *                CIA.                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 13/05/2013 - FAST COMPUTER (MARCO PAIVA)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.16         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 15  - CAD 82.238                                      *      */
        /*"      *                                                                *      */
        /*"      *              - MONITORAR O PROGRAMA PARA TENTAR IDENTIFICAR    *      */
        /*"      *                O ERRO                                          *      */
        /*"      *                                                                (      */
        /*"      *   EM 09/05/2013 - FAST COMPUTER (MARCO PAIVA)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14  - CAD 80.793                                      *      */
        /*"      *                                                                *      */
        /*"      *              - CORRECAO DE DIFERENCA NO PERCENTUAL DE          *      */
        /*"      *                COBERTURA NA TABELA APOLICE_COBERTURAS          *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/04/2013 - FAST COMPUTER (EDIVALDO GOMES)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13  - CAD 78.386                                      *      */
        /*"      *                                                                *      */
        /*"      *              - MODIFICACAO NA FORMA DE OBTER O INICIO E        *      */
        /*"      *                TERMINO DE VIGENCIA PARA AS TABELAS ENDOSSOS    *      */
        /*"      *                E APOLICE_COBERTURAS                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/01/2013 - FAST COMPUTER (EDIVALDO GOMES)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12  - CAD 75.978                                      *      */
        /*"      *                                                                *      */
        /*"      *               - AJUSTE NA DATA DE INICIO DE VIGENCIA           *      */
        /*"      *                 PARA AS TABELAS ENDOSSOS E APOLICE_COBERTURAS  *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/11/2012 - FAST COMPUTER (EDIVALDO GOMES)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 11                                                    *      */
        /*"      *             - CAD 201.081 - AJUSTE PARA DISTRIBUIR O IOF       *      */
        /*"      *               PARA CADA RAMO ENCONTRADO.                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/07/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.11      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 10                                                    *      */
        /*"      *             - CAD 201.057                                      *      */
        /*"      *               AJUSTE NA DATA DE TERMINO DE VIGENCIA NA         *      */
        /*"      *               TABELA SEGUROS.ENDOSSOS                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/04/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 09                                                    *      */
        /*"      *             - CAD 201.020                                      *      */
        /*"      *               AJUSTE NA TABELA SEGUROS.APOLICE_COBERTURAS      *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/02/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 08                                                    *      */
        /*"      *             - CAD 48.762                                       *      */
        /*"      *               CIRCULAR SUSEP 395                               *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/12/2010 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                       PROCURE POR V.08         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07                                                    *      */
        /*"      *             - CAD 36.597                                       *      */
        /*"      *               OTIMIZA��O DO PROGRAMA POR CAUSAR GRANDE IMPACTO *      */
        /*"      *               NA DIARIA EM MOMENTO CRITICO                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/02/2010 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 - CAD 36.283                                       *      */
        /*"      *                                                                *      */
        /*"      *                 -ATIVAR DISPLAYS PARA MAPEAR O PROCESSAMENTO.  *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/01/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                   PROCURE POR V.06             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 03/10/2008 INCLUIR CLAUSULA WITH UR NO SELECT         - WV1008 *      */
        /*"      * 05/08/2008 INIBIR O COMANDO DISPLAY                   - WV0808 *      */
        /*"      * 27/11/2008 INCLUIR WITH UR (SEGUROS.V0SUBGRUPO  )     - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (SEGUROS.V0OPCAOPAGVA)     - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (SEGUROS.V1RCAPCOMP )      - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (SEGUROS.V0RCAP )          - WV1108 *      */
        /*"      * 27/11/2008 RETIRAR WITH UR (SEGUROS.V1NUMERO_COSSEGURO) WV1108 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 005 - 04/06/2008 - FAST COMPUTER (SSI 10.967)                  *      */
        /*"      *       AJUSTE NO PROGRAMA PARA NAO GERACAO DE ENDOSSO QUANDO OS *      */
        /*"      *       PREMIOS ESTAO ZERADOS.                                   *      */
        /*"      *                                             PROCURE POR V.05   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 004 - 08/09/2007 - FAST COMPUTER (SSI 18.145/2007)             *      */
        /*"      *                             NAO PERMITE A GERACAO DE ENDOSSOS  *      */
        /*"      *                             COM VIGENCIA ANTERIOR A DA APOLICE *      */
        /*"      *                                             PROCURE POR V.04   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 003 - 29/01/2004 - MANOEL MESSIAS                              *      */
        /*"      *                             GERAR NA COBERAPOL O RAMO 82 NO LU-*      */
        /*"      *                             GAR DO RAMO 81.                    *      */
        /*"      *                                             PROCURE POR MM2904 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 002 - 02/08/2002 - FREDERICO / MESSIAS                         *      */
        /*"      *                             CORRECAO NO CALCULO DOS PERCENTUAIS*      */
        /*"      *                             DE COBERTURA E PREMIOS DO RAMO 81  *      */
        /*"      *                             PARA EVITAR A GERACAO DE PREMIOS/CO*      */
        /*"      *                             BETURAS NEGATIVOS PARA A DIT.      *      */
        /*"      *                                             PROCURE POR MF0208 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 001 - 31/07/2002 - MANOEL MESSIAS                              *      */
        /*"      *   EXISTE NO PRODUTO EMPRESARIAL ALGUNS SUBGRUPOS QUE POSSUI    *      */
        /*"      * SOMENTE VG OU AP. E O PROGRAMA NAO ESTAVA PREPARADO PARA ESTE  *      */
        /*"      * TIPO DE COBERTURA.                                             *      */
        /*"      *                                             PROCURE POR MM3107 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      *------------------------------------ ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * HISTORICO CONTABIL DE PARCELAS VA   V0HISTCONTABILVA  I-O      *      */
        /*"      * FONTES PRODUTORAS                   V1FONTE           I-O      *      */
        /*"      * APOLICES                            V0APOLICE         INPUT    *      */
        /*"      * ENDOSSOS                            V0ENDOSSO         OUTPUT   *      */
        /*"      * APOLICE COSSEGURO                   V1APOLCOSCED      INPUT    *      */
        /*"      * PARCELAS                            V0PARCELA         OUTPUT   *      */
        /*"      * HISTORICO DE PARCELAS               V0HISTOPARC       OUTPUT   *      */
        /*"      * COBERTURA APOLICES                  V0COBERAPOL       OUTPUT   *      */
        /*"      * ORDEM COSSEGURO CEDIDO              V0ORDECOSCED      OUTPUT   *      */
        /*"      * NUMERACAO GERAL                     V0NUMERO_AES      I-O      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _VG0139B1 { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis VG0139B1
        {
            get
            {
                _.Move(REG_VG0139B1, _VG0139B1); VarBasis.RedefinePassValue(REG_VG0139B1, _VG0139B1, REG_VG0139B1); return _VG0139B1;
            }
        }
        public SortBasis<VG0139B_REG_SVG0139B> SVG0139B { get; set; } = new SortBasis<VG0139B_REG_SVG0139B>(new VG0139B_REG_SVG0139B());
        /*"01            REG-SVG0139B.*/
        public VG0139B_REG_SVG0139B REG_SVG0139B { get; set; } = new VG0139B_REG_SVG0139B();
        public class VG0139B_REG_SVG0139B : VarBasis
        {
            /*"    05        SVA-SITUACAO        PIC  X(001).*/
            public StringBasis SVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-NUM-APOLICE     PIC S9(013)    COMP-3.*/
            public IntBasis SVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        SVA-CODSUBES        PIC S9(004)    COMP.*/
            public IntBasis SVA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-FONTE           PIC S9(004)    COMP.*/
            public IntBasis SVA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-PRMVG           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-PRMAP           PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05        SVA-CODOPER         PIC S9(004)    COMP.*/
            public IntBasis SVA_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-NRCERTIF        PIC S9(015)    COMP-3.*/
            public IntBasis SVA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        SVA-NRPARCEL        PIC S9(004)    COMP.*/
            public IntBasis SVA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-NRTIT           PIC S9(013)    COMP-3.*/
            public IntBasis SVA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        SVA-OCORHIST        PIC S9(004)    COMP.*/
            public IntBasis SVA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-DTMOVTO         PIC  X(010).*/
            public StringBasis SVA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-DTQITBCO        PIC  X(010).*/
            public StringBasis SVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-CODCLIEN        PIC S9(009)    COMP.*/
            public IntBasis SVA_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SVA-ESTR-COBR       PIC  X(010).*/
            public StringBasis SVA_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-ORIG-PRODU      PIC  X(010).*/
            public StringBasis SVA_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-IND-IOF         PIC  X(001).*/
            public StringBasis SVA_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05        SVA-CODPRODU        PIC S9(004)    COMP.*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-OCORHIST1       PIC S9(004)    COMP.*/
            public IntBasis SVA_OCORHIST1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-DTPROXVEN       PIC  X(010).*/
            public StringBasis SVA_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-SITPROPOS       PIC  X(001).*/
            public StringBasis SVA_SITPROPOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01        REG-VG0139B1              PIC  X(350).*/
        }
        public StringBasis REG_VG0139B1 { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"*/
        public IntBasis WS_COB00 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB05 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_COB11 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01              V1RIND-RAMO           PIC S9(004)      COMP.*/
        public IntBasis V1RIND_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              V1RIND-DTINIVIG       PIC  X(010).*/
        public StringBasis V1RIND_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              V1RIND-PCIOF          PIC S9(003)V99   COMP-3.*/
        public DoubleBasis V1RIND_PCIOF { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01              WS-DTRENOVA           PIC X(010).*/
        public StringBasis WS_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              WS-DTINIVIG           PIC X(010).*/
        public StringBasis WS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01              WS-TIME               PIC  X(008).*/
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         VIND-DATARCAP       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DATARCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-DTQITBCO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-DTVENCTO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_DTVENCTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-VLCUSEMI       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_VLCUSEMI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-CFPREFIX       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_CFPREFIX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         VIND-SITUACAO       PIC S9(004)   VALUE +0     COMP.*/
        public IntBasis VIND_SITUACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         WHOST-CODSUBES       PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01         WHOST-NRPARCEL       PIC S9(04) COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01         WHOST-NRCERTIF       PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01         WHOST-NRTIT          PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01         WHOST-DTINIVIG       PIC  X(10).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         WHOST-DTTERVIG       PIC  X(10).*/
        public StringBasis WHOST_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         V0COBP-DTINIVIG-ENDO PIC  X(10).*/
        public StringBasis V0COBP_DTINIVIG_ENDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         V0COBP-DTTERVIG-ENDO PIC  X(10).*/
        public StringBasis V0COBP_DTTERVIG_ENDO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         V0COBP-NRCERTIF      PIC S9(015)     VALUE +0 COMP-3.*/
        public IntBasis V0COBP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0COBP-OCORHIST      PIC S9(004) COMP.*/
        public IntBasis V0COBP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         NUM-SICOB            PIC S9(15) COMP-3.*/
        public IntBasis NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01         WHOST-DTINIVIG1      PIC  X(10).*/
        public StringBasis WHOST_DTINIVIG1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         WHOST-DTTERVIG1      PIC  X(10).*/
        public StringBasis WHOST_DTTERVIG1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         WHOST-DTINIVIG2      PIC  X(10).*/
        public StringBasis WHOST_DTINIVIG2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         WHOST-DTTERVIG2      PIC  X(10).*/
        public StringBasis WHOST_DTTERVIG2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01         WTEM-VIGENCIA        PIC  X(001).*/
        public StringBasis WTEM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         WHOST-DTENDFIM       PIC  X(10).*/
        public StringBasis WHOST_DTENDFIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-CODUSU               PIC X(8).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  V0RELA-DATA-SOLICITACAO     PIC X(10).*/
        public StringBasis V0RELA_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-IDSISTEM             PIC X(2).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"01  V0RELA-CODRELAT             PIC X(8).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"01  V0RELA-NRCOPIAS             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-QUANTIDADE           PIC S9(04) COMP.*/
        public IntBasis V0RELA_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PERI-INICIAL         PIC X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-PERI-FINAL           PIC X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-DATA-REFERENCIA      PIC X(10).*/
        public StringBasis V0RELA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RELA-MES-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-ANO-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-ORGAO                PIC S9(04) COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-MODALIDA             PIC S9(04) COMP.*/
        public IntBasis V0RELA_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CONGENER             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NRCERTIF             PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-NRTIT                PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-CODSUBES             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-COD-PLANO            PIC S9(04) COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-OCORHIST             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-APOLIDER             PIC X(15).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-ENDOSLID             PIC X(15).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-NUM-PARC-LIDER       PIC S9(04) COMP.*/
        public IntBasis V0RELA_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-NUM-SINISTRO         PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0RELA-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis V0RELA_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"01  V0RELA-NUM-ORDEM            PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0RELA-CODUNIMO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-CORRECAO             PIC X(1).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-SITUACAO             PIC X(1).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-PREVIA-DEFINITIVA    PIC X(1).*/
        public StringBasis V0RELA_PREVIA_DEFINITIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-ANAL-RESUMO          PIC X(1).*/
        public StringBasis V0RELA_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"01  V0RELA-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0RELA-PERI-RENOVACAO       PIC S9(04) COMP.*/
        public IntBasis V0RELA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0RELA-PCT-AUMENTO          PIC S9(3)V9(2) COMP-3.*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"01  V0RELA-TIMESTAMP            PIC X(26).*/
        public StringBasis V0RELA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01         V1SIST-DTMOVABE     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTCURRENT    PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SIST-DTMOVACB     PIC  X(010).*/
        public StringBasis V1SIST_DTMOVACB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HCTB-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0HCTB-NRPARCEL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HCTB-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCTB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HCTB-CODSUBES     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-FONTE        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-PRMVG        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0HCTB_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0HCTB-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0HCTB_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0HCTB-DTMOVTO      PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCTB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCTB-SITUACAO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0HCTB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0HCTB-CODOPER      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HCTB-DTMOVTO-ANT  PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCTB_DTMOVTO_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCTB-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HCTB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-DTVENCTO     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCOB-DTVENCTO     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0HCOB-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0OPCP-PERIPGTO     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-RAMO         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-ORGAO        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0APOL-MODALIDA     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0SUBG-DTINIVIG     PIC  X(010)      VALUE SPACES.*/
        public StringBasis V0SUBG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0SUBG-DTINIVIG-I   PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0SUBG_DTINIVIG_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0SUBG-IND-IOF      PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0SUBG_IND_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0SUBG-NUM-APOLICE  PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0SUBG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PROP-NRCERTIF     PIC S9(015)      VALUE +0 COMP-3.*/
        public IntBasis V0PROP_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0PROP-CODPRODU     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-CODCLIEN     PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PROP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PROP-OCORHIST     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PROP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PROP-DTPROXVEN    PIC  X(010).*/
        public StringBasis V0PROP_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PROP-SITUACAO     PIC  X(001)      VALUE SPACES.*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01         V0COND-IEA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IEA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPA          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0COND-IPD          PIC S9(003)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COND_IPD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01         V0PLAN-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0PLAN-IPRMDIT      PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0PLAN_IPRMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PLAN-PRMAP        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0PLAN_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAMDS      PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPDH        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-PRMDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-PRMDIT-I     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V0CBPR_PRMDIT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0CBPR-IMPCDG       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAA        PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPAAF       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPAAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V0CBPR-IMPADE       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0CBPR_IMPADE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1FONT-PROPAUTOM    PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1FONT_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V1RCAP-VLRCAP       PIC S9(013)V99    VALUE +0 COMP-3*/
        public DoubleBasis V1RCAP_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01         V1RCAP-DATARCAP     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V1RCAP_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V1COSP-CONGENER     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1COSP_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-NUM-APOLICE  PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0ENDO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0ENDO-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-CODSUBES     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-NRPROPOS     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-DATPRO       PIC  X(010).*/
        public StringBasis V0ENDO_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DT-LIBER     PIC  X(010).*/
        public StringBasis V0ENDO_DT_LIBER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DTEMIS       PIC  X(010).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-VLRCAP       PIC S9(013)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
        /*"01         V0ENDO-BCORCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-AGERCAP      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-DACRCAP      PIC  X(001).*/
        public StringBasis V0ENDO_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-IDRCAP       PIC  X(001).*/
        public StringBasis V0ENDO_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-DACCOBR      PIC  X(001).*/
        public StringBasis V0ENDO_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-DTINIVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-DTTERVIG     PIC  X(010).*/
        public StringBasis V0ENDO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-CDFRACIO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-PCENTRAD     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"01         V0ENDO-PCADICIO     PIC S9(003)V9(02) VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(02)"), 2);
        /*"01         V0ENDO-PRESTA1      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTPRESTA     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-QTITENS      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-CODTXT       PIC  X(003).*/
        public StringBasis V0ENDO_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
        /*"01         V0ENDO-CDACEITA     PIC  X(001).*/
        public StringBasis V0ENDO_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-MOEDA-IMP    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-MOEDA-PRM    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-TIPO-ENDO    PIC  X(001).*/
        public StringBasis V0ENDO_TIPO_ENDO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-COD-USUAR    PIC  X(008).*/
        public StringBasis V0ENDO_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0ENDO-OCORR-END    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-SITUACAO     PIC  X(001).*/
        public StringBasis V0ENDO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-DATARCAP     PIC  X(010).*/
        public StringBasis V0ENDO_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0ENDO-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ENDO-CORRECAO     PIC  X(001).*/
        public StringBasis V0ENDO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-ISENTA-CST   PIC  X(001).*/
        public StringBasis V0ENDO_ISENTA_CST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0ENDO-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ENDO_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0ENDO-DTVENCTO     PIC  X(010)       VALUE  SPACES.*/
        public StringBasis V0ENDO_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01         V0ENDO-CFPREFIX     PIC S9(004)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"01         V0ENDO-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0ENDO_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0ENDO-RAMO         PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ENDO-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0ENDO_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0RCAP-NRRCAP       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0RCAP_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0RCAP-SITUACAO     PIC  X(001).*/
        public StringBasis V0RCAP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
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
        /*"01         V1NCOS-CONGENER     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-ORGAO        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V1NCOS-NRORDEM      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V1NCOS_NRORDEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-DACPARC      PIC  X(001).*/
        public StringBasis V0PARC_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PARC-FONTE        PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-NRTIT        PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0PARC_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0PARC-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-VAL-DES-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNPRLIQ     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNADFRA     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNCUSTO     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNCUSTO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNIOF       PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNIOF { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OTNTOTAL     PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0PARC_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0PARC-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-QTDDOC       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PARC_QTDDOC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PARC-SITUACAO     PIC  X(001).*/
        public StringBasis V0PARC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0PARC-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0PARC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0PARC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0PARC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0PARC-SIT-COBR     PIC  X(001).*/
        public StringBasis V0PARC_SIT_COBR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0HISP-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRPARCEL     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-DACPARC      PIC  X(001).*/
        public StringBasis V0HISP_DACPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-DTMOVTO      PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-OPERACAO     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-PRM-TARIFA   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_PRM_TARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VAL-DESCON   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VAL_DESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPRMLIQ     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLADIFRA     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLCUSEMI     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLIOCC       PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPRMTOT     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-VLPREMIO     PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0HISP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0HISP-DTVENCTO     PIC  X(010).*/
        public StringBasis V0HISP_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-BCOCOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-AGECOBR      PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0HISP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0HISP-NRAVISO      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-NRENDOCA     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_NRENDOCA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-SITCONTB     PIC  X(001).*/
        public StringBasis V0HISP_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         V0HISP-COD-USUAR    PIC  X(008).*/
        public StringBasis V0HISP_COD_USUAR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01         V0HISP-RNUDOC       PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_RNUDOC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-DTQITBCO     PIC  X(010).*/
        public StringBasis V0HISP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0HISP-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0HISP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0HISP-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0HISP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V1SEGVG-DTINIVIG    PIC  X(010).*/
        public StringBasis V1SEGVG_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SEGVG-DTRENOVA    PIC  X(010).*/
        public StringBasis V1SEGVG_DTRENOVA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V1SEGVG-DTRENOVA-IND PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis V1SEGVG_DTRENOVA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-NUM-APOL     PIC S9(013)       VALUE +0 COMP-3*/
        public IntBasis V0COBA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0COBA-NRENDOS      PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-NUM-ITEM     PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-OCORHIST     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-RAMOFR       PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_RAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-MODALIFR     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_MODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-COD-COBER    PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-IMP-SEG-IX   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0COBA-PRM-TAR-IX   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0COBA-IMP-SEG-VR   PIC S9(013)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_IMP_SEG_VR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01         V0COBA-PRM-TAR-VR   PIC S9(010)V9(5)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PRM_TAR_VR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01         V0COBA-PCT-COBERT   PIC S9(003)V9(2)  VALUE +0 COMP-3*/
        public DoubleBasis V0COBA_PCT_COBERT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(2)"), 2);
        /*"01         V0COBA-FATOR-MULT   PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0COBA_FATOR_MULT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0COBA-DATA-INIVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0COBA-DATA-TERVI   PIC  X(010).*/
        public StringBasis V0COBA_DATA_TERVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0COBA-COD-EMPRESA  PIC S9(009)       VALUE +0 COMP.*/
        public IntBasis V0COBA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0COBA-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0COBA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0COBA-SITUACAO     PIC  X(001)       VALUE '0'.*/
        public StringBasis V0COBA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"0");
        /*"01         V0ORDC-NUM-APOL     PIC S9(013)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01         V0ORDC-NRENDOS      PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ORDC-CODCOSS      PIC S9(004)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_CODCOSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0ORDC-ORDEM-CED    PIC S9(015)      VALUE +0  COMP-3*/
        public IntBasis V0ORDC_ORDEM_CED { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01         V0ORDC-COD-EMPRESA  PIC S9(009)      VALUE +0  COMP.*/
        public IntBasis V0ORDC_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01         V0ORDC-TIMESTAMP    PIC  X(026).*/
        public StringBasis V0ORDC_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
        /*"01         V0PRVG-ESTR-COBR    PIC  X(010).*/
        public StringBasis V0PRVG_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PRVG-ORIG-PRODU   PIC  X(010).*/
        public StringBasis V0PRVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01         V0PRVG-CODPRODU     PIC S9(004)       VALUE +0 COMP.*/
        public IntBasis V0PRVG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01         V0PRVF-NRTIT        PIC S9(013)      VALUE +0 COMP-3.*/
        public IntBasis V0PRVF_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0EDIA-CODRELAT            PIC  X(008).*/
        public StringBasis V0EDIA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  V0EDIA-NUM-APOL            PIC S9(013)               COMP-3.*/
        public IntBasis V0EDIA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  V0EDIA-NRENDOS             PIC S9(009)               COMP.*/
        public IntBasis V0EDIA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  V0EDIA-NRPARCEL            PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-DTMOVTO             PIC  X(010).*/
        public StringBasis V0EDIA_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  V0EDIA-ORGAO               PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-RAMO                PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-FONTE               PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-CONGENER            PIC S9(004)               COMP.*/
        public IntBasis V0EDIA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  V0EDIA-CODCORR             PIC S9(009)               COMP.*/
        public IntBasis V0EDIA_CODCORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WS-CNT-RELEASE             PIC  9(008) VALUE ZEROS.*/
        public IntBasis WS_CNT_RELEASE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
        /*"01  V0EDIA-SITUACAO            PIC  X(001).*/
        public StringBasis V0EDIA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01         TABELA-RAMO.*/
        public VG0139B_TABELA_RAMO TABELA_RAMO { get; set; } = new VG0139B_TABELA_RAMO();
        public class VG0139B_TABELA_RAMO : VarBasis
        {
            /*"  05       FILLER               OCCURS 100 TIMES.*/
            public ListBasis<VG0139B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<VG0139B_FILLER_0>(100);
            public class VG0139B_FILLER_0 : VarBasis
            {
                /*"    10     TB-RAMO-VALOR-IS     PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    10     TB-RAMO-VALOR-PRM    PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"01         TABELA-RAMO-R.*/
            }
        }
        public VG0139B_TABELA_RAMO_R TABELA_RAMO_R { get; set; } = new VG0139B_TABELA_RAMO_R();
        public class VG0139B_TABELA_RAMO_R : VarBasis
        {
            /*"  05       FILLER               OCCURS 100 TIMES.*/
            public ListBasis<VG0139B_FILLER_1> FILLER_1 { get; set; } = new ListBasis<VG0139B_FILLER_1>(100);
            public class VG0139B_FILLER_1 : VarBasis
            {
                /*"    10     TB-RAMO-VALOR-IS-R   PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_IS_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"    10     TB-RAMO-VALOR-PRM-R  PIC S9(13)V99 COMP-3.*/
                public DoubleBasis TB_RAMO_VALOR_PRM_R { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
                /*"01         TABELA-ULTIMOS-DIAS.*/
            }
        }
        public VG0139B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VG0139B_TABELA_ULTIMOS_DIAS();
        public class VG0139B_TABELA_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
            /*"01         TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
        }
        private _REDEF_VG0139B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
        public _REDEF_VG0139B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
        {
            get { _tab_ultimos_dias = new _REDEF_VG0139B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
            set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
        }  //Redefines
        public class _REDEF_VG0139B_TAB_ULTIMOS_DIAS : VarBasis
        {
            /*"  05       TAB-DIA-MESES        OCCURS 12.*/
            public ListBasis<VG0139B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VG0139B_TAB_DIA_MESES>(12);
            public class VG0139B_TAB_DIA_MESES : VarBasis
            {
                /*"    10     TAB-DIA-MES          PIC 9(002).*/
                public IntBasis TAB_DIA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           AREA-DE-WORK.*/

                public VG0139B_TAB_DIA_MESES()
                {
                    TAB_DIA_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0139B_TAB_ULTIMOS_DIAS()
            {
                TAB_DIA_MESES.ValueChanged += OnValueChanged;
            }

        }
        public VG0139B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0139B_AREA_DE_WORK();
        public class VG0139B_AREA_DE_WORK : VarBasis
        {
            /*" 05             WS-DTBASE.*/
            public VG0139B_WS_DTBASE WS_DTBASE { get; set; } = new VG0139B_WS_DTBASE();
            public class VG0139B_WS_DTBASE : VarBasis
            {
                /*"   10           WS-DTBASE-AM.*/
                public VG0139B_WS_DTBASE_AM WS_DTBASE_AM { get; set; } = new VG0139B_WS_DTBASE_AM();
                public class VG0139B_WS_DTBASE_AM : VarBasis
                {
                    /*"     15         WS-AABASE             PIC 9(004).*/
                    public IntBasis WS_AABASE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMBASE             PIC 9(002).*/
                    public IntBasis WS_MMBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDBASE             PIC 9(002).*/
                public IntBasis WS_DDBASE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DTFATUR.*/
            }
            public VG0139B_WS_DTFATUR WS_DTFATUR { get; set; } = new VG0139B_WS_DTFATUR();
            public class VG0139B_WS_DTFATUR : VarBasis
            {
                /*"   10           WS-DTFATUR-AM.*/
                public VG0139B_WS_DTFATUR_AM WS_DTFATUR_AM { get; set; } = new VG0139B_WS_DTFATUR_AM();
                public class VG0139B_WS_DTFATUR_AM : VarBasis
                {
                    /*"     15         WS-AAFATUR            PIC 9(004).*/
                    public IntBasis WS_AAFATUR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15         FILLER                PIC X(001).*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"     15         WS-MMFATUR            PIC 9(002).*/
                    public IntBasis WS_MMFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   10           FILLER                PIC X(001).*/
                }
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10           WS-DDFATUR            PIC 9(002).*/
                public IntBasis WS_DDFATUR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*" 05             WS-DIA                PIC 9(002).*/
            }
            public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         AC-FATURA                PIC X(001)  VALUE SPACES.*/
            public StringBasis AC_FATURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-PROPOVA             PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0HISTCONTABILVA    PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V0HISTCONTABILVA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V1RCAP              PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V1RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-VG082               PIC X(003)  VALUE SPACES.*/
            public StringBasis WTEM_VG082 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WTEM-V0RCAP              PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_V0RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-CONVERSAO           PIC X(001)  VALUE SPACES.*/
            public StringBasis WTEM_CONVERSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WTEM-RAMO-CONJ           PIC X(003)  VALUE SPACES.*/
            public StringBasis WTEM_RAMO_CONJ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WTEM-RAMO-COMP           PIC X(003)  VALUE SPACES.*/
            public StringBasis WTEM_RAMO_COMP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WFIM-V0PROPOSTAVA        PIC 9(001)  VALUE 0.*/
            public IntBasis WFIM_V0PROPOSTAVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05         WS-PRMVG               PIC ---------------9,99.*/
            public DoubleBasis WS_PRMVG { get; set; } = new DoubleBasis(new PIC("9", "16", "---------------9V99."), 2);
            /*"  05         WS-PRMAP               PIC ---------------9,99.*/
            public DoubleBasis WS_PRMAP { get; set; } = new DoubleBasis(new PIC("9", "16", "---------------9V99."), 2);
            /*"  05         WS-APOLICE-ANT         PIC S9(13)   COMP-3 VALUE +0*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-SUBGRUPO-ANT        PIC S9(04)   COMP   VALUE +0*/
            public IntBasis WS_SUBGRUPO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NUM-APOLICE-ANT     PIC S9(13)   COMP-3.*/
            public IntBasis WS_NUM_APOLICE_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-CODSUBES-ANT        PIC S9(04)   COMP.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NRPARCEL-ANT        PIC S9(04)   COMP.*/
            public IntBasis WS_NRPARCEL_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-NRCERTIF-ANT        PIC S9(15)   COMP-3.*/
            public IntBasis WS_NRCERTIF_ANT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"  05         WS-NRTIT-ANT           PIC S9(13)   COMP-3.*/
            public IntBasis WS_NRTIT_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"  05         WS-FONTE-ANT           PIC S9(04)   COMP.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05         WS-IND-IOF             PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis WS_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"  05         WS-IND                 PIC S9(004)     COMP.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WS-IND1                PIC S9(004)     COMP.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WS-VLIOCC              PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-VG           PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-AP           PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-DIT          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-RTO          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-VG       PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-AP       PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-DIT      PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-VLIOCC-TOT-RTO      PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_VLIOCC_TOT_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PREMIO-LIQ          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PREMIO_LIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-AP          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-VG          PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-DIT         PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRM-LIQ-RTO         PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRM_LIQ_RTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-ACUM-IND            PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_ACUM_IND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-ACUM-PRM            PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_ACUM_PRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-ACUM-IOF            PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_ACUM_IOF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-IOF-RAMO            PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_IOF_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-IMPRTO              PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_IMPRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05         WS-PRMRTO              PIC S9(13)V99   COMP-3.*/
            public DoubleBasis WS_PRMRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05    AC-IND             PIC S9(004)    COMP   VALUE ZEROES.*/
            public IntBasis AC_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05    AC-VALPRM          PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_VALPRM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05    WSHOST-PRM-TAR-IX  PIC S9(010)V9(5)  VALUE +0 COMP-3.*/
            public DoubleBasis WSHOST_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05    WS-PERTOT          PIC S9(13)V99  COMP-3 VALUE ZEROES.*/
            public DoubleBasis WS_PERTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"  05    GV-ARQSAI1         PIC  9(009)           VALUE ZEROS.*/
            public IntBasis GV_ARQSAI1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05    DP-EMISSAO         PIC  9(009)           VALUE ZEROS.*/
            public IntBasis DP_EMISSAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05    DP-OPERACAO        PIC  9(009)           VALUE ZEROS.*/
            public IntBasis DP_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05    DP-VALOR           PIC  9(009)           VALUE ZEROS.*/
            public IntBasis DP_VALOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05    WS-VALOR           PIC S9(013)V99   VALUE +0 COMP-3.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         WWORK-NUM-ORDEM   PIC  9(014)    VALUE ZEROS.*/
            public IntBasis WWORK_NUM_ORDEM { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05         FILLER            REDEFINES      WWORK-NUM-ORDEM.*/
            private _REDEF_VG0139B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG0139B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG0139B_FILLER_7(); _.Move(WWORK_NUM_ORDEM, _filler_7); VarBasis.RedefinePassValue(WWORK_NUM_ORDEM, _filler_7, WWORK_NUM_ORDEM); _filler_7.ValueChanged += () => { _.Move(_filler_7, WWORK_NUM_ORDEM); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WWORK_NUM_ORDEM); }
            }  //Redefines
            public class _REDEF_VG0139B_FILLER_7 : VarBasis
            {
                /*"    10       WWORK-ORD-CONGE   PIC  9(004).*/
                public IntBasis WWORK_ORD_CONGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WWORK-ORD-ORGAO   PIC  9(003).*/
                public IntBasis WWORK_ORD_ORGAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WWORK-ORD-SEQUE   PIC  9(007).*/
                public IntBasis WWORK_ORD_SEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"  05         WWORK-DATA.*/

                public _REDEF_VG0139B_FILLER_7()
                {
                    WWORK_ORD_CONGE.ValueChanged += OnValueChanged;
                    WWORK_ORD_ORGAO.ValueChanged += OnValueChanged;
                    WWORK_ORD_SEQUE.ValueChanged += OnValueChanged;
                }

            }
            public VG0139B_WWORK_DATA WWORK_DATA { get; set; } = new VG0139B_WWORK_DATA();
            public class VG0139B_WWORK_DATA : VarBasis
            {
                /*"    10       WWORK-ANO         PIC  9(004).*/
                public IntBasis WWORK_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-MES         PIC  9(002).*/
                public IntBasis WWORK_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10       WWORK-DIA         PIC  9(002).*/
                public IntBasis WWORK_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATA-SISTEMA.*/
            }
            public VG0139B_WDATA_SISTEMA WDATA_SISTEMA { get; set; } = new VG0139B_WDATA_SISTEMA();
            public class VG0139B_WDATA_SISTEMA : VarBasis
            {
                /*"    10       WDATA-SIS-ANO     PIC  X(004).*/
                public StringBasis WDATA_SIS_ANO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-MES     PIC  X(002).*/
                public StringBasis WDATA_SIS_MES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-SIS-DIA     PIC  X(002).*/
                public StringBasis WDATA_SIS_DIA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WS-DATE.*/
            }
            public VG0139B_WS_DATE WS_DATE { get; set; } = new VG0139B_WS_DATE();
            public class VG0139B_WS_DATE : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-INIVIGENCIA.*/
            }
            public VG0139B_WS_DATA_INIVIGENCIA WS_DATA_INIVIGENCIA { get; set; } = new VG0139B_WS_DATA_INIVIGENCIA();
            public class VG0139B_WS_DATA_INIVIGENCIA : VarBasis
            {
                /*"    10       WDATA-AA-INIV     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_INIV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-INIV     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-INIV     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_INIV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WS-DATA-QUITACAO.*/
            }
            public VG0139B_WS_DATA_QUITACAO WS_DATA_QUITACAO { get; set; } = new VG0139B_WS_DATA_QUITACAO();
            public class VG0139B_WS_DATA_QUITACAO : VarBasis
            {
                /*"    10       WDATA-AA-QUIT     PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WDATA_AA_QUIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-MM-QUIT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_MM_QUIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WDATA-DD-QUIT     PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WDATA_DD_QUIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public VG0139B_WDATA_CABEC WDATA_CABEC { get; set; } = new VG0139B_WDATA_CABEC();
            public class VG0139B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         AC-APOLICES-NOK PIC  9(008)         VALUE ZEROS.*/
            }
            public IntBasis AC_APOLICES_NOK { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-PRMVG      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMAP      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMDIT     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-PRMRTO     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_PRMRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPCDG     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPAA      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPAA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPADE     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPADE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPAAF     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPAAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPMORNATU PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPMORACID PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPINVPERM PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPAMDS    PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPDH      PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPDIT     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-IMPRTO     PIC S9(013)V99 COMP-3 VALUE ZEROES.*/
            public DoubleBasis AC_IMPRTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05         AC-CONTA                PIC  9(005)   VALUE ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         AC-L-SORT               PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_L_SORT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-L-V0HISTCONT         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTCONT { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0ENDOSSO          PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ENDOSSO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0RCAPCOMP         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0ORDECOSCED       PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0ORDECOSCED { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0EMISDIARIA       PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0EMISDIARIA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0PARCELA          PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0PARCELA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0HISTOPARC        PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-I-V0COBERAPOL        PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_I_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0COBERAPOL        PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0COBERAPOL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0RCAP             PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0RCAPCOMP         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0RCAPCOMP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0NUMERAES         PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERAES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0FONTE            PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0FONTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0HISTCONTABILVA   PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0HISTCONTABILVA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         AC-U-V0NUMERO-COSSEGURO PIC  9(008)   VALUE ZEROS.*/
            public IntBasis AC_U_V0NUMERO_COSSEGURO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05        WABEND.*/
            public VG0139B_WABEND WABEND { get; set; } = new VG0139B_WABEND();
            public class VG0139B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VG0139B '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VG0139B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"01  ARQUIVOS-SAIDA.*/
            }
        }
        public VG0139B_ARQUIVOS_SAIDA ARQUIVOS_SAIDA { get; set; } = new VG0139B_ARQUIVOS_SAIDA();
        public class VG0139B_ARQUIVOS_SAIDA : VarBasis
        {
            /*"  03    LC01.*/
            public VG0139B_LC01 LC01 { get; set; } = new VG0139B_LC01();
            public class VG0139B_LC01 : VarBasis
            {
                /*"        10  FILLER          PIC  X(015) VALUE                          'CERTIFICADO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"CERTIFICADO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(007) VALUE                          'PARCELA'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PARCELA");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(013) VALUE                          'TITULO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"TITULO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(008) VALUE                          'OCORHIST'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OCORHIST");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(013) VALUE                          'APOLICE'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"APOLICE");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(008) VALUE                          'SUBGRUPO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SUBGRUPO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(005) VALUE                          'FONTE'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(007) VALUE                          'PRODUTO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PRODUTO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(009) VALUE                          'CLIENTE'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CLIENTE");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'DTMOVTO  '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTMOVTO  ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'DTQITBCO '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTQITBCO ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'DTPROXVEN'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTPROXVEN");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(008) VALUE                          'OCORHIST'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OCORHIST");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(008) VALUE                          'OPERACAO'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"OPERACAO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(015) VALUE                          'PREMIO VG'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO VG");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(015) VALUE                          'PREMIO AP'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PREMIO AP");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'ESTR-COBR '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ESTR-COBR ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'ORIG-PRODU'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ORIG-PRODU");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'DTVENCTO '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTVENCTO ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'DTINIVIG '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTINIVIG ");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(010) VALUE                          'DTINIVIG1'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTINIVIG1");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(008) VALUE                          'SITUACAO'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SITUACAO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(040) VALUE                          'OBSERVACAO'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"OBSERVACAO");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(025)           VALUE    ' '.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @" ");
                /*"  03        LD01.*/
            }
            public VG0139B_LD01 LD01 { get; set; } = new VG0139B_LD01();
            public class VG0139B_LD01 : VarBasis
            {
                /*"        10  LD01-NRCERTIF   PIC  9(015)           VALUE  ZEROS.*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-NRPARCEL   PIC  9(007)           VALUE  ZEROS.*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-NRTIT      PIC  9(013)           VALUE  ZEROS.*/
                public IntBasis LD01_NRTIT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-OCORHIST1  PIC  9(008)           VALUE  ZEROS.*/
                public IntBasis LD01_OCORHIST1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-NUMAPOL    PIC  9(013)           VALUE  ZEROS.*/
                public IntBasis LD01_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-CODSUBES   PIC  9(008)           VALUE  ZEROS.*/
                public IntBasis LD01_CODSUBES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-FONTE      PIC  9(005)           VALUE  ZEROS.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-CODPRODU   PIC  9(007)           VALUE  ZEROS.*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-CODCLIEN   PIC  9(009)           VALUE  ZEROS.*/
                public IntBasis LD01_CODCLIEN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTMOVTO    PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTQITBCO   PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTPROXVEN  PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_DTPROXVEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-OCORHIST2  PIC  9(008)           VALUE  ZEROS.*/
                public IntBasis LD01_OCORHIST2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-OPERACAO   PIC  9(008)           VALUE  ZEROS.*/
                public IntBasis LD01_OPERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-PRMVG      PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRMVG { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-PRMAP      PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_PRMAP { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-ESTR-COBR  PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-ORIG-PRODU PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTVENCTO   PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTINIVIG   PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-DTINIVIG1  PIC  X(010)           VALUE  SPACES.*/
                public StringBasis LD01_DTINIVIG1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  LD01-SIT-CERTIF PIC  X(001)           VALUE  SPACES.*/
                public StringBasis LD01_SIT_CERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"        10  FILLER          PIC  X(007)           VALUE    ' ;'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" ;");
                /*"        10  LD01-OBSERVA    PIC  X(040)           VALUE  SPACES.*/
                public StringBasis LD01_OBSERVA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"        10  FILLER          PIC  X(003)           VALUE    ' ;'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ;");
                /*"        10  FILLER          PIC  X(026)           VALUE    ' '.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" ");
                /*"01  TABELA-COBERTURA.*/
            }
        }
        public VG0139B_TABELA_COBERTURA TABELA_COBERTURA { get; set; } = new VG0139B_TABELA_COBERTURA();
        public class VG0139B_TABELA_COBERTURA : VarBasis
        {
            /*"  03          WCOB00-COBE00.*/
            public VG0139B_WCOB00_COBE00 WCOB00_COBE00 { get; set; } = new VG0139B_WCOB00_COBE00();
            public class VG0139B_WCOB00_COBE00 : VarBasis
            {
                /*"    05        WCOB00-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB00.*/
                public ListBasis<VG0139B_WCOB00_OCORRECOB> WCOB00_OCORRECOB { get; set; } = new ListBasis<VG0139B_WCOB00_OCORRECOB>(010);
                public class VG0139B_WCOB00_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB00-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB00_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB00-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB00_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB00-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB00_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB00-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB00_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB00-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB00_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB00-QTDE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB00_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"  03          WCOB01-COBE01.*/
                }
            }
            public VG0139B_WCOB01_COBE01 WCOB01_COBE01 { get; set; } = new VG0139B_WCOB01_COBE01();
            public class VG0139B_WCOB01_COBE01 : VarBasis
            {
                /*"    05        WCOB01-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB01.*/
                public ListBasis<VG0139B_WCOB01_OCORRECOB> WCOB01_OCORRECOB { get; set; } = new ListBasis<VG0139B_WCOB01_OCORRECOB>(010);
                public class VG0139B_WCOB01_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB01-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB01_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB01-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB01_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB01-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB01_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB01-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB01_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB01-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB01_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"  03          WCOB02-COBE02.*/
                }
            }
            public VG0139B_WCOB02_COBE02 WCOB02_COBE02 { get; set; } = new VG0139B_WCOB02_COBE02();
            public class VG0139B_WCOB02_COBE02 : VarBasis
            {
                /*"    05        WCOB02-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB02.*/
                public ListBasis<VG0139B_WCOB02_OCORRECOB> WCOB02_OCORRECOB { get; set; } = new ListBasis<VG0139B_WCOB02_OCORRECOB>(010);
                public class VG0139B_WCOB02_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB02-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB02_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB02-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB02_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB02-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB02_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB02-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB02_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB02-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB02_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"  03          WCOB05-COBE05.*/
                }
            }
            public VG0139B_WCOB05_COBE05 WCOB05_COBE05 { get; set; } = new VG0139B_WCOB05_COBE05();
            public class VG0139B_WCOB05_COBE05 : VarBasis
            {
                /*"    05        WCOB05-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB05.*/
                public ListBasis<VG0139B_WCOB05_OCORRECOB> WCOB05_OCORRECOB { get; set; } = new ListBasis<VG0139B_WCOB05_OCORRECOB>(010);
                public class VG0139B_WCOB05_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB05-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB05_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB05-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB05_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB05-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB05_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB05-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB05_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB05-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB05_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"  03          WCOB11-COBE11.*/
                }
            }
            public VG0139B_WCOB11_COBE11 WCOB11_COBE11 { get; set; } = new VG0139B_WCOB11_COBE11();
            public class VG0139B_WCOB11_COBE11 : VarBasis
            {
                /*"    05        WCOB11-OCORRECOB    OCCURS       010   TIMES                                  INDEXED      BY    WS-COB11.*/
                public ListBasis<VG0139B_WCOB11_OCORRECOB> WCOB11_OCORRECOB { get; set; } = new ListBasis<VG0139B_WCOB11_OCORRECOB>(010);
                public class VG0139B_WCOB11_OCORRECOB : VarBasis
                {
                    /*"      10      WCOB11-RAMO         PIC S9(004)        COMP.*/
                    public IntBasis WCOB11_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB11-COBE         PIC S9(004)        COMP.*/
                    public IntBasis WCOB11_COBE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WCOB11-IMPSEG       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB11_IMPSEG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB11-PRMTAR       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB11_PRMTAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"      10      WCOB11-PERCEN       PIC S9(013)V99     COMP-3.*/
                    public DoubleBasis WCOB11_PERCEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                }
            }
        }


        public Dclgens.HISCONPA HISCONPA { get; set; } = new Dclgens.HISCONPA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.VG082 VG082 { get; set; } = new Dclgens.VG082();
        public Dclgens.VG080 VG080 { get; set; } = new Dclgens.VG080();
        public VG0139B_CHISTCTBL CHISTCTBL { get; set; } = new VG0139B_CHISTCTBL();
        public VG0139B_V1RCAPCOMP V1RCAPCOMP { get; set; } = new VG0139B_V1RCAPCOMP();
        public VG0139B_CVGHISTCONT CVGHISTCONT { get; set; } = new VG0139B_CVGHISTCONT();
        public VG0139B_V1APOLCOSCED V1APOLCOSCED { get; set; } = new VG0139B_V1APOLCOSCED();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SVG0139B_FILE_NAME_P, string VG0139B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SVG0139B.SetFile(SVG0139B_FILE_NAME_P);
                VG0139B1.SetFile(VG0139B1_FILE_NAME_P);

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
            /*" -1234- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1237- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1240- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1243- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1245- DISPLAY 'VG0139B - GERA ENDOSSO DO HISTORICO DE CONTABILIZACA 'O DE PARCELAS' */

            $"VG0139B - GERA ENDOSSO DO HISTORICO DE CONTABILIZACA ODEPARCELAS"
            .Display();

            /*" -1246- DISPLAY '          PARA REGISTRAR A EMISSAO E COBRANCA' */
            _.Display($"          PARA REGISTRAR A EMISSAO E COBRANCA");

            /*" -1247- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1253- DISPLAY 'VERSAO V.41: - EM 07/06/2018         ' */
            _.Display($"VERSAO V.41: - EM 07/06/2018         ");

            /*" -1254- DISPLAY ' ' */
            _.Display($" ");

            /*" -1261- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1262- DISPLAY '   ' */
            _.Display($"   ");

            /*" -1265- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -1268- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -1270- MOVE +600000 TO SORT-FILE-SIZE. */
            _.Move(+600000, SORT_FILE_SIZE);

            /*" -1279- SORT SVG0139B ON ASCENDING KEY SVA-SITUACAO SVA-NUM-APOLICE SVA-CODSUBES SVA-NRPARCEL SVA-FONTE SVA-NRTIT INPUT PROCEDURE R0110-00-SELECIONA THRU R0110-FIM OUTPUT PROCEDURE R0610-00-OUTPUT THRU R0610-FIM. */
            SORT_RETURN.Value = SVG0139B.Sort("SVA-SITUACAO,SVA-NUM-APOLICE,SVA-CODSUBES,SVA-NRPARCEL,SVA-FONTE,SVA-NRTIT", () => R0110_00_SELECIONA_SECTION(), () => R0610_00_OUTPUT_SECTION());

            /*" -1282- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -1283- DISPLAY 'PROBLEMAS NO SORT ' SORT-RETURN */
                _.Display($"PROBLEMAS NO SORT {SORT_RETURN}");

                /*" -1284- DISPLAY 'QUANT. RELEASE ' WS-CNT-RELEASE */
                _.Display($"QUANT. RELEASE {WS_CNT_RELEASE}");

                /*" -1285- CLOSE VG0139B1 */
                VG0139B1.Close();

                /*" -1287- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -1290- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -1292- MOVE '0099' TO WNR-EXEC-SQL. */
            _.Move("0099", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1292- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1295- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1297- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1297- PERFORM R9990-00-INSERT-RELATORI. */

            R9990_00_INSERT_RELATORI_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1303- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1305- DISPLAY '*--------  VG0139B - FIM NORMAL  --------*' . */
            _.Display($"*--------  VG0139B - FIM NORMAL  --------*");

            /*" -1307- CLOSE VG0139B1. */
            VG0139B1.Close();

            /*" -1307- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -1319- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1321- OPEN OUTPUT VG0139B1. */
            VG0139B1.Open(REG_VG0139B1);

            /*" -1324- WRITE REG-VG0139B1 FROM LC01. */
            _.Move(ARQUIVOS_SAIDA.LC01.GetMoveValues(), REG_VG0139B1);

            VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

            /*" -1332- PERFORM R0050_00_INICIO_DB_SELECT_1 */

            R0050_00_INICIO_DB_SELECT_1();

            /*" -1335- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1338- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1344- PERFORM R0050_00_INICIO_DB_SELECT_2 */

            R0050_00_INICIO_DB_SELECT_2();

            /*" -1347- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1349- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1349- DISPLAY 'DATA SISTEMA "CB": ' V1SIST-DTMOVACB. */

            $"DATA SISTEMA CB: {V1SIST_DTMOVACB}"
            .Display();

        }

        [StopWatch]
        /*" R0050-00-INICIO-DB-SELECT-1 */
        public void R0050_00_INICIO_DB_SELECT_1()
        {
            /*" -1332- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' WITH UR END-EXEC. */

            var r0050_00_INICIO_DB_SELECT_1_Query1 = new R0050_00_INICIO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0050_00_INICIO_DB_SELECT_1_Query1.Execute(r0050_00_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_FIM*/

        [StopWatch]
        /*" R0050-00-INICIO-DB-SELECT-2 */
        public void R0050_00_INICIO_DB_SELECT_2()
        {
            /*" -1344- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVACB FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'CB' WITH UR END-EXEC. */

            var r0050_00_INICIO_DB_SELECT_2_Query1 = new R0050_00_INICIO_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0050_00_INICIO_DB_SELECT_2_Query1.Execute(r0050_00_INICIO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVACB, V1SIST_DTMOVACB);
            }


        }

        [StopWatch]
        /*" R0110-00-SELECIONA-SECTION */
        private void R0110_00_SELECIONA_SECTION()
        {
            /*" -1362- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1364- MOVE 'N' TO WFIM-V0HISTCONTABILVA. */
            _.Move("N", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

            /*" -1366- PERFORM R0500-00-DECLARE-HCTBVA. */

            R0500_00_DECLARE_HCTBVA_SECTION();

            /*" -1368- PERFORM R0510-00-FETCH-HCTBVA. */

            R0510_00_FETCH_HCTBVA_SECTION();

            /*" -1369- PERFORM R0535-00-PROCESSA-PROPVA UNTIL WFIM-V0HISTCONTABILVA EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_V0HISTCONTABILVA == "S"))
            {

                R0535_00_PROCESSA_PROPVA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_FIM*/

        [StopWatch]
        /*" R0500-00-DECLARE-HCTBVA-SECTION */
        private void R0500_00_DECLARE_HCTBVA_SECTION()
        {
            /*" -1382- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1428- PERFORM R0500_00_DECLARE_HCTBVA_DB_DECLARE_1 */

            R0500_00_DECLARE_HCTBVA_DB_DECLARE_1();

            /*" -1430- PERFORM R0500_00_DECLARE_HCTBVA_DB_OPEN_1 */

            R0500_00_DECLARE_HCTBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0500-00-DECLARE-HCTBVA-DB-DECLARE-1 */
        public void R0500_00_DECLARE_HCTBVA_DB_DECLARE_1()
        {
            /*" -1428- EXEC SQL DECLARE CHISTCTBL CURSOR FOR SELECT A.NUM_CERTIFICADO ,A.NUM_PARCELA ,A.NUM_TITULO ,A.OCORR_HISTORICO ,A.NUM_APOLICE ,A.COD_SUBGRUPO ,A.COD_FONTE ,A.PREMIO_VG ,A.PREMIO_AP ,A.DATA_MOVIMENTO ,A.SIT_REGISTRO ,A.COD_OPERACAO ,B.COD_PRODUTO ,B.COD_CLIENTE ,B.DATA_QUITACAO ,B.SIT_REGISTRO ,B.OCORR_HISTORICO ,B.DTPROXVEN ,C.COD_PRODUTO ,C.ESTR_COBR ,C.ORIG_PRODU ,VALUE(D.IND_IOF, 'S' ) FROM SEGUROS.HIST_CONT_PARCELVA A ,SEGUROS.PROPOSTAS_VA B ,SEGUROS.PRODUTOS_VG C ,SEGUROS.SUBGRUPOS_VGAP D WHERE A.DTFATUR IS NULL AND A.SIT_REGISTRO IN ( '0' , '3' ) AND A.DATA_MOVIMENTO <= :V1SIST-DTMOVABE AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.COD_SUBGRUPO = B.COD_SUBGRUPO AND D.COD_CLIENTE = B.COD_CLIENTE AND D.NUM_APOLICE = A.NUM_APOLICE AND D.COD_SUBGRUPO = A.COD_SUBGRUPO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.COD_SUBGRUPO = B.COD_SUBGRUPO AND C.DIA_FATURA = 31 AND C.ESTR_COBR = 'MULT' AND C.ORIG_PRODU IN ( 'EMPRE' , 'ESPEC' , 'ESPE1' , 'ESPE2' , 'ESPE3' , 'ESPE4' , 'ESPE5' , 'ESPE6' , 'GLOBAL' ) END-EXEC. */
            CHISTCTBL = new VG0139B_CHISTCTBL(true);
            string GetQuery_CHISTCTBL()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							,A.NUM_PARCELA 
							,A.NUM_TITULO 
							,A.OCORR_HISTORICO 
							,A.NUM_APOLICE 
							,A.COD_SUBGRUPO 
							,A.COD_FONTE 
							,A.PREMIO_VG 
							,A.PREMIO_AP 
							,A.DATA_MOVIMENTO 
							,A.SIT_REGISTRO 
							,A.COD_OPERACAO 
							,B.COD_PRODUTO 
							,B.COD_CLIENTE 
							,B.DATA_QUITACAO 
							,B.SIT_REGISTRO 
							,B.OCORR_HISTORICO 
							,B.DTPROXVEN 
							,C.COD_PRODUTO 
							,C.ESTR_COBR 
							,C.ORIG_PRODU 
							,VALUE(D.IND_IOF
							, 'S' ) 
							FROM SEGUROS.HIST_CONT_PARCELVA A 
							,SEGUROS.PROPOSTAS_VA B 
							,SEGUROS.PRODUTOS_VG C 
							,SEGUROS.SUBGRUPOS_VGAP D 
							WHERE A.DTFATUR IS NULL 
							AND A.SIT_REGISTRO IN ( '0'
							, '3' ) 
							AND A.DATA_MOVIMENTO <= '{V1SIST_DTMOVABE}' 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND D.COD_CLIENTE = B.COD_CLIENTE 
							AND D.NUM_APOLICE = A.NUM_APOLICE 
							AND D.COD_SUBGRUPO = A.COD_SUBGRUPO 
							AND C.NUM_APOLICE = B.NUM_APOLICE 
							AND C.COD_SUBGRUPO = B.COD_SUBGRUPO 
							AND C.DIA_FATURA = 31 
							AND C.ESTR_COBR = 'MULT' 
							AND C.ORIG_PRODU IN ( 'EMPRE'
							, 'ESPEC'
							, 
							'ESPE1'
							, 'ESPE2'
							, 
							'ESPE3'
							, 'ESPE4'
							, 
							'ESPE5'
							, 'ESPE6'
							, 
							'GLOBAL' )";

                return query;
            }
            CHISTCTBL.GetQueryEvent += GetQuery_CHISTCTBL;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-HCTBVA-DB-OPEN-1 */
        public void R0500_00_DECLARE_HCTBVA_DB_OPEN_1()
        {
            /*" -1430- EXEC SQL OPEN CHISTCTBL END-EXEC. */

            CHISTCTBL.Open();

        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-DECLARE-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1()
        {
            /*" -3356- EXEC SQL DECLARE V1RCAPCOMP CURSOR FOR SELECT FONTE , NRRCAP , NRRCAPCO , OPERACAO , DTMOVTO , HORAOPER , SITUACAO , BCOAVISO , AGEAVISO , NRAVISO , VLRCAP , DATARCAP , DTCADAST , SITCONTB FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */
            V1RCAPCOMP = new VG0139B_V1RCAPCOMP(true);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-FETCH-HCTBVA-SECTION */
        private void R0510_00_FETCH_HCTBVA_SECTION()
        {
            /*" -1442- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1465- PERFORM R0510_00_FETCH_HCTBVA_DB_FETCH_1 */

            R0510_00_FETCH_HCTBVA_DB_FETCH_1();

            /*" -1469- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1470- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1470- PERFORM R0510_00_FETCH_HCTBVA_DB_CLOSE_1 */

                    R0510_00_FETCH_HCTBVA_DB_CLOSE_1();

                    /*" -1472- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -1473- GO TO R0510-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                    /*" -1474- ELSE */
                }
                else
                {


                    /*" -1475- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1476- END-IF */
                }


                /*" -1478- END-IF. */
            }


            /*" -1481- ADD 1 TO AC-L-V0HISTCONT */
            AREA_DE_WORK.AC_L_V0HISTCONT.Value = AREA_DE_WORK.AC_L_V0HISTCONT + 1;

            /*" -1483- ADD 1 TO AC-CONTA. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -1484- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -1485- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1486- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1490- DISPLAY 'LIDOS HISCONPA ... ' AC-L-V0HISTCONT ' ' V0HCTB-NRCERTIF ' ' WS-TIME */

                $"LIDOS HISCONPA ... {AREA_DE_WORK.AC_L_V0HISTCONT} {V0HCTB_NRCERTIF} {WS_TIME}"
                .Display();

                /*" -1493- END-IF */
            }


            /*" -1500- MOVE SPACES TO LD01-DTVENCTO LD01-DTINIVIG LD01-DTINIVIG1 LD01-OBSERVA. */
            _.Move("", ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG1, ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

            /*" -1502- IF (V0HCTB-CODOPER = 1000) OR (V0HCTB-CODOPER > 499 AND V0HCTB-CODOPER < 600) */

            if ((V0HCTB_CODOPER == 1000) || (V0HCTB_CODOPER > 499 && V0HCTB_CODOPER < 600))
            {

                /*" -1503- ADD 1 TO DP-OPERACAO */
                AREA_DE_WORK.DP_OPERACAO.Value = AREA_DE_WORK.DP_OPERACAO + 1;

                /*" -1506- GO TO R0510-00-FETCH-HCTBVA. */
                new Task(() => R0510_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1507- IF V0HCTB-FONTE EQUAL ZEROS */

            if (V0HCTB_FONTE == 00)
            {

                /*" -1510- MOVE 5 TO V0HCTB-FONTE. */
                _.Move(5, V0HCTB_FONTE);
            }


            /*" -1513- IF V0PROP-SITUACAO NOT EQUAL '3' AND V0PROP-SITUACAO NOT EQUAL '4' AND V0PROP-SITUACAO NOT EQUAL '6' */

            if (V0PROP_SITUACAO != "3" && V0PROP_SITUACAO != "4" && V0PROP_SITUACAO != "6")
            {

                /*" -1514- MOVE 'CERTIFICADO COM SIT. N�O INTEGRADA' TO LD01-OBSERVA */
                _.Move("CERTIFICADO COM SIT. N�O INTEGRADA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1515- PERFORM R1010-00-GRAVA-CRITICA */

                R1010_00_GRAVA_CRITICA_SECTION();

                /*" -1518- GO TO R0510-00-FETCH-HCTBVA. */
                new Task(() => R0510_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1519- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' */

            if (V0PRVG_ORIG_PRODU == "EMPRE")
            {

                /*" -1520- IF V0HCTB-CODSUBES EQUAL ZEROS */

                if (V0HCTB_CODSUBES == 00)
                {

                    /*" -1522- MOVE 'ORIG-PRODU = EMPRE - CODSUBES = ZEROS' TO LD01-OBSERVA */
                    _.Move("ORIG-PRODU = EMPRE - CODSUBES = ZEROS", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                    /*" -1523- PERFORM R1010-00-GRAVA-CRITICA */

                    R1010_00_GRAVA_CRITICA_SECTION();

                    /*" -1526- GO TO R0510-00-FETCH-HCTBVA. */
                    new Task(() => R0510_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...
                }

            }


            /*" -1527- IF V0HCTB-DTMOVTO GREATER V1SIST-DTMOVABE */

            if (V0HCTB_DTMOVTO > V1SIST_DTMOVABE)
            {

                /*" -1529- MOVE 'V0HCTB-DTMOVTO MAIOR V1SIST-DTMOVABE ' TO LD01-OBSERVA */
                _.Move("V0HCTB-DTMOVTO MAIOR V1SIST-DTMOVABE ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1530- PERFORM R1010-00-GRAVA-CRITICA */

                R1010_00_GRAVA_CRITICA_SECTION();

                /*" -1533- GO TO R0510-00-FETCH-HCTBVA. */
                new Task(() => R0510_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1537- COMPUTE WS-VALOR EQUAL (V0HCTB-PRMVG + V0HCTB-PRMAP). */
            AREA_DE_WORK.WS_VALOR.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP);

            /*" -1538- IF WS-VALOR NOT GREATER ZEROS */

            if (AREA_DE_WORK.WS_VALOR <= 00)
            {

                /*" -1539- PERFORM R0515-00-UPDATE-CONTABIL */

                R0515_00_UPDATE_CONTABIL_SECTION();

                /*" -1540- ADD 1 TO DP-VALOR */
                AREA_DE_WORK.DP_VALOR.Value = AREA_DE_WORK.DP_VALOR + 1;

                /*" -1540- GO TO R0510-00-FETCH-HCTBVA. */
                new Task(() => R0510_00_FETCH_HCTBVA_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


        }

        [StopWatch]
        /*" R0510-00-FETCH-HCTBVA-DB-FETCH-1 */
        public void R0510_00_FETCH_HCTBVA_DB_FETCH_1()
        {
            /*" -1465- EXEC SQL FETCH CHISTCTBL INTO :V0HCTB-NRCERTIF ,:V0HCTB-NRPARCEL ,:V0HCTB-NRTIT ,:V0HCTB-OCORHIST ,:V0HCTB-NUM-APOLICE ,:V0HCTB-CODSUBES ,:V0HCTB-FONTE ,:V0HCTB-PRMVG ,:V0HCTB-PRMAP ,:V0HCTB-DTMOVTO ,:V0HCTB-SITUACAO ,:V0HCTB-CODOPER ,:V0PROP-CODPRODU ,:V0PROP-CODCLIEN ,:V0PROP-DTQITBCO ,:V0PROP-SITUACAO ,:V0PROP-OCORHIST ,:V0PROP-DTPROXVEN ,:V0PRVG-CODPRODU ,:V0PRVG-ESTR-COBR ,:V0PRVG-ORIG-PRODU ,:V0SUBG-IND-IOF END-EXEC. */

            if (CHISTCTBL.Fetch())
            {
                _.Move(CHISTCTBL.V0HCTB_NRCERTIF, V0HCTB_NRCERTIF);
                _.Move(CHISTCTBL.V0HCTB_NRPARCEL, V0HCTB_NRPARCEL);
                _.Move(CHISTCTBL.V0HCTB_NRTIT, V0HCTB_NRTIT);
                _.Move(CHISTCTBL.V0HCTB_OCORHIST, V0HCTB_OCORHIST);
                _.Move(CHISTCTBL.V0HCTB_NUM_APOLICE, V0HCTB_NUM_APOLICE);
                _.Move(CHISTCTBL.V0HCTB_CODSUBES, V0HCTB_CODSUBES);
                _.Move(CHISTCTBL.V0HCTB_FONTE, V0HCTB_FONTE);
                _.Move(CHISTCTBL.V0HCTB_PRMVG, V0HCTB_PRMVG);
                _.Move(CHISTCTBL.V0HCTB_PRMAP, V0HCTB_PRMAP);
                _.Move(CHISTCTBL.V0HCTB_DTMOVTO, V0HCTB_DTMOVTO);
                _.Move(CHISTCTBL.V0HCTB_SITUACAO, V0HCTB_SITUACAO);
                _.Move(CHISTCTBL.V0HCTB_CODOPER, V0HCTB_CODOPER);
                _.Move(CHISTCTBL.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(CHISTCTBL.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(CHISTCTBL.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(CHISTCTBL.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(CHISTCTBL.V0PROP_OCORHIST, V0PROP_OCORHIST);
                _.Move(CHISTCTBL.V0PROP_DTPROXVEN, V0PROP_DTPROXVEN);
                _.Move(CHISTCTBL.V0PRVG_CODPRODU, V0PRVG_CODPRODU);
                _.Move(CHISTCTBL.V0PRVG_ESTR_COBR, V0PRVG_ESTR_COBR);
                _.Move(CHISTCTBL.V0PRVG_ORIG_PRODU, V0PRVG_ORIG_PRODU);
                _.Move(CHISTCTBL.V0SUBG_IND_IOF, V0SUBG_IND_IOF);
            }

        }

        [StopWatch]
        /*" R0510-00-FETCH-HCTBVA-DB-CLOSE-1 */
        public void R0510_00_FETCH_HCTBVA_DB_CLOSE_1()
        {
            /*" -1470- EXEC SQL CLOSE CHISTCTBL END-EXEC */

            CHISTCTBL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0515-00-UPDATE-CONTABIL-SECTION */
        private void R0515_00_UPDATE_CONTABIL_SECTION()
        {
            /*" -1552- MOVE '0515' TO WNR-EXEC-SQL. */
            _.Move("0515", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1562- PERFORM R0515_00_UPDATE_CONTABIL_DB_UPDATE_1 */

            R0515_00_UPDATE_CONTABIL_DB_UPDATE_1();

            /*" -1566- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1566- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0515-00-UPDATE-CONTABIL-DB-UPDATE-1 */
        public void R0515_00_UPDATE_CONTABIL_DB_UPDATE_1()
        {
            /*" -1562- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST AND NUM_APOLICE = :V0HCTB-NUM-APOLICE AND CODSUBES = :V0HCTB-CODSUBES END-EXEC. */

            var r0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1 = new R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
                V0HCTB_OCORHIST = V0HCTB_OCORHIST.ToString(),
                V0HCTB_CODSUBES = V0HCTB_CODSUBES.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            R0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1.Execute(r0515_00_UPDATE_CONTABIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0515_99_SAIDA*/

        [StopWatch]
        /*" R0535-00-PROCESSA-PROPVA-SECTION */
        private void R0535_00_PROCESSA_PROPVA_SECTION()
        {
            /*" -1579- MOVE '0535' TO WNR-EXEC-SQL. */
            _.Move("0535", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1580- MOVE V0HCTB-SITUACAO TO SVA-SITUACAO */
            _.Move(V0HCTB_SITUACAO, REG_SVG0139B.SVA_SITUACAO);

            /*" -1581- MOVE V0HCTB-NUM-APOLICE TO SVA-NUM-APOLICE */
            _.Move(V0HCTB_NUM_APOLICE, REG_SVG0139B.SVA_NUM_APOLICE);

            /*" -1582- MOVE V0HCTB-CODSUBES TO SVA-CODSUBES */
            _.Move(V0HCTB_CODSUBES, REG_SVG0139B.SVA_CODSUBES);

            /*" -1583- MOVE V0HCTB-FONTE TO SVA-FONTE */
            _.Move(V0HCTB_FONTE, REG_SVG0139B.SVA_FONTE);

            /*" -1584- MOVE V0HCTB-PRMVG TO SVA-PRMVG */
            _.Move(V0HCTB_PRMVG, REG_SVG0139B.SVA_PRMVG);

            /*" -1585- MOVE V0HCTB-PRMAP TO SVA-PRMAP */
            _.Move(V0HCTB_PRMAP, REG_SVG0139B.SVA_PRMAP);

            /*" -1586- MOVE V0HCTB-CODOPER TO SVA-CODOPER */
            _.Move(V0HCTB_CODOPER, REG_SVG0139B.SVA_CODOPER);

            /*" -1587- MOVE V0HCTB-NRCERTIF TO SVA-NRCERTIF */
            _.Move(V0HCTB_NRCERTIF, REG_SVG0139B.SVA_NRCERTIF);

            /*" -1588- MOVE V0HCTB-NRPARCEL TO SVA-NRPARCEL */
            _.Move(V0HCTB_NRPARCEL, REG_SVG0139B.SVA_NRPARCEL);

            /*" -1589- MOVE V0HCTB-NRTIT TO SVA-NRTIT */
            _.Move(V0HCTB_NRTIT, REG_SVG0139B.SVA_NRTIT);

            /*" -1590- MOVE V0HCTB-OCORHIST TO SVA-OCORHIST */
            _.Move(V0HCTB_OCORHIST, REG_SVG0139B.SVA_OCORHIST);

            /*" -1591- MOVE V0HCTB-DTMOVTO TO SVA-DTMOVTO */
            _.Move(V0HCTB_DTMOVTO, REG_SVG0139B.SVA_DTMOVTO);

            /*" -1592- MOVE V0PROP-DTQITBCO TO SVA-DTQITBCO */
            _.Move(V0PROP_DTQITBCO, REG_SVG0139B.SVA_DTQITBCO);

            /*" -1593- MOVE V0PROP-CODCLIEN TO SVA-CODCLIEN */
            _.Move(V0PROP_CODCLIEN, REG_SVG0139B.SVA_CODCLIEN);

            /*" -1594- MOVE V0PRVG-ESTR-COBR TO SVA-ESTR-COBR */
            _.Move(V0PRVG_ESTR_COBR, REG_SVG0139B.SVA_ESTR_COBR);

            /*" -1595- MOVE V0PRVG-ORIG-PRODU TO SVA-ORIG-PRODU */
            _.Move(V0PRVG_ORIG_PRODU, REG_SVG0139B.SVA_ORIG_PRODU);

            /*" -1596- MOVE V0SUBG-IND-IOF TO SVA-IND-IOF */
            _.Move(V0SUBG_IND_IOF, REG_SVG0139B.SVA_IND_IOF);

            /*" -1597- MOVE V0PRVG-CODPRODU TO SVA-CODPRODU */
            _.Move(V0PRVG_CODPRODU, REG_SVG0139B.SVA_CODPRODU);

            /*" -1598- MOVE V0PROP-OCORHIST TO SVA-OCORHIST1 */
            _.Move(V0PROP_OCORHIST, REG_SVG0139B.SVA_OCORHIST1);

            /*" -1599- MOVE V0PROP-DTPROXVEN TO SVA-DTPROXVEN. */
            _.Move(V0PROP_DTPROXVEN, REG_SVG0139B.SVA_DTPROXVEN);

            /*" -1601- MOVE V0PROP-SITUACAO TO SVA-SITPROPOS. */
            _.Move(V0PROP_SITUACAO, REG_SVG0139B.SVA_SITPROPOS);

            /*" -1603- RELEASE REG-SVG0139B. */
            SVG0139B.Release(REG_SVG0139B);

            /*" -1605- ADD 1 TO WS-CNT-RELEASE */
            WS_CNT_RELEASE.Value = WS_CNT_RELEASE + 1;

            /*" -1605- PERFORM R0510-00-FETCH-HCTBVA. */

            R0510_00_FETCH_HCTBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0535_FIM*/

        [StopWatch]
        /*" R0610-00-OUTPUT-SECTION */
        private void R0610_00_OUTPUT_SECTION()
        {
            /*" -1618- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1620- MOVE SPACES TO WFIM-V0HISTCONTABILVA. */
            _.Move("", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

            /*" -1622- PERFORM R0620-00-LEITURA-SVG0139B. */

            R0620_00_LEITURA_SVG0139B_SECTION();

            /*" -1623- PERFORM R0700-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty()))
            {

                R0700_00_PROCESSA_REGISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_FIM*/

        [StopWatch]
        /*" R0620-00-LEITURA-SVG0139B-SECTION */
        private void R0620_00_LEITURA_SVG0139B_SECTION()
        {
            /*" -1635- MOVE '0620' TO WNR-EXEC-SQL. */
            _.Move("0620", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1637- RETURN SVG0139B AT END */
            try
            {
                SVG0139B.Return(REG_SVG0139B, () =>
                {

                    /*" -1638- MOVE 'S' TO WFIM-V0HISTCONTABILVA */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTCONTABILVA);

                    /*" -1641- GO TO R0620-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1642- MOVE SVA-SITUACAO TO V0HCTB-SITUACAO */
            _.Move(REG_SVG0139B.SVA_SITUACAO, V0HCTB_SITUACAO);

            /*" -1643- MOVE SVA-NUM-APOLICE TO V0HCTB-NUM-APOLICE */
            _.Move(REG_SVG0139B.SVA_NUM_APOLICE, V0HCTB_NUM_APOLICE);

            /*" -1644- MOVE SVA-CODSUBES TO V0HCTB-CODSUBES */
            _.Move(REG_SVG0139B.SVA_CODSUBES, V0HCTB_CODSUBES);

            /*" -1645- MOVE SVA-FONTE TO V0HCTB-FONTE */
            _.Move(REG_SVG0139B.SVA_FONTE, V0HCTB_FONTE);

            /*" -1646- MOVE SVA-PRMVG TO V0HCTB-PRMVG */
            _.Move(REG_SVG0139B.SVA_PRMVG, V0HCTB_PRMVG);

            /*" -1647- MOVE SVA-PRMAP TO V0HCTB-PRMAP */
            _.Move(REG_SVG0139B.SVA_PRMAP, V0HCTB_PRMAP);

            /*" -1648- MOVE SVA-CODOPER TO V0HCTB-CODOPER */
            _.Move(REG_SVG0139B.SVA_CODOPER, V0HCTB_CODOPER);

            /*" -1649- MOVE SVA-NRCERTIF TO V0HCTB-NRCERTIF */
            _.Move(REG_SVG0139B.SVA_NRCERTIF, V0HCTB_NRCERTIF);

            /*" -1650- MOVE SVA-NRPARCEL TO V0HCTB-NRPARCEL */
            _.Move(REG_SVG0139B.SVA_NRPARCEL, V0HCTB_NRPARCEL);

            /*" -1651- MOVE SVA-NRTIT TO V0HCTB-NRTIT */
            _.Move(REG_SVG0139B.SVA_NRTIT, V0HCTB_NRTIT);

            /*" -1652- MOVE SVA-OCORHIST TO V0HCTB-OCORHIST */
            _.Move(REG_SVG0139B.SVA_OCORHIST, V0HCTB_OCORHIST);

            /*" -1653- MOVE SVA-DTMOVTO TO V0HCTB-DTMOVTO */
            _.Move(REG_SVG0139B.SVA_DTMOVTO, V0HCTB_DTMOVTO);

            /*" -1654- MOVE SVA-DTQITBCO TO V0PROP-DTQITBCO */
            _.Move(REG_SVG0139B.SVA_DTQITBCO, V0PROP_DTQITBCO);

            /*" -1655- MOVE SVA-CODCLIEN TO V0PROP-CODCLIEN */
            _.Move(REG_SVG0139B.SVA_CODCLIEN, V0PROP_CODCLIEN);

            /*" -1656- MOVE SVA-ESTR-COBR TO V0PRVG-ESTR-COBR */
            _.Move(REG_SVG0139B.SVA_ESTR_COBR, V0PRVG_ESTR_COBR);

            /*" -1657- MOVE SVA-ORIG-PRODU TO V0PRVG-ORIG-PRODU. */
            _.Move(REG_SVG0139B.SVA_ORIG_PRODU, V0PRVG_ORIG_PRODU);

            /*" -1658- MOVE SVA-IND-IOF TO V0SUBG-IND-IOF. */
            _.Move(REG_SVG0139B.SVA_IND_IOF, V0SUBG_IND_IOF);

            /*" -1659- MOVE SVA-OCORHIST1 TO V0PROP-OCORHIST. */
            _.Move(REG_SVG0139B.SVA_OCORHIST1, V0PROP_OCORHIST);

            /*" -1660- MOVE SVA-CODPRODU TO V0PROP-CODPRODU. */
            _.Move(REG_SVG0139B.SVA_CODPRODU, V0PROP_CODPRODU);

            /*" -1661- MOVE SVA-DTPROXVEN TO V0PROP-DTPROXVEN. */
            _.Move(REG_SVG0139B.SVA_DTPROXVEN, V0PROP_DTPROXVEN);

            /*" -1663- MOVE SVA-SITPROPOS TO V0PROP-SITUACAO. */
            _.Move(REG_SVG0139B.SVA_SITPROPOS, V0PROP_SITUACAO);

            /*" -1670- MOVE SPACES TO LD01-DTVENCTO LD01-DTINIVIG LD01-DTINIVIG1 LD01-OBSERVA. */
            _.Move("", ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG1, ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

            /*" -1673- ADD 1 TO AC-L-SORT AC-CONTA. */
            AREA_DE_WORK.AC_L_SORT.Value = AREA_DE_WORK.AC_L_SORT + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -1674- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -1675- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -1676- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WS_TIME);

                /*" -1680- DISPLAY 'LIDOS SORT ....... ' AC-L-SORT ' ' V0HCTB-NRCERTIF ' ' WS-TIME */

                $"LIDOS SORT ....... {AREA_DE_WORK.AC_L_SORT} {V0HCTB_NRCERTIF} {WS_TIME}"
                .Display();

                /*" -1680- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-SECTION */
        private void R0700_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1694- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1695- IF V0PROP-SITUACAO EQUAL '4' */

            if (V0PROP_SITUACAO == "4")
            {

                /*" -1697- IF V0HCTB-NRPARCEL GREATER 1 NEXT SENTENCE */

                if (V0HCTB_NRPARCEL > 1)
                {

                    /*" -1698- ELSE */
                }
                else
                {


                    /*" -1699- PERFORM R0710-00-SELECT-HCTBVA */

                    R0710_00_SELECT_HCTBVA_SECTION();

                    /*" -1700- IF AC-FATURA NOT EQUAL 'S' */

                    if (AREA_DE_WORK.AC_FATURA != "S")
                    {

                        /*" -1701- MOVE ' PARCELA DE ADESAO N�O INTEGRADA' TO LD01-OBSERVA */
                        _.Move(" PARCELA DE ADESAO N�O INTEGRADA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -1702- PERFORM R1010-00-GRAVA-CRITICA */

                        R1010_00_GRAVA_CRITICA_SECTION();

                        /*" -1703- PERFORM R0620-00-LEITURA-SVG0139B */

                        R0620_00_LEITURA_SVG0139B_SECTION();

                        /*" -1706- GO TO R0700-00-PROCESSA-REGISTRO. */
                        new Task(() => R0700_00_PROCESSA_REGISTRO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...
                    }

                }

            }


            /*" -1708- MOVE V0HCTB-NUM-APOLICE TO WS-NUM-APOLICE-ANT V0ENDO-NUM-APOLICE. */
            _.Move(V0HCTB_NUM_APOLICE, AREA_DE_WORK.WS_NUM_APOLICE_ANT, V0ENDO_NUM_APOLICE);

            /*" -1710- MOVE V0HCTB-CODSUBES TO WS-CODSUBES-ANT V0ENDO-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, AREA_DE_WORK.WS_CODSUBES_ANT, V0ENDO_CODSUBES);

            /*" -1712- MOVE V0HCTB-FONTE TO WS-FONTE-ANT V0ENDO-FONTE. */
            _.Move(V0HCTB_FONTE, AREA_DE_WORK.WS_FONTE_ANT, V0ENDO_FONTE);

            /*" -1715- MOVE V0HCTB-NRPARCEL TO WS-NRPARCEL-ANT WHOST-NRPARCEL. */
            _.Move(V0HCTB_NRPARCEL, AREA_DE_WORK.WS_NRPARCEL_ANT, WHOST_NRPARCEL);

            /*" -1717- MOVE V0HCTB-NRCERTIF TO WS-NRCERTIF-ANT WHOST-NRCERTIF. */
            _.Move(V0HCTB_NRCERTIF, AREA_DE_WORK.WS_NRCERTIF_ANT, WHOST_NRCERTIF);

            /*" -1719- MOVE V0HCTB-NRTIT TO WS-NRTIT-ANT WHOST-NRTIT. */
            _.Move(V0HCTB_NRTIT, AREA_DE_WORK.WS_NRTIT_ANT, WHOST_NRTIT);

            /*" -1721- MOVE V0HCTB-DTMOVTO TO V0HCTB-DTMOVTO-ANT. */
            _.Move(V0HCTB_DTMOVTO, V0HCTB_DTMOVTO_ANT);

            /*" -1723- MOVE '1001' TO WNR-EXEC-SQL. */
            _.Move("1001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1734- PERFORM R0700_00_PROCESSA_REGISTRO_DB_SELECT_1 */

            R0700_00_PROCESSA_REGISTRO_DB_SELECT_1();

            /*" -1738- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1739- DISPLAY V0HCTB-NUM-APOLICE */
                _.Display(V0HCTB_NUM_APOLICE);

                /*" -1742- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1744- MOVE '10B1' TO WNR-EXEC-SQL. */
            _.Move("10B1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1753- PERFORM R0700_00_PROCESSA_REGISTRO_DB_SELECT_2 */

            R0700_00_PROCESSA_REGISTRO_DB_SELECT_2();

            /*" -1756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1758- DISPLAY V0HCTB-NRCERTIF ' ' V0HCTB-NRPARCEL */

                $"{V0HCTB_NRCERTIF} {V0HCTB_NRPARCEL}"
                .Display();

                /*" -1760- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1762- MOVE '10BY' TO WNR-EXEC-SQL. */
            _.Move("10BY", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1773- PERFORM R0700_00_PROCESSA_REGISTRO_DB_SELECT_3 */

            R0700_00_PROCESSA_REGISTRO_DB_SELECT_3();

            /*" -1776- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1777- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1778- MOVE '10BZ' TO WNR-EXEC-SQL */
                    _.Move("10BZ", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1788- PERFORM R0700_00_PROCESSA_REGISTRO_DB_SELECT_4 */

                    R0700_00_PROCESSA_REGISTRO_DB_SELECT_4();

                    /*" -1790- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1791- DISPLAY 'ERRO ACESSO HISTCOBVA ' V0HCTB-NRCERTIF */
                        _.Display($"ERRO ACESSO HISTCOBVA {V0HCTB_NRCERTIF}");

                        /*" -1792- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1793- END-IF */
                    }


                    /*" -1794- ELSE */
                }
                else
                {


                    /*" -1797- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1799- PERFORM R0730-00-SELECT-HISCOBPR. */

            R0730_00_SELECT_HISCOBPR_SECTION();

            /*" -1800- IF (LD01-OBSERVA NOT EQUAL SPACES) */

            if ((!ARQUIVOS_SAIDA.LD01.LD01_OBSERVA.IsEmpty()))
            {

                /*" -1801- PERFORM R1010-00-GRAVA-CRITICA */

                R1010_00_GRAVA_CRITICA_SECTION();

                /*" -1802- PERFORM R0620-00-LEITURA-SVG0139B */

                R0620_00_LEITURA_SVG0139B_SECTION();

                /*" -1803- GO TO R0700-00-PROCESSA-REGISTRO */
                new Task(() => R0700_00_PROCESSA_REGISTRO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1803- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0700_10_10C1 */

            R0700_10_10C1();

        }

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-DB-SELECT-1 */
        public void R0700_00_PROCESSA_REGISTRO_DB_SELECT_1()
        {
            /*" -1734- EXEC SQL SELECT RAMO, CODPRODU, MODALIDA, ORGAO INTO :V0APOL-RAMO, :V0APOL-CODPRODU, :V0APOL-MODALIDA, :V0APOL-ORGAO FROM SEGUROS.V0APOLICE WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE END-EXEC. */

            var r0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 = new R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1.Execute(r0700_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(executed_1.V0APOL_CODPRODU, V0APOL_CODPRODU);
                _.Move(executed_1.V0APOL_MODALIDA, V0APOL_MODALIDA);
                _.Move(executed_1.V0APOL_ORGAO, V0APOL_ORGAO);
            }


        }

        [StopWatch]
        /*" R0700-10-10C1 */
        private void R0700_10_10C1(bool isPerform = false)
        {
            /*" -1810- MOVE '10C1' TO WNR-EXEC-SQL. */
            _.Move("10C1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1818- PERFORM R0700_10_10C1_DB_SELECT_1 */

            R0700_10_10C1_DB_SELECT_1();

            /*" -1821- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1822- IF (V0HCTB-NRPARCEL EQUAL 01) */

                if ((V0HCTB_NRPARCEL == 01))
                {

                    /*" -1823- MOVE '10Z1' TO WNR-EXEC-SQL */
                    _.Move("10Z1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                    /*" -1828- PERFORM R0700_10_10C1_DB_UPDATE_1 */

                    R0700_10_10C1_DB_UPDATE_1();

                    /*" -1831- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1832- DISPLAY 'ERRO UPDATE OPCAOPAG ' V0HCTB-NRCERTIF */
                        _.Display($"ERRO UPDATE OPCAOPAG {V0HCTB_NRCERTIF}");

                        /*" -1833- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1834- ELSE */
                    }
                    else
                    {


                        /*" -1835- GO TO R0700-10-10C1 */
                        new Task(() => R0700_10_10C1()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1836- END-IF */
                    }


                    /*" -1837- ELSE */
                }
                else
                {


                    /*" -1845- PERFORM R0700_10_10C1_DB_SELECT_2 */

                    R0700_10_10C1_DB_SELECT_2();

                    /*" -1848- IF (SQLCODE NOT EQUAL ZEROS) */

                    if ((DB.SQLCODE != 00))
                    {

                        /*" -1850- DISPLAY 'NAO ENCONTROU ' V0HCTB-NRCERTIF ' ' V0PARC-DTVENCTO */

                        $"NAO ENCONTROU {V0HCTB_NRCERTIF} {V0PARC_DTVENCTO}"
                        .Display();

                        /*" -1851- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1852- END-IF */
                    }


                    /*" -1853- END-IF */
                }


                /*" -1856- END-IF. */
            }


            /*" -1858- MOVE '10D1' TO WNR-EXEC-SQL. */
            _.Move("10D1", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1862- MOVE V0COBP-DTINIVIG-ENDO TO V0ENDO-DTINIVIG V0ENDO-DTTERVIG. */
            _.Move(V0COBP_DTINIVIG_ENDO, V0ENDO_DTINIVIG, V0ENDO_DTTERVIG);

            /*" -1863- IF (V0ENDO-DTTERVIG >= V0PARC-DTVENCTO) */

            if ((V0ENDO_DTTERVIG >= V0PARC_DTVENCTO))
            {

                /*" -1872- PERFORM R0700_10_10C1_DB_SELECT_3 */

                R0700_10_10C1_DB_SELECT_3();

                /*" -1875- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1876- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1877- END-IF */
                }


                /*" -1878- ELSE */
            }
            else
            {


                /*" -1879- PERFORM UNTIL V0ENDO-DTTERVIG > V0PARC-DTVENCTO */

                while (!(V0ENDO_DTTERVIG > V0PARC_DTVENCTO))
                {

                    /*" -1888- PERFORM R0700_10_10C1_DB_SELECT_4 */

                    R0700_10_10C1_DB_SELECT_4();

                    /*" -1891- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1892- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1893- END-IF */
                    }


                    /*" -1894- END-PERFORM */
                }

                /*" -1896- END-IF. */
            }


            /*" -1902- PERFORM R0700_10_10C1_DB_SELECT_5 */

            R0700_10_10C1_DB_SELECT_5();

            /*" -1905- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -1906- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1914- END-IF */
            }


            /*" -1916- PERFORM R0750-00-SELECT-V0ENDOSSO. */

            R0750_00_SELECT_V0ENDOSSO_SECTION();

            /*" -1917- IF LD01-OBSERVA NOT EQUAL SPACES */

            if (!ARQUIVOS_SAIDA.LD01.LD01_OBSERVA.IsEmpty())
            {

                /*" -1918- PERFORM R1010-00-GRAVA-CRITICA */

                R1010_00_GRAVA_CRITICA_SECTION();

                /*" -1919- PERFORM R0620-00-LEITURA-SVG0139B */

                R0620_00_LEITURA_SVG0139B_SECTION();

                /*" -1924- GO TO R0700-00-PROCESSA-REGISTRO. */

                R0700_00_PROCESSA_REGISTRO_SECTION(); //GOTO
                return;
            }


            /*" -1926- MOVE '1002' TO WNR-EXEC-SQL. */
            _.Move("1002", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1934- PERFORM R0700_10_10C1_DB_SELECT_6 */

            R0700_10_10C1_DB_SELECT_6();

            /*" -1937- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1938- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1944- END-IF. */
            }


            /*" -1946- MOVE 'S' TO WTEM-VIGENCIA. */
            _.Move("S", WTEM_VIGENCIA);

            /*" -1947- IF V0ENDO-DTINIVIG LESS WHOST-DTINIVIG */

            if (V0ENDO_DTINIVIG < WHOST_DTINIVIG)
            {

                /*" -1948- IF V0HCTB-NRPARCEL EQUAL 1 */

                if (V0HCTB_NRPARCEL == 1)
                {

                    /*" -1949- PERFORM R1030-00-AJUSTA-VIGENCIA */

                    R1030_00_AJUSTA_VIGENCIA_SECTION();

                    /*" -1950- ELSE */
                }
                else
                {


                    /*" -1951- MOVE WHOST-DTINIVIG TO V0ENDO-DTINIVIG */
                    _.Move(WHOST_DTINIVIG, V0ENDO_DTINIVIG);

                    /*" -1953- MOVE WHOST-DTENDFIM TO V0ENDO-DTTERVIG. */
                    _.Move(WHOST_DTENDFIM, V0ENDO_DTTERVIG);
                }

            }


            /*" -1954- IF WTEM-VIGENCIA EQUAL 'N' */

            if (WTEM_VIGENCIA == "N")
            {

                /*" -1956- MOVE 'VIGENCIA DO ENDOSSO DIVERGE          ' TO LD01-OBSERVA */
                _.Move("VIGENCIA DO ENDOSSO DIVERGE          ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -1958- MOVE V0ENDO-DTINIVIG TO LD01-DTINIVIG */
                _.Move(V0ENDO_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

                /*" -1960- MOVE WHOST-DTINIVIG TO LD01-DTINIVIG1 */
                _.Move(WHOST_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG1);

                /*" -1961- PERFORM R1010-00-GRAVA-CRITICA */

                R1010_00_GRAVA_CRITICA_SECTION();

                /*" -1962- PERFORM R0620-00-LEITURA-SVG0139B */

                R0620_00_LEITURA_SVG0139B_SECTION();

                /*" -1965- GO TO R0700-00-PROCESSA-REGISTRO. */

                R0700_00_PROCESSA_REGISTRO_SECTION(); //GOTO
                return;
            }


            /*" -1967- MOVE '1005' TO WNR-EXEC-SQL. */
            _.Move("1005", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1973- PERFORM R0700_10_10C1_DB_SELECT_7 */

            R0700_10_10C1_DB_SELECT_7();

            /*" -1976- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1978- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1980- ADD 1 TO V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS + 1;

            /*" -1982- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1987- PERFORM R0700_10_10C1_DB_UPDATE_2 */

            R0700_10_10C1_DB_UPDATE_2();

            /*" -1990- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1992- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1994- ADD 1 TO AC-U-V0NUMERAES. */
            AREA_DE_WORK.AC_U_V0NUMERAES.Value = AREA_DE_WORK.AC_U_V0NUMERAES + 1;

            /*" -2004- MOVE +0 TO AC-PRMVG AC-PRMAP AC-PRMRTO AC-PRMDIT WS-PRM-LIQ-DIT WS-VLIOCC-TOT WS-VLIOCC-TOT-AP WS-VLIOCC-TOT-VG WS-VLIOCC-TOT-DIT WS-VLIOCC-TOT-RTO. */
            _.Move(+0, AREA_DE_WORK.AC_PRMVG, AREA_DE_WORK.AC_PRMAP, AREA_DE_WORK.AC_PRMRTO, AREA_DE_WORK.AC_PRMDIT, AREA_DE_WORK.WS_PRM_LIQ_DIT, AREA_DE_WORK.WS_VLIOCC_TOT, AREA_DE_WORK.WS_VLIOCC_TOT_AP, AREA_DE_WORK.WS_VLIOCC_TOT_VG, AREA_DE_WORK.WS_VLIOCC_TOT_DIT, AREA_DE_WORK.WS_VLIOCC_TOT_RTO);

            /*" -2006- MOVE 'NAO' TO WTEM-VG082. */
            _.Move("NAO", AREA_DE_WORK.WTEM_VG082);

            /*" -2009- INITIALIZE TABELA-RAMO TABELA-RAMO-R */
            _.Initialize(
                TABELA_RAMO
                , TABELA_RAMO_R
            );

            /*" -2010- MOVE '1011' TO WNR-EXEC-SQL. */
            _.Move("1011", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2012- MOVE 'SIM' TO WTEM-RAMO-CONJ. */
            _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_CONJ);

            /*" -2018- PERFORM R0700_10_10C1_DB_SELECT_8 */

            R0700_10_10C1_DB_SELECT_8();

            /*" -2021- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2022- IF SQLCODE NOT EQUAL 100 AND -811 */

                if (!DB.SQLCODE.In("100", "-811"))
                {

                    /*" -2023- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2024- ELSE */
                }
                else
                {


                    /*" -2025- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2026- MOVE 'NAO' TO WTEM-RAMO-CONJ */
                        _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_CONJ);

                        /*" -2027- END-IF */
                    }


                    /*" -2028- END-IF */
                }


                /*" -2030- END-IF. */
            }


            /*" -2032- PERFORM R1020-00-MOVE-DADOS. */

            R1020_00_MOVE_DADOS_SECTION();

            /*" -2041- PERFORM R1100-00-ACUMULA-PREMIO UNTIL WFIM-V0HISTCONTABILVA NOT EQUAL SPACES OR V0HCTB-NUM-APOLICE NOT EQUAL WS-NUM-APOLICE-ANT OR V0HCTB-CODSUBES NOT EQUAL WS-CODSUBES-ANT OR V0HCTB-NRPARCEL NOT EQUAL WS-NRPARCEL-ANT OR V0HCTB-FONTE NOT EQUAL WS-FONTE-ANT OR V0HCTB-NRTIT NOT EQUAL WS-NRTIT-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTCONTABILVA.IsEmpty() || V0HCTB_NUM_APOLICE != AREA_DE_WORK.WS_NUM_APOLICE_ANT || V0HCTB_CODSUBES != AREA_DE_WORK.WS_CODSUBES_ANT || V0HCTB_NRPARCEL != AREA_DE_WORK.WS_NRPARCEL_ANT || V0HCTB_FONTE != AREA_DE_WORK.WS_FONTE_ANT || V0HCTB_NRTIT != AREA_DE_WORK.WS_NRTIT_ANT))
            {

                R1100_00_ACUMULA_PREMIO_SECTION();
            }

            /*" -2043- IF AC-PRMVG NOT GREATER ZEROES AND AC-PRMAP NOT GREATER ZEROES */

            if (AREA_DE_WORK.AC_PRMVG <= 00 && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -2044- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -2046- MOVE 'PREMIO VG E AP NAO MAIOR QUE ZEROS     ' TO LD01-OBSERVA */
                _.Move("PREMIO VG E AP NAO MAIOR QUE ZEROS     ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2047- WRITE REG-VG0139B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                /*" -2048- ADD 1 TO GV-ARQSAI1 */
                AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                /*" -2050- GO TO R0700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2052- IF (V0APOL-RAMO EQUAL 93 OR 77) AND AC-PRMVG NOT GREATER ZEROES */

            if ((V0APOL_RAMO.In("93", "77")) && AREA_DE_WORK.AC_PRMVG <= 00)
            {

                /*" -2053- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -2055- MOVE 'PREMIO VG NAO MAIOR QUE ZEROS - (93/77)' TO LD01-OBSERVA */
                _.Move("PREMIO VG NAO MAIOR QUE ZEROS - (93/77)", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2056- WRITE REG-VG0139B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                /*" -2057- ADD 1 TO GV-ARQSAI1 */
                AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                /*" -2059- GO TO R0700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2061- IF (V0APOL-RAMO EQUAL 81 OR 82) AND AC-PRMAP NOT GREATER ZEROES */

            if ((V0APOL_RAMO.In("81", "82")) && AREA_DE_WORK.AC_PRMAP <= 00)
            {

                /*" -2062- PERFORM R1050-00-ESTORNA-CONTABIL */

                R1050_00_ESTORNA_CONTABIL_SECTION();

                /*" -2064- MOVE 'PREMIO AP NAO MAIOR QUE ZEROS - (81/82)' TO LD01-OBSERVA */
                _.Move("PREMIO AP NAO MAIOR QUE ZEROS - (81/82)", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2065- WRITE REG-VG0139B1 FROM LD01 */
                _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                /*" -2066- ADD 1 TO GV-ARQSAI1 */
                AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                /*" -2068- GO TO R0700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2069- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -2071- IF AC-PRMVG NOT GREATER ZEROES OR AC-PRMAP NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_PRMVG <= 00 || AREA_DE_WORK.AC_PRMAP <= 00)
                {

                    /*" -2073- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -2074- ELSE */
                    }
                    else
                    {


                        /*" -2075- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -2077- MOVE 'PREMIO VG OU AP NAO MAIOR QUE ZEROS 97 ' TO LD01-OBSERVA */
                        _.Move("PREMIO VG OU AP NAO MAIOR QUE ZEROS 97 ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -2078- WRITE REG-VG0139B1 FROM LD01 */
                        _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                        VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                        /*" -2079- ADD 1 TO GV-ARQSAI1 */
                        AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                        /*" -2081- GO TO R0700-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -2089- MOVE +0 TO AC-IMPMORNATU AC-IMPMORACID AC-IMPINVPERM AC-IMPAMDS AC-IMPDH AC-IMPDIT AC-IMPRTO. */
            _.Move(+0, AREA_DE_WORK.AC_IMPMORNATU, AREA_DE_WORK.AC_IMPMORACID, AREA_DE_WORK.AC_IMPINVPERM, AREA_DE_WORK.AC_IMPAMDS, AREA_DE_WORK.AC_IMPDH, AREA_DE_WORK.AC_IMPDIT, AREA_DE_WORK.AC_IMPRTO);

            /*" -2091- PERFORM R1200-00-ACUMULA-IS. */

            R1200_00_ACUMULA_IS_SECTION();

            /*" -2092- IF V0APOL-RAMO EQUAL 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -2093- IF AC-IMPMORNATU NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORNATU <= 00)
                {

                    /*" -2096- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' AND V0APOL-RAMO EQUAL 97 NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE" && V0APOL_RAMO == 97)
                    {

                        /*" -2097- ELSE */
                    }
                    else
                    {


                        /*" -2098- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -2100- MOVE 'IMPMORNATU NAO MAIOR ZEROS 93,97,77  ' TO LD01-OBSERVA */
                        _.Move("IMPMORNATU NAO MAIOR ZEROS 93,97,77  ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -2101- WRITE REG-VG0139B1 FROM LD01 */
                        _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                        VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                        /*" -2102- ADD 1 TO GV-ARQSAI1 */
                        AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                        /*" -2104- GO TO R0700-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -2105- IF V0APOL-RAMO EQUAL 97 */

            if (V0APOL_RAMO == 97)
            {

                /*" -2107- IF AC-IMPMORACID NOT GREATER ZEROES OR AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 || AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -2109- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' NEXT SENTENCE */

                    if (V0PRVG_ORIG_PRODU == "EMPRE")
                    {

                        /*" -2110- ELSE */
                    }
                    else
                    {


                        /*" -2111- PERFORM R1050-00-ESTORNA-CONTABIL */

                        R1050_00_ESTORNA_CONTABIL_SECTION();

                        /*" -2113- MOVE 'MORACID/INVPERM NAO MAIOR ZEROS 97 ' TO LD01-OBSERVA */
                        _.Move("MORACID/INVPERM NAO MAIOR ZEROS 97 ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -2114- WRITE REG-VG0139B1 FROM LD01 */
                        _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                        VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                        /*" -2115- ADD 1 TO GV-ARQSAI1 */
                        AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                        /*" -2117- GO TO R0700-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -2118- IF V0APOL-RAMO EQUAL 81 OR 82 */

            if (V0APOL_RAMO.In("81", "82"))
            {

                /*" -2120- IF AC-IMPMORACID NOT GREATER ZEROES AND AC-IMPINVPERM NOT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPMORACID <= 00 && AREA_DE_WORK.AC_IMPINVPERM <= 00)
                {

                    /*" -2121- PERFORM R1050-00-ESTORNA-CONTABIL */

                    R1050_00_ESTORNA_CONTABIL_SECTION();

                    /*" -2123- MOVE 'MORACID/INVPERM NAO MAIOR ZEROS 81,82 ' TO LD01-OBSERVA */
                    _.Move("MORACID/INVPERM NAO MAIOR ZEROS 81,82 ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                    /*" -2124- WRITE REG-VG0139B1 FROM LD01 */
                    _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

                    VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

                    /*" -2125- ADD 1 TO GV-ARQSAI1 */
                    AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

                    /*" -2127- GO TO R0700-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -2129- MOVE '1015' TO WNR-EXEC-SQL. */
            _.Move("1015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2134- PERFORM R0700_10_10C1_DB_SELECT_9 */

            R0700_10_10C1_DB_SELECT_9();

            /*" -2137- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2138- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2141- END-IF. */
            }


            /*" -2142- COMPUTE V0PARC-OTNTOTAL = AC-PRMVG + AC-PRMAP */
            V0PARC_OTNTOTAL.Value = AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.AC_PRMAP;

            /*" -2143- MOVE ZEROS TO V0PARC-OTNADFRA */
            _.Move(0, V0PARC_OTNADFRA);

            /*" -2145- MOVE ZEROS TO V0PARC-OTNCUSTO */
            _.Move(0, V0PARC_OTNCUSTO);

            /*" -2148- COMPUTE V0PARC-OTNPRLIQ ROUNDED = V0PARC-OTNTOTAL - WS-VLIOCC-TOT. */
            V0PARC_OTNPRLIQ.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_VLIOCC_TOT;

            /*" -2149- IF (V0PARC-OTNPRLIQ EQUAL ZEROS) */

            if ((V0PARC_OTNPRLIQ == 00))
            {

                /*" -2150- DISPLAY 'PARCELA LIQUIDA COM VALOR ZERADO' */
                _.Display($"PARCELA LIQUIDA COM VALOR ZERADO");

                /*" -2151- PERFORM R5000-00-DISPLAY-REGISTRO */

                R5000_00_DISPLAY_REGISTRO_SECTION();

                /*" -2152- MOVE 'PARCELA LIQUIDA COM VALOR ZERADO' TO LD01-OBSERVA */
                _.Move("PARCELA LIQUIDA COM VALOR ZERADO", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                /*" -2153- MOVE V0PARC-DTVENCTO TO LD01-DTVENCTO */
                _.Move(V0PARC_DTVENCTO, ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO);

                /*" -2154- PERFORM R1010-00-GRAVA-CRITICA */

                R1010_00_GRAVA_CRITICA_SECTION();

                /*" -2155- PERFORM R0620-00-LEITURA-SVG0139B */

                R0620_00_LEITURA_SVG0139B_SECTION();

                /*" -2156- GO TO R0700-00-PROCESSA-REGISTRO */

                R0700_00_PROCESSA_REGISTRO_SECTION(); //GOTO
                return;

                /*" -2156- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-1 */
        public void R0700_10_10C1_DB_SELECT_1()
        {
            /*" -1818- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r0700_10_10C1_DB_SELECT_1_Query1 = new R0700_10_10C1_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_1_Query1.Execute(r0700_10_10C1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-UPDATE-1 */
        public void R0700_10_10C1_DB_UPDATE_1()
        {
            /*" -1828- EXEC SQL UPDATE SEGUROS.V0OPCAOPAGVA SET DTINIVIG = :V0PARC-DTVENCTO WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC */

            var r0700_10_10C1_DB_UPDATE_1_Update1 = new R0700_10_10C1_DB_UPDATE_1_Update1()
            {
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            R0700_10_10C1_DB_UPDATE_1_Update1.Execute(r0700_10_10C1_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-DB-SELECT-2 */
        public void R0700_00_PROCESSA_REGISTRO_DB_SELECT_2()
        {
            /*" -1753- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1 = new R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1.Execute(r0700_00_PROCESSA_REGISTRO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-2 */
        public void R0700_10_10C1_DB_SELECT_2()
        {
            /*" -1845- EXEC SQL SELECT PERIPGTO INTO :V0OPCP-PERIPGTO FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTTERVIG >= :V0PARC-DTVENCTO ORDER BY NRCERTIF, DTTERVIG FETCH FIRST 1 ROWS ONLY END-EXEC */

            var r0700_10_10C1_DB_SELECT_2_Query1 = new R0700_10_10C1_DB_SELECT_2_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_2_Query1.Execute(r0700_10_10C1_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0OPCP_PERIPGTO, V0OPCP_PERIPGTO);
            }


        }

        [StopWatch]
        /*" R0700-10-LOOP-PROPAUTOM */
        private void R0700_10_LOOP_PROPAUTOM(bool isPerform = false)
        {
            /*" -2164- COMPUTE V1FONT-PROPAUTOM = V1FONT-PROPAUTOM + 1. */
            V1FONT_PROPAUTOM.Value = V1FONT_PROPAUTOM + 1;

            /*" -2165- MOVE V1FONT-PROPAUTOM TO V0ENDO-NRPROPOS. */
            _.Move(V1FONT_PROPAUTOM, V0ENDO_NRPROPOS);

            /*" -2167- MOVE V1SIST-DTMOVABE TO V0ENDO-DT-LIBER. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DT_LIBER);

            /*" -2171- MOVE 0 TO V0ENDO-BCORCAP V0ENDO-BCOCOBR V0ENDO-AGERCAP V0ENDO-AGECOBR. */
            _.Move(0, V0ENDO_BCORCAP, V0ENDO_BCOCOBR, V0ENDO_AGERCAP, V0ENDO_AGECOBR);

            /*" -2173- MOVE '0' TO V0ENDO-DACCOBR. */
            _.Move("0", V0ENDO_DACCOBR);

            /*" -2175- MOVE 0 TO V0ENDO-NRRCAP V0ENDO-VLRCAP. */
            _.Move(0, V0ENDO_NRRCAP, V0ENDO_VLRCAP);

            /*" -2176- MOVE ' ' TO V0ENDO-DACRCAP. */
            _.Move(" ", V0ENDO_DACRCAP);

            /*" -2177- MOVE ' ' TO V0ENDO-IDRCAP. */
            _.Move(" ", V0ENDO_IDRCAP);

            /*" -2178- MOVE SPACES TO V0ENDO-DATARCAP */
            _.Move("", V0ENDO_DATARCAP);

            /*" -2180- MOVE -1 TO VIND-DATARCAP. */
            _.Move(-1, VIND_DATARCAP);

            /*" -2181- MOVE ZEROS TO V0ENDO-PCENTRAD. */
            _.Move(0, V0ENDO_PCENTRAD);

            /*" -2182- MOVE ZEROS TO V0ENDO-PCADICIO. */
            _.Move(0, V0ENDO_PCADICIO);

            /*" -2183- MOVE ZEROS TO V0ENDO-PRESTA1. */
            _.Move(0, V0ENDO_PRESTA1);

            /*" -2184- MOVE ZEROS TO V0ENDO-QTPARCEL. */
            _.Move(0, V0ENDO_QTPARCEL);

            /*" -2185- MOVE ZEROS TO V0ENDO-CDFRACIO. */
            _.Move(0, V0ENDO_CDFRACIO);

            /*" -2186- MOVE ZEROS TO V0ENDO-QTPRESTA. */
            _.Move(0, V0ENDO_QTPRESTA);

            /*" -2187- MOVE 1 TO V0ENDO-QTITENS. */
            _.Move(1, V0ENDO_QTITENS);

            /*" -2188- MOVE SPACES TO V0ENDO-CODTXT. */
            _.Move("", V0ENDO_CODTXT);

            /*" -2190- MOVE ZEROS TO V0ENDO-CDACEITA. */
            _.Move(0, V0ENDO_CDACEITA);

            /*" -2193- MOVE 1 TO V0ENDO-MOEDA-IMP V0ENDO-MOEDA-PRM. */
            _.Move(1, V0ENDO_MOEDA_IMP, V0ENDO_MOEDA_PRM);

            /*" -2194- MOVE '1' TO V0ENDO-TIPO-ENDO. */
            _.Move("1", V0ENDO_TIPO_ENDO);

            /*" -2196- MOVE 'VG0139B' TO V0ENDO-COD-USUAR. */
            _.Move("VG0139B", V0ENDO_COD_USUAR);

            /*" -2198- MOVE 1 TO V0ENDO-OCORR-END. */
            _.Move(1, V0ENDO_OCORR_END);

            /*" -2200- MOVE '1' TO V0ENDO-SITUACAO. */
            _.Move("1", V0ENDO_SITUACAO);

            /*" -2201- MOVE ZEROS TO V0ENDO-COD-EMPRESA. */
            _.Move(0, V0ENDO_COD_EMPRESA);

            /*" -2202- MOVE '1' TO V0ENDO-CORRECAO. */
            _.Move("1", V0ENDO_CORRECAO);

            /*" -2203- MOVE 'S' TO V0ENDO-ISENTA-CST. */
            _.Move("S", V0ENDO_ISENTA_CST);

            /*" -2204- MOVE -1 TO VIND-DTVENCTO. */
            _.Move(-1, VIND_DTVENCTO);

            /*" -2206- MOVE -1 TO VIND-VLCUSEMI. */
            _.Move(-1, VIND_VLCUSEMI);

            /*" -2207- MOVE -1 TO VIND-CFPREFIX. */
            _.Move(-1, VIND_CFPREFIX);

            /*" -2208- MOVE V0APOL-RAMO TO V0ENDO-RAMO. */
            _.Move(V0APOL_RAMO, V0ENDO_RAMO);

            /*" -2210- MOVE V0PROP-CODPRODU TO V0ENDO-CODPRODU. */
            _.Move(V0PROP_CODPRODU, V0ENDO_CODPRODU);

            /*" -2212- MOVE V0ENDO-DTINIVIG TO V0ENDO-DATPRO V0ENDO-DTEMIS. */
            _.Move(V0ENDO_DTINIVIG, V0ENDO_DATPRO, V0ENDO_DTEMIS);

            /*" -2214- MOVE V1SIST-DTMOVABE TO V0ENDO-DTEMIS. */
            _.Move(V1SIST_DTMOVABE, V0ENDO_DTEMIS);

            /*" -2215- IF V0ENDO-DTEMIS LESS V0ENDO-DTINIVIG */

            if (V0ENDO_DTEMIS < V0ENDO_DTINIVIG)
            {

                /*" -2216- ADD 1 TO DP-EMISSAO */
                AREA_DE_WORK.DP_EMISSAO.Value = AREA_DE_WORK.DP_EMISSAO + 1;

                /*" -2217- PERFORM R0620-00-LEITURA-SVG0139B */

                R0620_00_LEITURA_SVG0139B_SECTION();

                /*" -2220- GO TO R0700-00-PROCESSA-REGISTRO. */

                R0700_00_PROCESSA_REGISTRO_SECTION(); //GOTO
                return;
            }


            /*" -2228- PERFORM R0700_10_LOOP_PROPAUTOM_DB_SELECT_1 */

            R0700_10_LOOP_PROPAUTOM_DB_SELECT_1();

            /*" -2232- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2236- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2238- MOVE '1025' TO WNR-EXEC-SQL. */
            _.Move("1025", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2328- PERFORM R0700_10_LOOP_PROPAUTOM_DB_INSERT_1 */

            R0700_10_LOOP_PROPAUTOM_DB_INSERT_1();

            /*" -2331- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2332- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -2333- IF V0ENDO-NRPROPOS NOT EQUAL ZEROS */

                    if (V0ENDO_NRPROPOS != 00)
                    {

                        /*" -2334- GO TO R0700-10-LOOP-PROPAUTOM */
                        new Task(() => R0700_10_LOOP_PROPAUTOM()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -2335- ELSE */
                    }
                    else
                    {


                        /*" -2336- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2337- ELSE */
                    }

                }
                else
                {


                    /*" -2339- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2341- ADD +1 TO AC-I-V0ENDOSSO. */
            AREA_DE_WORK.AC_I_V0ENDOSSO.Value = AREA_DE_WORK.AC_I_V0ENDOSSO + +1;

            /*" -2343- MOVE '1026' TO WNR-EXEC-SQL. */
            _.Move("1026", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2347- PERFORM R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1 */

            R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1();

            /*" -2350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2352- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2354- ADD 1 TO AC-U-V0FONTE. */
            AREA_DE_WORK.AC_U_V0FONTE.Value = AREA_DE_WORK.AC_U_V0FONTE + 1;

            /*" -2356- PERFORM R1300-00-GRAVA-COSSEGURO. */

            R1300_00_GRAVA_COSSEGURO_SECTION();

            /*" -2357- MOVE V0ENDO-NUM-APOLICE TO V0PARC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0PARC_NUM_APOL);

            /*" -2358- MOVE V0ENDO-NRENDOS TO V0PARC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0PARC_NRENDOS);

            /*" -2360- MOVE ZEROS TO V0PARC-NRPARCEL */
            _.Move(0, V0PARC_NRPARCEL);

            /*" -2361- MOVE '0' TO V0PARC-DACPARC */
            _.Move("0", V0PARC_DACPARC);

            /*" -2362- MOVE V0ENDO-FONTE TO V0PARC-FONTE */
            _.Move(V0ENDO_FONTE, V0PARC_FONTE);

            /*" -2363- MOVE WS-NRTIT-ANT TO V0PARC-NRTIT */
            _.Move(AREA_DE_WORK.WS_NRTIT_ANT, V0PARC_NRTIT);

            /*" -2365- MOVE ZEROS TO V0PARC-VAL-DES-IX */
            _.Move(0, V0PARC_VAL_DES_IX);

            /*" -2367- MOVE V0PARC-OTNPRLIQ TO V0PARC-PRM-TAR-IX. */
            _.Move(V0PARC_OTNPRLIQ, V0PARC_PRM_TAR_IX);

            /*" -2369- MOVE WS-VLIOCC-TOT TO V0PARC-OTNIOF */
            _.Move(AREA_DE_WORK.WS_VLIOCC_TOT, V0PARC_OTNIOF);

            /*" -2370- MOVE 2 TO V0PARC-OCORHIST */
            _.Move(2, V0PARC_OCORHIST);

            /*" -2371- MOVE ZEROS TO V0PARC-QTDDOC */
            _.Move(0, V0PARC_QTDDOC);

            /*" -2372- MOVE '1' TO V0PARC-SITUACAO */
            _.Move("1", V0PARC_SITUACAO);

            /*" -2374- MOVE ZEROS TO V0PARC-COD-EMPRESA. */
            _.Move(0, V0PARC_COD_EMPRESA);

            /*" -2377- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2398- PERFORM R0700_10_LOOP_PROPAUTOM_DB_INSERT_2 */

            R0700_10_LOOP_PROPAUTOM_DB_INSERT_2();

            /*" -2401- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2403- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2405- ADD +1 TO AC-I-V0PARCELA. */
            AREA_DE_WORK.AC_I_V0PARCELA.Value = AREA_DE_WORK.AC_I_V0PARCELA + +1;

            /*" -2407- PERFORM R1400-00-GRAVA-V0HISTOPARC. */

            R1400_00_GRAVA_V0HISTOPARC_SECTION();

            /*" -2413- PERFORM R1500-00-GRAVA-OPERACAO-BAIXA. */

            R1500_00_GRAVA_OPERACAO_BAIXA_SECTION();

            /*" -2413- PERFORM R2000-TRATA-COBERTURAS. */

            R2000_TRATA_COBERTURAS_SECTION();

        }

        [StopWatch]
        /*" R0700-10-LOOP-PROPAUTOM-DB-SELECT-1 */
        public void R0700_10_LOOP_PROPAUTOM_DB_SELECT_1()
        {
            /*" -2228- EXEC SQL SELECT COD_PRODUTO INTO :V0ENDO-CODPRODU FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND COD_SUBGRUPO = :V0ENDO-CODSUBES FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1 = new R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
            };

            var executed_1 = R0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1.Execute(r0700_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_CODPRODU, V0ENDO_CODPRODU);
            }


        }

        [StopWatch]
        /*" R0700-10-LOOP-PROPAUTOM-DB-INSERT-1 */
        public void R0700_10_LOOP_PROPAUTOM_DB_INSERT_1()
        {
            /*" -2328- EXEC SQL INSERT INTO SEGUROS.V0ENDOSSO (NUM_APOLICE , NRENDOS , CODSUBES , FONTE , NRPROPOS , DATPRO , DATA_LIBERACAO , DTEMIS , NRRCAP , VLRCAP , BCORCAP , AGERCAP , DACRCAP , IDRCAP , BCOCOBR , AGECOBR , DACCOBR , DTINIVIG , DTTERVIG , CDFRACIO , PCENTRAD , PCADICIO , PRESTA1 , QTPARCEL , QTPRESTA , QTITENS , CODTXT , CDACEITA , COD_MOEDA_IMP , COD_MOEDA_PRM , TIPO_ENDOSSO , COD_USUARIO , OCORR_ENDERECO , SITUACAO , DATARCAP , COD_EMPRESA , CORRECAO , ISENTA_CUSTO , TIMESTAMP , DTVENCTO , CFPREFIX , VLCUSEMI , RAMO , CODPRODU) VALUES (:V0ENDO-NUM-APOLICE, :V0ENDO-NRENDOS, :V0ENDO-CODSUBES, :V0ENDO-FONTE, :V0ENDO-NRPROPOS, :V0ENDO-DATPRO, :V0ENDO-DT-LIBER, :V0ENDO-DTEMIS, :V0ENDO-NRRCAP, :V0ENDO-VLRCAP, :V0ENDO-BCORCAP, :V0ENDO-AGERCAP, :V0ENDO-DACRCAP, :V0ENDO-IDRCAP, :V0ENDO-BCOCOBR, :V0ENDO-AGECOBR, :V0ENDO-DACCOBR, :V0ENDO-DTINIVIG, :V0ENDO-DTTERVIG, :V0ENDO-CDFRACIO, :V0ENDO-PCENTRAD, :V0ENDO-PCADICIO, :V0ENDO-PRESTA1, :V0ENDO-QTPARCEL, :V0ENDO-QTPRESTA, :V0ENDO-QTITENS, :V0ENDO-CODTXT, :V0ENDO-CDACEITA, :V0ENDO-MOEDA-IMP, :V0ENDO-MOEDA-PRM, :V0ENDO-TIPO-ENDO, :V0ENDO-COD-USUAR, :V0ENDO-OCORR-END, :V0ENDO-SITUACAO, :V0ENDO-DATARCAP:VIND-DATARCAP, :V0ENDO-COD-EMPRESA, :V0ENDO-CORRECAO, :V0ENDO-ISENTA-CST, CURRENT TIMESTAMP, :V0ENDO-DTVENCTO:VIND-DTVENCTO, :V0ENDO-CFPREFIX:VIND-CFPREFIX, :V0ENDO-VLCUSEMI:VIND-VLCUSEMI, :V0ENDO-RAMO, :V0ENDO-CODPRODU) END-EXEC. */

            var r0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1 = new R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
                V0ENDO_NRPROPOS = V0ENDO_NRPROPOS.ToString(),
                V0ENDO_DATPRO = V0ENDO_DATPRO.ToString(),
                V0ENDO_DT_LIBER = V0ENDO_DT_LIBER.ToString(),
                V0ENDO_DTEMIS = V0ENDO_DTEMIS.ToString(),
                V0ENDO_NRRCAP = V0ENDO_NRRCAP.ToString(),
                V0ENDO_VLRCAP = V0ENDO_VLRCAP.ToString(),
                V0ENDO_BCORCAP = V0ENDO_BCORCAP.ToString(),
                V0ENDO_AGERCAP = V0ENDO_AGERCAP.ToString(),
                V0ENDO_DACRCAP = V0ENDO_DACRCAP.ToString(),
                V0ENDO_IDRCAP = V0ENDO_IDRCAP.ToString(),
                V0ENDO_BCOCOBR = V0ENDO_BCOCOBR.ToString(),
                V0ENDO_AGECOBR = V0ENDO_AGECOBR.ToString(),
                V0ENDO_DACCOBR = V0ENDO_DACCOBR.ToString(),
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0ENDO_CDFRACIO = V0ENDO_CDFRACIO.ToString(),
                V0ENDO_PCENTRAD = V0ENDO_PCENTRAD.ToString(),
                V0ENDO_PCADICIO = V0ENDO_PCADICIO.ToString(),
                V0ENDO_PRESTA1 = V0ENDO_PRESTA1.ToString(),
                V0ENDO_QTPARCEL = V0ENDO_QTPARCEL.ToString(),
                V0ENDO_QTPRESTA = V0ENDO_QTPRESTA.ToString(),
                V0ENDO_QTITENS = V0ENDO_QTITENS.ToString(),
                V0ENDO_CODTXT = V0ENDO_CODTXT.ToString(),
                V0ENDO_CDACEITA = V0ENDO_CDACEITA.ToString(),
                V0ENDO_MOEDA_IMP = V0ENDO_MOEDA_IMP.ToString(),
                V0ENDO_MOEDA_PRM = V0ENDO_MOEDA_PRM.ToString(),
                V0ENDO_TIPO_ENDO = V0ENDO_TIPO_ENDO.ToString(),
                V0ENDO_COD_USUAR = V0ENDO_COD_USUAR.ToString(),
                V0ENDO_OCORR_END = V0ENDO_OCORR_END.ToString(),
                V0ENDO_SITUACAO = V0ENDO_SITUACAO.ToString(),
                V0ENDO_DATARCAP = V0ENDO_DATARCAP.ToString(),
                VIND_DATARCAP = VIND_DATARCAP.ToString(),
                V0ENDO_COD_EMPRESA = V0ENDO_COD_EMPRESA.ToString(),
                V0ENDO_CORRECAO = V0ENDO_CORRECAO.ToString(),
                V0ENDO_ISENTA_CST = V0ENDO_ISENTA_CST.ToString(),
                V0ENDO_DTVENCTO = V0ENDO_DTVENCTO.ToString(),
                VIND_DTVENCTO = VIND_DTVENCTO.ToString(),
                V0ENDO_CFPREFIX = V0ENDO_CFPREFIX.ToString(),
                VIND_CFPREFIX = VIND_CFPREFIX.ToString(),
                V0ENDO_VLCUSEMI = V0ENDO_VLCUSEMI.ToString(),
                VIND_VLCUSEMI = VIND_VLCUSEMI.ToString(),
                V0ENDO_RAMO = V0ENDO_RAMO.ToString(),
                V0ENDO_CODPRODU = V0ENDO_CODPRODU.ToString(),
            };

            R0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r0700_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0700-10-LOOP-PROPAUTOM-DB-UPDATE-1 */
        public void R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -2347- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :V1FONT-PROPAUTOM WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 = new R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                V1FONT_PROPAUTOM = V1FONT_PROPAUTOM.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r0700_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-3 */
        public void R0700_10_10C1_DB_SELECT_3()
        {
            /*" -1872- EXEC SQL SELECT DATE (:V0ENDO-DTINIVIG) , DATE (:V0ENDO-DTINIVIG) + :V0OPCP-PERIPGTO MONTHS INTO :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r0700_10_10C1_DB_SELECT_3_Query1 = new R0700_10_10C1_DB_SELECT_3_Query1()
            {
                V0ENDO_DTINIVIG = V0ENDO_DTINIVIG.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_3_Query1.Execute(r0700_10_10C1_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R0700-10-LOOP-PROPAUTOM-DB-INSERT-2 */
        public void R0700_10_LOOP_PROPAUTOM_DB_INSERT_2()
        {
            /*" -2398- EXEC SQL INSERT INTO SEGUROS.V0PARCELA VALUES (:V0PARC-NUM-APOL , :V0PARC-NRENDOS , :V0PARC-NRPARCEL , :V0PARC-DACPARC , :V0PARC-FONTE , :V0PARC-NRTIT , :V0PARC-PRM-TAR-IX , :V0PARC-VAL-DES-IX , :V0PARC-OTNPRLIQ , :V0PARC-OTNADFRA , :V0PARC-OTNCUSTO , :V0PARC-OTNIOF , :V0PARC-OTNTOTAL , :V0PARC-OCORHIST , :V0PARC-QTDDOC , :V0PARC-SITUACAO , :V0PARC-COD-EMPRESA , CURRENT TIMESTAMP, NULL) END-EXEC. */

            var r0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1 = new R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1()
            {
                V0PARC_NUM_APOL = V0PARC_NUM_APOL.ToString(),
                V0PARC_NRENDOS = V0PARC_NRENDOS.ToString(),
                V0PARC_NRPARCEL = V0PARC_NRPARCEL.ToString(),
                V0PARC_DACPARC = V0PARC_DACPARC.ToString(),
                V0PARC_FONTE = V0PARC_FONTE.ToString(),
                V0PARC_NRTIT = V0PARC_NRTIT.ToString(),
                V0PARC_PRM_TAR_IX = V0PARC_PRM_TAR_IX.ToString(),
                V0PARC_VAL_DES_IX = V0PARC_VAL_DES_IX.ToString(),
                V0PARC_OTNPRLIQ = V0PARC_OTNPRLIQ.ToString(),
                V0PARC_OTNADFRA = V0PARC_OTNADFRA.ToString(),
                V0PARC_OTNCUSTO = V0PARC_OTNCUSTO.ToString(),
                V0PARC_OTNIOF = V0PARC_OTNIOF.ToString(),
                V0PARC_OTNTOTAL = V0PARC_OTNTOTAL.ToString(),
                V0PARC_OCORHIST = V0PARC_OCORHIST.ToString(),
                V0PARC_QTDDOC = V0PARC_QTDDOC.ToString(),
                V0PARC_SITUACAO = V0PARC_SITUACAO.ToString(),
                V0PARC_COD_EMPRESA = V0PARC_COD_EMPRESA.ToString(),
            };

            R0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1.Execute(r0700_10_LOOP_PROPAUTOM_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-DB-SELECT-3 */
        public void R0700_00_PROCESSA_REGISTRO_DB_SELECT_3()
        {
            /*" -1773- EXEC SQL SELECT DTVENCTO INTO :V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 = new R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            var executed_1 = R0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1.Execute(r0700_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-4 */
        public void R0700_10_10C1_DB_SELECT_4()
        {
            /*" -1888- EXEC SQL SELECT DATE (:V0ENDO-DTTERVIG), DATE (:V0ENDO-DTTERVIG) + :V0OPCP-PERIPGTO MONTHS INTO :V0ENDO-DTINIVIG , :V0ENDO-DTTERVIG FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r0700_10_10C1_DB_SELECT_4_Query1 = new R0700_10_10C1_DB_SELECT_4_Query1()
            {
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_4_Query1.Execute(r0700_10_10C1_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTINIVIG, V0ENDO_DTINIVIG);
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R0700-98-COMMIT */
        private void R0700_98_COMMIT(bool isPerform = false)
        {
            /*" -2418- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2420- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2420- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-UPDATE-2 */
        public void R0700_10_10C1_DB_UPDATE_2()
        {
            /*" -1987- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r0700_10_10C1_DB_UPDATE_2_Update1 = new R0700_10_10C1_DB_UPDATE_2_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R0700_10_10C1_DB_UPDATE_2_Update1.Execute(r0700_10_10C1_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-5 */
        public void R0700_10_10C1_DB_SELECT_5()
        {
            /*" -1902- EXEC SQL SELECT DATE(:V0ENDO-DTTERVIG) - 1 DAY INTO :V0ENDO-DTTERVIG FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC */

            var r0700_10_10C1_DB_SELECT_5_Query1 = new R0700_10_10C1_DB_SELECT_5_Query1()
            {
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_5_Query1.Execute(r0700_10_10C1_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R0700-00-PROCESSA-REGISTRO-DB-SELECT-4 */
        public void R0700_00_PROCESSA_REGISTRO_DB_SELECT_4()
        {
            /*" -1788- EXEC SQL SELECT DTVENCTO INTO :V0HCOB-DTVENCTO FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1 = new R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1.Execute(r0700_00_PROCESSA_REGISTRO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-6 */
        public void R0700_10_10C1_DB_SELECT_6()
        {
            /*" -1934- EXEC SQL SELECT DTINIVIG ,(DTINIVIG + :V0OPCP-PERIPGTO MONTHS) INTO :WHOST-DTINIVIG ,:WHOST-DTENDFIM FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 END-EXEC. */

            var r0700_10_10C1_DB_SELECT_6_Query1 = new R0700_10_10C1_DB_SELECT_6_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_6_Query1.Execute(r0700_10_10C1_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
                _.Move(executed_1.WHOST_DTENDFIM, WHOST_DTENDFIM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-7 */
        public void R0700_10_10C1_DB_SELECT_7()
        {
            /*" -1973- EXEC SQL SELECT ENDOSCOB INTO :V0ENDO-NRENDOS FROM SEGUROS.V0NUMERO_AES WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r0700_10_10C1_DB_SELECT_7_Query1 = new R0700_10_10C1_DB_SELECT_7_Query1()
            {
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_7_Query1.Execute(r0700_10_10C1_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_NRENDOS, V0ENDO_NRENDOS);
            }


        }

        [StopWatch]
        /*" R0710-00-SELECT-HCTBVA-SECTION */
        private void R0710_00_SELECT_HCTBVA_SECTION()
        {
            /*" -2431- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2437- MOVE 'S' TO AC-FATURA. */
            _.Move("S", AREA_DE_WORK.AC_FATURA);

            /*" -2439- IF V0HCTB-CODOPER GREATER 199 AND V0HCTB-CODOPER LESS 300 */

            if (V0HCTB_CODOPER > 199 && V0HCTB_CODOPER < 300)
            {

                /*" -2440- PERFORM R0720-00-SELECT-HCTBVA */

                R0720_00_SELECT_HCTBVA_SECTION();

                /*" -2446- GO TO R0710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2448- IF V0HCTB-CODOPER LESS 500 AND V0HCTB-CODOPER GREATER 599 */

            if (V0HCTB_CODOPER < 500 && V0HCTB_CODOPER > 599)
            {

                /*" -2451- GO TO R0710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2461- PERFORM R0710_00_SELECT_HCTBVA_DB_SELECT_1 */

            R0710_00_SELECT_HCTBVA_DB_SELECT_1();

            /*" -2465- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2466- MOVE 'N' TO AC-FATURA */
                _.Move("N", AREA_DE_WORK.AC_FATURA);

                /*" -2467- ELSE */
            }
            else
            {


                /*" -2468- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2469- MOVE 'S' TO AC-FATURA */
                    _.Move("S", AREA_DE_WORK.AC_FATURA);

                    /*" -2470- ELSE */
                }
                else
                {


                    /*" -2471- DISPLAY 'R0710-00-SELECT-HCTBVA - ESTORNO ' */
                    _.Display($"R0710-00-SELECT-HCTBVA - ESTORNO ");

                    /*" -2471- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0710-00-SELECT-HCTBVA-DB-SELECT-1 */
        public void R0710_00_SELECT_HCTBVA_DB_SELECT_1()
        {
            /*" -2461- EXEC SQL SELECT NRENDOS INTO :V0HCTB-NRENDOS FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND CODOPER BETWEEN 200 AND 299 AND NRENDOS > 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1 = new R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1.Execute(r0710_00_SELECT_HCTBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_NRENDOS, V0HCTB_NRENDOS);
            }


        }

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-8 */
        public void R0700_10_10C1_DB_SELECT_8()
        {
            /*" -2018- EXEC SQL SELECT COD_GRUPO_SUSEP INTO :VG080-COD-GRUPO-SUSEP FROM SEGUROS.VG_PARAM_RAMO_CONJ WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND COD_SUBGRUPO = +0 END-EXEC. */

            var r0700_10_10C1_DB_SELECT_8_Query1 = new R0700_10_10C1_DB_SELECT_8_Query1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_8_Query1.Execute(r0700_10_10C1_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG080_COD_GRUPO_SUSEP, VG080.DCLVG_PARAM_RAMO_CONJ.VG080_COD_GRUPO_SUSEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0700-10-10C1-DB-SELECT-9 */
        public void R0700_10_10C1_DB_SELECT_9()
        {
            /*" -2134- EXEC SQL SELECT PROPAUTOM INTO :V1FONT-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :V0ENDO-FONTE END-EXEC. */

            var r0700_10_10C1_DB_SELECT_9_Query1 = new R0700_10_10C1_DB_SELECT_9_Query1()
            {
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            var executed_1 = R0700_10_10C1_DB_SELECT_9_Query1.Execute(r0700_10_10C1_DB_SELECT_9_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONT_PROPAUTOM, V1FONT_PROPAUTOM);
            }


        }

        [StopWatch]
        /*" R0720-00-SELECT-HCTBVA-SECTION */
        private void R0720_00_SELECT_HCTBVA_SECTION()
        {
            /*" -2484- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2493- PERFORM R0720_00_SELECT_HCTBVA_DB_SELECT_1 */

            R0720_00_SELECT_HCTBVA_DB_SELECT_1();

            /*" -2497- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2498- MOVE 'S' TO AC-FATURA */
                _.Move("S", AREA_DE_WORK.AC_FATURA);

                /*" -2499- ELSE */
            }
            else
            {


                /*" -2500- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2501- MOVE 'N' TO AC-FATURA */
                    _.Move("N", AREA_DE_WORK.AC_FATURA);

                    /*" -2502- ELSE */
                }
                else
                {


                    /*" -2503- DISPLAY 'R0720-00-SELECT-HCTBVA - ESTORNO ' */
                    _.Display($"R0720-00-SELECT-HCTBVA - ESTORNO ");

                    /*" -2503- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0720-00-SELECT-HCTBVA-DB-SELECT-1 */
        public void R0720_00_SELECT_HCTBVA_DB_SELECT_1()
        {
            /*" -2493- EXEC SQL SELECT NRENDOS INTO :V0HCTB-NRENDOS FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND CODOPER BETWEEN 500 AND 599 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1 = new R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
            };

            var executed_1 = R0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1.Execute(r0720_00_SELECT_HCTBVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_NRENDOS, V0HCTB_NRENDOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_99_SAIDA*/

        [StopWatch]
        /*" R0730-00-SELECT-HISCOBPR-SECTION */
        private void R0730_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2516- MOVE '0730' TO WNR-EXEC-SQL. */
            _.Move("0730", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2535- PERFORM R0730_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R0730_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2538- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2539- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2540- PERFORM R0740-00-SELECT-HISCOBPR */

                    R0740_00_SELECT_HISCOBPR_SECTION();

                    /*" -2541- ELSE */
                }
                else
                {


                    /*" -2542- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -2544- MOVE 'REGISTRO DUPLICADO      V0COBERPROPVA' TO LD01-OBSERVA */
                        _.Move("REGISTRO DUPLICADO      V0COBERPROPVA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -2546- MOVE V0PARC-DTVENCTO TO LD01-DTVENCTO */
                        _.Move(V0PARC_DTVENCTO, ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO);

                        /*" -2547- ELSE */
                    }
                    else
                    {


                        /*" -2548- DISPLAY 'R0730-00-SELECT-HISCOBPR    ' */
                        _.Display($"R0730-00-SELECT-HISCOBPR    ");

                        /*" -2548- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0730-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R0730_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2535- EXEC SQL SELECT NRCERTIF, OCORHIST, DTINIVIG, DTTERVIG INTO :V0COBP-NRCERTIF, :V0COBP-OCORHIST, :V0COBP-DTINIVIG-ENDO, :V0COBP-DTTERVIG-ENDO FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND :V0PARC-DTVENCTO BETWEEN DTINIVIG AND DTTERVIG ORDER BY NRCERTIF, DTINIVIG FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r0730_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_NRCERTIF, V0COBP_NRCERTIF);
                _.Move(executed_1.V0COBP_OCORHIST, V0COBP_OCORHIST);
                _.Move(executed_1.V0COBP_DTINIVIG_ENDO, V0COBP_DTINIVIG_ENDO);
                _.Move(executed_1.V0COBP_DTTERVIG_ENDO, V0COBP_DTTERVIG_ENDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0730_99_SAIDA*/

        [StopWatch]
        /*" R0740-00-SELECT-HISCOBPR-SECTION */
        private void R0740_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -2561- MOVE '0740' TO WNR-EXEC-SQL. */
            _.Move("0740", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2579- PERFORM R0740_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R0740_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -2582- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2583- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2585- MOVE 'REGISTRO NAO CADASTRADO V0COBERPROPVA' TO LD01-OBSERVA */
                    _.Move("REGISTRO NAO CADASTRADO V0COBERPROPVA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                    /*" -2587- MOVE V0PARC-DTVENCTO TO LD01-DTVENCTO */
                    _.Move(V0PARC_DTVENCTO, ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO);

                    /*" -2588- ELSE */
                }
                else
                {


                    /*" -2589- IF SQLCODE EQUAL -811 */

                    if (DB.SQLCODE == -811)
                    {

                        /*" -2591- MOVE 'REGISTRO DUPLICADO      V0COBERPROPVA' TO LD01-OBSERVA */
                        _.Move("REGISTRO DUPLICADO      V0COBERPROPVA", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                        /*" -2593- MOVE V0PARC-DTVENCTO TO LD01-DTVENCTO */
                        _.Move(V0PARC_DTVENCTO, ARQUIVOS_SAIDA.LD01.LD01_DTVENCTO);

                        /*" -2594- ELSE */
                    }
                    else
                    {


                        /*" -2595- DISPLAY 'R0740-00-SELECT-HISCOBPR    ' */
                        _.Display($"R0740-00-SELECT-HISCOBPR    ");

                        /*" -2595- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0740-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R0740_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -2579- EXEC SQL SELECT NRCERTIF, OCORHIST, DTINIVIG, DTTERVIG INTO :V0COBP-NRCERTIF, :V0COBP-OCORHIST, :V0COBP-DTINIVIG-ENDO, :V0COBP-DTTERVIG-ENDO FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTB-NRCERTIF AND DTTERVIG >= :V0PARC-DTVENCTO ORDER BY NRCERTIF, DTTERVIG FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r0740_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBP_NRCERTIF, V0COBP_NRCERTIF);
                _.Move(executed_1.V0COBP_OCORHIST, V0COBP_OCORHIST);
                _.Move(executed_1.V0COBP_DTINIVIG_ENDO, V0COBP_DTINIVIG_ENDO);
                _.Move(executed_1.V0COBP_DTTERVIG_ENDO, V0COBP_DTTERVIG_ENDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0740_99_SAIDA*/

        [StopWatch]
        /*" R0750-00-SELECT-V0ENDOSSO-SECTION */
        private void R0750_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -2608- MOVE '0750' TO WNR-EXEC-SQL. */
            _.Move("0750", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2618- PERFORM R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -2621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2622- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2624- MOVE 'ENDOSSO  NAO CADASTRADO              ' TO LD01-OBSERVA */
                    _.Move("ENDOSSO  NAO CADASTRADO              ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                    /*" -2626- MOVE V0ENDO-DTINIVIG TO LD01-DTINIVIG */
                    _.Move(V0ENDO_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

                    /*" -2627- ELSE */
                }
                else
                {


                    /*" -2628- DISPLAY 'R0750-00-SELECT-V0ENDOSSO   ' */
                    _.Display($"R0750-00-SELECT-V0ENDOSSO   ");

                    /*" -2631- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2632- IF WHOST-DTTERVIG LESS V0PARC-DTVENCTO */

            if (WHOST_DTTERVIG < V0PARC_DTVENCTO)
            {

                /*" -2632- PERFORM R0760-00-SELECT-V0COBERAPOL. */

                R0760_00_SELECT_V0COBERAPOL_SECTION();
            }


        }

        [StopWatch]
        /*" R0750-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -2618- EXEC SQL SELECT CODSUBES, DTTERVIG INTO :WHOST-CODSUBES, :WHOST-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 WITH UR END-EXEC. */

            var r0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r0750_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODSUBES, WHOST_CODSUBES);
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_99_SAIDA*/

        [StopWatch]
        /*" R0760-00-SELECT-V0COBERAPOL-SECTION */
        private void R0760_00_SELECT_V0COBERAPOL_SECTION()
        {
            /*" -2645- MOVE '0760' TO WNR-EXEC-SQL. */
            _.Move("0760", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2654- PERFORM R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1 */

            R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1();

            /*" -2657- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2658- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2660- MOVE 'SOLICITAR PRORROGACAO DA APOLICE     ' TO LD01-OBSERVA */
                    _.Move("SOLICITAR PRORROGACAO DA APOLICE     ", ARQUIVOS_SAIDA.LD01.LD01_OBSERVA);

                    /*" -2662- MOVE V0ENDO-DTINIVIG TO LD01-DTINIVIG */
                    _.Move(V0ENDO_DTINIVIG, ARQUIVOS_SAIDA.LD01.LD01_DTINIVIG);

                    /*" -2663- ELSE */
                }
                else
                {


                    /*" -2664- DISPLAY 'R0760-00-SELECT-V0COBERAPOL ' */
                    _.Display($"R0760-00-SELECT-V0COBERAPOL ");

                    /*" -2665- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2666- ELSE */
                }

            }
            else
            {


                /*" -2666- PERFORM R0770-00-UPDATE-V0ENDOSSO. */

                R0770_00_UPDATE_V0ENDOSSO_SECTION();
            }


        }

        [StopWatch]
        /*" R0760-00-SELECT-V0COBERAPOL-DB-SELECT-1 */
        public void R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1()
        {
            /*" -2654- EXEC SQL SELECT DATA_TERVIGENCIA INTO :WHOST-DTTERVIG FROM SEGUROS.V0COBERAPOL WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 AND DATA_TERVIGENCIA > :V0PARC-DTVENCTO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1 = new R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1()
            {
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
            };

            var executed_1 = R0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1.Execute(r0760_00_SELECT_V0COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTTERVIG, WHOST_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0760_99_SAIDA*/

        [StopWatch]
        /*" R0770-00-UPDATE-V0ENDOSSO-SECTION */
        private void R0770_00_UPDATE_V0ENDOSSO_SECTION()
        {
            /*" -2679- MOVE '0770' TO WNR-EXEC-SQL. */
            _.Move("0770", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2683- PERFORM R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1 */

            R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1();

            /*" -2686- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2687- DISPLAY 'R0770-00-UPDATE-V0ENDOSSO   ' */
                _.Display($"R0770-00-UPDATE-V0ENDOSSO   ");

                /*" -2687- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0770-00-UPDATE-V0ENDOSSO-DB-UPDATE-1 */
        public void R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1()
        {
            /*" -2683- EXEC SQL UPDATE SEGUROS.V0ENDOSSO SET DTTERVIG = :WHOST-DTTERVIG WHERE NUM_APOLICE = :V0HCTB-NUM-APOLICE AND NRENDOS = 0 END-EXEC. */

            var r0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1 = new R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1()
            {
                WHOST_DTTERVIG = WHOST_DTTERVIG.ToString(),
                V0HCTB_NUM_APOLICE = V0HCTB_NUM_APOLICE.ToString(),
            };

            R0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1.Execute(r0770_00_UPDATE_V0ENDOSSO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0770_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-GRAVA-CRITICA-SECTION */
        private void R1010_00_GRAVA_CRITICA_SECTION()
        {
            /*" -2699- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2701- MOVE V0HCTB-NRCERTIF TO LD01-NRCERTIF. */
            _.Move(V0HCTB_NRCERTIF, ARQUIVOS_SAIDA.LD01.LD01_NRCERTIF);

            /*" -2703- MOVE V0HCTB-NRPARCEL TO LD01-NRPARCEL. */
            _.Move(V0HCTB_NRPARCEL, ARQUIVOS_SAIDA.LD01.LD01_NRPARCEL);

            /*" -2705- MOVE V0HCTB-NRTIT TO LD01-NRTIT. */
            _.Move(V0HCTB_NRTIT, ARQUIVOS_SAIDA.LD01.LD01_NRTIT);

            /*" -2707- MOVE V0HCTB-OCORHIST TO LD01-OCORHIST1. */
            _.Move(V0HCTB_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST1);

            /*" -2709- MOVE V0HCTB-NUM-APOLICE TO LD01-NUMAPOL. */
            _.Move(V0HCTB_NUM_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUMAPOL);

            /*" -2711- MOVE V0HCTB-CODSUBES TO LD01-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, ARQUIVOS_SAIDA.LD01.LD01_CODSUBES);

            /*" -2713- MOVE V0HCTB-FONTE TO LD01-FONTE. */
            _.Move(V0HCTB_FONTE, ARQUIVOS_SAIDA.LD01.LD01_FONTE);

            /*" -2715- MOVE V0PROP-CODPRODU TO LD01-CODPRODU. */
            _.Move(V0PROP_CODPRODU, ARQUIVOS_SAIDA.LD01.LD01_CODPRODU);

            /*" -2717- MOVE V0PROP-CODCLIEN TO LD01-CODCLIEN. */
            _.Move(V0PROP_CODCLIEN, ARQUIVOS_SAIDA.LD01.LD01_CODCLIEN);

            /*" -2719- MOVE V0HCTB-DTMOVTO TO LD01-DTMOVTO. */
            _.Move(V0HCTB_DTMOVTO, ARQUIVOS_SAIDA.LD01.LD01_DTMOVTO);

            /*" -2721- MOVE V0PROP-DTQITBCO TO LD01-DTQITBCO. */
            _.Move(V0PROP_DTQITBCO, ARQUIVOS_SAIDA.LD01.LD01_DTQITBCO);

            /*" -2723- MOVE V0PROP-DTPROXVEN TO LD01-DTPROXVEN. */
            _.Move(V0PROP_DTPROXVEN, ARQUIVOS_SAIDA.LD01.LD01_DTPROXVEN);

            /*" -2725- MOVE V0PROP-OCORHIST TO LD01-OCORHIST2. */
            _.Move(V0PROP_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST2);

            /*" -2727- MOVE V0HCTB-CODOPER TO LD01-OPERACAO. */
            _.Move(V0HCTB_CODOPER, ARQUIVOS_SAIDA.LD01.LD01_OPERACAO);

            /*" -2729- MOVE V0HCTB-PRMVG TO LD01-PRMVG. */
            _.Move(V0HCTB_PRMVG, ARQUIVOS_SAIDA.LD01.LD01_PRMVG);

            /*" -2731- MOVE V0HCTB-PRMAP TO LD01-PRMAP. */
            _.Move(V0HCTB_PRMAP, ARQUIVOS_SAIDA.LD01.LD01_PRMAP);

            /*" -2733- MOVE V0PRVG-ESTR-COBR TO LD01-ESTR-COBR. */
            _.Move(V0PRVG_ESTR_COBR, ARQUIVOS_SAIDA.LD01.LD01_ESTR_COBR);

            /*" -2735- MOVE V0PRVG-ORIG-PRODU TO LD01-ORIG-PRODU. */
            _.Move(V0PRVG_ORIG_PRODU, ARQUIVOS_SAIDA.LD01.LD01_ORIG_PRODU);

            /*" -2738- MOVE V0PROP-SITUACAO TO LD01-SIT-CERTIF */
            _.Move(V0PROP_SITUACAO, ARQUIVOS_SAIDA.LD01.LD01_SIT_CERTIF);

            /*" -2739- WRITE REG-VG0139B1 FROM LD01. */
            _.Move(ARQUIVOS_SAIDA.LD01.GetMoveValues(), REG_VG0139B1);

            VG0139B1.Write(REG_VG0139B1.GetMoveValues().ToString());

            /*" -2739- ADD 1 TO GV-ARQSAI1. */
            AREA_DE_WORK.GV_ARQSAI1.Value = AREA_DE_WORK.GV_ARQSAI1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-MOVE-DADOS-SECTION */
        private void R1020_00_MOVE_DADOS_SECTION()
        {
            /*" -2752- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2754- MOVE V0HCTB-NRCERTIF TO LD01-NRCERTIF. */
            _.Move(V0HCTB_NRCERTIF, ARQUIVOS_SAIDA.LD01.LD01_NRCERTIF);

            /*" -2756- MOVE V0HCTB-NRPARCEL TO LD01-NRPARCEL. */
            _.Move(V0HCTB_NRPARCEL, ARQUIVOS_SAIDA.LD01.LD01_NRPARCEL);

            /*" -2758- MOVE V0HCTB-NRTIT TO LD01-NRTIT. */
            _.Move(V0HCTB_NRTIT, ARQUIVOS_SAIDA.LD01.LD01_NRTIT);

            /*" -2760- MOVE V0HCTB-OCORHIST TO LD01-OCORHIST1. */
            _.Move(V0HCTB_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST1);

            /*" -2762- MOVE V0HCTB-NUM-APOLICE TO LD01-NUMAPOL. */
            _.Move(V0HCTB_NUM_APOLICE, ARQUIVOS_SAIDA.LD01.LD01_NUMAPOL);

            /*" -2764- MOVE V0HCTB-CODSUBES TO LD01-CODSUBES. */
            _.Move(V0HCTB_CODSUBES, ARQUIVOS_SAIDA.LD01.LD01_CODSUBES);

            /*" -2766- MOVE V0HCTB-FONTE TO LD01-FONTE. */
            _.Move(V0HCTB_FONTE, ARQUIVOS_SAIDA.LD01.LD01_FONTE);

            /*" -2768- MOVE V0PROP-CODPRODU TO LD01-CODPRODU. */
            _.Move(V0PROP_CODPRODU, ARQUIVOS_SAIDA.LD01.LD01_CODPRODU);

            /*" -2770- MOVE V0PROP-CODCLIEN TO LD01-CODCLIEN. */
            _.Move(V0PROP_CODCLIEN, ARQUIVOS_SAIDA.LD01.LD01_CODCLIEN);

            /*" -2772- MOVE V0HCTB-DTMOVTO TO LD01-DTMOVTO. */
            _.Move(V0HCTB_DTMOVTO, ARQUIVOS_SAIDA.LD01.LD01_DTMOVTO);

            /*" -2774- MOVE V0PROP-DTQITBCO TO LD01-DTQITBCO. */
            _.Move(V0PROP_DTQITBCO, ARQUIVOS_SAIDA.LD01.LD01_DTQITBCO);

            /*" -2776- MOVE V0PROP-DTPROXVEN TO LD01-DTPROXVEN. */
            _.Move(V0PROP_DTPROXVEN, ARQUIVOS_SAIDA.LD01.LD01_DTPROXVEN);

            /*" -2778- MOVE V0PROP-OCORHIST TO LD01-OCORHIST2. */
            _.Move(V0PROP_OCORHIST, ARQUIVOS_SAIDA.LD01.LD01_OCORHIST2);

            /*" -2780- MOVE V0HCTB-CODOPER TO LD01-OPERACAO. */
            _.Move(V0HCTB_CODOPER, ARQUIVOS_SAIDA.LD01.LD01_OPERACAO);

            /*" -2782- MOVE V0HCTB-PRMVG TO LD01-PRMVG. */
            _.Move(V0HCTB_PRMVG, ARQUIVOS_SAIDA.LD01.LD01_PRMVG);

            /*" -2784- MOVE V0HCTB-PRMAP TO LD01-PRMAP. */
            _.Move(V0HCTB_PRMAP, ARQUIVOS_SAIDA.LD01.LD01_PRMAP);

            /*" -2786- MOVE V0PRVG-ESTR-COBR TO LD01-ESTR-COBR. */
            _.Move(V0PRVG_ESTR_COBR, ARQUIVOS_SAIDA.LD01.LD01_ESTR_COBR);

            /*" -2787- MOVE V0PRVG-ORIG-PRODU TO LD01-ORIG-PRODU. */
            _.Move(V0PRVG_ORIG_PRODU, ARQUIVOS_SAIDA.LD01.LD01_ORIG_PRODU);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-AJUSTA-VIGENCIA-SECTION */
        private void R1030_00_AJUSTA_VIGENCIA_SECTION()
        {
            /*" -2800- MOVE '1030' TO WNR-EXEC-SQL. */
            _.Move("1030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2831- PERFORM R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1 */

            R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1();

            /*" -2835- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2836- MOVE 'N' TO WTEM-VIGENCIA */
                _.Move("N", WTEM_VIGENCIA);

                /*" -2838- GO TO R1030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2840- DISPLAY 'R1030-00-(PROBLEMAS AJUSTE VIGENCIA  ' */
                _.Display($"R1030-00-(PROBLEMAS AJUSTE VIGENCIA  ");

                /*" -2843- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2844- IF WHOST-DTINIVIG1 LESS WHOST-DTINIVIG2 */

            if (WHOST_DTINIVIG1 < WHOST_DTINIVIG2)
            {

                /*" -2845- MOVE WHOST-DTINIVIG2 TO V0ENDO-DTINIVIG */
                _.Move(WHOST_DTINIVIG2, V0ENDO_DTINIVIG);

                /*" -2846- MOVE WHOST-DTTERVIG2 TO V0ENDO-DTTERVIG */
                _.Move(WHOST_DTTERVIG2, V0ENDO_DTTERVIG);

                /*" -2847- ELSE */
            }
            else
            {


                /*" -2848- MOVE WHOST-DTINIVIG1 TO V0ENDO-DTINIVIG */
                _.Move(WHOST_DTINIVIG1, V0ENDO_DTINIVIG);

                /*" -2851- MOVE WHOST-DTTERVIG1 TO V0ENDO-DTTERVIG. */
                _.Move(WHOST_DTTERVIG1, V0ENDO_DTTERVIG);
            }


            /*" -2857- PERFORM R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2 */

            R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2();

            /*" -2860- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2861- DISPLAY 'R1030-10-(PROBLEMAS ACESSO V1SISTEMA ' */
                _.Display($"R1030-10-(PROBLEMAS ACESSO V1SISTEMA ");

                /*" -2864- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2864- MOVE 'S' TO WTEM-VIGENCIA. */
            _.Move("S", WTEM_VIGENCIA);

        }

        [StopWatch]
        /*" R1030-00-AJUSTA-VIGENCIA-DB-SELECT-1 */
        public void R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1()
        {
            /*" -2831- EXEC SQL SELECT D.DATA_INIVIGENCIA ,(D.DATA_INIVIGENCIA + C.PERI_PAGAMENTO MONTHS) , E.DATA_INIVIGENCIA ,(E.DATA_INIVIGENCIA + C.PERI_PAGAMENTO MONTHS) INTO :WHOST-DTINIVIG1 ,:WHOST-DTTERVIG1 ,:WHOST-DTINIVIG2 ,:WHOST-DTTERVIG2 FROM SEGUROS.HIST_CONT_PARCELVA A, SEGUROS.PARCELAS_VIDAZUL B, SEGUROS.OPCAO_PAG_VIDAZUL C, SEGUROS.HIS_COBER_PROPOST D, SEGUROS.ENDOSSOS E WHERE A.NUM_CERTIFICADO = :V0HCTB-NRCERTIF AND A.DTFATUR IS NULL AND A.SIT_REGISTRO IN ( '0' , '3' ) AND A.DATA_MOVIMENTO <= :V1SIST-DTMOVABE AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.NUM_PARCELA = B.NUM_PARCELA AND B.NUM_CERTIFICADO = C.NUM_CERTIFICADO AND B.DATA_VENCIMENTO BETWEEN C.DATA_INIVIGENCIA AND C.DATA_TERVIGENCIA AND B.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND B.DATA_VENCIMENTO BETWEEN D.DATA_INIVIGENCIA AND D.DATA_TERVIGENCIA AND C.NUM_CERTIFICADO = D.NUM_CERTIFICADO AND E.NUM_APOLICE = A.NUM_APOLICE AND E.NUM_ENDOSSO = 0 FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1 = new R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
            };

            var executed_1 = R1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1.Execute(r1030_00_AJUSTA_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG1, WHOST_DTINIVIG1);
                _.Move(executed_1.WHOST_DTTERVIG1, WHOST_DTTERVIG1);
                _.Move(executed_1.WHOST_DTINIVIG2, WHOST_DTINIVIG2);
                _.Move(executed_1.WHOST_DTTERVIG2, WHOST_DTTERVIG2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_99_SAIDA*/

        [StopWatch]
        /*" R1030-00-AJUSTA-VIGENCIA-DB-SELECT-2 */
        public void R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2()
        {
            /*" -2857- EXEC SQL SELECT DATE(:V0ENDO-DTTERVIG) - 1 DAY INTO :V0ENDO-DTTERVIG FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' WITH UR END-EXEC. */

            var r1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1 = new R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1()
            {
                V0ENDO_DTTERVIG = V0ENDO_DTTERVIG.ToString(),
            };

            var executed_1 = R1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1.Execute(r1030_00_AJUSTA_VIGENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTTERVIG, V0ENDO_DTTERVIG);
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-SECTION */
        private void R1050_00_ESTORNA_CONTABIL_SECTION()
        {
            /*" -2877- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2890- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1();

            /*" -2894- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2896- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2898- SUBTRACT 1 FROM V0ENDO-NRENDOS. */
            V0ENDO_NRENDOS.Value = V0ENDO_NRENDOS - 1;

            /*" -2900- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2905- PERFORM R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2 */

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2();

            /*" -2908- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2908- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-1 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1()
        {
            /*" -2890- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '3' , NRENDOS = 0 , DTFATUR = NULL WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND CODSUBES = :V0ENDO-CODSUBES AND FONTE = :V0ENDO-FONTE AND NRENDOS = :V0ENDO-NRENDOS AND DTFATUR = :V1SIST-DTMOVABE AND NRPARCEL = :WHOST-NRPARCEL AND CODOPER �= 1000 END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_CODSUBES = V0ENDO_CODSUBES.ToString(),
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                WHOST_NRPARCEL = WHOST_NRPARCEL.ToString(),
                V0ENDO_FONTE = V0ENDO_FONTE.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-ESTORNA-CONTABIL-DB-UPDATE-2 */
        public void R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2()
        {
            /*" -2905- EXEC SQL UPDATE SEGUROS.V0NUMERO_AES SET ENDOSCOB = :V0ENDO-NRENDOS WHERE COD_ORGAO = :V0APOL-ORGAO AND COD_RAMO = :V0APOL-RAMO END-EXEC. */

            var r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1 = new R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0APOL_ORGAO = V0APOL_ORGAO.ToString(),
                V0APOL_RAMO = V0APOL_RAMO.ToString(),
            };

            R1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1.Execute(r1050_00_ESTORNA_CONTABIL_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1060-00-DIFERE-COBERTURA-SECTION */
        private void R1060_00_DIFERE_COBERTURA_SECTION()
        {
            /*" -2919- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2920- IF V0ENDO-TIPO-ENDO EQUAL '1' */

            if (V0ENDO_TIPO_ENDO == "1")
            {

                /*" -2921- MOVE 99 TO WS-IND1 */
                _.Move(99, AREA_DE_WORK.WS_IND1);

                /*" -2923- PERFORM UNTIL WS-IND1 EQUAL ZEROS OR TB-RAMO-VALOR-PRM(WS-IND1) GREATER ZEROS */

                while (!(AREA_DE_WORK.WS_IND1 == 00 || TABELA_RAMO.FILLER_0[AREA_DE_WORK.WS_IND1].TB_RAMO_VALOR_PRM > 00))
                {

                    /*" -2924- SUBTRACT 1 FROM WS-IND1 */
                    AREA_DE_WORK.WS_IND1.Value = AREA_DE_WORK.WS_IND1 - 1;

                    /*" -2925- END-PERFORM */
                }

                /*" -2929- MOVE ZEROS TO WS-IND WS-ACUM-IND WS-ACUM-PRM WS-ACUM-IOF */
                _.Move(0, AREA_DE_WORK.WS_IND, AREA_DE_WORK.WS_ACUM_IND, AREA_DE_WORK.WS_ACUM_PRM, AREA_DE_WORK.WS_ACUM_IOF);

                /*" -2930- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -2931- MOVE 'NAO' TO WTEM-RAMO-COMP */
                _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_COMP);

                /*" -2932- PERFORM UNTIL WS-IND GREATER 99 */

                while (!(AREA_DE_WORK.WS_IND > 99))
                {

                    /*" -2933- ADD 1 TO WS-IND */
                    AREA_DE_WORK.WS_IND.Value = AREA_DE_WORK.WS_IND + 1;

                    /*" -2934- IF TB-RAMO-VALOR-PRM(WS-IND) GREATER ZEROS */

                    if (TABELA_RAMO.FILLER_0[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM > 00)
                    {

                        /*" -2935- MOVE 'SIM' TO WTEM-RAMO-COMP */
                        _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_COMP);

                        /*" -2936- MOVE WS-IND TO V0COBA-RAMOFR */
                        _.Move(AREA_DE_WORK.WS_IND, V0COBA_RAMOFR);

                        /*" -2939- MOVE TB-RAMO-VALOR-PRM(WS-IND) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(TABELA_RAMO.FILLER_0[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -2941- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -2943- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF * V0COBA-PCT-COBERT / 100 */
                        AREA_DE_WORK.WS_IOF_RAMO.Value = V0PARC_OTNIOF * V0COBA_PCT_COBERT / 100f;

                        /*" -2944- IF WS-IND EQUAL WS-IND1 */

                        if (AREA_DE_WORK.WS_IND == AREA_DE_WORK.WS_IND1)
                        {

                            /*" -2946- COMPUTE V0COBA-PCT-COBERT = 100 - WS-ACUM-IND */
                            V0COBA_PCT_COBERT.Value = 100 - AREA_DE_WORK.WS_ACUM_IND;

                            /*" -2948- COMPUTE V0COBA-PRM-TAR-IX = V0PARC-OTNTOTAL - WS-ACUM-PRM */
                            V0COBA_PRM_TAR_IX.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_ACUM_PRM;

                            /*" -2950- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF - WS-ACUM-IOF */
                            AREA_DE_WORK.WS_IOF_RAMO.Value = V0PARC_OTNIOF - AREA_DE_WORK.WS_ACUM_IOF;

                            /*" -2952- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                            V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.WS_IOF_RAMO;

                            /*" -2954- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                            _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                            /*" -2955- ELSE */
                        }
                        else
                        {


                            /*" -2956- ADD V0COBA-PCT-COBERT TO WS-ACUM-IND */
                            AREA_DE_WORK.WS_ACUM_IND.Value = AREA_DE_WORK.WS_ACUM_IND + V0COBA_PCT_COBERT;

                            /*" -2957- ADD V0COBA-PRM-TAR-IX TO WS-ACUM-PRM */
                            AREA_DE_WORK.WS_ACUM_PRM.Value = AREA_DE_WORK.WS_ACUM_PRM + V0COBA_PRM_TAR_IX;

                            /*" -2958- ADD WS-IOF-RAMO TO WS-ACUM-IOF */
                            AREA_DE_WORK.WS_ACUM_IOF.Value = AREA_DE_WORK.WS_ACUM_IOF + AREA_DE_WORK.WS_IOF_RAMO;

                            /*" -2960- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                            V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.WS_IOF_RAMO;

                            /*" -2962- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                            _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                            /*" -2964- END-IF */
                        }


                        /*" -2965- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -2966- IF WS-IND EQUAL 93 */

                        if (AREA_DE_WORK.WS_IND == 93)
                        {

                            /*" -2967- MOVE 11 TO V0COBA-COD-COBER */
                            _.Move(11, V0COBA_COD_COBER);

                            /*" -2968- PERFORM R1600-00-INSERT-V0COBERAPOL */

                            R1600_00_INSERT_V0COBERAPOL_SECTION();

                            /*" -2969- END-IF */
                        }


                        /*" -2970- END-IF */
                    }


                    /*" -2971- END-PERFORM */
                }

                /*" -2972- ELSE */
            }
            else
            {


                /*" -2973- MOVE 99 TO WS-IND1 */
                _.Move(99, AREA_DE_WORK.WS_IND1);

                /*" -2975- PERFORM UNTIL WS-IND1 EQUAL ZEROS OR TB-RAMO-VALOR-PRM-R (WS-IND1) GREATER ZEROS */

                while (!(AREA_DE_WORK.WS_IND1 == 00 || TABELA_RAMO_R.FILLER_1[AREA_DE_WORK.WS_IND1].TB_RAMO_VALOR_PRM_R > 00))
                {

                    /*" -2976- SUBTRACT 1 FROM WS-IND1 */
                    AREA_DE_WORK.WS_IND1.Value = AREA_DE_WORK.WS_IND1 - 1;

                    /*" -2977- END-PERFORM */
                }

                /*" -2981- MOVE ZEROS TO WS-IND WS-ACUM-IND WS-ACUM-PRM WS-ACUM-IOF */
                _.Move(0, AREA_DE_WORK.WS_IND, AREA_DE_WORK.WS_ACUM_IND, AREA_DE_WORK.WS_ACUM_PRM, AREA_DE_WORK.WS_ACUM_IOF);

                /*" -2982- MOVE 'NAO' TO WTEM-RAMO-COMP */
                _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_COMP);

                /*" -2983- PERFORM UNTIL WS-IND GREATER 99 */

                while (!(AREA_DE_WORK.WS_IND > 99))
                {

                    /*" -2984- ADD 1 TO WS-IND */
                    AREA_DE_WORK.WS_IND.Value = AREA_DE_WORK.WS_IND + 1;

                    /*" -2985- IF TB-RAMO-VALOR-PRM-R (WS-IND) GREATER ZEROS */

                    if (TABELA_RAMO_R.FILLER_1[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM_R > 00)
                    {

                        /*" -2986- MOVE 'SIM' TO WTEM-RAMO-COMP */
                        _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_COMP);

                        /*" -2987- MOVE WS-IND TO V0COBA-RAMOFR */
                        _.Move(AREA_DE_WORK.WS_IND, V0COBA_RAMOFR);

                        /*" -2990- MOVE TB-RAMO-VALOR-PRM-R (WS-IND) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(TABELA_RAMO_R.FILLER_1[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM_R, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -2992- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -2994- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF * V0COBA-PCT-COBERT / 100 */
                        AREA_DE_WORK.WS_IOF_RAMO.Value = V0PARC_OTNIOF * V0COBA_PCT_COBERT / 100f;

                        /*" -2995- IF WS-IND EQUAL WS-IND1 */

                        if (AREA_DE_WORK.WS_IND == AREA_DE_WORK.WS_IND1)
                        {

                            /*" -2997- COMPUTE V0COBA-PCT-COBERT = 100 - WS-ACUM-IND */
                            V0COBA_PCT_COBERT.Value = 100 - AREA_DE_WORK.WS_ACUM_IND;

                            /*" -2999- COMPUTE V0COBA-PRM-TAR-IX = V0PARC-OTNTOTAL - WS-ACUM-PRM */
                            V0COBA_PRM_TAR_IX.Value = V0PARC_OTNTOTAL - AREA_DE_WORK.WS_ACUM_PRM;

                            /*" -3001- COMPUTE WS-IOF-RAMO = V0PARC-OTNIOF - WS-ACUM-IOF */
                            AREA_DE_WORK.WS_IOF_RAMO.Value = V0PARC_OTNIOF - AREA_DE_WORK.WS_ACUM_IOF;

                            /*" -3003- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                            V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.WS_IOF_RAMO;

                            /*" -3005- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                            _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                            /*" -3006- ELSE */
                        }
                        else
                        {


                            /*" -3007- ADD V0COBA-PCT-COBERT TO WS-ACUM-IND */
                            AREA_DE_WORK.WS_ACUM_IND.Value = AREA_DE_WORK.WS_ACUM_IND + V0COBA_PCT_COBERT;

                            /*" -3008- ADD V0COBA-PRM-TAR-IX TO WS-ACUM-PRM */
                            AREA_DE_WORK.WS_ACUM_PRM.Value = AREA_DE_WORK.WS_ACUM_PRM + V0COBA_PRM_TAR_IX;

                            /*" -3009- ADD WS-IOF-RAMO TO WS-ACUM-IOF */
                            AREA_DE_WORK.WS_ACUM_IOF.Value = AREA_DE_WORK.WS_ACUM_IOF + AREA_DE_WORK.WS_IOF_RAMO;

                            /*" -3011- COMPUTE V0COBA-PRM-TAR-IX = V0COBA-PRM-TAR-IX - WS-IOF-RAMO */
                            V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.WS_IOF_RAMO;

                            /*" -3013- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                            _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                            /*" -3015- END-IF */
                        }


                        /*" -3016- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -3017- IF WS-IND EQUAL 93 */

                        if (AREA_DE_WORK.WS_IND == 93)
                        {

                            /*" -3018- MOVE 11 TO V0COBA-COD-COBER */
                            _.Move(11, V0COBA_COD_COBER);

                            /*" -3019- PERFORM R1600-00-INSERT-V0COBERAPOL */

                            R1600_00_INSERT_V0COBERAPOL_SECTION();

                            /*" -3020- END-IF */
                        }


                        /*" -3021- END-IF */
                    }


                    /*" -3022- END-PERFORM */
                }

                /*" -3023- END-IF */
            }


            /*" -3024- IF WTEM-RAMO-COMP EQUAL 'NAO' */

            if (AREA_DE_WORK.WTEM_RAMO_COMP == "NAO")
            {

                /*" -3027- IF V0APOL-RAMO EQUAL 97 AND V0COBA-RAMOFR EQUAL 82 NEXT SENTENCE */

                if (V0APOL_RAMO == 97 && V0COBA_RAMOFR == 82)
                {

                    /*" -3028- ELSE */
                }
                else
                {


                    /*" -3030- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -3031- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -3032- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -3033- MOVE 11 TO V0COBA-COD-COBER */
                    _.Move(11, V0COBA_COD_COBER);

                    /*" -3034- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -3035- END-IF */
                }


                /*" -3035- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: C1060_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-SECTION */
        private void R1100_00_ACUMULA_PREMIO_SECTION()
        {
            /*" -3046- MOVE 'S' TO WTEM-CONVERSAO. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSAO);

            /*" -3049- MOVE '110A' TO WNR-EXEC-SQL. */
            _.Move("110A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3051- MOVE V0PARC-DTVENCTO TO WS-DTBASE. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WS_DTBASE);

            /*" -3052- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -3055- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -3058- COMPUTE WS-PREMIO-LIQ ROUNDED = (V0HCTB-PRMVG + V0HCTB-PRMAP) / WS-IND-IOF */
            AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP) / AREA_DE_WORK.WS_IND_IOF;

            /*" -3062- COMPUTE WS-VLIOCC = V0HCTB-PRMVG + V0HCTB-PRMAP - WS-PREMIO-LIQ */
            AREA_DE_WORK.WS_VLIOCC.Value = V0HCTB_PRMVG + V0HCTB_PRMAP - AREA_DE_WORK.WS_PREMIO_LIQ;

            /*" -3064- COMPUTE WS-PRM-LIQ-AP ROUNDED = V0HCTB-PRMAP / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP / AREA_DE_WORK.WS_IND_IOF;

            /*" -3066- COMPUTE WS-VLIOCC-AP = V0HCTB-PRMAP - WS-PRM-LIQ-AP */
            AREA_DE_WORK.WS_VLIOCC_AP.Value = V0HCTB_PRMAP - AREA_DE_WORK.WS_PRM_LIQ_AP;

            /*" -3068- COMPUTE WS-PRM-LIQ-VG ROUNDED = V0HCTB-PRMVG / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG / AREA_DE_WORK.WS_IND_IOF;

            /*" -3071- COMPUTE WS-VLIOCC-VG = V0HCTB-PRMVG - WS-PRM-LIQ-VG. */
            AREA_DE_WORK.WS_VLIOCC_VG.Value = V0HCTB_PRMVG - AREA_DE_WORK.WS_PRM_LIQ_VG;

            /*" -3072- IF V0SUBG-IND-IOF = 'N' */

            if (V0SUBG_IND_IOF == "N")
            {

                /*" -3075- MOVE ZEROS TO WS-VLIOCC WS-VLIOCC-VG WS-VLIOCC-AP */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC, AREA_DE_WORK.WS_VLIOCC_VG, AREA_DE_WORK.WS_VLIOCC_AP);

                /*" -3077- COMPUTE WS-PREMIO-LIQ = (V0HCTB-PRMVG + V0HCTB-PRMAP) */
                AREA_DE_WORK.WS_PREMIO_LIQ.Value = (V0HCTB_PRMVG + V0HCTB_PRMAP);

                /*" -3078- COMPUTE WS-PRM-LIQ-VG = V0HCTB-PRMVG */
                AREA_DE_WORK.WS_PRM_LIQ_VG.Value = V0HCTB_PRMVG;

                /*" -3081- COMPUTE WS-PRM-LIQ-AP = V0HCTB-PRMAP. */
                AREA_DE_WORK.WS_PRM_LIQ_AP.Value = V0HCTB_PRMAP;
            }


            /*" -3084- MOVE 0 TO WS-PRMRTO WS-VLIOCC-RTO. */
            _.Move(0, AREA_DE_WORK.WS_PRMRTO, AREA_DE_WORK.WS_VLIOCC_RTO);

            /*" -3086- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -3087- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT + WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT + AREA_DE_WORK.WS_VLIOCC;

                /*" -3088- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP + WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP + AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -3089- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG + WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG + AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -3091- COMPUTE WS-VLIOCC-TOT-RTO = WS-VLIOCC-TOT-RTO + WS-VLIOCC-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_RTO.Value = AREA_DE_WORK.WS_VLIOCC_TOT_RTO + AREA_DE_WORK.WS_VLIOCC_RTO;

                /*" -3092- COMPUTE AC-PRMVG = AC-PRMVG + V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG + V0HCTB_PRMVG;

                /*" -3093- COMPUTE AC-PRMAP = AC-PRMAP + V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP + V0HCTB_PRMAP;

                /*" -3094- COMPUTE AC-PRMRTO = AC-PRMRTO + WS-PRMRTO */
                AREA_DE_WORK.AC_PRMRTO.Value = AREA_DE_WORK.AC_PRMRTO + AREA_DE_WORK.WS_PRMRTO;

                /*" -3095- IF WTEM-RAMO-CONJ EQUAL 'SIM' */

                if (AREA_DE_WORK.WTEM_RAMO_CONJ == "SIM")
                {

                    /*" -3096- PERFORM R1130-00-ACUMULA-CONJ */

                    R1130_00_ACUMULA_CONJ_SECTION();

                    /*" -3097- END-IF */
                }


                /*" -3098- COMPUTE AC-IMPCDG = AC-IMPCDG + V0CBPR-IMPCDG */
                AREA_DE_WORK.AC_IMPCDG.Value = AREA_DE_WORK.AC_IMPCDG + V0CBPR_IMPCDG;

                /*" -3099- COMPUTE AC-IMPAA = AC-IMPAA + V0CBPR-IMPAA */
                AREA_DE_WORK.AC_IMPAA.Value = AREA_DE_WORK.AC_IMPAA + V0CBPR_IMPAA;

                /*" -3100- COMPUTE AC-IMPAAF = AC-IMPAAF + V0CBPR-IMPAAF */
                AREA_DE_WORK.AC_IMPAAF.Value = AREA_DE_WORK.AC_IMPAAF + V0CBPR_IMPAAF;

                /*" -3101- COMPUTE AC-IMPADE = AC-IMPADE + V0CBPR-IMPADE */
                AREA_DE_WORK.AC_IMPADE.Value = AREA_DE_WORK.AC_IMPADE + V0CBPR_IMPADE;

                /*" -3102- ELSE */
            }
            else
            {


                /*" -3103- COMPUTE WS-VLIOCC-TOT = WS-VLIOCC-TOT - WS-VLIOCC */
                AREA_DE_WORK.WS_VLIOCC_TOT.Value = AREA_DE_WORK.WS_VLIOCC_TOT - AREA_DE_WORK.WS_VLIOCC;

                /*" -3104- COMPUTE WS-VLIOCC-TOT-AP = WS-VLIOCC-TOT-AP - WS-VLIOCC-AP */
                AREA_DE_WORK.WS_VLIOCC_TOT_AP.Value = AREA_DE_WORK.WS_VLIOCC_TOT_AP - AREA_DE_WORK.WS_VLIOCC_AP;

                /*" -3105- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-VG */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_VG;

                /*" -3107- COMPUTE WS-VLIOCC-TOT-RTO = WS-VLIOCC-TOT-RTO - WS-VLIOCC-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_RTO.Value = AREA_DE_WORK.WS_VLIOCC_TOT_RTO - AREA_DE_WORK.WS_VLIOCC_RTO;

                /*" -3108- COMPUTE AC-PRMVG = AC-PRMVG - V0HCTB-PRMVG */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - V0HCTB_PRMVG;

                /*" -3109- COMPUTE AC-PRMAP = AC-PRMAP - V0HCTB-PRMAP */
                AREA_DE_WORK.AC_PRMAP.Value = AREA_DE_WORK.AC_PRMAP - V0HCTB_PRMAP;

                /*" -3110- COMPUTE AC-PRMRTO = AC-PRMRTO - WS-PRMRTO */
                AREA_DE_WORK.AC_PRMRTO.Value = AREA_DE_WORK.AC_PRMRTO - AREA_DE_WORK.WS_PRMRTO;

                /*" -3111- IF WTEM-RAMO-CONJ EQUAL 'SIM' */

                if (AREA_DE_WORK.WTEM_RAMO_CONJ == "SIM")
                {

                    /*" -3112- PERFORM R1130-00-ACUMULA-CONJ */

                    R1130_00_ACUMULA_CONJ_SECTION();

                    /*" -3113- END-IF */
                }


                /*" -3115- END-IF. */
            }


            /*" -3117- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3127- PERFORM R1100_00_ACUMULA_PREMIO_DB_UPDATE_1 */

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1();

            /*" -3130- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3132- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3134- ADD +1 TO AC-U-V0HISTCONTABILVA. */
            AREA_DE_WORK.AC_U_V0HISTCONTABILVA.Value = AREA_DE_WORK.AC_U_V0HISTCONTABILVA + +1;

            /*" -3136- IF V0HCTB-SITUACAO EQUAL '0' AND V0HCTB-NRPARCEL EQUAL 1 */

            if (V0HCTB_SITUACAO == "0" && V0HCTB_NRPARCEL == 1)
            {

                /*" -3136- PERFORM R1110-00-VERIFICA-RCAP. */

                R1110_00_VERIFICA_RCAP_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1100_00_NEXT */

            R1100_00_NEXT();

        }

        [StopWatch]
        /*" R1100-00-ACUMULA-PREMIO-DB-UPDATE-1 */
        public void R1100_00_ACUMULA_PREMIO_DB_UPDATE_1()
        {
            /*" -3127- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '1' , NRENDOS = :V0ENDO-NRENDOS, DTFATUR = :V1SIST-DTMOVABE, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTB-NRCERTIF AND NRPARCEL = :V0HCTB-NRPARCEL AND NRTIT = :V0HCTB-NRTIT AND OCOORHIST = :V0HCTB-OCORHIST END-EXEC. */

            var r1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1 = new R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1()
            {
                V1SIST_DTMOVABE = V1SIST_DTMOVABE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
                V0HCTB_NRPARCEL = V0HCTB_NRPARCEL.ToString(),
                V0HCTB_OCORHIST = V0HCTB_OCORHIST.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            R1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1.Execute(r1100_00_ACUMULA_PREMIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1100-00-NEXT */
        private void R1100_00_NEXT(bool isPerform = false)
        {
            /*" -3140- PERFORM R0620-00-LEITURA-SVG0139B. */

            R0620_00_LEITURA_SVG0139B_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-SECTION */
        private void R1102_00_SELECT_RCAP_SECTION()
        {
            /*" -3151- MOVE '1102' TO WNR-EXEC-SQL. */
            _.Move("1102", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3152- MOVE 'S' TO WTEM-V0RCAP. */
            _.Move("S", AREA_DE_WORK.WTEM_V0RCAP);

            /*" -3155- MOVE V0HCTB-NRTIT TO V0RCAP-NRTIT. */
            _.Move(V0HCTB_NRTIT, V0RCAP_NRTIT);

            /*" -3157- MOVE '11A3' TO WNR-EXEC-SQL. */
            _.Move("11A3", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3166- PERFORM R1102_00_SELECT_RCAP_DB_SELECT_1 */

            R1102_00_SELECT_RCAP_DB_SELECT_1();

            /*" -3169- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3170- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3172- DISPLAY 'TITULO / AVISO ' V0RCAP-NRTIT ' ' V1RCAC-AGEAVISO ' ' V1RCAC-NRAVISO */

                    $"TITULO / AVISO {V0RCAP_NRTIT} {V1RCAC_AGEAVISO} {V1RCAC_NRAVISO}"
                    .Display();

                    /*" -3173- DISPLAY 'AVISO NOT FOUND - 100 ' */
                    _.Display($"AVISO NOT FOUND - 100 ");

                    /*" -3174- DISPLAY 'PULADO - NAO PROCESSADO          ' */
                    _.Display($"PULADO - NAO PROCESSADO          ");

                    /*" -3175- MOVE 'N' TO WTEM-V0RCAP */
                    _.Move("N", AREA_DE_WORK.WTEM_V0RCAP);

                    /*" -3176- GO TO R1102-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/ //GOTO
                    return;

                    /*" -3177- ELSE */
                }
                else
                {


                    /*" -3179- DISPLAY 'TITULO / AVISO ' V0RCAP-NRTIT ' ' V1RCAC-AGEAVISO ' ' V1RCAC-NRAVISO */

                    $"TITULO / AVISO {V0RCAP_NRTIT} {V1RCAC_AGEAVISO} {V1RCAC_NRAVISO}"
                    .Display();

                    /*" -3180- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3181- END-IF */
                }


                /*" -3181- END-IF. */
            }


        }

        [StopWatch]
        /*" R1102-00-SELECT-RCAP-DB-SELECT-1 */
        public void R1102_00_SELECT_RCAP_DB_SELECT_1()
        {
            /*" -3166- EXEC SQL SELECT AGEAVISO , NRAVISO INTO :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO FROM SEGUROS.V0HISTCOBVA WHERE NRTIT = :V0RCAP-NRTIT WITH UR END-EXEC. */

            var r1102_00_SELECT_RCAP_DB_SELECT_1_Query1 = new R1102_00_SELECT_RCAP_DB_SELECT_1_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1102_00_SELECT_RCAP_DB_SELECT_1_Query1.Execute(r1102_00_SELECT_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1102_99_SAIDA*/

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-SECTION */
        private void R1105_00_ACESSA_V1RAMOIND_SECTION()
        {
            /*" -3192- MOVE 'R1105' TO WNR-EXEC-SQL. */
            _.Move("R1105", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3193- MOVE V0APOL-RAMO TO V1RIND-RAMO */
            _.Move(V0APOL_RAMO, V1RIND_RAMO);

            /*" -3195- MOVE WS-DTBASE TO V1RIND-DTINIVIG */
            _.Move(AREA_DE_WORK.WS_DTBASE, V1RIND_DTINIVIG);

            /*" -3203- PERFORM R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1 */

            R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1();

            /*" -3206- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -3207- DISPLAY 'PROBLEMA NO ACESSAO V1RAMOIND' */
                _.Display($"PROBLEMA NO ACESSAO V1RAMOIND");

                /*" -3207- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1105-00-ACESSA-V1RAMOIND-DB-SELECT-1 */
        public void R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1()
        {
            /*" -3203- EXEC SQL SELECT PCIOF INTO :V1RIND-PCIOF FROM SEGUROS.V1RAMOIND WHERE RAMO = :V1RIND-RAMO AND DTINIVIG <= :V1RIND-DTINIVIG AND DTTERVIG >= :V1RIND-DTINIVIG WITH UR END-EXEC. */

            var r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1 = new R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1()
            {
                V1RIND_DTINIVIG = V1RIND_DTINIVIG.ToString(),
                V1RIND_RAMO = V1RIND_RAMO.ToString(),
            };

            var executed_1 = R1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1.Execute(r1105_00_ACESSA_V1RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RIND_PCIOF, V1RIND_PCIOF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1105_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-SECTION */
        private void R1110_00_VERIFICA_RCAP_SECTION()
        {
            /*" -3218- MOVE SPACES TO WFIM-V1RCAP. */
            _.Move("", AREA_DE_WORK.WFIM_V1RCAP);

            /*" -3219- MOVE 'S' TO WTEM-CONVERSAO. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSAO);

            /*" -3221- MOVE '110A' TO WNR-EXEC-SQL. */
            _.Move("110A", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3227- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_1 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_1();

            /*" -3230- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3231- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3232- MOVE 'N' TO WTEM-CONVERSAO */
                    _.Move("N", AREA_DE_WORK.WTEM_CONVERSAO);

                    /*" -3233- ELSE */
                }
                else
                {


                    /*" -3235- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3236- IF V0PRVG-ESTR-COBR EQUAL 'MULT' */

            if (V0PRVG_ESTR_COBR == "MULT")
            {

                /*" -3237- IF WTEM-CONVERSAO EQUAL 'S' */

                if (AREA_DE_WORK.WTEM_CONVERSAO == "S")
                {

                    /*" -3238- MOVE NUM-SICOB TO V0RCAP-NRTIT */
                    _.Move(NUM_SICOB, V0RCAP_NRTIT);

                    /*" -3239- ELSE */
                }
                else
                {


                    /*" -3240- MOVE V0HCTB-NRCERTIF TO V0RCAP-NRTIT */
                    _.Move(V0HCTB_NRCERTIF, V0RCAP_NRTIT);

                    /*" -3241- END-IF */
                }


                /*" -3242- ELSE */
            }
            else
            {


                /*" -3244- DISPLAY 'ESTRUTURA DE COBRANCA DESCONHECIDA ' V0PRVG-ESTR-COBR */
                _.Display($"ESTRUTURA DE COBRANCA DESCONHECIDA {V0PRVG_ESTR_COBR}");

                /*" -3246- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3248- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3260- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_2 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_2();

            /*" -3263- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3264- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3265- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -3266- ELSE */
                }
                else
                {


                    /*" -3268- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3269- IF V0RCAP-SITUACAO EQUAL '1' */

            if (V0RCAP_SITUACAO == "1")
            {

                /*" -3270- MOVE '1110' TO WNR-EXEC-SQL */
                _.Move("1110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -3276- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_1 */

                R1110_00_VERIFICA_RCAP_DB_UPDATE_1();

                /*" -3278- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3280- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3282- MOVE '1113' TO WNR-EXEC-SQL. */
            _.Move("1113", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3298- PERFORM R1110_00_VERIFICA_RCAP_DB_SELECT_3 */

            R1110_00_VERIFICA_RCAP_DB_SELECT_3();

            /*" -3301- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3303- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3305- PERFORM R1120-00-BAIXA-RCAP. */

            R1120_00_BAIXA_RCAP_SECTION();

            /*" -3307- MOVE '1115' TO WNR-EXEC-SQL. */
            _.Move("1115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3317- PERFORM R1110_00_VERIFICA_RCAP_DB_UPDATE_2 */

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2();

            /*" -3320- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3322- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3322- ADD 1 TO AC-U-V0RCAP. */
            AREA_DE_WORK.AC_U_V0RCAP.Value = AREA_DE_WORK.AC_U_V0RCAP + 1;

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-1 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_1()
        {
            /*" -3227- EXEC SQL SELECT NUM_SICOB INTO :NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0HCTB-NRCERTIF WITH UR END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1()
            {
                V0HCTB_NRCERTIF = V0HCTB_NRCERTIF.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_SICOB, NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-UPDATE-1 */
        public void R1110_00_VERIFICA_RCAP_DB_UPDATE_1()
        {
            /*" -3276- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRENDOS = :V0ENDO-NRENDOS, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-2 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_2()
        {
            /*" -3260- EXEC SQL SELECT FONTE, NRRCAP, SITUACAO INTO :V0RCAP-FONTE, :V0RCAP-NRRCAP, :V0RCAP-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :V0RCAP-NRTIT AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO IN ( '0' , '1' ) END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1()
            {
                V0RCAP_NRTIT = V0RCAP_NRTIT.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RCAP_FONTE, V0RCAP_FONTE);
                _.Move(executed_1.V0RCAP_NRRCAP, V0RCAP_NRRCAP);
                _.Move(executed_1.V0RCAP_SITUACAO, V0RCAP_SITUACAO);
            }


        }

        [StopWatch]
        /*" R1120-00-BAIXA-RCAP-SECTION */
        private void R1120_00_BAIXA_RCAP_SECTION()
        {
            /*" -3331- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R1120_10_DECLARE_V0RCAPCOMP */

            R1120_10_DECLARE_V0RCAPCOMP();

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-UPDATE-2 */
        public void R1110_00_VERIFICA_RCAP_DB_UPDATE_2()
        {
            /*" -3317- EXEC SQL UPDATE SEGUROS.V0RCAP SET SITUACAO = '1' , OPERACAO = 220 , NUM_APOLICE = :V0ENDO-NUM-APOLICE, NRENDOS = :V0ENDO-NRENDOS, NRPARCEL = 0, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1 = new R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1()
            {
                V0ENDO_NUM_APOLICE = V0ENDO_NUM_APOLICE.ToString(),
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            R1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1.Execute(r1110_00_VERIFICA_RCAP_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1110-00-VERIFICA-RCAP-DB-SELECT-3 */
        public void R1110_00_VERIFICA_RCAP_DB_SELECT_3()
        {
            /*" -3298- EXEC SQL SELECT BCOAVISO , AGEAVISO , NRAVISO , DATARCAP INTO :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-DATARCAP FROM SEGUROS.V1RCAPCOMP WHERE FONTE = :V0RCAP-FONTE AND NRRCAP = :V0RCAP-NRRCAP AND NRRCAPCO = 0 AND OPERACAO >= 100 AND OPERACAO <= 199 AND SITUACAO = '0' END-EXEC. */

            var r1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1 = new R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1()
            {
                V0RCAP_NRRCAP = V0RCAP_NRRCAP.ToString(),
                V0RCAP_FONTE = V0RCAP_FONTE.ToString(),
            };

            var executed_1 = R1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1.Execute(r1110_00_VERIFICA_RCAP_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RCAC_BCOAVISO, V1RCAC_BCOAVISO);
                _.Move(executed_1.V1RCAC_AGEAVISO, V1RCAC_AGEAVISO);
                _.Move(executed_1.V1RCAC_NRAVISO, V1RCAC_NRAVISO);
                _.Move(executed_1.V1RCAC_DATARCAP, V1RCAC_DATARCAP);
            }


        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP */
        private void R1120_10_DECLARE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3356- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_DECLARE_1();

            /*" -3358- PERFORM R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1 */

            R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1();

            /*" -3361- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3361- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-10-DECLARE-V0RCAPCOMP-DB-OPEN-1 */
        public void R1120_10_DECLARE_V0RCAPCOMP_DB_OPEN_1()
        {
            /*" -3358- EXEC SQL OPEN V1RCAPCOMP END-EXEC. */

            V1RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R1130-10-DECLARE-VGHISTCONT-DB-DECLARE-1 */
        public void R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1()
        {
            /*" -3496- EXEC SQL DECLARE CVGHISTCONT CURSOR FOR SELECT NUM_CERTIFICADO , NUM_PARCELA , NUM_TITULO , OCORR_HISTORICO , COD_GRUPO_SUSEP , RAMO_EMISSOR , COD_MODALIDADE , COD_COBERTURA , VLR_PREMIO_RAMO , COD_USUARIO , DTH_ATUALIZACAO FROM SEGUROS.VG_HIST_CONT_COBER WHERE NUM_CERTIFICADO = :V0HCTB-NRCERTIF AND NUM_PARCELA = :V0HCTB-NRPARCEL AND NUM_TITULO = :V0HCTB-NRTIT AND OCORR_HISTORICO = :V0HCTB-OCORHIST END-EXEC. */
            CVGHISTCONT = new VG0139B_CVGHISTCONT(true);
            string GetQuery_CVGHISTCONT()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							NUM_PARCELA
							, 
							NUM_TITULO
							, 
							OCORR_HISTORICO
							, 
							COD_GRUPO_SUSEP
							, 
							RAMO_EMISSOR
							, 
							COD_MODALIDADE
							, 
							COD_COBERTURA
							, 
							VLR_PREMIO_RAMO
							, 
							COD_USUARIO
							, 
							DTH_ATUALIZACAO 
							FROM SEGUROS.VG_HIST_CONT_COBER 
							WHERE NUM_CERTIFICADO = '{V0HCTB_NRCERTIF}' 
							AND NUM_PARCELA = '{V0HCTB_NRPARCEL}' 
							AND NUM_TITULO = '{V0HCTB_NRTIT}' 
							AND OCORR_HISTORICO = '{V0HCTB_OCORHIST}'";

                return query;
            }
            CVGHISTCONT.GetQueryEvent += GetQuery_CVGHISTCONT;

        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP */
        private void R1120_20_FETCH_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3368- MOVE '1121' TO WNR-EXEC-SQL. */
            _.Move("1121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3383- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1 */

            R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1();

            /*" -3386- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3387- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3387- PERFORM R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1 */

                    R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1();

                    /*" -3389- GO TO R1120-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/ //GOTO
                    return;

                    /*" -3390- ELSE */
                }
                else
                {


                    /*" -3390- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-FETCH-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_FETCH_1()
        {
            /*" -3383- EXEC SQL FETCH V1RCAPCOMP INTO :V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1RCAC-DTMOVTO , :V1RCAC-HORAOPER , :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB END-EXEC. */

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
        /*" R1120-20-FETCH-V0RCAPCOMP-DB-CLOSE-1 */
        public void R1120_20_FETCH_V0RCAPCOMP_DB_CLOSE_1()
        {
            /*" -3387- EXEC SQL CLOSE V1RCAPCOMP END-EXEC */

            V1RCAPCOMP.Close();

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP */
        private void R1120_30_UPDATE_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3396- MOVE '1122' TO WNR-EXEC-SQL. */
            _.Move("1122", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3406- PERFORM R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1 */

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1();

            /*" -3409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3411- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3411- ADD +1 TO AC-U-V0RCAPCOMP. */
            AREA_DE_WORK.AC_U_V0RCAPCOMP.Value = AREA_DE_WORK.AC_U_V0RCAPCOMP + +1;

        }

        [StopWatch]
        /*" R1120-30-UPDATE-V0RCAPCOMP-DB-UPDATE-1 */
        public void R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1()
        {
            /*" -3406- EXEC SQL UPDATE SEGUROS.V0RCAPCOMP SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :V1RCAC-FONTE AND NRRCAP = :V1RCAC-NRRCAP AND NRRCAPCO = :V1RCAC-NRRCAPCO AND OPERACAO = :V1RCAC-OPERACAO AND DTMOVTO = :V1RCAC-DTMOVTO AND HORAOPER = :V1RCAC-HORAOPER END-EXEC. */

            var r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1 = new R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1()
            {
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1RCAC_HORAOPER = V1RCAC_HORAOPER.ToString(),
                V1RCAC_DTMOVTO = V1RCAC_DTMOVTO.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
            };

            R1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1.Execute(r1120_30_UPDATE_V0RCAPCOMP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP */
        private void R1120_40_INSERT_V0RCAPCOMP(bool isPerform = false)
        {
            /*" -3417- MOVE '1123' TO WNR-EXEC-SQL. */
            _.Move("1123", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3418- MOVE '0' TO V1RCAC-SITCONTB */
            _.Move("0", V1RCAC_SITCONTB);

            /*" -3419- MOVE '0' TO V1RCAC-SITUACAO */
            _.Move("0", V1RCAC_SITUACAO);

            /*" -3421- MOVE 220 TO V1RCAC-OPERACAO */
            _.Move(220, V1RCAC_OPERACAO);

            /*" -3439- PERFORM R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1 */

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1();

            /*" -3442- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3444- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3444- ADD 1 TO AC-I-V0RCAPCOMP. */
            AREA_DE_WORK.AC_I_V0RCAPCOMP.Value = AREA_DE_WORK.AC_I_V0RCAPCOMP + 1;

        }

        [StopWatch]
        /*" R1120-40-INSERT-V0RCAPCOMP-DB-INSERT-1 */
        public void R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1()
        {
            /*" -3439- EXEC SQL INSERT INTO SEGUROS.V0RCAPCOMP VALUES (:V1RCAC-FONTE , :V1RCAC-NRRCAP , :V1RCAC-NRRCAPCO , :V1RCAC-OPERACAO , :V1SIST-DTMOVACB , CURRENT TIME, :V1RCAC-SITUACAO , :V1RCAC-BCOAVISO , :V1RCAC-AGEAVISO , :V1RCAC-NRAVISO , :V1RCAC-VLRCAP , :V1RCAC-DATARCAP , :V1RCAC-DTCADAST , :V1RCAC-SITCONTB , :V1RCAC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1 = new R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1()
            {
                V1RCAC_FONTE = V1RCAC_FONTE.ToString(),
                V1RCAC_NRRCAP = V1RCAC_NRRCAP.ToString(),
                V1RCAC_NRRCAPCO = V1RCAC_NRRCAPCO.ToString(),
                V1RCAC_OPERACAO = V1RCAC_OPERACAO.ToString(),
                V1SIST_DTMOVACB = V1SIST_DTMOVACB.ToString(),
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

            R1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1.Execute(r1120_40_INSERT_V0RCAPCOMP_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO */
        private void R1120_50_UPDATE_V0AVISOSALDO(bool isPerform = false)
        {
            /*" -3451- MOVE '1124' TO WNR-EXEC-SQL. */
            _.Move("1124", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3458- PERFORM R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1 */

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1();

            /*" -3462- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3465- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3465- GO TO R1120-20-FETCH-V0RCAPCOMP. */

            R1120_20_FETCH_V0RCAPCOMP(); //GOTO
            return;

        }

        [StopWatch]
        /*" R1120-50-UPDATE-V0AVISOSALDO-DB-UPDATE-1 */
        public void R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1()
        {
            /*" -3458- EXEC SQL UPDATE SEGUROS.V0AVISOS_SALDOS SET SDOATU = (SDOATU - :V1RCAC-VLRCAP) WHERE BCOAVISO = :V1RCAC-BCOAVISO AND AGEAVISO = :V1RCAC-AGEAVISO AND NRAVISO = :V1RCAC-NRAVISO END-EXEC. */

            var r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1 = new R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1()
            {
                V1RCAC_VLRCAP = V1RCAC_VLRCAP.ToString(),
                V1RCAC_BCOAVISO = V1RCAC_BCOAVISO.ToString(),
                V1RCAC_AGEAVISO = V1RCAC_AGEAVISO.ToString(),
                V1RCAC_NRAVISO = V1RCAC_NRAVISO.ToString(),
            };

            R1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1.Execute(r1120_50_UPDATE_V0AVISOSALDO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-ACUMULA-CONJ-SECTION */
        private void R1130_00_ACUMULA_CONJ_SECTION()
        {
            /*" -3475- MOVE '1130' TO WNR-EXEC-SQL. */
            _.Move("1130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3475- MOVE 'NAO' TO WTEM-VG082. */
            _.Move("NAO", AREA_DE_WORK.WTEM_VG082);

            /*" -0- FLUXCONTROL_PERFORM R1130_10_DECLARE_VGHISTCONT */

            R1130_10_DECLARE_VGHISTCONT();

        }

        [StopWatch]
        /*" R1130-10-DECLARE-VGHISTCONT */
        private void R1130_10_DECLARE_VGHISTCONT(bool isPerform = false)
        {
            /*" -3496- PERFORM R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1 */

            R1130_10_DECLARE_VGHISTCONT_DB_DECLARE_1();

            /*" -3498- PERFORM R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1 */

            R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1();

            /*" -3501- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3501- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1130-10-DECLARE-VGHISTCONT-DB-OPEN-1 */
        public void R1130_10_DECLARE_VGHISTCONT_DB_OPEN_1()
        {
            /*" -3498- EXEC SQL OPEN CVGHISTCONT END-EXEC. */

            CVGHISTCONT.Open();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-DECLARE-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1()
        {
            /*" -3658- EXEC SQL DECLARE V1APOLCOSCED CURSOR FOR SELECT DISTINCT CODCOSS FROM SEGUROS.V1APOLCOSCED WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE AND DTINIVIG <= :V0ENDO-DTINIVIG AND DTTERVIG >= :V0ENDO-DTINIVIG ORDER BY CODCOSS WITH UR END-EXEC. */
            V1APOLCOSCED = new VG0139B_V1APOLCOSCED(true);
            string GetQuery_V1APOLCOSCED()
            {
                var query = @$"SELECT DISTINCT CODCOSS 
							FROM SEGUROS.V1APOLCOSCED 
							WHERE NUM_APOLICE = '{V0ENDO_NUM_APOLICE}' 
							AND DTINIVIG <= '{V0ENDO_DTINIVIG}' 
							AND DTTERVIG >= '{V0ENDO_DTINIVIG}' 
							ORDER BY CODCOSS";

                return query;
            }
            V1APOLCOSCED.GetQueryEvent += GetQuery_V1APOLCOSCED;

        }

        [StopWatch]
        /*" R1130-20-FETCH-VGHISTCONT */
        private void R1130_20_FETCH_VGHISTCONT(bool isPerform = false)
        {
            /*" -3508- MOVE '1131' TO WNR-EXEC-SQL. */
            _.Move("1131", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3520- PERFORM R1130_20_FETCH_VGHISTCONT_DB_FETCH_1 */

            R1130_20_FETCH_VGHISTCONT_DB_FETCH_1();

            /*" -3523- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3524- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3524- PERFORM R1130_20_FETCH_VGHISTCONT_DB_CLOSE_1 */

                    R1130_20_FETCH_VGHISTCONT_DB_CLOSE_1();

                    /*" -3526- IF WTEM-VG082 EQUAL 'NAO' */

                    if (AREA_DE_WORK.WTEM_VG082 == "NAO")
                    {

                        /*" -3528- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

                        if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
                        {

                            /*" -3531- ADD V0HCTB-PRMVG V0HCTB-PRMAP TO TB-RAMO-VALOR-PRM (V0APOL-RAMO) */
                            TABELA_RAMO.FILLER_0[V0APOL_RAMO].TB_RAMO_VALOR_PRM.Value = TABELA_RAMO.FILLER_0[V0APOL_RAMO].TB_RAMO_VALOR_PRM + V0HCTB_PRMAP;

                            /*" -3532- ELSE */
                        }
                        else
                        {


                            /*" -3535- ADD V0HCTB-PRMVG V0HCTB-PRMAP TO TB-RAMO-VALOR-PRM-R (V0APOL-RAMO) */
                            TABELA_RAMO_R.FILLER_1[V0APOL_RAMO].TB_RAMO_VALOR_PRM_R.Value = TABELA_RAMO_R.FILLER_1[V0APOL_RAMO].TB_RAMO_VALOR_PRM_R + V0HCTB_PRMAP;

                            /*" -3536- END-IF */
                        }


                        /*" -3537- END-IF */
                    }


                    /*" -3538- GO TO R1130-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/ //GOTO
                    return;

                    /*" -3539- ELSE */
                }
                else
                {


                    /*" -3541- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3543- IF V0HCTB-CODOPER NOT LESS 200 AND V0HCTB-CODOPER NOT GREATER 299 */

            if (V0HCTB_CODOPER >= 200 && V0HCTB_CODOPER <= 299)
            {

                /*" -3545- ADD VG082-VLR-PREMIO-RAMO TO TB-RAMO-VALOR-PRM (VG082-RAMO-EMISSOR) */
                TABELA_RAMO.FILLER_0[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM.Value = TABELA_RAMO.FILLER_0[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM + VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO;

                /*" -3546- ELSE */
            }
            else
            {


                /*" -3548- ADD VG082-VLR-PREMIO-RAMO TO TB-RAMO-VALOR-PRM-R (VG082-RAMO-EMISSOR) */
                TABELA_RAMO_R.FILLER_1[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM_R.Value = TABELA_RAMO_R.FILLER_1[VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR].TB_RAMO_VALOR_PRM_R + VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO;

                /*" -3550- END-IF. */
            }


            /*" -3552- MOVE 'SIM' TO WTEM-VG082. */
            _.Move("SIM", AREA_DE_WORK.WTEM_VG082);

            /*" -3552- GO TO R1130-20-FETCH-VGHISTCONT. */
            new Task(() => R1130_20_FETCH_VGHISTCONT()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1130-20-FETCH-VGHISTCONT-DB-FETCH-1 */
        public void R1130_20_FETCH_VGHISTCONT_DB_FETCH_1()
        {
            /*" -3520- EXEC SQL FETCH CVGHISTCONT INTO :VG082-NUM-CERTIFICADO , :VG082-NUM-PARCELA , :VG082-NUM-TITULO , :VG082-OCORR-HISTORICO , :VG082-COD-GRUPO-SUSEP , :VG082-RAMO-EMISSOR , :VG082-COD-MODALIDADE , :VG082-COD-COBERTURA , :VG082-VLR-PREMIO-RAMO , :VG082-COD-USUARIO , :VG082-DTH-ATUALIZACAO END-EXEC. */

            if (CVGHISTCONT.Fetch())
            {
                _.Move(CVGHISTCONT.VG082_NUM_CERTIFICADO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_CERTIFICADO);
                _.Move(CVGHISTCONT.VG082_NUM_PARCELA, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_PARCELA);
                _.Move(CVGHISTCONT.VG082_NUM_TITULO, VG082.DCLVG_HIST_CONT_COBER.VG082_NUM_TITULO);
                _.Move(CVGHISTCONT.VG082_OCORR_HISTORICO, VG082.DCLVG_HIST_CONT_COBER.VG082_OCORR_HISTORICO);
                _.Move(CVGHISTCONT.VG082_COD_GRUPO_SUSEP, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_GRUPO_SUSEP);
                _.Move(CVGHISTCONT.VG082_RAMO_EMISSOR, VG082.DCLVG_HIST_CONT_COBER.VG082_RAMO_EMISSOR);
                _.Move(CVGHISTCONT.VG082_COD_MODALIDADE, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_MODALIDADE);
                _.Move(CVGHISTCONT.VG082_COD_COBERTURA, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_COBERTURA);
                _.Move(CVGHISTCONT.VG082_VLR_PREMIO_RAMO, VG082.DCLVG_HIST_CONT_COBER.VG082_VLR_PREMIO_RAMO);
                _.Move(CVGHISTCONT.VG082_COD_USUARIO, VG082.DCLVG_HIST_CONT_COBER.VG082_COD_USUARIO);
                _.Move(CVGHISTCONT.VG082_DTH_ATUALIZACAO, VG082.DCLVG_HIST_CONT_COBER.VG082_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" R1130-20-FETCH-VGHISTCONT-DB-CLOSE-1 */
        public void R1130_20_FETCH_VGHISTCONT_DB_CLOSE_1()
        {
            /*" -3524- EXEC SQL CLOSE CVGHISTCONT END-EXEC */

            CVGHISTCONT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-ACUMULA-IS-SECTION */
        private void R1200_00_ACUMULA_IS_SECTION()
        {
            /*" -3561- PERFORM R1210-00-ACUMULA-IS. */

            R1210_00_ACUMULA_IS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-SECTION */
        private void R1210_00_ACUMULA_IS_SECTION()
        {
            /*" -3572- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3592- PERFORM R1210_00_ACUMULA_IS_DB_SELECT_1 */

            R1210_00_ACUMULA_IS_DB_SELECT_1();

            /*" -3595- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3597- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3598- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -3600- GO TO R1210-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/ //GOTO
                return;
            }


            /*" -3601- IF V0CBPR-PRMDIT-I LESS ZEROS */

            if (V0CBPR_PRMDIT_I < 00)
            {

                /*" -3603- MOVE ZEROS TO V0CBPR-PRMDIT. */
                _.Move(0, V0CBPR_PRMDIT);
            }


            /*" -3604- COMPUTE AC-IMPMORNATU = AC-IMPMORNATU + V0CBPR-IMPMORNATU. */
            AREA_DE_WORK.AC_IMPMORNATU.Value = AREA_DE_WORK.AC_IMPMORNATU + V0CBPR_IMPMORNATU;

            /*" -3605- COMPUTE AC-IMPMORACID = AC-IMPMORACID + V0CBPR-IMPMORACID. */
            AREA_DE_WORK.AC_IMPMORACID.Value = AREA_DE_WORK.AC_IMPMORACID + V0CBPR_IMPMORACID;

            /*" -3606- COMPUTE AC-IMPINVPERM = AC-IMPINVPERM + V0CBPR-IMPINVPERM. */
            AREA_DE_WORK.AC_IMPINVPERM.Value = AREA_DE_WORK.AC_IMPINVPERM + V0CBPR_IMPINVPERM;

            /*" -3607- COMPUTE AC-IMPAMDS = AC-IMPAMDS + V0CBPR-IMPAMDS. */
            AREA_DE_WORK.AC_IMPAMDS.Value = AREA_DE_WORK.AC_IMPAMDS + V0CBPR_IMPAMDS;

            /*" -3608- COMPUTE AC-IMPDH = AC-IMPDH + V0CBPR-IMPDH. */
            AREA_DE_WORK.AC_IMPDH.Value = AREA_DE_WORK.AC_IMPDH + V0CBPR_IMPDH;

            /*" -3610- COMPUTE AC-IMPDIT = AC-IMPDIT + V0CBPR-IMPDIT. */
            AREA_DE_WORK.AC_IMPDIT.Value = AREA_DE_WORK.AC_IMPDIT + V0CBPR_IMPDIT;

            /*" -3611- IF V0CBPR-IMPDIT NOT EQUAL ZEROES */

            if (V0CBPR_IMPDIT != 00)
            {

                /*" -3611- PERFORM R1220-00-LE-PREMIO-DIT. */

                R1220_00_LE_PREMIO_DIT_SECTION();
            }


        }

        [StopWatch]
        /*" R1210-00-ACUMULA-IS-DB-SELECT-1 */
        public void R1210_00_ACUMULA_IS_DB_SELECT_1()
        {
            /*" -3592- EXEC SQL SELECT IMPMORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, PRMDIT INTO :V0CBPR-IMPMORNATU, :V0CBPR-IMPMORACID, :V0CBPR-IMPINVPERM, :V0CBPR-IMPAMDS, :V0CBPR-IMPDH, :V0CBPR-IMPDIT, :V0CBPR-PRMDIT:V0CBPR-PRMDIT-I FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :WHOST-NRCERTIF AND OCORHIST = :V0COBP-OCORHIST FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1210_00_ACUMULA_IS_DB_SELECT_1_Query1 = new R1210_00_ACUMULA_IS_DB_SELECT_1_Query1()
            {
                V0COBP_OCORHIST = V0COBP_OCORHIST.ToString(),
                WHOST_NRCERTIF = WHOST_NRCERTIF.ToString(),
            };

            var executed_1 = R1210_00_ACUMULA_IS_DB_SELECT_1_Query1.Execute(r1210_00_ACUMULA_IS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CBPR_IMPMORNATU, V0CBPR_IMPMORNATU);
                _.Move(executed_1.V0CBPR_IMPMORACID, V0CBPR_IMPMORACID);
                _.Move(executed_1.V0CBPR_IMPINVPERM, V0CBPR_IMPINVPERM);
                _.Move(executed_1.V0CBPR_IMPAMDS, V0CBPR_IMPAMDS);
                _.Move(executed_1.V0CBPR_IMPDH, V0CBPR_IMPDH);
                _.Move(executed_1.V0CBPR_IMPDIT, V0CBPR_IMPDIT);
                _.Move(executed_1.V0CBPR_PRMDIT, V0CBPR_PRMDIT);
                _.Move(executed_1.V0CBPR_PRMDIT_I, V0CBPR_PRMDIT_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1220-00-LE-PREMIO-DIT-SECTION */
        private void R1220_00_LE_PREMIO_DIT_SECTION()
        {
            /*" -3622- MOVE V0CBPR-PRMDIT TO V0PLAN-PRMDIT. */
            _.Move(V0CBPR_PRMDIT, V0PLAN_PRMDIT);

            /*" -3624- MOVE '1222' TO WNR-EXEC-SQL. */
            _.Move("1222", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3626- MOVE V0PARC-DTVENCTO TO WS-DTBASE. */
            _.Move(V0PARC_DTVENCTO, AREA_DE_WORK.WS_DTBASE);

            /*" -3628- PERFORM R1105-00-ACESSA-V1RAMOIND */

            R1105_00_ACESSA_V1RAMOIND_SECTION();

            /*" -3630- COMPUTE WS-IND-IOF ROUNDED = (V1RIND-PCIOF / 100) + 1 */
            AREA_DE_WORK.WS_IND_IOF.Value = (V1RIND_PCIOF / 100f) + 1;

            /*" -3632- COMPUTE WS-PRM-LIQ-DIT ROUNDED = V0PLAN-PRMDIT / WS-IND-IOF */
            AREA_DE_WORK.WS_PRM_LIQ_DIT.Value = V0PLAN_PRMDIT / AREA_DE_WORK.WS_IND_IOF;

            /*" -3635- COMPUTE WS-VLIOCC-DIT = V0PLAN-PRMDIT - WS-PRM-LIQ-DIT */
            AREA_DE_WORK.WS_VLIOCC_DIT.Value = V0PLAN_PRMDIT - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -3636- IF V0SUBG-IND-IOF = 'N' */

            if (V0SUBG_IND_IOF == "N")
            {

                /*" -3637- MOVE ZEROS TO WS-VLIOCC-DIT */
                _.Move(0, AREA_DE_WORK.WS_VLIOCC_DIT);

                /*" -3639- MOVE V0PLAN-PRMDIT TO WS-PRM-LIQ-DIT. */
                _.Move(V0PLAN_PRMDIT, AREA_DE_WORK.WS_PRM_LIQ_DIT);
            }


            /*" -3640- ADD V0PLAN-PRMDIT TO AC-PRMDIT. */
            AREA_DE_WORK.AC_PRMDIT.Value = AREA_DE_WORK.AC_PRMDIT + V0PLAN_PRMDIT;

            /*" -3641- COMPUTE WS-VLIOCC-TOT-DIT = WS-VLIOCC-TOT-DIT + WS-VLIOCC-DIT. */
            AREA_DE_WORK.WS_VLIOCC_TOT_DIT.Value = AREA_DE_WORK.WS_VLIOCC_TOT_DIT + AREA_DE_WORK.WS_VLIOCC_DIT;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1220_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-SECTION */
        private void R1300_00_GRAVA_COSSEGURO_SECTION()
        {
            /*" -3658- PERFORM R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1 */

            R1300_00_GRAVA_COSSEGURO_DB_DECLARE_1();

            /*" -3661- MOVE '1301' TO WNR-EXEC-SQL. */
            _.Move("1301", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3661- PERFORM R1300_00_GRAVA_COSSEGURO_DB_OPEN_1 */

            R1300_00_GRAVA_COSSEGURO_DB_OPEN_1();

            /*" -3664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3664- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1300_10_FETCH_V1APOLCOSCED */

            R1300_10_FETCH_V1APOLCOSCED();

        }

        [StopWatch]
        /*" R1300-00-GRAVA-COSSEGURO-DB-OPEN-1 */
        public void R1300_00_GRAVA_COSSEGURO_DB_OPEN_1()
        {
            /*" -3661- EXEC SQL OPEN V1APOLCOSCED END-EXEC. */

            V1APOLCOSCED.Open();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED */
        private void R1300_10_FETCH_V1APOLCOSCED(bool isPerform = false)
        {
            /*" -3671- MOVE '1302' TO WNR-EXEC-SQL. */
            _.Move("1302", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3673- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1();

            /*" -3676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3677- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3677- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1 */

                    R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1();

                    /*" -3679- GO TO R1300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                    return;

                    /*" -3680- ELSE */
                }
                else
                {


                    /*" -3683- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -3685- MOVE '1303' TO WNR-EXEC-SQL. */
            _.Move("1303", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3686- MOVE ZEROS TO V0ORDC-COD-EMPRESA. */
            _.Move(0, V0ORDC_COD_EMPRESA);

            /*" -3687- MOVE V0ENDO-NUM-APOLICE TO V0ORDC-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0ORDC_NUM_APOL);

            /*" -3688- MOVE V0ENDO-NRENDOS TO V0ORDC-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0ORDC_NRENDOS);

            /*" -3690- MOVE V1COSP-CONGENER TO V0ORDC-CODCOSS WWORK-ORD-CONGE. */
            _.Move(V1COSP_CONGENER, V0ORDC_CODCOSS);
            _.Move(V1COSP_CONGENER, AREA_DE_WORK.FILLER_7.WWORK_ORD_CONGE);


            /*" -3692- MOVE V0APOL-ORGAO TO WWORK-ORD-ORGAO. */
            _.Move(V0APOL_ORGAO, AREA_DE_WORK.FILLER_7.WWORK_ORD_ORGAO);

            /*" -3693- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -3695- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -3701- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1();

            /*" -3704- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3706- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3708- MOVE '2288' TO WNR-EXEC-SQL. */
            _.Move("2288", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3710- COMPUTE V1NCOS-NRORDEM = V1NCOS-NRORDEM + 1. */
            V1NCOS_NRORDEM.Value = V1NCOS_NRORDEM + 1;

            /*" -3712- MOVE V1NCOS-NRORDEM TO WWORK-ORD-SEQUE. */
            _.Move(V1NCOS_NRORDEM, AREA_DE_WORK.FILLER_7.WWORK_ORD_SEQUE);

            /*" -3714- MOVE WWORK-NUM-ORDEM TO V0ORDC-ORDEM-CED. */
            _.Move(AREA_DE_WORK.WWORK_NUM_ORDEM, V0ORDC_ORDEM_CED);

            /*" -3722- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1();

            /*" -3725- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3727- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3729- ADD +1 TO AC-I-V0ORDECOSCED. */
            AREA_DE_WORK.AC_I_V0ORDECOSCED.Value = AREA_DE_WORK.AC_I_V0ORDECOSCED + +1;

            /*" -3731- MOVE '1304' TO WNR-EXEC-SQL. */
            _.Move("1304", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3732- MOVE V1COSP-CONGENER TO V1NCOS-CONGENER */
            _.Move(V1COSP_CONGENER, V1NCOS_CONGENER);

            /*" -3734- MOVE V0APOL-ORGAO TO V1NCOS-ORGAO. */
            _.Move(V0APOL_ORGAO, V1NCOS_ORGAO);

            /*" -3740- PERFORM R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1 */

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1();

            /*" -3743- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3745- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3747- ADD +1 TO AC-U-V0NUMERO-COSSEGURO. */
            AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO.Value = AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO + +1;

            /*" -3748- MOVE 'EM0103B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0103B1", V0EDIA_CODRELAT);

            /*" -3749- MOVE V0ENDO-NUM-APOLICE TO V0EDIA-NUM-APOL. */
            _.Move(V0ENDO_NUM_APOLICE, V0EDIA_NUM_APOL);

            /*" -3750- MOVE V0ENDO-NRENDOS TO V0EDIA-NRENDOS. */
            _.Move(V0ENDO_NRENDOS, V0EDIA_NRENDOS);

            /*" -3751- MOVE ZEROS TO V0EDIA-NRPARCEL. */
            _.Move(0, V0EDIA_NRPARCEL);

            /*" -3752- MOVE V1SIST-DTMOVABE TO V0EDIA-DTMOVTO. */
            _.Move(V1SIST_DTMOVABE, V0EDIA_DTMOVTO);

            /*" -3753- MOVE ZEROS TO V0EDIA-ORGAO. */
            _.Move(0, V0EDIA_ORGAO);

            /*" -3754- MOVE V0APOL-RAMO TO V0EDIA-RAMO. */
            _.Move(V0APOL_RAMO, V0EDIA_RAMO);

            /*" -3755- MOVE ZEROS TO V0EDIA-FONTE. */
            _.Move(0, V0EDIA_FONTE);

            /*" -3756- MOVE V1COSP-CONGENER TO V0EDIA-CONGENER. */
            _.Move(V1COSP_CONGENER, V0EDIA_CONGENER);

            /*" -3758- MOVE ZEROS TO V0EDIA-CODCORR. */
            _.Move(0, V0EDIA_CODCORR);

            /*" -3760- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -3761- MOVE V0ENDO-FONTE TO V0EDIA-FONTE. */
            _.Move(V0ENDO_FONTE, V0EDIA_FONTE);

            /*" -3762- MOVE 'EM0105B1' TO V0EDIA-CODRELAT. */
            _.Move("EM0105B1", V0EDIA_CODRELAT);

            /*" -3764- PERFORM R1700-INCLUI-V0EMISDIARIA. */

            R1700_INCLUI_V0EMISDIARIA_SECTION();

            /*" -3764- GO TO R1300-10-FETCH-V1APOLCOSCED. */
            new Task(() => R1300_10_FETCH_V1APOLCOSCED()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-FETCH-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_FETCH_1()
        {
            /*" -3673- EXEC SQL FETCH V1APOLCOSCED INTO :V1COSP-CONGENER END-EXEC. */

            if (V1APOLCOSCED.Fetch())
            {
                _.Move(V1APOLCOSCED.V1COSP_CONGENER, V1COSP_CONGENER);
            }

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-CLOSE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_CLOSE_1()
        {
            /*" -3677- EXEC SQL CLOSE V1APOLCOSCED END-EXEC */

            V1APOLCOSCED.Close();

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-SELECT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1()
        {
            /*" -3701- EXEC SQL SELECT NRORDEM INTO :V1NCOS-NRORDEM FROM SEGUROS.V1NUMERO_COSSEGURO WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1 = new R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1()
            {
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            var executed_1 = R1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1NCOS_NRORDEM, V1NCOS_NRORDEM);
            }


        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-INSERT-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1()
        {
            /*" -3722- EXEC SQL INSERT INTO SEGUROS.V0ORDECOSCED VALUES (:V0ORDC-NUM-APOL , :V0ORDC-NRENDOS , :V0ORDC-CODCOSS , :V0ORDC-ORDEM-CED , :V0ORDC-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1 = new R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1()
            {
                V0ORDC_NUM_APOL = V0ORDC_NUM_APOL.ToString(),
                V0ORDC_NRENDOS = V0ORDC_NRENDOS.ToString(),
                V0ORDC_CODCOSS = V0ORDC_CODCOSS.ToString(),
                V0ORDC_ORDEM_CED = V0ORDC_ORDEM_CED.ToString(),
                V0ORDC_COD_EMPRESA = V0ORDC_COD_EMPRESA.ToString(),
            };

            R1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1300-10-FETCH-V1APOLCOSCED-DB-UPDATE-1 */
        public void R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1()
        {
            /*" -3740- EXEC SQL UPDATE SEGUROS.V0NUMERO_COSSEGURO SET NRORDEM = :V1NCOS-NRORDEM , TIMESTAMP = CURRENT TIMESTAMP WHERE ORGAO = :V1NCOS-ORGAO AND CONGENER = :V1NCOS-CONGENER END-EXEC. */

            var r1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1 = new R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1()
            {
                V1NCOS_NRORDEM = V1NCOS_NRORDEM.ToString(),
                V1NCOS_CONGENER = V1NCOS_CONGENER.ToString(),
                V1NCOS_ORGAO = V1NCOS_ORGAO.ToString(),
            };

            R1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1.Execute(r1300_10_FETCH_V1APOLCOSCED_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-GRAVA-V0HISTOPARC-SECTION */
        private void R1400_00_GRAVA_V0HISTOPARC_SECTION()
        {
            /*" -3775- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3776- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -3778- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -3779- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3780- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3781- MOVE 0101 TO V0HISP-OPERACAO */
            _.Move(0101, V0HISP_OPERACAO);

            /*" -3783- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3785- MOVE 1 TO V0HISP-OCORHIST */
            _.Move(1, V0HISP_OCORHIST);

            /*" -3786- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3787- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3788- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3789- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3790- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3791- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3793- COMPUTE V0HISP-VLIOCC = V0HISP-VLPRMTOT - V0HISP-VLPRMLIQ */
            V0HISP_VLIOCC.Value = V0HISP_VLPRMTOT - V0HISP_VLPRMLIQ;

            /*" -3794- MOVE ZEROS TO V0HISP-VLPREMIO */
            _.Move(0, V0HISP_VLPREMIO);

            /*" -3795- MOVE V0HCOB-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V0HCOB_DTVENCTO, V0HISP_DTVENCTO);

            /*" -3796- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3797- MOVE 0 TO V0HISP-NRAVISO */
            _.Move(0, V0HISP_NRAVISO);

            /*" -3798- MOVE 0 TO V0HISP-AGECOBR */
            _.Move(0, V0HISP_AGECOBR);

            /*" -3799- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3800- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3801- MOVE 'VG0139B' TO V0HISP-COD-USUAR */
            _.Move("VG0139B", V0HISP_COD_USUAR);

            /*" -3803- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3805- MOVE -1 TO VIND-DTQITBCO */
            _.Move(-1, VIND_DTQITBCO);

            /*" -3807- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3807- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-OPERACAO-BAIXA-SECTION */
        private void R1500_00_GRAVA_OPERACAO_BAIXA_SECTION()
        {
            /*" -3817- MOVE V0ENDO-NUM-APOLICE TO V0HISP-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0HISP_NUM_APOL);

            /*" -3818- MOVE V0ENDO-NRENDOS TO V0HISP-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0HISP_NRENDOS);

            /*" -3820- MOVE ZEROS TO V0HISP-NRPARCEL */
            _.Move(0, V0HISP_NRPARCEL);

            /*" -3821- MOVE '0' TO V0HISP-DACPARC */
            _.Move("0", V0HISP_DACPARC);

            /*" -3822- MOVE V1SIST-DTMOVACB TO V0HISP-DTMOVTO */
            _.Move(V1SIST_DTMOVACB, V0HISP_DTMOVTO);

            /*" -3824- MOVE 0201 TO V0HISP-OPERACAO */
            _.Move(0201, V0HISP_OPERACAO);

            /*" -3826- MOVE 2 TO V0HISP-OCORHIST */
            _.Move(2, V0HISP_OCORHIST);

            /*" -3827- MOVE V0PARC-PRM-TAR-IX TO V0HISP-PRM-TARIFA */
            _.Move(V0PARC_PRM_TAR_IX, V0HISP_PRM_TARIFA);

            /*" -3828- MOVE V0PARC-VAL-DES-IX TO V0HISP-VAL-DESCON */
            _.Move(V0PARC_VAL_DES_IX, V0HISP_VAL_DESCON);

            /*" -3829- MOVE V0PARC-OTNPRLIQ TO V0HISP-VLPRMLIQ */
            _.Move(V0PARC_OTNPRLIQ, V0HISP_VLPRMLIQ);

            /*" -3830- MOVE V0PARC-OTNADFRA TO V0HISP-VLADIFRA */
            _.Move(V0PARC_OTNADFRA, V0HISP_VLADIFRA);

            /*" -3831- MOVE V0PARC-OTNCUSTO TO V0HISP-VLCUSEMI */
            _.Move(V0PARC_OTNCUSTO, V0HISP_VLCUSEMI);

            /*" -3832- MOVE V0PARC-OTNIOF TO V0HISP-VLIOCC */
            _.Move(V0PARC_OTNIOF, V0HISP_VLIOCC);

            /*" -3834- MOVE V0PARC-OTNTOTAL TO V0HISP-VLPRMTOT */
            _.Move(V0PARC_OTNTOTAL, V0HISP_VLPRMTOT);

            /*" -3835- MOVE V0HISP-VLPRMTOT TO V0HISP-VLPREMIO */
            _.Move(V0HISP_VLPRMTOT, V0HISP_VLPREMIO);

            /*" -3836- MOVE V0HCOB-DTVENCTO TO V0HISP-DTVENCTO */
            _.Move(V0HCOB_DTVENCTO, V0HISP_DTVENCTO);

            /*" -3838- MOVE 104 TO V0HISP-BCOCOBR */
            _.Move(104, V0HISP_BCOCOBR);

            /*" -3840- PERFORM R1102-00-SELECT-RCAP */

            R1102_00_SELECT_RCAP_SECTION();

            /*" -3841- IF WTEM-V0RCAP EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_V0RCAP == "S")
            {

                /*" -3842- MOVE V1RCAC-NRAVISO TO V0HISP-NRAVISO */
                _.Move(V1RCAC_NRAVISO, V0HISP_NRAVISO);

                /*" -3843- MOVE V1RCAC-AGEAVISO TO V0HISP-AGECOBR */
                _.Move(V1RCAC_AGEAVISO, V0HISP_AGECOBR);

                /*" -3844- ELSE */
            }
            else
            {


                /*" -3845- MOVE 0 TO V0HISP-NRAVISO */
                _.Move(0, V0HISP_NRAVISO);

                /*" -3846- MOVE 0 TO V0HISP-AGECOBR */
                _.Move(0, V0HISP_AGECOBR);

                /*" -3848- END-IF */
            }


            /*" -3849- MOVE ZEROS TO V0HISP-NRENDOCA */
            _.Move(0, V0HISP_NRENDOCA);

            /*" -3850- MOVE '0' TO V0HISP-SITCONTB */
            _.Move("0", V0HISP_SITCONTB);

            /*" -3851- MOVE 'VG0139B' TO V0HISP-COD-USUAR */
            _.Move("VG0139B", V0HISP_COD_USUAR);

            /*" -3853- MOVE ZEROS TO V0HISP-RNUDOC */
            _.Move(0, V0HISP_RNUDOC);

            /*" -3854- MOVE +0 TO VIND-DTQITBCO */
            _.Move(+0, VIND_DTQITBCO);

            /*" -3856- MOVE V0HCTB-DTMOVTO-ANT TO V0HISP-DTQITBCO. */
            _.Move(V0HCTB_DTMOVTO_ANT, V0HISP_DTQITBCO);

            /*" -3858- MOVE ZEROS TO V0HISP-COD-EMPRESA. */
            _.Move(0, V0HISP_COD_EMPRESA);

            /*" -3860- PERFORM R1450-00-INSERT-V0HISTOPARC. */

            R1450_00_INSERT_V0HISTOPARC_SECTION();

            /*" -3860- PERFORM R1480-00-UPDATE-V0RCAP. */

            R1480_00_UPDATE_V0RCAP_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-SECTION */
        private void R1450_00_INSERT_V0HISTOPARC_SECTION()
        {
            /*" -3871- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3900- PERFORM R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1 */

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1();

            /*" -3903- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3905- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -3905- ADD +1 TO AC-I-V0HISTOPARC. */
            AREA_DE_WORK.AC_I_V0HISTOPARC.Value = AREA_DE_WORK.AC_I_V0HISTOPARC + +1;

        }

        [StopWatch]
        /*" R1450-00-INSERT-V0HISTOPARC-DB-INSERT-1 */
        public void R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1()
        {
            /*" -3900- EXEC SQL INSERT INTO SEGUROS.V0HISTOPARC VALUES (:V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-DACPARC , :V0HISP-DTMOVTO , :V0HISP-OPERACAO , CURRENT TIME, :V0HISP-OCORHIST , :V0HISP-PRM-TARIFA , :V0HISP-VAL-DESCON , :V0HISP-VLPRMLIQ , :V0HISP-VLADIFRA , :V0HISP-VLCUSEMI , :V0HISP-VLIOCC , :V0HISP-VLPRMTOT , :V0HISP-VLPREMIO , :V0HISP-DTVENCTO , :V0HISP-BCOCOBR , :V0HISP-AGECOBR , :V0HISP-NRAVISO , :V0HISP-NRENDOCA , :V0HISP-SITCONTB , :V0HISP-COD-USUAR , :V0HISP-RNUDOC , :V0HISP-DTQITBCO:VIND-DTQITBCO , :V0HISP-COD-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1 = new R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
                V0HISP_NRENDOS = V0HISP_NRENDOS.ToString(),
                V0HISP_NRPARCEL = V0HISP_NRPARCEL.ToString(),
                V0HISP_DACPARC = V0HISP_DACPARC.ToString(),
                V0HISP_DTMOVTO = V0HISP_DTMOVTO.ToString(),
                V0HISP_OPERACAO = V0HISP_OPERACAO.ToString(),
                V0HISP_OCORHIST = V0HISP_OCORHIST.ToString(),
                V0HISP_PRM_TARIFA = V0HISP_PRM_TARIFA.ToString(),
                V0HISP_VAL_DESCON = V0HISP_VAL_DESCON.ToString(),
                V0HISP_VLPRMLIQ = V0HISP_VLPRMLIQ.ToString(),
                V0HISP_VLADIFRA = V0HISP_VLADIFRA.ToString(),
                V0HISP_VLCUSEMI = V0HISP_VLCUSEMI.ToString(),
                V0HISP_VLIOCC = V0HISP_VLIOCC.ToString(),
                V0HISP_VLPRMTOT = V0HISP_VLPRMTOT.ToString(),
                V0HISP_VLPREMIO = V0HISP_VLPREMIO.ToString(),
                V0HISP_DTVENCTO = V0HISP_DTVENCTO.ToString(),
                V0HISP_BCOCOBR = V0HISP_BCOCOBR.ToString(),
                V0HISP_AGECOBR = V0HISP_AGECOBR.ToString(),
                V0HISP_NRAVISO = V0HISP_NRAVISO.ToString(),
                V0HISP_NRENDOCA = V0HISP_NRENDOCA.ToString(),
                V0HISP_SITCONTB = V0HISP_SITCONTB.ToString(),
                V0HISP_COD_USUAR = V0HISP_COD_USUAR.ToString(),
                V0HISP_RNUDOC = V0HISP_RNUDOC.ToString(),
                V0HISP_DTQITBCO = V0HISP_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0HISP_COD_EMPRESA = V0HISP_COD_EMPRESA.ToString(),
            };

            R1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1.Execute(r1450_00_INSERT_V0HISTOPARC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1480-00-UPDATE-V0RCAP-SECTION */
        private void R1480_00_UPDATE_V0RCAP_SECTION()
        {
            /*" -3916- MOVE '1480' TO WNR-EXEC-SQL. */
            _.Move("1480", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3920- PERFORM R1480_00_UPDATE_V0RCAP_DB_UPDATE_1 */

            R1480_00_UPDATE_V0RCAP_DB_UPDATE_1();

            /*" -3923- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3925- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -3926- ELSE */
                }
                else
                {


                    /*" -3926- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1480-00-UPDATE-V0RCAP-DB-UPDATE-1 */
        public void R1480_00_UPDATE_V0RCAP_DB_UPDATE_1()
        {
            /*" -3920- EXEC SQL UPDATE SEGUROS.V0RCAP SET NRENDOS = :V0ENDO-NRENDOS WHERE NRTIT = :V0HCTB-NRTIT END-EXEC */

            var r1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1 = new R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1()
            {
                V0ENDO_NRENDOS = V0ENDO_NRENDOS.ToString(),
                V0HCTB_NRTIT = V0HCTB_NRTIT.ToString(),
            };

            R1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1.Execute(r1480_00_UPDATE_V0RCAP_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1480_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-SECTION */
        private void R1600_00_INSERT_V0COBERAPOL_SECTION()
        {
            /*" -3938- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3958- PERFORM R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1 */

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1();

            /*" -3961- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3962- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -3963- ADD +1 TO AC-U-V0COBERAPOL */
                    AREA_DE_WORK.AC_U_V0COBERAPOL.Value = AREA_DE_WORK.AC_U_V0COBERAPOL + +1;

                    /*" -3964- PERFORM R1610-00-UPDATE-V0COBERAPOL */

                    R1610_00_UPDATE_V0COBERAPOL_SECTION();

                    /*" -3965- ELSE */
                }
                else
                {


                    /*" -3966- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -3967- ELSE */
                }

            }
            else
            {


                /*" -3967- ADD +1 TO AC-I-V0COBERAPOL. */
                AREA_DE_WORK.AC_I_V0COBERAPOL.Value = AREA_DE_WORK.AC_I_V0COBERAPOL + +1;
            }


        }

        [StopWatch]
        /*" R1600-00-INSERT-V0COBERAPOL-DB-INSERT-1 */
        public void R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1()
        {
            /*" -3958- EXEC SQL INSERT INTO SEGUROS.V0COBERAPOL VALUES (:V0COBA-NUM-APOL , :V0COBA-NRENDOS , :V0COBA-NUM-ITEM , :V0COBA-OCORHIST , :V0COBA-RAMOFR , :V0COBA-MODALIFR , :V0COBA-COD-COBER , :V0COBA-IMP-SEG-IX , :V0COBA-PRM-TAR-IX , :V0COBA-IMP-SEG-VR , :V0COBA-PRM-TAR-VR , :V0COBA-PCT-COBERT , :V0COBA-FATOR-MULT , :V0COBA-DATA-INIVI , :V0COBA-DATA-TERVI , :V0COBA-COD-EMPRESA , CURRENT TIMESTAMP , :V0COBA-SITUACAO:VIND-SITUACAO) END-EXEC. */

            var r1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1 = new R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1()
            {
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_IMP_SEG_IX = V0COBA_IMP_SEG_IX.ToString(),
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_IMP_SEG_VR = V0COBA_IMP_SEG_VR.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_FATOR_MULT = V0COBA_FATOR_MULT.ToString(),
                V0COBA_DATA_INIVI = V0COBA_DATA_INIVI.ToString(),
                V0COBA_DATA_TERVI = V0COBA_DATA_TERVI.ToString(),
                V0COBA_COD_EMPRESA = V0COBA_COD_EMPRESA.ToString(),
                V0COBA_SITUACAO = V0COBA_SITUACAO.ToString(),
                VIND_SITUACAO = VIND_SITUACAO.ToString(),
            };

            R1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1.Execute(r1600_00_INSERT_V0COBERAPOL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-UPDATE-V0COBERAPOL-SECTION */
        private void R1610_00_UPDATE_V0COBERAPOL_SECTION()
        {
            /*" -3979- MOVE '1610' TO WNR-EXEC-SQL. */
            _.Move("1610", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -3991- PERFORM R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1 */

            R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1();

            /*" -3994- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3994- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1610-00-UPDATE-V0COBERAPOL-DB-UPDATE-1 */
        public void R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1()
        {
            /*" -3991- EXEC SQL UPDATE SEGUROS.V0COBERAPOL SET PRM_TARIFARIO_IX = :V0COBA-PRM-TAR-IX , PRM_TARIFARIO_VAR = :V0COBA-PRM-TAR-VR , PCT_COBERTURA = :V0COBA-PCT-COBERT WHERE NUM_APOLICE = :V0COBA-NUM-APOL AND NRENDOS = :V0COBA-NRENDOS AND NUM_ITEM = :V0COBA-NUM-ITEM AND OCORHIST = :V0COBA-OCORHIST AND RAMOFR = :V0COBA-RAMOFR AND MODALIFR = :V0COBA-MODALIFR AND COD_COBERTURA = :V0COBA-COD-COBER END-EXEC. */

            var r1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1 = new R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1()
            {
                V0COBA_PRM_TAR_IX = V0COBA_PRM_TAR_IX.ToString(),
                V0COBA_PRM_TAR_VR = V0COBA_PRM_TAR_VR.ToString(),
                V0COBA_PCT_COBERT = V0COBA_PCT_COBERT.ToString(),
                V0COBA_COD_COBER = V0COBA_COD_COBER.ToString(),
                V0COBA_NUM_APOL = V0COBA_NUM_APOL.ToString(),
                V0COBA_NUM_ITEM = V0COBA_NUM_ITEM.ToString(),
                V0COBA_OCORHIST = V0COBA_OCORHIST.ToString(),
                V0COBA_MODALIFR = V0COBA_MODALIFR.ToString(),
                V0COBA_NRENDOS = V0COBA_NRENDOS.ToString(),
                V0COBA_RAMOFR = V0COBA_RAMOFR.ToString(),
            };

            R1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1.Execute(r1610_00_UPDATE_V0COBERAPOL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-SECTION */
        private void R1700_INCLUI_V0EMISDIARIA_SECTION()
        {
            /*" -4005- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4020- PERFORM R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1 */

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1();

            /*" -4023- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -4024- DISPLAY 'R1700-00 (REGISTRO DUPLICADO) ... ' */
                _.Display($"R1700-00 (REGISTRO DUPLICADO) ... ");

                /*" -4026- GO TO R1700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4027- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4028- DISPLAY 'R1700-00 (PROBLEMAS NA INSERCAO) ... ' */
                _.Display($"R1700-00 (PROBLEMAS NA INSERCAO) ... ");

                /*" -4030- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4030- ADD 1 TO AC-I-V0EMISDIARIA. */
            AREA_DE_WORK.AC_I_V0EMISDIARIA.Value = AREA_DE_WORK.AC_I_V0EMISDIARIA + 1;

        }

        [StopWatch]
        /*" R1700-INCLUI-V0EMISDIARIA-DB-INSERT-1 */
        public void R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1()
        {
            /*" -4020- EXEC SQL INSERT INTO SEGUROS.V0EMISDIARIA VALUES (:V0EDIA-CODRELAT , :V0EDIA-NUM-APOL , :V0EDIA-NRENDOS , :V0EDIA-NRPARCEL , :V0EDIA-DTMOVTO , :V0EDIA-ORGAO , :V0EDIA-RAMO , :V0EDIA-FONTE , :V0EDIA-CONGENER , :V0EDIA-CODCORR , :V0EDIA-SITUACAO , NULL , CURRENT TIMESTAMP) END-EXEC. */

            var r1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1 = new R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1()
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
            };

            R1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1.Execute(r1700_INCLUI_V0EMISDIARIA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2000-TRATA-COBERTURAS-SECTION */
        private void R2000_TRATA_COBERTURAS_SECTION()
        {
            /*" -4045- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4048- MOVE V0PARC-PRM-TAR-IX TO WSHOST-PRM-TAR-IX. */
            _.Move(V0PARC_PRM_TAR_IX, AREA_DE_WORK.WSHOST_PRM_TAR_IX);

            /*" -4049- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -4050- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -4051- SET WS-COB02 TO 1. */
            WS_COB02.Value = 1;

            /*" -4052- SET WS-COB05 TO 1. */
            WS_COB05.Value = 1;

            /*" -4054- SET WS-COB11 TO 1. */
            WS_COB11.Value = 1;

            /*" -4057- PERFORM R2010-00-LIMPA-COBERTURA 010 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2010_00_LIMPA_COBERTURA_SECTION();

            }

            /*" -4058- MOVE V0ENDO-NUM-APOLICE TO V0COBA-NUM-APOL */
            _.Move(V0ENDO_NUM_APOLICE, V0COBA_NUM_APOL);

            /*" -4059- MOVE V0ENDO-NRENDOS TO V0COBA-NRENDOS */
            _.Move(V0ENDO_NRENDOS, V0COBA_NRENDOS);

            /*" -4060- MOVE ZEROS TO V0COBA-NUM-ITEM */
            _.Move(0, V0COBA_NUM_ITEM);

            /*" -4061- MOVE 1 TO V0COBA-FATOR-MULT */
            _.Move(1, V0COBA_FATOR_MULT);

            /*" -4062- MOVE ZEROS TO V0COBA-COD-EMPRESA */
            _.Move(0, V0COBA_COD_EMPRESA);

            /*" -4063- MOVE '0' TO V0COBA-SITUACAO */
            _.Move("0", V0COBA_SITUACAO);

            /*" -4065- MOVE +0 TO VIND-SITUACAO */
            _.Move(+0, VIND_SITUACAO);

            /*" -4066- MOVE V0ENDO-DTINIVIG TO V0COBA-DATA-INIVI */
            _.Move(V0ENDO_DTINIVIG, V0COBA_DATA_INIVI);

            /*" -4067- MOVE V0ENDO-DTTERVIG TO V0COBA-DATA-TERVI */
            _.Move(V0ENDO_DTTERVIG, V0COBA_DATA_TERVI);

            /*" -4069- MOVE 1 TO V0COBA-OCORHIST. */
            _.Move(1, V0COBA_OCORHIST);

            /*" -4070- IF WTEM-VG082 EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_VG082 == "SIM")
            {

                /*" -4071- PERFORM R2060-00-DIFERE-COBERTURA */

                R2060_00_DIFERE_COBERTURA_SECTION();

                /*" -4072- PERFORM R2500-00-AJUSTA-COBERTURA */

                R2500_00_AJUSTA_COBERTURA_SECTION();

                /*" -4073- ELSE */
            }
            else
            {


                /*" -4074- IF WS-PRM-LIQ-DIT NOT EQUAL ZEROS */

                if (AREA_DE_WORK.WS_PRM_LIQ_DIT != 00)
                {

                    /*" -4076- IF V0ENDO-RAMO EQUAL 82 OR 93 */

                    if (V0ENDO_RAMO.In("82", "93"))
                    {

                        /*" -4077- MOVE V0ENDO-RAMO TO V0COBA-RAMOFR */
                        _.Move(V0ENDO_RAMO, V0COBA_RAMOFR);

                        /*" -4079- MOVE V0PARC-OTNTOTAL TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(V0PARC_OTNTOTAL, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -4080- PERFORM R2070-00-TRATA-COBERAPOL */

                        R2070_00_TRATA_COBERAPOL_SECTION();

                        /*" -4081- PERFORM R2500-00-AJUSTA-COBERTURA */

                        R2500_00_AJUSTA_COBERTURA_SECTION();

                        /*" -4082- ELSE */
                    }
                    else
                    {


                        /*" -4083- PERFORM R2100-00-TRATA-COBERAPOL */

                        R2100_00_TRATA_COBERAPOL_SECTION();

                        /*" -4084- END-IF */
                    }


                    /*" -4085- ELSE */
                }
                else
                {


                    /*" -4086- PERFORM R2100-00-TRATA-COBERAPOL */

                    R2100_00_TRATA_COBERAPOL_SECTION();

                    /*" -4087- END-IF */
                }


                /*" -4087- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-LIMPA-COBERTURA-SECTION */
        private void R2010_00_LIMPA_COBERTURA_SECTION()
        {
            /*" -4100- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4108- MOVE ZEROS TO WCOB00-RAMO(WS-COB00) WCOB00-COBE(WS-COB00) WCOB00-IMPSEG(WS-COB00) WCOB00-PRMTAR(WS-COB00) WCOB00-QTDE(WS-COB00) WCOB00-PERCEN(WS-COB00). */
            _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

            /*" -4111- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

            /*" -4118- MOVE ZEROS TO WCOB01-RAMO(WS-COB01) WCOB01-COBE(WS-COB01) WCOB01-IMPSEG(WS-COB01) WCOB01-PERCEN(WS-COB01) WCOB01-PRMTAR(WS-COB01). */
            _.Move(0, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR);

            /*" -4121- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

            /*" -4128- MOVE ZEROS TO WCOB02-RAMO(WS-COB02) WCOB02-COBE(WS-COB02) WCOB02-IMPSEG(WS-COB02) WCOB02-PERCEN(WS-COB02) WCOB02-PRMTAR(WS-COB02). */
            _.Move(0, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_COBE, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_IMPSEG, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PERCEN, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PRMTAR);

            /*" -4131- SET WS-COB02 UP BY 1. */
            WS_COB02.Value += 1;

            /*" -4138- MOVE ZEROS TO WCOB05-RAMO(WS-COB05) WCOB05-COBE(WS-COB05) WCOB05-IMPSEG(WS-COB05) WCOB05-PERCEN(WS-COB05) WCOB05-PRMTAR(WS-COB05). */
            _.Move(0, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_COBE, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_IMPSEG, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PERCEN, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PRMTAR);

            /*" -4141- SET WS-COB05 UP BY 1. */
            WS_COB05.Value += 1;

            /*" -4148- MOVE ZEROS TO WCOB11-RAMO(WS-COB11) WCOB11-COBE(WS-COB11) WCOB11-IMPSEG(WS-COB11) WCOB11-PERCEN(WS-COB11) WCOB11-PRMTAR(WS-COB11). */
            _.Move(0, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_COBE, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_IMPSEG, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PERCEN, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR);

            /*" -4148- SET WS-COB11 UP BY 1. */
            WS_COB11.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2060-00-DIFERE-COBERTURA-SECTION */
        private void R2060_00_DIFERE_COBERTURA_SECTION()
        {
            /*" -4160- MOVE '2060' TO WNR-EXEC-SQL. */
            _.Move("2060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4161- IF V0ENDO-TIPO-ENDO EQUAL '1' */

            if (V0ENDO_TIPO_ENDO == "1")
            {

                /*" -4162- MOVE 99 TO WS-IND1 */
                _.Move(99, AREA_DE_WORK.WS_IND1);

                /*" -4164- PERFORM UNTIL WS-IND1 EQUAL ZEROS OR TB-RAMO-VALOR-PRM(WS-IND1) GREATER ZEROS */

                while (!(AREA_DE_WORK.WS_IND1 == 00 || TABELA_RAMO.FILLER_0[AREA_DE_WORK.WS_IND1].TB_RAMO_VALOR_PRM > 00))
                {

                    /*" -4165- SUBTRACT 1 FROM WS-IND1 */
                    AREA_DE_WORK.WS_IND1.Value = AREA_DE_WORK.WS_IND1 - 1;

                    /*" -4166- END-PERFORM */
                }

                /*" -4167- MOVE ZEROS TO WS-IND */
                _.Move(0, AREA_DE_WORK.WS_IND);

                /*" -4168- MOVE 'NAO' TO WTEM-RAMO-COMP */
                _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_COMP);

                /*" -4169- PERFORM UNTIL WS-IND GREATER 99 */

                while (!(AREA_DE_WORK.WS_IND > 99))
                {

                    /*" -4170- ADD 1 TO WS-IND */
                    AREA_DE_WORK.WS_IND.Value = AREA_DE_WORK.WS_IND + 1;

                    /*" -4171- IF TB-RAMO-VALOR-PRM(WS-IND) GREATER ZEROS */

                    if (TABELA_RAMO.FILLER_0[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM > 00)
                    {

                        /*" -4172- MOVE 'SIM' TO WTEM-RAMO-COMP */
                        _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_COMP);

                        /*" -4173- MOVE WS-IND TO V0COBA-RAMOFR */
                        _.Move(AREA_DE_WORK.WS_IND, V0COBA_RAMOFR);

                        /*" -4176- MOVE TB-RAMO-VALOR-PRM(WS-IND) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(TABELA_RAMO.FILLER_0[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -4177- PERFORM R2070-00-TRATA-COBERAPOL */

                        R2070_00_TRATA_COBERAPOL_SECTION();

                        /*" -4178- END-IF */
                    }


                    /*" -4179- END-PERFORM */
                }

                /*" -4180- ELSE */
            }
            else
            {


                /*" -4181- MOVE 99 TO WS-IND1 */
                _.Move(99, AREA_DE_WORK.WS_IND1);

                /*" -4183- PERFORM UNTIL WS-IND1 EQUAL ZEROS OR TB-RAMO-VALOR-PRM-R (WS-IND1) GREATER ZEROS */

                while (!(AREA_DE_WORK.WS_IND1 == 00 || TABELA_RAMO_R.FILLER_1[AREA_DE_WORK.WS_IND1].TB_RAMO_VALOR_PRM_R > 00))
                {

                    /*" -4184- SUBTRACT 1 FROM WS-IND1 */
                    AREA_DE_WORK.WS_IND1.Value = AREA_DE_WORK.WS_IND1 - 1;

                    /*" -4185- END-PERFORM */
                }

                /*" -4189- MOVE ZEROS TO WS-IND WS-ACUM-IND WS-ACUM-PRM WS-ACUM-IOF */
                _.Move(0, AREA_DE_WORK.WS_IND, AREA_DE_WORK.WS_ACUM_IND, AREA_DE_WORK.WS_ACUM_PRM, AREA_DE_WORK.WS_ACUM_IOF);

                /*" -4190- MOVE 'NAO' TO WTEM-RAMO-COMP */
                _.Move("NAO", AREA_DE_WORK.WTEM_RAMO_COMP);

                /*" -4191- PERFORM UNTIL WS-IND GREATER 99 */

                while (!(AREA_DE_WORK.WS_IND > 99))
                {

                    /*" -4192- ADD 1 TO WS-IND */
                    AREA_DE_WORK.WS_IND.Value = AREA_DE_WORK.WS_IND + 1;

                    /*" -4193- IF TB-RAMO-VALOR-PRM-R (WS-IND) GREATER ZEROS */

                    if (TABELA_RAMO_R.FILLER_1[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM_R > 00)
                    {

                        /*" -4194- MOVE 'SIM' TO WTEM-RAMO-COMP */
                        _.Move("SIM", AREA_DE_WORK.WTEM_RAMO_COMP);

                        /*" -4195- MOVE WS-IND TO V0COBA-RAMOFR */
                        _.Move(AREA_DE_WORK.WS_IND, V0COBA_RAMOFR);

                        /*" -4198- MOVE TB-RAMO-VALOR-PRM-R (WS-IND) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                        _.Move(TABELA_RAMO_R.FILLER_1[AREA_DE_WORK.WS_IND].TB_RAMO_VALOR_PRM_R, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -4199- PERFORM R2070-00-TRATA-COBERAPOL */

                        R2070_00_TRATA_COBERAPOL_SECTION();

                        /*" -4200- END-IF */
                    }


                    /*" -4201- END-PERFORM */
                }

                /*" -4202- END-IF */
            }


            /*" -4203- IF WTEM-RAMO-COMP EQUAL 'NAO' */

            if (AREA_DE_WORK.WTEM_RAMO_COMP == "NAO")
            {

                /*" -4206- IF V0APOL-RAMO EQUAL 97 AND V0COBA-RAMOFR EQUAL 82 NEXT SENTENCE */

                if (V0APOL_RAMO == 97 && V0COBA_RAMOFR == 82)
                {

                    /*" -4207- ELSE */
                }
                else
                {


                    /*" -4209- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4210- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -4211- MOVE ZEROS TO V0COBA-COD-COBER */
                    _.Move(0, V0COBA_COD_COBER);

                    /*" -4212- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4213- MOVE 11 TO V0COBA-COD-COBER */
                    _.Move(11, V0COBA_COD_COBER);

                    /*" -4214- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4215- END-IF */
                }


                /*" -4215- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_99_SAIDA*/

        [StopWatch]
        /*" R2070-00-TRATA-COBERAPOL-SECTION */
        private void R2070_00_TRATA_COBERAPOL_SECTION()
        {
            /*" -4226- MOVE '2070' TO WNR-EXEC-SQL. */
            _.Move("2070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4228- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR. */
            _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

            /*" -4231- MOVE ZEROS TO V0COBA-PCT-COBERT. */
            _.Move(0, V0COBA_PCT_COBERT);

            /*" -4232- IF AC-IMPMORACID NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_IMPMORACID != 00)
            {

                /*" -4234- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -4235- ELSE */
            }
            else
            {


                /*" -4236- IF AC-IMPMORNATU NOT EQUAL ZEROS */

                if (AREA_DE_WORK.AC_IMPMORNATU != 00)
                {

                    /*" -4239- MOVE AC-IMPMORNATU TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR. */
                    _.Move(AREA_DE_WORK.AC_IMPMORNATU, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);
                }

            }


            /*" -4241- COMPUTE AC-VALPRM ROUNDED EQUAL (V0COBA-PRM-TAR-IX / WS-IND-IOF). */
            AREA_DE_WORK.AC_VALPRM.Value = (V0COBA_PRM_TAR_IX / AREA_DE_WORK.WS_IND_IOF);

            /*" -4243- MOVE AC-VALPRM TO V0COBA-PRM-TAR-IX. */
            _.Move(AREA_DE_WORK.AC_VALPRM, V0COBA_PRM_TAR_IX);

            /*" -4244- IF V0COBA-RAMOFR EQUAL 82 */

            if (V0COBA_RAMOFR == 82)
            {

                /*" -4245- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -4248- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -4250- IF (WS-PRM-LIQ-DIT GREATER ZEROS) AND (WTEM-VG082 EQUAL 'NAO' ) */

                if ((AREA_DE_WORK.WS_PRM_LIQ_DIT > 00) && (AREA_DE_WORK.WTEM_VG082 == "NAO"))
                {

                    /*" -4251- PERFORM R2080-00-PREMIO-DIT */

                    R2080_00_PREMIO_DIT_SECTION();

                    /*" -4252- ELSE */
                }
                else
                {


                    /*" -4253- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4254- PERFORM R2200-00-ACUMULA-COBERTURA */

                    R2200_00_ACUMULA_COBERTURA_SECTION();

                    /*" -4255- ELSE */
                }

            }
            else
            {


                /*" -4256- IF V0COBA-RAMOFR EQUAL 93 */

                if (V0COBA_RAMOFR == 93)
                {

                    /*" -4257- MOVE 11 TO V0COBA-COD-COBER */
                    _.Move(11, V0COBA_COD_COBER);

                    /*" -4259- MOVE AC-IMPMORNATU TO V0COBA-IMP-SEG-IX */
                    _.Move(AREA_DE_WORK.AC_IMPMORNATU, V0COBA_IMP_SEG_IX);

                    /*" -4261- IF (WS-PRM-LIQ-DIT GREATER ZEROS) AND (WTEM-VG082 EQUAL 'NAO' ) */

                    if ((AREA_DE_WORK.WS_PRM_LIQ_DIT > 00) && (AREA_DE_WORK.WTEM_VG082 == "NAO"))
                    {

                        /*" -4262- PERFORM R2080-00-PREMIO-DIT */

                        R2080_00_PREMIO_DIT_SECTION();

                        /*" -4263- ELSE */
                    }
                    else
                    {


                        /*" -4264- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -4265- PERFORM R2200-00-ACUMULA-COBERTURA */

                        R2200_00_ACUMULA_COBERTURA_SECTION();

                        /*" -4266- ELSE */
                    }

                }
                else
                {


                    /*" -4268- IF (V0COBA-RAMOFR EQUAL 90) AND (WS-PRM-LIQ-DIT GREATER ZEROS) */

                    if ((V0COBA_RAMOFR == 90) && (AREA_DE_WORK.WS_PRM_LIQ_DIT > 00))
                    {

                        /*" -4269- MOVE 1 TO V0COBA-COD-COBER */
                        _.Move(1, V0COBA_COD_COBER);

                        /*" -4272- COMPUTE V0COBA-PRM-TAR-VR = V0COBA-PRM-TAR-IX - WS-PRM-LIQ-DIT */
                        V0COBA_PRM_TAR_VR.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.WS_PRM_LIQ_DIT;

                        /*" -4274- MOVE V0COBA-PRM-TAR-VR TO V0COBA-PRM-TAR-IX */
                        _.Move(V0COBA_PRM_TAR_VR, V0COBA_PRM_TAR_IX);

                        /*" -4276- PERFORM R2200-00-ACUMULA-COBERTURA */

                        R2200_00_ACUMULA_COBERTURA_SECTION();

                        /*" -4277- MOVE 5 TO V0COBA-COD-COBER */
                        _.Move(5, V0COBA_COD_COBER);

                        /*" -4280- MOVE WS-PRM-LIQ-DIT TO V0COBA-PRM-TAR-VR V0COBA-PRM-TAR-IX */
                        _.Move(AREA_DE_WORK.WS_PRM_LIQ_DIT, V0COBA_PRM_TAR_VR, V0COBA_PRM_TAR_IX);

                        /*" -4281- PERFORM R2200-00-ACUMULA-COBERTURA */

                        R2200_00_ACUMULA_COBERTURA_SECTION();

                        /*" -4282- ELSE */
                    }
                    else
                    {


                        /*" -4283- MOVE 1 TO V0COBA-COD-COBER */
                        _.Move(1, V0COBA_COD_COBER);

                        /*" -4285- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -4285- PERFORM R2200-00-ACUMULA-COBERTURA. */

                        R2200_00_ACUMULA_COBERTURA_SECTION();
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2070_99_SAIDA*/

        [StopWatch]
        /*" R2080-00-PREMIO-DIT-SECTION */
        private void R2080_00_PREMIO_DIT_SECTION()
        {
            /*" -4298- MOVE '2080' TO WNR-EXEC-SQL. */
            _.Move("2080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4300- COMPUTE V0COBA-PRM-TAR-IX EQUAL V0COBA-PRM-TAR-IX - WS-PRM-LIQ-DIT */
            V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.WS_PRM_LIQ_DIT;

            /*" -4301- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
            _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -4303- PERFORM R2200-00-ACUMULA-COBERTURA. */

            R2200_00_ACUMULA_COBERTURA_SECTION();

            /*" -4304- MOVE 90 TO V0COBA-RAMOFR */
            _.Move(90, V0COBA_RAMOFR);

            /*" -4305- MOVE 5 TO V0COBA-COD-COBER */
            _.Move(5, V0COBA_COD_COBER);

            /*" -4307- MOVE AC-IMPDIT TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
            _.Move(AREA_DE_WORK.AC_IMPDIT, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -4309- MOVE WS-PRM-LIQ-DIT TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
            _.Move(AREA_DE_WORK.WS_PRM_LIQ_DIT, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -4309- PERFORM R2200-00-ACUMULA-COBERTURA. */

            R2200_00_ACUMULA_COBERTURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2080_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-TRATA-COBERAPOL-SECTION */
        private void R2100_00_TRATA_COBERAPOL_SECTION()
        {
            /*" -4322- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4323- IF V0APOL-RAMO = 81 OR 97 OR 82 */

            if (V0APOL_RAMO.In("81", "97", "82"))
            {

                /*" -4324- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -4325- MOVE 82 TO V0COBA-RAMOFR */
                    _.Move(82, V0COBA_RAMOFR);

                    /*" -4326- ELSE */
                }
                else
                {


                    /*" -4327- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -4328- END-IF */
                }


                /*" -4330- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                /*" -4331- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -4333- MOVE AC-IMPMORACID TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORACID, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -4334- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -4337- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMVG + WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMVG + AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -4338- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4340- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -4341- ELSE */
                }
                else
                {


                    /*" -4343- MOVE V0PARC-OTNPRLIQ TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(V0PARC_OTNPRLIQ, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4344- MOVE 100 TO V0COBA-PCT-COBERT */
                    _.Move(100, V0COBA_PCT_COBERT);

                    /*" -4345- END-IF */
                }


                /*" -4347- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -4348- MOVE 1 TO V0COBA-COD-COBER */
                _.Move(1, V0COBA_COD_COBER);

                /*" -4349- IF AC-PRMDIT GREATER 0 */

                if (AREA_DE_WORK.AC_PRMDIT > 0)
                {

                    /*" -4352- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0COBA-PRM-TAR-IX - AC-PRMDIT + WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = V0COBA_PRM_TAR_IX - AREA_DE_WORK.AC_PRMDIT + AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -4353- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4355- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -4356- END-IF */
                }


                /*" -4358- PERFORM R1600-00-INSERT-V0COBERAPOL */

                R1600_00_INSERT_V0COBERAPOL_SECTION();

                /*" -4359- IF AC-IMPINVPERM GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPINVPERM > 00)
                {

                    /*" -4361- MOVE AC-IMPINVPERM TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPINVPERM, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -4364- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR V0COBA-PCT-COBERT */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR, V0COBA_PCT_COBERT);

                    /*" -4365- MOVE 2 TO V0COBA-COD-COBER */
                    _.Move(2, V0COBA_COD_COBER);

                    /*" -4366- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4368- END-IF */
                }


                /*" -4369- IF AC-IMPAMDS GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPAMDS > 00)
                {

                    /*" -4371- MOVE AC-IMPAMDS TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPAMDS, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -4373- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4374- MOVE 3 TO V0COBA-COD-COBER */
                    _.Move(3, V0COBA_COD_COBER);

                    /*" -4375- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4377- END-IF */
                }


                /*" -4378- IF AC-IMPDH GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDH > 00)
                {

                    /*" -4380- MOVE AC-IMPDH TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDH, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -4382- MOVE 0 TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR */
                    _.Move(0, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4383- MOVE 4 TO V0COBA-COD-COBER */
                    _.Move(4, V0COBA_COD_COBER);

                    /*" -4384- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4386- END-IF */
                }


                /*" -4387- IF AC-IMPDIT GREATER ZEROES */

                if (AREA_DE_WORK.AC_IMPDIT > 00)
                {

                    /*" -4389- MOVE AC-IMPDIT TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                    _.Move(AREA_DE_WORK.AC_IMPDIT, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                    /*" -4391- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMDIT - WS-VLIOCC-TOT-DIT */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMDIT - AREA_DE_WORK.WS_VLIOCC_TOT_DIT;

                    /*" -4392- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4393- MOVE 90 TO V0COBA-RAMOFR */
                    _.Move(90, V0COBA_RAMOFR);

                    /*" -4394- MOVE 5 TO V0COBA-COD-COBER */
                    _.Move(5, V0COBA_COD_COBER);

                    /*" -4396- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -4397- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4398- END-IF */
                }


                /*" -4399- PERFORM R1060-00-DIFERE-COBERTURA */

                R1060_00_DIFERE_COBERTURA_SECTION();

                /*" -4400- END-IF. */
            }


            /*" -4401- IF V0APOL-RAMO = 93 OR 97 OR 77 */

            if (V0APOL_RAMO.In("93", "97", "77"))
            {

                /*" -4402- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -4403- MOVE 93 TO V0COBA-RAMOFR */
                    _.Move(93, V0COBA_RAMOFR);

                    /*" -4404- ELSE */
                }
                else
                {


                    /*" -4405- MOVE V0APOL-RAMO TO V0COBA-RAMOFR */
                    _.Move(V0APOL_RAMO, V0COBA_RAMOFR);

                    /*" -4406- END-IF */
                }


                /*" -4408- MOVE V0APOL-MODALIDA TO V0COBA-MODALIFR */
                _.Move(V0APOL_MODALIDA, V0COBA_MODALIFR);

                /*" -4409- MOVE 0 TO V0COBA-COD-COBER */
                _.Move(0, V0COBA_COD_COBER);

                /*" -4411- MOVE AC-IMPMORNATU TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR */
                _.Move(AREA_DE_WORK.AC_IMPMORNATU, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

                /*" -4413- COMPUTE AC-PRMVG = AC-PRMVG - AC-PRMRTO */
                AREA_DE_WORK.AC_PRMVG.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.AC_PRMRTO;

                /*" -4415- COMPUTE WS-VLIOCC-TOT-VG = WS-VLIOCC-TOT-VG - WS-VLIOCC-TOT-RTO */
                AREA_DE_WORK.WS_VLIOCC_TOT_VG.Value = AREA_DE_WORK.WS_VLIOCC_TOT_VG - AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                /*" -4416- IF V0APOL-RAMO = 97 */

                if (V0APOL_RAMO == 97)
                {

                    /*" -4418- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = AC-PRMVG - WS-VLIOCC-TOT-VG */
                    V0COBA_PRM_TAR_IX.Value = AREA_DE_WORK.AC_PRMVG - AREA_DE_WORK.WS_VLIOCC_TOT_VG;

                    /*" -4419- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                    _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                    /*" -4421- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                    V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                    /*" -4422- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4423- MOVE 11 TO V0COBA-COD-COBER */
                    _.Move(11, V0COBA_COD_COBER);

                    /*" -4424- PERFORM R1600-00-INSERT-V0COBERAPOL */

                    R1600_00_INSERT_V0COBERAPOL_SECTION();

                    /*" -4425- ELSE */
                }
                else
                {


                    /*" -4426- IF AC-IMPRTO GREATER 0 */

                    if (AREA_DE_WORK.AC_IMPRTO > 0)
                    {

                        /*" -4429- COMPUTE V0COBA-PRM-TAR-IX ROUNDED = V0PARC-OTNPRLIQ - AC-PRMRTO + WS-VLIOCC-TOT-RTO */
                        V0COBA_PRM_TAR_IX.Value = V0PARC_OTNPRLIQ - AREA_DE_WORK.AC_PRMRTO + AREA_DE_WORK.WS_VLIOCC_TOT_RTO;

                        /*" -4430- MOVE V0COBA-PRM-TAR-IX TO V0COBA-PRM-TAR-VR */
                        _.Move(V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

                        /*" -4432- COMPUTE V0COBA-PCT-COBERT ROUNDED = (V0COBA-PRM-TAR-IX / V0PARC-OTNPRLIQ) * 100 */
                        V0COBA_PCT_COBERT.Value = (V0COBA_PRM_TAR_IX / V0PARC_OTNPRLIQ) * 100;

                        /*" -4433- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -4434- MOVE 11 TO V0COBA-COD-COBER */
                        _.Move(11, V0COBA_COD_COBER);

                        /*" -4435- PERFORM R1600-00-INSERT-V0COBERAPOL */

                        R1600_00_INSERT_V0COBERAPOL_SECTION();

                        /*" -4436- ELSE */
                    }
                    else
                    {


                        /*" -4436- PERFORM R1060-00-DIFERE-COBERTURA. */

                        R1060_00_DIFERE_COBERTURA_SECTION();
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-ACUMULA-COBERTURA-SECTION */
        private void R2200_00_ACUMULA_COBERTURA_SECTION()
        {
            /*" -4451- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4454- COMPUTE WSHOST-PRM-TAR-IX EQUAL WSHOST-PRM-TAR-IX - V0COBA-PRM-TAR-IX. */
            AREA_DE_WORK.WSHOST_PRM_TAR_IX.Value = AREA_DE_WORK.WSHOST_PRM_TAR_IX - V0COBA_PRM_TAR_IX;

            /*" -4455- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -4456- SEARCH WCOB00-OCORRECOB */
            for (; WS_COB00 < TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB.Items.Count; WS_COB00.Value++)
            {

                /*" -4460- WHEN (WCOB00-RAMO(WS-COB00) EQUAL V0COBA-RAMOFR) OR (WCOB00-RAMO(WS-COB00) EQUAL ZEROS) */

                if ((TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == V0COBA_RAMOFR) || (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00))
                {


                    /*" -4462- ADD 1 TO WCOB00-QTDE(WS-COB00) */
                    TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE.Value = TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE + 1;

                    /*" -4464- MOVE V0COBA-RAMOFR TO WCOB00-RAMO(WS-COB00) */
                    _.Move(V0COBA_RAMOFR, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO);

                    /*" -4466- MOVE ZEROS TO WCOB00-COBE(WS-COB00) */
                    _.Move(0, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE);

                    /*" -4468- MOVE V0COBA-IMP-SEG-IX TO WCOB00-IMPSEG(WS-COB00) */
                    _.Move(V0COBA_IMP_SEG_IX, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG);

                    /*" -4470- ADD V0COBA-PRM-TAR-IX TO WCOB00-PRMTAR(WS-COB00) */
                    TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value = TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR + V0COBA_PRM_TAR_IX;

                    /*" -4470- END-SEARCH. */
                    break;
                }
            }


            /*" -4474- IF V0COBA-COD-COBER EQUAL 01 */

            if (V0COBA_COD_COBER == 01)
            {

                /*" -4475- PERFORM R2201-00-ACUMULA-COBERTURA01 */

                R2201_00_ACUMULA_COBERTURA01_SECTION();

                /*" -4476- ELSE */
            }
            else
            {


                /*" -4477- IF V0COBA-COD-COBER EQUAL 02 */

                if (V0COBA_COD_COBER == 02)
                {

                    /*" -4478- PERFORM R2202-00-ACUMULA-COBERTURA02 */

                    R2202_00_ACUMULA_COBERTURA02_SECTION();

                    /*" -4479- ELSE */
                }
                else
                {


                    /*" -4480- IF V0COBA-COD-COBER EQUAL 05 */

                    if (V0COBA_COD_COBER == 05)
                    {

                        /*" -4481- PERFORM R2205-00-ACUMULA-COBERTURA05 */

                        R2205_00_ACUMULA_COBERTURA05_SECTION();

                        /*" -4482- ELSE */
                    }
                    else
                    {


                        /*" -4483- IF V0COBA-COD-COBER EQUAL 11 */

                        if (V0COBA_COD_COBER == 11)
                        {

                            /*" -4483- PERFORM R2211-00-ACUMULA-COBERTURA11. */

                            R2211_00_ACUMULA_COBERTURA11_SECTION();
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2201-00-ACUMULA-COBERTURA01-SECTION */
        private void R2201_00_ACUMULA_COBERTURA01_SECTION()
        {
            /*" -4499- MOVE '2201' TO WNR-EXEC-SQL. */
            _.Move("2201", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4500- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -4501- SEARCH WCOB01-OCORRECOB */
            for (; WS_COB01 < TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB.Items.Count; WS_COB01.Value++)
            {

                /*" -4505- WHEN (WCOB01-RAMO(WS-COB01) EQUAL V0COBA-RAMOFR) OR (WCOB01-RAMO(WS-COB01) EQUAL ZEROS) */

                if ((TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == V0COBA_RAMOFR) || (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == 00))
                {


                    /*" -4507- MOVE V0COBA-RAMOFR TO WCOB01-RAMO(WS-COB01) */
                    _.Move(V0COBA_RAMOFR, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO);

                    /*" -4509- MOVE V0COBA-COD-COBER TO WCOB01-COBE(WS-COB01) */
                    _.Move(V0COBA_COD_COBER, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE);

                    /*" -4511- MOVE V0COBA-IMP-SEG-IX TO WCOB01-IMPSEG(WS-COB01) */
                    _.Move(V0COBA_IMP_SEG_IX, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG);

                    /*" -4513- ADD V0COBA-PRM-TAR-IX TO WCOB01-PRMTAR(WS-COB01) */
                    TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR.Value = TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR + V0COBA_PRM_TAR_IX;

                    /*" -4513- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2201_99_SAIDA*/

        [StopWatch]
        /*" R2202-00-ACUMULA-COBERTURA02-SECTION */
        private void R2202_00_ACUMULA_COBERTURA02_SECTION()
        {
            /*" -4528- MOVE '2202' TO WNR-EXEC-SQL. */
            _.Move("2202", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4529- SET WS-COB02 TO 1. */
            WS_COB02.Value = 1;

            /*" -4530- SEARCH WCOB02-OCORRECOB */
            for (; WS_COB02 < TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB.Items.Count; WS_COB02.Value++)
            {

                /*" -4534- WHEN (WCOB02-RAMO(WS-COB02) EQUAL V0COBA-RAMOFR) OR (WCOB02-RAMO(WS-COB02) EQUAL ZEROS) */

                if ((TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO == V0COBA_RAMOFR) || (TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO == 00))
                {


                    /*" -4536- MOVE V0COBA-RAMOFR TO WCOB02-RAMO(WS-COB02) */
                    _.Move(V0COBA_RAMOFR, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO);

                    /*" -4538- MOVE V0COBA-COD-COBER TO WCOB02-COBE(WS-COB02) */
                    _.Move(V0COBA_COD_COBER, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_COBE);

                    /*" -4540- MOVE V0COBA-IMP-SEG-IX TO WCOB02-IMPSEG(WS-COB02) */
                    _.Move(V0COBA_IMP_SEG_IX, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_IMPSEG);

                    /*" -4542- ADD V0COBA-PRM-TAR-IX TO WCOB02-PRMTAR(WS-COB02) */
                    TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PRMTAR.Value = TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PRMTAR + V0COBA_PRM_TAR_IX;

                    /*" -4542- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2202_99_SAIDA*/

        [StopWatch]
        /*" R2205-00-ACUMULA-COBERTURA05-SECTION */
        private void R2205_00_ACUMULA_COBERTURA05_SECTION()
        {
            /*" -4556- MOVE '2205' TO WNR-EXEC-SQL. */
            _.Move("2205", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4557- SET WS-COB05 TO 1. */
            WS_COB05.Value = 1;

            /*" -4558- SEARCH WCOB05-OCORRECOB */
            for (; WS_COB05 < TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB.Items.Count; WS_COB05.Value++)
            {

                /*" -4562- WHEN (WCOB05-RAMO(WS-COB05) EQUAL V0COBA-RAMOFR) OR (WCOB05-RAMO(WS-COB05) EQUAL ZEROS) */

                if ((TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO == V0COBA_RAMOFR) || (TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO == 00))
                {


                    /*" -4564- MOVE V0COBA-RAMOFR TO WCOB05-RAMO(WS-COB05) */
                    _.Move(V0COBA_RAMOFR, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO);

                    /*" -4566- MOVE V0COBA-COD-COBER TO WCOB05-COBE(WS-COB05) */
                    _.Move(V0COBA_COD_COBER, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_COBE);

                    /*" -4568- MOVE V0COBA-IMP-SEG-IX TO WCOB05-IMPSEG(WS-COB05) */
                    _.Move(V0COBA_IMP_SEG_IX, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_IMPSEG);

                    /*" -4570- ADD V0COBA-PRM-TAR-IX TO WCOB05-PRMTAR(WS-COB05) */
                    TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PRMTAR.Value = TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PRMTAR + V0COBA_PRM_TAR_IX;

                    /*" -4570- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2205_99_SAIDA*/

        [StopWatch]
        /*" R2211-00-ACUMULA-COBERTURA11-SECTION */
        private void R2211_00_ACUMULA_COBERTURA11_SECTION()
        {
            /*" -4585- MOVE '2211' TO WNR-EXEC-SQL. */
            _.Move("2211", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4586- SET WS-COB11 TO 1. */
            WS_COB11.Value = 1;

            /*" -4587- SEARCH WCOB11-OCORRECOB */
            for (; WS_COB11 < TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB.Items.Count; WS_COB11.Value++)
            {

                /*" -4591- WHEN (WCOB11-RAMO(WS-COB11) EQUAL V0COBA-RAMOFR) OR (WCOB11-RAMO(WS-COB11) EQUAL ZEROS) */

                if ((TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO == V0COBA_RAMOFR) || (TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO == 00))
                {


                    /*" -4593- MOVE V0COBA-RAMOFR TO WCOB11-RAMO(WS-COB11) */
                    _.Move(V0COBA_RAMOFR, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO);

                    /*" -4595- MOVE V0COBA-COD-COBER TO WCOB11-COBE(WS-COB11) */
                    _.Move(V0COBA_COD_COBER, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_COBE);

                    /*" -4597- MOVE V0COBA-IMP-SEG-IX TO WCOB11-IMPSEG(WS-COB11) */
                    _.Move(V0COBA_IMP_SEG_IX, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_IMPSEG);

                    /*" -4599- ADD V0COBA-PRM-TAR-IX TO WCOB11-PRMTAR(WS-COB11) */
                    TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR.Value = TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR + V0COBA_PRM_TAR_IX;

                    /*" -4599- END-SEARCH. */
                    break;
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2211_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-AJUSTA-COBERTURA-SECTION */
        private void R2500_00_AJUSTA_COBERTURA_SECTION()
        {
            /*" -4611- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4612- IF WSHOST-PRM-TAR-IX NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSHOST_PRM_TAR_IX != 00)
            {

                /*" -4613- IF V0ENDO-RAMO EQUAL 82 */

                if (V0ENDO_RAMO == 82)
                {

                    /*" -4614- SET WS-COB00 TO 1 */
                    WS_COB00.Value = 1;

                    /*" -4615- PERFORM R2510-00-AJUSTA-PRMCOB00 10 TIMES */

                    for (int i = 0; i < 10; i++)
                    {

                        R2510_00_AJUSTA_PRMCOB00_SECTION();

                    }

                    /*" -4616- SET WS-COB01 TO 1 */
                    WS_COB01.Value = 1;

                    /*" -4617- PERFORM R2520-00-AJUSTA-PRMCOB01 10 TIMES */

                    for (int i = 0; i < 10; i++)
                    {

                        R2520_00_AJUSTA_PRMCOB01_SECTION();

                    }

                    /*" -4618- ELSE */
                }
                else
                {


                    /*" -4619- IF V0ENDO-RAMO EQUAL 93 */

                    if (V0ENDO_RAMO == 93)
                    {

                        /*" -4620- SET WS-COB00 TO 1 */
                        WS_COB00.Value = 1;

                        /*" -4621- PERFORM R2510-00-AJUSTA-PRMCOB00 10 TIMES */

                        for (int i = 0; i < 10; i++)
                        {

                            R2510_00_AJUSTA_PRMCOB00_SECTION();

                        }

                        /*" -4622- SET WS-COB11 TO 1 */
                        WS_COB11.Value = 1;

                        /*" -4625- PERFORM R2530-00-AJUSTA-PRMCOB11 10 TIMES. */

                        for (int i = 0; i < 10; i++)
                        {

                            R2530_00_AJUSTA_PRMCOB11_SECTION();

                        }
                    }

                }

            }


            /*" -4626- SET WS-COB00 TO 10. */
            WS_COB00.Value = 10;

            /*" -4628- MOVE 100 TO WS-PERTOT. */
            _.Move(100, AREA_DE_WORK.WS_PERTOT);

            /*" -4631- PERFORM R2600-00-AJUSTA-PERCEN00 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2600_00_AJUSTA_PERCEN00_SECTION();

            }

            /*" -4633- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -4636- PERFORM R2700-00-AJUSTA-OUTROS 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2700_00_AJUSTA_OUTROS_SECTION();

            }

            /*" -4636- PERFORM R3000-00-INSERT-COBERTURAS. */

            R3000_00_INSERT_COBERTURAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2510-00-AJUSTA-PRMCOB00-SECTION */
        private void R2510_00_AJUSTA_PRMCOB00_SECTION()
        {
            /*" -4649- MOVE '2510' TO WNR-EXEC-SQL. */
            _.Move("2510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4650- IF WCOB00-RAMO(WS-COB00) EQUAL V0ENDO-RAMO */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == V0ENDO_RAMO)
            {

                /*" -4654- ADD WSHOST-PRM-TAR-IX TO WCOB00-PRMTAR(WS-COB00). */
                TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value = TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR + AREA_DE_WORK.WSHOST_PRM_TAR_IX;
            }


            /*" -4654- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2510_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-AJUSTA-PRMCOB01-SECTION */
        private void R2520_00_AJUSTA_PRMCOB01_SECTION()
        {
            /*" -4667- MOVE '2520' TO WNR-EXEC-SQL. */
            _.Move("2520", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4668- IF WCOB01-RAMO(WS-COB01) EQUAL V0ENDO-RAMO */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == V0ENDO_RAMO)
            {

                /*" -4672- ADD WSHOST-PRM-TAR-IX TO WCOB01-PRMTAR(WS-COB01). */
                TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR.Value = TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR + AREA_DE_WORK.WSHOST_PRM_TAR_IX;
            }


            /*" -4672- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R2530-00-AJUSTA-PRMCOB11-SECTION */
        private void R2530_00_AJUSTA_PRMCOB11_SECTION()
        {
            /*" -4685- MOVE '2530' TO WNR-EXEC-SQL. */
            _.Move("2530", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4686- IF WCOB11-RAMO(WS-COB11) EQUAL V0ENDO-RAMO */

            if (TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO == V0ENDO_RAMO)
            {

                /*" -4690- ADD WSHOST-PRM-TAR-IX TO WCOB11-PRMTAR(WS-COB11). */
                TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR.Value = TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR + AREA_DE_WORK.WSHOST_PRM_TAR_IX;
            }


            /*" -4690- SET WS-COB11 UP BY 1. */
            WS_COB11.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2530_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-AJUSTA-PERCEN00-SECTION */
        private void R2600_00_AJUSTA_PERCEN00_SECTION()
        {
            /*" -4703- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4706- SET AC-IND TO WS-COB00. */
            AREA_DE_WORK.AC_IND.Value = WS_COB00;

            /*" -4707- IF WCOB00-RAMO(WS-COB00) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00)
            {

                /*" -4708- SET WS-COB00 DOWN BY 1 */
                WS_COB00.Value -= 1;

                /*" -4711- GO TO R2600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4712- IF AC-IND EQUAL 1 */

            if (AREA_DE_WORK.AC_IND == 1)
            {

                /*" -4714- MOVE WS-PERTOT TO WCOB00-PERCEN(WS-COB00) */
                _.Move(AREA_DE_WORK.WS_PERTOT, TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN);

                /*" -4717- GO TO R2600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4721- COMPUTE WCOB00-PERCEN(WS-COB00) EQUAL ((WCOB00-PRMTAR(WS-COB00) * 100) / V0PARC-PRM-TAR-IX). */
            TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN.Value = ((TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value * 100) / V0PARC_PRM_TAR_IX);

            /*" -4725- SUBTRACT WCOB00-PERCEN(WS-COB00) FROM WS-PERTOT. */
            AREA_DE_WORK.WS_PERTOT.Value = AREA_DE_WORK.WS_PERTOT - TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN;

            /*" -4725- SET WS-COB00 DOWN BY 1. */
            WS_COB00.Value -= 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-AJUSTA-OUTROS-SECTION */
        private void R2700_00_AJUSTA_OUTROS_SECTION()
        {
            /*" -4738- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4739- MOVE 100 TO WS-PERTOT. */
            _.Move(100, AREA_DE_WORK.WS_PERTOT);

            /*" -4742- MOVE 1 TO AC-IND. */
            _.Move(1, AREA_DE_WORK.AC_IND);

            /*" -4743- IF WCOB00-RAMO(WS-COB00) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00)
            {

                /*" -4744- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -4747- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4749- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -4751- PERFORM R2710-00-AJUSTA-COB01 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2710_00_AJUSTA_COB01_SECTION();

            }

            /*" -4752- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4753- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -4756- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4758- SET WS-COB02 TO 1. */
            WS_COB02.Value = 1;

            /*" -4760- PERFORM R2720-00-AJUSTA-COB02 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2720_00_AJUSTA_COB02_SECTION();

            }

            /*" -4761- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4762- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -4765- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4767- SET WS-COB05 TO 1. */
            WS_COB05.Value = 1;

            /*" -4769- PERFORM R2730-00-AJUSTA-COB05 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2730_00_AJUSTA_COB05_SECTION();

            }

            /*" -4770- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4771- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -4774- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4776- SET WS-COB11 TO 1. */
            WS_COB11.Value = 1;

            /*" -4778- PERFORM R2750-00-AJUSTA-COB11 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R2750_00_AJUSTA_COB11_SECTION();

            }

            /*" -4779- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4780- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -4783- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4783- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-AJUSTA-COB01-SECTION */
        private void R2710_00_AJUSTA_COB01_SECTION()
        {
            /*" -4796- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4797- IF WCOB01-RAMO(WS-COB01) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == 00)
            {

                /*" -4798- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -4801- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4803- IF WCOB01-RAMO(WS-COB01) NOT EQUAL WCOB00-RAMO(WS-COB00) */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO != TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO)
            {

                /*" -4804- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -4807- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4808- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4809- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -4812- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4813- IF WCOB00-QTDE(WS-COB00) EQUAL AC-IND */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE == AREA_DE_WORK.AC_IND)
            {

                /*" -4815- MOVE WS-PERTOT TO WCOB01-PERCEN(WS-COB01) */
                _.Move(AREA_DE_WORK.WS_PERTOT, TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN);

                /*" -4816- MOVE ZEROS TO WS-PERTOT */
                _.Move(0, AREA_DE_WORK.WS_PERTOT);

                /*" -4817- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -4820- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4824- COMPUTE WCOB01-PERCEN(WS-COB01) EQUAL ((WCOB01-PRMTAR(WS-COB01) * 100) / WCOB00-PRMTAR(WS-COB00)). */
            TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN.Value = ((TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR.Value * 100) / TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value);

            /*" -4827- SUBTRACT WCOB01-PERCEN(WS-COB01) FROM WS-PERTOT. */
            AREA_DE_WORK.WS_PERTOT.Value = AREA_DE_WORK.WS_PERTOT - TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN;

            /*" -4830- ADD 1 TO AC-IND. */
            AREA_DE_WORK.AC_IND.Value = AREA_DE_WORK.AC_IND + 1;

            /*" -4830- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2720-00-AJUSTA-COB02-SECTION */
        private void R2720_00_AJUSTA_COB02_SECTION()
        {
            /*" -4843- MOVE '2720' TO WNR-EXEC-SQL. */
            _.Move("2720", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4844- IF WCOB02-RAMO(WS-COB02) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO == 00)
            {

                /*" -4845- SET WS-COB02 UP BY 1 */
                WS_COB02.Value += 1;

                /*" -4848- GO TO R2720-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4850- IF WCOB02-RAMO(WS-COB02) NOT EQUAL WCOB00-RAMO(WS-COB00) */

            if (TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO != TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO)
            {

                /*" -4851- SET WS-COB02 UP BY 1 */
                WS_COB02.Value += 1;

                /*" -4854- GO TO R2720-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4855- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4856- SET WS-COB02 UP BY 1 */
                WS_COB02.Value += 1;

                /*" -4859- GO TO R2720-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4860- IF WCOB00-QTDE(WS-COB00) EQUAL AC-IND */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE == AREA_DE_WORK.AC_IND)
            {

                /*" -4862- MOVE WS-PERTOT TO WCOB02-PERCEN(WS-COB02) */
                _.Move(AREA_DE_WORK.WS_PERTOT, TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PERCEN);

                /*" -4863- MOVE ZEROS TO WS-PERTOT */
                _.Move(0, AREA_DE_WORK.WS_PERTOT);

                /*" -4864- SET WS-COB02 UP BY 1 */
                WS_COB02.Value += 1;

                /*" -4867- GO TO R2720-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4871- COMPUTE WCOB02-PERCEN(WS-COB02) EQUAL ((WCOB02-PRMTAR(WS-COB02) * 100) / WCOB00-PRMTAR(WS-COB00)). */
            TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PERCEN.Value = ((TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PRMTAR.Value * 100) / TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value);

            /*" -4874- SUBTRACT WCOB02-PERCEN(WS-COB02) FROM WS-PERTOT. */
            AREA_DE_WORK.WS_PERTOT.Value = AREA_DE_WORK.WS_PERTOT - TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PERCEN;

            /*" -4877- ADD 1 TO AC-IND. */
            AREA_DE_WORK.AC_IND.Value = AREA_DE_WORK.AC_IND + 1;

            /*" -4877- SET WS-COB02 UP BY 1. */
            WS_COB02.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2720_99_SAIDA*/

        [StopWatch]
        /*" R2730-00-AJUSTA-COB05-SECTION */
        private void R2730_00_AJUSTA_COB05_SECTION()
        {
            /*" -4890- MOVE '2730' TO WNR-EXEC-SQL. */
            _.Move("2730", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4891- IF WCOB05-RAMO(WS-COB05) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO == 00)
            {

                /*" -4892- SET WS-COB05 UP BY 1 */
                WS_COB05.Value += 1;

                /*" -4895- GO TO R2730-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2730_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4897- IF WCOB05-RAMO(WS-COB05) NOT EQUAL WCOB00-RAMO(WS-COB00) */

            if (TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO != TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO)
            {

                /*" -4898- SET WS-COB05 UP BY 1 */
                WS_COB05.Value += 1;

                /*" -4901- GO TO R2730-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2730_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4902- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4903- SET WS-COB05 UP BY 1 */
                WS_COB05.Value += 1;

                /*" -4906- GO TO R2730-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2730_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4907- IF WCOB00-QTDE(WS-COB00) EQUAL AC-IND */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE == AREA_DE_WORK.AC_IND)
            {

                /*" -4909- MOVE WS-PERTOT TO WCOB05-PERCEN(WS-COB05) */
                _.Move(AREA_DE_WORK.WS_PERTOT, TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PERCEN);

                /*" -4910- MOVE ZEROS TO WS-PERTOT */
                _.Move(0, AREA_DE_WORK.WS_PERTOT);

                /*" -4911- SET WS-COB05 UP BY 1 */
                WS_COB05.Value += 1;

                /*" -4914- GO TO R2730-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2730_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4918- COMPUTE WCOB05-PERCEN(WS-COB05) EQUAL ((WCOB05-PRMTAR(WS-COB05) * 100) / WCOB00-PRMTAR(WS-COB00)). */
            TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PERCEN.Value = ((TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PRMTAR.Value * 100) / TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value);

            /*" -4921- SUBTRACT WCOB05-PERCEN(WS-COB05) FROM WS-PERTOT. */
            AREA_DE_WORK.WS_PERTOT.Value = AREA_DE_WORK.WS_PERTOT - TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PERCEN;

            /*" -4924- ADD 1 TO AC-IND. */
            AREA_DE_WORK.AC_IND.Value = AREA_DE_WORK.AC_IND + 1;

            /*" -4924- SET WS-COB05 UP BY 1. */
            WS_COB05.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2730_99_SAIDA*/

        [StopWatch]
        /*" R2750-00-AJUSTA-COB11-SECTION */
        private void R2750_00_AJUSTA_COB11_SECTION()
        {
            /*" -4937- MOVE '2750' TO WNR-EXEC-SQL. */
            _.Move("2750", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4938- IF WCOB11-RAMO(WS-COB11) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO == 00)
            {

                /*" -4939- SET WS-COB11 UP BY 1 */
                WS_COB11.Value += 1;

                /*" -4942- GO TO R2750-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4944- IF WCOB11-RAMO(WS-COB11) NOT EQUAL WCOB00-RAMO(WS-COB00) */

            if (TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO != TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO)
            {

                /*" -4945- SET WS-COB11 UP BY 1 */
                WS_COB11.Value += 1;

                /*" -4948- GO TO R2750-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4949- IF WS-PERTOT EQUAL ZEROS */

            if (AREA_DE_WORK.WS_PERTOT == 00)
            {

                /*" -4950- SET WS-COB11 UP BY 1 */
                WS_COB11.Value += 1;

                /*" -4953- GO TO R2750-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4954- IF WCOB00-QTDE(WS-COB00) EQUAL AC-IND */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_QTDE == AREA_DE_WORK.AC_IND)
            {

                /*" -4956- MOVE WS-PERTOT TO WCOB11-PERCEN(WS-COB11) */
                _.Move(AREA_DE_WORK.WS_PERTOT, TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PERCEN);

                /*" -4957- MOVE ZEROS TO WS-PERTOT */
                _.Move(0, AREA_DE_WORK.WS_PERTOT);

                /*" -4958- SET WS-COB11 UP BY 1 */
                WS_COB11.Value += 1;

                /*" -4961- GO TO R2750-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4965- COMPUTE WCOB11-PERCEN(WS-COB11) EQUAL ((WCOB11-PRMTAR(WS-COB11) * 100) / WCOB00-PRMTAR(WS-COB00)). */
            TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PERCEN.Value = ((TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR.Value * 100) / TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR.Value);

            /*" -4968- SUBTRACT WCOB11-PERCEN(WS-COB11) FROM WS-PERTOT. */
            AREA_DE_WORK.WS_PERTOT.Value = AREA_DE_WORK.WS_PERTOT - TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PERCEN;

            /*" -4971- ADD 1 TO AC-IND. */
            AREA_DE_WORK.AC_IND.Value = AREA_DE_WORK.AC_IND + 1;

            /*" -4971- SET WS-COB11 UP BY 1. */
            WS_COB11.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2750_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-INSERT-COBERTURAS-SECTION */
        private void R3000_00_INSERT_COBERTURAS_SECTION()
        {
            /*" -4984- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -4986- SET WS-COB00 TO 1. */
            WS_COB00.Value = 1;

            /*" -4989- PERFORM R3010-00-INSERT-COB00 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3010_00_INSERT_COB00_SECTION();

            }

            /*" -4991- SET WS-COB01 TO 1. */
            WS_COB01.Value = 1;

            /*" -4994- PERFORM R3020-00-INSERT-COB01 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3020_00_INSERT_COB01_SECTION();

            }

            /*" -4996- SET WS-COB02 TO 1. */
            WS_COB02.Value = 1;

            /*" -4999- PERFORM R3030-00-INSERT-COB02 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3030_00_INSERT_COB02_SECTION();

            }

            /*" -5001- SET WS-COB05 TO 1. */
            WS_COB05.Value = 1;

            /*" -5004- PERFORM R3040-00-INSERT-COB05 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3040_00_INSERT_COB05_SECTION();

            }

            /*" -5006- SET WS-COB11 TO 1. */
            WS_COB11.Value = 1;

            /*" -5006- PERFORM R3050-00-INSERT-COB11 10 TIMES. */

            for (int i = 0; i < 10; i++)
            {

                R3050_00_INSERT_COB11_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-INSERT-COB00-SECTION */
        private void R3010_00_INSERT_COB00_SECTION()
        {
            /*" -5019- MOVE '3010' TO WNR-EXEC-SQL. */
            _.Move("3010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5020- IF WCOB00-RAMO(WS-COB00) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO == 00)
            {

                /*" -5021- SET WS-COB00 UP BY 1 */
                WS_COB00.Value += 1;

                /*" -5024- GO TO R3010-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5026- MOVE WCOB00-RAMO(WS-COB00) TO V0COBA-RAMOFR. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_RAMO, V0COBA_RAMOFR);

            /*" -5028- MOVE WCOB00-COBE(WS-COB00) TO V0COBA-COD-COBER. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_COBE, V0COBA_COD_COBER);

            /*" -5031- MOVE WCOB00-IMPSEG(WS-COB00) TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_IMPSEG, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -5034- MOVE WCOB00-PRMTAR(WS-COB00) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PRMTAR, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -5038- MOVE WCOB00-PERCEN(WS-COB00) TO V0COBA-PCT-COBERT. */
            _.Move(TABELA_COBERTURA.WCOB00_COBE00.WCOB00_OCORRECOB[WS_COB00].WCOB00_PERCEN, V0COBA_PCT_COBERT);

            /*" -5041- PERFORM R1600-00-INSERT-V0COBERAPOL. */

            R1600_00_INSERT_V0COBERAPOL_SECTION();

            /*" -5041- SET WS-COB00 UP BY 1. */
            WS_COB00.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R3020-00-INSERT-COB01-SECTION */
        private void R3020_00_INSERT_COB01_SECTION()
        {
            /*" -5054- MOVE '3020' TO WNR-EXEC-SQL. */
            _.Move("3020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5055- IF WCOB01-RAMO(WS-COB01) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO == 00)
            {

                /*" -5056- SET WS-COB01 UP BY 1 */
                WS_COB01.Value += 1;

                /*" -5059- GO TO R3020-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5061- MOVE WCOB01-RAMO(WS-COB01) TO V0COBA-RAMOFR. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_RAMO, V0COBA_RAMOFR);

            /*" -5063- MOVE WCOB01-COBE(WS-COB01) TO V0COBA-COD-COBER. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_COBE, V0COBA_COD_COBER);

            /*" -5066- MOVE WCOB01-IMPSEG(WS-COB01) TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_IMPSEG, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -5069- MOVE WCOB01-PRMTAR(WS-COB01) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PRMTAR, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -5073- MOVE WCOB01-PERCEN(WS-COB01) TO V0COBA-PCT-COBERT. */
            _.Move(TABELA_COBERTURA.WCOB01_COBE01.WCOB01_OCORRECOB[WS_COB01].WCOB01_PERCEN, V0COBA_PCT_COBERT);

            /*" -5076- PERFORM R1600-00-INSERT-V0COBERAPOL. */

            R1600_00_INSERT_V0COBERAPOL_SECTION();

            /*" -5076- SET WS-COB01 UP BY 1. */
            WS_COB01.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3020_99_SAIDA*/

        [StopWatch]
        /*" R3030-00-INSERT-COB02-SECTION */
        private void R3030_00_INSERT_COB02_SECTION()
        {
            /*" -5089- MOVE '3030' TO WNR-EXEC-SQL. */
            _.Move("3030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5090- IF WCOB02-RAMO(WS-COB02) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_RAMO == 00)
            {

                /*" -5091- SET WS-COB02 UP BY 1 */
                WS_COB02.Value += 1;

                /*" -5094- GO TO R3030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5096- MOVE WCOB02-RAMO(WS-COB05) TO V0COBA-RAMOFR. */
            _.Move(TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB05].WCOB02_RAMO, V0COBA_RAMOFR);

            /*" -5098- MOVE WCOB02-COBE(WS-COB02) TO V0COBA-COD-COBER. */
            _.Move(TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_COBE, V0COBA_COD_COBER);

            /*" -5101- MOVE WCOB02-IMPSEG(WS-COB02) TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR. */
            _.Move(TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_IMPSEG, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -5104- MOVE WCOB02-PRMTAR(WS-COB02) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR. */
            _.Move(TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PRMTAR, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -5108- MOVE WCOB02-PERCEN(WS-COB02) TO V0COBA-PCT-COBERT. */
            _.Move(TABELA_COBERTURA.WCOB02_COBE02.WCOB02_OCORRECOB[WS_COB02].WCOB02_PERCEN, V0COBA_PCT_COBERT);

            /*" -5111- PERFORM R1600-00-INSERT-V0COBERAPOL. */

            R1600_00_INSERT_V0COBERAPOL_SECTION();

            /*" -5111- SET WS-COB02 UP BY 1. */
            WS_COB02.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3030_99_SAIDA*/

        [StopWatch]
        /*" R3040-00-INSERT-COB05-SECTION */
        private void R3040_00_INSERT_COB05_SECTION()
        {
            /*" -5124- MOVE '3040' TO WNR-EXEC-SQL. */
            _.Move("3040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5125- IF WCOB05-RAMO(WS-COB05) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO == 00)
            {

                /*" -5126- SET WS-COB05 UP BY 1 */
                WS_COB05.Value += 1;

                /*" -5129- GO TO R3040-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5131- MOVE WCOB05-RAMO(WS-COB05) TO V0COBA-RAMOFR. */
            _.Move(TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_RAMO, V0COBA_RAMOFR);

            /*" -5133- MOVE WCOB05-COBE(WS-COB05) TO V0COBA-COD-COBER. */
            _.Move(TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_COBE, V0COBA_COD_COBER);

            /*" -5136- MOVE WCOB05-IMPSEG(WS-COB05) TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR. */
            _.Move(TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_IMPSEG, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -5139- MOVE WCOB05-PRMTAR(WS-COB05) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR. */
            _.Move(TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PRMTAR, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -5143- MOVE WCOB05-PERCEN(WS-COB05) TO V0COBA-PCT-COBERT. */
            _.Move(TABELA_COBERTURA.WCOB05_COBE05.WCOB05_OCORRECOB[WS_COB05].WCOB05_PERCEN, V0COBA_PCT_COBERT);

            /*" -5146- PERFORM R1600-00-INSERT-V0COBERAPOL. */

            R1600_00_INSERT_V0COBERAPOL_SECTION();

            /*" -5146- SET WS-COB05 UP BY 1. */
            WS_COB05.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3040_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-INSERT-COB11-SECTION */
        private void R3050_00_INSERT_COB11_SECTION()
        {
            /*" -5159- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -5160- IF WCOB11-RAMO(WS-COB11) EQUAL ZEROS */

            if (TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO == 00)
            {

                /*" -5161- SET WS-COB11 UP BY 1 */
                WS_COB11.Value += 1;

                /*" -5164- GO TO R3050-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5166- MOVE WCOB11-RAMO(WS-COB11) TO V0COBA-RAMOFR. */
            _.Move(TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_RAMO, V0COBA_RAMOFR);

            /*" -5168- MOVE WCOB11-COBE(WS-COB11) TO V0COBA-COD-COBER. */
            _.Move(TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_COBE, V0COBA_COD_COBER);

            /*" -5171- MOVE WCOB11-IMPSEG(WS-COB11) TO V0COBA-IMP-SEG-IX V0COBA-IMP-SEG-VR. */
            _.Move(TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_IMPSEG, V0COBA_IMP_SEG_IX, V0COBA_IMP_SEG_VR);

            /*" -5174- MOVE WCOB11-PRMTAR(WS-COB11) TO V0COBA-PRM-TAR-IX V0COBA-PRM-TAR-VR. */
            _.Move(TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PRMTAR, V0COBA_PRM_TAR_IX, V0COBA_PRM_TAR_VR);

            /*" -5178- MOVE WCOB11-PERCEN(WS-COB11) TO V0COBA-PCT-COBERT. */
            _.Move(TABELA_COBERTURA.WCOB11_COBE11.WCOB11_OCORRECOB[WS_COB11].WCOB11_PERCEN, V0COBA_PCT_COBERT);

            /*" -5181- PERFORM R1600-00-INSERT-V0COBERAPOL. */

            R1600_00_INSERT_V0COBERAPOL_SECTION();

            /*" -5181- SET WS-COB11 UP BY 1. */
            WS_COB11.Value += 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TOTAIS-CONTROLE-SECTION */
        private void R4000_00_TOTAIS_CONTROLE_SECTION()
        {
            /*" -5200- MOVE V1SIST-DTCURRENT TO WS-DATE. */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WS_DATE);

            /*" -5201- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -5202- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -5204- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.WS_DATE.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -5205- DISPLAY ' ' */
            _.Display($" ");

            /*" -5206- DISPLAY '---------------------------------------------' */
            _.Display($"---------------------------------------------");

            /*" -5207- DISPLAY 'LIDOS  V0HISTCONTABILVA  ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS  V0HISTCONTABILVA  {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -5208- DISPLAY 'DESPREZA OPERACAO        ' DP-OPERACAO. */
            _.Display($"DESPREZA OPERACAO        {AREA_DE_WORK.DP_OPERACAO}");

            /*" -5209- DISPLAY 'DESPREZA VALOR           ' DP-VALOR. */
            _.Display($"DESPREZA VALOR           {AREA_DE_WORK.DP_VALOR}");

            /*" -5210- DISPLAY 'RELEASE GRAVADOS........ ' WS-CNT-RELEASE */
            _.Display($"RELEASE GRAVADOS........ {WS_CNT_RELEASE}");

            /*" -5211- DISPLAY ' ' */
            _.Display($" ");

            /*" -5212- DISPLAY 'LIDOS SORT ............. ' AC-L-SORT */
            _.Display($"LIDOS SORT ............. {AREA_DE_WORK.AC_L_SORT}");

            /*" -5213- DISPLAY 'DESPREZA EMISSAO         ' DP-EMISSAO. */
            _.Display($"DESPREZA EMISSAO         {AREA_DE_WORK.DP_EMISSAO}");

            /*" -5214- DISPLAY 'ARQUIVO INCONSISTENCIAS  ' GV-ARQSAI1. */
            _.Display($"ARQUIVO INCONSISTENCIAS  {AREA_DE_WORK.GV_ARQSAI1}");

            /*" -5215- DISPLAY ' ' */
            _.Display($" ");

            /*" -5216- DISPLAY 'INSERT V0ENDOSSO          ' AC-I-V0ENDOSSO. */
            _.Display($"INSERT V0ENDOSSO          {AREA_DE_WORK.AC_I_V0ENDOSSO}");

            /*" -5217- DISPLAY 'INSERT V0RCAPCOMP         ' AC-I-V0RCAPCOMP. */
            _.Display($"INSERT V0RCAPCOMP         {AREA_DE_WORK.AC_I_V0RCAPCOMP}");

            /*" -5218- DISPLAY 'INSERT V0ORDECOSCED       ' AC-I-V0ORDECOSCED. */
            _.Display($"INSERT V0ORDECOSCED       {AREA_DE_WORK.AC_I_V0ORDECOSCED}");

            /*" -5219- DISPLAY 'INSERT V0EMISDIARIA       ' AC-I-V0EMISDIARIA. */
            _.Display($"INSERT V0EMISDIARIA       {AREA_DE_WORK.AC_I_V0EMISDIARIA}");

            /*" -5220- DISPLAY 'INSERT V0PARCELA          ' AC-I-V0PARCELA. */
            _.Display($"INSERT V0PARCELA          {AREA_DE_WORK.AC_I_V0PARCELA}");

            /*" -5221- DISPLAY 'INSERT V0HISTOPARC        ' AC-I-V0HISTOPARC. */
            _.Display($"INSERT V0HISTOPARC        {AREA_DE_WORK.AC_I_V0HISTOPARC}");

            /*" -5222- DISPLAY 'INSERT V0COBERAPOL        ' AC-I-V0COBERAPOL. */
            _.Display($"INSERT V0COBERAPOL        {AREA_DE_WORK.AC_I_V0COBERAPOL}");

            /*" -5223- DISPLAY 'UPDATE V0COBERAPOL        ' AC-U-V0COBERAPOL. */
            _.Display($"UPDATE V0COBERAPOL        {AREA_DE_WORK.AC_U_V0COBERAPOL}");

            /*" -5224- DISPLAY ' ' */
            _.Display($" ");

            /*" -5225- DISPLAY 'UPDATE V0RCAP             ' AC-U-V0RCAP. */
            _.Display($"UPDATE V0RCAP             {AREA_DE_WORK.AC_U_V0RCAP}");

            /*" -5226- DISPLAY 'UPDATE V0RCAPCOMP         ' AC-U-V0RCAPCOMP. */
            _.Display($"UPDATE V0RCAPCOMP         {AREA_DE_WORK.AC_U_V0RCAPCOMP}");

            /*" -5227- DISPLAY 'UPDATE V0NUMEROAES        ' AC-U-V0NUMERAES. */
            _.Display($"UPDATE V0NUMEROAES        {AREA_DE_WORK.AC_U_V0NUMERAES}");

            /*" -5228- DISPLAY 'UPDATE V0FONTE            ' AC-U-V0FONTE. */
            _.Display($"UPDATE V0FONTE            {AREA_DE_WORK.AC_U_V0FONTE}");

            /*" -5229- DISPLAY 'UPDATE V0HISTCONTABILVA   ' AC-U-V0HISTCONTABILVA. */
            _.Display($"UPDATE V0HISTCONTABILVA   {AREA_DE_WORK.AC_U_V0HISTCONTABILVA}");

            /*" -5231- DISPLAY 'UPDATE V0NUMERO-COSSEGURO ' AC-U-V0NUMERO-COSSEGURO */
            _.Display($"UPDATE V0NUMERO-COSSEGURO {AREA_DE_WORK.AC_U_V0NUMERO_COSSEGURO}");

            /*" -5232- DISPLAY 'APOL.EMP.GLOBAL N/FATURADA' AC-APOLICES-NOK. */
            _.Display($"APOL.EMP.GLOBAL N/FATURADA{AREA_DE_WORK.AC_APOLICES_NOK}");

            /*" -5232- DISPLAY '---------------------------------------------' . */
            _.Display($"---------------------------------------------");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-DISPLAY-REGISTRO-SECTION */
        private void R5000_00_DISPLAY_REGISTRO_SECTION()
        {
            /*" -5244- DISPLAY ' V0HCTB-SITUACAO    ' V0HCTB-SITUACAO. */
            _.Display($" V0HCTB-SITUACAO    {V0HCTB_SITUACAO}");

            /*" -5245- DISPLAY ' V0HCTB-NUM-APOLICE ' V0HCTB-NUM-APOLICE. */
            _.Display($" V0HCTB-NUM-APOLICE {V0HCTB_NUM_APOLICE}");

            /*" -5246- DISPLAY ' V0HCTB-CODSUBES    ' V0HCTB-CODSUBES. */
            _.Display($" V0HCTB-CODSUBES    {V0HCTB_CODSUBES}");

            /*" -5247- DISPLAY ' V0HCTB-FONTE       ' V0HCTB-FONTE. */
            _.Display($" V0HCTB-FONTE       {V0HCTB_FONTE}");

            /*" -5248- DISPLAY ' V0HCTB-PRMVG       ' V0HCTB-PRMVG. */
            _.Display($" V0HCTB-PRMVG       {V0HCTB_PRMVG}");

            /*" -5249- DISPLAY ' V0HCTB-PRMAP       ' V0HCTB-PRMAP. */
            _.Display($" V0HCTB-PRMAP       {V0HCTB_PRMAP}");

            /*" -5250- DISPLAY ' V0HCTB-CODOPER     ' V0HCTB-CODOPER. */
            _.Display($" V0HCTB-CODOPER     {V0HCTB_CODOPER}");

            /*" -5251- DISPLAY ' V0HCTB-NRCERTIF    ' V0HCTB-NRCERTIF. */
            _.Display($" V0HCTB-NRCERTIF    {V0HCTB_NRCERTIF}");

            /*" -5252- DISPLAY ' V0HCTB-NRPARCEL    ' V0HCTB-NRPARCEL. */
            _.Display($" V0HCTB-NRPARCEL    {V0HCTB_NRPARCEL}");

            /*" -5253- DISPLAY ' V0HCTB-NRTIT       ' V0HCTB-NRTIT. */
            _.Display($" V0HCTB-NRTIT       {V0HCTB_NRTIT}");

            /*" -5254- DISPLAY ' V0HCTB-OCORHIST    ' V0HCTB-OCORHIST. */
            _.Display($" V0HCTB-OCORHIST    {V0HCTB_OCORHIST}");

            /*" -5255- DISPLAY ' V0HCTB-DTMOVTO     ' V0HCTB-DTMOVTO. */
            _.Display($" V0HCTB-DTMOVTO     {V0HCTB_DTMOVTO}");

            /*" -5256- DISPLAY ' V0PROP-DTQITBCO    ' V0PROP-DTQITBCO. */
            _.Display($" V0PROP-DTQITBCO    {V0PROP_DTQITBCO}");

            /*" -5257- DISPLAY ' V0PROP-CODCLIEN    ' V0PROP-CODCLIEN. */
            _.Display($" V0PROP-CODCLIEN    {V0PROP_CODCLIEN}");

            /*" -5258- DISPLAY ' V0PRVG-ESTR-COBR   ' V0PRVG-ESTR-COBR. */
            _.Display($" V0PRVG-ESTR-COBR   {V0PRVG_ESTR_COBR}");

            /*" -5259- DISPLAY ' V0PRVG-ORIG-PRODU  ' V0PRVG-ORIG-PRODU. */
            _.Display($" V0PRVG-ORIG-PRODU  {V0PRVG_ORIG_PRODU}");

            /*" -5260- DISPLAY ' V0SUBG-IND-IOF     ' V0SUBG-IND-IOF. */
            _.Display($" V0SUBG-IND-IOF     {V0SUBG_IND_IOF}");

            /*" -5261- DISPLAY ' V0PROP-OCORHIST    ' V0PROP-OCORHIST. */
            _.Display($" V0PROP-OCORHIST    {V0PROP_OCORHIST}");

            /*" -5262- DISPLAY ' V0PROP-CODPRODU    ' V0PROP-CODPRODU. */
            _.Display($" V0PROP-CODPRODU    {V0PROP_CODPRODU}");

            /*" -5264- DISPLAY ' V0PROP-DTPROXVEN   ' V0PROP-DTPROXVEN. */
            _.Display($" V0PROP-DTPROXVEN   {V0PROP_DTPROXVEN}");

            /*" -5265- DISPLAY ' V0APOL-RAMO          ' V0APOL-RAMO. */
            _.Display($" V0APOL-RAMO          {V0APOL_RAMO}");

            /*" -5266- DISPLAY ' V0APOL-CODPRODU      ' V0APOL-CODPRODU. */
            _.Display($" V0APOL-CODPRODU      {V0APOL_CODPRODU}");

            /*" -5267- DISPLAY ' V0PARC-DTVENCTO      ' V0PARC-DTVENCTO. */
            _.Display($" V0PARC-DTVENCTO      {V0PARC_DTVENCTO}");

            /*" -5268- DISPLAY ' V0HCOB-DTVENCTO      ' V0HCOB-DTVENCTO. */
            _.Display($" V0HCOB-DTVENCTO      {V0HCOB_DTVENCTO}");

            /*" -5269- DISPLAY ' V0COBP-DTINIVIG-ENDO ' V0COBP-DTINIVIG-ENDO. */
            _.Display($" V0COBP-DTINIVIG-ENDO {V0COBP_DTINIVIG_ENDO}");

            /*" -5270- DISPLAY ' V0COBP-DTTERVIG-ENDO ' V0COBP-DTTERVIG-ENDO. */
            _.Display($" V0COBP-DTTERVIG-ENDO {V0COBP_DTTERVIG_ENDO}");

            /*" -5272- DISPLAY ' V0OPCP-PERIPGTO      ' V0OPCP-PERIPGTO. */
            _.Display($" V0OPCP-PERIPGTO      {V0OPCP_PERIPGTO}");

            /*" -5273- DISPLAY ' WHOST-CODSUBES       ' WHOST-CODSUBES. */
            _.Display($" WHOST-CODSUBES       {WHOST_CODSUBES}");

            /*" -5274- DISPLAY ' WHOST-DTTERVIG       ' WHOST-DTTERVIG. */
            _.Display($" WHOST-DTTERVIG       {WHOST_DTTERVIG}");

            /*" -5275- DISPLAY ' WHOST-DTINIVIG       ' WHOST-DTINIVIG. */
            _.Display($" WHOST-DTINIVIG       {WHOST_DTINIVIG}");

            /*" -5277- DISPLAY ' V0ENDO-DTINIVIG      ' V0ENDO-DTINIVIG. */
            _.Display($" V0ENDO-DTINIVIG      {V0ENDO_DTINIVIG}");

            /*" -5278- DISPLAY ' V0PRVG-ORIG-PRODU    ' V0PRVG-ORIG-PRODU. */
            _.Display($" V0PRVG-ORIG-PRODU    {V0PRVG_ORIG_PRODU}");

            /*" -5279- DISPLAY ' V0APOL-RAMO          ' V0APOL-RAMO. */
            _.Display($" V0APOL-RAMO          {V0APOL_RAMO}");

            /*" -5280- DISPLAY ' AC-PRMVG             ' AC-PRMVG. */
            _.Display($" AC-PRMVG             {AREA_DE_WORK.AC_PRMVG}");

            /*" -5282- DISPLAY ' AC-PRMAP             ' AC-PRMAP. */
            _.Display($" AC-PRMAP             {AREA_DE_WORK.AC_PRMAP}");

            /*" -5283- DISPLAY ' AC-IMPMORNATU        ' AC-IMPMORNATU. */
            _.Display($" AC-IMPMORNATU        {AREA_DE_WORK.AC_IMPMORNATU}");

            /*" -5284- DISPLAY ' AC-IMPMORACID        ' AC-IMPMORACID. */
            _.Display($" AC-IMPMORACID        {AREA_DE_WORK.AC_IMPMORACID}");

            /*" -5284- DISPLAY ' AC-IMPINVPERM        ' AC-IMPINVPERM. */
            _.Display($" AC-IMPINVPERM        {AREA_DE_WORK.AC_IMPINVPERM}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-INSERT-RELATORI-SECTION */
        private void R9990_00_INSERT_RELATORI_SECTION()
        {
            /*" -5295- MOVE 'VG0139B' TO V0RELA-CODUSU */
            _.Move("VG0139B", V0RELA_CODUSU);

            /*" -5296- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -5297- MOVE 'VA' TO V0RELA-IDSISTEM */
            _.Move("VA", V0RELA_IDSISTEM);

            /*" -5298- MOVE 'VA0417B' TO V0RELA-CODRELAT */
            _.Move("VA0417B", V0RELA_CODRELAT);

            /*" -5299- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -5300- MOVE ZEROS TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -5301- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -5302- MOVE V1SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V1SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -5303- MOVE V1SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(V1SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -5304- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -5305- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -5306- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -5307- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -5308- MOVE ZEROS TO V0RELA-CODPDT */
            _.Move(0, V0RELA_CODPDT);

            /*" -5309- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -5310- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -5311- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -5312- MOVE ZEROS TO V0RELA-NUM-APOLICE */
            _.Move(0, V0RELA_NUM_APOLICE);

            /*" -5313- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -5314- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -5315- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -5316- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -5317- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -5318- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -5319- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -5320- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -5321- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -5322- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -5323- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -5324- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -5325- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -5326- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -5327- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -5328- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -5329- MOVE '0' TO V0RELA-SITUACAO */
            _.Move("0", V0RELA_SITUACAO);

            /*" -5330- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -5331- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -5332- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -5333- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -5335- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -5378- PERFORM R9990_00_INSERT_RELATORI_DB_INSERT_1 */

            R9990_00_INSERT_RELATORI_DB_INSERT_1();

            /*" -5381- IF SQLCODE EQUAL -803 OR -811 */

            if (DB.SQLCODE.In("-803", "-811"))
            {

                /*" -5382- DISPLAY 'B0300-10 (REGISTRO DUPLICADO) ... ' */
                _.Display($"B0300-10 (REGISTRO DUPLICADO) ... ");

                /*" -5384- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -5385- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5386- DISPLAY 'R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ' */
                _.Display($"R0300-10-(PROBLEMAS NA INSERCAO RELATORIOS ");

                /*" -5386- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R9990-00-INSERT-RELATORI-DB-INSERT-1 */
        public void R9990_00_INSERT_RELATORI_DB_INSERT_1()
        {
            /*" -5378- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1 = new R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1()
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

            R9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1.Execute(r9990_00_INSERT_RELATORI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9990_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -5399- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -5400- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -5401- DISPLAY 'APOLICE     ' V0HCTB-NUM-APOLICE */
            _.Display($"APOLICE     {V0HCTB_NUM_APOLICE}");

            /*" -5402- DISPLAY 'SUBGRUPO    ' V0HCTB-CODSUBES */
            _.Display($"SUBGRUPO    {V0HCTB_CODSUBES}");

            /*" -5403- DISPLAY 'CERTIFICADO ' V0HCTB-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTB_NRCERTIF}");

            /*" -5404- DISPLAY 'LIDOS       ' AC-L-V0HISTCONT. */
            _.Display($"LIDOS       {AREA_DE_WORK.AC_L_V0HISTCONT}");

            /*" -5405- DISPLAY 'VALOR       ' V0CBPR-IMPDIT. */
            _.Display($"VALOR       {V0CBPR_IMPDIT}");

            /*" -5406- DISPLAY V0PROP-CODPRODU */
            _.Display(V0PROP_CODPRODU);

            /*" -5407- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -5408- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -5410- DISPLAY V0CBPR-IMPDIT */
            _.Display(V0CBPR_IMPDIT);

            /*" -5411- DISPLAY V0ENDO-NUM-APOLICE */
            _.Display(V0ENDO_NUM_APOLICE);

            /*" -5412- DISPLAY V0ENDO-NRENDOS */
            _.Display(V0ENDO_NRENDOS);

            /*" -5413- DISPLAY V0ENDO-CODSUBES */
            _.Display(V0ENDO_CODSUBES);

            /*" -5414- DISPLAY V0ENDO-FONTE */
            _.Display(V0ENDO_FONTE);

            /*" -5415- DISPLAY V0ENDO-NRPROPOS */
            _.Display(V0ENDO_NRPROPOS);

            /*" -5416- DISPLAY V0ENDO-DATPRO */
            _.Display(V0ENDO_DATPRO);

            /*" -5417- DISPLAY V0ENDO-DT-LIBER */
            _.Display(V0ENDO_DT_LIBER);

            /*" -5418- DISPLAY V0ENDO-DTEMIS */
            _.Display(V0ENDO_DTEMIS);

            /*" -5419- DISPLAY V0ENDO-NRRCAP */
            _.Display(V0ENDO_NRRCAP);

            /*" -5420- DISPLAY V0ENDO-VLRCAP */
            _.Display(V0ENDO_VLRCAP);

            /*" -5421- DISPLAY V0ENDO-BCORCAP */
            _.Display(V0ENDO_BCORCAP);

            /*" -5422- DISPLAY V0ENDO-AGERCAP */
            _.Display(V0ENDO_AGERCAP);

            /*" -5423- DISPLAY V0ENDO-DACRCAP */
            _.Display(V0ENDO_DACRCAP);

            /*" -5424- DISPLAY V0ENDO-IDRCAP */
            _.Display(V0ENDO_IDRCAP);

            /*" -5425- DISPLAY V0ENDO-BCOCOBR */
            _.Display(V0ENDO_BCOCOBR);

            /*" -5426- DISPLAY V0ENDO-AGECOBR */
            _.Display(V0ENDO_AGECOBR);

            /*" -5427- DISPLAY V0ENDO-DACCOBR */
            _.Display(V0ENDO_DACCOBR);

            /*" -5428- DISPLAY V0ENDO-DTINIVIG */
            _.Display(V0ENDO_DTINIVIG);

            /*" -5429- DISPLAY V0ENDO-DTTERVIG */
            _.Display(V0ENDO_DTTERVIG);

            /*" -5430- DISPLAY V0ENDO-CDFRACIO */
            _.Display(V0ENDO_CDFRACIO);

            /*" -5431- DISPLAY V0ENDO-PCENTRAD */
            _.Display(V0ENDO_PCENTRAD);

            /*" -5432- DISPLAY V0ENDO-PCADICIO */
            _.Display(V0ENDO_PCADICIO);

            /*" -5433- DISPLAY V0ENDO-PRESTA1 */
            _.Display(V0ENDO_PRESTA1);

            /*" -5434- DISPLAY V0ENDO-QTPARCEL */
            _.Display(V0ENDO_QTPARCEL);

            /*" -5435- DISPLAY V0ENDO-QTPRESTA */
            _.Display(V0ENDO_QTPRESTA);

            /*" -5436- DISPLAY V0ENDO-QTITENS */
            _.Display(V0ENDO_QTITENS);

            /*" -5437- DISPLAY V0ENDO-CODTXT */
            _.Display(V0ENDO_CODTXT);

            /*" -5438- DISPLAY V0ENDO-CDACEITA */
            _.Display(V0ENDO_CDACEITA);

            /*" -5439- DISPLAY V0ENDO-MOEDA-IMP */
            _.Display(V0ENDO_MOEDA_IMP);

            /*" -5440- DISPLAY V0ENDO-MOEDA-PRM */
            _.Display(V0ENDO_MOEDA_PRM);

            /*" -5441- DISPLAY V0ENDO-TIPO-ENDO */
            _.Display(V0ENDO_TIPO_ENDO);

            /*" -5442- DISPLAY V0ENDO-COD-USUAR */
            _.Display(V0ENDO_COD_USUAR);

            /*" -5443- DISPLAY V0ENDO-OCORR-END */
            _.Display(V0ENDO_OCORR_END);

            /*" -5444- DISPLAY V0ENDO-SITUACAO */
            _.Display(V0ENDO_SITUACAO);

            /*" -5445- DISPLAY V0ENDO-DATARCAP */
            _.Display(V0ENDO_DATARCAP);

            /*" -5446- DISPLAY V0ENDO-COD-EMPRESA */
            _.Display(V0ENDO_COD_EMPRESA);

            /*" -5447- DISPLAY V0ENDO-CORRECAO */
            _.Display(V0ENDO_CORRECAO);

            /*" -5448- DISPLAY V0ENDO-ISENTA-CST */
            _.Display(V0ENDO_ISENTA_CST);

            /*" -5449- DISPLAY V0ENDO-DTVENCTO */
            _.Display(V0ENDO_DTVENCTO);

            /*" -5450- DISPLAY V0ENDO-CFPREFIX */
            _.Display(V0ENDO_CFPREFIX);

            /*" -5451- DISPLAY V0ENDO-VLCUSEMI */
            _.Display(V0ENDO_VLCUSEMI);

            /*" -5452- DISPLAY V0ENDO-RAMO */
            _.Display(V0ENDO_RAMO);

            /*" -5454- DISPLAY V0ENDO-CODPRODU. */
            _.Display(V0ENDO_CODPRODU);

            /*" -5456- PERFORM R4000-00-TOTAIS-CONTROLE. */

            R4000_00_TOTAIS_CONTROLE_SECTION();

            /*" -5456- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -5458- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -5462- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -5464- CLOSE VG0139B1. */
            VG0139B1.Close();

            /*" -5464- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}