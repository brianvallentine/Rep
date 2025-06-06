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
using Sias.PessoaFisica.DB2.PF4002B;

namespace Code
{
    public class PF4002B
    {
        public bool IsCall { get; set; }

        public PF4002B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA.................  SISTEMA PROPOSTAS VIDA             *      */
        /*"      *   MODULO..................  SIAS                               *      */
        /*"      *   OBJETIVO................  LEITURA DE ARQUIVO DE PROPOSTAS    *      */
        /*"      *                             REJEITADAS DA CAIXA E GRAVACAO NA  *      */
        /*"      *                             TABELA HIST_PROP_FIDELIZ           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO.....  THIAGO BLAIER                      *      */
        /*"      *   PROGRAMA ...............  PF4002B                            *      */
        /*"      *   DATA ...................  28/10/2024.                  .     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * VERSAO 02     - DEMANDA 595918   ABEND OPTI-4261               *      */
        /*"      *                 TRATAR SQLCODE 100 NA PROPOSTA_FIDELIZ         *      */
        /*"      *                                                                *      */
        /*"      * EM 07/01/2025 - SERGIO LORETO                                  *      */
        /*"      *                                         PROCURE POR V.02       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _CVPRJEMI { get; set; } = new FileBasis(new PIC("X", "130", "X(130)"));

        public FileBasis CVPRJEMI
        {
            get
            {
                _.Move(REG_CVPRJEMI, _CVPRJEMI); VarBasis.RedefinePassValue(REG_CVPRJEMI, _CVPRJEMI, REG_CVPRJEMI); return _CVPRJEMI;
            }
        }
        /*"01   REG-CVPRJEMI              PIC X(130).*/
        public StringBasis REG_CVPRJEMI { get; set; } = new StringBasis(new PIC("X", "130", "X(130)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  AREA-DE-WORK.*/
        public PF4002B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new PF4002B_AREA_DE_WORK();
        public class PF4002B_AREA_DE_WORK : VarBasis
        {
            /*"    05  WS-SQLCODE              PIC S9(06) COMP-3.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
            /*"    05  WS-PROGRAMA             PIC X(008)  VALUE SPACES.*/
            public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05  WS-IND-TP-ACAO          PIC X(001) VALUE SPACES.*/
            public StringBasis WS_IND_TP_ACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  WS-EDIT.*/
            public PF4002B_WS_EDIT WS_EDIT { get; set; } = new PF4002B_WS_EDIT();
            public class PF4002B_WS_EDIT : VarBasis
            {
                /*"       10 WS-SMALLINT           PIC ZZ.ZZ9- OCCURS 20 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"       10 WS-INTEGER            PIC Z.ZZZ.ZZZ.ZZ9-                                            OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"       10 WS-BIGINT             PIC 99999999999999                                            OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"       10 WS-DECIMAL            PIC ZZZZZZZZZZ9,999999                                            OCCURS 10 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"    05 WS-NUM-PROPOSTA-ANT      PIC 9(014) VALUE ZEROS.*/
            }
            public IntBasis WS_NUM_PROPOSTA_ANT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
            /*"01  WS-REG-ENTRADA.*/
        }
        public PF4002B_WS_REG_ENTRADA WS_REG_ENTRADA { get; set; } = new PF4002B_WS_REG_ENTRADA();
        public class PF4002B_WS_REG_ENTRADA : VarBasis
        {
            /*"    02  REG-TIPO-STATUS.*/
            public PF4002B_REG_TIPO_STATUS REG_TIPO_STATUS { get; set; } = new PF4002B_REG_TIPO_STATUS();
            public class PF4002B_REG_TIPO_STATUS : VarBasis
            {
                /*"        03  REG-TIPOREG              PIC X(001).*/
                public StringBasis REG_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        03  REG-NUM-PROPOSTA         PIC 9(014).*/
                public IntBasis REG_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"        03  FILLER    REDEFINES     REG-NUM-PROPOSTA.*/
                private _REDEF_PF4002B_FILLER_0 _filler_0 { get; set; }
                public _REDEF_PF4002B_FILLER_0 FILLER_0
                {
                    get { _filler_0 = new _REDEF_PF4002B_FILLER_0(); _.Move(REG_NUM_PROPOSTA, _filler_0); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_0, REG_NUM_PROPOSTA); _filler_0.ValueChanged += () => { _.Move(_filler_0, REG_NUM_PROPOSTA); }; return _filler_0; }
                    set { VarBasis.RedefinePassValue(value, _filler_0, REG_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF4002B_FILLER_0 : VarBasis
                {
                    /*"            05  REG-NOME-HT          PIC X(008).*/
                    public StringBasis REG_NOME_HT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"            05  FILLER   REDEFINES   REG-NOME-HT.*/
                    private _REDEF_PF4002B_FILLER_1 _filler_1 { get; set; }
                    public _REDEF_PF4002B_FILLER_1 FILLER_1
                    {
                        get { _filler_1 = new _REDEF_PF4002B_FILLER_1(); _.Move(REG_NOME_HT, _filler_1); VarBasis.RedefinePassValue(REG_NOME_HT, _filler_1, REG_NOME_HT); _filler_1.ValueChanged += () => { _.Move(_filler_1, REG_NOME_HT); }; return _filler_1; }
                        set { VarBasis.RedefinePassValue(value, _filler_1, REG_NOME_HT); }
                    }  //Redefines
                    public class _REDEF_PF4002B_FILLER_1 : VarBasis
                    {
                        /*"                07  FILLER           PIC X(005).*/
                        public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                        /*"                07  COD-PROD-POS67   PIC 9(002).*/
                        public IntBasis COD_PROD_POS67 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                        /*"                07  FILLER           PIC X(001).*/
                        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"            05  REG-RESTO            PIC X(006).*/

                        public _REDEF_PF4002B_FILLER_1()
                        {
                            FILLER_2.ValueChanged += OnValueChanged;
                            COD_PROD_POS67.ValueChanged += OnValueChanged;
                            FILLER_3.ValueChanged += OnValueChanged;
                        }

                    }
                    public StringBasis REG_RESTO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
                    /*"        03  FILLER    REDEFINES      REG-NUM-PROPOSTA.*/

                    public _REDEF_PF4002B_FILLER_0()
                    {
                        REG_NOME_HT.ValueChanged += OnValueChanged;
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_PF4002B_FILLER_4 _filler_4 { get; set; }
                public _REDEF_PF4002B_FILLER_4 FILLER_4
                {
                    get { _filler_4 = new _REDEF_PF4002B_FILLER_4(); _.Move(REG_NUM_PROPOSTA, _filler_4); VarBasis.RedefinePassValue(REG_NUM_PROPOSTA, _filler_4, REG_NUM_PROPOSTA); _filler_4.ValueChanged += () => { _.Move(_filler_4, REG_NUM_PROPOSTA); }; return _filler_4; }
                    set { VarBasis.RedefinePassValue(value, _filler_4, REG_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_PF4002B_FILLER_4 : VarBasis
                {
                    /*"            05  REG-NUM-PROPOSTA-A   PIC X(014).*/
                    public StringBasis REG_NUM_PROPOSTA_A { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
                    /*"        03  FILLER                   PIC X(085).*/

                    public _REDEF_PF4002B_FILLER_4()
                    {
                        REG_NUM_PROPOSTA_A.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "85", "X(085)."), @"");
                /*"        03  REG-COD-RET-SIGPF        PIC 9(003).*/
                public IntBasis REG_COD_RET_SIGPF { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        03  REG-DESC-RET-SIGPF       PIC X(027).*/
                public StringBasis REG_DESC_RET_SIGPF { get; set; } = new StringBasis(new PIC("X", "27", "X(027)."), @"");
                /*"    02  FILLER   REDEFINES  REG-TIPO-STATUS.*/
            }
            private _REDEF_PF4002B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_PF4002B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_PF4002B_FILLER_6(); _.Move(REG_TIPO_STATUS, _filler_6); VarBasis.RedefinePassValue(REG_TIPO_STATUS, _filler_6, REG_TIPO_STATUS); _filler_6.ValueChanged += () => { _.Move(_filler_6, REG_TIPO_STATUS); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, REG_TIPO_STATUS); }
            }  //Redefines
            public class _REDEF_PF4002B_FILLER_6 : VarBasis
            {
                /*"        04  REGH-TIPO-SASSE.*/
                public PF4002B_REGH_TIPO_SASSE REGH_TIPO_SASSE { get; set; } = new PF4002B_REGH_TIPO_SASSE();
                public class PF4002B_REGH_TIPO_SASSE : VarBasis
                {
                    /*"            05  REGH-TIPOREG         PIC X(001).*/
                    public StringBasis REGH_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  REGH-ARQUIVO         PIC X(008).*/
                    public StringBasis REGH_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                    /*"            05  REGH-DATA-PROPOSTA   PIC 9(008).*/
                    public IntBasis REGH_DATA_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  REGH-COD-SIST        PIC 9(001).*/
                    public IntBasis REGH_COD_SIST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  REGH-COD-SIST-DEST   PIC 9(001).*/
                    public IntBasis REGH_COD_SIST_DEST { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                    /*"            05  REGH-SEQ-ARQ         PIC 9(007).*/
                    public IntBasis REGH_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                    /*"    02  FILLER   REDEFINES  REG-TIPO-STATUS.*/

                    public PF4002B_REGH_TIPO_SASSE()
                    {
                        REGH_TIPOREG.ValueChanged += OnValueChanged;
                        REGH_ARQUIVO.ValueChanged += OnValueChanged;
                        REGH_DATA_PROPOSTA.ValueChanged += OnValueChanged;
                        REGH_COD_SIST.ValueChanged += OnValueChanged;
                        REGH_COD_SIST_DEST.ValueChanged += OnValueChanged;
                        REGH_SEQ_ARQ.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF4002B_FILLER_6()
                {
                    REGH_TIPO_SASSE.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF4002B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_PF4002B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_PF4002B_FILLER_7(); _.Move(REG_TIPO_STATUS, _filler_7); VarBasis.RedefinePassValue(REG_TIPO_STATUS, _filler_7, REG_TIPO_STATUS); _filler_7.ValueChanged += () => { _.Move(_filler_7, REG_TIPO_STATUS); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, REG_TIPO_STATUS); }
            }  //Redefines
            public class _REDEF_PF4002B_FILLER_7 : VarBasis
            {
                /*"        04  REG-TIPO-8.*/
                public PF4002B_REG_TIPO_8 REG_TIPO_8 { get; set; } = new PF4002B_REG_TIPO_8();
                public class PF4002B_REG_TIPO_8 : VarBasis
                {
                    /*"            05  REG8-TIPOREG         PIC X(001).*/
                    public StringBasis REG8_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"            05  REG8-NUM-PROPOSTA    PIC 9(014).*/
                    public IntBasis REG8_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                    /*"            05  REG8-NUM-PARCELA     PIC 9(008).*/
                    public IntBasis REG8_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                    /*"            05  REG8-COD-ENVIO       PIC 9(003).*/
                    public IntBasis REG8_COD_ENVIO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                    /*"            05  REG8-VALOR           PIC 9(011)V9(2).*/
                    public DoubleBasis REG8_VALOR { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V9(2)."), 2);
                    /*"01  WS-RSH-SEQ-ARQ                  PIC 9(007).*/

                    public PF4002B_REG_TIPO_8()
                    {
                        REG8_TIPOREG.ValueChanged += OnValueChanged;
                        REG8_NUM_PROPOSTA.ValueChanged += OnValueChanged;
                        REG8_NUM_PARCELA.ValueChanged += OnValueChanged;
                        REG8_COD_ENVIO.ValueChanged += OnValueChanged;
                        REG8_VALOR.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_PF4002B_FILLER_7()
                {
                    REG_TIPO_8.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_RSH_SEQ_ARQ { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  WORK-AREA.*/
        public PF4002B_WORK_AREA WORK_AREA { get; set; } = new PF4002B_WORK_AREA();
        public class PF4002B_WORK_AREA : VarBasis
        {
            /*"            05  WS-NUM-PROPOSTA      PIC 9(014).*/
            public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"            05  WS-NUM-PROPOSTA-R    REDEFINES                WS-NUM-PROPOSTA.*/
            private _REDEF_PF4002B_WS_NUM_PROPOSTA_R _ws_num_proposta_r { get; set; }
            public _REDEF_PF4002B_WS_NUM_PROPOSTA_R WS_NUM_PROPOSTA_R
            {
                get { _ws_num_proposta_r = new _REDEF_PF4002B_WS_NUM_PROPOSTA_R(); _.Move(WS_NUM_PROPOSTA, _ws_num_proposta_r); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _ws_num_proposta_r, WS_NUM_PROPOSTA); _ws_num_proposta_r.ValueChanged += () => { _.Move(_ws_num_proposta_r, WS_NUM_PROPOSTA); }; return _ws_num_proposta_r; }
                set { VarBasis.RedefinePassValue(value, _ws_num_proposta_r, WS_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF4002B_WS_NUM_PROPOSTA_R : VarBasis
            {
                /*"                10 WS-NUM-PROPOSTA-9 PIC 9(013).*/
                public IntBasis WS_NUM_PROPOSTA_9 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"                10 WS-NUM-PROPOSTA-0 PIC 9(001).*/
                public IntBasis WS_NUM_PROPOSTA_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"            05  DATA-ARQ.*/

                public _REDEF_PF4002B_WS_NUM_PROPOSTA_R()
                {
                    WS_NUM_PROPOSTA_9.ValueChanged += OnValueChanged;
                    WS_NUM_PROPOSTA_0.ValueChanged += OnValueChanged;
                }

            }
            public PF4002B_DATA_ARQ DATA_ARQ { get; set; } = new PF4002B_DATA_ARQ();
            public class PF4002B_DATA_ARQ : VarBasis
            {
                /*"                10 DIA-ARQ           PIC  9(002).*/
                public IntBasis DIA_ARQ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"                10 MES-ARQ           PIC  9(002).*/
                public IntBasis MES_ARQ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"                10 ANO-ARQ           PIC  9(004).*/
                public IntBasis ANO_ARQ { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"            05  DATA-SQL.*/
            }
            public PF4002B_DATA_SQL DATA_SQL { get; set; } = new PF4002B_DATA_SQL();
            public class PF4002B_DATA_SQL : VarBasis
            {
                /*"                10 ANO-SQL           PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"                10 FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"                10 MES-SQL           PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"                10 FILLER            PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"                10 DIA-SQL           PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"             05 WS-DATA-HEADER         PIC  X(010) VALUE SPACES.*/
                public StringBasis WS_DATA_HEADER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
                public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    05        WFIM-MOV4002E       PIC   X(01)  VALUE  ' '.*/
                public StringBasis WFIM_MOV4002E { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
                public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05        AC-PROCESSADOS      PIC  9(006) VALUE ZEROS.*/
                public IntBasis AC_PROCESSADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05        AC-GRAVADOS         PIC  9(006) VALUE ZEROS.*/
                public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    05        WABEND.*/
                public PF4002B_WABEND WABEND { get; set; } = new PF4002B_WABEND();
                public class PF4002B_WABEND : VarBasis
                {
                    /*"      10      FILLER              PIC  X(010) VALUE             ' PF4002B '.*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PF4002B ");
                    /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                    /*"      10      WNR-EXEC-SQL        PIC  X(006) VALUE '000000'.*/
                    public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"000000");
                    /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                    public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                    /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                    public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                    /*"      10      FILLER              PIC  X(014) VALUE             ' *** SQLERRMC '.*/
                    public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                    /*"      10      WSQLERRMC           PIC  X(070)    VALUE SPACES.*/
                    public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                }
            }
        }


        public Copies.PF0005W PF0005W { get; set; } = new Copies.PF0005W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CVPRJEMI_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CVPRJEMI.SetFile(CVPRJEMI_FILE_NAME_P);

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
            /*" -172- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -173- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -176- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -179- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -182- DISPLAY '-----------------------------------' */
            _.Display($"-----------------------------------");

            /*" -183- DISPLAY 'PROGRAMA EM EXECUCAO    PF4002B    ' */
            _.Display($"PROGRAMA EM EXECUCAO    PF4002B    ");

            /*" -185- DISPLAY 'VERSAO V.02             07/01/2025 ' */
            _.Display($"VERSAO V.02             07/01/2025 ");

            /*" -187- DISPLAY '-----------------------------------' . */
            _.Display($"-----------------------------------");

            /*" -189- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -190- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.DATA_SQL.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -191- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -192- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -194- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -196- OPEN INPUT CVPRJEMI. */
            CVPRJEMI.Open(REG_CVPRJEMI);

            /*" -197- PERFORM R0110-00-LER-MOV4002E. */

            R0110_00_LER_MOV4002E_SECTION();

            /*" -198- IF WFIM-MOV4002E NOT EQUAL SPACES */

            if (!WORK_AREA.DATA_SQL.WFIM_MOV4002E.IsEmpty())
            {

                /*" -199- DISPLAY 'PF4002B - MOV4002E VAZIO' */
                _.Display($"PF4002B - MOV4002E VAZIO");

                /*" -201- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -202- PERFORM R1000-00-PROCESSA UNTIL WFIM-MOV4002E EQUAL 'S' . */

            while (!(WORK_AREA.DATA_SQL.WFIM_MOV4002E == "S"))
            {

                R1000_00_PROCESSA_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -208- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -209- DISPLAY '*** PF4002B ***' */
            _.Display($"*** PF4002B ***");

            /*" -210- DISPLAY 'LIDOS MOV2646E            ' AC-LIDOS */
            _.Display($"LIDOS MOV2646E            {WORK_AREA.DATA_SQL.AC_LIDOS}");

            /*" -211- DISPLAY 'PROCESSADOS VIDA          ' AC-PROCESSADOS */
            _.Display($"PROCESSADOS VIDA          {WORK_AREA.DATA_SQL.AC_PROCESSADOS}");

            /*" -212- DISPLAY 'GRAVADOS HIS_PROP_FIDELIZ ' AC-GRAVADOS */
            _.Display($"GRAVADOS HIS_PROP_FIDELIZ {WORK_AREA.DATA_SQL.AC_GRAVADOS}");

            /*" -213- DISPLAY '*** PF4002B - TERMINO NORMAL ***' */
            _.Display($"*** PF4002B - TERMINO NORMAL ***");

            /*" -214- CLOSE CVPRJEMI. */
            CVPRJEMI.Close();

            /*" -214- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -225- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -230- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -233- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -234- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -235- DISPLAY 'PF4002B - ERRO ACESSO SISTEMAS VG' */
                    _.Display($"PF4002B - ERRO ACESSO SISTEMAS VG");

                    /*" -236- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", WORK_AREA.DATA_SQL.WFIM_V1SISTEMA);

                    /*" -237- ELSE */
                }
                else
                {


                    /*" -238- MOVE SQLCODE TO WSQLCODE */
                    _.Move(DB.SQLCODE, WORK_AREA.DATA_SQL.WABEND.WSQLCODE);

                    /*" -239- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -240- END-IF */
                }


                /*" -240- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -230- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-LER-MOV4002E-SECTION */
        private void R0110_00_LER_MOV4002E_SECTION()
        {
            /*" -250- READ CVPRJEMI INTO WS-REG-ENTRADA AT END */
            try
            {
                CVPRJEMI.Read(() =>
                {

                    /*" -252- MOVE 'S' TO WFIM-MOV4002E */
                    _.Move("S", WORK_AREA.DATA_SQL.WFIM_MOV4002E);

                    /*" -253- NOT AT END */
                }, () =>
                {

                    /*" -254- ADD 1 TO AC-LIDOS */
                    WORK_AREA.DATA_SQL.AC_LIDOS.Value = WORK_AREA.DATA_SQL.AC_LIDOS + 1;

                    /*" -254- END-READ. */
                });

                _.Move(CVPRJEMI.Value, WS_REG_ENTRADA); _.Move(CVPRJEMI.Value, REG_CVPRJEMI);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SECTION */
        private void R1000_00_PROCESSA_SECTION()
        {
            /*" -265- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -267- INITIALIZE DCLPROPOSTA-FIDELIZ */
            _.Initialize(
                PROPOFID.DCLPROPOSTA_FIDELIZ
            );

            /*" -268- IF REG-TIPOREG EQUAL 'H' */

            if (WS_REG_ENTRADA.REG_TIPO_STATUS.REG_TIPOREG == "H")
            {

                /*" -269- MOVE REGH-SEQ-ARQ TO WS-RSH-SEQ-ARQ */
                _.Move(WS_REG_ENTRADA.FILLER_6.REGH_TIPO_SASSE.REGH_SEQ_ARQ, WS_RSH_SEQ_ARQ);

                /*" -270- MOVE REGH-DATA-PROPOSTA TO DATA-ARQ */
                _.Move(WS_REG_ENTRADA.FILLER_6.REGH_TIPO_SASSE.REGH_DATA_PROPOSTA, WORK_AREA.DATA_ARQ);

                /*" -271- MOVE DIA-ARQ TO DIA-SQL */
                _.Move(WORK_AREA.DATA_ARQ.DIA_ARQ, WORK_AREA.DATA_SQL.DIA_SQL);

                /*" -272- MOVE MES-ARQ TO MES-SQL */
                _.Move(WORK_AREA.DATA_ARQ.MES_ARQ, WORK_AREA.DATA_SQL.MES_SQL);

                /*" -273- MOVE ANO-ARQ TO ANO-SQL */
                _.Move(WORK_AREA.DATA_ARQ.ANO_ARQ, WORK_AREA.DATA_SQL.ANO_SQL);

                /*" -274- MOVE DATA-SQL TO WS-DATA-HEADER */
                _.Move(WORK_AREA.DATA_SQL, WORK_AREA.DATA_SQL.WS_DATA_HEADER);

                /*" -275- GO TO R1000-90-CONTINUA */

                R1000_90_CONTINUA(); //GOTO
                return;

                /*" -277- END-IF */
            }


            /*" -279- IF REG-TIPOREG EQUAL '1' OR REG-TIPOREG EQUAL '8' */

            if (WS_REG_ENTRADA.REG_TIPO_STATUS.REG_TIPOREG == "1" || WS_REG_ENTRADA.REG_TIPO_STATUS.REG_TIPOREG == "8")
            {

                /*" -284- IF COD-PROD-POS67 EQUAL 06 OR 07 OR 09 OR 11 OR 13 OR 16 OR 30 OR 46 OR 48 OR 93 OR 29 OR 37 OR 54 OR 56 */

                if (WS_REG_ENTRADA.REG_TIPO_STATUS.FILLER_0.FILLER_1.COD_PROD_POS67.In("06", "07", "09", "11", "13", "16", "30", "46", "48", "93", "29", "37", "54", "56"))
                {

                    /*" -285- ADD 1 TO AC-PROCESSADOS */
                    WORK_AREA.DATA_SQL.AC_PROCESSADOS.Value = WORK_AREA.DATA_SQL.AC_PROCESSADOS + 1;

                    /*" -286- MOVE ZEROS TO WS-SQLCODE */
                    _.Move(0, AREA_DE_WORK.WS_SQLCODE);

                    /*" -287- PERFORM R1005-00-SELECT-PROPOFID */

                    R1005_00_SELECT_PROPOFID_SECTION();

                    /*" -288- IF WS-SQLCODE EQUAL ZEROS */

                    if (AREA_DE_WORK.WS_SQLCODE == 00)
                    {

                        /*" -289- PERFORM R1010-PREPARAR-HISTORICO */

                        R1010_PREPARAR_HISTORICO_SECTION();

                        /*" -290- ELSE */
                    }
                    else
                    {


                        /*" -292- DISPLAY 'PF4002B NUMERO PROPOSTA NAO EXISTE FIDELIZ ' REG-NUM-PROPOSTA */
                        _.Display($"PF4002B NUMERO PROPOSTA NAO EXISTE FIDELIZ {WS_REG_ENTRADA.REG_TIPO_STATUS.REG_NUM_PROPOSTA}");

                        /*" -293- END-IF */
                    }


                    /*" -294- END-IF */
                }


                /*" -294- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_CONTINUA */

            R1000_90_CONTINUA();

        }

        [StopWatch]
        /*" R1000-90-CONTINUA */
        private void R1000_90_CONTINUA(bool isPerform = false)
        {
            /*" -297- PERFORM R0110-00-LER-MOV4002E. */

            R0110_00_LER_MOV4002E_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-PREPARAR-HISTORICO-SECTION */
        private void R1010_PREPARAR_HISTORICO_SECTION()
        {
            /*" -306- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R1010_00_START */

            R1010_00_START();

        }

        [StopWatch]
        /*" R1010-00-START */
        private void R1010_00_START(bool isPerform = false)
        {
            /*" -311- MOVE 'R1010' TO WNR-EXEC-SQL. */
            _.Move("R1010", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -311- PERFORM R1010-05-INICIO. */

            R1010_05_INICIO(true);

        }

        [StopWatch]
        /*" R1010-05-INICIO */
        private void R1010_05_INICIO(bool isPerform = false)
        {
            /*" -317- MOVE PROPOFID-NUM-IDENTIFICACAO OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PF0005W.LK_PF005_E_NUM_IDENTIFICACAO);

            /*" -318- MOVE WS-DATA-HEADER TO LK-PF005-E-DATA-SITUACAO */
            _.Move(WORK_AREA.DATA_SQL.WS_DATA_HEADER, PF0005W.LK_PF005_E_DATA_SITUACAO);

            /*" -320- MOVE WS-RSH-SEQ-ARQ TO LK-PF005-E-NSAS-SIVPF */
            _.Move(WS_RSH_SEQ_ARQ, PF0005W.LK_PF005_E_NSAS_SIVPF);

            /*" -321- MOVE 0 TO LK-PF005-E-NSL */
            _.Move(0, PF0005W.LK_PF005_E_NSL);

            /*" -323- MOVE PROPOFID-SIT-PROPOSTA OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-SIT-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA, PF0005W.LK_PF005_E_SIT_PROPOSTA);

            /*" -325- MOVE SPACES TO LK-PF005-E-SIT-COBRANCA-SIVPF */
            _.Move("", PF0005W.LK_PF005_E_SIT_COBRANCA_SIVPF);

            /*" -327- MOVE 0 TO LK-PF005-E-SIT-MOTIVO-SIVPF */
            _.Move(0, PF0005W.LK_PF005_E_SIT_MOTIVO_SIVPF);

            /*" -329- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-COD-EMPRESA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PF0005W.LK_PF005_E_COD_EMPRESA_SIVPF);

            /*" -331- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-COD-PRODUTO-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PF0005W.LK_PF005_E_COD_PRODUTO_SIVPF);

            /*" -332- MOVE 'R' TO LK-PF005-E-IND-TP-ACAO */
            _.Move("R", PF0005W.LK_PF005_E_IND_TP_ACAO);

            /*" -334- MOVE 'S' TO LK-PF005-E-IND-TP-SENSIBILIZA */
            _.Move("S", PF0005W.LK_PF005_E_IND_TP_SENSIBILIZA);

            /*" -336- MOVE '0001-01-01' TO LK-PF005-E-DTA-INI-VIGENCIA LK-PF005-E-DTA-FIM-VIGENCIA */
            _.Move("0001-01-01", PF0005W.LK_PF005_E_DTA_INI_VIGENCIA, PF0005W.LK_PF005_E_DTA_FIM_VIGENCIA);

            /*" -338- MOVE DATA-SQL TO LK-PF005-E-DTA-PROCESSA-CEF */
            _.Move(WORK_AREA.DATA_SQL, PF0005W.LK_PF005_E_DTA_PROCESSA_CEF);

            /*" -339- IF REG8-TIPOREG EQUAL '8' */

            if (WS_REG_ENTRADA.FILLER_7.REG_TIPO_8.REG8_TIPOREG == "8")
            {

                /*" -340- MOVE REG8-NUM-PARCELA TO LK-PF005-E-NUM-PARCELA */
                _.Move(WS_REG_ENTRADA.FILLER_7.REG_TIPO_8.REG8_NUM_PARCELA, PF0005W.LK_PF005_E_NUM_PARCELA);

                /*" -342- MOVE REG8-COD-ENVIO TO LK-PF005-E-COD-TP-LANCAMENTO */
                _.Move(WS_REG_ENTRADA.FILLER_7.REG_TIPO_8.REG8_COD_ENVIO, PF0005W.LK_PF005_E_COD_TP_LANCAMENTO);

                /*" -343- MOVE REG8-VALOR TO LK-PF005-E-VLR-PREMIO */
                _.Move(WS_REG_ENTRADA.FILLER_7.REG_TIPO_8.REG8_VALOR, PF0005W.LK_PF005_E_VLR_PREMIO);

                /*" -344- ELSE */
            }
            else
            {


                /*" -345- MOVE 0 TO LK-PF005-E-NUM-PARCELA */
                _.Move(0, PF0005W.LK_PF005_E_NUM_PARCELA);

                /*" -347- MOVE 0 TO LK-PF005-E-COD-TP-LANCAMENTO */
                _.Move(0, PF0005W.LK_PF005_E_COD_TP_LANCAMENTO);

                /*" -349- MOVE PROPOFID-VAL-PAGO OF DCLPROPOSTA-FIDELIZ TO LK-PF005-E-VLR-PREMIO */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO, PF0005W.LK_PF005_E_VLR_PREMIO);

                /*" -350- END-IF */
            }


            /*" -352- MOVE REG-COD-RET-SIGPF TO LK-PF005-E-COD-ERRO */
            _.Move(WS_REG_ENTRADA.REG_TIPO_STATUS.REG_COD_RET_SIGPF, PF0005W.LK_PF005_E_COD_ERRO);

            /*" -353- PERFORM R1020-GRAVA-HISTORICO */

            R1020_GRAVA_HISTORICO_SECTION();

            /*" -353- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_EXIT*/

        [StopWatch]
        /*" R1020-GRAVA-HISTORICO-SECTION */
        private void R1020_GRAVA_HISTORICO_SECTION()
        {
            /*" -363- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R1020_00_START */

            R1020_00_START();

        }

        [StopWatch]
        /*" R1020-00-START */
        private void R1020_00_START(bool isPerform = false)
        {
            /*" -368- MOVE 'R1020' TO WNR-EXEC-SQL. */
            _.Move("R1020", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -369- MOVE 'N' TO LK-PF005-E-TRACE */
            _.Move("N", PF0005W.LK_PF005_E_TRACE);

            /*" -370- MOVE 01 TO LK-PF005-E-ACAO */
            _.Move(01, PF0005W.LK_PF005_E_ACAO);

            /*" -371- MOVE 'BATCH' TO LK-PF005-E-COD-USUARIO */
            _.Move("BATCH", PF0005W.LK_PF005_E_COD_USUARIO);

            /*" -373- MOVE 'PF4002B' TO LK-PF005-E-NOM-PROGRAMA. */
            _.Move("PF4002B", PF0005W.LK_PF005_E_NOM_PROGRAMA);

            /*" -373- PERFORM R1020-05-INICIO. */

            R1020_05_INICIO(true);

        }

        [StopWatch]
        /*" R1020-05-INICIO */
        private void R1020_05_INICIO(bool isPerform = false)
        {
            /*" -377- MOVE 'PF0005S' TO WS-PROGRAMA */
            _.Move("PF0005S", AREA_DE_WORK.WS_PROGRAMA);

            /*" -406- CALL WS-PROGRAMA USING LK-PF005-E-TRACE LK-PF005-E-ACAO LK-PF005-E-NUM-IDENTIFICACAO LK-PF005-E-DATA-SITUACAO LK-PF005-E-NSAS-SIVPF LK-PF005-E-NSL LK-PF005-E-SIT-PROPOSTA LK-PF005-E-SIT-COBRANCA-SIVPF LK-PF005-E-SIT-MOTIVO-SIVPF LK-PF005-E-COD-EMPRESA-SIVPF LK-PF005-E-COD-PRODUTO-SIVPF LK-PF005-E-IND-TP-ACAO LK-PF005-E-IND-TP-SENSIBILIZA LK-PF005-E-DTA-INI-VIGENCIA LK-PF005-E-DTA-FIM-VIGENCIA LK-PF005-E-NUM-PARCELA LK-PF005-E-COD-TP-LANCAMENTO LK-PF005-E-VLR-PREMIO LK-PF005-E-COD-ERRO LK-PF005-E-DTA-PROCESSA-CEF LK-PF005-E-COD-USUARIO LK-PF005-E-NOM-PROGRAMA LK-PF005-IND-ERRO LK-PF005-MENSAGEM LK-PF005-NOM-TABELA LK-PF005-SQLCODE LK-PF005-SQLERRMC LK-PF005-SQLSTATE. */
            _.Call(AREA_DE_WORK.WS_PROGRAMA, PF0005W);

            /*" -407- IF LK-PF005-IND-ERRO NOT = 0 */

            if (PF0005W.LK_PF005_IND_ERRO != 0)
            {

                /*" -408- DISPLAY '**    PF4002 - ERRO - SECTION R1020  ***' */
                _.Display($"**    PF4002 - ERRO - SECTION R1020  ***");

                /*" -409- MOVE LK-PF005-IND-ERRO TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_IND_ERRO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -410- DISPLAY '** IND-ERRO.....: ' LK-PF005-SQLCODE */
                _.Display($"** IND-ERRO.....: {PF0005W.LK_PF005_SQLCODE}");

                /*" -411- DISPLAY '** MENSAGEM.....: ' LK-PF005-MENSAGEM */
                _.Display($"** MENSAGEM.....: {PF0005W.LK_PF005_MENSAGEM}");

                /*" -412- DISPLAY '** NOM-TABELA...: ' LK-PF005-NOM-TABELA */
                _.Display($"** NOM-TABELA...: {PF0005W.LK_PF005_NOM_TABELA}");

                /*" -413- MOVE LK-PF005-SQLCODE TO WS-SMALLINT(01) */
                _.Move(PF0005W.LK_PF005_SQLCODE, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -414- DISPLAY '** SQLCODE......: ' LK-PF005-SQLCODE */
                _.Display($"** SQLCODE......: {PF0005W.LK_PF005_SQLCODE}");

                /*" -415- DISPLAY '** SQLERRMC.....: ' LK-PF005-SQLERRMC */
                _.Display($"** SQLERRMC.....: {PF0005W.LK_PF005_SQLERRMC}");

                /*" -416- DISPLAY '** SQLSTATE.....: ' LK-PF005-SQLSTATE */
                _.Display($"** SQLSTATE.....: {PF0005W.LK_PF005_SQLSTATE}");

                /*" -417- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -419- END-IF */
            }


            /*" -420- ADD 1 TO AC-GRAVADOS */
            WORK_AREA.DATA_SQL.AC_GRAVADOS.Value = WORK_AREA.DATA_SQL.AC_GRAVADOS + 1;

            /*" -420- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_EXIT*/

        [StopWatch]
        /*" R1005-00-SELECT-PROPOFID-SECTION */
        private void R1005_00_SELECT_PROPOFID_SECTION()
        {
            /*" -432- MOVE 'R1005' TO WNR-EXEC-SQL. */
            _.Move("R1005", WORK_AREA.DATA_SQL.WABEND.WNR_EXEC_SQL);

            /*" -433- MOVE REG-NUM-PROPOSTA TO PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Move(WS_REG_ENTRADA.REG_TIPO_STATUS.REG_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -436- DISPLAY 'PROPOFID-NUM-PROPOSTA-SIVPF ' PROPOFID-NUM-PROPOSTA-SIVPF */
            _.Display($"PROPOFID-NUM-PROPOSTA-SIVPF {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

            /*" -462- PERFORM R1005_00_SELECT_PROPOFID_DB_SELECT_1 */

            R1005_00_SELECT_PROPOFID_DB_SELECT_1();

            /*" -465- MOVE SQLCODE TO WS-SQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WS_SQLCODE);

            /*" -466- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -468- DISPLAY 'PF4002B NUMERO PROPOSTA ENTRADA = ' REG-NUM-PROPOSTA */
                _.Display($"PF4002B NUMERO PROPOSTA ENTRADA = {WS_REG_ENTRADA.REG_TIPO_STATUS.REG_NUM_PROPOSTA}");

                /*" -469- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WORK_AREA.DATA_SQL.WABEND.WSQLCODE);

                /*" -470- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -470- END-IF. */
            }


        }

        [StopWatch]
        /*" R1005-00-SELECT-PROPOFID-DB-SELECT-1 */
        public void R1005_00_SELECT_PROPOFID_DB_SELECT_1()
        {
            /*" -462- EXEC SQL SELECT NUM_IDENTIFICACAO , SIT_PROPOSTA , CANAL_PROPOSTA , ORIGEM_PROPOSTA , SITUACAO_ENVIO , COD_PRODUTO_SIVPF , SITUACAO_ENVIO , DATA_PROPOSTA , NUM_PROPOSTA_SIVPF, VAL_PAGO INTO :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-SITUACAO-ENVIO , :PROPOFID-DATA-PROPOSTA , :PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-VAL-PAGO FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC. */

            var r1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1 = new R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1.Execute(r1005_00_SELECT_PROPOFID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(executed_1.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(executed_1.PROPOFID_SITUACAO_ENVIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);
                _.Move(executed_1.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(executed_1.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(executed_1.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1005_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -480- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.DATA_SQL.WABEND.WSQLCODE);

            /*" -482- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, WORK_AREA.DATA_SQL.WABEND.WSQLERRMC);

            /*" -484- DISPLAY WABEND */
            _.Display(WORK_AREA.DATA_SQL.WABEND);

            /*" -484- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -486- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -490- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -490- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}