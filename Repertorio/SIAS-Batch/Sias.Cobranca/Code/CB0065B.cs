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
using Sias.Cobranca.DB2.CB0065B;

namespace Code
{
    public class CB0065B
    {
        public bool IsCall { get; set; }

        public CB0065B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0065B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  29/04/2003                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROCESSA FITA DE ENVIO SICOV       *      */
        /*"      *                             PARA DEBITO NA CONTA DO SEGURADO.  *      */
        /*"      *                             CONVENIO 6051   - CAIXA SEGURADORA *      */
        /*"      *                             CONVENIO 600139 - VERA CRUZ        *      */
        /*"      *                             A PARTIR DA LEITURA DA TABELA      *      */
        /*"      *                             MOVTO_DEBITOCC_CEF.                *      */
        /*"      *                                                                *      */
        /*"      *   SUBSTITUI O PGM CB0095B A PARTIR DE 06/05/2003.              *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM JUNHO/2003 - CARLOS ALBERTO - PROCURAR CA0603     *      */
        /*"      *                           ACESSO AO COD-PRODUTO DA TAB.ENDOSSOS*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-USUARIO MASTER- - HISTORICO - 29/11/2007-----------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO EM 16/12/2008 - CLOVIS         - PROCURAR V.01       *      */
        /*"      *                           QUANDO DATA DO VENCIMENTO FOR IGUAL  *      */
        /*"      *                           31/12 ALTERA PARA 02/01.             *      */
        /*"      *                           MOTIVO - PARA C.E.F. NAO EXISTE      *      */
        /*"      *                           ESTA DATA POR SER FERIADO BANCARIO.  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO EM 06/07/2011 - CLOVIS         - PROCURAR V.02       *      */
        /*"      *                           PROJETO AUTO SAS                     *      */
        /*"      *                           PREVISAO DO ORGAO 110 NO CONVENIO.   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 12/09/2012 - CLOVIS         - PROCURAR V.03       *      */
        /*"      *                           CADMUS 74083 / 74142                 *      */
        /*"      *                           A PARTIR DA DIARIA DE 10/09/2012 O   *      */
        /*"      *                           PROGRAMA ESTA COM DEMORA NA EXECUCAO *      */
        /*"      *                           SENDO CANCELADO PELA PRODUCAO.       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 24/06/2013 - COREON         - PROCURAR V.04       *      */
        /*"      *                           CADMUS 74582                         *      */
        /*"      *                           PROCESSAR O ORGAO EMISSOR 10 PARA O  *      */
        /*"      *                           CONVENIO 600139 (PRODUTOS AUTO FACIL)*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO EM 25/06/2013 - COREON         - PROCURAR V.05       *      */
        /*"      *                           CADMUS 74582                         *      */
        /*"      *                           SELECINAR MOVTOS DE ADES�O VIA DEBITO*      */
        /*"      *                           EM C/C NA CEF P/ OS PRODUTOS DO AUTO *      */
        /*"      *                           FACIL (VENDAS FORA DA REDE DE        *      */
        /*"      *                           AGENCIAS).                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.06  *   VERSAO 06 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/10/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.06         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.07  *   VERSAO 07 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   AJUSTE LAYOUT ARQUIVO MOVIMENTO (MOV605100 MOV600139         *      */
        /*"      *                                    MOV600140)                  *      */
        /*"      *   EM 20/07/2015 - COREON                                       *      */
        /*"      *                                       PROCURE POR V.07         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.08  * EM 06/02/2017 - ALTERADO POR LISIANE - CADMUS 143826           *      */
        /*"      *                 ALTERADO O PRAZO DE ENVIO PARA O BANCO DE      *      */
        /*"      *                 8 PARA 7 DIAS UTEIS                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * ALTERACAO EM 25/04/2018 - CLOVIS         - PROCURAR V.09       *      */
        /*"      *                           PROJETO AUTO SAS                     *      */
        /*"      * R0610-00 - PROBLEMAS NO UPDATE(MOVDEBCE)                       *      */
        /*"      * CB0065B   *** ERRO  EXEC SQL  NUMERO 0610                      *      */
        /*"      * SQLCODE =      803-   SQLERRD1 =      156-                     *      */
        /*"      *                                                                *      */
        /*"      * WHERE       NUM_APOLICE                =    1103101044525      *      */
        /*"      * AND         NUM_ENDOSSO                =    0                  *      */
        /*"      * AND         NUM_PARCELA                =    10                 *      */
        /*"      *                                                                *      */
        /*"      * MOTIVO DO ABEND : ALTERACAO INDEVIDA NOS PROGRAMAS             *      */
        /*"      *                   CB1261B E CB1262B.                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOV605100_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOV605100_CC
        {
            get
            {
                _.Move(REG_MOV605100, _MOV605100_CC); VarBasis.RedefinePassValue(REG_MOV605100, _MOV605100_CC, REG_MOV605100); return _MOV605100_CC;
            }
        }
        public FileBasis _MOV600139_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOV600139_CC
        {
            get
            {
                _.Move(REG_MOV600139, _MOV600139_CC); VarBasis.RedefinePassValue(REG_MOV600139, _MOV600139_CC, REG_MOV600139); return _MOV600139_CC;
            }
        }
        public FileBasis _MOV600140_CC { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOV600140_CC
        {
            get
            {
                _.Move(REG_MOV600140, _MOV600140_CC); VarBasis.RedefinePassValue(REG_MOV600140, _MOV600140_CC, REG_MOV600140); return _MOV600140_CC;
            }
        }
        public FileBasis _RCB0065B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RCB0065B
        {
            get
            {
                _.Move(REG_CB0065B, _RCB0065B); VarBasis.RedefinePassValue(REG_CB0065B, _RCB0065B, REG_CB0065B); return _RCB0065B;
            }
        }
        /*"01        REG-MOV605100               PIC  X(150).*/
        public StringBasis REG_MOV605100 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-MOV600139               PIC  X(150).*/
        public StringBasis REG_MOV600139 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-MOV600140               PIC  X(150).*/
        public StringBasis REG_MOV600140 { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01        REG-CB0065B                 PIC  X(132).*/
        public StringBasis REG_CB0065B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WSHOST-DATA-INIVIGENCIA        PIC X(10) VALUE SPACES.*/
        public StringBasis WSHOST_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WSHOST-DATA-TERVIGENCIA        PIC X(10) VALUE SPACES.*/
        public StringBasis WSHOST_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WSHOST-DATA-CURRENT            PIC X(10) VALUE SPACES.*/
        public StringBasis WSHOST_DATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WSHOST-DATA-UTEIS01            PIC X(10) VALUE SPACES.*/
        public StringBasis WSHOST_DATA_UTEIS01 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WSHOST-DATA-UTEIS05            PIC X(10) VALUE SPACES.*/
        public StringBasis WSHOST_DATA_UTEIS05 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WSHOST-DATA-UTEIS07            PIC X(10) VALUE SPACES.*/
        public StringBasis WSHOST_DATA_UTEIS07 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  W.*/
        public CB0065B_W W { get; set; } = new CB0065B_W();
        public class CB0065B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-V0MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_V0MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-V1MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_V1MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-V0MOVDEBCE             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_V0MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ANT-CONVENIO              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis ANT_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  WS-SUBS                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WS-QTD-DIAS               PIC  9(004)    VALUE   ZEROS.*/
            public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AC-TOTARQUIVO             PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_TOTARQUIVO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-TOTREGISTRO            PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis AC_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-VLRTOTDEB              PIC S9(013)V99 COMP-3.*/
            public DoubleBasis AC_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AC-VALOR                  PIC  ZZZ.ZZZ.ZZ9,99-.*/
            public DoubleBasis AC_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
            /*"  03  AC-PAGINA                 PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03  AC-LINHAS                 PIC  9(003)    VALUE 100.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 100);
            /*"  03  WPARM15-AUX               PIC S9(009) VALUE ZEROS COMP.*/
            public IntBasis WPARM15_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WQUOCIENTE                PIC S9(004) VALUE ZEROS COMP.*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WRESTO                    PIC S9(004) VALUE ZEROS COMP.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  WS-DIGCONTA               PIC  9(001)    VALUE   ZEROS.*/
            public IntBasis WS_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_CB0065B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB0065B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB0065B_FILLER_0(); _.Move(WTIME_DAY, _filler_0); VarBasis.RedefinePassValue(WTIME_DAY, _filler_0, WTIME_DAY); _filler_0.ValueChanged += () => { _.Move(_filler_0, WTIME_DAY); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_CB0065B_FILLER_0 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public CB0065B_WTIME_DAYR WTIME_DAYR { get; set; } = new CB0065B_WTIME_DAYR();
                public class CB0065B_WTIME_DAYR : VarBasis
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

                    public CB0065B_WTIME_DAYR()
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
                /*"  03         WS-TIME.*/

                public _REDEF_CB0065B_FILLER_0()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public CB0065B_WS_TIME WS_TIME { get; set; } = new CB0065B_WS_TIME();
            public class CB0065B_WS_TIME : VarBasis
            {
                /*"      10     WS-HH-TIME         PIC  9(002).*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-MM-TIME         PIC  9(002).*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-SS-TIME         PIC  9(002).*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CC-TIME         PIC  9(002).*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_CB0065B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_CB0065B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_CB0065B_FILLER_1(); _.Move(WDATA_REL, _filler_1); VarBasis.RedefinePassValue(WDATA_REL, _filler_1, WDATA_REL); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_REL); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0065B_FILLER_1 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_CB0065B_FILLER_1()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0065B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB0065B_WDATA_CABEC();
            public class CB0065B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WHORA-CURR.*/
            }
            public CB0065B_WHORA_CURR WHORA_CURR { get; set; } = new CB0065B_WHORA_CURR();
            public class CB0065B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WHORA-CABEC.*/
            }
            public CB0065B_WHORA_CABEC WHORA_CABEC { get; set; } = new CB0065B_WHORA_CABEC();
            public class CB0065B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03        WS-NUMERO           PIC  9(015)  VALUE   ZEROS.*/
            }
            public IntBasis WS_NUMERO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  03        FILLER              REDEFINES    WS-NUMERO.*/
            private _REDEF_CB0065B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_CB0065B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_CB0065B_FILLER_8(); _.Move(WS_NUMERO, _filler_8); VarBasis.RedefinePassValue(WS_NUMERO, _filler_8, WS_NUMERO); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_NUMERO); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_NUMERO); }
            }  //Redefines
            public class _REDEF_CB0065B_FILLER_8 : VarBasis
            {
                /*"    10      WS-AGENCIA          PIC  9(004).*/
                public IntBasis WS_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WS-OPERACAO         PIC  9(003).*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      WS-NUMCONTA         PIC  9(008).*/
                public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"  03        LPARM15X.*/

                public _REDEF_CB0065B_FILLER_8()
                {
                    WS_AGENCIA.ValueChanged += OnValueChanged;
                    WS_OPERACAO.ValueChanged += OnValueChanged;
                    WS_NUMCONTA.ValueChanged += OnValueChanged;
                }

            }
            public CB0065B_LPARM15X LPARM15X { get; set; } = new CB0065B_LPARM15X();
            public class CB0065B_LPARM15X : VarBasis
            {
                /*"    10      LPARM15             PIC  9(015).*/
                public IntBasis LPARM15 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10      FILLER              REDEFINES   LPARM15.*/
                private _REDEF_CB0065B_FILLER_9 _filler_9 { get; set; }
                public _REDEF_CB0065B_FILLER_9 FILLER_9
                {
                    get { _filler_9 = new _REDEF_CB0065B_FILLER_9(); _.Move(LPARM15, _filler_9); VarBasis.RedefinePassValue(LPARM15, _filler_9, LPARM15); _filler_9.ValueChanged += () => { _.Move(_filler_9, LPARM15); }; return _filler_9; }
                    set { VarBasis.RedefinePassValue(value, _filler_9, LPARM15); }
                }  //Redefines
                public class _REDEF_CB0065B_FILLER_9 : VarBasis
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

                    public _REDEF_CB0065B_FILLER_9()
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
                /*"01            AUX-RELATORIO.*/
            }
        }
        public CB0065B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new CB0065B_AUX_RELATORIO();
        public class CB0065B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC01.*/
            public CB0065B_LC01 LC01 { get; set; } = new CB0065B_LC01();
            public class CB0065B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(007)  VALUE             'CB0065B'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CB0065B");
                /*"    10        FILLER              PIC  X(033)  VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10        LC01-EMPRESA        PIC  X(040).*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    10        FILLER              PIC  X(032)  VALUE SPACES.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'PAGINA: '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PAGINA: ");
                /*"    10        FILLER              PIC  X(005)  VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10        LC01-PAGINA         PIC  ZZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"  03          LC02.*/
            }
            public CB0065B_LC02 LC02 { get; set; } = new CB0065B_LC02();
            public class CB0065B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(112)  VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA  : '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA  : ");
                /*"    10        LC02-DATA           PIC  X(010).*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03          LC03.*/
            }
            public CB0065B_LC03 LC03 { get; set; } = new CB0065B_LC03();
            public class CB0065B_LC03 : VarBasis
            {
                /*"    10        FILLER              PIC  X(035)  VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    10        FILLER              PIC  X(038)  VALUE             'CONTROLE DE DOCUMENTOS PROCESSADOS EM '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"CONTROLE DE DOCUMENTOS PROCESSADOS EM ");
                /*"    10        LC03-DTMOVTO        PIC  X(010).*/
                public StringBasis LC03_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(029)  VALUE SPACES.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "29", "X(029)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'HORA  : '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"HORA  : ");
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        LC03-HORA           PIC  X(008).*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"  03          LC04.*/
            }
            public CB0065B_LC04 LC04 { get; set; } = new CB0065B_LC04();
            public class CB0065B_LC04 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE             'CONVENIO: '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CONVENIO: ");
                /*"    10        LC04-CONVENIO       PIC  9(006).*/
                public IntBasis LC04_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        FILLER              PIC  X(015)  VALUE             'NSAS DE ENVIO: '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NSAS DE ENVIO: ");
                /*"    10        LC04-NSAS           PIC  ZZZZZ9.*/
                public IntBasis LC04_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "ZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        FILLER              PIC  X(015)  VALUE             'DATA DE ENVIO: '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA DE ENVIO: ");
                /*"    10        LC04-DTENVIO        PIC  X(010).*/
                public StringBasis LC04_DTENVIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        FILLER              PIC  X(020)  VALUE             'DATA DE VENCIMENTO: '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA DE VENCIMENTO: ");
                /*"    10        LC04-DTVENCTO1      PIC  X(010).*/
                public StringBasis LC04_DTVENCTO1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(003)  VALUE ' A '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" A ");
                /*"    10        LC04-DTVENCTO2      PIC  X(010).*/
                public StringBasis LC04_DTVENCTO2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(018)  VALUE SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"  03          LC05.*/
            }
            public CB0065B_LC05 LC05 { get; set; } = new CB0065B_LC05();
            public class CB0065B_LC05 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE ALL '-'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03          LC06.*/
            }
            public CB0065B_LC06 LC06 { get; set; } = new CB0065B_LC06();
            public class CB0065B_LC06 : VarBasis
            {
                /*"    10        FILLER              PIC  X(006)  VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10        FILLER              PIC  X(011)  VALUE             'APOLICE'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"APOLICE");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(016)  VALUE             'PARCELA'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"PARCELA");
                /*"    10        FILLER              PIC  X(015)  VALUE             'PROPOSTA'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"PROPOSTA");
                /*"    10        FILLER              PIC  X(031)  VALUE             'CONTA INFORMADA'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"CONTA INFORMADA");
                /*"    10        FILLER              PIC  X(008)  VALUE             'VALOR'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VALOR");
                /*"    10        FILLER              PIC  X(040)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"MENSAGEM");
                /*"  03          LC08.*/
            }
            public CB0065B_LC08 LC08 { get; set; } = new CB0065B_LC08();
            public class CB0065B_LC08 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03          LD01.*/
            }
            public CB0065B_LD01 LD01 { get; set; } = new CB0065B_LD01();
            public class CB0065B_LD01 : VarBasis
            {
                /*"    10        LD01-APOLICE        PIC  ZZZZZZZZZZZZ9.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        LD01-ENDOSSO        PIC  ZZZZZZZZ9.*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(005)  VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10        LD01-PARCELA        PIC  ZZZZ9.*/
                public IntBasis LD01_PARCELA { get; set; } = new IntBasis(new PIC("9", "5", "ZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        LD01-PROPOSTA       PIC  ZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        LD01-AGECONTA       PIC  9(004).*/
                public IntBasis LD01_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10        LD01-OPECONTA       PIC  9(004).*/
                public IntBasis LD01_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE '.'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10        LD01-NUMCONTA       PIC  9(012).*/
                public IntBasis LD01_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10        FILLER              PIC  X(001)  VALUE '-'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    10        LD01-DIGCONTA       PIC  9(001).*/
                public IntBasis LD01_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        LD01-VALOR          PIC  ZZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10        FILLER              PIC  X(002)  VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10        LD01-MENSAGEM       PIC  X(040).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  03        WABEND.*/
            }
            public CB0065B_WABEND WABEND { get; set; } = new CB0065B_WABEND();
            public class CB0065B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' CB0065B  '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CB0065B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public CB0065B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new CB0065B_HEADER_REGISTRO();
        public class CB0065B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTRO       PIC  X(001).*/
            public StringBasis HEADER_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODREMESSA        PIC  X(001).*/
            public StringBasis HEADER_CODREMESSA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODCONVENIO.*/
            public CB0065B_HEADER_CODCONVENIO HEADER_CODCONVENIO { get; set; } = new CB0065B_HEADER_CODCONVENIO();
            public class CB0065B_HEADER_CODCONVENIO : VarBasis
            {
                /*"    10    HEADER-CONVENIO          PIC  9(006).*/
                public IntBasis HEADER_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    FILLER                   PIC  X(014).*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                /*"  05      HEADER-NOMEMPRESA        PIC  X(020).*/
            }
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-CODBANCO          PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMBANCO          PIC  X(020).*/
            public StringBasis HEADER_NOMBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      HEADER-DATGERACAO.*/
            public CB0065B_HEADER_DATGERACAO HEADER_DATGERACAO { get; set; } = new CB0065B_HEADER_DATGERACAO();
            public class CB0065B_HEADER_DATGERACAO : VarBasis
            {
                /*"    10    HEADER-ANO               PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES               PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA               PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-NSAS              PIC  9(006).*/
            }
            public IntBasis HEADER_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-VERSAO            PIC  X(002).*/
            public StringBasis HEADER_VERSAO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-DEBCREDAUT        PIC  X(017).*/
            public StringBasis HEADER_DEBCREDAUT { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05      FILLER                   PIC  X(052).*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01        MOVCC-REGISTRO.*/
        }
        public CB0065B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new CB0065B_MOVCC_REGISTRO();
        public class CB0065B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-CODREGISTRO        PIC  X(001).*/
            public StringBasis MOVCC_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      MOVCC-IDTCLIEMP.*/
            public CB0065B_MOVCC_IDTCLIEMP MOVCC_IDTCLIEMP { get; set; } = new CB0065B_MOVCC_IDTCLIEMP();
            public class CB0065B_MOVCC_IDTCLIEMP : VarBasis
            {
                /*"    10    MOVCC-NUMAPOL            PIC  9(013).*/
                public IntBasis MOVCC_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"    10    MOVCC-NRENDOS            PIC  9(006).*/
                public IntBasis MOVCC_NRENDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-NRPARCEL           PIC  9(002).*/
                public IntBasis MOVCC_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                   PIC  X(004).*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"  05      MOVCC-IDTCLIBAN.*/
            }
            public CB0065B_MOVCC_IDTCLIBAN MOVCC_IDTCLIBAN { get; set; } = new CB0065B_MOVCC_IDTCLIBAN();
            public class CB0065B_MOVCC_IDTCLIBAN : VarBasis
            {
                /*"    10    MOVCC-AGECONTA           PIC  9(004).*/
                public IntBasis MOVCC_AGECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-OPECONTA           PIC  9(004).*/
                public IntBasis MOVCC_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-NUMCONTA           PIC  9(012).*/
                public IntBasis MOVCC_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10    MOVCC-DIGCONTA           PIC  9(001).*/
                public IntBasis MOVCC_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10    FILLER                   PIC  X(002).*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05      MOVCC-DTCREDITO.*/
            }
            public CB0065B_MOVCC_DTCREDITO MOVCC_DTCREDITO { get; set; } = new CB0065B_MOVCC_DTCREDITO();
            public class CB0065B_MOVCC_DTCREDITO : VarBasis
            {
                /*"    10    MOVCC-ANO                PIC  9(004).*/
                public IntBasis MOVCC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    MOVCC-MES                PIC  9(002).*/
                public IntBasis MOVCC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    MOVCC-DIA                PIC  9(002).*/
                public IntBasis MOVCC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      MOVCC-VLDEBCRE           PIC  9(013)V99.*/
            }
            public DoubleBasis MOVCC_VLDEBCRE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      MOVCC-CODMOEDA           PIC  X(002).*/
            public StringBasis MOVCC_CODMOEDA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      MOVCC-USOEMPRESA.*/
            public CB0065B_MOVCC_USOEMPRESA MOVCC_USOEMPRESA { get; set; } = new CB0065B_MOVCC_USOEMPRESA();
            public class CB0065B_MOVCC_USOEMPRESA : VarBasis
            {
                /*"    10    MOVCC-CONVENIO           PIC  9(006).*/
                public IntBasis MOVCC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-NSAS               PIC  9(006).*/
                public IntBasis MOVCC_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-NRSEQ              PIC  9(006).*/
                public IntBasis MOVCC_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10    MOVCC-CODPRODU           PIC  9(004).*/
                public IntBasis MOVCC_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                   PIC  X(038).*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)."), @"");
                /*"  05      FILLER                   PIC  X(015).*/
            }
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      MOVCC-CODMOV             PIC  X(001).*/
            public StringBasis MOVCC_CODMOV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"01        TRAILL-REGISTRO.*/
        }
        public CB0065B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new CB0065B_TRAILL_REGISTRO();
        public class CB0065B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTRO       PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-TOTREGISTRO       PIC  9(006).*/
            public IntBasis TRAILL_TOTREGISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILL-VLRTOTDEB         PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTDEB { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-VLRTOTCRE         PIC  9(015)V99.*/
            public DoubleBasis TRAILL_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      TRAILL-FILLER            PIC  X(109).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
            /*"01          LK-LINK.*/
        }
        public CB0065B_LK_LINK LK_LINK { get; set; } = new CB0065B_LK_LINK();
        public class CB0065B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public CB0065B_V0CALENDARIO V0CALENDARIO { get; set; } = new CB0065B_V0CALENDARIO();
        public CB0065B_V0MOVDEBCE V0MOVDEBCE { get; set; } = new CB0065B_V0MOVDEBCE();
        public CB0065B_V1MOVDEBCE V1MOVDEBCE { get; set; } = new CB0065B_V1MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV605100_CC_FILE_NAME_P, string MOV600139_CC_FILE_NAME_P, string MOV600140_CC_FILE_NAME_P, string RCB0065B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV605100_CC.SetFile(MOV605100_CC_FILE_NAME_P);
                MOV600139_CC.SetFile(MOV600139_CC_FILE_NAME_P);
                MOV600140_CC.SetFile(MOV600140_CC_FILE_NAME_P);
                RCB0065B.SetFile(RCB0065B_FILE_NAME_P);

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
            /*" -484- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -484- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -486- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -488- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -491- DISPLAY '---------------------------------------' */
            _.Display($"---------------------------------------");

            /*" -497- DISPLAY 'PROGRAMA EM EXECUCAO CB0065B      ' */
            _.Display($"PROGRAMA EM EXECUCAO CB0065B      ");

            /*" -499- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -501- MOVE 01 TO WS-SUBS. */
            _.Move(01, W.WS_SUBS);

            /*" -501- PERFORM R0300-00-PROCESSA-CONVENIO 03 TIMES. */

            for (int i = 0; i < 3; i++)
            {

                R0300_00_PROCESSA_CONVENIO_SECTION();

            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -505- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -513- CLOSE MOV605100-CC MOV600139-CC MOV600140-CC RCB0065B. */
            MOV605100_CC.Close();
            MOV600139_CC.Close();
            MOV600140_CC.Close();
            RCB0065B.Close();

            /*" -515- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -516- DISPLAY ' ' */
            _.Display($" ");

            /*" -518- DISPLAY 'CB0065B - FIM NORMAL' . */
            _.Display($"CB0065B - FIM NORMAL");

            /*" -518- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -529- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -530- DISPLAY ' CB0065B - INICIO PROCESSAMENTO ' . */
            _.Display($" CB0065B - INICIO PROCESSAMENTO ");

            /*" -532- DISPLAY ' ' . */
            _.Display($" ");

            /*" -537- OPEN OUTPUT MOV605100-CC MOV600139-CC MOV600140-CC RCB0065B. */
            MOV605100_CC.Open(REG_MOV605100);
            MOV600139_CC.Open(REG_MOV600139);
            MOV600140_CC.Open(REG_MOV600140);
            RCB0065B.Open(REG_CB0065B);

            /*" -539- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -541- PERFORM R0120-00-MONTA-EMPRESA. */

            R0120_00_MONTA_EMPRESA_SECTION();

            /*" -542- MOVE ZEROS TO WS-QTD-DIAS. */
            _.Move(0, W.WS_QTD_DIAS);

            /*" -546- MOVE SPACES TO WSHOST-DATA-UTEIS01 WSHOST-DATA-UTEIS05 WSHOST-DATA-UTEIS07 */
            _.Move("", WSHOST_DATA_UTEIS01, WSHOST_DATA_UTEIS05, WSHOST_DATA_UTEIS07);

            /*" -548- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -550- PERFORM R0250-00-DECLARE-V0CALENDARIO */

            R0250_00_DECLARE_V0CALENDARIO_SECTION();

            /*" -553- PERFORM R0260-00-FETCH-V0CALENDARIO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0260_00_FETCH_V0CALENDARIO_SECTION();
            }

            /*" -555- DISPLAY 'DATA DO PROCESSAMENTO + 01 DIA  UTIL   ' WSHOST-DATA-UTEIS01. */
            _.Display($"DATA DO PROCESSAMENTO + 01 DIA  UTIL   {WSHOST_DATA_UTEIS01}");

            /*" -557- DISPLAY 'DATA DO PROCESSAMENTO + 05 DIAS UTEIS  ' WSHOST-DATA-UTEIS05. */
            _.Display($"DATA DO PROCESSAMENTO + 05 DIAS UTEIS  {WSHOST_DATA_UTEIS05}");

            /*" -561- DISPLAY 'DATA DO PROCESSAMENTO + 07 DIAS UTEIS  ' WSHOST-DATA-UTEIS07. */
            _.Display($"DATA DO PROCESSAMENTO + 07 DIAS UTEIS  {WSHOST_DATA_UTEIS07}");

            /*" -563- DISPLAY ' ' . */
            _.Display($" ");

            /*" -567- IF WSHOST-DATA-UTEIS01 = SPACES OR WSHOST-DATA-UTEIS05 = SPACES OR WSHOST-DATA-UTEIS07 = SPACES */

            if (WSHOST_DATA_UTEIS01.IsEmpty() || WSHOST_DATA_UTEIS05.IsEmpty() || WSHOST_DATA_UTEIS07.IsEmpty())
            {

                /*" -568- DISPLAY 'PROBLEMAS CALCULO DIAS UTEIS  ' */
                _.Display($"PROBLEMAS CALCULO DIAS UTEIS  ");

                /*" -570- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -571- IF SISTEMAS-DATA-MOV-ABERTO EQUAL '2005-06-22' */

            if (SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO == "2005-06-22")
            {

                /*" -574- PERFORM R3000-00-CONVENIO-ZERO. */

                R3000_00_CONVENIO_ZERO_SECTION();
            }


            /*" -574- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -586- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -594- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -597- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -598- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -603- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -611- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_2();

            /*" -614- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -615- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(CALENDARIO)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(CALENDARIO)");

                /*" -617- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -618- MOVE WSHOST-DATA-CURRENT TO WDATA-REL */
            _.Move(WSHOST_DATA_CURRENT, W.WDATA_REL);

            /*" -619- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -620- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -621- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -624- MOVE WDATA-CABEC TO LC02-DATA. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LC02.LC02_DATA);

            /*" -626- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -627- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -628- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -629- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -631- MOVE WDATA-CABEC TO LC03-DTMOVTO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LC03.LC03_DTMOVTO);

            /*" -633- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -634- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, W.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -635- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, W.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -636- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, W.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -638- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(W.WHORA_CABEC, AUX_RELATORIO.LC03.LC03_HORA);

            /*" -640- DISPLAY 'DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($"DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -642- DISPLAY 'DATA DO PROCESSAMENTO + 01 DIA ......  ' WSHOST-DATA-INIVIGENCIA. */
            _.Display($"DATA DO PROCESSAMENTO + 01 DIA ......  {WSHOST_DATA_INIVIGENCIA}");

            /*" -644- DISPLAY 'DATA DO PROCESSAMENTO + 01 MES ......  ' WSHOST-DATA-TERVIGENCIA. */
            _.Display($"DATA DO PROCESSAMENTO + 01 MES ......  {WSHOST_DATA_TERVIGENCIA}");

            /*" -644- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -594- EXEC SQL SELECT DATA_MOV_ABERTO ,CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO ,:WSHOST-DATA-CURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CO' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WSHOST_DATA_CURRENT, WSHOST_DATA_CURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-2 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_2()
        {
            /*" -611- EXEC SQL SELECT (DATA_CALENDARIO + 1 DAYS) ,(DATA_CALENDARIO + 1 MONTH) INTO :WSHOST-DATA-INIVIGENCIA ,:WSHOST-DATA-TERVIGENCIA FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WSHOST_DATA_INIVIGENCIA, WSHOST_DATA_INIVIGENCIA);
                _.Move(executed_1.WSHOST_DATA_TERVIGENCIA, WSHOST_DATA_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" R0120-00-MONTA-EMPRESA-SECTION */
        private void R0120_00_MONTA_EMPRESA_SECTION()
        {
            /*" -655- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -661- PERFORM R0120_00_MONTA_EMPRESA_DB_SELECT_1 */

            R0120_00_MONTA_EMPRESA_DB_SELECT_1();

            /*" -664- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -665- DISPLAY 'CB0065B - EMPRESA NAO ESTA CADASTRADA' */
                _.Display($"CB0065B - EMPRESA NAO ESTA CADASTRADA");

                /*" -667- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -669- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -671- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -672- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -673- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AUX_RELATORIO.LC01.LC01_EMPRESA);

                /*" -674- ELSE */
            }
            else
            {


                /*" -675- DISPLAY 'R0120-00 PROBLEMA CALL EMPRESAS ' */
                _.Display($"R0120-00 PROBLEMA CALL EMPRESAS ");

                /*" -675- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0120-00-MONTA-EMPRESA-DB-SELECT-1 */
        public void R0120_00_MONTA_EMPRESA_DB_SELECT_1()
        {
            /*" -661- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 WITH UR END-EXEC. */

            var r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1 = new R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1.Execute(r0120_00_MONTA_EMPRESA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0250-00-DECLARE-V0CALENDARIO-SECTION */
        private void R0250_00_DECLARE_V0CALENDARIO_SECTION()
        {
            /*" -686- MOVE '0250' TO WNR-EXEC-SQL. */
            _.Move("0250", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -696- PERFORM R0250_00_DECLARE_V0CALENDARIO_DB_DECLARE_1 */

            R0250_00_DECLARE_V0CALENDARIO_DB_DECLARE_1();

            /*" -698- PERFORM R0250_00_DECLARE_V0CALENDARIO_DB_OPEN_1 */

            R0250_00_DECLARE_V0CALENDARIO_DB_OPEN_1();

            /*" -701- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -702- DISPLAY 'R0250-00 - PROBLEMAS DECLARE (CALENDARIO)' */
                _.Display($"R0250-00 - PROBLEMAS DECLARE (CALENDARIO)");

                /*" -702- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0250-00-DECLARE-V0CALENDARIO-DB-DECLARE-1 */
        public void R0250_00_DECLARE_V0CALENDARIO_DB_DECLARE_1()
        {
            /*" -696- EXEC SQL DECLARE V0CALENDARIO CURSOR WITH HOLD FOR SELECT DATA_CALENDARIO ,DIA_SEMANA ,FERIADO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO >= :WSHOST-DATA-INIVIGENCIA AND DATA_CALENDARIO <= :WSHOST-DATA-TERVIGENCIA ORDER BY DATA_CALENDARIO WITH UR END-EXEC. */
            V0CALENDARIO = new CB0065B_V0CALENDARIO(true);
            string GetQuery_V0CALENDARIO()
            {
                var query = @$"SELECT DATA_CALENDARIO 
							,DIA_SEMANA 
							,FERIADO 
							FROM SEGUROS.CALENDARIO 
							WHERE DATA_CALENDARIO >= '{WSHOST_DATA_INIVIGENCIA}' 
							AND DATA_CALENDARIO <= '{WSHOST_DATA_TERVIGENCIA}' 
							ORDER BY DATA_CALENDARIO";

                return query;
            }
            V0CALENDARIO.GetQueryEvent += GetQuery_V0CALENDARIO;

        }

        [StopWatch]
        /*" R0250-00-DECLARE-V0CALENDARIO-DB-OPEN-1 */
        public void R0250_00_DECLARE_V0CALENDARIO_DB_OPEN_1()
        {
            /*" -698- EXEC SQL OPEN V0CALENDARIO END-EXEC. */

            V0CALENDARIO.Open();

        }

        [StopWatch]
        /*" R0310-00-DECLARE-V0MOVDEBCE-DB-DECLARE-1 */
        public void R0310_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1()
        {
            /*" -887- EXEC SQL DECLARE V0MOVDEBCE CURSOR WITH HOLD FOR SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.SITUACAO_COBRANCA ,A.DATA_VENCIMENTO ,A.VALOR_DEBITO ,A.COD_AGENCIA_DEB ,A.OPER_CONTA_DEB ,A.NUM_CONTA_DEB ,A.DIG_CONTA_DEB ,C.ORGAO_EMISSOR ,D.COD_PRODUTO FROM SEGUROS.MOVTO_DEBITOCC_CEF A ,SEGUROS.PARCELAS B ,SEGUROS.APOLICES C ,SEGUROS.ENDOSSOS D WHERE A.SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.DATA_VENCIMENTO <= :WSHOST-DATA-UTEIS07 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.SIT_REGISTRO = '0' AND C.NUM_APOLICE = A.NUM_APOLICE AND D.NUM_APOLICE = A.NUM_APOLICE AND D.NUM_ENDOSSO = A.NUM_ENDOSSO END-EXEC. */
            V0MOVDEBCE = new CB0065B_V0MOVDEBCE(true);
            string GetQuery_V0MOVDEBCE()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.SITUACAO_COBRANCA 
							,A.DATA_VENCIMENTO 
							,A.VALOR_DEBITO 
							,A.COD_AGENCIA_DEB 
							,A.OPER_CONTA_DEB 
							,A.NUM_CONTA_DEB 
							,A.DIG_CONTA_DEB 
							,C.ORGAO_EMISSOR 
							,D.COD_PRODUTO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF A 
							,SEGUROS.PARCELAS B 
							,SEGUROS.APOLICES C 
							,SEGUROS.ENDOSSOS D 
							WHERE A.SITUACAO_COBRANCA = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}' 
							AND A.COD_CONVENIO = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}' 
							AND A.DATA_VENCIMENTO <= '{WSHOST_DATA_UTEIS07}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_PARCELA = A.NUM_PARCELA 
							AND B.SIT_REGISTRO = '0' 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND D.NUM_APOLICE = A.NUM_APOLICE 
							AND D.NUM_ENDOSSO = A.NUM_ENDOSSO";

                return query;
            }
            V0MOVDEBCE.GetQueryEvent += GetQuery_V0MOVDEBCE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0250_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-FETCH-V0CALENDARIO-SECTION */
        private void R0260_00_FETCH_V0CALENDARIO_SECTION()
        {
            /*" -713- MOVE '0260' TO WNR-EXEC-SQL. */
            _.Move("0260", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -718- PERFORM R0260_00_FETCH_V0CALENDARIO_DB_FETCH_1 */

            R0260_00_FETCH_V0CALENDARIO_DB_FETCH_1();

            /*" -721- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -721- PERFORM R0260_00_FETCH_V0CALENDARIO_DB_CLOSE_1 */

                R0260_00_FETCH_V0CALENDARIO_DB_CLOSE_1();

                /*" -723- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -725- GO TO R0260-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/ //GOTO
                return;
            }


            /*" -726- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -727- DISPLAY 'R0260-00 - PROBLEMAS FETCH (V0CALENDARIO)' */
                _.Display($"R0260-00 - PROBLEMAS FETCH (V0CALENDARIO)");

                /*" -729- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -732- IF CALENDAR-DIA-SEMANA EQUAL 'S' OR CALENDAR-DIA-SEMANA EQUAL 'D' OR CALENDAR-FERIADO NOT EQUAL SPACES */

            if (CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "S" || CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA == "D" || !CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO.IsEmpty())
            {

                /*" -734- GO TO R0260-00-FETCH-V0CALENDARIO. */
                new Task(() => R0260_00_FETCH_V0CALENDARIO_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -736- ADD 1 TO WS-QTD-DIAS. */
            W.WS_QTD_DIAS.Value = W.WS_QTD_DIAS + 1;

            /*" -737- IF WS-QTD-DIAS EQUAL 01 */

            if (W.WS_QTD_DIAS == 01)
            {

                /*" -739- MOVE CALENDAR-DATA-CALENDARIO TO WSHOST-DATA-UTEIS01 */
                _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSHOST_DATA_UTEIS01);

                /*" -740- ELSE */
            }
            else
            {


                /*" -741- IF WS-QTD-DIAS EQUAL 05 */

                if (W.WS_QTD_DIAS == 05)
                {

                    /*" -743- MOVE CALENDAR-DATA-CALENDARIO TO WSHOST-DATA-UTEIS05 */
                    _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSHOST_DATA_UTEIS05);

                    /*" -744- ELSE */
                }
                else
                {


                    /*" -745- IF WS-QTD-DIAS EQUAL 07 */

                    if (W.WS_QTD_DIAS == 07)
                    {

                        /*" -752- MOVE CALENDAR-DATA-CALENDARIO TO WSHOST-DATA-UTEIS07. */
                        _.Move(CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO, WSHOST_DATA_UTEIS07);
                    }

                }

            }


            /*" -756- IF WSHOST-DATA-UTEIS01 NOT = SPACES AND WSHOST-DATA-UTEIS05 NOT = SPACES AND WSHOST-DATA-UTEIS07 NOT = SPACES */

            if (!WSHOST_DATA_UTEIS01.IsEmpty() && !WSHOST_DATA_UTEIS05.IsEmpty() && !WSHOST_DATA_UTEIS07.IsEmpty())
            {

                /*" -756- PERFORM R0260_00_FETCH_V0CALENDARIO_DB_CLOSE_2 */

                R0260_00_FETCH_V0CALENDARIO_DB_CLOSE_2();

                /*" -757- MOVE 'S' TO WFIM-MOVIMENTO. */
                _.Move("S", W.WFIM_MOVIMENTO);
            }


        }

        [StopWatch]
        /*" R0260-00-FETCH-V0CALENDARIO-DB-FETCH-1 */
        public void R0260_00_FETCH_V0CALENDARIO_DB_FETCH_1()
        {
            /*" -718- EXEC SQL FETCH V0CALENDARIO INTO :CALENDAR-DATA-CALENDARIO ,:CALENDAR-DIA-SEMANA ,:CALENDAR-FERIADO END-EXEC. */

            if (V0CALENDARIO.Fetch())
            {
                _.Move(V0CALENDARIO.CALENDAR_DATA_CALENDARIO, CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO);
                _.Move(V0CALENDARIO.CALENDAR_DIA_SEMANA, CALENDAR.DCLCALENDARIO.CALENDAR_DIA_SEMANA);
                _.Move(V0CALENDARIO.CALENDAR_FERIADO, CALENDAR.DCLCALENDARIO.CALENDAR_FERIADO);
            }

        }

        [StopWatch]
        /*" R0260-00-FETCH-V0CALENDARIO-DB-CLOSE-1 */
        public void R0260_00_FETCH_V0CALENDARIO_DB_CLOSE_1()
        {
            /*" -721- EXEC SQL CLOSE V0CALENDARIO END-EXEC */

            V0CALENDARIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0260_99_SAIDA*/

        [StopWatch]
        /*" R0260-00-FETCH-V0CALENDARIO-DB-CLOSE-2 */
        public void R0260_00_FETCH_V0CALENDARIO_DB_CLOSE_2()
        {
            /*" -756- EXEC SQL CLOSE V0CALENDARIO END-EXEC */

            V0CALENDARIO.Close();

        }

        [StopWatch]
        /*" R0300-00-PROCESSA-CONVENIO-SECTION */
        private void R0300_00_PROCESSA_CONVENIO_SECTION()
        {
            /*" -770- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -771- IF WS-SUBS EQUAL 01 */

            if (W.WS_SUBS == 01)
            {

                /*" -772- DISPLAY 'CONVENIO 605100 (AZULCAR SEGUROS) - ENVIO ' */
                _.Display($"CONVENIO 605100 (AZULCAR SEGUROS) - ENVIO ");

                /*" -773- MOVE 01 TO PARAMCON-TIPO-MOVTO-CC */
                _.Move(01, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);

                /*" -774- MOVE ZEROS TO PARAMCON-COD-PRODUTO */
                _.Move(0, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);

                /*" -776- MOVE 6051 TO PARAMCON-COD-CONVENIO MOVDEBCE-COD-CONVENIO */
                _.Move(6051, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -777- MOVE 605100 TO ANT-CONVENIO */
                _.Move(605100, W.ANT_CONVENIO);

                /*" -778- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA */
                _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                /*" -779- MOVE 02 TO WS-SUBS */
                _.Move(02, W.WS_SUBS);

                /*" -780- ELSE */
            }
            else
            {


                /*" -781- IF WS-SUBS EQUAL 02 */

                if (W.WS_SUBS == 02)
                {

                    /*" -782- DISPLAY 'CONVENIO 600139 (AZULCAR VERA CRUZ) - ENVIO ' */
                    _.Display($"CONVENIO 600139 (AZULCAR VERA CRUZ) - ENVIO ");

                    /*" -783- MOVE 01 TO PARAMCON-TIPO-MOVTO-CC */
                    _.Move(01, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);

                    /*" -784- MOVE ZEROS TO PARAMCON-COD-PRODUTO */
                    _.Move(0, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);

                    /*" -787- MOVE 600139 TO PARAMCON-COD-CONVENIO MOVDEBCE-COD-CONVENIO ANT-CONVENIO */
                    _.Move(600139, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W.ANT_CONVENIO);

                    /*" -788- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA */
                    _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                    /*" -789- MOVE 03 TO WS-SUBS */
                    _.Move(03, W.WS_SUBS);

                    /*" -790- ELSE */
                }
                else
                {


                    /*" -791- IF WS-SUBS EQUAL 03 */

                    if (W.WS_SUBS == 03)
                    {

                        /*" -792- DISPLAY 'CONVENIO 600140 (RAMOS 40 67 E 75 ) - ENVIO ' */
                        _.Display($"CONVENIO 600140 (RAMOS 40 67 E 75 ) - ENVIO ");

                        /*" -793- MOVE 01 TO PARAMCON-TIPO-MOVTO-CC */
                        _.Move(01, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);

                        /*" -794- MOVE ZEROS TO PARAMCON-COD-PRODUTO */
                        _.Move(0, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);

                        /*" -797- MOVE 600140 TO PARAMCON-COD-CONVENIO MOVDEBCE-COD-CONVENIO ANT-CONVENIO */
                        _.Move(600140, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, W.ANT_CONVENIO);

                        /*" -798- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA */
                        _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                        /*" -799- MOVE 04 TO WS-SUBS */
                        _.Move(04, W.WS_SUBS);

                        /*" -800- ELSE */
                    }
                    else
                    {


                        /*" -801- DISPLAY 'CONVENIO NAO PREVISTO' */
                        _.Display($"CONVENIO NAO PREVISTO");

                        /*" -803- GO TO R0300-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -805- DISPLAY ' ' . */
            _.Display($" ");

            /*" -812- MOVE ZEROS TO LD-V0MOVDEBCE LD-V1MOVDEBCE DP-V0MOVDEBCE AC-TOTREGISTRO AC-TOTARQUIVO AC-VLRTOTDEB AC-PAGINA. */
            _.Move(0, W.LD_V0MOVDEBCE, W.LD_V1MOVDEBCE, W.DP_V0MOVDEBCE, W.AC_TOTREGISTRO, W.AC_TOTARQUIVO, W.AC_VLRTOTDEB, W.AC_PAGINA);

            /*" -815- MOVE 100 TO AC-LINHAS. */
            _.Move(100, W.AC_LINHAS);

            /*" -817- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -818- IF MOVDEBCE-COD-CONVENIO NOT EQUAL 600139 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO != 600139)
            {

                /*" -819- PERFORM R0310-00-DECLARE-V0MOVDEBCE */

                R0310_00_DECLARE_V0MOVDEBCE_SECTION();

                /*" -820- PERFORM R0320-00-FETCH-V0MOVDEBCE */

                R0320_00_FETCH_V0MOVDEBCE_SECTION();

                /*" -821- ELSE */
            }
            else
            {


                /*" -822- PERFORM R0330-00-DECLARE-V1MOVDEBCE */

                R0330_00_DECLARE_V1MOVDEBCE_SECTION();

                /*" -824- PERFORM R0340-00-FETCH-V1MOVDEBCE. */

                R0340_00_FETCH_V1MOVDEBCE_SECTION();
            }


            /*" -825- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -826- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' */
                _.Display($"SEM MOVIMENTO NESTA DATA  ");

                /*" -828- GO TO R0300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -830- PERFORM R0350-00-SELECT-V0PARAMCON. */

            R0350_00_SELECT_V0PARAMCON_SECTION();

            /*" -833- PERFORM R0400-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0400_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -835- MOVE AC-VLRTOTDEB TO AC-VALOR. */
            _.Move(W.AC_VLRTOTDEB, W.AC_VALOR);

            /*" -836- DISPLAY ' ' . */
            _.Display($" ");

            /*" -837- DISPLAY 'MOVDEBCE LIDOS (DEMAIS) ' LD-V0MOVDEBCE. */
            _.Display($"MOVDEBCE LIDOS (DEMAIS) {W.LD_V0MOVDEBCE}");

            /*" -838- DISPLAY 'MOVDEBCE LIDOS (600139) ' LD-V1MOVDEBCE. */
            _.Display($"MOVDEBCE LIDOS (600139) {W.LD_V1MOVDEBCE}");

            /*" -839- DISPLAY 'MOVDEBCE DESPREZADOS .. ' DP-V0MOVDEBCE. */
            _.Display($"MOVDEBCE DESPREZADOS .. {W.DP_V0MOVDEBCE}");

            /*" -840- DISPLAY 'REGISTROS ENVIADOS .... ' AC-TOTREGISTRO. */
            _.Display($"REGISTROS ENVIADOS .... {W.AC_TOTREGISTRO}");

            /*" -841- DISPLAY 'VALOR TOTAL ........... ' AC-VALOR. */
            _.Display($"VALOR TOTAL ........... {W.AC_VALOR}");

            /*" -843- DISPLAY ' ' . */
            _.Display($" ");

            /*" -844- IF AC-TOTARQUIVO NOT EQUAL ZEROS */

            if (W.AC_TOTARQUIVO != 00)
            {

                /*" -846- PERFORM R0650-00-GRAVA-TRAILLER. */

                R0650_00_GRAVA_TRAILLER_SECTION();
            }


            /*" -846- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-DECLARE-V0MOVDEBCE-SECTION */
        private void R0310_00_DECLARE_V0MOVDEBCE_SECTION()
        {
            /*" -858- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -887- PERFORM R0310_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1 */

            R0310_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1();

            /*" -889- PERFORM R0310_00_DECLARE_V0MOVDEBCE_DB_OPEN_1 */

            R0310_00_DECLARE_V0MOVDEBCE_DB_OPEN_1();

            /*" -892- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -893- DISPLAY 'R0310-00 - PROBLEMAS DECLARE (MOVDEBCE)' */
                _.Display($"R0310-00 - PROBLEMAS DECLARE (MOVDEBCE)");

                /*" -893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0310-00-DECLARE-V0MOVDEBCE-DB-OPEN-1 */
        public void R0310_00_DECLARE_V0MOVDEBCE_DB_OPEN_1()
        {
            /*" -889- EXEC SQL OPEN V0MOVDEBCE END-EXEC. */

            V0MOVDEBCE.Open();

        }

        [StopWatch]
        /*" R0330-00-DECLARE-V1MOVDEBCE-DB-DECLARE-1 */
        public void R0330_00_DECLARE_V1MOVDEBCE_DB_DECLARE_1()
        {
            /*" -1011- EXEC SQL DECLARE V1MOVDEBCE CURSOR WITH HOLD FOR (SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.SITUACAO_COBRANCA ,A.DATA_VENCIMENTO ,A.VALOR_DEBITO ,A.COD_AGENCIA_DEB ,A.OPER_CONTA_DEB ,A.NUM_CONTA_DEB ,A.DIG_CONTA_DEB ,C.ORGAO_EMISSOR ,D.COD_PRODUTO FROM SEGUROS.MOVTO_DEBITOCC_CEF A ,SEGUROS.PARCELAS B ,SEGUROS.APOLICES C ,SEGUROS.ENDOSSOS D WHERE A.SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.DATA_VENCIMENTO <= :WSHOST-DATA-UTEIS07 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.NUM_PARCELA = A.NUM_PARCELA AND B.SIT_REGISTRO = '0' AND C.NUM_APOLICE = A.NUM_APOLICE AND D.NUM_APOLICE = A.NUM_APOLICE AND D.NUM_ENDOSSO = A.NUM_ENDOSSO ) UNION ALL (SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.SITUACAO_COBRANCA ,A.DATA_VENCIMENTO ,A.VALOR_DEBITO ,A.COD_AGENCIA_DEB ,A.OPER_CONTA_DEB ,A.NUM_CONTA_DEB ,A.DIG_CONTA_DEB ,10 ,B.COD_PRODUTO FROM SEGUROS.MOVTO_DEBITOCC_CEF A ,SEGUROS.PROPOSTAS B ,SEGUROS.PROPOSTA_AUTO C ,SEGUROS.AU_VENDA_ONLINE D WHERE A.SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.DATA_VENCIMENTO <= :WSHOST-DATA-UTEIS07 AND A.NUM_APOLICE = D.NUM_TITULO AND B.COD_FONTE = C.COD_FONTE AND B.NUM_PROPOSTA = C.NUM_PROPOSTA AND C.NUM_PROPOSTA_CONV = D.NUM_PROPOSTA_CONV AND D.STA_PROCESSADO = 'S' AND B.COD_PRODUTO IN (5302, 5303, 5304) AND D.IND_FORMA_PAGTO_AD IN (1,3) AND D.NUM_CANAL_PROPOSTA <> 8 AND C.NUM_ITEM = ( SELECT MAX(E.NUM_ITEM) FROM SEGUROS.PROPOSTA_AUTO E WHERE E.COD_FONTE = C.COD_FONTE AND E.NUM_PROPOSTA = C.NUM_PROPOSTA ) ) END-EXEC. */
            V1MOVDEBCE = new CB0065B_V1MOVDEBCE(true);
            string GetQuery_V1MOVDEBCE()
            {
                var query = @$"(SELECT A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.SITUACAO_COBRANCA 
							,A.DATA_VENCIMENTO 
							,A.VALOR_DEBITO 
							,A.COD_AGENCIA_DEB 
							,A.OPER_CONTA_DEB 
							,A.NUM_CONTA_DEB 
							,A.DIG_CONTA_DEB 
							,C.ORGAO_EMISSOR 
							,D.COD_PRODUTO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF A 
							,SEGUROS.PARCELAS B 
							,SEGUROS.APOLICES C 
							,SEGUROS.ENDOSSOS D 
							WHERE A.SITUACAO_COBRANCA = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}' 
							AND A.COD_CONVENIO = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}' 
							AND A.DATA_VENCIMENTO <= '{WSHOST_DATA_UTEIS07}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.NUM_PARCELA = A.NUM_PARCELA 
							AND B.SIT_REGISTRO = '0' 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND D.NUM_APOLICE = A.NUM_APOLICE 
							AND D.NUM_ENDOSSO = A.NUM_ENDOSSO 
							) 
							UNION ALL 
							(SELECT A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.SITUACAO_COBRANCA 
							,A.DATA_VENCIMENTO 
							,A.VALOR_DEBITO 
							,A.COD_AGENCIA_DEB 
							,A.OPER_CONTA_DEB 
							,A.NUM_CONTA_DEB 
							,A.DIG_CONTA_DEB 
							,10 
							,B.COD_PRODUTO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF A 
							,SEGUROS.PROPOSTAS B 
							,SEGUROS.PROPOSTA_AUTO C 
							,SEGUROS.AU_VENDA_ONLINE D 
							WHERE A.SITUACAO_COBRANCA = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}' 
							AND A.COD_CONVENIO = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}' 
							AND A.DATA_VENCIMENTO <= '{WSHOST_DATA_UTEIS07}' 
							AND A.NUM_APOLICE = D.NUM_TITULO 
							AND B.COD_FONTE = C.COD_FONTE 
							AND B.NUM_PROPOSTA = C.NUM_PROPOSTA 
							AND C.NUM_PROPOSTA_CONV = D.NUM_PROPOSTA_CONV 
							AND D.STA_PROCESSADO = 'S' 
							AND B.COD_PRODUTO IN (5302
							, 5303
							, 5304) 
							AND D.IND_FORMA_PAGTO_AD IN (1
							,3) 
							AND D.NUM_CANAL_PROPOSTA <> 8 
							AND C.NUM_ITEM = 
							( SELECT MAX(E.NUM_ITEM) 
							FROM SEGUROS.PROPOSTA_AUTO E 
							WHERE E.COD_FONTE = C.COD_FONTE 
							AND E.NUM_PROPOSTA = C.NUM_PROPOSTA 
							) 
							)";

                return query;
            }
            V1MOVDEBCE.GetQueryEvent += GetQuery_V1MOVDEBCE;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-FETCH-V0MOVDEBCE-SECTION */
        private void R0320_00_FETCH_V0MOVDEBCE_SECTION()
        {
            /*" -905- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -918- PERFORM R0320_00_FETCH_V0MOVDEBCE_DB_FETCH_1 */

            R0320_00_FETCH_V0MOVDEBCE_DB_FETCH_1();

            /*" -922- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -922- PERFORM R0320_00_FETCH_V0MOVDEBCE_DB_CLOSE_1 */

                R0320_00_FETCH_V0MOVDEBCE_DB_CLOSE_1();

                /*" -924- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -926- GO TO R0320-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/ //GOTO
                return;
            }


            /*" -927- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -928- DISPLAY 'R0320-00 - PROBLEMAS FETCH (MOVDEBCE)' */
                _.Display($"R0320-00 - PROBLEMAS FETCH (MOVDEBCE)");

                /*" -931- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -931- ADD 1 TO LD-V0MOVDEBCE. */
            W.LD_V0MOVDEBCE.Value = W.LD_V0MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R0320-00-FETCH-V0MOVDEBCE-DB-FETCH-1 */
        public void R0320_00_FETCH_V0MOVDEBCE_DB_FETCH_1()
        {
            /*" -918- EXEC SQL FETCH V0MOVDEBCE INTO :MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-VALOR-DEBITO ,:MOVDEBCE-COD-AGENCIA-DEB ,:MOVDEBCE-OPER-CONTA-DEB ,:MOVDEBCE-NUM-CONTA-DEB ,:MOVDEBCE-DIG-CONTA-DEB ,:APOLICES-ORGAO-EMISSOR ,:ENDOSSOS-COD-PRODUTO END-EXEC. */

            if (V0MOVDEBCE.Fetch())
            {
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(V0MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(V0MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(V0MOVDEBCE.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(V0MOVDEBCE.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(V0MOVDEBCE.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(V0MOVDEBCE.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0320-00-FETCH-V0MOVDEBCE-DB-CLOSE-1 */
        public void R0320_00_FETCH_V0MOVDEBCE_DB_CLOSE_1()
        {
            /*" -922- EXEC SQL CLOSE V0MOVDEBCE END-EXEC */

            V0MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-DECLARE-V1MOVDEBCE-SECTION */
        private void R0330_00_DECLARE_V1MOVDEBCE_SECTION()
        {
            /*" -943- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1011- PERFORM R0330_00_DECLARE_V1MOVDEBCE_DB_DECLARE_1 */

            R0330_00_DECLARE_V1MOVDEBCE_DB_DECLARE_1();

            /*" -1013- PERFORM R0330_00_DECLARE_V1MOVDEBCE_DB_OPEN_1 */

            R0330_00_DECLARE_V1MOVDEBCE_DB_OPEN_1();

            /*" -1016- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1017- DISPLAY 'R0330-00 - PROBLEMAS DECLARE (MOVDEBCE)' */
                _.Display($"R0330-00 - PROBLEMAS DECLARE (MOVDEBCE)");

                /*" -1017- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0330-00-DECLARE-V1MOVDEBCE-DB-OPEN-1 */
        public void R0330_00_DECLARE_V1MOVDEBCE_DB_OPEN_1()
        {
            /*" -1013- EXEC SQL OPEN V1MOVDEBCE END-EXEC. */

            V1MOVDEBCE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-FETCH-V1MOVDEBCE-SECTION */
        private void R0340_00_FETCH_V1MOVDEBCE_SECTION()
        {
            /*" -1029- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1042- PERFORM R0340_00_FETCH_V1MOVDEBCE_DB_FETCH_1 */

            R0340_00_FETCH_V1MOVDEBCE_DB_FETCH_1();

            /*" -1046- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1046- PERFORM R0340_00_FETCH_V1MOVDEBCE_DB_CLOSE_1 */

                R0340_00_FETCH_V1MOVDEBCE_DB_CLOSE_1();

                /*" -1048- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", W.WFIM_MOVIMENTO);

                /*" -1050- GO TO R0340-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1051- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1052- DISPLAY 'R0340-00 - PROBLEMAS FETCH (MOVDEBCE)' */
                _.Display($"R0340-00 - PROBLEMAS FETCH (MOVDEBCE)");

                /*" -1055- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1055- ADD 1 TO LD-V1MOVDEBCE. */
            W.LD_V1MOVDEBCE.Value = W.LD_V1MOVDEBCE + 1;

        }

        [StopWatch]
        /*" R0340-00-FETCH-V1MOVDEBCE-DB-FETCH-1 */
        public void R0340_00_FETCH_V1MOVDEBCE_DB_FETCH_1()
        {
            /*" -1042- EXEC SQL FETCH V1MOVDEBCE INTO :MOVDEBCE-NUM-APOLICE ,:MOVDEBCE-NUM-ENDOSSO ,:MOVDEBCE-NUM-PARCELA ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-DATA-VENCIMENTO ,:MOVDEBCE-VALOR-DEBITO ,:MOVDEBCE-COD-AGENCIA-DEB ,:MOVDEBCE-OPER-CONTA-DEB ,:MOVDEBCE-NUM-CONTA-DEB ,:MOVDEBCE-DIG-CONTA-DEB ,:APOLICES-ORGAO-EMISSOR ,:ENDOSSOS-COD-PRODUTO END-EXEC. */

            if (V1MOVDEBCE.Fetch())
            {
                _.Move(V1MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(V1MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(V1MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(V1MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(V1MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(V1MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(V1MOVDEBCE.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(V1MOVDEBCE.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(V1MOVDEBCE.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(V1MOVDEBCE.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(V1MOVDEBCE.APOLICES_ORGAO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR);
                _.Move(V1MOVDEBCE.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
            }

        }

        [StopWatch]
        /*" R0340-00-FETCH-V1MOVDEBCE-DB-CLOSE-1 */
        public void R0340_00_FETCH_V1MOVDEBCE_DB_CLOSE_1()
        {
            /*" -1046- EXEC SQL CLOSE V1MOVDEBCE END-EXEC */

            V1MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-SELECT-V0PARAMCON-SECTION */
        private void R0350_00_SELECT_V0PARAMCON_SECTION()
        {
            /*" -1067- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1081- PERFORM R0350_00_SELECT_V0PARAMCON_DB_SELECT_1 */

            R0350_00_SELECT_V0PARAMCON_DB_SELECT_1();

            /*" -1085- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1086- DISPLAY 'R0350-00 - PROBLEMAS SELECT(PARAM_CONTACEF)' */
                _.Display($"R0350-00 - PROBLEMAS SELECT(PARAM_CONTACEF)");

                /*" -1089- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1093- ADD 1 TO PARAMCON-NSAS. */
            PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.Value = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS + 1;

            /*" -1095- DISPLAY ' NSAS DE ENVIO .......................  ' PARAMCON-NSAS. */
            _.Display($" NSAS DE ENVIO .......................  {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS}");

            /*" -1095- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0350-00-SELECT-V0PARAMCON-DB-SELECT-1 */
        public void R0350_00_SELECT_V0PARAMCON_DB_SELECT_1()
        {
            /*" -1081- EXEC SQL SELECT TIPO_MOVTO_CC , COD_PRODUTO , COD_CONVENIO , NSAS INTO :PARAMCON-TIPO-MOVTO-CC , :PARAMCON-COD-PRODUTO , :PARAMCON-COD-CONVENIO , :PARAMCON-NSAS FROM SEGUROS.PARAM_CONTACEF WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC AND COD_PRODUTO = :PARAMCON-COD-PRODUTO AND COD_CONVENIO = :PARAMCON-COD-CONVENIO WITH UR END-EXEC. */

            var r0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 = new R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1()
            {
                PARAMCON_TIPO_MOVTO_CC = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                PARAMCON_COD_PRODUTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMCON_TIPO_MOVTO_CC, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);
                _.Move(executed_1.PARAMCON_COD_PRODUTO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);
                _.Move(executed_1.PARAMCON_COD_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);
                _.Move(executed_1.PARAMCON_NSAS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0400_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -1108- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1109- MOVE SPACES TO LD01-MENSAGEM */
            _.Move("", AUX_RELATORIO.LD01.LD01_MENSAGEM);

            /*" -1111- PERFORM R0450-00-CONSISTE-REGISTRO. */

            R0450_00_CONSISTE_REGISTRO_SECTION();

            /*" -1112- IF LD01-MENSAGEM NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_MENSAGEM.IsEmpty())
            {

                /*" -1113- ADD 1 TO DP-V0MOVDEBCE */
                W.DP_V0MOVDEBCE.Value = W.DP_V0MOVDEBCE + 1;

                /*" -1114- PERFORM R0500-00-SELECT-V0RCAPS */

                R0500_00_SELECT_V0RCAPS_SECTION();

                /*" -1115- PERFORM R1500-00-IMPRIME-ERRO */

                R1500_00_IMPRIME_ERRO_SECTION();

                /*" -1118- GO TO R0400-90-LEITURA. */

                R0400_90_LEITURA(); //GOTO
                return;
            }


            /*" -1119- IF AC-TOTARQUIVO EQUAL ZEROS */

            if (W.AC_TOTARQUIVO == 00)
            {

                /*" -1122- PERFORM R0550-00-GRAVA-HEADER. */

                R0550_00_GRAVA_HEADER_SECTION();
            }


            /*" -1122- PERFORM R0600-00-GRAVA-DETALHE. */

            R0600_00_GRAVA_DETALHE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0400_90_LEITURA */

            R0400_90_LEITURA();

        }

        [StopWatch]
        /*" R0400-90-LEITURA */
        private void R0400_90_LEITURA(bool isPerform = false)
        {
            /*" -1128- IF MOVDEBCE-COD-CONVENIO NOT EQUAL 600139 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO != 600139)
            {

                /*" -1129- PERFORM R0320-00-FETCH-V0MOVDEBCE */

                R0320_00_FETCH_V0MOVDEBCE_SECTION();

                /*" -1130- ELSE */
            }
            else
            {


                /*" -1130- PERFORM R0340-00-FETCH-V1MOVDEBCE. */

                R0340_00_FETCH_V1MOVDEBCE_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-CONSISTE-REGISTRO-SECTION */
        private void R0450_00_CONSISTE_REGISTRO_SECTION()
        {
            /*" -1142- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1143- IF MOVDEBCE-VALOR-DEBITO EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO == 00)
            {

                /*" -1145- MOVE 'PARCELA EMITIDA SEM VALOR               ' TO LD01-MENSAGEM */
                _.Move("PARCELA EMITIDA SEM VALOR               ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1148- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1149- IF MOVDEBCE-VALOR-DEBITO LESS ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO < 00)
            {

                /*" -1151- MOVE 'PARCELA EMITIDA COM VALOR NEGATIVO      ' TO LD01-MENSAGEM */
                _.Move("PARCELA EMITIDA COM VALOR NEGATIVO      ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1154- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1155- IF MOVDEBCE-COD-AGENCIA-DEB EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB == 00)
            {

                /*" -1157- MOVE 'AGENCIA DA CONTA NAO INFORMADA          ' TO LD01-MENSAGEM */
                _.Move("AGENCIA DA CONTA NAO INFORMADA          ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1160- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1161- IF MOVDEBCE-OPER-CONTA-DEB EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB == 00)
            {

                /*" -1163- MOVE 'OPERACAO DA CONTA NAO INFORMADA         ' TO LD01-MENSAGEM */
                _.Move("OPERACAO DA CONTA NAO INFORMADA         ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1166- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1167- IF MOVDEBCE-NUM-CONTA-DEB EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB == 00)
            {

                /*" -1169- MOVE 'NUMERO DA CONTA NAO INFORMADA           ' TO LD01-MENSAGEM */
                _.Move("NUMERO DA CONTA NAO INFORMADA           ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1172- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1174- PERFORM R0460-00-SELECT-V0AGENCCEF. */

            R0460_00_SELECT_V0AGENCCEF_SECTION();

            /*" -1175- IF LD01-MENSAGEM NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_MENSAGEM.IsEmpty())
            {

                /*" -1177- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1179- PERFORM R0470-00-VERIFICA-CONTA. */

            R0470_00_VERIFICA_CONTA_SECTION();

            /*" -1180- IF WS-DIGCONTA NOT EQUAL LPARM15-D1 */

            if (W.WS_DIGCONTA != W.LPARM15X.LPARM15_D1)
            {

                /*" -1182- MOVE 'CONTA INFORMADA INVALIDA' TO LD01-MENSAGEM */
                _.Move("CONTA INFORMADA INVALIDA", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1192- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1193- IF PARAMCON-COD-CONVENIO EQUAL 600139 */

            if (PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO == 600139)
            {

                /*" -1196- IF APOLICES-ORGAO-EMISSOR NOT EQUAL 100 AND APOLICES-ORGAO-EMISSOR NOT EQUAL 110 AND APOLICES-ORGAO-EMISSOR NOT EQUAL 10 */

                if (APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR != 100 && APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR != 110 && APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR != 10)
                {

                    /*" -1198- MOVE 'DOCUMENTO NAO PERTENCE AO CONVENIO      ' TO LD01-MENSAGEM */
                    _.Move("DOCUMENTO NAO PERTENCE AO CONVENIO      ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                    /*" -1201- GO TO R0450-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                    return;
                }

            }


            /*" -1203- IF PARAMCON-COD-CONVENIO EQUAL 6051 AND APOLICES-ORGAO-EMISSOR NOT EQUAL 10 */

            if (PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO == 6051 && APOLICES.DCLAPOLICES.APOLICES_ORGAO_EMISSOR != 10)
            {

                /*" -1205- MOVE 'DOCUMENTO NAO PERTENCE AO CONVENIO      ' TO LD01-MENSAGEM */
                _.Move("DOCUMENTO NAO PERTENCE AO CONVENIO      ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -1205- GO TO R0450-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/ //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0460-00-SELECT-V0AGENCCEF-SECTION */
        private void R0460_00_SELECT_V0AGENCCEF_SECTION()
        {
            /*" -1218- MOVE '0460' TO WNR-EXEC-SQL. */
            _.Move("0460", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1222- MOVE MOVDEBCE-COD-AGENCIA-DEB TO AGENCCEF-COD-AGENCIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -1228- PERFORM R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1 */

            R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1();

            /*" -1233- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1234- DISPLAY 'R0460-00 - PROBLEMAS NO SELECT(AGENCCEF)' */
                _.Display($"R0460-00 - PROBLEMAS NO SELECT(AGENCCEF)");

                /*" -1237- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1238- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1239- MOVE 'AGENCIA DA CONTA NAO CADASTRADA         ' TO LD01-MENSAGEM. */
                _.Move("AGENCIA DA CONTA NAO CADASTRADA         ", AUX_RELATORIO.LD01.LD01_MENSAGEM);
            }


        }

        [StopWatch]
        /*" R0460-00-SELECT-V0AGENCCEF-DB-SELECT-1 */
        public void R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1()
        {
            /*" -1228- EXEC SQL SELECT COD_AGENCIA INTO :AGENCCEF-COD-AGENCIA FROM SEGUROS.AGENCIAS_CEF WHERE COD_AGENCIA = :AGENCCEF-COD-AGENCIA WITH UR END-EXEC. */

            var r0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1 = new R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1.Execute(r0460_00_SELECT_V0AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_99_SAIDA*/

        [StopWatch]
        /*" R0470-00-VERIFICA-CONTA-SECTION */
        private void R0470_00_VERIFICA_CONTA_SECTION()
        {
            /*" -1251- MOVE '0470' TO WNR-EXEC-SQL. */
            _.Move("0470", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1252- INITIALIZE WS-NUMERO. */
            _.Initialize(
                W.WS_NUMERO
            );

            /*" -1253- IF MOVDEBCE-NUM-CONTA-DEB >= 400000000 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB >= 400000000)
            {

                /*" -1254- MOVE MOVDEBCE-NUM-CONTA-DEB TO WS-NUMERO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, W.WS_NUMERO);

                /*" -1255- ELSE */
            }
            else
            {


                /*" -1257- MOVE MOVDEBCE-COD-AGENCIA-DEB TO WS-AGENCIA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, W.FILLER_8.WS_AGENCIA);

                /*" -1259- MOVE MOVDEBCE-OPER-CONTA-DEB TO WS-OPERACAO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, W.FILLER_8.WS_OPERACAO);

                /*" -1261- MOVE MOVDEBCE-NUM-CONTA-DEB TO WS-NUMCONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, W.FILLER_8.WS_NUMCONTA);

                /*" -1263- END-IF. */
            }


            /*" -1266- MOVE MOVDEBCE-DIG-CONTA-DEB TO WS-DIGCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, W.WS_DIGCONTA);

            /*" -1269- MOVE WS-NUMERO TO LPARM15. */
            _.Move(W.WS_NUMERO, W.LPARM15X.LPARM15);

            /*" -1285- COMPUTE WPARM15-AUX = LPARM15-1 * 8 + LPARM15-2 * 7 + LPARM15-3 * 6 + LPARM15-4 * 5 + LPARM15-5 * 4 + LPARM15-6 * 3 + LPARM15-7 * 2 + LPARM15-8 * 9 + LPARM15-9 * 8 + LPARM15-10 * 7 + LPARM15-11 * 6 + LPARM15-12 * 5 + LPARM15-13 * 4 + LPARM15-14 * 3 + LPARM15-15 * 2 */
            W.WPARM15_AUX.Value = W.LPARM15X.FILLER_9.LPARM15_1 * 8 + W.LPARM15X.FILLER_9.LPARM15_2 * 7 + W.LPARM15X.FILLER_9.LPARM15_3 * 6 + W.LPARM15X.FILLER_9.LPARM15_4 * 5 + W.LPARM15X.FILLER_9.LPARM15_5 * 4 + W.LPARM15X.FILLER_9.LPARM15_6 * 3 + W.LPARM15X.FILLER_9.LPARM15_7 * 2 + W.LPARM15X.FILLER_9.LPARM15_8 * 9 + W.LPARM15X.FILLER_9.LPARM15_9 * 8 + W.LPARM15X.FILLER_9.LPARM15_10 * 7 + W.LPARM15X.FILLER_9.LPARM15_11 * 6 + W.LPARM15X.FILLER_9.LPARM15_12 * 5 + W.LPARM15X.FILLER_9.LPARM15_13 * 4 + W.LPARM15X.FILLER_9.LPARM15_14 * 3 + W.LPARM15X.FILLER_9.LPARM15_15 * 2;

            /*" -1288- DIVIDE WPARM15-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(W.WPARM15_AUX, 11, W.WQUOCIENTE, W.WRESTO);

            /*" -1289- IF WRESTO EQUAL ZEROS */

            if (W.WRESTO == 00)
            {

                /*" -1290- MOVE 0 TO LPARM15-D1 */
                _.Move(0, W.LPARM15X.LPARM15_D1);

                /*" -1291- ELSE */
            }
            else
            {


                /*" -1292- SUBTRACT WRESTO FROM 11 GIVING LPARM15-D1. */
                W.LPARM15X.LPARM15_D1.Value = 11 - W.WRESTO;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-V0RCAPS-SECTION */
        private void R0500_00_SELECT_V0RCAPS_SECTION()
        {
            /*" -1305- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1307- MOVE MOVDEBCE-NUM-APOLICE TO ENDOSSOS-NUM-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);

            /*" -1311- MOVE MOVDEBCE-NUM-ENDOSSO TO ENDOSSOS-NUM-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);

            /*" -1314- MOVE ZEROS TO RCAPS-NUM-CERTIFICADO. */
            _.Move(0, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1317- GO TO R0500-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
            return;


        }

        [StopWatch]
        /*" R0500-00-SELECT-V0RCAPS-DB-SELECT-1 */
        public void R0500_00_SELECT_V0RCAPS_DB_SELECT_1()
        {
            /*" -1326- EXEC SQL SELECT VALUE (B.NUM_CERTIFICADO,0) INTO :RCAPS-NUM-CERTIFICADO FROM SEGUROS.ENDOSSOS A, SEGUROS.RCAPS B WHERE A.NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND B.NUM_RCAP = A.NUM_RCAP WITH UR END-EXEC. */

            var r0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1 = new R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V0RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_CERTIFICADO, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-GRAVA-HEADER-SECTION */
        private void R0550_00_GRAVA_HEADER_SECTION()
        {
            /*" -1350- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1352- MOVE 1 TO AC-TOTARQUIVO. */
            _.Move(1, W.AC_TOTARQUIVO);

            /*" -1354- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -1356- MOVE 'A' TO HEADER-CODREGISTRO. */
            _.Move("A", HEADER_REGISTRO.HEADER_CODREGISTRO);

            /*" -1358- MOVE '1' TO HEADER-CODREMESSA. */
            _.Move("1", HEADER_REGISTRO.HEADER_CODREMESSA);

            /*" -1360- MOVE ANT-CONVENIO TO HEADER-CONVENIO. */
            _.Move(W.ANT_CONVENIO, HEADER_REGISTRO.HEADER_CODCONVENIO.HEADER_CONVENIO);

            /*" -1362- MOVE 'CAIXA SEGURADORA S/A' TO HEADER-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA S/A", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -1364- MOVE '104' TO HEADER-CODBANCO. */
            _.Move("104", HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -1366- MOVE 'CAIXA ECONOMICA FEDE' TO HEADER-NOMBANCO. */
            _.Move("CAIXA ECONOMICA FEDE", HEADER_REGISTRO.HEADER_NOMBANCO);

            /*" -1368- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -1370- MOVE WDAT-REL-ANO TO HEADER-ANO. */
            _.Move(W.FILLER_1.WDAT_REL_ANO, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_ANO);

            /*" -1372- MOVE WDAT-REL-MES TO HEADER-MES. */
            _.Move(W.FILLER_1.WDAT_REL_MES, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_MES);

            /*" -1374- MOVE WDAT-REL-DIA TO HEADER-DIA. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, HEADER_REGISTRO.HEADER_DATGERACAO.HEADER_DIA);

            /*" -1376- MOVE PARAMCON-NSAS TO HEADER-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, HEADER_REGISTRO.HEADER_NSAS);

            /*" -1378- MOVE '04' TO HEADER-VERSAO. */
            _.Move("04", HEADER_REGISTRO.HEADER_VERSAO);

            /*" -1382- MOVE 'DEB/CRED AUTOMAT ' TO HEADER-DEBCREDAUT. */
            _.Move("DEB/CRED AUTOMAT ", HEADER_REGISTRO.HEADER_DEBCREDAUT);

            /*" -1383- IF ANT-CONVENIO EQUAL 605100 */

            if (W.ANT_CONVENIO == 605100)
            {

                /*" -1385- MOVE 'SASSE AZULCAR       ' TO HEADER-NOMEMPRESA */
                _.Move("SASSE AZULCAR       ", HEADER_REGISTRO.HEADER_NOMEMPRESA);

                /*" -1386- MOVE HEADER-REGISTRO TO REG-MOV605100 */
                _.Move(HEADER_REGISTRO, REG_MOV605100);

                /*" -1387- WRITE REG-MOV605100 */
                MOV605100_CC.Write(REG_MOV605100.GetMoveValues().ToString());

                /*" -1388- ELSE */
            }
            else
            {


                /*" -1389- IF ANT-CONVENIO EQUAL 600139 */

                if (W.ANT_CONVENIO == 600139)
                {

                    /*" -1390- MOVE HEADER-REGISTRO TO REG-MOV600139 */
                    _.Move(HEADER_REGISTRO, REG_MOV600139);

                    /*" -1391- WRITE REG-MOV600139 */
                    MOV600139_CC.Write(REG_MOV600139.GetMoveValues().ToString());

                    /*" -1392- ELSE */
                }
                else
                {


                    /*" -1393- IF ANT-CONVENIO EQUAL 600140 */

                    if (W.ANT_CONVENIO == 600140)
                    {

                        /*" -1395- MOVE 'RD / SGTO           ' TO HEADER-NOMEMPRESA */
                        _.Move("RD / SGTO           ", HEADER_REGISTRO.HEADER_NOMEMPRESA);

                        /*" -1396- MOVE HEADER-REGISTRO TO REG-MOV600140 */
                        _.Move(HEADER_REGISTRO, REG_MOV600140);

                        /*" -1396- WRITE REG-MOV600140. */
                        MOV600140_CC.Write(REG_MOV600140.GetMoveValues().ToString());
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-GRAVA-DETALHE-SECTION */
        private void R0600_00_GRAVA_DETALHE_SECTION()
        {
            /*" -1409- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1411- PERFORM R0610-00-UPDATE-V0MOVDEBCE. */

            R0610_00_UPDATE_V0MOVDEBCE_SECTION();

            /*" -1412- IF MOVDEBCE-SITUACAO-COBRANCA EQUAL '*' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "*")
            {

                /*" -1415- GO TO R0600-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1418- ADD 1 TO AC-TOTARQUIVO AC-TOTREGISTRO. */
            W.AC_TOTARQUIVO.Value = W.AC_TOTARQUIVO + 1;
            W.AC_TOTREGISTRO.Value = W.AC_TOTREGISTRO + 1;

            /*" -1420- MOVE SPACES TO MOVCC-REGISTRO. */
            _.Move("", MOVCC_REGISTRO);

            /*" -1422- MOVE 'E' TO MOVCC-CODREGISTRO. */
            _.Move("E", MOVCC_REGISTRO.MOVCC_CODREGISTRO);

            /*" -1424- MOVE MOVDEBCE-NUM-APOLICE TO MOVCC-NUMAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NUMAPOL);

            /*" -1426- MOVE MOVDEBCE-NUM-ENDOSSO TO MOVCC-NRENDOS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NRENDOS);

            /*" -1428- MOVE MOVDEBCE-NUM-PARCELA TO MOVCC-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, MOVCC_REGISTRO.MOVCC_IDTCLIEMP.MOVCC_NRPARCEL);

            /*" -1430- MOVE MOVDEBCE-COD-AGENCIA-DEB TO MOVCC-AGECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_AGECONTA);

            /*" -1432- MOVE MOVDEBCE-OPER-CONTA-DEB TO MOVCC-OPECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_OPECONTA);

            /*" -1434- MOVE MOVDEBCE-NUM-CONTA-DEB TO MOVCC-NUMCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_NUMCONTA);

            /*" -1437- MOVE MOVDEBCE-DIG-CONTA-DEB TO MOVCC-DIGCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, MOVCC_REGISTRO.MOVCC_IDTCLIBAN.MOVCC_DIGCONTA);

            /*" -1438- IF MOVDEBCE-DATA-VENCIMENTO LESS WSHOST-DATA-UTEIS05 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO < WSHOST_DATA_UTEIS05)
            {

                /*" -1440- MOVE WSHOST-DATA-UTEIS05 TO WDATA-REL */
                _.Move(WSHOST_DATA_UTEIS05, W.WDATA_REL);

                /*" -1441- ELSE */
            }
            else
            {


                /*" -1445- MOVE MOVDEBCE-DATA-VENCIMENTO TO WDATA-REL. */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, W.WDATA_REL);
            }


            /*" -1446- IF WDATA-REL EQUAL '2007-12-31' */

            if (W.WDATA_REL == "2007-12-31")
            {

                /*" -1449- MOVE '2008-01-02' TO WDATA-REL. */
                _.Move("2008-01-02", W.WDATA_REL);
            }


            /*" -1451- IF WDAT-REL-DIA EQUAL 31 AND WDAT-REL-MES EQUAL 12 */

            if (W.FILLER_1.WDAT_REL_DIA == 31 && W.FILLER_1.WDAT_REL_MES == 12)
            {

                /*" -1452- MOVE 02 TO WDAT-REL-DIA */
                _.Move(02, W.FILLER_1.WDAT_REL_DIA);

                /*" -1453- MOVE 01 TO WDAT-REL-MES */
                _.Move(01, W.FILLER_1.WDAT_REL_MES);

                /*" -1456- ADD 01 TO WDAT-REL-ANO. */
                W.FILLER_1.WDAT_REL_ANO.Value = W.FILLER_1.WDAT_REL_ANO + 01;
            }


            /*" -1458- MOVE WDAT-REL-ANO TO MOVCC-ANO. */
            _.Move(W.FILLER_1.WDAT_REL_ANO, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_ANO);

            /*" -1460- MOVE WDAT-REL-MES TO MOVCC-MES. */
            _.Move(W.FILLER_1.WDAT_REL_MES, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_MES);

            /*" -1463- MOVE WDAT-REL-DIA TO MOVCC-DIA. */
            _.Move(W.FILLER_1.WDAT_REL_DIA, MOVCC_REGISTRO.MOVCC_DTCREDITO.MOVCC_DIA);

            /*" -1465- MOVE MOVDEBCE-VALOR-DEBITO TO MOVCC-VLDEBCRE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, MOVCC_REGISTRO.MOVCC_VLDEBCRE);

            /*" -1467- ADD MOVDEBCE-VALOR-DEBITO TO AC-VLRTOTDEB. */
            W.AC_VLRTOTDEB.Value = W.AC_VLRTOTDEB + MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO;

            /*" -1469- MOVE '00' TO MOVCC-CODMOEDA. */
            _.Move("00", MOVCC_REGISTRO.MOVCC_CODMOEDA);

            /*" -1471- MOVE ANT-CONVENIO TO MOVCC-CONVENIO. */
            _.Move(W.ANT_CONVENIO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_CONVENIO);

            /*" -1473- MOVE PARAMCON-NSAS TO MOVCC-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_NSAS);

            /*" -1475- MOVE AC-TOTREGISTRO TO MOVCC-NRSEQ. */
            _.Move(W.AC_TOTREGISTRO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_NRSEQ);

            /*" -1477- MOVE ENDOSSOS-COD-PRODUTO TO MOVCC-CODPRODU. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, MOVCC_REGISTRO.MOVCC_USOEMPRESA.MOVCC_CODPRODU);

            /*" -1481- MOVE '0' TO MOVCC-CODMOV. */
            _.Move("0", MOVCC_REGISTRO.MOVCC_CODMOV);

            /*" -1482- IF ANT-CONVENIO EQUAL 605100 */

            if (W.ANT_CONVENIO == 605100)
            {

                /*" -1483- MOVE MOVCC-REGISTRO TO REG-MOV605100 */
                _.Move(MOVCC_REGISTRO, REG_MOV605100);

                /*" -1484- WRITE REG-MOV605100 */
                MOV605100_CC.Write(REG_MOV605100.GetMoveValues().ToString());

                /*" -1485- ELSE */
            }
            else
            {


                /*" -1486- IF ANT-CONVENIO EQUAL 600139 */

                if (W.ANT_CONVENIO == 600139)
                {

                    /*" -1487- MOVE MOVCC-REGISTRO TO REG-MOV600139 */
                    _.Move(MOVCC_REGISTRO, REG_MOV600139);

                    /*" -1488- WRITE REG-MOV600139 */
                    MOV600139_CC.Write(REG_MOV600139.GetMoveValues().ToString());

                    /*" -1489- ELSE */
                }
                else
                {


                    /*" -1490- IF ANT-CONVENIO EQUAL 600140 */

                    if (W.ANT_CONVENIO == 600140)
                    {

                        /*" -1491- MOVE MOVCC-REGISTRO TO REG-MOV600140 */
                        _.Move(MOVCC_REGISTRO, REG_MOV600140);

                        /*" -1492- WRITE REG-MOV600140 */
                        MOV600140_CC.Write(REG_MOV600140.GetMoveValues().ToString());

                        /*" -1493- ELSE */
                    }
                    else
                    {


                        /*" -1499- GO TO R0600-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1505- IF MOVDEBCE-COD-CONVENIO EQUAL 600139 AND MOVDEBCE-NUM-PARCELA EQUAL 0 AND (ENDOSSOS-COD-PRODUTO EQUAL 5302 OR ENDOSSOS-COD-PRODUTO EQUAL 5303 OR ENDOSSOS-COD-PRODUTO EQUAL 5304) NEXT SENTENCE */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 600139 && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA == 0 && (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 5302 || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 5303 || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 5304))
            {

                /*" -1506- ELSE */
            }
            else
            {


                /*" -1506- PERFORM R0620-00-UPDATE-V0PARCELAS. */

                R0620_00_UPDATE_V0PARCELAS_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R0610_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -1519- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1533- PERFORM R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -1537- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1539- MOVE '*' TO MOVDEBCE-SITUACAO-COBRANCA */
                _.Move("*", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

                /*" -1545- DISPLAY 'R0610-00 - DUPLICIDADE UPDATE(MOVDEBCE)' ' APOLICE    ' MOVDEBCE-NUM-APOLICE ' ENDOSSO    ' MOVDEBCE-NUM-ENDOSSO ' PARCELA    ' MOVDEBCE-NUM-PARCELA ' CONVENIO   ' MOVDEBCE-COD-CONVENIO ' DTVENCTO   ' MOVDEBCE-DATA-VENCIMENTO */

                $"R0610-00 - DUPLICIDADE UPDATE(MOVDEBCE) APOLICE    {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} ENDOSSO    {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} PARCELA    {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} CONVENIO   {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO} DTVENCTO   {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}"
                .Display();

                /*" -1546- ELSE */
            }
            else
            {


                /*" -1547- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1553- DISPLAY 'R0610-00 - PROBLEMAS NO UPDATE(MOVDEBCE)' ' APOLICE    ' MOVDEBCE-NUM-APOLICE ' ENDOSSO    ' MOVDEBCE-NUM-ENDOSSO ' PARCELA    ' MOVDEBCE-NUM-PARCELA ' CONVENIO   ' MOVDEBCE-COD-CONVENIO ' DTVENCTO   ' MOVDEBCE-DATA-VENCIMENTO */

                    $"R0610-00 - PROBLEMAS NO UPDATE(MOVDEBCE) APOLICE    {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} ENDOSSO    {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} PARCELA    {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} CONVENIO   {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO} DTVENCTO   {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}"
                    .Display();

                    /*" -1554- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1555- ELSE */
                }
                else
                {


                    /*" -1556- MOVE '1' TO MOVDEBCE-SITUACAO-COBRANCA. */
                    _.Move("1", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                }

            }


        }

        [StopWatch]
        /*" R0610-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -1533- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = '1' , DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO, TIMESTAMP = CURRENT TIMESTAMP, DATA_ENVIO = :WSHOST-DATA-UTEIS01, NSAS = :PARAMCON-NSAS, COD_USUARIO = 'CB0065B' WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND DATA_VENCIMENTO = :MOVDEBCE-DATA-VENCIMENTO END-EXEC. */

            var r0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WSHOST_DATA_UTEIS01 = WSHOST_DATA_UTEIS01.ToString(),
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r0610_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0620-00-UPDATE-V0PARCELAS-SECTION */
        private void R0620_00_UPDATE_V0PARCELAS_SECTION()
        {
            /*" -1569- MOVE '0620' TO WNR-EXEC-SQL. */
            _.Move("0620", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1576- PERFORM R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1 */

            R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1();

            /*" -1580- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1581- DISPLAY 'R0620-00 - PROBLEMAS NO UPDATE(PARCELAS)' */
                _.Display($"R0620-00 - PROBLEMAS NO UPDATE(PARCELAS)");

                /*" -1581- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0620-00-UPDATE-V0PARCELAS-DB-UPDATE-1 */
        public void R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1()
        {
            /*" -1576- EXEC SQL UPDATE SEGUROS.PARCELAS SET SITUACAO_COBRANCA = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA END-EXEC. */

            var r0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1 = new R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            R0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1.Execute(r0620_00_UPDATE_V0PARCELAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0620_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-GRAVA-TRAILLER-SECTION */
        private void R0650_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -1594- MOVE '0650' TO WNR-EXEC-SQL. */
            _.Move("0650", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1596- ADD 1 TO AC-TOTARQUIVO. */
            W.AC_TOTARQUIVO.Value = W.AC_TOTARQUIVO + 1;

            /*" -1598- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -1600- MOVE 'Z' TO TRAILL-CODREGISTRO. */
            _.Move("Z", TRAILL_REGISTRO.TRAILL_CODREGISTRO);

            /*" -1602- MOVE AC-TOTARQUIVO TO TRAILL-TOTREGISTRO. */
            _.Move(W.AC_TOTARQUIVO, TRAILL_REGISTRO.TRAILL_TOTREGISTRO);

            /*" -1604- MOVE AC-VLRTOTDEB TO TRAILL-VLRTOTDEB. */
            _.Move(W.AC_VLRTOTDEB, TRAILL_REGISTRO.TRAILL_VLRTOTDEB);

            /*" -1608- MOVE ZEROS TO TRAILL-VLRTOTCRE. */
            _.Move(0, TRAILL_REGISTRO.TRAILL_VLRTOTCRE);

            /*" -1609- IF ANT-CONVENIO EQUAL 605100 */

            if (W.ANT_CONVENIO == 605100)
            {

                /*" -1610- MOVE TRAILL-REGISTRO TO REG-MOV605100 */
                _.Move(TRAILL_REGISTRO, REG_MOV605100);

                /*" -1611- WRITE REG-MOV605100 */
                MOV605100_CC.Write(REG_MOV605100.GetMoveValues().ToString());

                /*" -1612- ELSE */
            }
            else
            {


                /*" -1613- IF ANT-CONVENIO EQUAL 600139 */

                if (W.ANT_CONVENIO == 600139)
                {

                    /*" -1614- MOVE TRAILL-REGISTRO TO REG-MOV600139 */
                    _.Move(TRAILL_REGISTRO, REG_MOV600139);

                    /*" -1615- WRITE REG-MOV600139 */
                    MOV600139_CC.Write(REG_MOV600139.GetMoveValues().ToString());

                    /*" -1616- ELSE */
                }
                else
                {


                    /*" -1617- IF ANT-CONVENIO EQUAL 600140 */

                    if (W.ANT_CONVENIO == 600140)
                    {

                        /*" -1618- MOVE TRAILL-REGISTRO TO REG-MOV600140 */
                        _.Move(TRAILL_REGISTRO, REG_MOV600140);

                        /*" -1619- WRITE REG-MOV600140 */
                        MOV600140_CC.Write(REG_MOV600140.GetMoveValues().ToString());

                        /*" -1620- ELSE */
                    }
                    else
                    {


                        /*" -1623- GO TO R0650-99-SAIDA. */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/ //GOTO
                        return;
                    }

                }

            }


            /*" -1623- PERFORM R0700-00-UPDATE-V0PARAMCON. */

            R0700_00_UPDATE_V0PARAMCON_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-UPDATE-V0PARAMCON-SECTION */
        private void R0700_00_UPDATE_V0PARAMCON_SECTION()
        {
            /*" -1636- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1646- PERFORM R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1 */

            R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1();

            /*" -1649- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1650- DISPLAY 'R0700-00 - PROBLEMAS NO UPDATE(PARAMCON)' */
                _.Display($"R0700-00 - PROBLEMAS NO UPDATE(PARAMCON)");

                /*" -1650- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0700-00-UPDATE-V0PARAMCON-DB-UPDATE-1 */
        public void R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1()
        {
            /*" -1646- EXEC SQL UPDATE SEGUROS.PARAM_CONTACEF SET NSAS = :PARAMCON-NSAS ,DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO ,DATA_PROXIMO_DEB = :WSHOST-DATA-UTEIS07 ,TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC AND COD_PRODUTO = :PARAMCON-COD-PRODUTO AND COD_CONVENIO = :PARAMCON-COD-CONVENIO END-EXEC. */

            var r0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1 = new R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WSHOST_DATA_UTEIS07 = WSHOST_DATA_UTEIS07.ToString(),
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                PARAMCON_TIPO_MOVTO_CC = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                PARAMCON_COD_PRODUTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO.ToString(),
            };

            R0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1.Execute(r0700_00_UPDATE_V0PARAMCON_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-IMPRIME-ERRO-SECTION */
        private void R1500_00_IMPRIME_ERRO_SECTION()
        {
            /*" -1663- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1665- MOVE MOVDEBCE-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_APOLICE);

            /*" -1667- MOVE MOVDEBCE-NUM-ENDOSSO TO LD01-ENDOSSO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -1669- MOVE MOVDEBCE-NUM-PARCELA TO LD01-PARCELA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -1671- MOVE RCAPS-NUM-CERTIFICADO TO LD01-PROPOSTA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO, AUX_RELATORIO.LD01.LD01_PROPOSTA);

            /*" -1673- MOVE MOVDEBCE-COD-AGENCIA-DEB TO LD01-AGECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, AUX_RELATORIO.LD01.LD01_AGECONTA);

            /*" -1675- MOVE MOVDEBCE-OPER-CONTA-DEB TO LD01-OPECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, AUX_RELATORIO.LD01.LD01_OPECONTA);

            /*" -1677- MOVE MOVDEBCE-NUM-CONTA-DEB TO LD01-NUMCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, AUX_RELATORIO.LD01.LD01_NUMCONTA);

            /*" -1679- MOVE MOVDEBCE-DIG-CONTA-DEB TO LD01-DIGCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, AUX_RELATORIO.LD01.LD01_DIGCONTA);

            /*" -1683- MOVE MOVDEBCE-VALOR-DEBITO TO LD01-VALOR. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -1684- IF AC-LINHAS GREATER 56 */

            if (W.AC_LINHAS > 56)
            {

                /*" -1687- PERFORM R2000-00-CABECALHOS. */

                R2000_00_CABECALHOS_SECTION();
            }


            /*" -1688- WRITE REG-CB0065B FROM LD01 AFTER 1. */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1688- ADD 1 TO AC-LINHAS. */
            W.AC_LINHAS.Value = W.AC_LINHAS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CABECALHOS-SECTION */
        private void R2000_00_CABECALHOS_SECTION()
        {
            /*" -1700- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1702- ADD 1 TO AC-PAGINA */
            W.AC_PAGINA.Value = W.AC_PAGINA + 1;

            /*" -1703- MOVE AC-PAGINA TO LC01-PAGINA. */
            _.Move(W.AC_PAGINA, AUX_RELATORIO.LC01.LC01_PAGINA);

            /*" -1704- MOVE ANT-CONVENIO TO LC04-CONVENIO. */
            _.Move(W.ANT_CONVENIO, AUX_RELATORIO.LC04.LC04_CONVENIO);

            /*" -1705- MOVE PARAMCON-NSAS TO LC04-NSAS. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, AUX_RELATORIO.LC04.LC04_NSAS);

            /*" -1706- MOVE WSHOST-DATA-UTEIS01 TO WDATA-REL */
            _.Move(WSHOST_DATA_UTEIS01, W.WDATA_REL);

            /*" -1707- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1708- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1709- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1710- MOVE WDATA-CABEC TO LC04-DTENVIO. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LC04.LC04_DTENVIO);

            /*" -1711- MOVE WSHOST-DATA-UTEIS05 TO WDATA-REL */
            _.Move(WSHOST_DATA_UTEIS05, W.WDATA_REL);

            /*" -1712- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1713- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1714- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1716- MOVE WDATA-CABEC TO LC04-DTVENCTO1. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LC04.LC04_DTVENCTO1);

            /*" -1717- MOVE WSHOST-DATA-UTEIS07 TO WDATA-REL */
            _.Move(WSHOST_DATA_UTEIS07, W.WDATA_REL);

            /*" -1718- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1719- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1720- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC */
            _.Move(W.FILLER_1.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1722- MOVE WDATA-CABEC TO LC04-DTVENCTO2. */
            _.Move(W.WDATA_CABEC, AUX_RELATORIO.LC04.LC04_DTVENCTO2);

            /*" -1723- WRITE REG-CB0065B FROM LC01 AFTER PAGE */
            _.Move(AUX_RELATORIO.LC01.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1724- WRITE REG-CB0065B FROM LC02 AFTER 1 */
            _.Move(AUX_RELATORIO.LC02.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1725- WRITE REG-CB0065B FROM LC03 AFTER 1 */
            _.Move(AUX_RELATORIO.LC03.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1726- WRITE REG-CB0065B FROM LC04 AFTER 2 */
            _.Move(AUX_RELATORIO.LC04.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1727- WRITE REG-CB0065B FROM LC05 AFTER 1 */
            _.Move(AUX_RELATORIO.LC05.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1728- WRITE REG-CB0065B FROM LC06 AFTER 1 */
            _.Move(AUX_RELATORIO.LC06.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1729- WRITE REG-CB0065B FROM LC05 AFTER 1 */
            _.Move(AUX_RELATORIO.LC05.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1731- WRITE REG-CB0065B FROM LC08 AFTER 1. */
            _.Move(AUX_RELATORIO.LC08.GetMoveValues(), REG_CB0065B);

            RCB0065B.Write(REG_CB0065B.GetMoveValues().ToString());

            /*" -1731- MOVE 09 TO AC-LINHAS. */
            _.Move(09, W.AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-CONVENIO-ZERO-SECTION */
        private void R3000_00_CONVENIO_ZERO_SECTION()
        {
            /*" -1744- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1744- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1750- MOVE 600140 TO MOVDEBCE-COD-CONVENIO. */
            _.Move(600140, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -1752- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -1754- MOVE 0101400610081 TO MOVDEBCE-NUM-APOLICE. */
            _.Move(0101400610081, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -1757- MOVE ZEROS TO MOVDEBCE-NUM-ENDOSSO. */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -1757- PERFORM R3010-00-UPDATE-V0MOVDEBCE. */

            R3010_00_UPDATE_V0MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3010-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R3010_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -1770- MOVE '3010' TO WNR-EXEC-SQL. */
            _.Move("3010", AUX_RELATORIO.WABEND.WNR_EXEC_SQL);

            /*" -1777- PERFORM R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -1782- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -1783- DISPLAY 'R3010-00 - PROBLEMAS NO SELECT(MOVDEBCE)' */
                _.Display($"R3010-00 - PROBLEMAS NO SELECT(MOVDEBCE)");

                /*" -1786- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1787- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1788- DISPLAY 'R3010-00 - NAO  ' MOVDEBCE-NUM-APOLICE */
                _.Display($"R3010-00 - NAO  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -1789- ELSE */
            }
            else
            {


                /*" -1789- DISPLAY 'R3010-00 - SIM  ' MOVDEBCE-NUM-APOLICE. */
                _.Display($"R3010-00 - SIM  {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");
            }


        }

        [StopWatch]
        /*" R3010-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -1777- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET COD_CONVENIO = :MOVDEBCE-COD-CONVENIO WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND COD_CONVENIO = 0 END-EXEC. */

            var r3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
            };

            R3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r3010_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3010_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1800- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AUX_RELATORIO.WABEND.WSQLCODE);

            /*" -1801- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AUX_RELATORIO.WABEND.WSQLERRD1);

            /*" -1803- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AUX_RELATORIO.WABEND.WSQLERRD2);

            /*" -1805- DISPLAY WABEND. */
            _.Display(AUX_RELATORIO.WABEND);

            /*" -1805- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1812- CLOSE MOV605100-CC MOV600139-CC MOV600140-CC RCB0065B. */
            MOV605100_CC.Close();
            MOV600139_CC.Close();
            MOV600140_CC.Close();
            RCB0065B.Close();

            /*" -1814- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1814- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}