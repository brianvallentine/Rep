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
using Sias.VidaAzul.DB2.VA0965B;

namespace Code
{
    public class VA0965B
    {
        public bool IsCall { get; set; }

        public VA0965B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * FUNCAO...................: ACOMPANHAMENTOS DE SINISTROS        *      */
        /*"      *                            E RESULTADOS FINANCEIROS            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA .................: VA                                  *      */
        /*"      * PROGRAMA ................: VA0965B                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CADMUS...................: 22.007                              *      */
        /*"      * PROGRAMADOR .............: LEANDRO CORTES - FAST COMPUTER      *      */
        /*"      * DATA CODIFICACAO ........: 25/03/2009                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.02    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 15/01/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * CADMUS...................: 22.007                              *      */
        /*"      * PROGRAMADOR .............: LEANDRO CORTES - FAST COMPUTER      *      */
        /*"      * DATA CODIFICACAO ........: 25/03/2009                          *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - HIST 181.582                                     *      */
        /*"      *             - PREPARAR PROGRAMA PARA PROCESSAMENTO DA JV1      *      */
        /*"      *                                                                *      */
        /*"      *   EM 20/01/2019 - HUSNI ALI HUSNI                              *      */
        /*"      *                                       PROCURE POR JV101        *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQSAIDA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ARQSAIDA
        {
            get
            {
                _.Move(REG_SAIDA, _ARQSAIDA); VarBasis.RedefinePassValue(REG_SAIDA, _ARQSAIDA, REG_SAIDA); return _ARQSAIDA;
            }
        }
        /*"01          REG-SAIDA       PIC X(400).*/
        public StringBasis REG_SAIDA { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  WHOST-MAX-OCORR             PIC  S9(4)    USAGE   COMP.*/
        public IntBasis WHOST_MAX_OCORR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"77  WHOST-NUM-OCORR-MOVTO       PIC  S9(9)    USAGE   COMP.*/
        public IntBasis WHOST_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77  WHOST-DTFINAL               PIC  X(010)   VALUE   SPACES.*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-DT-CORRENTE           PIC  X(010)   VALUE   SPACES.*/
        public StringBasis WHOST_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  WHOST-CURRENT-DATE          PIC  X(10)    VALUE   SPACES.*/
        public StringBasis WHOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  WHOST-VAL-DIFERENCA         PIC S9(13)V99 COMP    VALUE +0.*/
        public DoubleBasis WHOST_VAL_DIFERENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-VAL-IN-TOTAL          PIC S9(13)V99 COMP    VALUE +0.*/
        public DoubleBasis WHOST_VAL_IN_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  WHOST-VAL-AVISADO           PIC S9(13)V99 COMP    VALUE +0.*/
        public DoubleBasis WHOST_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  DESPREZADOS-SINISMES        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_SINISMES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-SEGURVGA        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_SEGURVGA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-CLIENTES        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_CLIENTES { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-AVISADO         PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_AVISADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-SINISTRO        PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_SINISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PESS-SINIS      PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PESS_SINIS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PESS-EVENTO     PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PESS_EVENTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77  DESPREZADOS-PESS-CONTA      PIC  9(09)    VALUE   ZEROS.*/
        public IntBasis DESPREZADOS_PESS_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"01  AREA-DE-WORK.*/
        public VA0965B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0965B_AREA_DE_WORK();
        public class VA0965B_AREA_DE_WORK : VarBasis
        {
            /*"    05       SIST-DT-MOV-ABERTO  PIC  X(10)     VALUE  SPACES.*/
            public StringBasis SIST_DT_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"    05       WFIM-SISTEMA        PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WFIM-SINISHIS       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WFIM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WFIM-SINISHIS1      PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WFIM_SINISHIS1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-VARIAVEL       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_VARIAVEL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-SINISMES       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SINISMES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-SINISHIS       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SINISHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-SINISTRO       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-CLIENTES       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_CLIENTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-SEGURVGA       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SEGURVGA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-SISTEMAS       PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       WTEM-FONTES         PIC  X(01)     VALUE  SPACES.*/
            public StringBasis WTEM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"    05       AUX-TIME            PIC  X(08)     VALUE  SPACES.*/
            public StringBasis AUX_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
            /*"    05       AC-LIDOS            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05       AC-CONTA            PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05       AC-GRAVADOS         PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 AUX-RESULTADO              PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 AUX-RESTO                  PIC  9(09)   VALUE   ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05 WS-ERRO-DATA               PIC  X(003)  VALUE   SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05 WS-DTH-CRITICA             PIC  9(008).*/
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05 WS-DTH-CRITICA-R           REDEFINES    WS-DTH-CRITICA.*/
            private _REDEF_VA0965B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VA0965B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VA0965B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VA0965B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"      10     WS-CRITICA-ANO       PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-CRITICA-MES       PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CRITICA-DIA       PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-LIDOS                PIC 9(008)   VALUE   ZEROS.*/

                public _REDEF_VA0965B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-GRAVA-ARQ1           PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_ARQ1 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-GRAVA-DES            PIC 9(008)   VALUE   ZEROS.*/
            public IntBasis WS_GRAVA_DES { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  WS-DATA-ACCEPT.*/
            public VA0965B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new VA0965B_WS_DATA_ACCEPT();
            public class VA0965B_WS_DATA_ACCEPT : VarBasis
            {
                /*"        10  WS-ANO-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MES-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-DIA-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-HORA-ACCEPT.*/
            }
            public VA0965B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new VA0965B_WS_HORA_ACCEPT();
            public class VA0965B_WS_HORA_ACCEPT : VarBasis
            {
                /*"        10  WS-HOR-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-MIN-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  WS-SEG-ACCEPT       PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WS-DATA-CURR.*/
            }
            public VA0965B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new VA0965B_WS_DATA_CURR();
            public class VA0965B_WS_DATA_CURR : VarBasis
            {
                /*"        10  WS-DIA-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-MES-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"        10  WS-ANO-CURR         PIC  9(004)  VALUE   ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    05  WS-HORA-CURR.*/
            }
            public VA0965B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new VA0965B_WS_HORA_CURR();
            public class VA0965B_WS_HORA_CURR : VarBasis
            {
                /*"        10  WS-HOR-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   ':'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-MIN-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"        10  FILLER              PIC  X(001)  VALUE   ':'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"        10  WS-SEG-CURR         PIC  9(002)  VALUE   ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05  WHOST-DATA-REF          PIC  X(010)  VALUE   SPACES.*/
            }
            public StringBasis WHOST_DATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05  WHOST-COD-PRODUTO       PIC S9(004)  VALUE +0 COMP.*/
            public IntBasis WHOST_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05  WHOST-DTH-INI           PIC  X(010).*/
            public StringBasis WHOST_DTH_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  WHOST-DTH-FIM           PIC  X(010).*/
            public StringBasis WHOST_DTH_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  WHOST-DTCURRENT         PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05        DATA-SQL.*/
            public VA0965B_DATA_SQL DATA_SQL { get; set; } = new VA0965B_DATA_SQL();
            public class VA0965B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WPAR-PARAMETROS     PIC  X(17).*/
            }
            public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
            /*"    05        FILLER REDEFINES    WPAR-PARAMETROS.*/
            private _REDEF_VA0965B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VA0965B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VA0965B_FILLER_7(); _.Move(WPAR_PARAMETROS, _filler_7); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_7, WPAR_PARAMETROS); _filler_7.ValueChanged += () => { _.Move(_filler_7, WPAR_PARAMETROS); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WPAR_PARAMETROS); }
            }  //Redefines
            public class _REDEF_VA0965B_FILLER_7 : VarBasis
            {
                /*"      10     WPAR-ROTINA         PIC  X(01).*/
                public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10     WPAR-INICIO         PIC  X(08).*/
                public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10     WPAR-FIM            PIC  X(08).*/
                public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"01         LD00.*/

                public _REDEF_VA0965B_FILLER_7()
                {
                    WPAR_ROTINA.ValueChanged += OnValueChanged;
                    WPAR_INICIO.ValueChanged += OnValueChanged;
                    WPAR_FIM.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0965B_LD00 LD00 { get; set; } = new VA0965B_LD00();
        public class VA0965B_LD00 : VarBasis
        {
            /*"    05    FILLER     PIC  X(11) VALUE 'RELATORIO A'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"RELATORIO A");
            /*"    05    FILLER     PIC  X(03) VALUE ' - '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
            /*"    05    FILLER     PIC  X(47) VALUE         'ACOMPANHAMENTO SINISTRO E RESULTADO FINANCEIRO'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "47", "X(47)"), @"ACOMPANHAMENTO SINISTRO E RESULTADO FINANCEIRO");
            /*"01        LD01.*/
        }
        public VA0965B_LD01 LD01 { get; set; } = new VA0965B_LD01();
        public class VA0965B_LD01 : VarBasis
        {
            /*"    05    FILLER                PIC  X(12)          VALUE 'NUM SINISTRO'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM SINISTRO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(08)          VALUE 'SEGURADO'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(11)          VALUE 'CGCCPF/CNPJ'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CGCCPF/CNPJ");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(10)          VALUE 'VL AVISADO'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"VL AVISADO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(14)          VALUE 'VL TOT PRE LIB'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"VL TOT PRE LIB");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(12)          VALUE 'VL DIFERENCA'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"VL DIFERENCA");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(11)          VALUE 'VL OPERACAO'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"VL OPERACAO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(15)          VALUE 'NM BENEFICIARIO'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"NM BENEFICIARIO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(16)          VALUE 'CPF BENEFICIARIO'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"CPF BENEFICIARIO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(05)          VALUE 'BANCO'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"BANCO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(07)          VALUE 'AGENCIA'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(08)          VALUE 'OPERACAO'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"OPERACAO");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    FILLER                PIC  X(05)          VALUE 'CONTA'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CONTA");
            /*"    05    FILLER                PIC  X(01) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01         LD02.*/
        }
        public VA0965B_LD02 LD02 { get; set; } = new VA0965B_LD02();
        public class VA0965B_LD02 : VarBasis
        {
            /*"    05    LD02-NUM-APOL-SINISTRO PIC 9(13).*/
            public IntBasis LD02_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-NOME-RAZAO        PIC  X(40).*/
            public StringBasis LD02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-CGCCPF-CNPJ       PIC  9(14).*/
            public IntBasis LD02_CGCCPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-VAL-AVISADO       PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-VAL-TOT-PRE-LIB   PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_TOT_PRE_LIB { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-VAL-DIFERENCA     PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-VAL-OPER          PIC  9999999999999,99.*/
            public DoubleBasis LD02_VAL_OPER { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-NOME-BENEFICIARIO PIC  X(40).*/
            public StringBasis LD02_NOME_BENEFICIARIO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-CPF-BENEFICIARIO  PIC  9(14).*/
            public IntBasis LD02_CPF_BENEFICIARIO { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-BANCO             PIC  9(04).*/
            public IntBasis LD02_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-AGENCIA           PIC  9(04).*/
            public IntBasis LD02_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-OPERACAO          PIC  X(04).*/
            public StringBasis LD02_OPERACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05    LD02-CONTA             PIC  X(12).*/
            public StringBasis LD02_CONTA { get; set; } = new StringBasis(new PIC("X", "12", "X(12)."), @"");
            /*"    05    FILLER                 PIC  X(01)  VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01         WABEND.*/
        }
        public VA0965B_WABEND WABEND { get; set; } = new VA0965B_WABEND();
        public class VA0965B_WABEND : VarBasis
        {
            /*"    10     FILLER              PIC  X(010)    VALUE            'VA0965B'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0965B");
            /*"    10     FILLER              PIC  X(026)    VALUE            ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10     WNR-EXEC-SQL        PIC  X(004)    VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10     FILLER              PIC  X(013)    VALUE            ' *** SQLCODE '.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10     WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.OD009 OD009 { get; set; } = new Dclgens.OD009();
        public Dclgens.GE368 GE368 { get; set; } = new Dclgens.GE368();
        public Dclgens.SI155 SI155 { get; set; } = new Dclgens.SI155();
        public Dclgens.SI175 SI175 { get; set; } = new Dclgens.SI175();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public VA0965B_C01_SINISHIS C01_SINISHIS { get; set; } = new VA0965B_C01_SINISHIS();
        public VA0965B_SINISHIS1 SINISHIS1 { get; set; } = new VA0965B_SINISHIS1();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(VA0965B_AREA_DE_WORK AREA_DE_WORK_P, string ARQSAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.AREA_DE_WORK = AREA_DE_WORK_P;
                ARQSAIDA.SetFile(ARQSAIDA_FILE_NAME_P);

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
            /*" -347- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -350- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -353- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -355- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -362- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -364- ACCEPT WPAR-PARAMETROS FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -367- MOVE 'NAO' TO WS-ERRO-DATA. */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -368- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_7.WPAR_ROTINA == "M")
            {

                /*" -370- IF WPAR-INICIO EQUAL '00000000' AND WPAR-FIM EQUAL '00000000' */

                if (AREA_DE_WORK.FILLER_7.WPAR_INICIO == "00000000" && AREA_DE_WORK.FILLER_7.WPAR_FIM == "00000000")
                {

                    /*" -372- DISPLAY '*** NAO HOUVE SOLICITACAO  ' WPAR-PARAMETROS */
                    _.Display($"*** NAO HOUVE SOLICITACAO  {AREA_DE_WORK.WPAR_PARAMETROS}");

                    /*" -373- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -374- END-IF */
                }


                /*" -376- END-IF. */
            }


            /*" -379- MOVE WPAR-INICIO TO WS-DTH-CRITICA-R. */
            _.Move(AREA_DE_WORK.FILLER_7.WPAR_INICIO, AREA_DE_WORK.WS_DTH_CRITICA_R);

            /*" -380- IF WS-ERRO-DATA EQUAL 'NAO' */

            if (AREA_DE_WORK.WS_ERRO_DATA == "NAO")
            {

                /*" -382- MOVE WPAR-FIM TO WS-DTH-CRITICA-R */
                _.Move(AREA_DE_WORK.FILLER_7.WPAR_FIM, AREA_DE_WORK.WS_DTH_CRITICA_R);

                /*" -384- END-IF. */
            }


            /*" -386- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -387- IF WFIM-SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_SISTEMA.IsEmpty())
            {

                /*" -388- DISPLAY '***  PROBLEMAS NA V1SISTEMA' */
                _.Display($"***  PROBLEMAS NA V1SISTEMA");

                /*" -389- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -390- STOP RUN */

                throw new GoBack();   // => STOP RUN.

                /*" -392- END-IF. */
            }


            /*" -393- IF WPAR-ROTINA EQUAL 'M' */

            if (AREA_DE_WORK.FILLER_7.WPAR_ROTINA == "M")
            {

                /*" -394- PERFORM R0160-00-CONSISTE-DATA */

                R0160_00_CONSISTE_DATA_SECTION();

                /*" -395- PERFORM R0150-00-MONTA-PARAMETROS */

                R0150_00_MONTA_PARAMETROS_SECTION();

                /*" -396- ELSE */
            }
            else
            {


                /*" -398- PERFORM R0100-00-SELECT-SISTEMA */

                R0100_00_SELECT_SISTEMA_SECTION();

                /*" -399- IF WFIM-SISTEMA NOT EQUAL SPACES */

                if (!AREA_DE_WORK.WFIM_SISTEMA.IsEmpty())
                {

                    /*" -400- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                    _.Display($"*** PROBLEMAS NA SISTEMAS");

                    /*" -401- MOVE 9 TO RETURN-CODE */
                    _.Move(9, RETURN_CODE);

                    /*" -402- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -404- END-IF */
                }


                /*" -405- DISPLAY '***     PARAMETROS  ***' */
                _.Display($"***     PARAMETROS  ***");

                /*" -406- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
                _.Display($"*** TIPO DE ROTINA   {AREA_DE_WORK.FILLER_7.WPAR_ROTINA}");

                /*" -407- DISPLAY '*** DATA DE INICIO   ' WHOST-DTH-INI */
                _.Display($"*** DATA DE INICIO   {AREA_DE_WORK.WHOST_DTH_INI}");

                /*" -409- DISPLAY '*** DATA DE FIM      ' WHOST-DTH-FIM */
                _.Display($"*** DATA DE FIM      {AREA_DE_WORK.WHOST_DTH_FIM}");

                /*" -411- END-IF. */
            }


            /*" -414- IF WPAR-ROTINA EQUAL ( 'M' OR 'D' ) AND WS-ERRO-DATA EQUAL 'NAO' NEXT SENTENCE */

            if (AREA_DE_WORK.FILLER_7.WPAR_ROTINA.In("M", "D") && AREA_DE_WORK.WS_ERRO_DATA == "NAO")
            {

                /*" -415- ELSE */
            }
            else
            {


                /*" -417- DISPLAY '*** PROBLEMAS NOS PARAMETROS INFORMADOS ' '(' WPAR-PARAMETROS ') ***' */

                $"*** PROBLEMAS NOS PARAMETROS INFORMADOS ({AREA_DE_WORK.WPAR_PARAMETROS}) ***"
                .Display();

                /*" -418- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -420- END-IF. */
            }


            /*" -422- OPEN OUTPUT ARQSAIDA. */
            ARQSAIDA.Open(REG_SAIDA);

            /*" -424- WRITE REG-SAIDA FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -426- WRITE REG-SAIDA FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -428- PERFORM R0900-00-DECLARE-CURSOR. */

            R0900_00_DECLARE_CURSOR_SECTION();

            /*" -430- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

            /*" -432- IF WFIM-SINISHIS EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS == "S")
            {

                /*" -434- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -436- DISPLAY '** NAO HA MOVIMENTO PARA O PERIODO **' */
                _.Display($"** NAO HA MOVIMENTO PARA O PERIODO **");

                /*" -439- MOVE '** NAO HA MOVIMENTO PARA ESTE DIA  **' TO LD01 */
                _.Move("** NAO HA MOVIMENTO PARA ESTE DIA  **", LD01);

                /*" -441- WRITE REG-SAIDA FROM LD01 */
                _.Move(LD01.GetMoveValues(), REG_SAIDA);

                ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

                /*" -443- PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA_SECTION();

                /*" -445- END-IF. */
            }


            /*" -446- PERFORM R1000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS EQUAL 'S' . */

            while (!(AREA_DE_WORK.WFIM_SINISHIS == "S"))
            {

                R1000_00_PROCESSA_SINISHIS_SECTION();
            }

        }

        [StopWatch]
        /*" R0000-90-FINALIZA-SECTION */
        private void R0000_90_FINALIZA_SECTION()
        {
            /*" -454- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -454- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -458- DISPLAY ' ' . */
            _.Display($" ");

            /*" -460- DISPLAY '* TOTAL LIDOS         :' AC-LIDOS. */
            _.Display($"* TOTAL LIDOS         :{AREA_DE_WORK.AC_LIDOS}");

            /*" -462- DISPLAY '* TOTAL DE GRAVADOS   :' AC-GRAVADOS. */
            _.Display($"* TOTAL DE GRAVADOS   :{AREA_DE_WORK.AC_GRAVADOS}");

            /*" -464- DISPLAY '* DESPREZ SINISMES    :' DESPREZADOS-SINISMES. */
            _.Display($"* DESPREZ SINISMES    :{DESPREZADOS_SINISMES}");

            /*" -466- DISPLAY '* DESPREZ SEGURVGA    :' DESPREZADOS-SEGURVGA. */
            _.Display($"* DESPREZ SEGURVGA    :{DESPREZADOS_SEGURVGA}");

            /*" -468- DISPLAY '* DESPREZ CLIENTES    :' DESPREZADOS-CLIENTES. */
            _.Display($"* DESPREZ CLIENTES    :{DESPREZADOS_CLIENTES}");

            /*" -470- DISPLAY '* DESPREZ AVISADO     :' DESPREZADOS-AVISADO. */
            _.Display($"* DESPREZ AVISADO     :{DESPREZADOS_AVISADO}");

            /*" -472- DISPLAY '* DESPREZ PESS SINIS  :' DESPREZADOS-PESS-SINIS. */
            _.Display($"* DESPREZ PESS SINIS  :{DESPREZADOS_PESS_SINIS}");

            /*" -474- DISPLAY '* DESPREZ PESS EVENTO :' DESPREZADOS-PESS-EVENTO. */
            _.Display($"* DESPREZ PESS EVENTO :{DESPREZADOS_PESS_EVENTO}");

            /*" -476- DISPLAY '* DESPREZ PESS CONTA  :' DESPREZADOS-PESS-CONTA. */
            _.Display($"* DESPREZ PESS CONTA  :{DESPREZADOS_PESS_CONTA}");

            /*" -478- DISPLAY ' ' . */
            _.Display($" ");

            /*" -480- CLOSE ARQSAIDA. */
            ARQSAIDA.Close();

            /*" -482- DISPLAY '* VA0965B - TERMINO NORMAL       ' . */
            _.Display($"* VA0965B - TERMINO NORMAL       ");

            /*" -482- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -504- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -507- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -508- DISPLAY ' PROBLEMAS NO ACESSO A SISTEMAS' */
                _.Display($" PROBLEMAS NO ACESSO A SISTEMAS");

                /*" -509- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -511- END-IF. */
            }


            /*" -512- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DTH-INI WHOST-DTH-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WHOST_DTH_INI, AREA_DE_WORK.WHOST_DTH_FIM);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -504- EXEC SQL SELECT DATA_MOV_ABERTO , CURRENT_DATE INTO :SISTEMAS-DATA-MOV-ABERTO , :WHOST-CURRENT-DATE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_CURRENT_DATE, WHOST_CURRENT_DATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0150-00-MONTA-PARAMETROS-SECTION */
        private void R0150_00_MONTA_PARAMETROS_SECTION()
        {
            /*" -526- MOVE '0150' TO WNR-EXEC-SQL. */
            _.Move("0150", WABEND.WNR_EXEC_SQL);

            /*" -529- MOVE WPAR-INICIO (1:4) TO WHOST-DTH-INI (1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_INICIO.Substring(1, 4), AREA_DE_WORK.WHOST_DTH_INI, 1, 4);

            /*" -532- MOVE WPAR-INICIO (5:2) TO WHOST-DTH-INI (6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_INICIO.Substring(5, 2), AREA_DE_WORK.WHOST_DTH_INI, 6, 2);

            /*" -535- MOVE WPAR-INICIO (7:2) TO WHOST-DTH-INI (9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_INICIO.Substring(7, 2), AREA_DE_WORK.WHOST_DTH_INI, 9, 2);

            /*" -538- MOVE WPAR-FIM (1:4) TO WHOST-DTH-FIM (1:4) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_FIM.Substring(1, 4), AREA_DE_WORK.WHOST_DTH_FIM, 1, 4);

            /*" -541- MOVE WPAR-FIM (5:2) TO WHOST-DTH-FIM (6:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_FIM.Substring(5, 2), AREA_DE_WORK.WHOST_DTH_FIM, 6, 2);

            /*" -544- MOVE WPAR-FIM (7:2) TO WHOST-DTH-FIM (9:2) */
            _.MoveAtPosition(AREA_DE_WORK.FILLER_7.WPAR_FIM.Substring(7, 2), AREA_DE_WORK.WHOST_DTH_FIM, 9, 2);

            /*" -550- MOVE '-' TO WHOST-DTH-FIM(8:1). */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_FIM, 8, 1);

            /*" -550- MOVE '-' TO WHOST-DTH-FIM(5:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_FIM, 5, 1);

            /*" -550- MOVE '-' TO WHOST-DTH-INI(8:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_INI, 8, 1);

            /*" -550- MOVE '-' TO WHOST-DTH-INI(5:1) */
            _.MoveAtPosition("-", AREA_DE_WORK.WHOST_DTH_INI, 5, 1);

            /*" -551- DISPLAY '***     PARAMETROS  ***' */
            _.Display($"***     PARAMETROS  ***");

            /*" -552- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA. */
            _.Display($"*** TIPO DE ROTINA   {AREA_DE_WORK.FILLER_7.WPAR_ROTINA}");

            /*" -553- DISPLAY '*** DATA DE INICIO   ' WHOST-DTH-INI. */
            _.Display($"*** DATA DE INICIO   {AREA_DE_WORK.WHOST_DTH_INI}");

            /*" -553- DISPLAY '*** DATA DE FIM      ' WHOST-DTH-FIM. */
            _.Display($"*** DATA DE FIM      {AREA_DE_WORK.WHOST_DTH_FIM}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_99_SAIDA*/

        [StopWatch]
        /*" R0160-00-CONSISTE-DATA-SECTION */
        private void R0160_00_CONSISTE_DATA_SECTION()
        {
            /*" -566- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", WABEND.WNR_EXEC_SQL);

            /*" -568- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", AREA_DE_WORK.WS_ERRO_DATA);

            /*" -570- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -571- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -572- GO TO R0160-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;

                /*" -574- END-IF. */
            }


            /*" -577- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -578- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -579- GO TO R0160-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;

                /*" -581- END-IF */
            }


            /*" -583- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -584- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                /*" -585- GO TO R0160-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                return;

                /*" -587- END-IF. */
            }


            /*" -590- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -591- IF WS-CRITICA-DIA GREATER 31 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -592- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -593- GO TO R0160-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                    return;

                    /*" -595- END-IF. */
                }

            }


            /*" -596- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -597- IF WS-CRITICA-DIA GREATER 30 */

                if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -598- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                    /*" -599- GO TO R0160-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                    return;

                    /*" -600- END-IF */
                }


                /*" -602- END-IF. */
            }


            /*" -603- IF WS-CRITICA-MES EQUAL 02 */

            if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -607- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                _.Divide(AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, AREA_DE_WORK.AUX_RESULTADO, AREA_DE_WORK.AUX_RESTO);

                /*" -608- IF AUX-RESTO EQUAL ZEROS */

                if (AREA_DE_WORK.AUX_RESTO == 00)
                {

                    /*" -609- IF WS-CRITICA-DIA GREATER 29 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -610- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -611- GO TO R0160-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                        return;

                        /*" -612- END-IF */
                    }


                    /*" -613- ELSE */
                }
                else
                {


                    /*" -614- IF WS-CRITICA-DIA GREATER 28 */

                    if (AREA_DE_WORK.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -615- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", AREA_DE_WORK.WS_ERRO_DATA);

                        /*" -616- GO TO R0160-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/ //GOTO
                        return;

                        /*" -617- END-IF */
                    }


                    /*" -618- END-IF */
                }


                /*" -618- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0160_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-SECTION */
        private void R0900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -631- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -649- PERFORM R0900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R0900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -651- PERFORM R0900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R0900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -654- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -655- DISPLAY 'PROBLEMA NO CURSOR SINISHIS.' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS.");

                /*" -656- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -656- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R0900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -649- EXEC SQL DECLARE C01_SINISHIS CURSOR FOR SELECT DISTINCT NUM_APOL_SINISTRO FROM SEGUROS.SINISTRO_HISTORICO WHERE DATA_MOVIMENTO BETWEEN :WHOST-DTH-INI AND :WHOST-DTH-FIM AND COD_OPERACAO IN (1181, 1182, 1183, 1184) AND COD_PRODUTO IN (8201, 9327, 9301, 9311, 9318, 9319, 9320, 9321, 9322, 9325, 9326, 9327, 9701, 9702, 9703, 9704, 9705, 9712, :JVPRD9327, :JVPRD9320, :JVPRD9311, :JVPRD9321, :JVPRD9327) ORDER BY NUM_APOL_SINISTRO END-EXEC. */
            C01_SINISHIS = new VA0965B_C01_SINISHIS(true);
            string GetQuery_C01_SINISHIS()
            {
                var query = @$"SELECT DISTINCT 
							NUM_APOL_SINISTRO 
							FROM 
							SEGUROS.SINISTRO_HISTORICO 
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
            /*" -651- EXEC SQL OPEN C01_SINISHIS END-EXEC. */

            C01_SINISHIS.Open();

        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-DECLARE-1 */
        public void R1900_00_DECLARE_CURSOR_DB_DECLARE_1()
        {
            /*" -1121- EXEC SQL DECLARE SINISHIS1 CURSOR FOR SELECT VAL_OPERACAO , NOME_FAVORECIDO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */
            SINISHIS1 = new VA0965B_SINISHIS1(true);
            string GetQuery_SINISHIS1()
            {
                var query = @$"SELECT 
							VAL_OPERACAO
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
            /*" -670- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R0910_00_FETCH_CURSOR_DB_FETCH_1 */

            R0910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -677- PERFORM R0910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R0910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -679- MOVE 'S' TO WFIM-SINISHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS);

                    /*" -680- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -681- ELSE */
                }
                else
                {


                    /*" -682- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS");

                    /*" -684- DISPLAY ' APOLICE SINISTRO ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($" APOLICE SINISTRO {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -685- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -686- END-IF */
                }


                /*" -688- END-IF. */
            }


            /*" -690- ADD 1 TO AC-CONTA. */
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -691- IF AC-CONTA GREATER 9999 */

            if (AREA_DE_WORK.AC_CONTA > 9999)
            {

                /*" -692- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -693- ACCEPT AUX-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.AUX_TIME);

                /*" -697- DISPLAY 'LIDOS SINISHIS ....: ' AC-LIDOS AUX-TIME SINISHIS-NUM-APOL-SINISTRO */

                $"LIDOS SINISHIS ....: {AREA_DE_WORK.AC_LIDOS}{AREA_DE_WORK.AUX_TIME}{SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}"
                .Display();

                /*" -697- END-IF. */
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R0910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -673- EXEC SQL FETCH C01_SINISHIS INTO :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            if (C01_SINISHIS.Fetch())
            {
                _.Move(C01_SINISHIS.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R0910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -677- EXEC SQL CLOSE C01_SINISHIS END-EXEC */

            C01_SINISHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-SINISHIS-SECTION */
        private void R1000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -711- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -713- PERFORM R1100-00-SELECT-SINISMES. */

            R1100_00_SELECT_SINISMES_SECTION();

            /*" -714- IF WTEM-SINISMES NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_SINISMES != "S")
            {

                /*" -715- ADD 1 TO DESPREZADOS-SINISMES */
                DESPREZADOS_SINISMES.Value = DESPREZADOS_SINISMES + 1;

                /*" -716- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -718- END-IF. */
            }


            /*" -720- PERFORM R1200-00-SELECT-SEGURVGA. */

            R1200_00_SELECT_SEGURVGA_SECTION();

            /*" -721- IF WTEM-SEGURVGA NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_SEGURVGA != "S")
            {

                /*" -722- ADD 1 TO DESPREZADOS-SEGURVGA */
                DESPREZADOS_SEGURVGA.Value = DESPREZADOS_SEGURVGA + 1;

                /*" -723- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -725- END-IF. */
            }


            /*" -727- PERFORM R1300-00-SELECT-CLIENTES. */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -728- IF WTEM-CLIENTES NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_CLIENTES != "S")
            {

                /*" -729- ADD 1 TO DESPREZADOS-CLIENTES */
                DESPREZADOS_CLIENTES.Value = DESPREZADOS_CLIENTES + 1;

                /*" -730- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -732- END-IF. */
            }


            /*" -734- PERFORM R1400-00-SELECT-SINISHIS. */

            R1400_00_SELECT_SINISHIS_SECTION();

            /*" -735- IF WTEM-SINISHIS NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_SINISHIS != "S")
            {

                /*" -736- ADD 1 TO DESPREZADOS-AVISADO */
                DESPREZADOS_AVISADO.Value = DESPREZADOS_AVISADO + 1;

                /*" -737- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -739- END-IF. */
            }


            /*" -741- PERFORM R1500-00-SELECT-MAX-OCORR. */

            R1500_00_SELECT_MAX_OCORR_SECTION();

            /*" -743- PERFORM R1600-00-SELECT-SI175. */

            R1600_00_SELECT_SI175_SECTION();

            /*" -744- IF WTEM-VARIAVEL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_VARIAVEL != "S")
            {

                /*" -745- ADD 1 TO DESPREZADOS-PESS-SINIS */
                DESPREZADOS_PESS_SINIS.Value = DESPREZADOS_PESS_SINIS + 1;

                /*" -746- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -748- END-IF. */
            }


            /*" -750- PERFORM R1700-00-SELECT-GE368. */

            R1700_00_SELECT_GE368_SECTION();

            /*" -751- IF WTEM-VARIAVEL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_VARIAVEL != "S")
            {

                /*" -752- ADD 1 TO DESPREZADOS-PESS-EVENTO */
                DESPREZADOS_PESS_EVENTO.Value = DESPREZADOS_PESS_EVENTO + 1;

                /*" -753- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -755- END-IF. */
            }


            /*" -757- PERFORM R1800-00-SELECT-OD009. */

            R1800_00_SELECT_OD009_SECTION();

            /*" -758- IF WTEM-VARIAVEL NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_VARIAVEL != "S")
            {

                /*" -759- ADD 1 TO DESPREZADOS-PESS-CONTA */
                DESPREZADOS_PESS_CONTA.Value = DESPREZADOS_PESS_CONTA + 1;

                /*" -760- GO TO R1000-10-NEXT */

                R1000_10_NEXT(); //GOTO
                return;

                /*" -762- END-IF. */
            }


            /*" -765- MOVE OD009-COD-BANCO TO LD02-BANCO. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO, LD02.LD02_BANCO);

            /*" -768- MOVE OD009-COD-AGENCIA TO LD02-AGENCIA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA, LD02.LD02_AGENCIA);

            /*" -771- MOVE OD009-NUM-OPERACAO-CONTA TO LD02-OPERACAO. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA, LD02.LD02_OPERACAO);

            /*" -774- MOVE OD009-NUM-CONTA TO LD02-CONTA. */
            _.Move(OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA, LD02.LD02_CONTA);

            /*" -777- MOVE SINISHIS-NUM-APOL-SINISTRO TO LD02-NUM-APOL-SINISTRO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LD02.LD02_NUM_APOL_SINISTRO);

            /*" -780- MOVE CLIENTES-NOME-RAZAO TO LD02-NOME-RAZAO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD02.LD02_NOME_RAZAO);

            /*" -783- MOVE CLIENTES-CGCCPF TO LD02-CGCCPF-CNPJ. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LD02.LD02_CGCCPF_CNPJ);

            /*" -787- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-AVISADO WHOST-VAL-AVISADO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_AVISADO, WHOST_VAL_AVISADO);

            /*" -790- MOVE 'N' TO WFIM-SINISHIS1. */
            _.Move("N", AREA_DE_WORK.WFIM_SINISHIS1);

            /*" -792- PERFORM R1900-00-DECLARE-CURSOR. */

            R1900_00_DECLARE_CURSOR_SECTION();

            /*" -794- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

            /*" -795- IF WFIM-SINISHIS1 EQUAL 'S' */

            if (AREA_DE_WORK.WFIM_SINISHIS1 == "S")
            {

                /*" -796- ADD 1 TO DESPREZADOS-SINISMES */
                DESPREZADOS_SINISMES.Value = DESPREZADOS_SINISMES + 1;

                /*" -798- END-IF. */
            }


            /*" -799- PERFORM R2000-00-PROCESSA-SINISHIS UNTIL WFIM-SINISHIS1 EQUAL 'S' . */

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
            /*" -803- PERFORM R0910-00-FETCH-CURSOR. */

            R0910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-SECTION */
        private void R1100_00_SELECT_SINISMES_SECTION()
        {
            /*" -817- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -819- MOVE 'S' TO WTEM-SINISMES. */
            _.Move("S", AREA_DE_WORK.WTEM_SINISMES);

            /*" -830- PERFORM R1100_00_SELECT_SINISMES_DB_SELECT_1 */

            R1100_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -833- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -834- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -835- MOVE 'N' TO WTEM-SINISMES */
                    _.Move("N", AREA_DE_WORK.WTEM_SINISMES);

                    /*" -836- ELSE */
                }
                else
                {


                    /*" -837- DISPLAY 'PROBLEMAS NA R1100-00-SELECT-SINISMES' */
                    _.Display($"PROBLEMAS NA R1100-00-SELECT-SINISMES");

                    /*" -838- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -839- END-IF */
                }


                /*" -839- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R1100_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -830- EXEC SQL SELECT NUM_CERTIFICADO INTO :SINISMES-NUM-CERTIFICADO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND NUM_CERTIFICADO <> 0 END-EXEC. */

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
            /*" -852- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -854- MOVE 'S' TO WTEM-SEGURVGA. */
            _.Move("S", AREA_DE_WORK.WTEM_SEGURVGA);

            /*" -869- PERFORM R1200_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1200_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -872- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -873- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -874- MOVE 'N' TO WTEM-SEGURVGA */
                    _.Move("N", AREA_DE_WORK.WTEM_SEGURVGA);

                    /*" -875- ELSE */
                }
                else
                {


                    /*" -876- DISPLAY 'PROBLEMAS NA R1200-00-SELECT-SEGURVGA' */
                    _.Display($"PROBLEMAS NA R1200-00-SELECT-SEGURVGA");

                    /*" -877- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -878- END-IF */
                }


                /*" -878- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1200_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -869- EXEC SQL SELECT NUM_CERTIFICADO, NUM_APOLICE , COD_CLIENTE INTO :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-NUM-APOLICE , :SEGURVGA-COD-CLIENTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-SECTION */
        private void R1300_00_SELECT_CLIENTES_SECTION()
        {
            /*" -892- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -894- MOVE 'S' TO WTEM-CLIENTES. */
            _.Move("S", AREA_DE_WORK.WTEM_CLIENTES);

            /*" -906- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -909- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -910- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -911- MOVE 'N' TO WTEM-CLIENTES */
                    _.Move("N", AREA_DE_WORK.WTEM_CLIENTES);

                    /*" -912- ELSE */
                }
                else
                {


                    /*" -913- DISPLAY 'PROBLEMAS NA R1300-00-SELECT-CLIENTES' */
                    _.Display($"PROBLEMAS NA R1300-00-SELECT-CLIENTES");

                    /*" -914- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -915- END-IF */
                }


                /*" -915- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -906- EXEC SQL SELECT NOME_RAZAO , CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

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
            /*" -929- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -931- MOVE 'S' TO WTEM-SINISHIS */
            _.Move("S", AREA_DE_WORK.WTEM_SINISHIS);

            /*" -941- PERFORM R1400_00_SELECT_SINISHIS_DB_SELECT_1 */

            R1400_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -944- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -945- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -946- MOVE 'N' TO WTEM-SINISHIS */
                    _.Move("N", AREA_DE_WORK.WTEM_SINISHIS);

                    /*" -947- ELSE */
                }
                else
                {


                    /*" -948- DISPLAY 'PROBLEMAS NA R1400-00-SELECT-SINIHIS' */
                    _.Display($"PROBLEMAS NA R1400-00-SELECT-SINIHIS");

                    /*" -949- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -950- END-IF */
                }


                /*" -950- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R1400_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -941- EXEC SQL SELECT VAL_OPERACAO AS VAL_AVISADO INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO = 101 END-EXEC. */

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
        /*" R1500-00-SELECT-MAX-OCORR-SECTION */
        private void R1500_00_SELECT_MAX_OCORR_SECTION()
        {
            /*" -964- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -966- MOVE 'S' TO WTEM-SINISTRO. */
            _.Move("S", AREA_DE_WORK.WTEM_SINISTRO);

            /*" -972- PERFORM R1500_00_SELECT_MAX_OCORR_DB_SELECT_1 */

            R1500_00_SELECT_MAX_OCORR_DB_SELECT_1();

            /*" -975- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -976- DISPLAY 'PROBLEMAS NA R1500-00-SELECT-MAX-OCORR' */
                _.Display($"PROBLEMAS NA R1500-00-SELECT-MAX-OCORR");

                /*" -977- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -979- END-IF. */
            }


            /*" -980- MOVE WHOST-MAX-OCORR TO SINISHIS-OCORR-HISTORICO. */
            _.Move(WHOST_MAX_OCORR, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

        }

        [StopWatch]
        /*" R1500-00-SELECT-MAX-OCORR-DB-SELECT-1 */
        public void R1500_00_SELECT_MAX_OCORR_DB_SELECT_1()
        {
            /*" -972- EXEC SQL SELECT MAX(OCORR_HISTORICO) INTO :WHOST-MAX-OCORR FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO END-EXEC. */

            var r1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1 = new R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1.Execute(r1500_00_SELECT_MAX_OCORR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_MAX_OCORR, WHOST_MAX_OCORR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-SI175-SECTION */
        private void R1600_00_SELECT_SI175_SECTION()
        {
            /*" -994- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -996- MOVE 'S' TO WTEM-VARIAVEL. */
            _.Move("S", AREA_DE_WORK.WTEM_VARIAVEL);

            /*" -1014- PERFORM R1600_00_SELECT_SI175_DB_SELECT_1 */

            R1600_00_SELECT_SI175_DB_SELECT_1();

            /*" -1017- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1018- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1019- MOVE 'N' TO WTEM-VARIAVEL */
                    _.Move("N", AREA_DE_WORK.WTEM_VARIAVEL);

                    /*" -1020- ELSE */
                }
                else
                {


                    /*" -1021- DISPLAY 'PROBLEMAS NA R1600-00-SELECT-SI175' */
                    _.Display($"PROBLEMAS NA R1600-00-SELECT-SI175");

                    /*" -1022- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1023- END-IF */
                }


                /*" -1025- END-IF. */
            }


            /*" -1026- MOVE SI175-NUM-OCORR-MOVTO TO WHOST-NUM-OCORR-MOVTO. */
            _.Move(SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO, WHOST_NUM_OCORR_MOVTO);

        }

        [StopWatch]
        /*" R1600-00-SELECT-SI175-DB-SELECT-1 */
        public void R1600_00_SELECT_SI175_DB_SELECT_1()
        {
            /*" -1014- EXEC SQL SELECT NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , NUM_OCORR_MOVTO INTO :SI175-NUM-APOL-SINISTRO , :SI175-OCORR-HISTORICO , :SI175-COD-OPERACAO , :SI175-NUM-OCORR-MOVTO FROM SEGUROS.SI_PESS_SINISTRO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */

            var r1600_00_SELECT_SI175_DB_SELECT_1_Query1 = new R1600_00_SELECT_SI175_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_SI175_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_SI175_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI175_NUM_APOL_SINISTRO, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_APOL_SINISTRO);
                _.Move(executed_1.SI175_OCORR_HISTORICO, SI175.DCLSI_PESS_SINISTRO.SI175_OCORR_HISTORICO);
                _.Move(executed_1.SI175_COD_OPERACAO, SI175.DCLSI_PESS_SINISTRO.SI175_COD_OPERACAO);
                _.Move(executed_1.SI175_NUM_OCORR_MOVTO, SI175.DCLSI_PESS_SINISTRO.SI175_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-GE368-SECTION */
        private void R1700_00_SELECT_GE368_SECTION()
        {
            /*" -1040- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -1042- MOVE 'S' TO WTEM-VARIAVEL. */
            _.Move("S", AREA_DE_WORK.WTEM_VARIAVEL);

            /*" -1052- PERFORM R1700_00_SELECT_GE368_DB_SELECT_1 */

            R1700_00_SELECT_GE368_DB_SELECT_1();

            /*" -1055- IF SQLCODE NOT EQUAL ZEROS AND -811 */

            if (!DB.SQLCODE.In("00", "-811"))
            {

                /*" -1056- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1057- MOVE 'N' TO WTEM-VARIAVEL */
                    _.Move("N", AREA_DE_WORK.WTEM_VARIAVEL);

                    /*" -1058- ELSE */
                }
                else
                {


                    /*" -1059- DISPLAY 'PROBLEMAS NA R1700-00-SELECT-GE368' */
                    _.Display($"PROBLEMAS NA R1700-00-SELECT-GE368");

                    /*" -1060- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1060- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-GE368-DB-SELECT-1 */
        public void R1700_00_SELECT_GE368_DB_SELECT_1()
        {
            /*" -1052- EXEC SQL SELECT IND_ENTIDADE , NUM_PESSOA , SEQ_ENTIDADE INTO :GE368-IND-ENTIDADE , :GE368-NUM-PESSOA , :GE368-SEQ-ENTIDADE FROM SEGUROS.GE_LEG_PESS_EVENTO WHERE NUM_OCORR_MOVTO = :WHOST-NUM-OCORR-MOVTO END-EXEC. */

            var r1700_00_SELECT_GE368_DB_SELECT_1_Query1 = new R1700_00_SELECT_GE368_DB_SELECT_1_Query1()
            {
                WHOST_NUM_OCORR_MOVTO = WHOST_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R1700_00_SELECT_GE368_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_GE368_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE368_IND_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_IND_ENTIDADE);
                _.Move(executed_1.GE368_NUM_PESSOA, GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA);
                _.Move(executed_1.GE368_SEQ_ENTIDADE, GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-SELECT-OD009-SECTION */
        private void R1800_00_SELECT_OD009_SECTION()
        {
            /*" -1074- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -1076- MOVE 'S' TO WTEM-VARIAVEL. */
            _.Move("S", AREA_DE_WORK.WTEM_VARIAVEL);

            /*" -1089- PERFORM R1800_00_SELECT_OD009_DB_SELECT_1 */

            R1800_00_SELECT_OD009_DB_SELECT_1();

            /*" -1092- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1093- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1094- MOVE 'N' TO WTEM-VARIAVEL */
                    _.Move("N", AREA_DE_WORK.WTEM_VARIAVEL);

                    /*" -1095- ELSE */
                }
                else
                {


                    /*" -1096- DISPLAY 'PROBLEMAS NA R1800-00-SELECT-OD009' */
                    _.Display($"PROBLEMAS NA R1800-00-SELECT-OD009");

                    /*" -1097- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1098- END-IF */
                }


                /*" -1098- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-SELECT-OD009-DB-SELECT-1 */
        public void R1800_00_SELECT_OD009_DB_SELECT_1()
        {
            /*" -1089- EXEC SQL SELECT COD_BANCO , COD_AGENCIA , NUM_OPERACAO_CONTA , NUM_CONTA INTO :OD009-COD-BANCO , :OD009-COD-AGENCIA , :OD009-NUM-OPERACAO-CONTA, :OD009-NUM-CONTA FROM ODS.OD_PESS_CONTA_BANC WHERE NUM_PESSOA = :GE368-NUM-PESSOA AND SEQ_CONTA_BANCARIA = :GE368-SEQ-ENTIDADE END-EXEC. */

            var r1800_00_SELECT_OD009_DB_SELECT_1_Query1 = new R1800_00_SELECT_OD009_DB_SELECT_1_Query1()
            {
                GE368_SEQ_ENTIDADE = GE368.DCLGE_LEG_PESS_EVENTO.GE368_SEQ_ENTIDADE.ToString(),
                GE368_NUM_PESSOA = GE368.DCLGE_LEG_PESS_EVENTO.GE368_NUM_PESSOA.ToString(),
            };

            var executed_1 = R1800_00_SELECT_OD009_DB_SELECT_1_Query1.Execute(r1800_00_SELECT_OD009_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OD009_COD_BANCO, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_BANCO);
                _.Move(executed_1.OD009_COD_AGENCIA, OD009.DCLOD_PESS_CONTA_BANC.OD009_COD_AGENCIA);
                _.Move(executed_1.OD009_NUM_OPERACAO_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_OPERACAO_CONTA);
                _.Move(executed_1.OD009_NUM_CONTA, OD009.DCLOD_PESS_CONTA_BANC.OD009_NUM_CONTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-SECTION */
        private void R1900_00_DECLARE_CURSOR_SECTION()
        {
            /*" -1112- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -1121- PERFORM R1900_00_DECLARE_CURSOR_DB_DECLARE_1 */

            R1900_00_DECLARE_CURSOR_DB_DECLARE_1();

            /*" -1123- PERFORM R1900_00_DECLARE_CURSOR_DB_OPEN_1 */

            R1900_00_DECLARE_CURSOR_DB_OPEN_1();

            /*" -1126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1127- DISPLAY 'PROBLEMA NO CURSOR SINISHIS1 ' */
                _.Display($"PROBLEMA NO CURSOR SINISHIS1 ");

                /*" -1128- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1128- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-DECLARE-CURSOR-DB-OPEN-1 */
        public void R1900_00_DECLARE_CURSOR_DB_OPEN_1()
        {
            /*" -1123- EXEC SQL OPEN SINISHIS1 END-EXEC. */

            SINISHIS1.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-SECTION */
        private void R1910_00_FETCH_CURSOR_SECTION()
        {
            /*" -1142- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", WABEND.WNR_EXEC_SQL);

            /*" -1146- PERFORM R1910_00_FETCH_CURSOR_DB_FETCH_1 */

            R1910_00_FETCH_CURSOR_DB_FETCH_1();

            /*" -1149- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1150- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1150- PERFORM R1910_00_FETCH_CURSOR_DB_CLOSE_1 */

                    R1910_00_FETCH_CURSOR_DB_CLOSE_1();

                    /*" -1152- MOVE 'S' TO WFIM-SINISHIS1 */
                    _.Move("S", AREA_DE_WORK.WFIM_SINISHIS1);

                    /*" -1153- GO TO R1910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1154- ELSE */
                }
                else
                {


                    /*" -1155- DISPLAY ' PROBLEMAS NO FETCH DA SINISHIS1' */
                    _.Display($" PROBLEMAS NO FETCH DA SINISHIS1");

                    /*" -1156- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1157- END-IF */
                }


                /*" -1159- END-IF. */
            }


            /*" -1159- ADD 1 TO AC-LIDOS. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-FETCH-1 */
        public void R1910_00_FETCH_CURSOR_DB_FETCH_1()
        {
            /*" -1146- EXEC SQL FETCH SINISHIS1 INTO :SINISHIS-VAL-OPERACAO , :SINISHIS-NOME-FAVORECIDO END-EXEC. */

            if (SINISHIS1.Fetch())
            {
                _.Move(SINISHIS1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
                _.Move(SINISHIS1.SINISHIS_NOME_FAVORECIDO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO);
            }

        }

        [StopWatch]
        /*" R1910-00-FETCH-CURSOR-DB-CLOSE-1 */
        public void R1910_00_FETCH_CURSOR_DB_CLOSE_1()
        {
            /*" -1150- EXEC SQL CLOSE SINISHIS1 END-EXEC */

            SINISHIS1.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SINISHIS-SECTION */
        private void R2000_00_PROCESSA_SINISHIS_SECTION()
        {
            /*" -1173- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1176- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-OPER. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_OPER);

            /*" -1179- MOVE SINISHIS-NOME-FAVORECIDO TO LD02-NOME-BENEFICIARIO. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NOME_FAVORECIDO, LD02.LD02_NOME_BENEFICIARIO);

            /*" -1182- MOVE ZEROS TO LD02-CPF-BENEFICIARIO. */
            _.Move(0, LD02.LD02_CPF_BENEFICIARIO);

            /*" -1184- PERFORM R2100-00-SELECT-SINISHIS. */

            R2100_00_SELECT_SINISHIS_SECTION();

            /*" -1186- PERFORM R2200-00-SELECT-SI155. */

            R2200_00_SELECT_SI155_SECTION();

            /*" -1189- COMPUTE WHOST-VAL-DIFERENCA = SI155-VLR-CORRECAO + SI155-VLR-MULTA. */
            WHOST_VAL_DIFERENCA.Value = SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_CORRECAO + SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_MULTA;

            /*" -1192- MOVE WHOST-VAL-DIFERENCA TO LD02-VAL-DIFERENCA. */
            _.Move(WHOST_VAL_DIFERENCA, LD02.LD02_VAL_DIFERENCA);

            /*" -1195- MOVE SINISHIS-VAL-OPERACAO TO LD02-VAL-TOT-PRE-LIB. */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO, LD02.LD02_VAL_TOT_PRE_LIB);

            /*" -1197- WRITE REG-SAIDA FROM LD02. */
            _.Move(LD02.GetMoveValues(), REG_SAIDA);

            ARQSAIDA.Write(REG_SAIDA.GetMoveValues().ToString());

            /*" -1197- ADD 1 TO AC-GRAVADOS. */
            AREA_DE_WORK.AC_GRAVADOS.Value = AREA_DE_WORK.AC_GRAVADOS + 1;

            /*" -0- FLUXCONTROL_PERFORM R2000_10_NEXT */

            R2000_10_NEXT();

        }

        [StopWatch]
        /*" R2000-10-NEXT */
        private void R2000_10_NEXT(bool isPerform = false)
        {
            /*" -1201- PERFORM R1910-00-FETCH-CURSOR. */

            R1910_00_FETCH_CURSOR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-SINISHIS-SECTION */
        private void R2100_00_SELECT_SINISHIS_SECTION()
        {
            /*" -1215- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1225- PERFORM R2100_00_SELECT_SINISHIS_DB_SELECT_1 */

            R2100_00_SELECT_SINISHIS_DB_SELECT_1();

            /*" -1228- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1229- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1229- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-SINISHIS-DB-SELECT-1 */
        public void R2100_00_SELECT_SINISHIS_DB_SELECT_1()
        {
            /*" -1225- EXEC SQL SELECT SUM (VAL_OPERACAO) AS VAL_TOT_PRE_LIB INTO :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */

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
        /*" R2200-00-SELECT-SI155-SECTION */
        private void R2200_00_SELECT_SI155_SECTION()
        {
            /*" -1243- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1246- INITIALIZE SI155-VLR-CORRECAO SI155-VLR-MULTA. */
            _.Initialize(
                SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_CORRECAO
                , SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_MULTA
            );

            /*" -1259- PERFORM R2200_00_SELECT_SI155_DB_SELECT_1 */

            R2200_00_SELECT_SI155_DB_SELECT_1();

            /*" -1262- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1263- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1265- MOVE ZEROS TO SI155-VLR-CORRECAO SI155-VLR-MULTA */
                    _.Move(0, SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_CORRECAO, SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_MULTA);

                    /*" -1266- ELSE */
                }
                else
                {


                    /*" -1267- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1268- END-IF */
                }


                /*" -1268- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-SELECT-SI155-DB-SELECT-1 */
        public void R2200_00_SELECT_SI155_DB_SELECT_1()
        {
            /*" -1259- EXEC SQL SELECT VLR_CORRECAO , VLR_MULTA INTO :SI155-VLR-CORRECAO , :SI155-VLR-MULTA FROM SEGUROS.SI_MOV_HABIT_PAR WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :WHOST-MAX-OCORR AND COD_OPERACAO IN (1181, 1182, 1183, 1184) END-EXEC. */

            var r2200_00_SELECT_SI155_DB_SELECT_1_Query1 = new R2200_00_SELECT_SI155_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                WHOST_MAX_OCORR = WHOST_MAX_OCORR.ToString(),
            };

            var executed_1 = R2200_00_SELECT_SI155_DB_SELECT_1_Query1.Execute(r2200_00_SELECT_SI155_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SI155_VLR_CORRECAO, SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_CORRECAO);
                _.Move(executed_1.SI155_VLR_MULTA, SI155.DCLSI_MOV_HABIT_PAR.SI155_VLR_MULTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1282- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1284- DISPLAY WABEND */
            _.Display(WABEND);

            /*" -1284- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1286- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1290- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1290- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}