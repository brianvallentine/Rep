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
using Sias.Sinistro.DB2.SI5001B;

namespace Code
{
    public class SI5001B
    {
        public bool IsCall { get; set; }

        public SI5001B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO / LOTERICO                *      */
        /*"      *   PROGRAMA ...............  SI5001B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER                             *      */
        /*"      *   PROGRAMADOR ............  HEIDER                             *      */
        /*"      *   DATA CODIFICACAO .......  MAIO / 2001                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ....... GERACAO DO ARQUIVO A SER ENVIADO PARA ACEF    *      */
        /*"      *   COM OS MOVIMENTOS DE CREDITO E DEBITO REFERENTE A SINISTRO   *      */
        /*"      *   EH PROCESSADO PARA CADA CONVENIO, PARA CREDITO OU DEBITO     *      */
        /*"      *   DEPENDE DO CARTAO PARAMETRO INFORMADO (CONVENIO E C/D)       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO DESCONFORMIDADE SIAS - DEMANDA: 301167  TAREFA: 332879 *      */
        /*"      *  ALTERACAO: CHAMAR ROTINA DE INTEGRACAO COM O MCP (SICP001S).  *      */
        /*"      *  PROCURAR V.09 - HERVAL SOUZA - ACT            EM: 03/11/2021  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * HEIDER EM 20/01/2012 - APENAS RETIRANDO DISPLYAS EXTRAS, VISANDO      */
        /*"      *        PERFORMANCE DE EXECUCAO                                        */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO REINF - OUT/2017                                       *      */
        /*"      *  ALTERAO DO CAMPO GE_ARQUIVO_SAP.TXT_REG_SAP DE 3.952 BYTES  *        */
        /*"      *    PARA 4.834 BYTES                                            *      */
        /*"      *  PROCURAR V.08 - DOUGLAS ARAUJO - ATOS                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 07 -   GUILHERME CORREIA - CADMUS 129207              *      */
        /*"      *               - IMPLEMENTACAO DE RESSARCIMENTO PARA LOTERICO E *      */
        /*"      *                 CCA                                            *      */
        /*"      *                                                                *      */
        /*"      *   EM 02/02/2016                                                *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 06 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE LAYOUT MVDBCCOR                                       *      */
        /*"      *   EM 25/08/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 18/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.05         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * AJUSTE PARA NAO GERAR O SEGUNDO HEADER E TRAILLER                     */
        /*"      * INFORMAR O CODIGO DO CONVENIO QUANDO O ARQUIVO VAZIO                  */
        /*"      *                                                                *      */
        /*"      *   V.03 - OLIVEIRA      - 23112012 15:04HS SUSP. COB - R0210    *      */
        /*"      *   V.02 - OLIVEIRA      - NOV   2011 - COBRANCA SUSPENSA        *      */
        /*"      *   V.01 - HEIDER COELHO - JULHO 2010 - PROJETO VISAO / SAP      *      */
        /*"      *   CADMUS 44547 - CHAMADA DA ROTINA SISAP01B PARA GERACAO       *      */
        /*"      *                  DO MOVIMENTO PARA ENVIO AO SAP                *      */
        /*"      *                                         PROCURE  POR V.01      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 04 - CAD 10.003                                        *      */
        /*"      *                                                                *      */
        /*"      *             - CONVERSAO DO DB2 PARA A VERSAO 10                *      */
        /*"      *                                                                *      */
        /*"      *  EM 26/09/2013 -  ROGERIO PEREIRA                              *      */
        /*"      *                                                                *      */
        /*"      *                                           PROCURE POR V.04     *      */
        /*"      *----------------------------------------------------------------*      */
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
        public FileBasis _RSI5001B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RSI5001B
        {
            get
            {
                _.Move(REG_SI5001B, _RSI5001B); VarBasis.RedefinePassValue(REG_SI5001B, _RSI5001B, REG_SI5001B); return _RSI5001B;
            }
        }
        /*"01        HEADER-REGISTRO.*/
        public SI5001B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new SI5001B_HEADER_REGISTRO();
        public class SI5001B_HEADER_REGISTRO : VarBasis
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
        public SI5001B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new SI5001B_MOVCC_REGISTRO();
        public class SI5001B_MOVCC_REGISTRO : VarBasis
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
            /*"  05      MOVCC-USOEMPRESA   PIC  X(060).*/
            public StringBasis MOVCC_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(060)."), @"");
            /*"  05      MOVCC-FILLER       PIC  X(015).*/
            public StringBasis MOVCC_FILLER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      MOVCC-CODMOVTO     PIC  9(001).*/
            public IntBasis MOVCC_CODMOVTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public SI5001B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new SI5001B_TRAILL_REGISTRO();
        public class SI5001B_TRAILL_REGISTRO : VarBasis
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
            /*"01        REG-SI5001B        PIC  X(132).*/
        }
        public StringBasis REG_SI5001B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-DATA-CORRENTE               PIC X(10).*/
        public StringBasis HOST_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-HORA-CORRENTE               PIC X(10).*/
        public StringBasis HOST_HORA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  HOST-COD-CONVENIO                PIC S9(09) COMP   VALUE +0.*/
        public IntBasis HOST_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  WS-PROGRAMA                      PIC  X(08) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
        /*"77  WS-SI239-SQL100                  PIC  X(03) VALUE 'NAO'.*/
        public StringBasis WS_SI239_SQL100 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"01  AREA-DE-WORK.*/
        public SI5001B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI5001B_AREA_DE_WORK();
        public class SI5001B_AREA_DE_WORK : VarBasis
        {
            /*"    05 WFIM-PARAMCON            PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_PARAMCON { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 WFIM-MOVDEBCE                 PIC X(03)    VALUE 'NAO'.*/
            public StringBasis WFIM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-SEM-MOVIMENTO         PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_SEM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-NOVA-PARAM-CONTACEF   PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_NOVA_PARAM_CONTACEF { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-CHAVE-TEM-MOVIMENTO-ENVIO   PIC X(03)    VALUE 'NAO'.*/
            public StringBasis W_CHAVE_TEM_MOVIMENTO_ENVIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    05 W-LIDOS-PARAMCON              PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS_PARAMCON { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-TOTAL-LIDOS-MOVDEBCE        PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_TOTAL_LIDOS_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-LIDOS-MOVDEBCE-DEBITO       PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS_MOVDEBCE_DEBITO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-LIDOS-MOVDEBCE-CREDITO      PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_LIDOS_MOVDEBCE_CREDITO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-TOT-REG-GRAVADOS            PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_TOT_REG_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 W-TOTAL-CREDITOS              PIC 9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_TOTAL_CREDITOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-TOTAL-DEBITOS               PIC 9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_TOTAL_DEBITOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-TOTAL-REGISTROS-ENVIADOS    PIC 9(09)    VALUE ZEROS.*/
            public IntBasis W_TOTAL_REGISTROS_ENVIADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 WS-CONTADOR                   PIC S9(04)   VALUE +0 COMP.*/
            public IntBasis WS_CONTADOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 WS-COD-LOT-FENAL              PIC S9(09)   VALUE +0 COMP.*/
            public IntBasis WS_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 W-EDICAO1                     PIC ZZZ.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9."));
            /*"    05 W-EDICAO2                     PIC ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis W_EDICAO2 { get; set; } = new DoubleBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05 W-ENDOSSO.*/
            public SI5001B_W_ENDOSSO W_ENDOSSO { get; set; } = new SI5001B_W_ENDOSSO();
            public class SI5001B_W_ENDOSSO : VarBasis
            {
                /*"       10 W-ENDOSSO-PRODUTO          PIC 9(04).*/
                public IntBasis W_ENDOSSO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-ENDOSSO-OPERACAO         PIC 9(04).*/
                public IntBasis W_ENDOSSO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05 W-VALOR                       PIC 9(13)V99 VALUE ZEROS.*/
            }
            public DoubleBasis W_VALOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 W-CONTA-PAGINA                PIC 9(07)    VALUE ZEROS.*/
            public IntBasis W_CONTA_PAGINA { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
            /*"    05 W-CONTA-LINHA                 PIC 9(02)    VALUE 90.*/
            public IntBasis W_CONTA_LINHA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 90);
            /*"    05 W-NUM-ENDOSSO-NUMERICO        PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis W_NUM_ENDOSSO_NUMERICO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
            /*"    05 W-NUM-ENDOSSO.*/
            public SI5001B_W_NUM_ENDOSSO W_NUM_ENDOSSO { get; set; } = new SI5001B_W_NUM_ENDOSSO();
            public class SI5001B_W_NUM_ENDOSSO : VarBasis
            {
                /*"       15 FILLER                     PIC 9(05)       VALUE ZEROS*/
                public IntBasis FILLER_0 { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"       15 W-NUM-ENDOSSO-PRODUTO      PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_NUM_ENDOSSO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 FILLER                     PIC 9(04)       VALUE ZEROS*/
                public IntBasis FILLER_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-DATA-CORRENTE.*/
            }
            public SI5001B_W_DATA_CORRENTE W_DATA_CORRENTE { get; set; } = new SI5001B_W_DATA_CORRENTE();
            public class SI5001B_W_DATA_CORRENTE : VarBasis
            {
                /*"       15 W-DATA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-DATA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-DATA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_DATA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-DATA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-HORA-CORRENTE.*/
            }
            public SI5001B_W_HORA_CORRENTE W_HORA_CORRENTE { get; set; } = new SI5001B_W_HORA_CORRENTE();
            public class SI5001B_W_HORA_CORRENTE : VarBasis
            {
                /*"       15 W-HORA-CORRENTE-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       15 W-HORA-CORRENTE-FILLER-1   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       15 W-HORA-CORRENTE-FILLER-2   PIC X(01)       VALUE ZEROS*/
                public StringBasis W_HORA_CORRENTE_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"       15 W-HORA-CORRENTE-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_HORA_CORRENTE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-AAAAMMDD.*/
            }
            public SI5001B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new SI5001B_W_DATA_AAAAMMDD();
            public class SI5001B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"       10 W-DATA-AAAAMMDD-ANO        PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 W-DATA-AAAAMMDD-MES        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-AAAAMMDD-DIA        PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_AAAAMMDD_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"    05 W-DATA-DD-MM-AAAA.*/
            }
            public SI5001B_W_DATA_DD_MM_AAAA W_DATA_DD_MM_AAAA { get; set; } = new SI5001B_W_DATA_DD_MM_AAAA();
            public class SI5001B_W_DATA_DD_MM_AAAA : VarBasis
            {
                /*"       10 W-DATA-DD-MM-AAAA-DD       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-DD-F1    PIC X(01)       VALUE ' '.*/
                public StringBasis W_DATA_DD_MM_AAAA_DD_F1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 W-DATA-DD-MM-AAAA-MM       PIC 9(02)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"       10 W-DATA-DD-MM-AAAA-DD-F2    PIC X(01)       VALUE ' '.*/
                public StringBasis W_DATA_DD_MM_AAAA_DD_F2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 W-DATA-DD-MM-AAAA-AAAA     PIC 9(04)       VALUE ZEROS*/
                public IntBasis W_DATA_DD_MM_AAAA_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    05 W-IDENT-CLIENTE-BANCO         PIC X(19).*/
            }
            public StringBasis W_IDENT_CLIENTE_BANCO { get; set; } = new StringBasis(new PIC("X", "19", "X(19)."), @"");
            /*"    05 FILLER         REDEFINES      W-IDENT-CLIENTE-BANCO.*/
            private _REDEF_SI5001B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_SI5001B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_SI5001B_FILLER_2(); _.Move(W_IDENT_CLIENTE_BANCO, _filler_2); VarBasis.RedefinePassValue(W_IDENT_CLIENTE_BANCO, _filler_2, W_IDENT_CLIENTE_BANCO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_IDENT_CLIENTE_BANCO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_IDENT_CLIENTE_BANCO); }
            }  //Redefines
            public class _REDEF_SI5001B_FILLER_2 : VarBasis
            {
                /*"       10 W-OPER-CONTA               PIC 9(04).*/
                public IntBasis W_OPER_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-NUMERO-CONTA             PIC 9(12).*/
                public IntBasis W_NUMERO_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                /*"       10 W-DV-CONTA                 PIC 9(01).*/
                public IntBasis W_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 FILLER-1                   PIC X(02).*/
                public StringBasis FILLER_1_0 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"    05 W-IDENT-CLIENTE-EMPRESA       PIC  X(25).*/

                public _REDEF_SI5001B_FILLER_2()
                {
                    W_OPER_CONTA.ValueChanged += OnValueChanged;
                    W_NUMERO_CONTA.ValueChanged += OnValueChanged;
                    W_DV_CONTA.ValueChanged += OnValueChanged;
                    FILLER_1_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_IDENT_CLIENTE_EMPRESA { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05 FILLER         REDEFINES      W-IDENT-CLIENTE-EMPRESA.*/
            private _REDEF_SI5001B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_SI5001B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_SI5001B_FILLER_3(); _.Move(W_IDENT_CLIENTE_EMPRESA, _filler_3); VarBasis.RedefinePassValue(W_IDENT_CLIENTE_EMPRESA, _filler_3, W_IDENT_CLIENTE_EMPRESA); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_IDENT_CLIENTE_EMPRESA); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_IDENT_CLIENTE_EMPRESA); }
            }  //Redefines
            public class _REDEF_SI5001B_FILLER_3 : VarBasis
            {
                /*"       10 W-NUM-APOL-SINISTRO        PIC 9(13).*/
                public IntBasis W_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10 W-COD-PRODUTO              PIC 9(04).*/
                public IntBasis W_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-COD-OPERACAO             PIC 9(04).*/
                public IntBasis W_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-OCORR-HISTORICO          PIC 9(04).*/
                public IntBasis W_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05 W-PRODUTO-OPERACAO             PIC 9(09).*/

                public _REDEF_SI5001B_FILLER_3()
                {
                    W_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                    W_COD_PRODUTO.ValueChanged += OnValueChanged;
                    W_COD_OPERACAO.ValueChanged += OnValueChanged;
                    W_OCORR_HISTORICO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_PRODUTO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05 FILLER         REDEFINES       W-PRODUTO-OPERACAO.*/
            private _REDEF_SI5001B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_SI5001B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_SI5001B_FILLER_4(); _.Move(W_PRODUTO_OPERACAO, _filler_4); VarBasis.RedefinePassValue(W_PRODUTO_OPERACAO, _filler_4, W_PRODUTO_OPERACAO); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_PRODUTO_OPERACAO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_PRODUTO_OPERACAO); }
            }  //Redefines
            public class _REDEF_SI5001B_FILLER_4 : VarBasis
            {
                /*"       10 FILLER                      PIC 9(01).*/
                public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 W-PRODUTO-OPERACAO-PRODUTO  PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-PRODUTO-OPERACAO-OPERACAO PIC 9(04).*/
                public IntBasis W_PRODUTO_OPERACAO_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05 W-COD-CONVENIO-TOTAL           PIC X(09).*/

                public _REDEF_SI5001B_FILLER_4()
                {
                    FILLER_5.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_PRODUTO.ValueChanged += OnValueChanged;
                    W_PRODUTO_OPERACAO_OPERACAO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_COD_CONVENIO_TOTAL { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
            /*"    05 FILLER         REDEFINES       W-COD-CONVENIO-TOTAL.*/
            private _REDEF_SI5001B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_SI5001B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_SI5001B_FILLER_6(); _.Move(W_COD_CONVENIO_TOTAL, _filler_6); VarBasis.RedefinePassValue(W_COD_CONVENIO_TOTAL, _filler_6, W_COD_CONVENIO_TOTAL); _filler_6.ValueChanged += () => { _.Move(_filler_6, W_COD_CONVENIO_TOTAL); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W_COD_CONVENIO_TOTAL); }
            }  //Redefines
            public class _REDEF_SI5001B_FILLER_6 : VarBasis
            {
                /*"       10 FILLER                      PIC X(03).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"       10 W-COD-CONVENIO-REAL         PIC X(06).*/
                public StringBasis W_COD_CONVENIO_REAL { get; set; } = new StringBasis(new PIC("X", "6", "X(06)."), @"");
                /*"    05 W-USO-EMPRESA                      PIC X(60).*/

                public _REDEF_SI5001B_FILLER_6()
                {
                    FILLER_7.ValueChanged += OnValueChanged;
                    W_COD_CONVENIO_REAL.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"    05 FILLER         REDEFINES      W-USO-EMPRESA.*/
            private _REDEF_SI5001B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_SI5001B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_SI5001B_FILLER_8(); _.Move(W_USO_EMPRESA, _filler_8); VarBasis.RedefinePassValue(W_USO_EMPRESA, _filler_8, W_USO_EMPRESA); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_USO_EMPRESA); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_USO_EMPRESA); }
            }  //Redefines
            public class _REDEF_SI5001B_FILLER_8 : VarBasis
            {
                /*"       10 W-USO-EMP-FILLER-1              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-COD-CONVENIO          PIC 9(06).*/
                public IntBasis W_USO_EMP_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       10 W-USO-EMP-FILLER-2              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-NSAS                  PIC 9(06).*/
                public IntBasis W_USO_EMP_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       10 W-USO-EMP-FILLER-3              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-DATA-MOVIMENTO        PIC 9(10).*/
                public IntBasis W_USO_EMP_DATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                /*"       10 W-USO-EMP-FILLER-4              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-NUM-APOL-SINISTRO     PIC 9(13).*/
                public IntBasis W_USO_EMP_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"       10 W-USO-EMP-FILLER-5              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-COD-PRODUTO           PIC 9(04).*/
                public IntBasis W_USO_EMP_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-USO-EMP-FILLER-6              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-COD-OPERACAO          PIC 9(04).*/
                public IntBasis W_USO_EMP_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-USO-EMP-FILLER-7              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-OCORR-HISTORICO       PIC 9(04).*/
                public IntBasis W_USO_EMP_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"       10 W-USO-EMP-FILLER-8              PIC X(01).*/
                public StringBasis W_USO_EMP_FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 W-USO-EMP-COD-EMPRESA           PIC 9(01).*/
                public IntBasis W_USO_EMP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"       10 W-USO-EMP-FILLER-9              PIC X(04).*/
                public StringBasis W_USO_EMP_FILLER_9 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"    05 LC01.*/

                public _REDEF_SI5001B_FILLER_8()
                {
                    W_USO_EMP_FILLER_1.ValueChanged += OnValueChanged;
                    W_USO_EMP_COD_CONVENIO.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_2.ValueChanged += OnValueChanged;
                    W_USO_EMP_NSAS.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_3.ValueChanged += OnValueChanged;
                    W_USO_EMP_DATA_MOVIMENTO.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_4.ValueChanged += OnValueChanged;
                    W_USO_EMP_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_5.ValueChanged += OnValueChanged;
                    W_USO_EMP_COD_PRODUTO.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_6.ValueChanged += OnValueChanged;
                    W_USO_EMP_COD_OPERACAO.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_7.ValueChanged += OnValueChanged;
                    W_USO_EMP_OCORR_HISTORICO.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_8.ValueChanged += OnValueChanged;
                    W_USO_EMP_COD_EMPRESA.ValueChanged += OnValueChanged;
                    W_USO_EMP_FILLER_9.ValueChanged += OnValueChanged;
                }

            }
            public SI5001B_LC01 LC01 { get; set; } = new SI5001B_LC01();
            public class SI5001B_LC01 : VarBasis
            {
                /*"       10 LC01-RELATORIO             PIC X(07) VALUE 'SI5001B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"SI5001B");
                /*"       10 FILLER                     PIC X(36) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"");
                /*"       10 LC01-EMPRESA               PIC X(40) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"       10 FILLER                     PIC X(34) VALUE  SPACES.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "34", "X(34)"), @"");
                /*"       10 FILLER                     PIC X(11) VALUE 'PAGINA'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PAGINA");
                /*"       10 LC01-PAGINA                PIC ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    05 LC02.*/
            }
            public SI5001B_LC02 LC02 { get; set; } = new SI5001B_LC02();
            public class SI5001B_LC02 : VarBasis
            {
                /*"       10 FILLER                     PIC X(103) VALUE  SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "103", "X(103)"), @"");
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA SISTEMA (SI): '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA SISTEMA (SI): ");
                /*"       10 LC02-DATA-SISTEMA          PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_SISTEMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC02-A.*/
            }
            public SI5001B_LC02_A LC02_A { get; set; } = new SI5001B_LC02_A();
            public class SI5001B_LC02_A : VarBasis
            {
                /*"       10 FILLER                     PIC X(103) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "103", "X(103)"), @"");
                /*"       10 FILLER                     PIC X(19)  VALUE          'DATA CORRENTE    : '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA CORRENTE    : ");
                /*"       10 LC02-DATA-CORRENTE         PIC X(10)   VALUE SPACES.*/
                public StringBasis LC02_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    05 LC03.*/
            }
            public SI5001B_LC03 LC03 { get; set; } = new SI5001B_LC03();
            public class SI5001B_LC03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(25) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"");
                /*"       10 FILLER                     PIC X(53) VALUE         'RELACAO DE DEBITOS/CREDITOS GERADAS PARA A C.E.F. EM '*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "53", "X(53)"), @"RELACAO DE DEBITOS/CREDITOS GERADAS PARA A C.E.F. EM ");
                /*"       10 LC03-DATA                  PIC X(10).*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"       10 FILLER                     PIC X(15) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
                /*"       10 FILLER                     PIC X(18) VALUE          'HORA             :'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"HORA             :");
                /*"       10 FILLER                     PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"       10 LC03-HORA                  PIC X(08) VALUE ' '.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" ");
                /*"    05 LC04.*/
            }
            public SI5001B_LC04 LC04 { get; set; } = new SI5001B_LC04();
            public class SI5001B_LC04 : VarBasis
            {
                /*"       10 FILLER                     PIC X(132) VALUE  ALL '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05 LC04-B.*/
            }
            public SI5001B_LC04_B LC04_B { get; set; } = new SI5001B_LC04_B();
            public class SI5001B_LC04_B : VarBasis
            {
                /*"       10 FILLER                     PIC X(09) VALUE          'CONVENIO:'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"CONVENIO:");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LC04-COD-CONVENIO          PIC ZZZZZ9.*/
                public IntBasis LC04_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"       10 FILLER                     PIC X(03) VALUE ' - '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"       10 LC04-NOME-CONVENIO         PIC X(40) VALUE SPACES.*/
                public StringBasis LC04_NOME_CONVENIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    05 LC05.*/
            }
            public SI5001B_LC05 LC05 { get; set; } = new SI5001B_LC05();
            public class SI5001B_LC05 : VarBasis
            {
                /*"       10 FILLER                     PIC X(08) VALUE          'SINISTRO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"       10 FILLER                     PIC X(06) VALUE ' '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @" ");
                /*"       10 FILLER                     PIC X(03) VALUE          'OC.'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"OC.");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(04) VALUE          'OPE.'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"OPE.");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(04) VALUE          'PROD'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"PROD");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(40) VALUE          'LOTERICO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"LOTERICO");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(17) VALUE          'COD. LOTERICO CEF'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"COD. LOTERICO CEF");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(07) VALUE          'DEB/CRD'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"DEB/CRD");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(07) VALUE          'TP. LNC'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"TP. LNC");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 FILLER                     PIC X(14) VALUE          'CONTA CORRENTE'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CONTA CORRENTE");
                /*"       10 FILLER                     PIC X(15) VALUE ' '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @" ");
                /*"       10 FILLER                     PIC X(05) VALUE          'VALOR'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"VALOR");
                /*"    05 LC08.*/
            }
            public SI5001B_LC08 LC08 { get; set; } = new SI5001B_LC08();
            public class SI5001B_LC08 : VarBasis
            {
                /*"       10 FILLER                     PIC X(132) VALUE ' '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @" ");
                /*"    05 LD01.*/
            }
            public SI5001B_LD01 LD01 { get; set; } = new SI5001B_LD01();
            public class SI5001B_LD01 : VarBasis
            {
                /*"       10 LD01-NUM-APOL-SINISTRO     PIC 9(13) VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-OCORR-HISTORICO       PIC 9(03) VALUE ZEROS.*/
                public IntBasis LD01_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-COD-OPERACAO          PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-COD-PRODUTO           PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-NOME-LOTERICO         PIC X(40) VALUE ' '.*/
                public StringBasis LD01_NOME_LOTERICO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-COD-LOT-CEF           PIC ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-DEB-CRE               PIC X(07) VALUE ' '.*/
                public StringBasis LD01_DEB_CRE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-TIPO-LANCAMENTO       PIC X(07) VALUE ' '.*/
                public StringBasis LD01_TIPO_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @" ");
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-COD-AGENCIA           PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       10 LD01-OPER-CONTA            PIC 9(04) VALUE ZEROS.*/
                public IntBasis LD01_OPER_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"       10 FILLER                     PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       10 LD01-NUM-CONTA             PIC 9(12) VALUE ZEROS.*/
                public IntBasis LD01_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)"));
                /*"       10 FILLER                     PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"       10 LD01-DV-CONTA              PIC 9(01) VALUE ZEROS.*/
                public IntBasis LD01_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
                /*"       10 FILLER                     PIC X(01) VALUE ' '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"       10 LD01-VALOR                 PIC ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
                /*"    05 LT00.*/
            }
            public SI5001B_LT00 LT00 { get; set; } = new SI5001B_LT00();
            public class SI5001B_LT00 : VarBasis
            {
                /*"       10 FILLER                     PIC X(25) VALUE          '** TOTAIS DO CONVENIO  **'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"** TOTAIS DO CONVENIO  **");
                /*"    05 LT01.*/
            }
            public SI5001B_LT01 LT01 { get; set; } = new SI5001B_LT01();
            public class SI5001B_LT01 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  TOTAL DE REGISTROS ........ '.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  TOTAL DE REGISTROS ........ ");
                /*"       10 LT01-TOTAL-REGISTROS     PIC  ZZZZ.ZZ9.*/
                public IntBasis LT01_TOTAL_REGISTROS { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZ.ZZ9."));
                /*"    05 LT02.*/
            }
            public SI5001B_LT02 LT02 { get; set; } = new SI5001B_LT02();
            public class SI5001B_LT02 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  TOTAL DE CREDITOS  ........ '.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  TOTAL DE CREDITOS  ........ ");
                /*"       10 LT02-TOTAL-CREDITOS      PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT02_TOTAL_CREDITOS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 LT03.*/
            }
            public SI5001B_LT03 LT03 { get; set; } = new SI5001B_LT03();
            public class SI5001B_LT03 : VarBasis
            {
                /*"       10 FILLER                     PIC X(30) VALUE          '  TOTAL DE DEBITOS   ........ '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"  TOTAL DE DEBITOS   ........ ");
                /*"       10 LT03-TOTAL-DEBITOS       PIC  ZZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LT03_TOTAL_DEBITOS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
                /*"    05 LT04.*/
            }
            public SI5001B_LT04 LT04 { get; set; } = new SI5001B_LT04();
            public class SI5001B_LT04 : VarBasis
            {
                /*"       10 FILLER          PIC  X(13) VALUE          '  FITA  NR.: '.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"  FITA  NR.: ");
                /*"       10 LT04-NRFITA     PIC  ZZZZZZZZZ9.*/
                public IntBasis LT04_NRFITA { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"01  REGISTRO-LINKAGE-SAP.*/
            }
        }
        public SI5001B_REGISTRO_LINKAGE_SAP REGISTRO_LINKAGE_SAP { get; set; } = new SI5001B_REGISTRO_LINKAGE_SAP();
        public class SI5001B_REGISTRO_LINKAGE_SAP : VarBasis
        {
            /*"    05 LK-SAP-NUM-APOLICE            PIC S9(13) COMP-3.*/
            public IntBasis LK_SAP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 LK-SAP-NUM-ENDOSSO            PIC S9(09) COMP.*/
            public IntBasis LK_SAP_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-SAP-NUM-PARCELA            PIC S9(04) COMP.*/
            public IntBasis LK_SAP_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SAP-COD-CONVENIO           PIC S9(09) COMP.*/
            public IntBasis LK_SAP_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-SAP-NSAS                   PIC S9(04) COMP.*/
            public IntBasis LK_SAP_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SAP-SITUACAO-COBRANCA      PIC  X(01).*/
            public StringBasis LK_SAP_SITUACAO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-COD-BANCO              PIC S9(04) COMP.*/
            public IntBasis LK_SAP_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-SAP-COD-AGENCIA            PIC  9(05).*/
            public IntBasis LK_SAP_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SAP-DV-AGENCIA             PIC  X(01).*/
            public StringBasis LK_SAP_DV_AGENCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-OPERACAO-CONTA         PIC  9(04).*/
            public IntBasis LK_SAP_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05 LK-SAP-NUM-CONTA              PIC  9(12).*/
            public IntBasis LK_SAP_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"    05 LK-SAP-DV-CONTA               PIC  X(01).*/
            public StringBasis LK_SAP_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-COD-PROGRAMA           PIC  X(08).*/
            public StringBasis LK_SAP_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05 LK-SAP-FAVORECIDO.*/
            public SI5001B_LK_SAP_FAVORECIDO LK_SAP_FAVORECIDO { get; set; } = new SI5001B_LK_SAP_FAVORECIDO();
            public class SI5001B_LK_SAP_FAVORECIDO : VarBasis
            {
                /*"       10 LK-SAP-NOME-FAVORECIDO     PIC  X(30).*/
                public StringBasis LK_SAP_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"       10 LK-SAP-NUM-DOC-EMPRESA     PIC  9(06).*/
                public IntBasis LK_SAP_NUM_DOC_EMPRESA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"       10 FILLER                     PIC  X(04).*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"    05 LK-SAP-DES-LOGRADOURO         PIC  X(30).*/
            }
            public StringBasis LK_SAP_DES_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"    05 LK-SAP-NUM-LOCAL              PIC  9(05).*/
            public IntBasis LK_SAP_NUM_LOCAL { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SAP-DES-COMPLEMENTO        PIC  X(15).*/
            public StringBasis LK_SAP_DES_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SAP-DES-BAIRRO             PIC  X(15).*/
            public StringBasis LK_SAP_DES_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SAP-DES-CIDADE             PIC  X(20).*/
            public StringBasis LK_SAP_DES_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05 LK-SAP-NUM-CEP                PIC  9(05).*/
            public IntBasis LK_SAP_NUM_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
            /*"    05 LK-SAP-DES-COMPL-CEP          PIC  X(03).*/
            public StringBasis LK_SAP_DES_COMPL_CEP { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-SAP-DES-SIGLA-UF           PIC  X(02).*/
            public StringBasis LK_SAP_DES_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 LK-SAP-CHR-USO-EMPRESA.*/
            public SI5001B_LK_SAP_CHR_USO_EMPRESA LK_SAP_CHR_USO_EMPRESA { get; set; } = new SI5001B_LK_SAP_CHR_USO_EMPRESA();
            public class SI5001B_LK_SAP_CHR_USO_EMPRESA : VarBasis
            {
                /*"       10 WS-USO-EMPRESA-SICOV-TXT1  PIC  X(40).*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT1 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-25    PIC  X(25).*/
                public StringBasis WS_USO_EMPRESA_SICOV_25 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-TXT2  PIC  X(40).*/
                public StringBasis WS_USO_EMPRESA_SICOV_TXT2 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"       10 FILLER                     PIC  X(01).*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 WS-USO-EMPRESA-SICOV-60    PIC  X(60).*/
                public StringBasis WS_USO_EMPRESA_SICOV_60 { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
                /*"       10 FILLER                     PIC  X(32).*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "32", "X(32)."), @"");
                /*"    05 LK-SAP-COD-DOCUMENTO-SIACC    PIC  X(15).*/
            }
            public StringBasis LK_SAP_COD_DOCUMENTO_SIACC { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"    05 LK-SAP-USO-EMPRESA-SIACC      PIC  X(40).*/
            public StringBasis LK_SAP_USO_EMPRESA_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-SAP-COD-RETORNO            PIC  X(01).*/
            public StringBasis LK_SAP_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-SAP-MENSAGEM-RETORNO       PIC  X(80).*/
            public StringBasis LK_SAP_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "80", "X(80)."), @"");
            /*"    05 LK-SAP-REGISTRO               PIC  X(4834).*/
            public StringBasis LK_SAP_REGISTRO { get; set; } = new StringBasis(new PIC("X", "4834", "X(4834)."), @"");
            /*"    05 WABEND.*/
            public SI5001B_WABEND WABEND { get; set; } = new SI5001B_WABEND();
            public class SI5001B_WABEND : VarBasis
            {
                /*"       07 WABEND1.*/
                public SI5001B_WABEND1 WABEND1 { get; set; } = new SI5001B_WABEND1();
                public class SI5001B_WABEND1 : VarBasis
                {
                    /*"       10 FILLER         PIC  X(008)      VALUE          'SI5001B '.*/
                    public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"SI5001B ");
                    /*"       07 WABEND2.*/
                    public SI5001B_WABEND2 WABEND2 { get; set; } = new SI5001B_WABEND2();
                    public class SI5001B_WABEND2 : VarBasis
                    {
                        /*"       10 FILLER         PIC  X(025)      VALUE          '*** ERRO EXEC SQL NUMERO '.*/
                        public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                        /*"       10 WNR-EXEC-SQL   PIC  X(004)      VALUE   '0000'.*/
                        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                        /*"       07 WABEND3.*/
                        public SI5001B_WABEND3 WABEND3 { get; set; } = new SI5001B_WABEND3();
                        public class SI5001B_WABEND3 : VarBasis
                        {
                            /*"       10 FILLER         PIC  X(013)      VALUE          ' *** SQLCODE '.*/
                            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                            /*"       10 WSQLCODE       PIC  ZZZZZ999-   VALUE    ZEROS.*/
                            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                            /*"01          LK-LINK.*/
                        }
                    }
                    public SI5001B_LK_LINK LK_LINK { get; set; } = new SI5001B_LK_LINK();
                    public class SI5001B_LK_LINK : VarBasis
                    {
                        /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
                        public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                        /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
                        public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
                        /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
                        public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                        /*"01  LINK-PARM-CONV-PROCESSADO.*/
                    }
                }
            }
        }
        public SI5001B_LINK_PARM_CONV_PROCESSADO LINK_PARM_CONV_PROCESSADO { get; set; } = new SI5001B_LINK_PARM_CONV_PROCESSADO();
        public class SI5001B_LINK_PARM_CONV_PROCESSADO : VarBasis
        {
            /*"    05 TAMANHO-PARM                PIC S9(04) COMP.*/
            public IntBasis TAMANHO_PARM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 PARM-CONV-PROCESSADO        PIC  X(06)     .*/
            public StringBasis PARM_CONV_PROCESSADO { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
            /*"    05 PARM-TIPO-MOVIMENTO         PIC  X(01)     .*/
            public StringBasis PARM_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        }


        public Copies.SICPW001 SICPW001 { get; set; } = new Copies.SICPW001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.SINILT01 SINILT01 { get; set; } = new Dclgens.SINILT01();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.SI239 SI239 { get; set; } = new Dclgens.SI239();
        public SI5001B_C01_PARAMCON C01_PARAMCON { get; set; } = new SI5001B_C01_PARAMCON();
        public SI5001B_C01_MOVDEBCE C01_MOVDEBCE { get; set; } = new SI5001B_C01_MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SI5001B_LINK_PARM_CONV_PROCESSADO SI5001B_LINK_PARM_CONV_PROCESSADO_P, string MOVDEBITO_CC_FILE_NAME_P, string RSI5001B_FILE_NAME_P) //PROCEDURE DIVISION USING 
        /*LINK_PARM_CONV_PROCESSADO*/
        {
            try
            {
                this.LINK_PARM_CONV_PROCESSADO = SI5001B_LINK_PARM_CONV_PROCESSADO_P;
                MOVDEBITO_CC.SetFile(MOVDEBITO_CC_FILE_NAME_P);
                RSI5001B.SetFile(RSI5001B_FILE_NAME_P);

                /*" -553- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -554- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -555- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -558- DISPLAY ' ' */
                _.Display($" ");

                /*" -559- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -560- DISPLAY 'PROGRAMA SI5001B EM EXECUCAO V.09 ' */
                _.Display($"PROGRAMA SI5001B EM EXECUCAO V.09 ");

                /*" -567- DISPLAY 'COMPILADO EM ' FUNCTION WHEN-COMPILED(7:2) '/' FUNCTION WHEN-COMPILED(5:2) '/' FUNCTION WHEN-COMPILED(1:4) ' AS ' FUNCTION WHEN-COMPILED(9:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) ' *' */

                $"COMPILADO EM FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)} *"
                .Display();

                /*" -568- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -569- DISPLAY ' CARTAO PARAMATRO INFORMADO' */
                _.Display($" CARTAO PARAMATRO INFORMADO");

                /*" -570- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -572- DISPLAY 'CONVENIO = ' PARM-CONV-PROCESSADO ' TIPO MOVIMENTO = ' PARM-TIPO-MOVIMENTO */

                $"CONVENIO = {LINK_PARM_CONV_PROCESSADO.PARM_CONV_PROCESSADO} TIPO MOVIMENTO = {LINK_PARM_CONV_PROCESSADO.PARM_TIPO_MOVIMENTO}"
                .Display();

                /*" -574- IF (PARM-TIPO-MOVIMENTO NOT EQUAL 'D' ) AND (PARM-TIPO-MOVIMENTO NOT EQUAL 'C' ) */

                if ((LINK_PARM_CONV_PROCESSADO.PARM_TIPO_MOVIMENTO != "D") && (LINK_PARM_CONV_PROCESSADO.PARM_TIPO_MOVIMENTO != "C"))
                {

                    /*" -575- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -576- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -577- DISPLAY '*           PROGRAMA SI5001B                   *' */
                    _.Display($"*           PROGRAMA SI5001B                   *");

                    /*" -578- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -579- DISPLAY '*        ERRO NO CARTAO PARAMETRO              *' */
                    _.Display($"*        ERRO NO CARTAO PARAMETRO              *");

                    /*" -580- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -581- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -582- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -584- DISPLAY ' ' . */
                _.Display($" ");

                /*" -586- MOVE PARM-CONV-PROCESSADO TO HOST-COD-CONVENIO. */
                _.Move(LINK_PARM_CONV_PROCESSADO.PARM_CONV_PROCESSADO, HOST_COD_CONVENIO);

                /*" -587- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -588- DISPLAY ' CODIGO DO CONVENIO QUE ESTA SENDO PROCESSADO' */
                _.Display($" CODIGO DO CONVENIO QUE ESTA SENDO PROCESSADO");

                /*" -589- DISPLAY ' INFORMADO VIA PARM = ' PARM-CONV-PROCESSADO. */
                _.Display($" INFORMADO VIA PARM = {LINK_PARM_CONV_PROCESSADO.PARM_CONV_PROCESSADO}");

                /*" -590- DISPLAY '***************************************************' */
                _.Display($"***************************************************");

                /*" -592- DISPLAY ' ' . */
                _.Display($" ");

                /*" -594- OPEN OUTPUT MOVDEBITO-CC RSI5001B. */
                MOVDEBITO_CC.Open(HEADER_REGISTRO);
                RSI5001B.Open(REG_SI5001B);

                /*" -596- PERFORM R010-LE-SISTEMAS THRU R010-EXIT. */

                R010_LE_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -598- PERFORM R015-LE-MONTA-NOME-EMPRESA THRU R015-EXIT. */

                R015_LE_MONTA_NOME_EMPRESA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/


                /*" -599- PERFORM R020-DECLARE-PARAM-CONTACEF THRU R020-EXIT. */

                R020_DECLARE_PARAM_CONTACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -600- MOVE 'NAO' TO WFIM-PARAMCON. */
                _.Move("NAO", AREA_DE_WORK.WFIM_PARAMCON);

                /*" -602- PERFORM R021-FETCH-PARAM-CONTACEF THRU R021-EXIT. */

                R021_FETCH_PARAM_CONTACEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -603- IF WFIM-PARAMCON EQUAL 'SIM' */

                if (AREA_DE_WORK.WFIM_PARAMCON == "SIM")
                {

                    /*" -604- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -605- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -606- DISPLAY '*           PROGRAMA SI5001B                   *' */
                    _.Display($"*           PROGRAMA SI5001B                   *");

                    /*" -607- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -608- DISPLAY '*             ERRO ANORMAL                     *' */
                    _.Display($"*             ERRO ANORMAL                     *");

                    /*" -609- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -610- DISPLAY '*   NAO FOI ENCONTRADO O REGISTRO NA           *' */
                    _.Display($"*   NAO FOI ENCONTRADO O REGISTRO NA           *");

                    /*" -611- DISPLAY '*   SEGUROS.PARAM_CONTACEF PARA PROCESSAMENTO  *' */
                    _.Display($"*   SEGUROS.PARAM_CONTACEF PARA PROCESSAMENTO  *");

                    /*" -612- DISPLAY '*   DA GERACAO DO ARQUIVO DE DEBITO / CREDITO  *' */
                    _.Display($"*   DA GERACAO DO ARQUIVO DE DEBITO / CREDITO  *");

                    /*" -613- DISPLAY '*   PARA C.E.F.                                *' */
                    _.Display($"*   PARA C.E.F.                                *");

                    /*" -614- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -615- DISPLAY '*----------------------------------------------*' */
                    _.Display($"*----------------------------------------------*");

                    /*" -617- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -619- MOVE 'NAO' TO W-CHAVE-TEM-MOVIMENTO-ENVIO. */
                _.Move("NAO", AREA_DE_WORK.W_CHAVE_TEM_MOVIMENTO_ENVIO);

                /*" -622- PERFORM R100-PROCESSA-PARAM-CONTACEF THRU R100-EXIT UNTIL WFIM-PARAMCON EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_PARAMCON == "SIM"))
                {

                    R100_PROCESSA_PARAM_CONTACEF(true);

                    R100_LE(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -623- IF W-TOTAL-LIDOS-MOVDEBCE EQUAL 0 */

                if (AREA_DE_WORK.W_TOTAL_LIDOS_MOVDEBCE == 0)
                {

                    /*" -624- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -626- DISPLAY '** NAO HOUVE MOVIMENTO PARA O CONVENIO ' PARAMCON-COD-CONVENIO ' NA DATA DE HOJE.' */

                    $"** NAO HOUVE MOVIMENTO PARA O CONVENIO {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO} NA DATA DE HOJE."
                    .Display();

                    /*" -627- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -628- MOVE 'NAO HOUVE MOVIMENTO NA DATA DE HOJE' TO LC08 */
                    _.Move("NAO HOUVE MOVIMENTO NA DATA DE HOJE", AREA_DE_WORK.LC08);

                    /*" -629- WRITE REG-SI5001B FROM LC08 AFTER 2 */
                    _.Move(AREA_DE_WORK.LC08.GetMoveValues(), REG_SI5001B);

                    RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

                    /*" -631- MOVE 90 TO W-CONTA-LINHA. */
                    _.Move(90, AREA_DE_WORK.W_CONTA_LINHA);
                }


                /*" -632- DISPLAY ' ' . */
                _.Display($" ");

                /*" -633- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -634- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -635- DISPLAY '*           SI5001B                 *' . */
                _.Display($"*           SI5001B                 *");

                /*" -636- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -637- DISPLAY '*  TERMINO NORMAL DE PROCESSAMENTO  *' . */
                _.Display($"*  TERMINO NORMAL DE PROCESSAMENTO  *");

                /*" -638- DISPLAY '*                                   *' . */
                _.Display($"*                                   *");

                /*" -640- DISPLAY '*************************************' . */
                _.Display($"*************************************");

                /*" -642- CLOSE MOVDEBITO-CC RSI5001B. */
                MOVDEBITO_CC.Close();
                RSI5001B.Close();

                /*" -642- EXEC SQL COMMIT WORK END-EXEC. */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -645- MOVE ZEROS TO RETURN-CODE. */
                _.Move(0, RETURN_CODE);

                /*" -645- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LINK_PARM_CONV_PROCESSADO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R010-LE-SISTEMAS */
        private void R010_LE_SISTEMAS(bool isPerform = false)
        {
            /*" -651- MOVE '001' TO WNR-EXEC-SQL. */
            _.Move("001", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -658- PERFORM R010_LE_SISTEMAS_DB_SELECT_1 */

            R010_LE_SISTEMAS_DB_SELECT_1();

            /*" -660- DISPLAY 'DATA SISTEMA .......' HOST-DATA-CORRENTE */
            _.Display($"DATA SISTEMA .......{HOST_DATA_CORRENTE}");

            /*" -662- DISPLAY 'HORA SISTEMA .......' HOST-HORA-CORRENTE. */
            _.Display($"HORA SISTEMA .......{HOST_HORA_CORRENTE}");

            /*" -663- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -664- DISPLAY 'SI5001B - SISTEMA CB NAO CADASTRADO' */
                _.Display($"SI5001B - SISTEMA CB NAO CADASTRADO");

                /*" -666- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -672- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) ' ' SISTEMAS-DATA-MOV-ABERTO(8:1) ' ' SISTEMAS-DATA-MOV-ABERTO(6:2) ' ' SISTEMAS-DATA-MOV-ABERTO(5:1) ' ' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -674- DISPLAY ' ' . */
            _.Display($" ");

            /*" -676- MOVE '002' TO WNR-EXEC-SQL. */
            _.Move("002", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -681- PERFORM R010_LE_SISTEMAS_DB_SELECT_2 */

            R010_LE_SISTEMAS_DB_SELECT_2();

            /*" -684- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -685- DISPLAY 'SI5001B - SISTEMA SI NAO CADASTRADO' */
                _.Display($"SI5001B - SISTEMA SI NAO CADASTRADO");

                /*" -687- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -689- DISPLAY 'DATA DO SISTEMA DE SINISTRO (SI)' . */
            _.Display($"DATA DO SISTEMA DE SINISTRO (SI)");

            /*" -694- DISPLAY SISTEMAS-DATA-MOV-ABERTO(9:2) ' ' SISTEMAS-DATA-MOV-ABERTO(8:1) ' ' SISTEMAS-DATA-MOV-ABERTO(6:2) ' ' SISTEMAS-DATA-MOV-ABERTO(5:1) ' ' SISTEMAS-DATA-MOV-ABERTO(1:4) */

            $"{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1)} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4)}"
            .Display();

            /*" -696- DISPLAY ' ' . */
            _.Display($" ");

            /*" -697- MOVE SISTEMAS-DATA-MOV-ABERTO(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -698- MOVE SISTEMAS-DATA-MOV-ABERTO(8:1) TO W-DATA-DD-MM-AAAA-DD-F1 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(8, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F1);

            /*" -699- MOVE SISTEMAS-DATA-MOV-ABERTO(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -700- MOVE SISTEMAS-DATA-MOV-ABERTO(5:1) TO W-DATA-DD-MM-AAAA-DD-F2 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(5, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F2);

            /*" -702- MOVE SISTEMAS-DATA-MOV-ABERTO(1:4) TO W-DATA-DD-MM-AAAA-AAAA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -704- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-SISTEMA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02.LC02_DATA_SISTEMA);

            /*" -705- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-DD-MM-AAAA-DD */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD);

            /*" -706- MOVE HOST-DATA-CORRENTE(8:1) TO W-DATA-DD-MM-AAAA-DD-F1 */
            _.Move(HOST_DATA_CORRENTE.Substring(8, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F1);

            /*" -707- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-DD-MM-AAAA-MM */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_MM);

            /*" -708- MOVE HOST-DATA-CORRENTE(5:1) TO W-DATA-DD-MM-AAAA-DD-F2 */
            _.Move(HOST_DATA_CORRENTE.Substring(5, 1), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_DD_F2);

            /*" -710- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-DD-MM-AAAA-AAAA. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_DD_MM_AAAA.W_DATA_DD_MM_AAAA_AAAA);

            /*" -712- MOVE W-DATA-DD-MM-AAAA TO LC02-DATA-CORRENTE LC03-DATA. */
            _.Move(AREA_DE_WORK.W_DATA_DD_MM_AAAA, AREA_DE_WORK.LC02_A.LC02_DATA_CORRENTE, AREA_DE_WORK.LC03.LC03_DATA);

            /*" -714- DISPLAY 'HORA CORRENTE ........ ' W-HORA-CORRENTE */
            _.Display($"HORA CORRENTE ........ {AREA_DE_WORK.W_HORA_CORRENTE}");

            /*" -714- MOVE HOST-HORA-CORRENTE TO LC03-HORA. */
            _.Move(HOST_HORA_CORRENTE, AREA_DE_WORK.LC03.LC03_HORA);

        }

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-1 */
        public void R010_LE_SISTEMAS_DB_SELECT_1()
        {
            /*" -658- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT DATE, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :HOST-DATA-CORRENTE, :HOST-HORA-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_1_Query1 = new R010_LE_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_1_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.HOST_DATA_CORRENTE, HOST_DATA_CORRENTE);
                _.Move(executed_1.HOST_HORA_CORRENTE, HOST_HORA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R010-LE-SISTEMAS-DB-SELECT-2 */
        public void R010_LE_SISTEMAS_DB_SELECT_2()
        {
            /*" -681- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_LE_SISTEMAS_DB_SELECT_2_Query1 = new R010_LE_SISTEMAS_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R010_LE_SISTEMAS_DB_SELECT_2_Query1.Execute(r010_LE_SISTEMAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA */
        private void R015_LE_MONTA_NOME_EMPRESA(bool isPerform = false)
        {
            /*" -722- MOVE '003' TO WNR-EXEC-SQL. */
            _.Move("003", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -727- PERFORM R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1 */

            R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1();

            /*" -730- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, REGISTRO_LINKAGE_SAP.WABEND.WABEND1.LK_LINK.LK_TITULO);

            /*" -732- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.LK_LINK);

            /*" -733- IF LK-RTCODE EQUAL ZEROS */

            if (REGISTRO_LINKAGE_SAP.WABEND.WABEND1.LK_LINK.LK_RTCODE == 00)
            {

                /*" -734- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(REGISTRO_LINKAGE_SAP.WABEND.WABEND1.LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -735- ELSE */
            }
            else
            {


                /*" -736- DISPLAY 'PROBLEMA CALL V0EMPRESA' */
                _.Display($"PROBLEMA CALL V0EMPRESA");

                /*" -736- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R015-LE-MONTA-NOME-EMPRESA-DB-SELECT-1 */
        public void R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1()
        {
            /*" -727- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC. */

            var r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1 = new R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1.Execute(r015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R015_EXIT*/

        [StopWatch]
        /*" R020-DECLARE-PARAM-CONTACEF */
        private void R020_DECLARE_PARAM_CONTACEF(bool isPerform = false)
        {
            /*" -744- MOVE '004' TO WNR-EXEC-SQL. */
            _.Move("004", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -754- PERFORM R020_DECLARE_PARAM_CONTACEF_DB_DECLARE_1 */

            R020_DECLARE_PARAM_CONTACEF_DB_DECLARE_1();

            /*" -756- PERFORM R020_DECLARE_PARAM_CONTACEF_DB_OPEN_1 */

            R020_DECLARE_PARAM_CONTACEF_DB_OPEN_1();

            /*" -758- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -759- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -759- END-IF. */
            }


        }

        [StopWatch]
        /*" R020-DECLARE-PARAM-CONTACEF-DB-DECLARE-1 */
        public void R020_DECLARE_PARAM_CONTACEF_DB_DECLARE_1()
        {
            /*" -754- EXEC SQL DECLARE C01_PARAMCON CURSOR WITH HOLD FOR SELECT MAX(NSAS) FROM SEGUROS.PARAM_CONTACEF WHERE TIPO_MOVTO_CC = 1 AND COD_CONVENIO = :HOST-COD-CONVENIO AND TIMESTAMP = ( SELECT MAX(TIMESTAMP) FROM SEGUROS.PARAM_CONTACEF WHERE TIPO_MOVTO_CC = 1 AND COD_CONVENIO = :HOST-COD-CONVENIO ) END-EXEC. */
            C01_PARAMCON = new SI5001B_C01_PARAMCON(true);
            string GetQuery_C01_PARAMCON()
            {
                var query = @$"SELECT MAX(NSAS) 
							FROM SEGUROS.PARAM_CONTACEF 
							WHERE TIPO_MOVTO_CC = 1 
							AND COD_CONVENIO = '{HOST_COD_CONVENIO}' 
							AND TIMESTAMP = 
							( SELECT MAX(TIMESTAMP) 
							FROM SEGUROS.PARAM_CONTACEF 
							WHERE TIPO_MOVTO_CC = 1 
							AND COD_CONVENIO = '{HOST_COD_CONVENIO}' )";

                return query;
            }
            C01_PARAMCON.GetQueryEvent += GetQuery_C01_PARAMCON;

        }

        [StopWatch]
        /*" R020-DECLARE-PARAM-CONTACEF-DB-OPEN-1 */
        public void R020_DECLARE_PARAM_CONTACEF_DB_OPEN_1()
        {
            /*" -756- EXEC SQL OPEN C01_PARAMCON END-EXEC. */

            C01_PARAMCON.Open();

        }

        [StopWatch]
        /*" R200-DECLA-MOVTO-DEBITOCC-CEF-DB-DECLARE-1 */
        public void R200_DECLA_MOVTO_DEBITOCC_CEF_DB_DECLARE_1()
        {
            /*" -954- EXEC SQL DECLARE C01_MOVDEBCE CURSOR WITH HOLD FOR SELECT NUM_APOLICE AS NUM_APOL_SINISTRO, NUM_ENDOSSO AS CODPRODU_OPERACAO, NUM_PARCELA AS OCORHIST, COD_CONVENIO, COD_AGENCIA_DEB, OPER_CONTA_DEB, NUM_CONTA_DEB, DIG_CONTA_DEB, DATA_VENCIMENTO, DATA_MOVIMENTO, VALOR_DEBITO, VLR_CREDITO, SITUACAO_COBRANCA, COD_EMPRESA FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA = '0' AND COD_CONVENIO = :PARAMCON-COD-CONVENIO ORDER BY VALOR_DEBITO, VLR_CREDITO, NUM_APOL_SINISTRO, CODPRODU_OPERACAO, OCORHIST END-EXEC. */
            C01_MOVDEBCE = new SI5001B_C01_MOVDEBCE(true);
            string GetQuery_C01_MOVDEBCE()
            {
                var query = @$"SELECT NUM_APOLICE AS NUM_APOL_SINISTRO
							, 
							NUM_ENDOSSO AS CODPRODU_OPERACAO
							, 
							NUM_PARCELA AS OCORHIST
							, 
							COD_CONVENIO
							, 
							COD_AGENCIA_DEB
							, 
							OPER_CONTA_DEB
							, 
							NUM_CONTA_DEB
							, 
							DIG_CONTA_DEB
							, 
							DATA_VENCIMENTO
							, 
							DATA_MOVIMENTO
							, 
							VALOR_DEBITO
							, 
							VLR_CREDITO
							, 
							SITUACAO_COBRANCA
							, 
							COD_EMPRESA 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE SITUACAO_COBRANCA = '0' 
							AND COD_CONVENIO = '{PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO}' 
							ORDER BY VALOR_DEBITO
							, VLR_CREDITO
							, 
							NUM_APOL_SINISTRO
							, CODPRODU_OPERACAO
							, OCORHIST";

                return query;
            }
            C01_MOVDEBCE.GetQueryEvent += GetQuery_C01_MOVDEBCE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-PARAM-CONTACEF */
        private void R021_FETCH_PARAM_CONTACEF(bool isPerform = false)
        {
            /*" -767- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -769- PERFORM R021_FETCH_PARAM_CONTACEF_DB_FETCH_1 */

            R021_FETCH_PARAM_CONTACEF_DB_FETCH_1();

            /*" -772- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -774- ADD 1 TO W-LIDOS-PARAMCON. */
                AREA_DE_WORK.W_LIDOS_PARAMCON.Value = AREA_DE_WORK.W_LIDOS_PARAMCON + 1;
            }


            /*" -775- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -776- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -777- MOVE 'SIM' TO WFIM-PARAMCON */
                    _.Move("SIM", AREA_DE_WORK.WFIM_PARAMCON);

                    /*" -777- PERFORM R021_FETCH_PARAM_CONTACEF_DB_CLOSE_1 */

                    R021_FETCH_PARAM_CONTACEF_DB_CLOSE_1();

                    /*" -779- ELSE */
                }
                else
                {


                    /*" -780- DISPLAY 'ERRO NO FETCH PARAM_CONTACEF...............' */
                    _.Display($"ERRO NO FETCH PARAM_CONTACEF...............");

                    /*" -782- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -792- PERFORM R021_FETCH_PARAM_CONTACEF_DB_SELECT_1 */

            R021_FETCH_PARAM_CONTACEF_DB_SELECT_1();

            /*" -795- DISPLAY ' ' */
            _.Display($" ");

            /*" -796- DISPLAY 'LIDO NA PARAM_CONTA_CEF: ' */
            _.Display($"LIDO NA PARAM_CONTA_CEF: ");

            /*" -797- DISPLAY ' ' */
            _.Display($" ");

            /*" -800- DISPLAY 'HOST-COD-CONVENIO - ' HOST-COD-CONVENIO ' CONVENIO - ' PARAMCON-COD-CONVENIO '  / ' PARAMCON-DESCR-CONVENIO ' NSA - ' PARAMCON-NSAS. */

            $"HOST-COD-CONVENIO - {HOST_COD_CONVENIO} CONVENIO - {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO}  / {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DESCR_CONVENIO} NSA - {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS}"
            .Display();

        }

        [StopWatch]
        /*" R021-FETCH-PARAM-CONTACEF-DB-FETCH-1 */
        public void R021_FETCH_PARAM_CONTACEF_DB_FETCH_1()
        {
            /*" -769- EXEC SQL FETCH C01_PARAMCON INTO :PARAMCON-NSAS END-EXEC. */

            if (C01_PARAMCON.Fetch())
            {
                _.Move(C01_PARAMCON.PARAMCON_NSAS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS);
            }

        }

        [StopWatch]
        /*" R021-FETCH-PARAM-CONTACEF-DB-CLOSE-1 */
        public void R021_FETCH_PARAM_CONTACEF_DB_CLOSE_1()
        {
            /*" -777- EXEC SQL CLOSE C01_PARAMCON END-EXEC */

            C01_PARAMCON.Close();

        }

        [StopWatch]
        /*" R021-FETCH-PARAM-CONTACEF-DB-SELECT-1 */
        public void R021_FETCH_PARAM_CONTACEF_DB_SELECT_1()
        {
            /*" -792- EXEC SQL SELECT DISTINCT COD_CONVENIO, DESCR_CONVENIO INTO :PARAMCON-COD-CONVENIO, :PARAMCON-DESCR-CONVENIO FROM SEGUROS.PARAM_CONTACEF WHERE TIPO_MOVTO_CC = 1 AND COD_CONVENIO = :HOST-COD-CONVENIO ORDER BY COD_CONVENIO, DESCR_CONVENIO END-EXEC. */

            var r021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1 = new R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1()
            {
                HOST_COD_CONVENIO = HOST_COD_CONVENIO.ToString(),
            };

            var executed_1 = R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1.Execute(r021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMCON_COD_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);
                _.Move(executed_1.PARAMCON_DESCR_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DESCR_CONVENIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-PARAM-CONTACEF */
        private void R100_PROCESSA_PARAM_CONTACEF(bool isPerform = false)
        {
            /*" -808- PERFORM R900-IMPRIME-CABEC-CONVENIO THRU R900-EXIT. */

            R900_IMPRIME_CABEC_CONVENIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R900_EXIT*/


            /*" -810- MOVE HOST-COD-CONVENIO TO MOVDEBCE-COD-CONVENIO . */
            _.Move(HOST_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -811- PERFORM R200-DECLA-MOVTO-DEBITOCC-CEF THRU R200-EXIT. */

            R200_DECLA_MOVTO_DEBITOCC_CEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/


            /*" -812- MOVE 'NAO' TO WFIM-MOVDEBCE. */
            _.Move("NAO", AREA_DE_WORK.WFIM_MOVDEBCE);

            /*" -817- PERFORM R201-FETCH-MOVTO-DEBITOCC-CEF THRU R201-EXIT. */

            R201_FETCH_MOVTO_DEBITOCC_CEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/


            /*" -819- PERFORM R110-PROCESSA-HEADER THRU R110-EXIT. */

            R110_PROCESSA_HEADER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/


            /*" -824- MOVE ZEROS TO W-LIDOS-MOVDEBCE-DEBITO W-LIDOS-MOVDEBCE-CREDITO W-TOTAL-CREDITOS W-TOTAL-DEBITOS. */
            _.Move(0, AREA_DE_WORK.W_LIDOS_MOVDEBCE_DEBITO, AREA_DE_WORK.W_LIDOS_MOVDEBCE_CREDITO, AREA_DE_WORK.W_TOTAL_CREDITOS, AREA_DE_WORK.W_TOTAL_DEBITOS);

            /*" -827- PERFORM R300-PCS-MOVTO-DEBITOCC-CEF THRU R300-EXIT UNTIL WFIM-MOVDEBCE EQUAL 'SIM' . */

            while (!(AREA_DE_WORK.WFIM_MOVDEBCE == "SIM"))
            {

                R300_PCS_MOVTO_DEBITOCC_CEF(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

            }

            /*" -829- PERFORM R120-PROCESSA-TRAILLER THRU R120-EXIT. */

            R120_PROCESSA_TRAILLER(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/


            /*" -831- PERFORM R130-IMPRIME-TOTAIS THRU R130-EXIT. */

            R130_IMPRIME_TOTAIS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/


            /*" -831- PERFORM R600-UPDATE-PARAM-CONTA-CEF THRU R600-EXIT. */

            R600_UPDATE_PARAM_CONTA_CEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R600_EXIT*/


        }

        [StopWatch]
        /*" R100-LE */
        private void R100_LE(bool isPerform = false)
        {
            /*" -835- PERFORM R021-FETCH-PARAM-CONTACEF THRU R021-EXIT. */

            R021_FETCH_PARAM_CONTACEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R110-PROCESSA-HEADER */
        private void R110_PROCESSA_HEADER(bool isPerform = false)
        {
            /*" -842- MOVE ALL SPACES TO HEADER-REGISTRO */
            _.MoveAll("", HEADER_REGISTRO);

            /*" -843- MOVE 'A' TO HEADER-CODREGISTRO */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -844- MOVE 1 TO HEADER-CODREMESSA */
            _.Move(1, HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -845- MOVE MOVDEBCE-COD-CONVENIO TO W-COD-CONVENIO-TOTAL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, AREA_DE_WORK.W_COD_CONVENIO_TOTAL);

            /*" -846- MOVE W-COD-CONVENIO-REAL TO HEADER-CODCONVENIO */
            _.Move(AREA_DE_WORK.FILLER_6.W_COD_CONVENIO_REAL, HEADER_REGISTRO.HEADER_CODCONVENIO);

            /*" -847- MOVE 'CAIXA SEGUROS LOTERI' TO HEADER-NOMEMPRESA */
            _.Move("CAIXA SEGUROS LOTERI", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -848- MOVE 104 TO HEADER-CODBANCO */
            _.Move(104, HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -850- MOVE 'CEF' TO HEADER-NOMBANCO */
            _.Move("CEF", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -851- MOVE HOST-DATA-CORRENTE(9:2) TO W-DATA-AAAAMMDD-DIA. */
            _.Move(HOST_DATA_CORRENTE.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DIA);

            /*" -852- MOVE HOST-DATA-CORRENTE(6:2) TO W-DATA-AAAAMMDD-MES. */
            _.Move(HOST_DATA_CORRENTE.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MES);

            /*" -853- MOVE HOST-DATA-CORRENTE(1:4) TO W-DATA-AAAAMMDD-ANO. */
            _.Move(HOST_DATA_CORRENTE.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_ANO);

            /*" -855- MOVE W-DATA-AAAAMMDD TO HEADER-DATGERACAO. */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, HEADER_REGISTRO.HEADER_DATGERACAO);

            /*" -856- COMPUTE PARAMCON-NSAS = PARAMCON-NSAS + 1. */
            PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.Value = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS + 1;

            /*" -858- MOVE PARAMCON-NSAS TO HEADER-NSA */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, HEADER_REGISTRO.HEADER_NSA);

            /*" -859- MOVE 04 TO HEADER-VERSAO */
            _.Move(04, HEADER_REGISTRO.HEADER_VERSAO);

            /*" -860- MOVE 'DEB/CRED AUTOMAT' TO HEADER-DEBITOAUT */
            _.Move("DEB/CRED AUTOMAT", HEADER_REGISTRO.HEADER_DEBITOAUT);

            /*" -862- MOVE ALL '-' TO HEADER-FILLER */
            _.MoveAll("-", HEADER_REGISTRO.HEADER_FILLER);

            /*" -862- WRITE HEADER-REGISTRO. */
            MOVDEBITO_CC.Write(HEADER_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R110_EXIT*/

        [StopWatch]
        /*" R120-PROCESSA-TRAILLER */
        private void R120_PROCESSA_TRAILLER(bool isPerform = false)
        {
            /*" -869- MOVE ALL SPACES TO TRAILL-REGISTRO */
            _.MoveAll("", TRAILL_REGISTRO);

            /*" -871- MOVE 'Z' TO TRAILL-CODREGISTRO */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -874- COMPUTE TRAILL-TOTREGISTRO = W-LIDOS-MOVDEBCE-DEBITO + W-LIDOS-MOVDEBCE-CREDITO + 2. */
            TRAILL_REGISTRO.TRAILL_TOTREGISTRO.Value = AREA_DE_WORK.W_LIDOS_MOVDEBCE_DEBITO + AREA_DE_WORK.W_LIDOS_MOVDEBCE_CREDITO + 2;

            /*" -875- MOVE W-TOTAL-DEBITOS TO TRAILL-VLRTOTDEB. */
            _.Move(AREA_DE_WORK.W_TOTAL_DEBITOS, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -876- MOVE W-TOTAL-CREDITOS TO TRAILL-VLRTOTCRE. */
            _.Move(AREA_DE_WORK.W_TOTAL_CREDITOS, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -877- MOVE ALL '-' TO TRAILL-FILLER. */
            _.MoveAll("-", TRAILL_REGISTRO.TRAILL_FILLER);

            /*" -877- WRITE TRAILL-REGISTRO. */
            MOVDEBITO_CC.Write(TRAILL_REGISTRO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R120_EXIT*/

        [StopWatch]
        /*" R130-IMPRIME-TOTAIS */
        private void R130_IMPRIME_TOTAIS(bool isPerform = false)
        {
            /*" -885- COMPUTE W-TOT-REG-GRAVADOS = W-LIDOS-MOVDEBCE-DEBITO + W-LIDOS-MOVDEBCE-CREDITO. */
            AREA_DE_WORK.W_TOT_REG_GRAVADOS.Value = AREA_DE_WORK.W_LIDOS_MOVDEBCE_DEBITO + AREA_DE_WORK.W_LIDOS_MOVDEBCE_CREDITO;

            /*" -886- DISPLAY ' ' */
            _.Display($" ");

            /*" -890- DISPLAY '** TOTAIS DE CONTROLE DO CONVENIO ' PARAMCON-COD-CONVENIO ' PRODUTO - ' PARAMCON-COD-PRODUTO ' NA DATA DE HOJE. **' */

            $"** TOTAIS DE CONTROLE DO CONVENIO {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO} PRODUTO - {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO} NA DATA DE HOJE. **"
            .Display();

            /*" -891- DISPLAY ' ' */
            _.Display($" ");

            /*" -892- MOVE W-TOT-REG-GRAVADOS TO W-EDICAO1 */
            _.Move(AREA_DE_WORK.W_TOT_REG_GRAVADOS, AREA_DE_WORK.W_EDICAO1);

            /*" -894- DISPLAY '  QTD. TOTAL DE REGISTROS GRAVADOS ' W-EDICAO1 */
            _.Display($"  QTD. TOTAL DE REGISTROS GRAVADOS {AREA_DE_WORK.W_EDICAO1}");

            /*" -895- DISPLAY '  CREDITOS               ' */
            _.Display($"  CREDITOS               ");

            /*" -896- MOVE W-LIDOS-MOVDEBCE-CREDITO TO W-EDICAO1 */
            _.Move(AREA_DE_WORK.W_LIDOS_MOVDEBCE_CREDITO, AREA_DE_WORK.W_EDICAO1);

            /*" -897- DISPLAY '  QTD. REGISTROS ....... ' W-EDICAO1 */
            _.Display($"  QTD. REGISTROS ....... {AREA_DE_WORK.W_EDICAO1}");

            /*" -898- MOVE W-TOTAL-CREDITOS TO W-EDICAO2 */
            _.Move(AREA_DE_WORK.W_TOTAL_CREDITOS, AREA_DE_WORK.W_EDICAO2);

            /*" -899- DISPLAY '  TOTAL DE CREDITOS .... ' W-EDICAO2 */
            _.Display($"  TOTAL DE CREDITOS .... {AREA_DE_WORK.W_EDICAO2}");

            /*" -900- DISPLAY '  DEBITOS                ' */
            _.Display($"  DEBITOS                ");

            /*" -901- MOVE W-LIDOS-MOVDEBCE-DEBITO TO W-EDICAO1 */
            _.Move(AREA_DE_WORK.W_LIDOS_MOVDEBCE_DEBITO, AREA_DE_WORK.W_EDICAO1);

            /*" -902- DISPLAY '  QTD. REGISTROS ....... ' W-EDICAO1 */
            _.Display($"  QTD. REGISTROS ....... {AREA_DE_WORK.W_EDICAO1}");

            /*" -903- MOVE W-TOTAL-DEBITOS TO W-EDICAO2 */
            _.Move(AREA_DE_WORK.W_TOTAL_DEBITOS, AREA_DE_WORK.W_EDICAO2);

            /*" -905- DISPLAY '  TOTAL DE DEBITOS ..... ' W-EDICAO2. */
            _.Display($"  TOTAL DE DEBITOS ..... {AREA_DE_WORK.W_EDICAO2}");

            /*" -906- MOVE W-TOT-REG-GRAVADOS TO LT01-TOTAL-REGISTROS. */
            _.Move(AREA_DE_WORK.W_TOT_REG_GRAVADOS, AREA_DE_WORK.LT01.LT01_TOTAL_REGISTROS);

            /*" -907- MOVE W-TOTAL-CREDITOS TO LT02-TOTAL-CREDITOS. */
            _.Move(AREA_DE_WORK.W_TOTAL_CREDITOS, AREA_DE_WORK.LT02.LT02_TOTAL_CREDITOS);

            /*" -909- MOVE W-TOTAL-DEBITOS TO LT03-TOTAL-DEBITOS. */
            _.Move(AREA_DE_WORK.W_TOTAL_DEBITOS, AREA_DE_WORK.LT03.LT03_TOTAL_DEBITOS);

            /*" -910- IF W-CONTA-LINHA GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA > 60)
            {

                /*" -912- PERFORM R900-IMPRIME-CABEC-CONVENIO THRU R900-EXIT. */

                R900_IMPRIME_CABEC_CONVENIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R900_EXIT*/

            }


            /*" -913- WRITE REG-SI5001B FROM LT00 AFTER 2. */
            _.Move(AREA_DE_WORK.LT00.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -914- WRITE REG-SI5001B FROM LT01 AFTER 1. */
            _.Move(AREA_DE_WORK.LT01.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -915- WRITE REG-SI5001B FROM LT02 AFTER 1. */
            _.Move(AREA_DE_WORK.LT02.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -916- WRITE REG-SI5001B FROM LT03 AFTER 1. */
            _.Move(AREA_DE_WORK.LT03.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -917- MOVE PARAMCON-NSAS TO LT04-NRFITA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, AREA_DE_WORK.LT04.LT04_NRFITA);

            /*" -918- WRITE REG-SI5001B FROM LT04 AFTER 2. */
            _.Move(AREA_DE_WORK.LT04.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -918- MOVE 90 TO W-CONTA-LINHA. */
            _.Move(90, AREA_DE_WORK.W_CONTA_LINHA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R130_EXIT*/

        [StopWatch]
        /*" R200-DECLA-MOVTO-DEBITOCC-CEF */
        private void R200_DECLA_MOVTO_DEBITOCC_CEF(bool isPerform = false)
        {
            /*" -926- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -954- PERFORM R200_DECLA_MOVTO_DEBITOCC_CEF_DB_DECLARE_1 */

            R200_DECLA_MOVTO_DEBITOCC_CEF_DB_DECLARE_1();

            /*" -956- PERFORM R200_DECLA_MOVTO_DEBITOCC_CEF_DB_OPEN_1 */

            R200_DECLA_MOVTO_DEBITOCC_CEF_DB_OPEN_1();

            /*" -958- IF SQLCODE < 0 */

            if (DB.SQLCODE < 0)
            {

                /*" -959- GO TO R10010199-MENSAGEM-LOCK */

                R10010199_MENSAGEM_LOCK(); //GOTO
                return;

                /*" -959- END-IF. */
            }


        }

        [StopWatch]
        /*" R200-DECLA-MOVTO-DEBITOCC-CEF-DB-OPEN-1 */
        public void R200_DECLA_MOVTO_DEBITOCC_CEF_DB_OPEN_1()
        {
            /*" -956- EXEC SQL OPEN C01_MOVDEBCE END-EXEC. */

            C01_MOVDEBCE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R201-FETCH-MOVTO-DEBITOCC-CEF */
        private void R201_FETCH_MOVTO_DEBITOCC_CEF(bool isPerform = false)
        {
            /*" -967- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -982- PERFORM R201_FETCH_MOVTO_DEBITOCC_CEF_DB_FETCH_1 */

            R201_FETCH_MOVTO_DEBITOCC_CEF_DB_FETCH_1();

            /*" -991- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -993- ADD 1 TO W-TOTAL-LIDOS-MOVDEBCE */
                AREA_DE_WORK.W_TOTAL_LIDOS_MOVDEBCE.Value = AREA_DE_WORK.W_TOTAL_LIDOS_MOVDEBCE + 1;

                /*" -994- IF PARM-TIPO-MOVIMENTO EQUAL 'D' */

                if (LINK_PARM_CONV_PROCESSADO.PARM_TIPO_MOVIMENTO == "D")
                {

                    /*" -995- IF MOVDEBCE-VALOR-DEBITO EQUAL ZERO */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO == 00)
                    {

                        /*" -996- GO TO R201-FETCH-MOVTO-DEBITOCC-CEF */
                        new Task(() => R201_FETCH_MOVTO_DEBITOCC_CEF()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -998- END-IF */
                    }


                    /*" -999- ELSE */
                }
                else
                {


                    /*" -1000- IF MOVDEBCE-VLR-CREDITO EQUAL ZERO */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO == 00)
                    {

                        /*" -1001- GO TO R201-FETCH-MOVTO-DEBITOCC-CEF */
                        new Task(() => R201_FETCH_MOVTO_DEBITOCC_CEF()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -1018- END-IF. */
                    }

                }

            }


            /*" -1019- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1020- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1021- MOVE 'SIM' TO WFIM-MOVDEBCE */
                    _.Move("SIM", AREA_DE_WORK.WFIM_MOVDEBCE);

                    /*" -1021- PERFORM R201_FETCH_MOVTO_DEBITOCC_CEF_DB_CLOSE_1 */

                    R201_FETCH_MOVTO_DEBITOCC_CEF_DB_CLOSE_1();

                    /*" -1023- GO TO R201-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/ //GOTO
                    return;

                    /*" -1024- ELSE */
                }
                else
                {


                    /*" -1025- DISPLAY 'ERRO FETCH MOVTO_DEBITOCC_CEF ............. ' */
                    _.Display($"ERRO FETCH MOVTO_DEBITOCC_CEF ............. ");

                    /*" -1026- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -1030- END-IF. */
                }

            }


            /*" -1031- PERFORM R210-00-VER-COBRANCA-SUSP THRU R210-EXIT. */

            R210_00_VER_COBRANCA_SUSP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/


            /*" -1032- IF WS-CONTADOR > 0 */

            if (AREA_DE_WORK.WS_CONTADOR > 0)
            {

                /*" -1042- DISPLAY 'R201-DEBITO/CREDITO - SUSPENSO ' ' SIN=' MOVDEBCE-NUM-APOLICE ' END=' MOVDEBCE-NUM-ENDOSSO ' PCL=' MOVDEBCE-NUM-PARCELA ' CONV=' MOVDEBCE-COD-CONVENIO ' VENC=' MOVDEBCE-DATA-VENCIMENTO ' DTMOV=' MOVDEBCE-DATA-MOVIMENTO ' VLRDEB=' MOVDEBCE-VALOR-DEBITO ' VLRCRED=' MOVDEBCE-VLR-CREDITO ' LOT=' WS-COD-LOT-FENAL */

                $"R201-DEBITO/CREDITO - SUSPENSO  SIN={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} END={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} PCL={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} CONV={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO} VENC={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO} DTMOV={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO} VLRDEB={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO} VLRCRED={MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO} LOT={AREA_DE_WORK.WS_COD_LOT_FENAL}"
                .Display();

                /*" -1043- GO TO R201-FETCH-MOVTO-DEBITOCC-CEF */
                new Task(() => R201_FETCH_MOVTO_DEBITOCC_CEF()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...

                /*" -1043- END-IF. */
            }


        }

        [StopWatch]
        /*" R201-FETCH-MOVTO-DEBITOCC-CEF-DB-FETCH-1 */
        public void R201_FETCH_MOVTO_DEBITOCC_CEF_DB_FETCH_1()
        {
            /*" -982- EXEC SQL FETCH C01_MOVDEBCE INTO :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-COD-CONVENIO, :MOVDEBCE-COD-AGENCIA-DEB, :MOVDEBCE-OPER-CONTA-DEB, :MOVDEBCE-NUM-CONTA-DEB, :MOVDEBCE-DIG-CONTA-DEB, :MOVDEBCE-DATA-VENCIMENTO, :MOVDEBCE-DATA-MOVIMENTO, :MOVDEBCE-VALOR-DEBITO, :MOVDEBCE-VLR-CREDITO, :MOVDEBCE-SITUACAO-COBRANCA, :MOVDEBCE-COD-EMPRESA END-EXEC. */

            if (C01_MOVDEBCE.Fetch())
            {
                _.Move(C01_MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(C01_MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(C01_MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(C01_MOVDEBCE.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(C01_MOVDEBCE.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(C01_MOVDEBCE.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(C01_MOVDEBCE.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(C01_MOVDEBCE.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(C01_MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(C01_MOVDEBCE.MOVDEBCE_DATA_MOVIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);
                _.Move(C01_MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(C01_MOVDEBCE.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(C01_MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(C01_MOVDEBCE.MOVDEBCE_COD_EMPRESA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);
            }

        }

        [StopWatch]
        /*" R201-FETCH-MOVTO-DEBITOCC-CEF-DB-CLOSE-1 */
        public void R201_FETCH_MOVTO_DEBITOCC_CEF_DB_CLOSE_1()
        {
            /*" -1021- EXEC SQL CLOSE C01_MOVDEBCE END-EXEC */

            C01_MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/

        [StopWatch]
        /*" R210-00-VER-COBRANCA-SUSP */
        private void R210_00_VER_COBRANCA_SUSP(bool isPerform = false)
        {
            /*" -1054- MOVE 0 TO WS-CONTADOR */
            _.Move(0, AREA_DE_WORK.WS_CONTADOR);

            /*" -1059- PERFORM R210_00_VER_COBRANCA_SUSP_DB_SELECT_1 */

            R210_00_VER_COBRANCA_SUSP_DB_SELECT_1();

            /*" -1062- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1063- DISPLAY 'R210-ERRO LER LOTERICO01 - SQLCODE=' SQLCODE */
                _.Display($"R210-ERRO LER LOTERICO01 - SQLCODE={DB.SQLCODE}");

                /*" -1064- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1066- END-IF */
            }


            /*" -1072- PERFORM R210_00_VER_COBRANCA_SUSP_DB_SELECT_2 */

            R210_00_VER_COBRANCA_SUSP_DB_SELECT_2();

            /*" -1074- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1076- DISPLAY 'R210-ERRO LER LOTERICO01 ** - SQLCODE=' SQLCODE */
                _.Display($"R210-ERRO LER LOTERICO01 ** - SQLCODE={DB.SQLCODE}");

                /*" -1077- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1078- END-IF */
            }


            /*" -1078- . */

        }

        [StopWatch]
        /*" R210-00-VER-COBRANCA-SUSP-DB-SELECT-1 */
        public void R210_00_VER_COBRANCA_SUSP_DB_SELECT_1()
        {
            /*" -1059- EXEC SQL SELECT COD_LOT_FENAL INTO :WS-COD-LOT-FENAL FROM SEGUROS.SINI_LOTERICO01 WHERE NUM_APOL_SINISTRO = :MOVDEBCE-NUM-APOLICE END-EXEC. */

            var r210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1 = new R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1.Execute(r210_00_VER_COBRANCA_SUSP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_LOT_FENAL, AREA_DE_WORK.WS_COD_LOT_FENAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R210_EXIT*/

        [StopWatch]
        /*" R210-00-VER-COBRANCA-SUSP-DB-SELECT-2 */
        public void R210_00_VER_COBRANCA_SUSP_DB_SELECT_2()
        {
            /*" -1072- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WS-CONTADOR FROM SEGUROS.LOTERICO01 WHERE COD_LOT_FENAL = :WS-COD-LOT-FENAL AND OPCAO_DEP = 'S' END-EXEC. */

            var r210_00_VER_COBRANCA_SUSP_DB_SELECT_2_Query1 = new R210_00_VER_COBRANCA_SUSP_DB_SELECT_2_Query1()
            {
                WS_COD_LOT_FENAL = AREA_DE_WORK.WS_COD_LOT_FENAL.ToString(),
            };

            var executed_1 = R210_00_VER_COBRANCA_SUSP_DB_SELECT_2_Query1.Execute(r210_00_VER_COBRANCA_SUSP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CONTADOR, AREA_DE_WORK.WS_CONTADOR);
            }


        }

        [StopWatch]
        /*" R300-PCS-MOVTO-DEBITOCC-CEF */
        private void R300_PCS_MOVTO_DEBITOCC_CEF(bool isPerform = false)
        {
            /*" -1085- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 00)
            {

                /*" -1086- ADD MOVDEBCE-VALOR-DEBITO TO W-TOTAL-DEBITOS */
                AREA_DE_WORK.W_TOTAL_DEBITOS.Value = AREA_DE_WORK.W_TOTAL_DEBITOS + MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO;

                /*" -1088- ADD 1 TO W-LIDOS-MOVDEBCE-DEBITO. */
                AREA_DE_WORK.W_LIDOS_MOVDEBCE_DEBITO.Value = AREA_DE_WORK.W_LIDOS_MOVDEBCE_DEBITO + 1;
            }


            /*" -1089- IF MOVDEBCE-VLR-CREDITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 00)
            {

                /*" -1090- ADD MOVDEBCE-VLR-CREDITO TO W-TOTAL-CREDITOS */
                AREA_DE_WORK.W_TOTAL_CREDITOS.Value = AREA_DE_WORK.W_TOTAL_CREDITOS + MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO;

                /*" -1092- ADD 1 TO W-LIDOS-MOVDEBCE-CREDITO. */
                AREA_DE_WORK.W_LIDOS_MOVDEBCE_CREDITO.Value = AREA_DE_WORK.W_LIDOS_MOVDEBCE_CREDITO + 1;
            }


            /*" -1094- PERFORM R320-PCS-REGISTRO-E THRU R320-EXIT. */

            R320_PCS_REGISTRO_E(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/


            /*" -1100- PERFORM R330-UPD-MOVTO-DEBITOCC-CEF THRU R330-EXIT. */

            R330_UPD_MOVTO_DEBITOCC_CEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R330_EXIT*/


            /*" -1104- PERFORM R15000-GERA-SAP THRU R15000-EXIT. */

            R15000_GERA_SAP(true);

            R15000_GERA_MCP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R15000_EXIT*/


            /*" -1106- PERFORM R340-IMPRIME-RELATORIO THRU R340-EXIT. */

            R340_IMPRIME_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R340_EXIT*/


            /*" -1106- EXEC SQL COMMIT END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1109- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1110- DISPLAY 'ERRO COMMIT............. ' */
                _.Display($"ERRO COMMIT............. ");

                /*" -1111- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1113- END-IF. */
            }


            /*" -1113- PERFORM R201-FETCH-MOVTO-DEBITOCC-CEF THRU R201-EXIT. */

            R201_FETCH_MOVTO_DEBITOCC_CEF(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R201_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R320-PCS-REGISTRO-E */
        private void R320_PCS_REGISTRO_E(bool isPerform = false)
        {
            /*" -1120- MOVE ALL SPACES TO MOVCC-REGISTRO */
            _.MoveAll("", MOVCC_REGISTRO);

            /*" -1122- MOVE 'E' TO MOVCC-CODREGISTRO */
            _.Move("E", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -1123- MOVE MOVDEBCE-NUM-APOLICE TO W-NUM-APOL-SINISTRO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, AREA_DE_WORK.FILLER_3.W_NUM_APOL_SINISTRO);

            /*" -1124- MOVE MOVDEBCE-NUM-ENDOSSO TO W-PRODUTO-OPERACAO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, AREA_DE_WORK.W_PRODUTO_OPERACAO);

            /*" -1125- MOVE W-PRODUTO-OPERACAO-PRODUTO TO W-COD-PRODUTO. */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_PRODUTO, AREA_DE_WORK.FILLER_3.W_COD_PRODUTO);

            /*" -1126- MOVE W-PRODUTO-OPERACAO-OPERACAO TO W-COD-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO, AREA_DE_WORK.FILLER_3.W_COD_OPERACAO);

            /*" -1128- MOVE MOVDEBCE-NUM-PARCELA TO W-OCORR-HISTORICO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, AREA_DE_WORK.FILLER_3.W_OCORR_HISTORICO);

            /*" -1130- MOVE W-IDENT-CLIENTE-EMPRESA TO MOVCC-IDTCLIEMP. */
            _.Move(AREA_DE_WORK.W_IDENT_CLIENTE_EMPRESA, MOVCC_REGISTRO.MOVCC_IDTCLIEMP);

            /*" -1131- MOVE MOVDEBCE-COD-AGENCIA-DEB TO MOVCC-AGEDEBITO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_AGEDEBITO);

            /*" -1132- MOVE MOVDEBCE-OPER-CONTA-DEB TO W-OPER-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, AREA_DE_WORK.FILLER_2.W_OPER_CONTA);

            /*" -1133- MOVE MOVDEBCE-NUM-CONTA-DEB TO W-NUMERO-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, AREA_DE_WORK.FILLER_2.W_NUMERO_CONTA);

            /*" -1135- MOVE MOVDEBCE-DIG-CONTA-DEB TO W-DV-CONTA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, AREA_DE_WORK.FILLER_2.W_DV_CONTA);

            /*" -1136- MOVE ALL SPACES TO FILLER-1 */
            _.MoveAll("", AREA_DE_WORK.W_NUM_ENDOSSO.FILLER_1);

            /*" -1138- MOVE W-IDENT-CLIENTE-BANCO TO MOVCC-IDTCLIBAN. */
            _.Move(AREA_DE_WORK.W_IDENT_CLIENTE_BANCO, MOVCC_REGISTRO.MOVCC_IDTCLIBAN);

            /*" -1139- MOVE MOVDEBCE-DATA-VENCIMENTO(1:4) TO W-DATA-AAAAMMDD-ANO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(1, 4), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_ANO);

            /*" -1140- MOVE MOVDEBCE-DATA-VENCIMENTO(6:2) TO W-DATA-AAAAMMDD-MES. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(6, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_MES);

            /*" -1141- MOVE MOVDEBCE-DATA-VENCIMENTO(9:2) TO W-DATA-AAAAMMDD-DIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.Substring(9, 2), AREA_DE_WORK.W_DATA_AAAAMMDD.W_DATA_AAAAMMDD_DIA);

            /*" -1143- MOVE W-DATA-AAAAMMDD TO MOVCC-DTVENCTO */
            _.Move(AREA_DE_WORK.W_DATA_AAAAMMDD, MOVCC_REGISTRO.MOVCC_DTVENCTO);

            /*" -1145- MOVE 9 TO MOVCC-CODMOVTO */
            _.Move(9, MOVCC_REGISTRO.MOVCC_CODMOVTO);

            /*" -1146- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 00)
            {

                /*" -1147- MOVE MOVDEBCE-VALOR-DEBITO TO MOVCC-VLRDEBITO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, MOVCC_REGISTRO.MOVCC_VLRDEBITO);

                /*" -1149- MOVE 0 TO MOVCC-CODMOVTO. */
                _.Move(0, MOVCC_REGISTRO.MOVCC_CODMOVTO);
            }


            /*" -1150- IF MOVDEBCE-VLR-CREDITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 00)
            {

                /*" -1151- MOVE MOVDEBCE-VLR-CREDITO TO MOVCC-VLRDEBITO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, MOVCC_REGISTRO.MOVCC_VLRDEBITO);

                /*" -1153- MOVE 2 TO MOVCC-CODMOVTO. */
                _.Move(2, MOVCC_REGISTRO.MOVCC_CODMOVTO);
            }


            /*" -1155- MOVE '03' TO MOVCC-CODMOEDA. */
            _.Move("03", MOVCC_REGISTRO.MOVCC_CODMOEDA);

            /*" -1156- MOVE MOVDEBCE-COD-CONVENIO TO W-USO-EMP-COD-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, AREA_DE_WORK.FILLER_8.W_USO_EMP_COD_CONVENIO);

            /*" -1157- MOVE PARAMCON-NSAS TO W-USO-EMP-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, AREA_DE_WORK.FILLER_8.W_USO_EMP_NSAS);

            /*" -1159- MOVE MOVDEBCE-DATA-MOVIMENTO TO W-USO-EMP-DATA-MOVIMENTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO, AREA_DE_WORK.FILLER_8.W_USO_EMP_DATA_MOVIMENTO);

            /*" -1161- MOVE MOVDEBCE-NUM-APOLICE TO W-USO-EMP-NUM-APOL-SINISTRO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, AREA_DE_WORK.FILLER_8.W_USO_EMP_NUM_APOL_SINISTRO);

            /*" -1162- MOVE MOVDEBCE-NUM-ENDOSSO TO W-PRODUTO-OPERACAO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, AREA_DE_WORK.W_PRODUTO_OPERACAO);

            /*" -1163- MOVE W-PRODUTO-OPERACAO-PRODUTO TO W-USO-EMP-COD-PRODUTO. */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_PRODUTO, AREA_DE_WORK.FILLER_8.W_USO_EMP_COD_PRODUTO);

            /*" -1164- MOVE W-PRODUTO-OPERACAO-OPERACAO TO W-USO-EMP-COD-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO, AREA_DE_WORK.FILLER_8.W_USO_EMP_COD_OPERACAO);

            /*" -1166- MOVE MOVDEBCE-NUM-PARCELA TO W-USO-EMP-OCORR-HISTORICO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, AREA_DE_WORK.FILLER_8.W_USO_EMP_OCORR_HISTORICO);

            /*" -1167- MOVE MOVDEBCE-COD-EMPRESA TO W-USO-EMP-COD-EMPRESA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA, AREA_DE_WORK.FILLER_8.W_USO_EMP_COD_EMPRESA);

            /*" -1171- MOVE ALL '/' TO W-USO-EMP-FILLER-1 W-USO-EMP-FILLER-2 W-USO-EMP-FILLER-3 W-USO-EMP-FILLER-4 W-USO-EMP-FILLER-5 W-USO-EMP-FILLER-6 W-USO-EMP-FILLER-7 W-USO-EMP-FILLER-8 W-USO-EMP-FILLER-9 */
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_1);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_2);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_3);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_4);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_5);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_6);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_7);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_8);
            _.Move("/", AREA_DE_WORK.FILLER_8.W_USO_EMP_FILLER_9);


            /*" -1172- MOVE W-USO-EMPRESA TO MOVCC-USOEMPRESA. */
            _.Move(AREA_DE_WORK.W_USO_EMPRESA, MOVCC_REGISTRO.MOVCC_USOEMPRESA);

            /*" -1174- MOVE ALL '-' TO MOVCC-FILLER. */
            _.MoveAll("-", MOVCC_REGISTRO.MOVCC_FILLER);

            /*" -1176- WRITE MOVCC-REGISTRO. */
            MOVDEBITO_CC.Write(MOVCC_REGISTRO.GetMoveValues().ToString());

            /*" -1178- ADD 1 TO W-TOTAL-REGISTROS-ENVIADOS. */
            AREA_DE_WORK.W_TOTAL_REGISTROS_ENVIADOS.Value = AREA_DE_WORK.W_TOTAL_REGISTROS_ENVIADOS + 1;

            /*" -1179- IF W-CHAVE-TEM-MOVIMENTO-ENVIO EQUAL 'NAO' */

            if (AREA_DE_WORK.W_CHAVE_TEM_MOVIMENTO_ENVIO == "NAO")
            {

                /*" -1179- MOVE 'SIM' TO W-CHAVE-TEM-MOVIMENTO-ENVIO. */
                _.Move("SIM", AREA_DE_WORK.W_CHAVE_TEM_MOVIMENTO_ENVIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R320_EXIT*/

        [StopWatch]
        /*" R330-UPD-MOVTO-DEBITOCC-CEF */
        private void R330_UPD_MOVTO_DEBITOCC_CEF(bool isPerform = false)
        {
            /*" -1187- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1188- MOVE '1' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("1", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -1190- MOVE PARAMCON-NSAS TO MOVDEBCE-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -1200- PERFORM R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1 */

            R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1();

            /*" -1203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1204- DISPLAY 'ERRO UPDATE MOVTO_DEBITOCC_CEF .............' */
                _.Display($"ERRO UPDATE MOVTO_DEBITOCC_CEF .............");

                /*" -1205- DISPLAY 'SINISTRO ............. ' MOVDEBCE-NUM-APOLICE */
                _.Display($"SINISTRO ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1206- DISPLAY 'PRODUTO / OPERACAO ... ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"PRODUTO / OPERACAO ... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1207- DISPLAY 'OCORHIST ............. ' MOVDEBCE-NUM-PARCELA */
                _.Display($"OCORHIST ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1208- DISPLAY 'CONVENIO ............. ' MOVDEBCE-COD-CONVENIO */
                _.Display($"CONVENIO ............. {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -1209- DISPLAY 'NSAS ................. ' PARAMCON-NSAS */
                _.Display($"NSAS ................. {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS}");

                /*" -1211- DISPLAY 'SIT. COBRANCA ........ ' MOVDEBCE-SITUACAO-COBRANCA */
                _.Display($"SIT. COBRANCA ........ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

                /*" -1211- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R330-UPD-MOVTO-DEBITOCC-CEF-DB-UPDATE-1 */
        public void R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1()
        {
            /*" -1200- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA, DATA_ENVIO = :SISTEMAS-DATA-MOV-ABERTO, NSAS = :MOVDEBCE-NSAS, COD_USUARIO = 'SI5001B' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND SITUACAO_COBRANCA = '0' END-EXEC. */

            var r330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1 = new R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1.Execute(r330_UPD_MOVTO_DEBITOCC_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R330_EXIT*/

        [StopWatch]
        /*" R340-IMPRIME-RELATORIO */
        private void R340_IMPRIME_RELATORIO(bool isPerform = false)
        {
            /*" -1218- MOVE MOVDEBCE-NUM-APOLICE TO LD01-NUM-APOL-SINISTRO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_NUM_APOL_SINISTRO);

            /*" -1219- MOVE MOVDEBCE-NUM-PARCELA TO LD01-OCORR-HISTORICO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, AREA_DE_WORK.LD01.LD01_OCORR_HISTORICO);

            /*" -1220- MOVE W-PRODUTO-OPERACAO-OPERACAO TO LD01-COD-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO, AREA_DE_WORK.LD01.LD01_COD_OPERACAO);

            /*" -1222- MOVE W-PRODUTO-OPERACAO-PRODUTO TO LD01-COD-PRODUTO . */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_PRODUTO, AREA_DE_WORK.LD01.LD01_COD_PRODUTO);

            /*" -1223- IF MOVDEBCE-VALOR-DEBITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO != 00)
            {

                /*" -1224- MOVE 'DEBITO' TO LD01-DEB-CRE */
                _.Move("DEBITO", AREA_DE_WORK.LD01.LD01_DEB_CRE);

                /*" -1226- MOVE MOVDEBCE-VALOR-DEBITO TO LD01-VALOR. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, AREA_DE_WORK.LD01.LD01_VALOR);
            }


            /*" -1227- IF MOVDEBCE-VLR-CREDITO NOT EQUAL ZERO */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO != 00)
            {

                /*" -1228- MOVE 'CREDITO' TO LD01-DEB-CRE */
                _.Move("CREDITO", AREA_DE_WORK.LD01.LD01_DEB_CRE);

                /*" -1230- MOVE MOVDEBCE-VLR-CREDITO TO LD01-VALOR. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, AREA_DE_WORK.LD01.LD01_VALOR);
            }


            /*" -1231- MOVE '???????' TO LD01-TIPO-LANCAMENTO. */
            _.Move("???????", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);

            /*" -1232- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 1070 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 1070)
            {

                /*" -1234- MOVE 'ADIANT.' TO LD01-TIPO-LANCAMENTO. */
                _.Move("ADIANT.", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1235- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 1071 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 1071)
            {

                /*" -1237- MOVE 'IND PAR' TO LD01-TIPO-LANCAMENTO. */
                _.Move("IND PAR", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1238- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 1072 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 1072)
            {

                /*" -1240- MOVE 'IND FIN' TO LD01-TIPO-LANCAMENTO. */
                _.Move("IND FIN", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1241- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 1073 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 1073)
            {

                /*" -1243- MOVE 'IND TOT' TO LD01-TIPO-LANCAMENTO. */
                _.Move("IND TOT", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1244- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 1074 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 1074)
            {

                /*" -1246- MOVE 'IND COM' TO LD01-TIPO-LANCAMENTO. */
                _.Move("IND COM", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1247- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 1051 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 1051)
            {

                /*" -1249- MOVE 'ESTORNO' TO LD01-TIPO-LANCAMENTO. */
                _.Move("ESTORNO", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1250- IF W-PRODUTO-OPERACAO-OPERACAO EQUAL 4000 */

            if (AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO == 4000)
            {

                /*" -1252- MOVE 'RESSARC' TO LD01-TIPO-LANCAMENTO. */
                _.Move("RESSARC", AREA_DE_WORK.LD01.LD01_TIPO_LANCAMENTO);
            }


            /*" -1253- MOVE MOVDEBCE-COD-AGENCIA-DEB TO LD01-COD-AGENCIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, AREA_DE_WORK.LD01.LD01_COD_AGENCIA);

            /*" -1254- MOVE MOVDEBCE-OPER-CONTA-DEB TO LD01-OPER-CONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, AREA_DE_WORK.LD01.LD01_OPER_CONTA);

            /*" -1255- MOVE MOVDEBCE-NUM-CONTA-DEB TO LD01-NUM-CONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, AREA_DE_WORK.LD01.LD01_NUM_CONTA);

            /*" -1257- MOVE MOVDEBCE-DIG-CONTA-DEB TO LD01-DV-CONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, AREA_DE_WORK.LD01.LD01_DV_CONTA);

            /*" -1259- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1267- PERFORM R340_IMPRIME_RELATORIO_DB_SELECT_1 */

            R340_IMPRIME_RELATORIO_DB_SELECT_1();

            /*" -1270- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1271- DISPLAY 'ERRO SELECT SINI_LOTERICO01 .............' */
                _.Display($"ERRO SELECT SINI_LOTERICO01 .............");

                /*" -1272- DISPLAY 'SINISTRO ....... ' MOVDEBCE-NUM-APOLICE */
                _.Display($"SINISTRO ....... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1274- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1275- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-LOTERICO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LD01.LD01_NOME_LOTERICO);

            /*" -1277- MOVE SINILT01-COD-LOT-CEF TO LD01-COD-LOT-CEF. */
            _.Move(SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF, AREA_DE_WORK.LD01.LD01_COD_LOT_CEF);

            /*" -1278- IF W-CONTA-LINHA GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA > 60)
            {

                /*" -1280- PERFORM R900-IMPRIME-CABEC-CONVENIO THRU R900-EXIT. */

                R900_IMPRIME_CABEC_CONVENIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R900_EXIT*/

            }


            /*" -1281- WRITE REG-SI5001B FROM LD01 AFTER 1. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1281- ADD 1 TO W-CONTA-LINHA. */
            AREA_DE_WORK.W_CONTA_LINHA.Value = AREA_DE_WORK.W_CONTA_LINHA + 1;

        }

        [StopWatch]
        /*" R340-IMPRIME-RELATORIO-DB-SELECT-1 */
        public void R340_IMPRIME_RELATORIO_DB_SELECT_1()
        {
            /*" -1267- EXEC SQL SELECT C.NOME_RAZAO, A.COD_LOT_CEF INTO :CLIENTES-NOME-RAZAO, :SINILT01-COD-LOT-CEF FROM SEGUROS.CLIENTES C, SEGUROS.SINI_LOTERICO01 A WHERE A.NUM_APOL_SINISTRO = :MOVDEBCE-NUM-APOLICE AND C.COD_CLIENTE = A.COD_CLIENTE END-EXEC. */

            var r340_IMPRIME_RELATORIO_DB_SELECT_1_Query1 = new R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R340_IMPRIME_RELATORIO_DB_SELECT_1_Query1.Execute(r340_IMPRIME_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.SINILT01_COD_LOT_CEF, SINILT01.DCLSINI_LOTERICO01.SINILT01_COD_LOT_CEF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R340_EXIT*/

        [StopWatch]
        /*" R600-UPDATE-PARAM-CONTA-CEF */
        private void R600_UPDATE_PARAM_CONTA_CEF(bool isPerform = false)
        {
            /*" -1289- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WNR_EXEC_SQL);

            /*" -1305- PERFORM R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1 */

            R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1();

            /*" -1314- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1315- DISPLAY 'ERRO UPDATE PARAM_CONTACEF .................' */
                _.Display($"ERRO UPDATE PARAM_CONTACEF .................");

                /*" -1316- DISPLAY 'TIPO MOVIMENTO ...... ' PARAMCON-TIPO-MOVTO-CC */
                _.Display($"TIPO MOVIMENTO ...... {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC}");

                /*" -1317- DISPLAY 'PRODUTO ............. ' PARAMCON-COD-PRODUTO */
                _.Display($"PRODUTO ............. {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO}");

                /*" -1318- DISPLAY 'CONVENIO ............ ' PARAMCON-COD-CONVENIO */
                _.Display($"CONVENIO ............ {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO}");

                /*" -1319- DISPLAY 'NSAS ................ ' PARAMCON-NSAS */
                _.Display($"NSAS ................ {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS}");

                /*" -1319- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R600-UPDATE-PARAM-CONTA-CEF-DB-UPDATE-1 */
        public void R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1()
        {
            /*" -1305- EXEC SQL UPDATE SEGUROS.PARAM_CONTACEF SET NSAS = :PARAMCON-NSAS, DATA_MOVIMENTO = CURRENT DATE, DATA_PROXIMO_DEB = CURRENT DATE, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CONVENIO = :PARAMCON-COD-CONVENIO END-EXEC. */

            var r600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1 = new R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1()
            {
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
            };

            R600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1.Execute(r600_UPDATE_PARAM_CONTA_CEF_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R600_EXIT*/

        [StopWatch]
        /*" R900-IMPRIME-CABEC-CONVENIO */
        private void R900_IMPRIME_CABEC_CONVENIO(bool isPerform = false)
        {
            /*" -1326- IF W-CONTA-LINHA GREATER 60 */

            if (AREA_DE_WORK.W_CONTA_LINHA > 60)
            {

                /*" -1328- ADD 1 TO W-CONTA-PAGINA. */
                AREA_DE_WORK.W_CONTA_PAGINA.Value = AREA_DE_WORK.W_CONTA_PAGINA + 1;
            }


            /*" -1329- MOVE PARAMCON-COD-CONVENIO TO LC04-COD-CONVENIO. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, AREA_DE_WORK.LC04_B.LC04_COD_CONVENIO);

            /*" -1331- MOVE PARAMCON-DESCR-CONVENIO TO LC04-NOME-CONVENIO. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DESCR_CONVENIO, AREA_DE_WORK.LC04_B.LC04_NOME_CONVENIO);

            /*" -1332- MOVE W-CONTA-PAGINA TO LC01-PAGINA. */
            _.Move(AREA_DE_WORK.W_CONTA_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -1333- MOVE 7 TO W-CONTA-LINHA. */
            _.Move(7, AREA_DE_WORK.W_CONTA_LINHA);

            /*" -1334- WRITE REG-SI5001B FROM LC01 AFTER PAGE. */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1335- WRITE REG-SI5001B FROM LC02 AFTER 1. */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1336- WRITE REG-SI5001B FROM LC02-A AFTER 1. */
            _.Move(AREA_DE_WORK.LC02_A.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1337- WRITE REG-SI5001B FROM LC03 AFTER 1. */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1338- WRITE REG-SI5001B FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1339- WRITE REG-SI5001B FROM LC04-B AFTER 1. */
            _.Move(AREA_DE_WORK.LC04_B.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1340- WRITE REG-SI5001B FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1341- WRITE REG-SI5001B FROM LC05 AFTER 1. */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

            /*" -1341- WRITE REG-SI5001B FROM LC04 AFTER 1. */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_SI5001B);

            RSI5001B.Write(REG_SI5001B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R900_EXIT*/

        [StopWatch]
        /*" R15000-GERA-SAP */
        private void R15000_GERA_SAP(bool isPerform = false)
        {
            /*" -1368- PERFORM R15000_GERA_SAP_DB_SELECT_1 */

            R15000_GERA_SAP_DB_SELECT_1();

            /*" -1378- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1379- DISPLAY 'R15000- ERRO LEITURA PARA CALL SISAP01B' */
                _.Display($"R15000- ERRO LEITURA PARA CALL SISAP01B");

                /*" -1380- DISPLAY ' SQLCODE ........... ' SQLCODE */
                _.Display($" SQLCODE ........... {DB.SQLCODE}");

                /*" -1381- DISPLAY ' NUM_APOLICE ....... ' MOVDEBCE-NUM-APOLICE */
                _.Display($" NUM_APOLICE ....... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1382- DISPLAY ' NUM_ENDOSSO ....... ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($" NUM_ENDOSSO ....... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -1383- DISPLAY ' NUM_PARCELA ....... ' MOVDEBCE-NUM-PARCELA */
                _.Display($" NUM_PARCELA ....... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -1384- DISPLAY ' SITUACAO_COBRANCA . ' MOVDEBCE-SITUACAO-COBRANCA */
                _.Display($" SITUACAO_COBRANCA . {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

                /*" -1385- DISPLAY ' COD_CONVENIO ...... ' MOVDEBCE-COD-CONVENIO */
                _.Display($" COD_CONVENIO ...... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -1386- DISPLAY ' DATA_VENCIMENTO ... ' MOVDEBCE-DATA-VENCIMENTO */
                _.Display($" DATA_VENCIMENTO ... {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}");

                /*" -1396- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1398- INITIALIZE REGISTRO-LINKAGE-SAP. */
            _.Initialize(
                REGISTRO_LINKAGE_SAP
            );

            /*" -1399- MOVE MOVDEBCE-NUM-APOLICE TO LK-SAP-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE);

            /*" -1400- MOVE MOVDEBCE-NUM-ENDOSSO TO LK-SAP-NUM-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO);

            /*" -1401- MOVE MOVDEBCE-NUM-PARCELA TO LK-SAP-NUM-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA);

            /*" -1402- MOVE MOVDEBCE-COD-CONVENIO TO LK-SAP-COD-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO);

            /*" -1403- MOVE MOVDEBCE-NSAS TO LK-SAP-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REGISTRO_LINKAGE_SAP.LK_SAP_NSAS);

            /*" -1404- MOVE MOVDEBCE-SITUACAO-COBRANCA TO LK-SAP-SITUACAO-COBRANCA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA, REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA);

            /*" -1405- MOVE 104 TO LK-SAP-COD-BANCO. */
            _.Move(104, REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO);

            /*" -1406- MOVE MOVDEBCE-COD-AGENCIA-DEB TO LK-SAP-COD-AGENCIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, REGISTRO_LINKAGE_SAP.LK_SAP_COD_AGENCIA);

            /*" -1407- MOVE ' ' TO LK-SAP-DV-AGENCIA. */
            _.Move(" ", REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA);

            /*" -1408- MOVE W-OPER-CONTA TO LK-SAP-OPERACAO-CONTA. */
            _.Move(AREA_DE_WORK.FILLER_2.W_OPER_CONTA, REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA);

            /*" -1409- MOVE W-NUMERO-CONTA TO LK-SAP-NUM-CONTA. */
            _.Move(AREA_DE_WORK.FILLER_2.W_NUMERO_CONTA, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CONTA);

            /*" -1410- MOVE W-DV-CONTA TO LK-SAP-DV-CONTA. */
            _.Move(AREA_DE_WORK.FILLER_2.W_DV_CONTA, REGISTRO_LINKAGE_SAP.LK_SAP_DV_CONTA);

            /*" -1411- MOVE 'SI5001B' TO LK-SAP-COD-PROGRAMA. */
            _.Move("SI5001B", REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA);

            /*" -1412- MOVE '?? LOTERICO ??' TO LK-SAP-NOME-FAVORECIDO. */
            _.Move("?? LOTERICO ??", REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO.LK_SAP_NOME_FAVORECIDO);

            /*" -1413- MOVE '000' TO LK-SAP-NUM-DOC-EMPRESA. */
            _.Move("000", REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO.LK_SAP_NUM_DOC_EMPRESA);

            /*" -1414- MOVE ALL '?X' TO LK-SAP-DES-LOGRADOURO . */
            _.MoveAll("?X", REGISTRO_LINKAGE_SAP.LK_SAP_DES_LOGRADOURO);

            /*" -1415- MOVE 00 TO LK-SAP-NUM-LOCAL . */
            _.Move(00, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_LOCAL);

            /*" -1416- MOVE ALL '?X' TO LK-SAP-DES-COMPLEMENTO. */
            _.MoveAll("?X", REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPLEMENTO);

            /*" -1417- MOVE ALL '?X' TO LK-SAP-DES-BAIRRO . */
            _.MoveAll("?X", REGISTRO_LINKAGE_SAP.LK_SAP_DES_BAIRRO);

            /*" -1418- MOVE ALL '?X' TO LK-SAP-DES-CIDADE . */
            _.MoveAll("?X", REGISTRO_LINKAGE_SAP.LK_SAP_DES_CIDADE);

            /*" -1419- MOVE 99999 TO LK-SAP-NUM-CEP . */
            _.Move(99999, REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CEP);

            /*" -1420- MOVE '?X?' TO LK-SAP-DES-COMPL-CEP . */
            _.Move("?X?", REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP);

            /*" -1422- MOVE '?X' TO LK-SAP-DES-SIGLA-UF . */
            _.Move("?X", REGISTRO_LINKAGE_SAP.LK_SAP_DES_SIGLA_UF);

            /*" -1424- MOVE SPACES TO LK-SAP-CHR-USO-EMPRESA. */
            _.Move("", REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA);

            /*" -1426- MOVE 'IDENTIFICACAO CLIENTE X(25):' TO WS-USO-EMPRESA-SICOV-TXT1. */
            _.Move("IDENTIFICACAO CLIENTE X(25):", REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA.WS_USO_EMPRESA_SICOV_TXT1);

            /*" -1428- MOVE W-IDENT-CLIENTE-EMPRESA TO WS-USO-EMPRESA-SICOV-25. */
            _.Move(AREA_DE_WORK.W_IDENT_CLIENTE_EMPRESA, REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA.WS_USO_EMPRESA_SICOV_25);

            /*" -1430- MOVE 'USO DA EMPRESA X(60):' TO WS-USO-EMPRESA-SICOV-TXT2. */
            _.Move("USO DA EMPRESA X(60):", REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA.WS_USO_EMPRESA_SICOV_TXT2);

            /*" -1437- MOVE W-USO-EMPRESA TO WS-USO-EMPRESA-SICOV-60. */
            _.Move(AREA_DE_WORK.W_USO_EMPRESA, REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA.WS_USO_EMPRESA_SICOV_60);

            /*" -1438- MOVE SPACES TO LK-SAP-COD-RETORNO. */
            _.Move("", REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO);

            /*" -1442- MOVE SPACES TO LK-SAP-MENSAGEM-RETORNO. */
            _.Move("", REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO);

            /*" -1443- PERFORM R9000-00-CARGA-SICPW001 THRU R9000-99-EXIT. */

            R9000_00_CARGA_SICPW001(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_EXIT*/


            /*" -1445- IF WS-SI239-SQL100 = 'NAO' AND MOVDEBCE-VLR-CREDITO > 0 */

            if (WS_SI239_SQL100 == "NAO" && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO > 0)
            {

                /*" -1446- GO TO R15000-GERA-MCP */

                R15000_GERA_MCP(); //GOTO
                return;

                /*" -1448- END-IF. */
            }


            /*" -1449- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -1450- DISPLAY '--- CADMUS - 103.659  -  NSGD   ---' */
            _.Display($"--- CADMUS - 103.659  -  NSGD   ---");

            /*" -1451- DISPLAY '--- EVIDENCIA CALL SUBROTINA    ---' */
            _.Display($"--- EVIDENCIA CALL SUBROTINA    ---");

            /*" -1452- DISPLAY '--- CALL NA SUBROTINA SISAP01B  ---' */
            _.Display($"--- CALL NA SUBROTINA SISAP01B  ---");

            /*" -1453- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -1455- DISPLAY '--- CHAMANDO ... ' */
            _.Display($"--- CHAMANDO ... ");

            /*" -1457- CALL 'SISAP01B' USING REGISTRO-LINKAGE-SAP. */
            _.Call("SISAP01B", REGISTRO_LINKAGE_SAP);

            /*" -1458- DISPLAY '--- RETORNO .... ' */
            _.Display($"--- RETORNO .... ");

            /*" -1466- DISPLAY '----------------------------------' */
            _.Display($"----------------------------------");

            /*" -1467- IF LK-SAP-COD-RETORNO NOT EQUAL 0 */

            if (REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO != 0)
            {

                /*" -1468- DISPLAY '*' */
                _.Display($"*");

                /*" -1469- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -1470- DISPLAY '*' */
                _.Display($"*");

                /*" -1471- DISPLAY '* ERRO NA EXECUCAO DA SUB-ROTINA SISAP01B' */
                _.Display($"* ERRO NA EXECUCAO DA SUB-ROTINA SISAP01B");

                /*" -1472- DISPLAY '*' */
                _.Display($"*");

                /*" -1473- DISPLAY '*            PROBLEMA GRAVE. ' */
                _.Display($"*            PROBLEMA GRAVE. ");

                /*" -1474- DISPLAY '*' */
                _.Display($"*");

                /*" -1475- DISPLAY '* PROGRAMA DE GERACAO DOS PAGAMENTOS DE' */
                _.Display($"* PROGRAMA DE GERACAO DOS PAGAMENTOS DE");

                /*" -1476- DISPLAY '* CONVENIO 921286 - CONVENIO BANCO DO BRASIL' */
                _.Display($"* CONVENIO 921286 - CONVENIO BANCO DO BRASIL");

                /*" -1477- DISPLAY '*' */
                _.Display($"*");

                /*" -1478- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -1479- DISPLAY ' ' */
                _.Display($" ");

                /*" -1480- DISPLAY 'CODIGO DE RETORNO = ' LK-SAP-COD-RETORNO */
                _.Display($"CODIGO DE RETORNO = {REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO}");

                /*" -1482- DISPLAY 'MENSAGEM RETORNADA = ' LK-SAP-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM RETORNADA = {REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO}");

                /*" -1484- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1484- GO TO R15000-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R15000_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R15000-GERA-SAP-DB-SELECT-1 */
        public void R15000_GERA_SAP_DB_SELECT_1()
        {
            /*" -1368- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_CONVENIO, NSAS, SITUACAO_COBRANCA INTO :MOVDEBCE-NUM-APOLICE, :MOVDEBCE-NUM-ENDOSSO, :MOVDEBCE-NUM-PARCELA, :MOVDEBCE-COD-CONVENIO, :MOVDEBCE-NSAS, :MOVDEBCE-SITUACAO-COBRANCA FROM SEGUROS.MOVTO_DEBITOCC_CEF C WHERE C.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND C.NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND C.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND C.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND C.SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND C.NSAS = :MOVDEBCE-NSAS END-EXEC. */

            var r15000_GERA_SAP_DB_SELECT_1_Query1 = new R15000_GERA_SAP_DB_SELECT_1_Query1()
            {
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = R15000_GERA_SAP_DB_SELECT_1_Query1.Execute(r15000_GERA_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
            }


        }

        [StopWatch]
        /*" R15000-GERA-MCP */
        private void R15000_GERA_MCP(bool isPerform = false)
        {
            /*" -1490- PERFORM R9100-00-CHAMA-SICP001S THRU R9100-99-EXIT. */

            R9100_00_CHAMA_SICP001S(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R15000_EXIT*/

        [StopWatch]
        /*" R9000-00-CARGA-SICPW001 */
        private void R9000_00_CARGA_SICPW001(bool isPerform = false)
        {
            /*" -1500- INITIALIZE SSICPW001. */
            _.Initialize(
                SICPW001.SSICPW001
            );

            /*" -1501- MOVE MOVDEBCE-NUM-ENDOSSO TO W-PRODUTO-OPERACAO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, AREA_DE_WORK.W_PRODUTO_OPERACAO);

            /*" -1503- MOVE W-PRODUTO-OPERACAO-OPERACAO TO SI239-COD-OPERACAO. */
            _.Move(AREA_DE_WORK.FILLER_4.W_PRODUTO_OPERACAO_OPERACAO, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO);

            /*" -1505- PERFORM P7239-SI2-SELECT THRU P7239-SI2-EXIT. */

            P7239_SI2_SELECT(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P7239_SI2_EXIT*/


            /*" -1506- MOVE LK-SAP-NUM-APOLICE TO LK-SICPW001-NUM-APOLICE */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_APOLICE, SICPW001.SSICPW001.LK_SICPW001_NUM_APOLICE);

            /*" -1507- MOVE LK-SAP-NUM-ENDOSSO TO LK-SICPW001-NUM-ENDOSSO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_ENDOSSO, SICPW001.SSICPW001.LK_SICPW001_NUM_ENDOSSO);

            /*" -1508- MOVE LK-SAP-NUM-PARCELA TO LK-SICPW001-NUM-PARCELA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_PARCELA, SICPW001.SSICPW001.LK_SICPW001_NUM_PARCELA);

            /*" -1509- MOVE LK-SAP-COD-CONVENIO TO LK-SICPW001-COD-CONVENIO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_CONVENIO, SICPW001.SSICPW001.LK_SICPW001_COD_CONVENIO);

            /*" -1510- MOVE LK-SAP-NSAS TO LK-SICPW001-NSAS */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NSAS, SICPW001.SSICPW001.LK_SICPW001_NSAS);

            /*" -1512- MOVE LK-SAP-SITUACAO-COBRANCA TO LK-SICPW001-SITUACAO-COBRANCA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_SITUACAO_COBRANCA, SICPW001.SSICPW001.LK_SICPW001_SITUACAO_COBRANCA);

            /*" -1513- MOVE LK-SAP-COD-BANCO TO LK-SICPW001-COD-BANCO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_BANCO, SICPW001.SSICPW001.LK_SICPW001_COD_BANCO);

            /*" -1514- MOVE LK-SAP-COD-AGENCIA TO LK-SICPW001-COD-AGENCIA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_AGENCIA, SICPW001.SSICPW001.LK_SICPW001_COD_AGENCIA);

            /*" -1515- MOVE LK-SAP-DV-AGENCIA TO LK-SICPW001-DV-AGENCIA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DV_AGENCIA, SICPW001.SSICPW001.LK_SICPW001_DV_AGENCIA);

            /*" -1517- MOVE LK-SAP-OPERACAO-CONTA TO LK-SICPW001-OPERACAO-CONTA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_OPERACAO_CONTA, SICPW001.SSICPW001.LK_SICPW001_OPERACAO_CONTA);

            /*" -1518- MOVE LK-SAP-NUM-CONTA TO LK-SICPW001-NUM-CONTA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CONTA, SICPW001.SSICPW001.LK_SICPW001_NUM_CONTA);

            /*" -1519- MOVE LK-SAP-DV-CONTA TO LK-SICPW001-DV-CONTA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DV_CONTA, SICPW001.SSICPW001.LK_SICPW001_DV_CONTA);

            /*" -1520- MOVE LK-SAP-COD-PROGRAMA TO LK-SICPW001-COD-PROGRAMA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_PROGRAMA, SICPW001.SSICPW001.LK_SICPW001_COD_PROGRAMA);

            /*" -1521- MOVE LK-SAP-FAVORECIDO TO LK-SICPW001-FAVORECIDO. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_FAVORECIDO, SICPW001.SSICPW001.LK_SICPW001_FAVORECIDO);

            /*" -1523- MOVE LK-SAP-DES-LOGRADOURO TO LK-SICPW001-DES-LOGRADOURO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_LOGRADOURO, SICPW001.SSICPW001.LK_SICPW001_DES_LOGRADOURO);

            /*" -1524- MOVE LK-SAP-NUM-LOCAL TO LK-SICPW001-NUM-LOCAL */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_LOCAL, SICPW001.SSICPW001.LK_SICPW001_NUM_LOCAL);

            /*" -1526- MOVE LK-SAP-DES-COMPLEMENTO TO LK-SICPW001-DES-COMPLEMENTO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPLEMENTO, SICPW001.SSICPW001.LK_SICPW001_DES_COMPLEMENTO);

            /*" -1527- MOVE LK-SAP-DES-BAIRRO TO LK-SICPW001-DES-BAIRRO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_BAIRRO, SICPW001.SSICPW001.LK_SICPW001_DES_BAIRRO);

            /*" -1528- MOVE LK-SAP-DES-CIDADE TO LK-SICPW001-DES-CIDADE */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_CIDADE, SICPW001.SSICPW001.LK_SICPW001_DES_CIDADE);

            /*" -1529- MOVE LK-SAP-NUM-CEP TO LK-SICPW001-NUM-CEP */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_NUM_CEP, SICPW001.SSICPW001.LK_SICPW001_NUM_CEP);

            /*" -1530- MOVE LK-SAP-DES-COMPL-CEP TO LK-SICPW001-DES-COMPL-CEP */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_COMPL_CEP, SICPW001.SSICPW001.LK_SICPW001_DES_COMPL_CEP);

            /*" -1531- MOVE LK-SAP-DES-SIGLA-UF TO LK-SICPW001-DES-SIGLA-UF */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_DES_SIGLA_UF, SICPW001.SSICPW001.LK_SICPW001_DES_SIGLA_UF);

            /*" -1533- MOVE LK-SAP-CHR-USO-EMPRESA TO LK-SICPW001-CHR-USO-EMPRESA */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_CHR_USO_EMPRESA, SICPW001.SSICPW001.LK_SICPW001_CHR_USO_EMPRESA);

            /*" -1535- MOVE LK-SAP-COD-DOCUMENTO-SIACC TO LK-SICPW001-COD-DOC-SIACC */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_DOCUMENTO_SIACC, SICPW001.SSICPW001.LK_SICPW001_COD_DOC_SIACC);

            /*" -1537- MOVE LK-SAP-USO-EMPRESA-SIACC TO LK-SICPW001-USO-SIACC. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_USO_EMPRESA_SIACC, SICPW001.SSICPW001.LK_SICPW001_USO_SIACC);

            /*" -1538- MOVE LK-SAP-COD-RETORNO TO LK-SICPW001-COD-RETORNO */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_COD_RETORNO, SICPW001.SSICPW001.LK_SICPW001_COD_RETORNO);

            /*" -1539- MOVE LK-SAP-MENSAGEM-RETORNO TO LK-SICPW001-MENSAGEM-RETORNO. */
            _.Move(REGISTRO_LINKAGE_SAP.LK_SAP_MENSAGEM_RETORNO, SICPW001.SSICPW001.LK_SICPW001_MENSAGEM_RETORNO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_EXIT*/

        [StopWatch]
        /*" R9100-00-CHAMA-SICP001S */
        private void R9100_00_CHAMA_SICP001S(bool isPerform = false)
        {
            /*" -1552- MOVE 'SICP001S' TO WS-PROGRAMA. */
            _.Move("SICP001S", WS_PROGRAMA);

            /*" -1554- CALL WS-PROGRAMA USING SSICPW001. */
            _.Call(WS_PROGRAMA, SICPW001.SSICPW001);

            /*" -1555- IF LK-SICPW001-COD-RETORNO NOT EQUAL 0 */

            if (SICPW001.SSICPW001.LK_SICPW001_COD_RETORNO != 0)
            {

                /*" -1556- DISPLAY '*' */
                _.Display($"*");

                /*" -1557- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -1558- DISPLAY '*' */
                _.Display($"*");

                /*" -1559- DISPLAY '* ERRO NA EXECUCAO DA SUB-ROTINA SICP001S' */
                _.Display($"* ERRO NA EXECUCAO DA SUB-ROTINA SICP001S");

                /*" -1560- DISPLAY '*' */
                _.Display($"*");

                /*" -1561- DISPLAY '*            PROBLEMA GRAVE. ' */
                _.Display($"*            PROBLEMA GRAVE. ");

                /*" -1562- DISPLAY '*' */
                _.Display($"*");

                /*" -1563- DISPLAY '********************************************' */
                _.Display($"********************************************");

                /*" -1564- DISPLAY ' ' */
                _.Display($" ");

                /*" -1565- DISPLAY 'CODIGO DE RETORNO = ' LK-SICPW001-COD-RETORNO */
                _.Display($"CODIGO DE RETORNO = {SICPW001.SSICPW001.LK_SICPW001_COD_RETORNO}");

                /*" -1567- DISPLAY 'MENSAGEM RETORNADA = ' LK-SICPW001-MENSAGEM-RETORNO */
                _.Display($"MENSAGEM RETORNADA = {SICPW001.SSICPW001.LK_SICPW001_MENSAGEM_RETORNO}");

                /*" -1567- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_EXIT*/

        [StopWatch]
        /*" P7239-SI2-SELECT */
        private void P7239_SI2_SELECT(bool isPerform = false)
        {
            /*" -1581- MOVE 'NAO' TO WS-SI239-SQL100. */
            _.Move("NAO", WS_SI239_SQL100);

            /*" -1594- PERFORM P7239_SI2_SELECT_DB_SELECT_1 */

            P7239_SI2_SELECT_DB_SELECT_1();

            /*" -1597- IF SQLCODE NOT = ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1598- DISPLAY 'P7239-SI2-SELECT' */
                _.Display($"P7239-SI2-SELECT");

                /*" -1600- DISPLAY 'ERRO NO ACESSO A TABELA: ' '"SEGUROS.SI_OPERACAO_EVENTO"' */
                _.Display($"ERRO NO ACESSO A TABELA: SEGUROS.SI_OPERACAO_EVENTO");

                /*" -1601- DISPLAY 'COD_OPERACAO: ' SI239-COD-OPERACAO */
                _.Display($"COD_OPERACAO: {SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO}");

                /*" -1602- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1604- END-IF. */
            }


            /*" -1605- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1606- MOVE 'SIM' TO WS-SI239-SQL100 */
                _.Move("SIM", WS_SI239_SQL100);

                /*" -1606- END-IF. */
            }


        }

        [StopWatch]
        /*" P7239-SI2-SELECT-DB-SELECT-1 */
        public void P7239_SI2_SELECT_DB_SELECT_1()
        {
            /*" -1594- EXEC SQL SELECT IDE_SISTEMA ,COD_OPERACAO ,COD_EVENTO_SAP INTO :SI239-IDE-SISTEMA ,:SI239-COD-OPERACAO ,:SI239-COD-EVENTO-SAP FROM SEGUROS.SI_OPERACAO_EVENTO WHERE COD_OPERACAO = :SI239-COD-OPERACAO AND (DTA_FIM_VIGENCIA = '9999-12-31' OR DTA_FIM_VIGENCIA IS NULL) WITH UR END-EXEC. */

            var p7239_SI2_SELECT_DB_SELECT_1_Query1 = new P7239_SI2_SELECT_DB_SELECT_1_Query1()
            {
                SI239_COD_OPERACAO = SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO.ToString(),
            };

            var executed_1 = P7239_SI2_SELECT_DB_SELECT_1_Query1.Execute(p7239_SI2_SELECT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI239_IDE_SISTEMA, SI239.DCLSI_OPERACAO_EVENTO.SI239_IDE_SISTEMA);
                _.Move(executed_1.SI239_COD_OPERACAO, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_OPERACAO);
                _.Move(executed_1.SI239_COD_EVENTO_SAP, SI239.DCLSI_OPERACAO_EVENTO.SI239_COD_EVENTO_SAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P7239_SI2_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1614- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -1615- DISPLAY ' ' */
            _.Display($" ");

            /*" -1616- DISPLAY ' ' */
            _.Display($" ");

            /*" -1617- DISPLAY ' ' */
            _.Display($" ");

            /*" -1618- DISPLAY '=====  PROGRAMA ABENDADO  =====' */
            _.Display($"=====  PROGRAMA ABENDADO  =====");

            /*" -1619- DISPLAY ' ' */
            _.Display($" ");

            /*" -1620- DISPLAY ' ' */
            _.Display($" ");

            /*" -1621- DISPLAY ' ' */
            _.Display($" ");

            /*" -1622- DISPLAY WABEND1. */
            _.Display(REGISTRO_LINKAGE_SAP.WABEND.WABEND1);

            /*" -1623- DISPLAY WABEND2. */
            _.Display(REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2);

            /*" -1624- DISPLAY WABEND3. */
            _.Display(REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WABEND3);

            /*" -1624- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1625- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1627- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1627- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R10010199-MENSAGEM-LOCK */
        private void R10010199_MENSAGEM_LOCK(bool isPerform = false)
        {
            /*" -1634- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE);

            /*" -1637- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1640- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1643- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' UPON CONSOLE. */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1646- DISPLAY '*      -------------       ----------------------         *' UPON CONSOLE. */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1649- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1652- DISPLAY '*                   PROGRAMA ABENDADO                     *' UPON CONSOLE. */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1655- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' UPON CONSOLE. */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1658- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' UPON CONSOLE. */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1661- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' UPON CONSOLE. */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1664- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1667- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' UPON CONSOLE. */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1670- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1673- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1676- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE UPON CONSOLE. */
            _.Display($"*     SQLCODE DO ABEND ....... {REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -1679- DISPLAY '*                                                         *' UPON CONSOLE. */
            _.Display($"*                                                         *");

            /*" -1685- DISPLAY '***********************************************************' UPON CONSOLE. */
            _.Display($"***********************************************************");

            /*" -1687- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1689- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1691- DISPLAY '*      A T E N C A O       S R.   O P E R A D O R         *' */
            _.Display($"*      A T E N C A O       S R.   O P E R A D O R         *");

            /*" -1693- DISPLAY '*      -------------       ----------------------         *' */
            _.Display($"*      -------------       ----------------------         *");

            /*" -1695- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1697- DISPLAY '*                   PROGRAMA ABENDADO                     *' */
            _.Display($"*                   PROGRAMA ABENDADO                     *");

            /*" -1699- DISPLAY '*                 PROVAVELMENTE POR LOCK                  *' */
            _.Display($"*                 PROVAVELMENTE POR LOCK                  *");

            /*" -1701- DISPLAY '*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *' */
            _.Display($"*        VERIFIQUE O LOG ANTES DE LIGAR PARA O ANALISTA   *");

            /*" -1703- DISPLAY '*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *' */
            _.Display($"*    CONFIRMANDO O LOCK, EXECUTAR NOVAMENTE O PROGRAMA    *");

            /*" -1705- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1707- DISPLAY '*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *' */
            _.Display($"*  PERMANECENDO O ERRO, CONTACTAR O ANALISTA RESPONSAVEL  *");

            /*" -1709- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1711- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1713- DISPLAY '*                                                         *' */
            _.Display($"*                                                         *");

            /*" -1715- DISPLAY '*     SQLCODE DO ABEND ....... ' WSQLCODE */
            _.Display($"*     SQLCODE DO ABEND ....... {REGISTRO_LINKAGE_SAP.WABEND.WABEND1.WABEND2.WABEND3.WSQLCODE}");

            /*" -1717- DISPLAY '***********************************************************' */
            _.Display($"***********************************************************");

            /*" -1717- GO TO R9999-00-ROT-ERRO. */

            R9999_00_ROT_ERRO(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R10010199_EXIT*/
    }
}