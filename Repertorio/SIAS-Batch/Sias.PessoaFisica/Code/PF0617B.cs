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
using Sias.PessoaFisica.DB2.PF0617B;

namespace Code
{
    public class PF0617B
    {
        public bool IsCall { get; set; }

        public PF0617B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ..............  PF - PRODUTOS DE FIDELIZACAO         *      */
        /*"      *   PROGRAMA .............  PF0617B                              *      */
        /*"      *   DATA .................  04/08/2000                           *      */
        /*"      *   ANALISE/PROGRAMACAO...  LUIZ CARLOS                          *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ...............  GERA ARQUIVO PARA O SIGPF DAS PROPOS *      */
        /*"      *                           TAS BILHETE EMITIDAS E QUE NAO FORAM *      */
        /*"      *                           GERADAS PELO SIGPF.   GERA TAMBEM AS *      */
        /*"      *                           TABELAS CORPORATIVAS.                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.56  *   VERSAO 56 - INCIDENTE 601144 - CORRECAO ACESSO PESSOA-TELEFO *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/09/2024 - CANETTA             PROCURE POR V.56         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.55  *   VERSAO 55 - INCLUI NA PROPOSTA_FIDELIZ PARA OS PRODUTOS      *      */
        /*"      *               8104, 8112 E 8201.                               *      */
        /*"      *               DEMANDA 585437                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 27/06/2024 - TERCIO CARVALHO                              *      */
        /*"      *                                              PROCURE POR V.55  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.54  *   VERSAO 54 - GERAR ARQUIVO TIPO-D PARA O NOME SOCIAL          *      */
        /*"      *               DEMANDA 577291                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/05/2024 - ROGER PIRES DOS SANTOS                       *      */
        /*"      *                                              PROCURE POR V.54  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.53  *   VERSAO 53 - DEMANDA 496381 - NAO PERMITIR ENVIO DE PROPOSTAS *      */
        /*"      *               DO MICROSSEGURO AMPARO (3721), COM ORIGEM 13,15 E*      */
        /*"      *               22, CANAL 3 OU 4 E PRODUTO_SIVPF 29 DO SISPL     *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/10/2023 - ELIERMES OLIVEIRA   PROCURE POR V.53         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.52  *   VERSAO 52 - DEMANDA 496381 - NAO PERMITIR ENVIO DE PROPOSTAS *      */
        /*"      *               DO MICROSSEGURO AMPARO (3721), COM ORIGEM 15,    *      */
        /*"      *               CANAL 4 (ATM) E PRODUTO_SIVPF 29 DO SISPL        *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/10/2023 - ELIERMES OLIVEIRA   PROCURE POR V.52         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.51  *   VERSAO 51 - INCIDENTE 505923 - CORRECAO ACESSO FIDELIZ       *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/06/2023 - THIAGO BLAIER       PROCURE POR V.51         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.50  *   VERSAO 50 - INCIDENTE 504346 - CORRECAO ACESSO FIDELIZ       *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/06/2023 - CANETTA             PROCURE POR V.50         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 49 -                                                  *      */
        /*"      *               ACERTO EM PROGRAMA PARA ENVIO DE PROPOSTAS       *      */
        /*"      *               DE RENOVACAO                                     *      */
        /*"      *   EM 05/06/2023 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.49         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 48             ACRESCENTAR NO REGISTRO HEADER O CODIGO  *      */
        /*"      * ATENDE JAZZ 459621    E O NOME DA EMPRESA QUE GEROU O ARQUIVO  *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.48          REGINALDO SILVA                          *      */
        /*"      *                       10/03/2023                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 47 - DEMANDA 477857                                   *      */
        /*"      *               ACERTAR BUSCA DE LOTERICA AMPARO                 *      */
        /*"      *   EM 15/03/2023 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.47         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 46 - ABEND                                            *      */
        /*"      *               DISPLAY PARA TRATAR O ABEND -803                 *      */
        /*"      *               DISPLAY PARA VER OS CAMPOS                       *      */
        /*"      *   EM 28/12/2022 - THIAGO BLAIER                                *      */
        /*"      *                                       PROCURE POR V.46         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 45 - ABEND                                            *      */
        /*"      *               DISPLAY PARA TRATAR O ABEND -803                 *      */
        /*"      *               DISPLAY PARA VER OS CAMPOS                       *      */
        /*"      *   EM DEZ/2022 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.45         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.44    09/12/2022  HUSNI ALI HUSNI                            *      */
        /*"      *         DEMANDA 416666 TAREFA 452040                           *      */
        /*"      *         - PERMITIR GERAR ARQUIVO SIGPF PARA PROPOSTA COM ORIGEM*      */
        /*"      *         1026                                                   *      */
        /*"      *                                                   PROCURE V44  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 43 - DEMANDA  425398                                  *      */
        /*"      *               AJUSTES PARA ENVIAR PROPOSTAS APOLICE ESPECIFICA *      */
        /*"      *               CAAAAPPNNNNNND                                   *      */
        /*"      *               C      = Canal (pode Ser: 1, 2, 3, 6, 7, 8 e 9)  *      */
        /*"      *               AAAA   = Agencia de venda da proposta            *      */
        /*"      *               PP     = Codigo Produto                          *      */
        /*"      *               NNNNNN = Numero Sequencial da venda do produto   *      */
        /*"      *               D      = Digito Verificador calculo pelo Mod. 10 *      */
        /*"      *   EM SET/2022 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.43         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * V.42    17/05/2022  HUSNI ALI HUSNI                            *      */
        /*"      *         DEMANDA 387907 TAREFA 390027                           *      */
        /*"      *         - ENCAMINHAR CANAL 17 PARA PRODUTOS COM O CODIGO       *      */
        /*"      *         3725 ( SEGURO APOIO FAMILIA )                          *      */
        /*"      *                                                   PROCURE V42  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.41  * VERSAO 41       DEMANDA: 381226 - CORRECAO NO PRODUTO 3721     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.41    CANETTA  13/04/2022                            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ATENDE JAZZ - 232634 - SENSIBILIZA��O DO SIGPF PARA OS            */
        /*"      *                        PRODUTOS ATM E CAIXA EXECUTIVO          *      */
        /*"      *    INCLUIR ORIGENS DA PROPOSTA ATM E CAIXA EXECUTIVO E         *      */
        /*"      *    PRODUTOS SIVPF 10 E 29                                      *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V40          THIAGO BATISTA                            *      */
        /*"      *                       03/2021                                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 39             ATUALIZACAO DOS PRODUTOS JV1             *      */
        /*"      *                                                                *      */
        /*"      * ATENDE JAZZ HISTORIA: 206622      TAREFA: 213868               *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.39          TERCIO CARVALHO                          *      */
        /*"      *                       16/10/2020                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 38             ALTERAR CODIGO ORIGEM CASO O PRODUTO FOR *      */
        /*"      *                       O 3716.                                  *      */
        /*"      *                                                                *      */
        /*"      * ATENDE DEMANDA 245802                                          *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.38          CLAUDETE RADEL                           *      */
        /*"      *                       07/07/2020                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 37            Solicitacao da Caixa para a regularizacao *      */
        /*"      *                      de propostas com situacao MAN, esse status*      */
        /*"      *                      temporario necessitando da atualizacao.   *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      * ATENDE DEMANDA 238544    TAREFA 240828                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.37          RAUL BASILI ROTTA                        *      */
        /*"      *                       13/04/2020                               *      */
        /*"      *################################################################*      */
        /*"      *---> OBS.: TEM QUE FAZER MERGE COM A VERSAO 36 (ANTERIOR A ESSA)       */
        /*"      *---> OBS.: TEM QUE FAZER MERGE COM A VERSAO 36 (ANTERIOR A ESSA)       */
        /*"      *---> OBS.: TEM QUE FAZER MERGE COM A VERSAO 36 (ANTERIOR A ESSA)       */
        /*"      *################################################################*      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 35             MELHORIA NA BUSCA DO DIGITO VERIFICADOR  *      */
        /*"      *                                                                *      */
        /*"      * ATENDE DEMANDA 209.639                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.35          JOAO ARAUJO                              *      */
        /*"      *                       08/08/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 34             MELHORAR AS BUSCAS NA TABELA FC_LOTERICO *      */
        /*"      *                       POIS, NO CASO DO AMPARO WEB, O CCA ESTA  *      */
        /*"      *                       CADASTRADO COM UM 9 NA FRENTE, POR ISSO, *      */
        /*"      *                       NUNCA ENCONTRA O CCA NA TABELA.          *      */
        /*"      * ATENDE DEMANDA 199355                                          *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.34          CLAUDETE RADEL                           *      */
        /*"      *                       13/05/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * VERSAO 33             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.33          MARCUS VALERIO                           *      */
        /*"      *                       05/02/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 32             ENVIO INFORMACOES AMPARO CANAL CCA       *      */
        /*"      * ATENDE CADMUS 145.690 IMPLEMENTACAO DO REGISTRO TIPO 'C'       *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.32          MARCUS                                   *      */
        /*"      *                       13/11/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 31             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.31          FRANK CARVALHO                           *      */
        /*"      *                       05/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 30             AJUSTAR A ROTINA  R0500-LER-CAP          *      */
        /*"      * ATENDE CADMUS 134544  TITULOS QUE NAO TEM RCAPS                *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.30          REGINALDO SILVA                          *      */
        /*"      *                       30/03/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 29             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       16/06/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 28             GERAR INDICADOR ZERADO E CODIGO DE       *      */
        /*"      * ATENDE CADMUS 114074  PRODUTO 29 PARA AMPARO                   *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.28          THIAGO BLAIER                            *      */
        /*"      *                       29/05/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 27             AJUSTE PERIODICIDADE DE PAGAMENTO        *      */
        /*"      * ATENDE CADMUS 93600   PERI-PAGAMMENTO E R3-PERIPGTO            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.27          REGINALDO SILVA                          *      */
        /*"      *                       10/04/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 26             AJUSTE ROTINA R0577                      *      */
        /*"      * ATENDE CADMUS 93469   501-  LENDO ARQ DEPOIS DE FECHADO        *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.26          REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       30/01/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 25             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 24             AJUSTE NOS SELECTS  V10                  *      */
        /*"      * ATENDE CADMUS 84809   DB2.V10  SELECTS                         *      */
        /*"      *                                                                *      */
        /*"      *                       REGINALDO DA SILVA                       *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 23-    ATENDE CADMUS 81548 - RAMO 37 - MICROSEGURO      *      */
        /*"      *               AJUSTE NO CAMPO RAMO-BILHETE ACEITANDO RAMO 37   *      */
        /*"      * DATA     -    18/04/2013                                       *      */
        /*"      * ELABORADO-    REGINALDO DA SILVA    PROCURE POR V.23           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 22-    ATENDE CADMUS 75904 - PROJETO MONITORAMENTO      *      */
        /*"      *               AJUSTE NO CAMPO ORIGEM PROPOSTA NO ARQ DE SAIDA  *      */
        /*"      * DATA     -    23/11/2012                                       *      */
        /*"      * ELABORADO-    REGINALDO DA SILVA    PROCURE POR V.22           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 21-    ATENDE CADMUS 50481                              *      */
        /*"      *               AJUSTAR DATA DA TABELA DE RELATORIOS             *      */
        /*"      * DATA     -    19/11/2010                                       *      */
        /*"      * ELABORADO-    REGINALDO DA SILVA    PROCURE POR V.21           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ATENDE CADMUS 48758          EDSON MARQUES                     *      */
        /*"      *                                                                *      */
        /*"      * 19/10/2010 - CALCULAR A DIFERENCA DE DIAS -  REPROCESSA +      *      */
        /*"      *              DE 10 DIAS                                        *      */
        /*"      * ATENDE CADMUS 48055          SERGIO LORETO                     *      */
        /*"      *                                                                *      */
        /*"      * 23/09/2010 - CALCULAR A DIFERENCA DE DIAS -  REPROCESSA +      *      */
        /*"      *              DE 15 DIAS                                        *      */
        /*"      ******************************************************************      */
        /*"      * ATENDE CADMUS 48055          SERGIO LORETO                     *      */
        /*"      *                                                                *      */
        /*"      * 23/09/2010 - CALCULAR A DIFERENCA DE DIAS -  REPROCESSA +      *      */
        /*"      *              DE 15 DIAS                                        *      */
        /*"      ******************************************************************      */
        /*"      * ATENDE CADMUS36876           EDILANA CERQUEIRA                 *      */
        /*"      *                                                                *      */
        /*"      * 04/02/2010 - ALTERA DATA CURSOR PROCURAR V.20                  *      */
        /*"      ******************************************************************      */
        /*"      * ATENDE CADMUS34714           EDILANA CERQUEIRA                 *      */
        /*"      *                                                                *      */
        /*"      * 28/12/2009 - CORRIGE ABEND   PROCURAR POR V.19                 *      */
        /*"      ******************************************************************      */
        /*"      * ATENDE CADMUS34490           EDILANA CERQUEIRA                 *      */
        /*"      *                                                                *      */
        /*"      * 24/12/2009 - CORRIGE ABEND   PROCURAR POR V.18                 *      */
        /*"      ******************************************************************      */
        /*"      * ATENDE CADMUS34430           EDILANA CERQUEIRA                 *      */
        /*"      *                                                                *      */
        /*"      * 17/12/2009 - CORRIGE ABEND   PROCURAR POR V.17                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ATENDE CADMUS31775           EDILANA CERQUEIRA                 *      */
        /*"      *                                                                *      */
        /*"      * 27/10/2009 - RETIRA DATA FIXA                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 13/10/2008 - INCLUIR CLAUSULA WITH UR NO SELECT     - WV1008   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   14 -  07/10/2008  ATENDE   PROJETO FGV                       *      */
        /*"      *                     RETIRAR DISPLAY PARAGRAFO R0200            *      */
        /*"      *         PROCURE POR V.14      - LUCIA VIEIRA.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   13 -  01/09/2008  ATENDE SSI 21887  SAF LOTERICO             *      */
        /*"      *                     INCLUIR NA LISTA DE CANAIS POSSIVEIS       *      */
        /*"      *                     O CANAL 9 - CORRESPONDENTE NEGOCIAL        *      */
        /*"      *                     GRAVAR COM ORIGEM PROPOSTA = 13            *      */
        /*"      *         PROCURE POR V.13      - LUCIA VIEIRA.                  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   12 -  01/09/2008  ATENDE SSI 21887                           *      */
        /*"      *                     PASSA A INCLUIR NA PROPOSTA_FIDELIZ               */
        /*"      *                     ATRIBUTO  DATA-NASC-CONJUGE  = NULL               */
        /*"      *         PROCURE POR V.12      - LUCIA VIEIRA.                  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   11 -  29/08/2008  ATENDE CORRECAO ABEND CADMUS 13788         *      */
        /*"      *                     SQLCODE -180                               *      */
        /*"      *                     PARAGRAFO R3360-TRATA-PROP-FIDELIZACAO     *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V.11      - LUCIA VIEIRA.                  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   10 -  02/08/2008  ATENDE SSI22961                            *      */
        /*"      *                     PASSA A VERIFICAR SE A PROPOSTA CONTEM     *      */
        /*"      *                     SITUACAO = 'EMT' NA TAB HIST_PROP_FIDELIZ  *      */
        /*"      *                     ANTES DE GRAVAR O ARQUIVO DE SAIDA         *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V.10      - LUCIA VIEIRA.                  *      */
        /*"      ******************************************************************      */
        /*"      *   09 -  12/06/2008 CORRECAO DE ABEND SQLCODE -502              *      */
        /*"      *                    CURSOR  PARCELS - CADMUS 11503              *      */
        /*"      *         SSI 20683                                              *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V.09      - LUCIA VIEIRA.                  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   08 -  11/06/2008 CORRECAO DE ABEND SQLCODE 100 TAB PARCELAS  *      */
        /*"      *                    PARAGRAFO R0573-00-LER-PARCELAS CADMUS 11466*      */
        /*"      *         SSI 20683                                              *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V.08      - LUCIA VIEIRA.                  *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   07 -  27/03/2008 ADEQUACAO PARA BILHETE FACIL VIDA TRANQUILA *      */
        /*"      *                   (VENDA CENTRAL RELACIONAMENTO FENAE - MARSH) *      */
        /*"      *                                                                *      */
        /*"      *         SSI 20683                                              *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V.07- LUCIA VIEIRA.                        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   06 -  06/12/2007 RETIRADO CONTROLE QUANTIDADE REGISTRO       *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V06 - LUCIA VIEIRA.                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   05 -  22/05/2006 ACRESCENTADO COLUNA NUM_TP_MORA_IMOVEL DA   *      */
        /*"      *                    TABELA SEGUROS.PROP_SASSE_BILHETE.          *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V05 - LUCIA VIEIRA.                        *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   04 -  06/05/2003 PASSOU A OBTER A DATA DE EXPEDICAO DO RG,   *      */
        /*"      *                    ADEQUANDO-SE   A CIRCULAR 200 SUSEP.        *      */
        /*"      *                                                                *      */
        /*"      *         PROCURE POR V04 - LUIZ CARLOS.                         *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   03 -  19/06/2002 PASSOU A IDENTIFICAR PROPOSTA ELETRONICA    *      */
        /*"      *                    SIVPF DIGITADAS NO SIAS. PROCURE 190602.    *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   02 -  18/10/2001 PASSOU A DESPREZAR BILHETES QUE NAO POSSUEM *      */
        /*"      *                    CPF E  DATA DE NASCIMENTO. VER ROTINA R0150 *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   01 -  10/08/2001 PASSOU A DESPREZAR BILHETES QUE NAO POSSUEM *      */
        /*"      *                    CPF OU DATA DE NASCIMENTO. VER ROTINA R0150 *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACAO NO ACESSO A TABELA PRODUTOS_SIVPF EM FUNCAO DE       *      */
        /*"      * HAVER MAIS DE UMA LINHA PARA O MESMO COD_PRODUTO_SIVPF         *      */
        /*"      * (VIDA DA GENTE E MULTIPREMIADO SUPER)                          *      */
        /*"      * (PROCURAR POR 240703) - CHICON (PRODEXTER)            JUL/2003 *      */
        /*"      ******************************************************************      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_PRP_BILHETE { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOVTO_PRP_BILHETE
        {
            get
            {
                _.Move(REG_PRP_BILHETE, _MOVTO_PRP_BILHETE); VarBasis.RedefinePassValue(REG_PRP_BILHETE, _MOVTO_PRP_BILHETE, REG_PRP_BILHETE); return _MOVTO_PRP_BILHETE;
            }
        }
        /*"01   REG-PRP-BILHETE                    PIC X(300).*/
        public StringBasis REG_PRP_BILHETE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  NUM-APOL-ANT                  PIC S9(013)   VALUE +0 COMP-3.*/
        public IntBasis NUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  W-ORIGEM-MARSH                    PIC X(03) VALUE SPACES.*/
        public StringBasis W_ORIGEM_MARSH { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  W-TEM-RENOVACAO                   PIC X(03) VALUE SPACES.*/
        public StringBasis W_TEM_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  WS-JA-ENVIADA                     PIC X(01) VALUE SPACES.*/
        public StringBasis WS_JA_ENVIADA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"01  VIND-DTNASC-ESPOSA                PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NOME-ESPOSA                  PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NOME_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASBENEF                   PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASBENEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CPF                          PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-SEXO                         PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-UF-EXP                       PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-CBO                      PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TP-IDENT                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TP_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTEXPEDI                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-UF                       PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-USUR                     PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_USUR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUM-IDENT                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_NUM_IDENT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-ORGAO-EXP                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_ORGAO_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-TIMESTAMP                    PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_TIMESTAMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-COD-PESSOA                   PIC S9(4) COMP VALUE +0.*/
        public IntBasis VIND_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  COD-CBO-TIT                       PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_TIT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  COD-CBO-CONJ                      PIC S9(9)  COMP.*/
        public IntBasis COD_CBO_CONJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"01  WS-SISTEMA-DATA-MOV-ABERTO        PIC X(010).*/
        public StringBasis WS_SISTEMA_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-RELATORI-DATA-REFERENCIA       PIC X(010).*/
        public StringBasis WS_RELATORI_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-DIFERENCA-DIAS                 PIC S9(4) COMP VALUE +0.*/
        public IntBasis WS_DIFERENCA_DIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  WAREA-AUXILIAR.*/
        public PF0617B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0617B_WAREA_AUXILIAR();
        public class PF0617B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-MOVTO-BILH              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_BILH { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-V0APOLCORRET            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_V0APOLCORRET { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BENEFICIARIOS           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BENEFICIARIOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-VENDAS                  PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_VENDAS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-COB             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-FIDELIZ              PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-EXISTE-ENDERECO             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_EXISTE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-TELEFONE         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-INDEX                       PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-BENEF                   PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-IND-BENEF1                  PIC  9(02)  VALUE ZEROS.*/
            public IntBasis W_IND_BENEF1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-QTD-LD-TIPO-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-A               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-B               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-C               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-D               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-E               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-F               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-G               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-H               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-I               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-J               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-GERADO-PRP              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-COD-RELACION                PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_RELACION { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-ACHOU-EMAIL                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-SICOB                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_SICOB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-FILIAL                PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_FILIAL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-AGENCIA               PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_AGENCIA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-TELEFONE              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-ENDERECO              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-PROFISSAO             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-RELACIONAMENTO        PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_RELACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OCORR-ENDERECO              PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-OBTER-MAX-PESSOA            PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_PESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OBTER-MAX-RELAC             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_RELAC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-PRM-COMISSAO                PIC 9(013)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_COMISSAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05  W-VAL-COMISSAO                PIC 9(013)V99 VALUE ZEROS.*/
            public DoubleBasis W_VAL_COMISSAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05  W-TOT-COMISSAO                PIC 9(013)V99 VALUE ZEROS.*/
            public DoubleBasis W_TOT_COMISSAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
            /*"    05  W-TOT-PROCESSADO              PIC 9(008)    VALUE ZEROS.*/
            public IntBasis W_TOT_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-TOT-DESPREZADO              PIC 9(008)    VALUE ZEROS.*/
            public IntBasis W_TOT_DESPREZADO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  W-NUM-IDENTIF                 PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_IDENTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NUM-BENEF                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_NUM_BENEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-TIMESTAMP                   PIC X(026)  VALUE SPACES.*/
            public StringBasis W_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    05  FILLER REDEFINES W-TIMESTAMP.*/
            private _REDEF_PF0617B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0617B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0617B_FILLER_0(); _.Move(W_TIMESTAMP, _filler_0); VarBasis.RedefinePassValue(W_TIMESTAMP, _filler_0, W_TIMESTAMP); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_TIMESTAMP); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_TIMESTAMP); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_0 : VarBasis
            {
                /*"        07  W-DT-TIMESTAMP            PIC X(010).*/
                public StringBasis W_DT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"        07  W-HH-TIMESTAMP            PIC X(016).*/
                public StringBasis W_HH_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"    05  W-PRAZO-PERCEPCAO             PIC 9(002)  VALUE ZEROS.*/

                public _REDEF_PF0617B_FILLER_0()
                {
                    W_DT_TIMESTAMP.ValueChanged += OnValueChanged;
                    W_HH_TIMESTAMP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_PRAZO_PERCEPCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    05  FILLER REDEFINES W-PRAZO-PERCEPCAO.*/
            private _REDEF_PF0617B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0617B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0617B_FILLER_1(); _.Move(W_PRAZO_PERCEPCAO, _filler_1); VarBasis.RedefinePassValue(W_PRAZO_PERCEPCAO, _filler_1, W_PRAZO_PERCEPCAO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_PRAZO_PERCEPCAO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_PRAZO_PERCEPCAO); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_1 : VarBasis
            {
                /*"        07  W-PERCEPCAO               PIC X(002).*/
                public StringBasis W_PERCEPCAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  W-OPC-COBERTURA               PIC 9(004)  VALUE ZEROS.*/

                public _REDEF_PF0617B_FILLER_1()
                {
                    W_PERCEPCAO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_OPC_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-OPC-COBERTURA.*/
            private _REDEF_PF0617B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0617B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0617B_FILLER_2(); _.Move(W_OPC_COBERTURA, _filler_2); VarBasis.RedefinePassValue(W_OPC_COBERTURA, _filler_2, W_OPC_COBERTURA); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_OPC_COBERTURA); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_OPC_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_2 : VarBasis
            {
                /*"        07  W-OPC-COBERTURA-1         PIC 9(003).*/
                public IntBasis W_OPC_COBERTURA_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-OPC-COBERTURA-2         PIC 9(001).*/
                public IntBasis W_OPC_COBERTURA_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NR-IDENTIDADE               PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0617B_FILLER_2()
                {
                    W_OPC_COBERTURA_1.ValueChanged += OnValueChanged;
                    W_OPC_COBERTURA_2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_IDENTIDADE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-NR-IDENTIDADE.*/
            private _REDEF_PF0617B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0617B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0617B_FILLER_3(); _.Move(W_NR_IDENTIDADE, _filler_3); VarBasis.RedefinePassValue(W_NR_IDENTIDADE, _filler_3, W_NR_IDENTIDADE); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_NR_IDENTIDADE); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_NR_IDENTIDADE); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_3 : VarBasis
            {
                /*"        07  W-NR-RG                   PIC X(008).*/
                public StringBasis W_NR_RG { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0617B_FILLER_3()
                {
                    W_NR_RG.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE                    PIC 9(006).*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0617B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0617B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0617B_FILLER_4(); _.Move(W_DATA_TRABALHO, _filler_4); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_4, W_DATA_TRABALHO); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_DATA_TRABALHO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_4 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0617B_FILLER_4()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0617B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PF0617B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PF0617B_FILLER_5(); _.Move(W_DATA_NASCIMENTO, _filler_5); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_5, W_DATA_NASCIMENTO); _filler_5.ValueChanged += () => { _.Move(_filler_5, W_DATA_NASCIMENTO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_5 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  HOST-DT-TERVIG1               PIC X(010)  VALUE        '1999-12-31'.*/

                public _REDEF_PF0617B_FILLER_5()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis HOST_DT_TERVIG1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"1999-12-31");
            /*"    05  HOST-DT-TERVIG2               PIC X(010)  VALUE        '9999-12-31'.*/
            public StringBasis HOST_DT_TERVIG2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"9999-12-31");
            /*"    05  W-DTMOVABE                    PIC X(010).*/
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0617B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0617B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0617B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0617B_W_DTMOVABE1 : VarBasis
            {
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-DATA-CONTRATACAO.*/

                public _REDEF_PF0617B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public PF0617B_WS_DATA_CONTRATACAO WS_DATA_CONTRATACAO { get; set; } = new PF0617B_WS_DATA_CONTRATACAO();
            public class PF0617B_WS_DATA_CONTRATACAO : VarBasis
            {
                /*"        07  WS-DIA-CONTRATACAO        PIC 9(002).*/
                public IntBasis WS_DIA_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WS-MES-CONTRATACAO        PIC 9(002).*/
                public IntBasis WS_MES_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  WS-ANO-CONTRATACAO        PIC 9(004).*/
                public IntBasis WS_ANO_CONTRATACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  WS-FCLOTERI-NUM-LOTERICO      PIC 9(015).*/
            }
            public IntBasis WS_FCLOTERI_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES  WS-FCLOTERI-NUM-LOTERICO.*/
            private _REDEF_PF0617B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF0617B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF0617B_FILLER_6(); _.Move(WS_FCLOTERI_NUM_LOTERICO, _filler_6); VarBasis.RedefinePassValue(WS_FCLOTERI_NUM_LOTERICO, _filler_6, WS_FCLOTERI_NUM_LOTERICO); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_FCLOTERI_NUM_LOTERICO); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_FCLOTERI_NUM_LOTERICO); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_6 : VarBasis
            {
                /*"        07 WS-FCLOTERI-NUM-LOTERICO-8 PIC 9(014).*/
                public IntBasis WS_FCLOTERI_NUM_LOTERICO_8 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"        07 WS-FCLOTERI-NUM-LOTERICO-1 PIC 9(001).*/
                public IntBasis WS_FCLOTERI_NUM_LOTERICO_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WS-EOF-FC-LOTERICO-R0915      PIC 9(001) VALUE ZEROS.*/

                public _REDEF_PF0617B_FILLER_6()
                {
                    WS_FCLOTERI_NUM_LOTERICO_8.ValueChanged += OnValueChanged;
                    WS_FCLOTERI_NUM_LOTERICO_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_EOF_FC_LOTERICO_R0915 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-EOF-FC-LOTERICO-R0920      PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FC_LOTERICO_R0920 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-EOF-FC-LOTERICO-R0925      PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FC_LOTERICO_R0925 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-EOF-FC-LOTERICO-R0926      PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FC_LOTERICO_R0926 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-EOF-FC-LOTERICO-R0927      PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_FC_LOTERICO_R0927 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-EOF-PRODUTOR-R0930         PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_PRODUTOR_R0930 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-EOF-PRODUTOR-R0935         PIC 9(001) VALUE ZEROS.*/
            public IntBasis WS_EOF_PRODUTOR_R0935 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  WS-MATRICULA                  PIC 9(015) VALUE ZEROS.*/
            public IntBasis WS_MATRICULA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  FILLER REDEFINES WS-MATRICULA.*/
            private _REDEF_PF0617B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_PF0617B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_PF0617B_FILLER_7(); _.Move(WS_MATRICULA, _filler_7); VarBasis.RedefinePassValue(WS_MATRICULA, _filler_7, WS_MATRICULA); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_MATRICULA); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WS_MATRICULA); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_7 : VarBasis
            {
                /*"        07  WS-MATR01                 PIC 9(014).*/
                public IntBasis WS_MATR01 { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"        07  WS-MATRDV                 PIC 9(001).*/
                public IntBasis WS_MATRDV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  WHOST-DATA-REF-CURSOR         PIC X(010).*/

                public _REDEF_PF0617B_FILLER_7()
                {
                    WS_MATR01.ValueChanged += OnValueChanged;
                    WS_MATRDV.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WHOST_DATA_REF_CURSOR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  WHOST-DATA-REFERENCIA         PIC X(010).*/
            public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  WS-DTH-BILHETE                PIC X(010) VALUE SPACES.*/
            public StringBasis WS_DTH_BILHETE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WHOST-DATA-REF-M1YEAR         PIC X(010) VALUE SPACES.*/
            public StringBasis WHOST_DATA_REF_M1YEAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-WHOST-DATA-REF-M1YEAR REDEFINES WHOST-DATA-REF-M1YEAR.*/
            private _REDEF_PF0617B_W_WHOST_DATA_REF_M1YEAR _w_whost_data_ref_m1year { get; set; }
            public _REDEF_PF0617B_W_WHOST_DATA_REF_M1YEAR W_WHOST_DATA_REF_M1YEAR
            {
                get { _w_whost_data_ref_m1year = new _REDEF_PF0617B_W_WHOST_DATA_REF_M1YEAR(); _.Move(WHOST_DATA_REF_M1YEAR, _w_whost_data_ref_m1year); VarBasis.RedefinePassValue(WHOST_DATA_REF_M1YEAR, _w_whost_data_ref_m1year, WHOST_DATA_REF_M1YEAR); _w_whost_data_ref_m1year.ValueChanged += () => { _.Move(_w_whost_data_ref_m1year, WHOST_DATA_REF_M1YEAR); }; return _w_whost_data_ref_m1year; }
                set { VarBasis.RedefinePassValue(value, _w_whost_data_ref_m1year, WHOST_DATA_REF_M1YEAR); }
            }  //Redefines
            public class _REDEF_PF0617B_W_WHOST_DATA_REF_M1YEAR : VarBasis
            {
                /*"        07  W-ANO-DATA-REF            PIC X(004).*/
                public StringBasis W_ANO_DATA_REF { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"        07  W-REF-BARRA1              PIC X(001).*/
                public StringBasis W_REF_BARRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-DATA-REF            PIC X(002).*/
                public StringBasis W_MES_DATA_REF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"        07  W-REF-BARRA2              PIC X(001).*/
                public StringBasis W_REF_BARRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-DATA-REF            PIC X(002).*/
                public StringBasis W_DIA_DATA_REF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05  WS-DIA-SEMANA                 PIC X(001) VALUE SPACES.*/

                public _REDEF_PF0617B_W_WHOST_DATA_REF_M1YEAR()
                {
                    W_ANO_DATA_REF.ValueChanged += OnValueChanged;
                    W_REF_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_DATA_REF.ValueChanged += OnValueChanged;
                    W_REF_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_DATA_REF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DIA_SEMANA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-DTMOVABE-I                  PIC X(010).*/
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0617B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0617B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0617B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0617B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_PF0617B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0617B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0617B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0617B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0617B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-NR-SICOB                    PIC 9(015).*/

                public _REDEF_PF0617B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES W-NR-SICOB.*/
            private _REDEF_PF0617B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0617B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0617B_FILLER_8(); _.Move(W_NR_SICOB, _filler_8); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_8, W_NR_SICOB); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_NR_SICOB); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_8 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_PF0617B_FILLER_8()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0617B_CANAL _canal { get; set; }
            public _REDEF_PF0617B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0617B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0617B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                  VALUE 0, 6. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0,6"),
							/*" 88 CANAL-VENDA-CEF                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                 VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                     VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                      VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                        VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                     VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET                     VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8"),
							/*" 88 CANAL-CORRESP-NEGOCIAL             VALUE 9. */
							new SelectorItemBasis("CANAL_CORRESP_NEGOCIAL", "9")
                }
                };

                /*"        07  FILLER                    PIC X(013).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  W-NUMR-TITULO               PIC  9(013)   VALUE ZEROS.*/

                public _REDEF_PF0617B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05  FILLER                      REDEFINES    W-NUMR-TITULO.*/
            private _REDEF_PF0617B_FILLER_10 _filler_10 { get; set; }
            public _REDEF_PF0617B_FILLER_10 FILLER_10
            {
                get { _filler_10 = new _REDEF_PF0617B_FILLER_10(); _.Move(W_NUMR_TITULO, _filler_10); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_10, W_NUMR_TITULO); _filler_10.ValueChanged += () => { _.Move(_filler_10, W_NUMR_TITULO); }; return _filler_10; }
                set { VarBasis.RedefinePassValue(value, _filler_10, W_NUMR_TITULO); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_10 : VarBasis
            {
                /*"      10    WTITL-ZEROS             PIC  9(002).*/
                public IntBasis WTITL_ZEROS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    WTITL-SEQUENCIA         PIC  9(010).*/
                public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      10    WTITL-DIGITO            PIC  9(001).*/
                public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05              DPARM01X.*/

                public _REDEF_PF0617B_FILLER_10()
                {
                    WTITL_ZEROS.ValueChanged += OnValueChanged;
                    WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                    WTITL_DIGITO.ValueChanged += OnValueChanged;
                }

            }
            public PF0617B_DPARM01X DPARM01X { get; set; } = new PF0617B_DPARM01X();
            public class PF0617B_DPARM01X : VarBasis
            {
                /*"      07            DPARM01           PIC  9(010).*/
                public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
                /*"      07            DPARM01-R         REDEFINES   DPARM01.*/
                private _REDEF_PF0617B_DPARM01_R _dparm01_r { get; set; }
                public _REDEF_PF0617B_DPARM01_R DPARM01_R
                {
                    get { _dparm01_r = new _REDEF_PF0617B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                    set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
                }  //Redefines
                public class _REDEF_PF0617B_DPARM01_R : VarBasis
                {
                    /*"        10          DPARM01-1         PIC  9(001).*/
                    public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-2         PIC  9(001).*/
                    public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-3         PIC  9(001).*/
                    public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-4         PIC  9(001).*/
                    public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-5         PIC  9(001).*/
                    public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-6         PIC  9(001).*/
                    public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-7         PIC  9(001).*/
                    public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-8         PIC  9(001).*/
                    public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-9         PIC  9(001).*/
                    public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"        10          DPARM01-10        PIC  9(001).*/
                    public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      07            DPARM01-D1        PIC  9(001).*/

                    public _REDEF_PF0617B_DPARM01_R()
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
                /*"      07            DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
                public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/
            }

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 FEDERALPREV                             VALUE 2. */
							new SelectorItemBasis("FEDERALPREV", "2"),
							/*" 88 FEDERALCAP                              VALUE 3. */
							new SelectorItemBasis("FEDERALCAP", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE-T                               VALUE 4. */
							new SelectorItemBasis("BILHETE_T", "4")
                }
            };

            /*"    05  W-NOM-ORGAO-EXP               PIC X(030).*/
            public StringBasis W_NOM_ORGAO_EXP { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05  FILLER REDEFINES W-NOM-ORGAO-EXP.*/
            private _REDEF_PF0617B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_PF0617B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_PF0617B_FILLER_11(); _.Move(W_NOM_ORGAO_EXP, _filler_11); VarBasis.RedefinePassValue(W_NOM_ORGAO_EXP, _filler_11, W_NOM_ORGAO_EXP); _filler_11.ValueChanged += () => { _.Move(_filler_11, W_NOM_ORGAO_EXP); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, W_NOM_ORGAO_EXP); }
            }  //Redefines
            public class _REDEF_PF0617B_FILLER_11 : VarBasis
            {
                /*"        07  W-ORGAO-EXPEDIDOR         PIC X(005).*/
                public StringBasis W_ORGAO_EXPEDIDOR { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"        07  FILLER                    PIC X(025).*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
                /*"    05 W-OBTER-DADOS-RG               PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0617B_FILLER_11()
                {
                    W_ORGAO_EXPEDIDOR.ValueChanged += OnValueChanged;
                    FILLER_12.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_OBTER_DADOS_RG { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OBTEVE-DADOS-RG                         VALUE 1. */
							new SelectorItemBasis("OBTEVE_DADOS_RG", "1")
                }
            };

            /*"    05 W-CONVERSAO                    PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CONVERSAO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CONVERSAO-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("CONVERSAO_CADASTRADA", "1")
                }
            };

            /*"    05 W-MATRI-CCA                    PIC  9(008) VALUE ZEROS.*/
            public IntBasis W_MATRI_CCA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05 N88-ACHOU-ORIGEM-34            PIC  9(004) VALUE ZEROS.*/

            public SelectorBasis N88_ACHOU_ORIGEM_34 { get; set; } = new SelectorBasis("004", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ACHOU-ORIGEM-34                         VALUE 0034. */
							new SelectorItemBasis("ACHOU_ORIGEM_34", "0034")
                }
            };

            /*"01  WABEND*/
        }
        public PF0617B_WABEND WABEND { get; set; } = new PF0617B_WABEND();
        public class PF0617B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0617B_FILLER_13 FILLER_13 { get; set; } = new PF0617B_FILLER_13();
            public class PF0617B_FILLER_13 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0617B  '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0617B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0617B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0617B_LOCALIZA_ABEND_1();
            public class PF0617B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0617B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0617B_LOCALIZA_ABEND_2();
            public class PF0617B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0617B_WS_HORAS WS_HORAS { get; set; } = new PF0617B_WS_HORAS();
        public class PF0617B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0617B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0617B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0617B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0617B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_PF0617B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0617B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0617B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0617B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0617B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3.*/

                public _REDEF_PF0617B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public PF0617B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0617B_TOTAIS_ROT();
        public class PF0617B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 65 TIMES.*/
            public ListBasis<PF0617B_FILLER_22> FILLER_22 { get; set; } = new ListBasis<PF0617B_FILLER_22>(65);
            public class PF0617B_FILLER_22 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"01  WS-IN-PROPOFID1                   PIC 9(09)  VALUE ZEROS.*/
            }
        }
        public IntBasis WS_IN_PROPOFID1 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  WS-IN-PROPOFID2                   PIC 9(09)  VALUE ZEROS.*/
        public IntBasis WS_IN_PROPOFID2 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  WS-NUM-LOTERICO-26                PIC 9(09)  VALUE ZEROS.*/
        public IntBasis WS_NUM_LOTERICO_26 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  WS-NUM-LOTERICO-27                PIC 9(09)  VALUE ZEROS.*/
        public IntBasis WS_NUM_LOTERICO_27 { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  WS-NUM-CORRESPONDENTE             PIC 9(09)  VALUE ZEROS.*/
        public IntBasis WS_NUM_CORRESPONDENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  FILLER REDEFINES WS-NUM-CORRESPONDENTE.*/
        private _REDEF_PF0617B_FILLER_23 _filler_23 { get; set; }
        public _REDEF_PF0617B_FILLER_23 FILLER_23
        {
            get { _filler_23 = new _REDEF_PF0617B_FILLER_23(); _.Move(WS_NUM_CORRESPONDENTE, _filler_23); VarBasis.RedefinePassValue(WS_NUM_CORRESPONDENTE, _filler_23, WS_NUM_CORRESPONDENTE); _filler_23.ValueChanged += () => { _.Move(_filler_23, WS_NUM_CORRESPONDENTE); }; return _filler_23; }
            set { VarBasis.RedefinePassValue(value, _filler_23, WS_NUM_CORRESPONDENTE); }
        }  //Redefines
        public class _REDEF_PF0617B_FILLER_23 : VarBasis
        {
            /*"      07  WS-NUM-LOTERICO           PIC 9(008).*/
            public IntBasis WS_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"      07  WS-NUM-DV-LOTERICO        PIC 9(001).*/
            public IntBasis WS_NUM_DV_LOTERICO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));

            public _REDEF_PF0617B_FILLER_23()
            {
                WS_NUM_LOTERICO.ValueChanged += OnValueChanged;
                WS_NUM_DV_LOTERICO.ValueChanged += OnValueChanged;
            }

        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LBFPF014 LBFPF014 { get; set; } = new Copies.LBFPF014();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LBFPF010 LBFPF010 { get; set; } = new Copies.LBFPF010();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LXFPF028 LXFPF028 { get; set; } = new Copies.LXFPF028();
        public Copies.SPGE053W SPGE053W { get; set; } = new Copies.SPGE053W();
        public Copies.LBWPF002 LBWPF002 { get; set; } = new Copies.LBWPF002();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.APOLICOR APOLICOR { get; set; } = new Dclgens.APOLICOR();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.BENPROPZ BENPROPZ { get; set; } = new Dclgens.BENPROPZ();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.BENEFICI BENEFICI { get; set; } = new Dclgens.BENEFICI();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.OPPAGVA OPPAGVA { get; set; } = new Dclgens.OPPAGVA();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PRODUTOR PRODUTOR { get; set; } = new Dclgens.PRODUTOR();
        public Dclgens.FCLOTERI FCLOTERI { get; set; } = new Dclgens.FCLOTERI();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public PF0617B_C01_BILHETE C01_BILHETE { get; set; } = new PF0617B_C01_BILHETE();
        public PF0617B_C01_ENDERECO C01_ENDERECO { get; set; } = new PF0617B_C01_ENDERECO();
        public PF0617B_PARCELS PARCELS { get; set; } = new PF0617B_PARCELS();
        public PF0617B_V0APOLCORRET V0APOLCORRET { get; set; } = new PF0617B_V0APOLCORRET();
        public PF0617B_BENEFICIARIOS BENEFICIARIOS { get; set; } = new PF0617B_BENEFICIARIOS();
        public PF0617B_DTHBILHETE DTHBILHETE { get; set; } = new PF0617B_DTHBILHETE();
        public PF0617B_EMAIL EMAIL { get; set; } = new PF0617B_EMAIL();
        public PF0617B_ENDERECOS ENDERECOS { get; set; } = new PF0617B_ENDERECOS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_PRP_BILHETE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_PRP_BILHETE.SetFile(MOVTO_PRP_BILHETE_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -960- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -961- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -962- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -965- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -966- DISPLAY '*               PROGRAMA PF0617B               *' . */
            _.Display($"*               PROGRAMA PF0617B               *");

            /*" -967- DISPLAY '* GERA ARQUIVO PROPOSTAS DE BILHETES EMITIDOS  *' . */
            _.Display($"* GERA ARQUIVO PROPOSTAS DE BILHETES EMITIDOS  *");

            /*" -973- DISPLAY '*     VERSAO:  56 - 02/09/2024 - 601144      ..*' . */
            _.Display($"*     VERSAO:  56 - 02/09/2024 - 601144      ..*");

            /*" -974- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -983- DISPLAY '*  PF0617B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  PF0617B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -984- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -986- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -988- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -990- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -992- PERFORM R0007-00-OBTER-DT-PROCE. */

            R0007_00_OBTER_DT_PROCE_SECTION();

            /*" -994- DISPLAY '** DATA REFERENCIA NESTE PROCESSAMENTO ' RELATORI-DATA-REFERENCIA OF DCLRELATORIOS. */
            _.Display($"** DATA REFERENCIA NESTE PROCESSAMENTO {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

            /*" -996- DISPLAY '**' . */
            _.Display($"**");

            /*" -998- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -1000- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -1002- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -1004- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -1006- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -1009- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-BILH EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_BILH == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -1011- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -1013- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -1015- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -1016- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -1017- DISPLAY ' TOT-PROCESSADO = ' W-TOT-PROCESSADO */
            _.Display($" TOT-PROCESSADO = {WAREA_AUXILIAR.W_TOT_PROCESSADO}");

            /*" -1019- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -1021- PERFORM R1110-00-UPDATE-RELATORIOS. */

            R1110_00_UPDATE_RELATORIOS_SECTION();

            /*" -1025- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -1028- DISPLAY '** DATA REFERENCIA PROX. PROCESSAMENTO ' RELATORI-DATA-REFERENCIA OF DCLRELATORIOS. */
            _.Display($"** DATA REFERENCIA PROX. PROCESSAMENTO {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

            /*" -1029- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -1031- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -1034- DISPLAY '** PF0617B ** FIM    PROCESSAMENTO - HORA ' W-TIME-EDIT. */
            _.Display($"** PF0617B ** FIM    PROCESSAMENTO - HORA {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -1034- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -1042- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1044- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1046- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -1054- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -1057- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1058- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1059- DISPLAY '          ERRO SELECT SISTEMAS' */
                _.Display($"          ERRO SELECT SISTEMAS");

                /*" -1061- DISPLAY '          IDSISTEM........... ' SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS */
                _.Display($"          IDSISTEM........... {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -1063- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1066- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1069- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -1071- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -1073- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -1076- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -1078- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -1054- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REF-M1YEAR FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REF_M1YEAR, WAREA_AUXILIAR.WHOST_DATA_REF_M1YEAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-SECTION */
        private void R0007_00_OBTER_DT_PROCE_SECTION()
        {
            /*" -1088- MOVE 'R0007-00-OBTER-DT-PROCE' TO PARAGRAFO. */
            _.Move("R0007-00-OBTER-DT-PROCE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1091- MOVE 'SELECT SEGUROS.RELATORIOS' TO COMANDO. */
            _.Move("SELECT SEGUROS.RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1100- PERFORM R0007_00_OBTER_DT_PROCE_DB_SELECT_1 */

            R0007_00_OBTER_DT_PROCE_DB_SELECT_1();

            /*" -1103- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1104- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1105- DISPLAY '          ERRO SELECT RELATORIOS' */
                _.Display($"          ERRO SELECT RELATORIOS");

                /*" -1107- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1109- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1110- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1112- DISPLAY '** DATA REFERENCIA DO CURSOR: ' WHOST-DATA-REF-CURSOR */
            _.Display($"** DATA REFERENCIA DO CURSOR: {WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}");

            /*" -1114- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -1118- MOVE WHOST-DATA-REF-CURSOR TO W-DT-TIMESTAMP. */
            _.Move(WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR, WAREA_AUXILIAR.FILLER_0.W_DT_TIMESTAMP);

            /*" -1120- MOVE '-00.00.00.000000' TO W-HH-TIMESTAMP. */
            _.Move("-00.00.00.000000", WAREA_AUXILIAR.FILLER_0.W_HH_TIMESTAMP);

            /*" -1121- MOVE W-TIMESTAMP TO RELATORI-TIMESTAMP OF DCLRELATORIOS. */
            _.Move(WAREA_AUXILIAR.W_TIMESTAMP, RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP);

        }

        [StopWatch]
        /*" R0007-00-OBTER-DT-PROCE-DB-SELECT-1 */
        public void R0007_00_OBTER_DT_PROCE_DB_SELECT_1()
        {
            /*" -1100- EXEC SQL SELECT DATA_REFERENCIA, DATA_REFERENCIA INTO :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, :WHOST-DATA-REF-CURSOR FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0617B' WITH UR END-EXEC. */

            var r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1 = new R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1.Execute(r0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(executed_1.WHOST_DATA_REF_CURSOR, WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0007_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -1131- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1133- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1133- OPEN OUTPUT MOVTO-PRP-BILHETE. */
            MOVTO_PRP_BILHETE.Open(REG_PRP_BILHETE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -1143- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1145- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1152- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -1155- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1156- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1157- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -1159- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -1160- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1162- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1165- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -1167- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -1167- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -1152- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = 'PRPSASSE' AND SISTEMA_ORIGEM = 4 WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -1177- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1179- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1227- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -1229- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -1232- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1233- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1234- DISPLAY '          ERRO OPEN  CURSOR  BILHETE  ' */
                _.Display($"          ERRO OPEN  CURSOR  BILHETE  ");

                /*" -1236- DISPLAY '          DATA REFERENCIA CURSOR..... ' WHOST-DATA-REF-CURSOR */
                _.Display($"          DATA REFERENCIA CURSOR..... {WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}");

                /*" -1238- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1239- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1239- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -1227- EXEC SQL DECLARE C01_BILHETE CURSOR FOR SELECT A.NUM_BILHETE , A.NUM_APOLICE , A.FONTE , A.AGE_COBRANCA , A.NUM_MATRICULA , A.COD_AGENCIA , A.OPERACAO_CONTA , A.NUM_CONTA , A.DIG_CONTA , A.COD_CLIENTE , A.PROFISSAO , A.IDE_SEXO , A.ESTADO_CIVIL , A.OCORR_ENDERECO , A.COD_AGENCIA_DEB , A.OPERACAO_CONTA_DEB, A.NUM_CONTA_DEB , A.DIG_CONTA_DEB , A.OPC_COBERTURA , A.DATA_QUITACAO , A.VAL_RCAP , A.RAMO , A.DATA_VENDA , A.DATA_MOVIMENTO , A.NUM_APOL_ANTERIOR , A.SITUACAO , A.TIP_CANCELAMENTO , A.SIT_SINISTRO , A.COD_USUARIO , DATE(A.TIMESTAMP) , B.NUM_APOLICE , B.NUM_ENDOSSO , B.NUM_PROPOSTA , B.DATA_PROPOSTA , B.DATA_EMISSAO , B.NUM_RCAP , B.VAL_RCAP , B.DATA_INIVIGENCIA , B.DATA_TERVIGENCIA , B.COD_PRODUTO FROM SEGUROS.BILHETE A, SEGUROS.ENDOSSOS B WHERE A.SITUACAO = '9' AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = 0 AND B.DATA_EMISSAO >= :WHOST-DATA-REF-CURSOR WITH UR END-EXEC. */
            C01_BILHETE = new PF0617B_C01_BILHETE(true);
            string GetQuery_C01_BILHETE()
            {
                var query = @$"SELECT A.NUM_BILHETE
							, 
							A.NUM_APOLICE
							, 
							A.FONTE
							, 
							A.AGE_COBRANCA
							, 
							A.NUM_MATRICULA
							, 
							A.COD_AGENCIA
							, 
							A.OPERACAO_CONTA
							, 
							A.NUM_CONTA
							, 
							A.DIG_CONTA
							, 
							A.COD_CLIENTE
							, 
							A.PROFISSAO
							, 
							A.IDE_SEXO
							, 
							A.ESTADO_CIVIL
							, 
							A.OCORR_ENDERECO
							, 
							A.COD_AGENCIA_DEB
							, 
							A.OPERACAO_CONTA_DEB
							, 
							A.NUM_CONTA_DEB
							, 
							A.DIG_CONTA_DEB
							, 
							A.OPC_COBERTURA
							, 
							A.DATA_QUITACAO
							, 
							A.VAL_RCAP
							, 
							A.RAMO
							, 
							A.DATA_VENDA
							, 
							A.DATA_MOVIMENTO
							, 
							A.NUM_APOL_ANTERIOR
							, 
							A.SITUACAO
							, 
							A.TIP_CANCELAMENTO
							, 
							A.SIT_SINISTRO
							, 
							A.COD_USUARIO
							, 
							DATE(A.TIMESTAMP)
							, 
							B.NUM_APOLICE
							, 
							B.NUM_ENDOSSO
							, 
							B.NUM_PROPOSTA
							, 
							B.DATA_PROPOSTA
							, 
							B.DATA_EMISSAO
							, 
							B.NUM_RCAP
							, 
							B.VAL_RCAP
							, 
							B.DATA_INIVIGENCIA
							, 
							B.DATA_TERVIGENCIA
							, 
							B.COD_PRODUTO 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.ENDOSSOS B 
							WHERE A.SITUACAO = '9' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = 0 
							AND B.DATA_EMISSAO >= '{WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}'";

                return query;
            }
            C01_BILHETE.GetQueryEvent += GetQuery_C01_BILHETE;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -1229- EXEC SQL OPEN C01_BILHETE END-EXEC. */

            C01_BILHETE.Open();

        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-DECLARE-1 */
        public void R0350_00_LER_ENDERECO_DB_DECLARE_1()
        {
            /*" -1897- EXEC SQL DECLARE C01_ENDERECO CURSOR FOR SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND COD_ENDERECO = 1 ORDER BY OCORR_ENDERECO DESC WITH UR END-EXEC. */
            C01_ENDERECO = new PF0617B_C01_ENDERECO(true);
            string GetQuery_C01_ENDERECO()
            {
                var query = @$"SELECT COD_CLIENTE
							, 
							COD_ENDERECO
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
							TELEX
							, 
							SIT_REGISTRO 
							FROM SEGUROS.ENDERECOS 
							WHERE COD_CLIENTE = 
							'{ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}' 
							AND COD_ENDERECO = 1 
							ORDER BY OCORR_ENDERECO DESC";

                return query;
            }
            C01_ENDERECO.GetQueryEvent += GetQuery_C01_ENDERECO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -1249- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1251- MOVE 'FETCH BILHETE' TO COMANDO. */
            _.Move("FETCH BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1293- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -1299- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1300- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1301- MOVE 'FIM' TO W-FIM-MOVTO-BILH */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_BILH);

                    /*" -1301- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -1303- ELSE */
                }
                else
                {


                    /*" -1304- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -1306- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -1307- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1308- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1309- ELSE */
                }

            }
            else
            {


                /*" -1311- ADD 1 TO W-NSL W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -1312- IF W-CONTROLE > 1999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 1999)
                {

                    /*" -1313- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -1314- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -1315- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -1317- DISPLAY '* PF0617B * TOTAL LIDOS ' W-NSL '  HORA ' W-TIME-EDIT */

                    $"* PF0617B * TOTAL LIDOS {WAREA_AUXILIAR.W_NSL}  HORA {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -1325- END-IF */
                }


                /*" -1343- COMPUTE W-TOT-PROCESSADO = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
                WAREA_AUXILIAR.W_TOT_PROCESSADO.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -1293- EXEC SQL FETCH C01_BILHETE INTO :DCLBILHETE.BILHETE-NUM-BILHETE , :DCLBILHETE.BILHETE-NUM-APOLICE , :DCLBILHETE.BILHETE-FONTE , :DCLBILHETE.BILHETE-AGE-COBRANCA , :DCLBILHETE.BILHETE-NUM-MATRICULA , :DCLBILHETE.BILHETE-COD-AGENCIA , :DCLBILHETE.BILHETE-OPERACAO-CONTA , :DCLBILHETE.BILHETE-NUM-CONTA , :DCLBILHETE.BILHETE-DIG-CONTA , :DCLBILHETE.BILHETE-COD-CLIENTE , :DCLBILHETE.BILHETE-PROFISSAO , :DCLBILHETE.BILHETE-IDE-SEXO , :DCLBILHETE.BILHETE-ESTADO-CIVIL , :DCLBILHETE.BILHETE-OCORR-ENDERECO , :DCLBILHETE.BILHETE-COD-AGENCIA-DEB , :DCLBILHETE.BILHETE-OPERACAO-CONTA-DEB , :DCLBILHETE.BILHETE-NUM-CONTA-DEB , :DCLBILHETE.BILHETE-DIG-CONTA-DEB , :DCLBILHETE.BILHETE-OPC-COBERTURA , :DCLBILHETE.BILHETE-DATA-QUITACAO , :DCLBILHETE.BILHETE-VAL-RCAP , :DCLBILHETE.BILHETE-RAMO , :DCLBILHETE.BILHETE-DATA-VENDA , :DCLBILHETE.BILHETE-DATA-MOVIMENTO , :DCLBILHETE.BILHETE-NUM-APOL-ANTERIOR , :DCLBILHETE.BILHETE-SITUACAO , :DCLBILHETE.BILHETE-TIP-CANCELAMENTO , :DCLBILHETE.BILHETE-SIT-SINISTRO , :DCLBILHETE.BILHETE-COD-USUARIO , :WHOST-DATA-REFERENCIA , :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE , :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO , :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA , :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA , :DCLENDOSSOS.ENDOSSOS-DATA-EMISSAO , :DCLENDOSSOS.ENDOSSOS-NUM-RCAP , :DCLENDOSSOS.ENDOSSOS-VAL-RCAP , :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA , :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA , :DCLENDOSSOS.ENDOSSOS-COD-PRODUTO END-EXEC. */

            if (C01_BILHETE.Fetch())
            {
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_FONTE, BILHETE.DCLBILHETE.BILHETE_FONTE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_AGE_COBRANCA, BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_MATRICULA, BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_AGENCIA, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OPERACAO_CONTA, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_CONTA, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DIG_CONTA, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_CLIENTE, BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_PROFISSAO, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_IDE_SEXO, BILHETE.DCLBILHETE.BILHETE_IDE_SEXO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_ESTADO_CIVIL, BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OCORR_ENDERECO, BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_AGENCIA_DEB, BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OPERACAO_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DIG_CONTA_DEB, BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_VENDA, BILHETE.DCLBILHETE.BILHETE_DATA_VENDA);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_TIP_CANCELAMENTO, BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_SIT_SINISTRO, BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO);
                _.Move(C01_BILHETE.DCLBILHETE_BILHETE_COD_USUARIO, BILHETE.DCLBILHETE.BILHETE_COD_USUARIO);
                _.Move(C01_BILHETE.WHOST_DATA_REFERENCIA, WAREA_AUXILIAR.WHOST_DATA_REFERENCIA);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(C01_BILHETE.DCLENDOSSOS_ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -1301- EXEC SQL CLOSE C01_BILHETE END-EXEC */

            C01_BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -1357- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1359- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1361- MOVE SPACES TO REG-HEADER. */
            _.Move("", LXFPF990.REG_HEADER);

            /*" -1364- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -1367- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -1368- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO);

            /*" -1369- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO);

            /*" -1371- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO);

            /*" -1374- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1377- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1380- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -1383- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFPF990.REG_HEADER.RH_NSAS);

            /*" -1385- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -1388- MOVE 01 TO RH-COD-EMPRESA OF REG-HEADER. */
            _.Move(01, LXFPF990.REG_HEADER.RH_COD_EMPRESA);

            /*" -1391- MOVE 'CAIXA VIDA E PREVIDENCIA S.A.  ' TO RH-NOME-EMPRESA OF REG-HEADER. */
            _.Move("CAIXA VIDA E PREVIDENCIA S.A.  ", LXFPF990.REG_HEADER.RH_NOME_EMPRESA);

            /*" -1394- MOVE SPACES TO RH-FILLER2 OF REG-HEADER. */
            _.Move("", LXFPF990.REG_HEADER.RH_FILLER2);

            /*" -1394- WRITE REG-PRP-BILHETE FROM REG-HEADER. */
            _.Move(LXFPF990.REG_HEADER.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1414- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1415- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1416- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1418- DISPLAY 'BILHETE = ' BILHETE-NUM-BILHETE OF DCLBILHETE */
            _.Display($"BILHETE = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

            /*" -1420- MOVE 'NAO' TO W-EXISTE-FIDELIZ W-TEM-RENOVACAO */
            _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ, W_TEM_RENOVACAO);

            /*" -1422- INITIALIZE W-ORIGEM-MARSH */
            _.Initialize(
                W_ORIGEM_MARSH
            );

            /*" -1424- PERFORM R0200-00-LER-PROP-FIDELIZ */

            R0200_00_LER_PROP_FIDELIZ_SECTION();

            /*" -1425- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
            {

                /*" -1426- MOVE PROPOFID-ORIGEM-PROPOSTA TO N88-ACHOU-ORIGEM-34 */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WAREA_AUXILIAR.N88_ACHOU_ORIGEM_34);

                /*" -1430- IF ( PROPOFID-ORIGEM-PROPOSTA = 12 OR 18 OR 19 OR 34 AND PROPOFID-CANAL-PROPOSTA = 1 AND PROPOFID-COD-PRODUTO-SIVPF = 9 OR 10 OR 29 ) OR ( PROPOFID-ORIGEM-PROPOSTA = 1026 ) */

                if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("12", "18", "19", "34") && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA == 1 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("9", "10", "29")) || (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1026))
                {

                    /*" -1431- MOVE 'SIM' TO W-ORIGEM-MARSH */
                    _.Move("SIM", W_ORIGEM_MARSH);

                    /*" -1432- ELSE */
                }
                else
                {


                    /*" -1433- ADD 1 TO W-TOT-DESPREZADO */
                    WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                    /*" -1434- GO TO R0150-LEITURA */

                    R0150_LEITURA(); //GOTO
                    return;

                    /*" -1435- END-IF */
                }


                /*" -1437- END-IF */
            }


            /*" -1438- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
            {

                /*" -1440- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

                /*" -1442- PERFORM R0250-00-VERIFICA-HISTORICO */

                R0250_00_VERIFICA_HISTORICO_SECTION();

                /*" -1443- IF WS-JA-ENVIADA EQUAL 'S' */

                if (WS_JA_ENVIADA == "S")
                {

                    /*" -1444- GO TO R0150-LEITURA */

                    R0150_LEITURA(); //GOTO
                    return;

                    /*" -1445- END-IF */
                }


                /*" -1447- END-IF */
            }


            /*" -1448- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
            {

                /*" -1454- IF (ENDOSSOS-COD-PRODUTO EQUAL 3721) AND (PROPOFID-CANAL-PROPOSTA EQUAL 03 OR 04) AND (PROPOFID-ORIGEM-PROPOSTA EQUAL 13 OR 15 OR 22) AND (PROPOFID-COD-PRODUTO-SIVPF EQUAL 29) */

                if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 3721) && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.In("03", "04")) && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("13", "15", "22")) && (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == 29))
                {

                    /*" -1455- ADD 1 TO W-TOT-DESPREZADO */
                    WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                    /*" -1457- DISPLAY 'NAO ENVIAR PROPOSTA AMPARO 3721 DO SISPL >> ' BILHETE-NUM-APOLICE OF DCLBILHETE */
                    _.Display($"NAO ENVIAR PROPOSTA AMPARO 3721 DO SISPL >> {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

                    /*" -1458- GO TO R0150-LEITURA */

                    R0150_LEITURA(); //GOTO
                    return;

                    /*" -1459- END-IF */
                }


                /*" -1461- END-IF */
            }


            /*" -1463- IF BILHETE-NUM-APOL-ANTERIOR OF DCLBILHETE EQUAL ZEROS */

            if (BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR == 00)
            {

                /*" -1464- CONTINUE */

                /*" -1465- ELSE */
            }
            else
            {


                /*" -1467- MOVE BILHETE-NUM-APOL-ANTERIOR OF DCLBILHETE TO NUM-APOL-ANT */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR, NUM_APOL_ANT);

                /*" -1469- PERFORM R0598-00-SELECT-QUANT-BIL-RENO THRU R0598-99-SAIDA */

                R0598_00_SELECT_QUANT_BIL_RENO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0598_99_SAIDA*/


                /*" -1470- PERFORM R0599-00-SELECT-PROPOFID */

                R0599_00_SELECT_PROPOFID_SECTION();

                /*" -1472- END-IF */
            }


            /*" -1477- PERFORM R0300-00-LER-CLIENTE */

            R0300_00_LER_CLIENTE_SECTION();

            /*" -1479- IF VIND-DTNASCI LESS ZEROS AND CGCCPF OF DCLCLIENTES EQUAL ZEROS */

            if (VIND_DTNASCI < 00 && CLIENTE.DCLCLIENTES.CGCCPF == 00)
            {

                /*" -1480- DISPLAY 'PF0617B - SEGURO NAO ENVIADO A CEF' */
                _.Display($"PF0617B - SEGURO NAO ENVIADO A CEF");

                /*" -1481- DISPLAY '          CPF E DT.NASC. ZERADOS. ' */
                _.Display($"          CPF E DT.NASC. ZERADOS. ");

                /*" -1485- DISPLAY '          NUMERO DO BILHETE...... ' BILHETE-NUM-BILHETE OF DCLBILHETE '   ' CGCCPF OF DCLCLIENTES */

                $"          NUMERO DO BILHETE...... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}   {CLIENTE.DCLCLIENTES.CGCCPF}"
                .Display();

                /*" -1487- ADD 1 TO W-TOT-DESPREZADO */
                WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                /*" -1508- ELSE */
            }
            else
            {


                /*" -1516- IF ENDOSSOS-COD-PRODUTO EQUAL 8114 OR 8115 OR 8116 OR 8117 OR 8118 OR JVPRD8114 OR JVPRD8115 OR JVPRD8116 OR JVPRD8117 OR JVPRD8118 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8114", "8115", "8116", "8117", "8118", JVBKINCL.JV_PRODUTOS.JVPRD8114.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8115.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8116.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8117.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8118.ToString()))
                {

                    /*" -1517- ADD 1 TO W-TOT-DESPREZADO */
                    WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                    /*" -1519- DISPLAY 'PROPOSTA REJEITADA PARCERIA SYSTEMCRED' BILHETE-NUM-APOLICE OF DCLBILHETE */
                    _.Display($"PROPOSTA REJEITADA PARCERIA SYSTEMCRED{BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

                    /*" -1521- ELSE */
                }
                else
                {


                    /*" -1522- PERFORM R0345-00-LER-ENDERECO */

                    R0345_00_LER_ENDERECO_SECTION();

                    /*" -1523- IF W-EXISTE-ENDERECO EQUAL 'NAO' */

                    if (WAREA_AUXILIAR.W_EXISTE_ENDERECO == "NAO")
                    {

                        /*" -1524- PERFORM R0350-00-LER-ENDERECO */

                        R0350_00_LER_ENDERECO_SECTION();

                        /*" -1525- END-IF */
                    }


                    /*" -1526- PERFORM R0450-00-LER-PRODUTOS-SIVPF */

                    R0450_00_LER_PRODUTOS_SIVPF_SECTION();

                    /*" -1527- PERFORM R0500-00-LER-RCAP */

                    R0500_00_LER_RCAP_SECTION();

                    /*" -1528- PERFORM R0570-00-OBTER-COMISSAO */

                    R0570_00_OBTER_COMISSAO_SECTION();

                    /*" -1529- PERFORM R0580-00-OBTER-VAL-TARIFA */

                    R0580_00_OBTER_VAL_TARIFA_SECTION();

                    /*" -1531- PERFORM R0590-00-LER-CONVERSAO-SICOB */

                    R0590_00_LER_CONVERSAO_SICOB_SECTION();

                    /*" -1532- IF CONVERSAO-CADASTRADA */

                    if (WAREA_AUXILIAR.W_CONVERSAO["CONVERSAO_CADASTRADA"])
                    {

                        /*" -1533- PERFORM R0595-00-LER-PROP-FIDELIZ */

                        R0595_00_LER_PROP_FIDELIZ_SECTION();

                        /*" -1534- IF W-EXISTE-FIDELIZ EQUAL 'SIM' */

                        if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "SIM")
                        {

                            /*" -1535- INITIALIZE W-ORIGEM-MARSH */
                            _.Initialize(
                                W_ORIGEM_MARSH
                            );

                            /*" -1537- MOVE PROPOFID-ORIGEM-PROPOSTA TO N88-ACHOU-ORIGEM-34 */
                            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA, WAREA_AUXILIAR.N88_ACHOU_ORIGEM_34);

                            /*" -1545- IF ( PROPOFID-ORIGEM-PROPOSTA EQUAL 12 OR 18 OR 19 OR 34 AND PROPOFID-CANAL-PROPOSTA EQUAL 1 AND PROPOFID-COD-PRODUTO-SIVPF EQUAL 9 OR 10 OR 29 ) OR ( PROPOFID-ORIGEM-PROPOSTA = 1026 ) */

                            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.In("12", "18", "19", "34") && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA == 1 && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.In("9", "10", "29")) || (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA == 1026))
                            {

                                /*" -1546- MOVE 'SIM' TO W-ORIGEM-MARSH */
                                _.Move("SIM", W_ORIGEM_MARSH);

                                /*" -1548- END-IF */
                            }


                            /*" -1550- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
                            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

                            /*" -1552- PERFORM R0250-00-VERIFICA-HISTORICO */

                            R0250_00_VERIFICA_HISTORICO_SECTION();

                            /*" -1553- IF WS-JA-ENVIADA EQUAL 'S' */

                            if (WS_JA_ENVIADA == "S")
                            {

                                /*" -1554- ADD 1 TO W-TOT-DESPREZADO */
                                WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                                /*" -1555- GO TO R0150-LEITURA */

                                R0150_LEITURA(); //GOTO
                                return;

                                /*" -1556- ELSE */
                            }
                            else
                            {


                                /*" -1557- IF W-ORIGEM-MARSH NOT EQUAL 'SIM' */

                                if (W_ORIGEM_MARSH != "SIM")
                                {

                                    /*" -1558- ADD 1 TO W-TOT-DESPREZADO */
                                    WAREA_AUXILIAR.W_TOT_DESPREZADO.Value = WAREA_AUXILIAR.W_TOT_DESPREZADO + 1;

                                    /*" -1559- PERFORM R3055-MUDA-SITUACAO-ENVIO */

                                    R3055_MUDA_SITUACAO_ENVIO_SECTION();

                                    /*" -1560- GO TO R0150-LEITURA */

                                    R0150_LEITURA(); //GOTO
                                    return;

                                    /*" -1561- END-IF */
                                }


                                /*" -1562- END-IF */
                            }


                            /*" -1563- END-IF */
                        }


                        /*" -1565- END-IF */
                    }


                    /*" -1566- PERFORM R0600-00-GERAR-REGISTRO-TP1 */

                    R0600_00_GERAR_REGISTRO_TP1_SECTION();

                    /*" -1567- PERFORM R0650-00-GERAR-REGISTRO-TP2 */

                    R0650_00_GERAR_REGISTRO_TP2_SECTION();

                    /*" -1568- PERFORM R0700-00-GERAR-REGISTRO-TP3 */

                    R0700_00_GERAR_REGISTRO_TP3_SECTION();

                    /*" -1569- PERFORM R0750-PROCESSAR-BENEFICIARIOS */

                    R0750_PROCESSAR_BENEFICIARIOS_SECTION();

                    /*" -1575- PERFORM R1200-00-GERAR-REGISTRO-TPD */

                    R1200_00_GERAR_REGISTRO_TPD_SECTION();

                    /*" -1576- IF BILHETE-NUM-MATRICULA OF DCLBILHETE > 0 */

                    if (BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA > 0)
                    {

                        /*" -1578- IF ENDOSSOS-COD-PRODUTO OF DCLENDOSSOS = 3701 OR JVPRD3701 */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString()))
                        {

                            /*" -1579- PERFORM R0910-TRATAR-NUM-MATRICULA */

                            R0910_TRATAR_NUM_MATRICULA_SECTION();

                            /*" -1580- PERFORM R0950-PROCESSAR-VENDAS */

                            R0950_PROCESSAR_VENDAS_SECTION();

                            /*" -1581- END-IF */
                        }


                        /*" -1583- END-IF */
                    }


                    /*" -1584- IF W-ORIGEM-MARSH EQUAL 'SIM' */

                    if (W_ORIGEM_MARSH == "SIM")
                    {

                        /*" -1585- PERFORM R3050-MUDA-SITUACAO-ENVIO */

                        R3050_MUDA_SITUACAO_ENVIO_SECTION();

                        /*" -1586- ELSE */
                    }
                    else
                    {


                        /*" -1587- IF W-TEM-RENOVACAO NOT EQUAL 'SIM' */

                        if (W_TEM_RENOVACAO != "SIM")
                        {

                            /*" -1588- PERFORM R3000-GERAR-TB-CORPORATIVAS */

                            R3000_GERAR_TB_CORPORATIVAS_SECTION();

                            /*" -1589- ADD 1 TO WS-IN-PROPOFID1 */
                            WS_IN_PROPOFID1.Value = WS_IN_PROPOFID1 + 1;

                            /*" -1590- END-IF */
                        }


                        /*" -1592- END-IF. */
                    }

                }

            }


            /*" -1593- IF ENDOSSOS-COD-PRODUTO EQUAL 8104 OR 8112 OR 8201 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("8104", "8112", "8201"))
            {

                /*" -1594- IF W-EXISTE-FIDELIZ EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_EXISTE_FIDELIZ == "NAO")
                {

                    /*" -1595- PERFORM R3000-GERAR-TB-CORPORATIVAS */

                    R3000_GERAR_TB_CORPORATIVAS_SECTION();

                    /*" -1596- ADD 1 TO WS-IN-PROPOFID2 */
                    WS_IN_PROPOFID2.Value = WS_IN_PROPOFID2 + 1;

                    /*" -1597- END-IF */
                }


                /*" -1598- END-IF */
            }


            /*" -1598- . */

            /*" -0- FLUXCONTROL_PERFORM R0150_LEITURA */

            R0150_LEITURA();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1602- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-SECTION */
        private void R0200_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -1612- MOVE 'R0200-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0200-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1613- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1615- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1616- MOVE ZEROS TO N88-ACHOU-ORIGEM-34 */
            _.Move(0, WAREA_AUXILIAR.N88_ACHOU_ORIGEM_34);

            /*" -1619- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO PROPOFID-NUM-SICOB */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -1640- PERFORM R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -1643- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -1644- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -1645- ELSE */
            }
            else
            {


                /*" -1646- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1647- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -1648- ELSE */
                }
                else
                {


                    /*" -1649- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -1650- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1652- DISPLAY '          NUMERO DO SICOB............ ' PROPOFID-NUM-SICOB */
                    _.Display($"          NUMERO DO SICOB............ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                    /*" -1654- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1655- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1655- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1640- EXEC SQL SELECT SIT_PROPOSTA , CANAL_PROPOSTA , ORIGEM_PROPOSTA , COD_PRODUTO_SIVPF , NUM_IDENTIFICACAO , NUM_SICOB , COD_EMPRESA_SIVPF , NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-NUM-SICOB , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :PROPOFID-NUM-SICOB WITH UR END-EXEC. */

            var r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0200_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(executed_1.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0250-00-VERIFICA-HISTORICO-SECTION */
        private void R0250_00_VERIFICA_HISTORICO_SECTION()
        {
            /*" -1662- MOVE 'R0250-00-VERIFICA-HISTORICO' TO PARAGRAFO. */
            _.Move("R0250-00-VERIFICA-HISTORICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1663- MOVE 'SELECT HIST_PROP_FIDELIZ' TO COMANDO. */
            _.Move("SELECT HIST_PROP_FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1665- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1667- INITIALIZE WS-JA-ENVIADA. */
            _.Initialize(
                WS_JA_ENVIADA
            );

            /*" -1675- PERFORM R0250_00_VERIFICA_HISTORICO_DB_SELECT_1 */

            R0250_00_VERIFICA_HISTORICO_DB_SELECT_1();

            /*" -1678- IF SQLCODE NOT EQUAL ZEROS AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -1679- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1680- DISPLAY '  ERRO SELECT HIST_PROP_FIDELIZ' */
                _.Display($"  ERRO SELECT HIST_PROP_FIDELIZ");

                /*" -1682- DISPLAY '  NUMERO SICOB  = ' PROPOFID-NUM-SICOB */
                _.Display($"  NUMERO SICOB  = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                /*" -1684- DISPLAY '  IDENTIFICACAO = ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"  IDENTIFICACAO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -1686- DISPLAY '  SQLCODE.......= ' SQLCODE */
                _.Display($"  SQLCODE.......= {DB.SQLCODE}");

                /*" -1687- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -1689- END-IF. */
            }


            /*" -1691- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -1692- ELSE */
            }
            else
            {


                /*" -1693- MOVE 'S' TO WS-JA-ENVIADA */
                _.Move("S", WS_JA_ENVIADA);

                /*" -1694- END-IF. */
            }


        }

        [StopWatch]
        /*" R0250-00-VERIFICA-HISTORICO-DB-SELECT-1 */
        public void R0250_00_VERIFICA_HISTORICO_DB_SELECT_1()
        {
            /*" -1675- EXEC SQL SELECT SIT_PROPOSTA INTO :PROPFIDH-SIT-PROPOSTA FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = 'EMT' WITH UR END-EXEC. */

            var r0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1 = new R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1.Execute(r0250_00_VERIFICA_HISTORICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1703- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1704- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1706- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1709- MOVE BILHETE-COD-CLIENTE OF DCLBILHETE TO COD-CLIENTE OF DCLCLIENTES. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);

            /*" -1727- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1730- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1731- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1732- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                _.Display($"          ERRO SELECT TABELA CLIENTES");

                /*" -1734- DISPLAY '          CODIGO DO CLIENTE.......... ' BILHETE-COD-CLIENTE OF DCLBILHETE */
                _.Display($"          CODIGO DO CLIENTE.......... {BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE}");

                /*" -1736- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1737- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1737- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1727- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO INTO :DCLCLIENTES.COD-CLIENTE , :DCLCLIENTES.NOME-RAZAO , :DCLCLIENTES.TIPO-PESSOA , :DCLCLIENTES.CGCCPF , :DCLCLIENTES.SIT-REGISTRO , :DCLCLIENTES.DATA-NASCIMENTO:VIND-DTNASCI FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :DCLCLIENTES.COD-CLIENTE WITH UR END-EXEC. */

            var r0300_00_LER_CLIENTE_DB_SELECT_1_Query1 = new R0300_00_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                COD_CLIENTE = CLIENTE.DCLCLIENTES.COD_CLIENTE.ToString(),
            };

            var executed_1 = R0300_00_LER_CLIENTE_DB_SELECT_1_Query1.Execute(r0300_00_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_CLIENTE, CLIENTE.DCLCLIENTES.COD_CLIENTE);
                _.Move(executed_1.NOME_RAZAO, CLIENTE.DCLCLIENTES.NOME_RAZAO);
                _.Move(executed_1.TIPO_PESSOA, CLIENTE.DCLCLIENTES.TIPO_PESSOA);
                _.Move(executed_1.CGCCPF, CLIENTE.DCLCLIENTES.CGCCPF);
                _.Move(executed_1.SIT_REGISTRO, CLIENTE.DCLCLIENTES.SIT_REGISTRO);
                _.Move(executed_1.DATA_NASCIMENTO, CLIENTE.DCLCLIENTES.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0340-00-LER-ENDOSSO-SECTION */
        private void R0340_00_LER_ENDOSSO_SECTION()
        {
            /*" -1747- MOVE 'R0340-00-LER-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0340-00-LER-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1748- MOVE 'SELECT ENDOSSO' TO COMANDO. */
            _.Move("SELECT ENDOSSO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1750- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1753- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -1756- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO OF DCLENDOSSOS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -1779- PERFORM R0340_00_LER_ENDOSSO_DB_SELECT_1 */

            R0340_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -1782- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1783- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1784- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -1785- DISPLAY '          ERRO SELECT TAB. ENDOSSO' */
                    _.Display($"          ERRO SELECT TAB. ENDOSSO");

                    /*" -1787- DISPLAY '          NUMERO APOLICE.......... ' ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS */
                    _.Display($"          NUMERO APOLICE.......... {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -1789- DISPLAY '          SQLCODE................. ' SQLCODE */
                    _.Display($"          SQLCODE................. {DB.SQLCODE}");

                    /*" -1790- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1790- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0340-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R0340_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -1779- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PROPOSTA, DATA_PROPOSTA, DATA_EMISSAO, NUM_RCAP, VAL_RCAP, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE, :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO, :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-EMISSAO, :DCLENDOSSOS.ENDOSSOS-NUM-RCAP, :DCLENDOSSOS.ENDOSSOS-VAL-RCAP, :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA, :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0340_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0340_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r0340_00_LER_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(executed_1.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(executed_1.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_SAIDA*/

        [StopWatch]
        /*" R0345-00-LER-ENDERECO-SECTION */
        private void R0345_00_LER_ENDERECO_SECTION()
        {
            /*" -1800- MOVE 'R0345-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0345-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1801- MOVE 'SELECT ENDERECO' TO COMANDO. */
            _.Move("SELECT ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1803- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1806- MOVE BILHETE-COD-CLIENTE OF DCLBILHETE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1809- MOVE BILHETE-OCORR-ENDERECO OF DCLBILHETE TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -1843- PERFORM R0345_00_LER_ENDERECO_DB_SELECT_1 */

            R0345_00_LER_ENDERECO_DB_SELECT_1();

            /*" -1846- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1847- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1848- MOVE 'NAO' TO W-EXISTE-ENDERECO */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_ENDERECO);

                    /*" -1849- ELSE */
                }
                else
                {


                    /*" -1850- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -1851- DISPLAY '          ERRO DECLER TABELA ENDERECOS' */
                    _.Display($"          ERRO DECLER TABELA ENDERECOS");

                    /*" -1853- DISPLAY '          CODIGO DO CLIENTE.......... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                    _.Display($"          CODIGO DO CLIENTE.......... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                    /*" -1855- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1856- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1857- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1858- ELSE */
                }

            }
            else
            {


                /*" -1858- MOVE 'SIM' TO W-EXISTE-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_ENDERECO);
            }


        }

        [StopWatch]
        /*" R0345-00-LER-ENDERECO-DB-SELECT-1 */
        public void R0345_00_LER_ENDERECO_DB_SELECT_1()
        {
            /*" -1843- EXEC SQL SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND OCORR_ENDERECO = :DCLENDERECOS.ENDERECO-OCORR-ENDERECO WITH UR END-EXEC. */

            var r0345_00_LER_ENDERECO_DB_SELECT_1_Query1 = new R0345_00_LER_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0345_00_LER_ENDERECO_DB_SELECT_1_Query1.Execute(r0345_00_LER_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(executed_1.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(executed_1.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(executed_1.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(executed_1.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(executed_1.ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0345_SAIDA*/

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-SECTION */
        private void R0350_00_LER_ENDERECO_SECTION()
        {
            /*" -1869- MOVE 'R0350-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1870- MOVE 'DECLER ENDERECO' TO COMANDO. */
            _.Move("DECLER ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1872- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1875- MOVE BILHETE-COD-CLIENTE OF DCLBILHETE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1897- PERFORM R0350_00_LER_ENDERECO_DB_DECLARE_1 */

            R0350_00_LER_ENDERECO_DB_DECLARE_1();

            /*" -1900- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1901- DISPLAY 'PF0617B - FIM ANORMAL ' */
                _.Display($"PF0617B - FIM ANORMAL ");

                /*" -1902- DISPLAY '          ERRO DECLER TABELA ENDERECOS' */
                _.Display($"          ERRO DECLER TABELA ENDERECOS");

                /*" -1904- DISPLAY '          CODIGO DO CLIENTE.......... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE.......... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1906- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1907- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1909- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1911- MOVE 'OPEN  CURSOR ENDERECO ' TO COMANDO. */
            _.Move("OPEN  CURSOR ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1911- PERFORM R0350_00_LER_ENDERECO_DB_OPEN_1 */

            R0350_00_LER_ENDERECO_DB_OPEN_1();

            /*" -1914- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1915- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1916- DISPLAY '          ERRO OPEN  CURSOR  ENDERECO ' */
                _.Display($"          ERRO OPEN  CURSOR  ENDERECO ");

                /*" -1918- DISPLAY '          CODIGO DO CLIENTE.......... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE.......... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1920- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1921- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1923- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1925- MOVE 'FETCH CURSOR ENDERECO ' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1941- PERFORM R0350_00_LER_ENDERECO_DB_FETCH_1 */

            R0350_00_LER_ENDERECO_DB_FETCH_1();

            /*" -1944- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- MOVE ZEROS TO ENDERECO-OCORR-ENDERECO OF DCLENDERECOS */
                _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

                /*" -1951- MOVE SPACES TO ENDERECO-ENDERECO OF DCLENDERECOS ENDERECO-BAIRRO OF DCLENDERECOS ENDERECO-CIDADE OF DCLENDERECOS ENDERECO-SIGLA-UF OF DCLENDERECOS */
                _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

                /*" -1958- MOVE ZEROS TO ENDERECO-CEP OF DCLENDERECOS ENDERECO-DDD OF DCLENDERECOS ENDERECO-TELEFONE OF DCLENDERECOS ENDERECO-FAX OF DCLENDERECOS ENDERECO-TELEX OF DCLENDERECOS. */
                _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
            }


            /*" -1960- MOVE 'CLOSE CURSOR ENDERECO ' TO COMANDO. */
            _.Move("CLOSE CURSOR ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1960- PERFORM R0350_00_LER_ENDERECO_DB_CLOSE_1 */

            R0350_00_LER_ENDERECO_DB_CLOSE_1();

            /*" -1963- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1964- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -1965- DISPLAY '          ERRO CLOSE CURSOR  ENDERECO ' */
                _.Display($"          ERRO CLOSE CURSOR  ENDERECO ");

                /*" -1967- DISPLAY '          CODIGO DO CLIENTE.......... ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */
                _.Display($"          CODIGO DO CLIENTE.......... {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1969- DISPLAY '          SQLCODE.................... ' SQLCODE */
                _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                /*" -1970- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1970- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-OPEN-1 */
        public void R0350_00_LER_ENDERECO_DB_OPEN_1()
        {
            /*" -1911- EXEC SQL OPEN C01_ENDERECO END-EXEC. */

            C01_ENDERECO.Open();

        }

        [StopWatch]
        /*" R0573-00-LER-PARCELA-DB-DECLARE-1 */
        public void R0573_00_LER_PARCELA_DB_DECLARE_1()
        {
            /*" -2279- EXEC SQL DECLARE PARCELS CURSOR FOR SELECT A.PRM_TARIFARIO_IX FROM SEGUROS.PARCELAS A WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO ORDER BY TIMESTAMP WITH UR END-EXEC */
            PARCELS = new PF0617B_PARCELS(true);
            string GetQuery_PARCELS()
            {
                var query = @$"SELECT A.PRM_TARIFARIO_IX 
							FROM SEGUROS.PARCELAS A 
							WHERE A.NUM_APOLICE = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}' 
							AND A.NUM_ENDOSSO = '{PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO}' 
							ORDER BY TIMESTAMP";

                return query;
            }
            PARCELS.GetQueryEvent += GetQuery_PARCELS;

        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-FETCH-1 */
        public void R0350_00_LER_ENDERECO_DB_FETCH_1()
        {
            /*" -1941- EXEC SQL FETCH C01_ENDERECO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO END-EXEC. */

            if (C01_ENDERECO.Fetch())
            {
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0350-00-LER-ENDERECO-DB-CLOSE-1 */
        public void R0350_00_LER_ENDERECO_DB_CLOSE_1()
        {
            /*" -1960- EXEC SQL CLOSE C01_ENDERECO END-EXEC */

            C01_ENDERECO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-PROFISSAO-SECTION */
        private void R0400_00_LER_PROFISSAO_SECTION()
        {
            /*" -1980- MOVE 'R0400-00-LER-PROFISSAO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-PROFISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1984- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1986- IF BILHETE-PROFISSAO OF DCLBILHETE NOT EQUAL SPACES */

            if (!BILHETE.DCLBILHETE.BILHETE_PROFISSAO.IsEmpty())
            {

                /*" -1990- MOVE BILHETE-PROFISSAO OF DCLBILHETE TO CBO-DESCR-CBO OF DCLCBO R1-DESCRICAO-PROFISSAO */
                _.Move(BILHETE.DCLBILHETE.BILHETE_PROFISSAO, CBO.DCLCBO.CBO_DESCR_CBO, LBFPF011.REG_CLIENTES.R1_DESCRICAO_PROFISSAO);

                /*" -1992- PERFORM R0410-00-LER-CBO */

                R0410_00_LER_CBO_SECTION();

                /*" -1994- IF SQLCODE EQUAL 000 OR SQLCODE EQUAL -811 */

                if (DB.SQLCODE == 000 || DB.SQLCODE == -811)
                {

                    /*" -1996- MOVE CBO-COD-CBO OF DCLCBO TO COD-CBO-TIT */
                    _.Move(CBO.DCLCBO.CBO_COD_CBO, COD_CBO_TIT);

                    /*" -1997- ELSE */
                }
                else
                {


                    /*" -1998- MOVE ZEROS TO COD-CBO-TIT */
                    _.Move(0, COD_CBO_TIT);

                    /*" -1999- ELSE */
                }

            }
            else
            {


                /*" -2001- MOVE ZEROS TO COD-CBO-TIT. */
                _.Move(0, COD_CBO_TIT);
            }


            /*" -2001- MOVE ZEROS TO COD-CBO-CONJ. */
            _.Move(0, COD_CBO_CONJ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0410-00-LER-CBO-SECTION */
        private void R0410_00_LER_CBO_SECTION()
        {
            /*" -2011- MOVE 'R0400-00-LER-CBO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-CBO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2012- MOVE 'SELECT CBO' TO COMANDO. */
            _.Move("SELECT CBO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2014- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2024- PERFORM R0410_00_LER_CBO_DB_SELECT_1 */

            R0410_00_LER_CBO_DB_SELECT_1();

            /*" -2029- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -811 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -811 && DB.SQLCODE != 100)
            {

                /*" -2030- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -2031- DISPLAY '          ERRO SELECT TABELA CBO' */
                _.Display($"          ERRO SELECT TABELA CBO");

                /*" -2033- DISPLAY '          NUMERO CERTIFICADO....' BILHETE-NUM-BILHETE OF DCLBILHETE */
                _.Display($"          NUMERO CERTIFICADO....{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2035- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -2036- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2036- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0410-00-LER-CBO-DB-SELECT-1 */
        public void R0410_00_LER_CBO_DB_SELECT_1()
        {
            /*" -2024- EXEC SQL SELECT COD_CBO , DESCR_CBO INTO :DCLCBO.CBO-COD-CBO , :DCLCBO.CBO-DESCR-CBO FROM SEGUROS.CBO WHERE DESCR_CBO = :DCLCBO.CBO-DESCR-CBO WITH UR END-EXEC. */

            var r0410_00_LER_CBO_DB_SELECT_1_Query1 = new R0410_00_LER_CBO_DB_SELECT_1_Query1()
            {
                CBO_DESCR_CBO = CBO.DCLCBO.CBO_DESCR_CBO.ToString(),
            };

            var executed_1 = R0410_00_LER_CBO_DB_SELECT_1_Query1.Execute(r0410_00_LER_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(executed_1.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_SAIDA*/

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-SECTION */
        private void R0450_00_LER_PRODUTOS_SIVPF_SECTION()
        {
            /*" -2046- MOVE 'R0450-00-LER-PRODUTOS-SIVPF' TO PARAGRAFO. */
            _.Move("R0450-00-LER-PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2047- MOVE 'SELECT PRODUTOS-SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2049- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2051- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -2054- IF BILHETE-RAMO OF DCLBILHETE EQUAL 82 OR BILHETE-RAMO OF DCLBILHETE EQUAL 81 OR BILHETE-RAMO OF DCLBILHETE EQUAL 37 */

            if (BILHETE.DCLBILHETE.BILHETE_RAMO == 82 || BILHETE.DCLBILHETE.BILHETE_RAMO == 81 || BILHETE.DCLBILHETE.BILHETE_RAMO == 37)
            {

                /*" -2056- MOVE 9 TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Move(9, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

                /*" -2057- ELSE */
            }
            else
            {


                /*" -2058- IF BILHETE-RAMO OF DCLBILHETE EQUAL 14 OR 72 */

                if (BILHETE.DCLBILHETE.BILHETE_RAMO.In("14", "72"))
                {

                    /*" -2060- MOVE 10 TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                    _.Move(10, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

                    /*" -2061- ELSE */
                }
                else
                {


                    /*" -2062- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2065- DISPLAY '          NUMERO BILHETE............' BILHETE-NUM-BILHETE OF DCLBILHETE PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF */

                    $"          NUMERO BILHETE............{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}"
                    .Display();

                    /*" -2067- DISPLAY '          CODIGO PRODUTO............' PRDSIVPF-COD-PRODUTO OF DCLPRODUTOS-SIVPF */
                    _.Display($"          CODIGO PRODUTO............{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}");

                    /*" -2069- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -2070- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2072- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -2074- IF ENDOSSOS-COD-PRODUTO EQUAL 3701 OR JVPRD3701 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString()))
            {

                /*" -2077- MOVE 29 TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
                _.Move(29, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
            }


            /*" -2095- PERFORM R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1 */

            R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -2098- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2099- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -2100- DISPLAY '          ERRO SELECT PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT PRODUTOS-SIVPF");

                /*" -2102- DISPLAY '          CODIGO EMPRESA............' PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO EMPRESA............{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF}");

                /*" -2104- DISPLAY '          CODIGO PRODUTO............' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO PRODUTO............{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -2106- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -2107- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2107- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0450-00-LER-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -2095- EXEC SQL SELECT DISTINCT COD_EMPRESA_SIVPF , COD_PRODUTO_SIVPF , COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_EMPRESA_SIVPF, COD_PRODUTO_SIVPF, COD_RELAC WITH UR END-EXEC. */

            var r0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 = new R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1.Execute(r0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_EMPRESA_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0500-00-LER-RCAP-SECTION */
        private void R0500_00_LER_RCAP_SECTION()
        {
            /*" -2117- MOVE 'R0500-00-LER-RCAP' TO PARAGRAFO. */
            _.Move("R0500-00-LER-RCAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2118- MOVE 'SELECT RCAP' TO COMANDO. */
            _.Move("SELECT RCAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2120- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2123- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO RCAPS-NUM-TITULO OF DCLRCAPS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

            /*" -2150- PERFORM R0500_00_LER_RCAP_DB_SELECT_1 */

            R0500_00_LER_RCAP_DB_SELECT_1();

            /*" -2154- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2155- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2181- PERFORM R0500_00_LER_RCAP_DB_SELECT_2 */

                    R0500_00_LER_RCAP_DB_SELECT_2();

                    /*" -2184- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2185- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -2186- DISPLAY 'PF0617B - -- TITULO SEM RCAPS -- ' */
                            _.Display($"PF0617B - -- TITULO SEM RCAPS -- ");

                            /*" -2188- DISPLAY '          NUMERO DO TITULO...... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                            _.Display($"          NUMERO DO TITULO...... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                            /*" -2189- ELSE */
                        }
                        else
                        {


                            /*" -2190- DISPLAY 'PF0617B - ERRO NO  ACESSO A RCAP' */
                            _.Display($"PF0617B - ERRO NO  ACESSO A RCAP");

                            /*" -2192- DISPLAY '          NUMERO   DO  TITULO... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                            _.Display($"          NUMERO   DO  TITULO... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                            /*" -2194- DISPLAY '          SQLCODE............... ' SQLCODE */
                            _.Display($"          SQLCODE............... {DB.SQLCODE}");

                            /*" -2195- DISPLAY ' ' */
                            _.Display($" ");

                            /*" -2196- PERFORM R9988-00-FECHAR-ARQUIVOS */

                            R9988_00_FECHAR_ARQUIVOS_SECTION();

                            /*" -2197- PERFORM R9999-00-FINALIZAR */

                            R9999_00_FINALIZAR_SECTION();

                            /*" -2199- ELSE NEXT SENTENCE */
                        }

                    }
                    else
                    {


                        /*" -2200- ELSE */
                    }

                }
                else
                {


                    /*" -2201- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2202- DISPLAY '          ERRO SELECT TABELA RCAP' */
                    _.Display($"          ERRO SELECT TABELA RCAP");

                    /*" -2204- DISPLAY '          NUMERO DO TITULO....... ' RCAPS-NUM-TITULO OF DCLRCAPS */
                    _.Display($"          NUMERO DO TITULO....... {RCAPS.DCLRCAPS.RCAPS_NUM_TITULO}");

                    /*" -2206- DISPLAY '          SQLCODE................ ' SQLCODE */
                    _.Display($"          SQLCODE................ {DB.SQLCODE}");

                    /*" -2207- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2207- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-LER-RCAP-DB-SELECT-1 */
        public void R0500_00_LER_RCAP_DB_SELECT_1()
        {
            /*" -2150- EXEC SQL SELECT COD_FONTE, NUM_RCAP, NUM_PROPOSTA, VAL_RCAP, VAL_RCAP_PRINCIPAL, DATA_CADASTRAMENTO, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, NUM_TITULO INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-NUM-PROPOSTA, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP-PRINCIPAL, :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO, :DCLRCAPS.RCAPS-DATA-MOVIMENTO, :DCLRCAPS.RCAPS-SIT-REGISTRO, :DCLRCAPS.RCAPS-COD-OPERACAO, :DCLRCAPS.RCAPS-NUM-TITULO FROM SEGUROS.RCAPS WHERE NUM_TITULO = :DCLRCAPS.RCAPS-NUM-TITULO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0500_00_LER_RCAP_DB_SELECT_1_Query1 = new R0500_00_LER_RCAP_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R0500_00_LER_RCAP_DB_SELECT_1_Query1.Execute(r0500_00_LER_RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0500-00-LER-RCAP-DB-SELECT-2 */
        public void R0500_00_LER_RCAP_DB_SELECT_2()
        {
            /*" -2181- EXEC SQL SELECT COD_FONTE, NUM_RCAP, NUM_PROPOSTA, VAL_RCAP, VAL_RCAP_PRINCIPAL, DATA_CADASTRAMENTO, DATA_MOVIMENTO, SIT_REGISTRO, COD_OPERACAO, NUM_TITULO INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-NUM-PROPOSTA, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP-PRINCIPAL, :DCLRCAPS.RCAPS-DATA-CADASTRAMENTO, :DCLRCAPS.RCAPS-DATA-MOVIMENTO, :DCLRCAPS.RCAPS-SIT-REGISTRO, :DCLRCAPS.RCAPS-COD-OPERACAO, :DCLRCAPS.RCAPS-NUM-TITULO FROM SEGUROS.RCAPS WHERE NUM_TITULO = :DCLRCAPS.RCAPS-NUM-TITULO WITH UR END-EXEC */

            var r0500_00_LER_RCAP_DB_SELECT_2_Query1 = new R0500_00_LER_RCAP_DB_SELECT_2_Query1()
            {
                RCAPS_NUM_TITULO = RCAPS.DCLRCAPS.RCAPS_NUM_TITULO.ToString(),
            };

            var executed_1 = R0500_00_LER_RCAP_DB_SELECT_2_Query1.Execute(r0500_00_LER_RCAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R0570-00-OBTER-COMISSAO-SECTION */
        private void R0570_00_OBTER_COMISSAO_SECTION()
        {
            /*" -2217- MOVE 'R0570-00-OBTER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-OBTER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2218- MOVE 'SELECT COMISICOBVA' TO COMANDO. */
            _.Move("SELECT COMISICOBVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2220- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2222- PERFORM R0573-00-LER-PARCELA. */

            R0573_00_LER_PARCELA_SECTION();

            /*" -2224- PERFORM R0575-00-CURSOR-APOLCORRET. */

            R0575_00_CURSOR_APOLCORRET_SECTION();

            /*" -2226- MOVE SPACES TO W-FIM-V0APOLCORRET. */
            _.Move("", WAREA_AUXILIAR.W_FIM_V0APOLCORRET);

            /*" -2228- PERFORM R0577-00-LER-APOLCORRET. */

            R0577_00_LER_APOLCORRET_SECTION();

            /*" -2231- MOVE ZEROS TO W-PRM-COMISSAO, W-TOT-COMISSAO. */
            _.Move(0, WAREA_AUXILIAR.W_PRM_COMISSAO, WAREA_AUXILIAR.W_TOT_COMISSAO);

            /*" -2232- PERFORM R0579-00-CALCULA-COMISSAO UNTIL W-FIM-V0APOLCORRET EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_V0APOLCORRET == "FIM"))
            {

                R0579_00_CALCULA_COMISSAO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0573-00-LER-PARCELA-SECTION */
        private void R0573_00_LER_PARCELA_SECTION()
        {
            /*" -2242- MOVE 'R0573-00-LER-PARCELA' TO PARAGRAFO. */
            _.Move("R0573-00-LER-PARCELA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2243- MOVE 'SELECT PARCELAS' TO COMANDO. */
            _.Move("SELECT PARCELAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2245- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2246- MOVE BILHETE-NUM-APOLICE TO PARCELAS-NUM-APOLICE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

            /*" -2248- MOVE 1 TO PARCELAS-NUM-PARCELA. */
            _.Move(1, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);

            /*" -2255- PERFORM R0573_00_LER_PARCELA_DB_SELECT_1 */

            R0573_00_LER_PARCELA_DB_SELECT_1();

            /*" -2259- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -2260- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -2261- DISPLAY '          ERRO SELECT TAB. PARCELAS' */
                _.Display($"          ERRO SELECT TAB. PARCELAS");

                /*" -2263- DISPLAY '          NUMERO APOLICE............ ' PARCELAS-NUM-APOLICE */
                _.Display($"          NUMERO APOLICE............ {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2265- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -2266- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2268- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2269- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2270- MOVE BILHETE-NUM-APOLICE TO PARCELAS-NUM-APOLICE */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);

                /*" -2272- MOVE ZEROS TO PARCELAS-NUM-ENDOSSO */
                _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);

                /*" -2279- PERFORM R0573_00_LER_PARCELA_DB_DECLARE_1 */

                R0573_00_LER_PARCELA_DB_DECLARE_1();

                /*" -2281- PERFORM R0573_00_LER_PARCELA_DB_OPEN_1 */

                R0573_00_LER_PARCELA_DB_OPEN_1();

                /*" -2283- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -2284- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2285- DISPLAY '          ERRO OPEN  CURSOR  PARCELS ' */
                    _.Display($"          ERRO OPEN  CURSOR  PARCELS ");

                    /*" -2286- DISPLAY '          APOLICE  = ' PARCELAS-NUM-APOLICE */
                    _.Display($"          APOLICE  = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                    /*" -2287- DISPLAY '          SQLCODE  = ' SQLCODE */
                    _.Display($"          SQLCODE  = {DB.SQLCODE}");

                    /*" -2288- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2289- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2290- ELSE */
                }
                else
                {


                    /*" -2291- PERFORM R0574-00-FETCH-PARCELS */

                    R0574_00_FETCH_PARCELS_SECTION();

                    /*" -2291- PERFORM R0573_00_LER_PARCELA_DB_CLOSE_1 */

                    R0573_00_LER_PARCELA_DB_CLOSE_1();

                    /*" -2293- END-IF */
                }


                /*" -2293- END-IF. */
            }


        }

        [StopWatch]
        /*" R0573-00-LER-PARCELA-DB-SELECT-1 */
        public void R0573_00_LER_PARCELA_DB_SELECT_1()
        {
            /*" -2255- EXEC SQL SELECT A.PRM_TARIFARIO_IX INTO :PARCELAS-PRM-TARIFARIO-IX FROM SEGUROS.PARCELAS A WHERE A.NUM_APOLICE = :PARCELAS-NUM-APOLICE AND A.NUM_PARCELA = :PARCELAS-NUM-PARCELA WITH UR END-EXEC. */

            var r0573_00_LER_PARCELA_DB_SELECT_1_Query1 = new R0573_00_LER_PARCELA_DB_SELECT_1_Query1()
            {
                PARCELAS_NUM_APOLICE = PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE.ToString(),
                PARCELAS_NUM_PARCELA = PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0573_00_LER_PARCELA_DB_SELECT_1_Query1.Execute(r0573_00_LER_PARCELA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);
            }


        }

        [StopWatch]
        /*" R0573-00-LER-PARCELA-DB-OPEN-1 */
        public void R0573_00_LER_PARCELA_DB_OPEN_1()
        {
            /*" -2281- EXEC SQL OPEN PARCELS END-EXEC */

            PARCELS.Open();

        }

        [StopWatch]
        /*" R0575-00-CURSOR-APOLCORRET-DB-DECLARE-1 */
        public void R0575_00_CURSOR_APOLCORRET_DB_DECLARE_1()
        {
            /*" -2346- EXEC SQL DECLARE V0APOLCORRET CURSOR FOR SELECT COD_CORRETOR, PCT_PART_CORRETOR, PCT_COM_CORRETOR FROM SEGUROS.APOLICE_CORRETOR WHERE NUM_APOLICE = :APOLICOR-NUM-APOLICE WITH UR END-EXEC. */
            V0APOLCORRET = new PF0617B_V0APOLCORRET(true);
            string GetQuery_V0APOLCORRET()
            {
                var query = @$"SELECT COD_CORRETOR
							, 
							PCT_PART_CORRETOR
							, 
							PCT_COM_CORRETOR 
							FROM SEGUROS.APOLICE_CORRETOR 
							WHERE NUM_APOLICE = '{APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE}'";

                return query;
            }
            V0APOLCORRET.GetQueryEvent += GetQuery_V0APOLCORRET;

        }

        [StopWatch]
        /*" R0573-00-LER-PARCELA-DB-CLOSE-1 */
        public void R0573_00_LER_PARCELA_DB_CLOSE_1()
        {
            /*" -2291- EXEC SQL CLOSE PARCELS END-EXEC */

            PARCELS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0573_SAIDA*/

        [StopWatch]
        /*" R0574-00-FETCH-PARCELS-SECTION */
        private void R0574_00_FETCH_PARCELS_SECTION()
        {
            /*" -2300- MOVE 'R0574-00-FETCH-PARCELS' TO PARAGRAFO. */
            _.Move("R0574-00-FETCH-PARCELS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2301- MOVE 'FETCH  PARCELS' TO COMANDO. */
            _.Move("FETCH  PARCELS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2303- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2306- PERFORM R0574_00_FETCH_PARCELS_DB_FETCH_1 */

            R0574_00_FETCH_PARCELS_DB_FETCH_1();

            /*" -2311- IF SQLCODE EQUAL ZEROS OR SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 00 || DB.SQLCODE == 100)
            {

                /*" -2312- ELSE */
            }
            else
            {


                /*" -2313- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -2314- DISPLAY '          ERRO FETCH CURSOR  PARCELS ' */
                _.Display($"          ERRO FETCH CURSOR  PARCELS ");

                /*" -2315- DISPLAY '          APOLICE  = ' PARCELAS-NUM-APOLICE */
                _.Display($"          APOLICE  = {PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE}");

                /*" -2316- DISPLAY '          SQLCODE  = ' SQLCODE */
                _.Display($"          SQLCODE  = {DB.SQLCODE}");

                /*" -2317- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2318- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2319- END-IF. */
            }


        }

        [StopWatch]
        /*" R0574-00-FETCH-PARCELS-DB-FETCH-1 */
        public void R0574_00_FETCH_PARCELS_DB_FETCH_1()
        {
            /*" -2306- EXEC SQL FETCH PARCELS INTO :PARCELAS-PRM-TARIFARIO-IX END-EXEC. */

            if (PARCELS.Fetch())
            {
                _.Move(PARCELS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0574_SAIDA*/

        [StopWatch]
        /*" R0575-00-CURSOR-APOLCORRET-SECTION */
        private void R0575_00_CURSOR_APOLCORRET_SECTION()
        {
            /*" -2328- MOVE 'R0575-00-CURSOR-APOLCORRET' TO PARAGRAFO. */
            _.Move("R0575-00-CURSOR-APOLCORRET", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2329- MOVE 'SELECT V0APOLCORRET' TO COMANDO. */
            _.Move("SELECT V0APOLCORRET", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2331- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2334- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO APOLICOR-NUM-APOLICE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_NUM_APOLICE);

            /*" -2337- MOVE BILHETE-RAMO OF DCLBILHETE TO APOLICOR-RAMO-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_RAMO_COBERTURA);

            /*" -2346- PERFORM R0575_00_CURSOR_APOLCORRET_DB_DECLARE_1 */

            R0575_00_CURSOR_APOLCORRET_DB_DECLARE_1();

            /*" -2348- PERFORM R0575_00_CURSOR_APOLCORRET_DB_OPEN_1 */

            R0575_00_CURSOR_APOLCORRET_DB_OPEN_1();

            /*" -2351- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2352- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -2353- DISPLAY '          ERRO OPEN CURSOR V0APOLCORRET' */
                _.Display($"          ERRO OPEN CURSOR V0APOLCORRET");

                /*" -2357- DISPLAY '          BILHETE/APOLICE/RAMO.....> ' BILHETE-NUM-BILHETE OF DCLBILHETE '  ' BILHETE-NUM-APOLICE OF DCLBILHETE '  ' BILHETE-RAMO OF DCLBILHETE */

                $"          BILHETE/APOLICE/RAMO.....> {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}  {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}  {BILHETE.DCLBILHETE.BILHETE_RAMO}"
                .Display();

                /*" -2359- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -2360- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2360- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0575-00-CURSOR-APOLCORRET-DB-OPEN-1 */
        public void R0575_00_CURSOR_APOLCORRET_DB_OPEN_1()
        {
            /*" -2348- EXEC SQL OPEN V0APOLCORRET END-EXEC. */

            V0APOLCORRET.Open();

        }

        [StopWatch]
        /*" R0800-00-RELACIONAR-BENEFICIA-DB-DECLARE-1 */
        public void R0800_00_RELACIONAR_BENEFICIA_DB_DECLARE_1()
        {
            /*" -3182- EXEC SQL DECLARE BENEFICIARIOS CURSOR FOR SELECT NUM_APOLICE , COD_SUBGRUPO , NUM_CERTIFICADO , DAC_CERTIFICADO , NUM_BENEFICIARIO , NOME_BENEFICIARIO , GRAU_PARENTESCO , PCT_PART_BENEFICIA , DATA_INIVIGENCIA , DATA_TERVIGENCIA FROM SEGUROS.BENEFICIARIOS WHERE NUM_CERTIFICADO = :DCLBENEFICIARIOS.BENEFICI-NUM-CERTIFICADO WITH UR END-EXEC. */
            BENEFICIARIOS = new PF0617B_BENEFICIARIOS(true);
            string GetQuery_BENEFICIARIOS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							NUM_BENEFICIARIO
							, 
							NOME_BENEFICIARIO
							, 
							GRAU_PARENTESCO
							, 
							PCT_PART_BENEFICIA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA 
							FROM SEGUROS.BENEFICIARIOS 
							WHERE NUM_CERTIFICADO = 
							'{BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO}'";

                return query;
            }
            BENEFICIARIOS.GetQueryEvent += GetQuery_BENEFICIARIOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0575_SAIDA*/

        [StopWatch]
        /*" R0577-00-LER-APOLCORRET-SECTION */
        private void R0577_00_LER_APOLCORRET_SECTION()
        {
            /*" -2367- MOVE 'R0577-00-LER-APOLCORRET' TO PARAGRAFO. */
            _.Move("R0577-00-LER-APOLCORRET", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2368- MOVE 'SELECT CURSOR V0APOLCORRET' TO COMANDO. */
            _.Move("SELECT CURSOR V0APOLCORRET", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2370- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2375- PERFORM R0577_00_LER_APOLCORRET_DB_FETCH_1 */

            R0577_00_LER_APOLCORRET_DB_FETCH_1();

            /*" -2378- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2379- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2380- MOVE 'FIM' TO W-FIM-V0APOLCORRET */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_V0APOLCORRET);

                    /*" -2380- PERFORM R0577_00_LER_APOLCORRET_DB_CLOSE_1 */

                    R0577_00_LER_APOLCORRET_DB_CLOSE_1();

                    /*" -2382- ELSE */
                }
                else
                {


                    /*" -2383- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2385- DISPLAY '          ERRO FETCH V0APOLCORRET ' SQLCODE */
                    _.Display($"          ERRO FETCH V0APOLCORRET {DB.SQLCODE}");

                    /*" -2389- DISPLAY '          BILHETE/APOLICE/RAMO.....> ' BILHETE-NUM-BILHETE OF DCLBILHETE '  ' BILHETE-NUM-APOLICE OF DCLBILHETE '  ' BILHETE-RAMO OF DCLBILHETE */

                    $"          BILHETE/APOLICE/RAMO.....> {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}  {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}  {BILHETE.DCLBILHETE.BILHETE_RAMO}"
                    .Display();

                    /*" -2390- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2390- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0577-00-LER-APOLCORRET-DB-FETCH-1 */
        public void R0577_00_LER_APOLCORRET_DB_FETCH_1()
        {
            /*" -2375- EXEC SQL FETCH V0APOLCORRET INTO :APOLICOR-COD-CORRETOR ,:APOLICOR-PCT-PART-CORRETOR ,:APOLICOR-PCT-COM-CORRETOR END-EXEC. */

            if (V0APOLCORRET.Fetch())
            {
                _.Move(V0APOLCORRET.APOLICOR_COD_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_COD_CORRETOR);
                _.Move(V0APOLCORRET.APOLICOR_PCT_PART_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);
                _.Move(V0APOLCORRET.APOLICOR_PCT_COM_CORRETOR, APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);
            }

        }

        [StopWatch]
        /*" R0577-00-LER-APOLCORRET-DB-CLOSE-1 */
        public void R0577_00_LER_APOLCORRET_DB_CLOSE_1()
        {
            /*" -2380- EXEC SQL CLOSE V0APOLCORRET END-EXEC */

            V0APOLCORRET.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0577_SAIDA*/

        [StopWatch]
        /*" R0579-00-CALCULA-COMISSAO-SECTION */
        private void R0579_00_CALCULA_COMISSAO_SECTION()
        {
            /*" -2406- MOVE 'R0579-00-CALCULA-COMISSAO' TO PARAGRAFO. */
            _.Move("R0579-00-CALCULA-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2407- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2409- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2414- COMPUTE W-PRM-COMISSAO ROUNDED = ( PARCELAS-PRM-TARIFARIO-IX * APOLICOR-PCT-PART-CORRETOR ) */
            WAREA_AUXILIAR.W_PRM_COMISSAO.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_PART_CORRETOR);

            /*" -2418- COMPUTE W-VAL-COMISSAO ROUNDED = (W-PRM-COMISSAO * APOLICOR-PCT-COM-CORRETOR ) */
            WAREA_AUXILIAR.W_VAL_COMISSAO.Value = (WAREA_AUXILIAR.W_PRM_COMISSAO * APOLICOR.DCLAPOLICE_CORRETOR.APOLICOR_PCT_COM_CORRETOR);

            /*" -2421- ADD W-VAL-COMISSAO TO W-TOT-COMISSAO. */
            WAREA_AUXILIAR.W_TOT_COMISSAO.Value = WAREA_AUXILIAR.W_TOT_COMISSAO + WAREA_AUXILIAR.W_VAL_COMISSAO;

            /*" -2421- PERFORM R0577-00-LER-APOLCORRET. */

            R0577_00_LER_APOLCORRET_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0579_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -2431- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2432- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2434- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2437- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -2449- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -2452- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2453- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2454- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -2455- ELSE */
                }
                else
                {


                    /*" -2456- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2457- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -2459- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -2461- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -2462- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2462- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -2449- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 = new R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1.Execute(r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VAL_TARIFA, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0590-00-LER-CONVERSAO-SICOB-SECTION */
        private void R0590_00_LER_CONVERSAO_SICOB_SECTION()
        {
            /*" -2472- MOVE 'R0590-LER-CONVERSAO-SICOB' TO PARAGRAFO. */
            _.Move("R0590-LER-CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2473- MOVE 'SELECT CONVERSAO-SICOB' TO COMANDO. */
            _.Move("SELECT CONVERSAO-SICOB", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2475- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2479- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO NUM-SICOB OF DCLCONVERSAO-SICOB W-NUM-PROPOSTA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB, WAREA_AUXILIAR.W_NUM_PROPOSTA);

            /*" -2481- MOVE 2 TO W-CONVERSAO. */
            _.Move(2, WAREA_AUXILIAR.W_CONVERSAO);

            /*" -2490- PERFORM R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1 */

            R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1();

            /*" -2493- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2494- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -2495- DISPLAY 'PF0617B FIM ANORMAL' */
                    _.Display($"PF0617B FIM ANORMAL");

                    /*" -2496- DISPLAY '        ERRO SELECT TAB. CONVERSAO-SICOB' */
                    _.Display($"        ERRO SELECT TAB. CONVERSAO-SICOB");

                    /*" -2498- DISPLAY '        NUM SICOB........... ' NUM-SICOB OF DCLCONVERSAO-SICOB */
                    _.Display($"        NUM SICOB........... {COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB}");

                    /*" -2499- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2501- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -2502- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2503- MOVE 1 TO W-CONVERSAO */
                _.Move(1, WAREA_AUXILIAR.W_CONVERSAO);

                /*" -2504- MOVE NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB TO W-NUM-PROPOSTA. */
                _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, WAREA_AUXILIAR.W_NUM_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R0590-00-LER-CONVERSAO-SICOB-DB-SELECT-1 */
        public void R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1()
        {
            /*" -2490- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, NUM_SICOB INTO :DCLCONVERSAO-SICOB.NUM-PROPOSTA-SIVPF, :DCLCONVERSAO-SICOB.NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_SICOB = :DCLCONVERSAO-SICOB.NUM-SICOB WITH UR END-EXEC. */

            var r0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1_Query1 = new R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1_Query1()
            {
                NUM_SICOB = COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB.ToString(),
            };

            var executed_1 = R0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1_Query1.Execute(r0590_00_LER_CONVERSAO_SICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_PROPOSTA_SIVPF, COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.NUM_SICOB, COVSICOB.DCLCONVERSAO_SICOB.NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0590_SAIDA*/

        [StopWatch]
        /*" R0595-00-LER-PROP-FIDELIZ-SECTION */
        private void R0595_00_LER_PROP_FIDELIZ_SECTION()
        {
            /*" -2514- MOVE 'R0595-00-LER-PROP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0595-00-LER-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2515- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2517- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2518- MOVE ZEROS TO N88-ACHOU-ORIGEM-34 */
            _.Move(0, WAREA_AUXILIAR.N88_ACHOU_ORIGEM_34);

            /*" -2521- MOVE NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -2539- PERFORM R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1 */

            R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1();

            /*" -2542- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2543- MOVE 'SIM' TO W-EXISTE-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                /*" -2544- ELSE */
            }
            else
            {


                /*" -2545- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2546- MOVE 'NAO' TO W-EXISTE-FIDELIZ */
                    _.Move("NAO", WAREA_AUXILIAR.W_EXISTE_FIDELIZ);

                    /*" -2547- ELSE */
                }
                else
                {


                    /*" -2548- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2549- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -2551- DISPLAY '          NUMERO DO PROPOSTA......... ' NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB */
                    _.Display($"          NUMERO DO PROPOSTA......... {COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}");

                    /*" -2553- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -2554- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2554- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0595-00-LER-PROP-FIDELIZ-DB-SELECT-1 */
        public void R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1()
        {
            /*" -2539- EXEC SQL SELECT SIT_PROPOSTA , CANAL_PROPOSTA , ORIGEM_PROPOSTA , COD_PRODUTO_SIVPF , NUM_IDENTIFICACAO , NUM_SICOB INTO :PROPOFID-SIT-PROPOSTA , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-NUM-SICOB FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1 = new R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0595_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0595_SAIDA*/

        [StopWatch]
        /*" R0596-00-UPDATE-PROPOFID-SECTION */
        private void R0596_00_UPDATE_PROPOFID_SECTION()
        {
            /*" -2565- MOVE '0596' TO PARAGRAFO. */
            _.Move("0596", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2571- PERFORM R0596_00_UPDATE_PROPOFID_DB_UPDATE_1 */

            R0596_00_UPDATE_PROPOFID_DB_UPDATE_1();

            /*" -2574- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2575- DISPLAY 'R0596-00 (ERRO UPDATE PROPOFID ' */
                _.Display($"R0596-00 (ERRO UPDATE PROPOFID ");

                /*" -2576- DISPLAY 'NUMBIL            = ' BILHETE-NUM-BILHETE */
                _.Display($"NUMBIL            = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2577- DISPLAY 'BILHETE RENOVACAO = ' NUM-APOL-ANT */
                _.Display($"BILHETE RENOVACAO = {NUM_APOL_ANT}");

                /*" -2578- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2579- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2579- END-IF. */
            }


        }

        [StopWatch]
        /*" R0596-00-UPDATE-PROPOFID-DB-UPDATE-1 */
        public void R0596_00_UPDATE_PROPOFID_DB_UPDATE_1()
        {
            /*" -2571- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'S' , COD_USUARIO = 'PF0617B' , SIT_PROPOSTA = :PROPOFID-SIT-PROPOSTA WHERE NUM_SICOB = :NUM-APOL-ANT END-EXEC. */

            var r0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1 = new R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1()
            {
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                NUM_APOL_ANT = NUM_APOL_ANT.ToString(),
            };

            R0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1.Execute(r0596_00_UPDATE_PROPOFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0596_99_SAIDA*/

        [StopWatch]
        /*" R0598-00-SELECT-QUANT-BIL-RENO-SECTION */
        private void R0598_00_SELECT_QUANT_BIL_RENO_SECTION()
        {
            /*" -2589- MOVE 'R0598' TO PARAGRAFO. */
            _.Move("R0598", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2591- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2597- PERFORM R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1 */

            R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1();

            /*" -2601- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2602- DISPLAY 'R0599 - PROBLEMA SELECT BILHETE  ' */
                _.Display($"R0599 - PROBLEMA SELECT BILHETE  ");

                /*" -2603- DISPLAY 'NUMBIL            = ' BILHETE-NUM-BILHETE */
                _.Display($"NUMBIL            = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2604- DISPLAY 'BILHETE RENOVACAO = ' NUM-APOL-ANT */
                _.Display($"BILHETE RENOVACAO = {NUM_APOL_ANT}");

                /*" -2605- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2606- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2607- ELSE */
            }
            else
            {


                /*" -2608- IF BILHETE-NUM-APOL-ANTERIOR NOT EQUAL ZEROS */

                if (BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR != 00)
                {

                    /*" -2609- MOVE BILHETE-NUM-APOL-ANTERIOR TO NUM-APOL-ANT */
                    _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR, NUM_APOL_ANT);

                    /*" -2610- GO TO R0598-00-SELECT-QUANT-BIL-RENO */
                    new Task(() => R0598_00_SELECT_QUANT_BIL_RENO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2611- END-IF */
                }


                /*" -2612- END-IF */
            }


            /*" -2612- . */

        }

        [StopWatch]
        /*" R0598-00-SELECT-QUANT-BIL-RENO-DB-SELECT-1 */
        public void R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1()
        {
            /*" -2597- EXEC SQL SELECT NUM_APOL_ANTERIOR INTO :BILHETE-NUM-APOL-ANTERIOR FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :NUM-APOL-ANT WITH UR END-EXEC. */

            var r0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1 = new R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1()
            {
                NUM_APOL_ANT = NUM_APOL_ANT.ToString(),
            };

            var executed_1 = R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1.Execute(r0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0598_99_SAIDA*/

        [StopWatch]
        /*" R0599-00-SELECT-PROPOFID-SECTION */
        private void R0599_00_SELECT_PROPOFID_SECTION()
        {
            /*" -2622- MOVE '0599' TO PARAGRAFO. */
            _.Move("0599", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2624- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2631- PERFORM R0599_00_SELECT_PROPOFID_DB_SELECT_1 */

            R0599_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -2634- IF SQLCODE EQUAL ZEROS OR 100 */

            if (DB.SQLCODE.In("00", "100"))
            {

                /*" -2635- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2637- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

                    /*" -2639- DISPLAY 'PROP FIDELIZ NOTFND: ' NUM-APOL-ANT '/' BILHETE-NUM-BILHETE */

                    $"PROP FIDELIZ NOTFND: {NUM_APOL_ANT}/{BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}"
                    .Display();

                    /*" -2640- ELSE */
                }
                else
                {


                    /*" -2641- IF PROPOFID-SIT-PROPOSTA NOT EQUAL 'EMT' */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA != "EMT")
                    {

                        /*" -2642- MOVE 'EMT' TO PROPOFID-SIT-PROPOSTA */
                        _.Move("EMT", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

                        /*" -2643- END-IF */
                    }


                    /*" -2644- MOVE 'SIM' TO W-TEM-RENOVACAO */
                    _.Move("SIM", W_TEM_RENOVACAO);

                    /*" -2645- PERFORM R0596-00-UPDATE-PROPOFID */

                    R0596_00_UPDATE_PROPOFID_SECTION();

                    /*" -2646- END-IF */
                }


                /*" -2647- ELSE */
            }
            else
            {


                /*" -2648- DISPLAY 'R0599-00 (ERRO SELECT PROPOFID ' */
                _.Display($"R0599-00 (ERRO SELECT PROPOFID ");

                /*" -2649- DISPLAY 'NUMBIL            = ' BILHETE-NUM-BILHETE */
                _.Display($"NUMBIL            = {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -2650- DISPLAY 'BILHETE RENOVACAO = ' NUM-APOL-ANT */
                _.Display($"BILHETE RENOVACAO = {NUM_APOL_ANT}");

                /*" -2651- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2652- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -2652- END-IF. */
            }


        }

        [StopWatch]
        /*" R0599-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R0599_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -2631- EXEC SQL SELECT NUM_PROPOSTA_SIVPF, SIT_PROPOSTA INTO :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-SIT-PROPOSTA FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :NUM-APOL-ANT END-EXEC. */

            var r0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                NUM_APOL_ANT = NUM_APOL_ANT.ToString(),
            };

            var executed_1 = R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0599_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0600_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -2663- MOVE 'R0600-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2665- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2668- MOVE SPACES TO REG-CLIENTES, REG-PRP-BILHETE */
            _.Move("", LBFPF011.REG_CLIENTES, REG_PRP_BILHETE);

            /*" -2672- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES. */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -2678- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-CLIENTES */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -2681- MOVE CGCCPF OF DCLCLIENTES TO R1-CGC-CPF OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -2682- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -2684- MOVE ZEROS TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
                _.Move(0, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

                /*" -2685- ELSE */
            }
            else
            {


                /*" -2688- MOVE DATA-NASCIMENTO OF DCLCLIENTES TO W-DATA-SQL */
                _.Move(CLIENTE.DCLCLIENTES.DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2689- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO);

                /*" -2690- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO);

                /*" -2691- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO);

                /*" -2694- MOVE W-DATA-TRABALHO TO R1-DATA-NASCIMENTO OF REG-CLIENTES. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);
            }


            /*" -2697- MOVE NOME-RAZAO OF DCLCLIENTES TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -2698- IF TIPO-PESSOA OF DCLCLIENTES EQUAL 'F' */

            if (CLIENTE.DCLCLIENTES.TIPO_PESSOA == "F")
            {

                /*" -2699- MOVE 1 TO R1-TIPO-PESSOA OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

                /*" -2700- ELSE */
            }
            else
            {


                /*" -2702- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);
            }


            /*" -2707- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES R1-CODIGO-SEGMENTO OF REG-CLIENTES R1-ORGAO-EXPEDIDOR OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, LBFPF011.REG_CLIENTES.R1_CODIGO_SEGMENTO, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

            /*" -2711- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES R1-DATA-EXPEDICAO-RG OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

            /*" -2713- MOVE ZERO TO W-OBTER-DADOS-RG. */
            _.Move(0, WAREA_AUXILIAR.W_OBTER_DADOS_RG);

            /*" -2715- PERFORM R0620-00-DADOS-RG. */

            R0620_00_DADOS_RG_SECTION();

            /*" -2716- IF OBTEVE-DADOS-RG */

            if (WAREA_AUXILIAR.W_OBTER_DADOS_RG["OBTEVE_DADOS_RG"])
            {

                /*" -2719- MOVE GEDOCCLI-COD-IDENTIFICACAO TO R1-NUM-IDENTIDADE OF REG-CLIENTES */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

                /*" -2722- MOVE GEDOCCLI-NOM-ORGAO-EXP TO W-NOM-ORGAO-EXP */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP, WAREA_AUXILIAR.W_NOM_ORGAO_EXP);

                /*" -2725- MOVE W-ORGAO-EXPEDIDOR TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.FILLER_11.W_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR);

                /*" -2727- MOVE GEDOCCLI-DTH-EXPEDICAO TO W-DATA-SQL */
                _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -2728- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO);

                /*" -2729- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO);

                /*" -2730- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO);

                /*" -2733- MOVE W-DATA-TRABALHO TO R1-DATA-EXPEDICAO-RG OF REG-CLIENTES */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG);

                /*" -2734- IF VIND-COD-UF LESS ZEROS */

                if (VIND_COD_UF < 00)
                {

                    /*" -2736- MOVE SPACES TO R1-UF-EXPEDIDORA OF REG-CLIENTES */
                    _.Move("", LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

                    /*" -2737- ELSE */
                }
                else
                {


                    /*" -2740- MOVE GEDOCCLI-COD-UF TO R1-UF-EXPEDIDORA OF REG-CLIENTES. */
                    _.Move(GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);
                }

            }


            /*" -2741- IF BILHETE-ESTADO-CIVIL OF DCLBILHETE EQUAL 'S' */

            if (BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL == "S")
            {

                /*" -2742- MOVE 1 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                /*" -2743- ELSE */
            }
            else
            {


                /*" -2744- IF BILHETE-ESTADO-CIVIL OF DCLBILHETE EQUAL 'C' */

                if (BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL == "C")
                {

                    /*" -2745- MOVE 2 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                    _.Move(2, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                    /*" -2746- ELSE */
                }
                else
                {


                    /*" -2747- IF BILHETE-ESTADO-CIVIL OF DCLBILHETE EQUAL 'V' */

                    if (BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL == "V")
                    {

                        /*" -2748- MOVE 3 TO R1-ESTADO-CIVIL OF REG-CLIENTES */
                        _.Move(3, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);

                        /*" -2749- ELSE */
                    }
                    else
                    {


                        /*" -2751- MOVE 4 TO R1-ESTADO-CIVIL OF REG-CLIENTES. */
                        _.Move(4, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL);
                    }

                }

            }


            /*" -2752- IF BILHETE-IDE-SEXO OF DCLBILHETE EQUAL 'M' */

            if (BILHETE.DCLBILHETE.BILHETE_IDE_SEXO == "M")
            {

                /*" -2753- MOVE 1 TO R1-IDE-SEXO OF REG-CLIENTES */
                _.Move(1, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);

                /*" -2754- ELSE */
            }
            else
            {


                /*" -2756- MOVE 2 TO R1-IDE-SEXO OF REG-CLIENTES. */
                _.Move(2, LBFPF011.REG_CLIENTES.R1_IDE_SEXO);
            }


            /*" -2758- PERFORM R0400-00-LER-PROFISSAO. */

            R0400_00_LER_PROFISSAO_SECTION();

            /*" -2761- MOVE COD-CBO-TIT TO R1-COD-CBO OF REG-CLIENTES. */
            _.Move(COD_CBO_TIT, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -2764- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

            /*" -2767- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(1). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

            /*" -2771- MOVE ZEROS TO R1-DDD(2) R1-DDD(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);

            /*" -2775- MOVE ZEROS TO R1-NUM-FONE(2) R1-NUM-FONE(3). */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

            /*" -2778- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
            _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

            /*" -2780- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

            /*" -2783- MOVE -1 TO VIND-DTNASC-ESPOSA */
            _.Move(-1, VIND_DTNASC_ESPOSA);

            /*" -2786- MOVE COD-CBO-CONJ TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(COD_CBO_CONJ, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -2789- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -2791- WRITE REG-PRP-BILHETE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

            /*" -2791- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0620-00-DADOS-RG-SECTION */
        private void R0620_00_DADOS_RG_SECTION()
        {
            /*" -2801- MOVE 'R0620-00-DADOS-RG' TO PARAGRAFO. */
            _.Move("R0620-00-DADOS-RG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2802- MOVE 'SELECT GE_DOC_CLIENTE' TO COMANDO. */
            _.Move("SELECT GE_DOC_CLIENTE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2804- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2807- MOVE COD-CLIENTE OF DCLCLIENTES TO GEDOCCLI-COD-CLIENTE. */
            _.Move(CLIENTE.DCLCLIENTES.COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);

            /*" -2823- PERFORM R0620_00_DADOS_RG_DB_SELECT_1 */

            R0620_00_DADOS_RG_DB_SELECT_1();

            /*" -2826- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2828- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -2829- ELSE */
                }
                else
                {


                    /*" -2830- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2831- DISPLAY '          ERRO SELECT TAB. GE_DOC_CLIENTE' */
                    _.Display($"          ERRO SELECT TAB. GE_DOC_CLIENTE");

                    /*" -2833- DISPLAY '          NUMERO BILHETE.................. ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO BILHETE.................. {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -2835- DISPLAY '          CODIGO DO CLIENTE............... ' GEDOCCLI-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE............... {GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE}");

                    /*" -2837- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -2838- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2839- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2840- ELSE */
                }

            }
            else
            {


                /*" -2840- MOVE 1 TO W-OBTER-DADOS-RG. */
                _.Move(1, WAREA_AUXILIAR.W_OBTER_DADOS_RG);
            }


        }

        [StopWatch]
        /*" R0620-00-DADOS-RG-DB-SELECT-1 */
        public void R0620_00_DADOS_RG_DB_SELECT_1()
        {
            /*" -2823- EXEC SQL SELECT COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF INTO :GEDOCCLI-COD-CLIENTE , :GEDOCCLI-COD-IDENTIFICACAO , :GEDOCCLI-NOM-ORGAO-EXP , :GEDOCCLI-DTH-EXPEDICAO , :GEDOCCLI-COD-UF:VIND-COD-UF FROM SEGUROS.GE_DOC_CLIENTE WHERE COD_CLIENTE = :GEDOCCLI-COD-CLIENTE WITH UR END-EXEC. */

            var r0620_00_DADOS_RG_DB_SELECT_1_Query1 = new R0620_00_DADOS_RG_DB_SELECT_1_Query1()
            {
                GEDOCCLI_COD_CLIENTE = GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0620_00_DADOS_RG_DB_SELECT_1_Query1.Execute(r0620_00_DADOS_RG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEDOCCLI_COD_CLIENTE, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_CLIENTE);
                _.Move(executed_1.GEDOCCLI_COD_IDENTIFICACAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_IDENTIFICACAO);
                _.Move(executed_1.GEDOCCLI_NOM_ORGAO_EXP, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_NOM_ORGAO_EXP);
                _.Move(executed_1.GEDOCCLI_DTH_EXPEDICAO, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_DTH_EXPEDICAO);
                _.Move(executed_1.GEDOCCLI_COD_UF, GEDOCCLI.DCLGE_DOC_CLIENTE.GEDOCCLI_COD_UF);
                _.Move(executed_1.VIND_COD_UF, VIND_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_SAIDA*/

        [StopWatch]
        /*" R0650-00-GERAR-REGISTRO-TP2-SECTION */
        private void R0650_00_GERAR_REGISTRO_TP2_SECTION()
        {
            /*" -2850- MOVE 'R0650-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2852- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2855- MOVE SPACES TO REG-ENDERECO, REG-PRP-BILHETE */
            _.Move("", LBFPF012.REG_ENDERECO, REG_PRP_BILHETE);

            /*" -2859- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -2862- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R2-NUM-PROPOSTA OF REG-ENDERECO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -2865- MOVE '2' TO R2-TIPO-ENDER OF REG-ENDERECO. */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -2868- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO);

            /*" -2871- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO);

            /*" -2874- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE);

            /*" -2877- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF);

            /*" -2880- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP);

            /*" -2882- WRITE REG-PRP-BILHETE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

            /*" -2882- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0700-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0700_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -2892- MOVE 'R0700-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0700-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2894- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2897- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-BILHETE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_BILHETE);

            /*" -2901- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -2904- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -2907- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO R3-NUM-SICOB OF REG-PROPOSTA-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB);

            /*" -2908- IF BILHETE-RAMO OF DCLBILHETE EQUAL 14 OR 72 */

            if (BILHETE.DCLBILHETE.BILHETE_RAMO.In("14", "72"))
            {

                /*" -2910- MOVE 10 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                _.Move(10, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                /*" -2911- ELSE */
            }
            else
            {


                /*" -2914- IF BILHETE-RAMO OF DCLBILHETE EQUAL 82 OR BILHETE-RAMO OF DCLBILHETE EQUAL 81 OR BILHETE-RAMO OF DCLBILHETE EQUAL 37 */

                if (BILHETE.DCLBILHETE.BILHETE_RAMO == 82 || BILHETE.DCLBILHETE.BILHETE_RAMO == 81 || BILHETE.DCLBILHETE.BILHETE_RAMO == 37)
                {

                    /*" -2916- MOVE 09 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                    _.Move(09, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                    /*" -2917- ELSE */
                }
                else
                {


                    /*" -2918- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -2921- DISPLAY '          RAMO NAO ESPERADO - BILHETE/RAMO => ' BILHETE-NUM-BILHETE OF DCLBILHETE '  ' BILHETE-RAMO OF DCLBILHETE */

                    $"          RAMO NAO ESPERADO - BILHETE/RAMO => {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}  {BILHETE.DCLBILHETE.BILHETE_RAMO}"
                    .Display();

                    /*" -2922- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2933- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -2935- IF ENDOSSOS-COD-PRODUTO EQUAL 3701 OR JVPRD3701 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString()))
            {

                /*" -2936- IF ACHOU-ORIGEM-34 */

                if (WAREA_AUXILIAR.N88_ACHOU_ORIGEM_34["ACHOU_ORIGEM_34"])
                {

                    /*" -2938- MOVE 009 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                    _.Move(009, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                    /*" -2939- ELSE */
                }
                else
                {


                    /*" -2941- MOVE 029 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                    _.Move(029, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                    /*" -2942- END-IF */
                }


                /*" -2944- END-IF */
            }


            /*" -2947- MOVE BILHETE-AGE-COBRANCA OF DCLBILHETE TO R3-AGECOBR OF REG-PROPOSTA-SASSE */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -2949- MOVE BILHETE-DATA-QUITACAO OF DCLBILHETE TO W-DATA-SQL */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2950- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO);

            /*" -2951- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO);

            /*" -2952- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO);

            /*" -2955- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -2958- MOVE ZEROS TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);

            /*" -2961- MOVE BILHETE-NUM-CONTA-DEB OF DCLBILHETE TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

            /*" -2964- MOVE BILHETE-COD-AGENCIA-DEB OF DCLBILHETE TO R3-AGECTADEB OF REG-PROPOSTA-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

            /*" -2967- MOVE BILHETE-OPERACAO-CONTA-DEB OF DCLBILHETE TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

            /*" -2970- MOVE BILHETE-DIG-CONTA-DEB OF DCLBILHETE TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

            /*" -2974- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

            /*" -2976- IF ENDOSSOS-COD-PRODUTO EQUAL 3701 OR JVPRD3701 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString()))
            {

                /*" -2978- MOVE ZEROS TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

                /*" -2979- ELSE */
            }
            else
            {


                /*" -2981- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

                /*" -2995- END-IF */
            }


            /*" -2998- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ);

            /*" -3001- MOVE SPACES TO R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -3008- MOVE ZEROS TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

            /*" -3013- MOVE 12 TO R3-PERIPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(12, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -3017- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

            /*" -3023- MOVE SPACES TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -3026- MOVE W-TOT-COMISSAO TO R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_TOT_COMISSAO, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO);

            /*" -3028- IF ENDOSSOS-COD-PRODUTO EQUAL 3701 OR 3716 OR JVPRD3701 OR JVPRD3716 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", "3716", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD3716.ToString()))
            {

                /*" -3030- MOVE 'EMT' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Move("EMT", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

                /*" -3031- ELSE */
            }
            else
            {


                /*" -3033- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

                /*" -3035- END-IF */
            }


            /*" -3038- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -3041- MOVE ZEROS TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -3044- MOVE BILHETE-OPC-COBERTURA OF DCLBILHETE TO W-OPC-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, WAREA_AUXILIAR.W_OPC_COBERTURA);

            /*" -3047- MOVE W-OPC-COBERTURA-2 TO R3-OPCAO-COBER OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.FILLER_2.W_OPC_COBERTURA_2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER);

            /*" -3050- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

            /*" -3053- MOVE BILHETE-DATA-QUITACAO OF DCLBILHETE TO W-DATA-SQL */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3054- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO);

            /*" -3055- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO);

            /*" -3056- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO);

            /*" -3059- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -3062- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO);

            /*" -3065- MOVE BILHETE-AGE-COBRANCA OF DCLBILHETE TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -3068- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -3070- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO W-DATA-SQL */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3071- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO);

            /*" -3072- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO);

            /*" -3073- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO);

            /*" -3076- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -3079- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -3081- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -3084- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -3085- IF W-ORIGEM-MARSH EQUAL 'SIM' */

            if (W_ORIGEM_MARSH == "SIM")
            {

                /*" -3086- MOVE 11 TO R3-ORIGEM-PROPOSTA */
                _.Move(11, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_SIV.R3_ORIGEM_PROPOSTA);

                /*" -3088- END-IF. */
            }


            /*" -3089- IF CANAL-CORRESP-NEGOCIAL */

            if (WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA["CANAL_CORRESP_NEGOCIAL"])
            {

                /*" -3090- MOVE 13 TO R3-ORIGEM-PROPOSTA */
                _.Move(13, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_SIV.R3_ORIGEM_PROPOSTA);

                /*" -3091- ELSE */
            }
            else
            {


                /*" -3092-  EVALUATE TRUE  */

                /*" -3093-  WHEN ENDOSSOS-COD-PRODUTO     = 3716  */

                /*" -3093- IF ENDOSSOS-COD-PRODUTO     = 3716 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 3716)
                {

                    /*" -3094- MOVE 09 TO R3-ORIGEM-PROPOSTA */
                    _.Move(09, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_SIV.R3_ORIGEM_PROPOSTA);

                    /*" -3095-  WHEN ENDOSSOS-COD-PRODUTO     = 3725  */

                    /*" -3095- ELSE IF ENDOSSOS-COD-PRODUTO     = 3725 */
                }
                else

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 3725)
                {

                    /*" -3096- MOVE 17 TO R3-ORIGEM-PROPOSTA */
                    _.Move(17, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_SIV.R3_ORIGEM_PROPOSTA);

                    /*" -3097-  WHEN OTHER  */

                    /*" -3097- ELSE */
                }
                else
                {


                    /*" -3098- MOVE 06 TO R3-ORIGEM-PROPOSTA */
                    _.Move(06, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_SIV.R3_ORIGEM_PROPOSTA);

                    /*" -3099-  END-EVALUATE  */

                    /*" -3099- END-IF */
                }


                /*" -3101- END-IF. */
            }


            /*" -3104- WRITE REG-PRP-BILHETE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

            /*" -3106- IF ENDOSSOS-COD-PRODUTO EQUAL 3701 OR JVPRD3701 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.In("3701", JVBKINCL.JV_PRODUTOS.JVPRD3701.ToString()))
            {

                /*" -3107- IF ACHOU-ORIGEM-34 */

                if (WAREA_AUXILIAR.N88_ACHOU_ORIGEM_34["ACHOU_ORIGEM_34"])
                {

                    /*" -3109- MOVE 029 TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
                    _.Move(029, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

                    /*" -3110- END-IF */
                }


                /*" -3112- END-IF */
            }


            /*" -3112- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0750-PROCESSAR-BENEFICIARIOS-SECTION */
        private void R0750_PROCESSAR_BENEFICIARIOS_SECTION()
        {
            /*" -3121- MOVE 'R0750-PROCESSAR-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0750-PROCESSAR-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3123- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3126- MOVE SPACES TO REG-BENEFIC, REG-PRP-BILHETE */
            _.Move("", LBFPF014.REG_BENEFIC, REG_PRP_BILHETE);

            /*" -3130- MOVE '4' TO R4-TIPO-REG OF REG-BENEFIC. */
            _.Move("4", LBFPF014.REG_BENEFIC.R4_TIPO_REG);

            /*" -3133- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R4-NUM-PROPOSTA OF REG-BENEFIC. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA);

            /*" -3143- MOVE ZEROS TO R4-DATA-NASCIMENTO OF REG-BENEFIC, R4-CGC-CPF OF REG-BENEFIC, R4-SEXO OF REG-BENEFIC, R4-ESTADO-CIVIL OF REG-BENEFIC, R4-PCT-FGB OF REG-BENEFIC, R4-PCT-PECULIO OF REG-BENEFIC, R4-PCT-PENSAO OF REG-BENEFIC, R4-QTDE-TITULOS OF REG-BENEFIC. */
            _.Move(0, LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO, LBFPF014.REG_BENEFIC.R4_CGC_CPF, LBFPF014.REG_BENEFIC.R4_SEXO, LBFPF014.REG_BENEFIC.R4_ESTADO_CIVIL, LBFPF014.REG_BENEFIC.R4_PCT_FGB, LBFPF014.REG_BENEFIC.R4_PCT_PECULIO, LBFPF014.REG_BENEFIC.R4_PCT_PENSAO, LBFPF014.REG_BENEFIC.R4_QTDE_TITULOS);

            /*" -3146- MOVE SPACES TO W-FIM-BENEFICIARIOS. */
            _.Move("", WAREA_AUXILIAR.W_FIM_BENEFICIARIOS);

            /*" -3148- PERFORM R0800-00-RELACIONAR-BENEFICIA. */

            R0800_00_RELACIONAR_BENEFICIA_SECTION();

            /*" -3150- PERFORM R0850-00-LER-BENEFICIARIOS. */

            R0850_00_LER_BENEFICIARIOS_SECTION();

            /*" -3151- PERFORM R0900-00-GERAR-REGISTRO-TP4 UNTIL W-FIM-BENEFICIARIOS EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_BENEFICIARIOS == "FIM"))
            {

                R0900_00_GERAR_REGISTRO_TP4_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R0800-00-RELACIONAR-BENEFICIA-SECTION */
        private void R0800_00_RELACIONAR_BENEFICIA_SECTION()
        {
            /*" -3161- MOVE 'R0800-00-RELACIONAR-BENEFICIA' TO PARAGRAFO. */
            _.Move("R0800-00-RELACIONAR-BENEFICIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3163- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3166- MOVE BILHETE-NUM-BILHETE OF DCLBILHETE TO BENEFICI-NUM-CERTIFICADO OF DCLBENEFICIARIOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);

            /*" -3182- PERFORM R0800_00_RELACIONAR_BENEFICIA_DB_DECLARE_1 */

            R0800_00_RELACIONAR_BENEFICIA_DB_DECLARE_1();

            /*" -3184- PERFORM R0800_00_RELACIONAR_BENEFICIA_DB_OPEN_1 */

            R0800_00_RELACIONAR_BENEFICIA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0800-00-RELACIONAR-BENEFICIA-DB-OPEN-1 */
        public void R0800_00_RELACIONAR_BENEFICIA_DB_OPEN_1()
        {
            /*" -3184- EXEC SQL OPEN BENEFICIARIOS END-EXEC. */

            BENEFICIARIOS.Open();

        }

        [StopWatch]
        /*" R1120-00-BUSCA-MENOR-DATA-DB-DECLARE-1 */
        public void R1120_00_BUSCA_MENOR_DATA_DB_DECLARE_1()
        {
            /*" -4168- EXEC SQL DECLARE DTHBILHETE CURSOR FOR SELECT C.DATA_EMISSAO FROM SEGUROS.BILHETE A, SEGUROS.ENDOSSOS C WHERE A.RAMO IN (81,82,37) AND A.SITUACAO = '9' AND C.NUM_APOLICE = A.NUM_APOLICE AND C.NUM_ENDOSSO = 0 AND C.DATA_EMISSAO < :WHOST-DATA-REF-CURSOR AND C.DATA_EMISSAO > :WHOST-DATA-REF-M1YEAR AND NOT EXISTS (SELECT B.NUM_SICOB FROM SEGUROS.PROPOSTA_FIDELIZ B WHERE A.NUM_BILHETE = B.NUM_SICOB) ORDER BY C.DATA_EMISSAO ASC WITH UR END-EXEC. */
            DTHBILHETE = new PF0617B_DTHBILHETE(true);
            string GetQuery_DTHBILHETE()
            {
                var query = @$"SELECT C.DATA_EMISSAO 
							FROM SEGUROS.BILHETE A
							, 
							SEGUROS.ENDOSSOS C 
							WHERE A.RAMO IN (81
							,82
							,37) 
							AND A.SITUACAO = '9' 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND C.NUM_ENDOSSO = 0 
							AND C.DATA_EMISSAO < '{WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}' 
							AND C.DATA_EMISSAO > '{WAREA_AUXILIAR.WHOST_DATA_REF_M1YEAR}' 
							AND NOT EXISTS
							(SELECT  B.NUM_SICOB 
							FROM SEGUROS.PROPOSTA_FIDELIZ B 
							WHERE A.NUM_BILHETE = B.NUM_SICOB) 
							ORDER BY C.DATA_EMISSAO ASC";

                return query;
            }
            DTHBILHETE.GetQueryEvent += GetQuery_DTHBILHETE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-SECTION */
        private void R0850_00_LER_BENEFICIARIOS_SECTION()
        {
            /*" -3194- MOVE 'R0850-00-LER-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R0850-00-LER-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3196- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3208- PERFORM R0850_00_LER_BENEFICIARIOS_DB_FETCH_1 */

            R0850_00_LER_BENEFICIARIOS_DB_FETCH_1();

            /*" -3211- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3212- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3213- MOVE 'FIM' TO W-FIM-BENEFICIARIOS */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BENEFICIARIOS);

                    /*" -3213- PERFORM R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1 */

                    R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1();

                    /*" -3215- ELSE */
                }
                else
                {


                    /*" -3216- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3218- DISPLAY '          ERRO FETCH BENEFICIARIOS ' SQLCODE */
                    _.Display($"          ERRO FETCH BENEFICIARIOS {DB.SQLCODE}");

                    /*" -3219- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3219- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-DB-FETCH-1 */
        public void R0850_00_LER_BENEFICIARIOS_DB_FETCH_1()
        {
            /*" -3208- EXEC SQL FETCH BENEFICIARIOS INTO :DCLBENEFICIARIOS.BENEFICI-NUM-APOLICE , :DCLBENEFICIARIOS.BENEFICI-COD-SUBGRUPO , :DCLBENEFICIARIOS.BENEFICI-NUM-CERTIFICADO , :DCLBENEFICIARIOS.BENEFICI-DAC-CERTIFICADO , :DCLBENEFICIARIOS.BENEFICI-NUM-BENEFICIARIO , :DCLBENEFICIARIOS.BENEFICI-NOME-BENEFICIARIO , :DCLBENEFICIARIOS.BENEFICI-GRAU-PARENTESCO , :DCLBENEFICIARIOS.BENEFICI-PCT-PART-BENEFICIA , :DCLBENEFICIARIOS.BENEFICI-DATA-INIVIGENCIA , :DCLBENEFICIARIOS.BENEFICI-DATA-TERVIGENCIA END-EXEC. */

            if (BENEFICIARIOS.Fetch())
            {
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_NUM_APOLICE, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_APOLICE);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_COD_SUBGRUPO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_COD_SUBGRUPO);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_NUM_CERTIFICADO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_CERTIFICADO);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_DAC_CERTIFICADO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_DAC_CERTIFICADO);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_NUM_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NUM_BENEFICIARIO);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_NOME_BENEFICIARIO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_GRAU_PARENTESCO, BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_PCT_PART_BENEFICIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_DATA_INIVIGENCIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_INIVIGENCIA);
                _.Move(BENEFICIARIOS.DCLBENEFICIARIOS_BENEFICI_DATA_TERVIGENCIA, BENEFICI.DCLBENEFICIARIOS.BENEFICI_DATA_TERVIGENCIA);
            }

        }

        [StopWatch]
        /*" R0850-00-LER-BENEFICIARIOS-DB-CLOSE-1 */
        public void R0850_00_LER_BENEFICIARIOS_DB_CLOSE_1()
        {
            /*" -3213- EXEC SQL CLOSE BENEFICIARIOS END-EXEC */

            BENEFICIARIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0900-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0900_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -3229- MOVE 'R0900-00-GERA-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0900-00-GERA-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3231- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3234- MOVE BENEFICI-NOME-BENEFICIARIO OF DCLBENEFICIARIOS TO R4-NOME OF REG-BENEFIC. */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_NOME_BENEFICIARIO, LBFPF014.REG_BENEFIC.R4_NOME);

            /*" -3237- IF BENEFICI-GRAU-PARENTESCO OF DCLBENEFICIARIOS EQUAL 'CONJUGE' OR 'MARIDO' OR 'MULHER' OR 'ESPOSA' OR 'ESPOSO' */

            if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("CONJUGE", "MARIDO", "MULHER", "ESPOSA", "ESPOSO"))
            {

                /*" -3239- MOVE 1 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                _.Move(1, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                /*" -3240- ELSE */
            }
            else
            {


                /*" -3242- IF BENEFICI-GRAU-PARENTESCO OF DCLBENEFICIARIOS EQUAL 'COMPANHEIRO(A)' */

                if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO == "COMPANHEIRO(A)")
                {

                    /*" -3244- MOVE 2 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                    _.Move(2, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                    /*" -3245- ELSE */
                }
                else
                {


                    /*" -3247- IF BENEFICI-GRAU-PARENTESCO OF DCLBENEFICIARIOS EQUAL 'FILHOS' OR 'FILHO' OR 'FILHA' */

                    if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("FILHOS", "FILHO", "FILHA"))
                    {

                        /*" -3249- MOVE 3 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                        _.Move(3, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                        /*" -3250- ELSE */
                    }
                    else
                    {


                        /*" -3252- IF BENEFICI-GRAU-PARENTESCO OF DCLBENEFICIARIOS EQUAL 'PAIS' OR 'PAI' OR 'MAE' */

                        if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("PAIS", "PAI", "MAE"))
                        {

                            /*" -3254- MOVE 4 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                            _.Move(4, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                            /*" -3255- ELSE */
                        }
                        else
                        {


                            /*" -3257- IF BENEFICI-GRAU-PARENTESCO OF DCLBENEFICIARIOS EQUAL 'IRMAOS' OR 'IRMAO' OR 'IRMA' */

                            if (BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO.In("IRMAOS", "IRMAO", "IRMA"))
                            {

                                /*" -3259- MOVE 5 TO R4-GRAU-PARENTESCO OF REG-BENEFIC */
                                _.Move(5, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);

                                /*" -3260- ELSE */
                            }
                            else
                            {


                                /*" -3263- MOVE 6 TO R4-GRAU-PARENTESCO OF REG-BENEFIC. */
                                _.Move(6, LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO);
                            }

                        }

                    }

                }

            }


            /*" -3266- MOVE BENEFICI-PCT-PART-BENEFICIA OF DCLBENEFICIARIOS TO R4-PCT-PARTICIP OF REG-BENEFIC. */
            _.Move(BENEFICI.DCLBENEFICIARIOS.BENEFICI_PCT_PART_BENEFICIA, LBFPF014.REG_BENEFIC.R4_PCT_PARTICIP);

            /*" -3268- WRITE REG-PRP-BILHETE FROM REG-BENEFIC. */
            _.Move(LBFPF014.REG_BENEFIC.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

            /*" -3270- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

            /*" -3270- PERFORM R0850-00-LER-BENEFICIARIOS. */

            R0850_00_LER_BENEFICIARIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0910-TRATAR-NUM-MATRICULA-SECTION */
        private void R0910_TRATAR_NUM_MATRICULA_SECTION()
        {
            /*" -3280- MOVE 'R0910-TRATAR-NUM-MATRICULA' TO PARAGRAFO. */
            _.Move("R0910-TRATAR-NUM-MATRICULA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3282- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3284- MOVE ZEROS TO RC-NUM-CORRESPONDENTE OF REG-VENDAS. */
            _.Move(0, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

            /*" -3286- PERFORM R0920-SELECIONAR-FC-LOTERICO. */

            R0920_SELECIONAR_FC_LOTERICO_SECTION();

            /*" -3287- IF WS-EOF-FC-LOTERICO-R0920 EQUAL 1 */

            if (WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0920 == 1)
            {

                /*" -3288- PERFORM R0925-SELECIONAR-FC-LOTERICO */

                R0925_SELECIONAR_FC_LOTERICO_SECTION();

                /*" -3289- IF WS-EOF-FC-LOTERICO-R0925 EQUAL 1 */

                if (WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0925 == 1)
                {

                    /*" -3290- PERFORM R0926-SELECIONAR-FC-LOTERICO */

                    R0926_SELECIONAR_FC_LOTERICO_SECTION();

                    /*" -3291- IF WS-EOF-FC-LOTERICO-R0926 EQUAL 1 */

                    if (WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0926 == 1)
                    {

                        /*" -3292- PERFORM R0927-SELECIONAR-FC-LOTERICO */

                        R0927_SELECIONAR_FC_LOTERICO_SECTION();

                        /*" -3293- IF WS-EOF-FC-LOTERICO-R0927 EQUAL 1 */

                        if (WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0927 == 1)
                        {

                            /*" -3294- PERFORM R0930-SELECIONAR-PRODUTOR */

                            R0930_SELECIONAR_PRODUTOR_SECTION();

                            /*" -3295- IF WS-EOF-PRODUTOR-R0930 EQUAL 1 */

                            if (WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0930 == 1)
                            {

                                /*" -3296- PERFORM R0935-SELECIONAR-PRODUTOR */

                                R0935_SELECIONAR_PRODUTOR_SECTION();

                                /*" -3297- IF WS-EOF-PRODUTOR-R0935 EQUAL 1 */

                                if (WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0935 == 1)
                                {

                                    /*" -3299- MOVE BILHETE-NUM-MATRICULA TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                                    _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                                    /*" -3300- ELSE */
                                }
                                else
                                {


                                    /*" -3302- MOVE PRODUTOR-COD-HIERARQUIA TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                                    _.Move(PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_HIERARQUIA, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                                    /*" -3303- END-IF */
                                }


                                /*" -3304- ELSE */
                            }
                            else
                            {


                                /*" -3306- MOVE PRODUTOR-COD-HIERARQUIA TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                                _.Move(PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_HIERARQUIA, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                                /*" -3307- END-IF */
                            }


                            /*" -3308- ELSE */
                        }
                        else
                        {


                            /*" -3309- MOVE ZEROS TO WS-NUM-CORRESPONDENTE */
                            _.Move(0, WS_NUM_CORRESPONDENTE);

                            /*" -3311- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO WS-NUM-LOTERICO */
                            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, FILLER_23.WS_NUM_LOTERICO);

                            /*" -3313- MOVE FCLOTERI-NUM-DV-LOTERICO TO WS-NUM-DV-LOTERICO */
                            _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, FILLER_23.WS_NUM_DV_LOTERICO);

                            /*" -3315- MOVE WS-NUM-CORRESPONDENTE TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                            _.Move(WS_NUM_CORRESPONDENTE, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                            /*" -3316- END-IF */
                        }


                        /*" -3317- ELSE */
                    }
                    else
                    {


                        /*" -3318- MOVE ZEROS TO WS-NUM-CORRESPONDENTE */
                        _.Move(0, WS_NUM_CORRESPONDENTE);

                        /*" -3320- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO WS-NUM-LOTERICO */
                        _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, FILLER_23.WS_NUM_LOTERICO);

                        /*" -3321- MOVE FCLOTERI-NUM-DV-LOTERICO TO WS-NUM-DV-LOTERICO */
                        _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, FILLER_23.WS_NUM_DV_LOTERICO);

                        /*" -3323- MOVE WS-NUM-CORRESPONDENTE TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                        _.Move(WS_NUM_CORRESPONDENTE, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                        /*" -3324- END-IF */
                    }


                    /*" -3325- ELSE */
                }
                else
                {


                    /*" -3326- MOVE ZEROS TO WS-NUM-CORRESPONDENTE */
                    _.Move(0, WS_NUM_CORRESPONDENTE);

                    /*" -3327- MOVE FCLOTERI-NUM-LOTERICO TO WS-NUM-LOTERICO */
                    _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO, FILLER_23.WS_NUM_LOTERICO);

                    /*" -3328- MOVE FCLOTERI-NUM-DV-LOTERICO TO WS-NUM-DV-LOTERICO */
                    _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, FILLER_23.WS_NUM_DV_LOTERICO);

                    /*" -3330- MOVE WS-NUM-CORRESPONDENTE TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                    _.Move(WS_NUM_CORRESPONDENTE, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                    /*" -3331- END-IF */
                }


                /*" -3332- ELSE */
            }
            else
            {


                /*" -3333- MOVE ZEROS TO WS-NUM-CORRESPONDENTE */
                _.Move(0, WS_NUM_CORRESPONDENTE);

                /*" -3334- MOVE FCLOTERI-NUM-LOTERICO TO WS-NUM-LOTERICO */
                _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO, FILLER_23.WS_NUM_LOTERICO);

                /*" -3335- MOVE FCLOTERI-NUM-DV-LOTERICO TO WS-NUM-DV-LOTERICO */
                _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, FILLER_23.WS_NUM_DV_LOTERICO);

                /*" -3337- MOVE WS-NUM-CORRESPONDENTE TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
                _.Move(WS_NUM_CORRESPONDENTE, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

                /*" -3339- END-IF */
            }


            /*" -3340- IF BILHETE-NUM-MATRICULA OF DCLBILHETE EQUAL 90071115 */

            if (BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA.GetMoveValues().ToInt() == 90071115)
            {

                /*" -3341- PERFORM R0915-SELECIONAR-FC-LOTERICO */

                R0915_SELECIONAR_FC_LOTERICO_SECTION();

                /*" -3341- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_SAIDA*/

        [StopWatch]
        /*" R0915-SELECIONAR-FC-LOTERICO-SECTION */
        private void R0915_SELECIONAR_FC_LOTERICO_SECTION()
        {
            /*" -3351- MOVE 'R0915-SELECIONAR-FC-LOTERICO' TO PARAGRAFO. */
            _.Move("R0915-SELECIONAR-FC-LOTERICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3352- MOVE 'SELECT FC-LOTERICO' TO COMANDO. */
            _.Move("SELECT FC-LOTERICO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3354- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3356- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO WS-FCLOTERI-NUM-LOTERICO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, WAREA_AUXILIAR.WS_FCLOTERI_NUM_LOTERICO);

            /*" -3358- MOVE WS-FCLOTERI-NUM-LOTERICO-8 TO FCLOTERI-NUM-LOTERICO */
            _.Move(WAREA_AUXILIAR.FILLER_6.WS_FCLOTERI_NUM_LOTERICO_8, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO);

            /*" -3365- PERFORM R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1 */

            R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1();

            /*" -3368- MOVE FCLOTERI-NUM-DV-LOTERICO TO WS-FCLOTERI-NUM-LOTERICO-1 */
            _.Move(FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, WAREA_AUXILIAR.FILLER_6.WS_FCLOTERI_NUM_LOTERICO_1);

            /*" -3371- MOVE WS-FCLOTERI-NUM-LOTERICO TO RC-NUM-CORRESPONDENTE OF REG-VENDAS */
            _.Move(WAREA_AUXILIAR.WS_FCLOTERI_NUM_LOTERICO, LBFPF010.REG_VENDAS.RC_NUM_CORRESPONDENTE);

            /*" -3372- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3373- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -3374- DISPLAY '          ERRO SELECT TAB. FC_LOTERICO' */
                _.Display($"          ERRO SELECT TAB. FC_LOTERICO");

                /*" -3376- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -3378- DISPLAY '          NUMERO LOTERICO................. ' FCLOTERI-NUM-LOTERICO */
                _.Display($"          NUMERO LOTERICO................. {FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO}");

                /*" -3380- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -3381- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3382- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3382- END-IF. */
            }


        }

        [StopWatch]
        /*" R0915-SELECIONAR-FC-LOTERICO-DB-SELECT-1 */
        public void R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1()
        {
            /*" -3365- EXEC SQL SELECT NUM_DV_LOTERICO INTO :FCLOTERI-NUM-DV-LOTERICO FROM FDRCAP.FC_LOTERICO WHERE NUM_LOTERICO = :FCLOTERI-NUM-LOTERICO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 = new R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1()
            {
                FCLOTERI_NUM_LOTERICO = FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO.ToString(),
            };

            var executed_1 = R0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1.Execute(r0915_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCLOTERI_NUM_DV_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0915_SAIDA*/

        [StopWatch]
        /*" R0920-SELECIONAR-FC-LOTERICO-SECTION */
        private void R0920_SELECIONAR_FC_LOTERICO_SECTION()
        {
            /*" -3392- MOVE 'R0920-SELECIONAR-FC-LOTERICO' TO PARAGRAFO. */
            _.Move("R0920-SELECIONAR-FC-LOTERICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3393- MOVE 'SELECT FC-LOTERICO' TO COMANDO. */
            _.Move("SELECT FC-LOTERICO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3395- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3399- MOVE ZEROS TO FCLOTERI-NUM-LOTERICO FCLOTERI-NUM-DV-LOTERICO WS-EOF-FC-LOTERICO-R0920. */
            _.Move(0, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0920);

            /*" -3402- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO FCLOTERI-NUM-LOTERICO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO);

            /*" -3409- PERFORM R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1 */

            R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1();

            /*" -3412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3413- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3414- MOVE 1 TO WS-EOF-FC-LOTERICO-R0920 */
                    _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0920);

                    /*" -3415- ELSE */
                }
                else
                {


                    /*" -3416- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3417- DISPLAY '          ERRO SELECT TAB. FC_LOTERICO' */
                    _.Display($"          ERRO SELECT TAB. FC_LOTERICO");

                    /*" -3419- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                    _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -3421- DISPLAY '          NUMERO LOTERICO................. ' FCLOTERI-NUM-LOTERICO */
                    _.Display($"          NUMERO LOTERICO................. {FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO}");

                    /*" -3423- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3424- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3425- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3426- END-IF */
                }


                /*" -3426- END-IF. */
            }


        }

        [StopWatch]
        /*" R0920-SELECIONAR-FC-LOTERICO-DB-SELECT-1 */
        public void R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1()
        {
            /*" -3409- EXEC SQL SELECT NUM_DV_LOTERICO INTO :FCLOTERI-NUM-DV-LOTERICO FROM FDRCAP.FC_LOTERICO WHERE NUM_LOTERICO = :FCLOTERI-NUM-LOTERICO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 = new R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1()
            {
                FCLOTERI_NUM_LOTERICO = FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO.ToString(),
            };

            var executed_1 = R0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1.Execute(r0920_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCLOTERI_NUM_DV_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_SAIDA*/

        [StopWatch]
        /*" R0925-SELECIONAR-FC-LOTERICO-SECTION */
        private void R0925_SELECIONAR_FC_LOTERICO_SECTION()
        {
            /*" -3436- MOVE 'R0925-SELECIONAR-FC-LOTERICO' TO PARAGRAFO. */
            _.Move("R0925-SELECIONAR-FC-LOTERICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3437- MOVE 'SELECT FC-LOTERICO' TO COMANDO. */
            _.Move("SELECT FC-LOTERICO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3439- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3444- MOVE ZEROS TO WS-MATRICULA FCLOTERI-NUM-LOTERICO FCLOTERI-NUM-DV-LOTERICO WS-EOF-FC-LOTERICO-R0925. */
            _.Move(0, WAREA_AUXILIAR.WS_MATRICULA, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0925);

            /*" -3446- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO WS-MATRICULA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, WAREA_AUXILIAR.WS_MATRICULA);

            /*" -3448- MOVE WS-MATR01 TO FCLOTERI-NUM-LOTERICO. */
            _.Move(WAREA_AUXILIAR.FILLER_7.WS_MATR01, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO);

            /*" -3449- IF FCLOTERI-NUM-LOTERICO EQUAL ZEROS */

            if (FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO == 00)
            {

                /*" -3450- MOVE 1 TO WS-EOF-FC-LOTERICO-R0925 */
                _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0925);

                /*" -3451- GO TO R0925-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0925_SAIDA*/ //GOTO
                return;

                /*" -3453- END-IF. */
            }


            /*" -3460- PERFORM R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1 */

            R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1();

            /*" -3463- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3464- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3465- MOVE 1 TO WS-EOF-FC-LOTERICO-R0925 */
                    _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0925);

                    /*" -3466- ELSE */
                }
                else
                {


                    /*" -3467- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3468- DISPLAY '          ERRO SELECT TAB. FC_LOTERICO' */
                    _.Display($"          ERRO SELECT TAB. FC_LOTERICO");

                    /*" -3470- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                    _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -3472- DISPLAY '          NUMERO LOTERICO................. ' FCLOTERI-NUM-LOTERICO */
                    _.Display($"          NUMERO LOTERICO................. {FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO}");

                    /*" -3474- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3475- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3476- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3477- END-IF */
                }


                /*" -3477- END-IF. */
            }


        }

        [StopWatch]
        /*" R0925-SELECIONAR-FC-LOTERICO-DB-SELECT-1 */
        public void R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1()
        {
            /*" -3460- EXEC SQL SELECT NUM_DV_LOTERICO INTO :FCLOTERI-NUM-DV-LOTERICO FROM FDRCAP.FC_LOTERICO WHERE NUM_LOTERICO = :FCLOTERI-NUM-LOTERICO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 = new R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1()
            {
                FCLOTERI_NUM_LOTERICO = FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO.ToString(),
            };

            var executed_1 = R0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1.Execute(r0925_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCLOTERI_NUM_DV_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0925_SAIDA*/

        [StopWatch]
        /*" R0926-SELECIONAR-FC-LOTERICO-SECTION */
        private void R0926_SELECIONAR_FC_LOTERICO_SECTION()
        {
            /*" -3489- MOVE 'R0926-SELECIONAR-FC-LOTERICO' TO PARAGRAFO. */
            _.Move("R0926-SELECIONAR-FC-LOTERICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3490- MOVE 'SELECT FC-LOTERICO' TO COMANDO. */
            _.Move("SELECT FC-LOTERICO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3492- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3497- MOVE ZEROS TO WS-MATRICULA FCLOTERI-NUM-LOTERICO FCLOTERI-NUM-DV-LOTERICO WS-EOF-FC-LOTERICO-R0926. */
            _.Move(0, WAREA_AUXILIAR.WS_MATRICULA, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0926);

            /*" -3500- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO W-MATRI-CCA WS-MATRICULA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, WAREA_AUXILIAR.W_MATRI_CCA, WAREA_AUXILIAR.WS_MATRICULA);

            /*" -3501- MOVE 9 TO W-MATRI-CCA(1:1). */
            _.MoveAtPosition(9, WAREA_AUXILIAR.W_MATRI_CCA, 1, 1);

            /*" -3503- MOVE W-MATRI-CCA TO FCLOTERI-NUM-LOTERICO. */
            _.Move(WAREA_AUXILIAR.W_MATRI_CCA, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO);

            /*" -3504- IF FCLOTERI-NUM-LOTERICO EQUAL ZEROS */

            if (FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO == 00)
            {

                /*" -3505- MOVE 1 TO WS-EOF-FC-LOTERICO-R0926 */
                _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0926);

                /*" -3506- GO TO R0926-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0926_SAIDA*/ //GOTO
                return;

                /*" -3508- END-IF. */
            }


            /*" -3515- PERFORM R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1 */

            R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1();

            /*" -3518- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3519- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3520- MOVE 1 TO WS-EOF-FC-LOTERICO-R0926 */
                    _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0926);

                    /*" -3521- ELSE */
                }
                else
                {


                    /*" -3522- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3523- DISPLAY '          ERRO SELECT TAB. FC_LOTERICO' */
                    _.Display($"          ERRO SELECT TAB. FC_LOTERICO");

                    /*" -3525- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                    _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -3527- DISPLAY '          NUMERO LOTERICO................. ' FCLOTERI-NUM-LOTERICO */
                    _.Display($"          NUMERO LOTERICO................. {FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO}");

                    /*" -3529- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3530- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3531- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3532- END-IF */
                }


                /*" -3533- ELSE */
            }
            else
            {


                /*" -3534- ADD 1 TO WS-NUM-LOTERICO-26 */
                WS_NUM_LOTERICO_26.Value = WS_NUM_LOTERICO_26 + 1;

                /*" -3534- END-IF. */
            }


        }

        [StopWatch]
        /*" R0926-SELECIONAR-FC-LOTERICO-DB-SELECT-1 */
        public void R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1()
        {
            /*" -3515- EXEC SQL SELECT NUM_DV_LOTERICO INTO :FCLOTERI-NUM-DV-LOTERICO FROM FDRCAP.FC_LOTERICO WHERE NUM_LOTERICO = :FCLOTERI-NUM-LOTERICO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 = new R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1()
            {
                FCLOTERI_NUM_LOTERICO = FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO.ToString(),
            };

            var executed_1 = R0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1.Execute(r0926_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCLOTERI_NUM_DV_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0926_SAIDA*/

        [StopWatch]
        /*" R0927-SELECIONAR-FC-LOTERICO-SECTION */
        private void R0927_SELECIONAR_FC_LOTERICO_SECTION()
        {
            /*" -3544- MOVE 'R0925-SELECIONAR-FC-LOTERICO' TO PARAGRAFO. */
            _.Move("R0925-SELECIONAR-FC-LOTERICO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3545- MOVE 'SELECT FC-LOTERICO' TO COMANDO. */
            _.Move("SELECT FC-LOTERICO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3547- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3552- MOVE ZEROS TO WS-MATRICULA FCLOTERI-NUM-LOTERICO FCLOTERI-NUM-DV-LOTERICO WS-EOF-FC-LOTERICO-R0927. */
            _.Move(0, WAREA_AUXILIAR.WS_MATRICULA, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0927);

            /*" -3554- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO WS-MATRICULA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, WAREA_AUXILIAR.WS_MATRICULA);

            /*" -3555- MOVE WS-MATR01 TO W-MATRI-CCA. */
            _.Move(WAREA_AUXILIAR.FILLER_7.WS_MATR01, WAREA_AUXILIAR.W_MATRI_CCA);

            /*" -3556- MOVE 9 TO W-MATRI-CCA(1:1). */
            _.MoveAtPosition(9, WAREA_AUXILIAR.W_MATRI_CCA, 1, 1);

            /*" -3558- MOVE W-MATRI-CCA TO FCLOTERI-NUM-LOTERICO. */
            _.Move(WAREA_AUXILIAR.W_MATRI_CCA, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO);

            /*" -3559- IF FCLOTERI-NUM-LOTERICO EQUAL ZEROS */

            if (FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO == 00)
            {

                /*" -3560- MOVE 1 TO WS-EOF-FC-LOTERICO-R0927 */
                _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0927);

                /*" -3561- GO TO R0927-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0927_SAIDA*/ //GOTO
                return;

                /*" -3563- END-IF. */
            }


            /*" -3570- PERFORM R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1 */

            R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1();

            /*" -3573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3574- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3575- MOVE 1 TO WS-EOF-FC-LOTERICO-R0927 */
                    _.Move(1, WAREA_AUXILIAR.WS_EOF_FC_LOTERICO_R0927);

                    /*" -3576- ELSE */
                }
                else
                {


                    /*" -3577- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3578- DISPLAY '          ERRO SELECT TAB. FC_LOTERICO' */
                    _.Display($"          ERRO SELECT TAB. FC_LOTERICO");

                    /*" -3580- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                    _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -3582- DISPLAY '          NUMERO LOTERICO................. ' FCLOTERI-NUM-LOTERICO */
                    _.Display($"          NUMERO LOTERICO................. {FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO}");

                    /*" -3584- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3585- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3586- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3587- END-IF */
                }


                /*" -3588- ELSE */
            }
            else
            {


                /*" -3589- ADD 1 TO WS-NUM-LOTERICO-27 */
                WS_NUM_LOTERICO_27.Value = WS_NUM_LOTERICO_27 + 1;

                /*" -3589- END-IF. */
            }


        }

        [StopWatch]
        /*" R0927-SELECIONAR-FC-LOTERICO-DB-SELECT-1 */
        public void R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1()
        {
            /*" -3570- EXEC SQL SELECT NUM_DV_LOTERICO INTO :FCLOTERI-NUM-DV-LOTERICO FROM FDRCAP.FC_LOTERICO WHERE NUM_LOTERICO = :FCLOTERI-NUM-LOTERICO FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1 = new R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1()
            {
                FCLOTERI_NUM_LOTERICO = FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_LOTERICO.ToString(),
            };

            var executed_1 = R0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1.Execute(r0927_SELECIONAR_FC_LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FCLOTERI_NUM_DV_LOTERICO, FCLOTERI.DCLFC_LOTERICO.FCLOTERI_NUM_DV_LOTERICO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0927_SAIDA*/

        [StopWatch]
        /*" R0930-SELECIONAR-PRODUTOR-SECTION */
        private void R0930_SELECIONAR_PRODUTOR_SECTION()
        {
            /*" -3600- MOVE 'R0930-SELECIONAR-PRODUTOR' TO PARAGRAFO. */
            _.Move("R0930-SELECIONAR-PRODUTOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3601- MOVE 'SELECT PRODUTORES' TO COMANDO. */
            _.Move("SELECT PRODUTORES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3603- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3606- MOVE ZEROS TO PRODUTOR-NUM-MATRICULA WS-EOF-PRODUTOR-R0930. */
            _.Move(0, PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA, WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0930);

            /*" -3609- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO PRODUTOR-NUM-MATRICULA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA);

            /*" -3611- MOVE 'L' TO PRODUTOR-TIPO-PRODUTOR. */
            _.Move("L", PRODUTOR.DCLPRODUTORES.PRODUTOR_TIPO_PRODUTOR);

            /*" -3619- PERFORM R0930_SELECIONAR_PRODUTOR_DB_SELECT_1 */

            R0930_SELECIONAR_PRODUTOR_DB_SELECT_1();

            /*" -3622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3623- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3624- MOVE 1 TO WS-EOF-PRODUTOR-R0930 */
                    _.Move(1, WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0930);

                    /*" -3625- ELSE */
                }
                else
                {


                    /*" -3626- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3627- DISPLAY '          ERRO SELECT TAB. PRODUTORES' */
                    _.Display($"          ERRO SELECT TAB. PRODUTORES");

                    /*" -3629- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                    _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -3631- DISPLAY '          NUM MATRICULA................... ' PRODUTOR-NUM-MATRICULA */
                    _.Display($"          NUM MATRICULA................... {PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA}");

                    /*" -3633- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3634- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3635- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3636- END-IF */
                }


                /*" -3636- END-IF. */
            }


        }

        [StopWatch]
        /*" R0930-SELECIONAR-PRODUTOR-DB-SELECT-1 */
        public void R0930_SELECIONAR_PRODUTOR_DB_SELECT_1()
        {
            /*" -3619- EXEC SQL SELECT COD_HIERARQUIA INTO :PRODUTOR-COD-HIERARQUIA FROM SEGUROS.PRODUTORES WHERE NUM_MATRICULA = :PRODUTOR-NUM-MATRICULA AND TIPO_PRODUTOR = :PRODUTOR-TIPO-PRODUTOR FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0930_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1 = new R0930_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1()
            {
                PRODUTOR_NUM_MATRICULA = PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA.ToString(),
                PRODUTOR_TIPO_PRODUTOR = PRODUTOR.DCLPRODUTORES.PRODUTOR_TIPO_PRODUTOR.ToString(),
            };

            var executed_1 = R0930_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1.Execute(r0930_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTOR_COD_HIERARQUIA, PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_HIERARQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_SAIDA*/

        [StopWatch]
        /*" R0935-SELECIONAR-PRODUTOR-SECTION */
        private void R0935_SELECIONAR_PRODUTOR_SECTION()
        {
            /*" -3645- MOVE 'R0935-SELECIONAR-PRODUTOR' TO PARAGRAFO. */
            _.Move("R0935-SELECIONAR-PRODUTOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3646- MOVE 'SELECT PRODUTORES' TO COMANDO. */
            _.Move("SELECT PRODUTORES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3648- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3652- MOVE ZEROS TO WS-MATRICULA PRODUTOR-NUM-MATRICULA WS-EOF-PRODUTOR-R0935. */
            _.Move(0, WAREA_AUXILIAR.WS_MATRICULA, PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA, WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0935);

            /*" -3654- MOVE 'L' TO PRODUTOR-TIPO-PRODUTOR. */
            _.Move("L", PRODUTOR.DCLPRODUTORES.PRODUTOR_TIPO_PRODUTOR);

            /*" -3657- MOVE BILHETE-NUM-MATRICULA OF DCLBILHETE TO WS-MATRICULA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA, WAREA_AUXILIAR.WS_MATRICULA);

            /*" -3659- MOVE WS-MATR01 TO PRODUTOR-NUM-MATRICULA. */
            _.Move(WAREA_AUXILIAR.FILLER_7.WS_MATR01, PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA);

            /*" -3660- IF PRODUTOR-NUM-MATRICULA EQUAL ZEROS */

            if (PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA == 00)
            {

                /*" -3661- MOVE 1 TO WS-EOF-PRODUTOR-R0935 */
                _.Move(1, WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0935);

                /*" -3662- GO TO R0935-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0935_SAIDA*/ //GOTO
                return;

                /*" -3664- END-IF. */
            }


            /*" -3671- PERFORM R0935_SELECIONAR_PRODUTOR_DB_SELECT_1 */

            R0935_SELECIONAR_PRODUTOR_DB_SELECT_1();

            /*" -3674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3675- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3676- MOVE 1 TO WS-EOF-PRODUTOR-R0935 */
                    _.Move(1, WAREA_AUXILIAR.WS_EOF_PRODUTOR_R0935);

                    /*" -3677- ELSE */
                }
                else
                {


                    /*" -3678- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -3679- DISPLAY '          ERRO SELECT TAB. PRODUTORES' */
                    _.Display($"          ERRO SELECT TAB. PRODUTORES");

                    /*" -3681- DISPLAY '          NUMERO BILHETE.................. ' BILHETE-NUM-BILHETE */
                    _.Display($"          NUMERO BILHETE.................. {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -3683- DISPLAY '          NUM MATRICULA................... ' PRODUTOR-NUM-MATRICULA */
                    _.Display($"          NUM MATRICULA................... {PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA}");

                    /*" -3685- DISPLAY '          SQLCODE......................... ' SQLCODE */
                    _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                    /*" -3686- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3687- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3688- END-IF */
                }


                /*" -3688- END-IF. */
            }


        }

        [StopWatch]
        /*" R0935-SELECIONAR-PRODUTOR-DB-SELECT-1 */
        public void R0935_SELECIONAR_PRODUTOR_DB_SELECT_1()
        {
            /*" -3671- EXEC SQL SELECT COD_HIERARQUIA INTO :PRODUTOR-COD-HIERARQUIA FROM SEGUROS.PRODUTORES WHERE NUM_MATRICULA = :PRODUTOR-NUM-MATRICULA FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r0935_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1 = new R0935_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1()
            {
                PRODUTOR_NUM_MATRICULA = PRODUTOR.DCLPRODUTORES.PRODUTOR_NUM_MATRICULA.ToString(),
            };

            var executed_1 = R0935_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1.Execute(r0935_SELECIONAR_PRODUTOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTOR_COD_HIERARQUIA, PRODUTOR.DCLPRODUTORES.PRODUTOR_COD_HIERARQUIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0935_SAIDA*/

        [StopWatch]
        /*" R0950-PROCESSAR-VENDAS-SECTION */
        private void R0950_PROCESSAR_VENDAS_SECTION()
        {
            /*" -3698- MOVE 'R0950-PROCESSAR-VENDAS' TO PARAGRAFO. */
            _.Move("R0950-PROCESSAR-VENDAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3700- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3705- MOVE SPACES TO RC-TIPO-REG RC-COD-OPERADOR RC-ORIG-PROPOSTA RC-ESPACOS. */
            _.Move("", LBFPF010.REG_VENDAS.RC_TIPO_REG, LBFPF010.REG_VENDAS.RC_COD_OPERADOR, LBFPF010.REG_VENDAS.RC_ORIG_PROPOSTA, LBFPF010.REG_VENDAS.RC_ESPACOS);

            /*" -3711- MOVE ZEROS TO RC-NUM-PROPOSTA RC-DATA-CONTRATACAO RC-HORA-CONTRATACAO RC-NUM-PROPOSTA-SICAQ RC-TIPO-CORREPONDENTE. */
            _.Move(0, LBFPF010.REG_VENDAS.RC_NUM_PROPOSTA, LBFPF010.REG_VENDAS.RC_DATA_CONTRATACAO, LBFPF010.REG_VENDAS.RC_HORA_CONTRATACAO, LBFPF010.REG_VENDAS.RC_NUM_PROPOSTA_SICAQ, LBFPF010.REG_VENDAS.RC_TIPO_CORREPONDENTE);

            /*" -3714- MOVE 'C' TO RC-TIPO-REG OF REG-VENDAS. */
            _.Move("C", LBFPF010.REG_VENDAS.RC_TIPO_REG);

            /*" -3718- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO RC-NUM-PROPOSTA OF REG-VENDAS. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF010.REG_VENDAS.RC_NUM_PROPOSTA);

            /*" -3720- MOVE SPACES TO RC-COD-OPERADOR OF REG-VENDAS. */
            _.Move("", LBFPF010.REG_VENDAS.RC_COD_OPERADOR);

            /*" -3723- MOVE BILHETE-DATA-VENDA(1:4) TO WS-ANO-CONTRATACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA.Substring(1, 4), WAREA_AUXILIAR.WS_DATA_CONTRATACAO.WS_ANO_CONTRATACAO);

            /*" -3726- MOVE BILHETE-DATA-VENDA(6:2) TO WS-MES-CONTRATACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA.Substring(6, 2), WAREA_AUXILIAR.WS_DATA_CONTRATACAO.WS_MES_CONTRATACAO);

            /*" -3729- MOVE BILHETE-DATA-VENDA(9:2) TO WS-DIA-CONTRATACAO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_VENDA.Substring(9, 2), WAREA_AUXILIAR.WS_DATA_CONTRATACAO.WS_DIA_CONTRATACAO);

            /*" -3732- MOVE WS-DATA-CONTRATACAO TO RC-DATA-CONTRATACAO OF REG-VENDAS. */
            _.Move(WAREA_AUXILIAR.WS_DATA_CONTRATACAO, LBFPF010.REG_VENDAS.RC_DATA_CONTRATACAO);

            /*" -3735- MOVE ZEROS TO RC-HORA-CONTRATACAO OF REG-VENDAS. */
            _.Move(0, LBFPF010.REG_VENDAS.RC_HORA_CONTRATACAO);

            /*" -3738- MOVE ZEROS TO RC-NUM-PROPOSTA-SICAQ OF REG-VENDAS. */
            _.Move(0, LBFPF010.REG_VENDAS.RC_NUM_PROPOSTA_SICAQ);

            /*" -3741- MOVE 2 TO RC-TIPO-CORREPONDENTE OF REG-VENDAS. */
            _.Move(2, LBFPF010.REG_VENDAS.RC_TIPO_CORREPONDENTE);

            /*" -3744- MOVE SPACES TO RC-ORIG-PROPOSTA OF REG-VENDAS. */
            _.Move("", LBFPF010.REG_VENDAS.RC_ORIG_PROPOSTA);

            /*" -3744- PERFORM R0960-00-GERAR-REGISTRO-TP-C. */

            R0960_00_GERAR_REGISTRO_TP_C_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0960-00-GERAR-REGISTRO-TP-C-SECTION */
        private void R0960_00_GERAR_REGISTRO_TP_C_SECTION()
        {
            /*" -3755- MOVE 'R0960-00-GERA-REGISTRO-TP-C' TO PARAGRAFO. */
            _.Move("R0960-00-GERA-REGISTRO-TP-C", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3757- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3759- WRITE REG-PRP-BILHETE FROM REG-VENDAS. */
            _.Move(LBFPF010.REG_VENDAS.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

            /*" -3759- ADD 1 TO W-QTD-LD-TIPO-C. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_C.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_C + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0960_SAIDA*/

        [StopWatch]
        /*" R1200-00-GERAR-REGISTRO-TPD-SECTION */
        private void R1200_00_GERAR_REGISTRO_TPD_SECTION()
        {
            /*" -3771- MOVE '*' TO LK-GE053-E-TRACE */
            _.Move("*", SPGE053W.LK_GE053_E_TRACE);

            /*" -3772- MOVE 'PF' TO LK-GE053-E-IDE-SISTEMA */
            _.Move("PF", SPGE053W.LK_GE053_E_IDE_SISTEMA);

            /*" -3775- MOVE 2 TO LK-GE053-E-IND-OPERACAO */
            _.Move(2, SPGE053W.LK_GE053_E_IND_OPERACAO);

            /*" -3776- MOVE CGCCPF OF DCLCLIENTES TO LK-GE053-I-NUM-CPF. */
            _.Move(CLIENTE.DCLCLIENTES.CGCCPF, SPGE053W.LK_GE053_I_NUM_CPF);

            /*" -3778- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-OPERACAO. */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_OPERACAO);

            /*" -3779- MOVE SPACES TO LK-GE053-I-NOM-SOCIAL. */
            _.Move("", SPGE053W.LK_GE053_I_NOM_SOCIAL);

            /*" -3780- MOVE SPACES TO LK-GE053-I-IND-TIPO-ACAO. */
            _.Move("", SPGE053W.LK_GE053_I_IND_TIPO_ACAO);

            /*" -3781- MOVE SPACES TO LK-GE053-I-IND-USA-NOME-SOCIAL. */
            _.Move("", SPGE053W.LK_GE053_I_IND_USA_NOME_SOCIAL);

            /*" -3782- MOVE 0 TO LK-GE053-I-COD-TP-PES-NEGOCIO. */
            _.Move(0, SPGE053W.LK_GE053_I_COD_TP_PES_NEGOCIO);

            /*" -3783- MOVE 0 TO LK-GE053-I-NUM-PROPOSTA. */
            _.Move(0, SPGE053W.LK_GE053_I_NUM_PROPOSTA);

            /*" -3784- MOVE SPACES TO LK-GE053-I-COD-CANAL-ORIGEM. */
            _.Move("", SPGE053W.LK_GE053_I_COD_CANAL_ORIGEM);

            /*" -3785- MOVE SPACES TO LK-GE053-I-NUM-MATRICULA. */
            _.Move("", SPGE053W.LK_GE053_I_NUM_MATRICULA);

            /*" -3786- MOVE SPACES TO LK-GE053-I-NOM-PROGRAMA. */
            _.Move("", SPGE053W.LK_GE053_I_NOM_PROGRAMA);

            /*" -3789- MOVE '0001-01-01-00.00.00.000000' TO LK-GE053-I-DTH-CADASTRAMENTO. */
            _.Move("0001-01-01-00.00.00.000000", SPGE053W.LK_GE053_I_DTH_CADASTRAMENTO);

            /*" -3811- CALL 'SPBGE053' USING LK-GE053-E-TRACE LK-GE053-E-IDE-SISTEMA LK-GE053-E-IND-OPERACAO LK-GE053-I-NUM-CPF LK-GE053-I-DTH-OPERACAO LK-GE053-I-NOM-SOCIAL LK-GE053-I-IND-TIPO-ACAO LK-GE053-I-IND-USA-NOME-SOCIAL LK-GE053-I-COD-TP-PES-NEGOCIO LK-GE053-I-NUM-PROPOSTA LK-GE053-I-COD-CANAL-ORIGEM LK-GE053-I-NUM-MATRICULA LK-GE053-I-NOM-PROGRAMA LK-GE053-I-DTH-CADASTRAMENTO LK-GE053-IND-ERRO LK-GE053-ID-ERRO LK-GE053-MENSAGEM LK-GE053-NOM-TABELA LK-GE053-SQLCODE LK-GE053-SQLERRMC LK-GE053-SQLSTATE. */
            _.Call("SPBGE053", SPGE053W);

            /*" -3812- IF LK-GE053-IND-ERRO NOT EQUAL ZERO */

            if (SPGE053W.LK_GE053_IND_ERRO != 00)
            {

                /*" -3813- DISPLAY 'ERRO NO PROCESSAMENTO DO NOME SOCIAL' */
                _.Display($"ERRO NO PROCESSAMENTO DO NOME SOCIAL");

                /*" -3814- DISPLAY 'LK-GE053-IND-ERRO   ' LK-GE053-IND-ERRO */
                _.Display($"LK-GE053-IND-ERRO   {SPGE053W.LK_GE053_IND_ERRO}");

                /*" -3815- DISPLAY 'LK-GE053-ID-ERRO    ' LK-GE053-ID-ERRO */
                _.Display($"LK-GE053-ID-ERRO    {SPGE053W.LK_GE053_ID_ERRO}");

                /*" -3816- DISPLAY 'LK-GE053-MENSAGEM   ' LK-GE053-MENSAGEM */
                _.Display($"LK-GE053-MENSAGEM   {SPGE053W.LK_GE053_MENSAGEM}");

                /*" -3817- IF LK-GE053-SQLCODE NOT EQUAL ZERO */

                if (SPGE053W.LK_GE053_SQLCODE != 00)
                {

                    /*" -3818- DISPLAY 'LK-GE053-NOM-TABELA ' LK-GE053-NOM-TABELA */
                    _.Display($"LK-GE053-NOM-TABELA {SPGE053W.LK_GE053_NOM_TABELA}");

                    /*" -3819- DISPLAY 'LK-GE053-SQLCODE    ' LK-GE053-SQLCODE */
                    _.Display($"LK-GE053-SQLCODE    {SPGE053W.LK_GE053_SQLCODE}");

                    /*" -3820- DISPLAY 'LK-GE053-SQLERRMC   ' LK-GE053-SQLERRMC */
                    _.Display($"LK-GE053-SQLERRMC   {SPGE053W.LK_GE053_SQLERRMC}");

                    /*" -3821- DISPLAY 'LK-GE053-SQLSTATE   ' LK-GE053-SQLSTATE */
                    _.Display($"LK-GE053-SQLSTATE   {SPGE053W.LK_GE053_SQLSTATE}");

                    /*" -3822- END-IF */
                }


                /*" -3823- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3824- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3826- END-IF. */
            }


            /*" -3827- IF LK-GE053-I-NUM-PROPOSTA NOT EQUAL ZERO */

            if (SPGE053W.LK_GE053_I_NUM_PROPOSTA != 00)
            {

                /*" -3828- MOVE 'D' TO RSD-TIPO-REG */
                _.Move("D", LXFPF028.REG_TIPO_D.RSD_TIPO_REG);

                /*" -3829- MOVE LK-GE053-I-NUM-PROPOSTA TO RSD-NUM-PROPOSTA */
                _.Move(SPGE053W.LK_GE053_I_NUM_PROPOSTA, LXFPF028.REG_TIPO_D.RSD_NUM_PROPOSTA);

                /*" -3830- MOVE LK-GE053-I-NOM-SOCIAL TO RSD-NOME-SOCIAL */
                _.Move(SPGE053W.LK_GE053_I_NOM_SOCIAL, LXFPF028.REG_TIPO_D.RSD_NOME_SOCIAL);

                /*" -3831- MOVE SPACES TO RSD-FILLER */
                _.Move("", LXFPF028.REG_TIPO_D.RSD_FILLER);

                /*" -3832- WRITE REG-PRP-BILHETE FROM REG-TIPO-D */
                _.Move(LXFPF028.REG_TIPO_D.GetMoveValues(), REG_PRP_BILHETE);

                MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

                /*" -3832- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -3842- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3843- MOVE 'WRITE REG-TRAILLER' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3845- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3848- MOVE SPACES TO REG-TRAILLER, REG-PRP-BILHETE */
            _.Move("", LBFPF991.REG_TRAILLER, REG_PRP_BILHETE);

            /*" -3851- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -3854- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -3857- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -3860- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -3863- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -3866- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -3869- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -3872- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -3875- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -3878- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -3881- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -3884- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -3887- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -3890- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -3893- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -3896- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -3899- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -3902- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -3905- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -3908- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -3911- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -3914- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -3936- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 + RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9 + RT-QTDE-TIPO-A + RT-QTDE-TIPO-B + RT-QTDE-TIPO-C + RT-QTDE-TIPO-D + RT-QTDE-TIPO-E + RT-QTDE-TIPO-F + RT-QTDE-TIPO-G + RT-QTDE-TIPO-H + RT-QTDE-TIPO-I + RT-QTDE-TIPO-J. */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -3936- WRITE REG-PRP-BILHETE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_BILHETE);

            MOVTO_PRP_BILHETE.Write(REG_PRP_BILHETE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -3950- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3951- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3953- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3956- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -3958- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -3962- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -3965- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -3973- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -3976- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3977- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -3978- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -3980- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -3982- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -3984- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -3986- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -3988- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -3989- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3989- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -3973- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_SAIDA*/

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -4000- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4001- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4003- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4023- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

            /*" -4024- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4025- DISPLAY 'PF0617B - TOTAIS DO PROCESSAMENTO' . */
            _.Display($"PF0617B - TOTAIS DO PROCESSAMENTO");

            /*" -4027- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL. */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -4028- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4029- DISPLAY '          TOTAL REGISTROS GERADOS PRPSASSE' . */
            _.Display($"          TOTAL REGISTROS GERADOS PRPSASSE");

            /*" -4031- DISPLAY '          TOTAL REGISTROS TP-1............ ' W-QTD-LD-TIPO-1. */
            _.Display($"          TOTAL REGISTROS TP-1............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -4033- DISPLAY '          TOTAL REGISTROS TP-2............ ' W-QTD-LD-TIPO-2. */
            _.Display($"          TOTAL REGISTROS TP-2............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -4035- DISPLAY '          TOTAL REGISTROS TP-3............ ' W-QTD-LD-TIPO-3. */
            _.Display($"          TOTAL REGISTROS TP-3............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -4037- DISPLAY '          TOTAL REGISTROS TP-4............ ' W-QTD-LD-TIPO-4. */
            _.Display($"          TOTAL REGISTROS TP-4............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -4039- DISPLAY '          TOTAL REGISTROS TP-C............ ' W-QTD-LD-TIPO-C. */
            _.Display($"          TOTAL REGISTROS TP-C............ {WAREA_AUXILIAR.W_QTD_LD_TIPO_C}");

            /*" -4041- DISPLAY '          TOTAL GERAL..................... ' W-TOT-GERADO-PRP. */
            _.Display($"          TOTAL GERAL..................... {WAREA_AUXILIAR.W_TOT_GERADO_PRP}");

            /*" -4043- DISPLAY '          TOTAL PROPOSTAS DESPREZADAS..... ' W-TOT-DESPREZADO. */
            _.Display($"          TOTAL PROPOSTAS DESPREZADAS..... {WAREA_AUXILIAR.W_TOT_DESPREZADO}");

            /*" -4045- DISPLAY '          TOTAL PROPOFID INSERIDAS 1...... ' WS-IN-PROPOFID1 */
            _.Display($"          TOTAL PROPOFID INSERIDAS 1...... {WS_IN_PROPOFID1}");

            /*" -4046- DISPLAY '          TOTAL PROPOFID INSERIDAS 2...... ' WS-IN-PROPOFID2. */
            _.Display($"          TOTAL PROPOFID INSERIDAS 2...... {WS_IN_PROPOFID2}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-SECTION */
        private void R1110_00_UPDATE_RELATORIOS_SECTION()
        {
            /*" -4054- MOVE 'R1110-00-UPDATE-RELATORIOS' TO PARAGRAFO. */
            _.Move("R1110-00-UPDATE-RELATORIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4055- MOVE 'FETCH DECLARE DTHBILHETE' TO COMANDO. */
            _.Move("FETCH DECLARE DTHBILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4056- MOVE SPACES TO WS-DTH-BILHETE. */
            _.Move("", WAREA_AUXILIAR.WS_DTH_BILHETE);

            /*" -4083- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4090- PERFORM R1110_00_UPDATE_RELATORIOS_DB_SELECT_1 */

            R1110_00_UPDATE_RELATORIOS_DB_SELECT_1();

            /*" -4093- IF WS-DIA-SEMANA = '5' */

            if (WAREA_AUXILIAR.WS_DIA_SEMANA == "5")
            {

                /*" -4094- PERFORM R1120-00-BUSCA-MENOR-DATA */

                R1120_00_BUSCA_MENOR_DATA_SECTION();

                /*" -4095- IF WS-DTH-BILHETE NOT EQUAL SPACES */

                if (!WAREA_AUXILIAR.WS_DTH_BILHETE.IsEmpty())
                {

                    /*" -4097- MOVE WS-DTH-BILHETE TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
                    _.Move(WAREA_AUXILIAR.WS_DTH_BILHETE, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                    /*" -4098- ELSE */
                }
                else
                {


                    /*" -4100- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
                    _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                    /*" -4101- END-IF */
                }


                /*" -4102- ELSE */
            }
            else
            {


                /*" -4104- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

                /*" -4107- END-IF. */
            }


            /*" -4108- DISPLAY '------------------------------------------' */
            _.Display($"------------------------------------------");

            /*" -4117- DISPLAY ' DT-MOV-ABERTO ' WS-SISTEMA-DATA-MOV-ABERTO ' DT-REFERENCIA ' WS-RELATORI-DATA-REFERENCIA ' WS-DTH-BILHETE' WS-DTH-BILHETE */

            $" DT-MOV-ABERTO {WS_SISTEMA_DATA_MOV_ABERTO} DT-REFERENCIA {WS_RELATORI_DATA_REFERENCIA} WS-DTH-BILHETE{WAREA_AUXILIAR.WS_DTH_BILHETE}"
            .Display();

            /*" -4118- DISPLAY '-----------------------------------------' */
            _.Display($"-----------------------------------------");

            /*" -4120- DISPLAY 'DATA-REFERENCIA ' RELATORI-DATA-REFERENCIA OF DCLRELATORIOS */
            _.Display($"DATA-REFERENCIA {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

            /*" -4122- DISPLAY '-----------------------------------------' */
            _.Display($"-----------------------------------------");

            /*" -4124- MOVE 'UPDATE RELATORIOS' TO COMANDO. */
            _.Move("UPDATE RELATORIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4131- PERFORM R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1 */

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1();

            /*" -4134- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4135- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4136- DISPLAY '          ERRO UPDATE RELATORIOS' */
                _.Display($"          ERRO UPDATE RELATORIOS");

                /*" -4138- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -4139- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4139- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-DB-SELECT-1 */
        public void R1110_00_UPDATE_RELATORIOS_DB_SELECT_1()
        {
            /*" -4090- EXEC SQL SELECT DIA_SEMANA INTO :WS-DIA-SEMANA FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var r1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1 = new R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1.Execute(r1110_00_UPDATE_RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DIA_SEMANA, WAREA_AUXILIAR.WS_DIA_SEMANA);
            }


        }

        [StopWatch]
        /*" R1110-00-UPDATE-RELATORIOS-DB-UPDATE-1 */
        public void R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1()
        {
            /*" -4131- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :DCLRELATORIOS.RELATORI-DATA-REFERENCIA, TIMESTAMP = CURRENT TIMESTAMP WHERE IDE_SISTEMA = 'PF' AND COD_RELATORIO = 'PF0617B' END-EXEC. */

            var r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 = new R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1.Execute(r1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_SAIDA*/

        [StopWatch]
        /*" R1120-00-BUSCA-MENOR-DATA-SECTION */
        private void R1120_00_BUSCA_MENOR_DATA_SECTION()
        {
            /*" -4149- MOVE '01' TO W-DIA-DATA-REF. */
            _.Move("01", WAREA_AUXILIAR.W_WHOST_DATA_REF_M1YEAR.W_DIA_DATA_REF);

            /*" -4152- MOVE '01' TO W-MES-DATA-REF. */
            _.Move("01", WAREA_AUXILIAR.W_WHOST_DATA_REF_M1YEAR.W_MES_DATA_REF);

            /*" -4168- PERFORM R1120_00_BUSCA_MENOR_DATA_DB_DECLARE_1 */

            R1120_00_BUSCA_MENOR_DATA_DB_DECLARE_1();

            /*" -4170- PERFORM R1120_00_BUSCA_MENOR_DATA_DB_OPEN_1 */

            R1120_00_BUSCA_MENOR_DATA_DB_OPEN_1();

            /*" -4175- PERFORM R1120_00_BUSCA_MENOR_DATA_DB_FETCH_1 */

            R1120_00_BUSCA_MENOR_DATA_DB_FETCH_1();

            /*" -4178- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4179- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4180- DISPLAY '          ERRO FETCH DECLARE  ' */
                _.Display($"          ERRO FETCH DECLARE  ");

                /*" -4182- DISPLAY '          DTHBILHETE............. ' SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS */
                _.Display($"          DTHBILHETE............. {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA}");

                /*" -4184- DISPLAY '          WHOST-DATA-REF-CURSOR...' WHOST-DATA-REF-CURSOR */
                _.Display($"          WHOST-DATA-REF-CURSOR...{WAREA_AUXILIAR.WHOST_DATA_REF_CURSOR}");

                /*" -4186- DISPLAY '          WHOST-DATA-REF-M1YEAR...' WHOST-DATA-REF-M1YEAR */
                _.Display($"          WHOST-DATA-REF-M1YEAR...{WAREA_AUXILIAR.WHOST_DATA_REF_M1YEAR}");

                /*" -4188- DISPLAY '          SQLCODE.................' SQLCODE */
                _.Display($"          SQLCODE.................{DB.SQLCODE}");

                /*" -4191- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -4191- PERFORM R1120_00_BUSCA_MENOR_DATA_DB_CLOSE_1 */

            R1120_00_BUSCA_MENOR_DATA_DB_CLOSE_1();

        }

        [StopWatch]
        /*" R1120-00-BUSCA-MENOR-DATA-DB-OPEN-1 */
        public void R1120_00_BUSCA_MENOR_DATA_DB_OPEN_1()
        {
            /*" -4170- EXEC SQL OPEN DTHBILHETE END-EXEC. */

            DTHBILHETE.Open();

        }

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R3136_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -4774- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0617B_EMAIL(true);
            string GetQuery_EMAIL()
            {
                var query = @$"SELECT COD_PESSOA
							, 
							SEQ_EMAIL
							, 
							EMAIL
							, 
							SITUACAO_EMAIL 
							FROM SEGUROS.PESSOA_EMAIL 
							WHERE COD_PESSOA = '{PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}' 
							ORDER BY SEQ_EMAIL";

                return query;
            }
            EMAIL.GetQueryEvent += GetQuery_EMAIL;

        }

        [StopWatch]
        /*" R1120-00-BUSCA-MENOR-DATA-DB-FETCH-1 */
        public void R1120_00_BUSCA_MENOR_DATA_DB_FETCH_1()
        {
            /*" -4175- EXEC SQL FETCH DTHBILHETE INTO :WS-DTH-BILHETE END-EXEC. */

            if (DTHBILHETE.Fetch())
            {
                _.Move(DTHBILHETE.WS_DTH_BILHETE, WAREA_AUXILIAR.WS_DTH_BILHETE);
            }

        }

        [StopWatch]
        /*" R1120-00-BUSCA-MENOR-DATA-DB-CLOSE-1 */
        public void R1120_00_BUSCA_MENOR_DATA_DB_CLOSE_1()
        {
            /*" -4191- EXEC SQL CLOSE DTHBILHETE END-EXEC. */

            DTHBILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_SAIDA*/

        [StopWatch]
        /*" R3000-GERAR-TB-CORPORATIVAS-SECTION */
        private void R3000_GERAR_TB_CORPORATIVAS_SECTION()
        {
            /*" -4203- PERFORM R3100-TRATA-CLIENTE. */

            R3100_TRATA_CLIENTE_SECTION();

            /*" -4204- PERFORM R3200-TRATA-END-TEL. */

            R3200_TRATA_END_TEL_SECTION();

            /*" -4204- PERFORM R3300-TRATA-PROPOSTA. */

            R3300_TRATA_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R3050-MUDA-SITUACAO-ENVIO-SECTION */
        private void R3050_MUDA_SITUACAO_ENVIO_SECTION()
        {
            /*" -4214- MOVE 'R3050-MUDA-SITUACAO-ENVIO' TO PARAGRAFO. */
            _.Move("R3050-MUDA-SITUACAO-ENVIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4215- MOVE 'UPDATE PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA_FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4217- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4219- MOVE BILHETE-NUM-BILHETE TO PROPOFID-NUM-SICOB. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -4223- PERFORM R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1 */

            R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1();

            /*" -4226- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4227- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4228- DISPLAY '          ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -4229- DISPLAY 'PROPOFID-NUM-SICOB:' PROPOFID-NUM-SICOB */
                _.Display($"PROPOFID-NUM-SICOB:{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                /*" -4231- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -4232- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4232- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3050-MUDA-SITUACAO-ENVIO-DB-UPDATE-1 */
        public void R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1()
        {
            /*" -4223- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'S' WHERE NUM_SICOB = :PROPOFID-NUM-SICOB END-EXEC. */

            var r3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1 = new R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            R3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1.Execute(r3050_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_SAIDA*/

        [StopWatch]
        /*" R3055-MUDA-SITUACAO-ENVIO-SECTION */
        private void R3055_MUDA_SITUACAO_ENVIO_SECTION()
        {
            /*" -4240- MOVE 'R3055-MUDA-SITUACAO-ENVIO' TO PARAGRAFO. */
            _.Move("R3055-MUDA-SITUACAO-ENVIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4241- MOVE 'UPDATE PROPOSTA_FIDELIZ' TO COMANDO. */
            _.Move("UPDATE PROPOSTA_FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4243- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4246- MOVE NUM-PROPOSTA-SIVPF OF DCLCONVERSAO-SICOB TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -4251- PERFORM R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1 */

            R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1();

            /*" -4254- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4255- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4256- DISPLAY '          ERRO UPDATE PROPOSTA_FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA_FIDELIZ");

                /*" -4258- DISPLAY 'PROPOFID-NUM-PROPOSTA-SIVPF:' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"PROPOFID-NUM-PROPOSTA-SIVPF:{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -4259- DISPLAY 'SITUACAO_ENVIO:' 'S' */
                _.Display($"SITUACAO_ENVIO:S");

                /*" -4260- DISPLAY 'SIT_PROPOSTA..:' 'EMT' */
                _.Display($"SIT_PROPOSTA..:EMT");

                /*" -4262- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -4263- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4263- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3055-MUDA-SITUACAO-ENVIO-DB-UPDATE-1 */
        public void R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1()
        {
            /*" -4251- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'S' , SIT_PROPOSTA = 'EMT' WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1 = new R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            R3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1.Execute(r3055_MUDA_SITUACAO_ENVIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3055_SAIDA*/

        [StopWatch]
        /*" R3100-TRATA-CLIENTE-SECTION */
        private void R3100_TRATA_CLIENTE_SECTION()
        {
            /*" -4273- MOVE 'R3100-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R3100-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4274- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4284- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4285- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4286- PERFORM R3105-LER-PESSOA-FISICA */

                R3105_LER_PESSOA_FISICA_SECTION();

                /*" -4287- ELSE */
            }
            else
            {


                /*" -4289- PERFORM R3110-LER-PESSOA-JURIDICA. */

                R3110_LER_PESSOA_JURIDICA_SECTION();
            }


            /*" -4290- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -4291- PERFORM R3115-INCLUIR-TAB-CORPORATIVAS */

                R3115_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -4292- ELSE */
            }
            else
            {


                /*" -4293- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -4296- PERFORM R3150-LER-TAB-CORPORATIVAS */

                    R3150_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -4296- PERFORM R3135-INCLUIR-END-EMAIL. */

                    R3135_INCLUIR_END_EMAIL_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/

        [StopWatch]
        /*" R3105-LER-PESSOA-FISICA-SECTION */
        private void R3105_LER_PESSOA_FISICA_SECTION()
        {
            /*" -4306- MOVE 'R3105-LER-PESSOA-FISICA' TO PARAGRAFO. */
            _.Move("R3105-LER-PESSOA-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4307- MOVE 'SELECT PESSOA_FISICA' TO COMANDO. */
            _.Move("SELECT PESSOA_FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4309- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4312- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -4313- IF R1-DATA-NASCIMENTO OF REG-CLIENTES EQUAL ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO == 00)
            {

                /*" -4315- MOVE '0001-01-01' TO DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Move("0001-01-01", PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

                /*" -4316- ELSE */
            }
            else
            {


                /*" -4318- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

                /*" -4320- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -4322- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -4325- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -4329- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -4332- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
            }


            /*" -4333- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -4335- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -4336- ELSE */
            }
            else
            {


                /*" -4339- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -4371- PERFORM R3105_LER_PESSOA_FISICA_DB_SELECT_1 */

            R3105_LER_PESSOA_FISICA_DB_SELECT_1();

            /*" -4374- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4375- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4376- DISPLAY '          ERRO NO ACESSO A PESSOA-FISICA  ' */
                _.Display($"          ERRO NO ACESSO A PESSOA-FISICA  ");

                /*" -4378- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4380- DISPLAY '          CPF...........................  ' CPF OF DCLPESSOA-FISICA */
                _.Display($"          CPF...........................  {PESFIS.DCLPESSOA_FISICA.CPF}");

                /*" -4382- DISPLAY '          DATA NASCIMENTO...............  ' DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Display($"          DATA NASCIMENTO...............  {PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO}");

                /*" -4384- DISPLAY '          SEXO..........................  ' SEXO OF DCLPESSOA-FISICA */
                _.Display($"          SEXO..........................  {PESFIS.DCLPESSOA_FISICA.SEXO}");

                /*" -4386- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4387- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4387- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3105-LER-PESSOA-FISICA-DB-SELECT-1 */
        public void R3105_LER_PESSOA_FISICA_DB_SELECT_1()
        {
            /*" -4371- EXEC SQL SELECT COD_PESSOA, CPF, DATA_NASCIMENTO, SEXO, TIPO_IDENT_SIVPF, NUM_IDENTIDADE, ORGAO_EXPEDIDOR, UF_EXPEDIDORA, DATA_EXPEDICAO, COD_CBO, COD_USUARIO, ESTADO_CIVIL, TIMESTAMP INTO :DCLPESSOA-FISICA.COD-PESSOA:VIND-COD-PESSOA, :DCLPESSOA-FISICA.CPF:VIND-CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO:VIND-DTNASCI, :DCLPESSOA-FISICA.SEXO:VIND-SEXO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF:VIND-TP-IDENT, :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NUM-IDENT, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-ORGAO-EXP, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UF-EXP, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO:VIND-COD-CBO, :DCLPESSOA-FISICA.COD-USUARIO:VIND-COD-USUR, :DCLPESSOA-FISICA.ESTADO-CIVIL, :DCLPESSOA-FISICA.TIMESTAMP:VIND-TIMESTAMP FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO WITH UR END-EXEC. */

            var r3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1 = new R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1()
            {
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = R3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1.Execute(r3105_LER_PESSOA_FISICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);
                _.Move(executed_1.VIND_COD_PESSOA, VIND_COD_PESSOA);
                _.Move(executed_1.CPF, PESFIS.DCLPESSOA_FISICA.CPF);
                _.Move(executed_1.VIND_CPF, VIND_CPF);
                _.Move(executed_1.DATA_NASCIMENTO, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
                _.Move(executed_1.SEXO, PESFIS.DCLPESSOA_FISICA.SEXO);
                _.Move(executed_1.VIND_SEXO, VIND_SEXO);
                _.Move(executed_1.TIPO_IDENT_SIVPF, PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);
                _.Move(executed_1.VIND_TP_IDENT, VIND_TP_IDENT);
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.VIND_NUM_IDENT, VIND_NUM_IDENT);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.VIND_ORGAO_EXP, VIND_ORGAO_EXP);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UF_EXP, VIND_UF_EXP);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DTEXPEDI, VIND_DTEXPEDI);
                _.Move(executed_1.COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);
                _.Move(executed_1.VIND_COD_CBO, VIND_COD_CBO);
                _.Move(executed_1.COD_USUARIO, PESFIS.DCLPESSOA_FISICA.COD_USUARIO);
                _.Move(executed_1.VIND_COD_USUR, VIND_COD_USUR);
                _.Move(executed_1.ESTADO_CIVIL, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                _.Move(executed_1.TIMESTAMP, PESFIS.DCLPESSOA_FISICA.TIMESTAMP);
                _.Move(executed_1.VIND_TIMESTAMP, VIND_TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3105_SAIDA*/

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-SECTION */
        private void R3110_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -4397- MOVE 'R3110-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R3110-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4398- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4400- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4403- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -4417- PERFORM R3110_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R3110_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -4420- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -4421- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4422- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -4424- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4426- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4427- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4427- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R3110_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -4417- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

            var r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
                _.Move(executed_1.CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);
                _.Move(executed_1.NOME_FANTASIA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);
                _.Move(executed_1.COD_USUARIO, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESJUR.DCLPESSOA_JURIDICA.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_SAIDA*/

        [StopWatch]
        /*" R3115-INCLUIR-TAB-CORPORATIVAS-SECTION */
        private void R3115_INCLUIR_TAB_CORPORATIVAS_SECTION()
        {
            /*" -4436- MOVE 'R3115-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3115-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4437- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4439- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4441- PERFORM R3120-INCLUIR-TAB-PESSOA. */

            R3120_INCLUIR_TAB_PESSOA_SECTION();

            /*" -4442- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4443- PERFORM R3125-INCLUIR-PESSOA-FISICA */

                R3125_INCLUIR_PESSOA_FISICA_SECTION();

                /*" -4444- ELSE */
            }
            else
            {


                /*" -4446- PERFORM R3130-INCLUIR-PESSOA-JURIDICA. */

                R3130_INCLUIR_PESSOA_JURIDICA_SECTION();
            }


            /*" -4446- PERFORM R3135-INCLUIR-END-EMAIL. */

            R3135_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3115_SAIDA*/

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-SECTION */
        private void R3120_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -4456- MOVE 'R3120-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R3120-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4457- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4459- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4460- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -4461- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -4463- PERFORM R3121-OBTER-MAX-COD-PESSOA. */

                R3121_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -4466- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -4469- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -4472- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -4475- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -4476- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4478- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -4479- ELSE */
            }
            else
            {


                /*" -4480- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -4483- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -4486- MOVE 'PF0617B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0617B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -4494- PERFORM R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -4497- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4498- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4499- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -4501- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4503- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -4505- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4507- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4508- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4508- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -4494- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

            var r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 = new R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1.Execute(r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_SAIDA*/

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-SECTION */
        private void R3121_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -4518- MOVE 'R3121-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R3121-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4519- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4521- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4526- PERFORM R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -4529- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4530- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4531- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -4533- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4535- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4536- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4538- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -4539- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -4526- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3121_SAIDA*/

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-SECTION */
        private void R3125_INCLUIR_PESSOA_FISICA_SECTION()
        {
            /*" -4549- MOVE 'R3125-INCLUIR-PESSOAS-FISICA' TO PARAGRAFO. */
            _.Move("R3125-INCLUIR-PESSOAS-FISICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4550- MOVE 'INSERT PESSOA-FISICA' TO COMANDO. */
            _.Move("INSERT PESSOA-FISICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4552- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4555- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-FISICA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFIS.DCLPESSOA_FISICA.COD_PESSOA);

            /*" -4559- MOVE R1-CGC-CPF OF REG-CLIENTES TO CPF OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -4560- IF VIND-DTNASCI LESS ZEROS */

            if (VIND_DTNASCI < 00)
            {

                /*" -4562- MOVE '0001-01-01' TO DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Move("0001-01-01", PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

                /*" -4563- ELSE */
            }
            else
            {


                /*" -4565- MOVE R1-DATA-NASCIMENTO OF REG-CLIENTES TO W-DATA-NASCIMENTO */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_NASCIMENTO);

                /*" -4567- MOVE W-DIA-NASCIMENTO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_DIA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -4569- MOVE W-MES-NASCIMENTO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_MES_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -4572- MOVE W-ANO-NASCIMENTO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_5.W_ANO_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -4576- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -4579- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLPESSOA-FISICA. */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);
            }


            /*" -4580- IF R1-IDE-SEXO OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_IDE_SEXO == 1)
            {

                /*" -4582- MOVE 'M' TO SEXO OF DCLPESSOA-FISICA */
                _.Move("M", PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -4583- ELSE */
            }
            else
            {


                /*" -4586- MOVE 'F' TO SEXO OF DCLPESSOA-FISICA. */
                _.Move("F", PESFIS.DCLPESSOA_FISICA.SEXO);
            }


            /*" -4589- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA. */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -4592- MOVE R1-NUM-IDENTIDADE OF REG-CLIENTES TO NUM-IDENTIDADE OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -4595- MOVE R1-ORGAO-EXPEDIDOR OF REG-CLIENTES TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

            /*" -4598- MOVE R1-UF-EXPEDIDORA OF REG-CLIENTES TO UF-EXPEDIDORA OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

            /*" -4599- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 1)
            {

                /*" -4601- MOVE 'S' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("S", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -4602- ELSE */
            }
            else
            {


                /*" -4603- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 2)
                {

                    /*" -4605- MOVE 'C' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                    _.Move("C", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                    /*" -4606- ELSE */
                }
                else
                {


                    /*" -4607- IF R1-ESTADO-CIVIL OF REG-CLIENTES EQUAL 3 */

                    if (LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL == 3)
                    {

                        /*" -4609- MOVE 'V' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                        _.Move("V", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                        /*" -4610- ELSE */
                    }
                    else
                    {


                        /*" -4613- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA. */
                        _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);
                    }

                }

            }


            /*" -4614- IF R1-DATA-EXPEDICAO-RG OF REG-CLIENTES GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG > 00)
            {

                /*" -4617- MOVE R1-DATA-EXPEDICAO-RG OF REG-CLIENTES TO W-DATA-TRABALHO */
                _.Move(LBFPF011.REG_CLIENTES.R1_DATA_EXPEDICAO_RG, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -4619- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -4621- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -4624- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -4628- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1 W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -4630- MOVE W-DATA-SQL TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                /*" -4631- ELSE */
            }
            else
            {


                /*" -4633- MOVE -1 TO VIND-DTEXPEDI. */
                _.Move(-1, VIND_DTEXPEDI);
            }


            /*" -4636- MOVE R1-COD-CBO OF REG-CLIENTES TO COD-CBO OF DCLPESSOA-FISICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -4639- MOVE 'PF0617B' TO COD-USUARIO OF DCLPESSOA-FISICA. */
            _.Move("PF0617B", PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -4654- PERFORM R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1 */

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1();

            /*" -4657- IF SQLCODE EQUAL -530 */

            if (DB.SQLCODE == -530)
            {

                /*" -4660- MOVE ZEROS TO COD-CBO OF DCLPESSOA-FISICA */
                _.Move(0, PESFIS.DCLPESSOA_FISICA.COD_CBO);

                /*" -4675- PERFORM R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2 */

                R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2();

                /*" -4677- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -4678- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -4679- DISPLAY '          ERRO INSERT TABELA PES. FISICA - 1' */
                    _.Display($"          ERRO INSERT TABELA PES. FISICA - 1");

                    /*" -4681- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                    _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                    /*" -4683- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -4685- DISPLAY '          COD-CBO.......................  ' COD-CBO OF DCLPESSOA-FISICA */
                    _.Display($"          COD-CBO.......................  {PESFIS.DCLPESSOA_FISICA.COD_CBO}");

                    /*" -4687- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4688- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4689- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -4691- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -4692- ELSE */
                }

            }
            else
            {


                /*" -4693- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -4694- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -4695- DISPLAY '          ERRO INSERT TABELA PES. FISICA - 2' */
                    _.Display($"          ERRO INSERT TABELA PES. FISICA - 2");

                    /*" -4697- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-FISICA */
                    _.Display($"          CODIGO PESSOA.................  {PESFIS.DCLPESSOA_FISICA.COD_PESSOA}");

                    /*" -4699- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -4701- DISPLAY '          COD-CBO.......................  ' COD-CBO OF DCLPESSOA-FISICA */
                    _.Display($"          COD-CBO.......................  {PESFIS.DCLPESSOA_FISICA.COD_CBO}");

                    /*" -4703- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4704- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4704- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-DB-INSERT-1 */
        public void R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -4654- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC. */

            var r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1 = new R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                VIND_DTEXPEDI = VIND_DTEXPEDI.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                TIPO_IDENT_SIVPF = PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF.ToString(),
            };

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3125_SAIDA*/

        [StopWatch]
        /*" R3125-INCLUIR-PESSOA-FISICA-DB-INSERT-2 */
        public void R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2()
        {
            /*" -4675- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:DCLPESSOA-FISICA.COD-PESSOA, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC */

            var r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1 = new R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1()
            {
                COD_PESSOA = PESFIS.DCLPESSOA_FISICA.COD_PESSOA.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                VIND_DTEXPEDI = VIND_DTEXPEDI.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                TIPO_IDENT_SIVPF = PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF.ToString(),
            };

            R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1.Execute(r3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R3130_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -4713- MOVE 'R3130-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R3130-INCLUIR-PESSOAS-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4714- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4716- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4719- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -4722- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -4725- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -4729- MOVE 'PF0617B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0617B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -4736- PERFORM R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -4739- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4740- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4741- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -4743- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -4745- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4747- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4748- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4748- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -4736- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_SAIDA*/

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-SECTION */
        private void R3136_RELACIONA_EMAIL_SECTION()
        {
            /*" -4758- MOVE 'R3136-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R3136-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4759- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4761- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4764- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4774- PERFORM R3136_RELACIONA_EMAIL_DB_DECLARE_1 */

            R3136_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -4778- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4779- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4780- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -4782- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4784- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4786- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4787- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4787- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3136_SAIDA*/

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-SECTION */
        private void R3135_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -4796- MOVE 'R3135-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R3135-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4797- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4799- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4801- PERFORM R3136-RELACIONA-EMAIL. */

            R3136_RELACIONA_EMAIL_SECTION();

            /*" -4803- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4803- PERFORM R3135_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R3135_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -4807- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -4809- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -4811- PERFORM R3137-FETCH-EMAIL */

            R3137_FETCH_EMAIL_SECTION();

            /*" -4812- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -4813- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -4815- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -4818- PERFORM R3138-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R3138_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -4819- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -4819- PERFORM R3139-INCLUIR-NOVO-EMAIL. */

                R3139_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R3135_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -4803- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R3205_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -5181- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0617B_ENDERECOS(true);
            string GetQuery_ENDERECOS()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							COD_PESSOA
							, 
							ENDERECO
							, 
							TIPO_ENDER
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							SITUACAO_ENDERECO 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO";

                return query;
            }
            ENDERECOS.GetQueryEvent += GetQuery_ENDERECOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3135_SAIDA*/

        [StopWatch]
        /*" R3137-FETCH-EMAIL-SECTION */
        private void R3137_FETCH_EMAIL_SECTION()
        {
            /*" -4830- MOVE 'R3137-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R3137-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4831- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4833- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4839- PERFORM R3137_FETCH_EMAIL_DB_FETCH_1 */

            R3137_FETCH_EMAIL_DB_FETCH_1();

            /*" -4842- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4843- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4844- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -4844- PERFORM R3137_FETCH_EMAIL_DB_CLOSE_1 */

                    R3137_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -4846- ELSE */
                }
                else
                {


                    /*" -4847- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -4848- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -4850- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -4852- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -4854- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4855- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4855- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-FETCH-1 */
        public void R3137_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -4839- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

            if (EMAIL.Fetch())
            {
                _.Move(EMAIL.DCLPESSOA_EMAIL_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }

        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-CLOSE-1 */
        public void R3137_FETCH_EMAIL_DB_CLOSE_1()
        {
            /*" -4844- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3137_SAIDA*/

        [StopWatch]
        /*" R3138-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R3138_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -4865- MOVE 'R3138-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R3138-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4866- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4868- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4870- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -4872- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -4873- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -4875- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -4875- PERFORM R3137-FETCH-EMAIL. */

            R3137_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3138_SAIDA*/

        [StopWatch]
        /*" R3139-INCLUIR-NOVO-EMAIL-SECTION */
        private void R3139_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -4885- MOVE 'R3139-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R3139-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4886- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4895- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4898- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -4900- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -4900- PERFORM R3141-INCLUIR-EMAIL. */

            R3141_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3139_SAIDA*/

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-SECTION */
        private void R3140_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -4910- MOVE 'R3140-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3140-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4911- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4913- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4916- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4922- PERFORM R3140_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3140_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -4925- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4926- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4927- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -4929- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4931- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4932- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4932- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3140_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -4922- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_SAIDA*/

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-SECTION */
        private void R3141_INCLUIR_EMAIL_SECTION()
        {
            /*" -4941- MOVE 'R3141-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R3141-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4942- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4944- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4947- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4950- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -4953- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -4956- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -4960- MOVE 'PF0617B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0617B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -4968- PERFORM R3141_INCLUIR_EMAIL_DB_INSERT_1 */

            R3141_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -4971- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4972- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -4973- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -4975- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4977- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -4979- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4981- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4982- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4982- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R3141_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -4968- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 = new R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1.Execute(r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3141_SAIDA*/

        [StopWatch]
        /*" R3150-LER-TAB-CORPORATIVAS-SECTION */
        private void R3150_LER_TAB_CORPORATIVAS_SECTION()
        {
            /*" -4992- MOVE 'R3150-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4993- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4995- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4996- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -4998- MOVE COD-PESSOA OF DCLPESSOA-FISICA TO PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Move(PESFIS.DCLPESSOA_FISICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

                /*" -4999- ELSE */
            }
            else
            {


                /*" -5002- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
                _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


            /*" -5004- PERFORM R3155-LER-TAB-PESSOA. */

            R3155_LER_TAB_PESSOA_SECTION();

            /*" -5004- PERFORM R3160-LER-TAB-EMAIL. */

            R3160_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_SAIDA*/

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-SECTION */
        private void R3155_LER_TAB_PESSOA_SECTION()
        {
            /*" -5014- MOVE 'R3150-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-PESSOAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5015- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5017- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5031- PERFORM R3155_LER_TAB_PESSOA_DB_SELECT_1 */

            R3155_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -5034- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5035- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5036- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -5038- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -5040- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5041- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5041- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R3155_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -5031- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1 = new R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1.Execute(r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                _.Move(executed_1.PESSOA_TIMESTAMP, PESSOA.DCLPESSOA.PESSOA_TIMESTAMP);
                _.Move(executed_1.PESSOA_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3155_SAIDA*/

        [StopWatch]
        /*" R3160-LER-TAB-EMAIL-SECTION */
        private void R3160_LER_TAB_EMAIL_SECTION()
        {
            /*" -5050- MOVE 'R3160-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R3160-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5051- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5053- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5055- PERFORM R3165-OBTER-MAX-EMAIL. */

            R3165_OBTER_MAX_EMAIL_SECTION();

            /*" -5055- PERFORM R3170-LER-EMAIL-ATUAL. */

            R3170_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_SAIDA*/

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-SECTION */
        private void R3165_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -5065- MOVE 'R3165-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3165-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5066- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5068- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5071- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -5077- PERFORM R3165_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3165_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -5080- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5081- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5082- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -5084- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -5086- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5087- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5087- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3165_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -5077- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3165_SAIDA*/

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-SECTION */
        private void R3170_LER_EMAIL_ATUAL_SECTION()
        {
            /*" -5097- MOVE 'R3170-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R3170-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5098- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5100- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5103- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -5120- PERFORM R3170_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R3170_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -5124- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5125- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5126- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -5128- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -5130- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -5132- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5133- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5133- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R3170_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -5120- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

            var r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 = new R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1.Execute(r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(executed_1.SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
                _.Move(executed_1.COD_USUARIO, PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESEMAIL.DCLPESSOA_EMAIL.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_SAIDA*/

        [StopWatch]
        /*" R3200-TRATA-END-TEL-SECTION */
        private void R3200_TRATA_END_TEL_SECTION()
        {
            /*" -5143- MOVE 'R3200-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R3200-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5144- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5146- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5148- PERFORM R3201-TRATA-ENDERECO. */

            R3201_TRATA_ENDERECO_SECTION();

            /*" -5150- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -5150- PERFORM R3250-TRATA-TELEFONES 4 TIMES. */

            for (int i = 0; i < 4; i++)
            {

                R3250_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_SAIDA*/

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-SECTION */
        private void R3205_RELACIONA_ENDERECO_SECTION()
        {
            /*" -5160- MOVE 'R3205-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3205-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5161- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5163- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5166- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -5181- PERFORM R3205_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R3205_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -5185- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -5186- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5187- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -5189- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5191- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5193- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5194- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5194- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3205_SAIDA*/

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-SECTION */
        private void R3201_TRATA_ENDERECO_SECTION()
        {
            /*" -5205- MOVE 'R3201-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3201-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5206- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5208- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5212- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -5214- PERFORM R3205-RELACIONA-ENDERECO. */

            R3205_RELACIONA_ENDERECO_SECTION();

            /*" -5216- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5216- PERFORM R3201_TRATA_ENDERECO_DB_OPEN_1 */

            R3201_TRATA_ENDERECO_DB_OPEN_1();

            /*" -5220- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -5222- MOVE SPACES TO W-FIM-CURSOR-ENDERECO. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -5224- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

            /*" -5225- IF W-FIM-CURSOR-ENDERECO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM")
            {

                /*" -5229- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

                if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
                {

                    /*" -5231- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
                }

            }


            /*" -5234- PERFORM R3215-VERIFICA-EXISTE-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R3215_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -5235- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -5235- PERFORM R3220-INCLUIR-NOVO-ENDERECO. */

                R3220_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-DB-OPEN-1 */
        public void R3201_TRATA_ENDERECO_DB_OPEN_1()
        {
            /*" -5216- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3201_SAIDA*/

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-SECTION */
        private void R3210_FETCH_ENDERECO_SECTION()
        {
            /*" -5245- MOVE 'R3210-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R3210-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5246- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5248- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5259- PERFORM R3210_FETCH_ENDERECO_DB_FETCH_1 */

            R3210_FETCH_ENDERECO_DB_FETCH_1();

            /*" -5262- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5263- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5264- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -5264- PERFORM R3210_FETCH_ENDERECO_DB_CLOSE_1 */

                    R3210_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -5266- ELSE */
                }
                else
                {


                    /*" -5267- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -5268- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -5270- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -5272- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -5274- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5275- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5275- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-FETCH-1 */
        public void R3210_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -5259- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

            if (ENDERECOS.Fetch())
            {
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SITUACAO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);
            }

        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R3210_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -5264- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_SAIDA*/

        [StopWatch]
        /*" R3215-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R3215_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -5285- MOVE 'R3215-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R3215-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5286- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5288- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5300- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-BAIRRO OF REG-ENDERECO EQUAL BAIRRO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_BAIRRO == PESENDER.DCLPESSOA_ENDERECO.BAIRRO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -5302- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -5306- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-BAIRRO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_BAIRRO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -5308- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -5308- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_SAIDA*/

        [StopWatch]
        /*" R3220-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R3220_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -5318- MOVE 'R3220-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R3220-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5319- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5327- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5330- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -5332- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -5332- PERFORM R3230-INCLUIR-ENDERECO. */

            R3230_INCLUIR_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_SAIDA*/

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-SECTION */
        private void R3225_OBTER_MAX_ENDERECO_SECTION()
        {
            /*" -5342- MOVE 'R3225-OBTER-MAX-ENDERECO' TO PARAGRAFO. */
            _.Move("R3225-OBTER-MAX-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5343- MOVE 'MAX SEGUROS.PESSOA_ENDERECO' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5345- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5349- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -5355- PERFORM R3225_OBTER_MAX_ENDERECO_DB_SELECT_1 */

            R3225_OBTER_MAX_ENDERECO_DB_SELECT_1();

            /*" -5358- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5359- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5360- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-ENDERECO' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-ENDERECO");

                /*" -5362- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5364- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5366- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5367- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5367- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-DB-SELECT-1 */
        public void R3225_OBTER_MAX_ENDERECO_DB_SELECT_1()
        {
            /*" -5355- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA WITH UR END-EXEC. */

            var r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1 = new R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
            };

            var executed_1 = R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1.Execute(r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3225_SAIDA*/

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-SECTION */
        private void R3230_INCLUIR_ENDERECO_SECTION()
        {
            /*" -5377- MOVE 'R3230-INCLUI-ENDERECO' TO PARAGRAFO. */
            _.Move("R3230-INCLUI-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5378- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5380- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5383- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -5386- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -5389- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -5392- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -5395- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -5398- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -5401- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -5404- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -5407- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -5410- MOVE 'PF0617B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0617B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -5424- PERFORM R3230_INCLUIR_ENDERECO_DB_INSERT_1 */

            R3230_INCLUIR_ENDERECO_DB_INSERT_1();

            /*" -5427- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5428- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5429- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -5431- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -5433- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5435- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5436- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5436- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-DB-INSERT-1 */
        public void R3230_INCLUIR_ENDERECO_DB_INSERT_1()
        {
            /*" -5424- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1 = new R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1.Execute(r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_SAIDA*/

        [StopWatch]
        /*" R3250-TRATA-TELEFONES-SECTION */
        private void R3250_TRATA_TELEFONES_SECTION()
        {
            /*" -5446- MOVE 'R3250-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R3250-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5447- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5449- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5451- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -5453- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -5454- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -5455- PERFORM R3255-LER-TELEFONE */

                R3255_LER_TELEFONE_SECTION();

                /*" -5456- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -5456- PERFORM R3260-INCLUIR-NOVO-TELEFONE. */

                    R3260_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_SAIDA*/

        [StopWatch]
        /*" R3255-LER-TELEFONE-SECTION */
        private void R3255_LER_TELEFONE_SECTION()
        {
            /*" -5467- MOVE 'R3255-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R3255-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5468- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5470- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5476- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -5482- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -5490- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -5493- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -5502- PERFORM R3255_LER_TELEFONE_DB_SELECT_1 */

            R3255_LER_TELEFONE_DB_SELECT_1();

            /*" -5505- IF SQLCODE EQUAL 00 OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -5506- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -5507- ELSE */
            }
            else
            {


                /*" -5508- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5509- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -5510- ELSE */
                }
                else
                {


                    /*" -5511- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -5512- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -5514- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -5516- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -5518- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5519- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5519- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3255-LER-TELEFONE-DB-SELECT-1 */
        public void R3255_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -5502- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

            var r3255_LER_TELEFONE_DB_SELECT_1_Query1 = new R3255_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R3255_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r3255_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3255_SAIDA*/

        [StopWatch]
        /*" R3260-INCLUIR-NOVO-TELEFONE-SECTION */
        private void R3260_INCLUIR_NOVO_TELEFONE_SECTION()
        {
            /*" -5529- MOVE 'R3260-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R3260-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5530- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5532- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5534- PERFORM R3265-OBTER-MAX-TELEFONE. */

            R3265_OBTER_MAX_TELEFONE_SECTION();

            /*" -5537- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -5539- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -5539- PERFORM R3270-INCLUIR-TELEFONE. */

            R3270_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_SAIDA*/

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-SECTION */
        private void R3265_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -5549- MOVE 'R3265-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R3265-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5550- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5552- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5558- PERFORM R3265_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R3265_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -5561- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5562- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5563- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -5565- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -5567- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5569- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5570- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5570- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R3265_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -5558- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

            var r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1 = new R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1.Execute(r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3265_SAIDA*/

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-SECTION */
        private void R3270_INCLUIR_TELEFONE_SECTION()
        {
            /*" -5580- MOVE 'R3270-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R3270-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5581- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5583- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5587- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -5590- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -5593- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -5596- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -5599- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -5602- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -5605- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -5608- MOVE 'PF0617B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0617B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -5619- PERFORM R3270_INCLUIR_TELEFONE_DB_INSERT_1 */

            R3270_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -5622- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5623- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5624- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -5626- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -5628- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -5630- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5631- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5631- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R3270_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -5619- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 = new R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1.Execute(r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_SAIDA*/

        [StopWatch]
        /*" R3300-TRATA-PROPOSTA-SECTION */
        private void R3300_TRATA_PROPOSTA_SECTION()
        {
            /*" -5642- MOVE 'R3300-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3300-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5643- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5645- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5647- PERFORM R3310-TRATA-TAB-RELACIONAMENTO. */

            R3310_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -5649- PERFORM R3350-TRATA-TAB-IDE-RELACIONAM. */

            R3350_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -5650- PERFORM R3360-TRATA-PROP-FIDELIZACAO. */

            R3360_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -5651- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5652- GO TO R3300-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/ //GOTO
                return;

                /*" -5654- END-IF. */
            }


            /*" -5654- PERFORM R3365-TRATA-PROP-ESPECIFICA. */

            R3365_TRATA_PROP_ESPECIFICA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/

        [StopWatch]
        /*" R3310-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R3310_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -5666- MOVE 'R3310-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3310-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5667- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5669- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5671- PERFORM R3315-DETERMINA-RELACIONAMENTO */

            R3315_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -5673- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -5675- PERFORM R3320-VERIFICA-EXISTE-RELACION. */

            R3320_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -5676- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -5676- PERFORM R3330-GERA-RELACIONAMENTO. */

                R3330_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_SAIDA*/

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-SECTION */
        private void R3315_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -5686- MOVE 'R3315-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3315-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5687- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5689- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5692- MOVE 1 TO PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF */
            _.Move(1, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);

            /*" -5695- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -5698- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO W-COD-EMPRESA. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, WAREA_AUXILIAR.W_COD_EMPRESA);

            /*" -5712- PERFORM R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1 */

            R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1();

            /*" -5715- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5716- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5717- DISPLAY '          ERRO SELECT TAB. PRODUTOS-SIVPF' */
                _.Display($"          ERRO SELECT TAB. PRODUTOS-SIVPF");

                /*" -5719- DISPLAY '          NOME EMPRESA.................. ' RH-NOME OF REG-HEADER */
                _.Display($"          NOME EMPRESA.................. {LXFPF990.REG_HEADER.RH_NOME}");

                /*" -5721- DISPLAY '          CODIGO DO PRODUTO............. ' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO DO PRODUTO............. {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -5723- DISPLAY '          NUMERO DA PROPOSTA............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO DA PROPOSTA............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -5725- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5726- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5728- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5732- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

            /*" -5733- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO W-PRODUTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LBWPF002.W_PRODUTO);

        }

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-DB-SELECT-1 */
        public void R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1()
        {
            /*" -5712- EXEC SQL SELECT DISTINCT COD_PRODUTO_SIVPF, COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF, :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_PRODUTO_SIVPF, COD_RELAC WITH UR END-EXEC. */

            var r3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1 = new R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_EMPRESA_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF.ToString(),
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1.Execute(r3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3315_SAIDA*/

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-SECTION */
        private void R3320_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -5743- MOVE 'R3320-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R3320-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5744- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5746- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5749- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -5752- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -5761- PERFORM R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -5764- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5765- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5766- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -5767- ELSE */
                }
                else
                {


                    /*" -5768- DISPLAY 'PF0617B - FIM ANORMAL' */
                    _.Display($"PF0617B - FIM ANORMAL");

                    /*" -5769- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -5771- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -5773- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -5775- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -5776- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -5777- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -5778- ELSE */
                }

            }
            else
            {


                /*" -5778- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -5761- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

            var r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 = new R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1.Execute(r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3320_SAIDA*/

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-SECTION */
        private void R3330_GERA_RELACIONAMENTO_SECTION()
        {
            /*" -5788- MOVE 'R3330-GERA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3330-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5789- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5791- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5794- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -5797- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -5801- PERFORM R3330_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -5804- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5805- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5806- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -5808- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -5810- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -5812- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5813- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5813- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R3330_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -5801- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3330_SAIDA*/

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-SECTION */
        private void R3350_TRATA_TAB_IDE_RELACIONAM_SECTION()
        {
            /*" -5823- IF W-OBTER-MAX-RELAC EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_RELAC == "NAO")
            {

                /*" -5824- MOVE 'SIM' TO W-OBTER-MAX-RELAC */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_RELAC);

                /*" -5826- PERFORM R3355-OBTER-MAX-ID-RELACIONAM. */

                R3355_OBTER_MAX_ID_RELACIONAM_SECTION();
            }


            /*" -5827- MOVE 'R3350-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3350-TRATA-TAB-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5828- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5830- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5833- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -5836- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -5839- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -5842- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -5845- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -5848- MOVE 'PF0617B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0617B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -5855- PERFORM R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -5858- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5859- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5860- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -5862- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -5864- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5866- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -5868- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5870- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5871- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5871- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -5855- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 = new R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO.ToString(),
                COD_PESSOA = IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA.ToString(),
                COD_RELAC = IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC.ToString(),
                COD_USUARIO = IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO.ToString(),
            };

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1.Execute(r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3350_SAIDA*/

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-SECTION */
        private void R3355_OBTER_MAX_ID_RELACIONAM_SECTION()
        {
            /*" -5881- MOVE 'R3355-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3355-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5882- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5884- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5887- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -5890- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -5897- PERFORM R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -5900- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5901- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -5902- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -5904- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5906- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -5908- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5909- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5909- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -5897- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

            var r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 = new R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1.Execute(r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3355_SAIDA*/

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-SECTION */
        private void R3360_TRATA_PROP_FIDELIZACAO_SECTION()
        {
            /*" -5919- MOVE 'R3360-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3360-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5920- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5922- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5925- MOVE R3-NUM-SICOB OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-SICOB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -5928- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -5931- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO PROPOFID-NUM-IDENTIFICACAO. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -5934- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5936- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5938- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5941- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5945- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5948- MOVE W-DATA-SQL TO PROPOFID-DATA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -5951- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PRODUTO-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -5954- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO PROPOFID-COD-EMPRESA-SIVPF. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -5957- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO PROPOFID-AGECOBR. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -5960- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

            /*" -5963- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAOPAG. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -5966- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-AGECTADEB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -5969- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-OPRCTADEB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -5972- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-NUMCTADEB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -5975- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-DIGCTADEB. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -5978- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PROPOFID-PERC-DESCONTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -5981- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO PROPOFID-NRMATRVEN. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -5999- MOVE ZEROS TO PROPOFID-AGECTAVEN PROPOFID-OPRCTAVEN PROPOFID-NUMCTAVEN PROPOFID-DIGCTAVEN. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -6002- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-CGC-CONVENENTE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -6007- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-NOME-CONVENENTE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -6010- MOVE ZEROS TO PROPOFID-NRMATRCON. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

            /*" -6013- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -6015- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -6017- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -6020- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -6024- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -6027- MOVE W-DATA-SQL TO PROPOFID-DTQITBCO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -6030- MOVE R3-VAL-PAGO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-PAGO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -6033- MOVE R3-AGEPGTO OF REG-PROPOSTA-SASSE TO PROPOFID-AGEPGTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -6036- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-TARIFA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -6039- MOVE ZEROS TO PROPOFID-VAL-IOF. */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -6042- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -6044- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -6046- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -6049- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -6053- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -6056- MOVE W-DATA-SQL TO PROPOFID-DATA-CREDITO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -6059- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-COMISSAO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -6062- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-SIT-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -6065- MOVE 'PF0617B' TO PROPOFID-COD-USUARIO. */
            _.Move("PF0617B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -6069- MOVE RH-NSAS OF REG-HEADER TO PROPOFID-NSAS-SIVPF PROPOFID-NSAC-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -6072- MOVE W-QTD-LD-TIPO-3 TO PROPOFID-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -6073- IF CANAL-VENDA-PAPEL */

            if (WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -6075- MOVE 2 TO W-CANAL-PROPOSTA. */
                _.Move(2, WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA);
            }


            /*" -6078- MOVE W-CANAL-PROPOSTA TO PROPOFID-CANAL-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

            /*" -6079- IF CANAL-CORRESP-NEGOCIAL */

            if (WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA["CANAL_CORRESP_NEGOCIAL"])
            {

                /*" -6080- MOVE 13 TO PROPOFID-ORIGEM-PROPOSTA */
                _.Move(13, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                /*" -6081- ELSE */
            }
            else
            {


                /*" -6082-  EVALUATE TRUE  */

                /*" -6083-  WHEN ENDOSSOS-COD-PRODUTO     = 3716  */

                /*" -6083- IF ENDOSSOS-COD-PRODUTO     = 3716 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 3716)
                {

                    /*" -6084- MOVE 09 TO PROPOFID-ORIGEM-PROPOSTA */
                    _.Move(09, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6085-  WHEN ENDOSSOS-COD-PRODUTO     = 3725  */

                    /*" -6085- ELSE IF ENDOSSOS-COD-PRODUTO     = 3725 */
                }
                else

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 3725)
                {

                    /*" -6086- MOVE 17 TO PROPOFID-ORIGEM-PROPOSTA */
                    _.Move(17, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6087-  WHEN OTHER  */

                    /*" -6087- ELSE */
                }
                else
                {


                    /*" -6088- MOVE 06 TO PROPOFID-ORIGEM-PROPOSTA */
                    _.Move(06, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

                    /*" -6089-  END-EVALUATE  */

                    /*" -6089- END-IF */
                }


                /*" -6091- END-IF. */
            }


            /*" -6094- MOVE 'S' TO PROPOFID-SITUACAO-ENVIO. */
            _.Move("S", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -6097- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO PROPOFID-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -6100- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAO-COBER. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -6104- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PLANO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

            /*" -6108- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO PROPOFID-NOME-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -6111- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -6113- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -6115- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -6118- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -6121- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -6124- MOVE W-DATA-SQL TO PROPOFID-DATA-NASC-CONJUGE. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);

            /*" -6127- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROPOFID-PROFISSAO-CONJUGE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -6133- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA OF DCLPROPOSTA-FIDELIZ. */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -6233- PERFORM R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -6238- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL -180 AND SQLCODE NOT EQUAL -803 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -180 && DB.SQLCODE != -803)
            {

                /*" -6239- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -6240- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -6242- DISPLAY '          CODIGO PESSOA.................  ' PROPOFID-COD-PESSOA */
                _.Display($"          CODIGO PESSOA.................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -6244- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6246- DISPLAY '          NUM-IDENTIFICACAO.............  ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"          NUM-IDENTIFICACAO.............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -6248- DISPLAY '          COD-EMPRESA...................  ' PROPOFID-COD-EMPRESA-SIVPF */
                _.Display($"          COD-EMPRESA...................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}");

                /*" -6250- DISPLAY '          COD-PRODUTO-SIVPF.............  ' PROPOFID-COD-PRODUTO-SIVPF */
                _.Display($"          COD-PRODUTO-SIVPF.............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}");

                /*" -6252- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6254- DISPLAY '          SQLERRMC= ' SQLERRMC */
                _.Display($"          SQLERRMC= {DB.SQLERRMC}");

                /*" -6255- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6256- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -6258- END-IF */
            }


            /*" -6259- IF SQLCODE EQUAL -180 */

            if (DB.SQLCODE == -180)
            {

                /*" -6265- DISPLAY 'PF0617B PROPOSTAS NAO INSERIDA (-180) ' PROPOFID-NUM-PROPOSTA-SIVPF ' DTAPROPOSTA = ' PROPOFID-DATA-PROPOSTA ' DTQITBCO = ' PROPOFID-DTQITBCO ' DTCREDITO = ' PROPOFID-DATA-CREDITO ' DTNASCCONJG =' PROPOFID-DATA-NASC-CONJUGE */

                $"PF0617B PROPOSTAS NAO INSERIDA (-180) {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} DTAPROPOSTA = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA} DTQITBCO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO} DTCREDITO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO} DTNASCCONJG ={PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE}"
                .Display();

                /*" -6267- END-IF. */
            }


            /*" -6268- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -6275- DISPLAY 'PF0617B PROPOSTAS NAO INSERIDA (-803) ' PROPOFID-NUM-PROPOSTA-SIVPF ' NUM-IDENTIFICACAO   = ' PROPOFID-NUM-IDENTIFICACAO ' COD-EMPRESA-SIVPF   = ' PROPOFID-COD-EMPRESA-SIVPF ' COD-PRODUTO-SIVPF   = ' PROPOFID-COD-PRODUTO-SIVPF ' COD-PESSOA          = ' PROPOFID-COD-PESSOA ' NUM-SICOB           = ' PROPOFID-NUM-SICOB */

                $"PF0617B PROPOSTAS NAO INSERIDA (-803) {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} NUM-IDENTIFICACAO   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO} COD-EMPRESA-SIVPF   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF} COD-PRODUTO-SIVPF   = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF} COD-PESSOA          = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA} NUM-SICOB           = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}"
                .Display();

                /*" -6277- END-IF. R3360-SAIDA. EXIT. */
            }


        }

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -6233- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ (NUM_PROPOSTA_SIVPF ,NUM_IDENTIFICACAO ,COD_EMPRESA_SIVPF ,COD_PESSOA ,NUM_SICOB ,DATA_PROPOSTA ,COD_PRODUTO_SIVPF ,AGECOBR ,DIA_DEBITO ,OPCAOPAG ,AGECTADEB ,OPRCTADEB ,NUMCTADEB ,DIGCTADEB ,PERC_DESCONTO ,NRMATRVEN ,AGECTAVEN ,OPRCTAVEN ,NUMCTAVEN ,DIGCTAVEN ,CGC_CONVENENTE ,NOME_CONVENENTE ,NRMATRCON ,DTQITBCO ,VAL_PAGO ,AGEPGTO ,VAL_TARIFA ,VAL_IOF ,DATA_CREDITO ,VAL_COMISSAO ,SIT_PROPOSTA ,COD_USUARIO ,CANAL_PROPOSTA ,NSAS_SIVPF ,ORIGEM_PROPOSTA ,TIMESTAMP ,NSL ,NSAC_SIVPF ,SITUACAO_ENVIO ,OPCAO_COBER ,COD_PLANO ,NOME_CONJUGE ,DATA_NASC_CONJUGE ,PROFISSAO_CONJUGE ,FAIXA_RENDA_IND ,FAIXA_RENDA_FAM ,IND_TP_PROPOSTA ,IND_TIPO_CONTA) VALUES (:PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PESSOA , :PROPOFID-NUM-SICOB , :PROPOFID-DATA-PROPOSTA , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-AGECOBR , :PROPOFID-DIA-DEBITO , :PROPOFID-OPCAOPAG , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :PROPOFID-PERC-DESCONTO , :PROPOFID-NRMATRVEN , :PROPOFID-AGECTAVEN , :PROPOFID-OPRCTAVEN , :PROPOFID-NUMCTAVEN , :PROPOFID-DIGCTAVEN , :PROPOFID-CGC-CONVENENTE , :PROPOFID-NOME-CONVENENTE , :PROPOFID-NRMATRCON , :PROPOFID-DTQITBCO , :PROPOFID-VAL-PAGO , :PROPOFID-AGEPGTO , :PROPOFID-VAL-TARIFA , :PROPOFID-VAL-IOF , :PROPOFID-DATA-CREDITO , :PROPOFID-VAL-COMISSAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-COD-USUARIO , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-NSAS-SIVPF , :PROPOFID-ORIGEM-PROPOSTA , CURRENT TIMESTAMP , :PROPOFID-NSL , :PROPOFID-NSAC-SIVPF , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-OPCAO-COBER , :PROPOFID-COD-PLANO , :PROPOFID-NOME-CONJUGE , NULL , :PROPOFID-PROFISSAO-CONJUGE , ' ' , ' ' , NULL, :DCLPROPOSTA-FIDELIZ.PROPOFID-IND-TIPO-CONTA) END-EXEC. */

            var r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PESSOA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA.ToString(),
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                PROPOFID_DATA_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_DIA_DEBITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO.ToString(),
                PROPOFID_OPCAOPAG = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                PROPOFID_PERC_DESCONTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                PROPOFID_CGC_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE.ToString(),
                PROPOFID_NOME_CONVENENTE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE.ToString(),
                PROPOFID_NRMATRCON = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                PROPOFID_AGEPGTO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO.ToString(),
                PROPOFID_VAL_TARIFA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA.ToString(),
                PROPOFID_VAL_IOF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF.ToString(),
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_VAL_COMISSAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO.ToString(),
                PROPOFID_SIT_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA.ToString(),
                PROPOFID_COD_USUARIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO.ToString(),
                PROPOFID_CANAL_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA.ToString(),
                PROPOFID_NSAS_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF.ToString(),
                PROPOFID_ORIGEM_PROPOSTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_SITUACAO_ENVIO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO.ToString(),
                PROPOFID_OPCAO_COBER = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
                PROPOFID_NOME_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE.ToString(),
                PROPOFID_PROFISSAO_CONJUGE = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R3365-TRATA-PROP-ESPECIFICA-SECTION */
        private void R3365_TRATA_PROP_ESPECIFICA_SECTION()
        {
            /*" -6285- MOVE 'R3365-TRATA-PROP-ESPECIFICA' TO PARAGRAFO. */
            _.Move("R3365-TRATA-PROP-ESPECIFICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6288- MOVE W-COD-RELACION TO W-RELACIONAMENTO. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

            /*" -6289- MOVE 'INSERT PROPOSTA-BILHETE' TO COMANDO. */
            _.Move("INSERT PROPOSTA-BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6291- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6295- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPSSBI-NUM-IDENTIFICACAO OF DCLPROP-SASSE-BILHETE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO);

            /*" -6299- MOVE R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE TO PROPSSBI-RENOVACAO-AUTOM OF DCLPROP-SASSE-BILHETE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM);

            /*" -6303- MOVE 'PF0617B' TO PROPSSBI-COD-USUARIO OF DCLPROP-SASSE-BILHETE. */
            _.Move("PF0617B", PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_COD_USUARIO);

            /*" -6316- PERFORM R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1 */

            R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1();

            /*" -6319- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6320- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -6321- DISPLAY '          ERRO INSERT TAB. PROP. SASSE BILHETE' */
                _.Display($"          ERRO INSERT TAB. PROP. SASSE BILHETE");

                /*" -6323- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -6325- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -6328- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSBI-NUM-IDENTIFICACAO OF DCLPROP-SASSE-BILHETE */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO}");

                /*" -6330- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6331- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6331- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3365-TRATA-PROP-ESPECIFICA-DB-INSERT-1 */
        public void R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1()
        {
            /*" -6316- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_BILHETE VALUES (:DCLPROP-SASSE-BILHETE.PROPSSBI-NUM-IDENTIFICACAO , :DCLPROP-SASSE-BILHETE.PROPSSBI-RENOVACAO-AUTOM , :DCLPROP-SASSE-BILHETE.PROPSSBI-COD-USUARIO , CURRENT TIMESTAMP , :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO , 0 ) END-EXEC. */

            var r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1 = new R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1()
            {
                PROPSSBI_NUM_IDENTIFICACAO = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO.ToString(),
                PROPSSBI_RENOVACAO_AUTOM = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM.ToString(),
                PROPSSBI_COD_USUARIO = PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_COD_USUARIO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1.Execute(r3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3365_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -6340- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6341- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6343- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6346- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -6349- MOVE ENDOSSOS-DATA-EMISSAO OF DCLENDOSSOS TO PROPFIDH-DATA-SITUACAO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -6352- MOVE RH-NSAS OF REG-HEADER TO PROPFIDH-NSAS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -6355- MOVE W-QTD-LD-TIPO-3 TO PROPFIDH-NSL. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -6358- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -6361- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -6364- MOVE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-MOTIVO-SIVPF. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -6367- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -6370- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -6381- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -6384- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6385- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -6386- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -6388- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -6390- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -6393- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSBI-NUM-IDENTIFICACAO OF DCLPROP-SASSE-BILHETE */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_NUM_IDENTIFICACAO}");

                /*" -6395- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6396- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6396- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -6381- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ( :PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF , :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_COD_EMPRESA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF.ToString(),
                PROPFIDH_COD_PRODUTO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF.ToString(),
            };

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3390_SAIDA*/

        [StopWatch]
        /*" R3400-TRATA-BENEFICIARIOS-SECTION */
        private void R3400_TRATA_BENEFICIARIOS_SECTION()
        {
            /*" -6406- MOVE 'R3400-TRATA-BENEFICIARIOS' TO PARAGRAFO. */
            _.Move("R3400-TRATA-BENEFICIARIOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6407- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6409- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6411- PERFORM R3455-OBTER-MAX-BENEFICIARIO. */

            R3455_OBTER_MAX_BENEFICIARIO_SECTION();

            /*" -6417- MOVE ZEROS TO COD-AGENCIA-LOTE OF DCLBENEF-PROP-AZUL, DATA-LOTE OF DCLBENEF-PROP-AZUL, NUM-LOTE OF DCLBENEF-PROP-AZUL, NUM-SEQ-LOTE OF DCLBENEF-PROP-AZUL. */
            _.Move(0, BENPROPZ.DCLBENEF_PROP_AZUL.COD_AGENCIA_LOTE, BENPROPZ.DCLBENEF_PROP_AZUL.DATA_LOTE, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_LOTE, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_SEQ_LOTE);

            /*" -6420- MOVE NUM-BENEFICIARIO OF DCLBENEF-PROP-AZUL TO W-NUM-BENEF. */
            _.Move(BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO, WAREA_AUXILIAR.W_NUM_BENEF);

            /*" -6423- COMPUTE W-NUM-BENEF = W-NUM-BENEF + 1. */
            WAREA_AUXILIAR.W_NUM_BENEF.Value = WAREA_AUXILIAR.W_NUM_BENEF + 1;

            /*" -6426- MOVE W-NUM-BENEF TO NUM-BENEFICIARIO OF DCLBENEF-PROP-AZUL. */
            _.Move(WAREA_AUXILIAR.W_NUM_BENEF, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO);

            /*" -6429- MOVE R4-NOME OF REG-BENEFIC TO NOME-BENEFICIARIO OF DCLBENEF-PROP-AZUL. */
            _.Move(LBFPF014.REG_BENEFIC.R4_NOME, BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO);

            /*" -6430- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 1 */

            if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 1)
            {

                /*" -6432- MOVE 'CONJUGE' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                _.Move("CONJUGE", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                /*" -6433- ELSE */
            }
            else
            {


                /*" -6434- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 2 */

                if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 2)
                {

                    /*" -6436- MOVE 'COMPANHEIRO(A)' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                    _.Move("COMPANHEIRO(A)", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                    /*" -6437- ELSE */
                }
                else
                {


                    /*" -6438- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 3 */

                    if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 3)
                    {

                        /*" -6440- MOVE 'FILHOS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                        _.Move("FILHOS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                        /*" -6441- ELSE */
                    }
                    else
                    {


                        /*" -6442- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 4 */

                        if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 4)
                        {

                            /*" -6444- MOVE 'PAIS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                            _.Move("PAIS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                            /*" -6445- ELSE */
                        }
                        else
                        {


                            /*" -6446- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 5 */

                            if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 5)
                            {

                                /*" -6448- MOVE 'IRMAOS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                _.Move("IRMAOS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                /*" -6449- ELSE */
                            }
                            else
                            {


                                /*" -6450- IF R4-GRAU-PARENTESCO OF REG-BENEFIC EQUAL 6 */

                                if (LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO == 6)
                                {

                                    /*" -6452- MOVE 'OUTROS' TO GRAU-PARENTESCO OF DCLBENEF-PROP-AZUL */
                                    _.Move("OUTROS", BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO);

                                    /*" -6453- ELSE */
                                }
                                else
                                {


                                    /*" -6454- DISPLAY 'PF0617B FIM ANORMAL' */
                                    _.Display($"PF0617B FIM ANORMAL");

                                    /*" -6455- DISPLAY '        GRAU PARENTESCO INVALIDO.... ' */
                                    _.Display($"        GRAU PARENTESCO INVALIDO.... ");

                                    /*" -6457- DISPLAY '        NOME BENEFICIARIO........... ' NOME-BENEFICIARIO OF DCLBENEF-PROP-AZUL */
                                    _.Display($"        NOME BENEFICIARIO........... {BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO}");

                                    /*" -6459- DISPLAY '        NUMERO BENEFICIARIO......... ' NUM-BENEFICIARIO OF DCLBENEF-PROP-AZUL */
                                    _.Display($"        NUMERO BENEFICIARIO......... {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO}");

                                    /*" -6461- DISPLAY '        GRAU PARENTESCO BENEPROPAZUL ' BENEFICI-GRAU-PARENTESCO OF DCLBENEFICIARIOS */
                                    _.Display($"        GRAU PARENTESCO BENEPROPAZUL {BENEFICI.DCLBENEFICIARIOS.BENEFICI_GRAU_PARENTESCO}");

                                    /*" -6463- DISPLAY '        GRAU PARENTESCO REG-BENEFIC. ' R4-GRAU-PARENTESCO OF REG-BENEFIC */
                                    _.Display($"        GRAU PARENTESCO REG-BENEFIC. {LBFPF014.REG_BENEFIC.R4_GRAU_PARENTESCO}");

                                    /*" -6464- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                                    /*" -6466- PERFORM R9999-00-FINALIZAR. */

                                    R9999_00_FINALIZAR_SECTION();
                                }

                            }

                        }

                    }

                }

            }


            /*" -6469- MOVE R4-PCT-PARTICIP OF REG-BENEFIC TO PCT-PART-BENEFICIA OF DCLBENEF-PROP-AZUL. */
            _.Move(LBFPF014.REG_BENEFIC.R4_PCT_PARTICIP, BENPROPZ.DCLBENEF_PROP_AZUL.PCT_PART_BENEFICIA);

            /*" -6470- IF R4-DATA-NASCIMENTO OF REG-BENEFIC GREATER ZEROS */

            if (LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO > 00)
            {

                /*" -6473- MOVE R4-DATA-NASCIMENTO OF REG-BENEFIC TO W-DATA-TRABALHO */
                _.Move(LBFPF014.REG_BENEFIC.R4_DATA_NASCIMENTO, WAREA_AUXILIAR.W_DATA_TRABALHO);

                /*" -6475- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_4.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

                /*" -6477- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_4.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

                /*" -6480- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1 */
                _.Move(WAREA_AUXILIAR.FILLER_4.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

                /*" -6484- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1 */
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
                _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


                /*" -6486- MOVE W-DATA-SQL TO DATA-NASCIMENTO OF DCLBENEF-PROP-AZUL */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL, BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO);

                /*" -6487- ELSE */
            }
            else
            {


                /*" -6489- MOVE -1 TO VIND-DTNASBENEF. */
                _.Move(-1, VIND_DTNASBENEF);
            }


            /*" -6501- PERFORM R3400_TRATA_BENEFICIARIOS_DB_INSERT_1 */

            R3400_TRATA_BENEFICIARIOS_DB_INSERT_1();

            /*" -6504- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6505- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -6506- DISPLAY '          ERRO INSERT TABELA BENEF-PROP-AZUL' */
                _.Display($"          ERRO INSERT TABELA BENEF-PROP-AZUL");

                /*" -6508- DISPLAY '          NUMERO PROPOSTA...............  ' R4-NUM-PROPOSTA OF REG-BENEFIC */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF014.REG_BENEFIC.R4_NUM_PROPOSTA}");

                /*" -6510- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6511- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6511- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3400-TRATA-BENEFICIARIOS-DB-INSERT-1 */
        public void R3400_TRATA_BENEFICIARIOS_DB_INSERT_1()
        {
            /*" -6501- EXEC SQL INSERT INTO SEGUROS.BENEF_PROP_AZUL VALUES (:DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL, :DCLBENEF-PROP-AZUL.COD-AGENCIA-LOTE, :DCLBENEF-PROP-AZUL.DATA-LOTE, :DCLBENEF-PROP-AZUL.NUM-LOTE, :DCLBENEF-PROP-AZUL.NUM-SEQ-LOTE, :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO, :DCLBENEF-PROP-AZUL.NOME-BENEFICIARIO, :DCLBENEF-PROP-AZUL.GRAU-PARENTESCO, :DCLBENEF-PROP-AZUL.PCT-PART-BENEFICIA, :DCLBENEF-PROP-AZUL.DATA-NASCIMENTO:VIND-DTNASBENEF) END-EXEC. */

            var r3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1 = new R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1()
            {
                NUM_PROPOSTA_AZUL = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL.ToString(),
                COD_AGENCIA_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.COD_AGENCIA_LOTE.ToString(),
                DATA_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.DATA_LOTE.ToString(),
                NUM_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_LOTE.ToString(),
                NUM_SEQ_LOTE = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_SEQ_LOTE.ToString(),
                NUM_BENEFICIARIO = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO.ToString(),
                NOME_BENEFICIARIO = BENPROPZ.DCLBENEF_PROP_AZUL.NOME_BENEFICIARIO.ToString(),
                GRAU_PARENTESCO = BENPROPZ.DCLBENEF_PROP_AZUL.GRAU_PARENTESCO.ToString(),
                PCT_PART_BENEFICIA = BENPROPZ.DCLBENEF_PROP_AZUL.PCT_PART_BENEFICIA.ToString(),
                DATA_NASCIMENTO = BENPROPZ.DCLBENEF_PROP_AZUL.DATA_NASCIMENTO.ToString(),
                VIND_DTNASBENEF = VIND_DTNASBENEF.ToString(),
            };

            R3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1.Execute(r3400_TRATA_BENEFICIARIOS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3400_SAIDA*/

        [StopWatch]
        /*" R3455-OBTER-MAX-BENEFICIARIO-SECTION */
        private void R3455_OBTER_MAX_BENEFICIARIO_SECTION()
        {
            /*" -6521- MOVE 'R3455-OBTER-MAX-BENEFICIARIO' TO PARAGRAFO. */
            _.Move("R3455-OBTER-MAX-BENEFICIARIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6522- MOVE 'MAX BENEF-PROP-AZUL' TO COMANDO. */
            _.Move("MAX BENEF-PROP-AZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -6524- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -6527- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL);

            /*" -6533- PERFORM R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1 */

            R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1();

            /*" -6536- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -6537- DISPLAY 'PF0617B - FIM ANORMAL' */
                _.Display($"PF0617B - FIM ANORMAL");

                /*" -6538- DISPLAY '          ERRO SELECT MAX TAB. BENEF-PROP-AZUL' */
                _.Display($"          ERRO SELECT MAX TAB. BENEF-PROP-AZUL");

                /*" -6540- DISPLAY '          NUMERO DA PROPOSTA............  ' NUM-PROPOSTA-AZUL OF DCLBENEF-PROP-AZUL */
                _.Display($"          NUMERO DA PROPOSTA............  {BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL}");

                /*" -6542- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -6543- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -6543- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3455-OBTER-MAX-BENEFICIARIO-DB-SELECT-1 */
        public void R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1()
        {
            /*" -6533- EXEC SQL SELECT VALUE(MAX(NUM_BENEFICIARIO),0) INTO :DCLBENEF-PROP-AZUL.NUM-BENEFICIARIO FROM SEGUROS.BENEF_PROP_AZUL WHERE NUM_PROPOSTA_AZUL = :DCLBENEF-PROP-AZUL.NUM-PROPOSTA-AZUL END-EXEC. */

            var r3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1 = new R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1()
            {
                NUM_PROPOSTA_AZUL = BENPROPZ.DCLBENEF_PROP_AZUL.NUM_PROPOSTA_AZUL.ToString(),
            };

            var executed_1 = R3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1.Execute(r3455_OBTER_MAX_BENEFICIARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_BENEFICIARIO, BENPROPZ.DCLBENEF_PROP_AZUL.NUM_BENEFICIARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3455_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -6552- CLOSE MOVTO-PRP-BILHETE. */
            MOVTO_PRP_BILHETE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -6559- DISPLAY ' ' . */
            _.Display($" ");

            /*" -6559- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -6562- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -6563- IF SII < 63 */

            if (WS_HORAS.SII < 63)
            {

                /*" -6564- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_22[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -6566- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_22[WS_HORAS.SII]}"
                .Display();

                /*" -6567- GO TO M-1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -6567- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -6579- DISPLAY ' ' */
            _.Display($" ");

            /*" -6580- IF W-FIM-MOVTO-BILH = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_BILH == "FIM")
            {

                /*" -6581- DISPLAY 'PESQUISA LOT. 9 E DV: ' WS-NUM-LOTERICO-26 */
                _.Display($"PESQUISA LOT. 9 E DV: {WS_NUM_LOTERICO_26}");

                /*" -6582- DISPLAY 'PESQUISA LOT. 9.....: ' WS-NUM-LOTERICO-27 */
                _.Display($"PESQUISA LOT. 9.....: {WS_NUM_LOTERICO_27}");

                /*" -6583- DISPLAY 'PF0617B - FIM NORMAL' */
                _.Display($"PF0617B - FIM NORMAL");

                /*" -6585- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -6587- DISPLAY COMANDO */
                _.Display(WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6588- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6588- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -6590- ELSE */
            }
            else
            {


                /*" -6591- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_13.WSQLCODE);

                /*" -6592- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_13.WSQLERRD1);

                /*" -6593- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_13.WSQLERRD2);

                /*" -6594- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -6595- DISPLAY 'SQLERRMC = ' SQLERRMC */
                _.Display($"SQLERRMC = {DB.SQLERRMC}");

                /*" -6596- DISPLAY '*** PF0617B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0617B *** ROLLBACK EM ANDAMENTO ...");

                /*" -6597- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -6597- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -6600- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -6600- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" R8888-00-DISPLAY1-SECTION */
        private void R8888_00_DISPLAY1_SECTION()
        {
            /*" -6606- DISPLAY ' ' */
            _.Display($" ");

            /*" -6607- DISPLAY '=> BILHETE EM PROCESSAMENTO' */
            _.Display($"=> BILHETE EM PROCESSAMENTO");

            /*" -6608- DISPLAY ' ' */
            _.Display($" ");

            /*" -6610- DISPLAY 'BILHETE-NUM-BILHETE: ' BILHETE-NUM-BILHETE */
            _.Display($"BILHETE-NUM-BILHETE: {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

            /*" -6612- DISPLAY 'BILHETE-NUM-APOLICE: ' BILHETE-NUM-APOLICE */
            _.Display($"BILHETE-NUM-APOLICE: {BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE}");

            /*" -6614- DISPLAY 'BILHETE-FONTE      : ' BILHETE-FONTE */
            _.Display($"BILHETE-FONTE      : {BILHETE.DCLBILHETE.BILHETE_FONTE}");

            /*" -6616- DISPLAY 'BILHETE-AGE-COBRANCA: ' BILHETE-AGE-COBRANCA */
            _.Display($"BILHETE-AGE-COBRANCA: {BILHETE.DCLBILHETE.BILHETE_AGE_COBRANCA}");

            /*" -6618- DISPLAY 'BILHETE-NUM-MATRICULA: ' BILHETE-NUM-MATRICULA */
            _.Display($"BILHETE-NUM-MATRICULA: {BILHETE.DCLBILHETE.BILHETE_NUM_MATRICULA}");

            /*" -6620- DISPLAY 'BILHETE-COD-AGENCIA: ' BILHETE-COD-AGENCIA */
            _.Display($"BILHETE-COD-AGENCIA: {BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA}");

            /*" -6622- DISPLAY 'BILHETE-OPERACAO-CONTA: ' BILHETE-OPERACAO-CONTA */
            _.Display($"BILHETE-OPERACAO-CONTA: {BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA}");

            /*" -6624- DISPLAY 'BILHETE-NUM-CONTA: ' BILHETE-NUM-CONTA */
            _.Display($"BILHETE-NUM-CONTA: {BILHETE.DCLBILHETE.BILHETE_NUM_CONTA}");

            /*" -6626- DISPLAY 'BILHETE-DIG-CONTA: ' BILHETE-DIG-CONTA */
            _.Display($"BILHETE-DIG-CONTA: {BILHETE.DCLBILHETE.BILHETE_DIG_CONTA}");

            /*" -6628- DISPLAY 'BILHETE-COD-CLIENTE: ' BILHETE-COD-CLIENTE */
            _.Display($"BILHETE-COD-CLIENTE: {BILHETE.DCLBILHETE.BILHETE_COD_CLIENTE}");

            /*" -6630- DISPLAY 'BILHETE-PROFISSAO: ' BILHETE-PROFISSAO */
            _.Display($"BILHETE-PROFISSAO: {BILHETE.DCLBILHETE.BILHETE_PROFISSAO}");

            /*" -6632- DISPLAY 'BILHETE-IDE-SEXO: ' BILHETE-IDE-SEXO */
            _.Display($"BILHETE-IDE-SEXO: {BILHETE.DCLBILHETE.BILHETE_IDE_SEXO}");

            /*" -6634- DISPLAY 'BILHETE-ESTADO-CIVIL: ' BILHETE-ESTADO-CIVIL */
            _.Display($"BILHETE-ESTADO-CIVIL: {BILHETE.DCLBILHETE.BILHETE_ESTADO_CIVIL}");

            /*" -6636- DISPLAY 'BILHETE-OCORR-ENDERECO: ' BILHETE-OCORR-ENDERECO */
            _.Display($"BILHETE-OCORR-ENDERECO: {BILHETE.DCLBILHETE.BILHETE_OCORR_ENDERECO}");

            /*" -6638- DISPLAY 'BILHETE-COD-AGENCIA-DEB: ' BILHETE-COD-AGENCIA-DEB */
            _.Display($"BILHETE-COD-AGENCIA-DEB: {BILHETE.DCLBILHETE.BILHETE_COD_AGENCIA_DEB}");

            /*" -6640- DISPLAY 'BILHETE-OPERACAO-CONTA-DEB: ' BILHETE-OPERACAO-CONTA-DEB */
            _.Display($"BILHETE-OPERACAO-CONTA-DEB: {BILHETE.DCLBILHETE.BILHETE_OPERACAO_CONTA_DEB}");

            /*" -6642- DISPLAY 'BILHETE-NUM-CONTA-DEB: ' BILHETE-NUM-CONTA-DEB */
            _.Display($"BILHETE-NUM-CONTA-DEB: {BILHETE.DCLBILHETE.BILHETE_NUM_CONTA_DEB}");

            /*" -6644- DISPLAY 'BILHETE-DIG-CONTA-DEB: ' BILHETE-DIG-CONTA-DEB */
            _.Display($"BILHETE-DIG-CONTA-DEB: {BILHETE.DCLBILHETE.BILHETE_DIG_CONTA_DEB}");

            /*" -6646- DISPLAY 'BILHETE-OPC-COBERTURA: ' BILHETE-OPC-COBERTURA */
            _.Display($"BILHETE-OPC-COBERTURA: {BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA}");

            /*" -6648- DISPLAY 'BILHETE-DATA-QUITACAO: ' BILHETE-DATA-QUITACAO */
            _.Display($"BILHETE-DATA-QUITACAO: {BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO}");

            /*" -6650- DISPLAY 'BILHETE-VAL-RCAP     : ' BILHETE-VAL-RCAP */
            _.Display($"BILHETE-VAL-RCAP     : {BILHETE.DCLBILHETE.BILHETE_VAL_RCAP}");

            /*" -6652- DISPLAY 'BILHETE-RAMO         : ' BILHETE-RAMO */
            _.Display($"BILHETE-RAMO         : {BILHETE.DCLBILHETE.BILHETE_RAMO}");

            /*" -6654- DISPLAY 'BILHETE-DATA-VENDA   : ' BILHETE-DATA-VENDA */
            _.Display($"BILHETE-DATA-VENDA   : {BILHETE.DCLBILHETE.BILHETE_DATA_VENDA}");

            /*" -6656- DISPLAY 'BILHETE-DATA-MOVIMENTO: ' BILHETE-DATA-MOVIMENTO */
            _.Display($"BILHETE-DATA-MOVIMENTO: {BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO}");

            /*" -6658- DISPLAY 'BILHETE-NUM-APOL-ANTERIOR: ' BILHETE-NUM-APOL-ANTERIOR */
            _.Display($"BILHETE-NUM-APOL-ANTERIOR: {BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR}");

            /*" -6660- DISPLAY 'BILHETE-SITUACAO        : ' BILHETE-SITUACAO */
            _.Display($"BILHETE-SITUACAO        : {BILHETE.DCLBILHETE.BILHETE_SITUACAO}");

            /*" -6662- DISPLAY 'BILHETE-TIP-CANCELAMENTO: ' BILHETE-TIP-CANCELAMENTO */
            _.Display($"BILHETE-TIP-CANCELAMENTO: {BILHETE.DCLBILHETE.BILHETE_TIP_CANCELAMENTO}");

            /*" -6664- DISPLAY 'BILHETE-SIT-SINISTRO   : ' BILHETE-SIT-SINISTRO */
            _.Display($"BILHETE-SIT-SINISTRO   : {BILHETE.DCLBILHETE.BILHETE_SIT_SINISTRO}");

            /*" -6666- DISPLAY 'BILHETE-COD-USUARIO    : ' BILHETE-COD-USUARIO */
            _.Display($"BILHETE-COD-USUARIO    : {BILHETE.DCLBILHETE.BILHETE_COD_USUARIO}");

            /*" -6668- DISPLAY 'WHOST-DATA-REFERENCIA             : ' WHOST-DATA-REFERENCIA */
            _.Display($"WHOST-DATA-REFERENCIA             : {WAREA_AUXILIAR.WHOST_DATA_REFERENCIA}");

            /*" -6670- DISPLAY 'ENDOSSOS-NUM-APOLICE  : ' ENDOSSOS-NUM-APOLICE */
            _.Display($"ENDOSSOS-NUM-APOLICE  : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

            /*" -6672- DISPLAY 'ENDOSSOS-NUM-ENDOSSO  : ' ENDOSSOS-NUM-ENDOSSO */
            _.Display($"ENDOSSOS-NUM-ENDOSSO  : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

            /*" -6674- DISPLAY 'ENDOSSOS-NUM-PROPOSTA : ' ENDOSSOS-NUM-PROPOSTA */
            _.Display($"ENDOSSOS-NUM-PROPOSTA : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA}");

            /*" -6676- DISPLAY 'ENDOSSOS-DATA-PROPOSTA: ' ENDOSSOS-DATA-PROPOSTA */
            _.Display($"ENDOSSOS-DATA-PROPOSTA: {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA}");

            /*" -6678- DISPLAY 'ENDOSSOS-DATA-EMISSAO : ' ENDOSSOS-DATA-EMISSAO */
            _.Display($"ENDOSSOS-DATA-EMISSAO : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO}");

            /*" -6680- DISPLAY 'ENDOSSOS-NUM-RCAP     : ' ENDOSSOS-NUM-RCAP */
            _.Display($"ENDOSSOS-NUM-RCAP     : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP}");

            /*" -6682- DISPLAY 'ENDOSSOS-VAL-RCAP     : ' ENDOSSOS-VAL-RCAP */
            _.Display($"ENDOSSOS-VAL-RCAP     : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP}");

            /*" -6684- DISPLAY 'ENDOSSOS-DATA-INIVIGENCIA: ' ENDOSSOS-DATA-INIVIGENCIA */
            _.Display($"ENDOSSOS-DATA-INIVIGENCIA: {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

            /*" -6686- DISPLAY 'ENDOSSOS-DATA-TERVIGENCIA: ' ENDOSSOS-DATA-TERVIGENCIA */
            _.Display($"ENDOSSOS-DATA-TERVIGENCIA: {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}");

            /*" -6687- DISPLAY 'ENDOSSOS-COD-PRODUTO : ' ENDOSSOS-COD-PRODUTO. */
            _.Display($"ENDOSSOS-COD-PRODUTO : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8888_00_EXIT*/
    }
}