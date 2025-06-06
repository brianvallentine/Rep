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
using Sias.Cobranca.DB2.CB1280B;

namespace Code
{
    public class CB1280B
    {
        public bool IsCall { get; set; }

        public CB1280B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA ........... COBRANCA                                   *      */
        /*"      * PROGRAMA .......... CB1280B                                    *      */
        /*"      * PROJETO ........... ATENDIMENTO CADMUS 136030                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA .......... LISIANE BRAGAN�A SOARES                    *      */
        /*"      * DATA CODIFICACAO .. 06/05/2016                                 *      */
        /*"      * FUNCAO ............ SELECIONA AS PARCELAS EM ATRASO PARA OS    *      */
        /*"      *                     PRODUTOS 'CCA-1805' E 'LOTERICO-1803'      *      */
        /*"      *                     PARA CADASTRAMENTO NA TABELA               *      */
        /*"      *                     CB_APOLICE_VIGPROP ONDE TERA NOVA VIGENCIA *      */
        /*"      *                     E ONDE SERA CALCULADA A DATA CANCELAMENTO  *      */
        /*"      *                     DA APOLICE                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * OBS: NA IMPLANTACAO DO PROGRAMA FOI COLOCADO A DATA DE CORTE   *      */
        /*"      *      PARA 13/06/2016.                                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      H I S T O R I C O                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   ALTERADO EM 01/02/2017 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 146776 - ALTERADO A DATA DE CORTE PARA 10/02/2017     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  *   ALTERADO EM 22/09/2016 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 142393 - ALTERA��O NO CALCULO DA DATA DE CANCELAMENTO *      */
        /*"      *                   E NA DATA FIM DA VIGENCIA PROPORCIONAL       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  *   ALTERADO EM 11/07/2016 - LISIANE BRAGANCA SOARES             *      */
        /*"      *   CADMUS 139720 - ALTERA��O NA FORMA DE VERIFICAR O RETORNO    *      */
        /*"      *                   DO BANCO EM FUNCAO DO REENVIO DAS PARCELAS   *      */
        /*"      *                   REALIZADO NA APLICACAO LT60                  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _CB1280S01 { get; set; } = new FileBasis(new PIC("X", "259", "X(259)"));

        public FileBasis CB1280S01
        {
            get
            {
                _.Move(S01_REGISTRO, _CB1280S01); VarBasis.RedefinePassValue(S01_REGISTRO, _CB1280S01, S01_REGISTRO); return _CB1280S01;
            }
        }
        public FileBasis _CB1280S02 { get; set; } = new FileBasis(new PIC("X", "259", "X(259)"));

        public FileBasis CB1280S02
        {
            get
            {
                _.Move(S02_REGISTRO, _CB1280S02); VarBasis.RedefinePassValue(S02_REGISTRO, _CB1280S02, S02_REGISTRO); return _CB1280S02;
            }
        }
        public FileBasis _CB1280S03 { get; set; } = new FileBasis(new PIC("X", "90", "X(90)"));

        public FileBasis CB1280S03
        {
            get
            {
                _.Move(S03_REGISTRO, _CB1280S03); VarBasis.RedefinePassValue(S03_REGISTRO, _CB1280S03, S03_REGISTRO); return _CB1280S03;
            }
        }
        /*"01 S01-REGISTRO                   PIC X(259).*/
        public StringBasis S01_REGISTRO { get; set; } = new StringBasis(new PIC("X", "259", "X(259)."), @"");
        /*"01 S02-REGISTRO                   PIC X(259).*/
        public StringBasis S02_REGISTRO { get; set; } = new StringBasis(new PIC("X", "259", "X(259)."), @"");
        /*"01 S03-REGISTRO.*/
        public CB1280B_S03_REGISTRO S03_REGISTRO { get; set; } = new CB1280B_S03_REGISTRO();
        public class CB1280B_S03_REGISTRO : VarBasis
        {
            /*"   05 S03-NR-APOLICE              PIC 9(13).*/
            public IntBasis S03_NR_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S03-NR-ENDOSSO              PIC 9(06).*/
            public IntBasis S03_NR_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S03-NR-PARCELA              PIC 9(02).*/
            public IntBasis S03_NR_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S03-CD-PRODUTO              PIC 9(04).*/
            public IntBasis S03_CD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S03-DT-VENCIMENTO           PIC X(10).*/
            public StringBasis S03_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S03-DS-OBSERVACAO           PIC X(50).*/
            public StringBasis S03_DS_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-QT-LIDOS                    PIC 9(09) VALUE ZEROS.*/
        public IntBasis WS_QT_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77 WS-QT-INC                      PIC 9(09) VALUE ZEROS.*/
        public IntBasis WS_QT_INC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77 WS-QT-REJ                      PIC 9(09) VALUE ZEROS.*/
        public IntBasis WS_QT_REJ { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77 WS-QT-APO-REP                  PIC 9(09) VALUE ZEROS.*/
        public IntBasis WS_QT_APO_REP { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77 WS-FIM-LE-CURSOR               PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_FIM_LE_CURSOR { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77 WS-FLAG-ERRO                   PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_FLAG_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77 WS-TEM-VIG-PROP                PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_TEM_VIG_PROP { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77 WS-DT-FIM-VIG-PROP             PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_FIM_VIG_PROP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DT-CANCELAMENTO             PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DT-CANCELAMENTO-1           PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_CANCELAMENTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DT-CANCELAMENTO-2           PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_CANCELAMENTO_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-DT-CORTE                    PIC X(10) VALUE SPACES.*/
        public StringBasis WS_DT_CORTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
        /*"77 WS-NR-APOLICE-ANT              PIC 9(13) VALUE ZEROS.*/
        public IntBasis WS_NR_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
        /*"77 WS-DS-OBSERVACAO               PIC X(50) VALUE SPACES.*/
        public StringBasis WS_DS_OBSERVACAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"");
        /*"77 WS-SEG-INICIAL                 PIC S9(08)V9(4) VALUE 0.*/
        public DoubleBasis WS_SEG_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)"), 4);
        /*"77 WS-SEG-FINAL                   PIC S9(08)V9(4) VALUE 0.*/
        public DoubleBasis WS_SEG_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)"), 4);
        /*"77 WS-TOT-TIME-ED                 PIC ZZZ.ZZ9,9999-.*/
        public DoubleBasis WS_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
        /*"77 WS-QT-DIAS-CANC                PIC S9(02) VALUE +0 COMP.*/
        public IntBasis WS_QT_DIAS_CANC { get; set; } = new IntBasis(new PIC("S9", "2", "S9(02)"));
        /*"77 WS-QT-REGISTRO-1               PIC S9(06) VALUE +0 COMP.*/
        public IntBasis WS_QT_REGISTRO_1 { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"77 WS-QT-REGISTRO-2               PIC S9(06) VALUE +0 COMP.*/
        public IntBasis WS_QT_REGISTRO_2 { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"77 WS-QT-SINISTRO                 PIC S9(06) VALUE +0 COMP.*/
        public IntBasis WS_QT_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "6", "S9(06)"));
        /*"77 WS-VL-PAGAMENTO                PIC S9(13)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_VL_PAGAMENTO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77 WS-VL-ESTORNO                  PIC S9(13)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_VL_ESTORNO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77 WS-VL-PAGO                     PIC S9(13)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_VL_PAGO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77 WS-VL-DEVIDO                   PIC S9(13)V99 VALUE +0 COMP-3.*/
        public DoubleBasis WS_VL_DEVIDO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77 WS-QT-DIAS-VIG                PIC S9(06)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis WS_QT_DIAS_VIG { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(5)"), 5);
        /*"77 WS-QT-DIAS-VIG-PROP           PIC S9(06)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis WS_QT_DIAS_VIG_PROP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(06)V9(5)"), 5);
        /*"77 STATUS-S01                     PIC X(02) VALUE ZEROS.*/

        public SelectorBasis STATUS_S01 { get; set; } = new SelectorBasis("02", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 STATUS-FIM-S01 VALUE '10'. */
							new SelectorItemBasis("STATUS_FIM_S01", "10"),
							/*" 88 STATUS-OK-S01  VALUE '00' '97'. */
							new SelectorItemBasis("STATUS_OK_S01", "00"),
							/*" 88 STATUS-DUP-S01 VALUE '22'. */
							new SelectorItemBasis("STATUS_DUP_S01", "22"),
							/*" 88 STATUS-INE-S01 VALUE '23'. */
							new SelectorItemBasis("STATUS_INE_S01", "23")
                }
        };

        /*"77 STATUS-S02                     PIC X(02) VALUE ZEROS.*/

        public SelectorBasis STATUS_S02 { get; set; } = new SelectorBasis("02", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 STATUS-FIM-S02 VALUE '10'. */
							new SelectorItemBasis("STATUS_FIM_S02", "10"),
							/*" 88 STATUS-OK-S02  VALUE '00' '97'. */
							new SelectorItemBasis("STATUS_OK_S02", "00"),
							/*" 88 STATUS-DUP-S02 VALUE '22'. */
							new SelectorItemBasis("STATUS_DUP_S02", "22"),
							/*" 88 STATUS-INE-S02 VALUE '23'. */
							new SelectorItemBasis("STATUS_INE_S02", "23")
                }
        };

        /*"77 STATUS-S03                     PIC X(02) VALUE ZEROS.*/

        public SelectorBasis STATUS_S03 { get; set; } = new SelectorBasis("02", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 STATUS-FIM-S03 VALUE '10'. */
							new SelectorItemBasis("STATUS_FIM_S03", "10"),
							/*" 88 STATUS-OK-S03  VALUE '00' '97'. */
							new SelectorItemBasis("STATUS_OK_S03", "00"),
							/*" 88 STATUS-DUP-S03 VALUE '22'. */
							new SelectorItemBasis("STATUS_DUP_S03", "22"),
							/*" 88 STATUS-INE-S03 VALUE '23'. */
							new SelectorItemBasis("STATUS_INE_S03", "23")
                }
        };

        /*"01 WS-VARIAVEIS.*/
        public CB1280B_WS_VARIAVEIS WS_VARIAVEIS { get; set; } = new CB1280B_WS_VARIAVEIS();
        public class CB1280B_WS_VARIAVEIS : VarBasis
        {
            /*"   05 WS-DATA-1.*/
            public CB1280B_WS_DATA_1 WS_DATA_1 { get; set; } = new CB1280B_WS_DATA_1();
            public class CB1280B_WS_DATA_1 : VarBasis
            {
                /*"      10 WS-ANO-1                 PIC 9(04).*/
                public IntBasis WS_ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 FILLER                   PIC X(01).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WS-MES-1                 PIC 9(02).*/
                public IntBasis WS_MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                   PIC X(01).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WS-DIA-1                 PIC 9(02).*/
                public IntBasis WS_DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-DATA-2.*/
            }
            public CB1280B_WS_DATA_2 WS_DATA_2 { get; set; } = new CB1280B_WS_DATA_2();
            public class CB1280B_WS_DATA_2 : VarBasis
            {
                /*"      10 WS-DIA-2                 PIC 9(02).*/
                public IntBasis WS_DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      10 WS-MES-2                 PIC 9(02).*/
                public IntBasis WS_MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      10 WS-ANO-2                 PIC 9(04).*/
                public IntBasis WS_ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"   05 WS-NR-CPFCNPJ               PIC 9(15).*/
            }
            public IntBasis WS_NR_CPFCNPJ { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"   05 WS-NR-CPFCNPJ-R1 REDEFINES WS-NR-CPFCNPJ.*/
            private _REDEF_CB1280B_WS_NR_CPFCNPJ_R1 _ws_nr_cpfcnpj_r1 { get; set; }
            public _REDEF_CB1280B_WS_NR_CPFCNPJ_R1 WS_NR_CPFCNPJ_R1
            {
                get { _ws_nr_cpfcnpj_r1 = new _REDEF_CB1280B_WS_NR_CPFCNPJ_R1(); _.Move(WS_NR_CPFCNPJ, _ws_nr_cpfcnpj_r1); VarBasis.RedefinePassValue(WS_NR_CPFCNPJ, _ws_nr_cpfcnpj_r1, WS_NR_CPFCNPJ); _ws_nr_cpfcnpj_r1.ValueChanged += () => { _.Move(_ws_nr_cpfcnpj_r1, WS_NR_CPFCNPJ); }; return _ws_nr_cpfcnpj_r1; }
                set { VarBasis.RedefinePassValue(value, _ws_nr_cpfcnpj_r1, WS_NR_CPFCNPJ); }
            }  //Redefines
            public class _REDEF_CB1280B_WS_NR_CPFCNPJ_R1 : VarBasis
            {
                /*"      10 WS-NRCPF-FILLER          PIC 9(04).*/
                public IntBasis WS_NRCPF_FILLER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 WS-NRCPF-1               PIC 9(03).*/
                public IntBasis WS_NRCPF_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRCPF-2               PIC 9(03).*/
                public IntBasis WS_NRCPF_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRCPF-3               PIC 9(03).*/
                public IntBasis WS_NRCPF_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRCPF-DV              PIC 9(02).*/
                public IntBasis WS_NRCPF_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-NR-CPFCNPJ-R2 REDEFINES WS-NR-CPFCNPJ.*/

                public _REDEF_CB1280B_WS_NR_CPFCNPJ_R1()
                {
                    WS_NRCPF_FILLER.ValueChanged += OnValueChanged;
                    WS_NRCPF_1.ValueChanged += OnValueChanged;
                    WS_NRCPF_2.ValueChanged += OnValueChanged;
                    WS_NRCPF_3.ValueChanged += OnValueChanged;
                    WS_NRCPF_DV.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_CB1280B_WS_NR_CPFCNPJ_R2 _ws_nr_cpfcnpj_r2 { get; set; }
            public _REDEF_CB1280B_WS_NR_CPFCNPJ_R2 WS_NR_CPFCNPJ_R2
            {
                get { _ws_nr_cpfcnpj_r2 = new _REDEF_CB1280B_WS_NR_CPFCNPJ_R2(); _.Move(WS_NR_CPFCNPJ, _ws_nr_cpfcnpj_r2); VarBasis.RedefinePassValue(WS_NR_CPFCNPJ, _ws_nr_cpfcnpj_r2, WS_NR_CPFCNPJ); _ws_nr_cpfcnpj_r2.ValueChanged += () => { _.Move(_ws_nr_cpfcnpj_r2, WS_NR_CPFCNPJ); }; return _ws_nr_cpfcnpj_r2; }
                set { VarBasis.RedefinePassValue(value, _ws_nr_cpfcnpj_r2, WS_NR_CPFCNPJ); }
            }  //Redefines
            public class _REDEF_CB1280B_WS_NR_CPFCNPJ_R2 : VarBasis
            {
                /*"      10 WS-NRCNPJ-1              PIC 9(03).*/
                public IntBasis WS_NRCNPJ_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRCNPJ-2              PIC 9(03).*/
                public IntBasis WS_NRCNPJ_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRCNPJ-3              PIC 9(03).*/
                public IntBasis WS_NRCNPJ_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 WS-NRCNPJ-4              PIC 9(04).*/
                public IntBasis WS_NRCNPJ_4 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 WS-NRCNPJ-DV             PIC 9(02).*/
                public IntBasis WS_NRCNPJ_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-NR-CPF.*/

                public _REDEF_CB1280B_WS_NR_CPFCNPJ_R2()
                {
                    WS_NRCNPJ_1.ValueChanged += OnValueChanged;
                    WS_NRCNPJ_2.ValueChanged += OnValueChanged;
                    WS_NRCNPJ_3.ValueChanged += OnValueChanged;
                    WS_NRCNPJ_4.ValueChanged += OnValueChanged;
                    WS_NRCNPJ_DV.ValueChanged += OnValueChanged;
                }

            }
            public CB1280B_WS_NR_CPF WS_NR_CPF { get; set; } = new CB1280B_WS_NR_CPF();
            public class CB1280B_WS_NR_CPF : VarBasis
            {
                /*"      10 WS-NR-CPF-1              PIC 9(03).*/
                public IntBasis WS_NR_CPF_1 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 FILLER                   PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"      10 WS-NR-CPF-2              PIC 9(03).*/
                public IntBasis WS_NR_CPF_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 FILLER                   PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"      10 WS-NR-CPF-3              PIC 9(03).*/
                public IntBasis WS_NR_CPF_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 FILLER                   PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10 WS-NR-CPF-DV             PIC 9(02).*/
                public IntBasis WS_NR_CPF_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-NR-CNPJ.*/
            }
            public CB1280B_WS_NR_CNPJ WS_NR_CNPJ { get; set; } = new CB1280B_WS_NR_CNPJ();
            public class CB1280B_WS_NR_CNPJ : VarBasis
            {
                /*"      10 WS-NR-CNPJ-1             PIC ZZ9.*/
                public IntBasis WS_NR_CNPJ_1 { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                /*"      10 WS-NR-CNPJ-2             PIC 9(03).*/
                public IntBasis WS_NR_CNPJ_2 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 FILLER                   PIC X(01) VALUE '.'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @".");
                /*"      10 WS-NR-CNPJ-3             PIC 9(03).*/
                public IntBasis WS_NR_CNPJ_3 { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
                /*"      10 FILLER                   PIC X(01) VALUE '/'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
                /*"      10 WS-NR-CNPJ-4             PIC 9(04).*/
                public IntBasis WS_NR_CNPJ_4 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 FILLER                   PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10 WS-NR-CNPJ-DV            PIC 9(02).*/
                public IntBasis WS_NR_CNPJ_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-TELEFONE                 PIC 9(09).*/
            }
            public IntBasis WS_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 FILLER REDEFINES WS-TELEFONE.*/
            private _REDEF_CB1280B_FILLER_15 _filler_15 { get; set; }
            public _REDEF_CB1280B_FILLER_15 FILLER_15
            {
                get { _filler_15 = new _REDEF_CB1280B_FILLER_15(); _.Move(WS_TELEFONE, _filler_15); VarBasis.RedefinePassValue(WS_TELEFONE, _filler_15, WS_TELEFONE); _filler_15.ValueChanged += () => { _.Move(_filler_15, WS_TELEFONE); }; return _filler_15; }
                set { VarBasis.RedefinePassValue(value, _filler_15, WS_TELEFONE); }
            }  //Redefines
            public class _REDEF_CB1280B_FILLER_15 : VarBasis
            {
                /*"      10 WS-NR-PREFIX             PIC 9(05).*/
                public IntBasis WS_NR_PREFIX { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                /*"      10 WS-NR-INTERM             PIC 9(02).*/
                public IntBasis WS_NR_INTERM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 WS-NR-SUFIXO             PIC 9(02).*/
                public IntBasis WS_NR_SUFIXO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-NR-TELEFONE.*/

                public _REDEF_CB1280B_FILLER_15()
                {
                    WS_NR_PREFIX.ValueChanged += OnValueChanged;
                    WS_NR_INTERM.ValueChanged += OnValueChanged;
                    WS_NR_SUFIXO.ValueChanged += OnValueChanged;
                }

            }
            public CB1280B_WS_NR_TELEFONE WS_NR_TELEFONE { get; set; } = new CB1280B_WS_NR_TELEFONE();
            public class CB1280B_WS_NR_TELEFONE : VarBasis
            {
                /*"      10 FILLER                   PIC X(01) VALUE '('.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"(");
                /*"      10 WS-NR-DDD                PIC 9(02).*/
                public IntBasis WS_NR_DDD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                   PIC X(01) VALUE ')'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @")");
                /*"      10 WS-NR-PREF               PIC Z9999.*/
                public IntBasis WS_NR_PREF { get; set; } = new IntBasis(new PIC("9", "5", "Z9999."));
                /*"      10 FILLER                   PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10 WS-NR-INTM               PIC 9(02).*/
                public IntBasis WS_NR_INTM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 WS-NR-SUFX               PIC 9(02).*/
                public IntBasis WS_NR_SUFX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-DESCR-S01-S02.*/
            }
            public CB1280B_WS_DESCR_S01_S02 WS_DESCR_S01_S02 { get; set; } = new CB1280B_WS_DESCR_S01_S02();
            public class CB1280B_WS_DESCR_S01_S02 : VarBasis
            {
                /*"      10 FILLER                   PIC X(07) VALUE 'PRODUTO'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"      10 FILLER                   PIC X(11) VALUE ';DC-PRODUTO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @";DC_PRODUTO");
                /*"      10 FILLER                   PIC X(08) VALUE ';APOLICE'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @";APOLICE");
                /*"      10 FILLER                   PIC X(08) VALUE ';ENDOSSO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @";ENDOSSO");
                /*"      10 FILLER                   PIC X(08) VALUE ';PARCELA'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @";PARCELA");
                /*"      10 FILLER                   PIC X(13) VALUE         ';NOME-CLIENTE'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @";NOME_CLIENTE");
                /*"      10 FILLER                   PIC X(09) VALUE ';CPF/CNPJ'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @";CPF/CNPJ");
                /*"      10 FILLER                   PIC X(11) VALUE ';DT-SELECAO'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @";DT_SELECAO");
                /*"      10 FILLER                   PIC X(10) VALUE ';DT-VENCIM'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @";DT_VENCIM");
                /*"      10 FILLER                   PIC X(15) VALUE         ';FONE-COMERCIAL'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @";FONE_COMERCIAL");
                /*"      10 FILLER                   PIC X(17) VALUE         ';FONE-RESIDENCIAL'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "17", "X(17)"), @";FONE_RESIDENCIAL");
                /*"      10 FILLER                   PIC X(13) VALUE         ';FONE-CELULAR'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @";FONE_CELULAR");
                /*"      10 FILLER                   PIC X(07) VALUE ';E-MAIL'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @";E_MAIL");
                /*"      10 FILLER                   PIC X(16) VALUE         ';DT-FIM-VIG-PROP'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @";DT_FIM_VIG_PROP");
                /*"      10 FILLER                   PIC X(16) VALUE         ';DT-CANCELAMENTO'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @";DT_CANCELAMENTO");
                /*"   05 WS-DESCR-S03.*/
            }
            public CB1280B_WS_DESCR_S03 WS_DESCR_S03 { get; set; } = new CB1280B_WS_DESCR_S03();
            public class CB1280B_WS_DESCR_S03 : VarBasis
            {
                /*"      10 FILLER                   PIC X(07) VALUE 'APOLICE'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"APOLICE");
                /*"      10 FILLER                   PIC X(08) VALUE ';ENDOSSO'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @";ENDOSSO");
                /*"      10 FILLER                   PIC X(08) VALUE ';PARCELA'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @";PARCELA");
                /*"      10 FILLER                   PIC X(08) VALUE ';PRODUTO'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @";PRODUTO");
                /*"      10 FILLER                   PIC X(10) VALUE ';DT-VENCIM'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @";DT_VENCIM");
                /*"      10 FILLER                   PIC X(11) VALUE ';OBSERVACAO'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @";OBSERVACAO");
                /*"01 WS-REGISTRO.*/
            }
        }
        public CB1280B_WS_REGISTRO WS_REGISTRO { get; set; } = new CB1280B_WS_REGISTRO();
        public class CB1280B_WS_REGISTRO : VarBasis
        {
            /*"   05 WS-CD-PRODUTO               PIC 9(04).*/
            public IntBasis WS_CD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NM-PRODUTO               PIC X(40).*/
            public StringBasis WS_NM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-APOLICE               PIC 9(13).*/
            public IntBasis WS_NR_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-ENDOSSO               PIC 9(06).*/
            public IntBasis WS_NR_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-PARCELA               PIC 9(02).*/
            public IntBasis WS_NR_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NM-CLIENTE               PIC X(40).*/
            public StringBasis WS_NM_CLIENTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-CPF-CNPJ              PIC X(18).*/
            public StringBasis WS_NR_CPF_CNPJ { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-DT-SELECAO               PIC X(10).*/
            public StringBasis WS_DT_SELECAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-DT-VENCIMENTO            PIC X(10).*/
            public StringBasis WS_DT_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-TEL-COMERCIAL         PIC X(14).*/
            public StringBasis WS_NR_TEL_COMERCIAL { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-TEL-RESIDENCIAL       PIC X(14).*/
            public StringBasis WS_NR_TEL_RESIDENCIAL { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-NR-TEL-CELULAR           PIC X(14).*/
            public StringBasis WS_NR_TEL_CELULAR { get; set; } = new StringBasis(new PIC("X", "14", "X(14)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-EMAIL                    PIC X(40).*/
            public StringBasis WS_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-DT-FIM-VIG-PROPORC       PIC X(10).*/
            public StringBasis WS_DT_FIM_VIG_PROPORC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 WS-DT-CANCELAMENTO-APOLICE  PIC X(10).*/
            public StringBasis WS_DT_CANCELAMENTO_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"77 WS-MSG                         PIC X(80) VALUE SPACES.*/
        }
        public StringBasis WS_MSG { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
        /*"01 WS-VARIAVEIS-GLOBAIS.*/
        public CB1280B_WS_VARIAVEIS_GLOBAIS WS_VARIAVEIS_GLOBAIS { get; set; } = new CB1280B_WS_VARIAVEIS_GLOBAIS();
        public class CB1280B_WS_VARIAVEIS_GLOBAIS : VarBasis
        {
            /*"   05 WS-CURRENT-DATE.*/
            public CB1280B_WS_CURRENT_DATE WS_CURRENT_DATE { get; set; } = new CB1280B_WS_CURRENT_DATE();
            public class CB1280B_WS_CURRENT_DATE : VarBasis
            {
                /*"      10 WS-DATE                  PIC X(16) VALUE SPACES.*/
                public StringBasis WS_DATE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"      10 WS-DATE-R REDEFINES WS-DATE.*/
                private _REDEF_CB1280B_WS_DATE_R _ws_date_r { get; set; }
                public _REDEF_CB1280B_WS_DATE_R WS_DATE_R
                {
                    get { _ws_date_r = new _REDEF_CB1280B_WS_DATE_R(); _.Move(WS_DATE, _ws_date_r); VarBasis.RedefinePassValue(WS_DATE, _ws_date_r, WS_DATE); _ws_date_r.ValueChanged += () => { _.Move(_ws_date_r, WS_DATE); }; return _ws_date_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_date_r, WS_DATE); }
                }  //Redefines
                public class _REDEF_CB1280B_WS_DATE_R : VarBasis
                {
                    /*"         15 WS-DT-TODAY           PIC 9(08).*/
                    public IntBasis WS_DT_TODAY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"         15 WS-HR-TODAY           PIC 9(06).*/
                    public IntBasis WS_HR_TODAY { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"         15 FILLER REDEFINES WS-HR-TODAY.*/
                    private _REDEF_CB1280B_FILLER_54 _filler_54 { get; set; }
                    public _REDEF_CB1280B_FILLER_54 FILLER_54
                    {
                        get { _filler_54 = new _REDEF_CB1280B_FILLER_54(); _.Move(WS_HR_TODAY, _filler_54); VarBasis.RedefinePassValue(WS_HR_TODAY, _filler_54, WS_HR_TODAY); _filler_54.ValueChanged += () => { _.Move(_filler_54, WS_HR_TODAY); }; return _filler_54; }
                        set { VarBasis.RedefinePassValue(value, _filler_54, WS_HR_TODAY); }
                    }  //Redefines
                    public class _REDEF_CB1280B_FILLER_54 : VarBasis
                    {
                        /*"            20 WS-HR-HOR          PIC 9(02).*/
                        public IntBasis WS_HR_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"            20 WS-HR-MIN          PIC 9(02).*/
                        public IntBasis WS_HR_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"            20 WS-HR-SEG          PIC 9(02).*/
                        public IntBasis WS_HR_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"         15 WS-HR-DECSEG          PIC 9(02).*/

                        public _REDEF_CB1280B_FILLER_54()
                        {
                            WS_HR_HOR.ValueChanged += OnValueChanged;
                            WS_HR_MIN.ValueChanged += OnValueChanged;
                            WS_HR_SEG.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_HR_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"01 WS-DISPLAY.*/

                    public _REDEF_CB1280B_WS_DATE_R()
                    {
                        WS_DT_TODAY.ValueChanged += OnValueChanged;
                        WS_HR_TODAY.ValueChanged += OnValueChanged;
                        FILLER_54.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public CB1280B_WS_DISPLAY WS_DISPLAY { get; set; } = new CB1280B_WS_DISPLAY();
        public class CB1280B_WS_DISPLAY : VarBasis
        {
            /*"   05 FILLER                      PIC X(07) VALUE      'CB1280B'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"CB1280B");
            /*"   05 FILLER                      PIC X(35) VALUE      ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"   05 WS-NR-PARAG                 PIC X(04) VALUE '0000'.*/
            public StringBasis WS_NR_PARAG { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"0000");
            /*"   05 FILLER                      PIC X(13) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
            /*"   05 WS-SQLCODE                  PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.CBAPOVIG CBAPOVIG { get; set; } = new Dclgens.CBAPOVIG();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public CB1280B_CUR_PARCELAS CUR_PARCELAS { get; set; } = new CB1280B_CUR_PARCELAS();
        public CB1280B_CUR_PARCELA_PAGA CUR_PARCELA_PAGA { get; set; } = new CB1280B_CUR_PARCELA_PAGA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CB1280S01_FILE_NAME_P, string CB1280S02_FILE_NAME_P, string CB1280S03_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CB1280S01.SetFile(CB1280S01_FILE_NAME_P);
                CB1280S02.SetFile(CB1280S02_FILE_NAME_P);
                CB1280S03.SetFile(CB1280S03_FILE_NAME_P);

                /*" -338- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC */

                /*" -339- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC */

                /*" -340- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC */

                /*" -344- PERFORM P1000-00-INICIO. */

                P1000_00_INICIO_SECTION();

                /*" -394- PERFORM Execute_DB_DECLARE_1 */

                Execute_DB_DECLARE_1();

                /*" -407- PERFORM Execute_DB_DECLARE_2 */

                Execute_DB_DECLARE_2();

                /*" -411- PERFORM P2000-00-PRINCIPAL. */

                P2000_00_PRINCIPAL_SECTION();

                /*" -411- PERFORM P9000-00-FINALIZA. */

                P9000_00_FINALIZA_SECTION();

                /*" -411- FLUXCONTROL_PERFORM Execute-DB-DECLARE-1 */

                Execute_DB_DECLARE_1();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-DECLARE-1 */
        public void Execute_DB_DECLARE_1()
        {
            /*" -394- EXEC SQL DECLARE CUR_PARCELAS CURSOR FOR SELECT D.NUM_APOLICE ,D.NUM_ENDOSSO ,D.NUM_PARCELA ,D.DATA_VENCIMENTO ,D.PRM_TOTAL ,B.COD_PRODUTO ,F.DESCR_PRODUTO ,B.DATA_INIVIGENCIA ,B.DATA_TERVIGENCIA ,E.NOME_RAZAO ,E.TIPO_PESSOA ,E.CGCCPF ,G.DDD ,G.TELEFONE ,G.FAX ,G.TELEX ,VALUE(H.EMAIL, ' ' ) FROM SEGUROS.APOLICES A INNER JOIN SEGUROS.ENDOSSOS B ON A.NUM_APOLICE = B.NUM_APOLICE AND B.COD_PRODUTO IN (1803,1805) AND B.SIT_REGISTRO = '0' AND B.TIPO_ENDOSSO IN ( '0' , '1' ) AND B.DATA_TERVIGENCIA > :SISTEMAS-DATA-MOV-ABERTO INNER JOIN SEGUROS.PARCELAS C ON B.NUM_APOLICE = C.NUM_APOLICE AND B.NUM_ENDOSSO = C.NUM_ENDOSSO AND C.SIT_REGISTRO = '0' INNER JOIN SEGUROS.PARCELA_HISTORICO D ON C.NUM_APOLICE = D.NUM_APOLICE AND C.NUM_ENDOSSO = D.NUM_ENDOSSO AND C.NUM_PARCELA = D.NUM_PARCELA AND D.OCORR_HISTORICO = 1 AND D.DATA_VENCIMENTO > :WS-DT-CORTE AND D.DATA_VENCIMENTO < :SISTEMAS-DATA-MOV-ABERTO INNER JOIN SEGUROS.CLIENTES E ON A.COD_CLIENTE = E.COD_CLIENTE INNER JOIN SEGUROS.PRODUTO F ON B.COD_PRODUTO = F.COD_PRODUTO INNER JOIN SEGUROS.ENDERECOS G ON A.COD_CLIENTE = G.COD_CLIENTE AND B.OCORR_ENDERECO = G.OCORR_ENDERECO LEFT JOIN SEGUROS.CLIENTE_EMAIL H ON A.COD_CLIENTE = H.COD_CLIENTE ORDER BY D.NUM_APOLICE ,D.NUM_ENDOSSO ,D.NUM_PARCELA WITH UR END-EXEC */
            CUR_PARCELAS = new CB1280B_CUR_PARCELAS(true);
            string GetQuery_CUR_PARCELAS()
            {
                var query = @$"SELECT D.NUM_APOLICE 
							,D.NUM_ENDOSSO 
							,D.NUM_PARCELA 
							,D.DATA_VENCIMENTO 
							,D.PRM_TOTAL 
							,B.COD_PRODUTO 
							,F.DESCR_PRODUTO 
							,B.DATA_INIVIGENCIA 
							,B.DATA_TERVIGENCIA 
							,E.NOME_RAZAO 
							,E.TIPO_PESSOA 
							,E.CGCCPF 
							,G.DDD 
							,G.TELEFONE 
							,G.FAX 
							,G.TELEX 
							,VALUE(H.EMAIL
							, ' ' ) 
							FROM SEGUROS.APOLICES A 
							INNER
							JOIN SEGUROS.ENDOSSOS B 
							ON A.NUM_APOLICE = B.NUM_APOLICE 
							AND B.COD_PRODUTO IN (1803
							,1805) 
							AND B.SIT_REGISTRO = '0' 
							AND B.TIPO_ENDOSSO IN ( '0'
							, '1' ) 
							AND B.DATA_TERVIGENCIA > '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							INNER
							JOIN SEGUROS.PARCELAS C 
							ON B.NUM_APOLICE = C.NUM_APOLICE 
							AND B.NUM_ENDOSSO = C.NUM_ENDOSSO 
							AND C.SIT_REGISTRO = '0' 
							INNER
							JOIN SEGUROS.PARCELA_HISTORICO D 
							ON C.NUM_APOLICE = D.NUM_APOLICE 
							AND C.NUM_ENDOSSO = D.NUM_ENDOSSO 
							AND C.NUM_PARCELA = D.NUM_PARCELA 
							AND D.OCORR_HISTORICO = 1 
							AND D.DATA_VENCIMENTO > '{WS_DT_CORTE}' 
							AND D.DATA_VENCIMENTO < '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							INNER
							JOIN SEGUROS.CLIENTES E 
							ON A.COD_CLIENTE = E.COD_CLIENTE 
							INNER
							JOIN SEGUROS.PRODUTO F 
							ON B.COD_PRODUTO = F.COD_PRODUTO 
							INNER
							JOIN SEGUROS.ENDERECOS G 
							ON A.COD_CLIENTE = G.COD_CLIENTE 
							AND B.OCORR_ENDERECO = G.OCORR_ENDERECO 
							LEFT
							JOIN SEGUROS.CLIENTE_EMAIL H 
							ON A.COD_CLIENTE = H.COD_CLIENTE 
							ORDER BY D.NUM_APOLICE 
							,D.NUM_ENDOSSO 
							,D.NUM_PARCELA";

                return query;
            }
            CUR_PARCELAS.GetQueryEvent += GetQuery_CUR_PARCELAS;

        }

        [StopWatch]
        /*" P1000-00-INICIO-SECTION */
        private void P1000_00_INICIO_SECTION()
        {
            /*" -418- MOVE '1000' TO WS-NR-PARAG */
            _.Move("1000", WS_DISPLAY.WS_NR_PARAG);

            /*" -420- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -423- DISPLAY 'DATA INICIO: ' WS-DT-TODAY ' - HORA INICIO: ' WS-HR-TODAY */

            $"DATA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_DT_TODAY} - HORA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_TODAY}"
            .Display();

            /*" -428- COMPUTE WS-SEG-INICIAL = (WS-HR-HOR * 60 * 60) + (WS-HR-MIN * 60) + WS-HR-SEG + (WS-HR-DECSEG / 100) */
            WS_SEG_INICIAL.Value = (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_54.WS_HR_HOR * 60 * 60) + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_54.WS_HR_MIN * 60) + WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_54.WS_HR_SEG + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_DECSEG / 100f);

            /*" -430- INITIALIZE DCLSISTEMAS */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
            );

            /*" -432- MOVE 'LT' TO SISTEMAS-IDE-SISTEMA */
            _.Move("LT", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -438- PERFORM P1000_00_INICIO_DB_SELECT_1 */

            P1000_00_INICIO_DB_SELECT_1();

            /*" -441- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -443- MOVE 'ERRO NA LEITURA TABELA .SISTEMAS' TO WS-MSG */
                _.Move("ERRO NA LEITURA TABELA .SISTEMAS", WS_MSG);

                /*" -444- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -446- END-IF */
            }


            /*" -447- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -450- STRING 'SISTEMA ' SISTEMAS-IDE-SISTEMA ' NAO CADASTRADO' DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl1 = "SISTEMA " + SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.GetMoveValues();
                spl1 += " NAO CADASTRADO";
                _.Move(spl1, WS_MSG);
                #endregion

                /*" -451- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -455- END-IF */
            }


            /*" -459- DISPLAY 'SISTEMA: ' SISTEMAS-IDE-SISTEMA ' DATA ' SISTEMAS-DATA-MOV-ABERTO */

            $"SISTEMA: {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA} DATA {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -461- MOVE '2017-02-10' TO WS-DT-CORTE */
            _.Move("2017-02-10", WS_DT_CORTE);

            /*" -461- DISPLAY 'DATA CORTE ' WS-DT-CORTE. */
            _.Display($"DATA CORTE {WS_DT_CORTE}");

        }

        [StopWatch]
        /*" P1000-00-INICIO-DB-SELECT-1 */
        public void P1000_00_INICIO_DB_SELECT_1()
        {
            /*" -438- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC */

            var p1000_00_INICIO_DB_SELECT_1_Query1 = new P1000_00_INICIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = P1000_00_INICIO_DB_SELECT_1_Query1.Execute(p1000_00_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" Execute-DB-DECLARE-2 */
        public void Execute_DB_DECLARE_2()
        {
            /*" -407- EXEC SQL DECLARE CUR_PARCELA_PAGA CURSOR FOR SELECT A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA FROM SEGUROS.CB_APOLICE_VIGPROP A ,SEGUROS.PARCELAS B WHERE A.SITUACAO = 'X' AND A.NUM_APOLICE = B.NUM_APOLICE AND A.NUM_ENDOSSO = B.NUM_ENDOSSO AND A.NUM_PARCELA = B.NUM_PARCELA AND B.SIT_REGISTRO = '1' END-EXEC */
            CUR_PARCELA_PAGA = new CB1280B_CUR_PARCELA_PAGA(false);
            string GetQuery_CUR_PARCELA_PAGA()
            {
                var query = @$"SELECT A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							FROM SEGUROS.CB_APOLICE_VIGPROP A 
							,SEGUROS.PARCELAS B 
							WHERE A.SITUACAO = 'X' 
							AND A.NUM_APOLICE = B.NUM_APOLICE 
							AND A.NUM_ENDOSSO = B.NUM_ENDOSSO 
							AND A.NUM_PARCELA = B.NUM_PARCELA 
							AND B.SIT_REGISTRO = '1'";

                return query;
            }
            CUR_PARCELA_PAGA.GetQueryEvent += GetQuery_CUR_PARCELA_PAGA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P1000_99_FIM*/

        [StopWatch]
        /*" P2000-00-PRINCIPAL-SECTION */
        private void P2000_00_PRINCIPAL_SECTION()
        {
            /*" -472- DISPLAY 'INICIO PRINCIPAL' */
            _.Display($"INICIO PRINCIPAL");

            /*" -473- MOVE '2000' TO WS-NR-PARAG */
            _.Move("2000", WS_DISPLAY.WS_NR_PARAG);

            /*" -475- MOVE SPACES TO WS-MSG */
            _.Move("", WS_MSG);

            /*" -477- OPEN OUTPUT CB1280S01 */
            CB1280S01.Open(S01_REGISTRO, STATUS_S01);

            /*" -478- IF NOT STATUS-OK-S01 */

            if (!STATUS_S01["STATUS_OK_S01"])
            {

                /*" -481- STRING 'ERRO NA ABERTURA S01 - STATUS ' STATUS-S01 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl2 = "ERRO NA ABERTURA S01 - STATUS " + STATUS_S01.GetMoveValues();
                _.Move(spl2, WS_MSG);
                #endregion

                /*" -482- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -484- END-IF */
            }


            /*" -486- OPEN OUTPUT CB1280S02 */
            CB1280S02.Open(S02_REGISTRO, STATUS_S02);

            /*" -487- IF NOT STATUS-OK-S02 */

            if (!STATUS_S02["STATUS_OK_S02"])
            {

                /*" -490- STRING 'ERRO NA ABERTURA S02 - STATUS ' STATUS-S02 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl3 = "ERRO NA ABERTURA S02 - STATUS " + STATUS_S02.GetMoveValues();
                _.Move(spl3, WS_MSG);
                #endregion

                /*" -491- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -493- END-IF */
            }


            /*" -495- OPEN OUTPUT CB1280S03 */
            CB1280S03.Open(S03_REGISTRO, STATUS_S03);

            /*" -496- IF NOT STATUS-OK-S03 */

            if (!STATUS_S03["STATUS_OK_S03"])
            {

                /*" -499- STRING 'ERRO NA ABERTURA S03 - STATUS ' STATUS-S03 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl4 = "ERRO NA ABERTURA S03 - STATUS " + STATUS_S03.GetMoveValues();
                _.Move(spl4, WS_MSG);
                #endregion

                /*" -500- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -502- END-IF */
            }


            /*" -505- MOVE WS-DESCR-S01-S02 TO S01-REGISTRO S02-REGISTRO */
            _.Move(WS_VARIAVEIS.WS_DESCR_S01_S02, S01_REGISTRO, S02_REGISTRO);

            /*" -507- WRITE S01-REGISTRO */
            CB1280S01.Write(S01_REGISTRO.GetMoveValues().ToString());

            /*" -508- IF NOT STATUS-OK-S01 */

            if (!STATUS_S01["STATUS_OK_S01"])
            {

                /*" -511- STRING 'ERRO NA 1 GRAVACAO S01 - STATUS ' STATUS-S01 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl5 = "ERRO NA 1 GRAVACAO S01 - STATUS " + STATUS_S01.GetMoveValues();
                _.Move(spl5, WS_MSG);
                #endregion

                /*" -512- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -514- END-IF */
            }


            /*" -516- WRITE S02-REGISTRO */
            CB1280S02.Write(S02_REGISTRO.GetMoveValues().ToString());

            /*" -517- IF NOT STATUS-OK-S02 */

            if (!STATUS_S02["STATUS_OK_S02"])
            {

                /*" -520- STRING 'ERRO NA 1 GRAVACAO S02 - STATUS ' STATUS-S02 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl6 = "ERRO NA 1 GRAVACAO S02 - STATUS " + STATUS_S02.GetMoveValues();
                _.Move(spl6, WS_MSG);
                #endregion

                /*" -521- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -523- END-IF */
            }


            /*" -525- MOVE WS-DESCR-S03 TO S03-REGISTRO */
            _.Move(WS_VARIAVEIS.WS_DESCR_S03, S03_REGISTRO);

            /*" -527- WRITE S03-REGISTRO */
            CB1280S03.Write(S03_REGISTRO.GetMoveValues().ToString());

            /*" -528- IF NOT STATUS-OK-S03 */

            if (!STATUS_S03["STATUS_OK_S03"])
            {

                /*" -531- STRING 'ERRO NA 1 GRAVACAO S03 - STATUS ' STATUS-S03 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl7 = "ERRO NA 1 GRAVACAO S03 - STATUS " + STATUS_S03.GetMoveValues();
                _.Move(spl7, WS_MSG);
                #endregion

                /*" -532- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -534- END-IF */
            }


            /*" -534- PERFORM P2000_00_PRINCIPAL_DB_OPEN_1 */

            P2000_00_PRINCIPAL_DB_OPEN_1();

            /*" -537- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -539- MOVE 'ERRO NA ABERTURA DO CURSOR CUR_PARCELA_PAGA' TO WS-MSG */
                _.Move("ERRO NA ABERTURA DO CURSOR CUR_PARCELA_PAGA", WS_MSG);

                /*" -540- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -542- END-IF */
            }


            /*" -544- MOVE 0 TO WS-FIM-LE-CURSOR */
            _.Move(0, WS_FIM_LE_CURSOR);

            /*" -545- PERFORM UNTIL WS-FIM-LE-CURSOR = 1 */

            while (!(WS_FIM_LE_CURSOR == 1))
            {

                /*" -546- PERFORM P2200-00-LE-CUR-PARCELA-PAGA */

                P2200_00_LE_CUR_PARCELA_PAGA_SECTION();

                /*" -548- END-PERFORM */
            }

            /*" -548- PERFORM P2000_00_PRINCIPAL_DB_CLOSE_1 */

            P2000_00_PRINCIPAL_DB_CLOSE_1();

            /*" -551- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -553- MOVE 'ERRO NO FECHAMENTO DO CURSOR CUR_PARCELA_PAGA' TO WS-MSG */
                _.Move("ERRO NO FECHAMENTO DO CURSOR CUR_PARCELA_PAGA", WS_MSG);

                /*" -554- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -556- END-IF */
            }


            /*" -556- PERFORM P2000_00_PRINCIPAL_DB_OPEN_2 */

            P2000_00_PRINCIPAL_DB_OPEN_2();

            /*" -559- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -561- MOVE 'ERRO NA ABERTURA DO CURSOR CUR_PARCELAS' TO WS-MSG */
                _.Move("ERRO NA ABERTURA DO CURSOR CUR_PARCELAS", WS_MSG);

                /*" -562- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -564- END-IF */
            }


            /*" -566- MOVE 0 TO WS-FIM-LE-CURSOR */
            _.Move(0, WS_FIM_LE_CURSOR);

            /*" -567- PERFORM UNTIL WS-FIM-LE-CURSOR = 1 */

            while (!(WS_FIM_LE_CURSOR == 1))
            {

                /*" -568- PERFORM P2100-00-LE-CUR-PARCELAS */

                P2100_00_LE_CUR_PARCELAS_SECTION();

                /*" -570- END-PERFORM */
            }

            /*" -570- PERFORM P2000_00_PRINCIPAL_DB_CLOSE_2 */

            P2000_00_PRINCIPAL_DB_CLOSE_2();

            /*" -573- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -575- MOVE 'ERRO NO FECHAMENTO DO CURSOR CUR_PARCELAS' TO WS-MSG */
                _.Move("ERRO NO FECHAMENTO DO CURSOR CUR_PARCELAS", WS_MSG);

                /*" -576- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -578- END-IF */
            }


            /*" -579- DISPLAY 'TOTAL DE REGISTROS LIDOS ' WS-QT-LIDOS */
            _.Display($"TOTAL DE REGISTROS LIDOS {WS_QT_LIDOS}");

            /*" -580- DISPLAY 'TOTAL DE REGISTROS INC   ' WS-QT-INC */
            _.Display($"TOTAL DE REGISTROS INC   {WS_QT_INC}");

            /*" -581- DISPLAY 'TOTAL DE REGISTROS REJ   ' WS-QT-REJ */
            _.Display($"TOTAL DE REGISTROS REJ   {WS_QT_REJ}");

            /*" -583- DISPLAY 'TOTAL DE REGISTROS REP   ' WS-QT-APO-REP */
            _.Display($"TOTAL DE REGISTROS REP   {WS_QT_APO_REP}");

            /*" -583- DISPLAY 'TERMINO PRINCIPAL' . */
            _.Display($"TERMINO PRINCIPAL");

        }

        [StopWatch]
        /*" P2000-00-PRINCIPAL-DB-OPEN-1 */
        public void P2000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -534- EXEC SQL OPEN CUR_PARCELA_PAGA END-EXEC */

            CUR_PARCELA_PAGA.Open();

        }

        [StopWatch]
        /*" P2000-00-PRINCIPAL-DB-CLOSE-1 */
        public void P2000_00_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -548- EXEC SQL CLOSE CUR_PARCELA_PAGA END-EXEC */

            CUR_PARCELA_PAGA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2000_99_FIM*/

        [StopWatch]
        /*" P2000-00-PRINCIPAL-DB-OPEN-2 */
        public void P2000_00_PRINCIPAL_DB_OPEN_2()
        {
            /*" -556- EXEC SQL OPEN CUR_PARCELAS END-EXEC */

            CUR_PARCELAS.Open();

        }

        [StopWatch]
        /*" P2000-00-PRINCIPAL-DB-CLOSE-2 */
        public void P2000_00_PRINCIPAL_DB_CLOSE_2()
        {
            /*" -570- EXEC SQL CLOSE CUR_PARCELAS END-EXEC */

            CUR_PARCELAS.Close();

        }

        [StopWatch]
        /*" P2100-00-LE-CUR-PARCELAS-SECTION */
        private void P2100_00_LE_CUR_PARCELAS_SECTION()
        {
            /*" -594- MOVE '2100' TO WS-NR-PARAG */
            _.Move("2100", WS_DISPLAY.WS_NR_PARAG);

            /*" -612- PERFORM P2100_00_LE_CUR_PARCELAS_DB_FETCH_1 */

            P2100_00_LE_CUR_PARCELAS_DB_FETCH_1();

            /*" -615- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -617- MOVE 'ERRO NA LEITURA DO CURSOR CUR_PARCELAS' TO WS-MSG */
                _.Move("ERRO NA LEITURA DO CURSOR CUR_PARCELAS", WS_MSG);

                /*" -618- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -620- END-IF */
            }


            /*" -621- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -622- PERFORM P2110-00-TRATA-REGISTRO */

                P2110_00_TRATA_REGISTRO_SECTION();

                /*" -623- ELSE */
            }
            else
            {


                /*" -624- MOVE 1 TO WS-FIM-LE-CURSOR */
                _.Move(1, WS_FIM_LE_CURSOR);

                /*" -624- END-IF. */
            }


        }

        [StopWatch]
        /*" P2100-00-LE-CUR-PARCELAS-DB-FETCH-1 */
        public void P2100_00_LE_CUR_PARCELAS_DB_FETCH_1()
        {
            /*" -612- EXEC SQL FETCH NEXT CUR_PARCELAS INTO :PARCEHIS-NUM-APOLICE ,:PARCEHIS-NUM-ENDOSSO ,:PARCEHIS-NUM-PARCELA ,:PARCEHIS-DATA-VENCIMENTO ,:PARCEHIS-PRM-TOTAL ,:ENDOSSOS-COD-PRODUTO ,:PRODUTO-DESCR-PRODUTO ,:ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA ,:CLIENTES-NOME-RAZAO ,:CLIENTES-TIPO-PESSOA ,:CLIENTES-CGCCPF ,:ENDERECO-DDD ,:ENDERECO-TELEFONE ,:ENDERECO-FAX ,:ENDERECO-TELEX ,:CLIENEMA-EMAIL END-EXEC */

            if (CUR_PARCELAS.Fetch())
            {
                _.Move(CUR_PARCELAS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(CUR_PARCELAS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(CUR_PARCELAS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(CUR_PARCELAS.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(CUR_PARCELAS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(CUR_PARCELAS.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(CUR_PARCELAS.PRODUTO_DESCR_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO);
                _.Move(CUR_PARCELAS.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(CUR_PARCELAS.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(CUR_PARCELAS.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(CUR_PARCELAS.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(CUR_PARCELAS.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(CUR_PARCELAS.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(CUR_PARCELAS.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(CUR_PARCELAS.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(CUR_PARCELAS.ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(CUR_PARCELAS.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2100_99_FIM*/

        [StopWatch]
        /*" P2110-00-TRATA-REGISTRO-SECTION */
        private void P2110_00_TRATA_REGISTRO_SECTION()
        {
            /*" -635- MOVE '2110' TO WS-NR-PARAG */
            _.Move("2110", WS_DISPLAY.WS_NR_PARAG);

            /*" -637- ADD 1 TO WS-QT-LIDOS */
            WS_QT_LIDOS.Value = WS_QT_LIDOS + 1;

            /*" -646- DISPLAY 'APO ' PARCEHIS-NUM-APOLICE '/' PARCEHIS-NUM-ENDOSSO '/' PARCEHIS-NUM-PARCELA ' DT  ' PARCEHIS-DATA-VENCIMENTO ' PRO ' ENDOSSOS-COD-PRODUTO ' VIG ' ENDOSSOS-DATA-INIVIGENCIA ' A ' ENDOSSOS-DATA-TERVIGENCIA ' LIDOS ' WS-QT-LIDOS */

            $"APO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}/{PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}/{PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA} DT  {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO} PRO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO} VIG {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA} A {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA} LIDOS {WS_QT_LIDOS}"
            .Display();

            /*" -647- IF PARCEHIS-NUM-APOLICE = WS-NR-APOLICE-ANT */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE == WS_NR_APOLICE_ANT)
            {

                /*" -648- ADD 1 TO WS-QT-APO-REP */
                WS_QT_APO_REP.Value = WS_QT_APO_REP + 1;

                /*" -649- GO TO P2110-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2110_99_FIM*/ //GOTO
                return;

                /*" -651- END-IF */
            }


            /*" -652- MOVE PARCEHIS-NUM-APOLICE TO WS-NR-APOLICE-ANT */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, WS_NR_APOLICE_ANT);

            /*" -654- MOVE 0 TO WS-FLAG-ERRO */
            _.Move(0, WS_FLAG_ERRO);

            /*" -656- PERFORM P2111-00-VALIDA-APOLICE */

            P2111_00_VALIDA_APOLICE_SECTION();

            /*" -657- IF WS-FLAG-ERRO = 1 */

            if (WS_FLAG_ERRO == 1)
            {

                /*" -658- ADD 1 TO WS-QT-REJ */
                WS_QT_REJ.Value = WS_QT_REJ + 1;

                /*" -659- GO TO P2110-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2110_99_FIM*/ //GOTO
                return;

                /*" -661- END-IF */
            }


            /*" -663- PERFORM P2112-00-CALCULA-VIGENCIA */

            P2112_00_CALCULA_VIGENCIA_SECTION();

            /*" -665- PERFORM P2113-00-CALCULA-VALORES */

            P2113_00_CALCULA_VALORES_SECTION();

            /*" -667- PERFORM P2114-00-GRAVA-S01-S02 */

            P2114_00_GRAVA_S01_S02_SECTION();

            /*" -669- PERFORM P2115-00-INCLUI-CBAPOVIG */

            P2115_00_INCLUI_CBAPOVIG_SECTION();

            /*" -669- ADD 1 TO WS-QT-INC. */
            WS_QT_INC.Value = WS_QT_INC + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2110_99_FIM*/

        [StopWatch]
        /*" P2111-00-VALIDA-APOLICE-SECTION */
        private void P2111_00_VALIDA_APOLICE_SECTION()
        {
            /*" -682- MOVE '2111' TO WS-NR-PARAG */
            _.Move("2111", WS_DISPLAY.WS_NR_PARAG);

            /*" -683- MOVE SPACES TO CBAPOVIG-SITUACAO */
            _.Move("", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

            /*" -685- MOVE 0 TO WS-TEM-VIG-PROP */
            _.Move(0, WS_TEM_VIG_PROP);

            /*" -693- PERFORM P2111_00_VALIDA_APOLICE_DB_SELECT_1 */

            P2111_00_VALIDA_APOLICE_DB_SELECT_1();

            /*" -696- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -700- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -702- MOVE 'ERRO NA LEITURA DA TABELA .CB_APOLICE_VIGPROP' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .CB_APOLICE_VIGPROP", WS_MSG);

                /*" -703- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -705- END-IF */
            }


            /*" -706- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -708- IF PARCEHIS-NUM-ENDOSSO = CBAPOVIG-NUM-ENDOSSO AND PARCEHIS-NUM-PARCELA = CBAPOVIG-NUM-PARCELA */

                if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO == CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO && PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA == CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA)
                {

                    /*" -710- MOVE 'VIGENCIA JA CADASTRADA' TO WS-DS-OBSERVACAO */
                    _.Move("VIGENCIA JA CADASTRADA", WS_DS_OBSERVACAO);

                    /*" -711- PERFORM P2116-00-GRAVA-S03 */

                    P2116_00_GRAVA_S03_SECTION();

                    /*" -712- GO TO P2111-99-FIM */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/ //GOTO
                    return;

                    /*" -714- END-IF */
                }


                /*" -715- MOVE 1 TO WS-TEM-VIG-PROP */
                _.Move(1, WS_TEM_VIG_PROP);

                /*" -721- END-IF */
            }


            /*" -723- MOVE 0 TO WS-QT-REGISTRO-1 */
            _.Move(0, WS_QT_REGISTRO_1);

            /*" -724- IF ENDOSSOS-COD-PRODUTO = 1803 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 1803)
            {

                /*" -725- MOVE 600121 TO MOVDEBCE-COD-CONVENIO */
                _.Move(600121, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -726- ELSE */
            }
            else
            {


                /*" -727- MOVE 600149 TO MOVDEBCE-COD-CONVENIO */
                _.Move(600149, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

                /*" -729- END-IF */
            }


            /*" -738- PERFORM P2111_00_VALIDA_APOLICE_DB_SELECT_2 */

            P2111_00_VALIDA_APOLICE_DB_SELECT_2();

            /*" -741- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -745- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -747- DISPLAY 'CONVENIO ' MOVDEBCE-COD-CONVENIO */
                _.Display($"CONVENIO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -749- MOVE 'ERRO NA 1 LEITURA DA TABELA .MOVTO_DEBITOCC_CEF' TO WS-MSG */
                _.Move("ERRO NA 1 LEITURA DA TABELA .MOVTO_DEBITOCC_CEF", WS_MSG);

                /*" -750- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -752- END-IF */
            }


            /*" -753- IF WS-QT-REGISTRO-1 = 0 */

            if (WS_QT_REGISTRO_1 == 0)
            {

                /*" -755- MOVE 'REGISTRO DE DEBITO EM CONTA NAO CADASTRADO' TO WS-DS-OBSERVACAO */
                _.Move("REGISTRO DE DEBITO EM CONTA NAO CADASTRADO", WS_DS_OBSERVACAO);

                /*" -756- PERFORM P2116-00-GRAVA-S03 */

                P2116_00_GRAVA_S03_SECTION();

                /*" -757- GO TO P2111-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/ //GOTO
                return;

                /*" -759- END-IF */
            }


            /*" -761- MOVE 0 TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -770- PERFORM P2111_00_VALIDA_APOLICE_DB_SELECT_3 */

            P2111_00_VALIDA_APOLICE_DB_SELECT_3();

            /*" -773- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -777- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -779- DISPLAY 'CONVENIO ' MOVDEBCE-COD-CONVENIO */
                _.Display($"CONVENIO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO}");

                /*" -781- MOVE 'ERRO NA 2 LEITURA DA TABELA .MOVTO_DEBITOCC_CEF' TO WS-MSG */
                _.Move("ERRO NA 2 LEITURA DA TABELA .MOVTO_DEBITOCC_CEF", WS_MSG);

                /*" -782- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -784- END-IF */
            }


            /*" -785- IF MOVDEBCE-NSAS = 0 */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS == 0)
            {

                /*" -787- MOVE 'PARCELA NAO FOI ENVIADA PARA O BANCO' TO WS-DS-OBSERVACAO */
                _.Move("PARCELA NAO FOI ENVIADA PARA O BANCO", WS_DS_OBSERVACAO);

                /*" -788- PERFORM P2116-00-GRAVA-S03 */

                P2116_00_GRAVA_S03_SECTION();

                /*" -789- GO TO P2111-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/ //GOTO
                return;

                /*" -791- END-IF */
            }


            /*" -794- MOVE SPACES TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move("", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -806- PERFORM P2111_00_VALIDA_APOLICE_DB_SELECT_4 */

            P2111_00_VALIDA_APOLICE_DB_SELECT_4();

            /*" -809- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -813- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -816- DISPLAY 'CONVENIO ' MOVDEBCE-COD-CONVENIO ' NSAS ' MOVDEBCE-NSAS */

                $"CONVENIO {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO} NSAS {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS}"
                .Display();

                /*" -818- MOVE 'ERRO NA 3 LEITURA DA TABELA .MOVTO_DEBITOCC_CEF' TO WS-MSG */
                _.Move("ERRO NA 3 LEITURA DA TABELA .MOVTO_DEBITOCC_CEF", WS_MSG);

                /*" -819- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -822- END-IF */
            }


            /*" -823- IF MOVDEBCE-SITUACAO-COBRANCA = ' ' OR '1' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.In(" ", "1"))
            {

                /*" -825- MOVE 'PARCELA NAO TEVE RETORNO DO DEBITO EM CONTA' TO WS-DS-OBSERVACAO */
                _.Move("PARCELA NAO TEVE RETORNO DO DEBITO EM CONTA", WS_DS_OBSERVACAO);

                /*" -826- PERFORM P2116-00-GRAVA-S03 */

                P2116_00_GRAVA_S03_SECTION();

                /*" -827- GO TO P2111-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/ //GOTO
                return;

                /*" -829- END-IF */
            }


            /*" -830- IF MOVDEBCE-SITUACAO-COBRANCA = '2' */

            if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "2")
            {

                /*" -832- MOVE 'JA HOUVE PAGAMENTO DA PARCELA' TO WS-DS-OBSERVACAO */
                _.Move("JA HOUVE PAGAMENTO DA PARCELA", WS_DS_OBSERVACAO);

                /*" -833- PERFORM P2116-00-GRAVA-S03 */

                P2116_00_GRAVA_S03_SECTION();

                /*" -834- GO TO P2111-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/ //GOTO
                return;

                /*" -840- END-IF */
            }


            /*" -842- MOVE 0 TO WS-QT-SINISTRO */
            _.Move(0, WS_QT_SINISTRO);

            /*" -849- PERFORM P2111_00_VALIDA_APOLICE_DB_SELECT_5 */

            P2111_00_VALIDA_APOLICE_DB_SELECT_5();

            /*" -852- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -856- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -858- MOVE 'ERRO NA LEITURA DA TABELA .SINISTRO_MESTRE' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .SINISTRO_MESTRE", WS_MSG);

                /*" -859- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -861- END-IF */
            }


            /*" -862- IF WS-QT-SINISTRO > 0 */

            if (WS_QT_SINISTRO > 0)
            {

                /*" -864- MOVE 'APOLICE COM SINISTRO' TO WS-DS-OBSERVACAO */
                _.Move("APOLICE COM SINISTRO", WS_DS_OBSERVACAO);

                /*" -865- PERFORM P2116-00-GRAVA-S03 */

                P2116_00_GRAVA_S03_SECTION();

                /*" -866- GO TO P2111-99-FIM */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/ //GOTO
                return;

                /*" -866- END-IF. */
            }


        }

        [StopWatch]
        /*" P2111-00-VALIDA-APOLICE-DB-SELECT-1 */
        public void P2111_00_VALIDA_APOLICE_DB_SELECT_1()
        {
            /*" -693- EXEC SQL SELECT NUM_ENDOSSO ,NUM_PARCELA INTO :CBAPOVIG-NUM-ENDOSSO ,:CBAPOVIG-NUM-PARCELA FROM SEGUROS.CB_APOLICE_VIGPROP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE WITH UR END-EXEC */

            var p2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1 = new P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1.Execute(p2111_00_VALIDA_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBAPOVIG_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);
                _.Move(executed_1.CBAPOVIG_NUM_PARCELA, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2111_99_FIM*/

        [StopWatch]
        /*" P2111-00-VALIDA-APOLICE-DB-SELECT-2 */
        public void P2111_00_VALIDA_APOLICE_DB_SELECT_2()
        {
            /*" -738- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-QT-REGISTRO-1 FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO WITH UR END-EXEC */

            var p2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1 = new P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = P2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1.Execute(p2111_00_VALIDA_APOLICE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_REGISTRO_1, WS_QT_REGISTRO_1);
            }


        }

        [StopWatch]
        /*" P2112-00-CALCULA-VIGENCIA-SECTION */
        private void P2112_00_CALCULA_VIGENCIA_SECTION()
        {
            /*" -879- MOVE '2112' TO WS-NR-PARAG */
            _.Move("2112", WS_DISPLAY.WS_NR_PARAG);

            /*" -880- IF PARCEHIS-NUM-ENDOSSO NOT = 0 */

            if (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != 0)
            {

                /*" -889- PERFORM P2112_00_CALCULA_VIGENCIA_DB_SELECT_1 */

                P2112_00_CALCULA_VIGENCIA_DB_SELECT_1();

                /*" -892- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -896- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                    $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                    .Display();

                    /*" -898- MOVE 'ERRO NA LEITURA DA TABELA .ENDOSSOS' TO WS-MSG */
                    _.Move("ERRO NA LEITURA DA TABELA .ENDOSSOS", WS_MSG);

                    /*" -899- PERFORM P9000-00-FINALIZA */

                    P9000_00_FINALIZA_SECTION();

                    /*" -900- END-IF */
                }


                /*" -902- END-IF */
            }


            /*" -909- PERFORM P2112_00_CALCULA_VIGENCIA_DB_SELECT_2 */

            P2112_00_CALCULA_VIGENCIA_DB_SELECT_2();

            /*" -912- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -916- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -919- DISPLAY 'PERIODO ' ENDOSSOS-DATA-INIVIGENCIA ' A ' ENDOSSOS-DATA-TERVIGENCIA */

                $"PERIODO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA} A {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}"
                .Display();

                /*" -921- MOVE 'ERRO NO CALCULO DA QUANTIDADE DE DIAS DE VIGENCIA' TO WS-MSG */
                _.Move("ERRO NO CALCULO DA QUANTIDADE DE DIAS DE VIGENCIA", WS_MSG);

                /*" -922- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -924- END-IF */
            }


            /*" -925- IF WS-QT-DIAS-VIG > 365 */

            if (WS_QT_DIAS_VIG > 365)
            {

                /*" -926- MOVE 365 TO WS-QT-DIAS-VIG */
                _.Move(365, WS_QT_DIAS_VIG);

                /*" -928- END-IF. */
            }


            /*" -930- DISPLAY '  QT DIAS VIGENCIA: ' WS-QT-DIAS-VIG ' PERIODO ' ENDOSSOS-DATA-INIVIGENCIA ' A ' ENDOSSOS-DATA-TERVIGENCIA. */

            $"  QT DIAS VIGENCIA: {WS_QT_DIAS_VIG} PERIODO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA} A {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA}"
            .Display();

        }

        [StopWatch]
        /*" P2112-00-CALCULA-VIGENCIA-DB-SELECT-1 */
        public void P2112_00_CALCULA_VIGENCIA_DB_SELECT_1()
        {
            /*" -889- EXEC SQL SELECT DATA_INIVIGENCIA ,DATA_TERVIGENCIA INTO :ENDOSSOS-DATA-INIVIGENCIA ,:ENDOSSOS-DATA-TERVIGENCIA FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = 0 WITH UR END-EXEC */

            var p2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1 = new P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1.Execute(p2112_00_CALCULA_VIGENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
            }


        }

        [StopWatch]
        /*" P2111-00-VALIDA-APOLICE-DB-SELECT-3 */
        public void P2111_00_VALIDA_APOLICE_DB_SELECT_3()
        {
            /*" -770- EXEC SQL SELECT VALUE(MAX(NSAS),0) INTO :MOVDEBCE-NSAS FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO WITH UR END-EXEC */

            var p2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1 = new P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = P2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1.Execute(p2111_00_VALIDA_APOLICE_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NSAS, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);
            }


        }

        [StopWatch]
        /*" P2112-00-CALCULA-VIGENCIA-DB-SELECT-2 */
        public void P2112_00_CALCULA_VIGENCIA_DB_SELECT_2()
        {
            /*" -909- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-QT-DIAS-VIG FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO BETWEEN :ENDOSSOS-DATA-INIVIGENCIA AND :ENDOSSOS-DATA-TERVIGENCIA WITH UR END-EXEC */

            var p2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1 = new P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                ENDOSSOS_DATA_TERVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA.ToString(),
            };

            var executed_1 = P2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1.Execute(p2112_00_CALCULA_VIGENCIA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_DIAS_VIG, WS_QT_DIAS_VIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2112_99_FIM*/

        [StopWatch]
        /*" P2111-00-VALIDA-APOLICE-DB-SELECT-4 */
        public void P2111_00_VALIDA_APOLICE_DB_SELECT_4()
        {
            /*" -806- EXEC SQL SELECT SITUACAO_COBRANCA INTO :MOVDEBCE-SITUACAO-COBRANCA FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA AND COD_CONVENIO = :MOVDEBCE-COD-CONVENIO AND NSAS = :MOVDEBCE-NSAS WITH UR END-EXEC */

            var p2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1 = new P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1()
            {
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
            };

            var executed_1 = P2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1.Execute(p2111_00_VALIDA_APOLICE_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
            }


        }

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-SECTION */
        private void P2113_00_CALCULA_VALORES_SECTION()
        {
            /*" -940- MOVE '2113' TO WS-NR-PARAG */
            _.Move("2113", WS_DISPLAY.WS_NR_PARAG);

            /*" -946- MOVE 0 TO WS-VL-PAGO WS-VL-PAGAMENTO WS-VL-ESTORNO WS-VL-DEVIDO */
            _.Move(0, WS_VL_PAGO, WS_VL_PAGAMENTO, WS_VL_ESTORNO, WS_VL_DEVIDO);

            /*" -952- PERFORM P2113_00_CALCULA_VALORES_DB_SELECT_1 */

            P2113_00_CALCULA_VALORES_DB_SELECT_1();

            /*" -955- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -959- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -961- MOVE 'ERRO NO CALCULO DO VALOR DEVIDO' TO WS-MSG */
                _.Move("ERRO NO CALCULO DO VALOR DEVIDO", WS_MSG);

                /*" -962- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -964- END-IF */
            }


            /*" -978- PERFORM P2113_00_CALCULA_VALORES_DB_SELECT_2 */

            P2113_00_CALCULA_VALORES_DB_SELECT_2();

            /*" -981- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -985- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -987- MOVE 'ERRO NO CALCULO DO VALOR PAGAMENTO' TO WS-MSG */
                _.Move("ERRO NO CALCULO DO VALOR PAGAMENTO", WS_MSG);

                /*" -988- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -990- END-IF */
            }


            /*" -1003- PERFORM P2113_00_CALCULA_VALORES_DB_SELECT_3 */

            P2113_00_CALCULA_VALORES_DB_SELECT_3();

            /*" -1006- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1010- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1012- MOVE 'ERRO NO CALCULO DO VALOR ESTORNO' TO WS-MSG */
                _.Move("ERRO NO CALCULO DO VALOR ESTORNO", WS_MSG);

                /*" -1013- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1015- END-IF */
            }


            /*" -1052- COMPUTE WS-VL-PAGO = WS-VL-PAGAMENTO - WS-VL-ESTORNO */
            WS_VL_PAGO.Value = WS_VL_PAGAMENTO - WS_VL_ESTORNO;

            /*" -1053- IF WS-VL-DEVIDO NOT = 0 */

            if (WS_VL_DEVIDO != 0)
            {

                /*" -1055- COMPUTE WS-QT-DIAS-VIG-PROP = (WS-VL-PAGO * WS-QT-DIAS-VIG) / WS-VL-DEVIDO */
                WS_QT_DIAS_VIG_PROP.Value = (WS_VL_PAGO * WS_QT_DIAS_VIG) / WS_VL_DEVIDO;

                /*" -1056- ELSE */
            }
            else
            {


                /*" -1057- MOVE 0 TO WS-QT-DIAS-VIG-PROP */
                _.Move(0, WS_QT_DIAS_VIG_PROP);

                /*" -1059- END-IF */
            }


            /*" -1061- MOVE SPACES TO WS-DT-FIM-VIG-PROP */
            _.Move("", WS_DT_FIM_VIG_PROP);

            /*" -1067- PERFORM P2113_00_CALCULA_VALORES_DB_SELECT_4 */

            P2113_00_CALCULA_VALORES_DB_SELECT_4();

            /*" -1070- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1074- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1078- DISPLAY 'DIAS VIG PROP ' WS-QT-DIAS-VIG-PROP ' DIAS VIG ' WS-QT-DIAS-VIG */

                $"DIAS VIG PROP {WS_QT_DIAS_VIG_PROP} DIAS VIG {WS_QT_DIAS_VIG}"
                .Display();

                /*" -1080- MOVE 'ERRO NA 1 LEITURA DA TABELA .CALENDARIO' TO WS-MSG */
                _.Move("ERRO NA 1 LEITURA DA TABELA .CALENDARIO", WS_MSG);

                /*" -1081- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1083- END-IF */
            }


            /*" -1087- MOVE SPACES TO WS-DT-CANCELAMENTO WS-DT-CANCELAMENTO-1 WS-DT-CANCELAMENTO-2 */
            _.Move("", WS_DT_CANCELAMENTO, WS_DT_CANCELAMENTO_1, WS_DT_CANCELAMENTO_2);

            /*" -1098- PERFORM P2113_00_CALCULA_VALORES_DB_SELECT_5 */

            P2113_00_CALCULA_VALORES_DB_SELECT_5();

            /*" -1101- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1105- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1107- DISPLAY 'DATA FIM VIG PROP ' WS-DT-FIM-VIG-PROP */
                _.Display($"DATA FIM VIG PROP {WS_DT_FIM_VIG_PROP}");

                /*" -1109- MOVE 'ERRO NA 2 LEITURA DA TABELA .CALENDARIO' TO WS-MSG */
                _.Move("ERRO NA 2 LEITURA DA TABELA .CALENDARIO", WS_MSG);

                /*" -1110- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1112- END-IF */
            }


            /*" -1113- IF ENDOSSOS-COD-PRODUTO = 1803 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 1803)
            {

                /*" -1114- MOVE 60 TO WS-QT-DIAS-CANC */
                _.Move(60, WS_QT_DIAS_CANC);

                /*" -1115- ELSE */
            }
            else
            {


                /*" -1116- MOVE 20 TO WS-QT-DIAS-CANC */
                _.Move(20, WS_QT_DIAS_CANC);

                /*" -1118- END-IF */
            }


            /*" -1126- PERFORM P2113_00_CALCULA_VALORES_DB_SELECT_6 */

            P2113_00_CALCULA_VALORES_DB_SELECT_6();

            /*" -1129- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1133- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1135- MOVE 'ERRO NA 3 LEITURA DA TABELA .CALENDARIO' TO WS-MSG */
                _.Move("ERRO NA 3 LEITURA DA TABELA .CALENDARIO", WS_MSG);

                /*" -1136- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1138- END-IF */
            }


            /*" -1139- IF WS-DT-CANCELAMENTO-1 > WS-DT-CANCELAMENTO-2 */

            if (WS_DT_CANCELAMENTO_1 > WS_DT_CANCELAMENTO_2)
            {

                /*" -1140- MOVE WS-DT-CANCELAMENTO-1 TO WS-DT-CANCELAMENTO */
                _.Move(WS_DT_CANCELAMENTO_1, WS_DT_CANCELAMENTO);

                /*" -1141- ELSE */
            }
            else
            {


                /*" -1142- MOVE WS-DT-CANCELAMENTO-2 TO WS-DT-CANCELAMENTO */
                _.Move(WS_DT_CANCELAMENTO_2, WS_DT_CANCELAMENTO);

                /*" -1144- END-IF. */
            }


            /*" -1147- DISPLAY '  VL DEVIDO ' WS-VL-DEVIDO ' VL PAGO ' WS-VL-PAGO */

            $"  VL DEVIDO {WS_VL_DEVIDO} VL PAGO {WS_VL_PAGO}"
            .Display();

            /*" -1150- DISPLAY '  DIAS VIG ' WS-QT-DIAS-VIG ' DIAS VIG PROP ' WS-QT-DIAS-VIG-PROP */

            $"  DIAS VIG {WS_QT_DIAS_VIG} DIAS VIG PROP {WS_QT_DIAS_VIG_PROP}"
            .Display();

            /*" -1151- DISPLAY '  DT CANC-1 ' WS-DT-CANCELAMENTO-1 */
            _.Display($"  DT CANC-1 {WS_DT_CANCELAMENTO_1}");

            /*" -1153- DISPLAY '  DT CANC-2 ' WS-DT-CANCELAMENTO-2 */
            _.Display($"  DT CANC-2 {WS_DT_CANCELAMENTO_2}");

            /*" -1154- DISPLAY '  DT-FIM-VIG ' WS-DT-FIM-VIG-PROP ' DT CANC ' WS-DT-CANCELAMENTO. */

            $"  DT-FIM-VIG {WS_DT_FIM_VIG_PROP} DT CANC {WS_DT_CANCELAMENTO}"
            .Display();

        }

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-DB-SELECT-1 */
        public void P2113_00_CALCULA_VALORES_DB_SELECT_1()
        {
            /*" -952- EXEC SQL SELECT IFNULL(SUM(PRM_TOTAL_IX),0) INTO :WS-VL-DEVIDO FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE WITH UR END-EXEC */

            var p2113_00_CALCULA_VALORES_DB_SELECT_1_Query1 = new P2113_00_CALCULA_VALORES_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2113_00_CALCULA_VALORES_DB_SELECT_1_Query1.Execute(p2113_00_CALCULA_VALORES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VL_DEVIDO, WS_VL_DEVIDO);
            }


        }

        [StopWatch]
        /*" P2111-00-VALIDA-APOLICE-DB-SELECT-5 */
        public void P2111_00_VALIDA_APOLICE_DB_SELECT_5()
        {
            /*" -849- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WS-QT-SINISTRO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND SIT_REGISTRO NOT IN ( '2' ) WITH UR END-EXEC */

            var p2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1 = new P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1.Execute(p2111_00_VALIDA_APOLICE_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_QT_SINISTRO, WS_QT_SINISTRO);
            }


        }

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-DB-SELECT-2 */
        public void P2113_00_CALCULA_VALORES_DB_SELECT_2()
        {
            /*" -978- EXEC SQL SELECT IFNULL(SUM(PRM_TOTAL),0) INTO :WS-VL-PAGAMENTO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND ( ( COD_OPERACAO BETWEEN 200 AND 299 ) AND ( (NUM_ENDOSSO = 0) OR (NUM_ENDOSSO BETWEEN 800000 AND 899999) ) ) WITH UR END-EXEC */

            var p2113_00_CALCULA_VALORES_DB_SELECT_2_Query1 = new P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2113_00_CALCULA_VALORES_DB_SELECT_2_Query1.Execute(p2113_00_CALCULA_VALORES_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VL_PAGAMENTO, WS_VL_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2113_99_FIM*/

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-DB-SELECT-3 */
        public void P2113_00_CALCULA_VALORES_DB_SELECT_3()
        {
            /*" -1003- EXEC SQL SELECT IFNULL(SUM(PRM_TOTAL),0) INTO :WS-VL-ESTORNO FROM SEGUROS.PARCELA_HISTORICO WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND ( ( COD_OPERACAO BETWEEN 300 AND 399 ) OR ((COD_OPERACAO BETWEEN 200 AND 299) AND (NUM_ENDOSSO BETWEEN 200000 AND 299999) ) ) WITH UR END-EXEC */

            var p2113_00_CALCULA_VALORES_DB_SELECT_3_Query1 = new P2113_00_CALCULA_VALORES_DB_SELECT_3_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2113_00_CALCULA_VALORES_DB_SELECT_3_Query1.Execute(p2113_00_CALCULA_VALORES_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VL_ESTORNO, WS_VL_ESTORNO);
            }


        }

        [StopWatch]
        /*" P2114-00-GRAVA-S01-S02-SECTION */
        private void P2114_00_GRAVA_S01_S02_SECTION()
        {
            /*" -1165- MOVE '2114' TO WS-NR-PARAG */
            _.Move("2114", WS_DISPLAY.WS_NR_PARAG);

            /*" -1167- INITIALIZE WS-REGISTRO */
            _.Initialize(
                WS_REGISTRO
            );

            /*" -1169- MOVE ALL ';' TO WS-REGISTRO */
            _.MoveAll(";", WS_REGISTRO);

            /*" -1170- MOVE ENDOSSOS-COD-PRODUTO TO WS-CD-PRODUTO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, WS_REGISTRO.WS_CD_PRODUTO);

            /*" -1171- MOVE PRODUTO-DESCR-PRODUTO TO WS-NM-PRODUTO */
            _.Move(PRODUTO.DCLPRODUTO.PRODUTO_DESCR_PRODUTO, WS_REGISTRO.WS_NM_PRODUTO);

            /*" -1172- MOVE PARCEHIS-NUM-APOLICE TO WS-NR-APOLICE */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, WS_REGISTRO.WS_NR_APOLICE);

            /*" -1173- MOVE PARCEHIS-NUM-ENDOSSO TO WS-NR-ENDOSSO */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, WS_REGISTRO.WS_NR_ENDOSSO);

            /*" -1174- MOVE PARCEHIS-NUM-PARCELA TO WS-NR-PARCELA */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, WS_REGISTRO.WS_NR_PARCELA);

            /*" -1175- MOVE CLIENTES-NOME-RAZAO TO WS-NM-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WS_REGISTRO.WS_NM_CLIENTE);

            /*" -1177- MOVE SPACES TO WS-NR-CPF-CNPJ */
            _.Move("", WS_REGISTRO.WS_NR_CPF_CNPJ);

            /*" -1178- IF CLIENTES-CGCCPF > 0 */

            if (CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF > 0)
            {

                /*" -1180- MOVE CLIENTES-CGCCPF TO WS-NR-CPFCNPJ */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WS_VARIAVEIS.WS_NR_CPFCNPJ);

                /*" -1181- IF CLIENTES-TIPO-PESSOA = 'F' */

                if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
                {

                    /*" -1182- MOVE WS-NRCPF-1 TO WS-NR-CPF-1 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R1.WS_NRCPF_1, WS_VARIAVEIS.WS_NR_CPF.WS_NR_CPF_1);

                    /*" -1183- MOVE WS-NRCPF-2 TO WS-NR-CPF-2 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R1.WS_NRCPF_2, WS_VARIAVEIS.WS_NR_CPF.WS_NR_CPF_2);

                    /*" -1184- MOVE WS-NRCPF-3 TO WS-NR-CPF-3 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R1.WS_NRCPF_3, WS_VARIAVEIS.WS_NR_CPF.WS_NR_CPF_3);

                    /*" -1185- MOVE WS-NRCPF-DV TO WS-NR-CPF-DV */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R1.WS_NRCPF_DV, WS_VARIAVEIS.WS_NR_CPF.WS_NR_CPF_DV);

                    /*" -1186- MOVE WS-NR-CPF TO WS-NR-CPF-CNPJ */
                    _.Move(WS_VARIAVEIS.WS_NR_CPF, WS_REGISTRO.WS_NR_CPF_CNPJ);

                    /*" -1187- ELSE */
                }
                else
                {


                    /*" -1188- MOVE WS-NRCNPJ-1 TO WS-NR-CNPJ-1 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R2.WS_NRCNPJ_1, WS_VARIAVEIS.WS_NR_CNPJ.WS_NR_CNPJ_1);

                    /*" -1189- MOVE WS-NRCNPJ-2 TO WS-NR-CNPJ-2 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R2.WS_NRCNPJ_2, WS_VARIAVEIS.WS_NR_CNPJ.WS_NR_CNPJ_2);

                    /*" -1190- MOVE WS-NRCNPJ-3 TO WS-NR-CNPJ-3 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R2.WS_NRCNPJ_3, WS_VARIAVEIS.WS_NR_CNPJ.WS_NR_CNPJ_3);

                    /*" -1191- MOVE WS-NRCNPJ-4 TO WS-NR-CNPJ-4 */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R2.WS_NRCNPJ_4, WS_VARIAVEIS.WS_NR_CNPJ.WS_NR_CNPJ_4);

                    /*" -1192- MOVE WS-NRCNPJ-DV TO WS-NR-CNPJ-DV */
                    _.Move(WS_VARIAVEIS.WS_NR_CPFCNPJ_R2.WS_NRCNPJ_DV, WS_VARIAVEIS.WS_NR_CNPJ.WS_NR_CNPJ_DV);

                    /*" -1193- MOVE WS-NR-CNPJ TO WS-NR-CPF-CNPJ */
                    _.Move(WS_VARIAVEIS.WS_NR_CNPJ, WS_REGISTRO.WS_NR_CPF_CNPJ);

                    /*" -1194- END-IF */
                }


                /*" -1196- END-IF */
            }


            /*" -1197- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-1 */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_VARIAVEIS.WS_DATA_1);

            /*" -1198- MOVE WS-DIA-1 TO WS-DIA-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_DIA_1, WS_VARIAVEIS.WS_DATA_2.WS_DIA_2);

            /*" -1199- MOVE WS-MES-1 TO WS-MES-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_MES_1, WS_VARIAVEIS.WS_DATA_2.WS_MES_2);

            /*" -1200- MOVE WS-ANO-1 TO WS-ANO-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_ANO_1, WS_VARIAVEIS.WS_DATA_2.WS_ANO_2);

            /*" -1202- MOVE WS-DATA-2 TO WS-DT-SELECAO */
            _.Move(WS_VARIAVEIS.WS_DATA_2, WS_REGISTRO.WS_DT_SELECAO);

            /*" -1203- MOVE PARCEHIS-DATA-VENCIMENTO TO WS-DATA-1 */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, WS_VARIAVEIS.WS_DATA_1);

            /*" -1204- MOVE WS-DIA-1 TO WS-DIA-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_DIA_1, WS_VARIAVEIS.WS_DATA_2.WS_DIA_2);

            /*" -1205- MOVE WS-MES-1 TO WS-MES-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_MES_1, WS_VARIAVEIS.WS_DATA_2.WS_MES_2);

            /*" -1206- MOVE WS-ANO-1 TO WS-ANO-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_ANO_1, WS_VARIAVEIS.WS_DATA_2.WS_ANO_2);

            /*" -1208- MOVE WS-DATA-2 TO WS-DT-VENCIMENTO */
            _.Move(WS_VARIAVEIS.WS_DATA_2, WS_REGISTRO.WS_DT_VENCIMENTO);

            /*" -1209- MOVE ENDERECO-DDD TO WS-NR-DDD */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, WS_VARIAVEIS.WS_NR_TELEFONE.WS_NR_DDD);

            /*" -1210- MOVE ENDERECO-TELEFONE TO WS-TELEFONE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, WS_VARIAVEIS.WS_TELEFONE);

            /*" -1211- MOVE WS-NR-PREFIX TO WS-NR-PREF */
            _.Move(WS_VARIAVEIS.FILLER_15.WS_NR_PREFIX, WS_VARIAVEIS.WS_NR_TELEFONE.WS_NR_PREF);

            /*" -1212- MOVE WS-NR-INTERM TO WS-NR-INTM */
            _.Move(WS_VARIAVEIS.FILLER_15.WS_NR_INTERM, WS_VARIAVEIS.WS_NR_TELEFONE.WS_NR_INTM);

            /*" -1213- MOVE WS-NR-SUFIXO TO WS-NR-SUFX */
            _.Move(WS_VARIAVEIS.FILLER_15.WS_NR_SUFIXO, WS_VARIAVEIS.WS_NR_TELEFONE.WS_NR_SUFX);

            /*" -1214- MOVE WS-NR-TELEFONE TO WS-NR-TEL-COMERCIAL */
            _.Move(WS_VARIAVEIS.WS_NR_TELEFONE, WS_REGISTRO.WS_NR_TEL_COMERCIAL);

            /*" -1216- MOVE SPACES TO WS-NR-TEL-RESIDENCIAL WS-NR-TEL-CELULAR */
            _.Move("", WS_REGISTRO.WS_NR_TEL_RESIDENCIAL, WS_REGISTRO.WS_NR_TEL_CELULAR);

            /*" -1218- MOVE CLIENEMA-EMAIL TO WS-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, WS_REGISTRO.WS_EMAIL);

            /*" -1219- MOVE WS-DT-FIM-VIG-PROP TO WS-DATA-1 */
            _.Move(WS_DT_FIM_VIG_PROP, WS_VARIAVEIS.WS_DATA_1);

            /*" -1220- MOVE WS-DIA-1 TO WS-DIA-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_DIA_1, WS_VARIAVEIS.WS_DATA_2.WS_DIA_2);

            /*" -1221- MOVE WS-MES-1 TO WS-MES-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_MES_1, WS_VARIAVEIS.WS_DATA_2.WS_MES_2);

            /*" -1222- MOVE WS-ANO-1 TO WS-ANO-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_ANO_1, WS_VARIAVEIS.WS_DATA_2.WS_ANO_2);

            /*" -1224- MOVE WS-DATA-2 TO WS-DT-FIM-VIG-PROPORC */
            _.Move(WS_VARIAVEIS.WS_DATA_2, WS_REGISTRO.WS_DT_FIM_VIG_PROPORC);

            /*" -1225- MOVE WS-DT-CANCELAMENTO TO WS-DATA-1 */
            _.Move(WS_DT_CANCELAMENTO, WS_VARIAVEIS.WS_DATA_1);

            /*" -1226- MOVE WS-DIA-1 TO WS-DIA-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_DIA_1, WS_VARIAVEIS.WS_DATA_2.WS_DIA_2);

            /*" -1227- MOVE WS-MES-1 TO WS-MES-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_MES_1, WS_VARIAVEIS.WS_DATA_2.WS_MES_2);

            /*" -1228- MOVE WS-ANO-1 TO WS-ANO-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_ANO_1, WS_VARIAVEIS.WS_DATA_2.WS_ANO_2);

            /*" -1230- MOVE WS-DATA-2 TO WS-DT-CANCELAMENTO-APOLICE */
            _.Move(WS_VARIAVEIS.WS_DATA_2, WS_REGISTRO.WS_DT_CANCELAMENTO_APOLICE);

            /*" -1231- IF ENDOSSOS-COD-PRODUTO = 1803 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO == 1803)
            {

                /*" -1233- MOVE WS-REGISTRO TO S01-REGISTRO */
                _.Move(WS_REGISTRO, S01_REGISTRO);

                /*" -1235- WRITE S01-REGISTRO */
                CB1280S01.Write(S01_REGISTRO.GetMoveValues().ToString());

                /*" -1236- IF NOT STATUS-OK-S01 */

                if (!STATUS_S01["STATUS_OK_S01"])
                {

                    /*" -1242- STRING 'ERRO NA GRAVACAO S01 - STATUS ' STATUS-S01 ' REGISTRO ' WS-NR-APOLICE '-' WS-NR-ENDOSSO '-' WS-NR-PARCELA DELIMITED BY SIZE INTO WS-MSG */
                    #region STRING
                    var spl8 = "ERRO NA GRAVACAO S01 - STATUS " + STATUS_S01.GetMoveValues();
                    spl8 += " REGISTRO ";
                    var spl9 = WS_REGISTRO.WS_NR_APOLICE.GetMoveValues();
                    spl9 += "-";
                    var spl10 = WS_REGISTRO.WS_NR_ENDOSSO.GetMoveValues();
                    spl10 += "-";
                    var spl11 = WS_REGISTRO.WS_NR_PARCELA.GetMoveValues();
                    var results12 = spl8 + spl9 + spl10 + spl11;
                    _.Move(results12, WS_MSG);
                    #endregion

                    /*" -1243- PERFORM P9000-00-FINALIZA */

                    P9000_00_FINALIZA_SECTION();

                    /*" -1244- END-IF */
                }


                /*" -1245- ELSE */
            }
            else
            {


                /*" -1247- MOVE WS-REGISTRO TO S02-REGISTRO */
                _.Move(WS_REGISTRO, S02_REGISTRO);

                /*" -1249- WRITE S02-REGISTRO */
                CB1280S02.Write(S02_REGISTRO.GetMoveValues().ToString());

                /*" -1250- IF NOT STATUS-OK-S02 */

                if (!STATUS_S02["STATUS_OK_S02"])
                {

                    /*" -1256- STRING 'ERRO NA GRAVACAO S02 - STATUS ' STATUS-S02 ' REGISTRO ' WS-NR-APOLICE '-' WS-NR-ENDOSSO '-' WS-NR-PARCELA DELIMITED BY SIZE INTO WS-MSG */
                    #region STRING
                    var spl12 = "ERRO NA GRAVACAO S02 - STATUS " + STATUS_S02.GetMoveValues();
                    spl12 += " REGISTRO ";
                    var spl13 = WS_REGISTRO.WS_NR_APOLICE.GetMoveValues();
                    spl13 += "-";
                    var spl14 = WS_REGISTRO.WS_NR_ENDOSSO.GetMoveValues();
                    spl14 += "-";
                    var spl15 = WS_REGISTRO.WS_NR_PARCELA.GetMoveValues();
                    var results16 = spl12 + spl13 + spl14 + spl15;
                    _.Move(results16, WS_MSG);
                    #endregion

                    /*" -1257- PERFORM P9000-00-FINALIZA */

                    P9000_00_FINALIZA_SECTION();

                    /*" -1258- END-IF */
                }


                /*" -1258- END-IF. */
            }


        }

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-DB-SELECT-4 */
        public void P2113_00_CALCULA_VALORES_DB_SELECT_4()
        {
            /*" -1067- EXEC SQL SELECT (DATA_CALENDARIO + :WS-QT-DIAS-VIG-PROP DAYS) INTO :WS-DT-FIM-VIG-PROP FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :ENDOSSOS-DATA-INIVIGENCIA WITH UR END-EXEC */

            var p2113_00_CALCULA_VALORES_DB_SELECT_4_Query1 = new P2113_00_CALCULA_VALORES_DB_SELECT_4_Query1()
            {
                ENDOSSOS_DATA_INIVIGENCIA = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA.ToString(),
                WS_QT_DIAS_VIG_PROP = WS_QT_DIAS_VIG_PROP.ToString(),
            };

            var executed_1 = P2113_00_CALCULA_VALORES_DB_SELECT_4_Query1.Execute(p2113_00_CALCULA_VALORES_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DT_FIM_VIG_PROP, WS_DT_FIM_VIG_PROP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2114_99_FIM*/

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-DB-SELECT-5 */
        public void P2113_00_CALCULA_VALORES_DB_SELECT_5()
        {
            /*" -1098- EXEC SQL SELECT MAX(A.DATA_CALENDARIO) INTO :WS-DT-CANCELAMENTO-1 FROM ( SELECT DATA_CALENDARIO FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO > :WS-DT-FIM-VIG-PROP AND DIA_SEMANA NOT IN ( 'S' , 'D' ) AND FERIADO <> 'N' FETCH FIRST 5 ROW ONLY ) A WITH UR END-EXEC */

            var p2113_00_CALCULA_VALORES_DB_SELECT_5_Query1 = new P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1()
            {
                WS_DT_FIM_VIG_PROP = WS_DT_FIM_VIG_PROP.ToString(),
            };

            var executed_1 = P2113_00_CALCULA_VALORES_DB_SELECT_5_Query1.Execute(p2113_00_CALCULA_VALORES_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DT_CANCELAMENTO_1, WS_DT_CANCELAMENTO_1);
            }


        }

        [StopWatch]
        /*" P2115-00-INCLUI-CBAPOVIG-SECTION */
        private void P2115_00_INCLUI_CBAPOVIG_SECTION()
        {
            /*" -1269- MOVE '2115' TO WS-NR-PARAG */
            _.Move("2115", WS_DISPLAY.WS_NR_PARAG);

            /*" -1270- IF WS-TEM-VIG-PROP = 1 */

            if (WS_TEM_VIG_PROP == 1)
            {

                /*" -1274- DISPLAY 'DELETANDO APO ' PARCEHIS-NUM-APOLICE ' END ' CBAPOVIG-NUM-ENDOSSO ' PARC ' CBAPOVIG-NUM-PARCELA */

                $"DELETANDO APO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} END {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO} PARC {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA}"
                .Display();

                /*" -1278- PERFORM P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1 */

                P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1();

                /*" -1281- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -1285- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                    $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                    .Display();

                    /*" -1287- MOVE 'ERRO NA DELECAO DA TABELA .CB_APOLICE_VIGPROP' TO WS-MSG */
                    _.Move("ERRO NA DELECAO DA TABELA .CB_APOLICE_VIGPROP", WS_MSG);

                    /*" -1288- PERFORM P9000-00-FINALIZA */

                    P9000_00_FINALIZA_SECTION();

                    /*" -1289- END-IF */
                }


                /*" -1291- END-IF */
            }


            /*" -1293- INITIALIZE DCLCB-APOLICE-VIGPROP */
            _.Initialize(
                CBAPOVIG.DCLCB_APOLICE_VIGPROP
            );

            /*" -1294- MOVE PARCEHIS-NUM-APOLICE TO CBAPOVIG-NUM-APOLICE */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);

            /*" -1295- MOVE PARCEHIS-NUM-ENDOSSO TO CBAPOVIG-NUM-ENDOSSO */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);

            /*" -1296- MOVE PARCEHIS-NUM-PARCELA TO CBAPOVIG-NUM-PARCELA */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);

            /*" -1297- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBAPOVIG-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO);

            /*" -1298- MOVE PARCEHIS-DATA-VENCIMENTO TO CBAPOVIG-DATA-VENCIMENTO */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO);

            /*" -1299- MOVE WS-VL-PAGO TO CBAPOVIG-PREMIO-TOTAL-PAGO */
            _.Move(WS_VL_PAGO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO);

            /*" -1300- MOVE WS-VL-DEVIDO TO CBAPOVIG-PREMIO-TOTAL-DEV */
            _.Move(WS_VL_DEVIDO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV);

            /*" -1301- MOVE WS-QT-DIAS-VIG-PROP TO CBAPOVIG-QTD-DIAS-COBERTOS */
            _.Move(WS_QT_DIAS_VIG_PROP, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS);

            /*" -1302- MOVE WS-DT-FIM-VIG-PROP TO CBAPOVIG-DATA-FIM-VIG-PROP */
            _.Move(WS_DT_FIM_VIG_PROP, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP);

            /*" -1303- MOVE WS-DT-CANCELAMENTO TO CBAPOVIG-DATA-CANCELAMENTO */
            _.Move(WS_DT_CANCELAMENTO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO);

            /*" -1304- MOVE 19 TO CBAPOVIG-IDTAB-SITUACAO */
            _.Move(19, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO);

            /*" -1306- MOVE 'X' TO CBAPOVIG-SITUACAO */
            _.Move("X", CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO);

            /*" -1341- PERFORM P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1 */

            P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1();

            /*" -1344- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1348- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1350- MOVE 'ERRO NA INCLUSAO DA TABELA .CB_APOLICE_VIGPROP' TO WS-MSG */
                _.Move("ERRO NA INCLUSAO DA TABELA .CB_APOLICE_VIGPROP", WS_MSG);

                /*" -1351- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1351- END-IF. */
            }


        }

        [StopWatch]
        /*" P2115-00-INCLUI-CBAPOVIG-DB-DELETE-1 */
        public void P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1()
        {
            /*" -1278- EXEC SQL DELETE FROM SEGUROS.CB_APOLICE_VIGPROP WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE END-EXEC */

            var p2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1 = new P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            P2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1.Execute(p2115_00_INCLUI_CBAPOVIG_DB_DELETE_1_Delete1);

        }

        [StopWatch]
        /*" P2115-00-INCLUI-CBAPOVIG-DB-INSERT-1 */
        public void P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1()
        {
            /*" -1341- EXEC SQL INSERT INTO SEGUROS.CB_APOLICE_VIGPROP ( NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,DATA_MOVIMENTO ,DATA_VENCIMENTO ,PREMIO_TOTAL_PAGO ,PREMIO_TOTAL_DEV ,QTD_DIAS_COBERTOS ,DATA_FIM_VIG_PROP ,DATA_CANCELAMENTO ,IDTAB_SITUACAO ,SITUACAO ,TIMESTAMP ,DATA_MALA_VIG_PROP ,DATA_MALA_CANCEL ) VALUES (:CBAPOVIG-NUM-APOLICE ,:CBAPOVIG-NUM-ENDOSSO ,:CBAPOVIG-NUM-PARCELA ,:CBAPOVIG-DATA-MOVIMENTO ,:CBAPOVIG-DATA-VENCIMENTO ,:CBAPOVIG-PREMIO-TOTAL-PAGO ,:CBAPOVIG-PREMIO-TOTAL-DEV ,:CBAPOVIG-QTD-DIAS-COBERTOS ,:CBAPOVIG-DATA-FIM-VIG-PROP ,:CBAPOVIG-DATA-CANCELAMENTO ,:CBAPOVIG-IDTAB-SITUACAO ,:CBAPOVIG-SITUACAO , CURRENT TIMESTAMP , NULL , NULL ) END-EXEC */

            var p2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1 = new P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
                CBAPOVIG_NUM_ENDOSSO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO.ToString(),
                CBAPOVIG_NUM_PARCELA = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA.ToString(),
                CBAPOVIG_DATA_MOVIMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_MOVIMENTO.ToString(),
                CBAPOVIG_DATA_VENCIMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_VENCIMENTO.ToString(),
                CBAPOVIG_PREMIO_TOTAL_PAGO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_PAGO.ToString(),
                CBAPOVIG_PREMIO_TOTAL_DEV = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_PREMIO_TOTAL_DEV.ToString(),
                CBAPOVIG_QTD_DIAS_COBERTOS = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_QTD_DIAS_COBERTOS.ToString(),
                CBAPOVIG_DATA_FIM_VIG_PROP = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_FIM_VIG_PROP.ToString(),
                CBAPOVIG_DATA_CANCELAMENTO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_DATA_CANCELAMENTO.ToString(),
                CBAPOVIG_IDTAB_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_IDTAB_SITUACAO.ToString(),
                CBAPOVIG_SITUACAO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_SITUACAO.ToString(),
            };

            P2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1.Execute(p2115_00_INCLUI_CBAPOVIG_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" P2113-00-CALCULA-VALORES-DB-SELECT-6 */
        public void P2113_00_CALCULA_VALORES_DB_SELECT_6()
        {
            /*" -1126- EXEC SQL SELECT (DATA_CALENDARIO + :WS-QT-DIAS-CANC DAYS) INTO :WS-DT-CANCELAMENTO-2 FROM SEGUROS.CALENDARIO WHERE DATA_CALENDARIO = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC */

            var p2113_00_CALCULA_VALORES_DB_SELECT_6_Query1 = new P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WS_QT_DIAS_CANC = WS_QT_DIAS_CANC.ToString(),
            };

            var executed_1 = P2113_00_CALCULA_VALORES_DB_SELECT_6_Query1.Execute(p2113_00_CALCULA_VALORES_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DT_CANCELAMENTO_2, WS_DT_CANCELAMENTO_2);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2115_99_FIM*/

        [StopWatch]
        /*" P2116-00-GRAVA-S03-SECTION */
        private void P2116_00_GRAVA_S03_SECTION()
        {
            /*" -1361- MOVE '2116' TO WS-NR-PARAG */
            _.Move("2116", WS_DISPLAY.WS_NR_PARAG);

            /*" -1363- MOVE 1 TO WS-FLAG-ERRO */
            _.Move(1, WS_FLAG_ERRO);

            /*" -1365- INITIALIZE S03-REGISTRO */
            _.Initialize(
                S03_REGISTRO
            );

            /*" -1366- MOVE ALL ';' TO S03-REGISTRO */
            _.MoveAll(";", S03_REGISTRO);

            /*" -1367- MOVE PARCEHIS-NUM-APOLICE TO S03-NR-APOLICE */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, S03_REGISTRO.S03_NR_APOLICE);

            /*" -1368- MOVE PARCEHIS-NUM-ENDOSSO TO S03-NR-ENDOSSO */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, S03_REGISTRO.S03_NR_ENDOSSO);

            /*" -1369- MOVE PARCEHIS-NUM-PARCELA TO S03-NR-PARCELA */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, S03_REGISTRO.S03_NR_PARCELA);

            /*" -1370- MOVE ENDOSSOS-COD-PRODUTO TO S03-CD-PRODUTO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, S03_REGISTRO.S03_CD_PRODUTO);

            /*" -1371- MOVE PARCEHIS-DATA-VENCIMENTO TO WS-DATA-1 */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, WS_VARIAVEIS.WS_DATA_1);

            /*" -1372- MOVE WS-DIA-1 TO WS-DIA-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_DIA_1, WS_VARIAVEIS.WS_DATA_2.WS_DIA_2);

            /*" -1373- MOVE WS-MES-1 TO WS-MES-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_MES_1, WS_VARIAVEIS.WS_DATA_2.WS_MES_2);

            /*" -1374- MOVE WS-ANO-1 TO WS-ANO-2 */
            _.Move(WS_VARIAVEIS.WS_DATA_1.WS_ANO_1, WS_VARIAVEIS.WS_DATA_2.WS_ANO_2);

            /*" -1375- MOVE WS-DATA-2 TO S03-DT-VENCIMENTO */
            _.Move(WS_VARIAVEIS.WS_DATA_2, S03_REGISTRO.S03_DT_VENCIMENTO);

            /*" -1377- MOVE WS-DS-OBSERVACAO TO S03-DS-OBSERVACAO */
            _.Move(WS_DS_OBSERVACAO, S03_REGISTRO.S03_DS_OBSERVACAO);

            /*" -1379- WRITE S03-REGISTRO */
            CB1280S03.Write(S03_REGISTRO.GetMoveValues().ToString());

            /*" -1380- IF NOT STATUS-OK-S03 */

            if (!STATUS_S03["STATUS_OK_S03"])
            {

                /*" -1384- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1387- STRING 'ERRO NA GRAVACAO S03 - STATUS ' STATUS-S03 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl16 = "ERRO NA GRAVACAO S03 - STATUS " + STATUS_S03.GetMoveValues();
                _.Move(spl16, WS_MSG);
                #endregion

                /*" -1388- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1388- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2116_99_FIM*/

        [StopWatch]
        /*" P2117-00-CALCULA-VL-PAGO-TST-SECTION */
        private void P2117_00_CALCULA_VL_PAGO_TST_SECTION()
        {
            /*" -1399- MOVE '2117' TO WS-NR-PARAG */
            _.Move("2117", WS_DISPLAY.WS_NR_PARAG);

            /*" -1406- PERFORM P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1 */

            P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1();

            /*" -1409- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1413- DISPLAY 'APOLICE ' PARCEHIS-NUM-APOLICE ' ENDOSSO ' PARCEHIS-NUM-ENDOSSO ' PARCELA ' PARCEHIS-NUM-PARCELA */

                $"APOLICE {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE} ENDOSSO {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO} PARCELA {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}"
                .Display();

                /*" -1415- MOVE 'ERRO NO CALCULO DO VALOR PAGO' TO WS-MSG */
                _.Move("ERRO NO CALCULO DO VALOR PAGO", WS_MSG);

                /*" -1416- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1416- END-IF. */
            }


        }

        [StopWatch]
        /*" P2117-00-CALCULA-VL-PAGO-TST-DB-SELECT-1 */
        public void P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1()
        {
            /*" -1406- EXEC SQL SELECT IFNULL(SUM(PRM_LIQUIDO_IX),0) INTO :WS-VL-PAGO FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND SIT_REGISTRO = '1' WITH UR END-EXEC */

            var p2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1_Query1 = new P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
            };

            var executed_1 = P2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1_Query1.Execute(p2117_00_CALCULA_VL_PAGO_TST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_VL_PAGO, WS_VL_PAGO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2117_99_FIM*/

        [StopWatch]
        /*" P2200-00-LE-CUR-PARCELA-PAGA-SECTION */
        private void P2200_00_LE_CUR_PARCELA_PAGA_SECTION()
        {
            /*" -1427- MOVE '2200' TO WS-NR-PARAG */
            _.Move("2200", WS_DISPLAY.WS_NR_PARAG);

            /*" -1431- PERFORM P2200_00_LE_CUR_PARCELA_PAGA_DB_FETCH_1 */

            P2200_00_LE_CUR_PARCELA_PAGA_DB_FETCH_1();

            /*" -1434- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -1436- MOVE 'ERRO NA LEITURA DO CURSOR CUR_PARCELA_PAGA' TO WS-MSG */
                _.Move("ERRO NA LEITURA DO CURSOR CUR_PARCELA_PAGA", WS_MSG);

                /*" -1437- PERFORM P9000-00-FINALIZA */

                P9000_00_FINALIZA_SECTION();

                /*" -1439- END-IF */
            }


            /*" -1440- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -1444- DISPLAY 'ALTERANDO VIG.PROP: ' CBAPOVIG-NUM-APOLICE ' END ' CBAPOVIG-NUM-ENDOSSO ' PARC ' CBAPOVIG-NUM-PARCELA */

                $"ALTERANDO VIG.PROP: {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE} END {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO} PARC {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA}"
                .Display();

                /*" -1450- PERFORM P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1 */

                P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1();

                /*" -1453- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -1457- DISPLAY 'APOLICE ' CBAPOVIG-NUM-APOLICE ' ENDOSSO ' CBAPOVIG-NUM-ENDOSSO ' PARCELA ' CBAPOVIG-NUM-PARCELA */

                    $"APOLICE {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE} ENDOSSO {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO} PARCELA {CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA}"
                    .Display();

                    /*" -1459- MOVE 'ERRO NA ATUALIZACAO TABELA .CB_APOLICE_VIGPROP' TO WS-MSG */
                    _.Move("ERRO NA ATUALIZACAO TABELA .CB_APOLICE_VIGPROP", WS_MSG);

                    /*" -1460- PERFORM P9000-00-FINALIZA */

                    P9000_00_FINALIZA_SECTION();

                    /*" -1461- END-IF */
                }


                /*" -1462- ELSE */
            }
            else
            {


                /*" -1463- MOVE 1 TO WS-FIM-LE-CURSOR */
                _.Move(1, WS_FIM_LE_CURSOR);

                /*" -1463- END-IF. */
            }


        }

        [StopWatch]
        /*" P2200-00-LE-CUR-PARCELA-PAGA-DB-FETCH-1 */
        public void P2200_00_LE_CUR_PARCELA_PAGA_DB_FETCH_1()
        {
            /*" -1431- EXEC SQL FETCH NEXT CUR_PARCELA_PAGA INTO :CBAPOVIG-NUM-APOLICE ,:CBAPOVIG-NUM-ENDOSSO ,:CBAPOVIG-NUM-PARCELA END-EXEC */

            if (CUR_PARCELA_PAGA.Fetch())
            {
                _.Move(CUR_PARCELA_PAGA.CBAPOVIG_NUM_APOLICE, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE);
                _.Move(CUR_PARCELA_PAGA.CBAPOVIG_NUM_ENDOSSO, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO);
                _.Move(CUR_PARCELA_PAGA.CBAPOVIG_NUM_PARCELA, CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA);
            }

        }

        [StopWatch]
        /*" P2200-00-LE-CUR-PARCELA-PAGA-DB-UPDATE-1 */
        public void P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1()
        {
            /*" -1450- EXEC SQL UPDATE SEGUROS.CB_APOLICE_VIGPROP SET SITUACAO = '2' WHERE NUM_APOLICE = :CBAPOVIG-NUM-APOLICE AND NUM_ENDOSSO = :CBAPOVIG-NUM-ENDOSSO AND NUM_PARCELA = :CBAPOVIG-NUM-PARCELA END-EXEC */

            var p2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1 = new P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1()
            {
                CBAPOVIG_NUM_APOLICE = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_APOLICE.ToString(),
                CBAPOVIG_NUM_ENDOSSO = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_ENDOSSO.ToString(),
                CBAPOVIG_NUM_PARCELA = CBAPOVIG.DCLCB_APOLICE_VIGPROP.CBAPOVIG_NUM_PARCELA.ToString(),
            };

            P2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1.Execute(p2200_00_LE_CUR_PARCELA_PAGA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P2200_99_FIM*/

        [StopWatch]
        /*" P9000-00-FINALIZA-SECTION */
        private void P9000_00_FINALIZA_SECTION()
        {
            /*" -1473- CLOSE CB1280S01 */
            CB1280S01.Close();

            /*" -1474- CLOSE CB1280S02 */
            CB1280S02.Close();

            /*" -1476- CLOSE CB1280S03 */
            CB1280S03.Close();

            /*" -1477- IF WS-MSG = SPACES */

            if (WS_MSG.IsEmpty())
            {

                /*" -1480- MOVE 'OPERACAO EFETUADA COM SUCESSO' TO WS-MSG */
                _.Move("OPERACAO EFETUADA COM SUCESSO", WS_MSG);

                /*" -1480- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -1484- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -1485- ELSE */
            }
            else
            {


                /*" -1487- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_DISPLAY.WS_SQLCODE);

                /*" -1489- DISPLAY WS-DISPLAY */
                _.Display(WS_DISPLAY);

                /*" -1489- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -1492- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -1494- END-IF */
            }


            /*" -1496- DISPLAY 'MENSAGEM: ' WS-MSG */
            _.Display($"MENSAGEM: {WS_MSG}");

            /*" -1498- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -1501- DISPLAY 'DATA TERMINO: ' WS-DT-TODAY ' - HORA TERMINO: ' WS-HR-TODAY */

            $"DATA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_DT_TODAY} - HORA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_TODAY}"
            .Display();

            /*" -1506- COMPUTE WS-SEG-FINAL = (WS-HR-HOR * 60 * 60) + (WS-HR-MIN * 60) + WS-HR-SEG + (WS-HR-DECSEG / 100) */
            WS_SEG_FINAL.Value = (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_54.WS_HR_HOR * 60 * 60) + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_54.WS_HR_MIN * 60) + WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_54.WS_HR_SEG + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_DECSEG / 100f);

            /*" -1508- SUBTRACT WS-SEG-INICIAL FROM WS-SEG-FINAL */
            WS_SEG_FINAL.Value = WS_SEG_FINAL - WS_SEG_INICIAL;

            /*" -1510- MOVE WS-SEG-FINAL TO WS-TOT-TIME-ED */
            _.Move(WS_SEG_FINAL, WS_TOT_TIME_ED);

            /*" -1512- DISPLAY 'TEMPO SEG: ' WS-TOT-TIME-ED */
            _.Display($"TEMPO SEG: {WS_TOT_TIME_ED}");

            /*" -1514- COMPUTE WS-SEG-FINAL = WS-SEG-FINAL / 60 */
            WS_SEG_FINAL.Value = WS_SEG_FINAL / 60f;

            /*" -1516- MOVE WS-SEG-FINAL TO WS-TOT-TIME-ED */
            _.Move(WS_SEG_FINAL, WS_TOT_TIME_ED);

            /*" -1518- DISPLAY 'TEMPO MIN: ' WS-TOT-TIME-ED */
            _.Display($"TEMPO MIN: {WS_TOT_TIME_ED}");

            /*" -1518- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P9000_99_FIM*/
    }
}