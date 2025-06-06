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
using Sias.VidaAzul.DB2.VA0964B;

namespace Code
{
    public class VA0964B
    {
        public bool IsCall { get; set; }

        public VA0964B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------                                    */
        /*"      *                                                                       */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ VA                                  *      */
        /*"      *   PROGRAMA ............... VA0964B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SOLICITACAO ............ SSI - S/N                           *      */
        /*"      *   ANALISTA ............... TERCIO CARVALHO (FAST COMPUTER)     *      */
        /*"      *   PROGRAMADOR ............ CESAR DALAZUANA (FAST COMPUTER)     *      */
        /*"      *   DATA CODIFICACAO ....... JANEIRO  / 2008                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: SINISTROS PRE-LIBERADOS NO DIA                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - HIST 181.602                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 07/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                          PROCURE POR V.02      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  VERSAO 01 - INCLUSAO DE COLUNA NO RELATORIO                   *      */
        /*"      *  DATA DA ALTERACAO - 07/03/2008                                *      */
        /*"      *  ALTERADO POR FAST COMPUTER                                    *      */
        /*"      *  PROCURAR POR - VR01                                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SAI0964B { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAI0964B
        {
            get
            {
                _.Move(REG_VA0964B, _SAI0964B); VarBasis.RedefinePassValue(REG_VA0964B, _SAI0964B, REG_VA0964B); return _SAI0964B;
            }
        }
        /*"01          REG-VA0964B     PIC X(400).*/
        public StringBasis REG_VA0964B { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-DT-INICIO       PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DT-FIM          PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DT-HOJE         PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          W77-VAL-DIFERENCA     PIC S9(13)V99 COMP VALUE +0.*/
        public DoubleBasis W77_VAL_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          W77-VAL-IN-TOTAL      PIC S9(13)V99 COMP VALUE +0.*/
        public DoubleBasis W77_VAL_IN_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          W77-VAL-AVISADO       PIC S9(13)V99 COMP VALUE +0.*/
        public DoubleBasis W77_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77          W77-DESPREZ-SINISMES  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-SEGURVGA  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_SEGURVGA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-CLIENTES  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_CLIENTES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-AVISADO   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_AVISADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DATA-PRE          PIC  X(07)      VALUE ZEROS.*/
        public StringBasis W77_DATA_PRE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
        /*"01  AREA-DE-WORK.*/
        public VA0964B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0964B_AREA_DE_WORK();
        public class VA0964B_AREA_DE_WORK : VarBasis
        {
            /*"   05       SIST-DT-MOV-ABERTO  PIC  X(10)     VALUE ZEROS.*/
            public StringBasis SIST_DT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05       WFIM-SISTEMA        PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-SINISHIS       PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-SINISHIS1      PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SINISHIS1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WTEM-SINISMES       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SINISMES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-PAGAMENTO      PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SINISHIS       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-CLIENTES       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-APOLICES       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_APOLICES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SEGURVGA       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SISTEMAS       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-FONTES         PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WS-ERRO-DATA        PIC  X(03)     VALUE  SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05       AUX-RESULTADO       PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESTO           PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-TIME            PIC  X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WPAR-PARAMETROS     PIC  X(17).*/
            public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"   05        FILLER REDEFINES    WPAR-PARAMETROS.*/
            private _REDEF_VA0964B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0964B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0964B_FILLER_0(); _.Move(WPAR_PARAMETROS, _filler_0); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_0, WPAR_PARAMETROS); _filler_0.ValueChanged += () => { _.Move(_filler_0, WPAR_PARAMETROS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WPAR_PARAMETROS); }
            }  //Redefines
            public class _REDEF_VA0964B_FILLER_0 : VarBasis
            {
                /*"     10     WPAR-ROTINA         PIC  X(01).*/
                public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WPAR-INICIO         PIC  X(08).*/
                public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10     WPAR-FIM            PIC  X(08).*/
                public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"   05       WS-DT-INICIO        PIC  X(10).*/

                public _REDEF_VA0964B_FILLER_0()
                {
                    WPAR_ROTINA.ValueChanged += OnValueChanged;
                    WPAR_INICIO.ValueChanged += OnValueChanged;
                    WPAR_FIM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05        FILLER REDEFINES    WS-DT-INICIO.*/
            private _REDEF_VA0964B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0964B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0964B_FILLER_1(); _.Move(WS_DT_INICIO, _filler_1); VarBasis.RedefinePassValue(WS_DT_INICIO, _filler_1, WS_DT_INICIO); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_DT_INICIO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WS_DT_INICIO); }
            }  //Redefines
            public class _REDEF_VA0964B_FILLER_1 : VarBasis
            {
                /*"     10     WS-ANO-INI          PIC  X(04).*/
                public StringBasis WS_ANO_INI { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-INI          PIC  9(02).*/
                public IntBasis WS_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-INI          PIC  X(02).*/
                public StringBasis WS_DIA_INI { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"   05       WS-DT-FIM           PIC  X(10).*/

                public _REDEF_VA0964B_FILLER_1()
                {
                    WS_ANO_INI.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_MES_INI.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_DIA_INI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05        FILLER REDEFINES    WS-DT-FIM.*/
            private _REDEF_VA0964B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0964B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0964B_FILLER_4(); _.Move(WS_DT_FIM, _filler_4); VarBasis.RedefinePassValue(WS_DT_FIM, _filler_4, WS_DT_FIM); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_DT_FIM); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WS_DT_FIM); }
            }  //Redefines
            public class _REDEF_VA0964B_FILLER_4 : VarBasis
            {
                /*"     10     WS-ANO-FIM          PIC  X(04).*/
                public StringBasis WS_ANO_FIM { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-FIM          PIC  9(02).*/
                public IntBasis WS_MES_FIM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER              PIC  X(01).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-FIM          PIC  X(02).*/
                public StringBasis WS_DIA_FIM { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"   05       WS-DATA-CORRENTE    PIC  X(10).*/

                public _REDEF_VA0964B_FILLER_4()
                {
                    WS_ANO_FIM.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_MES_FIM.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WS_DIA_FIM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DTH-CRITICA      PIC  9(008).*/
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05       WS-DTH-CRITICA-R    REDEFINES   WS-DTH-CRITICA.*/
            private _REDEF_VA0964B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA0964B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA0964B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA0964B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"     10     WS-CRITICA-ANO      PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     WS-CRITICA-MES      PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     WS-CRITICA-DIA      PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05      CAB1.*/

                public _REDEF_VA0964B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA0964B_CAB1 CAB1 { get; set; } = new VA0964B_CAB1();
            public class VA0964B_CAB1 : VarBasis
            {
                /*"     10    FILLER                PIC  X(10) VALUE 'VA0964B'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VA0964B");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(47) VALUE          'SSI S/N  - SINISTROS PRE-LIBERADOS NO DIA PARA '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "47", "X(47)"), @"SSI S/N  - SINISTROS PRE-LIBERADOS NO DIA PARA ");
                /*"     10    FILLER                PIC  X(25) VALUE          ' O RAMO VIDA             '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @" O RAMO VIDA             ");
                /*"     10    FILLER                PIC  X(03) VALUE ' ; '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
                /*"     10    FILLER                PIC  X(21) VALUE           'DATA MOVIMENTO: '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA MOVIMENTO: ");
                /*"     10    CAB1-DATA-ATU         PIC  X(10).*/
                public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"   05      CAB2.*/
            }
            public VA0964B_CAB2 CAB2 { get; set; } = new VA0964B_CAB2();
            public class VA0964B_CAB2 : VarBasis
            {
                /*"     10    FILLER                PIC  X(12)           VALUE 'NUM SINISTRO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(08)           VALUE 'SEGURADO'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(13)           VALUE 'CGCCPF / CNPJ'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"CGCCPF / CNPJ");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(02)           VALUE 'IS'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"IS");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(11)           VALUE 'COD PRODUTO'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"COD PRODUTO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(24)           VALUE 'NM USUARIO PRE-LIBERACAO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"NM USUARIO PRE-LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(16)           VALUE 'DT PRE-LIBERACAO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"DT PRE-LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)           VALUE 'NOME FONTE'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"NOME FONTE");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(14)           VALUE 'VL TOT PRE-LIB'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VL TOT PRE-LIB");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(12)           VALUE 'VL DIFERENCA'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VL DIFERENCA");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(11)           VALUE 'VL OPERACAO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"VL OPERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)           VALUE 'VL AVISADO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VL AVISADO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(13)           VALUE 'DESCR PRODUTO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DESCR PRODUTO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(24)           VALUE 'CD USUARIO PRE-LIBERACAO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"CD USUARIO PRE-LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(12)           VALUE 'DT LIBERACAO'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DT LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(20)           VALUE 'CD USUARIO LIBERACAO'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"CD USUARIO LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(20)           VALUE 'NM USUARIO LIBERACAO'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"NM USUARIO LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(15)           VALUE 'NM BENEFICIARIO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NM BENEFICIARIO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(135)  VALUE  SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "135", "X(135)"), @"");
                /*"   05      SAI.*/
            }
            public VA0964B_SAI SAI { get; set; } = new VA0964B_SAI();
            public class VA0964B_SAI : VarBasis
            {
                /*"     10    SAI-NUM-APOL-SINISTRO PIC  9(13).*/
                public IntBasis SAI_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NOME-RAZAO        PIC  X(40).*/
                public StringBasis SAI_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-CGCCPF-CNPJ       PIC  9(14).*/
                public IntBasis SAI_CGCCPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-IS                PIC  9(04).*/
                public IntBasis SAI_IS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-COD-PRODUTO       PIC  9(04).*/
                public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NOME-USUARIO-PRE  PIC  X(40).*/
                public StringBasis SAI_NOME_USUARIO_PRE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DATA-PRE          PIC  X(07).*/
                public StringBasis SAI_DATA_PRE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NOME-FONTE        PIC  X(40).*/
                public StringBasis SAI_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-VAL-IN-TOTAL      PIC  9999999999999,99.*/
                public DoubleBasis SAI_VAL_IN_TOTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-VAL-DIFERENCA     PIC  9999999999999,99.*/
                public DoubleBasis SAI_VAL_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-VAL-OPER          PIC  9999999999999,99.*/
                public DoubleBasis SAI_VAL_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-VAL-AVISADO       PIC  9999999999999,99.*/
                public DoubleBasis SAI_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DESCR-PRODUTO     PIC  X(40).*/
                public StringBasis SAI_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-COD-USUARIO-PRE   PIC  X(08).*/
                public StringBasis SAI_COD_USUARIO_PRE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DATA-LIB          PIC  X(10).*/
                public StringBasis SAI_DATA_LIB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-COD-USUARIO-LIB   PIC  X(08).*/
                public StringBasis SAI_COD_USUARIO_LIB { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NOME-USUARIO-LIB  PIC  X(40).*/
                public StringBasis SAI_NOME_USUARIO_LIB { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NOME-FAVORECIDO   PIC  X(40).*/
                public StringBasis SAI_NOME_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(10)  VALUE  SPACES.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"   05       WABEND.*/
            }
            public VA0964B_WABEND WABEND { get; set; } = new VA0964B_WABEND();
            public class VA0964B_WABEND : VarBasis
            {
                /*"     10     FILLER              PIC  X(010)    VALUE             'VA0964B'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0964B");
                /*"     10     FILLER              PIC  X(026)    VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"     10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"     10     FILLER              PIC  X(013)    VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0964B_C01_SINISHIS C01_SINISHIS { get; set; } = new VA0964B_C01_SINISHIS();
        public VA0964B_SINISHIS1 SINISHIS1 { get; set; } = new VA0964B_SINISHIS1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SAI0964B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SAI0964B.SetFile(SAI0964B_FILE_NAME_P);

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
            /*" -342- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -345- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -348- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -350- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -357- MOVE 'R000' TO WNR-EXEC-SQL. */
            _.Move("R000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -358- OPEN OUTPUT SAI0964B. */
            SAI0964B.Open(REG_VA0964B);

            /*" -359- WRITE REG-VA0964B FROM CAB1. */
            _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_VA0964B);

            SAI0964B.Write(REG_VA0964B.GetMoveValues().ToString());

            /*" -363- WRITE REG-VA0964B FROM CAB2. */
            _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0964B);

            SAI0964B.Write(REG_VA0964B.GetMoveValues().ToString());

            /*" -365- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -366- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMA.IsEmpty())
            {

                /*" -367- DISPLAY '*** PROBLEMAS NA V1SISTEMA' */
                _.Display($"*** PROBLEMAS NA V1SISTEMA");

                /*" -368- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -369- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -371- END-IF. */
            }


            /*" -372- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -374- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -375- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -376- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -377- DISPLAY '** NAO HA MOVIMENTO PARA O PERIODO ***' */
                _.Display($"** NAO HA MOVIMENTO PARA O PERIODO ***");

                /*" -379- MOVE '** NAO HA MOVIMENTO PARA ESTE DIA  ***' TO CAB2 */
                _.Move("** NAO HA MOVIMENTO PARA ESTE DIA  ***", AREA_DE_WORK.CAB2);

                /*" -380- WRITE REG-VA0964B FROM CAB2 */
                _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0964B);

                SAI0964B.Write(REG_VA0964B.GetMoveValues().ToString());

                /*" -381- PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION();

                /*" -383- END-IF. */
            }


            /*" -384- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS == "S"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

        }

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -390- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -390- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -394- DISPLAY ' ' . */
            _.Display($" ");

            /*" -396- DISPLAY '***VA0964B***.' */
            _.Display($"***VA0964B***.");

            /*" -397- DISPLAY 'TOTAL LIDOS....... ' AC-LIDOS. */
            _.Display($"TOTAL LIDOS....... {AREA_DE_WORK.AC_LIDOS}");

            /*" -398- DISPLAY 'TOTAL DE GRAVADOS. ' AC-GRAVADOS. */
            _.Display($"TOTAL DE GRAVADOS. {AREA_DE_WORK.AC_GRAVADOS}");

            /*" -399- DISPLAY 'DESPREZ SINISMES...' W77-DESPREZ-SINISMES */
            _.Display($"DESPREZ SINISMES...{W77_DESPREZ_SINISMES}");

            /*" -400- DISPLAY 'DESPREZ SEGUVGA... ' W77-DESPREZ-SEGURVGA */
            _.Display($"DESPREZ SEGUVGA... {W77_DESPREZ_SEGURVGA}");

            /*" -401- DISPLAY 'DESPREZ CLIENTES.. ' W77-DESPREZ-CLIENTES */
            _.Display($"DESPREZ CLIENTES.. {W77_DESPREZ_CLIENTES}");

            /*" -402- DISPLAY 'DESPREZ AVISADO... ' W77-DESPREZ-AVISADO */
            _.Display($"DESPREZ AVISADO... {W77_DESPREZ_AVISADO}");

            /*" -404- DISPLAY ' ' . */
            _.Display($" ");

            /*" -406- CLOSE SAI0964B. */
            SAI0964B.Close();

            /*" -407- DISPLAY '*' . */
            _.Display($"*");

            /*" -408- DISPLAY '***VA0964B - TERMINO NORMAL***' . */
            _.Display($"***VA0964B - TERMINO NORMAL***");

            /*" -410- DISPLAY '*' . */
            _.Display($"*");

            /*" -410- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -434- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -438- DISPLAY ' PROBLEMAS NO ACESSO A SISTEMAS' */
                _.Display($" PROBLEMAS NO ACESSO A SISTEMAS");

                /*" -439- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -441- END-IF. */
            }


            /*" -444- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO CAB1-DATA-ATU (7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 7, 4);

            /*" -447- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO CAB1-DATA-ATU (4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 4, 2);

            /*" -450- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO CAB1-DATA-ATU (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 1, 2);

            /*" -452- MOVE '/' TO CAB1-DATA-ATU(6:1). */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 6, 1);

            /*" -452- MOVE '/' TO CAB1-DATA-ATU(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 3, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -434- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT_DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DT-HOJE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DT_HOJE, WHOST_DT_HOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -467- MOVE 'R090' TO WNR-EXEC-SQL. */
            _.Move("R090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -483- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -485- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -489- DISPLAY 'PROBLEMA NO CURSOR SINISHIS.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS.");

                /*" -490- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -490- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -483- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) AND COD_PRODUTO IN (8201, 9327, 9301, 9311, 9318, 9319, 9320, 9321, 9322, 9325, 9326, 9327, 9701, 9702, 9703, 9704, 9705, 9712, :JVPRD9311, :JVPRD9320, :JVPRD9321, :JVPRD9327 ) ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            C01_SINISHIS = new VA0964B_C01_SINISHIS(true);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT DISTINCT 
							NUM_APOL_SINISTRO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO 
							WHERE 
							DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184) 
							AND COD_PRODUTO IN (8201
							, 9327
							, 9301
							, 9311
							, 
							9318
							, 9319
							, 9320
							, 9321
							, 
							9322
							, 9325
							, 9326
							, 9327
							, 
							9701
							, 9702
							, 9703
							, 9704
							, 
							9705
							, 9712
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9311}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9320}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9321}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9327}' ) 
							ORDER BY NUM_APOL_SINISTRO";

                return query;
            }
            C01_SINISHIS.GetQueryEvent += GetQuery_C01_SINISHIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -485- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R1900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -892- EXEC SQL DECLARE SINISHIS1 CURSOR FOR SELECT OCORR_HISTORICO, DATA_MOVIMENTO, VAL_OPERACAO AS VAL_PRE_LIBERADO, COD_USUARIO, NOME_FAVORECIDO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */
            SINISHIS1 = new VA0964B_SINISHIS1(true);
            string GetQuery_SINISHIS1()
            {
                var query = @$"SELECT 
							OCORR_HISTORICO
							, 
							DATA_MOVIMENTO
							, 
							VAL_OPERACAO AS VAL_PRE_LIBERADO
							, 
							COD_USUARIO
							, 
							NOME_FAVORECIDO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO 
							WHERE 
							NUM_APOL_SINISTRO = '{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}' 
							AND COD_OPERACAO IN (1181
							, 1182
							, 1183
							, 1184)";

                return query;
            }
            SINISHIS1.GetQueryEvent += GetQuery_SINISHIS1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-SECTION */
        private void R0910_00_FETCH_CURSOR_SECTION()
        {
            /*" -505- MOVE 'R091' TO WNR-EXEC-SQL. */
            _.Move("R091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -508- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -511- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -512- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -512- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -514- MOVE 'S' TO WFIM-SINISHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -515- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -516- ELSE */
                }
                else
                {


                    /*" -517- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS");

                    /*" -518- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -519- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -520- END-IF */
                }


                /*" -523- END-IF. */
            }


            /*" -525- ADD 1 TO AC-CONTA. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -526- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -527- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -528- ACCEPT AUX-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AUX_TIME);

                /*" -532- DISPLAY 'LIDOS SINISHIS ....: ' AC-LIDOS AUX-TIME SINISHIS-NUM-APOL-SINISTRO */

                $"LIDOS SINISHIS ....: {AREA_DE_WORK.AC_LIDOS}{AREA_DE_WORK.AUX_TIME}{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -532- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -508- EXEC SQL FETCH C01_SINISHIS INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -512- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -547- MOVE 'R100' TO WNR-EXEC-SQL. */
            _.Move("R100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -549- PERFORM R1100-00-SELECT-SINISMES */

            R1100_00_SELECT_SINISMES_SECTION();

            /*" -550- IF WTEM-SINISMES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SINISMES != "SIM")
            {

                /*" -551- ADD 1 TO W77-DESPREZ-SINISMES */
                W77_DESPREZ_SINISMES.Value = W77_DESPREZ_SINISMES + 1;

                /*" -552- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -554- END-IF. */
            }


            /*" -556- PERFORM R1200-00-SELECT-SEGURVGA */

            R1200_00_SELECT_SEGURVGA_SECTION();

            /*" -557- IF WTEM-SEGURVGA NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SEGURVGA != "SIM")
            {

                /*" -558- ADD 1 TO W77-DESPREZ-SEGURVGA */
                W77_DESPREZ_SEGURVGA.Value = W77_DESPREZ_SEGURVGA + 1;

                /*" -560- DISPLAY 'VA0964B - DESPREZADO SEGURVGA ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"VA0964B - DESPREZADO SEGURVGA {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -561- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -563- END-IF. */
            }


            /*" -565- PERFORM R1300-00-SELECT-CLIENTES */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -566- IF WTEM-CLIENTES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_CLIENTES != "SIM")
            {

                /*" -567- ADD 1 TO W77-DESPREZ-CLIENTES */
                W77_DESPREZ_CLIENTES.Value = W77_DESPREZ_CLIENTES + 1;

                /*" -569- DISPLAY 'VA0964B - DESPREZADO CLIENTES ' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"VA0964B - DESPREZADO CLIENTES {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -570- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -572- END-IF. */
            }


            /*" -574- PERFORM R1400-00-SELECT-SINISHIS */

            R1400_00_SELECT_SINISHIS_SECTION();

            /*" -575- IF WTEM-SINISHIS NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SINISHIS != "SIM")
            {

                /*" -576- ADD 1 TO W77-DESPREZ-AVISADO */
                W77_DESPREZ_AVISADO.Value = W77_DESPREZ_AVISADO + 1;

                /*" -578- DISPLAY 'VA0964B - DESPREZADO AVISADO' SINISHIS-NUM-APOL-SINISTRO */
                _.Display($"VA0964B - DESPREZADO AVISADO{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                /*" -579- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -581- END-IF. */
            }


            /*" -583- PERFORM R1450-00-SELECT-FONTES */

            R1450_00_SELECT_FONTES_SECTION();

            /*" -585- PERFORM R1500-00-SELECT-PRODUTO */

            R1500_00_SELECT_PRODUTO_SECTION();

            /*" -588- MOVE SINISHIS-NUM-APOL-SINISTRO TO SAI-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.SAI.SAI_NUM_APOL_SINISTRO);

            /*" -591- MOVE CLIENTES-NOME-RAZAO TO SAI-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.SAI.SAI_NOME_RAZAO);

            /*" -594- MOVE CLIENTES-CGCCPF TO SAI-CGCCPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.SAI.SAI_CGCCPF_CNPJ);

            /*" -598- MOVE SINISHIS-VAL-OPERACAO TO SAI-VAL-AVISADO W77-VAL-AVISADO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.SAI.SAI_VAL_AVISADO, W77_VAL_AVISADO);

            /*" -601- MOVE PRODUTO-COD-PRODUTO TO SAI-COD-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, AREA_DE_WORK.SAI.SAI_COD_PRODUTO);

            /*" -604- MOVE PRODUTO-DESCR-PRODUTO TO SAI-DESCR-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.SAI.SAI_DESCR_PRODUTO);

            /*" -607- MOVE SINISMES-IMP-SEGURADA-IX TO SAI-IS */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX, AREA_DE_WORK.SAI.SAI_IS);

            /*" -610- MOVE FONTES-NOME-FONTE TO SAI-NOME-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, AREA_DE_WORK.SAI.SAI_NOME_FONTE);

            /*" -613- MOVE 'N' TO WFIM-SINISHIS1 */
            _.Move("N", AREA_DE_WORK.WFIM_SINISHIS1);

            /*" -614- PERFORM R1900-00-DECLARE-CURSOR */

            R1900_00_DECLARE_CURSOR_SECTION();

            /*" -615- PERFORM R1910-00-FETCH-CURSOR */

            R1910_00_FETCH_CURSOR_SECTION();

            /*" -616- IF WFIM-SINISHIS1 EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS1 == "S")
            {

                /*" -617- ADD 1 TO W77-DESPREZ-SINISMES */
                W77_DESPREZ_SINISMES.Value = W77_DESPREZ_SINISMES + 1;

                /*" -619- END-IF. */
            }


            /*" -620- PERFORM R2000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS1 EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS1 == "S"))
            {

                R2000_00_PROCESSA_SINISHIS_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -624- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-SECTION */
        private void R1100_00_SELECT_SINISMES_SECTION()
        {
            /*" -639- MOVE 'R110' TO WNR-EXEC-SQL. */
            _.Move("R110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -641- MOVE 'SIM' TO WTEM-SINISMES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_SINISMES);

            /*" -651- PERFORM R1100_00_SELECT_SINISMES_DB_SELECT_1 */

            R1100_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -655- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -656- MOVE 'NAO' TO WTEM-SINISMES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SINISMES);

                    /*" -657- ELSE */
                }
                else
                {


                    /*" -658- DISPLAY 'PROBLEMAS NA R1100-00-SELECT-SINISMES' */
                    _.Display($"PROBLEMAS NA R1100-00-SELECT-SINISMES");

                    /*" -659- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -660- END-IF */
                }


                /*" -660- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R1100_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -651- EXEC SQL SELECT NUM_CERTIFICADO, IMP_SEGURADA_IX, COD_FONTE INTO :SINISMES-NUM-CERTIFICADO, :SINISMES-IMP-SEGURADA-IX, :SINISMES-COD-FONTE FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND NUM_CERTIFICADO <> 0 END-EXEC. */

            var r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(executed_1.SINISMES_IMP_SEGURADA_IX, SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX);
                _.Move(executed_1.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-SECTION */
        private void R1200_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -675- MOVE 'R120' TO WNR-EXEC-SQL. */
            _.Move("R120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -677- MOVE 'SIM' TO WTEM-SEGURVGA. */
            _.Move("SIM", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -687- PERFORM R1200_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1200_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -690- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -691- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -692- MOVE 'NAO' TO WTEM-SEGURVGA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -693- ELSE */
                }
                else
                {


                    /*" -694- DISPLAY 'PROBLEMAS NA R1200-00-SELECT-SEGURVGA' */
                    _.Display($"PROBLEMAS NA R1200-00-SELECT-SEGURVGA");

                    /*" -695- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -696- END-IF */
                }


                /*" -696- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1200_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -687- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_CLIENTE INTO :SEGURVGA-NUM-APOLICE , :SEGURVGA-COD-SUBGRUPO , :SEGURVGA-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-SECTION */
        private void R1300_00_SELECT_CLIENTES_SECTION()
        {
            /*" -711- MOVE 'R130' TO WNR-EXEC-SQL. */
            _.Move("R130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -713- MOVE 'SIM' TO WTEM-CLIENTES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -721- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -724- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -725- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -726- MOVE 'NAO' TO WTEM-CLIENTES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -727- ELSE */
                }
                else
                {


                    /*" -728- DISPLAY 'PROBLEMAS NA R1300-00-SELECT-CLIENTES' */
                    _.Display($"PROBLEMAS NA R1300-00-SELECT-CLIENTES");

                    /*" -729- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -730- END-IF */
                }


                /*" -730- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -721- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

            var r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-SINISHIS-SECTION */
        private void R1400_00_SELECT_SINISHIS_SECTION()
        {
            /*" -745- MOVE 'R140' TO WNR-EXEC-SQL. */
            _.Move("R140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -747- MOVE 'SIM' TO WTEM-SINISHIS */
            _.Move("SIM", AREA_DE_WORK.WTEM_SINISHIS);

            /*" -757- PERFORM R1400_00_SELECT_SINISHIS_DB_SELECT_1 */

            R1400_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -760- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -761- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -762- MOVE 'NAO' TO WTEM-SINISHIS */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SINISHIS);

                    /*" -763- ELSE */
                }
                else
                {


                    /*" -764- DISPLAY 'PROBLEMAS NA R1400-00-SELECT-SINIHIS' */
                    _.Display($"PROBLEMAS NA R1400-00-SELECT-SINIHIS");

                    /*" -765- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -766- END-IF */
                }


                /*" -766- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R1400_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -757- EXEC SQL SELECT VAL_OPERACAO AS VAL_AVISADO INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 END-EXEC. */

            var r1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-SELECT-FONTES-SECTION */
        private void R1450_00_SELECT_FONTES_SECTION()
        {
            /*" -781- MOVE 'R145' TO WNR-EXEC-SQL. */
            _.Move("R145", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -790- PERFORM R1450_00_SELECT_FONTES_DB_SELECT_1 */

            R1450_00_SELECT_FONTES_DB_SELECT_1();

            /*" -793- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -794- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -795- MOVE ' ' TO FONTES-NOME-FONTE */
                    _.Move(" ", FONTES.DCLFONTES.FONTES_NOME_FONTE);

                    /*" -796- ELSE */
                }
                else
                {


                    /*" -797- DISPLAY 'PROBLEMAS NA R1450-00-SELECT-FONTES' */
                    _.Display($"PROBLEMAS NA R1450-00-SELECT-FONTES");

                    /*" -798- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -799- END-IF */
                }


                /*" -799- END-IF. */
            }


        }

        [StopWatch]
        /*" R1450-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1450_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -790- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :SINISMES-COD-FONTE END-EXEC. */

            var r1450_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R1450_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                SINISMES_COD_FONTE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.ToString(),
            };

            var executed_1 = R1450_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r1450_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-SECTION */
        private void R1500_00_SELECT_PRODUTO_SECTION()
        {
            /*" -814- MOVE 'R150' TO WNR-EXEC-SQL. */
            _.Move("R150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -826- PERFORM R1500_00_SELECT_PRODUTO_DB_SELECT_1 */

            R1500_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -829- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -830- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -839- PERFORM R1500_00_SELECT_PRODUTO_DB_SELECT_2 */

                    R1500_00_SELECT_PRODUTO_DB_SELECT_2();

                    /*" -841- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -843- DISPLAY 'PROBLEMA NO ACESSO A APOLICES ' SEGURVGA-NUM-APOLICE */
                        _.Display($"PROBLEMA NO ACESSO A APOLICES {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                        /*" -844- PERFORM R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION();

                        /*" -845- END-IF */
                    }


                    /*" -856- PERFORM R1500_00_SELECT_PRODUTO_DB_SELECT_3 */

                    R1500_00_SELECT_PRODUTO_DB_SELECT_3();

                    /*" -858- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -859- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -860- MOVE ZEROS TO PRODUTO-COD-PRODUTO */
                            _.Move(0, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

                            /*" -861- MOVE SPACES TO PRODUTO-DESCR-PRODUTO */
                            _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);

                            /*" -862- ELSE */
                        }
                        else
                        {


                            /*" -863- DISPLAY 'PROBLEMAS NA R1500-00-SELECT-PRODUTO' */
                            _.Display($"PROBLEMAS NA R1500-00-SELECT-PRODUTO");

                            /*" -864- PERFORM R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION();

                            /*" -865- END-IF */
                        }


                        /*" -865- END-IF. */
                    }

                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R1500_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -826- EXEC SQL SELECT COD_PRODUTO, NOME_PRODUTO INTO :PRODUTO-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-DB-SELECT-2 */
        public void R1500_00_SELECT_PRODUTO_DB_SELECT_2()
        {
            /*" -839- EXEC SQL SELECT COD_PRODUTO INTO :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE END-EXEC */

            var r1500_00_SELECT_PRODUTO_DB_SELECT_2_Query1 = new R1500_00_SELECT_PRODUTO_DB_SELECT_2_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_PRODUTO_DB_SELECT_2_Query1.Execute(r1500_00_SELECT_PRODUTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-SECTION */
        private void R1900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -880- MOVE 'R190' TO WNR-EXEC-SQL. */
            _.Move("R190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -892- PERFORM R1900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R1900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -894- PERFORM R1900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R1900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -897- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -898- DISPLAY 'PROBLEMA NO CURSOR SINISHIS1.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS1.");

                /*" -899- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -899- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R1900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -894- EXEC SQL OPEN SINISHIS1 END-EXEC. */

            SINISHIS1.Open();

        }

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-DB-SELECT-3 */
        public void R1500_00_SELECT_PRODUTO_DB_SELECT_3()
        {
            /*" -856- EXEC SQL SELECT COD_PRODUTO , DESCR_PRODUTO INTO :PRODUTO-COD-PRODUTO , :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :APOLICES-COD-PRODUTO END-EXEC. */

            var r1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1 = new R1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1()
            {
                APOLICES_COD_PRODUTO = APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1.Execute(r1500_00_SELECT_PRODUTO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-SECTION */
        private void R1910_00_FETCH_CURSOR_SECTION()
        {
            /*" -914- MOVE 'R191' TO WNR-EXEC-SQL. */
            _.Move("R191", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -921- PERFORM R1910_00_FETCH_CURSOR_DB_FETCH_1 */

            R1910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -924- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -925- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -925- PERFORM R1910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R1910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -927- MOVE 'S' TO WFIM-SINISHIS1 */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS1);

                    /*" -928- GO TO R1910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                    /*" -929- ELSE */
                }
                else
                {


                    /*" -930- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS1' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS1");

                    /*" -931- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -932- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -933- END-IF */
                }


                /*" -935- END-IF. */
            }


            /*" -935- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R1910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -921- EXEC SQL FETCH SINISHIS1 INTO :SINISHIS-OCORR-HISTORICO, :SINISHIS-DATA-MOVIMENTO, :SINISHIS-VAL-OPERACAO, :SINISHIS-COD-USUARIO, :SINISHIS-NOME-FAVORECIDO END-EXEC. */

            if (SINISHIS1.Fetch())
            {
                _.Move(SINISHIS1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(SINISHIS1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(SINISHIS1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISHIS1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(SINISHIS1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
            }

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R1910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -925- EXEC SQL CLOSE SINISHIS1 END-EXEC */

            SINISHIS1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISHIS-SECTION */
        private void R2000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -950- MOVE 'R200' TO WNR-EXEC-SQL. */
            _.Move("R200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -953- MOVE SINISHIS-DATA-MOVIMENTO (1:4) TO W77-DATA-PRE (4:4) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(1, 4), W77_DATA_PRE, 4, 4);

            /*" -956- MOVE W77-DATA-PRE TO SAI-DATA-PRE */
            _.Move(W77_DATA_PRE, AREA_DE_WORK.SAI.SAI_DATA_PRE);

            /*" -962- MOVE SINISHIS-DATA-MOVIMENTO (6:2) TO W77-DATA-PRE (1:2) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(6, 2), W77_DATA_PRE, 1, 2);

            /*" -966- MOVE '/' TO W77-DATA-PRE (3:1) */
            _.MoveAtPosition("/", W77_DATA_PRE, 3, 1);

            /*" -969- MOVE W77-DATA-PRE TO SAI-DATA-PRE */
            _.Move(W77_DATA_PRE, AREA_DE_WORK.SAI.SAI_DATA_PRE);

            /*" -972- MOVE USUARIOS-NOME-USUARIO TO SAI-NOME-USUARIO-PRE */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.SAI.SAI_NOME_USUARIO_PRE);

            /*" -975- MOVE SINISHIS-COD-USUARIO TO SAI-COD-USUARIO-PRE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.SAI.SAI_COD_USUARIO_PRE);

            /*" -978- MOVE SINISHIS-VAL-OPERACAO TO SAI-VAL-OPER */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.SAI.SAI_VAL_OPER);

            /*" -980- PERFORM R2100-00-SELECT-USUARIOS */

            R2100_00_SELECT_USUARIOS_SECTION();

            /*" -983- MOVE USUARIOS-NOME-USUARIO TO SAI-NOME-USUARIO-PRE */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.SAI.SAI_NOME_USUARIO_PRE);

            /*" -985- PERFORM R2200-00-SELECT-SINISHIS */

            R2200_00_SELECT_SINISHIS_SECTION();

            /*" -989- IF WTEM-PAGAMENTO EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PAGAMENTO == "SIM")
            {

                /*" -992- MOVE SINISHIS-DATA-MOVIMENTO (1:4) TO SAI-DATA-LIB (7:4) */
                _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(1, 4), AREA_DE_WORK.SAI.SAI_DATA_LIB, 7, 4);

                /*" -995- MOVE SINISHIS-DATA-MOVIMENTO (6:2) TO SAI-DATA-LIB (4:2) */
                _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(6, 2), AREA_DE_WORK.SAI.SAI_DATA_LIB, 4, 2);

                /*" -998- MOVE SINISHIS-DATA-MOVIMENTO (9:2) TO SAI-DATA-LIB (1:2) */
                _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(9, 2), AREA_DE_WORK.SAI.SAI_DATA_LIB, 1, 2);

                /*" -1002- MOVE '/' TO SAI-DATA-LIB(6:1) */
                _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DATA_LIB, 6, 1);

                /*" -1002- MOVE '/' TO SAI-DATA-LIB(3:1) */
                _.MoveAtPosition("/", AREA_DE_WORK.SAI.SAI_DATA_LIB, 3, 1);

                /*" -1003- PERFORM R2100-00-SELECT-USUARIOS */

                R2100_00_SELECT_USUARIOS_SECTION();

                /*" -1005- MOVE SINISHIS-COD-USUARIO TO SAI-COD-USUARIO-LIB */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.SAI.SAI_COD_USUARIO_LIB);

                /*" -1007- MOVE USUARIOS-NOME-USUARIO TO SAI-NOME-USUARIO-LIB */
                _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.SAI.SAI_NOME_USUARIO_LIB);

                /*" -1008- ELSE */
            }
            else
            {


                /*" -1012- MOVE SPACES TO SAI-DATA-LIB SAI-COD-USUARIO-LIB SAI-NOME-USUARIO-LIB */
                _.Move("", AREA_DE_WORK.SAI.SAI_DATA_LIB, AREA_DE_WORK.SAI.SAI_COD_USUARIO_LIB, AREA_DE_WORK.SAI.SAI_NOME_USUARIO_LIB);

                /*" -1014- END-IF. */
            }


            /*" -1017- MOVE SINISHIS-NOME-FAVORECIDO TO SAI-NOME-FAVORECIDO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, AREA_DE_WORK.SAI.SAI_NOME_FAVORECIDO);

            /*" -1019- PERFORM R2300-00-SELECT-SINISHIS */

            R2300_00_SELECT_SINISHIS_SECTION();

            /*" -1023- MOVE SINISHIS-VAL-OPERACAO TO SAI-VAL-IN-TOTAL W77-VAL-IN-TOTAL */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.SAI.SAI_VAL_IN_TOTAL, W77_VAL_IN_TOTAL);

            /*" -1026- COMPUTE W77-VAL-DIFERENCA = W77-VAL-IN-TOTAL - W77-VAL-AVISADO */
            W77_VAL_DIFERENCA.Value = W77_VAL_IN_TOTAL - W77_VAL_AVISADO;

            /*" -1030- MOVE W77-VAL-DIFERENCA TO SAI-VAL-DIFERENCA */
            _.Move(W77_VAL_DIFERENCA, AREA_DE_WORK.SAI.SAI_VAL_DIFERENCA);

            /*" -1032- WRITE REG-VA0964B FROM SAI. */
            _.Move(AREA_DE_WORK.SAI.GetMoveValues(), REG_VA0964B);

            SAI0964B.Write(REG_VA0964B.GetMoveValues().ToString());

            /*" -1032- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R2000_10_NEXT */

            R2000_10_NEXT();

        }

        [StopWatch]
        /*" R2000-10-NEXT */
        private void R2000_10_NEXT(bool isPerform = false)
        {
            /*" -1036- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-USUARIOS-SECTION */
        private void R2100_00_SELECT_USUARIOS_SECTION()
        {
            /*" -1051- MOVE 'R210' TO WNR-EXEC-SQL. */
            _.Move("R210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1056- PERFORM R2100_00_SELECT_USUARIOS_DB_SELECT_1 */

            R2100_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -1059- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1060- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1061- MOVE SPACES TO USUARIOS-NOME-USUARIO */
                    _.Move("", USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);

                    /*" -1062- ELSE */
                }
                else
                {


                    /*" -1063- DISPLAY 'PROBLEMAS NA R2100-00-SELECT-USUARIOS' */
                    _.Display($"PROBLEMAS NA R2100-00-SELECT-USUARIOS");

                    /*" -1064- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1065- END-IF */
                }


                /*" -1065- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R2100_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -1056- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SINISHIS-COD-USUARIO END-EXEC. */

            var r2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1 = new R2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1()
            {
                SINISHIS_COD_USUARIO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO.ToString(),
            };

            var executed_1 = R2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-SELECT-SINISHIS-SECTION */
        private void R2200_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1080- MOVE 'R220' TO WNR-EXEC-SQL. */
            _.Move("R220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1082- MOVE 'SIM' TO WTEM-PAGAMENTO */
            _.Move("SIM", AREA_DE_WORK.WTEM_PAGAMENTO);

            /*" -1096- PERFORM R2200_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2200_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1099- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1100- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1101- MOVE 'NAO' TO WTEM-PAGAMENTO */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PAGAMENTO);

                    /*" -1102- ELSE */
                }
                else
                {


                    /*" -1103- DISPLAY 'PROBLEMAS NA R2200-00-SELECT-SINIHIS' */
                    _.Display($"PROBLEMAS NA R2200-00-SELECT-SINIHIS");

                    /*" -1104- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1105- END-IF */
                }


                /*" -1105- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2200_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1096- EXEC SQL SELECT COD_USUARIO AS USUARIO_LIBERADOR, DATA_MOVIMENTO AS DATA_LIBERACAO INTO :SINISHIS-COD-USUARIO, :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO IN (1081,1082,1083, 1084,1089) END-EXEC. */

            var r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
                _.Move(executed_1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-SELECT-SINISHIS-SECTION */
        private void R2300_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1120- MOVE 'R220' TO WNR-EXEC-SQL. */
            _.Move("R220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1122- MOVE 'SIM' TO WTEM-PAGAMENTO */
            _.Move("SIM", AREA_DE_WORK.WTEM_PAGAMENTO);

            /*" -1132- PERFORM R2300_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2300_00_SELECT_SINISHIS_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2300-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2300_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1132- EXEC SQL SELECT SUM (VAL_OPERACAO) AS VAL_TOT_PRE_LIB INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */

            var r2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2300_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1149- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1151- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1151- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1153- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1157- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1157- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}