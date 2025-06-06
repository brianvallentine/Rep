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
using Sias.Cobranca.DB2.CB0112B;

namespace Code
{
    public class CB0112B
    {
        public bool IsCall { get; set; }

        public CB0112B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA (CARTAO DE CREDITO)       *      */
        /*"      *   PROGRAMA ...............  CB0112B (CONV. 9022 - CIELO PARCIAL*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PROGRAMADOR ............  ELIERMES OLIVEIRA                  *      */
        /*"      *   SOLICITACAO ............  D496862 - ChargeBack Cart�o CIELO  *      */
        /*"      *   DATA CODIFICACAO .......  27/12/2023                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  - GERA ARQUIVO DE ENVIO PARA       *      */
        /*"      *                               ESTORNOS MANUAIS VIA CARTAO DE   *      */
        /*"      *                               CREDITO APARTIR DA LEITURA DA    *      */
        /*"      *                               MOVTO_DEBITOCC_CEF (CONV. 9022)  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                        ALTERACOES                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO XX  - DEMANDA XXX.XXX                                 *      */
        /*"      *              - XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                                                                *      */
        /*"      *   EM XX/XX/XXXX - XXXXXXXXXXXXXXXXXXXXXX                       *      */
        /*"      *                                       PROCURE POR V.XX         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "120", "X(120)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOV_REGISTRO, _MOVIMENTO); VarBasis.RedefinePassValue(MOV_REGISTRO, _MOVIMENTO, MOV_REGISTRO); return _MOVIMENTO;
            }
        }
        public FileBasis _RCB0112B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RCB0112B
        {
            get
            {
                _.Move(REG_CB0112B, _RCB0112B); VarBasis.RedefinePassValue(REG_CB0112B, _RCB0112B, REG_CB0112B); return _RCB0112B;
            }
        }
        /*"01        MOV-REGISTRO            PIC  X(120).*/
        public StringBasis MOV_REGISTRO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
        /*"01        REG-CB0112B             PIC  X(132).*/
        public StringBasis REG_CB0112B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WSHOST-DATA-PARAMETRO     PIC  X(010).*/
        public StringBasis WSHOST_DATA_PARAMETRO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    VIND-OPERACAO             PIC S9(004)     COMP.*/
        public IntBasis VIND_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-TRANSACAO            PIC S9(004)     COMP.*/
        public IntBasis VIND_TRANSACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NUM-CARTAO           PIC S9(004)     COMP.*/
        public IntBasis VIND_NUM_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NSAS                 PIC S9(004)     COMP.*/
        public IntBasis VIND_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-NSL                  PIC S9(004)     COMP.*/
        public IntBasis VIND_NSL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    VIND-AGENCIA              PIC S9(004)     COMP.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01           AREA-DE-WORK.*/
        public CB0112B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CB0112B_AREA_DE_WORK();
        public class CB0112B_AREA_DE_WORK : VarBasis
        {
            /*"  03         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-MOVDEBCE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         DP-MOVDEBCE       PIC  9(007)    VALUE ZEROS.*/
            public IntBasis DP_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-HISLANCTA      PIC  9(007)    VALUE ZEROS.*/
            public IntBasis UP_HISLANCTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         UP-MOVTODEBCC     PIC  9(007)    VALUE ZEROS.*/
            public IntBasis UP_MOVTODEBCC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         AC-QTD-TOTAL      PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_QTD_TOTAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         AC-VLR-TOTAL      PIC  9(015)V99 VALUE ZEROS.*/
            public DoubleBasis AC_VLR_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99"), 2);
            /*"  03         AUX-TRANSACAO     PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AUX_TRANSACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         WS-NSL            PIC S9(009)    VALUE ZEROS COMP.*/
            public IntBasis WS_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03         AUX-NSAS          PIC  9(004)    VALUE ZEROS.*/
            public IntBasis AUX_NSAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  03         AUX-SEQUENCIA     PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AUX_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_CB0112B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CB0112B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CB0112B_FILLER_0(); _.Move(WDATA_REL, _filler_0); VarBasis.RedefinePassValue(WDATA_REL, _filler_0, WDATA_REL); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_REL); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0112B_FILLER_0 : VarBasis
            {
                /*"    10       WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WHORA-CURR.*/

                public _REDEF_CB0112B_FILLER_0()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0112B_WHORA_CURR WHORA_CURR { get; set; } = new CB0112B_WHORA_CURR();
            public class CB0112B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-CC-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WDATA-CABEC.*/
            }
            public CB0112B_WDATA_CABEC WDATA_CABEC { get; set; } = new CB0112B_WDATA_CABEC();
            public class CB0112B_WDATA_CABEC : VarBasis
            {
                /*"    10       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WHORA-CABEC.*/
            }
            public CB0112B_WHORA_CABEC WHORA_CABEC { get; set; } = new CB0112B_WHORA_CABEC();
            public class CB0112B_WHORA_CABEC : VarBasis
            {
                /*"    10       WHORA-HH-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10       WHORA-SS-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WDATA-HOST        PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_HOST { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-HOST.*/
            private _REDEF_CB0112B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_CB0112B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_CB0112B_FILLER_7(); _.Move(WDATA_HOST, _filler_7); VarBasis.RedefinePassValue(WDATA_HOST, _filler_7, WDATA_HOST); _filler_7.ValueChanged += () => { _.Move(_filler_7, WDATA_HOST); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WDATA_HOST); }
            }  //Redefines
            public class _REDEF_CB0112B_FILLER_7 : VarBasis
            {
                /*"    10       WDATA-AA-HOST     PIC  9(004).*/
                public IntBasis WDATA_AA_HOST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-MM-HOST     PIC  9(002).*/
                public IntBasis WDATA_MM_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-DD-HOST     PIC  9(002).*/
                public IntBasis WDATA_DD_HOST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03 W04DTSQL.*/

                public _REDEF_CB0112B_FILLER_7()
                {
                    WDATA_AA_HOST.ValueChanged += OnValueChanged;
                    FILLER_8.ValueChanged += OnValueChanged;
                    WDATA_MM_HOST.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDATA_DD_HOST.ValueChanged += OnValueChanged;
                }

            }
            public CB0112B_W04DTSQL W04DTSQL { get; set; } = new CB0112B_W04DTSQL();
            public class CB0112B_W04DTSQL : VarBasis
            {
                /*"    10  W04AASQL                PIC  9(004).*/
                public IntBasis W04AASQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10  W04T1SQL                PIC  X(001).*/
                public StringBasis W04T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  W04MMSQL                PIC  9(002).*/
                public IntBasis W04MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10  W04T2SQL                PIC  X(001).*/
                public StringBasis W04T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10  W04DDSQL                PIC  9(002).*/
                public IntBasis W04DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03 PARM-PROSOMU1.*/
            }
            public CB0112B_PARM_PROSOMU1 PARM_PROSOMU1 { get; set; } = new CB0112B_PARM_PROSOMU1();
            public class CB0112B_PARM_PROSOMU1 : VarBasis
            {
                /*"    10 SU1-DATA1.*/
                public CB0112B_SU1_DATA1 SU1_DATA1 { get; set; } = new CB0112B_SU1_DATA1();
                public class CB0112B_SU1_DATA1 : VarBasis
                {
                    /*"       15 SU1-DD1               PIC  99.*/
                    public IntBasis SU1_DD1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"       15 SU1-MM1               PIC  99.*/
                    public IntBasis SU1_MM1 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"       15 SU1-AA1               PIC  9999.*/
                    public IntBasis SU1_AA1 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"    10 SU1-NRDIAS               PIC S9(005) COMP-3.*/
                }
                public IntBasis SU1_NRDIAS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    10 SU1-DATA2.*/
                public CB0112B_SU1_DATA2 SU1_DATA2 { get; set; } = new CB0112B_SU1_DATA2();
                public class CB0112B_SU1_DATA2 : VarBasis
                {
                    /*"       15 SU1-DD2               PIC  99.*/
                    public IntBasis SU1_DD2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"       15 SU1-MM2               PIC  99.*/
                    public IntBasis SU1_MM2 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"       15 SU1-AA2               PIC  9999.*/
                    public IntBasis SU1_AA2 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                    /*"01            AUX-RELATORIO.*/
                }
            }
        }
        public CB0112B_AUX_RELATORIO AUX_RELATORIO { get; set; } = new CB0112B_AUX_RELATORIO();
        public class CB0112B_AUX_RELATORIO : VarBasis
        {
            /*"  03          LC01.*/
            public CB0112B_LC01 LC01 { get; set; } = new CB0112B_LC01();
            public class CB0112B_LC01 : VarBasis
            {
                /*"    10        FILLER              PIC  X(007)  VALUE             'CB0112B'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CB0112B");
                /*"    10        FILLER              PIC  X(033)  VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
                /*"    10        LC01-DESCRICAO      PIC  X(040)  VALUE             'RELATORIO DE INCONSISTENCIAS'.*/
                public StringBasis LC01_DESCRICAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"RELATORIO DE INCONSISTENCIAS");
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
            public CB0112B_LC02 LC02 { get; set; } = new CB0112B_LC02();
            public class CB0112B_LC02 : VarBasis
            {
                /*"    10        FILLER              PIC  X(112)  VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
                /*"    10        FILLER              PIC  X(010)  VALUE             'DATA  : '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DATA  : ");
                /*"    10        LC02-DATA           PIC  X(010).*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  03          LC03.*/
            }
            public CB0112B_LC03 LC03 { get; set; } = new CB0112B_LC03();
            public class CB0112B_LC03 : VarBasis
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
            public CB0112B_LC04 LC04 { get; set; } = new CB0112B_LC04();
            public class CB0112B_LC04 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE             'CONVENIO: 9022 - CARTAO DE CREDITO (  CIELO  )'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"CONVENIO: 9022 - CARTAO DE CREDITO (  CIELO  )");
                /*"  03          LC05.*/
            }
            public CB0112B_LC05 LC05 { get; set; } = new CB0112B_LC05();
            public class CB0112B_LC05 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE ALL '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"  03          LC06.*/
            }
            public CB0112B_LC06 LC06 { get; set; } = new CB0112B_LC06();
            public class CB0112B_LC06 : VarBasis
            {
                /*"    10        FILLER              PIC  X(010)  VALUE SPACES.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10        FILLER              PIC  X(007)  VALUE             'CARTAO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CARTAO");
                /*"    10        FILLER              PIC  X(015)  VALUE             'TITULO/APOLICE'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"TITULO/APOLICE");
                /*"    10        FILLER              PIC  X(010)  VALUE             'ENDOSSO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"ENDOSSO");
                /*"    10        FILLER              PIC  X(009)  VALUE             'PARC'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"PARC");
                /*"    10        FILLER              PIC  X(016)  VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"CERTIFICADO");
                /*"    10        FILLER              PIC  X(015)  VALUE             'VENCTO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"VENCTO");
                /*"    10        FILLER              PIC  X(006)  VALUE             'VALOR'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"VALOR");
                /*"    10        FILLER              PIC  X(005)  VALUE             'PROD'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"PROD");
                /*"    10        FILLER              PIC  X(005)  VALUE             'TIPO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"TIPO");
                /*"    10        FILLER              PIC  X(034)  VALUE             'MENSAGEM'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"MENSAGEM");
                /*"  03          LC07.*/
            }
            public CB0112B_LC07 LC07 { get; set; } = new CB0112B_LC07();
            public class CB0112B_LC07 : VarBasis
            {
                /*"    10        FILLER              PIC  X(132)  VALUE SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"  03          LD01.*/
            }
            public CB0112B_LD01 LD01 { get; set; } = new CB0112B_LD01();
            public class CB0112B_LD01 : VarBasis
            {
                /*"    10        LD01-CARTAO         PIC  ZZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_CARTAO { get; set; } = new IntBasis(new PIC("9", "16", "ZZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-TITULO         PIC  ZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_TITULO { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-ENDOSSO        PIC  ZZZZZZ9.*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10        FILLER              PIC  X(003)  VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10        LD01-PARCELA        PIC  ZZZ9.*/
                public IntBasis LD01_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-NRCERTIF       PIC  ZZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZZZ9."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-DTVENCTO       PIC  X(010).*/
                public StringBasis LD01_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-VALOR          PIC  ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VALOR { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-CODPRODU       PIC  9(004).*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-CODTRANS       PIC  9(004).*/
                public IntBasis LD01_CODTRANS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10        FILLER              PIC  X(001)  VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10        LD01-MENSAGEM       PIC  X(034).*/
                public StringBasis LD01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
                /*"01  AREA-ABEND.*/
            }
        }
        public CB0112B_AREA_ABEND AREA_ABEND { get; set; } = new CB0112B_AREA_ABEND();
        public class CB0112B_AREA_ABEND : VarBasis
        {
            /*"    05   WABEND.*/
            public CB0112B_WABEND WABEND { get; set; } = new CB0112B_WABEND();
            public class CB0112B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'CB0112B  '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"CB0112B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public CB0112B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new CB0112B_LOCALIZA_ABEND_1();
            public class CB0112B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public CB0112B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new CB0112B_LOCALIZA_ABEND_2();
            public class CB0112B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"    05      WSQLERRO.*/
            }
            public CB0112B_WSQLERRO WSQLERRO { get; set; } = new CB0112B_WSQLERRO();
            public class CB0112B_WSQLERRO : VarBasis
            {
                /*"      10       FILLER                PIC  X(014) VALUE            ' *** SQLERRMC '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"      10    WSQLERRMC                PIC  X(070) VALUE  SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public CB0112B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new CB0112B_HEADER_REGISTRO();
        public class CB0112B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-TIPO-REGISTRO    PIC  9(003).*/
            public IntBasis HEADER_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-TIPO-ARQUIVO     PIC  9(003).*/
            public IntBasis HEADER_TIPO_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      HEADER-DATA-GERACAO.*/
            public CB0112B_HEADER_DATA_GERACAO HEADER_DATA_GERACAO { get; set; } = new CB0112B_HEADER_DATA_GERACAO();
            public class CB0112B_HEADER_DATA_GERACAO : VarBasis
            {
                /*"    10    HEADER-ANO              PIC  9(004).*/
                public IntBasis HEADER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    HEADER-MES              PIC  9(002).*/
                public IntBasis HEADER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    HEADER-DIA              PIC  9(002).*/
                public IntBasis HEADER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      HEADER-COD-CONVENIO     PIC  9(006).*/
            }
            public IntBasis HEADER_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      HEADER-NSAS             PIC  9(005).*/
            public IntBasis HEADER_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      FILLER                  PIC  X(095).*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "95", "X(095)."), @"");
            /*"01        DETALHE-REGISTRO.*/
        }
        public CB0112B_DETALHE_REGISTRO DETALHE_REGISTRO { get; set; } = new CB0112B_DETALHE_REGISTRO();
        public class CB0112B_DETALHE_REGISTRO : VarBasis
        {
            /*"  05      DETALHE-TIPO-REGISTRO   PIC  9(003).*/
            public IntBasis DETALHE_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      DETALHE-NUM-CERTIFICADO PIC  9(015).*/
            public IntBasis DETALHE_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05      DETALHE-NUM-TITULO      PIC  9(013).*/
            public IntBasis DETALHE_NUM_TITULO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"  05      DETALHE-DATA-TRANSACAO.*/
            public CB0112B_DETALHE_DATA_TRANSACAO DETALHE_DATA_TRANSACAO { get; set; } = new CB0112B_DETALHE_DATA_TRANSACAO();
            public class CB0112B_DETALHE_DATA_TRANSACAO : VarBasis
            {
                /*"    10    DETALHE-ANO             PIC  9(004).*/
                public IntBasis DETALHE_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    DETALHE-MES             PIC  9(002).*/
                public IntBasis DETALHE_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    DETALHE-DIA             PIC  9(002).*/
                public IntBasis DETALHE_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      DETALHE-VLR-TRANSACAO   PIC  9(013)V99.*/
            }
            public DoubleBasis DETALHE_VLR_TRANSACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"  05      DETALHE-COD-TRANSACAO   PIC  9(003).*/
            public IntBasis DETALHE_COD_TRANSACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      DETALHE-QTD-PARCELA     PIC  9(003).*/
            public IntBasis DETALHE_QTD_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      DETALHE-NUM-PARCELA     PIC  9(003).*/
            public IntBasis DETALHE_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      DETALHE-TIPO-LANCAMEN   PIC  9(004).*/
            public IntBasis DETALHE_TIPO_LANCAMEN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      FILLER                  PIC  9(004).*/
            public IntBasis FILLER_55 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      DETALHE-REFERENCIA      PIC  9(009).*/
            public IntBasis DETALHE_REFERENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      FILLER                  PIC  X(040).*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"01        TRAILER-REGISTRO.*/
        }
        public CB0112B_TRAILER_REGISTRO TRAILER_REGISTRO { get; set; } = new CB0112B_TRAILER_REGISTRO();
        public class CB0112B_TRAILER_REGISTRO : VarBasis
        {
            /*"  05      TRAILER-TIPO-REGISTRO   PIC  9(003).*/
            public IntBasis TRAILER_TIPO_REGISTRO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      TRAILER-DATA-MOVIMENTO.*/
            public CB0112B_TRAILER_DATA_MOVIMENTO TRAILER_DATA_MOVIMENTO { get; set; } = new CB0112B_TRAILER_DATA_MOVIMENTO();
            public class CB0112B_TRAILER_DATA_MOVIMENTO : VarBasis
            {
                /*"    10    TRAILER-ANO             PIC  9(004).*/
                public IntBasis TRAILER_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    TRAILER-MES             PIC  9(002).*/
                public IntBasis TRAILER_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    TRAILER-DIA             PIC  9(002).*/
                public IntBasis TRAILER_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      TRAILER-COD-CONVENIO    PIC  9(006).*/
            }
            public IntBasis TRAILER_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      TRAILER-NSAS            PIC  9(005).*/
            public IntBasis TRAILER_NSAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      TRAILER-QTD-TOTAL       PIC  9(009).*/
            public IntBasis TRAILER_QTD_TOTAL { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05      TRAILER-VLR-TOTAL       PIC  9(015)V99.*/
            public DoubleBasis TRAILER_VLR_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"  05      FILLER                  PIC  X(072).*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"01          LK-LINK.*/
        }
        public CB0112B_LK_LINK LK_LINK { get; set; } = new CB0112B_LK_LINK();
        public class CB0112B_LK_LINK : VarBasis
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
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.PARAMCON PARAMCON { get; set; } = new Dclgens.PARAMCON();
        public Dclgens.BILCOBER BILCOBER { get; set; } = new Dclgens.BILCOBER();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public CB0112B_V0MOVDEBCE V0MOVDEBCE { get; set; } = new CB0112B_V0MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P, string RCB0112B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);
                RCB0112B.SetFile(RCB0112B_FILE_NAME_P);

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
            /*" -354- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -356- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -358- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -361- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -362- DISPLAY ' PROGRAMA EM EXECUCAO CB0112B  ' */
            _.Display($" PROGRAMA EM EXECUCAO CB0112B  ");

            /*" -363- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -364- DISPLAY ' VERSAO V.00 496.862 21/12/2023' */
            _.Display($" VERSAO V.00 496.862 21/12/2023");

            /*" -365- DISPLAY '-------------------------------' */
            _.Display($"-------------------------------");

            /*" -372- DISPLAY 'COMPILACAO: ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $"COMPILACAO: FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -374- DISPLAY '-------------------------------' . */
            _.Display($"-------------------------------");

            /*" -376- PERFORM R0050-00-INICIO */

            R0050_00_INICIO_SECTION();

            /*" -377- PERFORM R0300-00-DECLARE-V0MOVDEBCE */

            R0300_00_DECLARE_V0MOVDEBCE_SECTION();

            /*" -378- PERFORM R0310-00-FETCH-V0MOVDEBCE */

            R0310_00_FETCH_V0MOVDEBCE_SECTION();

            /*" -381- PERFORM R0350-00-PROCESSA-V0MOVDEBCE UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_V0MOVDEBCE_SECTION();
            }

            /*" -382- IF AC-QTD-TOTAL NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_QTD_TOTAL != 00)
            {

                /*" -383- PERFORM R1000-00-GRAVA-TRAILLER */

                R1000_00_GRAVA_TRAILLER_SECTION();

                /*" -384- ELSE */
            }
            else
            {


                /*" -385- DISPLAY 'SEM MOVIMENTO PARA ENVIO   ' */
                _.Display($"SEM MOVIMENTO PARA ENVIO   ");

                /*" -387- END-IF */
            }


            /*" -388- DISPLAY ' ' */
            _.Display($" ");

            /*" -389- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -390- DISPLAY '             ESTATISTICA DO CB0112B           ' */
            _.Display($"             ESTATISTICA DO CB0112B           ");

            /*" -391- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -392- DISPLAY 'LIDOS MOVDEBCE ................ ' LD-MOVDEBCE */
            _.Display($"LIDOS MOVDEBCE ................ {AREA_DE_WORK.LD_MOVDEBCE}");

            /*" -393- DISPLAY 'DESPREZADOS MOVDEBCE .......... ' DP-MOVDEBCE */
            _.Display($"DESPREZADOS MOVDEBCE .......... {AREA_DE_WORK.DP_MOVDEBCE}");

            /*" -394- DISPLAY 'ATUALIZADOS HIST_LANC_CTA ..... ' UP-HISLANCTA */
            _.Display($"ATUALIZADOS HIST_LANC_CTA ..... {AREA_DE_WORK.UP_HISLANCTA}");

            /*" -395- DISPLAY 'ATUALIZADOS MOVTO_DEBITOCC_CEF. ' UP-MOVTODEBCC */
            _.Display($"ATUALIZADOS MOVTO_DEBITOCC_CEF. {AREA_DE_WORK.UP_MOVTODEBCC}");

            /*" -396- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -397- DISPLAY ' ' */
            _.Display($" ");

            /*" -397- . */

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -404- CLOSE MOVIMENTO RCB0112B */
            MOVIMENTO.Close();
            RCB0112B.Close();

            /*" -404- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -407- DISPLAY 'PROCESSAMENTO REALIZADO COM COMMIT' */
            _.Display($"PROCESSAMENTO REALIZADO COM COMMIT");

            /*" -409- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -410- DISPLAY ' ' */
            _.Display($" ");

            /*" -411- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -412- DISPLAY '            CB0112B - TERMINO NORMAL          ' */
            _.Display($"            CB0112B - TERMINO NORMAL          ");

            /*" -413- DISPLAY '----------------------------------------------' */
            _.Display($"----------------------------------------------");

            /*" -415- DISPLAY ' ' . */
            _.Display($" ");

            /*" -415- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -424- MOVE 'R0050-00-INICIO' TO PARAGRAFO */
            _.Move("R0050-00-INICIO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -425- MOVE 'INICIO DO PROGRAMA' TO COMANDO */
            _.Move("INICIO DO PROGRAMA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -427- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -428- DISPLAY ' ' . */
            _.Display($" ");

            /*" -429- DISPLAY 'CONVENIO 9022 - DEVOLUCAO CARTAO CIELO (Manual)' */
            _.Display($"CONVENIO 9022 - DEVOLUCAO CARTAO CIELO (Manual)");

            /*" -430- DISPLAY 'ARQUIVO TIPO 001 - ENVIO           ' */
            _.Display($"ARQUIVO TIPO 001 - ENVIO           ");

            /*" -432- DISPLAY ' ' . */
            _.Display($" ");

            /*" -441- INITIALIZE LC01 LC02 LC03 LC04 LC05 LC06 LC07 LD01 */
            _.Initialize(
                AUX_RELATORIO.LC01
                , AUX_RELATORIO.LC02
                , AUX_RELATORIO.LC03
                , AUX_RELATORIO.LC04
                , AUX_RELATORIO.LC05
                , AUX_RELATORIO.LC06
                , AUX_RELATORIO.LC07
                , AUX_RELATORIO.LD01
            );

            /*" -444- OPEN OUTPUT MOVIMENTO RCB0112B */
            MOVIMENTO.Open(MOV_REGISTRO);
            RCB0112B.Open(REG_CB0112B);

            /*" -446- PERFORM R0100-00-SELECT-SISTEMA */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -447- MOVE 04 TO PARAMCON-TIPO-MOVTO-CC */
            _.Move(04, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC);

            /*" -448- MOVE 99 TO PARAMCON-COD-PRODUTO */
            _.Move(99, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO);

            /*" -450- MOVE 9022 TO PARAMCON-COD-CONVENIO */
            _.Move(9022, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO);

            /*" -452- DISPLAY 'DATA DE MOVIMENTO ........ ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DE MOVIMENTO ........ {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -454- DISPLAY 'DATA DE VENCIMENTO ATE ... ' WSHOST-DATA-PARAMETRO */
            _.Display($"DATA DE VENCIMENTO ATE ... {WSHOST_DATA_PARAMETRO}");

            /*" -456- DISPLAY ' ' */
            _.Display($" ");

            /*" -458- PERFORM R2000-00-CABECALHOS */

            R2000_00_CABECALHOS_SECTION();

            /*" -458- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -467- MOVE 'R0100-00-SELECT-SISTEMA' TO PARAGRAFO */
            _.Move("R0100-00-SELECT-SISTEMA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -468- MOVE 'INICIO DO PROGRAMA' TO COMANDO */
            _.Move("INICIO DO PROGRAMA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -470- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -476- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -479- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -480- DISPLAY 'CB0112B - SISTEMA NAO ESTA CADASTRADO' */
                _.Display($"CB0112B - SISTEMA NAO ESTA CADASTRADO");

                /*" -481- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -486- END-IF */
            }


            /*" -487- MOVE SISTEMAS-DATA-MOV-ABERTO TO WSHOST-DATA-PARAMETRO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WSHOST_DATA_PARAMETRO);

            /*" -488- MOVE WSHOST-DATA-PARAMETRO TO W04DTSQL */
            _.Move(WSHOST_DATA_PARAMETRO, AREA_DE_WORK.W04DTSQL);

            /*" -489- MOVE W04DDSQL TO SU1-DD1 */
            _.Move(AREA_DE_WORK.W04DTSQL.W04DDSQL, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_DD1);

            /*" -490- MOVE W04MMSQL TO SU1-MM1 */
            _.Move(AREA_DE_WORK.W04DTSQL.W04MMSQL, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_MM1);

            /*" -491- MOVE W04AASQL TO SU1-AA1 */
            _.Move(AREA_DE_WORK.W04DTSQL.W04AASQL, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1.SU1_AA1);

            /*" -492- MOVE ZEROES TO SU1-DATA2 */
            _.Move(0, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2);

            /*" -493- PERFORM R0140-00-SOMA-DIAS 6 TIMES */

            for (int i = 0; i < 6; i++)
            {

                R0140_00_SOMA_DIAS_SECTION();

            }

            /*" -494- MOVE SU1-DD2 TO W04DDSQL */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_DD2, AREA_DE_WORK.W04DTSQL.W04DDSQL);

            /*" -495- MOVE SU1-MM2 TO W04MMSQL */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_MM2, AREA_DE_WORK.W04DTSQL.W04MMSQL);

            /*" -497- MOVE SU1-AA2 TO W04AASQL */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2.SU1_AA2, AREA_DE_WORK.W04DTSQL.W04AASQL);

            /*" -499- MOVE W04DTSQL TO WSHOST-DATA-PARAMETRO */
            _.Move(AREA_DE_WORK.W04DTSQL, WSHOST_DATA_PARAMETRO);

            /*" -500- ACCEPT WHORA-CURR FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -501- MOVE WHORA-HH-CURR TO WHORA-HH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -502- MOVE WHORA-MM-CURR TO WHORA-MM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -503- MOVE WHORA-SS-CURR TO WHORA-SS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -505- MOVE WHORA-CABEC TO LC03-HORA. */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AUX_RELATORIO.LC03.LC03_HORA);

            /*" -506- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-HOST */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_HOST);

            /*" -507- MOVE WDATA-AA-HOST TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_AA_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -508- MOVE WDATA-MM-HOST TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_MM_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -509- MOVE WDATA-DD-HOST TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_DD_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -512- MOVE WDATA-CABEC TO LC02-DATA LC03-DTMOVTO */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AUX_RELATORIO.LC02.LC02_DATA, AUX_RELATORIO.LC03.LC03_DTMOVTO);

            /*" -512- . */

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -476- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CB' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0140-00-SOMA-DIAS-SECTION */
        private void R0140_00_SOMA_DIAS_SECTION()
        {
            /*" -521- MOVE 'R0140-00-SOMA-DIAS' TO PARAGRAFO */
            _.Move("R0140-00-SOMA-DIAS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -523- MOVE 'SOMA DIAS A DATA ENVIADA' TO COMANDO */
            _.Move("SOMA DIAS A DATA ENVIADA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -524- MOVE +1 TO SU1-NRDIAS */
            _.Move(+1, AREA_DE_WORK.PARM_PROSOMU1.SU1_NRDIAS);

            /*" -525- CALL 'PROSOCU1' USING PARM-PROSOMU1 */
            _.Call("PROSOCU1", AREA_DE_WORK.PARM_PROSOMU1);

            /*" -527- MOVE SU1-DATA2 TO SU1-DATA1 */
            _.Move(AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA2, AREA_DE_WORK.PARM_PROSOMU1.SU1_DATA1);

            /*" -527- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-DECLARE-V0MOVDEBCE-SECTION */
        private void R0300_00_DECLARE_V0MOVDEBCE_SECTION()
        {
            /*" -536- MOVE 'R0300-00-DECLARE-V0MOVDEBCE' TO PARAGRAFO */
            _.Move("R0300-00-DECLARE-V0MOVDEBCE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -537- MOVE 'DECLARACAO DO CURSOR PRINCIPAL' TO COMANDO */
            _.Move("DECLARACAO DO CURSOR PRINCIPAL", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -539- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -540- MOVE WSHOST-DATA-PARAMETRO TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(WSHOST_DATA_PARAMETRO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -541- MOVE PARAMCON-COD-CONVENIO TO MOVDEBCE-COD-CONVENIO */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -543- MOVE ZEROS TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -561- PERFORM R0300_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1 */

            R0300_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1();

            /*" -563- PERFORM R0300_00_DECLARE_V0MOVDEBCE_DB_OPEN_1 */

            R0300_00_DECLARE_V0MOVDEBCE_DB_OPEN_1();

            /*" -566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -567- DISPLAY 'R0300-00 - PROBLEMAS DECLARE (MOVDEBCE)   ' */
                _.Display($"R0300-00 - PROBLEMAS DECLARE (MOVDEBCE)   ");

                /*" -568- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -570- END-IF */
            }


            /*" -570- . */

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0MOVDEBCE-DB-DECLARE-1 */
        public void R0300_00_DECLARE_V0MOVDEBCE_DB_DECLARE_1()
        {
            /*" -561- EXEC SQL DECLARE V0MOVDEBCE CURSOR FOR SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , DIG_CONTA_DEB , NSAS , NUM_CARTAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE SITUACAO_COBRANCA IN ( ' ' , '0' ) AND DATA_VENCIMENTO <= :MOVDEBCE-DATA-VENCIMENTO AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND COD_EMPRESA = :MOVDEBCE-COD-EMPRESA END-EXEC */
            V0MOVDEBCE = new CB0112B_V0MOVDEBCE(true);
            string GetQuery_V0MOVDEBCE()
            {
                var query = @$"SELECT NUM_APOLICE 
							, NUM_ENDOSSO 
							, NUM_PARCELA 
							, SITUACAO_COBRANCA 
							, DATA_VENCIMENTO 
							, VALOR_DEBITO 
							, COD_AGENCIA_DEB 
							, OPER_CONTA_DEB 
							, DIG_CONTA_DEB 
							, NSAS 
							, NUM_CARTAO 
							FROM SEGUROS.MOVTO_DEBITOCC_CEF 
							WHERE SITUACAO_COBRANCA IN ( ' '
							, '0' ) 
							AND DATA_VENCIMENTO <= '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO}' 
							AND COD_CONVENIO = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}' 
							AND COD_EMPRESA = '{MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA}'";

                return query;
            }
            V0MOVDEBCE.GetQueryEvent += GetQuery_V0MOVDEBCE;

        }

        [StopWatch]
        /*" R0300-00-DECLARE-V0MOVDEBCE-DB-OPEN-1 */
        public void R0300_00_DECLARE_V0MOVDEBCE_DB_OPEN_1()
        {
            /*" -563- EXEC SQL OPEN V0MOVDEBCE END-EXEC */

            V0MOVDEBCE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-FETCH-V0MOVDEBCE-SECTION */
        private void R0310_00_FETCH_V0MOVDEBCE_SECTION()
        {
            /*" -579- MOVE 'R0310-00-FETCH-V0MOVDEBCE' TO PARAGRAFO */
            _.Move("R0310-00-FETCH-V0MOVDEBCE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -580- MOVE 'REALIZA SORT DOS DADOS' TO COMANDO */
            _.Move("REALIZA SORT DOS DADOS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -582- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -594- PERFORM R0310_00_FETCH_V0MOVDEBCE_DB_FETCH_1 */

            R0310_00_FETCH_V0MOVDEBCE_DB_FETCH_1();

            /*" -597-  EVALUATE SQLCODE  */

            /*" -598-  WHEN ZEROS  */

            /*" -598- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -599- CONTINUE */

                /*" -600-  WHEN +100  */

                /*" -600- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -600- PERFORM R0310_00_FETCH_V0MOVDEBCE_DB_CLOSE_1 */

                R0310_00_FETCH_V0MOVDEBCE_DB_CLOSE_1();

                /*" -602- MOVE 'S' TO WFIM-MOVIMENTO */
                _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                /*" -603- GO TO R0310-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                return;

                /*" -604-  WHEN OTHER  */

                /*" -604- ELSE */
            }
            else
            {


                /*" -605- DISPLAY 'R0310-00 - PROBLEMAS FETCH   (MOVDEBCE)   ' */
                _.Display($"R0310-00 - PROBLEMAS FETCH   (MOVDEBCE)   ");

                /*" -606- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -608-  END-EVALUATE  */

                /*" -608- END-IF */
            }


            /*" -610- ADD 1 TO LD-MOVDEBCE */
            AREA_DE_WORK.LD_MOVDEBCE.Value = AREA_DE_WORK.LD_MOVDEBCE + 1;

            /*" -611- IF VIND-NUM-CARTAO LESS ZEROS */

            if (VIND_NUM_CARTAO < 00)
            {

                /*" -612- MOVE ZEROS TO MOVDEBCE-NUM-CARTAO */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);

                /*" -614- END-IF */
            }


            /*" -615- IF VIND-OPERACAO LESS ZEROS */

            if (VIND_OPERACAO < 00)
            {

                /*" -616- MOVE ZEROS TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -618- END-IF */
            }


            /*" -619- IF VIND-TRANSACAO LESS ZEROS */

            if (VIND_TRANSACAO < 00)
            {

                /*" -620- MOVE ZEROS TO MOVDEBCE-DIG-CONTA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

                /*" -622- END-IF */
            }


            /*" -623- IF VIND-AGENCIA LESS ZEROS */

            if (VIND_AGENCIA < 00)
            {

                /*" -624- MOVE ZEROS TO MOVDEBCE-COD-AGENCIA-DEB */
                _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

                /*" -626- END-IF */
            }


            /*" -626- . */

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0MOVDEBCE-DB-FETCH-1 */
        public void R0310_00_FETCH_V0MOVDEBCE_DB_FETCH_1()
        {
            /*" -594- EXEC SQL FETCH V0MOVDEBCE INTO :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-COD-AGENCIA-DEB:VIND-AGENCIA , :MOVDEBCE-OPER-CONTA-DEB:VIND-OPERACAO , :MOVDEBCE-DIG-CONTA-DEB:VIND-TRANSACAO , :MOVDEBCE-NSAS , :MOVDEBCE-NUM-CARTAO:VIND-NUM-CARTAO END-EXEC */

            if (V0MOVDEBCE.Fetch())
            {
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_APOLICE, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_ENDOSSO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_PARCELA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);
                _.Move(V0MOVDEBCE.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(V0MOVDEBCE.MOVDEBCE_DATA_VENCIMENTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);
                _.Move(V0MOVDEBCE.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
                _.Move(V0MOVDEBCE.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(V0MOVDEBCE.VIND_AGENCIA, VIND_AGENCIA);
                _.Move(V0MOVDEBCE.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(V0MOVDEBCE.VIND_OPERACAO, VIND_OPERACAO);
                _.Move(V0MOVDEBCE.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(V0MOVDEBCE.VIND_TRANSACAO, VIND_TRANSACAO);
                _.Move(V0MOVDEBCE.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
                _.Move(V0MOVDEBCE.MOVDEBCE_NUM_CARTAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO);
                _.Move(V0MOVDEBCE.VIND_NUM_CARTAO, VIND_NUM_CARTAO);
            }

        }

        [StopWatch]
        /*" R0310-00-FETCH-V0MOVDEBCE-DB-CLOSE-1 */
        public void R0310_00_FETCH_V0MOVDEBCE_DB_CLOSE_1()
        {
            /*" -600- EXEC SQL CLOSE V0MOVDEBCE END-EXEC */

            V0MOVDEBCE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-V0MOVDEBCE-SECTION */
        private void R0350_00_PROCESSA_V0MOVDEBCE_SECTION()
        {
            /*" -635- MOVE 'R0350-00-PROCESSA-V0MOVDEBCE' TO PARAGRAFO */
            _.Move("R0350-00-PROCESSA-V0MOVDEBCE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -636- MOVE 'PROCESSA CURSOR PARA CARGA DO SORT' TO COMANDO */
            _.Move("PROCESSA CURSOR PARA CARGA DO SORT", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -638- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -639- IF MOVDEBCE-VALOR-DEBITO EQUAL ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO == 00)
            {

                /*" -641- MOVE 'VALOR INFORMADO IGUAL A ZEROS     ' TO LD01-MENSAGEM */
                _.Move("VALOR INFORMADO IGUAL A ZEROS     ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -643- END-IF */
            }


            /*" -644- IF MOVDEBCE-VALOR-DEBITO LESS ZEROS */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO < 00)
            {

                /*" -646- MOVE 'VALOR INFORMADO NEGATIVO          ' TO LD01-MENSAGEM */
                _.Move("VALOR INFORMADO NEGATIVO          ", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -648- END-IF */
            }


            /*" -650- PERFORM R0420-00-SELECT-COBHISVI */

            R0420_00_SELECT_COBHISVI_SECTION();

            /*" -651- MOVE ZEROS TO AUX-TRANSACAO */
            _.Move(0, AREA_DE_WORK.AUX_TRANSACAO);

            /*" -652- IF LD01-MENSAGEM NOT EQUAL SPACES */

            if (!AUX_RELATORIO.LD01.LD01_MENSAGEM.IsEmpty())
            {

                /*" -653- PERFORM R1500-00-IMPRIME-RELATORIO */

                R1500_00_IMPRIME_RELATORIO_SECTION();

                /*" -654- ADD 1 TO DP-MOVDEBCE */
                AREA_DE_WORK.DP_MOVDEBCE.Value = AREA_DE_WORK.DP_MOVDEBCE + 1;

                /*" -655- GO TO R0350-90-LEITURA */

                R0350_90_LEITURA(); //GOTO
                return;

                /*" -657- END-IF */
            }


            /*" -658- IF AC-QTD-TOTAL EQUAL ZEROS */

            if (AREA_DE_WORK.AC_QTD_TOTAL == 00)
            {

                /*" -659- PERFORM R0650-00-GRAVA-HEADER */

                R0650_00_GRAVA_HEADER_SECTION();

                /*" -661- END-IF */
            }


            /*" -663- MOVE SPACES TO LD01 */
            _.Move("", AUX_RELATORIO.LD01);

            /*" -665- PERFORM R0690-00-GRAVA-DETALHE */

            R0690_00_GRAVA_DETALHE_SECTION();

            /*" -665- . */

            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -669- PERFORM R0310-00-FETCH-V0MOVDEBCE. */

            R0310_00_FETCH_V0MOVDEBCE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0420-00-SELECT-COBHISVI-SECTION */
        private void R0420_00_SELECT_COBHISVI_SECTION()
        {
            /*" -678- MOVE 'R0420-00-SELECT-COBHISVI' TO PARAGRAFO */
            _.Move("R0420-00-SELECT-COBHISVI", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -679- MOVE 'RECUPERA DADOS DO TITULO' TO COMANDO */
            _.Move("RECUPERA DADOS DO TITULO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -681- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -683- MOVE MOVDEBCE-NUM-APOLICE TO COBHISVI-NUM-TITULO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO);

            /*" -697- PERFORM R0420_00_SELECT_COBHISVI_DB_SELECT_1 */

            R0420_00_SELECT_COBHISVI_DB_SELECT_1();

            /*" -700- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -701- DISPLAY 'R0420 - FALHA NA CONSULTA DO TITULO' */
                _.Display($"R0420 - FALHA NA CONSULTA DO TITULO");

                /*" -702- DISPLAY 'CERTIFICADO = ' COBHISVI-NUM-TITULO */
                _.Display($"CERTIFICADO = {COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO}");

                /*" -704- MOVE 'TITULO NAO FOI ENCONTRADO PARA DEVOLUCAO' TO LD01-MENSAGEM */
                _.Move("TITULO NAO FOI ENCONTRADO PARA DEVOLUCAO", AUX_RELATORIO.LD01.LD01_MENSAGEM);

                /*" -706- END-IF */
            }


            /*" -706- . */

        }

        [StopWatch]
        /*" R0420-00-SELECT-COBHISVI-DB-SELECT-1 */
        public void R0420_00_SELECT_COBHISVI_DB_SELECT_1()
        {
            /*" -697- EXEC SQL SELECT B.NUM_CERTIFICADO , B.COD_PRODUTO , B.NUM_APOLICE , B.COD_SUBGRUPO INTO :PROPOVA-NUM-CERTIFICADO , :PROPOVA-COD-PRODUTO , :PROPOVA-NUM-APOLICE , :PROPOVA-COD-SUBGRUPO FROM SEGUROS.COBER_HIST_VIDAZUL A , SEGUROS.PROPOSTAS_VA B WHERE A.NUM_TITULO = :COBHISVI-NUM-TITULO AND B.NUM_CERTIFICADO = A.NUM_CERTIFICADO WITH UR END-EXEC */

            var r0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1 = new R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_TITULO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_TITULO.ToString(),
            };

            var executed_1 = R0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1.Execute(r0420_00_SELECT_COBHISVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(executed_1.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(executed_1.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(executed_1.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0420_99_SAIDA*/

        [StopWatch]
        /*" R0650-00-GRAVA-HEADER-SECTION */
        private void R0650_00_GRAVA_HEADER_SECTION()
        {
            /*" -715- MOVE 'R0650-00-GRAVA-HEADER' TO PARAGRAFO */
            _.Move("R0650-00-GRAVA-HEADER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -716- MOVE 'GRAVAR HEADER' TO COMANDO */
            _.Move("GRAVAR HEADER", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -718- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -720- PERFORM R0660-00-SELECT-PARAMCON */

            R0660_00_SELECT_PARAMCON_SECTION();

            /*" -721- MOVE SPACES TO HEADER-REGISTRO */
            _.Move("", HEADER_REGISTRO);

            /*" -722- MOVE 000 TO HEADER-TIPO-REGISTRO */
            _.Move(000, HEADER_REGISTRO.HEADER_TIPO_REGISTRO);

            /*" -723- MOVE 001 TO HEADER-TIPO-ARQUIVO */
            _.Move(001, HEADER_REGISTRO.HEADER_TIPO_ARQUIVO);

            /*" -724- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-HOST */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_HOST);

            /*" -725- MOVE WDATA-AA-HOST TO HEADER-ANO */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_AA_HOST, HEADER_REGISTRO.HEADER_DATA_GERACAO.HEADER_ANO);

            /*" -726- MOVE WDATA-MM-HOST TO HEADER-MES */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_MM_HOST, HEADER_REGISTRO.HEADER_DATA_GERACAO.HEADER_MES);

            /*" -727- MOVE WDATA-DD-HOST TO HEADER-DIA */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_DD_HOST, HEADER_REGISTRO.HEADER_DATA_GERACAO.HEADER_DIA);

            /*" -728- MOVE PARAMCON-COD-CONVENIO TO HEADER-COD-CONVENIO */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, HEADER_REGISTRO.HEADER_COD_CONVENIO);

            /*" -730- MOVE AUX-NSAS TO HEADER-NSAS */
            _.Move(AREA_DE_WORK.AUX_NSAS, HEADER_REGISTRO.HEADER_NSAS);

            /*" -731- MOVE HEADER-REGISTRO TO MOV-REGISTRO */
            _.Move(HEADER_REGISTRO, MOV_REGISTRO);

            /*" -733- WRITE MOV-REGISTRO */
            MOVIMENTO.Write(MOV_REGISTRO.GetMoveValues().ToString());

            /*" -733- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_99_SAIDA*/

        [StopWatch]
        /*" R0660-00-SELECT-PARAMCON-SECTION */
        private void R0660_00_SELECT_PARAMCON_SECTION()
        {
            /*" -742- MOVE 'R0660-00-SELECT-PARAMCON' TO PARAGRAFO */
            _.Move("R0660-00-SELECT-PARAMCON", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -743- MOVE 'RECUPERA NSAS' TO COMANDO */
            _.Move("RECUPERA NSAS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -745- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -753- PERFORM R0660_00_SELECT_PARAMCON_DB_SELECT_1 */

            R0660_00_SELECT_PARAMCON_DB_SELECT_1();

            /*" -756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -757- DISPLAY 'CB0112B - PARAMCON NAO ESTA CADASTRADA' */
                _.Display($"CB0112B - PARAMCON NAO ESTA CADASTRADA");

                /*" -758- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -760- END-IF */
            }


            /*" -761- ADD 1 TO PARAMCON-NSAS */
            PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.Value = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS + 1;

            /*" -762- MOVE PARAMCON-NSAS TO AUX-NSAS */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, AREA_DE_WORK.AUX_NSAS);

            /*" -764- MOVE ZEROS TO AUX-SEQUENCIA */
            _.Move(0, AREA_DE_WORK.AUX_SEQUENCIA);

            /*" -765- DISPLAY ' ' . */
            _.Display($" ");

            /*" -766- DISPLAY 'NSAS DE ENVIO PARAMCON ..... ' PARAMCON-NSAS */
            _.Display($"NSAS DE ENVIO PARAMCON ..... {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS}");

            /*" -768- DISPLAY ' ' */
            _.Display($" ");

            /*" -768- . */

        }

        [StopWatch]
        /*" R0660-00-SELECT-PARAMCON-DB-SELECT-1 */
        public void R0660_00_SELECT_PARAMCON_DB_SELECT_1()
        {
            /*" -753- EXEC SQL SELECT NSAS INTO :PARAMCON-NSAS FROM SEGUROS.PARAM_CONTACEF WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC AND COD_PRODUTO = :PARAMCON-COD-PRODUTO AND COD_CONVENIO = :PARAMCON-COD-CONVENIO WITH UR END-EXEC */

            var r0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1 = new R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1()
            {
                PARAMCON_TIPO_MOVTO_CC = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                PARAMCON_COD_PRODUTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1.Execute(r0660_00_SELECT_PARAMCON_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMCON_NSAS, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0660_99_SAIDA*/

        [StopWatch]
        /*" R0690-00-GRAVA-DETALHE-SECTION */
        private void R0690_00_GRAVA_DETALHE_SECTION()
        {
            /*" -777- MOVE 'R0690-00-GRAVA-DETALHE' TO PARAGRAFO */
            _.Move("R0690-00-GRAVA-DETALHE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -778- MOVE 'GRAVAR DETALHE DO ARQUIVO' TO COMANDO */
            _.Move("GRAVAR DETALHE DO ARQUIVO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -780- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -781- MOVE SPACES TO DETALHE-REGISTRO */
            _.Move("", DETALHE_REGISTRO);

            /*" -783- MOVE 1 TO DETALHE-TIPO-REGISTRO DETALHE-QTD-PARCELA */
            _.Move(1, DETALHE_REGISTRO.DETALHE_TIPO_REGISTRO, DETALHE_REGISTRO.DETALHE_QTD_PARCELA);

            /*" -784- MOVE MOVDEBCE-NUM-CARTAO TO DETALHE-NUM-CERTIFICADO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, DETALHE_REGISTRO.DETALHE_NUM_CERTIFICADO);

            /*" -785- MOVE MOVDEBCE-NUM-APOLICE TO DETALHE-NUM-TITULO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE, DETALHE_REGISTRO.DETALHE_NUM_TITULO);

            /*" -786- MOVE MOVDEBCE-DATA-VENCIMENTO TO WDATA-HOST */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO, AREA_DE_WORK.WDATA_HOST);

            /*" -787- MOVE WDATA-AA-HOST TO DETALHE-ANO */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_AA_HOST, DETALHE_REGISTRO.DETALHE_DATA_TRANSACAO.DETALHE_ANO);

            /*" -788- MOVE WDATA-MM-HOST TO DETALHE-MES */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_MM_HOST, DETALHE_REGISTRO.DETALHE_DATA_TRANSACAO.DETALHE_MES);

            /*" -789- MOVE WDATA-DD-HOST TO DETALHE-DIA */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_DD_HOST, DETALHE_REGISTRO.DETALHE_DATA_TRANSACAO.DETALHE_DIA);

            /*" -790- MOVE MOVDEBCE-VALOR-DEBITO TO DETALHE-VLR-TRANSACAO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, DETALHE_REGISTRO.DETALHE_VLR_TRANSACAO);

            /*" -791- MOVE MOVDEBCE-DIG-CONTA-DEB TO DETALHE-COD-TRANSACAO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB, DETALHE_REGISTRO.DETALHE_COD_TRANSACAO);

            /*" -792- MOVE MOVDEBCE-NUM-PARCELA TO DETALHE-NUM-PARCELA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, DETALHE_REGISTRO.DETALHE_NUM_PARCELA);

            /*" -794- MOVE AUX-TRANSACAO TO DETALHE-TIPO-LANCAMEN */
            _.Move(AREA_DE_WORK.AUX_TRANSACAO, DETALHE_REGISTRO.DETALHE_TIPO_LANCAMEN);

            /*" -795- IF DETALHE-NUM-PARCELA EQUAL ZEROS */

            if (DETALHE_REGISTRO.DETALHE_NUM_PARCELA == 00)
            {

                /*" -796- MOVE 1 TO DETALHE-NUM-PARCELA */
                _.Move(1, DETALHE_REGISTRO.DETALHE_NUM_PARCELA);

                /*" -798- END-IF */
            }


            /*" -799- IF DETALHE-NUM-PARCELA GREATER DETALHE-QTD-PARCELA */

            if (DETALHE_REGISTRO.DETALHE_NUM_PARCELA > DETALHE_REGISTRO.DETALHE_QTD_PARCELA)
            {

                /*" -800- MOVE DETALHE-NUM-PARCELA TO DETALHE-QTD-PARCELA */
                _.Move(DETALHE_REGISTRO.DETALHE_NUM_PARCELA, DETALHE_REGISTRO.DETALHE_QTD_PARCELA);

                /*" -803- END-IF */
            }


            /*" -804- ADD 1 TO AUX-SEQUENCIA */
            AREA_DE_WORK.AUX_SEQUENCIA.Value = AREA_DE_WORK.AUX_SEQUENCIA + 1;

            /*" -806- MOVE AUX-SEQUENCIA TO DETALHE-REFERENCIA */
            _.Move(AREA_DE_WORK.AUX_SEQUENCIA, DETALHE_REGISTRO.DETALHE_REFERENCIA);

            /*" -807- PERFORM R0700-00-UPDATE-V0MOVDEBCE */

            R0700_00_UPDATE_V0MOVDEBCE_SECTION();

            /*" -809- PERFORM R0750-00-UPDATE-V0HISTCONTAVA */

            R0750_00_UPDATE_V0HISTCONTAVA_SECTION();

            /*" -811- MOVE DETALHE-REGISTRO TO MOV-REGISTRO */
            _.Move(DETALHE_REGISTRO, MOV_REGISTRO);

            /*" -813- WRITE MOV-REGISTRO. */
            MOVIMENTO.Write(MOV_REGISTRO.GetMoveValues().ToString());

            /*" -814- ADD 1 TO AC-QTD-TOTAL */
            AREA_DE_WORK.AC_QTD_TOTAL.Value = AREA_DE_WORK.AC_QTD_TOTAL + 1;

            /*" -816- ADD DETALHE-VLR-TRANSACAO TO AC-VLR-TOTAL */
            AREA_DE_WORK.AC_VLR_TOTAL.Value = AREA_DE_WORK.AC_VLR_TOTAL + DETALHE_REGISTRO.DETALHE_VLR_TRANSACAO;

            /*" -816- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0690_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-UPDATE-V0MOVDEBCE-SECTION */
        private void R0700_00_UPDATE_V0MOVDEBCE_SECTION()
        {
            /*" -825- MOVE 'R0700-00-UPDATE-V0MOVDEBCE' TO PARAGRAFO */
            _.Move("R0700-00-UPDATE-V0MOVDEBCE", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -826- MOVE 'ATUALIZA TABELA MOVTO_DEBITOCC_CEF' TO COMANDO */
            _.Move("ATUALIZA TABELA MOVTO_DEBITOCC_CEF", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -828- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -829- MOVE PARAMCON-COD-CONVENIO TO MOVDEBCE-COD-CONVENIO */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -831- MOVE DETALHE-REFERENCIA TO WS-NSL */
            _.Move(DETALHE_REGISTRO.DETALHE_REFERENCIA, AREA_DE_WORK.WS_NSL);

            /*" -843- PERFORM R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1 */

            R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1();

            /*" -846- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -847- ADD 1 TO UP-MOVTODEBCC */
                AREA_DE_WORK.UP_MOVTODEBCC.Value = AREA_DE_WORK.UP_MOVTODEBCC + 1;

                /*" -848- ELSE */
            }
            else
            {


                /*" -849- DISPLAY 'R0700-00 - PROBLEMAS UPDATE MOVDEBCE   ' */
                _.Display($"R0700-00 - PROBLEMAS UPDATE MOVDEBCE   ");

                /*" -850- DISPLAY 'COD-CONVENIO = ' MOVDEBCE-COD-CONVENIO */
                _.Display($"COD-CONVENIO = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -851- DISPLAY 'NSAS         = ' MOVDEBCE-NSAS */
                _.Display($"NSAS         = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}");

                /*" -852- DISPLAY 'NUM-APOLICE  = ' MOVDEBCE-NUM-APOLICE */
                _.Display($"NUM-APOLICE  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -853- DISPLAY 'NUM-ENDOSSO  = ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -854- DISPLAY 'NUM-PARCELA  = ' MOVDEBCE-NUM-PARCELA */
                _.Display($"NUM-PARCELA  = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -855- DISPLAY 'SIT-COBRANCA = ' MOVDEBCE-SITUACAO-COBRANCA */
                _.Display($"SIT-COBRANCA = {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA}");

                /*" -856- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -857- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -859- END-IF */
            }


            /*" -859- . */

        }

        [StopWatch]
        /*" R0700-00-UPDATE-V0MOVDEBCE-DB-UPDATE-1 */
        public void R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1()
        {
            /*" -843- EXEC SQL UPDATE SEGUROS.MOVTO_DEBITOCC_CEF SET SITUACAO_COBRANCA = '5' , DATA_ENVIO = :SISTEMAS-DATA-MOV-ABERTO , NSAS = :PARAMCON-NSAS , NUM_ENDOSSO = :WS-NSL WHERE COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS AND NUM_APOLICE = :MOVDEBCE-NUM-APOLICE AND NUM_ENDOSSO = :MOVDEBCE-NUM-ENDOSSO AND NUM_PARCELA = :MOVDEBCE-NUM-PARCELA AND SITUACAO_COBRANCA = :MOVDEBCE-SITUACAO-COBRANCA END-EXEC. */

            var r0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1 = new R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                WS_NSL = AREA_DE_WORK.WS_NSL.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            R0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1.Execute(r0700_00_UPDATE_V0MOVDEBCE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0750-00-UPDATE-V0HISTCONTAVA-SECTION */
        private void R0750_00_UPDATE_V0HISTCONTAVA_SECTION()
        {
            /*" -868- MOVE 'R0750-00-UPDATE-V0HISTCONTAVA' TO PARAGRAFO */
            _.Move("R0750-00-UPDATE-V0HISTCONTAVA", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -869- MOVE 'ATUALIZA TABELA HIST_LANC_CTA' TO COMANDO */
            _.Move("ATUALIZA TABELA HIST_LANC_CTA", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -871- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -872- MOVE PROPOVA-NUM-CERTIFICADO TO HISLANCT-NUM-CERTIFICADO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);

            /*" -873- MOVE MOVDEBCE-NUM-PARCELA TO HISLANCT-NUM-PARCELA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);

            /*" -874- MOVE '3' TO HISLANCT-SIT-REGISTRO */
            _.Move("3", HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);

            /*" -875- MOVE PARAMCON-NSAS TO HISLANCT-NSAS */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS);

            /*" -876- MOVE DETALHE-REFERENCIA TO HISLANCT-NSL */
            _.Move(DETALHE_REGISTRO.DETALHE_REFERENCIA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL);

            /*" -879- MOVE ZEROS TO VIND-NSAS VIND-NSL */
            _.Move(0, VIND_NSAS, VIND_NSL);

            /*" -889- PERFORM R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1 */

            R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1();

            /*" -892- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -893- ADD 1 TO UP-HISLANCTA */
                AREA_DE_WORK.UP_HISLANCTA.Value = AREA_DE_WORK.UP_HISLANCTA + 1;

                /*" -894- ELSE */
            }
            else
            {


                /*" -895- DISPLAY 'R0700-00 - PROBLEMAS UPDATE HIST_LANC_CTA' */
                _.Display($"R0700-00 - PROBLEMAS UPDATE HIST_LANC_CTA");

                /*" -896- DISPLAY 'NUM-CERTIFICADO = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -897- DISPLAY 'NUM-PARCELA     = ' HISLANCT-NUM-PARCELA */
                _.Display($"NUM-PARCELA     = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA}");

                /*" -898- DISPLAY 'SQLCODE         = ' SQLCODE */
                _.Display($"SQLCODE         = {DB.SQLCODE}");

                /*" -899- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -901- END-IF */
            }


            /*" -901- . */

        }

        [StopWatch]
        /*" R0750-00-UPDATE-V0HISTCONTAVA-DB-UPDATE-1 */
        public void R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1()
        {
            /*" -889- EXEC SQL UPDATE SEGUROS.HIST_LANC_CTA SET SIT_REGISTRO = :HISLANCT-SIT-REGISTRO , NSAS = :HISLANCT-NSAS :VIND-NSAS , NSL = :HISLANCT-NSL :VIND-NSL WHERE NUM_CERTIFICADO = :HISLANCT-NUM-CERTIFICADO AND NUM_PARCELA = :HISLANCT-NUM-PARCELA AND SIT_REGISTRO = '0' AND TIPLANC = '2' AND CODCONV = :PARAMCON-COD-CONVENIO END-EXEC */

            var r0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1 = new R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1()
            {
                HISLANCT_NSAS = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSAS.ToString(),
                VIND_NSAS = VIND_NSAS.ToString(),
                HISLANCT_NSL = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NSL.ToString(),
                VIND_NSL = VIND_NSL.ToString(),
                HISLANCT_SIT_REGISTRO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO.ToString(),
                HISLANCT_NUM_CERTIFICADO = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                HISLANCT_NUM_PARCELA = HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA.ToString(),
            };

            R0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1.Execute(r0750_00_UPDATE_V0HISTCONTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-GRAVA-TRAILLER-SECTION */
        private void R1000_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -910- MOVE 'R1000-00-GRAVA-TRAILLER' TO PARAGRAFO */
            _.Move("R1000-00-GRAVA-TRAILLER", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -911- MOVE 'GRAVA TRAILLER' TO COMANDO */
            _.Move("GRAVA TRAILLER", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -913- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -914- MOVE SPACES TO TRAILER-REGISTRO */
            _.Move("", TRAILER_REGISTRO);

            /*" -915- MOVE 999 TO TRAILER-TIPO-REGISTRO */
            _.Move(999, TRAILER_REGISTRO.TRAILER_TIPO_REGISTRO);

            /*" -916- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-HOST */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_HOST);

            /*" -917- MOVE WDATA-AA-HOST TO TRAILER-ANO */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_AA_HOST, TRAILER_REGISTRO.TRAILER_DATA_MOVIMENTO.TRAILER_ANO);

            /*" -918- MOVE WDATA-MM-HOST TO TRAILER-MES */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_MM_HOST, TRAILER_REGISTRO.TRAILER_DATA_MOVIMENTO.TRAILER_MES);

            /*" -919- MOVE WDATA-DD-HOST TO TRAILER-DIA */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_DD_HOST, TRAILER_REGISTRO.TRAILER_DATA_MOVIMENTO.TRAILER_DIA);

            /*" -920- MOVE PARAMCON-COD-CONVENIO TO TRAILER-COD-CONVENIO */
            _.Move(PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO, TRAILER_REGISTRO.TRAILER_COD_CONVENIO);

            /*" -921- MOVE AUX-NSAS TO TRAILER-NSAS */
            _.Move(AREA_DE_WORK.AUX_NSAS, TRAILER_REGISTRO.TRAILER_NSAS);

            /*" -922- MOVE AC-QTD-TOTAL TO TRAILER-QTD-TOTAL */
            _.Move(AREA_DE_WORK.AC_QTD_TOTAL, TRAILER_REGISTRO.TRAILER_QTD_TOTAL);

            /*" -924- MOVE AC-VLR-TOTAL TO TRAILER-VLR-TOTAL */
            _.Move(AREA_DE_WORK.AC_VLR_TOTAL, TRAILER_REGISTRO.TRAILER_VLR_TOTAL);

            /*" -925- MOVE TRAILER-REGISTRO TO MOV-REGISTRO */
            _.Move(TRAILER_REGISTRO, MOV_REGISTRO);

            /*" -927- WRITE MOV-REGISTRO */
            MOVIMENTO.Write(MOV_REGISTRO.GetMoveValues().ToString());

            /*" -929- PERFORM R1100-00-UPDATE-PARAMCON */

            R1100_00_UPDATE_PARAMCON_SECTION();

            /*" -929- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-UPDATE-PARAMCON-SECTION */
        private void R1100_00_UPDATE_PARAMCON_SECTION()
        {
            /*" -938- MOVE 'R1100-00-UPDATE-PARAMCON' TO PARAGRAFO */
            _.Move("R1100-00-UPDATE-PARAMCON", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -939- MOVE 'ATUALIZA TABELA DE NSAS' TO COMANDO */
            _.Move("ATUALIZA TABELA DE NSAS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -941- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -942- MOVE SISTEMAS-DATA-MOV-ABERTO TO PARAMCON-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_MOVIMENTO);

            /*" -944- MOVE WSHOST-DATA-PARAMETRO TO PARAMCON-DATA-PROXIMO-DEB */
            _.Move(WSHOST_DATA_PARAMETRO, PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_PROXIMO_DEB);

            /*" -952- PERFORM R1100_00_UPDATE_PARAMCON_DB_UPDATE_1 */

            R1100_00_UPDATE_PARAMCON_DB_UPDATE_1();

            /*" -955- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -956- DISPLAY 'CB0112B - PROBLEMAS UPDATE PARAMCON   ' */
                _.Display($"CB0112B - PROBLEMAS UPDATE PARAMCON   ");

                /*" -957- DISPLAY 'TIPO-MOVTO-CC = ' PARAMCON-TIPO-MOVTO-CC */
                _.Display($"TIPO-MOVTO-CC = {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC}");

                /*" -958- DISPLAY 'COD-PRODUTO   = ' PARAMCON-COD-PRODUTO */
                _.Display($"COD-PRODUTO   = {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO}");

                /*" -959- DISPLAY 'COD-CONVENIO  = ' PARAMCON-COD-CONVENIO */
                _.Display($"COD-CONVENIO  = {PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO}");

                /*" -960- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -962- END-IF */
            }


            /*" -962- . */

        }

        [StopWatch]
        /*" R1100-00-UPDATE-PARAMCON-DB-UPDATE-1 */
        public void R1100_00_UPDATE_PARAMCON_DB_UPDATE_1()
        {
            /*" -952- EXEC SQL UPDATE SEGUROS.PARAM_CONTACEF SET NSAS = :PARAMCON-NSAS , DATA_MOVIMENTO = :PARAMCON-DATA-MOVIMENTO , DATA_PROXIMO_DEB = :PARAMCON-DATA-PROXIMO-DEB WHERE TIPO_MOVTO_CC = :PARAMCON-TIPO-MOVTO-CC AND COD_PRODUTO = :PARAMCON-COD-PRODUTO AND COD_CONVENIO = :PARAMCON-COD-CONVENIO END-EXEC */

            var r1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1 = new R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1()
            {
                PARAMCON_DATA_PROXIMO_DEB = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_PROXIMO_DEB.ToString(),
                PARAMCON_DATA_MOVIMENTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_DATA_MOVIMENTO.ToString(),
                PARAMCON_NSAS = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_NSAS.ToString(),
                PARAMCON_TIPO_MOVTO_CC = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_TIPO_MOVTO_CC.ToString(),
                PARAMCON_COD_CONVENIO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_CONVENIO.ToString(),
                PARAMCON_COD_PRODUTO = PARAMCON.DCLPARAM_CONTACEF.PARAMCON_COD_PRODUTO.ToString(),
            };

            R1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1.Execute(r1100_00_UPDATE_PARAMCON_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-IMPRIME-RELATORIO-SECTION */
        private void R1500_00_IMPRIME_RELATORIO_SECTION()
        {
            /*" -971- MOVE 'R1500-00-IMPRIME-RELATORIO' TO PARAGRAFO */
            _.Move("R1500-00-IMPRIME-RELATORIO", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -972- MOVE 'RELATORIO DE INCONSISTENCIAS' TO COMANDO */
            _.Move("RELATORIO DE INCONSISTENCIAS", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -974- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -975- MOVE MOVDEBCE-NUM-CARTAO TO LD01-CARTAO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO, AUX_RELATORIO.LD01.LD01_CARTAO);

            /*" -976- MOVE PROPOVA-NUM-APOLICE TO LD01-TITULO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AUX_RELATORIO.LD01.LD01_TITULO);

            /*" -977- MOVE MOVDEBCE-NUM-ENDOSSO TO LD01-ENDOSSO */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO, AUX_RELATORIO.LD01.LD01_ENDOSSO);

            /*" -978- MOVE MOVDEBCE-NUM-PARCELA TO LD01-PARCELA */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA, AUX_RELATORIO.LD01.LD01_PARCELA);

            /*" -979- MOVE PROPOVA-NUM-CERTIFICADO TO LD01-NRCERTIF */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, AUX_RELATORIO.LD01.LD01_NRCERTIF);

            /*" -980- MOVE MOVDEBCE-VALOR-DEBITO TO LD01-VALOR */
            _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO, AUX_RELATORIO.LD01.LD01_VALOR);

            /*" -981- MOVE PROPOVA-COD-PRODUTO TO LD01-CODPRODU */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, AUX_RELATORIO.LD01.LD01_CODPRODU);

            /*" -983- MOVE AUX-TRANSACAO TO LD01-CODTRANS */
            _.Move(AREA_DE_WORK.AUX_TRANSACAO, AUX_RELATORIO.LD01.LD01_CODTRANS);

            /*" -984- MOVE WDATA-AA-HOST TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_AA_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -985- MOVE WDATA-MM-HOST TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_MM_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -986- MOVE WDATA-DD-HOST TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.FILLER_7.WDATA_DD_HOST, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -988- MOVE WDATA-CABEC TO LD01-DTVENCTO */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AUX_RELATORIO.LD01.LD01_DTVENCTO);

            /*" -990- WRITE REG-CB0112B FROM LD01 */
            _.Move(AUX_RELATORIO.LD01.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -992- MOVE SPACES TO LD01 */
            _.Move("", AUX_RELATORIO.LD01);

            /*" -992- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CABECALHOS-SECTION */
        private void R2000_00_CABECALHOS_SECTION()
        {
            /*" -1001- MOVE 'R2000-00-CABECALHOS' TO PARAGRAFO */
            _.Move("R2000-00-CABECALHOS", AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1002- MOVE 'CABECALHOS DO RELATORIO' TO COMANDO */
            _.Move("CABECALHOS DO RELATORIO", AREA_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1004- DISPLAY PARAGRAFO */
            _.Display(AREA_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1005- MOVE 1 TO LC01-PAGINA */
            _.Move(1, AUX_RELATORIO.LC01.LC01_PAGINA);

            /*" -1006- WRITE REG-CB0112B FROM LC01 */
            _.Move(AUX_RELATORIO.LC01.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1007- WRITE REG-CB0112B FROM LC02 */
            _.Move(AUX_RELATORIO.LC02.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1008- WRITE REG-CB0112B FROM LC03 */
            _.Move(AUX_RELATORIO.LC03.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1009- WRITE REG-CB0112B FROM LC04 */
            _.Move(AUX_RELATORIO.LC04.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1010- WRITE REG-CB0112B FROM LC05 */
            _.Move(AUX_RELATORIO.LC05.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1011- WRITE REG-CB0112B FROM LC06 */
            _.Move(AUX_RELATORIO.LC06.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1012- WRITE REG-CB0112B FROM LC05 */
            _.Move(AUX_RELATORIO.LC05.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1014- WRITE REG-CB0112B FROM LC07 */
            _.Move(AUX_RELATORIO.LC07.GetMoveValues(), REG_CB0112B);

            RCB0112B.Write(REG_CB0112B.GetMoveValues().ToString());

            /*" -1014- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1023- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_ABEND.WABEND.WSQLCODE);

            /*" -1024- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AREA_ABEND.WABEND.WSQLERRD1);

            /*" -1025- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AREA_ABEND.WABEND.WSQLERRD2);

            /*" -1026- MOVE SQLERRMC TO WSQLERRMC */
            _.Move(DB.SQLERRMC, AREA_ABEND.WSQLERRO.WSQLERRMC);

            /*" -1028- DISPLAY WABEND */
            _.Display(AREA_ABEND.WABEND);

            /*" -1031- CLOSE MOVIMENTO RCB0112B */
            MOVIMENTO.Close();
            RCB0112B.Close();

            /*" -1032- DISPLAY ' ' */
            _.Display($" ");

            /*" -1033- DISPLAY 'CB0112B - FIM COM ERRO     ' . */
            _.Display($"CB0112B - FIM COM ERRO     ");

            /*" -1035- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1035- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1038- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1038- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}