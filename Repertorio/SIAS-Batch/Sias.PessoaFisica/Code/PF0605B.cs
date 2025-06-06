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
using Sias.PessoaFisica.DB2.PF0605B;

namespace Code
{
    public class PF0605B
    {
        public bool IsCall { get; set; }

        public PF0605B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA.. ..............  SISTEMA DE PRODUTOS DE FIDELIZACAO *      */
        /*"      *   ANALISE/PROGRAMACAO.....  LUIZ CARLOS / REGINALDO SILVA      *      */
        /*"      *   PROGRAMA ...............  PF0605B                            *      */
        /*"      *   DATA ...................  29/01/2008.                        *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  GERAR STATUS DE VIDA E BILHETE     *      */
        /*"      *                             PARA O SIGPF CAIXA.                *      */
        /*"      *                                                                *      */
        /*"      *   OBS.: POR SOLICITACAO DA CEF, GERAMOS UM STATUS POR VEZ, SEM *      */
        /*"      *         PRE O MAIOR CODIGO DE ERRO NA TAB. ERROS-PROP-VIDAZUL. *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                        ATUALIZACOES                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.38  *   VERSAO 38 - DEMANDA 575149                                   *      */
        /*"      *             - TRATAR PRODUTO 3729 (APOIO + FUTURO)             *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/06/2024 - CANETTA              PROCURE POR V.38        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.37  *   VERSAO 37 - DEMANDA 538808                                   *      */
        /*"      *             - NAO ENVIAR COBERTURA INVALIDEZ POR MORTE         *      */
        /*"      *                ACIDENTAL PARA OS PRODUTOS 8533 8534            *      */
        /*"      *                                                                *      */
        /*"      *   EM 01/06/2024 - CANETTA              PROCURE POR V.37        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.37  *   VERSAO 37 - INCIDENTE 484.074                                *      */
        /*"      *               INCLUSAO DOS PRODUTOS SEGURO PROTECAO EXECUTIVA  *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/03/2024 - TERCIO CARVALHO      PROCURE POR V.37        *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.36  *   VERSAO 36 - DEMANDA 539589                                   *      */
        /*"      *             - NAO ENVIAR COBERTURA INVALIDEZ POR MORTE         *      */
        /*"      *                ACIDENTAL PARA OS PRODUTOS 8528, 8529           *      */
        /*"      *                                                                *      */
        /*"      *   EM 22/02/2024 - THIAGO BLAIER                                *      */
        /*"      *                                        PROCURE POR V.36        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.35  *   VERSAO 35 - DEMANDA 568.044                                  *      */
        /*"      *             - ENVIA O STATUS PARA O NOVO PRODUTO SIVPF 37      *      */
        /*"      *               VIDA EXECUTIVO.                                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 23/01/2023 - FRANK CARVALHO                               *      */
        /*"      *                                        PROCURE POR V.35        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.34  *   VERSAO 34 - DEMANDA 499072                                   *      */
        /*"      *             - AJUSTE EM PROGRAMA PARA ENVIO DO STATUS DE       *      */
        /*"      *               PROPOSTAS  DE BILHETE COM PRODUTO-SIVPF = 9      *      */
        /*"      *               RENOVADOS                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/07/2023 - THIAGO BLAIER                                *      */
        /*"      *                                        PROCURE POR V.34        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.33  *   VERSAO 33 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA BILHETE_ERROS      *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2023 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.33        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 32 - DEMANDA  425398                                  *      */
        /*"      *               AJUSTES PARA ENVIAR PROPOSTAS APOLICE ESPECIFICA *      */
        /*"      *               CAAAAPPNNNNNND                                   *      */
        /*"      *               C      = Canal (pode Ser: 1, 2, 3, 6, 7, 8 e 9)  *      */
        /*"      *               AAAA   = Agencia de venda da proposta            *      */
        /*"      *               PP     = Codigo Produto                          *      */
        /*"      *               NNNNNN = Numero Sequencial da venda do produto   *      */
        /*"      *               D      = Digito Verificador calculo pelo Mod. 10 *      */
        /*"      *   EM SET/2022 - THIAGO BLAIER                                  *      */
        /*"      *                                       PROCURE POR V.32         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ATENDE JAZZ - 232634 - SENSIBILIZACAO DO SIGPF PARA OS         *      */
        /*"      *                        PRODUTOS ATM E CAIXA EXECUTIVO          *      */
        /*"      *    INCLUIR ORIGENS DA PROPOSTA ATM E CAIXA EXECUTIVO E         *      */
        /*"      *    PRODUTOS SIVPF 10 E 29                                      *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V31          THIAGO BATISTA                            *      */
        /*"      *                       03/2021                                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 30             PARA AS PROPOSTAS COMERCIALIZADAS COM A  *      */
        /*"      * PROJ. AUTO COMPRA     ORIGEM 1009 E 1010 DEVERA A ADESAO COM   *      */
        /*"      * DEMANDA 244.137       MOTIVO 228, POIS SENSIBILIZAMOS A PROPOS-*      */
        /*"      *                       TA ATRAVES DO MVPROP.                    *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.27          FRANK CARVALHO                           *      */
        /*"      *                       18/11/2020                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 29            PARA AS PROPOSTAS COMERCIALIZADAS COM A   *      */
        /*"      * DEMANDA 249184       OPCAO DE PAGAMETNO CARTAO DE CREDITO A    *      */
        /*"      *                      SENSIBILIZACAO DO STATUS VAI PASSAR A SER *      */
        /*"      *                      COM MOTIVO 000, ALTERACAO FEITA PARA QUE  *      */
        /*"      *                      NAO DUPLIQUEM AS PROPOSTAS GERADAS        *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.29         FELIPE TOGAWA                             *      */
        /*"      *                      24/06/2020                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 28             NAO ENVIAR A COBERTURA 2 PARA OS PRODUTOS*      */
        /*"      * DEMANDA 217238        8112 E 8113.                             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.28          CLAUDETE RADEL                           *      */
        /*"      *                       04/12/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 27             PARA AS PROPOSTAS COMERCIALIZADAS COM A  *      */
        /*"      * PROJ. CARTAO CIELO    OPCAO DE PAGAMENTO CARTAO DE CREDITO A   *      */
        /*"      *                       SENSIBILIZACAO DO STATUS DEVERA SER COM  *      */
        /*"      *                       MOTIVO 228, UMA VEZ QUE O PAGAMENTO VIA  *      */
        /*"      *                       CARTAO NAO PASSA PELA CAIXA.             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.27          FRANK CARVALHO                           *      */
        /*"      *                       04/07/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 26             CORRIGIR SENSIBILIZACAO DO AMPARO. ALTE- *      */
        /*"      * DEMANDA 173020        RAR O CODIGO DE 0102 PARA 0012 CONFORME  *      */
        /*"      *                       ESPECIFICACAO DA DEMANDA.                *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.26          FRANK CARVALHO                           *      */
        /*"      *                       11/03/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"JV.01 *   VERSAO 25 - PROJETO JOINT VENTURE (JV)                       *      */
        /*"=     *             - AVALIAR IMPACTO PRODUTO, APOLICE, ORGAO, ETC.    *      */
        /*"=     *             - Historia: 188284.                                *      */
        /*"=     *    EM 14/02/2019 - HERVAL SOUZA                                *      */
        /*"=     *                                        PROCURE POR JV.01       *      */
        /*"JV.01 *----------------------------------------------------------------*      */
        /*"      * VERSAO 24             ALTERACAO PARA ACERTAR DATA_TERVIGENCIA  *      */
        /*"      * ATENDE CADMUS 156.890 PARA OS PRODUTOS PU..                    *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.24          THIAGO BLAIER                            *      */
        /*"      *                       12/12/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 23             INCLUSOES DOS PROGRAMAS VA0116B E VA0118B*      */
        /*"      * ATENDE CADMUS 155.544 QUE AGORA REALIZAM DECLINIO DE PROPOSTAS *      */
        /*"      *                       DO PRODUTO VIDA DA GENTE.                *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.23          FRANK CARVALHO                           *      */
        /*"      *                       08/12/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 22             AJUSTE PARA NAO ENVIAR DUAS COBERTURAS   *      */
        /*"      * ATENDE CADMUS 153555  PARA OS PRODUTOS:                        *      */
        /*"      *                       8144,8145,8146,8147,8148,8149,8150       *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.22          THIAGO BLAIER                            *      */
        /*"      *                       04/09/2017                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 21             AJUSTE NO ENVIO DE SITUACAO DA PROPOSTA  *      */
        /*"      * ATENDE CADMUS 117698  MAN PARA EMT                             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.21          THIAGO BLAIER                            *      */
        /*"      *                       13/07/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 20             AJUSTE NRO PROPOSTA ZERADA               *      */
        /*"      * ATENDE CADMUS 104288                                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.20          REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       08/10/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 19             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       11/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 18 - REGINALDO SILVA  25/02/2012  (MILLENIUM)           *      */
        /*"      *                                                                *      */
        /*"      * SOLICITACAO VIA ...CADMUS 79704 - ROMINA                       *      */
        /*"      *                    CALCULO  DA DATA DE TERMINO DE VIGENCIA DOS *      */
        /*"      *                    PRODUTOS 7705 E 7707 COM O COD_PLANO        *      */
        /*"      *                    SEGUROS.MOVIMENTO_VGAP                      *      */
        /*"      * PROCURAR POR    V.18                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 17 - MARCO PAIVA    30/05/2012    (FAST COMPUTER)       *      */
        /*"      *                                                                *      */
        /*"      * SOLICITACAO VIA ...CADMUS 70.303                               *      */
        /*"      *                    CORRECAO DO ABEND SQLCODE = 100 NA TABELA   *      */
        /*"      *                    SEGUROS.MOVIMENTO_VGAP                      *      */
        /*"      * PROCURAR POR    V.17                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 16 - EDIVALDO GOMES 26/10/2010    (FAST COMPUTER)       *      */
        /*"      *                                                                *      */
        /*"      * SOLICITACAO VIA ...CADMUS 201.115                              *      */
        /*"      *                    PROCESSAR QUANDO A ORIGEM_PROPOSTA FOR 1005.*      */
        /*"      * PROCURAR POR    V.16                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15 - SERGIO LORETO  26/10/2010                          *      */
        /*"      *                                                                *      */
        /*"      * SOLICITACAO VIA ...CADMUS 49336                                *      */
        /*"      *                    INCLUIR A SEGUINTE CONDICAO:                *      */
        /*"      *                       AND A.ORIGEM_PROPOSTA  <> 1001           *      */
        /*"      * PROCURAR POR===> C49336                                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14 -                                                    *      */
        /*"      * SOLICITACAO VIA ...CADMUS 43617                                *      */
        /*"      * 09/06/2010 PROCURE POR V.14 - EDSON MARQUES                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13 -                                                    *      */
        /*"      * SOLICITACAO VIA ...CADMUS 40634                                *      */
        /*"      * 14/04/2010 PROCURE POR V.13 - EDSON MARQUES                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12 -                                                    *      */
        /*"      * SOLICITACAO VIA ...CADMUS 39163/41379                          *      */
        /*"      * 16/03/2010 PROCURE POR V.12 - EDSON MARQUES                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11 - ATENDE CADMUS 34327                                *      */
        /*"      *                                                                *      */
        /*"      * 15/12/2009 PROCURE POR V.11 - EDILANA                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10 - ATENDE CADMUS32886                                 *      */
        /*"      *                                                                *      */
        /*"      * 18/11/2009 PROCURE POR V.10 - EDILANA                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09 - ADEQUACAO PARA TRATAR VIDA DA GENTE, VIDA MULHER OU*      */
        /*"      *             PRESTAMISTA COMERCIALIZADO NA GITEL.               *      */
        /*"      *           - INCLUI GRAVACAO NA TAB.RELATORIO                   *      */
        /*"      *                                                                *      */
        /*"      * 03/06/2009 PROCURE POR V.08 - EDILANA / LUIZ CARLOS            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 08 - INCLUIR SEGURO PRESTAMISTA                         *      */
        /*"      *                                                                *      */
        /*"      * 08/05/2009 PROCURE POR V.08 - EDILANA E. CERQUEIRA             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 07 - INCLUIR CANAL  - CORRESPONDENTE NEGOCIAL           *      */
        /*"      *            ATENDE - SSI 21887  SAF LOTERICO                    *      */
        /*"      *                                                                *      */
        /*"      * 03/09/2008 PROCURE POR V.07 - LUCIA VIEIRA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 06 - PASSA A ENVIAR MAIS DE 99999 STATUS                *      */
        /*"      *            ATENDE - SSI 20683                                  *      */
        /*"      *                                                                *      */
        /*"      * 13/06/2008 PROCURE POR V.06 - LUCIA VIEIRA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 05 - ADEQUACAO PARA BILHETE FACIL VIDA TRANQUILA  -     *      */
        /*"      *             VENDIDO NA CENTRAL RELACIONAMENTO FENAE - MARSH    *      */
        /*"      *            ATENDE - SSI 20683                                  *      */
        /*"      *                                                                *      */
        /*"      * 10/06/2008 PROCURE POR V.05 - LUCIA VIEIRA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 04- ATENDER SSI 21955 -VIDA DA GENTE - GITEL            *      */
        /*"      *                                                                *      */
        /*"      * 30/05/2008 PROCURE POR V.04 - LUCIA VIEIRA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 3 - DESPREZAR COD_PRODUTO_SIVPF IGUAL A 48. TRATA-SE DA *      */
        /*"      *            INTERNALIZACAO DE APOLICE ESPECIFICA DE VIDA.       *      */
        /*"      *                                                                *      */
        /*"      * 27/11/2007 PROCURE POR V.03 - MAURICIO LINKE.                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - ATENDE SSI 14784 - SUBSTITUI DATA TERVIGENCIA    *      */
        /*"      *               31129999 POR DATA TERVIGENCIA CALCULADA   =      *      */
        /*"      *                            DATA INIVIGENCIA + 1 YEAR           *      */
        /*"      *   EM 23/04/2007 - LUCIA VIEIRA             PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PASSOU A TRATAR CANAL GITEL PARA BILHETES        *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/10/2006 - FAST COMPUTER            PROCURE POR V.01    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 12-03-2004: PASSOU A TRATAR AS TABELAS DE VIDA NA FAIXA DE*      */
        /*"      *                  NUMERACAO 10000000000 E  19999999999, PASSANDO*      */
        /*"      *                  A INCLUIR O DV PARA ENVIO A CEF.              *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR 120304                                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   EM 06-03-2003: PASSOU A ACESSAR A TABELA BILHETE_COBER, TENDO*      */
        /*"      *                  O PREMIO PAGO COMO BASE. ESTE ACESSO SERA   NO*      */
        /*"      *                  CASO DA COBERTURA NAO SER ENCONTRADA NO ACESSO*      */
        /*"      *                  UTILIZANDO AS DATAS (SAO PARA BILHETES COM CO-*      */
        /*"      *                  BERTURAS VENCIADAS).                          *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR 060303.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 19-06-2002: POR SOLICITACAO DO SR. SERGIO, TODA PROPOSTA  *      */
        /*"      *                  ELETRONICA SIVPF DIGITADA NO SIAS, PASSA A TER*      */
        /*"      *                  O TIPO DE MOTIVO 228 (SENSIBILIZA  O POSITIVA *      */
        /*"      *                  NO SIDEM).                                    *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR 190602.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14-06-2002: POR SOLICITACAO DO SR. SERGIO, O STATUS DE PEN*      */
        /*"      *                  CODIGO 728 - AGUARDANDO PROPOSTA FISICA, SO DE*      */
        /*"      *                  VERA  SER ENVIADO  A CEF, 7 DIAS APOS INTEGRA-*      */
        /*"      *                  DO NO SIAS.                                   *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR 130602.                                          *      */
        /*"      *                                                                *      */
        /*"      *   EM 03-11-2001: PASSOU A GERAR O PREMIO LIQUIDO DE IOF, INFOR-*      */
        /*"      *                  MAR O NUMERO DA APOLICE DO BILHETE E ATUALIZAR*      */
        /*"      *                  A COLUNA VAL_IOF DA TABELA PROPOSTA_FIDELIZ.  *      */
        /*"      *                                                                *      */
        /*"      *   PROCURE POR LC1201.                                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_STA_SASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_SASSE
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA_SASSE); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA_SASSE, REG_STA_SASSE); return _MOVTO_STA_SASSE;
            }
        }
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  PARAMETROS.*/
        public PF0605B_PARAMETROS PARAMETROS { get; set; } = new PF0605B_PARAMETROS();
        public class PF0605B_PARAMETROS : VarBasis
        {
            /*"    05 LK-APOLICE                    PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05 LK-SUBGRUPO                   PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-IDADE                      PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05 LK-NASCIMENTO.*/
            public PF0605B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new PF0605B_LK_NASCIMENTO();
            public class PF0605B_LK_NASCIMENTO : VarBasis
            {
                /*"       10 LK-DATA-NASCIMENTO         PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 LK-SALARIO                    PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-INV-POR-ACIDENTE      PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_INV_POR_ACIDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-COBT-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-MORTE-ACIDENTAL       PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-INV-PERMANENTE        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-ASS-MEDICA            PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-HOSPITALAR     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PURO-DIARIA-INTERNACAO     PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-MORTE-NATURAL         PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-ACIDENTES-PESSOAIS    PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-PREM-TOTAL                 PIC S9(013)V99 COMP-3.*/
            public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05 LK-RETURN-CODE                PIC S9(03) COMP-3.*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
            /*"    05 LK-MENSAGEM                   PIC  X(77).*/
            public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
            /*"01  NUM-APOL-ANT                  PIC S9(013)   VALUE +0 COMP-3.*/
        }
        public IntBasis NUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  W-TEM-RENOVACAO                   PIC X(03) VALUE SPACES.*/
        public StringBasis W_TEM_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
        /*"01  DATA-LIB-STA-PEN                  PIC X(010).*/
        public StringBasis DATA_LIB_STA_PEN { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WAREA-AUXILIAR.*/
        public PF0605B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0605B_WAREA_AUXILIAR();
        public class PF0605B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  WS-DESPREZA-STATUS            PIC X(003)  VALUE SPACES.*/
            public StringBasis WS_DESPREZA_STATUS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WS-TEM-HIST-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis WS_TEM_HIST_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-MOVTO-FIDELIZ           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_FIDELIZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-COB             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_COB { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-ERROS-VDZ               PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_ERROS_VDZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-BILHETE-ERROS           PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_BILHETE_ERROS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-TIME                        PIC  9(08).*/
            public IntBasis W_TIME { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05  W-TIME-EDIT                   PIC  99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-CONTROLE                    PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-REG-BIL-AP                  PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_REG_BIL_AP { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-PRM-LIQ                     PIC  9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
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
            /*"    05  W-ABEND-CTR                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_ABEND_CTR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-VIDA                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_VIDA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-PROD                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_PROD { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-USUA                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_USUA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-SICOB                  PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-SEGU                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_SEGU { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-PEND                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_PEND { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-HIST                   PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_HIST { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-DESP-MOTIVO                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_DESP_MOTIVO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-AP                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_AP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-MIC-AMPARO             PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_MIC_AMPARO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-LIDO-BIL-RD                 PIC  9(06)  VALUE ZEROS.*/
            public IntBasis W_LIDO_BIL_RD { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
            /*"    05  W-TOT-GERADO-STA              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_STA { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-BILHETE-LIDO                PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_BILHETE_LIDO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0605B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_PF0605B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_PF0605B_FILLER_0(); _.Move(W_COD_COBERTURA, _filler_0); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_0, W_COD_COBERTURA); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_COD_COBERTURA); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0605B_FILLER_0 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NSAS                        PIC 9(006).*/

                public _REDEF_PF0605B_FILLER_0()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(006).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  WDTA-TERVG-CALC               PIC X(010)  VALUE SPACES.*/
            public StringBasis WDTA_TERVG_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0605B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0605B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0605B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0605B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0605B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0605B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0605B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0605B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0605B_W_DTMOVABE1 : VarBasis
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
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_PF0605B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0605B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0605B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0605B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0605B_W_DTMOVABE_I1 : VarBasis
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

                public _REDEF_PF0605B_W_DTMOVABE_I1()
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
            private _REDEF_PF0605B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0605B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0605B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0605B_W_DATA_SQL1 : VarBasis
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
                /*"    05 W-RCAP                         PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0605B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_RCAP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-NORMAL                             VALUE 1. */
							new SelectorItemBasis("RCAP_NORMAL", "1"),
							/*" 88 RCAP-ERRO                               VALUE 2. */
							new SelectorItemBasis("RCAP_ERRO", "2")
                }
            };

            /*"    05  W-NUM-PROPOSTA-NOVA           PIC  9(014).*/
            public IntBasis W_NUM_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA-NOVA.*/
            private _REDEF_PF0605B_CANAL _canal { get; set; }
            public _REDEF_PF0605B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0605B_CANAL(); _.Move(W_NUM_PROPOSTA_NOVA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA_NOVA, _canal, W_NUM_PROPOSTA_NOVA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA_NOVA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA_NOVA); }
            }  //Redefines
            public class _REDEF_PF0605B_CANAL : VarBasis
            {
                /*"        07  W-NUM-PROPOSTA-ATUAL      PIC  9(013).*/
                public IntBasis W_NUM_PROPOSTA_ATUAL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"        07  W-DV-PROPOSTA-NOVA        PIC  9(001).*/
                public IntBasis W_DV_PROPOSTA_NOVA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-NUM-PROPOSTA                PIC  9(014).*/

                public _REDEF_PF0605B_CANAL()
                {
                    W_NUM_PROPOSTA_ATUAL.ValueChanged += OnValueChanged;
                    W_DV_PROPOSTA_NOVA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0605B_CANAL_0 _canal_0 { get; set; }
            public _REDEF_PF0605B_CANAL_0 CANAL_0
            {
                get { _canal_0 = new _REDEF_PF0605B_CANAL_0(); _.Move(W_NUM_PROPOSTA, _canal_0); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal_0, W_NUM_PROPOSTA); _canal_0.ValueChanged += () => { _.Move(_canal_0, W_NUM_PROPOSTA); }; return _canal_0; }
                set { VarBasis.RedefinePassValue(value, _canal_0, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0605B_CANAL_0 : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC  9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-GRAFICA                VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_GRAFICA", "0"),
							/*" 88 CANAL-VENDA-CEF                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-VENDA-SASSE                  VALUE 2. */
							new SelectorItemBasis("CANAL_VENDA_SASSE", "2"),
							/*" 88 CANAL-VENDA-CORRETOR               VALUE 3. */
							new SelectorItemBasis("CANAL_VENDA_CORRETOR", "3"),
							/*" 88 CANAL-VENDA-ATM                    VALUE 4. */
							new SelectorItemBasis("CANAL_VENDA_ATM", "4"),
							/*" 88 CANAL-VENDA-GITEL                  VALUE 5. */
							new SelectorItemBasis("CANAL_VENDA_GITEL", "5"),
							/*" 88 CANAL-VENDA-INTERNET               VALUE 7. */
							new SelectorItemBasis("CANAL_VENDA_INTERNET", "7"),
							/*" 88 CANAL-VENDA-INTRANET               VALUE 8. */
							new SelectorItemBasis("CANAL_VENDA_INTRANET", "8"),
							/*" 88 CANAL-CORRESP-NEGOCIAL             VALUE 9. */
							new SelectorItemBasis("CANAL_CORRESP_NEGOCIAL", "9")
                }
                };

                /*"        07  FILLER                    PIC 9(013).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    05 W-TEM-ERRO-SEG-VDZ             PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0605B_CANAL_0()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_TEM_ERRO_SEG_VDZ { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-ERRO-SEG-VDZ                        VALUE 1. */
							new SelectorItemBasis("TEM_ERRO_SEG_VDZ", "1")
                }
            };

            /*"    05 W-PENDENCIA-PROPOSTA           PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PENDENCIA_PROPOSTA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 AGUARDANDO-PRP-FISICA                   VALUE 1. */
							new SelectorItemBasis("AGUARDANDO_PRP_FISICA", "1")
                }
            };

            /*"    05 W-TEM-ERRO-BILHETE             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_ERRO_BILHETE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-ERRO-SEG-BIL                        VALUE 1. */
							new SelectorItemBasis("TEM_ERRO_SEG_BIL", "1")
                }
            };

            /*"    05 W-TEM-COBERTURA-BILHETE        PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_COBERTURA_BILHETE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TEM-COBERTURA-BILHETE                   VALUE 1. */
							new SelectorItemBasis("TEM_COBERTURA_BILHETE", "1")
                }
            };

            /*"    05 W-TEM-COBERPROPVA              PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TEM_COBERPROPVA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 NAO-TEM-COBERPROPVA                     VALUE 1. */
							new SelectorItemBasis("NAO_TEM_COBERPROPVA", "1")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

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
							/*" 88 BILHETE-REL                             VALUE 4. */
							new SelectorItemBasis("BILHETE_REL", "4")
                }
            };

            /*"    05 W-PRODUTO                      PIC  9(002) VALUE ZEROS.*/

            public SelectorBasis W_PRODUTO { get; set; } = new SelectorBasis("002", "ZEROS")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MULTIPREMIADO                           VALUE 01. */
							new SelectorItemBasis("MULTIPREMIADO", "01"),
							/*" 88 FEDPREV                                 VALUE 02. */
							new SelectorItemBasis("FEDPREV", "02"),
							/*" 88 FEDECAP                                 VALUE 03. */
							new SelectorItemBasis("FEDECAP", "03"),
							/*" 88 EXECUTIVO                               VALUE 04. */
							new SelectorItemBasis("EXECUTIVO", "04"),
							/*" 88 FEDPREV-CRESCER                         VALUE 05. */
							new SelectorItemBasis("FEDPREV_CRESCER", "05"),
							/*" 88 FEDPREV-PGTO-UNICO                      VALUE 06. */
							new SelectorItemBasis("FEDPREV_PGTO_UNICO", "06"),
							/*" 88 SENIOR                                  VALUE 07. */
							new SelectorItemBasis("SENIOR", "07"),
							/*" 88 FEDPREV-ECONOMIARIO                     VALUE 08. */
							new SelectorItemBasis("FEDPREV_ECONOMIARIO", "08"),
							/*" 88 BILHETE-AP                              VALUE 09. */
							new SelectorItemBasis("BILHETE_AP", "09"),
							/*" 88 BILHETE-RD                              VALUE 10. */
							new SelectorItemBasis("BILHETE_RD", "10"),
							/*" 88 VIDA-DA-GENTE                           VALUE 11. */
							new SelectorItemBasis("VIDA_DA_GENTE", "11"),
							/*" 88 MULTIPREMIADO-SUPER                     VALUE 13. */
							new SelectorItemBasis("MULTIPREMIADO_SUPER", "13"),
							/*" 88 VIDAZUL-EMPRESARIAL                     VALUE 15. */
							new SelectorItemBasis("VIDAZUL_EMPRESARIAL", "15"),
							/*" 88 VIDAZUL-EMPRESARIAL-SUPER               VALUE 16. */
							new SelectorItemBasis("VIDAZUL_EMPRESARIAL_SUPER", "16"),
							/*" 88 MICROSSEGURO-AMPARO                     VALUE 29. */
							new SelectorItemBasis("MICROSSEGURO_AMPARO", "29")
                }
            };

            /*"    05 W-TP-MOVIMENTO                 PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_TP_MOVIMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 MOVTO-AVULSO                            VALUE 1. */
							new SelectorItemBasis("MOVTO_AVULSO", "1"),
							/*" 88 MOVTO-ADESAO                            VALUE 2. */
							new SelectorItemBasis("MOVTO_ADESAO", "2")
                }
            };

            /*"01  W-VINDICADORAS.*/
        }
        public PF0605B_W_VINDICADORAS W_VINDICADORAS { get; set; } = new PF0605B_W_VINDICADORAS();
        public class PF0605B_W_VINDICADORAS : VarBasis
        {
            /*"    05 VIND-DT-RCAP                   PIC S9(004) COMP  VALUE +0*/
            public IntBasis VIND_DT_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  WABEND*/
        }
        public PF0605B_WABEND WABEND { get; set; } = new PF0605B_WABEND();
        public class PF0605B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0605B_FILLER_3 FILLER_3 { get; set; } = new PF0605B_FILLER_3();
            public class PF0605B_FILLER_3 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0605B  '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0605B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0605B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0605B_LOCALIZA_ABEND_1();
            public class PF0605B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0605B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0605B_LOCALIZA_ABEND_2();
            public class PF0605B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public PF0605B_WS_HORAS WS_HORAS { get; set; } = new PF0605B_WS_HORAS();
        public class PF0605B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_PF0605B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_PF0605B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_PF0605B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_PF0605B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_PF0605B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_PF0605B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_PF0605B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_PF0605B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_PF0605B_WS_HORA_FIM_R : VarBasis
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

                public _REDEF_PF0605B_WS_HORA_FIM_R()
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
        public PF0605B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new PF0605B_TOTAIS_ROT();
        public class PF0605B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<PF0605B_FILLER_12> FILLER_12 { get; set; } = new ListBasis<PF0605B_FILLER_12>(50);
            public class PF0605B_FILLER_12 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.IDENTREL IDENTREL { get; set; } = new Dclgens.IDENTREL();
        public Dclgens.PROPVA PROPVA { get; set; } = new Dclgens.PROPVA();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.COBPRPVA COBPRPVA { get; set; } = new Dclgens.COBPRPVA();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.ERROSBIL ERROSBIL { get; set; } = new Dclgens.ERROSBIL();
        public Dclgens.CODERRBI CODERRBI { get; set; } = new Dclgens.CODERRBI();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPFID PROPFID { get; set; } = new Dclgens.PROPFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.MOVVGAP MOVVGAP { get; set; } = new Dclgens.MOVVGAP();
        public Dclgens.ERROVDAZ ERROVDAZ { get; set; } = new Dclgens.ERROVDAZ();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public PF0605B_PROPOSTA_FIDELIZ PROPOSTA_FIDELIZ { get; set; } = new PF0605B_PROPOSTA_FIDELIZ();
        public PF0605B_ERROS_PROP_VIDAZUL ERROS_PROP_VIDAZUL { get; set; } = new PF0605B_ERROS_PROP_VIDAZUL();
        public PF0605B_BILHETE_ERROS BILHETE_ERROS { get; set; } = new PF0605B_BILHETE_ERROS();
        public PF0605B_BILHETE_COBERTURA BILHETE_COBERTURA { get; set; } = new PF0605B_BILHETE_COBERTURA();
        public PF0605B_BILHETE_COBER BILHETE_COBER { get; set; } = new PF0605B_BILHETE_COBER();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);

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
            /*" -762- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -763- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -764- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -767- DISPLAY '********************************************' . */
            _.Display($"********************************************");

            /*" -768- DISPLAY '*                 PF0605B                  *' . */
            _.Display($"*                 PF0605B                  *");

            /*" -775- DISPLAY '*           VERSAO 37 - 03/2024 DM484074   *' . */
            _.Display($"*           VERSAO 37 - 03/2024 DM484074   *");

            /*" -777- DISPLAY '********************************************' */
            _.Display($"********************************************");

            /*" -780- INITIALIZE TOTAIS-ROT DCLBILHETE */
            _.Initialize(
                TOTAIS_ROT
                , BILHETE.DCLBILHETE
            );

            /*" -781- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -783- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -785- DISPLAY '*   PF0605B ** INICIO PROCESSAMENTO - HORA.. ' W-TIME-EDIT. */
            _.Display($"*   PF0605B ** INICIO PROCESSAMENTO - HORA.. {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -787- DISPLAY '*' . */
            _.Display($"*");

            /*" -789- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -791- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -793- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -795- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -797- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -799- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -802- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-FIDELIZ EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -804- PERFORM R0800-00-GERAR-TRAILLER. */

            R0800_00_GERAR_TRAILLER_SECTION();

            /*" -806- PERFORM R0850-00-CONTROLAR-ARQ-ENVIADO */

            R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -808- PERFORM R0870-00-GERAR-TOTAIS. */

            R0870_00_GERAR_TOTAIS_SECTION();

            /*" -812- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -813- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -815- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -816- DISPLAY '*' . */
            _.Display($"*");

            /*" -819- DISPLAY '*  PF0605B ** FIM DO PROCESSAMENTO - HORA.. ' W-TIME-EDIT. */
            _.Display($"*  PF0605B ** FIM DO PROCESSAMENTO - HORA.. {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -819- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -827- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -829- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -831- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -837- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -842- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -844- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -846- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -849- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -851- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -837- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -861- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -863- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -863- OPEN OUTPUT MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -873- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -875- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -878- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -881- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -890- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -893- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -894- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -895- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -897- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -898- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -900- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -903- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -905- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -905- MOVE W-NSAS TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(WAREA_AUXILIAR.W_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -890- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
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
            /*" -915- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -916- MOVE 'DECLARE PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("DECLARE PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -918- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -919- MOVE 1 TO COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(1, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);

            /*" -921- MOVE 'S' TO SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ. */
            _.Move("S", PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);

            /*" -977- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -980- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -984- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -985- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -986- DISPLAY '          ERRO OPEN CURSOR PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO OPEN CURSOR PROPOSTA-FIDELIZ");

                /*" -988- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -989- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -989- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -977- EXEC SQL DECLARE PROPOSTA-FIDELIZ CURSOR FOR SELECT A.NUM_PROPOSTA_SIVPF, A.NUM_IDENTIFICACAO, A.COD_EMPRESA_SIVPF, A.COD_PESSOA, A.NUM_SICOB, A.DATA_PROPOSTA, A.COD_PRODUTO_SIVPF, A.AGECOBR, A.DIA_DEBITO, A.OPCAOPAG, A.AGECTADEB, A.OPRCTADEB, A.NUMCTADEB, A.DIGCTADEB, A.PERC_DESCONTO, A.NRMATRVEN, A.AGECTAVEN, A.OPRCTAVEN, A.NUMCTAVEN, A.DIGCTAVEN, A.CGC_CONVENENTE, A.NOME_CONVENENTE, A.NRMATRCON, A.DTQITBCO, A.VAL_PAGO, A.AGEPGTO, A.VAL_TARIFA, A.VAL_IOF, A.DATA_CREDITO, A.VAL_COMISSAO, A.SIT_PROPOSTA, A.COD_USUARIO, A.CANAL_PROPOSTA, A.NSAS_SIVPF, A.ORIGEM_PROPOSTA, A.NSL, A.NSAC_SIVPF, A.SITUACAO_ENVIO, DATE(A.TIMESTAMP) + 10 DAYS, A.COD_PLANO, B.COD_RELAC FROM SEGUROS.PROPOSTA_FIDELIZ A, SEGUROS.IDENTIFICA_RELAC B WHERE A.COD_EMPRESA_SIVPF = :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF AND A.SITUACAO_ENVIO = :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO AND A.COD_PRODUTO_SIVPF NOT IN (48, 7708, 9341, 9350, 9348) AND A.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND B.COD_RELAC IN (1, 4, 8) AND A.ORIGEM_PROPOSTA <> 1001 WITH UR END-EXEC. */
            PROPOSTA_FIDELIZ = new PF0605B_PROPOSTA_FIDELIZ(true);
            string GetQuery_PROPOSTA_FIDELIZ()
            {
                var query = @$"SELECT A.NUM_PROPOSTA_SIVPF
							, 
							A.NUM_IDENTIFICACAO
							, 
							A.COD_EMPRESA_SIVPF
							, 
							A.COD_PESSOA
							, 
							A.NUM_SICOB
							, 
							A.DATA_PROPOSTA
							, 
							A.COD_PRODUTO_SIVPF
							, 
							A.AGECOBR
							, 
							A.DIA_DEBITO
							, 
							A.OPCAOPAG
							, 
							A.AGECTADEB
							, 
							A.OPRCTADEB
							, 
							A.NUMCTADEB
							, 
							A.DIGCTADEB
							, 
							A.PERC_DESCONTO
							, 
							A.NRMATRVEN
							, 
							A.AGECTAVEN
							, 
							A.OPRCTAVEN
							, 
							A.NUMCTAVEN
							, 
							A.DIGCTAVEN
							, 
							A.CGC_CONVENENTE
							, 
							A.NOME_CONVENENTE
							, 
							A.NRMATRCON
							, 
							A.DTQITBCO
							, 
							A.VAL_PAGO
							, 
							A.AGEPGTO
							, 
							A.VAL_TARIFA
							, 
							A.VAL_IOF
							, 
							A.DATA_CREDITO
							, 
							A.VAL_COMISSAO
							, 
							A.SIT_PROPOSTA
							, 
							A.COD_USUARIO
							, 
							A.CANAL_PROPOSTA
							, 
							A.NSAS_SIVPF
							, 
							A.ORIGEM_PROPOSTA
							, 
							A.NSL
							, 
							A.NSAC_SIVPF
							, 
							A.SITUACAO_ENVIO
							, 
							DATE(A.TIMESTAMP) + 10 DAYS
							, 
							A.COD_PLANO
							, 
							B.COD_RELAC 
							FROM SEGUROS.PROPOSTA_FIDELIZ A
							, 
							SEGUROS.IDENTIFICA_RELAC B 
							WHERE A.COD_EMPRESA_SIVPF = 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF}' 
							AND A.SITUACAO_ENVIO = 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO}' 
							AND A.COD_PRODUTO_SIVPF NOT IN 
							(48
							, 7708
							, 9341
							, 9350
							, 9348) 
							AND A.NUM_IDENTIFICACAO = 
							B.NUM_IDENTIFICACAO 
							AND B.COD_RELAC IN (1
							, 4
							, 8) 
							AND A.ORIGEM_PROPOSTA <> 1001";

                return query;
            }
            PROPOSTA_FIDELIZ.GetQueryEvent += GetQuery_PROPOSTA_FIDELIZ;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -980- EXEC SQL OPEN PROPOSTA-FIDELIZ END-EXEC. */

            PROPOSTA_FIDELIZ.Open();

        }

        [StopWatch]
        /*" R0182-00-SEL-ERRO-SEGURADO-DB-DECLARE-1 */
        public void R0182_00_SEL_ERRO_SEGURADO_DB_DECLARE_1()
        {
            /*" -1762- EXEC SQL DECLARE ERROS-PROP-VIDAZUL CURSOR FOR SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :ERRPROVI-NUM-CERTIFICADO AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' ORDER BY A.COD_MSG_CRITICA WITH UR END-EXEC. */
            ERROS_PROP_VIDAZUL = new PF0605B_ERROS_PROP_VIDAZUL(true);
            string GetQuery_ERROS_PROP_VIDAZUL()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA <> '3' 
							ORDER BY A.COD_MSG_CRITICA";

                return query;
            }
            ERROS_PROP_VIDAZUL.GetQueryEvent += GetQuery_ERROS_PROP_VIDAZUL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -996- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -997- MOVE 'FETCH PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("FETCH PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -999- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1042- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -1045- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1046- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1047- MOVE 'FIM' TO W-FIM-MOVTO-FIDELIZ */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                    /*" -1047- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -1049- ELSE */
                }
                else
                {


                    /*" -1050- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -1051- DISPLAY '          ERRO FETCH CURSOR PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO FETCH CURSOR PROPOSTA-FIDELIZ");

                    /*" -1053- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1054- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1055- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1058- ELSE */
                }

            }
            else
            {


                /*" -1063- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ NOT EQUAL 01 AND 04 AND 07 AND 09 AND 10 AND 11 AND 13 AND 29 AND 46 AND 77 AND 37 AND 56 */

                if (!PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.In("01", "04", "07", "09", "10", "11", "13", "29", "46", "77", "37", "56"))
                {

                    /*" -1064- ADD 1 TO W-DESP-PROD */
                    WAREA_AUXILIAR.W_DESP_PROD.Value = WAREA_AUXILIAR.W_DESP_PROD + 1;

                    /*" -1065- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1067- END-IF */
                }


                /*" -1068- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'REJ' */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == "REJ")
                {

                    /*" -1073- IF COD-USUARIO OF DCLPROPOSTA-FIDELIZ EQUAL 'PF0601B' OR 'PF0602B' OR 'VA0601B' OR 'VB0601B' OR 'VA0116B' OR 'VA0118B' NEXT SENTENCE */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO.In("PF0601B", "PF0602B", "VA0601B", "VB0601B", "VA0116B", "VA0118B"))
                    {

                        /*" -1074- ELSE */
                    }
                    else
                    {


                        /*" -1075- ADD 1 TO W-DESP-USUA */
                        WAREA_AUXILIAR.W_DESP_USUA.Value = WAREA_AUXILIAR.W_DESP_USUA + 1;

                        /*" -1076- GO TO R0070-00-LER-MOVTO */
                        new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1077- END-IF */
                    }


                    /*" -1080- END-IF */
                }


                /*" -1082- IF NUM-SICOB OF DCLPROPOSTA-FIDELIZ = 0 AND IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 4 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB == 0 && IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC == 4)
                {

                    /*" -1083- ADD 1 TO W-DESP-SICOB */
                    WAREA_AUXILIAR.W_DESP_SICOB.Value = WAREA_AUXILIAR.W_DESP_SICOB + 1;

                    /*" -1084- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1087- END-IF */
                }


                /*" -1090- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -1091- IF W-CONTROLE > 9999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 9999)
                {

                    /*" -1092- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -1093- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -1094- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -1096- DISPLAY '** PF0605B ** TOTAL LIDOS... ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0605B ** TOTAL LIDOS... {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -1101- END-IF */
                }


                /*" -1109- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
                WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -1042- EXEC SQL FETCH PROPOSTA-FIDELIZ INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, :DCLPROPOSTA-FIDELIZ.NUM-IDENTIFICACAO, :DCLPROPOSTA-FIDELIZ.COD-EMPRESA-SIVPF, :DCLPROPOSTA-FIDELIZ.COD-PESSOA, :DCLPROPOSTA-FIDELIZ.NUM-SICOB, :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, :DCLPROPOSTA-FIDELIZ.AGECOBR, :DCLPROPOSTA-FIDELIZ.DIA-DEBITO, :DCLPROPOSTA-FIDELIZ.OPCAOPAG, :DCLPROPOSTA-FIDELIZ.AGECTADEB, :DCLPROPOSTA-FIDELIZ.OPRCTADEB, :DCLPROPOSTA-FIDELIZ.NUMCTADEB, :DCLPROPOSTA-FIDELIZ.DIGCTADEB, :DCLPROPOSTA-FIDELIZ.PERC-DESCONTO, :DCLPROPOSTA-FIDELIZ.NRMATRVEN, :DCLPROPOSTA-FIDELIZ.AGECTAVEN, :DCLPROPOSTA-FIDELIZ.OPRCTAVEN, :DCLPROPOSTA-FIDELIZ.NUMCTAVEN, :DCLPROPOSTA-FIDELIZ.DIGCTAVEN, :DCLPROPOSTA-FIDELIZ.CGC-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NOME-CONVENENTE, :DCLPROPOSTA-FIDELIZ.NRMATRCON, :DCLPROPOSTA-FIDELIZ.DTQITBCO, :DCLPROPOSTA-FIDELIZ.VAL-PAGO, :DCLPROPOSTA-FIDELIZ.AGEPGTO, :DCLPROPOSTA-FIDELIZ.VAL-TARIFA, :DCLPROPOSTA-FIDELIZ.VAL-IOF, :DCLPROPOSTA-FIDELIZ.DATA-CREDITO, :DCLPROPOSTA-FIDELIZ.VAL-COMISSAO, :DCLPROPOSTA-FIDELIZ.SIT-PROPOSTA, :DCLPROPOSTA-FIDELIZ.COD-USUARIO, :DCLPROPOSTA-FIDELIZ.CANAL-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSAS-SIVPF, :DCLPROPOSTA-FIDELIZ.ORIGEM-PROPOSTA, :DCLPROPOSTA-FIDELIZ.NSL, :DCLPROPOSTA-FIDELIZ.NSAC-SIVPF, :DCLPROPOSTA-FIDELIZ.SITUACAO-ENVIO, :DATA-LIB-STA-PEN, :DCLPROPOSTA-FIDELIZ.COD-PLANO, :DCLIDENTIFICA-RELAC.IDENTREL-COD-RELAC END-EXEC. */

            if (PROPOSTA_FIDELIZ.Fetch())
            {
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_EMPRESA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_PESSOA, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PESSOA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUM_SICOB, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DATA_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGECOBR, PROPFID.DCLPROPOSTA_FIDELIZ.AGECOBR);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DIA_DEBITO, PROPFID.DCLPROPOSTA_FIDELIZ.DIA_DEBITO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_OPCAOPAG, PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGECTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_OPRCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUMCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DIGCTADEB, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTADEB);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_PERC_DESCONTO, PROPFID.DCLPROPOSTA_FIDELIZ.PERC_DESCONTO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NRMATRVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGECTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.AGECTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_OPRCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.OPRCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NUMCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.NUMCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DIGCTAVEN, PROPFID.DCLPROPOSTA_FIDELIZ.DIGCTAVEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_CGC_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.CGC_CONVENENTE);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NOME_CONVENENTE, PROPFID.DCLPROPOSTA_FIDELIZ.NOME_CONVENENTE);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NRMATRCON, PROPFID.DCLPROPOSTA_FIDELIZ.NRMATRCON);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DTQITBCO, PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_PAGO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_PAGO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_AGEPGTO, PROPFID.DCLPROPOSTA_FIDELIZ.AGEPGTO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_TARIFA, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_TARIFA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_DATA_CREDITO, PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_VAL_COMISSAO, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_COMISSAO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_USUARIO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_USUARIO);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSAS_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAS_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA, PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSL, PROPFID.DCLPROPOSTA_FIDELIZ.NSL);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_NSAC_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NSAC_SIVPF);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO, PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO);
                _.Move(PROPOSTA_FIDELIZ.DATA_LIB_STA_PEN, DATA_LIB_STA_PEN);
                _.Move(PROPOSTA_FIDELIZ.DCLPROPOSTA_FIDELIZ_COD_PLANO, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);
                _.Move(PROPOSTA_FIDELIZ.DCLIDENTIFICA_RELAC_IDENTREL_COD_RELAC, IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -1047- EXEC SQL CLOSE PROPOSTA-FIDELIZ END-EXEC */

            PROPOSTA_FIDELIZ.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -1123- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1124- MOVE 'WRITE REG-HEADER-STA' TO COMANDO. */
            _.Move("WRITE REG-HEADER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1126- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1128- MOVE SPACES TO REG-HEADER-STA. */
            _.Move("", LBFCT011.REG_HEADER_STA);

            /*" -1131- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -1134- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -1135- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1136- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1138- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1141- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -1144- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -1147- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -1150- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO RH-NSAS OF REG-HEADER-STA */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_HEADER_STA.RH_NSAS);

            /*" -1150- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1160- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1161- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1163- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1166- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-NUM-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, WAREA_AUXILIAR.W_NUM_PROPOSTA);

            /*" -1169- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-PRODUTO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, WAREA_AUXILIAR.W_PRODUTO);

            /*" -1170- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 4 */

            if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC == 4)
            {

                /*" -1172- PERFORM R0220-00-LER-BILHETE */

                R0220_00_LER_BILHETE_SECTION();

                /*" -1174- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 'EMT' OR 'MAN' */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA.In("EMT", "MAN"))
                {

                    /*" -1175- IF BILHETE-NUM-APOLICE OF DCLBILHETE EQUAL ZEROS */

                    if (BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE == 00)
                    {

                        /*" -1178- DISPLAY 'PF0605B - BILHETE IGNORADO, APOLICE ZERADA ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                        _.Display($"PF0605B - BILHETE IGNORADO, APOLICE ZERADA {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                        /*" -1179- GO TO R0150-LER */

                        R0150_LER(); //GOTO
                        return;

                        /*" -1180- ELSE */
                    }
                    else
                    {


                        /*" -1181- PERFORM R0230-00-LER-ENDOSSO */

                        R0230_00_LER_ENDOSSO_SECTION();

                        /*" -1182- IF SQLCODE EQUAL ZEROS */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1184- MOVE ENDOSSOS-DATA-EMISSAO OF DCLENDOSSOS TO PROPFIDH-DATA-SITUACAO */
                            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

                            /*" -1185- ELSE */
                        }
                        else
                        {


                            /*" -1186- DISPLAY 'PF0605B - PROPOSTA IGNORADA' */
                            _.Display($"PF0605B - PROPOSTA IGNORADA");

                            /*" -1189- DISPLAY '          PROBLEMAS NO ACESSO A ENDOSSO  ' BILHETE-NUM-BILHETE OF DCLBILHETE '   ' SQLCODE */

                            $"          PROBLEMAS NO ACESSO A ENDOSSO  {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}   {DB.SQLCODE}"
                            .Display();

                            /*" -1197- GO TO R0150-LER. */

                            R0150_LER(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -1199- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC EQUAL 1 OR 8 */

            if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.In("1", "8"))
            {

                /*" -1201- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'EMT' OR 'MAN' */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA.In("EMT", "MAN"))
                {

                    /*" -1203- PERFORM R0284-00-ACESSAR-SEGURAVG */

                    R0284_00_ACESSAR_SEGURAVG_SECTION();

                    /*" -1208- IF SQLCODE NOT EQUAL 00 */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1209- ADD 1 TO W-DESP-SEGU */
                        WAREA_AUXILIAR.W_DESP_SEGU.Value = WAREA_AUXILIAR.W_DESP_SEGU + 1;

                        /*" -1210- GO TO R0150-LER */

                        R0150_LER(); //GOTO
                        return;

                        /*" -1211- END-IF */
                    }


                    /*" -1212- END-IF */
                }


                /*" -1227- END-IF */
            }


            /*" -1229- IF BILHETE-NUM-APOL-ANTERIOR OF DCLBILHETE EQUAL ZEROS */

            if (BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR == 00)
            {

                /*" -1230- CONTINUE */

                /*" -1231- ELSE */
            }
            else
            {


                /*" -1233- MOVE BILHETE-NUM-APOL-ANTERIOR OF DCLBILHETE TO NUM-APOL-ANT */
                _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR, NUM_APOL_ANT);

                /*" -1235- PERFORM R0598-00-SELECT-QUANT-BIL-RENO THRU R0598-99-SAIDA */

                R0598_00_SELECT_QUANT_BIL_RENO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0598_99_SAIDA*/


                /*" -1236- PERFORM R0599-00-SELECT-PROPOFID */

                R0599_00_SELECT_PROPOFID_SECTION();

                /*" -1238- END-IF */
            }


            /*" -1240- PERFORM R0180-00-GERA-H-PROP-FIDEL */

            R0180_00_GERA_H_PROP_FIDEL_SECTION();

            /*" -1241- IF AGUARDANDO-PRP-FISICA */

            if (WAREA_AUXILIAR.W_PENDENCIA_PROPOSTA["AGUARDANDO_PRP_FISICA"])
            {

                /*" -1242- ADD 1 TO W-DESP-PEND */
                WAREA_AUXILIAR.W_DESP_PEND.Value = WAREA_AUXILIAR.W_DESP_PEND + 1;

                /*" -1244- GO TO R0150-LER. */

                R0150_LER(); //GOTO
                return;
            }


            /*" -1245- IF CANAL-VENDA-ATM */

            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_ATM"])
            {

                /*" -1247- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 9 OR 10 OR 29 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.In("9", "10", "29"))
                {

                    /*" -1248- IF PROPFIDH-SIT-PROPOSTA EQUAL 'EMT' */

                    if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                    {

                        /*" -1249- IF BILHETE-NUM-APOL-ANTERIOR EQUAL ZEROS */

                        if (BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR == 00)
                        {

                            /*" -1250- MOVE ZEROS TO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(0, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                            /*" -1251- ELSE */
                        }
                        else
                        {


                            /*" -1252- MOVE 731 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(731, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                            /*" -1253- END-IF */
                        }


                        /*" -1254- END-IF */
                    }


                    /*" -1255- END-IF */
                }


                /*" -1257- END-IF. */
            }


            /*" -1258- IF WS-DESPREZA-STATUS EQUAL 'SIM' */

            if (WAREA_AUXILIAR.WS_DESPREZA_STATUS == "SIM")
            {

                /*" -1263- PERFORM R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1 */

                R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1();

                /*" -1266- IF SQLCODE NOT EQUAL 00 */

                if (DB.SQLCODE != 00)
                {

                    /*" -1267- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -1268- DISPLAY '          ERRO UPDATE1 PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO UPDATE1 PROPOSTA-FIDELIZ");

                    /*" -1270- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                    _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                    /*" -1272- DISPLAY '          SQLCODE....................... ' SQLCODE */
                    _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                    /*" -1273- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1274- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1275- ELSE */
                }
                else
                {


                    /*" -1276- GO TO R0150-LER */

                    R0150_LER(); //GOTO
                    return;

                    /*" -1277- END-IF */
                }


                /*" -1279- END-IF */
            }


            /*" -1281- PERFORM R0190-00-GERAR-REGISTRO-TP1. */

            R0190_00_GERAR_REGISTRO_TP1_SECTION();

            /*" -1282- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 4 */

            if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC == 4)
            {

                /*" -1283- IF PROPFIDH-SIT-PROPOSTA EQUAL 'EMT' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                {

                    /*" -1284- PERFORM R0200-00-PROCESSAR-BILHETE */

                    R0200_00_PROCESSAR_BILHETE_SECTION();

                    /*" -1286- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1287- ELSE */
                }

            }
            else
            {


                /*" -1290- IF PROPFIDH-SIT-PROPOSTA NOT EQUAL 'POB' AND PROPFIDH-SIT-PROPOSTA NOT EQUAL 'REJ' AND PROPFIDH-SIT-PROPOSTA NOT EQUAL 'PEN' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA != "POB" && PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA != "REJ" && PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA != "PEN")
                {

                    /*" -1292- PERFORM R0500-00-PROCESSAR-VIDA. */

                    R0500_00_PROCESSAR_VIDA_SECTION();
                }

            }


            /*" -1294- PERFORM R0600-00-GERAR-REGISTRO-TP4. */

            R0600_00_GERAR_REGISTRO_TP4_SECTION();

            /*" -1297- MOVE R2-VAL-IOF OF REG-APOL-SASSE TO VAL-IOF OF DCLPROPOSTA-FIDELIZ. */
            _.Move(LBFCT016.REG_APOL_SASSE.R2_VAL_IOF, PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF);

            /*" -1298- IF CANAL-VENDA-GITEL */

            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -1299- IF OPCAOPAG OF DCLPROPOSTA-FIDELIZ = 1 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG == 1)
                {

                    /*" -1300- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 1 OR 8 */

                    if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC.In("1", "8"))
                    {

                        /*" -1301- IF PROPFIDH-SIT-MOTIVO-SIVPF = 228 */

                        if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF == 228)
                        {

                            /*" -1303- PERFORM 0610-GRAVA-RELATORIO. */

                            M_0610_GRAVA_RELATORIO_SECTION();
                        }

                    }

                }

            }


            /*" -1314- PERFORM R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2 */

            R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2();

            /*" -1317- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1318- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -1319- DISPLAY '          ERRO UPDATE PROPOSTA-FIDELIZ' */
                _.Display($"          ERRO UPDATE PROPOSTA-FIDELIZ");

                /*" -1321- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1323- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -1324- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1324- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0150_LER */

            R0150_LER();

        }

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-DB-UPDATE-1 */
        public void R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1()
        {
            /*" -1263- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC */

            var r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1 = new R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1()
            {
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1.Execute(r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0150-LER */
        private void R0150_LER(bool isPerform = false)
        {
            /*" -1328- PERFORM R0070-00-LER-MOVTO. */

            R0070_00_LER_MOVTO_SECTION();

        }

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-DB-UPDATE-2 */
        public void R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2()
        {
            /*" -1314- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SITUACAO_ENVIO = 'R' , NSAS_SIVPF = :PROPFIDH-NSAS-SIVPF , NSL = :PROPFIDH-NSL , VAL_IOF = :DCLPROPOSTA-FIDELIZ.VAL-IOF WHERE NUM_PROPOSTA_SIVPF = :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF END-EXEC. */

            var r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1 = new R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1()
            {
                VAL_IOF = PROPFID.DCLPROPOSTA_FIDELIZ.VAL_IOF.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
            };

            R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1.Execute(r0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-SECTION */
        private void R0180_00_GERA_H_PROP_FIDEL_SECTION()
        {
            /*" -1338- MOVE 'R0180-GERA-H-PROP-FIDEL' TO PARAGRAFO. */
            _.Move("R0180-GERA-H-PROP-FIDEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1339- MOVE 'INSERT HIST PROP FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST PROP FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1341- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1344- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-NUM-IDENTIFICACAO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -1347- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO PROPFIDH-NSAS-SIVPF. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -1348- IF SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 'MAN' */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA == "MAN")
            {

                /*" -1350- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA */
                _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                /*" -1351- ELSE */
            }
            else
            {


                /*" -1353- MOVE SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-SIT-PROPOSTA */
                _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.SIT_PROPOSTA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

                /*" -1355- END-IF */
            }


            /*" -1356- IF PROPFIDH-SIT-PROPOSTA = 'EMT' */

            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
            {

                /*" -1357- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                /*" -1358- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 4 */

                if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC == 4)
                {

                    /*" -1359- IF BILHETE-NUM-APOL-ANTERIOR EQUAL ZEROS */

                    if (BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR == 00)
                    {

                        /*" -1361- MOVE 000 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1362- IF CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 1 */

                        if (PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA == 1)
                        {

                            /*" -1365- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 12 OR 18 OR 19 OR 34 */

                            if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("12", "18", "19", "34"))
                            {

                                /*" -1366- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                /*" -1367- END-IF */
                            }


                            /*" -1369- END-IF */
                        }


                        /*" -1371- IF CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 2 NEXT SENTENCE */

                        if (PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA == 2)
                        {

                            /*" -1372- ELSE */
                        }
                        else
                        {


                            /*" -1374- IF CANAL-VENDA-GRAFICA NEXT SENTENCE */

                            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_GRAFICA"])
                            {

                                /*" -1375- ELSE */
                            }
                            else
                            {


                                /*" -1376- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 6 */

                                if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA == 6)
                                {

                                    /*" -1377- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                    _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                    /*" -1379- ELSE NEXT SENTENCE */
                                }
                                else
                                {


                                    /*" -1380- END-IF */
                                }


                                /*" -1381- END-IF */
                            }


                            /*" -1382- END-IF */
                        }


                        /*" -1384- ELSE */
                    }
                    else
                    {


                        /*" -1388- MOVE 731 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(731, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1389- END-IF */
                    }


                    /*" -1392- ELSE */
                }
                else
                {


                    /*" -1394- MOVE 000 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                    _.Move(000, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                    /*" -1396- PERFORM R0282-00-OBTER-DT-SIT-VDZ */

                    R0282_00_OBTER_DT_SIT_VDZ_SECTION();

                    /*" -1398- IF CANAL-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 2 NEXT SENTENCE */

                    if (PROPFID.DCLPROPOSTA_FIDELIZ.CANAL_PROPOSTA == 2)
                    {

                        /*" -1399- ELSE */
                    }
                    else
                    {


                        /*" -1401- IF CANAL-VENDA-GRAFICA NEXT SENTENCE */

                        if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_GRAFICA"])
                        {

                            /*" -1402- ELSE */
                        }
                        else
                        {


                            /*" -1403- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 6 */

                            if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA == 6)
                            {

                                /*" -1404- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                /*" -1406- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -1407- END-IF */
                            }


                            /*" -1408- END-IF */
                        }


                        /*" -1409- END-IF */
                    }


                    /*" -1410- END-IF */
                }


                /*" -1411- ELSE */
            }
            else
            {


                /*" -1413- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO PROPFIDH-DATA-SITUACAO */
                _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

                /*" -1414- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 4 */

                if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC == 4)
                {

                    /*" -1416- IF BILHETE-SITUACAO OF DCLBILHETE EQUAL '2' OR '3' AND PROPFIDH-SIT-PROPOSTA NOT EQUAL 'REJ' */

                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO.In("2", "3") && PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA != "REJ")
                    {

                        /*" -1417- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                        _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                        /*" -1418- MOVE 001 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(001, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1419- ELSE */
                    }
                    else
                    {


                        /*" -1420- PERFORM R0186-00-MOTIVO-ERRO-BI */

                        R0186_00_MOTIVO_ERRO_BI_SECTION();

                        /*" -1422- IF TEM-ERRO-SEG-BIL AND PROPFIDH-SIT-PROPOSTA NOT EQUAL 'REJ' */

                        if (WAREA_AUXILIAR.W_TEM_ERRO_BILHETE["TEM_ERRO_SEG_BIL"] && PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA != "REJ")
                        {

                            /*" -1423- PERFORM R0187-DE-PARA-ERRO-BILHETE */

                            R0187_DE_PARA_ERRO_BILHETE_SECTION();

                            /*" -1425- MOVE CODERRBI-COD-ERRO-SIVPF TO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                            /*" -1426- IF RCAP-NORMAL */

                            if (WAREA_AUXILIAR.W_RCAP["RCAP_NORMAL"])
                            {

                                /*" -1427- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                /*" -1428- ELSE */
                            }
                            else
                            {


                                /*" -1429- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                /*" -1430- END-IF */
                            }


                            /*" -1435- ELSE */
                        }
                        else
                        {


                            /*" -1436- IF PROPFIDH-SIT-PROPOSTA EQUAL 'PEN' */

                            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "PEN")
                            {

                                /*" -1437- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                /*" -1438- MOVE 209 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                _.Move(209, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                /*" -1439- ELSE */
                            }
                            else
                            {


                                /*" -1440- IF PROPFIDH-SIT-PROPOSTA EQUAL 'POB' */

                                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "POB")
                                {

                                    /*" -1441- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                    _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                    /*" -1442- MOVE 01 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                    _.Move(01, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                    /*" -1443- ELSE */
                                }
                                else
                                {


                                    /*" -1444- IF PROPFIDH-SIT-PROPOSTA EQUAL 'REJ' */

                                    if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "REJ")
                                    {

                                        /*" -1447- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                        _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                        /*" -1449- MOVE 209 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                        _.Move(209, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                        /*" -1450- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1451- DISPLAY 'PF0605B - FIM ANORMAL' */
                                        _.Display($"PF0605B - FIM ANORMAL");

                                        /*" -1453- DISPLAY '       INCONSISTENCIA SITUACAO BILHETE' */
                                        _.Display($"       INCONSISTENCIA SITUACAO BILHETE");

                                        /*" -1457- DISPLAY '      NUMERO BILHETE................  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                                        _.Display($"      NUMERO BILHETE................  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                                        /*" -1458- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                                        /*" -1459- PERFORM R9999-00-FINALIZAR */

                                        R9999_00_FINALIZAR_SECTION();

                                        /*" -1460- END-IF */
                                    }


                                    /*" -1461- END-IF */
                                }


                                /*" -1462- END-IF */
                            }


                            /*" -1463- END-IF */
                        }


                        /*" -1464- END-IF */
                    }


                    /*" -1465- ELSE */
                }
                else
                {


                    /*" -1467- PERFORM R0181-00-MOTIVO-ERRO-VG */

                    R0181_00_MOTIVO_ERRO_VG_SECTION();

                    /*" -1469- IF TEM-ERRO-SEG-VDZ AND PROPFIDH-SIT-PROPOSTA NOT EQUAL 'REJ' */

                    if (WAREA_AUXILIAR.W_TEM_ERRO_SEG_VDZ["TEM_ERRO_SEG_VDZ"] && PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA != "REJ")
                    {

                        /*" -1470- PERFORM R0185-DE-PARA-COD-ERRO-VG */

                        R0185_DE_PARA_COD_ERRO_VG_SECTION();

                        /*" -1472- MOVE ERROVDAZ-COD-ERRO-SIVPF TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1473- IF RCAP-NORMAL */

                        if (WAREA_AUXILIAR.W_RCAP["RCAP_NORMAL"])
                        {

                            /*" -1474- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                            /*" -1475- ELSE */
                        }
                        else
                        {


                            /*" -1476- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                            _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                            /*" -1477- END-IF */
                        }


                        /*" -1482- ELSE */
                    }
                    else
                    {


                        /*" -1483- IF PROPFIDH-SIT-PROPOSTA EQUAL 'PEN' */

                        if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "PEN")
                        {

                            /*" -1484- MOVE 'PAG' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                            _.Move("PAG", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                            /*" -1485- MOVE 209 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                            _.Move(209, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                            /*" -1486- ELSE */
                        }
                        else
                        {


                            /*" -1487- IF PROPFIDH-SIT-PROPOSTA EQUAL 'POB' */

                            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "POB")
                            {

                                /*" -1488- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                /*" -1489- MOVE 01 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                _.Move(01, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                /*" -1490- ELSE */
                            }
                            else
                            {


                                /*" -1491- IF PROPFIDH-SIT-PROPOSTA EQUAL 'REJ' */

                                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "REJ")
                                {

                                    /*" -1493- MOVE 'SUS' TO PROPFIDH-SIT-COBRANCA-SIVPF */
                                    _.Move("SUS", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

                                    /*" -1494- MOVE 209 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                                    _.Move(209, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                                    /*" -1495- ELSE */
                                }
                                else
                                {


                                    /*" -1496- DISPLAY 'PF0605B - FIM ANORMAL' */
                                    _.Display($"PF0605B - FIM ANORMAL");

                                    /*" -1498- DISPLAY '         INCONSISTENCIA SITUACAO PROP. VG' */
                                    _.Display($"         INCONSISTENCIA SITUACAO PROP. VG");

                                    /*" -1501- DISPLAY '         NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                                    _.Display($"         NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                                    /*" -1502- PERFORM R9988-00-FECHAR-ARQUIVOS */

                                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                                    /*" -1503- PERFORM R9999-00-FINALIZAR */

                                    R9999_00_FINALIZAR_SECTION();

                                    /*" -1504- END-IF */
                                }


                                /*" -1505- END-IF */
                            }


                            /*" -1506- END-IF */
                        }


                        /*" -1507- END-IF */
                    }


                    /*" -1508- END-IF */
                }


                /*" -1510- END-IF */
            }


            /*" -1518- MOVE 0 TO W-PENDENCIA-PROPOSTA */
            _.Move(0, WAREA_AUXILIAR.W_PENDENCIA_PROPOSTA);

            /*" -1519- IF IDENTREL-COD-RELAC OF DCLIDENTIFICA-RELAC = 1 */

            if (IDENTREL.DCLIDENTIFICA_RELAC.IDENTREL_COD_RELAC == 1)
            {

                /*" -1520- IF PROPFIDH-SIT-PROPOSTA = 'PEN' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "PEN")
                {

                    /*" -1522- IF SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS < DATA-LIB-STA-PEN */

                    if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO < DATA_LIB_STA_PEN)
                    {

                        /*" -1523- IF PROPFIDH-SIT-MOTIVO-SIVPF = 728 */

                        if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF == 728)
                        {

                            /*" -1524- MOVE 1 TO W-PENDENCIA-PROPOSTA */
                            _.Move(1, WAREA_AUXILIAR.W_PENDENCIA_PROPOSTA);

                            /*" -1525- GO TO R0180-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/ //GOTO
                            return;

                            /*" -1526- END-IF */
                        }


                        /*" -1527- END-IF */
                    }


                    /*" -1528- END-IF */
                }


                /*" -1530- END-IF */
            }


            /*" -1533- ADD 1 TO PROPFIDH-NSL. */
            PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.Value = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL + 1;

            /*" -1534- IF CANAL-CORRESP-NEGOCIAL */

            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_CORRESP_NEGOCIAL"])
            {

                /*" -1535- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ = 13 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA == 13)
                {

                    /*" -1536- IF PROPFIDH-SIT-PROPOSTA = 'EMT' */

                    if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                    {

                        /*" -1537- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1538- END-IF */
                    }


                    /*" -1539- END-IF */
                }


                /*" -1541- END-IF */
            }


            /*" -1544- INITIALIZE WS-TEM-HIST-FIDELIZ WS-DESPREZA-STATUS. */
            _.Initialize(
                WAREA_AUXILIAR.WS_TEM_HIST_FIDELIZ
                , WAREA_AUXILIAR.WS_DESPREZA_STATUS
            );

            /*" -1545- IF CANAL-VENDA-GITEL */

            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -1546- IF PROPFIDH-SIT-PROPOSTA = 'EMT' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                {

                    /*" -1547- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                    _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                    /*" -1548- END-IF */
                }


                /*" -1551- END-IF */
            }


            /*" -1556- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 12 OR 18 OR 19 OR 34 OR 1009 OR 1010 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("12", "18", "19", "34", "1009", "1010"))
            {

                /*" -1557- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ NOT = 9 AND 10 */

                if (!PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.In("9", "10"))
                {

                    /*" -1558- IF PROPFIDH-SIT-PROPOSTA = 'EMT' */

                    if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                    {

                        /*" -1559- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                        _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                        /*" -1560- END-IF */
                    }


                    /*" -1561- END-IF */
                }


                /*" -1563- END-IF */
            }


            /*" -1564- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 1004 OR 1005 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("1004", "1005"))
            {

                /*" -1565- IF PROPFIDH-SIT-PROPOSTA = 'EMT' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                {

                    /*" -1566- MOVE 228 TO PROPFIDH-SIT-MOTIVO-SIVPF */
                    _.Move(228, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

                    /*" -1567- END-IF */
                }


                /*" -1568- GO TO R0180-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/ //GOTO
                return;

                /*" -1577- END-IF */
            }


            /*" -1578- PERFORM R0195-BUSCA-DADOS-HISPROFI */

            R0195_BUSCA_DADOS_HISPROFI_SECTION();

            /*" -1580- IF WS-TEM-HIST-FIDELIZ EQUAL 'SIM' AND SITUACAO-ENVIO OF DCLPROPOSTA-FIDELIZ EQUAL 'R' */

            if (WAREA_AUXILIAR.WS_TEM_HIST_FIDELIZ == "SIM" && PROPFID.DCLPROPOSTA_FIDELIZ.SITUACAO_ENVIO == "R")
            {

                /*" -1581- MOVE 'SIM' TO WS-DESPREZA-STATUS */
                _.Move("SIM", WAREA_AUXILIAR.WS_DESPREZA_STATUS);

                /*" -1582- ADD 1 TO W-DESP-HIST */
                WAREA_AUXILIAR.W_DESP_HIST.Value = WAREA_AUXILIAR.W_DESP_HIST + 1;

                /*" -1583- GO TO R0180-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/ //GOTO
                return;

                /*" -1586- END-IF */
            }


            /*" -1587- IF CANAL-VENDA-GITEL */

            if (WAREA_AUXILIAR.CANAL_0.W_CANAL_PROPOSTA["CANAL_VENDA_GITEL"])
            {

                /*" -1588- IF OPCAOPAG OF DCLPROPOSTA-FIDELIZ = 1 */

                if (PROPFID.DCLPROPOSTA_FIDELIZ.OPCAOPAG == 1)
                {

                    /*" -1590- IF ( PROPFIDH-SIT-PROPOSTA = 'PEN' OR PROPFIDH-SIT-PROPOSTA = 'POB' ) */

                    if ((PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "PEN" || PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "POB"))
                    {

                        /*" -1594- IF ( PROPFIDH-SIT-MOTIVO-SIVPF = 001 OR PROPFIDH-SIT-MOTIVO-SIVPF = 576 OR 577 OR 578 OR 579 OR 580 OR 600 OR 601 OR 610 OR 896 OR 1864 ) */

                        if ((PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF == 001 || PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.In("576", "577", "578", "579", "580", "600", "601", "610", "896", "1864")))
                        {

                            /*" -1595- MOVE 'SIM' TO WS-DESPREZA-STATUS */
                            _.Move("SIM", WAREA_AUXILIAR.WS_DESPREZA_STATUS);

                            /*" -1596- ADD 1 TO W-DESP-MOTIVO */
                            WAREA_AUXILIAR.W_DESP_MOTIVO.Value = WAREA_AUXILIAR.W_DESP_MOTIVO + 1;

                            /*" -1597- GO TO R0180-SAIDA */
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/ //GOTO
                            return;

                            /*" -1598- END-IF */
                        }


                        /*" -1599- END-IF */
                    }


                    /*" -1600- END-IF */
                }


                /*" -1603- END-IF */
            }


            /*" -1606- MOVE COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -1609- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -1620- PERFORM R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1 */

            R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1();

            /*" -1623- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1624- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -1625- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -1627- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -1629- DISPLAY '          NUMERO IDENTIFICACAO..........  ' NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO}");

                /*" -1631- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -1632- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1632- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0180-00-GERA-H-PROP-FIDEL-DB-INSERT-1 */
        public void R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1()
        {
            /*" -1620- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF, :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF) END-EXEC. */

            var r0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1 = new R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1()
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

            R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1.Execute(r0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/

        [StopWatch]
        /*" R0181-00-MOTIVO-ERRO-VG-SECTION */
        private void R0181_00_MOTIVO_ERRO_VG_SECTION()
        {
            /*" -1642- MOVE 'R0181-00-MOTIVO-ERRO-VG' TO PARAGRAFO. */
            _.Move("R0181-00-MOTIVO-ERRO-VG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1644- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1646- MOVE 'NAO' TO W-FIM-ERROS-VDZ. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_ERROS_VDZ);

            /*" -1648- MOVE 1 TO W-RCAP. */
            _.Move(1, WAREA_AUXILIAR.W_RCAP);

            /*" -1650- MOVE 0 TO W-TEM-ERRO-SEG-VDZ. */
            _.Move(0, WAREA_AUXILIAR.W_TEM_ERRO_SEG_VDZ);

            /*" -1652- PERFORM R0182-00-SEL-ERRO-SEGURADO. */

            R0182_00_SEL_ERRO_SEGURADO_SECTION();

            /*" -1654- PERFORM R0183-00-LER-ERRO-SEGURADO. */

            R0183_00_LER_ERRO_SEGURADO_SECTION();

            /*" -1655- PERFORM R0184-00-PROCESSAR-ERROS UNTIL W-FIM-ERROS-VDZ EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_ERROS_VDZ == "FIM"))
            {

                R0184_00_PROCESSAR_ERROS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0181_SAIDA*/

        [StopWatch]
        /*" M-0610-GRAVA-RELATORIO-SECTION */
        private void M_0610_GRAVA_RELATORIO_SECTION()
        {
            /*" -1667- MOVE '0610-GRAVA-RELATORIO ' TO PARAGRAFO */
            _.Move("0610-GRAVA-RELATORIO ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1669- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1712- PERFORM M_0610_GRAVA_RELATORIO_DB_INSERT_1 */

            M_0610_GRAVA_RELATORIO_DB_INSERT_1();

            /*" -1715- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1716- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -1717- DISPLAY '          ERRO INSERT TAB. RELATORIOS' */
                _.Display($"          ERRO INSERT TAB. RELATORIOS");

                /*" -1719- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -1720- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1723- PERFORM R9999-00-FINALIZAR. 0610-SAIDA. EXIT. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" M-0610-GRAVA-RELATORIO-DB-INSERT-1 */
        public void M_0610_GRAVA_RELATORIO_DB_INSERT_1()
        {
            /*" -1712- EXEC SQL INSERT INTO SEGUROS.RELATORIOS VALUES ( 'PF0605B' , CURRENT DATE, 'PF' , 'PF0648B' , 0, 0, CURRENT DATE, CURRENT DATE, CURRENT DATE, 0, 0, 0, 0, 0, :DCLAPOLICES.APOLICES-RAMO-EMISSOR, :DCLPROPOSTAS-VA.COD-PRODUTO, 0, :DCLAPOLICES.APOLICES-NUM-APOLICE, 0, 0, :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF, 0, 0, 0, :DCLPROPOSTA-FIDELIZ.COD-PRODUTO-SIVPF, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , '0' , '0' , 0, 0, 0, CURRENT TIMESTAMP) END-EXEC. */

            var m_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1 = new M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1()
            {
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
                COD_PRODUTO = PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO.ToString(),
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
                NUM_PROPOSTA_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF.ToString(),
                COD_PRODUTO_SIVPF = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF.ToString(),
            };

            M_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1.Execute(m_0610_GRAVA_RELATORIO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0182-00-SEL-ERRO-SEGURADO-SECTION */
        private void R0182_00_SEL_ERRO_SEGURADO_SECTION()
        {
            /*" -1731- MOVE 'R0182-00-SEL-ERRO-SEGURADO' TO PARAGRAFO. */
            _.Move("R0182-00-SEL-ERRO-SEGURADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1732- MOVE 'DECLARE ERROS-PROP-VIDAZUL' TO COMANDO. */
            _.Move("DECLARE ERROS-PROP-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1734- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1750- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO ERRPROVI-NUM-CERTIFICADO */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO);

            /*" -1762- PERFORM R0182_00_SEL_ERRO_SEGURADO_DB_DECLARE_1 */

            R0182_00_SEL_ERRO_SEGURADO_DB_DECLARE_1();

            /*" -1764- PERFORM R0182_00_SEL_ERRO_SEGURADO_DB_OPEN_1 */

            R0182_00_SEL_ERRO_SEGURADO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0182-00-SEL-ERRO-SEGURADO-DB-OPEN-1 */
        public void R0182_00_SEL_ERRO_SEGURADO_DB_OPEN_1()
        {
            /*" -1764- EXEC SQL OPEN ERROS-PROP-VIDAZUL END-EXEC. */

            ERROS_PROP_VIDAZUL.Open();

        }

        [StopWatch]
        /*" R0188-00-SEL-BILHETE-ERROS-DB-DECLARE-1 */
        public void R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1()
        {
            /*" -1923- EXEC SQL DECLARE BILHETE-ERROS CURSOR FOR SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :ERROSBIL-NUM-BILHETE AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' ORDER BY A.COD_MSG_CRITICA WITH UR END-EXEC. */
            BILHETE_ERROS = new PF0605B_BILHETE_ERROS(true);
            string GetQuery_BILHETE_ERROS()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO
							, 
							A.COD_MSG_CRITICA 
							FROM SEGUROS.VG_CRITICA_PROPOSTA A
							, 
							SEGUROS.VG_DM_MSG_CRITICA B 
							WHERE A.NUM_CERTIFICADO = '{ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_NUM_BILHETE}' 
							AND A.STA_CRITICA IN ( '0'
							, '1'
							, '2'
							, '4'
							, '5'
							, '8' ) 
							AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA 
							AND B.COD_TP_MSG_CRITICA <> '3' 
							ORDER BY A.COD_MSG_CRITICA";

                return query;
            }
            BILHETE_ERROS.GetQueryEvent += GetQuery_BILHETE_ERROS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0182_SAIDA*/

        [StopWatch]
        /*" R0183-00-LER-ERRO-SEGURADO-SECTION */
        private void R0183_00_LER_ERRO_SEGURADO_SECTION()
        {
            /*" -1774- MOVE 'R0183-00-LER-ERRO-SEGURADO' TO PARAGRAFO. */
            _.Move("R0183-00-LER-ERRO-SEGURADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1775- MOVE 'FETCH ERROS-PROP-VIDAZUL' TO COMANDO. */
            _.Move("FETCH ERROS-PROP-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1777- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1781- PERFORM R0183_00_LER_ERRO_SEGURADO_DB_FETCH_1 */

            R0183_00_LER_ERRO_SEGURADO_DB_FETCH_1();

            /*" -1784- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1785- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1786- MOVE 'FIM' TO W-FIM-ERROS-VDZ */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_ERROS_VDZ);

                    /*" -1786- PERFORM R0183_00_LER_ERRO_SEGURADO_DB_CLOSE_1 */

                    R0183_00_LER_ERRO_SEGURADO_DB_CLOSE_1();

                    /*" -1788- ELSE */
                }
                else
                {


                    /*" -1789- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -1790- DISPLAY '          ERRO FETCH CURSOR ERROS-PROP-VIDAZUL' */
                    _.Display($"          ERRO FETCH CURSOR ERROS-PROP-VIDAZUL");

                    /*" -1792- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1793- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1793- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0183-00-LER-ERRO-SEGURADO-DB-FETCH-1 */
        public void R0183_00_LER_ERRO_SEGURADO_DB_FETCH_1()
        {
            /*" -1781- EXEC SQL FETCH ERROS-PROP-VIDAZUL INTO :ERRPROVI-NUM-CERTIFICADO, :ERRPROVI-COD-ERRO END-EXEC. */

            if (ERROS_PROP_VIDAZUL.Fetch())
            {
                _.Move(ERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_NUM_CERTIFICADO);
                _.Move(ERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);
            }

        }

        [StopWatch]
        /*" R0183-00-LER-ERRO-SEGURADO-DB-CLOSE-1 */
        public void R0183_00_LER_ERRO_SEGURADO_DB_CLOSE_1()
        {
            /*" -1786- EXEC SQL CLOSE ERROS-PROP-VIDAZUL END-EXEC */

            ERROS_PROP_VIDAZUL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0183_SAIDA*/

        [StopWatch]
        /*" R0184-00-PROCESSAR-ERROS-SECTION */
        private void R0184_00_PROCESSAR_ERROS_SECTION()
        {
            /*" -1804- MOVE 'R0184-00-PROCESSAR-ERROS' TO PARAGRAFO. */
            _.Move("R0184-00-PROCESSAR-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1805- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1807- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1810- MOVE 1 TO W-TEM-ERRO-SEG-VDZ. */
            _.Move(1, WAREA_AUXILIAR.W_TEM_ERRO_SEG_VDZ);

            /*" -1812- IF ERRPROVI-COD-ERRO EQUAL 11501 OR 1505 OR 1506 OR 1827 OR 1828 */

            if (ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO.In("11501", "1505", "1506", "1827", "1828"))
            {

                /*" -1812- PERFORM R0184_00_PROCESSAR_ERROS_DB_CLOSE_1 */

                R0184_00_PROCESSAR_ERROS_DB_CLOSE_1();

                /*" -1814- MOVE 'FIM' TO W-FIM-ERROS-VDZ */
                _.Move("FIM", WAREA_AUXILIAR.W_FIM_ERROS_VDZ);

                /*" -1815- MOVE 2 TO W-RCAP */
                _.Move(2, WAREA_AUXILIAR.W_RCAP);

                /*" -1816- ELSE */
            }
            else
            {


                /*" -1816- PERFORM R0183-00-LER-ERRO-SEGURADO. */

                R0183_00_LER_ERRO_SEGURADO_SECTION();
            }


        }

        [StopWatch]
        /*" R0184-00-PROCESSAR-ERROS-DB-CLOSE-1 */
        public void R0184_00_PROCESSAR_ERROS_DB_CLOSE_1()
        {
            /*" -1812- EXEC SQL CLOSE ERROS-PROP-VIDAZUL END-EXEC */

            ERROS_PROP_VIDAZUL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0184_SAIDA*/

        [StopWatch]
        /*" R0185-DE-PARA-COD-ERRO-VG-SECTION */
        private void R0185_DE_PARA_COD_ERRO_VG_SECTION()
        {
            /*" -1826- MOVE 'R0185-DE-PARA-COD-ERRO-VG' TO PARAGRAFO. */
            _.Move("R0185-DE-PARA-COD-ERRO-VG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1827- MOVE 'SELECT ERROS-VIDAZUL' TO COMANDO. */
            _.Move("SELECT ERROS-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1829- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1841- MOVE ERRPROVI-COD-ERRO TO ERROVDAZ-COD-ERRO. */
            _.Move(ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO, ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO);

            /*" -1849- PERFORM R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1 */

            R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1();

            /*" -1853- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1854- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -1855- DISPLAY '          ERRO SELECT TAB. VG_DM_MSG_CRITICA' */
                _.Display($"          ERRO SELECT TAB. VG_DM_MSG_CRITICA");

                /*" -1857- DISPLAY '          COD-ERRO................ ' ERROVDAZ-COD-ERRO */
                _.Display($"          COD-ERRO................ {ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO}");

                /*" -1859- DISPLAY '          SQLCODE................. ' SQLCODE */
                _.Display($"          SQLCODE................. {DB.SQLCODE}");

                /*" -1860- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1860- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0185-DE-PARA-COD-ERRO-VG-DB-SELECT-1 */
        public void R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1()
        {
            /*" -1849- EXEC SQL SELECT COD_MSG_CRITICA, COD_ERRO_SIVPF INTO :ERROVDAZ-COD-ERRO, :ERROVDAZ-COD-ERRO-SIVPF FROM SEGUROS.VG_DM_MSG_CRITICA WHERE COD_MSG_CRITICA = :ERROVDAZ-COD-ERRO WITH UR END-EXEC. */

            var r0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1 = new R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1()
            {
                ERROVDAZ_COD_ERRO = ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO.ToString(),
            };

            var executed_1 = R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1.Execute(r0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERROVDAZ_COD_ERRO, ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO);
                _.Move(executed_1.ERROVDAZ_COD_ERRO_SIVPF, ERROVDAZ.DCLERROS_VIDAZUL.ERROVDAZ_COD_ERRO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0185_SAIDA*/

        [StopWatch]
        /*" R0186-00-MOTIVO-ERRO-BI-SECTION */
        private void R0186_00_MOTIVO_ERRO_BI_SECTION()
        {
            /*" -1870- MOVE 'R0186-00-MOTIVO-ERRO-BI' TO PARAGRAFO. */
            _.Move("R0186-00-MOTIVO-ERRO-BI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1872- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1874- MOVE 'NAO' TO W-FIM-BILHETE-ERROS. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_BILHETE_ERROS);

            /*" -1876- MOVE 1 TO W-RCAP. */
            _.Move(1, WAREA_AUXILIAR.W_RCAP);

            /*" -1878- MOVE 0 TO W-TEM-ERRO-BILHETE. */
            _.Move(0, WAREA_AUXILIAR.W_TEM_ERRO_BILHETE);

            /*" -1880- PERFORM R0188-00-SEL-BILHETE-ERROS. */

            R0188_00_SEL_BILHETE_ERROS_SECTION();

            /*" -1882- PERFORM R0189-00-LER-BILHETE-ERROS. */

            R0189_00_LER_BILHETE_ERROS_SECTION();

            /*" -1883- PERFORM R0189-10-TRATAR-ERROS-BILHETE UNTIL W-FIM-BILHETE-ERROS EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_BILHETE_ERROS == "FIM"))
            {

                R0189_10_TRATAR_ERROS_BILHETE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0186_SAIDA*/

        [StopWatch]
        /*" R0188-00-SEL-BILHETE-ERROS-SECTION */
        private void R0188_00_SEL_BILHETE_ERROS_SECTION()
        {
            /*" -1893- MOVE 'R0188-00-SEL-BILHETE-ERROS' TO PARAGRAFO. */
            _.Move("R0188-00-SEL-BILHETE-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1894- MOVE 'DECLARE BILHETE-ERROS' TO COMANDO. */
            _.Move("DECLARE BILHETE-ERROS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1896- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1911- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO ERROSBIL-NUM-BILHETE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_NUM_BILHETE);

            /*" -1923- PERFORM R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1 */

            R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1();

            /*" -1925- PERFORM R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1 */

            R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0188-00-SEL-BILHETE-ERROS-DB-OPEN-1 */
        public void R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1()
        {
            /*" -1925- EXEC SQL OPEN BILHETE-ERROS END-EXEC. */

            BILHETE_ERROS.Open();

        }

        [StopWatch]
        /*" R0240-00-SELECIONA-BIL-COB-DB-DECLARE-1 */
        public void R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1()
        {
            /*" -2330- EXEC SQL DECLARE BILHETE-COBERTURA CURSOR FOR SELECT COD_PRODUTO, RAMO_COBERTURA, MODALI_COBERTURA, COD_OPCAO_PLANO, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IDE_COBERTURA, VAL_COBERTURA_IX, PRM_TOTAL, PCT_IOCC FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :BILCOBER-COD-EMPRESA AND RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA AND MODALI_COBERTURA = :BILCOBER-MODALI-COBERTURA AND COD_OPCAO_PLANO = :BILCOBER-COD-OPCAO-PLANO AND DATA_INIVIGENCIA <= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND DATA_TERVIGENCIA >= :DCLPROPOSTA-FIDELIZ.DATA-PROPOSTA AND IDE_COBERTURA = :BILCOBER-IDE-COBERTURA ORDER BY COD_COBERTURA WITH UR END-EXEC. */
            BILHETE_COBERTURA = new PF0605B_BILHETE_COBERTURA(true);
            string GetQuery_BILHETE_COBERTURA()
            {
                var query = @$"SELECT COD_PRODUTO
							, 
							RAMO_COBERTURA
							, 
							MODALI_COBERTURA
							, 
							COD_OPCAO_PLANO
							, 
							COD_COBERTURA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							IDE_COBERTURA
							, 
							VAL_COBERTURA_IX
							, 
							PRM_TOTAL
							, 
							PCT_IOCC 
							FROM SEGUROS.BILHETE_COBERTURA 
							WHERE COD_EMPRESA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_EMPRESA}' 
							AND RAMO_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA}' 
							AND MODALI_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA}' 
							AND COD_OPCAO_PLANO = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO}' 
							AND DATA_INIVIGENCIA <= 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}' 
							AND DATA_TERVIGENCIA >= 
							'{PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA}' 
							AND IDE_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA}' 
							ORDER BY COD_COBERTURA";

                return query;
            }
            BILHETE_COBERTURA.GetQueryEvent += GetQuery_BILHETE_COBERTURA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0188_SAIDA*/

        [StopWatch]
        /*" R0189-00-LER-BILHETE-ERROS-SECTION */
        private void R0189_00_LER_BILHETE_ERROS_SECTION()
        {
            /*" -1935- MOVE 'R0189-00-LER-BILHETE-ERROS' TO PARAGRAFO. */
            _.Move("R0189-00-LER-BILHETE-ERROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1936- MOVE 'FETCH BILHETE-ERROS' TO COMANDO. */
            _.Move("FETCH BILHETE-ERROS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1938- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1942- PERFORM R0189_00_LER_BILHETE_ERROS_DB_FETCH_1 */

            R0189_00_LER_BILHETE_ERROS_DB_FETCH_1();

            /*" -1945- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1946- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1947- MOVE 'FIM' TO W-FIM-BILHETE-ERROS */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_ERROS);

                    /*" -1947- PERFORM R0189_00_LER_BILHETE_ERROS_DB_CLOSE_1 */

                    R0189_00_LER_BILHETE_ERROS_DB_CLOSE_1();

                    /*" -1949- ELSE */
                }
                else
                {


                    /*" -1950- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -1951- DISPLAY '          ERRO FETCH CURSOR BILHETE-ERROS' */
                    _.Display($"          ERRO FETCH CURSOR BILHETE-ERROS");

                    /*" -1953- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -1954- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1954- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0189-00-LER-BILHETE-ERROS-DB-FETCH-1 */
        public void R0189_00_LER_BILHETE_ERROS_DB_FETCH_1()
        {
            /*" -1942- EXEC SQL FETCH BILHETE-ERROS INTO :ERROSBIL-NUM-BILHETE, :ERROSBIL-COD-ERRO END-EXEC. */

            if (BILHETE_ERROS.Fetch())
            {
                _.Move(BILHETE_ERROS.ERROSBIL_NUM_BILHETE, ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_NUM_BILHETE);
                _.Move(BILHETE_ERROS.ERROSBIL_COD_ERRO, ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_COD_ERRO);
            }

        }

        [StopWatch]
        /*" R0189-00-LER-BILHETE-ERROS-DB-CLOSE-1 */
        public void R0189_00_LER_BILHETE_ERROS_DB_CLOSE_1()
        {
            /*" -1947- EXEC SQL CLOSE BILHETE-ERROS END-EXEC */

            BILHETE_ERROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0189_SAIDA*/

        [StopWatch]
        /*" R0189-10-TRATAR-ERROS-BILHETE-SECTION */
        private void R0189_10_TRATAR_ERROS_BILHETE_SECTION()
        {
            /*" -1967- MOVE 'R0189-10-TRATAR-ERROS-BILHETE' TO PARAGRAFO. */
            _.Move("R0189-10-TRATAR-ERROS-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1968- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1970- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1973- MOVE 1 TO W-TEM-ERRO-BILHETE. */
            _.Move(1, WAREA_AUXILIAR.W_TEM_ERRO_BILHETE);

            /*" -1974- IF ERROSBIL-COD-ERRO EQUAL 11802 OR 11701 */

            if (ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_COD_ERRO.In("11802", "11701"))
            {

                /*" -1974- PERFORM R0189_10_TRATAR_ERROS_BILHETE_DB_CLOSE_1 */

                R0189_10_TRATAR_ERROS_BILHETE_DB_CLOSE_1();

                /*" -1976- MOVE 'FIM' TO W-FIM-BILHETE-ERROS */
                _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_ERROS);

                /*" -1977- MOVE 2 TO W-RCAP */
                _.Move(2, WAREA_AUXILIAR.W_RCAP);

                /*" -1978- ELSE */
            }
            else
            {


                /*" -1978- PERFORM R0189-00-LER-BILHETE-ERROS. */

                R0189_00_LER_BILHETE_ERROS_SECTION();
            }


        }

        [StopWatch]
        /*" R0189-10-TRATAR-ERROS-BILHETE-DB-CLOSE-1 */
        public void R0189_10_TRATAR_ERROS_BILHETE_DB_CLOSE_1()
        {
            /*" -1974- EXEC SQL CLOSE BILHETE-ERROS END-EXEC */

            BILHETE_ERROS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0189_10_SAIDA*/

        [StopWatch]
        /*" R0187-DE-PARA-ERRO-BILHETE-SECTION */
        private void R0187_DE_PARA_ERRO_BILHETE_SECTION()
        {
            /*" -1988- MOVE 'R0187-DE-PARA-ERRO-BILHETE' TO PARAGRAFO. */
            _.Move("R0187-DE-PARA-ERRO-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1989- MOVE 'SELECT COD-ERROS-BILHETE' TO COMANDO. */
            _.Move("SELECT COD-ERROS-BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1991- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2004- MOVE ERROSBIL-COD-ERRO TO CODERRBI-COD-ERRO. */
            _.Move(ERROSBIL.DCLBILHETE_ERROS.ERROSBIL_COD_ERRO, CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO);

            /*" -2012- PERFORM R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1 */

            R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1();

            /*" -2015- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2016- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -2017- DISPLAY '          ERRO SELECT TAB. VG_DM_MSG_CRITICA' */
                _.Display($"          ERRO SELECT TAB. VG_DM_MSG_CRITICA");

                /*" -2019- DISPLAY '          COD-ERRO................ ' CODERRBI-COD-ERRO */
                _.Display($"          COD-ERRO................ {CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO}");

                /*" -2021- DISPLAY '          SQLCODE................. ' SQLCODE */
                _.Display($"          SQLCODE................. {DB.SQLCODE}");

                /*" -2022- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2022- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0187-DE-PARA-ERRO-BILHETE-DB-SELECT-1 */
        public void R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1()
        {
            /*" -2012- EXEC SQL SELECT COD_MSG_CRITICA, COD_ERRO_SIVPF INTO :CODERRBI-COD-ERRO, :CODERRBI-COD-ERRO-SIVPF FROM SEGUROS.VG_DM_MSG_CRITICA WHERE COD_MSG_CRITICA = :CODERRBI-COD-ERRO WITH UR END-EXEC. */

            var r0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1_Query1 = new R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1_Query1()
            {
                CODERRBI_COD_ERRO = CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO.ToString(),
            };

            var executed_1 = R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1_Query1.Execute(r0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CODERRBI_COD_ERRO, CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO);
                _.Move(executed_1.CODERRBI_COD_ERRO_SIVPF, CODERRBI.DCLCOD_ERROS_BILHETE.CODERRBI_COD_ERRO_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0187_SAIDA*/

        [StopWatch]
        /*" R0190-00-GERAR-REGISTRO-TP1-SECTION */
        private void R0190_00_GERAR_REGISTRO_TP1_SECTION()
        {
            /*" -2033- MOVE 'R0190-00-GERAR-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0190-00-GERAR-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2034- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2036- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2038- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -2041- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -2044- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -2047- MOVE PROPFIDH-SIT-PROPOSTA TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA, LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -2050- MOVE PROPFIDH-SIT-MOTIVO-SIVPF TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

            /*" -2053- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2054- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2055- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2057- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2060- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -2063- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -2065- ADD 1 TO W-QTD-LD-TIPO-1, W-ABEND-CTR. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;
            WAREA_AUXILIAR.W_ABEND_CTR.Value = WAREA_AUXILIAR.W_ABEND_CTR + 1;

            /*" -2068- MOVE W-QTD-LD-TIPO-1 TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -2070- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2071- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0195-BUSCA-DADOS-HISPROFI-SECTION */
        private void R0195_BUSCA_DADOS_HISPROFI_SECTION()
        {
            /*" -2077- MOVE 'R0195-BUSCA-DADOS-HISPROFI' TO PARAGRAFO. */
            _.Move("R0195-BUSCA-DADOS-HISPROFI", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2078- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2080- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2081- IF PROPFIDH-SIT-PROPOSTA EQUAL 'REJ' OR 'POB' */

            if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.In("REJ", "POB"))
            {

                /*" -2090- PERFORM R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1 */

                R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1();

                /*" -2094- ELSE */
            }
            else
            {


                /*" -2107- PERFORM R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2 */

                R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2();

                /*" -2110- END-IF. */
            }


            /*" -2111- IF SQLCODE NOT EQUAL 00 AND 100 AND -811 */

            if (!DB.SQLCODE.In("00", "100", "-811"))
            {

                /*" -2112- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -2113- DISPLAY ' ERRO SELECT TAB. HIST_PROP_FIDELIZ' */
                _.Display($" ERRO SELECT TAB. HIST_PROP_FIDELIZ");

                /*" -2114- DISPLAY ' SQLCODE..... = ' SQLCODE */
                _.Display($" SQLCODE..... = {DB.SQLCODE}");

                /*" -2115- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2117- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2118- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -2119- MOVE 'SIM' TO WS-TEM-HIST-FIDELIZ */
                _.Move("SIM", WAREA_AUXILIAR.WS_TEM_HIST_FIDELIZ);

                /*" -2120- END-IF. */
            }


        }

        [StopWatch]
        /*" R0195-BUSCA-DADOS-HISPROFI-DB-SELECT-1 */
        public void R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1()
        {
            /*" -2090- EXEC SQL SELECT DATA_SITUACAO INTO :PROPFIDH-DATA-SITUACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA WITH UR END-EXEC */

            var r0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1_Query1 = new R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1_Query1.Execute(r0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0195_SAIDA*/

        [StopWatch]
        /*" R0195-BUSCA-DADOS-HISPROFI-DB-SELECT-2 */
        public void R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2()
        {
            /*" -2107- EXEC SQL SELECT DATA_SITUACAO INTO :PROPFIDH-DATA-SITUACAO FROM SEGUROS.HIST_PROP_FIDELIZ WHERE NUM_IDENTIFICACAO = :PROPFIDH-NUM-IDENTIFICACAO AND SIT_PROPOSTA = :PROPFIDH-SIT-PROPOSTA AND SIT_MOTIVO_SIVPF = :PROPFIDH-SIT-MOTIVO-SIVPF AND DATA_SITUACAO = :PROPFIDH-DATA-SITUACAO WITH UR END-EXEC */

            var r0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2_Query1 = new R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2_Query1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
            };

            var executed_1 = R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2_Query1.Execute(r0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPFIDH_DATA_SITUACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);
            }


        }

        [StopWatch]
        /*" R0200-00-PROCESSAR-BILHETE-SECTION */
        private void R0200_00_PROCESSAR_BILHETE_SECTION()
        {
            /*" -2129- MOVE 'R0200-00-PROCESSAR-BILHETE' TO PARAGRAFO. */
            _.Move("R0200-00-PROCESSAR-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2130- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2134- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2136- MOVE 'NAO' TO W-FIM-BILHETE-COB. */
            _.Move("NAO", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

            /*" -2138- MOVE 1 TO W-BILHETE-LIDO. */
            _.Move(1, WAREA_AUXILIAR.W_BILHETE_LIDO);

            /*" -2140- MOVE ZERO TO W-TEM-COBERTURA-BILHETE. */
            _.Move(0, WAREA_AUXILIAR.W_TEM_COBERTURA_BILHETE);

            /*" -2142- PERFORM R0240-00-SELECIONA-BIL-COB. */

            R0240_00_SELECIONA_BIL_COB_SECTION();

            /*" -2144- PERFORM R0245-00-LER-BILHETE-COBER. */

            R0245_00_LER_BILHETE_COBER_SECTION();

            /*" -2145- IF TEM-COBERTURA-BILHETE */

            if (WAREA_AUXILIAR.W_TEM_COBERTURA_BILHETE["TEM_COBERTURA_BILHETE"])
            {

                /*" -2147- PERFORM R0250-00-GERAR-REGISTROS UNTIL W-FIM-BILHETE-COB EQUAL 'FIM' */

                while (!(WAREA_AUXILIAR.W_FIM_BILHETE_COB == "FIM"))
                {

                    R0250_00_GERAR_REGISTROS_SECTION();
                }

                /*" -2148- ELSE */
            }
            else
            {


                /*" -2149- PERFORM R0246-00-OBTER-COB-VALOR */

                R0246_00_OBTER_COB_VALOR_SECTION();

                /*" -2150- PERFORM R0247-00-LER-COBER-VALOR */

                R0247_00_LER_COBER_VALOR_SECTION();

                /*" -2151- PERFORM R0248-00-GERAR-REGISTROS UNTIL W-FIM-BILHETE-COB EQUAL 'FIM' . */

                while (!(WAREA_AUXILIAR.W_FIM_BILHETE_COB == "FIM"))
                {

                    R0248_00_GERAR_REGISTROS_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0220-00-LER-BILHETE-SECTION */
        private void R0220_00_LER_BILHETE_SECTION()
        {
            /*" -2161- MOVE 'R0220-00-LER-BILHETE' TO PARAGRAFO. */
            _.Move("R0220-00-LER-BILHETE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2162- MOVE 'SELECT BILHETE' TO COMANDO. */
            _.Move("SELECT BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2164- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2167- MOVE NUM-SICOB OF DCLPROPOSTA-FIDELIZ TO BILHETE-NUM-BILHETE OF DCLBILHETE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);

            /*" -2187- PERFORM R0220_00_LER_BILHETE_DB_SELECT_1 */

            R0220_00_LER_BILHETE_DB_SELECT_1();

            /*" -2190- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2191- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -2192- DISPLAY '          ERRO SELECT TAB. BILHETE' */
                _.Display($"          ERRO SELECT TAB. BILHETE");

                /*" -2196- DISPLAY '          NUMERO BILHETE.......... ' BILHETE-NUM-BILHETE OF DCLBILHETE ' PROPOSTA.....' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */

                $"          NUMERO BILHETE.......... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE} PROPOSTA.....{PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -2198- DISPLAY '          SQLCODE..................' SQLCODE */
                _.Display($"          SQLCODE..................{DB.SQLCODE}");

                /*" -2199- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2199- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0220-00-LER-BILHETE-DB-SELECT-1 */
        public void R0220_00_LER_BILHETE_DB_SELECT_1()
        {
            /*" -2187- EXEC SQL SELECT NUM_BILHETE, NUM_APOLICE, NUM_APOL_ANTERIOR, OPC_COBERTURA, DATA_QUITACAO, VAL_RCAP, RAMO, SITUACAO INTO :DCLBILHETE.BILHETE-NUM-BILHETE, :DCLBILHETE.BILHETE-NUM-APOLICE, :DCLBILHETE.BILHETE-NUM-APOL-ANTERIOR, :DCLBILHETE.BILHETE-OPC-COBERTURA, :DCLBILHETE.BILHETE-DATA-QUITACAO, :DCLBILHETE.BILHETE-VAL-RCAP, :DCLBILHETE.BILHETE-RAMO, :DCLBILHETE.BILHETE-SITUACAO FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :DCLBILHETE.BILHETE-NUM-BILHETE WITH UR END-EXEC. */

            var r0220_00_LER_BILHETE_DB_SELECT_1_Query1 = new R0220_00_LER_BILHETE_DB_SELECT_1_Query1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            var executed_1 = R0220_00_LER_BILHETE_DB_SELECT_1_Query1.Execute(r0220_00_LER_BILHETE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(executed_1.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(executed_1.BILHETE_NUM_APOL_ANTERIOR, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);
                _.Move(executed_1.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_RAMO, BILHETE.DCLBILHETE.BILHETE_RAMO);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_SAIDA*/

        [StopWatch]
        /*" R0230-00-LER-ENDOSSO-SECTION */
        private void R0230_00_LER_ENDOSSO_SECTION()
        {
            /*" -2209- MOVE 'R0230-00-LER-ENDOSSO' TO PARAGRAFO. */
            _.Move("R0230-00-LER-ENDOSSO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2210- MOVE 'SELECT BILHETE' TO COMANDO. */
            _.Move("SELECT BILHETE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2212- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2215- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -2218- MOVE ZEROS TO ENDOSSOS-NUM-ENDOSSO OF DCLENDOSSOS. */
            _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -2241- PERFORM R0230_00_LER_ENDOSSO_DB_SELECT_1 */

            R0230_00_LER_ENDOSSO_DB_SELECT_1();

            /*" -2244- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2245- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2254- MOVE ZEROS TO ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS ENDOSSOS-NUM-ENDOSSO OF DCLENDOSSOS ENDOSSOS-NUM-PROPOSTA OF DCLENDOSSOS ENDOSSOS-DATA-PROPOSTA OF DCLENDOSSOS ENDOSSOS-DATA-EMISSAO OF DCLENDOSSOS ENDOSSOS-NUM-RCAP OF DCLENDOSSOS ENDOSSOS-VAL-RCAP OF DCLENDOSSOS ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS */
                    _.Move(0, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_PROPOSTA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);

                    /*" -2255- ELSE */
                }
                else
                {


                    /*" -2256- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -2257- DISPLAY '          ERRO SELECT TAB. ENDOSSO' */
                    _.Display($"          ERRO SELECT TAB. ENDOSSO");

                    /*" -2259- DISPLAY '          NUMERO APOLICE.......... ' ENDOSSOS-NUM-APOLICE OF DCLENDOSSOS */
                    _.Display($"          NUMERO APOLICE.......... {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -2261- DISPLAY '          NUM BILHETE......... ' BILHETE-NUM-BILHETE OF DCLBILHETE */
                    _.Display($"          NUM BILHETE......... {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -2263- DISPLAY '          SQLCODE................. ' SQLCODE */
                    _.Display($"          SQLCODE................. {DB.SQLCODE}");

                    /*" -2264- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2264- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0230-00-LER-ENDOSSO-DB-SELECT-1 */
        public void R0230_00_LER_ENDOSSO_DB_SELECT_1()
        {
            /*" -2241- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, NUM_PROPOSTA, DATA_PROPOSTA, DATA_EMISSAO, NUM_RCAP, VAL_RCAP, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE, :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO, :DCLENDOSSOS.ENDOSSOS-NUM-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-PROPOSTA, :DCLENDOSSOS.ENDOSSOS-DATA-EMISSAO, :DCLENDOSSOS.ENDOSSOS-NUM-RCAP, :DCLENDOSSOS.ENDOSSOS-VAL-RCAP, :DCLENDOSSOS.ENDOSSOS-DATA-INIVIGENCIA, :DCLENDOSSOS.ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :DCLENDOSSOS.ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :DCLENDOSSOS.ENDOSSOS-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0230_00_LER_ENDOSSO_DB_SELECT_1_Query1 = new R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1.Execute(r0230_00_LER_ENDOSSO_DB_SELECT_1_Query1);
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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R0240-00-SELECIONA-BIL-COB-SECTION */
        private void R0240_00_SELECIONA_BIL_COB_SECTION()
        {
            /*" -2274- MOVE 'R0240-00-SELECIONA-BIL-COBE' TO PARAGRAFO. */
            _.Move("R0240-00-SELECIONA-BIL-COBE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2275- MOVE 'DECLARE BILHETE-COBER' TO COMANDO. */
            _.Move("DECLARE BILHETE-COBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2277- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2281- MOVE ZEROS TO BILCOBER-COD-EMPRESA BILCOBER-MODALI-COBERTURA. */
            _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_EMPRESA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);

            /*" -2284- MOVE BILHETE-RAMO OF DCLBILHETE TO BILCOBER-RAMO-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);

            /*" -2287- MOVE BILHETE-OPC-COBERTURA OF DCLBILHETE TO BILCOBER-COD-OPCAO-PLANO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);

            /*" -2290- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO BILCOBER-PRM-TOTAL. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);

            /*" -2293- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);

            /*" -2296- MOVE ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);

            /*" -2299- MOVE '1' TO BILCOBER-IDE-COBERTURA. */
            _.Move("1", BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA);

            /*" -2330- PERFORM R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1 */

            R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1();

            /*" -2332- PERFORM R0240_00_SELECIONA_BIL_COB_DB_OPEN_1 */

            R0240_00_SELECIONA_BIL_COB_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0240-00-SELECIONA-BIL-COB-DB-OPEN-1 */
        public void R0240_00_SELECIONA_BIL_COB_DB_OPEN_1()
        {
            /*" -2332- EXEC SQL OPEN BILHETE-COBERTURA END-EXEC. */

            BILHETE_COBERTURA.Open();

        }

        [StopWatch]
        /*" R0246-00-OBTER-COB-VALOR-DB-DECLARE-1 */
        public void R0246_00_OBTER_COB_VALOR_DB_DECLARE_1()
        {
            /*" -2435- EXEC SQL DECLARE BILHETE-COBER CURSOR FOR SELECT COD_PRODUTO, RAMO_COBERTURA, MODALI_COBERTURA, COD_OPCAO_PLANO, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IDE_COBERTURA, VAL_COBERTURA_IX, PRM_TOTAL, PCT_IOCC FROM SEGUROS.BILHETE_COBERTURA WHERE COD_EMPRESA = :BILCOBER-COD-EMPRESA AND RAMO_COBERTURA = :BILCOBER-RAMO-COBERTURA AND MODALI_COBERTURA = :BILCOBER-MODALI-COBERTURA AND PRM_TOTAL = :BILCOBER-PRM-TOTAL ORDER BY COD_COBERTURA WITH UR END-EXEC. */
            BILHETE_COBER = new PF0605B_BILHETE_COBER(true);
            string GetQuery_BILHETE_COBER()
            {
                var query = @$"SELECT COD_PRODUTO
							, 
							RAMO_COBERTURA
							, 
							MODALI_COBERTURA
							, 
							COD_OPCAO_PLANO
							, 
							COD_COBERTURA
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							IDE_COBERTURA
							, 
							VAL_COBERTURA_IX
							, 
							PRM_TOTAL
							, 
							PCT_IOCC 
							FROM SEGUROS.BILHETE_COBERTURA 
							WHERE COD_EMPRESA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_EMPRESA}' 
							AND RAMO_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA}' 
							AND MODALI_COBERTURA = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA}' 
							AND PRM_TOTAL = 
							'{BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL}' 
							ORDER BY COD_COBERTURA";

                return query;
            }
            BILHETE_COBER.GetQueryEvent += GetQuery_BILHETE_COBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0240_SAIDA*/

        [StopWatch]
        /*" R0245-00-LER-BILHETE-COBER-SECTION */
        private void R0245_00_LER_BILHETE_COBER_SECTION()
        {
            /*" -2341- MOVE 'R0245-00-LER-BILHETE-COBER' TO PARAGRAFO. */
            _.Move("R0245-00-LER-BILHETE-COBER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2342- MOVE 'FETCH BILHETE-COBERTURA' TO COMANDO. */
            _.Move("FETCH BILHETE-COBERTURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2344- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2357- PERFORM R0245_00_LER_BILHETE_COBER_DB_FETCH_1 */

            R0245_00_LER_BILHETE_COBER_DB_FETCH_1();

            /*" -2360- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2361- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2362- MOVE 'FIM' TO W-FIM-BILHETE-COB */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

                    /*" -2362- PERFORM R0245_00_LER_BILHETE_COBER_DB_CLOSE_1 */

                    R0245_00_LER_BILHETE_COBER_DB_CLOSE_1();

                    /*" -2364- ELSE */
                }
                else
                {


                    /*" -2365- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -2366- DISPLAY '          ERRO FETCH CURSOR BILHETE-COBERTURA' */
                    _.Display($"          ERRO FETCH CURSOR BILHETE-COBERTURA");

                    /*" -2368- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -2369- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2370- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2371- ELSE */
                }

            }
            else
            {


                /*" -2372- MOVE 1 TO W-TEM-COBERTURA-BILHETE */
                _.Move(1, WAREA_AUXILIAR.W_TEM_COBERTURA_BILHETE);

                /*" -2373- COMPUTE W-IND-IOF = (BILCOBER-PCT-IOCC / 100) + 1. */
                WAREA_AUXILIAR.W_IND_IOF.Value = (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC / 100f) + 1;
            }


        }

        [StopWatch]
        /*" R0245-00-LER-BILHETE-COBER-DB-FETCH-1 */
        public void R0245_00_LER_BILHETE_COBER_DB_FETCH_1()
        {
            /*" -2357- EXEC SQL FETCH BILHETE-COBERTURA INTO :BILCOBER-COD-PRODUTO, :BILCOBER-RAMO-COBERTURA, :BILCOBER-MODALI-COBERTURA, :BILCOBER-COD-OPCAO-PLANO, :BILCOBER-COD-COBERTURA, :BILCOBER-DATA-INIVIGENCIA, :BILCOBER-DATA-TERVIGENCIA, :BILCOBER-IDE-COBERTURA, :BILCOBER-VAL-COBERTURA-IX, :BILCOBER-PRM-TOTAL, :BILCOBER-PCT-IOCC END-EXEC. */

            if (BILHETE_COBERTURA.Fetch())
            {
                _.Move(BILHETE_COBERTURA.BILCOBER_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);
                _.Move(BILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);
                _.Move(BILHETE_COBERTURA.BILCOBER_COD_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);
                _.Move(BILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);
                _.Move(BILHETE_COBERTURA.BILCOBER_IDE_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA);
                _.Move(BILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX);
                _.Move(BILHETE_COBERTURA.BILCOBER_PRM_TOTAL, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);
                _.Move(BILHETE_COBERTURA.BILCOBER_PCT_IOCC, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC);
            }

        }

        [StopWatch]
        /*" R0245-00-LER-BILHETE-COBER-DB-CLOSE-1 */
        public void R0245_00_LER_BILHETE_COBER_DB_CLOSE_1()
        {
            /*" -2362- EXEC SQL CLOSE BILHETE-COBERTURA END-EXEC */

            BILHETE_COBERTURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0245_SAIDA*/

        [StopWatch]
        /*" R0246-00-OBTER-COB-VALOR-SECTION */
        private void R0246_00_OBTER_COB_VALOR_SECTION()
        {
            /*" -2383- MOVE 'R0246-00-OBTER-COB-VALOR' TO PARAGRAFO. */
            _.Move("R0246-00-OBTER-COB-VALOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2384- MOVE 'DECLARE BILHETE-COBER' TO COMANDO. */
            _.Move("DECLARE BILHETE-COBER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2386- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2388- MOVE SPACES TO W-FIM-BILHETE-COB. */
            _.Move("", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

            /*" -2392- MOVE ZEROS TO BILCOBER-COD-EMPRESA BILCOBER-MODALI-COBERTURA. */
            _.Move(0, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_EMPRESA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);

            /*" -2395- MOVE BILHETE-RAMO OF DCLBILHETE TO BILCOBER-RAMO-COBERTURA. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_RAMO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);

            /*" -2398- MOVE BILHETE-OPC-COBERTURA OF DCLBILHETE TO BILCOBER-COD-OPCAO-PLANO. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);

            /*" -2401- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO BILCOBER-PRM-TOTAL. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);

            /*" -2404- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-INIVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);

            /*" -2407- MOVE ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS TO BILCOBER-DATA-TERVIGENCIA. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);

            /*" -2410- MOVE '1' TO BILCOBER-IDE-COBERTURA. */
            _.Move("1", BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA);

            /*" -2435- PERFORM R0246_00_OBTER_COB_VALOR_DB_DECLARE_1 */

            R0246_00_OBTER_COB_VALOR_DB_DECLARE_1();

            /*" -2437- PERFORM R0246_00_OBTER_COB_VALOR_DB_OPEN_1 */

            R0246_00_OBTER_COB_VALOR_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0246-00-OBTER-COB-VALOR-DB-OPEN-1 */
        public void R0246_00_OBTER_COB_VALOR_DB_OPEN_1()
        {
            /*" -2437- EXEC SQL OPEN BILHETE-COBER END-EXEC. */

            BILHETE_COBER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0246_SAIDA*/

        [StopWatch]
        /*" R0247-00-LER-COBER-VALOR-SECTION */
        private void R0247_00_LER_COBER_VALOR_SECTION()
        {
            /*" -2446- MOVE 'R0247-00-LER-COBER-VALOR' TO PARAGRAFO. */
            _.Move("R0247-00-LER-COBER-VALOR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2447- MOVE 'FETCH BILHETE-COBERTURA' TO COMANDO. */
            _.Move("FETCH BILHETE-COBERTURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2449- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2462- PERFORM R0247_00_LER_COBER_VALOR_DB_FETCH_1 */

            R0247_00_LER_COBER_VALOR_DB_FETCH_1();

            /*" -2465- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2466- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2467- MOVE 'FIM' TO W-FIM-BILHETE-COB */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_BILHETE_COB);

                    /*" -2467- PERFORM R0247_00_LER_COBER_VALOR_DB_CLOSE_1 */

                    R0247_00_LER_COBER_VALOR_DB_CLOSE_1();

                    /*" -2469- ELSE */
                }
                else
                {


                    /*" -2470- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -2471- DISPLAY '          ERRO FETCH CURSOR BILHETE-COBERTURA' */
                    _.Display($"          ERRO FETCH CURSOR BILHETE-COBERTURA");

                    /*" -2473- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -2474- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2475- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2476- ELSE */
                }

            }
            else
            {


                /*" -2477- COMPUTE W-IND-IOF = (BILCOBER-PCT-IOCC / 100) + 1. */
                WAREA_AUXILIAR.W_IND_IOF.Value = (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC / 100f) + 1;
            }


        }

        [StopWatch]
        /*" R0247-00-LER-COBER-VALOR-DB-FETCH-1 */
        public void R0247_00_LER_COBER_VALOR_DB_FETCH_1()
        {
            /*" -2462- EXEC SQL FETCH BILHETE-COBER INTO :BILCOBER-COD-PRODUTO, :BILCOBER-RAMO-COBERTURA, :BILCOBER-MODALI-COBERTURA, :BILCOBER-COD-OPCAO-PLANO, :BILCOBER-COD-COBERTURA, :BILCOBER-DATA-INIVIGENCIA, :BILCOBER-DATA-TERVIGENCIA, :BILCOBER-IDE-COBERTURA, :BILCOBER-VAL-COBERTURA-IX, :BILCOBER-PRM-TOTAL, :BILCOBER-PCT-IOCC END-EXEC. */

            if (BILHETE_COBER.Fetch())
            {
                _.Move(BILHETE_COBER.BILCOBER_COD_PRODUTO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO);
                _.Move(BILHETE_COBER.BILCOBER_RAMO_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_RAMO_COBERTURA);
                _.Move(BILHETE_COBER.BILCOBER_MODALI_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_MODALI_COBERTURA);
                _.Move(BILHETE_COBER.BILCOBER_COD_OPCAO_PLANO, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_OPCAO_PLANO);
                _.Move(BILHETE_COBER.BILCOBER_COD_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA);
                _.Move(BILHETE_COBER.BILCOBER_DATA_INIVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_INIVIGENCIA);
                _.Move(BILHETE_COBER.BILCOBER_DATA_TERVIGENCIA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_DATA_TERVIGENCIA);
                _.Move(BILHETE_COBER.BILCOBER_IDE_COBERTURA, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_IDE_COBERTURA);
                _.Move(BILHETE_COBER.BILCOBER_VAL_COBERTURA_IX, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX);
                _.Move(BILHETE_COBER.BILCOBER_PRM_TOTAL, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL);
                _.Move(BILHETE_COBER.BILCOBER_PCT_IOCC, BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PCT_IOCC);
            }

        }

        [StopWatch]
        /*" R0247-00-LER-COBER-VALOR-DB-CLOSE-1 */
        public void R0247_00_LER_COBER_VALOR_DB_CLOSE_1()
        {
            /*" -2467- EXEC SQL CLOSE BILHETE-COBER END-EXEC */

            BILHETE_COBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0247_SAIDA*/

        [StopWatch]
        /*" R0248-00-GERAR-REGISTROS-SECTION */
        private void R0248_00_GERAR_REGISTROS_SECTION()
        {
            /*" -2485- MOVE 'R0248-00-GERAR-REGISTROS' TO PARAGRAFO. */
            _.Move("R0248-00-GERAR-REGISTROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2486- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2488- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2489- IF W-BILHETE-LIDO EQUAL 1 */

            if (WAREA_AUXILIAR.W_BILHETE_LIDO == 1)
            {

                /*" -2491- PERFORM R0270-00-GERAR-REG-TP2-BIL. */

                R0270_00_GERAR_REG_TP2_BIL_SECTION();
            }


            /*" -2493- MOVE 1 TO W-REG-BIL-AP. */
            _.Move(1, WAREA_AUXILIAR.W_REG_BIL_AP);

            /*" -2494- IF BILHETE-AP */

            if (WAREA_AUXILIAR.W_PRODUTO["BILHETE_AP"])
            {

                /*" -2495- ADD 1 TO W-LIDO-BIL-AP */
                WAREA_AUXILIAR.W_LIDO_BIL_AP.Value = WAREA_AUXILIAR.W_LIDO_BIL_AP + 1;

                /*" -2496- MOVE 09 TO W-SUBPRODUTO */
                _.Move(09, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -2498- PERFORM R0300-00-GERAR-REG-TP3-AP 2 TIMES */

                for (int i = 0; i < 2; i++)
                {

                    R0300_00_GERAR_REG_TP3_AP_SECTION();

                }

                /*" -2499- ELSE */
            }
            else
            {


                /*" -2500- IF MICROSSEGURO-AMPARO */

                if (WAREA_AUXILIAR.W_PRODUTO["MICROSSEGURO_AMPARO"])
                {

                    /*" -2501- ADD 1 TO W-LIDO-MIC-AMPARO */
                    WAREA_AUXILIAR.W_LIDO_MIC_AMPARO.Value = WAREA_AUXILIAR.W_LIDO_MIC_AMPARO + 1;

                    /*" -2502- MOVE 001 TO W-SUBPRODUTO */
                    _.Move(001, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                    /*" -2503- PERFORM R0300-00-GERAR-REG-TP3-AP */

                    R0300_00_GERAR_REG_TP3_AP_SECTION();

                    /*" -2504- ELSE */
                }
                else
                {


                    /*" -2505- ADD 1 TO W-LIDO-BIL-RD */
                    WAREA_AUXILIAR.W_LIDO_BIL_RD.Value = WAREA_AUXILIAR.W_LIDO_BIL_RD + 1;

                    /*" -2506- MOVE 10 TO W-SUBPRODUTO */
                    _.Move(10, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                    /*" -2507- PERFORM R0350-00-GERAR-REG-TP3-RD */

                    R0350_00_GERAR_REG_TP3_RD_SECTION();

                    /*" -2508- END-IF */
                }


                /*" -2510- END-IF */
            }


            /*" -2512- PERFORM R0247-00-LER-COBER-VALOR */

            R0247_00_LER_COBER_VALOR_SECTION();

            /*" -2512- ADD 1 TO W-BILHETE-LIDO. */
            WAREA_AUXILIAR.W_BILHETE_LIDO.Value = WAREA_AUXILIAR.W_BILHETE_LIDO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0248_SAIDA*/

        [StopWatch]
        /*" R0250-00-GERAR-REGISTROS-SECTION */
        private void R0250_00_GERAR_REGISTROS_SECTION()
        {
            /*" -2522- MOVE 'R0250-00-GERAR-REGISTROS' TO PARAGRAFO. */
            _.Move("R0250-00-GERAR-REGISTROS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2523- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2525- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2526- IF W-BILHETE-LIDO EQUAL 1 */

            if (WAREA_AUXILIAR.W_BILHETE_LIDO == 1)
            {

                /*" -2528- PERFORM R0270-00-GERAR-REG-TP2-BIL. */

                R0270_00_GERAR_REG_TP2_BIL_SECTION();
            }


            /*" -2530- MOVE 1 TO W-REG-BIL-AP. */
            _.Move(1, WAREA_AUXILIAR.W_REG_BIL_AP);

            /*" -2531- IF BILHETE-AP */

            if (WAREA_AUXILIAR.W_PRODUTO["BILHETE_AP"])
            {

                /*" -2532- ADD 1 TO W-LIDO-BIL-AP */
                WAREA_AUXILIAR.W_LIDO_BIL_AP.Value = WAREA_AUXILIAR.W_LIDO_BIL_AP + 1;

                /*" -2533- MOVE 09 TO W-SUBPRODUTO */
                _.Move(09, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                /*" -2535- PERFORM R0300-00-GERAR-REG-TP3-AP 2 TIMES */

                for (int i = 0; i < 2; i++)
                {

                    R0300_00_GERAR_REG_TP3_AP_SECTION();

                }

                /*" -2536- ELSE */
            }
            else
            {


                /*" -2537- IF MICROSSEGURO-AMPARO */

                if (WAREA_AUXILIAR.W_PRODUTO["MICROSSEGURO_AMPARO"])
                {

                    /*" -2538- ADD 1 TO W-LIDO-MIC-AMPARO */
                    WAREA_AUXILIAR.W_LIDO_MIC_AMPARO.Value = WAREA_AUXILIAR.W_LIDO_MIC_AMPARO + 1;

                    /*" -2539- MOVE 001 TO W-SUBPRODUTO */
                    _.Move(001, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                    /*" -2540- PERFORM R0300-00-GERAR-REG-TP3-AP */

                    R0300_00_GERAR_REG_TP3_AP_SECTION();

                    /*" -2541- ELSE */
                }
                else
                {


                    /*" -2542- ADD 1 TO W-LIDO-BIL-RD */
                    WAREA_AUXILIAR.W_LIDO_BIL_RD.Value = WAREA_AUXILIAR.W_LIDO_BIL_RD + 1;

                    /*" -2543- MOVE 10 TO W-SUBPRODUTO */
                    _.Move(10, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

                    /*" -2544- PERFORM R0350-00-GERAR-REG-TP3-RD */

                    R0350_00_GERAR_REG_TP3_RD_SECTION();

                    /*" -2545- END-IF */
                }


                /*" -2547- END-IF */
            }


            /*" -2549- PERFORM R0245-00-LER-BILHETE-COBER. */

            R0245_00_LER_BILHETE_COBER_SECTION();

            /*" -2549- ADD 1 TO W-BILHETE-LIDO. */
            WAREA_AUXILIAR.W_BILHETE_LIDO.Value = WAREA_AUXILIAR.W_BILHETE_LIDO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_SAIDA*/

        [StopWatch]
        /*" R0270-00-GERAR-REG-TP2-BIL-SECTION */
        private void R0270_00_GERAR_REG_TP2_BIL_SECTION()
        {
            /*" -2559- MOVE 'R0270-00-GERAR-REG-TP2-BIL' TO PARAGRAFO. */
            _.Move("R0270-00-GERAR-REG-TP2-BIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2560- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2562- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2564- MOVE SPACES TO REG-APOL-SASSE. */
            _.Move("", LBFCT016.REG_APOL_SASSE);

            /*" -2567- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE. */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -2570- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R2-NUM-PROPOSTA OF REG-APOL-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA);

            /*" -2573- MOVE BILHETE-NUM-APOLICE OF DCLBILHETE TO R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -2575- MOVE ENDOSSOS-DATA-INIVIGENCIA OF DCLENDOSSOS TO W-DATA-SQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2577- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2579- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2581- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2584- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -2586- MOVE ENDOSSOS-DATA-TERVIGENCIA OF DCLENDOSSOS TO W-DATA-SQL. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2588- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2590- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2593- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2596- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -2597- IF BILCOBER-PRM-TOTAL > 0 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL > 0)
            {

                /*" -2599- MOVE BILCOBER-PRM-TOTAL TO R2-VAL-PREMIO OF REG-APOL-SASSE */
                _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_PRM_TOTAL, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

                /*" -2600- ELSE */
            }
            else
            {


                /*" -2603- MOVE BILHETE-VAL-RCAP OF DCLBILHETE TO R2-VAL-PREMIO OF REG-APOL-SASSE. */
                _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);
            }


            /*" -2606- COMPUTE W-PRM-LIQ = R2-VAL-PREMIO OF REG-APOL-SASSE / W-IND-IOF. */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -2610- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - W-PRM-LIQ. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -2614- COMPUTE R2-VAL-PREMIO OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - R2-VAL-IOF OF REG-APOL-SASSE. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - LBFCT016.REG_APOL_SASSE.R2_VAL_IOF;

            /*" -2616- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2618- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

            /*" -2619- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R2-NUM-PROPOSTA OF REG-APOL-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0270_SAIDA*/

        [StopWatch]
        /*" R0282-00-OBTER-DT-SIT-VDZ-SECTION */
        private void R0282_00_OBTER_DT_SIT_VDZ_SECTION()
        {
            /*" -2629- MOVE 'R0282-00-OBTER-DT-SIT-VDZ' TO PARAGRAFO. */
            _.Move("R0282-00-OBTER-DT-SIT-VDZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2630- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2632- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2634- PERFORM R0284-00-ACESSAR-SEGURAVG. */

            R0284_00_ACESSAR_SEGURAVG_SECTION();

            /*" -2635- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2636- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -2637- DISPLAY '          ERRO SELECT V0SEGURAVG' */
                _.Display($"          ERRO SELECT V0SEGURAVG");

                /*" -2639- DISPLAY '          CERTIFICADO........... ' SEGVGAP-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO........... {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                /*" -2641- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -2642- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2644- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2646- PERFORM R0286-00-ACESSAR-HISTSEGVG. */

            R0286_00_ACESSAR_HISTSEGVG_SECTION();

            /*" -2647- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -2649- MOVE SEGVGAPH-DATA-OPERACAO TO PROPFIDH-DATA-SITUACAO */
                _.Move(SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_OPERACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

                /*" -2650- ELSE */
            }
            else
            {


                /*" -2651- IF SEGVGAP-OCORR-HISTORICO > 1 */

                if (SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_OCORR_HISTORICO > 1)
                {

                    /*" -2653- MOVE SEGVGAP-DATA-INIVIGENCIA TO PROPFIDH-DATA-SITUACAO */
                    _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_INIVIGENCIA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

                    /*" -2654- ELSE */
                }
                else
                {


                    /*" -2655- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -2656- DISPLAY '          ERRO SELECT V0HISTSEGVG' */
                    _.Display($"          ERRO SELECT V0HISTSEGVG");

                    /*" -2658- DISPLAY '          NUM APOLICE........... ' SEGVGAPH-NUM-APOLICE */
                    _.Display($"          NUM APOLICE........... {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE}");

                    /*" -2660- DISPLAY '          NUM ITEM.............. ' SEGVGAPH-NUM-ITEM */
                    _.Display($"          NUM ITEM.............. {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM}");

                    /*" -2662- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -2663- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2663- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0282_SAIDA*/

        [StopWatch]
        /*" R0284-00-ACESSAR-SEGURAVG-SECTION */
        private void R0284_00_ACESSAR_SEGURAVG_SECTION()
        {
            /*" -2673- MOVE 'R0284-00-ACESSAR-SEGURAVG' TO PARAGRAFO. */
            _.Move("R0284-00-ACESSAR-SEGURAVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2674- MOVE 'SELECT V0SEGURAVG' TO COMANDO. */
            _.Move("SELECT V0SEGURAVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2676- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2677- IF COD-PLANO OF DCLPROPOSTA-FIDELIZ = 0 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO == 0)
            {

                /*" -2679- MOVE 12 TO COD-PLANO OF DCLPROPOSTA-FIDELIZ. */
                _.Move(12, PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO);
            }


            /*" -2682- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO SEGVGAP-NUM-CERTIFICADO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO);

            /*" -2685- MOVE '1' TO SEGVGAP-TIPO-SEGURADO. */
            _.Move("1", SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_TIPO_SEGURADO);

            /*" -2705- PERFORM R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1 */

            R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1();

            /*" -2708- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2709- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -2710- DISPLAY '          ERRO SELECT V0SEGURAVG' */
                _.Display($"          ERRO SELECT V0SEGURAVG");

                /*" -2712- DISPLAY '          CERTIFICADO........... ' SEGVGAP-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO........... {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                /*" -2714- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -2715- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2715- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0284-00-ACESSAR-SEGURAVG-DB-SELECT-1 */
        public void R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1()
        {
            /*" -2705- EXEC SQL SELECT DAC_CERTIFICADO, NUM_APOLICE, COD_SUBGRUPO, NUM_ITEM, OCORR_HISTORICO, DATA_INIVIGENCIA , ( DATA_INIVIGENCIA + :DCLPROPOSTA-FIDELIZ.COD-PLANO MONTH ) INTO :SEGVGAP-DAC-CERTIFICADO, :SEGVGAP-NUM-APOLICE, :SEGVGAP-COD-SUBGRUPO, :SEGVGAP-NUM-ITEM, :SEGVGAP-OCORR-HISTORICO, :SEGVGAP-DATA-INIVIGENCIA, :WDTA-TERVG-CALC FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGVGAP-NUM-CERTIFICADO AND TIPO_SEGURADO = :SEGVGAP-TIPO-SEGURADO WITH UR END-EXEC. */

            var r0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1 = new R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1()
            {
                COD_PLANO = PROPFID.DCLPROPOSTA_FIDELIZ.COD_PLANO.ToString(),
                SEGVGAP_NUM_CERTIFICADO = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO.ToString(),
                SEGVGAP_TIPO_SEGURADO = SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_TIPO_SEGURADO.ToString(),
            };

            var executed_1 = R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1.Execute(r0284_00_ACESSAR_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAP_DAC_CERTIFICADO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DAC_CERTIFICADO);
                _.Move(executed_1.SEGVGAP_NUM_APOLICE, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE);
                _.Move(executed_1.SEGVGAP_COD_SUBGRUPO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_COD_SUBGRUPO);
                _.Move(executed_1.SEGVGAP_NUM_ITEM, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM);
                _.Move(executed_1.SEGVGAP_OCORR_HISTORICO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_OCORR_HISTORICO);
                _.Move(executed_1.SEGVGAP_DATA_INIVIGENCIA, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_DATA_INIVIGENCIA);
                _.Move(executed_1.WDTA_TERVG_CALC, WAREA_AUXILIAR.WDTA_TERVG_CALC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0284_SAIDA*/

        [StopWatch]
        /*" R0286-00-ACESSAR-HISTSEGVG-SECTION */
        private void R0286_00_ACESSAR_HISTSEGVG_SECTION()
        {
            /*" -2725- MOVE 'R0286-00-ACESSAR-HISTSEGVG' TO PARAGRAFO. */
            _.Move("R0286-00-ACESSAR-HISTSEGVG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2726- MOVE 'SELECT V0HISTSEGVG' TO COMANDO. */
            _.Move("SELECT V0HISTSEGVG", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2728- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2731- MOVE SEGVGAP-NUM-APOLICE TO SEGVGAPH-NUM-APOLICE. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE);

            /*" -2734- MOVE SEGVGAP-NUM-ITEM TO SEGVGAPH-NUM-ITEM. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM);

            /*" -2737- MOVE 1 TO SEGVGAPH-OCORR-HISTORICO. */
            _.Move(1, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO);

            /*" -2750- PERFORM R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1 */

            R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1();

            /*" -2753- IF SQLCODE NOT EQUAL 00 AND 100 AND 110 */

            if (!DB.SQLCODE.In("00", "100", "110"))
            {

                /*" -2754- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -2755- DISPLAY '          ERRO SELECT V0HISTSEGVG' */
                _.Display($"          ERRO SELECT V0HISTSEGVG");

                /*" -2757- DISPLAY '          NUM APOLICE........... ' SEGVGAPH-NUM-APOLICE */
                _.Display($"          NUM APOLICE........... {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE}");

                /*" -2759- DISPLAY '          NUM ITEM.............. ' SEGVGAPH-NUM-ITEM */
                _.Display($"          NUM ITEM.............. {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM}");

                /*" -2761- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -2762- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2762- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0286-00-ACESSAR-HISTSEGVG-DB-SELECT-1 */
        public void R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1()
        {
            /*" -2750- EXEC SQL SELECT DATA_OPERACAO, DATA_MOVIMENTO INTO :SEGVGAPH-DATA-OPERACAO, :SEGVGAPH-DATA-MOVIMENTO FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :SEGVGAPH-NUM-APOLICE AND NUM_ITEM = :SEGVGAPH-NUM-ITEM AND OCORR_HISTORICO = :SEGVGAPH-OCORR-HISTORICO WITH UR END-EXEC. */

            var r0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1_Query1 = new R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1_Query1()
            {
                SEGVGAPH_OCORR_HISTORICO = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_OCORR_HISTORICO.ToString(),
                SEGVGAPH_NUM_APOLICE = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE.ToString(),
                SEGVGAPH_NUM_ITEM = SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_ITEM.ToString(),
            };

            var executed_1 = R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1_Query1.Execute(r0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGVGAPH_DATA_OPERACAO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_OPERACAO);
                _.Move(executed_1.SEGVGAPH_DATA_MOVIMENTO, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0286_SAIDA*/

        [StopWatch]
        /*" R0300-00-GERAR-REG-TP3-AP-SECTION */
        private void R0300_00_GERAR_REG_TP3_AP_SECTION()
        {
            /*" -2772- MOVE 'R0300-00-GERAR-REG-TP3-AP' TO PARAGRAFO. */
            _.Move("R0300-00-GERAR-REG-TP3-AP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2773- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2775- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2777- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -2778- IF W-REG-BIL-AP EQUAL 2 */

            if (WAREA_AUXILIAR.W_REG_BIL_AP == 2)
            {

                /*" -2785- IF BILCOBER-COD-PRODUTO EQUAL 8144 OR 8145 OR 8146 OR 8147 OR 8148 OR 8149 OR 8150 OR 8112 OR 8113 OR JVPRD8144 OR JVPRD8145 OR JVPRD8146 OR JVPRD8147 OR JVPRD8148 OR JVPRD8149 OR JVPRD8150 */

                if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO.In("8144", "8145", "8146", "8147", "8148", "8149", "8150", "8112", "8113", JVBKINCL.JV_PRODUTOS.JVPRD8144.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8145.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8146.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8147.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8148.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8149.ToString(), JVBKINCL.JV_PRODUTOS.JVPRD8150.ToString()))
                {

                    /*" -2786- GO TO R0300-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/ //GOTO
                    return;

                    /*" -2787- END-IF */
                }


                /*" -2789- END-IF */
            }


            /*" -2792- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -2795- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -2802- MOVE BILCOBER-VAL-COBERTURA-IX TO R3-VAL-COBERTURA OF REG-COBER-SASSE. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -2807- IF (BILCOBER-COD-PRODUTO EQUAL 8528 OR BILCOBER-COD-PRODUTO EQUAL 8529 OR BILCOBER-COD-PRODUTO EQUAL 8533 OR BILCOBER-COD-PRODUTO EQUAL 8534) AND W-REG-BIL-AP EQUAL 2 */

            if ((BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO == 8528 || BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO == 8529 || BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO == 8533 || BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_PRODUTO == 8534) && WAREA_AUXILIAR.W_REG_BIL_AP == 2)
            {

                /*" -2808- GO TO R0300-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/ //GOTO
                return;

                /*" -2810- END-IF */
            }


            /*" -2811- IF W-REG-BIL-AP EQUAL 1 */

            if (WAREA_AUXILIAR.W_REG_BIL_AP == 1)
            {

                /*" -2812- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -2813- ELSE */
            }
            else
            {


                /*" -2814- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -2818- END-IF */
            }


            /*" -2819- IF MICROSSEGURO-AMPARO */

            if (WAREA_AUXILIAR.W_PRODUTO["MICROSSEGURO_AMPARO"])
            {

                /*" -2820- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -2822- END-IF */
            }


            /*" -2825- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -2828- ADD 1 TO W-QTD-LD-TIPO-3, W-REG-BIL-AP. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;
            WAREA_AUXILIAR.W_REG_BIL_AP.Value = WAREA_AUXILIAR.W_REG_BIL_AP + 1;

            /*" -2830- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2831- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0350-00-GERAR-REG-TP3-RD-SECTION */
        private void R0350_00_GERAR_REG_TP3_RD_SECTION()
        {
            /*" -2841- MOVE 'R0350-00-GERAR-REG-TP3-RD' TO PARAGRAFO. */
            _.Move("R0350-00-GERAR-REG-TP3-RD", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2842- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2844- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2846- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -2849- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -2852- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -2856- MOVE BILCOBER-VAL-COBERTURA-IX TO R3-VAL-COBERTURA OF REG-COBER-SASSE. */
            _.Move(BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_VAL_COBERTURA_IX, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

            /*" -2857- IF BILCOBER-COD-COBERTURA EQUAL 2000 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2000)
            {

                /*" -2860- MOVE 1 TO W-COBERTURA. */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -2861- IF BILCOBER-COD-COBERTURA EQUAL 2200 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2200)
            {

                /*" -2864- MOVE 2 TO W-COBERTURA. */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -2865- IF BILCOBER-COD-COBERTURA EQUAL 2100 */

            if (BILCOBER.DCLBILHETE_COBERTURA.BILCOBER_COD_COBERTURA == 2100)
            {

                /*" -2867- MOVE 3 TO W-COBERTURA. */
                _.Move(3, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);
            }


            /*" -2870- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE. */
            _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

            /*" -2872- ADD 1 TO W-QTD-LD-TIPO-3 */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2874- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
            _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -2875- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSAR-VIDA-SECTION */
        private void R0500_00_PROCESSAR_VIDA_SECTION()
        {
            /*" -2885- MOVE 'R0500-00-PROCESSAR-VIDA' TO PARAGRAFO. */
            _.Move("R0500-00-PROCESSAR-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2886- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2888- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2891- MOVE COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO W-SUBPRODUTO. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF, WAREA_AUXILIAR.FILLER_0.W_SUBPRODUTO);

            /*" -2893- ADD 01 TO W-LIDO-VIDA. */
            WAREA_AUXILIAR.W_LIDO_VIDA.Value = WAREA_AUXILIAR.W_LIDO_VIDA + 01;

            /*" -2895- PERFORM R0520-00-ACESSA-COBERPROPVA. */

            R0520_00_ACESSA_COBERPROPVA_SECTION();

            /*" -2897- PERFORM R0523-00-ACESSA-PROP-SASSE. */

            R0523_00_ACESSA_PROP_SASSE_SECTION();

            /*" -2898- IF NAO-TEM-COBERPROPVA */

            if (WAREA_AUXILIAR.W_TEM_COBERPROPVA["NAO_TEM_COBERPROPVA"])
            {

                /*" -2899- IF PROPFIDH-SIT-PROPOSTA EQUAL 'EMT' */

                if (PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA == "EMT")
                {

                    /*" -2900- PERFORM R0585-00-ACESSA-MOVIMENTO */

                    R0585_00_ACESSA_MOVIMENTO_SECTION();

                    /*" -2902- PERFORM R0521-00-CALL-VG0710S */

                    R0521_00_CALL_VG0710S_SECTION();

                    /*" -2905- MOVE LK-COBT-MORTE-NATURAL TO IMP-MORNATU OF DCLHIS-COBER-PROPOST */
                    _.Move(PARAMETROS.LK_COBT_MORTE_NATURAL, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);

                    /*" -2908- MOVE LK-COBT-MORTE-ACIDENTAL TO IMPMORACID OF DCLHIS-COBER-PROPOST */
                    _.Move(PARAMETROS.LK_COBT_MORTE_ACIDENTAL, COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID);

                    /*" -2911- MOVE LK-COBT-INV-PERMANENTE TO IMPINVPERM OF DCLHIS-COBER-PROPOST */
                    _.Move(PARAMETROS.LK_COBT_INV_PERMANENTE, COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM);

                    /*" -2914- MOVE LK-COBT-ASS-MEDICA TO IMPAMDS OF DCLHIS-COBER-PROPOST */
                    _.Move(PARAMETROS.LK_COBT_ASS_MEDICA, COBPRPVA.DCLHIS_COBER_PROPOST.IMPAMDS);

                    /*" -2917- MOVE LK-COBT-DIARIA-HOSPITALAR TO IMPDH OF DCLHIS-COBER-PROPOST */
                    _.Move(PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH);

                    /*" -2920- MOVE LK-COBT-DIARIA-INTERNACAO TO IMPDIT OF DCLHIS-COBER-PROPOST */
                    _.Move(PARAMETROS.LK_COBT_DIARIA_INTERNACAO, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT);

                    /*" -2921- PERFORM R0590-00-ACESSA-COBERAPOL */

                    R0590_00_ACESSA_COBERAPOL_SECTION();

                    /*" -2922- ELSE */
                }
                else
                {


                    /*" -2923- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -2924- DISPLAY '          PROBLEMAS ACESSO COBERPROPVA' */
                    _.Display($"          PROBLEMAS ACESSO COBERPROPVA");

                    /*" -2926- DISPLAY '          NUMERO DO CERTIFICADO...... ' NUM-CERTIFICADO OF DCLHIS-COBER-PROPOST */
                    _.Display($"          NUMERO DO CERTIFICADO...... {COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO}");

                    /*" -2928- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -2929- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2930- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -2931- ELSE */
                }

            }
            else
            {


                /*" -2934- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO SEGVGAP-NUM-APOLICE */
                _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE);

                /*" -2937- MOVE PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA TO SEGVGAP-COD-SUBGRUPO */
                _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_COD_SUBGRUPO);

                /*" -2939- PERFORM R0521-00-CALL-VG0710S. */

                R0521_00_CALL_VG0710S_SECTION();
            }


            /*" -2941- PERFORM R0525-00-ACESSA-APOLICE. */

            R0525_00_ACESSA_APOLICE_SECTION();

            /*" -2943- PERFORM R0527-00-OBTER-PCT-IOF. */

            R0527_00_OBTER_PCT_IOF_SECTION();

            /*" -2945- PERFORM R0530-00-ACESSAR-PROPOSTAVA. */

            R0530_00_ACESSAR_PROPOSTAVA_SECTION();

            /*" -2947- PERFORM R0560-00-OBTER-PERIPGTO. */

            R0560_00_OBTER_PERIPGTO_SECTION();

            /*" -2949- PERFORM R0570-00-GERAR-REGISTRO-TP2. */

            R0570_00_GERAR_REGISTRO_TP2_SECTION();

            /*" -2949- PERFORM R0580-00-GERAR-REGISTRO-TP3. */

            R0580_00_GERAR_REGISTRO_TP3_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0520-00-ACESSA-COBERPROPVA-SECTION */
        private void R0520_00_ACESSA_COBERPROPVA_SECTION()
        {
            /*" -2959- MOVE 'R0520-00-ACESSA-COBERPROPVA' TO PARAGRAFO. */
            _.Move("R0520-00-ACESSA-COBERPROPVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2960- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2962- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2965- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLHIS-COBER-PROPOST. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO);

            /*" -2997- PERFORM R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1 */

            R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1();

            /*" -3000- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3001- IF SQLCODE NOT EQUAL 100 AND -811 */

                if (!DB.SQLCODE.In("100", "-811"))
                {

                    /*" -3002- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -3003- DISPLAY '          ERRO SELECT COBERPROPVA' */
                    _.Display($"          ERRO SELECT COBERPROPVA");

                    /*" -3005- DISPLAY '          NUMERO DO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLHIS-COBER-PROPOST */
                    _.Display($"          NUMERO DO CERTIFICADO............ {COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO}");

                    /*" -3007- DISPLAY '          SQLCODE.......................... ' SQLCODE */
                    _.Display($"          SQLCODE.......................... {DB.SQLCODE}");

                    /*" -3008- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3009- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3010- ELSE */
                }
                else
                {


                    /*" -3011- MOVE 1 TO W-TEM-COBERPROPVA */
                    _.Move(1, WAREA_AUXILIAR.W_TEM_COBERPROPVA);

                    /*" -3012- ELSE */
                }

            }
            else
            {


                /*" -3012- MOVE 0 TO W-TEM-COBERPROPVA. */
                _.Move(0, WAREA_AUXILIAR.W_TEM_COBERPROPVA);
            }


        }

        [StopWatch]
        /*" R0520-00-ACESSA-COBERPROPVA-DB-SELECT-1 */
        public void R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1()
        {
            /*" -2997- EXEC SQL SELECT NUM_CERTIFICADO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, IMPSEGUR, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, VLPREMIO, PRMVG, PRMAP INTO :DCLHIS-COBER-PROPOST.NUM-CERTIFICADO, :DCLHIS-COBER-PROPOST.DATA-INIVIGENCIA, :DCLHIS-COBER-PROPOST.DATA-TERVIGENCIA, :DCLHIS-COBER-PROPOST.IMPSEGUR, :DCLHIS-COBER-PROPOST.IMP-MORNATU, :DCLHIS-COBER-PROPOST.IMPMORACID, :DCLHIS-COBER-PROPOST.IMPINVPERM, :DCLHIS-COBER-PROPOST.IMPAMDS, :DCLHIS-COBER-PROPOST.IMPDH, :DCLHIS-COBER-PROPOST.IMPDIT, :DCLHIS-COBER-PROPOST.VLPREMIO, :DCLHIS-COBER-PROPOST.PRMVG, :DCLHIS-COBER-PROPOST.PRMAP FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :DCLHIS-COBER-PROPOST.NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0520_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1 = new R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1.Execute(r0520_00_ACESSA_COBERPROPVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CERTIFICADO, COBPRPVA.DCLHIS_COBER_PROPOST.NUM_CERTIFICADO);
                _.Move(executed_1.DATA_INIVIGENCIA, COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA);
                _.Move(executed_1.DATA_TERVIGENCIA, COBPRPVA.DCLHIS_COBER_PROPOST.DATA_TERVIGENCIA);
                _.Move(executed_1.IMPSEGUR, COBPRPVA.DCLHIS_COBER_PROPOST.IMPSEGUR);
                _.Move(executed_1.IMP_MORNATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);
                _.Move(executed_1.IMPMORACID, COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID);
                _.Move(executed_1.IMPINVPERM, COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM);
                _.Move(executed_1.IMPAMDS, COBPRPVA.DCLHIS_COBER_PROPOST.IMPAMDS);
                _.Move(executed_1.IMPDH, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH);
                _.Move(executed_1.IMPDIT, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT);
                _.Move(executed_1.VLPREMIO, COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO);
                _.Move(executed_1.PRMVG, COBPRPVA.DCLHIS_COBER_PROPOST.PRMVG);
                _.Move(executed_1.PRMAP, COBPRPVA.DCLHIS_COBER_PROPOST.PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0520_SAIDA*/

        [StopWatch]
        /*" R0521-00-CALL-VG0710S-SECTION */
        private void R0521_00_CALL_VG0710S_SECTION()
        {
            /*" -3022- MOVE 'R0521-CALL-VG0710S' TO PARAGRAFO. */
            _.Move("R0521-CALL-VG0710S", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3023- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3025- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3027- MOVE SEGVGAP-NUM-APOLICE TO LK-APOLICE. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE, PARAMETROS.LK_APOLICE);

            /*" -3029- MOVE SEGVGAP-COD-SUBGRUPO TO LK-SUBGRUPO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_COD_SUBGRUPO, PARAMETROS.LK_SUBGRUPO);

            /*" -3051- MOVE ZEROS TO LK-IDADE LK-DATA-NASCIMENTO LK-SALARIO LK-PURO-MORTE-NATURAL LK-PURO-MORTE-ACIDENTAL LK-PURO-INV-PERMANENTE LK-PURO-ASS-MEDICA LK-PURO-DIARIA-HOSPITALAR LK-PURO-DIARIA-INTERNACAO LK-COBT-MORTE-NATURAL LK-COBT-MORTE-ACIDENTAL LK-COBT-INV-PERMANENTE LK-COBT-INV-POR-ACIDENTE LK-COBT-ASS-MEDICA LK-COBT-DIARIA-HOSPITALAR LK-COBT-DIARIA-INTERNACAO LK-PREM-MORTE-NATURAL LK-PREM-ACIDENTES-PESSOAIS LK-PREM-TOTAL LK-RETURN-CODE LK-MENSAGEM. */
            _.Move(0, PARAMETROS.LK_IDADE, PARAMETROS.LK_NASCIMENTO.LK_DATA_NASCIMENTO, PARAMETROS.LK_SALARIO, PARAMETROS.LK_PURO_MORTE_NATURAL, PARAMETROS.LK_PURO_MORTE_ACIDENTAL, PARAMETROS.LK_PURO_INV_PERMANENTE, PARAMETROS.LK_PURO_ASS_MEDICA, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR, PARAMETROS.LK_PURO_DIARIA_INTERNACAO, PARAMETROS.LK_COBT_MORTE_NATURAL, PARAMETROS.LK_COBT_MORTE_ACIDENTAL, PARAMETROS.LK_COBT_INV_PERMANENTE, PARAMETROS.LK_COBT_INV_POR_ACIDENTE, PARAMETROS.LK_COBT_ASS_MEDICA, PARAMETROS.LK_COBT_DIARIA_HOSPITALAR, PARAMETROS.LK_COBT_DIARIA_INTERNACAO, PARAMETROS.LK_PREM_MORTE_NATURAL, PARAMETROS.LK_PREM_ACIDENTES_PESSOAIS, PARAMETROS.LK_PREM_TOTAL, PARAMETROS.LK_RETURN_CODE, PARAMETROS.LK_MENSAGEM);

            /*" -3054- MOVE IMP-MORNATU OF DCLHIS-COBER-PROPOST TO LK-PURO-MORTE-NATURAL */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU, PARAMETROS.LK_PURO_MORTE_NATURAL);

            /*" -3057- MOVE IMPMORACID OF DCLHIS-COBER-PROPOST TO LK-PURO-MORTE-ACIDENTAL */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID, PARAMETROS.LK_PURO_MORTE_ACIDENTAL);

            /*" -3060- MOVE IMPINVPERM OF DCLHIS-COBER-PROPOST TO LK-PURO-INV-PERMANENTE */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM, PARAMETROS.LK_PURO_INV_PERMANENTE);

            /*" -3063- MOVE IMPAMDS OF DCLHIS-COBER-PROPOST TO LK-PURO-ASS-MEDICA */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPAMDS, PARAMETROS.LK_PURO_ASS_MEDICA);

            /*" -3066- MOVE IMPDH OF DCLHIS-COBER-PROPOST TO LK-PURO-DIARIA-HOSPITALAR */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH, PARAMETROS.LK_PURO_DIARIA_HOSPITALAR);

            /*" -3069- MOVE IMPDIT OF DCLHIS-COBER-PROPOST TO LK-PURO-DIARIA-INTERNACAO. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT, PARAMETROS.LK_PURO_DIARIA_INTERNACAO);

            /*" -3071- CALL 'VG0710S' USING PARAMETROS. */
            _.Call("VG0710S", PARAMETROS);

            /*" -3072- IF LK-RETURN-CODE NOT EQUAL ZEROS */

            if (PARAMETROS.LK_RETURN_CODE != 00)
            {

                /*" -3073- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3074- DISPLAY '          ERRO SUBROTINA VG0710S ' */
                _.Display($"          ERRO SUBROTINA VG0710S ");

                /*" -3075- DISPLAY '          MENSAGEM.............. ' LK-MENSAGEM */
                _.Display($"          MENSAGEM.............. {PARAMETROS.LK_MENSAGEM}");

                /*" -3077- DISPLAY '          CERTIFICADO........... ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          CERTIFICADO........... {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3078- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3079- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3081- END-IF */
            }


            /*" -3081- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0521_SAIDA*/

        [StopWatch]
        /*" R0523-00-ACESSA-PROP-SASSE-SECTION */
        private void R0523_00_ACESSA_PROP_SASSE_SECTION()
        {
            /*" -3091- MOVE 'R0523-ACESSA-PROP-SASSE' TO PARAGRAFO. */
            _.Move("R0523-ACESSA-PROP-SASSE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3092- MOVE 'SELECT PROPOSTA-SASSE-VIDA' TO COMANDO. */
            _.Move("SELECT PROPOSTA-SASSE-VIDA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3094- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3097- MOVE NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);

            /*" -3106- PERFORM R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1 */

            R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1();

            /*" -3110- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3111- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3112- DISPLAY '          ERRO SELECT TAB. PROPOSTA SASSE VIDA' */
                _.Display($"          ERRO SELECT TAB. PROPOSTA SASSE VIDA");

                /*" -3114- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO}");

                /*" -3116- DISPLAY '          NUMERO PROPOSTA...............  ' NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ */
                _.Display($"          NUMERO PROPOSTA...............  {PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF}");

                /*" -3118- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3119- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3119- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0523-00-ACESSA-PROP-SASSE-DB-SELECT-1 */
        public void R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1()
        {
            /*" -3106- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO INTO :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO FROM SEGUROS.PROP_SASSE_VIDA WHERE NUM_IDENTIFICACAO = :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO WITH UR END-EXEC. */

            var r0523_00_ACESSA_PROP_SASSE_DB_SELECT_1_Query1 = new R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1_Query1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
            };

            var executed_1 = R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1_Query1.Execute(r0523_00_ACESSA_PROP_SASSE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPSSVD_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);
                _.Move(executed_1.PROPSSVD_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0523_SAIDA*/

        [StopWatch]
        /*" R0525-00-ACESSA-APOLICE-SECTION */
        private void R0525_00_ACESSA_APOLICE_SECTION()
        {
            /*" -3129- MOVE 'R0525-ACESSA-APOLICE' TO PARAGRAFO. */
            _.Move("R0525-ACESSA-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3130- MOVE 'SELECT APOLICES' TO COMANDO. */
            _.Move("SELECT APOLICES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3132- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3135- MOVE PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA TO APOLICES-NUM-APOLICE OF DCLAPOLICES. */
            _.Move(PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -3141- PERFORM R0525_00_ACESSA_APOLICE_DB_SELECT_1 */

            R0525_00_ACESSA_APOLICE_DB_SELECT_1();

            /*" -3144- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3145- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3146- DISPLAY '          ERRO SELECT TAB. APOLICE' */
                _.Display($"          ERRO SELECT TAB. APOLICE");

                /*" -3148- DISPLAY '          NUMERO APOLICE........  ' APOLICES-NUM-APOLICE OF DCLAPOLICES */
                _.Display($"          NUMERO APOLICE........  {APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE}");

                /*" -3150- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3151- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3151- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0525-00-ACESSA-APOLICE-DB-SELECT-1 */
        public void R0525_00_ACESSA_APOLICE_DB_SELECT_1()
        {
            /*" -3141- EXEC SQL SELECT RAMO_EMISSOR INTO :DCLAPOLICES.APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :DCLAPOLICES.APOLICES-NUM-APOLICE WITH UR END-EXEC. */

            var r0525_00_ACESSA_APOLICE_DB_SELECT_1_Query1 = new R0525_00_ACESSA_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0525_00_ACESSA_APOLICE_DB_SELECT_1_Query1.Execute(r0525_00_ACESSA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0525_SAIDA*/

        [StopWatch]
        /*" R0527-00-OBTER-PCT-IOF-SECTION */
        private void R0527_00_OBTER_PCT_IOF_SECTION()
        {
            /*" -3161- MOVE 'R0527-OBTER-PCT-IOF' TO PARAGRAFO. */
            _.Move("R0527-OBTER-PCT-IOF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3162- MOVE 'SELECT RAMOIND' TO COMANDO. */
            _.Move("SELECT RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3164- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3167- MOVE APOLICES-RAMO-EMISSOR OF DCLAPOLICES TO RAMOCOMP-RAMO-EMISSOR OF DCLRAMO-COMPLEMENTAR. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR);

            /*" -3170- MOVE DATA-INIVIGENCIA OF DCLHIS-COBER-PROPOST TO RAMOCOMP-DATA-INIVIGENCIA OF DCLRAMO-COMPLEMENTAR. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA);

            /*" -3181- PERFORM R0527_00_OBTER_PCT_IOF_DB_SELECT_1 */

            R0527_00_OBTER_PCT_IOF_DB_SELECT_1();

            /*" -3184- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3185- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3186- DISPLAY '          ERRO SELECT TAB. RAMOIND' */
                _.Display($"          ERRO SELECT TAB. RAMOIND");

                /*" -3188- DISPLAY '          CODIGO DO RAMO........  ' RAMOCOMP-RAMO-EMISSOR OF DCLRAMO-COMPLEMENTAR */
                _.Display($"          CODIGO DO RAMO........  {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR}");

                /*" -3190- DISPLAY '          DATA INICIO VIGENCIA..  ' RAMOCOMP-DATA-INIVIGENCIA OF DCLRAMO-COMPLEMENTAR */
                _.Display($"          DATA INICIO VIGENCIA..  {RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA}");

                /*" -3192- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3193- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3195- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3196- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO OF DCLRAMO-COMPLEMENTAR / 100) + 1. */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

        }

        [StopWatch]
        /*" R0527-00-OBTER-PCT-IOF-DB-SELECT-1 */
        public void R0527_00_OBTER_PCT_IOF_DB_SELECT_1()
        {
            /*" -3181- EXEC SQL SELECT PCT_IOCC_RAMO INTO :DCLRAMO-COMPLEMENTAR.RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :DCLRAMO-COMPLEMENTAR.RAMOCOMP-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :DCLRAMO-COMPLEMENTAR.RAMOCOMP-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :DCLRAMO-COMPLEMENTAR.RAMOCOMP-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1 = new R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1()
            {
                RAMOCOMP_DATA_INIVIGENCIA = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.ToString(),
                RAMOCOMP_RAMO_EMISSOR = RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1.Execute(r0527_00_OBTER_PCT_IOF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0527_SAIDA*/

        [StopWatch]
        /*" R0530-00-ACESSAR-PROPOSTAVA-SECTION */
        private void R0530_00_ACESSAR_PROPOSTAVA_SECTION()
        {
            /*" -3206- MOVE 'R0530-ACESSAR-PROPOSTVA' TO PARAGRAFO. */
            _.Move("R0530-ACESSAR-PROPOSTVA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3207- MOVE 'SELECT PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT PROPOSTAVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3209- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3212- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO NUM-CERTIFICADO OF DCLPROPOSTAS-VA. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO);

            /*" -3226- PERFORM R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1 */

            R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1();

            /*" -3229- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3230- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3231- DISPLAY '          ERRO SELECT TAB. PROPOSTAVA' */
                _.Display($"          ERRO SELECT TAB. PROPOSTAVA");

                /*" -3233- DISPLAY '          CERTIFICADO...........  ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          CERTIFICADO...........  {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -3235- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3236- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3236- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0530-00-ACESSAR-PROPOSTAVA-DB-SELECT-1 */
        public void R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1()
        {
            /*" -3226- EXEC SQL SELECT COD_PRODUTO , DATA_MOVIMENTO, IDE_SEXO , COD_OPERACAO , DATA_QUITACAO INTO :DCLPROPOSTAS-VA.COD-PRODUTO , :DCLPROPOSTAS-VA.DATA-MOVIMENTO, :DCLPROPOSTAS-VA.IDE-SEXO , :DCLPROPOSTAS-VA.COD-OPERACAO , :DCLPROPOSTAS-VA.DATA-QUITACAO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1 = new R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1.Execute(r0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PRODUTO, PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO);
                _.Move(executed_1.DATA_MOVIMENTO, PROPVA.DCLPROPOSTAS_VA.DATA_MOVIMENTO);
                _.Move(executed_1.IDE_SEXO, PROPVA.DCLPROPOSTAS_VA.IDE_SEXO);
                _.Move(executed_1.COD_OPERACAO, PROPVA.DCLPROPOSTAS_VA.COD_OPERACAO);
                _.Move(executed_1.DATA_QUITACAO, PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0530_SAIDA*/

        [StopWatch]
        /*" R0560-00-OBTER-PERIPGTO-SECTION */
        private void R0560_00_OBTER_PERIPGTO_SECTION()
        {
            /*" -3245- MOVE 'R560-00-OBTER-PERIPGTO' TO PARAGRAFO. */
            _.Move("R560-00-OBTER-PERIPGTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3247- MOVE 'SELECT OPCAO-PAG-VIDAZUL' TO COMANDO. */
            _.Move("SELECT OPCAO-PAG-VIDAZUL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3254- PERFORM R0560_00_OBTER_PERIPGTO_DB_SELECT_1 */

            R0560_00_OBTER_PERIPGTO_DB_SELECT_1();

            /*" -3257- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3258- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3259- DISPLAY '          ERRO SELECT TAB. OPCAO-PAG-VIDAZUL' */
                _.Display($"          ERRO SELECT TAB. OPCAO-PAG-VIDAZUL");

                /*" -3261- DISPLAY '          NUM PROPOSTA............ ' NUM-CERTIFICADO OF DCLPROPOSTAS-VA */
                _.Display($"          NUM PROPOSTA............ {PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO}");

                /*" -3263- DISPLAY '          SQLCODE................. ' SQLCODE */
                _.Display($"          SQLCODE................. {DB.SQLCODE}");

                /*" -3264- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3265- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0560-00-OBTER-PERIPGTO-DB-SELECT-1 */
        public void R0560_00_OBTER_PERIPGTO_DB_SELECT_1()
        {
            /*" -3254- EXEC SQL SELECT PERI_PAGAMENTO INTO :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :DCLPROPOSTAS-VA.NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1 = new R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = PROPVA.DCLPROPOSTAS_VA.NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1.Execute(r0560_00_OBTER_PERIPGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0560_SAIDA*/

        [StopWatch]
        /*" R0570-00-GERAR-REGISTRO-TP2-SECTION */
        private void R0570_00_GERAR_REGISTRO_TP2_SECTION()
        {
            /*" -3274- MOVE 'R0570-00-GERAR-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0570-00-GERAR-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3275- MOVE 'WRITE REG-APOL-SASSE' TO COMANDO. */
            _.Move("WRITE REG-APOL-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3277- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3279- MOVE SPACES TO REG-APOL-SASSE. */
            _.Move("", LBFCT016.REG_APOL_SASSE);

            /*" -3282- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE. */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -3286- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R2-NUM-PROPOSTA OF REG-APOL-SASSE, R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -3288- MOVE DATA-INIVIGENCIA OF DCLHIS-COBER-PROPOST TO W-DATA-SQL. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3290- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3292- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3294- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3297- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -3299- IF ORIGEM-PROPOSTA OF DCLPROPOSTA-FIDELIZ EQUAL 1009 OR 1010 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.ORIGEM_PROPOSTA.In("1009", "1010"))
            {

                /*" -3301- MOVE DATA-QUITACAO OF DCLPROPOSTAS-VA TO W-DATA-SQL */
                _.Move(PROPVA.DCLPROPOSTAS_VA.DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

                /*" -3303- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

                /*" -3305- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

                /*" -3307- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

                /*" -3309- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

                /*" -3311- END-IF */
            }


            /*" -3313- MOVE DATA-TERVIGENCIA OF DCLHIS-COBER-PROPOST TO W-DATA-SQL. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3315- MOVE W-DIA-SQL OF W-DATA-SQL1 TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3317- MOVE W-MES-SQL OF W-DATA-SQL1 TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3320- MOVE W-ANO-SQL OF W-DATA-SQL1 TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3323- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -3327- IF R1-SIT-PROPOSTA OF REG-STA-PROPOSTA EQUAL 'EMT' */

            if (LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA == "EMT")
            {

                /*" -3328- IF OPCPAGVI-PERI-PAGAMENTO EQUAL ZEROS */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO == 00)
                {

                    /*" -3329- PERFORM R0585-00-ACESSA-MOVIMENTO */

                    R0585_00_ACESSA_MOVIMENTO_SECTION();

                    /*" -3330- PERFORM R0590-00-ACESSA-COBERAPOL */

                    R0590_00_ACESSA_COBERAPOL_SECTION();

                    /*" -3332- MOVE APOLICOB-DATA-TERVIGENCIA OF DCLAPOLICE-COBERTURAS TO W-DATA-SQL */
                    _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -3333- ELSE */
                }
                else
                {


                    /*" -3334- MOVE WDTA-TERVG-CALC TO W-DATA-SQL */
                    _.Move(WAREA_AUXILIAR.WDTA_TERVG_CALC, WAREA_AUXILIAR.W_DATA_SQL);

                    /*" -3336- END-IF */
                }


                /*" -3337- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

                /*" -3338- MOVE W-MES-SQL TO W-MES-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

                /*" -3339- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
                _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

                /*" -3341- MOVE W-DATA-TRABALHO TO R2-DTTERVIG OF REG-APOL-SASSE. */
                _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);
            }


            /*" -3344- MOVE VLPREMIO OF DCLHIS-COBER-PROPOST TO R2-VAL-PREMIO OF REG-APOL-SASSE. */
            _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -3347- COMPUTE W-PRM-LIQ = R2-VAL-PREMIO OF REG-APOL-SASSE / W-IND-IOF. */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO / WAREA_AUXILIAR.W_IND_IOF;

            /*" -3350- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - W-PRM-LIQ. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -3354- COMPUTE R2-VAL-PREMIO OF REG-APOL-SASSE = R2-VAL-PREMIO OF REG-APOL-SASSE - R2-VAL-IOF OF REG-APOL-SASSE. */
            LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO.Value = LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO - LBFCT016.REG_APOL_SASSE.R2_VAL_IOF;

            /*" -3356- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -3358- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

            /*" -3359- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R2-NUM-PROPOSTA OF REG-APOL-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-GERAR-REGISTRO-TP3-SECTION */
        private void R0580_00_GERAR_REGISTRO_TP3_SECTION()
        {
            /*" -3369- MOVE 'R0580-00-GERAR-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0580-00-GERAR-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3370- MOVE 'WRITE REG-COBER-SASSE' TO COMANDO. */
            _.Move("WRITE REG-COBER-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3372- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3374- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -3377- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -3380- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -3381- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
            {

                /*" -3383- MOVE IMP-MORNATU OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3384- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -3386- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3388- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -3390- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3391- IF IMPMORACID OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID > 00)
            {

                /*" -3393- MOVE IMPMORACID OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3394- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -3396- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3398- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -3402- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3403- IF COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ = 77 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 77)
            {

                /*" -3404- GO TO R0580-99 */

                R0580_99(); //GOTO
                return;

                /*" -3406- END-IF */
            }


            /*" -3407- IF IMPINVPERM OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM > 00)
            {

                /*" -3409- MOVE IMPINVPERM OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3410- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -3412- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3414- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -3416- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3417- IF LK-COBT-INV-POR-ACIDENTE GREATER ZEROS */

            if (PARAMETROS.LK_COBT_INV_POR_ACIDENTE > 00)
            {

                /*" -3419- MOVE LK-COBT-INV-POR-ACIDENTE TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(PARAMETROS.LK_COBT_INV_POR_ACIDENTE, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3420- MOVE 4 TO W-COBERTURA */
                _.Move(4, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -3422- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3424- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -3428- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3429- IF COD-PRODUTO OF DCLPROPOSTAS-VA EQUAL 9707 OR 9309 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO.In("9707", "9309"))
            {

                /*" -3430- IF IDE-SEXO OF DCLPROPOSTAS-VA EQUAL 'M' */

                if (PROPVA.DCLPROPOSTAS_VA.IDE_SEXO == "M")
                {

                    /*" -3432- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

                    if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
                    {

                        /*" -3434- COMPUTE R3-VAL-COBERTURA OF REG-COBER-SASSE = IMP-MORNATU OF DCLHIS-COBER-PROPOST / 2 */
                        LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA.Value = COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU / 2f;

                        /*" -3435- MOVE 5 TO W-COBERTURA */
                        _.Move(5, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                        /*" -3437- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                        _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                        /*" -3438- ADD 1 TO W-QTD-LD-TIPO-3 */
                        WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                        /*" -3442- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                        _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                        MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                    }

                }

            }


            /*" -3443- IF COD-PRODUTO OF DCLPROPOSTAS-VA EQUAL 9705 */

            if (PROPVA.DCLPROPOSTAS_VA.COD_PRODUTO == 9705)
            {

                /*" -3445- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

                if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
                {

                    /*" -3447- COMPUTE R3-VAL-COBERTURA OF REG-COBER-SASSE = IMP-MORNATU OF DCLHIS-COBER-PROPOST / 2 */
                    LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA.Value = COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU / 2f;

                    /*" -3448- MOVE 5 TO W-COBERTURA */
                    _.Move(5, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                    /*" -3450- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                    _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                    /*" -3451- ADD 1 TO W-QTD-LD-TIPO-3 */
                    WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                    /*" -3453- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                    _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                    MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
                }

            }


            /*" -3454- IF IMPDH OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH > 00)
            {

                /*" -3456- MOVE IMPDH OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3457- MOVE 6 TO W-COBERTURA */
                _.Move(6, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -3459- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3461- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -3463- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3464- IF IMPDIT OF DCLHIS-COBER-PROPOST GREATER ZEROS */

            if (COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT > 00)
            {

                /*" -3466- MOVE IMPDIT OF DCLHIS-COBER-PROPOST TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3467- MOVE 7 TO W-COBERTURA */
                _.Move(7, WAREA_AUXILIAR.FILLER_0.W_COBERTURA);

                /*" -3469- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3471- ADD 1 TO W-QTD-LD-TIPO-3 */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

                /*" -3471- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -0- FLUXCONTROL_PERFORM R0580_99 */

            R0580_99();

        }

        [StopWatch]
        /*" R0580-99 */
        private void R0580_99(bool isPerform = false)
        {
            /*" -3476- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0585-00-ACESSA-MOVIMENTO-SECTION */
        private void R0585_00_ACESSA_MOVIMENTO_SECTION()
        {
            /*" -3486- MOVE 'R0585-00-ACESSA-MOVIMENTO-VGAP' TO PARAGRAFO. */
            _.Move("R0585-00-ACESSA-MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3487- MOVE 'SELECT MOVIMENTO-VGAP' TO COMANDO. */
            _.Move("SELECT MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3489- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3490- MOVE SEGVGAP-NUM-APOLICE TO MOVVGAP-NUM-APOLICE. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE);

            /*" -3491- MOVE SEGVGAP-COD-SUBGRUPO TO MOVVGAP-COD-SUBGRUPO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_COD_SUBGRUPO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO);

            /*" -3493- MOVE SEGVGAP-NUM-CERTIFICADO TO MOVVGAP-NUM-CERTIFICADO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO);

            /*" -3584- PERFORM R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1 */

            R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1();

            /*" -3587- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3588- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3589- PERFORM R0586-00-ACESSA-MOVIMENTO */

                    R0586_00_ACESSA_MOVIMENTO_SECTION();

                    /*" -3590- ELSE */
                }
                else
                {


                    /*" -3591- DISPLAY 'PF0605B - FIM ANORMAL' */
                    _.Display($"PF0605B - FIM ANORMAL");

                    /*" -3592- DISPLAY '          ERRO SELECT MOVIMENTO-VGAP' */
                    _.Display($"          ERRO SELECT MOVIMENTO-VGAP");

                    /*" -3594- DISPLAY '          CERTIFICADO........... ' MOVVGAP-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO........... {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                    /*" -3596- DISPLAY '          SQLCODE............... ' SQLCODE */
                    _.Display($"          SQLCODE............... {DB.SQLCODE}");

                    /*" -3597- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3598- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -3599- END-IF */
                }


                /*" -3601- END-IF. */
            }


            /*" -3604- MOVE MOVVGAP-IMP-MORNATU-ATU TO IMP-MORNATU OF DCLHIS-COBER-PROPOST. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU);

            /*" -3607- MOVE MOVVGAP-IMP-MORACID-ATU TO IMPMORACID OF DCLHIS-COBER-PROPOST. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMPMORACID);

            /*" -3610- MOVE MOVVGAP-IMP-INVPERM-ATU TO IMPINVPERM OF DCLHIS-COBER-PROPOST. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMPINVPERM);

            /*" -3613- MOVE MOVVGAP-IMP-AMDS-ATU TO IMPAMDS OF DCLHIS-COBER-PROPOST. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMPAMDS);

            /*" -3616- MOVE MOVVGAP-IMP-DH-ATU TO IMPDH OF DCLHIS-COBER-PROPOST. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDH);

            /*" -3619- MOVE MOVVGAP-IMP-DIT-ATU TO IMPDIT OF DCLHIS-COBER-PROPOST. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU, COBPRPVA.DCLHIS_COBER_PROPOST.IMPDIT);

            /*" -3621- COMPUTE VLPREMIO OF DCLHIS-COBER-PROPOST = MOVVGAP-PRM-VG-ATU + MOVVGAP-PRM-AP-ATU. */
            COBPRPVA.DCLHIS_COBER_PROPOST.VLPREMIO.Value = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ATU + MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ATU;

        }

        [StopWatch]
        /*" R0585-00-ACESSA-MOVIMENTO-DB-SELECT-1 */
        public void R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1()
        {
            /*" -3584- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , IDE_SEXO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , DATA_REFERENCIA , DATA_MOVIMENTO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO INTO :MOVVGAP-NUM-APOLICE , :MOVVGAP-COD-SUBGRUPO , :MOVVGAP-COD-FONTE , :MOVVGAP-NUM-PROPOSTA , :MOVVGAP-TIPO-SEGURADO , :MOVVGAP-NUM-CERTIFICADO , :MOVVGAP-DAC-CERTIFICADO , :MOVVGAP-IDE-SEXO , :MOVVGAP-PCT-CONJUGE-VG , :MOVVGAP-PCT-CONJUGE-AP , :MOVVGAP-QTD-SAL-MORNATU , :MOVVGAP-QTD-SAL-MORACID , :MOVVGAP-QTD-SAL-INVPERM , :MOVVGAP-TAXA-AP-MORACID , :MOVVGAP-TAXA-AP-INVPERM , :MOVVGAP-TAXA-AP-AMDS , :MOVVGAP-TAXA-AP-DH , :MOVVGAP-TAXA-AP-DIT , :MOVVGAP-TAXA-VG , :MOVVGAP-IMP-MORNATU-ANT , :MOVVGAP-IMP-MORNATU-ATU , :MOVVGAP-IMP-MORACID-ANT , :MOVVGAP-IMP-MORACID-ATU , :MOVVGAP-IMP-INVPERM-ANT , :MOVVGAP-IMP-INVPERM-ATU , :MOVVGAP-IMP-AMDS-ANT , :MOVVGAP-IMP-AMDS-ATU , :MOVVGAP-IMP-DH-ANT , :MOVVGAP-IMP-DH-ATU , :MOVVGAP-IMP-DIT-ANT , :MOVVGAP-IMP-DIT-ATU , :MOVVGAP-PRM-VG-ANT , :MOVVGAP-PRM-VG-ATU , :MOVVGAP-PRM-AP-ANT , :MOVVGAP-PRM-AP-ATU , :MOVVGAP-COD-OPERACAO , :MOVVGAP-DATA-OPERACAO , :MOVVGAP-DATA-REFERENCIA , :MOVVGAP-DATA-MOVIMENTO , :MOVVGAP-COD-SUBGRUPO-TRANS , :MOVVGAP-SIT-REGISTRO , :MOVVGAP-COD-USUARIO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_APOLICE = :MOVVGAP-NUM-APOLICE AND COD_SUBGRUPO = :MOVVGAP-COD-SUBGRUPO AND NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 = new R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1()
            {
                MOVVGAP_NUM_CERTIFICADO = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO.ToString(),
                MOVVGAP_COD_SUBGRUPO = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO.ToString(),
                MOVVGAP_NUM_APOLICE = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1.Execute(r0585_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVVGAP_NUM_APOLICE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE);
                _.Move(executed_1.MOVVGAP_COD_SUBGRUPO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO);
                _.Move(executed_1.MOVVGAP_COD_FONTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_FONTE);
                _.Move(executed_1.MOVVGAP_NUM_PROPOSTA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA);
                _.Move(executed_1.MOVVGAP_TIPO_SEGURADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_SEGURADO);
                _.Move(executed_1.MOVVGAP_NUM_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO);
                _.Move(executed_1.MOVVGAP_DAC_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_CERTIFICADO);
                _.Move(executed_1.MOVVGAP_IDE_SEXO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IDE_SEXO);
                _.Move(executed_1.MOVVGAP_PCT_CONJUGE_VG, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_VG);
                _.Move(executed_1.MOVVGAP_PCT_CONJUGE_AP, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_AP);
                _.Move(executed_1.MOVVGAP_QTD_SAL_MORNATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORNATU);
                _.Move(executed_1.MOVVGAP_QTD_SAL_MORACID, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORACID);
                _.Move(executed_1.MOVVGAP_QTD_SAL_INVPERM, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_INVPERM);
                _.Move(executed_1.MOVVGAP_TAXA_AP_MORACID, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_MORACID);
                _.Move(executed_1.MOVVGAP_TAXA_AP_INVPERM, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_INVPERM);
                _.Move(executed_1.MOVVGAP_TAXA_AP_AMDS, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_AMDS);
                _.Move(executed_1.MOVVGAP_TAXA_AP_DH, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DH);
                _.Move(executed_1.MOVVGAP_TAXA_AP_DIT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DIT);
                _.Move(executed_1.MOVVGAP_TAXA_VG, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_VG);
                _.Move(executed_1.MOVVGAP_IMP_MORNATU_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ANT);
                _.Move(executed_1.MOVVGAP_IMP_MORNATU_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU);
                _.Move(executed_1.MOVVGAP_IMP_MORACID_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ANT);
                _.Move(executed_1.MOVVGAP_IMP_MORACID_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU);
                _.Move(executed_1.MOVVGAP_IMP_INVPERM_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ANT);
                _.Move(executed_1.MOVVGAP_IMP_INVPERM_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU);
                _.Move(executed_1.MOVVGAP_IMP_AMDS_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ANT);
                _.Move(executed_1.MOVVGAP_IMP_AMDS_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU);
                _.Move(executed_1.MOVVGAP_IMP_DH_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ANT);
                _.Move(executed_1.MOVVGAP_IMP_DH_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU);
                _.Move(executed_1.MOVVGAP_IMP_DIT_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ANT);
                _.Move(executed_1.MOVVGAP_IMP_DIT_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU);
                _.Move(executed_1.MOVVGAP_PRM_VG_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ANT);
                _.Move(executed_1.MOVVGAP_PRM_VG_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ATU);
                _.Move(executed_1.MOVVGAP_PRM_AP_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ANT);
                _.Move(executed_1.MOVVGAP_PRM_AP_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ATU);
                _.Move(executed_1.MOVVGAP_COD_OPERACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO);
                _.Move(executed_1.MOVVGAP_DATA_OPERACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_OPERACAO);
                _.Move(executed_1.MOVVGAP_DATA_REFERENCIA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_REFERENCIA);
                _.Move(executed_1.MOVVGAP_DATA_MOVIMENTO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_MOVIMENTO);
                _.Move(executed_1.MOVVGAP_COD_SUBGRUPO_TRANS, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO_TRANS);
                _.Move(executed_1.MOVVGAP_SIT_REGISTRO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_SIT_REGISTRO);
                _.Move(executed_1.MOVVGAP_COD_USUARIO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0585_SAIDA*/

        [StopWatch]
        /*" R0586-00-ACESSA-MOVIMENTO-SECTION */
        private void R0586_00_ACESSA_MOVIMENTO_SECTION()
        {
            /*" -3631- MOVE 'R0586-00-ACESSA-MOVIMENTO-VGAP' TO PARAGRAFO. */
            _.Move("R0586-00-ACESSA-MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3633- MOVE 'SELECT MOVIMENTO-VGAP' TO COMANDO. */
            _.Move("SELECT MOVIMENTO-VGAP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3634- MOVE SEGVGAP-NUM-APOLICE TO MOVVGAP-NUM-APOLICE. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_APOLICE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE);

            /*" -3635- MOVE SEGVGAP-COD-SUBGRUPO TO MOVVGAP-COD-SUBGRUPO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_COD_SUBGRUPO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO);

            /*" -3637- MOVE SEGVGAP-NUM-CERTIFICADO TO MOVVGAP-NUM-CERTIFICADO. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO);

            /*" -3726- PERFORM R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1 */

            R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1();

            /*" -3729- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3730- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3731- DISPLAY '          ERRO SELECT MOVIMENTO-VGAP' */
                _.Display($"          ERRO SELECT MOVIMENTO-VGAP");

                /*" -3733- DISPLAY '          CERTIFICADO........... ' MOVVGAP-NUM-CERTIFICADO */
                _.Display($"          CERTIFICADO........... {MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO}");

                /*" -3735- DISPLAY '          SQLCODE............... ' SQLCODE */
                _.Display($"          SQLCODE............... {DB.SQLCODE}");

                /*" -3736- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3737- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3738- END-IF. */
            }


        }

        [StopWatch]
        /*" R0586-00-ACESSA-MOVIMENTO-DB-SELECT-1 */
        public void R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1()
        {
            /*" -3726- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , IDE_SEXO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , DATA_REFERENCIA , DATA_MOVIMENTO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO INTO :MOVVGAP-NUM-APOLICE , :MOVVGAP-COD-SUBGRUPO , :MOVVGAP-COD-FONTE , :MOVVGAP-NUM-PROPOSTA , :MOVVGAP-TIPO-SEGURADO , :MOVVGAP-NUM-CERTIFICADO , :MOVVGAP-DAC-CERTIFICADO , :MOVVGAP-IDE-SEXO , :MOVVGAP-PCT-CONJUGE-VG , :MOVVGAP-PCT-CONJUGE-AP , :MOVVGAP-QTD-SAL-MORNATU , :MOVVGAP-QTD-SAL-MORACID , :MOVVGAP-QTD-SAL-INVPERM , :MOVVGAP-TAXA-AP-MORACID , :MOVVGAP-TAXA-AP-INVPERM , :MOVVGAP-TAXA-AP-AMDS , :MOVVGAP-TAXA-AP-DH , :MOVVGAP-TAXA-AP-DIT , :MOVVGAP-TAXA-VG , :MOVVGAP-IMP-MORNATU-ANT , :MOVVGAP-IMP-MORNATU-ATU , :MOVVGAP-IMP-MORACID-ANT , :MOVVGAP-IMP-MORACID-ATU , :MOVVGAP-IMP-INVPERM-ANT , :MOVVGAP-IMP-INVPERM-ATU , :MOVVGAP-IMP-AMDS-ANT , :MOVVGAP-IMP-AMDS-ATU , :MOVVGAP-IMP-DH-ANT , :MOVVGAP-IMP-DH-ATU , :MOVVGAP-IMP-DIT-ANT , :MOVVGAP-IMP-DIT-ATU , :MOVVGAP-PRM-VG-ANT , :MOVVGAP-PRM-VG-ATU , :MOVVGAP-PRM-AP-ANT , :MOVVGAP-PRM-AP-ATU , :MOVVGAP-COD-OPERACAO , :MOVVGAP-DATA-OPERACAO , :MOVVGAP-DATA-REFERENCIA , :MOVVGAP-DATA-MOVIMENTO , :MOVVGAP-COD-SUBGRUPO-TRANS , :MOVVGAP-SIT-REGISTRO , :MOVVGAP-COD-USUARIO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :MOVVGAP-NUM-CERTIFICADO AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0586_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1 = new R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1()
            {
                MOVVGAP_NUM_CERTIFICADO = MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1.Execute(r0586_00_ACESSA_MOVIMENTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVVGAP_NUM_APOLICE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE);
                _.Move(executed_1.MOVVGAP_COD_SUBGRUPO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO);
                _.Move(executed_1.MOVVGAP_COD_FONTE, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_FONTE);
                _.Move(executed_1.MOVVGAP_NUM_PROPOSTA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_PROPOSTA);
                _.Move(executed_1.MOVVGAP_TIPO_SEGURADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TIPO_SEGURADO);
                _.Move(executed_1.MOVVGAP_NUM_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_CERTIFICADO);
                _.Move(executed_1.MOVVGAP_DAC_CERTIFICADO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DAC_CERTIFICADO);
                _.Move(executed_1.MOVVGAP_IDE_SEXO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IDE_SEXO);
                _.Move(executed_1.MOVVGAP_PCT_CONJUGE_VG, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_VG);
                _.Move(executed_1.MOVVGAP_PCT_CONJUGE_AP, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PCT_CONJUGE_AP);
                _.Move(executed_1.MOVVGAP_QTD_SAL_MORNATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORNATU);
                _.Move(executed_1.MOVVGAP_QTD_SAL_MORACID, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_MORACID);
                _.Move(executed_1.MOVVGAP_QTD_SAL_INVPERM, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_QTD_SAL_INVPERM);
                _.Move(executed_1.MOVVGAP_TAXA_AP_MORACID, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_MORACID);
                _.Move(executed_1.MOVVGAP_TAXA_AP_INVPERM, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_INVPERM);
                _.Move(executed_1.MOVVGAP_TAXA_AP_AMDS, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_AMDS);
                _.Move(executed_1.MOVVGAP_TAXA_AP_DH, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DH);
                _.Move(executed_1.MOVVGAP_TAXA_AP_DIT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_AP_DIT);
                _.Move(executed_1.MOVVGAP_TAXA_VG, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_TAXA_VG);
                _.Move(executed_1.MOVVGAP_IMP_MORNATU_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ANT);
                _.Move(executed_1.MOVVGAP_IMP_MORNATU_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORNATU_ATU);
                _.Move(executed_1.MOVVGAP_IMP_MORACID_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ANT);
                _.Move(executed_1.MOVVGAP_IMP_MORACID_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_MORACID_ATU);
                _.Move(executed_1.MOVVGAP_IMP_INVPERM_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ANT);
                _.Move(executed_1.MOVVGAP_IMP_INVPERM_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_INVPERM_ATU);
                _.Move(executed_1.MOVVGAP_IMP_AMDS_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ANT);
                _.Move(executed_1.MOVVGAP_IMP_AMDS_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_AMDS_ATU);
                _.Move(executed_1.MOVVGAP_IMP_DH_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ANT);
                _.Move(executed_1.MOVVGAP_IMP_DH_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DH_ATU);
                _.Move(executed_1.MOVVGAP_IMP_DIT_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ANT);
                _.Move(executed_1.MOVVGAP_IMP_DIT_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_IMP_DIT_ATU);
                _.Move(executed_1.MOVVGAP_PRM_VG_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ANT);
                _.Move(executed_1.MOVVGAP_PRM_VG_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_VG_ATU);
                _.Move(executed_1.MOVVGAP_PRM_AP_ANT, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ANT);
                _.Move(executed_1.MOVVGAP_PRM_AP_ATU, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_PRM_AP_ATU);
                _.Move(executed_1.MOVVGAP_COD_OPERACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_OPERACAO);
                _.Move(executed_1.MOVVGAP_DATA_OPERACAO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_OPERACAO);
                _.Move(executed_1.MOVVGAP_DATA_REFERENCIA, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_REFERENCIA);
                _.Move(executed_1.MOVVGAP_DATA_MOVIMENTO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_MOVIMENTO);
                _.Move(executed_1.MOVVGAP_COD_SUBGRUPO_TRANS, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_SUBGRUPO_TRANS);
                _.Move(executed_1.MOVVGAP_SIT_REGISTRO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_SIT_REGISTRO);
                _.Move(executed_1.MOVVGAP_COD_USUARIO, MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0586_SAIDA*/

        [StopWatch]
        /*" R0590-00-ACESSA-COBERAPOL-SECTION */
        private void R0590_00_ACESSA_COBERAPOL_SECTION()
        {
            /*" -3747- MOVE 'R0590-ACESSA-COBERAPOL' TO PARAGRAFO. */
            _.Move("R0590-ACESSA-COBERAPOL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3748- MOVE 'SELECT COBERAPOL' TO COMANDO. */
            _.Move("SELECT COBERAPOL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3750- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3753- MOVE MOVVGAP-NUM-APOLICE TO APOLICOB-NUM-APOLICE OF DCLAPOLICE-COBERTURAS. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);

            /*" -3756- MOVE ZEROS TO APOLICOB-NUM-ENDOSSO OF DCLAPOLICE-COBERTURAS. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);

            /*" -3759- MOVE SEGVGAP-NUM-ITEM TO APOLICOB-NUM-ITEM OF DCLAPOLICE-COBERTURAS. */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);

            /*" -3762- MOVE MOVVGAP-DATA-MOVIMENTO TO APOLICOB-DATA-INIVIGENCIA OF DCLAPOLICE-COBERTURAS. */
            _.Move(MOVVGAP.DCLMOVIMENTO_VGAP.MOVVGAP_DATA_MOVIMENTO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);

            /*" -3763- IF COD-PRODUTO-SIVPF = 77 */

            if (PROPFID.DCLPROPOSTA_FIDELIZ.COD_PRODUTO_SIVPF == 77)
            {

                /*" -3765- MOVE 77 TO APOLICOB-RAMO-COBERTURA OF DCLAPOLICE-COBERTURAS */
                _.Move(77, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

                /*" -3767- MOVE 11 TO APOLICOB-COD-COBERTURA OF DCLAPOLICE-COBERTURAS */
                _.Move(11, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

                /*" -3768- ELSE */
            }
            else
            {


                /*" -3769- IF IMP-MORNATU OF DCLHIS-COBER-PROPOST GREATER ZEROS */

                if (COBPRPVA.DCLHIS_COBER_PROPOST.IMP_MORNATU > 00)
                {

                    /*" -3771- MOVE 93 TO APOLICOB-RAMO-COBERTURA OF DCLAPOLICE-COBERTURAS */
                    _.Move(93, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

                    /*" -3773- MOVE 11 TO APOLICOB-COD-COBERTURA OF DCLAPOLICE-COBERTURAS */
                    _.Move(11, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);

                    /*" -3774- ELSE */
                }
                else
                {


                    /*" -3776- MOVE 81 TO APOLICOB-RAMO-COBERTURA OF DCLAPOLICE-COBERTURAS */
                    _.Move(81, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);

                    /*" -3779- MOVE 01 TO APOLICOB-COD-COBERTURA OF DCLAPOLICE-COBERTURAS. */
                    _.Move(01, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                }

            }


            /*" -3808- PERFORM R0590_00_ACESSA_COBERAPOL_DB_SELECT_1 */

            R0590_00_ACESSA_COBERAPOL_DB_SELECT_1();

            /*" -3811- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3812- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -3813- DISPLAY '          ERRO SELECT TAB. COBERAPOL' */
                _.Display($"          ERRO SELECT TAB. COBERAPOL");

                /*" -3815- DISPLAY '          NUMERO APOLICE........  ' APOLICOB-NUM-APOLICE OF DCLAPOLICE-COBERTURAS */
                _.Display($"          NUMERO APOLICE........  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -3817- DISPLAY '          ITEM..................  ' APOLICOB-NUM-ITEM OF DCLAPOLICE-COBERTURAS */
                _.Display($"          ITEM..................  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                /*" -3819- DISPLAY '          RAMO..................  ' APOLICOB-RAMO-COBERTURA OF DCLAPOLICE-COBERTURAS */
                _.Display($"          RAMO..................  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -3821- DISPLAY '          COBERTURA.............  ' APOLICOB-COD-COBERTURA OF DCLAPOLICE-COBERTURAS */
                _.Display($"          COBERTURA.............  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -3823- DISPLAY '          DT.INIVIGENCIA........  ' APOLICOB-DATA-INIVIGENCIA OF DCLAPOLICE-COBERTURAS */
                _.Display($"          DT.INIVIGENCIA........  {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA}");

                /*" -3825- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3826- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3828- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3831- MOVE APOLICOB-DATA-INIVIGENCIA OF DCLAPOLICE-COBERTURAS TO DATA-INIVIGENCIA OF DCLHIS-COBER-PROPOST. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA, COBPRPVA.DCLHIS_COBER_PROPOST.DATA_INIVIGENCIA);

            /*" -3832- MOVE APOLICOB-DATA-TERVIGENCIA OF DCLAPOLICE-COBERTURAS TO DATA-TERVIGENCIA OF DCLHIS-COBER-PROPOST. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA, COBPRPVA.DCLHIS_COBER_PROPOST.DATA_TERVIGENCIA);

        }

        [StopWatch]
        /*" R0590-00-ACESSA-COBERAPOL-DB-SELECT-1 */
        public void R0590_00_ACESSA_COBERAPOL_DB_SELECT_1()
        {
            /*" -3808- EXEC SQL SELECT NUM_APOLICE, NUM_ITEM, NUM_ENDOSSO, RAMO_COBERTURA, COD_COBERTURA, DATA_INIVIGENCIA, DATA_TERVIGENCIA INTO :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-APOLICE, :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ITEM, :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ENDOSSO, :DCLAPOLICE-COBERTURAS.APOLICOB-RAMO-COBERTURA, :DCLAPOLICE-COBERTURAS.APOLICOB-COD-COBERTURA, :DCLAPOLICE-COBERTURAS.APOLICOB-DATA-INIVIGENCIA, :DCLAPOLICE-COBERTURAS.APOLICOB-DATA-TERVIGENCIA FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-APOLICE AND NUM_ENDOSSO = :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ENDOSSO AND NUM_ITEM = :DCLAPOLICE-COBERTURAS.APOLICOB-NUM-ITEM AND RAMO_COBERTURA = :DCLAPOLICE-COBERTURAS.APOLICOB-RAMO-COBERTURA AND COD_COBERTURA = :DCLAPOLICE-COBERTURAS.APOLICOB-COD-COBERTURA AND DATA_INIVIGENCIA = :DCLAPOLICE-COBERTURAS.APOLICOB-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1 = new R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1()
            {
                APOLICOB_DATA_INIVIGENCIA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
            };

            var executed_1 = R0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1.Execute(r0590_00_ACESSA_COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(executed_1.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);
                _.Move(executed_1.APOLICOB_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);
                _.Move(executed_1.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(executed_1.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(executed_1.APOLICOB_DATA_INIVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA);
                _.Move(executed_1.APOLICOB_DATA_TERVIGENCIA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_TERVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0590_SAIDA*/

        [StopWatch]
        /*" R0598-00-SELECT-QUANT-BIL-RENO-SECTION */
        private void R0598_00_SELECT_QUANT_BIL_RENO_SECTION()
        {
            /*" -3842- MOVE 'R0598' TO PARAGRAFO. */
            _.Move("R0598", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3848- PERFORM R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1 */

            R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1();

            /*" -3851- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3853- DISPLAY 'R0599 - PROBLEMA SELECT BILHETE  ' 'NUMBIL: ' BILHETE-NUM-BILHETE */

                $"R0599 - PROBLEMA SELECT BILHETE  NUMBIL: {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}"
                .Display();

                /*" -3854- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3856- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3857- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -3858- IF BILHETE-NUM-APOL-ANTERIOR NOT EQUAL ZEROS */

                if (BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR != 00)
                {

                    /*" -3859- MOVE BILHETE-NUM-APOL-ANTERIOR TO NUM-APOL-ANT */
                    _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR, NUM_APOL_ANT);

                    /*" -3860- GO TO R0598-00-SELECT-QUANT-BIL-RENO */
                    new Task(() => R0598_00_SELECT_QUANT_BIL_RENO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -3861- END-IF */
                }


                /*" -3861- END-IF. */
            }


        }

        [StopWatch]
        /*" R0598-00-SELECT-QUANT-BIL-RENO-DB-SELECT-1 */
        public void R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1()
        {
            /*" -3848- EXEC SQL SELECT NUM_APOL_ANTERIOR INTO :BILHETE-NUM-APOL-ANTERIOR FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :NUM-APOL-ANT WITH UR END-EXEC. */

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
            /*" -3872- MOVE '0599' TO PARAGRAFO. */
            _.Move("0599", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3877- PERFORM R0599_00_SELECT_PROPOFID_DB_SELECT_1 */

            R0599_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -3880- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3881- DISPLAY 'R0598-00 (ERRO SELECT PROPOFID ' */
                _.Display($"R0598-00 (ERRO SELECT PROPOFID ");

                /*" -3882- DISPLAY 'NUMBIL ' BILHETE-NUM-BILHETE */
                _.Display($"NUMBIL {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                /*" -3883- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3884- PERFORM R9999-00-FINALIZAR */

                R9999_00_FINALIZAR_SECTION();

                /*" -3885- ELSE */
            }
            else
            {


                /*" -3886- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -3887- MOVE 'SIM' TO W-TEM-RENOVACAO */
                    _.Move("SIM", W_TEM_RENOVACAO);

                    /*" -3888- END-IF */
                }


                /*" -3888- END-IF. */
            }


        }

        [StopWatch]
        /*" R0599-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R0599_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -3877- EXEC SQL SELECT NUM_PROPOSTA_SIVPF INTO :DCLPROPOSTA-FIDELIZ.NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_SICOB = :NUM-APOL-ANT END-EXEC. */

            var r0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                NUM_APOL_ANT = NUM_APOL_ANT.ToString(),
            };

            var executed_1 = R0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r0599_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_PROPOSTA_SIVPF, PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0599_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-GERAR-REGISTRO-TP4-SECTION */
        private void R0600_00_GERAR_REGISTRO_TP4_SECTION()
        {
            /*" -3901- MOVE 'R0600-00-GERAR-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0600-00-GERAR-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3902- MOVE 'WRITE REG-STA-PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-STA-PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3904- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3906- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -3909- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -3912- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -3915- MOVE PROPFIDH-SIT-COBRANCA-SIVPF TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -3918- MOVE PROPFIDH-DATA-SITUACAO TO W-DATA-SQL. */
            _.Move(PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3919- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3920- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3922- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3925- MOVE W-DATA-TRABALHO TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -3929- MOVE ZEROS TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -3931- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -3933- ADD 1 TO W-QTD-LD-TIPO-4. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_4.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + 1;

            /*" -3934- MOVE NUM-PROPOSTA-SIVPF OF DCLPROPOSTA-FIDELIZ TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(PROPFID.DCLPROPOSTA_FIDELIZ.NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0800-00-GERAR-TRAILLER-SECTION */
        private void R0800_00_GERAR_TRAILLER_SECTION()
        {
            /*" -3944- MOVE 'R0800-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R0800-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3945- MOVE 'WRITE REG-TRAILLER-STA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER-STA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3947- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3949- MOVE SPACES TO REG-TRAILLER-STA. */
            _.Move("", LBFCT011.REG_TRAILLER_STA);

            /*" -3952- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -3955- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -3958- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1);

            /*" -3961- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2);

            /*" -3964- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3);

            /*" -3967- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4);

            /*" -3970- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5);

            /*" -3973- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6);

            /*" -3976- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7);

            /*" -3979- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8);

            /*" -3982- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER-STA */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9);

            /*" -3993- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 + RT-QTDE-TIPO-2 + RT-QTDE-TIPO-3 + RT-QTDE-TIPO-4 + RT-QTDE-TIPO-5 + RT-QTDE-TIPO-6 + RT-QTDE-TIPO-7 + RT-QTDE-TIPO-8 + RT-QTDE-TIPO-9. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -3993- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R0850_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -4006- MOVE 'R0850-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R0850-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4007- MOVE 'INSERT ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4009- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4012- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -4015- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -4019- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -4023- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -4031- PERFORM R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -4034- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4035- DISPLAY 'PF0605B - FIM ANORMAL' */
                _.Display($"PF0605B - FIM ANORMAL");

                /*" -4036- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -4038- DISPLAY '          SIGLA DO ARQIVO...............  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -4040- DISPLAY '          NSAS SIVPF....................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -4042- DISPLAY '          DATA GERACAO..................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -4044- DISPLAY '          QTDE. REGISTROS...............  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS...............  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -4047- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4049- MOVE SPACES TO W-FIM-MOVTO-FIDELIZ */
                _.Move("", WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ);

                /*" -4050- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4050- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0850-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -4031- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0870-00-GERAR-TOTAIS-SECTION */
        private void R0870_00_GERAR_TOTAIS_SECTION()
        {
            /*" -4061- MOVE 'R0870-00-GERAR-TOTAIS' TO PARAGRAFO. */
            _.Move("R0870-00-GERAR-TOTAIS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4062- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4064- DISPLAY PARAGRAFO */
            _.Display(WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4074- COMPUTE W-TOT-GERADO-STA = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9. */
            WAREA_AUXILIAR.W_TOT_GERADO_STA.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9;

            /*" -4075- DISPLAY 'PF0605B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0605B - TOTAIS DO PROCESSAMENTO");

            /*" -4076- DISPLAY '          TOTAL  REGISTROS LIDOS... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS... {WAREA_AUXILIAR.W_NSL}");

            /*" -4077- DISPLAY '          TOTAL  REGISTROS VIDA.... ' W-LIDO-VIDA */
            _.Display($"          TOTAL  REGISTROS VIDA.... {WAREA_AUXILIAR.W_LIDO_VIDA}");

            /*" -4078- DISPLAY '          TOTAL  BILHETE   AP...... ' W-LIDO-BIL-AP */
            _.Display($"          TOTAL  BILHETE   AP...... {WAREA_AUXILIAR.W_LIDO_BIL_AP}");

            /*" -4079- DISPLAY '          TOTAL  BILHETE   RD...... ' W-LIDO-BIL-RD */
            _.Display($"          TOTAL  BILHETE   RD...... {WAREA_AUXILIAR.W_LIDO_BIL_RD}");

            /*" -4081- DISPLAY '          TOTAL  MICRO.AMPARO...... ' W-LIDO-MIC-AMPARO */
            _.Display($"          TOTAL  MICRO.AMPARO...... {WAREA_AUXILIAR.W_LIDO_MIC_AMPARO}");

            /*" -4082- DISPLAY ' ' */
            _.Display($" ");

            /*" -4083- DISPLAY '          TOTAL  GERADO ARQ. STATUS ' */
            _.Display($"          TOTAL  GERADO ARQ. STATUS ");

            /*" -4085- DISPLAY '          TOTAL  REGISTROS TP-1.... ' W-QTD-LD-TIPO-1 */
            _.Display($"          TOTAL  REGISTROS TP-1.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_1}");

            /*" -4087- DISPLAY '          TOTAL  REGISTROS TP-2.... ' W-QTD-LD-TIPO-2 */
            _.Display($"          TOTAL  REGISTROS TP-2.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_2}");

            /*" -4089- DISPLAY '          TOTAL  REGISTROS TP-3.... ' W-QTD-LD-TIPO-3 */
            _.Display($"          TOTAL  REGISTROS TP-3.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_3}");

            /*" -4091- DISPLAY '          TOTAL  REGISTROS TP-4.... ' W-QTD-LD-TIPO-4 */
            _.Display($"          TOTAL  REGISTROS TP-4.... {WAREA_AUXILIAR.W_QTD_LD_TIPO_4}");

            /*" -4093- DISPLAY '          TOTAL  REGISTROS GERADOS. ' W-TOT-GERADO-STA */
            _.Display($"          TOTAL  REGISTROS GERADOS. {WAREA_AUXILIAR.W_TOT_GERADO_STA}");

            /*" -4094- DISPLAY ' ' */
            _.Display($" ");

            /*" -4095- DISPLAY '          TOTAL  DESPREZ. PRODUTO.. ' W-DESP-PROD */
            _.Display($"          TOTAL  DESPREZ. PRODUTO.. {WAREA_AUXILIAR.W_DESP_PROD}");

            /*" -4096- DISPLAY '          TOTAL  DESPREZ. USUARIO.. ' W-DESP-USUA */
            _.Display($"          TOTAL  DESPREZ. USUARIO.. {WAREA_AUXILIAR.W_DESP_USUA}");

            /*" -4097- DISPLAY '          TOTAL  DESPREZ. SICOB.... ' W-DESP-SICOB */
            _.Display($"          TOTAL  DESPREZ. SICOB.... {WAREA_AUXILIAR.W_DESP_SICOB}");

            /*" -4098- DISPLAY '          TOTAL  DESPREZ. SEGURADO. ' W-DESP-SEGU */
            _.Display($"          TOTAL  DESPREZ. SEGURADO. {WAREA_AUXILIAR.W_DESP_SEGU}");

            /*" -4099- DISPLAY '          TOTAL  DESPREZ. PENDENCIA ' W-DESP-PEND */
            _.Display($"          TOTAL  DESPREZ. PENDENCIA {WAREA_AUXILIAR.W_DESP_PEND}");

            /*" -4100- DISPLAY '          TOTAL  DESPREZ. HISTORICO ' W-DESP-HIST */
            _.Display($"          TOTAL  DESPREZ. HISTORICO {WAREA_AUXILIAR.W_DESP_HIST}");

            /*" -4101- DISPLAY '          TOTAL  DESPREZ. MOTIVO... ' W-DESP-MOTIVO */
            _.Display($"          TOTAL  DESPREZ. MOTIVO... {WAREA_AUXILIAR.W_DESP_MOTIVO}");

            /*" -4101- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -4109- CLOSE MOVTO-STA-SASSE. */
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9998-00-MONITOR-SECTION */
        private void R9998_00_MONITOR_SECTION()
        {
            /*" -4116- DISPLAY ' ' . */
            _.Display($" ");

            /*" -4116- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM M_1100_MOSTRA_TOTAIS */

            M_1100_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" M-1100-MOSTRA-TOTAIS */
        private void M_1100_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -4119- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -4120- IF SII < 33 */

            if (WS_HORAS.SII < 33)
            {

                /*" -4121- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_12[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -4123- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_12[WS_HORAS.SII]}"
                .Display();

                /*" -4124- GO TO 1100-MOSTRA-TOTAIS. */
                new Task(() => M_1100_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -4124- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9998_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -4135- DISPLAY ' ' */
            _.Display($" ");

            /*" -4136- IF W-FIM-MOVTO-FIDELIZ = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_FIDELIZ == "FIM")
            {

                /*" -4138- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -4139- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4139- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -4145- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -4146- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -4147- DISPLAY '*         PF0605B - TERMINO NORMAL         *' */
                _.Display($"*         PF0605B - TERMINO NORMAL         *");

                /*" -4148- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -4149- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -4151- ELSE */
            }
            else
            {


                /*" -4152- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_3.WSQLCODE);

                /*" -4153- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_3.WSQLERRD1);

                /*" -4154- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_3.WSQLERRD2);

                /*" -4155- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -4156- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -4157- DISPLAY '*   PF0605B - TERMINO ANORMAL - VERIFIQUE  *' */
                _.Display($"*   PF0605B - TERMINO ANORMAL - VERIFIQUE  *");

                /*" -4158- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -4159- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -4160- DISPLAY '*' WABEND */
                _.Display($"*{WABEND}");

                /*" -4161- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -4162- DISPLAY '*   PF0605B - ROLLBACK   EM   ANDAMENTO    *' */
                _.Display($"*   PF0605B - ROLLBACK   EM   ANDAMENTO    *");

                /*" -4163- DISPLAY '*                                          *' */
                _.Display($"*                                          *");

                /*" -4165- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -4166- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -4166- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -4170- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -4170- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}