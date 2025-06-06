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
using Sias.Emissao.DB2.EM8021B;

namespace Code
{
    public class EM8021B
    {
        public bool IsCall { get; set; }

        public EM8021B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8021B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  18/11/2010                         *      */
        /*"      *   VERSAO .................  18/11/2010                         *      */
        /*"      *   DATA REVISAO ...........  21/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  PROCESSA FITA DE RETORNO SIACC     *      */
        /*"      *                             A PARTIR DA LEITURA DO ARQUIVO     *      */
        /*"      *                             GERADO PELO PGM EM8006B, RETORNO   *      */
        /*"      *                             ARQ-H SAP - LEGADO                 *      */
        /*"      *                             CONVENIO 043350 - C.E.F.           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 04 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.04         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * HEIDER - 02/08/2011                                            *      */
        /*"      *     MOVIMENTAR O COD-RETORNO DO BANCO DO ARQUIVO DE ENTRADA    *      */
        /*"      *     PARA O ARQUIVO QUE SERA LIDO PELO LEGADO.                  *      */
        /*"      *     NO V.02 S� FOI FEITO PARA O CHEQUE. OS PAGAMENTOS DE       *      */
        /*"      *     SINISTRO DO CONVENIO 43350 ESTAVAM COM PROBLEMA.           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * HEIDER - 08/02/2011                                            *      */
        /*"      *     MOVIMENTAR O COD-RETORNO DO BANCO DO ARQUIVO DE ENTRADA    *      */
        /*"      *     PARA O ARQUIVO QUE SERA LIDO PELO LEGADO                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * HEIDER - 29/01/2011                                            *      */
        /*"      *     O PROGRAMA VAI GERAR O ARQUIVO DO SIACC MESMO QUE A        *      */
        /*"      *     SITUACAO_COBRANCA <> '1'.                                  *      */
        /*"      *     ISTO SERA TRATADO PELOS PROGRAMAS:                         *      */
        /*"      *     SI5068B - RETORNO DE REPASSE DE RESSARCIMENTO - SIACC CAIXA*      */
        /*"      *     SI0903B - RETORNO DE INDENIZACAO HABIT E PENHOR SIACC CAIXA*      */
        /*"      *     CB1063B - RETORNO DE MOVIMENTO BANCO DO BRASIL 921286      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(REG_MOVIMENTO, _MOVIMENTO); VarBasis.RedefinePassValue(REG_MOVIMENTO, _MOVIMENTO, REG_MOVIMENTO); return _MOVIMENTO;
            }
        }
        public FileBasis _MOV043350_CC { get; set; } = new FileBasis(new PIC("X", "240", "X(240)"));

        public FileBasis MOV043350_CC
        {
            get
            {
                _.Move(REG_MOV043350, _MOV043350_CC); VarBasis.RedefinePassValue(REG_MOV043350, _MOV043350_CC, REG_MOV043350); return _MOV043350_CC;
            }
        }
        public SortBasis<EM8021B_REG_SEM8021B> SEM8021B { get; set; } = new SortBasis<EM8021B_REG_SEM8021B>(new EM8021B_REG_SEM8021B());
        /*"01        REG-SEM8021B.*/
        public EM8021B_REG_SEM8021B REG_SEM8021B { get; set; } = new EM8021B_REG_SEM8021B();
        public class EM8021B_REG_SEM8021B : VarBasis
        {
            /*"  05      SCB1-SEQSORT                PIC  9(002).*/
            public IntBasis SCB1_SEQSORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SCB1-TIPOREG                PIC  X(010).*/
            public StringBasis SCB1_TIPOREG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SCB1-OCORR-MOVTO            PIC  9(009).*/
            public IntBasis SCB1_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SCB1-NUMAPOL                PIC  9(013).*/
            public IntBasis SCB1_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SCB1-NRENDOS                PIC  9(009).*/
            public IntBasis SCB1_NRENDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SCB1-NRPARCEL               PIC  9(004).*/
            public IntBasis SCB1_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-CONVENIO               PIC  9(006).*/
            public IntBasis SCB1_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SCB1-NSAS                   PIC  9(006).*/
            public IntBasis SCB1_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SCB1-NSAC                   PIC  9(006).*/
            public IntBasis SCB1_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SCB1-BANCO                  PIC  9(003).*/
            public IntBasis SCB1_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      SCB1-AGENCIA                PIC  9(004).*/
            public IntBasis SCB1_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-OPECONTA               PIC  9(004).*/
            public IntBasis SCB1_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-NUMCONTA               PIC  9(012).*/
            public IntBasis SCB1_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05      SCB1-DIGCONTA               PIC  X(003).*/
            public StringBasis SCB1_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      SCB1-DTVENCTO               PIC  X(010).*/
            public StringBasis SCB1_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SCB1-VLPREMIO               PIC S9(013)V99.*/
            public DoubleBasis SCB1_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SCB1-DTPAGTO                PIC  X(010).*/
            public StringBasis SCB1_DTPAGTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SCB1-VLPAGTO                PIC S9(013)V99.*/
            public DoubleBasis SCB1_VLPAGTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99."), 2);
            /*"  05      SCB1-CODAGENC               PIC  9(004).*/
            public IntBasis SCB1_CODAGENC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-CONTACNB               PIC  X(020).*/
            public StringBasis SCB1_CONTACNB { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      SCB1-INDCONTA               PIC  9(004).*/
            public IntBasis SCB1_INDCONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-NUMCHQ                 PIC  9(009).*/
            public IntBasis SCB1_NUMCHQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SCB1-NUM-SIVAT              PIC  9(009).*/
            public IntBasis SCB1_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SCB1-IDLG                   PIC  X(040).*/
            public StringBasis SCB1_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      SCB1-RAMO                   PIC  9(004).*/
            public IntBasis SCB1_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-PRODUTO                PIC  9(004).*/
            public IntBasis SCB1_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-COD-RETORNO-BANCO      PIC  X(010).*/
            public StringBasis SCB1_COD_RETORNO_BANCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SCB1-NUM-DOC-BANCO          PIC  9(009).*/
            public IntBasis SCB1_NUM_DOC_BANCO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"01        REG-MOVIMENTO               PIC  X(300).*/
        }
        public StringBasis REG_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-MOV043350               PIC  X(240).*/
        public StringBasis REG_MOV043350 { get; set; } = new StringBasis(new PIC("X", "240", "X(240)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WVALOR-AUX                PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WVALOR_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WQUOCIENTE                PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WRESTO                    PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUMREQ               PIC S9(004)     COMP.*/
        public IntBasis VIND_NUMREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CARTAO               PIC S9(004)     COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public EM8021B_W W { get; set; } = new EM8021B_W();
        public class EM8021B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-MOVDEBCE             PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-ENTRADA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-MV043350               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MV043350 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ENTRADA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-CHEQUE                 PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_CHEQUE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SINISTRO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  AC-QTDLOTE                PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_QTDLOTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-QTDREGARQ              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_QTDREGARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-QTDREGLOT              PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_QTDREGLOT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-NRSEQ                  PIC  9(006)    VALUE   ZEROS.*/
            public IntBasis AC_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03  AC-VLRTOTCRE              PIC S9(013)V99 COMP-3.*/
            public DoubleBasis AC_VLRTOTCRE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  AC-VLRTOTAL               PIC S9(013)V99 COMP-3.*/
            public DoubleBasis AC_VLRTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  ANT-SEQSORT               PIC  9(002)    VALUE   ZEROS.*/
            public IntBasis ANT_SEQSORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03  ATU-SEQSORT               PIC  9(002)    VALUE   ZEROS.*/
            public IntBasis ATU_SEQSORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  03  WS-IND1                   PIC S9(009)  COMP  VALUE ZEROS.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03  WS-IND2                   PIC S9(009)  COMP  VALUE ZEROS.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WS-IDLG-CHEQUE      PIC  X(40).*/
            public StringBasis WS_IDLG_CHEQUE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  03         FILLER REDEFINES    WS-IDLG-CHEQUE.*/
            private _REDEF_EM8021B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM8021B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM8021B_FILLER_0(); _.Move(WS_IDLG_CHEQUE, _filler_0); VarBasis.RedefinePassValue(WS_IDLG_CHEQUE, _filler_0, WS_IDLG_CHEQUE); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_IDLG_CHEQUE); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_IDLG_CHEQUE); }
            }  //Redefines
            public class _REDEF_EM8021B_FILLER_0 : VarBasis
            {
                /*"     10     WS-IDLG-MATCON      PIC  X(19).*/
                public StringBasis WS_IDLG_MATCON { get; set; } = new StringBasis(new PIC("X", "19", "X(19)."), @"");
                /*"     10     WS-IDLG-NUMCHQ      PIC  9(10).*/
                public IntBasis WS_IDLG_NUMCHQ { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                /*"     10     WS-FILLER01         PIC  X(01).*/
                public StringBasis WS_FILLER01 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-IDLG-NRENDOS     PIC  9(04).*/
                public IntBasis WS_IDLG_NRENDOS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10     WS-FILLER02         PIC  X(01).*/
                public StringBasis WS_FILLER02 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-IDLG-NRPARCEL    PIC  9(04).*/
                public IntBasis WS_IDLG_NRPARCEL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10     WS-FILLER03         PIC  X(01).*/
                public StringBasis WS_FILLER03 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"  03        WS-IDLG-SINISTRO    PIC  X(40).*/

                public _REDEF_EM8021B_FILLER_0()
                {
                    WS_IDLG_MATCON.ValueChanged += OnValueChanged;
                    WS_IDLG_NUMCHQ.ValueChanged += OnValueChanged;
                    WS_FILLER01.ValueChanged += OnValueChanged;
                    WS_IDLG_NRENDOS.ValueChanged += OnValueChanged;
                    WS_FILLER02.ValueChanged += OnValueChanged;
                    WS_IDLG_NRPARCEL.ValueChanged += OnValueChanged;
                    WS_FILLER03.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  03         FILLER REDEFINES    WS-IDLG-SINISTRO.*/
            private _REDEF_EM8021B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM8021B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM8021B_FILLER_1(); _.Move(WS_IDLG_SINISTRO, _filler_1); VarBasis.RedefinePassValue(WS_IDLG_SINISTRO, _filler_1, WS_IDLG_SINISTRO); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_IDLG_SINISTRO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WS_IDLG_SINISTRO); }
            }  //Redefines
            public class _REDEF_EM8021B_FILLER_1 : VarBasis
            {
                /*"     10     WS-IDLG-OCORHIS     PIC  9(09).*/
                public IntBasis WS_IDLG_OCORHIS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"     10     WS-IDLG-NUMAPOL     PIC  9(13).*/
                public IntBasis WS_IDLG_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10     WS-IDLG-CONTRATO    PIC  9(18).*/
                public IntBasis WS_IDLG_CONTRATO { get; set; } = new IntBasis(new PIC("9", "18", "9(18)."));
                /*"  03         WTIME-DAY          PIC  99.99.99.99.*/

                public _REDEF_EM8021B_FILLER_1()
                {
                    WS_IDLG_OCORHIS.ValueChanged += OnValueChanged;
                    WS_IDLG_NUMAPOL.ValueChanged += OnValueChanged;
                    WS_IDLG_CONTRATO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_EM8021B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_EM8021B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_EM8021B_FILLER_2(); _.Move(WTIME_DAY, _filler_2); VarBasis.RedefinePassValue(WTIME_DAY, _filler_2, WTIME_DAY); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTIME_DAY); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_EM8021B_FILLER_2 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public EM8021B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM8021B_WTIME_DAYR();
                public class EM8021B_WTIME_DAYR : VarBasis
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

                    public EM8021B_WTIME_DAYR()
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

                public _REDEF_EM8021B_FILLER_2()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public EM8021B_WS_TIME WS_TIME { get; set; } = new EM8021B_WS_TIME();
            public class EM8021B_WS_TIME : VarBasis
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
            private _REDEF_EM8021B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_EM8021B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_EM8021B_FILLER_3(); _.Move(WDATA_REL, _filler_3); VarBasis.RedefinePassValue(WDATA_REL, _filler_3, WDATA_REL); _filler_3.ValueChanged += () => { _.Move(_filler_3, WDATA_REL); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8021B_FILLER_3 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WHORA-CURR.*/

                public _REDEF_EM8021B_FILLER_3()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public EM8021B_WHORA_CURR WHORA_CURR { get; set; } = new EM8021B_WHORA_CURR();
            public class EM8021B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03        WABEND.*/
            }
            public EM8021B_WABEND WABEND { get; set; } = new EM8021B_WABEND();
            public class EM8021B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8021B  '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8021B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03        WSQLERR.*/
            }
            public EM8021B_WSQLERR WSQLERR { get; set; } = new EM8021B_WSQLERR();
            public class EM8021B_WSQLERR : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01          ARQHEA-REGISTRO.*/
            }
        }
        public EM8021B_ARQHEA_REGISTRO ARQHEA_REGISTRO { get; set; } = new EM8021B_ARQHEA_REGISTRO();
        public class EM8021B_ARQHEA_REGISTRO : VarBasis
        {
            /*"  05        ARQHEA-CONTROLE.*/
            public EM8021B_ARQHEA_CONTROLE ARQHEA_CONTROLE { get; set; } = new EM8021B_ARQHEA_CONTROLE();
            public class EM8021B_ARQHEA_CONTROLE : VarBasis
            {
                /*"    10      ARQHEA-BANCO           PIC  9(003).*/
                public IntBasis ARQHEA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      ARQHEA-LOTSER          PIC  9(004).*/
                public IntBasis ARQHEA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      ARQHEA-TIPOREG         PIC  9(001).*/
                public IntBasis ARQHEA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        ARQHEA-EMPRESA.*/
            public EM8021B_ARQHEA_EMPRESA ARQHEA_EMPRESA { get; set; } = new EM8021B_ARQHEA_EMPRESA();
            public class EM8021B_ARQHEA_EMPRESA : VarBasis
            {
                /*"    10      ARQHEA-INSCRICAO.*/
                public EM8021B_ARQHEA_INSCRICAO ARQHEA_INSCRICAO { get; set; } = new EM8021B_ARQHEA_INSCRICAO();
                public class EM8021B_ARQHEA_INSCRICAO : VarBasis
                {
                    /*"      15    ARQHEA-TIPINSC         PIC  9(001).*/
                    public IntBasis ARQHEA_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    ARQHEA-NROINSC         PIC  9(014).*/
                    public IntBasis ARQHEA_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    10      ARQHEA-CONVENIO        PIC  9(006).*/
                }
                public IntBasis ARQHEA_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQHEA-PAR-TRANSMIS    PIC  9(002).*/
                public IntBasis ARQHEA_PAR_TRANSMIS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      ARQHEA-AMB-CLIENTE     PIC  X(001).*/
                public StringBasis ARQHEA_AMB_CLIENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      ARQHEA-AMB-CAIXA       PIC  X(001).*/
                public StringBasis ARQHEA_AMB_CAIXA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      ARQHEA-ORI-APLICATIVO  PIC  X(003).*/
                public StringBasis ARQHEA_ORI_APLICATIVO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10      ARQHEA-NUM-VERSAO      PIC  9(004).*/
                public IntBasis ARQHEA_NUM_VERSAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER                 PIC  X(003).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10      ARQHEA-CONTA.*/
                public EM8021B_ARQHEA_CONTA ARQHEA_CONTA { get; set; } = new EM8021B_ARQHEA_CONTA();
                public class EM8021B_ARQHEA_CONTA : VarBasis
                {
                    /*"      15    ARQHEA-AGECONTA        PIC  9(005).*/
                    public IntBasis ARQHEA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    ARQHEA-DIGAGENC        PIC  X(001).*/
                    public StringBasis ARQHEA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    ARQHEA-OPECONTA        PIC  9(004).*/
                    public IntBasis ARQHEA_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    ARQHEA-NUMCONTA        PIC  9(008).*/
                    public IntBasis ARQHEA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      15    ARQHEA-DIGCONTA        PIC  9(001).*/
                    public IntBasis ARQHEA_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    ARQHEA-DIGAGECTA       PIC  X(001).*/
                    public StringBasis ARQHEA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      ARQHEA-NOMEMPRESA      PIC  X(030).*/
                }
                public StringBasis ARQHEA_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        ARQHEA-NOMEBANCO       PIC  X(030).*/
            }
            public StringBasis ARQHEA_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05        FILLER                 PIC  X(010).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        ARQHEA-ARQUIVO.*/
            public EM8021B_ARQHEA_ARQUIVO ARQHEA_ARQUIVO { get; set; } = new EM8021B_ARQHEA_ARQUIVO();
            public class EM8021B_ARQHEA_ARQUIVO : VarBasis
            {
                /*"    10      ARQHEA-REMESSA         PIC  9(001).*/
                public IntBasis ARQHEA_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10      ARQHEA-DATAGERACAO.*/
                public EM8021B_ARQHEA_DATAGERACAO ARQHEA_DATAGERACAO { get; set; } = new EM8021B_ARQHEA_DATAGERACAO();
                public class EM8021B_ARQHEA_DATAGERACAO : VarBasis
                {
                    /*"      15    ARQHEA-DIAGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_DIAGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    ARQHEA-MESGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_MESGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    ARQHEA-ANOGERA         PIC  9(004).*/
                    public IntBasis ARQHEA_ANOGERA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      ARQHEA-HORAGERACAO.*/
                }
                public EM8021B_ARQHEA_HORAGERACAO ARQHEA_HORAGERACAO { get; set; } = new EM8021B_ARQHEA_HORAGERACAO();
                public class EM8021B_ARQHEA_HORAGERACAO : VarBasis
                {
                    /*"      15    ARQHEA-HORGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_HORGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    ARQHEA-MINGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_MINGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    ARQHEA-SEGGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_SEGGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10      ARQHEA-NSA             PIC  9(006).*/
                }
                public IntBasis ARQHEA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQHEA-VERSAO          PIC  9(003).*/
                public IntBasis ARQHEA_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      ARQHEA-DENSIDADE       PIC  9(005).*/
                public IntBasis ARQHEA_DENSIDADE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  05        ARQHEA-USOBANCO        PIC  X(020).*/
            }
            public StringBasis ARQHEA_USOBANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        ARQHEA-USOEMPRESA      PIC  X(020).*/
            public StringBasis ARQHEA_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        ARQHEA-USOFEBRABAN     PIC  X(011).*/
            public StringBasis ARQHEA_USOFEBRABAN { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
            /*"  05        ARQHEA-IDECOBRANCA     PIC  X(003).*/
            public StringBasis ARQHEA_IDECOBRANCA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05        ARQHEA-USOEXCLUSVAN    PIC  9(003).*/
            public IntBasis ARQHEA_USOEXCLUSVAN { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05        ARQHEA-TIPOSER         PIC  X(002).*/
            public StringBasis ARQHEA_TIPOSER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        FILLER                 PIC  X(010).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          ARQTRA-REGISTRO.*/
        }
        public EM8021B_ARQTRA_REGISTRO ARQTRA_REGISTRO { get; set; } = new EM8021B_ARQTRA_REGISTRO();
        public class EM8021B_ARQTRA_REGISTRO : VarBasis
        {
            /*"  05        ARQTRA-CONTROLE.*/
            public EM8021B_ARQTRA_CONTROLE ARQTRA_CONTROLE { get; set; } = new EM8021B_ARQTRA_CONTROLE();
            public class EM8021B_ARQTRA_CONTROLE : VarBasis
            {
                /*"    10      ARQTRA-BANCO           PIC  9(003).*/
                public IntBasis ARQTRA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      ARQTRA-LOTSER          PIC  9(004).*/
                public IntBasis ARQTRA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      ARQTRA-TIPOREG         PIC  9(001).*/
                public IntBasis ARQTRA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        ARQTRA-TOTAIS.*/
            public EM8021B_ARQTRA_TOTAIS ARQTRA_TOTAIS { get; set; } = new EM8021B_ARQTRA_TOTAIS();
            public class EM8021B_ARQTRA_TOTAIS : VarBasis
            {
                /*"    10      ARQTRA-QTDELOTE        PIC  9(006).*/
                public IntBasis ARQTRA_QTDELOTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQTRA-QTDEREG         PIC  9(006).*/
                public IntBasis ARQTRA_QTDEREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQTRA-QTDECONTA       PIC  9(006).*/
                public IntBasis ARQTRA_QTDECONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05        FILLER                 PIC  X(205).*/
            }
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "205", "X(205)."), @"");
            /*"01          LOTHEA-REGISTRO.*/
        }
        public EM8021B_LOTHEA_REGISTRO LOTHEA_REGISTRO { get; set; } = new EM8021B_LOTHEA_REGISTRO();
        public class EM8021B_LOTHEA_REGISTRO : VarBasis
        {
            /*"  05        LOTHEA-CONTROLE.*/
            public EM8021B_LOTHEA_CONTROLE LOTHEA_CONTROLE { get; set; } = new EM8021B_LOTHEA_CONTROLE();
            public class EM8021B_LOTHEA_CONTROLE : VarBasis
            {
                /*"    10      LOTHEA-BANCO           PIC  9(003).*/
                public IntBasis LOTHEA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      LOTHEA-LOTSER          PIC  9(004).*/
                public IntBasis LOTHEA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTHEA-TIPOREG         PIC  9(001).*/
                public IntBasis LOTHEA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        LOTHEA-SERVICO.*/
            }
            public EM8021B_LOTHEA_SERVICO LOTHEA_SERVICO { get; set; } = new EM8021B_LOTHEA_SERVICO();
            public class EM8021B_LOTHEA_SERVICO : VarBasis
            {
                /*"    10      LOTHEA-OPERACAO        PIC  X(001).*/
                public StringBasis LOTHEA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      LOTHEA-TIPSER          PIC  9(002).*/
                public IntBasis LOTHEA_TIPSER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      LOTHEA-FORMA           PIC  9(002).*/
                public IntBasis LOTHEA_FORMA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      LOTHEA-VERSAO          PIC  9(003).*/
                public IntBasis LOTHEA_VERSAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05        FILLER                 PIC  X(001).*/
            }
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05        LOTHEA-EMPRESA.*/
            public EM8021B_LOTHEA_EMPRESA LOTHEA_EMPRESA { get; set; } = new EM8021B_LOTHEA_EMPRESA();
            public class EM8021B_LOTHEA_EMPRESA : VarBasis
            {
                /*"    10      LOTHEA-INSCRICAO.*/
                public EM8021B_LOTHEA_INSCRICAO LOTHEA_INSCRICAO { get; set; } = new EM8021B_LOTHEA_INSCRICAO();
                public class EM8021B_LOTHEA_INSCRICAO : VarBasis
                {
                    /*"      15    LOTHEA-TIPINSC         PIC  9(001).*/
                    public IntBasis LOTHEA_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LOTHEA-NROINSC         PIC  9(014).*/
                    public IntBasis LOTHEA_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    10      LOTHEA-CONVENIO        PIC  9(006).*/
                }
                public IntBasis LOTHEA_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      LOTHEA-TIPCOMPROM      PIC  9(002).*/
                public IntBasis LOTHEA_TIPCOMPROM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      LOTHEA-CODCOMPROM      PIC  9(004).*/
                public IntBasis LOTHEA_CODCOMPROM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTHEA-TRANSMIS        PIC  X(002).*/
                public StringBasis LOTHEA_TRANSMIS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10      FILLER                 PIC  X(006).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                /*"    10      LOTHEA-CONTA.*/
                public EM8021B_LOTHEA_CONTA LOTHEA_CONTA { get; set; } = new EM8021B_LOTHEA_CONTA();
                public class EM8021B_LOTHEA_CONTA : VarBasis
                {
                    /*"      15    LOTHEA-AGECONTA        PIC  9(005).*/
                    public IntBasis LOTHEA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    LOTHEA-DIGAGENC        PIC  X(001).*/
                    public StringBasis LOTHEA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LOTHEA-OPECONTA        PIC  9(004).*/
                    public IntBasis LOTHEA_OPECONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    LOTHEA-NUMCONTA        PIC  9(008).*/
                    public IntBasis LOTHEA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"      15    LOTHEA-DIGCONTA        PIC  9(001).*/
                    public IntBasis LOTHEA_DIGCONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LOTHEA-DIGAGECTA       PIC  X(001).*/
                    public StringBasis LOTHEA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      LOTHEA-NOMEMPRESA      PIC  X(030).*/
                }
                public StringBasis LOTHEA_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        LOTHEA-MENSAGEM        PIC  X(040).*/
            }
            public StringBasis LOTHEA_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        LOTHEA-ENDERECO.*/
            public EM8021B_LOTHEA_ENDERECO LOTHEA_ENDERECO { get; set; } = new EM8021B_LOTHEA_ENDERECO();
            public class EM8021B_LOTHEA_ENDERECO : VarBasis
            {
                /*"    10      LOTHEA-LOGRADOURO      PIC  X(030).*/
                public StringBasis LOTHEA_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    10      LOTHEA-NUMERO          PIC  9(005).*/
                public IntBasis LOTHEA_NUMERO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      LOTHEA-COMPLOGRA       PIC  X(015).*/
                public StringBasis LOTHEA_COMPLOGRA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    10      LOTHEA-CIDADE          PIC  X(020).*/
                public StringBasis LOTHEA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10      LOTHEA-CEP             PIC  9(005).*/
                public IntBasis LOTHEA_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      LOTHEA-COMPLCEP        PIC  X(003).*/
                public StringBasis LOTHEA_COMPLCEP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10      LOTHEA-SIGLAUF         PIC  X(002).*/
                public StringBasis LOTHEA_SIGLAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05        FILLER                 PIC  X(008).*/
            }
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        LOTHEA-OCORRENCIA      PIC  X(010).*/
            public StringBasis LOTHEA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          LOTTRA-REGISTRO.*/
        }
        public EM8021B_LOTTRA_REGISTRO LOTTRA_REGISTRO { get; set; } = new EM8021B_LOTTRA_REGISTRO();
        public class EM8021B_LOTTRA_REGISTRO : VarBasis
        {
            /*"  05        LOTTRA-CONTROLE.*/
            public EM8021B_LOTTRA_CONTROLE LOTTRA_CONTROLE { get; set; } = new EM8021B_LOTTRA_CONTROLE();
            public class EM8021B_LOTTRA_CONTROLE : VarBasis
            {
                /*"    10      LOTTRA-BANCO           PIC  9(003).*/
                public IntBasis LOTTRA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      LOTTRA-LOTSER          PIC  9(004).*/
                public IntBasis LOTTRA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTTRA-TIPOREG         PIC  9(001).*/
                public IntBasis LOTTRA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        LOTTRA-TOTAIS.*/
            public EM8021B_LOTTRA_TOTAIS LOTTRA_TOTAIS { get; set; } = new EM8021B_LOTTRA_TOTAIS();
            public class EM8021B_LOTTRA_TOTAIS : VarBasis
            {
                /*"    10      LOTTRA-QTDEREG         PIC  9(006).*/
                public IntBasis LOTTRA_QTDEREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      LOTTRA-VALOR           PIC  9(016)V99.*/
                public DoubleBasis LOTTRA_VALOR { get; set; } = new DoubleBasis(new PIC("9", "16", "9(016)V99."), 2);
                /*"    10      LOTTRA-QTDEMOEDA       PIC  9(013)V99999.*/
                public DoubleBasis LOTTRA_QTDEMOEDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99999."), 5);
                /*"  05        LOTTRA-NRAVISO         PIC  9(006).*/
            }
            public IntBasis LOTTRA_NRAVISO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05        FILLER                 PIC  X(165).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "165", "X(165)."), @"");
            /*"  05        LOTTRA-OCORRENCIA      PIC  X(010).*/
            public StringBasis LOTTRA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          DETSEGA-REGISTRO.*/
        }
        public EM8021B_DETSEGA_REGISTRO DETSEGA_REGISTRO { get; set; } = new EM8021B_DETSEGA_REGISTRO();
        public class EM8021B_DETSEGA_REGISTRO : VarBasis
        {
            /*"  05        DETSEGA-CONTROLE.*/
            public EM8021B_DETSEGA_CONTROLE DETSEGA_CONTROLE { get; set; } = new EM8021B_DETSEGA_CONTROLE();
            public class EM8021B_DETSEGA_CONTROLE : VarBasis
            {
                /*"    10      DETSEGA-BANCO          PIC  9(003).*/
                public IntBasis DETSEGA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGA-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGA-SERVICO.*/
            }
            public EM8021B_DETSEGA_SERVICO DETSEGA_SERVICO { get; set; } = new EM8021B_DETSEGA_SERVICO();
            public class EM8021B_DETSEGA_SERVICO : VarBasis
            {
                /*"    10      DETSEGA-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGA_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGA-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGA_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DETSEGA-MOVIMENTO.*/
                public EM8021B_DETSEGA_MOVIMENTO DETSEGA_MOVIMENTO { get; set; } = new EM8021B_DETSEGA_MOVIMENTO();
                public class EM8021B_DETSEGA_MOVIMENTO : VarBasis
                {
                    /*"      15    DETSEGA-TIPOMOV        PIC  9(001).*/
                    public IntBasis DETSEGA_TIPOMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    DETSEGA-INSTRUCAO      PIC  9(002).*/
                    public IntBasis DETSEGA_INSTRUCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05        DETSEGA-FAVORECIDO.*/
                }
            }
            public EM8021B_DETSEGA_FAVORECIDO DETSEGA_FAVORECIDO { get; set; } = new EM8021B_DETSEGA_FAVORECIDO();
            public class EM8021B_DETSEGA_FAVORECIDO : VarBasis
            {
                /*"    10      DETSEGA-CAMARA         PIC  9(003).*/
                public IntBasis DETSEGA_CAMARA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-BANCOFAV       PIC  9(003).*/
                public IntBasis DETSEGA_BANCOFAV { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-CONTA.*/
                public EM8021B_DETSEGA_CONTA DETSEGA_CONTA { get; set; } = new EM8021B_DETSEGA_CONTA();
                public class EM8021B_DETSEGA_CONTA : VarBasis
                {
                    /*"      15    DETSEGA-AGECONTA       PIC  9(005).*/
                    public IntBasis DETSEGA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    DETSEGA-DIGAGENC       PIC  X(001).*/
                    public StringBasis DETSEGA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    DETSEGA-NUMCONTA       PIC  9(012).*/
                    public IntBasis DETSEGA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15    DETSEGA-DIGCONTA       PIC  X(001).*/
                    public StringBasis DETSEGA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    DETSEGA-DIGAGECTA      PIC  X(001).*/
                    public StringBasis DETSEGA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      DETSEGA-NOMEFAV        PIC  X(030).*/
                }
                public StringBasis DETSEGA_NOMEFAV { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        DETSEGA-CREDITO.*/
            }
            public EM8021B_DETSEGA_CREDITO DETSEGA_CREDITO { get; set; } = new EM8021B_DETSEGA_CREDITO();
            public class EM8021B_DETSEGA_CREDITO : VarBasis
            {
                /*"    10      DETSEGA-NROEMPRE.*/
                public EM8021B_DETSEGA_NROEMPRE DETSEGA_NROEMPRE { get; set; } = new EM8021B_DETSEGA_NROEMPRE();
                public class EM8021B_DETSEGA_NROEMPRE : VarBasis
                {
                    /*"      15    DETSEGA-NRSEQ01        PIC  9(006).*/
                    public IntBasis DETSEGA_NRSEQ01 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                    /*"      15    DETSEGA-NRSEQ02        PIC  X(013).*/
                    public StringBasis DETSEGA_NRSEQ02 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                    /*"      15    DETSEGA-TIPCTA         PIC  X(001).*/
                    public StringBasis DETSEGA_TIPCTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      DETSEGA-DATAPAGTO.*/
                }
                public EM8021B_DETSEGA_DATAPAGTO DETSEGA_DATAPAGTO { get; set; } = new EM8021B_DETSEGA_DATAPAGTO();
                public class EM8021B_DETSEGA_DATAPAGTO : VarBasis
                {
                    /*"      15    DETSEGA-DIAPAG         PIC  9(002).*/
                    public IntBasis DETSEGA_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-MESPAG         PIC  9(002).*/
                    public IntBasis DETSEGA_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-ANOPAG         PIC  9(004).*/
                    public IntBasis DETSEGA_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      DETSEGA-MOEDA.*/
                }
                public EM8021B_DETSEGA_MOEDA DETSEGA_MOEDA { get; set; } = new EM8021B_DETSEGA_MOEDA();
                public class EM8021B_DETSEGA_MOEDA : VarBasis
                {
                    /*"      15    DETSEGA-TIPOMOEDA      PIC  X(003).*/
                    public StringBasis DETSEGA_TIPOMOEDA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"      15    DETSEGA-QTDEMOEDA      PIC  9(010)V99999.*/
                    public DoubleBasis DETSEGA_QTDEMOEDA { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99999."), 5);
                    /*"    10      DETSEGA-VALPAGTO       PIC  9(013)V99.*/
                }
                public DoubleBasis DETSEGA_VALPAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10      DETSEGA-NUMDOCBANCO    PIC  9(009).*/
                public IntBasis DETSEGA_NUMDOCBANCO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10      FILLER                 PIC  X(003).*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10      DETSEGA-QTDPARCELA     PIC  9(002).*/
                public IntBasis DETSEGA_QTDPARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DETSEGA-INDBLOQUEIO    PIC  X(001).*/
                public StringBasis DETSEGA_INDBLOQUEIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DETSEGA-INDFORMA       PIC  9(001).*/
                public IntBasis DETSEGA_INDFORMA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10      DETSEGA-DIAVENCTO      PIC  X(002).*/
                public StringBasis DETSEGA_DIAVENCTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    10      DETSEGA-NUMPARCELA     PIC  9(002).*/
                public IntBasis DETSEGA_NUMPARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DETSEGA-DATAREAL.*/
                public EM8021B_DETSEGA_DATAREAL DETSEGA_DATAREAL { get; set; } = new EM8021B_DETSEGA_DATAREAL();
                public class EM8021B_DETSEGA_DATAREAL : VarBasis
                {
                    /*"      15    DETSEGA-DIAREA         PIC  9(002).*/
                    public IntBasis DETSEGA_DIAREA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-MESREA         PIC  9(002).*/
                    public IntBasis DETSEGA_MESREA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-ANOREA         PIC  9(004).*/
                    public IntBasis DETSEGA_ANOREA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      DETSEGA-VALREAL        PIC  9(013)V99.*/
                }
                public DoubleBasis DETSEGA_VALREAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"  05        DETSEGA-INFORMA        PIC  X(040).*/
            }
            public StringBasis DETSEGA_INFORMA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        DETSEGA-CODFINAL       PIC  X(002).*/
            public StringBasis DETSEGA_CODFINAL { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        FILLER                 PIC  X(010).*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        DETSEGA-AVISO          PIC  9(001).*/
            public IntBasis DETSEGA_AVISO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05        DETSEGA-OCORRENCIA     PIC  X(010).*/
            public StringBasis DETSEGA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          DETSEGB-REGISTRO.*/
        }
        public EM8021B_DETSEGB_REGISTRO DETSEGB_REGISTRO { get; set; } = new EM8021B_DETSEGB_REGISTRO();
        public class EM8021B_DETSEGB_REGISTRO : VarBasis
        {
            /*"  05        DETSEGB-CONTROLE.*/
            public EM8021B_DETSEGB_CONTROLE DETSEGB_CONTROLE { get; set; } = new EM8021B_DETSEGB_CONTROLE();
            public class EM8021B_DETSEGB_CONTROLE : VarBasis
            {
                /*"    10      DETSEGB-BANCO          PIC  9(003).*/
                public IntBasis DETSEGB_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGB-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGB_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGB-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGB_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGB-SERVICO.*/
            }
            public EM8021B_DETSEGB_SERVICO DETSEGB_SERVICO { get; set; } = new EM8021B_DETSEGB_SERVICO();
            public class EM8021B_DETSEGB_SERVICO : VarBasis
            {
                /*"    10      DETSEGB-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGB_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGB-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGB_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05        FILLER                 PIC  X(003).*/
            }
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05        DETSEGB-COMPLEMENTO.*/
            public EM8021B_DETSEGB_COMPLEMENTO DETSEGB_COMPLEMENTO { get; set; } = new EM8021B_DETSEGB_COMPLEMENTO();
            public class EM8021B_DETSEGB_COMPLEMENTO : VarBasis
            {
                /*"    10      DETSEGB-FAVORECIDO.*/
                public EM8021B_DETSEGB_FAVORECIDO DETSEGB_FAVORECIDO { get; set; } = new EM8021B_DETSEGB_FAVORECIDO();
                public class EM8021B_DETSEGB_FAVORECIDO : VarBasis
                {
                    /*"      15    DETSEGB-INSCRICAO.*/
                    public EM8021B_DETSEGB_INSCRICAO DETSEGB_INSCRICAO { get; set; } = new EM8021B_DETSEGB_INSCRICAO();
                    public class EM8021B_DETSEGB_INSCRICAO : VarBasis
                    {
                        /*"        20  DETSEGB-TIPINSC        PIC  9(001).*/
                        public IntBasis DETSEGB_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                        /*"        20  DETSEGB-NROINSC        PIC  9(014).*/
                        public IntBasis DETSEGB_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                        /*"      15    DETSEGB-LOGRADOURO     PIC  X(030).*/
                    }
                    public StringBasis DETSEGB_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                    /*"      15    DETSEGB-NUMERO         PIC  9(005).*/
                    public IntBasis DETSEGB_NUMERO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    DETSEGB-COMPLOGRA      PIC  X(015).*/
                    public StringBasis DETSEGB_COMPLOGRA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"      15    DETSEGB-BAIRRO         PIC  X(015).*/
                    public StringBasis DETSEGB_BAIRRO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"      15    DETSEGB-CIDADE         PIC  X(020).*/
                    public StringBasis DETSEGB_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                    /*"      15    DETSEGB-CEP            PIC  X(008).*/
                    public StringBasis DETSEGB_CEP { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"      15    DETSEGB-SIGLAUF        PIC  X(002).*/
                    public StringBasis DETSEGB_SIGLAUF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"    10      DETSEGB-PAGTO.*/
                }
                public EM8021B_DETSEGB_PAGTO DETSEGB_PAGTO { get; set; } = new EM8021B_DETSEGB_PAGTO();
                public class EM8021B_DETSEGB_PAGTO : VarBasis
                {
                    /*"      15    DETSEGB-DATAVENCTO.*/
                    public EM8021B_DETSEGB_DATAVENCTO DETSEGB_DATAVENCTO { get; set; } = new EM8021B_DETSEGB_DATAVENCTO();
                    public class EM8021B_DETSEGB_DATAVENCTO : VarBasis
                    {
                        /*"        20  DETSEGB-DIAVEN         PIC  9(002).*/
                        public IntBasis DETSEGB_DIAVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        20  DETSEGB-MESVEN         PIC  9(002).*/
                        public IntBasis DETSEGB_MESVEN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"        20  DETSEGB-ANOVEN         PIC  9(004).*/
                        public IntBasis DETSEGB_ANOVEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"      15    DETSEGB-VALNOMIN       PIC  9(013)V99.*/
                    }
                    public DoubleBasis DETSEGB_VALNOMIN { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALABAT        PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALABAT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALDESC        PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALDESC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALMORA        PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALMORA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"      15    DETSEGB-VALMULTA       PIC  9(013)V99.*/
                    public DoubleBasis DETSEGB_VALMULTA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                    /*"    10      DETSEGB-DOCFAV         PIC  X(015).*/
                }
                public StringBasis DETSEGB_DOCFAV { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05        FILLER                 PIC  X(015).*/
            }
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"01        REG-SIACC.*/
        }
        public EM8021B_REG_SIACC REG_SIACC { get; set; } = new EM8021B_REG_SIACC();
        public class EM8021B_REG_SIACC : VarBasis
        {
            /*"  05      SIACC-TIPO-ARQUIVO       PIC  X(010).*/
            public StringBasis SIACC_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SIACC-ORIGEM-EMPRESA     PIC  X(004).*/
            public StringBasis SIACC_ORIGEM_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      SIACC-IDLG               PIC  X(040).*/
            public StringBasis SIACC_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05      SIACC-CONVENIO           PIC  9(006).*/
            public IntBasis SIACC_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SIACC-NSA-BANCO          PIC  9(006).*/
            public IntBasis SIACC_NSA_BANCO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      SIACC-CPF-CNPJ           PIC  X(020).*/
            public StringBasis SIACC_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05      SIACC-EVENTO             PIC  X(010).*/
            public StringBasis SIACC_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SIACC-VALOR-BRUTO        PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-IRRF         PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_IRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-ISS          PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_ISS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-INSS         PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_INSS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-COFINS       PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_COFINS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-CSLL         PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_CSLL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-PIS          PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_PIS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-VALOR-PAGTO        PIC  9(013)V99.*/
            public DoubleBasis SIACC_VALOR_PAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      SIACC-DT-CRE-DIA         PIC  9(002).*/
            public IntBasis SIACC_DT_CRE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SIACC-DT-CRE-MES         PIC  9(002).*/
            public IntBasis SIACC_DT_CRE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SIACC-DT-CRE-ANO         PIC  9(004).*/
            public IntBasis SIACC_DT_CRE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SIACC-DT-ENV-DIA         PIC  9(002).*/
            public IntBasis SIACC_DT_ENV_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SIACC-DT-ENV-MES         PIC  9(002).*/
            public IntBasis SIACC_DT_ENV_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SIACC-DT-ENV-ANO         PIC  9(004).*/
            public IntBasis SIACC_DT_ENV_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SIACC-DT-CON-DIA         PIC  9(002).*/
            public IntBasis SIACC_DT_CON_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SIACC-DT-CON-MES         PIC  9(002).*/
            public IntBasis SIACC_DT_CON_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      SIACC-DT-CON-ANO         PIC  9(004).*/
            public IntBasis SIACC_DT_CON_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SIACC-MEIO-PAGTO         PIC  X(001).*/
            public StringBasis SIACC_MEIO_PAGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      SIACC-NUM-CHEQUE         PIC  9(013).*/
            public IntBasis SIACC_NUM_CHEQUE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      SIACC-NUM-SIVAT          PIC  9(009).*/
            public IntBasis SIACC_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      SIACC-OCORRENCIA         PIC  X(010).*/
            public StringBasis SIACC_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.FORNECED FORNECED { get; set; } = new Dclgens.FORNECED();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.RALCHEDO RALCHEDO { get; set; } = new Dclgens.RALCHEDO();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINCREIN SINCREIN { get; set; } = new Dclgens.SINCREIN();
        public Dclgens.APOLICRE APOLICRE { get; set; } = new Dclgens.APOLICRE();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SINIPENH SINIPENH { get; set; } = new Dclgens.SINIPENH();
        public Dclgens.SINIHAB1 SINIHAB1 { get; set; } = new Dclgens.SINIHAB1();
        public Dclgens.MOVSINIH MOVSINIH { get; set; } = new Dclgens.MOVSINIH();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SEM8021B_FILE_NAME_P, string MOVIMENTO_FILE_NAME_P, string MOV043350_CC_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SEM8021B.SetFile(SEM8021B_FILE_NAME_P);
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);
                MOV043350_CC.SetFile(MOV043350_CC_FILE_NAME_P);

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
            /*" -539- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -540- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -542- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -544- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -550- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -558- SORT SEM8021B ON ASCENDING KEY SCB1-SEQSORT SCB1-OCORR-MOVTO INPUT PROCEDURE R0200-00-SELECIONA THRU R0200-99-SAIDA OUTPUT PROCEDURE R0700-00-PROCESSA-SORT THRU R0700-99-SAIDA. */
            SEM8021B.Sort("SCB1-SEQSORT,SCB1-OCORR-MOVTO", () => R0200_00_SELECIONA_SECTION(), () => R0700_00_PROCESSA_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -563- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -569- CLOSE MOVIMENTO MOV043350-CC. */
            MOVIMENTO.Close();
            MOV043350_CC.Close();

            /*" -571- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -572- DISPLAY ' ' */
            _.Display($" ");

            /*" -575- DISPLAY 'EM8021B - FIM NORMAL' . */
            _.Display($"EM8021B - FIM NORMAL");

            /*" -575- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -588- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -589- DISPLAY ' EM8021B - INICIO PROCESSAMENTO ' . */
            _.Display($" EM8021B - INICIO PROCESSAMENTO ");

            /*" -591- DISPLAY ' ' . */
            _.Display($" ");

            /*" -592- OPEN INPUT MOVIMENTO */
            MOVIMENTO.Open(REG_MOVIMENTO);

            /*" -595- OUTPUT MOV043350-CC. */
            MOV043350_CC.Open(REG_MOV043350);

            /*" -598- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -598- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -612- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -622- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -623- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -626- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -628- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -628- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -618- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECIONA-SECTION */
        private void R0200_00_SELECIONA_SECTION()
        {
            /*" -641- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -647- MOVE ZEROS TO LD-ENTRADA LD-MV043350 DP-ENTRADA GV-SORT. */
            _.Move(0, W.LD_ENTRADA, W.LD_MV043350, W.DP_ENTRADA, W.GV_SORT);

            /*" -649- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -651- PERFORM R0210-00-LER-ENTRADA. */

            R0210_00_LER_ENTRADA_SECTION();

            /*" -655- PERFORM R0220-00-PROCESSA-ENTRADA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0220_00_PROCESSA_ENTRADA_SECTION();
            }

            /*" -656- DISPLAY ' ' . */
            _.Display($" ");

            /*" -657- DISPLAY ' LIDOS    ENTRADA ...... ' LD-ENTRADA. */
            _.Display($" LIDOS    ENTRADA ...... {W.LD_ENTRADA}");

            /*" -658- DISPLAY ' DESPREZA ENTRADA ...... ' DP-ENTRADA. */
            _.Display($" DESPREZA ENTRADA ...... {W.DP_ENTRADA}");

            /*" -659- DISPLAY ' LIDOS BANCO BRASIL .... ' LD-MV043350 */
            _.Display($" LIDOS BANCO BRASIL .... {W.LD_MV043350}");

            /*" -660- DISPLAY ' TRATA CHEQUE .......... ' TT-CHEQUE */
            _.Display($" TRATA CHEQUE .......... {W.TT_CHEQUE}");

            /*" -661- DISPLAY ' TRATA SINISTRO ........ ' TT-SINISTRO */
            _.Display($" TRATA SINISTRO ........ {W.TT_SINISTRO}");

            /*" -662- DISPLAY ' GRAVADOS SORT ......... ' GV-SORT. */
            _.Display($" GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -665- DISPLAY ' ' . */
            _.Display($" ");

            /*" -665- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-ENTRADA-SECTION */
        private void R0210_00_LER_ENTRADA_SECTION()
        {
            /*" -679- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -679- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -681- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -684- GO TO R0210-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, REG_MOVIMENTO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -685- MOVE REG-MOVIMENTO TO REG-SIACC. */
            _.Move(MOVIMENTO?.Value, REG_SIACC);

            /*" -685- ADD 1 TO LD-ENTRADA. */
            W.LD_ENTRADA.Value = W.LD_ENTRADA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-ENTRADA-SECTION */
        private void R0220_00_PROCESSA_ENTRADA_SECTION()
        {
            /*" -698- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -699- IF SIACC-CONVENIO NOT EQUAL 043350 */

            if (REG_SIACC.SIACC_CONVENIO != 043350)
            {

                /*" -700- ADD 1 TO DP-ENTRADA */
                W.DP_ENTRADA.Value = W.DP_ENTRADA + 1;

                /*" -703- GO TO R0220-50-LEITURA. */

                R0220_50_LEITURA(); //GOTO
                return;
            }


            /*" -706- ADD 1 TO LD-MV043350. */
            W.LD_MV043350.Value = W.LD_MV043350 + 1;

            /*" -709- MOVE SIACC-IDLG TO WS-IDLG-CHEQUE WS-IDLG-SINISTRO. */
            _.Move(REG_SIACC.SIACC_IDLG, W.WS_IDLG_CHEQUE, W.WS_IDLG_SINISTRO);

            /*" -711- IF WS-FILLER01 EQUAL '-' AND WS-FILLER02 EQUAL '-' */

            if (W.FILLER_0.WS_FILLER01 == "-" && W.FILLER_0.WS_FILLER02 == "-")
            {

                /*" -712- ADD 1 TO TT-CHEQUE */
                W.TT_CHEQUE.Value = W.TT_CHEQUE + 1;

                /*" -713- PERFORM R0300-00-TRATA-CHEQUE */

                R0300_00_TRATA_CHEQUE_SECTION();

                /*" -714- ELSE */
            }
            else
            {


                /*" -715- ADD 1 TO TT-SINISTRO */
                W.TT_SINISTRO.Value = W.TT_SINISTRO + 1;

                /*" -715- PERFORM R0400-00-TRATA-SINISTRO. */

                R0400_00_TRATA_SINISTRO_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R0220_50_LEITURA */

            R0220_50_LEITURA();

        }

        [StopWatch]
        /*" R0220-50-LEITURA */
        private void R0220_50_LEITURA(bool isPerform = false)
        {
            /*" -720- PERFORM R0210-00-LER-ENTRADA. */

            R0210_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-TRATA-CHEQUE-SECTION */
        private void R0300_00_TRATA_CHEQUE_SECTION()
        {
            /*" -735- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -737- MOVE SIACC-CONVENIO TO MOVDEBCE-COD-CONVENIO. */
            _.Move(REG_SIACC.SIACC_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -739- MOVE WS-IDLG-NUMCHQ TO MOVDEBCE-NUM-APOLICE. */
            _.Move(W.FILLER_0.WS_IDLG_NUMCHQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -743- MOVE '1' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("1", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -744- MOVE SPACES TO WFIM-MOVDEBCE. */
            _.Move("", W.WFIM_MOVDEBCE);

            /*" -747- PERFORM R0310-00-SELECT-V0MOVDEBCE. */

            R0310_00_SELECT_V0MOVDEBCE_SECTION();

            /*" -749- MOVE SPACES TO REG-SEM8021B. */
            _.Move("", REG_SEM8021B);

            /*" -750- MOVE 02 TO SCB1-SEQSORT. */
            _.Move(02, REG_SEM8021B.SCB1_SEQSORT);

            /*" -752- MOVE 'CHEQUE    ' TO SCB1-TIPOREG. */
            _.Move("CHEQUE    ", REG_SEM8021B.SCB1_TIPOREG);

            /*" -754- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -756- MOVE SIACC-DT-CRE-DIA TO WDAT-REL-DIA. */
            _.Move(REG_SIACC.SIACC_DT_CRE_DIA, W.FILLER_3.WDAT_REL_DIA);

            /*" -758- MOVE SIACC-DT-CRE-MES TO WDAT-REL-MES. */
            _.Move(REG_SIACC.SIACC_DT_CRE_MES, W.FILLER_3.WDAT_REL_MES);

            /*" -760- MOVE SIACC-DT-CRE-ANO TO WDAT-REL-ANO. */
            _.Move(REG_SIACC.SIACC_DT_CRE_ANO, W.FILLER_3.WDAT_REL_ANO);

            /*" -762- MOVE WDATA-REL TO SCB1-DTPAGTO. */
            _.Move(W.WDATA_REL, REG_SEM8021B.SCB1_DTPAGTO);

            /*" -764- MOVE SIACC-VALOR-PAGTO TO SCB1-VLPAGTO. */
            _.Move(REG_SIACC.SIACC_VALOR_PAGTO, REG_SEM8021B.SCB1_VLPAGTO);

            /*" -766- MOVE SIACC-NSA-BANCO TO SCB1-NSAC. */
            _.Move(REG_SIACC.SIACC_NSA_BANCO, REG_SEM8021B.SCB1_NSAC);

            /*" -768- MOVE SIACC-NUM-SIVAT TO SCB1-NUM-SIVAT. */
            _.Move(REG_SIACC.SIACC_NUM_SIVAT, REG_SEM8021B.SCB1_NUM_SIVAT);

            /*" -772- MOVE SIACC-IDLG TO SCB1-IDLG. */
            _.Move(REG_SIACC.SIACC_IDLG, REG_SEM8021B.SCB1_IDLG);

            /*" -774- MOVE MOVDEBCE-NUM-APOLICE TO SCB1-NUMAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REG_SEM8021B.SCB1_NUMAPOL);

            /*" -776- MOVE MOVDEBCE-NUM-ENDOSSO TO SCB1-NRENDOS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REG_SEM8021B.SCB1_NRENDOS);

            /*" -778- MOVE MOVDEBCE-NUM-PARCELA TO SCB1-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REG_SEM8021B.SCB1_NRPARCEL);

            /*" -780- MOVE MOVDEBCE-DATA-VENCIMENTO TO SCB1-DTVENCTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, REG_SEM8021B.SCB1_DTVENCTO);

            /*" -782- MOVE MOVDEBCE-COD-AGENCIA-DEB TO SCB1-AGENCIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, REG_SEM8021B.SCB1_AGENCIA);

            /*" -784- MOVE MOVDEBCE-OPER-CONTA-DEB TO SCB1-OPECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, REG_SEM8021B.SCB1_OPECONTA);

            /*" -786- MOVE MOVDEBCE-NUM-CONTA-DEB TO SCB1-NUMCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, REG_SEM8021B.SCB1_NUMCONTA);

            /*" -788- MOVE MOVDEBCE-COD-CONVENIO TO SCB1-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REG_SEM8021B.SCB1_CONVENIO);

            /*" -790- MOVE MOVDEBCE-NSAS TO SCB1-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REG_SEM8021B.SCB1_NSAS);

            /*" -792- MOVE MOVDEBCE-NUM-REQUISICAO TO SCB1-OCORR-MOVTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, REG_SEM8021B.SCB1_OCORR_MOVTO);

            /*" -794- MOVE MOVDEBCE-VLR-CREDITO TO SCB1-VLPREMIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, REG_SEM8021B.SCB1_VLPREMIO);

            /*" -796- MOVE MOVDEBCE-NUM-CARTAO TO SCB1-NUMCHQ. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, REG_SEM8021B.SCB1_NUMCHQ);

            /*" -798- MOVE GE369-COD-BANCO TO SCB1-BANCO. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO, REG_SEM8021B.SCB1_BANCO);

            /*" -800- MOVE GE369-NUM-DV-CONTA-CNB TO SCB1-DIGCONTA. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB, REG_SEM8021B.SCB1_DIGCONTA);

            /*" -802- MOVE GE369-COD-AGENCIA TO SCB1-CODAGENC. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA, REG_SEM8021B.SCB1_CODAGENC);

            /*" -804- MOVE GE369-NUM-CONTA-CNB TO SCB1-CONTACNB. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB, REG_SEM8021B.SCB1_CONTACNB);

            /*" -806- MOVE GE369-IND-CONTA-BANCARIA TO SCB1-INDCONTA. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA, REG_SEM8021B.SCB1_INDCONTA);

            /*" -810- MOVE ZEROS TO SCB1-RAMO SCB1-PRODUTO. */
            _.Move(0, REG_SEM8021B.SCB1_RAMO, REG_SEM8021B.SCB1_PRODUTO);

            /*" -811- MOVE SIACC-OCORRENCIA TO SCB1-COD-RETORNO-BANCO. */
            _.Move(REG_SIACC.SIACC_OCORRENCIA, REG_SEM8021B.SCB1_COD_RETORNO_BANCO);

            /*" -813- MOVE SIACC-NUM-SIVAT TO SCB1-NUM-DOC-BANCO */
            _.Move(REG_SIACC.SIACC_NUM_SIVAT, REG_SEM8021B.SCB1_NUM_DOC_BANCO);

            /*" -815- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -815- RELEASE REG-SEM8021B. */
            SEM8021B.Release(REG_SEM8021B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-V0MOVDEBCE-SECTION */
        private void R0310_00_SELECT_V0MOVDEBCE_SECTION()
        {
            /*" -827- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -876- PERFORM R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1 */

            R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1();

            /*" -880- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -881- MOVE 'S' TO WFIM-MOVDEBCE */
                _.Move("S", W.WFIM_MOVDEBCE);

                /*" -884- GO TO R0310-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;
            }


            /*" -885- IF VIND-NUMREQ LESS ZEROS */

            if (VIND_NUMREQ < 00)
            {

                /*" -888- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
            }


            /*" -889- IF VIND-CARTAO LESS ZEROS */

            if (VIND_CARTAO < 00)
            {

                /*" -893- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


            /*" -894- IF MOVDEBCE-SITUACAO-COBRANCA NOT EQUAL '1' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA != "1")
            {

                /*" -896- DISPLAY 'REG. JA PROCESSADO .. ' WS-IDLG-CHEQUE */
                _.Display($"REG. JA PROCESSADO .. {W.WS_IDLG_CHEQUE}");

                /*" -896- END-IF. */
            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-V0MOVDEBCE-DB-SELECT-1 */
        public void R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1()
        {
            /*" -876- EXEC SQL SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.DATA_VENCIMENTO , A.COD_AGENCIA_DEB , A.OPER_CONTA_DEB , A.NUM_CONTA_DEB , A.COD_CONVENIO , A.NSAS , A.NUM_REQUISICAO , A.VLR_CREDITO , A.NUM_CARTAO , A.SITUACAO_COBRANCA , B.COD_AGENCIA , B.COD_BANCO , B.NUM_CONTA_CNB , B.NUM_DV_CONTA_CNB , B.IND_CONTA_BANCARIA INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO:VIND-NUMREQ , :MOVDEBCE-VLR-CREDITO , :MOVDEBCE-NUM-CARTAO:VIND-CARTAO , :MOVDEBCE-SITUACAO-COBRANCA, :GE369-COD-AGENCIA , :GE369-COD-BANCO , :GE369-NUM-CONTA-CNB , :GE369-NUM-DV-CONTA-CNB , :GE369-IND-CONTA-BANCARIA FROM SEGUROS.MOVTO_DEBITOCC_CEF A, SEGUROS.GE_MOVTO_CONTA B WHERE A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.COD_CONVENIO = B.COD_CONVENIO AND A.NSAS = B.NSAS WITH UR END-EXEC. */

            var r0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 = new R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1.Execute(r0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.VIND_NUMREQ, VIND_NUMREQ);
                _.Move(executed_1.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.GE369_COD_AGENCIA, GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA);
                _.Move(executed_1.GE369_COD_BANCO, GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO);
                _.Move(executed_1.GE369_NUM_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB);
                _.Move(executed_1.GE369_NUM_DV_CONTA_CNB, GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB);
                _.Move(executed_1.GE369_IND_CONTA_BANCARIA, GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-TRATA-SINISTRO-SECTION */
        private void R0400_00_TRATA_SINISTRO_SECTION()
        {
            /*" -911- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -913- MOVE SIACC-CONVENIO TO MOVDEBCE-COD-CONVENIO. */
            _.Move(REG_SIACC.SIACC_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -915- MOVE WS-IDLG-NUMAPOL TO MOVDEBCE-NUM-APOLICE. */
            _.Move(W.FILLER_1.WS_IDLG_NUMAPOL, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -917- MOVE WS-IDLG-OCORHIS TO MOVDEBCE-NUM-PARCELA. */
            _.Move(W.FILLER_1.WS_IDLG_OCORHIS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -921- MOVE '1' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("1", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -922- MOVE SPACES TO WFIM-MOVDEBCE. */
            _.Move("", W.WFIM_MOVDEBCE);

            /*" -925- PERFORM R0410-00-SELECT-V0MOVDEBCE. */

            R0410_00_SELECT_V0MOVDEBCE_SECTION();

            /*" -926- IF WFIM-MOVDEBCE NOT EQUAL SPACES */

            if (!W.WFIM_MOVDEBCE.IsEmpty())
            {

                /*" -927- DISPLAY ' MOVDEBCE DESPREZADO ... ' WS-IDLG-CHEQUE */
                _.Display($" MOVDEBCE DESPREZADO ... {W.WS_IDLG_CHEQUE}");

                /*" -930- GO TO R0400-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;
            }


            /*" -932- MOVE SPACES TO REG-SEM8021B. */
            _.Move("", REG_SEM8021B);

            /*" -933- MOVE 02 TO SCB1-SEQSORT. */
            _.Move(02, REG_SEM8021B.SCB1_SEQSORT);

            /*" -935- MOVE 'SINISTRO  ' TO SCB1-TIPOREG. */
            _.Move("SINISTRO  ", REG_SEM8021B.SCB1_TIPOREG);

            /*" -937- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -939- MOVE SIACC-DT-CRE-DIA TO WDAT-REL-DIA. */
            _.Move(REG_SIACC.SIACC_DT_CRE_DIA, W.FILLER_3.WDAT_REL_DIA);

            /*" -941- MOVE SIACC-DT-CRE-MES TO WDAT-REL-MES. */
            _.Move(REG_SIACC.SIACC_DT_CRE_MES, W.FILLER_3.WDAT_REL_MES);

            /*" -943- MOVE SIACC-DT-CRE-ANO TO WDAT-REL-ANO. */
            _.Move(REG_SIACC.SIACC_DT_CRE_ANO, W.FILLER_3.WDAT_REL_ANO);

            /*" -945- MOVE WDATA-REL TO SCB1-DTPAGTO. */
            _.Move(W.WDATA_REL, REG_SEM8021B.SCB1_DTPAGTO);

            /*" -947- MOVE SIACC-VALOR-PAGTO TO SCB1-VLPAGTO. */
            _.Move(REG_SIACC.SIACC_VALOR_PAGTO, REG_SEM8021B.SCB1_VLPAGTO);

            /*" -949- MOVE SIACC-NSA-BANCO TO SCB1-NSAC. */
            _.Move(REG_SIACC.SIACC_NSA_BANCO, REG_SEM8021B.SCB1_NSAC);

            /*" -951- MOVE SIACC-NUM-SIVAT TO SCB1-NUM-SIVAT. */
            _.Move(REG_SIACC.SIACC_NUM_SIVAT, REG_SEM8021B.SCB1_NUM_SIVAT);

            /*" -955- MOVE SIACC-IDLG TO SCB1-IDLG. */
            _.Move(REG_SIACC.SIACC_IDLG, REG_SEM8021B.SCB1_IDLG);

            /*" -957- MOVE MOVDEBCE-NUM-APOLICE TO SCB1-NUMAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REG_SEM8021B.SCB1_NUMAPOL);

            /*" -959- MOVE MOVDEBCE-NUM-ENDOSSO TO SCB1-NRENDOS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REG_SEM8021B.SCB1_NRENDOS);

            /*" -961- MOVE MOVDEBCE-NUM-PARCELA TO SCB1-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REG_SEM8021B.SCB1_NRPARCEL);

            /*" -963- MOVE MOVDEBCE-DATA-VENCIMENTO TO SCB1-DTVENCTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, REG_SEM8021B.SCB1_DTVENCTO);

            /*" -965- MOVE MOVDEBCE-COD-AGENCIA-DEB TO SCB1-AGENCIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, REG_SEM8021B.SCB1_AGENCIA);

            /*" -967- MOVE MOVDEBCE-OPER-CONTA-DEB TO SCB1-OPECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, REG_SEM8021B.SCB1_OPECONTA);

            /*" -969- MOVE MOVDEBCE-NUM-CONTA-DEB TO SCB1-NUMCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, REG_SEM8021B.SCB1_NUMCONTA);

            /*" -971- MOVE MOVDEBCE-COD-CONVENIO TO SCB1-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REG_SEM8021B.SCB1_CONVENIO);

            /*" -973- MOVE MOVDEBCE-NSAS TO SCB1-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REG_SEM8021B.SCB1_NSAS);

            /*" -975- MOVE MOVDEBCE-NUM-REQUISICAO TO SCB1-OCORR-MOVTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, REG_SEM8021B.SCB1_OCORR_MOVTO);

            /*" -977- MOVE MOVDEBCE-VLR-CREDITO TO SCB1-VLPREMIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, REG_SEM8021B.SCB1_VLPREMIO);

            /*" -979- MOVE RALCHEDO-NUM-CHEQUE-INTERNO TO SCB1-NUMCHQ. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO, REG_SEM8021B.SCB1_NUMCHQ);

            /*" -981- MOVE 104 TO SCB1-BANCO. */
            _.Move(104, REG_SEM8021B.SCB1_BANCO);

            /*" -983- MOVE '000' TO SCB1-DIGCONTA. */
            _.Move("000", REG_SEM8021B.SCB1_DIGCONTA);

            /*" -985- MOVE RALCHEDO-AGENCIA-CONTRATO TO SCB1-CODAGENC. */
            _.Move(RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO, REG_SEM8021B.SCB1_CODAGENC);

            /*" -987- MOVE SPACES TO SCB1-CONTACNB. */
            _.Move("", REG_SEM8021B.SCB1_CONTACNB);

            /*" -989- MOVE ZEROS TO SCB1-INDCONTA. */
            _.Move(0, REG_SEM8021B.SCB1_INDCONTA);

            /*" -991- MOVE SINISMES-RAMO TO SCB1-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, REG_SEM8021B.SCB1_RAMO);

            /*" -994- MOVE SINISMES-COD-PRODUTO TO SCB1-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, REG_SEM8021B.SCB1_PRODUTO);

            /*" -995- MOVE SIACC-OCORRENCIA TO SCB1-COD-RETORNO-BANCO. */
            _.Move(REG_SIACC.SIACC_OCORRENCIA, REG_SEM8021B.SCB1_COD_RETORNO_BANCO);

            /*" -997- MOVE SIACC-NUM-SIVAT TO SCB1-NUM-DOC-BANCO */
            _.Move(REG_SIACC.SIACC_NUM_SIVAT, REG_SEM8021B.SCB1_NUM_DOC_BANCO);

            /*" -999- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -999- RELEASE REG-SEM8021B. */
            SEM8021B.Release(REG_SEM8021B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0410-00-SELECT-V0MOVDEBCE-SECTION */
        private void R0410_00_SELECT_V0MOVDEBCE_SECTION()
        {
            /*" -1011- MOVE '0410' TO WNR-EXEC-SQL. */
            _.Move("0410", W.WABEND.WNR_EXEC_SQL);

            /*" -1057- PERFORM R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1 */

            R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1();

            /*" -1061- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1062- MOVE 'S' TO WFIM-MOVDEBCE */
                _.Move("S", W.WFIM_MOVDEBCE);

                /*" -1065- GO TO R0410-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1066- IF VIND-NUMREQ LESS ZEROS */

            if (VIND_NUMREQ < 00)
            {

                /*" -1069- MOVE ZEROS TO MOVDEBCE-NUM-REQUISICAO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
            }


            /*" -1070- IF VIND-CARTAO LESS ZEROS */

            if (VIND_CARTAO < 00)
            {

                /*" -1071- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO. */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
            }


        }

        [StopWatch]
        /*" R0410-00-SELECT-V0MOVDEBCE-DB-SELECT-1 */
        public void R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1()
        {
            /*" -1057- EXEC SQL SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.DATA_VENCIMENTO , A.COD_AGENCIA_DEB , A.OPER_CONTA_DEB , A.NUM_CONTA_DEB , A.COD_CONVENIO , A.NSAS , A.NUM_REQUISICAO , A.VLR_CREDITO , A.NUM_CARTAO , B.NUM_CHEQUE_INTERNO , B.AGENCIA_CONTRATO , C.RAMO , C.COD_PRODUTO INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO:VIND-NUMREQ , :MOVDEBCE-VLR-CREDITO , :MOVDEBCE-NUM-CARTAO:VIND-CARTAO , :RALCHEDO-NUM-CHEQUE-INTERNO , :RALCHEDO-AGENCIA-CONTRATO , :SINISMES-RAMO , :SINISMES-COD-PRODUTO FROM SEGUROS.MOVTO_DEBITOCC_CEF A, SEGUROS.RALACAO_CHEQ_DOCTO B, SEGUROS.SINISTRO_MESTRE C WHERE A.SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND A.NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND A.NUM_APOLICE = B.NUMDOC_NUM01 AND A.NUM_PARCELA = B.OCORR_HISTORICO AND C.NUM_APOL_SINISTRO = A.NUM_APOLICE AND C.NUM_APOL_SINISTRO = B.NUMDOC_NUM01 WITH UR END-EXEC. */

            var r0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 = new R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
            };

            var executed_1 = R0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1.Execute(r0410_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(executed_1.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(executed_1.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(executed_1.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
                _.Move(executed_1.VIND_NUMREQ, VIND_NUMREQ);
                _.Move(executed_1.MOVDEBCE_VLR_CREDITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO);
                _.Move(executed_1.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
                _.Move(executed_1.RALCHEDO_NUM_CHEQUE_INTERNO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.RALCHEDO_AGENCIA_CONTRATO, RALCHEDO.DCLRALACAO_CHEQ_DOCTO.RALCHEDO_AGENCIA_CONTRATO);
                _.Move(executed_1.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0410_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-SORT-SECTION */
        private void R0700_00_PROCESSA_SORT_SECTION()
        {
            /*" -1082- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1084- DISPLAY '==> INICIO DE PROCESSAMENTO DO ARQUIVO DE SORT <==' . */
            _.Display($"==> INICIO DE PROCESSAMENTO DO ARQUIVO DE SORT <==");

            /*" -1086- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1089- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", W.WABEND.WNR_EXEC_SQL);

            /*" -1093- MOVE ZEROS TO LD-SORT AC-VLRTOTAL. */
            _.Move(0, W.LD_SORT, W.AC_VLRTOTAL);

            /*" -1094- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -1097- PERFORM R0710-00-LER-SORT. */

            R0710_00_LER_SORT_SECTION();

            /*" -1098- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -1099- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' */
                _.Display($"SEM MOVIMENTO NESTA DATA  ");

                /*" -1102- GO TO R0700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1106- MOVE ZEROS TO AC-QTDLOTE AC-QTDREGARQ. */
            _.Move(0, W.AC_QTDLOTE, W.AC_QTDREGARQ);

            /*" -1109- PERFORM R3000-00-HEADER-ARQUIVO. */

            R3000_00_HEADER_ARQUIVO_SECTION();

            /*" -1113- PERFORM R0800-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0800_00_PROCESSA_SORT_SECTION();
            }

            /*" -1116- PERFORM R3100-00-TRAILLER-ARQUIVO. */

            R3100_00_TRAILLER_ARQUIVO_SECTION();

            /*" -1117- DISPLAY ' ' */
            _.Display($" ");

            /*" -1118- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -1119- DISPLAY ' ' */
            _.Display($" ");

            /*" -1120- DISPLAY 'TOTAL LOTES ........... ' AC-QTDLOTE */
            _.Display($"TOTAL LOTES ........... {W.AC_QTDLOTE}");

            /*" -1121- DISPLAY 'TOTAL REGISTROS ....... ' AC-QTDREGARQ */
            _.Display($"TOTAL REGISTROS ....... {W.AC_QTDREGARQ}");

            /*" -1124- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1124- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-LER-SORT-SECTION */
        private void R0710_00_LER_SORT_SECTION()
        {
            /*" -1138- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", W.WABEND.WNR_EXEC_SQL);

            /*" -1140- RETURN SEM8021B AT END */
            try
            {
                SEM8021B.Return(REG_SEM8021B, () =>
                {

                    /*" -1141- MOVE ZEROS TO ATU-SEQSORT */
                    _.Move(0, W.ATU_SEQSORT);

                    /*" -1142- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -1145- GO TO R0710-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1148- MOVE SCB1-SEQSORT TO ATU-SEQSORT. */
            _.Move(REG_SEM8021B.SCB1_SEQSORT, W.ATU_SEQSORT);

            /*" -1148- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-SORT-SECTION */
        private void R0800_00_PROCESSA_SORT_SECTION()
        {
            /*" -1161- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", W.WABEND.WNR_EXEC_SQL);

            /*" -1166- MOVE ZEROS TO AC-NRSEQ AC-QTDREGLOT AC-VLRTOTCRE. */
            _.Move(0, W.AC_NRSEQ, W.AC_QTDREGLOT, W.AC_VLRTOTCRE);

            /*" -1169- PERFORM R3200-00-HEADER-LOTE. */

            R3200_00_HEADER_LOTE_SECTION();

            /*" -1171- MOVE ATU-SEQSORT TO ANT-SEQSORT. */
            _.Move(W.ATU_SEQSORT, W.ANT_SEQSORT);

            /*" -1176- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL ATU-SEQSORT NOT EQUAL ANT-SEQSORT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_SEQSORT != W.ANT_SEQSORT || !W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1176- PERFORM R3300-00-TRAILLER-LOTE. */

            R3300_00_TRAILLER_LOTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1192- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1198- PERFORM R1400-00-SEGMENTO-A. */

            R1400_00_SEGMENTO_A_SECTION();

            /*" -1198- PERFORM R1500-00-SEGMENTO-B. */

            R1500_00_SEGMENTO_B_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1203- PERFORM R0710-00-LER-SORT. */

            R0710_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SEGMENTO-A-SECTION */
        private void R1400_00_SEGMENTO_A_SECTION()
        {
            /*" -1215- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", W.WABEND.WNR_EXEC_SQL);

            /*" -1219- ADD 1 TO AC-NRSEQ AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_NRSEQ.Value = W.AC_NRSEQ + 1;
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1222- MOVE SPACES TO DETSEGA-REGISTRO. */
            _.Move("", DETSEGA_REGISTRO);

            /*" -1224- MOVE 104 TO DETSEGA-BANCO. */
            _.Move(104, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_BANCO);

            /*" -1226- MOVE AC-QTDLOTE TO DETSEGA-LOTSER. */
            _.Move(W.AC_QTDLOTE, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_LOTSER);

            /*" -1228- MOVE 3 TO DETSEGA-TIPOREG. */
            _.Move(3, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_TIPOREG);

            /*" -1230- MOVE AC-NRSEQ TO DETSEGA-NUMREG. */
            _.Move(W.AC_NRSEQ, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_NUMREG);

            /*" -1232- MOVE 'A' TO DETSEGA-SEGMENTO. */
            _.Move("A", DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_SEGMENTO);

            /*" -1234- MOVE ZEROS TO DETSEGA-TIPOMOV. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_MOVIMENTO.DETSEGA_TIPOMOV);

            /*" -1236- MOVE ZEROS TO DETSEGA-INSTRUCAO. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_MOVIMENTO.DETSEGA_INSTRUCAO);

            /*" -1239- MOVE 700 TO DETSEGA-CAMARA. */
            _.Move(700, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CAMARA);

            /*" -1241- MOVE SCB1-BANCO TO DETSEGA-BANCOFAV. */
            _.Move(REG_SEM8021B.SCB1_BANCO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_BANCOFAV);

            /*" -1243- MOVE '0' TO DETSEGA-DIGAGENC. */
            _.Move("0", DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGAGENC);

            /*" -1245- MOVE ZEROS TO DETSEGA-NUMCONTA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_NUMCONTA);

            /*" -1247- MOVE '0' TO DETSEGA-DIGCONTA. */
            _.Move("0", DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

            /*" -1249- MOVE SPACES TO DETSEGA-DIGAGECTA. */
            _.Move("", DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGAGECTA);

            /*" -1252- MOVE AC-NRSEQ TO DETSEGA-NRSEQ01. */
            _.Move(W.AC_NRSEQ, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NROEMPRE.DETSEGA_NRSEQ01);

            /*" -1253- MOVE SCB1-DTPAGTO TO WDATA-REL. */
            _.Move(REG_SEM8021B.SCB1_DTPAGTO, W.WDATA_REL);

            /*" -1256- MOVE WDAT-REL-DIA TO DETSEGA-DIAREA DETSEGA-DIAPAG. */
            _.Move(W.FILLER_3.WDAT_REL_DIA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_DIAREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_DIAPAG);

            /*" -1259- MOVE WDAT-REL-MES TO DETSEGA-MESREA DETSEGA-MESPAG. */
            _.Move(W.FILLER_3.WDAT_REL_MES, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_MESREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_MESPAG);

            /*" -1263- MOVE WDAT-REL-ANO TO DETSEGA-ANOREA DETSEGA-ANOPAG. */
            _.Move(W.FILLER_3.WDAT_REL_ANO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_ANOREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_ANOPAG);

            /*" -1265- MOVE 'BRL' TO DETSEGA-TIPOMOEDA. */
            _.Move("BRL", DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_MOEDA.DETSEGA_TIPOMOEDA);

            /*" -1267- MOVE ZEROS TO DETSEGA-QTDEMOEDA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_MOEDA.DETSEGA_QTDEMOEDA);

            /*" -1270- MOVE SCB1-VLPAGTO TO DETSEGA-VALREAL DETSEGA-VALPAGTO. */
            _.Move(REG_SEM8021B.SCB1_VLPAGTO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALREAL, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALPAGTO);

            /*" -1274- ADD SCB1-VLPAGTO TO AC-VLRTOTCRE AC-VLRTOTAL. */
            W.AC_VLRTOTCRE.Value = W.AC_VLRTOTCRE + REG_SEM8021B.SCB1_VLPAGTO;
            W.AC_VLRTOTAL.Value = W.AC_VLRTOTAL + REG_SEM8021B.SCB1_VLPAGTO;

            /*" -1276- MOVE 01 TO DETSEGA-QTDPARCELA. */
            _.Move(01, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_QTDPARCELA);

            /*" -1278- MOVE 'N' TO DETSEGA-INDBLOQUEIO. */
            _.Move("N", DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_INDBLOQUEIO);

            /*" -1280- MOVE ZEROS TO DETSEGA-INDFORMA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_INDFORMA);

            /*" -1282- MOVE WDAT-REL-DIA TO DETSEGA-DIAVENCTO. */
            _.Move(W.FILLER_3.WDAT_REL_DIA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DIAVENCTO);

            /*" -1284- MOVE ZEROS TO DETSEGA-NUMPARCELA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NUMPARCELA);

            /*" -1286- MOVE SCB1-IDLG TO DETSEGA-INFORMA. */
            _.Move(REG_SEM8021B.SCB1_IDLG, DETSEGA_REGISTRO.DETSEGA_INFORMA);

            /*" -1288- MOVE '00' TO DETSEGA-CODFINAL. */
            _.Move("00", DETSEGA_REGISTRO.DETSEGA_CODFINAL);

            /*" -1292- MOVE ZEROS TO DETSEGA-AVISO. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_AVISO);

            /*" -1295- MOVE SCB1-COD-RETORNO-BANCO TO DETSEGA-OCORRENCIA. */
            _.Move(REG_SEM8021B.SCB1_COD_RETORNO_BANCO, DETSEGA_REGISTRO.DETSEGA_OCORRENCIA);

            /*" -1297- MOVE SCB1-NUM-DOC-BANCO TO DETSEGA-NUMDOCBANCO */
            _.Move(REG_SEM8021B.SCB1_NUM_DOC_BANCO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NUMDOCBANCO);

            /*" -1298- IF SCB1-TIPOREG EQUAL 'CHEQUE' */

            if (REG_SEM8021B.SCB1_TIPOREG == "CHEQUE")
            {

                /*" -1300- MOVE SCB1-CODAGENC TO DETSEGA-AGECONTA */
                _.Move(REG_SEM8021B.SCB1_CODAGENC, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

                /*" -1302- MOVE 'REPASSE MATCON SCI' TO DETSEGA-NOMEFAV */
                _.Move("REPASSE MATCON SCI", DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

                /*" -1303- ELSE */
            }
            else
            {


                /*" -1306- PERFORM R2000-00-BUSCA-NOME. */

                R2000_00_BUSCA_NOME_SECTION();
            }


            /*" -1308- MOVE DETSEGA-REGISTRO TO REG-MOV043350 */
            _.Move(DETSEGA_REGISTRO, REG_MOV043350);

            /*" -1310- WRITE REG-MOV043350. */
            MOV043350_CC.Write(REG_MOV043350.GetMoveValues().ToString());

            /*" -1311- DISPLAY 'DETSEGA-INFORMA   =>' DETSEGA-INFORMA '<=' */

            $"DETSEGA-INFORMA   =>{DETSEGA_REGISTRO.DETSEGA_INFORMA}<="
            .Display();

            /*" -1312- DISPLAY 'DETSEGA-CODFINAL  =>' DETSEGA-CODFINAL '<=' */

            $"DETSEGA-CODFINAL  =>{DETSEGA_REGISTRO.DETSEGA_CODFINAL}<="
            .Display();

            /*" -1313- DISPLAY 'DETSEGA-AVISO     =>' DETSEGA-AVISO '<=' */

            $"DETSEGA-AVISO     =>{DETSEGA_REGISTRO.DETSEGA_AVISO}<="
            .Display();

            /*" -1313- DISPLAY 'DETSEGA-OCORRENCIA=>' DETSEGA-OCORRENCIA '<=' . */

            $"DETSEGA-OCORRENCIA=>{DETSEGA_REGISTRO.DETSEGA_OCORRENCIA}<="
            .Display();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SEGMENTO-B-SECTION */
        private void R1500_00_SEGMENTO_B_SECTION()
        {
            /*" -1324- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", W.WABEND.WNR_EXEC_SQL);

            /*" -1328- ADD 1 TO AC-NRSEQ AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_NRSEQ.Value = W.AC_NRSEQ + 1;
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1331- MOVE SPACES TO DETSEGB-REGISTRO. */
            _.Move("", DETSEGB_REGISTRO);

            /*" -1333- MOVE 104 TO DETSEGB-BANCO. */
            _.Move(104, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_BANCO);

            /*" -1335- MOVE AC-QTDLOTE TO DETSEGB-LOTSER. */
            _.Move(W.AC_QTDLOTE, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_LOTSER);

            /*" -1337- MOVE 3 TO DETSEGB-TIPOREG. */
            _.Move(3, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_TIPOREG);

            /*" -1339- MOVE AC-NRSEQ TO DETSEGB-NUMREG. */
            _.Move(W.AC_NRSEQ, DETSEGB_REGISTRO.DETSEGB_SERVICO.DETSEGB_NUMREG);

            /*" -1342- MOVE 'B' TO DETSEGB-SEGMENTO. */
            _.Move("B", DETSEGB_REGISTRO.DETSEGB_SERVICO.DETSEGB_SEGMENTO);

            /*" -1343- IF SCB1-TIPOREG EQUAL 'CHEQUE' */

            if (REG_SEM8021B.SCB1_TIPOREG == "CHEQUE")
            {

                /*" -1344- PERFORM R1600-00-SELECT-V0CHEQUES */

                R1600_00_SELECT_V0CHEQUES_SECTION();

                /*" -1345- ELSE */
            }
            else
            {


                /*" -1348- PERFORM R1700-00-MOVE-ENDERECO. */

                R1700_00_MOVE_ENDERECO_SECTION();
            }


            /*" -1350- MOVE DETSEGA-DIAPAG TO DETSEGB-DIAVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_DIAPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_DIAVEN);

            /*" -1352- MOVE DETSEGA-MESPAG TO DETSEGB-MESVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_MESPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_MESVEN);

            /*" -1354- MOVE DETSEGA-ANOPAG TO DETSEGB-ANOVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_ANOPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_ANOVEN);

            /*" -1356- MOVE DETSEGA-VALPAGTO TO DETSEGB-VALNOMIN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALPAGTO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALNOMIN);

            /*" -1363- MOVE ZEROS TO DETSEGB-VALABAT DETSEGB-VALDESC DETSEGB-VALMORA DETSEGB-VALMULTA. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALABAT, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALDESC, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALMORA, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALMULTA);

            /*" -1365- MOVE DETSEGB-REGISTRO TO REG-MOV043350 */
            _.Move(DETSEGB_REGISTRO, REG_MOV043350);

            /*" -1365- WRITE REG-MOV043350. */
            MOV043350_CC.Write(REG_MOV043350.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-V0CHEQUES-SECTION */
        private void R1600_00_SELECT_V0CHEQUES_SECTION()
        {
            /*" -1378- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", W.WABEND.WNR_EXEC_SQL);

            /*" -1382- MOVE SCB1-NUMAPOL TO CHEQUEMI-NUM-CHEQUE-INTERNO. */
            _.Move(REG_SEM8021B.SCB1_NUMAPOL, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);

            /*" -1389- PERFORM R1600_00_SELECT_V0CHEQUES_DB_SELECT_1 */

            R1600_00_SELECT_V0CHEQUES_DB_SELECT_1();

            /*" -1393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1394- DISPLAY 'R1600-00 - PROBLEMAS NO SELECT(CHEQUEMI)' */
                _.Display($"R1600-00 - PROBLEMAS NO SELECT(CHEQUEMI)");

                /*" -1397- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1397- PERFORM R1650-00-SELECT-V0FORNECEDOR. */

            R1650_00_SELECT_V0FORNECEDOR_SECTION();

        }

        [StopWatch]
        /*" R1600-00-SELECT-V0CHEQUES-DB-SELECT-1 */
        public void R1600_00_SELECT_V0CHEQUES_DB_SELECT_1()
        {
            /*" -1389- EXEC SQL SELECT COD_FAVORECIDO INTO :CHEQUEMI-COD-FAVORECIDO FROM SEGUROS.CHEQUES_EMITIDOS WHERE NUM_CHEQUE_INTERNO = :CHEQUEMI-NUM-CHEQUE-INTERNO WITH UR END-EXEC. */

            var r1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1 = new R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1()
            {
                CHEQUEMI_NUM_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_V0CHEQUES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CHEQUEMI_COD_FAVORECIDO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1650-00-SELECT-V0FORNECEDOR-SECTION */
        private void R1650_00_SELECT_V0FORNECEDOR_SECTION()
        {
            /*" -1410- MOVE '1650' TO WNR-EXEC-SQL. */
            _.Move("1650", W.WABEND.WNR_EXEC_SQL);

            /*" -1414- MOVE CHEQUEMI-COD-FAVORECIDO TO FORNECED-COD-FORNECEDOR. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO, FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR);

            /*" -1435- PERFORM R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1 */

            R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1();

            /*" -1439- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1440- DISPLAY 'R1650-00 - PROBLEMAS NO SELECT(FORNECED)' */
                _.Display($"R1650-00 - PROBLEMAS NO SELECT(FORNECED)");

                /*" -1443- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1444- IF FORNECED-TIPO-PESSOA EQUAL 'F' */

            if (FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA == "F")
            {

                /*" -1446- MOVE 1 TO DETSEGB-TIPINSC */
                _.Move(1, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);

                /*" -1447- ELSE */
            }
            else
            {


                /*" -1450- MOVE 2 TO DETSEGB-TIPINSC. */
                _.Move(2, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);
            }


            /*" -1452- MOVE FORNECED-CGCCPF TO DETSEGB-NROINSC. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_NROINSC);

            /*" -1454- MOVE FORNECED-ENDERECO TO DETSEGB-LOGRADOURO. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_LOGRADOURO);

            /*" -1456- MOVE ZEROS TO DETSEGB-NUMERO. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_NUMERO);

            /*" -1458- MOVE SPACES TO DETSEGB-COMPLOGRA. */
            _.Move("", DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_COMPLOGRA);

            /*" -1460- MOVE FORNECED-BAIRRO TO DETSEGB-BAIRRO. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_BAIRRO);

            /*" -1462- MOVE FORNECED-CIDADE TO DETSEGB-CIDADE. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CIDADE, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CIDADE);

            /*" -1464- MOVE FORNECED-CEP TO DETSEGB-CEP. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_CEP, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CEP);

            /*" -1465- MOVE FORNECED-SIGLA-UF TO DETSEGB-SIGLAUF. */
            _.Move(FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_SIGLAUF);

        }

        [StopWatch]
        /*" R1650-00-SELECT-V0FORNECEDOR-DB-SELECT-1 */
        public void R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1()
        {
            /*" -1435- EXEC SQL SELECT NOME_FORNECEDOR , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , CGCCPF , TIPO_PESSOA INTO :FORNECED-NOME-FORNECEDOR , :FORNECED-ENDERECO , :FORNECED-BAIRRO , :FORNECED-CIDADE , :FORNECED-SIGLA-UF , :FORNECED-CEP , :FORNECED-CGCCPF , :FORNECED-TIPO-PESSOA FROM SEGUROS.FORNECEDORES WHERE COD_FORNECEDOR = :FORNECED-COD-FORNECEDOR WITH UR END-EXEC. */

            var r1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1 = new R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1()
            {
                FORNECED_COD_FORNECEDOR = FORNECED.DCLFORNECEDORES.FORNECED_COD_FORNECEDOR.ToString(),
            };

            var executed_1 = R1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1.Execute(r1650_00_SELECT_V0FORNECEDOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FORNECED_NOME_FORNECEDOR, FORNECED.DCLFORNECEDORES.FORNECED_NOME_FORNECEDOR);
                _.Move(executed_1.FORNECED_ENDERECO, FORNECED.DCLFORNECEDORES.FORNECED_ENDERECO);
                _.Move(executed_1.FORNECED_BAIRRO, FORNECED.DCLFORNECEDORES.FORNECED_BAIRRO);
                _.Move(executed_1.FORNECED_CIDADE, FORNECED.DCLFORNECEDORES.FORNECED_CIDADE);
                _.Move(executed_1.FORNECED_SIGLA_UF, FORNECED.DCLFORNECEDORES.FORNECED_SIGLA_UF);
                _.Move(executed_1.FORNECED_CEP, FORNECED.DCLFORNECEDORES.FORNECED_CEP);
                _.Move(executed_1.FORNECED_CGCCPF, FORNECED.DCLFORNECEDORES.FORNECED_CGCCPF);
                _.Move(executed_1.FORNECED_TIPO_PESSOA, FORNECED.DCLFORNECEDORES.FORNECED_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-MOVE-ENDERECO-SECTION */
        private void R1700_00_MOVE_ENDERECO_SECTION()
        {
            /*" -1478- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", W.WABEND.WNR_EXEC_SQL);

            /*" -1479- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1481- MOVE 1 TO DETSEGB-TIPINSC */
                _.Move(1, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);

                /*" -1482- ELSE */
            }
            else
            {


                /*" -1485- MOVE 2 TO DETSEGB-TIPINSC. */
                _.Move(2, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);
            }


            /*" -1487- MOVE CLIENTES-CGCCPF TO DETSEGB-NROINSC. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_NROINSC);

            /*" -1489- MOVE ENDERECO-ENDERECO TO DETSEGB-LOGRADOURO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_LOGRADOURO);

            /*" -1491- MOVE ZEROS TO DETSEGB-NUMERO. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_NUMERO);

            /*" -1493- MOVE SPACES TO DETSEGB-COMPLOGRA. */
            _.Move("", DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_COMPLOGRA);

            /*" -1495- MOVE ENDERECO-BAIRRO TO DETSEGB-BAIRRO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_BAIRRO);

            /*" -1497- MOVE ENDERECO-CIDADE TO DETSEGB-CIDADE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CIDADE);

            /*" -1499- MOVE ENDERECO-CEP TO DETSEGB-CEP. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CEP);

            /*" -1500- MOVE ENDERECO-SIGLA-UF TO DETSEGB-SIGLAUF. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_SIGLAUF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-BUSCA-NOME-SECTION */
        private void R2000_00_BUSCA_NOME_SECTION()
        {
            /*" -1513- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", W.WABEND.WNR_EXEC_SQL);

            /*" -1515- MOVE SCB1-NUMAPOL TO SINISMES-NUM-APOL-SINISTRO. */
            _.Move(REG_SEM8021B.SCB1_NUMAPOL, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);

            /*" -1519- MOVE SCB1-NRPARCEL TO MOVSINIH-OCORR-HISTORICO. */
            _.Move(REG_SEM8021B.SCB1_NRPARCEL, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_OCORR_HISTORICO);

            /*" -1527- IF SCB1-PRODUTO EQUAL 4800 OR 4802 OR 4803 OR 4805 OR 4807 OR 4809 OR 4810 OR 4899 */

            if (REG_SEM8021B.SCB1_PRODUTO.In("4800", "4802", "4803", "4805", "4807", "4809", "4810", "4899"))
            {

                /*" -1528- PERFORM R2010-00-BUSCA-NOM-CREDITO */

                R2010_00_BUSCA_NOM_CREDITO_SECTION();

                /*" -1529- ELSE */
            }
            else
            {


                /*" -1531- IF SCB1-PRODUTO EQUAL 9301 OR 9302 */

                if (REG_SEM8021B.SCB1_PRODUTO.In("9301", "9302"))
                {

                    /*" -1532- PERFORM R2100-00-BUSCA-NOM-PENHOR-CE */

                    R2100_00_BUSCA_NOM_PENHOR_CE_SECTION();

                    /*" -1533- PERFORM R2120-00-BUSCA-END-PENHOR-CE */

                    R2120_00_BUSCA_END_PENHOR_CE_SECTION();

                    /*" -1534- PERFORM R2150-00-BUSCA-CTR-PENHOR-CE */

                    R2150_00_BUSCA_CTR_PENHOR_CE_SECTION();

                    /*" -1535- ELSE */
                }
                else
                {


                    /*" -1539- IF SCB1-PRODUTO EQUAL 4801 OR 4812 OR 7001 OR 7704 */

                    if (REG_SEM8021B.SCB1_PRODUTO.In("4801", "4812", "7001", "7704"))
                    {

                        /*" -1540- PERFORM R2200-00-BUSCA-NOM-HAB-MATCON */

                        R2200_00_BUSCA_NOM_HAB_MATCON_SECTION();

                        /*" -1541- ELSE */
                    }
                    else
                    {


                        /*" -1542- IF SCB1-RAMO EQUAL 68 */

                        if (REG_SEM8021B.SCB1_RAMO == 68)
                        {

                            /*" -1543- PERFORM R2200-00-BUSCA-NOM-HAB-MATCON */

                            R2200_00_BUSCA_NOM_HAB_MATCON_SECTION();

                            /*" -1544- ELSE */
                        }
                        else
                        {


                            /*" -1545- IF SCB1-RAMO EQUAL 66 */

                            if (REG_SEM8021B.SCB1_RAMO == 66)
                            {

                                /*" -1546- PERFORM R2300-00-BUSCA-NOM-HIPOTECARIO */

                                R2300_00_BUSCA_NOM_HIPOTECARIO_SECTION();

                                /*" -1547- ELSE */
                            }
                            else
                            {


                                /*" -1549- MOVE 0630 TO DETSEGA-AGECONTA */
                                _.Move(0630, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

                                /*" -1550- MOVE SPACES TO DETSEGA-NOMEFAV. */
                                _.Move("", DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);
                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-BUSCA-NOM-CREDITO-SECTION */
        private void R2010_00_BUSCA_NOM_CREDITO_SECTION()
        {
            /*" -1563- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", W.WABEND.WNR_EXEC_SQL);

            /*" -1577- PERFORM R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1 */

            R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1();

            /*" -1581- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1582- DISPLAY 'R2010-00 - PROBLEMAS NO SELECT(SINCREIN)' */
                _.Display($"R2010-00 - PROBLEMAS NO SELECT(SINCREIN)");

                /*" -1585- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1589- MOVE SINCREIN-COD-AGENCIA TO DETSEGA-AGECONTA. */
            _.Move(SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

            /*" -1592- PERFORM R2020-00-ACESSA-APOLICRE. */

            R2020_00_ACESSA_APOLICRE_SECTION();

            /*" -1593- IF APOLICRE-PROPRIET EQUAL SPACES */

            if (APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET.IsEmpty())
            {

                /*" -1595- MOVE CLIENTES-NOME-RAZAO TO DETSEGA-NOMEFAV */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

                /*" -1596- ELSE */
            }
            else
            {


                /*" -1597- MOVE APOLICRE-PROPRIET TO DETSEGA-NOMEFAV. */
                _.Move(APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);
            }


        }

        [StopWatch]
        /*" R2010-00-BUSCA-NOM-CREDITO-DB-SELECT-1 */
        public void R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1()
        {
            /*" -1577- EXEC SQL SELECT COD_SUREG, COD_AGENCIA, COD_OPERACAO, NUM_CONTRATO, CONTRATO_DIGITO INTO :SINCREIN-COD-SUREG, :SINCREIN-COD-AGENCIA, :SINCREIN-COD-OPERACAO, :SINCREIN-NUM-CONTRATO, :SINCREIN-CONTRATO-DIGITO FROM SEGUROS.SINISTRO_CRED_INT WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1_Query1 = new R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1_Query1.Execute(r2010_00_BUSCA_NOM_CREDITO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINCREIN_COD_SUREG, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG);
                _.Move(executed_1.SINCREIN_COD_AGENCIA, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA);
                _.Move(executed_1.SINCREIN_COD_OPERACAO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO);
                _.Move(executed_1.SINCREIN_NUM_CONTRATO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO);
                _.Move(executed_1.SINCREIN_CONTRATO_DIGITO, SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2020-00-ACESSA-APOLICRE-SECTION */
        private void R2020_00_ACESSA_APOLICRE_SECTION()
        {
            /*" -1610- MOVE '2020' TO WNR-EXEC-SQL. */
            _.Move("2020", W.WABEND.WNR_EXEC_SQL);

            /*" -1634- PERFORM R2020_00_ACESSA_APOLICRE_DB_SELECT_1 */

            R2020_00_ACESSA_APOLICRE_DB_SELECT_1();

            /*" -1638- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1641- MOVE SPACES TO APOLICRE-PROPRIET APOLICRE-TIPO-PESSOA */
                _.Move("", APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_TIPO_PESSOA);

                /*" -1645- MOVE ZEROS TO APOLICRE-CGCCPF. */
                _.Move(0, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
            }


            /*" -1645- PERFORM R2025-00-ACESSA-SINIITEM. */

            R2025_00_ACESSA_SINIITEM_SECTION();

        }

        [StopWatch]
        /*" R2020-00-ACESSA-APOLICRE-DB-SELECT-1 */
        public void R2020_00_ACESSA_APOLICRE_DB_SELECT_1()
        {
            /*" -1634- EXEC SQL SELECT PROPRIET, TIPO_PESSOA, CGCCPF INTO :APOLICRE-PROPRIET, :APOLICRE-TIPO-PESSOA, :APOLICRE-CGCCPF FROM SEGUROS.APOLICE_CREDITO WHERE COD_SUREG = :SINCREIN-COD-SUREG AND COD_AGENCIA = :SINCREIN-COD-AGENCIA AND COD_OPERACAO = :SINCREIN-COD-OPERACAO AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO AND SITUACAO IN ( '1' , 'A' , 'B' , 'S' , '3' ) AND TIMESTAMP = (SELECT MAX(TIMESTAMP) FROM SEGUROS.APOLICE_CREDITO WHERE COD_SUREG = :SINCREIN-COD-SUREG AND COD_AGENCIA = :SINCREIN-COD-AGENCIA AND COD_OPERACAO = :SINCREIN-COD-OPERACAO AND NUM_CONTRATO = :SINCREIN-NUM-CONTRATO AND CONTRATO_DIGITO = :SINCREIN-CONTRATO-DIGITO AND SITUACAO IN ( '1' , 'A' , 'B' , 'S' , '3' )) WITH UR END-EXEC. */

            var r2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1 = new R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1()
            {
                SINCREIN_CONTRATO_DIGITO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_CONTRATO_DIGITO.ToString(),
                SINCREIN_COD_OPERACAO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_OPERACAO.ToString(),
                SINCREIN_NUM_CONTRATO = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_NUM_CONTRATO.ToString(),
                SINCREIN_COD_AGENCIA = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_AGENCIA.ToString(),
                SINCREIN_COD_SUREG = SINCREIN.DCLSINISTRO_CRED_INT.SINCREIN_COD_SUREG.ToString(),
            };

            var executed_1 = R2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1.Execute(r2020_00_ACESSA_APOLICRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICRE_PROPRIET, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_PROPRIET);
                _.Move(executed_1.APOLICRE_TIPO_PESSOA, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_TIPO_PESSOA);
                _.Move(executed_1.APOLICRE_CGCCPF, APOLICRE.DCLAPOLICE_CREDITO.APOLICRE_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2020_99_SAIDA*/

        [StopWatch]
        /*" R2025-00-ACESSA-SINIITEM-SECTION */
        private void R2025_00_ACESSA_SINIITEM_SECTION()
        {
            /*" -1658- MOVE '2025' TO WNR-EXEC-SQL. */
            _.Move("2025", W.WABEND.WNR_EXEC_SQL);

            /*" -1664- PERFORM R2025_00_ACESSA_SINIITEM_DB_SELECT_1 */

            R2025_00_ACESSA_SINIITEM_DB_SELECT_1();

            /*" -1668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1676- MOVE SPACES TO CLIENTES-NOME-RAZAO CLIENTES-TIPO-PESSOA ENDERECO-ENDERECO ENDERECO-BAIRRO ENDERECO-CIDADE ENDERECO-SIGLA-UF ENDERECO-DES-COMPLEMENTO */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

                /*" -1679- MOVE ZEROS TO CLIENTES-CGCCPF ENDERECO-CEP */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

                /*" -1680- ELSE */
            }
            else
            {


                /*" -1681- PERFORM R2030-00-ACESSA-CLIENTES */

                R2030_00_ACESSA_CLIENTES_SECTION();

                /*" -1681- PERFORM R2040-00-ACESSA-ENDERECO1. */

                R2040_00_ACESSA_ENDERECO1_SECTION();
            }


        }

        [StopWatch]
        /*" R2025-00-ACESSA-SINIITEM-DB-SELECT-1 */
        public void R2025_00_ACESSA_SINIITEM_DB_SELECT_1()
        {
            /*" -1664- EXEC SQL SELECT COD_CLIENTE INTO :SINIITEM-COD-CLIENTE FROM SEGUROS.SINISTRO_ITEM WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2025_00_ACESSA_SINIITEM_DB_SELECT_1_Query1 = new R2025_00_ACESSA_SINIITEM_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2025_00_ACESSA_SINIITEM_DB_SELECT_1_Query1.Execute(r2025_00_ACESSA_SINIITEM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIITEM_COD_CLIENTE, SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2025_99_SAIDA*/

        [StopWatch]
        /*" R2030-00-ACESSA-CLIENTES-SECTION */
        private void R2030_00_ACESSA_CLIENTES_SECTION()
        {
            /*" -1694- MOVE '2030' TO WNR-EXEC-SQL. */
            _.Move("2030", W.WABEND.WNR_EXEC_SQL);

            /*" -1704- PERFORM R2030_00_ACESSA_CLIENTES_DB_SELECT_1 */

            R2030_00_ACESSA_CLIENTES_DB_SELECT_1();

            /*" -1708- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1711- MOVE SPACES TO CLIENTES-NOME-RAZAO CLIENTES-TIPO-PESSOA */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -1712- MOVE ZEROS TO CLIENTES-CGCCPF. */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }

        [StopWatch]
        /*" R2030-00-ACESSA-CLIENTES-DB-SELECT-1 */
        public void R2030_00_ACESSA_CLIENTES_DB_SELECT_1()
        {
            /*" -1704- EXEC SQL SELECT NOME_RAZAO, TIPO_PESSOA, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE WITH UR END-EXEC. */

            var r2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1 = new R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1()
            {
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1.Execute(r2030_00_ACESSA_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2030_99_SAIDA*/

        [StopWatch]
        /*" R2040-00-ACESSA-ENDERECO1-SECTION */
        private void R2040_00_ACESSA_ENDERECO1_SECTION()
        {
            /*" -1725- MOVE '2040' TO WNR-EXEC-SQL. */
            _.Move("2040", W.WABEND.WNR_EXEC_SQL);

            /*" -1746- PERFORM R2040_00_ACESSA_ENDERECO1_DB_SELECT_1 */

            R2040_00_ACESSA_ENDERECO1_DB_SELECT_1();

            /*" -1750- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1751- PERFORM R2050-00-ACESSA-ENDERECO2 */

                R2050_00_ACESSA_ENDERECO2_SECTION();

                /*" -1752- ELSE */
            }
            else
            {


                /*" -1753- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1759- MOVE SPACES TO ENDERECO-ENDERECO ENDERECO-BAIRRO ENDERECO-CIDADE ENDERECO-SIGLA-UF ENDERECO-DES-COMPLEMENTO */
                    _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

                    /*" -1760- MOVE ZEROS TO ENDERECO-CEP. */
                    _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                }

            }


        }

        [StopWatch]
        /*" R2040-00-ACESSA-ENDERECO1-DB-SELECT-1 */
        public void R2040_00_ACESSA_ENDERECO1_DB_SELECT_1()
        {
            /*" -1746- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, VALUE(DES_COMPLEMENTO, ' ' ) INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-DES-COMPLEMENTO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE AND COD_ENDERECO = 1 AND OCORR_ENDERECO = (SELECT MAX(OCORR_ENDERECO) FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE) WITH UR END-EXEC. */

            var r2040_00_ACESSA_ENDERECO1_DB_SELECT_1_Query1 = new R2040_00_ACESSA_ENDERECO1_DB_SELECT_1_Query1()
            {
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2040_00_ACESSA_ENDERECO1_DB_SELECT_1_Query1.Execute(r2040_00_ACESSA_ENDERECO1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2040_99_SAIDA*/

        [StopWatch]
        /*" R2050-00-ACESSA-ENDERECO2-SECTION */
        private void R2050_00_ACESSA_ENDERECO2_SECTION()
        {
            /*" -1773- MOVE '2050' TO WNR-EXEC-SQL. */
            _.Move("2050", W.WABEND.WNR_EXEC_SQL);

            /*" -1794- PERFORM R2050_00_ACESSA_ENDERECO2_DB_SELECT_1 */

            R2050_00_ACESSA_ENDERECO2_DB_SELECT_1();

            /*" -1797- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1798- PERFORM R2060-00-ACESSA-ENDERECO3 */

                R2060_00_ACESSA_ENDERECO3_SECTION();

                /*" -1799- ELSE */
            }
            else
            {


                /*" -1800- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1806- MOVE SPACES TO ENDERECO-ENDERECO ENDERECO-BAIRRO ENDERECO-CIDADE ENDERECO-SIGLA-UF ENDERECO-DES-COMPLEMENTO */
                    _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

                    /*" -1807- MOVE ZEROS TO ENDERECO-CEP. */
                    _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                }

            }


        }

        [StopWatch]
        /*" R2050-00-ACESSA-ENDERECO2-DB-SELECT-1 */
        public void R2050_00_ACESSA_ENDERECO2_DB_SELECT_1()
        {
            /*" -1794- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, VALUE(DES_COMPLEMENTO, ' ' ) INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-DES-COMPLEMENTO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE AND COD_ENDERECO = 2 AND OCORR_ENDERECO = (SELECT MAX(OCORR_ENDERECO) FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE) WITH UR END-EXEC. */

            var r2050_00_ACESSA_ENDERECO2_DB_SELECT_1_Query1 = new R2050_00_ACESSA_ENDERECO2_DB_SELECT_1_Query1()
            {
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2050_00_ACESSA_ENDERECO2_DB_SELECT_1_Query1.Execute(r2050_00_ACESSA_ENDERECO2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2050_99_SAIDA*/

        [StopWatch]
        /*" R2060-00-ACESSA-ENDERECO3-SECTION */
        private void R2060_00_ACESSA_ENDERECO3_SECTION()
        {
            /*" -1820- MOVE '2060' TO WNR-EXEC-SQL. */
            _.Move("2060", W.WABEND.WNR_EXEC_SQL);

            /*" -1840- PERFORM R2060_00_ACESSA_ENDERECO3_DB_SELECT_1 */

            R2060_00_ACESSA_ENDERECO3_DB_SELECT_1();

            /*" -1843- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1849- MOVE SPACES TO ENDERECO-ENDERECO ENDERECO-BAIRRO ENDERECO-CIDADE ENDERECO-SIGLA-UF ENDERECO-DES-COMPLEMENTO */
                _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

                /*" -1850- MOVE ZEROS TO ENDERECO-CEP. */
                _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R2060-00-ACESSA-ENDERECO3-DB-SELECT-1 */
        public void R2060_00_ACESSA_ENDERECO3_DB_SELECT_1()
        {
            /*" -1840- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, VALUE(DES_COMPLEMENTO, ' ' ) INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-DES-COMPLEMENTO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE AND OCORR_ENDERECO = (SELECT MAX(OCORR_ENDERECO) FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :SINIITEM-COD-CLIENTE) WITH UR END-EXEC. */

            var r2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1 = new R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1()
            {
                SINIITEM_COD_CLIENTE = SINIITEM.DCLSINISTRO_ITEM.SINIITEM_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1.Execute(r2060_00_ACESSA_ENDERECO3_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2060_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-BUSCA-NOM-PENHOR-CE-SECTION */
        private void R2100_00_BUSCA_NOM_PENHOR_CE_SECTION()
        {
            /*" -1863- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", W.WABEND.WNR_EXEC_SQL);

            /*" -1879- PERFORM R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1 */

            R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1();

            /*" -1883- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1886- MOVE SPACES TO CLIENTES-NOME-RAZAO CLIENTES-TIPO-PESSOA */
                _.Move("", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -1890- MOVE ZEROS TO CLIENTES-CGCCPF. */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


            /*" -1891- MOVE CLIENTES-NOME-RAZAO TO DETSEGA-NOMEFAV. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

        }

        [StopWatch]
        /*" R2100-00-BUSCA-NOM-PENHOR-CE-DB-SELECT-1 */
        public void R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1()
        {
            /*" -1879- EXEC SQL SELECT C.NOME_RAZAO, C.TIPO_PESSOA, C.CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-TIPO-PESSOA, :CLIENTES-CGCCPF FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.SINISTRO_MESTRE B, SEGUROS.CLIENTES C WHERE B.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND A.COD_CLIENTE = C.COD_CLIENTE WITH UR END-EXEC. */

            var r2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1_Query1 = new R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1_Query1.Execute(r2100_00_BUSCA_NOM_PENHOR_CE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2120-00-BUSCA-END-PENHOR-CE-SECTION */
        private void R2120_00_BUSCA_END_PENHOR_CE_SECTION()
        {
            /*" -1904- MOVE '2120' TO WNR-EXEC-SQL. */
            _.Move("2120", W.WABEND.WNR_EXEC_SQL);

            /*" -1930- PERFORM R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1 */

            R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1();

            /*" -1934- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1940- MOVE SPACES TO ENDERECO-ENDERECO ENDERECO-BAIRRO ENDERECO-CIDADE ENDERECO-SIGLA-UF ENDERECO-DES-COMPLEMENTO */
                _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

                /*" -1941- MOVE ZEROS TO ENDERECO-CEP. */
                _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }

        [StopWatch]
        /*" R2120-00-BUSCA-END-PENHOR-CE-DB-SELECT-1 */
        public void R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1()
        {
            /*" -1930- EXEC SQL SELECT C.ENDERECO, C.BAIRRO, C.CIDADE, C.SIGLA_UF, C.CEP, VALUE(C.DES_COMPLEMENTO, ' ' ) INTO :ENDERECO-ENDERECO, :ENDERECO-BAIRRO, :ENDERECO-CIDADE, :ENDERECO-SIGLA-UF, :ENDERECO-CEP, :ENDERECO-DES-COMPLEMENTO FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.SINISTRO_MESTRE B, SEGUROS.ENDERECOS C WHERE B.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND A.COD_CLIENTE = C.COD_CLIENTE AND C.OCORR_ENDERECO = (SELECT MAX(D.OCORR_ENDERECO) FROM SEGUROS.ENDERECOS D WHERE D.COD_CLIENTE = C.COD_CLIENTE) WITH UR END-EXEC. */

            var r2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1 = new R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1.Execute(r2120_00_BUSCA_END_PENHOR_CE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_DES_COMPLEMENTO, ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2120_99_SAIDA*/

        [StopWatch]
        /*" R2150-00-BUSCA-CTR-PENHOR-CE-SECTION */
        private void R2150_00_BUSCA_CTR_PENHOR_CE_SECTION()
        {
            /*" -1954- MOVE '2150' TO WNR-EXEC-SQL. */
            _.Move("2150", W.WABEND.WNR_EXEC_SQL);

            /*" -1962- PERFORM R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1 */

            R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1();

            /*" -1966- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1970- MOVE 0630 TO SINIPENH-COD-AGENCIA. */
                _.Move(0630, SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA);
            }


            /*" -1971- MOVE SINIPENH-COD-AGENCIA TO DETSEGA-AGECONTA. */
            _.Move(SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

        }

        [StopWatch]
        /*" R2150-00-BUSCA-CTR-PENHOR-CE-DB-SELECT-1 */
        public void R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1()
        {
            /*" -1962- EXEC SQL SELECT VALUE(NUM_CONTRATO,0) , VALUE(COD_AGENCIA,630) INTO :SINIPENH-NUM-CONTRATO , :SINIPENH-COD-AGENCIA FROM SEGUROS.SINI_PENHOR01 WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1 = new R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1.Execute(r2150_00_BUSCA_CTR_PENHOR_CE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIPENH_NUM_CONTRATO, SINIPENH.DCLSINI_PENHOR01.SINIPENH_NUM_CONTRATO);
                _.Move(executed_1.SINIPENH_COD_AGENCIA, SINIPENH.DCLSINI_PENHOR01.SINIPENH_COD_AGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2150_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-BUSCA-NOM-HAB-MATCON-SECTION */
        private void R2200_00_BUSCA_NOM_HAB_MATCON_SECTION()
        {
            /*" -1984- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", W.WABEND.WNR_EXEC_SQL);

            /*" -2002- PERFORM R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1 */

            R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1();

            /*" -2006- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2009- MOVE SPACES TO SINIHAB1-NOME-SEGURADO CLIENTES-TIPO-PESSOA */
                _.Move("", SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -2013- MOVE ZEROS TO CLIENTES-CGCCPF. */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


            /*" -2015- MOVE SINIHAB1-COD-UNO TO DETSEGA-AGECONTA. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_UNO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

            /*" -2017- MOVE SINIHAB1-NOME-SEGURADO TO DETSEGA-NOMEFAV. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

            /*" -2021- MOVE SINIHAB1-CGCCPF TO CLIENTES-CGCCPF. */
            _.Move(SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -2023- MOVE 'SCN QD 1 BL A 15 16 E 17 ANDAR' TO ENDERECO-ENDERECO. */
            _.Move("SCN QD 1 BL A 15 16 E 17 ANDAR", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -2024- MOVE SPACES TO ENDERECO-DES-COMPLEMENTO. */
            _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

            /*" -2025- MOVE 'CENTRO' TO ENDERECO-BAIRRO. */
            _.Move("CENTRO", ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -2026- MOVE 'BRASILIA' TO ENDERECO-CIDADE. */
            _.Move("BRASILIA", ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -2027- MOVE 70711900 TO ENDERECO-CEP. */
            _.Move(70711900, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -2027- MOVE 'DF' TO ENDERECO-SIGLA-UF. */
            _.Move("DF", ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

        }

        [StopWatch]
        /*" R2200-00-BUSCA-NOM-HAB-MATCON-DB-SELECT-1 */
        public void R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1()
        {
            /*" -2002- EXEC SQL SELECT COD_UNO OPERACAO, PONTO_VENDA, NUM_CONTRATO, CGCCPF, NOME_SEGURADO, DATA_NASC INTO :SINIHAB1-COD-UNO :SINIHAB1-OPERACAO, :SINIHAB1-PONTO-VENDA, :SINIHAB1-NUM-CONTRATO, :SINIHAB1-CGCCPF, :SINIHAB1-NOME-SEGURADO, :SINIHAB1-DATA-NASC FROM SEGUROS.SINISTRO_HABIT01 WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO WITH UR END-EXEC. */

            var r2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1 = new R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1.Execute(r2200_00_BUSCA_NOM_HAB_MATCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINIHAB1_COD_UNO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_COD_UNO);
                _.Move(executed_1.SINIHAB1_OPERACAO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_OPERACAO);
                _.Move(executed_1.SINIHAB1_PONTO_VENDA, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_PONTO_VENDA);
                _.Move(executed_1.SINIHAB1_NUM_CONTRATO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NUM_CONTRATO);
                _.Move(executed_1.SINIHAB1_CGCCPF, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_CGCCPF);
                _.Move(executed_1.SINIHAB1_NOME_SEGURADO, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_NOME_SEGURADO);
                _.Move(executed_1.SINIHAB1_DATA_NASC, SINIHAB1.DCLSINISTRO_HABIT01.SINIHAB1_DATA_NASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-BUSCA-NOM-HIPOTECARIO-SECTION */
        private void R2300_00_BUSCA_NOM_HIPOTECARIO_SECTION()
        {
            /*" -2040- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", W.WABEND.WNR_EXEC_SQL);

            /*" -2059- PERFORM R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1 */

            R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1();

            /*" -2063- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2065- MOVE 0630 TO MOVSINIH-AGE-INDENIZACAO */
                _.Move(0630, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_AGE_INDENIZACAO);

                /*" -2068- MOVE SPACES TO MOVSINIH-NOME-SEGURADO CLIENTES-TIPO-PESSOA */
                _.Move("", MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NOME_SEGURADO, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);

                /*" -2072- MOVE ZEROS TO CLIENTES-CGCCPF. */
                _.Move(0, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


            /*" -2074- MOVE MOVSINIH-AGE-INDENIZACAO TO DETSEGA-AGECONTA. */
            _.Move(MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_AGE_INDENIZACAO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

            /*" -2076- MOVE MOVSINIH-NOME-SEGURADO TO DETSEGA-NOMEFAV. */
            _.Move(MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NOME_SEGURADO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

            /*" -2080- MOVE MOVSINIH-CGCCPF TO CLIENTES-CGCCPF. */
            _.Move(MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);

            /*" -2082- MOVE 'SCN QD 1 BL A 15 16 E 17 ANDAR' TO ENDERECO-ENDERECO. */
            _.Move("SCN QD 1 BL A 15 16 E 17 ANDAR", ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);

            /*" -2083- MOVE SPACES TO ENDERECO-DES-COMPLEMENTO. */
            _.Move("", ENDERECO.DCLENDERECOS.ENDERECO_DES_COMPLEMENTO);

            /*" -2084- MOVE 'CENTRO' TO ENDERECO-BAIRRO. */
            _.Move("CENTRO", ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);

            /*" -2085- MOVE 'BRASILIA' TO ENDERECO-CIDADE. */
            _.Move("BRASILIA", ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);

            /*" -2086- MOVE 70711900 TO ENDERECO-CEP. */
            _.Move(70711900, ENDERECO.DCLENDERECOS.ENDERECO_CEP);

            /*" -2086- MOVE 'DF' TO ENDERECO-SIGLA-UF. */
            _.Move("DF", ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);

        }

        [StopWatch]
        /*" R2300-00-BUSCA-NOM-HIPOTECARIO-DB-SELECT-1 */
        public void R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1()
        {
            /*" -2059- EXEC SQL SELECT AGE_INDENIZACAO, NOME_SEGURADO, CGCCPF, DTH_NASCIMENTO, NUM_CONTRATO_CEF, MATR_AGENTE, COD_COBERTURA INTO :MOVSINIH-AGE-INDENIZACAO, :MOVSINIH-NOME-SEGURADO, :MOVSINIH-CGCCPF, :MOVSINIH-DTH-NASCIMENTO, :MOVSINIH-NUM-CONTRATO-CEF, :MOVSINIH-MATR-AGENTE, :MOVSINIH-COD-COBERTURA FROM SEGUROS.MOVSINISTRO_HABIT WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :MOVSINIH-OCORR-HISTORICO WITH UR END-EXEC. */

            var r2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1_Query1 = new R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
                MOVSINIH_OCORR_HISTORICO = MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1_Query1.Execute(r2300_00_BUSCA_NOM_HIPOTECARIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVSINIH_AGE_INDENIZACAO, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_AGE_INDENIZACAO);
                _.Move(executed_1.MOVSINIH_NOME_SEGURADO, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NOME_SEGURADO);
                _.Move(executed_1.MOVSINIH_CGCCPF, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_CGCCPF);
                _.Move(executed_1.MOVSINIH_DTH_NASCIMENTO, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_DTH_NASCIMENTO);
                _.Move(executed_1.MOVSINIH_NUM_CONTRATO_CEF, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_NUM_CONTRATO_CEF);
                _.Move(executed_1.MOVSINIH_MATR_AGENTE, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_MATR_AGENTE);
                _.Move(executed_1.MOVSINIH_COD_COBERTURA, MOVSINIH.DCLMOVSINISTRO_HABIT.MOVSINIH_COD_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-HEADER-ARQUIVO-SECTION */
        private void R3000_00_HEADER_ARQUIVO_SECTION()
        {
            /*" -2099- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", W.WABEND.WNR_EXEC_SQL);

            /*" -2102- PERFORM R3050-00-SELECT-V0PARAMCON. */

            R3050_00_SELECT_V0PARAMCON_SECTION();

            /*" -2104- ADD 1 TO AC-QTDREGARQ. */
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -2107- MOVE SPACES TO ARQHEA-REGISTRO. */
            _.Move("", ARQHEA_REGISTRO);

            /*" -2109- MOVE 104 TO ARQHEA-BANCO. */
            _.Move(104, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_BANCO);

            /*" -2111- MOVE ZEROS TO ARQHEA-LOTSER. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_LOTSER);

            /*" -2113- MOVE ZEROS TO ARQHEA-TIPOREG. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_TIPOREG);

            /*" -2115- MOVE 2 TO ARQHEA-TIPINSC. */
            _.Move(2, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_INSCRICAO.ARQHEA_TIPINSC);

            /*" -2117- MOVE 34020354000110 TO ARQHEA-NROINSC. */
            _.Move(34020354000110, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_INSCRICAO.ARQHEA_NROINSC);

            /*" -2119- MOVE 043350 TO ARQHEA-CONVENIO. */
            _.Move(043350, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONVENIO);

            /*" -2121- MOVE 01 TO ARQHEA-PAR-TRANSMIS. */
            _.Move(01, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_PAR_TRANSMIS);

            /*" -2123- MOVE 'P' TO ARQHEA-AMB-CLIENTE. */
            _.Move("P", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_AMB_CLIENTE);

            /*" -2125- MOVE 'P' TO ARQHEA-AMB-CAIXA. */
            _.Move("P", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_AMB_CAIXA);

            /*" -2128- MOVE ZEROS TO ARQHEA-ORI-APLICATIVO. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_ORI_APLICATIVO);

            /*" -2130- MOVE PARAMCON-COD-AGENCIA-SASS TO ARQHEA-AGECONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_AGENCIA_SASS, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_AGECONTA);

            /*" -2132- MOVE SPACES TO ARQHEA-DIGAGENC. */
            _.Move("", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGAGENC);

            /*" -2134- MOVE PARAMCON-OPER-CONTA-SASS TO ARQHEA-OPECONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_OPER_CONTA_SASS, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_OPECONTA);

            /*" -2136- MOVE PARAMCON-NUM-CONTA-SASS TO ARQHEA-NUMCONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NUM_CONTA_SASS, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_NUMCONTA);

            /*" -2138- MOVE PARAMCON-DIG-CONTA-SASS TO ARQHEA-DIGCONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DIG_CONTA_SASS, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGCONTA);

            /*" -2141- MOVE SPACES TO ARQHEA-DIGAGECTA. */
            _.Move("", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGAGECTA);

            /*" -2143- MOVE 'CAIXA SEGURADORA SA' TO ARQHEA-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_NOMEMPRESA);

            /*" -2145- MOVE 'CAIXA              ' TO ARQHEA-NOMEBANCO. */
            _.Move("CAIXA              ", ARQHEA_REGISTRO.ARQHEA_NOMEBANCO);

            /*" -2148- MOVE 2 TO ARQHEA-REMESSA. */
            _.Move(2, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_REMESSA);

            /*" -2150- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -2152- MOVE WDAT-REL-DIA TO ARQHEA-DIAGERA. */
            _.Move(W.FILLER_3.WDAT_REL_DIA, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_DIAGERA);

            /*" -2154- MOVE WDAT-REL-MES TO ARQHEA-MESGERA. */
            _.Move(W.FILLER_3.WDAT_REL_MES, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_MESGERA);

            /*" -2157- MOVE WDAT-REL-ANO TO ARQHEA-ANOGERA. */
            _.Move(W.FILLER_3.WDAT_REL_ANO, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_ANOGERA);

            /*" -2158- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -2160- MOVE WHORA-HH-CURR TO ARQHEA-HORGERA. */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_HORGERA);

            /*" -2162- MOVE WHORA-MM-CURR TO ARQHEA-MINGERA. */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_MINGERA);

            /*" -2164- MOVE WHORA-SS-CURR TO ARQHEA-SEGGERA. */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_SEGGERA);

            /*" -2166- MOVE SCB1-NSAC TO ARQHEA-NSA. */
            _.Move(REG_SEM8021B.SCB1_NSAC, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_NSA);

            /*" -2168- MOVE 050 TO ARQHEA-VERSAO. */
            _.Move(050, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_VERSAO);

            /*" -2170- MOVE 1600 TO ARQHEA-DENSIDADE. */
            _.Move(1600, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DENSIDADE);

            /*" -2174- MOVE ZEROS TO ARQHEA-USOEXCLUSVAN. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_USOEXCLUSVAN);

            /*" -2176- MOVE ARQHEA-REGISTRO TO REG-MOV043350 */
            _.Move(ARQHEA_REGISTRO, REG_MOV043350);

            /*" -2176- WRITE REG-MOV043350. */
            MOV043350_CC.Write(REG_MOV043350.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-SELECT-V0PARAMCON-SECTION */
        private void R3050_00_SELECT_V0PARAMCON_SECTION()
        {
            /*" -2189- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", W.WABEND.WNR_EXEC_SQL);

            /*" -2232- PERFORM R3050_00_SELECT_V0PARAMCON_DB_SELECT_1 */

            R3050_00_SELECT_V0PARAMCON_DB_SELECT_1();

            /*" -2236- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2237- DISPLAY 'R3050-00 - PROBLEMAS NO SELECT(PARAMCON)' */
                _.Display($"R3050-00 - PROBLEMAS NO SELECT(PARAMCON)");

                /*" -2237- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3050-00-SELECT-V0PARAMCON-DB-SELECT-1 */
        public void R3050_00_SELECT_V0PARAMCON_DB_SELECT_1()
        {
            /*" -2232- EXEC SQL SELECT COD_EMPRESA, COD_BANCO , TIPO_MOVTO_CC, COD_PRODUTO , COD_CONVENIO , NSAS , COD_AGENCIA_SASS, OPER_CONTA_SASS, NUM_CONTA_SASS , DIG_CONTA_SASS , DATA_MOVIMENTO , DATA_PROXIMO_DEB, DIA_DEBITO , SIT_REGISTRO , TIMESTAMP , DESCR_CONVENIO INTO :PARAMCON-COD-EMPRESA, :PARAMCON-COD-BANCO, :PARAMCON-TIPO-MOVTO-CC, :PARAMCON-COD-PRODUTO , :PARAMCON-COD-CONVENIO , :PARAMCON-NSAS , :PARAMCON-COD-AGENCIA-SASS, :PARAMCON-OPER-CONTA-SASS, :PARAMCON-NUM-CONTA-SASS, :PARAMCON-DIG-CONTA-SASS, :PARAMCON-DATA-MOVIMENTO, :PARAMCON-DATA-PROXIMO-DEB, :PARAMCON-DIA-DEBITO , :PARAMCON-SIT-REGISTRO, :PARAMCON-TIMESTAMP , :PARAMCON-DESCR-CONVENIO FROM SEGUROS.PARAM_CONTACEF WHERE COD_CONVENIO = 43350 AND SIT_REGISTRO = 'A' AND TIPO_MOVTO_CC = 1 AND COD_PRODUTO IN ( SELECT VALUE(MAX(COD_PRODUTO),0) FROM SEGUROS.PARAM_CONTACEF WHERE COD_CONVENIO = 43350 AND SIT_REGISTRO = 'A' ) WITH UR END-EXEC. */

            var r3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1 = new R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1.Execute(r3050_00_SELECT_V0PARAMCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMCON_COD_EMPRESA, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_EMPRESA);
                _.Move(executed_1.PARAMCON_COD_BANCO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_BANCO);
                _.Move(executed_1.PARAMCON_TIPO_MOVTO_CC, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);
                _.Move(executed_1.PARAMCON_COD_PRODUTO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);
                _.Move(executed_1.PARAMCON_COD_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);
                _.Move(executed_1.PARAMCON_NSAS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS);
                _.Move(executed_1.PARAMCON_COD_AGENCIA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_AGENCIA_SASS);
                _.Move(executed_1.PARAMCON_OPER_CONTA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_OPER_CONTA_SASS);
                _.Move(executed_1.PARAMCON_NUM_CONTA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NUM_CONTA_SASS);
                _.Move(executed_1.PARAMCON_DIG_CONTA_SASS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DIG_CONTA_SASS);
                _.Move(executed_1.PARAMCON_DATA_MOVIMENTO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_MOVIMENTO);
                _.Move(executed_1.PARAMCON_DATA_PROXIMO_DEB, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_PROXIMO_DEB);
                _.Move(executed_1.PARAMCON_DIA_DEBITO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DIA_DEBITO);
                _.Move(executed_1.PARAMCON_SIT_REGISTRO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_SIT_REGISTRO);
                _.Move(executed_1.PARAMCON_TIMESTAMP, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIMESTAMP);
                _.Move(executed_1.PARAMCON_DESCR_CONVENIO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DESCR_CONVENIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-TRAILLER-ARQUIVO-SECTION */
        private void R3100_00_TRAILLER_ARQUIVO_SECTION()
        {
            /*" -2250- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", W.WABEND.WNR_EXEC_SQL);

            /*" -2252- ADD 1 TO AC-QTDREGARQ. */
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -2255- MOVE SPACES TO ARQTRA-REGISTRO. */
            _.Move("", ARQTRA_REGISTRO);

            /*" -2257- MOVE 104 TO ARQTRA-BANCO. */
            _.Move(104, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_BANCO);

            /*" -2259- MOVE 9999 TO ARQTRA-LOTSER. */
            _.Move(9999, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_LOTSER);

            /*" -2262- MOVE 9 TO ARQTRA-TIPOREG. */
            _.Move(9, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_TIPOREG);

            /*" -2264- MOVE AC-QTDLOTE TO ARQTRA-QTDELOTE */
            _.Move(W.AC_QTDLOTE, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDELOTE);

            /*" -2266- MOVE AC-QTDREGARQ TO ARQTRA-QTDEREG. */
            _.Move(W.AC_QTDREGARQ, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDEREG);

            /*" -2270- MOVE ZEROS TO ARQTRA-QTDECONTA. */
            _.Move(0, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDECONTA);

            /*" -2272- MOVE ARQTRA-REGISTRO TO REG-MOV043350 */
            _.Move(ARQTRA_REGISTRO, REG_MOV043350);

            /*" -2272- WRITE REG-MOV043350. */
            MOV043350_CC.Write(REG_MOV043350.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-HEADER-LOTE-SECTION */
        private void R3200_00_HEADER_LOTE_SECTION()
        {
            /*" -2285- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", W.WABEND.WNR_EXEC_SQL);

            /*" -2289- ADD 1 TO AC-QTDLOTE AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_QTDLOTE.Value = W.AC_QTDLOTE + 1;
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -2292- MOVE SPACES TO LOTHEA-REGISTRO. */
            _.Move("", LOTHEA_REGISTRO);

            /*" -2294- MOVE 104 TO LOTHEA-BANCO. */
            _.Move(104, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_BANCO);

            /*" -2296- MOVE AC-QTDLOTE TO LOTHEA-LOTSER. */
            _.Move(W.AC_QTDLOTE, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_LOTSER);

            /*" -2298- MOVE 1 TO LOTHEA-TIPOREG. */
            _.Move(1, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_TIPOREG);

            /*" -2300- MOVE 'C' TO LOTHEA-OPERACAO. */
            _.Move("C", LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_OPERACAO);

            /*" -2302- MOVE 20 TO LOTHEA-TIPSER. */
            _.Move(20, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_TIPSER);

            /*" -2304- MOVE 10 TO LOTHEA-FORMA. */
            _.Move(10, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_FORMA);

            /*" -2307- MOVE 030 TO LOTHEA-VERSAO. */
            _.Move(030, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_VERSAO);

            /*" -2309- MOVE 2 TO LOTHEA-TIPINSC. */
            _.Move(2, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_INSCRICAO.LOTHEA_TIPINSC);

            /*" -2311- MOVE 34020354000110 TO LOTHEA-NROINSC. */
            _.Move(34020354000110, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_INSCRICAO.LOTHEA_NROINSC);

            /*" -2314- MOVE 043350 TO LOTHEA-CONVENIO. */
            _.Move(043350, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONVENIO);

            /*" -2316- MOVE PARAMCON-COD-AGENCIA-SASS TO LOTHEA-AGECONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_AGENCIA_SASS, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_AGECONTA);

            /*" -2318- MOVE SPACES TO LOTHEA-DIGAGENC. */
            _.Move("", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGAGENC);

            /*" -2320- MOVE PARAMCON-OPER-CONTA-SASS TO LOTHEA-OPECONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_OPER_CONTA_SASS, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_OPECONTA);

            /*" -2322- MOVE PARAMCON-NUM-CONTA-SASS TO LOTHEA-NUMCONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NUM_CONTA_SASS, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_NUMCONTA);

            /*" -2325- MOVE PARAMCON-DIG-CONTA-SASS TO LOTHEA-DIGCONTA. */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DIG_CONTA_SASS, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGCONTA);

            /*" -2327- MOVE SPACES TO LOTHEA-DIGAGECTA. */
            _.Move("", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGAGECTA);

            /*" -2329- MOVE 'CAIXA SEGURADORA SA' TO LOTHEA-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_NOMEMPRESA);

            /*" -2331- MOVE 'SCN - QUADRA 01 - BLOCO A     ' TO LOTHEA-LOGRADOURO. */
            _.Move("SCN - QUADRA 01 - BLOCO A     ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_LOGRADOURO);

            /*" -2333- MOVE 00001 TO LOTHEA-NUMERO. */
            _.Move(00001, LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_NUMERO);

            /*" -2335- MOVE 'ED. NUMBER ONE ' TO LOTHEA-COMPLOGRA. */
            _.Move("ED. NUMBER ONE ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_COMPLOGRA);

            /*" -2337- MOVE 'BRASILIA            ' TO LOTHEA-CIDADE. */
            _.Move("BRASILIA            ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_CIDADE);

            /*" -2339- MOVE 70710 TO LOTHEA-CEP. */
            _.Move(70710, LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_CEP);

            /*" -2341- MOVE '500' TO LOTHEA-COMPLCEP. */
            _.Move("500", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_COMPLCEP);

            /*" -2345- MOVE 'DF' TO LOTHEA-SIGLAUF. */
            _.Move("DF", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_SIGLAUF);

            /*" -2347- MOVE LOTHEA-REGISTRO TO REG-MOV043350 */
            _.Move(LOTHEA_REGISTRO, REG_MOV043350);

            /*" -2347- WRITE REG-MOV043350. */
            MOV043350_CC.Write(REG_MOV043350.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-TRAILLER-LOTE-SECTION */
        private void R3300_00_TRAILLER_LOTE_SECTION()
        {
            /*" -2360- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", W.WABEND.WNR_EXEC_SQL);

            /*" -2363- ADD 1 TO AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -2366- MOVE SPACES TO LOTTRA-REGISTRO. */
            _.Move("", LOTTRA_REGISTRO);

            /*" -2368- MOVE 104 TO LOTTRA-BANCO. */
            _.Move(104, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_BANCO);

            /*" -2370- MOVE AC-QTDLOTE TO LOTTRA-LOTSER. */
            _.Move(W.AC_QTDLOTE, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_LOTSER);

            /*" -2373- MOVE 5 TO LOTTRA-TIPOREG. */
            _.Move(5, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_TIPOREG);

            /*" -2375- MOVE AC-QTDREGLOT TO LOTTRA-QTDEREG */
            _.Move(W.AC_QTDREGLOT, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_QTDEREG);

            /*" -2377- MOVE AC-VLRTOTCRE TO LOTTRA-VALOR. */
            _.Move(W.AC_VLRTOTCRE, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_VALOR);

            /*" -2379- MOVE ZEROS TO LOTTRA-QTDEMOEDA. */
            _.Move(0, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_QTDEMOEDA);

            /*" -2383- MOVE ZEROS TO LOTTRA-NRAVISO. */
            _.Move(0, LOTTRA_REGISTRO.LOTTRA_NRAVISO);

            /*" -2385- MOVE LOTTRA-REGISTRO TO REG-MOV043350 */
            _.Move(LOTTRA_REGISTRO, REG_MOV043350);

            /*" -2385- WRITE REG-MOV043350. */
            MOV043350_CC.Write(REG_MOV043350.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2396- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -2397- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -2398- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -2400- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, W.WSQLERR.WSQLERRMC);

            /*" -2401- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -2403- DISPLAY WSQLERR. */
            _.Display(W.WSQLERR);

            /*" -2403- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2409- CLOSE MOVIMENTO MOV043350-CC. */
            MOVIMENTO.Close();
            MOV043350_CC.Close();

            /*" -2411- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2411- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}