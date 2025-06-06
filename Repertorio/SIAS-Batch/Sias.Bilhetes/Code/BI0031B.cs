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
using Sias.Bilhetes.DB2.BI0031B;

namespace Code
{
    public class BI0031B
    {
        public bool IsCall { get; set; }

        public BI0031B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  BI0031B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CONSEDA                            *      */
        /*"      *   PROGRAMADOR ............  CONSEDA                            *      */
        /*"      *   DATA CODIFICACAO .......  OUTUBRO/1999                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERAR ARQUIVO MOVTO P/ DEBITO EM *      */
        /*"      *                               CONTA CORRENTE PARA RENOVACAO DE *      */
        /*"      *                               BILHETE SASSE FACIL              *      */
        /*"V.21  *                               E DEBITO EM CONTA PARA COBRANCA  *      */
        /*"V.21  *                               DE PREMIO DE ADESAO P/BILHETES   *      */
        /*"V.21  *                               EXTRA-REDE.                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * MOVTO_DEBITOCC_CEF                  V0MOVDEBCC_CEF    I-O      *      */
        /*"      * PARAM_CONTACEF                      V0PARAM_CONTACEF  I-O      *      */
        /*"      * BILHETE                             V0BILHETE         I-O      *      */
        /*"      * EMPRESAS                            V0EMPRESA         I        *      */
        /*"      * CLIENTES                            V1CLIENTE         I        *      */
        /*"      * PROPOSTA_FIDELIZ                                      I        *      */
        /*"      * BILHETE_COBERTURA                                     I        *      */
        /*"      * ARQUIVOS_SIVPF                                        I        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.23  *   VERSAO 23   - DEMANDA 575149 TAREFA 594556                   *      */
        /*"      *               - PERMITIR QUE PRODUTOS PARAMENTRIZADOS COM      *      */
        /*"      *                 IND_FLUXO_PARAMETRIZADO IGUAL A "S" TENHAM     *      */
        /*"      *                 COBRAN�AS REALIZADAS                           *      */
        /*"      *                                                                *      */
        /*"      *   04/07/2024  - HUSNI ALI HUSNI       PROCURE POR V.23         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.22  *   VERSAO 22   - DEMANDA 489284                                 *      */
        /*"      *               - PRODUTO MEI 8530 (MENSAL)                      *      */
        /*"      *   27/12/2023  - CANETTA               PROCURE POR V.22         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 21 - DEMANDA 283883                                   *      */
        /*"      *               AJUSTE ATUALIZACAO MOVTO_DEBITOCC_CEF COM        *      */
        /*"      *               DTMOVTO = V1SISTE-DTMOVABE                       *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/04/2021 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.21         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 20 - DEMANDA 262223/TAREFA 262333                     *      */
        /*"      *             - DE-PARA DE CODIGO DE PRODUTO                     *      */
        /*"      *             - DEBITO PARA O BANCO.                             *      */
        /*"      *               ( JV1 )                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/10/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR V.20 .       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 19 - DEMANDA 226662/TAREFA 247703                     *      */
        /*"      *               ALTERAR A QUANTIDADE DE DIAS PARA O ENVIO DO     *      */
        /*"      *               DEBITO PARA O BANCO.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/06/2020 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR V.19         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 18 - HISTORIA 216705                                  *      */
        /*"      *               ENVIAR DEBITO DA ADESAO COM A DATA DE VENCIMENTO *      */
        /*"      *               ESCOLHIDA PELO CLIENTE.                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/02/2020 - BRICE HO                                     *      */
        /*"      *                                       PROCURE POR V.18         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO 22/07/2019 - CLOVIS              -  PROCURAR V.17    *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  AJUSTA OPCAO COBERTURA.            *      */
        /*"      *   HISTORIA 199359                                              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 16 -  ADAILTON DIAS                                   *      */
        /*"      *               - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1    *      */
        /*"      *   EM 12/02/2019 - ATOS BR                                      *      */
        /*"      *                                       PROCURE POR JV1          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 15 -   CADMUS 152.120.                                *      */
        /*"      *               - ALTERAR A VALIDACAO REALIZADA PARA OS PRODUTOS *      */
        /*"      *                 CAIXA FACIL.                                   *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/08/2017 - FRANK CARVALHO                               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.15         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 14 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 11/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.14         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 13 - CAD71995/CAD74014/CAD81890/81704                 *      */
        /*"      *             - PERMITIR O PROCESSAMENTO DOS PRODUTOS ABAIXO     *      */
        /*"      *                                                                *      */
        /*"      *      BILHETE CRESCER                         -  8184           *      */
        /*"      *      CAIXA FACIL APOIO FAMILIA               -  8144           *      */
        /*"      *      CAIXA FACIL DESCONTOS REMEDIOS          -  8145           *      */
        /*"      *      CAIXA FACIL APOIO PROFISSIONAL          -  8146           *      */
        /*"      *      CAIXA FACIL SOS INFORMATICA             -  8147           *      */
        /*"      *      CAIXA FACIL VIAGEM SEGURA               -  8148           *      */
        /*"      *      CAIXA FACIL APOIO NUTRICAO              -  8149           *      */
        /*"      *      CAIXA FACIL REVISAO DO LAR              -  8150           *      */
        /*"      *      CAIXA CARTOES-NACIONAL E AZUL ELO       -  8185           *      */
        /*"      *      CAIXA CARTOES-PLATINUM/BLACK E INFINIT  -  8186           *      */
        /*"      *      CAIXA CARTOES-NACIONAL/AZUL MASTER E                      *      */
        /*"      *                    VISA/GOLD/INTERNACIONAL   -  8187           *      */
        /*"      *      CAIXA CARTOES-UNIVERSITARIO             -  8190           *      */
        /*"      *                                                                *      */
        /*"      *      EM 16/06/2013 - EDIVALDO GOMES   - FAST COMPUTER          *      */
        /*"      *                                       PROCURE POR V.13         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 12 - CAD 70.923                                       *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA CORRECAO DO ABEND      *      */
        /*"      *                 SQLCODE = -803 NA TABELA SEGUROS.V0MOVDEBCC_CEF*      */
        /*"      *                                                                *      */
        /*"      *   EM 15/06/2012 - MARCO PAIVA (FAST COMPUTER)                  *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.12         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 11 - CAD-68.235                                       *      */
        /*"      *                                                                *      */
        /*"      *             - CUSTOMIZACAO PARA O CANAL DE VENDA MAIS ESTUDO   *      */
        /*"      *               OS PROGRAMAS                                     *      */
        /*"      *                                                                *      */
        /*"      *                  . BI3600B                                     *      */
        /*"      *                  . BI3602B                                     *      */
        /*"      *                  . BI0030B                                     *      */
        /*"      *                  . BI0031B                                     *      */
        /*"      *                  . BI0422B                                     *      */
        /*"      *                  . BI0602B                                     *      */
        /*"      *                  . BI6032B                                     *      */
        /*"      *                  . BI7028B                                     *      */
        /*"      *                  . BI7029B                                     *      */
        /*"      *                                                                *      */
        /*"      *                FORAM PREPARADOS PARA TRABALHAR COM PARAMETROS  *      */
        /*"      *                DEFINIDOS NA SEGUROS.ARQUIVOS_SIVPF.                   */
        /*"      *                                                                *      */
        /*"      *   EM 14/04/2012 - TERCIO CARVALHO (FAST COMPUTER)              *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.11    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 10 - CAD 201.141                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA PARA TRATAR OS BILHETES     *      */
        /*"      *                 COMERCIALIZADOS NA LOJA FACIL ASSISTENCIA.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/08/2011 - BRUNO RIBEIRO (FAST COMPUTER)                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.10         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 09 - CAD 201.012                                      *      */
        /*"      *               - AJUSTE NO PROGRAMA                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/01/2011 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.09         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 50.292                                       *      */
        /*"      *                                                                *      */
        /*"      *              - RETIRADOS OS DISPLAYS PARA MONITORAMENTO        *      */
        /*"      *                DO PROGRAMA.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 17/11/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.08      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 - CAD 39.946/39.528                                *      */
        /*"      *                                                                *      */
        /*"      *              - PASSA A ATUALIZAR A DATA DE VENCIMENTO PARA     *      */
        /*"      *                5 DIAS UTEIS A FRENTE.                          *      */
        /*"      *                                                                *      */
        /*"      *              - O PROGRAMA ESTA CARIMBANDO COMO MARSH APOLICES  *      */
        /*"      *                QUE NAO TEM ORIGEM MARSH, GERANDO COBRANCA EM   *      */
        /*"      *                DUPLICIDADE.                                    *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2010 - TERCIO FREITAS (FAST COMPUTER)               *      */
        /*"      *                                          PROCURE POR V.07      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 02/03/2010 - FAST                -  PROCURAR V.06    *      */
        /*"      *                                                                *      */
        /*"      *     -  MANUTENCAO NO PROGRAMA PARA NAO DEIXAR ABENDAR NO       *      */
        /*"      *        UPDATE DE BILHETE QUANDO NAO ACHAR O BILHETE.           *      */
        /*"      *                                                                *      */
        /*"      *        CAD 38224.                         PROCURAR POR V.06    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 15/01/2009 - FAST                -  PROCURAR V.05    *      */
        /*"      *                                                                *      */
        /*"      *     -  MANUTENCAO NO CURSOR PRINCIPAL PARA CONSIDERAR          *      */
        /*"      *        REGISTROS NA MOVDEBCC_CEF COM SITUACAO EM BRANCO E      *      */
        /*"      *        DESCARTAR DEBITOS COM VENCIMENTO MENOR QUE DATA ATUAL.  *      */
        /*"      *                                                                *      */
        /*"      *        CAD 19143.                         PROCURAR POR V.05    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 07/02/2008 - CLOVIS              -  PROCURAR V.04    *      */
        /*"      *                                                                *      */
        /*"      *        A PARTIR DO MOMENTO QUE FORAM EMITIDOS BILHETES         *      */
        /*"      *        PARCELADOS O PROGRAMA ESTAVA ENVIANDO TODAS AS          *      */
        /*"      *        PARCELAS PARA DEBITO EM CONTA. COMO EXEMPLO SEGUE A     *      */
        /*"      *        APOLICE 0108100000247. FORAM ENVIADAS PARA DEBITO AS    *      */
        /*"      *        PARCELAS 02 ATE 12, COM VENCIMENTOS DE 25/02/2008 ATE   *      */
        /*"      *        25/12/2008.                                             *      */
        /*"      *                                                                *      */
        /*"      *        PASSA A UTILIZAR COMO PARAMETRO O CAMPO                 *      */
        /*"      *        V1SISTE-DTMOVABE-10 = DATA DO SISTEMA + 10 DIAS.        *      */
        /*"      *        PARCELAS COM VENCIMENTO MAIOR QUE V1SISTE-DTMOVABE-10   *      */
        /*"      *        NAO SERAO ENVIADAS.                                     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 21/01/2008 - FAST                -  PROCURAR V.03    *      */
        /*"      *                                                                *      */
        /*"      *     -  CONSISTE CONTA CORRENTE. ATUALIZA BILHETE E             *      */
        /*"      *        MOVDEBCC_CEF - DIGITO DA CONTA.                         *      */
        /*"      *                                           PROCURAR POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 17/01/2008 - FAST                -  PROCURAR V.02    *      */
        /*"      *                                                                *      */
        /*"      *     -  PESQUISA BILHETE COM SITUACAO = '9' - EMITIDA           *      */
        /*"      *        PARA BILHETES MARSH PARCELADOS.                         *      */
        /*"      *                                           PROCURAR POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 18/10/2007 - MARCO PAIVA         -  PROCURAR V.01    *      */
        /*"      *                                                                *      */
        /*"      *     -  A TABELA V0MOVDEBCC_CE FPARA A ATUALIZAR A COLUNA DE    *      */
        /*"      *          NUM_REQUISICAO                                        *      */
        /*"      *                                           PROCURAR POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 09/04/2007 - TERCIO CARVALHO     -  PROCURAR TL0704  *      */
        /*"      *                                                                *      */
        /*"      *     -  O PROGRAMA PASSA A NAO MAIS AJUSTAR A DATA DE           *      */
        /*"      *            VENCIMENTO UMA VEZ QUE O PROGRAMA BI0030B JA O FAZ. *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 29/05/2002 - TERCIO CARVALHO     -  PROCURAR TL0205  *      */
        /*"      *                                                                *      */
        /*"      *     -  O PROGRAMA PASSA A TRATAR LANCAMENTOS COM MENOS DE      *      */
        /*"      *            3 DIAS UTEIS FAZENDO A PRORROGACAO DO MESMO.        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO 07/03/2001 - ENRICO (PRODEXTER)  -  PROCURAR EB0703  *      */
        /*"      *                                                                *      */
        /*"      *     -  CORRECAO DOS "DISPLAYS" DE CONTROLE                     *      */
        /*"      *            DATA DA GERACAO DA FITA                             *      */
        /*"      *            DATA DO PROXIMO DEBITO                              *      */
        /*"      *            DATA DO VENCIMENTO                                  *      */
        /*"      *                                                                *      */
        /*"      *     -  SUBSTITUIR DATA DO SISTEMA "RN" PELA DATA CORRENTE      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO  .............  - ALTERACAO DA COLUNA COD_CONVENIO *      */
        /*"      *                               DE SMALLINT PARA INTEGER.        *      */
        /*"      *               LIANE PONTES  -  LP0301   EM:  14/03/2001.       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVDEBITO_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVDEBITO_CC
        {
            get
            {
                _.Move(HEADER_REGISTRO, _MOVDEBITO_CC); VarBasis.RedefinePassValue(HEADER_REGISTRO, _MOVDEBITO_CC, HEADER_REGISTRO); return _MOVDEBITO_CC;
            }
        }
        public FileBasis _RBI0031B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RBI0031B
        {
            get
            {
                _.Move(REG_BI0031B, _RBI0031B); VarBasis.RedefinePassValue(REG_BI0031B, _RBI0031B, REG_BI0031B); return _RBI0031B;
            }
        }
        /*"01        HEADER-REGISTRO.*/
        public BI0031B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new BI0031B_HEADER_REGISTRO();
        public class BI0031B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO  PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA   PIC  9(001).*/
            public IntBasis HEADER_CODREMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      HEADER-CODCONVENIO  PIC  X(020).*/
            public StringBasis HEADER_CODCONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(020).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  9(003).*/
            public IntBasis HEADER_CODBANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-NOMBANCO     PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO   PIC  9(008).*/
            public IntBasis HEADER_DATGERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      HEADER-NSA          PIC  9(006).*/
            public IntBasis HEADER_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO       PIC  9(002).*/
            public IntBasis HEADER_VERSAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      HEADER-DEBITOAUT    PIC  X(017).*/
            public StringBasis HEADER_DEBITOAUT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      HEADER-FILLER       PIC  X(052).*/
            public StringBasis HEADER_FILLER { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public BI0031B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI0031B_MOVCC_REGISTRO();
        public class BI0031B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO  PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP    PIC  X(025).*/
            public StringBasis MOVCC_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05      MOVCC-AGEDEBITO    PIC  X(004).*/
            public StringBasis MOVCC_AGEDEBITO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      MOVCC-IDTCLIBAN    PIC  X(019).*/
            public StringBasis MOVCC_IDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  05      MOVCC-DTVENCTO     PIC  9(008).*/
            public IntBasis MOVCC_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  05      MOVCC-VLRDEBITO    PIC  9(013)V99.*/
            public DoubleBasis MOVCC_VLRDEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-CODMOEDA     PIC  X(002).*/
            public StringBasis MOVCC_CODMOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-USOEMPRESA   PIC  X(058).*/
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "58", "X(058)."), @"");
            /*"  05      MOVCC-FILLER       PIC  X(017).*/
            public StringBasis MOVCC_FILLER { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      MOVCC-CODMOVTO     PIC  9(001).*/
            public IntBasis MOVCC_CODMOVTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public BI0031B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new BI0031B_TRAILL_REGISTRO();
        public class BI0031B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO  PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO  PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-VLRTOTCRE    PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER       PIC  X(109).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01        REG-BI0031B        PIC  X(132).*/
        }
        public StringBasis REG_BI0031B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WDATA-BASE-07                PIC X(10).*/
        public StringBasis WDATA_BASE_07 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-30          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE             PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-10          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTCURRENT            PIC X(10).*/
        public StringBasis V1SISTE_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1SISTE-DTMOVABE-FI          PIC X(10).*/
        public StringBasis V1SISTE_DTMOVABE_FI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V1EMPR-COD-EMP               PIC S9(004)     COMP.*/
        public IntBasis V1EMPR_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  V1EMPR-NOM-EMP               PIC  X(040).*/
        public StringBasis V1EMPR_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77  V0MOVDE-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-SIT-COBRANCA         PIC X(1).*/
        public StringBasis V0MOVDE_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0MOVDE-DTVENCTO             PIC X(10).*/
        public StringBasis V0MOVDE_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-VLR-DEBITO           PIC S9(13)V9(2) COMP-3.*/
        public DoubleBasis V0MOVDE_VLR_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"77  V0MOVDE-COD-AGENCIA-DEB      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_AGENCIA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-OPER-CONTA-DEB       PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_OPER_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NUM-CONTA-DEB        PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_NUM_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-DIG-CONTA-DEB        PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_DIG_CONTA_DEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-DTMOVTO              PIC X(10).*/
        public StringBasis V0MOVDE_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTENVIO              PIC X(10).*/
        public StringBasis V0MOVDE_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-DTRETORNO            PIC X(10).*/
        public StringBasis V0MOVDE_DTRETORNO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0MOVDE-COD-RETORNO-CEF      PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_COD_RETORNO_CEF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-SEQUENCIA            PIC S9(04) COMP.*/
        public IntBasis V0MOVDE_SEQUENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0MOVDE-REQUISICAO           PIC S9(13) COMP-3.*/
        public IntBasis V0MOVDE_REQUISICAO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0MOVDE-DAYS                 PIC S9(09) COMP.*/
        public IntBasis V0MOVDE_DAYS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0MOVDE-COD-USUARIO          PIC  X(08).*/
        public StringBasis V0MOVDE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V0PARAMC-TIPO-MOVTOCC         PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_TIPO_MOVTOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-CODPRODU             PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-CONVENIO         PIC S9(09) COMP.*/
        public IntBasis V0PARAMC_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0PARAMC-NSAS                 PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-COD-AGENCIA-SASS     PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_COD_AGENCIA_SASS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-DTPROX-DEB           PIC X(10).*/
        public StringBasis V0PARAMC_DTPROX_DEB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0PARAMC-DIA-DEBITO           PIC S9(04) COMP.*/
        public IntBasis V0PARAMC_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0PARAMC-SITUACAO             PIC X(1).*/
        public StringBasis V0PARAMC_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0BILH-NUMBIL                 PIC S9(15) COMP-3.*/
        public IntBasis V0BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0BILH-SITUACAO               PIC  X(01).*/
        public StringBasis V0BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1BILH-NUMBIL                 PIC S9(15) COMP-3.*/
        public IntBasis V1BILH_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V1BILH-SITUACAO               PIC  X(01).*/
        public StringBasis V1BILH_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77  V1BILH-COD-USUARIO            PIC  X(08).*/
        public StringBasis V1BILH_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77  V1BILH-COD-CLIENTE            PIC S9(09) COMP.*/
        public IntBasis V1BILH_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1BILH-OPC-COBER              PIC S9(04) COMP.*/
        public IntBasis V1BILH_OPC_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1BILH-RAMO                   PIC S9(04) COMP.*/
        public IntBasis V1BILH_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1BILH-COD-PRODUTO            PIC S9(04) COMP VALUE 0.*/
        public IntBasis V1BILH_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V1CLIEN-COD-CLIENTE          PIC S9(09) COMP.*/
        public IntBasis V1CLIEN_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V1CLIEN-NOME-RAZAO           PIC  X(40).*/
        public StringBasis V1CLIEN_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"01  W-TAB-SISTEMA-ORIGEM.*/
        public BI0031B_W_TAB_SISTEMA_ORIGEM W_TAB_SISTEMA_ORIGEM { get; set; } = new BI0031B_W_TAB_SISTEMA_ORIGEM();
        public class BI0031B_W_TAB_SISTEMA_ORIGEM : VarBasis
        {
            /*"    05  WTAB-SISTEMA-ORIGEM   OCCURS    200  TIMES                                PIC  S9(004) COMP.*/
            public ListBasis<IntBasis, Int64> WTAB_SISTEMA_ORIGEM { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("S9", "4", "S9(004)"), 200);
            /*"01           AREA-DE-WORK.*/
        }
        public BI0031B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0031B_AREA_DE_WORK();
        public class BI0031B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WIND                 PIC S9(004)    COMP VALUE +0.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WIND1                PIC S9(004)    COMP VALUE +0.*/
            public IntBasis WIND1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WINF                 PIC S9(004)    COMP VALUE +0.*/
            public IntBasis WINF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WSUP                 PIC S9(004)    COMP VALUE +0.*/
            public IntBasis WSUP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WTEM-SISTEMA-ORIGEM  PIC  X(003)    VALUE SPACES.*/
            public StringBasis WTEM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         IND-FLUXO-PARAM      PIC  X(001)    VALUE 'N'.*/
            public StringBasis IND_FLUXO_PARAM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  05         WS-SMALLINT          PIC ZZ.ZZ9- OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 5);
            /*"  05         WS-BIGINT            PIC 99999999999999                                              OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
            /*"  05         WFIMV1SISTEMA        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV1BILHETE        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV1BILHETE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0PARAM-CONTACEF PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0PARAM_CONTACEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIMV0MOVDEBCC-CEF   PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIMV0MOVDEBCC_CEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-SISTEMA-ORIGEM  PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_SISTEMA_ORIGEM { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05         WS-MARSH             PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_MARSH { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WPAG                 PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WPAG { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WLIN                 PIC  9(009)    VALUE 90.*/
            public IntBasis WLIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"), 90);
            /*"  05         WTOTPARAMC           PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTPARAMC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTMOVDE            PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WTOTMOVDE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WTOTREG              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTGER              PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WTOTGER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WTOTDEB              PIC  9(016)V99 VALUE ZEROS.*/
            public DoubleBasis WTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "16", "9(016)V99"), 2);
            /*"  05         WCOD-CONVENIO        PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis WCOD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05         WDATSIS              PIC  9(008)    VALUE ZEROS.*/
            public IntBasis WDATSIS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         WNSAS                PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WNSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05  LD-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05  LD-MOVDEBCE               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis LD_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05  DP-BILHETE                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05  DP-COBERTURA              PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_COBERTURA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05  DP-NEGATIVO               PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_NEGATIVO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05  DP-DTMAIOR                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_DTMAIOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05  DP-DTMENOR                PIC  9(007)         VALUE ZEROS.*/
            public IntBasis DP_DTMENOR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05         WIDTCLIBAN           PIC   X(019).*/
            public StringBasis WIDTCLIBAN { get; set; } = new StringBasis(new PIC("X", "19", "X(019)."), @"");
            /*"  05         FILLER        REDEFINES    WIDTCLIBAN.*/
            private _REDEF_BI0031B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0031B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0031B_FILLER_0(); _.Move(WIDTCLIBAN, _filler_0); VarBasis.RedefinePassValue(WIDTCLIBAN, _filler_0, WIDTCLIBAN); _filler_0.ValueChanged += () => { _.Move(_filler_0, WIDTCLIBAN); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WIDTCLIBAN); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_0 : VarBasis
            {
                /*"     10      WOPER-CONTA          PIC   9(004).*/
                public IntBasis WOPER_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WNUM-CONTA           PIC   9(012).*/
                public IntBasis WNUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"     10      WDIG-CONTA           PIC   9(001).*/
                public IntBasis WDIG_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"     10      WIDT-SPACES          PIC   X(002).*/
                public StringBasis WIDT_SPACES { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05         WIDTCLIEMP           PIC  X(025).*/

                public _REDEF_BI0031B_FILLER_0()
                {
                    WOPER_CONTA.ValueChanged += OnValueChanged;
                    WNUM_CONTA.ValueChanged += OnValueChanged;
                    WDIG_CONTA.ValueChanged += OnValueChanged;
                    WIDT_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WIDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"  05         FILLER        REDEFINES   WIDTCLIEMP.*/
            private _REDEF_BI0031B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_BI0031B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_BI0031B_FILLER_1(); _.Move(WIDTCLIEMP, _filler_1); VarBasis.RedefinePassValue(WIDTCLIEMP, _filler_1, WIDTCLIEMP); _filler_1.ValueChanged += () => { _.Move(_filler_1, WIDTCLIEMP); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WIDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_1 : VarBasis
            {
                /*"     10      WNUMBIL              PIC   9(015).*/
                public IntBasis WNUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"     10      WEMP-SPACES          PIC   X(010).*/
                public StringBasis WEMP_SPACES { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05         WS-IDTCLIEMP      PIC  X(025)    VALUE SPACES.*/

                public _REDEF_BI0031B_FILLER_1()
                {
                    WNUMBIL.ValueChanged += OnValueChanged;
                    WEMP_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDTCLIEMP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05         FILLER            REDEFINES      WS-IDTCLIEMP.*/
            private _REDEF_BI0031B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_BI0031B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_BI0031B_FILLER_2(); _.Move(WS_IDTCLIEMP, _filler_2); VarBasis.RedefinePassValue(WS_IDTCLIEMP, _filler_2, WS_IDTCLIEMP); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_IDTCLIEMP); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WS_IDTCLIEMP); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_2 : VarBasis
            {
                /*"    10       WNUMAPOL          PIC  9(013).*/
                public IntBasis WNUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10       WNRENDOS          PIC  9(006).*/
                public IntBasis WNRENDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10       WNRPARCEL         PIC  9(002).*/
                public IntBasis WNRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(004).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05         WDATA-CURR        PIC  X(010)    VALUE SPACES.*/

                public _REDEF_BI0031B_FILLER_2()
                {
                    WNUMAPOL.ValueChanged += OnValueChanged;
                    WNRENDOS.ValueChanged += OnValueChanged;
                    WNRPARCEL.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURR.*/
            private _REDEF_BI0031B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_BI0031B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_BI0031B_FILLER_4(); _.Move(WDATA_CURR, _filler_4); VarBasis.RedefinePassValue(WDATA_CURR, _filler_4, WDATA_CURR); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_CURR); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_4 : VarBasis
            {
                /*"    10       WDATA-AA-CURR     PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-CURR     PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-CURR     PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WHORA-CURR.*/

                public _REDEF_BI0031B_FILLER_4()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public BI0031B_WHORA_CURR WHORA_CURR { get; set; } = new BI0031B_WHORA_CURR();
            public class BI0031B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WDATA-CABEC.*/
            }
            public BI0031B_WDATA_CABEC WDATA_CABEC { get; set; } = new BI0031B_WDATA_CABEC();
            public class BI0031B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05         WHORA-CABEC.*/
            }
            public BI0031B_WHORA_CABEC WHORA_CABEC { get; set; } = new BI0031B_WHORA_CABEC();
            public class BI0031B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WUSOEMPRESA          PIC  X(060).*/
            }
            public StringBasis WUSOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05         FILLER        REDEFINES   WUSOEMPRESA.*/
            private _REDEF_BI0031B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_BI0031B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_BI0031B_FILLER_11(); _.Move(WUSOEMPRESA, _filler_11); VarBasis.RedefinePassValue(WUSOEMPRESA, _filler_11, WUSOEMPRESA); _filler_11.ValueChanged += () => { _.Move(_filler_11, WUSOEMPRESA); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WUSOEMPRESA); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_11 : VarBasis
            {
                /*"     10      WUSO-CONVENIO        PIC   9(006).*/
                public IntBasis WUSO_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-NSAS            PIC   9(006).*/
                public IntBasis WUSO_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SEQFITA         PIC   9(006).*/
                public IntBasis WUSO_SEQFITA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"     10      WUSO-SPACES          PIC   X(042).*/
                public StringBasis WUSO_SPACES { get; set; } = new StringBasis(new PIC("X", "42", "X(042)."), @"");
                /*"  05         WDATA-DEBITO         PIC   X(010).*/

                public _REDEF_BI0031B_FILLER_11()
                {
                    WUSO_CONVENIO.ValueChanged += OnValueChanged;
                    WUSO_NSAS.ValueChanged += OnValueChanged;
                    WUSO_SEQFITA.ValueChanged += OnValueChanged;
                    WUSO_SPACES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         WDATA-SQL            PIC   X(010).*/
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         FILLER        REDEFINES   WDATA-SQL.*/
            private _REDEF_BI0031B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_BI0031B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_BI0031B_FILLER_12(); _.Move(WDATA_SQL, _filler_12); VarBasis.RedefinePassValue(WDATA_SQL, _filler_12, WDATA_SQL); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_SQL); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_12 : VarBasis
            {
                /*"     10      WANO-SQL             PIC   9(004).*/
                public IntBasis WANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WMES-SQL             PIC   9(002).*/
                public IntBasis WMES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      FILLER               PIC   X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10      WDIA-SQL             PIC   9(002).*/
                public IntBasis WDIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         WDATATRA             PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_BI0031B_FILLER_12()
                {
                    WANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WMES_SQL.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATATRA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER        REDEFINES   WDATATRA.*/
            private _REDEF_BI0031B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_BI0031B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_BI0031B_FILLER_15(); _.Move(WDATATRA, _filler_15); VarBasis.RedefinePassValue(WDATATRA, _filler_15, WDATATRA); _filler_15.ValueChanged += () => { _.Move(_filler_15, WDATATRA); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WDATATRA); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_15 : VarBasis
            {
                /*"     10      WANO-TRA            PIC   9(004).*/
                public IntBasis WANO_TRA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10      WMES-TRA            PIC   9(002).*/
                public IntBasis WMES_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10      WDIA-TRA            PIC   9(002).*/
                public IntBasis WDIA_TRA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        W05-COD-PRODUTO    PIC  9(004)      VALUE ZEROS.*/

                public _REDEF_BI0031B_FILLER_15()
                {
                    WANO_TRA.ValueChanged += OnValueChanged;
                    WMES_TRA.ValueChanged += OnValueChanged;
                    WDIA_TRA.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W05_COD_PRODUTO { get; set; } = new SelectorBasis("004", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88         PAG-ANTECIPADO                VALUE 8153. */
							new SelectorItemBasis("PAG_ANTECIPADO", "8153"),
							/*" 88         CANAL-ELETRONICO              VALUE                  8144 ,  8145 ,  8146 ,  8147 ,  8148 ,                  8149 ,  8150 ,  8152 ,  8153,                  8521 ,  8526 ,  8524 ,  8525 ,  8527 ,                  8523 ,  8522,                  8530. */
							new SelectorItemBasis("CANAL_ELETRONICO", "8144 ,8145 ,8146 ,8147 ,8148 ,8149 ,8150 ,8152 ,8153,8521 ,8526 ,8524 ,8525 ,8527 ,8523 ,8522,8530")
                }
            };

            /*"  05         WDATA-DISPLAY        PIC   X(010).*/
            public StringBasis WDATA_DISPLAY { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         LPARM.*/
            public BI0031B_LPARM LPARM { get; set; } = new BI0031B_LPARM();
            public class BI0031B_LPARM : VarBasis
            {
                /*"    10       DATA1.*/
                public BI0031B_DATA1 DATA1 { get; set; } = new BI0031B_DATA1();
                public class BI0031B_DATA1 : VarBasis
                {
                    /*"      15     DATA1-DD          PIC  9(002).*/
                    public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-MM          PIC  9(002).*/
                    public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     DATA1-AA          PIC  9(004).*/
                    public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10       RESPOSTA          PIC  X(001).*/
                }
                public StringBasis RESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05         LPARM2.*/
            }
            public BI0031B_LPARM2 LPARM2 { get; set; } = new BI0031B_LPARM2();
            public class BI0031B_LPARM2 : VarBasis
            {
                /*"    10       DATA2             PIC  9(008).*/
                public IntBasis DATA2 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DATA2-R           REDEFINES             DATA2.*/
                private _REDEF_BI0031B_DATA2_R _data2_r { get; set; }
                public _REDEF_BI0031B_DATA2_R DATA2_R
                {
                    get { _data2_r = new _REDEF_BI0031B_DATA2_R(); _.Move(DATA2, _data2_r); VarBasis.RedefinePassValue(DATA2, _data2_r, DATA2); _data2_r.ValueChanged += () => { _.Move(_data2_r, DATA2); }; return _data2_r; }
                    set { VarBasis.RedefinePassValue(value, _data2_r, DATA2); }
                }  //Redefines
                public class _REDEF_BI0031B_DATA2_R : VarBasis
                {
                    /*"      15     DATA2-DD          PIC  X(002).*/
                    public StringBasis DATA2_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA2-MM          PIC  X(002).*/
                    public StringBasis DATA2_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA2-AA          PIC  X(004).*/
                    public StringBasis DATA2_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"    10       QUANTIDA          PIC S9(005)  COMP-3  VALUE +1.*/

                    public _REDEF_BI0031B_DATA2_R()
                    {
                        DATA2_DD.ValueChanged += OnValueChanged;
                        DATA2_MM.ValueChanged += OnValueChanged;
                        DATA2_AA.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis QUANTIDA { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"), +1);
                /*"    10       DATA3             PIC  9(008).*/
                public IntBasis DATA3 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       DATA3-R           REDEFINES             DATA3.*/
                private _REDEF_BI0031B_DATA3_R _data3_r { get; set; }
                public _REDEF_BI0031B_DATA3_R DATA3_R
                {
                    get { _data3_r = new _REDEF_BI0031B_DATA3_R(); _.Move(DATA3, _data3_r); VarBasis.RedefinePassValue(DATA3, _data3_r, DATA3); _data3_r.ValueChanged += () => { _.Move(_data3_r, DATA3); }; return _data3_r; }
                    set { VarBasis.RedefinePassValue(value, _data3_r, DATA3); }
                }  //Redefines
                public class _REDEF_BI0031B_DATA3_R : VarBasis
                {
                    /*"      15     DATA3-DD          PIC  X(002).*/
                    public StringBasis DATA3_DD { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA3-MM          PIC  X(002).*/
                    public StringBasis DATA3_MM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"      15     DATA3-AA          PIC  X(004).*/
                    public StringBasis DATA3_AA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                    /*"  05            LC01.*/

                    public _REDEF_BI0031B_DATA3_R()
                    {
                        DATA3_DD.ValueChanged += OnValueChanged;
                        DATA3_MM.ValueChanged += OnValueChanged;
                        DATA3_AA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public BI0031B_LC01 LC01 { get; set; } = new BI0031B_LC01();
            public class BI0031B_LC01 : VarBasis
            {
                /*"    10          LC01-RELATORIO  PIC  X(007) VALUE 'BI0031B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"BI0031B");
                /*"    10          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    10          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  05            LC02.*/
            }
            public BI0031B_LC02 LC02 { get; set; } = new BI0031B_LC02();
            public class BI0031B_LC02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    10          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    10          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  05            LC03.*/
            }
            public BI0031B_LC03 LC03 { get; set; } = new BI0031B_LC03();
            public class BI0031B_LC03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(025) VALUE  SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10          FILLER          PIC  X(053) VALUE               'RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE DEBIT               'O - '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"RELACAO DE DOCUMENTOS ENVIADOS PELA FITA DE DEBIT               ");
                /*"    10          FILLER          PIC  X(018) VALUE 'C.E.F.'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"C.E.F.");
                /*"    10          FILLER          PIC  X(003) VALUE 'EM'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"EM");
                /*"    10          LC03-DATA       PIC  X(010).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    10          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public BI0031B_LC04 LC04 { get; set; } = new BI0031B_LC04();
            public class BI0031B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LC05.*/
            }
            public BI0031B_LC05 LC05 { get; set; } = new BI0031B_LC05();
            public class BI0031B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048)  VALUE      '          APOLICE    ENDOSSO PARC DT.VENC. DIA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"          APOLICE    ENDOSSO PARC DT.VENC. DIA");
                /*"    10          FILLER          PIC  X(026)  VALUE      '----- C/C DEBITADA -----'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"----- C/C DEBITADA -----");
                /*"    10          FILLER          PIC  X(053)  VALUE      'NOME DO SEGURADO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"NOME DO SEGURADO");
                /*"    10          FILLER          PIC  X(005)  VALUE      'VALOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"VALOR");
                /*"  05            LC06.*/
            }
            public BI0031B_LC06 LC06 { get; set; } = new BI0031B_LC06();
            public class BI0031B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          FILLER          PIC  X(011) VALUE    'FITA  NR.: '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"FITA  NR.: ");
                /*"    10          LC06-NRFITA     PIC  ZZZZZZZZZ9.*/
                public IntBasis LC06_NRFITA { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"  05            LC07.*/
            }
            public BI0031B_LC07 LC07 { get; set; } = new BI0031B_LC07();
            public class BI0031B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(132) VALUE  ALL ' '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  05            LD01.*/
            }
            public BI0031B_LD01 LD01 { get; set; } = new BI0031B_LD01();
            public class BI0031B_LD01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(004) VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10          LD01-NUMBIL     PIC  9(013).*/
                public IntBasis LD01_NUMBIL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NRENDOS    PIC  9(009).*/
                public IntBasis LD01_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NRPARCEL   PIC  9(002).*/
                public IntBasis LD01_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DTVENCTO   PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10          FILLER          PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-DIA-DEBITO PIC  9(002).*/
                public IntBasis LD01_DIA_DEBITO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-DEBITO.*/
                public BI0031B_LD01_DEBITO LD01_DEBITO { get; set; } = new BI0031B_LD01_DEBITO();
                public class BI0031B_LD01_DEBITO : VarBasis
                {
                    /*"      15        LD01-AGENCIA    PIC  9(004).*/
                    public IntBasis LD01_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        FILLER          PIC  X(001) VALUE SPACES.*/
                    public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"      15        LD01-OPERACAO   PIC  9(004).*/
                    public IntBasis LD01_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15        LD01-BARRA      PIC  X(001).*/
                    public StringBasis LD01_BARRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-CONTA      PIC  9(012).*/
                    public IntBasis LD01_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15        LD01-HIFEN1     PIC  X(001).*/
                    public StringBasis LD01_HIFEN1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15        LD01-DIGITO     PIC  9(001).*/
                    public IntBasis LD01_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                }
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-NOME       PIC  X(037).*/
                public StringBasis LD01_NOME { get; set; } = new StringBasis(new PIC("X", "37", "X(037)."), @"");
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LD01-VLDEBITO   PIC  ZZZZ.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLDEBITO { get; set; } = new DoubleBasis(new PIC("9", "13", "ZZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05            LD02.*/
            }
            public BI0031B_LD02 LD02 { get; set; } = new BI0031B_LD02();
            public class BI0031B_LD02 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE ALL '*'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"ALL");
                /*"  05            LD03.*/
            }
            public BI0031B_LD03 LD03 { get; set; } = new BI0031B_LD03();
            public class BI0031B_LD03 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*  NAO HOUVE MOVIMENTO NESTA DATA  *'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*  NAO HOUVE MOVIMENTO NESTA DATA  *");
                /*"  05            LD04.*/
            }
            public BI0031B_LD04 LD04 { get; set; } = new BI0031B_LD04();
            public class BI0031B_LD04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10          FILLER          PIC  X(036) VALUE    '*                                  *'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"*                                  *");
                /*"  05            LT01.*/
            }
            public BI0031B_LT01 LT01 { get; set; } = new BI0031B_LT01();
            public class BI0031B_LT01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(074) VALUE SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"");
                /*"    10          FILLER          PIC  X(032) VALUE 'TOTAIS'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"TOTAIS");
                /*"    10          LT01-QT-TOTAL   PIC  ZZZZ.ZZ9.*/
                public IntBasis LT01_QT_TOTAL { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10          LT01-VL-TOTAL   PIC  Z.ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT01_VL_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "10", "Z.ZZZ.ZZZ.ZZ9V99."), 2);
                /*"  05        WABEND.*/
            }
            public BI0031B_WABEND WABEND { get; set; } = new BI0031B_WABEND();
            public class BI0031B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0031B'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0031B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  05        WPARAGRAFO          PIC  X(040)    VALUE SPACES.*/
            }
            public StringBasis WPARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"01          LK-CONSISTE-CONTA.*/
        }
        public BI0031B_LK_CONSISTE_CONTA LK_CONSISTE_CONTA { get; set; } = new BI0031B_LK_CONSISTE_CONTA();
        public class BI0031B_LK_CONSISTE_CONTA : VarBasis
        {
            /*"  03  WS-CTA-ERRO               PIC  X(001)  VALUE SPACES.*/
            public StringBasis WS_CTA_ERRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03  WPARM15-AUX               PIC S9(009)  VALUE ZEROS COMP.*/
            public IntBasis WPARM15_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WQUOCIENTE                PIC S9(004)  VALUE ZEROS COMP.*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WRESTO                    PIC S9(004)  VALUE ZEROS COMP.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-DIGCONTA               PIC  9(001)  VALUE ZEROS.*/
            public IntBasis WS_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03        WS-NUMERO           PIC  9(015)  VALUE   ZEROS.*/
            public IntBasis WS_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03        FILLER              REDEFINES    WS-NUMERO.*/
            private _REDEF_BI0031B_FILLER_56 _filler_56 { get; set; }
            public _REDEF_BI0031B_FILLER_56 FILLER_56
            {
                get { _filler_56 = new _REDEF_BI0031B_FILLER_56(); _.Move(WS_NUMERO, _filler_56); VarBasis.RedefinePassValue(WS_NUMERO, _filler_56, WS_NUMERO); _filler_56.ValueChanged += () => { _.Move(_filler_56, WS_NUMERO); }; return _filler_56; }
                set { VarBasis.RedefinePassValue(value, _filler_56, WS_NUMERO); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_56 : VarBasis
            {
                /*"    10      WS-AGENCIA          PIC  9(004).*/
                public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-OPERACAO         PIC  9(003).*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WS-NUMCONTA         PIC  9(008).*/
                public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03        LPARM15X.*/

                public _REDEF_BI0031B_FILLER_56()
                {
                    WS_AGENCIA.ValueChanged += OnValueChanged;
                    WS_OPERACAO.ValueChanged += OnValueChanged;
                    WS_NUMCONTA.ValueChanged += OnValueChanged;
                }

            }
            public BI0031B_LPARM15X LPARM15X { get; set; } = new BI0031B_LPARM15X();
            public class BI0031B_LPARM15X : VarBasis
            {
                /*"    10      LPARM15             PIC  9(015).*/
                public IntBasis LPARM15 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10      FILLER              REDEFINES   LPARM15.*/
                private _REDEF_BI0031B_FILLER_57 _filler_57 { get; set; }
                public _REDEF_BI0031B_FILLER_57 FILLER_57
                {
                    get { _filler_57 = new _REDEF_BI0031B_FILLER_57(); _.Move(LPARM15, _filler_57); VarBasis.RedefinePassValue(LPARM15, _filler_57, LPARM15); _filler_57.ValueChanged += () => { _.Move(_filler_57, LPARM15); }; return _filler_57; }
                    set { VarBasis.RedefinePassValue(value, _filler_57, LPARM15); }
                }  //Redefines
                public class _REDEF_BI0031B_FILLER_57 : VarBasis
                {
                    /*"      15    LPARM15-1           PIC  9(001).*/
                    public IntBasis LPARM15_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-2           PIC  9(001).*/
                    public IntBasis LPARM15_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-3           PIC  9(001).*/
                    public IntBasis LPARM15_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-4           PIC  9(001).*/
                    public IntBasis LPARM15_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-5           PIC  9(001).*/
                    public IntBasis LPARM15_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-6           PIC  9(001).*/
                    public IntBasis LPARM15_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-7           PIC  9(001).*/
                    public IntBasis LPARM15_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-8           PIC  9(001).*/
                    public IntBasis LPARM15_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-9           PIC  9(001).*/
                    public IntBasis LPARM15_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-10          PIC  9(001).*/
                    public IntBasis LPARM15_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-11          PIC  9(001).*/
                    public IntBasis LPARM15_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-12          PIC  9(001).*/
                    public IntBasis LPARM15_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-13          PIC  9(001).*/
                    public IntBasis LPARM15_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-14          PIC  9(001).*/
                    public IntBasis LPARM15_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LPARM15-15          PIC  9(001).*/
                    public IntBasis LPARM15_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"    10      LPARM15-D1          PIC  9(001).*/

                    public _REDEF_BI0031B_FILLER_57()
                    {
                        LPARM15_1.ValueChanged += OnValueChanged;
                        LPARM15_2.ValueChanged += OnValueChanged;
                        LPARM15_3.ValueChanged += OnValueChanged;
                        LPARM15_4.ValueChanged += OnValueChanged;
                        LPARM15_5.ValueChanged += OnValueChanged;
                        LPARM15_6.ValueChanged += OnValueChanged;
                        LPARM15_7.ValueChanged += OnValueChanged;
                        LPARM15_8.ValueChanged += OnValueChanged;
                        LPARM15_9.ValueChanged += OnValueChanged;
                        LPARM15_10.ValueChanged += OnValueChanged;
                        LPARM15_11.ValueChanged += OnValueChanged;
                        LPARM15_12.ValueChanged += OnValueChanged;
                        LPARM15_13.ValueChanged += OnValueChanged;
                        LPARM15_14.ValueChanged += OnValueChanged;
                        LPARM15_15.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis LPARM15_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05            WDATA-SQL1           PIC   X(010).*/
            }
            public StringBasis WDATA_SQL1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05            FILLER               REDEFINES        WDATA-SQL1*/
            private _REDEF_BI0031B_FILLER_58 _filler_58 { get; set; }
            public _REDEF_BI0031B_FILLER_58 FILLER_58
            {
                get { _filler_58 = new _REDEF_BI0031B_FILLER_58(); _.Move(WDATA_SQL1, _filler_58); VarBasis.RedefinePassValue(WDATA_SQL1, _filler_58, WDATA_SQL1); _filler_58.ValueChanged += () => { _.Move(_filler_58, WDATA_SQL1); }; return _filler_58; }
                set { VarBasis.RedefinePassValue(value, _filler_58, WDATA_SQL1); }
            }  //Redefines
            public class _REDEF_BI0031B_FILLER_58 : VarBasis
            {
                /*"     10         WANO-SQL1            PIC   9(004).*/
                public IntBasis WANO_SQL1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10         FILLER               PIC   X(001).*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10         WMES-SQL1            PIC   9(002).*/
                public IntBasis WMES_SQL1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10         FILLER               PIC   X(001).*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10         WDIA-SQL1            PIC   9(002).*/
                public IntBasis WDIA_SQL1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          LK-LINK.*/

                public _REDEF_BI0031B_FILLER_58()
                {
                    WANO_SQL1.ValueChanged += OnValueChanged;
                    FILLER_59.ValueChanged += OnValueChanged;
                    WMES_SQL1.ValueChanged += OnValueChanged;
                    FILLER_60.ValueChanged += OnValueChanged;
                    WDIA_SQL1.ValueChanged += OnValueChanged;
                }

            }
        }
        public BI0031B_LK_LINK LK_LINK { get; set; } = new BI0031B_LK_LINK();
        public class BI0031B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01           GE0006S-LINKAGE.*/
        }
        public BI0031B_GE0006S_LINKAGE GE0006S_LINKAGE { get; set; } = new BI0031B_GE0006S_LINKAGE();
        public class BI0031B_GE0006S_LINKAGE : VarBasis
        {
            /*"  05         GE0006S-DATA-DESTINO    PIC  X(010).*/
            public StringBasis GE0006S_DATA_DESTINO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         GE0006S-QTDDIAS         PIC  9(004).*/
            public IntBasis GE0006S_QTDDIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05         GE0006S-MENSAGEM        PIC  X(070).*/
            public StringBasis GE0006S_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }


        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.BILERROS BILERROS { get; set; } = new Dclgens.BILERROS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public BI0031B_V0PARAMC V0PARAMC { get; set; } = new BI0031B_V0PARAMC();
        public BI0031B_V0MOVDE V0MOVDE { get; set; } = new BI0031B_V0MOVDE();
        public BI0031B_CORIGEM CORIGEM { get; set; } = new BI0031B_CORIGEM();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVDEBITO_CC_FILE_NAME_P, string RBI0031B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVDEBITO_CC.SetFile(MOVDEBITO_CC_FILE_NAME_P);
                RBI0031B.SetFile(RBI0031B_FILE_NAME_P);

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
            /*" -797- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -798- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -800- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -802- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -805- DISPLAY '------------------------------------' . */
            _.Display($"------------------------------------");

            /*" -806- DISPLAY 'PROGRAMA EM EXECUCAO BI0031B   ' . */
            _.Display($"PROGRAMA EM EXECUCAO BI0031B   ");

            /*" -807- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -808- DISPLAY 'VERSAO V.23 575.149 04/07/2024 ' . */
            _.Display($"VERSAO V.23 575.149 04/07/2024 ");

            /*" -809- DISPLAY 'COMPILADO EM ' FUNCTION WHEN-COMPILED. */

            $"COMPILADO EM FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -811- DISPLAY '------------------------------------' . */
            _.Display($"------------------------------------");

            /*" -812- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -813- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -814- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -815- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -817- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -819- ACCEPT WDATSIS FROM DATE. */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WDATSIS);

            /*" -821- OPEN OUTPUT MOVDEBITO-CC RBI0031B. */
            MOVDEBITO_CC.Open(HEADER_REGISTRO);
            RBI0031B.Open(REG_BI0031B);

            /*" -822- PERFORM R0010-00-SELECT-V1SISTEMA */

            R0010_00_SELECT_V1SISTEMA_SECTION();

            /*" -823- IF WFIMV1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIMV1SISTEMA.IsEmpty())
            {

                /*" -825- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -827- PERFORM R0200-00-CARREGA-ORIGEM. */

            R0200_00_CARREGA_ORIGEM_SECTION();

            /*" -829- PERFORM R0015-00-MONTA-V1EMPRESA. */

            R0015_00_MONTA_V1EMPRESA_SECTION();

            /*" -830- MOVE SPACES TO WFIMV0PARAM-CONTACEF */
            _.Move("", AREA_DE_WORK.WFIMV0PARAM_CONTACEF);

            /*" -831- PERFORM R0020-00-DECLARE-V0PARAM-CONTA. */

            R0020_00_DECLARE_V0PARAM_CONTA_SECTION();

            /*" -832- PERFORM R0060-00-LE-V0PARAM-CONTACEF. */

            R0060_00_LE_V0PARAM_CONTACEF_SECTION();

            /*" -833- IF WFIMV0PARAM-CONTACEF EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S")
            {

                /*" -835- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -838- PERFORM R0050-00-PROCE-V0PARAM-CONTA UNTIL WFIMV0PARAM-CONTACEF EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIMV0PARAM_CONTACEF == "S"))
            {

                R0050_00_PROCE_V0PARAM_CONTA_SECTION();
            }

            /*" -839- IF WTOTMOVDE GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE > 00)
            {

                /*" -840- PERFORM R0080-00-REGISTRO-TRAILLER */

                R0080_00_REGISTRO_TRAILLER_SECTION();

                /*" -840- PERFORM R0170-00-TOTALIZADOR. */

                R0170_00_TOTALIZADOR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -845- IF WTOTMOVDE GREATER ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE > 00)
            {

                /*" -847- DISPLAY '*** BI0031B *** DATA GERACAO DA FITA ' WDATSIS */
                _.Display($"*** BI0031B *** DATA GERACAO DA FITA {AREA_DE_WORK.WDATSIS}");

                /*" -849- DISPLAY '*** BI0031B *** QUANTIDADE           ' WTOTREG */
                _.Display($"*** BI0031B *** QUANTIDADE           {AREA_DE_WORK.WTOTREG}");

                /*" -851- DISPLAY '*** BI0031B *** VALOR TOTAL          ' WTOTDEB */
                _.Display($"*** BI0031B *** VALOR TOTAL          {AREA_DE_WORK.WTOTDEB}");

                /*" -853- DISPLAY '*** BI0031B *** NSA                  ' WNSAS */
                _.Display($"*** BI0031B *** NSA                  {AREA_DE_WORK.WNSAS}");

                /*" -854- DISPLAY ' ' */
                _.Display($" ");

                /*" -855- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -856- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -857- DISPLAY '* BI0031B - TERMINO NORMAL DE       *' */
                _.Display($"* BI0031B - TERMINO NORMAL DE       *");

                /*" -858- DISPLAY '*             PROCESSAMENTO         *' */
                _.Display($"*             PROCESSAMENTO         *");

                /*" -859- DISPLAY '*                                   *' */
                _.Display($"*                                   *");

                /*" -860- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -861- ELSE */
            }
            else
            {


                /*" -862- PERFORM R0160-00-CABECALHOS */

                R0160_00_CABECALHOS_SECTION();

                /*" -863- PERFORM R0180-00-RELAT-SEM-MOVTO */

                R0180_00_RELAT_SEM_MOVTO_SECTION();

                /*" -864- DISPLAY '******************************' */
                _.Display($"******************************");

                /*" -865- DISPLAY '* BI0031B - SEM MOVIMENTACAO *' */
                _.Display($"* BI0031B - SEM MOVIMENTACAO *");

                /*" -867- DISPLAY '******************************' . */
                _.Display($"******************************");
            }


            /*" -869- CLOSE MOVDEBITO-CC */
            MOVDEBITO_CC.Close();

            /*" -869- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -871- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -871- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-SECTION */
        private void R0010_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -878- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -881- MOVE 'R0010-00-SELECT-V1SISTEMA' TO WPARAGRAFO. */
            _.Move("R0010-00-SELECT-V1SISTEMA", AREA_DE_WORK.WPARAGRAFO);

            /*" -892- PERFORM R0010_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0010_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -895- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -896- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -897- DISPLAY 'BI0031B - SISTEMA (EM) NAO CADASTRADO' */
                    _.Display($"BI0031B - SISTEMA (EM) NAO CADASTRADO");

                    /*" -898- MOVE 'S' TO WFIMV1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIMV1SISTEMA);

                    /*" -899- ELSE */
                }
                else
                {


                    /*" -900- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -902- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -903- MOVE V1SISTE-DTMOVABE TO WDATA-SQL1 */
            _.Move(V1SISTE_DTMOVABE, LK_CONSISTE_CONTA.WDATA_SQL1);

            /*" -904- MOVE 07 TO GE0006S-QTDDIAS */
            _.Move(07, GE0006S_LINKAGE.GE0006S_QTDDIAS);

            /*" -905- PERFORM R0012-00-VALIDA-DATA */

            R0012_00_VALIDA_DATA_SECTION();

            /*" -907- MOVE WDATA-SQL1 TO WDATA-BASE-07 */
            _.Move(LK_CONSISTE_CONTA.WDATA_SQL1, WDATA_BASE_07);

            /*" -908- MOVE V1SISTE-DTCURRENT TO WDATA-CURR */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_CURR);

            /*" -909- MOVE WDATA-DD-CURR TO WDATA-DD-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_4.WDATA_DD_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -910- MOVE WDATA-MM-CURR TO WDATA-MM-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_4.WDATA_MM_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -911- MOVE WDATA-AA-CURR TO WDATA-AA-CABEC. */
            _.Move(AREA_DE_WORK.FILLER_4.WDATA_AA_CURR, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -911- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

        }

        [StopWatch]
        /*" R0010-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0010_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -892- EXEC SQL SELECT DTMOVABE, CURRENT DATE, DTMOVABE + 10 DAYS, DTMOVABE - 30 DAYS INTO :V1SISTE-DTMOVABE, :V1SISTE-DTCURRENT, :V1SISTE-DTMOVABE-10, :V1SISTE-DTMOVABE-30 FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'EM' END-EXEC. */

            var r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0010_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTE_DTMOVABE, V1SISTE_DTMOVABE);
                _.Move(executed_1.V1SISTE_DTCURRENT, V1SISTE_DTCURRENT);
                _.Move(executed_1.V1SISTE_DTMOVABE_10, V1SISTE_DTMOVABE_10);
                _.Move(executed_1.V1SISTE_DTMOVABE_30, V1SISTE_DTMOVABE_30);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0012-00-VALIDA-DATA-SECTION */
        private void R0012_00_VALIDA_DATA_SECTION()
        {
            /*" -921- MOVE '0012' TO WNR-EXEC-SQL. */
            _.Move("0012", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -924- MOVE 'R0012-00-VALIDA-DATA    ' TO WPARAGRAFO */
            _.Move("R0012-00-VALIDA-DATA    ", AREA_DE_WORK.WPARAGRAFO);

            /*" -925- MOVE WDATA-SQL1 TO GE0006S-DATA-DESTINO. */
            _.Move(LK_CONSISTE_CONTA.WDATA_SQL1, GE0006S_LINKAGE.GE0006S_DATA_DESTINO);

            /*" -927- MOVE SPACES TO GE0006S-MENSAGEM. */
            _.Move("", GE0006S_LINKAGE.GE0006S_MENSAGEM);

            /*" -929- CALL 'GE0006S' USING GE0006S-LINKAGE. */
            _.Call("GE0006S", GE0006S_LINKAGE);

            /*" -930- IF GE0006S-MENSAGEM EQUAL SPACES */

            if (GE0006S_LINKAGE.GE0006S_MENSAGEM.IsEmpty())
            {

                /*" -931- MOVE GE0006S-DATA-DESTINO TO WDATA-SQL1 */
                _.Move(GE0006S_LINKAGE.GE0006S_DATA_DESTINO, LK_CONSISTE_CONTA.WDATA_SQL1);

                /*" -932- ELSE */
            }
            else
            {


                /*" -933- DISPLAY 'PROBLEMA NA ROTINA GE0006S' */
                _.Display($"PROBLEMA NA ROTINA GE0006S");

                /*" -934- DISPLAY 'MENSAGEM -->' GE0006S-MENSAGEM */
                _.Display($"MENSAGEM -->{GE0006S_LINKAGE.GE0006S_MENSAGEM}");

                /*" -935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -935- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0012_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-SECTION */
        private void R0015_00_MONTA_V1EMPRESA_SECTION()
        {
            /*" -945- MOVE '0015' TO WNR-EXEC-SQL. */
            _.Move("0015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -948- MOVE 'R0015-00-MONTA-V1EMPRESA' TO WPARAGRAFO */
            _.Move("R0015-00-MONTA-V1EMPRESA", AREA_DE_WORK.WPARAGRAFO);

            /*" -952- PERFORM R0015_00_MONTA_V1EMPRESA_DB_SELECT_1 */

            R0015_00_MONTA_V1EMPRESA_DB_SELECT_1();

            /*" -955- MOVE V1EMPR-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPR_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -957- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -958- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -959- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -960- ELSE */
            }
            else
            {


                /*" -961- DISPLAY 'PROBLEMA CALL PROALN01' */
                _.Display($"PROBLEMA CALL PROALN01");

                /*" -961- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0015-00-MONTA-V1EMPRESA-DB-SELECT-1 */
        public void R0015_00_MONTA_V1EMPRESA_DB_SELECT_1()
        {
            /*" -952- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPR-NOM-EMP FROM SEGUROS.V0EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1 = new R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1.Execute(r0015_00_MONTA_V1EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPR_NOM_EMP, V1EMPR_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-SECTION */
        private void R0020_00_DECLARE_V0PARAM_CONTA_SECTION()
        {
            /*" -971- MOVE '0020' TO WNR-EXEC-SQL */
            _.Move("0020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -974- MOVE 'R0020-00-DECLARE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0020-00-DECLARE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -975- MOVE 01 TO V0PARAMC-TIPO-MOVTOCC */
            _.Move(01, V0PARAMC_TIPO_MOVTOCC);

            /*" -977- MOVE 'A' TO V0PARAMC-SITUACAO */
            _.Move("A", V0PARAMC_SITUACAO);

            /*" -991- PERFORM R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1 */

            R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1();

            /*" -993- PERFORM R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1 */

            R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1();

            /*" -996- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -997- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -998- DISPLAY 'PROBLEMAS DECLARE V0PARAM_CONTACEF' */
                _.Display($"PROBLEMAS DECLARE V0PARAM_CONTACEF");

                /*" -998- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-DB-DECLARE-1 */
        public void R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1()
        {
            /*" -991- EXEC SQL DECLARE V0PARAMC CURSOR FOR SELECT TIPO_MOVTOCC, CODPRODU, COD_CONVENIO, NSAS, COD_AGENCIA_SASS, DTPROX_DEB, DIA_DEBITO FROM SEGUROS.V0PARAM_CONTACEF WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND SITUACAO = :V0PARAMC-SITUACAO AND COD_CONVENIO = 6114 AND CODPRODU = 7106 ORDER BY COD_CONVENIO END-EXEC. */
            V0PARAMC = new BI0031B_V0PARAMC(true);
            string GetQuery_V0PARAMC()
            {
                var query = @$"SELECT TIPO_MOVTOCC
							, 
							CODPRODU
							, 
							COD_CONVENIO
							, 
							NSAS
							, 
							COD_AGENCIA_SASS
							, 
							DTPROX_DEB
							, 
							DIA_DEBITO 
							FROM SEGUROS.V0PARAM_CONTACEF 
							WHERE TIPO_MOVTOCC = '{V0PARAMC_TIPO_MOVTOCC}' 
							AND SITUACAO = '{V0PARAMC_SITUACAO}' 
							AND COD_CONVENIO = 6114 
							AND CODPRODU = 7106 
							ORDER BY COD_CONVENIO";

                return query;
            }
            V0PARAMC.GetQueryEvent += GetQuery_V0PARAMC;

        }

        [StopWatch]
        /*" R0020-00-DECLARE-V0PARAM-CONTA-DB-OPEN-1 */
        public void R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1()
        {
            /*" -993- EXEC SQL OPEN V0PARAMC END-EXEC. */

            V0PARAMC.Open();

        }

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-DB-DECLARE-1 */
        public void R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1()
        {
            /*" -1122- EXEC SQL DECLARE V0MOVDE CURSOR FOR SELECT A.NUM_APOLICE ,A.NRENDOS ,A.NRPARCEL ,A.DTVENCTO ,DAYS(A.DTVENCTO) - DAYS(CURRENT DATE) ,A.VLR_DEBITO ,A.DIA_DEBITO ,A.COD_AGENCIA_DEB ,A.OPER_CONTA_DEB ,A.NUM_CONTA_DEB ,A.DIG_CONTA_DEB ,A.COD_CONVENIO ,A.COD_USUARIO FROM SEGUROS.V0MOVDEBCC_CEF A WHERE A.SIT_COBRANCA IN ( '0' , ' ' ) AND A.COD_CONVENIO = :V0PARAMC-COD-CONVENIO AND A.COD_RETORNO_CEF IS NULL ORDER BY A.COD_CONVENIO, A.DTVENCTO , A.NUM_APOLICE END-EXEC. */
            V0MOVDE = new BI0031B_V0MOVDE(true);
            string GetQuery_V0MOVDE()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE 
							,A.NRENDOS 
							,A.NRPARCEL 
							,A.DTVENCTO 
							,DAYS(A.DTVENCTO) - DAYS(CURRENT DATE) 
							,A.VLR_DEBITO 
							,A.DIA_DEBITO 
							,A.COD_AGENCIA_DEB 
							,A.OPER_CONTA_DEB 
							,A.NUM_CONTA_DEB 
							,A.DIG_CONTA_DEB 
							,A.COD_CONVENIO 
							,A.COD_USUARIO 
							FROM SEGUROS.V0MOVDEBCC_CEF A 
							WHERE A.SIT_COBRANCA IN ( '0'
							, ' ' ) 
							AND A.COD_CONVENIO = '{V0PARAMC_COD_CONVENIO}' 
							AND A.COD_RETORNO_CEF IS NULL 
							ORDER BY A.COD_CONVENIO
							, 
							A.DTVENCTO
							, 
							A.NUM_APOLICE";

                return query;
            }
            V0MOVDE.GetQueryEvent += GetQuery_V0MOVDE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-PROCE-V0PARAM-CONTA-SECTION */
        private void R0050_00_PROCE_V0PARAM_CONTA_SECTION()
        {
            /*" -1008- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1010- MOVE 'R0050-00-PROCE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0050-00-PROCE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1011- DISPLAY '                      ' . */
            _.Display($"                      ");

            /*" -1012- DISPLAY 'GERACAO DO MOVTO DE DEBITO EM CONTA *****' */
            _.Display($"GERACAO DO MOVTO DE DEBITO EM CONTA *****");

            /*" -1014- DISPLAY 'DATA DO SISTEMA ........... = ' V1SISTE-DTMOVABE */
            _.Display($"DATA DO SISTEMA ........... = {V1SISTE_DTMOVABE}");

            /*" -1017- DISPLAY 'DATA SISTEMA - 30 DIAS..... = ' V1SISTE-DTMOVABE-30 */
            _.Display($"DATA SISTEMA - 30 DIAS..... = {V1SISTE_DTMOVABE_30}");

            /*" -1019- DISPLAY 'DATA SISTEMA + 7 DIAS UTEIS = ' WDATA-BASE-07. */
            _.Display($"DATA SISTEMA + 7 DIAS UTEIS = {WDATA_BASE_07}");

            /*" -1021- DISPLAY '                      ' . */
            _.Display($"                      ");

            /*" -1023- MOVE V0PARAMC-DTPROX-DEB TO WDATA-DEBITO. */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_DEBITO);

            /*" -1024- PERFORM R0065-00-DECLARE-V0MOVDEBCC */

            R0065_00_DECLARE_V0MOVDEBCC_SECTION();

            /*" -1026- PERFORM R0110-00-LE-V0MOVDEBCC-CEF */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

            /*" -1029- PERFORM R0100-00-PROCESSA-V0MOVDEBCC UNTIL WFIMV0MOVDEBCC-CEF EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIMV0MOVDEBCC_CEF == "S"))
            {

                R0100_00_PROCESSA_V0MOVDEBCC_SECTION();
            }

            /*" -1031- PERFORM R0130-00-UPDATE-V0PARAM-CONTA. */

            R0130_00_UPDATE_V0PARAM_CONTA_SECTION();

            /*" -1032- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1033- DISPLAY 'LIDOS MOVDEBCE ............. ' LD-MOVDEBCE */
            _.Display($"LIDOS MOVDEBCE ............. {AREA_DE_WORK.LD_MOVDEBCE}");

            /*" -1034- DISPLAY 'DESPREZA NEGATIVO .......... ' DP-NEGATIVO */
            _.Display($"DESPREZA NEGATIVO .......... {AREA_DE_WORK.DP_NEGATIVO}");

            /*" -1035- DISPLAY 'DESPREZA DTMAIOR ........... ' DP-DTMAIOR */
            _.Display($"DESPREZA DTMAIOR ........... {AREA_DE_WORK.DP_DTMAIOR}");

            /*" -1036- DISPLAY 'DESPREZA DTMENOR ........... ' DP-DTMENOR */
            _.Display($"DESPREZA DTMENOR ........... {AREA_DE_WORK.DP_DTMENOR}");

            /*" -1037- DISPLAY 'DESPREZA BILHETE ........... ' DP-BILHETE */
            _.Display($"DESPREZA BILHETE ........... {AREA_DE_WORK.DP_BILHETE}");

            /*" -1038- DISPLAY 'DESPREZA COBERTURA ......... ' DP-COBERTURA */
            _.Display($"DESPREZA COBERTURA ......... {AREA_DE_WORK.DP_COBERTURA}");

            /*" -1041- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1041- PERFORM R0060-00-LE-V0PARAM-CONTACEF. */

            R0060_00_LE_V0PARAM_CONTACEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-SECTION */
        private void R0060_00_LE_V0PARAM_CONTACEF_SECTION()
        {
            /*" -1051- MOVE '0060' TO WNR-EXEC-SQL */
            _.Move("0060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1054- MOVE 'R0060-00-LE-V0PARAM-CONTA-CEF' TO WPARAGRAFO */
            _.Move("R0060-00-LE-V0PARAM-CONTA-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1062- PERFORM R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1 */

            R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1();

            /*" -1065- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1066- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1067- MOVE 'S' TO WFIMV0PARAM-CONTACEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0PARAM_CONTACEF);

                    /*" -1067- PERFORM R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1 */

                    R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1();

                    /*" -1069- GO TO R0060-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/ //GOTO
                    return;

                    /*" -1070- ELSE */
                }
                else
                {


                    /*" -1071- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1073- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1074- IF WCOD-CONVENIO EQUAL ZEROS */

            if (AREA_DE_WORK.WCOD_CONVENIO == 00)
            {

                /*" -1075- MOVE V0PARAMC-DTPROX-DEB TO WDATA-DISPLAY */
                _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_DISPLAY);

                /*" -1078- MOVE V0PARAMC-COD-CONVENIO TO WCOD-CONVENIO. */
                _.Move(V0PARAMC_COD_CONVENIO, AREA_DE_WORK.WCOD_CONVENIO);
            }


            /*" -1079- MOVE V0PARAMC-DTPROX-DEB TO WDATA-SQL */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_SQL);

            /*" -1080- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_12.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1081- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_12.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1082- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_12.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1084- MOVE WDATA-CABEC TO LC03-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -1084- COMPUTE WTOTPARAMC = WTOTPARAMC + 1. */
            AREA_DE_WORK.WTOTPARAMC.Value = AREA_DE_WORK.WTOTPARAMC + 1;

        }

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-DB-FETCH-1 */
        public void R0060_00_LE_V0PARAM_CONTACEF_DB_FETCH_1()
        {
            /*" -1062- EXEC SQL FETCH V0PARAMC INTO :V0PARAMC-TIPO-MOVTOCC, :V0PARAMC-CODPRODU, :V0PARAMC-COD-CONVENIO, :V0PARAMC-NSAS, :V0PARAMC-COD-AGENCIA-SASS, :V0PARAMC-DTPROX-DEB, :V0PARAMC-DIA-DEBITO END-EXEC. */

            if (V0PARAMC.Fetch())
            {
                _.Move(V0PARAMC.V0PARAMC_TIPO_MOVTOCC, V0PARAMC_TIPO_MOVTOCC);
                _.Move(V0PARAMC.V0PARAMC_CODPRODU, V0PARAMC_CODPRODU);
                _.Move(V0PARAMC.V0PARAMC_COD_CONVENIO, V0PARAMC_COD_CONVENIO);
                _.Move(V0PARAMC.V0PARAMC_NSAS, V0PARAMC_NSAS);
                _.Move(V0PARAMC.V0PARAMC_COD_AGENCIA_SASS, V0PARAMC_COD_AGENCIA_SASS);
                _.Move(V0PARAMC.V0PARAMC_DTPROX_DEB, V0PARAMC_DTPROX_DEB);
                _.Move(V0PARAMC.V0PARAMC_DIA_DEBITO, V0PARAMC_DIA_DEBITO);
            }

        }

        [StopWatch]
        /*" R0060-00-LE-V0PARAM-CONTACEF-DB-CLOSE-1 */
        public void R0060_00_LE_V0PARAM_CONTACEF_DB_CLOSE_1()
        {
            /*" -1067- EXEC SQL CLOSE V0PARAMC END-EXEC */

            V0PARAMC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-SECTION */
        private void R0065_00_DECLARE_V0MOVDEBCC_SECTION()
        {
            /*" -1094- MOVE '0065' TO WNR-EXEC-SQL */
            _.Move("0065", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1097- MOVE 'R0065-00-DECLARE-V0MOVDEBCC' TO WPARAGRAFO */
            _.Move("R0065-00-DECLARE-V0MOVDEBCC", AREA_DE_WORK.WPARAGRAFO);

            /*" -1098- MOVE '0' TO V0MOVDE-SIT-COBRANCA */
            _.Move("0", V0MOVDE_SIT_COBRANCA);

            /*" -1100- MOVE 'N' TO WFIMV0MOVDEBCC-CEF */
            _.Move("N", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

            /*" -1122- PERFORM R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1 */

            R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1();

            /*" -1124- PERFORM R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1 */

            R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1();

            /*" -1127- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1128- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1129- DISPLAY 'PROBLEMAS OPEN V0MOVDEBCC_CEF ' */
                _.Display($"PROBLEMAS OPEN V0MOVDEBCC_CEF ");

                /*" -1129- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0065-00-DECLARE-V0MOVDEBCC-DB-OPEN-1 */
        public void R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1()
        {
            /*" -1124- EXEC SQL OPEN V0MOVDE END-EXEC. */

            V0MOVDE.Open();

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-DECLARE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_DECLARE_1()
        {
            /*" -2015- EXEC SQL DECLARE CORIGEM CURSOR FOR SELECT SISTEMA_ORIGEM FROM SEGUROS.ARQUIVOS_SIVPF WHERE DATA_GERACAO = '9999-12-31' AND QTDE_REG_GER = 981 ORDER BY SISTEMA_ORIGEM END-EXEC. */
            CORIGEM = new BI0031B_CORIGEM(false);
            string GetQuery_CORIGEM()
            {
                var query = @$"SELECT SISTEMA_ORIGEM 
							FROM SEGUROS.ARQUIVOS_SIVPF 
							WHERE DATA_GERACAO = '9999-12-31' 
							AND QTDE_REG_GER = 981 
							ORDER BY SISTEMA_ORIGEM";

                return query;
            }
            CORIGEM.GetQueryEvent += GetQuery_CORIGEM;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/

        [StopWatch]
        /*" R0070-00-REGISTRO-HEADER-SECTION */
        private void R0070_00_REGISTRO_HEADER_SECTION()
        {
            /*" -1139- MOVE '0070' TO WNR-EXEC-SQL. */
            _.Move("0070", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1142- MOVE 'R0070-00-REGISTRO-HEADER   ' TO WPARAGRAFO */
            _.Move("R0070-00-REGISTRO-HEADER   ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1143- MOVE ALL SPACES TO HEADER-REGISTRO */
            _.MoveAll("", HEADER_REGISTRO);

            /*" -1144- MOVE 'A' TO HEADER-CODREGISTRO */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -1145- MOVE 1 TO HEADER-CODREMESSA */
            _.Move(1, HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -1146- MOVE 600114 TO HEADER-CODCONVENIO */
            _.Move(600114, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -1147- MOVE 'CAIXA SEGURO FACIL' TO HEADER-NOMEMPRESA */
            _.Move("CAIXA SEGURO FACIL", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -1148- MOVE 104 TO HEADER-CODBANCO */
            _.Move(104, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -1149- MOVE 'CEF' TO HEADER-NOMBANCO */
            _.Move("CEF", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -1150- MOVE V1SISTE-DTCURRENT TO WDATA-SQL */
            _.Move(V1SISTE_DTCURRENT, AREA_DE_WORK.WDATA_SQL);

            /*" -1151- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_12.WANO_SQL, AREA_DE_WORK.FILLER_15.WANO_TRA);

            /*" -1152- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_12.WMES_SQL, AREA_DE_WORK.FILLER_15.WMES_TRA);

            /*" -1153- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_12.WDIA_SQL, AREA_DE_WORK.FILLER_15.WDIA_TRA);

            /*" -1156- MOVE WDATATRA TO HEADER-DATGERACAO WDATSIS. */
            _.Move(AREA_DE_WORK.WDATATRA, HEADER_REGISTRO.HEADER_DATGERACAO, AREA_DE_WORK.WDATSIS);

            /*" -1157- IF WTOTMOVDE NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WTOTMOVDE != 00)
            {

                /*" -1159- ADD 1 TO V0PARAMC-NSAS. */
                V0PARAMC_NSAS.Value = V0PARAMC_NSAS + 1;
            }


            /*" -1161- MOVE V0PARAMC-NSAS TO HEADER-NSA WNSAS */
            _.Move(V0PARAMC_NSAS, HEADER_REGISTRO.HEADER_NSA, AREA_DE_WORK.WNSAS);

            /*" -1162- MOVE 04 TO HEADER-VERSAO */
            _.Move(04, HEADER_REGISTRO.HEADER_VERSAO);

            /*" -1163- MOVE 'DEB/CRED AUTOMAT' TO HEADER-DEBITOAUT */
            _.Move("DEB/CRED AUTOMAT", HEADER_REGISTRO.HEADER_DEBITOAUT);

            /*" -1165- MOVE ALL SPACES TO HEADER-FILLER */
            _.MoveAll("", HEADER_REGISTRO.HEADER_FILLER);

            /*" -1165- WRITE HEADER-REGISTRO. */
            MOVDEBITO_CC.Write(HEADER_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-REGISTRO-TRAILLER-SECTION */
        private void R0080_00_REGISTRO_TRAILLER_SECTION()
        {
            /*" -1175- MOVE '0080' TO WNR-EXEC-SQL. */
            _.Move("0080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1178- MOVE 'R0080-00-REGISTRO-TRAILLER' TO WPARAGRAFO */
            _.Move("R0080-00-REGISTRO-TRAILLER", AREA_DE_WORK.WPARAGRAFO);

            /*" -1179- MOVE ALL SPACES TO TRAILL-REGISTRO */
            _.MoveAll("", TRAILL_REGISTRO);

            /*" -1180- MOVE 'Z' TO TRAILL-CODREGISTRO */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -1181- COMPUTE WTOTREG = WTOTREG + 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 2;

            /*" -1182- MOVE WTOTREG TO TRAILL-TOTREGISTRO */
            _.Move(AREA_DE_WORK.WTOTREG, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -1183- MOVE WTOTDEB TO TRAILL-VLRTOTDEB */
            _.Move(AREA_DE_WORK.WTOTDEB, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -1184- MOVE ZEROS TO TRAILL-VLRTOTCRE */
            _.Move(0, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -1185- MOVE ALL SPACES TO TRAILL-FILLER */
            _.MoveAll("", TRAILL_REGISTRO.TRAILL_FILLER);

            /*" -1185- WRITE TRAILL-REGISTRO. */
            MOVDEBITO_CC.Write(TRAILL_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-PROCESSA-V0MOVDEBCC-SECTION */
        private void R0100_00_PROCESSA_V0MOVDEBCC_SECTION()
        {
            /*" -1195- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1198- MOVE 'R0100-00-PROCESSA-V0MOVDEBCC' TO WPARAGRAFO */
            _.Move("R0100-00-PROCESSA-V0MOVDEBCC", AREA_DE_WORK.WPARAGRAFO);

            /*" -1199- IF WTOTMOVDE EQUAL 1 */

            if (AREA_DE_WORK.WTOTMOVDE == 1)
            {

                /*" -1201- PERFORM R0070-00-REGISTRO-HEADER. */

                R0070_00_REGISTRO_HEADER_SECTION();
            }


            /*" -1202- PERFORM R0120-00-REGISTRO-E */

            R0120_00_REGISTRO_E_SECTION();

            /*" -1203- PERFORM R0125-00-RELATORIO */

            R0125_00_RELATORIO_SECTION();

            /*" -1204- PERFORM R0140-00-UPDATE-V0MOVDEBCC-CEF */

            R0140_00_UPDATE_V0MOVDEBCC_CEF_SECTION();

            /*" -1206- PERFORM R0150-00-UPDATE-V0BILHETE. */

            R0150_00_UPDATE_V0BILHETE_SECTION();

            /*" -1206- PERFORM R0110-00-LE-V0MOVDEBCC-CEF. */

            R0110_00_LE_V0MOVDEBCC_CEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-LE-V0MOVDEBCC-CEF-SECTION */
        private void R0110_00_LE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1216- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1216- MOVE 'R0110-00-LE-V0MOVDEBCC-CEF' TO WPARAGRAFO. */
            _.Move("R0110-00-LE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -0- FLUXCONTROL_PERFORM R0110_10_LE_MOVDEBCC */

            R0110_10_LE_MOVDEBCC();

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC */
        private void R0110_10_LE_MOVDEBCC(bool isPerform = false)
        {
            /*" -1235- PERFORM R0110_10_LE_MOVDEBCC_DB_FETCH_1 */

            R0110_10_LE_MOVDEBCC_DB_FETCH_1();

            /*" -1238- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1239- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1240- MOVE 'S' TO WFIMV0MOVDEBCC-CEF */
                    _.Move("S", AREA_DE_WORK.WFIMV0MOVDEBCC_CEF);

                    /*" -1240- PERFORM R0110_10_LE_MOVDEBCC_DB_CLOSE_1 */

                    R0110_10_LE_MOVDEBCC_DB_CLOSE_1();

                    /*" -1242- GO TO R0110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/ //GOTO
                    return;

                    /*" -1243- ELSE */
                }
                else
                {


                    /*" -1244- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1246- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1249- ADD 1 TO LD-MOVDEBCE. */
            AREA_DE_WORK.LD_MOVDEBCE.Value = AREA_DE_WORK.LD_MOVDEBCE + 1;

            /*" -1250- IF V0MOVDE-VLR-DEBITO IS NEGATIVE */

            if (V0MOVDE_VLR_DEBITO < 0)
            {

                /*" -1251- ADD 1 TO DP-NEGATIVO */
                AREA_DE_WORK.DP_NEGATIVO.Value = AREA_DE_WORK.DP_NEGATIVO + 1;

                /*" -1253- GO TO R0110-10-LE-MOVDEBCC. */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1254- IF V0MOVDE-DTVENCTO GREATER WDATA-BASE-07 */

            if (V0MOVDE_DTVENCTO > WDATA_BASE_07)
            {

                /*" -1255- ADD 1 TO DP-DTMAIOR */
                AREA_DE_WORK.DP_DTMAIOR.Value = AREA_DE_WORK.DP_DTMAIOR + 1;

                /*" -1257- GO TO R0110-10-LE-MOVDEBCC. */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1258- IF V0MOVDE-DTVENCTO LESS V1SISTE-DTMOVABE-30 */

            if (V0MOVDE_DTVENCTO < V1SISTE_DTMOVABE_30)
            {

                /*" -1259- ADD 1 TO DP-DTMENOR */
                AREA_DE_WORK.DP_DTMENOR.Value = AREA_DE_WORK.DP_DTMENOR + 1;

                /*" -1262- GO TO R0110-10-LE-MOVDEBCC. */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1265- MOVE 'N' TO WS-MARSH WFIMV1BILHETE IND-FLUXO-PARAM */
            _.Move("N", AREA_DE_WORK.WS_MARSH, AREA_DE_WORK.WFIMV1BILHETE, AREA_DE_WORK.IND_FLUXO_PARAM);

            /*" -1267- MOVE V0MOVDE-NUM-APOLICE TO V1BILH-NUMBIL. */
            _.Move(V0MOVDE_NUM_APOLICE, V1BILH_NUMBIL);

            /*" -1269- PERFORM R0115-00-LE-V1BILHETE. */

            R0115_00_LE_V1BILHETE_SECTION();

            /*" -1270- IF WFIMV1BILHETE EQUAL 'S' */

            if (AREA_DE_WORK.WFIMV1BILHETE == "S")
            {

                /*" -1271- ADD 1 TO DP-BILHETE */
                AREA_DE_WORK.DP_BILHETE.Value = AREA_DE_WORK.DP_BILHETE + 1;

                /*" -1273- GO TO R0110-10-LE-MOVDEBCC. */
                new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1274- IF IND-FLUXO-PARAM = 'N' */

            if (AREA_DE_WORK.IND_FLUXO_PARAM == "N")
            {

                /*" -1275- PERFORM R0121-00-LE-BILCOBER */

                R0121_00_LE_BILCOBER_SECTION();

                /*" -1276- IF BILCOBER-COD-PRODUTO = ZEROS */

                if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO == 00)
                {

                    /*" -1277- ADD 1 TO DP-COBERTURA */
                    AREA_DE_WORK.DP_COBERTURA.Value = AREA_DE_WORK.DP_COBERTURA + 1;

                    /*" -1278- GO TO R0110-10-LE-MOVDEBCC */
                    new Task(() => R0110_10_LE_MOVDEBCC()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1279- END-IF */
                }


                /*" -1295- END-IF */
            }


            /*" -1296- COMPUTE WTOTMOVDE = WTOTMOVDE + 1 */
            AREA_DE_WORK.WTOTMOVDE.Value = AREA_DE_WORK.WTOTMOVDE + 1;

            /*" -1297- COMPUTE WTOTREG = WTOTREG + 1 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG + 1;

            /*" -1298- COMPUTE WTOTGER = WTOTGER + 1 */
            AREA_DE_WORK.WTOTGER.Value = AREA_DE_WORK.WTOTGER + 1;

            /*" -1298- COMPUTE WTOTDEB = WTOTDEB + V0MOVDE-VLR-DEBITO. */
            AREA_DE_WORK.WTOTDEB.Value = AREA_DE_WORK.WTOTDEB + V0MOVDE_VLR_DEBITO;

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC-DB-FETCH-1 */
        public void R0110_10_LE_MOVDEBCC_DB_FETCH_1()
        {
            /*" -1235- EXEC SQL FETCH V0MOVDE INTO :V0MOVDE-NUM-APOLICE ,:V0MOVDE-NRENDOS ,:V0MOVDE-NRPARCEL ,:V0MOVDE-DTVENCTO ,:V0MOVDE-DAYS ,:V0MOVDE-VLR-DEBITO ,:V0MOVDE-DIA-DEBITO ,:V0MOVDE-COD-AGENCIA-DEB ,:V0MOVDE-OPER-CONTA-DEB ,:V0MOVDE-NUM-CONTA-DEB ,:V0MOVDE-DIG-CONTA-DEB ,:V0MOVDE-COD-CONVENIO ,:V0MOVDE-COD-USUARIO END-EXEC. */

            if (V0MOVDE.Fetch())
            {
                _.Move(V0MOVDE.V0MOVDE_NUM_APOLICE, V0MOVDE_NUM_APOLICE);
                _.Move(V0MOVDE.V0MOVDE_NRENDOS, V0MOVDE_NRENDOS);
                _.Move(V0MOVDE.V0MOVDE_NRPARCEL, V0MOVDE_NRPARCEL);
                _.Move(V0MOVDE.V0MOVDE_DTVENCTO, V0MOVDE_DTVENCTO);
                _.Move(V0MOVDE.V0MOVDE_DAYS, V0MOVDE_DAYS);
                _.Move(V0MOVDE.V0MOVDE_VLR_DEBITO, V0MOVDE_VLR_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_DIA_DEBITO, V0MOVDE_DIA_DEBITO);
                _.Move(V0MOVDE.V0MOVDE_COD_AGENCIA_DEB, V0MOVDE_COD_AGENCIA_DEB);
                _.Move(V0MOVDE.V0MOVDE_OPER_CONTA_DEB, V0MOVDE_OPER_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_NUM_CONTA_DEB, V0MOVDE_NUM_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_DIG_CONTA_DEB, V0MOVDE_DIG_CONTA_DEB);
                _.Move(V0MOVDE.V0MOVDE_COD_CONVENIO, V0MOVDE_COD_CONVENIO);
                _.Move(V0MOVDE.V0MOVDE_COD_USUARIO, V0MOVDE_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R0110-10-LE-MOVDEBCC-DB-CLOSE-1 */
        public void R0110_10_LE_MOVDEBCC_DB_CLOSE_1()
        {
            /*" -1240- EXEC SQL CLOSE V0MOVDE END-EXEC */

            V0MOVDE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0115-00-LE-V1BILHETE-SECTION */
        private void R0115_00_LE_V1BILHETE_SECTION()
        {
            /*" -1308- MOVE '0115' TO WNR-EXEC-SQL. */
            _.Move("0115", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1310- MOVE 'R0115-00-LE-V1BILHETE ' TO WPARAGRAFO */
            _.Move("R0115-00-LE-V1BILHETE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1313- MOVE '5' TO V1BILH-SITUACAO. */
            _.Move("5", V1BILH_SITUACAO);

            /*" -1327- PERFORM R0115_00_LE_V1BILHETE_DB_SELECT_1 */

            R0115_00_LE_V1BILHETE_DB_SELECT_1();

            /*" -1331- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1332- PERFORM R0116-00-LE-V1BILHETE */

                R0116_00_LE_V1BILHETE_SECTION();

                /*" -1333- ELSE */
            }
            else
            {


                /*" -1334- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1335- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1336- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -1336- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0115-00-LE-V1BILHETE-DB-SELECT-1 */
        public void R0115_00_LE_V1BILHETE_DB_SELECT_1()
        {
            /*" -1327- EXEC SQL SELECT NUMBIL, CODCLIEN, OPC_COBERTURA, RAMO ,VALUE(COD_PRODUTO,0) INTO :V1BILH-NUMBIL, :V1BILH-COD-CLIENTE, :V1BILH-OPC-COBER , :V1BILH-RAMO ,:V1BILH-COD-PRODUTO FROM SEGUROS.V0BILHETE WHERE NUMBIL = :V1BILH-NUMBIL AND SITUACAO = :V1BILH-SITUACAO END-EXEC. */

            var r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1 = new R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1()
            {
                V1BILH_SITUACAO = V1BILH_SITUACAO.ToString(),
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0115_00_LE_V1BILHETE_DB_SELECT_1_Query1.Execute(r0115_00_LE_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_COD_CLIENTE, V1BILH_COD_CLIENTE);
                _.Move(executed_1.V1BILH_OPC_COBER, V1BILH_OPC_COBER);
                _.Move(executed_1.V1BILH_RAMO, V1BILH_RAMO);
                _.Move(executed_1.V1BILH_COD_PRODUTO, V1BILH_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_99_SAIDA*/

        [StopWatch]
        /*" R0116-00-LE-V1BILHETE-SECTION */
        private void R0116_00_LE_V1BILHETE_SECTION()
        {
            /*" -1347- MOVE '0116' TO WNR-EXEC-SQL. */
            _.Move("0116", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1350- MOVE 'R0116-00-LE-V1BILHETE ' TO WPARAGRAFO */
            _.Move("R0116-00-LE-V1BILHETE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1352- MOVE '9' TO V1BILH-SITUACAO. */
            _.Move("9", V1BILH_SITUACAO);

            /*" -1366- PERFORM R0116_00_LE_V1BILHETE_DB_SELECT_1 */

            R0116_00_LE_V1BILHETE_DB_SELECT_1();

            /*" -1369- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1370- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1371- MOVE 'S' TO WFIMV1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -1372- ELSE */
                }
                else
                {


                    /*" -1373- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1374- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -1375- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1376- END-IF */
                }


                /*" -1377- ELSE */
            }
            else
            {


                /*" -1378- IF V1BILH-COD-PRODUTO > 0 */

                if (V1BILH_COD_PRODUTO > 0)
                {

                    /*" -1379- MOVE V1BILH-COD-PRODUTO TO W05-COD-PRODUTO */
                    _.Move(V1BILH_COD_PRODUTO, AREA_DE_WORK.W05_COD_PRODUTO);

                    /*" -1380- PERFORM R8000-PESQUISA-HIS-COBER */

                    R8000_PESQUISA_HIS_COBER_SECTION();

                    /*" -1381- IF IND-FLUXO-PARAM = 'S' */

                    if (AREA_DE_WORK.IND_FLUXO_PARAM == "S")
                    {

                        /*" -1382- MOVE 'N' TO WFIMV1BILHETE */
                        _.Move("N", AREA_DE_WORK.WFIMV1BILHETE);

                        /*" -1383- MOVE 'S' TO WS-MARSH */
                        _.Move("S", AREA_DE_WORK.WS_MARSH);

                        /*" -1384- GO TO R0116-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0116_99_SAIDA*/ //GOTO
                        return;

                        /*" -1385- END-IF */
                    }


                    /*" -1386- END-IF */
                }


                /*" -1387- IF V0MOVDE-NRPARCEL GREATER ZEROS */

                if (V0MOVDE_NRPARCEL > 00)
                {

                    /*" -1388- MOVE 'S' TO WS-MARSH */
                    _.Move("S", AREA_DE_WORK.WS_MARSH);

                    /*" -1389- ELSE */
                }
                else
                {


                    /*" -1390- MOVE 'S' TO WFIMV1BILHETE */
                    _.Move("S", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -1391- PERFORM R0119-00-LE-PROPOFID */

                    R0119_00_LE_PROPOFID_SECTION();

                    /*" -1392- END-IF */
                }


                /*" -1392- END-IF. */
            }


        }

        [StopWatch]
        /*" R0116-00-LE-V1BILHETE-DB-SELECT-1 */
        public void R0116_00_LE_V1BILHETE_DB_SELECT_1()
        {
            /*" -1366- EXEC SQL SELECT NUMBIL ,CODCLIEN ,OPC_COBERTURA ,RAMO ,VALUE(COD_PRODUTO,0) INTO :V1BILH-NUMBIL ,:V1BILH-COD-CLIENTE ,:V1BILH-OPC-COBER ,:V1BILH-RAMO ,:V1BILH-COD-PRODUTO FROM SEGUROS.V0BILHETE A WHERE A.NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND A.SITUACAO = :V1BILH-SITUACAO END-EXEC. */

            var r0116_00_LE_V1BILHETE_DB_SELECT_1_Query1 = new R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1()
            {
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V1BILH_SITUACAO = V1BILH_SITUACAO.ToString(),
            };

            var executed_1 = R0116_00_LE_V1BILHETE_DB_SELECT_1_Query1.Execute(r0116_00_LE_V1BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1BILH_NUMBIL, V1BILH_NUMBIL);
                _.Move(executed_1.V1BILH_COD_CLIENTE, V1BILH_COD_CLIENTE);
                _.Move(executed_1.V1BILH_OPC_COBER, V1BILH_OPC_COBER);
                _.Move(executed_1.V1BILH_RAMO, V1BILH_RAMO);
                _.Move(executed_1.V1BILH_COD_PRODUTO, V1BILH_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0116_99_SAIDA*/

        [StopWatch]
        /*" R0117-UPDATE-V1BILHETE-SECTION */
        private void R0117_UPDATE_V1BILHETE_SECTION()
        {
            /*" -1402- MOVE '0117' TO WNR-EXEC-SQL. */
            _.Move("0117", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1405- MOVE 'R0111-UPDATE-V1BILHETE' TO WPARAGRAFO */
            _.Move("R0111-UPDATE-V1BILHETE", AREA_DE_WORK.WPARAGRAFO);

            /*" -1409- PERFORM R0117_UPDATE_V1BILHETE_DB_UPDATE_1 */

            R0117_UPDATE_V1BILHETE_DB_UPDATE_1();

            /*" -1412- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1413- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                /*" -1414- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1414- END-IF. */
            }


        }

        [StopWatch]
        /*" R0117-UPDATE-V1BILHETE-DB-UPDATE-1 */
        public void R0117_UPDATE_V1BILHETE_DB_UPDATE_1()
        {
            /*" -1409- EXEC SQL UPDATE SEGUROS.V0BILHETE SET DTQITBCO = :V0MOVDE-DTVENCTO WHERE NUMBIL = :V1BILH-NUMBIL END-EXEC. */

            var r0117_UPDATE_V1BILHETE_DB_UPDATE_1_Update1 = new R0117_UPDATE_V1BILHETE_DB_UPDATE_1_Update1()
            {
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            R0117_UPDATE_V1BILHETE_DB_UPDATE_1_Update1.Execute(r0117_UPDATE_V1BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0117_99_SAIDA*/

        [StopWatch]
        /*" R0118-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0118_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1424- MOVE '0118' TO WNR-EXEC-SQL. */
            _.Move("0118", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1427- MOVE 'R0118-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0118-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1434- PERFORM R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

            R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

            /*" -1437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1438- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1439- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -1440- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1441- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1442- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1442- END-IF. */
            }


        }

        [StopWatch]
        /*" R0118-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -1434- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET DTVENCTO = :V0MOVDE-DTVENCTO WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND NRENDOS = :V0MOVDE-NRENDOS AND NRPARCEL = :V0MOVDE-NRPARCEL AND SIT_COBRANCA IN ( '0' , ' ' ) AND COD_CONVENIO = :V0MOVDE-COD-CONVENIO END-EXEC. */

            var r0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
            };

            R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0118_99_SAIDA*/

        [StopWatch]
        /*" R0119-00-LE-PROPOFID-SECTION */
        private void R0119_00_LE_PROPOFID_SECTION()
        {
            /*" -1452- MOVE '0119' TO WNR-EXEC-SQL. */
            _.Move("0119", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1455- MOVE 'R0119-00-LE-PROPOFID  ' TO WPARAGRAFO */
            _.Move("R0119-00-LE-PROPOFID  ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1462- PERFORM R0119_00_LE_PROPOFID_DB_SELECT_1 */

            R0119_00_LE_PROPOFID_DB_SELECT_1();

            /*" -1465- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1466- MOVE PROPOFID-COD-PLANO TO W05-COD-PRODUTO */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, AREA_DE_WORK.W05_COD_PRODUTO);

                /*" -1467- PERFORM R0300-00-VERIFICA-ORIGEM */

                R0300_00_VERIFICA_ORIGEM_SECTION();

                /*" -1469- IF WTEM-SISTEMA-ORIGEM EQUAL 'SIM' OR CANAL-ELETRONICO */

                if (AREA_DE_WORK.WTEM_SISTEMA_ORIGEM == "SIM" || AREA_DE_WORK.W05_COD_PRODUTO["CANAL_ELETRONICO"])
                {

                    /*" -1470- MOVE 'S' TO WS-MARSH */
                    _.Move("S", AREA_DE_WORK.WS_MARSH);

                    /*" -1471- MOVE 'N' TO WFIMV1BILHETE */
                    _.Move("N", AREA_DE_WORK.WFIMV1BILHETE);

                    /*" -1472- END-IF */
                }


                /*" -1473- ELSE */
            }
            else
            {


                /*" -1475- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1476- ELSE */
                }
                else
                {


                    /*" -1477- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1478- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -1478- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0119-00-LE-PROPOFID-DB-SELECT-1 */
        public void R0119_00_LE_PROPOFID_DB_SELECT_1()
        {
            /*" -1462- EXEC SQL SELECT ORIGEM_PROPOSTA , COD_PLANO INTO :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-COD-PLANO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :V1BILH-NUMBIL END-EXEC. */

            var r0119_00_LE_PROPOFID_DB_SELECT_1_Query1 = new R0119_00_LE_PROPOFID_DB_SELECT_1_Query1()
            {
                V1BILH_NUMBIL = V1BILH_NUMBIL.ToString(),
            };

            var executed_1 = R0119_00_LE_PROPOFID_DB_SELECT_1_Query1.Execute(r0119_00_LE_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0119_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-REGISTRO-E-SECTION */
        private void R0120_00_REGISTRO_E_SECTION()
        {
            /*" -1488- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1491- MOVE 'R0120-00-REGISTRO-E ' TO WPARAGRAFO */
            _.Move("R0120-00-REGISTRO-E ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1492- MOVE ALL SPACES TO MOVCC-REGISTRO */
            _.MoveAll("", MOVCC_REGISTRO);

            /*" -1494- MOVE 'E' TO MOVCC-CODREGISTRO */
            _.Move("E", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -1495- MOVE V0MOVDE-NUM-APOLICE TO WNUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, AREA_DE_WORK.FILLER_1.WNUMBIL);

            /*" -1496- MOVE ALL SPACES TO WEMP-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_1.WEMP_SPACES);

            /*" -1499- MOVE WIDTCLIEMP TO MOVCC-IDTCLIEMP */
            _.Move(AREA_DE_WORK.WIDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -1500- IF WS-MARSH EQUAL 'S' */

            if (AREA_DE_WORK.WS_MARSH == "S")
            {

                /*" -1501- MOVE ALL SPACES TO WS-IDTCLIEMP */
                _.MoveAll("", AREA_DE_WORK.WS_IDTCLIEMP);

                /*" -1502- MOVE V0MOVDE-NUM-APOLICE TO WNUMAPOL */
                _.Move(V0MOVDE_NUM_APOLICE, AREA_DE_WORK.FILLER_2.WNUMAPOL);

                /*" -1503- MOVE V0MOVDE-NRENDOS TO WNRENDOS */
                _.Move(V0MOVDE_NRENDOS, AREA_DE_WORK.FILLER_2.WNRENDOS);

                /*" -1504- MOVE V0MOVDE-NRPARCEL TO WNRPARCEL */
                _.Move(V0MOVDE_NRPARCEL, AREA_DE_WORK.FILLER_2.WNRPARCEL);

                /*" -1507- MOVE WS-IDTCLIEMP TO MOVCC-IDTCLIEMP. */
                _.Move(AREA_DE_WORK.WS_IDTCLIEMP, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);
            }


            /*" -1508- MOVE SPACES TO WS-CTA-ERRO. */
            _.Move("", LK_CONSISTE_CONTA.WS_CTA_ERRO);

            /*" -1511- PERFORM R0122-00-VERIFICA-CONTA. */

            R0122_00_VERIFICA_CONTA_SECTION();

            /*" -1513- MOVE V0MOVDE-COD-AGENCIA-DEB TO MOVCC-AGEDEBITO */
            _.Move(V0MOVDE_COD_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_AGEDEBITO);

            /*" -1514- MOVE V0MOVDE-OPER-CONTA-DEB TO WOPER-CONTA */
            _.Move(V0MOVDE_OPER_CONTA_DEB, AREA_DE_WORK.FILLER_0.WOPER_CONTA);

            /*" -1515- MOVE V0MOVDE-NUM-CONTA-DEB TO WNUM-CONTA */
            _.Move(V0MOVDE_NUM_CONTA_DEB, AREA_DE_WORK.FILLER_0.WNUM_CONTA);

            /*" -1516- MOVE V0MOVDE-DIG-CONTA-DEB TO WDIG-CONTA */
            _.Move(V0MOVDE_DIG_CONTA_DEB, AREA_DE_WORK.FILLER_0.WDIG_CONTA);

            /*" -1517- MOVE ALL SPACES TO WIDT-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_0.WIDT_SPACES);

            /*" -1519- MOVE WIDTCLIBAN TO MOVCC-IDTCLIBAN */
            _.Move(AREA_DE_WORK.WIDTCLIBAN, MOVCC_REGISTRO.MOVCC_IDTCLIBAN);

            /*" -1521- MOVE V0MOVDE-DTVENCTO TO WDATA-SQL. */
            _.Move(V0MOVDE_DTVENCTO, AREA_DE_WORK.WDATA_SQL);

            /*" -1522- MOVE WANO-SQL TO WANO-TRA */
            _.Move(AREA_DE_WORK.FILLER_12.WANO_SQL, AREA_DE_WORK.FILLER_15.WANO_TRA);

            /*" -1523- MOVE WMES-SQL TO WMES-TRA */
            _.Move(AREA_DE_WORK.FILLER_12.WMES_SQL, AREA_DE_WORK.FILLER_15.WMES_TRA);

            /*" -1524- MOVE WDIA-SQL TO WDIA-TRA */
            _.Move(AREA_DE_WORK.FILLER_12.WDIA_SQL, AREA_DE_WORK.FILLER_15.WDIA_TRA);

            /*" -1526- MOVE WDATATRA TO MOVCC-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATATRA, MOVCC_REGISTRO.MOVCC_DTVENCTO);

            /*" -1527- MOVE V0MOVDE-VLR-DEBITO TO MOVCC-VLRDEBITO */
            _.Move(V0MOVDE_VLR_DEBITO, MOVCC_REGISTRO.MOVCC_VLRDEBITO);

            /*" -1529- MOVE ZEROS TO MOVCC-CODMOEDA */
            _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOEDA);

            /*" -1530- MOVE 600114 TO WUSO-CONVENIO */
            _.Move(600114, AREA_DE_WORK.FILLER_11.WUSO_CONVENIO);

            /*" -1531- MOVE V0PARAMC-NSAS TO WUSO-NSAS */
            _.Move(V0PARAMC_NSAS, AREA_DE_WORK.FILLER_11.WUSO_NSAS);

            /*" -1532- MOVE WTOTREG TO WUSO-SEQFITA */
            _.Move(AREA_DE_WORK.WTOTREG, AREA_DE_WORK.FILLER_11.WUSO_SEQFITA);

            /*" -1533- MOVE WTOTREG TO V0MOVDE-REQUISICAO */
            _.Move(AREA_DE_WORK.WTOTREG, V0MOVDE_REQUISICAO);

            /*" -1534- MOVE ALL SPACES TO WUSO-SPACES */
            _.MoveAll("", AREA_DE_WORK.FILLER_11.WUSO_SPACES);

            /*" -1536- MOVE WUSOEMPRESA TO MOVCC-USOEMPRESA */
            _.Move(AREA_DE_WORK.WUSOEMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -1537- MOVE ALL SPACES TO MOVCC-FILLER */
            _.MoveAll("", MOVCC_REGISTRO.MOVCC_FILLER);

            /*" -1539- MOVE ZEROS TO MOVCC-CODMOVTO */
            _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOVTO);

            /*" -1539- WRITE MOVCC-REGISTRO. */
            MOVDEBITO_CC.Write(MOVCC_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0121-00-LE-BILCOBER-SECTION */
        private void R0121_00_LE_BILCOBER_SECTION()
        {
            /*" -1549- MOVE '0121' TO WNR-EXEC-SQL. */
            _.Move("0121", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1552- MOVE 'R0121-00-LE-BILCOBER  ' TO WPARAGRAFO */
            _.Move("R0121-00-LE-BILCOBER  ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1570- PERFORM R0121_00_LE_BILCOBER_DB_SELECT_1 */

            R0121_00_LE_BILCOBER_DB_SELECT_1();

            /*" -1573- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1574- MOVE ZEROS TO BILCOBER-COD-PRODUTO */
                _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);

                /*" -1575- ELSE */
            }
            else
            {


                /*" -1576- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1577- DISPLAY 'BI0031B - ' WPARAGRAFO */
                    _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                    /*" -1578- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                    _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                    /*" -1579- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1580- ELSE */
                }
                else
                {


                    /*" -1580- MOVE BILCOBER-COD-PRODUTO TO W05-COD-PRODUTO. */
                    _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO, AREA_DE_WORK.W05_COD_PRODUTO);
                }

            }


        }

        [StopWatch]
        /*" R0121-00-LE-BILCOBER-DB-SELECT-1 */
        public void R0121_00_LE_BILCOBER_DB_SELECT_1()
        {
            /*" -1570- EXEC SQL SELECT COD_PRODUTO INTO :BILCOBER-COD-PRODUTO FROM SEGUROS.BILHETE_COBERTURA WHERE COD_OPCAO_PLANO = :V1BILH-OPC-COBER AND RAMO_COBERTURA = :V1BILH-RAMO AND DATA_TERVIGENCIA = '9999-12-31' FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var r0121_00_LE_BILCOBER_DB_SELECT_1_Query1 = new R0121_00_LE_BILCOBER_DB_SELECT_1_Query1()
            {
                V1BILH_OPC_COBER = V1BILH_OPC_COBER.ToString(),
                V1BILH_RAMO = V1BILH_RAMO.ToString(),
            };

            var executed_1 = R0121_00_LE_BILCOBER_DB_SELECT_1_Query1.Execute(r0121_00_LE_BILCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILCOBER_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0121_99_SAIDA*/

        [StopWatch]
        /*" R0122-00-VERIFICA-CONTA-SECTION */
        private void R0122_00_VERIFICA_CONTA_SECTION()
        {
            /*" -1591- MOVE '0122' TO WNR-EXEC-SQL. */
            _.Move("0122", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1594- MOVE 'R0122-00-VERIFICA CTA' TO WPARAGRAFO */
            _.Move("R0122-00-VERIFICA CTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1595- INITIALIZE WS-NUMERO. */
            _.Initialize(
                LK_CONSISTE_CONTA.WS_NUMERO
            );

            /*" -1596- IF V0MOVDE-NUM-CONTA-DEB >= 400000000 */

            if (V0MOVDE_NUM_CONTA_DEB >= 400000000)
            {

                /*" -1597- MOVE V0MOVDE-NUM-CONTA-DEB TO WS-NUMERO */
                _.Move(V0MOVDE_NUM_CONTA_DEB, LK_CONSISTE_CONTA.WS_NUMERO);

                /*" -1598- ELSE */
            }
            else
            {


                /*" -1600- MOVE V0MOVDE-COD-AGENCIA-DEB TO WS-AGENCIA */
                _.Move(V0MOVDE_COD_AGENCIA_DEB, LK_CONSISTE_CONTA.FILLER_56.WS_AGENCIA);

                /*" -1602- MOVE V0MOVDE-OPER-CONTA-DEB TO WS-OPERACAO */
                _.Move(V0MOVDE_OPER_CONTA_DEB, LK_CONSISTE_CONTA.FILLER_56.WS_OPERACAO);

                /*" -1604- MOVE V0MOVDE-NUM-CONTA-DEB TO WS-NUMCONTA */
                _.Move(V0MOVDE_NUM_CONTA_DEB, LK_CONSISTE_CONTA.FILLER_56.WS_NUMCONTA);

                /*" -1606- END-IF. */
            }


            /*" -1609- MOVE V0MOVDE-DIG-CONTA-DEB TO WS-DIGCONTA. */
            _.Move(V0MOVDE_DIG_CONTA_DEB, LK_CONSISTE_CONTA.WS_DIGCONTA);

            /*" -1612- MOVE WS-NUMERO TO LPARM15. */
            _.Move(LK_CONSISTE_CONTA.WS_NUMERO, LK_CONSISTE_CONTA.LPARM15X.LPARM15);

            /*" -1628- COMPUTE WPARM15-AUX = LPARM15-1 * 8 + LPARM15-2 * 7 + LPARM15-3 * 6 + LPARM15-4 * 5 + LPARM15-5 * 4 + LPARM15-6 * 3 + LPARM15-7 * 2 + LPARM15-8 * 9 + LPARM15-9 * 8 + LPARM15-10 * 7 + LPARM15-11 * 6 + LPARM15-12 * 5 + LPARM15-13 * 4 + LPARM15-14 * 3 + LPARM15-15 * 2. */
            LK_CONSISTE_CONTA.WPARM15_AUX.Value = LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_1 * 8 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_2 * 7 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_3 * 6 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_4 * 5 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_5 * 4 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_6 * 3 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_7 * 2 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_8 * 9 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_9 * 8 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_10 * 7 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_11 * 6 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_12 * 5 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_13 * 4 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_14 * 3 + LK_CONSISTE_CONTA.LPARM15X.FILLER_57.LPARM15_15 * 2;

            /*" -1632- DIVIDE WPARM15-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(LK_CONSISTE_CONTA.WPARM15_AUX, 11, LK_CONSISTE_CONTA.WQUOCIENTE, LK_CONSISTE_CONTA.WRESTO);

            /*" -1633- IF WRESTO EQUAL ZEROS */

            if (LK_CONSISTE_CONTA.WRESTO == 00)
            {

                /*" -1634- MOVE 0 TO LPARM15-D1 */
                _.Move(0, LK_CONSISTE_CONTA.LPARM15X.LPARM15_D1);

                /*" -1635- ELSE */
            }
            else
            {


                /*" -1639- SUBTRACT WRESTO FROM 11 GIVING LPARM15-D1. */
                LK_CONSISTE_CONTA.LPARM15X.LPARM15_D1.Value = 11 - LK_CONSISTE_CONTA.WRESTO;
            }


            /*" -1640- IF WS-DIGCONTA NOT EQUAL LPARM15-D1 */

            if (LK_CONSISTE_CONTA.WS_DIGCONTA != LK_CONSISTE_CONTA.LPARM15X.LPARM15_D1)
            {

                /*" -1644- DISPLAY 'DIGITO CONTA ALTERADA ... ' 'TITULO=' V0MOVDE-NUM-APOLICE ' DV ANTERIOR=' WS-DIGCONTA ' DV ATUAL=' LPARM15-D1 */

                $"DIGITO CONTA ALTERADA ... TITULO={V0MOVDE_NUM_APOLICE} DV ANTERIOR={LK_CONSISTE_CONTA.WS_DIGCONTA} DV ATUAL={LK_CONSISTE_CONTA.LPARM15X.LPARM15_D1}"
                .Display();

                /*" -1646- MOVE LPARM15-D1 TO V0MOVDE-DIG-CONTA-DEB */
                _.Move(LK_CONSISTE_CONTA.LPARM15X.LPARM15_D1, V0MOVDE_DIG_CONTA_DEB);

                /*" -1646- MOVE 'S' TO WS-CTA-ERRO. */
                _.Move("S", LK_CONSISTE_CONTA.WS_CTA_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0122_99_SAIDA*/

        [StopWatch]
        /*" R0125-00-RELATORIO-SECTION */
        private void R0125_00_RELATORIO_SECTION()
        {
            /*" -1656- MOVE '0125' TO WNR-EXEC-SQL. */
            _.Move("0125", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1659- MOVE 'R0125-00-RELATORIO ' TO WPARAGRAFO */
            _.Move("R0125-00-RELATORIO ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1661- PERFORM R0126-00-LE-V1CLIENTE. */

            R0126_00_LE_V1CLIENTE_SECTION();

            /*" -1662- MOVE V0MOVDE-NUM-APOLICE TO LD01-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_NUMBIL);

            /*" -1663- MOVE V0MOVDE-NRENDOS TO LD01-NRENDOS */
            _.Move(V0MOVDE_NRENDOS, AREA_DE_WORK.LD01.LD01_NRENDOS);

            /*" -1664- MOVE V0MOVDE-NRPARCEL TO LD01-NRPARCEL */
            _.Move(V0MOVDE_NRPARCEL, AREA_DE_WORK.LD01.LD01_NRPARCEL);

            /*" -1665- MOVE V0MOVDE-DTVENCTO TO WDATA-SQL */
            _.Move(V0MOVDE_DTVENCTO, AREA_DE_WORK.WDATA_SQL);

            /*" -1666- MOVE WDIA-SQL TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_12.WDIA_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1667- MOVE WMES-SQL TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_12.WMES_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1668- MOVE WANO-SQL TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_12.WANO_SQL, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1669- MOVE WDATA-CABEC TO LD01-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LD01.LD01_DTVENCTO);

            /*" -1670- MOVE V0MOVDE-DIA-DEBITO TO LD01-DIA-DEBITO */
            _.Move(V0MOVDE_DIA_DEBITO, AREA_DE_WORK.LD01.LD01_DIA_DEBITO);

            /*" -1671- MOVE V0MOVDE-COD-AGENCIA-DEB TO LD01-AGENCIA */
            _.Move(V0MOVDE_COD_AGENCIA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_AGENCIA);

            /*" -1672- MOVE V0MOVDE-OPER-CONTA-DEB TO LD01-OPERACAO */
            _.Move(V0MOVDE_OPER_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_OPERACAO);

            /*" -1673- MOVE '/' TO LD01-BARRA */
            _.Move("/", AREA_DE_WORK.LD01.LD01_DEBITO.LD01_BARRA);

            /*" -1674- MOVE V0MOVDE-NUM-CONTA-DEB TO LD01-CONTA */
            _.Move(V0MOVDE_NUM_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_CONTA);

            /*" -1675- MOVE '-' TO LD01-HIFEN1 */
            _.Move("-", AREA_DE_WORK.LD01.LD01_DEBITO.LD01_HIFEN1);

            /*" -1676- MOVE V0MOVDE-DIG-CONTA-DEB TO LD01-DIGITO */
            _.Move(V0MOVDE_DIG_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DEBITO.LD01_DIGITO);

            /*" -1678- MOVE V0MOVDE-VLR-DEBITO TO LD01-VLDEBITO */
            _.Move(V0MOVDE_VLR_DEBITO, AREA_DE_WORK.LD01.LD01_VLDEBITO);

            /*" -1680- MOVE V1CLIEN-NOME-RAZAO TO LD01-NOME */
            _.Move(V1CLIEN_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOME);

            /*" -1681- IF WLIN GREATER 50 */

            if (AREA_DE_WORK.WLIN > 50)
            {

                /*" -1683- PERFORM R0160-00-CABECALHOS. */

                R0160_00_CABECALHOS_SECTION();
            }


            /*" -1685- WRITE REG-BI0031B FROM LD01 AFTER 1 */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1685- COMPUTE WLIN = WLIN + 1. */
            AREA_DE_WORK.WLIN.Value = AREA_DE_WORK.WLIN + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_99_SAIDA*/

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-SECTION */
        private void R0126_00_LE_V1CLIENTE_SECTION()
        {
            /*" -1695- MOVE '0126' TO WNR-EXEC-SQL. */
            _.Move("0126", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1698- MOVE 'R0126-00-LE-V1CLIENTE ' TO WPARAGRAFO */
            _.Move("R0126-00-LE-V1CLIENTE ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1699- MOVE V1BILH-COD-CLIENTE TO V1CLIEN-COD-CLIENTE */
            _.Move(V1BILH_COD_CLIENTE, V1CLIEN_COD_CLIENTE);

            /*" -1701- MOVE SPACES TO V1CLIEN-NOME-RAZAO. */
            _.Move("", V1CLIEN_NOME_RAZAO);

            /*" -1706- PERFORM R0126_00_LE_V1CLIENTE_DB_SELECT_1 */

            R0126_00_LE_V1CLIENTE_DB_SELECT_1();

            /*" -1709- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1710- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1711- DISPLAY 'V0MOVDE-NUM-APOLICE ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE {V0MOVDE_NUM_APOLICE}");

                /*" -1712- DISPLAY 'V1CLIEN-COD-CLIENTE ' V1CLIEN-COD-CLIENTE */
                _.Display($"V1CLIEN-COD-CLIENTE {V1CLIEN_COD_CLIENTE}");

                /*" -1712- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0126-00-LE-V1CLIENTE-DB-SELECT-1 */
        public void R0126_00_LE_V1CLIENTE_DB_SELECT_1()
        {
            /*" -1706- EXEC SQL SELECT NOME_RAZAO INTO :V1CLIEN-NOME-RAZAO FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :V1CLIEN-COD-CLIENTE END-EXEC. */

            var r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1 = new R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1()
            {
                V1CLIEN_COD_CLIENTE = V1CLIEN_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1.Execute(r0126_00_LE_V1CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CLIEN_NOME_RAZAO, V1CLIEN_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0126_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-SECTION */
        private void R0130_00_UPDATE_V0PARAM_CONTA_SECTION()
        {
            /*" -1722- MOVE '0130' TO WNR-EXEC-SQL */
            _.Move("0130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1725- MOVE 'R0130-00-UPDATE-V0PARAM-CONTA' TO WPARAGRAFO */
            _.Move("R0130-00-UPDATE-V0PARAM-CONTA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1728- PERFORM R0135-00-PROXIMO-DEBITO. */

            R0135_00_PROXIMO_DEBITO_SECTION();

            /*" -1736- PERFORM R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1 */

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1();

            /*" -1739- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1740- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1741- DISPLAY 'V0PARAMC-TIPO-MOVTOCC ' V0PARAMC-TIPO-MOVTOCC */
                _.Display($"V0PARAMC-TIPO-MOVTOCC {V0PARAMC_TIPO_MOVTOCC}");

                /*" -1742- DISPLAY 'V0PARAMC-CODPRODU     ' V0PARAMC-CODPRODU */
                _.Display($"V0PARAMC-CODPRODU     {V0PARAMC_CODPRODU}");

                /*" -1743- DISPLAY 'V0PARAMC-COD-CONVENIO ' V0PARAMC-COD-CONVENIO */
                _.Display($"V0PARAMC-COD-CONVENIO {V0PARAMC_COD_CONVENIO}");

                /*" -1743- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-00-UPDATE-V0PARAM-CONTA-DB-UPDATE-1 */
        public void R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1()
        {
            /*" -1736- EXEC SQL UPDATE SEGUROS.V0PARAM_CONTACEF SET NSAS = :V0PARAMC-NSAS, DTMOVTO = :V1SISTE-DTCURRENT, DTPROX_DEB = :V0PARAMC-DTPROX-DEB, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_MOVTOCC = :V0PARAMC-TIPO-MOVTOCC AND COD_CONVENIO = :V0PARAMC-COD-CONVENIO AND SITUACAO = :V0PARAMC-SITUACAO END-EXEC. */

            var r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1 = new R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1()
            {
                V0PARAMC_DTPROX_DEB = V0PARAMC_DTPROX_DEB.ToString(),
                V1SISTE_DTCURRENT = V1SISTE_DTCURRENT.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0PARAMC_TIPO_MOVTOCC = V0PARAMC_TIPO_MOVTOCC.ToString(),
                V0PARAMC_COD_CONVENIO = V0PARAMC_COD_CONVENIO.ToString(),
                V0PARAMC_SITUACAO = V0PARAMC_SITUACAO.ToString(),
            };

            R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1.Execute(r0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0135-00-PROXIMO-DEBITO-SECTION */
        private void R0135_00_PROXIMO_DEBITO_SECTION()
        {
            /*" -1753- MOVE '0135' TO WNR-EXEC-SQL */
            _.Move("0135", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1756- MOVE 'R0135-00-PROXIMO-DEBITO' TO WPARAGRAFO */
            _.Move("R0135-00-PROXIMO-DEBITO", AREA_DE_WORK.WPARAGRAFO);

            /*" -1757- MOVE V0PARAMC-DTPROX-DEB TO WDATA-SQL. */
            _.Move(V0PARAMC_DTPROX_DEB, AREA_DE_WORK.WDATA_SQL);

            /*" -1758- MOVE WDIA-SQL TO DATA3-DD */
            _.Move(AREA_DE_WORK.FILLER_12.WDIA_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD);

            /*" -1759- MOVE WMES-SQL TO DATA3-MM */
            _.Move(AREA_DE_WORK.FILLER_12.WMES_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM);

            /*" -1760- MOVE WANO-SQL TO DATA3-AA */
            _.Move(AREA_DE_WORK.FILLER_12.WANO_SQL, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA);

            /*" -1761- MOVE ZEROS TO DATA2-DD */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_DD);

            /*" -1762- MOVE ZEROS TO DATA2-MM */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_MM);

            /*" -1764- MOVE ZEROS TO DATA2-AA */
            _.Move(0, AREA_DE_WORK.LPARM2.DATA2_R.DATA2_AA);

            /*" -1766- PERFORM R0136-00-ACHA-DATA 1 TIMES. */

            for (int i = 0; i < 1; i++)
            {

                R0136_00_ACHA_DATA_SECTION();

            }

            /*" -1767- IF QUANTIDA EQUAL +99999 */

            if (AREA_DE_WORK.LPARM2.QUANTIDA == +99999)
            {

                /*" -1768- MOVE 31 TO DATA3-DD */
                _.Move(31, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD);

                /*" -1769- MOVE 12 TO DATA3-MM */
                _.Move(12, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM);

                /*" -1770- MOVE 9999 TO DATA3-AA */
                _.Move(9999, AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA);

                /*" -1771- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1772- DISPLAY '* BI0031B - ERRO NA ROTINA PROSOMC1 *' */
                _.Display($"* BI0031B - ERRO NA ROTINA PROSOMC1 *");

                /*" -1773- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -1775- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1776- MOVE DATA3-DD TO WDIA-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_DD, AREA_DE_WORK.FILLER_12.WDIA_SQL);

            /*" -1777- MOVE DATA3-MM TO WMES-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_MM, AREA_DE_WORK.FILLER_12.WMES_SQL);

            /*" -1779- MOVE DATA3-AA TO WANO-SQL */
            _.Move(AREA_DE_WORK.LPARM2.DATA3_R.DATA3_AA, AREA_DE_WORK.FILLER_12.WANO_SQL);

            /*" -1779- MOVE WDATA-SQL TO V0PARAMC-DTPROX-DEB. */
            _.Move(AREA_DE_WORK.WDATA_SQL, V0PARAMC_DTPROX_DEB);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0135_99_SAIDA*/

        [StopWatch]
        /*" R0136-00-ACHA-DATA-SECTION */
        private void R0136_00_ACHA_DATA_SECTION()
        {
            /*" -1789- MOVE '0136' TO WNR-EXEC-SQL. */
            _.Move("0136", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1792- MOVE 'R0136-00-ACHA-DATA' TO WPARAGRAFO */
            _.Move("R0136-00-ACHA-DATA", AREA_DE_WORK.WPARAGRAFO);

            /*" -1794- MOVE DATA3 TO DATA2. */
            _.Move(AREA_DE_WORK.LPARM2.DATA3, AREA_DE_WORK.LPARM2.DATA2);

            /*" -1794- CALL 'PROSOMC1' USING LPARM2. */
            _.Call("PROSOMC1", AREA_DE_WORK.LPARM2);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0136_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0140_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1804- MOVE '0140' TO WNR-EXEC-SQL. */
            _.Move("0140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1807- MOVE 'R0140-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0140-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1808- IF WS-CTA-ERRO NOT EQUAL SPACES */

            if (!LK_CONSISTE_CONTA.WS_CTA_ERRO.IsEmpty())
            {

                /*" -1809- PERFORM R0141-00-UPDATE-V0MOVDEBCC-CEF */

                R0141_00_UPDATE_V0MOVDEBCC_CEF_SECTION();

                /*" -1811- GO TO R0140-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1827- PERFORM R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

            R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

            /*" -1830- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1831- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1832- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -1833- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1834- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1834- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0140-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -1827- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = '1' , DTMOVTO = :V1SISTE-DTMOVABE , DTENVIO = CURRENT DATE, NSAS = :V0PARAMC-NSAS, COD_USUARIO = 'BI0031B' , NUM_REQUISICAO = :V0MOVDE-REQUISICAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND NRENDOS = :V0MOVDE-NRENDOS AND NRPARCEL = :V0MOVDE-NRPARCEL AND SIT_COBRANCA IN ( '0' , ' ' ) AND DTVENCTO <= :V0MOVDE-DTVENCTO AND COD_CONVENIO = :V0MOVDE-COD-CONVENIO AND COD_RETORNO_CEF IS NULL END-EXEC. */

            var r0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V0MOVDE_REQUISICAO = V0MOVDE_REQUISICAO.ToString(),
                V1SISTE_DTMOVABE = V1SISTE_DTMOVABE.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
            };

            R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0141-00-UPDATE-V0MOVDEBCC-CEF-SECTION */
        private void R0141_00_UPDATE_V0MOVDEBCC_CEF_SECTION()
        {
            /*" -1844- MOVE '0141' TO WNR-EXEC-SQL. */
            _.Move("0141", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1847- MOVE 'R0141-00-UPDATE-V0MOVDEBCC-CEF' TO WPARAGRAFO */
            _.Move("R0141-00-UPDATE-V0MOVDEBCC-CEF", AREA_DE_WORK.WPARAGRAFO);

            /*" -1864- PERFORM R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1 */

            R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1();

            /*" -1867- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1868- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1869- DISPLAY 'V0MOVDE-NUM-APOLICE  ' V0MOVDE-NUM-APOLICE */
                _.Display($"V0MOVDE-NUM-APOLICE  {V0MOVDE_NUM_APOLICE}");

                /*" -1870- DISPLAY 'V0MOVDE-SIT-COBRANCA ' V0MOVDE-SIT-COBRANCA */
                _.Display($"V0MOVDE-SIT-COBRANCA {V0MOVDE_SIT_COBRANCA}");

                /*" -1871- DISPLAY 'V0MOVDE-DTVENCTO     ' V0MOVDE-DTVENCTO */
                _.Display($"V0MOVDE-DTVENCTO     {V0MOVDE_DTVENCTO}");

                /*" -1871- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0141-00-UPDATE-V0MOVDEBCC-CEF-DB-UPDATE-1 */
        public void R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1()
        {
            /*" -1864- EXEC SQL UPDATE SEGUROS.V0MOVDEBCC_CEF SET SIT_COBRANCA = '1' , DTMOVTO = :V1SISTE-DTMOVABE, DTENVIO = CURRENT DATE, NSAS = :V0PARAMC-NSAS, COD_USUARIO = 'BI0031B' , DIG_CONTA_DEB = :V0MOVDE-DIG-CONTA-DEB, NUM_REQUISICAO = :V0MOVDE-REQUISICAO, TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :V0MOVDE-NUM-APOLICE AND NRENDOS = :V0MOVDE-NRENDOS AND NRPARCEL = :V0MOVDE-NRPARCEL AND SIT_COBRANCA IN ( '0' , ' ' ) AND DTVENCTO <= :V0MOVDE-DTVENCTO AND COD_CONVENIO = :V0MOVDE-COD-CONVENIO AND COD_RETORNO_CEF IS NULL END-EXEC. */

            var r0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1 = new R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1()
            {
                V0MOVDE_DIG_CONTA_DEB = V0MOVDE_DIG_CONTA_DEB.ToString(),
                V0MOVDE_REQUISICAO = V0MOVDE_REQUISICAO.ToString(),
                V1SISTE_DTMOVABE = V1SISTE_DTMOVABE.ToString(),
                V0PARAMC_NSAS = V0PARAMC_NSAS.ToString(),
                V0MOVDE_COD_CONVENIO = V0MOVDE_COD_CONVENIO.ToString(),
                V0MOVDE_NUM_APOLICE = V0MOVDE_NUM_APOLICE.ToString(),
                V0MOVDE_NRPARCEL = V0MOVDE_NRPARCEL.ToString(),
                V0MOVDE_DTVENCTO = V0MOVDE_DTVENCTO.ToString(),
                V0MOVDE_NRENDOS = V0MOVDE_NRENDOS.ToString(),
            };

            R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1.Execute(r0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0141_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-UPDATE-V0BILHETE-SECTION */
        private void R0150_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1881- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1884- MOVE 'R0150-00-UPDATE-V0BILHETE' TO WPARAGRAFO */
            _.Move("R0150-00-UPDATE-V0BILHETE", AREA_DE_WORK.WPARAGRAFO);

            /*" -1885- IF WS-MARSH EQUAL 'S' */

            if (AREA_DE_WORK.WS_MARSH == "S")
            {

                /*" -1888- IF CANAL-ELETRONICO AND V0MOVDE-NRENDOS EQUAL ZEROS NEXT SENTENCE */

                if (AREA_DE_WORK.W05_COD_PRODUTO["CANAL_ELETRONICO"] && V0MOVDE_NRENDOS == 00)
                {

                    /*" -1889- ELSE */
                }
                else
                {


                    /*" -1891- GO TO R0150-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1892- IF WS-CTA-ERRO NOT EQUAL SPACES */

            if (!LK_CONSISTE_CONTA.WS_CTA_ERRO.IsEmpty())
            {

                /*" -1893- PERFORM R0151-00-UPDATE-V0BILHETE */

                R0151_00_UPDATE_V0BILHETE_SECTION();

                /*" -1895- GO TO R0150-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1896- MOVE V0MOVDE-NUM-APOLICE TO V0BILH-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, V0BILH_NUMBIL);

            /*" -1899- MOVE '6' TO V0BILH-SITUACAO */
            _.Move("6", V0BILH_SITUACAO);

            /*" -1904- PERFORM R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1907- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1908- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1909- DISPLAY 'V0BILH-NUMBIL ' V0BILH-NUMBIL */
                _.Display($"V0BILH-NUMBIL {V0BILH_NUMBIL}");

                /*" -1909- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0150-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1904- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, COD_USUARIO = 'BI0031B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0150_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0151-00-UPDATE-V0BILHETE-SECTION */
        private void R0151_00_UPDATE_V0BILHETE_SECTION()
        {
            /*" -1919- MOVE '0151' TO WNR-EXEC-SQL. */
            _.Move("0151", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1922- MOVE 'R0151-00-UPDATE-V0BILHETE' TO WPARAGRAFO */
            _.Move("R0151-00-UPDATE-V0BILHETE", AREA_DE_WORK.WPARAGRAFO);

            /*" -1923- MOVE V0MOVDE-NUM-APOLICE TO V0BILH-NUMBIL */
            _.Move(V0MOVDE_NUM_APOLICE, V0BILH_NUMBIL);

            /*" -1925- MOVE '6' TO V0BILH-SITUACAO */
            _.Move("6", V0BILH_SITUACAO);

            /*" -1931- PERFORM R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1 */

            R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1();

            /*" -1934- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1935- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -1936- DISPLAY 'V0BILH-NUMBIL ' V0BILH-NUMBIL */
                _.Display($"V0BILH-NUMBIL {V0BILH_NUMBIL}");

                /*" -1936- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0151-00-UPDATE-V0BILHETE-DB-UPDATE-1 */
        public void R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1()
        {
            /*" -1931- EXEC SQL UPDATE SEGUROS.V0BILHETE SET SITUACAO = :V0BILH-SITUACAO, DIG_CONTA_DEB = :V0MOVDE-DIG-CONTA-DEB, COD_USUARIO = 'BI0031B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUMBIL = :V0BILH-NUMBIL END-EXEC. */

            var r0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1 = new R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1()
            {
                V0MOVDE_DIG_CONTA_DEB = V0MOVDE_DIG_CONTA_DEB.ToString(),
                V0BILH_SITUACAO = V0BILH_SITUACAO.ToString(),
                V0BILH_NUMBIL = V0BILH_NUMBIL.ToString(),
            };

            R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1.Execute(r0151_00_UPDATE_V0BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0151_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CABECALHOS-SECTION */
        private void R0160_00_CABECALHOS_SECTION()
        {
            /*" -1946- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1949- MOVE 'R0160-00-CABECALHOS ' TO WPARAGRAFO */
            _.Move("R0160-00-CABECALHOS ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1950- MOVE V0PARAMC-NSAS TO LC06-NRFITA */
            _.Move(V0PARAMC_NSAS, AREA_DE_WORK.LC06.LC06_NRFITA);

            /*" -1951- COMPUTE WPAG = WPAG + 1 */
            AREA_DE_WORK.WPAG.Value = AREA_DE_WORK.WPAG + 1;

            /*" -1953- MOVE WPAG TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.WPAG, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1954- WRITE REG-BI0031B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1955- WRITE REG-BI0031B FROM LC02 AFTER 1 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1956- WRITE REG-BI0031B FROM LC03 AFTER 1 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1957- WRITE REG-BI0031B FROM LC07 AFTER 1 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1958- WRITE REG-BI0031B FROM LC06 AFTER 1 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1959- WRITE REG-BI0031B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1960- WRITE REG-BI0031B FROM LC05 AFTER 1 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1962- WRITE REG-BI0031B FROM LC04 AFTER 1 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1962- MOVE 08 TO WLIN. */
            _.Move(08, AREA_DE_WORK.WLIN);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0170-00-TOTALIZADOR-SECTION */
        private void R0170_00_TOTALIZADOR_SECTION()
        {
            /*" -1972- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1975- MOVE 'R0170-00-TOTALIZADOR     ' TO WPARAGRAFO */
            _.Move("R0170-00-TOTALIZADOR     ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1976- COMPUTE WTOTREG = WTOTREG - 2 */
            AREA_DE_WORK.WTOTREG.Value = AREA_DE_WORK.WTOTREG - 2;

            /*" -1977- MOVE WTOTREG TO LT01-QT-TOTAL */
            _.Move(AREA_DE_WORK.WTOTREG, AREA_DE_WORK.LT01.LT01_QT_TOTAL);

            /*" -1979- MOVE WTOTDEB TO LT01-VL-TOTAL */
            _.Move(AREA_DE_WORK.WTOTDEB, AREA_DE_WORK.LT01.LT01_VL_TOTAL);

            /*" -1979- WRITE REG-BI0031B FROM LT01 AFTER 2. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_99_SAIDA*/

        [StopWatch]
        /*" R0180-00-RELAT-SEM-MOVTO-SECTION */
        private void R0180_00_RELAT_SEM_MOVTO_SECTION()
        {
            /*" -1989- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1992- MOVE 'R0180-00-RELAT-SEM-MOVTO ' TO WPARAGRAFO */
            _.Move("R0180-00-RELAT-SEM-MOVTO ", AREA_DE_WORK.WPARAGRAFO);

            /*" -1993- WRITE REG-BI0031B FROM LD02 AFTER 2 */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1994- WRITE REG-BI0031B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1995- WRITE REG-BI0031B FROM LD03 AFTER 1 */
            _.Move(AREA_DE_WORK.LD03.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1996- WRITE REG-BI0031B FROM LD04 AFTER 1 */
            _.Move(AREA_DE_WORK.LD04.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

            /*" -1996- WRITE REG-BI0031B FROM LD02 AFTER 1. */
            _.Move(AREA_DE_WORK.LD02.GetMoveValues(), REG_BI0031B);

            RBI0031B.Write(REG_BI0031B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-SECTION */
        private void R0200_00_CARREGA_ORIGEM_SECTION()
        {
            /*" -2006- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2009- MOVE 'R0200-00-CARREGA-ORIGEM' TO WPARAGRAFO */
            _.Move("R0200-00-CARREGA-ORIGEM", AREA_DE_WORK.WPARAGRAFO);

            /*" -2015- PERFORM R0200_00_CARREGA_ORIGEM_DB_DECLARE_1 */

            R0200_00_CARREGA_ORIGEM_DB_DECLARE_1();

            /*" -2017- PERFORM R0200_00_CARREGA_ORIGEM_DB_OPEN_1 */

            R0200_00_CARREGA_ORIGEM_DB_OPEN_1();

            /*" -2020- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2021- DISPLAY 'PROBLEMAS NO OPEN CORIGEM ' */
                _.Display($"PROBLEMAS NO OPEN CORIGEM ");

                /*" -2024- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2025- PERFORM UNTIL WFIM-SISTEMA-ORIGEM EQUAL 'SIM' */

            while (!(AREA_DE_WORK.WFIM_SISTEMA_ORIGEM == "SIM"))
            {

                /*" -2027- PERFORM R0200_00_CARREGA_ORIGEM_DB_FETCH_1 */

                R0200_00_CARREGA_ORIGEM_DB_FETCH_1();

                /*" -2029- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -2030- ADD 1 TO WIND1 */
                    AREA_DE_WORK.WIND1.Value = AREA_DE_WORK.WIND1 + 1;

                    /*" -2032- MOVE ARQSIVPF-SISTEMA-ORIGEM TO WTAB-SISTEMA-ORIGEM (WIND1) */
                    _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM, W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND1]);

                    /*" -2033- ELSE */
                }
                else
                {


                    /*" -2034- IF SQLCODE EQUAL 100 */

                    if (DB.SQLCODE == 100)
                    {

                        /*" -2035- MOVE 'SIM' TO WFIM-SISTEMA-ORIGEM */
                        _.Move("SIM", AREA_DE_WORK.WFIM_SISTEMA_ORIGEM);

                        /*" -2035- PERFORM R0200_00_CARREGA_ORIGEM_DB_CLOSE_1 */

                        R0200_00_CARREGA_ORIGEM_DB_CLOSE_1();

                        /*" -2037- ELSE */
                    }
                    else
                    {


                        /*" -2038- DISPLAY 'PROBLEMAS NO FETCH CORIGEM ' */
                        _.Display($"PROBLEMAS NO FETCH CORIGEM ");

                        /*" -2039- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2040- END-IF */
                    }


                    /*" -2041- END-IF */
                }


                /*" -2041- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-OPEN-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_OPEN_1()
        {
            /*" -2017- EXEC SQL OPEN CORIGEM END-EXEC. */

            CORIGEM.Open();

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-FETCH-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_FETCH_1()
        {
            /*" -2027- EXEC SQL FETCH CORIGEM INTO :ARQSIVPF-SISTEMA-ORIGEM END-EXEC */

            if (CORIGEM.Fetch())
            {
                _.Move(CORIGEM.ARQSIVPF_SISTEMA_ORIGEM, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);
            }

        }

        [StopWatch]
        /*" R0200-00-CARREGA-ORIGEM-DB-CLOSE-1 */
        public void R0200_00_CARREGA_ORIGEM_DB_CLOSE_1()
        {
            /*" -2035- EXEC SQL CLOSE CORIGEM END-EXEC */

            CORIGEM.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-VERIFICA-ORIGEM-SECTION */
        private void R0300_00_VERIFICA_ORIGEM_SECTION()
        {
            /*" -2051- MOVE '0300' TO WNR-EXEC-SQL */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2054- MOVE 'R0300-00-VERIFICA-ORIGEM ' TO WPARAGRAFO */
            _.Move("R0300-00-VERIFICA-ORIGEM ", AREA_DE_WORK.WPARAGRAFO);

            /*" -2055- MOVE 1 TO WINF. */
            _.Move(1, AREA_DE_WORK.WINF);

            /*" -2056- MOVE WIND1 TO WSUP. */
            _.Move(AREA_DE_WORK.WIND1, AREA_DE_WORK.WSUP);

            /*" -2058- MOVE SPACES TO WTEM-SISTEMA-ORIGEM */
            _.Move("", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

            /*" -2059- PERFORM UNTIL WTEM-SISTEMA-ORIGEM NOT EQUAL SPACES */

            while (!(!AREA_DE_WORK.WTEM_SISTEMA_ORIGEM.IsEmpty()))
            {

                /*" -2060- IF WINF > WSUP */

                if (AREA_DE_WORK.WINF > AREA_DE_WORK.WSUP)
                {

                    /*" -2061- MOVE 'NAO' TO WTEM-SISTEMA-ORIGEM */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                    /*" -2062- ELSE */
                }
                else
                {


                    /*" -2063- COMPUTE WIND = (WSUP + WINF) / 2 */
                    AREA_DE_WORK.WIND.Value = (AREA_DE_WORK.WSUP + AREA_DE_WORK.WINF) / 2;

                    /*" -2065- IF PROPOFID-ORIGEM-PROPOSTA < WTAB-SISTEMA-ORIGEM(WIND) */

                    if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA < W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND])
                    {

                        /*" -2066- COMPUTE WSUP = WIND - 1 */
                        AREA_DE_WORK.WSUP.Value = AREA_DE_WORK.WIND - 1;

                        /*" -2067- ELSE */
                    }
                    else
                    {


                        /*" -2069- IF PROPOFID-ORIGEM-PROPOSTA > WTAB-SISTEMA-ORIGEM(WIND) */

                        if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA > W_TAB_SISTEMA_ORIGEM.WTAB_SISTEMA_ORIGEM[AREA_DE_WORK.WIND])
                        {

                            /*" -2070- COMPUTE WINF = WIND + 1 */
                            AREA_DE_WORK.WINF.Value = AREA_DE_WORK.WIND + 1;

                            /*" -2071- ELSE */
                        }
                        else
                        {


                            /*" -2072- MOVE 'SIM' TO WTEM-SISTEMA-ORIGEM */
                            _.Move("SIM", AREA_DE_WORK.WTEM_SISTEMA_ORIGEM);

                            /*" -2073- END-IF */
                        }


                        /*" -2074- END-IF */
                    }


                    /*" -2075- END-IF */
                }


                /*" -2075- END-PERFORM. */
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R8000-PESQUISA-HIS-COBER-SECTION */
        private void R8000_PESQUISA_HIS_COBER_SECTION()
        {
            /*" -2084- MOVE '8000' TO WNR-EXEC-SQL */
            _.Move("8000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2086- MOVE 'R8000-00-VERIFICA-ORIGEM' TO WPARAGRAFO */
            _.Move("R8000-00-VERIFICA-ORIGEM", AREA_DE_WORK.WPARAGRAFO);

            /*" -2087- MOVE 'N' TO IND-FLUXO-PARAM */
            _.Move("N", AREA_DE_WORK.IND_FLUXO_PARAM);

            /*" -2090- MOVE V1BILH-NUMBIL TO HISCOBPR-NUM-CERTIFICADO WS-BIGINT(01) */
            _.Move(V1BILH_NUMBIL, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO, AREA_DE_WORK.WS_BIGINT[01]);

            /*" -2102- PERFORM R8000_PESQUISA_HIS_COBER_DB_SELECT_1 */

            R8000_PESQUISA_HIS_COBER_DB_SELECT_1();

            /*" -2105- IF NOT ( SQLCODE = 0 OR = 100 ) */

            if (!(DB.SQLCODE.In("0", "100")))
            {

                /*" -2106- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -2107- DISPLAY '<NUM_CERTIFICADO=' WS-BIGINT(01) '>' */

                $"<NUM_CERTIFICADO={AREA_DE_WORK.WS_BIGINT[1]}>"
                .Display();

                /*" -2108- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2110- END-IF */
            }


            /*" -2111- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2112- MOVE 'N' TO IND-FLUXO-PARAM */
                _.Move("N", AREA_DE_WORK.IND_FLUXO_PARAM);

                /*" -2113- GO TO R8000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;

                /*" -2115- END-IF */
            }


            /*" -2117- PERFORM R8001-CALL-GE0070S */

            R8001_CALL_GE0070S_SECTION();

            /*" -2119- MOVE LK-0070-S-IND-FLUXO-PARAM TO IND-FLUXO-PARAM */
            _.Move(GE0070W.LK_0070_S_IND_FLUXO_PARAM, AREA_DE_WORK.IND_FLUXO_PARAM);

            /*" -2119- . */

        }

        [StopWatch]
        /*" R8000-PESQUISA-HIS-COBER-DB-SELECT-1 */
        public void R8000_PESQUISA_HIS_COBER_DB_SELECT_1()
        {
            /*" -2102- EXEC SQL SELECT VALUE(A.COD_PRODUTO,0) ,VALUE(A.SEQ_PRODUTO_VRS,0) INTO :HISCOBPR-COD-PRODUTO ,:HISCOBPR-SEQ-PRODUTO-VRS FROM SEGUROS.HIS_COBER_PROPOST A WHERE A.NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO AND A.OCORR_HISTORICO = ( SELECT MAX(VW1.OCORR_HISTORICO) FROM SEGUROS.HIS_COBER_PROPOST VW1 WHERE VW1.NUM_CERTIFICADO = A.NUM_CERTIFICADO ) END-EXEC. */

            var r8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1 = new R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1()
            {
                HISCOBPR_NUM_CERTIFICADO = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1.Execute(r8000_PESQUISA_HIS_COBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_COD_PRODUTO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_PRODUTO);
                _.Move(executed_1.HISCOBPR_SEQ_PRODUTO_VRS, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_SEQ_PRODUTO_VRS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8001-CALL-GE0070S-SECTION */
        private void R8001_CALL_GE0070S_SECTION()
        {
            /*" -2130- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R8001_00_START */

            R8001_00_START();

        }

        [StopWatch]
        /*" R8001-00-START */
        private void R8001_00_START(bool isPerform = false)
        {
            /*" -2133- MOVE '8001' TO WNR-EXEC-SQL */
            _.Move("8001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -2135- MOVE 'R8001-CALL-GE0070S' TO WPARAGRAFO */
            _.Move("R8001-CALL-GE0070S", AREA_DE_WORK.WPARAGRAFO);

            /*" -2136- MOVE 'N' TO LK-0070-E-TRACE */
            _.Move("N", GE0070W.LK_0070_E_TRACE);

            /*" -2137- MOVE 'BATCH' TO LK-0070-E-COD-USUARIO */
            _.Move("BATCH", GE0070W.LK_0070_E_COD_USUARIO);

            /*" -2138- MOVE 'BI0031B' TO LK-0070-E-NOM-PROGRAMA */
            _.Move("BI0031B", GE0070W.LK_0070_E_NOM_PROGRAMA);

            /*" -2139- MOVE 01 TO LK-0070-E-ACAO */
            _.Move(01, GE0070W.LK_0070_E_ACAO);

            /*" -2140- MOVE HISCOBPR-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -2142- MOVE HISCOBPR-SEQ-PRODUTO-VRS TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_SEQ_PRODUTO_VRS, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -2144- MOVE SPACES TO LK-0070-I-DTA-PROPOSTA */
            _.Move("", GE0070W.LK_0070_I_DTA_PROPOSTA);

            /*" -2146- . */

            /*" -2146- PERFORM R8001-05-INICIO. */

            R8001_05_INICIO(true);

        }

        [StopWatch]
        /*" R8001-05-INICIO */
        private void R8001_05_INICIO(bool isPerform = false)
        {
            /*" -2191- CALL 'GE0070S' USING LK-0070-E-TRACE LK-0070-E-COD-USUARIO LK-0070-E-NOM-PROGRAMA LK-0070-E-ACAO LK-0070-I-COD-PRODUTO LK-0070-I-SEQ-PRODUTO-VRS LK-0070-I-DTA-PROPOSTA LK-0070-S-DTA-INI-VIGENCIA LK-0070-S-DTA-FIM-VIGENCIA LK-0070-S-IND-FLUXO-PARAM LK-0070-S-COD-PERIOD-VIGENCIA LK-0070-S-QTD-PERIOD-VIGENCIA LK-0070-S-COD-MOEDA LK-0070-S-IND-RENOVA LK-0070-S-IND-RENOVA-AUTOMAT LK-0070-S-QTD-RENOVA-AUTOMAT LK-0070-S-IND-DPS LK-0070-S-IND-REENQUADRA-PREM LK-0070-S-IND-REAJUSTE-PREMIO LK-0070-S-COD-INDICE-REAJUSTE LK-0070-S-COD-PERIOD-REAJUSTE LK-0070-S-COD-INDC-DEVOLUCAO LK-0070-S-PCT-JUROS-DEVOLUCAO LK-0070-S-PCT-MULTA-DEVOLUCAO LK-0070-S-IND-FLUXO-COMISSAO LK-0070-S-IND-ACOPLADO LK-0070-S-IND-FLUXO-SINISTRO LK-0070-S-IND-CONJUGE LK-0070-S-COD-USUARIO LK-0070-S-NOM-PROGRAMA LK-0070-S-DTH-CADASTRAMENTO LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE */
            _.Call("GE0070S", GE0070W);

            /*" -2192- IF LK-0070-IND-ERRO NOT = 0 */

            if (GE0070W.LK_0070_IND_ERRO != 0)
            {

                /*" -2193- MOVE LK-0070-IND-ERRO TO WS-SMALLINT(01) */
                _.Move(GE0070W.LK_0070_IND_ERRO, AREA_DE_WORK.WS_SMALLINT[01]);

                /*" -2194- MOVE LK-0070-SQLCODE TO WS-SMALLINT(02) */
                _.Move(GE0070W.LK_0070_SQLCODE, AREA_DE_WORK.WS_SMALLINT[02]);

                /*" -2195- DISPLAY 'BI0031B - ' WPARAGRAFO */
                _.Display($"BI0031B - {AREA_DE_WORK.WPARAGRAFO}");

                /*" -2196- DISPLAY '*** ERRO NA GE0070S ***' */
                _.Display($"*** ERRO NA GE0070S ***");

                /*" -2197- DISPLAY '<NUM_CERTIFICADO=' WS-BIGINT(01) '>' */

                $"<NUM_CERTIFICADO={AREA_DE_WORK.WS_BIGINT[1]}>"
                .Display();

                /*" -2203- DISPLAY '<IND-ERRO=' WS-SMALLINT(01) '>' '<MSG-ERRO=' LK-0070-MSG-ERRO '>' '<NOM-TABELA=' LK-0070-NOM-TABELA '>' '<SQLCODE=' WS-SMALLINT(02) '>' '<SQLERRMC=' LK-0070-SQLERRMC '>' '<SQLSTATE=' LK-0070-SQLSTATE '>' */

                $"<IND-ERRO={AREA_DE_WORK.WS_SMALLINT[1]}><MSG-ERRO={GE0070W.LK_0070_MSG_ERRO}><NOM-TABELA={GE0070W.LK_0070_NOM_TABELA}><SQLCODE={AREA_DE_WORK.WS_SMALLINT[2]}><SQLERRMC={GE0070W.LK_0070_SQLERRMC}><SQLSTATE={GE0070W.LK_0070_SQLSTATE}>"
                .Display();

                /*" -2204- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2206- END-IF */
            }


            /*" -2206- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8001_99_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2217- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -2219- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -2219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -2221- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2225- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2225- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}