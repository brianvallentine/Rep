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
using Sias.VidaAzul.DB2.VA0967B;

namespace Code
{
    public class VA0967B
    {
        public bool IsCall { get; set; }

        public VA0967B()
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
        /*"      *   PROGRAMA ............... VA0967B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SOLICITACAO ............ CADMUS 22.007                       *      */
        /*"      *   ANALISTA ............... CESAR DALAZUANA                     *      */
        /*"      *   PROGRAMADOR ............ CESAR DALAZUANA (FAST COMPUTER)     *      */
        /*"      *   DATA CODIFICACAO ....... 25/03/2009                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: ACOMPANHAMENTO DE USUARIO NA LIBERACAO               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.01    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - HIST 181.582                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *--------------------------------------                                 */
        #endregion


        #region VARIABLES

        public FileBasis _SAI0967B { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis SAI0967B
        {
            get
            {
                _.Move(REG_VA0967B, _SAI0967B); VarBasis.RedefinePassValue(REG_VA0967B, _SAI0967B, REG_VA0967B); return _SAI0967B;
            }
        }
        /*"01          REG-VA0967B     PIC X(300).*/
        public StringBasis REG_VA0967B { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          W77-DATA-PRE          PIC  X(07)      VALUE ZEROS.*/
        public StringBasis W77_DATA_PRE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
        /*"77          WHOST-DT-FIM          PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DT-HOJE         PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DT-INICIO       PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          W77-DESPREZ-PRODUTO   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_PRODUTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-PRODUVG   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_PRODUVG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-AVISADO   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_AVISADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-SINISMES  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-SEGURVGA  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_SEGURVGA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DESPREZ-CLIENTES  PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_CLIENTES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  AREA-DE-WORK.*/
        public VA0967B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0967B_AREA_DE_WORK();
        public class VA0967B_AREA_DE_WORK : VarBasis
        {
            /*"   05       WFIM-SISTEMA        PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-SINISHIS       PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WFIM-SINISHIS1      PIC  X(01)     VALUE  ' '.*/
            public StringBasis WFIM_SINISHIS1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"   05       WTEM-FONTES         PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-PRODUTO        PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-PRODUVG        PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PRODUVG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WTEM-SINISMES       PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_SINISMES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
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
            /*"   05       WTEM-PAGAMENTO      PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       WS-ERRO-DATA        PIC  X(03)     VALUE  SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05       SIST-DT-MOV-ABERTO  PIC  X(10)     VALUE ZEROS.*/
            public StringBasis SIST_DT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05       AUX-TIME            PIC  X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05       AUX-RESTO           PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESULTADO       PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WPAR-PARAMETROS     PIC  X(17).*/
            public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"   05        FILLER REDEFINES    WPAR-PARAMETROS.*/
            private _REDEF_VA0967B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0967B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0967B_FILLER_0(); _.Move(WPAR_PARAMETROS, _filler_0); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_0, WPAR_PARAMETROS); _filler_0.ValueChanged += () => { _.Move(_filler_0, WPAR_PARAMETROS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WPAR_PARAMETROS); }
            }  //Redefines
            public class _REDEF_VA0967B_FILLER_0 : VarBasis
            {
                /*"     10     WPAR-ROTINA         PIC  X(01).*/
                public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WPAR-INICIO         PIC  X(08).*/
                public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10     WPAR-FIM            PIC  X(08).*/
                public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"   05       WS-DT-INICIO        PIC  X(10).*/

                public _REDEF_VA0967B_FILLER_0()
                {
                    WPAR_ROTINA.ValueChanged += OnValueChanged;
                    WPAR_INICIO.ValueChanged += OnValueChanged;
                    WPAR_FIM.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05        FILLER REDEFINES    WS-DT-INICIO.*/
            private _REDEF_VA0967B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_VA0967B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_VA0967B_FILLER_1(); _.Move(WS_DT_INICIO, _filler_1); VarBasis.RedefinePassValue(WS_DT_INICIO, _filler_1, WS_DT_INICIO); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_DT_INICIO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WS_DT_INICIO); }
            }  //Redefines
            public class _REDEF_VA0967B_FILLER_1 : VarBasis
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

                public _REDEF_VA0967B_FILLER_1()
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
            private _REDEF_VA0967B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_VA0967B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_VA0967B_FILLER_4(); _.Move(WS_DT_FIM, _filler_4); VarBasis.RedefinePassValue(WS_DT_FIM, _filler_4, WS_DT_FIM); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_DT_FIM); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WS_DT_FIM); }
            }  //Redefines
            public class _REDEF_VA0967B_FILLER_4 : VarBasis
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

                public _REDEF_VA0967B_FILLER_4()
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
            private _REDEF_VA0967B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA0967B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA0967B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA0967B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"     10     WS-CRITICA-ANO      PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     WS-CRITICA-MES      PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     WS-CRITICA-DIA      PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05      CAB1.*/

                public _REDEF_VA0967B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VA0967B_CAB1 CAB1 { get; set; } = new VA0967B_CAB1();
            public class VA0967B_CAB1 : VarBasis
            {
                /*"     10    FILLER                PIC  X(11) VALUE 'RELATORIO C'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"RELATORIO C");
                /*"     10    FILLER                PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"     10    FILLER                PIC  X(38) VALUE          'ACOMPANHAMENTO DE USUARIO NA LIBERACAO'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"ACOMPANHAMENTO DE USUARIO NA LIBERACAO");
                /*"     10    FILLER                PIC  X(26) VALUE          ' DO RAMO VIDA             '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @" DO RAMO VIDA             ");
                /*"     10    FILLER                PIC  X(03) VALUE ' ; '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ; ");
                /*"     10    FILLER                PIC  X(21) VALUE          'DATA MOVIMENTO: '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA MOVIMENTO: ");
                /*"     10    CAB1-DATA-ATU         PIC  X(10).*/
                public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"   05      CAB2.*/
            }
            public VA0967B_CAB2 CAB2 { get; set; } = new VA0967B_CAB2();
            public class VA0967B_CAB2 : VarBasis
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
                /*"     10    FILLER                PIC  X(13)           VALUE 'DESCR PRODUTO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"DESCR PRODUTO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(09)           VALUE 'COBERTURA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"COBERTURA");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(16)           VALUE 'DT PRE-LIBERACAO'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"DT PRE-LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(24)           VALUE 'CD USUARIO PRE-LIBERACAO'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "24", "X(24)"), @"CD USUARIO PRE-LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(12)           VALUE 'DT LIBERACAO'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DT LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(20)           VALUE 'CD USUARIO LIBERACAO'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"CD USUARIO LIBERACAO");
                /*"     10    FILLER                PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(164)  VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "164", "X(164)"), @"");
                /*"   05      LD1.*/
            }
            public VA0967B_LD1 LD1 { get; set; } = new VA0967B_LD1();
            public class VA0967B_LD1 : VarBasis
            {
                /*"     10    LD1-NUM-APOL-SINISTRO PIC  9(13).*/
                public IntBasis LD1_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-NOME-RAZAO        PIC  X(40).*/
                public StringBasis LD1_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-CGCCPF-CNPJ       PIC  9(14).*/
                public IntBasis LD1_CGCCPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-DESCR-PRODUTO     PIC  X(40).*/
                public StringBasis LD1_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-COBERTURA         PIC  X(02).*/
                public StringBasis LD1_COBERTURA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-DATA-PRE          PIC  X(07).*/
                public StringBasis LD1_DATA_PRE { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-COD-USUARIO-PRE   PIC  X(08).*/
                public StringBasis LD1_COD_USUARIO_PRE { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10    LD1-TRACO1            PIC  X(03)  VALUE ' - '.*/
                public StringBasis LD1_TRACO1 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"     10    LD1-NOME-USUARIO-PRE  PIC  X(40).*/
                public StringBasis LD1_NOME_USUARIO_PRE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-DATA-LIB          PIC  X(10).*/
                public StringBasis LD1_DATA_LIB { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    LD1-COD-USUARIO-LIB   PIC  X(08).*/
                public StringBasis LD1_COD_USUARIO_LIB { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"     10    LD1-TRACO2            PIC  X(03)  VALUE SPACES.*/
                public StringBasis LD1_TRACO2 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"     10    LD1-NOME-USUARIO-LIB  PIC  X(40).*/
                public StringBasis LD1_NOME_USUARIO_LIB { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    FILLER                PIC  X(93)  VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "93", "X(93)"), @"");
                /*"   05       WABEND.*/
            }
            public VA0967B_WABEND WABEND { get; set; } = new VA0967B_WABEND();
            public class VA0967B_WABEND : VarBasis
            {
                /*"     10     FILLER              PIC  X(010)    VALUE           'VA0967B'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0967B");
                /*"     10     FILLER              PIC  X(026)    VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"     10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"     10     FILLER              PIC  X(013)    VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0967B_C01_SINISHIS C01_SINISHIS { get; set; } = new VA0967B_C01_SINISHIS();
        public VA0967B_SINISHIS1 SINISHIS1 { get; set; } = new VA0967B_SINISHIS1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0967B_AREA_DE_WORK AREA_DE_WORK_P, string SAI0967B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.AREA_DE_WORK = AREA_DE_WORK_P;
                SAI0967B.SetFile(SAI0967B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { AREA_DE_WORK, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -291- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -294- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -297- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -299- PERFORM R0000-00-PRINCIPAL */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -309- MOVE 'R000' TO WNR-EXEC-SQL. */
            _.Move("R000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -311- ACCEPT WPAR-PARAMETROS FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -314- MOVE 'NAO' TO WS-ERRO-DATA. */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -315- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_0.WPAR_ROTINA == "M")
            {

                /*" -318- IF WPAR-INICIO EQUAL '00000000' AND WPAR-FIM EQUAL '00000000' */

                if (AREA_DE_WORK.FILLER_0.WPAR_INICIO == "00000000" && AREA_DE_WORK.FILLER_0.WPAR_FIM == "00000000")
                {

                    /*" -319- DISPLAY '*** NAO HOUVE SOLICITACAO  ' WPAR-PARAMETROS */
                    _.Display($"*** NAO HOUVE SOLICITACAO  {AREA_DE_WORK.WPAR_PARAMETROS}");

                    /*" -320- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -322- END-IF */
                }


                /*" -325- MOVE WPAR-INICIO TO WS-DTH-CRITICA-R */
                _.Move(AREA_DE_WORK.FILLER_0.WPAR_INICIO, AREA_DE_WORK.WS_DTH_CRITICA_R);

                /*" -327- PERFORM R0300-00-CONSISTE-DATA */

                R0300_00_CONSISTE_DATA_SECTION();

                /*" -328- IF WS-ERRO-DATA EQUAL 'NAO' */

                if (AREA_DE_WORK.WS_ERRO_DATA == "NAO")
                {

                    /*" -331- MOVE WPAR-FIM TO WS-DTH-CRITICA-R */
                    _.Move(AREA_DE_WORK.FILLER_0.WPAR_FIM, AREA_DE_WORK.WS_DTH_CRITICA_R);

                    /*" -332- PERFORM R0300-00-CONSISTE-DATA */

                    R0300_00_CONSISTE_DATA_SECTION();

                    /*" -333- END-IF */
                }


                /*" -335- END-IF. */
            }


            /*" -338- IF WPAR-ROTINA EQUAL ( 'M' OR 'D' ) AND WS-ERRO-DATA EQUAL 'NAO' NEXT SENTENCE */

            if (AREA_DE_WORK.FILLER_0.WPAR_ROTINA.In("M", "D") && AREA_DE_WORK.WS_ERRO_DATA == "NAO")
            {

                /*" -339- ELSE */
            }
            else
            {


                /*" -341- DISPLAY '*** PROBLEMAS NOS PARAMETROS INFORMADOS ' WPAR-PARAMETROS */
                _.Display($"*** PROBLEMAS NOS PARAMETROS INFORMADOS {AREA_DE_WORK.WPAR_PARAMETROS}");

                /*" -342- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -344- END-IF. */
            }


            /*" -346- OPEN OUTPUT SAI0967B. */
            SAI0967B.Open(REG_VA0967B);

            /*" -348- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -349- WRITE REG-VA0967B FROM CAB1. */
            _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_VA0967B);

            SAI0967B.Write(REG_VA0967B.GetMoveValues().ToString());

            /*" -351- WRITE REG-VA0967B FROM CAB2. */
            _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0967B);

            SAI0967B.Write(REG_VA0967B.GetMoveValues().ToString());

            /*" -352- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMA.IsEmpty())
            {

                /*" -353- DISPLAY '*** PROBLEMAS NA V1SISTEMA' */
                _.Display($"*** PROBLEMAS NA V1SISTEMA");

                /*" -354- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -355- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -357- END-IF. */
            }


            /*" -358- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_0.WPAR_ROTINA == "M")
            {

                /*" -359- PERFORM R0400-00-MONTA-DATA-PARAMETROS */

                R0400_00_MONTA_DATA_PARAMETROS_SECTION();

                /*" -361- END-IF. */
            }


            /*" -362- DISPLAY '***     PARAMETROS  ***' */
            _.Display($"***     PARAMETROS  ***");

            /*" -363- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
            _.Display($"*** TIPO DE ROTINA   {AREA_DE_WORK.FILLER_0.WPAR_ROTINA}");

            /*" -364- DISPLAY '*** DATA DE INICIO   ' WHOST-DT-INICIO */
            _.Display($"*** DATA DE INICIO   {WHOST_DT_INICIO}");

            /*" -365- DISPLAY '*** DATA DE FIM      ' WHOST-DT-FIM. */
            _.Display($"*** DATA DE FIM      {WHOST_DT_FIM}");

            /*" -366- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -368- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -369- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -370- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -371- DISPLAY '** NAO HA MOVIMENTO PARA O PERIODO ***' */
                _.Display($"** NAO HA MOVIMENTO PARA O PERIODO ***");

                /*" -374- MOVE '** NAO HA MOVIMENTO PARA ESTE DIA  ***' TO CAB2 */
                _.Move("** NAO HA MOVIMENTO PARA ESTE DIA  ***", AREA_DE_WORK.CAB2);

                /*" -375- WRITE REG-VA0967B FROM CAB2 */
                _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0967B);

                SAI0967B.Write(REG_VA0967B.GetMoveValues().ToString());

                /*" -376- PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION();

                /*" -378- END-IF. */
            }


            /*" -379- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS == "S"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

        }

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -387- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -387- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -391- DISPLAY ' ' . */
            _.Display($" ");

            /*" -393- DISPLAY '***VA0967B***.' */
            _.Display($"***VA0967B***.");

            /*" -394- DISPLAY 'TOTAL LIDOS....... ' AC-LIDOS. */
            _.Display($"TOTAL LIDOS....... {AREA_DE_WORK.AC_LIDOS}");

            /*" -395- DISPLAY 'TOTAL DE GRAVADOS. ' AC-GRAVADOS. */
            _.Display($"TOTAL DE GRAVADOS. {AREA_DE_WORK.AC_GRAVADOS}");

            /*" -396- DISPLAY 'DESPREZ SINISMES.. ' W77-DESPREZ-SINISMES */
            _.Display($"DESPREZ SINISMES.. {W77_DESPREZ_SINISMES}");

            /*" -397- DISPLAY 'DESPREZ SEGUVGA... ' W77-DESPREZ-SEGURVGA */
            _.Display($"DESPREZ SEGUVGA... {W77_DESPREZ_SEGURVGA}");

            /*" -398- DISPLAY 'DESPREZ CLIENTES.. ' W77-DESPREZ-CLIENTES */
            _.Display($"DESPREZ CLIENTES.. {W77_DESPREZ_CLIENTES}");

            /*" -399- DISPLAY 'DESPREZ AVISADO... ' W77-DESPREZ-AVISADO */
            _.Display($"DESPREZ AVISADO... {W77_DESPREZ_AVISADO}");

            /*" -401- DISPLAY ' ' . */
            _.Display($" ");

            /*" -403- CLOSE SAI0967B. */
            SAI0967B.Close();

            /*" -404- DISPLAY '*' . */
            _.Display($"*");

            /*" -405- DISPLAY '***VA0967B - TERMINO NORMAL***' . */
            _.Display($"***VA0967B - TERMINO NORMAL***");

            /*" -407- DISPLAY '*' . */
            _.Display($"*");

            /*" -407- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -417- MOVE 'R010' TO WNR-EXEC-SQL. */
            _.Move("R010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -429- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -432- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -433- DISPLAY ' PROBLEMAS NO ACESSO A SISTEMAS' */
                _.Display($" PROBLEMAS NO ACESSO A SISTEMAS");

                /*" -434- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -436- END-IF. */
            }


            /*" -439- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO CAB1-DATA-ATU (7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 7, 4);

            /*" -442- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO CAB1-DATA-ATU (4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 4, 2);

            /*" -445- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO CAB1-DATA-ATU (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 1, 2);

            /*" -449- MOVE '/' TO CAB1-DATA-ATU(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 6, 1);

            /*" -449- MOVE '/' TO CAB1-DATA-ATU(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 3, 1);

            /*" -450- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DT-INICIO WHOST-DT-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WHOST_DT_INICIO, WHOST_DT_FIM);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -429- EXEC SQL SELECT DATA_MOV_ABERTO , CURRENT_DATE INTO :SISTEMAS-DATA-MOV-ABERTO , :WHOST-DT-HOJE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
        /*" R0300-00-CONSISTE-DATA-SECTION */
        private void R0300_00_CONSISTE_DATA_SECTION()
        {
            /*" -463- MOVE 'R030' TO WNR-EXEC-SQL. */
            _.Move("R030", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -465- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -467- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -468- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -469- GO TO R0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;

                /*" -471- END-IF. */
            }


            /*" -474- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -475- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -476- GO TO R0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;

                /*" -478- END-IF */
            }


            /*" -480- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -481- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -482- GO TO R0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;

                /*" -484- END-IF. */
            }


            /*" -487- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -488- IF WS-CRITICA-DIA GREATER 31 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -489- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -490- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -491- END-IF */
                }


                /*" -493- END-IF. */
            }


            /*" -494- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -495- IF WS-CRITICA-DIA GREATER 30 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -496- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -497- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -498- END-IF */
                }


                /*" -500- END-IF. */
            }


            /*" -501- IF WS-CRITICA-MES EQUAL 02 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -504- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                _.Divide(AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, AREA_DE_WORK.AUX_RESULTADO, AREA_DE_WORK.AUX_RESTO);

                /*" -505- IF AUX-RESTO EQUAL ZEROS */

                if (AREA_DE_WORK.AUX_RESTO == 00)
                {

                    /*" -506- IF WS-CRITICA-DIA GREATER 29 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -507- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -508- GO TO R0300-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                        return;

                        /*" -509- END-IF */
                    }


                    /*" -510- ELSE */
                }
                else
                {


                    /*" -511- IF WS-CRITICA-DIA GREATER 28 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -512- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -513- GO TO R0300-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                        return;

                        /*" -514- END-IF */
                    }


                    /*" -515- END-IF */
                }


                /*" -515- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-MONTA-DATA-PARAMETROS-SECTION */
        private void R0400_00_MONTA_DATA_PARAMETROS_SECTION()
        {
            /*" -528- MOVE 'R040' TO WNR-EXEC-SQL. */
            _.Move("R040", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -531- MOVE WPAR-INICIO (1:4) TO WHOST-DT-INICIO (1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(1, 4), WHOST_DT_INICIO, 1, 4);

            /*" -534- MOVE WPAR-INICIO (5:2) TO WHOST-DT-INICIO (6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(5, 2), WHOST_DT_INICIO, 6, 2);

            /*" -537- MOVE WPAR-INICIO (7:2) TO WHOST-DT-INICIO (9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(7, 2), WHOST_DT_INICIO, 9, 2);

            /*" -540- MOVE WPAR-FIM (1:4) TO WHOST-DT-FIM (1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(1, 4), WHOST_DT_FIM, 1, 4);

            /*" -543- MOVE WPAR-FIM (5:2) TO WHOST-DT-FIM (6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(5, 2), WHOST_DT_FIM, 6, 2);

            /*" -546- MOVE WPAR-FIM (7:2) TO WHOST-DT-FIM (9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(7, 2), WHOST_DT_FIM, 9, 2);

            /*" -550- MOVE '-' TO WHOST-DT-FIM(8:1). */
            _.MoveAtPosition("-", WHOST_DT_FIM, 8, 1);

            /*" -550- MOVE '-' TO WHOST-DT-FIM(5:1) */
            _.MoveAtPosition("-", WHOST_DT_FIM, 5, 1);

            /*" -550- MOVE '-' TO WHOST-DT-INICIO(8:1) */
            _.MoveAtPosition("-", WHOST_DT_INICIO, 8, 1);

            /*" -550- MOVE '-' TO WHOST-DT-INICIO(5:1) */
            _.MoveAtPosition("-", WHOST_DT_INICIO, 5, 1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -563- MOVE 'R090' TO WNR-EXEC-SQL. */
            _.Move("R090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -581- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -583- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -586- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -587- DISPLAY 'PROBLEMA NO CURSOR SINISHIS.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS.");

                /*" -588- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -588- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -581- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO WHERE DATA_MOVIMENTO BETWEEN :WHOST-DT-INICIO AND :WHOST-DT-FIM AND COD_OPERACAO IN (1181, 1182, 1183, 1184) AND COD_PRODUTO IN (8201, 9327, 9301, 9311, 9318, 9319, 9320, 9321, 9322, 9325, 9326, 9327, 9701, 9702, 9703, 9704, 9705, 9712, :JVPRD9327, :JVPRD9320, :JVPRD9311, :JVPRD9321, :JVPRD9327) ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            C01_SINISHIS = new VA0967B_C01_SINISHIS(true);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT DISTINCT 
							NUM_APOL_SINISTRO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO 
							WHERE 
							DATA_MOVIMENTO BETWEEN '{WHOST_DT_INICIO}' 
							AND '{WHOST_DT_FIM}' 
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
							'{JVBKINCL.JV_PRODUTOS.JVPRD9327}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9320}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9311}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD9321}'
							, 
							'{JVBKINCL.JV_PRODUTOS.JVPRD9327}') 
							ORDER BY NUM_APOL_SINISTRO";

                return query;
            }
            C01_SINISHIS.GetQueryEvent += GetQuery_C01_SINISHIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R0900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -583- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R1900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -928- EXEC SQL DECLARE SINISHIS1 CURSOR FOR SELECT OCORR_HISTORICO , DATA_MOVIMENTO , COD_USUARIO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */
            SINISHIS1 = new VA0967B_SINISHIS1(true);
            string GetQuery_SINISHIS1()
            {
                var query = @$"SELECT 
							OCORR_HISTORICO
							, 
							DATA_MOVIMENTO
							, 
							COD_USUARIO 
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
            /*" -602- MOVE 'R091' TO WNR-EXEC-SQL. */
            _.Move("R091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -605- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -608- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -609- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -609- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -611- MOVE 'S' TO WFIM-SINISHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -612- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -613- ELSE */
                }
                else
                {


                    /*" -614- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS");

                    /*" -615- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -616- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -617- END-IF */
                }


                /*" -619- END-IF. */
            }


            /*" -621- ADD 1 TO AC-CONTA. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -622- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -623- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -624- ACCEPT AUX-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AUX_TIME);

                /*" -628- DISPLAY 'LIDOS SINISHIS ....: ' AC-LIDOS AUX-TIME SINISHIS-NUM-APOL-SINISTRO */

                $"LIDOS SINISHIS ....: {AREA_DE_WORK.AC_LIDOS}{AREA_DE_WORK.AUX_TIME}{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -628- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -605- EXEC SQL FETCH C01_SINISHIS INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -609- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -641- MOVE 'R100' TO WNR-EXEC-SQL. */
            _.Move("R100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -643- INITIALIZE LD1. */
            _.Initialize(
                AREA_DE_WORK.LD1
            );

            /*" -645- PERFORM R1100-00-SELECT-SINISMES */

            R1100_00_SELECT_SINISMES_SECTION();

            /*" -646- IF WTEM-SINISMES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SINISMES != "SIM")
            {

                /*" -647- ADD 1 TO W77-DESPREZ-SINISMES */
                W77_DESPREZ_SINISMES.Value = W77_DESPREZ_SINISMES + 1;

                /*" -648- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -650- END-IF. */
            }


            /*" -652- PERFORM R1200-00-SELECT-SEGURVGA */

            R1200_00_SELECT_SEGURVGA_SECTION();

            /*" -653- IF WTEM-SEGURVGA NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SEGURVGA != "SIM")
            {

                /*" -654- ADD 1 TO W77-DESPREZ-SEGURVGA */
                W77_DESPREZ_SEGURVGA.Value = W77_DESPREZ_SEGURVGA + 1;

                /*" -655- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -657- END-IF. */
            }


            /*" -659- PERFORM R1300-00-SELECT-CLIENTES */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -660- IF WTEM-CLIENTES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_CLIENTES != "SIM")
            {

                /*" -661- ADD 1 TO W77-DESPREZ-CLIENTES */
                W77_DESPREZ_CLIENTES.Value = W77_DESPREZ_CLIENTES + 1;

                /*" -662- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -664- END-IF. */
            }


            /*" -666- PERFORM R1400-00-SELECT-PRODUTO */

            R1400_00_SELECT_PRODUTO_SECTION();

            /*" -668- PERFORM R1500-00-SELECT-PRODUVG */

            R1500_00_SELECT_PRODUVG_SECTION();

            /*" -669- IF WTEM-PRODUVG NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PRODUVG != "SIM")
            {

                /*" -670- ADD 1 TO W77-DESPREZ-PRODUVG */
                W77_DESPREZ_PRODUVG.Value = W77_DESPREZ_PRODUVG + 1;

                /*" -671- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -673- END-IF. */
            }


            /*" -674- IF PRODUVG-RAMO EQUAL 93 OR 97 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO.In("93", "97"))
            {

                /*" -675- MOVE 'VG' TO LD1-COBERTURA */
                _.Move("VG", AREA_DE_WORK.LD1.LD1_COBERTURA);

                /*" -676- ELSE */
            }
            else
            {


                /*" -677- IF PRODUVG-RAMO EQUAL 82 */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO == 82)
                {

                    /*" -678- MOVE 'AP' TO LD1-COBERTURA */
                    _.Move("AP", AREA_DE_WORK.LD1.LD1_COBERTURA);

                    /*" -679- END-IF */
                }


                /*" -681- END-IF. */
            }


            /*" -684- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD1-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.LD1.LD1_NUM_APOL_SINISTRO);

            /*" -687- MOVE CLIENTES-NOME-RAZAO TO LD1-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.LD1.LD1_NOME_RAZAO);

            /*" -690- MOVE CLIENTES-CGCCPF TO LD1-CGCCPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.LD1.LD1_CGCCPF_CNPJ);

            /*" -693- MOVE PRODUTO-DESCR-PRODUTO TO LD1-DESCR-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.LD1.LD1_DESCR_PRODUTO);

            /*" -696- MOVE 'N' TO WFIM-SINISHIS1 */
            _.Move("N", AREA_DE_WORK.WFIM_SINISHIS1);

            /*" -697- PERFORM R1900-00-DECLARE-CURSOR */

            R1900_00_DECLARE_CURSOR_SECTION();

            /*" -699- PERFORM R1910-00-FETCH-CURSOR */

            R1910_00_FETCH_CURSOR_SECTION();

            /*" -700- IF WFIM-SINISHIS1 EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS1 == "S")
            {

                /*" -701- ADD 1 TO W77-DESPREZ-SINISMES */
                W77_DESPREZ_SINISMES.Value = W77_DESPREZ_SINISMES + 1;

                /*" -703- END-IF. */
            }


            /*" -704- PERFORM R2000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS1 EQUAL 'S' . */

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
            /*" -708- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-SECTION */
        private void R1100_00_SELECT_SINISMES_SECTION()
        {
            /*" -721- MOVE 'R110' TO WNR-EXEC-SQL. */
            _.Move("R110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -723- MOVE 'SIM' TO WTEM-SINISMES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_SINISMES);

            /*" -729- PERFORM R1100_00_SELECT_SINISMES_DB_SELECT_1 */

            R1100_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -733- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -734- MOVE 'NAO' TO WTEM-SINISMES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SINISMES);

                    /*" -735- ELSE */
                }
                else
                {


                    /*" -736- DISPLAY 'PROBLEMAS NA R1100-00-SELECT-SINISMES' */
                    _.Display($"PROBLEMAS NA R1100-00-SELECT-SINISMES");

                    /*" -737- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -738- END-IF */
                }


                /*" -738- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R1100_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -729- EXEC SQL SELECT NUM_CERTIFICADO INTO :SINISMES-NUM-CERTIFICADO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND NUM_CERTIFICADO <> 0 END-EXEC. */

            var r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-SECTION */
        private void R1200_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -751- MOVE 'R120' TO WNR-EXEC-SQL. */
            _.Move("R120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -753- MOVE 'SIM' TO WTEM-SEGURVGA. */
            _.Move("SIM", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -763- PERFORM R1200_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1200_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -766- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -767- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -768- MOVE 'NAO' TO WTEM-SEGURVGA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -769- ELSE */
                }
                else
                {


                    /*" -770- DISPLAY 'PROBLEMAS NA R1200-00-SELECT-SEGURVGA' */
                    _.Display($"PROBLEMAS NA R1200-00-SELECT-SEGURVGA");

                    /*" -771- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -772- END-IF */
                }


                /*" -772- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1200_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -763- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_CLIENTE INTO :SEGURVGA-NUM-APOLICE , :SEGURVGA-COD-SUBGRUPO , :SEGURVGA-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

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
            /*" -785- MOVE 'R130' TO WNR-EXEC-SQL. */
            _.Move("R130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -787- MOVE 'SIM' TO WTEM-CLIENTES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -795- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -798- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -799- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -800- MOVE 'NAO' TO WTEM-CLIENTES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -801- ELSE */
                }
                else
                {


                    /*" -802- DISPLAY 'PROBLEMAS NA R1300-00-SELECT-CLIENTES' */
                    _.Display($"PROBLEMAS NA R1300-00-SELECT-CLIENTES");

                    /*" -803- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -804- END-IF */
                }


                /*" -804- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -795- EXEC SQL SELECT NOME_RAZAO , CGCCPF INTO :CLIENTES-NOME-RAZAO , :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

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
        /*" R1400-00-SELECT-PRODUTO-SECTION */
        private void R1400_00_SELECT_PRODUTO_SECTION()
        {
            /*" -817- MOVE 'R140' TO WNR-EXEC-SQL. */
            _.Move("R140", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -829- PERFORM R1400_00_SELECT_PRODUTO_DB_SELECT_1 */

            R1400_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -832- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -833- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -842- PERFORM R1400_00_SELECT_PRODUTO_DB_SELECT_2 */

                    R1400_00_SELECT_PRODUTO_DB_SELECT_2();

                    /*" -845- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -847- DISPLAY 'PROBLEMA NO ACESSO A APOLICES ' SEGURVGA-NUM-APOLICE */
                        _.Display($"PROBLEMA NO ACESSO A APOLICES {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                        /*" -848- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -850- END-IF */
                    }


                    /*" -861- PERFORM R1400_00_SELECT_PRODUTO_DB_SELECT_3 */

                    R1400_00_SELECT_PRODUTO_DB_SELECT_3();

                    /*" -864- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -865- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -866- MOVE ZEROS TO PRODUTO-COD-PRODUTO */
                            _.Move(0, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

                            /*" -867- MOVE SPACES TO PRODUTO-DESCR-PRODUTO */
                            _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);

                            /*" -868- ELSE */
                        }
                        else
                        {


                            /*" -869- DISPLAY 'PROBLEMAS NA R1400-00-SELECT-PRODUTO' */
                            _.Display($"PROBLEMAS NA R1400-00-SELECT-PRODUTO");

                            /*" -870- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -871- END-IF */
                        }


                        /*" -871- END-IF. */
                    }

                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R1400_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -829- EXEC SQL SELECT COD_PRODUTO , NOME_PRODUTO INTO :PRODUTO-COD-PRODUTO , :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r1400_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R1400_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PRODUTO-DB-SELECT-2 */
        public void R1400_00_SELECT_PRODUTO_DB_SELECT_2()
        {
            /*" -842- EXEC SQL SELECT COD_PRODUTO INTO :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE END-EXEC */

            var r1400_00_SELECT_PRODUTO_DB_SELECT_2_Query1 = new R1400_00_SELECT_PRODUTO_DB_SELECT_2_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PRODUTO_DB_SELECT_2_Query1.Execute(r1400_00_SELECT_PRODUTO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_COD_PRODUTO, APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO);
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-PRODUVG-SECTION */
        private void R1500_00_SELECT_PRODUVG_SECTION()
        {
            /*" -884- MOVE 'R150' TO WNR-EXEC-SQL. */
            _.Move("R150", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -886- MOVE 'SIM' TO WTEM-PRODUVG. */
            _.Move("SIM", AREA_DE_WORK.WTEM_PRODUVG);

            /*" -896- PERFORM R1500_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1500_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -900- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -901- MOVE 'NAO' TO WTEM-PRODUVG */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PRODUVG);

                    /*" -902- ELSE */
                }
                else
                {


                    /*" -903- DISPLAY 'PROBLEMAS NA R1500-00-SELECT-PRODUVG' */
                    _.Display($"PROBLEMAS NA R1500-00-SELECT-PRODUVG");

                    /*" -904- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -905- END-IF */
                }


                /*" -905- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1500_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -896- EXEC SQL SELECT RAMO INTO :PRODUVG-RAMO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_RAMO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO);
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-PRODUTO-DB-SELECT-3 */
        public void R1400_00_SELECT_PRODUTO_DB_SELECT_3()
        {
            /*" -861- EXEC SQL SELECT COD_PRODUTO , DESCR_PRODUTO INTO :PRODUTO-COD-PRODUTO , :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :APOLICES-COD-PRODUTO END-EXEC. */

            var r1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1 = new R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1()
            {
                APOLICES_COD_PRODUTO = APOLICES.DCLAPOLICES.APOLICES_COD_PRODUTO.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1.Execute(r1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(executed_1.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-SECTION */
        private void R1900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -918- MOVE 'R190' TO WNR-EXEC-SQL. */
            _.Move("R190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -928- PERFORM R1900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R1900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -930- PERFORM R1900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R1900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -933- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -934- DISPLAY 'PROBLEMA NO CURSOR SINISHIS1.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS1.");

                /*" -935- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -935- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R1900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -930- EXEC SQL OPEN SINISHIS1 END-EXEC. */

            SINISHIS1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-SECTION */
        private void R1910_00_FETCH_CURSOR_SECTION()
        {
            /*" -948- MOVE 'R191' TO WNR-EXEC-SQL. */
            _.Move("R191", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -953- PERFORM R1910_00_FETCH_CURSOR_DB_FETCH_1 */

            R1910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -956- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -957- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -957- PERFORM R1910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R1910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -959- MOVE 'S' TO WFIM-SINISHIS1 */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS1);

                    /*" -960- GO TO R1910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                    /*" -961- ELSE */
                }
                else
                {


                    /*" -962- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS1' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS1");

                    /*" -963- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -964- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -965- END-IF */
                }


                /*" -967- END-IF. */
            }


            /*" -967- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R1910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -953- EXEC SQL FETCH SINISHIS1 INTO :SINISHIS-OCORR-HISTORICO , :SINISHIS-DATA-MOVIMENTO , :SINISHIS-COD-USUARIO END-EXEC. */

            if (SINISHIS1.Fetch())
            {
                _.Move(SINISHIS1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(SINISHIS1.SINISHIS_DATA_MOVIMENTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO);
                _.Move(SINISHIS1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R1910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -957- EXEC SQL CLOSE SINISHIS1 END-EXEC */

            SINISHIS1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISHIS-SECTION */
        private void R2000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -980- MOVE 'R200' TO WNR-EXEC-SQL. */
            _.Move("R200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -983- MOVE SINISHIS-DATA-MOVIMENTO (1:4) TO W77-DATA-PRE (4:4) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(1, 4), W77_DATA_PRE, 4, 4);

            /*" -986- MOVE W77-DATA-PRE TO LD1-DATA-PRE */
            _.Move(W77_DATA_PRE, AREA_DE_WORK.LD1.LD1_DATA_PRE);

            /*" -989- MOVE SINISHIS-DATA-MOVIMENTO (6:2) TO W77-DATA-PRE (1:2) */
            _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(6, 2), W77_DATA_PRE, 1, 2);

            /*" -992- MOVE '/' TO W77-DATA-PRE (3:1) */
            _.MoveAtPosition("/", W77_DATA_PRE, 3, 1);

            /*" -995- MOVE W77-DATA-PRE TO LD1-DATA-PRE */
            _.Move(W77_DATA_PRE, AREA_DE_WORK.LD1.LD1_DATA_PRE);

            /*" -998- MOVE SINISHIS-COD-USUARIO TO LD1-COD-USUARIO-PRE */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.LD1.LD1_COD_USUARIO_PRE);

            /*" -1001- MOVE ' - ' TO LD1-TRACO1 */
            _.Move(" - ", AREA_DE_WORK.LD1.LD1_TRACO1);

            /*" -1003- PERFORM R2100-00-SELECT-USUARIOS */

            R2100_00_SELECT_USUARIOS_SECTION();

            /*" -1006- MOVE USUARIOS-NOME-USUARIO TO LD1-NOME-USUARIO-PRE */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.LD1.LD1_NOME_USUARIO_PRE);

            /*" -1008- PERFORM R2200-00-SELECT-SINISHIS */

            R2200_00_SELECT_SINISHIS_SECTION();

            /*" -1010- IF WTEM-PAGAMENTO EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PAGAMENTO == "SIM")
            {

                /*" -1013- MOVE SINISHIS-DATA-MOVIMENTO (1:4) TO LD1-DATA-LIB (7:4) */
                _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(1, 4), AREA_DE_WORK.LD1.LD1_DATA_LIB, 7, 4);

                /*" -1016- MOVE SINISHIS-DATA-MOVIMENTO (6:2) TO LD1-DATA-LIB (4:2) */
                _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(6, 2), AREA_DE_WORK.LD1.LD1_DATA_LIB, 4, 2);

                /*" -1019- MOVE SINISHIS-DATA-MOVIMENTO (9:2) TO LD1-DATA-LIB (1:2) */
                _.MoveAtPosition(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Substring(9, 2), AREA_DE_WORK.LD1.LD1_DATA_LIB, 1, 2);

                /*" -1023- MOVE '/' TO LD1-DATA-LIB(6:1) */
                _.MoveAtPosition("/", AREA_DE_WORK.LD1.LD1_DATA_LIB, 6, 1);

                /*" -1023- MOVE '/' TO LD1-DATA-LIB(3:1) */
                _.MoveAtPosition("/", AREA_DE_WORK.LD1.LD1_DATA_LIB, 3, 1);

                /*" -1025- PERFORM R2100-00-SELECT-USUARIOS */

                R2100_00_SELECT_USUARIOS_SECTION();

                /*" -1028- MOVE SINISHIS-COD-USUARIO TO LD1-COD-USUARIO-LIB */
                _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO, AREA_DE_WORK.LD1.LD1_COD_USUARIO_LIB);

                /*" -1031- MOVE ' - ' TO LD1-TRACO2 */
                _.Move(" - ", AREA_DE_WORK.LD1.LD1_TRACO2);

                /*" -1034- MOVE USUARIOS-NOME-USUARIO TO LD1-NOME-USUARIO-LIB */
                _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, AREA_DE_WORK.LD1.LD1_NOME_USUARIO_LIB);

                /*" -1036- ELSE */
            }
            else
            {


                /*" -1041- MOVE SPACES TO LD1-TRACO2 LD1-DATA-LIB LD1-COD-USUARIO-LIB LD1-NOME-USUARIO-LIB */
                _.Move("", AREA_DE_WORK.LD1.LD1_TRACO2, AREA_DE_WORK.LD1.LD1_DATA_LIB, AREA_DE_WORK.LD1.LD1_COD_USUARIO_LIB, AREA_DE_WORK.LD1.LD1_NOME_USUARIO_LIB);

                /*" -1043- END-IF. */
            }


            /*" -1045- WRITE REG-VA0967B FROM LD1. */
            _.Move(AREA_DE_WORK.LD1.GetMoveValues(), REG_VA0967B);

            SAI0967B.Write(REG_VA0967B.GetMoveValues().ToString());

            /*" -1045- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R2000_10_NEXT */

            R2000_10_NEXT();

        }

        [StopWatch]
        /*" R2000-10-NEXT */
        private void R2000_10_NEXT(bool isPerform = false)
        {
            /*" -1049- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-USUARIOS-SECTION */
        private void R2100_00_SELECT_USUARIOS_SECTION()
        {
            /*" -1062- MOVE 'R210' TO WNR-EXEC-SQL. */
            _.Move("R210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1067- PERFORM R2100_00_SELECT_USUARIOS_DB_SELECT_1 */

            R2100_00_SELECT_USUARIOS_DB_SELECT_1();

            /*" -1070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1071- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1072- MOVE SPACES TO USUARIOS-NOME-USUARIO */
                    _.Move("", USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);

                    /*" -1073- ELSE */
                }
                else
                {


                    /*" -1074- DISPLAY 'PROBLEMAS NA R2100-00-SELECT-USUARIOS' */
                    _.Display($"PROBLEMAS NA R2100-00-SELECT-USUARIOS");

                    /*" -1075- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1076- END-IF */
                }


                /*" -1076- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-USUARIOS-DB-SELECT-1 */
        public void R2100_00_SELECT_USUARIOS_DB_SELECT_1()
        {
            /*" -1067- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :SINISHIS-COD-USUARIO END-EXEC. */

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
            /*" -1089- MOVE 'R220' TO WNR-EXEC-SQL. */
            _.Move("R220", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1091- MOVE 'SIM' TO WTEM-PAGAMENTO */
            _.Move("SIM", AREA_DE_WORK.WTEM_PAGAMENTO);

            /*" -1104- PERFORM R2200_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2200_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1107- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1108- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1109- MOVE 'NAO' TO WTEM-PAGAMENTO */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PAGAMENTO);

                    /*" -1110- ELSE */
                }
                else
                {


                    /*" -1111- DISPLAY 'PROBLEMAS NA R2200-00-SELECT-SINIHIS' */
                    _.Display($"PROBLEMAS NA R2200-00-SELECT-SINIHIS");

                    /*" -1112- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1113- END-IF */
                }


                /*" -1113- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2200_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1104- EXEC SQL SELECT COD_USUARIO AS USUARIO_LIBERADOR , DATA_MOVIMENTO AS DATA_LIBERACAO INTO :SINISHIS-COD-USUARIO , :SINISHIS-DATA-MOVIMENTO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO IN (1081,1082,1083,1084,1089) END-EXEC. */

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
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1128- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1130- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1130- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1132- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1136- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1136- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}