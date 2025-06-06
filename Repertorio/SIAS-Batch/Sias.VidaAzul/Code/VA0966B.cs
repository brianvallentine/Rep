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
using Sias.VidaAzul.DB2.VA0966B;

namespace Code
{
    public class VA0966B
    {
        public bool IsCall { get; set; }

        public VA0966B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   SISTEMA ................ VA                                  *      */
        /*"      *   PROGRAMA ............... VA0966B                             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS      ............ 22.007                              *      */
        /*"      *   PROGRAMADOR ............ ANDERSON DE OLIVEIRA (FAST COMPUTER)*      */
        /*"      *   DATA CODIFICACAO ....... ABRIL    / 2009                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO: ACOMPANHAMENTO SINISTRALIDADE POR PRODUTO.           *      */
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
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _SAI0966B { get; set; } = new FileBasis(new PIC("X", "137", "X(137)"));

        public FileBasis SAI0966B
        {
            get
            {
                _.Move(REG_VA0966B, _SAI0966B); VarBasis.RedefinePassValue(REG_VA0966B, _SAI0966B, REG_VA0966B); return _SAI0966B;
            }
        }
        /*"01          REG-VA0966B     PIC X(137).*/
        public StringBasis REG_VA0966B { get; set; } = new StringBasis(new PIC("X", "137", "X(137)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-DT-HOJE         PIC  X(10)      VALUE SPACES.*/
        public StringBasis WHOST_DT_HOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
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
        /*"77          W77-DESPREZ-PRODUVG   PIC  9(09)      VALUE ZEROS.*/
        public IntBasis W77_DESPREZ_PRODUVG { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77          W77-DATA-PRE          PIC  X(10)      VALUE ZEROS.*/
        public StringBasis W77_DATA_PRE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77          WHOST-DTFINAL         PIC  X(10)      VALUE ZEROS.*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"01  AREA-DE-WORK.*/
        public VA0966B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0966B_AREA_DE_WORK();
        public class VA0966B_AREA_DE_WORK : VarBasis
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
            /*"   05       WTEM-PRODUVG        PIC  X(03)     VALUE  ' '.*/
            public StringBasis WTEM_PRODUVG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" ");
            /*"   05       AUX-TIME            PIC  X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"   05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05        WPAR-PARAMETROS     PIC  X(17).*/
            public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"   05         FILLER REDEFINES    WPAR-PARAMETROS.*/
            private _REDEF_VA0966B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0966B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0966B_FILLER_0(); _.Move(WPAR_PARAMETROS, _filler_0); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_0, WPAR_PARAMETROS); _filler_0.ValueChanged += () => { _.Move(_filler_0, WPAR_PARAMETROS); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WPAR_PARAMETROS); }
            }  //Redefines
            public class _REDEF_VA0966B_FILLER_0 : VarBasis
            {
                /*"      10     WPAR-ROTINA         PIC  X(01).*/
                public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10     WPAR-INICIO         PIC  X(08).*/
                public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10     WPAR-FIM            PIC  X(08).*/
                public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"   05       AUX-RESULTADO      PIC  9(09)   VALUE   ZEROS.*/

                public _REDEF_VA0966B_FILLER_0()
                {
                    WPAR_ROTINA.ValueChanged += OnValueChanged;
                    WPAR_INICIO.ValueChanged += OnValueChanged;
                    WPAR_FIM.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESTO          PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       WS-ERRO-DATA       PIC  X(003)  VALUE   SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05       WS-DTH-CRITICA     PIC  9(008).*/
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05       WS-DTH-CRITICA-R   REDEFINES    WS-DTH-CRITICA.*/
            private _REDEF_VA0966B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA0966B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA0966B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA0966B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"     10     WS-CRITICA-ANO     PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     WS-CRITICA-MES     PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     WS-CRITICA-DIA     PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05       WS-LIDOS           PIC 9(008)   VALUE   ZEROS.*/

                public _REDEF_VA0966B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05       WS-GRAVA-ARQ1      PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_ARQ1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05       WS-GRAVA-DES       PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_DES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"   05       WS-DATA-ACCEPT.*/
            public VA0966B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new VA0966B_WS_DATA_ACCEPT();
            public class VA0966B_WS_DATA_ACCEPT : VarBasis
            {
                /*"     10     WS-ANO-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-MES-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-DIA-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-HORA-ACCEPT.*/
            }
            public VA0966B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new VA0966B_WS_HORA_ACCEPT();
            public class VA0966B_WS_HORA_ACCEPT : VarBasis
            {
                /*"     10     WS-HOR-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-MIN-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     WS-SEG-ACCEPT      PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-DATA-CURR.*/
            }
            public VA0966B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new VA0966B_WS_DATA_CURR();
            public class VA0966B_WS_DATA_CURR : VarBasis
            {
                /*"     10     WS-DIA-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER             PIC  X(001)  VALUE   '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-MES-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER             PIC  X(001)  VALUE   '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-ANO-CURR        PIC  9(004)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"   05       WS-HORA-CURR.*/
            }
            public VA0966B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new VA0966B_WS_HORA_CURR();
            public class VA0966B_WS_HORA_CURR : VarBasis
            {
                /*"     10     WS-HOR-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER             PIC  X(001)  VALUE   ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10     WS-MIN-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER             PIC  X(001)  VALUE   ':'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"     10     WS-SEG-CURR        PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WHOST-DATA-REF     PIC  X(010)  VALUE   SPACES.*/
            }
            public StringBasis WHOST_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05       WHOST-COD-PRODUTO  PIC S9(004)  VALUE  +0 COMP.*/
            public IntBasis WHOST_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WHOST-DTH-INI      PIC  X(010).*/
            public StringBasis WHOST_DTH_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05       WHOST-DTH-FIM      PIC  X(010).*/
            public StringBasis WHOST_DTH_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05       WHOST-DTCURRENT    PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05       LD00-11.*/
            public VA0966B_LD00_11 LD00_11 { get; set; } = new VA0966B_LD00_11();
            public class VA0966B_LD00_11 : VarBasis
            {
                /*"     10     FILLER             PIC X(09)   VALUE            'PERIODO:'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PERIODO:");
                /*"     10     LD00-11-DATAINI    PIC X(10).*/
                public StringBasis LD00_11_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10     LD00-11-A          PIC X(05)   VALUE   SPACES.*/
                public StringBasis LD00_11_A { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"     10     LD00-11-DATAFIN    PIC X(10)   VALUE   SPACES.*/
                public StringBasis LD00_11_DATAFIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"     10     FILLER             PIC X(01)   VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"     10     FILLER             PIC X(01)   VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"   05       DATA-SQL.*/
            }
            public VA0966B_DATA_SQL DATA_SQL { get; set; } = new VA0966B_DATA_SQL();
            public class VA0966B_DATA_SQL : VarBasis
            {
                /*"     10     ANO-SQL            PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     FILLER             PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     MES-SQL            PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER             PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     FILLER             PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     DIA-SQL            PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05       CAB1.*/
            }
            public VA0966B_CAB1 CAB1 { get; set; } = new VA0966B_CAB1();
            public class VA0966B_CAB1 : VarBasis
            {
                /*"     10     FILLER              PIC  X(11) VALUE 'RELATORIO B'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"RELATORIO B");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(41) VALUE           'ACOMPANHAMENTO SINISTRALIDADE POR PRODUTO'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "41", "X(41)"), @"ACOMPANHAMENTO SINISTRALIDADE POR PRODUTO");
                /*"     10     FILLER              PIC  X(29) VALUE           ' DO RAMO VIDA                '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @" DO RAMO VIDA                ");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(21) VALUE           'DATA MOVIMENTO: '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA MOVIMENTO: ");
                /*"     10     CAB1-DATA-ATU       PIC  X(10).*/
                public StringBasis CAB1_DATA_ATU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"   05       CAB2.*/
            }
            public VA0966B_CAB2 CAB2 { get; set; } = new VA0966B_CAB2();
            public class VA0966B_CAB2 : VarBasis
            {
                /*"     10     FILLER              PIC  X(12)            VALUE 'NUM SINISTRO'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(08)            VALUE 'SEGURADO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(11)            VALUE 'CGCCPF/CNPJ'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CGCCPF/CNPJ");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(08)            VALUE 'FONTE FL'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"FONTE FL");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(12)            VALUE 'COD PRODUTO/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"COD PRODUTO/");
                /*"     10     FILLER              PIC  X(09)            VALUE 'DESCRICAO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DESCRICAO");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(09)            VALUE 'COBERTURA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"COBERTURA");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(12)            VALUE 'IMP SEGURADA'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"IMP SEGURADA");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10     FILLER              PIC  X(11)            VALUE 'VL OPERACAO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"VL OPERACAO");
                /*"     10     FILLER              PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"   05       SAI.*/
            }
            public VA0966B_SAI SAI { get; set; } = new VA0966B_SAI();
            public class VA0966B_SAI : VarBasis
            {
                /*"     10    SAI-NUM-APOL-SINISTRO PIC  9(13).*/
                public IntBasis SAI_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-SEGURADO          PIC  X(40).*/
                public StringBasis SAI_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-CGCCPF-CNPJ       PIC  9(13).*/
                public IntBasis SAI_CGCCPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-NOME-FONTE        PIC  X(10).*/
                public StringBasis SAI_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-COD-PRODUTO       PIC  9(04).*/
                public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-DESCR-PRODUTO     PIC  X(13).*/
                public StringBasis SAI_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "13", "X(13)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-COBERTURA         PIC  X(02).*/
                public StringBasis SAI_COBERTURA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-IS                PIC  9(12).*/
                public IntBasis SAI_IS { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"     10    SAI-VL-OPERACAO       PIC  9(11).*/
                public IntBasis SAI_VL_OPERACAO { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"     10    FILLER                PIC  X(01)  VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"   05       WABEND.*/
            }
            public VA0966B_WABEND WABEND { get; set; } = new VA0966B_WABEND();
            public class VA0966B_WABEND : VarBasis
            {
                /*"     10     FILLER              PIC  X(010)    VALUE             'VA0966B'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0966B");
                /*"     10     FILLER              PIC  X(026)    VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"     10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"     10     FILLER              PIC  X(013)    VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"     10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0966B_C01_SINISHIS C01_SINISHIS { get; set; } = new VA0966B_C01_SINISHIS();
        public VA0966B_SINISHIS1 SINISHIS1 { get; set; } = new VA0966B_SINISHIS1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0966B_AREA_DE_WORK AREA_DE_WORK_P, string SAI0966B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.AREA_DE_WORK = AREA_DE_WORK_P;
                SAI0966B.SetFile(SAI0966B_FILE_NAME_P);

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
            /*" -312- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -315- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -318- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -319- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -327- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -329- ACCEPT WPAR-PARAMETROS FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -332- MOVE 'NAO' TO WS-ERRO-DATA. */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -333- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_0.WPAR_ROTINA == "M")
            {

                /*" -335- IF WPAR-INICIO EQUAL '00000000' AND WPAR-FIM EQUAL '00000000' */

                if (AREA_DE_WORK.FILLER_0.WPAR_INICIO == "00000000" && AREA_DE_WORK.FILLER_0.WPAR_FIM == "00000000")
                {

                    /*" -337- DISPLAY '*** NAO HOUVE SOLICITACAO  ' WPAR-PARAMETROS */
                    _.Display($"*** NAO HOUVE SOLICITACAO  {AREA_DE_WORK.WPAR_PARAMETROS}");

                    /*" -338- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -340- END-IF */
                }


                /*" -343- MOVE WPAR-INICIO TO WS-DTH-CRITICA-R */
                _.Move(AREA_DE_WORK.FILLER_0.WPAR_INICIO, AREA_DE_WORK.WS_DTH_CRITICA_R);

                /*" -345- PERFORM R0300-00-CONSISTE-DATA */

                R0300_00_CONSISTE_DATA_SECTION();

                /*" -346- IF WS-ERRO-DATA EQUAL 'NAO' */

                if (AREA_DE_WORK.WS_ERRO_DATA == "NAO")
                {

                    /*" -349- MOVE WPAR-FIM TO WS-DTH-CRITICA-R */
                    _.Move(AREA_DE_WORK.FILLER_0.WPAR_FIM, AREA_DE_WORK.WS_DTH_CRITICA_R);

                    /*" -351- PERFORM R0300-00-CONSISTE-DATA */

                    R0300_00_CONSISTE_DATA_SECTION();

                    /*" -352- END-IF */
                }


                /*" -354- END-IF. */
            }


            /*" -357- IF WPAR-ROTINA EQUAL ( 'M' OR 'D' ) AND WS-ERRO-DATA EQUAL 'NAO' NEXT SENTENCE */

            if (AREA_DE_WORK.FILLER_0.WPAR_ROTINA.In("M", "D") && AREA_DE_WORK.WS_ERRO_DATA == "NAO")
            {

                /*" -358- ELSE */
            }
            else
            {


                /*" -360- DISPLAY '*** PROBLEMAS NOS PARAMETROS INFORMADOS ' WPAR-PARAMETROS */
                _.Display($"*** PROBLEMAS NOS PARAMETROS INFORMADOS {AREA_DE_WORK.WPAR_PARAMETROS}");

                /*" -361- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -363- END-IF. */
            }


            /*" -367- OPEN OUTPUT SAI0966B. */
            SAI0966B.Open(REG_VA0966B);

            /*" -369- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -370- WRITE REG-VA0966B FROM CAB1. */
            _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_VA0966B);

            SAI0966B.Write(REG_VA0966B.GetMoveValues().ToString());

            /*" -372- WRITE REG-VA0966B FROM CAB2. */
            _.Move(AREA_DE_WORK.CAB2.GetMoveValues(), REG_VA0966B);

            SAI0966B.Write(REG_VA0966B.GetMoveValues().ToString());

            /*" -373- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMA.IsEmpty())
            {

                /*" -374- DISPLAY '*** PROBLEMAS NA V1SISTEMA' */
                _.Display($"*** PROBLEMAS NA V1SISTEMA");

                /*" -375- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -376- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -378- END-IF. */
            }


            /*" -379- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_0.WPAR_ROTINA == "M")
            {

                /*" -380- PERFORM R0400-00-MONTA-DATA-PARAMETROS */

                R0400_00_MONTA_DATA_PARAMETROS_SECTION();

                /*" -382- END-IF. */
            }


            /*" -383- DISPLAY '***     PARAMETROS  ***' */
            _.Display($"***     PARAMETROS  ***");

            /*" -384- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
            _.Display($"*** TIPO DE ROTINA   {AREA_DE_WORK.FILLER_0.WPAR_ROTINA}");

            /*" -385- DISPLAY '*** DATA DE INICIO   ' WHOST-DTH-INI */
            _.Display($"*** DATA DE INICIO   {AREA_DE_WORK.WHOST_DTH_INI}");

            /*" -387- DISPLAY '*** DATA DE FIM      ' WHOST-DTH-FIM */
            _.Display($"*** DATA DE FIM      {AREA_DE_WORK.WHOST_DTH_FIM}");

            /*" -389- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -391- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -393- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -395- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -396- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -397- DISPLAY '*  NAO HA MOVIMENTO PARA O PERIODO  *' */
                _.Display($"*  NAO HA MOVIMENTO PARA O PERIODO  *");

                /*" -399- DISPLAY '*************************************' */
                _.Display($"*************************************");

                /*" -402- MOVE ' NAO HA MOVIMENTO PARA ESTE DIA' TO CAB1 */
                _.Move(" NAO HA MOVIMENTO PARA ESTE DIA", AREA_DE_WORK.CAB1);

                /*" -404- WRITE REG-VA0966B FROM CAB1 */
                _.Move(AREA_DE_WORK.CAB1.GetMoveValues(), REG_VA0966B);

                SAI0966B.Write(REG_VA0966B.GetMoveValues().ToString());

                /*" -406- PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION();

                /*" -408- END-IF. */
            }


            /*" -409- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS == "S"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

        }

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -417- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -417- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -421- DISPLAY ' ' . */
            _.Display($" ");

            /*" -423- DISPLAY '***VA0966B***.' */
            _.Display($"***VA0966B***.");

            /*" -424- DISPLAY 'TOTAL LIDOS....... ' AC-LIDOS. */
            _.Display($"TOTAL LIDOS....... {AREA_DE_WORK.AC_LIDOS}");

            /*" -425- DISPLAY 'TOTAL DE GRAVADOS. ' AC-GRAVADOS. */
            _.Display($"TOTAL DE GRAVADOS. {AREA_DE_WORK.AC_GRAVADOS}");

            /*" -426- DISPLAY 'DESPREZ SINISMES...' W77-DESPREZ-SINISMES */
            _.Display($"DESPREZ SINISMES...{W77_DESPREZ_SINISMES}");

            /*" -427- DISPLAY 'DESPREZ SEGUVGA... ' W77-DESPREZ-SEGURVGA */
            _.Display($"DESPREZ SEGUVGA... {W77_DESPREZ_SEGURVGA}");

            /*" -428- DISPLAY 'DESPREZ CLIENTES.. ' W77-DESPREZ-CLIENTES */
            _.Display($"DESPREZ CLIENTES.. {W77_DESPREZ_CLIENTES}");

            /*" -429- DISPLAY 'DESPREZ AVISADO... ' W77-DESPREZ-AVISADO */
            _.Display($"DESPREZ AVISADO... {W77_DESPREZ_AVISADO}");

            /*" -430- DISPLAY 'DESPREZ PRODUVG... ' W77-DESPREZ-PRODUVG */
            _.Display($"DESPREZ PRODUVG... {W77_DESPREZ_PRODUVG}");

            /*" -432- DISPLAY ' ' . */
            _.Display($" ");

            /*" -434- CLOSE SAI0966B. */
            SAI0966B.Close();

            /*" -435- DISPLAY '*' . */
            _.Display($"*");

            /*" -436- DISPLAY '***VA0966B - TERMINO NORMAL***' . */
            _.Display($"***VA0966B - TERMINO NORMAL***");

            /*" -438- DISPLAY '*' . */
            _.Display($"*");

            /*" -438- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -463- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -466- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -467- DISPLAY ' PROBLEMAS NO ACESSO A SISTEMAS' */
                _.Display($" PROBLEMAS NO ACESSO A SISTEMAS");

                /*" -468- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -470- END-IF. */
            }


            /*" -473- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO CAB1-DATA-ATU (7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 7, 4);

            /*" -476- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO CAB1-DATA-ATU (4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 4, 2);

            /*" -479- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO CAB1-DATA-ATU (1:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 1, 2);

            /*" -483- MOVE '/' TO CAB1-DATA-ATU(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 6, 1);

            /*" -483- MOVE '/' TO CAB1-DATA-ATU(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.CAB1.CAB1_DATA_ATU, 3, 1);

            /*" -484- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DTH-INI WHOST-DTH-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WHOST_DTH_INI, AREA_DE_WORK.WHOST_DTH_FIM);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -463- EXEC SQL SELECT DATA_MOV_ABERTO, CURRENT_DATE INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DT-HOJE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -498- MOVE 'R0300' TO WNR-EXEC-SQL. */
            _.Move("R0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -499- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -501- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -502- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -504- GO TO R0300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                return;

                /*" -506- END-IF. */
            }


            /*" -509- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -511- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -513- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
                {

                    /*" -514- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -515- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -517- END-IF. */
                }

            }


            /*" -521- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -522- IF WS-CRITICA-DIA GREATER 31 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -523- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -524- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -526- END-IF. */
                }

            }


            /*" -527- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -529- IF WS-CRITICA-DIA GREATER 30 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -530- IF WS-CRITICA-MES EQUAL 02 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
                    {

                        /*" -534- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                        _.Divide(AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, AREA_DE_WORK.AUX_RESULTADO, AREA_DE_WORK.AUX_RESTO);

                        /*" -535- IF AUX-RESTO EQUAL ZEROS */

                        if (AREA_DE_WORK.AUX_RESTO == 00)
                        {

                            /*" -536- IF WS-CRITICA-DIA GREATER 29 */

                            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                            {

                                /*" -537- MOVE 'SIM' TO WS-ERRO-DATA */
                                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                                /*" -538- GO TO R0300-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                                return;

                                /*" -539- END-IF */
                            }


                            /*" -541- ELSE */
                        }
                        else
                        {


                            /*" -542- IF WS-CRITICA-DIA GREATER 28 */

                            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                            {

                                /*" -543- MOVE 'SIM' TO WS-ERRO-DATA */
                                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                                /*" -544- GO TO R0300-99-SAIDA */
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                                return;

                                /*" -545- END-IF */
                            }


                            /*" -546- END-IF */
                        }


                        /*" -546- END-IF. */
                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-MONTA-DATA-PARAMETROS-SECTION */
        private void R0400_00_MONTA_DATA_PARAMETROS_SECTION()
        {
            /*" -560- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -564- MOVE WPAR-INICIO (1:4) TO LD00-11-DATAINI(7:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(1, 4), AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 7, 4);

            /*" -564- MOVE WPAR-INICIO (1:4) TO WHOST-DTH-INI(1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(1, 4), AREA_DE_WORK.WHOST_DTH_INI, 1, 4);

            /*" -568- MOVE WPAR-INICIO (5:2) TO LD00-11-DATAINI(4:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(5, 2), AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 4, 2);

            /*" -568- MOVE WPAR-INICIO (5:2) TO WHOST-DTH-INI(6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(5, 2), AREA_DE_WORK.WHOST_DTH_INI, 6, 2);

            /*" -572- MOVE WPAR-INICIO (7:2) TO LD00-11-DATAINI(1:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(7, 2), AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 1, 2);

            /*" -572- MOVE WPAR-INICIO (7:2) TO WHOST-DTH-INI(9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_INICIO.Substring(7, 2), AREA_DE_WORK.WHOST_DTH_INI, 9, 2);

            /*" -576- MOVE '/' TO LD00-11-DATAINI(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 6, 1);

            /*" -576- MOVE '/' TO LD00-11-DATAINI(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 3, 1);

            /*" -580- MOVE WPAR-FIM (1:4) TO LD00-11-DATAFIN(7:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(1, 4), AREA_DE_WORK.LD00_11.LD00_11_DATAFIN, 7, 4);

            /*" -580- MOVE WPAR-FIM (1:4) TO WHOST-DTH-FIM(1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(1, 4), AREA_DE_WORK.WHOST_DTH_FIM, 1, 4);

            /*" -582- IF WPAR-FIM (1:4) GREATER WHOST-DT-HOJE (1:4) */

            if (AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(1, 4) > WHOST_DT_HOJE.Substring(1, 4))
            {

                /*" -584- MOVE WHOST-DT-HOJE (1:4) TO LD00-11-DATAFIN (7:4) */
                _.MoveAtPosition(WHOST_DT_HOJE.Substring(1, 4), AREA_DE_WORK.LD00_11.LD00_11_DATAFIN, 7, 4);

                /*" -586- END-IF. */
            }


            /*" -590- MOVE WPAR-FIM (5:2) TO LD00-11-DATAFIN(4:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(5, 2), AREA_DE_WORK.LD00_11.LD00_11_DATAFIN, 4, 2);

            /*" -590- MOVE WPAR-FIM (5:2) TO WHOST-DTH-FIM(6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(5, 2), AREA_DE_WORK.WHOST_DTH_FIM, 6, 2);

            /*" -594- MOVE WPAR-FIM (7:2) TO LD00-11-DATAFIN(1:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(7, 2), AREA_DE_WORK.LD00_11.LD00_11_DATAFIN, 1, 2);

            /*" -594- MOVE WPAR-FIM (7:2) TO WHOST-DTH-FIM(9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_0.WPAR_FIM.Substring(7, 2), AREA_DE_WORK.WHOST_DTH_FIM, 9, 2);

            /*" -600- MOVE '/' TO LD00-11-DATAFIN(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LD00_11.LD00_11_DATAFIN, 6, 1);

            /*" -600- MOVE '/' TO LD00-11-DATAFIN(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LD00_11.LD00_11_DATAFIN, 3, 1);

            /*" -600- MOVE '/' TO LD00-11-DATAINI(6:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 6, 1);

            /*" -600- MOVE '/' TO LD00-11-DATAINI(3:1) */
            _.MoveAtPosition("/", AREA_DE_WORK.LD00_11.LD00_11_DATAINI, 3, 1);

            /*" -603- MOVE '  A  ' TO LD00-11-A */
            _.Move("  A  ", AREA_DE_WORK.LD00_11.LD00_11_A);

            /*" -606- MOVE '-' TO WHOST-DTH-FIM(5:1). */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_FIM, 5, 1);

            /*" -606- MOVE '-' TO WHOST-DTH-INI(8:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_INI, 8, 1);

            /*" -606- MOVE '-' TO WHOST-DTH-INI(5:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_INI, 5, 1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -620- MOVE 'R0900' TO WNR-EXEC-SQL. */
            _.Move("R0900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -639- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -641- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -645- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -647- DISPLAY 'PROBLEMA NO CURSOR SINISHIS.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS.");

                /*" -648- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -648- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -639- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO WHERE DATA_MOVIMENTO BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND COD_OPERACAO IN (1181, 1182, 1183, 1184) AND COD_PRODUTO IN (8201, 9327, 9301, 9311, 9318, 9319, 9320, 9321, 9322, 9325, 9326, 9327, 9701, 9702, 9703, 9704, 9705, 9712, :JVPRD9327, :JVPRD9320, :JVPRD9311, :JVPRD9321, :JVPRD9327) ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            C01_SINISHIS = new VA0966B_C01_SINISHIS(true);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT DISTINCT 
							NUM_APOL_SINISTRO 
							FROM SEGUROS.SINISTRO_HISTORICO 
							WHERE 
							DATA_MOVIMENTO BETWEEN '{AREA_DE_WORK.WHOST_DTH_INI}' 
							AND '{AREA_DE_WORK.WHOST_DTH_FIM}' 
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
            /*" -641- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R1900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -1131- EXEC SQL DECLARE SINISHIS1 CURSOR FOR SELECT VAL_OPERACAO , COD_USUARIO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */
            SINISHIS1 = new VA0966B_SINISHIS1(true);
            string GetQuery_SINISHIS1()
            {
                var query = @$"SELECT 
							VAL_OPERACAO
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
            /*" -664- MOVE 'R0910' TO WNR-EXEC-SQL. */
            _.Move("R0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -668- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -672- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -672- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -674- MOVE 'S' TO WFIM-SINISHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -675- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -676- ELSE */
                }
                else
                {


                    /*" -677- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS");

                    /*" -678- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -679- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -680- END-IF */
                }


                /*" -682- END-IF. */
            }


            /*" -684- ADD 1 TO AC-CONTA */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -685- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -686- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -687- ACCEPT AUX-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AUX_TIME);

                /*" -691- DISPLAY 'LIDOS SINISHIS ....: ' AC-LIDOS AUX-TIME SINISHIS-NUM-APOL-SINISTRO */

                $"LIDOS SINISHIS ....: {AREA_DE_WORK.AC_LIDOS}{AREA_DE_WORK.AUX_TIME}{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -691- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -668- EXEC SQL FETCH C01_SINISHIS INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -672- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -707- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -709- INITIALIZE CAB2. */
            _.Initialize(
                AREA_DE_WORK.CAB2
            );

            /*" -711- PERFORM R1100-00-SELECT-SINISMES */

            R1100_00_SELECT_SINISMES_SECTION();

            /*" -712- IF WTEM-SINISMES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SINISMES != "SIM")
            {

                /*" -713- ADD 1 TO W77-DESPREZ-SINISMES */
                W77_DESPREZ_SINISMES.Value = W77_DESPREZ_SINISMES + 1;

                /*" -714- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -716- END-IF. */
            }


            /*" -718- PERFORM R1200-00-SELECT-SEGURVGA */

            R1200_00_SELECT_SEGURVGA_SECTION();

            /*" -719- IF WTEM-SEGURVGA NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_SEGURVGA != "SIM")
            {

                /*" -722- ADD 1 TO W77-DESPREZ-SEGURVGA SINISHIS-NUM-APOL-SINISTRO */
                W77_DESPREZ_SEGURVGA.Value = W77_DESPREZ_SEGURVGA + 1;
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO + 1;

                /*" -723- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -725- END-IF. */
            }


            /*" -727- PERFORM R1300-00-SELECT-CLIENTES */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -728- IF WTEM-CLIENTES NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_CLIENTES != "SIM")
            {

                /*" -730- ADD 1 TO W77-DESPREZ-CLIENTES */
                W77_DESPREZ_CLIENTES.Value = W77_DESPREZ_CLIENTES + 1;

                /*" -731- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -733- END-IF. */
            }


            /*" -735- PERFORM R1450-00-SELECT-FONTES */

            R1450_00_SELECT_FONTES_SECTION();

            /*" -737- PERFORM R1500-00-SELECT-PRODUTO */

            R1500_00_SELECT_PRODUTO_SECTION();

            /*" -739- PERFORM R1510-00-SELECT-PRODUVG */

            R1510_00_SELECT_PRODUVG_SECTION();

            /*" -740- IF WTEM-PRODUVG NOT EQUAL 'SIM' */

            if (AREA_DE_WORK.WTEM_PRODUVG != "SIM")
            {

                /*" -743- ADD 1 TO W77-DESPREZ-PRODUVG SINISHIS-NUM-APOL-SINISTRO */
                W77_DESPREZ_PRODUVG.Value = W77_DESPREZ_PRODUVG + 1;
                SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.Value = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO + 1;

                /*" -744- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -746- END-IF. */
            }


            /*" -747- IF PRODUVG-RAMO EQUAL 93 OR 97 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO.In("93", "97"))
            {

                /*" -748- MOVE 'VG' TO SAI-COBERTURA */
                _.Move("VG", AREA_DE_WORK.SAI.SAI_COBERTURA);

                /*" -749- ELSE */
            }
            else
            {


                /*" -750- IF PRODUVG-RAMO EQUAL 82 */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO == 82)
                {

                    /*" -751- MOVE 'AP' TO SAI-COBERTURA */
                    _.Move("AP", AREA_DE_WORK.SAI.SAI_COBERTURA);

                    /*" -752- END-IF */
                }


                /*" -754- END-IF. */
            }


            /*" -756- PERFORM R1600-00-SELECT-COBERTURA */

            R1600_00_SELECT_COBERTURA_SECTION();

            /*" -759- MOVE SINISHIS-NUM-APOL-SINISTRO TO SAI-NUM-APOL-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, AREA_DE_WORK.SAI.SAI_NUM_APOL_SINISTRO);

            /*" -762- MOVE CLIENTES-NOME-RAZAO TO SAI-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, AREA_DE_WORK.SAI.SAI_SEGURADO);

            /*" -765- MOVE CLIENTES-CGCCPF TO SAI-CGCCPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.SAI.SAI_CGCCPF_CNPJ);

            /*" -768- MOVE FONTES-NOME-FONTE TO SAI-NOME-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, AREA_DE_WORK.SAI.SAI_NOME_FONTE);

            /*" -771- MOVE PRODUTO-COD-PRODUTO TO SAI-COD-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, AREA_DE_WORK.SAI.SAI_COD_PRODUTO);

            /*" -774- MOVE PRODUTO-DESCR-PRODUTO TO SAI-DESCR-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, AREA_DE_WORK.SAI.SAI_DESCR_PRODUTO);

            /*" -777- MOVE SINISMES-IMP-SEGURADA-IX TO SAI-IS */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX, AREA_DE_WORK.SAI.SAI_IS);

            /*" -780- MOVE 'N' TO WFIM-SINISHIS1 */
            _.Move("N", AREA_DE_WORK.WFIM_SINISHIS1);

            /*" -781- PERFORM R1900-00-DECLARE-CURSOR */

            R1900_00_DECLARE_CURSOR_SECTION();

            /*" -782- PERFORM R1910-00-FETCH-CURSOR */

            R1910_00_FETCH_CURSOR_SECTION();

            /*" -783- IF WFIM-SINISHIS1 EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS1 == "S")
            {

                /*" -784- ADD 1 TO W77-DESPREZ-SINISMES */
                W77_DESPREZ_SINISMES.Value = W77_DESPREZ_SINISMES + 1;

                /*" -786- END-IF. */
            }


            /*" -787- PERFORM R2000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS1 EQUAL 'S' . */

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
            /*" -791- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-SECTION */
        private void R1100_00_SELECT_SINISMES_SECTION()
        {
            /*" -807- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -809- MOVE 'SIM' TO WTEM-SINISMES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_SINISMES);

            /*" -821- PERFORM R1100_00_SELECT_SINISMES_DB_SELECT_1 */

            R1100_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -824- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -825- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -826- MOVE 'NAO' TO WTEM-SINISMES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SINISMES);

                    /*" -827- ELSE */
                }
                else
                {


                    /*" -828- DISPLAY 'PROBLEMAS NA R1100-00-SELECT-SINISMES' */
                    _.Display($"PROBLEMAS NA R1100-00-SELECT-SINISMES");

                    /*" -829- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -830- END-IF */
                }


                /*" -833- END-IF. R1100-99-SAIDA. */
            }


            /*" -833- EXIT. */

            return;

        }

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R1100_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -821- EXEC SQL SELECT NUM_CERTIFICADO , IMP_SEGURADA_IX INTO :SINISMES-NUM-CERTIFICADO , :SINISMES-IMP-SEGURADA-IX FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND NUM_CERTIFICADO <> 0 END-EXEC. */

            var r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(executed_1.SINISMES_IMP_SEGURADA_IX, SINISMES.DCLSINISTRO_MESTRE.SINISMES_IMP_SEGURADA_IX);
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-SECTION */
        private void R1200_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -844- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -846- MOVE 'SIM' TO WTEM-SEGURVGA. */
            _.Move("SIM", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -860- PERFORM R1200_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1200_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -863- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -864- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -865- MOVE 'NAO' TO WTEM-SEGURVGA */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -866- ELSE */
                }
                else
                {


                    /*" -867- DISPLAY 'PROBLEMAS NA R1200-00-SELECT-SEGURVGA' */
                    _.Display($"PROBLEMAS NA R1200-00-SELECT-SEGURVGA");

                    /*" -868- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -869- END-IF */
                }


                /*" -869- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1200_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -860- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_CLIENTE INTO :SEGURVGA-NUM-APOLICE , :SEGURVGA-COD-SUBGRUPO , :SEGURVGA-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

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
            /*" -883- MOVE 'R1300' TO WNR-EXEC-SQL. */
            _.Move("R1300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -885- MOVE 'SIM' TO WTEM-CLIENTES. */
            _.Move("SIM", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -897- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -900- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -901- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -902- MOVE 'NAO' TO WTEM-CLIENTES */
                    _.Move("NAO", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -903- ELSE */
                }
                else
                {


                    /*" -904- DISPLAY 'PROBLEMAS NA R1300-00-SELECT-CLIENTES' */
                    _.Display($"PROBLEMAS NA R1300-00-SELECT-CLIENTES");

                    /*" -905- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -906- END-IF */
                }


                /*" -906- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -897- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

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
            /*" -920- MOVE 'R1400' TO WNR-EXEC-SQL. */
            _.Move("R1400", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -922- MOVE 'SIM' TO WTEM-SINISHIS */
            _.Move("SIM", AREA_DE_WORK.WTEM_SINISHIS);

            /*" -932- PERFORM R1400_00_SELECT_SINISHIS_DB_SELECT_1 */

            R1400_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -935- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -936- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -937- MOVE 'NAO' TO WTEM-SINISHIS */
                    _.Move("NAO", AREA_DE_WORK.WTEM_SINISHIS);

                    /*" -938- ELSE */
                }
                else
                {


                    /*" -939- DISPLAY 'PROBLEMAS NA R1400-00-SELECT-SINIHIS' */
                    _.Display($"PROBLEMAS NA R1400-00-SELECT-SINIHIS");

                    /*" -940- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -941- END-IF */
                }


                /*" -941- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R1400_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -932- EXEC SQL SELECT VAL_OPERACAO AS VAL_AVISADO INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 END-EXEC. */

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
            /*" -955- MOVE 'R1450' TO WNR-EXEC-SQL. */
            _.Move("R1450", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -964- PERFORM R1450_00_SELECT_FONTES_DB_SELECT_1 */

            R1450_00_SELECT_FONTES_DB_SELECT_1();

            /*" -967- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -968- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -969- MOVE ' ' TO FONTES-NOME-FONTE */
                    _.Move(" ", FONTES.DCLFONTES.FONTES_NOME_FONTE);

                    /*" -970- ELSE */
                }
                else
                {


                    /*" -971- DISPLAY 'PROBLEMAS NA R1450-00-SELECT-FONTES' */
                    _.Display($"PROBLEMAS NA R1450-00-SELECT-FONTES");

                    /*" -972- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -973- END-IF */
                }


                /*" -973- END-IF. */
            }


        }

        [StopWatch]
        /*" R1450-00-SELECT-FONTES-DB-SELECT-1 */
        public void R1450_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -964- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :SINISMES-COD-FONTE END-EXEC. */

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
            /*" -987- MOVE 'R1500' TO WNR-EXEC-SQL. */
            _.Move("R1500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -999- PERFORM R1500_00_SELECT_PRODUTO_DB_SELECT_1 */

            R1500_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -1002- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1003- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1013- PERFORM R1500_00_SELECT_PRODUTO_DB_SELECT_2 */

                    R1500_00_SELECT_PRODUTO_DB_SELECT_2();

                    /*" -1016- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1017- DISPLAY 'PROBLEMAS NA R1500-00-SELECT-PRODUTO' */
                        _.Display($"PROBLEMAS NA R1500-00-SELECT-PRODUTO");

                        /*" -1018- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1020- END-IF */
                    }


                    /*" -1031- PERFORM R1500_00_SELECT_PRODUTO_DB_SELECT_3 */

                    R1500_00_SELECT_PRODUTO_DB_SELECT_3();

                    /*" -1034- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1035- IF SQLCODE EQUAL 100 */

                        if (DB.SQLCODE == 100)
                        {

                            /*" -1036- MOVE ZEROS TO PRODUTO-COD-PRODUTO */
                            _.Move(0, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);

                            /*" -1037- MOVE SPACES TO PRODUTO-DESCR-PRODUTO */
                            _.Move("", PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);

                            /*" -1038- ELSE */
                        }
                        else
                        {


                            /*" -1039- DISPLAY 'PROBLEMAS NA R1400-00-SELECT-PRODUTO' */
                            _.Display($"PROBLEMAS NA R1400-00-SELECT-PRODUTO");

                            /*" -1040- GO TO R9999-00-ROT-ERRO */

                            R9999_00_ROT_ERRO_SECTION(); //GOTO
                            return;

                            /*" -1041- END-IF */
                        }


                        /*" -1041- END-IF. */
                    }

                }

            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R1500_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -999- EXEC SQL SELECT COD_PRODUTO, NOME_PRODUTO INTO :PRODUTO-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-DB-SELECT-2 */
        public void R1500_00_SELECT_PRODUTO_DB_SELECT_2()
        {
            /*" -1013- EXEC SQL SELECT COD_PRODUTO INTO :APOLICES-COD-PRODUTO FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE END-EXEC */

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
        /*" R1510-00-SELECT-PRODUVG-SECTION */
        private void R1510_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1055- MOVE 'R1510' TO WNR-EXEC-SQL. */
            _.Move("R1510", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1057- MOVE 'SIM' TO WTEM-PRODUVG. */
            _.Move("SIM", AREA_DE_WORK.WTEM_PRODUVG);

            /*" -1067- PERFORM R1510_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1510_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1070- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1071- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1072- MOVE 'NAO' TO WTEM-PRODUVG */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PRODUVG);

                    /*" -1073- ELSE */
                }
                else
                {


                    /*" -1074- DISPLAY 'PROBLEMAS NA R1500-00-SELECT-PRODUVG' */
                    _.Display($"PROBLEMAS NA R1500-00-SELECT-PRODUVG");

                    /*" -1075- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1076- END-IF */
                }


                /*" -1076- END-IF. */
            }


        }

        [StopWatch]
        /*" R1510-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1510_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1067- EXEC SQL SELECT RAMO INTO :PRODUVG-RAMO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1510_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_RAMO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_RAMO);
            }


        }

        [StopWatch]
        /*" R1500-00-SELECT-PRODUTO-DB-SELECT-3 */
        public void R1500_00_SELECT_PRODUTO_DB_SELECT_3()
        {
            /*" -1031- EXEC SQL SELECT COD_PRODUTO , DESCR_PRODUTO INTO :PRODUTO-COD-PRODUTO , :PRODUTO-DESCR-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :APOLICES-COD-PRODUTO END-EXEC. */

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
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-COBERTURA-SECTION */
        private void R1600_00_SELECT_COBERTURA_SECTION()
        {
            /*" -1091- MOVE 'R1600' TO WNR-EXEC-SQL. */
            _.Move("R1600", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1100- PERFORM R1600_00_SELECT_COBERTURA_DB_SELECT_1 */

            R1600_00_SELECT_COBERTURA_DB_SELECT_1();

            /*" -1103- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1104- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1105- MOVE 'NAO' TO WTEM-PRODUVG */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PRODUVG);

                    /*" -1106- ELSE */
                }
                else
                {


                    /*" -1107- DISPLAY 'PROBLEMAS NA R1600-00-SELECT-COBERTURA' */
                    _.Display($"PROBLEMAS NA R1600-00-SELECT-COBERTURA");

                    /*" -1108- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1109- END-IF */
                }


                /*" -1109- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-COBERTURA-DB-SELECT-1 */
        public void R1600_00_SELECT_COBERTURA_DB_SELECT_1()
        {
            /*" -1100- EXEC SQL SELECT OPC_COBERTURA INTO :BILHETE-OPC-COBERTURA FROM SEGUROS.BILHETE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE END-EXEC. */

            var r1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1 = new R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_COBERTURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_OPC_COBERTURA, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-SECTION */
        private void R1900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -1122- MOVE 'R1900' TO WNR-EXEC-SQL. */
            _.Move("R1900", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1131- PERFORM R1900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R1900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -1133- PERFORM R1900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R1900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -1136- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1137- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1138- MOVE 'NAO' TO WTEM-PRODUVG */
                    _.Move("NAO", AREA_DE_WORK.WTEM_PRODUVG);

                    /*" -1139- ELSE */
                }
                else
                {


                    /*" -1140- DISPLAY 'PROBLEMAS NA R1600-00-SELECT-COBERTURA' */
                    _.Display($"PROBLEMAS NA R1600-00-SELECT-COBERTURA");

                    /*" -1141- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1142- END-IF */
                }


                /*" -1142- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R1900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -1133- EXEC SQL OPEN SINISHIS1 END-EXEC. */

            SINISHIS1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-SECTION */
        private void R1910_00_FETCH_CURSOR_SECTION()
        {
            /*" -1156- MOVE 'R1910' TO WNR-EXEC-SQL. */
            _.Move("R1910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1160- PERFORM R1910_00_FETCH_CURSOR_DB_FETCH_1 */

            R1910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -1163- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1164- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1164- PERFORM R1910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R1910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -1166- MOVE 'S' TO WFIM-SINISHIS1 */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS1);

                    /*" -1167- GO TO R1910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1168- ELSE */
                }
                else
                {


                    /*" -1169- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS1' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS1");

                    /*" -1170- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -1171- PERFORM R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION();

                    /*" -1172- END-IF */
                }


                /*" -1174- END-IF. */
            }


            /*" -1174- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R1910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -1160- EXEC SQL FETCH SINISHIS1 INTO :SINISHIS-VAL-OPERACAO, :SINISHIS-COD-USUARIO END-EXEC. */

            if (SINISHIS1.Fetch())
            {
                _.Move(SINISHIS1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISHIS1.SINISHIS_COD_USUARIO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R1910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -1164- EXEC SQL CLOSE SINISHIS1 END-EXEC */

            SINISHIS1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISHIS-SECTION */
        private void R2000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -1188- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1190- PERFORM R2100-00-SELECT-SINISHIS */

            R2100_00_SELECT_SINISHIS_SECTION();

            /*" -1193- MOVE SINISHIS-VAL-OPERACAO TO SAI-VL-OPERACAO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, AREA_DE_WORK.SAI.SAI_VL_OPERACAO);

            /*" -1195- WRITE REG-VA0966B FROM SAI. */
            _.Move(AREA_DE_WORK.SAI.GetMoveValues(), REG_VA0966B);

            SAI0966B.Write(REG_VA0966B.GetMoveValues().ToString());

            /*" -1195- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R2000_10_NEXT */

            R2000_10_NEXT();

        }

        [StopWatch]
        /*" R2000-10-NEXT */
        private void R2000_10_NEXT(bool isPerform = false)
        {
            /*" -1199- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-SINISHIS-SECTION */
        private void R2100_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1213- MOVE 'R2100' TO WNR-EXEC-SQL. */
            _.Move("R2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1215- MOVE 'SIM' TO WTEM-PAGAMENTO */
            _.Move("SIM", AREA_DE_WORK.WTEM_PAGAMENTO);

            /*" -1225- PERFORM R2100_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2100_00_SELECT_SINISHIS_DB_SELECT_1();

        }

        [StopWatch]
        /*" R2100-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2100_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1225- EXEC SQL SELECT VAL_OPERACAO INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */

            var r2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1 = new R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_SINISHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1239- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1241- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1241- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1243- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1247- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1247- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}