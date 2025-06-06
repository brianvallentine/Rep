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
using Sias.Bilhetes.DB2.BI0027B;

namespace Code
{
    public class BI0027B
    {
        public bool IsCall { get; set; }

        public BI0027B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------                                    */
        /*"      *                                                                       */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ BI                                  *      */
        /*"      *   PROGRAMA ............... BI0027B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SOLICITACAO ..... DEM-39684 - ALTERACAO NA REGRA DE ACUMULO  *      */
        /*"      *   ANALISTA ........ DANIEL MEDINA GOMIDE - MILLENIUM           *      */
        /*"      *   DATA CODIFICACAO  25/01/2019                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   GERAR UM RELAT�RIO EVENTUAL CONTENDO DADOS DOS CLIENTES QUE  *      */
        /*"      *   TIVERAM BILHETES DECLINADOS SIT = 'T' ATRASO PAGTO > 60 DIAS *      */
        /*"      *   OU REJEITADOS POR ACUMULO DE RISCO SIT = 'R' (LIMITE DE 4)   *      */
        /*"      *   E EFETUARAM PAGAMENTO DO BOLETO NOS ULTIMOS 6 MESES PARA QUE *      */
        /*"      *   SEJA RESSARCIDO A IMPORTANCIA DO CAPITAL INVESTIDO           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *            A  L T E R A C A O                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - DEM 39684                                        *      */
        /*"      *               QUEBRA POR PRODUTO (AMPARO (3701, 8105) OU DEMAIS*      */
        /*"      *                                                                *      */
        /*"      *   EM 27/03/2019 - MILLENIUM DANIEL MEDINA  PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SAI0027B { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis SAI0027B
        {
            get
            {
                _.Move(REG_BI0027B, _SAI0027B); VarBasis.RedefinePassValue(REG_BI0027B, _SAI0027B, REG_BI0027B); return _SAI0027B;
            }
        }
        /*"01          REG-BI0027B     PIC X(200).*/
        public StringBasis REG_BI0027B { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"  77       WHOST-DT-MOV6MON      PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_MOV6MON { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  77       WHOST-DT-FIM          PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  77       WHOST-DT-HOJE         PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"  77       WS-HOST-PRODU         PIC  X(06)      VALUE SPACES.*/
        public StringBasis WS_HOST_PRODU { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
        /*"  77       WS-NULL1              PIC S9(04) COMP VALUE ZEROS.*/
        public IntBasis WS_NULL1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  77       WS-NULL2              PIC S9(04) COMP VALUE ZEROS.*/
        public IntBasis WS_NULL2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  77       WS-NULL3              PIC S9(04) COMP VALUE ZEROS.*/
        public IntBasis WS_NULL3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  77       WS-NULL4              PIC S9(04) COMP VALUE ZEROS.*/
        public IntBasis WS_NULL4 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  77       WS-NULL5              PIC S9(04) COMP VALUE ZEROS.*/
        public IntBasis WS_NULL5 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"  77       WS-NULL6              PIC S9(04) COMP VALUE ZEROS.*/
        public IntBasis WS_NULL6 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  AREA-DE-WORK.*/
        public BI0027B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0027B_AREA_DE_WORK();
        public class BI0027B_AREA_DE_WORK : VarBasis
        {
            /*"   05       SIST-DT-MOV-ABERTO  PIC  X(10)     VALUE  ZEROS.*/
            public StringBasis SIST_DT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05       WFIM-SISTEMA        PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-BILHETES       PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_BILHETES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WTEM-SEGURO         PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SEGURO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-MOVDEBCC       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_MOVDEBCC { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SISTEMAS       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WS-ERRO-DATA        PIC  X(03)     VALUE  SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05       WS-HOUVE-ERRO       PIC  9(01)     VALUE  ZEROS.*/
            public IntBasis WS_HOUVE_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"   05       WS-DES-PRODANT      PIC  X(06)     VALUE  'AMPARO'.*/
            public StringBasis WS_DES_PRODANT { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"AMPARO");
            /*"   05       AUX-RESULTADO       PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESTO           PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-TIME            PIC  X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-LIDOS-R          PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS_R { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-LIDOS-T          PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS_T { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-VAL-E            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_VAL_E { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-VAL-T            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_VAL_T { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-VAL-TOT          PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_VAL_TOT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WS-TIME             PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis WS_TIME { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WS-SQLCODE          PIC  -Z999 VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "-Z999"));
            /*"   05       WS-DT-INICIO        PIC  X(10).*/
            public StringBasis WS_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05        FILLER REDEFINES    WS-DT-INICIO.*/
            private _REDEF_BI0027B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_BI0027B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_BI0027B_FILLER_0(); _.Move(WS_DT_INICIO, _filler_0); VarBasis.RedefinePassValue(WS_DT_INICIO, _filler_0, WS_DT_INICIO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_DT_INICIO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_DT_INICIO); }
            }  //Redefines
            public class _REDEF_BI0027B_FILLER_0 : VarBasis
            {
                /*"     10     WS-ANO-INI          PIC  X(04).*/
                public StringBasis WS_ANO_INI { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-INI          PIC  9(02).*/
                public IntBasis WS_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-INI          PIC  X(02).*/
                public StringBasis WS_DIA_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"   05       WS-DT-FIM           PIC  X(10).*/

                public _REDEF_BI0027B_FILLER_0()
                {
                    WS_ANO_INI.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_MES_INI.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_DIA_INI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05        FILLER REDEFINES    WS-DT-FIM.*/
            private _REDEF_BI0027B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_BI0027B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_BI0027B_FILLER_3(); _.Move(WS_DT_FIM, _filler_3); VarBasis.RedefinePassValue(WS_DT_FIM, _filler_3, WS_DT_FIM); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_DT_FIM); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WS_DT_FIM); }
            }  //Redefines
            public class _REDEF_BI0027B_FILLER_3 : VarBasis
            {
                /*"     10     WS-ANO-FIM          PIC  X(04).*/
                public StringBasis WS_ANO_FIM { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-FIM          PIC  9(02).*/
                public IntBasis WS_MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-FIM          PIC  X(02).*/
                public StringBasis WS_DIA_FIM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"   05       WS-DATA-CORRENTE    PIC  X(10).*/

                public _REDEF_BI0027B_FILLER_3()
                {
                    WS_ANO_FIM.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_MES_FIM.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_DIA_FIM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DTH-CRITICA      PIC  9(008).*/
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05       WS-DTH-CRITICA-R    REDEFINES   WS-DTH-CRITICA.*/
            private _REDEF_BI0027B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_BI0027B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_BI0027B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_BI0027B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"     10     WS-CRITICA-ANO      PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     WS-CRITICA-MES      PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     WS-CRITICA-DIA      PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05      CAB1.*/

                public _REDEF_BI0027B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public BI0027B_CAB1 CAB1 { get; set; } = new BI0027B_CAB1();
            public class BI0027B_CAB1 : VarBasis
            {
                /*"     10    FILLER                PIC  X(07) VALUE 'BI0027B'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BI0027B");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(28) VALUE          'INFORMACOES DE CLIENTES PARA'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "28", "X(28)"), @"INFORMACOES DE CLIENTES PARA");
                /*"     10    FILLER                PIC  X(38) VALUE          ' DEVOLUCAO CAPITAL INVESTIDO - ATRASO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @" DEVOLUCAO CAPITAL INVESTIDO - ATRASO");
                /*"     10    FILLER                PIC  X(35) VALUE          'POR ACUMULO DE RISCO OU DECLINIO -'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"POR ACUMULO DE RISCO OU DECLINIO -");
                /*"     10    CAB1-DATA-INICIO      PIC  X(10).*/
                public StringBasis CAB1_DATA_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(05) VALUE ' ATE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @" ATE ");
                /*"     10    CAB1-DATA-FIM         PIC  X(10).*/
                public StringBasis CAB1_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01) VALUE ' '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"     10    FILLER                PIC  X(12) VALUE           'DT.PROCESS: '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DT.PROCESS: ");
                /*"     10    CAB1-DATA-ATU         PIC  X(10).*/
                public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"   05      CAB2.*/
            }
            public BI0027B_CAB2 CAB2 { get; set; } = new BI0027B_CAB2();
            public class BI0027B_CAB2 : VarBasis
            {
                /*"     10    FILLER                PIC  X(09) VALUE          'PRODUTO: '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PRODUTO: ");
                /*"     10    CAB2-COD-PROD         PIC  X(30).*/
                public StringBasis CAB2_COD_PROD { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"     10    FILLER                PIC  X(03) VALUE          ' - '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"     10    CAB2-NOM-PROD         PIC  X(30).*/
                public StringBasis CAB2_NOM_PROD { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
                /*"   05      CAB3.*/
            }
            public BI0027B_CAB3 CAB3 { get; set; } = new BI0027B_CAB3();
            public class BI0027B_CAB3 : VarBasis
            {
                /*"     10    FILLER                PIC  X(17)           VALUE 'NOME DO CLIENTE '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"NOME DO CLIENTE ");
                /*"     10    CAB3-DES-PROD         PIC  X(23) VALUE           '(PROD.AMPARO)'.*/
                public StringBasis CAB3_DES_PROD { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"(PROD.AMPARO)");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(11)           VALUE 'CPF-CLI'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CPF-CLI");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(11)           VALUE 'BILHETE '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"BILHETE ");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(12)           VALUE 'APOLICE '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"APOLICE ");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(04)           VALUE 'PROD'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"PROD");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(13)           VALUE 'TELEFONE'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"TELEFONE");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)           VALUE 'DT.MOVTO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DT.MOVTO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)           VALUE 'QUIT.BILHE'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"QUIT.BILHE");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)           VALUE 'QUIT.PAGTO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"QUIT.PAGTO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(09)           VALUE 'VALOR'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"VALOR");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(01)           VALUE 'S'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"S");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(09)           VALUE 'NR.RECIBO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NR.RECIBO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(09)           VALUE 'NR.AVISO '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NR.AVISO ");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(09)           VALUE 'NR.PROPOS'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NR.PROPOS");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"   05      SAI.*/
            }
            public BI0027B_SAI SAI { get; set; } = new BI0027B_SAI();
            public class BI0027B_SAI : VarBasis
            {
                /*"     10    SAI-NOM-SEGURADO      PIC  X(40).*/
                public StringBasis SAI_NOM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-CGCCPF            PIC  9(11).*/
                public IntBasis SAI_CGCCPF { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NUM-BILHETE       PIC  9(11).*/
                public IntBasis SAI_NUM_BILHETE { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NUM-APOLICE       PIC  9(12).*/
                public IntBasis SAI_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-COD-PRODUTO       PIC  9(04).*/
                public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DDD               PIC  9(03).*/
                public IntBasis SAI_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"     10    FILLER                PIC  X(01)  VALUE '-'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"     10    SAI-TELEFONE          PIC  Z99999999.*/
                public IntBasis SAI_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "Z99999999."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DTH-MOVTO         PIC  X(10).*/
                public StringBasis SAI_DTH_MOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DTH-QUITACAO      PIC  X(10).*/
                public StringBasis SAI_DTH_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DTH-QUITPAG       PIC  X(10).*/
                public StringBasis SAI_DTH_QUITPAG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-VAL-RCAP          PIC  9(09).*/
                public IntBasis SAI_VAL_RCAP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-SITUACAO          PIC  X(01).*/
                public StringBasis SAI_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NUM-RECIBO        PIC  9(09).*/
                public IntBasis SAI_NUM_RECIBO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NUM-AVISO-CREDITO PIC  9(09).*/
                public IntBasis SAI_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NUM-PROPOSTA      PIC  9(09).*/
                public IntBasis SAI_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"   05    TRAIL.*/
            }
            public BI0027B_TRAIL TRAIL { get; set; } = new BI0027B_TRAIL();
            public class BI0027B_TRAIL : VarBasis
            {
                /*"     10  FILLER                PIC  X(08)  VALUE     'T.RISCO:'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"T.RISCO:");
                /*"     10  TRAIL-LIDOS-E         PIC  9(06).*/
                public IntBasis TRAIL_LIDOS_E { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10  FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER                PIC  X(08)  VALUE     'T.DECLI:'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"T.DECLI:");
                /*"     10  TRAIL-LIDOS-T         PIC  9(06).*/
                public IntBasis TRAIL_LIDOS_T { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10  FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER                PIC  X(08)  VALUE     'T.REGIS:'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"T.REGIS:");
                /*"     10  TRAIL-LIDOS-TOTAL     PIC  9(06).*/
                public IntBasis TRAIL_LIDOS_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10    FILLER              PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER                PIC  X(08)  VALUE     'V.RISCO:'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"V.RISCO:");
                /*"     10  TRAIL-VAL-E           PIC  9(06).*/
                public IntBasis TRAIL_VAL_E { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10    FILLER              PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER                PIC  X(08)  VALUE     'V.DECLI:'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"V.DECLI:");
                /*"     10  TRAIL-VAL-T           PIC  9(06).*/
                public IntBasis TRAIL_VAL_T { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10  FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10  FILLER                PIC  X(08)  VALUE     'T.VALOR:'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"T.VALOR:");
                /*"     10  TRAIL-VAL-TOTAL       PIC  9(06).*/
                public IntBasis TRAIL_VAL_TOTAL { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                /*"     10  FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            }
        }


        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();

        public BI0027B_CURSOR_BILHETES CURSOR_BILHETES { get; set; } = new BI0027B_CURSOR_BILHETES(true);
        string GetQuery_CURSOR_BILHETES()
        {
            var query = @$"SELECT A.NUM_BILHETE
							, A.NUM_APOLICE
							, A.DATA_QUITACAO
							, A.SITUACAO
							, C.NOME_RAZAO
							, C.CGCCPF
							, C.COD_CLIENTE
							, D.DDD
							, D.TELEFONE
							, B.VAL_RCAP
							, B.NUM_RCAP
							, B.NUM_PROPOSTA
							, B.DATA_MOVIMENTO
							, E.NUM_AVISO_CREDITO
							, E.DATA_RCAP
							, F.COD_PRODUTO_SIVPF
							, CASE WHEN F.COD_PRODUTO_SIVPF IN (3701
							, 8105) THEN 'AMPARO' ELSE 'DEMAIS' END PRODUTO
							FROM SEGUROS.BILHETE A
							, SEGUROS.RCAPS B
							, SEGUROS.CLIENTES C
							, SEGUROS.ENDERECOS D
							, SEGUROS.RCAP_COMPLEMENTAR E
							, SEGUROS.CONVERSAO_SICOB F WHERE A.SITUACAO IN ( 'T'
							, 'R' ) AND A.DATA_QUITACAO >= '{WHOST_DT_MOV6MON}' AND A.DATA_QUITACAO <= '{WHOST_DT_FIM}' AND A.FONTE = B.COD_FONTE AND A.NUM_BILHETE = B.NUM_TITULO AND A.NUM_BILHETE = F.NUM_SICOB AND B.COD_OPERACAO = 110 AND B.COD_FONTE = E.COD_FONTE AND B.NUM_RCAP = E.NUM_RCAP AND A.COD_CLIENTE = C.COD_CLIENTE AND C.COD_CLIENTE = D.COD_CLIENTE AND D.OCORR_ENDERECO = A.OCORR_ENDERECO ORDER BY 17
							, 1";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SAI0027B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SAI0027B.SetFile(SAI0027B_FILE_NAME_P);
                InitializeGetQuery();

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

        public void InitializeGetQuery()
        {
            CURSOR_BILHETES.GetQueryEvent += GetQuery_CURSOR_BILHETES;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -376- DISPLAY 'VERSAO V.01: ' FUNCTION WHEN-COMPILED ' - 39684  ' */

            $"VERSAO V.01: FUNCTION{_.WhenCompiled()} - 39684  "
            .Display();

            /*" -378- DISPLAY ' ' */
            _.Display($" ");

            /*" -380- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -381- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMA.IsEmpty())
            {

                /*" -382- DISPLAY '*** PROBLEMAS NA V1SISTEMA' */
                _.Display($"*** PROBLEMAS NA V1SISTEMA");

                /*" -383- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -384- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -386- END-IF */
            }


            /*" -387- DISPLAY '***BI0027B***  -  DATA: ' CAB1-DATA-ATU */
            _.Display($"***BI0027B***  -  DATA: {AREA_DE_WORK.CAB1.CAB1_DATA_ATU}");

            /*" -388- DISPLAY ' ' */
            _.Display($" ");

            /*" -390- DISPLAY 'INFORMACOES DE CLIENTES P/ DEVOLUCAO ' 'DO CAPITAL INVESTIDO ' */
            _.Display($"INFORMACOES DE CLIENTES P/ DEVOLUCAO DO CAPITAL INVESTIDO ");

            /*" -391- DISPLAY ' ' */
            _.Display($" ");

            /*" -392- DISPLAY 'BUSCANDO DADOS.......' */
            _.Display($"BUSCANDO DADOS.......");

            /*" -394- DISPLAY ' ' */
            _.Display($" ");

            /*" -396- PERFORM R0000_00_PRINCIPAL_DB_OPEN_1 */

            R0000_00_PRINCIPAL_DB_OPEN_1();

            /*" -399- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -400- DISPLAY '** PROBLEMAS AO ABRIR CURSOR-BILHETES' */
                _.Display($"** PROBLEMAS AO ABRIR CURSOR-BILHETES");

                /*" -401- GO TO R0025-00-ROT-ERRO */

                R0025_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -403- END-IF. */
            }


            /*" -404- DISPLAY 'PROCESSANDO..........' */
            _.Display($"PROCESSANDO..........");

            /*" -406- DISPLAY ' ' */
            _.Display($" ");

            /*" -409- OPEN OUTPUT SAI0027B. */
            SAI0027B.Open(REG_BI0027B);

            /*" -411- PERFORM R0910-00-FETCH-BILHETES. */

            R0910_00_FETCH_BILHETES_SECTION();

            /*" -412- IF WS-HOUVE-ERRO = 1 */

            if (AREA_DE_WORK.WS_HOUVE_ERRO == 1)
            {

                /*" -413- GO TO R0025-00-ROT-ERRO */

                R0025_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -414- ELSE */
            }
            else
            {


                /*" -415- PERFORM R2000-00-MOVIMENTA-DADOS */

                R2000_00_MOVIMENTA_DADOS_SECTION();

                /*" -417- END-IF */
            }


            /*" -418- IF WFIM-BILHETES = 'S' */

            if (AREA_DE_WORK.WFIM_BILHETES == "S")
            {

                /*" -419- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -420- DISPLAY '** NAO HA MOVIMENTO PARA O PERIODO ***' */
                _.Display($"** NAO HA MOVIMENTO PARA O PERIODO ***");

                /*" -421- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION(); //GOTO
                return;

                /*" -423- END-IF */
            }


            /*" -425- PERFORM R0200-00-MONTA-DATA-SISTEMAS */

            R0200_00_MONTA_DATA_SISTEMAS_SECTION();

            /*" -426- MOVE 'N' TO WFIM-BILHETES */
            _.Move("N", AREA_DE_WORK.WFIM_BILHETES);

            /*" -428- MOVE 0 TO WS-HOUVE-ERRO */
            _.Move(0, AREA_DE_WORK.WS_HOUVE_ERRO);

            /*" -429- WRITE REG-BI0027B FROM CAB1 */
            _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_BI0027B);

            SAI0027B.Write(REG_BI0027B.GetMoveValues().ToString());

            /*" -430- WRITE REG-BI0027B FROM CAB3 */
            _.Move(AREA_DE_WORK.CAB3.GetMoveValues(), REG_BI0027B);

            SAI0027B.Write(REG_BI0027B.GetMoveValues().ToString());

            /*" -433- MOVE 'AMPARO' TO WS-DES-PRODANT */
            _.Move("AMPARO", AREA_DE_WORK.WS_DES_PRODANT);

            /*" -437- PERFORM R1000-00-PROCESSA-BILHETES UNTIL WFIM-BILHETES = 'S' OR WS-HOUVE-ERRO = 1. */

            while (!(AREA_DE_WORK.WFIM_BILHETES == "S" || AREA_DE_WORK.WS_HOUVE_ERRO == 1))
            {

                R1000_00_PROCESSA_BILHETES_SECTION();
            }

            /*" -438- IF WS-HOUVE-ERRO = 1 */

            if (AREA_DE_WORK.WS_HOUVE_ERRO == 1)
            {

                /*" -439- GO TO R0025-00-ROT-ERRO */

                R0025_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -441- ELSE */
            }
            else
            {


                /*" -442- MOVE AC-LIDOS-R TO TRAIL-LIDOS-E */
                _.Move(AREA_DE_WORK.AC_LIDOS_R, AREA_DE_WORK.TRAIL.TRAIL_LIDOS_E);

                /*" -443- MOVE AC-LIDOS-T TO TRAIL-LIDOS-T */
                _.Move(AREA_DE_WORK.AC_LIDOS_T, AREA_DE_WORK.TRAIL.TRAIL_LIDOS_T);

                /*" -444- MOVE AC-LIDOS TO TRAIL-LIDOS-TOTAL */
                _.Move(AREA_DE_WORK.AC_LIDOS, AREA_DE_WORK.TRAIL.TRAIL_LIDOS_TOTAL);

                /*" -445- MOVE AC-VAL-E TO TRAIL-VAL-E */
                _.Move(AREA_DE_WORK.AC_VAL_E, AREA_DE_WORK.TRAIL.TRAIL_VAL_E);

                /*" -446- MOVE AC-VAL-T TO TRAIL-VAL-T */
                _.Move(AREA_DE_WORK.AC_VAL_T, AREA_DE_WORK.TRAIL.TRAIL_VAL_T);

                /*" -447- MOVE AC-VAL-TOT TO TRAIL-VAL-TOTAL */
                _.Move(AREA_DE_WORK.AC_VAL_TOT, AREA_DE_WORK.TRAIL.TRAIL_VAL_TOTAL);

                /*" -448- WRITE REG-BI0027B FROM TRAIL */
                _.Move(AREA_DE_WORK.TRAIL.GetMoveValues(), REG_BI0027B);

                SAI0027B.Write(REG_BI0027B.GetMoveValues().ToString());

                /*" -450- CLOSE SAI0027B */
                SAI0027B.Close();

                /*" -452- PERFORM R0000_00_PRINCIPAL_DB_CLOSE_1 */

                R0000_00_PRINCIPAL_DB_CLOSE_1();

                /*" -455- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION(); //GOTO
                return;

                /*" -455- END-IF. */
            }


        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-OPEN-1 */
        public void R0000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -396- EXEC SQL OPEN CURSOR-BILHETES END-EXEC. */

            CURSOR_BILHETES.Open();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-CLOSE-1 */
        public void R0000_00_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -452- EXEC SQL CLOSE CURSOR-BILHETES END-EXEC */

            CURSOR_BILHETES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_FIM*/

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -464- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -466- DISPLAY ' ' . */
            _.Display($" ");

            /*" -467- DISPLAY '***    FIM PROCESSAMENTO   ***' */
            _.Display($"***    FIM PROCESSAMENTO   ***");

            /*" -469- DISPLAY ' ' . */
            _.Display($" ");

            /*" -470- DISPLAY 'TOTAL LIDOS   ---> ' AC-LIDOS. */
            _.Display($"TOTAL LIDOS   ---> {AREA_DE_WORK.AC_LIDOS}");

            /*" -471- DISPLAY 'TOTAL GRAVADOS---> ' AC-GRAVADOS. */
            _.Display($"TOTAL GRAVADOS---> {AREA_DE_WORK.AC_GRAVADOS}");

            /*" -472- DISPLAY ' ' . */
            _.Display($" ");

            /*" -473- DISPLAY 'LIDOS RISCO   ---> ' TRAIL-LIDOS-E */
            _.Display($"LIDOS RISCO   ---> {AREA_DE_WORK.TRAIL.TRAIL_LIDOS_E}");

            /*" -474- DISPLAY 'LIDOS DECLINIO---> ' TRAIL-LIDOS-T */
            _.Display($"LIDOS DECLINIO---> {AREA_DE_WORK.TRAIL.TRAIL_LIDOS_T}");

            /*" -475- DISPLAY ' ' */
            _.Display($" ");

            /*" -476- DISPLAY 'A PAGAR RISCO ---> ' TRAIL-VAL-E */
            _.Display($"A PAGAR RISCO ---> {AREA_DE_WORK.TRAIL.TRAIL_VAL_E}");

            /*" -477- DISPLAY 'A PAGAR DECLINIO-> ' TRAIL-VAL-T */
            _.Display($"A PAGAR DECLINIO-> {AREA_DE_WORK.TRAIL.TRAIL_VAL_T}");

            /*" -478- DISPLAY 'TOTAL A PAGAR ---> ' TRAIL-VAL-TOTAL */
            _.Display($"TOTAL A PAGAR ---> {AREA_DE_WORK.TRAIL.TRAIL_VAL_TOTAL}");

            /*" -481- DISPLAY ' ' */
            _.Display($" ");

            /*" -482- DISPLAY '*' . */
            _.Display($"*");

            /*" -483- DISPLAY '** BI0027B - TERMINO NORMAL **' . */
            _.Display($"** BI0027B - TERMINO NORMAL **");

            /*" -485- DISPLAY '*' . */
            _.Display($"*");

            /*" -485- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -501- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -506- MOVE '2015-01-01' TO WHOST-DT-MOV6MON */
            _.Move("2015-01-01", WHOST_DT_MOV6MON);

            /*" -507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -508- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                /*" -510- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS) ' 'SQLCODE : ' WS-SQLCODE */

                $"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS) SQLCODE : {AREA_DE_WORK.WS_SQLCODE}"
                .Display();

                /*" -511- MOVE 1 TO WS-HOUVE-ERRO */
                _.Move(1, AREA_DE_WORK.WS_HOUVE_ERRO);

                /*" -512- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -515- END-IF. */
            }


            /*" -516- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -517- MOVE 'S' TO WFIM-SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_SISTEMA);

                /*" -518- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -520- END-IF. */
            }


            /*" -523- MOVE WHOST-DT-HOJE (9:2) TO CAB1-DATA-ATU (1:2). */
            _.MoveAtPosition(WHOST_DT_HOJE.Substring(9, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 1, 2);

            /*" -526- MOVE WHOST-DT-HOJE (6:2) TO CAB1-DATA-ATU (4:2). */
            _.MoveAtPosition(WHOST_DT_HOJE.Substring(6, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 4, 2);

            /*" -529- MOVE WHOST-DT-HOJE (1:4) TO CAB1-DATA-ATU (7:4). */
            _.MoveAtPosition(WHOST_DT_HOJE.Substring(1, 4), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 7, 4);

            /*" -531- MOVE '/' TO CAB1-DATA-ATU(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 6, 1);

            /*" -531- MOVE '/' TO CAB1-DATA-ATU(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -501- EXEC SQL SELECT DATA_MOV_ABERTO, (DATA_MOV_ABERTO - 6 MONTHS), CURRENT DATE INTO :WHOST-DT-FIM, :WHOST-DT-MOV6MON, :WHOST-DT-HOJE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DT_FIM, WHOST_DT_FIM);
                _.Move(executed_1.WHOST_DT_MOV6MON, WHOST_DT_MOV6MON);
                _.Move(executed_1.WHOST_DT_HOJE, WHOST_DT_HOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-MONTA-DATA-SISTEMAS-SECTION */
        private void R0200_00_MONTA_DATA_SISTEMAS_SECTION()
        {
            /*" -544- MOVE WHOST-DT-FIM (9:2) TO CAB1-DATA-FIM (1:2). */
            _.MoveAtPosition(WHOST_DT_FIM.Substring(9, 2), AREA_DE_WORK.CAB1.CAB1_DATA_FIM, 1, 2);

            /*" -547- MOVE WHOST-DT-FIM (6:2) TO CAB1-DATA-FIM (4:2). */
            _.MoveAtPosition(WHOST_DT_FIM.Substring(6, 2), AREA_DE_WORK.CAB1.CAB1_DATA_FIM, 4, 2);

            /*" -549- MOVE WHOST-DT-FIM (1:4) TO CAB1-DATA-FIM (7:4). */
            _.MoveAtPosition(WHOST_DT_FIM.Substring(1, 4), AREA_DE_WORK.CAB1.CAB1_DATA_FIM, 7, 4);

            /*" -554- MOVE '/' TO CAB1-DATA-FIM(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_FIM, 6, 1);

            /*" -554- MOVE '/' TO CAB1-DATA-FIM(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_FIM, 3, 1);

            /*" -557- MOVE WHOST-DT-MOV6MON (9:2) TO CAB1-DATA-INICIO (1:2). */
            _.MoveAtPosition(WHOST_DT_MOV6MON.Substring(9, 2), AREA_DE_WORK.CAB1.CAB1_DATA_INICIO, 1, 2);

            /*" -560- MOVE WHOST-DT-MOV6MON (6:2) TO CAB1-DATA-INICIO (4:2). */
            _.MoveAtPosition(WHOST_DT_MOV6MON.Substring(6, 2), AREA_DE_WORK.CAB1.CAB1_DATA_INICIO, 4, 2);

            /*" -563- MOVE WHOST-DT-MOV6MON (1:4) TO CAB1-DATA-INICIO (7:4). */
            _.MoveAtPosition(WHOST_DT_MOV6MON.Substring(1, 4), AREA_DE_WORK.CAB1.CAB1_DATA_INICIO, 7, 4);

            /*" -567- MOVE '/' TO CAB1-DATA-INICIO(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_INICIO, 6, 1);

            /*" -567- MOVE '/' TO CAB1-DATA-INICIO(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_INICIO, 3, 1);

            /*" -568- DISPLAY '*** PARAMETROS  ***' . */
            _.Display($"*** PARAMETROS  ***");

            /*" -569- DISPLAY '  ' */
            _.Display($"  ");

            /*" -570- DISPLAY '*** DATA INICIAL.....: ' CAB1-DATA-INICIO. */
            _.Display($"*** DATA INICIAL.....: {AREA_DE_WORK.CAB1.CAB1_DATA_INICIO}");

            /*" -571- DISPLAY '*** DATA MOV.ABERTO..: ' CAB1-DATA-FIM. */
            _.Display($"*** DATA MOV.ABERTO..: {AREA_DE_WORK.CAB1.CAB1_DATA_FIM}");

            /*" -572- DISPLAY '  ' */
            _.Display($"  ");

            /*" -572- DISPLAY 'REGISTROS LIDOS....' AC-LIDOS. */
            _.Display($"REGISTROS LIDOS....{AREA_DE_WORK.AC_LIDOS}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CONSISTE-DATA-SECTION */
        private void R0400_00_CONSISTE_DATA_SECTION()
        {
            /*" -582- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -584- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -585- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -586- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -588- END-IF. */
            }


            /*" -591- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -592- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -593- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -595- END-IF. */
            }


            /*" -597- IF WS-CRITICA-DIA = ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -598- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -599- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -601- END-IF. */
            }


            /*" -604- IF WS-CRITICA-MES = 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -605- IF WS-CRITICA-DIA > 31 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -606- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -607- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -608- END-IF */
                }


                /*" -610- END-IF */
            }


            /*" -611- IF WS-CRITICA-MES = 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -612- IF WS-CRITICA-DIA GREATER 30 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -613- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -614- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -615- END-IF */
                }


                /*" -617- END-IF. */
            }


            /*" -618- IF WS-CRITICA-MES = 02 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -622- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                _.Divide(AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, AREA_DE_WORK.AUX_RESULTADO, AREA_DE_WORK.AUX_RESTO);

                /*" -623- IF AUX-RESTO = 0 */

                if (AREA_DE_WORK.AUX_RESTO == 0)
                {

                    /*" -624- IF WS-CRITICA-DIA GREATER 29 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -625- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -626- GO TO R0400-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                        return;

                        /*" -627- END-IF */
                    }


                    /*" -628- ELSE */
                }
                else
                {


                    /*" -629- IF WS-CRITICA-DIA > 28 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -630- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -631- END-IF */
                    }


                    /*" -632- END-IF */
                }


                /*" -632- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-BILHETES-SECTION */
        private void R0910_00_FETCH_BILHETES_SECTION()
        {
            /*" -660- PERFORM R0910_00_FETCH_BILHETES_DB_FETCH_1 */

            R0910_00_FETCH_BILHETES_DB_FETCH_1();

            /*" -663- IF SQLCODE NOT = ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -665- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -666- MOVE 'S' TO WFIM-BILHETES */
                    _.Move("S", AREA_DE_WORK.WFIM_BILHETES);

                    /*" -667- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -668- ELSE */
                }
                else
                {


                    /*" -669- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, AREA_DE_WORK.WS_SQLCODE);

                    /*" -671- DISPLAY ' PROBLEMAS NO FETCH DO CURSOR-BILHETES' 'SQLCODE : ' WS-SQLCODE */

                    $" PROBLEMAS NO FETCH DO CURSOR-BILHETESSQLCODE : {AREA_DE_WORK.WS_SQLCODE}"
                    .Display();

                    /*" -672- DISPLAY ' BILHTETE.NUM_BILHETE ' BILHETE-NUM-BILHETE */
                    _.Display($" BILHTETE.NUM_BILHETE {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE}");

                    /*" -673- MOVE 1 TO WS-HOUVE-ERRO */
                    _.Move(1, AREA_DE_WORK.WS_HOUVE_ERRO);

                    /*" -674- END-IF */
                }


                /*" -676- END-IF. */
            }


            /*" -677- IF AC-CONTA > 1000 */

            if (AREA_DE_WORK.AC_CONTA > 1000)
            {

                /*" -678- MOVE 1 TO AC-CONTA */
                _.Move(1, AREA_DE_WORK.AC_CONTA);

                /*" -679- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -682- DISPLAY 'REGISTROS LIDOS....' AC-LIDOS WS-TIME */

                $"REGISTROS LIDOS....{AREA_DE_WORK.AC_LIDOS}{AREA_DE_WORK.WS_TIME}"
                .Display();

                /*" -684- END-IF. */
            }


            /*" -684- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-BILHETES-DB-FETCH-1 */
        public void R0910_00_FETCH_BILHETES_DB_FETCH_1()
        {
            /*" -660- EXEC SQL FETCH CURSOR-BILHETES INTO :BILHETE-NUM-BILHETE, :BILHETE-NUM-APOLICE, :BILHETE-DATA-QUITACAO, :BILHETE-SITUACAO, :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-COD-CLIENTE, :ENDERECO-DDD, :ENDERECO-TELEFONE, :RCAPS-VAL-RCAP, :RCAPS-NUM-RCAP, :RCAPS-NUM-PROPOSTA, :RCAPS-DATA-MOVIMENTO, :RCAPCOMP-NUM-AVISO-CREDITO, :RCAPCOMP-DATA-RCAP, :CONVERSI-COD-PRODUTO-SIVPF, :WS-HOST-PRODU END-EXEC. */

            if (CURSOR_BILHETES.Fetch())
            {
                _.Move(CURSOR_BILHETES.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
                _.Move(CURSOR_BILHETES.BILHETE_NUM_APOLICE, BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE);
                _.Move(CURSOR_BILHETES.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(CURSOR_BILHETES.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
                _.Move(CURSOR_BILHETES.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(CURSOR_BILHETES.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(CURSOR_BILHETES.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(CURSOR_BILHETES.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(CURSOR_BILHETES.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(CURSOR_BILHETES.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(CURSOR_BILHETES.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(CURSOR_BILHETES.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(CURSOR_BILHETES.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(CURSOR_BILHETES.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(CURSOR_BILHETES.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(CURSOR_BILHETES.CONVERSI_COD_PRODUTO_SIVPF, CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF);
                _.Move(CURSOR_BILHETES.WS_HOST_PRODU, WS_HOST_PRODU);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-BILHETES-SECTION */
        private void R1000_00_PROCESSA_BILHETES_SECTION()
        {
            /*" -694- IF WS-HOUVE-ERRO = 0 */

            if (AREA_DE_WORK.WS_HOUVE_ERRO == 0)
            {

                /*" -695- PERFORM R2000-00-MOVIMENTA-DADOS */

                R2000_00_MOVIMENTA_DADOS_SECTION();

                /*" -697- END-IF */
            }


            /*" -698- WRITE REG-BI0027B FROM SAI */
            _.Move(AREA_DE_WORK.SAI.GetMoveValues(), REG_BI0027B);

            SAI0027B.Write(REG_BI0027B.GetMoveValues().ToString());

            /*" -700- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -700- PERFORM R0910-00-FETCH-BILHETES. */

            R0910_00_FETCH_BILHETES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-MOVIMENTA-DADOS-SECTION */
        private void R2000_00_MOVIMENTA_DADOS_SECTION()
        {
            /*" -710- IF WS-HOST-PRODU NOT = 'AMPARO' AND WS-DES-PRODANT = 'AMPARO' */

            if (WS_HOST_PRODU != "AMPARO" && AREA_DE_WORK.WS_DES_PRODANT == "AMPARO")
            {

                /*" -711- MOVE 'DEMAIS' TO CAB2-NOM-PROD */
                _.Move("DEMAIS", AREA_DE_WORK.CAB2.CAB2_NOM_PROD);

                /*" -712- MOVE AC-LIDOS-R TO TRAIL-LIDOS-E */
                _.Move(AREA_DE_WORK.AC_LIDOS_R, AREA_DE_WORK.TRAIL.TRAIL_LIDOS_E);

                /*" -713- MOVE AC-LIDOS-T TO TRAIL-LIDOS-T */
                _.Move(AREA_DE_WORK.AC_LIDOS_T, AREA_DE_WORK.TRAIL.TRAIL_LIDOS_T);

                /*" -714- MOVE AC-LIDOS TO TRAIL-LIDOS-TOTAL */
                _.Move(AREA_DE_WORK.AC_LIDOS, AREA_DE_WORK.TRAIL.TRAIL_LIDOS_TOTAL);

                /*" -715- MOVE AC-VAL-E TO TRAIL-VAL-E */
                _.Move(AREA_DE_WORK.AC_VAL_E, AREA_DE_WORK.TRAIL.TRAIL_VAL_E);

                /*" -716- MOVE AC-VAL-T TO TRAIL-VAL-T */
                _.Move(AREA_DE_WORK.AC_VAL_T, AREA_DE_WORK.TRAIL.TRAIL_VAL_T);

                /*" -717- MOVE AC-VAL-TOT TO TRAIL-VAL-TOTAL */
                _.Move(AREA_DE_WORK.AC_VAL_TOT, AREA_DE_WORK.TRAIL.TRAIL_VAL_TOTAL);

                /*" -718- WRITE REG-BI0027B FROM TRAIL */
                _.Move(AREA_DE_WORK.TRAIL.GetMoveValues(), REG_BI0027B);

                SAI0027B.Write(REG_BI0027B.GetMoveValues().ToString());

                /*" -724- MOVE ZEROS TO AC-LIDOS-R AC-LIDOS-T AC-LIDOS AC-VAL-E AC-VAL-T AC-VAL-TOT */
                _.Move(0, AREA_DE_WORK.AC_LIDOS_R, AREA_DE_WORK.AC_LIDOS_T, AREA_DE_WORK.AC_LIDOS, AREA_DE_WORK.AC_VAL_E, AREA_DE_WORK.AC_VAL_T, AREA_DE_WORK.AC_VAL_TOT);

                /*" -725- MOVE 'DEMAIS' TO WS-DES-PRODANT */
                _.Move("DEMAIS", AREA_DE_WORK.WS_DES_PRODANT);

                /*" -726- DISPLAY 'NAO SOU AMPARO ' */
                _.Display($"NAO SOU AMPARO ");

                /*" -727- MOVE '(DEMAIS PRODUTOS)' TO CAB3-DES-PROD */
                _.Move("(DEMAIS PRODUTOS)", AREA_DE_WORK.CAB3.CAB3_DES_PROD);

                /*" -728- WRITE REG-BI0027B FROM CAB3 */
                _.Move(AREA_DE_WORK.CAB3.GetMoveValues(), REG_BI0027B);

                SAI0027B.Write(REG_BI0027B.GetMoveValues().ToString());

                /*" -730- END-IF */
            }


            /*" -734- MOVE CLIENTES-NOME-RAZAO TO SAI-NOM-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.SAI.SAI_NOM_SEGURADO);

            /*" -738- MOVE CLIENTES-CGCCPF TO SAI-CGCCPF. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.SAI.SAI_CGCCPF);

            /*" -742- MOVE BILHETE-NUM-BILHETE TO SAI-NUM-BILHETE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE, AREA_DE_WORK.SAI.SAI_NUM_BILHETE);

            /*" -746- MOVE BILHETE-NUM-APOLICE TO SAI-NUM-APOLICE. */
            _.Move(BILHETE.DCLBILHETE.BILHETE_NUM_APOLICE, AREA_DE_WORK.SAI.SAI_NUM_APOLICE);

            /*" -750- MOVE CONVERSI-COD-PRODUTO-SIVPF TO SAI-COD-PRODUTO CAB2-COD-PROD. */
            _.Move(CONVERSI.DCLCONVERSAO_SICOB.CONVERSI_COD_PRODUTO_SIVPF, AREA_DE_WORK.SAI.SAI_COD_PRODUTO, AREA_DE_WORK.CAB2.CAB2_COD_PROD);

            /*" -754- MOVE ENDERECO-DDD TO SAI-DDD. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, AREA_DE_WORK.SAI.SAI_DDD);

            /*" -758- MOVE ENDERECO-TELEFONE TO SAI-TELEFONE. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, AREA_DE_WORK.SAI.SAI_TELEFONE);

            /*" -760- MOVE RCAPS-DATA-MOVIMENTO (1:4) TO SAI-DTH-MOVTO (7:4). */
            _.MoveAtPosition(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO.Substring(1, 4), AREA_DE_WORK.SAI.SAI_DTH_MOVTO, 7, 4);

            /*" -762- MOVE RCAPS-DATA-MOVIMENTO (6:2) TO SAI-DTH-MOVTO (4:2). */
            _.MoveAtPosition(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO.Substring(6, 2), AREA_DE_WORK.SAI.SAI_DTH_MOVTO, 4, 2);

            /*" -764- MOVE RCAPS-DATA-MOVIMENTO (9:2) TO SAI-DTH-MOVTO (1:2). */
            _.MoveAtPosition(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO.Substring(9, 2), AREA_DE_WORK.SAI.SAI_DTH_MOVTO, 1, 2);

            /*" -769- MOVE '/' TO SAI-DTH-MOVTO(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DTH_MOVTO, 6, 1);

            /*" -769- MOVE '/' TO SAI-DTH-MOVTO(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DTH_MOVTO, 3, 1);

            /*" -771- MOVE BILHETE-DATA-QUITACAO (1:4) TO SAI-DTH-QUITACAO (7:4). */
            _.MoveAtPosition(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Substring(1, 4), AREA_DE_WORK.SAI.SAI_DTH_QUITACAO, 7, 4);

            /*" -773- MOVE BILHETE-DATA-QUITACAO (6:2) TO SAI-DTH-QUITACAO (4:2). */
            _.MoveAtPosition(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Substring(6, 2), AREA_DE_WORK.SAI.SAI_DTH_QUITACAO, 4, 2);

            /*" -775- MOVE BILHETE-DATA-QUITACAO (9:2) TO SAI-DTH-QUITACAO (1:2). */
            _.MoveAtPosition(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO.Substring(9, 2), AREA_DE_WORK.SAI.SAI_DTH_QUITACAO, 1, 2);

            /*" -779- MOVE '/' TO SAI-DTH-QUITACAO(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DTH_QUITACAO, 6, 1);

            /*" -779- MOVE '/' TO SAI-DTH-QUITACAO(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DTH_QUITACAO, 3, 1);

            /*" -782- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO SAI-NUM-AVISO-CREDITO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, AREA_DE_WORK.SAI.SAI_NUM_AVISO_CREDITO);

            /*" -785- MOVE BILHETE-SITUACAO TO SAI-SITUACAO */
            _.Move(BILHETE.DCLBILHETE.BILHETE_SITUACAO, AREA_DE_WORK.SAI.SAI_SITUACAO);

            /*" -786- IF BILHETE-SITUACAO = 'R' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "R")
            {

                /*" -787- ADD 1 TO AC-LIDOS-R */
                AREA_DE_WORK.AC_LIDOS_R.Value = AREA_DE_WORK.AC_LIDOS_R + 1;

                /*" -788- ADD RCAPS-VAL-RCAP TO AC-VAL-E AC-VAL-TOT */
                AREA_DE_WORK.AC_VAL_E.Value = AREA_DE_WORK.AC_VAL_E + RCAPS.DCLRCAPS.RCAPS_VAL_RCAP;
                AREA_DE_WORK.AC_VAL_TOT.Value = AREA_DE_WORK.AC_VAL_TOT + RCAPS.DCLRCAPS.RCAPS_VAL_RCAP;

                /*" -789- ELSE */
            }
            else
            {


                /*" -790- ADD 1 TO AC-LIDOS-T */
                AREA_DE_WORK.AC_LIDOS_T.Value = AREA_DE_WORK.AC_LIDOS_T + 1;

                /*" -791- ADD RCAPS-VAL-RCAP TO AC-VAL-T AC-VAL-TOT */
                AREA_DE_WORK.AC_VAL_T.Value = AREA_DE_WORK.AC_VAL_T + RCAPS.DCLRCAPS.RCAPS_VAL_RCAP;
                AREA_DE_WORK.AC_VAL_TOT.Value = AREA_DE_WORK.AC_VAL_TOT + RCAPS.DCLRCAPS.RCAPS_VAL_RCAP;

                /*" -793- END-IF */
            }


            /*" -795- MOVE RCAPCOMP-DATA-RCAP (1:4) TO SAI-DTH-QUITPAG (7:4). */
            _.MoveAtPosition(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Substring(1, 4), AREA_DE_WORK.SAI.SAI_DTH_QUITPAG, 7, 4);

            /*" -797- MOVE RCAPCOMP-DATA-RCAP (6:2) TO SAI-DTH-QUITPAG (4:2). */
            _.MoveAtPosition(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Substring(6, 2), AREA_DE_WORK.SAI.SAI_DTH_QUITPAG, 4, 2);

            /*" -799- MOVE RCAPCOMP-DATA-RCAP (9:2) TO SAI-DTH-QUITPAG (1:2). */
            _.MoveAtPosition(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Substring(9, 2), AREA_DE_WORK.SAI.SAI_DTH_QUITPAG, 1, 2);

            /*" -804- MOVE '/' TO SAI-DTH-QUITPAG(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DTH_QUITPAG, 6, 1);

            /*" -804- MOVE '/' TO SAI-DTH-QUITPAG(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DTH_QUITPAG, 3, 1);

            /*" -808- MOVE RCAPS-VAL-RCAP TO SAI-VAL-RCAP. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, AREA_DE_WORK.SAI.SAI_VAL_RCAP);

            /*" -812- MOVE RCAPS-NUM-RCAP TO SAI-NUM-RECIBO. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_RCAP, AREA_DE_WORK.SAI.SAI_NUM_RECIBO);

            /*" -816- MOVE RCAPCOMP-NUM-AVISO-CREDITO TO SAI-NUM-AVISO-CREDITO. */
            _.Move(RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO, AREA_DE_WORK.SAI.SAI_NUM_AVISO_CREDITO);

            /*" -817- MOVE RCAPS-NUM-PROPOSTA TO SAI-NUM-PROPOSTA. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA, AREA_DE_WORK.SAI.SAI_NUM_PROPOSTA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R0025-00-ROT-ERRO-SECTION */
        private void R0025_00_ROT_ERRO_SECTION()
        {
            /*" -827- DISPLAY ' ' . */
            _.Display($" ");

            /*" -829- DISPLAY '***BI0027B***.' */
            _.Display($"***BI0027B***.");

            /*" -831- DISPLAY 'TOTAL LIDOS   ---> ' AC-LIDOS. */
            _.Display($"TOTAL LIDOS   ---> {AREA_DE_WORK.AC_LIDOS}");

            /*" -832- DISPLAY '*' . */
            _.Display($"*");

            /*" -833- DISPLAY '***BI0027B - TERMINO ANORMAL- VERIFIQUE ***' . */
            _.Display($"***BI0027B - TERMINO ANORMAL- VERIFIQUE ***");

            /*" -835- DISPLAY '*' . */
            _.Display($"*");

            /*" -835- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}