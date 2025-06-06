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
using Sias.Auto.DB2.AU2055B;

namespace Code
{
    public class AU2055B
    {
        public bool IsCall { get; set; }

        public AU2055B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------                                        */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  AUTO FACIL - CADMUS 74582          *      */
        /*"      *   PROGRAMA ...............  AU2055B                            *      */
        /*"      *   PROJETO ................  CADMUS 74582                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  COREON                             *      */
        /*"      *   PROGRAMADOR ............  COREON                             *      */
        /*"      *   DATA CODIFICACAO .......  DEZEMBRO / 2012                    *      */
        /*"      *   FUNCAO .................  CONCILIA COBRANCA E LIBERA PROPOSTA*      */
        /*"      *                             PARA EMISSAO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      H I S T O R I C O                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA     DATA   VERSAO FUNCAO                              *      */
        /*"      * COREON     12/12/12 V.00   DESENVOLVIMENTO                     *      */
        /*"      * COREON     19/04/13 V.01   ADESAO CARTAO DE CREDITO            *      */
        /*"      * COREON     01/04/14 V.02   ADESAO (3) OUTROS BANCOS            *      */
        /*"      * COREON     21/07/14 V.03   RENOVA��O AUTOM�TICA                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-DTCURRENT     PIC  X(010)    VALUE  SPACES.*/
        public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-CONGENERE     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-COD-FONTE     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis WHOST_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-PROPOSTA-VC   PIC S9(015)    VALUE +0 COMP-3.*/
        public IntBasis WHOST_PROPOSTA_VC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          WHOST-NUM-PROPOSTA  PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis WHOST_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          WHOST-TIPO-OPERACAO   PIC  X(003)  VALUE  SPACES.*/
        public StringBasis WHOST_TIPO_OPERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"77          WHOST-OCORR-HISTORICO PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis WHOST_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-COD-OPERACAO    PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis WHOST_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WHOST-DATA-REFERENCIA PIC  X(010)  VALUE  SPACES.*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          WHOST-VLR-PARCELA     PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis WHOST_VLR_PARCELA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          AREA-DE-WORK.*/
        public AU2055B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AU2055B_AREA_DE_WORK();
        public class AU2055B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WFIM-PROPOSTA       PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WFIM-MOVIMCOB       PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_MOVIMCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-RCAP           PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_RCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-PROPOSTA       PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WTEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WTEM-AU055          PIC  X(003)    VALUE  SPACES.*/
            public StringBasis WTEM_AU055 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05        WCH-LIBERA          PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WCH_LIBERA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-CT-SELEC         PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_SELEC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CT-DESPR         PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_DESPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CT-LIMITE        PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_LIMITE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CTC-BOL          PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CTC_BOL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CTC-DEB          PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CTC_DEB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CTC-DEBOT        PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CTC_DEBOT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CTC-ERNET        PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CTC_ERNET { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CTC-ORBIT        PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CTC_ORBIT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-DATA-AUX         PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WS-DATA-AUX-R       REDEFINES      WS-DATA-AUX.*/
            private _REDEF_AU2055B_WS_DATA_AUX_R _ws_data_aux_r { get; set; }
            public _REDEF_AU2055B_WS_DATA_AUX_R WS_DATA_AUX_R
            {
                get { _ws_data_aux_r = new _REDEF_AU2055B_WS_DATA_AUX_R(); _.Move(WS_DATA_AUX, _ws_data_aux_r); VarBasis.RedefinePassValue(WS_DATA_AUX, _ws_data_aux_r, WS_DATA_AUX); _ws_data_aux_r.ValueChanged += () => { _.Move(_ws_data_aux_r, WS_DATA_AUX); }; return _ws_data_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_aux_r, WS_DATA_AUX); }
            }  //Redefines
            public class _REDEF_AU2055B_WS_DATA_AUX_R : VarBasis
            {
                /*"    10      WS-ANO-AUX          PIC  9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-MES-AUX          PIC  9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-DIA-AUX          PIC  9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-DATA-EDIT        PIC  X(010)    VALUE  SPACES.*/

                public _REDEF_AU2055B_WS_DATA_AUX_R()
                {
                    WS_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATA_EDIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WS-DATA-EDIT-R      REDEFINES      WS-DATA-EDIT.*/
            private _REDEF_AU2055B_WS_DATA_EDIT_R _ws_data_edit_r { get; set; }
            public _REDEF_AU2055B_WS_DATA_EDIT_R WS_DATA_EDIT_R
            {
                get { _ws_data_edit_r = new _REDEF_AU2055B_WS_DATA_EDIT_R(); _.Move(WS_DATA_EDIT, _ws_data_edit_r); VarBasis.RedefinePassValue(WS_DATA_EDIT, _ws_data_edit_r, WS_DATA_EDIT); _ws_data_edit_r.ValueChanged += () => { _.Move(_ws_data_edit_r, WS_DATA_EDIT); }; return _ws_data_edit_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_edit_r, WS_DATA_EDIT); }
            }  //Redefines
            public class _REDEF_AU2055B_WS_DATA_EDIT_R : VarBasis
            {
                /*"    10      WS-DIA-EDIT         PIC  9(002).*/
                public IntBasis WS_DIA_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-MES-EDIT         PIC  9(002).*/
                public IntBasis WS_MES_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-ANO-EDIT         PIC  9(004).*/
                public IntBasis WS_ANO_EDIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05        WS-HORA-ACCEPT.*/

                public _REDEF_AU2055B_WS_DATA_EDIT_R()
                {
                    WS_DIA_EDIT.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_MES_EDIT.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_ANO_EDIT.ValueChanged += OnValueChanged;
                }

            }
            public AU2055B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new AU2055B_WS_HORA_ACCEPT();
            public class AU2055B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10      WS-HOR-ACCEPT       PIC  9(002).*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-MIN-ACCEPT       PIC  9(002).*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-SEG-ACCEPT       PIC  9(002).*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-CSS-ACCEPT       PIC  9(002).*/
                public IntBasis WS_CSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-HORA-EDIT        PIC  X(008)    VALUE  SPACES.*/
            }
            public StringBasis WS_HORA_EDIT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        WS-HORA-EDIT-R      REDEFINES      WS-HORA-EDIT.*/
            private _REDEF_AU2055B_WS_HORA_EDIT_R _ws_hora_edit_r { get; set; }
            public _REDEF_AU2055B_WS_HORA_EDIT_R WS_HORA_EDIT_R
            {
                get { _ws_hora_edit_r = new _REDEF_AU2055B_WS_HORA_EDIT_R(); _.Move(WS_HORA_EDIT, _ws_hora_edit_r); VarBasis.RedefinePassValue(WS_HORA_EDIT, _ws_hora_edit_r, WS_HORA_EDIT); _ws_hora_edit_r.ValueChanged += () => { _.Move(_ws_hora_edit_r, WS_HORA_EDIT); }; return _ws_hora_edit_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_edit_r, WS_HORA_EDIT); }
            }  //Redefines
            public class _REDEF_AU2055B_WS_HORA_EDIT_R : VarBasis
            {
                /*"    10      WS-HOR-EDIT         PIC  9(002).*/
                public IntBasis WS_HOR_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-MIN-EDIT         PIC  9(002).*/
                public IntBasis WS_MIN_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-SEG-EDIT         PIC  9(002).*/
                public IntBasis WS_SEG_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-DATA-CURR.*/

                public _REDEF_AU2055B_WS_HORA_EDIT_R()
                {
                    WS_HOR_EDIT.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_MIN_EDIT.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_SEG_EDIT.ValueChanged += OnValueChanged;
                }

            }
            public AU2055B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new AU2055B_WS_DATA_CURR();
            public class AU2055B_WS_DATA_CURR : VarBasis
            {
                /*"    10      WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WS-DATA-ACCEPT.*/
            }
            public AU2055B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new AU2055B_WS_DATA_ACCEPT();
            public class AU2055B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10      WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        LPARM.*/
            }
            public AU2055B_LPARM LPARM { get; set; } = new AU2055B_LPARM();
            public class AU2055B_LPARM : VarBasis
            {
                /*"    10      LPARM01.*/
                public AU2055B_LPARM01 LPARM01 { get; set; } = new AU2055B_LPARM01();
                public class AU2055B_LPARM01 : VarBasis
                {
                    /*"      15    LPARM01-AAAA        PIC  9(004).*/
                    public IntBasis LPARM01_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    FILLER              PIC  X(001).*/
                    public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LPARM01-MM          PIC  9(002).*/
                    public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    FILLER              PIC  X(001).*/
                    public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LPARM01-DD          PIC  9(002).*/
                    public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10      LPARM02.*/
                }
                public AU2055B_LPARM02 LPARM02 { get; set; } = new AU2055B_LPARM02();
                public class AU2055B_LPARM02 : VarBasis
                {
                    /*"      15    LPARM02-AAAA        PIC  9(004).*/
                    public IntBasis LPARM02_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    FILLER              PIC  X(001).*/
                    public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LPARM02-MM          PIC  9(002).*/
                    public IntBasis LPARM02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    FILLER              PIC  X(001).*/
                    public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      15    LPARM02-DD          PIC  9(002).*/
                    public IntBasis LPARM02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10      LPARM03             PIC S9(009)      COMP-3.*/
                }
                public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    10      IND-RETORNO         PIC  9(001).*/
                public IntBasis IND_RETORNO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10      MENSAGEM            PIC  X(070).*/
                public StringBasis MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"  05        WS-QTD-DIAS         PIC  9(005)      VALUE ZEROS.*/
            }
            public IntBasis WS_QTD_DIAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"01          WABEND.*/
        }
        public AU2055B_WABEND WABEND { get; set; } = new AU2055B_WABEND();
        public class AU2055B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC X(010) VALUE           ' AU2055B'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AU2055B");
            /*"  05        FILLER              PIC X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC X(005) VALUE '00000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
            /*"  05        FILLER              PIC X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01          WSQLERRO.*/
        }
        public AU2055B_WSQLERRO WSQLERRO { get; set; } = new AU2055B_WSQLERRO();
        public class AU2055B_WSQLERRO : VarBasis
        {
            /*"  05        FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
            /*"  05        WSQLERRMC           PIC  X(070) VALUE SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOSTA PROPOSTA { get; set; } = new Dclgens.PROPOSTA();
        public Dclgens.PROPOACO PROPOACO { get; set; } = new Dclgens.PROPOACO();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.PROPOAUT PROPOAUT { get; set; } = new Dclgens.PROPOAUT();
        public Dclgens.AU055 AU055 { get; set; } = new Dclgens.AU055();
        public Dclgens.AU057 AU057 { get; set; } = new Dclgens.AU057();
        public Dclgens.MOVIMCOB MOVIMCOB { get; set; } = new Dclgens.MOVIMCOB();
        public Dclgens.PROPCOBR PROPCOBR { get; set; } = new Dclgens.PROPCOBR();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.AU085 AU085 { get; set; } = new Dclgens.AU085();
        public AU2055B_C01_PROPOSTA C01_PROPOSTA { get; set; } = new AU2055B_C01_PROPOSTA();
        public AU2055B_C01_MOVIMCOB C01_MOVIMCOB { get; set; } = new AU2055B_C01_MOVIMCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -218- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WABEND.WNR_EXEC_SQL);

            /*" -219- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -222- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -225- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -229- DISPLAY ' ' */
            _.Display($" ");

            /*" -231- DISPLAY '*-------------------------------------------------' '------------------------*' */
            _.Display($"*-------------------------------------------------------------------------*");

            /*" -232- DISPLAY 'PROGRAMA EM EXECUCAO AU2055B' */
            _.Display($"PROGRAMA EM EXECUCAO AU2055B");

            /*" -236- DISPLAY 'VERSAO V.03 -  21/07/2014' */
            _.Display($"VERSAO V.03 -  21/07/2014");

            /*" -238- DISPLAY '*-------------------------------------------------' '------------------------*' */
            _.Display($"*-------------------------------------------------------------------------*");

            /*" -240- DISPLAY ' ' */
            _.Display($" ");

            /*" -242- MOVE 5631 TO WHOST-CONGENERE. */
            _.Move(5631, WHOST_CONGENERE);

            /*" -244- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -246- MOVE '00/00/0000' TO WS-DATA-EDIT. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDIT);

            /*" -247- MOVE WHOST-DTCURRENT TO WS-DATA-AUX. */
            _.Move(WHOST_DTCURRENT, AREA_DE_WORK.WS_DATA_AUX);

            /*" -248- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -249- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -251- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -253- MOVE '00:00:00' TO WS-HORA-EDIT. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_EDIT);

            /*" -254- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -255- MOVE WS-HOR-ACCEPT TO WS-HOR-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_HOR_EDIT);

            /*" -256- MOVE WS-MIN-ACCEPT TO WS-MIN-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_MIN_EDIT);

            /*" -258- MOVE WS-SEG-ACCEPT TO WS-SEG-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_SEG_EDIT);

            /*" -259- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -261- DISPLAY 'AU2055B - Inicio de Execucao - ' WS-DATA-EDIT ' - ' WS-HORA-EDIT. */

            $"AU2055B - Inicio de Execucao - {AREA_DE_WORK.WS_DATA_EDIT} - {AREA_DE_WORK.WS_HORA_EDIT}"
            .Display();

            /*" -263- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -263- PERFORM R2000-00-CONCILIACAO. */

            R2000_00_CONCILIACAO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -269- MOVE '00/00/0000' TO WS-DATA-EDIT. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDIT);

            /*" -270- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-AUX. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_AUX);

            /*" -271- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -272- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -274- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -275- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -276- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -277- DISPLAY '| DATA MOVTO :   ' WS-DATA-EDIT '         |' . */

            $"| DATA MOVTO :   {AREA_DE_WORK.WS_DATA_EDIT}         |"
            .Display();

            /*" -279- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -280- IF WS-CT-SELEC > ZEROS */

            if (AREA_DE_WORK.WS_CT_SELEC > 00)
            {

                /*" -281- DISPLAY '| Documentos Lidos ....... ' WS-CT-SELEC '  |' */

                $"| Documentos Lidos ....... {AREA_DE_WORK.WS_CT_SELEC}  |"
                .Display();

                /*" -282- DISPLAY '| Nao Conciliados                   |' */
                _.Display($"| Nao Conciliados                   |");

                /*" -283- DISPLAY '| - Pag.nao recepcionado . ' WS-CT-DESPR '  |' */

                $"| - Pag.nao recepcionado . {AREA_DE_WORK.WS_CT_DESPR}  |"
                .Display();

                /*" -284- DISPLAY '| - Renov.Autom.(Limite) . ' WS-CT-LIMITE '  |' */

                $"| - Renov.Autom.(Limite) . {AREA_DE_WORK.WS_CT_LIMITE}  |"
                .Display();

                /*" -285- DISPLAY '| Adesoes Conciliadas               |' */
                _.Display($"| Adesoes Conciliadas               |");

                /*" -286- DISPLAY '| - Boleto ............... ' WS-CTC-BOL '  |' */

                $"| - Boleto ............... {AREA_DE_WORK.WS_CTC_BOL}  |"
                .Display();

                /*" -287- DISPLAY '| - Debito                          |' */
                _.Display($"| - Debito                          |");

                /*" -288- DISPLAY '|   . CEF ................ ' WS-CTC-DEB '  |' */

                $"|   . CEF ................ {AREA_DE_WORK.WS_CTC_DEB}  |"
                .Display();

                /*" -289- DISPLAY '|   . Outros Bancos ...... ' WS-CTC-DEBOT '  |' */

                $"|   . Outros Bancos ...... {AREA_DE_WORK.WS_CTC_DEBOT}  |"
                .Display();

                /*" -290- DISPLAY '| - Cartao                          |' */
                _.Display($"| - Cartao                          |");

                /*" -291- DISPLAY '|   . ERNET .............. ' WS-CTC-ERNET '  |' */

                $"|   . ERNET .............. {AREA_DE_WORK.WS_CTC_ERNET}  |"
                .Display();

                /*" -292- DISPLAY '|   . ORBITALL ........... ' WS-CTC-ORBIT '  |' */

                $"|   . ORBITALL ........... {AREA_DE_WORK.WS_CTC_ORBIT}  |"
                .Display();

                /*" -293- DISPLAY '+-----------------------------------+' */
                _.Display($"+-----------------------------------+");

                /*" -294- ELSE */
            }
            else
            {


                /*" -295- DISPLAY '| NAO HOUVE MOVIMENTACAO NESTE DIA  |' */
                _.Display($"| NAO HOUVE MOVIMENTACAO NESTE DIA  |");

                /*" -297- DISPLAY '+-----------------------------------+' . */
                _.Display($"+-----------------------------------+");
            }


            /*" -299- MOVE '00/00/0000' TO WS-DATA-EDIT. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDIT);

            /*" -300- MOVE WHOST-DTCURRENT TO WS-DATA-AUX. */
            _.Move(WHOST_DTCURRENT, AREA_DE_WORK.WS_DATA_AUX);

            /*" -301- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -302- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -304- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -306- MOVE '00:00:00' TO WS-HORA-EDIT. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_EDIT);

            /*" -307- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -308- MOVE WS-HOR-ACCEPT TO WS-HOR-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_HOR_EDIT);

            /*" -309- MOVE WS-MIN-ACCEPT TO WS-MIN-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_MIN_EDIT);

            /*" -311- MOVE WS-SEG-ACCEPT TO WS-SEG-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_SEG_EDIT);

            /*" -312- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -315- DISPLAY 'AU2055B - Final de execucao  - ' WS-DATA-EDIT ' - ' WS-HORA-EDIT. */

            $"AU2055B - Final de execucao  - {AREA_DE_WORK.WS_DATA_EDIT} - {AREA_DE_WORK.WS_HORA_EDIT}"
            .Display();

            /*" -315- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -322- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -322- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -332- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WABEND.WNR_EXEC_SQL);

            /*" -339- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -342- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -343- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS (AU)' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS (AU)");

                /*" -343- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -339- EXEC SQL SELECT DATA_MOV_ABERTO , CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'AU' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DTCURRENT, WHOST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CONCILIACAO-SECTION */
        private void R2000_00_CONCILIACAO_SECTION()
        {
            /*" -357- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -358- PERFORM R2100-00-DECLARE-PROPOSTA */

            R2100_00_DECLARE_PROPOSTA_SECTION();

            /*" -359- PERFORM R2110-00-FETCH-PROPOSTA */

            R2110_00_FETCH_PROPOSTA_SECTION();

            /*" -363- PERFORM R2200-00-PROCESSA-PROPOSTA UNTIL WFIM-PROPOSTA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PROPOSTA.IsEmpty()))
            {

                R2200_00_PROCESSA_PROPOSTA_SECTION();
            }

            /*" -364- PERFORM R3100-00-DECLARE-MOVIMCOB */

            R3100_00_DECLARE_MOVIMCOB_SECTION();

            /*" -365- PERFORM R3110-00-FETCH-MOVIMCOB */

            R3110_00_FETCH_MOVIMCOB_SECTION();

            /*" -366- PERFORM R3200-00-PROCESSA-MOVIMCOB UNTIL WFIM-MOVIMCOB NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMCOB.IsEmpty()))
            {

                R3200_00_PROCESSA_MOVIMCOB_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-DECLARE-PROPOSTA-SECTION */
        private void R2100_00_DECLARE_PROPOSTA_SECTION()
        {
            /*" -379- MOVE 'R2100' TO WNR-EXEC-SQL. */
            _.Move("R2100", WABEND.WNR_EXEC_SQL);

            /*" -404- PERFORM R2100_00_DECLARE_PROPOSTA_DB_DECLARE_1 */

            R2100_00_DECLARE_PROPOSTA_DB_DECLARE_1();

            /*" -406- PERFORM R2100_00_DECLARE_PROPOSTA_DB_OPEN_1 */

            R2100_00_DECLARE_PROPOSTA_DB_OPEN_1();

            /*" -409- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -410- DISPLAY 'R2100 - ERRO NO DECLARE DA PROPOSTAS' */
                _.Display($"R2100 - ERRO NO DECLARE DA PROPOSTAS");

                /*" -411- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -412- ELSE */
            }
            else
            {


                /*" -412- MOVE SPACES TO WFIM-PROPOSTA. */
                _.Move("", AREA_DE_WORK.WFIM_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R2100-00-DECLARE-PROPOSTA-DB-DECLARE-1 */
        public void R2100_00_DECLARE_PROPOSTA_DB_DECLARE_1()
        {
            /*" -404- EXEC SQL DECLARE C01_PROPOSTA CURSOR FOR SELECT A.COD_FONTE ,A.NUM_PROPOSTA ,A.NUM_RCAP ,C.TIPO_COBRANCA ,VALUE(D.IND_FORMA_PAGTO_AD, '0' ) ,A.DATA_INIVIGENCIA ,A.NUM_APOL_ANTERIOR FROM SEGUROS.PROPOSTAS A ,SEGUROS.PROPOSTA_ACOMPANHA B ,SEGUROS.PROPOSTA_COBRANCA C ,SEGUROS.AU_PROPOSTA_COMPL D WHERE A.SIT_REGISTRO = ' ' AND A.COD_PRODUTO IN ( 5303, 5302, 5304 ) AND B.COD_FONTE = A.COD_FONTE AND B.NUM_PROPOSTA = A.NUM_PROPOSTA AND B.COD_OPERACAO = 9002 AND B.OCORR_HISTORICO = 01 AND B.COD_USUARIO = 'AU2050B' AND B.COD_FONTE = C.COD_FONTE AND B.NUM_PROPOSTA = C.NUM_PROPOSTA AND C.COD_FONTE = D.COD_FONTE AND C.NUM_PROPOSTA = D.NUM_PROPOSTA ORDER BY A.COD_FONTE, A.NUM_PROPOSTA END-EXEC. */
            C01_PROPOSTA = new AU2055B_C01_PROPOSTA(false);
            string GetQuery_C01_PROPOSTA()
            {
                var query = @$"SELECT A.COD_FONTE 
							,A.NUM_PROPOSTA 
							,A.NUM_RCAP 
							,C.TIPO_COBRANCA 
							,VALUE(D.IND_FORMA_PAGTO_AD
							, '0' ) 
							,A.DATA_INIVIGENCIA 
							,A.NUM_APOL_ANTERIOR 
							FROM SEGUROS.PROPOSTAS A 
							,SEGUROS.PROPOSTA_ACOMPANHA B 
							,SEGUROS.PROPOSTA_COBRANCA C 
							,SEGUROS.AU_PROPOSTA_COMPL D 
							WHERE A.SIT_REGISTRO = ' ' 
							AND A.COD_PRODUTO IN ( 5303
							, 5302
							, 5304 ) 
							AND B.COD_FONTE = A.COD_FONTE 
							AND B.NUM_PROPOSTA = A.NUM_PROPOSTA 
							AND B.COD_OPERACAO = 9002 
							AND B.OCORR_HISTORICO = 01 
							AND B.COD_USUARIO = 'AU2050B' 
							AND B.COD_FONTE = C.COD_FONTE 
							AND B.NUM_PROPOSTA = C.NUM_PROPOSTA 
							AND C.COD_FONTE = D.COD_FONTE 
							AND C.NUM_PROPOSTA = D.NUM_PROPOSTA 
							ORDER BY A.COD_FONTE
							, 
							A.NUM_PROPOSTA";

                return query;
            }
            C01_PROPOSTA.GetQueryEvent += GetQuery_C01_PROPOSTA;

        }

        [StopWatch]
        /*" R2100-00-DECLARE-PROPOSTA-DB-OPEN-1 */
        public void R2100_00_DECLARE_PROPOSTA_DB_OPEN_1()
        {
            /*" -406- EXEC SQL OPEN C01_PROPOSTA END-EXEC. */

            C01_PROPOSTA.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-MOVIMCOB-DB-DECLARE-1 */
        public void R3100_00_DECLARE_MOVIMCOB_DB_DECLARE_1()
        {
            /*" -690- EXEC SQL DECLARE C01_MOVIMCOB CURSOR FOR SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.NUM_AVISO , A.NUM_FITA , A.DATA_MOVIMENTO , A.DATA_QUITACAO , A.NUM_TITULO , A.COD_MOVIMENTO , A.COD_BANCO , A.COD_AGENCIA , A.VAL_TITULO , A.VAL_IOCC , A.VAL_CREDITO , A.NOME_SEGURADO , A.NUM_NOSSO_TITULO , B.DATA_INIVIGENCIA , B.NUM_APOL_ANTERIOR FROM SEGUROS.MOVIMENTO_COBRANCA A , SEGUROS.PROPOSTAS B WHERE A.SIT_REGISTRO = ' ' AND A.TIPO_MOVIMENTO = 'Y' AND A.NUM_AVISO IN (23000, 12000) AND CAST(A.NUM_APOLICE AS SMALLINT) = B.COD_FONTE AND A.NUM_ENDOSSO = B.NUM_PROPOSTA ORDER BY A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA END-EXEC. */
            C01_MOVIMCOB = new AU2055B_C01_MOVIMCOB(false);
            string GetQuery_C01_MOVIMCOB()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.NUM_AVISO
							, 
							A.NUM_FITA
							, 
							A.DATA_MOVIMENTO
							, 
							A.DATA_QUITACAO
							, 
							A.NUM_TITULO
							, 
							A.COD_MOVIMENTO
							, 
							A.COD_BANCO
							, 
							A.COD_AGENCIA
							, 
							A.VAL_TITULO
							, 
							A.VAL_IOCC
							, 
							A.VAL_CREDITO
							, 
							A.NOME_SEGURADO
							, 
							A.NUM_NOSSO_TITULO
							, 
							B.DATA_INIVIGENCIA
							, 
							B.NUM_APOL_ANTERIOR 
							FROM SEGUROS.MOVIMENTO_COBRANCA A
							, 
							SEGUROS.PROPOSTAS B 
							WHERE A.SIT_REGISTRO = ' ' 
							AND A.TIPO_MOVIMENTO = 'Y' 
							AND A.NUM_AVISO IN (23000
							, 12000) 
							AND CAST(A.NUM_APOLICE AS SMALLINT) = B.COD_FONTE 
							AND A.NUM_ENDOSSO = B.NUM_PROPOSTA 
							ORDER BY A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA";

                return query;
            }
            C01_MOVIMCOB.GetQueryEvent += GetQuery_C01_MOVIMCOB;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2110-00-FETCH-PROPOSTA-SECTION */
        private void R2110_00_FETCH_PROPOSTA_SECTION()
        {
            /*" -425- MOVE 'R2110' TO WNR-EXEC-SQL. */
            _.Move("R2110", WABEND.WNR_EXEC_SQL);

            /*" -433- PERFORM R2110_00_FETCH_PROPOSTA_DB_FETCH_1 */

            R2110_00_FETCH_PROPOSTA_DB_FETCH_1();

            /*" -436- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -437- ADD 1 TO WS-CT-SELEC */
                AREA_DE_WORK.WS_CT_SELEC.Value = AREA_DE_WORK.WS_CT_SELEC + 1;

                /*" -438- ELSE */
            }
            else
            {


                /*" -439- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -440- MOVE 'S' TO WFIM-PROPOSTA */
                    _.Move("S", AREA_DE_WORK.WFIM_PROPOSTA);

                    /*" -440- PERFORM R2110_00_FETCH_PROPOSTA_DB_CLOSE_1 */

                    R2110_00_FETCH_PROPOSTA_DB_CLOSE_1();

                    /*" -442- ELSE */
                }
                else
                {


                    /*" -443- DISPLAY 'R2110 - ERRO NO FETCH DA PROPOSTAS' */
                    _.Display($"R2110 - ERRO NO FETCH DA PROPOSTAS");

                    /*" -444- DISPLAY 'FONTE    - ' PROPOSTA-COD-FONTE */
                    _.Display($"FONTE    - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE}");

                    /*" -445- DISPLAY 'PROPOSTA - ' PROPOSTA-NUM-PROPOSTA */
                    _.Display($"PROPOSTA - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA}");

                    /*" -446- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -447- END-IF */
                }


                /*" -447- END-IF. */
            }


        }

        [StopWatch]
        /*" R2110-00-FETCH-PROPOSTA-DB-FETCH-1 */
        public void R2110_00_FETCH_PROPOSTA_DB_FETCH_1()
        {
            /*" -433- EXEC SQL FETCH C01_PROPOSTA INTO :PROPOSTA-COD-FONTE ,:PROPOSTA-NUM-PROPOSTA ,:PROPOSTA-NUM-RCAP ,:PROPCOBR-TIPO-COBRANCA ,:AU085-IND-FORMA-PAGTO-AD ,:PROPOSTA-DATA-INIVIGENCIA ,:PROPOSTA-NUM-APOL-ANTERIOR END-EXEC. */

            if (C01_PROPOSTA.Fetch())
            {
                _.Move(C01_PROPOSTA.PROPOSTA_COD_FONTE, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE);
                _.Move(C01_PROPOSTA.PROPOSTA_NUM_PROPOSTA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA);
                _.Move(C01_PROPOSTA.PROPOSTA_NUM_RCAP, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_RCAP);
                _.Move(C01_PROPOSTA.PROPCOBR_TIPO_COBRANCA, PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA);
                _.Move(C01_PROPOSTA.AU085_IND_FORMA_PAGTO_AD, AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);
                _.Move(C01_PROPOSTA.PROPOSTA_DATA_INIVIGENCIA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA);
                _.Move(C01_PROPOSTA.PROPOSTA_NUM_APOL_ANTERIOR, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_APOL_ANTERIOR);
            }

        }

        [StopWatch]
        /*" R2110-00-FETCH-PROPOSTA-DB-CLOSE-1 */
        public void R2110_00_FETCH_PROPOSTA_DB_CLOSE_1()
        {
            /*" -440- EXEC SQL CLOSE C01_PROPOSTA END-EXEC */

            C01_PROPOSTA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2110_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-PROPOSTA-SECTION */
        private void R2200_00_PROCESSA_PROPOSTA_SECTION()
        {
            /*" -460- MOVE 'R2200' TO WNR-EXEC-SQL. */
            _.Move("R2200", WABEND.WNR_EXEC_SQL);

            /*" -462- PERFORM R2210-00-SELECT-RCAPS. */

            R2210_00_SELECT_RCAPS_SECTION();

            /*" -463- IF WTEM-RCAP EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_RCAP == "N")
            {

                /*" -467- ADD 1 TO WS-CT-DESPR */
                AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                /*" -469- GO TO R2200-90-LER-PROXIMO. */

                R2200_90_LER_PROXIMO(); //GOTO
                return;
            }


            /*" -471- IF AU085-IND-FORMA-PAGTO-AD EQUAL '4' OR '3' */

            if (AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD.In("4", "3"))
            {

                /*" -472- ADD 1 TO WS-CT-DESPR */
                AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                /*" -476- GO TO R2200-90-LER-PROXIMO. */

                R2200_90_LER_PROXIMO(); //GOTO
                return;
            }


            /*" -478- IF PROPOSTA-NUM-APOL-ANTERIOR GREATER ZEROS */

            if (PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_APOL_ANTERIOR > 00)
            {

                /*" -479- PERFORM R4000-00-VERIFICA-LIMITE */

                R4000_00_VERIFICA_LIMITE_SECTION();

                /*" -480- IF WCH-LIBERA EQUAL 'N' */

                if (AREA_DE_WORK.WCH_LIBERA == "N")
                {

                    /*" -481- ADD 1 TO WS-CT-LIMITE */
                    AREA_DE_WORK.WS_CT_LIMITE.Value = AREA_DE_WORK.WS_CT_LIMITE + 1;

                    /*" -482- ADD 1 TO WS-CT-DESPR */
                    AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                    /*" -483- GO TO R2200-90-LER-PROXIMO */

                    R2200_90_LER_PROXIMO(); //GOTO
                    return;

                    /*" -484- END-IF */
                }


                /*" -486- END-IF. */
            }


            /*" -488- PERFORM R2220-00-SELECT-PROPOAUT */

            R2220_00_SELECT_PROPOAUT_SECTION();

            /*" -490- PERFORM R2230-00-UPDATE-PROPOSTAS */

            R2230_00_UPDATE_PROPOSTAS_SECTION();

            /*" -492- PERFORM R2240-00-ATUALIZA-PAINEL */

            R2240_00_ATUALIZA_PAINEL_SECTION();

            /*" -494- IF PROPCOBR-TIPO-COBRANCA EQUAL '0' */

            if (PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA == "0")
            {

                /*" -495- ADD 1 TO WS-CTC-BOL */
                AREA_DE_WORK.WS_CTC_BOL.Value = AREA_DE_WORK.WS_CTC_BOL + 1;

                /*" -496- ELSE */
            }
            else
            {


                /*" -498- IF PROPCOBR-TIPO-COBRANCA EQUAL '1' */

                if (PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA == "1")
                {

                    /*" -499- ADD 1 TO WS-CTC-DEB */
                    AREA_DE_WORK.WS_CTC_DEB.Value = AREA_DE_WORK.WS_CTC_DEB + 1;

                    /*" -500- ELSE */
                }
                else
                {


                    /*" -502- IF PROPCOBR-TIPO-COBRANCA EQUAL '2' */

                    if (PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA == "2")
                    {

                        /*" -504- ADD 1 TO WS-CTC-ORBIT. */
                        AREA_DE_WORK.WS_CTC_ORBIT.Value = AREA_DE_WORK.WS_CTC_ORBIT + 1;
                    }

                }

            }


            /*" -507- DISPLAY 'Proposta ..... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Conciliada' . */

            $"Proposta ..... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Conciliada"
            .Display();

            /*" -0- FLUXCONTROL_PERFORM R2200_90_LER_PROXIMO */

            R2200_90_LER_PROXIMO();

        }

        [StopWatch]
        /*" R2200-90-LER-PROXIMO */
        private void R2200_90_LER_PROXIMO(bool isPerform = false)
        {
            /*" -511- PERFORM R2110-00-FETCH-PROPOSTA. */

            R2110_00_FETCH_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2210-00-SELECT-RCAPS-SECTION */
        private void R2210_00_SELECT_RCAPS_SECTION()
        {
            /*" -524- MOVE 'R2210' TO WNR-EXEC-SQL. */
            _.Move("R2210", WABEND.WNR_EXEC_SQL);

            /*" -542- PERFORM R2210_00_SELECT_RCAPS_DB_SELECT_1 */

            R2210_00_SELECT_RCAPS_DB_SELECT_1();

            /*" -545- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -546- MOVE 'S' TO WTEM-RCAP */
                _.Move("S", AREA_DE_WORK.WTEM_RCAP);

                /*" -547- ELSE */
            }
            else
            {


                /*" -548- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -549- MOVE 'N' TO WTEM-RCAP */
                    _.Move("N", AREA_DE_WORK.WTEM_RCAP);

                    /*" -550- ELSE */
                }
                else
                {


                    /*" -551- DISPLAY 'R2210 - ERRO NO SELECT DA RCAPS' */
                    _.Display($"R2210 - ERRO NO SELECT DA RCAPS");

                    /*" -552- DISPLAY 'FONTE    - ' PROPOSTA-COD-FONTE */
                    _.Display($"FONTE    - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE}");

                    /*" -553- DISPLAY 'PROPOSTA - ' PROPOSTA-NUM-PROPOSTA */
                    _.Display($"PROPOSTA - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA}");

                    /*" -554- DISPLAY 'NUM RCAP - ' PROPOSTA-NUM-RCAP */
                    _.Display($"NUM RCAP - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_RCAP}");

                    /*" -554- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2210-00-SELECT-RCAPS-DB-SELECT-1 */
        public void R2210_00_SELECT_RCAPS_DB_SELECT_1()
        {
            /*" -542- EXEC SQL SELECT NUM_RCAP , COD_FONTE , NUM_PROPOSTA , DATA_CADASTRAMENTO , DATA_MOVIMENTO , VAL_RCAP_PRINCIPAL , VALUE(NUM_TITULO,+0) INTO :RCAPS-NUM-RCAP , :RCAPS-COD-FONTE , :RCAPS-NUM-PROPOSTA , :RCAPS-DATA-CADASTRAMENTO , :RCAPS-DATA-MOVIMENTO , :RCAPS-VAL-RCAP-PRINCIPAL , :RCAPS-NUM-TITULO FROM SEGUROS.RCAPS WHERE NUM_RCAP = :PROPOSTA-NUM-RCAP AND SIT_REGISTRO = '0' END-EXEC. */

            var r2210_00_SELECT_RCAPS_DB_SELECT_1_Query1 = new R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1()
            {
                PROPOSTA_NUM_RCAP = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_RCAP.ToString(),
            };

            var executed_1 = R2210_00_SELECT_RCAPS_DB_SELECT_1_Query1.Execute(r2210_00_SELECT_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2210_99_SAIDA*/

        [StopWatch]
        /*" R2220-00-SELECT-PROPOAUT-SECTION */
        private void R2220_00_SELECT_PROPOAUT_SECTION()
        {
            /*" -567- MOVE 'R2220' TO WNR-EXEC-SQL. */
            _.Move("R2220", WABEND.WNR_EXEC_SQL);

            /*" -591- PERFORM R2220_00_SELECT_PROPOAUT_DB_SELECT_1 */

            R2220_00_SELECT_PROPOAUT_DB_SELECT_1();

            /*" -594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -595- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -597- MOVE ZEROS TO PROPOAUT-NUM-PROPOSTA-CONV */
                    _.Move(0, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV);

                    /*" -598- ELSE */
                }
                else
                {


                    /*" -599- DISPLAY 'R2220 - ERRO NO SELECT DA PROPOSTA-AUTO' */
                    _.Display($"R2220 - ERRO NO SELECT DA PROPOSTA-AUTO");

                    /*" -600- DISPLAY 'FONTE    - ' PROPOSTA-COD-FONTE */
                    _.Display($"FONTE    - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE}");

                    /*" -601- DISPLAY 'PROPOSTA - ' PROPOSTA-NUM-PROPOSTA */
                    _.Display($"PROPOSTA - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA}");

                    /*" -601- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2220-00-SELECT-PROPOAUT-DB-SELECT-1 */
        public void R2220_00_SELECT_PROPOAUT_DB_SELECT_1()
        {
            /*" -591- EXEC SQL SELECT A.COD_FONTE ,A.NUM_PROPOSTA ,VALUE(A.TIPO_COBRANCA, ' ' ) ,VALUE(A.NUM_RECIBO_CONV,+0) ,VALUE(A.IND_TP_RENOVACAO,+0) ,VALUE(A.NUM_PROPOSTA_CONV,+0) INTO :PROPOAUT-COD-FONTE ,:PROPOAUT-NUM-PROPOSTA ,:PROPOAUT-TIPO-COBRANCA ,:PROPOAUT-NUM-RECIBO-CONV ,:PROPOAUT-IND-TP-RENOVACAO ,:PROPOAUT-NUM-PROPOSTA-CONV FROM SEGUROS.PROPOSTA_AUTO A WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA AND A.SIT_REGISTRO <> '2' AND A.NUM_ITEM = (SELECT MAX(B.NUM_ITEM) FROM SEGUROS.PROPOSTA_AUTO B WHERE A.COD_FONTE = B.COD_FONTE AND A.NUM_PROPOSTA = B.NUM_PROPOSTA) END-EXEC. */

            var r2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 = new R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1()
            {
                PROPOSTA_NUM_PROPOSTA = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA.ToString(),
                PROPOSTA_COD_FONTE = PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE.ToString(),
            };

            var executed_1 = R2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1.Execute(r2220_00_SELECT_PROPOAUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOAUT_COD_FONTE, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_COD_FONTE);
                _.Move(executed_1.PROPOAUT_NUM_PROPOSTA, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA);
                _.Move(executed_1.PROPOAUT_TIPO_COBRANCA, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_TIPO_COBRANCA);
                _.Move(executed_1.PROPOAUT_NUM_RECIBO_CONV, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_RECIBO_CONV);
                _.Move(executed_1.PROPOAUT_IND_TP_RENOVACAO, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_IND_TP_RENOVACAO);
                _.Move(executed_1.PROPOAUT_NUM_PROPOSTA_CONV, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2220_99_SAIDA*/

        [StopWatch]
        /*" R2230-00-UPDATE-PROPOSTAS-SECTION */
        private void R2230_00_UPDATE_PROPOSTAS_SECTION()
        {
            /*" -614- MOVE 'R2230' TO WNR-EXEC-SQL. */
            _.Move("R2230", WABEND.WNR_EXEC_SQL);

            /*" -620- PERFORM R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1 */

            R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1();

            /*" -623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -624- DISPLAY 'R2230 - ERRO NO UPDATE DA PROPOSTAS' */
                _.Display($"R2230 - ERRO NO UPDATE DA PROPOSTAS");

                /*" -625- DISPLAY 'FONTE    - ' PROPOSTA-COD-FONTE */
                _.Display($"FONTE    - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE}");

                /*" -626- DISPLAY 'PROPOSTA - ' PROPOSTA-NUM-PROPOSTA */
                _.Display($"PROPOSTA - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA}");

                /*" -626- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2230-00-UPDATE-PROPOSTAS-DB-UPDATE-1 */
        public void R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1()
        {
            /*" -620- EXEC SQL UPDATE SEGUROS.PROPOSTAS SET SIT_REGISTRO = '0' WHERE COD_FONTE = :PROPOSTA-COD-FONTE AND NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA AND SIT_REGISTRO = ' ' END-EXEC. */

            var r2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1 = new R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1()
            {
                PROPOSTA_NUM_PROPOSTA = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA.ToString(),
                PROPOSTA_COD_FONTE = PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE.ToString(),
            };

            R2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1.Execute(r2230_00_UPDATE_PROPOSTAS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2230_99_SAIDA*/

        [StopWatch]
        /*" R2240-00-ATUALIZA-PAINEL-SECTION */
        private void R2240_00_ATUALIZA_PAINEL_SECTION()
        {
            /*" -639- MOVE 'R2240' TO WNR-EXEC-SQL. */
            _.Move("R2240", WABEND.WNR_EXEC_SQL);

            /*" -641- MOVE PROPOAUT-NUM-PROPOSTA-CONV TO WHOST-PROPOSTA-VC */
            _.Move(PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV, WHOST_PROPOSTA_VC);

            /*" -643- MOVE PROPOSTA-COD-FONTE TO WHOST-COD-FONTE */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE, WHOST_COD_FONTE);

            /*" -645- MOVE PROPOSTA-NUM-PROPOSTA TO WHOST-NUM-PROPOSTA */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA, WHOST_NUM_PROPOSTA);

            /*" -648- MOVE RCAPS-VAL-RCAP-PRINCIPAL TO WHOST-VLR-PARCELA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL, WHOST_VLR_PARCELA);

            /*" -648- PERFORM R5000-00-ATUALIZA-HISTORICO. */

            R5000_00_ATUALIZA_HISTORICO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2240_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DECLARE-MOVIMCOB-SECTION */
        private void R3100_00_DECLARE_MOVIMCOB_SECTION()
        {
            /*" -661- MOVE 'R3100' TO WNR-EXEC-SQL. */
            _.Move("R3100", WABEND.WNR_EXEC_SQL);

            /*" -690- PERFORM R3100_00_DECLARE_MOVIMCOB_DB_DECLARE_1 */

            R3100_00_DECLARE_MOVIMCOB_DB_DECLARE_1();

            /*" -692- PERFORM R3100_00_DECLARE_MOVIMCOB_DB_OPEN_1 */

            R3100_00_DECLARE_MOVIMCOB_DB_OPEN_1();

            /*" -695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -696- DISPLAY 'R3100 - ERRO NO DECLARE DA MOVIMCOB' */
                _.Display($"R3100 - ERRO NO DECLARE DA MOVIMCOB");

                /*" -697- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -698- ELSE */
            }
            else
            {


                /*" -698- MOVE SPACES TO WFIM-MOVIMCOB. */
                _.Move("", AREA_DE_WORK.WFIM_MOVIMCOB);
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-MOVIMCOB-DB-OPEN-1 */
        public void R3100_00_DECLARE_MOVIMCOB_DB_OPEN_1()
        {
            /*" -692- EXEC SQL OPEN C01_MOVIMCOB END-EXEC. */

            C01_MOVIMCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-MOVIMCOB-SECTION */
        private void R3110_00_FETCH_MOVIMCOB_SECTION()
        {
            /*" -711- MOVE 'R3110' TO WNR-EXEC-SQL. */
            _.Move("R3110", WABEND.WNR_EXEC_SQL);

            /*" -730- PERFORM R3110_00_FETCH_MOVIMCOB_DB_FETCH_1 */

            R3110_00_FETCH_MOVIMCOB_DB_FETCH_1();

            /*" -733- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -734- ADD 1 TO WS-CT-SELEC */
                AREA_DE_WORK.WS_CT_SELEC.Value = AREA_DE_WORK.WS_CT_SELEC + 1;

                /*" -735- ELSE */
            }
            else
            {


                /*" -736- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -737- MOVE 'S' TO WFIM-MOVIMCOB */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMCOB);

                    /*" -737- PERFORM R3110_00_FETCH_MOVIMCOB_DB_CLOSE_1 */

                    R3110_00_FETCH_MOVIMCOB_DB_CLOSE_1();

                    /*" -739- ELSE */
                }
                else
                {


                    /*" -740- DISPLAY 'R3110 - ERRO NO FETCH DA MOVIMCOB' */
                    _.Display($"R3110 - ERRO NO FETCH DA MOVIMCOB");

                    /*" -741- DISPLAY 'APOLICE  - ' MOVIMCOB-NUM-APOLICE */
                    _.Display($"APOLICE  - {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                    /*" -742- DISPLAY 'ENDOSSO  - ' MOVIMCOB-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                    /*" -743- DISPLAY 'PARCELA  - ' MOVIMCOB-NUM-PARCELA */
                    _.Display($"PARCELA  - {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                    /*" -744- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -745- END-IF */
                }


                /*" -745- END-IF. */
            }


        }

        [StopWatch]
        /*" R3110-00-FETCH-MOVIMCOB-DB-FETCH-1 */
        public void R3110_00_FETCH_MOVIMCOB_DB_FETCH_1()
        {
            /*" -730- EXEC SQL FETCH C01_MOVIMCOB INTO :MOVIMCOB-NUM-APOLICE , :MOVIMCOB-NUM-ENDOSSO , :MOVIMCOB-NUM-PARCELA , :MOVIMCOB-NUM-AVISO , :MOVIMCOB-NUM-FITA , :MOVIMCOB-DATA-MOVIMENTO , :MOVIMCOB-DATA-QUITACAO , :MOVIMCOB-NUM-TITULO , :MOVIMCOB-COD-MOVIMENTO , :MOVIMCOB-COD-BANCO , :MOVIMCOB-COD-AGENCIA , :MOVIMCOB-VAL-TITULO , :MOVIMCOB-VAL-IOCC , :MOVIMCOB-VAL-CREDITO , :MOVIMCOB-NOME-SEGURADO , :MOVIMCOB-NUM-NOSSO-TITULO , :PROPOSTA-DATA-INIVIGENCIA , :PROPOSTA-NUM-APOL-ANTERIOR END-EXEC. */

            if (C01_MOVIMCOB.Fetch())
            {
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_APOLICE, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_ENDOSSO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_PARCELA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_AVISO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_FITA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_FITA);
                _.Move(C01_MOVIMCOB.MOVIMCOB_DATA_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_MOVIMENTO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_DATA_QUITACAO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_DATA_QUITACAO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_TITULO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_COD_MOVIMENTO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_MOVIMENTO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_COD_BANCO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_BANCO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_COD_AGENCIA, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_COD_AGENCIA);
                _.Move(C01_MOVIMCOB.MOVIMCOB_VAL_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_TITULO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_VAL_IOCC, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_IOCC);
                _.Move(C01_MOVIMCOB.MOVIMCOB_VAL_CREDITO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NOME_SEGURADO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NOME_SEGURADO);
                _.Move(C01_MOVIMCOB.MOVIMCOB_NUM_NOSSO_TITULO, MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_NOSSO_TITULO);
                _.Move(C01_MOVIMCOB.PROPOSTA_DATA_INIVIGENCIA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA);
                _.Move(C01_MOVIMCOB.PROPOSTA_NUM_APOL_ANTERIOR, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_APOL_ANTERIOR);
            }

        }

        [StopWatch]
        /*" R3110-00-FETCH-MOVIMCOB-DB-CLOSE-1 */
        public void R3110_00_FETCH_MOVIMCOB_DB_CLOSE_1()
        {
            /*" -737- EXEC SQL CLOSE C01_MOVIMCOB END-EXEC */

            C01_MOVIMCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-PROCESSA-MOVIMCOB-SECTION */
        private void R3200_00_PROCESSA_MOVIMCOB_SECTION()
        {
            /*" -758- MOVE 'R3200' TO WNR-EXEC-SQL. */
            _.Move("R3200", WABEND.WNR_EXEC_SQL);

            /*" -759- MOVE SPACES TO WTEM-PROPOSTA */
            _.Move("", AREA_DE_WORK.WTEM_PROPOSTA);

            /*" -761- MOVE MOVIMCOB-NUM-APOLICE TO PROPOSTA-COD-FONTE */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE);

            /*" -763- MOVE MOVIMCOB-NUM-ENDOSSO TO PROPOSTA-NUM-PROPOSTA */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA);

            /*" -764- PERFORM R3210-00-SELECT-PROPOSTA */

            R3210_00_SELECT_PROPOSTA_SECTION();

            /*" -765- IF WTEM-PROPOSTA EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_PROPOSTA == "N")
            {

                /*" -766- IF MOVIMCOB-NUM-AVISO = 23000 */

                if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 23000)
                {

                    /*" -769- DISPLAY 'Cartao ....... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' - Proposta Nao encontrada' */

                    $"Cartao ....... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} - Proposta Nao encontrada"
                    .Display();

                    /*" -770- ELSE */
                }
                else
                {


                    /*" -773- DISPLAY 'Deb Outros ... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' - Proposta Nao encontrada' */

                    $"Deb Outros ... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} - Proposta Nao encontrada"
                    .Display();

                    /*" -774- END-IF */
                }


                /*" -775- ADD 1 TO WS-CT-DESPR */
                AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                /*" -776- GO TO R3200-90-LER-PROXIMO */

                R3200_90_LER_PROXIMO(); //GOTO
                return;

                /*" -778- END-IF. */
            }


            /*" -780- MOVE PROPOSTA-COD-FONTE TO AU085-COD-FONTE */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE, AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_FONTE);

            /*" -782- MOVE PROPOSTA-NUM-PROPOSTA TO AU085-NUM-PROPOSTA */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA, AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_PROPOSTA);

            /*" -784- PERFORM R3215-00-SELECT-AU085 */

            R3215_00_SELECT_AU085_SECTION();

            /*" -786- IF PROPOSTA-SIT-REGISTRO EQUAL '1' */

            if (PROPOSTA.DCLPROPOSTAS.PROPOSTA_SIT_REGISTRO == "1")
            {

                /*" -787- IF MOVIMCOB-NUM-AVISO = 23000 */

                if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 23000)
                {

                    /*" -791- DISPLAY 'Cartao ....... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Proposta Emitida' */

                    $"Cartao ....... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Proposta Emitida"
                    .Display();

                    /*" -792- ELSE */
                }
                else
                {


                    /*" -796- DISPLAY 'Deb Outros ... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Proposta Emitida' */

                    $"Deb Outros ... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Proposta Emitida"
                    .Display();

                    /*" -797- END-IF */
                }


                /*" -798- ADD 1 TO WS-CT-DESPR */
                AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                /*" -800- GO TO R3200-90-LER-PROXIMO. */

                R3200_90_LER_PROXIMO(); //GOTO
                return;
            }


            /*" -802- IF PROPOSTA-SIT-REGISTRO EQUAL '2' */

            if (PROPOSTA.DCLPROPOSTAS.PROPOSTA_SIT_REGISTRO == "2")
            {

                /*" -803- IF MOVIMCOB-NUM-AVISO = 23000 */

                if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 23000)
                {

                    /*" -807- DISPLAY 'Cartao ....... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Proposta Cancelada' */

                    $"Cartao ....... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Proposta Cancelada"
                    .Display();

                    /*" -808- ELSE */
                }
                else
                {


                    /*" -812- DISPLAY 'Deb Outros ... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Proposta Cancelada' */

                    $"Deb Outros ... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Proposta Cancelada"
                    .Display();

                    /*" -813- END-IF */
                }


                /*" -814- ADD 1 TO WS-CT-DESPR */
                AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                /*" -818- GO TO R3200-90-LER-PROXIMO. */

                R3200_90_LER_PROXIMO(); //GOTO
                return;
            }


            /*" -820- IF PROPOSTA-NUM-APOL-ANTERIOR GREATER ZEROS */

            if (PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_APOL_ANTERIOR > 00)
            {

                /*" -821- PERFORM R4000-00-VERIFICA-LIMITE */

                R4000_00_VERIFICA_LIMITE_SECTION();

                /*" -822- IF WCH-LIBERA EQUAL 'N' */

                if (AREA_DE_WORK.WCH_LIBERA == "N")
                {

                    /*" -823- ADD 1 TO WS-CT-LIMITE */
                    AREA_DE_WORK.WS_CT_LIMITE.Value = AREA_DE_WORK.WS_CT_LIMITE + 1;

                    /*" -824- ADD 1 TO WS-CT-DESPR */
                    AREA_DE_WORK.WS_CT_DESPR.Value = AREA_DE_WORK.WS_CT_DESPR + 1;

                    /*" -825- GO TO R3200-90-LER-PROXIMO */

                    R3200_90_LER_PROXIMO(); //GOTO
                    return;

                    /*" -826- END-IF */
                }


                /*" -828- END-IF. */
            }


            /*" -829- PERFORM R3220-00-UPDATE-MOVIMCOB */

            R3220_00_UPDATE_MOVIMCOB_SECTION();

            /*" -831- PERFORM R3230-00-UPDATE-PROPOSTA */

            R3230_00_UPDATE_PROPOSTA_SECTION();

            /*" -833- PERFORM R3240-00-ATUALIZA-PAINEL */

            R3240_00_ATUALIZA_PAINEL_SECTION();

            /*" -834- IF MOVIMCOB-NUM-AVISO = 23000 */

            if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 23000)
            {

                /*" -838- DISPLAY 'Cartao ....... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Conciliado' */

                $"Cartao ....... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Conciliado"
                .Display();

                /*" -839- ELSE */
            }
            else
            {


                /*" -843- DISPLAY 'Deb Outros ... ' PROPOSTA-COD-FONTE ' ' PROPOSTA-NUM-PROPOSTA ' ' AU085-IND-FORMA-PAGTO-AD ' - Conciliado' */

                $"Deb Outros ... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE} {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA} {AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD} - Conciliado"
                .Display();

                /*" -845- END-IF. */
            }


            /*" -846- IF PROPCOBR-TIPO-COBRANCA EQUAL '0' */

            if (PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA == "0")
            {

                /*" -847- ADD 1 TO WS-CTC-BOL */
                AREA_DE_WORK.WS_CTC_BOL.Value = AREA_DE_WORK.WS_CTC_BOL + 1;

                /*" -848- ELSE */
            }
            else
            {


                /*" -849- IF PROPCOBR-TIPO-COBRANCA EQUAL '1' */

                if (PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA == "1")
                {

                    /*" -850- IF MOVIMCOB-NUM-AVISO EQUAL 23000 */

                    if (MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO == 23000)
                    {

                        /*" -851- ADD 1 TO WS-CTC-DEB */
                        AREA_DE_WORK.WS_CTC_DEB.Value = AREA_DE_WORK.WS_CTC_DEB + 1;

                        /*" -852- ELSE */
                    }
                    else
                    {


                        /*" -853- ADD 1 TO WS-CTC-DEBOT */
                        AREA_DE_WORK.WS_CTC_DEBOT.Value = AREA_DE_WORK.WS_CTC_DEBOT + 1;

                        /*" -854- ELSE */
                    }

                }
                else
                {


                    /*" -855- IF PROPCOBR-TIPO-COBRANCA EQUAL '2' */

                    if (PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA == "2")
                    {

                        /*" -856- IF MOVDEBCE-COD-CONVENIO EQUAL 23000 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO == 23000)
                        {

                            /*" -857- ADD 1 TO WS-CTC-ERNET */
                            AREA_DE_WORK.WS_CTC_ERNET.Value = AREA_DE_WORK.WS_CTC_ERNET + 1;

                            /*" -858- ELSE */
                        }
                        else
                        {


                            /*" -858- ADD 1 TO WS-CTC-ORBIT. */
                            AREA_DE_WORK.WS_CTC_ORBIT.Value = AREA_DE_WORK.WS_CTC_ORBIT + 1;
                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R3200_90_LER_PROXIMO */

            R3200_90_LER_PROXIMO();

        }

        [StopWatch]
        /*" R3200-90-LER-PROXIMO */
        private void R3200_90_LER_PROXIMO(bool isPerform = false)
        {
            /*" -862- PERFORM R3110-00-FETCH-MOVIMCOB. */

            R3110_00_FETCH_MOVIMCOB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-SELECT-PROPOSTA-SECTION */
        private void R3210_00_SELECT_PROPOSTA_SECTION()
        {
            /*" -875- MOVE 'R3210' TO WNR-EXEC-SQL. */
            _.Move("R3210", WABEND.WNR_EXEC_SQL);

            /*" -893- PERFORM R3210_00_SELECT_PROPOSTA_DB_SELECT_1 */

            R3210_00_SELECT_PROPOSTA_DB_SELECT_1();

            /*" -896- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -897- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -898- MOVE 'N' TO WTEM-PROPOSTA */
                    _.Move("N", AREA_DE_WORK.WTEM_PROPOSTA);

                    /*" -899- ELSE */
                }
                else
                {


                    /*" -900- DISPLAY 'R3210 - ERRO NO SELECT PROPOSTAS' */
                    _.Display($"R3210 - ERRO NO SELECT PROPOSTAS");

                    /*" -901- DISPLAY 'APOLICE ...... ' MOVIMCOB-NUM-APOLICE */
                    _.Display($"APOLICE ...... {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                    /*" -902- DISPLAY 'ENDOSSO ...... ' MOVIMCOB-NUM-ENDOSSO */
                    _.Display($"ENDOSSO ...... {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                    /*" -903- DISPLAY 'PARCELA ...... ' MOVIMCOB-NUM-PARCELA */
                    _.Display($"PARCELA ...... {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                    /*" -904- DISPLAY 'FONTE ........ ' PROPOSTA-COD-FONTE */
                    _.Display($"FONTE ........ {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE}");

                    /*" -905- DISPLAY 'PROPOSTA ..... ' PROPOSTA-NUM-PROPOSTA */
                    _.Display($"PROPOSTA ..... {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA}");

                    /*" -906- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -907- ELSE */
                }

            }
            else
            {


                /*" -907- MOVE 'S' TO WTEM-PROPOSTA. */
                _.Move("S", AREA_DE_WORK.WTEM_PROPOSTA);
            }


        }

        [StopWatch]
        /*" R3210-00-SELECT-PROPOSTA-DB-SELECT-1 */
        public void R3210_00_SELECT_PROPOSTA_DB_SELECT_1()
        {
            /*" -893- EXEC SQL SELECT A.SIT_REGISTRO , B.TIPO_COBRANCA , C.COD_CONVENIO INTO :PROPOSTA-SIT-REGISTRO , :PROPCOBR-TIPO-COBRANCA , :MOVDEBCE-COD-CONVENIO FROM SEGUROS.PROPOSTAS A , SEGUROS.PROPOSTA_COBRANCA B , SEGUROS.MOVTO_DEBITOCC_CEF C WHERE A.COD_FONTE = :PROPOSTA-COD-FONTE AND A.NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA AND A.COD_FONTE = B.COD_FONTE AND A.NUM_PROPOSTA = B.NUM_PROPOSTA AND B.COD_FONTE = C.NUM_APOLICE AND B.NUM_PROPOSTA = C.NUM_ENDOSSO AND C.STATUS_CARTAO = 'A' END-EXEC. */

            var r3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1 = new R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOSTA_NUM_PROPOSTA = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA.ToString(),
                PROPOSTA_COD_FONTE = PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE.ToString(),
            };

            var executed_1 = R3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1.Execute(r3210_00_SELECT_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOSTA_SIT_REGISTRO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_SIT_REGISTRO);
                _.Move(executed_1.PROPCOBR_TIPO_COBRANCA, PROPCOBR.DCLPROPOSTA_COBRANCA.PROPCOBR_TIPO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3215-00-SELECT-AU085-SECTION */
        private void R3215_00_SELECT_AU085_SECTION()
        {
            /*" -920- MOVE 'R3215' TO WNR-EXEC-SQL. */
            _.Move("R3215", WABEND.WNR_EXEC_SQL);

            /*" -926- PERFORM R3215_00_SELECT_AU085_DB_SELECT_1 */

            R3215_00_SELECT_AU085_DB_SELECT_1();

            /*" -929- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -930- DISPLAY 'R3215 - ERRO NO SELECT AU085' */
                _.Display($"R3215 - ERRO NO SELECT AU085");

                /*" -931- DISPLAY 'APOLICE ...... ' MOVIMCOB-NUM-APOLICE */
                _.Display($"APOLICE ...... {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -932- DISPLAY 'ENDOSSO ...... ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"ENDOSSO ...... {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -933- DISPLAY 'PARCELA ...... ' MOVIMCOB-NUM-PARCELA */
                _.Display($"PARCELA ...... {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -934- DISPLAY 'FONTE ........ ' AU085-COD-FONTE */
                _.Display($"FONTE ........ {AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_FONTE}");

                /*" -935- DISPLAY 'PROPOSTA ..... ' AU085-NUM-PROPOSTA */
                _.Display($"PROPOSTA ..... {AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_PROPOSTA}");

                /*" -935- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3215-00-SELECT-AU085-DB-SELECT-1 */
        public void R3215_00_SELECT_AU085_DB_SELECT_1()
        {
            /*" -926- EXEC SQL SELECT IND_FORMA_PAGTO_AD INTO :AU085-IND-FORMA-PAGTO-AD FROM SEGUROS.AU_PROPOSTA_COMPL WHERE COD_FONTE = :AU085-COD-FONTE AND NUM_PROPOSTA = :AU085-NUM-PROPOSTA END-EXEC. */

            var r3215_00_SELECT_AU085_DB_SELECT_1_Query1 = new R3215_00_SELECT_AU085_DB_SELECT_1_Query1()
            {
                AU085_NUM_PROPOSTA = AU085.DCLAU_PROPOSTA_COMPL.AU085_NUM_PROPOSTA.ToString(),
                AU085_COD_FONTE = AU085.DCLAU_PROPOSTA_COMPL.AU085_COD_FONTE.ToString(),
            };

            var executed_1 = R3215_00_SELECT_AU085_DB_SELECT_1_Query1.Execute(r3215_00_SELECT_AU085_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU085_IND_FORMA_PAGTO_AD, AU085.DCLAU_PROPOSTA_COMPL.AU085_IND_FORMA_PAGTO_AD);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_99_SAIDA*/

        [StopWatch]
        /*" R3220-00-UPDATE-MOVIMCOB-SECTION */
        private void R3220_00_UPDATE_MOVIMCOB_SECTION()
        {
            /*" -948- MOVE 'R3220' TO WNR-EXEC-SQL. */
            _.Move("R3220", WABEND.WNR_EXEC_SQL);

            /*" -958- PERFORM R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1 */

            R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1();

            /*" -961- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -962- DISPLAY 'R3220 - ERRO NO UPDATE MOVIMCOB' */
                _.Display($"R3220 - ERRO NO UPDATE MOVIMCOB");

                /*" -963- DISPLAY 'APOLICE  - ' MOVIMCOB-NUM-APOLICE */
                _.Display($"APOLICE  - {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE}");

                /*" -964- DISPLAY 'ENDOSSO  - ' MOVIMCOB-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO}");

                /*" -965- DISPLAY 'PARCELA  - ' MOVIMCOB-NUM-PARCELA */
                _.Display($"PARCELA  - {MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA}");

                /*" -965- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3220-00-UPDATE-MOVIMCOB-DB-UPDATE-1 */
        public void R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1()
        {
            /*" -958- EXEC SQL UPDATE SEGUROS.MOVIMENTO_COBRANCA SET SIT_REGISTRO = '0' WHERE NUM_APOLICE = :MOVIMCOB-NUM-APOLICE AND NUM_ENDOSSO = :MOVIMCOB-NUM-ENDOSSO AND NUM_PARCELA = :MOVIMCOB-NUM-PARCELA AND SIT_REGISTRO = ' ' AND TIPO_MOVIMENTO = 'Y' AND NUM_AVISO = :MOVIMCOB-NUM-AVISO END-EXEC. */

            var r3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1 = new R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1()
            {
                MOVIMCOB_NUM_APOLICE = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_APOLICE.ToString(),
                MOVIMCOB_NUM_ENDOSSO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_ENDOSSO.ToString(),
                MOVIMCOB_NUM_PARCELA = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_PARCELA.ToString(),
                MOVIMCOB_NUM_AVISO = MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_NUM_AVISO.ToString(),
            };

            R3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1.Execute(r3220_00_UPDATE_MOVIMCOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_99_SAIDA*/

        [StopWatch]
        /*" R3230-00-UPDATE-PROPOSTA-SECTION */
        private void R3230_00_UPDATE_PROPOSTA_SECTION()
        {
            /*" -978- MOVE 'R3230' TO WNR-EXEC-SQL. */
            _.Move("R3230", WABEND.WNR_EXEC_SQL);

            /*" -984- PERFORM R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1 */

            R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1();

            /*" -987- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -988- DISPLAY 'R3230 - ERRO NO UPDATE PROPOSTAS' */
                _.Display($"R3230 - ERRO NO UPDATE PROPOSTAS");

                /*" -989- DISPLAY 'FONTE    - ' PROPOSTA-COD-FONTE */
                _.Display($"FONTE    - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE}");

                /*" -990- DISPLAY 'PROPOSTA - ' PROPOSTA-NUM-PROPOSTA */
                _.Display($"PROPOSTA - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA}");

                /*" -991- DISPLAY 'SITUACAO - ' PROPOSTA-SIT-REGISTRO */
                _.Display($"SITUACAO - {PROPOSTA.DCLPROPOSTAS.PROPOSTA_SIT_REGISTRO}");

                /*" -993- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -993- ADD 1 TO WS-CTC-BOL. */
            AREA_DE_WORK.WS_CTC_BOL.Value = AREA_DE_WORK.WS_CTC_BOL + 1;

        }

        [StopWatch]
        /*" R3230-00-UPDATE-PROPOSTA-DB-UPDATE-1 */
        public void R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1()
        {
            /*" -984- EXEC SQL UPDATE SEGUROS.PROPOSTAS SET SIT_REGISTRO = '0' WHERE COD_FONTE = :PROPOSTA-COD-FONTE AND NUM_PROPOSTA = :PROPOSTA-NUM-PROPOSTA AND SIT_REGISTRO = ' ' END-EXEC. */

            var r3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1 = new R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1()
            {
                PROPOSTA_NUM_PROPOSTA = PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA.ToString(),
                PROPOSTA_COD_FONTE = PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE.ToString(),
            };

            R3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1.Execute(r3230_00_UPDATE_PROPOSTA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_99_SAIDA*/

        [StopWatch]
        /*" R3240-00-ATUALIZA-PAINEL-SECTION */
        private void R3240_00_ATUALIZA_PAINEL_SECTION()
        {
            /*" -1006- MOVE 'R3240' TO WNR-EXEC-SQL. */
            _.Move("R3240", WABEND.WNR_EXEC_SQL);

            /*" -1008- MOVE PROPOSTA-COD-FONTE TO WHOST-COD-FONTE */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE, WHOST_COD_FONTE);

            /*" -1010- MOVE PROPOSTA-NUM-PROPOSTA TO WHOST-NUM-PROPOSTA */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA, WHOST_NUM_PROPOSTA);

            /*" -1012- PERFORM R3241-00-SELECT-PROPOAUT */

            R3241_00_SELECT_PROPOAUT_SECTION();

            /*" -1014- MOVE PROPOAUT-NUM-PROPOSTA-CONV TO WHOST-PROPOSTA-VC */
            _.Move(PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV, WHOST_PROPOSTA_VC);

            /*" -1017- MOVE MOVIMCOB-VAL-CREDITO TO WHOST-VLR-PARCELA. */
            _.Move(MOVIMCOB.DCLMOVIMENTO_COBRANCA.MOVIMCOB_VAL_CREDITO, WHOST_VLR_PARCELA);

            /*" -1017- PERFORM R5000-00-ATUALIZA-HISTORICO. */

            R5000_00_ATUALIZA_HISTORICO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3240_99_SAIDA*/

        [StopWatch]
        /*" R3241-00-SELECT-PROPOAUT-SECTION */
        private void R3241_00_SELECT_PROPOAUT_SECTION()
        {
            /*" -1030- MOVE 'R3241' TO WNR-EXEC-SQL. */
            _.Move("R3241", WABEND.WNR_EXEC_SQL);

            /*" -1031- MOVE WHOST-COD-FONTE TO PROPOAUT-COD-FONTE */
            _.Move(WHOST_COD_FONTE, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_COD_FONTE);

            /*" -1034- MOVE WHOST-NUM-PROPOSTA TO PROPOAUT-NUM-PROPOSTA. */
            _.Move(WHOST_NUM_PROPOSTA, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA);

            /*" -1040- PERFORM R3241_00_SELECT_PROPOAUT_DB_SELECT_1 */

            R3241_00_SELECT_PROPOAUT_DB_SELECT_1();

            /*" -1043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1044- DISPLAY 'R3241 - ERRO NO SELECT PROPOAUT' */
                _.Display($"R3241 - ERRO NO SELECT PROPOAUT");

                /*" -1045- DISPLAY 'FONTE    - ' PROPOAUT-COD-FONTE */
                _.Display($"FONTE    - {PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_COD_FONTE}");

                /*" -1046- DISPLAY 'COBRANCA - ' PROPOAUT-NUM-PROPOSTA */
                _.Display($"COBRANCA - {PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA}");

                /*" -1046- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3241-00-SELECT-PROPOAUT-DB-SELECT-1 */
        public void R3241_00_SELECT_PROPOAUT_DB_SELECT_1()
        {
            /*" -1040- EXEC SQL SELECT NUM_PROPOSTA_CONV INTO :PROPOAUT-NUM-PROPOSTA-CONV FROM SEGUROS.PROPOSTA_AUTO WHERE COD_FONTE = :PROPOAUT-COD-FONTE AND NUM_PROPOSTA = :PROPOAUT-NUM-PROPOSTA END-EXEC. */

            var r3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1 = new R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1()
            {
                PROPOAUT_NUM_PROPOSTA = PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA.ToString(),
                PROPOAUT_COD_FONTE = PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_COD_FONTE.ToString(),
            };

            var executed_1 = R3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1.Execute(r3241_00_SELECT_PROPOAUT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOAUT_NUM_PROPOSTA_CONV, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3241_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-VERIFICA-LIMITE-SECTION */
        private void R4000_00_VERIFICA_LIMITE_SECTION()
        {
            /*" -1059- MOVE 'R4000' TO WNR-EXEC-SQL. */
            _.Move("R4000", WABEND.WNR_EXEC_SQL);

            /*" -1061- MOVE SISTEMAS-DATA-MOV-ABERTO TO LPARM01. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.LPARM.LPARM01);

            /*" -1064- MOVE PROPOSTA-DATA-INIVIGENCIA TO LPARM02. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA, AREA_DE_WORK.LPARM.LPARM02);

            /*" -1065- MOVE ZEROS TO LPARM03. */
            _.Move(0, AREA_DE_WORK.LPARM.LPARM03);

            /*" -1066- MOVE ZEROS TO IND-RETORNO. */
            _.Move(0, AREA_DE_WORK.LPARM.IND_RETORNO);

            /*" -1068- MOVE SPACES TO MENSAGEM. */
            _.Move("", AREA_DE_WORK.LPARM.MENSAGEM);

            /*" -1069- CALL 'PRODIFD2' USING LPARM. */
            _.Call("PRODIFD2", AREA_DE_WORK.LPARM);

            /*" -1071- IF IND-RETORNO EQUAL 9 OR MENSAGEM NOT = ' ' */

            if (AREA_DE_WORK.LPARM.IND_RETORNO == 9 || AREA_DE_WORK.LPARM.MENSAGEM != " ")
            {

                /*" -1072- DISPLAY 'ERRO CHAMADA A SUBROTINA PRODIFD2' */
                _.Display($"ERRO CHAMADA A SUBROTINA PRODIFD2");

                /*" -1073- DISPLAY 'CODIGO DE RETORNO' IND-RETORNO */
                _.Display($"CODIGO DE RETORNO{AREA_DE_WORK.LPARM.IND_RETORNO}");

                /*" -1074- DISPLAY 'LPRAM01 ... ' LPARM01 */
                _.Display($"LPRAM01 ... {AREA_DE_WORK.LPARM.LPARM01}");

                /*" -1075- DISPLAY 'LPRAM02 ... ' LPARM02 */
                _.Display($"LPRAM02 ... {AREA_DE_WORK.LPARM.LPARM02}");

                /*" -1077- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1081- MOVE LPARM03 TO WS-QTD-DIAS. */
            _.Move(AREA_DE_WORK.LPARM.LPARM03, AREA_DE_WORK.WS_QTD_DIAS);

            /*" -1082- IF WS-QTD-DIAS > 10 */

            if (AREA_DE_WORK.WS_QTD_DIAS > 10)
            {

                /*" -1083- MOVE 'N' TO WCH-LIBERA */
                _.Move("N", AREA_DE_WORK.WCH_LIBERA);

                /*" -1084- ELSE */
            }
            else
            {


                /*" -1085- MOVE 'S' TO WCH-LIBERA */
                _.Move("S", AREA_DE_WORK.WCH_LIBERA);

                /*" -1085- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-ATUALIZA-HISTORICO-SECTION */
        private void R5000_00_ATUALIZA_HISTORICO_SECTION()
        {
            /*" -1098- MOVE 'R5000' TO WNR-EXEC-SQL. */
            _.Move("R5000", WABEND.WNR_EXEC_SQL);

            /*" -1099- MOVE 'CON' TO WHOST-TIPO-OPERACAO */
            _.Move("CON", WHOST_TIPO_OPERACAO);

            /*" -1101- MOVE ZEROS TO WHOST-OCORR-HISTORICO */
            _.Move(0, WHOST_OCORR_HISTORICO);

            /*" -1102- MOVE 200 TO WHOST-COD-OPERACAO */
            _.Move(200, WHOST_COD_OPERACAO);

            /*" -1105- MOVE SPACES TO WHOST-DATA-REFERENCIA */
            _.Move("", WHOST_DATA_REFERENCIA);

            /*" -1106- MOVE SPACES TO WTEM-AU055 */
            _.Move("", AREA_DE_WORK.WTEM_AU055);

            /*" -1107- PERFORM R5030-00-SELECT-AU055 */

            R5030_00_SELECT_AU055_SECTION();

            /*" -1108- IF WTEM-AU055 EQUAL 'NAO' */

            if (AREA_DE_WORK.WTEM_AU055 == "NAO")
            {

                /*" -1109- PERFORM R5040-00-INSERT-AU055 */

                R5040_00_INSERT_AU055_SECTION();

                /*" -1110- ELSE */
            }
            else
            {


                /*" -1112- PERFORM R5045-00-UPDATE-AU055. */

                R5045_00_UPDATE_AU055_SECTION();
            }


            /*" -1112- PERFORM R5050-00-UPDATE-AU057. */

            R5050_00_UPDATE_AU057_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R5030-00-SELECT-AU055-SECTION */
        private void R5030_00_SELECT_AU055_SECTION()
        {
            /*" -1127- MOVE 'R5030-00' TO WNR-EXEC-SQL. */
            _.Move("R5030-00", WABEND.WNR_EXEC_SQL);

            /*" -1137- PERFORM R5030_00_SELECT_AU055_DB_SELECT_1 */

            R5030_00_SELECT_AU055_DB_SELECT_1();

            /*" -1140- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1141- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1142- MOVE 'NAO' TO WTEM-AU055 */
                    _.Move("NAO", AREA_DE_WORK.WTEM_AU055);

                    /*" -1143- ELSE */
                }
                else
                {


                    /*" -1145- DISPLAY 'R5030-00 - PROBLEMAS SELECT AU_HIS_PROP_CONV' ' ' WHOST-PROPOSTA-VC */

                    $"R5030-00 - PROBLEMAS SELECT AU_HIS_PROP_CONV {WHOST_PROPOSTA_VC}"
                    .Display();

                    /*" -1145- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R5030-00-SELECT-AU055-DB-SELECT-1 */
        public void R5030_00_SELECT_AU055_DB_SELECT_1()
        {
            /*" -1137- EXEC SQL SELECT DTH_OPERACAO , NUM_ARQUIVO INTO :AU055-DTH-OPERACAO , :AU055-NUM-ARQUIVO FROM SEGUROS.AU_HIS_PROP_CONV WHERE NUM_PROPOSTA_VC = :WHOST-PROPOSTA-VC AND DTH_OPERACAO = :SISTEMAS-DATA-MOV-ABERTO AND IND_OPERACAO = 'CON' AND COD_CONGENERE = :WHOST-CONGENERE END-EXEC. */

            var r5030_00_SELECT_AU055_DB_SELECT_1_Query1 = new R5030_00_SELECT_AU055_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_PROPOSTA_VC = WHOST_PROPOSTA_VC.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            var executed_1 = R5030_00_SELECT_AU055_DB_SELECT_1_Query1.Execute(r5030_00_SELECT_AU055_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU055_DTH_OPERACAO, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO);
                _.Move(executed_1.AU055_NUM_ARQUIVO, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5030_99_SAIDA*/

        [StopWatch]
        /*" R5040-00-INSERT-AU055-SECTION */
        private void R5040_00_INSERT_AU055_SECTION()
        {
            /*" -1158- MOVE 'R5040' TO WNR-EXEC-SQL. */
            _.Move("R5040", WABEND.WNR_EXEC_SQL);

            /*" -1164- PERFORM R5040_00_INSERT_AU055_DB_SELECT_1 */

            R5040_00_INSERT_AU055_DB_SELECT_1();

            /*" -1167- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1170- DISPLAY 'R5040-00 - PROBLEMAS SELECT AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' ' WHOST-CONGENERE */

                $"R5040-00 - PROBLEMAS SELECT AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC} {WHOST_CONGENERE}"
                .Display();

                /*" -1172- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1173- MOVE WHOST-PROPOSTA-VC TO AU055-NUM-PROPOSTA-VC */
            _.Move(WHOST_PROPOSTA_VC, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC);

            /*" -1174- ADD 1 TO AU055-SEQ-HISTORICO */
            AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO.Value = AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO + 1;

            /*" -1175- MOVE 'AU2055B' TO AU055-NOM-PROGRAMA */
            _.Move("AU2055B", AU055.DCLAU_HIS_PROP_CONV.AU055_NOM_PROGRAMA);

            /*" -1177- MOVE SISTEMAS-DATA-MOV-ABERTO TO AU055-DTH-OPERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO);

            /*" -1178- MOVE 'CON' TO AU055-IND-OPERACAO */
            _.Move("CON", AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO);

            /*" -1180- MOVE SISTEMAS-DATA-MOV-ABERTO TO AU055-DTH-MOVTO-ARQUIVO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_MOVTO_ARQUIVO);

            /*" -1181- MOVE ZEROS TO AU055-NUM-ARQUIVO */
            _.Move(0, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO);

            /*" -1183- MOVE 'N' TO AU055-STA-ERRO. */
            _.Move("N", AU055.DCLAU_HIS_PROP_CONV.AU055_STA_ERRO);

            /*" -1205- PERFORM R5040_00_INSERT_AU055_DB_INSERT_1 */

            R5040_00_INSERT_AU055_DB_INSERT_1();

            /*" -1208- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1212- DISPLAY 'R5040 - PROBLEMAS INSERT AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' ' AU055-SEQ-HISTORICO ' ' WHOST-CONGENERE */

                $"R5040 - PROBLEMAS INSERT AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC} {AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO} {WHOST_CONGENERE}"
                .Display();

                /*" -1212- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5040-00-INSERT-AU055-DB-SELECT-1 */
        public void R5040_00_INSERT_AU055_DB_SELECT_1()
        {
            /*" -1164- EXEC SQL SELECT VALUE(MAX(SEQ_HISTORICO),0) INTO :AU055-SEQ-HISTORICO FROM SEGUROS.AU_HIS_PROP_CONV WHERE NUM_PROPOSTA_VC = :WHOST-PROPOSTA-VC AND COD_CONGENERE = :WHOST-CONGENERE END-EXEC. */

            var r5040_00_INSERT_AU055_DB_SELECT_1_Query1 = new R5040_00_INSERT_AU055_DB_SELECT_1_Query1()
            {
                WHOST_PROPOSTA_VC = WHOST_PROPOSTA_VC.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            var executed_1 = R5040_00_INSERT_AU055_DB_SELECT_1_Query1.Execute(r5040_00_INSERT_AU055_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AU055_SEQ_HISTORICO, AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO);
            }


        }

        [StopWatch]
        /*" R5040-00-INSERT-AU055-DB-INSERT-1 */
        public void R5040_00_INSERT_AU055_DB_INSERT_1()
        {
            /*" -1205- EXEC SQL INSERT INTO SEGUROS.AU_HIS_PROP_CONV ( NUM_PROPOSTA_VC , SEQ_HISTORICO , NOM_PROGRAMA , DTH_OPERACAO , IND_OPERACAO , DTH_MOVTO_ARQUIVO , NUM_ARQUIVO , STA_ERRO , DTH_CADASTRAMENTO , COD_CONGENERE) VALUES (:AU055-NUM-PROPOSTA-VC , :AU055-SEQ-HISTORICO , :AU055-NOM-PROGRAMA , :AU055-DTH-OPERACAO , :AU055-IND-OPERACAO , :AU055-DTH-MOVTO-ARQUIVO, :AU055-NUM-ARQUIVO , :AU055-STA-ERRO , CURRENT TIMESTAMP , :WHOST-CONGENERE) END-EXEC. */

            var r5040_00_INSERT_AU055_DB_INSERT_1_Insert1 = new R5040_00_INSERT_AU055_DB_INSERT_1_Insert1()
            {
                AU055_NUM_PROPOSTA_VC = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC.ToString(),
                AU055_SEQ_HISTORICO = AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO.ToString(),
                AU055_NOM_PROGRAMA = AU055.DCLAU_HIS_PROP_CONV.AU055_NOM_PROGRAMA.ToString(),
                AU055_DTH_OPERACAO = AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO.ToString(),
                AU055_IND_OPERACAO = AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO.ToString(),
                AU055_DTH_MOVTO_ARQUIVO = AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_MOVTO_ARQUIVO.ToString(),
                AU055_NUM_ARQUIVO = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_ARQUIVO.ToString(),
                AU055_STA_ERRO = AU055.DCLAU_HIS_PROP_CONV.AU055_STA_ERRO.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            R5040_00_INSERT_AU055_DB_INSERT_1_Insert1.Execute(r5040_00_INSERT_AU055_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5040_99_SAIDA*/

        [StopWatch]
        /*" R5045-00-UPDATE-AU055-SECTION */
        private void R5045_00_UPDATE_AU055_SECTION()
        {
            /*" -1225- MOVE 'R5045' TO WNR-EXEC-SQL. */
            _.Move("R5045", WABEND.WNR_EXEC_SQL);

            /*" -1226- MOVE WHOST-PROPOSTA-VC TO AU055-NUM-PROPOSTA-VC */
            _.Move(WHOST_PROPOSTA_VC, AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC);

            /*" -1227- MOVE 'AU2055B' TO AU055-NOM-PROGRAMA */
            _.Move("AU2055B", AU055.DCLAU_HIS_PROP_CONV.AU055_NOM_PROGRAMA);

            /*" -1228- MOVE SISTEMAS-DATA-MOV-ABERTO TO AU055-DTH-OPERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO);

            /*" -1230- MOVE 'CON' TO AU055-IND-OPERACAO */
            _.Move("CON", AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO);

            /*" -1238- PERFORM R5045_00_UPDATE_AU055_DB_UPDATE_1 */

            R5045_00_UPDATE_AU055_DB_UPDATE_1();

            /*" -1241- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1244- DISPLAY 'R5045 - PROBLEMAS UPDATE AU_HIS_PROP_CONV' ' ' AU055-NUM-PROPOSTA-VC ' ' AU055-SEQ-HISTORICO */

                $"R5045 - PROBLEMAS UPDATE AU_HIS_PROP_CONV {AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC} {AU055.DCLAU_HIS_PROP_CONV.AU055_SEQ_HISTORICO}"
                .Display();

                /*" -1244- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5045-00-UPDATE-AU055-DB-UPDATE-1 */
        public void R5045_00_UPDATE_AU055_DB_UPDATE_1()
        {
            /*" -1238- EXEC SQL UPDATE SEGUROS.AU_HIS_PROP_CONV SET IND_OPERACAO = :AU055-IND-OPERACAO , NOM_PROGRAMA = :AU055-NOM-PROGRAMA , DTH_CADASTRAMENTO = CURRENT TIMESTAMP WHERE NUM_PROPOSTA_VC = :AU055-NUM-PROPOSTA-VC AND DTH_OPERACAO = :AU055-DTH-OPERACAO AND COD_CONGENERE = :WHOST-CONGENERE END-EXEC. */

            var r5045_00_UPDATE_AU055_DB_UPDATE_1_Update1 = new R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1()
            {
                AU055_IND_OPERACAO = AU055.DCLAU_HIS_PROP_CONV.AU055_IND_OPERACAO.ToString(),
                AU055_NOM_PROGRAMA = AU055.DCLAU_HIS_PROP_CONV.AU055_NOM_PROGRAMA.ToString(),
                AU055_NUM_PROPOSTA_VC = AU055.DCLAU_HIS_PROP_CONV.AU055_NUM_PROPOSTA_VC.ToString(),
                AU055_DTH_OPERACAO = AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            R5045_00_UPDATE_AU055_DB_UPDATE_1_Update1.Execute(r5045_00_UPDATE_AU055_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5045_99_SAIDA*/

        [StopWatch]
        /*" R5050-00-UPDATE-AU057-SECTION */
        private void R5050_00_UPDATE_AU057_SECTION()
        {
            /*" -1257- MOVE 'R5050' TO WNR-EXEC-SQL. */
            _.Move("R5050", WABEND.WNR_EXEC_SQL);

            /*" -1258- MOVE WHOST-COD-FONTE TO AU057-COD-FONTE */
            _.Move(WHOST_COD_FONTE, AU057.DCLAU_PROP_CONV_VC.AU057_COD_FONTE);

            /*" -1259- MOVE WHOST-NUM-PROPOSTA TO AU057-NUM-PROPOSTA */
            _.Move(WHOST_NUM_PROPOSTA, AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA);

            /*" -1261- MOVE 'CON' TO AU057-IND-OPERACAO. */
            _.Move("CON", AU057.DCLAU_PROP_CONV_VC.AU057_IND_OPERACAO);

            /*" -1268- PERFORM R5050_00_UPDATE_AU057_DB_UPDATE_1 */

            R5050_00_UPDATE_AU057_DB_UPDATE_1();

            /*" -1271- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1274- DISPLAY 'R5050 - PROBLEMAS UPDATE AU_PROP_CONV_VC' ' ' WHOST-PROPOSTA-VC ' ' WHOST-CONGENERE */

                $"R5050 - PROBLEMAS UPDATE AU_PROP_CONV_VC {WHOST_PROPOSTA_VC} {WHOST_CONGENERE}"
                .Display();

                /*" -1274- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R5050-00-UPDATE-AU057-DB-UPDATE-1 */
        public void R5050_00_UPDATE_AU057_DB_UPDATE_1()
        {
            /*" -1268- EXEC SQL UPDATE SEGUROS.AU_PROP_CONV_VC SET COD_FONTE = :AU057-COD-FONTE , NUM_PROPOSTA = :AU057-NUM-PROPOSTA , IND_OPERACAO = :AU057-IND-OPERACAO WHERE NUM_PROPOSTA_VC = :WHOST-PROPOSTA-VC AND COD_CONGENERE = :WHOST-CONGENERE END-EXEC. */

            var r5050_00_UPDATE_AU057_DB_UPDATE_1_Update1 = new R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1()
            {
                AU057_NUM_PROPOSTA = AU057.DCLAU_PROP_CONV_VC.AU057_NUM_PROPOSTA.ToString(),
                AU057_IND_OPERACAO = AU057.DCLAU_PROP_CONV_VC.AU057_IND_OPERACAO.ToString(),
                AU057_COD_FONTE = AU057.DCLAU_PROP_CONV_VC.AU057_COD_FONTE.ToString(),
                WHOST_PROPOSTA_VC = WHOST_PROPOSTA_VC.ToString(),
                WHOST_CONGENERE = WHOST_CONGENERE.ToString(),
            };

            R5050_00_UPDATE_AU057_DB_UPDATE_1_Update1.Execute(r5050_00_UPDATE_AU057_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5050_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1288- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1290- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WSQLERRO.WSQLERRMC);

            /*" -1291- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1293- DISPLAY WSQLERRO. */
            _.Display(WSQLERRO);

            /*" -1293- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1297- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1297- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}