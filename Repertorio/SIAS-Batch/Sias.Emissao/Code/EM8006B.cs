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
using Sias.Emissao.DB2.EM8006B;

namespace Code
{
    public class EM8006B
    {
        public bool IsCall { get; set; }

        public EM8006B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8006B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA DE REQUISITOS..  CLOVIS/DANIELA MARTINO             *      */
        /*"      *   PROGRAMADOR ............  WANGER C SILVA                     *      */
        /*"      *   CADMUS .... ............  XX.XXX    (PROJETO VISAO)          *      */
        /*"      *   DATA CODIFICACAO .......  30/08/2010                         *      */
        /*"      *   DATA REVISAO ...........  06/12/2010 - CLOVIS                *      */
        /*"      *   DATA REVISAO ...........  22/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DE ARQUIVOS DO PROJETO SAP *      */
        /*"      *                             REFERENTE RETORNO (ARQ-H)          *      */
        /*"      *                             EXCETO SINISTRO                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.59  * VERSAO  : 059 - JAZZ   582106                                  *      */
        /*"      *         : META 2024 - INCORPORACAO DA EMPRESA XS2 PELA CVP.    *      */
        /*"      * DEMANDA : 582.106                                              *      */
        /*"      * DATA    : 19/07/2024                                           *      */
        /*"      * NOME    : SERGIO LORETO                                        *      */
        /*"      * MARCADOR: V.59                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.58  * VERSAO  : 058                                                  *      */
        /*"      * MOTIVO  : RECEBER EVENTO 912861 E REALIZAR DE/PARA PARA EVENTO *      */
        /*"      *           912087 PARA PROCESSAMENTO NO CB6249B/CB6259B         *      */
        /*"      * DEMANDA : 496.381                                              *      */
        /*"      * DATA    : 10/10/2023                                           *      */
        /*"      * NOME    : ELIERMES OLIVEIRA                                    *      */
        /*"      * MARCADOR: V.58                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.57  * VERSAO  : 057                                                  *      */
        /*"      * MOTIVO  : SEGREGACAO SINISTRO MCP CNP - MCP CVP                *      */
        /*"      *           EXPURGO DE SINISTROS JA PROCESSADOS PELO MCP DA CVP  *      */
        /*"      * DEMANDA : 524.617                                              *      */
        /*"      * DATA    : 02/10/2023                                           *      */
        /*"      * NOME    : ROGER PIRES DOS SANTOS                               *      */
        /*"      * MARCADOR: V.57                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.56  * VERSAO  : 056                                                  *      */
        /*"      * MOTIVO  : RETIRAR AS ALTERACOES DAS VERSOES TEMPORARIAS 51 E   *      */
        /*"      *           54.                                                  *      */
        /*"      * DEMANDA : 446.551                                              *      */
        /*"      * DATA    : 13/01/2023                                           *      */
        /*"      * NOME    : FRANK CARVALHO                                       *      */
        /*"      * MARCADOR: V.56                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.55  * VERSAO  : 055                                                  *      */
        /*"      * MOTIVO  : RETIRAR OS REGISTROS TRATADOS PELO MCP, GRAVANDO     *      */
        /*"      *           NO ARQUIVO MOVTOMCP, SAIDA18. OS REGISTROS SAO       *      */
        /*"      *           IDENTIFICADOS PELA STRING 'MCP' NAS 3 PRIMEIRAS      *      */
        /*"      *           POSICOES, DO CAMPO IDLG (DET-IDLG) DOS REGISTROS     *      */
        /*"      *           DETALHE.                                             *      */
        /*"      * HISTORIA: PROJETO DS-SIAS                                      *      */
        /*"      * DATA    : 16/01/2022                                           *      */
        /*"      * NOME    : LUIZ FERNANDO GONCALVES                              *      */
        /*"      * MARCADOR: V.55                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.54  * VERSAO  : 54                                                   *      */
        /*"      * MOTIVO  : ENVITAR QUE REGISTROS SEJAM EXPURGADOS EM UM DERTER- *      */
        /*"      *           MINADO INTERVALO PARA GERAR REEMBOLSO.               *      */
        /*"      * DEMANDA : 299.143                                              *      */
        /*"      * DATA    : 19/07/2021                                           *      */
        /*"      * NOME    : THIAGO BLAIER                                        *      */
        /*"      * MARCADOR: V.54                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.53  * VERSAO  : 053                                                  *      */
        /*"      * MOTIVO  : ENVIAR O CAMPO MOTIVO DA COMPENSACAO PARA UTILIZAR NA*      */
        /*"      *           SOLUCAO DA REGUA DE COBRANCA.                        *      */
        /*"      * DEMANDA : 278.146                                              *      */
        /*"      * DATA    : 23/04/2021                                           *      */
        /*"      * NOME    : FRANK CARVALHO                                       *      */
        /*"      * MARCADOR: V.53                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.52  * VERSAO  : 052                                                  *      */
        /*"      * MOTIVO  : TRATATIVA PARA OS REGISTROS DO LOTERICO E CCA ENVIADO*      */
        /*"      *           COM APOLICE POSTECIPADA OU SEM PARCELA DE ADESAO.    *      */
        /*"      * DEMANDA : 286978                                               *      */
        /*"      * DATA    : 30/04/2021                                           *      */
        /*"      * NOME    : FLAVIO LIMA                                          *      */
        /*"      * MARCADOR: V.52                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  * VERSAO  : 051                                                  *      */
        /*"      * MOTIVO  : TRATATIVA EVENTUAL PARA REGISTROS DE VIDA ENVIADOS   *      */
        /*"      *           INCORRETAMENTE PARA RESTITUICAO.                     *      */
        /*"      * DEMANDA : 285.443 TAREFA: 285.862                              *      */
        /*"      * DATA    : 17/04/2021                                           *      */
        /*"      * NOME    : FRANK CARVALHO                                       *      */
        /*"      * MARCADOR: V.51                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.50  * VERSAO  : 050                                                  *      */
        /*"      * MOTIVO  : REALIZAR TRATATIVA PARA ACEITACAO DE ARQUIVOS JV1    *      */
        /*"      *           BEM COMO SEUS CONVENIOS                              *      */
        /*"      * HISTORIA: 268448 TAREFA: 270117                                *      */
        /*"      * DATA    : 14/12/2020                                           *      */
        /*"      * NOME    : HUSNI ALI HUSNI                                      *      */
        /*"      * MARCADOR: V.50                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.49  * VERSAO  : 049                                                  *      */
        /*"      * MOTIVO  : INCLUSAO DOS CAMPOS DE ADVERTENCIA CRIADOS PELO SAP  *      */
        /*"      *           PARA INDICAR A REGUA DE COBRANCA DE DEBITO E CARTAO. *      */
        /*"      * HISTORIA: 250.426/256.184                                      *      */
        /*"      * DATA    : 29/10/2020                                           *      */
        /*"      * NOME    : FRANK CARVALHO                                       *      */
        /*"      * MARCADOR: V.49                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO...: V.48                                               *      */
        /*"      *                                                                *      */
        /*"      *  HISTORIA.:                 PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 01/10/2020                                         *      */
        /*"      *  DESCRICAO: TROCA DE CEDENTES                                  *      */
        /*"      *                                                                *      */
        /*"      * CAIXA SEGURADORA S/A - RESSARCIMENTO YOUSE                     *      */
        /*"      * DE 238733 0630.003.00001004-9 PARA 976543 4255.003.00000121-2  *      */
        /*"      * CAIXA SEGURADORA S/A - DIRID (com IOF)                         *      */
        /*"      * DE 696001 0630.003.00001011-1 PARA 976545 4255.003.00000103-4  *      */
        /*"      * CAIXA SEGURADORA S/A - RESSARCIMENTO SEGURADORA                *      */
        /*"      * DE 696005 0630.003.00001003-0 PARA 976548 4255.003.00000103-4  *      */
        /*"      * CAIXA SEGURADORA S/A - YOUSE - RETENCAO (com IOF)              *      */
        /*"      * DE 763297 0630.003.00001004-9 PARA 976550 4255.003.00000121-2  *      */
        /*"      * CAIXA CAPITALIZACAO S/A - DICAP                                *      */
        /*"      * DE 695990 0630.003.00000371-9 PARA 976551 4255.003.00000111-5  *      */
        /*"      * CAIXA CONSORCIOS S/A - DICON                                   *      */
        /*"      * DE 695983 0630.003.00000367-0 PARA 976553 4255.003.00000115-8  *      */
        /*"      * CAIXA VIDA E PREVIDENCIA S/A - PREV - DEMAIS PARCELAS          *      */
        /*"      * DE 695993 0630.003.00041536-7 PARA 976554 4255.003.00000131-0  *      */
        /*"      * CAIXA VIDA E PREVIDENCIA S/A - PREV - ADESAO                   *      */
        /*"      * DE 700497 0630.003.00041536-7 PARA 976555 4255.003.00000131-0  *      */
        /*"      * CAIXA VIDA E PREVIDENCIA S/A - VIDA e PRESTAMISTA (com IOF)    *      */
        /*"      * DE 933828 0630.003.00008000-4 PARA 976556 4255.003.00000127-1  *      */
        /*"      * CAIXA VIDA E PREVIDENCIA S/A - RESSARCIMENTO CVP               *      */
        /*"      * DE 974800 0630.003.00008000-4 PARA 976557 4255.003.00000127-1  *      */
        /*"      * CAIXA SAUDE - DIRSA                                            *      */
        /*"      * DE 270168 0630.003.00000100-4 PARA 976665 4255-003-00800090-8  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.47  * VERSAO  : 047                                                  *      */
        /*"      * MOTIVO  : ALTERACAO PARA INCLUSAO DO TRATAMENTO DO REGISTRO    *      */
        /*"      *           TIPO 16 DO ARQ-H (SIACC-150 CVP / CNAB 150)          *      */
        /*"      * HISTORIA: 238.218                                              *      */
        /*"      * DATA    : 24/03/2020                                           *      */
        /*"      * NOME    : LUIZ FERNANDO GONCALVES                              *      */
        /*"      * MARCADOR: V.47                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.46  * VERSAO  : 046                                                  *      */
        /*"      * MOTIVO  : PREPARAR PROGRAMA PARA PROCESSAMENTO DOS NOVOS       *      */
        /*"      *           CONVENIOS DA CVP, PARA OS PRODUTOS DE VIDA           *      */
        /*"      * HISTORIA: 234.939                                              *      */
        /*"      * DATA    : 27/02/2020                                           *      */
        /*"      * NOME    : LUIZ FERNANDO GONCALVES                              *      */
        /*"      * MARCADOR: V.46                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.45  * VERSAO  : 045                                                  *      */
        /*"      * MOTIVO  : PREPARAR PROGRAMA PARA PROCESSAMENTO JV1             *      */
        /*"      * HISTORIA: 188.377                                              *      */
        /*"      * DATA    : 18/02/2019                                           *      */
        /*"      * NOME    : HUSNI ALI HUSNI                                      *      */
        /*"      * MARCADOR: JV101                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.44  * JAZZ 225440 - TRATAR CONGENERE NOVA 1015                       *      */
        /*"      *             - ALTERADO PARA OBTER A CONGENERE NA DATA DO       *      */
        /*"      *               PROCESSAMENTO                                    *      */
        /*"      * EM 23/03/2020 - OLIVEIRA                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.43  * VERSAO  : 043                                                  *      */
        /*"      * MOTIVO  : ACERTO INCLUSAO DA TABELA GE_CONTROLE_EMISSAO_SIGCB  *      */
        /*"      * JAZZ    : 200125                                               *      */
        /*"      * DATA    : 24/05/2019                                           *      */
        /*"      * NOME    : LISIANE BRAGANCA SOARES                              *      */
        /*"      * MARCADOR: V.43                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.42  * VERSAO  : 042                                                  *      */
        /*"      * MOTIVO  : PROJETO - MUDANCA OPCAO PAGTO CARTOES CIELO          *      */
        /*"      * DATA    : 09/05/2019                                           *      */
        /*"      * NOME    : DANIEL MEDINA GOMIDE - MILLENIUM                     *      */
        /*"      * MARCADOR: V.42                                                 *      */
        /*"      * DESCRICAO: PROCESSAR REGISTRO TIPO 14 - CARTAO DE CREDITO CIELO*      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.41  * VERSAO  : 041                                                  *      */
        /*"      * MOTIVO  : TRATAR RETORNO DO ARQH ANTES DO ARQG                 *      */
        /*"      * CADMUS  : 163502                                               *      */
        /*"      * DATA    : 25/05/2018                                           *      */
        /*"      * NOME    : LISIANE BRAGANCA SOARES                              *      */
        /*"      * MARCADOR: V.41                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.40  * VERSAO  : 040                                                  *      */
        /*"      * MOTIVO  : CORRIGIR FALHA NA GERACAO DO BOLETO RESSARCIMENTO    *      */
        /*"      * CADMUS  : 156915                                               *      */
        /*"      * DATA    : 04/12/2017                                           *      */
        /*"      * NOME    : ANTONIO PAULINO                                      *      */
        /*"      * MARCADOR: V.40                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.39  * VERSAO  : 039                                                  *      */
        /*"      * MOTIVO  : PRODUTO CESTA DE SERVICOS DISEF. GRAVA ARQUIVO       *      */
        /*"      *           REGISTRO TIPO 15. (PRODUTO 7732 E 7733)              *      */
        /*"      * CADMUS  : 151597                                               *      */
        /*"      * DATA    : 16/10/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.39                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.38  *  VERSAO...: V.38                                               *      */
        /*"      *  CADMUS...:             ANALISTA : LISIANE BRAGANCA SOARES     *      */
        /*"      *  DATA ....: 03/10/2017                                         *      */
        /*"      *  DESCRICAO: IDENTIFICAR APOLICE E ENDOSSO DO AUTO              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.37  *  VERSAO...: V.37                                               *      */
        /*"      *  CADMUS...: 152.798     ANALISTA : ELIERMES OLIVEIRA           *      */
        /*"      *  DATA ....: 09/08/2017                                         *      */
        /*"      *  DESCRICAO: NAO ALTERAR OPCAO-PAG DAS PARCELAS DE DEBITO EM    *      */
        /*"      *  CONTA, PARA CORRIGIR ERRO OCASIONADO NO VA0268B.              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.36  *  VERSAO...: V.36                                               *      */
        /*"      *  CADMUS...: 105.721     ANALISTA : DIEGO DIAS                  *      */
        /*"      *  DATA ....: 02/08/2017                                         *      */
        /*"      *  DESCRICAO: CORRECAO DA DATA PASSADA PARA O CAMPO SIGC13-DTA-  *      */
        /*"      *  GERACAO, VISTO QUE ESTA RECEBENDO A INFORMACAO DO ULTIMO      *      */
        /*"      *  GEGISTRO LIDO, E NAO CORRETA REFERENTE A DATA DE GERACAO DO   *      */
        /*"      *  PAGAMENTO                                                            */
        /*"      *----------------------------------------------------------------*      */
        /*"V.35  *  VERSAO...: V.35                                               *      */
        /*"      *  CADMUS...: 152.400     ANALISTA : LISIANE B. SOARES           *      */
        /*"      *  DATA ....: 11/07/2017                                         *      */
        /*"      *  DESCRICAO: ABEND -811 NA LEITURA DA TABELA                    *      */
        /*"      *             GE_CONTROLE_EMISSAO_SIGCB                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.34  *  VERSAO...: V.34                                               *      */
        /*"      *  CADMUS...: 105.721     ANALISTA : LISIANE B. SOARES           *      */
        /*"      *  DATA ....: 26/06/2017                                         *      */
        /*"      *  DESCRICAO: IDENTIFICAR RESSARCIMENTO DO AUTO                  *      */
        /*"      *             ACERTO NA INCLUSAO DA GE_CONTROLE_EMISSAO_SIGCB    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.33  *  VERSAO...: V.33                                               *      */
        /*"      *  CADMUS...: 151.935     ANALISTA : ELIERMES OLIVEIRA           *      */
        /*"      *  DATA ....: 23/06/2017                                         *      */
        /*"      *  DESCRICAO: CORRECAO DE ABEND -304 NO PARAGRAFO R5700          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.32  *  VERSAO...: V.32                                               *      */
        /*"      *  CADMUS...: 105.721         ANALISTA : DIEGO DIAS              *      */
        /*"      *  DATA ....: 16/12/2016                                         *      */
        /*"      *             22/02/2017                                         *      */
        /*"      *  DESCRICAO: GRAVAR INFORMACOES COMPLEMENTARES NO RETORNO DE PGT*      */
        /*"      *             P/ AUTO QUANDO ENDOSS0 = 4000 (OP DE RESSARCIMENTO)*      */
        /*"      *             GRAVADO PELO PROGRAMA SI9200B                      *      */
        /*"V.32D1*  DATA ....: 19/06/2017                                         *      */
        /*"V.32D1*             AJUSTE NA REGRA PARA TRATAMENTO DE CASOS DUPLICADOS*      */
        /*"V.32D1*             PRODUTO AUTO                                       *      */
        /*"V.32D2*                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.31  *  VERSAO...: V.31                                               *      */
        /*"      *  CADMUS...: 150.293         PROGRAMADOR: ELIERMES OLIVEIRA     *      */
        /*"      *  DATA ....: 28/04/2017                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: VERIFICA SE DET 13 POSSUI ENVIO DE DEBITO EM CONTA,*      */
        /*"      *             CASO POSITIVO GRAVA RETORNO DO SAP COM DADOS DA    *      */
        /*"      *             PARCELA ENCONTRADA NO SIAS E ALTERA A OPCAO-PAG    *      */
        /*"      *             PARA BOLETO.                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.30  * VERSAO  : 030                                                  *      */
        /*"      * MOTIVO  : FAZER O DE PARA DO CODIGO RETORNO 'ZA' ENVIADO DO SAP*      */
        /*"      *           PARA 'AN'.                                           *      */
        /*"      * CADMUS  : 148900                                               *      */
        /*"      * DATA    : 10/03/2017                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.30                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.29  *  VERSAO...: V.29                                               *      */
        /*"      *  CADMUS...: 140.778         PROGRAMADOR: ELIERMES OLIVEIRA     *      */
        /*"      *  DATA ....: 18/01/2017                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: GRAVAR COD-REJEICAO NA BASE DO SIGCB               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.28  *  VERSAO...: V.28                                               *      */
        /*"      *  CADMUS...: 140.778         PROGRAMADOR: ELIERMES OLIVEIRA     *      */
        /*"      *  DATA ....: 04/01/2017                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: CORRECAO NO UPDATE DOS REGISTROS DET 13 QUANDO     *      */
        /*"      *             ENCONTRADO NA BASE DO SIGCB                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.27  *  VERSAO...: V.27                                               *      */
        /*"      *  CADMUS...: 140.778         PROGRAMADOR: ELIERMES OLIVEIRA     *      */
        /*"      *  DATA ....: 04/01/2017                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: VERIFICAR EXISTENCIA DE NN REGISTRADO PELO IDLG    *      */
        /*"      *             DET 13 (Detalhe CA Cobranca Boleto Registrado)     *      */
        /*"      *             PARA TRATAMENTO DO PF2002B - PROJETO SIGCB         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.26  *  VERSAO...: V.26                                               *      */
        /*"      *  CADMUS...: 140.778         PROGRAMADOR: ELIERMES OLIVEIRA     *      */
        /*"      *  DATA ....: 21/09/2016                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: GRAVAR ARQUIVO REG-SAIDA15 COM TIPO DE REGISTRO    *      */
        /*"      *             DET 13 (Detalhe CA Cobranca Boleto Registrado)     *      */
        /*"      *             PARA TRATAMENTO DO PF2002B - PROJETO SIGCB         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.25  *  VERSAO...: V.25                                               *      */
        /*"      *  CADMUS...: 139534          PROGRAMADOR: LISIANE B. SOARES     *      */
        /*"      *  DATA ....: 20/10/2016                                         *      */
        /*"      *  MOTIVO...: RENOVACAO CCA                                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *  VERSAO...: V.24                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: THIAGO                *      */
        /*"      *  DATA ....: 05/05/2016                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATAR CODIGO DE RETORNO DO SAP EM BRANCO.         *      */
        /*"      *             O RETORNO EM BRANCO NAO E MAIS CONSIDERADO PAGTO OK*      */
        /*"      *             O RETORNO EM BRANCO SERA TRATADO COMO CRITICA NO   *      */
        /*"      *             NO ARQUIVO DE SAIDA DO PROGRAMA CB0083B            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *  VERSAO...: V.23                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 11/08/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATA DEMAIS PARCELAS BACKSEG    OUTROS BANCOS     *      */
        /*"      *             RETORNO NO ARQ-H - DET12         CONVENIO 012000   *      */
        /*"      *                                                                *      */
        /*"      *  GRAVA REGISTROS NO DEBITO - REG-SAIDA14                       *      */
        /*"      *  ARQUIVO DE ENTRADA PARA O PROGRAMA BI0073B                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 22 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.21  *  VERSAO...: V.21                                               *      */
        /*"      *  CADMUS...: 107.004         PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 10/02/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATA ADESAO          BACKSEG    OUTROS BANCOS     *      */
        /*"      *             RETORNO NO ARQ-H - DET11         CONVENIO 011000   *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATA DEMAIS PARCELAS BACKSEG    OUTROS BANCOS     *      */
        /*"      *             RETORNO NO ARQ-H - DET14         CONVENIO 012000   *      */
        /*"      *                                                                *      */
        /*"      *  GRAVA REGISTROS NO DEBITO - REG-SAIDA14                       *      */
        /*"      *  ARQUIVO DE ENTRADA PARA O PROGRAMA BI0073B                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 020                                                  *      */
        /*"      * MOTIVO  : OCORRENCIA DE FALHA NUM. 99812 - PROCESSAMENTO NO DIA*      */
        /*"      *           27/06/2014 - ERRO UPDATE NA MOVTO_DEBITOCC_CEF       *      */
        /*"      * CADMUS  : 99812                                                *      */
        /*"      * DATA    : 01/07/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.20                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 019                                                  *      */
        /*"      * MOTIVO  : OCORRENCIA DE FALHA NUM. 99812 - PROCESSAMENTO NO DIA*      */
        /*"      *           27/06/2014 - ERRO UPDATE NA MOVTO_DEBITOCC_CEF       *      */
        /*"      * CADMUS  : 99812                                                *      */
        /*"      * DATA    : 30/06/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.19                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO  : 018                                                  *      */
        /*"      * MOTIVO  : CANCELAMENTO PRODUTO 7705 DENTRO DO EFP, GRAVA  ARQ  *      */
        /*"      *           SICOV 609500                                         *      */
        /*"      * CADMUS  : 88832                                                *      */
        /*"      * DATA    : 25/04/2014                                           *      */
        /*"      * NOME    : DIOGO MATHEUS                                        *      */
        /*"      * MARCADOR: V.18                                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.17  *  VERSAO...: V.17                                               *      */
        /*"      *  CADMUS...: CAD 74.582      PROGRAMADOR: COREON                *      */
        /*"      *  DATA ....: 28/03/2014                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: GERAR ARQUIVO RETORNO DEBITO (3) DEMAIS BANCOS     *      */
        /*"      *             PRODUTOS AUTO FACIL.                               *      */
        /*"      *                                                                *      */
        /*"      *             RETORNO NO ARQ-H - DET12         CONVENIO 012000   *      */
        /*"      *                                                                *      */
        /*"      *             GRAVA REGISTROS NO ARQUIVO - REG-SAIDA14           *      */
        /*"      *             ARQUIVO DE ENTRADA PARA O PROGRAMA BI6257B         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.16  *  VERSAO...: V.16                                               *      */
        /*"      *  CADMUS...: CAD93619        PROGRAMADOR: GUILHERME CORREIA     *      */
        /*"      *  DATA ....: 10/02/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: PERMITIR BAIXA DE PARCELAS PARA PARCELAS SUSPENSAS *      */
        /*"      *             PRODUTOS LOTERICO E CCA                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.15  *  VERSAO...: V.15                                               *      */
        /*"      *  CADMUS...: CAD91982        PROGRAMADOR: ELIERMES OLIVEIRA     *      */
        /*"      *  DATA ....: 24/12/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: CORRECAO SQLCODE -305 QUANDO DADOS BANCARIOS NULOS *      */
        /*"      *             NA TABELA MOVTO_DEBITOCC_CEF                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.14  *  VERSAO...: V.14                                               *      */
        /*"      *  CADMUS...: ABEND           PROGRAMADOR: FRANK CARVALHO        *      */
        /*"      *  DATA ....: 19/12/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: ENVIO DE COD_BANCO 104 PARA CONVENIO 001313, PARA  *      */
        /*"      *             EFETUAR CORRETAMENTE O RETORNO NAS TABELAS DO VIDA,*      */
        /*"      *             EVITANDO ABEND NO PROGRAMA VA0805B.                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.13  *  VERSAO...: V.13                                               *      */
        /*"      *  CADMUS...: 82475           PROGRAMADOR: OLIVEIRA              *      */
        /*"      *  DATA ....: 07/11/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: INCLUSAO DO CONVENIO 600149 - LOTERICO CCA         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.12  *  VERSAO...: V.12                                               *      */
        /*"      *  CADMUS...: 80672           PROGRAMADOR: PATRICIA SALES        *      */
        /*"      *  DATA ....: 06/11/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: ACERTO NO IDLG PARA TRATAR O RETORNO DO CONVENIO   *      */
        /*"      *             001313.                                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.11  *  VERSAO...: V.11                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 26/07/2013                                         *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATA ADESAO          PARCEIROS                    *      */
        /*"      *             RETORNO NO ARQ-H - DET11         CONVENIO 021000   *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATA DEMAIS PARCELAS PARCEIROS                    *      */
        /*"      *             RETORNO NO ARQ-H - DET14         CONVENIO 023000   *      */
        /*"      *                                                                *      */
        /*"      *  GRAVA REGISTROS NO SICAPP - REG-SAIDA11                       *      */
        /*"      *  ARQUIVO DE ENTRADA PARA O PROGRAMA BI6251B                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.10  *  VERSAO...: V.10                                               *      */
        /*"      *  CADMUS...: 84045           PROGRAMADOR: RILDO                 *      */
        /*"      *  DATA ....: 24/10/2012                                         *      */
        /*"      *  DESCRICAO: CRIAR ARQUIVO COM OS MOVIMENTOS REJEITADOS         *      */
        /*"      *             SAIDA13/EXPURGO                                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.09  *  VERSAO...: V.09                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 24/10/2012                                         *      */
        /*"      *  DESCRICAO: TRATA DEMAIS PARCELAS PARCEIRA                     *      */
        /*"      *             RETORNO NO ARQ-H - DET3 (CARTAO) CONVENIO 022000   *      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO: TRATA ADESAO          PARCEIRA                     *      */
        /*"      *             RETORNO NO ARQ-H - DET7 (SICAP)  CONVENIO 021000   *      */
        /*"      *             SEM ALTERACAO NESTE PROGRAMA.                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  *  VERSAO...: V.08                                               *      */
        /*"      *  CADMUS...:                 PROGRAMADOR: CLOVIS                *      */
        /*"      *  DATA ....: 24/10/2012                                         *      */
        /*"      *  DESCRICAO: TRANSFORMA O RETORNO DO CONVENIO 001313 (SIACC)    *      */
        /*"      *             COMO 609000 (SICOV).                               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS  66299                                                *      */
        /*"      *   EM 02/02/2012 - CLOVIS              PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS  66018                                                *      */
        /*"      *   EM 24/01/2012 - CLOVIS              PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *   VERIFICADO QUE NO ARQ-H, EXISTE CAMPO DE DATA SEM INFORMACAO *      */
        /*"      *   00000000.                                                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   EM 09/01/2012 - CLOVIS              PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 - COBRANCA CARTAO CREDITO DET3 - ORBITALL          *      */
        /*"      *                                                                *      */
        /*"      *   VERIFICADO QUE NO ARQ-H, O CAMPO MOTIVO                      *      */
        /*"      *   (POSICAO 144 A 145) ESTA COM BRANCOS.                        *      */
        /*"      *                                                                *      */
        /*"      *   R1050-00-TRATA-RETORNO                                       *      */
        /*"      *   GUARDA MOTIVO RETORNO SIACC ENVIADO PELO SAP PARA GERAR      *      */
        /*"      *   RELATORIOS COM CODIGOS DE RETORNO ORIGINAL.                  *      */
        /*"      *                                                                *      */
        /*"      *   REDEFINES DO REGISTRO DET11.                                 *      */
        /*"      *   V.04***** 10       FILLER                   PIC  X(168).     *      */
        /*"      *   V.04      10       FILLER                   PIC  X(164).     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 - COBRANCA PRODUTOS EXTRA-REDE - TRAY              *      */
        /*"      *                                                                *      */
        /*"      *   TRATA REGISTRO TIPO = 11(CA ADESAO PARCEIRA)                 *      */
        /*"      *                         12(CA DEMAIS PARCELAS PARCEIRA)        *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/11/2011 - EDIVALDO GOMES                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - COBRANCA BANCOOB - CREDIMINAS                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 31/05/2011 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *   TRATA REGISTRO TIPO = 9 (CA BOLETO BANCOOB)                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PROJETO AUTO - SUL AMERICA                       *      */
        /*"      *                                                                *      */
        /*"      *               - PREVISAO DOS NOVOS CEDENTES                    *      */
        /*"      *                 063087000000319-8 - ADESAO                     *      */
        /*"      *                 063087000000320-1 - DEMAIS PARCELAS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2011 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *   SEM NECESSIDADE DE ALTERACOES - O PGM TRATA O CONVENIO       *      */
        /*"      *   SICOB PELO CODIGO DA EMPRESA C000 - SEGURADORA               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVARQH { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis MOVARQH
        {
            get
            {
                _.Move(REG_ARQH, _MOVARQH); VarBasis.RedefinePassValue(REG_ARQH, _MOVARQH, REG_ARQH); return _MOVARQH;
            }
        }
        public FileBasis _SAIDA1 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA1
        {
            get
            {
                _.Move(REG_SAIDA1, _SAIDA1); VarBasis.RedefinePassValue(REG_SAIDA1, _SAIDA1, REG_SAIDA1); return _SAIDA1;
            }
        }
        public FileBasis _SAIDA2 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA2
        {
            get
            {
                _.Move(REG_SAIDA2, _SAIDA2); VarBasis.RedefinePassValue(REG_SAIDA2, _SAIDA2, REG_SAIDA2); return _SAIDA2;
            }
        }
        public FileBasis _SAIDA3 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA3
        {
            get
            {
                _.Move(REG_SAIDA3, _SAIDA3); VarBasis.RedefinePassValue(REG_SAIDA3, _SAIDA3, REG_SAIDA3); return _SAIDA3;
            }
        }
        public FileBasis _SAIDA4 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA4
        {
            get
            {
                _.Move(REG_SAIDA4, _SAIDA4); VarBasis.RedefinePassValue(REG_SAIDA4, _SAIDA4, REG_SAIDA4); return _SAIDA4;
            }
        }
        public FileBasis _SAIDA5 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA5
        {
            get
            {
                _.Move(REG_SAIDA5, _SAIDA5); VarBasis.RedefinePassValue(REG_SAIDA5, _SAIDA5, REG_SAIDA5); return _SAIDA5;
            }
        }
        public FileBasis _SAIDA6 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA6
        {
            get
            {
                _.Move(REG_SAIDA6, _SAIDA6); VarBasis.RedefinePassValue(REG_SAIDA6, _SAIDA6, REG_SAIDA6); return _SAIDA6;
            }
        }
        public FileBasis _SAIDA7 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA7
        {
            get
            {
                _.Move(REG_SAIDA7, _SAIDA7); VarBasis.RedefinePassValue(REG_SAIDA7, _SAIDA7, REG_SAIDA7); return _SAIDA7;
            }
        }
        public FileBasis _SAIDA9 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA9
        {
            get
            {
                _.Move(REG_SAIDA9, _SAIDA9); VarBasis.RedefinePassValue(REG_SAIDA9, _SAIDA9, REG_SAIDA9); return _SAIDA9;
            }
        }
        public FileBasis _SAIDA11 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA11
        {
            get
            {
                _.Move(REG_SAIDA11, _SAIDA11); VarBasis.RedefinePassValue(REG_SAIDA11, _SAIDA11, REG_SAIDA11); return _SAIDA11;
            }
        }
        public FileBasis _SAIDA12 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA12
        {
            get
            {
                _.Move(REG_SAIDA12, _SAIDA12); VarBasis.RedefinePassValue(REG_SAIDA12, _SAIDA12, REG_SAIDA12); return _SAIDA12;
            }
        }
        public FileBasis _SAIDA13 { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis SAIDA13
        {
            get
            {
                _.Move(REG_SAIDA13, _SAIDA13); VarBasis.RedefinePassValue(REG_SAIDA13, _SAIDA13, REG_SAIDA13); return _SAIDA13;
            }
        }
        public FileBasis _SAIDA14 { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis SAIDA14
        {
            get
            {
                _.Move(REG_SAIDA14, _SAIDA14); VarBasis.RedefinePassValue(REG_SAIDA14, _SAIDA14, REG_SAIDA14); return _SAIDA14;
            }
        }
        public FileBasis _SAIDA15 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA15
        {
            get
            {
                _.Move(REG_SAIDA15, _SAIDA15); VarBasis.RedefinePassValue(REG_SAIDA15, _SAIDA15, REG_SAIDA15); return _SAIDA15;
            }
        }
        public FileBasis _SAIDA16 { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAIDA16
        {
            get
            {
                _.Move(REG_SAIDA16, _SAIDA16); VarBasis.RedefinePassValue(REG_SAIDA16, _SAIDA16, REG_SAIDA16); return _SAIDA16;
            }
        }
        public FileBasis _SAIDA17 { get; set; } = new FileBasis(new PIC("X", "350", "X(350)"));

        public FileBasis SAIDA17
        {
            get
            {
                _.Move(REG_SAIDA17, _SAIDA17); VarBasis.RedefinePassValue(REG_SAIDA17, _SAIDA17, REG_SAIDA17); return _SAIDA17;
            }
        }
        public FileBasis _SAIDA18 { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis SAIDA18
        {
            get
            {
                _.Move(REG_SAIDA18, _SAIDA18); VarBasis.RedefinePassValue(REG_SAIDA18, _SAIDA18, REG_SAIDA18); return _SAIDA18;
            }
        }
        public FileBasis _SAIDA19 { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis SAIDA19
        {
            get
            {
                _.Move(REG_SAIDA19, _SAIDA19); VarBasis.RedefinePassValue(REG_SAIDA19, _SAIDA19, REG_SAIDA19); return _SAIDA19;
            }
        }
        /*"01        REG-ARQH                    PIC  X(500).*/
        public StringBasis REG_ARQH { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01        REG-SAIDA1                  PIC  X(300).*/
        public StringBasis REG_SAIDA1 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA2                  PIC  X(300).*/
        public StringBasis REG_SAIDA2 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA3                  PIC  X(300).*/
        public StringBasis REG_SAIDA3 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA4                  PIC  X(300).*/
        public StringBasis REG_SAIDA4 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA5                  PIC  X(300).*/
        public StringBasis REG_SAIDA5 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA6                  PIC  X(300).*/
        public StringBasis REG_SAIDA6 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA7                  PIC  X(300).*/
        public StringBasis REG_SAIDA7 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA9                  PIC  X(400).*/
        public StringBasis REG_SAIDA9 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA11                 PIC  X(300).*/
        public StringBasis REG_SAIDA11 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA12                 PIC  X(300).*/
        public StringBasis REG_SAIDA12 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA13                 PIC  X(500).*/
        public StringBasis REG_SAIDA13 { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01        REG-SAIDA14                 PIC  X(150).*/
        public StringBasis REG_SAIDA14 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-SAIDA15                 PIC  X(400).*/
        public StringBasis REG_SAIDA15 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA16                 PIC  X(300).*/
        public StringBasis REG_SAIDA16 { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA17                 PIC  X(350).*/
        public StringBasis REG_SAIDA17 { get; set; } = new StringBasis(new PIC("X", "350", "X(350)."), @"");
        /*"01        REG-SAIDA18                 PIC  X(500).*/
        public StringBasis REG_SAIDA18 { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01        REG-SAIDA19                 PIC  X(500).*/
        public StringBasis REG_SAIDA19 { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_ALF { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_BET { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77 WS-FLAG-DIRID                  PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_FLAG_DIRID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77    VIND-DTRETORNO            PIC S9(004)     COMP.*/
        public IntBasis VIND_DTRETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-RETORNO              PIC S9(004)     COMP.*/
        public IntBasis VIND_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-USUARIO              PIC S9(004)     COMP.*/
        public IntBasis VIND_USUARIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-SEQUENCIA            PIC S9(004)     COMP.*/
        public IntBasis VIND_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WHOST-DATA-EM             PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DATA_EM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77    WS-NULL1                  PIC S9(04)      COMP.*/
        public IntBasis WS_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    WS-COUNT                  PIC S9(04)      COMP.*/
        public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77    WS-CONTRATO-EF            PIC  X(03)      VALUE SPACES.*/
        public StringBasis WS_CONTRATO_EF { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"77    WS-NUM-REQUISICAO         PIC  9(13)      VALUE ZEROS.*/
        public IntBasis WS_NUM_REQUISICAO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77    VIND-NULL01               PIC S9(004)     COMP.*/
        public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-COUNT              PIC S9(009)     COMP VALUE +0.*/
        public IntBasis WSHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WS-QTD-DISPLAY            PIC  9(007) VALUE ZEROS.*/
        public IntBasis WS_QTD_DISPLAY { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"77 WS-COD-CONGENERE             PIC S9(04) VALUE +0   COMP.*/
        public IntBasis WS_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  W.*/
        public EM8006B_W W { get; set; } = new EM8006B_W();
        public class EM8006B_W : VarBasis
        {
            /*"  03  WS-MOVCC-CONVENIO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis WS_MOVCC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WTEM-REGISTRO             PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WTEM_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WNSAS-DISPLAY             PIC  9(008)    VALUE   ZEROS.*/
            public IntBasis WNSAS_DISPLAY { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03  LD-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVTOMCP               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVTOMCP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVTOMCPCVP            PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVTOMCPCVP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-TIPOREG                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_TIPOREG { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-HEADER                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_HEADER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-TRAILLER               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_TRAILLER { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESP01                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESP01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESP02                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESP02 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DESP16                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DESP16 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-VIDA                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_VIDA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CONV1313               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CONV1313 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-LOTERICO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_LOTERICO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-BILHETE                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-AUTO                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_AUTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-REDCHQ                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_REDCHQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET11                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET14                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET14 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET12                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET12 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET11                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET11 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET14                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET14 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET12                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET12 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SICAP                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SICAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SICOB                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SICOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SIGPF                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SIGPF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CARTAO                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CARTAO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SIACC                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SIACC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CHEQUE                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CHEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SINISTRO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-BANCOOB                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_BANCOOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-DET13                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_DET13 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET13                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET13 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET15                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET15 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET16                  PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET16 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-DET13-CNTRLE           PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_DET13_CNTRLE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TE-SINISTRO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TE_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-TRATA                  PIC  X(001)    VALUE   'S'.*/
            public StringBasis WS_TRATA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03  WS-EMP-ANT                PIC  X(004)    VALUE   SPACES.*/
            public StringBasis WS_EMP_ANT { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  03  WS-TEM-BILHETE            PIC  X(001)    VALUE   'S'.*/
            public StringBasis WS_TEM_BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
            /*"  03  WS-TRATA-SINISTRO         PIC  X(003)    VALUE    SPACES.*/
            public StringBasis WS_TRATA_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  AC-GRAV-SAIDA1            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA2            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA2 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA3            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA3 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA4            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA4 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA5            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA5 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA6            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA6 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA7            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA7 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA9            PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA9 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA11           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA11 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA12           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA13           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA13 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA14           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA14 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA15           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA15 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA16           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA16 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA17           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA17 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA18           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA18 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA19           PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis AC_GRAV_SAIDA19 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  BAC-ADESAO                PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis BAC_ADESAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  BAC-DEMAIS                PIC  9(009)    VALUE    ZEROS.*/
            public IntBasis BAC_DEMAIS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-FLAG-TEM-NN-CNTRLE     PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG_TEM_NN_CNTRLE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-FLAG-DUP               PIC  X(001)    VALUE   SPACES.*/
            public StringBasis WS_FLAG_DUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WS-SQLCODE                PIC  X(004)    VALUE   SPACES.*/
            public StringBasis WS_SQLCODE { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  03  WS-NOSSO-NUMERO-SAP       PIC  9(018).*/
            public IntBasis WS_NOSSO_NUMERO_SAP { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
            /*"  03         FILLER REDEFINES    WS-NOSSO-NUMERO-SAP.*/
            private _REDEF_EM8006B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM8006B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM8006B_FILLER_0(); _.Move(WS_NOSSO_NUMERO_SAP, _filler_0); VarBasis.RedefinePassValue(WS_NOSSO_NUMERO_SAP, _filler_0, WS_NOSSO_NUMERO_SAP); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_NOSSO_NUMERO_SAP); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_NOSSO_NUMERO_SAP); }
            }  //Redefines
            public class _REDEF_EM8006B_FILLER_0 : VarBasis
            {
                /*"     10     FILLER              PIC  9(003).*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"     10     WS-NUM-TITULO-NN    PIC  9(014).*/
                public IntBasis WS_NUM_TITULO_NN { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"     10     FILLER              PIC  9(001).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03  WS-HEA-NSASAP             PIC  9(009).*/

                public _REDEF_EM8006B_FILLER_0()
                {
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_NUM_TITULO_NN.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_HEA_NSASAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"   03 WS-IDLG-DIRID               PIC X(40).*/
            public StringBasis WS_IDLG_DIRID { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   03 WS-IDLG-DIRID-R1 REDEFINES WS-IDLG-DIRID.*/
            private _REDEF_EM8006B_WS_IDLG_DIRID_R1 _ws_idlg_dirid_r1 { get; set; }
            public _REDEF_EM8006B_WS_IDLG_DIRID_R1 WS_IDLG_DIRID_R1
            {
                get { _ws_idlg_dirid_r1 = new _REDEF_EM8006B_WS_IDLG_DIRID_R1(); _.Move(WS_IDLG_DIRID, _ws_idlg_dirid_r1); VarBasis.RedefinePassValue(WS_IDLG_DIRID, _ws_idlg_dirid_r1, WS_IDLG_DIRID); _ws_idlg_dirid_r1.ValueChanged += () => { _.Move(_ws_idlg_dirid_r1, WS_IDLG_DIRID); }; return _ws_idlg_dirid_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_idlg_dirid_r1, WS_IDLG_DIRID); }
            }  //Redefines
            public class _REDEF_EM8006B_WS_IDLG_DIRID_R1 : VarBasis
            {
                /*"      10 WS-IDLG-EMP-SIS-TIP      PIC X(13).*/
                public StringBasis WS_IDLG_EMP_SIS_TIP { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"      10 WS-IDLG-APO-END          PIC X(27).*/
                public StringBasis WS_IDLG_APO_END { get; set; } = new StringBasis(new PIC("X", "27", "X(27)."), @"");
                /*"      10 WS-IDLG-APO-END-R1 REDEFINES WS-IDLG-APO-END.*/
                private _REDEF_EM8006B_WS_IDLG_APO_END_R1 _ws_idlg_apo_end_r1 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_APO_END_R1 WS_IDLG_APO_END_R1
                {
                    get { _ws_idlg_apo_end_r1 = new _REDEF_EM8006B_WS_IDLG_APO_END_R1(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r1); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r1, WS_IDLG_APO_END); _ws_idlg_apo_end_r1.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r1, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r1; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r1, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_APO_END_R1 : VarBasis
                {
                    /*"         15 WS-IDLG-APO-NUM       PIC 9(13).*/
                    public IntBasis WS_IDLG_APO_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15  FILLER REDEFINES    WS-IDLG-APO-NUM.*/
                    private _REDEF_EM8006B_FILLER_3 _filler_3 { get; set; }
                    public _REDEF_EM8006B_FILLER_3 FILLER_3
                    {
                        get { _filler_3 = new _REDEF_EM8006B_FILLER_3(); _.Move(WS_IDLG_APO_NUM, _filler_3); VarBasis.RedefinePassValue(WS_IDLG_APO_NUM, _filler_3, WS_IDLG_APO_NUM); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_IDLG_APO_NUM); }; return _filler_3; }
                        set { VarBasis.RedefinePassValue(value, _filler_3, WS_IDLG_APO_NUM); }
                    }  //Redefines
                    public class _REDEF_EM8006B_FILLER_3 : VarBasis
                    {
                        /*"            20 WS-IDLG-APO-NUM-ID PIC 9(01).*/
                        public IntBasis WS_IDLG_APO_NUM_ID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-APO-NUM-RE PIC 9(12).*/
                        public IntBasis WS_IDLG_APO_NUM_RE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                        /*"         15 WS-IDLG-APO-PAR       PIC 9(02).*/

                        public _REDEF_EM8006B_FILLER_3()
                        {
                            WS_IDLG_APO_NUM_ID.ValueChanged += OnValueChanged;
                            WS_IDLG_APO_NUM_RE.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_IDLG_APO_PAR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER                PIC X(12).*/
                    public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
                    /*"      10 WS-IDLG-APO-END-R2 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8006B_WS_IDLG_APO_END_R1()
                    {
                        WS_IDLG_APO_NUM.ValueChanged += OnValueChanged;
                        FILLER_3.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_WS_IDLG_APO_END_R2 _ws_idlg_apo_end_r2 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_APO_END_R2 WS_IDLG_APO_END_R2
                {
                    get { _ws_idlg_apo_end_r2 = new _REDEF_EM8006B_WS_IDLG_APO_END_R2(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r2); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r2, WS_IDLG_APO_END); _ws_idlg_apo_end_r2.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r2, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r2; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r2, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_APO_END_R2 : VarBasis
                {
                    /*"         15 WS-IDLG-END-APO       PIC 9(13).*/
                    public IntBasis WS_IDLG_END_APO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG-END-NUM       PIC 9(04).*/
                    public IntBasis WS_IDLG_END_NUM { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"         15 WS-IDLG-END-PAR       PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR.*/
                    private _REDEF_EM8006B_FILLER_5 _filler_5 { get; set; }
                    public _REDEF_EM8006B_FILLER_5 FILLER_5
                    {
                        get { _filler_5 = new _REDEF_EM8006B_FILLER_5(); _.Move(WS_IDLG_END_PAR, _filler_5); VarBasis.RedefinePassValue(WS_IDLG_END_PAR, _filler_5, WS_IDLG_END_PAR); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_IDLG_END_PAR); }; return _filler_5; }
                        set { VarBasis.RedefinePassValue(value, _filler_5, WS_IDLG_END_PAR); }
                    }  //Redefines
                    public class _REDEF_EM8006B_FILLER_5 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(08).*/

                        public _REDEF_EM8006B_FILLER_5()
                        {
                            WS_IDLG_END_PAR_P1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_P2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                    /*"      10 WS-IDLG-APO-END-R3 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8006B_WS_IDLG_APO_END_R2()
                    {
                        WS_IDLG_END_APO.ValueChanged += OnValueChanged;
                        WS_IDLG_END_NUM.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR.ValueChanged += OnValueChanged;
                        FILLER_5.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_WS_IDLG_APO_END_R3 _ws_idlg_apo_end_r3 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_APO_END_R3 WS_IDLG_APO_END_R3
                {
                    get { _ws_idlg_apo_end_r3 = new _REDEF_EM8006B_WS_IDLG_APO_END_R3(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r3); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r3, WS_IDLG_APO_END); _ws_idlg_apo_end_r3.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r3, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r3; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r3, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_APO_END_R3 : VarBasis
                {
                    /*"         15 WS-IDLG-END-APO-R3    PIC 9(13).*/
                    public IntBasis WS_IDLG_END_APO_R3 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG-END-NUM-R3    PIC 9(04).*/
                    public IntBasis WS_IDLG_END_NUM_R3 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"         15 WS-IDLG-END-PAR-R3    PIC 9(03).*/
                    public IntBasis WS_IDLG_END_PAR_R3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR-R3.*/
                    private _REDEF_EM8006B_FILLER_7 _filler_7 { get; set; }
                    public _REDEF_EM8006B_FILLER_7 FILLER_7
                    {
                        get { _filler_7 = new _REDEF_EM8006B_FILLER_7(); _.Move(WS_IDLG_END_PAR_R3, _filler_7); VarBasis.RedefinePassValue(WS_IDLG_END_PAR_R3, _filler_7, WS_IDLG_END_PAR_R3); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_IDLG_END_PAR_R3); }; return _filler_7; }
                        set { VarBasis.RedefinePassValue(value, _filler_7, WS_IDLG_END_PAR_R3); }
                    }  //Redefines
                    public class _REDEF_EM8006B_FILLER_7 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-R3-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R3_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R3-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R3_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R3-P3 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R3_P3 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(07).*/

                        public _REDEF_EM8006B_FILLER_7()
                        {
                            WS_IDLG_END_PAR_R3_P1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R3_P2.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R3_P3.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                    /*"      10 WS-IDLG-APO-END-R4 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8006B_WS_IDLG_APO_END_R3()
                    {
                        WS_IDLG_END_APO_R3.ValueChanged += OnValueChanged;
                        WS_IDLG_END_NUM_R3.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R3.ValueChanged += OnValueChanged;
                        FILLER_7.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_WS_IDLG_APO_END_R4 _ws_idlg_apo_end_r4 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_APO_END_R4 WS_IDLG_APO_END_R4
                {
                    get { _ws_idlg_apo_end_r4 = new _REDEF_EM8006B_WS_IDLG_APO_END_R4(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r4); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r4, WS_IDLG_APO_END); _ws_idlg_apo_end_r4.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r4, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r4; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r4, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_APO_END_R4 : VarBasis
                {
                    /*"         15 WS-IDLG-END-APO-R4    PIC 9(13).*/
                    public IntBasis WS_IDLG_END_APO_R4 { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"         15 WS-IDLG-END-NUM-R4    PIC 9(03).*/
                    public IntBasis WS_IDLG_END_NUM_R4 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                    /*"         15 WS-IDLG-END-PAR-R4    PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR_R4 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER                PIC X(09).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                    /*"      10 WS-IDLG-PRO-END-R5 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8006B_WS_IDLG_APO_END_R4()
                    {
                        WS_IDLG_END_APO_R4.ValueChanged += OnValueChanged;
                        WS_IDLG_END_NUM_R4.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R4.ValueChanged += OnValueChanged;
                        FILLER_9.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_WS_IDLG_PRO_END_R5 _ws_idlg_pro_end_r5 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_PRO_END_R5 WS_IDLG_PRO_END_R5
                {
                    get { _ws_idlg_pro_end_r5 = new _REDEF_EM8006B_WS_IDLG_PRO_END_R5(); _.Move(WS_IDLG_APO_END, _ws_idlg_pro_end_r5); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_pro_end_r5, WS_IDLG_APO_END); _ws_idlg_pro_end_r5.ValueChanged += () => { _.Move(_ws_idlg_pro_end_r5, WS_IDLG_APO_END); }; return _ws_idlg_pro_end_r5; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_pro_end_r5, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_PRO_END_R5 : VarBasis
                {
                    /*"         15 WS-IDLG-PRO-NUM       PIC 9(12).*/
                    public IntBasis WS_IDLG_PRO_NUM { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                    /*"         15  FILLER REDEFINES    WS-IDLG-PRO-NUM.*/
                    private _REDEF_EM8006B_FILLER_10 _filler_10 { get; set; }
                    public _REDEF_EM8006B_FILLER_10 FILLER_10
                    {
                        get { _filler_10 = new _REDEF_EM8006B_FILLER_10(); _.Move(WS_IDLG_PRO_NUM, _filler_10); VarBasis.RedefinePassValue(WS_IDLG_PRO_NUM, _filler_10, WS_IDLG_PRO_NUM); _filler_10.ValueChanged += () => { _.Move(_filler_10, WS_IDLG_PRO_NUM); }; return _filler_10; }
                        set { VarBasis.RedefinePassValue(value, _filler_10, WS_IDLG_PRO_NUM); }
                    }  //Redefines
                    public class _REDEF_EM8006B_FILLER_10 : VarBasis
                    {
                        /*"            20 WS-IDLG-PRO-NUM-ID PIC 9(01).*/
                        public IntBasis WS_IDLG_PRO_NUM_ID { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-PRO-NUM-RE PIC 9(11).*/
                        public IntBasis WS_IDLG_PRO_NUM_RE { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                        /*"         15 FILLER                PIC X(15).*/

                        public _REDEF_EM8006B_FILLER_10()
                        {
                            WS_IDLG_PRO_NUM_ID.ValueChanged += OnValueChanged;
                            WS_IDLG_PRO_NUM_RE.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                    /*"      10 WS-IDLG-APO-END-R6 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8006B_WS_IDLG_PRO_END_R5()
                    {
                        WS_IDLG_PRO_NUM.ValueChanged += OnValueChanged;
                        FILLER_10.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_WS_IDLG_APO_END_R6 _ws_idlg_apo_end_r6 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_APO_END_R6 WS_IDLG_APO_END_R6
                {
                    get { _ws_idlg_apo_end_r6 = new _REDEF_EM8006B_WS_IDLG_APO_END_R6(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r6); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r6, WS_IDLG_APO_END); _ws_idlg_apo_end_r6.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r6, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r6; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r6, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_APO_END_R6 : VarBasis
                {
                    /*"         15 WS-IDLG-END-PRO-R6    PIC 9(10).*/
                    public IntBasis WS_IDLG_END_PRO_R6 { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"         15 WS-IDLG-END-PAR-R6    PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR_R6 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR-R6.*/
                    private _REDEF_EM8006B_FILLER_12 _filler_12 { get; set; }
                    public _REDEF_EM8006B_FILLER_12 FILLER_12
                    {
                        get { _filler_12 = new _REDEF_EM8006B_FILLER_12(); _.Move(WS_IDLG_END_PAR_R6, _filler_12); VarBasis.RedefinePassValue(WS_IDLG_END_PAR_R6, _filler_12, WS_IDLG_END_PAR_R6); _filler_12.ValueChanged += () => { _.Move(_filler_12, WS_IDLG_END_PAR_R6); }; return _filler_12; }
                        set { VarBasis.RedefinePassValue(value, _filler_12, WS_IDLG_END_PAR_R6); }
                    }  //Redefines
                    public class _REDEF_EM8006B_FILLER_12 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-R1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(15).*/

                        public _REDEF_EM8006B_FILLER_12()
                        {
                            WS_IDLG_END_PAR_R1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                    /*"      10 WS-IDLG-APO-END-R7 REDEFINES WS-IDLG-APO-END.*/

                    public _REDEF_EM8006B_WS_IDLG_APO_END_R6()
                    {
                        WS_IDLG_END_PRO_R6.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R6.ValueChanged += OnValueChanged;
                        FILLER_12.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_WS_IDLG_APO_END_R7 _ws_idlg_apo_end_r7 { get; set; }
                public _REDEF_EM8006B_WS_IDLG_APO_END_R7 WS_IDLG_APO_END_R7
                {
                    get { _ws_idlg_apo_end_r7 = new _REDEF_EM8006B_WS_IDLG_APO_END_R7(); _.Move(WS_IDLG_APO_END, _ws_idlg_apo_end_r7); VarBasis.RedefinePassValue(WS_IDLG_APO_END, _ws_idlg_apo_end_r7, WS_IDLG_APO_END); _ws_idlg_apo_end_r7.ValueChanged += () => { _.Move(_ws_idlg_apo_end_r7, WS_IDLG_APO_END); }; return _ws_idlg_apo_end_r7; }
                    set { VarBasis.RedefinePassValue(value, _ws_idlg_apo_end_r7, WS_IDLG_APO_END); }
                }  //Redefines
                public class _REDEF_EM8006B_WS_IDLG_APO_END_R7 : VarBasis
                {
                    /*"         15 WS-IDLG-END-PRO-R7    PIC 9(09).*/
                    public IntBasis WS_IDLG_END_PRO_R7 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                    /*"         15 WS-IDLG-END-PAR-R7    PIC 9(02).*/
                    public IntBasis WS_IDLG_END_PAR_R7 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"         15 FILLER REDEFINES WS-IDLG-END-PAR-R7.*/
                    private _REDEF_EM8006B_FILLER_14 _filler_14 { get; set; }
                    public _REDEF_EM8006B_FILLER_14 FILLER_14
                    {
                        get { _filler_14 = new _REDEF_EM8006B_FILLER_14(); _.Move(WS_IDLG_END_PAR_R7, _filler_14); VarBasis.RedefinePassValue(WS_IDLG_END_PAR_R7, _filler_14, WS_IDLG_END_PAR_R7); _filler_14.ValueChanged += () => { _.Move(_filler_14, WS_IDLG_END_PAR_R7); }; return _filler_14; }
                        set { VarBasis.RedefinePassValue(value, _filler_14, WS_IDLG_END_PAR_R7); }
                    }  //Redefines
                    public class _REDEF_EM8006B_FILLER_14 : VarBasis
                    {
                        /*"            20 WS-IDLG-END-PAR-R7-P1 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R7_P1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"            20 WS-IDLG-END-PAR-R7-P2 PIC 9(01).*/
                        public IntBasis WS_IDLG_END_PAR_R7_P2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                        /*"         15 FILLER                PIC X(16).*/

                        public _REDEF_EM8006B_FILLER_14()
                        {
                            WS_IDLG_END_PAR_R7_P1.ValueChanged += OnValueChanged;
                            WS_IDLG_END_PAR_R7_P2.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
                    /*"  03        WS-IDLG-VIDA        PIC  X(040).*/

                    public _REDEF_EM8006B_WS_IDLG_APO_END_R7()
                    {
                        WS_IDLG_END_PRO_R7.ValueChanged += OnValueChanged;
                        WS_IDLG_END_PAR_R7.ValueChanged += OnValueChanged;
                        FILLER_14.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_EM8006B_WS_IDLG_DIRID_R1()
                {
                    WS_IDLG_EMP_SIS_TIP.ValueChanged += OnValueChanged;
                    WS_IDLG_APO_END.ValueChanged += OnValueChanged;
                    WS_IDLG_APO_END_R1.ValueChanged += OnValueChanged;
                }

            }
        }
        public StringBasis WS_IDLG_VIDA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-VIDA.*/
        private _REDEF_EM8006B_FILLER_16 _filler_16 { get; set; }
        public _REDEF_EM8006B_FILLER_16 FILLER_16
        {
            get { _filler_16 = new _REDEF_EM8006B_FILLER_16(); _.Move(WS_IDLG_VIDA, _filler_16); VarBasis.RedefinePassValue(WS_IDLG_VIDA, _filler_16, WS_IDLG_VIDA); _filler_16.ValueChanged += () => { _.Move(_filler_16, WS_IDLG_VIDA); }; return _filler_16; }
            set { VarBasis.RedefinePassValue(value, _filler_16, WS_IDLG_VIDA); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_16 : VarBasis
        {
            /*"     10     WS-IDLG-CONV        PIC  9(006).*/
            public IntBasis WS_IDLG_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NSA         PIC  9(006).*/
            public IntBasis WS_IDLG_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NRSEQ       PIC  9(008).*/
            public IntBasis WS_IDLG_NRSEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10     FILLER              PIC  X(020).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  03        WS-IDLG-1313        PIC  X(040).*/

            public _REDEF_EM8006B_FILLER_16()
            {
                WS_IDLG_CONV.ValueChanged += OnValueChanged;
                WS_IDLG_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_NRSEQ.ValueChanged += OnValueChanged;
                FILLER_17.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_1313 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-1313.*/
        private _REDEF_EM8006B_FILLER_18 _filler_18 { get; set; }
        public _REDEF_EM8006B_FILLER_18 FILLER_18
        {
            get { _filler_18 = new _REDEF_EM8006B_FILLER_18(); _.Move(WS_IDLG_1313, _filler_18); VarBasis.RedefinePassValue(WS_IDLG_1313, _filler_18, WS_IDLG_1313); _filler_18.ValueChanged += () => { _.Move(_filler_18, WS_IDLG_1313); }; return _filler_18; }
            set { VarBasis.RedefinePassValue(value, _filler_18, WS_IDLG_1313); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_18 : VarBasis
        {
            /*"     10     WS-IDLG-CONV-1313   PIC  9(006).*/
            public IntBasis WS_IDLG_CONV_1313 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NSA-1313    PIC  9(006).*/
            public IntBasis WS_IDLG_NSA_1313 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-NRSEQ-1313  PIC  9(009).*/
            public IntBasis WS_IDLG_NRSEQ_1313 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     FILLER              PIC  X(019).*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  03        WS-IDLG-BILHETE     PIC  X(040).*/

            public _REDEF_EM8006B_FILLER_18()
            {
                WS_IDLG_CONV_1313.ValueChanged += OnValueChanged;
                WS_IDLG_NSA_1313.ValueChanged += OnValueChanged;
                WS_IDLG_NRSEQ_1313.ValueChanged += OnValueChanged;
                FILLER_19.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_BILHETE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-BILHETE.*/
        private _REDEF_EM8006B_FILLER_20 _filler_20 { get; set; }
        public _REDEF_EM8006B_FILLER_20 FILLER_20
        {
            get { _filler_20 = new _REDEF_EM8006B_FILLER_20(); _.Move(WS_IDLG_BILHETE, _filler_20); VarBasis.RedefinePassValue(WS_IDLG_BILHETE, _filler_20, WS_IDLG_BILHETE); _filler_20.ValueChanged += () => { _.Move(_filler_20, WS_IDLG_BILHETE); }; return _filler_20; }
            set { VarBasis.RedefinePassValue(value, _filler_20, WS_IDLG_BILHETE); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_20 : VarBasis
        {
            /*"     10     WS-IDLG-BIL-CON     PIC  9(006).*/
            public IntBasis WS_IDLG_BIL_CON { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-BIL-NSA     PIC  9(006).*/
            public IntBasis WS_IDLG_BIL_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-BIL-BIL     PIC  9(015).*/
            public IntBasis WS_IDLG_BIL_BIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10     WS-IDLG-BIL-ESP     PIC  X(013).*/
            public StringBasis WS_IDLG_BIL_ESP { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
            /*"  03        WS-IDLG-DEMAIS      PIC  X(040).*/

            public _REDEF_EM8006B_FILLER_20()
            {
                WS_IDLG_BIL_CON.ValueChanged += OnValueChanged;
                WS_IDLG_BIL_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_BIL_BIL.ValueChanged += OnValueChanged;
                WS_IDLG_BIL_ESP.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_DEMAIS { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-DEMAIS.*/
        private _REDEF_EM8006B_FILLER_21 _filler_21 { get; set; }
        public _REDEF_EM8006B_FILLER_21 FILLER_21
        {
            get { _filler_21 = new _REDEF_EM8006B_FILLER_21(); _.Move(WS_IDLG_DEMAIS, _filler_21); VarBasis.RedefinePassValue(WS_IDLG_DEMAIS, _filler_21, WS_IDLG_DEMAIS); _filler_21.ValueChanged += () => { _.Move(_filler_21, WS_IDLG_DEMAIS); }; return _filler_21; }
            set { VarBasis.RedefinePassValue(value, _filler_21, WS_IDLG_DEMAIS); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_21 : VarBasis
        {
            /*"     10     WS-IDLG-DEM-CON     PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_CON { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-NSA     PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-APO     PIC  9(013).*/
            public IntBasis WS_IDLG_DEM_APO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10     WS-IDLG-DEM-END     PIC  9(009).*/
            public IntBasis WS_IDLG_DEM_END { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     WS-IDLG-DEM-PAR     PIC  9(004).*/
            public IntBasis WS_IDLG_DEM_PAR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10     FILLER              PIC  X(002).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03        WS-IDLG-DEMAIS-PARC PIC  X(040).*/

            public _REDEF_EM8006B_FILLER_21()
            {
                WS_IDLG_DEM_CON.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_APO.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_END.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_PAR.ValueChanged += OnValueChanged;
                FILLER_22.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_DEMAIS_PARC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-DEMAIS-PARC.*/
        private _REDEF_EM8006B_FILLER_23 _filler_23 { get; set; }
        public _REDEF_EM8006B_FILLER_23 FILLER_23
        {
            get { _filler_23 = new _REDEF_EM8006B_FILLER_23(); _.Move(WS_IDLG_DEMAIS_PARC, _filler_23); VarBasis.RedefinePassValue(WS_IDLG_DEMAIS_PARC, _filler_23, WS_IDLG_DEMAIS_PARC); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS_IDLG_DEMAIS_PARC); }; return _filler_23; }
            set { VarBasis.RedefinePassValue(value, _filler_23, WS_IDLG_DEMAIS_PARC); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_23 : VarBasis
        {
            /*"     10     WS-IDLG-DEM-CON-P   PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_CON_P { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-NSA-P   PIC  9(006).*/
            public IntBasis WS_IDLG_DEM_NSA_P { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-DEM-APO-P   PIC  9(015).*/
            public IntBasis WS_IDLG_DEM_APO_P { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10     WS-IDLG-DEM-END-P   PIC  9(009).*/
            public IntBasis WS_IDLG_DEM_END_P { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     WS-IDLG-DEM-PAR-P   PIC  9(004).*/
            public IntBasis WS_IDLG_DEM_PAR_P { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03        WS-IDLG-CHQ         PIC  X(040).*/

            public _REDEF_EM8006B_FILLER_23()
            {
                WS_IDLG_DEM_CON_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_NSA_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_APO_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_END_P.ValueChanged += OnValueChanged;
                WS_IDLG_DEM_PAR_P.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_CHQ { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-CHQ.*/
        private _REDEF_EM8006B_FILLER_24 _filler_24 { get; set; }
        public _REDEF_EM8006B_FILLER_24 FILLER_24
        {
            get { _filler_24 = new _REDEF_EM8006B_FILLER_24(); _.Move(WS_IDLG_CHQ, _filler_24); VarBasis.RedefinePassValue(WS_IDLG_CHQ, _filler_24, WS_IDLG_CHQ); _filler_24.ValueChanged += () => { _.Move(_filler_24, WS_IDLG_CHQ); }; return _filler_24; }
            set { VarBasis.RedefinePassValue(value, _filler_24, WS_IDLG_CHQ); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_24 : VarBasis
        {
            /*"     10     WS-IDLG-NROCHQ      PIC  9(009).*/
            public IntBasis WS_IDLG_NROCHQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     WS-IDLG-DVCHQ       PIC  9(001).*/
            public IntBasis WS_IDLG_DVCHQ { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"     10     FILLER              PIC  X(030).*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  03        WS-IDLG-CARTAO      PIC  X(040).*/

            public _REDEF_EM8006B_FILLER_24()
            {
                WS_IDLG_NROCHQ.ValueChanged += OnValueChanged;
                WS_IDLG_DVCHQ.ValueChanged += OnValueChanged;
                FILLER_25.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDLG_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"  03         FILLER REDEFINES    WS-IDLG-CARTAO.*/
        private _REDEF_EM8006B_FILLER_26 _filler_26 { get; set; }
        public _REDEF_EM8006B_FILLER_26 FILLER_26
        {
            get { _filler_26 = new _REDEF_EM8006B_FILLER_26(); _.Move(WS_IDLG_CARTAO, _filler_26); VarBasis.RedefinePassValue(WS_IDLG_CARTAO, _filler_26, WS_IDLG_CARTAO); _filler_26.ValueChanged += () => { _.Move(_filler_26, WS_IDLG_CARTAO); }; return _filler_26; }
            set { VarBasis.RedefinePassValue(value, _filler_26, WS_IDLG_CARTAO); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_26 : VarBasis
        {
            /*"     10     WS-IDLG-CAR-CONV    PIC  9(006).*/
            public IntBasis WS_IDLG_CAR_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-CAR-NSA     PIC  9(006).*/
            public IntBasis WS_IDLG_CAR_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10     WS-IDLG-CAR-NRSEQ   PIC  9(009).*/
            public IntBasis WS_IDLG_CAR_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10     FILLER              PIC  X(019).*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  03         WS-OCORR           PIC  X(010).*/

            public _REDEF_EM8006B_FILLER_26()
            {
                WS_IDLG_CAR_CONV.ValueChanged += OnValueChanged;
                WS_IDLG_CAR_NSA.ValueChanged += OnValueChanged;
                WS_IDLG_CAR_NRSEQ.ValueChanged += OnValueChanged;
                FILLER_27.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_OCORR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"  03          FILLER REDEFINES    WS-OCORR.*/
        private _REDEF_EM8006B_FILLER_28 _filler_28 { get; set; }
        public _REDEF_EM8006B_FILLER_28 FILLER_28
        {
            get { _filler_28 = new _REDEF_EM8006B_FILLER_28(); _.Move(WS_OCORR, _filler_28); VarBasis.RedefinePassValue(WS_OCORR, _filler_28, WS_OCORR); _filler_28.ValueChanged += () => { _.Move(_filler_28, WS_OCORR); }; return _filler_28; }
            set { VarBasis.RedefinePassValue(value, _filler_28, WS_OCORR); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_28 : VarBasis
        {
            /*"     10      WS-OCORR1          PIC  X(002).*/
            public StringBasis WS_OCORR1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR2          PIC  X(002).*/
            public StringBasis WS_OCORR2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR3          PIC  X(002).*/
            public StringBasis WS_OCORR3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR4          PIC  X(002).*/
            public StringBasis WS_OCORR4 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"     10      WS-OCORR5          PIC  X(002).*/
            public StringBasis WS_OCORR5 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-PROPOSTA       PIC   9(014).*/

            public _REDEF_EM8006B_FILLER_28()
            {
                WS_OCORR1.ValueChanged += OnValueChanged;
                WS_OCORR2.ValueChanged += OnValueChanged;
                WS_OCORR3.ValueChanged += OnValueChanged;
                WS_OCORR4.ValueChanged += OnValueChanged;
                WS_OCORR5.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"  03         FILLER            REDEFINES      WS-PROPOSTA.*/
        private _REDEF_EM8006B_FILLER_29 _filler_29 { get; set; }
        public _REDEF_EM8006B_FILLER_29 FILLER_29
        {
            get { _filler_29 = new _REDEF_EM8006B_FILLER_29(); _.Move(WS_PROPOSTA, _filler_29); VarBasis.RedefinePassValue(WS_PROPOSTA, _filler_29, WS_PROPOSTA); _filler_29.ValueChanged += () => { _.Move(_filler_29, WS_PROPOSTA); }; return _filler_29; }
            set { VarBasis.RedefinePassValue(value, _filler_29, WS_PROPOSTA); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_29 : VarBasis
        {
            /*"    05       WS-PROPOS1        PIC   9(013).*/
            public IntBasis WS_PROPOS1 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    05       FILLER            PIC   9(001).*/
            public IntBasis FILLER_30 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03         WS-NUMALFA        PIC   X(013).*/

            public _REDEF_EM8006B_FILLER_29()
            {
                WS_PROPOS1.ValueChanged += OnValueChanged;
                FILLER_30.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_NUMALFA { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
        /*"  03         FILLER            REDEFINES      WS-NUMALFA.*/
        private _REDEF_EM8006B_FILLER_31 _filler_31 { get; set; }
        public _REDEF_EM8006B_FILLER_31 FILLER_31
        {
            get { _filler_31 = new _REDEF_EM8006B_FILLER_31(); _.Move(WS_NUMALFA, _filler_31); VarBasis.RedefinePassValue(WS_NUMALFA, _filler_31, WS_NUMALFA); _filler_31.ValueChanged += () => { _.Move(_filler_31, WS_NUMALFA); }; return _filler_31; }
            set { VarBasis.RedefinePassValue(value, _filler_31, WS_NUMALFA); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_31 : VarBasis
        {
            /*"    05       TB-NUMALFA        OCCURS         13 TIMES                               INDEXED  BY    WS-ALF.*/
            public ListBasis<EM8006B_TB_NUMALFA> TB_NUMALFA { get; set; } = new ListBasis<EM8006B_TB_NUMALFA>(13);
            public class EM8006B_TB_NUMALFA : VarBasis
            {
                /*"     10      WS-ALFA01          PIC  X(001).*/
                public StringBasis WS_ALFA01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WS-NUMBETA        PIC   9(013).*/

                public EM8006B_TB_NUMALFA()
                {
                    WS_ALFA01.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_EM8006B_FILLER_31()
            {
                TB_NUMALFA.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_NUMBETA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
        /*"  03         FILLER            REDEFINES      WS-NUMBETA.*/
        private _REDEF_EM8006B_FILLER_32 _filler_32 { get; set; }
        public _REDEF_EM8006B_FILLER_32 FILLER_32
        {
            get { _filler_32 = new _REDEF_EM8006B_FILLER_32(); _.Move(WS_NUMBETA, _filler_32); VarBasis.RedefinePassValue(WS_NUMBETA, _filler_32, WS_NUMBETA); _filler_32.ValueChanged += () => { _.Move(_filler_32, WS_NUMBETA); }; return _filler_32; }
            set { VarBasis.RedefinePassValue(value, _filler_32, WS_NUMBETA); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_32 : VarBasis
        {
            /*"    05       TB-NUMBETA        OCCURS         13 TIMES                               INDEXED  BY    WS-BET.*/
            public ListBasis<EM8006B_TB_NUMBETA> TB_NUMBETA { get; set; } = new ListBasis<EM8006B_TB_NUMBETA>(13);
            public class EM8006B_TB_NUMBETA : VarBasis
            {
                /*"     10      WS-BETA01          PIC  X(001).*/
                public StringBasis WS_BETA01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WS-IDTCLIDET3      PIC  X(025).*/

                public EM8006B_TB_NUMBETA()
                {
                    WS_BETA01.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_EM8006B_FILLER_32()
            {
                TB_NUMBETA.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIDET3 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIDET3.*/
        private _REDEF_EM8006B_FILLER_33 _filler_33 { get; set; }
        public _REDEF_EM8006B_FILLER_33 FILLER_33
        {
            get { _filler_33 = new _REDEF_EM8006B_FILLER_33(); _.Move(WS_IDTCLIDET3, _filler_33); VarBasis.RedefinePassValue(WS_IDTCLIDET3, _filler_33, WS_IDTCLIDET3); _filler_33.ValueChanged += () => { _.Move(_filler_33, WS_IDTCLIDET3); }; return _filler_33; }
            set { VarBasis.RedefinePassValue(value, _filler_33, WS_IDTCLIDET3); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_33 : VarBasis
        {
            /*"    10       MOVCC-ANO-DET3     PIC  9(004).*/
            public IntBasis MOVCC_ANO_DET3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       MOVCC-MES-DET3     PIC  9(002).*/
            public IntBasis MOVCC_MES_DET3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       MOVCC-DIA-DET3     PIC  9(002).*/
            public IntBasis MOVCC_DIA_DET3 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER             PIC  X(017).*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  03         WS-IDTCLIEMP       PIC  X(025).*/

            public _REDEF_EM8006B_FILLER_33()
            {
                MOVCC_ANO_DET3.ValueChanged += OnValueChanged;
                MOVCC_MES_DET3.ValueChanged += OnValueChanged;
                MOVCC_DIA_DET3.ValueChanged += OnValueChanged;
                FILLER_34.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP.*/
        private _REDEF_EM8006B_FILLER_35 _filler_35 { get; set; }
        public _REDEF_EM8006B_FILLER_35 FILLER_35
        {
            get { _filler_35 = new _REDEF_EM8006B_FILLER_35(); _.Move(WS_IDTCLIEMP, _filler_35); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_35, WS_IDTCLIEMP); _filler_35.ValueChanged += () => { _.Move(_filler_35, WS_IDTCLIEMP); }; return _filler_35; }
            set { VarBasis.RedefinePassValue(value, _filler_35, WS_IDTCLIEMP); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_35 : VarBasis
        {
            /*"     10      WS-NUM-CERTIF      PIC  9(015).*/
            public IntBasis WS_NUM_CERTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10      WS-NUM-NSAS        PIC  9(005).*/
            public IntBasis WS_NUM_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"     10      FILLER             PIC  9(005).*/
            public IntBasis FILLER_36 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  03         WS-IDTCLIEMP-LOT   PIC  X(025).*/

            public _REDEF_EM8006B_FILLER_35()
            {
                WS_NUM_CERTIF.ValueChanged += OnValueChanged;
                WS_NUM_NSAS.ValueChanged += OnValueChanged;
                FILLER_36.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_LOT { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-LOT.*/
        private _REDEF_EM8006B_FILLER_37 _filler_37 { get; set; }
        public _REDEF_EM8006B_FILLER_37 FILLER_37
        {
            get { _filler_37 = new _REDEF_EM8006B_FILLER_37(); _.Move(WS_IDTCLIEMP_LOT, _filler_37); VarBasis.RedefinePassValue(WS_IDTCLIEMP_LOT, _filler_37, WS_IDTCLIEMP_LOT); _filler_37.ValueChanged += () => { _.Move(_filler_37, WS_IDTCLIEMP_LOT); }; return _filler_37; }
            set { VarBasis.RedefinePassValue(value, _filler_37, WS_IDTCLIEMP_LOT); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_37 : VarBasis
        {
            /*"     10      WS-CODFENAL        PIC  9(009).*/
            public IntBasis WS_CODFENAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10      WS-NRPARCEL        PIC  9(003).*/
            public IntBasis WS_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10      WS-NUMAPOL         PIC  9(013).*/
            public IntBasis WS_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  03         WS-IDTCLIEMP-RED   PIC  X(025).*/

            public _REDEF_EM8006B_FILLER_37()
            {
                WS_CODFENAL.ValueChanged += OnValueChanged;
                WS_NRPARCEL.ValueChanged += OnValueChanged;
                WS_NUMAPOL.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_RED { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-RED.*/
        private _REDEF_EM8006B_FILLER_38 _filler_38 { get; set; }
        public _REDEF_EM8006B_FILLER_38 FILLER_38
        {
            get { _filler_38 = new _REDEF_EM8006B_FILLER_38(); _.Move(WS_IDTCLIEMP_RED, _filler_38); VarBasis.RedefinePassValue(WS_IDTCLIEMP_RED, _filler_38, WS_IDTCLIEMP_RED); _filler_38.ValueChanged += () => { _.Move(_filler_38, WS_IDTCLIEMP_RED); }; return _filler_38; }
            set { VarBasis.RedefinePassValue(value, _filler_38, WS_IDTCLIEMP_RED); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_38 : VarBasis
        {
            /*"     10      WS-RED-NRAPOL      PIC  9(013).*/
            public IntBasis WS_RED_NRAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10      WS-RED-NRENDO      PIC  9(008).*/
            public IntBasis WS_RED_NRENDO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      WS-RED-NRPARC      PIC  9(004).*/
            public IntBasis WS_RED_NRPARC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03         WS-IDTCLIEMP-BI1   PIC  X(025).*/

            public _REDEF_EM8006B_FILLER_38()
            {
                WS_RED_NRAPOL.ValueChanged += OnValueChanged;
                WS_RED_NRENDO.ValueChanged += OnValueChanged;
                WS_RED_NRPARC.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_BI1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-BI1.*/
        private _REDEF_EM8006B_FILLER_39 _filler_39 { get; set; }
        public _REDEF_EM8006B_FILLER_39 FILLER_39
        {
            get { _filler_39 = new _REDEF_EM8006B_FILLER_39(); _.Move(WS_IDTCLIEMP_BI1, _filler_39); VarBasis.RedefinePassValue(WS_IDTCLIEMP_BI1, _filler_39, WS_IDTCLIEMP_BI1); _filler_39.ValueChanged += () => { _.Move(_filler_39, WS_IDTCLIEMP_BI1); }; return _filler_39; }
            set { VarBasis.RedefinePassValue(value, _filler_39, WS_IDTCLIEMP_BI1); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_39 : VarBasis
        {
            /*"     10      WS-BI1-NRAPOL      PIC  9(013).*/
            public IntBasis WS_BI1_NRAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10      WS-BI1-NRENDO      PIC  9(006).*/
            public IntBasis WS_BI1_NRENDO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BI1-NRPARC      PIC  9(002).*/
            public IntBasis WS_BI1_NRPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10      FILLER             PIC  X(004).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  03         WS-IDTCLIEMP-BI2   PIC  X(025).*/

            public _REDEF_EM8006B_FILLER_39()
            {
                WS_BI1_NRAPOL.ValueChanged += OnValueChanged;
                WS_BI1_NRENDO.ValueChanged += OnValueChanged;
                WS_BI1_NRPARC.ValueChanged += OnValueChanged;
                FILLER_40.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_BI2 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-BI2.*/
        private _REDEF_EM8006B_FILLER_41 _filler_41 { get; set; }
        public _REDEF_EM8006B_FILLER_41 FILLER_41
        {
            get { _filler_41 = new _REDEF_EM8006B_FILLER_41(); _.Move(WS_IDTCLIEMP_BI2, _filler_41); VarBasis.RedefinePassValue(WS_IDTCLIEMP_BI2, _filler_41, WS_IDTCLIEMP_BI2); _filler_41.ValueChanged += () => { _.Move(_filler_41, WS_IDTCLIEMP_BI2); }; return _filler_41; }
            set { VarBasis.RedefinePassValue(value, _filler_41, WS_IDTCLIEMP_BI2); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_41 : VarBasis
        {
            /*"     10      WS-BI2-NUMBIL      PIC  9(015).*/
            public IntBasis WS_BI2_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10      FILLER             PIC  X(010).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         WS-IDTCLIEMP-BI3   PIC  X(025).*/

            public _REDEF_EM8006B_FILLER_41()
            {
                WS_BI2_NUMBIL.ValueChanged += OnValueChanged;
                FILLER_42.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_IDTCLIEMP_BI3 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
        /*"  03          FILLER REDEFINES    WS-IDTCLIEMP-BI3.*/
        private _REDEF_EM8006B_FILLER_43 _filler_43 { get; set; }
        public _REDEF_EM8006B_FILLER_43 FILLER_43
        {
            get { _filler_43 = new _REDEF_EM8006B_FILLER_43(); _.Move(WS_IDTCLIEMP_BI3, _filler_43); VarBasis.RedefinePassValue(WS_IDTCLIEMP_BI3, _filler_43, WS_IDTCLIEMP_BI3); _filler_43.ValueChanged += () => { _.Move(_filler_43, WS_IDTCLIEMP_BI3); }; return _filler_43; }
            set { VarBasis.RedefinePassValue(value, _filler_43, WS_IDTCLIEMP_BI3); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_43 : VarBasis
        {
            /*"     10      WS-BI3-NRAPOL      PIC  9(015).*/
            public IntBasis WS_BI3_NRAPOL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"     10      WS-BI3-NRENDO      PIC  9(006).*/
            public IntBasis WS_BI3_NRENDO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BI3-NRPARC      PIC  9(002).*/
            public IntBasis WS_BI3_NRPARC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10      FILLER             PIC  X(002).*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-NSL             PIC  9(005).*/

            public _REDEF_EM8006B_FILLER_43()
            {
                WS_BI3_NRAPOL.ValueChanged += OnValueChanged;
                WS_BI3_NRENDO.ValueChanged += OnValueChanged;
                WS_BI3_NRPARC.ValueChanged += OnValueChanged;
                FILLER_44.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
        /*"  03          FILLER REDEFINES    WS-NSL.*/
        private _REDEF_EM8006B_FILLER_45 _filler_45 { get; set; }
        public _REDEF_EM8006B_FILLER_45 FILLER_45
        {
            get { _filler_45 = new _REDEF_EM8006B_FILLER_45(); _.Move(WS_NSL, _filler_45); VarBasis.RedefinePassValue(WS_NSL, _filler_45, WS_NSL); _filler_45.ValueChanged += () => { _.Move(_filler_45, WS_NSL); }; return _filler_45; }
            set { VarBasis.RedefinePassValue(value, _filler_45, WS_NSL); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_45 : VarBasis
        {
            /*"     10      WS-NSL1            PIC  9(002).*/
            public IntBasis WS_NSL1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10      WS-NSL2            PIC  9(003).*/
            public IntBasis WS_NSL2 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  03         WS-USOEMPRESA      PIC  X(060).*/

            public _REDEF_EM8006B_FILLER_45()
            {
                WS_NSL1.ValueChanged += OnValueChanged;
                WS_NSL2.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPRESA.*/
        private _REDEF_EM8006B_FILLER_46 _filler_46 { get; set; }
        public _REDEF_EM8006B_FILLER_46 FILLER_46
        {
            get { _filler_46 = new _REDEF_EM8006B_FILLER_46(); _.Move(WS_USOEMPRESA, _filler_46); VarBasis.RedefinePassValue(WS_USOEMPRESA, _filler_46, WS_USOEMPRESA); _filler_46.ValueChanged += () => { _.Move(_filler_46, WS_USOEMPRESA); }; return _filler_46; }
            set { VarBasis.RedefinePassValue(value, _filler_46, WS_USOEMPRESA); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_46 : VarBasis
        {
            /*"     10      WS-NUM-NSL         PIC  9(003).*/
            public IntBasis WS_NUM_NSL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10      WS-NUM-NRSEQ       PIC  9(008).*/
            public IntBasis WS_NUM_NRSEQ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      FILLER             PIC  X(049).*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)."), @"");
            /*"  03         WS-USOEMPR-BIL     PIC  X(060).*/

            public _REDEF_EM8006B_FILLER_46()
            {
                WS_NUM_NSL.ValueChanged += OnValueChanged;
                WS_NUM_NRSEQ.ValueChanged += OnValueChanged;
                FILLER_47.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPR_BIL { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPR-BIL.*/
        private _REDEF_EM8006B_FILLER_48 _filler_48 { get; set; }
        public _REDEF_EM8006B_FILLER_48 FILLER_48
        {
            get { _filler_48 = new _REDEF_EM8006B_FILLER_48(); _.Move(WS_USOEMPR_BIL, _filler_48); VarBasis.RedefinePassValue(WS_USOEMPR_BIL, _filler_48, WS_USOEMPR_BIL); _filler_48.ValueChanged += () => { _.Move(_filler_48, WS_USOEMPR_BIL); }; return _filler_48; }
            set { VarBasis.RedefinePassValue(value, _filler_48, WS_USOEMPR_BIL); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_48 : VarBasis
        {
            /*"     10      WS-BIL-CODCONV     PIC  9(006).*/
            public IntBasis WS_BIL_CODCONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BIL-NSAS        PIC  9(006).*/
            public IntBasis WS_BIL_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-BIL-NUMREQ      PIC  9(006).*/
            public IntBasis WS_BIL_NUMREQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      FILLER             PIC  X(042).*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
            /*"  03         WS-USOEMPR-CHQ     PIC  X(060).*/

            public _REDEF_EM8006B_FILLER_48()
            {
                WS_BIL_CODCONV.ValueChanged += OnValueChanged;
                WS_BIL_NSAS.ValueChanged += OnValueChanged;
                WS_BIL_NUMREQ.ValueChanged += OnValueChanged;
                FILLER_49.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPR_CHQ { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPR-CHQ.*/
        private _REDEF_EM8006B_FILLER_50 _filler_50 { get; set; }
        public _REDEF_EM8006B_FILLER_50 FILLER_50
        {
            get { _filler_50 = new _REDEF_EM8006B_FILLER_50(); _.Move(WS_USOEMPR_CHQ, _filler_50); VarBasis.RedefinePassValue(WS_USOEMPR_CHQ, _filler_50, WS_USOEMPR_CHQ); _filler_50.ValueChanged += () => { _.Move(_filler_50, WS_USOEMPR_CHQ); }; return _filler_50; }
            set { VarBasis.RedefinePassValue(value, _filler_50, WS_USOEMPR_CHQ); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_50 : VarBasis
        {
            /*"     10      WS-CHQ-CODCONV     PIC  9(006).*/
            public IntBasis WS_CHQ_CODCONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-CHQ-NSAS        PIC  9(006).*/
            public IntBasis WS_CHQ_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-CHQ-NUMREQ      PIC  9(006).*/
            public IntBasis WS_CHQ_NUMREQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-CHQ-CODPROD     PIC  9(004).*/
            public IntBasis WS_CHQ_CODPROD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10      WS-CHQ-OCMOVTO     PIC  9(009).*/
            public IntBasis WS_CHQ_OCMOVTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"     10      FILLER             PIC  X(029).*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)."), @"");
            /*"  03         WS-USOEMPR-LOT     PIC  X(060).*/

            public _REDEF_EM8006B_FILLER_50()
            {
                WS_CHQ_CODCONV.ValueChanged += OnValueChanged;
                WS_CHQ_NSAS.ValueChanged += OnValueChanged;
                WS_CHQ_NUMREQ.ValueChanged += OnValueChanged;
                WS_CHQ_CODPROD.ValueChanged += OnValueChanged;
                WS_CHQ_OCMOVTO.ValueChanged += OnValueChanged;
                FILLER_51.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_USOEMPR_LOT { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
        /*"  03          FILLER REDEFINES    WS-USOEMPR-LOT.*/
        private _REDEF_EM8006B_FILLER_52 _filler_52 { get; set; }
        public _REDEF_EM8006B_FILLER_52 FILLER_52
        {
            get { _filler_52 = new _REDEF_EM8006B_FILLER_52(); _.Move(WS_USOEMPR_LOT, _filler_52); VarBasis.RedefinePassValue(WS_USOEMPR_LOT, _filler_52, WS_USOEMPR_LOT); _filler_52.ValueChanged += () => { _.Move(_filler_52, WS_USOEMPR_LOT); }; return _filler_52; }
            set { VarBasis.RedefinePassValue(value, _filler_52, WS_USOEMPR_LOT); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_52 : VarBasis
        {
            /*"     10      WS-LOT-NSA         PIC  9(006).*/
            public IntBasis WS_LOT_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-LOT-NSL         PIC  9(006).*/
            public IntBasis WS_LOT_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"     10      WS-LOT-NUMLAC      PIC  9(013).*/
            public IntBasis WS_LOT_NUMLAC { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"     10      WS-LOT-CODPRODU    PIC  9(004).*/
            public IntBasis WS_LOT_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"     10      WS-LOT-NRENDOS     PIC  9(008).*/
            public IntBasis WS_LOT_NRENDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      WS-LOT-CODCOBER    PIC  9(003).*/
            public IntBasis WS_LOT_CODCOBER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"     10      WS-LOT-NUMFATUR    PIC  9(008).*/
            public IntBasis WS_LOT_NUMFATUR { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"     10      WS-LOT-DATADEB     PIC  X(010).*/
            public StringBasis WS_LOT_DATADEB { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"     10      WS-LOT-TPREG       PIC  X(002).*/
            public StringBasis WS_LOT_TPREG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03        WS-DATA-SAP.*/

            public _REDEF_EM8006B_FILLER_52()
            {
                WS_LOT_NSA.ValueChanged += OnValueChanged;
                WS_LOT_NSL.ValueChanged += OnValueChanged;
                WS_LOT_NUMLAC.ValueChanged += OnValueChanged;
                WS_LOT_CODPRODU.ValueChanged += OnValueChanged;
                WS_LOT_NRENDOS.ValueChanged += OnValueChanged;
                WS_LOT_CODCOBER.ValueChanged += OnValueChanged;
                WS_LOT_NUMFATUR.ValueChanged += OnValueChanged;
                WS_LOT_DATADEB.ValueChanged += OnValueChanged;
                WS_LOT_TPREG.ValueChanged += OnValueChanged;
            }

        }
        public EM8006B_WS_DATA_SAP WS_DATA_SAP { get; set; } = new EM8006B_WS_DATA_SAP();
        public class EM8006B_WS_DATA_SAP : VarBasis
        {
            /*"     10     WS-DD-SAP           PIC  9(002).*/
            public IntBasis WS_DD_SAP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-MM-SAP           PIC  9(002).*/
            public IntBasis WS_MM_SAP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-AA-SAP           PIC  9(004).*/
            public IntBasis WS_AA_SAP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03        WS-DATA-SAP1.*/
        }
        public EM8006B_WS_DATA_SAP1 WS_DATA_SAP1 { get; set; } = new EM8006B_WS_DATA_SAP1();
        public class EM8006B_WS_DATA_SAP1 : VarBasis
        {
            /*"     10     WS-DD-SAP1          PIC  9(002).*/
            public IntBasis WS_DD_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-MM-SAP1          PIC  9(002).*/
            public IntBasis WS_MM_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-SS-SAP1          PIC  9(002).*/
            public IntBasis WS_SS_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"     10     WS-AA-SAP1          PIC  9(002).*/
            public IntBasis WS_AA_SAP1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
        }
        public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
        /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
        private _REDEF_EM8006B_FILLER_53 _filler_53 { get; set; }
        public _REDEF_EM8006B_FILLER_53 FILLER_53
        {
            get { _filler_53 = new _REDEF_EM8006B_FILLER_53(); _.Move(WTIME_DAY, _filler_53); VarBasis.RedefinePassValue(WTIME_DAY, _filler_53, WTIME_DAY); _filler_53.ValueChanged += () => { _.Move(_filler_53, WTIME_DAY); }; return _filler_53; }
            set { VarBasis.RedefinePassValue(value, _filler_53, WTIME_DAY); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_53 : VarBasis
        {
            /*"    05       WTIME-DAYR.*/
            public EM8006B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM8006B_WTIME_DAYR();
            public class EM8006B_WTIME_DAYR : VarBasis
            {
                /*"      10     WTIME-HORA         PIC  X(002).*/
                public StringBasis WTIME_HORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-2PT1         PIC  X(001).*/
                public StringBasis WTIME_2PT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WTIME-MINU         PIC  X(002).*/
                public StringBasis WTIME_MINU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10     WTIME-2PT2         PIC  X(001).*/
                public StringBasis WTIME_2PT2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WTIME-SEGU         PIC  X(002).*/
                public StringBasis WTIME_SEGU { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       WTIME-2PT3         PIC  X(001).*/

                public EM8006B_WTIME_DAYR()
                {
                    WTIME_HORA.ValueChanged += OnValueChanged;
                    WTIME_2PT1.ValueChanged += OnValueChanged;
                    WTIME_MINU.ValueChanged += OnValueChanged;
                    WTIME_2PT2.ValueChanged += OnValueChanged;
                    WTIME_SEGU.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WTIME_2PT3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05       WTIME-CCSE         PIC  X(002).*/
            public StringBasis WTIME_CCSE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03         WS-VLR-AUX         PIC  S9(13)V99 USAGE COMP-3.*/

            public _REDEF_EM8006B_FILLER_53()
            {
                WTIME_DAYR.ValueChanged += OnValueChanged;
                WTIME_2PT3.ValueChanged += OnValueChanged;
                WTIME_CCSE.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis WS_VLR_AUX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"  03         WS-TIME-SQL         PIC  X(08).*/
        public StringBasis WS_TIME_SQL { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"  03          FILLER REDEFINES    WS-TIME-SQL.*/
        private _REDEF_EM8006B_FILLER_54 _filler_54 { get; set; }
        public _REDEF_EM8006B_FILLER_54 FILLER_54
        {
            get { _filler_54 = new _REDEF_EM8006B_FILLER_54(); _.Move(WS_TIME_SQL, _filler_54); VarBasis.RedefinePassValue(WS_TIME_SQL, _filler_54, WS_TIME_SQL); _filler_54.ValueChanged += () => { _.Move(_filler_54, WS_TIME_SQL); }; return _filler_54; }
            set { VarBasis.RedefinePassValue(value, _filler_54, WS_TIME_SQL); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_54 : VarBasis
        {
            /*"     10      WS-HH-SQL           PIC  9(02).*/
            public IntBasis WS_HH_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-HH-PTO1          PIC  X(01).*/
            public StringBasis WS_HH_PTO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     10      WS-MM-SQL           PIC  9(02).*/
            public IntBasis WS_MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-HH-PTO2          PIC  X(01).*/
            public StringBasis WS_HH_PTO2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"     10      WS-SS-SQL           PIC  9(02).*/
            public IntBasis WS_SS_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  03         WS-TIME             PIC  X(06).*/

            public _REDEF_EM8006B_FILLER_54()
            {
                WS_HH_SQL.ValueChanged += OnValueChanged;
                WS_HH_PTO1.ValueChanged += OnValueChanged;
                WS_MM_SQL.ValueChanged += OnValueChanged;
                WS_HH_PTO2.ValueChanged += OnValueChanged;
                WS_SS_SQL.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
        /*"  03          FILLER REDEFINES    WS-TIME.*/
        private _REDEF_EM8006B_FILLER_55 _filler_55 { get; set; }
        public _REDEF_EM8006B_FILLER_55 FILLER_55
        {
            get { _filler_55 = new _REDEF_EM8006B_FILLER_55(); _.Move(WS_TIME, _filler_55); VarBasis.RedefinePassValue(WS_TIME, _filler_55, WS_TIME); _filler_55.ValueChanged += () => { _.Move(_filler_55, WS_TIME); }; return _filler_55; }
            set { VarBasis.RedefinePassValue(value, _filler_55, WS_TIME); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_55 : VarBasis
        {
            /*"     10      WS-HH               PIC  9(02).*/
            public IntBasis WS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-MM               PIC  9(02).*/
            public IntBasis WS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"     10      WS-SS               PIC  9(02).*/
            public IntBasis WS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/

            public _REDEF_EM8006B_FILLER_55()
            {
                WS_HH.ValueChanged += OnValueChanged;
                WS_MM.ValueChanged += OnValueChanged;
                WS_SS.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"  03         FILLER             REDEFINES      WDATA-REL.*/
        private _REDEF_EM8006B_FILLER_56 _filler_56 { get; set; }
        public _REDEF_EM8006B_FILLER_56 FILLER_56
        {
            get { _filler_56 = new _REDEF_EM8006B_FILLER_56(); _.Move(WDATA_REL, _filler_56); VarBasis.RedefinePassValue(WDATA_REL, _filler_56, WDATA_REL); _filler_56.ValueChanged += () => { _.Move(_filler_56, WDATA_REL); }; return _filler_56; }
            set { VarBasis.RedefinePassValue(value, _filler_56, WDATA_REL); }
        }  //Redefines
        public class _REDEF_EM8006B_FILLER_56 : VarBasis
        {
            /*"    10       WDAT-REL-ANO       PIC  9(004).*/
            public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       WDAT-REL-HIFEN-1   PIC  X(001).*/
            public StringBasis WDAT_REL_HIFEN_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDAT-REL-MES       PIC  9(002).*/
            public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       WDAT-REL-HIFEN-2   PIC  X(001).*/
            public StringBasis WDAT_REL_HIFEN_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       WDAT-REL-DIA       PIC  9(002).*/
            public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03         WDATA-SQL.*/

            public _REDEF_EM8006B_FILLER_56()
            {
                WDAT_REL_ANO.ValueChanged += OnValueChanged;
                WDAT_REL_HIFEN_1.ValueChanged += OnValueChanged;
                WDAT_REL_MES.ValueChanged += OnValueChanged;
                WDAT_REL_HIFEN_2.ValueChanged += OnValueChanged;
                WDAT_REL_DIA.ValueChanged += OnValueChanged;
            }

        }
        public EM8006B_WDATA_SQL WDATA_SQL { get; set; } = new EM8006B_WDATA_SQL();
        public class EM8006B_WDATA_SQL : VarBasis
        {
            /*"    05       WDATA-AA-SQL      PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WDATA_AA_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '-'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05       WDATA-MM-SQL      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_MM_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '-'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"    05       WDATA-DD-SQL      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_DD_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03         WDATA-CABEC.*/
        }
        public EM8006B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8006B_WDATA_CABEC();
        public class EM8006B_WDATA_CABEC : VarBasis
        {
            /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
            public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"01 WS-NUM-OCORR-MOVTO          PIC S9(18)V USAGE COMP-3.*/
        }
        public DoubleBasis WS_NUM_OCORR_MOVTO { get; set; } = new DoubleBasis(new PIC("S9", "18", "S9(18)V"), 0);
        /*"01  ABEN.*/
        public EM8006B_ABEN ABEN { get; set; } = new EM8006B_ABEN();
        public class EM8006B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8006B_WABEND WABEND { get; set; } = new EM8006B_WABEND();
            public class EM8006B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8006B  '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8006B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8006B_WABEND1 WABEND1 { get; set; } = new EM8006B_WABEND1();
            public class EM8006B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          HEA-REGISTRO.*/
            }
        }
        public EM8006B_HEA_REGISTRO HEA_REGISTRO { get; set; } = new EM8006B_HEA_REGISTRO();
        public class EM8006B_HEA_REGISTRO : VarBasis
        {
            /*"  05        HEA-TIPREG             PIC  9(002).*/
            public IntBasis HEA_TIPREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        HEA-SEQREG             PIC  9(009).*/
            public IntBasis HEA_SEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        HEA-DATPRO             PIC  X(008).*/
            public StringBasis HEA_DATPRO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        HEA-EMPRESA            PIC  X(004).*/
            public StringBasis HEA_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05        HEA-NSASAP             PIC  9(009).*/
            public IntBasis HEA_NSASAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        FILLER                 PIC  X(468).*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "468", "X(468)."), @"");
            /*"01          DET-REGISTRO.*/
        }
        public EM8006B_DET_REGISTRO DET_REGISTRO { get; set; } = new EM8006B_DET_REGISTRO();
        public class EM8006B_DET_REGISTRO : VarBasis
        {
            /*"  05        DET-TIPREG             PIC  9(002).*/
            public IntBasis DET_TIPREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        DET-SEQREG             PIC  9(009).*/
            public IntBasis DET_SEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        DET-IDLG               PIC  X(040).*/
            public StringBasis DET_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        DET-AUGST              PIC  X(001).*/
            public StringBasis DET_AUGST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05        DET-AUGRD              PIC  9(002).*/
            public IntBasis DET_AUGRD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        DET-BELNR              PIC  X(010).*/
            public StringBasis DET_BELNR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        DET-BUZEI              PIC  9(003).*/
            public IntBasis DET_BUZEI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05        DET-OPBEL              PIC  X(012).*/
            public StringBasis DET_OPBEL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"  05        DET-OPUPK              PIC  9(004).*/
            public IntBasis DET_OPUPK { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05        DET-AUGBL              PIC  X(012).*/
            public StringBasis DET_AUGBL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"  05        DET-AUGVD              PIC  9(008).*/
            public IntBasis DET_AUGVD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05        DET-BLART              PIC  X(002).*/
            public StringBasis DET_BLART { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        DET-BLDAT              PIC  X(008).*/
            public StringBasis DET_BLDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        DET-BUDAT              PIC  X(008).*/
            public StringBasis DET_BUDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        DET-BUKRS              PIC  X(004).*/
            public StringBasis DET_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05        DET-NSA-BCO            PIC  9(006).*/
            public IntBasis DET_NSA_BCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05        DET-REG1.*/
            public EM8006B_DET_REG1 DET_REG1 { get; set; } = new EM8006B_DET_REG1();
            public class EM8006B_DET_REG1 : VarBasis
            {
                /*"   10       DET1-CGCCPF            PIC  X(020).*/
                public StringBasis DET1_CGCCPF { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET1-EVENTO            PIC  X(010).*/
                public StringBasis DET1_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET1-VLR-BRUTO-RED     PIC  X(015)*/
                public StringBasis DET1_VLR_BRUTO_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"   10       DET1-VLR-BRUTO REDEFINES DET1-VLR-BRUTO-RED            PIC  9(013)V99.*/
                private _REDEF_DoubleBasis _det1_vlr_bruto { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_BRUTO
                {
                    get { _det1_vlr_bruto = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99."), 2); ; _.Move(DET1_VLR_BRUTO_RED, _det1_vlr_bruto); VarBasis.RedefinePassValue(DET1_VLR_BRUTO_RED, _det1_vlr_bruto, DET1_VLR_BRUTO_RED); _det1_vlr_bruto.ValueChanged += () => { _.Move(_det1_vlr_bruto, DET1_VLR_BRUTO_RED); }; return _det1_vlr_bruto; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_bruto, DET1_VLR_BRUTO_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-IRRF-RED          PIC  X(015)*/
                public StringBasis DET1_VLR_IRRF_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"   10       DET1-VLR-IRRF  REDEFINES DET1-VLR-IRRF-RED            PIC  9(013)V99*/
                private _REDEF_DoubleBasis _det1_vlr_irrf { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_IRRF
                {
                    get { _det1_vlr_irrf = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99"), 2); ; _.Move(DET1_VLR_IRRF_RED, _det1_vlr_irrf); VarBasis.RedefinePassValue(DET1_VLR_IRRF_RED, _det1_vlr_irrf, DET1_VLR_IRRF_RED); _det1_vlr_irrf.ValueChanged += () => { _.Move(_det1_vlr_irrf, DET1_VLR_IRRF_RED); }; return _det1_vlr_irrf; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_irrf, DET1_VLR_IRRF_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-ISS-RED           PIC  X(015)*/
                public StringBasis DET1_VLR_ISS_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"   10       DET1-VLR-ISS REDEFINES DET1-VLR-ISS-RED            PIC  9(013)V99.*/
                private _REDEF_DoubleBasis _det1_vlr_iss { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_ISS
                {
                    get { _det1_vlr_iss = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99."), 2); ; _.Move(DET1_VLR_ISS_RED, _det1_vlr_iss); VarBasis.RedefinePassValue(DET1_VLR_ISS_RED, _det1_vlr_iss, DET1_VLR_ISS_RED); _det1_vlr_iss.ValueChanged += () => { _.Move(_det1_vlr_iss, DET1_VLR_ISS_RED); }; return _det1_vlr_iss; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_iss, DET1_VLR_ISS_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-INSS-RED          PIC  X(015).*/
                public StringBasis DET1_VLR_INSS_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   10       DET1-VLR-INSS REDEFINES DET1-VLR-INSS-RED            PIC  9(013)V99*/
                private _REDEF_DoubleBasis _det1_vlr_inss { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_INSS
                {
                    get { _det1_vlr_inss = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99"), 2); ; _.Move(DET1_VLR_INSS_RED, _det1_vlr_inss); VarBasis.RedefinePassValue(DET1_VLR_INSS_RED, _det1_vlr_inss, DET1_VLR_INSS_RED); _det1_vlr_inss.ValueChanged += () => { _.Move(_det1_vlr_inss, DET1_VLR_INSS_RED); }; return _det1_vlr_inss; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_inss, DET1_VLR_INSS_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-COFINS-RED        PIC  X(015).*/
                public StringBasis DET1_VLR_COFINS_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   10       DET1-VLR-COFINS REDEFINES DET1-VLR-COFINS-RED            PIC  9(013)V99*/
                private _REDEF_DoubleBasis _det1_vlr_cofins { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_COFINS
                {
                    get { _det1_vlr_cofins = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99"), 2); ; _.Move(DET1_VLR_COFINS_RED, _det1_vlr_cofins); VarBasis.RedefinePassValue(DET1_VLR_COFINS_RED, _det1_vlr_cofins, DET1_VLR_COFINS_RED); _det1_vlr_cofins.ValueChanged += () => { _.Move(_det1_vlr_cofins, DET1_VLR_COFINS_RED); }; return _det1_vlr_cofins; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_cofins, DET1_VLR_COFINS_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-CSLL-RED          PIC  X(015).*/
                public StringBasis DET1_VLR_CSLL_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   10       DET1-VLR-CSLL REDEFINES DET1-VLR-CSLL-RED            PIC  9(013)V99*/
                private _REDEF_DoubleBasis _det1_vlr_csll { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_CSLL
                {
                    get { _det1_vlr_csll = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99"), 2); ; _.Move(DET1_VLR_CSLL_RED, _det1_vlr_csll); VarBasis.RedefinePassValue(DET1_VLR_CSLL_RED, _det1_vlr_csll, DET1_VLR_CSLL_RED); _det1_vlr_csll.ValueChanged += () => { _.Move(_det1_vlr_csll, DET1_VLR_CSLL_RED); }; return _det1_vlr_csll; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_csll, DET1_VLR_CSLL_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-PIS-RED           PIC  X(015).*/
                public StringBasis DET1_VLR_PIS_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   10       DET1-VLR-PIS REDEFINES DET1-VLR-PIS-RED            PIC  9(013)V99*/
                private _REDEF_DoubleBasis _det1_vlr_pis { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_PIS
                {
                    get { _det1_vlr_pis = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99"), 2); ; _.Move(DET1_VLR_PIS_RED, _det1_vlr_pis); VarBasis.RedefinePassValue(DET1_VLR_PIS_RED, _det1_vlr_pis, DET1_VLR_PIS_RED); _det1_vlr_pis.ValueChanged += () => { _.Move(_det1_vlr_pis, DET1_VLR_PIS_RED); }; return _det1_vlr_pis; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_pis, DET1_VLR_PIS_RED); }
                }  //Redefines
                /*"   10       DET1-VLR-PG-REC-RED        PIC  X(015).*/
                public StringBasis DET1_VLR_PG_REC_RED { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   10       DET1-VLR-PG-REC REDEFINES DET1-VLR-PG-REC-RED            PIC  9(013)V99*/
                private _REDEF_DoubleBasis _det1_vlr_pg_rec { get; set; }
                public _REDEF_DoubleBasis DET1_VLR_PG_REC
                {
                    get { _det1_vlr_pg_rec = new _REDEF_DoubleBasis(new PIC("9", "013", "9(013)V99"), 2); ; _.Move(DET1_VLR_PG_REC_RED, _det1_vlr_pg_rec); VarBasis.RedefinePassValue(DET1_VLR_PG_REC_RED, _det1_vlr_pg_rec, DET1_VLR_PG_REC_RED); _det1_vlr_pg_rec.ValueChanged += () => { _.Move(_det1_vlr_pg_rec, DET1_VLR_PG_REC_RED); }; return _det1_vlr_pg_rec; }
                    set { VarBasis.RedefinePassValue(value, _det1_vlr_pg_rec, DET1_VLR_PG_REC_RED); }
                }  //Redefines
                /*"   10       DET1-DT-MOVTO          PIC  X(008).*/
                public StringBasis DET1_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET1-DT-ENVIO          PIC  X(008).*/
                public StringBasis DET1_DT_ENVIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET1-DT-CONTABIL       PIC  X(008).*/
                public StringBasis DET1_DT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET1-MEIO-PAGTO        PIC  X(001).*/
                public StringBasis DET1_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10       DET1-NRO-CHQ-INT       PIC  X(013).*/
                public StringBasis DET1_NRO_CHQ_INT { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"   10       DET1-NRO-SIVAT         PIC  9(009).*/
                public IntBasis DET1_NRO_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"   10       DET1-OCORRENCIA        PIC  X(010).*/
                public StringBasis DET1_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       FILLER                 PIC  X(162).*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "162", "X(162)."), @"");
                /*"  05        DET-REG2     REDEFINES   DET-REG1.*/
            }
            private _REDEF_EM8006B_DET_REG2 _det_reg2 { get; set; }
            public _REDEF_EM8006B_DET_REG2 DET_REG2
            {
                get { _det_reg2 = new _REDEF_EM8006B_DET_REG2(); _.Move(DET_REG1, _det_reg2); VarBasis.RedefinePassValue(DET_REG1, _det_reg2, DET_REG1); _det_reg2.ValueChanged += () => { _.Move(_det_reg2, DET_REG1); }; return _det_reg2; }
                set { VarBasis.RedefinePassValue(value, _det_reg2, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG2 : VarBasis
            {
                /*"   10       DET2-DT-MOVTO           PIC  X(008).*/
                public StringBasis DET2_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET2-COD-CONV           PIC  9(006).*/
                public IntBasis DET2_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET2-COD-BCO            PIC  9(003).*/
                public IntBasis DET2_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET2-COD-AGE            PIC  9(005).*/
                public IntBasis DET2_COD_AGE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET2-DV-AGE             PIC  9(001).*/
                public IntBasis DET2_DV_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET2-OPCONTA.*/
                public EM8006B_DET2_OPCONTA DET2_OPCONTA { get; set; } = new EM8006B_DET2_OPCONTA();
                public class EM8006B_DET2_OPCONTA : VarBasis
                {
                    /*"     15     DET2-TIP-CONTA          PIC  9(004).*/
                    public IntBasis DET2_TIP_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"     15     DET2-NRO-CONTA          PIC  9(008).*/
                    public IntBasis DET2_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"   10       DET2-TESTE   REDEFINES  DET2-OPCONTA.*/

                    public EM8006B_DET2_OPCONTA()
                    {
                        DET2_TIP_CONTA.ValueChanged += OnValueChanged;
                        DET2_NRO_CONTA.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_DET2_TESTE _det2_teste { get; set; }
                public _REDEF_EM8006B_DET2_TESTE DET2_TESTE
                {
                    get { _det2_teste = new _REDEF_EM8006B_DET2_TESTE(); _.Move(DET2_OPCONTA, _det2_teste); VarBasis.RedefinePassValue(DET2_OPCONTA, _det2_teste, DET2_OPCONTA); _det2_teste.ValueChanged += () => { _.Move(_det2_teste, DET2_OPCONTA); }; return _det2_teste; }
                    set { VarBasis.RedefinePassValue(value, _det2_teste, DET2_OPCONTA); }
                }  //Redefines
                public class _REDEF_EM8006B_DET2_TESTE : VarBasis
                {
                    /*"     15     DET2-FILLER             PIC  9(003).*/
                    public IntBasis DET2_FILLER { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"     15     DET2-CONTA-TESTE        PIC  9(009).*/
                    public IntBasis DET2_CONTA_TESTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"   10       DET2-NSGD    REDEFINES  DET2-OPCONTA                                    PIC  9(012).*/

                    public _REDEF_EM8006B_DET2_TESTE()
                    {
                        DET2_FILLER.ValueChanged += OnValueChanged;
                        DET2_CONTA_TESTE.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_IntBasis _det2_nsgd { get; set; }
                public _REDEF_IntBasis DET2_NSGD
                {
                    get { _det2_nsgd = new _REDEF_IntBasis(new PIC("9", "012", "9(012).")); ; _.Move(DET2_OPCONTA, _det2_nsgd); VarBasis.RedefinePassValue(DET2_OPCONTA, _det2_nsgd, DET2_OPCONTA); _det2_nsgd.ValueChanged += () => { _.Move(_det2_nsgd, DET2_OPCONTA); }; return _det2_nsgd; }
                    set { VarBasis.RedefinePassValue(value, _det2_nsgd, DET2_OPCONTA); }
                }  //Redefines
                /*"   10       DET2-DV-CTA             PIC  9(001).*/
                public IntBasis DET2_DV_CTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET2-DT-EFETIV          PIC  X(008).*/
                public StringBasis DET2_DT_EFETIV { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET2-VLR-EFET           PIC  9(013)V99.*/
                public DoubleBasis DET2_VLR_EFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET2-OCORRENCIA         PIC  X(010).*/
                public StringBasis DET2_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET2-PROC-ADVERT        PIC  X(002).*/
                public StringBasis DET2_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET2-NIVE-ADVERT        PIC  X(002).*/
                public StringBasis DET2_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       FILLER                  PIC  X(296).*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "296", "X(296)."), @"");
                /*"  05        DET-REG3     REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG2()
                {
                    DET2_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET2_COD_CONV.ValueChanged += OnValueChanged;
                    DET2_COD_BCO.ValueChanged += OnValueChanged;
                    DET2_COD_AGE.ValueChanged += OnValueChanged;
                    DET2_DV_AGE.ValueChanged += OnValueChanged;
                    DET2_OPCONTA.ValueChanged += OnValueChanged;
                    DET2_TESTE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG3 _det_reg3 { get; set; }
            public _REDEF_EM8006B_DET_REG3 DET_REG3
            {
                get { _det_reg3 = new _REDEF_EM8006B_DET_REG3(); _.Move(DET_REG1, _det_reg3); VarBasis.RedefinePassValue(DET_REG1, _det_reg3, DET_REG1); _det_reg3.ValueChanged += () => { _.Move(_det_reg3, DET_REG1); }; return _det_reg3; }
                set { VarBasis.RedefinePassValue(value, _det_reg3, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG3 : VarBasis
            {
                /*"   10       DET3-DT-MOVTO           PIC  X(008).*/
                public StringBasis DET3_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET3-COD-CONV           PIC  9(004).*/
                public IntBasis DET3_COD_CONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET3-MOTIVO             PIC  X(002).*/
                public StringBasis DET3_MOTIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET3-COD-TRANS          PIC  9(003).*/
                public IntBasis DET3_COD_TRANS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET3-NRO-PARC           PIC  9(003).*/
                public IntBasis DET3_NRO_PARC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET3-NRO-CARTAO         PIC  X(019).*/
                public StringBasis DET3_NRO_CARTAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"   10       DET3-DT-VENCTO          PIC  X(008).*/
                public StringBasis DET3_DT_VENCTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET3-NOVO-NROCAR        PIC  X(019).*/
                public StringBasis DET3_NOVO_NROCAR { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"   10       DET3-NOVO-DIA-VENCTO    PIC  9(004).*/
                public IntBasis DET3_NOVO_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET3-DT-AGENDTO         PIC  X(008).*/
                public StringBasis DET3_DT_AGENDTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET3-MOTIVO-RET         PIC  X(002).*/
                public StringBasis DET3_MOTIVO_RET { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET3-MOTIVO-CANC        PIC  X(002).*/
                public StringBasis DET3_MOTIVO_CANC { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET3-VLR-CREDITO        PIC  9(013)V99.*/
                public DoubleBasis DET3_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET3-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET3_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET3-BANCO              PIC  9(003).*/
                public IntBasis DET3_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET3-AGENCIA            PIC  9(005).*/
                public IntBasis DET3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET3-CONTA              PIC  9(012).*/
                public IntBasis DET3_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"   10       DET3-VALOR              PIC  9(013)V99.*/
                public DoubleBasis DET3_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       FILLER                  PIC  X(222).*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "222", "X(222)."), @"");
                /*"  05        DET-REG4     REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG3()
                {
                    DET3_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET3_COD_CONV.ValueChanged += OnValueChanged;
                    DET3_MOTIVO.ValueChanged += OnValueChanged;
                    DET3_COD_TRANS.ValueChanged += OnValueChanged;
                    DET3_NRO_PARC.ValueChanged += OnValueChanged;
                    DET3_NRO_CARTAO.ValueChanged += OnValueChanged;
                    DET3_DT_VENCTO.ValueChanged += OnValueChanged;
                    DET3_NOVO_NROCAR.ValueChanged += OnValueChanged;
                    DET3_NOVO_DIA_VENCTO.ValueChanged += OnValueChanged;
                    DET3_DT_AGENDTO.ValueChanged += OnValueChanged;
                    DET3_MOTIVO_RET.ValueChanged += OnValueChanged;
                    DET3_MOTIVO_CANC.ValueChanged += OnValueChanged;
                    DET3_VLR_CREDITO.ValueChanged += OnValueChanged;
                    DET3_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET3_BANCO.ValueChanged += OnValueChanged;
                    DET3_AGENCIA.ValueChanged += OnValueChanged;
                    DET3_CONTA.ValueChanged += OnValueChanged;
                    DET3_VALOR.ValueChanged += OnValueChanged;
                    FILLER_69.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG4 _det_reg4 { get; set; }
            public _REDEF_EM8006B_DET_REG4 DET_REG4
            {
                get { _det_reg4 = new _REDEF_EM8006B_DET_REG4(); _.Move(DET_REG1, _det_reg4); VarBasis.RedefinePassValue(DET_REG1, _det_reg4, DET_REG1); _det_reg4.ValueChanged += () => { _.Move(_det_reg4, DET_REG1); }; return _det_reg4; }
                set { VarBasis.RedefinePassValue(value, _det_reg4, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG4 : VarBasis
            {
                /*"   10       DET4-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET4_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET4-COD-CONV           PIC  9(006).*/
                public IntBasis DET4_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET4-COD-BCO            PIC  9(003).*/
                public IntBasis DET4_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET4-COD-AGE            PIC  9(004).*/
                public IntBasis DET4_COD_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET4-OPCONTA.*/
                public EM8006B_DET4_OPCONTA DET4_OPCONTA { get; set; } = new EM8006B_DET4_OPCONTA();
                public class EM8006B_DET4_OPCONTA : VarBasis
                {
                    /*"     15     DET4-TIP-CONTA          PIC  9(003).*/
                    public IntBasis DET4_TIP_CONTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"     15     DET4-NRO-CONTA          PIC  9(008).*/
                    public IntBasis DET4_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"   10       DET4-TESTE   REDEFINES  DET4-OPCONTA.*/

                    public EM8006B_DET4_OPCONTA()
                    {
                        DET4_TIP_CONTA.ValueChanged += OnValueChanged;
                        DET4_NRO_CONTA.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_EM8006B_DET4_TESTE _det4_teste { get; set; }
                public _REDEF_EM8006B_DET4_TESTE DET4_TESTE
                {
                    get { _det4_teste = new _REDEF_EM8006B_DET4_TESTE(); _.Move(DET4_OPCONTA, _det4_teste); VarBasis.RedefinePassValue(DET4_OPCONTA, _det4_teste, DET4_OPCONTA); _det4_teste.ValueChanged += () => { _.Move(_det4_teste, DET4_OPCONTA); }; return _det4_teste; }
                    set { VarBasis.RedefinePassValue(value, _det4_teste, DET4_OPCONTA); }
                }  //Redefines
                public class _REDEF_EM8006B_DET4_TESTE : VarBasis
                {
                    /*"     15     DET4-FILLER             PIC  9(002).*/
                    public IntBasis DET4_FILLER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"     15     DET4-CONTA-TESTE        PIC  9(009).*/
                    public IntBasis DET4_CONTA_TESTE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"   10       DET4-NSGD    REDEFINES  DET4-OPCONTA                                    PIC  9(011).*/

                    public _REDEF_EM8006B_DET4_TESTE()
                    {
                        DET4_FILLER.ValueChanged += OnValueChanged;
                        DET4_CONTA_TESTE.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_IntBasis _det4_nsgd { get; set; }
                public _REDEF_IntBasis DET4_NSGD
                {
                    get { _det4_nsgd = new _REDEF_IntBasis(new PIC("9", "011", "9(011).")); ; _.Move(DET4_OPCONTA, _det4_nsgd); VarBasis.RedefinePassValue(DET4_OPCONTA, _det4_nsgd, DET4_OPCONTA); _det4_nsgd.ValueChanged += () => { _.Move(_det4_nsgd, DET4_OPCONTA); }; return _det4_nsgd; }
                    set { VarBasis.RedefinePassValue(value, _det4_nsgd, DET4_OPCONTA); }
                }  //Redefines
                /*"   10       DET4-DV-CONTA           PIC  9(001).*/
                public IntBasis DET4_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  9(003).*/
                public IntBasis FILLER_70 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET4-DT-DEBITO          PIC  X(008).*/
                public StringBasis DET4_DT_DEBITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET4-VLR-ORIGINAL       PIC  9(013)V99.*/
                public DoubleBasis DET4_VLR_ORIGINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET4-COD-RETORNO        PIC  X(002).*/
                public StringBasis DET4_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET4-COD-MOVTO          PIC  9(001).*/
                public IntBasis DET4_COD_MOVTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  X(307).*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "307", "X(307)."), @"");
                /*"  05        DET-REG5     REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG4()
                {
                    DET4_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET4_COD_CONV.ValueChanged += OnValueChanged;
                    DET4_COD_BCO.ValueChanged += OnValueChanged;
                    DET4_COD_AGE.ValueChanged += OnValueChanged;
                    DET4_OPCONTA.ValueChanged += OnValueChanged;
                    DET4_TESTE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG5 _det_reg5 { get; set; }
            public _REDEF_EM8006B_DET_REG5 DET_REG5
            {
                get { _det_reg5 = new _REDEF_EM8006B_DET_REG5(); _.Move(DET_REG1, _det_reg5); VarBasis.RedefinePassValue(DET_REG1, _det_reg5, DET_REG1); _det_reg5.ValueChanged += () => { _.Move(_det_reg5, DET_REG1); }; return _det_reg5; }
                set { VarBasis.RedefinePassValue(value, _det_reg5, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG5 : VarBasis
            {
                /*"   10       DET5-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET5_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-COD-BANCO          PIC  9(003).*/
                public IntBasis DET5_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-TP-INSCR           PIC  9(002).*/
                public IntBasis DET5_TP_INSCR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET5-NRO-INSCR          PIC  9(014).*/
                public IntBasis DET5_NRO_INSCR { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET5-COD-CEDENTE        PIC  9(016).*/
                public IntBasis DET5_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       DET5-TITU-EMP           PIC  9(016).*/
                public IntBasis DET5_TITU_EMP { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       DET5-TITU-BCO           PIC  9(011).*/
                public IntBasis DET5_TITU_BCO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"   10       DET5-COD-REJ            PIC  9(003).*/
                public IntBasis DET5_COD_REJ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-COD-OCORR          PIC  9(002).*/
                public IntBasis DET5_COD_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET5-DT-OCORR           PIC  X(008).*/
                public StringBasis DET5_DT_OCORR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-DT-VENCTO          PIC  X(008).*/
                public StringBasis DET5_DT_VENCTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-VLR-NOMINAL        PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_NOMINAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-COD-BCO-PAGTO      PIC  9(003).*/
                public IntBasis DET5_COD_BCO_PAGTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-AGE-PAGTO          PIC  9(004).*/
                public IntBasis DET5_AGE_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET5-DV-AGE-PAGTO       PIC  9(001).*/
                public IntBasis DET5_DV_AGE_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET5-ESPECIE            PIC  X(002).*/
                public StringBasis DET5_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET5-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-FORMA-LIQ          PIC  9(003).*/
                public IntBasis DET5_FORMA_LIQ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET5-FORMA-PAGTO        PIC  9(001).*/
                public IntBasis DET5_FORMA_PAGTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET5-QTD-DIAS-FLO       PIC  9(002).*/
                public IntBasis DET5_QTD_DIAS_FLO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET5-DT-DEB-TARIFA      PIC  X(008).*/
                public StringBasis DET5_DT_DEB_TARIFA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-VLR-IOF            PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-ABATIMEN       PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_ABATIMEN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-DESCTO         PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_DESCTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-PRINC          PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_PRINC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-JUROS          PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-VLR-MULTA          PIC  9(013)V99.*/
                public DoubleBasis DET5_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET5-COD-MOEDA          PIC  9(001).*/
                public IntBasis DET5_COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET5-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET5_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET5-FINANCEIRO         PIC  9(016).*/
                public IntBasis DET5_FINANCEIRO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       FILLER                  PIC  X(109).*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
                /*"  05        DET-REG6     REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG5()
                {
                    DET5_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET5_COD_BANCO.ValueChanged += OnValueChanged;
                    DET5_TP_INSCR.ValueChanged += OnValueChanged;
                    DET5_NRO_INSCR.ValueChanged += OnValueChanged;
                    DET5_COD_CEDENTE.ValueChanged += OnValueChanged;
                    DET5_TITU_EMP.ValueChanged += OnValueChanged;
                    DET5_TITU_BCO.ValueChanged += OnValueChanged;
                    DET5_COD_REJ.ValueChanged += OnValueChanged;
                    DET5_COD_OCORR.ValueChanged += OnValueChanged;
                    DET5_DT_OCORR.ValueChanged += OnValueChanged;
                    DET5_DT_VENCTO.ValueChanged += OnValueChanged;
                    DET5_VLR_NOMINAL.ValueChanged += OnValueChanged;
                    DET5_COD_BCO_PAGTO.ValueChanged += OnValueChanged;
                    DET5_AGE_PAGTO.ValueChanged += OnValueChanged;
                    DET5_DV_AGE_PAGTO.ValueChanged += OnValueChanged;
                    DET5_ESPECIE.ValueChanged += OnValueChanged;
                    DET5_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET5_FORMA_LIQ.ValueChanged += OnValueChanged;
                    DET5_FORMA_PAGTO.ValueChanged += OnValueChanged;
                    DET5_QTD_DIAS_FLO.ValueChanged += OnValueChanged;
                    DET5_DT_DEB_TARIFA.ValueChanged += OnValueChanged;
                    DET5_VLR_IOF.ValueChanged += OnValueChanged;
                    DET5_VLR_ABATIMEN.ValueChanged += OnValueChanged;
                    DET5_VLR_DESCTO.ValueChanged += OnValueChanged;
                    DET5_VLR_PRINC.ValueChanged += OnValueChanged;
                    DET5_VLR_JUROS.ValueChanged += OnValueChanged;
                    DET5_VLR_MULTA.ValueChanged += OnValueChanged;
                    DET5_COD_MOEDA.ValueChanged += OnValueChanged;
                    DET5_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET5_FINANCEIRO.ValueChanged += OnValueChanged;
                    FILLER_72.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG6 _det_reg6 { get; set; }
            public _REDEF_EM8006B_DET_REG6 DET_REG6
            {
                get { _det_reg6 = new _REDEF_EM8006B_DET_REG6(); _.Move(DET_REG1, _det_reg6); VarBasis.RedefinePassValue(DET_REG1, _det_reg6, DET_REG1); _det_reg6.ValueChanged += () => { _.Move(_det_reg6, DET_REG1); }; return _det_reg6; }
                set { VarBasis.RedefinePassValue(value, _det_reg6, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG6 : VarBasis
            {
                /*"   10       DET6-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET6_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET6-NRO-SIVPF          PIC  9(014).*/
                public IntBasis DET6_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET6-AGENCIA            PIC  9(004).*/
                public IntBasis DET6_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET6-OPERACAO           PIC  9(003).*/
                public IntBasis DET6_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET6-CONTA              PIC  9(008).*/
                public IntBasis DET6_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET6-DV-CONTA           PIC  9(001).*/
                public IntBasis DET6_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET6-VLR-PAGO           PIC  9(013)V99.*/
                public DoubleBasis DET6_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET6-VLR-BALCAO         PIC  9(013)V99.*/
                public DoubleBasis DET6_VLR_BALCAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET6-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET6_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET6-DT-PAGTO           PIC  X(008).*/
                public StringBasis DET6_DT_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET6-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET6_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       FILLER                  PIC  X(270).*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "270", "X(270)."), @"");
                /*"  05        DET-REG7     REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG6()
                {
                    DET6_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET6_NRO_SIVPF.ValueChanged += OnValueChanged;
                    DET6_AGENCIA.ValueChanged += OnValueChanged;
                    DET6_OPERACAO.ValueChanged += OnValueChanged;
                    DET6_CONTA.ValueChanged += OnValueChanged;
                    DET6_DV_CONTA.ValueChanged += OnValueChanged;
                    DET6_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET6_VLR_BALCAO.ValueChanged += OnValueChanged;
                    DET6_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET6_DT_PAGTO.ValueChanged += OnValueChanged;
                    DET6_DT_CREDITO.ValueChanged += OnValueChanged;
                    FILLER_73.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG7 _det_reg7 { get; set; }
            public _REDEF_EM8006B_DET_REG7 DET_REG7
            {
                get { _det_reg7 = new _REDEF_EM8006B_DET_REG7(); _.Move(DET_REG1, _det_reg7); VarBasis.RedefinePassValue(DET_REG1, _det_reg7, DET_REG1); _det_reg7.ValueChanged += () => { _.Move(_det_reg7, DET_REG1); }; return _det_reg7; }
                set { VarBasis.RedefinePassValue(value, _det_reg7, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG7 : VarBasis
            {
                /*"   10       DET7-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET7_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET7-COD-REMESSA        PIC  9(001).*/
                public IntBasis DET7_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET7-COD-CONV           PIC  9(006).*/
                public IntBasis DET7_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET7-NOME-EMPR          PIC  X(020).*/
                public StringBasis DET7_NOME_EMPR { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET7-COD-BCO            PIC  9(003).*/
                public IntBasis DET7_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET7-NOME-BCO           PIC  X(020).*/
                public StringBasis DET7_NOME_BCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET7-AGENCIA            PIC  9(004).*/
                public IntBasis DET7_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET7-OPERACAO           PIC  9(003).*/
                public IntBasis DET7_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET7-NRO-CONTA          PIC  9(008).*/
                public IntBasis DET7_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET7-DV-CONTA           PIC  9(001).*/
                public IntBasis DET7_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET7-DT-PAGTO           PIC  X(008).*/
                public StringBasis DET7_DT_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET7-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET7_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET7-BARRA01            PIC  X(016).*/
                public StringBasis DET7_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"   10       DET7-BANCO              PIC  9(003).*/
                public IntBasis DET7_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET7-BARRA02            PIC  X(005).*/
                public StringBasis DET7_BARRA02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"   10       DET7-NRO-SIVPF          PIC  9(013).*/
                public IntBasis DET7_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"   10       DET7-BARRA03            PIC  X(007).*/
                public StringBasis DET7_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
                /*"   10       DET7-VLR-PAGO           PIC  9(013)V99.*/
                public DoubleBasis DET7_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET7-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET7_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET7-VLR-TOT-PAGO       PIC  9(013)V99.*/
                public DoubleBasis DET7_VLR_TOT_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       FILLER                  PIC  X(190).*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "190", "X(190)."), @"");
                /*"  05        DET-REG9     REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG7()
                {
                    DET7_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET7_COD_REMESSA.ValueChanged += OnValueChanged;
                    DET7_COD_CONV.ValueChanged += OnValueChanged;
                    DET7_NOME_EMPR.ValueChanged += OnValueChanged;
                    DET7_COD_BCO.ValueChanged += OnValueChanged;
                    DET7_NOME_BCO.ValueChanged += OnValueChanged;
                    DET7_AGENCIA.ValueChanged += OnValueChanged;
                    DET7_OPERACAO.ValueChanged += OnValueChanged;
                    DET7_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET7_DV_CONTA.ValueChanged += OnValueChanged;
                    DET7_DT_PAGTO.ValueChanged += OnValueChanged;
                    DET7_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET7_BARRA01.ValueChanged += OnValueChanged;
                    DET7_BANCO.ValueChanged += OnValueChanged;
                    DET7_BARRA02.ValueChanged += OnValueChanged;
                    DET7_NRO_SIVPF.ValueChanged += OnValueChanged;
                    DET7_BARRA03.ValueChanged += OnValueChanged;
                    DET7_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET7_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET7_VLR_TOT_PAGO.ValueChanged += OnValueChanged;
                    FILLER_74.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG9 _det_reg9 { get; set; }
            public _REDEF_EM8006B_DET_REG9 DET_REG9
            {
                get { _det_reg9 = new _REDEF_EM8006B_DET_REG9(); _.Move(DET_REG1, _det_reg9); VarBasis.RedefinePassValue(DET_REG1, _det_reg9, DET_REG1); _det_reg9.ValueChanged += () => { _.Move(_det_reg9, DET_REG1); }; return _det_reg9; }
                set { VarBasis.RedefinePassValue(value, _det_reg9, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG9 : VarBasis
            {
                /*"   10       DET9-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET9_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-COD-CEDENTE        PIC  9(008).*/
                public IntBasis DET9_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET9-COD-CONVENIO       PIC  9(006).*/
                public IntBasis DET9_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET9-CGCCPF             PIC  9(014).*/
                public IntBasis DET9_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET9-COD-BCO            PIC  9(003).*/
                public IntBasis DET9_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET9-DIG-BCO            PIC  9(001).*/
                public IntBasis DET9_DIG_BCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-AGENCIA            PIC  9(004).*/
                public IntBasis DET9_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET9-DIG-AGE            PIC  9(001).*/
                public IntBasis DET9_DIG_AGE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-NRO-CONTA          PIC  9(008).*/
                public IntBasis DET9_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET9-DV-CONTA           PIC  9(001).*/
                public IntBasis DET9_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-CONTROLE           PIC  X(025).*/
                public StringBasis DET9_CONTROLE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"   10       DET9-NRO-TITULO         PIC  9(011).*/
                public IntBasis DET9_NRO_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"   10       DET9-DIG-TITULO         PIC  9(001).*/
                public IntBasis DET9_DIG_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-NRPARCEL           PIC  9(002).*/
                public IntBasis DET9_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-DIAS-CALC          PIC  9(004).*/
                public IntBasis DET9_DIAS_CALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET9-MOTIVO             PIC  9(002).*/
                public IntBasis DET9_MOTIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-PREFIXO            PIC  X(003).*/
                public StringBasis DET9_PREFIXO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"   10       DET9-VARIACAO           PIC  9(003).*/
                public IntBasis DET9_VARIACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET9-TAXA-DESCONTO      PIC  9(003)V99.*/
                public DoubleBasis DET9_TAXA_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"   10       DET9-TAXA-IOF           PIC  9(001)V9999.*/
                public DoubleBasis DET9_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "9(001)V9999."), 4);
                /*"   10       DET9-CARTEIRA           PIC  9(002).*/
                public IntBasis DET9_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-COMANDO            PIC  9(002).*/
                public IntBasis DET9_COMANDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-DT-LIQUIDA         PIC  X(008).*/
                public StringBasis DET9_DT_LIQUIDA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-SEU-NUMERO         PIC  X(010).*/
                public StringBasis DET9_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET9-DT-VENCTO          PIC  X(008).*/
                public StringBasis DET9_DT_VENCTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-VALOR-TITULO       PIC  9(013)V99.*/
                public DoubleBasis DET9_VALOR_TITULO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-BANCO              PIC  9(003).*/
                public IntBasis DET9_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET9-AGE-COBR           PIC  9(004).*/
                public IntBasis DET9_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET9-DIG-COBR           PIC  9(001).*/
                public IntBasis DET9_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET9-ESPECIE            PIC  9(002).*/
                public IntBasis DET9_ESPECIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET9-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET9_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET9-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET9_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-OUT-DESPESAS       PIC  9(013)V99.*/
                public DoubleBasis DET9_OUT_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-JUROS              PIC  9(013)V99.*/
                public DoubleBasis DET9_JUROS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-VALOR-IOF          PIC  9(013)V99.*/
                public DoubleBasis DET9_VALOR_IOF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-ABATIMENTO         PIC  9(013)V99.*/
                public DoubleBasis DET9_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-DESCONTO           PIC  9(013)V99.*/
                public DoubleBasis DET9_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-VLR-RECEBIDO       PIC  9(013)V99.*/
                public DoubleBasis DET9_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-MORA               PIC  9(013)V99.*/
                public DoubleBasis DET9_MORA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-OUT-RECEBE         PIC  9(013)V99.*/
                public DoubleBasis DET9_OUT_RECEBE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-VLR-LANCADO        PIC  9(013)V99.*/
                public DoubleBasis DET9_VLR_LANCADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET9-INDICA-VLR         PIC  9(001).*/
                public IntBasis DET9_INDICA_VLR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  X(040).*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05        DET-REG11    REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG9()
                {
                    DET9_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET9_COD_CEDENTE.ValueChanged += OnValueChanged;
                    DET9_COD_CONVENIO.ValueChanged += OnValueChanged;
                    DET9_CGCCPF.ValueChanged += OnValueChanged;
                    DET9_COD_BCO.ValueChanged += OnValueChanged;
                    DET9_DIG_BCO.ValueChanged += OnValueChanged;
                    DET9_AGENCIA.ValueChanged += OnValueChanged;
                    DET9_DIG_AGE.ValueChanged += OnValueChanged;
                    DET9_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET9_DV_CONTA.ValueChanged += OnValueChanged;
                    DET9_CONTROLE.ValueChanged += OnValueChanged;
                    DET9_NRO_TITULO.ValueChanged += OnValueChanged;
                    DET9_DIG_TITULO.ValueChanged += OnValueChanged;
                    DET9_NRPARCEL.ValueChanged += OnValueChanged;
                    DET9_DIAS_CALC.ValueChanged += OnValueChanged;
                    DET9_MOTIVO.ValueChanged += OnValueChanged;
                    DET9_PREFIXO.ValueChanged += OnValueChanged;
                    DET9_VARIACAO.ValueChanged += OnValueChanged;
                    DET9_TAXA_DESCONTO.ValueChanged += OnValueChanged;
                    DET9_TAXA_IOF.ValueChanged += OnValueChanged;
                    DET9_CARTEIRA.ValueChanged += OnValueChanged;
                    DET9_COMANDO.ValueChanged += OnValueChanged;
                    DET9_DT_LIQUIDA.ValueChanged += OnValueChanged;
                    DET9_SEU_NUMERO.ValueChanged += OnValueChanged;
                    DET9_DT_VENCTO.ValueChanged += OnValueChanged;
                    DET9_VALOR_TITULO.ValueChanged += OnValueChanged;
                    DET9_BANCO.ValueChanged += OnValueChanged;
                    DET9_AGE_COBR.ValueChanged += OnValueChanged;
                    DET9_DIG_COBR.ValueChanged += OnValueChanged;
                    DET9_ESPECIE.ValueChanged += OnValueChanged;
                    DET9_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET9_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET9_OUT_DESPESAS.ValueChanged += OnValueChanged;
                    DET9_JUROS.ValueChanged += OnValueChanged;
                    DET9_VALOR_IOF.ValueChanged += OnValueChanged;
                    DET9_ABATIMENTO.ValueChanged += OnValueChanged;
                    DET9_DESCONTO.ValueChanged += OnValueChanged;
                    DET9_VLR_RECEBIDO.ValueChanged += OnValueChanged;
                    DET9_MORA.ValueChanged += OnValueChanged;
                    DET9_OUT_RECEBE.ValueChanged += OnValueChanged;
                    DET9_VLR_LANCADO.ValueChanged += OnValueChanged;
                    DET9_INDICA_VLR.ValueChanged += OnValueChanged;
                    FILLER_75.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG11 _det_reg11 { get; set; }
            public _REDEF_EM8006B_DET_REG11 DET_REG11
            {
                get { _det_reg11 = new _REDEF_EM8006B_DET_REG11(); _.Move(DET_REG1, _det_reg11); VarBasis.RedefinePassValue(DET_REG1, _det_reg11, DET_REG1); _det_reg11.ValueChanged += () => { _.Move(_det_reg11, DET_REG1); }; return _det_reg11; }
                set { VarBasis.RedefinePassValue(value, _det_reg11, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG11 : VarBasis
            {
                /*"   10       DET11-DT-GERACAO         PIC  X(008).*/
                public StringBasis DET11_DT_GERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET11-USO-EMPRESA.*/
                public EM8006B_DET11_USO_EMPRESA DET11_USO_EMPRESA { get; set; } = new EM8006B_DET11_USO_EMPRESA();
                public class EM8006B_DET11_USO_EMPRESA : VarBasis
                {
                    /*"     15     DET11-USO-PARTE01        PIC  9(010).*/
                    public IntBasis DET11_USO_PARTE01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                    /*"     15     DET11-NRO-SIVPF          PIC  9(015).*/
                    public IntBasis DET11_NRO_SIVPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                    /*"   10       DET11-AGENCIA            PIC  9(004).*/

                    public EM8006B_DET11_USO_EMPRESA()
                    {
                        DET11_USO_PARTE01.ValueChanged += OnValueChanged;
                        DET11_NRO_SIVPF.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis DET11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET11-OPERACAO           PIC  9(003).*/
                public IntBasis DET11_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET11-NRO-CONTA          PIC  9(008).*/
                public IntBasis DET11_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET11-DV-CONTA           PIC  9(001).*/
                public IntBasis DET11_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET11-VLR-PAGO           PIC  9(013)V99.*/
                public DoubleBasis DET11_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET11-VLR-TARIFA         PIC  9(013)V99.*/
                public DoubleBasis DET11_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET11-DT-PAGTO           PIC  X(008).*/
                public StringBasis DET11_DT_PAGTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET11-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET11_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       FILLER                   PIC  X(274).*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "274", "X(274)."), @"");
                /*"  05        DET-REG12    REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG11()
                {
                    DET11_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET11_USO_EMPRESA.ValueChanged += OnValueChanged;
                    DET11_AGENCIA.ValueChanged += OnValueChanged;
                    DET11_OPERACAO.ValueChanged += OnValueChanged;
                    DET11_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET11_DV_CONTA.ValueChanged += OnValueChanged;
                    DET11_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET11_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET11_DT_PAGTO.ValueChanged += OnValueChanged;
                    DET11_DT_CREDITO.ValueChanged += OnValueChanged;
                    FILLER_76.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG12 _det_reg12 { get; set; }
            public _REDEF_EM8006B_DET_REG12 DET_REG12
            {
                get { _det_reg12 = new _REDEF_EM8006B_DET_REG12(); _.Move(DET_REG1, _det_reg12); VarBasis.RedefinePassValue(DET_REG1, _det_reg12, DET_REG1); _det_reg12.ValueChanged += () => { _.Move(_det_reg12, DET_REG1); }; return _det_reg12; }
                set { VarBasis.RedefinePassValue(value, _det_reg12, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG12 : VarBasis
            {
                /*"   10       DET12-DT-MOVTO           PIC  X(008).*/
                public StringBasis DET12_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET12-CONVENIO           PIC  9(006).*/
                public IntBasis DET12_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET12-BANCO              PIC  9(003).*/
                public IntBasis DET12_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET12-NUMCONTA           PIC  X(019).*/
                public StringBasis DET12_NUMCONTA { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
                /*"   10       DET12-DT-CREDITO         PIC  X(008).*/
                public StringBasis DET12_DT_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET12-VLR-PARCELA        PIC  9(013)V99.*/
                public DoubleBasis DET12_VLR_PARCELA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET12-COD-ERRO           PIC  9(002).*/
                public IntBasis DET12_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       FILLER                   PIC  X(308).*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "308", "X(308)."), @"");
                /*"  05        DET-REG13    REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG12()
                {
                    DET12_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET12_CONVENIO.ValueChanged += OnValueChanged;
                    DET12_BANCO.ValueChanged += OnValueChanged;
                    DET12_NUMCONTA.ValueChanged += OnValueChanged;
                    DET12_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET12_VLR_PARCELA.ValueChanged += OnValueChanged;
                    DET12_COD_ERRO.ValueChanged += OnValueChanged;
                    FILLER_77.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG13 _det_reg13 { get; set; }
            public _REDEF_EM8006B_DET_REG13 DET_REG13
            {
                get { _det_reg13 = new _REDEF_EM8006B_DET_REG13(); _.Move(DET_REG1, _det_reg13); VarBasis.RedefinePassValue(DET_REG1, _det_reg13, DET_REG1); _det_reg13.ValueChanged += () => { _.Move(_det_reg13, DET_REG1); }; return _det_reg13; }
                set { VarBasis.RedefinePassValue(value, _det_reg13, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG13 : VarBasis
            {
                /*"   10       DET13-NUM-PROPOSTA      PIC  X(016).*/
                public StringBasis DET13_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"   10       DET13-NUM-BOL-INTERNO   PIC  X(010).*/
                public StringBasis DET13_NUM_BOL_INTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       DET13-NN-REGISTRADO     PIC  X(018).*/
                public StringBasis DET13_NN_REGISTRADO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)."), @"");
                /*"   10       DET13-LNHA-DIGITAVEL    PIC  X(054).*/
                public StringBasis DET13_LNHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)."), @"");
                /*"   10       DET13-COD-AG-CEDENTE    PIC  X(020).*/
                public StringBasis DET13_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET13-NUM-BCO-RECEB     PIC  9(003).*/
                public IntBasis DET13_NUM_BCO_RECEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET13-NUM-AGE-RECEB     PIC  9(005).*/
                public IntBasis DET13_NUM_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET13-DV-AGE-RECEB      PIC  9(001).*/
                public IntBasis DET13_DV_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET13-DTA-VENCIMENTO    PIC  X(008).*/
                public StringBasis DET13_DTA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-DTA-PAGAMENTO     PIC  X(008).*/
                public StringBasis DET13_DTA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-DTA-CREDITO       PIC  X(008).*/
                public StringBasis DET13_DTA_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-DTA-DEB-TARIFA    PIC  X(008).*/
                public StringBasis DET13_DTA_DEB_TARIFA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET13-VLR-ACRESCIMO     PIC  9(015).*/
                public IntBasis DET13_VLR_ACRESCIMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-DESCONTO      PIC  9(015).*/
                public IntBasis DET13_VLR_DESCONTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-ABATIMENTO    PIC  9(015).*/
                public IntBasis DET13_VLR_ABATIMENTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-IOF           PIC  9(015).*/
                public IntBasis DET13_VLR_IOF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-PAGO          PIC  9(015).*/
                public IntBasis DET13_VLR_PAGO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-LIQUIDO       PIC  9(015).*/
                public IntBasis DET13_VLR_LIQUIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-VLR-TARIFA        PIC  9(015).*/
                public IntBasis DET13_VLR_TARIFA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"   10       DET13-COD-MOVIMENTO     PIC  9(002).*/
                public IntBasis DET13_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10       DET13-COD-REJEICAO      PIC  X(010).*/
                public StringBasis DET13_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"   10       FILLER                  PIC  X(093).*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "93", "X(093)."), @"");
                /*"  05        DET-REG14    REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG13()
                {
                    DET13_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                    DET13_NUM_BOL_INTERNO.ValueChanged += OnValueChanged;
                    DET13_NN_REGISTRADO.ValueChanged += OnValueChanged;
                    DET13_LNHA_DIGITAVEL.ValueChanged += OnValueChanged;
                    DET13_COD_AG_CEDENTE.ValueChanged += OnValueChanged;
                    DET13_NUM_BCO_RECEB.ValueChanged += OnValueChanged;
                    DET13_NUM_AGE_RECEB.ValueChanged += OnValueChanged;
                    DET13_DV_AGE_RECEB.ValueChanged += OnValueChanged;
                    DET13_DTA_VENCIMENTO.ValueChanged += OnValueChanged;
                    DET13_DTA_PAGAMENTO.ValueChanged += OnValueChanged;
                    DET13_DTA_CREDITO.ValueChanged += OnValueChanged;
                    DET13_DTA_DEB_TARIFA.ValueChanged += OnValueChanged;
                    DET13_VLR_ACRESCIMO.ValueChanged += OnValueChanged;
                    DET13_VLR_DESCONTO.ValueChanged += OnValueChanged;
                    DET13_VLR_ABATIMENTO.ValueChanged += OnValueChanged;
                    DET13_VLR_IOF.ValueChanged += OnValueChanged;
                    DET13_VLR_PAGO.ValueChanged += OnValueChanged;
                    DET13_VLR_LIQUIDO.ValueChanged += OnValueChanged;
                    DET13_VLR_TARIFA.ValueChanged += OnValueChanged;
                    DET13_COD_MOVIMENTO.ValueChanged += OnValueChanged;
                    DET13_COD_REJEICAO.ValueChanged += OnValueChanged;
                    FILLER_78.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG14 _det_reg14 { get; set; }
            public _REDEF_EM8006B_DET_REG14 DET_REG14
            {
                get { _det_reg14 = new _REDEF_EM8006B_DET_REG14(); _.Move(DET_REG1, _det_reg14); VarBasis.RedefinePassValue(DET_REG1, _det_reg14, DET_REG1); _det_reg14.ValueChanged += () => { _.Move(_det_reg14, DET_REG1); }; return _det_reg14; }
                set { VarBasis.RedefinePassValue(value, _det_reg14, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG14 : VarBasis
            {
                /*"   10       DET14-DT-MOVTO                PIC  9(008).*/
                public IntBasis DET14_DT_MOVTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-NRO-PROPOSTA            PIC  9(016).*/
                public IntBasis DET14_NRO_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"   10       DET14-NUM-COM-CIELO           PIC  9(010).*/
                public IntBasis DET14_NUM_COM_CIELO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"   10       DET14-COD-BCO-CRED            PIC  9(003).*/
                public IntBasis DET14_COD_BCO_CRED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET14-COD-AGE-CRED            PIC  9(005).*/
                public IntBasis DET14_COD_AGE_CRED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"   10       DET14-NUM-CTA-CRED            PIC  9(012).*/
                public IntBasis DET14_NUM_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"   10       DET14-DIG-CTA-CRED            PIC  9(001).*/
                public IntBasis DET14_DIG_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET14-COD-CART-BANDEIRA       PIC  9(004).*/
                public IntBasis DET14_COD_CART_BANDEIRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET14-NUM-CARTAO              PIC  X(025).*/
                public StringBasis DET14_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"   10       DET14-COD-TOKEN-CARTAO        PIC  X(040).*/
                public StringBasis DET14_COD_TOKEN_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"   10       DET14-STA-CART-PADRAO-SAP     PIC  X(001).*/
                public StringBasis DET14_STA_CART_PADRAO_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10       DET14-COD-TID-CIELO           PIC  X(020).*/
                public StringBasis DET14_COD_TID_CIELO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"   10       DET14-VLR-COBRANCA            PIC  9(013)V99.*/
                public DoubleBasis DET14_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET14-VLR-LIQUIDO             PIC  9(013)V99.*/
                public DoubleBasis DET14_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET14-VLR-TAX-ADM             PIC  9(013)V99.*/
                public DoubleBasis DET14_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET14-DTA-VENCIMENTO          PIC  9(008).*/
                public IntBasis DET14_DTA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-DT-CREDITO              PIC  9(008).*/
                public IntBasis DET14_DT_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-DT-DEBITO               PIC  9(008).*/
                public IntBasis DET14_DT_DEBITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-DTA-AJU-CAPTURA         PIC  9(008).*/
                public IntBasis DET14_DTA_AJU_CAPTURA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET14-COD-MOVIMENTO           PIC  X(002).*/
                public StringBasis DET14_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET14-COD-RETORNO             PIC  X(003).*/
                public StringBasis DET14_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"   10       DET14-PROC-ADVERT             PIC  X(002).*/
                public StringBasis DET14_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET14-NIVE-ADVERT             PIC  X(002).*/
                public StringBasis DET14_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       FILLER                        PIC  X(138).*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "138", "X(138)."), @"");
                /*"  05        DET-CESTA    REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_REG14()
                {
                    DET14_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET14_NRO_PROPOSTA.ValueChanged += OnValueChanged;
                    DET14_NUM_COM_CIELO.ValueChanged += OnValueChanged;
                    DET14_COD_BCO_CRED.ValueChanged += OnValueChanged;
                    DET14_COD_AGE_CRED.ValueChanged += OnValueChanged;
                    DET14_NUM_CTA_CRED.ValueChanged += OnValueChanged;
                    DET14_DIG_CTA_CRED.ValueChanged += OnValueChanged;
                    DET14_COD_CART_BANDEIRA.ValueChanged += OnValueChanged;
                    DET14_NUM_CARTAO.ValueChanged += OnValueChanged;
                    DET14_COD_TOKEN_CARTAO.ValueChanged += OnValueChanged;
                    DET14_STA_CART_PADRAO_SAP.ValueChanged += OnValueChanged;
                    DET14_COD_TID_CIELO.ValueChanged += OnValueChanged;
                    DET14_VLR_COBRANCA.ValueChanged += OnValueChanged;
                    DET14_VLR_LIQUIDO.ValueChanged += OnValueChanged;
                    DET14_VLR_TAX_ADM.ValueChanged += OnValueChanged;
                    DET14_DTA_VENCIMENTO.ValueChanged += OnValueChanged;
                    DET14_DT_CREDITO.ValueChanged += OnValueChanged;
                    DET14_DT_DEBITO.ValueChanged += OnValueChanged;
                    DET14_DTA_AJU_CAPTURA.ValueChanged += OnValueChanged;
                    DET14_COD_MOVIMENTO.ValueChanged += OnValueChanged;
                    DET14_COD_RETORNO.ValueChanged += OnValueChanged;
                    DET14_PROC_ADVERT.ValueChanged += OnValueChanged;
                    DET14_NIVE_ADVERT.ValueChanged += OnValueChanged;
                    FILLER_79.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_CESTA _det_cesta { get; set; }
            public _REDEF_EM8006B_DET_CESTA DET_CESTA
            {
                get { _det_cesta = new _REDEF_EM8006B_DET_CESTA(); _.Move(DET_REG1, _det_cesta); VarBasis.RedefinePassValue(DET_REG1, _det_cesta, DET_REG1); _det_cesta.ValueChanged += () => { _.Move(_det_cesta, DET_REG1); }; return _det_cesta; }
                set { VarBasis.RedefinePassValue(value, _det_cesta, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_CESTA : VarBasis
            {
                /*"   10       DET15-DT-GERACAO        PIC  9(008).*/
                public IntBasis DET15_DT_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET15-NUM-PROPPOSTA     PIC  9(014).*/
                public IntBasis DET15_NUM_PROPPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"   10       DET15-AGENCIA-CLI       PIC  9(004).*/
                public IntBasis DET15_AGENCIA_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET15-OPERACAO-CLI      PIC  9(004).*/
                public IntBasis DET15_OPERACAO_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET15-CONTA-CLI         PIC  9(012).*/
                public IntBasis DET15_CONTA_CLI { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"   10       DET15-CONTA-DV-CLI      PIC  9(001).*/
                public IntBasis DET15_CONTA_DV_CLI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       DET15-VALOR-PAGO        PIC  9(013)V99.*/
                public DoubleBasis DET15_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET15-COD-RETORNO       PIC  9(003).*/
                public IntBasis DET15_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET15-MSG-RETORNO       PIC  X(045).*/
                public StringBasis DET15_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
                /*"   10       DET15-FILLER            PIC  X(263).*/
                public StringBasis DET15_FILLER { get; set; } = new StringBasis(new PIC("X", "263", "X(263)."), @"");
                /*"  05        DET-REG16    REDEFINES   DET-REG1.*/

                public _REDEF_EM8006B_DET_CESTA()
                {
                    DET15_DT_GERACAO.ValueChanged += OnValueChanged;
                    DET15_NUM_PROPPOSTA.ValueChanged += OnValueChanged;
                    DET15_AGENCIA_CLI.ValueChanged += OnValueChanged;
                    DET15_OPERACAO_CLI.ValueChanged += OnValueChanged;
                    DET15_CONTA_CLI.ValueChanged += OnValueChanged;
                    DET15_CONTA_DV_CLI.ValueChanged += OnValueChanged;
                    DET15_VALOR_PAGO.ValueChanged += OnValueChanged;
                    DET15_COD_RETORNO.ValueChanged += OnValueChanged;
                    DET15_MSG_RETORNO.ValueChanged += OnValueChanged;
                    DET15_FILLER.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_EM8006B_DET_REG16 _det_reg16 { get; set; }
            public _REDEF_EM8006B_DET_REG16 DET_REG16
            {
                get { _det_reg16 = new _REDEF_EM8006B_DET_REG16(); _.Move(DET_REG1, _det_reg16); VarBasis.RedefinePassValue(DET_REG1, _det_reg16, DET_REG1); _det_reg16.ValueChanged += () => { _.Move(_det_reg16, DET_REG1); }; return _det_reg16; }
                set { VarBasis.RedefinePassValue(value, _det_reg16, DET_REG1); }
            }  //Redefines
            public class _REDEF_EM8006B_DET_REG16 : VarBasis
            {
                /*"   10       DET16-DT-MOVTO          PIC  X(008).*/
                public StringBasis DET16_DT_MOVTO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET16-COD-CONV          PIC  9(006).*/
                public IntBasis DET16_COD_CONV { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"   10       DET16-COD-BCO           PIC  9(003).*/
                public IntBasis DET16_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET16-COD-AGE           PIC  9(004).*/
                public IntBasis DET16_COD_AGE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   10       DET16-OPE-CTA           PIC  9(003).*/
                public IntBasis DET16_OPE_CTA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10       DET16-NRO-CONTA         PIC  9(008).*/
                public IntBasis DET16_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"   10       DET16-DV-CTA            PIC  9(001).*/
                public IntBasis DET16_DV_CTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   10       FILLER                  PIC  X(003).*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"   10       DET16-DT-DEBITO         PIC  X(008).*/
                public StringBasis DET16_DT_DEBITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"   10       DET16-VLR-DEBITO        PIC  9(013)V99.*/
                public DoubleBasis DET16_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"   10       DET16-COD-RETORNO       PIC  X(002).*/
                public StringBasis DET16_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET16-COD-MOVTO         PIC  X(001).*/
                public StringBasis DET16_COD_MOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10       DET16-PROC-ADVERT       PIC  X(002).*/
                public StringBasis DET16_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       DET16-NIVE-ADVERT       PIC  X(002).*/
                public StringBasis DET16_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"   10       FILLER                  PIC  X(303).*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "303", "X(303)."), @"");
                /*"01          TRAI-REGISTRO.*/

                public _REDEF_EM8006B_DET_REG16()
                {
                    DET16_DT_MOVTO.ValueChanged += OnValueChanged;
                    DET16_COD_CONV.ValueChanged += OnValueChanged;
                    DET16_COD_BCO.ValueChanged += OnValueChanged;
                    DET16_COD_AGE.ValueChanged += OnValueChanged;
                    DET16_OPE_CTA.ValueChanged += OnValueChanged;
                    DET16_NRO_CONTA.ValueChanged += OnValueChanged;
                    DET16_DV_CTA.ValueChanged += OnValueChanged;
                    FILLER_80.ValueChanged += OnValueChanged;
                    DET16_DT_DEBITO.ValueChanged += OnValueChanged;
                    DET16_VLR_DEBITO.ValueChanged += OnValueChanged;
                    DET16_COD_RETORNO.ValueChanged += OnValueChanged;
                    DET16_COD_MOVTO.ValueChanged += OnValueChanged;
                    DET16_PROC_ADVERT.ValueChanged += OnValueChanged;
                    DET16_NIVE_ADVERT.ValueChanged += OnValueChanged;
                    FILLER_81.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8006B_TRAI_REGISTRO TRAI_REGISTRO { get; set; } = new EM8006B_TRAI_REGISTRO();
        public class EM8006B_TRAI_REGISTRO : VarBasis
        {
            /*"  05        TRAI-TIPREG            PIC  9(002).*/
            public IntBasis TRAI_TIPREG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05        TRAI-SEQREG            PIC  9(009).*/
            public IntBasis TRAI_SEQREG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        TRAI-DT-PROC           PIC  X(008).*/
            public StringBasis TRAI_DT_PROC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        TRAI-TOT-REG           PIC  9(009).*/
            public IntBasis TRAI_TOT_REG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05        FILLER                 PIC  X(472).*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "472", "X(472)."), @"");
            /*"01          WS-COD-AG-CEDENTE      PIC  X(020).*/
        }
        public StringBasis WS_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"01 WS-CEDENTE-R REDEFINES WS-COD-AG-CEDENTE.*/
        private _REDEF_EM8006B_WS_CEDENTE_R _ws_cedente_r { get; set; }
        public _REDEF_EM8006B_WS_CEDENTE_R WS_CEDENTE_R
        {
            get { _ws_cedente_r = new _REDEF_EM8006B_WS_CEDENTE_R(); _.Move(WS_COD_AG_CEDENTE, _ws_cedente_r); VarBasis.RedefinePassValue(WS_COD_AG_CEDENTE, _ws_cedente_r, WS_COD_AG_CEDENTE); _ws_cedente_r.ValueChanged += () => { _.Move(_ws_cedente_r, WS_COD_AG_CEDENTE); }; return _ws_cedente_r; }
            set { VarBasis.RedefinePassValue(value, _ws_cedente_r, WS_COD_AG_CEDENTE); }
        }  //Redefines
        public class _REDEF_EM8006B_WS_CEDENTE_R : VarBasis
        {
            /*"   15       FILLER                 PIC  X(007).*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"   15       WS-COD-AGE-CED         PIC  9(004).*/
            public IntBasis WS_COD_AGE_CED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"   15       FILLER                 PIC  X(001).*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   15       WS-COD-CEDENTE         PIC  9(006).*/
            public IntBasis WS_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"   15       FILLER                 PIC  X(001).*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   15       WS-DV-CEDENTE          PIC  9(001).*/
            public IntBasis WS_DV_CEDENTE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        MOVCC-REGISTRO.*/

            public _REDEF_EM8006B_WS_CEDENTE_R()
            {
                FILLER_83.ValueChanged += OnValueChanged;
                WS_COD_AGE_CED.ValueChanged += OnValueChanged;
                FILLER_84.ValueChanged += OnValueChanged;
                WS_COD_CEDENTE.ValueChanged += OnValueChanged;
                FILLER_85.ValueChanged += OnValueChanged;
                WS_DV_CEDENTE.ValueChanged += OnValueChanged;
            }

        }
        public EM8006B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new EM8006B_MOVCC_REGISTRO();
        public class EM8006B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis MOVCC_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      MOVCC-CODBANCO           PIC  9(003) VALUE ZEROS.*/
            public IntBasis MOVCC_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      MOVCC-CONVENIO           PIC  9(006) VALUE ZEROS.*/
            public IntBasis MOVCC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      MOVCC-NSAS               PIC  9(005) VALUE ZEROS.*/
            public IntBasis MOVCC_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05      MOVCC-CONVENIO-SAP       PIC  9(006) VALUE ZEROS.*/
            public IntBasis MOVCC_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      MOVCC-NSAC               PIC  9(005) VALUE ZEROS.*/
            public IntBasis MOVCC_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05      MOVCC-DTGERACAO.*/
            public EM8006B_MOVCC_DTGERACAO MOVCC_DTGERACAO { get; set; } = new EM8006B_MOVCC_DTGERACAO();
            public class EM8006B_MOVCC_DTGERACAO : VarBasis
            {
                /*"    10    MOVCC-ANO-HEADER         PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    MOVCC-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      MOVCC-IDTCLIEMP          PIC  X(025) VALUE SPACES.*/
            }
            public StringBasis MOVCC_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05      MOVCC-IDTCLIBAN.*/
            public EM8006B_MOVCC_IDTCLIBAN MOVCC_IDTCLIBAN { get; set; } = new EM8006B_MOVCC_IDTCLIBAN();
            public class EM8006B_MOVCC_IDTCLIBAN : VarBasis
            {
                /*"    10    MOVCC-AGECONTA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-OPECONTA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-NUMCONTA           PIC  9(012) VALUE ZEROS.*/
                public IntBasis MOVCC_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"    10    MOVCC-DIGCONTA           PIC  9(001) VALUE ZEROS.*/
                public IntBasis MOVCC_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"    10    FILLER                   PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public EM8006B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new EM8006B_MOVCC_DTCREDITO();
            public class EM8006B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANO                PIC  9(004) VALUE ZEROS.*/
                public IntBasis MOVCC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    MOVCC-MES                PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    MOVCC-DIA                PIC  9(002) VALUE ZEROS.*/
                public IntBasis MOVCC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      MOVCC-VLDEBCRE           PIC  9(013)V99 VALUE ZEROS.*/
            }
            public DoubleBasis MOVCC_VLDEBCRE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      MOVCC-RETORNO            PIC  X(002) VALUE SPACES.*/
            public StringBasis MOVCC_RETORNO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      FILLER              REDEFINES        MOVCC-RETORNO.*/
            private _REDEF_EM8006B_FILLER_87 _filler_87 { get; set; }
            public _REDEF_EM8006B_FILLER_87 FILLER_87
            {
                get { _filler_87 = new _REDEF_EM8006B_FILLER_87(); _.Move(MOVCC_RETORNO, _filler_87); VarBasis.RedefinePassValue(MOVCC_RETORNO, _filler_87, MOVCC_RETORNO); _filler_87.ValueChanged += () => { _.Move(_filler_87, MOVCC_RETORNO); }; return _filler_87; }
                set { VarBasis.RedefinePassValue(value, _filler_87, MOVCC_RETORNO); }
            }  //Redefines
            public class _REDEF_EM8006B_FILLER_87 : VarBasis
            {
                /*"    10    MOVCC-CODRET             PIC  9(002).*/
                public IntBasis MOVCC_CODRET { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-USOEMPRESA         PIC  X(060) VALUE SPACES.*/

                public _REDEF_EM8006B_FILLER_87()
                {
                    MOVCC_CODRET.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"  05      MOVCC-PROCE-ADVERT       PIC  X(002) VALUE SPACES.*/
            public StringBasis MOVCC_PROCE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      MOVCC-NIVEL-ADVERT       PIC  X(002) VALUE SPACES.*/
            public StringBasis MOVCC_NIVEL_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      MOVCC-MOTIV-COMPEN       PIC  9(002) VALUE ZEROS.*/
            public IntBasis MOVCC_MOTIV_COMPEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      FILLER                   PIC  X(009) VALUE SPACES.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05      MOVCC-CODMOV             PIC  9(001) VALUE ZEROS.*/
            public IntBasis MOVCC_CODMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05      MOVCC-IDLG               PIC  X(040) VALUE SPACES.*/
            public StringBasis MOVCC_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      MOVCC-RETSIACC           PIC  X(010) VALUE SPACES.*/
            public StringBasis MOVCC_RETSIACC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*" 01        REG-SICAP.*/
            public EM8006B_REG_SICAP REG_SICAP { get; set; } = new EM8006B_REG_SICAP();
            public class EM8006B_REG_SICAP : VarBasis
            {
                /*"   10      SICAP-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
                public StringBasis SICAP_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"   10      SICAP-BANCO              PIC  9(003) VALUE ZEROS.*/
                public IntBasis SICAP_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   10      SICAP-CONVENIO-SAP       PIC  9(006) VALUE ZEROS.*/
                public IntBasis SICAP_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   10      SICAP-NSAC               PIC  9(005) VALUE ZEROS.*/
                public IntBasis SICAP_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"   10      SICAP-DTGERACAO.*/
                public EM8006B_SICAP_DTGERACAO SICAP_DTGERACAO { get; set; } = new EM8006B_SICAP_DTGERACAO();
                public class EM8006B_SICAP_DTGERACAO : VarBasis
                {
                    /*"     15    SICAP-ANO-HEADER         PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICAP_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     15    SICAP-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     15    SICAP-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   10      SICAP-COD-REGISTRO       PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis SICAP_COD_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"   10      SICAP-AGENCIA            PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICAP_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   10      SICAP-OPERACAO           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICAP_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   10      SICAP-NUM-CONTA          PIC  9(012) VALUE ZEROS.*/
                public IntBasis SICAP_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"   10      SICAP-DIG-CONTA          PIC  9(001) VALUE ZEROS.*/
                public IntBasis SICAP_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   10      SICAP-DATA-PAGTO.*/
                public EM8006B_SICAP_DATA_PAGTO SICAP_DATA_PAGTO { get; set; } = new EM8006B_SICAP_DATA_PAGTO();
                public class EM8006B_SICAP_DATA_PAGTO : VarBasis
                {
                    /*"     15    SICAP-ANO-PAGTO          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICAP_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     15    SICAP-MES-PAGTO          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     15    SICAP-DIA-PAGTO          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   10      SICAP-DATA-CREDITO.*/
                }
                public EM8006B_SICAP_DATA_CREDITO SICAP_DATA_CREDITO { get; set; } = new EM8006B_SICAP_DATA_CREDITO();
                public class EM8006B_SICAP_DATA_CREDITO : VarBasis
                {
                    /*"     15    SICAP-ANO-CRED           PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICAP_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     15    SICAP-MES-CRED           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     15    SICAP-DIA-CRED           PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICAP_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   10      SICAP-BARRA01            PIC  X(016) VALUE SPACES.*/
                }
                public StringBasis SICAP_BARRA01 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"   10      SICAP-CODBANCO           PIC  9(003) VALUE ZEROS.*/
                public IntBasis SICAP_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   10      SICAP-BARRA02            PIC  X(005) VALUE SPACES.*/
                public StringBasis SICAP_BARRA02 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10      SICAP-NUM-SIVPF          PIC  9(013) VALUE ZEROS.*/
                public IntBasis SICAP_NUM_SIVPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"   10      SICAP-BARRA03            PIC  X(007) VALUE SPACES.*/
                public StringBasis SICAP_BARRA03 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"   10      SICAP-VALOR-PAGO         PIC  9(010)V99 VALUE ZEROS.*/
                public DoubleBasis SICAP_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
                /*"   10      SICAP-VALOR-TARIFA       PIC  9(005)V99 VALUE ZEROS.*/
                public DoubleBasis SICAP_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99"), 2);
                /*" 01        REG-SICA11.*/
            }
            public EM8006B_REG_SICA11 REG_SICA11 { get; set; } = new EM8006B_REG_SICA11();
            public class EM8006B_REG_SICA11 : VarBasis
            {
                /*"   05      SICA11-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SICA11_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      SICA11-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SICA11_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"   05      SICA11-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SICA11_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"   05      SICA11-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SICA11_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SICA11-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
                public IntBasis SICA11_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   05      SICA11-DTGERACAO.*/
                public EM8006B_SICA11_DTGERACAO SICA11_DTGERACAO { get; set; } = new EM8006B_SICA11_DTGERACAO();
                public class EM8006B_SICA11_DTGERACAO : VarBasis
                {
                    /*"     10    SICA11-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA11_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA11-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA11-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA11-USO-EMPRESA       PIC  X(025) VALUE SPACES.*/
                }
                public StringBasis SICA11_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"   05      SICA11-AGENCIA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICA11_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05      SICA11-OPERACAO          PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICA11_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05      SICA11-NUM-CONTA         PIC  9(012) VALUE ZEROS.*/
                public IntBasis SICA11_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"   05      SICA11-DIG-CONTA         PIC  9(001) VALUE ZEROS.*/
                public IntBasis SICA11_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   05      SICA11-VALOR-PAGO        PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis SICA11_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA11-VALOR-TARIFA      PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis SICA11_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA11-DATA-PAGTO.*/
                public EM8006B_SICA11_DATA_PAGTO SICA11_DATA_PAGTO { get; set; } = new EM8006B_SICA11_DATA_PAGTO();
                public class EM8006B_SICA11_DATA_PAGTO : VarBasis
                {
                    /*"     10    SICA11-ANO-PAGTO         PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA11_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA11-MES-PAGTO         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA11-DIA-PAGTO         PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA11-DATA-CREDITO.*/
                }
                public EM8006B_SICA11_DATA_CREDITO SICA11_DATA_CREDITO { get; set; } = new EM8006B_SICA11_DATA_CREDITO();
                public class EM8006B_SICA11_DATA_CREDITO : VarBasis
                {
                    /*"     10    SICA11-ANO-CRED          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA11_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA11-MES-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA11-DIA-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA11_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA11-FILLER            PIC  X(144).*/
                }
                public StringBasis SICA11_FILLER { get; set; } = new StringBasis(new PIC("X", "144", "X(144)."), @"");
                /*" 01        REG-SIGC13.*/
            }
            public EM8006B_REG_SIGC13 REG_SIGC13 { get; set; } = new EM8006B_REG_SIGC13();
            public class EM8006B_REG_SIGC13 : VarBasis
            {
                /*"   05      SIGC13-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SIGC13_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      SIGC13-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SIGC13_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"   05      SIGC13-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SIGC13_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"   05      SIGC13-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SIGC13_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SIGC13-NSAC              PIC  9(005) VALUE ZEROS.*/
                public IntBasis SIGC13_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"   05      SIGC13-RESTO.*/
                public EM8006B_SIGC13_RESTO SIGC13_RESTO { get; set; } = new EM8006B_SIGC13_RESTO();
                public class EM8006B_SIGC13_RESTO : VarBasis
                {
                    /*"      10   SIGC13-NUM-PROPOSTA      PIC  X(016) VALUE SPACES.*/
                    public StringBasis SIGC13_NUM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                    /*"      10   SIGC13-NUM-BOL-INTERNO   PIC  X(010) VALUE SPACES.*/
                    public StringBasis SIGC13_NUM_BOL_INTERNO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"      10   SIGC13-NN-REGISTRADO     PIC  X(018) VALUE SPACES.*/
                    public StringBasis SIGC13_NN_REGISTRADO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                    /*"      10   SIGC13-LNHA-DIGITAVEL    PIC  X(054) VALUE SPACES.*/
                    public StringBasis SIGC13_LNHA_DIGITAVEL { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
                    /*"      10   SIGC13-COD-AG-CEDENTE    PIC  X(020) VALUE SPACES.*/
                    public StringBasis SIGC13_COD_AG_CEDENTE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                    /*"      10   SIGC13-NUM-BCO-RECEB     PIC  9(003) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_BCO_RECEB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                    /*"      10   SIGC13-NUM-AGE-RECEB     PIC  9(005) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                    /*"      10   SIGC13-DV-AGE-RECEB      PIC  9(001) VALUE ZEROS.*/
                    public IntBasis SIGC13_DV_AGE_RECEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                    /*"      10   SIGC13-DTA-VENCIMENTO.*/
                    public EM8006B_SIGC13_DTA_VENCIMENTO SIGC13_DTA_VENCIMENTO { get; set; } = new EM8006B_SIGC13_DTA_VENCIMENTO();
                    public class EM8006B_SIGC13_DTA_VENCIMENTO : VarBasis
                    {
                        /*"         15 SIGC13-DIA-VENCIMENTO   PIC  9(002) VALUE ZEROS.*/
                        public IntBasis SIGC13_DIA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                        /*"         15 SIGC13-MES-VENCIMENTO   PIC  9(002) VALUE ZEROS.*/
                        public IntBasis SIGC13_MES_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                        /*"         15 SIGC13-ANO-VENCIMENTO   PIC  9(004) VALUE ZEROS.*/
                        public IntBasis SIGC13_ANO_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                        /*"      10   SIGC13-DTA-PAGAMENTO     PIC  9(008) VALUE ZEROS.*/
                    }
                    public IntBasis SIGC13_DTA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   SIGC13-DTA-CREDITO       PIC  9(008) VALUE ZEROS.*/
                    public IntBasis SIGC13_DTA_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   SIGC13-DTA-DEB-TARIFA    PIC  9(008) VALUE ZEROS.*/
                    public IntBasis SIGC13_DTA_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   SIGC13-VLR-ACRESCIMO     PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_ACRESCIMO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-DESCONTO      PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_DESCONTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-ABATIMENTO    PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_ABATIMENTO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-IOF           PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_IOF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-PAGO          PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_PAGO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-LIQUIDO       PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_LIQUIDO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-VLR-TARIFA        PIC  9(015) VALUE ZEROS.*/
                    public IntBasis SIGC13_VLR_TARIFA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                    /*"      10   SIGC13-COD-MOVIMENTO     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SIGC13_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"      10   SIGC13-COD-REJEICAO      PIC  X(010) VALUE SPACES.*/
                    public StringBasis SIGC13_COD_REJEICAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                    /*"      10   SIGC13-NUM-TITULO        PIC  9(016) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
                    /*"      10   SIGC13-COD-SISTEMA       PIC  X(003) VALUE SPACES.*/
                    public StringBasis SIGC13_COD_SISTEMA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                    /*"      10   SIGC13-NUM-PARCELA       PIC  9(003) VALUE ZEROS.*/
                    public IntBasis SIGC13_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                    /*"      10   SIGC13-COD-PRODUTO       PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SIGC13_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"      10   SIGC13-DTA-GERACAO       PIC  9(008) VALUE ZEROS.*/
                    public IntBasis SIGC13_DTA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
                    /*"      10   FILLER                   PIC  X(030) VALUE SPACES.*/
                    public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                    /*"01        REG-CESTA-HEAD.*/
                }
            }
        }
        public EM8006B_REG_CESTA_HEAD REG_CESTA_HEAD { get; set; } = new EM8006B_REG_CESTA_HEAD();
        public class EM8006B_REG_CESTA_HEAD : VarBasis
        {
            /*"  05      CESTA-H-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
            public StringBasis CESTA_H_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CESTA-H-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
            public IntBasis CESTA_H_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CESTA-H-DT-PROCESSA       PIC  X(008) VALUE SPACES.*/
            public StringBasis CESTA_H_DT_PROCESSA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CESTA-H-ORIG-EMP          PIC  X(004) VALUE SPACES.*/
            public StringBasis CESTA_H_ORIG_EMP { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      CESTA-H-NSA-SAP           PIC  9(009) VALUE ZEROS.*/
            public IntBasis CESTA_H_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CESTA-H-FILLER            PIC  X(268) VALUE SPACES.*/
            public StringBasis CESTA_H_FILLER { get; set; } = new StringBasis(new PIC("X", "268", "X(268)"), @"");
            /*"01        REG-CESTA-DET.*/
        }
        public EM8006B_REG_CESTA_DET REG_CESTA_DET { get; set; } = new EM8006B_REG_CESTA_DET();
        public class EM8006B_REG_CESTA_DET : VarBasis
        {
            /*"  05      CESTA-D-TIPO-REGISTRO     PIC  9(002) VALUE ZEROS.*/
            public IntBasis CESTA_D_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      CESTA-D-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
            public IntBasis CESTA_D_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CESTA-D-IDLG              PIC  X(040) VALUE SPACES.*/
            public StringBasis CESTA_D_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      CESTA-D-AUGST             PIC  X(001) VALUE SPACES.*/
            public StringBasis CESTA_D_AUGST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      CESTA-D-AUGRD             PIC  9(002) VALUE ZEROS.*/
            public IntBasis CESTA_D_AUGRD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      CESTA-D-BELNR             PIC  X(010) VALUE SPACES.*/
            public StringBasis CESTA_D_BELNR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CESTA-D-BUZEI             PIC  9(003) VALUE ZEROS.*/
            public IntBasis CESTA_D_BUZEI { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CESTA-D-OPBEL             PIC  X(012) VALUE SPACES.*/
            public StringBasis CESTA_D_OPBEL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      CESTA-D-OPUPK             PIC  9(004) VALUE ZEROS.*/
            public IntBasis CESTA_D_OPUPK { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CESTA-D-AUGBL             PIC  X(012) VALUE SPACES.*/
            public StringBasis CESTA_D_AUGBL { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05      CESTA-D-AUGVD             PIC  9(008) VALUE ZEROS.*/
            public IntBasis CESTA_D_AUGVD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05      CESTA-D-BLART             PIC  X(002) VALUE SPACES.*/
            public StringBasis CESTA_D_BLART { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CESTA-D-BLDAT             PIC  X(008) VALUE SPACES.*/
            public StringBasis CESTA_D_BLDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CESTA-D-BUDAT             PIC  X(008) VALUE SPACES.*/
            public StringBasis CESTA_D_BUDAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CESTA-D-BUKRS             PIC  X(004) VALUE SPACES.*/
            public StringBasis CESTA_D_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      CESTA-D-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis CESTA_D_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CESTA-D-DT-GERACAO        PIC  9(008) VALUE ZEROS.*/
            public IntBasis CESTA_D_DT_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05      CESTA-D-NUM-PROPOSTA      PIC  9(014) VALUE ZEROS.*/
            public IntBasis CESTA_D_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  05      CESTA-D-AGENCIA-CLI       PIC  9(004) VALUE ZEROS.*/
            public IntBasis CESTA_D_AGENCIA_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CESTA-D-OPERACAO-CLI      PIC  9(004) VALUE ZEROS.*/
            public IntBasis CESTA_D_OPERACAO_CLI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CESTA-D-CONTA-CLI         PIC  9(012) VALUE ZEROS.*/
            public IntBasis CESTA_D_CONTA_CLI { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"  05      CESTA-D-CONTA-DV-CLI      PIC  9(001) VALUE ZEROS.*/
            public IntBasis CESTA_D_CONTA_DV_CLI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05      CESTA-D-VALOR-PAGO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CESTA_D_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CESTA-D-COD-RETORNO       PIC  9(003) VALUE ZEROS.*/
            public IntBasis CESTA_D_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CESTA-D-MSG-RETORNO       PIC  X(045) VALUE SPACES.*/
            public StringBasis CESTA_D_MSG_RETORNO { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"");
            /*"  05      CESTA-H-FILLER            PIC  X(063) VALUE SPACES.*/
            public StringBasis CESTA_H_FILLER_0 { get; set; } = new StringBasis(new PIC("X", "63", "X(063)"), @"");
            /*" 01        HEADER-SAIDA11.*/
            public EM8006B_HEADER_SAIDA11 HEADER_SAIDA11 { get; set; } = new EM8006B_HEADER_SAIDA11();
            public class EM8006B_HEADER_SAIDA11 : VarBasis
            {
                /*"   05      HEAD11-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis HEAD11_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      HEAD11-DTMOVTO.*/
                public EM8006B_HEAD11_DTMOVTO HEAD11_DTMOVTO { get; set; } = new EM8006B_HEAD11_DTMOVTO();
                public class EM8006B_HEAD11_DTMOVTO : VarBasis
                {
                    /*"     10    HEAD11-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis HEAD11_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    HEAD11-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD11_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    HEAD11-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD11_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      HEAD11-DESCRICAO         PIC  X(050) VALUE SPACES.*/
                }
                public StringBasis HEAD11_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*" 01        REG-SICA12.*/
            }
            public EM8006B_REG_SICA12 REG_SICA12 { get; set; } = new EM8006B_REG_SICA12();
            public class EM8006B_REG_SICA12 : VarBasis
            {
                /*"   05      SICA12-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis SICA12_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      SICA12-SEQ-REGISTRO      PIC  9(009) VALUE ZEROS.*/
                public IntBasis SICA12_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"   05      SICA12-IDLG              PIC  X(040) VALUE SPACES.*/
                public StringBasis SICA12_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"   05      SICA12-BUKRS             PIC  X(004) VALUE SPACES.*/
                public StringBasis SICA12_BUKRS { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SICA12-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
                public IntBasis SICA12_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"   05      SICA12-DTMOVTO.*/
                public EM8006B_SICA12_DTMOVTO SICA12_DTMOVTO { get; set; } = new EM8006B_SICA12_DTMOVTO();
                public class EM8006B_SICA12_DTMOVTO : VarBasis
                {
                    /*"     10    SICA12-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA12_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA12-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA12-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA12-VALOR-VENDA       PIC  9(013)V99 VALUE ZEROS.*/
                }
                public DoubleBasis SICA12_VALOR_VENDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA12-VALOR-PARCELA     PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis SICA12_VALOR_PARCELA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"   05      SICA12-DATA-CREDITO.*/
                public EM8006B_SICA12_DATA_CREDITO SICA12_DATA_CREDITO { get; set; } = new EM8006B_SICA12_DATA_CREDITO();
                public class EM8006B_SICA12_DATA_CREDITO : VarBasis
                {
                    /*"     10    SICA12-ANO-CRED          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis SICA12_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    SICA12-MES-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    SICA12-DIA-CRED          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis SICA12_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      SICA12-BANCO             PIC  9(003) VALUE ZEROS.*/
                }
                public IntBasis SICA12_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"   05      SICA12-BANCO-DV          PIC  9(001) VALUE ZEROS.*/
                public IntBasis SICA12_BANCO_DV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"   05      SICA12-AGENCIA           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SICA12_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05      SICA12-STATUS            PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICA12_STATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05      SICA12-COD-ERRO          PIC  X(004) VALUE SPACES.*/
                public StringBasis SICA12_COD_ERRO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"   05      SICA12-FILLER            PIC  X(179).*/
                public StringBasis SICA12_FILLER { get; set; } = new StringBasis(new PIC("X", "179", "X(179)."), @"");
                /*" 01        HEADER-SAIDA12.*/
            }
            public EM8006B_HEADER_SAIDA12 HEADER_SAIDA12 { get; set; } = new EM8006B_HEADER_SAIDA12();
            public class EM8006B_HEADER_SAIDA12 : VarBasis
            {
                /*"   05      HEAD12-TIPO-REGISTRO     PIC  X(002) VALUE SPACES.*/
                public StringBasis HEAD12_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"   05      HEAD12-DTMOVTO.*/
                public EM8006B_HEAD12_DTMOVTO HEAD12_DTMOVTO { get; set; } = new EM8006B_HEAD12_DTMOVTO();
                public class EM8006B_HEAD12_DTMOVTO : VarBasis
                {
                    /*"     10    HEAD12-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                    public IntBasis HEAD12_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"     10    HEAD12-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD12_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"     10    HEAD12-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                    public IntBasis HEAD12_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"   05      HEAD12-DESCRICAO         PIC  X(050) VALUE SPACES.*/
                }
                public StringBasis HEAD12_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"01        REG-SICOB.*/
            }
        }
        public EM8006B_REG_SICOB REG_SICOB { get; set; } = new EM8006B_REG_SICOB();
        public class EM8006B_REG_SICOB : VarBasis
        {
            /*"  10      SICOB-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis SICOB_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      SICOB-COD-REGISTRO       PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-TIPO-INSCRICAO     PIC  9(002) VALUE ZEROS.*/
            public IntBasis SICOB_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      SICOB-NUM-INSCRICAO      PIC  9(014) VALUE ZEROS.*/
            public IntBasis SICOB_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  10      SICOB-COD-CEDENTE        PIC  9(016) VALUE ZEROS.*/
            public IntBasis SICOB_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  10      SICOB-COD-BANCO          PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-NSAC               PIC  9(005) VALUE ZEROS.*/
            public IntBasis SICOB_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  10      SICOB-DTGERACAO.*/
            public EM8006B_SICOB_DTGERACAO SICOB_DTGERACAO { get; set; } = new EM8006B_SICOB_DTGERACAO();
            public class EM8006B_SICOB_DTGERACAO : VarBasis
            {
                /*"    15    SICOB-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-TITULO-EMPRESA     PIC  9(016) VALUE ZEROS.*/
            }
            public IntBasis SICOB_TITULO_EMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  10      SICOB-TITULO-BANCO       PIC  9(011) VALUE ZEROS.*/
            public IntBasis SICOB_TITULO_BANCO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  10      SICOB-COD-REJEICAO       PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_COD_REJEICAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-COD-OCORRENCIA     PIC  9(002) VALUE ZEROS.*/
            public IntBasis SICOB_COD_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      SICOB-DATA-OCORRENCIA.*/
            public EM8006B_SICOB_DATA_OCORRENCIA SICOB_DATA_OCORRENCIA { get; set; } = new EM8006B_SICOB_DATA_OCORRENCIA();
            public class EM8006B_SICOB_DATA_OCORRENCIA : VarBasis
            {
                /*"    15    SICOB-DIA-OCORR          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-OCORR          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-OCORR          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-DATA-VENCIMENTO.*/
            }
            public EM8006B_SICOB_DATA_VENCIMENTO SICOB_DATA_VENCIMENTO { get; set; } = new EM8006B_SICOB_DATA_VENCIMENTO();
            public class EM8006B_SICOB_DATA_VENCIMENTO : VarBasis
            {
                /*"    15    SICOB-DIA-VENCTO         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-VENCTO         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-VENCTO         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-VLR-NOMINAL-TIT    PIC  9(011)V99 VALUE ZEROS.*/
            }
            public DoubleBasis SICOB_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-COD-COMP-CAIXA     PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_COD_COMP_CAIXA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-AGE-COBR           PIC  9(004) VALUE ZEROS.*/
            public IntBasis SICOB_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      SICOB-AGE-DIG-COBR       PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-ESPECIE            PIC  X(002) VALUE SPACES.*/
            public StringBasis SICOB_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  10      SICOB-VLR-TARIFA         PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-FORMA-LIQUIDACAO   PIC  9(003) VALUE ZEROS.*/
            public IntBasis SICOB_FORMA_LIQUIDACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      SICOB-FORMA-PAGAMENTO    PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_FORMA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-QTD-DIAS-FLOAT     PIC  9(002) VALUE ZEROS.*/
            public IntBasis SICOB_QTD_DIAS_FLOAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      SICOB-DATA-DEB-TARIFA.*/
            public EM8006B_SICOB_DATA_DEB_TARIFA SICOB_DATA_DEB_TARIFA { get; set; } = new EM8006B_SICOB_DATA_DEB_TARIFA();
            public class EM8006B_SICOB_DATA_DEB_TARIFA : VarBasis
            {
                /*"    15    SICOB-DIA-TARIFA         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-TARIFA         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-TARIFA         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_TARIFA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-VLR-IOF            PIC  9(011)V99 VALUE ZEROS.*/
            }
            public DoubleBasis SICOB_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-ABATIMENTO     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-DESCONTO       PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-PRINCIPAL      PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-JUROS          PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-VLR-MULTA          PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis SICOB_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      SICOB-COD-MOEDA          PIC  9(001) VALUE ZEROS.*/
            public IntBasis SICOB_COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SICOB-DATA-CREDITO.*/
            public EM8006B_SICOB_DATA_CREDITO SICOB_DATA_CREDITO { get; set; } = new EM8006B_SICOB_DATA_CREDITO();
            public class EM8006B_SICOB_DATA_CREDITO : VarBasis
            {
                /*"    15    SICOB-DIA-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-MES-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SICOB-ANO-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SICOB_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SICOB-FINANCEIRO         PIC  9(016) VALUE ZEROS.*/
            }
            public IntBasis SICOB_FINANCEIRO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"01        REG-SIGPF.*/
        }
        public EM8006B_REG_SIGPF REG_SIGPF { get; set; } = new EM8006B_REG_SIGPF();
        public class EM8006B_REG_SIGPF : VarBasis
        {
            /*"  10      SIGPF-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis SIGPF_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      SIGPF-CONVENIO-SAP       PIC  9(006) VALUE ZEROS.*/
            public IntBasis SIGPF_CONVENIO_SAP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  10      SIGPF-NSAC               PIC  9(005) VALUE ZEROS.*/
            public IntBasis SIGPF_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  10      SIGPF-DTGERACAO.*/
            public EM8006B_SIGPF_DTGERACAO SIGPF_DTGERACAO { get; set; } = new EM8006B_SIGPF_DTGERACAO();
            public class EM8006B_SIGPF_DTGERACAO : VarBasis
            {
                /*"    15    SIGPF-ANO-HEADER         PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGPF_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    15    SIGPF-MES-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SIGPF-DIA-HEADER         PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SIGPF-COD-REGISTRO       PIC  9(001) VALUE ZEROS.*/
            }
            public IntBasis SIGPF_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SIGPF-NUM-SIVPF          PIC  9(014) VALUE ZEROS.*/
            public IntBasis SIGPF_NUM_SIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  10      SIGPF-AGENCIA            PIC  9(004) VALUE ZEROS.*/
            public IntBasis SIGPF_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      SIGPF-OPERACAO           PIC  9(004) VALUE ZEROS.*/
            public IntBasis SIGPF_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      SIGPF-NUM-CONTA          PIC  9(012) VALUE ZEROS.*/
            public IntBasis SIGPF_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"  10      SIGPF-DIG-CONTA          PIC  9(001) VALUE ZEROS.*/
            public IntBasis SIGPF_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      SIGPF-VALOR-PAGO         PIC  9(012)V99 VALUE ZEROS.*/
            public DoubleBasis SIGPF_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
            /*"  10      SIGPF-VALOR-BALCAO       PIC  9(012)V99 VALUE ZEROS.*/
            public DoubleBasis SIGPF_VALOR_BALCAO { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
            /*"  10      SIGPF-VALOR-TARIFA       PIC  9(012)V99 VALUE ZEROS.*/
            public DoubleBasis SIGPF_VALOR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "12", "9(012)V99"), 2);
            /*"  10      SIGPF-DATA-PAGTO.*/
            public EM8006B_SIGPF_DATA_PAGTO SIGPF_DATA_PAGTO { get; set; } = new EM8006B_SIGPF_DATA_PAGTO();
            public class EM8006B_SIGPF_DATA_PAGTO : VarBasis
            {
                /*"    15    SIGPF-ANO-PAGTO          PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGPF_ANO_PAGTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    15    SIGPF-MES-PAGTO          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_MES_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SIGPF-DIA-PAGTO          PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_DIA_PAGTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      SIGPF-DATA-CREDITO.*/
            }
            public EM8006B_SIGPF_DATA_CREDITO SIGPF_DATA_CREDITO { get; set; } = new EM8006B_SIGPF_DATA_CREDITO();
            public class EM8006B_SIGPF_DATA_CREDITO : VarBasis
            {
                /*"    15    SIGPF-ANO-CRED           PIC  9(004) VALUE ZEROS.*/
                public IntBasis SIGPF_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    15    SIGPF-MES-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    SIGPF-DIA-CRED           PIC  9(002) VALUE ZEROS.*/
                public IntBasis SIGPF_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01        REG-CARTAO.*/
            }
        }
        public EM8006B_REG_CARTAO REG_CARTAO { get; set; } = new EM8006B_REG_CARTAO();
        public class EM8006B_REG_CARTAO : VarBasis
        {
            /*"  05      CARTAO-TIPO-ARQUIVO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CARTAO_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CARTAO-CODBANCO          PIC  9(003) VALUE ZEROS.*/
            public IntBasis CARTAO_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CARTAO-CONVENIO          PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_CONVENIO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-NSAS              PIC  9(006) VALUE ZEROS.*/
            public IntBasis CARTAO_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CARTAO-NUM-APOLICE       PIC  9(013) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      CARTAO-NUM-ENDOSSO       PIC  9(009) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CARTAO-NUM-PARCELA       PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-NUM-REQUISICAO    PIC  9(009) VALUE ZEROS.*/
            public IntBasis CARTAO_NUM_REQUISICAO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CARTAO-TIPO-LANCAMENTO   PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_TIPO_LANCAMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-NSAC              PIC  9(006) VALUE ZEROS.*/
            public IntBasis CARTAO_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CARTAO-DTGERACAO.*/
            public EM8006B_CARTAO_DTGERACAO CARTAO_DTGERACAO { get; set; } = new EM8006B_CARTAO_DTGERACAO();
            public class EM8006B_CARTAO_DTGERACAO : VarBasis
            {
                /*"    10    CARTAO-ANO-HEADER        PIC  9(004) VALUE ZEROS.*/
                public IntBasis CARTAO_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    CARTAO-MES-HEADER        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    CARTAO-DIA-HEADER        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      CARTAO-MOTIVO            PIC  X(002) VALUE SPACES.*/
            }
            public StringBasis CARTAO_MOTIVO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CARTAO-COD-TRANSACAO     PIC  9(003) VALUE ZEROS.*/
            public IntBasis CARTAO_COD_TRANSACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CARTAO-NUM-CARTAO        PIC  X(019) VALUE SPACES.*/
            public StringBasis CARTAO_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"  05      CARTAO-DTVENCTO.*/
            public EM8006B_CARTAO_DTVENCTO CARTAO_DTVENCTO { get; set; } = new EM8006B_CARTAO_DTVENCTO();
            public class EM8006B_CARTAO_DTVENCTO : VarBasis
            {
                /*"    10    CARTAO-ANO-VENCTO        PIC  9(004) VALUE ZEROS.*/
                public IntBasis CARTAO_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    CARTAO-MES-VENCTO        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    CARTAO-DIA-VENCTO        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      CARTAO-VLR-TRANSACAO     PIC  9(013)V99 VALUE ZEROS.*/
            }
            public DoubleBasis CARTAO_VLR_TRANSACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CARTAO-VLR-CREDITO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CARTAO_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CARTAO-VLR-TARIFA        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CARTAO_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CARTAO-NOVO-CARTAO       PIC  X(019) VALUE SPACES.*/
            public StringBasis CARTAO_NOVO_CARTAO { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
            /*"  05      CARTAO-NOVO-DIA-VENCTO   PIC  9(004) VALUE ZEROS.*/
            public IntBasis CARTAO_NOVO_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      CARTAO-DATA-AGENDAMENTO.*/
            public EM8006B_CARTAO_DATA_AGENDAMENTO CARTAO_DATA_AGENDAMENTO { get; set; } = new EM8006B_CARTAO_DATA_AGENDAMENTO();
            public class EM8006B_CARTAO_DATA_AGENDAMENTO : VarBasis
            {
                /*"    10    CARTAO-ANO-AGENDA        PIC  9(004) VALUE ZEROS.*/
                public IntBasis CARTAO_ANO_AGENDA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10    CARTAO-MES-AGENDA        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_MES_AGENDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    CARTAO-DIA-AGENDA        PIC  9(002) VALUE ZEROS.*/
                public IntBasis CARTAO_DIA_AGENDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      CARTAO-MOT-RETORNO       PIC  9(002) VALUE ZEROS.*/
            }
            public IntBasis CARTAO_MOT_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      CARTAO-MOT-CANCEL        PIC  X(002) VALUE SPACES.*/
            public StringBasis CARTAO_MOT_CANCEL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05      CARTAO-BANCO             PIC  9(003) VALUE ZEROS.*/
            public IntBasis CARTAO_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  05      CARTAO-AGENCIA           PIC  9(005) VALUE ZEROS.*/
            public IntBasis CARTAO_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05      CARTAO-CONTA             PIC  9(012) VALUE ZEROS.*/
            public IntBasis CARTAO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"01        REG-CHEQUE.*/
        }
        public EM8006B_REG_CHEQUE REG_CHEQUE { get; set; } = new EM8006B_REG_CHEQUE();
        public class EM8006B_REG_CHEQUE : VarBasis
        {
            /*"  05      CHEQUE-TIPO-ARQUIVO      PIC  X(010) VALUE SPACES.*/
            public StringBasis CHEQUE_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CHEQUE-ORIGEM-EMPRESA    PIC  X(004) VALUE SPACES.*/
            public StringBasis CHEQUE_ORIGEM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      CHEQUE-IDLG              PIC  X(040) VALUE SPACES.*/
            public StringBasis CHEQUE_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      CHEQUE-NSA-BANCO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis CHEQUE_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      CHEQUE-CPF-CNPJ          PIC  X(020) VALUE SPACES.*/
            public StringBasis CHEQUE_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05      CHEQUE-EVENTO            PIC  X(010) VALUE SPACES.*/
            public StringBasis CHEQUE_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      CHEQUE-VALOR-BRUTO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-IRRF        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-ISS         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-INSS        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-COFINS      PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_COFINS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-CSLL        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_CSLL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-PIS         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_PIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-VALOR-PAGTO       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis CHEQUE_VALOR_PAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      CHEQUE-DATA-CREDITO      PIC  X(008) VALUE SPACES.*/
            public StringBasis CHEQUE_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CHEQUE-DATA-ENVIO        PIC  X(008) VALUE SPACES.*/
            public StringBasis CHEQUE_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CHEQUE-DATA-CONTABIL     PIC  X(008) VALUE SPACES.*/
            public StringBasis CHEQUE_DATA_CONTABIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      CHEQUE-MEIO-PAGTO        PIC  X(001) VALUE SPACES.*/
            public StringBasis CHEQUE_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      CHEQUE-NUM-CHEQUE        PIC  9(013) VALUE ZEROS.*/
            public IntBasis CHEQUE_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      CHEQUE-NUM-SIVAT         PIC  9(009) VALUE ZEROS.*/
            public IntBasis CHEQUE_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      CHEQUE-OCORRENCIA        PIC  X(010) VALUE SPACES.*/
            public StringBasis CHEQUE_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01        REG-SIACC.*/
        }
        public EM8006B_REG_SIACC REG_SIACC { get; set; } = new EM8006B_REG_SIACC();
        public class EM8006B_REG_SIACC : VarBasis
        {
            /*"  05      SIACC-TIPO-ARQUIVO       PIC  X(010) VALUE SPACES.*/
            public StringBasis SIACC_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      SIACC-ORIGEM-EMPRESA     PIC  X(004) VALUE SPACES.*/
            public StringBasis SIACC_ORIGEM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
            /*"  05      SIACC-IDLG               PIC  X(040) VALUE SPACES.*/
            public StringBasis SIACC_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05      SIACC-CONVENIO           PIC  9(006) VALUE ZEROS.*/
            public IntBasis SIACC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      SIACC-NSA-BANCO          PIC  9(006) VALUE ZEROS.*/
            public IntBasis SIACC_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05      SIACC-CPF-CNPJ           PIC  X(020) VALUE SPACES.*/
            public StringBasis SIACC_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  05      SIACC-EVENTO             PIC  X(010) VALUE SPACES.*/
            public StringBasis SIACC_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      SIACC-VALOR-BRUTO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-IRRF         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-ISS          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-INSS         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-COFINS       PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_COFINS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-CSLL         PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_CSLL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-PIS          PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_PIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-VALOR-PAGTO        PIC  9(013)V99 VALUE ZEROS.*/
            public DoubleBasis SIACC_VALOR_PAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"  05      SIACC-DATA-CREDITO       PIC  X(008) VALUE SPACES.*/
            public StringBasis SIACC_DATA_CREDITO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      SIACC-DATA-ENVIO         PIC  X(008) VALUE SPACES.*/
            public StringBasis SIACC_DATA_ENVIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      SIACC-DATA-CONTABIL      PIC  X(008) VALUE SPACES.*/
            public StringBasis SIACC_DATA_CONTABIL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05      SIACC-MEIO-PAGTO         PIC  X(001) VALUE SPACES.*/
            public StringBasis SIACC_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      SIACC-NUM-CHEQUE         PIC  9(013) VALUE ZEROS.*/
            public IntBasis SIACC_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05      SIACC-NUM-SIVAT          PIC  9(009) VALUE ZEROS.*/
            public IntBasis SIACC_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      SIACC-OCORRENCIA         PIC  X(010) VALUE SPACES.*/
            public StringBasis SIACC_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01        REG-BANCOOB.*/
        }
        public EM8006B_REG_BANCOOB REG_BANCOOB { get; set; } = new EM8006B_REG_BANCOOB();
        public class EM8006B_REG_BANCOOB : VarBasis
        {
            /*"  10      BANCOOB-TIPO-ARQUIVO     PIC  X(010) VALUE SPACES.*/
            public StringBasis BANCOOB_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      BANCOOB-COD-REGISTRO     PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-TIPO-INSCRICAO   PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-NUM-INSCRICAO    PIC  9(014) VALUE ZEROS.*/
            public IntBasis BANCOOB_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  10      BANCOOB-COD-AGENCIA      PIC  9(004) VALUE ZEROS.*/
            public IntBasis BANCOOB_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      BANCOOB-DIG-AGENCIA      PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIG_AGENCIA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-NRO-CONTA        PIC  9(012) VALUE ZEROS.*/
            public IntBasis BANCOOB_NRO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
            /*"  10      BANCOOB-DIG-CONTA        PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-CEDENTE          PIC  9(008) VALUE ZEROS.*/
            public IntBasis BANCOOB_CEDENTE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  10      BANCOOB-CONVENIO         PIC  9(006) VALUE ZEROS.*/
            public IntBasis BANCOOB_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  10      BANCOOB-CONTROLE         PIC  X(025) VALUE SPACES.*/
            public StringBasis BANCOOB_CONTROLE { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  10      BANCOOB-NRO-TITULO       PIC  9(011) VALUE ZEROS.*/
            public IntBasis BANCOOB_NRO_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  10      BANCOOB-DIG-TITULO       PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIG_TITULO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-NRO-PARCELA      PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_NRO_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-DIAS-CALCULO     PIC  9(004) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIAS_CALCULO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      BANCOOB-MOTIVO           PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_MOTIVO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-PREFIXO          PIC  X(003) VALUE SPACES.*/
            public StringBasis BANCOOB_PREFIXO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  10      BANCOOB-VARIACAO         PIC  9(003) VALUE ZEROS.*/
            public IntBasis BANCOOB_VARIACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      BANCOOB-CAUCAO           PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_CAUCAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-RESPONSABIL      PIC  9(005) VALUE ZEROS.*/
            public IntBasis BANCOOB_RESPONSABIL { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  10      BANCOOB-DIGITO           PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-TAXA-DESCON      PIC  9(003)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_TAXA_DESCON { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99"), 2);
            /*"  10      BANCOOB-TAXA-IOF         PIC  9(001)V9999 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_TAXA_IOF { get; set; } = new DoubleBasis(new PIC("9", "1", "9(001)V9999"), 4);
            /*"  10      FILLER                   PIC  X(001) VALUE SPACES.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  10      BANCOOB-CARTEIRA         PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-COMANDO          PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_COMANDO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-DTLIQUIDA.*/
            public EM8006B_BANCOOB_DTLIQUIDA BANCOOB_DTLIQUIDA { get; set; } = new EM8006B_BANCOOB_DTLIQUIDA();
            public class EM8006B_BANCOOB_DTLIQUIDA : VarBasis
            {
                /*"    15    BANCOOB-DIA-LIQUIDA      PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-LIQUIDA      PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-LIQUIDA      PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_LIQUIDA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      BANCOOB-SEU-NUMERO       PIC  X(010) VALUE SPACES.*/
            }
            public StringBasis BANCOOB_SEU_NUMERO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      FILLER                   PIC  X(020) VALUE SPACES.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"  10      BANCOOB-DTVENCTO.*/
            public EM8006B_BANCOOB_DTVENCTO BANCOOB_DTVENCTO { get; set; } = new EM8006B_BANCOOB_DTVENCTO();
            public class EM8006B_BANCOOB_DTVENCTO : VarBasis
            {
                /*"    15    BANCOOB-DIA-VENCTO       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-VENCTO       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-VENCTO       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_VENCTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      BANCOOB-VLR-NOMINAL-TIT  PIC  9(011)V99 VALUE ZEROS.*/
            }
            public DoubleBasis BANCOOB_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-COD-BANCO        PIC  9(003) VALUE ZEROS.*/
            public IntBasis BANCOOB_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      BANCOOB-AGE-COBR         PIC  9(004) VALUE ZEROS.*/
            public IntBasis BANCOOB_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  10      BANCOOB-AGE-DIG-COBR     PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-ESPECIE          PIC  9(002) VALUE ZEROS.*/
            public IntBasis BANCOOB_ESPECIE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  10      BANCOOB-DATA-CREDITO.*/
            public EM8006B_BANCOOB_DATA_CREDITO BANCOOB_DATA_CREDITO { get; set; } = new EM8006B_BANCOOB_DATA_CREDITO();
            public class EM8006B_BANCOOB_DATA_CREDITO : VarBasis
            {
                /*"    15    BANCOOB-DIA-CRED         PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-CRED         PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-CRED         PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_CRED { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      BANCOOB-VLR-TARIFA       PIC  9(005)V99 VALUE ZEROS.*/
            }
            public DoubleBasis BANCOOB_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99"), 2);
            /*"  10      BANCOOB-VLR-DESPESAS     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-JUROS        PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-IOF          PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-ABATIMENTO   PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-DESCONTO     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-RECEBIDO     PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_RECEBIDO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-MORA         PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_MORA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-OUTROS       PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_OUTROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-ABATNAO      PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_ABATNAO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-VLR-LANCADO      PIC  9(011)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_LANCADO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99"), 2);
            /*"  10      BANCOOB-IND-DEBCRE       PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_IND_DEBCRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-IND-VALOR        PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_IND_VALOR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-VLR-AJUSTE       PIC  9(010)V99 VALUE ZEROS.*/
            public DoubleBasis BANCOOB_VLR_AJUSTE { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99"), 2);
            /*"  10      FILLER                   PIC  X(010) VALUE SPACES.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  10      BANCOOB-BANCO            PIC  9(003) VALUE ZEROS.*/
            public IntBasis BANCOOB_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
            /*"  10      BANCOOB-DIGBCO           PIC  9(001) VALUE ZEROS.*/
            public IntBasis BANCOOB_DIGBCO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  10      BANCOOB-NSAC             PIC  9(006) VALUE ZEROS.*/
            public IntBasis BANCOOB_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  10      BANCOOB-DTGERACAO.*/
            public EM8006B_BANCOOB_DTGERACAO BANCOOB_DTGERACAO { get; set; } = new EM8006B_BANCOOB_DTGERACAO();
            public class EM8006B_BANCOOB_DTGERACAO : VarBasis
            {
                /*"    15    BANCOOB-DIA-HEADER       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_DIA_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-MES-HEADER       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_MES_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    15    BANCOOB-ANO-HEADER       PIC  9(002) VALUE ZEROS.*/
                public IntBasis BANCOOB_ANO_HEADER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  10      FILLER                   PIC  X(020) VALUE SPACES.*/
            }
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
            /*"01        BACKS-REGISTRO.*/
        }
        public EM8006B_BACKS_REGISTRO BACKS_REGISTRO { get; set; } = new EM8006B_BACKS_REGISTRO();
        public class EM8006B_BACKS_REGISTRO : VarBasis
        {
            /*"  05      BACKS-CODREGISTRO  PIC  X(001).*/
            public StringBasis BACKS_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      BACKS-CTACOBRANCA.*/
            public EM8006B_BACKS_CTACOBRANCA BACKS_CTACOBRANCA { get; set; } = new EM8006B_BACKS_CTACOBRANCA();
            public class EM8006B_BACKS_CTACOBRANCA : VarBasis
            {
                /*"    10    BACKS-AGENCIA      PIC  9(004).*/
                public IntBasis BACKS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-OPERACAO     PIC  9(003).*/
                public IntBasis BACKS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    BACKS-NUMCTA       PIC  9(008).*/
                public IntBasis BACKS_NUMCTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10    BACKS-DIGCTA       PIC  9(001).*/
                public IntBasis BACKS_DIGCTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER             PIC  X(004).*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      BACKS-DTPAGTO.*/
            }
            public EM8006B_BACKS_DTPAGTO BACKS_DTPAGTO { get; set; } = new EM8006B_BACKS_DTPAGTO();
            public class EM8006B_BACKS_DTPAGTO : VarBasis
            {
                /*"    10    BACKS-ANOPAG       PIC  9(004).*/
                public IntBasis BACKS_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-MESPAG       PIC  9(002).*/
                public IntBasis BACKS_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    BACKS-DIAPAG       PIC  9(002).*/
                public IntBasis BACKS_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      BACKS-DTCREDITO.*/
            }
            public EM8006B_BACKS_DTCREDITO BACKS_DTCREDITO { get; set; } = new EM8006B_BACKS_DTCREDITO();
            public class EM8006B_BACKS_DTCREDITO : VarBasis
            {
                /*"    10    BACKS-ANOCRE       PIC  9(004).*/
                public IntBasis BACKS_ANOCRE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-MESCRE       PIC  9(002).*/
                public IntBasis BACKS_MESCRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    BACKS-DIACRE       PIC  9(002).*/
                public IntBasis BACKS_DIACRE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      BACKS-CODBARRA.*/
            }
            public EM8006B_BACKS_CODBARRA BACKS_CODBARRA { get; set; } = new EM8006B_BACKS_CODBARRA();
            public class EM8006B_BACKS_CODBARRA : VarBasis
            {
                /*"    10    BACKS-COD-BANCO    PIC  9(003).*/
                public IntBasis BACKS_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10    BACKS-AGENCIA-DEB  PIC  9(004).*/
                public IntBasis BACKS_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-OPERACAO-DEB PIC  9(004).*/
                public IntBasis BACKS_OPERACAO_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-NUMCTA-DEB   PIC  9(012).*/
                public IntBasis BACKS_NUMCTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    BACKS-DIGCTA-DEB   PIC  X(001).*/
                public StringBasis BACKS_DIGCTA_DEB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    FILLER             PIC  X(001).*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    BACKS-NUM-PROPOSTA PIC  9(013).*/
                public IntBasis BACKS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    BACKS-NUM-PARCELA  PIC  9(004).*/
                public IntBasis BACKS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    BACKS-BARRA3       PIC  X(004).*/
                public StringBasis BACKS_BARRA3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      BACKS-VLRPAGO      PIC  9(010)V99.*/
            }
            public DoubleBasis BACKS_VLRPAGO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
            /*"  05      BACKS-VLRTARIFA    PIC  9(005)V99.*/
            public DoubleBasis BACKS_VLRTARIFA { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V99."), 2);
            /*"  05      BACKS-NRSEQREG     PIC  9(008).*/
            public IntBasis BACKS_NRSEQREG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      BACKS-AGENCIA-ARREC PIC X(008).*/
            public StringBasis BACKS_AGENCIA_ARREC { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05      BACKS-FORMA-ARREC  PIC  X(001).*/
            public StringBasis BACKS_FORMA_ARREC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      BACKS-NUM-AUTENTIC.*/
            public EM8006B_BACKS_NUM_AUTENTIC BACKS_NUM_AUTENTIC { get; set; } = new EM8006B_BACKS_NUM_AUTENTIC();
            public class EM8006B_BACKS_NUM_AUTENTIC : VarBasis
            {
                /*"    10    BACKS-NUM-CARTAO   PIC  9(016).*/
                public IntBasis BACKS_NUM_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                /*"    10    BACKS-COD-RETORNO  PIC  9(002).*/
                public IntBasis BACKS_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    BACKS-RESERVADO    PIC  9(005).*/
                public IntBasis BACKS_RESERVADO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05      BACKS-FORMAPAG     PIC  9(001).*/
            }
            public IntBasis BACKS_FORMAPAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      FILLER             PIC  X(007).*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"01       CIELO-17.*/
        }
        public EM8006B_CIELO_17 CIELO_17 { get; set; } = new EM8006B_CIELO_17();
        public class EM8006B_CIELO_17 : VarBasis
        {
            /*"  05      DET17-TP-REGISTRO             PIC  9(002).*/
            public IntBasis DET17_TP_REGISTRO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      DET17-TP-MOVIMENTO            PIC  X(002).*/
            public StringBasis DET17_TP_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      DET17-IDLG                    PIC  X(040).*/
            public StringBasis DET17_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      DET17-STA-COMPENSACAO         PIC  X(001).*/
            public StringBasis DET17_STA_COMPENSACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      DET17-MOTIVO-COMPENSACAO      PIC  9(002).*/
            public IntBasis DET17_MOTIVO_COMPENSACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      DET17-NSA-SAP                 PIC  9(009).*/
            public IntBasis DET17_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      DET17-NUM-FATURA              PIC  X(012).*/
            public StringBasis DET17_NUM_FATURA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"  05      DET17-NUM-ITEM-FATURA         PIC  9(004).*/
            public IntBasis DET17_NUM_ITEM_FATURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DET17-NSA-BANCO               PIC  9(006).*/
            public IntBasis DET17_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      DET17-DTA-MOV                 PIC  9(008).*/
            public IntBasis DET17_DTA_MOV { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-NUM-PROPOSTA            PIC  9(016).*/
            public IntBasis DET17_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      DET17-NUM-COM-CIELO           PIC  9(010).*/
            public IntBasis DET17_NUM_COM_CIELO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05      DET17-COD-BCO-CRED            PIC  9(003).*/
            public IntBasis DET17_COD_BCO_CRED { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      DET17-COD-AGE-CRED            PIC  9(005).*/
            public IntBasis DET17_COD_AGE_CRED { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      DET17-NUM-CTA-CRED            PIC  9(012).*/
            public IntBasis DET17_NUM_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05      DET17-DIG-CTA-CRED            PIC  9(001).*/
            public IntBasis DET17_DIG_CTA_CRED { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      DET17-COD-CART-BANDEIRA       PIC  9(004).*/
            public IntBasis DET17_COD_CART_BANDEIRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DET17-NUM-CARTAO              PIC  X(025).*/
            public StringBasis DET17_NUM_CARTAO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      DET17-COD-TOKEN-CARTAO        PIC  X(040).*/
            public StringBasis DET17_COD_TOKEN_CARTAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      DET17-STA-CART-PADRAO-SAP     PIC  X(001).*/
            public StringBasis DET17_STA_CART_PADRAO_SAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      DET17-COD-TID-CIELO           PIC  X(020).*/
            public StringBasis DET17_COD_TID_CIELO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      DET17-VLR-COBRANCA            PIC  9(013)V99.*/
            public DoubleBasis DET17_VLR_COBRANCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DET17-VLR-LIQUIDO             PIC  9(013)V99.*/
            public DoubleBasis DET17_VLR_LIQUIDO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DET17-VLR-TAX-ADM             PIC  9(013)V99.*/
            public DoubleBasis DET17_VLR_TAX_ADM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DET17-DTA-VENCIMENTO          PIC  9(008).*/
            public IntBasis DET17_DTA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-DTA-CREDITO             PIC  9(008).*/
            public IntBasis DET17_DTA_CREDITO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-DTA-DEB-TARIFA-ADM      PIC  9(008).*/
            public IntBasis DET17_DTA_DEB_TARIFA_ADM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-DTA-AJU-CAPTURA         PIC  9(008).*/
            public IntBasis DET17_DTA_AJU_CAPTURA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      DET17-COD-MOVIMENTO           PIC  X(002).*/
            public StringBasis DET17_COD_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      DET17-COD-RETORNO             PIC  X(003).*/
            public StringBasis DET17_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      DET17-PROC-ADVERT             PIC  X(002).*/
            public StringBasis DET17_PROC_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      DET17-NIVE-ADVERT             PIC  X(002).*/
            public StringBasis DET17_NIVE_ADVERT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      FILLER                        PIC  X(041).*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)."), @"");
            /*"01        HEADER-REGISTRO.*/
        }
        public EM8006B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8006B_HEADER_REGISTRO();
        public class EM8006B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  9(010).*/
            public IntBasis HEADER_CODCONVENIO { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05      FILLER              PIC  X(010).*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public EM8006B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new EM8006B_HEADER_DATGERACAO();
            public class EM8006B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO          PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES          PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA          PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSA          PIC  9(006).*/
            }
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      FILLER              PIC  X(069).*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "69", "X(069)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8006B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8006B_TRAILL_REGISTRO();
        public class EM8006B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTPAG    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTPAG { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER              PIC  X(126).*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "126", "X(126)."), @"");
            /*"01        FILLER.*/
        }
        public EM8006B_FILLER_101 FILLER_101 { get; set; } = new EM8006B_FILLER_101();
        public class EM8006B_FILLER_101 : VarBasis
        {
            /*"  05 WS-NUM-APOLICE           PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis WS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"  05 WS-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
            public DoubleBasis WS_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"  05 WS-NUM-PARCELA           PIC S9(4) USAGE COMP.*/
            public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05 WS-NUM-TITULO            PIC S9(13)V USAGE COMP-3.*/
            public DoubleBasis WS_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
            /*"  05 WS-COD-PRODUTO           PIC S9(4) USAGE COMP.*/
            public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"  05 WS-COD-CLIENTE           PIC S9(9) USAGE COMP.*/
            public IntBasis WS_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
            /*"01  LK-IDLG-REGISTRO-SINISTRO.*/
        }
        public EM8006B_LK_IDLG_REGISTRO_SINISTRO LK_IDLG_REGISTRO_SINISTRO { get; set; } = new EM8006B_LK_IDLG_REGISTRO_SINISTRO();
        public class EM8006B_LK_IDLG_REGISTRO_SINISTRO : VarBasis
        {
            /*"  03   LK-IDLG-DADOS-ENTRADA.*/
            public EM8006B_LK_IDLG_DADOS_ENTRADA LK_IDLG_DADOS_ENTRADA { get; set; } = new EM8006B_LK_IDLG_DADOS_ENTRADA();
            public class EM8006B_LK_IDLG_DADOS_ENTRADA : VarBasis
            {
                /*"    05 LK-IDLG-CODIGO-SINISTRO          PIC X(40).*/
                public StringBasis LK_IDLG_CODIGO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05 LK-IDLG-SIAS-SINI      REDEFINES  LK-IDLG-CODIGO-SINISTRO*/
                private _REDEF_EM8006B_LK_IDLG_SIAS_SINI _lk_idlg_sias_sini { get; set; }
                public _REDEF_EM8006B_LK_IDLG_SIAS_SINI LK_IDLG_SIAS_SINI
                {
                    get { _lk_idlg_sias_sini = new _REDEF_EM8006B_LK_IDLG_SIAS_SINI(); _.Move(LK_IDLG_CODIGO_SINISTRO, _lk_idlg_sias_sini); VarBasis.RedefinePassValue(LK_IDLG_CODIGO_SINISTRO, _lk_idlg_sias_sini, LK_IDLG_CODIGO_SINISTRO); _lk_idlg_sias_sini.ValueChanged += () => { _.Move(_lk_idlg_sias_sini, LK_IDLG_CODIGO_SINISTRO); }; return _lk_idlg_sias_sini; }
                    set { VarBasis.RedefinePassValue(value, _lk_idlg_sias_sini, LK_IDLG_CODIGO_SINISTRO); }
                }  //Redefines
                public class _REDEF_EM8006B_LK_IDLG_SIAS_SINI : VarBasis
                {
                    /*"       10 LK-IDLG-SINISTRO              PIC X(01).*/
                    public StringBasis LK_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-NUM-APOL-SINISTRO     PIC 9(13).*/
                    public IntBasis LK_IDLG_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"       10 LK-IDLG-FILLER-1              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-OCORR-HISTORICO       PIC 9(05).*/
                    public IntBasis LK_IDLG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       10 LK-IDLG-FILLER-2              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-COD-OPERACAO          PIC 9(04).*/
                    public IntBasis LK_IDLG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"       10 LK-IDLG-FILLER-3              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-TIPO-MOVIMENTO        PIC X(01).*/
                    public StringBasis LK_IDLG_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FILLER-4              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FORMA-PAGAMENTO       PIC X(01).*/
                    public StringBasis LK_IDLG_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FILLER-5              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-COMPLEMENTO           PIC X(10).*/
                    public StringBasis LK_IDLG_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       10 LK-IDLG-COMPLEMENTO-1  REDEFINES  LK-IDLG-COMPLEMENTO.*/
                    private _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_1 _lk_idlg_complemento_1 { get; set; }
                    public _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_1 LK_IDLG_COMPLEMENTO_1
                    {
                        get { _lk_idlg_complemento_1 = new _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_1(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_1); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_1.ValueChanged += () => { _.Move(_lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_1; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_1 : VarBasis
                    {
                        /*"          15 LK-IDLG-NUM-CHEQUE-INTERNO PIC 9(10).*/
                        public IntBasis LK_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                        /*"       10 LK-IDLG-COMPLEMENTO-2  REDEFINES  LK-IDLG-COMPLEMENTO.*/

                        public _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_1()
                        {
                            LK_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_2 _lk_idlg_complemento_2 { get; set; }
                    public _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_2 LK_IDLG_COMPLEMENTO_2
                    {
                        get { _lk_idlg_complemento_2 = new _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_2(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_2); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_2.ValueChanged += () => { _.Move(_lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_2; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_2 : VarBasis
                    {
                        /*"          15 LK-IDLG-NSAS               PIC 9(10).*/
                        public IntBasis LK_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                        /*"       10 LK-IDLG-COMPLEMENTO-3  REDEFINES  LK-IDLG-COMPLEMENTO.*/

                        public _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_2()
                        {
                            LK_IDLG_NSAS.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_3 _lk_idlg_complemento_3 { get; set; }
                    public _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_3 LK_IDLG_COMPLEMENTO_3
                    {
                        get { _lk_idlg_complemento_3 = new _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_3(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_3); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_3.ValueChanged += () => { _.Move(_lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_3; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_3 : VarBasis
                    {
                        /*"          15 LK-IDLG-NUM-ACORDO         PIC 9(05).*/
                        public IntBasis LK_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                        /*"          15 FILLER                     PIC X(01).*/
                        public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                        /*"          15 LK-IDLG-NUM-PARCELA        PIC 9(04).*/
                        public IntBasis LK_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                        /*"  03   LK-IDLG-DADOS-RETORNO.*/

                        public _REDEF_EM8006B_LK_IDLG_COMPLEMENTO_3()
                        {
                            LK_IDLG_NUM_ACORDO.ValueChanged += OnValueChanged;
                            FILLER_102.ValueChanged += OnValueChanged;
                            LK_IDLG_NUM_PARCELA.ValueChanged += OnValueChanged;
                        }

                    }

                    public _REDEF_EM8006B_LK_IDLG_SIAS_SINI()
                    {
                        LK_IDLG_SINISTRO.ValueChanged += OnValueChanged;
                        LK_IDLG_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_1.ValueChanged += OnValueChanged;
                        LK_IDLG_OCORR_HISTORICO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_2.ValueChanged += OnValueChanged;
                        LK_IDLG_COD_OPERACAO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_3.ValueChanged += OnValueChanged;
                        LK_IDLG_TIPO_MOVIMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_4.ValueChanged += OnValueChanged;
                        LK_IDLG_FORMA_PAGAMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_5.ValueChanged += OnValueChanged;
                        LK_IDLG_COMPLEMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_COMPLEMENTO_1.ValueChanged += OnValueChanged;
                    }

                }
            }
            public EM8006B_LK_IDLG_DADOS_RETORNO LK_IDLG_DADOS_RETORNO { get; set; } = new EM8006B_LK_IDLG_DADOS_RETORNO();
            public class EM8006B_LK_IDLG_DADOS_RETORNO : VarBasis
            {
                /*"    05 LK-IDLG-RET-EH-SINISTRO       PIC  X(03).*/
                public StringBasis LK_IDLG_RET_EH_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"    05 LK-IDLG-RET-NUM-APOL-SINISTRO PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-OCORR-HISTORICO   PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-COD-OPERACAO      PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-COD-PAGA-RECEBE   PIC  9(02).*/
                public IntBasis LK_IDLG_RET_COD_PAGA_RECEBE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05 LK-IDLG-RET-COD-PAGA-TEXTO    PIC  X(50).*/
                public StringBasis LK_IDLG_RET_COD_PAGA_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LK-IDLG-RET-COD-FINANC        PIC  9(02).*/
                public IntBasis LK_IDLG_RET_COD_FINANC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05 LK-IDLG-RET-COD-FINANC-TEXTO  PIC  X(50).*/
                public StringBasis LK_IDLG_RET_COD_FINANC_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LK-IDLG-RET-LAYOUT            PIC  9(02).*/
                public IntBasis LK_IDLG_RET_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05 LK-IDLG-RET-LAYOUT-TEXTO      PIC  X(50).*/
                public StringBasis LK_IDLG_RET_LAYOUT_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"    05 LK-IDLG-RET-NUM-OCORR-MOVTO   PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-IDE-SISTEMA       PIC  X(02).*/
                public StringBasis LK_IDLG_RET_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05 LK-IDLG-RET-MOVDEB-NUM-APOLICE                                     PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_MOVDEB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-MOVDEB-NUM-ENDOSSO                                     PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-MOVDEB-PARCELA                                     PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-MOVDEB-CONVENIO                                     PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-MOVDEB-NSAS-ENVIO                                     PIC S9(04) COMP  .*/
                public IntBasis LK_IDLG_RET_MOVDEB_NSAS_ENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                /*"    05 LK-IDLG-RET-MOVDEB-NUM-REQUISI                                     PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_MOVDEB_NUM_REQUISI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-CHQ-CHQINT                                     PIC S9(13) COMP-3.*/
                public IntBasis LK_IDLG_RET_CHQ_CHQINT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                /*"    05 LK-IDLG-RET-RESSARC-NUM-ACORDO                                     PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_RESSARC_NUM_ACORDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-RESSARC-PARCELA                                     PIC S9(09) COMP  .*/
                public IntBasis LK_IDLG_RET_RESSARC_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                /*"    05 LK-IDLG-RET-CODIGO-RETORNO    PIC X(01)        .*/
                public StringBasis LK_IDLG_RET_CODIGO_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"    05 LK-IDLG-RET-MENSAGEM          PIC X(80)        .*/
                public StringBasis LK_IDLG_RET_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                /*"01  REGISTRO-LINKAGE-GE0302B.*/
            }
        }
        public EM8006B_REGISTRO_LINKAGE_GE0302B REGISTRO_LINKAGE_GE0302B { get; set; } = new EM8006B_REGISTRO_LINKAGE_GE0302B();
        public class EM8006B_REGISTRO_LINKAGE_GE0302B : VarBasis
        {
            /*"    05 LK-GE0302B-IDLG                    PIC  X(40).*/
            public StringBasis LK_GE0302B_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0302B-ACHOU-USO-EMPRESA       PIC  X(03).*/
            public StringBasis LK_GE0302B_ACHOU_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-GE0302B-EH-SINISTRO             PIC  X(03).*/
            public StringBasis LK_GE0302B_EH_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-GE0302B-CHR-USO-EMPRESA         PIC  X(200).*/
            public StringBasis LK_GE0302B_CHR_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"    05 LK-GE0302B-SICOV-IDENT-CLIENTE     PIC  X(25).*/
            public StringBasis LK_GE0302B_SICOV_IDENT_CLIENTE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05 LK-GE0302B-SICOV-USO-EMPRESA       PIC  X(60).*/
            public StringBasis LK_GE0302B_SICOV_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"    05 LK-GE0302B-SIACC                   PIC  X(40).*/
            public StringBasis LK_GE0302B_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0302B-COD-RETORNO             PIC  X(01).*/
            public StringBasis LK_GE0302B_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-GE0302B-MENSAGEM.*/
            public EM8006B_LK_GE0302B_MENSAGEM LK_GE0302B_MENSAGEM { get; set; } = new EM8006B_LK_GE0302B_MENSAGEM();
            public class EM8006B_LK_GE0302B_MENSAGEM : VarBasis
            {
                /*"       10 LK-GE0302B-SQLCODE              PIC   -ZZ9.*/
                public IntBasis LK_GE0302B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-GE0302B-MENSAGEM-RETORNO     PIC  X(75).*/
                public StringBasis LK_GE0302B_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Copies.LBGE0350 LBGE0350 { get; set; } = new Copies.LBGE0350();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.GE100 GE100 { get; set; } = new Dclgens.GE100();
        public Dclgens.GE094 GE094 { get; set; } = new Dclgens.GE094();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.EF150 EF150 { get; set; } = new Dclgens.EF150();
        public Dclgens.GE403 GE403 { get; set; } = new Dclgens.GE403();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVARQH_FILE_NAME_P, string SAIDA1_FILE_NAME_P, string SAIDA2_FILE_NAME_P, string SAIDA3_FILE_NAME_P, string SAIDA4_FILE_NAME_P, string SAIDA5_FILE_NAME_P, string SAIDA6_FILE_NAME_P, string SAIDA7_FILE_NAME_P, string SAIDA9_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVARQH.SetFile(MOVARQH_FILE_NAME_P);
                SAIDA1.SetFile(SAIDA1_FILE_NAME_P);
                SAIDA2.SetFile(SAIDA2_FILE_NAME_P);
                SAIDA3.SetFile(SAIDA3_FILE_NAME_P);
                SAIDA4.SetFile(SAIDA4_FILE_NAME_P);
                SAIDA5.SetFile(SAIDA5_FILE_NAME_P);
                SAIDA6.SetFile(SAIDA6_FILE_NAME_P);
                SAIDA7.SetFile(SAIDA7_FILE_NAME_P);
                SAIDA9.SetFile(SAIDA9_FILE_NAME_P);

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
            /*" -2398- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2398- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2400- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2402- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -2405- DISPLAY '---------------------------------------------------' */
            _.Display($"---------------------------------------------------");

            /*" -2406- DISPLAY '       EM8006B - PROCESSA ARQUIVO <ARQ_H>          ' */
            _.Display($"       EM8006B - PROCESSA ARQUIVO <ARQ_H>          ");

            /*" -2407- DISPLAY '                                                   ' */
            _.Display($"                                                   ");

            /*" -2412- DISPLAY 'VERSAO V.59: ' FUNCTION WHEN-COMPILED ' - DEMANDA 582106 - 12/08/2024.' */

            $"VERSAO V.59: FUNCTION{_.WhenCompiled()} - DEMANDA 582106 - 12/08/2024."
            .Display();

            /*" -2413- DISPLAY ' ' */
            _.Display($" ");

            /*" -2420- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -2421- DISPLAY '   ' */
            _.Display($"   ");

            /*" -2423- DISPLAY '------------------------------------------------' */
            _.Display($"------------------------------------------------");

            /*" -2425- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -2428- PERFORM R0400-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0400_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -2428- PERFORM R2560-00-TRAILL-BACKSEG. */

            R2560_00_TRAILL_BACKSEG_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -2434- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2450- CLOSE MOVARQH SAIDA1 SAIDA2 SAIDA3 SAIDA4 SAIDA5 SAIDA6 SAIDA7 SAIDA9 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15 SAIDA16 SAIDA17 SAIDA18 SAIDA19. */
            MOVARQH.Close();
            SAIDA1.Close();
            SAIDA2.Close();
            SAIDA3.Close();
            SAIDA4.Close();
            SAIDA5.Close();
            SAIDA6.Close();
            SAIDA7.Close();
            SAIDA9.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();
            SAIDA16.Close();
            SAIDA17.Close();
            SAIDA18.Close();
            SAIDA19.Close();

            /*" -2452- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -2453- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2454- DISPLAY '                 E M 8 0 0 6 B  ' */
            _.Display($"                 E M 8 0 0 6 B  ");

            /*" -2455- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2456- DISPLAY 'LIDOS HEADER ............ ' TT-HEADER */
            _.Display($"LIDOS HEADER ............ {W.TT_HEADER}");

            /*" -2457- DISPLAY 'LIDOS TRAILLER .......... ' TT-TRAILLER */
            _.Display($"LIDOS TRAILLER .......... {W.TT_TRAILLER}");

            /*" -2458- DISPLAY 'LIDOS DESP01 ............ ' TT-DESP01 */
            _.Display($"LIDOS DESP01 ............ {W.TT_DESP01}");

            /*" -2459- DISPLAY 'LIDOS DESP02 ............ ' TT-DESP02 */
            _.Display($"LIDOS DESP02 ............ {W.TT_DESP02}");

            /*" -2460- DISPLAY 'LIDOS DESP16 ............ ' TT-DESP16 */
            _.Display($"LIDOS DESP16 ............ {W.TT_DESP16}");

            /*" -2461- DISPLAY 'LIDOS DETALHE ........... ' LD-MOVIMENTO */
            _.Display($"LIDOS DETALHE ........... {W.LD_MOVIMENTO}");

            /*" -2462- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2463- DISPLAY 'DESPREZA MOVIMENTO MCP .. ' DP-MOVTOMCP */
            _.Display($"DESPREZA MOVIMENTO MCP .. {W.DP_MOVTOMCP}");

            /*" -2464- DISPLAY 'DESPREZA MOVIMENTO MCPCVP ' DP-MOVTOMCPCVP */
            _.Display($"DESPREZA MOVIMENTO MCPCVP {W.DP_MOVTOMCPCVP}");

            /*" -2465- DISPLAY 'DESPREZA DETALHE ........ ' DP-MOVIMENTO */
            _.Display($"DESPREZA DETALHE ........ {W.DP_MOVIMENTO}");

            /*" -2466- DISPLAY 'DESPREZA TIPOREG ........ ' DP-TIPOREG */
            _.Display($"DESPREZA TIPOREG ........ {W.DP_TIPOREG}");

            /*" -2467- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2468- DISPLAY 'TRATA SICOV VIDA ........ ' TT-VIDA */
            _.Display($"TRATA SICOV VIDA ........ {W.TT_VIDA}");

            /*" -2469- DISPLAY 'TRATA CONVENIO 001313 ... ' TT-CONV1313 */
            _.Display($"TRATA CONVENIO 001313 ... {W.TT_CONV1313}");

            /*" -2470- DISPLAY 'TRATA SICOV LOTERICO .... ' TT-LOTERICO */
            _.Display($"TRATA SICOV LOTERICO .... {W.TT_LOTERICO}");

            /*" -2471- DISPLAY 'TRATA SICOV BILHETE ..... ' TT-BILHETE */
            _.Display($"TRATA SICOV BILHETE ..... {W.TT_BILHETE}");

            /*" -2472- DISPLAY 'TRATA SICOV AUTO/RD ..... ' TT-AUTO */
            _.Display($"TRATA SICOV AUTO/RD ..... {W.TT_AUTO}");

            /*" -2473- DISPLAY 'TRATA SICOV RED CHQ ..... ' TT-REDCHQ */
            _.Display($"TRATA SICOV RED CHQ ..... {W.TT_REDCHQ}");

            /*" -2474- DISPLAY 'TRATA SICAP ............. ' TT-SICAP */
            _.Display($"TRATA SICAP ............. {W.TT_SICAP}");

            /*" -2475- DISPLAY 'TRATA SICOB ............. ' TT-SICOB */
            _.Display($"TRATA SICOB ............. {W.TT_SICOB}");

            /*" -2476- DISPLAY 'TRATA SIGPF ............. ' TT-SIGPF */
            _.Display($"TRATA SIGPF ............. {W.TT_SIGPF}");

            /*" -2477- DISPLAY 'TRATA CARTAO CREDITO .... ' TT-CARTAO */
            _.Display($"TRATA CARTAO CREDITO .... {W.TT_CARTAO}");

            /*" -2478- DISPLAY 'TRATA SIACC ............. ' TT-SIACC */
            _.Display($"TRATA SIACC ............. {W.TT_SIACC}");

            /*" -2479- DISPLAY 'TRATA CHEQUE ............ ' TT-CHEQUE */
            _.Display($"TRATA CHEQUE ............ {W.TT_CHEQUE}");

            /*" -2480- DISPLAY 'TRATA BANCOOB ........... ' TT-BANCOOB */
            _.Display($"TRATA BANCOOB ........... {W.TT_BANCOOB}");

            /*" -2481- DISPLAY 'TRATA DET11 ............. ' TT-DET11 */
            _.Display($"TRATA DET11 ............. {W.TT_DET11}");

            /*" -2482- DISPLAY 'DESPREZA DET11 .......... ' DP-DET11 */
            _.Display($"DESPREZA DET11 .......... {W.DP_DET11}");

            /*" -2483- DISPLAY 'TRATA DET14 ............. ' TT-DET14 */
            _.Display($"TRATA DET14 ............. {W.TT_DET14}");

            /*" -2484- DISPLAY 'DESPREZA DET14 .......... ' DP-DET14 */
            _.Display($"DESPREZA DET14 .......... {W.DP_DET14}");

            /*" -2485- DISPLAY 'TRATA DET12 ............. ' TT-DET12 */
            _.Display($"TRATA DET12 ............. {W.TT_DET12}");

            /*" -2486- DISPLAY 'DESPREZA DET12 .......... ' DP-DET12 */
            _.Display($"DESPREZA DET12 .......... {W.DP_DET12}");

            /*" -2487- DISPLAY 'TRATA DET13 ............. ' TT-DET13 */
            _.Display($"TRATA DET13 ............. {W.TT_DET13}");

            /*" -2488- DISPLAY 'DESPREZA DET13 .......... ' DP-DET13 */
            _.Display($"DESPREZA DET13 .......... {W.DP_DET13}");

            /*" -2489- DISPLAY 'DET13 CNTRLE NN SAP...... ' TT-DET13-CNTRLE */
            _.Display($"DET13 CNTRLE NN SAP...... {W.TT_DET13_CNTRLE}");

            /*" -2490- DISPLAY 'TRATA DET15 (CESTA SERV). ' TT-DET15 */
            _.Display($"TRATA DET15 (CESTA SERV). {W.TT_DET15}");

            /*" -2491- DISPLAY 'QTD DE TROCA DO ZA PARA AN = ' WS-QTD-DISPLAY */
            _.Display($"QTD DE TROCA DO ZA PARA AN = {WS_QTD_DISPLAY}");

            /*" -2492- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2493- DISPLAY ' ' */
            _.Display($" ");

            /*" -2494- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2495- DISPLAY 'TRATA SINISTRO .......... ' TT-SINISTRO */
            _.Display($"TRATA SINISTRO .......... {W.TT_SINISTRO}");

            /*" -2496- DISPLAY 'TEM SINISTRO ............ ' TE-SINISTRO */
            _.Display($"TEM SINISTRO ............ {W.TE_SINISTRO}");

            /*" -2497- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2498- DISPLAY ' ' */
            _.Display($" ");

            /*" -2499- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2500- DISPLAY 'REGISTROS GRAV SICOV..... ' AC-GRAV-SAIDA1 */
            _.Display($"REGISTROS GRAV SICOV..... {W.AC_GRAV_SAIDA1}");

            /*" -2501- DISPLAY ' ' */
            _.Display($" ");

            /*" -2502- DISPLAY 'REGISTROS GRAV SICAP..... ' AC-GRAV-SAIDA2 */
            _.Display($"REGISTROS GRAV SICAP..... {W.AC_GRAV_SAIDA2}");

            /*" -2503- DISPLAY ' ' */
            _.Display($" ");

            /*" -2504- DISPLAY 'REGISTROS GRAV SICOB..... ' AC-GRAV-SAIDA3 */
            _.Display($"REGISTROS GRAV SICOB..... {W.AC_GRAV_SAIDA3}");

            /*" -2505- DISPLAY ' ' */
            _.Display($" ");

            /*" -2506- DISPLAY 'REGISTROS GRAV SIGPF..... ' AC-GRAV-SAIDA4 */
            _.Display($"REGISTROS GRAV SIGPF..... {W.AC_GRAV_SAIDA4}");

            /*" -2507- DISPLAY ' ' */
            _.Display($" ");

            /*" -2508- DISPLAY 'REGISTROS GRAV CARTAO.... ' AC-GRAV-SAIDA5 */
            _.Display($"REGISTROS GRAV CARTAO.... {W.AC_GRAV_SAIDA5}");

            /*" -2509- DISPLAY ' ' */
            _.Display($" ");

            /*" -2510- DISPLAY 'REGISTROS GRAV CHEQUE.... ' AC-GRAV-SAIDA6 */
            _.Display($"REGISTROS GRAV CHEQUE.... {W.AC_GRAV_SAIDA6}");

            /*" -2511- DISPLAY ' ' */
            _.Display($" ");

            /*" -2512- DISPLAY 'REGISTROS GRAV SIACC..... ' AC-GRAV-SAIDA7 */
            _.Display($"REGISTROS GRAV SIACC..... {W.AC_GRAV_SAIDA7}");

            /*" -2513- DISPLAY ' ' */
            _.Display($" ");

            /*" -2514- DISPLAY 'REGISTROS GRAV BANCOOB... ' AC-GRAV-SAIDA9 */
            _.Display($"REGISTROS GRAV BANCOOB... {W.AC_GRAV_SAIDA9}");

            /*" -2515- DISPLAY ' ' */
            _.Display($" ");

            /*" -2516- DISPLAY 'REGISTROS GRAV PARCEIROS. ' AC-GRAV-SAIDA11 */
            _.Display($"REGISTROS GRAV PARCEIROS. {W.AC_GRAV_SAIDA11}");

            /*" -2517- DISPLAY ' ' */
            _.Display($" ");

            /*" -2518- DISPLAY 'REGISTROS DEB OUTROS BCO. ' AC-GRAV-SAIDA14 */
            _.Display($"REGISTROS DEB OUTROS BCO. {W.AC_GRAV_SAIDA14}");

            /*" -2519- DISPLAY ' ' */
            _.Display($" ");

            /*" -2520- DISPLAY 'REGISTROS GRAV SICOV P... ' AC-GRAV-SAIDA12 */
            _.Display($"REGISTROS GRAV SICOV P... {W.AC_GRAV_SAIDA12}");

            /*" -2521- DISPLAY ' ' */
            _.Display($" ");

            /*" -2522- DISPLAY 'REGISTROS GRAV EXPURGO... ' AC-GRAV-SAIDA13 */
            _.Display($"REGISTROS GRAV EXPURGO... {W.AC_GRAV_SAIDA13}");

            /*" -2523- DISPLAY ' ' */
            _.Display($" ");

            /*" -2524- DISPLAY 'REGISTROS GRAV SIGCB..... ' AC-GRAV-SAIDA15 */
            _.Display($"REGISTROS GRAV SIGCB..... {W.AC_GRAV_SAIDA15}");

            /*" -2525- DISPLAY ' ' */
            _.Display($" ");

            /*" -2526- DISPLAY 'REGISTROS GRAV CESTA SERV.' AC-GRAV-SAIDA16 */
            _.Display($"REGISTROS GRAV CESTA SERV.{W.AC_GRAV_SAIDA16}");

            /*" -2527- DISPLAY ' ' */
            _.Display($" ");

            /*" -2528- DISPLAY 'REGISTROS GRAV CIELO......' AC-GRAV-SAIDA17 */
            _.Display($"REGISTROS GRAV CIELO......{W.AC_GRAV_SAIDA17}");

            /*" -2529- DISPLAY ' ' */
            _.Display($" ");

            /*" -2530- DISPLAY 'REGISTROS GRAV MOVTO MCP..' AC-GRAV-SAIDA18 */
            _.Display($"REGISTROS GRAV MOVTO MCP..{W.AC_GRAV_SAIDA18}");

            /*" -2531- DISPLAY ' ' */
            _.Display($" ");

            /*" -2532- DISPLAY 'REG. GRAV MOVTO MCP CVP...' AC-GRAV-SAIDA19 */
            _.Display($"REG. GRAV MOVTO MCP CVP...{W.AC_GRAV_SAIDA19}");

            /*" -2533- DISPLAY ' ' */
            _.Display($" ");

            /*" -2534- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2535- DISPLAY '            EM8006B - FIM NORMAL' . */
            _.Display($"            EM8006B - FIM NORMAL");

            /*" -2537- DISPLAY '--------------------------------------------- ' */
            _.Display($"--------------------------------------------- ");

            /*" -2537- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -2548- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2550- OPEN INPUT MOVARQH. */
            MOVARQH.Open(REG_ARQH);

            /*" -2568- OPEN OUTPUT SAIDA1 SAIDA2 SAIDA3 SAIDA4 SAIDA5 SAIDA6 SAIDA7 SAIDA9 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15 SAIDA16 SAIDA17 SAIDA18 SAIDA19. */
            SAIDA1.Open(REG_SAIDA1);
            SAIDA2.Open(REG_SAIDA2);
            SAIDA3.Open(REG_SAIDA3);
            SAIDA4.Open(REG_SAIDA4);
            SAIDA5.Open(REG_SAIDA5);
            SAIDA6.Open(REG_SAIDA6);
            SAIDA7.Open(REG_SAIDA7);
            SAIDA9.Open(REG_SAIDA9);
            SAIDA11.Open(REG_SAIDA11);
            SAIDA12.Open(REG_SAIDA12);
            SAIDA13.Open(REG_SAIDA13);
            SAIDA14.Open(REG_SAIDA14);
            SAIDA15.Open(REG_SAIDA15);
            SAIDA16.Open(REG_SAIDA16);
            SAIDA17.Open(REG_SAIDA17);
            SAIDA18.Open(REG_SAIDA18);
            SAIDA19.Open(REG_SAIDA19);

            /*" -2570- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -2572- PERFORM R0130-00-SELECT-CONGENERE. */

            R0130_00_SELECT_CONGENERE_SECTION();

            /*" -2574- PERFORM R2550-00-HEADER-BACKSEG. */

            R2550_00_HEADER_BACKSEG_SECTION();

            /*" -2575- MOVE 'S' TO WS-TRATA. */
            _.Move("S", W.WS_TRATA);

            /*" -2577- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -2579- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -2580- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -2581- PERFORM R2560-00-TRAILL-BACKSEG */

                R2560_00_TRAILL_BACKSEG_SECTION();

                /*" -2581- GO TO R9990-00-SEM-MOVIMENTO. */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -2592- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2598- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -2601- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2603- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' ' SQLCODE ' SQLCODE */

                $"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS) SQLCODE {DB.SQLCODE}"
                .Display();

                /*" -2607- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2609- DISPLAY 'DATA DO MOVIMENTO: ' WHOST-DATA-EM */
            _.Display($"DATA DO MOVIMENTO: {WHOST_DATA_EM}");

            /*" -2609- MOVE WHOST-DATA-EM TO WDATA-REL. */
            _.Move(WHOST_DATA_EM, WDATA_REL);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -2598- EXEC SQL SELECT DATA_MOV_ABERTO INTO :WHOST-DATA-EM FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FA' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DATA_EM, WHOST_DATA_EM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-SELECT-CONGENERE-SECTION */
        private void R0130_00_SELECT_CONGENERE_SECTION()
        {
            /*" -2636- MOVE 'R0130' TO WNR-EXEC-SQL. */
            _.Move("R0130", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2637- MOVE 1015 TO WS-COD-CONGENERE */
            _.Move(1015, WS_COD_CONGENERE);

            /*" -2638- DISPLAY 'R0130-00-COD-CONGENERE:' WS-COD-CONGENERE */
            _.Display($"R0130-00-COD-CONGENERE:{WS_COD_CONGENERE}");

            /*" -2638- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -2648- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2649- READ MOVARQH AT END */
            try
            {
                MOVARQH.Read(() =>
                {

                    /*" -2650- MOVE 'S' TO WFIM-MOVIMENTO. */
                    _.Move("S", W.WFIM_MOVIMENTO);
                });

                _.Move(MOVARQH.Value, REG_ARQH);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0400_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -2661- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2666- MOVE REG-ARQH TO HEA-REGISTRO DET-REGISTRO TRAI-REGISTRO REG-SAIDA13. */
            _.Move(MOVARQH?.Value, HEA_REGISTRO, DET_REGISTRO, TRAI_REGISTRO, REG_SAIDA13);

            /*" -2667- IF (HEA-TIPREG EQUAL 00) */

            if ((HEA_REGISTRO.HEA_TIPREG == 00))
            {

                /*" -2668- ADD 1 TO TT-HEADER */
                W.TT_HEADER.Value = W.TT_HEADER + 1;

                /*" -2669- PERFORM R0410-00-TRATA-HEADER */

                R0410_00_TRATA_HEADER_SECTION();

                /*" -2670- GO TO R0400-90-LEITURA */

                R0400_90_LEITURA(); //GOTO
                return;

                /*" -2671- ELSE */
            }
            else
            {


                /*" -2672- IF (HEA-TIPREG EQUAL 99) */

                if ((HEA_REGISTRO.HEA_TIPREG == 99))
                {

                    /*" -2673- ADD 1 TO TT-TRAILLER */
                    W.TT_TRAILLER.Value = W.TT_TRAILLER + 1;

                    /*" -2674- GO TO R0400-90-LEITURA */

                    R0400_90_LEITURA(); //GOTO
                    return;

                    /*" -2675- END-IF */
                }


                /*" -2677- END-IF. */
            }


            /*" -2679- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

            /*" -2680- IF WS-TRATA EQUAL 'N' */

            if (W.WS_TRATA == "N")
            {

                /*" -2681- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -2682- ADD 1 TO DP-MOVIMENTO */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;

                /*" -2684- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2685- IF DET-IDLG(01:3) EQUAL "MCP" */

            if (DET_REGISTRO.DET_IDLG.Substring(01, 3) == "MCP")
            {

                /*" -2686- PERFORM R9500-00-EXPURGA-MCP THRU R9500-99-SAIDA */

                R9500_00_EXPURGA_MCP_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9500_99_SAIDA*/


                /*" -2687- ADD 1 TO DP-MOVTOMCP */
                W.DP_MOVTOMCP.Value = W.DP_MOVTOMCP + 1;

                /*" -2689- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2690- IF DET-IDLG(01:3) EQUAL "CVP" */

            if (DET_REGISTRO.DET_IDLG.Substring(01, 3) == "JVBKINCL.CVP_PRODUTO.CVPPROD")
            {

                /*" -2691- PERFORM R9600-00-EXPURGA-MCPCVP THRU R9600-99-SAIDA */

                R9600_00_EXPURGA_MCPCVP_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9600_99_SAIDA*/


                /*" -2692- ADD 1 TO DP-MOVTOMCPCVP */
                W.DP_MOVTOMCPCVP.Value = W.DP_MOVTOMCPCVP + 1;

                /*" -2694- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2696- PERFORM R0450-00-VERIFICA-DATAS. */

            R0450_00_VERIFICA_DATAS_SECTION();

            /*" -2697- IF DET1-OCORRENCIA(1:2) = 'ZA' */

            if (DET_REGISTRO.DET_REG1.DET1_OCORRENCIA.Substring(1, 2) == "ZA")
            {

                /*" -2698- MOVE 'AN' TO DET1-OCORRENCIA(1:2) */
                _.MoveAtPosition("AN", DET_REGISTRO.DET_REG1.DET1_OCORRENCIA, 1, 2);

                /*" -2699- ADD 1 TO WS-QTD-DISPLAY */
                WS_QTD_DISPLAY.Value = WS_QTD_DISPLAY + 1;

                /*" -2701- END-IF */
            }


            /*" -2702- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -2706- IF DET1-OCORRENCIA(1:2) EQUAL 'BD' OR '  ' OR 'BE' OR 'BF' */

                if (DET_REGISTRO.DET_REG1.DET1_OCORRENCIA.Substring(1, 2).In("BD", " ", "BE", "BF"))
                {

                    /*" -2707- ADD 1 TO TT-DESP01 */
                    W.TT_DESP01.Value = W.TT_DESP01 + 1;

                    /*" -2708- GO TO R0400-90-LEITURA */

                    R0400_90_LEITURA(); //GOTO
                    return;

                    /*" -2709- END-IF */
                }


                /*" -2711- END-IF. */
            }


            /*" -2712- IF DET-TIPREG EQUAL 02 */

            if (DET_REGISTRO.DET_TIPREG == 02)
            {

                /*" -2716- IF DET2-OCORRENCIA(1:2) EQUAL 'BD' OR '  ' OR 'BE' OR 'BF' */

                if (DET_REGISTRO.DET_REG2.DET2_OCORRENCIA.Substring(1, 2).In("BD", " ", "BE", "BF"))
                {

                    /*" -2717- ADD 1 TO TT-DESP02 */
                    W.TT_DESP02.Value = W.TT_DESP02 + 1;

                    /*" -2718- GO TO R0400-90-LEITURA */

                    R0400_90_LEITURA(); //GOTO
                    return;

                    /*" -2719- END-IF */
                }


                /*" -2721- END-IF. */
            }


            /*" -2722- IF DET-TIPREG EQUAL 16 */

            if (DET_REGISTRO.DET_TIPREG == 16)
            {

                /*" -2724- IF DET16-COD-RETORNO EQUAL 'BD' OR '  ' OR 'BE' OR 'BF' */

                if (DET_REGISTRO.DET_REG16.DET16_COD_RETORNO.In("BD", " ", "BE", "BF"))
                {

                    /*" -2725- ADD 1 TO TT-DESP16 */
                    W.TT_DESP16.Value = W.TT_DESP16 + 1;

                    /*" -2726- GO TO R0400-90-LEITURA */

                    R0400_90_LEITURA(); //GOTO
                    return;

                    /*" -2727- END-IF */
                }


                /*" -2729- END-IF. */
            }


            /*" -2731- MOVE SPACES TO MOVCC-REGISTRO. */
            _.Move("", MOVCC_REGISTRO);

            /*" -2734- MOVE SPACES TO REG-SAIDA1 REG-SAIDA12. */
            _.Move("", REG_SAIDA1, REG_SAIDA12);

            /*" -2736- MOVE 'SICOV     ' TO MOVCC-TIPO-ARQUIVO. */
            _.Move("SICOV     ", MOVCC_REGISTRO.MOVCC_TIPO_ARQUIVO);

            /*" -2739- MOVE SPACES TO REG-SAIDA2 REG-SAIDA11. */
            _.Move("", REG_SAIDA2, REG_SAIDA11);

            /*" -2741- MOVE 'SICAP     ' TO SICAP-TIPO-ARQUIVO. */
            _.Move("SICAP     ", MOVCC_REGISTRO.REG_SICAP.SICAP_TIPO_ARQUIVO);

            /*" -2742- MOVE SPACES TO REG-SAIDA3. */
            _.Move("", REG_SAIDA3);

            /*" -2745- MOVE 'SICOB     ' TO SICOB-TIPO-ARQUIVO. */
            _.Move("SICOB     ", REG_SICOB.SICOB_TIPO_ARQUIVO);

            /*" -2746- MOVE SPACES TO REG-SAIDA4. */
            _.Move("", REG_SAIDA4);

            /*" -2748- MOVE 'SIGPF     ' TO SIGPF-TIPO-ARQUIVO. */
            _.Move("SIGPF     ", REG_SIGPF.SIGPF_TIPO_ARQUIVO);

            /*" -2749- MOVE SPACES TO REG-SAIDA5. */
            _.Move("", REG_SAIDA5);

            /*" -2751- MOVE 'CARTAO    ' TO CARTAO-TIPO-ARQUIVO. */
            _.Move("CARTAO    ", REG_CARTAO.CARTAO_TIPO_ARQUIVO);

            /*" -2752- MOVE SPACES TO REG-SAIDA6. */
            _.Move("", REG_SAIDA6);

            /*" -2754- MOVE 'CHEQUES   ' TO CHEQUE-TIPO-ARQUIVO. */
            _.Move("CHEQUES   ", REG_CHEQUE.CHEQUE_TIPO_ARQUIVO);

            /*" -2755- MOVE SPACES TO REG-SAIDA7. */
            _.Move("", REG_SAIDA7);

            /*" -2757- MOVE 'SIACC     ' TO SIACC-TIPO-ARQUIVO. */
            _.Move("SIACC     ", REG_SIACC.SIACC_TIPO_ARQUIVO);

            /*" -2758- MOVE SPACES TO REG-SAIDA9. */
            _.Move("", REG_SAIDA9);

            /*" -2760- MOVE 'BANCOOB   ' TO BANCOOB-TIPO-ARQUIVO. */
            _.Move("BANCOOB   ", REG_BANCOOB.BANCOOB_TIPO_ARQUIVO);

            /*" -2769- MOVE DET-IDLG TO WS-IDLG-VIDA WS-IDLG-BILHETE WS-IDLG-DEMAIS WS-IDLG-DEMAIS-PARC WS-IDLG-CARTAO WS-IDLG-CHQ WS-IDLG-1313 WS-IDLG-DIRID. */
            _.Move(DET_REGISTRO.DET_IDLG, WS_IDLG_VIDA, WS_IDLG_BILHETE, WS_IDLG_DEMAIS, WS_IDLG_DEMAIS_PARC, WS_IDLG_CARTAO, WS_IDLG_CHQ, WS_IDLG_1313, W.WS_IDLG_DIRID);

            /*" -2771- MOVE DET-IDLG TO MOVCC-IDLG. */
            _.Move(DET_REGISTRO.DET_IDLG, MOVCC_REGISTRO.MOVCC_IDLG);

            /*" -2784- MOVE 'S' TO WTEM-REGISTRO. */
            _.Move("S", W.WTEM_REGISTRO);

            /*" -2785- IF DET-TIPREG EQUAL 05 */

            if (DET_REGISTRO.DET_TIPREG == 05)
            {

                /*" -2786- PERFORM R4000-00-TRATA-SICOB */

                R4000_00_TRATA_SICOB_SECTION();

                /*" -2790- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2793- IF WS-EMP-ANT EQUAL 'C000' OR 'C010' OR 'D011' */

            if (W.WS_EMP_ANT.In("C000", "C010", "D011"))
            {

                /*" -2794- IF DET-TIPREG EQUAL 06 */

                if (DET_REGISTRO.DET_TIPREG == 06)
                {

                    /*" -2795- PERFORM R5000-00-TRATA-SIGPF */

                    R5000_00_TRATA_SIGPF_SECTION();

                    /*" -2799- GO TO R0400-90-LEITURA. */

                    R0400_90_LEITURA(); //GOTO
                    return;
                }

            }


            /*" -2800- IF DET-TIPREG EQUAL 07 */

            if (DET_REGISTRO.DET_TIPREG == 07)
            {

                /*" -2801- PERFORM R3000-00-TRATA-SICAP */

                R3000_00_TRATA_SICAP_SECTION();

                /*" -2805- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2806- IF DET-TIPREG EQUAL 09 */

            if (DET_REGISTRO.DET_TIPREG == 09)
            {

                /*" -2807- PERFORM R3500-00-TRATA-BANCOOB */

                R3500_00_TRATA_BANCOOB_SECTION();

                /*" -2811- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2812- IF DET-TIPREG EQUAL 11 */

            if (DET_REGISTRO.DET_TIPREG == 11)
            {

                /*" -2813- PERFORM R2400-00-TRATA-DET11 */

                R2400_00_TRATA_DET11_SECTION();

                /*" -2817- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2819- IF DET-TIPREG EQUAL 14 */

            if (DET_REGISTRO.DET_TIPREG == 14)
            {

                /*" -2820- PERFORM R2900-00-TRATA-DET14 */

                R2900_00_TRATA_DET14_SECTION();

                /*" -2824- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2825- IF DET-TIPREG EQUAL 13 */

            if (DET_REGISTRO.DET_TIPREG == 13)
            {

                /*" -2826- PERFORM R5500-00-TRATA-DET13 */

                R5500_00_TRATA_DET13_SECTION();

                /*" -2827- GO TO R0400-90-LEITURA */

                R0400_90_LEITURA(); //GOTO
                return;

                /*" -2832- END-IF. */
            }


            /*" -2833- IF DET-TIPREG EQUAL 15 */

            if (DET_REGISTRO.DET_TIPREG == 15)
            {

                /*" -2834- PERFORM R5550-00-TRATA-DET15 */

                R5550_00_TRATA_DET15_SECTION();

                /*" -2835- GO TO R0400-90-LEITURA */

                R0400_90_LEITURA(); //GOTO
                return;

                /*" -2839- END-IF. */
            }


            /*" -2840- IF DET-TIPREG EQUAL 12 */

            if (DET_REGISTRO.DET_TIPREG == 12)
            {

                /*" -2841- PERFORM R2700-00-TRATA-DET12 */

                R2700_00_TRATA_DET12_SECTION();

                /*" -2845- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2846- IF WS-IDLG-CONV EQUAL 608800 OR 609000 OR 613100 OR 613200 */

            if (FILLER_16.WS_IDLG_CONV.In("608800", "609000", "613100", "613200"))
            {

                /*" -2847- PERFORM R0500-00-TRATA-VIDA */

                R0500_00_TRATA_VIDA_SECTION();

                /*" -2849- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2850- IF WS-IDLG-CONV EQUAL 600121 */

            if (FILLER_16.WS_IDLG_CONV == 600121)
            {

                /*" -2851- PERFORM R0600-00-TRATA-LOTERICO */

                R0600_00_TRATA_LOTERICO_SECTION();

                /*" -2853- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2854- IF WS-IDLG-CONV EQUAL 600114 */

            if (FILLER_16.WS_IDLG_CONV == 600114)
            {

                /*" -2855- PERFORM R0700-00-TRATA-BILHETE */

                R0700_00_TRATA_BILHETE_SECTION();

                /*" -2857- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2858- IF WS-IDLG-CONV EQUAL 600139 OR 600140 */

            if (FILLER_16.WS_IDLG_CONV.In("600139", "600140"))
            {

                /*" -2859- PERFORM R0800-00-TRATA-AUTO */

                R0800_00_TRATA_AUTO_SECTION();

                /*" -2861- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2862- IF WS-IDLG-CONV EQUAL 600149 */

            if (FILLER_16.WS_IDLG_CONV == 600149)
            {

                /*" -2863- PERFORM R0600-00-TRATA-LOTERICO */

                R0600_00_TRATA_LOTERICO_SECTION();

                /*" -2865- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2866- IF WS-IDLG-CONV EQUAL 900662 */

            if (FILLER_16.WS_IDLG_CONV == 900662)
            {

                /*" -2867- PERFORM R0900-00-TRATA-RED-CHQ */

                R0900_00_TRATA_RED_CHQ_SECTION();

                /*" -2871- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2872- IF WS-IDLG-CONV EQUAL 921286 */

            if (FILLER_16.WS_IDLG_CONV == 921286)
            {

                /*" -2873- MOVE WS-IDLG-CONV TO SIACC-CONVENIO */
                _.Move(FILLER_16.WS_IDLG_CONV, REG_SIACC.SIACC_CONVENIO);

                /*" -2875- MOVE DET-IDLG TO SIACC-IDLG */
                _.Move(DET_REGISTRO.DET_IDLG, REG_SIACC.SIACC_IDLG);

                /*" -2877- PERFORM R0560-00-VER-PRODUTO-EF */

                R0560_00_VER_PRODUTO_EF_SECTION();

                /*" -2878- IF WS-CONTRATO-EF = 'SIM' */

                if (WS_CONTRATO_EF == "SIM")
                {

                    /*" -2879- PERFORM R0570-00-TRATA-PRTMSTA-EF */

                    R0570_00_TRATA_PRTMSTA_EF_SECTION();

                    /*" -2880- ELSE */
                }
                else
                {


                    /*" -2881- PERFORM R1500-00-GRAVA-SIACC */

                    R1500_00_GRAVA_SIACC_SECTION();

                    /*" -2883- END-IF */
                }


                /*" -2886- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -2891- IF DET-IDLG(01:1) EQUAL "S" AND DET-IDLG(15:1) EQUAL "|" AND DET-IDLG(21:1) EQUAL "|" AND DET-IDLG(26:1) EQUAL "|" */

            if (DET_REGISTRO.DET_IDLG.Substring(01, 1) == "SISTEMAS.DCLSISTEMAS.SISTEMAS_IND_SGBD" && DET_REGISTRO.DET_IDLG.Substring(15, 1) == "|" && DET_REGISTRO.DET_IDLG.Substring(21, 1) == "|" && DET_REGISTRO.DET_IDLG.Substring(26, 1) == "|")
            {

                /*" -2893- ADD 1 TO TT-SINISTRO */
                W.TT_SINISTRO.Value = W.TT_SINISTRO + 1;

                /*" -2895- PERFORM R8000-00-TRATA-SINISTRO */

                R8000_00_TRATA_SINISTRO_SECTION();

                /*" -2896- IF WS-TRATA-SINISTRO EQUAL 'SIM' */

                if (W.WS_TRATA_SINISTRO == "SIM")
                {

                    /*" -2897- ADD 1 TO TE-SINISTRO */
                    W.TE_SINISTRO.Value = W.TE_SINISTRO + 1;

                    /*" -2898- ELSE */
                }
                else
                {


                    /*" -2899- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                    R9000_00_GRAVA_EXPURGO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                    /*" -2900- GO TO R0400-90-LEITURA */

                    R0400_90_LEITURA(); //GOTO
                    return;

                    /*" -2901- ELSE */
                }

            }
            else
            {


                /*" -2902- IF WS-IDLG-CONV EQUAL 001313 */

                if (FILLER_16.WS_IDLG_CONV == 001313)
                {

                    /*" -2903- PERFORM R0550-00-TRATA-CONV1313 */

                    R0550_00_TRATA_CONV1313_SECTION();

                    /*" -2904- ELSE */
                }
                else
                {


                    /*" -2905- MOVE DET-IDLG TO CHEQUE-IDLG */
                    _.Move(DET_REGISTRO.DET_IDLG, REG_CHEQUE.CHEQUE_IDLG);

                    /*" -2905- PERFORM R7000-00-TRATA-CHEQUE. */

                    R7000_00_TRATA_CHEQUE_SECTION();
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0400_90_LEITURA */

            R0400_90_LEITURA();

        }

        [StopWatch]
        /*" R0400-90-LEITURA */
        private void R0400_90_LEITURA(bool isPerform = false)
        {
            /*" -2909- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-TRATA-HEADER-SECTION */
        private void R0410_00_TRATA_HEADER_SECTION()
        {
            /*" -2920- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2922- MOVE HEA-NSASAP TO WS-HEA-NSASAP */
            _.Move(HEA_REGISTRO.HEA_NSASAP, W.WS_HEA_NSASAP);

            /*" -2942- IF HEA-EMPRESA NOT EQUAL 'C000' AND HEA-EMPRESA NOT EQUAL 'C010' AND HEA-EMPRESA NOT EQUAL 'C100' AND HEA-EMPRESA NOT EQUAL 'C101' AND HEA-EMPRESA NOT EQUAL 'K100' AND HEA-EMPRESA NOT EQUAL 'K102' AND HEA-EMPRESA NOT EQUAL 'N103' AND HEA-EMPRESA NOT EQUAL 'S100' AND HEA-EMPRESA NOT EQUAL 'S101' AND HEA-EMPRESA NOT EQUAL 'S102' AND HEA-EMPRESA NOT EQUAL 'S103' AND HEA-EMPRESA NOT EQUAL 'S104' AND HEA-EMPRESA NOT EQUAL 'S106' AND HEA-EMPRESA NOT EQUAL 'S107' AND HEA-EMPRESA NOT EQUAL 'S108' AND HEA-EMPRESA NOT EQUAL 'S109' AND HEA-EMPRESA NOT EQUAL 'S110' AND HEA-EMPRESA NOT EQUAL 'S201' AND HEA-EMPRESA NOT EQUAL 'S204' AND HEA-EMPRESA NOT EQUAL 'S205' */

            if (HEA_REGISTRO.HEA_EMPRESA != "C000" && HEA_REGISTRO.HEA_EMPRESA != "C010" && HEA_REGISTRO.HEA_EMPRESA != "C100" && HEA_REGISTRO.HEA_EMPRESA != "C101" && HEA_REGISTRO.HEA_EMPRESA != "K100" && HEA_REGISTRO.HEA_EMPRESA != "K102" && HEA_REGISTRO.HEA_EMPRESA != "N103" && HEA_REGISTRO.HEA_EMPRESA != "S100" && HEA_REGISTRO.HEA_EMPRESA != "S101" && HEA_REGISTRO.HEA_EMPRESA != "S102" && HEA_REGISTRO.HEA_EMPRESA != "S103" && HEA_REGISTRO.HEA_EMPRESA != "S104" && HEA_REGISTRO.HEA_EMPRESA != "S106" && HEA_REGISTRO.HEA_EMPRESA != "S107" && HEA_REGISTRO.HEA_EMPRESA != "S108" && HEA_REGISTRO.HEA_EMPRESA != "S109" && HEA_REGISTRO.HEA_EMPRESA != "S110" && HEA_REGISTRO.HEA_EMPRESA != "S201" && HEA_REGISTRO.HEA_EMPRESA != "S204" && HEA_REGISTRO.HEA_EMPRESA != "S205")
            {

                /*" -2943- MOVE 'S' TO WS-TRATA */
                _.Move("S", W.WS_TRATA);

                /*" -2944- MOVE HEA-EMPRESA TO WS-EMP-ANT */
                _.Move(HEA_REGISTRO.HEA_EMPRESA, W.WS_EMP_ANT);

                /*" -2945- ELSE */
            }
            else
            {


                /*" -2946- MOVE 'S' TO WS-TRATA */
                _.Move("S", W.WS_TRATA);

                /*" -2946- MOVE HEA-EMPRESA TO WS-EMP-ANT. */
                _.Move(HEA_REGISTRO.HEA_EMPRESA, W.WS_EMP_ANT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-VERIFICA-DATAS-SECTION */
        private void R0450_00_VERIFICA_DATAS_SECTION()
        {
            /*" -2960- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -2961- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -2963- IF DET1-DT-MOVTO EQUAL '00000000' OR DET1-DT-MOVTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG1.DET1_DT_MOVTO == "00000000" || DET_REGISTRO.DET_REG1.DET1_DT_MOVTO.IsEmpty())
                {

                    /*" -2964- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -2965- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -2966- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -2968- MOVE WS-DATA-SAP TO DET1-DT-MOVTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG1.DET1_DT_MOVTO);
                }

            }


            /*" -2969- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -2971- IF DET1-DT-ENVIO EQUAL '00000000' OR DET1-DT-ENVIO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG1.DET1_DT_ENVIO == "00000000" || DET_REGISTRO.DET_REG1.DET1_DT_ENVIO.IsEmpty())
                {

                    /*" -2972- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -2973- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -2974- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -2976- MOVE WS-DATA-SAP TO DET1-DT-ENVIO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG1.DET1_DT_ENVIO);
                }

            }


            /*" -2977- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -2979- IF DET1-DT-CONTABIL EQUAL '00000000' OR DET1-DT-CONTABIL EQUAL SPACES */

                if (DET_REGISTRO.DET_REG1.DET1_DT_CONTABIL == "00000000" || DET_REGISTRO.DET_REG1.DET1_DT_CONTABIL.IsEmpty())
                {

                    /*" -2980- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -2981- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -2982- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -2985- MOVE WS-DATA-SAP TO DET1-DT-CONTABIL. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG1.DET1_DT_CONTABIL);
                }

            }


            /*" -2986- IF DET-TIPREG EQUAL 02 */

            if (DET_REGISTRO.DET_TIPREG == 02)
            {

                /*" -2988- IF DET2-DT-MOVTO EQUAL '00000000' OR DET2-DT-MOVTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG2.DET2_DT_MOVTO == "00000000" || DET_REGISTRO.DET_REG2.DET2_DT_MOVTO.IsEmpty())
                {

                    /*" -2989- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -2990- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -2991- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -2993- MOVE WS-DATA-SAP TO DET2-DT-MOVTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG2.DET2_DT_MOVTO);
                }

            }


            /*" -2994- IF DET-TIPREG EQUAL 02 */

            if (DET_REGISTRO.DET_TIPREG == 02)
            {

                /*" -2996- IF DET2-DT-EFETIV EQUAL '00000000' OR DET2-DT-EFETIV EQUAL SPACES */

                if (DET_REGISTRO.DET_REG2.DET2_DT_EFETIV == "00000000" || DET_REGISTRO.DET_REG2.DET2_DT_EFETIV.IsEmpty())
                {

                    /*" -2997- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -2998- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -2999- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3002- MOVE WS-DATA-SAP TO DET2-DT-EFETIV. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG2.DET2_DT_EFETIV);
                }

            }


            /*" -3003- IF DET-TIPREG EQUAL 03 */

            if (DET_REGISTRO.DET_TIPREG == 03)
            {

                /*" -3005- IF DET3-DT-MOVTO EQUAL '00000000' OR DET3-DT-MOVTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG3.DET3_DT_MOVTO == "00000000" || DET_REGISTRO.DET_REG3.DET3_DT_MOVTO.IsEmpty())
                {

                    /*" -3006- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3007- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3008- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3010- MOVE WS-DATA-SAP TO DET3-DT-MOVTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG3.DET3_DT_MOVTO);
                }

            }


            /*" -3011- IF DET-TIPREG EQUAL 03 */

            if (DET_REGISTRO.DET_TIPREG == 03)
            {

                /*" -3013- IF DET3-DT-VENCTO EQUAL '00000000' OR DET3-DT-VENCTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG3.DET3_DT_VENCTO == "00000000" || DET_REGISTRO.DET_REG3.DET3_DT_VENCTO.IsEmpty())
                {

                    /*" -3014- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3015- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3016- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3018- MOVE WS-DATA-SAP TO DET3-DT-VENCTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG3.DET3_DT_VENCTO);
                }

            }


            /*" -3019- IF DET-TIPREG EQUAL 03 */

            if (DET_REGISTRO.DET_TIPREG == 03)
            {

                /*" -3021- IF DET3-DT-AGENDTO EQUAL '00000000' OR DET3-DT-AGENDTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG3.DET3_DT_AGENDTO == "00000000" || DET_REGISTRO.DET_REG3.DET3_DT_AGENDTO.IsEmpty())
                {

                    /*" -3022- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3023- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3024- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3027- MOVE WS-DATA-SAP TO DET3-DT-AGENDTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG3.DET3_DT_AGENDTO);
                }

            }


            /*" -3028- IF DET-TIPREG EQUAL 04 */

            if (DET_REGISTRO.DET_TIPREG == 04)
            {

                /*" -3030- IF DET4-DT-GERACAO EQUAL '00000000' OR DET4-DT-GERACAO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG4.DET4_DT_GERACAO == "00000000" || DET_REGISTRO.DET_REG4.DET4_DT_GERACAO.IsEmpty())
                {

                    /*" -3031- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3032- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3033- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3035- MOVE WS-DATA-SAP TO DET4-DT-GERACAO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG4.DET4_DT_GERACAO);
                }

            }


            /*" -3036- IF DET-TIPREG EQUAL 04 */

            if (DET_REGISTRO.DET_TIPREG == 04)
            {

                /*" -3038- IF DET4-DT-DEBITO EQUAL '00000000' OR DET4-DT-DEBITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG4.DET4_DT_DEBITO == "00000000" || DET_REGISTRO.DET_REG4.DET4_DT_DEBITO.IsEmpty())
                {

                    /*" -3039- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3040- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3041- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3044- MOVE WS-DATA-SAP TO DET4-DT-DEBITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG4.DET4_DT_DEBITO);
                }

            }


            /*" -3045- IF DET-TIPREG EQUAL 05 */

            if (DET_REGISTRO.DET_TIPREG == 05)
            {

                /*" -3047- IF DET5-DT-GERACAO EQUAL '00000000' OR DET5-DT-GERACAO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG5.DET5_DT_GERACAO == "00000000" || DET_REGISTRO.DET_REG5.DET5_DT_GERACAO.IsEmpty())
                {

                    /*" -3048- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3049- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3050- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3052- MOVE WS-DATA-SAP TO DET5-DT-GERACAO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG5.DET5_DT_GERACAO);
                }

            }


            /*" -3053- IF DET-TIPREG EQUAL 05 */

            if (DET_REGISTRO.DET_TIPREG == 05)
            {

                /*" -3055- IF DET5-DT-OCORR EQUAL '00000000' OR DET5-DT-OCORR EQUAL SPACES */

                if (DET_REGISTRO.DET_REG5.DET5_DT_OCORR == "00000000" || DET_REGISTRO.DET_REG5.DET5_DT_OCORR.IsEmpty())
                {

                    /*" -3056- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3057- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3058- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3060- MOVE WS-DATA-SAP TO DET5-DT-OCORR. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG5.DET5_DT_OCORR);
                }

            }


            /*" -3061- IF DET-TIPREG EQUAL 05 */

            if (DET_REGISTRO.DET_TIPREG == 05)
            {

                /*" -3063- IF DET5-DT-VENCTO EQUAL '00000000' OR DET5-DT-VENCTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG5.DET5_DT_VENCTO == "00000000" || DET_REGISTRO.DET_REG5.DET5_DT_VENCTO.IsEmpty())
                {

                    /*" -3064- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3065- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3066- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3068- MOVE WS-DATA-SAP TO DET5-DT-VENCTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG5.DET5_DT_VENCTO);
                }

            }


            /*" -3069- IF DET-TIPREG EQUAL 05 */

            if (DET_REGISTRO.DET_TIPREG == 05)
            {

                /*" -3071- IF DET5-DT-DEB-TARIFA EQUAL '00000000' OR DET5-DT-DEB-TARIFA EQUAL SPACES */

                if (DET_REGISTRO.DET_REG5.DET5_DT_DEB_TARIFA == "00000000" || DET_REGISTRO.DET_REG5.DET5_DT_DEB_TARIFA.IsEmpty())
                {

                    /*" -3072- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3073- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3074- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3076- MOVE WS-DATA-SAP TO DET5-DT-DEB-TARIFA. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG5.DET5_DT_DEB_TARIFA);
                }

            }


            /*" -3077- IF DET-TIPREG EQUAL 05 */

            if (DET_REGISTRO.DET_TIPREG == 05)
            {

                /*" -3079- IF DET5-DT-CREDITO EQUAL '00000000' OR DET5-DT-CREDITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG5.DET5_DT_CREDITO == "00000000" || DET_REGISTRO.DET_REG5.DET5_DT_CREDITO.IsEmpty())
                {

                    /*" -3080- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3081- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3082- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3085- MOVE WS-DATA-SAP TO DET5-DT-CREDITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG5.DET5_DT_CREDITO);
                }

            }


            /*" -3086- IF DET-TIPREG EQUAL 06 */

            if (DET_REGISTRO.DET_TIPREG == 06)
            {

                /*" -3088- IF DET6-DT-GERACAO EQUAL '00000000' OR DET6-DT-GERACAO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG6.DET6_DT_GERACAO == "00000000" || DET_REGISTRO.DET_REG6.DET6_DT_GERACAO.IsEmpty())
                {

                    /*" -3089- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3090- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3091- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3093- MOVE WS-DATA-SAP TO DET6-DT-GERACAO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG6.DET6_DT_GERACAO);
                }

            }


            /*" -3094- IF DET-TIPREG EQUAL 06 */

            if (DET_REGISTRO.DET_TIPREG == 06)
            {

                /*" -3096- IF DET6-DT-PAGTO EQUAL '00000000' OR DET6-DT-PAGTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG6.DET6_DT_PAGTO == "00000000" || DET_REGISTRO.DET_REG6.DET6_DT_PAGTO.IsEmpty())
                {

                    /*" -3097- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3098- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3099- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3101- MOVE WS-DATA-SAP TO DET6-DT-PAGTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG6.DET6_DT_PAGTO);
                }

            }


            /*" -3102- IF DET-TIPREG EQUAL 06 */

            if (DET_REGISTRO.DET_TIPREG == 06)
            {

                /*" -3104- IF DET6-DT-CREDITO EQUAL '00000000' OR DET6-DT-CREDITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG6.DET6_DT_CREDITO == "00000000" || DET_REGISTRO.DET_REG6.DET6_DT_CREDITO.IsEmpty())
                {

                    /*" -3105- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3106- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3107- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3110- MOVE WS-DATA-SAP TO DET6-DT-CREDITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG6.DET6_DT_CREDITO);
                }

            }


            /*" -3111- IF DET-TIPREG EQUAL 07 */

            if (DET_REGISTRO.DET_TIPREG == 07)
            {

                /*" -3113- IF DET7-DT-GERACAO EQUAL '00000000' OR DET7-DT-GERACAO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG7.DET7_DT_GERACAO == "00000000" || DET_REGISTRO.DET_REG7.DET7_DT_GERACAO.IsEmpty())
                {

                    /*" -3114- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3115- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3116- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3118- MOVE WS-DATA-SAP TO DET7-DT-GERACAO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG7.DET7_DT_GERACAO);
                }

            }


            /*" -3119- IF DET-TIPREG EQUAL 07 */

            if (DET_REGISTRO.DET_TIPREG == 07)
            {

                /*" -3121- IF DET7-DT-PAGTO EQUAL '00000000' OR DET7-DT-PAGTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG7.DET7_DT_PAGTO == "00000000" || DET_REGISTRO.DET_REG7.DET7_DT_PAGTO.IsEmpty())
                {

                    /*" -3122- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3123- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3124- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3126- MOVE WS-DATA-SAP TO DET7-DT-PAGTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG7.DET7_DT_PAGTO);
                }

            }


            /*" -3127- IF DET-TIPREG EQUAL 07 */

            if (DET_REGISTRO.DET_TIPREG == 07)
            {

                /*" -3129- IF DET7-DT-CREDITO EQUAL '00000000' OR DET7-DT-CREDITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG7.DET7_DT_CREDITO == "00000000" || DET_REGISTRO.DET_REG7.DET7_DT_CREDITO.IsEmpty())
                {

                    /*" -3130- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3131- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3132- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3135- MOVE WS-DATA-SAP TO DET7-DT-CREDITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG7.DET7_DT_CREDITO);
                }

            }


            /*" -3136- IF DET-TIPREG EQUAL 09 */

            if (DET_REGISTRO.DET_TIPREG == 09)
            {

                /*" -3138- IF DET9-DT-GERACAO EQUAL '00000000' OR DET9-DT-GERACAO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG9.DET9_DT_GERACAO == "00000000" || DET_REGISTRO.DET_REG9.DET9_DT_GERACAO.IsEmpty())
                {

                    /*" -3139- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3140- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3141- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3143- MOVE WS-DATA-SAP TO DET9-DT-GERACAO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG9.DET9_DT_GERACAO);
                }

            }


            /*" -3144- IF DET-TIPREG EQUAL 09 */

            if (DET_REGISTRO.DET_TIPREG == 09)
            {

                /*" -3146- IF DET9-DT-LIQUIDA EQUAL '00000000' OR DET9-DT-LIQUIDA EQUAL SPACES */

                if (DET_REGISTRO.DET_REG9.DET9_DT_LIQUIDA == "00000000" || DET_REGISTRO.DET_REG9.DET9_DT_LIQUIDA.IsEmpty())
                {

                    /*" -3147- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3148- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3149- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3151- MOVE WS-DATA-SAP TO DET9-DT-LIQUIDA. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG9.DET9_DT_LIQUIDA);
                }

            }


            /*" -3152- IF DET-TIPREG EQUAL 09 */

            if (DET_REGISTRO.DET_TIPREG == 09)
            {

                /*" -3154- IF DET9-DT-VENCTO EQUAL '00000000' OR DET9-DT-VENCTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG9.DET9_DT_VENCTO == "00000000" || DET_REGISTRO.DET_REG9.DET9_DT_VENCTO.IsEmpty())
                {

                    /*" -3155- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3156- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3157- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3159- MOVE WS-DATA-SAP TO DET9-DT-VENCTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG9.DET9_DT_VENCTO);
                }

            }


            /*" -3160- IF DET-TIPREG EQUAL 09 */

            if (DET_REGISTRO.DET_TIPREG == 09)
            {

                /*" -3162- IF DET9-DT-CREDITO EQUAL '00000000' OR DET9-DT-CREDITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG9.DET9_DT_CREDITO == "00000000" || DET_REGISTRO.DET_REG9.DET9_DT_CREDITO.IsEmpty())
                {

                    /*" -3163- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3164- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3165- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3168- MOVE WS-DATA-SAP TO DET9-DT-CREDITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG9.DET9_DT_CREDITO);
                }

            }


            /*" -3169- IF DET-TIPREG EQUAL 11 */

            if (DET_REGISTRO.DET_TIPREG == 11)
            {

                /*" -3171- IF DET11-DT-GERACAO EQUAL '00000000' OR DET11-DT-GERACAO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG11.DET11_DT_GERACAO == "00000000" || DET_REGISTRO.DET_REG11.DET11_DT_GERACAO.IsEmpty())
                {

                    /*" -3172- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3173- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3174- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3176- MOVE WS-DATA-SAP TO DET11-DT-GERACAO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG11.DET11_DT_GERACAO);
                }

            }


            /*" -3177- IF DET-TIPREG EQUAL 11 */

            if (DET_REGISTRO.DET_TIPREG == 11)
            {

                /*" -3179- IF DET11-DT-PAGTO EQUAL '00000000' OR DET11-DT-PAGTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG11.DET11_DT_PAGTO == "00000000" || DET_REGISTRO.DET_REG11.DET11_DT_PAGTO.IsEmpty())
                {

                    /*" -3180- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3181- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3182- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3184- MOVE WS-DATA-SAP TO DET11-DT-PAGTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG11.DET11_DT_PAGTO);
                }

            }


            /*" -3185- IF DET-TIPREG EQUAL 11 */

            if (DET_REGISTRO.DET_TIPREG == 11)
            {

                /*" -3187- IF DET11-DT-CREDITO EQUAL '00000000' OR DET11-DT-CREDITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG11.DET11_DT_CREDITO == "00000000" || DET_REGISTRO.DET_REG11.DET11_DT_CREDITO.IsEmpty())
                {

                    /*" -3188- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3189- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3190- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3193- MOVE WS-DATA-SAP TO DET11-DT-CREDITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG11.DET11_DT_CREDITO);
                }

            }


            /*" -3194- IF DET-TIPREG EQUAL 14 */

            if (DET_REGISTRO.DET_TIPREG == 14)
            {

                /*" -3196- IF DET14-DT-MOVTO EQUAL '00000000' OR DET14-DT-MOVTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG14.DET14_DT_MOVTO == "00000000" || DET_REGISTRO.DET_REG14.DET14_DT_MOVTO.IsEmpty())
                {

                    /*" -3197- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3198- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3199- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3202- MOVE WS-DATA-SAP TO DET14-DT-MOVTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG14.DET14_DT_MOVTO);
                }

            }


            /*" -3203- IF DET-TIPREG EQUAL 14 */

            if (DET_REGISTRO.DET_TIPREG == 14)
            {

                /*" -3205- IF DET14-DT-CREDITO EQUAL '00000000' OR DET14-DT-CREDITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG14.DET14_DT_CREDITO == "00000000" || DET_REGISTRO.DET_REG14.DET14_DT_CREDITO.IsEmpty())
                {

                    /*" -3206- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3207- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3208- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3210- MOVE WS-DATA-SAP TO DET14-DT-CREDITO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG14.DET14_DT_CREDITO);
                }

            }


            /*" -3211- IF DET-TIPREG EQUAL 16 */

            if (DET_REGISTRO.DET_TIPREG == 16)
            {

                /*" -3213- IF DET2-DT-MOVTO EQUAL '00000000' OR DET2-DT-MOVTO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG2.DET2_DT_MOVTO == "00000000" || DET_REGISTRO.DET_REG2.DET2_DT_MOVTO.IsEmpty())
                {

                    /*" -3214- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3215- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3216- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3218- MOVE WS-DATA-SAP TO DET2-DT-MOVTO. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG2.DET2_DT_MOVTO);
                }

            }


            /*" -3219- IF DET-TIPREG EQUAL 16 */

            if (DET_REGISTRO.DET_TIPREG == 16)
            {

                /*" -3221- IF DET16-DT-DEBITO EQUAL '00000000' OR DET16-DT-DEBITO EQUAL SPACES */

                if (DET_REGISTRO.DET_REG16.DET16_DT_DEBITO == "00000000" || DET_REGISTRO.DET_REG16.DET16_DT_DEBITO.IsEmpty())
                {

                    /*" -3222- MOVE WDAT-REL-DIA TO WS-DD-SAP */
                    _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

                    /*" -3223- MOVE WDAT-REL-MES TO WS-MM-SAP */
                    _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

                    /*" -3224- MOVE WDAT-REL-ANO TO WS-AA-SAP */
                    _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

                    /*" -3226- MOVE WS-DATA-SAP TO DET2-DT-EFETIV. */
                    _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG2.DET2_DT_EFETIV);
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-TRATA-VIDA-SECTION */
        private void R0500_00_TRATA_VIDA_SECTION()
        {
            /*" -3238- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3240- ADD 1 TO TT-VIDA. */
            W.TT_VIDA.Value = W.TT_VIDA + 1;

            /*" -3243- MOVE WS-IDLG-CONV TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_16.WS_IDLG_CONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3246- MOVE WS-IDLG-NSA TO MOVDEBCE-NSAS. */
            _.Move(FILLER_16.WS_IDLG_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3249- MOVE WS-IDLG-NRSEQ TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(FILLER_16.WS_IDLG_NRSEQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3251- PERFORM R1900-00-SELECT-MOVDEBCC. */

            R1900_00_SELECT_MOVDEBCC_SECTION();

            /*" -3252- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3253- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3254- GO TO R0500-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;

                /*" -3257- END-IF. */
            }


            /*" -3260- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3263- MOVE MOVDEBCE-COD-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3266- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3268- MOVE SPACES TO WS-IDTCLIEMP. */
            _.Move("", WS_IDTCLIEMP);

            /*" -3270- MOVE MOVDEBCE-NUM-CARTAO TO WS-NUM-CERTIF. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, FILLER_35.WS_NUM_CERTIF);

            /*" -3272- MOVE MOVDEBCE-NSAS TO WS-NUM-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_35.WS_NUM_NSAS);

            /*" -3275- MOVE WS-IDTCLIEMP TO MOVCC-IDTCLIEMP. */
            _.Move(WS_IDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -3277- MOVE SPACES TO WS-USOEMPRESA. */
            _.Move("", WS_USOEMPRESA);

            /*" -3279- MOVE MOVDEBCE-NSAS TO WS-NSL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, WS_NSL);

            /*" -3281- MOVE WS-NSL2 TO WS-NUM-NSL. */
            _.Move(FILLER_45.WS_NSL2, FILLER_46.WS_NUM_NSL);

            /*" -3283- MOVE MOVDEBCE-NUM-ENDOSSO TO WS-NUM-NRSEQ. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, FILLER_46.WS_NUM_NRSEQ);

            /*" -3286- MOVE WS-USOEMPRESA TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3286- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-TRATA-CONV1313-SECTION */
        private void R0550_00_TRATA_CONV1313_SECTION()
        {
            /*" -3300- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3302- ADD 1 TO TT-CONV1313. */
            W.TT_CONV1313.Value = W.TT_CONV1313 + 1;

            /*" -3305- MOVE WS-IDLG-CONV-1313 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_18.WS_IDLG_CONV_1313, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3308- MOVE WS-IDLG-NSA-1313 TO MOVDEBCE-NSAS. */
            _.Move(FILLER_18.WS_IDLG_NSA_1313, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3311- MOVE WS-IDLG-NRSEQ-1313 TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(FILLER_18.WS_IDLG_NRSEQ_1313, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -3314- PERFORM R1910-00-SELECT-MOVDEBCC. */

            R1910_00_SELECT_MOVDEBCC_SECTION();

            /*" -3315- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3316- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3317- GO TO R0550-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                return;

                /*" -3320- END-IF. */
            }


            /*" -3322- MOVE MOVDEBCE-NUM-CARTAO TO HISLANCT-NUM-CERTIFICADO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -3324- MOVE MOVDEBCE-NUM-PARCELA TO HISLANCT-NUM-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -3326- MOVE 6090 TO HISLANCT-CODCONV. */
            _.Move(6090, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);

            /*" -3329- MOVE MOVDEBCE-NSAS TO HISLANCT-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

            /*" -3332- PERFORM R1920-00-SELECT-HISLANCT. */

            R1920_00_SELECT_HISLANCT_SECTION();

            /*" -3333- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3334- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3335- GO TO R0550-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/ //GOTO
                return;

                /*" -3338- END-IF. */
            }


            /*" -3341- MOVE 609000 TO MOVCC-CONVENIO. */
            _.Move(609000, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3343- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3346- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3348- MOVE SPACES TO WS-IDTCLIEMP. */
            _.Move("", WS_IDTCLIEMP);

            /*" -3350- MOVE MOVDEBCE-NUM-CARTAO TO WS-NUM-CERTIF. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, FILLER_35.WS_NUM_CERTIF);

            /*" -3352- MOVE MOVDEBCE-NSAS TO WS-NUM-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_35.WS_NUM_NSAS);

            /*" -3355- MOVE WS-IDTCLIEMP TO MOVCC-IDTCLIEMP. */
            _.Move(WS_IDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -3357- MOVE SPACES TO WS-USOEMPRESA. */
            _.Move("", WS_USOEMPRESA);

            /*" -3359- MOVE MOVDEBCE-NSAS TO WS-NSL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, WS_NSL);

            /*" -3361- MOVE WS-NSL2 TO WS-NUM-NSL. */
            _.Move(FILLER_45.WS_NSL2, FILLER_46.WS_NUM_NSL);

            /*" -3363- MOVE HISLANCT-NSL TO WS-NUM-NRSEQ. */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL, FILLER_46.WS_NUM_NRSEQ);

            /*" -3366- MOVE WS-USOEMPRESA TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3366- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0560-00-VER-PRODUTO-EF-SECTION */
        private void R0560_00_VER_PRODUTO_EF_SECTION()
        {
            /*" -3377- MOVE '0560' TO WNR-EXEC-SQL. */
            _.Move("0560", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3378- MOVE SPACES TO WS-CONTRATO-EF. */
            _.Move("", WS_CONTRATO_EF);

            /*" -3379- MOVE ZEROS TO WS-COUNT. */
            _.Move(0, WS_COUNT);

            /*" -3380- MOVE WS-IDLG-NRSEQ-1313 TO WS-NUM-REQUISICAO */
            _.Move(FILLER_18.WS_IDLG_NRSEQ_1313, WS_NUM_REQUISICAO);

            /*" -3382- MOVE WS-NUM-REQUISICAO TO EF150-NUM-OCORR-MOVTO */
            _.Move(WS_NUM_REQUISICAO, EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO);

            /*" -3388- PERFORM R0560_00_VER_PRODUTO_EF_DB_SELECT_1 */

            R0560_00_VER_PRODUTO_EF_DB_SELECT_1();

            /*" -3391- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3393- DISPLAY 'R1920-00 - PROBLEMAS NO SELECT EF_ENVIO_MOVTO_SAP ' */
                _.Display($"R1920-00 - PROBLEMAS NO SELECT EF_ENVIO_MOVTO_SAP ");

                /*" -3394- DISPLAY 'NUM_OCORR_MOVTO = ' EF150-NUM-OCORR-MOVTO */
                _.Display($"NUM_OCORR_MOVTO = {EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO}");

                /*" -3395- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3397- END-IF. */
            }


            /*" -3398- IF WS-COUNT > ZEROS */

            if (WS_COUNT > 00)
            {

                /*" -3399- MOVE 'SIM' TO WS-CONTRATO-EF */
                _.Move("SIM", WS_CONTRATO_EF);

                /*" -3399- END-IF. */
            }


        }

        [StopWatch]
        /*" R0560-00-VER-PRODUTO-EF-DB-SELECT-1 */
        public void R0560_00_VER_PRODUTO_EF_DB_SELECT_1()
        {
            /*" -3388- EXEC SQL SELECT COUNT (*) INTO :WS-COUNT FROM SEGUROS.EF_ENVIO_MOVTO_SAP WHERE NUM_OCORR_MOVTO = :EF150-NUM-OCORR-MOVTO WITH UR END-EXEC. */

            var r0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1 = new R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1()
            {
                EF150_NUM_OCORR_MOVTO = EF150.DCLEF_ENVIO_MOVTO_SAP.EF150_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1.Execute(r0560_00_VER_PRODUTO_EF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COUNT, WS_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_99_SAIDA*/

        [StopWatch]
        /*" R0570-00-TRATA-PRTMSTA-EF-SECTION */
        private void R0570_00_TRATA_PRTMSTA_EF_SECTION()
        {
            /*" -3408- MOVE '0570' TO WNR-EXEC-SQL. */
            _.Move("0570", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3410- ADD 1 TO TT-CONV1313. */
            W.TT_CONV1313.Value = W.TT_CONV1313 + 1;

            /*" -3413- MOVE WS-IDLG-CONV-1313 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_18.WS_IDLG_CONV_1313, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3416- MOVE WS-IDLG-NSA-1313 TO MOVDEBCE-NSAS. */
            _.Move(FILLER_18.WS_IDLG_NSA_1313, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3419- MOVE WS-IDLG-NRSEQ-1313 TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(FILLER_18.WS_IDLG_NRSEQ_1313, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -3421- PERFORM R0575-00-SELECT-MOVDEBCC. */

            R0575_00_SELECT_MOVDEBCC_SECTION();

            /*" -3422- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3423- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3424- GO TO R0570-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/ //GOTO
                return;

                /*" -3426- END-IF. */
            }


            /*" -3428- MOVE MOVDEBCE-NUM-CARTAO TO HISLANCT-NUM-CERTIFICADO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -3430- MOVE MOVDEBCE-NUM-PARCELA TO HISLANCT-NUM-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -3432- MOVE 6095 TO HISLANCT-CODCONV. */
            _.Move(6095, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);

            /*" -3435- MOVE MOVDEBCE-NSAS TO HISLANCT-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

            /*" -3437- MOVE 609500 TO WS-MOVCC-CONVENIO MOVCC-CONVENIO. */
            _.Move(609500, W.WS_MOVCC_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3439- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3442- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3444- MOVE SPACES TO WS-IDTCLIEMP. */
            _.Move("", WS_IDTCLIEMP);

            /*" -3446- MOVE MOVDEBCE-NUM-CARTAO TO WS-NUM-CERTIF. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, FILLER_35.WS_NUM_CERTIF);

            /*" -3448- MOVE MOVDEBCE-NSAS TO WS-NUM-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_35.WS_NUM_NSAS);

            /*" -3451- MOVE WS-IDTCLIEMP TO MOVCC-IDTCLIEMP. */
            _.Move(WS_IDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -3453- MOVE SPACES TO WS-USOEMPRESA. */
            _.Move("", WS_USOEMPRESA);

            /*" -3455- MOVE MOVDEBCE-NSAS TO WS-NSL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, WS_NSL);

            /*" -3457- MOVE WS-NSL2 TO WS-NUM-NSL. */
            _.Move(FILLER_45.WS_NSL2, FILLER_46.WS_NUM_NSL);

            /*" -3459- MOVE MOVDEBCE-NUM-ENDOSSO TO WS-NUM-NRSEQ. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, FILLER_46.WS_NUM_NRSEQ);

            /*" -3462- MOVE WS-USOEMPRESA TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3462- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_99_SAIDA*/

        [StopWatch]
        /*" R0575-00-SELECT-MOVDEBCC-SECTION */
        private void R0575_00_SELECT_MOVDEBCC_SECTION()
        {
            /*" -3473- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3503- PERFORM R0575_00_SELECT_MOVDEBCC_DB_SELECT_1 */

            R0575_00_SELECT_MOVDEBCC_DB_SELECT_1();

            /*" -3507- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3508- DISPLAY 'R0575-00 - NAO CADASTRADO MOVDEBCE' */
                _.Display($"R0575-00 - NAO CADASTRADO MOVDEBCE");

                /*" -3509- DISPLAY ' IDLG: ' DET-IDLG */
                _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -3510- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -3511- ELSE */
            }
            else
            {


                /*" -3512- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -3513- DISPLAY 'R0575-00 - PROBLEMAS NO SELECT MOVDEBCE' */
                    _.Display($"R0575-00 - PROBLEMAS NO SELECT MOVDEBCE");

                    /*" -3514- DISPLAY 'COD_CONVENIO    = ' MOVDEBCE-COD-CONVENIO */
                    _.Display($"COD_CONVENIO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                    /*" -3515- MOVE MOVDEBCE-NSAS TO WNSAS-DISPLAY */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, W.WNSAS_DISPLAY);

                    /*" -3516- DISPLAY 'NSAS            = ' WNSAS-DISPLAY */
                    _.Display($"NSAS            = {W.WNSAS_DISPLAY}");

                    /*" -3517- DISPLAY 'NUM_REUISICAO   = ' MOVDEBCE-NUM-REQUISICAO */
                    _.Display($"NUM_REUISICAO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                    /*" -3517- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0575-00-SELECT-MOVDEBCC-DB-SELECT-1 */
        public void R0575_00_SELECT_MOVDEBCC_DB_SELECT_1()
        {
            /*" -3503- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , VALUE(COD_AGENCIA_DEB, 0) , VALUE(OPER_CONTA_DEB, 0) , VALUE(NUM_CONTA_DEB, 0) , VALUE(DIG_CONTA_DEB, 0) , COD_CONVENIO , NSAS , VALUE(NUM_REQUISICAO, 0) , VALUE(NUM_CARTAO, 0) INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO , :MOVDEBCE-NUM-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO WITH UR END-EXEC. */

            var r0575_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 = new R0575_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R0575_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1.Execute(r0575_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0575_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-TRATA-LOTERICO-SECTION */
        private void R0600_00_TRATA_LOTERICO_SECTION()
        {
            /*" -3530- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3532- ADD 1 TO TT-LOTERICO. */
            W.TT_LOTERICO.Value = W.TT_LOTERICO + 1;

            /*" -3535- MOVE WS-IDLG-DEM-CON TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_21.WS_IDLG_DEM_CON, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3538- MOVE WS-IDLG-DEM-NSA TO MOVDEBCE-NSAS. */
            _.Move(FILLER_21.WS_IDLG_DEM_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3541- MOVE WS-IDLG-DEM-APO TO MOVDEBCE-NUM-APOLICE. */
            _.Move(FILLER_21.WS_IDLG_DEM_APO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -3544- MOVE WS-IDLG-DEM-END TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(FILLER_21.WS_IDLG_DEM_END, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3547- MOVE WS-IDLG-DEM-PAR TO MOVDEBCE-NUM-PARCELA. */
            _.Move(FILLER_21.WS_IDLG_DEM_PAR, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -3549- PERFORM R2100-00-SELECT-MOVDEBCC. */

            R2100_00_SELECT_MOVDEBCC_SECTION();

            /*" -3550- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3551- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3552- GO TO R0600-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;

                /*" -3554- END-IF. */
            }


            /*" -3557- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3560- MOVE MOVDEBCE-COD-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3563- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3565- MOVE SPACES TO WS-IDTCLIEMP-LOT. */
            _.Move("", WS_IDTCLIEMP_LOT);

            /*" -3567- MOVE LOTERI01-COD-LOT-FENAL TO WS-CODFENAL. */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL, FILLER_37.WS_CODFENAL);

            /*" -3569- MOVE MOVDEBCE-NUM-PARCELA TO WS-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, FILLER_37.WS_NRPARCEL);

            /*" -3571- MOVE MOVDEBCE-NUM-APOLICE TO WS-NUMAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, FILLER_37.WS_NUMAPOL);

            /*" -3574- MOVE WS-IDTCLIEMP-LOT TO MOVCC-IDTCLIEMP. */
            _.Move(WS_IDTCLIEMP_LOT, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -3576- MOVE SPACES TO WS-USOEMPR-LOT. */
            _.Move("", WS_USOEMPR_LOT);

            /*" -3578- MOVE MOVDEBCE-NSAS TO WS-LOT-NSA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_52.WS_LOT_NSA);

            /*" -3580- MOVE ZEROS TO WS-LOT-NSL. */
            _.Move(0, FILLER_52.WS_LOT_NSL);

            /*" -3582- MOVE MOVDEBCE-NUM-REQUISICAO TO WS-LOT-NUMLAC. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, FILLER_52.WS_LOT_NUMLAC);

            /*" -3584- MOVE APOLICES-COD-PRODUTO TO WS-LOT-CODPRODU. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO, FILLER_52.WS_LOT_CODPRODU);

            /*" -3586- MOVE MOVDEBCE-NUM-ENDOSSO TO WS-LOT-NRENDOS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, FILLER_52.WS_LOT_NRENDOS);

            /*" -3588- MOVE 001 TO WS-LOT-CODCOBER. */
            _.Move(001, FILLER_52.WS_LOT_CODCOBER);

            /*" -3590- MOVE ZEROS TO WS-LOT-NUMFATUR. */
            _.Move(0, FILLER_52.WS_LOT_NUMFATUR);

            /*" -3592- MOVE MOVDEBCE-DATA-VENCIMENTO TO WS-LOT-DATADEB. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, FILLER_52.WS_LOT_DATADEB);

            /*" -3594- MOVE MOVDEBCE-STATUS-CARTAO TO WS-LOT-TPREG. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO, FILLER_52.WS_LOT_TPREG);

            /*" -3597- MOVE WS-USOEMPR-LOT TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPR_LOT, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3597- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-TRATA-BILHETE-SECTION */
        private void R0700_00_TRATA_BILHETE_SECTION()
        {
            /*" -3611- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3613- ADD 1 TO TT-BILHETE. */
            W.TT_BILHETE.Value = W.TT_BILHETE + 1;

            /*" -3614- IF WS-IDLG-BIL-ESP EQUAL SPACES */

            if (FILLER_20.WS_IDLG_BIL_ESP.IsEmpty())
            {

                /*" -3616- MOVE WS-IDLG-BIL-CON TO MOVDEBCE-COD-CONVENIO */
                _.Move(FILLER_20.WS_IDLG_BIL_CON, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -3618- MOVE WS-IDLG-BIL-NSA TO MOVDEBCE-NSAS */
                _.Move(FILLER_20.WS_IDLG_BIL_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                /*" -3620- MOVE WS-IDLG-BIL-BIL TO MOVDEBCE-NUM-APOLICE */
                _.Move(FILLER_20.WS_IDLG_BIL_BIL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

                /*" -3622- MOVE ZEROS TO MOVDEBCE-NUM-ENDOSSO */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                /*" -3624- MOVE ZEROS TO MOVDEBCE-NUM-PARCELA */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

                /*" -3625- ELSE */
            }
            else
            {


                /*" -3627- MOVE WS-IDLG-DEM-CON TO MOVDEBCE-COD-CONVENIO */
                _.Move(FILLER_21.WS_IDLG_DEM_CON, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -3629- MOVE WS-IDLG-DEM-NSA TO MOVDEBCE-NSAS */
                _.Move(FILLER_21.WS_IDLG_DEM_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

                /*" -3631- MOVE WS-IDLG-DEM-APO TO MOVDEBCE-NUM-APOLICE */
                _.Move(FILLER_21.WS_IDLG_DEM_APO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

                /*" -3633- MOVE WS-IDLG-DEM-END TO MOVDEBCE-NUM-ENDOSSO */
                _.Move(FILLER_21.WS_IDLG_DEM_END, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

                /*" -3636- MOVE WS-IDLG-DEM-PAR TO MOVDEBCE-NUM-PARCELA. */
                _.Move(FILLER_21.WS_IDLG_DEM_PAR, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
            }


            /*" -3639- MOVE 6114 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(6114, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3641- PERFORM R2200-00-SELECT-MOVDEBCC. */

            R2200_00_SELECT_MOVDEBCC_SECTION();

            /*" -3642- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3643- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3644- GO TO R0700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                return;

                /*" -3646- END-IF. */
            }


            /*" -3648- PERFORM R2250-00-SELECT-APOLICES. */

            R2250_00_SELECT_APOLICES_SECTION();

            /*" -3651- MOVE 600114 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(600114, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3654- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3657- MOVE MOVDEBCE-COD-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3660- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3662- MOVE SPACES TO WS-USOEMPR-BIL. */
            _.Move("", WS_USOEMPR_BIL);

            /*" -3664- MOVE MOVDEBCE-COD-CONVENIO TO WS-BIL-CODCONV. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, FILLER_48.WS_BIL_CODCONV);

            /*" -3666- MOVE MOVDEBCE-NSAS TO WS-BIL-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_48.WS_BIL_NSAS);

            /*" -3668- MOVE MOVDEBCE-NUM-REQUISICAO TO WS-BIL-NUMREQ. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, FILLER_48.WS_BIL_NUMREQ);

            /*" -3671- MOVE WS-USOEMPR-BIL TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPR_BIL, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3675- MOVE SPACES TO WS-IDTCLIEMP-BI1 WS-IDTCLIEMP-BI2. */
            _.Move("", WS_IDTCLIEMP_BI1, WS_IDTCLIEMP_BI2);

            /*" -3676- IF WS-TEM-BILHETE EQUAL 'S' */

            if (W.WS_TEM_BILHETE == "S")
            {

                /*" -3678- MOVE MOVDEBCE-NUM-APOLICE TO WS-BI1-NRAPOL */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, FILLER_39.WS_BI1_NRAPOL);

                /*" -3680- MOVE MOVDEBCE-NUM-ENDOSSO TO WS-BI1-NRENDO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, FILLER_39.WS_BI1_NRENDO);

                /*" -3682- MOVE MOVDEBCE-NUM-PARCELA TO WS-BI1-NRPARC */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, FILLER_39.WS_BI1_NRPARC);

                /*" -3684- MOVE WS-IDTCLIEMP-BI1 TO MOVCC-IDTCLIEMP */
                _.Move(WS_IDTCLIEMP_BI1, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

                /*" -3685- ELSE */
            }
            else
            {


                /*" -3687- MOVE MOVDEBCE-NUM-APOLICE TO WS-BI2-NUMBIL */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, FILLER_41.WS_BI2_NUMBIL);

                /*" -3691- MOVE WS-IDTCLIEMP-BI2 TO MOVCC-IDTCLIEMP. */
                _.Move(WS_IDTCLIEMP_BI2, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);
            }


            /*" -3691- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-TRATA-AUTO-SECTION */
        private void R0800_00_TRATA_AUTO_SECTION()
        {
            /*" -3705- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3707- ADD 1 TO TT-AUTO. */
            W.TT_AUTO.Value = W.TT_AUTO + 1;

            /*" -3710- MOVE WS-IDLG-DEM-CON TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_21.WS_IDLG_DEM_CON, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3713- MOVE WS-IDLG-DEM-NSA TO MOVDEBCE-NSAS. */
            _.Move(FILLER_21.WS_IDLG_DEM_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3716- MOVE WS-IDLG-DEM-APO TO MOVDEBCE-NUM-APOLICE. */
            _.Move(FILLER_21.WS_IDLG_DEM_APO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -3719- MOVE WS-IDLG-DEM-END TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(FILLER_21.WS_IDLG_DEM_END, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3722- MOVE WS-IDLG-DEM-PAR TO MOVDEBCE-NUM-PARCELA. */
            _.Move(FILLER_21.WS_IDLG_DEM_PAR, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -3724- PERFORM R2200-00-SELECT-MOVDEBCC. */

            R2200_00_SELECT_MOVDEBCC_SECTION();

            /*" -3725- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3726- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3727- GO TO R0800-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/ //GOTO
                return;

                /*" -3729- END-IF. */
            }


            /*" -3732- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3735- MOVE MOVDEBCE-COD-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3738- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3740- MOVE SPACES TO WS-IDTCLIEMP-BI1. */
            _.Move("", WS_IDTCLIEMP_BI1);

            /*" -3742- MOVE MOVDEBCE-NUM-APOLICE TO WS-BI1-NRAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, FILLER_39.WS_BI1_NRAPOL);

            /*" -3744- MOVE MOVDEBCE-NUM-ENDOSSO TO WS-BI1-NRENDO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, FILLER_39.WS_BI1_NRENDO);

            /*" -3746- MOVE MOVDEBCE-NUM-PARCELA TO WS-BI1-NRPARC. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, FILLER_39.WS_BI1_NRPARC);

            /*" -3749- MOVE WS-IDTCLIEMP-BI1 TO MOVCC-IDTCLIEMP. */
            _.Move(WS_IDTCLIEMP_BI1, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -3751- MOVE SPACES TO WS-USOEMPR-BIL. */
            _.Move("", WS_USOEMPR_BIL);

            /*" -3753- MOVE MOVDEBCE-COD-CONVENIO TO WS-BIL-CODCONV. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, FILLER_48.WS_BIL_CODCONV);

            /*" -3755- MOVE MOVDEBCE-NSAS TO WS-BIL-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_48.WS_BIL_NSAS);

            /*" -3757- MOVE ZEROS TO WS-BIL-NUMREQ. */
            _.Move(0, FILLER_48.WS_BIL_NUMREQ);

            /*" -3760- MOVE WS-USOEMPR-BIL TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPR_BIL, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3760- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-TRATA-RED-CHQ-SECTION */
        private void R0900_00_TRATA_RED_CHQ_SECTION()
        {
            /*" -3775- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3777- ADD 1 TO TT-REDCHQ. */
            W.TT_REDCHQ.Value = W.TT_REDCHQ + 1;

            /*" -3780- MOVE WS-IDLG-DEM-CON TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_21.WS_IDLG_DEM_CON, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -3783- MOVE WS-IDLG-DEM-NSA TO MOVDEBCE-NSAS. */
            _.Move(FILLER_21.WS_IDLG_DEM_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -3786- MOVE WS-IDLG-DEM-APO TO MOVDEBCE-NUM-APOLICE. */
            _.Move(FILLER_21.WS_IDLG_DEM_APO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -3789- MOVE WS-IDLG-DEM-END TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(FILLER_21.WS_IDLG_DEM_END, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -3792- MOVE WS-IDLG-DEM-PAR TO MOVDEBCE-NUM-PARCELA. */
            _.Move(FILLER_21.WS_IDLG_DEM_PAR, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -3794- PERFORM R2200-00-SELECT-MOVDEBCC. */

            R2200_00_SELECT_MOVDEBCC_SECTION();

            /*" -3795- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -3796- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -3797- GO TO R0900-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/ //GOTO
                return;

                /*" -3799- END-IF. */
            }


            /*" -3802- MOVE 104 TO MOVCC-CODBANCO. */
            _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

            /*" -3805- MOVE MOVDEBCE-COD-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

            /*" -3808- MOVE MOVDEBCE-NSAS TO MOVCC-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, MOVCC_REGISTRO.MOVCC_NSAS);

            /*" -3810- MOVE SPACES TO WS-IDTCLIEMP-RED. */
            _.Move("", WS_IDTCLIEMP_RED);

            /*" -3812- MOVE MOVDEBCE-NUM-APOLICE TO WS-RED-NRAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, FILLER_38.WS_RED_NRAPOL);

            /*" -3814- MOVE MOVDEBCE-NUM-ENDOSSO TO WS-RED-NRENDO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, FILLER_38.WS_RED_NRENDO);

            /*" -3816- MOVE MOVDEBCE-NUM-PARCELA TO WS-RED-NRPARC. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, FILLER_38.WS_RED_NRPARC);

            /*" -3819- MOVE WS-IDTCLIEMP-RED TO MOVCC-IDTCLIEMP. */
            _.Move(WS_IDTCLIEMP_RED, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -3821- MOVE SPACES TO WS-USOEMPR-CHQ. */
            _.Move("", WS_USOEMPR_CHQ);

            /*" -3823- MOVE MOVDEBCE-COD-CONVENIO TO WS-CHQ-CODCONV. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, FILLER_50.WS_CHQ_CODCONV);

            /*" -3825- MOVE MOVDEBCE-NSAS TO WS-CHQ-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, FILLER_50.WS_CHQ_NSAS);

            /*" -3828- MOVE ZEROS TO WS-CHQ-NUMREQ WS-CHQ-CODPROD. */
            _.Move(0, FILLER_50.WS_CHQ_NUMREQ);
            _.Move(0, FILLER_50.WS_CHQ_CODPROD);


            /*" -3830- MOVE MOVDEBCE-NUM-REQUISICAO TO WS-CHQ-OCMOVTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, FILLER_50.WS_CHQ_OCMOVTO);

            /*" -3833- MOVE WS-USOEMPR-CHQ TO MOVCC-USOEMPRESA. */
            _.Move(WS_USOEMPR_CHQ, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -3833- PERFORM R1000-00-GRAVA-SICOV. */

            R1000_00_GRAVA_SICOV_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-GRAVA-SICOV-SECTION */
        private void R1000_00_GRAVA_SICOV_SECTION()
        {
            /*" -3847- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -3855- MOVE DET-NSA-BCO TO MOVCC-NSAC. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, MOVCC_REGISTRO.MOVCC_NSAC);

            /*" -3856- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -3858- MOVE 2 TO MOVCC-CODMOV */
                _.Move(2, MOVCC_REGISTRO.MOVCC_CODMOV);

                /*" -3860- MOVE ZEROS TO MOVCC-CONVENIO-SAP */
                _.Move(0, MOVCC_REGISTRO.MOVCC_CONVENIO_SAP);

                /*" -3862- MOVE DET1-VLR-BRUTO TO MOVCC-VLDEBCRE */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_BRUTO, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

                /*" -3863- MOVE DET1-DT-MOVTO TO WS-DATA-SAP */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_MOVTO, WS_DATA_SAP);

                /*" -3866- MOVE WS-DD-SAP TO MOVCC-DIA-HEADER MOVCC-DIA */
                _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_DIA_HEADER, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIA);

                /*" -3869- MOVE WS-MM-SAP TO MOVCC-MES-HEADER MOVCC-MES */
                _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_MES_HEADER, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MES);

                /*" -3872- MOVE WS-AA-SAP TO MOVCC-ANO-HEADER MOVCC-ANO */
                _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_ANO_HEADER, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANO);

                /*" -3874- MOVE MOVDEBCE-COD-AGENCIA-DEB TO MOVCC-AGECONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_AGECONTA);

                /*" -3876- MOVE MOVDEBCE-OPER-CONTA-DEB TO MOVCC-OPECONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

                /*" -3878- MOVE MOVDEBCE-NUM-CONTA-DEB TO MOVCC-NUMCONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

                /*" -3880- MOVE MOVDEBCE-DIG-CONTA-DEB TO MOVCC-DIGCONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_DIGCONTA);

                /*" -3881- MOVE DET1-OCORRENCIA TO WS-OCORR */
                _.Move(DET_REGISTRO.DET_REG1.DET1_OCORRENCIA, WS_OCORR);

                /*" -3882- PERFORM R1050-00-TRATA-RETORNO */

                R1050_00_TRATA_RETORNO_SECTION();

                /*" -3886- ELSE */
            }
            else
            {


                /*" -3887- IF DET-TIPREG EQUAL 02 */

                if (DET_REGISTRO.DET_TIPREG == 02)
                {

                    /*" -3889- MOVE ZEROS TO MOVCC-CODMOV */
                    _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOV);

                    /*" -3891- MOVE DET2-COD-CONV TO MOVCC-CONVENIO-SAP */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_COD_CONV, MOVCC_REGISTRO.MOVCC_CONVENIO_SAP);

                    /*" -3893- MOVE DET2-VLR-EFET TO MOVCC-VLDEBCRE */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_VLR_EFET, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

                    /*" -3894- MOVE DET2-DT-MOVTO TO WS-DATA-SAP */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_DT_MOVTO, WS_DATA_SAP);

                    /*" -3896- MOVE WS-DD-SAP TO MOVCC-DIA-HEADER */
                    _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_DIA_HEADER);

                    /*" -3898- MOVE WS-MM-SAP TO MOVCC-MES-HEADER */
                    _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_MES_HEADER);

                    /*" -3900- MOVE WS-AA-SAP TO MOVCC-ANO-HEADER */
                    _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_ANO_HEADER);

                    /*" -3901- MOVE DET2-DT-EFETIV TO WS-DATA-SAP */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_DT_EFETIV, WS_DATA_SAP);

                    /*" -3903- MOVE WS-DD-SAP TO MOVCC-DIA */
                    _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIA);

                    /*" -3905- MOVE WS-MM-SAP TO MOVCC-MES */
                    _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MES);

                    /*" -3907- MOVE WS-AA-SAP TO MOVCC-ANO */
                    _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANO);

                    /*" -3908- MOVE DET2-OCORRENCIA TO WS-OCORR */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_OCORRENCIA, WS_OCORR);

                    /*" -3909- PERFORM R1050-00-TRATA-RETORNO */

                    R1050_00_TRATA_RETORNO_SECTION();

                    /*" -3915- MOVE DET2-COD-AGE TO MOVCC-AGECONTA */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_COD_AGE, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_AGECONTA);

                    /*" -3919- IF DET2-CONTA-TESTE >= 400000000 AND DET2-CONTA-TESTE < 700000000 */

                    if (DET_REGISTRO.DET_REG2.DET2_TESTE.DET2_CONTA_TESTE >= 400000000 && DET_REGISTRO.DET_REG2.DET2_TESTE.DET2_CONTA_TESTE < 700000000)
                    {

                        /*" -3921- MOVE ZEROS TO MOVCC-OPECONTA */
                        _.Move(0, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

                        /*" -3923- MOVE DET2-NSGD TO MOVCC-NUMCONTA */
                        _.Move(DET_REGISTRO.DET_REG2.DET2_NSGD, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

                        /*" -3924- ELSE */
                    }
                    else
                    {


                        /*" -3926- MOVE DET2-TIP-CONTA TO MOVCC-OPECONTA */
                        _.Move(DET_REGISTRO.DET_REG2.DET2_OPCONTA.DET2_TIP_CONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

                        /*" -3928- MOVE DET2-NRO-CONTA TO MOVCC-NUMCONTA */
                        _.Move(DET_REGISTRO.DET_REG2.DET2_OPCONTA.DET2_NRO_CONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

                        /*" -3929- END-IF */
                    }


                    /*" -3931- MOVE DET2-DV-CTA TO MOVCC-DIGCONTA */
                    _.Move(DET_REGISTRO.DET_REG2.DET2_DV_CTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_DIGCONTA);

                    /*" -3935- ELSE */
                }
                else
                {


                    /*" -3936- IF DET-TIPREG EQUAL 04 */

                    if (DET_REGISTRO.DET_TIPREG == 04)
                    {

                        /*" -3938- MOVE DET4-COD-MOVTO TO MOVCC-CODMOV */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_COD_MOVTO, MOVCC_REGISTRO.MOVCC_CODMOV);

                        /*" -3940- MOVE DET4-COD-CONV TO MOVCC-CONVENIO-SAP */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_COD_CONV, MOVCC_REGISTRO.MOVCC_CONVENIO_SAP);

                        /*" -3942- MOVE DET4-VLR-ORIGINAL TO MOVCC-VLDEBCRE */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_VLR_ORIGINAL, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

                        /*" -3943- MOVE DET4-DT-GERACAO TO WS-DATA-SAP */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_DT_GERACAO, WS_DATA_SAP);

                        /*" -3945- MOVE WS-DD-SAP TO MOVCC-DIA-HEADER */
                        _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_DIA_HEADER);

                        /*" -3947- MOVE WS-MM-SAP TO MOVCC-MES-HEADER */
                        _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_MES_HEADER);

                        /*" -3949- MOVE WS-AA-SAP TO MOVCC-ANO-HEADER */
                        _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_ANO_HEADER);

                        /*" -3950- MOVE DET4-DT-DEBITO TO WS-DATA-SAP */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_DT_DEBITO, WS_DATA_SAP);

                        /*" -3952- MOVE WS-DD-SAP TO MOVCC-DIA */
                        _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIA);

                        /*" -3954- MOVE WS-MM-SAP TO MOVCC-MES */
                        _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MES);

                        /*" -3956- MOVE WS-AA-SAP TO MOVCC-ANO */
                        _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANO);

                        /*" -3958- MOVE DET4-COD-RETORNO TO MOVCC-RETORNO */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_COD_RETORNO, MOVCC_REGISTRO.MOVCC_RETORNO);

                        /*" -3964- MOVE DET4-COD-AGE TO MOVCC-AGECONTA */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_COD_AGE, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_AGECONTA);

                        /*" -3968- IF DET4-CONTA-TESTE >= 400000000 AND DET4-CONTA-TESTE < 700000000 */

                        if (DET_REGISTRO.DET_REG4.DET4_TESTE.DET4_CONTA_TESTE >= 400000000 && DET_REGISTRO.DET_REG4.DET4_TESTE.DET4_CONTA_TESTE < 700000000)
                        {

                            /*" -3970- MOVE ZEROS TO MOVCC-OPECONTA */
                            _.Move(0, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

                            /*" -3972- MOVE DET4-NSGD TO MOVCC-NUMCONTA */
                            _.Move(DET_REGISTRO.DET_REG4.DET4_NSGD, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

                            /*" -3973- ELSE */
                        }
                        else
                        {


                            /*" -3975- MOVE DET4-TIP-CONTA TO MOVCC-OPECONTA */
                            _.Move(DET_REGISTRO.DET_REG4.DET4_OPCONTA.DET4_TIP_CONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

                            /*" -3977- MOVE DET4-NRO-CONTA TO MOVCC-NUMCONTA */
                            _.Move(DET_REGISTRO.DET_REG4.DET4_OPCONTA.DET4_NRO_CONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

                            /*" -3978- END-IF */
                        }


                        /*" -3980- MOVE DET4-DV-CONTA TO MOVCC-DIGCONTA */
                        _.Move(DET_REGISTRO.DET_REG4.DET4_DV_CONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_DIGCONTA);

                        /*" -3984- ELSE */
                    }
                    else
                    {


                        /*" -3985- IF DET-TIPREG EQUAL 16 */

                        if (DET_REGISTRO.DET_TIPREG == 16)
                        {

                            /*" -3987- MOVE ZEROS TO MOVCC-CODMOV */
                            _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOV);

                            /*" -3989- MOVE DET16-COD-CONV TO MOVCC-CONVENIO-SAP */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_COD_CONV, MOVCC_REGISTRO.MOVCC_CONVENIO_SAP);

                            /*" -3991- MOVE DET16-VLR-DEBITO TO MOVCC-VLDEBCRE */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_VLR_DEBITO, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

                            /*" -3992- MOVE DET16-DT-MOVTO TO WS-DATA-SAP */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_DT_MOVTO, WS_DATA_SAP);

                            /*" -3994- MOVE WS-DD-SAP TO MOVCC-DIA-HEADER */
                            _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_DIA_HEADER);

                            /*" -3996- MOVE WS-MM-SAP TO MOVCC-MES-HEADER */
                            _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_MES_HEADER);

                            /*" -3998- MOVE WS-AA-SAP TO MOVCC-ANO-HEADER */
                            _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTGERACAO.MOVCC_ANO_HEADER);

                            /*" -3999- MOVE DET16-DT-DEBITO TO WS-DATA-SAP */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_DT_DEBITO, WS_DATA_SAP);

                            /*" -4001- MOVE WS-DD-SAP TO MOVCC-DIA */
                            _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIA);

                            /*" -4003- MOVE WS-MM-SAP TO MOVCC-MES */
                            _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MES);

                            /*" -4005- MOVE WS-AA-SAP TO MOVCC-ANO */
                            _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANO);

                            /*" -4006- MOVE DET16-COD-RETORNO TO WS-OCORR */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_COD_RETORNO, WS_OCORR);

                            /*" -4007- PERFORM R1060-00-TRATA-RET-SIACC-150 */

                            R1060_00_TRATA_RET_SIACC_150_SECTION();

                            /*" -4009- MOVE DET16-COD-AGE TO MOVCC-AGECONTA */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_COD_AGE, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_AGECONTA);

                            /*" -4011- MOVE DET16-OPE-CTA TO MOVCC-OPECONTA */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_OPE_CTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

                            /*" -4013- MOVE DET16-NRO-CONTA TO MOVCC-NUMCONTA */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_NRO_CONTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

                            /*" -4015- MOVE DET16-DV-CTA TO MOVCC-DIGCONTA */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_DV_CTA, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_DIGCONTA);

                            /*" -4017- MOVE DET16-PROC-ADVERT TO MOVCC-PROCE-ADVERT */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_PROC_ADVERT, MOVCC_REGISTRO.MOVCC_PROCE_ADVERT);

                            /*" -4019- MOVE DET16-NIVE-ADVERT TO MOVCC-NIVEL-ADVERT */
                            _.Move(DET_REGISTRO.DET_REG16.DET16_NIVE_ADVERT, MOVCC_REGISTRO.MOVCC_NIVEL_ADVERT);

                            /*" -4021- MOVE DET-AUGRD TO MOVCC-MOTIV-COMPEN */
                            _.Move(DET_REGISTRO.DET_AUGRD, MOVCC_REGISTRO.MOVCC_MOTIV_COMPEN);

                            /*" -4022- ELSE */
                        }
                        else
                        {


                            /*" -4023- ADD 1 TO DP-TIPOREG */
                            W.DP_TIPOREG.Value = W.DP_TIPOREG + 1;

                            /*" -4026- GO TO R1000-99-SAIDA. */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/ //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -4028- WRITE REG-SAIDA1 FROM MOVCC-REGISTRO. */
            _.Move(MOVCC_REGISTRO.GetMoveValues(), REG_SAIDA1);

            SAIDA1.Write(REG_SAIDA1.GetMoveValues().ToString());

            /*" -4031- ADD 1 TO AC-GRAV-SAIDA1. */
            W.AC_GRAV_SAIDA1.Value = W.AC_GRAV_SAIDA1 + 1;

            /*" -4036- IF WS-IDLG-CONV EQUAL 608800 OR 609000 OR 613100 OR 613200 OR 001313 */

            if (FILLER_16.WS_IDLG_CONV.In("608800", "609000", "613100", "613200", "001313"))
            {

                /*" -4038- PERFORM R1100-00-UPDATE-V0MOVDEBCE. */

                R1100_00_UPDATE_V0MOVDEBCE_SECTION();
            }


            /*" -4039- IF WS-MOVCC-CONVENIO EQUAL 609500 */

            if (W.WS_MOVCC_CONVENIO == 609500)
            {

                /*" -4039- PERFORM R1110-00-UPDATE-V0MOVDEBCE. */

                R1110_00_UPDATE_V0MOVDEBCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-TRATA-RETORNO-SECTION */
        private void R1050_00_TRATA_RETORNO_SECTION()
        {
            /*" -4052- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4054- IF WS-OCORR1 EQUAL '00' OR '01' */

            if (FILLER_28.WS_OCORR1.In("00", "01"))
            {

                /*" -4056- MOVE WS-OCORR1 TO MOVCC-RETORNO */
                _.Move(FILLER_28.WS_OCORR1, MOVCC_REGISTRO.MOVCC_RETORNO);

                /*" -4057- ELSE */
            }
            else
            {


                /*" -4058- IF WS-OCORR1 EQUAL '02' */

                if (FILLER_28.WS_OCORR1 == "02")
                {

                    /*" -4060- MOVE '99' TO MOVCC-RETORNO */
                    _.Move("99", MOVCC_REGISTRO.MOVCC_RETORNO);

                    /*" -4061- ELSE */
                }
                else
                {


                    /*" -4063- IF WS-OCORR1 EQUAL 'AG' OR 'AM' */

                    if (FILLER_28.WS_OCORR1.In("AG", "AM"))
                    {

                        /*" -4065- MOVE '14' TO MOVCC-RETORNO */
                        _.Move("14", MOVCC_REGISTRO.MOVCC_RETORNO);

                        /*" -4066- ELSE */
                    }
                    else
                    {


                        /*" -4067- IF WS-OCORR1 EQUAL 'AN' OR 'ZA' */

                        if (FILLER_28.WS_OCORR1.In("AN", "ZA"))
                        {

                            /*" -4069- MOVE '02' TO MOVCC-RETORNO */
                            _.Move("02", MOVCC_REGISTRO.MOVCC_RETORNO);

                            /*" -4070- ELSE */
                        }
                        else
                        {


                            /*" -4071- IF WS-OCORR1 EQUAL 'AP' */

                            if (FILLER_28.WS_OCORR1 == "AP")
                            {

                                /*" -4073- MOVE '13' TO MOVCC-RETORNO */
                                _.Move("13", MOVCC_REGISTRO.MOVCC_RETORNO);

                                /*" -4074- ELSE */
                            }
                            else
                            {


                                /*" -4075- IF WS-OCORR1 EQUAL 'AR' */

                                if (FILLER_28.WS_OCORR1 == "AR")
                                {

                                    /*" -4077- MOVE '12' TO MOVCC-RETORNO */
                                    _.Move("12", MOVCC_REGISTRO.MOVCC_RETORNO);

                                    /*" -4078- ELSE */
                                }
                                else
                                {


                                    /*" -4082- MOVE '04' TO MOVCC-RETORNO. */
                                    _.Move("04", MOVCC_REGISTRO.MOVCC_RETORNO);
                                }

                            }

                        }

                    }

                }

            }


            /*" -4082- MOVE WS-OCORR TO MOVCC-RETSIACC. */
            _.Move(WS_OCORR, MOVCC_REGISTRO.MOVCC_RETSIACC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1060-00-TRATA-RET-SIACC-150-SECTION */
        private void R1060_00_TRATA_RET_SIACC_150_SECTION()
        {
            /*" -4096- MOVE '1060' TO WNR-EXEC-SQL. */
            _.Move("1060", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4097- IF WS-OCORR1 EQUAL '00' */

            if (FILLER_28.WS_OCORR1 == "00")
            {

                /*" -4099- MOVE WS-OCORR1 TO MOVCC-RETORNO */
                _.Move(FILLER_28.WS_OCORR1, MOVCC_REGISTRO.MOVCC_RETORNO);

                /*" -4100- ELSE */
            }
            else
            {


                /*" -4101- IF WS-OCORR1 EQUAL '05' */

                if (FILLER_28.WS_OCORR1 == "05")
                {

                    /*" -4103- MOVE '01' TO MOVCC-RETORNO */
                    _.Move("01", MOVCC_REGISTRO.MOVCC_RETORNO);

                    /*" -4104- ELSE */
                }
                else
                {


                    /*" -4105- IF WS-OCORR1 EQUAL '99' */

                    if (FILLER_28.WS_OCORR1 == "99")
                    {

                        /*" -4107- MOVE WS-OCORR1 TO MOVCC-RETORNO */
                        _.Move(FILLER_28.WS_OCORR1, MOVCC_REGISTRO.MOVCC_RETORNO);

                        /*" -4108- ELSE */
                    }
                    else
                    {


                        /*" -4111- IF WS-OCORR1 EQUAL '12' OR '53' OR '57' */

                        if (FILLER_28.WS_OCORR1.In("12", "53", "57"))
                        {

                            /*" -4113- MOVE '14' TO MOVCC-RETORNO */
                            _.Move("14", MOVCC_REGISTRO.MOVCC_RETORNO);

                            /*" -4114- ELSE */
                        }
                        else
                        {


                            /*" -4118- IF WS-OCORR1 EQUAL '60' OR '61' OR '81' OR '82' */

                            if (FILLER_28.WS_OCORR1.In("60", "61", "81", "82"))
                            {

                                /*" -4120- MOVE '02' TO MOVCC-RETORNO */
                                _.Move("02", MOVCC_REGISTRO.MOVCC_RETORNO);

                                /*" -4121- ELSE */
                            }
                            else
                            {


                                /*" -4128- IF WS-OCORR1 EQUAL '19' OR '34' OR '46' OR '67' OR '85' OR '89' OR '95' */

                                if (FILLER_28.WS_OCORR1.In("19", "34", "46", "67", "85", "89", "95"))
                                {

                                    /*" -4130- MOVE '13' TO MOVCC-RETORNO */
                                    _.Move("13", MOVCC_REGISTRO.MOVCC_RETORNO);

                                    /*" -4131- ELSE */
                                }
                                else
                                {


                                    /*" -4133- IF WS-OCORR1 EQUAL '22' OR '35' */

                                    if (FILLER_28.WS_OCORR1.In("22", "35"))
                                    {

                                        /*" -4135- MOVE '12' TO MOVCC-RETORNO */
                                        _.Move("12", MOVCC_REGISTRO.MOVCC_RETORNO);

                                        /*" -4136- ELSE */
                                    }
                                    else
                                    {


                                        /*" -4140- MOVE '04' TO MOVCC-RETORNO. */
                                        _.Move("04", MOVCC_REGISTRO.MOVCC_RETORNO);
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -4140- MOVE WS-OCORR TO MOVCC-RETSIACC. */
            _.Move(WS_OCORR, MOVCC_REGISTRO.MOVCC_RETSIACC);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R1100_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -4153- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4154- IF DET-AUGRD EQUAL LOW-VALUES OR HIGH-VALUES */

            if (DET_REGISTRO.DET_AUGRD.IsLowValues() || DET_REGISTRO.DET_AUGRD.IsHighValues)
            {

                /*" -4155- MOVE ZEROS TO DET-AUGRD */
                _.Move(0, DET_REGISTRO.DET_AUGRD);

                /*" -4157- END-IF */
            }


            /*" -4158- IF MOVCC-RETORNO EQUAL '00' */

            if (MOVCC_REGISTRO.MOVCC_RETORNO == "00")
            {

                /*" -4160- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                /*" -4162- MOVE '2' TO MOVDEBCE-SITUACAO-COBRANCA */
                _.Move("2", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                /*" -4163- ELSE */
            }
            else
            {


                /*" -4167- IF DET-TIPREG EQUAL 16 AND DET-AUGRD EQUAL 00 */

                if (DET_REGISTRO.DET_TIPREG == 16 && DET_REGISTRO.DET_AUGRD == 00)
                {

                    /*" -4168- MOVE MOVCC-CODRET TO MOVDEBCE-COD-RETORNO-CEF */
                    _.Move(MOVCC_REGISTRO.FILLER_87.MOVCC_CODRET, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                    /*" -4169- MOVE 'R' TO MOVDEBCE-SITUACAO-COBRANCA */
                    _.Move("R", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                    /*" -4170- ELSE */
                }
                else
                {


                    /*" -4172- MOVE MOVCC-CODRET TO MOVDEBCE-COD-RETORNO-CEF */
                    _.Move(MOVCC_REGISTRO.FILLER_87.MOVCC_CODRET, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                    /*" -4174- MOVE '3' TO MOVDEBCE-SITUACAO-COBRANCA */
                    _.Move("3", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                    /*" -4175- END-IF */
                }


                /*" -4177- END-IF */
            }


            /*" -4179- MOVE WHOST-DATA-EM TO MOVDEBCE-DATA-RETORNO. */
            _.Move(WHOST_DATA_EM, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -4181- MOVE ZEROS TO MOVDEBCE-SEQUENCIA. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);

            /*" -4184- MOVE 'EM8006B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("EM8006B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -4189- MOVE ZEROS TO VIND-DTRETORNO VIND-RETORNO VIND-USUARIO VIND-SEQUENCIA. */
            _.Move(0, VIND_DTRETORNO, VIND_RETORNO, VIND_USUARIO, VIND_SEQUENCIA);

            /*" -4209- PERFORM R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -4213- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4214- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -4215- DISPLAY 'EM8006B - PROBLEMAS 1100 UPDATE MOVDEBCE   ' */
                _.Display($"EM8006B - PROBLEMAS 1100 UPDATE MOVDEBCE   ");

                /*" -4216- DISPLAY 'NUM_APOLICE       = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -4217- DISPLAY 'NUM_ENDOSSO       = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -4218- DISPLAY 'NUM_PARCELA       = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -4219- DISPLAY 'COD_CONVENIO      = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD_CONVENIO      = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -4220- DISPLAY 'NSAS              = ' MOVDEBCE-NSAS */
                _.Display($"NSAS              = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -4221- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -4221- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -4209- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA , DATA_RETORNO = :MOVDEBCE-DATA-RETORNO:VIND-DTRETORNO , COD_RETORNO_CEF = :MOVDEBCE-COD-RETORNO-CEF:VIND-RETORNO , COD_USUARIO = :MOVDEBCE-COD-USUARIO:VIND-USUARIO , SEQUENCIA = :MOVDEBCE-SEQUENCIA:VIND-SEQUENCIA WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS END-EXEC. */

            var r1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_RETORNO = VIND_RETORNO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r1100_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R1110_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -4233- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4235- MOVE ZEROS TO WS-MOVCC-CONVENIO. */
            _.Move(0, W.WS_MOVCC_CONVENIO);

            /*" -4236- IF MOVCC-RETORNO EQUAL '00' */

            if (MOVCC_REGISTRO.MOVCC_RETORNO == "00")
            {

                /*" -4238- MOVE ZEROS TO MOVDEBCE-COD-RETORNO-CEF */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                /*" -4240- MOVE '2' TO MOVDEBCE-SITUACAO-COBRANCA */
                _.Move("2", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                /*" -4241- ELSE */
            }
            else
            {


                /*" -4243- MOVE MOVCC-CODRET TO MOVDEBCE-COD-RETORNO-CEF */
                _.Move(MOVCC_REGISTRO.FILLER_87.MOVCC_CODRET, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);

                /*" -4246- MOVE '3' TO MOVDEBCE-SITUACAO-COBRANCA. */
                _.Move("3", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
            }


            /*" -4248- MOVE WHOST-DATA-EM TO MOVDEBCE-DATA-RETORNO. */
            _.Move(WHOST_DATA_EM, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO);

            /*" -4250- MOVE ZEROS TO MOVDEBCE-SEQUENCIA. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA);

            /*" -4253- MOVE 'EM8006B' TO MOVDEBCE-COD-USUARIO. */
            _.Move("EM8006B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -4258- MOVE ZEROS TO VIND-DTRETORNO VIND-RETORNO VIND-USUARIO VIND-SEQUENCIA. */
            _.Move(0, VIND_DTRETORNO, VIND_RETORNO, VIND_USUARIO, VIND_SEQUENCIA);

            /*" -4278- PERFORM R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -4282- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4283- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -4284- DISPLAY 'EM8006B - PROBLEMAS 1110 UPDATE MOVDEBCE   ' */
                _.Display($"EM8006B - PROBLEMAS 1110 UPDATE MOVDEBCE   ");

                /*" -4285- DISPLAY 'NUM_APOLICE       = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM_APOLICE       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -4286- DISPLAY 'NUM_ENDOSSO       = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM_ENDOSSO       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -4287- DISPLAY 'NUM_PARCELA       = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM_PARCELA       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -4288- DISPLAY 'COD_CONVENIO      = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD_CONVENIO      = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -4289- DISPLAY 'NSAS              = ' MOVDEBCE-NSAS */
                _.Display($"NSAS              = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -4290- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -4290- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1110-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -4278- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA , DATA_RETORNO = :MOVDEBCE-DATA-RETORNO:VIND-DTRETORNO , COD_RETORNO_CEF = :MOVDEBCE-COD-RETORNO-CEF:VIND-RETORNO , COD_USUARIO = :MOVDEBCE-COD-USUARIO:VIND-USUARIO , SEQUENCIA = :MOVDEBCE-SEQUENCIA:VIND-SEQUENCIA WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS END-EXEC. */

            var r1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_RETORNO = VIND_RETORNO.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRETORNO = VIND_DTRETORNO.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                VIND_USUARIO = VIND_USUARIO.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUENCIA = VIND_SEQUENCIA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r1110_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-GRAVA-SIACC-SECTION */
        private void R1500_00_GRAVA_SIACC_SECTION()
        {
            /*" -4304- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4306- ADD 1 TO TT-SIACC. */
            W.TT_SIACC.Value = W.TT_SIACC + 1;

            /*" -4308- MOVE DET-NSA-BCO TO SIACC-NSA-BANCO. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_SIACC.SIACC_NSA_BANCO);

            /*" -4311- MOVE WS-EMP-ANT TO SIACC-ORIGEM-EMPRESA. */
            _.Move(W.WS_EMP_ANT, REG_SIACC.SIACC_ORIGEM_EMPRESA);

            /*" -4312- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -4314- MOVE DET1-CGCCPF TO SIACC-CPF-CNPJ */
                _.Move(DET_REGISTRO.DET_REG1.DET1_CGCCPF, REG_SIACC.SIACC_CPF_CNPJ);

                /*" -4316- MOVE DET1-EVENTO TO SIACC-EVENTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_EVENTO, REG_SIACC.SIACC_EVENTO);

                /*" -4318- MOVE DET1-VLR-BRUTO TO SIACC-VALOR-BRUTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_BRUTO, REG_SIACC.SIACC_VALOR_BRUTO);

                /*" -4320- MOVE DET1-VLR-IRRF TO SIACC-VALOR-IRRF */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_IRRF, REG_SIACC.SIACC_VALOR_IRRF);

                /*" -4322- MOVE DET1-VLR-ISS TO SIACC-VALOR-ISS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_ISS, REG_SIACC.SIACC_VALOR_ISS);

                /*" -4324- MOVE DET1-VLR-INSS TO SIACC-VALOR-INSS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_INSS, REG_SIACC.SIACC_VALOR_INSS);

                /*" -4326- MOVE DET1-VLR-COFINS TO SIACC-VALOR-COFINS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_COFINS, REG_SIACC.SIACC_VALOR_COFINS);

                /*" -4328- MOVE DET1-VLR-CSLL TO SIACC-VALOR-CSLL */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_CSLL, REG_SIACC.SIACC_VALOR_CSLL);

                /*" -4330- MOVE DET1-VLR-PIS TO SIACC-VALOR-PIS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_PIS, REG_SIACC.SIACC_VALOR_PIS);

                /*" -4332- MOVE DET1-VLR-PG-REC TO SIACC-VALOR-PAGTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_PG_REC, REG_SIACC.SIACC_VALOR_PAGTO);

                /*" -4334- MOVE DET1-DT-MOVTO TO SIACC-DATA-CREDITO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_MOVTO, REG_SIACC.SIACC_DATA_CREDITO);

                /*" -4336- MOVE DET1-DT-ENVIO TO SIACC-DATA-ENVIO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_ENVIO, REG_SIACC.SIACC_DATA_ENVIO);

                /*" -4338- MOVE DET1-DT-CONTABIL TO SIACC-DATA-CONTABIL */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_CONTABIL, REG_SIACC.SIACC_DATA_CONTABIL);

                /*" -4340- MOVE DET1-MEIO-PAGTO TO SIACC-MEIO-PAGTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_MEIO_PAGTO, REG_SIACC.SIACC_MEIO_PAGTO);

                /*" -4342- MOVE DET1-NRO-CHQ-INT TO SIACC-NUM-CHEQUE */
                _.Move(DET_REGISTRO.DET_REG1.DET1_NRO_CHQ_INT, REG_SIACC.SIACC_NUM_CHEQUE);

                /*" -4344- MOVE DET1-NRO-SIVAT TO SIACC-NUM-SIVAT */
                _.Move(DET_REGISTRO.DET_REG1.DET1_NRO_SIVAT, REG_SIACC.SIACC_NUM_SIVAT);

                /*" -4346- MOVE DET1-OCORRENCIA TO SIACC-OCORRENCIA */
                _.Move(DET_REGISTRO.DET_REG1.DET1_OCORRENCIA, REG_SIACC.SIACC_OCORRENCIA);

                /*" -4347- ELSE */
            }
            else
            {


                /*" -4348- ADD 1 TO DP-TIPOREG */
                W.DP_TIPOREG.Value = W.DP_TIPOREG + 1;

                /*" -4351- GO TO R1500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4353- WRITE REG-SAIDA7 FROM REG-SIACC. */
            _.Move(REG_SIACC.GetMoveValues(), REG_SAIDA7);

            SAIDA7.Write(REG_SAIDA7.GetMoveValues().ToString());

            /*" -4353- ADD 1 TO AC-GRAV-SAIDA7. */
            W.AC_GRAV_SAIDA7.Value = W.AC_GRAV_SAIDA7 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-MOVDEBCC-SECTION */
        private void R1900_00_SELECT_MOVDEBCC_SECTION()
        {
            /*" -4367- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4398- PERFORM R1900_00_SELECT_MOVDEBCC_DB_SELECT_1 */

            R1900_00_SELECT_MOVDEBCC_DB_SELECT_1();

            /*" -4402- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4403- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -4404- ELSE */
            }
            else
            {


                /*" -4405- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4406- DISPLAY 'R1900-00 - PROBLEMAS NO SELECT MOVDEBCE' */
                    _.Display($"R1900-00 - PROBLEMAS NO SELECT MOVDEBCE");

                    /*" -4407- DISPLAY 'COD_CONVENIO    = ' MOVDEBCE-COD-CONVENIO */
                    _.Display($"COD_CONVENIO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                    /*" -4408- MOVE MOVDEBCE-NSAS TO WNSAS-DISPLAY */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, W.WNSAS_DISPLAY);

                    /*" -4409- DISPLAY 'NSAS            = ' WNSAS-DISPLAY */
                    _.Display($"NSAS            = {W.WNSAS_DISPLAY}");

                    /*" -4410- DISPLAY 'NUM_ENDOSSO     = ' MOVDEBCE-NUM-ENDOSSO */
                    _.Display($"NUM_ENDOSSO     = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                    /*" -4410- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-MOVDEBCC-DB-SELECT-1 */
        public void R1900_00_SELECT_MOVDEBCC_DB_SELECT_1()
        {
            /*" -4398- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , VALUE(COD_AGENCIA_DEB, 0) , VALUE(OPER_CONTA_DEB, 0) , VALUE(NUM_CONTA_DEB, 0) , VALUE(DIG_CONTA_DEB, 0) , COD_CONVENIO , NSAS , VALUE(NUM_REQUISICAO, 0) , VALUE(NUM_CARTAO, 0) INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO , :MOVDEBCE-NUM-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA IN ( '1' , '6' , 'N' , 'E' , 'R' ) AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO WITH UR END-EXEC. */

            var r1900_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 = new R1900_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R1900_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-SELECT-MOVDEBCC-SECTION */
        private void R1910_00_SELECT_MOVDEBCC_SECTION()
        {
            /*" -4423- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4454- PERFORM R1910_00_SELECT_MOVDEBCC_DB_SELECT_1 */

            R1910_00_SELECT_MOVDEBCC_DB_SELECT_1();

            /*" -4458- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4459- DISPLAY 'R1910-00 - NAO CADASTRADO MOVDEBCE' */
                _.Display($"R1910-00 - NAO CADASTRADO MOVDEBCE");

                /*" -4460- DISPLAY ' IDLG: ' DET-IDLG */
                _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -4461- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -4462- ELSE */
            }
            else
            {


                /*" -4463- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4464- DISPLAY 'R1910-00 - PROBLEMAS NO SELECT MOVDEBCE' */
                    _.Display($"R1910-00 - PROBLEMAS NO SELECT MOVDEBCE");

                    /*" -4465- DISPLAY 'COD_CONVENIO    = ' MOVDEBCE-COD-CONVENIO */
                    _.Display($"COD_CONVENIO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                    /*" -4466- MOVE MOVDEBCE-NSAS TO WNSAS-DISPLAY */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, W.WNSAS_DISPLAY);

                    /*" -4467- DISPLAY 'NSAS            = ' WNSAS-DISPLAY */
                    _.Display($"NSAS            = {W.WNSAS_DISPLAY}");

                    /*" -4468- DISPLAY 'NUM_REUISICAO   = ' MOVDEBCE-NUM-REQUISICAO */
                    _.Display($"NUM_REUISICAO   = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                    /*" -4468- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1910-00-SELECT-MOVDEBCC-DB-SELECT-1 */
        public void R1910_00_SELECT_MOVDEBCC_DB_SELECT_1()
        {
            /*" -4454- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , VALUE(COD_AGENCIA_DEB, 0) , VALUE(OPER_CONTA_DEB, 0) , VALUE(NUM_CONTA_DEB, 0) , VALUE(DIG_CONTA_DEB, 0) , COD_CONVENIO , NSAS , VALUE(NUM_REQUISICAO, 0) , VALUE(NUM_CARTAO, 0) INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO , :MOVDEBCE-NUM-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA IN ( '1' , '6' , 'N' , 'E' ) AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO WITH UR END-EXEC. */

            var r1910_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 = new R1910_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R1910_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1.Execute(r1910_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R1920-00-SELECT-HISLANCT-SECTION */
        private void R1920_00_SELECT_HISLANCT_SECTION()
        {
            /*" -4482- MOVE '1920' TO WNR-EXEC-SQL. */
            _.Move("1920", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4492- PERFORM R1920_00_SELECT_HISLANCT_DB_SELECT_1 */

            R1920_00_SELECT_HISLANCT_DB_SELECT_1();

            /*" -4496- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4497- DISPLAY 'R1920-00 - NAO CADASTRADO HISLANCT' */
                _.Display($"R1920-00 - NAO CADASTRADO HISLANCT");

                /*" -4498- DISPLAY ' IDLG: ' DET-IDLG */
                _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -4499- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -4501- GO TO R1920-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1920_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4502- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4503- DISPLAY 'R1920-00 - PROBLEMAS NO SELECT HISLANCT' */
                _.Display($"R1920-00 - PROBLEMAS NO SELECT HISLANCT");

                /*" -4504- DISPLAY 'COD_CONVENIO    = ' HISLANCT-CODCONV */
                _.Display($"COD_CONVENIO    = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                /*" -4505- MOVE HISLANCT-NSAS TO WNSAS-DISPLAY */
                _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS, W.WNSAS_DISPLAY);

                /*" -4506- DISPLAY 'NSAS            = ' WNSAS-DISPLAY */
                _.Display($"NSAS            = {W.WNSAS_DISPLAY}");

                /*" -4507- DISPLAY 'NUM_CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM_CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -4508- DISPLAY 'NUM_PARCELA     = ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM_PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -4511- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4512- IF WS-NULL1 LESS ZEROS */

            if (WS_NULL1 < 00)
            {

                /*" -4513- DISPLAY 'R1920-00 - NSL NULA HISLANCT' */
                _.Display($"R1920-00 - NSL NULA HISLANCT");

                /*" -4514- DISPLAY ' IDLG: ' DET-IDLG */
                _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -4514- MOVE 'N' TO WTEM-REGISTRO. */
                _.Move("N", W.WTEM_REGISTRO);
            }


        }

        [StopWatch]
        /*" R1920-00-SELECT-HISLANCT-DB-SELECT-1 */
        public void R1920_00_SELECT_HISLANCT_DB_SELECT_1()
        {
            /*" -4492- EXEC SQL SELECT NSL INTO :HISLANCT-NSL:WS-NULL1 FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND CODCONV = :HISLANCT-CODCONV AND NSAS = :HISLANCT-NSAS FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1 = new R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1()
            {
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
                HISLANCT_CODCONV = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV.ToString(),
                HISLANCT_NSAS = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.ToString(),
            };

            var executed_1 = R1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1.Execute(r1920_00_SELECT_HISLANCT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISLANCT_NSL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL);
                _.Move(executed_1.WS_NULL1, WS_NULL1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1920_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-MOVDEBCC-SECTION */
        private void R2000_00_SELECT_MOVDEBCC_SECTION()
        {
            /*" -4527- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4558- PERFORM R2000_00_SELECT_MOVDEBCC_DB_SELECT_1 */

            R2000_00_SELECT_MOVDEBCC_DB_SELECT_1();

            /*" -4562- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4563- DISPLAY 'R2000-00 - NAO CADASTRADO MOVDEBCE' */
                _.Display($"R2000-00 - NAO CADASTRADO MOVDEBCE");

                /*" -4564- DISPLAY ' IDLG: ' DET-IDLG */
                _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -4565- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -4566- ELSE */
            }
            else
            {


                /*" -4567- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -4568- DISPLAY 'R2000-00 - PROBLEMAS NO SELECT MOVDEBCE' */
                    _.Display($"R2000-00 - PROBLEMAS NO SELECT MOVDEBCE");

                    /*" -4569- DISPLAY 'COD_CONVENIO    = ' MOVDEBCE-COD-CONVENIO */
                    _.Display($"COD_CONVENIO    = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                    /*" -4570- MOVE MOVDEBCE-NSAS TO WNSAS-DISPLAY */
                    _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, W.WNSAS_DISPLAY);

                    /*" -4571- DISPLAY 'NSAS            = ' WNSAS-DISPLAY */
                    _.Display($"NSAS            = {W.WNSAS_DISPLAY}");

                    /*" -4572- DISPLAY 'NUM_REQUISICAO  = ' MOVDEBCE-NUM-REQUISICAO */
                    _.Display($"NUM_REQUISICAO  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}");

                    /*" -4572- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2000-00-SELECT-MOVDEBCC-DB-SELECT-1 */
        public void R2000_00_SELECT_MOVDEBCC_DB_SELECT_1()
        {
            /*" -4558- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , VALUE(COD_AGENCIA_DEB, 0) , VALUE(OPER_CONTA_DEB, 0) , VALUE(NUM_CONTA_DEB, 0) , VALUE(DIG_CONTA_DEB, 0) , COD_CONVENIO , NSAS , VALUE(NUM_REQUISICAO, 0) , VALUE(NUM_CARTAO, 0) INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO , :MOVDEBCE-NUM-CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA = '5' AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO WITH UR END-EXEC. */

            var r2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 = new R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1.Execute(r2000_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-MOVDEBCC-SECTION */
        private void R2100_00_SELECT_MOVDEBCC_SECTION()
        {
            /*" -4585- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4586- IF MOVDEBCE-NUM-ENDOSSO = 0 AND MOVDEBCE-NUM-PARCELA = 1 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO == 0 && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA == 1)
            {

                /*" -4628- PERFORM R2100_00_SELECT_MOVDEBCC_DB_SELECT_1 */

                R2100_00_SELECT_MOVDEBCC_DB_SELECT_1();

                /*" -4630- ELSE */
            }
            else
            {


                /*" -4676- PERFORM R2100_00_SELECT_MOVDEBCC_DB_SELECT_2 */

                R2100_00_SELECT_MOVDEBCC_DB_SELECT_2();

                /*" -4679- END-IF */
            }


            /*" -4680- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4681- DISPLAY 'R2100-00 - NAO CADASTRADO MOVDEBCE (A)' */
                _.Display($"R2100-00 - NAO CADASTRADO MOVDEBCE (A)");

                /*" -4682- DISPLAY 'IDLG: ' DET-IDLG */
                _.Display($"IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -4683- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -4684- GO TO R2100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;

                /*" -4686- END-IF */
            }


            /*" -4687- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4688- DISPLAY 'R2100-00 - PROBLEMAS NO SELECT MOVDEBCE' */
                _.Display($"R2100-00 - PROBLEMAS NO SELECT MOVDEBCE");

                /*" -4689- DISPLAY 'A.COD_CONVENIO      = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"A.COD_CONVENIO      = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -4690- MOVE MOVDEBCE-NSAS TO WNSAS-DISPLAY */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, W.WNSAS_DISPLAY);

                /*" -4691- DISPLAY 'A.NSAS              = ' WNSAS-DISPLAY */
                _.Display($"A.NSAS              = {W.WNSAS_DISPLAY}");

                /*" -4692- DISPLAY 'A.NUM_APOLICE       = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"A.NUM_APOLICE       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -4693- DISPLAY 'A.NUM_ENDOSSO       = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"A.NUM_ENDOSSO       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -4694- DISPLAY 'A.NUM_PARCELA       = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"A.NUM_PARCELA       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -4695- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -4697- END-IF */
            }


            /*" -4699- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '1' NEXT SENTENCE */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "1")
            {

                /*" -4700- ELSE */
            }
            else
            {


                /*" -4701- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '6' */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "6")
                {

                    /*" -4702- PERFORM R2300-00-UPDATE-V0MOVDEBCE */

                    R2300_00_UPDATE_V0MOVDEBCE_SECTION();

                    /*" -4703- ELSE */
                }
                else
                {


                    /*" -4704- DISPLAY 'R2100-00 - NAO CADASTRADO MOVDEBCE (B)' */
                    _.Display($"R2100-00 - NAO CADASTRADO MOVDEBCE (B)");

                    /*" -4705- DISPLAY ' IDLG: ' DET-IDLG */
                    _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                    /*" -4706- MOVE 'N' TO WTEM-REGISTRO */
                    _.Move("N", W.WTEM_REGISTRO);

                    /*" -4707- END-IF */
                }


                /*" -4707- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-MOVDEBCC-DB-SELECT-1 */
        public void R2100_00_SELECT_MOVDEBCC_DB_SELECT_1()
        {
            /*" -4628- EXEC SQL SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.DATA_VENCIMENTO ,A.SITUACAO_COBRANCA ,VALUE(A.COD_AGENCIA_DEB, 0) ,VALUE(A.OPER_CONTA_DEB, 0) ,VALUE(A.NUM_CONTA_DEB, 0) ,VALUE(A.DIG_CONTA_DEB, 0) ,A.COD_CONVENIO ,A.NSAS ,VALUE(A.NUM_REQUISICAO, 0) ,VALUE(A.STATUS_CARTAO, '' ) ,B.COD_EXT_SEGURADO ,B.COD_PRODUTO INTO :MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-COD-AGENCIA-DEB ,:MOVDEBCE-OPER-CONTA-DEB ,:MOVDEBCE-NUM-CONTA-DEB ,:MOVDEBCE-DIG-CONTA-DEB ,:MOVDEBCE-COD-CONVENIO ,:MOVDEBCE-NSAS ,:MOVDEBCE-NUM-REQUISICAO ,:MOVDEBCE-STATUS-CARTAO ,:LOTERI01-COD-LOT-FENAL ,:APOLICES-COD-PRODUTO FROM SEGUROS.MOVTO_DEBITOCC_CEF A ,SEGUROS.LT_MOV_PROPOSTA B WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND A.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.NSAS = :MOVDEBCE-NSAS AND (A.NUM_APOLICE = B.NUM_TITULO OR A.NUM_APOLICE = B.NUM_APOLICE) FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r2100_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 = new R2100_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R2100_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.MOVDEBCE_STATUS_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);
                _.Move(executed_1.LOTERI01_COD_LOT_FENAL, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-MOVDEBCC-DB-SELECT-2 */
        public void R2100_00_SELECT_MOVDEBCC_DB_SELECT_2()
        {
            /*" -4676- EXEC SQL SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.DATA_VENCIMENTO ,A.SITUACAO_COBRANCA ,VALUE(A.COD_AGENCIA_DEB, 0) ,VALUE(A.OPER_CONTA_DEB, 0) ,VALUE(A.NUM_CONTA_DEB, 0) ,VALUE(A.DIG_CONTA_DEB, 0) ,A.COD_CONVENIO ,A.NSAS ,VALUE(A.NUM_REQUISICAO, 0) ,VALUE(A.STATUS_CARTAO, '' ) ,B.COD_LOT_FENAL ,C.COD_PRODUTO INTO :MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-COD-AGENCIA-DEB ,:MOVDEBCE-OPER-CONTA-DEB ,:MOVDEBCE-NUM-CONTA-DEB ,:MOVDEBCE-DIG-CONTA-DEB ,:MOVDEBCE-COD-CONVENIO ,:MOVDEBCE-NSAS ,:MOVDEBCE-NUM-REQUISICAO ,:MOVDEBCE-STATUS-CARTAO ,:LOTERI01-COD-LOT-FENAL ,:APOLICES-COD-PRODUTO FROM SEGUROS.MOVTO_DEBITOCC_CEF A ,SEGUROS.LOTERICO01 B ,SEGUROS.APOLICES C WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND A.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.NSAS = :MOVDEBCE-NSAS AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_APOLICE = C.NUM_APOLICE AND B.NUM_APOLICE = C.NUM_APOLICE ORDER BY B.DTINIVIG DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var r2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1 = new R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1.Execute(r2100_00_SELECT_MOVDEBCC_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.MOVDEBCE_STATUS_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO);
                _.Move(executed_1.LOTERI01_COD_LOT_FENAL, LOTERI01.DCLLOTERICO01.LOTERI01_COD_LOT_FENAL);
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-MOVDEBCC-SECTION */
        private void R2200_00_SELECT_MOVDEBCC_SECTION()
        {
            /*" -4719- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4751- PERFORM R2200_00_SELECT_MOVDEBCC_DB_SELECT_1 */

            R2200_00_SELECT_MOVDEBCC_DB_SELECT_1();

            /*" -4755- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4756- DISPLAY 'R2200-00 - NAO CADASTRADO MOVDEBCE' */
                _.Display($"R2200-00 - NAO CADASTRADO MOVDEBCE");

                /*" -4757- DISPLAY ' IDLG: ' DET-IDLG */
                _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -4758- MOVE 'N' TO WTEM-REGISTRO */
                _.Move("N", W.WTEM_REGISTRO);

                /*" -4761- GO TO R2200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4762- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4763- DISPLAY 'R2200-00 - PROBLEMAS NO SELECT MOVDEBCE' */
                _.Display($"R2200-00 - PROBLEMAS NO SELECT MOVDEBCE");

                /*" -4764- DISPLAY ' COD_CONVENIO         = ' MOVDEBCE-COD-CONVENIO */
                _.Display($" COD_CONVENIO         = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -4765- MOVE MOVDEBCE-NSAS TO WNSAS-DISPLAY */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, W.WNSAS_DISPLAY);

                /*" -4766- DISPLAY ' NSAS                 = ' WNSAS-DISPLAY */
                _.Display($" NSAS                 = {W.WNSAS_DISPLAY}");

                /*" -4767- DISPLAY ' NUM_APOLICE          = ' MOVDEBCE-NUM-APOLICE */
                _.Display($" NUM_APOLICE          = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -4768- DISPLAY ' NUM_ENDOSSO          = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($" NUM_ENDOSSO          = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -4769- DISPLAY ' NUM_PARCELA          = ' MOVDEBCE-NUM-PARCELA */
                _.Display($" NUM_PARCELA          = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -4772- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -4773- IF WS-NULL1 LESS ZEROS */

            if (WS_NULL1 < 00)
            {

                /*" -4776- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
            }


            /*" -4777- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '0' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "0")
            {

                /*" -4778- PERFORM R2300-00-UPDATE-V0MOVDEBCE */

                R2300_00_UPDATE_V0MOVDEBCE_SECTION();

                /*" -4779- ELSE */
            }
            else
            {


                /*" -4781- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '1' NEXT SENTENCE */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "1")
                {

                    /*" -4782- ELSE */
                }
                else
                {


                    /*" -4783- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '6' */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "6")
                    {

                        /*" -4784- PERFORM R2300-00-UPDATE-V0MOVDEBCE */

                        R2300_00_UPDATE_V0MOVDEBCE_SECTION();

                        /*" -4785- ELSE */
                    }
                    else
                    {


                        /*" -4786- DISPLAY 'R2200-00 - PROBLEMAS SITUACAO  MOVDEBCE' */
                        _.Display($"R2200-00 - PROBLEMAS SITUACAO  MOVDEBCE");

                        /*" -4787- DISPLAY ' IDLG: ' DET-IDLG */
                        _.Display($" IDLG: {DET_REGISTRO.DET_IDLG}");

                        /*" -4788- MOVE 'N' TO WTEM-REGISTRO */
                        _.Move("N", W.WTEM_REGISTRO);

                        /*" -4789- END-IF */
                    }


                    /*" -4790- END-IF */
                }


                /*" -4790- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-MOVDEBCC-DB-SELECT-1 */
        public void R2200_00_SELECT_MOVDEBCC_DB_SELECT_1()
        {
            /*" -4751- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , DATA_VENCIMENTO , SITUACAO_COBRANCA , VALUE(COD_AGENCIA_DEB, 0) , VALUE(OPER_CONTA_DEB, 0) , VALUE(NUM_CONTA_DEB, 0) , VALUE(DIG_CONTA_DEB, 0) , COD_CONVENIO , NSAS , VALUE(NUM_REQUISICAO, 0) INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO:WS-NULL1 FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS WITH UR END-EXEC. */

            var r2200_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1 = new R2200_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R2200_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_MOVDEBCC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.WS_NULL1, WS_NULL1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2250-00-SELECT-APOLICES-SECTION */
        private void R2250_00_SELECT_APOLICES_SECTION()
        {
            /*" -4803- MOVE '2250' TO WNR-EXEC-SQL. */
            _.Move("2250", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4811- PERFORM R2250_00_SELECT_APOLICES_DB_SELECT_1 */

            R2250_00_SELECT_APOLICES_DB_SELECT_1();

            /*" -4815- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4816- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4817- MOVE 'N' TO WS-TEM-BILHETE */
                    _.Move("N", W.WS_TEM_BILHETE);

                    /*" -4818- ELSE */
                }
                else
                {


                    /*" -4819- DISPLAY 'R2250-00 - PROBLEMAS NO SELECT APOLICES' */
                    _.Display($"R2250-00 - PROBLEMAS NO SELECT APOLICES");

                    /*" -4820- DISPLAY 'NUM_APOLICE       = ' MOVDEBCE-NUM-APOLICE */
                    _.Display($"NUM_APOLICE       = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                    /*" -4821- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -4822- ELSE */
                }

            }
            else
            {


                /*" -4822- MOVE 'S' TO WS-TEM-BILHETE. */
                _.Move("S", W.WS_TEM_BILHETE);
            }


        }

        [StopWatch]
        /*" R2250-00-SELECT-APOLICES-DB-SELECT-1 */
        public void R2250_00_SELECT_APOLICES_DB_SELECT_1()
        {
            /*" -4811- EXEC SQL SELECT COD_PRODUTO INTO :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE WITH UR END-EXEC. */

            var r2250_00_SELECT_APOLICES_DB_SELECT_1_Query1 = new R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1.Execute(r2250_00_SELECT_APOLICES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2250_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R2300_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -4836- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4847- PERFORM R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -4851- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -4852- DISPLAY 'R2300   - PROBLEMAS UPDATE MOVDEBCE   ' */
                _.Display($"R2300   - PROBLEMAS UPDATE MOVDEBCE   ");

                /*" -4852- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2300-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -4847- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = '1' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS END-EXEC. */

            var r2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r2300_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-TRATA-DET11-SECTION */
        private void R2400_00_TRATA_DET11_SECTION()
        {
            /*" -4866- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4867- ADD 1 TO TT-DET11. */
            W.TT_DET11.Value = W.TT_DET11 + 1;

            /*" -4869- MOVE SPACES TO REG-SICA11. */
            _.Move("", MOVCC_REGISTRO.REG_SICA11);

            /*" -4871- IF DET-BUKRS NOT EQUAL 'C000' AND NOT EQUAL 'C010' */

            if (!DET_REGISTRO.DET_BUKRS.In("C000", "C010"))
            {

                /*" -4872- ADD 1 TO DP-DET11 */
                W.DP_DET11.Value = W.DP_DET11 + 1;

                /*" -4877- GO TO R2400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4879- IF DET11-NRO-SIVPF GREATER 98000000000000 AND DET11-NRO-SIVPF LESS 98999999999999 */

            if (DET_REGISTRO.DET_REG11.DET11_USO_EMPRESA.DET11_NRO_SIVPF > 98000000000000 && DET_REGISTRO.DET_REG11.DET11_USO_EMPRESA.DET11_NRO_SIVPF < 98999999999999)
            {

                /*" -4880- PERFORM R2410-00-BACKSEG-ADESAO */

                R2410_00_BACKSEG_ADESAO_SECTION();

                /*" -4883- GO TO R2400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -4884- MOVE DET-TIPREG TO SICA11-TIPO-REGISTRO. */
            _.Move(DET_REGISTRO.DET_TIPREG, MOVCC_REGISTRO.REG_SICA11.SICA11_TIPO_REGISTRO);

            /*" -4885- MOVE DET-SEQREG TO SICA11-SEQ-REGISTRO. */
            _.Move(DET_REGISTRO.DET_SEQREG, MOVCC_REGISTRO.REG_SICA11.SICA11_SEQ_REGISTRO);

            /*" -4886- MOVE DET-IDLG TO SICA11-IDLG. */
            _.Move(DET_REGISTRO.DET_IDLG, MOVCC_REGISTRO.REG_SICA11.SICA11_IDLG);

            /*" -4887- MOVE DET-BUKRS TO SICA11-BUKRS. */
            _.Move(DET_REGISTRO.DET_BUKRS, MOVCC_REGISTRO.REG_SICA11.SICA11_BUKRS);

            /*" -4888- MOVE DET-NSA-BCO TO SICA11-NSA-BANCO. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, MOVCC_REGISTRO.REG_SICA11.SICA11_NSA_BANCO);

            /*" -4889- MOVE DET11-DT-GERACAO TO SICA11-DTGERACAO. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_DT_GERACAO, MOVCC_REGISTRO.REG_SICA11.SICA11_DTGERACAO);

            /*" -4890- MOVE DET11-USO-EMPRESA TO SICA11-USO-EMPRESA. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_USO_EMPRESA, MOVCC_REGISTRO.REG_SICA11.SICA11_USO_EMPRESA);

            /*" -4891- MOVE DET11-AGENCIA TO SICA11-AGENCIA. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_AGENCIA, MOVCC_REGISTRO.REG_SICA11.SICA11_AGENCIA);

            /*" -4892- MOVE DET11-OPERACAO TO SICA11-OPERACAO. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_OPERACAO, MOVCC_REGISTRO.REG_SICA11.SICA11_OPERACAO);

            /*" -4893- MOVE DET11-NRO-CONTA TO SICA11-NUM-CONTA. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_NRO_CONTA, MOVCC_REGISTRO.REG_SICA11.SICA11_NUM_CONTA);

            /*" -4894- MOVE DET11-DV-CONTA TO SICA11-DIG-CONTA. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_DV_CONTA, MOVCC_REGISTRO.REG_SICA11.SICA11_DIG_CONTA);

            /*" -4895- MOVE DET11-VLR-PAGO TO SICA11-VALOR-PAGO. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_VLR_PAGO, MOVCC_REGISTRO.REG_SICA11.SICA11_VALOR_PAGO);

            /*" -4896- MOVE DET11-VLR-TARIFA TO SICA11-VALOR-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_VLR_TARIFA, MOVCC_REGISTRO.REG_SICA11.SICA11_VALOR_TARIFA);

            /*" -4897- MOVE DET11-DT-PAGTO TO SICA11-DATA-PAGTO. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_DT_PAGTO, MOVCC_REGISTRO.REG_SICA11.SICA11_DATA_PAGTO);

            /*" -4900- MOVE DET11-DT-CREDITO TO SICA11-DATA-CREDITO. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_DT_CREDITO, MOVCC_REGISTRO.REG_SICA11.SICA11_DATA_CREDITO);

            /*" -4901- IF AC-GRAV-SAIDA11 EQUAL ZEROS */

            if (W.AC_GRAV_SAIDA11 == 00)
            {

                /*" -4904- PERFORM R2600-00-HEADER-SAIDA11. */

                R2600_00_HEADER_SAIDA11_SECTION();
            }


            /*" -4905- WRITE REG-SAIDA11 FROM REG-SICA11. */
            _.Move(MOVCC_REGISTRO.REG_SICA11.GetMoveValues(), REG_SAIDA11);

            SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

            /*" -4907- ADD 1 TO AC-GRAV-SAIDA11. */
            W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2410-00-BACKSEG-ADESAO-SECTION */
        private void R2410_00_BACKSEG_ADESAO_SECTION()
        {
            /*" -4919- MOVE '2410' TO WNR-EXEC-SQL. */
            _.Move("2410", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -4921- MOVE SPACES TO BACKS-REGISTRO. */
            _.Move("", BACKS_REGISTRO);

            /*" -4923- MOVE 'G' TO BACKS-CODREGISTRO. */
            _.Move("G", BACKS_REGISTRO.BACKS_CODREGISTRO);

            /*" -4925- MOVE 0630 TO BACKS-AGENCIA. */
            _.Move(0630, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_AGENCIA);

            /*" -4927- MOVE 003 TO BACKS-OPERACAO. */
            _.Move(003, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_OPERACAO);

            /*" -4929- MOVE 00001581 TO BACKS-NUMCTA. */
            _.Move(00001581, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_NUMCTA);

            /*" -4931- MOVE 4 TO BACKS-DIGCTA. */
            _.Move(4, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_DIGCTA);

            /*" -4933- MOVE ZEROS TO BACKS-VLRTARIFA. */
            _.Move(0, BACKS_REGISTRO.BACKS_VLRTARIFA);

            /*" -4935- MOVE '00000009' TO BACKS-AGENCIA-ARREC. */
            _.Move("00000009", BACKS_REGISTRO.BACKS_AGENCIA_ARREC);

            /*" -4937- MOVE '6' TO BACKS-FORMA-ARREC. */
            _.Move("6", BACKS_REGISTRO.BACKS_FORMA_ARREC);

            /*" -4939- MOVE 1234567891234567 TO BACKS-NUM-CARTAO. */
            _.Move(1234567891234567, BACKS_REGISTRO.BACKS_NUM_AUTENTIC.BACKS_NUM_CARTAO);

            /*" -4942- MOVE 1 TO BACKS-FORMAPAG. */
            _.Move(1, BACKS_REGISTRO.BACKS_FORMAPAG);

            /*" -4943- MOVE DET11-DT-PAGTO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_DT_PAGTO, WS_DATA_SAP);

            /*" -4944- MOVE WS-DD-SAP TO BACKS-DIAPAG. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, BACKS_REGISTRO.BACKS_DTPAGTO.BACKS_DIAPAG);

            /*" -4945- MOVE WS-MM-SAP TO BACKS-MESPAG. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, BACKS_REGISTRO.BACKS_DTPAGTO.BACKS_MESPAG);

            /*" -4946- MOVE WS-AA-SAP TO BACKS-ANOPAG. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, BACKS_REGISTRO.BACKS_DTPAGTO.BACKS_ANOPAG);

            /*" -4947- MOVE DET11-DT-CREDITO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_DT_CREDITO, WS_DATA_SAP);

            /*" -4948- MOVE WS-DD-SAP TO BACKS-DIACRE. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, BACKS_REGISTRO.BACKS_DTCREDITO.BACKS_DIACRE);

            /*" -4949- MOVE WS-MM-SAP TO BACKS-MESCRE. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, BACKS_REGISTRO.BACKS_DTCREDITO.BACKS_MESCRE);

            /*" -4951- MOVE WS-AA-SAP TO BACKS-ANOCRE. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, BACKS_REGISTRO.BACKS_DTCREDITO.BACKS_ANOCRE);

            /*" -4953- MOVE DET11-NRO-SIVPF TO WS-PROPOSTA. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_USO_EMPRESA.DET11_NRO_SIVPF, WS_PROPOSTA);

            /*" -4955- MOVE WS-PROPOS1 TO BACKS-NUM-PROPOSTA. */
            _.Move(FILLER_29.WS_PROPOS1, BACKS_REGISTRO.BACKS_CODBARRA.BACKS_NUM_PROPOSTA);

            /*" -4957- MOVE 01 TO BACKS-NUM-PARCELA. */
            _.Move(01, BACKS_REGISTRO.BACKS_CODBARRA.BACKS_NUM_PARCELA);

            /*" -4959- MOVE DET11-VLR-PAGO TO BACKS-VLRPAGO. */
            _.Move(DET_REGISTRO.DET_REG11.DET11_VLR_PAGO, BACKS_REGISTRO.BACKS_VLRPAGO);

            /*" -4962- MOVE ZEROS TO BACKS-COD-RETORNO. */
            _.Move(0, BACKS_REGISTRO.BACKS_NUM_AUTENTIC.BACKS_COD_RETORNO);

            /*" -4964- ADD 1 TO TRAILL-TOTREGISTRO. */
            TRAILL_REGISTRO.TRAILL_TOTREGISTRO.Value = TRAILL_REGISTRO.TRAILL_TOTREGISTRO + 1;

            /*" -4967- ADD DET11-VLR-PAGO TO TRAILL-VLRTOTPAG. */
            TRAILL_REGISTRO.TRAILL_VLRTOTPAG.Value = TRAILL_REGISTRO.TRAILL_VLRTOTPAG + DET_REGISTRO.DET_REG11.DET11_VLR_PAGO;

            /*" -4971- MOVE TRAILL-TOTREGISTRO TO BACKS-NRSEQREG. */
            _.Move(TRAILL_REGISTRO.TRAILL_TOTREGISTRO, BACKS_REGISTRO.BACKS_NRSEQREG);

            /*" -4973- WRITE REG-SAIDA14 FROM BACKS-REGISTRO. */
            _.Move(BACKS_REGISTRO.GetMoveValues(), REG_SAIDA14);

            SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

            /*" -4975- ADD 1 TO BAC-ADESAO. */
            W.BAC_ADESAO.Value = W.BAC_ADESAO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2410_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-TRATA-DET14-SECTION */
        private void R2900_00_TRATA_DET14_SECTION()
        {
            /*" -5039- MOVE '2900' TO WNR-EXEC-SQL */
            _.Move("2900", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5040- MOVE DET-TIPREG TO DET17-TP-REGISTRO */
            _.Move(DET_REGISTRO.DET_TIPREG, CIELO_17.DET17_TP_REGISTRO);

            /*" -5041- MOVE DET-BLART TO DET17-TP-MOVIMENTO */
            _.Move(DET_REGISTRO.DET_BLART, CIELO_17.DET17_TP_MOVIMENTO);

            /*" -5042- MOVE DET-IDLG TO DET17-IDLG */
            _.Move(DET_REGISTRO.DET_IDLG, CIELO_17.DET17_IDLG);

            /*" -5043- MOVE DET-AUGST TO DET17-STA-COMPENSACAO */
            _.Move(DET_REGISTRO.DET_AUGST, CIELO_17.DET17_STA_COMPENSACAO);

            /*" -5044- MOVE DET-AUGRD TO DET17-MOTIVO-COMPENSACAO */
            _.Move(DET_REGISTRO.DET_AUGRD, CIELO_17.DET17_MOTIVO_COMPENSACAO);

            /*" -5045- MOVE WS-HEA-NSASAP TO DET17-NSA-SAP */
            _.Move(W.WS_HEA_NSASAP, CIELO_17.DET17_NSA_SAP);

            /*" -5046- MOVE DET-OPBEL TO DET17-NUM-FATURA */
            _.Move(DET_REGISTRO.DET_OPBEL, CIELO_17.DET17_NUM_FATURA);

            /*" -5047- MOVE DET-OPUPK TO DET17-NUM-ITEM-FATURA */
            _.Move(DET_REGISTRO.DET_OPUPK, CIELO_17.DET17_NUM_ITEM_FATURA);

            /*" -5048- MOVE DET-NSA-BCO TO DET17-NSA-BANCO */
            _.Move(DET_REGISTRO.DET_NSA_BCO, CIELO_17.DET17_NSA_BANCO);

            /*" -5049- MOVE DET14-DT-MOVTO TO DET17-DTA-MOV */
            _.Move(DET_REGISTRO.DET_REG14.DET14_DT_MOVTO, CIELO_17.DET17_DTA_MOV);

            /*" -5050- MOVE DET14-NRO-PROPOSTA TO DET17-NUM-PROPOSTA */
            _.Move(DET_REGISTRO.DET_REG14.DET14_NRO_PROPOSTA, CIELO_17.DET17_NUM_PROPOSTA);

            /*" -5051- MOVE DET14-NUM-COM-CIELO TO DET17-NUM-COM-CIELO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_NUM_COM_CIELO, CIELO_17.DET17_NUM_COM_CIELO);

            /*" -5052- MOVE DET14-COD-BCO-CRED TO DET17-COD-BCO-CRED */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_BCO_CRED, CIELO_17.DET17_COD_BCO_CRED);

            /*" -5053- MOVE DET14-COD-AGE-CRED TO DET17-COD-AGE-CRED */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_AGE_CRED, CIELO_17.DET17_COD_AGE_CRED);

            /*" -5054- MOVE DET14-NUM-CTA-CRED TO DET17-NUM-CTA-CRED */
            _.Move(DET_REGISTRO.DET_REG14.DET14_NUM_CTA_CRED, CIELO_17.DET17_NUM_CTA_CRED);

            /*" -5055- MOVE DET14-DIG-CTA-CRED TO DET17-DIG-CTA-CRED */
            _.Move(DET_REGISTRO.DET_REG14.DET14_DIG_CTA_CRED, CIELO_17.DET17_DIG_CTA_CRED);

            /*" -5056- MOVE DET14-COD-CART-BANDEIRA TO DET17-COD-CART-BANDEIRA */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_CART_BANDEIRA, CIELO_17.DET17_COD_CART_BANDEIRA);

            /*" -5057- MOVE DET14-NUM-CARTAO TO DET17-NUM-CARTAO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_NUM_CARTAO, CIELO_17.DET17_NUM_CARTAO);

            /*" -5058- MOVE DET14-COD-TOKEN-CARTAO TO DET17-COD-TOKEN-CARTAO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_TOKEN_CARTAO, CIELO_17.DET17_COD_TOKEN_CARTAO);

            /*" -5059- MOVE DET14-STA-CART-PADRAO-SAP TO DET17-STA-CART-PADRAO-SAP */
            _.Move(DET_REGISTRO.DET_REG14.DET14_STA_CART_PADRAO_SAP, CIELO_17.DET17_STA_CART_PADRAO_SAP);

            /*" -5060- MOVE DET14-COD-TID-CIELO TO DET17-COD-TID-CIELO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_TID_CIELO, CIELO_17.DET17_COD_TID_CIELO);

            /*" -5061- MOVE DET14-VLR-COBRANCA TO DET17-VLR-COBRANCA */
            _.Move(DET_REGISTRO.DET_REG14.DET14_VLR_COBRANCA, CIELO_17.DET17_VLR_COBRANCA);

            /*" -5062- MOVE DET14-VLR-LIQUIDO TO DET17-VLR-LIQUIDO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_VLR_LIQUIDO, CIELO_17.DET17_VLR_LIQUIDO);

            /*" -5063- MOVE DET14-VLR-TAX-ADM TO DET17-VLR-TAX-ADM */
            _.Move(DET_REGISTRO.DET_REG14.DET14_VLR_TAX_ADM, CIELO_17.DET17_VLR_TAX_ADM);

            /*" -5064- MOVE DET14-DTA-VENCIMENTO TO DET17-DTA-VENCIMENTO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_DTA_VENCIMENTO, CIELO_17.DET17_DTA_VENCIMENTO);

            /*" -5065- MOVE DET14-DT-CREDITO TO DET17-DTA-CREDITO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_DT_CREDITO, CIELO_17.DET17_DTA_CREDITO);

            /*" -5066- MOVE DET14-DT-DEBITO TO DET17-DTA-DEB-TARIFA-ADM */
            _.Move(DET_REGISTRO.DET_REG14.DET14_DT_DEBITO, CIELO_17.DET17_DTA_DEB_TARIFA_ADM);

            /*" -5067- MOVE DET14-DTA-AJU-CAPTURA TO DET17-DTA-AJU-CAPTURA */
            _.Move(DET_REGISTRO.DET_REG14.DET14_DTA_AJU_CAPTURA, CIELO_17.DET17_DTA_AJU_CAPTURA);

            /*" -5068- MOVE DET14-COD-MOVIMENTO TO DET17-COD-MOVIMENTO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_MOVIMENTO, CIELO_17.DET17_COD_MOVIMENTO);

            /*" -5069- MOVE DET14-COD-RETORNO TO DET17-COD-RETORNO */
            _.Move(DET_REGISTRO.DET_REG14.DET14_COD_RETORNO, CIELO_17.DET17_COD_RETORNO);

            /*" -5070- MOVE DET14-PROC-ADVERT TO DET17-PROC-ADVERT */
            _.Move(DET_REGISTRO.DET_REG14.DET14_PROC_ADVERT, CIELO_17.DET17_PROC_ADVERT);

            /*" -5072- MOVE DET14-NIVE-ADVERT TO DET17-NIVE-ADVERT */
            _.Move(DET_REGISTRO.DET_REG14.DET14_NIVE_ADVERT, CIELO_17.DET17_NIVE_ADVERT);

            /*" -5073- WRITE REG-SAIDA17 FROM CIELO-17 */
            _.Move(CIELO_17.GetMoveValues(), REG_SAIDA17);

            SAIDA17.Write(REG_SAIDA17.GetMoveValues().ToString());

            /*" -5074- ADD 1 TO AC-GRAV-SAIDA17 TT-DET14. */
            W.AC_GRAV_SAIDA17.Value = W.AC_GRAV_SAIDA17 + 1;
            W.TT_DET14.Value = W.TT_DET14 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2520-00-SELECT-BILHETE-SECTION */
        private void R2520_00_SELECT_BILHETE_SECTION()
        {
            /*" -5165- MOVE '2520' TO WNR-EXEC-SQL. */
            _.Move("2520", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5175- PERFORM R2520_00_SELECT_BILHETE_DB_SELECT_1 */

            R2520_00_SELECT_BILHETE_DB_SELECT_1();

            /*" -5179- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5181- MOVE ZEROS TO PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

                /*" -5182- ELSE */
            }
            else
            {


                /*" -5183- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5184- DISPLAY 'R2520-00 - PROBLEMAS NO SELECT BILHETE ' */
                    _.Display($"R2520-00 - PROBLEMAS NO SELECT BILHETE ");

                    /*" -5185- DISPLAY 'NUM_APOLICE       = ' BILHETE-NUM-APOLICE */
                    _.Display($"NUM_APOLICE       = {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

                    /*" -5187- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2520-00-SELECT-BILHETE-DB-SELECT-1 */
        public void R2520_00_SELECT_BILHETE_DB_SELECT_1()
        {
            /*" -5175- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.BILHETE A ,SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_APOLICE = :BILHETE-NUM-APOLICE AND A.NUM_BILHETE = B.NUM_SICOB WITH UR END-EXEC. */

            var r2520_00_SELECT_BILHETE_DB_SELECT_1_Query1 = new R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_APOLICE = BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2520_00_SELECT_BILHETE_DB_SELECT_1_Query1.Execute(r2520_00_SELECT_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2520_99_SAIDA*/

        [StopWatch]
        /*" R2550-00-HEADER-BACKSEG-SECTION */
        private void R2550_00_HEADER_BACKSEG_SECTION()
        {
            /*" -5199- MOVE '2550' TO WNR-EXEC-SQL. */
            _.Move("2550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5201- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -5203- MOVE 'A' TO HEADER-CODREGISTRO. */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -5205- MOVE 2 TO HEADER-CODREMESSA. */
            _.Move(2, HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -5207- MOVE 1028370056 TO HEADER-CODCONVENIO. */
            _.Move(1028370056, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -5209- MOVE 'CIELO' TO HEADER-NOMEMPRESA. */
            _.Move("CIELO", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -5211- MOVE 104 TO HEADER-CODBANCO. */
            _.Move(104, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -5213- MOVE 'CAIXA' TO HEADER-NOMBANCO. */
            _.Move("CAIXA", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -5216- MOVE 4 TO HEADER-VERSAO. */
            _.Move(4, HEADER_REGISTRO.HEADER_VERSAO);

            /*" -5217- MOVE WHOST-DATA-EM TO WDATA-REL. */
            _.Move(WHOST_DATA_EM, WDATA_REL);

            /*" -5218- MOVE WDAT-REL-ANO TO HEADER-ANO. */
            _.Move(FILLER_56.WDAT_REL_ANO, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_ANO);

            /*" -5219- MOVE WDAT-REL-MES TO HEADER-MES. */
            _.Move(FILLER_56.WDAT_REL_MES, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_MES);

            /*" -5221- MOVE WDAT-REL-DIA TO HEADER-DIA. */
            _.Move(FILLER_56.WDAT_REL_DIA, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_DIA);

            /*" -5223- PERFORM R2570-00-SELECT-MOVIMCOB. */

            R2570_00_SELECT_MOVIMCOB_SECTION();

            /*" -5227- MOVE WSHOST-COUNT TO HEADER-NSA. */
            _.Move(WSHOST_COUNT, HEADER_REGISTRO.HEADER_NSA);

            /*" -5230- WRITE REG-SAIDA14 FROM HEADER-REGISTRO. */
            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA14);

            SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

            /*" -5232- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -5234- MOVE 'Z' TO TRAILL-CODREGISTRO. */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -5238- MOVE ZEROS TO TRAILL-TOTREGISTRO TRAILL-VLRTOTPAG. */
            _.Move(0, TRAILL_REGISTRO.TRAILL_TOTREGISTRO, TRAILL_REGISTRO.TRAILL_VLRTOTPAG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2550_99_SAIDA*/

        [StopWatch]
        /*" R2560-00-TRAILL-BACKSEG-SECTION */
        private void R2560_00_TRAILL_BACKSEG_SECTION()
        {
            /*" -5250- MOVE '2560' TO WNR-EXEC-SQL. */
            _.Move("2560", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5252- WRITE REG-SAIDA14 FROM TRAILL-REGISTRO. */
            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA14);

            SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

            /*" -5253- DISPLAY ' ' */
            _.Display($" ");

            /*" -5254- DISPLAY 'GRAVADOS BACKSEG ........ ' TRAILL-TOTREGISTRO. */
            _.Display($"GRAVADOS BACKSEG ........ {TRAILL_REGISTRO.TRAILL_TOTREGISTRO}");

            /*" -5255- DISPLAY 'GRAVADOS ADESAO ......... ' BAC-ADESAO. */
            _.Display($"GRAVADOS ADESAO ......... {W.BAC_ADESAO}");

            /*" -5256- DISPLAY 'GRAVADOS DEMAIS ......... ' BAC-DEMAIS. */
            _.Display($"GRAVADOS DEMAIS ......... {W.BAC_DEMAIS}");

            /*" -5259- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2560_99_SAIDA*/

        [StopWatch]
        /*" R2570-00-SELECT-MOVIMCOB-SECTION */
        private void R2570_00_SELECT_MOVIMCOB_SECTION()
        {
            /*" -5270- MOVE '2570' TO WNR-EXEC-SQL. */
            _.Move("2570", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5272- MOVE 104 TO MOVIMCOB-COD-BANCO. */
            _.Move(104, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);

            /*" -5275- MOVE 9581 TO MOVIMCOB-COD-AGENCIA. */
            _.Move(9581, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);

            /*" -5284- PERFORM R2570_00_SELECT_MOVIMCOB_DB_SELECT_1 */

            R2570_00_SELECT_MOVIMCOB_DB_SELECT_1();

            /*" -5287- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -5289- MOVE 1 TO WSHOST-COUNT */
                _.Move(1, WSHOST_COUNT);

                /*" -5290- ELSE */
            }
            else
            {


                /*" -5291- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -5292- DISPLAY 'R2570-00 - PROBLEMAS NO SELECT MOVIMCOB' */
                    _.Display($"R2570-00 - PROBLEMAS NO SELECT MOVIMCOB");

                    /*" -5293- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -5294- ELSE */
                }
                else
                {


                    /*" -5295- IF VIND-NULL01 LESS ZEROS */

                    if (VIND_NULL01 < 00)
                    {

                        /*" -5297- MOVE 1 TO WSHOST-COUNT */
                        _.Move(1, WSHOST_COUNT);

                        /*" -5298- ELSE */
                    }
                    else
                    {


                        /*" -5301- ADD 1 TO WSHOST-COUNT. */
                        WSHOST_COUNT.Value = WSHOST_COUNT + 1;
                    }

                }

            }


        }

        [StopWatch]
        /*" R2570-00-SELECT-MOVIMCOB-DB-SELECT-1 */
        public void R2570_00_SELECT_MOVIMCOB_DB_SELECT_1()
        {
            /*" -5284- EXEC SQL SELECT MAX(NUM_FITA) INTO :WSHOST-COUNT:VIND-NULL01 FROM SEGUROS.MOVIMENTO_COBRANCA WHERE COD_BANCO = :MOVIMCOB-COD-BANCO AND COD_AGENCIA = :MOVIMCOB-COD-AGENCIA WITH UR END-EXEC. */

            var r2570_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1 = new R2570_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1()
            {
                MOVIMCOB_COD_AGENCIA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA.ToString(),
                MOVIMCOB_COD_BANCO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO.ToString(),
            };

            var executed_1 = R2570_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1.Execute(r2570_00_SELECT_MOVIMCOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_COUNT, WSHOST_COUNT);
                _.Move(executed_1.VIND_NULL01, VIND_NULL01);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2570_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-HEADER-SAIDA11-SECTION */
        private void R2600_00_HEADER_SAIDA11_SECTION()
        {
            /*" -5313- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5314- MOVE WHOST-DATA-EM TO WDATA-REL. */
            _.Move(WHOST_DATA_EM, WDATA_REL);

            /*" -5315- MOVE WDAT-REL-ANO TO HEAD11-ANO-HEADER. */
            _.Move(FILLER_56.WDAT_REL_ANO, REG_CESTA_DET.HEADER_SAIDA11.HEAD11_DTMOVTO.HEAD11_ANO_HEADER);

            /*" -5316- MOVE WDAT-REL-MES TO HEAD11-MES-HEADER. */
            _.Move(FILLER_56.WDAT_REL_MES, REG_CESTA_DET.HEADER_SAIDA11.HEAD11_DTMOVTO.HEAD11_MES_HEADER);

            /*" -5317- MOVE WDAT-REL-DIA TO HEAD11-DIA-HEADER. */
            _.Move(FILLER_56.WDAT_REL_DIA, REG_CESTA_DET.HEADER_SAIDA11.HEAD11_DTMOVTO.HEAD11_DIA_HEADER);

            /*" -5318- MOVE '00' TO HEAD11-TIPO-REGISTRO. */
            _.Move("00", REG_CESTA_DET.HEADER_SAIDA11.HEAD11_TIPO_REGISTRO);

            /*" -5322- MOVE 'PARCEIROS DET11-DET14 - EM8006B - BI6251B' TO HEAD11-DESCRICAO. */
            _.Move("PARCEIROS DET11-DET14 - EM8006B - BI6251B", REG_CESTA_DET.HEADER_SAIDA11.HEAD11_DESCRICAO);

            /*" -5323- WRITE REG-SAIDA11 FROM HEADER-SAIDA11. */
            _.Move(REG_CESTA_DET.HEADER_SAIDA11.GetMoveValues(), REG_SAIDA11);

            SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

            /*" -5325- ADD 1 TO AC-GRAV-SAIDA11. */
            W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-TRATA-DET12-SECTION */
        private void R2700_00_TRATA_DET12_SECTION()
        {
            /*" -5337- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5338- ADD 1 TO TT-DET12. */
            W.TT_DET12.Value = W.TT_DET12 + 1;

            /*" -5340- MOVE SPACES TO REG-SICA12. */
            _.Move("", REG_CESTA_DET.REG_SICA12);

            /*" -5342- IF DET-BUKRS NOT EQUAL 'C000' AND NOT EQUAL 'C010' */

            if (!DET_REGISTRO.DET_BUKRS.In("C000", "C010"))
            {

                /*" -5343- ADD 1 TO DP-DET12 */
                W.DP_DET12.Value = W.DP_DET12 + 1;

                /*" -5349- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5350- MOVE DET-IDLG TO WS-IDLG-DEMAIS. */
            _.Move(DET_REGISTRO.DET_IDLG, WS_IDLG_DEMAIS);

            /*" -5351- IF WS-IDLG-DEM-CON EQUAL 102837 */

            if (FILLER_21.WS_IDLG_DEM_CON == 102837)
            {

                /*" -5352- PERFORM R2710-00-BACKSEG-DEMAIS */

                R2710_00_BACKSEG_DEMAIS_SECTION();

                /*" -5353- GO TO R2700-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;

                /*" -5354- ELSE */
            }
            else
            {


                /*" -5355- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -5356- ADD 1 TO DP-MOVIMENTO */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;

                /*" -5382- GO TO R2700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2710-00-BACKSEG-DEMAIS-SECTION */
        private void R2710_00_BACKSEG_DEMAIS_SECTION()
        {
            /*" -5394- MOVE '2710' TO WNR-EXEC-SQL. */
            _.Move("2710", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5397- MOVE WS-IDLG-DEM-APO TO BILHETE-NUM-APOLICE. */
            _.Move(FILLER_21.WS_IDLG_DEM_APO, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);

            /*" -5399- PERFORM R2520-00-SELECT-BILHETE. */

            R2520_00_SELECT_BILHETE_SECTION();

            /*" -5400- IF PROPOFID-NUM-PROPOSTA-SIVPF EQUAL ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF == 00)
            {

                /*" -5401- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -5402- ADD 1 TO DP-MOVIMENTO */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;

                /*" -5404- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5405- IF DET12-CONVENIO NOT EQUAL 12000 */

            if (DET_REGISTRO.DET_REG12.DET12_CONVENIO != 12000)
            {

                /*" -5406- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -5407- ADD 1 TO DP-MOVIMENTO */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;

                /*" -5410- GO TO R2710-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/ //GOTO
                return;
            }


            /*" -5412- MOVE SPACES TO BACKS-REGISTRO. */
            _.Move("", BACKS_REGISTRO);

            /*" -5414- MOVE 'G' TO BACKS-CODREGISTRO. */
            _.Move("G", BACKS_REGISTRO.BACKS_CODREGISTRO);

            /*" -5416- MOVE 0630 TO BACKS-AGENCIA. */
            _.Move(0630, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_AGENCIA);

            /*" -5418- MOVE 003 TO BACKS-OPERACAO. */
            _.Move(003, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_OPERACAO);

            /*" -5420- MOVE 00001581 TO BACKS-NUMCTA. */
            _.Move(00001581, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_NUMCTA);

            /*" -5422- MOVE 4 TO BACKS-DIGCTA. */
            _.Move(4, BACKS_REGISTRO.BACKS_CTACOBRANCA.BACKS_DIGCTA);

            /*" -5424- MOVE ZEROS TO BACKS-VLRTARIFA. */
            _.Move(0, BACKS_REGISTRO.BACKS_VLRTARIFA);

            /*" -5426- MOVE '00000009' TO BACKS-AGENCIA-ARREC. */
            _.Move("00000009", BACKS_REGISTRO.BACKS_AGENCIA_ARREC);

            /*" -5428- MOVE '6' TO BACKS-FORMA-ARREC. */
            _.Move("6", BACKS_REGISTRO.BACKS_FORMA_ARREC);

            /*" -5430- MOVE 1234567891234567 TO BACKS-NUM-CARTAO. */
            _.Move(1234567891234567, BACKS_REGISTRO.BACKS_NUM_AUTENTIC.BACKS_NUM_CARTAO);

            /*" -5433- MOVE 1 TO BACKS-FORMAPAG. */
            _.Move(1, BACKS_REGISTRO.BACKS_FORMAPAG);

            /*" -5434- MOVE DET12-DT-MOVTO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG12.DET12_DT_MOVTO, WS_DATA_SAP);

            /*" -5435- MOVE WS-DD-SAP TO BACKS-DIAPAG. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, BACKS_REGISTRO.BACKS_DTPAGTO.BACKS_DIAPAG);

            /*" -5436- MOVE WS-MM-SAP TO BACKS-MESPAG. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, BACKS_REGISTRO.BACKS_DTPAGTO.BACKS_MESPAG);

            /*" -5437- MOVE WS-AA-SAP TO BACKS-ANOPAG. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, BACKS_REGISTRO.BACKS_DTPAGTO.BACKS_ANOPAG);

            /*" -5438- MOVE DET12-DT-CREDITO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG12.DET12_DT_CREDITO, WS_DATA_SAP);

            /*" -5439- MOVE WS-DD-SAP TO BACKS-DIACRE. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, BACKS_REGISTRO.BACKS_DTCREDITO.BACKS_DIACRE);

            /*" -5440- MOVE WS-MM-SAP TO BACKS-MESCRE. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, BACKS_REGISTRO.BACKS_DTCREDITO.BACKS_MESCRE);

            /*" -5442- MOVE WS-AA-SAP TO BACKS-ANOCRE. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, BACKS_REGISTRO.BACKS_DTCREDITO.BACKS_ANOCRE);

            /*" -5444- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_PROPOSTA);

            /*" -5446- MOVE WS-PROPOS1 TO BACKS-NUM-PROPOSTA. */
            _.Move(FILLER_29.WS_PROPOS1, BACKS_REGISTRO.BACKS_CODBARRA.BACKS_NUM_PROPOSTA);

            /*" -5448- MOVE WS-IDLG-DEM-PAR TO BACKS-NUM-PARCELA. */
            _.Move(FILLER_21.WS_IDLG_DEM_PAR, BACKS_REGISTRO.BACKS_CODBARRA.BACKS_NUM_PARCELA);

            /*" -5450- MOVE DET12-VLR-PARCELA TO BACKS-VLRPAGO. */
            _.Move(DET_REGISTRO.DET_REG12.DET12_VLR_PARCELA, BACKS_REGISTRO.BACKS_VLRPAGO);

            /*" -5453- MOVE DET12-COD-ERRO TO BACKS-COD-RETORNO. */
            _.Move(DET_REGISTRO.DET_REG12.DET12_COD_ERRO, BACKS_REGISTRO.BACKS_NUM_AUTENTIC.BACKS_COD_RETORNO);

            /*" -5455- ADD 1 TO TRAILL-TOTREGISTRO. */
            TRAILL_REGISTRO.TRAILL_TOTREGISTRO.Value = TRAILL_REGISTRO.TRAILL_TOTREGISTRO + 1;

            /*" -5458- ADD DET12-VLR-PARCELA TO TRAILL-VLRTOTPAG. */
            TRAILL_REGISTRO.TRAILL_VLRTOTPAG.Value = TRAILL_REGISTRO.TRAILL_VLRTOTPAG + DET_REGISTRO.DET_REG12.DET12_VLR_PARCELA;

            /*" -5462- MOVE TRAILL-TOTREGISTRO TO BACKS-NRSEQREG. */
            _.Move(TRAILL_REGISTRO.TRAILL_TOTREGISTRO, BACKS_REGISTRO.BACKS_NRSEQREG);

            /*" -5464- WRITE REG-SAIDA14 FROM BACKS-REGISTRO. */
            _.Move(BACKS_REGISTRO.GetMoveValues(), REG_SAIDA14);

            SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

            /*" -5465- ADD 1 TO BAC-DEMAIS. */
            W.BAC_DEMAIS.Value = W.BAC_DEMAIS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2710_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-HEADER-SAIDA12-SECTION */
        private void R2800_00_HEADER_SAIDA12_SECTION()
        {
            /*" -5477- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5478- MOVE WHOST-DATA-EM TO WDATA-REL. */
            _.Move(WHOST_DATA_EM, WDATA_REL);

            /*" -5479- MOVE WDAT-REL-ANO TO HEAD12-ANO-HEADER. */
            _.Move(FILLER_56.WDAT_REL_ANO, REG_CESTA_DET.HEADER_SAIDA12.HEAD12_DTMOVTO.HEAD12_ANO_HEADER);

            /*" -5480- MOVE WDAT-REL-MES TO HEAD12-MES-HEADER. */
            _.Move(FILLER_56.WDAT_REL_MES, REG_CESTA_DET.HEADER_SAIDA12.HEAD12_DTMOVTO.HEAD12_MES_HEADER);

            /*" -5481- MOVE WDAT-REL-DIA TO HEAD12-DIA-HEADER. */
            _.Move(FILLER_56.WDAT_REL_DIA, REG_CESTA_DET.HEADER_SAIDA12.HEAD12_DTMOVTO.HEAD12_DIA_HEADER);

            /*" -5482- MOVE '00' TO HEAD12-TIPO-REGISTRO. */
            _.Move("00", REG_CESTA_DET.HEADER_SAIDA12.HEAD12_TIPO_REGISTRO);

            /*" -5486- MOVE 'PARCEIROS DET12 - EM8006B - BI6257B' TO HEAD12-DESCRICAO. */
            _.Move("PARCEIROS DET12 - EM8006B - BI6257B", REG_CESTA_DET.HEADER_SAIDA12.HEAD12_DESCRICAO);

            /*" -5487- WRITE REG-SAIDA14 FROM HEADER-SAIDA12. */
            _.Move(REG_CESTA_DET.HEADER_SAIDA12.GetMoveValues(), REG_SAIDA14);

            SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

            /*" -5489- ADD 1 TO AC-GRAV-SAIDA14. */
            W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-TRATA-SICAP-SECTION */
        private void R3000_00_TRATA_SICAP_SECTION()
        {
            /*" -5501- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5503- ADD 1 TO TT-SICAP. */
            W.TT_SICAP.Value = W.TT_SICAP + 1;

            /*" -5504- MOVE DET7-DT-GERACAO TO WS-DATA-SAP */
            _.Move(DET_REGISTRO.DET_REG7.DET7_DT_GERACAO, WS_DATA_SAP);

            /*" -5506- MOVE WS-DD-SAP TO SICAP-DIA-HEADER. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DTGERACAO.SICAP_DIA_HEADER);

            /*" -5508- MOVE WS-MM-SAP TO SICAP-MES-HEADER. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DTGERACAO.SICAP_MES_HEADER);

            /*" -5511- MOVE WS-AA-SAP TO SICAP-ANO-HEADER. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DTGERACAO.SICAP_ANO_HEADER);

            /*" -5512-  EVALUATE TRUE  */

            /*" -5513-  WHEN DET7-COD-CONV           = 912105  */

            /*" -5513- IF DET7-COD-CONV           = 912105 */

            if (DET_REGISTRO.DET_REG7.DET7_COD_CONV == 912105)
            {

                /*" -5514- MOVE 912085 TO SICAP-CONVENIO-SAP */
                _.Move(912085, MOVCC_REGISTRO.REG_SICAP.SICAP_CONVENIO_SAP);

                /*" -5515-  WHEN DET7-COD-CONV           = 912861  */

                /*" -5515- ELSE IF DET7-COD-CONV           = 912861 */
            }
            else

            if (DET_REGISTRO.DET_REG7.DET7_COD_CONV == 912861)
            {

                /*" -5517- MOVE 912085 TO SICAP-CONVENIO-SAP */
                _.Move(912085, MOVCC_REGISTRO.REG_SICAP.SICAP_CONVENIO_SAP);

                /*" -5518-  WHEN DET7-COD-CONV           = 912106  */

                /*" -5518- ELSE IF DET7-COD-CONV           = 912106 */
            }
            else

            if (DET_REGISTRO.DET_REG7.DET7_COD_CONV == 912106)
            {

                /*" -5519- MOVE 912086 TO SICAP-CONVENIO-SAP */
                _.Move(912086, MOVCC_REGISTRO.REG_SICAP.SICAP_CONVENIO_SAP);

                /*" -5520-  WHEN DET7-COD-CONV           = 912107  */

                /*" -5520- ELSE IF DET7-COD-CONV           = 912107 */
            }
            else

            if (DET_REGISTRO.DET_REG7.DET7_COD_CONV == 912107)
            {

                /*" -5521- MOVE 912087 TO SICAP-CONVENIO-SAP */
                _.Move(912087, MOVCC_REGISTRO.REG_SICAP.SICAP_CONVENIO_SAP);

                /*" -5522-  WHEN DET7-COD-CONV           = 912108  */

                /*" -5522- ELSE IF DET7-COD-CONV           = 912108 */
            }
            else

            if (DET_REGISTRO.DET_REG7.DET7_COD_CONV == 912108)
            {

                /*" -5523- MOVE 912090 TO SICAP-CONVENIO-SAP */
                _.Move(912090, MOVCC_REGISTRO.REG_SICAP.SICAP_CONVENIO_SAP);

                /*" -5524-  WHEN OTHER  */

                /*" -5524- ELSE */
            }
            else
            {


                /*" -5525- MOVE DET7-COD-CONV TO SICAP-CONVENIO-SAP */
                _.Move(DET_REGISTRO.DET_REG7.DET7_COD_CONV, MOVCC_REGISTRO.REG_SICAP.SICAP_CONVENIO_SAP);

                /*" -5527-  END-EVALUATE  */

                /*" -5527- END-IF */
            }


            /*" -5530- MOVE DET7-COD-BCO TO SICAP-BANCO. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_COD_BCO, MOVCC_REGISTRO.REG_SICAP.SICAP_BANCO);

            /*" -5533- MOVE 'G' TO SICAP-COD-REGISTRO. */
            _.Move("G", MOVCC_REGISTRO.REG_SICAP.SICAP_COD_REGISTRO);

            /*" -5536- MOVE DET7-AGENCIA TO SICAP-AGENCIA. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_AGENCIA, MOVCC_REGISTRO.REG_SICAP.SICAP_AGENCIA);

            /*" -5539- MOVE DET7-OPERACAO TO SICAP-OPERACAO. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_OPERACAO, MOVCC_REGISTRO.REG_SICAP.SICAP_OPERACAO);

            /*" -5542- MOVE DET7-NRO-CONTA TO SICAP-NUM-CONTA. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_NRO_CONTA, MOVCC_REGISTRO.REG_SICAP.SICAP_NUM_CONTA);

            /*" -5545- MOVE DET7-DV-CONTA TO SICAP-DIG-CONTA. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_DV_CONTA, MOVCC_REGISTRO.REG_SICAP.SICAP_DIG_CONTA);

            /*" -5546- MOVE DET7-DT-PAGTO TO WS-DATA-SAP */
            _.Move(DET_REGISTRO.DET_REG7.DET7_DT_PAGTO, WS_DATA_SAP);

            /*" -5548- MOVE WS-DD-SAP TO SICAP-DIA-PAGTO. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DATA_PAGTO.SICAP_DIA_PAGTO);

            /*" -5550- MOVE WS-MM-SAP TO SICAP-MES-PAGTO. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DATA_PAGTO.SICAP_MES_PAGTO);

            /*" -5553- MOVE WS-AA-SAP TO SICAP-ANO-PAGTO. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DATA_PAGTO.SICAP_ANO_PAGTO);

            /*" -5554- MOVE DET7-DT-CREDITO TO WS-DATA-SAP */
            _.Move(DET_REGISTRO.DET_REG7.DET7_DT_CREDITO, WS_DATA_SAP);

            /*" -5556- MOVE WS-DD-SAP TO SICAP-DIA-CRED. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DATA_CREDITO.SICAP_DIA_CRED);

            /*" -5558- MOVE WS-MM-SAP TO SICAP-MES-CRED. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DATA_CREDITO.SICAP_MES_CRED);

            /*" -5561- MOVE WS-AA-SAP TO SICAP-ANO-CRED. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, MOVCC_REGISTRO.REG_SICAP.SICAP_DATA_CREDITO.SICAP_ANO_CRED);

            /*" -5564- MOVE DET7-BARRA01 TO SICAP-BARRA01. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_BARRA01, MOVCC_REGISTRO.REG_SICAP.SICAP_BARRA01);

            /*" -5567- MOVE DET7-BANCO TO SICAP-CODBANCO. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_BANCO, MOVCC_REGISTRO.REG_SICAP.SICAP_CODBANCO);

            /*" -5570- MOVE DET7-BARRA02 TO SICAP-BARRA02. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_BARRA02, MOVCC_REGISTRO.REG_SICAP.SICAP_BARRA02);

            /*" -5573- MOVE DET7-NRO-SIVPF TO SICAP-NUM-SIVPF. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_NRO_SIVPF, MOVCC_REGISTRO.REG_SICAP.SICAP_NUM_SIVPF);

            /*" -5576- MOVE DET7-BARRA03 TO SICAP-BARRA03. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_BARRA03, MOVCC_REGISTRO.REG_SICAP.SICAP_BARRA03);

            /*" -5579- MOVE DET7-VLR-PAGO TO SICAP-VALOR-PAGO. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_VLR_PAGO, MOVCC_REGISTRO.REG_SICAP.SICAP_VALOR_PAGO);

            /*" -5582- MOVE DET7-VLR-TARIFA TO SICAP-VALOR-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG7.DET7_VLR_TARIFA, MOVCC_REGISTRO.REG_SICAP.SICAP_VALOR_TARIFA);

            /*" -5585- MOVE DET-NSA-BCO TO SICAP-NSAC. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, MOVCC_REGISTRO.REG_SICAP.SICAP_NSAC);

            /*" -5587- WRITE REG-SAIDA2 FROM REG-SICAP. */
            _.Move(MOVCC_REGISTRO.REG_SICAP.GetMoveValues(), REG_SAIDA2);

            SAIDA2.Write(REG_SAIDA2.GetMoveValues().ToString());

            /*" -5587- ADD 1 TO AC-GRAV-SAIDA2. */
            W.AC_GRAV_SAIDA2.Value = W.AC_GRAV_SAIDA2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3500-00-TRATA-BANCOOB-SECTION */
        private void R3500_00_TRATA_BANCOOB_SECTION()
        {
            /*" -5601- MOVE '3500' TO WNR-EXEC-SQL. */
            _.Move("3500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5603- ADD 1 TO TT-BANCOOB. */
            W.TT_BANCOOB.Value = W.TT_BANCOOB + 1;

            /*" -5606- MOVE 1 TO BANCOOB-COD-REGISTRO. */
            _.Move(1, REG_BANCOOB.BANCOOB_COD_REGISTRO);

            /*" -5607- MOVE DET9-DT-GERACAO TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DT_GERACAO, WS_DATA_SAP1);

            /*" -5609- MOVE WS-DD-SAP1 TO BANCOOB-DIA-HEADER. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_BANCOOB.BANCOOB_DTGERACAO.BANCOOB_DIA_HEADER);

            /*" -5611- MOVE WS-MM-SAP1 TO BANCOOB-MES-HEADER. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_BANCOOB.BANCOOB_DTGERACAO.BANCOOB_MES_HEADER);

            /*" -5614- MOVE WS-AA-SAP1 TO BANCOOB-ANO-HEADER. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_BANCOOB.BANCOOB_DTGERACAO.BANCOOB_ANO_HEADER);

            /*" -5616- MOVE DET9-COD-BCO TO BANCOOB-BANCO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_COD_BCO, REG_BANCOOB.BANCOOB_BANCO);

            /*" -5619- MOVE DET9-DIG-BCO TO BANCOOB-DIGBCO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DIG_BCO, REG_BANCOOB.BANCOOB_DIGBCO);

            /*" -5621- MOVE 2 TO BANCOOB-TIPO-INSCRICAO. */
            _.Move(2, REG_BANCOOB.BANCOOB_TIPO_INSCRICAO);

            /*" -5623- MOVE DET9-CGCCPF TO BANCOOB-NUM-INSCRICAO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_CGCCPF, REG_BANCOOB.BANCOOB_NUM_INSCRICAO);

            /*" -5625- MOVE DET9-COD-CEDENTE TO BANCOOB-CEDENTE. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_COD_CEDENTE, REG_BANCOOB.BANCOOB_CEDENTE);

            /*" -5627- MOVE DET9-COD-CONVENIO TO BANCOOB-CONVENIO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_COD_CONVENIO, REG_BANCOOB.BANCOOB_CONVENIO);

            /*" -5629- MOVE DET9-AGENCIA TO BANCOOB-COD-AGENCIA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_AGENCIA, REG_BANCOOB.BANCOOB_COD_AGENCIA);

            /*" -5631- MOVE DET9-DIG-AGE TO BANCOOB-DIG-AGENCIA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DIG_AGE, REG_BANCOOB.BANCOOB_DIG_AGENCIA);

            /*" -5633- MOVE DET9-NRO-CONTA TO BANCOOB-NRO-CONTA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_NRO_CONTA, REG_BANCOOB.BANCOOB_NRO_CONTA);

            /*" -5635- MOVE DET9-DV-CONTA TO BANCOOB-DIG-CONTA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DV_CONTA, REG_BANCOOB.BANCOOB_DIG_CONTA);

            /*" -5637- MOVE DET9-CONTROLE TO BANCOOB-CONTROLE. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_CONTROLE, REG_BANCOOB.BANCOOB_CONTROLE);

            /*" -5639- MOVE DET9-NRO-TITULO TO BANCOOB-NRO-TITULO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_NRO_TITULO, REG_BANCOOB.BANCOOB_NRO_TITULO);

            /*" -5641- MOVE DET9-DIG-TITULO TO BANCOOB-DIG-TITULO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DIG_TITULO, REG_BANCOOB.BANCOOB_DIG_TITULO);

            /*" -5643- MOVE DET9-NRPARCEL TO BANCOOB-NRO-PARCELA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_NRPARCEL, REG_BANCOOB.BANCOOB_NRO_PARCELA);

            /*" -5645- MOVE DET9-DIAS-CALC TO BANCOOB-DIAS-CALCULO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DIAS_CALC, REG_BANCOOB.BANCOOB_DIAS_CALCULO);

            /*" -5647- MOVE DET9-MOTIVO TO BANCOOB-MOTIVO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_MOTIVO, REG_BANCOOB.BANCOOB_MOTIVO);

            /*" -5649- MOVE DET9-PREFIXO TO BANCOOB-PREFIXO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_PREFIXO, REG_BANCOOB.BANCOOB_PREFIXO);

            /*" -5651- MOVE DET9-VARIACAO TO BANCOOB-VARIACAO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_VARIACAO, REG_BANCOOB.BANCOOB_VARIACAO);

            /*" -5653- MOVE ZEROS TO BANCOOB-CAUCAO. */
            _.Move(0, REG_BANCOOB.BANCOOB_CAUCAO);

            /*" -5655- MOVE ZEROS TO BANCOOB-RESPONSABIL. */
            _.Move(0, REG_BANCOOB.BANCOOB_RESPONSABIL);

            /*" -5657- MOVE ZEROS TO BANCOOB-DIGITO. */
            _.Move(0, REG_BANCOOB.BANCOOB_DIGITO);

            /*" -5659- MOVE DET9-TAXA-DESCONTO TO BANCOOB-TAXA-DESCON. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_TAXA_DESCONTO, REG_BANCOOB.BANCOOB_TAXA_DESCON);

            /*" -5661- MOVE DET9-TAXA-IOF TO BANCOOB-TAXA-IOF. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_TAXA_IOF, REG_BANCOOB.BANCOOB_TAXA_IOF);

            /*" -5663- MOVE DET9-CARTEIRA TO BANCOOB-CARTEIRA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_CARTEIRA, REG_BANCOOB.BANCOOB_CARTEIRA);

            /*" -5666- MOVE DET9-COMANDO TO BANCOOB-COMANDO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_COMANDO, REG_BANCOOB.BANCOOB_COMANDO);

            /*" -5667- MOVE DET9-DT-LIQUIDA TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DT_LIQUIDA, WS_DATA_SAP1);

            /*" -5669- MOVE WS-DD-SAP1 TO BANCOOB-DIA-LIQUIDA. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_BANCOOB.BANCOOB_DTLIQUIDA.BANCOOB_DIA_LIQUIDA);

            /*" -5671- MOVE WS-MM-SAP1 TO BANCOOB-MES-LIQUIDA. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_BANCOOB.BANCOOB_DTLIQUIDA.BANCOOB_MES_LIQUIDA);

            /*" -5674- MOVE WS-AA-SAP1 TO BANCOOB-ANO-LIQUIDA. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_BANCOOB.BANCOOB_DTLIQUIDA.BANCOOB_ANO_LIQUIDA);

            /*" -5677- MOVE DET9-SEU-NUMERO TO BANCOOB-SEU-NUMERO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_SEU_NUMERO, REG_BANCOOB.BANCOOB_SEU_NUMERO);

            /*" -5678- MOVE DET9-DT-VENCTO TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DT_VENCTO, WS_DATA_SAP1);

            /*" -5680- MOVE WS-DD-SAP1 TO BANCOOB-DIA-VENCTO. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_BANCOOB.BANCOOB_DTVENCTO.BANCOOB_DIA_VENCTO);

            /*" -5682- MOVE WS-MM-SAP1 TO BANCOOB-MES-VENCTO. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_BANCOOB.BANCOOB_DTVENCTO.BANCOOB_MES_VENCTO);

            /*" -5685- MOVE WS-AA-SAP1 TO BANCOOB-ANO-VENCTO. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_BANCOOB.BANCOOB_DTVENCTO.BANCOOB_ANO_VENCTO);

            /*" -5687- MOVE DET9-VALOR-TITULO TO BANCOOB-VLR-NOMINAL-TIT */
            _.Move(DET_REGISTRO.DET_REG9.DET9_VALOR_TITULO, REG_BANCOOB.BANCOOB_VLR_NOMINAL_TIT);

            /*" -5689- MOVE DET9-BANCO TO BANCOOB-COD-BANCO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_BANCO, REG_BANCOOB.BANCOOB_COD_BANCO);

            /*" -5691- MOVE DET9-AGE-COBR TO BANCOOB-AGE-COBR. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_AGE_COBR, REG_BANCOOB.BANCOOB_AGE_COBR);

            /*" -5693- MOVE DET9-DIG-COBR TO BANCOOB-AGE-DIG-COBR. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DIG_COBR, REG_BANCOOB.BANCOOB_AGE_DIG_COBR);

            /*" -5696- MOVE DET9-ESPECIE TO BANCOOB-ESPECIE. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_ESPECIE, REG_BANCOOB.BANCOOB_ESPECIE);

            /*" -5697- MOVE DET9-DT-CREDITO TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DT_CREDITO, WS_DATA_SAP1);

            /*" -5699- MOVE WS-DD-SAP1 TO BANCOOB-DIA-CRED. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_BANCOOB.BANCOOB_DATA_CREDITO.BANCOOB_DIA_CRED);

            /*" -5701- MOVE WS-MM-SAP1 TO BANCOOB-MES-CRED. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_BANCOOB.BANCOOB_DATA_CREDITO.BANCOOB_MES_CRED);

            /*" -5704- MOVE WS-AA-SAP1 TO BANCOOB-ANO-CRED. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_BANCOOB.BANCOOB_DATA_CREDITO.BANCOOB_ANO_CRED);

            /*" -5706- MOVE DET9-VLR-TARIFA TO BANCOOB-VLR-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_VLR_TARIFA, REG_BANCOOB.BANCOOB_VLR_TARIFA);

            /*" -5708- MOVE DET9-OUT-DESPESAS TO BANCOOB-VLR-DESPESAS. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_OUT_DESPESAS, REG_BANCOOB.BANCOOB_VLR_DESPESAS);

            /*" -5710- MOVE DET9-JUROS TO BANCOOB-VLR-JUROS. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_JUROS, REG_BANCOOB.BANCOOB_VLR_JUROS);

            /*" -5712- MOVE DET9-VALOR-IOF TO BANCOOB-VLR-IOF. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_VALOR_IOF, REG_BANCOOB.BANCOOB_VLR_IOF);

            /*" -5714- MOVE DET9-ABATIMENTO TO BANCOOB-VLR-ABATIMENTO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_ABATIMENTO, REG_BANCOOB.BANCOOB_VLR_ABATIMENTO);

            /*" -5716- MOVE DET9-DESCONTO TO BANCOOB-VLR-DESCONTO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_DESCONTO, REG_BANCOOB.BANCOOB_VLR_DESCONTO);

            /*" -5718- MOVE DET9-VLR-RECEBIDO TO BANCOOB-VLR-RECEBIDO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_VLR_RECEBIDO, REG_BANCOOB.BANCOOB_VLR_RECEBIDO);

            /*" -5720- MOVE DET9-MORA TO BANCOOB-VLR-MORA. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_MORA, REG_BANCOOB.BANCOOB_VLR_MORA);

            /*" -5722- MOVE DET9-OUT-RECEBE TO BANCOOB-VLR-OUTROS. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_OUT_RECEBE, REG_BANCOOB.BANCOOB_VLR_OUTROS);

            /*" -5724- MOVE ZEROS TO BANCOOB-VLR-ABATNAO. */
            _.Move(0, REG_BANCOOB.BANCOOB_VLR_ABATNAO);

            /*" -5726- MOVE DET9-VLR-LANCADO TO BANCOOB-VLR-LANCADO. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_VLR_LANCADO, REG_BANCOOB.BANCOOB_VLR_LANCADO);

            /*" -5728- MOVE ZEROS TO BANCOOB-IND-DEBCRE. */
            _.Move(0, REG_BANCOOB.BANCOOB_IND_DEBCRE);

            /*" -5730- MOVE DET9-INDICA-VLR TO BANCOOB-IND-VALOR. */
            _.Move(DET_REGISTRO.DET_REG9.DET9_INDICA_VLR, REG_BANCOOB.BANCOOB_IND_VALOR);

            /*" -5733- MOVE ZEROS TO BANCOOB-VLR-AJUSTE. */
            _.Move(0, REG_BANCOOB.BANCOOB_VLR_AJUSTE);

            /*" -5736- MOVE DET-NSA-BCO TO BANCOOB-NSAC. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_BANCOOB.BANCOOB_NSAC);

            /*" -5738- WRITE REG-SAIDA9 FROM REG-BANCOOB. */
            _.Move(REG_BANCOOB.GetMoveValues(), REG_SAIDA9);

            SAIDA9.Write(REG_SAIDA9.GetMoveValues().ToString());

            /*" -5738- ADD 1 TO AC-GRAV-SAIDA9. */
            W.AC_GRAV_SAIDA9.Value = W.AC_GRAV_SAIDA9 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3500_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-TRATA-SICOB-SECTION */
        private void R4000_00_TRATA_SICOB_SECTION()
        {
            /*" -5752- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5754- ADD 1 TO TT-SICOB. */
            W.TT_SICOB.Value = W.TT_SICOB + 1;

            /*" -5757- MOVE 1 TO SICOB-COD-REGISTRO. */
            _.Move(1, REG_SICOB.SICOB_COD_REGISTRO);

            /*" -5758- MOVE DET5-DT-GERACAO TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_DT_GERACAO, WS_DATA_SAP1);

            /*" -5760- MOVE WS-DD-SAP1 TO SICOB-DIA-HEADER. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_SICOB.SICOB_DTGERACAO.SICOB_DIA_HEADER);

            /*" -5762- MOVE WS-MM-SAP1 TO SICOB-MES-HEADER. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_SICOB.SICOB_DTGERACAO.SICOB_MES_HEADER);

            /*" -5765- MOVE WS-AA-SAP1 TO SICOB-ANO-HEADER. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_SICOB.SICOB_DTGERACAO.SICOB_ANO_HEADER);

            /*" -5768- MOVE DET5-COD-BANCO TO SICOB-COD-BANCO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_COD_BANCO, REG_SICOB.SICOB_COD_BANCO);

            /*" -5771- MOVE DET5-TP-INSCR TO SICOB-TIPO-INSCRICAO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_TP_INSCR, REG_SICOB.SICOB_TIPO_INSCRICAO);

            /*" -5774- MOVE DET5-NRO-INSCR TO SICOB-NUM-INSCRICAO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_NRO_INSCR, REG_SICOB.SICOB_NUM_INSCRICAO);

            /*" -5777- MOVE DET5-COD-CEDENTE TO SICOB-COD-CEDENTE. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_COD_CEDENTE, REG_SICOB.SICOB_COD_CEDENTE);

            /*" -5780- MOVE DET5-TITU-EMP TO SICOB-TITULO-EMPRESA. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_TITU_EMP, REG_SICOB.SICOB_TITULO_EMPRESA);

            /*" -5783- MOVE DET5-TITU-BCO TO SICOB-TITULO-BANCO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_TITU_BCO, REG_SICOB.SICOB_TITULO_BANCO);

            /*" -5786- MOVE DET5-COD-REJ TO SICOB-COD-REJEICAO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_COD_REJ, REG_SICOB.SICOB_COD_REJEICAO);

            /*" -5789- MOVE DET5-COD-OCORR TO SICOB-COD-OCORRENCIA. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_COD_OCORR, REG_SICOB.SICOB_COD_OCORRENCIA);

            /*" -5790- MOVE DET5-DT-OCORR TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_DT_OCORR, WS_DATA_SAP1);

            /*" -5792- MOVE WS-DD-SAP1 TO SICOB-DIA-OCORR. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_SICOB.SICOB_DATA_OCORRENCIA.SICOB_DIA_OCORR);

            /*" -5794- MOVE WS-MM-SAP1 TO SICOB-MES-OCORR. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_SICOB.SICOB_DATA_OCORRENCIA.SICOB_MES_OCORR);

            /*" -5797- MOVE WS-AA-SAP1 TO SICOB-ANO-OCORR. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_SICOB.SICOB_DATA_OCORRENCIA.SICOB_ANO_OCORR);

            /*" -5798- MOVE DET5-DT-VENCTO TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_DT_VENCTO, WS_DATA_SAP1);

            /*" -5800- MOVE WS-DD-SAP1 TO SICOB-DIA-VENCTO. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_SICOB.SICOB_DATA_VENCIMENTO.SICOB_DIA_VENCTO);

            /*" -5802- MOVE WS-MM-SAP1 TO SICOB-MES-VENCTO. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_SICOB.SICOB_DATA_VENCIMENTO.SICOB_MES_VENCTO);

            /*" -5805- MOVE WS-AA-SAP1 TO SICOB-ANO-VENCTO. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_SICOB.SICOB_DATA_VENCIMENTO.SICOB_ANO_VENCTO);

            /*" -5808- MOVE DET5-VLR-NOMINAL TO SICOB-VLR-NOMINAL-TIT. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_NOMINAL, REG_SICOB.SICOB_VLR_NOMINAL_TIT);

            /*" -5811- MOVE DET5-COD-BCO-PAGTO TO SICOB-COD-COMP-CAIXA. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_COD_BCO_PAGTO, REG_SICOB.SICOB_COD_COMP_CAIXA);

            /*" -5814- MOVE DET5-AGE-PAGTO TO SICOB-AGE-COBR. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_AGE_PAGTO, REG_SICOB.SICOB_AGE_COBR);

            /*" -5817- MOVE DET5-DV-AGE-PAGTO TO SICOB-AGE-DIG-COBR. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_DV_AGE_PAGTO, REG_SICOB.SICOB_AGE_DIG_COBR);

            /*" -5820- MOVE DET5-ESPECIE TO SICOB-ESPECIE. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_ESPECIE, REG_SICOB.SICOB_ESPECIE);

            /*" -5823- MOVE DET5-VLR-TARIFA TO SICOB-VLR-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_TARIFA, REG_SICOB.SICOB_VLR_TARIFA);

            /*" -5826- MOVE DET5-FORMA-LIQ TO SICOB-FORMA-LIQUIDACAO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_FORMA_LIQ, REG_SICOB.SICOB_FORMA_LIQUIDACAO);

            /*" -5829- MOVE DET5-FORMA-PAGTO TO SICOB-FORMA-PAGAMENTO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_FORMA_PAGTO, REG_SICOB.SICOB_FORMA_PAGAMENTO);

            /*" -5832- MOVE DET5-QTD-DIAS-FLO TO SICOB-QTD-DIAS-FLOAT. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_QTD_DIAS_FLO, REG_SICOB.SICOB_QTD_DIAS_FLOAT);

            /*" -5833- MOVE DET5-DT-DEB-TARIFA TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_DT_DEB_TARIFA, WS_DATA_SAP1);

            /*" -5835- MOVE WS-DD-SAP1 TO SICOB-DIA-TARIFA. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_SICOB.SICOB_DATA_DEB_TARIFA.SICOB_DIA_TARIFA);

            /*" -5837- MOVE WS-MM-SAP1 TO SICOB-MES-TARIFA. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_SICOB.SICOB_DATA_DEB_TARIFA.SICOB_MES_TARIFA);

            /*" -5840- MOVE WS-AA-SAP1 TO SICOB-ANO-TARIFA. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_SICOB.SICOB_DATA_DEB_TARIFA.SICOB_ANO_TARIFA);

            /*" -5843- MOVE DET5-VLR-IOF TO SICOB-VLR-IOF. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_IOF, REG_SICOB.SICOB_VLR_IOF);

            /*" -5846- MOVE DET5-VLR-ABATIMEN TO SICOB-VLR-ABATIMENTO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_ABATIMEN, REG_SICOB.SICOB_VLR_ABATIMENTO);

            /*" -5849- MOVE DET5-VLR-DESCTO TO SICOB-VLR-DESCONTO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_DESCTO, REG_SICOB.SICOB_VLR_DESCONTO);

            /*" -5852- MOVE DET5-VLR-PRINC TO SICOB-VLR-PRINCIPAL. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_PRINC, REG_SICOB.SICOB_VLR_PRINCIPAL);

            /*" -5855- MOVE DET5-VLR-JUROS TO SICOB-VLR-JUROS. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_JUROS, REG_SICOB.SICOB_VLR_JUROS);

            /*" -5858- MOVE DET5-VLR-MULTA TO SICOB-VLR-MULTA. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_VLR_MULTA, REG_SICOB.SICOB_VLR_MULTA);

            /*" -5861- MOVE DET5-COD-MOEDA TO SICOB-COD-MOEDA. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_COD_MOEDA, REG_SICOB.SICOB_COD_MOEDA);

            /*" -5862- MOVE DET5-DT-CREDITO TO WS-DATA-SAP1. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_DT_CREDITO, WS_DATA_SAP1);

            /*" -5864- MOVE WS-DD-SAP1 TO SICOB-DIA-CRED. */
            _.Move(WS_DATA_SAP1.WS_DD_SAP1, REG_SICOB.SICOB_DATA_CREDITO.SICOB_DIA_CRED);

            /*" -5866- MOVE WS-MM-SAP1 TO SICOB-MES-CRED. */
            _.Move(WS_DATA_SAP1.WS_MM_SAP1, REG_SICOB.SICOB_DATA_CREDITO.SICOB_MES_CRED);

            /*" -5869- MOVE WS-AA-SAP1 TO SICOB-ANO-CRED. */
            _.Move(WS_DATA_SAP1.WS_AA_SAP1, REG_SICOB.SICOB_DATA_CREDITO.SICOB_ANO_CRED);

            /*" -5872- MOVE DET5-FINANCEIRO TO SICOB-FINANCEIRO. */
            _.Move(DET_REGISTRO.DET_REG5.DET5_FINANCEIRO, REG_SICOB.SICOB_FINANCEIRO);

            /*" -5875- MOVE DET-NSA-BCO TO SICOB-NSAC. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_SICOB.SICOB_NSAC);

            /*" -5877- WRITE REG-SAIDA3 FROM REG-SICOB. */
            _.Move(REG_SICOB.GetMoveValues(), REG_SAIDA3);

            SAIDA3.Write(REG_SAIDA3.GetMoveValues().ToString());

            /*" -5877- ADD 1 TO AC-GRAV-SAIDA3. */
            W.AC_GRAV_SAIDA3.Value = W.AC_GRAV_SAIDA3 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-TRATA-SIGPF-SECTION */
        private void R5000_00_TRATA_SIGPF_SECTION()
        {
            /*" -5891- MOVE '5000' TO WNR-EXEC-SQL. */
            _.Move("5000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5893- ADD 1 TO TT-SIGPF. */
            W.TT_SIGPF.Value = W.TT_SIGPF + 1;

            /*" -5896- MOVE ZEROS TO SIGPF-CONVENIO-SAP. */
            _.Move(0, REG_SIGPF.SIGPF_CONVENIO_SAP);

            /*" -5897- MOVE DET6-DT-GERACAO TO WS-DATA-SAP */
            _.Move(DET_REGISTRO.DET_REG6.DET6_DT_GERACAO, WS_DATA_SAP);

            /*" -5899- MOVE WS-DD-SAP TO SIGPF-DIA-HEADER. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, REG_SIGPF.SIGPF_DTGERACAO.SIGPF_DIA_HEADER);

            /*" -5901- MOVE WS-MM-SAP TO SIGPF-MES-HEADER. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, REG_SIGPF.SIGPF_DTGERACAO.SIGPF_MES_HEADER);

            /*" -5904- MOVE WS-AA-SAP TO SIGPF-ANO-HEADER. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, REG_SIGPF.SIGPF_DTGERACAO.SIGPF_ANO_HEADER);

            /*" -5907- MOVE 3 TO SIGPF-COD-REGISTRO. */
            _.Move(3, REG_SIGPF.SIGPF_COD_REGISTRO);

            /*" -5910- MOVE DET6-NRO-SIVPF TO SIGPF-NUM-SIVPF. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_NRO_SIVPF, REG_SIGPF.SIGPF_NUM_SIVPF);

            /*" -5913- MOVE DET6-AGENCIA TO SIGPF-AGENCIA. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_AGENCIA, REG_SIGPF.SIGPF_AGENCIA);

            /*" -5916- MOVE DET6-OPERACAO TO SIGPF-OPERACAO. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_OPERACAO, REG_SIGPF.SIGPF_OPERACAO);

            /*" -5919- MOVE DET6-CONTA TO SIGPF-NUM-CONTA. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_CONTA, REG_SIGPF.SIGPF_NUM_CONTA);

            /*" -5922- MOVE DET6-DV-CONTA TO SIGPF-DIG-CONTA. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_DV_CONTA, REG_SIGPF.SIGPF_DIG_CONTA);

            /*" -5925- MOVE DET6-VLR-PAGO TO SIGPF-VALOR-PAGO. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_VLR_PAGO, REG_SIGPF.SIGPF_VALOR_PAGO);

            /*" -5928- MOVE DET6-VLR-BALCAO TO SIGPF-VALOR-BALCAO. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_VLR_BALCAO, REG_SIGPF.SIGPF_VALOR_BALCAO);

            /*" -5931- MOVE DET6-VLR-TARIFA TO SIGPF-VALOR-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG6.DET6_VLR_TARIFA, REG_SIGPF.SIGPF_VALOR_TARIFA);

            /*" -5932- MOVE DET6-DT-PAGTO TO WS-DATA-SAP */
            _.Move(DET_REGISTRO.DET_REG6.DET6_DT_PAGTO, WS_DATA_SAP);

            /*" -5934- MOVE WS-DD-SAP TO SIGPF-DIA-PAGTO. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, REG_SIGPF.SIGPF_DATA_PAGTO.SIGPF_DIA_PAGTO);

            /*" -5936- MOVE WS-MM-SAP TO SIGPF-MES-PAGTO. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, REG_SIGPF.SIGPF_DATA_PAGTO.SIGPF_MES_PAGTO);

            /*" -5939- MOVE WS-AA-SAP TO SIGPF-ANO-PAGTO. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, REG_SIGPF.SIGPF_DATA_PAGTO.SIGPF_ANO_PAGTO);

            /*" -5940- MOVE DET6-DT-CREDITO TO WS-DATA-SAP */
            _.Move(DET_REGISTRO.DET_REG6.DET6_DT_CREDITO, WS_DATA_SAP);

            /*" -5942- MOVE WS-DD-SAP TO SIGPF-DIA-CRED. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, REG_SIGPF.SIGPF_DATA_CREDITO.SIGPF_DIA_CRED);

            /*" -5944- MOVE WS-MM-SAP TO SIGPF-MES-CRED. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, REG_SIGPF.SIGPF_DATA_CREDITO.SIGPF_MES_CRED);

            /*" -5947- MOVE WS-AA-SAP TO SIGPF-ANO-CRED. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, REG_SIGPF.SIGPF_DATA_CREDITO.SIGPF_ANO_CRED);

            /*" -5950- MOVE DET-NSA-BCO TO SIGPF-NSAC. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_SIGPF.SIGPF_NSAC);

            /*" -5952- WRITE REG-SAIDA4 FROM REG-SIGPF. */
            _.Move(REG_SIGPF.GetMoveValues(), REG_SAIDA4);

            SAIDA4.Write(REG_SAIDA4.GetMoveValues().ToString());

            /*" -5952- ADD 1 TO AC-GRAV-SAIDA4. */
            W.AC_GRAV_SAIDA4.Value = W.AC_GRAV_SAIDA4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5500-00-TRATA-DET13-SECTION */
        private void R5500_00_TRATA_DET13_SECTION()
        {
            /*" -5965- MOVE '5500' TO WNR-EXEC-SQL. */
            _.Move("5500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -5967- ADD 1 TO TT-DET13. */
            W.TT_DET13.Value = W.TT_DET13 + 1;

            /*" -5968- INITIALIZE REG-SIGC13. */
            _.Initialize(
                MOVCC_REGISTRO.REG_SIGC13
            );

            /*" -5973- INITIALIZE REGISTRO-LINKAGE-GE0350S. */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
            );

            /*" -5974- MOVE WHOST-DATA-EM TO WDATA-REL */
            _.Move(WHOST_DATA_EM, WDATA_REL);

            /*" -5975- MOVE WDAT-REL-DIA TO WS-DD-SAP */
            _.Move(FILLER_56.WDAT_REL_DIA, WS_DATA_SAP.WS_DD_SAP);

            /*" -5976- MOVE WDAT-REL-MES TO WS-MM-SAP */
            _.Move(FILLER_56.WDAT_REL_MES, WS_DATA_SAP.WS_MM_SAP);

            /*" -5977- MOVE WDAT-REL-ANO TO WS-AA-SAP */
            _.Move(FILLER_56.WDAT_REL_ANO, WS_DATA_SAP.WS_AA_SAP);

            /*" -5979- MOVE WS-DATA-SAP TO SIGC13-DTA-GERACAO */
            _.Move(WS_DATA_SAP, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_GERACAO);

            /*" -5981- IF (DET13-DTA-VENCIMENTO EQUAL '00000000' ) OR (DET13-DTA-VENCIMENTO EQUAL SPACES) */

            if ((DET_REGISTRO.DET_REG13.DET13_DTA_VENCIMENTO == "00000000") || (DET_REGISTRO.DET_REG13.DET13_DTA_VENCIMENTO.IsEmpty()))
            {

                /*" -5982- MOVE WS-DATA-SAP TO DET13-DTA-VENCIMENTO */
                _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG13.DET13_DTA_VENCIMENTO);

                /*" -5984- END-IF */
            }


            /*" -5986- IF (DET13-DTA-PAGAMENTO EQUAL '00000000' ) OR (DET13-DTA-PAGAMENTO EQUAL SPACES) */

            if ((DET_REGISTRO.DET_REG13.DET13_DTA_PAGAMENTO == "00000000") || (DET_REGISTRO.DET_REG13.DET13_DTA_PAGAMENTO.IsEmpty()))
            {

                /*" -5987- MOVE WS-DATA-SAP TO DET13-DTA-PAGAMENTO */
                _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG13.DET13_DTA_PAGAMENTO);

                /*" -5989- END-IF */
            }


            /*" -5991- IF (DET13-DTA-CREDITO EQUAL '00000000' ) OR (DET13-DTA-CREDITO EQUAL SPACES) */

            if ((DET_REGISTRO.DET_REG13.DET13_DTA_CREDITO == "00000000") || (DET_REGISTRO.DET_REG13.DET13_DTA_CREDITO.IsEmpty()))
            {

                /*" -5992- MOVE WS-DATA-SAP TO DET13-DTA-CREDITO */
                _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG13.DET13_DTA_CREDITO);

                /*" -5994- END-IF */
            }


            /*" -5996- IF (DET13-DTA-DEB-TARIFA EQUAL '00000000' ) OR (DET13-DTA-DEB-TARIFA EQUAL SPACES) */

            if ((DET_REGISTRO.DET_REG13.DET13_DTA_DEB_TARIFA == "00000000") || (DET_REGISTRO.DET_REG13.DET13_DTA_DEB_TARIFA.IsEmpty()))
            {

                /*" -5997- MOVE WS-DATA-SAP TO DET13-DTA-DEB-TARIFA */
                _.Move(WS_DATA_SAP, DET_REGISTRO.DET_REG13.DET13_DTA_DEB_TARIFA);

                /*" -5999- END-IF */
            }


            /*" -6000- MOVE DET13-DTA-VENCIMENTO TO SIGC13-DTA-VENCIMENTO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_DTA_VENCIMENTO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_VENCIMENTO);

            /*" -6001- MOVE DET13-DTA-PAGAMENTO TO SIGC13-DTA-PAGAMENTO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_DTA_PAGAMENTO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_PAGAMENTO);

            /*" -6002- MOVE DET13-DTA-CREDITO TO SIGC13-DTA-CREDITO. */
            _.Move(DET_REGISTRO.DET_REG13.DET13_DTA_CREDITO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_CREDITO);

            /*" -6004- MOVE DET13-DTA-DEB-TARIFA TO SIGC13-DTA-DEB-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG13.DET13_DTA_DEB_TARIFA, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_DEB_TARIFA);

            /*" -6005- MOVE DET-TIPREG TO SIGC13-TIPO-REGISTRO */
            _.Move(DET_REGISTRO.DET_TIPREG, MOVCC_REGISTRO.REG_SIGC13.SIGC13_TIPO_REGISTRO);

            /*" -6006- MOVE DET-SEQREG TO SIGC13-SEQ-REGISTRO */
            _.Move(DET_REGISTRO.DET_SEQREG, MOVCC_REGISTRO.REG_SIGC13.SIGC13_SEQ_REGISTRO);

            /*" -6007- MOVE DET-IDLG TO SIGC13-IDLG */
            _.Move(DET_REGISTRO.DET_IDLG, MOVCC_REGISTRO.REG_SIGC13.SIGC13_IDLG);

            /*" -6009- MOVE DET-BUKRS TO SIGC13-BUKRS */
            _.Move(DET_REGISTRO.DET_BUKRS, MOVCC_REGISTRO.REG_SIGC13.SIGC13_BUKRS);

            /*" -6010- MOVE DET13-NUM-PROPOSTA TO SIGC13-NUM-PROPOSTA */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NUM_PROPOSTA, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_PROPOSTA);

            /*" -6011- MOVE DET13-NUM-BOL-INTERNO TO SIGC13-NUM-BOL-INTERNO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NUM_BOL_INTERNO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_BOL_INTERNO);

            /*" -6012- MOVE DET13-NN-REGISTRADO TO SIGC13-NN-REGISTRADO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NN_REGISTRADO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NN_REGISTRADO);

            /*" -6013- MOVE DET13-LNHA-DIGITAVEL TO SIGC13-LNHA-DIGITAVEL */
            _.Move(DET_REGISTRO.DET_REG13.DET13_LNHA_DIGITAVEL, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_LNHA_DIGITAVEL);

            /*" -6017- MOVE DET13-COD-AG-CEDENTE TO SIGC13-COD-AG-CEDENTE WS-COD-AG-CEDENTE. */
            _.Move(DET_REGISTRO.DET_REG13.DET13_COD_AG_CEDENTE, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_AG_CEDENTE, WS_COD_AG_CEDENTE);

            /*" -6018-  EVALUATE TRUE  */

            /*" -6019-  WHEN WS-COD-CEDENTE        = 976545  */

            /*" -6019- IF WS-COD-CEDENTE        = 976545 */

            if (WS_CEDENTE_R.WS_COD_CEDENTE == 976545)
            {

                /*" -6020- MOVE 696001 TO WS-COD-CEDENTE */
                _.Move(696001, WS_CEDENTE_R.WS_COD_CEDENTE);

                /*" -6021-  WHEN WS-COD-CEDENTE        = 976548  */

                /*" -6021- ELSE IF WS-COD-CEDENTE        = 976548 */
            }
            else

            if (WS_CEDENTE_R.WS_COD_CEDENTE == 976548)
            {

                /*" -6022- MOVE 696005 TO WS-COD-CEDENTE */
                _.Move(696005, WS_CEDENTE_R.WS_COD_CEDENTE);

                /*" -6023-  WHEN WS-COD-CEDENTE        = 976556  */

                /*" -6023- ELSE IF WS-COD-CEDENTE        = 976556 */
            }
            else

            if (WS_CEDENTE_R.WS_COD_CEDENTE == 976556)
            {

                /*" -6024- MOVE 933828 TO WS-COD-CEDENTE */
                _.Move(933828, WS_CEDENTE_R.WS_COD_CEDENTE);

                /*" -6025-  WHEN WS-COD-CEDENTE        = 976557  */

                /*" -6025- ELSE IF WS-COD-CEDENTE        = 976557 */
            }
            else

            if (WS_CEDENTE_R.WS_COD_CEDENTE == 976557)
            {

                /*" -6026- MOVE 974800 TO WS-COD-CEDENTE */
                _.Move(974800, WS_CEDENTE_R.WS_COD_CEDENTE);

                /*" -6028-  END-EVALUATE  */

                /*" -6028- END-IF */
            }


            /*" -6031- MOVE WS-COD-AG-CEDENTE TO SIGC13-COD-AG-CEDENTE. */
            _.Move(WS_COD_AG_CEDENTE, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_AG_CEDENTE);

            /*" -6032- MOVE DET13-NUM-BCO-RECEB TO SIGC13-NUM-BCO-RECEB */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NUM_BCO_RECEB, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_BCO_RECEB);

            /*" -6033- MOVE DET13-NUM-AGE-RECEB TO SIGC13-NUM-AGE-RECEB */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NUM_AGE_RECEB, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_AGE_RECEB);

            /*" -6034- MOVE DET13-DV-AGE-RECEB TO SIGC13-DV-AGE-RECEB */
            _.Move(DET_REGISTRO.DET_REG13.DET13_DV_AGE_RECEB, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DV_AGE_RECEB);

            /*" -6035- MOVE DET13-VLR-ACRESCIMO TO SIGC13-VLR-ACRESCIMO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_ACRESCIMO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_ACRESCIMO);

            /*" -6036- MOVE DET13-VLR-DESCONTO TO SIGC13-VLR-DESCONTO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_DESCONTO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_DESCONTO);

            /*" -6037- MOVE DET13-VLR-ABATIMENTO TO SIGC13-VLR-ABATIMENTO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_ABATIMENTO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_ABATIMENTO);

            /*" -6038- MOVE DET13-VLR-IOF TO SIGC13-VLR-IOF */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_IOF, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_IOF);

            /*" -6039- MOVE DET13-VLR-PAGO TO SIGC13-VLR-PAGO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_PAGO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_PAGO);

            /*" -6040- MOVE DET13-VLR-LIQUIDO TO SIGC13-VLR-LIQUIDO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_LIQUIDO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_LIQUIDO);

            /*" -6041- MOVE DET13-VLR-TARIFA TO SIGC13-VLR-TARIFA */
            _.Move(DET_REGISTRO.DET_REG13.DET13_VLR_TARIFA, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_TARIFA);

            /*" -6042- MOVE DET13-COD-MOVIMENTO TO SIGC13-COD-MOVIMENTO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_MOVIMENTO);

            /*" -6044- MOVE DET13-COD-REJEICAO TO SIGC13-COD-REJEICAO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_COD_REJEICAO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_REJEICAO);

            /*" -6046- IF DET-BUKRS NOT EQUAL 'C000' AND NOT EQUAL 'C010' */

            if (!DET_REGISTRO.DET_BUKRS.In("C000", "C010"))
            {

                /*" -6047- ADD 1 TO DP-DET13 */
                W.DP_DET13.Value = W.DP_DET13 + 1;

                /*" -6048- GO TO R5500-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/ //GOTO
                return;

                /*" -6050- END-IF. */
            }


            /*" -6052- MOVE DET-IDLG TO WS-IDLG-VIDA */
            _.Move(DET_REGISTRO.DET_IDLG, WS_IDLG_VIDA);

            /*" -6054- PERFORM R5600-CONSULTA-NN-CNTRLE */

            R5600_CONSULTA_NN_CNTRLE_SECTION();

            /*" -6055- IF (WS-FLAG-TEM-NN-CNTRLE EQUAL 'N' ) */

            if ((W.WS_FLAG_TEM_NN_CNTRLE == "N"))
            {

                /*" -6056- PERFORM R5700-PESQUISA-IDLG-DEB-CONTA */

                R5700_PESQUISA_IDLG_DEB_CONTA_SECTION();

                /*" -6057- PERFORM R5610-INSERT-CNTRLE-SIGCB */

                R5610_INSERT_CNTRLE_SIGCB_SECTION();

                /*" -6058- ELSE */
            }
            else
            {


                /*" -6059- PERFORM R5620-ALTERA-SIT-CNTRLE-SIGCB */

                R5620_ALTERA_SIT_CNTRLE_SIGCB_SECTION();

                /*" -6061- END-IF. */
            }


            /*" -6062- IF (DET13-COD-MOVIMENTO EQUAL 02 OR 03 OR 09) */

            if ((DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO.In("02", "03", "09")))
            {

                /*" -6063- ADD 1 TO TT-DET13-CNTRLE */
                W.TT_DET13_CNTRLE.Value = W.TT_DET13_CNTRLE + 1;

                /*" -6064- GO TO R5500-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/ //GOTO
                return;

                /*" -6066- END-IF */
            }


            /*" -6067- MOVE LK-GE350-NUM-TITULO TO SIGC13-NUM-TITULO */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_TITULO);

            /*" -6068- MOVE LK-GE350-IDE-SISTEMA TO SIGC13-COD-SISTEMA */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_SISTEMA);

            /*" -6069- MOVE LK-GE350-NUM-PARCELA TO SIGC13-NUM-PARCELA */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_PARCELA);

            /*" -6071- MOVE LK-GE350-COD-PRODUTO TO SIGC13-COD-PRODUTO */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO, MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_PRODUTO);

            /*" -6073- WRITE REG-SAIDA15 FROM REG-SIGC13. */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.GetMoveValues(), REG_SAIDA15);

            SAIDA15.Write(REG_SAIDA15.GetMoveValues().ToString());

            /*" -6074- ADD 1 TO AC-GRAV-SAIDA15. */
            W.AC_GRAV_SAIDA15.Value = W.AC_GRAV_SAIDA15 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5500_99_SAIDA*/

        [StopWatch]
        /*" R5550-00-TRATA-DET15-SECTION */
        private void R5550_00_TRATA_DET15_SECTION()
        {
            /*" -6084- MOVE '5550' TO WNR-EXEC-SQL. */
            _.Move("5550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6086- ADD 1 TO TT-DET15. */
            W.TT_DET15.Value = W.TT_DET15 + 1;

            /*" -6089- MOVE WS-IDLG-CONV TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_16.WS_IDLG_CONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -6092- MOVE WS-IDLG-NSA TO MOVDEBCE-NSAS. */
            _.Move(FILLER_16.WS_IDLG_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -6095- MOVE WS-IDLG-NRSEQ TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(FILLER_16.WS_IDLG_NRSEQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -6097- PERFORM R1900-00-SELECT-MOVDEBCC. */

            R1900_00_SELECT_MOVDEBCC_SECTION();

            /*" -6098- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -6099- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -6100- GO TO R5550-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R5550_99_SAIDA*/ //GOTO
                return;

                /*" -6102- END-IF. */
            }


            /*" -6104- INITIALIZE REG-CESTA-DET. */
            _.Initialize(
                REG_CESTA_DET
            );

            /*" -6105- MOVE DET-TIPREG TO CESTA-D-TIPO-REGISTRO */
            _.Move(DET_REGISTRO.DET_TIPREG, REG_CESTA_DET.CESTA_D_TIPO_REGISTRO);

            /*" -6106- MOVE DET-SEQREG TO CESTA-D-SEQ-REGISTRO */
            _.Move(DET_REGISTRO.DET_SEQREG, REG_CESTA_DET.CESTA_D_SEQ_REGISTRO);

            /*" -6107- MOVE DET-IDLG TO CESTA-D-IDLG */
            _.Move(DET_REGISTRO.DET_IDLG, REG_CESTA_DET.CESTA_D_IDLG);

            /*" -6108- MOVE DET-AUGST TO CESTA-D-AUGST */
            _.Move(DET_REGISTRO.DET_AUGST, REG_CESTA_DET.CESTA_D_AUGST);

            /*" -6109- MOVE DET-AUGRD TO CESTA-D-AUGRD */
            _.Move(DET_REGISTRO.DET_AUGRD, REG_CESTA_DET.CESTA_D_AUGRD);

            /*" -6110- MOVE DET-BELNR TO CESTA-D-BELNR */
            _.Move(DET_REGISTRO.DET_BELNR, REG_CESTA_DET.CESTA_D_BELNR);

            /*" -6111- MOVE DET-BUZEI TO CESTA-D-BUZEI */
            _.Move(DET_REGISTRO.DET_BUZEI, REG_CESTA_DET.CESTA_D_BUZEI);

            /*" -6112- MOVE DET-OPBEL TO CESTA-D-OPBEL */
            _.Move(DET_REGISTRO.DET_OPBEL, REG_CESTA_DET.CESTA_D_OPBEL);

            /*" -6113- MOVE DET-OPUPK TO CESTA-D-OPUPK */
            _.Move(DET_REGISTRO.DET_OPUPK, REG_CESTA_DET.CESTA_D_OPUPK);

            /*" -6114- MOVE DET-AUGBL TO CESTA-D-AUGBL */
            _.Move(DET_REGISTRO.DET_AUGBL, REG_CESTA_DET.CESTA_D_AUGBL);

            /*" -6115- MOVE DET-AUGVD TO CESTA-D-AUGVD */
            _.Move(DET_REGISTRO.DET_AUGVD, REG_CESTA_DET.CESTA_D_AUGVD);

            /*" -6116- MOVE DET-BLART TO CESTA-D-BLART */
            _.Move(DET_REGISTRO.DET_BLART, REG_CESTA_DET.CESTA_D_BLART);

            /*" -6117- MOVE DET-BLDAT TO CESTA-D-BLDAT */
            _.Move(DET_REGISTRO.DET_BLDAT, REG_CESTA_DET.CESTA_D_BLDAT);

            /*" -6118- MOVE DET-BUDAT TO CESTA-D-BUDAT */
            _.Move(DET_REGISTRO.DET_BUDAT, REG_CESTA_DET.CESTA_D_BUDAT);

            /*" -6119- MOVE DET-BUKRS TO CESTA-D-BUKRS */
            _.Move(DET_REGISTRO.DET_BUKRS, REG_CESTA_DET.CESTA_D_BUKRS);

            /*" -6120- MOVE DET-NSA-BCO TO CESTA-D-NSA-BANCO */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_CESTA_DET.CESTA_D_NSA_BANCO);

            /*" -6121- MOVE DET15-DT-GERACAO TO CESTA-D-DT-GERACAO */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_DT_GERACAO, REG_CESTA_DET.CESTA_D_DT_GERACAO);

            /*" -6122- MOVE DET15-NUM-PROPPOSTA TO CESTA-D-NUM-PROPOSTA */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_NUM_PROPPOSTA, REG_CESTA_DET.CESTA_D_NUM_PROPOSTA);

            /*" -6123- MOVE DET15-AGENCIA-CLI TO CESTA-D-AGENCIA-CLI */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_AGENCIA_CLI, REG_CESTA_DET.CESTA_D_AGENCIA_CLI);

            /*" -6124- MOVE DET15-OPERACAO-CLI TO CESTA-D-OPERACAO-CLI */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_OPERACAO_CLI, REG_CESTA_DET.CESTA_D_OPERACAO_CLI);

            /*" -6125- MOVE DET15-CONTA-CLI TO CESTA-D-CONTA-CLI */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_CONTA_CLI, REG_CESTA_DET.CESTA_D_CONTA_CLI);

            /*" -6126- MOVE DET15-CONTA-DV-CLI TO CESTA-D-CONTA-DV-CLI */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_CONTA_DV_CLI, REG_CESTA_DET.CESTA_D_CONTA_DV_CLI);

            /*" -6127- MOVE DET15-VALOR-PAGO TO CESTA-D-VALOR-PAGO */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_VALOR_PAGO, REG_CESTA_DET.CESTA_D_VALOR_PAGO);

            /*" -6129- MOVE DET15-COD-RETORNO TO CESTA-D-COD-RETORNO MOVCC-CODRET */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_COD_RETORNO, REG_CESTA_DET.CESTA_D_COD_RETORNO, MOVCC_REGISTRO.FILLER_87.MOVCC_CODRET);

            /*" -6131- MOVE DET15-MSG-RETORNO TO CESTA-D-MSG-RETORNO */
            _.Move(DET_REGISTRO.DET_CESTA.DET15_MSG_RETORNO, REG_CESTA_DET.CESTA_D_MSG_RETORNO);

            /*" -6133- WRITE REG-SAIDA16 FROM REG-CESTA-DET. */
            _.Move(REG_CESTA_DET.GetMoveValues(), REG_SAIDA16);

            SAIDA16.Write(REG_SAIDA16.GetMoveValues().ToString());

            /*" -6135- ADD 1 TO AC-GRAV-SAIDA16. */
            W.AC_GRAV_SAIDA16.Value = W.AC_GRAV_SAIDA16 + 1;

            /*" -6136- IF DET15-COD-RETORNO EQUAL ZEROS */

            if (DET_REGISTRO.DET_CESTA.DET15_COD_RETORNO == 00)
            {

                /*" -6138- MOVE '00' TO MOVCC-RETORNO. */
                _.Move("00", MOVCC_REGISTRO.MOVCC_RETORNO);
            }


            /*" -6139- IF WS-IDLG-CONV EQUAL 608800 */

            if (FILLER_16.WS_IDLG_CONV == 608800)
            {

                /*" -6139- PERFORM R1100-00-UPDATE-V0MOVDEBCE. */

                R1100_00_UPDATE_V0MOVDEBCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5550_99_SAIDA*/

        [StopWatch]
        /*" R5600-CONSULTA-NN-CNTRLE-SECTION */
        private void R5600_CONSULTA_NN_CNTRLE_SECTION()
        {
            /*" -6151- MOVE '5600' TO WNR-EXEC-SQL. */
            _.Move("5600", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6154- INITIALIZE REGISTRO-LINKAGE-GE0350S DCLGE-CONTROLE-EMISSAO-SIGCB */
            _.Initialize(
                LBGE0350.REGISTRO_LINKAGE_GE0350S
                , GE403.DCLGE_CONTROLE_EMISSAO_SIGCB
            );

            /*" -6158- IF WS-COD-CEDENTE = 696005 OR CVPCV-696005 OR JV1CV-696005 */

            if (WS_CEDENTE_R.WS_COD_CEDENTE.In("696005", JVBKINCL.JV_CONVENIOS.CVPCV_696005.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_696005.ToString()))
            {

                /*" -6160- MOVE SIGC13-NN-REGISTRADO TO GE403-NUM-NOSSO-NUMERO-SAP */
                _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NN_REGISTRADO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP);

                /*" -6177- PERFORM R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1 */

                R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1();

                /*" -6181- IF SQLCODE NOT = 0 AND 100 AND -811 */

                if (!DB.SQLCODE.In("0", "100", "-811"))
                {

                    /*" -6182- DISPLAY '--------------------------------------' */
                    _.Display($"--------------------------------------");

                    /*" -6183- DISPLAY 'EM8006B - PROBLEMA NA LEITURA GE_CONTROLE' */
                    _.Display($"EM8006B - PROBLEMA NA LEITURA GE_CONTROLE");

                    /*" -6184- DISPLAY 'NUM-PROPOSTA ' GE403-NUM-PROPOSTA */
                    _.Display($"NUM-PROPOSTA {GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA}");

                    /*" -6185- DISPLAY 'NN           ' SIGC13-NN-REGISTRADO */
                    _.Display($"NN           {MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NN_REGISTRADO}");

                    /*" -6186- DISPLAY 'IDLG         ' SIGC13-IDLG */
                    _.Display($"IDLG         {MOVCC_REGISTRO.REG_SIGC13.SIGC13_IDLG}");

                    /*" -6187- DISPLAY '--------------------------------------' */
                    _.Display($"--------------------------------------");

                    /*" -6188- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6190- END-IF */
                }


                /*" -6191- IF GE403-COD-PRODUTO >= 3100 AND <= 3199 */

                if (GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO >= 3100 && GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO <= 3199)
                {

                    /*" -6192- MOVE 4000 TO LK-GE350-NUM-ENDOSSO */
                    _.Move(4000, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                    /*" -6194- END-IF */
                }


                /*" -6197- END-IF */
            }


            /*" -6201- MOVE 'N' TO WS-FLAG-DUP */
            _.Move("N", W.WS_FLAG_DUP);

            /*" -6203- MOVE 0 TO WS-FLAG-DIRID */
            _.Move(0, WS_FLAG_DIRID);

            /*" -6209- IF (WS-COD-CEDENTE = 696001) OR ( ( WS-COD-CEDENTE = 696005 OR CVPCV-696005 OR JV1CV-696005 ) AND LK-GE350-NUM-ENDOSSO = 4000 ) */

            if ((WS_CEDENTE_R.WS_COD_CEDENTE == 696001) || ((WS_CEDENTE_R.WS_COD_CEDENTE.In("696005", JVBKINCL.JV_CONVENIOS.CVPCV_696005.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_696005.ToString())) && LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO == 4000))
            {

                /*" -6210- MOVE 06 TO LK-GE350-COD-FUNCAO */
                _.Move(06, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

                /*" -6211- MOVE SIGC13-NN-REGISTRADO TO LK-GE350-NOSSO-NUMERO-SAP */
                _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NN_REGISTRADO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP);

                /*" -6212- MOVE 1 TO WS-FLAG-DIRID */
                _.Move(1, WS_FLAG_DIRID);

                /*" -6213- ELSE */
            }
            else
            {


                /*" -6214- MOVE 05 TO LK-GE350-COD-FUNCAO */
                _.Move(05, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

                /*" -6215- MOVE SIGC13-IDLG TO LK-GE350-NUM-IDLG */
                _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_IDLG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

                /*" -6217- END-IF */
            }


            /*" -6220- MOVE 'EM8006B' TO LK-GE350-COD-USUARIO */
            _.Move("EM8006B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -6222- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -6223- EVALUATE LK-GE350-COD-RETORNO */
            switch (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO.Value.Trim())
            {

                /*" -6224- WHEN '0' */
                case "0":

                    /*" -6225- WHEN '3' */
                    break;
                case "3":

                    /*" -6226- MOVE 'S' TO WS-FLAG-TEM-NN-CNTRLE */
                    _.Move("S", W.WS_FLAG_TEM_NN_CNTRLE);

                    /*" -6227- WHEN '2' */
                    break;
                case "2":

                    /*" -6228- MOVE 'N' TO WS-FLAG-TEM-NN-CNTRLE */
                    _.Move("N", W.WS_FLAG_TEM_NN_CNTRLE);

                    /*" -6229- WHEN OTHER */
                    break;
                default:

                    /*" -6230- MOVE 'S' TO WS-FLAG-DUP */
                    _.Move("S", W.WS_FLAG_DUP);

                    /*" -6233- END-EVALUATE. */
                    break;
            }


            /*" -6235- IF WS-FLAG-DIRID = 1 AND WS-FLAG-TEM-NN-CNTRLE = 'N' */

            if (WS_FLAG_DIRID == 1 && W.WS_FLAG_TEM_NN_CNTRLE == "N")
            {

                /*" -6236- MOVE 'S' TO WS-FLAG-DUP */
                _.Move("S", W.WS_FLAG_DUP);

                /*" -6238- END-IF */
            }


            /*" -6239- IF WS-FLAG-DUP EQUAL 'S' */

            if (W.WS_FLAG_DUP == "S")
            {

                /*" -6240- PERFORM R5601-RETORNO-IMPREVISTO */

                R5601_RETORNO_IMPREVISTO_SECTION();

                /*" -6240- END-IF. */
            }


        }

        [StopWatch]
        /*" R5600-CONSULTA-NN-CNTRLE-DB-SELECT-1 */
        public void R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1()
        {
            /*" -6177- EXEC SQL SELECT A.COD_PRODUTO INTO :GE403-COD-PRODUTO FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB A WHERE A.NUM_NOSSO_NUMERO_SAP = :GE403-NUM-NOSSO-NUMERO-SAP AND A.SEQ_CONTROLE_SIGCB = ( SELECT MAX(B.SEQ_CONTROLE_SIGCB) FROM SEGUROS.GE_CONTROLE_EMISSAO_SIGCB B WHERE B.NUM_PROPOSTA = A.NUM_PROPOSTA AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO ) WITH UR END-EXEC */

            var r5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1 = new R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1()
            {
                GE403_NUM_NOSSO_NUMERO_SAP = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_NOSSO_NUMERO_SAP.ToString(),
            };

            var executed_1 = R5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1.Execute(r5600_CONSULTA_NN_CNTRLE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE403_COD_PRODUTO, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5600_99_SAIDA*/

        [StopWatch]
        /*" R5601-RETORNO-IMPREVISTO-SECTION */
        private void R5601_RETORNO_IMPREVISTO_SECTION()
        {
            /*" -6251- MOVE '5601' TO WNR-EXEC-SQL. */
            _.Move("5601", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6252- MOVE SPACES TO WS-SQLCODE */
            _.Move("", W.WS_SQLCODE);

            /*" -6254- MOVE LK-GE350-SQLCODE TO WS-SQLCODE */
            _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE, W.WS_SQLCODE);

            /*" -6261- IF ( (LK-GE350-SQLCODE EQUAL -811 OR LK-GE350-SQLCODE EQUAL 811 OR (WS-SQLCODE EQUAL '-811' OR ' 811' OR '811' ) ) ) OR ( WS-FLAG-DIRID = 1 AND WS-FLAG-TEM-NN-CNTRLE = 'N' ) */

            if (((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE == -811 || LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE == 811 || (W.WS_SQLCODE.In("-811", " 811", "811")))) || (WS_FLAG_DIRID == 1 && W.WS_FLAG_TEM_NN_CNTRLE == "N"))
            {

                /*" -6263- INITIALIZE REGISTRO-LINKAGE-GE0350S */
                _.Initialize(
                    LBGE0350.REGISTRO_LINKAGE_GE0350S
                );

                /*" -6264- MOVE 5 TO LK-GE350-COD-FUNCAO */
                _.Move(5, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

                /*" -6265- MOVE SIGC13-IDLG TO LK-GE350-NUM-IDLG */
                _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_IDLG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

                /*" -6268- MOVE 'EM8006B' TO LK-GE350-COD-USUARIO */
                _.Move("EM8006B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

                /*" -6270- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S */
                _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

                /*" -6271- IF LK-GE350-COD-RETORNO EQUAL '0' OR '3' */

                if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO.In("0", "3"))
                {

                    /*" -6272- MOVE 'S' TO WS-FLAG-TEM-NN-CNTRLE */
                    _.Move("S", W.WS_FLAG_TEM_NN_CNTRLE);

                    /*" -6273- ELSE */
                }
                else
                {


                    /*" -6274- IF LK-GE350-COD-RETORNO EQUAL '2' */

                    if (LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO == "2")
                    {

                        /*" -6275- MOVE 'N' TO WS-FLAG-TEM-NN-CNTRLE */
                        _.Move("N", W.WS_FLAG_TEM_NN_CNTRLE);

                        /*" -6276- ELSE */
                    }
                    else
                    {


                        /*" -6277- MOVE SPACES TO WS-SQLCODE */
                        _.Move("", W.WS_SQLCODE);

                        /*" -6279- MOVE LK-GE350-SQLCODE TO WS-SQLCODE */
                        _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE, W.WS_SQLCODE);

                        /*" -6283- IF (LK-GE350-SQLCODE EQUAL -811 OR LK-GE350-SQLCODE EQUAL 811 OR (WS-SQLCODE EQUAL '-811' OR ' 811' OR '811' )) */

                        if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE == -811 || LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE == 811 || (W.WS_SQLCODE.In("-811", " 811", "811"))))
                        {

                            /*" -6285- MOVE 'N' TO WS-FLAG-TEM-NN-CNTRLE */
                            _.Move("N", W.WS_FLAG_TEM_NN_CNTRLE);

                            /*" -6286- DISPLAY '**************************************' */
                            _.Display($"**************************************");

                            /*" -6287- DISPLAY '* R5601-RETORNO-IMPREVISTO SQL -811  *' */
                            _.Display($"* R5601-RETORNO-IMPREVISTO SQL -811  *");

                            /*" -6288- DISPLAY '* ERRO NA EXECUCAO DO CALL DA GE0350S*' */
                            _.Display($"* ERRO NA EXECUCAO DO CALL DA GE0350S*");

                            /*" -6289- DISPLAY '**************************************' */
                            _.Display($"**************************************");

                            /*" -6290- DISPLAY '=> LK-MENSAGEM ...' LK-GE350-MENSAGEM */
                            _.Display($"=> LK-MENSAGEM ...{LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                            /*" -6291- DISPLAY '=> LK-COD-RETORNO ' LK-GE350-COD-RETORNO */
                            _.Display($"=> LK-COD-RETORNO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                            /*" -6292- DISPLAY '=> LK-SQLCODE..   ' LK-GE350-SQLCODE */
                            _.Display($"=> LK-SQLCODE..   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                            /*" -6293- DISPLAY '=> NN-SAP... ' LK-GE350-NOSSO-NUMERO-SAP */
                            _.Display($"=> NN-SAP... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                            /*" -6294- DISPLAY '=> IDLG  ... ' LK-GE350-NUM-IDLG */
                            _.Display($"=> IDLG  ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                            /*" -6295- DISPLAY '=> FLAG  ... ' WS-FLAG-TEM-NN-CNTRLE */
                            _.Display($"=> FLAG  ... {W.WS_FLAG_TEM_NN_CNTRLE}");

                            /*" -6296- ELSE */
                        }
                        else
                        {


                            /*" -6297- DISPLAY '*************************************' */
                            _.Display($"*************************************");

                            /*" -6298- DISPLAY '* R5601-RETORNO-IMPREVISTO  1      *' */
                            _.Display($"* R5601-RETORNO-IMPREVISTO  1      *");

                            /*" -6299- DISPLAY '* ERRO NA EXECUCAO DO CALL DA GE0350S*' */
                            _.Display($"* ERRO NA EXECUCAO DO CALL DA GE0350S*");

                            /*" -6300- DISPLAY '**************************************' */
                            _.Display($"**************************************");

                            /*" -6301- DISPLAY '=> LK-MENSAGEM ...' LK-GE350-MENSAGEM */
                            _.Display($"=> LK-MENSAGEM ...{LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                            /*" -6302- DISPLAY '=> LK-COD-RETORNO ' LK-GE350-COD-RETORNO */
                            _.Display($"=> LK-COD-RETORNO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                            /*" -6303- DISPLAY '=> LK-SQLCODE.....' LK-GE350-SQLCODE */
                            _.Display($"=> LK-SQLCODE.....{LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                            /*" -6304- DISPLAY '=> NN-SAP... ' LK-GE350-NOSSO-NUMERO-SAP */
                            _.Display($"=> NN-SAP... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                            /*" -6305- DISPLAY '=> IDLG  ... ' LK-GE350-NUM-IDLG */
                            _.Display($"=> IDLG  ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                            /*" -6306- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -6307- END-IF */
                        }


                        /*" -6308- END-IF */
                    }


                    /*" -6311- END-IF */
                }


                /*" -6312- ELSE */
            }
            else
            {


                /*" -6313- DISPLAY ' ' */
                _.Display($" ");

                /*" -6314- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6315- DISPLAY '*  R5601-CONSULTA-NN-CNTRLE      2.1    *' */
                _.Display($"*  R5601-CONSULTA-NN-CNTRLE      2.1    *");

                /*" -6316- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -6317- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6318- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -6319- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -6320- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -6321- DISPLAY '=> NUM-NN-SAP..... ' LK-GE350-NOSSO-NUMERO-SAP */
                _.Display($"=> NUM-NN-SAP..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP}");

                /*" -6322- DISPLAY '=> IDLG  ......... ' LK-GE350-NUM-IDLG */
                _.Display($"=> IDLG  ......... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -6323- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6324- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6325- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5601_99_SAIDA*/

        [StopWatch]
        /*" R5610-INSERT-CNTRLE-SIGCB-SECTION */
        private void R5610_INSERT_CNTRLE_SIGCB_SECTION()
        {
            /*" -6336- MOVE '5610' TO WNR-EXEC-SQL. */
            _.Move("5610", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6337- MOVE ZEROS TO LK-GE350-COD-RETORNO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO);

            /*" -6338- MOVE 02 TO LK-GE350-COD-FUNCAO */
            _.Move(02, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -6339- MOVE WS-NUM-APOLICE TO LK-GE350-NUM-APOLICE */
            _.Move(FILLER_101.WS_NUM_APOLICE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

            /*" -6340- MOVE WS-NUM-CERTIFICADO TO LK-GE350-NUM-CERTIFICADO */
            _.Move(FILLER_101.WS_NUM_CERTIFICADO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO);

            /*" -6341- MOVE WS-NUM-PARCELA TO LK-GE350-NUM-PARCELA */
            _.Move(FILLER_101.WS_NUM_PARCELA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

            /*" -6342- MOVE ZEROS TO LK-GE350-NUM-ENDOSSO */
            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

            /*" -6343- MOVE SIGC13-NUM-PROPOSTA TO LK-GE350-NUM-PROPOSTA */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_PROPOSTA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA);

            /*" -6344- MOVE WHOST-DATA-EM TO LK-GE350-DTA-MOVIMENTO */
            _.Move(WHOST_DATA_EM, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO);

            /*" -6345- MOVE WS-NUM-OCORR-MOVTO TO LK-GE350-NUM-OCORR-MOVTO */
            _.Move(WS_NUM_OCORR_MOVTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO);

            /*" -6346- MOVE SIGC13-IDLG TO LK-GE350-NUM-IDLG */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_IDLG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

            /*" -6347- MOVE WS-COD-PRODUTO TO LK-GE350-COD-PRODUTO */
            _.Move(FILLER_101.WS_COD_PRODUTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

            /*" -6349- MOVE SIGC13-COD-REJEICAO TO LK-GE350-COD-REJEICAO */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_REJEICAO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO);

            /*" -6350- MOVE SIGC13-DIA-VENCIMENTO TO WDAT-REL-DIA */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_VENCIMENTO.SIGC13_DIA_VENCIMENTO, FILLER_56.WDAT_REL_DIA);

            /*" -6351- MOVE SIGC13-MES-VENCIMENTO TO WDAT-REL-MES */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_VENCIMENTO.SIGC13_MES_VENCIMENTO, FILLER_56.WDAT_REL_MES);

            /*" -6352- MOVE SIGC13-ANO-VENCIMENTO TO WDAT-REL-ANO */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_DTA_VENCIMENTO.SIGC13_ANO_VENCIMENTO, FILLER_56.WDAT_REL_ANO);

            /*" -6354- MOVE WDATA-REL TO LK-GE350-DTA-VENCIMENTO */
            _.Move(WDATA_REL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_VENCIMENTO);

            /*" -6356- COMPUTE LK-GE350-VLR-PREMIO-TOTAL = SIGC13-VLR-PAGO / 100 */
            LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_PREMIO_TOTAL.Value = MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_PAGO / 100f;

            /*" -6357- MOVE WS-NUM-PARCELA TO LK-GE350-QTD-PARCELA */
            _.Move(FILLER_101.WS_NUM_PARCELA, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_PARCELA);

            /*" -6358- MOVE 29 TO LK-GE350-QTD-DIAS-CUSTODIA */
            _.Move(29, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_QTD_DIAS_CUSTODIA);

            /*" -6360- MOVE WS-COD-CLIENTE TO LK-GE350-COD-CLIENTE */
            _.Move(FILLER_101.WS_COD_CLIENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CLIENTE);

            /*" -6362- COMPUTE LK-GE350-VLR-IOF = SIGC13-VLR-IOF / 100 */
            LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_VLR_IOF.Value = MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_VLR_IOF / 100f;

            /*" -6363- MOVE SIGC13-NUM-BOL-INTERNO TO LK-GE350-NUM-BLTO-INTERNO */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NUM_BOL_INTERNO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

            /*" -6366- MOVE SIGC13-NN-REGISTRADO TO LK-GE350-NOSSO-NUMERO-SAP WS-NOSSO-NUMERO-SAP */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_NN_REGISTRADO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, W.WS_NOSSO_NUMERO_SAP);

            /*" -6367- IF (WS-NUM-TITULO EQUAL ZEROS) */

            if ((FILLER_101.WS_NUM_TITULO == 00))
            {

                /*" -6368- MOVE WS-NUM-TITULO-NN TO LK-GE350-NUM-TITULO */
                _.Move(W.FILLER_0.WS_NUM_TITULO_NN, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                /*" -6369- ELSE */
            }
            else
            {


                /*" -6370- MOVE WS-NUM-TITULO TO LK-GE350-NUM-TITULO */
                _.Move(FILLER_101.WS_NUM_TITULO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                /*" -6372- END-IF. */
            }


            /*" -6373- MOVE SIGC13-LNHA-DIGITAVEL TO LK-GE350-COD-LINHA-DGTVEL */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_LNHA_DIGITAVEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

            /*" -6374- MOVE 'FA' TO LK-GE350-IDE-SISTEMA */
            _.Move("FA", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_IDE_SISTEMA);

            /*" -6376- MOVE 'EM8006B' TO LK-GE350-COD-USUARIO */
            _.Move("EM8006B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -6377- IF (DET13-COD-MOVIMENTO EQUAL 02 OR 03 OR 09) */

            if ((DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO.In("02", "03", "09")))
            {

                /*" -6378- MOVE 'H' TO LK-GE350-COD-SITUACAO */
                _.Move("H", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -6379- ELSE */
            }
            else
            {


                /*" -6380- MOVE 'F' TO LK-GE350-COD-SITUACAO */
                _.Move("F", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                /*" -6382- END-IF */
            }


            /*" -6383- IF WS-FLAG-DIRID = 1 */

            if (WS_FLAG_DIRID == 1)
            {

                /*" -6384- EVALUATE DET13-COD-MOVIMENTO */
                switch (DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO.Value)
                {

                    /*" -6385- WHEN 02 */
                    case 02:

                        /*" -6386- MOVE 'H' TO LK-GE350-COD-SITUACAO */
                        _.Move("H", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                        /*" -6387- WHEN 03 */
                        break;
                    case 03:

                        /*" -6388- MOVE 'R' TO LK-GE350-COD-SITUACAO */
                        _.Move("R", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                        /*" -6389- WHEN 06 */
                        break;
                    case 06:

                        /*" -6390- MOVE 'F' TO LK-GE350-COD-SITUACAO */
                        _.Move("F", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                        /*" -6391- WHEN 09 */
                        break;
                    case 09:

                        /*" -6392- MOVE 'T' TO LK-GE350-COD-SITUACAO */
                        _.Move("T", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                        /*" -6393- WHEN OTHER */
                        break;
                    default:

                        /*" -6394- DISPLAY 'ERRO COD-MOVIMENTO ARQ-H SAP' */
                        _.Display($"ERRO COD-MOVIMENTO ARQ-H SAP");

                        /*" -6395- DISPLAY 'CERTIFIC  ' LK-GE350-NUM-CERTIFICADO */
                        _.Display($"CERTIFIC  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                        /*" -6396- DISPLAY 'PROPOSTA  ' LK-GE350-NUM-PROPOSTA */
                        _.Display($"PROPOSTA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                        /*" -6397- DISPLAY 'APOLICE   ' LK-GE350-NUM-APOLICE */
                        _.Display($"APOLICE   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                        /*" -6398- DISPLAY 'ENDOSSO   ' LK-GE350-NUM-ENDOSSO */
                        _.Display($"ENDOSSO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                        /*" -6399- DISPLAY 'PARCELA   ' LK-GE350-NUM-PARCELA */
                        _.Display($"PARCELA   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                        /*" -6400- DISPLAY 'IDLG      ' LK-GE350-NUM-IDLG */
                        _.Display($"IDLG      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                        /*" -6401- DISPLAY 'COD-MOVTO ' DET13-COD-MOVIMENTO */
                        _.Display($"COD-MOVTO {DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO}");

                        /*" -6402- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -6403- END-EVALUATE */
                        break;
                }


                /*" -6405- END-IF */
            }


            /*" -6407- MOVE DET13-COD-AG-CEDENTE TO LK-GE350-COD-CEDENTE-SAP */
            _.Move(DET_REGISTRO.DET_REG13.DET13_COD_AG_CEDENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

            /*" -6408- IF WS-IDLG-EMP-SIS-TIP = 'C000SASONLINE' */

            if (W.WS_IDLG_DIRID_R1.WS_IDLG_EMP_SIS_TIP == "C000SASONLINE")
            {

                /*" -6409- IF WS-COD-CEDENTE = 696001 */

                if (WS_CEDENTE_R.WS_COD_CEDENTE == 696001)
                {

                    /*" -6410- IF WS-IDLG-APO-NUM-ID = 1 */

                    if (W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R1.FILLER_3.WS_IDLG_APO_NUM_ID == 1)
                    {

                        /*" -6412- IF WS-IDLG-APO-PAR = 0 */

                        if (W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R1.WS_IDLG_APO_PAR == 0)
                        {

                            /*" -6413- IF WS-IDLG-END-PAR-R3-P3 NUMERIC */

                            if (W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R3.FILLER_7.WS_IDLG_END_PAR_R3_P3.IsNumeric())
                            {

                                /*" -6415- MOVE WS-IDLG-END-NUM-R3 TO LK-GE350-NUM-ENDOSSO */
                                _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R3.WS_IDLG_END_NUM_R3, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                                /*" -6417- MOVE WS-IDLG-END-PAR-R3 TO LK-GE350-NUM-PARCELA */
                                _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R3.WS_IDLG_END_PAR_R3, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                                /*" -6419- MOVE WS-IDLG-END-APO-R3 TO LK-GE350-NUM-APOLICE */
                                _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R3.WS_IDLG_END_APO_R3, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                                /*" -6420- ELSE */
                            }
                            else
                            {


                                /*" -6421- IF WS-IDLG-END-PAR-P2 NUMERIC */

                                if (W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R2.FILLER_5.WS_IDLG_END_PAR_P2.IsNumeric())
                                {

                                    /*" -6423- MOVE WS-IDLG-END-NUM TO LK-GE350-NUM-ENDOSSO */
                                    _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R2.WS_IDLG_END_NUM, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                                    /*" -6425- MOVE WS-IDLG-END-PAR TO LK-GE350-NUM-PARCELA */
                                    _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R2.WS_IDLG_END_PAR, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                                    /*" -6427- MOVE WS-IDLG-END-APO TO LK-GE350-NUM-APOLICE */
                                    _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R2.WS_IDLG_END_APO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                                    /*" -6428- ELSE */
                                }
                                else
                                {


                                    /*" -6430- MOVE WS-IDLG-END-NUM-R4 TO LK-GE350-NUM-ENDOSSO */
                                    _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R4.WS_IDLG_END_NUM_R4, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                                    /*" -6432- MOVE WS-IDLG-END-PAR-R4 TO LK-GE350-NUM-PARCELA */
                                    _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R4.WS_IDLG_END_PAR_R4, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                                    /*" -6434- MOVE WS-IDLG-END-APO-R4 TO LK-GE350-NUM-APOLICE */
                                    _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R4.WS_IDLG_END_APO_R4, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                                    /*" -6435- END-IF */
                                }


                                /*" -6436- END-IF */
                            }


                            /*" -6437- ELSE */
                        }
                        else
                        {


                            /*" -6438- MOVE WS-IDLG-APO-PAR TO LK-GE350-NUM-PARCELA */
                            _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R1.WS_IDLG_APO_PAR, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                            /*" -6439- MOVE WS-IDLG-APO-NUM TO LK-GE350-NUM-APOLICE */
                            _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R1.WS_IDLG_APO_NUM, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE);

                            /*" -6440- MOVE 0 TO LK-GE350-NUM-ENDOSSO */
                            _.Move(0, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                            /*" -6441- END-IF */
                        }


                        /*" -6444- END-IF */
                    }


                    /*" -6445- MOVE ZEROS TO WS-COD-PRODUTO */
                    _.Move(0, FILLER_101.WS_COD_PRODUTO);

                    /*" -6447- MOVE LK-GE350-NUM-PROPOSTA TO GE403-NUM-PROPOSTA */
                    _.Move(LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA, GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA);

                    /*" -6457- PERFORM R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1 */

                    R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1();

                    /*" -6460- IF SQLCODE = 0 */

                    if (DB.SQLCODE == 0)
                    {

                        /*" -6462- MOVE WS-COD-PRODUTO TO LK-GE350-COD-PRODUTO */
                        _.Move(FILLER_101.WS_COD_PRODUTO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_PRODUTO);

                        /*" -6464- END-IF */
                    }


                    /*" -6466- END-IF */
                }


                /*" -6468- IF WS-COD-CEDENTE = 696005 OR CVPCV-696005 OR JV1CV-696005 */

                if (WS_CEDENTE_R.WS_COD_CEDENTE.In("696005", JVBKINCL.JV_CONVENIOS.CVPCV_696005.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_696005.ToString()))
                {

                    /*" -6469- IF WS-IDLG-PRO-NUM-ID EQUAL 9 */

                    if (W.WS_IDLG_DIRID_R1.WS_IDLG_PRO_END_R5.FILLER_10.WS_IDLG_PRO_NUM_ID == 9)
                    {

                        /*" -6470- IF WS-IDLG-END-PAR-R7 = 0 */

                        if (W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R7.WS_IDLG_END_PAR_R7 == 0)
                        {

                            /*" -6471- MOVE 1 TO LK-GE350-NUM-PARCELA */
                            _.Move(1, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                            /*" -6472- ELSE */
                        }
                        else
                        {


                            /*" -6474- MOVE WS-IDLG-END-PAR-R7 TO LK-GE350-NUM-PARCELA */
                            _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R7.WS_IDLG_END_PAR_R7, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                            /*" -6475- END-IF */
                        }


                        /*" -6476- MOVE 4000 TO LK-GE350-NUM-ENDOSSO */
                        _.Move(4000, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                        /*" -6477- ELSE */
                    }
                    else
                    {


                        /*" -6478- IF WS-IDLG-END-PAR-R6 = 0 */

                        if (W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R6.WS_IDLG_END_PAR_R6 == 0)
                        {

                            /*" -6479- MOVE 1 TO LK-GE350-NUM-PARCELA */
                            _.Move(1, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                            /*" -6480- ELSE */
                        }
                        else
                        {


                            /*" -6482- MOVE WS-IDLG-END-PAR-R6 TO LK-GE350-NUM-PARCELA */
                            _.Move(W.WS_IDLG_DIRID_R1.WS_IDLG_APO_END_R6.WS_IDLG_END_PAR_R6, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA);

                            /*" -6483- END-IF */
                        }


                        /*" -6484- MOVE 4000 TO LK-GE350-NUM-ENDOSSO */
                        _.Move(4000, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO);

                        /*" -6485- END-IF */
                    }


                    /*" -6486- END-IF */
                }


                /*" -6489- END-IF */
            }


            /*" -6491- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -6492- IF (LK-GE350-COD-RETORNO NOT EQUAL '0' ) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0"))
            {

                /*" -6493- DISPLAY ' ' */
                _.Display($" ");

                /*" -6494- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6495- DISPLAY '*    R5100-SOLICITA-NN-SAP-SIGCB        *' */
                _.Display($"*    R5100-SOLICITA-NN-SAP-SIGCB        *");

                /*" -6496- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -6497- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6498- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -6499- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -6500- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -6501- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6502- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6502- END-IF. */
            }


        }

        [StopWatch]
        /*" R5610-INSERT-CNTRLE-SIGCB-DB-SELECT-1 */
        public void R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1()
        {
            /*" -6457- EXEC SQL SELECT B.COD_PRODUTO INTO :WS-COD-PRODUTO FROM SEGUROS.PROPOSTA_AUTO A ,SEGUROS.PROPOSTAS B WHERE A.NUM_PROPOSTA_CONV = :GE403-NUM-PROPOSTA AND A.SIT_REGISTRO = ' ' AND B.COD_FONTE = A.COD_FONTE AND B.NUM_PROPOSTA = A.NUM_PROPOSTA WITH UR END-EXEC */

            var r5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1 = new R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1()
            {
                GE403_NUM_PROPOSTA = GE403.DCLGE_CONTROLE_EMISSAO_SIGCB.GE403_NUM_PROPOSTA.ToString(),
            };

            var executed_1 = R5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1.Execute(r5610_INSERT_CNTRLE_SIGCB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_PRODUTO, FILLER_101.WS_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5610_99_SAIDA*/

        [StopWatch]
        /*" R5620-ALTERA-SIT-CNTRLE-SIGCB-SECTION */
        private void R5620_ALTERA_SIT_CNTRLE_SIGCB_SECTION()
        {
            /*" -6526- MOVE '5620' TO WNR-EXEC-SQL. */
            _.Move("5620", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6528- MOVE DET13-NN-REGISTRADO TO LK-GE350-NOSSO-NUMERO-SAP WS-NOSSO-NUMERO-SAP */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NN_REGISTRADO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NOSSO_NUMERO_SAP, W.WS_NOSSO_NUMERO_SAP);

            /*" -6529- MOVE DET13-LNHA-DIGITAVEL TO LK-GE350-COD-LINHA-DGTVEL */
            _.Move(DET_REGISTRO.DET_REG13.DET13_LNHA_DIGITAVEL, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_LINHA_DGTVEL);

            /*" -6530- MOVE DET13-COD-AG-CEDENTE TO LK-GE350-COD-CEDENTE-SAP */
            _.Move(DET_REGISTRO.DET_REG13.DET13_COD_AG_CEDENTE, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_CEDENTE_SAP);

            /*" -6531- MOVE DET13-NUM-BOL-INTERNO TO LK-GE350-NUM-BLTO-INTERNO */
            _.Move(DET_REGISTRO.DET_REG13.DET13_NUM_BOL_INTERNO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_BLTO_INTERNO);

            /*" -6532- MOVE DET-IDLG TO LK-GE350-NUM-IDLG */
            _.Move(DET_REGISTRO.DET_IDLG, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG);

            /*" -6534- MOVE SIGC13-COD-REJEICAO TO LK-GE350-COD-REJEICAO */
            _.Move(MOVCC_REGISTRO.REG_SIGC13.SIGC13_RESTO.SIGC13_COD_REJEICAO, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_REJEICAO);

            /*" -6535- EVALUATE DET13-COD-MOVIMENTO */
            switch (DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO.Value)
            {

                /*" -6536- WHEN 02 */
                case 02:

                    /*" -6537- MOVE 'H' TO LK-GE350-COD-SITUACAO */
                    _.Move("H", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -6538- WHEN 03 */
                    break;
                case 03:

                    /*" -6539- MOVE 'R' TO LK-GE350-COD-SITUACAO */
                    _.Move("R", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -6540- WHEN 06 */
                    break;
                case 06:

                    /*" -6541- MOVE 'F' TO LK-GE350-COD-SITUACAO */
                    _.Move("F", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -6542- WHEN 09 */
                    break;
                case 09:

                    /*" -6543- MOVE 'T' TO LK-GE350-COD-SITUACAO */
                    _.Move("T", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO);

                    /*" -6544- WHEN OTHER */
                    break;
                default:

                    /*" -6545- DISPLAY 'R5610 - ERRO COD-MOVIMENTO ARQ-H SAP' */
                    _.Display($"R5610 - ERRO COD-MOVIMENTO ARQ-H SAP");

                    /*" -6546- DISPLAY 'CERTIFIC  ' LK-GE350-NUM-CERTIFICADO */
                    _.Display($"CERTIFIC  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                    /*" -6547- DISPLAY 'PROPOSTA  ' LK-GE350-NUM-PROPOSTA */
                    _.Display($"PROPOSTA  {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                    /*" -6548- DISPLAY 'APOLICE   ' LK-GE350-NUM-APOLICE */
                    _.Display($"APOLICE   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                    /*" -6549- DISPLAY 'ENDOSSO   ' LK-GE350-NUM-ENDOSSO */
                    _.Display($"ENDOSSO   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                    /*" -6550- DISPLAY 'PARCELA   ' LK-GE350-NUM-PARCELA */
                    _.Display($"PARCELA   {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                    /*" -6551- DISPLAY 'IDLG      ' LK-GE350-NUM-IDLG */
                    _.Display($"IDLG      {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                    /*" -6552- DISPLAY 'COD-MOVTO ' DET13-COD-MOVIMENTO */
                    _.Display($"COD-MOVTO {DET_REGISTRO.DET_REG13.DET13_COD_MOVIMENTO}");

                    /*" -6553- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -6564- END-EVALUATE. */
                    break;
            }


            /*" -6566- MOVE 04 TO LK-GE350-COD-FUNCAO */
            _.Move(04, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_FUNCAO);

            /*" -6570- IF (WS-COD-CEDENTE EQUAL 696001) OR (WS-COD-CEDENTE EQUAL 696005 OR CVPCV-696005 OR JV1CV-696005 ) */

            if ((WS_CEDENTE_R.WS_COD_CEDENTE == 696001) || (WS_CEDENTE_R.WS_COD_CEDENTE.In("696005", JVBKINCL.JV_CONVENIOS.CVPCV_696005.ToString(), JVBKINCL.JV_CONVENIOS.JV1CV_696005.ToString())))
            {

                /*" -6571- IF (LK-GE350-NUM-TITULO EQUAL ZEROS) */

                if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO == 00))
                {

                    /*" -6572- MOVE WS-NUM-TITULO-NN TO LK-GE350-NUM-TITULO */
                    _.Move(W.FILLER_0.WS_NUM_TITULO_NN, LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_TITULO);

                    /*" -6573- END-IF */
                }


                /*" -6575- END-IF */
            }


            /*" -6578- MOVE 'EM8006B' TO LK-GE350-COD-USUARIO */
            _.Move("EM8006B", LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_USUARIO);

            /*" -6580- CALL 'GE0350S' USING REGISTRO-LINKAGE-GE0350S. */
            _.Call("GE0350S", LBGE0350.REGISTRO_LINKAGE_GE0350S);

            /*" -6581- IF (LK-GE350-COD-RETORNO NOT EQUAL '0' ) */

            if ((LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO != "0"))
            {

                /*" -6582- DISPLAY ' ' */
                _.Display($" ");

                /*" -6583- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6584- DISPLAY '*    R5640-ALTERA-SIT-CNTRLE-SIGCB      *' */
                _.Display($"*    R5640-ALTERA-SIT-CNTRLE-SIGCB      *");

                /*" -6585- DISPLAY '*  ERRO NA EXECUCAO DO CALL DA GE0350S  *' */
                _.Display($"*  ERRO NA EXECUCAO DO CALL DA GE0350S  *");

                /*" -6586- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6587- DISPLAY '=> LK-MENSAGEM ... ' LK-GE350-MENSAGEM */
                _.Display($"=> LK-MENSAGEM ... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM}");

                /*" -6588- DISPLAY '=> LK-COD-RETORNO. ' LK-GE350-COD-RETORNO */
                _.Display($"=> LK-COD-RETORNO. {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_RETORNO}");

                /*" -6589- DISPLAY '=> LK-SQLCODE..... ' LK-GE350-SQLCODE */
                _.Display($"=> LK-SQLCODE..... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_MENSAGEM.LK_GE350_SQLCODE}");

                /*" -6590- DISPLAY '-----------------------------------------' */
                _.Display($"-----------------------------------------");

                /*" -6591- DISPLAY '=> NUM-APOLICE.... ' LK-GE350-NUM-APOLICE */
                _.Display($"=> NUM-APOLICE.... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_APOLICE}");

                /*" -6592- DISPLAY '=> NUM-CERTIFICADO ' LK-GE350-NUM-CERTIFICADO */
                _.Display($"=> NUM-CERTIFICADO {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_CERTIFICADO}");

                /*" -6593- DISPLAY '=> NUM-PARCELA.... ' LK-GE350-NUM-PARCELA */
                _.Display($"=> NUM-PARCELA.... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PARCELA}");

                /*" -6594- DISPLAY '=> NUM-ENDOSSO.... ' LK-GE350-NUM-ENDOSSO */
                _.Display($"=> NUM-ENDOSSO.... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_ENDOSSO}");

                /*" -6595- DISPLAY '=> NUM-PROPOSTA... ' LK-GE350-NUM-PROPOSTA */
                _.Display($"=> NUM-PROPOSTA... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_PROPOSTA}");

                /*" -6596- DISPLAY '=> MVMTO-SIGCB.... ' LK-GE350-DTA-MOVIMENTO */
                _.Display($"=> MVMTO-SIGCB.... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_DTA_MOVIMENTO}");

                /*" -6597- DISPLAY '=> OCORR-MOVTO-SAP ' LK-GE350-NUM-OCORR-MOVTO */
                _.Display($"=> OCORR-MOVTO-SAP {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_OCORR_MOVTO}");

                /*" -6598- DISPLAY '=> COD-SITUACAO... ' LK-GE350-COD-SITUACAO */
                _.Display($"=> COD-SITUACAO... {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_COD_SITUACAO}");

                /*" -6600- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -6601- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6601- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5620_99_SAIDA*/

        [StopWatch]
        /*" R5700-PESQUISA-IDLG-DEB-CONTA-SECTION */
        private void R5700_PESQUISA_IDLG_DEB_CONTA_SECTION()
        {
            /*" -6612- MOVE '5700' TO WNR-EXEC-SQL. */
            _.Move("5700", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6642- PERFORM R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1 */

            R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1();

            /*" -6645- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -6646- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6647- DISPLAY 'EM8006B - PROBLEMAS 5700 SELECT IDLG CONTA ' */
                _.Display($"EM8006B - PROBLEMAS 5700 SELECT IDLG CONTA ");

                /*" -6648- DISPLAY 'NUM-IDLG => ' LK-GE350-NUM-IDLG */
                _.Display($"NUM-IDLG => {LBGE0350.REGISTRO_LINKAGE_GE0350S.LK_GE350_NUM_IDLG}");

                /*" -6649- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6650- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6652- END-IF. */
            }


            /*" -6654- IF (SQLCODE EQUAL ZEROS) NEXT SENTENCE */

            if ((DB.SQLCODE == 00))
            {

                /*" -6655- ELSE */
            }
            else
            {


                /*" -6656- MOVE ZEROS TO WS-NUM-APOLICE */
                _.Move(0, FILLER_101.WS_NUM_APOLICE);

                /*" -6657- MOVE ZEROS TO WS-NUM-CERTIFICADO */
                _.Move(0, FILLER_101.WS_NUM_CERTIFICADO);

                /*" -6658- MOVE 01 TO WS-NUM-PARCELA */
                _.Move(01, FILLER_101.WS_NUM_PARCELA);

                /*" -6659- MOVE ZEROS TO WS-COD-CLIENTE */
                _.Move(0, FILLER_101.WS_COD_CLIENTE);

                /*" -6660- MOVE ZEROS TO WS-NUM-OCORR-MOVTO */
                _.Move(0, WS_NUM_OCORR_MOVTO);

                /*" -6661- MOVE ZEROS TO WS-COD-PRODUTO */
                _.Move(0, FILLER_101.WS_COD_PRODUTO);

                /*" -6662- MOVE ZEROS TO WS-NUM-TITULO */
                _.Move(0, FILLER_101.WS_NUM_TITULO);

                /*" -6663- END-IF. */
            }


        }

        [StopWatch]
        /*" R5700-PESQUISA-IDLG-DEB-CONTA-DB-SELECT-1 */
        public void R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1()
        {
            /*" -6642- EXEC SQL SELECT E.NUM_APOLICE , D.NUM_CERTIFICADO , D.NUM_PARCELA , D.NUM_TITULO , A.NUM_OCORR_MOVTO , E.COD_PRODUTO , E.COD_CLIENTE INTO :WS-NUM-APOLICE , :WS-NUM-CERTIFICADO , :WS-NUM-PARCELA , :WS-NUM-TITULO , :WS-NUM-OCORR-MOVTO , :WS-COD-PRODUTO , :WS-COD-CLIENTE FROM SEGUROS.GE_CONTROLE_INTERF_SAP A, SEGUROS.GE_MOVDEBCE_SAP B, SEGUROS.MOVTO_DEBITOCC_CEF C, SEGUROS.COBER_HIST_VIDAZUL D, SEGUROS.PROPOSTAS_VA E WHERE A.COD_IDLG = :SIGC13-IDLG AND B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO AND C.NUM_APOLICE = B.NUM_APOLICE AND C.NUM_ENDOSSO = B.NUM_ENDOSSO AND C.NUM_PARCELA = B.NUM_PARCELA AND C.NSAS = B.NSAS AND D.NUM_TITULO = C.NUM_APOLICE AND E.NUM_CERTIFICADO = D.NUM_CERTIFICADO FETCH FIRST 01 ROWS ONLY WITH UR END-EXEC. */

            var r5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1 = new R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1()
            {
                SIGC13_IDLG = MOVCC_REGISTRO.REG_SIGC13.SIGC13_IDLG.ToString(),
            };

            var executed_1 = R5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1.Execute(r5700_PESQUISA_IDLG_DEB_CONTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_APOLICE, FILLER_101.WS_NUM_APOLICE);
                _.Move(executed_1.WS_NUM_CERTIFICADO, FILLER_101.WS_NUM_CERTIFICADO);
                _.Move(executed_1.WS_NUM_PARCELA, FILLER_101.WS_NUM_PARCELA);
                _.Move(executed_1.WS_NUM_TITULO, FILLER_101.WS_NUM_TITULO);
                _.Move(executed_1.WS_NUM_OCORR_MOVTO, WS_NUM_OCORR_MOVTO);
                _.Move(executed_1.WS_COD_PRODUTO, FILLER_101.WS_COD_PRODUTO);
                _.Move(executed_1.WS_COD_CLIENTE, FILLER_101.WS_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5700_99_SAIDA*/

        [StopWatch]
        /*" R5710-UPDATE-OPCAO-PAG-PARC-SECTION */
        private void R5710_UPDATE_OPCAO_PAG_PARC_SECTION()
        {
            /*" -6673- MOVE '5710' TO WNR-EXEC-SQL. */
            _.Move("5710", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6678- PERFORM R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1 */

            R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1();

            /*" -6681- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -6682- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6683- DISPLAY 'EM8006B - PROBLEMAS 5710 UPDATE COBER-HISTVA ' */
                _.Display($"EM8006B - PROBLEMAS 5710 UPDATE COBER-HISTVA ");

                /*" -6684- DISPLAY 'NUM-CERTIFICADO => ' WS-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {FILLER_101.WS_NUM_CERTIFICADO}");

                /*" -6685- DISPLAY 'NUM-PARCELA => ' WS-NUM-PARCELA */
                _.Display($"NUM-PARCELA => {FILLER_101.WS_NUM_PARCELA}");

                /*" -6686- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6687- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6689- END-IF. */
            }


            /*" -6694- PERFORM R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2 */

            R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2();

            /*" -6697- IF (SQLCODE NOT EQUAL ZEROS AND +100) */

            if ((!DB.SQLCODE.In("00", "+100")))
            {

                /*" -6698- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6699- DISPLAY 'EM8006B - PROBLEMAS 5710 UPDATE PARCELAS-VA ' */
                _.Display($"EM8006B - PROBLEMAS 5710 UPDATE PARCELAS-VA ");

                /*" -6700- DISPLAY 'NUM-CERTIFICADO => ' WS-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO => {FILLER_101.WS_NUM_CERTIFICADO}");

                /*" -6701- DISPLAY 'NUM-PARCELA => ' WS-NUM-PARCELA */
                _.Display($"NUM-PARCELA => {FILLER_101.WS_NUM_PARCELA}");

                /*" -6702- DISPLAY '--------------------------------------' */
                _.Display($"--------------------------------------");

                /*" -6703- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -6704- END-IF. */
            }


        }

        [StopWatch]
        /*" R5710-UPDATE-OPCAO-PAG-PARC-DB-UPDATE-1 */
        public void R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1()
        {
            /*" -6678- EXEC SQL UPDATE SEGUROS.COBER_HIST_VIDAZUL SET OPCAO_PAGAMENTO = '3' WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO AND NUM_PARCELA = :WS-NUM-PARCELA END-EXEC. */

            var r5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1 = new R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1()
            {
                WS_NUM_CERTIFICADO = FILLER_101.WS_NUM_CERTIFICADO.ToString(),
                WS_NUM_PARCELA = FILLER_101.WS_NUM_PARCELA.ToString(),
            };

            R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1.Execute(r5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5710_99_SAIDA*/

        [StopWatch]
        /*" R5710-UPDATE-OPCAO-PAG-PARC-DB-UPDATE-2 */
        public void R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2()
        {
            /*" -6694- EXEC SQL UPDATE SEGUROS.PARCELAS_VIDAZUL SET OPCAO_PAGAMENTO = '3' WHERE NUM_CERTIFICADO = :WS-NUM-CERTIFICADO AND NUM_PARCELA = :WS-NUM-PARCELA END-EXEC. */

            var r5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2_Update1 = new R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2_Update1()
            {
                WS_NUM_CERTIFICADO = FILLER_101.WS_NUM_CERTIFICADO.ToString(),
                WS_NUM_PARCELA = FILLER_101.WS_NUM_PARCELA.ToString(),
            };

            R5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2_Update1.Execute(r5710_UPDATE_OPCAO_PAG_PARC_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R6000-00-TRATA-CARTAO-SECTION */
        private void R6000_00_TRATA_CARTAO_SECTION()
        {
            /*" -6715- MOVE '6000' TO WNR-EXEC-SQL. */
            _.Move("6000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6717- ADD 1 TO TT-CARTAO. */
            W.TT_CARTAO.Value = W.TT_CARTAO + 1;

            /*" -6720- MOVE WS-IDLG-CAR-CONV TO MOVDEBCE-COD-CONVENIO. */
            _.Move(FILLER_26.WS_IDLG_CAR_CONV, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -6723- MOVE WS-IDLG-CAR-NSA TO MOVDEBCE-NSAS. */
            _.Move(FILLER_26.WS_IDLG_CAR_NSA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -6726- MOVE WS-IDLG-CAR-NRSEQ TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(FILLER_26.WS_IDLG_CAR_NRSEQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -6729- PERFORM R2000-00-SELECT-MOVDEBCC. */

            R2000_00_SELECT_MOVDEBCC_SECTION();

            /*" -6730- IF WTEM-REGISTRO NOT EQUAL 'S' */

            if (W.WTEM_REGISTRO != "S")
            {

                /*" -6731- PERFORM R9000-00-GRAVA-EXPURGO THRU R9000-99-SAIDA */

                R9000_00_GRAVA_EXPURGO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/


                /*" -6732- GO TO R6000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/ //GOTO
                return;

                /*" -6734- END-IF. */
            }


            /*" -6737- MOVE 104 TO CARTAO-CODBANCO. */
            _.Move(104, REG_CARTAO.CARTAO_CODBANCO);

            /*" -6740- MOVE MOVDEBCE-COD-CONVENIO TO CARTAO-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REG_CARTAO.CARTAO_CONVENIO);

            /*" -6743- MOVE MOVDEBCE-NSAS TO CARTAO-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REG_CARTAO.CARTAO_NSAS);

            /*" -6746- MOVE MOVDEBCE-NUM-APOLICE TO CARTAO-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REG_CARTAO.CARTAO_NUM_APOLICE);

            /*" -6749- MOVE MOVDEBCE-NUM-ENDOSSO TO CARTAO-NUM-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REG_CARTAO.CARTAO_NUM_ENDOSSO);

            /*" -6752- MOVE MOVDEBCE-NUM-PARCELA TO CARTAO-NUM-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REG_CARTAO.CARTAO_NUM_PARCELA);

            /*" -6755- MOVE MOVDEBCE-NUM-REQUISICAO TO CARTAO-NUM-REQUISICAO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, REG_CARTAO.CARTAO_NUM_REQUISICAO);

            /*" -6758- MOVE MOVDEBCE-OPER-CONTA-DEB TO CARTAO-TIPO-LANCAMENTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, REG_CARTAO.CARTAO_TIPO_LANCAMENTO);

            /*" -6759- MOVE DET3-DT-MOVTO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_DT_MOVTO, WS_DATA_SAP);

            /*" -6761- MOVE WS-DD-SAP TO CARTAO-DIA-HEADER. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, REG_CARTAO.CARTAO_DTGERACAO.CARTAO_DIA_HEADER);

            /*" -6763- MOVE WS-MM-SAP TO CARTAO-MES-HEADER. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, REG_CARTAO.CARTAO_DTGERACAO.CARTAO_MES_HEADER);

            /*" -6766- MOVE WS-AA-SAP TO CARTAO-ANO-HEADER. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, REG_CARTAO.CARTAO_DTGERACAO.CARTAO_ANO_HEADER);

            /*" -6769- MOVE DET3-MOTIVO TO CARTAO-MOTIVO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_MOTIVO, REG_CARTAO.CARTAO_MOTIVO);

            /*" -6772- MOVE DET3-COD-TRANS TO CARTAO-COD-TRANSACAO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_COD_TRANS, REG_CARTAO.CARTAO_COD_TRANSACAO);

            /*" -6775- MOVE DET3-NRO-CARTAO TO CARTAO-NUM-CARTAO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_NRO_CARTAO, REG_CARTAO.CARTAO_NUM_CARTAO);

            /*" -6776- MOVE DET3-DT-VENCTO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_DT_VENCTO, WS_DATA_SAP);

            /*" -6778- MOVE WS-DD-SAP TO CARTAO-DIA-VENCTO. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, REG_CARTAO.CARTAO_DTVENCTO.CARTAO_DIA_VENCTO);

            /*" -6780- MOVE WS-MM-SAP TO CARTAO-MES-VENCTO. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, REG_CARTAO.CARTAO_DTVENCTO.CARTAO_MES_VENCTO);

            /*" -6783- MOVE WS-AA-SAP TO CARTAO-ANO-VENCTO. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, REG_CARTAO.CARTAO_DTVENCTO.CARTAO_ANO_VENCTO);

            /*" -6786- MOVE DET3-VALOR TO CARTAO-VLR-TRANSACAO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_VALOR, REG_CARTAO.CARTAO_VLR_TRANSACAO);

            /*" -6789- MOVE DET3-VLR-CREDITO TO CARTAO-VLR-CREDITO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_VLR_CREDITO, REG_CARTAO.CARTAO_VLR_CREDITO);

            /*" -6792- MOVE DET3-VLR-TARIFA TO CARTAO-VLR-TARIFA. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_VLR_TARIFA, REG_CARTAO.CARTAO_VLR_TARIFA);

            /*" -6795- MOVE DET3-NOVO-NROCAR TO CARTAO-NOVO-CARTAO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_NOVO_NROCAR, REG_CARTAO.CARTAO_NOVO_CARTAO);

            /*" -6798- MOVE DET3-NOVO-DIA-VENCTO TO CARTAO-NOVO-DIA-VENCTO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_NOVO_DIA_VENCTO, REG_CARTAO.CARTAO_NOVO_DIA_VENCTO);

            /*" -6799- MOVE DET3-DT-AGENDTO TO WS-DATA-SAP. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_DT_AGENDTO, WS_DATA_SAP);

            /*" -6801- MOVE WS-DD-SAP TO CARTAO-DIA-AGENDA. */
            _.Move(WS_DATA_SAP.WS_DD_SAP, REG_CARTAO.CARTAO_DATA_AGENDAMENTO.CARTAO_DIA_AGENDA);

            /*" -6803- MOVE WS-MM-SAP TO CARTAO-MES-AGENDA. */
            _.Move(WS_DATA_SAP.WS_MM_SAP, REG_CARTAO.CARTAO_DATA_AGENDAMENTO.CARTAO_MES_AGENDA);

            /*" -6811- MOVE WS-AA-SAP TO CARTAO-ANO-AGENDA. */
            _.Move(WS_DATA_SAP.WS_AA_SAP, REG_CARTAO.CARTAO_DATA_AGENDAMENTO.CARTAO_ANO_AGENDA);

            /*" -6812- IF DET3-MOTIVO-RET NOT NUMERIC */

            if (!DET_REGISTRO.DET_REG3.DET3_MOTIVO_RET.IsNumeric())
            {

                /*" -6817- MOVE '99' TO DET3-MOTIVO-RET. */
                _.Move("99", DET_REGISTRO.DET_REG3.DET3_MOTIVO_RET);
            }


            /*" -6820- MOVE DET3-MOTIVO-RET TO CARTAO-MOT-RETORNO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_MOTIVO_RET, REG_CARTAO.CARTAO_MOT_RETORNO);

            /*" -6823- MOVE DET3-MOTIVO-CANC TO CARTAO-MOT-CANCEL. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_MOTIVO_CANC, REG_CARTAO.CARTAO_MOT_CANCEL);

            /*" -6826- MOVE DET3-BANCO TO CARTAO-BANCO. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_BANCO, REG_CARTAO.CARTAO_BANCO);

            /*" -6829- MOVE DET3-AGENCIA TO CARTAO-AGENCIA. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_AGENCIA, REG_CARTAO.CARTAO_AGENCIA);

            /*" -6832- MOVE DET3-CONTA TO CARTAO-CONTA. */
            _.Move(DET_REGISTRO.DET_REG3.DET3_CONTA, REG_CARTAO.CARTAO_CONTA);

            /*" -6836- MOVE DET-NSA-BCO TO CARTAO-NSAC. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_CARTAO.CARTAO_NSAC);

            /*" -6838- WRITE REG-SAIDA5 FROM REG-CARTAO. */
            _.Move(REG_CARTAO.GetMoveValues(), REG_SAIDA5);

            SAIDA5.Write(REG_SAIDA5.GetMoveValues().ToString());

            /*" -6838- ADD 1 TO AC-GRAV-SAIDA5. */
            W.AC_GRAV_SAIDA5.Value = W.AC_GRAV_SAIDA5 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-TRATA-CHEQUE-SECTION */
        private void R7000_00_TRATA_CHEQUE_SECTION()
        {
            /*" -6852- MOVE '7000' TO WNR-EXEC-SQL. */
            _.Move("7000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6855- ADD 1 TO TT-CHEQUE. */
            W.TT_CHEQUE.Value = W.TT_CHEQUE + 1;

            /*" -6857- MOVE DET-NSA-BCO TO CHEQUE-NSA-BANCO. */
            _.Move(DET_REGISTRO.DET_NSA_BCO, REG_CHEQUE.CHEQUE_NSA_BANCO);

            /*" -6860- MOVE WS-EMP-ANT TO CHEQUE-ORIGEM-EMPRESA. */
            _.Move(W.WS_EMP_ANT, REG_CHEQUE.CHEQUE_ORIGEM_EMPRESA);

            /*" -6861- IF DET-TIPREG EQUAL 01 */

            if (DET_REGISTRO.DET_TIPREG == 01)
            {

                /*" -6863- MOVE DET1-CGCCPF TO CHEQUE-CPF-CNPJ */
                _.Move(DET_REGISTRO.DET_REG1.DET1_CGCCPF, REG_CHEQUE.CHEQUE_CPF_CNPJ);

                /*" -6865- MOVE DET1-EVENTO TO CHEQUE-EVENTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_EVENTO, REG_CHEQUE.CHEQUE_EVENTO);

                /*" -6867- MOVE DET1-VLR-BRUTO TO CHEQUE-VALOR-BRUTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_BRUTO, REG_CHEQUE.CHEQUE_VALOR_BRUTO);

                /*" -6869- MOVE DET1-VLR-IRRF TO CHEQUE-VALOR-IRRF */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_IRRF, REG_CHEQUE.CHEQUE_VALOR_IRRF);

                /*" -6871- MOVE DET1-VLR-ISS TO CHEQUE-VALOR-ISS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_ISS, REG_CHEQUE.CHEQUE_VALOR_ISS);

                /*" -6873- MOVE DET1-VLR-INSS TO CHEQUE-VALOR-INSS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_INSS, REG_CHEQUE.CHEQUE_VALOR_INSS);

                /*" -6875- MOVE DET1-VLR-COFINS TO CHEQUE-VALOR-COFINS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_COFINS, REG_CHEQUE.CHEQUE_VALOR_COFINS);

                /*" -6877- MOVE DET1-VLR-CSLL TO CHEQUE-VALOR-CSLL */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_CSLL, REG_CHEQUE.CHEQUE_VALOR_CSLL);

                /*" -6879- MOVE DET1-VLR-PIS TO CHEQUE-VALOR-PIS */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_PIS, REG_CHEQUE.CHEQUE_VALOR_PIS);

                /*" -6881- MOVE DET1-VLR-PG-REC TO CHEQUE-VALOR-PAGTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_VLR_PG_REC, REG_CHEQUE.CHEQUE_VALOR_PAGTO);

                /*" -6883- MOVE DET1-DT-MOVTO TO CHEQUE-DATA-CREDITO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_MOVTO, REG_CHEQUE.CHEQUE_DATA_CREDITO);

                /*" -6885- MOVE DET1-DT-ENVIO TO CHEQUE-DATA-ENVIO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_ENVIO, REG_CHEQUE.CHEQUE_DATA_ENVIO);

                /*" -6887- MOVE DET1-DT-CONTABIL TO CHEQUE-DATA-CONTABIL */
                _.Move(DET_REGISTRO.DET_REG1.DET1_DT_CONTABIL, REG_CHEQUE.CHEQUE_DATA_CONTABIL);

                /*" -6889- MOVE DET1-MEIO-PAGTO TO CHEQUE-MEIO-PAGTO */
                _.Move(DET_REGISTRO.DET_REG1.DET1_MEIO_PAGTO, REG_CHEQUE.CHEQUE_MEIO_PAGTO);

                /*" -6891- MOVE DET1-NRO-SIVAT TO CHEQUE-NUM-SIVAT */
                _.Move(DET_REGISTRO.DET_REG1.DET1_NRO_SIVAT, REG_CHEQUE.CHEQUE_NUM_SIVAT);

                /*" -6893- MOVE DET1-OCORRENCIA TO CHEQUE-OCORRENCIA */
                _.Move(DET_REGISTRO.DET_REG1.DET1_OCORRENCIA, REG_CHEQUE.CHEQUE_OCORRENCIA);

                /*" -6894- ELSE */
            }
            else
            {


                /*" -6895- ADD 1 TO DP-TIPOREG */
                W.DP_TIPOREG.Value = W.DP_TIPOREG + 1;

                /*" -6898- GO TO R7000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6899- MOVE ZEROS TO WS-NUMBETA. */
            _.Move(0, WS_NUMBETA);

            /*" -6902- MOVE DET1-NRO-CHQ-INT TO WS-NUMALFA. */
            _.Move(DET_REGISTRO.DET_REG1.DET1_NRO_CHQ_INT, WS_NUMALFA);

            /*" -6903- SET WS-ALF TO 13. */
            WS_ALF.Value = 13;

            /*" -6905- SET WS-BET TO 13. */
            WS_BET.Value = 13;

            /*" -6907- PERFORM R7100-00-AJUSTA-CAMPO 13 TIMES. */

            for (int i = 0; i < 13; i++)
            {

                R7100_00_AJUSTA_CAMPO_SECTION();

            }

            /*" -6911- MOVE WS-NUMBETA TO CHEQUE-NUM-CHEQUE. */
            _.Move(WS_NUMBETA, REG_CHEQUE.CHEQUE_NUM_CHEQUE);

            /*" -6913- WRITE REG-SAIDA6 FROM REG-CHEQUE. */
            _.Move(REG_CHEQUE.GetMoveValues(), REG_SAIDA6);

            SAIDA6.Write(REG_SAIDA6.GetMoveValues().ToString());

            /*" -6913- ADD 1 TO AC-GRAV-SAIDA6. */
            W.AC_GRAV_SAIDA6.Value = W.AC_GRAV_SAIDA6 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R7100-00-AJUSTA-CAMPO-SECTION */
        private void R7100_00_AJUSTA_CAMPO_SECTION()
        {
            /*" -6927- MOVE '7100' TO WNR-EXEC-SQL. */
            _.Move("7100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6928- IF WS-ALFA01(WS-ALF) NOT EQUAL SPACES */

            if (FILLER_31.TB_NUMALFA[WS_ALF].WS_ALFA01 != string.Empty)
            {

                /*" -6930- MOVE WS-ALFA01(WS-ALF) TO WS-BETA01(WS-BET) */
                _.Move(FILLER_31.TB_NUMALFA[WS_ALF].WS_ALFA01, FILLER_32.TB_NUMBETA[WS_BET].WS_BETA01);

                /*" -6933- SET WS-BET DOWN BY 1. */
                WS_BET.Value -= 1;
            }


            /*" -6933- SET WS-ALF DOWN BY 1. */
            WS_ALF.Value -= 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7100_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-TRATA-SINISTRO-SECTION */
        private void R8000_00_TRATA_SINISTRO_SECTION()
        {
            /*" -6947- MOVE '8000' TO WNR-EXEC-SQL. */
            _.Move("8000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -6951- MOVE 'SIM' TO WS-TRATA-SINISTRO. */
            _.Move("SIM", W.WS_TRATA_SINISTRO);

            /*" -6953- MOVE DET-IDLG TO LK-IDLG-CODIGO-SINISTRO. */
            _.Move(DET_REGISTRO.DET_IDLG, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_CODIGO_SINISTRO);

            /*" -6956- CALL 'SISAP03B' USING LK-IDLG-REGISTRO-SINISTRO. */
            _.Call("SISAP03B", LK_IDLG_REGISTRO_SINISTRO);

            /*" -6957- IF LK-IDLG-RET-CODIGO-RETORNO NOT EQUAL '0' */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO != "0")
            {

                /*" -6959- DISPLAY 'ERRO DE ACESSO NA EXECUCAO DA SISAP03 = ' LK-IDLG-RET-CODIGO-RETORNO */
                _.Display($"ERRO DE ACESSO NA EXECUCAO DA SISAP03 = {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO}");

                /*" -6960- DISPLAY 'MENSAGEM DE ERRO ' LK-IDLG-RET-MENSAGEM */
                _.Display($"MENSAGEM DE ERRO {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM}");

                /*" -6962- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -6964- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6965- IF LK-IDLG-RET-EH-SINISTRO NOT EQUAL 'SIM' */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO != "SIM")
            {

                /*" -6967- DISPLAY 'ADVERTENCIA - SISAP03B NAO ENCONTROU: ' DET-IDLG */
                _.Display($"ADVERTENCIA - SISAP03B NAO ENCONTROU: {DET_REGISTRO.DET_IDLG}");

                /*" -6969- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -6971- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6972- IF LK-IDLG-RET-COD-FINANC EQUAL 01 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC == 01)
            {

                /*" -6973- MOVE SPACES TO WS-IDLG-CHQ */
                _.Move("", WS_IDLG_CHQ);

                /*" -6974- MOVE ZEROS TO WS-IDLG-DVCHQ */
                _.Move(0, FILLER_24.WS_IDLG_DVCHQ);

                /*" -6976- MOVE LK-IDLG-NUM-CHEQUE-INTERNO TO WS-IDLG-NROCHQ */
                _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINI.LK_IDLG_COMPLEMENTO_1.LK_IDLG_NUM_CHEQUE_INTERNO, FILLER_24.WS_IDLG_NROCHQ);

                /*" -6977- MOVE WS-IDLG-CHQ TO CHEQUE-IDLG */
                _.Move(WS_IDLG_CHQ, REG_CHEQUE.CHEQUE_IDLG);

                /*" -6978- PERFORM R7000-00-TRATA-CHEQUE */

                R7000_00_TRATA_CHEQUE_SECTION();

                /*" -6980- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6981- IF LK-IDLG-RET-COD-FINANC NOT EQUAL 02 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC != 02)
            {

                /*" -6983- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -6985- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6988- IF LK-IDLG-RET-LAYOUT NOT EQUAL 01 AND LK-IDLG-RET-LAYOUT NOT EQUAL 02 AND LK-IDLG-RET-LAYOUT NOT EQUAL 03 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT != 01 && LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT != 02 && LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT != 03)
            {

                /*" -6990- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -6993- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -6994- MOVE DET-IDLG TO LK-GE0302B-IDLG. */
            _.Move(DET_REGISTRO.DET_IDLG, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_IDLG);

            /*" -6998- CALL 'GE0302B' USING REGISTRO-LINKAGE-GE0302B. */
            _.Call("GE0302B", REGISTRO_LINKAGE_GE0302B);

            /*" -6999- IF LK-GE0302B-COD-RETORNO NOT EQUAL ZEROS */

            if (REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO != 00)
            {

                /*" -7001- DISPLAY 'ERRO DE ACESSO NA EXECUCAO DA GE0302B = ' LK-GE0302B-COD-RETORNO */
                _.Display($"ERRO DE ACESSO NA EXECUCAO DA GE0302B = {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO}");

                /*" -7002- DISPLAY 'MENSAGEM DE ERRO ' LK-GE0302B-MENSAGEM */
                _.Display($"MENSAGEM DE ERRO {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM}");

                /*" -7004- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -7006- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7007- IF LK-GE0302B-ACHOU-USO-EMPRESA EQUAL 'NAO' */

            if (REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA == "NAO")
            {

                /*" -7008- DISPLAY 'ERRO DE ACESSO NA EXECUCAO DA GE0302B' */
                _.Display($"ERRO DE ACESSO NA EXECUCAO DA GE0302B");

                /*" -7009- DISPLAY 'NAO ACHOU O USO DA EMPRESA' */
                _.Display($"NAO ACHOU O USO DA EMPRESA");

                /*" -7010- DISPLAY 'MENSAGEM DE ERRO ' LK-GE0302B-MENSAGEM */
                _.Display($"MENSAGEM DE ERRO {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM}");

                /*" -7011- DISPLAY 'IDLG: ' DET-IDLG */
                _.Display($"IDLG: {DET_REGISTRO.DET_IDLG}");

                /*" -7012- DISPLAY '      ' DET1-OCORRENCIA(1:2) */
                _.Display($"      {DET_REGISTRO.DET_REG1.DET1_OCORRENCIA.Substring(1, 2)}");

                /*" -7014- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -7016- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7017- IF LK-GE0302B-EH-SINISTRO NOT EQUAL 'SIM' */

            if (REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO != "SIM")
            {

                /*" -7019- MOVE 'NAO' TO WS-TRATA-SINISTRO */
                _.Move("NAO", W.WS_TRATA_SINISTRO);

                /*" -7032- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -7033- IF LK-IDLG-RET-LAYOUT EQUAL 1 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT == 1)
            {

                /*" -7035- MOVE 104 TO MOVCC-CODBANCO */
                _.Move(104, MOVCC_REGISTRO.MOVCC_CODBANCO);

                /*" -7037- MOVE LK-IDLG-RET-MOVDEB-CONVENIO TO MOVCC-CONVENIO */
                _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_CONVENIO, MOVCC_REGISTRO.MOVCC_CONVENIO);

                /*" -7039- MOVE LK-IDLG-RET-MOVDEB-NSAS-ENVIO TO MOVCC-NSAS */
                _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NSAS_ENVIO, MOVCC_REGISTRO.MOVCC_NSAS);

                /*" -7041- MOVE LK-GE0302B-SICOV-IDENT-CLIENTE TO MOVCC-IDTCLIEMP */
                _.Move(REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_IDENT_CLIENTE, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

                /*" -7043- MOVE LK-GE0302B-SICOV-USO-EMPRESA TO MOVCC-USOEMPRESA */
                _.Move(REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_USO_EMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

                /*" -7044- PERFORM R1000-00-GRAVA-SICOV */

                R1000_00_GRAVA_SICOV_SECTION();

                /*" -7045- ELSE */
            }
            else
            {


                /*" -7047- IF LK-IDLG-RET-LAYOUT EQUAL 2 OR 3 */

                if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT.In("2", "3"))
                {

                    /*" -7049- MOVE LK-IDLG-RET-MOVDEB-CONVENIO TO SIACC-CONVENIO */
                    _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_CONVENIO, REG_SIACC.SIACC_CONVENIO);

                    /*" -7051- MOVE LK-GE0302B-SIACC TO SIACC-IDLG */
                    _.Move(REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SIACC, REG_SIACC.SIACC_IDLG);

                    /*" -7051- PERFORM R1500-00-GRAVA-SIACC. */

                    R1500_00_GRAVA_SIACC_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-GRAVA-EXPURGO-SECTION */
        private void R9000_00_GRAVA_EXPURGO_SECTION()
        {
            /*" -7062- WRITE REG-SAIDA13 FROM REG-ARQH. */
            _.Move(REG_ARQH.GetMoveValues(), REG_SAIDA13);

            SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

            /*" -7062- ADD 1 TO AC-GRAV-SAIDA13. */
            W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9500-00-EXPURGA-MCP-SECTION */
        private void R9500_00_EXPURGA_MCP_SECTION()
        {
            /*" -7072- WRITE REG-SAIDA18 FROM REG-ARQH. */
            _.Move(REG_ARQH.GetMoveValues(), REG_SAIDA18);

            SAIDA18.Write(REG_SAIDA18.GetMoveValues().ToString());

            /*" -7073- ADD 1 TO AC-GRAV-SAIDA18. */
            W.AC_GRAV_SAIDA18.Value = W.AC_GRAV_SAIDA18 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9500_99_SAIDA*/

        [StopWatch]
        /*" R9600-00-EXPURGA-MCPCVP-SECTION */
        private void R9600_00_EXPURGA_MCPCVP_SECTION()
        {
            /*" -7081- WRITE REG-SAIDA19 FROM REG-ARQH. */
            _.Move(REG_ARQH.GetMoveValues(), REG_SAIDA19);

            SAIDA19.Write(REG_SAIDA19.GetMoveValues().ToString());

            /*" -7082- ADD 1 TO AC-GRAV-SAIDA19. */
            W.AC_GRAV_SAIDA19.Value = W.AC_GRAV_SAIDA19 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9600_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -7089- MOVE WHOST-DATA-EM TO WDATA-SQL */
            _.Move(WHOST_DATA_EM, WDATA_SQL);

            /*" -7090- MOVE WDATA-DD-SQL TO WDATA-DD-CABEC */
            _.Move(WDATA_SQL.WDATA_DD_SQL, WDATA_CABEC.WDATA_DD_CABEC);

            /*" -7091- MOVE WDATA-MM-SQL TO WDATA-MM-CABEC */
            _.Move(WDATA_SQL.WDATA_MM_SQL, WDATA_CABEC.WDATA_MM_CABEC);

            /*" -7093- MOVE WDATA-AA-SQL TO WDATA-AA-CABEC. */
            _.Move(WDATA_SQL.WDATA_AA_SQL, WDATA_CABEC.WDATA_AA_CABEC);

            /*" -7096- DISPLAY 'ARQUIVO SEM MOVIMENTO PROCESSADO NESTA DATA - ' WDATA-CABEC. */
            _.Display($"ARQUIVO SEM MOVIMENTO PROCESSADO NESTA DATA - {WDATA_CABEC}");

            /*" -7110- CLOSE MOVARQH SAIDA1 SAIDA2 SAIDA3 SAIDA4 SAIDA5 SAIDA6 SAIDA7 SAIDA11 SAIDA12 SAIDA14 SAIDA15 SAIDA16. */
            MOVARQH.Close();
            SAIDA1.Close();
            SAIDA2.Close();
            SAIDA3.Close();
            SAIDA4.Close();
            SAIDA5.Close();
            SAIDA6.Close();
            SAIDA7.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA14.Close();
            SAIDA15.Close();
            SAIDA16.Close();

            /*" -7112- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -7112- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -7120- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -7121- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -7122- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -7123- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -7125- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -7125- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -7141- CLOSE MOVARQH SAIDA1 SAIDA2 SAIDA3 SAIDA4 SAIDA5 SAIDA6 SAIDA7 SAIDA11 SAIDA12 SAIDA14 SAIDA15 SAIDA16 */
            MOVARQH.Close();
            SAIDA1.Close();
            SAIDA2.Close();
            SAIDA3.Close();
            SAIDA4.Close();
            SAIDA5.Close();
            SAIDA6.Close();
            SAIDA7.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA14.Close();
            SAIDA15.Close();
            SAIDA16.Close();

            /*" -7143- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -7143- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}