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
using Sias.Sinistro.DB2.SI0868B;

namespace Code
{
    public class SI0868B
    {
        public bool IsCall { get; set; }

        public SI0868B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0868B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  LUIS RICARDO                       *      */
        /*"      *   CRIACAO ................  03/06/2002.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERAR RELATORIO DE SINISTROS PENDENTES POR      *      */
        /*"      *    DATA E RAMO INFORMADOS PELO USUARIO A PARTIR DA TRANSACAO   *      */
        /*"      *    ON LINE 13-12-33(APLICA  O SI1FA)                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 03 - CAD 10.003                                       *      */
        /*"      *                                                                *      */
        /*"      *              - CONVERSAO DO DB2 PARA A VERSAO 10               *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/09/2013 -  CLAUDIO FREITAS                             *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.03    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 28/04/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      * SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO     *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_ARQ_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_ARQ_SAIDA, _ARQ_SAIDA, REG_ARQ_SAIDA); return _ARQ_SAIDA;
            }
        }
        /*"01  REG-ARQ-SAIDA                  PIC X(400).*/
        public StringBasis REG_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77  HOST-VALOR-AVISO-SIAS       PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_VALOR_AVISO_SIAS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-AVISADO                PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-PAGO                   PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-PENDENTE               PIC S9(13)V99 COMP-3 VALUE +0.*/
        public DoubleBasis HOST_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77  HOST-APOL-INICIO            PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_APOL_INICIO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-APOL-FIM               PIC S9(13)    COMP-3 VALUE +0.*/
        public IntBasis HOST_APOL_FIM { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  HOST-SG1                    PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis HOST_SG1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-SG2                    PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis HOST_SG2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-DATA-AVISO-SIAS        PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA_AVISO_SIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  HOST-RAMO                   PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis HOST_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  HOST-DATA                   PIC  X(10) VALUE SPACES.*/
        public StringBasis HOST_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  IND-NULL                    PIC S9(04)    COMP   VALUE +0.*/
        public IntBasis IND_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  WIND-PCS-RAMO               PIC  X(03) VALUE 'NAO'.*/
        public StringBasis WIND_PCS_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  WIND-PCS-PRODUTO            PIC  X(03) VALUE 'NAO'.*/
        public StringBasis WIND_PCS_PRODUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  WIND-PCS-RAMOVG             PIC  X(03) VALUE 'NAO'.*/
        public StringBasis WIND_PCS_RAMOVG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  WIND-PCS-APOLICE            PIC  X(03) VALUE 'NAO'.*/
        public StringBasis WIND_PCS_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
        /*"77  W-GDA-RAMO                  PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-COD-PRODUTO           PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-APOLICE               PIC S9(13)    COMP-3 VALUE 0.*/
        public IntBasis W_GDA_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-GDA-SINISTRO              PIC S9(13)    COMP-3 VALUE 0.*/
        public IntBasis W_GDA_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  W-GDA-TIPO-REGISTRO         PIC  X(01) VALUE SPACE.*/
        public StringBasis W_GDA_TIPO_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  W-GDA-SUBGRUPO              PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-COD-CAUSA             PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-DATA-COMUNICADO       PIC  X(10) VALUE SPACES.*/
        public StringBasis W_GDA_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-DATA-OCORRENCIA       PIC  X(10) VALUE SPACES.*/
        public StringBasis W_GDA_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-SIT-REGISTRO          PIC  X(01) VALUE SPACE.*/
        public StringBasis W_GDA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  W-GDA-FONTE-EMIS            PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_FONTE_EMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-FONTE-SINI            PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_FONTE_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-DESCR-PRODUTO         PIC  X(40) VALUE SPACES.*/
        public StringBasis W_GDA_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  W-GDA-DESCR-CAUSA           PIC  X(40) VALUE SPACES.*/
        public StringBasis W_GDA_DESCR_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  W-SBS-FONTES                PIC  9(04) VALUE 0.*/
        public IntBasis W_SBS_FONTES { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-SBS-PRODUTOS              PIC  9(04) VALUE 0.*/
        public IntBasis W_SBS_PRODUTOS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"77  W-SBS-CAUSAS                PIC  9(04) VALUE 0.*/
        public IntBasis W_SBS_CAUSAS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
        /*"01  AREA-DE-WORK.*/
        public SI0868B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0868B_AREA_DE_WORK();
        public class SI0868B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"01  W-TABELA-FONTES.*/
        }
        public SI0868B_W_TABELA_FONTES W_TABELA_FONTES { get; set; } = new SI0868B_W_TABELA_FONTES();
        public class SI0868B_W_TABELA_FONTES : VarBasis
        {
            /*"    03  W-TAB-FONTES OCCURS 200 TIMES.*/
            public ListBasis<SI0868B_W_TAB_FONTES> W_TAB_FONTES { get; set; } = new ListBasis<SI0868B_W_TAB_FONTES>(200);
            public class SI0868B_W_TAB_FONTES : VarBasis
            {
                /*"        05 W-TAB-COD-FONTE            PIC 9(04).*/
                public IntBasis W_TAB_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"        05 W-TAB-DESCR-FONTE          PIC X(40).*/
                public StringBasis W_TAB_DESCR_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"01  W-TABELA-PRODUTOS.*/
            }
        }
        public SI0868B_W_TABELA_PRODUTOS W_TABELA_PRODUTOS { get; set; } = new SI0868B_W_TABELA_PRODUTOS();
        public class SI0868B_W_TABELA_PRODUTOS : VarBasis
        {
            /*"    03  W-TAB-PRODUTOS OCCURS 500 TIMES.*/
            public ListBasis<SI0868B_W_TAB_PRODUTOS> W_TAB_PRODUTOS { get; set; } = new ListBasis<SI0868B_W_TAB_PRODUTOS>(500);
            public class SI0868B_W_TAB_PRODUTOS : VarBasis
            {
                /*"        05 W-TAB-COD-PRODUTO          PIC 9(04)  VALUE 0.*/
                public IntBasis W_TAB_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05 W-TAB-DESCR-PRODUTO        PIC X(40)  VALUE SPACES.*/
                public StringBasis W_TAB_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"01  W-TABELA-CAUSAS.*/
            }
        }
        public SI0868B_W_TABELA_CAUSAS W_TABELA_CAUSAS { get; set; } = new SI0868B_W_TABELA_CAUSAS();
        public class SI0868B_W_TABELA_CAUSAS : VarBasis
        {
            /*"    03  W-TAB-CAUSAS OCCURS 500 TIMES.*/
            public ListBasis<SI0868B_W_TAB_CAUSAS> W_TAB_CAUSAS { get; set; } = new ListBasis<SI0868B_W_TAB_CAUSAS>(500);
            public class SI0868B_W_TAB_CAUSAS : VarBasis
            {
                /*"        05 W-TAB-COD-CAUSA            PIC 9(04)  VALUE 0.*/
                public IntBasis W_TAB_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05 W-TAB-RAMO-EMISSOR         PIC 9(04)  VALUE 0.*/
                public IntBasis W_TAB_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"        05 W-TAB-DESCR-CAUSA          PIC X(40)  VALUE SPACES.*/
                public StringBasis W_TAB_DESCR_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"01  W-INICIO-WORK.*/
            }
        }
        public SI0868B_W_INICIO_WORK W_INICIO_WORK { get; set; } = new SI0868B_W_INICIO_WORK();
        public class SI0868B_W_INICIO_WORK : VarBasis
        {
            /*"    03 W-FIM-RELATORIO                PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-CURSOR                   PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_CURSOR { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-FONTES                   PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_FONTES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-PRODUTOS                 PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_PRODUTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-CAUSAS                   PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_CAUSAS { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-FONTE                    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_IND_FONTE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-PRODUTO                  PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_IND_PRODUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-IND-CAUSA                    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_IND_CAUSA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CHAVE-ARQ-SAIDA-JA-ABERTO    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ARQ_SAIDA_JA_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-APOLICE-INICIAL-NUM         PIC 9(13).*/
            public IntBasis W_APOLICE_INICIAL_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03 W-APOLICE-INICIAL-ALFA  REDEFINES W-APOLICE-INICIAL-NUM.*/
            private _REDEF_SI0868B_W_APOLICE_INICIAL_ALFA _w_apolice_inicial_alfa { get; set; }
            public _REDEF_SI0868B_W_APOLICE_INICIAL_ALFA W_APOLICE_INICIAL_ALFA
            {
                get { _w_apolice_inicial_alfa = new _REDEF_SI0868B_W_APOLICE_INICIAL_ALFA(); _.Move(W_APOLICE_INICIAL_NUM, _w_apolice_inicial_alfa); VarBasis.RedefinePassValue(W_APOLICE_INICIAL_NUM, _w_apolice_inicial_alfa, W_APOLICE_INICIAL_NUM); _w_apolice_inicial_alfa.ValueChanged += () => { _.Move(_w_apolice_inicial_alfa, W_APOLICE_INICIAL_NUM); }; return _w_apolice_inicial_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_apolice_inicial_alfa, W_APOLICE_INICIAL_NUM); }
            }  //Redefines
            public class _REDEF_SI0868B_W_APOLICE_INICIAL_ALFA : VarBasis
            {
                /*"       05 W-ORGAO-EMISSOR-INICIAL         PIC 9(03).*/
                public IntBasis W_ORGAO_EMISSOR_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"       05 W-RAMO-INICIAL                  PIC 9(02).*/
                public IntBasis W_RAMO_INICIAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-SEQUENCIA-INICIAL             PIC 9(08).*/
                public IntBasis W_SEQUENCIA_INICIAL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"    03 W-APOLICE-FINAL-NUM           PIC 9(13).*/

                public _REDEF_SI0868B_W_APOLICE_INICIAL_ALFA()
                {
                    W_ORGAO_EMISSOR_INICIAL.ValueChanged += OnValueChanged;
                    W_RAMO_INICIAL.ValueChanged += OnValueChanged;
                    W_SEQUENCIA_INICIAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_APOLICE_FINAL_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03 W-APOLICE-FINAL-ALFA  REDEFINES  W-APOLICE-FINAL-NUM.*/
            private _REDEF_SI0868B_W_APOLICE_FINAL_ALFA _w_apolice_final_alfa { get; set; }
            public _REDEF_SI0868B_W_APOLICE_FINAL_ALFA W_APOLICE_FINAL_ALFA
            {
                get { _w_apolice_final_alfa = new _REDEF_SI0868B_W_APOLICE_FINAL_ALFA(); _.Move(W_APOLICE_FINAL_NUM, _w_apolice_final_alfa); VarBasis.RedefinePassValue(W_APOLICE_FINAL_NUM, _w_apolice_final_alfa, W_APOLICE_FINAL_NUM); _w_apolice_final_alfa.ValueChanged += () => { _.Move(_w_apolice_final_alfa, W_APOLICE_FINAL_NUM); }; return _w_apolice_final_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_apolice_final_alfa, W_APOLICE_FINAL_NUM); }
            }  //Redefines
            public class _REDEF_SI0868B_W_APOLICE_FINAL_ALFA : VarBasis
            {
                /*"       05 W-ORGAO-EMISSOR-FINAL           PIC 9(03).*/
                public IntBasis W_ORGAO_EMISSOR_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"       05 W-RAMO-FINAL                    PIC 9(02).*/
                public IntBasis W_RAMO_FINAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-SEQUENCIA-FINAL               PIC 9(08).*/
                public IntBasis W_SEQUENCIA_FINAL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"    03  W-CONTA-LIDOS                 PIC 9(08)  VALUE 0.*/

                public _REDEF_SI0868B_W_APOLICE_FINAL_ALFA()
                {
                    W_ORGAO_EMISSOR_FINAL.ValueChanged += OnValueChanged;
                    W_RAMO_FINAL.ValueChanged += OnValueChanged;
                    W_SEQUENCIA_FINAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_CONTA_LIDOS { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03  WGD-CEP                       PIC 9(08)  VALUE 0.*/
            public IntBasis WGD_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03  FILLER REDEFINES WGD-CEP.*/
            private _REDEF_SI0868B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0868B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0868B_FILLER_0(); _.Move(WGD_CEP, _filler_0); VarBasis.RedefinePassValue(WGD_CEP, _filler_0, WGD_CEP); _filler_0.ValueChanged += () => { _.Move(_filler_0, WGD_CEP); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WGD_CEP); }
            }  //Redefines
            public class _REDEF_SI0868B_FILLER_0 : VarBasis
            {
                /*"        05  WGD-CEP-PRINC             PIC 9(05).*/
                public IntBasis WGD_CEP_PRINC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"        05  WGD-CEP-EXTENS            PIC 9(03).*/
                public IntBasis WGD_CEP_EXTENS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"01  FILLER.*/

                public _REDEF_SI0868B_FILLER_0()
                {
                    WGD_CEP_PRINC.ValueChanged += OnValueChanged;
                    WGD_CEP_EXTENS.ValueChanged += OnValueChanged;
                }

            }
        }
        public SI0868B_FILLER_1 FILLER_1 { get; set; } = new SI0868B_FILLER_1();
        public class SI0868B_FILLER_1 : VarBasis
        {
            /*"    05 WABEND.*/
            public SI0868B_WABEND WABEND { get; set; } = new SI0868B_WABEND();
            public class SI0868B_WABEND : VarBasis
            {
                /*"       10 FILLER                     PIC  X(009) VALUE          'SI0868B '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0868B ");
                /*"       10 FILLER                     PIC  X(035) VALUE          ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
                /*"       10 WNR-EXEC-SQL               PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"       10 FILLER                     PIC  X(013) VALUE          ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"       10 WSQLCODE                   PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01  FILLER01.*/
            }
        }
        public SI0868B_FILLER01 FILLER01 { get; set; } = new SI0868B_FILLER01();
        public class SI0868B_FILLER01 : VarBasis
        {
            /*"  02 LD01.*/
            public SI0868B_LD01 LD01 { get; set; } = new SI0868B_LD01();
            public class SI0868B_LD01 : VarBasis
            {
                /*"    03 LD01-SOLICITANTE         PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-RAMO-SOLICITADO     PIC  9(04) VALUE 0.*/
                public IntBasis LD01_RAMO_SOLICITADO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-PENDENCIA      PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PENDENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-SOLIC          PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-PROC           PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-APOLICE             PIC  9(13) VALUE 0.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-SINISTRO            PIC  9(13) VALUE 0.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-RAMO                PIC  9(04) VALUE 0.*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-PROTOCOLO           PIC  9(09) VALUE 0.*/
                public IntBasis LD01_PROTOCOLO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-PRODUTO         PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-PRODUTO             PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-CAUSA           PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-CAUSA               PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-FONTE           PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-FONTE-SINISTRO      PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_FONTE_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-NOME-SEGURADO       PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-AVISO          PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-VALOR-AVISO         PIC  ------------9,99.*/
                public DoubleBasis LD01_VALOR_AVISO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-VLR-AVISADO         PIC  ------------9,99.*/
                public DoubleBasis LD01_VLR_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-VLR-PAGO            PIC  ------------9,99.*/
                public DoubleBasis LD01_VLR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-VLR-PENDENTE        PIC  ------------9,99.*/
                public DoubleBasis LD01_VLR_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  02  LC01.*/
            }
            public SI0868B_LC01 LC01 { get; set; } = new SI0868B_LC01();
            public class SI0868B_LC01 : VarBasis
            {
                /*"    03 FILLER                   PIC  X(11) VALUE       'SOLICITANTE'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SOLICITANTE");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(15) VALUE       'RAMO SOLICITADO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"RAMO SOLICITADO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(11) VALUE       'PENDENTE EM'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"PENDENTE EM");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(19) VALUE       'DATA DA SOLICITACAO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA DA SOLICITACAO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(21) VALUE       'DATA DO PROCESSAMENTO'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA DO PROCESSAMENTO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(07) VALUE       'APOLICE'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(08) VALUE       'SINISTRO'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(16) VALUE       'RAMO DO SINISTRO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"RAMO DO SINISTRO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(09) VALUE       'PROTOCOLO'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROTOCOLO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(12) VALUE       'COD. PRODUTO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"COD. PRODUTO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(07) VALUE       'PRODUTO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(10) VALUE       'COD. CAUSA'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"COD. CAUSA");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(05) VALUE       'CAUSA'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CAUSA");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(19) VALUE       'COD. FONTE SINISTRO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"COD. FONTE SINISTRO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(14) VALUE       'FONTE SINISTRO'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"FONTE SINISTRO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(08) VALUE       'SEGURADO'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SEGURADO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(15) VALUE       'DATA AVISO SIAS'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA AVISO SIAS");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(12) VALUE       '$ AVISO SIAS'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"$ AVISO SIAS");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(09) VALUE       '$ AVISADO'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"$ AVISADO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(06) VALUE       '$ PAGO'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"$ PAGO");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 FILLER                   PIC  X(10) VALUE       '$ PENDENTE'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ PENDENTE");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  02  LC02.*/
            }
            public SI0868B_LC02 LC02 { get; set; } = new SI0868B_LC02();
            public class SI0868B_LC02 : VarBasis
            {
                /*"    03 C02-IDENTIFICADOR        PIC  X(400) VALUE       'PROGRAMA GERADOR >>> SI0868B;'.*/
                public StringBasis C02_IDENTIFICADOR { get; set; } = new StringBasis(new PIC("X", "400", "X(400)"), @"PROGRAMA GERADOR >>> SI0868B;");
                /*"  02  LC03.*/
            }
            public SI0868B_LC03 LC03 { get; set; } = new SI0868B_LC03();
            public class SI0868B_LC03 : VarBasis
            {
                /*"    03 C03-FUNCAO               PIC  X(400) VALUE       'RELATORIO DE ACOMPANHAMENTO DE SINISTROS PENDENTES;'.*/
                public StringBasis C03_FUNCAO { get; set; } = new StringBasis(new PIC("X", "400", "X(400)"), @"RELATORIO DE ACOMPANHAMENTO DE SINISTROS PENDENTES;");
                /*"01  FILLER REDEFINES FILLER01.*/
            }
        }
        private _REDEF_SI0868B_FILLER_68 _filler_68 { get; set; }
        public _REDEF_SI0868B_FILLER_68 FILLER_68
        {
            get { _filler_68 = new _REDEF_SI0868B_FILLER_68(); _.Move(FILLER01, _filler_68); VarBasis.RedefinePassValue(FILLER01, _filler_68, FILLER01); _filler_68.ValueChanged += () => { _.Move(_filler_68, FILLER01); }; return _filler_68; }
            set { VarBasis.RedefinePassValue(value, _filler_68, FILLER01); }
        }  //Redefines
        public class _REDEF_SI0868B_FILLER_68 : VarBasis
        {
            /*"    03 C01-FILLER               PIC  X(400).*/
            public StringBasis C01_FILLER { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

            public _REDEF_SI0868B_FILLER_68()
            {
                C01_FILLER.ValueChanged += OnValueChanged;
            }

        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.LOTISG01 LOTISG01 { get; set; } = new Dclgens.LOTISG01();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public SI0868B_RELATORIOS RELATORIOS { get; set; } = new SI0868B_RELATORIOS();
        public SI0868B_C01_FONTES C01_FONTES { get; set; } = new SI0868B_C01_FONTES();
        public SI0868B_PRODUTOS PRODUTOS { get; set; } = new SI0868B_PRODUTOS();
        public SI0868B_CAUSAS CAUSAS { get; set; } = new SI0868B_CAUSAS();
        public SI0868B_RAMO RAMO { get; set; } = new SI0868B_RAMO();
        public SI0868B_RAMOVG RAMOVG { get; set; } = new SI0868B_RAMOVG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQ_SAIDA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQ_SAIDA.SetFile(ARQ_SAIDA_FILE_NAME_P);

                /*" -345- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -346- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -347- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -351- OPEN OUTPUT ARQ-SAIDA. */
                ARQ_SAIDA.Open(REG_ARQ_SAIDA);

                /*" -353- PERFORM R010-SELECT-SISTEMA THRU R010-EXIT. */

                R010_SELECT_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -354- PERFORM R020-DECLARE-RELATORIO THRU R020-EXIT. */

                R020_DECLARE_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -356- MOVE 'NAO' TO W-FIM-RELATORIO. */
                _.Move("NAO", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -358- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

                R021_FETCH_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -359- IF W-FIM-RELATORIO EQUAL 'SIM' */

                if (W_INICIO_WORK.W_FIM_RELATORIO == "SIM")
                {

                    /*" -360- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -361- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -362- DISPLAY '       NADA SELECIONADO NA DATA DE HOJE         ' */
                    _.Display($"       NADA SELECIONADO NA DATA DE HOJE         ");

                    /*" -363- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -364- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -365- MOVE 'NAO HOUVE SOLICITACAO NA DATA DE HOJE' TO C01-FILLER */
                    _.Move("NAO HOUVE SOLICITACAO NA DATA DE HOJE", FILLER_68.C01_FILLER);

                    /*" -366- WRITE REG-ARQ-SAIDA FROM LD01 */
                    _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -368- GO TO 000-TERMINA. */

                    M_000_TERMINA(); //GOTO
                    return Result;
                }


                /*" -369- PERFORM R030-DECLARA-FONTES THRU R030-EXIT. */

                R030_DECLARA_FONTES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/


                /*" -370- PERFORM R040-DECLARA-PRODUTOS THRU R040-EXIT. */

                R040_DECLARA_PRODUTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


                /*" -372- PERFORM R050-DECLARA-CAUSAS THRU R050-EXIT. */

                R050_DECLARA_CAUSAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


                /*" -375- PERFORM R060-PROCESSA-RELATORIO THRU R060-EXIT UNTIL (W-FIM-RELATORIO EQUAL 'SIM' ). */

                while (!((W_INICIO_WORK.W_FIM_RELATORIO == "SIM")))
                {

                    R060_PROCESSA_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

                }

                /*" -377- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", FILLER_1.WABEND.WNR_EXEC_SQL);

                /*" -382- PERFORM Execute_DB_UPDATE_1 */

                Execute_DB_UPDATE_1();

                /*" -385- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -386- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -387- DISPLAY 'ERRO NO UPDATE RELATORIOS.......' */
                    _.Display($"ERRO NO UPDATE RELATORIOS.......");

                    /*" -388- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -388- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -388- FLUXCONTROL_PERFORM Execute-DB-UPDATE-1 */

                Execute_DB_UPDATE_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-UPDATE-1 */
        public void Execute_DB_UPDATE_1()
        {
            /*" -382- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0868B' AND SIT_REGISTRO = '0' END-EXEC. */

            var execute_DB_UPDATE_1_Update1 = new Execute_DB_UPDATE_1_Update1()
            {
            };

            Execute_DB_UPDATE_1_Update1.Execute(execute_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-000-TERMINA */
        private void M_000_TERMINA(bool isPerform = false)
        {
            /*" -393- DISPLAY '************************************' */
            _.Display($"************************************");

            /*" -394- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -395- DISPLAY '*   TERMINO NORMAL DO PROGRAMA     *' */
            _.Display($"*   TERMINO NORMAL DO PROGRAMA     *");

            /*" -396- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -397- DISPLAY '*            SI0868B               *' */
            _.Display($"*            SI0868B               *");

            /*" -398- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -398- DISPLAY '************************************' . */
            _.Display($"************************************");

        }

        [StopWatch]
        /*" M-000-FIM-PROGRAMA */
        private void M_000_FIM_PROGRAMA(bool isPerform = false)
        {
            /*" -403- CLOSE ARQ-SAIDA */
            ARQ_SAIDA.Close();

            /*" -404- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -404- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA */
        private void R010_SELECT_SISTEMA(bool isPerform = false)
        {
            /*" -410- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -415- PERFORM R010_SELECT_SISTEMA_DB_SELECT_1 */

            R010_SELECT_SISTEMA_DB_SELECT_1();

            /*" -418- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -419- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -420- DISPLAY 'ERRO NO ACESSO - SISTEMA .......' */
                _.Display($"ERRO NO ACESSO - SISTEMA .......");

                /*" -421- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -422- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -423- ELSE */
            }
            else
            {


                /*" -425- MOVE SISTEMAS-DATA-MOV-ABERTO(09:02) TO LD01-DATA-PROC(01:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), FILLER01.LD01.LD01_DATA_PROC, 1, 2);

                /*" -426- MOVE '/' TO LD01-DATA-PROC(03:01) */
                _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_PROC, 3, 1);

                /*" -428- MOVE SISTEMAS-DATA-MOV-ABERTO(06:02) TO LD01-DATA-PROC(04:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), FILLER01.LD01.LD01_DATA_PROC, 4, 2);

                /*" -429- MOVE '/' TO LD01-DATA-PROC(06:01) */
                _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_PROC, 6, 1);

                /*" -430- MOVE SISTEMAS-DATA-MOV-ABERTO(01:04) TO LD01-DATA-PROC(07:04). */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), FILLER01.LD01.LD01_DATA_PROC, 7, 4);
            }


        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA-DB-SELECT-1 */
        public void R010_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -415- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r010_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R010_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R010_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r010_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/

        [StopWatch]
        /*" R020-DECLARE-RELATORIO */
        private void R020_DECLARE_RELATORIO(bool isPerform = false)
        {
            /*" -439- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -448- PERFORM R020_DECLARE_RELATORIO_DB_DECLARE_1 */

            R020_DECLARE_RELATORIO_DB_DECLARE_1();

            /*" -450- PERFORM R020_DECLARE_RELATORIO_DB_OPEN_1 */

            R020_DECLARE_RELATORIO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-DECLARE-1 */
        public void R020_DECLARE_RELATORIO_DB_DECLARE_1()
        {
            /*" -448- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT COD_USUARIO, DATA_SOLICITACAO, PERI_FINAL, RAMO_EMISSOR FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0868B' AND SIT_REGISTRO = '0' END-EXEC */
            RELATORIOS = new SI0868B_RELATORIOS(false);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT COD_USUARIO
							, 
							DATA_SOLICITACAO
							, 
							PERI_FINAL
							, 
							RAMO_EMISSOR 
							FROM SEGUROS.RELATORIOS 
							WHERE IDE_SISTEMA = 'SI' 
							AND COD_RELATORIO = 'SI0868B' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-OPEN-1 */
        public void R020_DECLARE_RELATORIO_DB_OPEN_1()
        {
            /*" -450- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" R030-DECLARA-FONTES-DB-DECLARE-1 */
        public void R030_DECLARA_FONTES_DB_DECLARE_1()
        {
            /*" -537- EXEC SQL DECLARE C01_FONTES CURSOR FOR SELECT COD_FONTE, NOME_FONTE FROM SEGUROS.FONTES END-EXEC. */
            C01_FONTES = new SI0868B_C01_FONTES(false);
            string GetQuery_C01_FONTES()
            {
                var query = @$"SELECT COD_FONTE
							, NOME_FONTE 
							FROM SEGUROS.FONTES";

                return query;
            }
            C01_FONTES.GetQueryEvent += GetQuery_C01_FONTES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-RELATORIO */
        private void R021_FETCH_RELATORIO(bool isPerform = false)
        {
            /*" -459- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -464- PERFORM R021_FETCH_RELATORIO_DB_FETCH_1 */

            R021_FETCH_RELATORIO_DB_FETCH_1();

            /*" -467- DISPLAY 'LIDO NA RELATORIO, EM PROCESSAMENTO' */
            _.Display($"LIDO NA RELATORIO, EM PROCESSAMENTO");

            /*" -468- DISPLAY 'USUARIO ....................' RELATORI-COD-USUARIO. */
            _.Display($"USUARIO ....................{RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

            /*" -469- DISPLAY 'PERIODO FINAL ..............' RELATORI-PERI-FINAL. */
            _.Display($"PERIODO FINAL ..............{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

            /*" -471- DISPLAY 'RAMO EM PROCESSAMENTO ......' RELATORI-RAMO-EMISSOR. */
            _.Display($"RAMO EM PROCESSAMENTO ......{RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

            /*" -472- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -473- MOVE 'SIM' TO W-FIM-RELATORIO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -473- PERFORM R021_FETCH_RELATORIO_DB_CLOSE_1 */

                R021_FETCH_RELATORIO_DB_CLOSE_1();

                /*" -476- GO TO R021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/ //GOTO
                return;
            }


            /*" -477- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -478- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -479- DISPLAY 'ERRO FETCH NA RELATORIOS...........' */
                _.Display($"ERRO FETCH NA RELATORIOS...........");

                /*" -480- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -482- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -484- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -489- PERFORM R021_FETCH_RELATORIO_DB_SELECT_1 */

            R021_FETCH_RELATORIO_DB_SELECT_1();

            /*" -492- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -493- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -494- DISPLAY 'ERRO NA LEITURA DA USUARIOS........' */
                _.Display($"ERRO NA LEITURA DA USUARIOS........");

                /*" -495- DISPLAY 'COD. USUARIO : ' RELATORI-COD-USUARIO */
                _.Display($"COD. USUARIO : {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                /*" -496- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -498- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -500- MOVE RELATORI-DATA-SOLICITACAO(09:02) TO LD01-DATA-SOLIC(01:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(9, 2), FILLER01.LD01.LD01_DATA_SOLIC, 1, 2);

            /*" -501- MOVE '/' TO LD01-DATA-SOLIC(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_SOLIC, 3, 1);

            /*" -503- MOVE RELATORI-DATA-SOLICITACAO(06:02) TO LD01-DATA-SOLIC(04:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(6, 2), FILLER01.LD01.LD01_DATA_SOLIC, 4, 2);

            /*" -504- MOVE '/' TO LD01-DATA-SOLIC(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_SOLIC, 6, 1);

            /*" -506- MOVE RELATORI-DATA-SOLICITACAO(01:04) TO LD01-DATA-SOLIC(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(1, 4), FILLER01.LD01.LD01_DATA_SOLIC, 7, 4);

            /*" -507- MOVE USUARIOS-NOME-USUARIO TO LD01-SOLICITANTE. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, FILLER01.LD01.LD01_SOLICITANTE);

            /*" -509- MOVE RELATORI-RAMO-EMISSOR TO LD01-RAMO-SOLICITADO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, FILLER01.LD01.LD01_RAMO_SOLICITADO);

            /*" -511- MOVE RELATORI-PERI-FINAL(09:02) TO LD01-DATA-PENDENCIA(01:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(9, 2), FILLER01.LD01.LD01_DATA_PENDENCIA, 1, 2);

            /*" -512- MOVE '/' TO LD01-DATA-PENDENCIA(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_PENDENCIA, 3, 1);

            /*" -514- MOVE RELATORI-PERI-FINAL(06:02) TO LD01-DATA-PENDENCIA(04:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(6, 2), FILLER01.LD01.LD01_DATA_PENDENCIA, 4, 2);

            /*" -515- MOVE '/' TO LD01-DATA-PENDENCIA(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_PENDENCIA, 6, 1);

            /*" -518- MOVE RELATORI-PERI-FINAL(01:04) TO LD01-DATA-PENDENCIA(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(1, 4), FILLER01.LD01.LD01_DATA_PENDENCIA, 7, 4);

            /*" -519- MOVE RELATORI-PERI-FINAL TO HOST-DATA. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, HOST_DATA);

            /*" -522- MOVE RELATORI-RAMO-EMISSOR TO HOST-RAMO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, HOST_RAMO);

            /*" -523- WRITE REG-ARQ-SAIDA FROM LC02. */
            _.Move(FILLER01.LC02.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -524- WRITE REG-ARQ-SAIDA FROM LC03. */
            _.Move(FILLER01.LC03.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -524- WRITE REG-ARQ-SAIDA FROM LC01. */
            _.Move(FILLER01.LC01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-FETCH-1 */
        public void R021_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -464- EXEC SQL FETCH RELATORIOS INTO :RELATORI-COD-USUARIO, :RELATORI-DATA-SOLICITACAO, :RELATORI-PERI-FINAL, :RELATORI-RAMO-EMISSOR END-EXEC. */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(RELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(RELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(RELATORIOS.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
            }

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-CLOSE-1 */
        public void R021_FETCH_RELATORIO_DB_CLOSE_1()
        {
            /*" -473- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-SELECT-1 */
        public void R021_FETCH_RELATORIO_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO END-EXEC. */

            var r021_FETCH_RELATORIO_DB_SELECT_1_Query1 = new R021_FETCH_RELATORIO_DB_SELECT_1_Query1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
            };

            var executed_1 = R021_FETCH_RELATORIO_DB_SELECT_1_Query1.Execute(r021_FETCH_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.USUARIOS_NOME_USUARIO, USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/

        [StopWatch]
        /*" R030-DECLARA-FONTES */
        private void R030_DECLARA_FONTES(bool isPerform = false)
        {
            /*" -533- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -537- PERFORM R030_DECLARA_FONTES_DB_DECLARE_1 */

            R030_DECLARA_FONTES_DB_DECLARE_1();

            /*" -539- PERFORM R030_DECLARA_FONTES_DB_OPEN_1 */

            R030_DECLARA_FONTES_DB_OPEN_1();

            /*" -543- MOVE 'NAO' TO W-FIM-FONTES. */
            _.Move("NAO", W_INICIO_WORK.W_FIM_FONTES);

            /*" -545- PERFORM R031-FETCH-FONTES THRU R031-EXIT */

            R031_FETCH_FONTES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


            /*" -546- PERFORM R032-CARREGA-TABELA-FONTES THRU R032-EXIT UNTIL W-FIM-FONTES EQUAL 'SIM' . */

            while (!(W_INICIO_WORK.W_FIM_FONTES == "SIM"))
            {

                R032_CARREGA_TABELA_FONTES(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R032_EXIT*/

            }

        }

        [StopWatch]
        /*" R030-DECLARA-FONTES-DB-OPEN-1 */
        public void R030_DECLARA_FONTES_DB_OPEN_1()
        {
            /*" -539- EXEC SQL OPEN C01_FONTES END-EXEC. */

            C01_FONTES.Open();

        }

        [StopWatch]
        /*" R040-DECLARA-PRODUTOS-DB-DECLARE-1 */
        public void R040_DECLARA_PRODUTOS_DB_DECLARE_1()
        {
            /*" -598- EXEC SQL DECLARE PRODUTOS CURSOR FOR SELECT COD_PRODUTO, DESCR_PRODUTO FROM SEGUROS.PRODUTO END-EXEC. */
            PRODUTOS = new SI0868B_PRODUTOS(false);
            string GetQuery_PRODUTOS()
            {
                var query = @$"SELECT COD_PRODUTO
							, DESCR_PRODUTO 
							FROM SEGUROS.PRODUTO";

                return query;
            }
            PRODUTOS.GetQueryEvent += GetQuery_PRODUTOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R031-FETCH-FONTES */
        private void R031_FETCH_FONTES(bool isPerform = false)
        {
            /*" -555- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -559- PERFORM R031_FETCH_FONTES_DB_FETCH_1 */

            R031_FETCH_FONTES_DB_FETCH_1();

            /*" -562- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -563- MOVE 'SIM' TO W-FIM-FONTES */
                _.Move("SIM", W_INICIO_WORK.W_FIM_FONTES);

                /*" -563- PERFORM R031_FETCH_FONTES_DB_CLOSE_1 */

                R031_FETCH_FONTES_DB_CLOSE_1();

                /*" -565- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -566- DISPLAY 'ERRO DE CLOSE DO CURSOR FONTES' */
                    _.Display($"ERRO DE CLOSE DO CURSOR FONTES");

                    /*" -568- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -569- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -570- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -571- DISPLAY 'ERRO LEITURA CURSOR FONTES.........' */
                _.Display($"ERRO LEITURA CURSOR FONTES.........");

                /*" -572- DISPLAY 'COD. FONTE  : ' FONTES-COD-FONTE */
                _.Display($"COD. FONTE  : {FONTES.DCLFONTES.FONTES_COD_FONTE}");

                /*" -573- DISPLAY 'FONTE       : ' FONTES-NOME-FONTE */
                _.Display($"FONTE       : {FONTES.DCLFONTES.FONTES_NOME_FONTE}");

                /*" -574- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -574- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R031-FETCH-FONTES-DB-FETCH-1 */
        public void R031_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -559- EXEC SQL FETCH C01_FONTES INTO :FONTES-COD-FONTE, :FONTES-NOME-FONTE END-EXEC. */

            if (C01_FONTES.Fetch())
            {
                _.Move(C01_FONTES.FONTES_COD_FONTE, FONTES.DCLFONTES.FONTES_COD_FONTE);
                _.Move(C01_FONTES.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }

        }

        [StopWatch]
        /*" R031-FETCH-FONTES-DB-CLOSE-1 */
        public void R031_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -563- EXEC SQL CLOSE C01_FONTES END-EXEC */

            C01_FONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/

        [StopWatch]
        /*" R032-CARREGA-TABELA-FONTES */
        private void R032_CARREGA_TABELA_FONTES(bool isPerform = false)
        {
            /*" -582- ADD 1 TO W-SBS-FONTES */
            W_SBS_FONTES.Value = W_SBS_FONTES + 1;

            /*" -583- MOVE FONTES-COD-FONTE TO W-TAB-COD-FONTE (W-SBS-FONTES) */
            _.Move(FONTES.DCLFONTES.FONTES_COD_FONTE, W_TABELA_FONTES.W_TAB_FONTES[W_SBS_FONTES].W_TAB_COD_FONTE);

            /*" -585- MOVE FONTES-NOME-FONTE TO W-TAB-DESCR-FONTE (W-SBS-FONTES). */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, W_TABELA_FONTES.W_TAB_FONTES[W_SBS_FONTES].W_TAB_DESCR_FONTE);

            /*" -585- PERFORM R031-FETCH-FONTES THRU R031-EXIT. */

            R031_FETCH_FONTES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R031_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R032_EXIT*/

        [StopWatch]
        /*" R040-DECLARA-PRODUTOS */
        private void R040_DECLARA_PRODUTOS(bool isPerform = false)
        {
            /*" -594- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R040_DECLARA_PRODUTOS_DB_DECLARE_1 */

            R040_DECLARA_PRODUTOS_DB_DECLARE_1();

            /*" -600- PERFORM R040_DECLARA_PRODUTOS_DB_OPEN_1 */

            R040_DECLARA_PRODUTOS_DB_OPEN_1();

            /*" -604- PERFORM R041-FETCH-PRODUTOS THRU R041-EXIT. */

            R041_FETCH_PRODUTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R041_EXIT*/


            /*" -605- PERFORM R042-CARREGA-TABELA-PRODUTOS THRU R042-EXIT UNTIL W-FIM-PRODUTOS EQUAL 'SIM' . */

            while (!(W_INICIO_WORK.W_FIM_PRODUTOS == "SIM"))
            {

                R042_CARREGA_TABELA_PRODUTOS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R042_EXIT*/

            }

        }

        [StopWatch]
        /*" R040-DECLARA-PRODUTOS-DB-OPEN-1 */
        public void R040_DECLARA_PRODUTOS_DB_OPEN_1()
        {
            /*" -600- EXEC SQL OPEN PRODUTOS END-EXEC. */

            PRODUTOS.Open();

        }

        [StopWatch]
        /*" R050-DECLARA-CAUSAS-DB-DECLARE-1 */
        public void R050_DECLARA_CAUSAS_DB_DECLARE_1()
        {
            /*" -659- EXEC SQL DECLARE CAUSAS CURSOR FOR SELECT COD_CAUSA, RAMO_EMISSOR, DESCR_CAUSA FROM SEGUROS.SINISTRO_CAUSA END-EXEC. */
            CAUSAS = new SI0868B_CAUSAS(false);
            string GetQuery_CAUSAS()
            {
                var query = @$"SELECT COD_CAUSA
							, RAMO_EMISSOR
							, DESCR_CAUSA 
							FROM SEGUROS.SINISTRO_CAUSA";

                return query;
            }
            CAUSAS.GetQueryEvent += GetQuery_CAUSAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R041-FETCH-PRODUTOS */
        private void R041_FETCH_PRODUTOS(bool isPerform = false)
        {
            /*" -614- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R041_FETCH_PRODUTOS_DB_FETCH_1 */

            R041_FETCH_PRODUTOS_DB_FETCH_1();

            /*" -621- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -622- MOVE 'SIM' TO W-FIM-PRODUTOS */
                _.Move("SIM", W_INICIO_WORK.W_FIM_PRODUTOS);

                /*" -622- PERFORM R041_FETCH_PRODUTOS_DB_CLOSE_1 */

                R041_FETCH_PRODUTOS_DB_CLOSE_1();

                /*" -624- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -625- DISPLAY 'ERRO DE CLOSE DO CURSOR PRODUTOS' */
                    _.Display($"ERRO DE CLOSE DO CURSOR PRODUTOS");

                    /*" -627- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -628- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -629- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -630- DISPLAY 'ERRO LEITURA CURSOR PRODUTOS.......' */
                _.Display($"ERRO LEITURA CURSOR PRODUTOS.......");

                /*" -631- DISPLAY 'COD. PRODUTO : ' PRODUTO-COD-PRODUTO */
                _.Display($"COD. PRODUTO : {PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO}");

                /*" -632- DISPLAY 'FONTE        : ' PRODUTO-DESCR-PRODUTO */
                _.Display($"FONTE        : {PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO}");

                /*" -633- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -633- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R041-FETCH-PRODUTOS-DB-FETCH-1 */
        public void R041_FETCH_PRODUTOS_DB_FETCH_1()
        {
            /*" -618- EXEC SQL FETCH PRODUTOS INTO :PRODUTO-COD-PRODUTO, :PRODUTO-DESCR-PRODUTO END-EXEC. */

            if (PRODUTOS.Fetch())
            {
                _.Move(PRODUTOS.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
                _.Move(PRODUTOS.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
            }

        }

        [StopWatch]
        /*" R041-FETCH-PRODUTOS-DB-CLOSE-1 */
        public void R041_FETCH_PRODUTOS_DB_CLOSE_1()
        {
            /*" -622- EXEC SQL CLOSE PRODUTOS END-EXEC */

            PRODUTOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R041_EXIT*/

        [StopWatch]
        /*" R042-CARREGA-TABELA-PRODUTOS */
        private void R042_CARREGA_TABELA_PRODUTOS(bool isPerform = false)
        {
            /*" -641- ADD 1 TO W-SBS-PRODUTOS. */
            W_SBS_PRODUTOS.Value = W_SBS_PRODUTOS + 1;

            /*" -643- MOVE PRODUTO-COD-PRODUTO TO W-TAB-COD-PRODUTO (W-SBS-PRODUTOS) */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO, W_TABELA_PRODUTOS.W_TAB_PRODUTOS[W_SBS_PRODUTOS].W_TAB_COD_PRODUTO);

            /*" -646- MOVE PRODUTO-DESCR-PRODUTO TO W-TAB-DESCR-PRODUTO(W-SBS-PRODUTOS). */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, W_TABELA_PRODUTOS.W_TAB_PRODUTOS[W_SBS_PRODUTOS].W_TAB_DESCR_PRODUTO);

            /*" -646- PERFORM R041-FETCH-PRODUTOS THRU R041-EXIT. */

            R041_FETCH_PRODUTOS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R041_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R042_EXIT*/

        [StopWatch]
        /*" R050-DECLARA-CAUSAS */
        private void R050_DECLARA_CAUSAS(bool isPerform = false)
        {
            /*" -655- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -659- PERFORM R050_DECLARA_CAUSAS_DB_DECLARE_1 */

            R050_DECLARA_CAUSAS_DB_DECLARE_1();

            /*" -661- PERFORM R050_DECLARA_CAUSAS_DB_OPEN_1 */

            R050_DECLARA_CAUSAS_DB_OPEN_1();

            /*" -665- PERFORM R051-FETCH-CAUSAS THRU R051-EXIT. */

            R051_FETCH_CAUSAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R051_EXIT*/


            /*" -666- PERFORM R052-CARREGA-TABELA-CAUSAS THRU R052-EXIT UNTIL W-FIM-CAUSAS EQUAL 'SIM' . */

            while (!(W_INICIO_WORK.W_FIM_CAUSAS == "SIM"))
            {

                R052_CARREGA_TABELA_CAUSAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R052_EXIT*/

            }

        }

        [StopWatch]
        /*" R050-DECLARA-CAUSAS-DB-OPEN-1 */
        public void R050_DECLARA_CAUSAS_DB_OPEN_1()
        {
            /*" -661- EXEC SQL OPEN CAUSAS END-EXEC. */

            CAUSAS.Open();

        }

        [StopWatch]
        /*" R070-DECLARA-CURSORES-DB-DECLARE-1 */
        public void R070_DECLARA_CURSORES_DB_DECLARE_1()
        {
            /*" -802- EXEC SQL DECLARE RAMO CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.RAMO, M.COD_PRODUTO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.NUM_CERTIFICADO, M.COD_SUBGRUPO, M.COD_CAUSA, X.DATA_MOVIMENTO AS DATA_AVISO_SIAS, X.VAL_OPERACAO AS VALOR_AVISO_SIAS FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO X, SEGUROS.GE_OPERACAO O WHERE M.NUM_APOLICE BETWEEN :HOST-APOL-INICIO AND :HOST-APOL-FIM AND H.DATA_MOVIMENTO <= :HOST-DATA AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO IN ( 'AV' , 'IN' ) AND H.NUM_APOL_SINISTRO = X.NUM_APOL_SINISTRO AND X.COD_OPERACAO = 101 GROUP BY M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.RAMO, M.COD_PRODUTO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.NUM_CERTIFICADO, M.COD_SUBGRUPO, M.COD_CAUSA, X.DATA_MOVIMENTO, X.VAL_OPERACAO ORDER BY M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.RAMO, M.COD_PRODUTO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.NUM_CERTIFICADO, M.COD_SUBGRUPO, M.COD_CAUSA, X.DATA_MOVIMENTO, X.VAL_OPERACAO END-EXEC. */
            RAMO = new SI0868B_RAMO(true);
            string GetQuery_RAMO()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_SUBGRUPO
							, 
							M.COD_CAUSA
							, 
							X.DATA_MOVIMENTO AS DATA_AVISO_SIAS
							, 
							X.VAL_OPERACAO AS VALOR_AVISO_SIAS 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO X
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE M.NUM_APOLICE BETWEEN '{HOST_APOL_INICIO}' 
							AND '{HOST_APOL_FIM}' 
							AND H.DATA_MOVIMENTO <= '{HOST_DATA}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO IN ( 'AV'
							, 'IN' ) 
							AND H.NUM_APOL_SINISTRO = X.NUM_APOL_SINISTRO 
							AND X.COD_OPERACAO = 101 
							GROUP BY M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_SUBGRUPO
							, 
							M.COD_CAUSA
							, 
							X.DATA_MOVIMENTO
							, 
							X.VAL_OPERACAO 
							ORDER BY M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_SUBGRUPO
							, 
							M.COD_CAUSA
							, 
							X.DATA_MOVIMENTO
							, 
							X.VAL_OPERACAO";

                return query;
            }
            RAMO.GetQueryEvent += GetQuery_RAMO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R051-FETCH-CAUSAS */
        private void R051_FETCH_CAUSAS(bool isPerform = false)
        {
            /*" -675- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -680- PERFORM R051_FETCH_CAUSAS_DB_FETCH_1 */

            R051_FETCH_CAUSAS_DB_FETCH_1();

            /*" -683- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -684- MOVE 'SIM' TO W-FIM-CAUSAS */
                _.Move("SIM", W_INICIO_WORK.W_FIM_CAUSAS);

                /*" -684- PERFORM R051_FETCH_CAUSAS_DB_CLOSE_1 */

                R051_FETCH_CAUSAS_DB_CLOSE_1();

                /*" -686- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -687- DISPLAY 'ERRO DE CLOSE DO CURSOR CAUSAS' */
                    _.Display($"ERRO DE CLOSE DO CURSOR CAUSAS");

                    /*" -689- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -690- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -691- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -692- DISPLAY 'ERRO LEITURA CURSOR CAUSAS.......' */
                _.Display($"ERRO LEITURA CURSOR CAUSAS.......");

                /*" -693- DISPLAY 'COD. CAUSA : ' SINISCAU-COD-CAUSA */
                _.Display($"COD. CAUSA : {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA}");

                /*" -694- DISPLAY 'RAMO       : ' SINISCAU-RAMO-EMISSOR */
                _.Display($"RAMO       : {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR}");

                /*" -695- DISPLAY 'CAUSA      : ' SINISCAU-DESCR-CAUSA */
                _.Display($"CAUSA      : {SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA}");

                /*" -696- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -696- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R051-FETCH-CAUSAS-DB-FETCH-1 */
        public void R051_FETCH_CAUSAS_DB_FETCH_1()
        {
            /*" -680- EXEC SQL FETCH CAUSAS INTO :SINISCAU-COD-CAUSA, :SINISCAU-RAMO-EMISSOR, :SINISCAU-DESCR-CAUSA END-EXEC. */

            if (CAUSAS.Fetch())
            {
                _.Move(CAUSAS.SINISCAU_COD_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA);
                _.Move(CAUSAS.SINISCAU_RAMO_EMISSOR, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR);
                _.Move(CAUSAS.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
            }

        }

        [StopWatch]
        /*" R051-FETCH-CAUSAS-DB-CLOSE-1 */
        public void R051_FETCH_CAUSAS_DB_CLOSE_1()
        {
            /*" -684- EXEC SQL CLOSE CAUSAS END-EXEC */

            CAUSAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R051_EXIT*/

        [StopWatch]
        /*" R052-CARREGA-TABELA-CAUSAS */
        private void R052_CARREGA_TABELA_CAUSAS(bool isPerform = false)
        {
            /*" -704- ADD 1 TO W-SBS-CAUSAS */
            W_SBS_CAUSAS.Value = W_SBS_CAUSAS + 1;

            /*" -705- MOVE SINISCAU-COD-CAUSA TO W-TAB-COD-CAUSA(W-SBS-CAUSAS) */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_COD_CAUSA, W_TABELA_CAUSAS.W_TAB_CAUSAS[W_SBS_CAUSAS].W_TAB_COD_CAUSA);

            /*" -707- MOVE SINISCAU-RAMO-EMISSOR TO W-TAB-RAMO-EMISSOR(W-SBS-CAUSAS) */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_RAMO_EMISSOR, W_TABELA_CAUSAS.W_TAB_CAUSAS[W_SBS_CAUSAS].W_TAB_RAMO_EMISSOR);

            /*" -710- MOVE SINISCAU-DESCR-CAUSA TO W-TAB-DESCR-CAUSA(W-SBS-CAUSAS). */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W_TABELA_CAUSAS.W_TAB_CAUSAS[W_SBS_CAUSAS].W_TAB_DESCR_CAUSA);

            /*" -710- PERFORM R051-FETCH-CAUSAS THRU R051-EXIT. */

            R051_FETCH_CAUSAS(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R051_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R052_EXIT*/

        [StopWatch]
        /*" R060-PROCESSA-RELATORIO */
        private void R060_PROCESSA_RELATORIO(bool isPerform = false)
        {
            /*" -719- DISPLAY 'INICIADA A SELECAO. LENDO A RELATORIOS.' */
            _.Display($"INICIADA A SELECAO. LENDO A RELATORIOS.");

            /*" -720- MOVE 010 TO W-ORGAO-EMISSOR-INICIAL W-ORGAO-EMISSOR-FINAL. */
            _.Move(010, W_INICIO_WORK.W_APOLICE_INICIAL_ALFA.W_ORGAO_EMISSOR_INICIAL);
            _.Move(010, W_INICIO_WORK.W_APOLICE_FINAL_ALFA.W_ORGAO_EMISSOR_FINAL);


            /*" -721- MOVE RELATORI-RAMO-EMISSOR TO W-RAMO-INICIAL W-RAMO-FINAL. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, W_INICIO_WORK.W_APOLICE_INICIAL_ALFA.W_RAMO_INICIAL);
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, W_INICIO_WORK.W_APOLICE_FINAL_ALFA.W_RAMO_FINAL);


            /*" -722- MOVE ZEROS TO W-SEQUENCIA-INICIAL. */
            _.Move(0, W_INICIO_WORK.W_APOLICE_INICIAL_ALFA.W_SEQUENCIA_INICIAL);

            /*" -724- MOVE 99999999 TO W-SEQUENCIA-FINAL. */
            _.Move(99999999, W_INICIO_WORK.W_APOLICE_FINAL_ALFA.W_SEQUENCIA_FINAL);

            /*" -725- MOVE W-APOLICE-INICIAL-NUM TO HOST-APOL-INICIO. */
            _.Move(W_INICIO_WORK.W_APOLICE_INICIAL_NUM, HOST_APOL_INICIO);

            /*" -727- MOVE W-APOLICE-FINAL-NUM TO HOST-APOL-FIM. */
            _.Move(W_INICIO_WORK.W_APOLICE_FINAL_NUM, HOST_APOL_FIM);

            /*" -729- MOVE 'NAO' TO WIND-PCS-RAMO WIND-PCS-RAMOVG. */
            _.Move("NAO", WIND_PCS_RAMO, WIND_PCS_RAMOVG);

            /*" -730- IF RELATORI-RAMO-EMISSOR EQUAL 81 OR 93 */

            if (RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.In("81", "93"))
            {

                /*" -731- MOVE 'SIM' TO WIND-PCS-RAMOVG */
                _.Move("SIM", WIND_PCS_RAMOVG);

                /*" -732- ELSE */
            }
            else
            {


                /*" -734- MOVE 'SIM' TO WIND-PCS-RAMO. */
                _.Move("SIM", WIND_PCS_RAMO);
            }


            /*" -736- PERFORM R070-DECLARA-CURSORES THRU R070-EXIT. */

            R070_DECLARA_CURSORES(true);

            R072_DECLARE_RAMOVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/


            /*" -738- MOVE 'NAO' TO W-FIM-CURSOR. */
            _.Move("NAO", W_INICIO_WORK.W_FIM_CURSOR);

            /*" -740- PERFORM R080-FETCH-CURSORES THRU R080-EXIT. */

            R080_FETCH_CURSORES(true);

            R081_FETCH_RAMO(true);

            R082_FETCH_RAMOVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/


            /*" -743- PERFORM R100-PROCESSA-RAMO THRU R100-EXIT UNTIL W-FIM-CURSOR EQUAL 'SIM' . */

            while (!(W_INICIO_WORK.W_FIM_CURSOR == "SIM"))
            {

                R100_PROCESSA_RAMO(true);

                R100_LE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

            }

            /*" -743- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

            R021_FETCH_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R060_EXIT*/

        [StopWatch]
        /*" R070-DECLARA-CURSORES */
        private void R070_DECLARA_CURSORES(bool isPerform = false)
        {
            /*" -751- IF WIND-PCS-RAMOVG EQUAL 'SIM' */

            if (WIND_PCS_RAMOVG == "SIM")
            {

                /*" -753- GO TO R072-DECLARE-RAMOVG. */

                R072_DECLARE_RAMOVG(); //GOTO
                return;
            }


            /*" -755- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -802- PERFORM R070_DECLARA_CURSORES_DB_DECLARE_1 */

            R070_DECLARA_CURSORES_DB_DECLARE_1();

            /*" -804- PERFORM R070_DECLARA_CURSORES_DB_OPEN_1 */

            R070_DECLARA_CURSORES_DB_OPEN_1();

            /*" -805- GO TO R070-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R070-DECLARA-CURSORES-DB-OPEN-1 */
        public void R070_DECLARA_CURSORES_DB_OPEN_1()
        {
            /*" -804- EXEC SQL OPEN RAMO END-EXEC. */

            RAMO.Open();

        }

        [StopWatch]
        /*" R072-DECLARE-RAMOVG-DB-DECLARE-1 */
        public void R072_DECLARE_RAMOVG_DB_DECLARE_1()
        {
            /*" -860- EXEC SQL DECLARE RAMOVG CURSOR FOR SELECT M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.RAMO, M.COD_PRODUTO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.NUM_CERTIFICADO, M.COD_SUBGRUPO, M.COD_CAUSA, X.DATA_MOVIMENTO AS DATA_AVISO_SIAS, X.VAL_OPERACAO AS VALOR_AVISO_SIAS FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.SINISTRO_HISTORICO X, SEGUROS.GE_OPERACAO O WHERE M.NUM_APOLICE BETWEEN :HOST-APOL-INICIO AND :HOST-APOL-FIM AND H.DATA_MOVIMENTO <= :HOST-DATA AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND O.IDE_SISTEMA = 'SI' AND O.COD_OPERACAO = H.COD_OPERACAO AND O.IND_TIPO_FUNCAO IN ( 'AV' , 'IN' ) AND H.NUM_APOL_SINISTRO = X.NUM_APOL_SINISTRO AND X.COD_OPERACAO = 101 GROUP BY M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.RAMO, M.COD_PRODUTO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.NUM_CERTIFICADO, M.COD_SUBGRUPO, M.COD_CAUSA, X.DATA_MOVIMENTO, X.VAL_OPERACAO ORDER BY M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.RAMO, M.COD_PRODUTO, M.COD_FONTE, M.NUM_PROTOCOLO_SINI, M.NUM_CERTIFICADO, M.COD_SUBGRUPO, M.COD_CAUSA, X.DATA_MOVIMENTO, X.VAL_OPERACAO END-EXEC. */
            RAMOVG = new SI0868B_RAMOVG(true);
            string GetQuery_RAMOVG()
            {
                var query = @$"SELECT M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_SUBGRUPO
							, 
							M.COD_CAUSA
							, 
							X.DATA_MOVIMENTO AS DATA_AVISO_SIAS
							, 
							X.VAL_OPERACAO AS VALOR_AVISO_SIAS 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.SINISTRO_HISTORICO X
							, 
							SEGUROS.GE_OPERACAO O 
							WHERE M.NUM_APOLICE BETWEEN '{HOST_APOL_INICIO}' 
							AND '{HOST_APOL_FIM}' 
							AND H.DATA_MOVIMENTO <= '{HOST_DATA}' 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND O.IDE_SISTEMA = 'SI' 
							AND O.COD_OPERACAO = H.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO IN ( 'AV'
							, 'IN' ) 
							AND H.NUM_APOL_SINISTRO = X.NUM_APOL_SINISTRO 
							AND X.COD_OPERACAO = 101 
							GROUP BY M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_SUBGRUPO
							, 
							M.COD_CAUSA
							, 
							X.DATA_MOVIMENTO
							, 
							X.VAL_OPERACAO 
							ORDER BY M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.COD_FONTE
							, 
							M.NUM_PROTOCOLO_SINI
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_SUBGRUPO
							, 
							M.COD_CAUSA
							, 
							X.DATA_MOVIMENTO
							, 
							X.VAL_OPERACAO";

                return query;
            }
            RAMOVG.GetQueryEvent += GetQuery_RAMOVG;

        }

        [StopWatch]
        /*" R072-DECLARE-RAMOVG */
        private void R072_DECLARE_RAMOVG(bool isPerform = false)
        {
            /*" -813- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -860- PERFORM R072_DECLARE_RAMOVG_DB_DECLARE_1 */

            R072_DECLARE_RAMOVG_DB_DECLARE_1();

            /*" -862- PERFORM R072_DECLARE_RAMOVG_DB_OPEN_1 */

            R072_DECLARE_RAMOVG_DB_OPEN_1();

        }

        [StopWatch]
        /*" R072-DECLARE-RAMOVG-DB-OPEN-1 */
        public void R072_DECLARE_RAMOVG_DB_OPEN_1()
        {
            /*" -862- EXEC SQL OPEN RAMOVG END-EXEC. */

            RAMOVG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R070_EXIT*/

        [StopWatch]
        /*" R080-FETCH-CURSORES */
        private void R080_FETCH_CURSORES(bool isPerform = false)
        {
            /*" -871- ADD 1 TO W-CONTA-LIDOS. */
            W_INICIO_WORK.W_CONTA_LIDOS.Value = W_INICIO_WORK.W_CONTA_LIDOS + 1;

            /*" -872- IF W-CONTA-LIDOS EQUAL 1000 */

            if (W_INICIO_WORK.W_CONTA_LIDOS == 1000)
            {

                /*" -873- MOVE ZEROS TO W-CONTA-LIDOS */
                _.Move(0, W_INICIO_WORK.W_CONTA_LIDOS);

                /*" -873- DISPLAY 'LIDOS ATE AGORA = ' W-CONTA-LIDOS. */
                _.Display($"LIDOS ATE AGORA = {W_INICIO_WORK.W_CONTA_LIDOS}");
            }


        }

        [StopWatch]
        /*" R081-FETCH-RAMO */
        private void R081_FETCH_RAMO(bool isPerform = false)
        {
            /*" -879- IF WIND-PCS-RAMOVG EQUAL 'SIM' */

            if (WIND_PCS_RAMOVG == "SIM")
            {

                /*" -881- GO TO R082-FETCH-RAMOVG. */

                R082_FETCH_RAMOVG(); //GOTO
                return;
            }


            /*" -883- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -895- PERFORM R081_FETCH_RAMO_DB_FETCH_1 */

            R081_FETCH_RAMO_DB_FETCH_1();

            /*" -898- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -899- MOVE 'SIM' TO W-FIM-CURSOR */
                _.Move("SIM", W_INICIO_WORK.W_FIM_CURSOR);

                /*" -899- PERFORM R081_FETCH_RAMO_DB_CLOSE_1 */

                R081_FETCH_RAMO_DB_CLOSE_1();

                /*" -901- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -902- DISPLAY 'ERRO DE CLOSE DO CURSOR RAMO' */
                    _.Display($"ERRO DE CLOSE DO CURSOR RAMO");

                    /*" -904- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -905- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -906- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -907- DISPLAY 'ERRO LEITURA CURSOR POR RAMO.......' */
                _.Display($"ERRO LEITURA CURSOR POR RAMO.......");

                /*" -908- DISPLAY 'SOLICITANTE : ' USUARIOS-NOME-USUARIO */
                _.Display($"SOLICITANTE : {USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO}");

                /*" -909- DISPLAY 'RAMO        : ' RELATORI-RAMO-EMISSOR */
                _.Display($"RAMO        : {RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

                /*" -910- DISPLAY 'DATA        : ' RELATORI-PERI-FINAL */
                _.Display($"DATA        : {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                /*" -911- DISPLAY 'SINISTRO    : ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO    : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -912- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -914- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -914- GO TO R080-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R081-FETCH-RAMO-DB-FETCH-1 */
        public void R081_FETCH_RAMO_DB_FETCH_1()
        {
            /*" -895- EXEC SQL FETCH RAMO INTO :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI, :SINISMES-NUM-CERTIFICADO, :SINISMES-COD-SUBGRUPO, :SINISMES-COD-CAUSA, :HOST-DATA-AVISO-SIAS, :HOST-VALOR-AVISO-SIAS END-EXEC. */

            if (RAMO.Fetch())
            {
                _.Move(RAMO.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(RAMO.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(RAMO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(RAMO.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(RAMO.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(RAMO.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(RAMO.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(RAMO.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(RAMO.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(RAMO.HOST_DATA_AVISO_SIAS, HOST_DATA_AVISO_SIAS);
                _.Move(RAMO.HOST_VALOR_AVISO_SIAS, HOST_VALOR_AVISO_SIAS);
            }

        }

        [StopWatch]
        /*" R081-FETCH-RAMO-DB-CLOSE-1 */
        public void R081_FETCH_RAMO_DB_CLOSE_1()
        {
            /*" -899- EXEC SQL CLOSE RAMO END-EXEC */

            RAMO.Close();

        }

        [StopWatch]
        /*" R082-FETCH-RAMOVG */
        private void R082_FETCH_RAMOVG(bool isPerform = false)
        {
            /*" -922- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -934- PERFORM R082_FETCH_RAMOVG_DB_FETCH_1 */

            R082_FETCH_RAMOVG_DB_FETCH_1();

            /*" -937- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -938- MOVE 'SIM' TO W-FIM-CURSOR */
                _.Move("SIM", W_INICIO_WORK.W_FIM_CURSOR);

                /*" -938- PERFORM R082_FETCH_RAMOVG_DB_CLOSE_1 */

                R082_FETCH_RAMOVG_DB_CLOSE_1();

                /*" -940- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -941- DISPLAY 'ERRO DE CLOSE DO CURSOR PARA VIDA' */
                    _.Display($"ERRO DE CLOSE DO CURSOR PARA VIDA");

                    /*" -943- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -944- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -945- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -946- DISPLAY 'ERRO LEITURA CURSOR PARA VIDA ......' */
                _.Display($"ERRO LEITURA CURSOR PARA VIDA ......");

                /*" -947- DISPLAY 'SOLICITANTE : ' USUARIOS-NOME-USUARIO */
                _.Display($"SOLICITANTE : {USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO}");

                /*" -948- DISPLAY 'RAMO        : ' RELATORI-RAMO-EMISSOR */
                _.Display($"RAMO        : {RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

                /*" -949- DISPLAY 'DATA        : ' RELATORI-PERI-FINAL */
                _.Display($"DATA        : {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}");

                /*" -950- DISPLAY 'SINISTRO    : ' SINISMES-NUM-APOL-SINISTRO */
                _.Display($"SINISTRO    : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                /*" -951- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -951- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R082-FETCH-RAMOVG-DB-FETCH-1 */
        public void R082_FETCH_RAMOVG_DB_FETCH_1()
        {
            /*" -934- EXEC SQL FETCH RAMOVG INTO :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-COD-FONTE, :SINISMES-NUM-PROTOCOLO-SINI, :SINISMES-NUM-CERTIFICADO, :SINISMES-COD-SUBGRUPO, :SINISMES-COD-CAUSA, :HOST-DATA-AVISO-SIAS, :HOST-VALOR-AVISO-SIAS END-EXEC. */

            if (RAMOVG.Fetch())
            {
                _.Move(RAMOVG.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(RAMOVG.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(RAMOVG.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(RAMOVG.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(RAMOVG.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(RAMOVG.SINISMES_NUM_PROTOCOLO_SINI, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI);
                _.Move(RAMOVG.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(RAMOVG.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(RAMOVG.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(RAMOVG.HOST_DATA_AVISO_SIAS, HOST_DATA_AVISO_SIAS);
                _.Move(RAMOVG.HOST_VALOR_AVISO_SIAS, HOST_VALOR_AVISO_SIAS);
            }

        }

        [StopWatch]
        /*" R082-FETCH-RAMOVG-DB-CLOSE-1 */
        public void R082_FETCH_RAMOVG_DB_CLOSE_1()
        {
            /*" -938- EXEC SQL CLOSE RAMOVG END-EXEC */

            RAMOVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-RAMO */
        private void R100_PROCESSA_RAMO(bool isPerform = false)
        {
            /*" -964- MOVE ZEROS TO HOST-PENDENTE HOST-AVISADO HOST-PAGO */
            _.Move(0, HOST_PENDENTE, HOST_AVISADO, HOST_PAGO);

            /*" -966- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -967- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -969- MOVE HOST-DATA TO SI1001S-DATA-FIM */
            _.Move(HOST_DATA, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -971- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -972- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -973- DISPLAY 'PROBLEMA CALL SI1001S ' */
                _.Display($"PROBLEMA CALL SI1001S ");

                /*" -974- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -975- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -976- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -977- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -979- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -983- MOVE SI1001S-VALOR-CALCULADO TO HOST-PENDENTE. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_PENDENTE);

            /*" -984- IF HOST-PENDENTE EQUAL ZEROS */

            if (HOST_PENDENTE == 00)
            {

                /*" -988- GO TO R100-LE. */

                R100_LE(); //GOTO
                return;
            }


            /*" -990- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -991- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -993- MOVE HOST-DATA TO SI1001S-DATA-FIM */
            _.Move(HOST_DATA, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -995- CALL 'SI1002S' USING SI1001S-PARAMETROS */
            _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

            /*" -996- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -997- DISPLAY 'PROBLEMA CALL SI1002S ' */
                _.Display($"PROBLEMA CALL SI1002S ");

                /*" -998- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -999- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -1000- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -1001- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -1003- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1007- MOVE SI1001S-VALOR-CALCULADO TO HOST-PAGO. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_PAGO);

            /*" -1009- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1010- MOVE SINISMES-NUM-APOL-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1012- MOVE HOST-DATA TO SI1001S-DATA-FIM */
            _.Move(HOST_DATA, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1014- CALL 'SI1003S' USING SI1001S-PARAMETROS */
            _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1015- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1016- DISPLAY 'PROBLEMA CALL SI1003S ' */
                _.Display($"PROBLEMA CALL SI1003S ");

                /*" -1017- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1018- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                /*" -1019- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                /*" -1020- DISPLAY ' ' SI1001S-DATA-FIM */
                _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                /*" -1022- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1024- MOVE SI1001S-VALOR-CALCULADO TO HOST-AVISADO. */
            _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_AVISADO);

            /*" -1028- MOVE 'NAO' TO W-IND-FONTE W-IND-PRODUTO W-IND-CAUSA. */
            _.Move("NAO", W_INICIO_WORK.W_IND_FONTE, W_INICIO_WORK.W_IND_PRODUTO, W_INICIO_WORK.W_IND_CAUSA);

            /*" -1032- MOVE '?????' TO LD01-FONTE-SINISTRO LD01-PRODUTO LD01-CAUSA. */
            _.Move("?????", FILLER01.LD01.LD01_FONTE_SINISTRO, FILLER01.LD01.LD01_PRODUTO, FILLER01.LD01.LD01_CAUSA);

            /*" -1036- MOVE 1 TO W-SBS-FONTES W-SBS-PRODUTOS W-SBS-CAUSAS. */
            _.Move(1, W_SBS_FONTES, W_SBS_PRODUTOS, W_SBS_CAUSAS);

            /*" -1040- PERFORM R300-BUSCA-DESCR-FONTE THRU R300-EXIT VARYING W-SBS-FONTES FROM 1 BY 1 UNTIL (W-IND-FONTE EQUAL 'SIM' ) OR (W-SBS-FONTES GREATER 200). */

            for (W_SBS_FONTES.Value = 1; !((W_INICIO_WORK.W_IND_FONTE == "SIM") || (W_SBS_FONTES > 200)); W_SBS_FONTES.Value += 1)
            {

                R300_BUSCA_DESCR_FONTE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

            }

            /*" -1044- PERFORM R400-BUSCA-DESCR-PRODUTO THRU R400-EXIT VARYING W-SBS-PRODUTOS FROM 1 BY 1 UNTIL (W-IND-PRODUTO EQUAL 'SIM' ) OR (W-SBS-PRODUTOS GREATER 500). */

            for (W_SBS_PRODUTOS.Value = 1; !((W_INICIO_WORK.W_IND_PRODUTO == "SIM") || (W_SBS_PRODUTOS > 500)); W_SBS_PRODUTOS.Value += 1)
            {

                R400_BUSCA_DESCR_PRODUTO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

            }

            /*" -1049- PERFORM R500-BUSCA-DESCR-CAUSA THRU R500-EXIT VARYING W-SBS-CAUSAS FROM 1 BY 1 UNTIL (W-IND-CAUSA EQUAL 'SIM' ) OR (W-SBS-CAUSAS GREATER 500). */

            for (W_SBS_CAUSAS.Value = 1; !((W_INICIO_WORK.W_IND_CAUSA == "SIM") || (W_SBS_CAUSAS > 500)); W_SBS_CAUSAS.Value += 1)
            {

                R500_BUSCA_DESCR_CAUSA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

            }

            /*" -1051- PERFORM R800-BUSCA-NOME-SEGURADO THRU R800-EXIT. */

            R800_BUSCA_NOME_SEGURADO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R800_EXIT*/


            /*" -1052- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-SEGURADO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, FILLER01.LD01.LD01_NOME_SEGURADO);

            /*" -1052- PERFORM R700-GRAVA-ARQ-SAIDA THRU R700-EXIT. */

            R700_GRAVA_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/


        }

        [StopWatch]
        /*" R100-LE */
        private void R100_LE(bool isPerform = false)
        {
            /*" -1056- PERFORM R080-FETCH-CURSORES THRU R080-EXIT. */

            R080_FETCH_CURSORES(true);

            R081_FETCH_RAMO(true);

            R082_FETCH_RAMOVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R080_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R300-BUSCA-DESCR-FONTE */
        private void R300_BUSCA_DESCR_FONTE(bool isPerform = false)
        {
            /*" -1064- IF SINISMES-COD-FONTE EQUAL W-TAB-COD-FONTE (W-SBS-FONTES) */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE == W_TABELA_FONTES.W_TAB_FONTES[W_SBS_FONTES].W_TAB_COD_FONTE)
            {

                /*" -1066- MOVE W-TAB-DESCR-FONTE(W-SBS-FONTES) TO LD01-FONTE-SINISTRO */
                _.Move(W_TABELA_FONTES.W_TAB_FONTES[W_SBS_FONTES].W_TAB_DESCR_FONTE, FILLER01.LD01.LD01_FONTE_SINISTRO);

                /*" -1066- MOVE 'SIM' TO W-IND-FONTE. */
                _.Move("SIM", W_INICIO_WORK.W_IND_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R400-BUSCA-DESCR-PRODUTO */
        private void R400_BUSCA_DESCR_PRODUTO(bool isPerform = false)
        {
            /*" -1075- IF SINISMES-COD-PRODUTO EQUAL W-TAB-COD-PRODUTO(W-SBS-PRODUTOS) */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO == W_TABELA_PRODUTOS.W_TAB_PRODUTOS[W_SBS_PRODUTOS].W_TAB_COD_PRODUTO)
            {

                /*" -1076- MOVE W-TAB-DESCR-PRODUTO(W-SBS-PRODUTOS) TO LD01-PRODUTO */
                _.Move(W_TABELA_PRODUTOS.W_TAB_PRODUTOS[W_SBS_PRODUTOS].W_TAB_DESCR_PRODUTO, FILLER01.LD01.LD01_PRODUTO);

                /*" -1076- MOVE 'SIM' TO W-IND-PRODUTO. */
                _.Move("SIM", W_INICIO_WORK.W_IND_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

        [StopWatch]
        /*" R500-BUSCA-DESCR-CAUSA */
        private void R500_BUSCA_DESCR_CAUSA(bool isPerform = false)
        {
            /*" -1086- IF SINISMES-COD-CAUSA EQUAL W-TAB-COD-CAUSA(W-SBS-CAUSAS) AND SINISMES-RAMO EQUAL W-TAB-RAMO-EMISSOR(W-SBS-CAUSAS) */

            if (SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA == W_TABELA_CAUSAS.W_TAB_CAUSAS[W_SBS_CAUSAS].W_TAB_COD_CAUSA && SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO == W_TABELA_CAUSAS.W_TAB_CAUSAS[W_SBS_CAUSAS].W_TAB_RAMO_EMISSOR)
            {

                /*" -1087- MOVE W-TAB-DESCR-CAUSA(W-SBS-CAUSAS) TO LD01-CAUSA */
                _.Move(W_TABELA_CAUSAS.W_TAB_CAUSAS[W_SBS_CAUSAS].W_TAB_DESCR_CAUSA, FILLER01.LD01.LD01_CAUSA);

                /*" -1087- MOVE 'SIM' TO W-IND-CAUSA. */
                _.Move("SIM", W_INICIO_WORK.W_IND_CAUSA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

        [StopWatch]
        /*" R700-GRAVA-ARQ-SAIDA */
        private void R700_GRAVA_ARQ_SAIDA(bool isPerform = false)
        {
            /*" -1095- MOVE SINISMES-NUM-APOLICE TO LD01-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, FILLER01.LD01.LD01_APOLICE);

            /*" -1096- MOVE SINISMES-NUM-APOL-SINISTRO TO LD01-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, FILLER01.LD01.LD01_SINISTRO);

            /*" -1097- MOVE SINISMES-RAMO TO LD01-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, FILLER01.LD01.LD01_RAMO);

            /*" -1098- MOVE SINISMES-COD-PRODUTO TO LD01-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, FILLER01.LD01.LD01_COD_PRODUTO);

            /*" -1099- MOVE SINISMES-COD-CAUSA TO LD01-COD-CAUSA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, FILLER01.LD01.LD01_COD_CAUSA);

            /*" -1100- MOVE SINISMES-COD-FONTE TO LD01-COD-FONTE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, FILLER01.LD01.LD01_COD_FONTE);

            /*" -1101- MOVE SINISMES-NUM-PROTOCOLO-SINI TO LD01-PROTOCOLO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI, FILLER01.LD01.LD01_PROTOCOLO);

            /*" -1102- MOVE HOST-DATA-AVISO-SIAS TO LD01-DATA-AVISO. */
            _.Move(HOST_DATA_AVISO_SIAS, FILLER01.LD01.LD01_DATA_AVISO);

            /*" -1103- MOVE HOST-VALOR-AVISO-SIAS TO LD01-VALOR-AVISO. */
            _.Move(HOST_VALOR_AVISO_SIAS, FILLER01.LD01.LD01_VALOR_AVISO);

            /*" -1104- MOVE HOST-AVISADO TO LD01-VLR-AVISADO. */
            _.Move(HOST_AVISADO, FILLER01.LD01.LD01_VLR_AVISADO);

            /*" -1105- MOVE HOST-PAGO TO LD01-VLR-PAGO. */
            _.Move(HOST_PAGO, FILLER01.LD01.LD01_VLR_PAGO);

            /*" -1107- MOVE HOST-PENDENTE TO LD01-VLR-PENDENTE. */
            _.Move(HOST_PENDENTE, FILLER01.LD01.LD01_VLR_PENDENTE);

            /*" -1107- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/

        [StopWatch]
        /*" R800-BUSCA-NOME-SEGURADO */
        private void R800_BUSCA_NOME_SEGURADO(bool isPerform = false)
        {
            /*" -1118- IF (RELATORI-RAMO-EMISSOR EQUAL 93 OR 97 OR (RELATORI-RAMO-EMISSOR EQUAL 81 AND (SINISMES-NUM-APOLICE LESS 103100000000 OR SINISMES-NUM-APOLICE GREATER 103199999999))) */

            if ((RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.In("93", "97") || (RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR == 81 && (SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE < 103100000000 || SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE > 103199999999))))
            {

                /*" -1119- PERFORM R810-BUSCA-CLIENTE-VIDA THRU R810-EXIT */

                R810_BUSCA_CLIENTE_VIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R810_EXIT*/


                /*" -1120- ELSE */
            }
            else
            {


                /*" -1120- PERFORM R830-BUSCA-CLIENTE-OUTROS THRU R830-EXIT. */

                R830_BUSCA_CLIENTE_OUTROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R830_EXIT*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R800_EXIT*/

        [StopWatch]
        /*" R810-BUSCA-CLIENTE-VIDA */
        private void R810_BUSCA_CLIENTE_VIDA(bool isPerform = false)
        {
            /*" -1129- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1139- PERFORM R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1 */

            R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1();

            /*" -1142- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1143- MOVE '???' TO CLIENTES-NOME-RAZAO */
                _.Move("???", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1144- ELSE */
            }
            else
            {


                /*" -1145- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
                {

                    /*" -1146- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -1147- DISPLAY 'ERRO NA BUSCA COD FONTE SEGURADOS_VGAP...' */
                    _.Display($"ERRO NA BUSCA COD FONTE SEGURADOS_VGAP...");

                    /*" -1148- DISPLAY 'APOLICE     : ' SINISMES-NUM-APOLICE */
                    _.Display($"APOLICE     : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                    /*" -1149- DISPLAY 'SINISTRO    : ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO    : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -1150- DISPLAY 'SUBGRUPO    : ' SINISMES-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO    : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                    /*" -1151- DISPLAY 'CERTIFICADO : ' SINISMES-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO}");

                    /*" -1152- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -1152- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R810-BUSCA-CLIENTE-VIDA-DB-SELECT-1 */
        public void R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1()
        {
            /*" -1139- EXEC SQL SELECT CL.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.SINISTRO_MESTRE SM, SEGUROS.SEGURADOS_VGAP S, SEGUROS.CLIENTES CL WHERE S.NUM_APOLICE = :SINISMES-NUM-APOLICE AND S.COD_SUBGRUPO = :SINISMES-COD-SUBGRUPO AND S.NUM_CERTIFICADO = :SINISMES-NUM-CERTIFICADO AND CL.COD_CLIENTE = :SEGURVGA-COD-CLIENTE END-EXEC. */

            var r810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1 = new R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_CERTIFICADO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO.ToString(),
                SINISMES_COD_SUBGRUPO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO.ToString(),
                SINISMES_NUM_APOLICE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1.Execute(r810_BUSCA_CLIENTE_VIDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R810_EXIT*/

        [StopWatch]
        /*" R830-BUSCA-CLIENTE-OUTROS */
        private void R830_BUSCA_CLIENTE_OUTROS(bool isPerform = false)
        {
            /*" -1161- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1168- PERFORM R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1 */

            R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1();

            /*" -1171- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1172- MOVE '???' TO CLIENTES-NOME-RAZAO */
                _.Move("???", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1173- ELSE */
            }
            else
            {


                /*" -1174- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
                {

                    /*" -1175- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -1176- DISPLAY 'ERRO NA BUSCA SEGURADO OUTROS RAMOS' */
                    _.Display($"ERRO NA BUSCA SEGURADO OUTROS RAMOS");

                    /*" -1177- DISPLAY 'SINISTRO    : ' SINISMES-NUM-APOL-SINISTRO */
                    _.Display($"SINISTRO    : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO}");

                    /*" -1178- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -1178- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R830-BUSCA-CLIENTE-OUTROS-DB-SELECT-1 */
        public void R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1()
        {
            /*" -1168- EXEC SQL SELECT CL.NOME_RAZAO INTO :CLIENTES-NOME-RAZAO FROM SEGUROS.SINISTRO_ITEM SI, SEGUROS.CLIENTES CL WHERE SI.NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO AND CL.COD_CLIENTE = SI.COD_CLIENTE END-EXEC. */

            var r830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1 = new R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1()
            {
                SINISMES_NUM_APOL_SINISTRO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.ToString(),
            };

            var executed_1 = R830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1.Execute(r830_BUSCA_CLIENTE_OUTROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R830_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1190- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, FILLER_1.WABEND.WSQLCODE);

            /*" -1192- CLOSE ARQ-SAIDA. */
            ARQ_SAIDA.Close();

            /*" -1194- DISPLAY WABEND */
            _.Display(FILLER_1.WABEND);

            /*" -1194- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -1196- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1200- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1200- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}