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
using Sias.Sinistro.DB2.SI0850B;

namespace Code
{
    public class SI0850B
    {
        public bool IsCall { get; set; }

        public SI0850B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      * SISTEMA          : SINISTRO                                    *      */
        /*"      *                                                                *      */
        /*"      * OBJETIVO         : EMITIR RELATORIO DE SINISTROS PENDENTES DE  *      */
        /*"      *                    AUTOMOVEIS QUE SEJA MENOR DO QUE A DATA     *      */
        /*"      *                    ATUAL.                                      *      */
        /*"      *                    RISCO DIVERSOS.                             *      */
        /*"      *                                                                *      */
        /*"      * ANALISTA         : HEIDER / RILDO SICO                         *      */
        /*"      *                                                                *      */
        /*"      * PROGRAMADOR      : RILDO SICO ALMEIDA DE SOUZA                 *      */
        /*"      *                                                                *      */
        /*"      * DATA             : MARCO/2000                                  *      */
        /*"      *                                                                *      */
        /*"      * ARQUIVO (INPUT)  : SINISTRO_MESTRE                             *      */
        /*"      *                    SINISTRO_HISTORICO                          *      */
        /*"      *                    PARAMETR_OPER_SINI                          *      */
        /*"      *                    FONTES                                      *      */
        /*"      *                    RAMOS                                       *      */
        /*"      *                    PRODUTO                                     *      */
        /*"      *                                                                *      */
        /*"      * ARQUIVO (OUTPUT) : PRINTER                                     *      */
        /*"      *                                                                *      */
        /*"      * ARQUIVO (TEMPORARIO) : ARQSORT                                 *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO  *    DATA     *    AUTOR    *       HISTORICO        *      */
        /*"      *           *             *             *                        *      */
        /*"      *     01    *  16/03/2000 *    RILDO    * CRIACAO.               *      */
        /*"      *           *             *             *                        *      */
        /*"      *     02    *  31/05/2000 * RILDO SICO  * NO CURSOR PRINCIPAL    *      */
        /*"      *           *             *             * FOI TROCADO O NOME DO  *      */
        /*"      *           *             *             * CAMPO O.TIPO_OPERACAO  *      */
        /*"      *           *             *             * POR O.IND_TIPO_OPERACAO*      */
        /*"      *           *             *             * EM VIRTUDE DA ALTERACAO*      */
        /*"      *           *             *             * DA TABELA              *      */
        /*"      *           *             *             * PARAMETR_OPER_SINI.    *      */
        /*"      *           *             *             * PROCURAR RS001         *      */
        /*"      *           *             *             *                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 06/04/2005 - PRODEXTER                                         *      */
        /*"      * (1) SUBSTITUICAO DA TABELA PARAMETR_OPER_SINI PELA GE_OPERACAO *      */
        /*"      * (2) SUBSTITUICAO DOS CALCULOS DE VALORES ATRAVES DE ACESSO A   *      */
        /*"      *     SINISTRO_HISTORICO PELA CHAMADAS AS SUB-ROTINAS DE CALCULO *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RSI0850B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RSI0850B
        {
            get
            {
                _.Move(REG_SI0850B, _RSI0850B); VarBasis.RedefinePassValue(REG_SI0850B, _RSI0850B, REG_SI0850B); return _RSI0850B;
            }
        }
        public SortBasis<SI0850B_REG_S0850B> S0850B { get; set; } = new SortBasis<SI0850B_REG_S0850B>(new SI0850B_REG_S0850B());
        /*"01  REG-SI0850B                 PIC  X(132).*/
        public StringBasis REG_SI0850B { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01  REG-S0850B.*/
        public SI0850B_REG_S0850B REG_S0850B { get; set; } = new SI0850B_REG_S0850B();
        public class SI0850B_REG_S0850B : VarBasis
        {
            /*"    03 S0850B-NUM-APOL-SINISTRO PIC  9(013).*/
            public IntBasis S0850B_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
            /*"    03 S0850B-COD-FONTE         PIC  9(004).*/
            public IntBasis S0850B_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 S0850B-NOME-FONTE        PIC  X(040).*/
            public StringBasis S0850B_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 S0850B-RAMO              PIC  9(004).*/
            public IntBasis S0850B_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 S0850B-NOME-RAMO         PIC  X(040).*/
            public StringBasis S0850B_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 S0850B-DATA-OCORRENCIA   PIC  X(010).*/
            public StringBasis S0850B_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 S0850B-DATA-COMUNICADO   PIC  X(010).*/
            public StringBasis S0850B_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 S0850B-DATA-TECNICA      PIC  X(010).*/
            public StringBasis S0850B_DATA_TECNICA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03 S0850B-COD-TITULO        PIC  9(002).*/
            public IntBasis S0850B_COD_TITULO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03 S0850B-DIAS-PEND         PIC  9(004).*/
            public IntBasis S0850B_DIAS_PEND { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 S0850B-NOME-RAZAO        PIC  X(040).*/
            public StringBasis S0850B_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03 S0850B-VALOR-AVISADO     PIC  9(013)V99.*/
            public DoubleBasis S0850B_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    03 S0850B-VALOR-PAGO        PIC  9(013)V99.*/
            public DoubleBasis S0850B_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    03 S0850B-VALOR-PENDENTE    PIC  9(013)V99.*/
            public DoubleBasis S0850B_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WS-AREA-TRABALHO.*/
        public SI0850B_WS_AREA_TRABALHO WS_AREA_TRABALHO { get; set; } = new SI0850B_WS_AREA_TRABALHO();
        public class SI0850B_WS_AREA_TRABALHO : VarBasis
        {
            /*"    03 WS-TIMESTAMP                 PIC  X(026) VALUE SPACES.*/
            public StringBasis WS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"    03 WS-TIMESTAMP-R REDEFINES WS-TIMESTAMP.*/
            private _REDEF_SI0850B_WS_TIMESTAMP_R _ws_timestamp_r { get; set; }
            public _REDEF_SI0850B_WS_TIMESTAMP_R WS_TIMESTAMP_R
            {
                get { _ws_timestamp_r = new _REDEF_SI0850B_WS_TIMESTAMP_R(); _.Move(WS_TIMESTAMP, _ws_timestamp_r); VarBasis.RedefinePassValue(WS_TIMESTAMP, _ws_timestamp_r, WS_TIMESTAMP); _ws_timestamp_r.ValueChanged += () => { _.Move(_ws_timestamp_r, WS_TIMESTAMP); }; return _ws_timestamp_r; }
                set { VarBasis.RedefinePassValue(value, _ws_timestamp_r, WS_TIMESTAMP); }
            }  //Redefines
            public class _REDEF_SI0850B_WS_TIMESTAMP_R : VarBasis
            {
                /*"       05 WS-ANO-TMP                PIC  9(004).*/
                public IntBasis WS_ANO_TMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MES-TMP                PIC  9(002).*/
                public IntBasis WS_MES_TMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-DIA-TMP                PIC  9(002).*/
                public IntBasis WS_DIA_TMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-HORA-TMP               PIC  9(002).*/
                public IntBasis WS_HORA_TMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MIN-TMP                PIC  9(002).*/
                public IntBasis WS_MIN_TMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-SEG-TMP                PIC  9(002).*/
                public IntBasis WS_SEG_TMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MSG-TMP                PIC  9(006).*/
                public IntBasis WS_MSG_TMP { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    03 WS-DATE-AMP                  PIC  X(010) VALUE SPACES.*/

                public _REDEF_SI0850B_WS_TIMESTAMP_R()
                {
                    WS_ANO_TMP.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_MES_TMP.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_DIA_TMP.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_HORA_TMP.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_MIN_TMP.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_SEG_TMP.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_MSG_TMP.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATE_AMP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 WS-DATE-AMP-R REDEFINES WS-DATE-AMP.*/
            private _REDEF_SI0850B_WS_DATE_AMP_R _ws_date_amp_r { get; set; }
            public _REDEF_SI0850B_WS_DATE_AMP_R WS_DATE_AMP_R
            {
                get { _ws_date_amp_r = new _REDEF_SI0850B_WS_DATE_AMP_R(); _.Move(WS_DATE_AMP, _ws_date_amp_r); VarBasis.RedefinePassValue(WS_DATE_AMP, _ws_date_amp_r, WS_DATE_AMP); _ws_date_amp_r.ValueChanged += () => { _.Move(_ws_date_amp_r, WS_DATE_AMP); }; return _ws_date_amp_r; }
                set { VarBasis.RedefinePassValue(value, _ws_date_amp_r, WS_DATE_AMP); }
            }  //Redefines
            public class _REDEF_SI0850B_WS_DATE_AMP_R : VarBasis
            {
                /*"       05 WS-ANO-AMP                PIC  9(004).*/
                public IntBasis WS_ANO_AMP { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-MES-AMP                PIC  9(002).*/
                public IntBasis WS_MES_AMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05 FILLER                    PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05 WS-DIA-AMP                PIC  9(002).*/
                public IntBasis WS_DIA_AMP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03 DIAS-PENDENTES               PIC S9(009) COMP.*/

                public _REDEF_SI0850B_WS_DATE_AMP_R()
                {
                    WS_ANO_AMP.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WS_MES_AMP.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WS_DIA_AMP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DIAS_PENDENTES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03 W-COUNT                      PIC S9(004) COMP   VALUE +0.*/
            public IntBasis W_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03 WS-VALOR-AUX.*/
            public SI0850B_WS_VALOR_AUX WS_VALOR_AUX { get; set; } = new SI0850B_WS_VALOR_AUX();
            public class SI0850B_WS_VALOR_AUX : VarBasis
            {
                /*"       05 WS-VL-OPERACAO            PIC S9(13)V9(2) COMP-3.*/
                public DoubleBasis WS_VL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"       05 WS-VL-PAGAMENTO           PIC S9(13)V9(2) COMP-3.*/
                public DoubleBasis WS_VL_PAGAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"       05 WS-VL-RESERVA             PIC S9(13)V9(2) COMP-3.*/
                public DoubleBasis WS_VL_RESERVA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"       03 WS-VL-AVISADO             PIC S9(13)V9(2) COMP-3.*/
                public DoubleBasis WS_VL_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"       03 WS-VL-PAGO                PIC S9(13)V9(2) COMP-3.*/
                public DoubleBasis WS_VL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"       03 WS-VL-PENDENTE            PIC S9(13)V9(2) COMP-3.*/
                public DoubleBasis WS_VL_PENDENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
                /*"    03 WS-CONTADORES.*/
            }
            public SI0850B_WS_CONTADORES WS_CONTADORES { get; set; } = new SI0850B_WS_CONTADORES();
            public class SI0850B_WS_CONTADORES : VarBasis
            {
                /*"       05 WS-TOTAL-AVISADO          PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TOTAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"       05 WS-TOTAL-PAGO             PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TOTAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"       05 WS-TOTAL-PENDENTE         PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TOTAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"    05 WS-TOTAL-GERAL.*/
            }
            public SI0850B_WS_TOTAL_GERAL WS_TOTAL_GERAL { get; set; } = new SI0850B_WS_TOTAL_GERAL();
            public class SI0850B_WS_TOTAL_GERAL : VarBasis
            {
                /*"       07 WS-TG-AVISADO             PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TG_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"       07 WS-TG-PAGO                PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TG_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"       07 WS-TG-PENDENTE            PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TG_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"    05 WS-TOTAL-GERAL-PARCIAL.*/
            }
            public SI0850B_WS_TOTAL_GERAL_PARCIAL WS_TOTAL_GERAL_PARCIAL { get; set; } = new SI0850B_WS_TOTAL_GERAL_PARCIAL();
            public class SI0850B_WS_TOTAL_GERAL_PARCIAL : VarBasis
            {
                /*"       07 WS-TP-AVISADO             PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TP_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"       07 WS-TP-PAGO                PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TP_PAGO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"       07 WS-TP-PENDENTE            PIC  9(013)V99 VALUE ZEROS.*/
                public DoubleBasis WS_TP_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
                /*"    03 WS-FONTE-ANT                 PIC  9(004) VALUE ZEROS.*/
            }
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-RAMO-ANT                  PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_RAMO_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    03 WS-TITULO-ANT                PIC  9(002) VALUE ZEROS.*/
            public IntBasis WS_TITULO_ANT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"    03 WS-DATA-AUX.*/
            public SI0850B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new SI0850B_WS_DATA_AUX();
            public class SI0850B_WS_DATA_AUX : VarBasis
            {
                /*"       05 WS-DD-AUX                 PIC  X(002) VALUE ZEROS.*/
                public StringBasis WS_DD_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       05 FILLER                    PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       05 WS-MM-AUX                 PIC  X(002) VALUE ZEROS.*/
                public StringBasis WS_MM_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       05 FILLER                    PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"       05 WS-AA-AUX                 PIC  X(004) VALUE ZEROS.*/
                public StringBasis WS_AA_AUX { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    03 AC-LINHAS                    PIC  9(003) COMP-3 VALUE 90.*/
            }
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"), 90);
            /*"    03 AC-FOLHAS                    PIC  9(005) VALUE ZEROS.*/
            public IntBasis AC_FOLHAS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    03 AC-LIDOS                     PIC  9(005) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"01  WS-MSG-ERRO                     PIC  X(040) VALUE SPACES.*/
        }
        public StringBasis WS_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
        /*"01  WS-STATUS-CAUSA                 PIC  9(002) VALUE ZEROS.*/

        public SelectorBasis WS_STATUS_CAUSA { get; set; } = new SelectorBasis("002", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-PERDA-TOTAL               VALUE 10 11 12 13 14 15 16                                          18 20. */
							new SelectorItemBasis("WS_PERDA_TOTAL", "10 11 12 13 14 15 16 18 20"),
							/*" 88 WS-PERDA-PARCIAL             VALUE 01 02 03 04 05                                          17 19 21. */
							new SelectorItemBasis("WS_PERDA_PARCIAL", "01 02 03 04 05 17 19 21"),
							/*" 88 WS-DANOS-MATERIAIS           VALUE 03 51 53. */
							new SelectorItemBasis("WS_DANOS_MATERIAIS", "03 51 53"),
							/*" 88 WS-DANOS-PESSOAIS            VALUE 52 54. */
							new SelectorItemBasis("WS_DANOS_PESSOAIS", "52 54")
                }
        };

        /*"01  WS-STATUS-CSINISTRO             PIC  X(001) VALUE SPACES.*/

        public SelectorBasis WS_STATUS_CSINISTRO { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-FIM-CSINISTRO             VALUE 'S'. */
							new SelectorItemBasis("WS_FIM_CSINISTRO", "S")
                }
        };

        /*"01  WS-STATUS-S0850B                PIC  X(001) VALUE SPACES.*/

        public SelectorBasis WS_STATUS_S0850B { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-FIM-S0850B                VALUE 'S'. */
							new SelectorItemBasis("WS_FIM_S0850B", "S"),
							/*" 88 WS-BOF-S0850B                VALUE ' '. */
							new SelectorItemBasis("WS_BOF_S0850B", " ")
                }
        };

        /*"01  WS-STATUS-CABEC                 PIC  X(001) VALUE SPACES.*/

        public SelectorBasis WS_STATUS_CABEC { get; set; } = new SelectorBasis("001", "SPACES")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 WS-CABEC-MODIFICADO          VALUE 'M'. */
							new SelectorItemBasis("WS_CABEC_MODIFICADO", "M"),
							/*" 88 WS-CABEC-IGUAL               VALUE 'I'. */
							new SelectorItemBasis("WS_CABEC_IGUAL", "I"),
							/*" 88 WS-CABEC-TOTALIZAR           VALUE 'T'. */
							new SelectorItemBasis("WS_CABEC_TOTALIZAR", "T")
                }
        };

        /*"01  WABEND.*/
        public SI0850B_WABEND WABEND { get; set; } = new SI0850B_WABEND();
        public class SI0850B_WABEND : VarBasis
        {
            /*"    03 FILLER                       PIC  X(010) VALUE       'SI0850B  '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SI0850B  ");
            /*"    03 FILLER                       PIC  X(028) VALUE       ' *** ERRO  EXEC SQL ***'.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
            /*"    03 FILLER                       PIC  X(014) VALUE       '    SQLCODE = '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"    03 WSQLCODE                     PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03 FILLER                       PIC  X(014)   VALUE       '   SQLERRD1 = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"    03 WSQLERRD1                    PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03 FILLER                       PIC  X(014)   VALUE       '   SQLERRD2 = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    03 WSQLERRD2                    PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"    03 FILLER                       PIC  X(014)   VALUE       '   SQLERRD2 = '.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"01  LOCALIZA-ABEND-1.*/
        }
        public SI0850B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new SI0850B_LOCALIZA_ABEND_1();
        public class SI0850B_LOCALIZA_ABEND_1 : VarBasis
        {
            /*"    03 FILLER                       PIC  X(012)   VALUE       'PARAGRAFO = '.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"    03 PARAGRAFO                    PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"01  LOCALIZA-ABEND-2.*/
        }
        public SI0850B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new SI0850B_LOCALIZA_ABEND_2();
        public class SI0850B_LOCALIZA_ABEND_2 : VarBasis
        {
            /*"    03 FILLER                       PIC  X(012)   VALUE       'COMANDO   = '.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"    03 COMANDO                      PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"01  RELATORIO.*/
        }
        public SI0850B_RELATORIO RELATORIO { get; set; } = new SI0850B_RELATORIO();
        public class SI0850B_RELATORIO : VarBasis
        {
            /*"    03 TRACO.*/
            public SI0850B_TRACO TRACO { get; set; } = new SI0850B_TRACO();
            public class SI0850B_TRACO : VarBasis
            {
                /*"       10 FILLER                   PIC  X(001) VALUE     '*'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"       10 FILLER                   PIC  X(130) VALUE ALL '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"       10 FILLER                   PIC  X(001) VALUE     '*'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    03 BRANCO.*/
            }
            public SI0850B_BRANCO BRANCO { get; set; } = new SI0850B_BRANCO();
            public class SI0850B_BRANCO : VarBasis
            {
                /*"       10 FILLER                   PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    03 LC01.*/
            }
            public SI0850B_LC01 LC01 { get; set; } = new SI0850B_LC01();
            public class SI0850B_LC01 : VarBasis
            {
                /*"       05 LC01-RELATORIO           PIC  X(007) VALUE 'SI0850B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI0850B");
                /*"       05 FILLER                   PIC  X(046) VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"       05 LC01-EMPRESA             PIC  X(038) VALUE        'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
                /*"       05 FILLER                   PIC  X(026) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"       05 FILLER                   PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"       05 LC01-FOLHA               PIC  ZZZ9.*/
                public IntBasis LC01_FOLHA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"    03 LC02.*/
            }
            public SI0850B_LC02 LC02 { get; set; } = new SI0850B_LC02();
            public class SI0850B_LC02 : VarBasis
            {
                /*"       05 FILLER                   PIC  X(053) VALUE  SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "53", "X(053)"), @"");
                /*"       05 FILLER                   PIC  X(038) VALUE        'RELACAO DE SINISTROS PENDENTES - AUTO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @"RELACAO DE SINISTROS PENDENTES - AUTO");
                /*"       05 FILLER                   PIC  X(026) VALUE  SPACES.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"       05 FILLER                   PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"       05 LC02-DATA.*/
                public SI0850B_LC02_DATA LC02_DATA { get; set; } = new SI0850B_LC02_DATA();
                public class SI0850B_LC02_DATA : VarBasis
                {
                    /*"          07 LC02-DD-DATA          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC02_DD_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER                PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LC02-MM-DATA          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC02_MM_DATA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER                PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LC02-AA-DATA          PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LC02_AA_DATA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"    03 LC03.*/
                }
            }
            public SI0850B_LC03 LC03 { get; set; } = new SI0850B_LC03();
            public class SI0850B_LC03 : VarBasis
            {
                /*"       05 LC03-FONTE-CAPTION       PIC  X(007) VALUE 'FONTE: '.*/
                public StringBasis LC03_FONTE_CAPTION { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"FONTE: ");
                /*"       05 LC03-FONTE               PIC  ZZ.*/
                public StringBasis LC03_FONTE { get; set; } = new StringBasis(new PIC("X", "0", "ZZ."), @"");
                /*"       05 LC03-TRACO01             PIC  X(003) VALUE ' - '.*/
                public StringBasis LC03_TRACO01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"       05 LC03-NOME-FONTE          PIC  X(034) VALUE  SPACES.*/
                public StringBasis LC03_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"       05 FILLER                   PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC03-TITULO              PIC  X(050) VALUE  SPACES.*/
                public StringBasis LC03_TITULO { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"       05 FILLER                   PIC  X(003) VALUE SPACES.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"       05 FILLER                   PIC  X(017) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
                /*"       05 FILLER                   PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"       05 LC03-HORA.*/
                public SI0850B_LC03_HORA LC03_HORA { get; set; } = new SI0850B_LC03_HORA();
                public class SI0850B_LC03_HORA : VarBasis
                {
                    /*"          07 LC03-HH-HORA          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC03_HH_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER                PIC  X(001) VALUE ':'.*/
                    public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                    /*"          07 LC03-MM-HORA          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC03_MM_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER                PIC  X(001) VALUE ':'.*/
                    public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                    /*"          07 LC03-SS-HORA          PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LC03_SS_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"    03 LC04.*/
                }
            }
            public SI0850B_LC04 LC04 { get; set; } = new SI0850B_LC04();
            public class SI0850B_LC04 : VarBasis
            {
                /*"       05 LC04-RAMO-CAPTION        PIC  X(007) VALUE 'RAMO : '.*/
                public StringBasis LC04_RAMO_CAPTION { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"RAMO : ");
                /*"       05 LC04-RAMO                PIC  ZZ.*/
                public StringBasis LC04_RAMO { get; set; } = new StringBasis(new PIC("X", "0", "ZZ."), @"");
                /*"       05 LC04-TRACO01             PIC  X(003) VALUE ' - '.*/
                public StringBasis LC04_TRACO01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"       05 LC04-NOME-RAMO           PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC04_NOME_RAMO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    03 LC05.*/
            }
            public SI0850B_LC05 LC05 { get; set; } = new SI0850B_LC05();
            public class SI0850B_LC05 : VarBasis
            {
                /*"       05 LC05-NUM-APOL-SINISTRO  PIC  X(013) VALUE         'SINISTRO'.*/
                public StringBasis LC05_NUM_APOL_SINISTRO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SINISTRO");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-DATA-OCORRENCIA    PIC  X(010) VALUE         'DT. OCORR.'.*/
                public StringBasis LC05_DATA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT. OCORR.");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-DATA-COMUNICADO    PIC  X(010) VALUE         'DT. COMUN.'.*/
                public StringBasis LC05_DATA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT. COMUN.");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-DATA-TECNICA       PIC  X(010) VALUE         'DT. CAD.'.*/
                public StringBasis LC05_DATA_TECNICA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DT. CAD.");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-DIAS-PEND          PIC  X(009) VALUE         'QTD. DIAS'.*/
                public StringBasis LC05_DIAS_PEND { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"QTD. DIAS");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-NOME-RAZAO         PIC  X(039) VALUE          'SEGURADO'.*/
                public StringBasis LC05_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "39", "X(039)"), @"SEGURADO");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-VALOR-AVISADO      PIC  X(011) VALUE          'VL. AVISADO'.*/
                public StringBasis LC05_VALOR_AVISADO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"VL. AVISADO");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-VALOR-PAGO         PIC  X(011) VALUE          '   VL. PAGO'.*/
                public StringBasis LC05_VALOR_PAGO { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"   VL. PAGO");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LC05-VALOR-PENDENTE     PIC  X(011) VALUE          '  VL. PEND.'.*/
                public StringBasis LC05_VALOR_PENDENTE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"  VL. PEND.");
                /*"    03 LD01.*/
            }
            public SI0850B_LD01 LD01 { get; set; } = new SI0850B_LD01();
            public class SI0850B_LD01 : VarBasis
            {
                /*"       05 LD01-NUM-APOL-SINISTRO  PIC  9(013) VALUE ZEROS.*/
                public IntBasis LD01_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-DATA-OCORRENCIA.*/
                public SI0850B_LD01_DATA_OCORRENCIA LD01_DATA_OCORRENCIA { get; set; } = new SI0850B_LD01_DATA_OCORRENCIA();
                public class SI0850B_LD01_DATA_OCORRENCIA : VarBasis
                {
                    /*"          07 LD01-DD-DT-OCORR     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LD01_DD_DT_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER               PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LD01-MM-DT-OCORR     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LD01_MM_DT_OCORR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER               PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LD01-AA-DT-OCORR     PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LD01_AA_DT_OCORR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-DATA-COMUNICADO.*/
                public SI0850B_LD01_DATA_COMUNICADO LD01_DATA_COMUNICADO { get; set; } = new SI0850B_LD01_DATA_COMUNICADO();
                public class SI0850B_LD01_DATA_COMUNICADO : VarBasis
                {
                    /*"          07 LD01-DD-DT-COMUN     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LD01_DD_DT_COMUN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER               PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LD01-MM-DT-COMUN     PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LD01_MM_DT_COMUN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER               PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LD01-AA-DT-COMUN     PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LD01_AA_DT_COMUN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-DATA-TECNICA.*/
                public SI0850B_LD01_DATA_TECNICA LD01_DATA_TECNICA { get; set; } = new SI0850B_LD01_DATA_TECNICA();
                public class SI0850B_LD01_DATA_TECNICA : VarBasis
                {
                    /*"          07 LD01-DD-DT-TEC       PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LD01_DD_DT_TEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER               PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LD01-MM-DT-TEC       PIC  9(002) VALUE ZEROS.*/
                    public IntBasis LD01_MM_DT_TEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 FILLER               PIC  X(001) VALUE '/'.*/
                    public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                    /*"          07 LD01-AA-DT-TEC       PIC  9(004) VALUE ZEROS.*/
                    public IntBasis LD01_AA_DT_TEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                    /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                }
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 FILLER                  PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       05 LD01-DIAS-PEND          PIC  Z.ZZ9.*/
                public IntBasis LD01_DIAS_PEND { get; set; } = new IntBasis(new PIC("9", "4", "Z.ZZ9."));
                /*"       05 FILLER                  PIC  X(002) VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-NOME-RAZAO         PIC  X(039).*/
                public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "39", "X(039)."), @"");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-VALOR-AVISADO      PIC  ----.--9,99.*/
                public DoubleBasis LD01_VALOR_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V99."), 2);
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-VALOR-PAGO         PIC  ----.--9,99.*/
                public DoubleBasis LD01_VALOR_PAGO { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V99."), 2);
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD01-VALOR-PENDENTE     PIC  ----.--9,99.*/
                public DoubleBasis LD01_VALOR_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V99."), 2);
                /*"    03 LD02.*/
            }
            public SI0850B_LD02 LD02 { get; set; } = new SI0850B_LD02();
            public class SI0850B_LD02 : VarBasis
            {
                /*"       05 FILLER                  PIC  X(077) VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"");
                /*"       05 FILLER                  PIC  X(020) VALUE         'TOTAL ............: '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL ............: ");
                /*"       05 LD02-TOTAL-AVISADO      PIC  ----.--9,99.*/
                public DoubleBasis LD02_TOTAL_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V99."), 2);
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD02-TOTAL-PAGO         PIC  ----.--9,99.*/
                public DoubleBasis LD02_TOTAL_PAGO { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V99."), 2);
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 LD02-TOTAL-PENDENTE     PIC  ----.--9,99.*/
                public DoubleBasis LD02_TOTAL_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "7", "----.--9V99."), 2);
                /*"    03 LD02-TRACO.*/
            }
            public SI0850B_LD02_TRACO LD02_TRACO { get; set; } = new SI0850B_LD02_TRACO();
            public class SI0850B_LD02_TRACO : VarBasis
            {
                /*"       05 FILLER                  PIC  X(097) VALUE SPACES.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "97", "X(097)"), @"");
                /*"       05 FILLER                  PIC  X(011) VALUE         '-----------'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"-----------");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 FILLER                  PIC  X(011) VALUE         '-----------'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"-----------");
                /*"       05 FILLER                  PIC  X(001) VALUE SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"       05 FILLER                  PIC  X(011) VALUE         '-----------'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"-----------");
                /*"    03 LINHA-RESUMO.*/
            }
            public SI0850B_LINHA_RESUMO LINHA_RESUMO { get; set; } = new SI0850B_LINHA_RESUMO();
            public class SI0850B_LINHA_RESUMO : VarBasis
            {
                /*"       05 WS-INDEX               PIC  9(003)    VALUE ZEROS.*/
                public IntBasis WS_INDEX { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"       05 WS-IND                 PIC  9(003)    VALUE ZEROS.*/
                public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"       05 WS-TOTAL-TIPOS         OCCURS 300.*/
                public ListBasis<SI0850B_WS_TOTAL_TIPOS> WS_TOTAL_TIPOS { get; set; } = new ListBasis<SI0850B_WS_TOTAL_TIPOS>(300);
                public class SI0850B_WS_TOTAL_TIPOS : VarBasis
                {
                    /*"          07 WS-TT-RAMO           PIC 9(002)    VALUE ZEROS.*/
                    public IntBasis WS_TT_RAMO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 WS-TT-FONTE          PIC 9(002)    VALUE ZEROS.*/
                    public IntBasis WS_TT_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 WS-TT-NOME-FONTE     PIC X(040)    VALUE ZEROS.*/
                    public StringBasis WS_TT_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"          07 WS-TT-TIPO-TITULO    PIC 9(002)    VALUE ZEROS.*/
                    public IntBasis WS_TT_TIPO_TITULO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                    /*"          07 WS-TT-AVISADO        PIC 9(009)V99 VALUE ZEROS.*/
                    public DoubleBasis WS_TT_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99"), 2);
                    /*"          07 WS-TT-PAGO           PIC 9(009)V99 VALUE ZEROS.*/
                    public DoubleBasis WS_TT_PAGO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99"), 2);
                    /*"          07 WS-TT-PENDENTE       PIC 9(009)V99 VALUE ZEROS.*/
                    public DoubleBasis WS_TT_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99"), 2);
                    /*"       05 LR01.*/
                }
                public SI0850B_LR01 LR01 { get; set; } = new SI0850B_LR01();
                public class SI0850B_LR01 : VarBasis
                {
                    /*"          07 FILLER               PIC X(004) VALUE 'RAMO'.*/
                    public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"RAMO");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(015) VALUE 'TIPO'.*/
                    public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"TIPO");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(020) VALUE            'CLASSIFICACAO'.*/
                    public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"CLASSIFICACAO");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(005) VALUE 'FONTE'.*/
                    public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                    /*"          07 FILLER               PIC X(040) VALUE SPACES.*/
                    public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(013) VALUE            '  VL. AVISADO'.*/
                    public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"  VL. AVISADO");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(013) VALUE            '     VL. PAGO'.*/
                    public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"     VL. PAGO");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(013) VALUE            '    VL. PEND.'.*/
                    public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"    VL. PEND.");
                    /*"       05 LR02.*/
                }
                public SI0850B_LR02 LR02 { get; set; } = new SI0850B_LR02();
                public class SI0850B_LR02 : VarBasis
                {
                    /*"          07 LR02-RAMO            PIC ZZ99   VALUE ZEROS.*/
                    public IntBasis LR02_RAMO { get; set; } = new IntBasis(new PIC("9", "4", "ZZ99"));
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR02-TIPO            PIC X(015) VALUE SPACES.*/
                    public StringBasis LR02_TIPO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR02-CLASSIFICACAO   PIC X(020) VALUE SPACES.*/
                    public StringBasis LR02_CLASSIFICACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR02-FONTE           PIC 99     VALUE ZEROS.*/
                    public IntBasis LR02_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "99"));
                    /*"          07 FILLER               PIC X(003) VALUE ' - '.*/
                    public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                    /*"          07 LR02-NOME-FONTE      PIC X(040) VALUE SPACES.*/
                    public StringBasis LR02_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR02-AVISADO         PIC --.---.--9,99.*/
                    public DoubleBasis LR02_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "8", "--.---.--9V99."), 2);
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR02-PAGO            PIC --.---.--9,99.*/
                    public DoubleBasis LR02_PAGO { get; set; } = new DoubleBasis(new PIC("9", "8", "--.---.--9V99."), 2);
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR02-PENDENTE        PIC --.---.--9,99.*/
                    public DoubleBasis LR02_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "8", "--.---.--9V99."), 2);
                    /*"       05 LR03.*/
                }
                public SI0850B_LR03 LR03 { get; set; } = new SI0850B_LR03();
                public class SI0850B_LR03 : VarBasis
                {
                    /*"          07 FILLER               PIC X(068) VALUE SPACES.*/
                    public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "68", "X(068)"), @"");
                    /*"          07 LR03-TITULO          PIC X(020) VALUE            'TOTAL GERAL ......: '.*/
                    public StringBasis LR03_TITULO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TOTAL GERAL ......: ");
                    /*"          07 LR03-TG-AVISADO      PIC --.---.--9,99.*/
                    public DoubleBasis LR03_TG_AVISADO { get; set; } = new DoubleBasis(new PIC("9", "8", "--.---.--9V99."), 2);
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR03-TG-PAGO         PIC --.---.--9,99.*/
                    public DoubleBasis LR03_TG_PAGO { get; set; } = new DoubleBasis(new PIC("9", "8", "--.---.--9V99."), 2);
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 LR03-TG-PENDENTE     PIC --.---.--9,99.*/
                    public DoubleBasis LR03_TG_PENDENTE { get; set; } = new DoubleBasis(new PIC("9", "8", "--.---.--9V99."), 2);
                    /*"       05 LR03-TRACO.*/
                }
                public SI0850B_LR03_TRACO LR03_TRACO { get; set; } = new SI0850B_LR03_TRACO();
                public class SI0850B_LR03_TRACO : VarBasis
                {
                    /*"          07 FILLER               PIC X(088) VALUE SPACES.*/
                    public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "88", "X(088)"), @"");
                    /*"          07 FILLER               PIC X(013) VALUE            '-------------'.*/
                    public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"-------------");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(013) VALUE            '-------------'.*/
                    public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"-------------");
                    /*"          07 FILLER               PIC X(001) VALUE SPACES.*/
                    public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                    /*"          07 FILLER               PIC X(013) VALUE            '-------------'.*/
                    public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"-------------");
                }
            }
        }


        public Copies.LBSI1001 LBSI1001 { get; set; } = new Copies.LBSI1001();
        public Dclgens.GEOPERAC GEOPERAC { get; set; } = new Dclgens.GEOPERAC();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.RAMOS RAMOS { get; set; } = new Dclgens.RAMOS();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public SI0850B_CSINISTRO CSINISTRO { get; set; } = new SI0850B_CSINISTRO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RSI0850B_FILE_NAME_P, string S0850B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RSI0850B.SetFile(RSI0850B_FILE_NAME_P);
                S0850B.SetFile(S0850B_FILE_NAME_P);

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
            /*" -503- PERFORM M-1000-INICIALIZAR */

            M_1000_INICIALIZAR(true);

            /*" -505- PERFORM 2000-PROCESSAR */

            M_2000_PROCESSAR(true);

            /*" -507- PERFORM 3000-FINALIZAR */

            M_3000_FINALIZAR(true);

            /*" -507- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-1000-INICIALIZAR */
        private void M_1000_INICIALIZAR(bool isPerform = false)
        {
            /*" -515- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -517- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

            /*" -519- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC */

            /*" -521- PERFORM M_1000_INICIALIZAR_DB_SET_1 */

            M_1000_INICIALIZAR_DB_SET_1();

            /*" -524- PERFORM R0010-PROCURAR-DATA-SISTEMA */

            R0010_PROCURAR_DATA_SISTEMA(true);

            /*" -526- PERFORM R0020-PROCURAR-RELATORIO */

            R0020_PROCURAR_RELATORIO(true);

            /*" -527- MOVE WS-DIA-TMP TO LC02-DD-DATA */
            _.Move(WS_AREA_TRABALHO.WS_TIMESTAMP_R.WS_DIA_TMP, RELATORIO.LC02.LC02_DATA.LC02_DD_DATA);

            /*" -528- MOVE WS-MES-TMP TO LC02-MM-DATA */
            _.Move(WS_AREA_TRABALHO.WS_TIMESTAMP_R.WS_MES_TMP, RELATORIO.LC02.LC02_DATA.LC02_MM_DATA);

            /*" -530- MOVE WS-ANO-TMP TO LC02-AA-DATA */
            _.Move(WS_AREA_TRABALHO.WS_TIMESTAMP_R.WS_ANO_TMP, RELATORIO.LC02.LC02_DATA.LC02_AA_DATA);

            /*" -531- MOVE WS-HORA-TMP TO LC03-HH-HORA */
            _.Move(WS_AREA_TRABALHO.WS_TIMESTAMP_R.WS_HORA_TMP, RELATORIO.LC03.LC03_HORA.LC03_HH_HORA);

            /*" -532- MOVE WS-MIN-TMP TO LC03-MM-HORA */
            _.Move(WS_AREA_TRABALHO.WS_TIMESTAMP_R.WS_MIN_TMP, RELATORIO.LC03.LC03_HORA.LC03_MM_HORA);

            /*" -534- MOVE WS-SEG-TMP TO LC03-SS-HORA */
            _.Move(WS_AREA_TRABALHO.WS_TIMESTAMP_R.WS_SEG_TMP, RELATORIO.LC03.LC03_HORA.LC03_SS_HORA);

            /*" -581- PERFORM M_1000_INICIALIZAR_DB_DECLARE_1 */

            M_1000_INICIALIZAR_DB_DECLARE_1();

            /*" -587- PERFORM R1010-ABRIR-CURSOR-CSINISTRO */

            R1010_ABRIR_CURSOR_CSINISTRO(true);

            /*" -588- PERFORM R1020-FETCH-CURSOR-CSINISTRO */

            R1020_FETCH_CURSOR_CSINISTRO(true);

            /*" -589- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -591- MOVE 'CURSOR CSINISTRO ESTA VAZIO.' TO WS-MSG-ERRO */
                _.Move("CURSOR CSINISTRO ESTA VAZIO.", WS_MSG_ERRO);

                /*" -592- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -594- END-IF */
            }


            /*" -595- DISPLAY '*-------------------------------------------*' */
            _.Display($"*-------------------------------------------*");

            /*" -596- DISPLAY '**> IMPRESSAO ATE ' WS-DATE-AMP '              <**' */

            $"**> IMPRESSAO ATE {WS_AREA_TRABALHO.WS_DATE_AMP}              <**"
            .Display();

            /*" -598- DISPLAY '*-------------------------------------------*' */
            _.Display($"*-------------------------------------------*");

            /*" -599- MOVE WS-DIA-AMP TO WS-DD-AUX */
            _.Move(WS_AREA_TRABALHO.WS_DATE_AMP_R.WS_DIA_AMP, WS_AREA_TRABALHO.WS_DATA_AUX.WS_DD_AUX);

            /*" -600- MOVE WS-MES-AMP TO WS-MM-AUX */
            _.Move(WS_AREA_TRABALHO.WS_DATE_AMP_R.WS_MES_AMP, WS_AREA_TRABALHO.WS_DATA_AUX.WS_MM_AUX);

            /*" -600- MOVE WS-ANO-AMP TO WS-AA-AUX. */
            _.Move(WS_AREA_TRABALHO.WS_DATE_AMP_R.WS_ANO_AMP, WS_AREA_TRABALHO.WS_DATA_AUX.WS_AA_AUX);

        }

        [StopWatch]
        /*" M-1000-INICIALIZAR-DB-SET-1 */
        public void M_1000_INICIALIZAR_DB_SET_1()
        {
            /*" -521- EXEC SQL SET :WS-TIMESTAMP = CURRENT_TIMESTAMP END-EXEC */
            _.Move(_.CurrentDate(), WS_AREA_TRABALHO.WS_TIMESTAMP);

        }

        [StopWatch]
        /*" M-1000-INICIALIZAR-DB-DECLARE-1 */
        public void M_1000_INICIALIZAR_DB_DECLARE_1()
        {
            /*" -581- EXEC SQL DECLARE CSINISTRO CURSOR FOR SELECT DISTINCT M.NUM_APOL_SINISTRO, M.COD_FONTE, M.RAMO, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, M.DATA_TECNICA, M.COD_CAUSA, DAYS(CURRENT DATE) - DAYS(M.DATA_TECNICA) AS DIAS_PENDENTES, C.NOME_RAZAO, CURRENT DATE - 1 DAYS AS DATA_ANTERIOR FROM SEGUROS.SINISTRO_MESTRE M, SEGUROS.SINISTRO_HISTORICO H, SEGUROS.GE_OPERACAO O, SEGUROS.APOLICES A, SEGUROS.CLIENTES C WHERE ((M.NUM_APOLICE BETWEEN 0103100000000 AND 0103199999999 ) OR (M.NUM_APOLICE BETWEEN 0105300000000 AND 0105399999999 )) AND M.RAMO IN (31,53,81) AND M.NUM_APOLICE = A.NUM_APOLICE AND A.COD_CLIENTE = C.COD_CLIENTE AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO AND H.DATA_MOVIMENTO < CURRENT DATE AND O.IDE_SISTEMA = 'SI' AND H.COD_OPERACAO = O.COD_OPERACAO AND O.IND_TIPO_FUNCAO IN ( 'AV' , 'IN' ) GROUP BY M.NUM_APOL_SINISTRO, M.COD_FONTE, M.RAMO, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, M.DATA_TECNICA, M.COD_CAUSA, C.NOME_RAZAO ORDER BY M.NUM_APOL_SINISTRO, M.COD_FONTE, M.RAMO, M.DATA_OCORRENCIA, M.DATA_COMUNICADO, M.DATA_TECNICA, M.COD_CAUSA, C.NOME_RAZAO END-EXEC */
            CSINISTRO = new SI0850B_CSINISTRO(false);
            string GetQuery_CSINISTRO()
            {
                var query = @$"SELECT DISTINCT M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							M.RAMO
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_TECNICA
							, 
							M.COD_CAUSA
							, 
							DAYS(CURRENT DATE) - DAYS(M.DATA_TECNICA) 
							AS DIAS_PENDENTES
							, 
							C.NOME_RAZAO
							, 
							CURRENT DATE - 1 DAYS AS DATA_ANTERIOR 
							FROM SEGUROS.SINISTRO_MESTRE M
							, 
							SEGUROS.SINISTRO_HISTORICO H
							, 
							SEGUROS.GE_OPERACAO O
							, 
							SEGUROS.APOLICES A
							, 
							SEGUROS.CLIENTES C 
							WHERE ((M.NUM_APOLICE BETWEEN 0103100000000 AND 
							0103199999999 ) OR 
							(M.NUM_APOLICE BETWEEN 0105300000000 AND 
							0105399999999 )) 
							AND M.RAMO IN (31
							,53
							,81) 
							AND M.NUM_APOLICE = A.NUM_APOLICE 
							AND A.COD_CLIENTE = C.COD_CLIENTE 
							AND M.NUM_APOL_SINISTRO = H.NUM_APOL_SINISTRO 
							AND H.DATA_MOVIMENTO < CURRENT DATE 
							AND O.IDE_SISTEMA = 'SI' 
							AND H.COD_OPERACAO = O.COD_OPERACAO 
							AND O.IND_TIPO_FUNCAO IN ( 'AV'
							, 'IN' ) 
							GROUP BY M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							M.RAMO
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_TECNICA
							, 
							M.COD_CAUSA
							, 
							C.NOME_RAZAO 
							ORDER BY M.NUM_APOL_SINISTRO
							, 
							M.COD_FONTE
							, 
							M.RAMO
							, 
							M.DATA_OCORRENCIA
							, 
							M.DATA_COMUNICADO
							, 
							M.DATA_TECNICA
							, 
							M.COD_CAUSA
							, 
							C.NOME_RAZAO";

                return query;
            }
            CSINISTRO.GetQueryEvent += GetQuery_CSINISTRO;

        }

        [StopWatch]
        /*" M-2000-PROCESSAR */
        private void M_2000_PROCESSAR(bool isPerform = false)
        {
            /*" -609- PERFORM R0100-SORT-ARQUIVO-TMP */

            R0100_SORT_ARQUIVO_TMP(true);

            /*" -609- PERFORM R0224-RESUMO-SORT. */

            R0224_RESUMO_SORT(true);

        }

        [StopWatch]
        /*" M-3000-FINALIZAR */
        private void M_3000_FINALIZAR(bool isPerform = false)
        {
            /*" -619- PERFORM R0030-ATUALIZAR-RELATORIO */

            R0030_ATUALIZAR_RELATORIO(true);

            /*" -621- CLOSE RSI0850B */
            RSI0850B.Close();

            /*" -621- PERFORM M_3000_FINALIZAR_DB_CLOSE_1 */

            M_3000_FINALIZAR_DB_CLOSE_1();

            /*" -624- DISPLAY '*------------------------------------------------*' */
            _.Display($"*------------------------------------------------*");

            /*" -626- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -627- DISPLAY '*         EXECUCAO REALIZADA COM SUCESSO         *' */
            _.Display($"*         EXECUCAO REALIZADA COM SUCESSO         *");

            /*" -628- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -628- DISPLAY '*------------------------------------------------*' . */
            _.Display($"*------------------------------------------------*");

        }

        [StopWatch]
        /*" M-3000-FINALIZAR-DB-CLOSE-1 */
        public void M_3000_FINALIZAR_DB_CLOSE_1()
        {
            /*" -621- EXEC SQL CLOSE CSINISTRO END-EXEC */

            CSINISTRO.Close();

        }

        [StopWatch]
        /*" R0010-PROCURAR-DATA-SISTEMA */
        private void R0010_PROCURAR_DATA_SISTEMA(bool isPerform = false)
        {
            /*" -639- PERFORM R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1 */

            R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1();

            /*" -642- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -643- DISPLAY 'ERRO SELECT SISTEMAS PARA IDE_SISTEMA = SI' */
                _.Display($"ERRO SELECT SISTEMAS PARA IDE_SISTEMA = SI");

                /*" -644- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -645- ELSE */
            }
            else
            {


                /*" -646- DISPLAY '*--------------------------------------------*' */
                _.Display($"*--------------------------------------------*");

                /*" -648- DISPLAY '* DATA DE MOVIMENTO : ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"* DATA DE MOVIMENTO : {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -649- DISPLAY '*--------------------------------------------*' */
                _.Display($"*--------------------------------------------*");

                /*" -649- END-IF. */
            }


        }

        [StopWatch]
        /*" R0010-PROCURAR-DATA-SISTEMA-DB-SELECT-1 */
        public void R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1()
        {
            /*" -639- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC */

            var r0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1 = new R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1.Execute(r0010_PROCURAR_DATA_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R0020-PROCURAR-RELATORIO */
        private void R0020_PROCURAR_RELATORIO(bool isPerform = false)
        {
            /*" -662- PERFORM R0020_PROCURAR_RELATORIO_DB_SELECT_1 */

            R0020_PROCURAR_RELATORIO_DB_SELECT_1();

            /*" -665- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -666- DISPLAY 'ERRO NO SELECT NA RELATORIOS' */
                _.Display($"ERRO NO SELECT NA RELATORIOS");

                /*" -667- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -669- END-IF */
            }


            /*" -670- IF W-COUNT EQUAL ZERO */

            if (WS_AREA_TRABALHO.W_COUNT == 00)
            {

                /*" -671- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -672- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -673- DISPLAY '*         PROGRAMA - SI0850B                   *' */
                _.Display($"*         PROGRAMA - SI0850B                   *");

                /*" -674- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -675- DISPLAY '*  NAO FOI ENCONTRADA SOLICITACAO NA           *' */
                _.Display($"*  NAO FOI ENCONTRADA SOLICITACAO NA           *");

                /*" -676- DISPLAY '*  V0RELATORIOS PELO USUARIO, PARA EXECUCAO    *' */
                _.Display($"*  V0RELATORIOS PELO USUARIO, PARA EXECUCAO    *");

                /*" -677- DISPLAY '*  DO PROGRAMA.                                *' */
                _.Display($"*  DO PROGRAMA.                                *");

                /*" -678- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -679- DISPLAY '*         TERMINO NORMAL DO PROGRAMA           *' */
                _.Display($"*         TERMINO NORMAL DO PROGRAMA           *");

                /*" -680- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -681- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -682- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -682- END-IF. */
            }


        }

        [StopWatch]
        /*" R0020-PROCURAR-RELATORIO-DB-SELECT-1 */
        public void R0020_PROCURAR_RELATORIO_DB_SELECT_1()
        {
            /*" -662- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :W-COUNT FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'SI0850B' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC */

            var r0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1 = new R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1.Execute(r0020_PROCURAR_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.W_COUNT, WS_AREA_TRABALHO.W_COUNT);
            }


        }

        [StopWatch]
        /*" R0030-ATUALIZAR-RELATORIO */
        private void R0030_ATUALIZAR_RELATORIO(bool isPerform = false)
        {
            /*" -694- PERFORM R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1 */

            R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1();

            /*" -697- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
            {

                /*" -698- DISPLAY 'ERRO NO UPDATE RELATORIOS' */
                _.Display($"ERRO NO UPDATE RELATORIOS");

                /*" -699- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -699- END-IF. */
            }


        }

        [StopWatch]
        /*" R0030-ATUALIZAR-RELATORIO-DB-UPDATE-1 */
        public void R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1()
        {
            /*" -694- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '1' WHERE COD_RELATORIO = 'SI0850B' AND DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO AND SIT_REGISTRO = '0' END-EXEC */

            var r0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1 = new R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1.Execute(r0030_ATUALIZAR_RELATORIO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0100-SORT-ARQUIVO-TMP */
        private void R0100_SORT_ARQUIVO_TMP(bool isPerform = false)
        {
            /*" -712- SORT S0850B ON ASCENDING KEY S0850B-COD-FONTE ASCENDING KEY S0850B-RAMO ASCENDING KEY S0850B-COD-TITULO DESCENDING KEY S0850B-DIAS-PEND INPUT PROCEDURE R0110-INPUT-SORT OUTPUT PROCEDURE R0120-OUTPUT-SORT. */
            SORT_RETURN.Value = S0850B.Sort("S0850B-COD-FONTE,ASCENDING,KEY,S0850B-RAMO,ASCENDING,KEY,S0850B-COD-TITULO,DESCENDING,KEY,S0850B-DIAS-PEND", () => R0110_INPUT_SORT(true), () => R0120_OUTPUT_SORT(true));

            /*" -716- IF SORT-RETURN EQUAL ZEROS NEXT SENTENCE */

            if (SORT_RETURN == 00)
            {

                /*" -717- ELSE */
            }
            else
            {


                /*" -718- DISPLAY 'R0200 - ERRO NO SORT INTERNO PROGRAMA SI0850B' */
                _.Display($"R0200 - ERRO NO SORT INTERNO PROGRAMA SI0850B");

                /*" -719- DISPLAY 'SORT RETURN = ' SORT-RETURN */
                _.Display($"SORT RETURN = {SORT_RETURN}");

                /*" -720- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -720- END-IF. */
            }


        }

        [StopWatch]
        /*" R0110-INPUT-SORT */
        private void R0110_INPUT_SORT(bool isPerform = false)
        {
            /*" -726- OPEN OUTPUT RSI0850B */
            RSI0850B.Open(REG_SI0850B);

            /*" -730- PERFORM UNTIL WS-FIM-CSINISTRO */

            while (!(WS_STATUS_CSINISTRO["WS_FIM_CSINISTRO"]))
            {

                /*" -732- INITIALIZE SI1001S-PARAMETROS */
                _.Initialize(
                    LBSI1001.SI1001S_PARAMETROS
                );

                /*" -734- MOVE SINISMES-NUM-APOL-SINISTRO OF DCLSINISTRO-MESTRE TO SI1001S-NUM-APOL-SINISTRO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

                /*" -736- MOVE WS-DATE-AMP TO SI1001S-DATA-FIM */
                _.Move(WS_AREA_TRABALHO.WS_DATE_AMP, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

                /*" -738- CALL 'SI1001S' USING SI1001S-PARAMETROS */
                _.Call("SI1001S", LBSI1001.SI1001S_PARAMETROS);

                /*" -739- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

                if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
                {

                    /*" -740- DISPLAY 'PROBLEMA CALL SI1001S ' */
                    _.Display($"PROBLEMA CALL SI1001S ");

                    /*" -741- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                    _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                    /*" -742- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                    _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                    /*" -743- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                    _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                    /*" -744- DISPLAY ' ' SI1001S-DATA-FIM */
                    _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                    /*" -745- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -747- END-IF */
                }


                /*" -751- MOVE SI1001S-VALOR-CALCULADO TO WS-VL-PENDENTE */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_PENDENTE);

                /*" -753- INITIALIZE SI1001S-PARAMETROS */
                _.Initialize(
                    LBSI1001.SI1001S_PARAMETROS
                );

                /*" -755- MOVE SINISMES-NUM-APOL-SINISTRO OF DCLSINISTRO-MESTRE TO SI1001S-NUM-APOL-SINISTRO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

                /*" -757- MOVE WS-DATE-AMP TO SI1001S-DATA-FIM */
                _.Move(WS_AREA_TRABALHO.WS_DATE_AMP, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

                /*" -759- CALL 'SI1002S' USING SI1001S-PARAMETROS */
                _.Call("SI1002S", LBSI1001.SI1001S_PARAMETROS);

                /*" -760- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

                if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
                {

                    /*" -761- DISPLAY 'PROBLEMA CALL SI1002S ' */
                    _.Display($"PROBLEMA CALL SI1002S ");

                    /*" -762- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                    _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                    /*" -763- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                    _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                    /*" -764- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                    _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                    /*" -765- DISPLAY ' ' SI1001S-DATA-FIM */
                    _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                    /*" -766- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -768- END-IF */
                }


                /*" -772- MOVE SI1001S-VALOR-CALCULADO TO WS-VL-PAGO */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_PAGO);

                /*" -774- INITIALIZE SI1001S-PARAMETROS */
                _.Initialize(
                    LBSI1001.SI1001S_PARAMETROS
                );

                /*" -776- MOVE SINISMES-NUM-APOL-SINISTRO OF DCLSINISTRO-MESTRE TO SI1001S-NUM-APOL-SINISTRO */
                _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO);

                /*" -778- MOVE WS-DATE-AMP TO SI1001S-DATA-FIM */
                _.Move(WS_AREA_TRABALHO.WS_DATE_AMP, LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM);

                /*" -780- CALL 'SI1003S' USING SI1001S-PARAMETROS */
                _.Call("SI1003S", LBSI1001.SI1001S_PARAMETROS);

                /*" -781- IF SI1001S-ERRO-MENSAGEM NOT EQUAL SPACES */

                if (!LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM.IsEmpty())
                {

                    /*" -782- DISPLAY 'PROBLEMA CALL SI1003S ' */
                    _.Display($"PROBLEMA CALL SI1003S ");

                    /*" -783- DISPLAY 'SQLCODE  - ' SI1001S-ERRO-SQLCODE */
                    _.Display($"SQLCODE  - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_SQLCODE}");

                    /*" -784- DISPLAY 'MENSAGEM - ' SI1001S-ERRO-MENSAGEM */
                    _.Display($"MENSAGEM - {LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_ERRO_MENSAGEM}");

                    /*" -785- DISPLAY ' ' SI1001S-NUM-APOL-SINISTRO */
                    _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_NUM_APOL_SINISTRO}");

                    /*" -786- DISPLAY ' ' SI1001S-DATA-FIM */
                    _.Display($" {LBSI1001.SI1001S_PARAMETROS.SI1001S_ENTRADA.SI1001S_DATA_FIM}");

                    /*" -787- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO(); //GOTO
                    return;

                    /*" -789- END-IF */
                }


                /*" -791- MOVE SI1001S-VALOR-CALCULADO TO WS-VL-AVISADO */
                _.Move(LBSI1001.SI1001S_PARAMETROS.SI1001S_SAIDA.SI1001S_VALOR_CALCULADO, WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_AVISADO);

                /*" -792- IF WS-VL-PENDENTE NOT EQUAL ZEROS */

                if (WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_PENDENTE != 00)
                {

                    /*" -793- PERFORM R1070-ENCONTRAR-FONTE */

                    R1070_ENCONTRAR_FONTE(true);

                    /*" -794- PERFORM R1080-ENCONTRAR-RAMOS */

                    R1080_ENCONTRAR_RAMOS(true);

                    /*" -795- PERFORM R0130-MONTA-SORT */

                    R0130_MONTA_SORT(true);

                    /*" -796- RELEASE REG-S0850B */
                    S0850B.Release(REG_S0850B);

                    /*" -798- END-IF */
                }


                /*" -800- PERFORM R1020-FETCH-CURSOR-CSINISTRO */

                R1020_FETCH_CURSOR_CSINISTRO(true);

                /*" -801- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -802- SET WS-FIM-CSINISTRO TO TRUE */
                    WS_STATUS_CSINISTRO["WS_FIM_CSINISTRO"] = true;

                    /*" -804- END-IF */
                }


                /*" -804- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0120-OUTPUT-SORT */
        private void R0120_OUTPUT_SORT(bool isPerform = false)
        {
            /*" -811- PERFORM R0200-LER-SORT */

            R0200_LER_SORT(true);

            /*" -812- IF NOT WS-FIM-S0850B */

            if (!WS_STATUS_S0850B["WS_FIM_S0850B"])
            {

                /*" -813- PERFORM UNTIL WS-FIM-S0850B */

                while (!(WS_STATUS_S0850B["WS_FIM_S0850B"]))
                {

                    /*" -814- PERFORM R0210-MONTA-LINHA */

                    R0210_MONTA_LINHA(true);

                    /*" -815- PERFORM R0220-IMPRIMIR */

                    R0220_IMPRIMIR(true);

                    /*" -816- PERFORM R0222-TOTALIZACAO-PARCIAL */

                    R0222_TOTALIZACAO_PARCIAL(true);

                    /*" -817- PERFORM R0200-LER-SORT */

                    R0200_LER_SORT(true);

                    /*" -819- END-PERFORM */
                }

                /*" -820- MOVE WS-TOTAL-AVISADO TO LD02-TOTAL-AVISADO */
                _.Move(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_AVISADO, RELATORIO.LD02.LD02_TOTAL_AVISADO);

                /*" -821- MOVE WS-TOTAL-PAGO TO LD02-TOTAL-PAGO */
                _.Move(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PAGO, RELATORIO.LD02.LD02_TOTAL_PAGO);

                /*" -823- MOVE WS-TOTAL-PENDENTE TO LD02-TOTAL-PENDENTE */
                _.Move(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PENDENTE, RELATORIO.LD02.LD02_TOTAL_PENDENTE);

                /*" -824- PERFORM R0221-IMPRIMIR-TOTAL-PARCIAL */

                R0221_IMPRIMIR_TOTAL_PARCIAL(true);

                /*" -824- END-IF. */
            }


        }

        [StopWatch]
        /*" R0130-MONTA-SORT */
        private void R0130_MONTA_SORT(bool isPerform = false)
        {
            /*" -833- MOVE SINISMES-NUM-APOL-SINISTRO OF DCLSINISTRO-MESTRE TO S0850B-NUM-APOL-SINISTRO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO, REG_S0850B.S0850B_NUM_APOL_SINISTRO);

            /*" -835- MOVE SINISMES-COD-FONTE OF DCLSINISTRO-MESTRE TO S0850B-COD-FONTE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE, REG_S0850B.S0850B_COD_FONTE);

            /*" -836- MOVE FONTES-NOME-FONTE TO S0850B-NOME-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, REG_S0850B.S0850B_NOME_FONTE);

            /*" -838- MOVE SINISMES-RAMO OF DCLSINISTRO-MESTRE TO S0850B-RAMO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO, REG_S0850B.S0850B_RAMO);

            /*" -840- MOVE RAMOS-NOME-RAMO TO S0850B-NOME-RAMO */
            _.Move(RAMOS.DCLRAMOS.RAMOS_NOME_RAMO, REG_S0850B.S0850B_NOME_RAMO);

            /*" -842- MOVE SINISMES-DATA-OCORRENCIA OF DCLSINISTRO-MESTRE TO S0850B-DATA-OCORRENCIA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, REG_S0850B.S0850B_DATA_OCORRENCIA);

            /*" -844- MOVE SINISMES-DATA-COMUNICADO OF DCLSINISTRO-MESTRE TO S0850B-DATA-COMUNICADO */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO, REG_S0850B.S0850B_DATA_COMUNICADO);

            /*" -846- MOVE SINISMES-DATA-TECNICA OF DCLSINISTRO-MESTRE TO S0850B-DATA-TECNICA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA, REG_S0850B.S0850B_DATA_TECNICA);

            /*" -848- MOVE SINISMES-COD-CAUSA OF DCLSINISTRO-MESTRE TO WS-STATUS-CAUSA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, WS_STATUS_CAUSA);

            /*" -849-  EVALUATE TRUE  */

            /*" -850-  WHEN WS-PERDA-TOTAL  */

            /*" -850- IF WS-PERDA-TOTAL */

            if (WS_STATUS_CAUSA["WS_PERDA_TOTAL"])
            {

                /*" -851- IF DIAS-PENDENTES > 90 */

                if (WS_AREA_TRABALHO.DIAS_PENDENTES > 90)
                {

                    /*" -852- MOVE 10 TO S0850B-COD-TITULO */
                    _.Move(10, REG_S0850B.S0850B_COD_TITULO);

                    /*" -853- ELSE */
                }
                else
                {


                    /*" -854- MOVE 15 TO S0850B-COD-TITULO */
                    _.Move(15, REG_S0850B.S0850B_COD_TITULO);

                    /*" -855- END-IF */
                }


                /*" -856-  WHEN WS-PERDA-PARCIAL  */

                /*" -856- ELSE IF WS-PERDA-PARCIAL */
            }
            else

            if (WS_STATUS_CAUSA["WS_PERDA_PARCIAL"])
            {

                /*" -857- IF DIAS-PENDENTES > 60 */

                if (WS_AREA_TRABALHO.DIAS_PENDENTES > 60)
                {

                    /*" -858- MOVE 20 TO S0850B-COD-TITULO */
                    _.Move(20, REG_S0850B.S0850B_COD_TITULO);

                    /*" -859- ELSE */
                }
                else
                {


                    /*" -860- MOVE 25 TO S0850B-COD-TITULO */
                    _.Move(25, REG_S0850B.S0850B_COD_TITULO);

                    /*" -861- END-IF */
                }


                /*" -862-  WHEN WS-DANOS-MATERIAIS  */

                /*" -862- ELSE IF WS-DANOS-MATERIAIS */
            }
            else

            if (WS_STATUS_CAUSA["WS_DANOS_MATERIAIS"])
            {

                /*" -863- MOVE 30 TO S0850B-COD-TITULO */
                _.Move(30, REG_S0850B.S0850B_COD_TITULO);

                /*" -864-  WHEN WS-DANOS-PESSOAIS  */

                /*" -864- ELSE IF WS-DANOS-PESSOAIS */
            }
            else

            if (WS_STATUS_CAUSA["WS_DANOS_PESSOAIS"])
            {

                /*" -865- MOVE 40 TO S0850B-COD-TITULO */
                _.Move(40, REG_S0850B.S0850B_COD_TITULO);

                /*" -866-  WHEN OTHER  */

                /*" -866- ELSE */
            }
            else
            {


                /*" -867- MOVE 50 TO S0850B-COD-TITULO */
                _.Move(50, REG_S0850B.S0850B_COD_TITULO);

                /*" -869-  END-EVALUATE  */

                /*" -869- END-IF */
            }


            /*" -870- MOVE DIAS-PENDENTES TO S0850B-DIAS-PEND */
            _.Move(WS_AREA_TRABALHO.DIAS_PENDENTES, REG_S0850B.S0850B_DIAS_PEND);

            /*" -872- MOVE NOME-RAZAO OF DCLCLIENTES TO S0850B-NOME-RAZAO */
            _.Move(CLIENTE.DCLCLIENTES.NOME_RAZAO, REG_S0850B.S0850B_NOME_RAZAO);

            /*" -873- MOVE WS-VL-AVISADO TO S0850B-VALOR-AVISADO */
            _.Move(WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_AVISADO, REG_S0850B.S0850B_VALOR_AVISADO);

            /*" -874- MOVE WS-VL-PAGO TO S0850B-VALOR-PAGO */
            _.Move(WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_PAGO, REG_S0850B.S0850B_VALOR_PAGO);

            /*" -874- MOVE WS-VL-PENDENTE TO S0850B-VALOR-PENDENTE. */
            _.Move(WS_AREA_TRABALHO.WS_VALOR_AUX.WS_VL_PENDENTE, REG_S0850B.S0850B_VALOR_PENDENTE);

        }

        [StopWatch]
        /*" R0200-LER-SORT */
        private void R0200_LER_SORT(bool isPerform = false)
        {
            /*" -882- RETURN S0850B AT END */
            try
            {
                S0850B.Return(REG_S0850B, () =>
                {

                    /*" -883- SET WS-FIM-S0850B TO TRUE */
                    WS_STATUS_S0850B["WS_FIM_S0850B"] = true;

                    /*" -884- NOT AT END */
                }, () =>
                {

                    /*" -885- SET WS-BOF-S0850B TO TRUE END-RETURN. */
                    WS_STATUS_S0850B["WS_BOF_S0850B"] = true;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }

        [StopWatch]
        /*" R0210-MONTA-LINHA */
        private void R0210_MONTA_LINHA(bool isPerform = false)
        {
            /*" -892- SET WS-CABEC-IGUAL TO TRUE */
            WS_STATUS_CABEC["WS_CABEC_IGUAL"] = true;

            /*" -896- IF WS-FONTE-ANT NOT EQUAL S0850B-COD-FONTE OR WS-RAMO-ANT NOT EQUAL S0850B-RAMO OR WS-TITULO-ANT NOT EQUAL S0850B-COD-TITULO */

            if (WS_AREA_TRABALHO.WS_FONTE_ANT != REG_S0850B.S0850B_COD_FONTE || WS_AREA_TRABALHO.WS_RAMO_ANT != REG_S0850B.S0850B_RAMO || WS_AREA_TRABALHO.WS_TITULO_ANT != REG_S0850B.S0850B_COD_TITULO)
            {

                /*" -897- MOVE S0850B-COD-FONTE TO LC03-FONTE */
                _.Move(REG_S0850B.S0850B_COD_FONTE, RELATORIO.LC03.LC03_FONTE);

                /*" -898- MOVE S0850B-NOME-FONTE TO LC03-NOME-FONTE */
                _.Move(REG_S0850B.S0850B_NOME_FONTE, RELATORIO.LC03.LC03_NOME_FONTE);

                /*" -899- MOVE S0850B-RAMO TO LC04-RAMO */
                _.Move(REG_S0850B.S0850B_RAMO, RELATORIO.LC04.LC04_RAMO);

                /*" -901- MOVE S0850B-NOME-RAMO TO LC04-NOME-RAMO */
                _.Move(REG_S0850B.S0850B_NOME_RAMO, RELATORIO.LC04.LC04_NOME_RAMO);

                /*" -903- ADD 1 TO WS-INDEX */
                RELATORIO.LINHA_RESUMO.WS_INDEX.Value = RELATORIO.LINHA_RESUMO.WS_INDEX + 1;

                /*" -904- EVALUATE S0850B-COD-TITULO */
                switch (REG_S0850B.S0850B_COD_TITULO.Value)
                {

                    /*" -906- WHEN 10 */
                    case 10:

                        /*" -909- MOVE '  PERDA TOTAL - SUPERIOR A 90 DIAS EM 99/99/9999' TO LC03-TITULO */
                        _.Move("  PERDA TOTAL - SUPERIOR A 90 DIAS EM 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -910- MOVE WS-DATA-AUX TO LC03-TITULO(39:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 39, 10);

                        /*" -911- WHEN 15 */
                        break;
                    case 15:

                        /*" -914- MOVE '      PERDA TOTAL - ATE 90 DIAS EM 99/99/9999' TO LC03-TITULO */
                        _.Move("      PERDA TOTAL - ATE 90 DIAS EM 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -915- MOVE WS-DATA-AUX TO LC03-TITULO(36:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 36, 10);

                        /*" -916- WHEN 20 */
                        break;
                    case 20:

                        /*" -919- MOVE ' PERDA PARCIAL - SUPERIOR A 60 DIAS EM 99/99/9999' TO LC03-TITULO */
                        _.Move(" PERDA PARCIAL - SUPERIOR A 60 DIAS EM 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -920- MOVE WS-DATA-AUX TO LC03-TITULO(40:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 40, 10);

                        /*" -922- WHEN 25 */
                        break;
                    case 25:

                        /*" -925- MOVE '     PERDA PARCIAL - ATE 60 DIAS EM 99/99/9999' TO LC03-TITULO */
                        _.Move("     PERDA PARCIAL - ATE 60 DIAS EM 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -926- MOVE WS-DATA-AUX TO LC03-TITULO(37:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 37, 10);

                        /*" -927- WHEN 30 */
                        break;
                    case 30:

                        /*" -930- MOVE '         DANOS MATERIAIS - ATE 99/99/9999' TO LC03-TITULO */
                        _.Move("         DANOS MATERIAIS - ATE 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -931- MOVE WS-DATA-AUX TO LC03-TITULO(32:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 32, 10);

                        /*" -932- WHEN 40 */
                        break;
                    case 40:

                        /*" -935- MOVE '         DANOS PESSOAIS - ATE 99/99/9999' TO LC03-TITULO */
                        _.Move("         DANOS PESSOAIS - ATE 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -936- MOVE WS-DATA-AUX TO LC03-TITULO(31:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 31, 10);

                        /*" -937- WHEN 50 */
                        break;
                    case 50:

                        /*" -940- MOVE '             PESSOA - ATE 99/99/9999' TO LC03-TITULO */
                        _.Move("             PESSOA - ATE 99/99/9999", RELATORIO.LC03.LC03_TITULO);

                        /*" -942- MOVE WS-DATA-AUX TO LC03-TITULO(27:10) */
                        _.MoveAtPosition(WS_AREA_TRABALHO.WS_DATA_AUX, RELATORIO.LC03.LC03_TITULO, 27, 10);

                        /*" -944- END-EVALUATE */
                        break;
                }


                /*" -945- MOVE S0850B-COD-FONTE TO WS-FONTE-ANT */
                _.Move(REG_S0850B.S0850B_COD_FONTE, WS_AREA_TRABALHO.WS_FONTE_ANT);

                /*" -946- MOVE S0850B-RAMO TO WS-RAMO-ANT */
                _.Move(REG_S0850B.S0850B_RAMO, WS_AREA_TRABALHO.WS_RAMO_ANT);

                /*" -948- MOVE S0850B-COD-TITULO TO WS-TITULO-ANT */
                _.Move(REG_S0850B.S0850B_COD_TITULO, WS_AREA_TRABALHO.WS_TITULO_ANT);

                /*" -950- SET WS-CABEC-MODIFICADO TO TRUE */
                WS_STATUS_CABEC["WS_CABEC_MODIFICADO"] = true;

                /*" -951- MOVE WS-TOTAL-AVISADO TO LD02-TOTAL-AVISADO */
                _.Move(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_AVISADO, RELATORIO.LD02.LD02_TOTAL_AVISADO);

                /*" -952- MOVE WS-TOTAL-PAGO TO LD02-TOTAL-PAGO */
                _.Move(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PAGO, RELATORIO.LD02.LD02_TOTAL_PAGO);

                /*" -953- MOVE WS-TOTAL-PENDENTE TO LD02-TOTAL-PENDENTE */
                _.Move(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PENDENTE, RELATORIO.LD02.LD02_TOTAL_PENDENTE);

                /*" -955- END-IF */
            }


            /*" -957- MOVE S0850B-NUM-APOL-SINISTRO TO LD01-NUM-APOL-SINISTRO */
            _.Move(REG_S0850B.S0850B_NUM_APOL_SINISTRO, RELATORIO.LD01.LD01_NUM_APOL_SINISTRO);

            /*" -958- MOVE S0850B-DATA-OCORRENCIA(9:2) TO LD01-DD-DT-OCORR */
            _.Move(REG_S0850B.S0850B_DATA_OCORRENCIA.Substring(9, 2), RELATORIO.LD01.LD01_DATA_OCORRENCIA.LD01_DD_DT_OCORR);

            /*" -959- MOVE S0850B-DATA-OCORRENCIA(6:2) TO LD01-MM-DT-OCORR */
            _.Move(REG_S0850B.S0850B_DATA_OCORRENCIA.Substring(6, 2), RELATORIO.LD01.LD01_DATA_OCORRENCIA.LD01_MM_DT_OCORR);

            /*" -961- MOVE S0850B-DATA-OCORRENCIA(1:4) TO LD01-AA-DT-OCORR */
            _.Move(REG_S0850B.S0850B_DATA_OCORRENCIA.Substring(1, 4), RELATORIO.LD01.LD01_DATA_OCORRENCIA.LD01_AA_DT_OCORR);

            /*" -962- MOVE S0850B-DATA-COMUNICADO(9:2) TO LD01-DD-DT-COMUN */
            _.Move(REG_S0850B.S0850B_DATA_COMUNICADO.Substring(9, 2), RELATORIO.LD01.LD01_DATA_COMUNICADO.LD01_DD_DT_COMUN);

            /*" -963- MOVE S0850B-DATA-COMUNICADO(6:2) TO LD01-MM-DT-COMUN */
            _.Move(REG_S0850B.S0850B_DATA_COMUNICADO.Substring(6, 2), RELATORIO.LD01.LD01_DATA_COMUNICADO.LD01_MM_DT_COMUN);

            /*" -965- MOVE S0850B-DATA-COMUNICADO(1:4) TO LD01-AA-DT-COMUN */
            _.Move(REG_S0850B.S0850B_DATA_COMUNICADO.Substring(1, 4), RELATORIO.LD01.LD01_DATA_COMUNICADO.LD01_AA_DT_COMUN);

            /*" -966- MOVE S0850B-DATA-TECNICA(9:2) TO LD01-DD-DT-TEC */
            _.Move(REG_S0850B.S0850B_DATA_TECNICA.Substring(9, 2), RELATORIO.LD01.LD01_DATA_TECNICA.LD01_DD_DT_TEC);

            /*" -967- MOVE S0850B-DATA-TECNICA(6:2) TO LD01-MM-DT-TEC */
            _.Move(REG_S0850B.S0850B_DATA_TECNICA.Substring(6, 2), RELATORIO.LD01.LD01_DATA_TECNICA.LD01_MM_DT_TEC);

            /*" -969- MOVE S0850B-DATA-TECNICA(1:4) TO LD01-AA-DT-TEC */
            _.Move(REG_S0850B.S0850B_DATA_TECNICA.Substring(1, 4), RELATORIO.LD01.LD01_DATA_TECNICA.LD01_AA_DT_TEC);

            /*" -970- MOVE S0850B-DIAS-PEND TO LD01-DIAS-PEND */
            _.Move(REG_S0850B.S0850B_DIAS_PEND, RELATORIO.LD01.LD01_DIAS_PEND);

            /*" -971- MOVE S0850B-NOME-RAZAO TO LD01-NOME-RAZAO */
            _.Move(REG_S0850B.S0850B_NOME_RAZAO, RELATORIO.LD01.LD01_NOME_RAZAO);

            /*" -972- MOVE S0850B-VALOR-AVISADO TO LD01-VALOR-AVISADO */
            _.Move(REG_S0850B.S0850B_VALOR_AVISADO, RELATORIO.LD01.LD01_VALOR_AVISADO);

            /*" -973- MOVE S0850B-VALOR-PAGO TO LD01-VALOR-PAGO */
            _.Move(REG_S0850B.S0850B_VALOR_PAGO, RELATORIO.LD01.LD01_VALOR_PAGO);

            /*" -975- MOVE S0850B-VALOR-PENDENTE TO LD01-VALOR-PENDENTE */
            _.Move(REG_S0850B.S0850B_VALOR_PENDENTE, RELATORIO.LD01.LD01_VALOR_PENDENTE);

            /*" -976- MOVE S0850B-COD-FONTE TO LC03-FONTE */
            _.Move(REG_S0850B.S0850B_COD_FONTE, RELATORIO.LC03.LC03_FONTE);

            /*" -978- MOVE S0850B-NOME-FONTE TO LC03-NOME-FONTE */
            _.Move(REG_S0850B.S0850B_NOME_FONTE, RELATORIO.LC03.LC03_NOME_FONTE);

            /*" -979- MOVE S0850B-RAMO TO LC04-RAMO */
            _.Move(REG_S0850B.S0850B_RAMO, RELATORIO.LC04.LC04_RAMO);

            /*" -979- MOVE S0850B-NOME-RAMO TO LC04-NOME-RAMO. */
            _.Move(REG_S0850B.S0850B_NOME_RAMO, RELATORIO.LC04.LC04_NOME_RAMO);

        }

        [StopWatch]
        /*" R0220-IMPRIMIR */
        private void R0220_IMPRIMIR(bool isPerform = false)
        {
            /*" -998- IF AC-LINHAS GREATER 57 OR WS-CABEC-MODIFICADO */

            if (WS_AREA_TRABALHO.AC_LINHAS > 57 || WS_STATUS_CABEC["WS_CABEC_MODIFICADO"])
            {

                /*" -1002- IF NOT (WS-TOTAL-AVISADO EQUAL ZEROS AND WS-TOTAL-PAGO EQUAL ZEROS AND WS-TOTAL-PENDENTE EQUAL ZEROS) AND WS-CABEC-MODIFICADO */

                if (!(WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_AVISADO == 00 && WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PAGO == 00 && WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PENDENTE == 00) && WS_STATUS_CABEC["WS_CABEC_MODIFICADO"])
                {

                    /*" -1003- PERFORM R0221-IMPRIMIR-TOTAL-PARCIAL */

                    R0221_IMPRIMIR_TOTAL_PARCIAL(true);

                    /*" -1004- INITIALIZE WS-CONTADORES */
                    _.Initialize(
                        WS_AREA_TRABALHO.WS_CONTADORES
                    );

                    /*" -1005- END-IF */
                }


                /*" -1006- PERFORM R0230-IMPRIMIR-CABECALHO */

                R0230_IMPRIMIR_CABECALHO(true);

                /*" -1008- END-IF */
            }


            /*" -1009- WRITE REG-SI0850B FROM LD01 AFTER 1 */
            _.Move(RELATORIO.LD01.GetMoveValues(), REG_SI0850B);

            RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

            /*" -1009- ADD 1 TO AC-LINHAS. */
            WS_AREA_TRABALHO.AC_LINHAS.Value = WS_AREA_TRABALHO.AC_LINHAS + 1;

        }

        [StopWatch]
        /*" R0221-IMPRIMIR-TOTAL-PARCIAL */
        private void R0221_IMPRIMIR_TOTAL_PARCIAL(bool isPerform = false)
        {
            /*" -1016- WRITE REG-SI0850B FROM LD02-TRACO AFTER 2 */
            _.Move(RELATORIO.LD02_TRACO.GetMoveValues(), REG_SI0850B);

            RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

            /*" -1017- WRITE REG-SI0850B FROM LD02 AFTER 1 */
            _.Move(RELATORIO.LD02.GetMoveValues(), REG_SI0850B);

            RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

            /*" -1017- ADD 3 TO AC-LINHAS. */
            WS_AREA_TRABALHO.AC_LINHAS.Value = WS_AREA_TRABALHO.AC_LINHAS + 3;

        }

        [StopWatch]
        /*" R0222-TOTALIZACAO-PARCIAL */
        private void R0222_TOTALIZACAO_PARCIAL(bool isPerform = false)
        {
            /*" -1025- COMPUTE WS-TOTAL-AVISADO = WS-TOTAL-AVISADO + S0850B-VALOR-AVISADO */
            WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_AVISADO.Value = WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_AVISADO + REG_S0850B.S0850B_VALOR_AVISADO;

            /*" -1027- COMPUTE WS-TOTAL-PAGO = WS-TOTAL-PAGO + S0850B-VALOR-PAGO */
            WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PAGO.Value = WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PAGO + REG_S0850B.S0850B_VALOR_PAGO;

            /*" -1030- COMPUTE WS-TOTAL-PENDENTE = WS-TOTAL-PENDENTE + S0850B-VALOR-PENDENTE */
            WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PENDENTE.Value = WS_AREA_TRABALHO.WS_CONTADORES.WS_TOTAL_PENDENTE + REG_S0850B.S0850B_VALOR_PENDENTE;

            /*" -1031- MOVE S0850B-RAMO TO WS-TT-RAMO(WS-INDEX) */
            _.Move(REG_S0850B.S0850B_RAMO, RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_RAMO);

            /*" -1032- MOVE S0850B-COD-FONTE TO WS-TT-FONTE(WS-INDEX) */
            _.Move(REG_S0850B.S0850B_COD_FONTE, RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_FONTE);

            /*" -1033- MOVE S0850B-NOME-FONTE TO WS-TT-NOME-FONTE(WS-INDEX) */
            _.Move(REG_S0850B.S0850B_NOME_FONTE, RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_NOME_FONTE);

            /*" -1035- MOVE S0850B-COD-TITULO TO WS-TT-TIPO-TITULO(WS-INDEX) */
            _.Move(REG_S0850B.S0850B_COD_TITULO, RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_TIPO_TITULO);

            /*" -1037- COMPUTE WS-TT-AVISADO(WS-INDEX) = WS-TT-AVISADO(WS-INDEX) + S0850B-VALOR-AVISADO */
            RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_AVISADO.Value = RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_AVISADO.Value + REG_S0850B.S0850B_VALOR_AVISADO;

            /*" -1039- COMPUTE WS-TT-PAGO(WS-INDEX) = WS-TT-PAGO(WS-INDEX) + S0850B-VALOR-PAGO */
            RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_PAGO.Value = RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_PAGO.Value + REG_S0850B.S0850B_VALOR_PAGO;

            /*" -1040- COMPUTE WS-TT-PENDENTE(WS-INDEX) = WS-TT-PENDENTE(WS-INDEX) + S0850B-VALOR-PENDENTE. */
            RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_PENDENTE.Value = RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_INDEX].WS_TT_PENDENTE.Value + REG_S0850B.S0850B_VALOR_PENDENTE;

        }

        [StopWatch]
        /*" R0224-RESUMO-SORT */
        private void R0224_RESUMO_SORT(bool isPerform = false)
        {
            /*" -1050- SORT S0850B ON ASCENDING KEY S0850B-RAMO ASCENDING KEY S0850B-COD-TITULO ASCENDING KEY S0850B-COD-FONTE INPUT PROCEDURE R0225-INPUT-RESUMO-SORT OUTPUT PROCEDURE R0226-OUTPUT-RESUMO-SORT. */
            SORT_RETURN.Value = S0850B.Sort("S0850B-RAMO,ASCENDING,KEY,S0850B-COD-TITULO,ASCENDING,KEY,S0850B-COD-FONTE", () => R0225_INPUT_RESUMO_SORT(true), () => R0226_OUTPUT_RESUMO_SORT(true));

            /*" -1054- IF SORT-RETURN EQUAL ZEROS NEXT SENTENCE */

            if (SORT_RETURN == 00)
            {

                /*" -1055- ELSE */
            }
            else
            {


                /*" -1056- DISPLAY 'R0224 - ERRO NO SORT INTERNO PROGRAMA SI0850B' */
                _.Display($"R0224 - ERRO NO SORT INTERNO PROGRAMA SI0850B");

                /*" -1057- DISPLAY 'SORT RETURN = ' SORT-RETURN */
                _.Display($"SORT RETURN = {SORT_RETURN}");

                /*" -1058- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1058- END-IF. */
            }


        }

        [StopWatch]
        /*" R0225-INPUT-RESUMO-SORT */
        private void R0225_INPUT_RESUMO_SORT(bool isPerform = false)
        {
            /*" -1065- PERFORM VARYING WS-IND FROM 1 BY 1 UNTIL WS-IND > WS-INDEX */

            for (RELATORIO.LINHA_RESUMO.WS_IND.Value = 1; !(RELATORIO.LINHA_RESUMO.WS_IND > RELATORIO.LINHA_RESUMO.WS_INDEX); RELATORIO.LINHA_RESUMO.WS_IND.Value += 1)
            {

                /*" -1066- MOVE WS-TT-TIPO-TITULO(WS-IND) TO S0850B-COD-TITULO */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_TIPO_TITULO, REG_S0850B.S0850B_COD_TITULO);

                /*" -1067- MOVE WS-TT-RAMO(WS-IND) TO S0850B-RAMO */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_RAMO, REG_S0850B.S0850B_RAMO);

                /*" -1068- MOVE WS-TT-FONTE(WS-IND) TO S0850B-COD-FONTE */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_FONTE, REG_S0850B.S0850B_COD_FONTE);

                /*" -1069- MOVE WS-TT-NOME-FONTE(WS-IND) TO S0850B-NOME-FONTE */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_NOME_FONTE, REG_S0850B.S0850B_NOME_FONTE);

                /*" -1070- MOVE WS-TT-AVISADO(WS-IND) TO S0850B-VALOR-AVISADO */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_AVISADO, REG_S0850B.S0850B_VALOR_AVISADO);

                /*" -1071- MOVE WS-TT-PAGO(WS-IND) TO S0850B-VALOR-PAGO */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_PAGO, REG_S0850B.S0850B_VALOR_PAGO);

                /*" -1073- MOVE WS-TT-PENDENTE(WS-IND) TO S0850B-VALOR-PENDENTE */
                _.Move(RELATORIO.LINHA_RESUMO.WS_TOTAL_TIPOS[RELATORIO.LINHA_RESUMO.WS_IND].WS_TT_PENDENTE, REG_S0850B.S0850B_VALOR_PENDENTE);

                /*" -1074- RELEASE REG-S0850B */
                S0850B.Release(REG_S0850B);

                /*" -1074- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0226-OUTPUT-RESUMO-SORT */
        private void R0226_OUTPUT_RESUMO_SORT(bool isPerform = false)
        {
            /*" -1083- MOVE '                   R E S U M O' TO LC03-TITULO */
            _.Move("                   R E S U M O", RELATORIO.LC03.LC03_TITULO);

            /*" -1085- PERFORM R0230-IMPRIMIR-CABECALHO */

            R0230_IMPRIMIR_CABECALHO(true);

            /*" -1086- PERFORM R0200-LER-SORT */

            R0200_LER_SORT(true);

            /*" -1087- IF NOT WS-FIM-S0850B */

            if (!WS_STATUS_S0850B["WS_FIM_S0850B"])
            {

                /*" -1088- MOVE S0850B-RAMO TO WS-RAMO-ANT */
                _.Move(REG_S0850B.S0850B_RAMO, WS_AREA_TRABALHO.WS_RAMO_ANT);

                /*" -1090- MOVE S0850B-COD-TITULO TO WS-TITULO-ANT */
                _.Move(REG_S0850B.S0850B_COD_TITULO, WS_AREA_TRABALHO.WS_TITULO_ANT);

                /*" -1092- PERFORM UNTIL WS-FIM-S0850B */

                while (!(WS_STATUS_S0850B["WS_FIM_S0850B"]))
                {

                    /*" -1093- IF AC-LINHAS GREATER 57 */

                    if (WS_AREA_TRABALHO.AC_LINHAS > 57)
                    {

                        /*" -1094- PERFORM R0230-IMPRIMIR-CABECALHO */

                        R0230_IMPRIMIR_CABECALHO(true);

                        /*" -1098- END-IF */
                    }


                    /*" -1100- COMPUTE WS-TP-AVISADO = WS-TP-AVISADO + S0850B-VALOR-AVISADO */
                    WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_AVISADO.Value = WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_AVISADO + REG_S0850B.S0850B_VALOR_AVISADO;

                    /*" -1102- COMPUTE WS-TP-PAGO = WS-TP-PAGO + S0850B-VALOR-PAGO */
                    WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PAGO.Value = WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PAGO + REG_S0850B.S0850B_VALOR_PAGO;

                    /*" -1105- COMPUTE WS-TP-PENDENTE = WS-TP-PENDENTE + S0850B-VALOR-PENDENTE */
                    WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PENDENTE.Value = WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PENDENTE + REG_S0850B.S0850B_VALOR_PENDENTE;

                    /*" -1106- EVALUATE S0850B-COD-TITULO */
                    switch (REG_S0850B.S0850B_COD_TITULO.Value)
                    {

                        /*" -1107- WHEN 10 */
                        case 10:

                            /*" -1108- MOVE 'SUPERIOR A 90 DIAS' TO LR02-CLASSIFICACAO */
                            _.Move("SUPERIOR A 90 DIAS", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1109- MOVE 'PERDA TOTAL' TO LR02-TIPO */
                            _.Move("PERDA TOTAL", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1110- WHEN 15 */
                            break;
                        case 15:

                            /*" -1111- MOVE 'ATE 90 DIAS' TO LR02-CLASSIFICACAO */
                            _.Move("ATE 90 DIAS", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1112- MOVE 'PERDA TOTAL' TO LR02-TIPO */
                            _.Move("PERDA TOTAL", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1113- WHEN 20 */
                            break;
                        case 20:

                            /*" -1114- MOVE 'SUPERIOR A 60 DIAS' TO LR02-CLASSIFICACAO */
                            _.Move("SUPERIOR A 60 DIAS", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1115- MOVE 'PERDA PARCIAL' TO LR02-TIPO */
                            _.Move("PERDA PARCIAL", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1116- WHEN 25 */
                            break;
                        case 25:

                            /*" -1117- MOVE 'ATE 60 DIAS' TO LR02-CLASSIFICACAO */
                            _.Move("ATE 60 DIAS", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1118- MOVE 'PERDA PARCIAL' TO LR02-TIPO */
                            _.Move("PERDA PARCIAL", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1119- WHEN 30 */
                            break;
                        case 30:

                            /*" -1120- MOVE 'TODOS PENDENTES' TO LR02-CLASSIFICACAO */
                            _.Move("TODOS PENDENTES", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1121- MOVE 'DANOS MATERIAIS' TO LR02-TIPO */
                            _.Move("DANOS MATERIAIS", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1122- WHEN 40 */
                            break;
                        case 40:

                            /*" -1123- MOVE 'TODOS PENDENTES' TO LR02-CLASSIFICACAO */
                            _.Move("TODOS PENDENTES", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1124- MOVE 'DANOS PESSOAIS' TO LR02-TIPO */
                            _.Move("DANOS PESSOAIS", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1125- WHEN 50 */
                            break;
                        case 50:

                            /*" -1126- MOVE 'TODOS PENDENTES' TO LR02-CLASSIFICACAO */
                            _.Move("TODOS PENDENTES", RELATORIO.LINHA_RESUMO.LR02.LR02_CLASSIFICACAO);

                            /*" -1127- MOVE 'PESSOA' TO LR02-TIPO */
                            _.Move("PESSOA", RELATORIO.LINHA_RESUMO.LR02.LR02_TIPO);

                            /*" -1129- END-EVALUATE */
                            break;
                    }


                    /*" -1130- MOVE S0850B-RAMO TO LR02-RAMO */
                    _.Move(REG_S0850B.S0850B_RAMO, RELATORIO.LINHA_RESUMO.LR02.LR02_RAMO);

                    /*" -1131- MOVE S0850B-COD-FONTE TO LR02-FONTE */
                    _.Move(REG_S0850B.S0850B_COD_FONTE, RELATORIO.LINHA_RESUMO.LR02.LR02_FONTE);

                    /*" -1132- MOVE S0850B-NOME-FONTE TO LR02-NOME-FONTE */
                    _.Move(REG_S0850B.S0850B_NOME_FONTE, RELATORIO.LINHA_RESUMO.LR02.LR02_NOME_FONTE);

                    /*" -1133- MOVE S0850B-VALOR-AVISADO TO LR02-AVISADO */
                    _.Move(REG_S0850B.S0850B_VALOR_AVISADO, RELATORIO.LINHA_RESUMO.LR02.LR02_AVISADO);

                    /*" -1134- MOVE S0850B-VALOR-PAGO TO LR02-PAGO */
                    _.Move(REG_S0850B.S0850B_VALOR_PAGO, RELATORIO.LINHA_RESUMO.LR02.LR02_PAGO);

                    /*" -1136- MOVE S0850B-VALOR-PENDENTE TO LR02-PENDENTE */
                    _.Move(REG_S0850B.S0850B_VALOR_PENDENTE, RELATORIO.LINHA_RESUMO.LR02.LR02_PENDENTE);

                    /*" -1137- WRITE REG-SI0850B FROM LR02 AFTER 1 */
                    _.Move(RELATORIO.LINHA_RESUMO.LR02.GetMoveValues(), REG_SI0850B);

                    RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                    /*" -1139- ADD 1 TO AC-LINHAS */
                    WS_AREA_TRABALHO.AC_LINHAS.Value = WS_AREA_TRABALHO.AC_LINHAS + 1;

                    /*" -1140- PERFORM R0200-LER-SORT */

                    R0200_LER_SORT(true);

                    /*" -1146- IF WS-FIM-S0850B OR S0850B-RAMO NOT EQUAL WS-RAMO-ANT OR S0850B-COD-TITULO NOT EQUAL WS-TITULO-ANT */

                    if (WS_STATUS_S0850B["WS_FIM_S0850B"] || REG_S0850B.S0850B_RAMO != WS_AREA_TRABALHO.WS_RAMO_ANT || REG_S0850B.S0850B_COD_TITULO != WS_AREA_TRABALHO.WS_TITULO_ANT)
                    {

                        /*" -1148- COMPUTE WS-TG-AVISADO = WS-TG-AVISADO + WS-TP-AVISADO */
                        WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_AVISADO.Value = WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_AVISADO + WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_AVISADO;

                        /*" -1150- COMPUTE WS-TG-PAGO = WS-TG-PAGO + WS-TP-PAGO */
                        WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_PAGO.Value = WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_PAGO + WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PAGO;

                        /*" -1153- COMPUTE WS-TG-PENDENTE = WS-TG-PENDENTE + WS-TP-PENDENTE */
                        WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_PENDENTE.Value = WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_PENDENTE + WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PENDENTE;

                        /*" -1154- MOVE 'TOTAL ............: ' TO LR03-TITULO */
                        _.Move("TOTAL ............: ", RELATORIO.LINHA_RESUMO.LR03.LR03_TITULO);

                        /*" -1155- MOVE WS-TP-AVISADO TO LR03-TG-AVISADO */
                        _.Move(WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_AVISADO, RELATORIO.LINHA_RESUMO.LR03.LR03_TG_AVISADO);

                        /*" -1156- MOVE WS-TP-PAGO TO LR03-TG-PAGO */
                        _.Move(WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PAGO, RELATORIO.LINHA_RESUMO.LR03.LR03_TG_PAGO);

                        /*" -1158- MOVE WS-TP-PENDENTE TO LR03-TG-PENDENTE */
                        _.Move(WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL.WS_TP_PENDENTE, RELATORIO.LINHA_RESUMO.LR03.LR03_TG_PENDENTE);

                        /*" -1159- WRITE REG-SI0850B FROM LR03-TRACO AFTER 1 */
                        _.Move(RELATORIO.LINHA_RESUMO.LR03_TRACO.GetMoveValues(), REG_SI0850B);

                        RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                        /*" -1160- WRITE REG-SI0850B FROM LR03 AFTER 1 */
                        _.Move(RELATORIO.LINHA_RESUMO.LR03.GetMoveValues(), REG_SI0850B);

                        RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                        /*" -1161- WRITE REG-SI0850B FROM BRANCO AFTER 1 */
                        _.Move(RELATORIO.BRANCO.GetMoveValues(), REG_SI0850B);

                        RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                        /*" -1163- ADD 3 TO AC-LINHAS */
                        WS_AREA_TRABALHO.AC_LINHAS.Value = WS_AREA_TRABALHO.AC_LINHAS + 3;

                        /*" -1164- MOVE S0850B-RAMO TO WS-RAMO-ANT */
                        _.Move(REG_S0850B.S0850B_RAMO, WS_AREA_TRABALHO.WS_RAMO_ANT);

                        /*" -1166- MOVE S0850B-COD-TITULO TO WS-TITULO-ANT */
                        _.Move(REG_S0850B.S0850B_COD_TITULO, WS_AREA_TRABALHO.WS_TITULO_ANT);

                        /*" -1167- INITIALIZE WS-TOTAL-GERAL-PARCIAL */
                        _.Initialize(
                            WS_AREA_TRABALHO.WS_TOTAL_GERAL_PARCIAL
                        );

                        /*" -1168- END-IF */
                    }


                    /*" -1170- END-PERFORM */
                }

                /*" -1171- MOVE 'TOTAL GERAL ......: ' TO LR03-TITULO */
                _.Move("TOTAL GERAL ......: ", RELATORIO.LINHA_RESUMO.LR03.LR03_TITULO);

                /*" -1172- MOVE WS-TG-AVISADO TO LR03-TG-AVISADO */
                _.Move(WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_AVISADO, RELATORIO.LINHA_RESUMO.LR03.LR03_TG_AVISADO);

                /*" -1173- MOVE WS-TG-PAGO TO LR03-TG-PAGO */
                _.Move(WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_PAGO, RELATORIO.LINHA_RESUMO.LR03.LR03_TG_PAGO);

                /*" -1175- MOVE WS-TG-PENDENTE TO LR03-TG-PENDENTE */
                _.Move(WS_AREA_TRABALHO.WS_TOTAL_GERAL.WS_TG_PENDENTE, RELATORIO.LINHA_RESUMO.LR03.LR03_TG_PENDENTE);

                /*" -1176- WRITE REG-SI0850B FROM LR03-TRACO AFTER 2 */
                _.Move(RELATORIO.LINHA_RESUMO.LR03_TRACO.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1177- WRITE REG-SI0850B FROM LR03 AFTER 1 */
                _.Move(RELATORIO.LINHA_RESUMO.LR03.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1178- ADD 3 TO AC-LINHAS */
                WS_AREA_TRABALHO.AC_LINHAS.Value = WS_AREA_TRABALHO.AC_LINHAS + 3;

                /*" -1178- END-IF. */
            }


        }

        [StopWatch]
        /*" R0230-IMPRIMIR-CABECALHO */
        private void R0230_IMPRIMIR_CABECALHO(bool isPerform = false)
        {
            /*" -1185- ADD 1 TO AC-FOLHAS */
            WS_AREA_TRABALHO.AC_FOLHAS.Value = WS_AREA_TRABALHO.AC_FOLHAS + 1;

            /*" -1187- MOVE AC-FOLHAS TO LC01-FOLHA */
            _.Move(WS_AREA_TRABALHO.AC_FOLHAS, RELATORIO.LC01.LC01_FOLHA);

            /*" -1188- WRITE REG-SI0850B FROM LC01 AFTER NEW-PAGE */
            _.Move(RELATORIO.LC01.GetMoveValues(), REG_SI0850B);

            RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

            /*" -1190- WRITE REG-SI0850B FROM LC02 AFTER 1 */
            _.Move(RELATORIO.LC02.GetMoveValues(), REG_SI0850B);

            RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

            /*" -1191- IF NOT WS-FIM-S0850B */

            if (!WS_STATUS_S0850B["WS_FIM_S0850B"])
            {

                /*" -1192- MOVE 07 TO AC-LINHAS */
                _.Move(07, WS_AREA_TRABALHO.AC_LINHAS);

                /*" -1193- WRITE REG-SI0850B FROM LC03 AFTER 1 */
                _.Move(RELATORIO.LC03.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1194- WRITE REG-SI0850B FROM TRACO AFTER 1 */
                _.Move(RELATORIO.TRACO.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1195- WRITE REG-SI0850B FROM LC04 AFTER 1 */
                _.Move(RELATORIO.LC04.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1196- WRITE REG-SI0850B FROM TRACO AFTER 1 */
                _.Move(RELATORIO.TRACO.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1197- WRITE REG-SI0850B FROM LC05 AFTER 1 */
                _.Move(RELATORIO.LC05.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1198- ELSE */
            }
            else
            {


                /*" -1199- MOVE 05 TO AC-LINHAS */
                _.Move(05, WS_AREA_TRABALHO.AC_LINHAS);

                /*" -1200- MOVE SPACES TO LC03-FONTE-CAPTION */
                _.Move("", RELATORIO.LC03.LC03_FONTE_CAPTION);

                /*" -1201- MOVE ZEROS TO LC03-FONTE */
                _.Move(0, RELATORIO.LC03.LC03_FONTE);

                /*" -1202- MOVE SPACES TO LC03-TRACO01 */
                _.Move("", RELATORIO.LC03.LC03_TRACO01);

                /*" -1203- MOVE SPACES TO LC03-NOME-FONTE */
                _.Move("", RELATORIO.LC03.LC03_NOME_FONTE);

                /*" -1204- WRITE REG-SI0850B FROM LC03 AFTER 1 */
                _.Move(RELATORIO.LC03.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1205- WRITE REG-SI0850B FROM TRACO AFTER 1 */
                _.Move(RELATORIO.TRACO.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1206- WRITE REG-SI0850B FROM LR01 AFTER 1 */
                _.Move(RELATORIO.LINHA_RESUMO.LR01.GetMoveValues(), REG_SI0850B);

                RSI0850B.Write(REG_SI0850B.GetMoveValues().ToString());

                /*" -1206- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-ABRIR-CURSOR-CSINISTRO */
        private void R1010_ABRIR_CURSOR_CSINISTRO(bool isPerform = false)
        {
            /*" -1213- MOVE 'R1010' TO PARAGRAFO */
            _.Move("R1010", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1213- PERFORM R1010_ABRIR_CURSOR_CSINISTRO_DB_OPEN_1 */

            R1010_ABRIR_CURSOR_CSINISTRO_DB_OPEN_1();

            /*" -1216- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1217- MOVE 'SI0850B - ERRO DECLARE CSINISTRO' TO WS-MSG-ERRO */
                _.Move("SI0850B - ERRO DECLARE CSINISTRO", WS_MSG_ERRO);

                /*" -1218- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1218- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-ABRIR-CURSOR-CSINISTRO-DB-OPEN-1 */
        public void R1010_ABRIR_CURSOR_CSINISTRO_DB_OPEN_1()
        {
            /*" -1213- EXEC SQL OPEN CSINISTRO END-EXEC */

            CSINISTRO.Open();

        }

        [StopWatch]
        /*" R1020-FETCH-CURSOR-CSINISTRO */
        private void R1020_FETCH_CURSOR_CSINISTRO(bool isPerform = false)
        {
            /*" -1226- MOVE 'R1020' TO PARAGRAFO */
            _.Move("R1020", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1237- PERFORM R1020_FETCH_CURSOR_CSINISTRO_DB_FETCH_1 */

            R1020_FETCH_CURSOR_CSINISTRO_DB_FETCH_1();

            /*" -1241- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL +100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != +100)
            {

                /*" -1242- MOVE 'SI0850B - ERRO FETCH CSINISTRO' TO WS-MSG-ERRO */
                _.Move("SI0850B - ERRO FETCH CSINISTRO", WS_MSG_ERRO);

                /*" -1243- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1243- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-FETCH-CURSOR-CSINISTRO-DB-FETCH-1 */
        public void R1020_FETCH_CURSOR_CSINISTRO_DB_FETCH_1()
        {
            /*" -1237- EXEC SQL FETCH CSINISTRO INTO :SINISMES-NUM-APOL-SINISTRO, :SINISMES-COD-FONTE, :SINISMES-RAMO, :SINISMES-DATA-OCORRENCIA, :SINISMES-DATA-COMUNICADO, :SINISMES-DATA-TECNICA, :SINISMES-COD-CAUSA, :DIAS-PENDENTES, :DCLCLIENTES.NOME-RAZAO, :WS-DATE-AMP END-EXEC */

            if (CSINISTRO.Fetch())
            {
                _.Move(CSINISTRO.SINISMES_NUM_APOL_SINISTRO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO);
                _.Move(CSINISTRO.SINISMES_COD_FONTE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE);
                _.Move(CSINISTRO.SINISMES_RAMO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO);
                _.Move(CSINISTRO.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CSINISTRO.SINISMES_DATA_COMUNICADO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO);
                _.Move(CSINISTRO.SINISMES_DATA_TECNICA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA);
                _.Move(CSINISTRO.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(CSINISTRO.DIAS_PENDENTES, WS_AREA_TRABALHO.DIAS_PENDENTES);
                _.Move(CSINISTRO.DCLCLIENTES_NOME_RAZAO, CLIENTE.DCLCLIENTES.NOME_RAZAO);
                _.Move(CSINISTRO.WS_DATE_AMP, WS_AREA_TRABALHO.WS_DATE_AMP);
            }

        }

        [StopWatch]
        /*" R1070-ENCONTRAR-FONTE */
        private void R1070_ENCONTRAR_FONTE(bool isPerform = false)
        {
            /*" -1251- MOVE 'R1070' TO PARAGRAFO */
            _.Move("R1070", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1255- PERFORM R1070_ENCONTRAR_FONTE_DB_SELECT_1 */

            R1070_ENCONTRAR_FONTE_DB_SELECT_1();

            /*" -1258- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1260- MOVE 'SI0850B - ERRO NO SELECT(FONTE)' TO WS-MSG-ERRO */
                _.Move("SI0850B - ERRO NO SELECT(FONTE)", WS_MSG_ERRO);

                /*" -1261- DISPLAY '***' */
                _.Display($"***");

                /*" -1263- DISPLAY '*** FONTE  -> ' SINISMES-COD-FONTE OF DCLSINISTRO-MESTRE */
                _.Display($"*** FONTE  -> {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE}");

                /*" -1264- DISPLAY '***' */
                _.Display($"***");

                /*" -1265- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1265- END-IF. */
            }


        }

        [StopWatch]
        /*" R1070-ENCONTRAR-FONTE-DB-SELECT-1 */
        public void R1070_ENCONTRAR_FONTE_DB_SELECT_1()
        {
            /*" -1255- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :SINISMES-COD-FONTE END-EXEC. */

            var r1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1 = new R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1()
            {
                SINISMES_COD_FONTE = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.ToString(),
            };

            var executed_1 = R1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1.Execute(r1070_ENCONTRAR_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }

        [StopWatch]
        /*" R1080-ENCONTRAR-RAMOS */
        private void R1080_ENCONTRAR_RAMOS(bool isPerform = false)
        {
            /*" -1273- MOVE 'R1080' TO PARAGRAFO */
            _.Move("R1080", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1278- PERFORM R1080_ENCONTRAR_RAMOS_DB_SELECT_1 */

            R1080_ENCONTRAR_RAMOS_DB_SELECT_1();

            /*" -1281- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1283- MOVE 'SI0850B - ERRO NO SELECT(RAMOS)' TO WS-MSG-ERRO */
                _.Move("SI0850B - ERRO NO SELECT(RAMOS)", WS_MSG_ERRO);

                /*" -1284- DISPLAY '***' */
                _.Display($"***");

                /*" -1286- DISPLAY '*** RAMO -> ' SINISMES-RAMO OF DCLSINISTRO-MESTRE */
                _.Display($"*** RAMO -> {SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO}");

                /*" -1287- DISPLAY '***' */
                _.Display($"***");

                /*" -1288- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO(); //GOTO
                return;

                /*" -1288- END-IF. */
            }


        }

        [StopWatch]
        /*" R1080-ENCONTRAR-RAMOS-DB-SELECT-1 */
        public void R1080_ENCONTRAR_RAMOS_DB_SELECT_1()
        {
            /*" -1278- EXEC SQL SELECT NOME_RAMO INTO :RAMOS-NOME-RAMO FROM SEGUROS.RAMOS WHERE RAMO_EMISSOR = :SINISMES-RAMO AND COD_MODALIDADE = 0 END-EXEC. */

            var r1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1 = new R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1()
            {
                SINISMES_RAMO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_RAMO.ToString(),
            };

            var executed_1 = R1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1.Execute(r1080_ENCONTRAR_RAMOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOS_NOME_RAMO, RAMOS.DCLRAMOS.RAMOS_NOME_RAMO);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1298- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1299- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1300- DISPLAY '*----------------* MSG ERRO *------------------*' */
                _.Display($"*----------------* MSG ERRO *------------------*");

                /*" -1301- DISPLAY '* ABEND -> ' WABEND */
                _.Display($"* ABEND -> {WABEND}");

                /*" -1302- DISPLAY '* ' WS-MSG-ERRO */
                _.Display($"* {WS_MSG_ERRO}");

                /*" -1303- DISPLAY '*----------------------------------------------*' */
                _.Display($"*----------------------------------------------*");

                /*" -1305- END-IF */
            }


            /*" -1305- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

            /*" -1307- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1310- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1311- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -1312- ELSE */
            }
            else
            {


                /*" -1313- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1315- END-IF */
            }


            /*" -1315- PERFORM R9999_00_ROT_ERRO_DB_CLOSE_1 */

            R9999_00_ROT_ERRO_DB_CLOSE_1();

            /*" -1319- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-DB-CLOSE-1 */
        public void R9999_00_ROT_ERRO_DB_CLOSE_1()
        {
            /*" -1315- EXEC SQL CLOSE CSINISTRO END-EXEC */

            CSINISTRO.Close();

        }
    }
}