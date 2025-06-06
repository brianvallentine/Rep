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
using Sias.Cobranca.DB2.CB0110B;

namespace Code
{
    public class CB0110B
    {
        public bool IsCall { get; set; }

        public CB0110B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  CB0110B                            *      */
        /*"      *   ANALISTA ...............  LISIANE BRAGANCA SOARES            *      */
        /*"      *   DATA CODIFICACAO .......  06/09/2018                         *      */
        /*"      *   CADMUS .................  166550                             *      */
        /*"      *   FUNCAO .................  GERAR DEVOLUCAO DE FOLLOW-UP POR   *      */
        /*"      *                             SITUACAO DE PARCELA CANCELADA      *      */
        /*"      *                             PARA OS PRODUTO AUTO TRANQUILO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      HISTORICO DE ALTERACAO                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.04  * EM 02/05/2024 - JAZZ 576989                                    *      */
        /*"      *               - CORRIGIR MOVIMENTO DO CEP PARA ODS.            *      */
        /*"      *                 DE INTEGER  PARA  CHAR.                        *      */
        /*"      *               - HERVAL SOUZA - ACT                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * EM 25/06/2019 - JAZZ 199602                                    *      */
        /*"      *               - ALTERADO PARA OS PRODUTOS CCA E LOTERICO       *      */
        /*"      *               - LISIANE BRAGANCA SOARES                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * EM 24/01/2019 - JAZZ 189479                                    *      */
        /*"      *               - NAO PERMITIR REENVIO DE CREDITO                *      */
        /*"      *               - LISIANE BRAGANCA SOARES                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * EM 13/11/2018 - LISIANE BRAGANCA SOARES                        *      */
        /*"      *                 ACERTO NA LEITURA DA TABELA MOVTO_DEBITOCC_CEF *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _CB0110S01 { get; set; } = new FileBasis(new PIC("X", "205", "X(205)"));

        public FileBasis CB0110S01
        {
            get
            {
                _.Move(S01_REGISTRO, _CB0110S01); VarBasis.RedefinePassValue(S01_REGISTRO, _CB0110S01, S01_REGISTRO); return _CB0110S01;
            }
        }
        /*"01 S01-REGISTRO.*/
        public CB0110B_S01_REGISTRO S01_REGISTRO { get; set; } = new CB0110B_S01_REGISTRO();
        public class CB0110B_S01_REGISTRO : VarBasis
        {
            /*"   05 S01-COD-FONTE               PIC 9(04).*/
            public IntBasis S01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NUM-APOLICE             PIC 9(13).*/
            public IntBasis S01_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NUM-ENDOSSO             PIC 9(06).*/
            public IntBasis S01_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NUM-PARCELA             PIC 9(02).*/
            public IntBasis S01_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-COD-CLIENTE             PIC 9(09).*/
            public IntBasis S01_COD_CLIENTE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NOME-RAZAO              PIC X(50).*/
            public StringBasis S01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-COD-BANCO               PIC 9(04).*/
            public IntBasis S01_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-COD-OPERACAO            PIC 9(04).*/
            public IntBasis S01_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-COD-AGENCIA             PIC X(04).*/
            public StringBasis S01_COD_AGENCIA { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-COD-AGENCIA-DV          PIC X(01).*/
            public StringBasis S01_COD_AGENCIA_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NUM-CONTA               PIC 9(12).*/
            public IntBasis S01_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NUM-CONTA-DV            PIC X(01).*/
            public StringBasis S01_NUM_CONTA_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-NUM-CHEQUE-INT          PIC 9(09).*/
            public IntBasis S01_NUM_CHEQUE_INT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-VLR-OPERACAO            PIC ZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis S01_VLR_OPERACAO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"   05 S01-MENSAGEM                PIC X(50).*/
            public StringBasis S01_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"   05 FILLER                      PIC X(01).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-FLAG-1                      PIC 9(01) VALUE ZEROS.*/
        public IntBasis WS_FLAG_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
        /*"77 WS-QT-LIDOS                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-REJEI                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_REJEI { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-DEVPR                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_DEVPR { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-DEVCC                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_DEVCC { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-DEVCH                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_DEVCH { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-921286                   PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_921286 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-900662                   PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_900662 { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-CHEMI                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_CHEMI { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-PESSO                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_PESSO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-LEGAD                    PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_LEGAD { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-IMPR                     PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_IMPR { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-PROCES                   PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_PROCES { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-DEBITO                   PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_DEBITO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-QT-BOLETO                   PIC 9(07) VALUE ZEROS.*/
        public IntBasis WS_QT_BOLETO { get; set; } = new IntBasis(new PIC("9", "7", "9(07)"));
        /*"77 WS-FIM-LE-CURSOR               PIC 9(06) VALUE ZEROS.*/
        public IntBasis WS_FIM_LE_CURSOR { get; set; } = new IntBasis(new PIC("9", "6", "9(06)"));
        /*"77 WS-GERA-CHEQUE                 PIC X(01) VALUE SPACES.*/
        public StringBasis WS_GERA_CHEQUE { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
        /*"77 WS-NRSEQ                       PIC 9(09) VALUE ZEROS.*/
        public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
        /*"77 WS-MENSAGEM                    PIC X(50) VALUE SPACES.*/
        public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "50", "X(50)"), @"");
        /*"77 WS-QT-MOVTO                    PIC S9(9) COMP VALUE ZEROS.*/
        public IntBasis WS_QT_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77 WS-IND1                        PIC S9(9) COMP VALUE ZEROS.*/
        public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77 WS-IND2                        PIC S9(9) COMP VALUE ZEROS.*/
        public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"77 VIND-CODEMP                    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-CODFAV                    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_CODFAV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-VLINSS                    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_VLINSS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DTEMIS                    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DTEMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DTCOMPE                   PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DTCOMPE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-DTCANCEL                  PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_DTCANCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 VIND-CODUSU                    PIC S9(04) VALUE +0 COMP.*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-PARM01-AUX                  PIC S9(09) VALUE +0 COMP-3.*/
        public IntBasis WS_PARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77 WS-QUOCIENTE                   PIC S9(04) VALUE +0 COMP-3.*/
        public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-RESTO                       PIC S9(04) VALUE +0 COMP-3.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77 WS-SEG-INICIAL                 PIC S9(08)V9(4) VALUE 0.*/
        public DoubleBasis WS_SEG_INICIAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)"), 4);
        /*"77 WS-SEG-FINAL                   PIC S9(08)V9(4) VALUE 0.*/
        public DoubleBasis WS_SEG_FINAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(4)"), 4);
        /*"77 WS-TOT-TIME-ED                 PIC ZZZ.ZZ9,9999-.*/
        public DoubleBasis WS_TOT_TIME_ED { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V9999-."), 5);
        /*"77 STATUS-S01                     PIC X(02) VALUE ZEROS.*/

        public SelectorBasis STATUS_S01 { get; set; } = new SelectorBasis("02", "ZEROS")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88 STATUS-FIM-S01              VALUE '10'. */
							new SelectorItemBasis("STATUS_FIM_S01", "10"),
							/*" 88 STATUS-OK-S01               VALUE '00' '97'. */
							new SelectorItemBasis("STATUS_OK_S01", "00"),
							/*" 88 STATUS-DUP-S01              VALUE '22'. */
							new SelectorItemBasis("STATUS_DUP_S01", "22"),
							/*" 88 STATUS-INE-S01              VALUE '23'. */
							new SelectorItemBasis("STATUS_INE_S01", "23")
                }
        };

        /*"01 WS-VARIAVEIS.*/
        public CB0110B_WS_VARIAVEIS WS_VARIAVEIS { get; set; } = new CB0110B_WS_VARIAVEIS();
        public class CB0110B_WS_VARIAVEIS : VarBasis
        {
            /*"   05 WS-DESCRICAO-S01.*/
            public CB0110B_WS_DESCRICAO_S01 WS_DESCRICAO_S01 { get; set; } = new CB0110B_WS_DESCRICAO_S01();
            public class CB0110B_WS_DESCRICAO_S01 : VarBasis
            {
                /*"      10 FILLER                   PIC X(06) VALUE 'FONTE;'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FONTE;");
                /*"      10 FILLER                   PIC X(08) VALUE 'APOLICE;'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"APOLICE;");
                /*"      10 FILLER                   PIC X(08) VALUE 'ENDOSSO;'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDOSSO;");
                /*"      10 FILLER                   PIC X(08) VALUE 'PARCELA;'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"PARCELA;");
                /*"      10 FILLER                   PIC X(08) VALUE 'CLIENTE;'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"CLIENTE;");
                /*"      10 FILLER                   PIC X(13) VALUE         'NOME CLIENTE;'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"NOME CLIENTE;");
                /*"      10 FILLER                   PIC X(06) VALUE 'BANCO;'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BANCO;");
                /*"      10 FILLER                   PIC X(09) VALUE 'OPERACAO;'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"OPERACAO;");
                /*"      10 FILLER                   PIC X(08) VALUE 'AGENCIA;'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"AGENCIA;");
                /*"      10 FILLER                   PIC X(11) VALUE 'DV-AGENCIA;'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"DV-AGENCIA;");
                /*"      10 FILLER                   PIC X(06) VALUE 'CONTA;'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CONTA;");
                /*"      10 FILLER                   PIC X(09) VALUE 'CONTA-DV;'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"CONTA-DV;");
                /*"      10 FILLER                   PIC X(12) VALUE 'NUM. CHEQUE;'*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "12", "X(12)"), @"NUM. CHEQUE;");
                /*"      10 FILLER                   PIC X(06) VALUE 'VALOR;'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"VALOR;");
                /*"      10 FILLER                   PIC X(08) VALUE 'MENSAGEM'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"MENSAGEM");
                /*"   05 WS-CHQINT.*/
            }
            public CB0110B_WS_CHQINT WS_CHQINT { get; set; } = new CB0110B_WS_CHQINT();
            public class CB0110B_WS_CHQINT : VarBasis
            {
                /*"      10 WS-NUMCHQ                PIC 9(09).*/
                public IntBasis WS_NUMCHQ { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"      10 FILLER                   PIC X(01) VALUE '-'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10 WS-DIGCHQ                PIC 9(01).*/
                public IntBasis WS_DIGCHQ { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"   05 WDATA-REL                   PIC X(10) VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"   05 FILLER REDEFINES WDATA-REL.*/
            private _REDEF_CB0110B_FILLER_31 _filler_31 { get; set; }
            public _REDEF_CB0110B_FILLER_31 FILLER_31
            {
                get { _filler_31 = new _REDEF_CB0110B_FILLER_31(); _.Move(WDATA_REL, _filler_31); VarBasis.RedefinePassValue(WDATA_REL, _filler_31, WDATA_REL); _filler_31.ValueChanged += () => { _.Move(_filler_31, WDATA_REL); }; return _filler_31; }
                set { VarBasis.RedefinePassValue(value, _filler_31, WDATA_REL); }
            }  //Redefines
            public class _REDEF_CB0110B_FILLER_31 : VarBasis
            {
                /*"      10 WDAT-REL-ANO             PIC 9(04).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 FILLER                   PIC X(01).*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WDAT-REL-MES             PIC 9(02).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 FILLER                   PIC X(01).*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"      10 WDAT-REL-DIA             PIC 9(02).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-NUMREC                   PIC 9(08) VALUE ZEROS.*/

                public _REDEF_CB0110B_FILLER_31()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_32.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_33.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NUMREC { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"   05 FILLER REDEFINES WS-NUMREC.*/
            private _REDEF_CB0110B_FILLER_34 _filler_34 { get; set; }
            public _REDEF_CB0110B_FILLER_34 FILLER_34
            {
                get { _filler_34 = new _REDEF_CB0110B_FILLER_34(); _.Move(WS_NUMREC, _filler_34); VarBasis.RedefinePassValue(WS_NUMREC, _filler_34, WS_NUMREC); _filler_34.ValueChanged += () => { _.Move(_filler_34, WS_NUMREC); }; return _filler_34; }
                set { VarBasis.RedefinePassValue(value, _filler_34, WS_NUMREC); }
            }  //Redefines
            public class _REDEF_CB0110B_FILLER_34 : VarBasis
            {
                /*"      10 WS-REC-ANO               PIC 9(04).*/
                public IntBasis WS_REC_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10 WS-REC-MES               PIC 9(02).*/
                public IntBasis WS_REC_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10 WS-REC-DIA               PIC 9(02).*/
                public IntBasis WS_REC_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-02.*/

                public _REDEF_CB0110B_FILLER_34()
                {
                    WS_REC_ANO.ValueChanged += OnValueChanged;
                    WS_REC_MES.ValueChanged += OnValueChanged;
                    WS_REC_DIA.ValueChanged += OnValueChanged;
                }

            }
            public CB0110B_WS_02 WS_02 { get; set; } = new CB0110B_WS_02();
            public class CB0110B_WS_02 : VarBasis
            {
                /*"      10 WS-02-NRTIT              PIC 9(11).*/
                public IntBasis WS_02_NRTIT { get; set; } = new IntBasis(new PIC("9", "11", "9(11)."));
                /*"   05 WS-03.*/
            }
            public CB0110B_WS_03 WS_03 { get; set; } = new CB0110B_WS_03();
            public class CB0110B_WS_03 : VarBasis
            {
                /*"      10 WS-03-NUMAPOL            PIC 9(13).*/
                public IntBasis WS_03_NUMAPOL { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"   05 LPARM01                     PIC 9(15) VALUE ZEROS.*/
            }
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(15)"));
            /*"   05 FILLER REDEFINES LPARM01.*/
            private _REDEF_CB0110B_FILLER_35 _filler_35 { get; set; }
            public _REDEF_CB0110B_FILLER_35 FILLER_35
            {
                get { _filler_35 = new _REDEF_CB0110B_FILLER_35(); _.Move(LPARM01, _filler_35); VarBasis.RedefinePassValue(LPARM01, _filler_35, LPARM01); _filler_35.ValueChanged += () => { _.Move(_filler_35, LPARM01); }; return _filler_35; }
                set { VarBasis.RedefinePassValue(value, _filler_35, LPARM01); }
            }  //Redefines
            public class _REDEF_CB0110B_FILLER_35 : VarBasis
            {
                /*"      10 LPARM01-01               PIC 9(01).*/
                public IntBasis LPARM01_01 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-02               PIC 9(01).*/
                public IntBasis LPARM01_02 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-03               PIC 9(01).*/
                public IntBasis LPARM01_03 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-04               PIC 9(01).*/
                public IntBasis LPARM01_04 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-05               PIC 9(01).*/
                public IntBasis LPARM01_05 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-06               PIC 9(01).*/
                public IntBasis LPARM01_06 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-07               PIC 9(01).*/
                public IntBasis LPARM01_07 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-08               PIC 9(01).*/
                public IntBasis LPARM01_08 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-09               PIC 9(01).*/
                public IntBasis LPARM01_09 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-10               PIC 9(01).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-11               PIC 9(01).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-12               PIC 9(01).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-13               PIC 9(01).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-14               PIC 9(01).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"      10 LPARM01-15               PIC 9(01).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(01)."));
                /*"   05 W-NUM-CGC-INT-A             PIC 9(14) VALUE ZEROS.*/

                public _REDEF_CB0110B_FILLER_35()
                {
                    LPARM01_01.ValueChanged += OnValueChanged;
                    LPARM01_02.ValueChanged += OnValueChanged;
                    LPARM01_03.ValueChanged += OnValueChanged;
                    LPARM01_04.ValueChanged += OnValueChanged;
                    LPARM01_05.ValueChanged += OnValueChanged;
                    LPARM01_06.ValueChanged += OnValueChanged;
                    LPARM01_07.ValueChanged += OnValueChanged;
                    LPARM01_08.ValueChanged += OnValueChanged;
                    LPARM01_09.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_CGC_INT_A { get; set; } = new IntBasis(new PIC("9", "14", "9(14)"));
            /*"   05 W-NUM-CGC-INT REDEFINES W-NUM-CGC-INT-A.*/
            private _REDEF_CB0110B_W_NUM_CGC_INT _w_num_cgc_int { get; set; }
            public _REDEF_CB0110B_W_NUM_CGC_INT W_NUM_CGC_INT
            {
                get { _w_num_cgc_int = new _REDEF_CB0110B_W_NUM_CGC_INT(); _.Move(W_NUM_CGC_INT_A, _w_num_cgc_int); VarBasis.RedefinePassValue(W_NUM_CGC_INT_A, _w_num_cgc_int, W_NUM_CGC_INT_A); _w_num_cgc_int.ValueChanged += () => { _.Move(_w_num_cgc_int, W_NUM_CGC_INT_A); }; return _w_num_cgc_int; }
                set { VarBasis.RedefinePassValue(value, _w_num_cgc_int, W_NUM_CGC_INT_A); }
            }  //Redefines
            public class _REDEF_CB0110B_W_NUM_CGC_INT : VarBasis
            {
                /*"      10 W-NUM-CGC-INT-NUM        PIC  9(008).*/
                public IntBasis W_NUM_CGC_INT_NUM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10 W-NUM-CGC-INT-FILIAL     PIC  9(004).*/
                public IntBasis W_NUM_CGC_INT_FILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 W-NUM-CGC-INT-DV         PIC  9(002).*/
                public IntBasis W_NUM_CGC_INT_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05 W-NUM-CPF-INT-A             PIC 9(11) VALUE ZEROS.*/

                public _REDEF_CB0110B_W_NUM_CGC_INT()
                {
                    W_NUM_CGC_INT_NUM.ValueChanged += OnValueChanged;
                    W_NUM_CGC_INT_FILIAL.ValueChanged += OnValueChanged;
                    W_NUM_CGC_INT_DV.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_CPF_INT_A { get; set; } = new IntBasis(new PIC("9", "11", "9(11)"));
            /*"   05 W-NUM-CPF-INT REDEFINES W-NUM-CPF-INT-A.*/
            private _REDEF_CB0110B_W_NUM_CPF_INT _w_num_cpf_int { get; set; }
            public _REDEF_CB0110B_W_NUM_CPF_INT W_NUM_CPF_INT
            {
                get { _w_num_cpf_int = new _REDEF_CB0110B_W_NUM_CPF_INT(); _.Move(W_NUM_CPF_INT_A, _w_num_cpf_int); VarBasis.RedefinePassValue(W_NUM_CPF_INT_A, _w_num_cpf_int, W_NUM_CPF_INT_A); _w_num_cpf_int.ValueChanged += () => { _.Move(_w_num_cpf_int, W_NUM_CPF_INT_A); }; return _w_num_cpf_int; }
                set { VarBasis.RedefinePassValue(value, _w_num_cpf_int, W_NUM_CPF_INT_A); }
            }  //Redefines
            public class _REDEF_CB0110B_W_NUM_CPF_INT : VarBasis
            {
                /*"      10 W-NUM-CPF-INT-NUM        PIC 9(09).*/
                public IntBasis W_NUM_CPF_INT_NUM { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"      10 W-NUM-CPF-INT-DV         PIC 9(02).*/
                public IntBasis W_NUM_CPF_INT_DV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05 WS-AGENC01.*/

                public _REDEF_CB0110B_W_NUM_CPF_INT()
                {
                    W_NUM_CPF_INT_NUM.ValueChanged += OnValueChanged;
                    W_NUM_CPF_INT_DV.ValueChanged += OnValueChanged;
                }

            }
            public CB0110B_WS_AGENC01 WS_AGENC01 { get; set; } = new CB0110B_WS_AGENC01();
            public class CB0110B_WS_AGENC01 : VarBasis
            {
                /*"      10 WS-AGENC-AG              PIC X(04) VALUE SPACES.*/
                public StringBasis WS_AGENC_AG { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
                /*"      10 WS-AGENC-DV              PIC X(01) VALUE SPACES.*/
                public StringBasis WS_AGENC_DV { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                /*"   05 WS-AGENC10                  PIC X(04) VALUE SPACES.*/
            }
            public StringBasis WS_AGENC10 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"   05 FILLER  REDEFINES WS-AGENC10.*/
            private _REDEF_CB0110B_FILLER_36 _filler_36 { get; set; }
            public _REDEF_CB0110B_FILLER_36 FILLER_36
            {
                get { _filler_36 = new _REDEF_CB0110B_FILLER_36(); _.Move(WS_AGENC10, _filler_36); VarBasis.RedefinePassValue(WS_AGENC10, _filler_36, WS_AGENC10); _filler_36.ValueChanged += () => { _.Move(_filler_36, WS_AGENC10); }; return _filler_36; }
                set { VarBasis.RedefinePassValue(value, _filler_36, WS_AGENC10); }
            }  //Redefines
            public class _REDEF_CB0110B_FILLER_36 : VarBasis
            {
                /*"      10 CHAR10 OCCURS 4 TIMES   PIC X(01).*/
                public ListBasis<StringBasis, string> CHAR10 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)."), 4);
                /*"   05 WS-AGENC20                  PIC 9(04).*/

                public _REDEF_CB0110B_FILLER_36()
                {
                    CHAR10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_AGENC20 { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05 FILLER  REDEFINES WS-AGENC20.*/
            private _REDEF_CB0110B_FILLER_37 _filler_37 { get; set; }
            public _REDEF_CB0110B_FILLER_37 FILLER_37
            {
                get { _filler_37 = new _REDEF_CB0110B_FILLER_37(); _.Move(WS_AGENC20, _filler_37); VarBasis.RedefinePassValue(WS_AGENC20, _filler_37, WS_AGENC20); _filler_37.ValueChanged += () => { _.Move(_filler_37, WS_AGENC20); }; return _filler_37; }
                set { VarBasis.RedefinePassValue(value, _filler_37, WS_AGENC20); }
            }  //Redefines
            public class _REDEF_CB0110B_FILLER_37 : VarBasis
            {
                /*"      10 CHAR20 OCCURS 4 TIMES   PIC X(01).*/
                public ListBasis<StringBasis, string> CHAR20 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)."), 4);
                /*"   05 WS-DIG-CONTA-DEB           PIC X(04) VALUE SPACES.*/

                public _REDEF_CB0110B_FILLER_37()
                {
                    CHAR20.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DIG_CONTA_DEB { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"");
            /*"   05 FILLER REDEFINES WS-DIG-CONTA-DEB.*/
            private _REDEF_CB0110B_FILLER_38 _filler_38 { get; set; }
            public _REDEF_CB0110B_FILLER_38 FILLER_38
            {
                get { _filler_38 = new _REDEF_CB0110B_FILLER_38(); _.Move(WS_DIG_CONTA_DEB, _filler_38); VarBasis.RedefinePassValue(WS_DIG_CONTA_DEB, _filler_38, WS_DIG_CONTA_DEB); _filler_38.ValueChanged += () => { _.Move(_filler_38, WS_DIG_CONTA_DEB); }; return _filler_38; }
                set { VarBasis.RedefinePassValue(value, _filler_38, WS_DIG_CONTA_DEB); }
            }  //Redefines
            public class _REDEF_CB0110B_FILLER_38 : VarBasis
            {
                /*"      10 WS-DIG-CONTA-DEB-1      PIC X(03).*/
                public StringBasis WS_DIG_CONTA_DEB_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                /*"      10 WS-DIG-CONTA-DEB-2      PIC X(01).*/
                public StringBasis WS_DIG_CONTA_DEB_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"01 LK-PF-PARAMETRO.*/

                public _REDEF_CB0110B_FILLER_38()
                {
                    WS_DIG_CONTA_DEB_1.ValueChanged += OnValueChanged;
                    WS_DIG_CONTA_DEB_2.ValueChanged += OnValueChanged;
                }

            }
        }
        public CB0110B_LK_PF_PARAMETRO LK_PF_PARAMETRO { get; set; } = new CB0110B_LK_PF_PARAMETRO();
        public class CB0110B_LK_PF_PARAMETRO : VarBasis
        {
            /*"   05 LK-PF-TIPO-UTILIZACAO       PIC  9(001).*/
            public IntBasis LK_PF_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-PF-PESSOA-ESPECIAL       PIC  X(001).*/
            public StringBasis LK_PF_PESSOA_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-PROGRAMA-CHAMADOR     PIC  X(008).*/
            public StringBasis LK_PF_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PF-NOME-USUARIO          PIC  X(008).*/
            public StringBasis LK_PF_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PF-NUM-PESSOA            PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PF-DTH-CADASTRAMENTO     PIC  X(026).*/
            public StringBasis LK_PF_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-PF-NUM-DV-PESSOA         PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-IND-PESSOA            PIC  X(001).*/
            public StringBasis LK_PF_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-STA-INF-INTEGRA       PIC  X(001).*/
            public StringBasis LK_PF_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-NUM-CPF               PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PF-NUM-DV-CPF            PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_DV_CPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-NOM-PESSOA            PIC  X(200).*/
            public StringBasis LK_PF_NOM_PESSOA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"   05 LK-PF-DTH-NASCIMENTO        PIC  X(010).*/
            public StringBasis LK_PF_DTH_NASCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-PF-STA-SEXO              PIC  X(001).*/
            public StringBasis LK_PF_STA_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-IND-ESTADO-CIVIL      PIC  X(001).*/
            public StringBasis LK_PF_IND_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-STA-PESSOA            PIC  X(001).*/
            public StringBasis LK_PF_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PF-NOM-TRATAMENTO        PIC  X(015).*/
            public StringBasis LK_PF_NOM_TRATAMENTO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"   05 LK-PF-COD-UF                PIC  X(002).*/
            public StringBasis LK_PF_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-PF-NUM-MUNICIPIO         PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PF-NUM-INSC-SOCIAL       PIC S9(010)V USAGE COMP-3.*/
            public DoubleBasis LK_PF_NUM_INSC_SOCIAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V"), 0);
            /*"   05 LK-PF-NUM-DV-INSC-SOCIAL    PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_DV_INSC_SOCIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-NUM-GRAU-INSTRUCAO    PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PF_NUM_GRAU_INSTRUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PF-NOM-REDUZIDO          PIC  X(025).*/
            public StringBasis LK_PF_NOM_REDUZIDO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05 LK-PF-COD-CBO               PIC  X(010).*/
            public StringBasis LK_PF_COD_CBO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-PF-NOM-PRIMEIRO          PIC  X(025).*/
            public StringBasis LK_PF_NOM_PRIMEIRO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05 LK-PF-NOM-ULTIMO            PIC  X(025).*/
            public StringBasis LK_PF_NOM_ULTIMO { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"   05 LK-PF-PARAMETROS-SAIDA.*/
            public CB0110B_LK_PF_PARAMETROS_SAIDA LK_PF_PARAMETROS_SAIDA { get; set; } = new CB0110B_LK_PF_PARAMETROS_SAIDA();
            public class CB0110B_LK_PF_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-PF-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_PF_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PF-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_PF_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-PF-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_PF_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PF-SQLCODE            PIC S9(004)  COMP.*/
                public IntBasis LK_PF_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-PF-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_PF_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-PJ-PARAMETRO.*/
            }
        }
        public CB0110B_LK_PJ_PARAMETRO LK_PJ_PARAMETRO { get; set; } = new CB0110B_LK_PJ_PARAMETRO();
        public class CB0110B_LK_PJ_PARAMETRO : VarBasis
        {
            /*"   05 LK-PJ-TIPO-UTILIZACAO       PIC  9(001).*/
            public IntBasis LK_PJ_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-PJ-PESSOA-ESPECIAL       PIC  X(001).*/
            public StringBasis LK_PJ_PESSOA_ESPECIAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-PROGRAMA-CHAMADOR     PIC  X(008).*/
            public StringBasis LK_PJ_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PJ-NOME-USUARIO          PIC  X(008).*/
            public StringBasis LK_PJ_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-PJ-NUM-PESSOA            PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-DTH-CADASTRAMENTO     PIC X(026).*/
            public StringBasis LK_PJ_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-PJ-NUM-DV-PESSOA         PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-IND-PESSOA            PIC X(001).*/
            public StringBasis LK_PJ_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-STA-INF-INTEGRA       PIC X(001).*/
            public StringBasis LK_PJ_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-NUM-CNPJ              PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_CNPJ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-NUM-FILIAL            PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_FILIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-NUM-DV-CNPJ           PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_DV_CNPJ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-NOM-RAZAO-SOCIAL      PIC  X(200).*/
            public StringBasis LK_PJ_NOM_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"   05 LK-PJ-STA-PESSOA            PIC  X(001).*/
            public StringBasis LK_PJ_STA_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-NUM-RAMO-ATIVIDADE    PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-DTH-FUNDACAO          PIC  X(010).*/
            public StringBasis LK_PJ_DTH_FUNDACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-PJ-NOM-FANTASIA          PIC  X(100).*/
            public StringBasis LK_PJ_NOM_FANTASIA { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"   05 LK-PJ-NOM-SIGLA-PESSOA      PIC  X(040).*/
            public StringBasis LK_PJ_NOM_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"   05 LK-PJ-NUM-INSC-ESTADUAL     PIC S9(014)V USAGE COMP-3.*/
            public DoubleBasis LK_PJ_NUM_INSC_ESTADUAL { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(014)V"), 0);
            /*"   05 LK-PJ-NUM-INSC-MUNICIPAL    PIC S9(014)V USAGE COMP-3.*/
            public DoubleBasis LK_PJ_NUM_INSC_MUNICIPAL { get; set; } = new DoubleBasis(new PIC("S9", "14", "S9(014)V"), 0);
            /*"   05 LK-PJ-COD-UF                PIC  X(002).*/
            public StringBasis LK_PJ_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-PJ-NUM-MUNICIPIO         PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_MUNICIPIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-PJ-COD-CNAE              PIC  X(020).*/
            public StringBasis LK_PJ_COD_CNAE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"   05 LK-PJ-NUM-SOCIOS            PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_PJ_NUM_SOCIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-PJ-STA-FRANQUIA          PIC  X(001).*/
            public StringBasis LK_PJ_STA_FRANQUIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-IND-FINALIDADE        PIC  X(001).*/
            public StringBasis LK_PJ_IND_FINALIDADE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-PJ-PARAMETROS-SAIDA.*/
            public CB0110B_LK_PJ_PARAMETROS_SAIDA LK_PJ_PARAMETROS_SAIDA { get; set; } = new CB0110B_LK_PJ_PARAMETROS_SAIDA();
            public class CB0110B_LK_PJ_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-PJ-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_PJ_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PJ-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_PJ_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-PJ-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_PJ_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-PJ-SQLCODE            PIC S9(004)  COMP.*/
                public IntBasis LK_PJ_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-PJ-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_PJ_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-EN-PARAMETRO.*/
            }
        }
        public CB0110B_LK_EN_PARAMETRO LK_EN_PARAMETRO { get; set; } = new CB0110B_LK_EN_PARAMETRO();
        public class CB0110B_LK_EN_PARAMETRO : VarBasis
        {
            /*"   05 LK-EN-TIPO-UTILIZACAO       PIC  9(001).*/
            public IntBasis LK_EN_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-EN-PROGRAMA-CHAMADOR     PIC  X(008).*/
            public StringBasis LK_EN_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-EN-NOME-USUARIO          PIC  X(008).*/
            public StringBasis LK_EN_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-EN-NUM-PESSOA            PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_EN_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-EN-DTH-CADASTRAMENTO     PIC  X(026).*/
            public StringBasis LK_EN_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-EN-NUM-DV-PESSOA         PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_EN_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-EN-IND-PESSOA            PIC  X(001).*/
            public StringBasis LK_EN_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-STA-INF-INTEGRA       PIC  X(001).*/
            public StringBasis LK_EN_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-SEQ-ENDERECO          PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_EN_SEQ_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-EN-DTH-CADASTRAMENTO-END PIC X(026).*/
            public StringBasis LK_EN_DTH_CADASTRAMENTO_END { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-EN-IND-ENDERECO          PIC  X(001).*/
            public StringBasis LK_EN_IND_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-STA-ENDERECO          PIC  X(001).*/
            public StringBasis LK_EN_STA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-NOM-LOGRADOURO        PIC  X(072).*/
            public StringBasis LK_EN_NOM_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-DES-NUM-IMOVEL        PIC  X(010).*/
            public StringBasis LK_EN_DES_NUM_IMOVEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-EN-DES-COMPL-ENDERECO    PIC  X(072).*/
            public StringBasis LK_EN_DES_COMPL_ENDERECO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-NOM-BAIRRO            PIC  X(072).*/
            public StringBasis LK_EN_NOM_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-NOM-CIDADE            PIC  X(072).*/
            public StringBasis LK_EN_NOM_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"   05 LK-EN-COD-CEP               PIC  9(008).*/
            public IntBasis LK_EN_COD_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"   05 LK-EN-COD-UF                PIC  X(002).*/
            public StringBasis LK_EN_COD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-EN-STA-CORRESPONDER      PIC  X(001).*/
            public StringBasis LK_EN_STA_CORRESPONDER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-STA-PROPAGANDA        PIC  X(001).*/
            public StringBasis LK_EN_STA_PROPAGANDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-EN-PARAMETROS-SAIDA.*/
            public CB0110B_LK_EN_PARAMETROS_SAIDA LK_EN_PARAMETROS_SAIDA { get; set; } = new CB0110B_LK_EN_PARAMETROS_SAIDA();
            public class CB0110B_LK_EN_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-EN-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_EN_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-EN-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_EN_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-EN-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_EN_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-EN-SQLCODE            PIC S9(004)  COMP.*/
                public IntBasis LK_EN_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-EN-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_EN_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-BC-PARAMETRO.*/
            }
        }
        public CB0110B_LK_BC_PARAMETRO LK_BC_PARAMETRO { get; set; } = new CB0110B_LK_BC_PARAMETRO();
        public class CB0110B_LK_BC_PARAMETRO : VarBasis
        {
            /*"   05 LK-BC-TIPO-UTILIZACAO       PIC  9(001).*/
            public IntBasis LK_BC_TIPO_UTILIZACAO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"   05 LK-BC-PROGRAMA-CHAMADOR     PIC  X(008).*/
            public StringBasis LK_BC_PROGRAMA_CHAMADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-BC-NOME-USUARIO          PIC  X(008).*/
            public StringBasis LK_BC_NOME_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-BC-NUM-PESSOA            PIC S9(009)  USAGE COMP.*/
            public IntBasis LK_BC_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-BC-DTH-CADASTRAMENTO     PIC  X(026).*/
            public StringBasis LK_BC_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(026)."), @"");
            /*"   05 LK-BC-NUM-DV-PESSOA         PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_BC_NUM_DV_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-IND-PESSOA            PIC  X(001).*/
            public StringBasis LK_BC_IND_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-BC-STA-INF-INTEGRA       PIC  X(001).*/
            public StringBasis LK_BC_STA_INF_INTEGRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-BC-SEQ-CONTA-BANCARIA    PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_BC_SEQ_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-STA-CONTA             PIC  X(001).*/
            public StringBasis LK_BC_STA_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"   05 LK-BC-COD-BANCO             PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_BC_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-COD-AGENCIA           PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_BC_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-IND-CONTA-BANCARIA    PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_BC_IND_CONTA_BANCARIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-NUM-CONTA             PIC S9(013)  USAGE COMP-3.*/
            public IntBasis LK_BC_NUM_CONTA { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-BC-NUM-DV-CONTA          PIC  X(002).*/
            public StringBasis LK_BC_NUM_DV_CONTA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-BC-NUM-OPERACAO-CONTA    PIC S9(004)  USAGE COMP.*/
            public IntBasis LK_BC_NUM_OPERACAO_CONTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-BC-PARAMETROS-SAIDA.*/
            public CB0110B_LK_BC_PARAMETROS_SAIDA LK_BC_PARAMETROS_SAIDA { get; set; } = new CB0110B_LK_BC_PARAMETROS_SAIDA();
            public class CB0110B_LK_BC_PARAMETROS_SAIDA : VarBasis
            {
                /*"      10 LK-BC-MSG-ADICIONAL      PIC  X(080).*/
                public StringBasis LK_BC_MSG_ADICIONAL { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-BC-IND-ERRO           PIC  X(003).*/
                public StringBasis LK_BC_IND_ERRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"      10 LK-BC-MSG-ERRO           PIC  X(080).*/
                public StringBasis LK_BC_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
                /*"      10 LK-BC-SQLCODE            PIC S9(004) COMP.*/
                public IntBasis LK_BC_SQLCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-BC-NOME-TABELA        PIC  X(030).*/
                public StringBasis LK_BC_NOME_TABELA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01 LK-LEGADO-PARAMETRO.*/
            }
        }
        public CB0110B_LK_LEGADO_PARAMETRO LK_LEGADO_PARAMETRO { get; set; } = new CB0110B_LK_LEGADO_PARAMETRO();
        public class CB0110B_LK_LEGADO_PARAMETRO : VarBasis
        {
            /*"   05 LK-COD-OPERACAO             PIC S9(004) COMP.*/
            public IntBasis LK_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-APOLICE              PIC S9(013) COMP-3.*/
            public IntBasis LK_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-NUM-ENDOSSO              PIC S9(009) COMP.*/
            public IntBasis LK_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-NUM-PARCELA              PIC S9(004) COMP.*/
            public IntBasis LK_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-OCORR-HISTORICO          PIC S9(004) COMP.*/
            public IntBasis LK_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-PESSOA               PIC S9(009) COMP.*/
            public IntBasis LK_NUM_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-NUM-OCORR-MOVTO          PIC S9(009) COMP.*/
            public IntBasis LK_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-TABELA-PONTEIRO OCCURS 30 TIMES.*/
            public ListBasis<CB0110B_LK_TABELA_PONTEIRO> LK_TABELA_PONTEIRO { get; set; } = new ListBasis<CB0110B_LK_TABELA_PONTEIRO>(30);
            public class CB0110B_LK_TABELA_PONTEIRO : VarBasis
            {
                /*"      10 LK-IND-ENTIDADE-PEDIDA   PIC S9(004)  COMP.*/
                public IntBasis LK_IND_ENTIDADE_PEDIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"      10 LK-IND-INFORMACAO-PEDIDA PIC  X(001).*/
                public StringBasis LK_IND_INFORMACAO_PEDIDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 LK-SEQ-ENTIDADE          PIC S9(004)  COMP.*/
                public IntBasis LK_SEQ_ENTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"   05 LK-COD-EVENTO               PIC S9(004) COMP.*/
            }
            public IntBasis LK_COD_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-IDE-SISTEMA              PIC  X(002).*/
            public StringBasis LK_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"   05 LK-DTH-MOVIMENTO            PIC  X(010).*/
            public StringBasis LK_DTH_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"   05 LK-IND-ESTRUTURA            PIC S9(004) COMP.*/
            public IntBasis LK_IND_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-IND-ORIGEM-FUNC          PIC S9(004) COMP.*/
            public IntBasis LK_IND_ORIGEM_FUNC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-IND-EVENTO               PIC S9(004) COMP.*/
            public IntBasis LK_IND_EVENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NOM-PROGRAMA             PIC  X(008).*/
            public StringBasis LK_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-COD-USUARIO              PIC  X(008).*/
            public StringBasis LK_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-IND-RELACIONAMENTO       PIC S9(004) COMP.*/
            public IntBasis LK_IND_RELACIONAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-HORA-OPERACAO            PIC  X(008).*/
            public StringBasis LK_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"   05 LK-COD-FONTE                PIC S9(004) COMP.*/
            public IntBasis LK_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-RCAP                 PIC S9(009) COMP.*/
            public IntBasis LK_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"   05 LK-NUM-APOL-SINISTRO        PIC S9(013) COMP-3.*/
            public IntBasis LK_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 LK-COD-OPERACAO-SI          PIC S9(004) COMP.*/
            public IntBasis LK_COD_OPERACAO_SI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 LK-NUM-CERTIFICADO          PIC S9(015) COMP-3.*/
            public IntBasis LK_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"   05 LK-NUM-TITULO               PIC S9(013) COMP-3.*/
            public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05 H-OUT-COD-RETORNO           PIC S9(004) COMP.*/
            public IntBasis H_OUT_COD_RETORNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 H-OUT-COD-RETORNO-SQL       PIC S9(004) COMP.*/
            public IntBasis H_OUT_COD_RETORNO_SQL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 H-OUT-MENSAGEM              PIC X(070).*/
            public StringBasis H_OUT_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"   05 H-OUT-SQLERRMC              PIC X(070).*/
            public StringBasis H_OUT_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
            /*"   05 H-OUT-SQLSTATE              PIC X(005).*/
            public StringBasis H_OUT_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
            /*"77 WS-MSG                         PIC X(80) VALUE SPACES.*/
        }
        public StringBasis WS_MSG { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
        /*"01 WS-VARIAVEIS-GLOBAIS.*/
        public CB0110B_WS_VARIAVEIS_GLOBAIS WS_VARIAVEIS_GLOBAIS { get; set; } = new CB0110B_WS_VARIAVEIS_GLOBAIS();
        public class CB0110B_WS_VARIAVEIS_GLOBAIS : VarBasis
        {
            /*"   05 WS-CURRENT-DATE.*/
            public CB0110B_WS_CURRENT_DATE WS_CURRENT_DATE { get; set; } = new CB0110B_WS_CURRENT_DATE();
            public class CB0110B_WS_CURRENT_DATE : VarBasis
            {
                /*"      10 WS-DATE                  PIC X(16) VALUE SPACES.*/
                public StringBasis WS_DATE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"      10 WS-DATE-R REDEFINES WS-DATE.*/
                private _REDEF_CB0110B_WS_DATE_R _ws_date_r { get; set; }
                public _REDEF_CB0110B_WS_DATE_R WS_DATE_R
                {
                    get { _ws_date_r = new _REDEF_CB0110B_WS_DATE_R(); _.Move(WS_DATE, _ws_date_r); VarBasis.RedefinePassValue(WS_DATE, _ws_date_r, WS_DATE); _ws_date_r.ValueChanged += () => { _.Move(_ws_date_r, WS_DATE); }; return _ws_date_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_date_r, WS_DATE); }
                }  //Redefines
                public class _REDEF_CB0110B_WS_DATE_R : VarBasis
                {
                    /*"         15 WS-DT-TODAY           PIC 9(08).*/
                    public IntBasis WS_DT_TODAY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"         15 FILLER REDEFINES WS-DT-TODAY.*/
                    private _REDEF_CB0110B_FILLER_39 _filler_39 { get; set; }
                    public _REDEF_CB0110B_FILLER_39 FILLER_39
                    {
                        get { _filler_39 = new _REDEF_CB0110B_FILLER_39(); _.Move(WS_DT_TODAY, _filler_39); VarBasis.RedefinePassValue(WS_DT_TODAY, _filler_39, WS_DT_TODAY); _filler_39.ValueChanged += () => { _.Move(_filler_39, WS_DT_TODAY); }; return _filler_39; }
                        set { VarBasis.RedefinePassValue(value, _filler_39, WS_DT_TODAY); }
                    }  //Redefines
                    public class _REDEF_CB0110B_FILLER_39 : VarBasis
                    {
                        /*"            20 WS-ANO-TODAY       PIC 9(04).*/
                        public IntBasis WS_ANO_TODAY { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                        /*"            20 WS-MES-TODAY       PIC 9(02).*/
                        public IntBasis WS_MES_TODAY { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"            20 WS-DIA-TODAY       PIC 9(02).*/
                        public IntBasis WS_DIA_TODAY { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"         15 WS-HR-TODAY           PIC 9(06).*/

                        public _REDEF_CB0110B_FILLER_39()
                        {
                            WS_ANO_TODAY.ValueChanged += OnValueChanged;
                            WS_MES_TODAY.ValueChanged += OnValueChanged;
                            WS_DIA_TODAY.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_HR_TODAY { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"         15 FILLER REDEFINES WS-HR-TODAY.*/
                    private _REDEF_CB0110B_FILLER_40 _filler_40 { get; set; }
                    public _REDEF_CB0110B_FILLER_40 FILLER_40
                    {
                        get { _filler_40 = new _REDEF_CB0110B_FILLER_40(); _.Move(WS_HR_TODAY, _filler_40); VarBasis.RedefinePassValue(WS_HR_TODAY, _filler_40, WS_HR_TODAY); _filler_40.ValueChanged += () => { _.Move(_filler_40, WS_HR_TODAY); }; return _filler_40; }
                        set { VarBasis.RedefinePassValue(value, _filler_40, WS_HR_TODAY); }
                    }  //Redefines
                    public class _REDEF_CB0110B_FILLER_40 : VarBasis
                    {
                        /*"            20 WS-HR-HOR          PIC 9(02).*/
                        public IntBasis WS_HR_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"            20 WS-HR-MIN          PIC 9(02).*/
                        public IntBasis WS_HR_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"            20 WS-HR-SEG          PIC 9(02).*/
                        public IntBasis WS_HR_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                        /*"         15 WS-HR-DECSEG          PIC 9(02).*/

                        public _REDEF_CB0110B_FILLER_40()
                        {
                            WS_HR_HOR.ValueChanged += OnValueChanged;
                            WS_HR_MIN.ValueChanged += OnValueChanged;
                            WS_HR_SEG.ValueChanged += OnValueChanged;
                        }

                    }
                    public IntBasis WS_HR_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"01 WS-DISPLAY.*/

                    public _REDEF_CB0110B_WS_DATE_R()
                    {
                        WS_DT_TODAY.ValueChanged += OnValueChanged;
                        FILLER_39.ValueChanged += OnValueChanged;
                    }

                }
            }
        }
        public CB0110B_WS_DISPLAY WS_DISPLAY { get; set; } = new CB0110B_WS_DISPLAY();
        public class CB0110B_WS_DISPLAY : VarBasis
        {
            /*"   05 FILLER                      PIC X(07) VALUE      'CB0110B'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"CB0110B");
            /*"   05 FILLER                      PIC X(35) VALUE      ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"   05 WS-NR-PARAG                 PIC X(06) VALUE '000000'.*/
            public StringBasis WS_NR_PARAG { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"000000");
            /*"   05 FILLER                      PIC X(13) VALUE      ' *** SQLCODE '.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @" *** SQLCODE ");
            /*"   05 WS-SQLCODE                  PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"   05 FILLER                      PIC X(14) VALUE      ' *** SQLERRMC '.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @" *** SQLERRMC ");
            /*"   05 WS-SQLERRMC                 PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WS_SQLERRMC { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.FOLLOUP FOLLOUP { get; set; } = new Dclgens.FOLLOUP();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.APOLCOBR APOLCOBR { get; set; } = new Dclgens.APOLCOBR();
        public Dclgens.CHEQUEMI CHEQUEMI { get; set; } = new Dclgens.CHEQUEMI();
        public Dclgens.HISTOCHE HISTOCHE { get; set; } = new Dclgens.HISTOCHE();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.GE381 GE381 { get; set; } = new Dclgens.GE381();
        public Dclgens.CB040 CB040 { get; set; } = new Dclgens.CB040();
        public Dclgens.AVISOSAL AVISOSAL { get; set; } = new Dclgens.AVISOSAL();
        public CB0110B_CUR_FOLLOW_UP CUR_FOLLOW_UP { get; set; } = new CB0110B_CUR_FOLLOW_UP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CB0110S01_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CB0110S01.SetFile(CB0110S01_FILE_NAME_P);

                /*" -607- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -609- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -611- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -615- PERFORM P10000-00-INICIO. */

                P10000_00_INICIO_SECTION();

                /*" -691- PERFORM Execute_DB_DECLARE_1 */

                Execute_DB_DECLARE_1();

                /*" -695- PERFORM P20000-00-PRINCIPAL. */

                P20000_00_PRINCIPAL_SECTION();

                /*" -695- PERFORM P30000-00-FINALIZA. */

                P30000_00_FINALIZA_SECTION();

                /*" -695- FLUXCONTROL_PERFORM Execute-DB-DECLARE-1 */

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
            /*" -691- EXEC SQL DECLARE CUR_FOLLOW_UP CURSOR WITH HOLD FOR SELECT B.COD_FONTE ,B.RAMO_EMISSOR ,C.COD_CLIENTE ,B.OCORR_ENDERECO ,VALUE(B.COD_PRODUTO, 0) ,B.AGE_COBRANCA ,A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA ,A.DATA_MOVIMENTO ,A.HORA_OPERACAO ,A.VAL_OPERACAO ,A.AGE_AVISO ,A.TIPO_SEGURO ,A.NUM_AVISO_CREDITO ,D.TIPO_COBRANCA ,E.QTD_DOCUMENTOS ,F.SALDO_ATUAL FROM SEGUROS.FOLLOW_UP A ,SEGUROS.ENDOSSOS B ,SEGUROS.APOLICES C ,SEGUROS.APOLICE_COBRANCA D ,SEGUROS.PARCELAS E ,SEGUROS.AVISOS_SALDOS F WHERE A.SIT_REGISTRO = '0' AND A.COD_OPERACAO = 103 AND A.COD_ERRO04 = '1' AND A.DAC_PARCELA NOT IN ( 'B' ) AND ((A.NUM_APOLICE BETWEEN 1103100000000 AND 1103199999999) OR (A.NUM_APOLICE BETWEEN 0101800000000 AND 0101899999999) ) AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND ((B.COD_PRODUTO IN (1803,1805)) OR (B.COD_PRODUTO BETWEEN 3100 AND 3199) ) AND C.NUM_APOLICE = A.NUM_APOLICE AND D.COD_FONTE = B.COD_FONTE AND D.NUM_APOLICE = B.NUM_APOLICE AND D.NUM_ENDOSSO = B.NUM_ENDOSSO AND E.NUM_APOLICE = A.NUM_APOLICE AND E.NUM_ENDOSSO = A.NUM_ENDOSSO AND E.NUM_PARCELA = A.NUM_PARCELA AND F.AGE_AVISO = A.AGE_AVISO AND F.TIPO_SEGURO = A.TIPO_SEGURO AND F.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO ORDER BY A.NUM_APOLICE ,A.NUM_ENDOSSO ,A.NUM_PARCELA WITH UR END-EXEC */
            CUR_FOLLOW_UP = new CB0110B_CUR_FOLLOW_UP(false);
            string GetQuery_CUR_FOLLOW_UP()
            {
                var query = @$"SELECT B.COD_FONTE 
							,B.RAMO_EMISSOR 
							,C.COD_CLIENTE 
							,B.OCORR_ENDERECO 
							,VALUE(B.COD_PRODUTO
							, 0) 
							,B.AGE_COBRANCA 
							,A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA 
							,A.DATA_MOVIMENTO 
							,A.HORA_OPERACAO 
							,A.VAL_OPERACAO 
							,A.AGE_AVISO 
							,A.TIPO_SEGURO 
							,A.NUM_AVISO_CREDITO 
							,D.TIPO_COBRANCA 
							,E.QTD_DOCUMENTOS 
							,F.SALDO_ATUAL 
							FROM SEGUROS.FOLLOW_UP A 
							,SEGUROS.ENDOSSOS B 
							,SEGUROS.APOLICES C 
							,SEGUROS.APOLICE_COBRANCA D 
							,SEGUROS.PARCELAS E 
							,SEGUROS.AVISOS_SALDOS F 
							WHERE A.SIT_REGISTRO = '0' 
							AND A.COD_OPERACAO = 103 
							AND A.COD_ERRO04 = '1' 
							AND A.DAC_PARCELA NOT IN ( 'B' ) 
							AND 
							((A.NUM_APOLICE BETWEEN 1103100000000 
							AND 1103199999999) 
							OR 
							(A.NUM_APOLICE BETWEEN 0101800000000 
							AND 0101899999999) 
							) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND 
							((B.COD_PRODUTO IN (1803
							,1805)) OR 
							(B.COD_PRODUTO BETWEEN 3100 
							AND 3199) 
							) 
							AND C.NUM_APOLICE = A.NUM_APOLICE 
							AND D.COD_FONTE = B.COD_FONTE 
							AND D.NUM_APOLICE = B.NUM_APOLICE 
							AND D.NUM_ENDOSSO = B.NUM_ENDOSSO 
							AND E.NUM_APOLICE = A.NUM_APOLICE 
							AND E.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND E.NUM_PARCELA = A.NUM_PARCELA 
							AND F.AGE_AVISO = A.AGE_AVISO 
							AND F.TIPO_SEGURO = A.TIPO_SEGURO 
							AND F.NUM_AVISO_CREDITO = A.NUM_AVISO_CREDITO 
							ORDER BY A.NUM_APOLICE 
							,A.NUM_ENDOSSO 
							,A.NUM_PARCELA";

                return query;
            }
            CUR_FOLLOW_UP.GetQueryEvent += GetQuery_CUR_FOLLOW_UP;

        }

        [StopWatch]
        /*" P10000-00-INICIO-SECTION */
        private void P10000_00_INICIO_SECTION()
        {
            /*" -703- MOVE 'P10000' TO WS-NR-PARAG */
            _.Move("P10000", WS_DISPLAY.WS_NR_PARAG);

            /*" -705- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -708- DISPLAY 'DATA INICIO: ' WS-DT-TODAY ' - HORA INICIO: ' WS-HR-TODAY */

            $"DATA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_DT_TODAY} - HORA INICIO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_TODAY}"
            .Display();

            /*" -713- COMPUTE WS-SEG-INICIAL = (WS-HR-HOR * 60 * 60) + (WS-HR-MIN * 60) + WS-HR-SEG + (WS-HR-DECSEG / 100) */
            WS_SEG_INICIAL.Value = (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_40.WS_HR_HOR * 60 * 60) + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_40.WS_HR_MIN * 60) + WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_40.WS_HR_SEG + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_DECSEG / 100f);

            /*" -715- OPEN OUTPUT CB0110S01 */
            CB0110S01.Open(S01_REGISTRO, STATUS_S01);

            /*" -716- IF NOT STATUS-OK-S01 */

            if (!STATUS_S01["STATUS_OK_S01"])
            {

                /*" -719- STRING 'ERRO ABERTURA S01 - STATUS ' STATUS-S01 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl1 = "ERRO ABERTURA S01 - STATUS " + STATUS_S01.GetMoveValues();
                _.Move(spl1, WS_MSG);
                #endregion

                /*" -720- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -722- END-IF */
            }


            /*" -724- MOVE WS-DESCRICAO-S01 TO S01-REGISTRO */
            _.Move(WS_VARIAVEIS.WS_DESCRICAO_S01, S01_REGISTRO);

            /*" -726- WRITE S01-REGISTRO */
            CB0110S01.Write(S01_REGISTRO.GetMoveValues().ToString());

            /*" -727- IF NOT STATUS-OK-S01 */

            if (!STATUS_S01["STATUS_OK_S01"])
            {

                /*" -730- STRING 'ERRO NA GRAVACAO HEADER - STATUS ' STATUS-S01 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl2 = "ERRO NA GRAVACAO HEADER - STATUS " + STATUS_S01.GetMoveValues();
                _.Move(spl2, WS_MSG);
                #endregion

                /*" -731- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -733- END-IF */
            }


            /*" -735- ADD 1 TO WS-QT-IMPR */
            WS_QT_IMPR.Value = WS_QT_IMPR + 1;

            /*" -737- INITIALIZE DCLSISTEMAS */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
            );

            /*" -739- MOVE 'CB' TO SISTEMAS-IDE-SISTEMA */
            _.Move("CB", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -745- PERFORM P10000_00_INICIO_DB_SELECT_1 */

            P10000_00_INICIO_DB_SELECT_1();

            /*" -748- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -750- MOVE 'ERRO NA LEITURA DA TABELA .SISTEMAS' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .SISTEMAS", WS_MSG);

                /*" -751- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -753- END-IF */
            }


            /*" -754- IF SQLCODE = 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -757- STRING 'SISTEMA ' SISTEMAS-IDE-SISTEMA ' NAO CADASTRADO' DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl3 = "SISTEMA " + SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.GetMoveValues();
                spl3 += " NAO CADASTRADO";
                _.Move(spl3, WS_MSG);
                #endregion

                /*" -758- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -762- END-IF */
            }


            /*" -765- DISPLAY 'SISTEMA ' SISTEMAS-IDE-SISTEMA ' DATA ' SISTEMAS-DATA-MOV-ABERTO */

            $"SISTEMA {SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA} DATA {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
            .Display();

            /*" -766- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WS_VARIAVEIS.WDATA_REL);

            /*" -767- MOVE WDAT-REL-DIA TO WS-REC-DIA */
            _.Move(WS_VARIAVEIS.FILLER_31.WDAT_REL_DIA, WS_VARIAVEIS.FILLER_34.WS_REC_DIA);

            /*" -768- MOVE WDAT-REL-MES TO WS-REC-MES */
            _.Move(WS_VARIAVEIS.FILLER_31.WDAT_REL_MES, WS_VARIAVEIS.FILLER_34.WS_REC_MES);

            /*" -770- MOVE WDAT-REL-ANO TO WS-REC-ANO */
            _.Move(WS_VARIAVEIS.FILLER_31.WDAT_REL_ANO, WS_VARIAVEIS.FILLER_34.WS_REC_ANO);

            /*" -772- PERFORM P10100-00-SELECT-CHEQUEMI */

            P10100_00_SELECT_CHEQUEMI_SECTION();

            /*" -772- PERFORM P10200-00-SELECT-CBCONDEV. */

            P10200_00_SELECT_CBCONDEV_SECTION();

        }

        [StopWatch]
        /*" P10000-00-INICIO-DB-SELECT-1 */
        public void P10000_00_INICIO_DB_SELECT_1()
        {
            /*" -745- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :SISTEMAS-IDE-SISTEMA WITH UR END-EXEC */

            var p10000_00_INICIO_DB_SELECT_1_Query1 = new P10000_00_INICIO_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = P10000_00_INICIO_DB_SELECT_1_Query1.Execute(p10000_00_INICIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P10000_99_FIM*/

        [StopWatch]
        /*" P10100-00-SELECT-CHEQUEMI-SECTION */
        private void P10100_00_SELECT_CHEQUEMI_SECTION()
        {
            /*" -783- MOVE 'P10100' TO WS-NR-PARAG */
            _.Move("P10100", WS_DISPLAY.WS_NR_PARAG);

            /*" -788- PERFORM P10100_00_SELECT_CHEQUEMI_DB_SELECT_1 */

            P10100_00_SELECT_CHEQUEMI_DB_SELECT_1();

            /*" -791- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -793- MOVE 'ERRO NA LEITURA DA TABELA .CHEQUES_EMITIDOS' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .CHEQUES_EMITIDOS", WS_MSG);

                /*" -794- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -796- END-IF */
            }


            /*" -798- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO WS-NUMCHQ. */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ);

            /*" -798- DISPLAY 'P10100-00-SELECT-CHEQUEMI ' WS-NUMCHQ. */
            _.Display($"P10100-00-SELECT-CHEQUEMI {WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ}");

        }

        [StopWatch]
        /*" P10100-00-SELECT-CHEQUEMI-DB-SELECT-1 */
        public void P10100_00_SELECT_CHEQUEMI_DB_SELECT_1()
        {
            /*" -788- EXEC SQL SELECT VALUE ( MAX ( NUM_CHEQUE_INTERNO ) , 0 ) INTO :CHEQUEMI-NUM-CHEQUE-INTERNO FROM SEGUROS.CHEQUES_EMITIDOS WITH UR END-EXEC */

            var p10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1 = new P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = P10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1.Execute(p10100_00_SELECT_CHEQUEMI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CHEQUEMI_NUM_CHEQUE_INTERNO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P10100_99_FIM*/

        [StopWatch]
        /*" P10200-00-SELECT-CBCONDEV-SECTION */
        private void P10200_00_SELECT_CBCONDEV_SECTION()
        {
            /*" -809- MOVE 'P10200' TO WS-NR-PARAG */
            _.Move("P10200", WS_DISPLAY.WS_NR_PARAG);

            /*" -815- PERFORM P10200_00_SELECT_CBCONDEV_DB_SELECT_1 */

            P10200_00_SELECT_CBCONDEV_DB_SELECT_1();

            /*" -818- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -820- DISPLAY 'DATA-MOV-ABERTO' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA-MOV-ABERTO{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -822- MOVE 'ERRO NA LEITURA DA TABELA .CB_CONTR_DEVPREMIO' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .CB_CONTR_DEVPREMIO", WS_MSG);

                /*" -823- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -825- END-IF */
            }


            /*" -827- MOVE CBCONDEV-NUM-SEQUENCIA TO WS-NRSEQ. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA, WS_NRSEQ);

            /*" -827- DISPLAY 'P10200-00-SELECT-CBCONDEV ' WS-NRSEQ. */
            _.Display($"P10200-00-SELECT-CBCONDEV {WS_NRSEQ}");

        }

        [StopWatch]
        /*" P10200-00-SELECT-CBCONDEV-DB-SELECT-1 */
        public void P10200_00_SELECT_CBCONDEV_DB_SELECT_1()
        {
            /*" -815- EXEC SQL SELECT VALUE ( MAX ( NUM_SEQUENCIA ) , 0 ) INTO :CBCONDEV-NUM-SEQUENCIA FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var p10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1 = new P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = P10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1.Execute(p10200_00_SELECT_CBCONDEV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBCONDEV_NUM_SEQUENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P10200_99_SAIDA*/

        [StopWatch]
        /*" P20000-00-PRINCIPAL-SECTION */
        private void P20000_00_PRINCIPAL_SECTION()
        {
            /*" -838- MOVE 'P20000' TO WS-NR-PARAG */
            _.Move("P20000", WS_DISPLAY.WS_NR_PARAG);

            /*" -840- DISPLAY 'INICIO PROGRAMA' */
            _.Display($"INICIO PROGRAMA");

            /*" -842- MOVE SPACES TO WS-MSG */
            _.Move("", WS_MSG);

            /*" -842- PERFORM P20000_00_PRINCIPAL_DB_OPEN_1 */

            P20000_00_PRINCIPAL_DB_OPEN_1();

            /*" -845- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -847- MOVE 'ERRO ABERTURA CURSOR CUR_FOLLOW_UP' TO WS-MSG */
                _.Move("ERRO ABERTURA CURSOR CUR_FOLLOW_UP", WS_MSG);

                /*" -848- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -850- END-IF */
            }


            /*" -852- MOVE 0 TO WS-FIM-LE-CURSOR */
            _.Move(0, WS_FIM_LE_CURSOR);

            /*" -853- PERFORM UNTIL WS-FIM-LE-CURSOR = 1 */

            while (!(WS_FIM_LE_CURSOR == 1))
            {

                /*" -854- PERFORM P21000-00-LE-CUR-FOLLOW-UP */

                P21000_00_LE_CUR_FOLLOW_UP_SECTION();

                /*" -856- END-PERFORM */
            }

            /*" -856- PERFORM P20000_00_PRINCIPAL_DB_CLOSE_1 */

            P20000_00_PRINCIPAL_DB_CLOSE_1();

            /*" -859- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -861- MOVE 'ERRO FECHAMENTO CURSOR CUR_FOLLOW_UP' TO WS-MSG */
                _.Move("ERRO FECHAMENTO CURSOR CUR_FOLLOW_UP", WS_MSG);

                /*" -862- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -864- END-IF */
            }


            /*" -865- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -866- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -867- DISPLAY '|   CB0110B  - Resultado Processo   |' . */
            _.Display($"|   CB0110B  - Resultado Processo   |");

            /*" -868- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -869- DISPLAY '| Propostas Lidas          ' WS-QT-LIDOS '  |' */

            $"| Propostas Lidas          {WS_QT_LIDOS}  |"
            .Display();

            /*" -870- DISPLAY '|           Rejeitadas     ' WS-QT-REJEI '  |' */

            $"|           Rejeitadas     {WS_QT_REJEI}  |"
            .Display();

            /*" -871- DISPLAY '|           Processadas    ' WS-QT-PROCES '  |' */

            $"|           Processadas    {WS_QT_PROCES}  |"
            .Display();

            /*" -872- DISPLAY '|           . Debito       ' WS-QT-DEBITO '  |' */

            $"|           . Debito       {WS_QT_DEBITO}  |"
            .Display();

            /*" -873- DISPLAY '|           . Boleto       ' WS-QT-BOLETO '  |' */

            $"|           . Boleto       {WS_QT_BOLETO}  |"
            .Display();

            /*" -874- DISPLAY '| Documentos Gravados :             |' */
            _.Display($"| Documentos Gravados :             |");

            /*" -875- DISPLAY '| - CB_CONTR_DEVPREMIO     ' WS-QT-DEVPR '  |' */

            $"| - CB_CONTR_DEVPREMIO     {WS_QT_DEVPR}  |"
            .Display();

            /*" -876- DISPLAY '|   . Convenio BBrasil     ' WS-QT-921286 '  |' */

            $"|   . Convenio BBrasil     {WS_QT_921286}  |"
            .Display();

            /*" -877- DISPLAY '|   . Convenio CEF         ' WS-QT-900662 '  |' */

            $"|   . Convenio CEF         {WS_QT_900662}  |"
            .Display();

            /*" -878- DISPLAY '|   . Cheque               ' WS-QT-DEVCC '  |' */

            $"|   . Cheque               {WS_QT_DEVCC}  |"
            .Display();

            /*" -879- DISPLAY '|   . CBCONDEV (Cheque)    ' WS-QT-DEVCH '  |' */

            $"|   . CBCONDEV (Cheque)    {WS_QT_DEVCH}  |"
            .Display();

            /*" -880- DISPLAY '| - CHEQUES_EMITIDOS       ' WS-QT-CHEMI '  |' */

            $"| - CHEQUES_EMITIDOS       {WS_QT_CHEMI}  |"
            .Display();

            /*" -881- DISPLAY '| - PESSOA                 ' WS-QT-PESSO '  |' */

            $"| - PESSOA                 {WS_QT_PESSO}  |"
            .Display();

            /*" -882- DISPLAY '| - LEGADO PESSOA          ' WS-QT-LEGAD '  |' */

            $"| - LEGADO PESSOA          {WS_QT_LEGAD}  |"
            .Display();

            /*" -883- DISPLAY '| Documentos Atualizados :          |' */
            _.Display($"| Documentos Atualizados :          |");

            /*" -884- DISPLAY '| Relatorio              :          |' */
            _.Display($"| Relatorio              :          |");

            /*" -885- DISPLAY '| - Registros Impressos    ' WS-QT-IMPR '  |' */

            $"| - Registros Impressos    {WS_QT_IMPR}  |"
            .Display();

            /*" -887- DISPLAY '+-----------------------------------+' */
            _.Display($"+-----------------------------------+");

            /*" -887- DISPLAY 'TERMINO PRINCIPAL' . */
            _.Display($"TERMINO PRINCIPAL");

        }

        [StopWatch]
        /*" P20000-00-PRINCIPAL-DB-OPEN-1 */
        public void P20000_00_PRINCIPAL_DB_OPEN_1()
        {
            /*" -842- EXEC SQL OPEN CUR_FOLLOW_UP END-EXEC */

            CUR_FOLLOW_UP.Open();

        }

        [StopWatch]
        /*" P20000-00-PRINCIPAL-DB-CLOSE-1 */
        public void P20000_00_PRINCIPAL_DB_CLOSE_1()
        {
            /*" -856- EXEC SQL CLOSE CUR_FOLLOW_UP END-EXEC */

            CUR_FOLLOW_UP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P20000_99_FIM*/

        [StopWatch]
        /*" P21000-00-LE-CUR-FOLLOW-UP-SECTION */
        private void P21000_00_LE_CUR_FOLLOW_UP_SECTION()
        {
            /*" -898- MOVE 'P21000' TO WS-NR-PARAG */
            _.Move("P21000", WS_DISPLAY.WS_NR_PARAG);

            /*" -917- PERFORM P21000_00_LE_CUR_FOLLOW_UP_DB_FETCH_1 */

            P21000_00_LE_CUR_FOLLOW_UP_DB_FETCH_1();

            /*" -920- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -922- MOVE 'ERRO NA LEITURA DO CURSOR CUR_FOLLOW_UP' TO WS-MSG */
                _.Move("ERRO NA LEITURA DO CURSOR CUR_FOLLOW_UP", WS_MSG);

                /*" -923- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -925- END-IF */
            }


            /*" -926- IF SQLCODE = 0 */

            if (DB.SQLCODE == 0)
            {

                /*" -927- PERFORM P22000-00-TRATA-REGISTRO */

                P22000_00_TRATA_REGISTRO_SECTION();

                /*" -928- ELSE */
            }
            else
            {


                /*" -929- MOVE 1 TO WS-FIM-LE-CURSOR */
                _.Move(1, WS_FIM_LE_CURSOR);

                /*" -929- END-IF. */
            }


        }

        [StopWatch]
        /*" P21000-00-LE-CUR-FOLLOW-UP-DB-FETCH-1 */
        public void P21000_00_LE_CUR_FOLLOW_UP_DB_FETCH_1()
        {
            /*" -917- EXEC SQL FETCH NEXT CUR_FOLLOW_UP INTO :ENDOSSOS-COD-FONTE ,:ENDOSSOS-RAMO-EMISSOR ,:APOLICES-COD-CLIENTE ,:ENDOSSOS-OCORR-ENDERECO ,:ENDOSSOS-COD-PRODUTO ,:ENDOSSOS-AGE-COBRANCA ,:FOLLOUP-NUM-APOLICE ,:FOLLOUP-NUM-ENDOSSO ,:FOLLOUP-NUM-PARCELA ,:FOLLOUP-DATA-MOVIMENTO ,:FOLLOUP-HORA-OPERACAO ,:FOLLOUP-VAL-OPERACAO ,:FOLLOUP-AGE-AVISO ,:FOLLOUP-TIPO-SEGURO ,:FOLLOUP-NUM-AVISO-CREDITO ,:APOLCOBR-TIPO-COBRANCA ,:PARCELAS-QTD-DOCUMENTOS ,:AVISOSAL-SALDO-ATUAL END-EXEC */

            if (CUR_FOLLOW_UP.Fetch())
            {
                _.Move(CUR_FOLLOW_UP.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(CUR_FOLLOW_UP.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(CUR_FOLLOW_UP.APOLICES_COD_CLIENTE, APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE);
                _.Move(CUR_FOLLOW_UP.ENDOSSOS_OCORR_ENDERECO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO);
                _.Move(CUR_FOLLOW_UP.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(CUR_FOLLOW_UP.ENDOSSOS_AGE_COBRANCA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_NUM_APOLICE, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_NUM_ENDOSSO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_NUM_PARCELA, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_DATA_MOVIMENTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_HORA_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_VAL_OPERACAO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_AGE_AVISO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_TIPO_SEGURO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO);
                _.Move(CUR_FOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO);
                _.Move(CUR_FOLLOW_UP.APOLCOBR_TIPO_COBRANCA, APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA);
                _.Move(CUR_FOLLOW_UP.PARCELAS_QTD_DOCUMENTOS, PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS);
                _.Move(CUR_FOLLOW_UP.AVISOSAL_SALDO_ATUAL, AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P21000_99_SAIDA*/

        [StopWatch]
        /*" P22000-00-TRATA-REGISTRO-SECTION */
        private void P22000_00_TRATA_REGISTRO_SECTION()
        {
            /*" -940- MOVE 'P22000' TO WS-NR-PARAG */
            _.Move("P22000", WS_DISPLAY.WS_NR_PARAG);

            /*" -942- ADD 1 TO WS-QT-LIDOS */
            WS_QT_LIDOS.Value = WS_QT_LIDOS + 1;

            /*" -944- MOVE SPACES TO WS-MENSAGEM */
            _.Move("", WS_MENSAGEM);

            /*" -960- DISPLAY 'LENDO CURSOR: ' ENDOSSOS-COD-FONTE ' APO ' FOLLOUP-NUM-APOLICE ' END ' FOLLOUP-NUM-ENDOSSO ' PAR ' FOLLOUP-NUM-PARCELA ' RAMO ' ENDOSSOS-RAMO-EMISSOR ' CLI ' APOLICES-COD-CLIENTE ' OC ' ENDOSSOS-OCORR-ENDERECO ' PROD ' ENDOSSOS-COD-PRODUTO ' AGE ' ENDOSSOS-AGE-COBRANCA ' VL ' FOLLOUP-VAL-OPERACAO ' COB ' APOLCOBR-TIPO-COBRANCA ' DOC ' PARCELAS-QTD-DOCUMENTOS ' SALDO ' AVISOSAL-SALDO-ATUAL ' DT MOV ' FOLLOUP-DATA-MOVIMENTO ' HR OPE ' FOLLOUP-HORA-OPERACAO */

            $"LENDO CURSOR: {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE} APO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE} END {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO} PAR {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA} RAMO {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR} CLI {APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE} OC {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO} PROD {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO} AGE {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA} VL {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO} COB {APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA} DOC {PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS} SALDO {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL} DT MOV {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO} HR OPE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO}"
            .Display();

            /*" -962- PERFORM P22100-00-SELECT-CLIENTES */

            P22100_00_SELECT_CLIENTES_SECTION();

            /*" -1027- PERFORM P22200-00-SELECT-ENDERECO */

            P22200_00_SELECT_ENDERECO_SECTION();

            /*" -1030- INITIALIZE DCLMOVTO-DEBITOCC-CEF WS-FLAG-1 */
            _.Initialize(
                MOVDEBCE.DCLMOVTO_DEBITOCC_CEF
                , WS_FLAG_1
            );

            /*" -1052- PERFORM P22000_00_TRATA_REGISTRO_DB_SELECT_1 */

            P22000_00_TRATA_REGISTRO_DB_SELECT_1();

            /*" -1055- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -1056- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1057- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1059- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1061- MOVE 'ERRO NA LEITURA DA TABELA .MOVTO_DEBITOCC_CEF' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .MOVTO_DEBITOCC_CEF", WS_MSG);

                /*" -1062- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -1064- END-IF */
            }


            /*" -1065- IF APOLCOBR-TIPO-COBRANCA = '1' */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA == "1")
            {

                /*" -1067- IF MOVDEBCE-SITUACAO-COBRANCA = '3' AND MOVDEBCE-COD-RETORNO-CEF = 0 */

                if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA == "3" && MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF == 0)
                {

                    /*" -1068- GO TO P22000-01-DEVOLUCAO */

                    P22000_01_DEVOLUCAO(); //GOTO
                    return;

                    /*" -1069- ELSE */
                }
                else
                {


                    /*" -1070- IF MOVDEBCE-SITUACAO-COBRANCA NOT EQUAL '3' */

                    if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA != "3")
                    {

                        /*" -1071- MOVE 1 TO WS-FLAG-1 */
                        _.Move(1, WS_FLAG_1);

                        /*" -1072- ELSE */
                    }
                    else
                    {


                        /*" -1073- IF MOVDEBCE-VALOR-DEBITO = 0 */

                        if (MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO == 0)
                        {

                            /*" -1074- MOVE 2 TO WS-FLAG-1 */
                            _.Move(2, WS_FLAG_1);

                            /*" -1075- END-IF */
                        }


                        /*" -1077- END-IF */
                    }


                    /*" -1078- GO TO P22000-02-RELATORIO */

                    P22000_02_RELATORIO(); //GOTO
                    return;

                    /*" -1079- END-IF */
                }


                /*" -1080- ELSE */
            }
            else
            {


                /*" -1081- IF SQLCODE = 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1082- GO TO P22000-01-DEVOLUCAO */

                    P22000_01_DEVOLUCAO(); //GOTO
                    return;

                    /*" -1083- ELSE */
                }
                else
                {


                    /*" -1084- MOVE 2 TO WS-FLAG-1 */
                    _.Move(2, WS_FLAG_1);

                    /*" -1085- GO TO P22000-02-RELATORIO */

                    P22000_02_RELATORIO(); //GOTO
                    return;

                    /*" -1086- END-IF */
                }


                /*" -1086- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM P22000_01_DEVOLUCAO */

            P22000_01_DEVOLUCAO();

        }

        [StopWatch]
        /*" P22000-00-TRATA-REGISTRO-DB-SELECT-1 */
        public void P22000_00_TRATA_REGISTRO_DB_SELECT_1()
        {
            /*" -1052- EXEC SQL SELECT VALUE(OPER_CONTA_DEB,0) ,VALUE(COD_AGENCIA_DEB,0) ,VALUE(NUM_CONTA_DEB,0) ,VALUE(DIG_CONTA_DEB,0) ,SITUACAO_COBRANCA ,VALUE(COD_RETORNO_CEF,0) ,VALUE(VALOR_DEBITO,0) INTO :MOVDEBCE-OPER-CONTA-DEB ,:MOVDEBCE-COD-AGENCIA-DEB ,:MOVDEBCE-NUM-CONTA-DEB ,:MOVDEBCE-DIG-CONTA-DEB ,:MOVDEBCE-SITUACAO-COBRANCA ,:MOVDEBCE-COD-RETORNO-CEF ,:MOVDEBCE-VALOR-DEBITO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :FOLLOUP-NUM-APOLICE AND NUM_ENDOSSO = :FOLLOUP-NUM-ENDOSSO AND NUM_PARCELA = :FOLLOUP-NUM-PARCELA ORDER BY TIMESTAMP DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC */

            var p22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1 = new P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1()
            {
                FOLLOUP_NUM_APOLICE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE.ToString(),
                FOLLOUP_NUM_ENDOSSO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO.ToString(),
                FOLLOUP_NUM_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA.ToString(),
            };

            var executed_1 = P22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1.Execute(p22000_00_TRATA_REGISTRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_OPER_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_COD_AGENCIA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);
                _.Move(executed_1.MOVDEBCE_NUM_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_DIG_CONTA_DEB, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);
                _.Move(executed_1.MOVDEBCE_SITUACAO_COBRANCA, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);
                _.Move(executed_1.MOVDEBCE_COD_RETORNO_CEF, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF);
                _.Move(executed_1.MOVDEBCE_VALOR_DEBITO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);
            }


        }

        [StopWatch]
        /*" P22000-01-DEVOLUCAO */
        private void P22000_01_DEVOLUCAO(bool isPerform = false)
        {
            /*" -1092- ADD 1 TO WS-QT-PROCES */
            WS_QT_PROCES.Value = WS_QT_PROCES + 1;

            /*" -1093- IF APOLCOBR-TIPO-COBRANCA = '1' */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA == "1")
            {

                /*" -1094- ADD 1 TO WS-QT-DEBITO */
                WS_QT_DEBITO.Value = WS_QT_DEBITO + 1;

                /*" -1095- ELSE */
            }
            else
            {


                /*" -1096- ADD 1 TO WS-QT-BOLETO */
                WS_QT_BOLETO.Value = WS_QT_BOLETO + 1;

                /*" -1098- END-IF */
            }


            /*" -1100- PERFORM P22300-00-GERA-DEVOLUCAO */

            P22300_00_GERA_DEVOLUCAO_SECTION();

            /*" -1102- PERFORM P22400-00-ATUALIZACOES */

            P22400_00_ATUALIZACOES_SECTION();

            /*" -1102- GO TO P22000-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P22000_99_SAIDA*/ //GOTO
            return;

        }

        [StopWatch]
        /*" P22000-02-RELATORIO */
        private void P22000_02_RELATORIO(bool isPerform = false)
        {
            /*" -1108- ADD 1 TO WS-QT-REJEI */
            WS_QT_REJEI.Value = WS_QT_REJEI + 1;

            /*" -1110- DISPLAY 'DESPREZANDO REGISTRO ' FOLLOUP-NUM-APOLICE */
            _.Display($"DESPREZANDO REGISTRO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

            /*" -1114- MOVE 0 TO GE381-COD-BCO GE381-COD-OPERACAO GE381-NUM-CONTA CBCONDEV-NUM-CHEQUE-INTERNO */
            _.Move(0, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);

            /*" -1118- MOVE SPACES TO GE381-COD-AGENCIA GE381-COD-AGENCIA-DV GE381-NUM-CONTA-DV1 */
            _.Move("", GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA_DV, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1);

            /*" -1119- EVALUATE WS-FLAG-1 */
            switch (WS_FLAG_1.Value)
            {

                /*" -1120- WHEN 0 */
                case 0:

                    /*" -1122- MOVE 'DEBITO NAO EFETUADO - REGISTRO DESPREZADO' TO WS-MENSAGEM */
                    _.Move("DEBITO NAO EFETUADO - REGISTRO DESPREZADO", WS_MENSAGEM);

                    /*" -1123- WHEN 1 */
                    break;
                case 1:

                    /*" -1125- MOVE 'SITUACAO IMPREVISTA - REGISTRO DESPREZADO' TO WS-MENSAGEM */
                    _.Move("SITUACAO IMPREVISTA - REGISTRO DESPREZADO", WS_MENSAGEM);

                    /*" -1126- WHEN 2 */
                    break;
                case 2:

                    /*" -1128- MOVE 'RETORNO DE CREDITO - REGISTRO DESPREZADO' TO WS-MENSAGEM */
                    _.Move("RETORNO DE CREDITO - REGISTRO DESPREZADO", WS_MENSAGEM);

                    /*" -1130- END-EVALUATE */
                    break;
            }


            /*" -1130- PERFORM P22370-00-GRAVA-RELATORIO. */

            P22370_00_GRAVA_RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22000_99_SAIDA*/

        [StopWatch]
        /*" P22100-00-SELECT-CLIENTES-SECTION */
        private void P22100_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1141- MOVE 'P22100' TO WS-NR-PARAG */
            _.Move("P22100", WS_DISPLAY.WS_NR_PARAG);

            /*" -1143- INITIALIZE DCLCLIENTES */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -1145- MOVE APOLICES-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -1157- PERFORM P22100_00_SELECT_CLIENTES_DB_SELECT_1 */

            P22100_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1160- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1161- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1162- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1163- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1165- DISPLAY 'CLIENTE ' CLIENTES-COD-CLIENTE */
                _.Display($"CLIENTE {CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE}");

                /*" -1167- MOVE 'ERRO NA LEITURA DA TABELA .CLIENTES' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .CLIENTES", WS_MSG);

                /*" -1168- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -1168- END-IF. */
            }


        }

        [StopWatch]
        /*" P22100-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void P22100_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1157- EXEC SQL SELECT COD_CLIENTE ,NOME_RAZAO ,TIPO_PESSOA ,CGCCPF INTO :CLIENTES-COD-CLIENTE ,:CLIENTES-NOME-RAZAO ,:CLIENTES-TIPO-PESSOA ,:CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE WITH UR END-EXEC */

            var p22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = P22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(p22100_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22100_99_SAIDA*/

        [StopWatch]
        /*" P22200-00-SELECT-ENDERECO-SECTION */
        private void P22200_00_SELECT_ENDERECO_SECTION()
        {
            /*" -1179- MOVE 'P22200' TO WS-NR-PARAG */
            _.Move("P22200", WS_DISPLAY.WS_NR_PARAG);

            /*" -1181- INITIALIZE DCLENDERECOS */
            _.Initialize(
                ENDERECO.DCLENDERECOS
            );

            /*" -1182- MOVE APOLICES-COD-CLIENTE TO ENDERECO-COD-CLIENTE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1184- MOVE ENDOSSOS-OCORR-ENDERECO TO ENDERECO-OCORR-ENDERECO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);

            /*" -1199- PERFORM P22200_00_SELECT_ENDERECO_DB_SELECT_1 */

            P22200_00_SELECT_ENDERECO_DB_SELECT_1();

            /*" -1202- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1203- DISPLAY 'APOLICE  ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1204- DISPLAY 'ENDOSSO  ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1205- DISPLAY 'PARCELA  ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1206- DISPLAY 'CLIENTE  ' ENDERECO-COD-CLIENTE */
                _.Display($"CLIENTE  {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}");

                /*" -1208- DISPLAY 'ENDERECO ' ENDERECO-OCORR-ENDERECO */
                _.Display($"ENDERECO {ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO}");

                /*" -1210- MOVE 'ERRO NA LEITURA DA TABELA .ENDERECOS' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .ENDERECOS", WS_MSG);

                /*" -1211- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -1211- END-IF. */
            }


        }

        [StopWatch]
        /*" P22200-00-SELECT-ENDERECO-DB-SELECT-1 */
        public void P22200_00_SELECT_ENDERECO_DB_SELECT_1()
        {
            /*" -1199- EXEC SQL SELECT ENDERECO ,BAIRRO ,CIDADE ,SIGLA_UF ,CEP INTO :ENDERECO-ENDERECO ,:ENDERECO-BAIRRO ,:ENDERECO-CIDADE ,:ENDERECO-SIGLA-UF ,:ENDERECO-CEP FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :ENDERECO-COD-CLIENTE AND OCORR_ENDERECO = :ENDERECO-OCORR-ENDERECO WITH UR END-EXEC */

            var p22200_00_SELECT_ENDERECO_DB_SELECT_1_Query1 = new P22200_00_SELECT_ENDERECO_DB_SELECT_1_Query1()
            {
                ENDERECO_OCORR_ENDERECO = ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO.ToString(),
                ENDERECO_COD_CLIENTE = ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE.ToString(),
            };

            var executed_1 = P22200_00_SELECT_ENDERECO_DB_SELECT_1_Query1.Execute(p22200_00_SELECT_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(executed_1.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(executed_1.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(executed_1.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22200_99_SAIDA*/

        [StopWatch]
        /*" P22300-00-GERA-DEVOLUCAO-SECTION */
        private void P22300_00_GERA_DEVOLUCAO_SECTION()
        {
            /*" -1222- MOVE 'P22300' TO WS-NR-PARAG */
            _.Move("P22300", WS_DISPLAY.WS_NR_PARAG);

            /*" -1225- DISPLAY 'P22300-00-GERA-DEVOLUCAO' */
            _.Display($"P22300-00-GERA-DEVOLUCAO");

            /*" -1227- PERFORM P22310-00-SELECT-GE381 */

            P22310_00_SELECT_GE381_SECTION();

            /*" -1230- PERFORM P22320-00-SELECT-AGENCCEF */

            P22320_00_SELECT_AGENCCEF_SECTION();

            /*" -1234- PERFORM P22330-00-GRAVA-PESSOA */

            P22330_00_GRAVA_PESSOA_SECTION();

            /*" -1237- PERFORM P22340-00-PESSOA-LEGADO */

            P22340_00_PESSOA_LEGADO_SECTION();

            /*" -1240- PERFORM P22350-00-GRAVA-CBCONDEV */

            P22350_00_GRAVA_CBCONDEV_SECTION();

            /*" -1241- IF WS-GERA-CHEQUE EQUAL 'S' */

            if (WS_GERA_CHEQUE == "S")
            {

                /*" -1243- PERFORM P22360-00-GRAVA-CHEQUE. */

                P22360_00_GRAVA_CHEQUE_SECTION();
            }


            /*" -1243- PERFORM P22370-00-GRAVA-RELATORIO. */

            P22370_00_GRAVA_RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22300_99_SAIDA*/

        [StopWatch]
        /*" P22310-00-SELECT-GE381-SECTION */
        private void P22310_00_SELECT_GE381_SECTION()
        {
            /*" -1254- MOVE 'P22310' TO WS-NR-PARAG */
            _.Move("P22310", WS_DISPLAY.WS_NR_PARAG);

            /*" -1256- INITIALIZE DCLGE-CLI-DADOS-FINANC */
            _.Initialize(
                GE381.DCLGE_CLI_DADOS_FINANC
            );

            /*" -1258- MOVE CLIENTES-COD-CLIENTE TO GE381-COD-CLIENTE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_CLIENTE);

            /*" -1275- PERFORM P22310_00_SELECT_GE381_DB_SELECT_1 */

            P22310_00_SELECT_GE381_DB_SELECT_1();

            /*" -1278- IF SQLCODE NOT = 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -1279- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1280- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1281- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1283- DISPLAY 'CLIENTE ' GE381-COD-CLIENTE */
                _.Display($"CLIENTE {GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_CLIENTE}");

                /*" -1285- MOVE 'ERRO NA LEITURA DA TABELA .GE_CLI_DADOS_FINANC' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .GE_CLI_DADOS_FINANC", WS_MSG);

                /*" -1286- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -1288- END-IF */
            }


            /*" -1289- IF ENDOSSOS-RAMO-EMISSOR = 18 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR == 18)
            {

                /*" -1290- MOVE 0 TO SQLCODE */
                _.Move(0, DB.SQLCODE);

                /*" -1292- END-IF */
            }


            /*" -1293- IF APOLCOBR-TIPO-COBRANCA = '1' */

            if (APOLCOBR.DCLAPOLICE_COBRANCA.APOLCOBR_TIPO_COBRANCA == "1")
            {

                /*" -1294- MOVE 104 TO GE381-COD-BCO */
                _.Move(104, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO);

                /*" -1295- MOVE MOVDEBCE-OPER-CONTA-DEB TO GE381-COD-OPERACAO */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO);

                /*" -1296- MOVE MOVDEBCE-COD-AGENCIA-DEB TO GE381-COD-AGENCIA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA);

                /*" -1297- MOVE SPACES TO GE381-COD-AGENCIA-DV */
                _.Move("", GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA_DV);

                /*" -1298- MOVE MOVDEBCE-NUM-CONTA-DEB TO GE381-NUM-CONTA */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA);

                /*" -1299- MOVE WS-DIG-CONTA-DEB-2 TO GE381-NUM-CONTA-DV1 */
                _.Move(WS_VARIAVEIS.FILLER_38.WS_DIG_CONTA_DEB_2, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1);

                /*" -1301- END-IF */
            }


            /*" -1306- IF (SQLCODE = 100) OR (GE381-COD-BCO = ZEROS OR GE381-COD-AGENCIA = SPACES OR GE381-NUM-CONTA = ZEROS) */

            if ((DB.SQLCODE == 100) || (GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO == 00 || GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA.IsEmpty() || GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA == 00))
            {

                /*" -1307- MOVE 'S' TO WS-GERA-CHEQUE */
                _.Move("S", WS_GERA_CHEQUE);

                /*" -1308- ELSE */
            }
            else
            {


                /*" -1310- MOVE 'N' TO WS-GERA-CHEQUE */
                _.Move("N", WS_GERA_CHEQUE);

                /*" -1311- IF GE381-COD-BCO NOT = 104 */

                if (GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO != 104)
                {

                    /*" -1312- MOVE ZEROS TO GE381-COD-OPERACAO */
                    _.Move(0, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO);

                    /*" -1313- END-IF */
                }


                /*" -1313- END-IF. */
            }


        }

        [StopWatch]
        /*" P22310-00-SELECT-GE381-DB-SELECT-1 */
        public void P22310_00_SELECT_GE381_DB_SELECT_1()
        {
            /*" -1275- EXEC SQL SELECT VALUE(COD_BCO, 0) ,VALUE(COD_AGENCIA, ' ' ) ,VALUE(COD_AGENCIA_DV, ' ' ) ,VALUE(COD_OPERACAO, 0) ,VALUE(NUM_CONTA, 0) ,VALUE(NUM_CONTA_DV1, ' ' ) INTO :GE381-COD-BCO ,:GE381-COD-AGENCIA ,:GE381-COD-AGENCIA-DV ,:GE381-COD-OPERACAO ,:GE381-NUM-CONTA ,:GE381-NUM-CONTA-DV1 FROM SEGUROS.GE_CLI_DADOS_FINANC WHERE COD_CLIENTE = :GE381-COD-CLIENTE AND COD_TIPO_CONTA = ' ' WITH UR END-EXEC */

            var p22310_00_SELECT_GE381_DB_SELECT_1_Query1 = new P22310_00_SELECT_GE381_DB_SELECT_1_Query1()
            {
                GE381_COD_CLIENTE = GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_CLIENTE.ToString(),
            };

            var executed_1 = P22310_00_SELECT_GE381_DB_SELECT_1_Query1.Execute(p22310_00_SELECT_GE381_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE381_COD_BCO, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO);
                _.Move(executed_1.GE381_COD_AGENCIA, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA);
                _.Move(executed_1.GE381_COD_AGENCIA_DV, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA_DV);
                _.Move(executed_1.GE381_COD_OPERACAO, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO);
                _.Move(executed_1.GE381_NUM_CONTA, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA);
                _.Move(executed_1.GE381_NUM_CONTA_DV1, GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22310_99_SAIDA*/

        [StopWatch]
        /*" P22320-00-SELECT-AGENCCEF-SECTION */
        private void P22320_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -1331- MOVE 'P22320' TO WS-NR-PARAG */
            _.Move("P22320", WS_DISPLAY.WS_NR_PARAG);

            /*" -1334- INITIALIZE DCLAGENCIAS-CEF DCLMALHA-CEF */
            _.Initialize(
                AGENCCEF.DCLAGENCIAS_CEF
                , MALHACEF.DCLMALHA_CEF
            );

            /*" -1336- MOVE ENDOSSOS-AGE-COBRANCA TO AGENCCEF-COD-AGENCIA */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

            /*" -1345- PERFORM P22320_00_SELECT_AGENCCEF_DB_SELECT_1 */

            P22320_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -1348- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1349- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1350- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1351- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1353- DISPLAY 'AGENCIA ' AGENCCEF-COD-AGENCIA */
                _.Display($"AGENCIA {AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA}");

                /*" -1355- MOVE 'ERRO NA LEITURA DA TABELA .AGENCIAS_CEF' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .AGENCIAS_CEF", WS_MSG);

                /*" -1356- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -1356- END-IF. */
            }


        }

        [StopWatch]
        /*" P22320-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void P22320_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -1345- EXEC SQL SELECT A.COD_ESCNEG ,B.COD_FONTE INTO :AGENCCEF-COD-ESCNEG ,:MALHACEF-COD-FONTE FROM SEGUROS.AGENCIAS_CEF A ,SEGUROS.MALHA_CEF B WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA AND A.COD_SUREG = B.COD_SUREG END-EXEC. */

            var p22320_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new P22320_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = P22320_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(p22320_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
                _.Move(executed_1.MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22320_99_SAIDA*/

        [StopWatch]
        /*" P22330-00-GRAVA-PESSOA-SECTION */
        private void P22330_00_GRAVA_PESSOA_SECTION()
        {
            /*" -1367- MOVE 'P22330' TO WS-NR-PARAG. */
            _.Move("P22330", WS_DISPLAY.WS_NR_PARAG);

            /*" -1368- IF CLIENTES-TIPO-PESSOA = 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1369- PERFORM P22331-00-PESSOA-FISICA */

                P22331_00_PESSOA_FISICA_SECTION();

                /*" -1370- ELSE */
            }
            else
            {


                /*" -1372- PERFORM P22332-00-PESSOA-JURIDICA. */

                P22332_00_PESSOA_JURIDICA_SECTION();
            }


            /*" -1374- PERFORM P22333-00-ENDERECO. */

            P22333_00_ENDERECO_SECTION();

            /*" -1375- IF WS-GERA-CHEQUE EQUAL 'N' */

            if (WS_GERA_CHEQUE == "N")
            {

                /*" -1377- PERFORM P22334-00-BANCO. */

                P22334_00_BANCO_SECTION();
            }


            /*" -1377- ADD 1 TO WS-QT-PESSO. */
            WS_QT_PESSO.Value = WS_QT_PESSO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22330_99_SAIDA*/

        [StopWatch]
        /*" P22331-00-PESSOA-FISICA-SECTION */
        private void P22331_00_PESSOA_FISICA_SECTION()
        {
            /*" -1388- MOVE 'P22331' TO WS-NR-PARAG. */
            _.Move("P22331", WS_DISPLAY.WS_NR_PARAG);

            /*" -1390- INITIALIZE LK-PF-PARAMETRO. */
            _.Initialize(
                LK_PF_PARAMETRO
            );

            /*" -1391- MOVE '1' TO LK-PF-TIPO-UTILIZACAO. */
            _.Move("1", LK_PF_PARAMETRO.LK_PF_TIPO_UTILIZACAO);

            /*" -1392- MOVE 'N' TO LK-PF-PESSOA-ESPECIAL. */
            _.Move("N", LK_PF_PARAMETRO.LK_PF_PESSOA_ESPECIAL);

            /*" -1393- MOVE 'CB0110B' TO LK-PF-PROGRAMA-CHAMADOR. */
            _.Move("CB0110B", LK_PF_PARAMETRO.LK_PF_PROGRAMA_CHAMADOR);

            /*" -1394- MOVE 'CB0110B' TO LK-PF-NOME-USUARIO */
            _.Move("CB0110B", LK_PF_PARAMETRO.LK_PF_NOME_USUARIO);

            /*" -1395- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-PF-DTH-CADASTRAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_PF_PARAMETRO.LK_PF_DTH_CADASTRAMENTO);

            /*" -1396- MOVE CLIENTES-TIPO-PESSOA TO LK-PF-IND-PESSOA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_PF_PARAMETRO.LK_PF_IND_PESSOA);

            /*" -1397- MOVE 'S' TO LK-PF-STA-INF-INTEGRA. */
            _.Move("S", LK_PF_PARAMETRO.LK_PF_STA_INF_INTEGRA);

            /*" -1398- MOVE CLIENTES-CGCCPF TO W-NUM-CPF-INT-A */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WS_VARIAVEIS.W_NUM_CPF_INT_A);

            /*" -1399- MOVE W-NUM-CPF-INT-NUM TO LK-PF-NUM-CPF */
            _.Move(WS_VARIAVEIS.W_NUM_CPF_INT.W_NUM_CPF_INT_NUM, LK_PF_PARAMETRO.LK_PF_NUM_CPF);

            /*" -1400- MOVE W-NUM-CPF-INT-DV TO LK-PF-NUM-DV-CPF */
            _.Move(WS_VARIAVEIS.W_NUM_CPF_INT.W_NUM_CPF_INT_DV, LK_PF_PARAMETRO.LK_PF_NUM_DV_CPF);

            /*" -1401- MOVE CLIENTES-NOME-RAZAO TO LK-PF-NOM-PESSOA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LK_PF_PARAMETRO.LK_PF_NOM_PESSOA);

            /*" -1402- MOVE ' ' TO LK-PF-DTH-NASCIMENTO */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_DTH_NASCIMENTO);

            /*" -1403- MOVE ' ' TO LK-PF-STA-SEXO */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_STA_SEXO);

            /*" -1404- MOVE ' ' TO LK-PF-IND-ESTADO-CIVIL */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_IND_ESTADO_CIVIL);

            /*" -1405- MOVE 'A' TO LK-PF-STA-PESSOA */
            _.Move("A", LK_PF_PARAMETRO.LK_PF_STA_PESSOA);

            /*" -1406- MOVE ' ' TO LK-PF-NOM-TRATAMENTO */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_NOM_TRATAMENTO);

            /*" -1407- MOVE ' ' TO LK-PF-COD-UF */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_COD_UF);

            /*" -1408- MOVE 0 TO LK-PF-NUM-MUNICIPIO */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_MUNICIPIO);

            /*" -1409- MOVE 0 TO LK-PF-NUM-INSC-SOCIAL */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_INSC_SOCIAL);

            /*" -1410- MOVE 0 TO LK-PF-NUM-DV-INSC-SOCIAL */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_DV_INSC_SOCIAL);

            /*" -1411- MOVE 0 TO LK-PF-NUM-GRAU-INSTRUCAO */
            _.Move(0, LK_PF_PARAMETRO.LK_PF_NUM_GRAU_INSTRUCAO);

            /*" -1412- MOVE ' ' TO LK-PF-NOM-REDUZIDO */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_NOM_REDUZIDO);

            /*" -1413- MOVE ' ' TO LK-PF-COD-CBO */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_COD_CBO);

            /*" -1414- MOVE ' ' TO LK-PF-NOM-PRIMEIRO */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_NOM_PRIMEIRO);

            /*" -1416- MOVE ' ' TO LK-PF-NOM-ULTIMO. */
            _.Move(" ", LK_PF_PARAMETRO.LK_PF_NOM_ULTIMO);

            /*" -1418- CALL 'GE0500B' USING LK-PF-PARAMETRO. */
            _.Call("GE0500B", LK_PF_PARAMETRO);

            /*" -1419- IF LK-PF-NUM-PESSOA EQUAL 0 OR LK-PF-IND-ERRO EQUAL 'SIM' */

            if (LK_PF_PARAMETRO.LK_PF_NUM_PESSOA == 0 || LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_IND_ERRO == "SIM")
            {

                /*" -1420- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1421- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1423- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1426- MOVE 'ERRO NA CHAMADA DA ROTINA GE0500B' TO WS-MSG */
                _.Move("ERRO NA CHAMADA DA ROTINA GE0500B", WS_MSG);

                /*" -1427- IF LK-PF-NUM-PESSOA EQUAL 0 */

                if (LK_PF_PARAMETRO.LK_PF_NUM_PESSOA == 0)
                {

                    /*" -1428- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1429- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0500B' */
                    _.Display($"ERRO NA CHAMADA DA ROTINA GE0500B");

                    /*" -1430- DISPLAY 'GE0500B - CADASTRA PESSOA FISICA' */
                    _.Display($"GE0500B - CADASTRA PESSOA FISICA");

                    /*" -1431- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1432- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1433- DISPLAY 'CLIENTES-CGCCPF..... ' CLIENTES-CGCCPF */
                    _.Display($"CLIENTES-CGCCPF..... {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                    /*" -1434- DISPLAY 'NUMERO DA PESSOA ESTA ZERADO' */
                    _.Display($"NUMERO DA PESSOA ESTA ZERADO");

                    /*" -1436- END-IF */
                }


                /*" -1437- IF LK-PF-IND-ERRO EQUAL 'SIM' */

                if (LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_IND_ERRO == "SIM")
                {

                    /*" -1438- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1439- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0500B' */
                    _.Display($"ERRO NA CHAMADA DA ROTINA GE0500B");

                    /*" -1440- DISPLAY 'GE0500B - CADASTRA PESSOA FISICA' */
                    _.Display($"GE0500B - CADASTRA PESSOA FISICA");

                    /*" -1441- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1442- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1443- DISPLAY 'CLIENTES-CGCCPF..... ' CLIENTES-CGCCPF */
                    _.Display($"CLIENTES-CGCCPF..... {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                    /*" -1444- DISPLAY 'LK-PF-MSG-ERRO...... ' LK-PF-MSG-ERRO */
                    _.Display($"LK-PF-MSG-ERRO...... {LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_MSG_ERRO}");

                    /*" -1445- DISPLAY 'LK-PF-SQLCODE....... ' LK-PF-SQLCODE */
                    _.Display($"LK-PF-SQLCODE....... {LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_SQLCODE}");

                    /*" -1446- DISPLAY 'LK-PF-NOME-TABELA... ' LK-PF-NOME-TABELA */
                    _.Display($"LK-PF-NOME-TABELA... {LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_NOME_TABELA}");

                    /*" -1447- DISPLAY 'LK-PF-MSG-ADICIONAL. ' LK-PF-MSG-ADICIONAL */
                    _.Display($"LK-PF-MSG-ADICIONAL. {LK_PF_PARAMETRO.LK_PF_PARAMETROS_SAIDA.LK_PF_MSG_ADICIONAL}");

                    /*" -1449- END-IF */
                }


                /*" -1449- PERFORM P30000-00-FINALIZA. */

                P30000_00_FINALIZA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22331_99_SAIDA*/

        [StopWatch]
        /*" P22332-00-PESSOA-JURIDICA-SECTION */
        private void P22332_00_PESSOA_JURIDICA_SECTION()
        {
            /*" -1460- MOVE 'P22332' TO WS-NR-PARAG. */
            _.Move("P22332", WS_DISPLAY.WS_NR_PARAG);

            /*" -1462- INITIALIZE LK-PJ-PARAMETRO. */
            _.Initialize(
                LK_PJ_PARAMETRO
            );

            /*" -1463- MOVE '1' TO LK-PJ-TIPO-UTILIZACAO. */
            _.Move("1", LK_PJ_PARAMETRO.LK_PJ_TIPO_UTILIZACAO);

            /*" -1464- MOVE 'N' TO LK-PJ-PESSOA-ESPECIAL. */
            _.Move("N", LK_PJ_PARAMETRO.LK_PJ_PESSOA_ESPECIAL);

            /*" -1465- MOVE 'CB0110B' TO LK-PJ-PROGRAMA-CHAMADOR. */
            _.Move("CB0110B", LK_PJ_PARAMETRO.LK_PJ_PROGRAMA_CHAMADOR);

            /*" -1466- MOVE 'CB0110B' TO LK-PJ-NOME-USUARIO */
            _.Move("CB0110B", LK_PJ_PARAMETRO.LK_PJ_NOME_USUARIO);

            /*" -1467- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-PJ-DTH-CADASTRAMENTO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_PJ_PARAMETRO.LK_PJ_DTH_CADASTRAMENTO);

            /*" -1468- MOVE CLIENTES-TIPO-PESSOA TO LK-PJ-IND-PESSOA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_PJ_PARAMETRO.LK_PJ_IND_PESSOA);

            /*" -1469- MOVE 'S' TO LK-PJ-STA-INF-INTEGRA. */
            _.Move("S", LK_PJ_PARAMETRO.LK_PJ_STA_INF_INTEGRA);

            /*" -1470- MOVE CLIENTES-CGCCPF TO W-NUM-CGC-INT-A */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WS_VARIAVEIS.W_NUM_CGC_INT_A);

            /*" -1471- MOVE W-NUM-CGC-INT-NUM TO LK-PJ-NUM-CNPJ */
            _.Move(WS_VARIAVEIS.W_NUM_CGC_INT.W_NUM_CGC_INT_NUM, LK_PJ_PARAMETRO.LK_PJ_NUM_CNPJ);

            /*" -1472- MOVE W-NUM-CGC-INT-FILIAL TO LK-PJ-NUM-FILIAL */
            _.Move(WS_VARIAVEIS.W_NUM_CGC_INT.W_NUM_CGC_INT_FILIAL, LK_PJ_PARAMETRO.LK_PJ_NUM_FILIAL);

            /*" -1473- MOVE W-NUM-CGC-INT-DV TO LK-PJ-NUM-DV-CNPJ */
            _.Move(WS_VARIAVEIS.W_NUM_CGC_INT.W_NUM_CGC_INT_DV, LK_PJ_PARAMETRO.LK_PJ_NUM_DV_CNPJ);

            /*" -1474- MOVE CLIENTES-NOME-RAZAO TO LK-PJ-NOM-RAZAO-SOCIAL */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LK_PJ_PARAMETRO.LK_PJ_NOM_RAZAO_SOCIAL);

            /*" -1475- MOVE CLIENTES-NOME-RAZAO TO LK-PJ-NOM-FANTASIA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LK_PJ_PARAMETRO.LK_PJ_NOM_FANTASIA);

            /*" -1476- MOVE 0 TO LK-PJ-NUM-RAMO-ATIVIDADE */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_RAMO_ATIVIDADE);

            /*" -1477- MOVE ' ' TO LK-PJ-NOM-SIGLA-PESSOA */
            _.Move(" ", LK_PJ_PARAMETRO.LK_PJ_NOM_SIGLA_PESSOA);

            /*" -1478- MOVE ' ' TO LK-PJ-COD-CNAE */
            _.Move(" ", LK_PJ_PARAMETRO.LK_PJ_COD_CNAE);

            /*" -1479- MOVE 0 TO LK-PJ-NUM-SOCIOS */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_SOCIOS);

            /*" -1480- MOVE 'N' TO LK-PJ-STA-FRANQUIA */
            _.Move("N", LK_PJ_PARAMETRO.LK_PJ_STA_FRANQUIA);

            /*" -1481- MOVE 'N' TO LK-PJ-IND-FINALIDADE */
            _.Move("N", LK_PJ_PARAMETRO.LK_PJ_IND_FINALIDADE);

            /*" -1482- MOVE ' ' TO LK-PJ-DTH-FUNDACAO */
            _.Move(" ", LK_PJ_PARAMETRO.LK_PJ_DTH_FUNDACAO);

            /*" -1483- MOVE 'A' TO LK-PJ-STA-PESSOA */
            _.Move("A", LK_PJ_PARAMETRO.LK_PJ_STA_PESSOA);

            /*" -1484- MOVE ' ' TO LK-PJ-COD-UF */
            _.Move(" ", LK_PJ_PARAMETRO.LK_PJ_COD_UF);

            /*" -1485- MOVE 0 TO LK-PJ-NUM-MUNICIPIO */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_MUNICIPIO);

            /*" -1486- MOVE 0 TO LK-PJ-NUM-INSC-ESTADUAL */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_INSC_ESTADUAL);

            /*" -1488- MOVE 0 TO LK-PJ-NUM-INSC-MUNICIPAL */
            _.Move(0, LK_PJ_PARAMETRO.LK_PJ_NUM_INSC_MUNICIPAL);

            /*" -1490- CALL 'GE0501B' USING LK-PJ-PARAMETRO. */
            _.Call("GE0501B", LK_PJ_PARAMETRO);

            /*" -1491- IF LK-PJ-NUM-PESSOA EQUAL 0 OR LK-PJ-IND-ERRO EQUAL 'SIM' */

            if (LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA == 0 || LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_IND_ERRO == "SIM")
            {

                /*" -1492- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1493- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1495- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1498- MOVE 'ERRO NA CHAMADA DA ROTINA GE0501B' TO WS-MSG */
                _.Move("ERRO NA CHAMADA DA ROTINA GE0501B", WS_MSG);

                /*" -1499- IF LK-PJ-NUM-PESSOA EQUAL 0 */

                if (LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA == 0)
                {

                    /*" -1500- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1501- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0501B' */
                    _.Display($"ERRO NA CHAMADA DA ROTINA GE0501B");

                    /*" -1502- DISPLAY 'GE0501B - CADASTRA PESSOA JURIDICA' */
                    _.Display($"GE0501B - CADASTRA PESSOA JURIDICA");

                    /*" -1503- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1504- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1505- DISPLAY 'CLIENTES-CGCCPF..... ' CLIENTES-CGCCPF */
                    _.Display($"CLIENTES-CGCCPF..... {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                    /*" -1506- DISPLAY 'NUMERO DA PESSOA ESTA ZERADO' */
                    _.Display($"NUMERO DA PESSOA ESTA ZERADO");

                    /*" -1508- END-IF */
                }


                /*" -1509- IF LK-PJ-IND-ERRO EQUAL 'SIM' */

                if (LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_IND_ERRO == "SIM")
                {

                    /*" -1510- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1511- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0501B' */
                    _.Display($"ERRO NA CHAMADA DA ROTINA GE0501B");

                    /*" -1512- DISPLAY 'GE0501B - CADASTRA PESSOA JURIDICA' */
                    _.Display($"GE0501B - CADASTRA PESSOA JURIDICA");

                    /*" -1513- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1514- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1515- DISPLAY 'CLIENTES-CGCCPF..... ' CLIENTES-CGCCPF */
                    _.Display($"CLIENTES-CGCCPF..... {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                    /*" -1516- DISPLAY 'LK-PJ-MSG-ERRO...... ' LK-PJ-IND-ERRO */
                    _.Display($"LK-PJ-MSG-ERRO...... {LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_IND_ERRO}");

                    /*" -1517- DISPLAY 'LK-PJ-SQLCODE....... ' LK-PJ-MSG-ERRO */
                    _.Display($"LK-PJ-SQLCODE....... {LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_MSG_ERRO}");

                    /*" -1518- DISPLAY 'LK-PJ-NOME-TABELA... ' LK-PJ-SQLCODE */
                    _.Display($"LK-PJ-NOME-TABELA... {LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_SQLCODE}");

                    /*" -1519- DISPLAY 'LK-PJ-MSG-ADICIONAL. ' LK-PJ-NOME-TABELA */
                    _.Display($"LK-PJ-MSG-ADICIONAL. {LK_PJ_PARAMETRO.LK_PJ_PARAMETROS_SAIDA.LK_PJ_NOME_TABELA}");

                    /*" -1521- END-IF */
                }


                /*" -1521- PERFORM P30000-00-FINALIZA. */

                P30000_00_FINALIZA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22332_99_SAIDA*/

        [StopWatch]
        /*" P22333-00-ENDERECO-SECTION */
        private void P22333_00_ENDERECO_SECTION()
        {
            /*" -1532- MOVE 'P22333' TO WS-NR-PARAG. */
            _.Move("P22333", WS_DISPLAY.WS_NR_PARAG);

            /*" -1534- INITIALIZE LK-EN-PARAMETRO. */
            _.Initialize(
                LK_EN_PARAMETRO
            );

            /*" -1535- MOVE '1' TO LK-EN-TIPO-UTILIZACAO. */
            _.Move("1", LK_EN_PARAMETRO.LK_EN_TIPO_UTILIZACAO);

            /*" -1536- MOVE 'CB0110B' TO LK-EN-PROGRAMA-CHAMADOR. */
            _.Move("CB0110B", LK_EN_PARAMETRO.LK_EN_PROGRAMA_CHAMADOR);

            /*" -1538- MOVE 'CB0110B' TO LK-EN-NOME-USUARIO */
            _.Move("CB0110B", LK_EN_PARAMETRO.LK_EN_NOME_USUARIO);

            /*" -1539- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1540- MOVE LK-PF-NUM-PESSOA TO LK-EN-NUM-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_PESSOA);

                /*" -1541- MOVE LK-PF-NUM-DV-PESSOA TO LK-EN-NUM-DV-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_DV_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_DV_PESSOA);

                /*" -1542- ELSE */
            }
            else
            {


                /*" -1543- MOVE LK-PJ-NUM-PESSOA TO LK-EN-NUM-PESSOA */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_PESSOA);

                /*" -1545- MOVE LK-PJ-NUM-DV-PESSOA TO LK-EN-NUM-DV-PESSOA. */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_DV_PESSOA, LK_EN_PARAMETRO.LK_EN_NUM_DV_PESSOA);
            }


            /*" -1546- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-EN-DTH-CADASTRAMENTO-END */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_EN_PARAMETRO.LK_EN_DTH_CADASTRAMENTO_END);

            /*" -1547- MOVE CLIENTES-TIPO-PESSOA TO LK-EN-IND-PESSOA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_EN_PARAMETRO.LK_EN_IND_PESSOA);

            /*" -1548- MOVE 'S' TO LK-EN-STA-INF-INTEGRA */
            _.Move("S", LK_EN_PARAMETRO.LK_EN_STA_INF_INTEGRA);

            /*" -1549- MOVE 'S' TO LK-EN-STA-PROPAGANDA */
            _.Move("S", LK_EN_PARAMETRO.LK_EN_STA_PROPAGANDA);

            /*" -1550- MOVE ENDERECO-ENDERECO TO LK-EN-NOM-LOGRADOURO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LK_EN_PARAMETRO.LK_EN_NOM_LOGRADOURO);

            /*" -1551- MOVE 'R' TO LK-EN-IND-ENDERECO */
            _.Move("R", LK_EN_PARAMETRO.LK_EN_IND_ENDERECO);

            /*" -1552- MOVE 'A' TO LK-EN-STA-ENDERECO */
            _.Move("A", LK_EN_PARAMETRO.LK_EN_STA_ENDERECO);

            /*" -1553- MOVE ' ' TO LK-EN-DES-NUM-IMOVEL */
            _.Move(" ", LK_EN_PARAMETRO.LK_EN_DES_NUM_IMOVEL);

            /*" -1554- MOVE ' ' TO LK-EN-DES-COMPL-ENDERECO */
            _.Move(" ", LK_EN_PARAMETRO.LK_EN_DES_COMPL_ENDERECO);

            /*" -1555- MOVE ENDERECO-BAIRRO TO LK-EN-NOM-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LK_EN_PARAMETRO.LK_EN_NOM_BAIRRO);

            /*" -1556- MOVE ENDERECO-CIDADE TO LK-EN-NOM-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LK_EN_PARAMETRO.LK_EN_NOM_CIDADE);

            /*" -1557- MOVE ENDERECO-CEP TO LK-EN-COD-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LK_EN_PARAMETRO.LK_EN_COD_CEP);

            /*" -1558- MOVE ENDERECO-SIGLA-UF TO LK-EN-COD-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LK_EN_PARAMETRO.LK_EN_COD_UF);

            /*" -1560- MOVE 'S' TO LK-EN-STA-CORRESPONDER */
            _.Move("S", LK_EN_PARAMETRO.LK_EN_STA_CORRESPONDER);

            /*" -1562- CALL 'GE0502B' USING LK-EN-PARAMETRO. */
            _.Call("GE0502B", LK_EN_PARAMETRO);

            /*" -1563- IF LK-EN-IND-ERRO EQUAL 'SIM' */

            if (LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_IND_ERRO == "SIM")
            {

                /*" -1564- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1565- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1567- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1568- DISPLAY '---------------------------------' */
                _.Display($"---------------------------------");

                /*" -1569- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0502B' */
                _.Display($"ERRO NA CHAMADA DA ROTINA GE0502B");

                /*" -1570- DISPLAY 'GE0502B - CADASTRA PESSOA ENDERECO' */
                _.Display($"GE0502B - CADASTRA PESSOA ENDERECO");

                /*" -1571- DISPLAY '---------------------------------' */
                _.Display($"---------------------------------");

                /*" -1572- DISPLAY ' ' */
                _.Display($" ");

                /*" -1573- DISPLAY 'CLIENTES-CGCCPF..... ' CLIENTES-CGCCPF */
                _.Display($"CLIENTES-CGCCPF..... {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -1574- DISPLAY 'LK-EN-MSG-ERRO...... ' LK-EN-MSG-ERRO */
                _.Display($"LK-EN-MSG-ERRO...... {LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_MSG_ERRO}");

                /*" -1575- DISPLAY 'LK-EN-SQLCODE....... ' LK-EN-SQLCODE */
                _.Display($"LK-EN-SQLCODE....... {LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_SQLCODE}");

                /*" -1576- DISPLAY 'LK-EN-NOME-TABELA... ' LK-EN-NOME-TABELA */
                _.Display($"LK-EN-NOME-TABELA... {LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_NOME_TABELA}");

                /*" -1578- DISPLAY 'LK-EN-MSG-ADICIONAL. ' LK-EN-MSG-ADICIONAL */
                _.Display($"LK-EN-MSG-ADICIONAL. {LK_EN_PARAMETRO.LK_EN_PARAMETROS_SAIDA.LK_EN_MSG_ADICIONAL}");

                /*" -1580- MOVE 'ERRO NA CHAMADA DA ROTINA GE0502B' TO WS-MSG */
                _.Move("ERRO NA CHAMADA DA ROTINA GE0502B", WS_MSG);

                /*" -1580- PERFORM P30000-00-FINALIZA. */

                P30000_00_FINALIZA_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22333_99_SAIDA*/

        [StopWatch]
        /*" P22334-00-BANCO-SECTION */
        private void P22334_00_BANCO_SECTION()
        {
            /*" -1591- MOVE 'P22334' TO WS-NR-PARAG. */
            _.Move("P22334", WS_DISPLAY.WS_NR_PARAG);

            /*" -1593- INITIALIZE LK-BC-PARAMETRO. */
            _.Initialize(
                LK_BC_PARAMETRO
            );

            /*" -1594- MOVE '1' TO LK-BC-TIPO-UTILIZACAO. */
            _.Move("1", LK_BC_PARAMETRO.LK_BC_TIPO_UTILIZACAO);

            /*" -1595- MOVE 'CB0110B' TO LK-BC-PROGRAMA-CHAMADOR. */
            _.Move("CB0110B", LK_BC_PARAMETRO.LK_BC_PROGRAMA_CHAMADOR);

            /*" -1597- MOVE 'CB0110B' TO LK-BC-NOME-USUARIO */
            _.Move("CB0110B", LK_BC_PARAMETRO.LK_BC_NOME_USUARIO);

            /*" -1598- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1599- MOVE 1 TO LK-BC-IND-CONTA-BANCARIA */
                _.Move(1, LK_BC_PARAMETRO.LK_BC_IND_CONTA_BANCARIA);

                /*" -1600- MOVE LK-PF-NUM-PESSOA TO LK-BC-NUM-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_PESSOA);

                /*" -1601- MOVE LK-PF-NUM-DV-PESSOA TO LK-BC-NUM-DV-PESSOA */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_DV_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_DV_PESSOA);

                /*" -1602- ELSE */
            }
            else
            {


                /*" -1603- MOVE 2 TO LK-BC-IND-CONTA-BANCARIA */
                _.Move(2, LK_BC_PARAMETRO.LK_BC_IND_CONTA_BANCARIA);

                /*" -1604- MOVE LK-PJ-NUM-PESSOA TO LK-BC-NUM-PESSOA */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_PESSOA);

                /*" -1605- MOVE LK-PJ-NUM-DV-PESSOA TO LK-BC-NUM-DV-PESSOA */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_DV_PESSOA, LK_BC_PARAMETRO.LK_BC_NUM_DV_PESSOA);

                /*" -1607- END-IF */
            }


            /*" -1608- MOVE SISTEMAS-DATA-MOV-ABERTO TO LK-BC-DTH-CADASTRAMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LK_BC_PARAMETRO.LK_BC_DTH_CADASTRAMENTO);

            /*" -1609- MOVE CLIENTES-TIPO-PESSOA TO LK-BC-IND-PESSOA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA, LK_BC_PARAMETRO.LK_BC_IND_PESSOA);

            /*" -1610- MOVE 'S' TO LK-BC-STA-INF-INTEGRA */
            _.Move("S", LK_BC_PARAMETRO.LK_BC_STA_INF_INTEGRA);

            /*" -1611- MOVE 0 TO LK-BC-SEQ-CONTA-BANCARIA */
            _.Move(0, LK_BC_PARAMETRO.LK_BC_SEQ_CONTA_BANCARIA);

            /*" -1612- MOVE 'A' TO LK-BC-STA-CONTA */
            _.Move("A", LK_BC_PARAMETRO.LK_BC_STA_CONTA);

            /*" -1613- MOVE GE381-COD-BCO TO LK-BC-COD-BANCO */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO, LK_BC_PARAMETRO.LK_BC_COD_BANCO);

            /*" -1614- MOVE GE381-COD-AGENCIA TO WS-AGENC-AG */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA, WS_VARIAVEIS.WS_AGENC01.WS_AGENC_AG);

            /*" -1615- MOVE WS-AGENC01 TO WS-AGENC10 */
            _.Move(WS_VARIAVEIS.WS_AGENC01, WS_VARIAVEIS.WS_AGENC10);

            /*" -1617- MOVE 6 TO WS-IND1 WS-IND2 */
            _.Move(6, WS_IND1, WS_IND2);

            /*" -1619- MOVE ZEROS TO WS-AGENC20 */
            _.Move(0, WS_VARIAVEIS.WS_AGENC20);

            /*" -1620- PERFORM 5 TIMES */

            for (int i = 0; i < 5; i++)
            {

                /*" -1621- SUBTRACT 1 FROM WS-IND1 */
                WS_IND1.Value = WS_IND1 - 1;

                /*" -1622- IF CHAR10(WS-IND1) IS NUMERIC */

                if (WS_VARIAVEIS.FILLER_36.CHAR10[WS_IND1].IsNumeric())
                {

                    /*" -1623- SUBTRACT 1 FROM WS-IND2 */
                    WS_IND2.Value = WS_IND2 - 1;

                    /*" -1624- MOVE CHAR10(WS-IND1) TO CHAR20(WS-IND2) */
                    _.Move(WS_VARIAVEIS.FILLER_36.CHAR10[WS_IND1], WS_VARIAVEIS.FILLER_37.CHAR20[WS_IND2]);

                    /*" -1625- END-IF */
                }


                /*" -1627- END-PERFORM. */
            }

            /*" -1629- MOVE WS-AGENC20 TO LK-BC-COD-AGENCIA GE381-COD-AGENCIA */
            _.Move(WS_VARIAVEIS.WS_AGENC20, LK_BC_PARAMETRO.LK_BC_COD_AGENCIA, GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA);

            /*" -1630- MOVE GE381-COD-OPERACAO TO LK-BC-NUM-OPERACAO-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO, LK_BC_PARAMETRO.LK_BC_NUM_OPERACAO_CONTA);

            /*" -1631- MOVE GE381-NUM-CONTA TO LK-BC-NUM-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA, LK_BC_PARAMETRO.LK_BC_NUM_CONTA);

            /*" -1633- MOVE GE381-NUM-CONTA-DV1 TO LK-BC-NUM-DV-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1, LK_BC_PARAMETRO.LK_BC_NUM_DV_CONTA);

            /*" -1635- CALL 'GE0503B' USING LK-BC-PARAMETRO. */
            _.Call("GE0503B", LK_BC_PARAMETRO);

            /*" -1636- IF LK-BC-IND-ERRO EQUAL 'SIM' */

            if (LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_IND_ERRO == "SIM")
            {

                /*" -1637- IF LK-BC-SQLCODE EQUAL +100 */

                if (LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_SQLCODE == +100)
                {

                    /*" -1638- MOVE 'S' TO WS-GERA-CHEQUE */
                    _.Move("S", WS_GERA_CHEQUE);

                    /*" -1640- MOVE 'BANCO/AGENCIA NAO CADASTRADO-CONVERTIDO P/ CHEQUE' TO WS-MENSAGEM */
                    _.Move("BANCO/AGENCIA NAO CADASTRADO-CONVERTIDO P/ CHEQUE", WS_MENSAGEM);

                    /*" -1641- ELSE */
                }
                else
                {


                    /*" -1642- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                    _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                    /*" -1643- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                    _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                    /*" -1645- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                    _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                    /*" -1646- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1647- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0503B' */
                    _.Display($"ERRO NA CHAMADA DA ROTINA GE0503B");

                    /*" -1648- DISPLAY 'GE0503B - CADASTRA PESSOA CONTA BANCARIA' */
                    _.Display($"GE0503B - CADASTRA PESSOA CONTA BANCARIA");

                    /*" -1649- DISPLAY '---------------------------------' */
                    _.Display($"---------------------------------");

                    /*" -1650- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1651- DISPLAY 'CLIENTES-CGCCPF..... ' CLIENTES-CGCCPF */
                    _.Display($"CLIENTES-CGCCPF..... {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                    /*" -1652- DISPLAY 'LK-BC-MSG-ERRO...... ' LK-BC-MSG-ERRO */
                    _.Display($"LK-BC-MSG-ERRO...... {LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_MSG_ERRO}");

                    /*" -1653- DISPLAY 'LK-BC-SQLCODE....... ' LK-BC-SQLCODE */
                    _.Display($"LK-BC-SQLCODE....... {LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_SQLCODE}");

                    /*" -1654- DISPLAY 'LK-BC-NOME-TABELA... ' LK-BC-NOME-TABELA */
                    _.Display($"LK-BC-NOME-TABELA... {LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_NOME_TABELA}");

                    /*" -1656- DISPLAY 'LK-BC-MSG-ADICIONAL. ' LK-BC-MSG-ADICIONAL */
                    _.Display($"LK-BC-MSG-ADICIONAL. {LK_BC_PARAMETRO.LK_BC_PARAMETROS_SAIDA.LK_BC_MSG_ADICIONAL}");

                    /*" -1658- MOVE 'ERRO NA CHAMADA DA ROTINA GE0503B' TO WS-MSG */
                    _.Move("ERRO NA CHAMADA DA ROTINA GE0503B", WS_MSG);

                    /*" -1658- PERFORM P30000-00-FINALIZA. */

                    P30000_00_FINALIZA_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22334_99_SAIDA*/

        [StopWatch]
        /*" P22340-00-PESSOA-LEGADO-SECTION */
        private void P22340_00_PESSOA_LEGADO_SECTION()
        {
            /*" -1669- MOVE 'P2090' TO WS-NR-PARAG. */
            _.Move("P2090", WS_DISPLAY.WS_NR_PARAG);

            /*" -1677- INITIALIZE LK-LEGADO-PARAMETRO. */
            _.Initialize(
                LK_LEGADO_PARAMETRO
            );

            /*" -1681- MOVE 1 TO LK-COD-OPERACAO */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_COD_OPERACAO);

            /*" -1682- MOVE FOLLOUP-NUM-APOLICE TO LK-NUM-APOLICE */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE, LK_LEGADO_PARAMETRO.LK_NUM_APOLICE);

            /*" -1683- MOVE FOLLOUP-NUM-ENDOSSO TO LK-NUM-ENDOSSO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO, LK_LEGADO_PARAMETRO.LK_NUM_ENDOSSO);

            /*" -1684- MOVE FOLLOUP-NUM-PARCELA TO LK-NUM-PARCELA */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA, LK_LEGADO_PARAMETRO.LK_NUM_PARCELA);

            /*" -1688- MOVE 0 TO LK-OCORR-HISTORICO. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_OCORR_HISTORICO);

            /*" -1689- MOVE LK-EN-NUM-PESSOA TO LK-NUM-PESSOA */
            _.Move(LK_EN_PARAMETRO.LK_EN_NUM_PESSOA, LK_LEGADO_PARAMETRO.LK_NUM_PESSOA);

            /*" -1715- MOVE 0 TO LK-NUM-OCORR-MOVTO. */
            _.Move(0, LK_LEGADO_PARAMETRO.LK_NUM_OCORR_MOVTO);

            /*" -1716- MOVE 'S' TO LK-IND-INFORMACAO-PEDIDA(1) */
            _.Move("S", LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[1].LK_IND_INFORMACAO_PEDIDA);

            /*" -1717- MOVE 1 TO LK-IND-ENTIDADE-PEDIDA(1). */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[1].LK_IND_ENTIDADE_PEDIDA);

            /*" -1721- MOVE LK-EN-SEQ-ENDERECO TO LK-SEQ-ENTIDADE(1). */
            _.Move(LK_EN_PARAMETRO.LK_EN_SEQ_ENDERECO, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[1].LK_SEQ_ENTIDADE);

            /*" -1722- IF WS-GERA-CHEQUE EQUAL 'N' */

            if (WS_GERA_CHEQUE == "N")
            {

                /*" -1723- MOVE 'S' TO LK-IND-INFORMACAO-PEDIDA(3) */
                _.Move("S", LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[3].LK_IND_INFORMACAO_PEDIDA);

                /*" -1724- MOVE 3 TO LK-IND-ENTIDADE-PEDIDA(3) */
                _.Move(3, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[3].LK_IND_ENTIDADE_PEDIDA);

                /*" -1731- MOVE LK-BC-SEQ-CONTA-BANCARIA TO LK-SEQ-ENTIDADE(3). */
                _.Move(LK_BC_PARAMETRO.LK_BC_SEQ_CONTA_BANCARIA, LK_LEGADO_PARAMETRO.LK_TABELA_PONTEIRO[3].LK_SEQ_ENTIDADE);
            }


            /*" -1732- IF WS-GERA-CHEQUE EQUAL 'S' */

            if (WS_GERA_CHEQUE == "S")
            {

                /*" -1733- MOVE 1 TO LK-COD-EVENTO */
                _.Move(1, LK_LEGADO_PARAMETRO.LK_COD_EVENTO);

                /*" -1734- ELSE */
            }
            else
            {


                /*" -1735- MOVE 3 TO LK-COD-EVENTO */
                _.Move(3, LK_LEGADO_PARAMETRO.LK_COD_EVENTO);

                /*" -1737- END-IF */
            }


            /*" -1738- MOVE 'CB' TO LK-IDE-SISTEMA */
            _.Move("CB", LK_LEGADO_PARAMETRO.LK_IDE_SISTEMA);

            /*" -1745- MOVE FOLLOUP-DATA-MOVIMENTO TO LK-DTH-MOVIMENTO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO, LK_LEGADO_PARAMETRO.LK_DTH_MOVIMENTO);

            /*" -1755- MOVE 1 TO LK-IND-ESTRUTURA */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_IND_ESTRUTURA);

            /*" -1765- MOVE 3 TO LK-IND-ORIGEM-FUNC */
            _.Move(3, LK_LEGADO_PARAMETRO.LK_IND_ORIGEM_FUNC);

            /*" -1766- IF WS-GERA-CHEQUE EQUAL 'S' */

            if (WS_GERA_CHEQUE == "S")
            {

                /*" -1767- MOVE 4 TO LK-IND-EVENTO */
                _.Move(4, LK_LEGADO_PARAMETRO.LK_IND_EVENTO);

                /*" -1768- ELSE */
            }
            else
            {


                /*" -1769- MOVE 1 TO LK-IND-EVENTO */
                _.Move(1, LK_LEGADO_PARAMETRO.LK_IND_EVENTO);

                /*" -1771- END-IF */
            }


            /*" -1772- MOVE 'CB0110B' TO LK-NOM-PROGRAMA. */
            _.Move("CB0110B", LK_LEGADO_PARAMETRO.LK_NOM_PROGRAMA);

            /*" -1782- MOVE 'CB0110B' TO LK-COD-USUARIO . */
            _.Move("CB0110B", LK_LEGADO_PARAMETRO.LK_COD_USUARIO);

            /*" -1787- MOVE 1 TO LK-IND-RELACIONAMENTO. */
            _.Move(1, LK_LEGADO_PARAMETRO.LK_IND_RELACIONAMENTO);

            /*" -1789- MOVE FOLLOUP-HORA-OPERACAO TO LK-HORA-OPERACAO. */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO, LK_LEGADO_PARAMETRO.LK_HORA_OPERACAO);

            /*" -1791- CALL 'GE0550B' USING LK-LEGADO-PARAMETRO. */
            _.Call("GE0550B", LK_LEGADO_PARAMETRO);

            /*" -1792- IF H-OUT-COD-RETORNO EQUAL 1 */

            if (LK_LEGADO_PARAMETRO.H_OUT_COD_RETORNO == 1)
            {

                /*" -1793- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1794- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1796- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1797- DISPLAY '---------------------------------' */
                _.Display($"---------------------------------");

                /*" -1798- DISPLAY 'ERRO NA CHAMADA DA ROTINA GE0550B' */
                _.Display($"ERRO NA CHAMADA DA ROTINA GE0550B");

                /*" -1799- DISPLAY 'GE0550B - CADASTRA PESSOA X LEGADO' */
                _.Display($"GE0550B - CADASTRA PESSOA X LEGADO");

                /*" -1800- DISPLAY '---------------------------------' */
                _.Display($"---------------------------------");

                /*" -1801- DISPLAY ' ' */
                _.Display($" ");

                /*" -1802- DISPLAY 'H-OUT-COD-RETORNO... ' H-OUT-COD-RETORNO */
                _.Display($"H-OUT-COD-RETORNO... {LK_LEGADO_PARAMETRO.H_OUT_COD_RETORNO}");

                /*" -1803- DISPLAY 'H-OUT-MENSAGEM...... ' H-OUT-MENSAGEM */
                _.Display($"H-OUT-MENSAGEM...... {LK_LEGADO_PARAMETRO.H_OUT_MENSAGEM}");

                /*" -1804- DISPLAY 'H-OUT-COD-RETORNO-SQL. ' H-OUT-COD-RETORNO-SQL */
                _.Display($"H-OUT-COD-RETORNO-SQL. {LK_LEGADO_PARAMETRO.H_OUT_COD_RETORNO_SQL}");

                /*" -1805- DISPLAY 'H-OUT-SQLERRMC...... ' H-OUT-SQLERRMC */
                _.Display($"H-OUT-SQLERRMC...... {LK_LEGADO_PARAMETRO.H_OUT_SQLERRMC}");

                /*" -1807- DISPLAY 'H-OUT-SQLSTATE...... ' H-OUT-SQLSTATE */
                _.Display($"H-OUT-SQLSTATE...... {LK_LEGADO_PARAMETRO.H_OUT_SQLSTATE}");

                /*" -1809- MOVE 'ERRO NA CHAMADA DA ROTINA GE0550B' TO WS-MSG */
                _.Move("ERRO NA CHAMADA DA ROTINA GE0550B", WS_MSG);

                /*" -1811- PERFORM P30000-00-FINALIZA. */

                P30000_00_FINALIZA_SECTION();
            }


            /*" -1811- ADD 1 TO WS-QT-LEGAD. */
            WS_QT_LEGAD.Value = WS_QT_LEGAD + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22340_99_SAIDA*/

        [StopWatch]
        /*" P22350-00-GRAVA-CBCONDEV-SECTION */
        private void P22350_00_GRAVA_CBCONDEV_SECTION()
        {
            /*" -1825- MOVE 'P22350' TO WS-NR-PARAG. */
            _.Move("P22350", WS_DISPLAY.WS_NR_PARAG);

            /*" -1826- IF WS-GERA-CHEQUE EQUAL 'S' */

            if (WS_GERA_CHEQUE == "S")
            {

                /*" -1828- PERFORM P22351-00-GERA-CHEQUE. */

                P22351_00_GERA_CHEQUE_SECTION();
            }


            /*" -1830- PERFORM P22352-00-SELECT-CB040. */

            P22352_00_SELECT_CB040_SECTION();

            /*" -1831- MOVE CB040-NUM-OCORR-MOVTO TO CBCONDEV-NUM-CHEQUE-INTERNO. */
            _.Move(CB040.DCLCB_PESS_REC_ANT.CB040_NUM_OCORR_MOVTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);

            /*" -1832- MOVE ZEROS TO CBCONDEV-DIG-CHEQUE-INTERNO. */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

            /*" -1834- MOVE 'Z' TO CBCONDEV-TIPO-MOVIMENTO. */
            _.Move("Z", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);

            /*" -1836- PERFORM P22353-00-MONTA-CBCONDEV. */

            P22353_00_MONTA_CBCONDEV_SECTION();

            /*" -1838- PERFORM P22354-00-INCLUI-CBCONDEV. */

            P22354_00_INCLUI_CBCONDEV_SECTION();

            /*" -1839- IF WS-GERA-CHEQUE EQUAL 'S' */

            if (WS_GERA_CHEQUE == "S")
            {

                /*" -1841- ADD 1 TO WS-QT-DEVCC WS-QT-DEVCH */
                WS_QT_DEVCC.Value = WS_QT_DEVCC + 1;
                WS_QT_DEVCH.Value = WS_QT_DEVCH + 1;

                /*" -1842- MOVE WS-NUMCHQ TO CBCONDEV-NUM-CHEQUE-INTERNO */
                _.Move(WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);

                /*" -1843- MOVE WS-DIGCHQ TO CBCONDEV-DIG-CHEQUE-INTERNO */
                _.Move(WS_VARIAVEIS.WS_CHQINT.WS_DIGCHQ, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

                /*" -1845- MOVE '8' TO CBCONDEV-TIPO-MOVIMENTO */
                _.Move("8", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO);

                /*" -1846- PERFORM P22353-00-MONTA-CBCONDEV */

                P22353_00_MONTA_CBCONDEV_SECTION();

                /*" -1846- PERFORM P22354-00-INCLUI-CBCONDEV. */

                P22354_00_INCLUI_CBCONDEV_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22350_99_SAIDA*/

        [StopWatch]
        /*" P22351-00-GERA-CHEQUE-SECTION */
        private void P22351_00_GERA_CHEQUE_SECTION()
        {
            /*" -1857- MOVE 'P22351' TO WS-NR-PARAG. */
            _.Move("P22351", WS_DISPLAY.WS_NR_PARAG);

            /*" -1858- ADD 1 TO WS-NUMCHQ */
            WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ.Value = WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ + 1;

            /*" -1860- MOVE WS-NUMCHQ TO LPARM01. */
            _.Move(WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ, WS_VARIAVEIS.LPARM01);

            /*" -1877- COMPUTE WS-PARM01-AUX = LPARM01-01 * 8 + LPARM01-02 * 7 + LPARM01-03 * 6 + LPARM01-04 * 5 + LPARM01-05 * 4 + LPARM01-06 * 3 + LPARM01-07 * 2 + LPARM01-08 * 9 + LPARM01-09 * 8 + LPARM01-10 * 7 + LPARM01-11 * 6 + LPARM01-12 * 5 + LPARM01-13 * 4 + LPARM01-14 * 3 + LPARM01-15 * 2. */
            WS_PARM01_AUX.Value = WS_VARIAVEIS.FILLER_35.LPARM01_01 * 8 + WS_VARIAVEIS.FILLER_35.LPARM01_02 * 7 + WS_VARIAVEIS.FILLER_35.LPARM01_03 * 6 + WS_VARIAVEIS.FILLER_35.LPARM01_04 * 5 + WS_VARIAVEIS.FILLER_35.LPARM01_05 * 4 + WS_VARIAVEIS.FILLER_35.LPARM01_06 * 3 + WS_VARIAVEIS.FILLER_35.LPARM01_07 * 2 + WS_VARIAVEIS.FILLER_35.LPARM01_08 * 9 + WS_VARIAVEIS.FILLER_35.LPARM01_09 * 8 + WS_VARIAVEIS.FILLER_35.LPARM01_10 * 7 + WS_VARIAVEIS.FILLER_35.LPARM01_11 * 6 + WS_VARIAVEIS.FILLER_35.LPARM01_12 * 5 + WS_VARIAVEIS.FILLER_35.LPARM01_13 * 4 + WS_VARIAVEIS.FILLER_35.LPARM01_14 * 3 + WS_VARIAVEIS.FILLER_35.LPARM01_15 * 2;

            /*" -1880- DIVIDE WS-PARM01-AUX BY 11 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
            _.Divide(WS_PARM01_AUX, 11, WS_QUOCIENTE, WS_RESTO);

            /*" -1881- IF WS-RESTO EQUAL 1 */

            if (WS_RESTO == 1)
            {

                /*" -1882- MOVE 0 TO WS-DIGCHQ */
                _.Move(0, WS_VARIAVEIS.WS_CHQINT.WS_DIGCHQ);

                /*" -1883- ELSE */
            }
            else
            {


                /*" -1884- IF WS-RESTO EQUAL ZEROS */

                if (WS_RESTO == 00)
                {

                    /*" -1885- MOVE 1 TO WS-DIGCHQ */
                    _.Move(1, WS_VARIAVEIS.WS_CHQINT.WS_DIGCHQ);

                    /*" -1886- ELSE */
                }
                else
                {


                    /*" -1886- SUBTRACT WS-RESTO FROM 11 GIVING WS-DIGCHQ. */
                    WS_VARIAVEIS.WS_CHQINT.WS_DIGCHQ.Value = 11 - WS_RESTO;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22351_99_SAIDA*/

        [StopWatch]
        /*" P22352-00-SELECT-CB040-SECTION */
        private void P22352_00_SELECT_CB040_SECTION()
        {
            /*" -1897- MOVE 'P22352' TO WS-NR-PARAG. */
            _.Move("P22352", WS_DISPLAY.WS_NR_PARAG);

            /*" -1905- PERFORM P22352_00_SELECT_CB040_DB_SELECT_1 */

            P22352_00_SELECT_CB040_DB_SELECT_1();

            /*" -1908- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1909- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -1910- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -1912- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -1914- MOVE 'ERRO NA LEITURA DA TABELA .CB_PESS_PENDENCIA' TO WS-MSG */
                _.Move("ERRO NA LEITURA DA TABELA .CB_PESS_PENDENCIA", WS_MSG);

                /*" -1915- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -1915- END-IF. */
            }


        }

        [StopWatch]
        /*" P22352-00-SELECT-CB040-DB-SELECT-1 */
        public void P22352_00_SELECT_CB040_DB_SELECT_1()
        {
            /*" -1905- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_MOVTO),0) INTO :CB040-NUM-OCORR-MOVTO FROM SEGUROS.CB_PESS_PENDENCIA WHERE NUM_APOLICE = :FOLLOUP-NUM-APOLICE AND NUM_ENDOSSO = :FOLLOUP-NUM-ENDOSSO AND NUM_PARCELA = :FOLLOUP-NUM-PARCELA WITH UR END-EXEC */

            var p22352_00_SELECT_CB040_DB_SELECT_1_Query1 = new P22352_00_SELECT_CB040_DB_SELECT_1_Query1()
            {
                FOLLOUP_NUM_APOLICE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE.ToString(),
                FOLLOUP_NUM_ENDOSSO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO.ToString(),
                FOLLOUP_NUM_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA.ToString(),
            };

            var executed_1 = P22352_00_SELECT_CB040_DB_SELECT_1_Query1.Execute(p22352_00_SELECT_CB040_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CB040_NUM_OCORR_MOVTO, CB040.DCLCB_PESS_REC_ANT.CB040_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22352_99_SAIDA*/

        [StopWatch]
        /*" P22353-00-MONTA-CBCONDEV-SECTION */
        private void P22353_00_MONTA_CBCONDEV_SECTION()
        {
            /*" -1936- MOVE 'P22353' TO WS-NR-PARAG. */
            _.Move("P22353", WS_DISPLAY.WS_NR_PARAG);

            /*" -1938- ADD 1 TO WS-NRSEQ */
            WS_NRSEQ.Value = WS_NRSEQ + 1;

            /*" -1939- IF CBCONDEV-TIPO-MOVIMENTO EQUAL 'Z' */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO == "Z")
            {

                /*" -1940- MOVE '0' TO CBCONDEV-SIT-REGISTRO */
                _.Move("0", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);

                /*" -1941- ELSE */
            }
            else
            {


                /*" -1942- IF WS-GERA-CHEQUE EQUAL 'S' */

                if (WS_GERA_CHEQUE == "S")
                {

                    /*" -1943- MOVE '2' TO CBCONDEV-SIT-REGISTRO */
                    _.Move("2", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);

                    /*" -1944- ELSE */
                }
                else
                {


                    /*" -1946- MOVE '0' TO CBCONDEV-SIT-REGISTRO. */
                    _.Move("0", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO);
                }

            }


            /*" -1947- MOVE ZEROS TO CBCONDEV-COD-EMPRESA */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA);

            /*" -1948- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBCONDEV-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO);

            /*" -1950- MOVE WS-NRSEQ TO CBCONDEV-NUM-SEQUENCIA */
            _.Move(WS_NRSEQ, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA);

            /*" -1951- MOVE 0 TO CBCONDEV-NUM-TITULO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO);

            /*" -1952- MOVE ENDOSSOS-COD-FONTE TO CBCONDEV-COD-FONTE */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE);

            /*" -1953- MOVE 0 TO CBCONDEV-NUM-RCAP */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP);

            /*" -1954- MOVE 0 TO CBCONDEV-NUM-RCAP-COMPLEMEN */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN);

            /*" -1955- MOVE FOLLOUP-NUM-APOLICE TO CBCONDEV-NUM-APOLICE */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE);

            /*" -1956- MOVE FOLLOUP-NUM-ENDOSSO TO CBCONDEV-NUM-ENDOSSO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO);

            /*" -1957- MOVE FOLLOUP-NUM-PARCELA TO CBCONDEV-NUM-PARCELA */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA);

            /*" -1958- MOVE ENDOSSOS-COD-PRODUTO TO CBCONDEV-COD-PRODUTO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO);

            /*" -1959- MOVE FOLLOUP-VAL-OPERACAO TO CBCONDEV-VAL-TITULO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO);

            /*" -1961- MOVE FOLLOUP-VAL-OPERACAO TO CBCONDEV-VAL-OPERACAO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO);

            /*" -1962- MOVE ZEROS TO CBCONDEV-COD-SUBGRUPO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO);

            /*" -1963- MOVE ZEROS TO CBCONDEV-NUM-CERTIFICADO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO);

            /*" -1964- MOVE FOLLOUP-DATA-MOVIMENTO TO CBCONDEV-DATA-OCORRENCIA */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA);

            /*" -1965- MOVE FOLLOUP-HORA-OPERACAO TO CBCONDEV-HORA-OPERACAO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO);

            /*" -1966- MOVE ZEROS TO CBCONDEV-NUM-MATRICULA */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA);

            /*" -1967- MOVE ENDOSSOS-RAMO-EMISSOR TO CBCONDEV-RAMO-EMISSOR */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR);

            /*" -1968- MOVE MALHACEF-COD-FONTE TO CBCONDEV-COD-FILIAL */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL);

            /*" -1969- MOVE AGENCCEF-COD-ESCNEG TO CBCONDEV-COD-ESCNEG */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG);

            /*" -1970- MOVE ENDOSSOS-AGE-COBRANCA TO CBCONDEV-AGE-COBRANCA */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_AGE_COBRANCA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA);

            /*" -1972- MOVE '9' TO CBCONDEV-TIPO-FAVORECIDO */
            _.Move("9", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO);

            /*" -1973- IF CLIENTES-TIPO-PESSOA EQUAL 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -1974- MOVE LK-PF-NUM-PESSOA TO CBCONDEV-COD-FAVORECIDO */
                _.Move(LK_PF_PARAMETRO.LK_PF_NUM_PESSOA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO);

                /*" -1975- ELSE */
            }
            else
            {


                /*" -1976- MOVE LK-PJ-NUM-PESSOA TO CBCONDEV-COD-FAVORECIDO */
                _.Move(LK_PJ_PARAMETRO.LK_PJ_NUM_PESSOA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO);

                /*" -1978- END-IF */
            }


            /*" -1979- MOVE ZEROS TO CBCONDEV-COD-ENDERECO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO);

            /*" -1980- MOVE LK-EN-SEQ-ENDERECO TO CBCONDEV-OCORR-ENDERECO */
            _.Move(LK_EN_PARAMETRO.LK_EN_SEQ_ENDERECO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO);

            /*" -1981- MOVE GE381-COD-AGENCIA TO CBCONDEV-COD-AGENCIA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA);

            /*" -1982- MOVE GE381-COD-OPERACAO TO CBCONDEV-OPERACAO-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA);

            /*" -1983- MOVE GE381-NUM-CONTA TO CBCONDEV-NUM-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA);

            /*" -1984- MOVE GE381-NUM-CONTA-DV1 TO CBCONDEV-DIG-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA);

            /*" -1985- MOVE SISTEMAS-DATA-MOV-ABERTO TO CBCONDEV-DATA-QUITACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO);

            /*" -1986- MOVE ZEROS TO CBCONDEV-VAL-DESCONTO */
            _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO);

            /*" -1987- MOVE 1205 TO CBCONDEV-COD-DESPESA */
            _.Move(1205, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA);

            /*" -1989- MOVE 150 TO CBCONDEV-COD-DEVOLUCAO */
            _.Move(150, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO);

            /*" -1990- IF CBCONDEV-TIPO-MOVIMENTO EQUAL 'Z' */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO == "Z")
            {

                /*" -1991- MOVE 0003 TO CBCONDEV-COD-SISTEMA */
                _.Move(0003, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);

                /*" -1992- ELSE */
            }
            else
            {


                /*" -1993- MOVE 0001 TO CBCONDEV-COD-SISTEMA */
                _.Move(0001, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA);

                /*" -1995- END-IF */
            }


            /*" -1996- MOVE 'CB0110B' TO CBCONDEV-COD-USU-SOLICITA */
            _.Move("CB0110B", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA);

            /*" -1997- MOVE SPACES TO CBCONDEV-DATA-CANCELAMENTO */
            _.Move("", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO);

            /*" -1998- MOVE SPACES TO CBCONDEV-COD-USU-CANCELA */
            _.Move("", CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA);

            /*" -1999- MOVE -1 TO VIND-DTCANCEL */
            _.Move(-1, VIND_DTCANCEL);

            /*" -2004- MOVE -1 TO VIND-CODUSU. */
            _.Move(-1, VIND_CODUSU);

            /*" -2005- IF WS-GERA-CHEQUE EQUAL 'N' */

            if (WS_GERA_CHEQUE == "N")
            {

                /*" -2006- IF GE381-COD-BCO EQUAL 104 */

                if (GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO == 104)
                {

                    /*" -2007- ADD 1 TO WS-QT-900662 */
                    WS_QT_900662.Value = WS_QT_900662 + 1;

                    /*" -2008- ELSE */
                }
                else
                {


                    /*" -2008- ADD 1 TO WS-QT-921286. */
                    WS_QT_921286.Value = WS_QT_921286 + 1;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22353_99_SAIDA*/

        [StopWatch]
        /*" P22354-00-INCLUI-CBCONDEV-SECTION */
        private void P22354_00_INCLUI_CBCONDEV_SECTION()
        {
            /*" -2021- MOVE 'P22354' TO WS-NR-PARAG. */
            _.Move("P22354", WS_DISPLAY.WS_NR_PARAG);

            /*" -2112- PERFORM P22354_00_INCLUI_CBCONDEV_DB_INSERT_1 */

            P22354_00_INCLUI_CBCONDEV_DB_INSERT_1();

            /*" -2115- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2116- DISPLAY 'COD-EMPRESA        ' CBCONDEV-COD-EMPRESA */
                _.Display($"COD-EMPRESA        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA}");

                /*" -2117- DISPLAY 'TIPO-MOVIMENTO     ' CBCONDEV-TIPO-MOVIMENTO */
                _.Display($"TIPO-MOVIMENTO     {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO}");

                /*" -2118- DISPLAY 'NUM-CHEQUE-INTERNO ' CBCONDEV-NUM-CHEQUE-INTERNO */
                _.Display($"NUM-CHEQUE-INTERNO {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO}");

                /*" -2119- DISPLAY 'DIG-CHEQUE-INTERNO ' CBCONDEV-DIG-CHEQUE-INTERNO */
                _.Display($"DIG-CHEQUE-INTERNO {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO}");

                /*" -2120- DISPLAY 'DATA-MOVIMENTO     ' CBCONDEV-DATA-MOVIMENTO */
                _.Display($"DATA-MOVIMENTO     {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO}");

                /*" -2121- DISPLAY 'NUM-SEQUENCIA      ' CBCONDEV-NUM-SEQUENCIA */
                _.Display($"NUM-SEQUENCIA      {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA}");

                /*" -2122- DISPLAY 'NUM-TITULO         ' CBCONDEV-NUM-TITULO */
                _.Display($"NUM-TITULO         {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO}");

                /*" -2123- DISPLAY 'COD-FONTE          ' CBCONDEV-COD-FONTE */
                _.Display($"COD-FONTE          {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE}");

                /*" -2124- DISPLAY 'NUM-RCAP           ' CBCONDEV-NUM-RCAP */
                _.Display($"NUM-RCAP           {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP}");

                /*" -2125- DISPLAY 'NUM-RCAP-COMPLEMEN ' CBCONDEV-NUM-RCAP-COMPLEMEN */
                _.Display($"NUM-RCAP-COMPLEMEN {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN}");

                /*" -2126- DISPLAY 'NUM-APOLICE        ' CBCONDEV-NUM-APOLICE */
                _.Display($"NUM-APOLICE        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE}");

                /*" -2127- DISPLAY 'NUM-ENDOSSO        ' CBCONDEV-NUM-ENDOSSO */
                _.Display($"NUM-ENDOSSO        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO}");

                /*" -2128- DISPLAY 'NUM-PARCELA        ' CBCONDEV-NUM-PARCELA */
                _.Display($"NUM-PARCELA        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA}");

                /*" -2129- DISPLAY 'COD-SUBGRUPO       ' CBCONDEV-COD-SUBGRUPO */
                _.Display($"COD-SUBGRUPO       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO}");

                /*" -2130- DISPLAY 'NUM-CERTIFICADO    ' CBCONDEV-NUM-CERTIFICADO */
                _.Display($"NUM-CERTIFICADO    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO}");

                /*" -2131- DISPLAY 'DATA-OCORRENCIA    ' CBCONDEV-DATA-OCORRENCIA */
                _.Display($"DATA-OCORRENCIA    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA}");

                /*" -2132- DISPLAY 'HORA-OPERACAO      ' CBCONDEV-HORA-OPERACAO */
                _.Display($"HORA-OPERACAO      {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO}");

                /*" -2133- DISPLAY 'NUM-MATRICULA      ' CBCONDEV-NUM-MATRICULA */
                _.Display($"NUM-MATRICULA      {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA}");

                /*" -2134- DISPLAY 'RAMO-EMISSOR       ' CBCONDEV-RAMO-EMISSOR */
                _.Display($"RAMO-EMISSOR       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR}");

                /*" -2135- DISPLAY 'COD-PRODUTO        ' CBCONDEV-COD-PRODUTO */
                _.Display($"COD-PRODUTO        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO}");

                /*" -2136- DISPLAY 'COD-FILIAL         ' CBCONDEV-COD-FILIAL */
                _.Display($"COD-FILIAL         {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL}");

                /*" -2137- DISPLAY 'COD-ESCNEG         ' CBCONDEV-COD-ESCNEG */
                _.Display($"COD-ESCNEG         {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG}");

                /*" -2138- DISPLAY 'AGE-COBRANCA       ' CBCONDEV-AGE-COBRANCA */
                _.Display($"AGE-COBRANCA       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA}");

                /*" -2139- DISPLAY 'TIPO-FAVORECIDO    ' CBCONDEV-TIPO-FAVORECIDO */
                _.Display($"TIPO-FAVORECIDO    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO}");

                /*" -2140- DISPLAY 'COD-FAVORECIDO     ' CBCONDEV-COD-FAVORECIDO */
                _.Display($"COD-FAVORECIDO     {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO}");

                /*" -2141- DISPLAY 'COD-ENDERECO       ' CBCONDEV-COD-ENDERECO */
                _.Display($"COD-ENDERECO       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO}");

                /*" -2142- DISPLAY 'OCORR-ENDERECO     ' CBCONDEV-OCORR-ENDERECO */
                _.Display($"OCORR-ENDERECO     {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO}");

                /*" -2143- DISPLAY 'COD-AGENCIA        ' CBCONDEV-COD-AGENCIA */
                _.Display($"COD-AGENCIA        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA}");

                /*" -2144- DISPLAY 'OPERACAO-CONTA     ' CBCONDEV-OPERACAO-CONTA */
                _.Display($"OPERACAO-CONTA     {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA}");

                /*" -2145- DISPLAY 'NUM-CONTA          ' CBCONDEV-NUM-CONTA */
                _.Display($"NUM-CONTA          {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA}");

                /*" -2146- DISPLAY 'DIG-CONTA          ' CBCONDEV-DIG-CONTA */
                _.Display($"DIG-CONTA          {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA}");

                /*" -2147- DISPLAY 'SIT-REGISTRO       ' CBCONDEV-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO}");

                /*" -2148- DISPLAY 'DATA-QUITACAO      ' CBCONDEV-DATA-QUITACAO */
                _.Display($"DATA-QUITACAO      {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO}");

                /*" -2149- DISPLAY 'VAL-TITULO         ' CBCONDEV-VAL-TITULO */
                _.Display($"VAL-TITULO         {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO}");

                /*" -2150- DISPLAY 'VAL-DESCONTO       ' CBCONDEV-VAL-DESCONTO */
                _.Display($"VAL-DESCONTO       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO}");

                /*" -2151- DISPLAY 'VAL-OPERACAO       ' CBCONDEV-VAL-OPERACAO */
                _.Display($"VAL-OPERACAO       {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO}");

                /*" -2152- DISPLAY 'COD-DESPESA        ' CBCONDEV-COD-DESPESA */
                _.Display($"COD-DESPESA        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA}");

                /*" -2153- DISPLAY 'COD-DEVOLUCAO      ' CBCONDEV-COD-DEVOLUCAO */
                _.Display($"COD-DEVOLUCAO      {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO}");

                /*" -2154- DISPLAY 'COD-SISTEMA        ' CBCONDEV-COD-SISTEMA */
                _.Display($"COD-SISTEMA        {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA}");

                /*" -2155- DISPLAY 'COD-USU-SOLICITA   ' CBCONDEV-COD-USU-SOLICITA */
                _.Display($"COD-USU-SOLICITA   {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA}");

                /*" -2156- DISPLAY 'DATA-CANCELAMENTO  ' CBCONDEV-DATA-CANCELAMENTO */
                _.Display($"DATA-CANCELAMENTO  {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO}");

                /*" -2158- DISPLAY 'COD-USU-CANCELA    ' CBCONDEV-COD-USU-CANCELA */
                _.Display($"COD-USU-CANCELA    {CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA}");

                /*" -2161- MOVE 'ERRO NA INCLUSAO NA TABELA .CB_CONTR_DEVPREMIO' TO WS-MSG */
                _.Move("ERRO NA INCLUSAO NA TABELA .CB_CONTR_DEVPREMIO", WS_MSG);

                /*" -2162- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -2164- END-IF */
            }


            /*" -2164- ADD 1 TO WS-QT-DEVPR. */
            WS_QT_DEVPR.Value = WS_QT_DEVPR + 1;

        }

        [StopWatch]
        /*" P22354-00-INCLUI-CBCONDEV-DB-INSERT-1 */
        public void P22354_00_INCLUI_CBCONDEV_DB_INSERT_1()
        {
            /*" -2112- EXEC SQL INSERT INTO SEGUROS.CB_CONTR_DEVPREMIO ( COD_EMPRESA ,TIPO_MOVIMENTO ,NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,DATA_MOVIMENTO ,NUM_SEQUENCIA ,NUM_TITULO ,COD_FONTE ,NUM_RCAP ,NUM_RCAP_COMPLEMEN ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_PARCELA ,COD_SUBGRUPO ,NUM_CERTIFICADO ,DATA_OCORRENCIA ,HORA_OPERACAO ,NUM_MATRICULA ,RAMO_EMISSOR ,COD_PRODUTO ,COD_FILIAL ,COD_ESCNEG ,AGE_COBRANCA ,TIPO_FAVORECIDO ,COD_FAVORECIDO ,COD_ENDERECO ,OCORR_ENDERECO ,COD_AGENCIA ,OPERACAO_CONTA ,NUM_CONTA ,DIG_CONTA ,SIT_REGISTRO ,DATA_QUITACAO ,VAL_TITULO ,VAL_DESCONTO ,VAL_OPERACAO ,COD_DESPESA ,COD_DEVOLUCAO ,COD_SISTEMA ,COD_USU_SOLICITA ,TIMESTAMP ,DATA_CANCELAMENTO ,COD_USU_CANCELA ) VALUES (:CBCONDEV-COD-EMPRESA ,:CBCONDEV-TIPO-MOVIMENTO ,:CBCONDEV-NUM-CHEQUE-INTERNO ,:CBCONDEV-DIG-CHEQUE-INTERNO ,:CBCONDEV-DATA-MOVIMENTO ,:CBCONDEV-NUM-SEQUENCIA ,:CBCONDEV-NUM-TITULO ,:CBCONDEV-COD-FONTE ,:CBCONDEV-NUM-RCAP ,:CBCONDEV-NUM-RCAP-COMPLEMEN ,:CBCONDEV-NUM-APOLICE ,:CBCONDEV-NUM-ENDOSSO ,:CBCONDEV-NUM-PARCELA ,:CBCONDEV-COD-SUBGRUPO ,:CBCONDEV-NUM-CERTIFICADO ,:CBCONDEV-DATA-OCORRENCIA ,:CBCONDEV-HORA-OPERACAO ,:CBCONDEV-NUM-MATRICULA ,:CBCONDEV-RAMO-EMISSOR ,:CBCONDEV-COD-PRODUTO ,:CBCONDEV-COD-FILIAL ,:CBCONDEV-COD-ESCNEG ,:CBCONDEV-AGE-COBRANCA ,:CBCONDEV-TIPO-FAVORECIDO ,:CBCONDEV-COD-FAVORECIDO ,:CBCONDEV-COD-ENDERECO ,:CBCONDEV-OCORR-ENDERECO ,:CBCONDEV-COD-AGENCIA ,:CBCONDEV-OPERACAO-CONTA ,:CBCONDEV-NUM-CONTA ,:CBCONDEV-DIG-CONTA ,:CBCONDEV-SIT-REGISTRO ,:CBCONDEV-DATA-QUITACAO ,:CBCONDEV-VAL-TITULO ,:CBCONDEV-VAL-DESCONTO ,:CBCONDEV-VAL-OPERACAO ,:CBCONDEV-COD-DESPESA ,:CBCONDEV-COD-DEVOLUCAO ,:CBCONDEV-COD-SISTEMA ,:CBCONDEV-COD-USU-SOLICITA , CURRENT TIMESTAMP ,:CBCONDEV-DATA-CANCELAMENTO:VIND-DTCANCEL ,:CBCONDEV-COD-USU-CANCELA:VIND-CODUSU ) END-EXEC. */

            var p22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1 = new P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1()
            {
                CBCONDEV_COD_EMPRESA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA.ToString(),
                CBCONDEV_TIPO_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_MOVIMENTO.ToString(),
                CBCONDEV_NUM_CHEQUE_INTERNO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO.ToString(),
                CBCONDEV_DIG_CHEQUE_INTERNO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO.ToString(),
                CBCONDEV_DATA_MOVIMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.ToString(),
                CBCONDEV_NUM_SEQUENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA.ToString(),
                CBCONDEV_NUM_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO.ToString(),
                CBCONDEV_COD_FONTE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FONTE.ToString(),
                CBCONDEV_NUM_RCAP = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP.ToString(),
                CBCONDEV_NUM_RCAP_COMPLEMEN = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_RCAP_COMPLEMEN.ToString(),
                CBCONDEV_NUM_APOLICE = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE.ToString(),
                CBCONDEV_NUM_ENDOSSO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_ENDOSSO.ToString(),
                CBCONDEV_NUM_PARCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_PARCELA.ToString(),
                CBCONDEV_COD_SUBGRUPO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SUBGRUPO.ToString(),
                CBCONDEV_NUM_CERTIFICADO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CERTIFICADO.ToString(),
                CBCONDEV_DATA_OCORRENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA.ToString(),
                CBCONDEV_HORA_OPERACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO.ToString(),
                CBCONDEV_NUM_MATRICULA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_MATRICULA.ToString(),
                CBCONDEV_RAMO_EMISSOR = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_RAMO_EMISSOR.ToString(),
                CBCONDEV_COD_PRODUTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO.ToString(),
                CBCONDEV_COD_FILIAL = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL.ToString(),
                CBCONDEV_COD_ESCNEG = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ESCNEG.ToString(),
                CBCONDEV_AGE_COBRANCA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_AGE_COBRANCA.ToString(),
                CBCONDEV_TIPO_FAVORECIDO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_TIPO_FAVORECIDO.ToString(),
                CBCONDEV_COD_FAVORECIDO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO.ToString(),
                CBCONDEV_COD_ENDERECO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_ENDERECO.ToString(),
                CBCONDEV_OCORR_ENDERECO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OCORR_ENDERECO.ToString(),
                CBCONDEV_COD_AGENCIA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_AGENCIA.ToString(),
                CBCONDEV_OPERACAO_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_OPERACAO_CONTA.ToString(),
                CBCONDEV_NUM_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CONTA.ToString(),
                CBCONDEV_DIG_CONTA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CONTA.ToString(),
                CBCONDEV_SIT_REGISTRO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_SIT_REGISTRO.ToString(),
                CBCONDEV_DATA_QUITACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO.ToString(),
                CBCONDEV_VAL_TITULO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_TITULO.ToString(),
                CBCONDEV_VAL_DESCONTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_DESCONTO.ToString(),
                CBCONDEV_VAL_OPERACAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO.ToString(),
                CBCONDEV_COD_DESPESA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA.ToString(),
                CBCONDEV_COD_DEVOLUCAO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DEVOLUCAO.ToString(),
                CBCONDEV_COD_SISTEMA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_SISTEMA.ToString(),
                CBCONDEV_COD_USU_SOLICITA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_SOLICITA.ToString(),
                CBCONDEV_DATA_CANCELAMENTO = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.ToString(),
                VIND_DTCANCEL = VIND_DTCANCEL.ToString(),
                CBCONDEV_COD_USU_CANCELA = CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_USU_CANCELA.ToString(),
                VIND_CODUSU = VIND_CODUSU.ToString(),
            };

            P22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1.Execute(p22354_00_INCLUI_CBCONDEV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22354_99_SAIDA*/

        [StopWatch]
        /*" P22360-00-GRAVA-CHEQUE-SECTION */
        private void P22360_00_GRAVA_CHEQUE_SECTION()
        {
            /*" -2226- MOVE 'P22360' TO WS-NR-PARAG. */
            _.Move("P22360", WS_DISPLAY.WS_NR_PARAG);

            /*" -2228- PERFORM P22361-00-MONTA-CHEQUE */

            P22361_00_MONTA_CHEQUE_SECTION();

            /*" -2230- PERFORM P22362-00-INCLUI-CHEQUEMI */

            P22362_00_INCLUI_CHEQUEMI_SECTION();

            /*" -2232- PERFORM P22363-00-INCLUI-HISTOCHE. */

            P22363_00_INCLUI_HISTOCHE_SECTION();

            /*" -2232- ADD 1 TO WS-QT-CHEMI. */
            WS_QT_CHEMI.Value = WS_QT_CHEMI + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22360_99_SAIDA*/

        [StopWatch]
        /*" P22361-00-MONTA-CHEQUE-SECTION */
        private void P22361_00_MONTA_CHEQUE_SECTION()
        {
            /*" -2249- MOVE 'P22361' TO WS-NR-PARAG. */
            _.Move("P22361", WS_DISPLAY.WS_NR_PARAG);

            /*" -2250- IF CBCONDEV-NUM-TITULO NOT EQUAL ZEROS */

            if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO != 00)
            {

                /*" -2251- MOVE CBCONDEV-NUM-TITULO TO WS-02-NRTIT */
                _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_TITULO, WS_VARIAVEIS.WS_02.WS_02_NRTIT);

                /*" -2252- MOVE WS-02 TO CHEQUEMI-NUM-DOCUMENTO */
                _.Move(WS_VARIAVEIS.WS_02, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO);

                /*" -2253- ELSE */
            }
            else
            {


                /*" -2254- IF CBCONDEV-NUM-APOLICE NOT EQUAL ZEROS */

                if (CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE != 00)
                {

                    /*" -2255- MOVE CBCONDEV-NUM-APOLICE TO WS-03-NUMAPOL */
                    _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_APOLICE, WS_VARIAVEIS.WS_03.WS_03_NUMAPOL);

                    /*" -2256- MOVE WS-03 TO CHEQUEMI-NUM-DOCUMENTO */
                    _.Move(WS_VARIAVEIS.WS_03, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO);

                    /*" -2257- ELSE */
                }
                else
                {


                    /*" -2259- MOVE 'DEVOLUCAO' TO CHEQUEMI-NUM-DOCUMENTO. */
                    _.Move("DEVOLUCAO", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO);
                }

            }


            /*" -2260- MOVE '8' TO CHEQUEMI-TIPO-MOVIMENTO */
            _.Move("8", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO);

            /*" -2261- MOVE CBCONDEV-COD-FILIAL TO CHEQUEMI-COD-FONTE */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FILIAL, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FONTE);

            /*" -2262- MOVE CLIENTES-NOME-RAZAO TO CHEQUEMI-NOME-FAVORECIDO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NOME_FAVORECIDO);

            /*" -2263- MOVE CBCONDEV-VAL-OPERACAO TO CHEQUEMI-VAL-CHEQUE */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_VAL_OPERACAO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE);

            /*" -2264- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO);

            /*" -2265- MOVE SPACES TO CHEQUEMI-DATA-EMISSAO */
            _.Move("", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO);

            /*" -2266- MOVE WS-NUMCHQ TO CHEQUEMI-NUM-CHEQUE-INTERNO */
            _.Move(WS_VARIAVEIS.WS_CHQINT.WS_NUMCHQ, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO);

            /*" -2267- MOVE WS-DIGCHQ TO CHEQUEMI-DIG-CHEQUE-INTERNO */
            _.Move(WS_VARIAVEIS.WS_CHQINT.WS_DIGCHQ, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO);

            /*" -2268- MOVE '0' TO CHEQUEMI-SIT-REGISTRO */
            _.Move("0", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO);

            /*" -2269- MOVE '1' TO CHEQUEMI-TIPO-PAGAMENTO */
            _.Move("1", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO);

            /*" -2270- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-COMPETENCIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA);

            /*" -2271- MOVE 'BRASILIA' TO CHEQUEMI-PRACA-PAGAMENTO */
            _.Move("BRASILIA", CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_PRACA_PAGAMENTO);

            /*" -2272- MOVE WS-NUMREC TO CHEQUEMI-NUM-RECIBO */
            _.Move(WS_VARIAVEIS.WS_NUMREC, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_RECIBO);

            /*" -2273- MOVE CBCONDEV-NUM-SEQUENCIA TO CHEQUEMI-OCORR-HISTORICO */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_SEQUENCIA, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_OCORR_HISTORICO);

            /*" -2274- MOVE 101 TO CHEQUEMI-COD-OPERACAO */
            _.Move(101, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_OPERACAO);

            /*" -2275- MOVE CBCONDEV-COD-DESPESA TO CHEQUEMI-COD-DESPESA */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_DESPESA, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_DESPESA);

            /*" -2278- MOVE ZEROS TO CHEQUEMI-VAL-IRF CHEQUEMI-VAL-ISS CHEQUEMI-VAL-IAPAS. */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IRF, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_ISS, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IAPAS);

            /*" -2279- MOVE CBCONDEV-COD-PRODUTO TO CHEQUEMI-COD-LANCAMENTO */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_PRODUTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_LANCAMENTO);

            /*" -2280- MOVE SISTEMAS-DATA-MOV-ABERTO TO CHEQUEMI-DATA-LANCAMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO);

            /*" -2281- MOVE CBCONDEV-COD-EMPRESA TO CHEQUEMI-COD-EMPRESA */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_EMPRESA, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA);

            /*" -2282- MOVE CBCONDEV-COD-FAVORECIDO TO CHEQUEMI-COD-FAVORECIDO */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_COD_FAVORECIDO, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO);

            /*" -2283- MOVE ZEROS TO CHEQUEMI-VAL-INSS */
            _.Move(0, CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_INSS);

            /*" -2284- MOVE -1 TO VIND-DTEMIS */
            _.Move(-1, VIND_DTEMIS);

            /*" -2288- MOVE ZEROS TO VIND-CODEMP VIND-CODFAV VIND-VLINSS. */
            _.Move(0, VIND_CODEMP, VIND_CODFAV, VIND_VLINSS);

            /*" -2290- MOVE CHEQUEMI-NUM-CHEQUE-INTERNO TO HISTOCHE-NUM-CHEQUE-INTERNO */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_NUM_CHEQUE_INTERNO);

            /*" -2292- MOVE CHEQUEMI-DIG-CHEQUE-INTERNO TO HISTOCHE-DIG-CHEQUE-INTERNO */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DIG_CHEQUE_INTERNO);

            /*" -2293- MOVE CHEQUEMI-DATA-MOVIMENTO TO HISTOCHE-DATA-MOVIMENTO */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO);

            /*" -2294- MOVE CHEQUEMI-COD-OPERACAO TO HISTOCHE-COD-OPERACAO */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_OPERACAO, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_OPERACAO);

            /*" -2295- MOVE CHEQUEMI-COD-EMPRESA TO HISTOCHE-COD-EMPRESA */
            _.Move(CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA, HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_EMPRESA);

            /*" -2296- MOVE SPACES TO HISTOCHE-DATA-COMPENSACAO */
            _.Move("", HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_COMPENSACAO);

            /*" -2297- MOVE ZEROS TO VIND-CODEMP */
            _.Move(0, VIND_CODEMP);

            /*" -2297- MOVE -1 TO VIND-DTCOMPE. */
            _.Move(-1, VIND_DTCOMPE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22361_99_SAIDA*/

        [StopWatch]
        /*" P22362-00-INCLUI-CHEQUEMI-SECTION */
        private void P22362_00_INCLUI_CHEQUEMI_SECTION()
        {
            /*" -2310- MOVE 'P22362' TO WS-NR-PARAG. */
            _.Move("P22362", WS_DISPLAY.WS_NR_PARAG);

            /*" -2367- PERFORM P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1 */

            P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1();

            /*" -2370- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2371- DISPLAY 'TIPO-MOVIMENTO     ' CHEQUEMI-TIPO-MOVIMENTO */
                _.Display($"TIPO-MOVIMENTO     {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO}");

                /*" -2372- DISPLAY 'COD-FONTE          ' CHEQUEMI-COD-FONTE */
                _.Display($"COD-FONTE          {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FONTE}");

                /*" -2373- DISPLAY 'NUM-DOCUMENTO      ' CHEQUEMI-NUM-DOCUMENTO */
                _.Display($"NUM-DOCUMENTO      {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO}");

                /*" -2374- DISPLAY 'NOME-FAVORECIDO    ' CHEQUEMI-NOME-FAVORECIDO */
                _.Display($"NOME-FAVORECIDO    {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NOME_FAVORECIDO}");

                /*" -2375- DISPLAY 'VAL-CHEQUE         ' CHEQUEMI-VAL-CHEQUE */
                _.Display($"VAL-CHEQUE         {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE}");

                /*" -2376- DISPLAY 'DATA-MOVIMENTO     ' CHEQUEMI-DATA-MOVIMENTO */
                _.Display($"DATA-MOVIMENTO     {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO}");

                /*" -2377- DISPLAY 'DATA-EMISSAO       ' CHEQUEMI-DATA-EMISSAO */
                _.Display($"DATA-EMISSAO       {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO}");

                /*" -2378- DISPLAY 'NUM-CHEQUE-INTERNO ' CHEQUEMI-NUM-CHEQUE-INTERNO */
                _.Display($"NUM-CHEQUE-INTERNO {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO}");

                /*" -2379- DISPLAY 'DIG-CHEQUE-INTERNO ' CHEQUEMI-DIG-CHEQUE-INTERNO */
                _.Display($"DIG-CHEQUE-INTERNO {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO}");

                /*" -2380- DISPLAY 'SIT-REGISTRO       ' CHEQUEMI-SIT-REGISTRO */
                _.Display($"SIT-REGISTRO       {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO}");

                /*" -2381- DISPLAY 'TIPO-PAGAMENTO     ' CHEQUEMI-TIPO-PAGAMENTO */
                _.Display($"TIPO-PAGAMENTO     {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO}");

                /*" -2382- DISPLAY 'DATA-COMPETENCIA   ' CHEQUEMI-DATA-COMPETENCIA */
                _.Display($"DATA-COMPETENCIA   {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA}");

                /*" -2383- DISPLAY 'PRACA-PAGAMENTO    ' CHEQUEMI-PRACA-PAGAMENTO */
                _.Display($"PRACA-PAGAMENTO    {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_PRACA_PAGAMENTO}");

                /*" -2384- DISPLAY 'NUM-RECIBO         ' CHEQUEMI-NUM-RECIBO */
                _.Display($"NUM-RECIBO         {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_RECIBO}");

                /*" -2385- DISPLAY 'OCORR-HISTORICO    ' CHEQUEMI-OCORR-HISTORICO */
                _.Display($"OCORR-HISTORICO    {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_OCORR_HISTORICO}");

                /*" -2386- DISPLAY 'COD-OPERACAO       ' CHEQUEMI-COD-OPERACAO */
                _.Display($"COD-OPERACAO       {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_OPERACAO}");

                /*" -2387- DISPLAY 'COD-DESPESA        ' CHEQUEMI-COD-DESPESA */
                _.Display($"COD-DESPESA        {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_DESPESA}");

                /*" -2388- DISPLAY 'VAL-IRF            ' CHEQUEMI-VAL-IRF */
                _.Display($"VAL-IRF            {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IRF}");

                /*" -2389- DISPLAY 'VAL-ISS            ' CHEQUEMI-VAL-ISS */
                _.Display($"VAL-ISS            {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_ISS}");

                /*" -2390- DISPLAY 'VAL-IAPAS          ' CHEQUEMI-VAL-IAPAS */
                _.Display($"VAL-IAPAS          {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IAPAS}");

                /*" -2391- DISPLAY 'COD-LANCAMENTO     ' CHEQUEMI-COD-LANCAMENTO */
                _.Display($"COD-LANCAMENTO     {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_LANCAMENTO}");

                /*" -2392- DISPLAY 'DATA-LANCAMENTO    ' CHEQUEMI-DATA-LANCAMENTO */
                _.Display($"DATA-LANCAMENTO    {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO}");

                /*" -2393- DISPLAY 'COD-EMPRESA        ' CHEQUEMI-COD-EMPRESA */
                _.Display($"COD-EMPRESA        {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA}");

                /*" -2394- DISPLAY 'COD-FAVORECIDO     ' CHEQUEMI-COD-FAVORECIDO */
                _.Display($"COD-FAVORECIDO     {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO}");

                /*" -2396- DISPLAY 'VAL-INSS           ' CHEQUEMI-VAL-INSS */
                _.Display($"VAL-INSS           {CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_INSS}");

                /*" -2399- MOVE 'ERRO NA INCLUSAO NA TABELA .CHEQUES_EMITIDOS' TO WS-MSG */
                _.Move("ERRO NA INCLUSAO NA TABELA .CHEQUES_EMITIDOS", WS_MSG);

                /*" -2400- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -2400- END-IF. */
            }


        }

        [StopWatch]
        /*" P22362-00-INCLUI-CHEQUEMI-DB-INSERT-1 */
        public void P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1()
        {
            /*" -2367- EXEC SQL INSERT INTO SEGUROS.CHEQUES_EMITIDOS ( TIPO_MOVIMENTO ,COD_FONTE ,NUM_DOCUMENTO ,NOME_FAVORECIDO ,VAL_CHEQUE ,DATA_MOVIMENTO ,DATA_EMISSAO ,NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,SIT_REGISTRO ,TIPO_PAGAMENTO ,DATA_COMPETENCIA ,PRACA_PAGAMENTO ,NUM_RECIBO ,OCORR_HISTORICO ,COD_OPERACAO ,COD_DESPESA ,VAL_IRF ,VAL_ISS ,VAL_IAPAS ,COD_LANCAMENTO ,DATA_LANCAMENTO ,COD_EMPRESA ,TIMESTAMP ,COD_FAVORECIDO ,VAL_INSS ) VALUES (:CHEQUEMI-TIPO-MOVIMENTO ,:CHEQUEMI-COD-FONTE ,:CHEQUEMI-NUM-DOCUMENTO ,:CHEQUEMI-NOME-FAVORECIDO ,:CHEQUEMI-VAL-CHEQUE ,:CHEQUEMI-DATA-MOVIMENTO ,:CHEQUEMI-DATA-EMISSAO:VIND-DTEMIS ,:CHEQUEMI-NUM-CHEQUE-INTERNO ,:CHEQUEMI-DIG-CHEQUE-INTERNO ,:CHEQUEMI-SIT-REGISTRO ,:CHEQUEMI-TIPO-PAGAMENTO ,:CHEQUEMI-DATA-COMPETENCIA ,:CHEQUEMI-PRACA-PAGAMENTO ,:CHEQUEMI-NUM-RECIBO ,:CHEQUEMI-OCORR-HISTORICO ,:CHEQUEMI-COD-OPERACAO ,:CHEQUEMI-COD-DESPESA ,:CHEQUEMI-VAL-IRF ,:CHEQUEMI-VAL-ISS ,:CHEQUEMI-VAL-IAPAS ,:CHEQUEMI-COD-LANCAMENTO ,:CHEQUEMI-DATA-LANCAMENTO ,:CHEQUEMI-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP ,:CHEQUEMI-COD-FAVORECIDO:VIND-CODFAV ,:CHEQUEMI-VAL-INSS:VIND-VLINSS ) END-EXEC. */

            var p22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1 = new P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1()
            {
                CHEQUEMI_TIPO_MOVIMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_MOVIMENTO.ToString(),
                CHEQUEMI_COD_FONTE = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FONTE.ToString(),
                CHEQUEMI_NUM_DOCUMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_DOCUMENTO.ToString(),
                CHEQUEMI_NOME_FAVORECIDO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NOME_FAVORECIDO.ToString(),
                CHEQUEMI_VAL_CHEQUE = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_CHEQUE.ToString(),
                CHEQUEMI_DATA_MOVIMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO.ToString(),
                CHEQUEMI_DATA_EMISSAO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO.ToString(),
                VIND_DTEMIS = VIND_DTEMIS.ToString(),
                CHEQUEMI_NUM_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_CHEQUE_INTERNO.ToString(),
                CHEQUEMI_DIG_CHEQUE_INTERNO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DIG_CHEQUE_INTERNO.ToString(),
                CHEQUEMI_SIT_REGISTRO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_SIT_REGISTRO.ToString(),
                CHEQUEMI_TIPO_PAGAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_TIPO_PAGAMENTO.ToString(),
                CHEQUEMI_DATA_COMPETENCIA = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA.ToString(),
                CHEQUEMI_PRACA_PAGAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_PRACA_PAGAMENTO.ToString(),
                CHEQUEMI_NUM_RECIBO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_NUM_RECIBO.ToString(),
                CHEQUEMI_OCORR_HISTORICO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_OCORR_HISTORICO.ToString(),
                CHEQUEMI_COD_OPERACAO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_OPERACAO.ToString(),
                CHEQUEMI_COD_DESPESA = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_DESPESA.ToString(),
                CHEQUEMI_VAL_IRF = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IRF.ToString(),
                CHEQUEMI_VAL_ISS = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_ISS.ToString(),
                CHEQUEMI_VAL_IAPAS = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_IAPAS.ToString(),
                CHEQUEMI_COD_LANCAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_LANCAMENTO.ToString(),
                CHEQUEMI_DATA_LANCAMENTO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO.ToString(),
                CHEQUEMI_COD_EMPRESA = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                CHEQUEMI_COD_FAVORECIDO = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_COD_FAVORECIDO.ToString(),
                VIND_CODFAV = VIND_CODFAV.ToString(),
                CHEQUEMI_VAL_INSS = CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_VAL_INSS.ToString(),
                VIND_VLINSS = VIND_VLINSS.ToString(),
            };

            P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1.Execute(p22362_00_INCLUI_CHEQUEMI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22362_99_SAIDA*/

        [StopWatch]
        /*" P22363-00-INCLUI-HISTOCHE-SECTION */
        private void P22363_00_INCLUI_HISTOCHE_SECTION()
        {
            /*" -2413- MOVE 'P22363' TO WS-NR-PARAG. */
            _.Move("P22363", WS_DISPLAY.WS_NR_PARAG);

            /*" -2434- PERFORM P22363_00_INCLUI_HISTOCHE_DB_INSERT_1 */

            P22363_00_INCLUI_HISTOCHE_DB_INSERT_1();

            /*" -2437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2438- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -2439- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -2441- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -2442- DISPLAY 'NUM-CHEQUE-INTERNO ' HISTOCHE-NUM-CHEQUE-INTERNO */
                _.Display($"NUM-CHEQUE-INTERNO {HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_NUM_CHEQUE_INTERNO}");

                /*" -2443- DISPLAY 'DIG-CHEQUE-INTERNO ' HISTOCHE-DIG-CHEQUE-INTERNO */
                _.Display($"DIG-CHEQUE-INTERNO {HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DIG_CHEQUE_INTERNO}");

                /*" -2444- DISPLAY 'DATA-MOVIMENTO     ' HISTOCHE-DATA-MOVIMENTO */
                _.Display($"DATA-MOVIMENTO     {HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO}");

                /*" -2445- DISPLAY 'COD-OPERACAO       ' HISTOCHE-COD-OPERACAO */
                _.Display($"COD-OPERACAO       {HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_OPERACAO}");

                /*" -2446- DISPLAY 'COD-EMPRESA        ' HISTOCHE-COD-EMPRESA */
                _.Display($"COD-EMPRESA        {HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_EMPRESA}");

                /*" -2448- DISPLAY 'DATA-COMPENSACAO   ' HISTOCHE-DATA-COMPENSACAO */
                _.Display($"DATA-COMPENSACAO   {HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_COMPENSACAO}");

                /*" -2451- MOVE 'ERRO NA INCLUSAO NA TABELA .HISTORICO_CHEQUES' TO WS-MSG */
                _.Move("ERRO NA INCLUSAO NA TABELA .HISTORICO_CHEQUES", WS_MSG);

                /*" -2452- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -2452- END-IF. */
            }


        }

        [StopWatch]
        /*" P22363-00-INCLUI-HISTOCHE-DB-INSERT-1 */
        public void P22363_00_INCLUI_HISTOCHE_DB_INSERT_1()
        {
            /*" -2434- EXEC SQL INSERT INTO SEGUROS.HISTORICO_CHEQUES ( NUM_CHEQUE_INTERNO ,DIG_CHEQUE_INTERNO ,DATA_MOVIMENTO ,HORA_OPERACAO ,COD_OPERACAO ,COD_EMPRESA ,TIMESTAMP ,DATA_COMPENSACAO ) VALUES (:HISTOCHE-NUM-CHEQUE-INTERNO ,:HISTOCHE-DIG-CHEQUE-INTERNO ,:HISTOCHE-DATA-MOVIMENTO , CURRENT TIME ,:HISTOCHE-COD-OPERACAO ,:HISTOCHE-COD-EMPRESA:VIND-CODEMP , CURRENT TIMESTAMP ,:HISTOCHE-DATA-COMPENSACAO:VIND-DTCOMPE ) END-EXEC. */

            var p22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1 = new P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1()
            {
                HISTOCHE_NUM_CHEQUE_INTERNO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_NUM_CHEQUE_INTERNO.ToString(),
                HISTOCHE_DIG_CHEQUE_INTERNO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DIG_CHEQUE_INTERNO.ToString(),
                HISTOCHE_DATA_MOVIMENTO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO.ToString(),
                HISTOCHE_COD_OPERACAO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_OPERACAO.ToString(),
                HISTOCHE_COD_EMPRESA = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_COD_EMPRESA.ToString(),
                VIND_CODEMP = VIND_CODEMP.ToString(),
                HISTOCHE_DATA_COMPENSACAO = HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_COMPENSACAO.ToString(),
                VIND_DTCOMPE = VIND_DTCOMPE.ToString(),
            };

            P22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1.Execute(p22363_00_INCLUI_HISTOCHE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22363_99_SAIDA*/

        [StopWatch]
        /*" P22370-00-GRAVA-RELATORIO-SECTION */
        private void P22370_00_GRAVA_RELATORIO_SECTION()
        {
            /*" -2463- MOVE 'P22370' TO WS-NR-PARAG. */
            _.Move("P22370", WS_DISPLAY.WS_NR_PARAG);

            /*" -2465- INITIALIZE S01-REGISTRO */
            _.Initialize(
                S01_REGISTRO
            );

            /*" -2467- MOVE ALL ';' TO S01-REGISTRO */
            _.MoveAll(";", S01_REGISTRO);

            /*" -2468- MOVE ENDOSSOS-COD-FONTE TO S01-COD-FONTE */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE, S01_REGISTRO.S01_COD_FONTE);

            /*" -2469- MOVE FOLLOUP-NUM-APOLICE TO S01-NUM-APOLICE */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE, S01_REGISTRO.S01_NUM_APOLICE);

            /*" -2470- MOVE FOLLOUP-NUM-ENDOSSO TO S01-NUM-ENDOSSO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO, S01_REGISTRO.S01_NUM_ENDOSSO);

            /*" -2471- MOVE FOLLOUP-NUM-PARCELA TO S01-NUM-PARCELA */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA, S01_REGISTRO.S01_NUM_PARCELA);

            /*" -2472- MOVE APOLICES-COD-CLIENTE TO S01-COD-CLIENTE */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_COD_CLIENTE, S01_REGISTRO.S01_COD_CLIENTE);

            /*" -2473- MOVE CLIENTES-NOME-RAZAO TO S01-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, S01_REGISTRO.S01_NOME_RAZAO);

            /*" -2474- MOVE FOLLOUP-VAL-OPERACAO TO S01-VLR-OPERACAO */
            _.Move(FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO, S01_REGISTRO.S01_VLR_OPERACAO);

            /*" -2475- MOVE GE381-COD-BCO TO S01-COD-BANCO */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_BCO, S01_REGISTRO.S01_COD_BANCO);

            /*" -2476- MOVE GE381-COD-AGENCIA TO S01-COD-AGENCIA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA, S01_REGISTRO.S01_COD_AGENCIA);

            /*" -2477- MOVE GE381-COD-AGENCIA-DV TO S01-COD-AGENCIA-DV */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_AGENCIA_DV, S01_REGISTRO.S01_COD_AGENCIA_DV);

            /*" -2478- MOVE GE381-COD-OPERACAO TO S01-COD-OPERACAO */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_COD_OPERACAO, S01_REGISTRO.S01_COD_OPERACAO);

            /*" -2479- MOVE GE381-NUM-CONTA TO S01-NUM-CONTA */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA, S01_REGISTRO.S01_NUM_CONTA);

            /*" -2480- MOVE GE381-NUM-CONTA-DV1 TO S01-NUM-CONTA-DV */
            _.Move(GE381.DCLGE_CLI_DADOS_FINANC.GE381_NUM_CONTA_DV1, S01_REGISTRO.S01_NUM_CONTA_DV);

            /*" -2482- MOVE CBCONDEV-NUM-CHEQUE-INTERNO TO S01-NUM-CHEQUE-INT */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO, S01_REGISTRO.S01_NUM_CHEQUE_INT);

            /*" -2484- MOVE WS-MENSAGEM TO S01-MENSAGEM */
            _.Move(WS_MENSAGEM, S01_REGISTRO.S01_MENSAGEM);

            /*" -2485- IF S01-MENSAGEM EQUAL SPACES */

            if (S01_REGISTRO.S01_MENSAGEM.IsEmpty())
            {

                /*" -2486- IF WS-GERA-CHEQUE EQUAL 'N' */

                if (WS_GERA_CHEQUE == "N")
                {

                    /*" -2487- MOVE 'GERADO CREDITO C/C' TO S01-MENSAGEM */
                    _.Move("GERADO CREDITO C/C", S01_REGISTRO.S01_MENSAGEM);

                    /*" -2488- ELSE */
                }
                else
                {


                    /*" -2489- MOVE 'GERADO CHEQUE' TO S01-MENSAGEM */
                    _.Move("GERADO CHEQUE", S01_REGISTRO.S01_MENSAGEM);

                    /*" -2490- END-IF */
                }


                /*" -2492- END-IF */
            }


            /*" -2494- WRITE S01-REGISTRO */
            CB0110S01.Write(S01_REGISTRO.GetMoveValues().ToString());

            /*" -2495- IF NOT STATUS-OK-S01 */

            if (!STATUS_S01["STATUS_OK_S01"])
            {

                /*" -2496- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -2497- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -2499- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -2502- STRING 'ERRO NA GRAVACAO REGISTRO - STATUS ' STATUS-S01 DELIMITED BY SIZE INTO WS-MSG */
                #region STRING
                var spl4 = "ERRO NA GRAVACAO REGISTRO - STATUS " + STATUS_S01.GetMoveValues();
                _.Move(spl4, WS_MSG);
                #endregion

                /*" -2503- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -2505- END-IF */
            }


            /*" -2505- ADD 1 TO WS-QT-IMPR. */
            WS_QT_IMPR.Value = WS_QT_IMPR + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22370_99_SAIDA*/

        [StopWatch]
        /*" P22400-00-ATUALIZACOES-SECTION */
        private void P22400_00_ATUALIZACOES_SECTION()
        {
            /*" -2518- MOVE 'P22400' TO WS-NR-PARAG. */
            _.Move("P22400", WS_DISPLAY.WS_NR_PARAG);

            /*" -2519- MOVE SISTEMAS-DATA-MOV-ABERTO TO FOLLOUP-DATA-LIBERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO);

            /*" -2520- MOVE '1' TO FOLLOUP-SIT-REGISTRO */
            _.Move("1", FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO);

            /*" -2532- MOVE 202 TO FOLLOUP-COD-OPERACAO */
            _.Move(202, FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO);

            /*" -2543- PERFORM P22400_00_ATUALIZACOES_DB_UPDATE_1 */

            P22400_00_ATUALIZACOES_DB_UPDATE_1();

            /*" -2546- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2547- DISPLAY 'APOLICE   ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE   {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -2548- DISPLAY 'ENDOSSO   ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO   {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -2549- DISPLAY 'PARCELA   ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA   {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -2550- DISPLAY 'DATA MOV  ' FOLLOUP-DATA-MOVIMENTO */
                _.Display($"DATA MOV  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO}");

                /*" -2551- DISPLAY 'HORA OPER ' FOLLOUP-HORA-OPERACAO */
                _.Display($"HORA OPER {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO}");

                /*" -2552- DISPLAY 'SIT.REG   ' FOLLOUP-SIT-REGISTRO */
                _.Display($"SIT.REG   {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO}");

                /*" -2553- DISPLAY 'OPERACAO  ' FOLLOUP-COD-OPERACAO */
                _.Display($"OPERACAO  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO}");

                /*" -2555- DISPLAY 'LIBERACAO ' FOLLOUP-DATA-LIBERACAO */
                _.Display($"LIBERACAO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO}");

                /*" -2558- MOVE 'ERRO NA ALTERACAO NA TABELA .FOLLOW_UP' TO WS-MSG */
                _.Move("ERRO NA ALTERACAO NA TABELA .FOLLOW_UP", WS_MSG);

                /*" -2559- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -2561- END-IF */
            }


            /*" -2563- SUBTRACT 1 FROM PARCELAS-QTD-DOCUMENTOS */
            PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.Value = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS - 1;

            /*" -2571- IF PARCELAS-QTD-DOCUMENTOS >= 0 */

            if (PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS >= 0)
            {

                /*" -2578- PERFORM P22400_00_ATUALIZACOES_DB_UPDATE_2 */

                P22400_00_ATUALIZACOES_DB_UPDATE_2();

                /*" -2581- IF SQLCODE NOT = 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -2582- DISPLAY 'APOLICE    ' FOLLOUP-NUM-APOLICE */
                    _.Display($"APOLICE    {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                    /*" -2583- DISPLAY 'ENDOSSO    ' FOLLOUP-NUM-ENDOSSO */
                    _.Display($"ENDOSSO    {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                    /*" -2584- DISPLAY 'PARCELA    ' FOLLOUP-NUM-PARCELA */
                    _.Display($"PARCELA    {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                    /*" -2586- DISPLAY 'DOCUMENTOS ' PARCELAS-QTD-DOCUMENTOS */
                    _.Display($"DOCUMENTOS {PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS}");

                    /*" -2589- MOVE 'ERRO NA ALTERACAO NA TABELA .PARCELAS' TO WS-MSG */
                    _.Move("ERRO NA ALTERACAO NA TABELA .PARCELAS", WS_MSG);

                    /*" -2590- PERFORM P30000-00-FINALIZA */

                    P30000_00_FINALIZA_SECTION();

                    /*" -2591- END-IF */
                }


                /*" -2595- END-IF */
            }


            /*" -2604- COMPUTE AVISOSAL-SALDO-ATUAL = AVISOSAL-SALDO-ATUAL - FOLLOUP-VAL-OPERACAO */
            AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.Value = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL - FOLLOUP.DCLFOLLOW_UP.FOLLOUP_VAL_OPERACAO;

            /*" -2610- PERFORM P22400_00_ATUALIZACOES_DB_UPDATE_3 */

            P22400_00_ATUALIZACOES_DB_UPDATE_3();

            /*" -2613- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2614- DISPLAY 'APOLICE ' FOLLOUP-NUM-APOLICE */
                _.Display($"APOLICE {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE}");

                /*" -2615- DISPLAY 'ENDOSSO ' FOLLOUP-NUM-ENDOSSO */
                _.Display($"ENDOSSO {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO}");

                /*" -2616- DISPLAY 'PARCELA ' FOLLOUP-NUM-PARCELA */
                _.Display($"PARCELA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA}");

                /*" -2617- DISPLAY 'AGENCIA ' FOLLOUP-AGE-AVISO */
                _.Display($"AGENCIA {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO}");

                /*" -2618- DISPLAY 'SEGURO  ' FOLLOUP-TIPO-SEGURO */
                _.Display($"SEGURO  {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO}");

                /*" -2619- DISPLAY 'AVISO   ' FOLLOUP-NUM-AVISO-CREDITO */
                _.Display($"AVISO   {FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO}");

                /*" -2621- DISPLAY 'SALDO   ' AVISOSAL-SALDO-ATUAL */
                _.Display($"SALDO   {AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL}");

                /*" -2624- MOVE 'ERRO NA ALTERACAO NA TABELA .AVISOS_SALDOS' TO WS-MSG */
                _.Move("ERRO NA ALTERACAO NA TABELA .AVISOS_SALDOS", WS_MSG);

                /*" -2625- PERFORM P30000-00-FINALIZA */

                P30000_00_FINALIZA_SECTION();

                /*" -2625- END-IF. */
            }


        }

        [StopWatch]
        /*" P22400-00-ATUALIZACOES-DB-UPDATE-1 */
        public void P22400_00_ATUALIZACOES_DB_UPDATE_1()
        {
            /*" -2543- EXEC SQL UPDATE SEGUROS.FOLLOW_UP SET SIT_REGISTRO = :FOLLOUP-SIT-REGISTRO ,COD_OPERACAO = :FOLLOUP-COD-OPERACAO ,DATA_LIBERACAO = :FOLLOUP-DATA-LIBERACAO ,TIMESTAMP = CURRENT TIMESTAMP WHERE DATA_MOVIMENTO = :FOLLOUP-DATA-MOVIMENTO AND HORA_OPERACAO = :FOLLOUP-HORA-OPERACAO AND NUM_APOLICE = :FOLLOUP-NUM-APOLICE AND NUM_ENDOSSO = :FOLLOUP-NUM-ENDOSSO AND NUM_PARCELA = :FOLLOUP-NUM-PARCELA END-EXEC */

            var p22400_00_ATUALIZACOES_DB_UPDATE_1_Update1 = new P22400_00_ATUALIZACOES_DB_UPDATE_1_Update1()
            {
                FOLLOUP_DATA_LIBERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.ToString(),
                FOLLOUP_SIT_REGISTRO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_SIT_REGISTRO.ToString(),
                FOLLOUP_COD_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_COD_OPERACAO.ToString(),
                FOLLOUP_DATA_MOVIMENTO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.ToString(),
                FOLLOUP_HORA_OPERACAO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.ToString(),
                FOLLOUP_NUM_APOLICE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE.ToString(),
                FOLLOUP_NUM_ENDOSSO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO.ToString(),
                FOLLOUP_NUM_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA.ToString(),
            };

            P22400_00_ATUALIZACOES_DB_UPDATE_1_Update1.Execute(p22400_00_ATUALIZACOES_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P22400_99_SAIDA*/

        [StopWatch]
        /*" P22400-00-ATUALIZACOES-DB-UPDATE-2 */
        public void P22400_00_ATUALIZACOES_DB_UPDATE_2()
        {
            /*" -2578- EXEC SQL UPDATE SEGUROS.PARCELAS SET QTD_DOCUMENTOS = :PARCELAS-QTD-DOCUMENTOS ,TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_APOLICE = :FOLLOUP-NUM-APOLICE AND NUM_ENDOSSO = :FOLLOUP-NUM-ENDOSSO AND NUM_PARCELA = :FOLLOUP-NUM-PARCELA END-EXEC */

            var p22400_00_ATUALIZACOES_DB_UPDATE_2_Update1 = new P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1()
            {
                PARCELAS_QTD_DOCUMENTOS = PARCELAS.DCLPARCELAS.PARCELAS_QTD_DOCUMENTOS.ToString(),
                FOLLOUP_NUM_APOLICE = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_APOLICE.ToString(),
                FOLLOUP_NUM_ENDOSSO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_ENDOSSO.ToString(),
                FOLLOUP_NUM_PARCELA = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_PARCELA.ToString(),
            };

            P22400_00_ATUALIZACOES_DB_UPDATE_2_Update1.Execute(p22400_00_ATUALIZACOES_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" P30000-00-FINALIZA-SECTION */
        private void P30000_00_FINALIZA_SECTION()
        {
            /*" -2636- CLOSE CB0110S01 */
            CB0110S01.Close();

            /*" -2637- IF WS-MSG = SPACES */

            if (WS_MSG.IsEmpty())
            {

                /*" -2640- MOVE 'OPERACAO EFETUADA COM SUCESSO' TO WS-MSG */
                _.Move("OPERACAO EFETUADA COM SUCESSO", WS_MSG);

                /*" -2640- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -2644- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -2645- ELSE */
            }
            else
            {


                /*" -2646- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_DISPLAY.WS_SQLCODE);

                /*" -2648- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WS_DISPLAY.WS_SQLERRMC);

                /*" -2650- DISPLAY WS-DISPLAY */
                _.Display(WS_DISPLAY);

                /*" -2650- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -2653- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -2655- END-IF */
            }


            /*" -2657- DISPLAY 'MENSAGEM: ' WS-MSG */
            _.Display($"MENSAGEM: {WS_MSG}");

            /*" -2659- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE);

            /*" -2662- DISPLAY 'DATA TERMINO: ' WS-DT-TODAY ' - HORA TERMINO: ' WS-HR-TODAY */

            $"DATA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_DT_TODAY} - HORA TERMINO: {WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_TODAY}"
            .Display();

            /*" -2667- COMPUTE WS-SEG-FINAL = (WS-HR-HOR * 60 * 60) + (WS-HR-MIN * 60) + WS-HR-SEG + (WS-HR-DECSEG / 100) */
            WS_SEG_FINAL.Value = (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_40.WS_HR_HOR * 60 * 60) + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_40.WS_HR_MIN * 60) + WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.FILLER_40.WS_HR_SEG + (WS_VARIAVEIS_GLOBAIS.WS_CURRENT_DATE.WS_DATE_R.WS_HR_DECSEG / 100f);

            /*" -2669- SUBTRACT WS-SEG-INICIAL FROM WS-SEG-FINAL */
            WS_SEG_FINAL.Value = WS_SEG_FINAL - WS_SEG_INICIAL;

            /*" -2671- MOVE WS-SEG-FINAL TO WS-TOT-TIME-ED */
            _.Move(WS_SEG_FINAL, WS_TOT_TIME_ED);

            /*" -2673- DISPLAY 'TEMPO SEG: ' WS-TOT-TIME-ED */
            _.Display($"TEMPO SEG: {WS_TOT_TIME_ED}");

            /*" -2675- COMPUTE WS-SEG-FINAL = WS-SEG-FINAL / 60 */
            WS_SEG_FINAL.Value = WS_SEG_FINAL / 60f;

            /*" -2677- MOVE WS-SEG-FINAL TO WS-TOT-TIME-ED */
            _.Move(WS_SEG_FINAL, WS_TOT_TIME_ED);

            /*" -2679- DISPLAY 'TEMPO MIN: ' WS-TOT-TIME-ED */
            _.Display($"TEMPO MIN: {WS_TOT_TIME_ED}");

            /*" -2679- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" P22400-00-ATUALIZACOES-DB-UPDATE-3 */
        public void P22400_00_ATUALIZACOES_DB_UPDATE_3()
        {
            /*" -2610- EXEC SQL UPDATE SEGUROS.AVISOS_SALDOS SET SALDO_ATUAL = :AVISOSAL-SALDO-ATUAL WHERE AGE_AVISO = :FOLLOUP-AGE-AVISO AND TIPO_SEGURO = :FOLLOUP-TIPO-SEGURO AND NUM_AVISO_CREDITO = :FOLLOUP-NUM-AVISO-CREDITO END-EXEC */

            var p22400_00_ATUALIZACOES_DB_UPDATE_3_Update1 = new P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1()
            {
                AVISOSAL_SALDO_ATUAL = AVISOSAL.DCLAVISOS_SALDOS.AVISOSAL_SALDO_ATUAL.ToString(),
                FOLLOUP_NUM_AVISO_CREDITO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_NUM_AVISO_CREDITO.ToString(),
                FOLLOUP_TIPO_SEGURO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_TIPO_SEGURO.ToString(),
                FOLLOUP_AGE_AVISO = FOLLOUP.DCLFOLLOW_UP.FOLLOUP_AGE_AVISO.ToString(),
            };

            P22400_00_ATUALIZACOES_DB_UPDATE_3_Update1.Execute(p22400_00_ATUALIZACOES_DB_UPDATE_3_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P30000_99_FIM*/
    }
}