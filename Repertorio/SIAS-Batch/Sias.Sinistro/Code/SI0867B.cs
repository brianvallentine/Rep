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
using Sias.Sinistro.DB2.SI0867B;

namespace Code
{
    public class SI0867B
    {
        public bool IsCall { get; set; }

        public SI0867B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTROS                          *      */
        /*"      *   PROGRAMA ...............  SI0867B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  LUIS RICARDO                       *      */
        /*"      *   CRIACAO ................  29/04/2002.                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ..... GERAR ARQUIVO SEQUENCIAL COM INFORMACOES DO     *      */
        /*"      *    LOTERICO SOLICITADO PELO USUARIO A PARTIR DA  TRANSACAO     *      */
        /*"      *    ON LINE 13-12-36(APLICA  O SI1GA)                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    12/04/2005 - PRODEXTER                                      *      */
        /*"      *   SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A     *      */
        /*"      *   SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQ_SAIDA { get; set; } = new FileBasis(new PIC("X", "950", "X(950)"));

        public FileBasis ARQ_SAIDA
        {
            get
            {
                _.Move(REG_ARQ_SAIDA, _ARQ_SAIDA); VarBasis.RedefinePassValue(REG_ARQ_SAIDA, _ARQ_SAIDA, REG_ARQ_SAIDA); return _ARQ_SAIDA;
            }
        }
        /*"01  REG-ARQ-SAIDA                  PIC X(950).*/
        public StringBasis REG_ARQ_SAIDA { get; set; } = new StringBasis(new PIC("X", "950", "X(950)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
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
        /*"77  W-GDA-NUM-CERTIFICADO       PIC S9(15)V   COMP-3 VALUE 0.*/
        public DoubleBasis W_GDA_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"77  W-GDA-COD-CAUSA             PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_COD_CAUSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-DATA-COMUNICADO       PIC  X(10) VALUE SPACES.*/
        public StringBasis W_GDA_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-DATA-OCORRENCIA       PIC  X(10) VALUE SPACES.*/
        public StringBasis W_GDA_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77  W-GDA-SIT-REGISTRO          PIC  X(01) VALUE SPACE.*/
        public StringBasis W_GDA_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  W-GDA-TIPO-SEGURADO         PIC  X(01) VALUE SPACE.*/
        public StringBasis W_GDA_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77  W-GDA-FONTE-EMIS            PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_FONTE_EMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-FONTE-SINI            PIC S9(04)    COMP   VALUE 0.*/
        public IntBasis W_GDA_FONTE_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  W-GDA-DESCR-PRODUTO         PIC  X(40) VALUE SPACES.*/
        public StringBasis W_GDA_DESCR_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"77  W-GDA-DESCR-CAUSA           PIC  X(40) VALUE SPACES.*/
        public StringBasis W_GDA_DESCR_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        /*"01  AREA-DE-WORK.*/
        public SI0867B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0867B_AREA_DE_WORK();
        public class SI0867B_AREA_DE_WORK : VarBasis
        {
            /*"   05 WSL-SQLCODE                    PIC  9(009) VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    03 W-APOLICE-INICIAL-NUM         PIC 9(13).*/
            public IntBasis W_APOLICE_INICIAL_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03 W-APOLICE-INICIAL-ALFA  REDEFINES W-APOLICE-INICIAL-NUM.*/
            private _REDEF_SI0867B_W_APOLICE_INICIAL_ALFA _w_apolice_inicial_alfa { get; set; }
            public _REDEF_SI0867B_W_APOLICE_INICIAL_ALFA W_APOLICE_INICIAL_ALFA
            {
                get { _w_apolice_inicial_alfa = new _REDEF_SI0867B_W_APOLICE_INICIAL_ALFA(); _.Move(W_APOLICE_INICIAL_NUM, _w_apolice_inicial_alfa); VarBasis.RedefinePassValue(W_APOLICE_INICIAL_NUM, _w_apolice_inicial_alfa, W_APOLICE_INICIAL_NUM); _w_apolice_inicial_alfa.ValueChanged += () => { _.Move(_w_apolice_inicial_alfa, W_APOLICE_INICIAL_NUM); }; return _w_apolice_inicial_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_apolice_inicial_alfa, W_APOLICE_INICIAL_NUM); }
            }  //Redefines
            public class _REDEF_SI0867B_W_APOLICE_INICIAL_ALFA : VarBasis
            {
                /*"       05 W-ORGAO-EMISSOR-INICIAL         PIC 9(03).*/
                public IntBasis W_ORGAO_EMISSOR_INICIAL { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"       05 W-RAMO-INICIAL                  PIC 9(02).*/
                public IntBasis W_RAMO_INICIAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-SEQUENCIA-INICIAL             PIC 9(08).*/
                public IntBasis W_SEQUENCIA_INICIAL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"    03 W-APOLICE-FINAL-NUM           PIC 9(13).*/

                public _REDEF_SI0867B_W_APOLICE_INICIAL_ALFA()
                {
                    W_ORGAO_EMISSOR_INICIAL.ValueChanged += OnValueChanged;
                    W_RAMO_INICIAL.ValueChanged += OnValueChanged;
                    W_SEQUENCIA_INICIAL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_APOLICE_FINAL_NUM { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"    03 W-APOLICE-FINAL-ALFA  REDEFINES  W-APOLICE-FINAL-NUM.*/
            private _REDEF_SI0867B_W_APOLICE_FINAL_ALFA _w_apolice_final_alfa { get; set; }
            public _REDEF_SI0867B_W_APOLICE_FINAL_ALFA W_APOLICE_FINAL_ALFA
            {
                get { _w_apolice_final_alfa = new _REDEF_SI0867B_W_APOLICE_FINAL_ALFA(); _.Move(W_APOLICE_FINAL_NUM, _w_apolice_final_alfa); VarBasis.RedefinePassValue(W_APOLICE_FINAL_NUM, _w_apolice_final_alfa, W_APOLICE_FINAL_NUM); _w_apolice_final_alfa.ValueChanged += () => { _.Move(_w_apolice_final_alfa, W_APOLICE_FINAL_NUM); }; return _w_apolice_final_alfa; }
                set { VarBasis.RedefinePassValue(value, _w_apolice_final_alfa, W_APOLICE_FINAL_NUM); }
            }  //Redefines
            public class _REDEF_SI0867B_W_APOLICE_FINAL_ALFA : VarBasis
            {
                /*"       05 W-ORGAO-EMISSOR-FINAL           PIC 9(03).*/
                public IntBasis W_ORGAO_EMISSOR_FINAL { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"       05 W-RAMO-FINAL                    PIC 9(02).*/
                public IntBasis W_RAMO_FINAL { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"       05 W-SEQUENCIA-FINAL               PIC 9(08).*/
                public IntBasis W_SEQUENCIA_FINAL { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"01  W-INICIO-WORK.*/

                public _REDEF_SI0867B_W_APOLICE_FINAL_ALFA()
                {
                    W_ORGAO_EMISSOR_FINAL.ValueChanged += OnValueChanged;
                    W_RAMO_FINAL.ValueChanged += OnValueChanged;
                    W_SEQUENCIA_FINAL.ValueChanged += OnValueChanged;
                }

            }
        }
        public SI0867B_W_INICIO_WORK W_INICIO_WORK { get; set; } = new SI0867B_W_INICIO_WORK();
        public class SI0867B_W_INICIO_WORK : VarBasis
        {
            /*"    03 W-FIM-RELATORIO                PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-RAMO                     PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RAMO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-PRODUTO                  PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-APOLICE                  PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_APOLICE { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-FIM-RAMOVG                   PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_FIM_RAMOVG { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03 W-CHAVE-ARQ-SAIDA-JA-ABERTO    PIC X(03)  VALUE 'NAO'.*/
            public StringBasis W_CHAVE_ARQ_SAIDA_JA_ABERTO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"NAO");
            /*"    03  WGD-CEP                       PIC 9(08)  VALUE 0.*/
            public IntBasis WGD_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    03  FILLER REDEFINES WGD-CEP.*/
            private _REDEF_SI0867B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_SI0867B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_SI0867B_FILLER_0(); _.Move(WGD_CEP, _filler_0); VarBasis.RedefinePassValue(WGD_CEP, _filler_0, WGD_CEP); _filler_0.ValueChanged += () => { _.Move(_filler_0, WGD_CEP); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WGD_CEP); }
            }  //Redefines
            public class _REDEF_SI0867B_FILLER_0 : VarBasis
            {
                /*"        05  WGD-CEP-PRINC             PIC 9(05).*/
                public IntBasis WGD_CEP_PRINC { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"        05  WGD-CEP-EXTENS            PIC 9(03).*/
                public IntBasis WGD_CEP_EXTENS { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"    03  WCONTADORES.*/

                public _REDEF_SI0867B_FILLER_0()
                {
                    WGD_CEP_PRINC.ValueChanged += OnValueChanged;
                    WGD_CEP_EXTENS.ValueChanged += OnValueChanged;
                }

            }
            public SI0867B_WCONTADORES WCONTADORES { get; set; } = new SI0867B_WCONTADORES();
            public class SI0867B_WCONTADORES : VarBasis
            {
                /*"        05 W-QTD-AVISADO        PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_AVISADO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-CANCELADO      PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_CANCELADO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-AUM-RESERVA    PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_AUM_RESERVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-DIM-RESERVA    PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_DIM_RESERVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-REATIVACAO     PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_REATIVACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-CORR-MONET     PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_CORR_MONET { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-INDENIZ        PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_INDENIZ { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-ESTORNOS       PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_ESTORNOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-DESPESAS       PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_DESPESAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-EST-DESP       PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_EST_DESP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-HONORARIOS     PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_HONORARIOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-EST-HONOR      PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_EST_HONOR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-SALVADOS       PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_SALVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-DESP-SALV      PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_DESP_SALV { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-EST-HONOR-SALV PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_EST_HONOR_SALV { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-HONOR-SALV     PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_HONOR_SALV { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"        05 W-QTD-PENDENTE       PIC  9(06) VALUE 0.*/
                public IntBasis W_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03  WACUMULADORES.*/
            }
            public SI0867B_WACUMULADORES WACUMULADORES { get; set; } = new SI0867B_WACUMULADORES();
            public class SI0867B_WACUMULADORES : VarBasis
            {
                /*"        05 W-ACM-AVISADO        PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-CANCELADO      PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_CANCELADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-AUM-RESERVA    PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_AUM_RESERVA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-DIM-RESERVA    PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_DIM_RESERVA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-REATIVACAO     PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_REATIVACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-CORR-MONET     PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_CORR_MONET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-INDENIZ        PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-ESTORNOS       PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_ESTORNOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-DESPESAS       PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-EST-DESP       PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_EST_DESP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-HONORARIOS     PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_HONORARIOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-EST-HONOR      PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_EST_HONOR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-SALVADOS       PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_SALVADOS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-DESP-SALV      PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_DESP_SALV { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-EST-HONOR-SALV PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_EST_HONOR_SALV { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-HONOR-SALV     PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_HONOR_SALV { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"        05 W-ACM-PENDENTE       PIC  9(13)V99 VALUE 0.*/
                public DoubleBasis W_ACM_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
                /*"01  FILLER.*/
            }
        }
        public SI0867B_FILLER_1 FILLER_1 { get; set; } = new SI0867B_FILLER_1();
        public class SI0867B_FILLER_1 : VarBasis
        {
            /*"    05 WABEND.*/
            public SI0867B_WABEND WABEND { get; set; } = new SI0867B_WABEND();
            public class SI0867B_WABEND : VarBasis
            {
                /*"       10 FILLER                     PIC  X(009) VALUE          'SI0867B '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"SI0867B ");
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
        public SI0867B_FILLER01 FILLER01 { get; set; } = new SI0867B_FILLER01();
        public class SI0867B_FILLER01 : VarBasis
        {
            /*"  02 LD01.*/
            public SI0867B_LD01 LD01 { get; set; } = new SI0867B_LD01();
            public class SI0867B_LD01 : VarBasis
            {
                /*"    03 LD01-SOLICITANTE         PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-RAMO-SOLIC          PIC  9(04) VALUE 0.*/
                public IntBasis LD01_RAMO_SOLIC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-APOLICE-SOLIC       PIC  9(13) VALUE 0.*/
                public IntBasis LD01_APOLICE_SOLIC { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-SUBGRUPO-SOLIC  PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_SUBGRUPO_SOLIC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-PRODUTO-SOLIC   PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_PRODUTO_SOLIC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-SOLIC          PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-PROC           PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-RAMO                PIC  9(04) VALUE 0.*/
                public IntBasis LD01_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-APOLICE             PIC  9(13) VALUE 0.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-SINISTRO            PIC  9(13) VALUE 0.*/
                public IntBasis LD01_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-SITUACAO            PIC  X(09) VALUE SPACES.*/
                public StringBasis LD01_SITUACAO { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-SUBGRUPO        PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-PRODUTO         PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-PRODUTO             PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-FONTE-EMIS      PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_FONTE_EMIS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-FONTE-EMISSAO       PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_FONTE_EMISSAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-FONTE-SINI      PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_FONTE_SINI { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-FONTE-SINISTRO      PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_FONTE_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-COD-CAUSA           PIC  9(04) VALUE 0.*/
                public IntBasis LD01_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DESCR-CAUSA         PIC  X(40) VALUE SPACES.*/
                public StringBasis LD01_DESCR_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-COMUNICADO     PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-DATA-OCORRENCIA     PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-PERI-INICIAL        PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-PERI-FINAL          PIC  X(10) VALUE SPACES.*/
                public StringBasis LD01_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-AVISADO         PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_AVISADO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-AVISADO         PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-CANCELADO       PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_CANCELADO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-CANCELADO       PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_CANCELADO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-AUM-RESERVA     PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_AUM_RESERVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-AUM-RESERVA     PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_AUM_RESERVA { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-DIM-RESERVA     PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_DIM_RESERVA { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-DIM-RESERVA     PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_DIM_RESERVA { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-REATIVACAO      PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_REATIVACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-REATIVACAO      PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_REATIVACAO { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-CORR-MONET      PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_CORR_MONET { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-CORR-MONET      PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_CORR_MONET { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-INDENIZ         PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_INDENIZ { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-INDENIZ         PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_INDENIZ { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-ESTORNOS        PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_ESTORNOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-ESTORNOS        PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_ESTORNOS { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-DESPESAS        PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_DESPESAS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-DESPESAS        PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-EST-DESP        PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_EST_DESP { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-EST-DESP        PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_EST_DESP { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-HONORARIOS      PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_HONORARIOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-HONORARIOS      PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_HONORARIOS { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-EST-HONOR       PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_EST_HONOR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-EST-HONOR       PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_EST_HONOR { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-SALVADOS        PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_SALVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-SALVADOS        PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_SALVADOS { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-DESP-SALV       PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_DESP_SALV { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-DESP-SALV       PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_DESP_SALV { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-EST-HONOR-SALV  PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_EST_HONOR_SALV { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-EST-HONOR-SALV  PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_EST_HONOR_SALV { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-HONOR-SALV      PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_HONOR_SALV { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-HONOR-SALV      PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_HONOR_SALV { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-QTD-PENDENTE        PIC  9(06) VALUE 0.*/
                public IntBasis LD01_QTD_PENDENTE { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03 LD01-ACM-PENDENTE        PIC  ------------9,99.*/
                public DoubleBasis LD01_ACM_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "------------9V99."), 2);
                /*"    03 FILLER                   PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  02 LC01.*/
            }
            public SI0867B_LC01 LC01 { get; set; } = new SI0867B_LC01();
            public class SI0867B_LC01 : VarBasis
            {
                /*"    03  FILLER                  PIC  X(11) VALUE 'SOLICITANTE'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SOLICITANTE");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(15) VALUE        'RAMO SOLICITADO'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"RAMO SOLICITADO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(18) VALUE        'APOLICE SOLICITADA'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"APOLICE SOLICITADA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'COD SUBGRUPO'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"COD SUBGRUPO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(22) VALUE        'COD PRODUTO SOLICITADO'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"COD PRODUTO SOLICITADO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(19) VALUE        'DATA DA SOLICITACAO'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"DATA DA SOLICITACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(21) VALUE        'DATA DO PROCESSAMENTO'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"DATA DO PROCESSAMENTO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(04) VALUE        'RAMO'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"RAMO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(07) VALUE        'APOLICE'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(08) VALUE        'SINISTRO'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SINISTRO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(08) VALUE        'SITUACAO'.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SITUACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(09) VALUE        'SUB GRUPO'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"SUB GRUPO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'COD. PRODUTO'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"COD. PRODUTO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(07) VALUE        'PRODUTO'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(18) VALUE        'COD. FONTE EMISSAO'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"COD. FONTE EMISSAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(13) VALUE        'FONTE EMISSAO'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"FONTE EMISSAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(19) VALUE        'COD. FONTE SINISTRO'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "19", "X(19)"), @"COD. FONTE SINISTRO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(14) VALUE        'FONTE SINISTRO'.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"FONTE SINISTRO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        'COD. CAUSA'.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"COD. CAUSA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(05) VALUE        'CAUSA'.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"CAUSA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(15) VALUE        'DATA COMUNICADO'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA COMUNICADO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(15) VALUE        'DATA OCORRENCIA'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"DATA OCORRENCIA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'DATA INICIAL'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"DATA INICIAL");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        'DATA FINAL'.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"DATA FINAL");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'QTD AVISADOS'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"QTD AVISADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        '$ AVISADOS'.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ AVISADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(14) VALUE        'QTD CANCELADOS'.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"QTD CANCELADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(14) VALUE        '$ CANCELADOS  '.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"$ CANCELADOS  ");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(22) VALUE        'QTD AUMENTO DE RESERVA'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"QTD AUMENTO DE RESERVA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(20) VALUE        '$ AUMENTO DE RESERVA'.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"$ AUMENTO DE RESERVA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(25) VALUE        'QTD DIMINUICAO DE RESERVA'.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "25", "X(25)"), @"QTD DIMINUICAO DE RESERVA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(23) VALUE        '$ DIMINUICAO DE RESERVA'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"$ DIMINUICAO DE RESERVA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(17) VALUE        'QTD DE REATIVACAO'.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @"QTD DE REATIVACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(15) VALUE        '$ DE REATIVACAO'.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"$ DE REATIVACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(22) VALUE        'QTD CORRECAO MONETARIA'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"QTD CORRECAO MONETARIA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(20) VALUE        '$ CORRECAO MONETARIA'.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"$ CORRECAO MONETARIA");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(15) VALUE        'QTD INDENIZACAO'.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"QTD INDENIZACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(13) VALUE        '$ INDENIZACAO'.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"$ INDENIZACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'QTD ESTORNOS'.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"QTD ESTORNOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        '$ ESTORNOS'.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ ESTORNOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'QTD DESPESAS'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"QTD DESPESAS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        '$ DESPESAS'.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ DESPESAS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(20) VALUE        'QTD ESTORNO DESPESAS'.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"QTD ESTORNO DESPESAS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(18) VALUE        '$ ESTORNO DESPESAS'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"$ ESTORNO DESPESAS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(14) VALUE        'QTD HONORARIOS'.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"QTD HONORARIOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        '$ HONORARIOS'.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"$ HONORARIOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(22) VALUE        'QTD ESTORNO HONORARIOS'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"QTD ESTORNO HONORARIOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(20) VALUE        '$ ESTORNO HONORARIOS'.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"$ ESTORNO HONORARIOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(12) VALUE        'QTD SALVADOS'.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"QTD SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        '$ SALVADOS'.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(20) VALUE        'QTD DESPESA SALVADOS'.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"QTD DESPESA SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(18) VALUE        '$ DESPESA SALVADOS'.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "18", "X(18)"), @"$ DESPESA SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(31) VALUE        'QTD ESTORNO HONORARIOS SALVADOS'.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"QTD ESTORNO HONORARIOS SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(29) VALUE        '$ ESTORNO HONORARIOS SALVADOS'.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @"$ ESTORNO HONORARIOS SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(23) VALUE        'QTD HONORARIOS SALVADOS'.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "23", "X(23)"), @"QTD HONORARIOS SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(21) VALUE        '$ HONORARIOS SALVADOS'.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "21", "X(21)"), @"$ HONORARIOS SALVADOS");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(13) VALUE        'QTD PENDENTES'.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"QTD PENDENTES");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(10) VALUE        '$ PENDENTE'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"$ PENDENTE");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"  02  LC02.*/
            }
            public SI0867B_LC02 LC02 { get; set; } = new SI0867B_LC02();
            public class SI0867B_LC02 : VarBasis
            {
                /*"    03  C02-IDENTIFICADOR       PIC  X(29) VALUE        'PROGRAMA GERADOR >>> SI0867B;'.*/
                public StringBasis C02_IDENTIFICADOR { get; set; } = new StringBasis(new PIC("X", "29", "X(29)"), @"PROGRAMA GERADOR >>> SI0867B;");
                /*"  02  LC03.*/
            }
            public SI0867B_LC03 LC03 { get; set; } = new SI0867B_LC03();
            public class SI0867B_LC03 : VarBasis
            {
                /*"    03  C03-FUNCAO              PIC  X(40) VALUE        'RELATORIO DE ACOMPANHAMENTO DE SINISTRO;'.*/
                public StringBasis C03_FUNCAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"RELATORIO DE ACOMPANHAMENTO DE SINISTRO;");
                /*"  02  LC04.*/
            }
            public SI0867B_LC04 LC04 { get; set; } = new SI0867B_LC04();
            public class SI0867B_LC04 : VarBasis
            {
                /*"    03  C04-SEM-MOV             PIC  X(38) VALUE        'NAO HA MOVIMENTO PARA ESSA SOLICITACAO'.*/
                public StringBasis C04_SEM_MOV { get; set; } = new StringBasis(new PIC("X", "38", "X(38)"), @"NAO HA MOVIMENTO PARA ESSA SOLICITACAO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(11) VALUE 'SOLICITANTE'.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"SOLICITANTE");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  C04-SOLICITANTE         PIC  X(40) VALUE SPACES.*/
                public StringBasis C04_SOLICITANTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(04) VALUE 'RAMO'.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"RAMO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  C04-RAMO                PIC  9(04) VALUE 0.*/
                public IntBasis C04_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(07) VALUE 'APOLICE'.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  C04-APOLICE             PIC  9(13) VALUE 0.*/
                public IntBasis C04_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(08) VALUE 'SUBGRUPO'.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"SUBGRUPO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  C04-COD-SUBGRUPO        PIC  9(04) VALUE 0.*/
                public IntBasis C04_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  FILLER                  PIC  X(07) VALUE 'PRODUTO'.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    03  C04-COD-PRODUTO         PIC  9(04) VALUE 0.*/
                public IntBasis C04_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    03  FILLER                  PIC  X(01) VALUE ';'.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"01  FILLER REDEFINES FILLER01.*/
            }
        }
        private _REDEF_SI0867B_FILLER_195 _filler_195 { get; set; }
        public _REDEF_SI0867B_FILLER_195 FILLER_195
        {
            get { _filler_195 = new _REDEF_SI0867B_FILLER_195(); _.Move(FILLER01, _filler_195); VarBasis.RedefinePassValue(FILLER01, _filler_195, FILLER01); _filler_195.ValueChanged += () => { _.Move(_filler_195, FILLER01); }; return _filler_195; }
            set { VarBasis.RedefinePassValue(value, _filler_195, FILLER01); }
        }  //Redefines
        public class _REDEF_SI0867B_FILLER_195 : VarBasis
        {
            /*"    03  C01-FILLER               PIC  X(600).*/
            public StringBasis C01_FILLER { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");

            public _REDEF_SI0867B_FILLER_195()
            {
                C01_FILLER.ValueChanged += OnValueChanged;
            }

        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.SINIITEM SINIITEM { get; set; } = new Dclgens.SINIITEM();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.LOTISG01 LOTISG01 { get; set; } = new Dclgens.LOTISG01();
        public Dclgens.USUARIOS USUARIOS { get; set; } = new Dclgens.USUARIOS();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public SI0867B_RELATORIOS RELATORIOS { get; set; } = new SI0867B_RELATORIOS();
        public SI0867B_RAMO RAMO { get; set; } = new SI0867B_RAMO();
        public SI0867B_C01_PRODUTO C01_PRODUTO { get; set; } = new SI0867B_C01_PRODUTO();
        public SI0867B_APOLICE APOLICE { get; set; } = new SI0867B_APOLICE();
        public SI0867B_RAMOVG RAMOVG { get; set; } = new SI0867B_RAMOVG();
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

                /*" -552- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -553- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -554- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -558- OPEN OUTPUT ARQ-SAIDA. */
                ARQ_SAIDA.Open(REG_ARQ_SAIDA);

                /*" -560- PERFORM R010-SELECT-SISTEMA THRU R010-EXIT. */

                R010_SELECT_SISTEMA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R010_EXIT*/


                /*" -561- PERFORM R020-DECLARE-RELATORIO THRU R020-EXIT. */

                R020_DECLARE_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/


                /*" -563- MOVE 'NAO' TO W-FIM-RELATORIO. */
                _.Move("NAO", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -565- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

                R021_FETCH_RELATORIO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


                /*" -566- IF W-FIM-RELATORIO EQUAL 'SIM' */

                if (W_INICIO_WORK.W_FIM_RELATORIO == "SIM")
                {

                    /*" -567- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -568- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -569- DISPLAY '       NADA SELECIONADO NA DATA DE HOJE         ' */
                    _.Display($"       NADA SELECIONADO NA DATA DE HOJE         ");

                    /*" -570- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -571- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -572- MOVE 'NAO HOUVE SOLICITACAO NA DATA DE HOJE' TO C01-FILLER */
                    _.Move("NAO HOUVE SOLICITACAO NA DATA DE HOJE", FILLER_195.C01_FILLER);

                    /*" -573- WRITE REG-ARQ-SAIDA FROM LD01 */
                    _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

                    ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

                    /*" -575- GO TO 000-TERMINA. */

                    M_000_TERMINA(); //GOTO
                    return Result;
                }


                /*" -578- PERFORM R030-PROCESSA-RELATORIO THRU R030-EXIT UNTIL (W-FIM-RELATORIO EQUAL 'SIM' ). */

                while (!((W_INICIO_WORK.W_FIM_RELATORIO == "SIM")))
                {

                    R030_PROCESSA_RELATORIO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

                }

                /*" -580- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", FILLER_1.WABEND.WNR_EXEC_SQL);

                /*" -585- PERFORM Execute_DB_UPDATE_1 */

                Execute_DB_UPDATE_1();

                /*" -588- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -589- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -590- DISPLAY 'ERRO NO UPDATE RELATORIOS.......' */
                    _.Display($"ERRO NO UPDATE RELATORIOS.......");

                    /*" -591- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -591- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -591- FLUXCONTROL_PERFORM Execute-DB-UPDATE-1 */

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
            /*" -585- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0867B' AND SIT_REGISTRO = '0' END-EXEC. */

            var execute_DB_UPDATE_1_Update1 = new Execute_DB_UPDATE_1_Update1()
            {
            };

            Execute_DB_UPDATE_1_Update1.Execute(execute_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-000-TERMINA */
        private void M_000_TERMINA(bool isPerform = false)
        {
            /*" -596- DISPLAY '************************************' */
            _.Display($"************************************");

            /*" -597- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -598- DISPLAY '*   TERMINO NORMAL DO PROGRAMA     *' */
            _.Display($"*   TERMINO NORMAL DO PROGRAMA     *");

            /*" -599- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -600- DISPLAY '*            SI0867B               *' */
            _.Display($"*            SI0867B               *");

            /*" -601- DISPLAY '*                                  *' */
            _.Display($"*                                  *");

            /*" -601- DISPLAY '************************************' . */
            _.Display($"************************************");

        }

        [StopWatch]
        /*" M-000-FIM-PROGRAMA */
        private void M_000_FIM_PROGRAMA(bool isPerform = false)
        {
            /*" -606- CLOSE ARQ-SAIDA */
            ARQ_SAIDA.Close();

            /*" -607- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -607- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA */
        private void R010_SELECT_SISTEMA(bool isPerform = false)
        {
            /*" -613- MOVE '002' TO WNR-EXEC-SQL */
            _.Move("002", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -618- PERFORM R010_SELECT_SISTEMA_DB_SELECT_1 */

            R010_SELECT_SISTEMA_DB_SELECT_1();

            /*" -621- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -622- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -623- DISPLAY 'ERRO NO ACESSO - SISTEMA .......' */
                _.Display($"ERRO NO ACESSO - SISTEMA .......");

                /*" -624- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -625- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -626- ELSE */
            }
            else
            {


                /*" -628- MOVE SISTEMAS-DATA-MOV-ABERTO(09:02) TO LD01-DATA-PROC(01:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), FILLER01.LD01.LD01_DATA_PROC, 1, 2);

                /*" -629- MOVE '/' TO LD01-DATA-PROC(03:01) */
                _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_PROC, 3, 1);

                /*" -631- MOVE SISTEMAS-DATA-MOV-ABERTO(06:02) TO LD01-DATA-PROC(04:02) */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), FILLER01.LD01.LD01_DATA_PROC, 4, 2);

                /*" -632- MOVE '/' TO LD01-DATA-PROC(06:01) */
                _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_PROC, 6, 1);

                /*" -633- MOVE SISTEMAS-DATA-MOV-ABERTO(01:04) TO LD01-DATA-PROC(07:04). */
                _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), FILLER01.LD01.LD01_DATA_PROC, 7, 4);
            }


        }

        [StopWatch]
        /*" R010-SELECT-SISTEMA-DB-SELECT-1 */
        public void R010_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -618- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

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
            /*" -642- MOVE '003' TO WNR-EXEC-SQL */
            _.Move("003", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -655- PERFORM R020_DECLARE_RELATORIO_DB_DECLARE_1 */

            R020_DECLARE_RELATORIO_DB_DECLARE_1();

            /*" -657- PERFORM R020_DECLARE_RELATORIO_DB_OPEN_1 */

            R020_DECLARE_RELATORIO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-DECLARE-1 */
        public void R020_DECLARE_RELATORIO_DB_DECLARE_1()
        {
            /*" -655- EXEC SQL DECLARE RELATORIOS CURSOR FOR SELECT COD_USUARIO, DATA_SOLICITACAO, NUM_APOLICE, PERI_INICIAL, PERI_FINAL, RAMO_EMISSOR, COD_OPERACAO AS PRODUTO, COD_SUBGRUPO FROM SEGUROS.RELATORIOS WHERE IDE_SISTEMA = 'SI' AND COD_RELATORIO = 'SI0867B' AND SIT_REGISTRO = '0' END-EXEC */
            RELATORIOS = new SI0867B_RELATORIOS(false);
            string GetQuery_RELATORIOS()
            {
                var query = @$"SELECT COD_USUARIO
							, 
							DATA_SOLICITACAO
							, 
							NUM_APOLICE
							, 
							PERI_INICIAL
							, 
							PERI_FINAL
							, 
							RAMO_EMISSOR
							, 
							COD_OPERACAO AS PRODUTO
							, 
							COD_SUBGRUPO 
							FROM SEGUROS.RELATORIOS 
							WHERE IDE_SISTEMA = 'SI' 
							AND COD_RELATORIO = 'SI0867B' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            RELATORIOS.GetQueryEvent += GetQuery_RELATORIOS;

        }

        [StopWatch]
        /*" R020-DECLARE-RELATORIO-DB-OPEN-1 */
        public void R020_DECLARE_RELATORIO_DB_OPEN_1()
        {
            /*" -657- EXEC SQL OPEN RELATORIOS END-EXEC. */

            RELATORIOS.Open();

        }

        [StopWatch]
        /*" R041-DECLARE-RAMO-DB-DECLARE-1 */
        public void R041_DECLARE_RAMO_DB_DECLARE_1()
        {
            /*" -856- EXEC SQL DECLARE RAMO CURSOR FOR SELECT M.RAMO, M.COD_PRODUTO, M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.TIPO_REGISTRO, M.COD_SUBGRUPO, M.NUM_CERTIFICADO, M.COD_CAUSA, M.DATA_COMUNICADO, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.TIPO_SEGURADO, E.COD_FONTE AS FONTE_EMISSAO, P.DESCR_PRODUTO, M.COD_FONTE AS FONTE_SINISTRO, SC.DESCR_CAUSA, H.COD_OPERACAO, H.VAL_OPERACAO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.PRODUTO P, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.ENDOSSOS E WHERE M.NUM_APOLICE BETWEEN :HOST-APOL-INICIO AND :HOST-APOL-FIM AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO BETWEEN :RELATORI-PERI-INICIAL AND :RELATORI-PERI-FINAL AND P.COD_PRODUTO = M.COD_PRODUTO AND SC.RAMO_EMISSOR = M.RAMO AND SC.COD_CAUSA = M.COD_CAUSA AND E.NUM_APOLICE = M.NUM_APOLICE AND E.NUM_ENDOSSO = 0 ORDER BY M.NUM_APOL_SINISTRO END-EXEC. */
            RAMO = new SI0867B_RAMO(true);
            string GetQuery_RAMO()
            {
                var query = @$"SELECT M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.TIPO_REGISTRO
							, 
							M.COD_SUBGRUPO
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_CAUSA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_OCORRENCIA
							, 
							M.SIT_REGISTRO
							, 
							M.TIPO_SEGURADO
							, 
							E.COD_FONTE AS FONTE_EMISSAO
							, 
							P.DESCR_PRODUTO
							, 
							M.COD_FONTE AS FONTE_SINISTRO
							, 
							SC.DESCR_CAUSA
							, 
							H.COD_OPERACAO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.PRODUTO P
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.ENDOSSOS E 
							WHERE M.NUM_APOLICE BETWEEN '{HOST_APOL_INICIO}' 
							AND '{HOST_APOL_FIM}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							AND P.COD_PRODUTO = M.COD_PRODUTO 
							AND SC.RAMO_EMISSOR = M.RAMO 
							AND SC.COD_CAUSA = M.COD_CAUSA 
							AND E.NUM_APOLICE = M.NUM_APOLICE 
							AND E.NUM_ENDOSSO = 0 
							ORDER BY M.NUM_APOL_SINISTRO";

                return query;
            }
            RAMO.GetQueryEvent += GetQuery_RAMO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R020_EXIT*/

        [StopWatch]
        /*" R021-FETCH-RELATORIO */
        private void R021_FETCH_RELATORIO(bool isPerform = false)
        {
            /*" -666- MOVE '004' TO WNR-EXEC-SQL */
            _.Move("004", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -675- PERFORM R021_FETCH_RELATORIO_DB_FETCH_1 */

            R021_FETCH_RELATORIO_DB_FETCH_1();

            /*" -678- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -679- MOVE 'SIM' TO W-FIM-RELATORIO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RELATORIO);

                /*" -679- PERFORM R021_FETCH_RELATORIO_DB_CLOSE_1 */

                R021_FETCH_RELATORIO_DB_CLOSE_1();

                /*" -682- GO TO R021-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/ //GOTO
                return;
            }


            /*" -683- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -684- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -685- DISPLAY 'ERRO FETCH NA RELATORIOS...........' */
                _.Display($"ERRO FETCH NA RELATORIOS...........");

                /*" -686- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -688- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -690- MOVE '005' TO WNR-EXEC-SQL. */
            _.Move("005", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -695- PERFORM R021_FETCH_RELATORIO_DB_SELECT_1 */

            R021_FETCH_RELATORIO_DB_SELECT_1();

            /*" -698- IF (SQLCODE NOT EQUAL 100) AND (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 100) && (DB.SQLCODE != 0))
            {

                /*" -699- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -700- DISPLAY 'ERRO NA LEITURA DA USUARIOS........' */
                _.Display($"ERRO NA LEITURA DA USUARIOS........");

                /*" -701- DISPLAY 'COD. USUARIO : ' RELATORI-COD-USUARIO */
                _.Display($"COD. USUARIO : {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}");

                /*" -702- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -704- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -706- MOVE RELATORI-DATA-SOLICITACAO(09:02) TO LD01-DATA-SOLIC(01:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(9, 2), FILLER01.LD01.LD01_DATA_SOLIC, 1, 2);

            /*" -707- MOVE '/' TO LD01-DATA-SOLIC(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_SOLIC, 3, 1);

            /*" -709- MOVE RELATORI-DATA-SOLICITACAO(06:02) TO LD01-DATA-SOLIC(04:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(6, 2), FILLER01.LD01.LD01_DATA_SOLIC, 4, 2);

            /*" -710- MOVE '/' TO LD01-DATA-SOLIC(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_SOLIC, 6, 1);

            /*" -712- MOVE RELATORI-DATA-SOLICITACAO(01:04) TO LD01-DATA-SOLIC(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Substring(1, 4), FILLER01.LD01.LD01_DATA_SOLIC, 7, 4);

            /*" -713- MOVE USUARIOS-NOME-USUARIO TO LD01-SOLICITANTE. */
            _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, FILLER01.LD01.LD01_SOLICITANTE);

            /*" -714- MOVE RELATORI-RAMO-EMISSOR TO LD01-RAMO-SOLIC. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, FILLER01.LD01.LD01_RAMO_SOLIC);

            /*" -715- MOVE RELATORI-NUM-APOLICE TO LD01-APOLICE-SOLIC. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, FILLER01.LD01.LD01_APOLICE_SOLIC);

            /*" -716- MOVE RELATORI-COD-SUBGRUPO TO LD01-COD-SUBGRUPO-SOLIC. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, FILLER01.LD01.LD01_COD_SUBGRUPO_SOLIC);

            /*" -719- MOVE RELATORI-COD-OPERACAO TO LD01-COD-PRODUTO-SOLIC. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, FILLER01.LD01.LD01_COD_PRODUTO_SOLIC);

            /*" -720- WRITE REG-ARQ-SAIDA FROM LC02. */
            _.Move(FILLER01.LC02.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -721- WRITE REG-ARQ-SAIDA FROM LC03. */
            _.Move(FILLER01.LC03.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

            /*" -721- WRITE REG-ARQ-SAIDA FROM LC01. */
            _.Move(FILLER01.LC01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-FETCH-1 */
        public void R021_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -675- EXEC SQL FETCH RELATORIOS INTO :RELATORI-COD-USUARIO, :RELATORI-DATA-SOLICITACAO, :RELATORI-NUM-APOLICE, :RELATORI-PERI-INICIAL, :RELATORI-PERI-FINAL, :RELATORI-RAMO-EMISSOR, :RELATORI-COD-OPERACAO, :RELATORI-COD-SUBGRUPO END-EXEC. */

            if (RELATORIOS.Fetch())
            {
                _.Move(RELATORIOS.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
                _.Move(RELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(RELATORIOS.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(RELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(RELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(RELATORIOS.RELATORI_RAMO_EMISSOR, RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR);
                _.Move(RELATORIOS.RELATORI_COD_OPERACAO, RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO);
                _.Move(RELATORIOS.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
            }

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-CLOSE-1 */
        public void R021_FETCH_RELATORIO_DB_CLOSE_1()
        {
            /*" -679- EXEC SQL CLOSE RELATORIOS END-EXEC */

            RELATORIOS.Close();

        }

        [StopWatch]
        /*" R021-FETCH-RELATORIO-DB-SELECT-1 */
        public void R021_FETCH_RELATORIO_DB_SELECT_1()
        {
            /*" -695- EXEC SQL SELECT NOME_USUARIO INTO :USUARIOS-NOME-USUARIO FROM SEGUROS.USUARIOS WHERE COD_USUARIO = :RELATORI-COD-USUARIO END-EXEC. */

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
        /*" R030-PROCESSA-RELATORIO */
        private void R030_PROCESSA_RELATORIO(bool isPerform = false)
        {
            /*" -734- MOVE 'NAO' TO WIND-PCS-RAMO WIND-PCS-PRODUTO WIND-PCS-RAMOVG WIND-PCS-APOLICE. */
            _.Move("NAO", WIND_PCS_RAMO, WIND_PCS_PRODUTO, WIND_PCS_RAMOVG, WIND_PCS_APOLICE);

            /*" -735- MOVE 010 TO W-ORGAO-EMISSOR-INICIAL W-ORGAO-EMISSOR-FINAL. */
            _.Move(010, AREA_DE_WORK.W_APOLICE_INICIAL_ALFA.W_ORGAO_EMISSOR_INICIAL);
            _.Move(010, AREA_DE_WORK.W_APOLICE_FINAL_ALFA.W_ORGAO_EMISSOR_FINAL);


            /*" -736- MOVE RELATORI-RAMO-EMISSOR TO W-RAMO-INICIAL W-RAMO-FINAL. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, AREA_DE_WORK.W_APOLICE_INICIAL_ALFA.W_RAMO_INICIAL);
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, AREA_DE_WORK.W_APOLICE_FINAL_ALFA.W_RAMO_FINAL);


            /*" -737- MOVE ZEROS TO W-SEQUENCIA-INICIAL. */
            _.Move(0, AREA_DE_WORK.W_APOLICE_INICIAL_ALFA.W_SEQUENCIA_INICIAL);

            /*" -739- MOVE 99999999 TO W-SEQUENCIA-FINAL. */
            _.Move(99999999, AREA_DE_WORK.W_APOLICE_FINAL_ALFA.W_SEQUENCIA_FINAL);

            /*" -740- MOVE W-APOLICE-INICIAL-NUM TO HOST-APOL-INICIO. */
            _.Move(AREA_DE_WORK.W_APOLICE_INICIAL_NUM, HOST_APOL_INICIO);

            /*" -742- MOVE W-APOLICE-FINAL-NUM TO HOST-APOL-FIM. */
            _.Move(AREA_DE_WORK.W_APOLICE_FINAL_NUM, HOST_APOL_FIM);

            /*" -743- IF RELATORI-RAMO-EMISSOR NOT EQUAL 0 */

            if (RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR != 0)
            {

                /*" -744- IF RELATORI-RAMO-EMISSOR EQUAL 81 OR 93 */

                if (RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.In("81", "93"))
                {

                    /*" -745- MOVE 'SIM' TO WIND-PCS-RAMOVG */
                    _.Move("SIM", WIND_PCS_RAMOVG);

                    /*" -746- ELSE */
                }
                else
                {


                    /*" -747- MOVE 'SIM' TO WIND-PCS-RAMO */
                    _.Move("SIM", WIND_PCS_RAMO);

                    /*" -748- END-IF */
                }


                /*" -749- ELSE */
            }
            else
            {


                /*" -750- IF RELATORI-COD-OPERACAO NOT EQUAL 0 */

                if (RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO != 0)
                {

                    /*" -751- MOVE 'SIM' TO WIND-PCS-PRODUTO */
                    _.Move("SIM", WIND_PCS_PRODUTO);

                    /*" -752- ELSE */
                }
                else
                {


                    /*" -753- IF RELATORI-NUM-APOLICE NOT EQUAL 0 */

                    if (RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE != 0)
                    {

                        /*" -754- IF RELATORI-COD-SUBGRUPO EQUAL 0 */

                        if (RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO == 0)
                        {

                            /*" -755- MOVE 0 TO HOST-SG1 */
                            _.Move(0, HOST_SG1);

                            /*" -756- MOVE 9999 TO HOST-SG2 */
                            _.Move(9999, HOST_SG2);

                            /*" -757- ELSE */
                        }
                        else
                        {


                            /*" -759- MOVE RELATORI-COD-SUBGRUPO TO HOST-SG1 HOST-SG2 */
                            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, HOST_SG1, HOST_SG2);

                            /*" -760- END-IF */
                        }


                        /*" -762- MOVE 'SIM' TO WIND-PCS-APOLICE. */
                        _.Move("SIM", WIND_PCS_APOLICE);
                    }

                }

            }


            /*" -764- PERFORM R040-DECLARA-CURSORES THRU R040-EXIT. */

            R040_DECLARA_CURSORES(true);

            R041_DECLARE_RAMO(true);

            R042_DECLARE_PRODUTO(true);

            R043_DECLARE_APOLICE(true);

            R044_DECLARE_RAMOVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/


            /*" -769- MOVE 'NAO' TO W-FIM-RAMO W-FIM-PRODUTO W-FIM-RAMOVG W-FIM-APOLICE. */
            _.Move("NAO", W_INICIO_WORK.W_FIM_RAMO, W_INICIO_WORK.W_FIM_PRODUTO, W_INICIO_WORK.W_FIM_RAMOVG, W_INICIO_WORK.W_FIM_APOLICE);

            /*" -770- PERFORM R050-FETCH-CURSORES THRU R050-EXIT. */

            R050_FETCH_CURSORES(true);

            R051_FETCH_RAMO(true);

            R052_FETCH_PRODUTO(true);

            R053_FETCH_APOLICE(true);

            R054_FETCH_RAMOVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


            /*" -774- IF W-FIM-RAMO EQUAL 'SIM' OR W-FIM-PRODUTO EQUAL 'SIM' OR W-FIM-RAMOVG EQUAL 'SIM' OR W-FIM-APOLICE EQUAL 'SIM' */

            if (W_INICIO_WORK.W_FIM_RAMO == "SIM" || W_INICIO_WORK.W_FIM_PRODUTO == "SIM" || W_INICIO_WORK.W_FIM_RAMOVG == "SIM" || W_INICIO_WORK.W_FIM_APOLICE == "SIM")
            {

                /*" -775- MOVE USUARIOS-NOME-USUARIO TO C04-SOLICITANTE */
                _.Move(USUARIOS.DCLUSUARIOS.USUARIOS_NOME_USUARIO, FILLER01.LC04.C04_SOLICITANTE);

                /*" -776- MOVE RELATORI-NUM-APOLICE TO C04-APOLICE */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, FILLER01.LC04.C04_APOLICE);

                /*" -777- MOVE RELATORI-RAMO-EMISSOR TO C04-RAMO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR, FILLER01.LC04.C04_RAMO);

                /*" -778- MOVE RELATORI-COD-OPERACAO TO C04-COD-PRODUTO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO, FILLER01.LC04.C04_COD_PRODUTO);

                /*" -779- MOVE RELATORI-COD-SUBGRUPO TO C04-COD-SUBGRUPO */
                _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, FILLER01.LC04.C04_COD_SUBGRUPO);

                /*" -781- WRITE REG-ARQ-SAIDA FROM LC04. */
                _.Move(FILLER01.LC04.GetMoveValues(), REG_ARQ_SAIDA);

                ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());
            }


            /*" -782- IF WIND-PCS-RAMO EQUAL 'SIM' */

            if (WIND_PCS_RAMO == "SIM")
            {

                /*" -784- PERFORM R100-PROCESSA-RAMO THRU R100-EXIT UNTIL W-FIM-RAMO EQUAL 'SIM' */

                while (!(W_INICIO_WORK.W_FIM_RAMO == "SIM"))
                {

                    R100_PROCESSA_RAMO(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

                }

                /*" -785- ELSE */
            }
            else
            {


                /*" -786- IF WIND-PCS-PRODUTO EQUAL 'SIM' */

                if (WIND_PCS_PRODUTO == "SIM")
                {

                    /*" -788- PERFORM R200-PROCESSA-PRODUTO THRU R200-EXIT UNTIL W-FIM-PRODUTO EQUAL 'SIM' */

                    while (!(W_INICIO_WORK.W_FIM_PRODUTO == "SIM"))
                    {

                        R200_PROCESSA_PRODUTO(true);
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

                    }

                    /*" -789- ELSE */
                }
                else
                {


                    /*" -790- IF WIND-PCS-RAMOVG EQUAL 'SIM' */

                    if (WIND_PCS_RAMOVG == "SIM")
                    {

                        /*" -792- PERFORM R300-PROCESSA-RAMOVG THRU R300-EXIT UNTIL W-FIM-RAMOVG EQUAL 'SIM' */

                        while (!(W_INICIO_WORK.W_FIM_RAMOVG == "SIM"))
                        {

                            R300_PROCESSA_RAMOVG(true);
                            /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

                        }

                        /*" -793- ELSE */
                    }
                    else
                    {


                        /*" -794- IF WIND-PCS-APOLICE EQUAL 'SIM' */

                        if (WIND_PCS_APOLICE == "SIM")
                        {

                            /*" -797- PERFORM R400-PROCESSA-APOLICE THRU R400-EXIT UNTIL W-FIM-APOLICE EQUAL 'SIM' . */

                            while (!(W_INICIO_WORK.W_FIM_APOLICE == "SIM"))
                            {

                                R400_PROCESSA_APOLICE(true);
                                /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

                            }
                        }

                    }

                }

            }


            /*" -797- PERFORM R021-FETCH-RELATORIO THRU R021-EXIT. */

            R021_FETCH_RELATORIO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R021_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R030_EXIT*/

        [StopWatch]
        /*" R040-DECLARA-CURSORES */
        private void R040_DECLARA_CURSORES(bool isPerform = false)
        {
            /*" -805- IF WIND-PCS-RAMO EQUAL 'SIM' */

            if (WIND_PCS_RAMO == "SIM")
            {

                /*" -806- GO TO R041-DECLARE-RAMO */

                R041_DECLARE_RAMO(); //GOTO
                return;

                /*" -807- ELSE */
            }
            else
            {


                /*" -808- IF WIND-PCS-PRODUTO EQUAL 'SIM' */

                if (WIND_PCS_PRODUTO == "SIM")
                {

                    /*" -809- GO TO R042-DECLARE-PRODUTO */

                    R042_DECLARE_PRODUTO(); //GOTO
                    return;

                    /*" -810- ELSE */
                }
                else
                {


                    /*" -811- IF WIND-PCS-APOLICE EQUAL 'SIM' */

                    if (WIND_PCS_APOLICE == "SIM")
                    {

                        /*" -812- GO TO R043-DECLARE-APOLICE */

                        R043_DECLARE_APOLICE(); //GOTO
                        return;

                        /*" -813- ELSE */
                    }
                    else
                    {


                        /*" -814- IF WIND-PCS-RAMOVG EQUAL 'SIM' */

                        if (WIND_PCS_RAMOVG == "SIM")
                        {

                            /*" -814- GO TO R044-DECLARE-RAMOVG. */

                            R044_DECLARE_RAMOVG(); //GOTO
                            return;
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R041-DECLARE-RAMO */
        private void R041_DECLARE_RAMO(bool isPerform = false)
        {
            /*" -821- MOVE '006' TO WNR-EXEC-SQL. */
            _.Move("006", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -856- PERFORM R041_DECLARE_RAMO_DB_DECLARE_1 */

            R041_DECLARE_RAMO_DB_DECLARE_1();

            /*" -858- PERFORM R041_DECLARE_RAMO_DB_OPEN_1 */

            R041_DECLARE_RAMO_DB_OPEN_1();

            /*" -859- GO TO R040-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R041-DECLARE-RAMO-DB-OPEN-1 */
        public void R041_DECLARE_RAMO_DB_OPEN_1()
        {
            /*" -858- EXEC SQL OPEN RAMO END-EXEC. */

            RAMO.Open();

        }

        [StopWatch]
        /*" R042-DECLARE-PRODUTO-DB-DECLARE-1 */
        public void R042_DECLARE_PRODUTO_DB_DECLARE_1()
        {
            /*" -901- EXEC SQL DECLARE C01_PRODUTO CURSOR FOR SELECT M.RAMO, M.COD_PRODUTO, M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.TIPO_REGISTRO, M.COD_SUBGRUPO, M.NUM_CERTIFICADO, M.COD_CAUSA, M.DATA_COMUNICADO, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.TIPO_SEGURADO, E.COD_FONTE, P.DESCR_PRODUTO, M.COD_FONTE, SC.DESCR_CAUSA, H.COD_OPERACAO, H.VAL_OPERACAO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.PRODUTO P, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.ENDOSSOS E WHERE M.COD_PRODUTO = :RELATORI-COD-OPERACAO AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO BETWEEN :RELATORI-PERI-INICIAL AND :RELATORI-PERI-FINAL AND P.COD_PRODUTO = M.COD_PRODUTO AND SC.RAMO_EMISSOR = M.RAMO AND SC.COD_CAUSA = M.COD_CAUSA AND M.NUM_APOLICE = E.NUM_APOLICE AND E.NUM_ENDOSSO = 0 ORDER BY M.NUM_APOL_SINISTRO END-EXEC. */
            C01_PRODUTO = new SI0867B_C01_PRODUTO(true);
            string GetQuery_C01_PRODUTO()
            {
                var query = @$"SELECT M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.TIPO_REGISTRO
							, 
							M.COD_SUBGRUPO
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_CAUSA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_OCORRENCIA
							, 
							M.SIT_REGISTRO
							, 
							M.TIPO_SEGURADO
							, 
							E.COD_FONTE
							, 
							P.DESCR_PRODUTO
							, 
							M.COD_FONTE
							, 
							SC.DESCR_CAUSA
							, 
							H.COD_OPERACAO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.PRODUTO P
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.ENDOSSOS E 
							WHERE M.COD_PRODUTO = '{RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							AND P.COD_PRODUTO = M.COD_PRODUTO 
							AND SC.RAMO_EMISSOR = M.RAMO 
							AND SC.COD_CAUSA = M.COD_CAUSA 
							AND M.NUM_APOLICE = E.NUM_APOLICE 
							AND E.NUM_ENDOSSO = 0 
							ORDER BY M.NUM_APOL_SINISTRO";

                return query;
            }
            C01_PRODUTO.GetQueryEvent += GetQuery_C01_PRODUTO;

        }

        [StopWatch]
        /*" R042-DECLARE-PRODUTO */
        private void R042_DECLARE_PRODUTO(bool isPerform = false)
        {
            /*" -867- MOVE '007' TO WNR-EXEC-SQL. */
            _.Move("007", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -901- PERFORM R042_DECLARE_PRODUTO_DB_DECLARE_1 */

            R042_DECLARE_PRODUTO_DB_DECLARE_1();

            /*" -903- PERFORM R042_DECLARE_PRODUTO_DB_OPEN_1 */

            R042_DECLARE_PRODUTO_DB_OPEN_1();

            /*" -904- GO TO R040-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R042-DECLARE-PRODUTO-DB-OPEN-1 */
        public void R042_DECLARE_PRODUTO_DB_OPEN_1()
        {
            /*" -903- EXEC SQL OPEN C01_PRODUTO END-EXEC. */

            C01_PRODUTO.Open();

        }

        [StopWatch]
        /*" R043-DECLARE-APOLICE-DB-DECLARE-1 */
        public void R043_DECLARE_APOLICE_DB_DECLARE_1()
        {
            /*" -948- EXEC SQL DECLARE APOLICE CURSOR FOR SELECT M.RAMO, M.COD_PRODUTO, M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.TIPO_REGISTRO, M.COD_SUBGRUPO, M.NUM_CERTIFICADO, M.COD_CAUSA, M.DATA_COMUNICADO, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.TIPO_SEGURADO, E.COD_FONTE, P.DESCR_PRODUTO, M.COD_FONTE, SC.DESCR_CAUSA, H.COD_OPERACAO, H.VAL_OPERACAO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.PRODUTO P, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.ENDOSSOS E WHERE M.NUM_APOLICE = :RELATORI-NUM-APOLICE AND M.COD_SUBGRUPO BETWEEN :HOST-SG1 AND :HOST-SG2 AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO BETWEEN :RELATORI-PERI-INICIAL AND :RELATORI-PERI-FINAL AND P.COD_PRODUTO = M.COD_PRODUTO AND SC.RAMO_EMISSOR = M.RAMO AND SC.COD_CAUSA = M.COD_CAUSA AND M.NUM_APOLICE = E.NUM_APOLICE AND E.NUM_ENDOSSO = 0 ORDER BY M.NUM_APOL_SINISTRO END-EXEC. */
            APOLICE = new SI0867B_APOLICE(true);
            string GetQuery_APOLICE()
            {
                var query = @$"SELECT M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.TIPO_REGISTRO
							, 
							M.COD_SUBGRUPO
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_CAUSA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_OCORRENCIA
							, 
							M.SIT_REGISTRO
							, 
							M.TIPO_SEGURADO
							, 
							E.COD_FONTE
							, 
							P.DESCR_PRODUTO
							, 
							M.COD_FONTE
							, 
							SC.DESCR_CAUSA
							, 
							H.COD_OPERACAO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.PRODUTO P
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.ENDOSSOS E 
							WHERE M.NUM_APOLICE = '{RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}' 
							AND M.COD_SUBGRUPO BETWEEN '{HOST_SG1}' 
							AND '{HOST_SG2}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							AND P.COD_PRODUTO = M.COD_PRODUTO 
							AND SC.RAMO_EMISSOR = M.RAMO 
							AND SC.COD_CAUSA = M.COD_CAUSA 
							AND M.NUM_APOLICE = E.NUM_APOLICE 
							AND E.NUM_ENDOSSO = 0 
							ORDER BY M.NUM_APOL_SINISTRO";

                return query;
            }
            APOLICE.GetQueryEvent += GetQuery_APOLICE;

        }

        [StopWatch]
        /*" R043-DECLARE-APOLICE */
        private void R043_DECLARE_APOLICE(bool isPerform = false)
        {
            /*" -912- MOVE '008' TO WNR-EXEC-SQL. */
            _.Move("008", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -948- PERFORM R043_DECLARE_APOLICE_DB_DECLARE_1 */

            R043_DECLARE_APOLICE_DB_DECLARE_1();

            /*" -950- PERFORM R043_DECLARE_APOLICE_DB_OPEN_1 */

            R043_DECLARE_APOLICE_DB_OPEN_1();

            /*" -951- GO TO R040-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R043-DECLARE-APOLICE-DB-OPEN-1 */
        public void R043_DECLARE_APOLICE_DB_OPEN_1()
        {
            /*" -950- EXEC SQL OPEN APOLICE END-EXEC. */

            APOLICE.Open();

        }

        [StopWatch]
        /*" R044-DECLARE-RAMOVG-DB-DECLARE-1 */
        public void R044_DECLARE_RAMOVG_DB_DECLARE_1()
        {
            /*" -994- EXEC SQL DECLARE RAMOVG CURSOR FOR SELECT M.RAMO, M.COD_PRODUTO, M.NUM_APOLICE, M.NUM_APOL_SINISTRO, M.TIPO_REGISTRO, M.COD_SUBGRUPO, M.NUM_CERTIFICADO, M.COD_CAUSA, M.DATA_COMUNICADO, M.DATA_OCORRENCIA, M.SIT_REGISTRO, M.TIPO_SEGURADO, E.COD_FONTE, P.DESCR_PRODUTO, M.COD_FONTE, SC.DESCR_CAUSA, H.COD_OPERACAO, H.VAL_OPERACAO FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.PRODUTO P, SEGUROS.SINISTRO_CAUSA SC, SEGUROS.ENDOSSOS E WHERE M.NUM_APOL_SINISTRO BETWEEN :HOST-APOL-INICIO AND :HOST-APOL-FIM AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO BETWEEN :RELATORI-PERI-INICIAL AND :RELATORI-PERI-FINAL AND P.COD_PRODUTO = M.COD_PRODUTO AND SC.RAMO_EMISSOR = M.RAMO AND SC.COD_CAUSA = M.COD_CAUSA AND M.NUM_APOLICE = E.NUM_APOLICE AND E.NUM_ENDOSSO = 0 ORDER BY M.NUM_APOL_SINISTRO END-EXEC. */
            RAMOVG = new SI0867B_RAMOVG(true);
            string GetQuery_RAMOVG()
            {
                var query = @$"SELECT M.RAMO
							, 
							M.COD_PRODUTO
							, 
							M.NUM_APOLICE
							, 
							M.NUM_APOL_SINISTRO
							, 
							M.TIPO_REGISTRO
							, 
							M.COD_SUBGRUPO
							, 
							M.NUM_CERTIFICADO
							, 
							M.COD_CAUSA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_OCORRENCIA
							, 
							M.SIT_REGISTRO
							, 
							M.TIPO_SEGURADO
							, 
							E.COD_FONTE
							, 
							P.DESCR_PRODUTO
							, 
							M.COD_FONTE
							, 
							SC.DESCR_CAUSA
							, 
							H.COD_OPERACAO
							, 
							H.VAL_OPERACAO 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.PRODUTO P
							, 
							SEGUROS.SINISTRO_CAUSA SC
							, 
							SEGUROS.ENDOSSOS E 
							WHERE M.NUM_APOL_SINISTRO BETWEEN '{HOST_APOL_INICIO}' 
							AND '{HOST_APOL_FIM}' 
							AND H.NUM_APOL_SINISTRO = M.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL}' 
							AND '{RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}' 
							AND P.COD_PRODUTO = M.COD_PRODUTO 
							AND SC.RAMO_EMISSOR = M.RAMO 
							AND SC.COD_CAUSA = M.COD_CAUSA 
							AND M.NUM_APOLICE = E.NUM_APOLICE 
							AND E.NUM_ENDOSSO = 0 
							ORDER BY M.NUM_APOL_SINISTRO";

                return query;
            }
            RAMOVG.GetQueryEvent += GetQuery_RAMOVG;

        }

        [StopWatch]
        /*" R044-DECLARE-RAMOVG */
        private void R044_DECLARE_RAMOVG(bool isPerform = false)
        {
            /*" -959- MOVE '009' TO WNR-EXEC-SQL. */
            _.Move("009", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -994- PERFORM R044_DECLARE_RAMOVG_DB_DECLARE_1 */

            R044_DECLARE_RAMOVG_DB_DECLARE_1();

            /*" -996- PERFORM R044_DECLARE_RAMOVG_DB_OPEN_1 */

            R044_DECLARE_RAMOVG_DB_OPEN_1();

        }

        [StopWatch]
        /*" R044-DECLARE-RAMOVG-DB-OPEN-1 */
        public void R044_DECLARE_RAMOVG_DB_OPEN_1()
        {
            /*" -996- EXEC SQL OPEN RAMOVG END-EXEC. */

            RAMOVG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R040_EXIT*/

        [StopWatch]
        /*" R050-FETCH-CURSORES */
        private void R050_FETCH_CURSORES(bool isPerform = false)
        {
            /*" -1004- IF WIND-PCS-RAMO EQUAL 'SIM' */

            if (WIND_PCS_RAMO == "SIM")
            {

                /*" -1005- GO TO R051-FETCH-RAMO */

                R051_FETCH_RAMO(); //GOTO
                return;

                /*" -1006- ELSE */
            }
            else
            {


                /*" -1007- IF WIND-PCS-PRODUTO EQUAL 'SIM' */

                if (WIND_PCS_PRODUTO == "SIM")
                {

                    /*" -1008- GO TO R052-FETCH-PRODUTO */

                    R052_FETCH_PRODUTO(); //GOTO
                    return;

                    /*" -1009- ELSE */
                }
                else
                {


                    /*" -1010- IF WIND-PCS-APOLICE EQUAL 'SIM' */

                    if (WIND_PCS_APOLICE == "SIM")
                    {

                        /*" -1011- GO TO R053-FETCH-APOLICE */

                        R053_FETCH_APOLICE(); //GOTO
                        return;

                        /*" -1012- ELSE */
                    }
                    else
                    {


                        /*" -1013- IF WIND-PCS-RAMOVG EQUAL 'SIM' */

                        if (WIND_PCS_RAMOVG == "SIM")
                        {

                            /*" -1013- GO TO R054-FETCH-RAMOVG. */

                            R054_FETCH_RAMOVG(); //GOTO
                            return;
                        }

                    }

                }

            }


        }

        [StopWatch]
        /*" R051-FETCH-RAMO */
        private void R051_FETCH_RAMO(bool isPerform = false)
        {
            /*" -1021- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1040- PERFORM R051_FETCH_RAMO_DB_FETCH_1 */

            R051_FETCH_RAMO_DB_FETCH_1();

            /*" -1043- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1044- MOVE 'SIM' TO W-FIM-RAMO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RAMO);

                /*" -1044- PERFORM R051_FETCH_RAMO_DB_CLOSE_1 */

                R051_FETCH_RAMO_DB_CLOSE_1();

                /*" -1046- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1047- DISPLAY 'ERRO DE CLOSE DO CURSOR RAMO' */
                    _.Display($"ERRO DE CLOSE DO CURSOR RAMO");

                    /*" -1049- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1050- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1051- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1052- DISPLAY 'ERRO LEITURA CURSOR POR RAMO.......' */
                _.Display($"ERRO LEITURA CURSOR POR RAMO.......");

                /*" -1053- DISPLAY 'COD. FONTE  : ' SINISMES-COD-FONTE */
                _.Display($"COD. FONTE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -1054- DISPLAY 'RAMO        : ' RELATORI-RAMO-EMISSOR */
                _.Display($"RAMO        : {RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR}");

                /*" -1055- DISPLAY 'COD. PRODUTO: ' SINISMES-COD-PRODUTO */
                _.Display($"COD. PRODUTO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -1056- DISPLAY 'NUM APOLICE : ' SINISMES-NUM-APOLICE */
                _.Display($"NUM APOLICE : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1057- DISPLAY 'COD.SUBGRUPO: ' SINISMES-COD-SUBGRUPO */
                _.Display($"COD.SUBGRUPO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                /*" -1058- DISPLAY 'COD.FONTE   : ' ENDOSSOS-COD-FONTE */
                _.Display($"COD.FONTE   : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1059- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1061- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1061- GO TO R050-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R051-FETCH-RAMO-DB-FETCH-1 */
        public void R051_FETCH_RAMO_DB_FETCH_1()
        {
            /*" -1040- EXEC SQL FETCH RAMO INTO :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-TIPO-REGISTRO, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISMES-COD-CAUSA, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-OCORRENCIA, :SINISMES-SIT-REGISTRO, :SINISMES-TIPO-SEGURADO, :ENDOSSOS-COD-FONTE, :PRODUTO-DESCR-PRODUTO, :SINISMES-COD-FONTE, :SINISCAU-DESCR-CAUSA, :SINISHIS-COD-OPERACAO, :SINISHIS-VAL-OPERACAO END-EXEC. */

            if (RAMO.Fetch())
            {
                _.Move(RAMO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(RAMO.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(RAMO.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(RAMO.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(RAMO.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(RAMO.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(RAMO.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(RAMO.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(RAMO.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(RAMO.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(RAMO.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(RAMO.SINISMES_TIPO_SEGURADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO);
                _.Move(RAMO.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(RAMO.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(RAMO.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(RAMO.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(RAMO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(RAMO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R051-FETCH-RAMO-DB-CLOSE-1 */
        public void R051_FETCH_RAMO_DB_CLOSE_1()
        {
            /*" -1044- EXEC SQL CLOSE RAMO END-EXEC */

            RAMO.Close();

        }

        [StopWatch]
        /*" R052-FETCH-PRODUTO */
        private void R052_FETCH_PRODUTO(bool isPerform = false)
        {
            /*" -1069- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1088- PERFORM R052_FETCH_PRODUTO_DB_FETCH_1 */

            R052_FETCH_PRODUTO_DB_FETCH_1();

            /*" -1091- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1092- MOVE 'SIM' TO W-FIM-PRODUTO */
                _.Move("SIM", W_INICIO_WORK.W_FIM_PRODUTO);

                /*" -1092- PERFORM R052_FETCH_PRODUTO_DB_CLOSE_1 */

                R052_FETCH_PRODUTO_DB_CLOSE_1();

                /*" -1094- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1095- DISPLAY 'ERRO DE CLOSE DO CURSOR POR PRODUTO' */
                    _.Display($"ERRO DE CLOSE DO CURSOR POR PRODUTO");

                    /*" -1097- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1098- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1099- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1100- DISPLAY 'ERRO LEITURA CURSOR POR PRODUTO.......' */
                _.Display($"ERRO LEITURA CURSOR POR PRODUTO.......");

                /*" -1101- DISPLAY 'NUM APOLICE : ' RELATORI-NUM-APOLICE */
                _.Display($"NUM APOLICE : {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -1102- DISPLAY 'COD. FONTE  : ' SINISMES-COD-FONTE */
                _.Display($"COD. FONTE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -1103- DISPLAY 'RAMO        : ' SINISMES-RAMO */
                _.Display($"RAMO        : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1104- DISPLAY 'COD. PRODUTO: ' RELATORI-COD-OPERACAO */
                _.Display($"COD. PRODUTO: {RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO}");

                /*" -1105- DISPLAY 'NUM APOLICE : ' SINISMES-NUM-APOLICE */
                _.Display($"NUM APOLICE : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1106- DISPLAY 'COD.SUBGRUPO: ' SINISMES-COD-SUBGRUPO */
                _.Display($"COD.SUBGRUPO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                /*" -1107- DISPLAY 'COD.FONTE   : ' ENDOSSOS-COD-FONTE */
                _.Display($"COD.FONTE   : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1108- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1110- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1110- GO TO R050-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R052-FETCH-PRODUTO-DB-FETCH-1 */
        public void R052_FETCH_PRODUTO_DB_FETCH_1()
        {
            /*" -1088- EXEC SQL FETCH C01_PRODUTO INTO :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-TIPO-REGISTRO, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISMES-COD-CAUSA, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-OCORRENCIA, :SINISMES-SIT-REGISTRO, :SINISMES-TIPO-SEGURADO, :ENDOSSOS-COD-FONTE, :PRODUTO-DESCR-PRODUTO, :SINISMES-COD-FONTE, :SINISCAU-DESCR-CAUSA, :SINISHIS-COD-OPERACAO, :SINISHIS-VAL-OPERACAO END-EXEC. */

            if (C01_PRODUTO.Fetch())
            {
                _.Move(C01_PRODUTO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(C01_PRODUTO.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(C01_PRODUTO.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(C01_PRODUTO.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(C01_PRODUTO.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(C01_PRODUTO.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(C01_PRODUTO.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(C01_PRODUTO.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(C01_PRODUTO.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(C01_PRODUTO.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(C01_PRODUTO.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(C01_PRODUTO.SINISMES_TIPO_SEGURADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO);
                _.Move(C01_PRODUTO.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(C01_PRODUTO.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(C01_PRODUTO.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(C01_PRODUTO.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(C01_PRODUTO.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(C01_PRODUTO.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R052-FETCH-PRODUTO-DB-CLOSE-1 */
        public void R052_FETCH_PRODUTO_DB_CLOSE_1()
        {
            /*" -1092- EXEC SQL CLOSE C01_PRODUTO END-EXEC */

            C01_PRODUTO.Close();

        }

        [StopWatch]
        /*" R053-FETCH-APOLICE */
        private void R053_FETCH_APOLICE(bool isPerform = false)
        {
            /*" -1118- MOVE '012' TO WNR-EXEC-SQL. */
            _.Move("012", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1137- PERFORM R053_FETCH_APOLICE_DB_FETCH_1 */

            R053_FETCH_APOLICE_DB_FETCH_1();

            /*" -1140- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1141- MOVE 'SIM' TO W-FIM-APOLICE */
                _.Move("SIM", W_INICIO_WORK.W_FIM_APOLICE);

                /*" -1141- PERFORM R053_FETCH_APOLICE_DB_CLOSE_1 */

                R053_FETCH_APOLICE_DB_CLOSE_1();

                /*" -1143- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1144- DISPLAY 'ERRO DE CLOSE DO CURSOR POR APOLICE' */
                    _.Display($"ERRO DE CLOSE DO CURSOR POR APOLICE");

                    /*" -1146- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1147- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1148- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1149- DISPLAY 'ERRO LEITURA CURSOR POR APOLICE.....' */
                _.Display($"ERRO LEITURA CURSOR POR APOLICE.....");

                /*" -1150- DISPLAY 'NUM APOLICE : ' RELATORI-NUM-APOLICE */
                _.Display($"NUM APOLICE : {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -1151- DISPLAY 'SUB GRUPO   : ' RELATORI-COD-SUBGRUPO */
                _.Display($"SUB GRUPO   : {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}");

                /*" -1152- DISPLAY 'COD. FONTE  : ' SINISMES-COD-FONTE */
                _.Display($"COD. FONTE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -1153- DISPLAY 'RAMO        : ' SINISMES-RAMO */
                _.Display($"RAMO        : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1154- DISPLAY 'COD. PRODUTO: ' SINISMES-COD-PRODUTO */
                _.Display($"COD. PRODUTO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -1155- DISPLAY 'NUM APOLICE : ' SINISMES-NUM-APOLICE */
                _.Display($"NUM APOLICE : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1156- DISPLAY 'COD.SUBGRUPO: ' SINISMES-COD-SUBGRUPO */
                _.Display($"COD.SUBGRUPO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                /*" -1157- DISPLAY 'COD.FONTE   : ' ENDOSSOS-COD-FONTE */
                _.Display($"COD.FONTE   : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1158- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1160- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -1160- GO TO R050-EXIT. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/ //GOTO
            return;

        }

        [StopWatch]
        /*" R053-FETCH-APOLICE-DB-FETCH-1 */
        public void R053_FETCH_APOLICE_DB_FETCH_1()
        {
            /*" -1137- EXEC SQL FETCH APOLICE INTO :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-TIPO-REGISTRO, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISMES-COD-CAUSA, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-OCORRENCIA, :SINISMES-SIT-REGISTRO, :SINISMES-TIPO-SEGURADO, :ENDOSSOS-COD-FONTE, :PRODUTO-DESCR-PRODUTO, :SINISMES-COD-FONTE, :SINISCAU-DESCR-CAUSA, :SINISHIS-COD-OPERACAO, :SINISHIS-VAL-OPERACAO END-EXEC. */

            if (APOLICE.Fetch())
            {
                _.Move(APOLICE.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(APOLICE.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(APOLICE.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(APOLICE.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(APOLICE.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(APOLICE.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(APOLICE.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(APOLICE.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(APOLICE.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(APOLICE.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(APOLICE.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(APOLICE.SINISMES_TIPO_SEGURADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO);
                _.Move(APOLICE.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(APOLICE.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(APOLICE.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(APOLICE.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(APOLICE.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(APOLICE.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R053-FETCH-APOLICE-DB-CLOSE-1 */
        public void R053_FETCH_APOLICE_DB_CLOSE_1()
        {
            /*" -1141- EXEC SQL CLOSE APOLICE END-EXEC */

            APOLICE.Close();

        }

        [StopWatch]
        /*" R054-FETCH-RAMOVG */
        private void R054_FETCH_RAMOVG(bool isPerform = false)
        {
            /*" -1168- MOVE '013' TO WNR-EXEC-SQL. */
            _.Move("013", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1187- PERFORM R054_FETCH_RAMOVG_DB_FETCH_1 */

            R054_FETCH_RAMOVG_DB_FETCH_1();

            /*" -1190- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1191- MOVE 'SIM' TO W-FIM-RAMOVG */
                _.Move("SIM", W_INICIO_WORK.W_FIM_RAMOVG);

                /*" -1191- PERFORM R054_FETCH_RAMOVG_DB_CLOSE_1 */

                R054_FETCH_RAMOVG_DB_CLOSE_1();

                /*" -1193- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1194- DISPLAY 'ERRO DE CLOSE DO CURSOR PARA VIDA' */
                    _.Display($"ERRO DE CLOSE DO CURSOR PARA VIDA");

                    /*" -1196- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


            /*" -1197- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -1198- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1199- DISPLAY 'ERRO LEITURA CURSOR PARA VIDA.....' */
                _.Display($"ERRO LEITURA CURSOR PARA VIDA.....");

                /*" -1200- DISPLAY 'NUM APOLICE : ' RELATORI-NUM-APOLICE */
                _.Display($"NUM APOLICE : {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE}");

                /*" -1201- DISPLAY 'SUB GRUPO   : ' RELATORI-COD-SUBGRUPO */
                _.Display($"SUB GRUPO   : {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO}");

                /*" -1202- DISPLAY 'COD. FONTE  : ' SINISMES-COD-FONTE */
                _.Display($"COD. FONTE  : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -1203- DISPLAY 'RAMO        : ' SINISMES-RAMO */
                _.Display($"RAMO        : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1204- DISPLAY 'COD. PRODUTO: ' SINISMES-COD-PRODUTO */
                _.Display($"COD. PRODUTO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -1205- DISPLAY 'NUM APOLICE : ' SINISMES-NUM-APOLICE */
                _.Display($"NUM APOLICE : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -1206- DISPLAY 'COD.SUBGRUPO: ' SINISMES-COD-SUBGRUPO */
                _.Display($"COD.SUBGRUPO: {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO}");

                /*" -1207- DISPLAY 'COD.FONTE   : ' ENDOSSOS-COD-FONTE */
                _.Display($"COD.FONTE   : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1208- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1208- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R054-FETCH-RAMOVG-DB-FETCH-1 */
        public void R054_FETCH_RAMOVG_DB_FETCH_1()
        {
            /*" -1187- EXEC SQL FETCH RAMOVG INTO :SINISMES-RAMO, :SINISMES-COD-PRODUTO, :SINISMES-NUM-APOLICE, :SINISMES-NUM-APOL-SINISTRO, :SINISMES-TIPO-REGISTRO, :SINISMES-COD-SUBGRUPO, :SINISMES-NUM-CERTIFICADO, :SINISMES-COD-CAUSA, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-OCORRENCIA, :SINISMES-SIT-REGISTRO, :SINISMES-TIPO-SEGURADO, :ENDOSSOS-COD-FONTE, :PRODUTO-DESCR-PRODUTO, :SINISMES-COD-FONTE, :SINISCAU-DESCR-CAUSA, :SINISHIS-COD-OPERACAO, :SINISHIS-VAL-OPERACAO END-EXEC. */

            if (RAMOVG.Fetch())
            {
                _.Move(RAMOVG.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(RAMOVG.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
                _.Move(RAMOVG.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(RAMOVG.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(RAMOVG.SINISMES_TIPO_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO);
                _.Move(RAMOVG.SINISMES_COD_SUBGRUPO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO);
                _.Move(RAMOVG.SINISMES_NUM_CERTIFICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO);
                _.Move(RAMOVG.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(RAMOVG.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(RAMOVG.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(RAMOVG.SINISMES_SIT_REGISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO);
                _.Move(RAMOVG.SINISMES_TIPO_SEGURADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO);
                _.Move(RAMOVG.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(RAMOVG.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(RAMOVG.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(RAMOVG.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(RAMOVG.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(RAMOVG.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }

        }

        [StopWatch]
        /*" R054-FETCH-RAMOVG-DB-CLOSE-1 */
        public void R054_FETCH_RAMOVG_DB_CLOSE_1()
        {
            /*" -1191- EXEC SQL CLOSE RAMOVG END-EXEC */

            RAMOVG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/

        [StopWatch]
        /*" R100-PROCESSA-RAMO */
        private void R100_PROCESSA_RAMO(bool isPerform = false)
        {
            /*" -1216- MOVE SINISMES-RAMO TO W-GDA-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, W_GDA_RAMO);

            /*" -1217- MOVE SINISMES-COD-PRODUTO TO W-GDA-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, W_GDA_COD_PRODUTO);

            /*" -1218- MOVE SINISMES-NUM-APOLICE TO W-GDA-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, W_GDA_APOLICE);

            /*" -1219- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1220- MOVE SINISMES-TIPO-REGISTRO TO W-GDA-TIPO-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO, W_GDA_TIPO_REGISTRO);

            /*" -1221- MOVE SINISMES-COD-SUBGRUPO TO W-GDA-SUBGRUPO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO, W_GDA_SUBGRUPO);

            /*" -1222- MOVE SINISMES-NUM-CERTIFICADO TO W-GDA-NUM-CERTIFICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, W_GDA_NUM_CERTIFICADO);

            /*" -1223- MOVE SINISMES-COD-CAUSA TO W-GDA-COD-CAUSA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, W_GDA_COD_CAUSA);

            /*" -1224- MOVE SINISMES-DATA-COMUNICADO TO W-GDA-DATA-COMUNICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, W_GDA_DATA_COMUNICADO);

            /*" -1225- MOVE SINISMES-DATA-OCORRENCIA TO W-GDA-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, W_GDA_DATA_OCORRENCIA);

            /*" -1226- MOVE SINISMES-SIT-REGISTRO TO W-GDA-SIT-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO, W_GDA_SIT_REGISTRO);

            /*" -1227- MOVE SINISMES-TIPO-SEGURADO TO W-GDA-TIPO-SEGURADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO, W_GDA_TIPO_SEGURADO);

            /*" -1228- MOVE ENDOSSOS-COD-FONTE TO W-GDA-FONTE-EMIS. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, W_GDA_FONTE_EMIS);

            /*" -1229- MOVE SINISMES-COD-FONTE TO W-GDA-FONTE-SINI. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_GDA_FONTE_SINI);

            /*" -1230- MOVE PRODUTO-DESCR-PRODUTO TO W-GDA-DESCR-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, W_GDA_DESCR_PRODUTO);

            /*" -1232- MOVE SINISCAU-DESCR-CAUSA TO W-GDA-DESCR-CAUSA. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W_GDA_DESCR_CAUSA);

            /*" -1236- PERFORM R500-TRATA-QUEBRA-SINISTRO THRU R500-EXIT UNTIL W-FIM-RAMO EQUAL 'SIM' OR SINISMES-NUM-APOL-SINISTRO NOT EQUAL W-GDA-SINISTRO. */

            while (!(W_INICIO_WORK.W_FIM_RAMO == "SIM" || SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO != W_GDA_SINISTRO))
            {

                R500_TRATA_QUEBRA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

            }

            /*" -1238- PERFORM R700-GRAVA-ARQ-SAIDA THRU R700-EXIT. */

            R700_GRAVA_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/


            /*" -1238- INITIALIZE WCONTADORES WACUMULADORES. */
            _.Initialize(
                W_INICIO_WORK.WCONTADORES
                , W_INICIO_WORK.WACUMULADORES
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100_EXIT*/

        [StopWatch]
        /*" R200-PROCESSA-PRODUTO */
        private void R200_PROCESSA_PRODUTO(bool isPerform = false)
        {
            /*" -1246- MOVE SINISMES-RAMO TO W-GDA-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, W_GDA_RAMO);

            /*" -1247- MOVE SINISMES-COD-PRODUTO TO W-GDA-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, W_GDA_COD_PRODUTO);

            /*" -1248- MOVE SINISMES-NUM-APOLICE TO W-GDA-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, W_GDA_APOLICE);

            /*" -1249- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1250- MOVE SINISMES-TIPO-REGISTRO TO W-GDA-TIPO-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO, W_GDA_TIPO_REGISTRO);

            /*" -1251- MOVE SINISMES-COD-SUBGRUPO TO W-GDA-SUBGRUPO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO, W_GDA_SUBGRUPO);

            /*" -1252- MOVE SINISMES-NUM-CERTIFICADO TO W-GDA-NUM-CERTIFICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, W_GDA_NUM_CERTIFICADO);

            /*" -1253- MOVE SINISMES-COD-CAUSA TO W-GDA-COD-CAUSA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, W_GDA_COD_CAUSA);

            /*" -1254- MOVE SINISMES-DATA-COMUNICADO TO W-GDA-DATA-COMUNICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, W_GDA_DATA_COMUNICADO);

            /*" -1255- MOVE SINISMES-DATA-OCORRENCIA TO W-GDA-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, W_GDA_DATA_OCORRENCIA);

            /*" -1256- MOVE SINISMES-SIT-REGISTRO TO W-GDA-SIT-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO, W_GDA_SIT_REGISTRO);

            /*" -1257- MOVE SINISMES-TIPO-SEGURADO TO W-GDA-TIPO-SEGURADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO, W_GDA_TIPO_SEGURADO);

            /*" -1258- MOVE ENDOSSOS-COD-FONTE TO W-GDA-FONTE-EMIS. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, W_GDA_FONTE_EMIS);

            /*" -1259- MOVE SINISMES-COD-FONTE TO W-GDA-FONTE-SINI. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_GDA_FONTE_SINI);

            /*" -1260- MOVE PRODUTO-DESCR-PRODUTO TO W-GDA-DESCR-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, W_GDA_DESCR_PRODUTO);

            /*" -1262- MOVE SINISCAU-DESCR-CAUSA TO W-GDA-DESCR-CAUSA. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W_GDA_DESCR_CAUSA);

            /*" -1263- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1267- PERFORM R500-TRATA-QUEBRA-SINISTRO THRU R500-EXIT UNTIL W-FIM-PRODUTO EQUAL 'SIM' OR SINISMES-NUM-APOL-SINISTRO NOT EQUAL W-GDA-SINISTRO. */

            while (!(W_INICIO_WORK.W_FIM_PRODUTO == "SIM" || SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO != W_GDA_SINISTRO))
            {

                R500_TRATA_QUEBRA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

            }

            /*" -1269- PERFORM R700-GRAVA-ARQ-SAIDA THRU R700-EXIT. */

            R700_GRAVA_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/


            /*" -1269- INITIALIZE WCONTADORES WACUMULADORES. */
            _.Initialize(
                W_INICIO_WORK.WCONTADORES
                , W_INICIO_WORK.WACUMULADORES
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R200_EXIT*/

        [StopWatch]
        /*" R300-PROCESSA-RAMOVG */
        private void R300_PROCESSA_RAMOVG(bool isPerform = false)
        {
            /*" -1277- MOVE SINISMES-RAMO TO W-GDA-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, W_GDA_RAMO);

            /*" -1278- MOVE SINISMES-COD-PRODUTO TO W-GDA-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, W_GDA_COD_PRODUTO);

            /*" -1279- MOVE SINISMES-NUM-APOLICE TO W-GDA-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, W_GDA_APOLICE);

            /*" -1280- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1281- MOVE SINISMES-TIPO-REGISTRO TO W-GDA-TIPO-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO, W_GDA_TIPO_REGISTRO);

            /*" -1282- MOVE SINISMES-COD-SUBGRUPO TO W-GDA-SUBGRUPO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO, W_GDA_SUBGRUPO);

            /*" -1283- MOVE SINISMES-NUM-CERTIFICADO TO W-GDA-NUM-CERTIFICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, W_GDA_NUM_CERTIFICADO);

            /*" -1284- MOVE SINISMES-COD-CAUSA TO W-GDA-COD-CAUSA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, W_GDA_COD_CAUSA);

            /*" -1285- MOVE SINISMES-DATA-COMUNICADO TO W-GDA-DATA-COMUNICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, W_GDA_DATA_COMUNICADO);

            /*" -1286- MOVE SINISMES-DATA-OCORRENCIA TO W-GDA-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, W_GDA_DATA_OCORRENCIA);

            /*" -1287- MOVE SINISMES-SIT-REGISTRO TO W-GDA-SIT-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO, W_GDA_SIT_REGISTRO);

            /*" -1288- MOVE SINISMES-TIPO-SEGURADO TO W-GDA-TIPO-SEGURADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO, W_GDA_TIPO_SEGURADO);

            /*" -1289- MOVE ENDOSSOS-COD-FONTE TO W-GDA-FONTE-EMIS. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, W_GDA_FONTE_EMIS);

            /*" -1290- MOVE SINISMES-COD-FONTE TO W-GDA-FONTE-SINI. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_GDA_FONTE_SINI);

            /*" -1291- MOVE PRODUTO-DESCR-PRODUTO TO W-GDA-DESCR-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, W_GDA_DESCR_PRODUTO);

            /*" -1293- MOVE SINISCAU-DESCR-CAUSA TO W-GDA-DESCR-CAUSA. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W_GDA_DESCR_CAUSA);

            /*" -1294- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1298- PERFORM R500-TRATA-QUEBRA-SINISTRO THRU R500-EXIT UNTIL W-FIM-RAMOVG EQUAL 'SIM' OR SINISMES-NUM-APOL-SINISTRO NOT EQUAL W-GDA-SINISTRO. */

            while (!(W_INICIO_WORK.W_FIM_RAMOVG == "SIM" || SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO != W_GDA_SINISTRO))
            {

                R500_TRATA_QUEBRA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

            }

            /*" -1300- PERFORM R700-GRAVA-ARQ-SAIDA THRU R700-EXIT. */

            R700_GRAVA_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/


            /*" -1300- INITIALIZE WCONTADORES WACUMULADORES. */
            _.Initialize(
                W_INICIO_WORK.WCONTADORES
                , W_INICIO_WORK.WACUMULADORES
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R300_EXIT*/

        [StopWatch]
        /*" R400-PROCESSA-APOLICE */
        private void R400_PROCESSA_APOLICE(bool isPerform = false)
        {
            /*" -1308- MOVE SINISMES-RAMO TO W-GDA-RAMO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, W_GDA_RAMO);

            /*" -1309- MOVE SINISMES-COD-PRODUTO TO W-GDA-COD-PRODUTO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO, W_GDA_COD_PRODUTO);

            /*" -1310- MOVE SINISMES-NUM-APOLICE TO W-GDA-APOLICE. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, W_GDA_APOLICE);

            /*" -1311- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1312- MOVE SINISMES-TIPO-REGISTRO TO W-GDA-TIPO-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_REGISTRO, W_GDA_TIPO_REGISTRO);

            /*" -1313- MOVE SINISMES-COD-SUBGRUPO TO W-GDA-SUBGRUPO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_SUBGRUPO, W_GDA_SUBGRUPO);

            /*" -1314- MOVE SINISMES-NUM-CERTIFICADO TO W-GDA-NUM-CERTIFICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_CERTIFICADO, W_GDA_NUM_CERTIFICADO);

            /*" -1315- MOVE SINISMES-COD-CAUSA TO W-GDA-COD-CAUSA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, W_GDA_COD_CAUSA);

            /*" -1316- MOVE SINISMES-DATA-COMUNICADO TO W-GDA-DATA-COMUNICADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, W_GDA_DATA_COMUNICADO);

            /*" -1317- MOVE SINISMES-DATA-OCORRENCIA TO W-GDA-DATA-OCORRENCIA. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, W_GDA_DATA_OCORRENCIA);

            /*" -1318- MOVE SINISMES-SIT-REGISTRO TO W-GDA-SIT-REGISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_SIT_REGISTRO, W_GDA_SIT_REGISTRO);

            /*" -1319- MOVE SINISMES-TIPO-SEGURADO TO W-GDA-TIPO-SEGURADO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_TIPO_SEGURADO, W_GDA_TIPO_SEGURADO);

            /*" -1320- MOVE ENDOSSOS-COD-FONTE TO W-GDA-FONTE-EMIS. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, W_GDA_FONTE_EMIS);

            /*" -1321- MOVE SINISMES-COD-FONTE TO W-GDA-FONTE-SINI. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, W_GDA_FONTE_SINI);

            /*" -1322- MOVE PRODUTO-DESCR-PRODUTO TO W-GDA-DESCR-PRODUTO. */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, W_GDA_DESCR_PRODUTO);

            /*" -1324- MOVE SINISCAU-DESCR-CAUSA TO W-GDA-DESCR-CAUSA. */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, W_GDA_DESCR_CAUSA);

            /*" -1325- MOVE SINISMES-NUM-APOL-SINISTRO TO W-GDA-SINISTRO. */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, W_GDA_SINISTRO);

            /*" -1329- PERFORM R500-TRATA-QUEBRA-SINISTRO THRU R500-EXIT UNTIL W-FIM-APOLICE EQUAL 'SIM' OR SINISMES-NUM-APOL-SINISTRO NOT EQUAL W-GDA-SINISTRO. */

            while (!(W_INICIO_WORK.W_FIM_APOLICE == "SIM" || SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO != W_GDA_SINISTRO))
            {

                R500_TRATA_QUEBRA_SINISTRO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

            }

            /*" -1331- PERFORM R700-GRAVA-ARQ-SAIDA THRU R700-EXIT. */

            R700_GRAVA_ARQ_SAIDA(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/


            /*" -1331- INITIALIZE WCONTADORES WACUMULADORES. */
            _.Initialize(
                W_INICIO_WORK.WCONTADORES
                , W_INICIO_WORK.WACUMULADORES
            );

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R400_EXIT*/

        [StopWatch]
        /*" R500-TRATA-QUEBRA-SINISTRO */
        private void R500_TRATA_QUEBRA_SINISTRO(bool isPerform = false)
        {
            /*" -1340- PERFORM R600-CALCULA-QTDES-VALORES THRU R600-EXIT. */

            R600_CALCULA_QTDES_VALORES(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R600_EXIT*/


            /*" -1340- PERFORM R050-FETCH-CURSORES THRU R050-EXIT. */

            R050_FETCH_CURSORES(true);

            R051_FETCH_RAMO(true);

            R052_FETCH_PRODUTO(true);

            R053_FETCH_APOLICE(true);

            R054_FETCH_RAMOVG(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R050_EXIT*/


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R500_EXIT*/

        [StopWatch]
        /*" R600-CALCULA-QTDES-VALORES */
        private void R600_CALCULA_QTDES_VALORES(bool isPerform = false)
        {
            /*" -1348- IF SINISHIS-COD-OPERACAO EQUAL 101 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 101)
            {

                /*" -1349- ADD 1 TO W-QTD-AVISADO */
                W_INICIO_WORK.WCONTADORES.W_QTD_AVISADO.Value = W_INICIO_WORK.WCONTADORES.W_QTD_AVISADO + 1;

                /*" -1351- ADD SINISHIS-VAL-OPERACAO TO W-ACM-AVISADO. */
                W_INICIO_WORK.WACUMULADORES.W_ACM_AVISADO.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_AVISADO + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;
            }


            /*" -1352- IF SINISHIS-COD-OPERACAO EQUAL 107 OR 108 OR 117 OR 118 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("107", "108", "117", "118"))
            {

                /*" -1353- ADD 1 TO W-QTD-CANCELADO */
                W_INICIO_WORK.WCONTADORES.W_QTD_CANCELADO.Value = W_INICIO_WORK.WCONTADORES.W_QTD_CANCELADO + 1;

                /*" -1354- ADD SINISHIS-VAL-OPERACAO TO W-ACM-CANCELADO */
                W_INICIO_WORK.WACUMULADORES.W_ACM_CANCELADO.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_CANCELADO + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1356- END-IF. */
            }


            /*" -1357- IF SINISHIS-COD-OPERACAO EQUAL 102 OR 103 OR 112 OR 113 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("102", "103", "112", "113"))
            {

                /*" -1358- ADD 1 TO W-QTD-AUM-RESERVA */
                W_INICIO_WORK.WCONTADORES.W_QTD_AUM_RESERVA.Value = W_INICIO_WORK.WCONTADORES.W_QTD_AUM_RESERVA + 1;

                /*" -1359- ADD SINISHIS-VAL-OPERACAO TO W-ACM-AUM-RESERVA */
                W_INICIO_WORK.WACUMULADORES.W_ACM_AUM_RESERVA.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_AUM_RESERVA + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1361- END-IF. */
            }


            /*" -1362- IF SINISHIS-COD-OPERACAO EQUAL 105 OR 106 OR 115 OR 116 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("105", "106", "115", "116"))
            {

                /*" -1363- ADD 1 TO W-QTD-DIM-RESERVA */
                W_INICIO_WORK.WCONTADORES.W_QTD_DIM_RESERVA.Value = W_INICIO_WORK.WCONTADORES.W_QTD_DIM_RESERVA + 1;

                /*" -1364- ADD SINISHIS-VAL-OPERACAO TO W-ACM-DIM-RESERVA */
                W_INICIO_WORK.WACUMULADORES.W_ACM_DIM_RESERVA.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_DIM_RESERVA + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1366- END-IF. */
            }


            /*" -1367- IF SINISHIS-COD-OPERACAO EQUAL 104 OR 114 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("104", "114"))
            {

                /*" -1368- ADD 1 TO W-QTD-REATIVACAO */
                W_INICIO_WORK.WCONTADORES.W_QTD_REATIVACAO.Value = W_INICIO_WORK.WCONTADORES.W_QTD_REATIVACAO + 1;

                /*" -1369- ADD SINISHIS-VAL-OPERACAO TO W-ACM-REATIVACAO */
                W_INICIO_WORK.WACUMULADORES.W_ACM_REATIVACAO.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_REATIVACAO + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1371- END-IF. */
            }


            /*" -1372- IF SINISHIS-COD-OPERACAO EQUAL 122 OR 123 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("122", "123"))
            {

                /*" -1373- ADD 1 TO W-QTD-CORR-MONET */
                W_INICIO_WORK.WCONTADORES.W_QTD_CORR_MONET.Value = W_INICIO_WORK.WCONTADORES.W_QTD_CORR_MONET + 1;

                /*" -1374- ADD SINISHIS-VAL-OPERACAO TO W-ACM-CORR-MONET */
                W_INICIO_WORK.WACUMULADORES.W_ACM_CORR_MONET.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_CORR_MONET + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1376- END-IF. */
            }


            /*" -1378- IF SINISHIS-COD-OPERACAO EQUAL 1001 OR 1002 OR 1003 OR 1004 OR 1009 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.In("1001", "1002", "1003", "1004", "1009"))
            {

                /*" -1379- ADD 1 TO W-QTD-INDENIZ */
                W_INICIO_WORK.WCONTADORES.W_QTD_INDENIZ.Value = W_INICIO_WORK.WCONTADORES.W_QTD_INDENIZ + 1;

                /*" -1380- ADD SINISHIS-VAL-OPERACAO TO W-ACM-INDENIZ */
                W_INICIO_WORK.WACUMULADORES.W_ACM_INDENIZ.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_INDENIZ + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1382- END-IF. */
            }


            /*" -1383- IF SINISHIS-COD-OPERACAO EQUAL 1050 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 1050)
            {

                /*" -1384- ADD 1 TO W-QTD-ESTORNOS */
                W_INICIO_WORK.WCONTADORES.W_QTD_ESTORNOS.Value = W_INICIO_WORK.WCONTADORES.W_QTD_ESTORNOS + 1;

                /*" -1385- ADD SINISHIS-VAL-OPERACAO TO W-ACM-ESTORNOS */
                W_INICIO_WORK.WACUMULADORES.W_ACM_ESTORNOS.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_ESTORNOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1387- END-IF. */
            }


            /*" -1388- IF SINISHIS-COD-OPERACAO EQUAL 2010 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 2010)
            {

                /*" -1389- ADD 1 TO W-QTD-DESPESAS */
                W_INICIO_WORK.WCONTADORES.W_QTD_DESPESAS.Value = W_INICIO_WORK.WCONTADORES.W_QTD_DESPESAS + 1;

                /*" -1390- ADD SINISHIS-VAL-OPERACAO TO W-ACM-DESPESAS */
                W_INICIO_WORK.WACUMULADORES.W_ACM_DESPESAS.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_DESPESAS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1392- END-IF. */
            }


            /*" -1393- IF SINISHIS-COD-OPERACAO EQUAL 2050 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 2050)
            {

                /*" -1394- ADD 1 TO W-QTD-EST-DESP */
                W_INICIO_WORK.WCONTADORES.W_QTD_EST_DESP.Value = W_INICIO_WORK.WCONTADORES.W_QTD_EST_DESP + 1;

                /*" -1395- ADD SINISHIS-VAL-OPERACAO TO W-ACM-EST-DESP */
                W_INICIO_WORK.WACUMULADORES.W_ACM_EST_DESP.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_EST_DESP + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1397- END-IF. */
            }


            /*" -1398- IF SINISHIS-COD-OPERACAO EQUAL 3010 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 3010)
            {

                /*" -1399- ADD 1 TO W-QTD-HONORARIOS */
                W_INICIO_WORK.WCONTADORES.W_QTD_HONORARIOS.Value = W_INICIO_WORK.WCONTADORES.W_QTD_HONORARIOS + 1;

                /*" -1400- ADD SINISHIS-VAL-OPERACAO TO W-ACM-HONORARIOS */
                W_INICIO_WORK.WACUMULADORES.W_ACM_HONORARIOS.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_HONORARIOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1402- END-IF. */
            }


            /*" -1403- IF SINISHIS-COD-OPERACAO EQUAL 3050 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 3050)
            {

                /*" -1404- ADD 1 TO W-QTD-EST-HONOR */
                W_INICIO_WORK.WCONTADORES.W_QTD_EST_HONOR.Value = W_INICIO_WORK.WCONTADORES.W_QTD_EST_HONOR + 1;

                /*" -1405- ADD SINISHIS-VAL-OPERACAO TO W-ACM-EST-HONOR */
                W_INICIO_WORK.WACUMULADORES.W_ACM_EST_HONOR.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_EST_HONOR + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1407- END-IF. */
            }


            /*" -1408- IF SINISHIS-COD-OPERACAO EQUAL 6040 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 6040)
            {

                /*" -1409- ADD 1 TO W-QTD-SALVADOS */
                W_INICIO_WORK.WCONTADORES.W_QTD_SALVADOS.Value = W_INICIO_WORK.WCONTADORES.W_QTD_SALVADOS + 1;

                /*" -1410- ADD SINISHIS-VAL-OPERACAO TO W-ACM-SALVADOS */
                W_INICIO_WORK.WACUMULADORES.W_ACM_SALVADOS.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_SALVADOS + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1412- END-IF. */
            }


            /*" -1413- IF SINISHIS-COD-OPERACAO EQUAL 6050 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 6050)
            {

                /*" -1414- ADD 1 TO W-QTD-DESP-SALV */
                W_INICIO_WORK.WCONTADORES.W_QTD_DESP_SALV.Value = W_INICIO_WORK.WCONTADORES.W_QTD_DESP_SALV + 1;

                /*" -1415- ADD SINISHIS-VAL-OPERACAO TO W-ACM-DESP-SALV */
                W_INICIO_WORK.WACUMULADORES.W_ACM_DESP_SALV.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_DESP_SALV + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1417- END-IF. */
            }


            /*" -1418- IF SINISHIS-COD-OPERACAO EQUAL 7040 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 7040)
            {

                /*" -1419- ADD 1 TO W-QTD-EST-HONOR-SALV */
                W_INICIO_WORK.WCONTADORES.W_QTD_EST_HONOR_SALV.Value = W_INICIO_WORK.WCONTADORES.W_QTD_EST_HONOR_SALV + 1;

                /*" -1420- ADD SINISHIS-VAL-OPERACAO TO W-ACM-EST-HONOR-SALV */
                W_INICIO_WORK.WACUMULADORES.W_ACM_EST_HONOR_SALV.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_EST_HONOR_SALV + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1422- END-IF. */
            }


            /*" -1423- IF SINISHIS-COD-OPERACAO EQUAL 7050 */

            if (SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO == 7050)
            {

                /*" -1424- ADD 1 TO W-QTD-HONOR-SALV */
                W_INICIO_WORK.WCONTADORES.W_QTD_HONOR_SALV.Value = W_INICIO_WORK.WCONTADORES.W_QTD_HONOR_SALV + 1;

                /*" -1425- ADD SINISHIS-VAL-OPERACAO TO W-ACM-HONOR-SALV */
                W_INICIO_WORK.WACUMULADORES.W_ACM_HONOR_SALV.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_HONOR_SALV + SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO;

                /*" -1425- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R600_EXIT*/

        [StopWatch]
        /*" R650-CALCULA-VLR-QTD-PENDENTE */
        private void R650_CALCULA_VLR_QTD_PENDENTE(bool isPerform = false)
        {
            /*" -1436- MOVE '014' TO WNR-EXEC-SQL. */
            _.Move("014", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1438- INITIALIZE SI1001S-PARAMETROS. */
            _.Initialize(
                LBSI1001.SI1001S_PARAMETROS
            );

            /*" -1439- MOVE W-GDA-SINISTRO TO SI1001S-NUM-APOL-SINISTRO */
            _.Move(W_GDA_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

            /*" -1441- MOVE RELATORI-PERI-FINAL TO SI1001S-DATA-FIM */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

            /*" -1443- CALL 'SI1001S' USING SI1001S-PARAMETROS */
            _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

            /*" -1444- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

            if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
            {

                /*" -1447- DISPLAY 'PROBLEMA CALL SI1001S ' ' ' W-GDA-SINISTRO ' ' RELATORI-PERI-FINAL */

                $"PROBLEMA CALL SI1001S  {W_GDA_SINISTRO} {RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL}"
                .Display();

                /*" -1448- DISPLAY 'SQLCODE = ' SI1001S-ERRO-SQLCODE */
                _.Display($"SQLCODE = {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                /*" -1449- DISPLAY SI1001S-ERRO-MENSAGEM */
                _.Display(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM);

                /*" -1450- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1451- ELSE */
            }
            else
            {


                /*" -1451- MOVE SI1001S-VALOR-CALCULADO TO HOST-PENDENTE. */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, HOST_PENDENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R650_EXIT*/

        [StopWatch]
        /*" R700-GRAVA-ARQ-SAIDA */
        private void R700_GRAVA_ARQ_SAIDA(bool isPerform = false)
        {
            /*" -1459- MOVE W-GDA-RAMO TO LD01-RAMO. */
            _.Move(W_GDA_RAMO, FILLER01.LD01.LD01_RAMO);

            /*" -1460- MOVE W-GDA-COD-PRODUTO TO LD01-COD-PRODUTO. */
            _.Move(W_GDA_COD_PRODUTO, FILLER01.LD01.LD01_COD_PRODUTO);

            /*" -1461- MOVE W-GDA-APOLICE TO LD01-APOLICE. */
            _.Move(W_GDA_APOLICE, FILLER01.LD01.LD01_APOLICE);

            /*" -1462- MOVE W-GDA-SINISTRO TO LD01-SINISTRO. */
            _.Move(W_GDA_SINISTRO, FILLER01.LD01.LD01_SINISTRO);

            /*" -1463- MOVE W-GDA-SUBGRUPO TO LD01-COD-SUBGRUPO. */
            _.Move(W_GDA_SUBGRUPO, FILLER01.LD01.LD01_COD_SUBGRUPO);

            /*" -1464- MOVE W-GDA-COD-CAUSA TO LD01-COD-CAUSA. */
            _.Move(W_GDA_COD_CAUSA, FILLER01.LD01.LD01_COD_CAUSA);

            /*" -1465- MOVE W-GDA-DESCR-PRODUTO TO LD01-PRODUTO. */
            _.Move(W_GDA_DESCR_PRODUTO, FILLER01.LD01.LD01_PRODUTO);

            /*" -1467- MOVE W-GDA-DESCR-CAUSA TO LD01-DESCR-CAUSA. */
            _.Move(W_GDA_DESCR_CAUSA, FILLER01.LD01.LD01_DESCR_CAUSA);

            /*" -1468- PERFORM R800-BUSCA-DESCR-FONTE-EMISSAO THRU R800-EXIT. */

            R800_BUSCA_DESCR_FONTE_EMISSAO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R800_EXIT*/


            /*" -1469- MOVE W-GDA-FONTE-EMIS TO LD01-COD-FONTE-EMIS. */
            _.Move(W_GDA_FONTE_EMIS, FILLER01.LD01.LD01_COD_FONTE_EMIS);

            /*" -1470- MOVE FONTES-NOME-FONTE TO LD01-FONTE-EMISSAO. */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, FILLER01.LD01.LD01_FONTE_EMISSAO);

            /*" -1471- PERFORM R850-BUSCA-DESC-FONTE-SINISTRO THRU R850-EXIT. */

            R850_BUSCA_DESC_FONTE_SINISTRO(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R850_EXIT*/


            /*" -1472- MOVE W-GDA-FONTE-SINI TO LD01-COD-FONTE-SINI. */
            _.Move(W_GDA_FONTE_SINI, FILLER01.LD01.LD01_COD_FONTE_SINI);

            /*" -1474- MOVE FONTES-NOME-FONTE TO LD01-FONTE-SINISTRO. */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, FILLER01.LD01.LD01_FONTE_SINISTRO);

            /*" -1476- MOVE RELATORI-PERI-INICIAL(09:02) TO LD01-PERI-INICIAL(01:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Substring(9, 2), FILLER01.LD01.LD01_PERI_INICIAL, 1, 2);

            /*" -1477- MOVE '/' TO LD01-PERI-INICIAL(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_PERI_INICIAL, 3, 1);

            /*" -1479- MOVE RELATORI-PERI-INICIAL(06:02) TO LD01-PERI-INICIAL(04:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Substring(6, 2), FILLER01.LD01.LD01_PERI_INICIAL, 4, 2);

            /*" -1480- MOVE '/' TO LD01-PERI-INICIAL(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_PERI_INICIAL, 6, 1);

            /*" -1483- MOVE RELATORI-PERI-INICIAL(01:04) TO LD01-PERI-INICIAL(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Substring(1, 4), FILLER01.LD01.LD01_PERI_INICIAL, 7, 4);

            /*" -1485- MOVE RELATORI-PERI-FINAL(09:02) TO LD01-PERI-FINAL(01:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(9, 2), FILLER01.LD01.LD01_PERI_FINAL, 1, 2);

            /*" -1486- MOVE '/' TO LD01-PERI-FINAL(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_PERI_FINAL, 3, 1);

            /*" -1488- MOVE RELATORI-PERI-FINAL(06:02) TO LD01-PERI-FINAL(04:02). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(6, 2), FILLER01.LD01.LD01_PERI_FINAL, 4, 2);

            /*" -1489- MOVE '/' TO LD01-PERI-FINAL(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_PERI_FINAL, 6, 1);

            /*" -1492- MOVE RELATORI-PERI-FINAL(01:04) TO LD01-PERI-FINAL(07:04). */
            _.MoveAtPosition(RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Substring(1, 4), FILLER01.LD01.LD01_PERI_FINAL, 7, 4);

            /*" -1494- MOVE W-GDA-DATA-COMUNICADO(09:02) TO LD01-DATA-COMUNICADO(01:02). */
            _.MoveAtPosition(W_GDA_DATA_COMUNICADO.Substring(9, 2), FILLER01.LD01.LD01_DATA_COMUNICADO, 1, 2);

            /*" -1495- MOVE '/' TO LD01-DATA-COMUNICADO(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_COMUNICADO, 3, 1);

            /*" -1497- MOVE W-GDA-DATA-COMUNICADO(06:02) TO LD01-DATA-COMUNICADO(04:02). */
            _.MoveAtPosition(W_GDA_DATA_COMUNICADO.Substring(6, 2), FILLER01.LD01.LD01_DATA_COMUNICADO, 4, 2);

            /*" -1498- MOVE '/' TO LD01-DATA-COMUNICADO(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_COMUNICADO, 6, 1);

            /*" -1501- MOVE W-GDA-DATA-COMUNICADO(01:04) TO LD01-DATA-COMUNICADO(07:04). */
            _.MoveAtPosition(W_GDA_DATA_COMUNICADO.Substring(1, 4), FILLER01.LD01.LD01_DATA_COMUNICADO, 7, 4);

            /*" -1503- MOVE W-GDA-DATA-OCORRENCIA(09:02) TO LD01-DATA-OCORRENCIA(01:02). */
            _.MoveAtPosition(W_GDA_DATA_OCORRENCIA.Substring(9, 2), FILLER01.LD01.LD01_DATA_OCORRENCIA, 1, 2);

            /*" -1504- MOVE '/' TO LD01-DATA-OCORRENCIA(03:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_OCORRENCIA, 3, 1);

            /*" -1506- MOVE W-GDA-DATA-OCORRENCIA(06:02) TO LD01-DATA-OCORRENCIA(04:02). */
            _.MoveAtPosition(W_GDA_DATA_OCORRENCIA.Substring(6, 2), FILLER01.LD01.LD01_DATA_OCORRENCIA, 4, 2);

            /*" -1507- MOVE '/' TO LD01-DATA-OCORRENCIA(06:01). */
            _.MoveAtPosition("/", FILLER01.LD01.LD01_DATA_OCORRENCIA, 6, 1);

            /*" -1510- MOVE W-GDA-DATA-OCORRENCIA(01:04) TO LD01-DATA-OCORRENCIA(07:04). */
            _.MoveAtPosition(W_GDA_DATA_OCORRENCIA.Substring(1, 4), FILLER01.LD01.LD01_DATA_OCORRENCIA, 7, 4);

            /*" -1511- IF W-GDA-SIT-REGISTRO EQUAL '2' */

            if (W_GDA_SIT_REGISTRO == "2")
            {

                /*" -1512- MOVE 'CANCELADO' TO LD01-SITUACAO */
                _.Move("CANCELADO", FILLER01.LD01.LD01_SITUACAO);

                /*" -1513- ELSE */
            }
            else
            {


                /*" -1515- MOVE SPACES TO LD01-SITUACAO. */
                _.Move("", FILLER01.LD01.LD01_SITUACAO);
            }


            /*" -1516- MOVE W-QTD-AVISADO TO LD01-QTD-AVISADO. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_AVISADO, FILLER01.LD01.LD01_QTD_AVISADO);

            /*" -1517- MOVE W-ACM-AVISADO TO LD01-ACM-AVISADO. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_AVISADO, FILLER01.LD01.LD01_ACM_AVISADO);

            /*" -1518- MOVE W-QTD-CANCELADO TO LD01-QTD-CANCELADO. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_CANCELADO, FILLER01.LD01.LD01_QTD_CANCELADO);

            /*" -1519- MOVE W-ACM-CANCELADO TO LD01-ACM-CANCELADO. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_CANCELADO, FILLER01.LD01.LD01_ACM_CANCELADO);

            /*" -1520- MOVE W-QTD-AUM-RESERVA TO LD01-QTD-AUM-RESERVA. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_AUM_RESERVA, FILLER01.LD01.LD01_QTD_AUM_RESERVA);

            /*" -1521- MOVE W-ACM-AUM-RESERVA TO LD01-ACM-AUM-RESERVA. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_AUM_RESERVA, FILLER01.LD01.LD01_ACM_AUM_RESERVA);

            /*" -1522- MOVE W-QTD-DIM-RESERVA TO LD01-QTD-DIM-RESERVA. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_DIM_RESERVA, FILLER01.LD01.LD01_QTD_DIM_RESERVA);

            /*" -1523- MOVE W-ACM-DIM-RESERVA TO LD01-ACM-DIM-RESERVA. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_DIM_RESERVA, FILLER01.LD01.LD01_ACM_DIM_RESERVA);

            /*" -1524- MOVE W-QTD-REATIVACAO TO LD01-QTD-REATIVACAO. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_REATIVACAO, FILLER01.LD01.LD01_QTD_REATIVACAO);

            /*" -1525- MOVE W-ACM-REATIVACAO TO LD01-ACM-REATIVACAO. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_REATIVACAO, FILLER01.LD01.LD01_ACM_REATIVACAO);

            /*" -1526- MOVE W-QTD-CORR-MONET TO LD01-QTD-CORR-MONET. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_CORR_MONET, FILLER01.LD01.LD01_QTD_CORR_MONET);

            /*" -1527- MOVE W-ACM-CORR-MONET TO LD01-ACM-CORR-MONET. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_CORR_MONET, FILLER01.LD01.LD01_ACM_CORR_MONET);

            /*" -1528- MOVE W-QTD-INDENIZ TO LD01-QTD-INDENIZ. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_INDENIZ, FILLER01.LD01.LD01_QTD_INDENIZ);

            /*" -1529- MOVE W-ACM-INDENIZ TO LD01-ACM-INDENIZ. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_INDENIZ, FILLER01.LD01.LD01_ACM_INDENIZ);

            /*" -1530- MOVE W-QTD-ESTORNOS TO LD01-QTD-ESTORNOS. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_ESTORNOS, FILLER01.LD01.LD01_QTD_ESTORNOS);

            /*" -1531- MOVE W-ACM-ESTORNOS TO LD01-ACM-ESTORNOS. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_ESTORNOS, FILLER01.LD01.LD01_ACM_ESTORNOS);

            /*" -1532- MOVE W-QTD-DESPESAS TO LD01-QTD-DESPESAS. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_DESPESAS, FILLER01.LD01.LD01_QTD_DESPESAS);

            /*" -1533- MOVE W-ACM-DESPESAS TO LD01-ACM-DESPESAS. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_DESPESAS, FILLER01.LD01.LD01_ACM_DESPESAS);

            /*" -1534- MOVE W-QTD-EST-DESP TO LD01-QTD-EST-DESP. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_EST_DESP, FILLER01.LD01.LD01_QTD_EST_DESP);

            /*" -1535- MOVE W-ACM-EST-DESP TO LD01-ACM-EST-DESP. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_EST_DESP, FILLER01.LD01.LD01_ACM_EST_DESP);

            /*" -1536- MOVE W-QTD-HONORARIOS TO LD01-QTD-HONORARIOS. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_HONORARIOS, FILLER01.LD01.LD01_QTD_HONORARIOS);

            /*" -1537- MOVE W-ACM-HONORARIOS TO LD01-ACM-HONORARIOS. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_HONORARIOS, FILLER01.LD01.LD01_ACM_HONORARIOS);

            /*" -1538- MOVE W-QTD-EST-HONOR TO LD01-QTD-EST-HONOR. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_EST_HONOR, FILLER01.LD01.LD01_QTD_EST_HONOR);

            /*" -1539- MOVE W-ACM-EST-HONOR TO LD01-ACM-EST-HONOR. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_EST_HONOR, FILLER01.LD01.LD01_ACM_EST_HONOR);

            /*" -1540- MOVE W-QTD-SALVADOS TO LD01-QTD-SALVADOS. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_SALVADOS, FILLER01.LD01.LD01_QTD_SALVADOS);

            /*" -1541- MOVE W-ACM-SALVADOS TO LD01-ACM-SALVADOS. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_SALVADOS, FILLER01.LD01.LD01_ACM_SALVADOS);

            /*" -1542- MOVE W-QTD-DESP-SALV TO LD01-QTD-DESP-SALV. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_DESP_SALV, FILLER01.LD01.LD01_QTD_DESP_SALV);

            /*" -1543- MOVE W-ACM-DESP-SALV TO LD01-ACM-DESP-SALV. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_DESP_SALV, FILLER01.LD01.LD01_ACM_DESP_SALV);

            /*" -1544- MOVE W-QTD-EST-HONOR-SALV TO LD01-QTD-EST-HONOR-SALV. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_EST_HONOR_SALV, FILLER01.LD01.LD01_QTD_EST_HONOR_SALV);

            /*" -1545- MOVE W-ACM-EST-HONOR-SALV TO LD01-ACM-EST-HONOR-SALV. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_EST_HONOR_SALV, FILLER01.LD01.LD01_ACM_EST_HONOR_SALV);

            /*" -1546- MOVE W-QTD-HONOR-SALV TO LD01-QTD-HONOR-SALV. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_HONOR_SALV, FILLER01.LD01.LD01_QTD_HONOR_SALV);

            /*" -1548- MOVE W-ACM-HONOR-SALV TO LD01-ACM-HONOR-SALV. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_HONOR_SALV, FILLER01.LD01.LD01_ACM_HONOR_SALV);

            /*" -1549- MOVE 0 TO W-QTD-PENDENTE. */
            _.Move(0, W_INICIO_WORK.WCONTADORES.W_QTD_PENDENTE);

            /*" -1551- MOVE 0 TO W-ACM-PENDENTE. */
            _.Move(0, W_INICIO_WORK.WACUMULADORES.W_ACM_PENDENTE);

            /*" -1553- PERFORM R650-CALCULA-VLR-QTD-PENDENTE THRU R650-EXIT. */

            R650_CALCULA_VLR_QTD_PENDENTE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R650_EXIT*/


            /*" -1554- IF HOST-PENDENTE NOT EQUAL 0 */

            if (HOST_PENDENTE != 0)
            {

                /*" -1555- ADD 1 TO W-QTD-PENDENTE */
                W_INICIO_WORK.WCONTADORES.W_QTD_PENDENTE.Value = W_INICIO_WORK.WCONTADORES.W_QTD_PENDENTE + 1;

                /*" -1556- ADD HOST-PENDENTE TO W-ACM-PENDENTE */
                W_INICIO_WORK.WACUMULADORES.W_ACM_PENDENTE.Value = W_INICIO_WORK.WACUMULADORES.W_ACM_PENDENTE + HOST_PENDENTE;

                /*" -1558- END-IF. */
            }


            /*" -1559- MOVE W-QTD-PENDENTE TO LD01-QTD-PENDENTE. */
            _.Move(W_INICIO_WORK.WCONTADORES.W_QTD_PENDENTE, FILLER01.LD01.LD01_QTD_PENDENTE);

            /*" -1561- MOVE W-ACM-PENDENTE TO LD01-ACM-PENDENTE. */
            _.Move(W_INICIO_WORK.WACUMULADORES.W_ACM_PENDENTE, FILLER01.LD01.LD01_ACM_PENDENTE);

            /*" -1561- WRITE REG-ARQ-SAIDA FROM LD01. */
            _.Move(FILLER01.LD01.GetMoveValues(), REG_ARQ_SAIDA);

            ARQ_SAIDA.Write(REG_ARQ_SAIDA.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R700_EXIT*/

        [StopWatch]
        /*" R800-BUSCA-DESCR-FONTE-EMISSAO */
        private void R800_BUSCA_DESCR_FONTE_EMISSAO(bool isPerform = false)
        {
            /*" -1573- IF (W-GDA-TIPO-REGISTRO NOT EQUAL 0) AND (W-GDA-RAMO EQUAL 93 OR 97 OR (W-GDA-RAMO EQUAL 81 AND (W-GDA-APOLICE LESS 103100000000 OR W-GDA-APOLICE GREATER 103199999999))) */

            if ((W_GDA_TIPO_REGISTRO != 0) && (W_GDA_RAMO.In("93", "97") || (W_GDA_RAMO == 81 && (W_GDA_APOLICE < 103100000000 || W_GDA_APOLICE > 103199999999))))
            {

                /*" -1574- PERFORM R810-BUSCA-FONTE-VIDA THRU R810-EXIT */

                R810_BUSCA_FONTE_VIDA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R810_EXIT*/


                /*" -1575- ELSE */
            }
            else
            {


                /*" -1575- PERFORM R830-BUSCA-FONTE-OUTROS THRU R830-EXIT. */

                R830_BUSCA_FONTE_OUTROS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R830_EXIT*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R800_EXIT*/

        [StopWatch]
        /*" R810-BUSCA-FONTE-VIDA */
        private void R810_BUSCA_FONTE_VIDA(bool isPerform = false)
        {
            /*" -1584- MOVE '016' TO WNR-EXEC-SQL. */
            _.Move("016", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1594- PERFORM R810_BUSCA_FONTE_VIDA_DB_SELECT_1 */

            R810_BUSCA_FONTE_VIDA_DB_SELECT_1();

            /*" -1597- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1598- MOVE '???' TO CLIENTES-NOME-RAZAO */
                _.Move("???", CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);

                /*" -1599- ELSE */
            }
            else
            {


                /*" -1600- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
                {

                    /*" -1601- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -1602- DISPLAY 'ERRO NA BUSCA COD FONTE SEGURADOS_VGAP...' */
                    _.Display($"ERRO NA BUSCA COD FONTE SEGURADOS_VGAP...");

                    /*" -1603- DISPLAY 'APOLICE     : ' W-GDA-APOLICE */
                    _.Display($"APOLICE     : {W_GDA_APOLICE}");

                    /*" -1604- DISPLAY 'SINISTRO    : ' W-GDA-SINISTRO */
                    _.Display($"SINISTRO    : {W_GDA_SINISTRO}");

                    /*" -1605- DISPLAY 'SUBGRUPO    : ' W-GDA-SUBGRUPO */
                    _.Display($"SUBGRUPO    : {W_GDA_SUBGRUPO}");

                    /*" -1606- DISPLAY 'CERTIFICADO : ' W-GDA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO : {W_GDA_NUM_CERTIFICADO}");

                    /*" -1607- DISPLAY '////////////////////////////////' */
                    _.Display($"////////////////////////////////");

                    /*" -1607- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R810-BUSCA-FONTE-VIDA-DB-SELECT-1 */
        public void R810_BUSCA_FONTE_VIDA_DB_SELECT_1()
        {
            /*" -1594- EXEC SQL SELECT F.NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.SEGURADOS_VGAP S, SEGUROS.FONTES F WHERE S.NUM_APOLICE = :W-GDA-APOLICE AND S.COD_SUBGRUPO = :W-GDA-SUBGRUPO AND S.NUM_CERTIFICADO = :W-GDA-NUM-CERTIFICADO AND F.COD_FONTE = :SEGURVGA-COD-FONTE AND S.TIPO_SEGURADO = :W-GDA-TIPO-SEGURADO END-EXEC. */

            var r810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1 = new R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1()
            {
                W_GDA_NUM_CERTIFICADO = W_GDA_NUM_CERTIFICADO.ToString(),
                W_GDA_TIPO_SEGURADO = W_GDA_TIPO_SEGURADO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                W_GDA_SUBGRUPO = W_GDA_SUBGRUPO.ToString(),
                W_GDA_APOLICE = W_GDA_APOLICE.ToString(),
            };

            var executed_1 = R810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1.Execute(r810_BUSCA_FONTE_VIDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R810_EXIT*/

        [StopWatch]
        /*" R830-BUSCA-FONTE-OUTROS */
        private void R830_BUSCA_FONTE_OUTROS(bool isPerform = false)
        {
            /*" -1616- MOVE '017' TO WNR-EXEC-SQL. */
            _.Move("017", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1621- PERFORM R830_BUSCA_FONTE_OUTROS_DB_SELECT_1 */

            R830_BUSCA_FONTE_OUTROS_DB_SELECT_1();

            /*" -1624- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1625- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1626- DISPLAY 'ERRO NA BUSCA DESCR FONTE NA TAB. FONTES.' */
                _.Display($"ERRO NA BUSCA DESCR FONTE NA TAB. FONTES.");

                /*" -1627- DISPLAY 'COD FONTE   : ' ENDOSSOS-COD-FONTE */
                _.Display($"COD FONTE   : {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE}");

                /*" -1628- DISPLAY 'COD FONTE   : ' W-GDA-FONTE-EMIS */
                _.Display($"COD FONTE   : {W_GDA_FONTE_EMIS}");

                /*" -1629- DISPLAY 'DESCR FONTE : ' FONTES-NOME-FONTE */
                _.Display($"DESCR FONTE : {FONTES.DCLFONTES.FONTES_NOME_FONTE}");

                /*" -1630- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1630- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R830-BUSCA-FONTE-OUTROS-DB-SELECT-1 */
        public void R830_BUSCA_FONTE_OUTROS_DB_SELECT_1()
        {
            /*" -1621- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :W-GDA-FONTE-EMIS END-EXEC. */

            var r830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1 = new R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1()
            {
                W_GDA_FONTE_EMIS = W_GDA_FONTE_EMIS.ToString(),
            };

            var executed_1 = R830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1.Execute(r830_BUSCA_FONTE_OUTROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R830_EXIT*/

        [StopWatch]
        /*" R850-BUSCA-DESC-FONTE-SINISTRO */
        private void R850_BUSCA_DESC_FONTE_SINISTRO(bool isPerform = false)
        {
            /*" -1639- MOVE '018' TO WNR-EXEC-SQL. */
            _.Move("018", FILLER_1.WABEND.WNR_EXEC_SQL);

            /*" -1644- PERFORM R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1 */

            R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1();

            /*" -1647- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1648- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1649- DISPLAY 'ERRO NA BUSCA DESCR FONTE NA TAB. FONTES.' */
                _.Display($"ERRO NA BUSCA DESCR FONTE NA TAB. FONTES.");

                /*" -1650- DISPLAY 'COD FONTE   : ' SINISMES-COD-FONTE */
                _.Display($"COD FONTE   : {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -1651- DISPLAY 'COD FONTE   : ' W-GDA-FONTE-SINI */
                _.Display($"COD FONTE   : {W_GDA_FONTE_SINI}");

                /*" -1652- DISPLAY 'DESCR FONTE : ' FONTES-NOME-FONTE */
                _.Display($"DESCR FONTE : {FONTES.DCLFONTES.FONTES_NOME_FONTE}");

                /*" -1653- DISPLAY '////////////////////////////////' */
                _.Display($"////////////////////////////////");

                /*" -1653- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R850-BUSCA-DESC-FONTE-SINISTRO-DB-SELECT-1 */
        public void R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1()
        {
            /*" -1644- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :W-GDA-FONTE-SINI END-EXEC. */

            var r850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1 = new R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1()
            {
                W_GDA_FONTE_SINI = W_GDA_FONTE_SINI.ToString(),
            };

            var executed_1 = R850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1.Execute(r850_BUSCA_DESC_FONTE_SINISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R850_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1663- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, FILLER_1.WABEND.WSQLCODE);

            /*" -1665- CLOSE ARQ-SAIDA. */
            ARQ_SAIDA.Close();

            /*" -1667- DISPLAY WABEND */
            _.Display(FILLER_1.WABEND);

            /*" -1667- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -1669- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1673- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -1673- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}