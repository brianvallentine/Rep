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
using Sias.VidaAzul.DB2.VA1813B;

namespace Code
{
    public class VA1813B
    {
        public bool IsCall { get; set; }

        public VA1813B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *      RETORNO DOS LANCAMENTOS DE DEBITO EM CONTA FEBRABAN       *      */
        /*"      *           CONVENIOS 6081 GLOBAL , 6088 MULTIPREMIADO,          *      */
        /*"      *                                                                       */
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
        /*"      *                                                                *      */
        /*"      *   VERSAO 31 - DEMANDA 385134                                   *      */
        /*"      *               CORRECAO NA ATUALIZACAO DA HIST_LANC_CTA PARA    *      */
        /*"      *               QUANDO HOUVER RETORNO DO FINAL DE REGUA O        *      */
        /*"      *               REGISTRO ENTRAR NA SITUACAO DE RETORNO DO ARQH   *      */
        /*"      *   EM 04/05/2023 - ROGER PIRES DOS SANTOS                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.31         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 30 -   INCIDENTE 343127                               *      */
        /*"      *               - ABEND -811 NA R0036-00-ACESSO-NSAS CAUSADO POR *      */
        /*"      *                 NSAS REPETIDO (NSAS ANTIGO). INCLUIDO CODCONV  *      */
        /*"      *                 (INFORMADO NO HEADER) NO SELECT.               *      */
        /*"      *   EM 03/12/2021 - BRICE HO                                     *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.30         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 29 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 12/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.29         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 28 - CAD 53.241                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CANCELA PROPOSTA QUANDO RETORNO DE COBRANCA DO  *      */
        /*"      *                CANAL CERAT FOR DIFERENTE DE ZERO.              *      */
        /*"      *                                                                *      */
        /*"      *   EM 04/03/2011 - EDIVALDO GOMES (FAST COMPUTER)               *      */
        /*"      *                                            PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - DEIXAR PARCELAS PENDENTES QUANDO A FITA DE RETOR-*      */
        /*"      *               NO CONSTAR "DEBITO ESTORNADO" (99)               *      */
        /*"      *                                                                *      */
        /*"      *   EM 05/07/2007 - FAST COMPUTER            PROCURE POR V.27    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 26 - DEIXAR PARCELAS PENDENTES QUANDO A FITA DE RETOR-*      */
        /*"      *               NO CONSTAR "DEBITO ESTORNADO" (99) NAO SOLICITA- *      */
        /*"      *               DOS PELA CX SEGUROS.                             *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/12/2006 - FAST COMPUTER            PROCURE POR V.26    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 25 - PASSOU A RECUPERAR LANCAMENTO POR NSAS E NSL     *      */
        /*"      *               PARA EVITAR DIFERENCA NA BAIXA DOS RETORNOS.     *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/10/2006 - FAST COMPUTER            PROCURE POR V.25    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 024                                                     */
        /*"      *              EM 22/08/2006- FAST COMPUTER  (FC0608)            *      */
        /*"      *                             O PROGRAMA ESTAVA TRATANDO A       *      */
        /*"      *                             ULTIMA POSICAO DO REGISTRO DE      *      */
        /*"      *                             RETORNO PARA DECIDIR O TIPO DE     *      */
        /*"      *                             ESTORNO. OCORRE QUE A ULTIMA       *      */
        /*"      *                             POSICAO ESTA RETORNANDO SEMPRE     *      */
        /*"      *                             COM 0, NAO PEMITINDO SEU USO.      *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 023                                                     */
        /*"      *              EM 20/08/2004- CLOVIS (CL0804)                    *      */
        /*"      *                             DEIXA DE INCLUIR AVISO DE CREDITO  *      */
        /*"      *                             NESTE PGM.                         *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *     ALTERACAO 022                                                     */
        /*"      *              EM 30/06/2004- MANOEL MESSIAS   (MM0604)          *      */
        /*"      *                               TRATA SOMENTE TIPLANC=4 E COD-RE *      */
        /*"      *                               TORNO 97, 98 E 99.               *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO 021                                                     */
        /*"      *              EM 08/07/2003- MANOEL MESSIAS   (MM0703)          *      */
        /*"      *                               PASSA A TRATAR O ESTORNO DE DEBI-*      */
        /*"      *                               TO GERADO PELA MATRIZ QUE GERA O *      */
        /*"      *                               TIPLANC = 4.                     *      */
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
        /*"      *                               AS PARCELAS CUJA SITUACAO ESTA   *      */
        /*"      *                               IGUAL A 1-PAGA NO MOMENTO DO     *      */
        /*"      *                               PROCESSAMENTO, PASSAM A NAO TER  *      */
        /*"      *                               A SITUACAO ALTERADA, MESMO       *      */
        /*"      *                               QUANDO O RETORNO FOR 97, 98      *      */
        /*"      *                               OU 99.                           *      */
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
        /*"1     ******************************************************************      */
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
        public SortBasis<VA1813B_SVA_CADASTRAMENTO> SVADEB { get; set; } = new SortBasis<VA1813B_SVA_CADASTRAMENTO>(new VA1813B_SVA_CADASTRAMENTO());
        /*"01         RETDEB-RECORD       PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01         RET-HEADER.*/
        public VA1813B_RET_HEADER RET_HEADER { get; set; } = new VA1813B_RET_HEADER();
        public class VA1813B_RET_HEADER : VarBasis
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
            public VA1813B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA1813B_RA_DATA_GERACAO();
            public class VA1813B_RA_DATA_GERACAO : VarBasis
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
        public VA1813B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA1813B_RET_CADASTRAMENTO();
        public class VA1813B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05   RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RF-IDENT-CLI-EMPRESA.*/
            public VA1813B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA1813B_RF_IDENT_CLI_EMPRESA();
            public class VA1813B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10  RF-IDENTIF-CLI      PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  RF-IDENTIF-CLI-R REDEFINES           RF-IDENTIF-CLI.*/
                private _REDEF_VA1813B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VA1813B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VA1813B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA1813B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"           15 FILLER           PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10  RF-IDENTIF-NSA      PIC 9(005).*/

                    public _REDEF_VA1813B_RF_IDENTIF_CLI_R()
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
            public VA1813B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA1813B_RF_IDENT_CLI_BANCO();
            public class VA1813B_RF_IDENT_CLI_BANCO : VarBasis
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
            public VA1813B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA1813B_RF_DATA_REAL();
            public class VA1813B_RF_DATA_REAL : VarBasis
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
            public VA1813B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA1813B_RF_USO_EMPRESA();
            public class VA1813B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10  RF-NSA              PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NSL              PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  FILLER              PIC X(047).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO            PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO        PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLER.*/
        }
        public VA1813B_RET_TRAILLER RET_TRAILLER { get; set; } = new VA1813B_RET_TRAILLER();
        public class VA1813B_RET_TRAILLER : VarBasis
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
        public VA1813B_RETERR_RECORD RETERR_RECORD { get; set; } = new VA1813B_RETERR_RECORD();
        public class VA1813B_RETERR_RECORD : VarBasis
        {
            /*"    05 RETERR-REGISTRO   PIC X(150).*/
            public StringBasis RETERR_REGISTRO { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
            /*"    05 RETERR-MENSAGEM   PIC X(070).*/
            public StringBasis RETERR_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"01  SVA-CADASTRAMENTO.*/
        }
        public VA1813B_SVA_CADASTRAMENTO SVA_CADASTRAMENTO { get; set; } = new VA1813B_SVA_CADASTRAMENTO();
        public class VA1813B_SVA_CADASTRAMENTO : VarBasis
        {
            /*"    05 SF-COD-REG        PIC X(001).*/
            public StringBasis SF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 SF-IDENT-CLI-EMPRESA.*/
            public VA1813B_SF_IDENT_CLI_EMPRESA SF_IDENT_CLI_EMPRESA { get; set; } = new VA1813B_SF_IDENT_CLI_EMPRESA();
            public class VA1813B_SF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10 SF-IDENTIF-CLI PIC 9(015).*/
                public IntBasis SF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10 SF-IDENTIF-CLI-R REDEFINES          SF-IDENTIF-CLI.*/
                private _REDEF_VA1813B_SF_IDENTIF_CLI_R _sf_identif_cli_r { get; set; }
                public _REDEF_VA1813B_SF_IDENTIF_CLI_R SF_IDENTIF_CLI_R
                {
                    get { _sf_identif_cli_r = new _REDEF_VA1813B_SF_IDENTIF_CLI_R(); _.Move(SF_IDENTIF_CLI, _sf_identif_cli_r); VarBasis.RedefinePassValue(SF_IDENTIF_CLI, _sf_identif_cli_r, SF_IDENTIF_CLI); _sf_identif_cli_r.ValueChanged += () => { _.Move(_sf_identif_cli_r, SF_IDENTIF_CLI); }; return _sf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _sf_identif_cli_r, SF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA1813B_SF_IDENTIF_CLI_R : VarBasis
                {
                    /*"          15 FILLER      PIC X(015).*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10 SF-IDENTIF-NSA PIC 9(005).*/

                    public _REDEF_VA1813B_SF_IDENTIF_CLI_R()
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
            public VA1813B_SF_IDENT_CLI_BANCO SF_IDENT_CLI_BANCO { get; set; } = new VA1813B_SF_IDENT_CLI_BANCO();
            public class VA1813B_SF_IDENT_CLI_BANCO : VarBasis
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
            public VA1813B_SF_DATA_REAL SF_DATA_REAL { get; set; } = new VA1813B_SF_DATA_REAL();
            public class VA1813B_SF_DATA_REAL : VarBasis
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
            public VA1813B_SF_USO_EMPRESA SF_USO_EMPRESA { get; set; } = new VA1813B_SF_USO_EMPRESA();
            public class VA1813B_SF_USO_EMPRESA : VarBasis
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
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
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
        /*"01  WHOST-TIPLANC                    PIC  X(01).*/
        public StringBasis WHOST_TIPLANC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  WHOST-CODCONV                    PIC S9(09)    COMP.*/
        public IntBasis WHOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SIST-DTMOVABE                  PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET                     PIC X(10).*/
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
        /*"01  V0PRVG-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PRVG_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis V0PRVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PRVG-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis V0PRVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0PRVG_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        /*"01  V0HCTA-TIPLANC                   PIC  X(01).*/
        public StringBasis V0HCTA_TIPLANC { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
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
        /*"01  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
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
        /*"01  V0COBP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
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
        /*"01    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WORK-AREA.*/
        public VA1813B_WORK_AREA WORK_AREA { get; set; } = new VA1813B_WORK_AREA();
        public class VA1813B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 AC-CONTA                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      DATA-SQL.*/
            public VA1813B_DATA_SQL DATA_SQL { get; set; } = new VA1813B_DATA_SQL();
            public class VA1813B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-TIME                       PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 WS-DATA-INV.*/
            public VA1813B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA1813B_WS_DATA_INV();
            public class VA1813B_WS_DATA_INV : VarBasis
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
            /*"    05 WS-NRAVISO                PIC  9(009)    VALUE  0.*/
            public IntBasis WS_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05 FILLER                    REDEFINES      WS-NRAVISO.*/
            private _REDEF_VA1813B_FILLER_11 _filler_11 { get; set; }
            public _REDEF_VA1813B_FILLER_11 FILLER_11
            {
                get { _filler_11 = new _REDEF_VA1813B_FILLER_11(); _.Move(WS_NRAVISO, _filler_11); VarBasis.RedefinePassValue(WS_NRAVISO, _filler_11, WS_NRAVISO); _filler_11.ValueChanged += () => { _.Move(_filler_11, WS_NRAVISO); }; return _filler_11; }
                set { VarBasis.RedefinePassValue(value, _filler_11, WS_NRAVISO); }
            }  //Redefines
            public class _REDEF_VA1813B_FILLER_11 : VarBasis
            {
                /*"      10 WS-AGEAVISO             PIC  9(004).*/
                public IntBasis WS_AGEAVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-NSAC                 PIC  9(005).*/
                public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05       WS-SUBS           PIC  9(005)    VALUE ZEROS.*/

                public _REDEF_VA1813B_FILLER_11()
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
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA1813B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VA1813B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VA1813B_FILLER_12(); _.Move(WDATA_REL, _filler_12); VarBasis.RedefinePassValue(WDATA_REL, _filler_12, WDATA_REL); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_REL); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA1813B_FILLER_12 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/

                public _REDEF_VA1813B_FILLER_12()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA1813B_WABEND WABEND { get; set; } = new VA1813B_WABEND();
            public class VA1813B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA1813B  '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA1813B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA1813B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA1813B_LOCALIZA_ABEND_1();
            public class VA1813B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA1813B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA1813B_LOCALIZA_ABEND_2();
            public class VA1813B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01    WS-HORAS.*/
            }
        }
        public VA1813B_WS_HORAS WS_HORAS { get; set; } = new VA1813B_WS_HORAS();
        public class VA1813B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA1813B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA1813B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA1813B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA1813B_WS_HORA_INI_R : VarBasis
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

                public _REDEF_VA1813B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA1813B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA1813B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA1813B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA1813B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VA1813B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VA1813B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA1813B_TOTAIS_ROT();
        public class VA1813B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VA1813B_FILLER_23> FILLER_23 { get; set; } = new ListBasis<VA1813B_FILLER_23>(50);
            public class VA1813B_FILLER_23 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Dclgens.VGFOLLOW VGFOLLOW { get; set; } = new Dclgens.VGFOLLOW();
        public VA1813B_CHCONTA2 CHCONTA2 { get; set; } = new VA1813B_CHCONTA2();
        public VA1813B_CHCONTA3 CHCONTA3 { get; set; } = new VA1813B_CHCONTA3();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETDEB_FILE_NAME_P, string RETERR_FILE_NAME_P, string SVADEB_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                RETERR.SetFile(RETERR_FILE_NAME_P);
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
            /*" -676- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -679- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -682- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -685- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -686- DISPLAY 'PROGRAMA EM EXECUCAO VA1813B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VA1813B  ");

            /*" -687- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -690- DISPLAY 'VERSAO V.31 385134 04/05/2023 ' */
            _.Display($"VERSAO V.31 385134 04/05/2023 ");

            /*" -691- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -693- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -696- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -703- SORT SVADEB ON ASCENDING KEY SF-COD-REG SF-IDENTIF-CLI SF-COD-RETORNO SF-NSA SF-NSL USING RETDEB GIVING RETDEB. */
            RETDEB.AllLines = RETDEB.SortFile("SF-COD-REG,SF-IDENTIF-CLI,SF-COD-RETORNO,SF-NSA,SF-NSL", SVADEB.FileLayout);

            /*" -706- OPEN INPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -708- OPEN OUTPUT RETERR. */
            RETERR.Open(RETERR_RECORD);

            /*" -709- MOVE '0001-INICIO  ' TO PARAGRAFO. */
            _.Move("0001-INICIO  ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -711- MOVE 'SELECT V1SISTEMA' TO COMANDO. */
            _.Move("SELECT V1SISTEMA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -712- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -714- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -719- PERFORM M_0000_PRINCIPAL_DB_SELECT_1 */

            M_0000_PRINCIPAL_DB_SELECT_1();

            /*" -723- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -724- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -725- DISPLAY 'SISTEMA NAO ENCONTRADO' */
                _.Display($"SISTEMA NAO ENCONTRADO");

                /*" -728- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -729- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -730- DISPLAY '*** VA1813B *** MOVIMENTO RETORNO VAZIO' */
                    _.Display($"*** VA1813B *** MOVIMENTO RETORNO VAZIO");

                    /*" -732- GO TO R0001-00-FIM-NORMAL. */

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
            /*" -733- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -734- DISPLAY '*** VA1813B *** FITA SEM HEADER' */
                _.Display($"*** VA1813B *** FITA SEM HEADER");

                /*" -736- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -741- MOVE RA-COD-CONVENIO TO WS-CODCONV WHOST-CODCONV. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_CODCONV, WHOST_CODCONV);

            /*" -742- IF WS-CODCONV NOT EQUAL 6081 AND 6088 AND 6132 AND 6153 */

            if (!WORK_AREA.WS_CODCONV.In("6081", "6088", "6132", "6153"))
            {

                /*" -744- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -746- MOVE RA-NSA TO V0FTCF-NSAC. */
            _.Move(RET_HEADER.RA_NSA, V0FTCF_NSAC);

            /*" -747- MOVE WS-CODCONV TO AUX-CONVENIO */
            _.Move(WORK_AREA.WS_CODCONV, WORK_AREA.AUX_CONVENIO);

            /*" -749- MOVE RA-NSA TO AUX-NSAC. */
            _.Move(RET_HEADER.RA_NSA, WORK_AREA.AUX_NSAC);

            /*" -750- IF WS-CODCONV = 6081 */

            if (WORK_AREA.WS_CODCONV == 6081)
            {

                /*" -752- ADD 19000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 19000;
            }


            /*" -753- IF WS-CODCONV = 6088 */

            if (WORK_AREA.WS_CODCONV == 6088)
            {

                /*" -755- ADD 23000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 23000;
            }


            /*" -756- IF WS-CODCONV = 6132 */

            if (WORK_AREA.WS_CODCONV == 6132)
            {

                /*" -758- ADD 28000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 28000;
            }


            /*" -759- IF WS-CODCONV = 6153 */

            if (WORK_AREA.WS_CODCONV == 6153)
            {

                /*" -761- ADD 30000 TO V0FTCF-NSAC. */
                V0FTCF_NSAC.Value = V0FTCF_NSAC + 30000;
            }


            /*" -762- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -763- MOVE WS-ANO-INV TO ANO-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -764- MOVE WS-MES-INV TO MES-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -766- MOVE WS-DIA-INV TO DIA-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -767- MOVE DATA-SQL TO V0FTCF-DTRET. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET);

            /*" -768- MOVE DATA-SQL TO V0FTCF-DTRET2. */
            _.Move(WORK_AREA.DATA_SQL, V0FTCF_DTRET2);

            /*" -770- MOVE RA-VERSAO-LAYOUT TO V0FTCF-VERSAO. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, V0FTCF_VERSAO);

            /*" -772- WRITE RETERR-RECORD FROM RETDEB-RECORD. */
            _.Move(RETDEB_RECORD.GetMoveValues(), RETERR_RECORD);

            RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

            /*" -773- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -774- DISPLAY '*** VA1813B *** FITA SEM MOVIMENTO ' */
                    _.Display($"*** VA1813B *** FITA SEM MOVIMENTO ");

                    /*" -776- GO TO R0001-00-FIM-NORMAL. */

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
            /*" -777- IF RA-COD-REG NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADER.RA_COD_REG.In("F", "Z"))
            {

                /*" -778- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -779- MOVE 'COD REGISTRO NAO ESPERADO' TO RETERR-MENSAGEM */
                _.Move("COD REGISTRO NAO ESPERADO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -780- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -782- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -783- IF RA-COD-REG EQUAL 'Z' */

            if (RET_HEADER.RA_COD_REG == "Z")
            {

                /*" -784- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                /*" -785- MOVE 'NAO HA RETORNO DE DEBITO' TO RETERR-MENSAGEM */
                _.Move("NAO HA RETORNO DE DEBITO", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -786- WRITE RETERR-RECORD */
                RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                /*" -788- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -789- MOVE V0FTCF-NSAC TO WS-NSAC */
            _.Move(V0FTCF_NSAC, WORK_AREA.FILLER_11.WS_NSAC);

            /*" -790- DISPLAY '*** VA1813B *** PROCESSANDO ...' . */
            _.Display($"*** VA1813B *** PROCESSANDO ...");

            /*" -791- DISPLAY '*** CONVENIO ' WS-CODCONV */
            _.Display($"*** CONVENIO {WORK_AREA.WS_CODCONV}");

            /*" -793- DISPLAY '*** NSAC     ' WS-NSAC */
            _.Display($"*** NSAC     {WORK_AREA.FILLER_11.WS_NSAC}");

            /*" -797- PERFORM R0020-00-PROCESSA UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                R0020_00_PROCESSA_SECTION();
            }

            /*" -798- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -799- DISPLAY '*** VA1813B *** FITA SEM TRAILLER' */
                _.Display($"*** VA1813B *** FITA SEM TRAILLER");

                /*" -800- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -801- ELSE */
            }
            else
            {


                /*" -802- IF RA-COD-REG NOT EQUAL 'Z' */

                if (RET_HEADER.RA_COD_REG != "Z")
                {

                    /*" -803- MOVE RETDEB-RECORD TO RETERR-REGISTRO */
                    _.Move(RETDEB?.Value, RETERR_RECORD.RETERR_REGISTRO);

                    /*" -804- MOVE 'COD REGISTRO NAO ESPERADO' TO RETERR-MENSAGEM */
                    _.Move("COD REGISTRO NAO ESPERADO", RETERR_RECORD.RETERR_MENSAGEM);

                    /*" -805- WRITE RETERR-RECORD */
                    RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

                    /*" -807- GO TO R0001-00-FIM-ANORMAL. */

                    R0001_00_FIM_ANORMAL(); //GOTO
                    return;
                }

            }


            /*" -809- WRITE RETERR-RECORD FROM RETDEB-RECORD. */
            _.Move(RETDEB_RECORD.GetMoveValues(), RETERR_RECORD);

            RETERR.Write(RETERR_RECORD.GetMoveValues().ToString());

            /*" -811- DISPLAY '*** VA1813B *** LANCAMENTOS RETORNADOS ' WS-REGISTROS. */
            _.Display($"*** VA1813B *** LANCAMENTOS RETORNADOS {WORK_AREA.WS_REGISTROS}");

            /*" -813- DISPLAY '*** VA1813B *** DEBITOS RETORNADOS     ' RZ-TOT-DEB-CRUZ. */
            _.Display($"*** VA1813B *** DEBITOS RETORNADOS     {RET_TRAILLER.RZ_TOT_DEB_CRUZ}");

            /*" -815- DISPLAY '*** VA1813B *** DEBITOS EFETUADOS      ' WS-ACG-TOTDBEFET. */
            _.Display($"*** VA1813B *** DEBITOS EFETUADOS      {WORK_AREA.WS_ACG_TOTDBEFET}");

            /*" -818- DISPLAY '*** VA1813B *** DEBITOS NAO EFET       ' WS-ACG-TOTDBNEFET. */
            _.Display($"*** VA1813B *** DEBITOS NAO EFET       {WORK_AREA.WS_ACG_TOTDBNEFET}");

            /*" -819- IF WS-REGISTROS GREATER ZEROES */

            if (WORK_AREA.WS_REGISTROS > 00)
            {

                /*" -819- PERFORM R0050-00-GERA-FITACEF. */

                R0050_00_GERA_FITACEF_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0001_00_FIM_NORMAL */

            R0001_00_FIM_NORMAL();

        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -719- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var m_0000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R0001-00-FIM-NORMAL */
        private void R0001_00_FIM_NORMAL(bool isPerform = false)
        {
            /*" -823- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -826- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -828- CLOSE RETERR. */
            RETERR.Close();

            /*" -829- DISPLAY '*** VA1813B *** TERMINO NORMAL' . */
            _.Display($"*** VA1813B *** TERMINO NORMAL");

            /*" -831- DISPLAY ' ' . */
            _.Display($" ");

            /*" -833- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -835- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -835- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0001-00-FIM-ANORMAL */
        private void R0001_00_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -840- DISPLAY '*** VA1813B *** PROCESSAMENTO TERMINOU COM ERRO' . */
            _.Display($"*** VA1813B *** PROCESSAMENTO TERMINOU COM ERRO");

            /*" -842- DISPLAY '*** VA1813B *** VIDE ARQUIVO RETERR COM MSG' . */
            _.Display($"*** VA1813B *** VIDE ARQUIVO RETERR COM MSG");

            /*" -842- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -845- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -847- CLOSE RETERR. */
            RETERR.Close();

            /*" -849- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -849- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-SECTION */
        private void R0020_00_PROCESSA_SECTION()
        {
            /*" -857- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -858- ADD 1 TO AC-LIDOS AC-CONTA. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.AC_CONTA.Value = WORK_AREA.AC_CONTA + 1;

            /*" -859- IF AC-CONTA > 999 */

            if (WORK_AREA.AC_CONTA > 999)
            {

                /*" -860- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WORK_AREA.AC_CONTA);

                /*" -861- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -864- DISPLAY 'LIDOS ' AC-LIDOS ' ' WS-TIME. */

                $"LIDOS {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();
            }


            /*" -866- IF RF-VLPRMTOT EQUAL ZEROS OR RF-COD-RETORNO EQUAL 96 */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT == 00 || RET_CADASTRAMENTO.RF_COD_RETORNO == 96)
            {

                /*" -867- DISPLAY '************************' */
                _.Display($"************************");

                /*" -868- DISPLAY 'DEBITO COM VALOR ZERADO ' */
                _.Display($"DEBITO COM VALOR ZERADO ");

                /*" -869- DISPLAY 'RF-NSA - ' RF-NSA */
                _.Display($"RF-NSA - {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA}");

                /*" -870- DISPLAY 'RF-NSL - ' RF-NSL */
                _.Display($"RF-NSL - {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL}");

                /*" -871- DISPLAY '************************' */
                _.Display($"************************");

                /*" -872- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -874- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -878- MOVE 0 TO WS-NAO-ACHEI. */
            _.Move(0, WORK_AREA.WS_NAO_ACHEI);

            /*" -879- IF RF-COD-RETORNO NOT EQUAL 97 AND 98 AND 99 */

            if (!RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
            {

                /*" -881- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -882- IF RF-VLPRMTOT GREATER ZEROES */

            if (RET_CADASTRAMENTO.RF_VLPRMTOT > 00)
            {

                /*" -883- IF RF-IDENTIF-CLI-R NUMERIC */

                if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI_R.IsNumeric())
                {

                    /*" -884- IF RF-IDENTIF-CLI > 0 */

                    if (RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI > 0)
                    {

                        /*" -885- PERFORM R0030-00-ACESSO-CERTIF */

                        R0030_00_ACESSO_CERTIF_SECTION();

                        /*" -886- IF WS-NAO-ACHEI = 1 */

                        if (WORK_AREA.WS_NAO_ACHEI == 1)
                        {

                            /*" -887- MOVE 0 TO WS-NAO-ACHEI */
                            _.Move(0, WORK_AREA.WS_NAO_ACHEI);

                            /*" -888- PERFORM R0036-00-ACESSO-NSAS */

                            R0036_00_ACESSO_NSAS_SECTION();

                            /*" -889- IF WS-NAO-ACHEI = 1 */

                            if (WORK_AREA.WS_NAO_ACHEI == 1)
                            {

                                /*" -890- MOVE 0 TO WS-NAO-ACHEI */
                                _.Move(0, WORK_AREA.WS_NAO_ACHEI);

                                /*" -891- PERFORM R0035-00-ACESSO-NUMCTADEB */

                                R0035_00_ACESSO_NUMCTADEB_SECTION();

                                /*" -893- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -895- ELSE NEXT SENTENCE */
                            }

                        }
                        else
                        {


                            /*" -896- ELSE */
                        }

                    }
                    else
                    {


                        /*" -897- PERFORM R0035-00-ACESSO-NUMCTADEB */

                        R0035_00_ACESSO_NUMCTADEB_SECTION();

                        /*" -898- ELSE */
                    }

                }
                else
                {


                    /*" -899- PERFORM R0035-00-ACESSO-NUMCTADEB */

                    R0035_00_ACESSO_NUMCTADEB_SECTION();

                    /*" -900- ELSE */
                }

            }
            else
            {


                /*" -902- MOVE 1 TO WS-NAO-ACHEI. */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);
            }


            /*" -903- IF WS-NAO-ACHEI NOT EQUAL 0 */

            if (WORK_AREA.WS_NAO_ACHEI != 0)
            {

                /*" -904- DISPLAY 'DEBITO NAO ENCONTRADO OU JA PROCESSADO' */
                _.Display($"DEBITO NAO ENCONTRADO OU JA PROCESSADO");

                /*" -905- DISPLAY RETDEB-RECORD */
                _.Display(RETDEB_RECORD);

                /*" -907- GO TO R0020-00-NEXT. */

                R0020_00_NEXT(); //GOTO
                return;
            }


            /*" -908- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -910- MOVE RF-COD-RETORNO TO V0HCTA-CODRET. */
            _.Move(RET_CADASTRAMENTO.RF_COD_RETORNO, V0HCTA_CODRET);

            /*" -911- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -913- MOVE 'SELECT V0PARCELVA' TO COMANDO. */
            _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -914- MOVE 02 TO SII. */
            _.Move(02, WS_HORAS.SII);

            /*" -916- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -930- PERFORM R0020_00_PROCESSA_DB_SELECT_1 */

            R0020_00_PROCESSA_DB_SELECT_1();

            /*" -934- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -935- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -937- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -939- MOVE 'SELECT V0HISTCOBVA' TO COMANDO. */
            _.Move("SELECT V0HISTCOBVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -940- MOVE 03 TO SII. */
            _.Move(03, WS_HORAS.SII);

            /*" -942- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -960- PERFORM R0020_00_PROCESSA_DB_SELECT_2 */

            R0020_00_PROCESSA_DB_SELECT_2();

            /*" -964- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -965- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -967- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -969- MOVE 'SELECT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -970- MOVE 04 TO SII. */
            _.Move(04, WS_HORAS.SII);

            /*" -972- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -982- PERFORM R0020_00_PROCESSA_DB_SELECT_3 */

            R0020_00_PROCESSA_DB_SELECT_3();

            /*" -986- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -987- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -989- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -991- MOVE 0 TO V0HCTA-OCORHISTCOB. */
            _.Move(0, V0HCTA_OCORHISTCOB);

            /*" -993- MOVE 'SELECT V0PROPOSTAVA' TO COMANDO. */
            _.Move("SELECT V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -994- MOVE 22 TO SII */
            _.Move(22, WS_HORAS.SII);

            /*" -996- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1034- PERFORM R0020_00_PROCESSA_DB_SELECT_4 */

            R0020_00_PROCESSA_DB_SELECT_4();

            /*" -1038- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1039- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1041- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1042- IF V0PROP-INRMATRFUN LESS 0 */

            if (V0PROP_INRMATRFUN < 0)
            {

                /*" -1044- MOVE 0 TO V0PROP-NRMATRFUN. */
                _.Move(0, V0PROP_NRMATRFUN);
            }


            /*" -1045- IF VIND-TEM-SAF LESS 0 */

            if (VIND_TEM_SAF < 0)
            {

                /*" -1047- MOVE 'N' TO V0PRVG-TEM-SAF. */
                _.Move("N", V0PRVG_TEM_SAF);
            }


            /*" -1048- IF VIND-TEM-CDG LESS 0 */

            if (VIND_TEM_CDG < 0)
            {

                /*" -1050- MOVE 'N' TO V0PRVG-TEM-CDG. */
                _.Move("N", V0PRVG_TEM_CDG);
            }


            /*" -1051- IF VIND-RISCO LESS 0 */

            if (VIND_RISCO < 0)
            {

                /*" -1060- MOVE '1' TO V0PRVG-RISCO. */
                _.Move("1", V0PRVG_RISCO);
            }


            /*" -1062- PERFORM R2000-00-REJEITA-PARCELA. */

            R2000_00_REJEITA_PARCELA_SECTION();

            /*" -1064- IF RF-COD-RETORNO EQUAL 97 OR 98 OR 99 AND V0PROP-SITUACAO NOT EQUAL '8' */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99") && V0PROP_SITUACAO != "8")
            {

                /*" -1129- PERFORM R0023-00-ATUALIZA-ESTORNO. */

                R0023_00_ATUALIZA_ESTORNO_SECTION();
            }


            /*" -1131- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

            /*" -1132- MOVE RF-IDENTIF-CLI TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -1133- MOVE RF-IDENTIF-NSA TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -1135- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -1135- PERFORM R8800-00-UPDATE-FOLLOWUP. */

            R8800_00_UPDATE_FOLLOWUP_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0020_00_NEXT */

            R0020_00_NEXT();

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-SELECT-1 */
        public void R0020_00_PROCESSA_DB_SELECT_1()
        {
            /*" -930- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, OPCAOOPAG, DTVENCTO INTO :V0PARC-PRMVG, :V0PARC-PRMAP, :V0PARC-PRMTOT, :V0PARC-OPCAOPAG, :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

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
            /*" -1139- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -1139- MOVE 1 TO WS-EOF. */
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
            /*" -960- EXEC SQL SELECT NRTIT, OCORHIST, DTVENCTO, SITUACAO, VLPRMTOT, OPCAOPAG, DTVENCTO - 1 DAY INTO :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0HCOB-DTVENCTO, :V0HCOB-SITUACAO, :V0HCOB-VLPRMTOT, :V0HCOB-OPCAOPAG, :V0HCOB-DTALTOPC FROM SEGUROS.V0HISTCOBVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

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
            /*" -982- EXEC SQL SELECT PERIPGTO, DIA_DEBITO, OPCAOPAG INTO :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, :V0OPCP-OPCAOPAG FROM SEGUROS.V0OPCAOPAGVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

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
        /*" R0023-00-ATUALIZA-ESTORNO-SECTION */
        private void R0023_00_ATUALIZA_ESTORNO_SECTION()
        {
            /*" -1148- IF RF-COD-MOVIMENTO EQUAL 0 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 0)
            {

                /*" -1149- MOVE '1' TO WHOST-TIPLANC. */
                _.Move("1", WHOST_TIPLANC);
            }


            /*" -1150- IF RF-COD-MOVIMENTO EQUAL 1 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 1)
            {

                /*" -1151- MOVE '4' TO WHOST-TIPLANC. */
                _.Move("4", WHOST_TIPLANC);
            }


            /*" -1152- IF RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -1153- MOVE '2' TO WHOST-TIPLANC. */
                _.Move("2", WHOST_TIPLANC);
            }


            /*" -1154- IF RF-COD-MOVIMENTO EQUAL 3 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 3)
            {

                /*" -1156- MOVE '5' TO WHOST-TIPLANC. */
                _.Move("5", WHOST_TIPLANC);
            }


            /*" -1157- IF RF-COD-RETORNO EQUAL 97 OR 98 */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98"))
            {

                /*" -1158- MOVE '8' TO WHOST-SITUACAO */
                _.Move("8", WHOST_SITUACAO);

                /*" -1159- ELSE */
            }
            else
            {


                /*" -1161- MOVE '7' TO WHOST-SITUACAO. */
                _.Move("7", WHOST_SITUACAO);
            }


            /*" -1163- MOVE 'UPDATE V0HISTCONTAVA 03' TO COMANDO */
            _.Move("UPDATE V0HISTCONTAVA 03", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1164- MOVE 08 TO SII */
            _.Move(08, WS_HORAS.SII);

            /*" -1166- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1179- PERFORM R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1 */

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1();

            /*" -1183- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1184- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1185- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1197- PERFORM R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2 */

                    R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2();

                    /*" -1199- ELSE */
                }
                else
                {


                    /*" -1199- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-DB-UPDATE-1 */
        public void R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1()
        {
            /*" -1179- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :WHOST-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA >= 0 AND NSAC IS NULL AND TIPLANC IN ( '4' , '5' ) END-EXEC. */

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
        /*" R0020-00-PROCESSA-DB-SELECT-4 */
        public void R0020_00_PROCESSA_DB_SELECT_4()
        {
            /*" -1034- EXEC SQL SELECT A.CODCLIEN, A.NUM_APOLICE, A.CODSUBES, A.FONTE, A.QTDPARATZ, A.SITUACAO, A.NUM_MATRICULA, A.CODPRODU, A.NRPARCE, B.PERIPGTO, B.TEM_SAF, B.TEM_CDG, B.RISCO, B.OPCAOPAG, B.CUSTOCAP_TOTAL, VALUE(B.ORIG_PRODU, ' ' ) INTO :V0PROP-CODCLIEN, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, :V0PROP-QTDPARATZ, :V0PROP-SITUACAO, :V0PROP-NRMATRFUN:V0PROP-INRMATRFUN, :V0PROP-CODPRODU, :V0PROP-NRPARCE, :V0PRVG-PERIPGTO, :V0PRVG-TEM-SAF:VIND-TEM-SAF, :V0PRVG-TEM-CDG:VIND-TEM-CDG, :V0PRVG-RISCO:VIND-RISCO, :V0PRVG-OPCAOPAG, :V0PRVG-CUSTOCAP-TOTAL, :V0PRVG-ORIG-PRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCTA-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC. */

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
                _.Move(executed_1.V0PROP_QTDPARATZ, V0PROP_QTDPARATZ);
                _.Move(executed_1.V0PROP_SITUACAO, V0PROP_SITUACAO);
                _.Move(executed_1.V0PROP_NRMATRFUN, V0PROP_NRMATRFUN);
                _.Move(executed_1.V0PROP_INRMATRFUN, V0PROP_INRMATRFUN);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_NRPARCE, V0PROP_NRPARCE);
                _.Move(executed_1.V0PRVG_PERIPGTO, V0PRVG_PERIPGTO);
                _.Move(executed_1.V0PRVG_TEM_SAF, V0PRVG_TEM_SAF);
                _.Move(executed_1.VIND_TEM_SAF, VIND_TEM_SAF);
                _.Move(executed_1.V0PRVG_TEM_CDG, V0PRVG_TEM_CDG);
                _.Move(executed_1.VIND_TEM_CDG, VIND_TEM_CDG);
                _.Move(executed_1.V0PRVG_RISCO, V0PRVG_RISCO);
                _.Move(executed_1.VIND_RISCO, VIND_RISCO);
                _.Move(executed_1.V0PRVG_OPCAOPAG, V0PRVG_OPCAOPAG);
                _.Move(executed_1.V0PRVG_CUSTOCAP_TOTAL, V0PRVG_CUSTOCAP_TOTAL);
                _.Move(executed_1.V0PRVG_ORIG_PRODU, V0PRVG_ORIG_PRODU);
            }


        }

        [StopWatch]
        /*" R0023-00-ATUALIZA-ESTORNO-DB-UPDATE-2 */
        public void R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2()
        {
            /*" -1197- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = :WHOST-SITUACAO, NSAC = :V0FTCF-NSAC, CODRET = :V0HCTA-CODRET, OCORHIST = :V0HCTA-OCORHISTCOB, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA >= 0 END-EXEC */

            var r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1 = new R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1()
            {
                V0HCTA_OCORHISTCOB = V0HCTA_OCORHISTCOB.ToString(),
                WHOST_SITUACAO = WHOST_SITUACAO.ToString(),
                V0HCTA_CODRET = V0HCTA_CODRET.ToString(),
                V0FTCF_NSAC = V0FTCF_NSAC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1.Execute(r0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0023_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-SECTION */
        private void R0030_00_ACESSO_CERTIF_SECTION()
        {
            /*" -1208- MOVE 'R0030-00-ACESSO-CERTIF' TO PARAGRAFO. */
            _.Move("R0030-00-ACESSO-CERTIF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1210- MOVE 'SELECT MIN V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1211- MOVE RF-IDENTIF-CLI TO V0HCTA-NRCERTIF. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, V0HCTA_NRCERTIF);

            /*" -1212- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -1213- MOVE RF-AGECTADEB TO V0HCTA-AGECTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_AGECTADEB, V0HCTA_AGECTADEB);

            /*" -1214- MOVE RF-COD-OPRCTADEB TO V0HCTA-OPRCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPRCTADEB, V0HCTA_OPRCTADEB);

            /*" -1216- MOVE RF-NUM-NUMCTADEB TO V0HCTA-NUMCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_NUMCTADEB, V0HCTA_NUMCTADEB);

            /*" -1217- IF RF-COD-MOVIMENTO EQUAL 0 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 0)
            {

                /*" -1218- MOVE '1' TO WHOST-TIPLANC. */
                _.Move("1", WHOST_TIPLANC);
            }


            /*" -1219- IF RF-COD-MOVIMENTO EQUAL 1 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 1)
            {

                /*" -1220- MOVE '4' TO WHOST-TIPLANC. */
                _.Move("4", WHOST_TIPLANC);
            }


            /*" -1221- IF RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -1222- MOVE '2' TO WHOST-TIPLANC. */
                _.Move("2", WHOST_TIPLANC);
            }


            /*" -1223- IF RF-COD-MOVIMENTO EQUAL 3 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 3)
            {

                /*" -1225- MOVE '5' TO WHOST-TIPLANC. */
                _.Move("5", WHOST_TIPLANC);
            }


            /*" -1226- MOVE 12 TO SII */
            _.Move(12, WS_HORAS.SII);

            /*" -1228- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1240- PERFORM R0030_00_ACESSO_CERTIF_DB_DECLARE_1 */

            R0030_00_ACESSO_CERTIF_DB_DECLARE_1();

            /*" -1242- PERFORM R0030_00_ACESSO_CERTIF_DB_OPEN_1 */

            R0030_00_ACESSO_CERTIF_DB_OPEN_1();

            /*" -1246- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1247- MOVE 13 TO SII */
            _.Move(13, WS_HORAS.SII);

            /*" -1249- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1255- PERFORM R0030_00_ACESSO_CERTIF_DB_FETCH_1 */

            R0030_00_ACESSO_CERTIF_DB_FETCH_1();

            /*" -1259- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1260- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1261- MOVE 'PARCELA NAO ENCONTRADA' TO RETERR-MENSAGEM */
                _.Move("PARCELA NAO ENCONTRADA", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -1261- PERFORM R0030_00_ACESSO_CERTIF_DB_CLOSE_1 */

                R0030_00_ACESSO_CERTIF_DB_CLOSE_1();

                /*" -1263- MOVE 1 TO WS-NAO-ACHEI */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                /*" -1265- GO TO R0030-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1265- PERFORM R0030_00_ACESSO_CERTIF_DB_CLOSE_2 */

            R0030_00_ACESSO_CERTIF_DB_CLOSE_2();

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-DECLARE-1 */
        public void R0030_00_ACESSO_CERTIF_DB_DECLARE_1()
        {
            /*" -1240- EXEC SQL DECLARE CHCONTA2 CURSOR FOR SELECT NRPARCEL, OCORRHISTCTA, NSAS, NSL, TIPLANC FROM SEGUROS.V0HISTCONTAVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND TIPLANC = '1' AND SITUACAO = '3' ORDER BY NRPARCEL, TIPLANC DESC END-EXEC. */
            CHCONTA2 = new VA1813B_CHCONTA2(true);
            string GetQuery_CHCONTA2()
            {
                var query = @$"SELECT NRPARCEL
							, 
							OCORRHISTCTA
							, 
							NSAS
							, 
							NSL
							, 
							TIPLANC 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE NRCERTIF = '{V0HCTA_NRCERTIF}' 
							AND TIPLANC = '1' 
							AND SITUACAO = '3' 
							ORDER BY NRPARCEL
							, TIPLANC DESC";

                return query;
            }
            CHCONTA2.GetQueryEvent += GetQuery_CHCONTA2;

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-OPEN-1 */
        public void R0030_00_ACESSO_CERTIF_DB_OPEN_1()
        {
            /*" -1242- EXEC SQL OPEN CHCONTA2 END-EXEC. */

            CHCONTA2.Open();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-DECLARE-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1()
        {
            /*" -1337- EXEC SQL DECLARE CHCONTA3 CURSOR FOR SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA, TIPLANC FROM SEGUROS.V0HISTCONTAVA WHERE AGECTADEB = :V0HCTA-AGECTADEB AND OPRCTADEB = :V0HCTA-OPRCTADEB AND NUMCTADEB = :V0HCTA-NUMCTADEB AND CODCONV = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS AND VLPRMTOT = :V0HCTA-VLPRMTOT AND SITUACAO = '3' ORDER BY NRCERTIF, NRPARCEL, TIPLANC DESC END-EXEC. */
            CHCONTA3 = new VA1813B_CHCONTA3(true);
            string GetQuery_CHCONTA3()
            {
                var query = @$"SELECT NRCERTIF
							, 
							NRPARCEL
							, 
							OCORRHISTCTA
							, 
							TIPLANC 
							FROM SEGUROS.V0HISTCONTAVA 
							WHERE AGECTADEB = '{V0HCTA_AGECTADEB}' 
							AND OPRCTADEB = '{V0HCTA_OPRCTADEB}' 
							AND NUMCTADEB = '{V0HCTA_NUMCTADEB}' 
							AND CODCONV = '{WHOST_CODCONV}' 
							AND NSAS = '{V0HCTA_NSAS}' 
							AND VLPRMTOT = '{V0HCTA_VLPRMTOT}' 
							AND SITUACAO = '3' 
							ORDER BY NRCERTIF
							, NRPARCEL
							, TIPLANC DESC";

                return query;
            }
            CHCONTA3.GetQueryEvent += GetQuery_CHCONTA3;

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-FETCH-1 */
        public void R0030_00_ACESSO_CERTIF_DB_FETCH_1()
        {
            /*" -1255- EXEC SQL FETCH CHCONTA2 INTO :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-NSAS, :V0HCTA-NSL, :V0HCTA-TIPLANC END-EXEC. */

            if (CHCONTA2.Fetch())
            {
                _.Move(CHCONTA2.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(CHCONTA2.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
                _.Move(CHCONTA2.V0HCTA_NSAS, V0HCTA_NSAS);
                _.Move(CHCONTA2.V0HCTA_NSL, V0HCTA_NSL);
                _.Move(CHCONTA2.V0HCTA_TIPLANC, V0HCTA_TIPLANC);
            }

        }

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-CLOSE-1 */
        public void R0030_00_ACESSO_CERTIF_DB_CLOSE_1()
        {
            /*" -1261- EXEC SQL CLOSE CHCONTA2 END-EXEC */

            CHCONTA2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0030_99_SAIDA*/

        [StopWatch]
        /*" R0030-00-ACESSO-CERTIF-DB-CLOSE-2 */
        public void R0030_00_ACESSO_CERTIF_DB_CLOSE_2()
        {
            /*" -1265- EXEC SQL CLOSE CHCONTA2 END-EXEC. */

            CHCONTA2.Close();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-SECTION */
        private void R0035_00_ACESSO_NUMCTADEB_SECTION()
        {
            /*" -1274- MOVE 'R0035-00-ACESSO-NUMCTADEB' TO PARAGRAFO. */
            _.Move("R0035-00-ACESSO-NUMCTADEB", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1276- MOVE 'SELECT MIN V0HISTCONTAVA' TO COMANDO. */
            _.Move("SELECT MIN V0HISTCONTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1277- MOVE RF-AGECTADEB TO V0HCTA-AGECTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_AGECTADEB, V0HCTA_AGECTADEB);

            /*" -1278- MOVE RF-COD-OPRCTADEB TO V0HCTA-OPRCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_COD_OPRCTADEB, V0HCTA_OPRCTADEB);

            /*" -1279- MOVE RF-NUM-NUMCTADEB TO V0HCTA-NUMCTADEB. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_BANCO.RF_NUM_NUMCTADEB, V0HCTA_NUMCTADEB);

            /*" -1281- MOVE RF-VLPRMTOT TO V0HCTA-VLPRMTOT. */
            _.Move(RET_CADASTRAMENTO.RF_VLPRMTOT, V0HCTA_VLPRMTOT);

            /*" -1286- MOVE RF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSA, V0HCTA_NSAS);

            /*" -1287- IF RF-IDENTIF-NSA NOT NUMERIC */

            if (!RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA.IsNumeric())
            {

                /*" -1288- IF WS-CODCONV EQUAL 6081 */

                if (WORK_AREA.WS_CODCONV == 6081)
                {

                    /*" -1289- ADD 19000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 19000;

                    /*" -1291- END-IF */
                }


                /*" -1292- IF WS-CODCONV EQUAL 6088 */

                if (WORK_AREA.WS_CODCONV == 6088)
                {

                    /*" -1293- ADD 23000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 23000;

                    /*" -1295- END-IF */
                }


                /*" -1296- IF WS-CODCONV EQUAL 6132 */

                if (WORK_AREA.WS_CODCONV == 6132)
                {

                    /*" -1297- ADD 28000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 28000;

                    /*" -1299- END-IF */
                }


                /*" -1300- IF WS-CODCONV EQUAL 6153 */

                if (WORK_AREA.WS_CODCONV == 6153)
                {

                    /*" -1301- ADD 30000 TO V0HCTA-NSAS */
                    V0HCTA_NSAS.Value = V0HCTA_NSAS + 30000;

                    /*" -1302- END-IF */
                }


                /*" -1303- ELSE */
            }
            else
            {


                /*" -1305- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS. */
                _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);
            }


            /*" -1307- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -1308- IF RF-COD-MOVIMENTO EQUAL 0 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 0)
            {

                /*" -1309- MOVE '1' TO WHOST-TIPLANC. */
                _.Move("1", WHOST_TIPLANC);
            }


            /*" -1310- IF RF-COD-MOVIMENTO EQUAL 1 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 1)
            {

                /*" -1311- MOVE '4' TO WHOST-TIPLANC. */
                _.Move("4", WHOST_TIPLANC);
            }


            /*" -1312- IF RF-COD-MOVIMENTO EQUAL 2 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 2)
            {

                /*" -1313- MOVE '2' TO WHOST-TIPLANC. */
                _.Move("2", WHOST_TIPLANC);
            }


            /*" -1314- IF RF-COD-MOVIMENTO EQUAL 3 */

            if (RET_CADASTRAMENTO.RF_COD_MOVIMENTO == 3)
            {

                /*" -1317- MOVE '5' TO WHOST-TIPLANC. */
                _.Move("5", WHOST_TIPLANC);
            }


            /*" -1318- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -1320- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1337- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1();

            /*" -1339- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1();

            /*" -1343- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1344- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -1346- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1351- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1 */

            R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1();

            /*" -1355- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1356- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1357- MOVE 'PARCELA NAO ENCONTRADA' TO RETERR-MENSAGEM */
                _.Move("PARCELA NAO ENCONTRADA", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -1357- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1 */

                R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1();

                /*" -1359- MOVE 1 TO WS-NAO-ACHEI */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                /*" -1361- GO TO R0035-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1361- PERFORM R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2 */

            R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-OPEN-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1()
        {
            /*" -1339- EXEC SQL OPEN CHCONTA3 END-EXEC. */

            CHCONTA3.Open();

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-FETCH-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_FETCH_1()
        {
            /*" -1351- EXEC SQL FETCH CHCONTA3 INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-TIPLANC END-EXEC. */

            if (CHCONTA3.Fetch())
            {
                _.Move(CHCONTA3.V0HCTA_NRCERTIF, V0HCTA_NRCERTIF);
                _.Move(CHCONTA3.V0HCTA_NRPARCEL, V0HCTA_NRPARCEL);
                _.Move(CHCONTA3.V0HCTA_OCORHISTCTA, V0HCTA_OCORHISTCTA);
                _.Move(CHCONTA3.V0HCTA_TIPLANC, V0HCTA_TIPLANC);
            }

        }

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-CLOSE-1 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_1()
        {
            /*" -1357- EXEC SQL CLOSE CHCONTA3 END-EXEC */

            CHCONTA3.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0035_99_SAIDA*/

        [StopWatch]
        /*" R0035-00-ACESSO-NUMCTADEB-DB-CLOSE-2 */
        public void R0035_00_ACESSO_NUMCTADEB_DB_CLOSE_2()
        {
            /*" -1361- EXEC SQL CLOSE CHCONTA3 END-EXEC. */

            CHCONTA3.Close();

        }

        [StopWatch]
        /*" R0036-00-ACESSO-NSAS-SECTION */
        private void R0036_00_ACESSO_NSAS_SECTION()
        {
            /*" -1411- MOVE 'R0036-00-ACESSO-NSAS     ' TO PARAGRAFO. */
            _.Move("R0036-00-ACESSO-NSAS     ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1413- MOVE 'SELECT V0HISTCONTAVA NSAS' TO COMANDO. */
            _.Move("SELECT V0HISTCONTAVA NSAS", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1414- MOVE RF-IDENTIF-NSA TO V0HCTA-NSAS. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, V0HCTA_NSAS);

            /*" -1415- MOVE RF-NSL TO V0HCTA-NSL. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, V0HCTA_NSL);

            /*" -1417- MOVE WS-CODCONV TO V0HCTA-CODCONV. */
            _.Move(WORK_AREA.WS_CODCONV, V0HCTA_CODCONV);

            /*" -1418- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -1420- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1434- PERFORM R0036_00_ACESSO_NSAS_DB_SELECT_1 */

            R0036_00_ACESSO_NSAS_DB_SELECT_1();

            /*" -1438- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1439- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1440- MOVE 'PARCELA NAO ENCONTRADA' TO RETERR-MENSAGEM */
                _.Move("PARCELA NAO ENCONTRADA", RETERR_RECORD.RETERR_MENSAGEM);

                /*" -1441- MOVE 1 TO WS-NAO-ACHEI */
                _.Move(1, WORK_AREA.WS_NAO_ACHEI);

                /*" -1442- GO TO R0036-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0036-00-ACESSO-NSAS-DB-SELECT-1 */
        public void R0036_00_ACESSO_NSAS_DB_SELECT_1()
        {
            /*" -1434- EXEC SQL SELECT NRCERTIF, NRPARCEL, OCORRHISTCTA, TIPLANC INTO :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCTA-OCORHISTCTA, :V0HCTA-TIPLANC FROM SEGUROS.V0HISTCONTAVA WHERE NSAS = :V0HCTA-NSAS AND NSL = :V0HCTA-NSL AND TIPLANC = '1' AND CODCONV = :V0HCTA-CODCONV END-EXEC. */

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
                _.Move(executed_1.V0HCTA_TIPLANC, V0HCTA_TIPLANC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0036_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-GERA-FITACEF-SECTION */
        private void R0050_00_GERA_FITACEF_SECTION()
        {
            /*" -1451- MOVE '0050-GERA-FITACEF' TO PARAGRAFO. */
            _.Move("0050-GERA-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1453- MOVE 'SELECT V0FITACEF' TO COMANDO. */
            _.Move("SELECT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1454- MOVE 16 TO SII */
            _.Move(16, WS_HORAS.SII);

            /*" -1456- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1461- PERFORM R0050_00_GERA_FITACEF_DB_SELECT_1 */

            R0050_00_GERA_FITACEF_DB_SELECT_1();

            /*" -1465- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1466- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1467- PERFORM R0053-00-UPDATE-FITACEF */

                R0053_00_UPDATE_FITACEF_SECTION();

                /*" -1468- ELSE */
            }
            else
            {


                /*" -1468- PERFORM R0055-00-INSERT-FITACEF. */

                R0055_00_INSERT_FITACEF_SECTION();
            }


        }

        [StopWatch]
        /*" R0050-00-GERA-FITACEF-DB-SELECT-1 */
        public void R0050_00_GERA_FITACEF_DB_SELECT_1()
        {
            /*" -1461- EXEC SQL SELECT DATA_GERACAO INTO :V0FTCF-DTRET FROM SEGUROS.V0FITACEF WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0053-00-UPDATE-FITACEF-SECTION */
        private void R0053_00_UPDATE_FITACEF_SECTION()
        {
            /*" -1479- MOVE 'R0053-00-UPDATE-FITACEF' TO PARAGRAFO. */
            _.Move("R0053-00-UPDATE-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1481- MOVE 'UPDATE V0FITACEF' TO COMANDO. */
            _.Move("UPDATE V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1482- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -1483- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -1484- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -1486- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -1487- MOVE 17 TO SII */
            _.Move(17, WS_HORAS.SII);

            /*" -1489- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1497- PERFORM R0053_00_UPDATE_FITACEF_DB_UPDATE_1 */

            R0053_00_UPDATE_FITACEF_DB_UPDATE_1();

            /*" -1499- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R0053-00-UPDATE-FITACEF-DB-UPDATE-1 */
        public void R0053_00_UPDATE_FITACEF_DB_UPDATE_1()
        {
            /*" -1497- EXEC SQL UPDATE SEGUROS.V0FITACEF SET DATA_GERACAO = :V0FTCF-DTRET2, QTDE_LANC_DEB_RET = :V0FTCF-QTLANCDB, TOT_DEB_EFET = :V0FTCF-TOTDBEFET, TOT_DEB_NAO_EFET = :V0FTCF-TOTDBNEFET, QTDE_DEB_EFET = :V0FTCF-QTDBEFET WHERE NSAC = :V0FTCF-NSAC END-EXEC. */

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
            /*" -1509- MOVE 'R0055-00-INSERT-FITACEF' TO PARAGRAFO. */
            _.Move("R0055-00-INSERT-FITACEF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1511- MOVE 'INSERT V0FITACEF' TO COMANDO. */
            _.Move("INSERT V0FITACEF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1512- MOVE RZ-QTDE-REGISTROS TO V0FTCF-QTREG. */
            _.Move(RET_TRAILLER.RZ_QTDE_REGISTROS, V0FTCF_QTREG);

            /*" -1513- MOVE WS-REGISTROS TO V0FTCF-QTLANCDB. */
            _.Move(WORK_AREA.WS_REGISTROS, V0FTCF_QTLANCDB);

            /*" -1514- MOVE WS-QTDBEFET TO V0FTCF-QTDBEFET. */
            _.Move(WORK_AREA.WS_QTDBEFET, V0FTCF_QTDBEFET);

            /*" -1515- MOVE WS-ACG-TOTDBEFET TO V0FTCF-TOTDBEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBEFET, V0FTCF_TOTDBEFET);

            /*" -1517- MOVE WS-ACG-TOTDBNEFET TO V0FTCF-TOTDBNEFET. */
            _.Move(WORK_AREA.WS_ACG_TOTDBNEFET, V0FTCF_TOTDBNEFET);

            /*" -1518- MOVE 18 TO SII */
            _.Move(18, WS_HORAS.SII);

            /*" -1520- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1534- PERFORM R0055_00_INSERT_FITACEF_DB_INSERT_1 */

            R0055_00_INSERT_FITACEF_DB_INSERT_1();

            /*" -1536- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

        }

        [StopWatch]
        /*" R0055-00-INSERT-FITACEF-DB-INSERT-1 */
        public void R0055_00_INSERT_FITACEF_DB_INSERT_1()
        {
            /*" -1534- EXEC SQL INSERT INTO SEGUROS.V0FITACEF VALUES (:V0FTCF-NSAC, :V0FTCF-DTRET, :V0FTCF-VERSAO, :V0FTCF-QTREG, :V0FTCF-QTLANCDB, :V0FTCF-TOTDBEFET, :V0FTCF-TOTDBNEFET, 0, 0, 0, :V0FTCF-QTDBEFET, 0) END-EXEC. */

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
        /*" R1000-00-QUITA-PARCELA-SECTION */
        private void R1000_00_QUITA_PARCELA_SECTION()
        {
            /*" -1547- MOVE 'R1000-00-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("R1000-00-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1548- ADD 1 TO WS-QTDBEFET. */
            WORK_AREA.WS_QTDBEFET.Value = WORK_AREA.WS_QTDBEFET + 1;

            /*" -1550- MOVE '1' TO V0HCTA-SITUACAO. */
            _.Move("1", V0HCTA_SITUACAO);

            /*" -1551- COMPUTE V0HCOB-OCORHIST = V0HCOB-OCORHIST + 1. */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -1553- MOVE V0HCOB-OCORHIST TO V0HCTA-OCORHISTCOB. */
            _.Move(V0HCOB_OCORHIST, V0HCTA_OCORHISTCOB);

            /*" -1557- MOVE V0OPCP-OPCAOPAG TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move(V0OPCP_OPCAOPAG, V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -1559- MOVE 'SELECT V0COBERPROPVA' TO COMANDO. */
            _.Move("SELECT V0COBERPROPVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1560- MOVE 21 TO SII */
            _.Move(21, WS_HORAS.SII);

            /*" -1562- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1585- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_1 */

            R1000_00_QUITA_PARCELA_DB_SELECT_1();

            /*" -1589- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1590- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1592- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1593- IF V0COBP-VLCUSTAUXF-I < ZEROS */

            if (V0COBP_VLCUSTAUXF_I < 00)
            {

                /*" -1594- MOVE ZEROS TO V0COBP-IMPSEGAUXF */
                _.Move(0, V0COBP_IMPSEGAUXF);

                /*" -1596- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1598- MOVE 0 TO WS-DIFERENCA. */
            _.Move(0, WORK_AREA.WS_DIFERENCA);

            /*" -1599- IF V0HCOB-SITUACAO EQUAL '1' */

            if (V0HCOB_SITUACAO == "1")
            {

                /*" -1600- MOVE 204 TO V0HCTB-CODOPER */
                _.Move(204, V0HCTB_CODOPER);

                /*" -1601- MOVE 601 TO V0DIFP-CODOPER */
                _.Move(601, V0DIFP_CODOPER);

                /*" -1602- MOVE V0HCTA-VLPRMTOT TO WS-DIFERENCA */
                _.Move(V0HCTA_VLPRMTOT, WORK_AREA.WS_DIFERENCA);

                /*" -1604- MOVE 0 TO V0DIFP-PRMDEVVG V0DIFP-PRMDEVAP */
                _.Move(0, V0DIFP_PRMDEVVG, V0DIFP_PRMDEVAP);

                /*" -1612- ELSE */
            }
            else
            {


                /*" -1613- IF V0HCTA-VLPRMTOT EQUAL V0HCOB-VLPRMTOT */

                if (V0HCTA_VLPRMTOT == V0HCOB_VLPRMTOT)
                {

                    /*" -1614- MOVE 202 TO V0HCTB-CODOPER */
                    _.Move(202, V0HCTB_CODOPER);

                    /*" -1615- ELSE */
                }
                else
                {


                    /*" -1616- MOVE V0PARC-PRMVG TO V0DIFP-PRMDEVVG */
                    _.Move(V0PARC_PRMVG, V0DIFP_PRMDEVVG);

                    /*" -1617- MOVE V0PARC-PRMAP TO V0DIFP-PRMDEVAP */
                    _.Move(V0PARC_PRMAP, V0DIFP_PRMDEVAP);

                    /*" -1618- IF V0HCTA-VLPRMTOT LESS V0HCOB-VLPRMTOT */

                    if (V0HCTA_VLPRMTOT < V0HCOB_VLPRMTOT)
                    {

                        /*" -1619- MOVE 206 TO V0HCTB-CODOPER */
                        _.Move(206, V0HCTB_CODOPER);

                        /*" -1620- MOVE 401 TO V0DIFP-CODOPER */
                        _.Move(401, V0DIFP_CODOPER);

                        /*" -1622- COMPUTE WS-DIFERENCA = V0HCOB-VLPRMTOT - V0HCTA-VLPRMTOT */
                        WORK_AREA.WS_DIFERENCA.Value = V0HCOB_VLPRMTOT - V0HCTA_VLPRMTOT;

                        /*" -1623- ELSE */
                    }
                    else
                    {


                        /*" -1624- MOVE 207 TO V0HCTB-CODOPER */
                        _.Move(207, V0HCTB_CODOPER);

                        /*" -1625- MOVE 602 TO V0DIFP-CODOPER */
                        _.Move(602, V0DIFP_CODOPER);

                        /*" -1628- COMPUTE WS-DIFERENCA = V0HCTA-VLPRMTOT - V0HCOB-VLPRMTOT. */
                        WORK_AREA.WS_DIFERENCA.Value = V0HCTA_VLPRMTOT - V0HCOB_VLPRMTOT;
                    }

                }

            }


            /*" -1629- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1630- IF V0HCOB-VLPRMTOT GREATER 0 */

                if (V0HCOB_VLPRMTOT > 0)
                {

                    /*" -1631- COMPUTE WS-PC-VG = V0PARC-PRMVG / V0HCOB-VLPRMTOT */
                    WORK_AREA.WS_PC_VG.Value = V0PARC_PRMVG / V0HCOB_VLPRMTOT;

                    /*" -1632- COMPUTE V0DIFP-PRMPAGVG = V0HCTA-VLPRMTOT * WS-PC-VG */
                    V0DIFP_PRMPAGVG.Value = V0HCTA_VLPRMTOT * WORK_AREA.WS_PC_VG;

                    /*" -1634- COMPUTE V0DIFP-PRMPAGAP = V0HCTA-VLPRMTOT - V0DIFP-PRMPAGVG */
                    V0DIFP_PRMPAGAP.Value = V0HCTA_VLPRMTOT - V0DIFP_PRMPAGVG;

                    /*" -1635- MOVE V0DIFP-PRMPAGVG TO V0PARC-PRMVG */
                    _.Move(V0DIFP_PRMPAGVG, V0PARC_PRMVG);

                    /*" -1636- MOVE V0DIFP-PRMPAGAP TO V0PARC-PRMAP */
                    _.Move(V0DIFP_PRMPAGAP, V0PARC_PRMAP);

                    /*" -1637- COMPUTE V0DIFP-PRMDIFVG = WS-DIFERENCA * WS-PC-VG */
                    V0DIFP_PRMDIFVG.Value = WORK_AREA.WS_DIFERENCA * WORK_AREA.WS_PC_VG;

                    /*" -1639- COMPUTE V0DIFP-PRMDIFAP = WS-DIFERENCA - V0DIFP-PRMDIFVG */
                    V0DIFP_PRMDIFAP.Value = WORK_AREA.WS_DIFERENCA - V0DIFP_PRMDIFVG;

                    /*" -1640- ELSE */
                }
                else
                {


                    /*" -1643- MOVE V0HCTA-VLPRMTOT TO V0DIFP-PRMPAGVG V0DIFP-PRMDIFVG V0PARC-PRMVG */
                    _.Move(V0HCTA_VLPRMTOT, V0DIFP_PRMPAGVG, V0DIFP_PRMDIFVG, V0PARC_PRMVG);

                    /*" -1647- MOVE 0 TO V0DIFP-PRMPAGAP V0DIFP-PRMDIFAP V0PARC-PRMAP. */
                    _.Move(0, V0DIFP_PRMPAGAP, V0DIFP_PRMDIFAP, V0PARC_PRMAP);
                }

            }


            /*" -1648- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1649- IF V0PARC-PRMAP LESS ZEROS */

                if (V0PARC_PRMAP < 00)
                {

                    /*" -1650- COMPUTE V0PARC-PRMTOTVG = V0PARC-PRMVG + V0PARC-PRMAP */
                    V0PARC_PRMTOTVG.Value = V0PARC_PRMVG + V0PARC_PRMAP;

                    /*" -1652- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1653- ELSE */
                    }
                    else
                    {


                        /*" -1654- MOVE V0PARC-PRMTOTVG TO V0PARC-PRMVG */
                        _.Move(V0PARC_PRMTOTVG, V0PARC_PRMVG);

                        /*" -1656- MOVE ZEROS TO V0PARC-PRMAP. */
                        _.Move(0, V0PARC_PRMAP);
                    }

                }

            }


            /*" -1657- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1658- IF V0DIFP-PRMPAGAP LESS ZEROS */

                if (V0DIFP_PRMPAGAP < 00)
                {

                    /*" -1660- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMPAGVG + V0DIFP-PRMPAGAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMPAGVG + V0DIFP_PRMPAGAP;

                    /*" -1662- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1663- ELSE */
                    }
                    else
                    {


                        /*" -1664- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMPAGVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMPAGVG);

                        /*" -1666- MOVE ZEROS TO V0DIFP-PRMPAGAP. */
                        _.Move(0, V0DIFP_PRMPAGAP);
                    }

                }

            }


            /*" -1667- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1668- IF V0DIFP-PRMDIFAP LESS ZEROS */

                if (V0DIFP_PRMDIFAP < 00)
                {

                    /*" -1670- COMPUTE V0PARC-PRMTOTVG = V0DIFP-PRMDIFVG + V0DIFP-PRMDIFAP */
                    V0PARC_PRMTOTVG.Value = V0DIFP_PRMDIFVG + V0DIFP_PRMDIFAP;

                    /*" -1672- IF V0PARC-PRMTOTVG LESS ZEROS NEXT SENTENCE */

                    if (V0PARC_PRMTOTVG < 00)
                    {

                        /*" -1673- ELSE */
                    }
                    else
                    {


                        /*" -1674- MOVE V0PARC-PRMTOTVG TO V0DIFP-PRMDIFVG */
                        _.Move(V0PARC_PRMTOTVG, V0DIFP_PRMDIFVG);

                        /*" -1681- MOVE ZEROS TO V0DIFP-PRMDIFAP. */
                        _.Move(0, V0DIFP_PRMDIFAP);
                    }

                }

            }


            /*" -1682- IF V0PRVG-TEM-SAF = 'N' */

            if (V0PRVG_TEM_SAF == "N")
            {

                /*" -1684- MOVE ZEROS TO V0COBP-VLCUSTAUXF. */
                _.Move(0, V0COBP_VLCUSTAUXF);
            }


            /*" -1685- IF V0PRVG-TEM-CDG = 'N' */

            if (V0PRVG_TEM_CDG == "N")
            {

                /*" -1687- MOVE ZEROS TO V0COBP-VLCUSTCDG. */
                _.Move(0, V0COBP_VLCUSTCDG);
            }


            /*" -1688- IF V0PRVG-CUSTOCAP-TOTAL = 'N' */

            if (V0PRVG_CUSTOCAP_TOTAL == "N")
            {

                /*" -1691- COMPUTE V0COBP-VLCUSTCAP = V0COBP-VLCUSTCAP * V0COBP-QTTITCAP. */
                V0COBP_VLCUSTCAP.Value = V0COBP_VLCUSTCAP * V0COBP_QTTITCAP;
            }


            /*" -1701- COMPUTE V0HCTVA-VLCOBADIC = V0COBP-VLCUSTCDG + V0COBP-VLCUSTAUXF + V0COBP-VLCUSTCAP. */
            V0HCTVA_VLCOBADIC.Value = V0COBP_VLCUSTCDG + V0COBP_VLCUSTAUXF + V0COBP_VLCUSTCAP;

            /*" -1702- IF V0SIST-DTMOVABE NOT GREATER '2001-09-30' */

            if (V0SIST_DTMOVABE <= "2001-09-30")
            {

                /*" -1704- COMPUTE V0HCTVA-PRMVG = V0PARC-PRMVG - V0HCTVA-VLCOBADIC */
                V0HCTVA_PRMVG.Value = V0PARC_PRMVG - V0HCTVA_VLCOBADIC;

                /*" -1705- ELSE */
            }
            else
            {


                /*" -1707- MOVE V0PARC-PRMVG TO V0HCTVA-PRMVG. */
                _.Move(V0PARC_PRMVG, V0HCTVA_PRMVG);
            }


            /*" -1708- IF V0COBP-PRMVG > ZEROS */

            if (V0COBP_PRMVG > 00)
            {

                /*" -1709- COMPUTE WS-PCT-COB-VG = V0COBP-PRMVG / V0COBP-VLPREMIO */
                WORK_AREA.WS_PCT_COB_VG.Value = V0COBP_PRMVG / V0COBP_VLPREMIO;

                /*" -1711- COMPUTE V0HCTVA-PRMVG ROUNDED = V0HCTA-VLPRMTOT * WS-PCT-COB-VG */
                V0HCTVA_PRMVG.Value = V0HCTA_VLPRMTOT * WORK_AREA.WS_PCT_COB_VG;

                /*" -1712- COMPUTE V0HCTVA-PRMAP = V0HCTA-VLPRMTOT - V0HCTVA-PRMVG */
                V0HCTVA_PRMAP.Value = V0HCTA_VLPRMTOT - V0HCTVA_PRMVG;

                /*" -1713- ELSE */
            }
            else
            {


                /*" -1714- MOVE ZEROS TO V0HCTVA-PRMVG */
                _.Move(0, V0HCTVA_PRMVG);

                /*" -1721- MOVE V0HCTA-VLPRMTOT TO V0HCTVA-PRMAP. */
                _.Move(V0HCTA_VLPRMTOT, V0HCTVA_PRMAP);
            }


            /*" -1723- MOVE 'INSERT V0HISTCONTABILVA' TO COMANDO. */
            _.Move("INSERT V0HISTCONTABILVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1724- MOVE 23 TO SII */
            _.Move(23, WS_HORAS.SII);

            /*" -1726- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1743- PERFORM R1000_00_QUITA_PARCELA_DB_INSERT_1 */

            R1000_00_QUITA_PARCELA_DB_INSERT_1();

            /*" -1747- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1748- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1750- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1751- IF (V0HCOB-SITUACAO NOT EQUAL ' ' AND '0' AND '5' ) */

            if ((!V0HCOB_SITUACAO.In(" ", "0", "5")))
            {

                /*" -1752- MOVE 'UPDATE V0HISTCOBVA 1' TO COMANDO */
                _.Move("UPDATE V0HISTCOBVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1753- MOVE 24 TO SII */
                _.Move(24, WS_HORAS.SII);

                /*" -1754- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1761- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_1 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_1();

                /*" -1763- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1764- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1765- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1766- END-IF */
                }


                /*" -1767- ELSE */
            }
            else
            {


                /*" -1768- MOVE 'UPDATE V0HISTCOBVA 2' TO COMANDO */
                _.Move("UPDATE V0HISTCOBVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1769- MOVE 25 TO SII */
                _.Move(25, WS_HORAS.SII);

                /*" -1770- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1779- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_2 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_2();

                /*" -1781- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1782- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1783- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1784- END-IF */
                }


                /*" -1785- MOVE 'UPDATE V0DIFPARCELVA' TO COMANDO */
                _.Move("UPDATE V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1786- MOVE 26 TO SII */
                _.Move(26, WS_HORAS.SII);

                /*" -1787- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1792- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_3 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_3();

                /*" -1794- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1795- IF SQLCODE NOT EQUAL ZEROES AND 100 */

                if (!DB.SQLCODE.In("00", "100"))
                {

                    /*" -1796- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1797- END-IF */
                }


                /*" -1798- IF V0PROP-QTDPARATZ GREATER 0 */

                if (V0PROP_QTDPARATZ > 0)
                {

                    /*" -1799- SUBTRACT 1 FROM V0PROP-QTDPARATZ */
                    V0PROP_QTDPARATZ.Value = V0PROP_QTDPARATZ - 1;

                    /*" -1800- MOVE 'UPDATE V0PROPOSTAVA 1' TO COMANDO */
                    _.Move("UPDATE V0PROPOSTAVA 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1801- MOVE 27 TO SII */
                    _.Move(27, WS_HORAS.SII);

                    /*" -1802- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -1806- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_4 */

                    R1000_00_QUITA_PARCELA_DB_UPDATE_4();

                    /*" -1808- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -1809- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1811- GO TO R9999-00-ROT-ERRO. */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;
                    }

                }

            }


            /*" -1812- IF V0PROP-SITUACAO EQUAL '8' */

            if (V0PROP_SITUACAO == "8")
            {

                /*" -1813- MOVE 'UPDATE V0PROPOSTAVA 2' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 2", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1814- MOVE 28 TO SII */
                _.Move(28, WS_HORAS.SII);

                /*" -1815- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1820- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_5 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_5();

                /*" -1822- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1823- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1825- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1827- IF V0PROP-SITUACAO EQUAL '6' AND V0PROP-NRPARCE EQUAL V0HCTA-NRPARCEL */

            if (V0PROP_SITUACAO == "6" && V0PROP_NRPARCE == V0HCTA_NRPARCEL)
            {

                /*" -1828- MOVE 'UPDATE V0PROPOSTAVA 3' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -1829- MOVE 29 TO SII */
                _.Move(29, WS_HORAS.SII);

                /*" -1830- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -1836- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_6 */

                R1000_00_QUITA_PARCELA_DB_UPDATE_6();

                /*" -1838- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -1839- IF SQLCODE NOT EQUAL ZEROES */

                if (DB.SQLCODE != 00)
                {

                    /*" -1841- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1842- MOVE 'SELECT V0CDGCOBER' TO COMANDO. */
            _.Move("SELECT V0CDGCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1843- MOVE 'UPDATE V0PROPOSTAVA 3' TO COMANDO */
            _.Move("UPDATE V0PROPOSTAVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1844- MOVE 30 TO SII */
            _.Move(30, WS_HORAS.SII);

            /*" -1846- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1852- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_2 */

            R1000_00_QUITA_PARCELA_DB_SELECT_2();

            /*" -1855- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1856- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1857- IF V0PRVG-TEM-CDG = 'S' */

                if (V0PRVG_TEM_CDG == "S")
                {

                    /*" -1858- PERFORM R1100-00-REPASSA-CDG */

                    R1100_00_REPASSA_CDG_SECTION();

                    /*" -1860- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1861- ELSE */
                }

            }
            else
            {


                /*" -1865- IF SQLCODE EQUAL 100 AND V0PRVG-TEM-CDG = 'S' AND V0COBP-VLCUSTCDG > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PRVG_TEM_CDG == "S" && V0COBP_VLCUSTCDG > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -1867- PERFORM R1099-00-INCLUI-CDG. */

                    R1099_00_INCLUI_CDG_SECTION();
                }

            }


            /*" -1868- MOVE 'SELECT V0SAFCOBER' TO COMANDO. */
            _.Move("SELECT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1869- MOVE 31 TO SII */
            _.Move(31, WS_HORAS.SII);

            /*" -1871- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1877- PERFORM R1000_00_QUITA_PARCELA_DB_SELECT_3 */

            R1000_00_QUITA_PARCELA_DB_SELECT_3();

            /*" -1880- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1881- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -1882- IF V0PRVG-TEM-SAF = 'S' */

                if (V0PRVG_TEM_SAF == "S")
                {

                    /*" -1883- PERFORM R1200-00-REPASSA-SAF */

                    R1200_00_REPASSA_SAF_SECTION();

                    /*" -1885- ELSE NEXT SENTENCE */
                }
                else
                {


                    /*" -1886- ELSE */
                }

            }
            else
            {


                /*" -1890- IF SQLCODE EQUAL 100 AND V0PRVG-TEM-SAF = 'S' AND V0COBP-VLCUSTAUXF > ZEROS AND V0PROP-SITUACAO = '3' OR '6' */

                if (DB.SQLCODE == 100 && V0PRVG_TEM_SAF == "S" && V0COBP_VLCUSTAUXF > 00 && V0PROP_SITUACAO.In("3", "6"))
                {

                    /*" -1892- PERFORM R1199-00-INCLUI-SAF. */

                    R1199_00_INCLUI_SAF_SECTION();
                }

            }


            /*" -1893- IF WS-DIFERENCA NOT EQUAL 0 */

            if (WORK_AREA.WS_DIFERENCA != 0)
            {

                /*" -1895- PERFORM R1050-00-GRAVA-DIFERENCA. */

                R1050_00_GRAVA_DIFERENCA_SECTION();
            }


            /*" -1897- MOVE 'R1000-00-QUITA-PARCELA' TO PARAGRAFO. */
            _.Move("R1000-00-QUITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1898- MOVE 'UPDATE V0FITASASSE 1' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE 1", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1899- MOVE 32 TO SII */
            _.Move(32, WS_HORAS.SII);

            /*" -1901- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1908- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_7 */

            R1000_00_QUITA_PARCELA_DB_UPDATE_7();

            /*" -1911- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1912- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1913- DISPLAY V0HCTA-NRCERTIF ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"{V0HCTA_NRCERTIF} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -1915- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1918- ADD V0HCTA-VLPRMTOT TO WS-ACG-TOTDBEFET. */
            WORK_AREA.WS_ACG_TOTDBEFET.Value = WORK_AREA.WS_ACG_TOTDBEFET + V0HCTA_VLPRMTOT;

            /*" -1920- COMPUTE V0CAPI-NRPARCEL = V0HCTA-NRPARCEL - 1. */
            V0CAPI_NRPARCEL.Value = V0HCTA_NRPARCEL - 1;

            /*" -1921- MOVE 'UPDATE V0PARCELCAPVG' TO COMANDO. */
            _.Move("UPDATE V0PARCELCAPVG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1922- MOVE 33 TO SII */
            _.Move(33, WS_HORAS.SII);

            /*" -1924- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1931- PERFORM R1000_00_QUITA_PARCELA_DB_UPDATE_8 */

            R1000_00_QUITA_PARCELA_DB_UPDATE_8();

            /*" -1934- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1935- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1937- IF SQLCODE = 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -1938- ELSE */
                }
                else
                {


                    /*" -1940- DISPLAY '*** VA1813B - ERRO UPDATE V0PARCELCAPVG ' V0HCTA-NRCERTIF ' ' V0CAPI-NRPARCEL ' ' SQLCODE */

                    $"*** VA1813B - ERRO UPDATE V0PARCELCAPVG {V0HCTA_NRCERTIF} {V0CAPI_NRPARCEL} {DB.SQLCODE}"
                    .Display();

                    /*" -1940- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-1 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_1()
        {
            /*" -1585- EXEC SQL SELECT PRMVG, PRMAP, PRMVG + PRMAP, VLCUSTCDG, VLCUSTAUXF, IMPSEGCDC, IMPSEGAUXF, VLCUSTCAP, QTTITCAP INTO :V0COBP-PRMVG, :V0COBP-PRMAP, :V0COBP-VLPREMIO, :V0COBP-VLCUSTCDG, :V0COBP-VLCUSTAUXF:V0COBP-VLCUSTAUXF-I, :V0COBP-IMPSEGCDG, :V0COBP-IMPSEGAUXF:V0COBP-IMPSEGAUXF-I, :V0COBP-VLCUSTCAP, :V0COBP-QTTITCAP FROM SEGUROS.V0COBERPROPVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTINIVIG <= :V0PARC-DTVENCTO AND DTTERVIG >= :V0PARC-DTVENCTO END-EXEC. */

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
                _.Move(executed_1.V0COBP_VLCUSTCDG, V0COBP_VLCUSTCDG);
                _.Move(executed_1.V0COBP_VLCUSTAUXF, V0COBP_VLCUSTAUXF);
                _.Move(executed_1.V0COBP_VLCUSTAUXF_I, V0COBP_VLCUSTAUXF_I);
                _.Move(executed_1.V0COBP_IMPSEGCDG, V0COBP_IMPSEGCDG);
                _.Move(executed_1.V0COBP_IMPSEGAUXF, V0COBP_IMPSEGAUXF);
                _.Move(executed_1.V0COBP_IMPSEGAUXF_I, V0COBP_IMPSEGAUXF_I);
                _.Move(executed_1.V0COBP_VLCUSTCAP, V0COBP_VLCUSTCAP);
                _.Move(executed_1.V0COBP_QTTITCAP, V0COBP_QTTITCAP);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-INSERT-1 */
        public void R1000_00_QUITA_PARCELA_DB_INSERT_1()
        {
            /*" -1743- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0HCOB-NRTIT, :V0HCOB-OCORHIST, :V0PROP-NUM-APOLICE, :V0PROP-CODSUBES, :V0PROP-FONTE, 0, :V0HCTVA-PRMVG, :V0HCTVA-PRMAP, :V0HCOB-DTVENCTO, '0' , :V0HCTB-CODOPER, CURRENT TIMESTAMP, NULL) END-EXEC. */

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
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0HCTB_CODOPER = V0HCTB_CODOPER.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1.Execute(r1000_00_QUITA_PARCELA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-1 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_1()
        {
            /*" -1761- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET OCORHIST = :V0HCOB-OCORHIST, OPCAOPAG = :V0HCOB-OPCAOPAG WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_OPCAOPAG = V0HCOB_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-2 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_2()
        {
            /*" -1779- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, VLPRMTOT = :V0HCTA-VLPRMTOT, OCORHIST = :V0HCOB-OCORHIST, OPCAOPAG = :V0HCOB-OPCAOPAG WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_OPCAOPAG = V0HCOB_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1050-00-GRAVA-DIFERENCA-SECTION */
        private void R1050_00_GRAVA_DIFERENCA_SECTION()
        {
            /*" -1956- MOVE 'R1050-00-GRAVA-DIFERENCA' TO PARAGRAFO. */
            _.Move("R1050-00-GRAVA-DIFERENCA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1956- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1958- MOVE V0HCTA-NRPARCEL TO V0DIFP-NRPARCEL. */
            _.Move(V0HCTA_NRPARCEL, V0DIFP_NRPARCEL);

            /*" -0- FLUXCONTROL_PERFORM R1050_00_LOOP */

            R1050_00_LOOP();

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-3 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_3()
        {
            /*" -1792- EXEC SQL UPDATE SEGUROS.V0DIFPARCELVA SET SITUACAO = '1' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_3_Update1);

        }

        [StopWatch]
        /*" R1050-00-LOOP */
        private void R1050_00_LOOP(bool isPerform = false)
        {
            /*" -1964- MOVE 'INSERT V0DIFPARCELVA' TO COMANDO. */
            _.Move("INSERT V0DIFPARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -1965- MOVE 34 TO SII */
            _.Move(34, WS_HORAS.SII);

            /*" -1966- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1981- PERFORM R1050_00_LOOP_DB_INSERT_1 */

            R1050_00_LOOP_DB_INSERT_1();

            /*" -1984- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1985- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -1986- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1987- ADD 1 TO V0DIFP-NRPARCEL */
                    V0DIFP_NRPARCEL.Value = V0DIFP_NRPARCEL + 1;

                    /*" -1988- MOVE 'SELECT V0PARCELVA' TO COMANDO */
                    _.Move("SELECT V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                    /*" -1989- MOVE 35 TO SII */
                    _.Move(35, WS_HORAS.SII);

                    /*" -1990- PERFORM R9000-00-INICIO */

                    R9000_00_INICIO_SECTION();

                    /*" -1996- PERFORM R1050_00_LOOP_DB_SELECT_1 */

                    R1050_00_LOOP_DB_SELECT_1();

                    /*" -1998- PERFORM R9100-00-TERMINO */

                    R9100_00_TERMINO_SECTION();

                    /*" -1999- IF SQLCODE NOT EQUAL ZEROES */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2000- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -2001- END-IF */
                    }


                    /*" -2002- GO TO R1050-00-LOOP */
                    new Task(() => R1050_00_LOOP()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -2003- ELSE */
                }
                else
                {


                    /*" -2005- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -2005- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

        }

        [StopWatch]
        /*" R1050-00-LOOP-DB-INSERT-1 */
        public void R1050_00_LOOP_DB_INSERT_1()
        {
            /*" -1981- EXEC SQL INSERT INTO SEGUROS.V0DIFPARCELVA VALUES (:V0HCTA-NRCERTIF, 9999, :V0DIFP-NRPARCEL, :V0DIFP-CODOPER, :V0PARC-DTVENCTO, :V0DIFP-PRMDEVVG, :V0DIFP-PRMDEVAP, :V0DIFP-PRMPAGVG, :V0DIFP-PRMPAGAP, :V0DIFP-PRMDIFVG, :V0DIFP-PRMDIFAP, 0, ' ' ) END-EXEC. */

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
        /*" R1050-00-LOOP-DB-SELECT-1 */
        public void R1050_00_LOOP_DB_SELECT_1()
        {
            /*" -1996- EXEC SQL SELECT DTVENCTO INTO :V0PARC-DTVENCTO FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0DIFP-NRPARCEL END-EXEC */

            var r1050_00_LOOP_DB_SELECT_1_Query1 = new R1050_00_LOOP_DB_SELECT_1_Query1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0DIFP_NRPARCEL = V0DIFP_NRPARCEL.ToString(),
            };

            var executed_1 = R1050_00_LOOP_DB_SELECT_1_Query1.Execute(r1050_00_LOOP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_DTVENCTO, V0PARC_DTVENCTO);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-4 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_4()
        {
            /*" -1806- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET QTDPARATZ = :V0PROP-QTDPARATZ WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1()
            {
                V0PROP_QTDPARATZ = V0PROP_QTDPARATZ.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-2 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_2()
        {
            /*" -1852- EXEC SQL SELECT VLCUSTCDG INTO :V0CDGC-VLCUSTCDG FROM SEGUROS.V0CDGCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_2_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CDGC_VLCUSTCDG, V0CDGC_VLCUSTCDG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-SELECT-3 */
        public void R1000_00_QUITA_PARCELA_DB_SELECT_3()
        {
            /*" -1877- EXEC SQL SELECT VLCUSTAUX INTO :V0SAFC-VLCUSTSAF FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_SELECT_3_Query1 = new R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1000_00_QUITA_PARCELA_DB_SELECT_3_Query1.Execute(r1000_00_QUITA_PARCELA_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_VLCUSTSAF, V0SAFC_VLCUSTSAF);
            }


        }

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-5 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_5()
        {
            /*" -1820- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '0' , DTQITBCO = :V0PARC-DTVENCTO WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1()
            {
                V0PARC_DTVENCTO = V0PARC_DTVENCTO.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_5_Update1);

        }

        [StopWatch]
        /*" R1099-00-INCLUI-CDG-SECTION */
        private void R1099_00_INCLUI_CDG_SECTION()
        {
            /*" -2016- MOVE 'R1099-00-INCLUI-CDG' TO PARAGRAFO. */
            _.Move("R1099-00-INCLUI-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2018- IF V0COBP-VLCUSTCDG > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -2019- ELSE */
            }
            else
            {


                /*" -2023- GO TO R1099-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1099_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2024- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -2026- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -2027- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -2028- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -2029- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -2030- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -2032- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -2034- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -2036- MOVE 'INSERT V0CDGCOBER  ' TO COMANDO. */
            _.Move("INSERT V0CDGCOBER  ", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2037- MOVE 36 TO SII */
            _.Move(36, WS_HORAS.SII);

            /*" -2039- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2051- PERFORM R1099_00_INCLUI_CDG_DB_INSERT_1 */

            R1099_00_INCLUI_CDG_DB_INSERT_1();

            /*" -2054- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2055- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2057- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2059- MOVE V0COBP-VLCUSTCDG TO V0CDGC-VLCUSTCDG. */
            _.Move(V0COBP_VLCUSTCDG, V0CDGC_VLCUSTCDG);

            /*" -2059- PERFORM R1100-00-REPASSA-CDG. */

            R1100_00_REPASSA_CDG_SECTION();

        }

        [StopWatch]
        /*" R1099-00-INCLUI-CDG-DB-INSERT-1 */
        public void R1099_00_INCLUI_CDG_DB_INSERT_1()
        {
            /*" -2051- EXEC SQL INSERT INTO SEGUROS.V0CDGCOBER VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, '9999-12-31' , :V0COBP-IMPSEGCDG, :V0COBP-VLCUSTCDG, :V0HCTA-NRCERTIF, 0, '0' , 'VA1813B' , CURRENT TIMESTAMP) END-EXEC. */

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
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-6 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_6()
        {
            /*" -1836- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '3' , NRPRIPARATZ = 0 , QTDPARATZ = 0 WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_6_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1099_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-7 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_7()
        {
            /*" -1908- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_EFET = TOT_DEB_EFET + :V0HCTA-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1()
            {
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_7_Update1);

        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-SECTION */
        private void R1100_00_REPASSA_CDG_SECTION()
        {
            /*" -2070- MOVE 'R1100-00-REPASSA-CDG' TO PARAGRAFO. */
            _.Move("R1100-00-REPASSA-CDG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2072- IF V0COBP-VLCUSTCDG > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTCDG > 00)
            {

                /*" -2073- ELSE */
            }
            else
            {


                /*" -2077- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2078- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -2080- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -2081- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -2082- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -2083- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -2084- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -2086- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -2088- MOVE DATA-SQL TO V0RCDG-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RCDG_DTREFER);

            /*" -2090- MOVE 'SELECT V0REPASSECDG' TO COMANDO. */
            _.Move("SELECT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2091- MOVE 37 TO SII */
            _.Move(37, WS_HORAS.SII);

            /*" -2093- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2099- PERFORM R1100_00_REPASSA_CDG_DB_SELECT_1 */

            R1100_00_REPASSA_CDG_DB_SELECT_1();

            /*" -2102- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2103- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2105- GO TO R1100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2107- MOVE 'INSERT V0REPASSECDG' TO COMANDO. */
            _.Move("INSERT V0REPASSECDG", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2108- MOVE 38 TO SII */
            _.Move(38, WS_HORAS.SII);

            /*" -2110- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2120- PERFORM R1100_00_REPASSA_CDG_DB_INSERT_1 */

            R1100_00_REPASSA_CDG_DB_INSERT_1();

            /*" -2123- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2124- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2124- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-REPASSA-CDG-DB-SELECT-1 */
        public void R1100_00_REPASSA_CDG_DB_SELECT_1()
        {
            /*" -2099- EXEC SQL SELECT SITUACAO INTO :V0RCDG-SITUACAO FROM SEGUROS.V0REPASSECDG WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREFER = :V0RCDG-DTREFER END-EXEC. */

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
            /*" -2120- EXEC SQL INSERT INTO SEGUROS.V0REPASSECDG VALUES (:V0PROP-CODCLIEN, :V0RCDG-DTREFER, :V0CDGC-VLCUSTCDG, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, '0' , :V0SIST-DTMOVABE, CURRENT TIMESTAMP) END-EXEC. */

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

        [StopWatch]
        /*" R1000-00-QUITA-PARCELA-DB-UPDATE-8 */
        public void R1000_00_QUITA_PARCELA_DB_UPDATE_8()
        {
            /*" -1931- EXEC SQL UPDATE SEGUROS.V0PARCELCAPVG SET SITPARCEL = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0CAPI-NRPARCEL AND SITPARCEL = '3' END-EXEC. */

            var r1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1 = new R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0CAPI_NRPARCEL = V0CAPI_NRPARCEL.ToString(),
            };

            R1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1.Execute(r1000_00_QUITA_PARCELA_DB_UPDATE_8_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-SECTION */
        private void R1199_00_INCLUI_SAF_SECTION()
        {
            /*" -2135- MOVE 'R1199-00-INCLUI-SAF' TO PARAGRAFO. */
            _.Move("R1199-00-INCLUI-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2137- IF V0COBP-VLCUSTAUXF > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -2138- ELSE */
            }
            else
            {


                /*" -2142- GO TO R1199-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2143- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -2145- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -2146- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -2147- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -2148- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -2149- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -2151- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -2153- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -2155- MOVE 'INSERT V0SAFCOBER' TO COMANDO. */
            _.Move("INSERT V0SAFCOBER", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2156- MOVE 39 TO SII */
            _.Move(39, WS_HORAS.SII);

            /*" -2158- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2170- PERFORM R1199_00_INCLUI_SAF_DB_INSERT_1 */

            R1199_00_INCLUI_SAF_DB_INSERT_1();

            /*" -2173- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2174- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2176- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2178- MOVE V0COBP-VLCUSTAUXF TO V0SAFC-VLCUSTSAF. */
            _.Move(V0COBP_VLCUSTAUXF, V0SAFC_VLCUSTSAF);

            /*" -2180- MOVE 'SELECT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2181- MOVE 40 TO SII */
            _.Move(40, WS_HORAS.SII);

            /*" -2183- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2190- PERFORM R1199_00_INCLUI_SAF_DB_SELECT_1 */

            R1199_00_INCLUI_SAF_DB_SELECT_1();

            /*" -2193- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2194- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2196- GO TO R1199-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1199_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2198- MOVE 'INSERT V0HISTREPSAF - 102' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF - 102", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2199- MOVE 41 TO SII */
            _.Move(41, WS_HORAS.SII);

            /*" -2201- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2217- PERFORM R1199_00_INCLUI_SAF_DB_INSERT_2 */

            R1199_00_INCLUI_SAF_DB_INSERT_2();

            /*" -2220- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2221- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2223- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2223- PERFORM R1200-00-REPASSA-SAF. */

            R1200_00_REPASSA_SAF_SECTION();

        }

        [StopWatch]
        /*" R1199-00-INCLUI-SAF-DB-INSERT-1 */
        public void R1199_00_INCLUI_SAF_DB_INSERT_1()
        {
            /*" -2170- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, '9999-12-31' , :V0COBP-IMPSEGAUXF, :V0COBP-VLCUSTAUXF, :V0HCTA-NRCERTIF, 0, '0' , 'VA1813B' , CURRENT TIMESTAMP) END-EXEC. */

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
            /*" -2190- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 102 END-EXEC. */

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
            /*" -2217- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 102, '0' , '0' , 0, 0, 'VA1813B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

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
            /*" -2234- MOVE 'R1200-00-REPASSA-SAF' TO PARAGRAFO. */
            _.Move("R1200-00-REPASSA-SAF", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2236- IF V0COBP-VLCUSTAUXF > ZEROS NEXT SENTENCE */

            if (V0COBP_VLCUSTAUXF > 00)
            {

                /*" -2237- ELSE */
            }
            else
            {


                /*" -2241- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2242- MOVE V0PARC-DTVENCTO TO DATA-SQL. */
            _.Move(V0PARC_DTVENCTO, WORK_AREA.DATA_SQL);

            /*" -2244- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -2245- IF V0PRVG-RISCO = '1' */

            if (V0PRVG_RISCO == "1")
            {

                /*" -2246- ADD V0OPCP-PERIPGTO TO MES-SQL */
                WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL + V0OPCP_PERIPGTO;

                /*" -2247- IF MES-SQL > 12 */

                if (WORK_AREA.DATA_SQL.MES_SQL > 12)
                {

                    /*" -2248- COMPUTE MES-SQL = MES-SQL - 12 */
                    WORK_AREA.DATA_SQL.MES_SQL.Value = WORK_AREA.DATA_SQL.MES_SQL - 12;

                    /*" -2250- ADD 1 TO ANO-SQL. */
                    WORK_AREA.DATA_SQL.ANO_SQL.Value = WORK_AREA.DATA_SQL.ANO_SQL + 1;
                }

            }


            /*" -2252- MOVE DATA-SQL TO V0RSAF-DTREFER. */
            _.Move(WORK_AREA.DATA_SQL, V0RSAF_DTREFER);

            /*" -2254- MOVE 'SELECT V0HISTREPSAF' TO COMANDO. */
            _.Move("SELECT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2255- MOVE 42 TO SII */
            _.Move(42, WS_HORAS.SII);

            /*" -2257- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2264- PERFORM R1200_00_REPASSA_SAF_DB_SELECT_1 */

            R1200_00_REPASSA_SAF_DB_SELECT_1();

            /*" -2267- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2268- IF SQLCODE EQUAL ZEROES */

            if (DB.SQLCODE == 00)
            {

                /*" -2270- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2272- MOVE 'INSERT V0HISTREPSAF' TO COMANDO. */
            _.Move("INSERT V0HISTREPSAF", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2273- MOVE 43 TO SII */
            _.Move(43, WS_HORAS.SII);

            /*" -2275- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2291- PERFORM R1200_00_REPASSA_SAF_DB_INSERT_1 */

            R1200_00_REPASSA_SAF_DB_INSERT_1();

            /*" -2294- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2295- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2295- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-REPASSA-SAF-DB-SELECT-1 */
        public void R1200_00_REPASSA_SAF_DB_SELECT_1()
        {
            /*" -2264- EXEC SQL SELECT SITUACAO INTO :V0RSAF-SITUACAO FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0PROP-CODCLIEN AND DTREF = :V0RSAF-DTREFER AND CODOPER = 1100 END-EXEC. */

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
            /*" -2291- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0PROP-CODCLIEN, :V0RSAF-DTREFER, :V0HCTA-NRCERTIF, :V0HCTA-NRPARCEL, :V0PROP-NRMATRFUN, :V0SAFC-VLCUSTSAF, 1100, '0' , '0' , 0, 0, 'VA1813B' , CURRENT TIMESTAMP, :V0PARC-DTVENCTO:VIND-DTMOVTO) END-EXEC. */

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
            /*" -2306- MOVE 'R2000-00-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("R2000-00-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2309- IF RF-COD-RETORNO EQUAL 99 AND V0HCTA-TIPLANC EQUAL '1' NEXT SENTENCE */

            if (RET_CADASTRAMENTO.RF_COD_RETORNO == 99 && V0HCTA_TIPLANC == "1")
            {

                /*" -2310- ELSE */
            }
            else
            {


                /*" -2311- IF V0HCOB-SITUACAO NOT EQUAL '1' */

                if (V0HCOB_SITUACAO != "1")
                {

                    /*" -2312- MOVE ' ' TO V0HCTA-SITUACAO */
                    _.Move(" ", V0HCTA_SITUACAO);

                    /*" -2313- ELSE */
                }
                else
                {


                    /*" -2314- MOVE '1' TO V0HCTA-SITUACAO */
                    _.Move("1", V0HCTA_SITUACAO);

                    /*" -2319- END-IF. */
                }

            }


            /*" -2323- MOVE V0OPCP-OPCAOPAG TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move(V0OPCP_OPCAOPAG, V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -2324- MOVE '2000-REJEITA-PARCELA' TO PARAGRAFO. */
            _.Move("2000-REJEITA-PARCELA", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2326- MOVE 'UPDATE V0FITASASSE' TO COMANDO. */
            _.Move("UPDATE V0FITASASSE", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2327- MOVE 44 TO SII */
            _.Move(44, WS_HORAS.SII);

            /*" -2329- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2337- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_1 */

            R2000_00_REJEITA_PARCELA_DB_UPDATE_1();

            /*" -2339- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2340- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -2342- DISPLAY V0HCTA-NRCERTIF ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                $"{V0HCTA_NRCERTIF} {WHOST_CODCONV} {V0HCTA_NSAS}"
                .Display();

                /*" -2344- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2347- ADD V0HCTA-VLPRMTOT TO WS-ACG-TOTDBNEFET. */
            WORK_AREA.WS_ACG_TOTDBNEFET.Value = WORK_AREA.WS_ACG_TOTDBNEFET + V0HCTA_VLPRMTOT;

            /*" -2349- IF (RF-COD-RETORNO EQUAL 97 OR 98 OR 99) AND (V0HCTA-TIPLANC EQUAL '1' ) */

            if ((RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99")) && (V0HCTA_TIPLANC == "1"))
            {

                /*" -2350- IF V0PRVG-PERIPGTO GREATER 1 */

                if (V0PRVG_PERIPGTO > 1)
                {

                    /*" -2351- MOVE '0' TO V0HCTA-SITUACAO */
                    _.Move("0", V0HCTA_SITUACAO);

                    /*" -2353- END-IF */
                }


                /*" -2354- ELSE */
            }
            else
            {


                /*" -2355- IF V0HCOB-SITUACAO NOT EQUAL '1' */

                if (V0HCOB_SITUACAO != "1")
                {

                    /*" -2357- IF V0HCOB-SITUACAO EQUAL '2' OR RF-COD-RETORNO EQUAL 97 OR 98 OR 99 */

                    if (V0HCOB_SITUACAO == "2" || RET_CADASTRAMENTO.RF_COD_RETORNO.In("97", "98", "99"))
                    {

                        /*" -2359- MOVE '2' TO V0HCTA-SITUACAO. */
                        _.Move("2", V0HCTA_SITUACAO);
                    }

                }

            }


            /*" -2360- IF V0PROP-SITUACAO EQUAL '8' */

            if (V0PROP_SITUACAO == "8")
            {

                /*" -2361- MOVE '2' TO V0HCTA-SITUACAO */
                _.Move("2", V0HCTA_SITUACAO);

                /*" -2364- MOVE 'UPDATE V0PROPOSTAVA' TO COMANDO */
                _.Move("UPDATE V0PROPOSTAVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

                /*" -2365- MOVE 45 TO SII */
                _.Move(45, WS_HORAS.SII);

                /*" -2366- PERFORM R9000-00-INICIO */

                R9000_00_INICIO_SECTION();

                /*" -2370- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_2 */

                R2000_00_REJEITA_PARCELA_DB_UPDATE_2();

                /*" -2373- PERFORM R9100-00-TERMINO */

                R9100_00_TERMINO_SECTION();

                /*" -2374- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2381- DISPLAY 'VA0813B - PROBLEMAS UPDATE V0PROPOSTAVA 2' V0HCTA-NRCERTIF ' ' V0HCTA-NRPARCEL ' ' V0HCOB-NRTIT ' ' V0PROP-CODCLIEN ' ' WHOST-CODCONV ' ' V0HCTA-NSAS */

                    $"VA0813B - PROBLEMAS UPDATE V0PROPOSTAVA 2{V0HCTA_NRCERTIF} {V0HCTA_NRPARCEL} {V0HCOB_NRTIT} {V0PROP_CODCLIEN} {WHOST_CODCONV} {V0HCTA_NSAS}"
                    .Display();

                    /*" -2383- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                }

            }


            /*" -2436- MOVE 'UPDATE V0HISTCOBVA 3' TO COMANDO. */
            _.Move("UPDATE V0HISTCOBVA 3", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2437- MOVE 45 TO SII */
            _.Move(45, WS_HORAS.SII);

            /*" -2439- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2448- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_5 */

            R2000_00_REJEITA_PARCELA_DB_UPDATE_5();

            /*" -2451- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2452- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2454- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2456- MOVE 'UPDATE V0PARCELVA' TO COMANDO. */
            _.Move("UPDATE V0PARCELVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2457- MOVE 07 TO SII */
            _.Move(07, WS_HORAS.SII);

            /*" -2459- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -2468- PERFORM R2000_00_REJEITA_PARCELA_DB_UPDATE_6 */

            R2000_00_REJEITA_PARCELA_DB_UPDATE_6();

            /*" -2472- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2473- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2475- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2476- IF V0PRVG-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' */

            if (V0PRVG_ORIG_PRODU.In("EMPRE", "ESPEC"))
            {

                /*" -2476- GO TO R2000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-1 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_1()
        {
            /*" -2337- EXEC SQL UPDATE SEGUROS.V0FITASASSE SET TOT_DEB_NAO_EFET = TOT_DEB_NAO_EFET + :V0HCTA-VLPRMTOT, QTDE_LANC_DEB_RET = QTDE_LANC_DEB_RET + 1 WHERE COD_CONVENIO = :WHOST-CODCONV AND NSAS = :V0HCTA-NSAS END-EXEC */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1()
            {
                V0HCTA_VLPRMTOT = V0HCTA_VLPRMTOT.ToString(),
                WHOST_CODCONV = WHOST_CODCONV.ToString(),
                V0HCTA_NSAS = V0HCTA_NSAS.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-2 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_2()
        {
            /*" -2370- EXEC SQL UPDATE SEGUROS.V0PROPOSTAVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HCTA-NRCERTIF END-EXEC */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-SECTION */
        private void R2100_00_MUDA_OPCAOPAG_SECTION()
        {
            /*" -2502- MOVE 'R2100-00-MUDA-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R2100-00-MUDA-OPCAOPAG", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2503- IF V0PRVG-OPCAOPAG = '3' */

            if (V0PRVG_OPCAOPAG == "3")
            {

                /*" -2505- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2509- MOVE '3' TO V0HCTA-OPCAOPAG V0HCOB-OPCAOPAG V0PARC-OPCAOPAG. */
            _.Move("3", V0HCTA_OPCAOPAG, V0HCOB_OPCAOPAG, V0PARC_OPCAOPAG);

            /*" -2510- IF V0OPCP-OPCAOPAG = '3' */

            if (V0OPCP_OPCAOPAG == "3")
            {

                /*" -2512- GO TO R2100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -2514- MOVE 'UPDATE V0OPCAOPAGVA' TO COMANDO. */
            _.Move("UPDATE V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2515- MOVE 47 TO SII */
            _.Move(47, WS_HORAS.SII);

            /*" -2517- PERFORM R9000-00-INICIO. */

            R9000_00_INICIO_SECTION();

            /*" -2523- PERFORM R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1 */

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1();

            /*" -2526- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2527- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2529- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2530- MOVE 'INSERT V0OPCAOPAGVA' TO COMANDO. */
            _.Move("INSERT V0OPCAOPAGVA", WORK_AREA.LOCALIZA_ABEND_2.COMANDO);

            /*" -2532- MOVE '3' TO V0OPCP-OPCAOPAG. */
            _.Move("3", V0OPCP_OPCAOPAG);

            /*" -2533- MOVE 48 TO SII */
            _.Move(48, WS_HORAS.SII);

            /*" -2535- PERFORM R9000-00-INICIO. */

            R9000_00_INICIO_SECTION();

            /*" -2563- PERFORM R2100_00_MUDA_OPCAOPAG_DB_INSERT_1 */

            R2100_00_MUDA_OPCAOPAG_DB_INSERT_1();

            /*" -2566- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -2567- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -2567- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-UPDATE-1 */
        public void R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1()
        {
            /*" -2523- EXEC SQL UPDATE SEGUROS.V0OPCAOPAGVA SET DTTERVIG = :V0HCOB-DTALTOPC, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1 = new R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1()
            {
                V0HCOB_DTALTOPC = V0HCOB_DTALTOPC.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1.Execute(r2100_00_MUDA_OPCAOPAG_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2100-00-MUDA-OPCAOPAG-DB-INSERT-1 */
        public void R2100_00_MUDA_OPCAOPAG_DB_INSERT_1()
        {
            /*" -2563- EXEC SQL INSERT INTO SEGUROS.V0OPCAOPAGVA (NRCERTIF, DTINIVIG, DTTERVIG, OPCAOPAG, PERIPGTO, DIA_DEBITO, CODUSU, TIMESTAMP, AGECTADEB, OPRCTADEB, NUMCTADEB, DIGCTADEB, NUM_CARTAO_CREDITO) VALUES (:V0HCTA-NRCERTIF, :V0HCOB-DTVENCTO, '9999-12-31' , :V0OPCP-OPCAOPAG, :V0OPCP-PERIPGTO, :V0OPCP-DIADEB, 'VA1813B' , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1 = new R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0OPCP_OPCAOPAG = V0OPCP_OPCAOPAG.ToString(),
                V0OPCP_PERIPGTO = V0OPCP_PERIPGTO.ToString(),
                V0OPCP_DIADEB = V0OPCP_DIADEB.ToString(),
            };

            R2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1.Execute(r2100_00_MUDA_OPCAOPAG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-3 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_3()
        {
            /*" -2395- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT AND OCOORHIST = :V0HCOB-OCORHIST END-EXEC */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1()
            {
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-4 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_4()
        {
            /*" -2419- EXEC SQL UPDATE SEGUROS.V0HISTCONTAVA SET SITUACAO = '2' WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND OCORRHISTCTA = :V0HCTA-OCORHISTCTA END-EXEC */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1()
            {
                V0HCTA_OCORHISTCTA = V0HCTA_OCORHISTCTA.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_4_Update1);

        }

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-SECTION */
        private void R8800_00_UPDATE_FOLLOWUP_SECTION()
        {
            /*" -2578- MOVE 'R8800-UPDATE-FOLLOWUP   ' TO PARAGRAFO. */
            _.Move("R8800-UPDATE-FOLLOWUP   ", WORK_AREA.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2590- PERFORM R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1 */

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1();

            /*" -2593- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2594- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2595- DISPLAY 'R8800-00 - PROBLEMAS UPDATE (FOLLOWUP) 100' */
                    _.Display($"R8800-00 - PROBLEMAS UPDATE (FOLLOWUP) 100");

                    /*" -2596- DISPLAY 'NUM_CERTIFICADO ' RF-IDENTIF-CLI */
                    _.Display($"NUM_CERTIFICADO {RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI}");

                    /*" -2597- DISPLAY 'NUM_NOSSA_FITA  ' RF-IDENTIF-NSA */
                    _.Display($"NUM_NOSSA_FITA  {RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA}");

                    /*" -2598- DISPLAY 'NUM_LANCAMENTO  ' RF-NSL */
                    _.Display($"NUM_LANCAMENTO  {RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL}");

                    /*" -2599- ELSE */
                }
                else
                {


                    /*" -2600- DISPLAY 'R8800-00 - PROBLEMAS UPDATE (FOLLOWUP)   ' */
                    _.Display($"R8800-00 - PROBLEMAS UPDATE (FOLLOWUP)   ");

                    /*" -2600- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R8800-00-UPDATE-FOLLOWUP-DB-UPDATE-1 */
        public void R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1()
        {
            /*" -2590- EXEC SQL UPDATE SEGUROS.VG_FOLLOW_UP SET NUM_PARCELA_USADA = :V0HCTA-NRPARCEL, STA_PROCESSAMENTO = 'P' , COD_USUARIO = 'VA1813B' , DTH_ATUALIZACAO = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :VGFOLLOW-NUM-CERTIFICADO AND NUM_NOSSA_FITA = :VGFOLLOW-NUM-NOSSA-FITA AND NUM_LANCAMENTO = :VGFOLLOW-NUM-LANCAMENTO END-EXEC. */

            var r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1 = new R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1()
            {
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
            };

            R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1.Execute(r8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-5 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_5()
        {
            /*" -2448- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET SITUACAO = :V0HCTA-SITUACAO, OPCAOPAG = :V0HCOB-OPCAOPAG, OCORHIST = :V0HCOB-OCORHIST WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC. */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_5_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_5_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0HCOB_OPCAOPAG = V0HCOB_OPCAOPAG.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_5_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_5_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-REJEITA-PARCELA-DB-UPDATE-6 */
        public void R2000_00_REJEITA_PARCELA_DB_UPDATE_6()
        {
            /*" -2468- EXEC SQL UPDATE SEGUROS.V0PARCELVA SET SITUACAO = :V0HCTA-SITUACAO, OPCAOOPAG = :V0PARC-OPCAOPAG, TIMESTAMP = CURRENT TIMESTAMP WHERE NRCERTIF = :V0HCTA-NRCERTIF AND NRPARCEL = :V0HCTA-NRPARCEL END-EXEC. */

            var r2000_00_REJEITA_PARCELA_DB_UPDATE_6_Update1 = new R2000_00_REJEITA_PARCELA_DB_UPDATE_6_Update1()
            {
                V0HCTA_SITUACAO = V0HCTA_SITUACAO.ToString(),
                V0PARC_OPCAOPAG = V0PARC_OPCAOPAG.ToString(),
                V0HCTA_NRCERTIF = V0HCTA_NRCERTIF.ToString(),
                V0HCTA_NRPARCEL = V0HCTA_NRPARCEL.ToString(),
            };

            R2000_00_REJEITA_PARCELA_DB_UPDATE_6_Update1.Execute(r2000_00_REJEITA_PARCELA_DB_UPDATE_6_Update1);

        }

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -2609- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -2610- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -2619- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -2620- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -2621- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -2622- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_23[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_23[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -2623- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_23[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_23[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -2632- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2633- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -2638- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -2639- IF SII < 51 */

            if (WS_HORAS.SII < 51)
            {

                /*" -2640- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_23[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -2642- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_23[WS_HORAS.SII]}"
                .Display();

                /*" -2644- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -2645- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2657- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -2658- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WORK_AREA.WABEND.WSQLERRD1);

            /*" -2659- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WORK_AREA.WABEND.WSQLERRD2);

            /*" -2660- DISPLAY WABEND. */
            _.Display(WORK_AREA.WABEND);

            /*" -2661- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_1);

            /*" -2663- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WORK_AREA.LOCALIZA_ABEND_2);

            /*" -2664- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -2666- CLOSE RETERR. */
            RETERR.Close();

            /*" -2666- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2669- DISPLAY 'CERTIFICADO ' V0HCTA-NRCERTIF. */
            _.Display($"CERTIFICADO {V0HCTA_NRCERTIF}");

            /*" -2670- DISPLAY 'PARCELA     ' V0HCTA-NRPARCEL. */
            _.Display($"PARCELA     {V0HCTA_NRPARCEL}");

            /*" -2672- DISPLAY 'LIDOS       ' AC-LIDOS. */
            _.Display($"LIDOS       {WORK_AREA.AC_LIDOS}");

            /*" -2674- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -2676- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -2676- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}