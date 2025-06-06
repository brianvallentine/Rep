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
using Sias.Emissao.DB2.EM8020B;

namespace Code
{
    public class EM8020B
    {
        public bool IsCall { get; set; }

        public EM8020B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8020B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  CLOVIS                             *      */
        /*"      *   PROGRAMADOR ............  CLOVIS                             *      */
        /*"      *   DATA CODIFICACAO .......  17/11/2010                         *      */
        /*"      *   VERSAO .................  17/11/2010                         *      */
        /*"      *   DATA REVISAO ...........  21/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  PROCESSA FITA DE RETORNO SIACC     *      */
        /*"      *                             A PARTIR DA LEITURA DO ARQUIVO     *      */
        /*"      *                             GERADO PELO PGM EM8006B, RETORNO   *      */
        /*"      *                             ARQ-H SAP - LEGADO                 *      */
        /*"      *                             CONVENIO 921286 - BANCO DO BRASIL. *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
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
        public FileBasis _MOV921286_CC { get; set; } = new FileBasis(new PIC("X", "240", "X(240)"));

        public FileBasis MOV921286_CC
        {
            get
            {
                _.Move(REG_MOV921286, _MOV921286_CC); VarBasis.RedefinePassValue(REG_MOV921286, _MOV921286_CC, REG_MOV921286); return _MOV921286_CC;
            }
        }
        public SortBasis<EM8020B_REG_SEM8020B> SEM8020B { get; set; } = new SortBasis<EM8020B_REG_SEM8020B>(new EM8020B_REG_SEM8020B());
        /*"01        REG-SEM8020B.*/
        public EM8020B_REG_SEM8020B REG_SEM8020B { get; set; } = new EM8020B_REG_SEM8020B();
        public class EM8020B_REG_SEM8020B : VarBasis
        {
            /*"  05      SCB1-SEQSORT                PIC  9(002).*/
            public IntBasis SCB1_SEQSORT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
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
            /*"  05      SCB1-IND-ESTRUTURA          PIC  9(004).*/
            public IntBasis SCB1_IND_ESTRUTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      SCB1-COD-RETORNO-BANCO      PIC  X(010).*/
            public StringBasis SCB1_COD_RETORNO_BANCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05      SCB1-NUM-SIVAT              PIC  9(009).*/
            public IntBasis SCB1_NUM_SIVAT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"01        REG-MOVIMENTO               PIC  X(300).*/
        }
        public StringBasis REG_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-MOV921286               PIC  X(240).*/
        public StringBasis REG_MOV921286 { get; set; } = new StringBasis(new PIC("X", "240", "X(240)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WVALOR-AUX                PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WVALOR_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WQUOCIENTE                PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WRESTO                    PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-CARTAO               PIC S9(004)     COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W.*/
        public EM8020B_W W { get; set; } = new EM8020B_W();
        public class EM8020B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  WFIM-MOVDEBCE             PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVDEBCE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-ENTRADA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  LD-MV921286               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MV921286 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  TT-SINISTRO               PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis TT_SINISTRO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-ENTRADA                PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
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
            /*"  03  W-CHAVE-EH-SINISTRO-TUTELA PIC X(003) VALUE SPACES.*/
            public StringBasis W_CHAVE_EH_SINISTRO_TUTELA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03  HOST-COUNT                PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  03        WS-IDLG-SIACC       PIC  X(40).*/
            public StringBasis WS_IDLG_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  03         FILLER REDEFINES    WS-IDLG-SIACC.*/
            private _REDEF_EM8020B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM8020B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM8020B_FILLER_0(); _.Move(WS_IDLG_SIACC, _filler_0); VarBasis.RedefinePassValue(WS_IDLG_SIACC, _filler_0, WS_IDLG_SIACC); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_IDLG_SIACC); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_IDLG_SIACC); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_0 : VarBasis
            {
                /*"     10     WS-IDLG-CONVENIO    PIC  9(06).*/
                public IntBasis WS_IDLG_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10     WS-IDLG-NSAS        PIC  9(06).*/
                public IntBasis WS_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10     WS-IDLG-NRSEQ       PIC  9(09).*/
                public IntBasis WS_IDLG_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"     10     WS-IDLG-ORIGEM      PIC  X(04).*/
                public StringBasis WS_IDLG_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10     FILLER              PIC  X(15).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
                /*"  03        WS-IDLG-SINISTRO    PIC  X(40).*/

                public _REDEF_EM8020B_FILLER_0()
                {
                    WS_IDLG_CONVENIO.ValueChanged += OnValueChanged;
                    WS_IDLG_NSAS.ValueChanged += OnValueChanged;
                    WS_IDLG_NRSEQ.ValueChanged += OnValueChanged;
                    WS_IDLG_ORIGEM.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"  03         FILLER REDEFINES    WS-IDLG-SINISTRO.*/
            private _REDEF_EM8020B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_EM8020B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_EM8020B_FILLER_2(); _.Move(WS_IDLG_SINISTRO, _filler_2); VarBasis.RedefinePassValue(WS_IDLG_SINISTRO, _filler_2, WS_IDLG_SINISTRO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WS_IDLG_SINISTRO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WS_IDLG_SINISTRO); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_2 : VarBasis
            {
                /*"     10     FILLER              PIC  X(09).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                /*"     10     WS-IDLG-NRSEQ02     PIC  9(11).*/
                public IntBasis WS_IDLG_NRSEQ02 { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"     10     FILLER              PIC  X(20).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"  03  WS-CONTA10                PIC  X(15)    VALUE  SPACES.*/

                public _REDEF_EM8020B_FILLER_2()
                {
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_IDLG_NRSEQ02.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CONTA10 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"");
            /*"  03  FILLER                    REDEFINES     WS-CONTA10.*/
            private _REDEF_EM8020B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_EM8020B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_EM8020B_FILLER_5(); _.Move(WS_CONTA10, _filler_5); VarBasis.RedefinePassValue(WS_CONTA10, _filler_5, WS_CONTA10); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_CONTA10); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_CONTA10); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_5 : VarBasis
            {
                /*"    10 CHAR10 OCCURS 15 TIMES  PIC  X(01).*/
                public ListBasis<StringBasis, string> CHAR10 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)."), 15);
                /*"  03  WS-CONTA20                PIC  9(15).*/

                public _REDEF_EM8020B_FILLER_5()
                {
                    CHAR10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CONTA20 { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"  03  FILLER                    REDEFINES     WS-CONTA20.*/
            private _REDEF_EM8020B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_EM8020B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_EM8020B_FILLER_6(); _.Move(WS_CONTA20, _filler_6); VarBasis.RedefinePassValue(WS_CONTA20, _filler_6, WS_CONTA20); _filler_6.ValueChanged += () => { _.Move(_filler_6, WS_CONTA20); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WS_CONTA20); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_6 : VarBasis
            {
                /*"    10 CHAR20 OCCURS 15 TIMES  PIC  X(01).*/
                public ListBasis<StringBasis, string> CHAR20 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)."), 15);
                /*"  03  WS-AGENCIA-BB             PIC  9(04).*/

                public _REDEF_EM8020B_FILLER_6()
                {
                    CHAR20.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_AGENCIA_BB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"  03  FILLER                    REDEFINES     WS-AGENCIA-BB.*/
            private _REDEF_EM8020B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_EM8020B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_EM8020B_FILLER_7(); _.Move(WS_AGENCIA_BB, _filler_7); VarBasis.RedefinePassValue(WS_AGENCIA_BB, _filler_7, WS_AGENCIA_BB); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_AGENCIA_BB); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WS_AGENCIA_BB); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_7 : VarBasis
            {
                /*"    10 LAGEN01-1                PIC  9(01).*/
                public IntBasis LAGEN01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 LAGEN01-2                PIC  9(01).*/
                public IntBasis LAGEN01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 LAGEN01-3                PIC  9(01).*/
                public IntBasis LAGEN01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"    10 LAGEN01-4                PIC  9(01).*/
                public IntBasis LAGEN01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"  03  WS-DV-BB                  PIC  9(01).*/

                public _REDEF_EM8020B_FILLER_7()
                {
                    LAGEN01_1.ValueChanged += OnValueChanged;
                    LAGEN01_2.ValueChanged += OnValueChanged;
                    LAGEN01_3.ValueChanged += OnValueChanged;
                    LAGEN01_4.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DV_BB { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
            /*"  03  WS-DV-BB-X                REDEFINES     WS-DV-BB                                PIC  X(01).*/
            private _REDEF_StringBasis _ws_dv_bb_x { get; set; }
            public _REDEF_StringBasis WS_DV_BB_X
            {
                get { _ws_dv_bb_x = new _REDEF_StringBasis(new PIC("X", "01", "X(01).")); ; _.Move(WS_DV_BB, _ws_dv_bb_x); VarBasis.RedefinePassValue(WS_DV_BB, _ws_dv_bb_x, WS_DV_BB); _ws_dv_bb_x.ValueChanged += () => { _.Move(_ws_dv_bb_x, WS_DV_BB); }; return _ws_dv_bb_x; }
                set { VarBasis.RedefinePassValue(value, _ws_dv_bb_x, WS_DV_BB); }
            }  //Redefines
            /*"  03         WTIME-DAY          PIC  99.99.99.99.*/
            public IntBasis WTIME_DAY { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"  03         FILLER             REDEFINES      WTIME-DAY.*/
            private _REDEF_EM8020B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_EM8020B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_EM8020B_FILLER_8(); _.Move(WTIME_DAY, _filler_8); VarBasis.RedefinePassValue(WTIME_DAY, _filler_8, WTIME_DAY); _filler_8.ValueChanged += () => { _.Move(_filler_8, WTIME_DAY); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WTIME_DAY); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_8 : VarBasis
            {
                /*"    05       WTIME-DAYR.*/
                public EM8020B_WTIME_DAYR WTIME_DAYR { get; set; } = new EM8020B_WTIME_DAYR();
                public class EM8020B_WTIME_DAYR : VarBasis
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

                    public EM8020B_WTIME_DAYR()
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

                public _REDEF_EM8020B_FILLER_8()
                {
                    WTIME_DAYR.ValueChanged += OnValueChanged;
                    WTIME_2PT3.ValueChanged += OnValueChanged;
                    WTIME_CCSE.ValueChanged += OnValueChanged;
                }

            }
            public EM8020B_WS_TIME WS_TIME { get; set; } = new EM8020B_WS_TIME();
            public class EM8020B_WS_TIME : VarBasis
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
            private _REDEF_EM8020B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_EM8020B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_EM8020B_FILLER_9(); _.Move(WDATA_REL, _filler_9); VarBasis.RedefinePassValue(WDATA_REL, _filler_9, WDATA_REL); _filler_9.ValueChanged += () => { _.Move(_filler_9, WDATA_REL); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_9 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_EM8020B_FILLER_9()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public EM8020B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8020B_WDATA_CABEC();
            public class EM8020B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WHORA-CURR.*/
            }
            public EM8020B_WHORA_CURR WHORA_CURR { get; set; } = new EM8020B_WHORA_CURR();
            public class EM8020B_WHORA_CURR : VarBasis
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
            public EM8020B_WHORA_CABEC WHORA_CABEC { get; set; } = new EM8020B_WHORA_CABEC();
            public class EM8020B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         CTA-CONTACEF      PIC  X(028)    VALUE SPACES.*/
            }
            public StringBasis CTA_CONTACEF { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
            /*"  03         FILLER            REDEFINES      CTA-CONTACEF.*/
            private _REDEF_EM8020B_FILLER_16 _filler_16 { get; set; }
            public _REDEF_EM8020B_FILLER_16 FILLER_16
            {
                get { _filler_16 = new _REDEF_EM8020B_FILLER_16(); _.Move(CTA_CONTACEF, _filler_16); VarBasis.RedefinePassValue(CTA_CONTACEF, _filler_16, CTA_CONTACEF); _filler_16.ValueChanged += () => { _.Move(_filler_16, CTA_CONTACEF); }; return _filler_16; }
                set { VarBasis.RedefinePassValue(value, _filler_16, CTA_CONTACEF); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_16 : VarBasis
            {
                /*"    10       CTA-BCOCEF        PIC  9(003).*/
                public IntBasis CTA_BCOCEF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-AGECEF        PIC  9(004).*/
                public IntBasis CTA_AGECEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-OPECEF        PIC  9(004).*/
                public IntBasis CTA_OPECEF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-CTACEF        PIC  9(012).*/
                public IntBasis CTA_CTACEF { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-DIGCEF        PIC  X(001).*/
                public StringBasis CTA_DIGCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         CTA-CONTAOUT      PIC  X(025)    VALUE SPACES.*/

                public _REDEF_EM8020B_FILLER_16()
                {
                    CTA_BCOCEF.ValueChanged += OnValueChanged;
                    FILLER_17.ValueChanged += OnValueChanged;
                    CTA_AGECEF.ValueChanged += OnValueChanged;
                    FILLER_18.ValueChanged += OnValueChanged;
                    CTA_OPECEF.ValueChanged += OnValueChanged;
                    FILLER_19.ValueChanged += OnValueChanged;
                    CTA_CTACEF.ValueChanged += OnValueChanged;
                    FILLER_20.ValueChanged += OnValueChanged;
                    CTA_DIGCEF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis CTA_CONTAOUT { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  03         FILLER            REDEFINES      CTA-CONTAOUT.*/
            private _REDEF_EM8020B_FILLER_21 _filler_21 { get; set; }
            public _REDEF_EM8020B_FILLER_21 FILLER_21
            {
                get { _filler_21 = new _REDEF_EM8020B_FILLER_21(); _.Move(CTA_CONTAOUT, _filler_21); VarBasis.RedefinePassValue(CTA_CONTAOUT, _filler_21, CTA_CONTAOUT); _filler_21.ValueChanged += () => { _.Move(_filler_21, CTA_CONTAOUT); }; return _filler_21; }
                set { VarBasis.RedefinePassValue(value, _filler_21, CTA_CONTAOUT); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_21 : VarBasis
            {
                /*"    10       CTA-BCOOUT        PIC  9(003).*/
                public IntBasis CTA_BCOOUT { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-AGEOUT        PIC  9(004).*/
                public IntBasis CTA_AGEOUT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-CTAOUT        PIC  9(012).*/
                public IntBasis CTA_CTAOUT { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       CTA-DIGOUT        PIC  X(003).*/
                public StringBasis CTA_DIGOUT { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"  03         WS-DIGCTA         PIC  X(003)    VALUE SPACES.*/

                public _REDEF_EM8020B_FILLER_21()
                {
                    CTA_BCOOUT.ValueChanged += OnValueChanged;
                    FILLER_22.ValueChanged += OnValueChanged;
                    CTA_AGEOUT.ValueChanged += OnValueChanged;
                    FILLER_23.ValueChanged += OnValueChanged;
                    CTA_CTAOUT.ValueChanged += OnValueChanged;
                    FILLER_24.ValueChanged += OnValueChanged;
                    CTA_DIGOUT.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DIGCTA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  03         FILLER            REDEFINES      WS-DIGCTA.*/
            private _REDEF_EM8020B_FILLER_25 _filler_25 { get; set; }
            public _REDEF_EM8020B_FILLER_25 FILLER_25
            {
                get { _filler_25 = new _REDEF_EM8020B_FILLER_25(); _.Move(WS_DIGCTA, _filler_25); VarBasis.RedefinePassValue(WS_DIGCTA, _filler_25, WS_DIGCTA); _filler_25.ValueChanged += () => { _.Move(_filler_25, WS_DIGCTA); }; return _filler_25; }
                set { VarBasis.RedefinePassValue(value, _filler_25, WS_DIGCTA); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_25 : VarBasis
            {
                /*"    10       WS-DIGCTA1        PIC  X(001).*/
                public StringBasis WS_DIGCTA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIGCTA2        PIC  X(001).*/
                public StringBasis WS_DIGCTA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIGCTA3        PIC  X(001).*/
                public StringBasis WS_DIGCTA3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  03         WS-NUMERO          PIC  9(016)  VALUE   ZEROS.*/

                public _REDEF_EM8020B_FILLER_25()
                {
                    WS_DIGCTA1.ValueChanged += OnValueChanged;
                    WS_DIGCTA2.ValueChanged += OnValueChanged;
                    WS_DIGCTA3.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUMERO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER             REDEFINES    WS-NUMERO.*/
            private _REDEF_EM8020B_FILLER_26 _filler_26 { get; set; }
            public _REDEF_EM8020B_FILLER_26 FILLER_26
            {
                get { _filler_26 = new _REDEF_EM8020B_FILLER_26(); _.Move(WS_NUMERO, _filler_26); VarBasis.RedefinePassValue(WS_NUMERO, _filler_26, WS_NUMERO); _filler_26.ValueChanged += () => { _.Move(_filler_26, WS_NUMERO); }; return _filler_26; }
                set { VarBasis.RedefinePassValue(value, _filler_26, WS_NUMERO); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_26 : VarBasis
            {
                /*"    10       WS-OPERACAO        PIC  9(004).*/
                public IntBasis WS_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-NUMCONTA        PIC  9(012).*/
                public IntBasis WS_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"  03         WS-CPF             PIC  9(014)  VALUE   ZEROS.*/

                public _REDEF_EM8020B_FILLER_26()
                {
                    WS_OPERACAO.ValueChanged += OnValueChanged;
                    WS_NUMCONTA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES    WS-CPF.*/
            private _REDEF_EM8020B_FILLER_27 _filler_27 { get; set; }
            public _REDEF_EM8020B_FILLER_27 FILLER_27
            {
                get { _filler_27 = new _REDEF_EM8020B_FILLER_27(); _.Move(WS_CPF, _filler_27); VarBasis.RedefinePassValue(WS_CPF, _filler_27, WS_CPF); _filler_27.ValueChanged += () => { _.Move(_filler_27, WS_CPF); }; return _filler_27; }
                set { VarBasis.RedefinePassValue(value, _filler_27, WS_CPF); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_27 : VarBasis
            {
                /*"    10       WS-NUM-CPF         PIC  9(012).*/
                public IntBasis WS_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"    10       WS-DIG-CPF         PIC  9(002).*/
                public IntBasis WS_DIG_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-CNPJ            PIC  9(014)  VALUE   ZEROS.*/

                public _REDEF_EM8020B_FILLER_27()
                {
                    WS_NUM_CPF.ValueChanged += OnValueChanged;
                    WS_DIG_CPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"  03         FILLER             REDEFINES    WS-CNPJ.*/
            private _REDEF_EM8020B_FILLER_28 _filler_28 { get; set; }
            public _REDEF_EM8020B_FILLER_28 FILLER_28
            {
                get { _filler_28 = new _REDEF_EM8020B_FILLER_28(); _.Move(WS_CNPJ, _filler_28); VarBasis.RedefinePassValue(WS_CNPJ, _filler_28, WS_CNPJ); _filler_28.ValueChanged += () => { _.Move(_filler_28, WS_CNPJ); }; return _filler_28; }
                set { VarBasis.RedefinePassValue(value, _filler_28, WS_CNPJ); }
            }  //Redefines
            public class _REDEF_EM8020B_FILLER_28 : VarBasis
            {
                /*"    10       WS-NUM-CNPJ        PIC  9(008).*/
                public IntBasis WS_NUM_CNPJ { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    10       WS-NUM-FILIAL      PIC  9(004).*/
                public IntBasis WS_NUM_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-DIG-CNPJ        PIC  9(002).*/
                public IntBasis WS_DIG_CNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WABEND.*/

                public _REDEF_EM8020B_FILLER_28()
                {
                    WS_NUM_CNPJ.ValueChanged += OnValueChanged;
                    WS_NUM_FILIAL.ValueChanged += OnValueChanged;
                    WS_DIG_CNPJ.ValueChanged += OnValueChanged;
                }

            }
            public EM8020B_WABEND WABEND { get; set; } = new EM8020B_WABEND();
            public class EM8020B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8020B  '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8020B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03        WSQLERR.*/
            }
            public EM8020B_WSQLERR WSQLERR { get; set; } = new EM8020B_WSQLERR();
            public class EM8020B_WSQLERR : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01          ARQHEA-REGISTRO.*/
            }
        }
        public EM8020B_ARQHEA_REGISTRO ARQHEA_REGISTRO { get; set; } = new EM8020B_ARQHEA_REGISTRO();
        public class EM8020B_ARQHEA_REGISTRO : VarBasis
        {
            /*"  05        ARQHEA-CONTROLE.*/
            public EM8020B_ARQHEA_CONTROLE ARQHEA_CONTROLE { get; set; } = new EM8020B_ARQHEA_CONTROLE();
            public class EM8020B_ARQHEA_CONTROLE : VarBasis
            {
                /*"    10      ARQHEA-BANCO           PIC  9(003).*/
                public IntBasis ARQHEA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      ARQHEA-LOTSER          PIC  9(004).*/
                public IntBasis ARQHEA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      ARQHEA-TIPOREG         PIC  9(001).*/
                public IntBasis ARQHEA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        ARQHEA-EMPRESA.*/
            public EM8020B_ARQHEA_EMPRESA ARQHEA_EMPRESA { get; set; } = new EM8020B_ARQHEA_EMPRESA();
            public class EM8020B_ARQHEA_EMPRESA : VarBasis
            {
                /*"    10      ARQHEA-INSCRICAO.*/
                public EM8020B_ARQHEA_INSCRICAO ARQHEA_INSCRICAO { get; set; } = new EM8020B_ARQHEA_INSCRICAO();
                public class EM8020B_ARQHEA_INSCRICAO : VarBasis
                {
                    /*"      15    ARQHEA-TIPINSC         PIC  9(001).*/
                    public IntBasis ARQHEA_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    ARQHEA-NROINSC         PIC  9(014).*/
                    public IntBasis ARQHEA_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    10      ARQHEA-CONVENIO        PIC  X(020).*/
                }
                public StringBasis ARQHEA_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10      ARQHEA-CONTA.*/
                public EM8020B_ARQHEA_CONTA ARQHEA_CONTA { get; set; } = new EM8020B_ARQHEA_CONTA();
                public class EM8020B_ARQHEA_CONTA : VarBasis
                {
                    /*"      15    ARQHEA-AGECONTA        PIC  9(005).*/
                    public IntBasis ARQHEA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    ARQHEA-DIGAGENC        PIC  X(001).*/
                    public StringBasis ARQHEA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    ARQHEA-NUMCONTA        PIC  9(012).*/
                    public IntBasis ARQHEA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15    ARQHEA-DIGCONTA        PIC  X(001).*/
                    public StringBasis ARQHEA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    ARQHEA-DIGAGECTA       PIC  X(001).*/
                    public StringBasis ARQHEA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      ARQHEA-NOMEMPRESA      PIC  X(030).*/
                }
                public StringBasis ARQHEA_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        ARQHEA-NOMEBANCO       PIC  X(030).*/
            }
            public StringBasis ARQHEA_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05        FILLER                 PIC  X(010).*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        ARQHEA-ARQUIVO.*/
            public EM8020B_ARQHEA_ARQUIVO ARQHEA_ARQUIVO { get; set; } = new EM8020B_ARQHEA_ARQUIVO();
            public class EM8020B_ARQHEA_ARQUIVO : VarBasis
            {
                /*"    10      ARQHEA-REMESSA         PIC  9(001).*/
                public IntBasis ARQHEA_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10      ARQHEA-DATAGERACAO.*/
                public EM8020B_ARQHEA_DATAGERACAO ARQHEA_DATAGERACAO { get; set; } = new EM8020B_ARQHEA_DATAGERACAO();
                public class EM8020B_ARQHEA_DATAGERACAO : VarBasis
                {
                    /*"      15    ARQHEA-DIAGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_DIAGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    ARQHEA-MESGERA         PIC  9(002).*/
                    public IntBasis ARQHEA_MESGERA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    ARQHEA-ANOGERA         PIC  9(004).*/
                    public IntBasis ARQHEA_ANOGERA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      ARQHEA-HORAGERACAO.*/
                }
                public EM8020B_ARQHEA_HORAGERACAO ARQHEA_HORAGERACAO { get; set; } = new EM8020B_ARQHEA_HORAGERACAO();
                public class EM8020B_ARQHEA_HORAGERACAO : VarBasis
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
                /*"  05        ARQHEA-USOBANCO.*/
            }
            public EM8020B_ARQHEA_USOBANCO ARQHEA_USOBANCO { get; set; } = new EM8020B_ARQHEA_USOBANCO();
            public class EM8020B_ARQHEA_USOBANCO : VarBasis
            {
                /*"    10      ARQHEA-BANCO01         PIC  X(009).*/
                public StringBasis ARQHEA_BANCO01 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"    10      ARQHEA-BANCO02         PIC  X(011).*/
                public StringBasis ARQHEA_BANCO02 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"  05        ARQHEA-USOEMPRESA      PIC  X(020).*/
            }
            public StringBasis ARQHEA_USOEMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05        ARQHEA-USO01           PIC  X(017).*/
            public StringBasis ARQHEA_USO01 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"  05        ARQHEA-TIPOSER         PIC  X(002).*/
            public StringBasis ARQHEA_TIPOSER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05        FILLER                 PIC  X(010).*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          ARQTRA-REGISTRO.*/
        }
        public EM8020B_ARQTRA_REGISTRO ARQTRA_REGISTRO { get; set; } = new EM8020B_ARQTRA_REGISTRO();
        public class EM8020B_ARQTRA_REGISTRO : VarBasis
        {
            /*"  05        ARQTRA-CONTROLE.*/
            public EM8020B_ARQTRA_CONTROLE ARQTRA_CONTROLE { get; set; } = new EM8020B_ARQTRA_CONTROLE();
            public class EM8020B_ARQTRA_CONTROLE : VarBasis
            {
                /*"    10      ARQTRA-BANCO           PIC  9(003).*/
                public IntBasis ARQTRA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      ARQTRA-LOTSER          PIC  9(004).*/
                public IntBasis ARQTRA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      ARQTRA-TIPOREG         PIC  9(001).*/
                public IntBasis ARQTRA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        ARQTRA-TOTAIS.*/
            public EM8020B_ARQTRA_TOTAIS ARQTRA_TOTAIS { get; set; } = new EM8020B_ARQTRA_TOTAIS();
            public class EM8020B_ARQTRA_TOTAIS : VarBasis
            {
                /*"    10      ARQTRA-QTDELOTE        PIC  9(006).*/
                public IntBasis ARQTRA_QTDELOTE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQTRA-QTDEREG         PIC  9(006).*/
                public IntBasis ARQTRA_QTDEREG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    10      ARQTRA-QTDECONTA       PIC  9(006).*/
                public IntBasis ARQTRA_QTDECONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"  05        FILLER                 PIC  X(205).*/
            }
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "205", "X(205)."), @"");
            /*"01          LOTHEA-REGISTRO.*/
        }
        public EM8020B_LOTHEA_REGISTRO LOTHEA_REGISTRO { get; set; } = new EM8020B_LOTHEA_REGISTRO();
        public class EM8020B_LOTHEA_REGISTRO : VarBasis
        {
            /*"  05        LOTHEA-CONTROLE.*/
            public EM8020B_LOTHEA_CONTROLE LOTHEA_CONTROLE { get; set; } = new EM8020B_LOTHEA_CONTROLE();
            public class EM8020B_LOTHEA_CONTROLE : VarBasis
            {
                /*"    10      LOTHEA-BANCO           PIC  9(003).*/
                public IntBasis LOTHEA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      LOTHEA-LOTSER          PIC  9(004).*/
                public IntBasis LOTHEA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTHEA-TIPOREG         PIC  9(001).*/
                public IntBasis LOTHEA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        LOTHEA-SERVICO.*/
            }
            public EM8020B_LOTHEA_SERVICO LOTHEA_SERVICO { get; set; } = new EM8020B_LOTHEA_SERVICO();
            public class EM8020B_LOTHEA_SERVICO : VarBasis
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
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05        LOTHEA-EMPRESA.*/
            public EM8020B_LOTHEA_EMPRESA LOTHEA_EMPRESA { get; set; } = new EM8020B_LOTHEA_EMPRESA();
            public class EM8020B_LOTHEA_EMPRESA : VarBasis
            {
                /*"    10      LOTHEA-INSCRICAO.*/
                public EM8020B_LOTHEA_INSCRICAO LOTHEA_INSCRICAO { get; set; } = new EM8020B_LOTHEA_INSCRICAO();
                public class EM8020B_LOTHEA_INSCRICAO : VarBasis
                {
                    /*"      15    LOTHEA-TIPINSC         PIC  9(001).*/
                    public IntBasis LOTHEA_TIPINSC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    LOTHEA-NROINSC         PIC  9(014).*/
                    public IntBasis LOTHEA_NROINSC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"    10      LOTHEA-CONVENIO        PIC  X(020).*/
                }
                public StringBasis LOTHEA_CONVENIO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    10      LOTHEA-CONTA.*/
                public EM8020B_LOTHEA_CONTA LOTHEA_CONTA { get; set; } = new EM8020B_LOTHEA_CONTA();
                public class EM8020B_LOTHEA_CONTA : VarBasis
                {
                    /*"      15    LOTHEA-AGECONTA        PIC  9(005).*/
                    public IntBasis LOTHEA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    LOTHEA-DIGAGENC        PIC  X(001).*/
                    public StringBasis LOTHEA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LOTHEA-NUMCONTA        PIC  9(012).*/
                    public IntBasis LOTHEA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                    /*"      15    LOTHEA-DIGCONTA        PIC  X(001).*/
                    public StringBasis LOTHEA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LOTHEA-DIGAGECTA       PIC  X(001).*/
                    public StringBasis LOTHEA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      LOTHEA-NOMEMPRESA      PIC  X(030).*/
                }
                public StringBasis LOTHEA_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        LOTHEA-MENSAGEM        PIC  X(040).*/
            }
            public StringBasis LOTHEA_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05        LOTHEA-ENDERECO.*/
            public EM8020B_LOTHEA_ENDERECO LOTHEA_ENDERECO { get; set; } = new EM8020B_LOTHEA_ENDERECO();
            public class EM8020B_LOTHEA_ENDERECO : VarBasis
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
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  05        LOTHEA-OCORRENCIA      PIC  X(010).*/
            public StringBasis LOTHEA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          LOTTRA-REGISTRO.*/
        }
        public EM8020B_LOTTRA_REGISTRO LOTTRA_REGISTRO { get; set; } = new EM8020B_LOTTRA_REGISTRO();
        public class EM8020B_LOTTRA_REGISTRO : VarBasis
        {
            /*"  05        LOTTRA-CONTROLE.*/
            public EM8020B_LOTTRA_CONTROLE LOTTRA_CONTROLE { get; set; } = new EM8020B_LOTTRA_CONTROLE();
            public class EM8020B_LOTTRA_CONTROLE : VarBasis
            {
                /*"    10      LOTTRA-BANCO           PIC  9(003).*/
                public IntBasis LOTTRA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      LOTTRA-LOTSER          PIC  9(004).*/
                public IntBasis LOTTRA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      LOTTRA-TIPOREG         PIC  9(001).*/
                public IntBasis LOTTRA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        FILLER                 PIC  X(009).*/
            }
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05        LOTTRA-TOTAIS.*/
            public EM8020B_LOTTRA_TOTAIS LOTTRA_TOTAIS { get; set; } = new EM8020B_LOTTRA_TOTAIS();
            public class EM8020B_LOTTRA_TOTAIS : VarBasis
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
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "165", "X(165)."), @"");
            /*"  05        LOTTRA-OCORRENCIA      PIC  X(010).*/
            public StringBasis LOTTRA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          DETSEGA-REGISTRO.*/
        }
        public EM8020B_DETSEGA_REGISTRO DETSEGA_REGISTRO { get; set; } = new EM8020B_DETSEGA_REGISTRO();
        public class EM8020B_DETSEGA_REGISTRO : VarBasis
        {
            /*"  05        DETSEGA-CONTROLE.*/
            public EM8020B_DETSEGA_CONTROLE DETSEGA_CONTROLE { get; set; } = new EM8020B_DETSEGA_CONTROLE();
            public class EM8020B_DETSEGA_CONTROLE : VarBasis
            {
                /*"    10      DETSEGA-BANCO          PIC  9(003).*/
                public IntBasis DETSEGA_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGA_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGA-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGA_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGA-SERVICO.*/
            }
            public EM8020B_DETSEGA_SERVICO DETSEGA_SERVICO { get; set; } = new EM8020B_DETSEGA_SERVICO();
            public class EM8020B_DETSEGA_SERVICO : VarBasis
            {
                /*"    10      DETSEGA-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGA_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGA-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGA_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DETSEGA-MOVIMENTO.*/
                public EM8020B_DETSEGA_MOVIMENTO DETSEGA_MOVIMENTO { get; set; } = new EM8020B_DETSEGA_MOVIMENTO();
                public class EM8020B_DETSEGA_MOVIMENTO : VarBasis
                {
                    /*"      15    DETSEGA-TIPOMOV        PIC  9(001).*/
                    public IntBasis DETSEGA_TIPOMOV { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"      15    DETSEGA-INSTRUCAO      PIC  9(002).*/
                    public IntBasis DETSEGA_INSTRUCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"  05        DETSEGA-FAVORECIDO.*/
                }
            }
            public EM8020B_DETSEGA_FAVORECIDO DETSEGA_FAVORECIDO { get; set; } = new EM8020B_DETSEGA_FAVORECIDO();
            public class EM8020B_DETSEGA_FAVORECIDO : VarBasis
            {
                /*"    10      DETSEGA-CAMARA         PIC  9(003).*/
                public IntBasis DETSEGA_CAMARA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-BANCOFAV       PIC  9(003).*/
                public IntBasis DETSEGA_BANCOFAV { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGA-CONTA.*/
                public EM8020B_DETSEGA_CONTA DETSEGA_CONTA { get; set; } = new EM8020B_DETSEGA_CONTA();
                public class EM8020B_DETSEGA_CONTA : VarBasis
                {
                    /*"      15    DETSEGA-AGECONTA       PIC  9(005).*/
                    public IntBasis DETSEGA_AGECONTA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                    /*"      15    DETSEGA-DIGAGENC       PIC  X(001).*/
                    public StringBasis DETSEGA_DIGAGENC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    DETSEGA-NUMCONTA       PIC  9(016).*/
                    public IntBasis DETSEGA_NUMCONTA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
                    /*"      15    DETSEGA-DIGCONTA       PIC  X(001).*/
                    public StringBasis DETSEGA_DIGCONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    DETSEGA-DIGAGECTA      PIC  X(001).*/
                    public StringBasis DETSEGA_DIGAGECTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    10      DETSEGA-NOMEFAV        PIC  X(030).*/
                }
                public StringBasis DETSEGA_NOMEFAV { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05        DETSEGA-CREDITO.*/
            }
            public EM8020B_DETSEGA_CREDITO DETSEGA_CREDITO { get; set; } = new EM8020B_DETSEGA_CREDITO();
            public class EM8020B_DETSEGA_CREDITO : VarBasis
            {
                /*"    10      DETSEGA-NROEMPRE.*/
                public EM8020B_DETSEGA_NROEMPRE DETSEGA_NROEMPRE { get; set; } = new EM8020B_DETSEGA_NROEMPRE();
                public class EM8020B_DETSEGA_NROEMPRE : VarBasis
                {
                    /*"      15    DETSEGA-NRSEQ01        PIC  9(009).*/
                    public IntBasis DETSEGA_NRSEQ01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"      15    DETSEGA-NRSEQ02        PIC  9(011).*/
                    public IntBasis DETSEGA_NRSEQ02 { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                    /*"    10      DETSEGA-DATAPAGTO.*/
                }
                public EM8020B_DETSEGA_DATAPAGTO DETSEGA_DATAPAGTO { get; set; } = new EM8020B_DETSEGA_DATAPAGTO();
                public class EM8020B_DETSEGA_DATAPAGTO : VarBasis
                {
                    /*"      15    DETSEGA-DIAPAG         PIC  9(002).*/
                    public IntBasis DETSEGA_DIAPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-MESPAG         PIC  9(002).*/
                    public IntBasis DETSEGA_MESPAG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    DETSEGA-ANOPAG         PIC  9(004).*/
                    public IntBasis DETSEGA_ANOPAG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    10      DETSEGA-MOEDA.*/
                }
                public EM8020B_DETSEGA_MOEDA DETSEGA_MOEDA { get; set; } = new EM8020B_DETSEGA_MOEDA();
                public class EM8020B_DETSEGA_MOEDA : VarBasis
                {
                    /*"      15    DETSEGA-TIPOMOEDA      PIC  X(003).*/
                    public StringBasis DETSEGA_TIPOMOEDA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                    /*"      15    DETSEGA-QTDEMOEDA      PIC  9(010)V99999.*/
                    public DoubleBasis DETSEGA_QTDEMOEDA { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99999."), 5);
                    /*"    10      DETSEGA-VALPAGTO       PIC  9(013)V99.*/
                }
                public DoubleBasis DETSEGA_VALPAGTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    10      DETSEGA-NUM-DOC-BANCO  PIC  9(009).*/
                public IntBasis DETSEGA_NUM_DOC_BANCO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"    10      FILLER                 PIC  X(011).*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)."), @"");
                /*"    10      DETSEGA-DATAREAL.*/
                public EM8020B_DETSEGA_DATAREAL DETSEGA_DATAREAL { get; set; } = new EM8020B_DETSEGA_DATAREAL();
                public class EM8020B_DETSEGA_DATAREAL : VarBasis
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
            /*"  05        FILLER                 PIC  X(006).*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05        DETSEGA-AVISO          PIC  9(001).*/
            public IntBasis DETSEGA_AVISO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05        DETSEGA-OCORRENCIA     PIC  X(010).*/
            public StringBasis DETSEGA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"01          DETSEGB-REGISTRO.*/
        }
        public EM8020B_DETSEGB_REGISTRO DETSEGB_REGISTRO { get; set; } = new EM8020B_DETSEGB_REGISTRO();
        public class EM8020B_DETSEGB_REGISTRO : VarBasis
        {
            /*"  05        DETSEGB-CONTROLE.*/
            public EM8020B_DETSEGB_CONTROLE DETSEGB_CONTROLE { get; set; } = new EM8020B_DETSEGB_CONTROLE();
            public class EM8020B_DETSEGB_CONTROLE : VarBasis
            {
                /*"    10      DETSEGB-BANCO          PIC  9(003).*/
                public IntBasis DETSEGB_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10      DETSEGB-LOTSER         PIC  9(004).*/
                public IntBasis DETSEGB_LOTSER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DETSEGB-TIPOREG        PIC  9(001).*/
                public IntBasis DETSEGB_TIPOREG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05        DETSEGB-SERVICO.*/
            }
            public EM8020B_DETSEGB_SERVICO DETSEGB_SERVICO { get; set; } = new EM8020B_DETSEGB_SERVICO();
            public class EM8020B_DETSEGB_SERVICO : VarBasis
            {
                /*"    10      DETSEGB-NUMREG         PIC  9(005).*/
                public IntBasis DETSEGB_NUMREG { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    10      DETSEGB-SEGMENTO       PIC  X(001).*/
                public StringBasis DETSEGB_SEGMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05        FILLER                 PIC  X(003).*/
            }
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05        DETSEGB-COMPLEMENTO.*/
            public EM8020B_DETSEGB_COMPLEMENTO DETSEGB_COMPLEMENTO { get; set; } = new EM8020B_DETSEGB_COMPLEMENTO();
            public class EM8020B_DETSEGB_COMPLEMENTO : VarBasis
            {
                /*"    10      DETSEGB-FAVORECIDO.*/
                public EM8020B_DETSEGB_FAVORECIDO DETSEGB_FAVORECIDO { get; set; } = new EM8020B_DETSEGB_FAVORECIDO();
                public class EM8020B_DETSEGB_FAVORECIDO : VarBasis
                {
                    /*"      15    DETSEGB-INSCRICAO.*/
                    public EM8020B_DETSEGB_INSCRICAO DETSEGB_INSCRICAO { get; set; } = new EM8020B_DETSEGB_INSCRICAO();
                    public class EM8020B_DETSEGB_INSCRICAO : VarBasis
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
                public EM8020B_DETSEGB_PAGTO DETSEGB_PAGTO { get; set; } = new EM8020B_DETSEGB_PAGTO();
                public class EM8020B_DETSEGB_PAGTO : VarBasis
                {
                    /*"      15    DETSEGB-DATAVENCTO.*/
                    public EM8020B_DETSEGB_DATAVENCTO DETSEGB_DATAVENCTO { get; set; } = new EM8020B_DETSEGB_DATAVENCTO();
                    public class EM8020B_DETSEGB_DATAVENCTO : VarBasis
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
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"01        REG-SIACC.*/
        }
        public EM8020B_REG_SIACC REG_SIACC { get; set; } = new EM8020B_REG_SIACC();
        public class EM8020B_REG_SIACC : VarBasis
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
        public Dclgens.GE366 GE366 { get; set; } = new Dclgens.GE366();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public Dclgens.GE369 GE369 { get; set; } = new Dclgens.GE369();
        public Dclgens.OD001 OD001 { get; set; } = new Dclgens.OD001();
        public Dclgens.OD002 OD002 { get; set; } = new Dclgens.OD002();
        public Dclgens.OD003 OD003 { get; set; } = new Dclgens.OD003();
        public Dclgens.OD007 OD007 { get; set; } = new Dclgens.OD007();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SEM8020B_FILE_NAME_P, string MOVIMENTO_FILE_NAME_P, string MOV921286_CC_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SEM8020B.SetFile(SEM8020B_FILE_NAME_P);
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);
                MOV921286_CC.SetFile(MOV921286_CC_FILE_NAME_P);

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
            /*" -591- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", W.WABEND.WNR_EXEC_SQL);

            /*" -592- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -594- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -596- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -602- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -610- SORT SEM8020B ON ASCENDING KEY SCB1-SEQSORT SCB1-OCORR-MOVTO INPUT PROCEDURE R0200-00-SELECIONA THRU R0200-99-SAIDA OUTPUT PROCEDURE R0700-00-PROCESSA-SORT THRU R0700-99-SAIDA. */
            SEM8020B.Sort("SCB1-SEQSORT,SCB1-OCORR-MOVTO", () => R0200_00_SELECIONA_SECTION(), () => R0700_00_PROCESSA_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -615- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -620- CLOSE MOVIMENTO MOV921286-CC. */
            MOVIMENTO.Close();
            MOV921286_CC.Close();

            /*" -622- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -623- DISPLAY ' ' */
            _.Display($" ");

            /*" -626- DISPLAY 'EM8020B - FIM NORMAL' . */
            _.Display($"EM8020B - FIM NORMAL");

            /*" -626- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -639- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -640- DISPLAY ' EM8020B - INICIO PROCESSAMENTO ' . */
            _.Display($" EM8020B - INICIO PROCESSAMENTO ");

            /*" -642- DISPLAY ' ' . */
            _.Display($" ");

            /*" -643- OPEN INPUT MOVIMENTO */
            MOVIMENTO.Open(REG_MOVIMENTO);

            /*" -646- OUTPUT MOV921286-CC. */
            MOV921286_CC.Open(REG_MOV921286);

            /*" -650- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -652- MOVE '000 0000.0000.000000000000- ' TO CTA-CONTACEF. */
            _.Move("000 0000.0000.000000000000- ", W.CTA_CONTACEF);

            /*" -656- MOVE '000 0000.000000000000-   ' TO CTA-CONTAOUT. */
            _.Move("000 0000.000000000000-   ", W.CTA_CONTAOUT);

            /*" -656- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -669- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", W.WABEND.WNR_EXEC_SQL);

            /*" -675- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -679- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -680- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -683- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -685- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -685- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -675- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

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
            /*" -698- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", W.WABEND.WNR_EXEC_SQL);

            /*" -705- MOVE ZEROS TO LD-ENTRADA LD-MV921286 TT-SINISTRO DP-ENTRADA GV-SORT. */
            _.Move(0, W.LD_ENTRADA, W.LD_MV921286, W.TT_SINISTRO, W.DP_ENTRADA, W.GV_SORT);

            /*" -707- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -709- PERFORM R0210-00-LER-ENTRADA. */

            R0210_00_LER_ENTRADA_SECTION();

            /*" -713- PERFORM R0220-00-PROCESSA-ENTRADA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0220_00_PROCESSA_ENTRADA_SECTION();
            }

            /*" -714- DISPLAY ' ' . */
            _.Display($" ");

            /*" -715- DISPLAY ' LIDOS    ENTRADA ...... ' LD-ENTRADA. */
            _.Display($" LIDOS    ENTRADA ...... {W.LD_ENTRADA}");

            /*" -716- DISPLAY ' LIDOS BANCO BRASIL .... ' LD-MV921286 */
            _.Display($" LIDOS BANCO BRASIL .... {W.LD_MV921286}");

            /*" -717- DISPLAY ' TRATA SINISTRO BB ..... ' TT-SINISTRO */
            _.Display($" TRATA SINISTRO BB ..... {W.TT_SINISTRO}");

            /*" -718- DISPLAY ' DESPREZA ENTRADA ...... ' DP-ENTRADA. */
            _.Display($" DESPREZA ENTRADA ...... {W.DP_ENTRADA}");

            /*" -719- DISPLAY ' GRAVADOS SORT ......... ' GV-SORT. */
            _.Display($" GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -722- DISPLAY ' ' . */
            _.Display($" ");

            /*" -722- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-ENTRADA-SECTION */
        private void R0210_00_LER_ENTRADA_SECTION()
        {
            /*" -735- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", W.WABEND.WNR_EXEC_SQL);

            /*" -735- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -737- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -740- GO TO R0210-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, REG_MOVIMENTO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -742- MOVE REG-MOVIMENTO TO REG-SIACC. */
            _.Move(MOVIMENTO?.Value, REG_SIACC);

            /*" -742- ADD 1 TO LD-ENTRADA. */
            W.LD_ENTRADA.Value = W.LD_ENTRADA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-ENTRADA-SECTION */
        private void R0220_00_PROCESSA_ENTRADA_SECTION()
        {
            /*" -755- MOVE '0220' TO WNR-EXEC-SQL. */
            _.Move("0220", W.WABEND.WNR_EXEC_SQL);

            /*" -758- MOVE SIACC-IDLG TO WS-IDLG-SIACC WS-IDLG-SINISTRO. */
            _.Move(REG_SIACC.SIACC_IDLG, W.WS_IDLG_SIACC, W.WS_IDLG_SINISTRO);

            /*" -759- IF WS-IDLG-CONVENIO EQUAL 921286 */

            if (W.FILLER_0.WS_IDLG_CONVENIO == 921286)
            {

                /*" -760- ADD 1 TO LD-MV921286 */
                W.LD_MV921286.Value = W.LD_MV921286 + 1;

                /*" -761- PERFORM R0300-00-TRATA-BANCO-BRASIL */

                R0300_00_TRATA_BANCO_BRASIL_SECTION();

                /*" -762- ELSE */
            }
            else
            {


                /*" -763- IF SIACC-CONVENIO EQUAL 921286 */

                if (REG_SIACC.SIACC_CONVENIO == 921286)
                {

                    /*" -764- ADD 1 TO TT-SINISTRO */
                    W.TT_SINISTRO.Value = W.TT_SINISTRO + 1;

                    /*" -765- PERFORM R0230-00-TRATA-SINISTRO */

                    R0230_00_TRATA_SINISTRO_SECTION();

                    /*" -766- ELSE */
                }
                else
                {


                    /*" -766- ADD 1 TO DP-ENTRADA. */
                    W.DP_ENTRADA.Value = W.DP_ENTRADA + 1;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0220_50_LEITURA */

            R0220_50_LEITURA();

        }

        [StopWatch]
        /*" R0220-50-LEITURA */
        private void R0220_50_LEITURA(bool isPerform = false)
        {
            /*" -771- PERFORM R0210-00-LER-ENTRADA. */

            R0210_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R0230-00-TRATA-SINISTRO-SECTION */
        private void R0230_00_TRATA_SINISTRO_SECTION()
        {
            /*" -786- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", W.WABEND.WNR_EXEC_SQL);

            /*" -788- MOVE SIACC-CONVENIO TO WS-IDLG-CONVENIO. */
            _.Move(REG_SIACC.SIACC_CONVENIO, W.FILLER_0.WS_IDLG_CONVENIO);

            /*" -790- MOVE WS-IDLG-NRSEQ02 TO WS-IDLG-NRSEQ. */
            _.Move(W.FILLER_2.WS_IDLG_NRSEQ02, W.FILLER_0.WS_IDLG_NRSEQ);

            /*" -792- MOVE ZEROS TO WS-IDLG-NSAS. */
            _.Move(0, W.FILLER_0.WS_IDLG_NSAS);

            /*" -796- MOVE 'SIAS' TO WS-IDLG-ORIGEM. */
            _.Move("SIAS", W.FILLER_0.WS_IDLG_ORIGEM);

            /*" -796- PERFORM R0300-00-TRATA-BANCO-BRASIL. */

            R0300_00_TRATA_BANCO_BRASIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-TRATA-BANCO-BRASIL-SECTION */
        private void R0300_00_TRATA_BANCO_BRASIL_SECTION()
        {
            /*" -812- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", W.WABEND.WNR_EXEC_SQL);

            /*" -814- MOVE WS-IDLG-CONVENIO TO MOVDEBCE-COD-CONVENIO */
            _.Move(W.FILLER_0.WS_IDLG_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -816- MOVE WS-IDLG-NRSEQ TO MOVDEBCE-NUM-REQUISICAO. */
            _.Move(W.FILLER_0.WS_IDLG_NRSEQ, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);

            /*" -820- MOVE '1' TO MOVDEBCE-SITUACAO-COBRANCA. */
            _.Move("1", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -821- MOVE SPACES TO WFIM-MOVDEBCE. */
            _.Move("", W.WFIM_MOVDEBCE);

            /*" -824- PERFORM R0310-00-SELECT-V0MOVDEBCE. */

            R0310_00_SELECT_V0MOVDEBCE_SECTION();

            /*" -833- MOVE SPACES TO REG-SEM8020B. */
            _.Move("", REG_SEM8020B);

            /*" -834- IF GE369-COD-BANCO EQUAL 001 */

            if (GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO == 001)
            {

                /*" -835- MOVE 01 TO SCB1-SEQSORT */
                _.Move(01, REG_SEM8020B.SCB1_SEQSORT);

                /*" -836- ELSE */
            }
            else
            {


                /*" -839- MOVE 02 TO SCB1-SEQSORT. */
                _.Move(02, REG_SEM8020B.SCB1_SEQSORT);
            }


            /*" -841- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -843- MOVE SIACC-DT-CRE-DIA TO WDAT-REL-DIA. */
            _.Move(REG_SIACC.SIACC_DT_CRE_DIA, W.FILLER_9.WDAT_REL_DIA);

            /*" -845- MOVE SIACC-DT-CRE-MES TO WDAT-REL-MES. */
            _.Move(REG_SIACC.SIACC_DT_CRE_MES, W.FILLER_9.WDAT_REL_MES);

            /*" -847- MOVE SIACC-DT-CRE-ANO TO WDAT-REL-ANO. */
            _.Move(REG_SIACC.SIACC_DT_CRE_ANO, W.FILLER_9.WDAT_REL_ANO);

            /*" -849- MOVE WDATA-REL TO SCB1-DTPAGTO. */
            _.Move(W.WDATA_REL, REG_SEM8020B.SCB1_DTPAGTO);

            /*" -851- MOVE SIACC-VALOR-PAGTO TO SCB1-VLPAGTO. */
            _.Move(REG_SIACC.SIACC_VALOR_PAGTO, REG_SEM8020B.SCB1_VLPAGTO);

            /*" -855- MOVE SIACC-NSA-BANCO TO SCB1-NSAC. */
            _.Move(REG_SIACC.SIACC_NSA_BANCO, REG_SEM8020B.SCB1_NSAC);

            /*" -857- MOVE MOVDEBCE-NUM-APOLICE TO SCB1-NUMAPOL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, REG_SEM8020B.SCB1_NUMAPOL);

            /*" -859- MOVE MOVDEBCE-NUM-ENDOSSO TO SCB1-NRENDOS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, REG_SEM8020B.SCB1_NRENDOS);

            /*" -861- MOVE MOVDEBCE-NUM-PARCELA TO SCB1-NRPARCEL. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, REG_SEM8020B.SCB1_NRPARCEL);

            /*" -863- MOVE MOVDEBCE-DATA-VENCIMENTO TO SCB1-DTVENCTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, REG_SEM8020B.SCB1_DTVENCTO);

            /*" -865- MOVE MOVDEBCE-COD-AGENCIA-DEB TO SCB1-AGENCIA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, REG_SEM8020B.SCB1_AGENCIA);

            /*" -867- MOVE MOVDEBCE-OPER-CONTA-DEB TO SCB1-OPECONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, REG_SEM8020B.SCB1_OPECONTA);

            /*" -869- MOVE MOVDEBCE-NUM-CONTA-DEB TO SCB1-NUMCONTA. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, REG_SEM8020B.SCB1_NUMCONTA);

            /*" -871- MOVE MOVDEBCE-COD-CONVENIO TO SCB1-CONVENIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO, REG_SEM8020B.SCB1_CONVENIO);

            /*" -873- MOVE MOVDEBCE-NSAS TO SCB1-NSAS. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS, REG_SEM8020B.SCB1_NSAS);

            /*" -879- MOVE MOVDEBCE-NUM-REQUISICAO TO SCB1-OCORR-MOVTO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, REG_SEM8020B.SCB1_OCORR_MOVTO);

            /*" -881- MOVE MOVDEBCE-VLR-CREDITO TO SCB1-VLPREMIO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO, REG_SEM8020B.SCB1_VLPREMIO);

            /*" -883- MOVE MOVDEBCE-NUM-CARTAO TO SCB1-NUMCHQ. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, REG_SEM8020B.SCB1_NUMCHQ);

            /*" -885- MOVE GE369-COD-BANCO TO SCB1-BANCO. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_COD_BANCO, REG_SEM8020B.SCB1_BANCO);

            /*" -887- MOVE GE369-NUM-DV-CONTA-CNB TO SCB1-DIGCONTA. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_NUM_DV_CONTA_CNB, REG_SEM8020B.SCB1_DIGCONTA);

            /*" -889- MOVE GE369-COD-AGENCIA TO SCB1-CODAGENC. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_COD_AGENCIA, REG_SEM8020B.SCB1_CODAGENC);

            /*" -891- MOVE GE369-NUM-CONTA-CNB TO SCB1-CONTACNB. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_NUM_CONTA_CNB, REG_SEM8020B.SCB1_CONTACNB);

            /*" -895- MOVE GE369-IND-CONTA-BANCARIA TO SCB1-INDCONTA. */
            _.Move(GE369.DCLGE_MOVTO_CONTA.GE369_IND_CONTA_BANCARIA, REG_SEM8020B.SCB1_INDCONTA);

            /*" -898- MOVE SCB1-OCORR-MOVTO TO GE366-NUM-OCORR-MOVTO. */
            _.Move(REG_SEM8020B.SCB1_OCORR_MOVTO, GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO);

            /*" -900- MOVE SIACC-OCORRENCIA TO SCB1-COD-RETORNO-BANCO. */
            _.Move(REG_SIACC.SIACC_OCORRENCIA, REG_SEM8020B.SCB1_COD_RETORNO_BANCO);

            /*" -902- MOVE SIACC-NUM-SIVAT TO SCB1-NUM-SIVAT. */
            _.Move(REG_SIACC.SIACC_NUM_SIVAT, REG_SEM8020B.SCB1_NUM_SIVAT);

            /*" -905- PERFORM R0350-00-SELECT-GE366. */

            R0350_00_SELECT_GE366_SECTION();

            /*" -908- IF SCB1-NUMCONTA EQUAL ZEROS AND SCB1-IND-ESTRUTURA EQUAL 004 AND SCB1-NUMCHQ NOT EQUAL ZEROS */

            if (REG_SEM8020B.SCB1_NUMCONTA == 00 && REG_SEM8020B.SCB1_IND_ESTRUTURA == 004 && REG_SEM8020B.SCB1_NUMCHQ != 00)
            {

                /*" -911- PERFORM R0400-00-VERIFICA-CONTA. */

                R0400_00_VERIFICA_CONTA_SECTION();
            }


            /*" -914- ADD 1 TO GV-SORT. */
            W.GV_SORT.Value = W.GV_SORT + 1;

            /*" -914- RELEASE REG-SEM8020B. */
            SEM8020B.Release(REG_SEM8020B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-SELECT-V0MOVDEBCE-SECTION */
        private void R0310_00_SELECT_V0MOVDEBCE_SECTION()
        {
            /*" -927- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", W.WABEND.WNR_EXEC_SQL);

            /*" -976- PERFORM R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1 */

            R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1();

            /*" -980- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -981- MOVE 'S' TO WFIM-MOVDEBCE */
                _.Move("S", W.WFIM_MOVDEBCE);

                /*" -982- ELSE */
            }
            else
            {


                /*" -983- IF VIND-CARTAO LESS ZEROS */

                if (VIND_CARTAO < 00)
                {

                    /*" -993- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO. */
                    _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                }

            }


            /*" -994- IF MOVDEBCE-SITUACAO-COBRANCA NOT EQUAL '1' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA != "1")
            {

                /*" -1002- DISPLAY 'REG. JA PROCESSADO .. ' ' APO ' MOVDEBCE-NUM-APOLICE ' END ' MOVDEBCE-NUM-ENDOSSO ' PAR ' MOVDEBCE-NUM-PARCELA ' CON ' MOVDEBCE-COD-CONVENIO ' NSA ' MOVDEBCE-NSAS ' REQ ' MOVDEBCE-NUM-REQUISICAO */

                $"REG. JA PROCESSADO ..  APO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE} END {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO} PAR {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA} CON {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO} NSA {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS} REQ {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO}"
                .Display();

                /*" -1002- END-IF. */
            }


        }

        [StopWatch]
        /*" R0310-00-SELECT-V0MOVDEBCE-DB-SELECT-1 */
        public void R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1()
        {
            /*" -976- EXEC SQL SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.DATA_VENCIMENTO , A.COD_AGENCIA_DEB , A.OPER_CONTA_DEB , A.NUM_CONTA_DEB , A.COD_CONVENIO , A.NSAS , A.NUM_REQUISICAO , A.VLR_CREDITO , A.NUM_CARTAO , A.SITUACAO_COBRANCA , B.COD_AGENCIA , B.COD_BANCO , B.NUM_CONTA_CNB , B.NUM_DV_CONTA_CNB , B.IND_CONTA_BANCARIA INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-REQUISICAO , :MOVDEBCE-VLR-CREDITO , :MOVDEBCE-NUM-CARTAO:VIND-CARTAO , :MOVDEBCE-SITUACAO-COBRANCA, :GE369-COD-AGENCIA , :GE369-COD-BANCO , :GE369-NUM-CONTA-CNB , :GE369-NUM-DV-CONTA-CNB , :GE369-IND-CONTA-BANCARIA FROM SEGUROS.MOVTO_DEBITOCC_CEF A, SEGUROS.GE_MOVTO_CONTA B WHERE A.NUM_REQUISICAO = :MOVDEBCE-NUM-REQUISICAO AND A.COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND A.COD_CONVENIO = B.COD_CONVENIO AND A.NSAS = B.NSAS WITH UR END-EXEC. */

            var r0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1 = new R0310_00_SELECT_V0MOVDEBCE_DB_SELECT_1_Query1()
            {
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
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
        /*" R0350-00-SELECT-GE366-SECTION */
        private void R0350_00_SELECT_GE366_SECTION()
        {
            /*" -1014- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", W.WABEND.WNR_EXEC_SQL);

            /*" -1030- PERFORM R0350_00_SELECT_GE366_DB_SELECT_1 */

            R0350_00_SELECT_GE366_DB_SELECT_1();

            /*" -1034- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1035- DISPLAY 'R0350-00 - PROBLEMAS NO SELECT(GE366)   ' */
                _.Display($"R0350-00 - PROBLEMAS NO SELECT(GE366)   ");

                /*" -1038- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1039- MOVE GE366-IND-ESTRUTURA TO SCB1-IND-ESTRUTURA. */
            _.Move(GE366.DCLGE_MOVIMENTO.GE366_IND_ESTRUTURA, REG_SEM8020B.SCB1_IND_ESTRUTURA);

        }

        [StopWatch]
        /*" R0350-00-SELECT-GE366-DB-SELECT-1 */
        public void R0350_00_SELECT_GE366_DB_SELECT_1()
        {
            /*" -1030- EXEC SQL SELECT NUM_OCORR_MOVTO, COD_EVENTO , IDE_SISTEMA , IND_ESTRUTURA , IND_ORIGEM_FUNC, IND_EVENTO INTO :GE366-NUM-OCORR-MOVTO, :GE366-COD-EVENTO , :GE366-IDE-SISTEMA , :GE366-IND-ESTRUTURA , :GE366-IND-ORIGEM-FUNC, :GE366-IND-EVENTO FROM SEGUROS.GE_MOVIMENTO WHERE NUM_OCORR_MOVTO = :GE366-NUM-OCORR-MOVTO WITH UR END-EXEC. */

            var r0350_00_SELECT_GE366_DB_SELECT_1_Query1 = new R0350_00_SELECT_GE366_DB_SELECT_1_Query1()
            {
                GE366_NUM_OCORR_MOVTO = GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R0350_00_SELECT_GE366_DB_SELECT_1_Query1.Execute(r0350_00_SELECT_GE366_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE366_NUM_OCORR_MOVTO, GE366.DCLGE_MOVIMENTO.GE366_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE366_COD_EVENTO, GE366.DCLGE_MOVIMENTO.GE366_COD_EVENTO);
                _.Move(executed_1.GE366_IDE_SISTEMA, GE366.DCLGE_MOVIMENTO.GE366_IDE_SISTEMA);
                _.Move(executed_1.GE366_IND_ESTRUTURA, GE366.DCLGE_MOVIMENTO.GE366_IND_ESTRUTURA);
                _.Move(executed_1.GE366_IND_ORIGEM_FUNC, GE366.DCLGE_MOVIMENTO.GE366_IND_ORIGEM_FUNC);
                _.Move(executed_1.GE366_IND_EVENTO, GE366.DCLGE_MOVIMENTO.GE366_IND_EVENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-VERIFICA-CONTA-SECTION */
        private void R0400_00_VERIFICA_CONTA_SECTION()
        {
            /*" -1052- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", W.WABEND.WNR_EXEC_SQL);

            /*" -1054- MOVE MOVDEBCE-NUM-APOLICE TO SIARDEVC-NUM-APOL-SINISTRO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO);

            /*" -1057- MOVE MOVDEBCE-NUM-PARCELA TO SIARDEVC-OCORR-HISTORICO. */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO);

            /*" -1060- PERFORM R0450-00-SELECT-SIARDEVC. */

            R0450_00_SELECT_SIARDEVC_SECTION();

            /*" -1062- MOVE SIARDEVC-COD-CONTA TO WS-CONTA10. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA, W.WS_CONTA10);

            /*" -1064- MOVE 16 TO WS-IND1 WS-IND2. */
            _.Move(16, W.WS_IND1, W.WS_IND2);

            /*" -1066- MOVE ZEROS TO WS-CONTA20. */
            _.Move(0, W.WS_CONTA20);

            /*" -1067- PERFORM 15 TIMES */

            for (int i = 0; i < 15; i++)
            {

                /*" -1068- SUBTRACT 1 FROM WS-IND1 */
                W.WS_IND1.Value = W.WS_IND1 - 1;

                /*" -1069- IF CHAR10(WS-IND1) IS NUMERIC */

                if (W.FILLER_5.CHAR10[W.WS_IND1].IsNumeric())
                {

                    /*" -1070- SUBTRACT 1 FROM WS-IND2 */
                    W.WS_IND2.Value = W.WS_IND2 - 1;

                    /*" -1072- MOVE CHAR10(WS-IND1) TO CHAR20(WS-IND2) */
                    _.Move(W.FILLER_5.CHAR10[W.WS_IND1], W.FILLER_6.CHAR20[W.WS_IND2]);

                    /*" -1073- END-IF */
                }


                /*" -1075- END-PERFORM. */
            }

            /*" -1077- MOVE WS-CONTA20 TO SCB1-NUMCONTA. */
            _.Move(W.WS_CONTA20, REG_SEM8020B.SCB1_NUMCONTA);

            /*" -1079- MOVE SIARDEVC-DV-CONTA TO WS-DIGCTA1. */
            _.Move(SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA, W.FILLER_25.WS_DIGCTA1);

            /*" -1082- MOVE SPACES TO WS-DIGCTA2 WS-DIGCTA3. */
            _.Move("", W.FILLER_25.WS_DIGCTA2);
            _.Move("", W.FILLER_25.WS_DIGCTA3);


            /*" -1083- MOVE WS-DIGCTA TO SCB1-DIGCONTA. */
            _.Move(W.WS_DIGCTA, REG_SEM8020B.SCB1_DIGCONTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0450-00-SELECT-SIARDEVC-SECTION */
        private void R0450_00_SELECT_SIARDEVC_SECTION()
        {
            /*" -1096- MOVE '0450' TO WNR-EXEC-SQL. */
            _.Move("0450", W.WABEND.WNR_EXEC_SQL);

            /*" -1107- PERFORM R0450_00_SELECT_SIARDEVC_DB_SELECT_1 */

            R0450_00_SELECT_SIARDEVC_DB_SELECT_1();

            /*" -1110- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1111- DISPLAY 'ERRO DE ACESSO - R0450-00-SELECT-SIARDEVC' */
                _.Display($"ERRO DE ACESSO - R0450-00-SELECT-SIARDEVC");

                /*" -1113- DISPLAY 'SINISTRO - ' SIARDEVC-NUM-APOL-SINISTRO ' OCORR - ' SIARDEVC-OCORR-HISTORICO */

                $"SINISTRO - {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO} OCORR - {SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO}"
                .Display();

                /*" -1115- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1116- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1118- MOVE ZEROS TO SIARDEVC-COD-CONTA */
                _.Move(0, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA);

                /*" -1119- MOVE SPACES TO SIARDEVC-DV-CONTA. */
                _.Move("", SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA);
            }


        }

        [StopWatch]
        /*" R0450-00-SELECT-SIARDEVC-DB-SELECT-1 */
        public void R0450_00_SELECT_SIARDEVC_DB_SELECT_1()
        {
            /*" -1107- EXEC SQL SELECT COD_CONTA , DV_CONTA INTO :SIARDEVC-COD-CONTA , :SIARDEVC-DV-CONTA FROM SEGUROS.SI_AR_DETALHE_VC WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO WITH UR END-EXEC. */

            var r0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1 = new R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1()
            {
                SIARDEVC_NUM_APOL_SINISTRO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_NUM_APOL_SINISTRO.ToString(),
                SIARDEVC_OCORR_HISTORICO = SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1.Execute(r0450_00_SELECT_SIARDEVC_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SIARDEVC_COD_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_COD_CONTA);
                _.Move(executed_1.SIARDEVC_DV_CONTA, SIARDEVC.DCLSI_AR_DETALHE_VC.SIARDEVC_DV_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-SORT-SECTION */
        private void R0700_00_PROCESSA_SORT_SECTION()
        {
            /*" -1130- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1132- DISPLAY '==> INICIO DE PROCESSAMENTO DO ARQUIVO DE SORT <==' . */
            _.Display($"==> INICIO DE PROCESSAMENTO DO ARQUIVO DE SORT <==");

            /*" -1134- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1137- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", W.WABEND.WNR_EXEC_SQL);

            /*" -1141- MOVE ZEROS TO LD-SORT AC-VLRTOTAL. */
            _.Move(0, W.LD_SORT, W.AC_VLRTOTAL);

            /*" -1142- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -1145- PERFORM R0710-00-LER-SORT. */

            R0710_00_LER_SORT_SECTION();

            /*" -1146- IF WFIM-SORT NOT EQUAL SPACES */

            if (!W.WFIM_SORT.IsEmpty())
            {

                /*" -1147- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' */
                _.Display($"SEM MOVIMENTO NESTA DATA  ");

                /*" -1150- GO TO R0700-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1154- MOVE ZEROS TO AC-QTDLOTE AC-QTDREGARQ. */
            _.Move(0, W.AC_QTDLOTE, W.AC_QTDREGARQ);

            /*" -1157- PERFORM R3000-00-HEADER-ARQUIVO. */

            R3000_00_HEADER_ARQUIVO_SECTION();

            /*" -1161- PERFORM R0800-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0800_00_PROCESSA_SORT_SECTION();
            }

            /*" -1164- PERFORM R3100-00-TRAILLER-ARQUIVO. */

            R3100_00_TRAILLER_ARQUIVO_SECTION();

            /*" -1165- DISPLAY ' ' */
            _.Display($" ");

            /*" -1166- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -1167- DISPLAY ' ' */
            _.Display($" ");

            /*" -1168- DISPLAY 'TOTAL LOTES ........... ' AC-QTDLOTE */
            _.Display($"TOTAL LOTES ........... {W.AC_QTDLOTE}");

            /*" -1169- DISPLAY 'TOTAL REGISTROS ....... ' AC-QTDREGARQ */
            _.Display($"TOTAL REGISTROS ....... {W.AC_QTDREGARQ}");

            /*" -1172- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1172- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0710-00-LER-SORT-SECTION */
        private void R0710_00_LER_SORT_SECTION()
        {
            /*" -1185- MOVE '0710' TO WNR-EXEC-SQL. */
            _.Move("0710", W.WABEND.WNR_EXEC_SQL);

            /*" -1187- RETURN SEM8020B AT END */
            try
            {
                SEM8020B.Return(REG_SEM8020B, () =>
                {

                    /*" -1188- MOVE ZEROS TO ATU-SEQSORT */
                    _.Move(0, W.ATU_SEQSORT);

                    /*" -1189- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -1192- GO TO R0710-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1195- MOVE SCB1-SEQSORT TO ATU-SEQSORT. */
            _.Move(REG_SEM8020B.SCB1_SEQSORT, W.ATU_SEQSORT);

            /*" -1195- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-SORT-SECTION */
        private void R0800_00_PROCESSA_SORT_SECTION()
        {
            /*" -1208- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", W.WABEND.WNR_EXEC_SQL);

            /*" -1213- MOVE ZEROS TO AC-NRSEQ AC-QTDREGLOT AC-VLRTOTCRE. */
            _.Move(0, W.AC_NRSEQ, W.AC_QTDREGLOT, W.AC_VLRTOTCRE);

            /*" -1216- PERFORM R3200-00-HEADER-LOTE. */

            R3200_00_HEADER_LOTE_SECTION();

            /*" -1218- MOVE ATU-SEQSORT TO ANT-SEQSORT. */
            _.Move(W.ATU_SEQSORT, W.ANT_SEQSORT);

            /*" -1223- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL ATU-SEQSORT NOT EQUAL ANT-SEQSORT OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_SEQSORT != W.ANT_SEQSORT || !W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1223- PERFORM R3300-00-TRAILLER-LOTE. */

            R3300_00_TRAILLER_LOTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1236- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", W.WABEND.WNR_EXEC_SQL);

            /*" -1239- MOVE SCB1-BANCO TO CTA-BCOCEF CTA-BCOOUT. */
            _.Move(REG_SEM8020B.SCB1_BANCO, W.FILLER_16.CTA_BCOCEF);
            _.Move(REG_SEM8020B.SCB1_BANCO, W.FILLER_21.CTA_BCOOUT);


            /*" -1242- MOVE SCB1-AGENCIA TO CTA-AGECEF CTA-AGEOUT. */
            _.Move(REG_SEM8020B.SCB1_AGENCIA, W.FILLER_16.CTA_AGECEF);
            _.Move(REG_SEM8020B.SCB1_AGENCIA, W.FILLER_21.CTA_AGEOUT);


            /*" -1246- MOVE SCB1-NUMCONTA TO CTA-CTACEF CTA-CTAOUT WS-NUMCONTA. */
            _.Move(REG_SEM8020B.SCB1_NUMCONTA, W.FILLER_16.CTA_CTACEF);
            _.Move(REG_SEM8020B.SCB1_NUMCONTA, W.FILLER_21.CTA_CTAOUT);
            _.Move(REG_SEM8020B.SCB1_NUMCONTA, W.FILLER_26.WS_NUMCONTA);


            /*" -1249- MOVE SCB1-OPECONTA TO CTA-OPECEF WS-OPERACAO. */
            _.Move(REG_SEM8020B.SCB1_OPECONTA, W.FILLER_16.CTA_OPECEF);
            _.Move(REG_SEM8020B.SCB1_OPECONTA, W.FILLER_26.WS_OPERACAO);


            /*" -1252- MOVE SCB1-DIGCONTA TO CTA-DIGOUT WS-DIGCTA. */
            _.Move(REG_SEM8020B.SCB1_DIGCONTA, W.FILLER_21.CTA_DIGOUT);
            _.Move(REG_SEM8020B.SCB1_DIGCONTA, W.WS_DIGCTA);


            /*" -1253- IF WS-DIGCTA1 NUMERIC */

            if (W.FILLER_25.WS_DIGCTA1.IsNumeric())
            {

                /*" -1255- MOVE WS-DIGCTA1 TO CTA-DIGCEF */
                _.Move(W.FILLER_25.WS_DIGCTA1, W.FILLER_16.CTA_DIGCEF);

                /*" -1256- ELSE */
            }
            else
            {


                /*" -1257- IF WS-DIGCTA2 NUMERIC */

                if (W.FILLER_25.WS_DIGCTA2.IsNumeric())
                {

                    /*" -1259- MOVE WS-DIGCTA2 TO CTA-DIGCEF */
                    _.Move(W.FILLER_25.WS_DIGCTA2, W.FILLER_16.CTA_DIGCEF);

                    /*" -1260- ELSE */
                }
                else
                {


                    /*" -1267- MOVE ZEROS TO CTA-DIGCEF. */
                    _.Move(0, W.FILLER_16.CTA_DIGCEF);
                }

            }


            /*" -1273- PERFORM R1050-00-SELECT-GE368. */

            R1050_00_SELECT_GE368_SECTION();

            /*" -1279- PERFORM R1100-00-SELECT-OD001. */

            R1100_00_SELECT_OD001_SECTION();

            /*" -1285- PERFORM R1200-00-SELECT-OD007. */

            R1200_00_SELECT_OD007_SECTION();

            /*" -1291- PERFORM R1400-00-SEGMENTO-A. */

            R1400_00_SEGMENTO_A_SECTION();

            /*" -1291- PERFORM R1500-00-SEGMENTO-B. */

            R1500_00_SEGMENTO_B_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1296- PERFORM R0710-00-LER-SORT. */

            R0710_00_LER_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1050-00-SELECT-GE368-SECTION */
        private void R1050_00_SELECT_GE368_SECTION()
        {
            /*" -1308- MOVE '1050' TO WNR-EXEC-SQL. */
            _.Move("1050", W.WABEND.WNR_EXEC_SQL);

            /*" -1310- MOVE SCB1-OCORR-MOVTO TO GE368-NUM-OCORR-MOVTO. */
            _.Move(REG_SEM8020B.SCB1_OCORR_MOVTO, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO);

            /*" -1314- MOVE 1 TO GE368-IND-ENTIDADE. */
            _.Move(1, GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE);

            /*" -1326- PERFORM R1050_00_SELECT_GE368_DB_SELECT_1 */

            R1050_00_SELECT_GE368_DB_SELECT_1();

            /*" -1329- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1330- DISPLAY 'ERRO DE ACESSO - R1050-00-SELECT-GE368' */
                _.Display($"ERRO DE ACESSO - R1050-00-SELECT-GE368");

                /*" -1331- DISPLAY 'TABELA - GE_LEG_PESS_EVENTO' */
                _.Display($"TABELA - GE_LEG_PESS_EVENTO");

                /*" -1333- DISPLAY 'GE368-NUM-OCORR-MOVTO - ' GE368-NUM-OCORR-MOVTO 'GE368-IND-ENTIDADE - ' GE368-IND-ENTIDADE */

                $"GE368-NUM-OCORR-MOVTO - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO}GE368-IND-ENTIDADE - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE}"
                .Display();

                /*" -1333- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-00-SELECT-GE368-DB-SELECT-1 */
        public void R1050_00_SELECT_GE368_DB_SELECT_1()
        {
            /*" -1326- EXEC SQL SELECT NUM_PESSOA , NUM_OCORR_MOVTO, SEQ_ENTIDADE , IND_ENTIDADE INTO :GE368-NUM-PESSOA , :GE368-NUM-OCORR-MOVTO, :GE368-SEQ-ENTIDADE , :GE368-IND-ENTIDADE FROM SEGUROS.GE_LEG_PESS_EVENTO WHERE NUM_OCORR_MOVTO = :GE368-NUM-OCORR-MOVTO AND IND_ENTIDADE = :GE368-IND-ENTIDADE END-EXEC. */

            var r1050_00_SELECT_GE368_DB_SELECT_1_Query1 = new R1050_00_SELECT_GE368_DB_SELECT_1_Query1()
            {
                GE368_NUM_OCORR_MOVTO = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO.ToString(),
                GE368_IND_ENTIDADE = GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE.ToString(),
            };

            var executed_1 = R1050_00_SELECT_GE368_DB_SELECT_1_Query1.Execute(r1050_00_SELECT_GE368_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
                _.Move(executed_1.GE368_NUM_OCORR_MOVTO, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE368_SEQ_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE);
                _.Move(executed_1.GE368_IND_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-OD001-SECTION */
        private void R1100_00_SELECT_OD001_SECTION()
        {
            /*" -1346- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", W.WABEND.WNR_EXEC_SQL);

            /*" -1353- PERFORM R1100_00_SELECT_OD001_DB_SELECT_1 */

            R1100_00_SELECT_OD001_DB_SELECT_1();

            /*" -1356- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1357- DISPLAY 'ERRO DE ACESSO - R1100-00-SELECT-OD001' */
                _.Display($"ERRO DE ACESSO - R1100-00-SELECT-OD001");

                /*" -1358- DISPLAY 'TABELA - ODS.OD_PESSOA' */
                _.Display($"TABELA - ODS.OD_PESSOA");

                /*" -1359- DISPLAY 'GE368-NUM-PESSOA - ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1361- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1362- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -1363- PERFORM R1120-00-SELECT-OD002 */

                R1120_00_SELECT_OD002_SECTION();

                /*" -1364- ELSE */
            }
            else
            {


                /*" -1364- PERFORM R1140-00-SELECT-OD003. */

                R1140_00_SELECT_OD003_SECTION();
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-OD001-DB-SELECT-1 */
        public void R1100_00_SELECT_OD001_DB_SELECT_1()
        {
            /*" -1353- EXEC SQL SELECT NUM_PESSOA , IND_PESSOA INTO :OD001-NUM-PESSOA , :OD001-IND-PESSOA FROM ODS.OD_PESSOA WHERE NUM_PESSOA = :GE368-NUM-PESSOA END-EXEC. */

            var r1100_00_SELECT_OD001_DB_SELECT_1_Query1 = new R1100_00_SELECT_OD001_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1100_00_SELECT_OD001_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_OD001_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD001_NUM_PESSOA, OD001.DCLOD_PESSOA.OD001_NUM_PESSOA);
                _.Move(executed_1.OD001_IND_PESSOA, OD001.DCLOD_PESSOA.OD001_IND_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-SELECT-OD002-SECTION */
        private void R1120_00_SELECT_OD002_SECTION()
        {
            /*" -1377- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", W.WABEND.WNR_EXEC_SQL);

            /*" -1381- MOVE SPACES TO OD002-NOM-PESSOA-TEXT. */
            _.Move("", OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT);

            /*" -1392- PERFORM R1120_00_SELECT_OD002_DB_SELECT_1 */

            R1120_00_SELECT_OD002_DB_SELECT_1();

            /*" -1395- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1396- DISPLAY 'ERRO DE ACESSO - R1120-00-SELECT-OD002' */
                _.Display($"ERRO DE ACESSO - R1120-00-SELECT-OD002");

                /*" -1397- DISPLAY 'TABELA - ODS.OD_PESSOA_FISICA' */
                _.Display($"TABELA - ODS.OD_PESSOA_FISICA");

                /*" -1398- DISPLAY 'GE368-NUM-PESSOA - ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1398- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1120-00-SELECT-OD002-DB-SELECT-1 */
        public void R1120_00_SELECT_OD002_DB_SELECT_1()
        {
            /*" -1392- EXEC SQL SELECT NUM_PESSOA , NUM_CPF , NUM_DV_CPF , NOM_PESSOA INTO :OD002-NUM-PESSOA , :OD002-NUM-CPF , :OD002-NUM-DV-CPF , :OD002-NOM-PESSOA FROM ODS.OD_PESSOA_FISICA WHERE NUM_PESSOA = :GE368-NUM-PESSOA END-EXEC. */

            var r1120_00_SELECT_OD002_DB_SELECT_1_Query1 = new R1120_00_SELECT_OD002_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1120_00_SELECT_OD002_DB_SELECT_1_Query1.Execute(r1120_00_SELECT_OD002_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD002_NUM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_PESSOA);
                _.Move(executed_1.OD002_NUM_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF);
                _.Move(executed_1.OD002_NUM_DV_CPF, OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF);
                _.Move(executed_1.OD002_NOM_PESSOA, OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1140-00-SELECT-OD003-SECTION */
        private void R1140_00_SELECT_OD003_SECTION()
        {
            /*" -1411- MOVE '1140' TO WNR-EXEC-SQL. */
            _.Move("1140", W.WABEND.WNR_EXEC_SQL);

            /*" -1414- MOVE SPACES TO OD003-NOM-RAZAO-SOCIAL-TEXT. */
            _.Move("", OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT);

            /*" -1427- PERFORM R1140_00_SELECT_OD003_DB_SELECT_1 */

            R1140_00_SELECT_OD003_DB_SELECT_1();

            /*" -1430- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1431- DISPLAY 'ERRO DE ACESSO - R1140-00-SELECT-OD003' */
                _.Display($"ERRO DE ACESSO - R1140-00-SELECT-OD003");

                /*" -1432- DISPLAY 'TABELA - ODS.OD_PESSOA_JURIDICA' */
                _.Display($"TABELA - ODS.OD_PESSOA_JURIDICA");

                /*" -1433- DISPLAY 'GE368-NUM-PESSOA - ' GE368-NUM-PESSOA */
                _.Display($"GE368-NUM-PESSOA - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA}");

                /*" -1433- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1140-00-SELECT-OD003-DB-SELECT-1 */
        public void R1140_00_SELECT_OD003_DB_SELECT_1()
        {
            /*" -1427- EXEC SQL SELECT NUM_PESSOA , NUM_CNPJ , NUM_FILIAL , NUM_DV_CNPJ , NOM_RAZAO_SOCIAL INTO :OD003-NUM-PESSOA , :OD003-NUM-CNPJ , :OD003-NUM-FILIAL , :OD003-NUM-DV-CNPJ , :OD003-NOM-RAZAO-SOCIAL FROM ODS.OD_PESSOA_JURIDICA WHERE NUM_PESSOA = :GE368-NUM-PESSOA END-EXEC. */

            var r1140_00_SELECT_OD003_DB_SELECT_1_Query1 = new R1140_00_SELECT_OD003_DB_SELECT_1_Query1()
            {
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1140_00_SELECT_OD003_DB_SELECT_1_Query1.Execute(r1140_00_SELECT_OD003_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD003_NUM_PESSOA, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_PESSOA);
                _.Move(executed_1.OD003_NUM_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ);
                _.Move(executed_1.OD003_NUM_FILIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL);
                _.Move(executed_1.OD003_NUM_DV_CNPJ, OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ);
                _.Move(executed_1.OD003_NOM_RAZAO_SOCIAL, OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1140_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-OD007-SECTION */
        private void R1200_00_SELECT_OD007_SECTION()
        {
            /*" -1446- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", W.WABEND.WNR_EXEC_SQL);

            /*" -1468- PERFORM R1200_00_SELECT_OD007_DB_SELECT_1 */

            R1200_00_SELECT_OD007_DB_SELECT_1();

            /*" -1471- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1472- DISPLAY 'ERRO DE ACESSO - R1200-00-SELECT-OD007' */
                _.Display($"ERRO DE ACESSO - R1200-00-SELECT-OD007");

                /*" -1473- DISPLAY 'TABELA - ODS.OD_PESSOA_ENDERECO' */
                _.Display($"TABELA - ODS.OD_PESSOA_ENDERECO");

                /*" -1475- DISPLAY 'GE368-NUM-PESSOA - ' GE368-NUM-PESSOA ' GE368-SEQ-ENTIDADE - ' GE368-SEQ-ENTIDADE */

                $"GE368-NUM-PESSOA - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA} GE368-SEQ-ENTIDADE - {GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE}"
                .Display();

                /*" -1477- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1478- IF SQLCODE EQUAL 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1484- GO TO R1200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1485- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1486- IF SCB1-NRENDOS EQUAL 8111 */

                if (REG_SEM8020B.SCB1_NRENDOS == 8111)
                {

                    /*" -1487- MOVE 'NAO' TO W-CHAVE-EH-SINISTRO-TUTELA */
                    _.Move("NAO", W.W_CHAVE_EH_SINISTRO_TUTELA);

                    /*" -1488- PERFORM R1210-00-SELECT-HISTSINI */

                    R1210_00_SELECT_HISTSINI_SECTION();

                    /*" -1489- IF W-CHAVE-EH-SINISTRO-TUTELA EQUAL 'SIM' */

                    if (W.W_CHAVE_EH_SINISTRO_TUTELA == "SIM")
                    {

                        /*" -1490- MOVE 'SCN - QUADRA 1' TO OD007-NOM-LOGRADOURO */
                        _.Move("SCN - QUADRA 1", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);

                        /*" -1491- MOVE 'BLOCO A' TO OD007-DES-NUM-IMOVEL */
                        _.Move("BLOCO A", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);

                        /*" -1492- MOVE 'ED NUMBER 1' TO OD007-DES-COMPL-ENDERECO */
                        _.Move("ED NUMBER 1", OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);

                        /*" -1493- MOVE 'ASA NORTE' TO OD007-NOM-BAIRRO */
                        _.Move("ASA NORTE", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);

                        /*" -1494- MOVE 'BRASILIA' TO OD007-NOM-CIDADE */
                        _.Move("BRASILIA", OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);

                        /*" -1495- MOVE '70711-900' TO OD007-COD-CEP */
                        _.Move("70711-900", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);

                        /*" -1496- MOVE 'DF' TO OD007-COD-UF */
                        _.Move("DF", OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);

                        /*" -1497- END-IF */
                    }


                    /*" -1497- GO TO R1200-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/ //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-OD007-DB-SELECT-1 */
        public void R1200_00_SELECT_OD007_DB_SELECT_1()
        {
            /*" -1468- EXEC SQL SELECT NUM_PESSOA , SEQ_ENDERECO , NOM_LOGRADOURO , DES_NUM_IMOVEL , DES_COMPL_ENDERECO , NOM_BAIRRO , NOM_CIDADE , COD_CEP , COD_UF INTO :OD007-NUM-PESSOA , :OD007-SEQ-ENDERECO , :OD007-NOM-LOGRADOURO , :OD007-DES-NUM-IMOVEL , :OD007-DES-COMPL-ENDERECO , :OD007-NOM-BAIRRO , :OD007-NOM-CIDADE , :OD007-COD-CEP , :OD007-COD-UF FROM ODS.OD_PESSOA_ENDERECO WHERE NUM_PESSOA = :GE368-NUM-PESSOA AND SEQ_ENDERECO = :GE368-SEQ-ENTIDADE END-EXEC. */

            var r1200_00_SELECT_OD007_DB_SELECT_1_Query1 = new R1200_00_SELECT_OD007_DB_SELECT_1_Query1()
            {
                GE368_SEQ_ENTIDADE = GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE.ToString(),
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1200_00_SELECT_OD007_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_OD007_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD007_NUM_PESSOA, OD007.DCLOD_PESSOA_ENDERECO.OD007_NUM_PESSOA);
                _.Move(executed_1.OD007_SEQ_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_SEQ_ENDERECO);
                _.Move(executed_1.OD007_NOM_LOGRADOURO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO);
                _.Move(executed_1.OD007_DES_NUM_IMOVEL, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_NUM_IMOVEL);
                _.Move(executed_1.OD007_DES_COMPL_ENDERECO, OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO);
                _.Move(executed_1.OD007_NOM_BAIRRO, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO);
                _.Move(executed_1.OD007_NOM_CIDADE, OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE);
                _.Move(executed_1.OD007_COD_CEP, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP);
                _.Move(executed_1.OD007_COD_UF, OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1210-00-SELECT-HISTSINI-SECTION */
        private void R1210_00_SELECT_HISTSINI_SECTION()
        {
            /*" -1508- MOVE '1210' TO WNR-EXEC-SQL. */
            _.Move("1210", W.WABEND.WNR_EXEC_SQL);

            /*" -1509- MOVE SCB1-NUMAPOL TO SINISHIS-NUM-APOL-SINISTRO */
            _.Move(REG_SEM8020B.SCB1_NUMAPOL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

            /*" -1510- MOVE SCB1-NRENDOS TO SINISHIS-COD-OPERACAO */
            _.Move(REG_SEM8020B.SCB1_NRENDOS, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

            /*" -1512- MOVE SCB1-NRPARCEL TO SINISHIS-OCORR-HISTORICO */
            _.Move(REG_SEM8020B.SCB1_NRPARCEL, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

            /*" -1520- PERFORM R1210_00_SELECT_HISTSINI_DB_SELECT_1 */

            R1210_00_SELECT_HISTSINI_DB_SELECT_1();

            /*" -1523- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1524- DISPLAY 'R1210-00 - PROBLEMAS NO SELECT(HISTSINI)' */
                _.Display($"R1210-00 - PROBLEMAS NO SELECT(HISTSINI)");

                /*" -1526- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1527- IF HOST-COUNT NOT EQUAL 0 */

            if (W.HOST_COUNT != 0)
            {

                /*" -1527- MOVE 'SIM' TO W-CHAVE-EH-SINISTRO-TUTELA . */
                _.Move("SIM", W.W_CHAVE_EH_SINISTRO_TUTELA);
            }


        }

        [StopWatch]
        /*" R1210-00-SELECT-HISTSINI-DB-SELECT-1 */
        public void R1210_00_SELECT_HISTSINI_DB_SELECT_1()
        {
            /*" -1520- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :HOST-COUNT FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO WITH UR END-EXEC. */

            var r1210_00_SELECT_HISTSINI_DB_SELECT_1_Query1 = new R1210_00_SELECT_HISTSINI_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R1210_00_SELECT_HISTSINI_DB_SELECT_1_Query1.Execute(r1210_00_SELECT_HISTSINI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HOST_COUNT, W.HOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1210_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SEGMENTO-A-SECTION */
        private void R1400_00_SEGMENTO_A_SECTION()
        {
            /*" -1539- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", W.WABEND.WNR_EXEC_SQL);

            /*" -1543- ADD 1 TO AC-NRSEQ AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_NRSEQ.Value = W.AC_NRSEQ + 1;
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1546- MOVE SPACES TO DETSEGA-REGISTRO. */
            _.Move("", DETSEGA_REGISTRO);

            /*" -1548- MOVE 001 TO DETSEGA-BANCO. */
            _.Move(001, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_BANCO);

            /*" -1550- MOVE AC-QTDLOTE TO DETSEGA-LOTSER. */
            _.Move(W.AC_QTDLOTE, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_LOTSER);

            /*" -1552- MOVE 3 TO DETSEGA-TIPOREG. */
            _.Move(3, DETSEGA_REGISTRO.DETSEGA_CONTROLE.DETSEGA_TIPOREG);

            /*" -1554- MOVE AC-NRSEQ TO DETSEGA-NUMREG. */
            _.Move(W.AC_NRSEQ, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_NUMREG);

            /*" -1556- MOVE 'A' TO DETSEGA-SEGMENTO. */
            _.Move("A", DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_SEGMENTO);

            /*" -1558- MOVE ZEROS TO DETSEGA-TIPOMOV. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_MOVIMENTO.DETSEGA_TIPOMOV);

            /*" -1560- MOVE ZEROS TO DETSEGA-INSTRUCAO. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_SERVICO.DETSEGA_MOVIMENTO.DETSEGA_INSTRUCAO);

            /*" -1563- MOVE ZEROS TO DETSEGA-CAMARA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CAMARA);

            /*" -1564- IF SCB1-BANCO EQUAL 104 */

            if (REG_SEM8020B.SCB1_BANCO == 104)
            {

                /*" -1566- MOVE CTA-BCOCEF TO DETSEGA-BANCOFAV */
                _.Move(W.FILLER_16.CTA_BCOCEF, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_BANCOFAV);

                /*" -1568- MOVE CTA-AGECEF TO DETSEGA-AGECONTA */
                _.Move(W.FILLER_16.CTA_AGECEF, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

                /*" -1570- MOVE WS-NUMERO TO DETSEGA-NUMCONTA */
                _.Move(W.WS_NUMERO, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_NUMCONTA);

                /*" -1572- MOVE CTA-DIGCEF TO DETSEGA-DIGCONTA */
                _.Move(W.FILLER_16.CTA_DIGCEF, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                /*" -1573- ELSE */
            }
            else
            {


                /*" -1574- IF CTA-BCOOUT EQUAL 001 */

                if (W.FILLER_21.CTA_BCOOUT == 001)
                {

                    /*" -1575- PERFORM R1410-00-CALCULA-DV-BB */

                    R1410_00_CALCULA_DV_BB_SECTION();

                    /*" -1577- MOVE WS-DV-BB-X TO DETSEGA-DIGAGENC */
                    _.Move(W.WS_DV_BB_X, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGAGENC);

                    /*" -1578- END-IF */
                }


                /*" -1580- MOVE CTA-BCOOUT TO DETSEGA-BANCOFAV */
                _.Move(W.FILLER_21.CTA_BCOOUT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_BANCOFAV);

                /*" -1582- MOVE CTA-AGEOUT TO DETSEGA-AGECONTA */
                _.Move(W.FILLER_21.CTA_AGEOUT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_AGECONTA);

                /*" -1584- MOVE CTA-CTAOUT TO DETSEGA-NUMCONTA */
                _.Move(W.FILLER_21.CTA_CTAOUT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_NUMCONTA);

                /*" -1586- IF WS-DIGCTA1 NUMERIC AND WS-DIGCTA2 NUMERIC */

                if (W.FILLER_25.WS_DIGCTA1.IsNumeric() && W.FILLER_25.WS_DIGCTA2.IsNumeric())
                {

                    /*" -1588- MOVE WS-DIGCTA1 TO DETSEGA-DIGCONTA */
                    _.Move(W.FILLER_25.WS_DIGCTA1, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                    /*" -1590- MOVE WS-DIGCTA2 TO DETSEGA-DIGAGECTA */
                    _.Move(W.FILLER_25.WS_DIGCTA2, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGAGECTA);

                    /*" -1591- ELSE */
                }
                else
                {


                    /*" -1592- IF WS-DIGCTA1 NUMERIC */

                    if (W.FILLER_25.WS_DIGCTA1.IsNumeric())
                    {

                        /*" -1594- MOVE WS-DIGCTA1 TO DETSEGA-DIGCONTA */
                        _.Move(W.FILLER_25.WS_DIGCTA1, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                        /*" -1595- ELSE */
                    }
                    else
                    {


                        /*" -1596- IF WS-DIGCTA2 NUMERIC */

                        if (W.FILLER_25.WS_DIGCTA2.IsNumeric())
                        {

                            /*" -1598- MOVE WS-DIGCTA2 TO DETSEGA-DIGCONTA */
                            _.Move(W.FILLER_25.WS_DIGCTA2, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                            /*" -1599- ELSE */
                        }
                        else
                        {


                            /*" -1601- IF WS-DIGCTA1 NOT EQUAL SPACES AND WS-DIGCTA2 NOT EQUAL SPACES */

                            if (!W.FILLER_25.WS_DIGCTA1.IsEmpty() && !W.FILLER_25.WS_DIGCTA2.IsEmpty())
                            {

                                /*" -1603- MOVE WS-DIGCTA1 TO DETSEGA-DIGCONTA */
                                _.Move(W.FILLER_25.WS_DIGCTA1, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                                /*" -1605- MOVE WS-DIGCTA2 TO DETSEGA-DIGAGECTA */
                                _.Move(W.FILLER_25.WS_DIGCTA2, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGAGECTA);

                                /*" -1606- ELSE */
                            }
                            else
                            {


                                /*" -1607- IF WS-DIGCTA1 NOT EQUAL SPACES */

                                if (!W.FILLER_25.WS_DIGCTA1.IsEmpty())
                                {

                                    /*" -1609- MOVE WS-DIGCTA1 TO DETSEGA-DIGCONTA */
                                    _.Move(W.FILLER_25.WS_DIGCTA1, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);

                                    /*" -1610- ELSE */
                                }
                                else
                                {


                                    /*" -1611- IF WS-DIGCTA2 NOT EQUAL SPACES */

                                    if (!W.FILLER_25.WS_DIGCTA2.IsEmpty())
                                    {

                                        /*" -1614- MOVE WS-DIGCTA2 TO DETSEGA-DIGCONTA. */
                                        _.Move(W.FILLER_25.WS_DIGCTA2, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_CONTA.DETSEGA_DIGCONTA);
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1615- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -1617- MOVE OD002-NOM-PESSOA-TEXT TO DETSEGA-NOMEFAV */
                _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NOM_PESSOA.OD002_NOM_PESSOA_TEXT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);

                /*" -1618- ELSE */
            }
            else
            {


                /*" -1621- MOVE OD003-NOM-RAZAO-SOCIAL-TEXT TO DETSEGA-NOMEFAV. */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NOM_RAZAO_SOCIAL.OD003_NOM_RAZAO_SOCIAL_TEXT, DETSEGA_REGISTRO.DETSEGA_FAVORECIDO.DETSEGA_NOMEFAV);
            }


            /*" -1623- MOVE ZEROS TO DETSEGA-NRSEQ01. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NROEMPRE.DETSEGA_NRSEQ01);

            /*" -1627- MOVE SCB1-OCORR-MOVTO TO DETSEGA-NRSEQ02. */
            _.Move(REG_SEM8020B.SCB1_OCORR_MOVTO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NROEMPRE.DETSEGA_NRSEQ02);

            /*" -1628- MOVE SCB1-DTPAGTO TO WDATA-REL. */
            _.Move(REG_SEM8020B.SCB1_DTPAGTO, W.WDATA_REL);

            /*" -1631- MOVE WDAT-REL-DIA TO DETSEGA-DIAREA DETSEGA-DIAPAG. */
            _.Move(W.FILLER_9.WDAT_REL_DIA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_DIAREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_DIAPAG);

            /*" -1634- MOVE WDAT-REL-MES TO DETSEGA-MESREA DETSEGA-MESPAG. */
            _.Move(W.FILLER_9.WDAT_REL_MES, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_MESREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_MESPAG);

            /*" -1638- MOVE WDAT-REL-ANO TO DETSEGA-ANOREA DETSEGA-ANOPAG. */
            _.Move(W.FILLER_9.WDAT_REL_ANO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAREAL.DETSEGA_ANOREA, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_ANOPAG);

            /*" -1640- MOVE 'BRL' TO DETSEGA-TIPOMOEDA. */
            _.Move("BRL", DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_MOEDA.DETSEGA_TIPOMOEDA);

            /*" -1642- MOVE ZEROS TO DETSEGA-QTDEMOEDA. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_MOEDA.DETSEGA_QTDEMOEDA);

            /*" -1645- MOVE SCB1-VLPAGTO TO DETSEGA-VALREAL DETSEGA-VALPAGTO. */
            _.Move(REG_SEM8020B.SCB1_VLPAGTO, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALREAL, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALPAGTO);

            /*" -1649- ADD SCB1-VLPAGTO TO AC-VLRTOTCRE AC-VLRTOTAL. */
            W.AC_VLRTOTCRE.Value = W.AC_VLRTOTCRE + REG_SEM8020B.SCB1_VLPAGTO;
            W.AC_VLRTOTAL.Value = W.AC_VLRTOTAL + REG_SEM8020B.SCB1_VLPAGTO;

            /*" -1651- MOVE '1CREDITO EM CONTA CORRENTE' TO DETSEGA-INFORMA. */
            _.Move("1CREDITO EM CONTA CORRENTE", DETSEGA_REGISTRO.DETSEGA_INFORMA);

            /*" -1655- MOVE ZEROS TO DETSEGA-AVISO. */
            _.Move(0, DETSEGA_REGISTRO.DETSEGA_AVISO);

            /*" -1656- MOVE SCB1-COD-RETORNO-BANCO TO DETSEGA-OCORRENCIA. */
            _.Move(REG_SEM8020B.SCB1_COD_RETORNO_BANCO, DETSEGA_REGISTRO.DETSEGA_OCORRENCIA);

            /*" -1658- MOVE SCB1-NUM-SIVAT TO DETSEGA-NUM-DOC-BANCO */
            _.Move(REG_SEM8020B.SCB1_NUM_SIVAT, DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_NUM_DOC_BANCO);

            /*" -1660- MOVE DETSEGA-REGISTRO TO REG-MOV921286 */
            _.Move(DETSEGA_REGISTRO, REG_MOV921286);

            /*" -1660- WRITE REG-MOV921286. */
            MOV921286_CC.Write(REG_MOV921286.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-CALCULA-DV-BB-SECTION */
        private void R1410_00_CALCULA_DV_BB_SECTION()
        {
            /*" -1671- MOVE '1410' TO WNR-EXEC-SQL. */
            _.Move("1410", W.WABEND.WNR_EXEC_SQL);

            /*" -1674- MOVE CTA-AGEOUT TO WS-AGENCIA-BB. */
            _.Move(W.FILLER_21.CTA_AGEOUT, W.WS_AGENCIA_BB);

            /*" -1680- COMPUTE WVALOR-AUX = LAGEN01-1 * 5 + LAGEN01-2 * 4 + LAGEN01-3 * 3 + LAGEN01-4 * 2 */
            WVALOR_AUX.Value = W.FILLER_7.LAGEN01_1 * 5 + W.FILLER_7.LAGEN01_2 * 4 + W.FILLER_7.LAGEN01_3 * 3 + W.FILLER_7.LAGEN01_4 * 2;

            /*" -1683- DIVIDE WVALOR-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(WVALOR_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -1684- IF WRESTO EQUAL 0 */

            if (WRESTO == 0)
            {

                /*" -1685- MOVE '0' TO WS-DV-BB-X */
                _.Move("0", W.WS_DV_BB_X);

                /*" -1686- ELSE */
            }
            else
            {


                /*" -1687- IF WRESTO EQUAL 1 */

                if (WRESTO == 1)
                {

                    /*" -1688- MOVE 'X' TO WS-DV-BB-X */
                    _.Move("X", W.WS_DV_BB_X);

                    /*" -1689- ELSE */
                }
                else
                {


                    /*" -1690- SUBTRACT WRESTO FROM 11 GIVING WS-DV-BB. */
                    W.WS_DV_BB.Value = 11 - WRESTO;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SEGMENTO-B-SECTION */
        private void R1500_00_SEGMENTO_B_SECTION()
        {
            /*" -1702- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", W.WABEND.WNR_EXEC_SQL);

            /*" -1706- ADD 1 TO AC-NRSEQ AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_NRSEQ.Value = W.AC_NRSEQ + 1;
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1709- MOVE SPACES TO DETSEGB-REGISTRO. */
            _.Move("", DETSEGB_REGISTRO);

            /*" -1711- MOVE 001 TO DETSEGB-BANCO. */
            _.Move(001, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_BANCO);

            /*" -1713- MOVE AC-QTDLOTE TO DETSEGB-LOTSER. */
            _.Move(W.AC_QTDLOTE, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_LOTSER);

            /*" -1715- MOVE 3 TO DETSEGB-TIPOREG. */
            _.Move(3, DETSEGB_REGISTRO.DETSEGB_CONTROLE.DETSEGB_TIPOREG);

            /*" -1717- MOVE AC-NRSEQ TO DETSEGB-NUMREG. */
            _.Move(W.AC_NRSEQ, DETSEGB_REGISTRO.DETSEGB_SERVICO.DETSEGB_NUMREG);

            /*" -1720- MOVE 'B' TO DETSEGB-SEGMENTO. */
            _.Move("B", DETSEGB_REGISTRO.DETSEGB_SERVICO.DETSEGB_SEGMENTO);

            /*" -1721- IF OD001-IND-PESSOA EQUAL 'F' */

            if (OD001.DCLOD_PESSOA.OD001_IND_PESSOA == "F")
            {

                /*" -1723- MOVE 1 TO DETSEGB-TIPINSC */
                _.Move(1, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);

                /*" -1725- MOVE OD002-NUM-CPF TO WS-NUM-CPF */
                _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_CPF, W.FILLER_27.WS_NUM_CPF);

                /*" -1727- MOVE OD002-NUM-DV-CPF TO WS-DIG-CPF */
                _.Move(OD002.DCLOD_PESSOA_FISICA.OD002_NUM_DV_CPF, W.FILLER_27.WS_DIG_CPF);

                /*" -1729- MOVE WS-CPF TO DETSEGB-NROINSC */
                _.Move(W.WS_CPF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_NROINSC);

                /*" -1730- ELSE */
            }
            else
            {


                /*" -1732- MOVE 2 TO DETSEGB-TIPINSC */
                _.Move(2, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_TIPINSC);

                /*" -1734- MOVE OD003-NUM-CNPJ TO WS-NUM-CNPJ */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_CNPJ, W.FILLER_28.WS_NUM_CNPJ);

                /*" -1736- MOVE OD003-NUM-FILIAL TO WS-NUM-FILIAL */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_FILIAL, W.FILLER_28.WS_NUM_FILIAL);

                /*" -1738- MOVE OD003-NUM-DV-CNPJ TO WS-DIG-CNPJ */
                _.Move(OD003.DCLOD_PESSOA_JURIDICA.OD003_NUM_DV_CNPJ, W.FILLER_28.WS_DIG_CNPJ);

                /*" -1741- MOVE WS-CNPJ TO DETSEGB-NROINSC. */
                _.Move(W.WS_CNPJ, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_INSCRICAO.DETSEGB_NROINSC);
            }


            /*" -1743- MOVE OD007-NOM-LOGRADOURO TO DETSEGB-LOGRADOURO. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_LOGRADOURO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_LOGRADOURO);

            /*" -1745- MOVE ZEROS TO DETSEGB-NUMERO. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_NUMERO);

            /*" -1747- MOVE OD007-DES-COMPL-ENDERECO TO DETSEGB-COMPLOGRA. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_DES_COMPL_ENDERECO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_COMPLOGRA);

            /*" -1749- MOVE OD007-NOM-BAIRRO TO DETSEGB-BAIRRO. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_BAIRRO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_BAIRRO);

            /*" -1751- MOVE OD007-NOM-CIDADE TO DETSEGB-CIDADE. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_NOM_CIDADE, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CIDADE);

            /*" -1753- MOVE OD007-COD-CEP TO DETSEGB-CEP. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_CEP, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_CEP);

            /*" -1756- MOVE OD007-COD-UF TO DETSEGB-SIGLAUF. */
            _.Move(OD007.DCLOD_PESSOA_ENDERECO.OD007_COD_UF, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_FAVORECIDO.DETSEGB_SIGLAUF);

            /*" -1758- MOVE DETSEGA-DIAPAG TO DETSEGB-DIAVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_DIAPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_DIAVEN);

            /*" -1760- MOVE DETSEGA-MESPAG TO DETSEGB-MESVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_MESPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_MESVEN);

            /*" -1762- MOVE DETSEGA-ANOPAG TO DETSEGB-ANOVEN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_DATAPAGTO.DETSEGA_ANOPAG, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_DATAVENCTO.DETSEGB_ANOVEN);

            /*" -1764- MOVE DETSEGA-VALPAGTO TO DETSEGB-VALNOMIN. */
            _.Move(DETSEGA_REGISTRO.DETSEGA_CREDITO.DETSEGA_VALPAGTO, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALNOMIN);

            /*" -1771- MOVE ZEROS TO DETSEGB-VALABAT DETSEGB-VALDESC DETSEGB-VALMORA DETSEGB-VALMULTA. */
            _.Move(0, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALABAT, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALDESC, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALMORA, DETSEGB_REGISTRO.DETSEGB_COMPLEMENTO.DETSEGB_PAGTO.DETSEGB_VALMULTA);

            /*" -1773- MOVE DETSEGB-REGISTRO TO REG-MOV921286 */
            _.Move(DETSEGB_REGISTRO, REG_MOV921286);

            /*" -1773- WRITE REG-MOV921286. */
            MOV921286_CC.Write(REG_MOV921286.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-HEADER-ARQUIVO-SECTION */
        private void R3000_00_HEADER_ARQUIVO_SECTION()
        {
            /*" -1786- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", W.WABEND.WNR_EXEC_SQL);

            /*" -1788- ADD 1 TO AC-QTDREGARQ. */
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1791- MOVE SPACES TO ARQHEA-REGISTRO. */
            _.Move("", ARQHEA_REGISTRO);

            /*" -1793- MOVE 001 TO ARQHEA-BANCO. */
            _.Move(001, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_BANCO);

            /*" -1795- MOVE ZEROS TO ARQHEA-LOTSER. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_LOTSER);

            /*" -1797- MOVE ZEROS TO ARQHEA-TIPOREG. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_CONTROLE.ARQHEA_TIPOREG);

            /*" -1799- MOVE 2 TO ARQHEA-TIPINSC. */
            _.Move(2, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_INSCRICAO.ARQHEA_TIPINSC);

            /*" -1801- MOVE 34020354000110 TO ARQHEA-NROINSC. */
            _.Move(34020354000110, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_INSCRICAO.ARQHEA_NROINSC);

            /*" -1803- MOVE '000921286' TO ARQHEA-CONVENIO. */
            _.Move("000921286", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONVENIO);

            /*" -1805- MOVE 03307 TO ARQHEA-AGECONTA. */
            _.Move(03307, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_AGECONTA);

            /*" -1807- MOVE '3' TO ARQHEA-DIGAGENC. */
            _.Move("3", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGAGENC);

            /*" -1809- MOVE 000000069498 TO ARQHEA-NUMCONTA. */
            _.Move(000000069498, ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_NUMCONTA);

            /*" -1811- MOVE '3' TO ARQHEA-DIGCONTA. */
            _.Move("3", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGCONTA);

            /*" -1813- MOVE SPACES TO ARQHEA-DIGAGECTA. */
            _.Move("", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_CONTA.ARQHEA_DIGAGECTA);

            /*" -1815- MOVE 'CAIXA SEGURADORA SA' TO ARQHEA-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", ARQHEA_REGISTRO.ARQHEA_EMPRESA.ARQHEA_NOMEMPRESA);

            /*" -1817- MOVE 'BANCO DO BRASIL    ' TO ARQHEA-NOMEBANCO. */
            _.Move("BANCO DO BRASIL    ", ARQHEA_REGISTRO.ARQHEA_NOMEBANCO);

            /*" -1820- MOVE 2 TO ARQHEA-REMESSA. */
            _.Move(2, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_REMESSA);

            /*" -1822- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -1824- MOVE WDAT-REL-DIA TO ARQHEA-DIAGERA. */
            _.Move(W.FILLER_9.WDAT_REL_DIA, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_DIAGERA);

            /*" -1826- MOVE WDAT-REL-MES TO ARQHEA-MESGERA. */
            _.Move(W.FILLER_9.WDAT_REL_MES, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_MESGERA);

            /*" -1829- MOVE WDAT-REL-ANO TO ARQHEA-ANOGERA. */
            _.Move(W.FILLER_9.WDAT_REL_ANO, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DATAGERACAO.ARQHEA_ANOGERA);

            /*" -1830- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), W.WHORA_CURR);

            /*" -1832- MOVE WHORA-HH-CURR TO ARQHEA-HORGERA. */
            _.Move(W.WHORA_CURR.WHORA_HH_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_HORGERA);

            /*" -1834- MOVE WHORA-MM-CURR TO ARQHEA-MINGERA. */
            _.Move(W.WHORA_CURR.WHORA_MM_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_MINGERA);

            /*" -1836- MOVE WHORA-SS-CURR TO ARQHEA-SEGGERA. */
            _.Move(W.WHORA_CURR.WHORA_SS_CURR, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_HORAGERACAO.ARQHEA_SEGGERA);

            /*" -1838- MOVE SCB1-NSAC TO ARQHEA-NSA. */
            _.Move(REG_SEM8020B.SCB1_NSAC, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_NSA);

            /*" -1840- MOVE 030 TO ARQHEA-VERSAO. */
            _.Move(030, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_VERSAO);

            /*" -1842- MOVE ZEROS TO ARQHEA-DENSIDADE. */
            _.Move(0, ARQHEA_REGISTRO.ARQHEA_ARQUIVO.ARQHEA_DENSIDADE);

            /*" -1844- MOVE 'CONSOLIDADO' TO ARQHEA-BANCO02. */
            _.Move("CONSOLIDADO", ARQHEA_REGISTRO.ARQHEA_USOBANCO.ARQHEA_BANCO02);

            /*" -1846- MOVE SPACES TO ARQHEA-USOEMPRESA. */
            _.Move("", ARQHEA_REGISTRO.ARQHEA_USOEMPRESA);

            /*" -1850- MOVE '98' TO ARQHEA-TIPOSER. */
            _.Move("98", ARQHEA_REGISTRO.ARQHEA_TIPOSER);

            /*" -1852- MOVE ARQHEA-REGISTRO TO REG-MOV921286 */
            _.Move(ARQHEA_REGISTRO, REG_MOV921286);

            /*" -1852- WRITE REG-MOV921286. */
            MOV921286_CC.Write(REG_MOV921286.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-TRAILLER-ARQUIVO-SECTION */
        private void R3100_00_TRAILLER_ARQUIVO_SECTION()
        {
            /*" -1865- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", W.WABEND.WNR_EXEC_SQL);

            /*" -1867- ADD 1 TO AC-QTDREGARQ. */
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1870- MOVE SPACES TO ARQTRA-REGISTRO. */
            _.Move("", ARQTRA_REGISTRO);

            /*" -1872- MOVE 001 TO ARQTRA-BANCO. */
            _.Move(001, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_BANCO);

            /*" -1874- MOVE 9999 TO ARQTRA-LOTSER. */
            _.Move(9999, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_LOTSER);

            /*" -1877- MOVE 9 TO ARQTRA-TIPOREG. */
            _.Move(9, ARQTRA_REGISTRO.ARQTRA_CONTROLE.ARQTRA_TIPOREG);

            /*" -1879- MOVE AC-QTDLOTE TO ARQTRA-QTDELOTE */
            _.Move(W.AC_QTDLOTE, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDELOTE);

            /*" -1881- MOVE AC-QTDREGARQ TO ARQTRA-QTDEREG. */
            _.Move(W.AC_QTDREGARQ, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDEREG);

            /*" -1885- MOVE ZEROS TO ARQTRA-QTDECONTA. */
            _.Move(0, ARQTRA_REGISTRO.ARQTRA_TOTAIS.ARQTRA_QTDECONTA);

            /*" -1887- MOVE ARQTRA-REGISTRO TO REG-MOV921286 */
            _.Move(ARQTRA_REGISTRO, REG_MOV921286);

            /*" -1887- WRITE REG-MOV921286. */
            MOV921286_CC.Write(REG_MOV921286.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-HEADER-LOTE-SECTION */
        private void R3200_00_HEADER_LOTE_SECTION()
        {
            /*" -1900- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", W.WABEND.WNR_EXEC_SQL);

            /*" -1904- ADD 1 TO AC-QTDLOTE AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_QTDLOTE.Value = W.AC_QTDLOTE + 1;
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1907- MOVE SPACES TO LOTHEA-REGISTRO. */
            _.Move("", LOTHEA_REGISTRO);

            /*" -1909- MOVE 001 TO LOTHEA-BANCO. */
            _.Move(001, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_BANCO);

            /*" -1911- MOVE AC-QTDLOTE TO LOTHEA-LOTSER. */
            _.Move(W.AC_QTDLOTE, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_LOTSER);

            /*" -1913- MOVE 1 TO LOTHEA-TIPOREG. */
            _.Move(1, LOTHEA_REGISTRO.LOTHEA_CONTROLE.LOTHEA_TIPOREG);

            /*" -1915- MOVE 'C' TO LOTHEA-OPERACAO. */
            _.Move("C", LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_OPERACAO);

            /*" -1917- MOVE 98 TO LOTHEA-TIPSER. */
            _.Move(98, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_TIPSER);

            /*" -1920- MOVE 020 TO LOTHEA-VERSAO. */
            _.Move(020, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_VERSAO);

            /*" -1921- IF SCB1-SEQSORT EQUAL 001 */

            if (REG_SEM8020B.SCB1_SEQSORT == 001)
            {

                /*" -1923- MOVE 01 TO LOTHEA-FORMA */
                _.Move(01, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_FORMA);

                /*" -1924- ELSE */
            }
            else
            {


                /*" -1927- MOVE 03 TO LOTHEA-FORMA. */
                _.Move(03, LOTHEA_REGISTRO.LOTHEA_SERVICO.LOTHEA_FORMA);
            }


            /*" -1929- MOVE 2 TO LOTHEA-TIPINSC. */
            _.Move(2, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_INSCRICAO.LOTHEA_TIPINSC);

            /*" -1931- MOVE 34020354000110 TO LOTHEA-NROINSC. */
            _.Move(34020354000110, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_INSCRICAO.LOTHEA_NROINSC);

            /*" -1933- MOVE '000921286' TO LOTHEA-CONVENIO. */
            _.Move("000921286", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONVENIO);

            /*" -1935- MOVE 03307 TO LOTHEA-AGECONTA. */
            _.Move(03307, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_AGECONTA);

            /*" -1937- MOVE '3' TO LOTHEA-DIGAGENC. */
            _.Move("3", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGAGENC);

            /*" -1939- MOVE 000000069498 TO LOTHEA-NUMCONTA. */
            _.Move(000000069498, LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_NUMCONTA);

            /*" -1941- MOVE '3' TO LOTHEA-DIGCONTA. */
            _.Move("3", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGCONTA);

            /*" -1943- MOVE SPACES TO LOTHEA-DIGAGECTA. */
            _.Move("", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_CONTA.LOTHEA_DIGAGECTA);

            /*" -1945- MOVE 'CAIXA SEGURADORA SA' TO LOTHEA-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", LOTHEA_REGISTRO.LOTHEA_EMPRESA.LOTHEA_NOMEMPRESA);

            /*" -1947- MOVE 'SCN - QUADRA 01 - BLOCO A     ' TO LOTHEA-LOGRADOURO. */
            _.Move("SCN - QUADRA 01 - BLOCO A     ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_LOGRADOURO);

            /*" -1949- MOVE 00001 TO LOTHEA-NUMERO. */
            _.Move(00001, LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_NUMERO);

            /*" -1951- MOVE 'ED. NUMBER ONE ' TO LOTHEA-COMPLOGRA. */
            _.Move("ED. NUMBER ONE ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_COMPLOGRA);

            /*" -1953- MOVE 'BRASILIA            ' TO LOTHEA-CIDADE. */
            _.Move("BRASILIA            ", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_CIDADE);

            /*" -1955- MOVE 70710 TO LOTHEA-CEP. */
            _.Move(70710, LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_CEP);

            /*" -1957- MOVE '500' TO LOTHEA-COMPLCEP. */
            _.Move("500", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_COMPLCEP);

            /*" -1961- MOVE 'DF' TO LOTHEA-SIGLAUF. */
            _.Move("DF", LOTHEA_REGISTRO.LOTHEA_ENDERECO.LOTHEA_SIGLAUF);

            /*" -1963- MOVE LOTHEA-REGISTRO TO REG-MOV921286 */
            _.Move(LOTHEA_REGISTRO, REG_MOV921286);

            /*" -1963- WRITE REG-MOV921286. */
            MOV921286_CC.Write(REG_MOV921286.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3300-00-TRAILLER-LOTE-SECTION */
        private void R3300_00_TRAILLER_LOTE_SECTION()
        {
            /*" -1976- MOVE '3300' TO WNR-EXEC-SQL. */
            _.Move("3300", W.WABEND.WNR_EXEC_SQL);

            /*" -1979- ADD 1 TO AC-QTDREGLOT AC-QTDREGARQ. */
            W.AC_QTDREGLOT.Value = W.AC_QTDREGLOT + 1;
            W.AC_QTDREGARQ.Value = W.AC_QTDREGARQ + 1;

            /*" -1982- MOVE SPACES TO LOTTRA-REGISTRO. */
            _.Move("", LOTTRA_REGISTRO);

            /*" -1984- MOVE 001 TO LOTTRA-BANCO. */
            _.Move(001, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_BANCO);

            /*" -1986- MOVE AC-QTDLOTE TO LOTTRA-LOTSER. */
            _.Move(W.AC_QTDLOTE, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_LOTSER);

            /*" -1989- MOVE 5 TO LOTTRA-TIPOREG. */
            _.Move(5, LOTTRA_REGISTRO.LOTTRA_CONTROLE.LOTTRA_TIPOREG);

            /*" -1991- MOVE AC-QTDREGLOT TO LOTTRA-QTDEREG */
            _.Move(W.AC_QTDREGLOT, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_QTDEREG);

            /*" -1993- MOVE AC-VLRTOTCRE TO LOTTRA-VALOR. */
            _.Move(W.AC_VLRTOTCRE, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_VALOR);

            /*" -1995- MOVE ZEROS TO LOTTRA-QTDEMOEDA. */
            _.Move(0, LOTTRA_REGISTRO.LOTTRA_TOTAIS.LOTTRA_QTDEMOEDA);

            /*" -1999- MOVE ZEROS TO LOTTRA-NRAVISO. */
            _.Move(0, LOTTRA_REGISTRO.LOTTRA_NRAVISO);

            /*" -2001- MOVE LOTTRA-REGISTRO TO REG-MOV921286 */
            _.Move(LOTTRA_REGISTRO, REG_MOV921286);

            /*" -2001- WRITE REG-MOV921286. */
            MOV921286_CC.Write(REG_MOV921286.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2012- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, W.WABEND.WSQLCODE);

            /*" -2013- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], W.WABEND.WSQLERRD1);

            /*" -2014- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], W.WABEND.WSQLERRD2);

            /*" -2016- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, W.WSQLERR.WSQLERRMC);

            /*" -2017- DISPLAY WABEND. */
            _.Display(W.WABEND);

            /*" -2019- DISPLAY WSQLERR. */
            _.Display(W.WSQLERR);

            /*" -2019- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2025- CLOSE MOVIMENTO MOV921286-CC. */
            MOVIMENTO.Close();
            MOV921286_CC.Close();

            /*" -2027- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2027- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}