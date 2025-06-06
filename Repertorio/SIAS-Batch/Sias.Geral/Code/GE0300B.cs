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
using Sias.Geral.DB2.GE0300B;

namespace Code
{
    public class GE0300B
    {
        public bool IsCall { get; set; }

        public GE0300B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  GE0300B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JULHO / 2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   SUB-ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DOS ARQUIVOS  *      */
        /*"      *   DE INTERFACE COM O SAP                                       *      */
        /*"      *                                                                *      */
        /*"      * CADMUS - 45.753 e 49.319                                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO REINF - OUT/2017                                       *      */
        /*"      *  ALTERA��O DO CAMPO GE_ARQUIVO_SAP.TXT_REG_SAP DE 3.952 BYTES  *      */
        /*"      *    PARA 4.834 BYTES                                            *      */
        /*"      *  PROCURAR V.01 - DOUGLAS ARAUJO - ATOS                         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   HOST-TIMESTAMP            PIC  X(026) VALUE SPACES.*/
        public StringBasis HOST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"77   HOST-SI-DATA-MOV-ABERTO   PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-SI-CURRENT-DATE      PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_SI_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-DATE         PIC  X(010) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_DATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   HOST-CURRENT-TIME         PIC  X(008) VALUE SPACES.*/
        public StringBasis HOST_CURRENT_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"77   HOST-NUM-IMOVEL           PIC S9(005) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_IMOVEL { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77   HOST-NUM-CEP              PIC S9(008) VALUE +0 COMP.*/
        public IntBasis HOST_NUM_CEP { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
        /*"77   HOST-COUNT                PIC S9(009) VALUE +0 COMP.*/
        public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   VIND-SEQ-TIPO-OBJ-SEG     PIC S9(004) VALUE +0 COMP.*/
        public IntBasis VIND_SEQ_TIPO_OBJ_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   NULL-COD-AGENCIA              PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   NULL-COD-BANCO                PIC S9(04) COMP VALUE +0.*/
        public IntBasis NULL_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01           AREA-DE-WORK.*/
        public GE0300B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0300B_AREA_DE_WORK();
        public class GE0300B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05 W-IDLG-SIAS-SINISTRO.*/
            public GE0300B_W_IDLG_SIAS_SINISTRO W_IDLG_SIAS_SINISTRO { get; set; } = new GE0300B_W_IDLG_SIAS_SINISTRO();
            public class GE0300B_W_IDLG_SIAS_SINISTRO : VarBasis
            {
                /*"    10 W-IDLG-SINISTRO               PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 W-IDLG-NUM-APOL-SINISTRO      PIC 9(13) VALUE 0.*/
                public IntBasis W_IDLG_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-OCORR-HISTORICO        PIC 9(05) VALUE 0.*/
                public IntBasis W_IDLG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-COD-OPERACAO           PIC 9(04) VALUE 0.*/
                public IntBasis W_IDLG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-TIPO-MOVIMENTO         PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-FORMA-PAGAMENTO        PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 FILLER                        PIC X(01) VALUE '|'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-COMPLEMENTO            PIC X(10).*/
                public StringBasis W_IDLG_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    10 W-IDLG-COMPLEMENTO-1   REDEFINES  W-IDLG-COMPLEMENTO.*/
                private _REDEF_GE0300B_W_IDLG_COMPLEMENTO_1 _w_idlg_complemento_1 { get; set; }
                public _REDEF_GE0300B_W_IDLG_COMPLEMENTO_1 W_IDLG_COMPLEMENTO_1
                {
                    get { _w_idlg_complemento_1 = new _REDEF_GE0300B_W_IDLG_COMPLEMENTO_1(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); _w_idlg_complemento_1.ValueChanged += () => { _.Move(_w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_1; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_GE0300B_W_IDLG_COMPLEMENTO_1 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-CHEQUE-INTERNO  PIC 9(10).*/
                    public IntBasis W_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-2   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_GE0300B_W_IDLG_COMPLEMENTO_1()
                    {
                        W_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_GE0300B_W_IDLG_COMPLEMENTO_2 _w_idlg_complemento_2 { get; set; }
                public _REDEF_GE0300B_W_IDLG_COMPLEMENTO_2 W_IDLG_COMPLEMENTO_2
                {
                    get { _w_idlg_complemento_2 = new _REDEF_GE0300B_W_IDLG_COMPLEMENTO_2(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); _w_idlg_complemento_2.ValueChanged += () => { _.Move(_w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_2; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_GE0300B_W_IDLG_COMPLEMENTO_2 : VarBasis
                {
                    /*"       15 W-IDLG-NSAS                PIC 9(10).*/
                    public IntBasis W_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-3   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_GE0300B_W_IDLG_COMPLEMENTO_2()
                    {
                        W_IDLG_NSAS.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_GE0300B_W_IDLG_COMPLEMENTO_3 _w_idlg_complemento_3 { get; set; }
                public _REDEF_GE0300B_W_IDLG_COMPLEMENTO_3 W_IDLG_COMPLEMENTO_3
                {
                    get { _w_idlg_complemento_3 = new _REDEF_GE0300B_W_IDLG_COMPLEMENTO_3(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); _w_idlg_complemento_3.ValueChanged += () => { _.Move(_w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_3; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_GE0300B_W_IDLG_COMPLEMENTO_3 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-ACORDO          PIC 9(05).*/
                    public IntBasis W_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       15 FILLER                     PIC X(01).*/
                    public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       15 W-IDLG-NUM-PARCELA         PIC 9(04).*/
                    public IntBasis W_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"  05 W-LOTE-NUM-SEQUENCIA            PIC 9(09) VALUE 0.*/

                    public _REDEF_GE0300B_W_IDLG_COMPLEMENTO_3()
                    {
                        W_IDLG_NUM_ACORDO.ValueChanged += OnValueChanged;
                        FILLER_5.ValueChanged += OnValueChanged;
                        W_IDLG_NUM_PARCELA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis W_LOTE_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05       WSTATUS               PIC  9(002)     VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 W-LOTE.*/
            public GE0300B_W_LOTE W_LOTE { get; set; } = new GE0300B_W_LOTE();
            public class GE0300B_W_LOTE : VarBasis
            {
                /*"    10 W-LOTE-NOME-PROGRAMA          PIC X(08) VALUE 'GE0300B'.*/
                public StringBasis W_LOTE_NOME_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"GE0300B");
                /*"    10 W-LOTE-SIGLA-MODULO           PIC X(02) VALUE '??'.*/
                public StringBasis W_LOTE_SIGLA_MODULO { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"??");
                /*"    10 W-LOTE-DATE-AAAA              PIC 9(04) VALUE 9999.*/
                public IntBasis W_LOTE_DATE_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 9999);
                /*"    10 W-LOTE-DATE-MM                PIC 9(02) VALUE 12.*/
                public IntBasis W_LOTE_DATE_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 12);
                /*"    10 W-LOTE-DATE-DD                PIC 9(02) VALUE 31.*/
                public IntBasis W_LOTE_DATE_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 31);
                /*"    10 W-LOTE-TIME-HH                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    10 W-LOTE-TIME-MM                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"    10 W-LOTE-TIME-SS                PIC 9(02) VALUE 01.*/
                public IntBasis W_LOTE_TIME_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"), 01);
                /*"  05  WFIM-LE-MOVDEBCE-1       PIC  X(003)    VALUE SPACES.*/
            }
            public StringBasis WFIM_LE_MOVDEBCE_1 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  WFIM-IMPOSTOS            PIC  X(003)    VALUE SPACES.*/
            public StringBasis WFIM_IMPOSTOS { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05  W-AC-LIDOS-MOVDEBCE      PIC  9(005)    VALUE ZEROS.*/
            public IntBasis W_AC_LIDOS_MOVDEBCE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05 W-DATA-AAAAMMDD.*/
            public GE0300B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new GE0300B_W_DATA_AAAAMMDD();
            public class GE0300B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"     10 W-DATA-AAAAMMDD-AAAA         PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 W-DATA-AAAAMMDD-MM           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 W-DATA-AAAAMMDD-DD           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05         WHORA-CURR.*/
            }
            public GE0300B_WHORA_CURR WHORA_CURR { get; set; } = new GE0300B_WHORA_CURR();
            public class GE0300B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORAS.*/
            }
            public GE0300B_WHORAS WHORAS { get; set; } = new GE0300B_WHORAS();
            public class GE0300B_WHORAS : VarBasis
            {
                /*"    10       WHORAS-HH         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_HH { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-MM         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-SS         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_SS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORAS-CC         PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORAS_CC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WMONTA-DATA       PIC  X(008)    VALUE SPACES.*/
            }
            public StringBasis WMONTA_DATA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05         FILLER            REDEFINES      WMONTA-DATA.*/
            private _REDEF_GE0300B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_GE0300B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_GE0300B_FILLER_6(); _.Move(WMONTA_DATA, _filler_6); VarBasis.RedefinePassValue(WMONTA_DATA, _filler_6, WMONTA_DATA); _filler_6.ValueChanged += () => { _.Move(_filler_6, WMONTA_DATA); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, WMONTA_DATA); }
            }  //Redefines
            public class _REDEF_GE0300B_FILLER_6 : VarBasis
            {
                /*"    10       WDATA-DIA         PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-MES         PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-ANO         PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-EDICAO                 PIC Z.ZZ9.*/

                public _REDEF_GE0300B_FILLER_6()
                {
                    WDATA_DIA.ValueChanged += OnValueChanged;
                    WDATA_MES.ValueChanged += OnValueChanged;
                    WDATA_ANO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_EDICAO { get; set; } = new IntBasis(new PIC("9", "4", "Z.ZZ9."));
            /*"  05  W-EDICAO-QTD             PIC Z.ZZZ.ZZ9.*/
            public IntBasis W_EDICAO_QTD { get; set; } = new IntBasis(new PIC("9", "7", "Z.ZZZ.ZZ9."));
            /*"  05  W-EDICAO-VALOR-1         PIC Z.ZZZ.ZZ9,99-.*/
            public DoubleBasis W_EDICAO_VALOR_1 { get; set; } = new DoubleBasis(new PIC("9", "7", "Z.ZZZ.ZZ9V99-."), 3);
            /*"01          WABEND.*/
        }
        public GE0300B_WABEND WABEND { get; set; } = new GE0300B_WABEND();
        public class GE0300B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' GE0300B'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0300B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REGISTRO-LINKAGE-GE0300B.*/
        }
        public GE0300B_REGISTRO_LINKAGE_GE0300B REGISTRO_LINKAGE_GE0300B { get; set; } = new GE0300B_REGISTRO_LINKAGE_GE0300B();
        public class GE0300B_REGISTRO_LINKAGE_GE0300B : VarBasis
        {
            /*"    05 LK-GE0300B-FUNCAO                  PIC  9(02).*/
            public IntBasis LK_GE0300B_FUNCAO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"    05 LK-GE0300B-IDLG                    PIC  X(40).*/
            public StringBasis LK_GE0300B_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0300B-DATA-MOV-ABERTO         PIC  X(10).*/
            public StringBasis LK_GE0300B_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05 LK-GE0300B-IDE-SISTEMA             PIC  X(02).*/
            public StringBasis LK_GE0300B_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05 LK-GE0300B-NUM-ESTRUTURA           PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NUM_ESTRUTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-APOLICE             piC S9(13) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "0", "05"));
            /*"    05 LK-GE0300B-NUM-ENDOSSO             PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-NUM-PARCELA             PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-NOSSO-TITULO        PIC S9(16) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_NOSSO_TITULO { get; set; } = new IntBasis(new PIC("S9", "16", "S9(16)"));
            /*"    05 LK-GE0300B-NUM-OCORR-HISTORICO     PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NUM_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-APOL-SINISTRO       PIC S9(13) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
            /*"    05 LK-GE0300B-COD-OPERACAO            PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-RESSARC             PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_NUM_RESSARC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-SEQ-RESSARC             PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_SEQ_RESSARC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NSAS                    PIC S9(04) COMP.*/
            public IntBasis LK_GE0300B_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05 LK-GE0300B-NUM-CHEQUE-INTERNO      PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-COD-CONVENIO            PIC S9(09) COMP.*/
            public IntBasis LK_GE0300B_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"    05 LK-GE0300B-NUM-CERTIFICADO         PIC S9(15) COMP-3.*/
            public IntBasis LK_GE0300B_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
            /*"    05 LK-GE0300B-CHR-USO-EMPRESA         PIC  X(200).*/
            public StringBasis LK_GE0300B_CHR_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"    05 LK-GE0300B-REGISTRO                PIC  X(4834).*/
            public StringBasis LK_GE0300B_REGISTRO { get; set; } = new StringBasis(new PIC("X", "4834", "X(4834)."), @"");
            /*"    05 LK-GE0300B-COD-RETORNO             PIC  X(01).*/
            public StringBasis LK_GE0300B_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-GE0300B-MENSAGEM.*/
            public GE0300B_LK_GE0300B_MENSAGEM LK_GE0300B_MENSAGEM { get; set; } = new GE0300B_LK_GE0300B_MENSAGEM();
            public class GE0300B_LK_GE0300B_MENSAGEM : VarBasis
            {
                /*"       10 LK-GE0300B-SQLCODE              PIC   -ZZ9.*/
                public IntBasis LK_GE0300B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-GE0300B-MENSAGEM-RETORNO     PIC  X(75).*/
                public StringBasis LK_GE0300B_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Dclgens.GE096 GE096 { get; set; } = new Dclgens.GE096();
        public Dclgens.GE098 GE098 { get; set; } = new Dclgens.GE098();
        public Dclgens.GE097 GE097 { get; set; } = new Dclgens.GE097();
        public Dclgens.GE094 GE094 { get; set; } = new Dclgens.GE094();
        public Dclgens.GE095 GE095 { get; set; } = new Dclgens.GE095();
        public Dclgens.GE099 GE099 { get; set; } = new Dclgens.GE099();
        public Dclgens.GE101 GE101 { get; set; } = new Dclgens.GE101();
        public Dclgens.GE100 GE100 { get; set; } = new Dclgens.GE100();
        public Dclgens.GE102 GE102 { get; set; } = new Dclgens.GE102();
        public Dclgens.GE113 GE113 { get; set; } = new Dclgens.GE113();
        public Dclgens.GE112 GE112 { get; set; } = new Dclgens.GE112();
        public Dclgens.GE104 GE104 { get; set; } = new Dclgens.GE104();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(GE0300B_REGISTRO_LINKAGE_GE0300B GE0300B_REGISTRO_LINKAGE_GE0300B_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_GE0300B*/
        {
            try
            {
                this.REGISTRO_LINKAGE_GE0300B = GE0300B_REGISTRO_LINKAGE_GE0300B_P;

                /*" -390- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -392- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -394- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -439- INITIALIZE DCLGE-MOVDEBCE-SAP DCLGE-VIDA-SAP DCLGE-BOLETO-EMISSAO DCLGE-CHEQUE-SAP DCLGE-BOLETO-RESSARC-SINI DCLGE-MOVIMENTO-SAP DCLGE-CONTROLE-INTERF-SAP DCLGE-FEBRABAN-USO-EMPRESA DCLGE-ARQUIVO-SAP . */
                _.Initialize(
                    GE094.DCLGE_MOVDEBCE_SAP
                    , GE095.DCLGE_VIDA_SAP
                    , GE096.DCLGE_BOLETO_EMISSAO
                    , GE097.DCLGE_CHEQUE_SAP
                    , GE098.DCLGE_BOLETO_RESSARC_SINI
                    , GE099.DCLGE_MOVIMENTO_SAP
                    , GE100.DCLGE_CONTROLE_INTERF_SAP
                    , GE113.DCLGE_FEBRABAN_USO_EMPRESA
                    , GE102.DCLGE_ARQUIVO_SAP
                );

                /*" -440- MOVE 0 TO LK-GE0300B-SQLCODE */
                _.Move(0, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_SQLCODE);

                /*" -441- MOVE ' ' TO LK-GE0300B-COD-RETORNO */
                _.Move(" ", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -443- MOVE SPACES TO LK-GE0300B-MENSAGEM. */
                _.Move("", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM);

                /*" -445- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -447- PERFORM R0020-CRITICA-LINKAGE THRU R0020-EXIT. */

                R0020_CRITICA_LINKAGE(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -449- PERFORM R1000-INCLUI-ESTRUTURA THRU R1000-EXIT. */

                R1000_INCLUI_ESTRUTURA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


                /*" -450- MOVE '0' TO LK-GE0300B-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -454- MOVE 'EXECUCAO COM SUCESSO' TO LK-GE0300B-MENSAGEM. */
                _.Move("EXECUCAO COM SUCESSO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM);

                /*" -454- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_GE0300B, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -474- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -477- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -478- DISPLAY 'GE0300B - ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"GE0300B - ERRO NO ACESSO SISTEMAS - FI");

                /*" -478- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -474- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE, CURRENT TIMESTAMP, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-CURRENT-DATE, :HOST-TIMESTAMP, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

            var r0010_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0010_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0010_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
                _.Move(executed_1.HOST_CURRENT_DATE, HOST_CURRENT_DATE);
                _.Move(executed_1.HOST_TIMESTAMP, HOST_TIMESTAMP);
                _.Move(executed_1.HOST_CURRENT_TIME, HOST_CURRENT_TIME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/

        [StopWatch]
        /*" R0020-CRITICA-LINKAGE */
        private void R0020_CRITICA_LINKAGE(bool isPerform = false)
        {
            /*" -485- IF LK-GE0300B-FUNCAO NOT EQUAL 1 */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_FUNCAO != 1)
            {

                /*" -486- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -489- MOVE 'GE0300B - FUNCAO INVALIDA' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - FUNCAO INVALIDA", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -491- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -492- IF LK-GE0300B-IDE-SISTEMA EQUAL SPACES */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA.IsEmpty())
            {

                /*" -493- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -496- MOVE 'GE0300B - IDE-SISTEMA NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - IDE-SISTEMA NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -497- DISPLAY 'GE0300B - COD RETORNO ' LK-GE0300B-COD-RETORNO */
                _.Display($"GE0300B - COD RETORNO {REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO}");

                /*" -498- DISPLAY 'GE0300B - MSG RET ' LK-GE0300B-MENSAGEM-RETORNO */
                _.Display($"GE0300B - MSG RET {REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO}");

                /*" -540- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -542- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 1) AND (LK-GE0300B-NUM-NOSSO-TITULO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 1) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_NOSSO_TITULO == 0))
            {

                /*" -543- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -546- MOVE 'GE0300B - BOLETO DE EMISSAO - TITULO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO DE EMISSAO - TITULO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -560- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -562- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-NUM-APOL-SINISTRO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOL_SINISTRO == 0))
            {

                /*" -563- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -566- MOVE 'GE0300B - BOLETO RESSARC - SINISTRO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - SINISTRO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -568- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -570- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-COD-OPERACAO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_OPERACAO == 0))
            {

                /*" -571- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -574- MOVE 'GE0300B - BOLETO RESSARC - COD. OPERACAO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - COD. OPERACAO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -576- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -578- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-NUM-OCORR-HISTORICO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_OCORR_HISTORICO == 0))
            {

                /*" -579- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -582- MOVE 'GE0300B - BOLETO RESSARC - OCORHIST NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - OCORHIST NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -584- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -586- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-NUM-RESSARC EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_RESSARC == 0))
            {

                /*" -587- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -590- MOVE 'GE0300B - BOLETO RESSARC - NUM. ACORDO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - NUM. ACORDO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -592- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -594- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-NUM-PARCELA EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA == 0))
            {

                /*" -595- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -598- MOVE 'GE0300B - BOLETO RESSARC - NUM. PARCELA NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - NUM. PARCELA NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -600- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -602- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-NUM-NOSSO-TITULO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_NOSSO_TITULO == 0))
            {

                /*" -603- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -606- MOVE 'GE0300B - BOLETO RESSARC - TITULO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - TITULO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -608- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -610- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 2) AND (LK-GE0300B-NSAS EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS == 0))
            {

                /*" -611- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -614- MOVE 'GE0300B - BOLETO RESSARC - NSAS NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - NSAS NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -622- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -624- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 3) AND (LK-GE0300B-NUM-CHEQUE-INTERNO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 3) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_CHEQUE_INTERNO == 0))
            {

                /*" -625- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -628- MOVE 'GE0300B - BOLETO RESSARC - NUM. CHQ. INTERNO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - BOLETO RESSARC - NUM. CHQ. INTERNO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -635- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -637- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 4) AND (LK-GE0300B-NUM-APOLICE EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 4) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOLICE == 0))
            {

                /*" -638- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -641- MOVE 'GE0300B - MOVDEBCE - APOLICE NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - MOVDEBCE - APOLICE NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -686- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -688- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 5) AND (LK-GE0300B-NUM-CERTIFICADO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 5) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_CERTIFICADO == 0))
            {

                /*" -689- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -692- MOVE 'GE0300B - VIDA - CERTIFICADO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - VIDA - CERTIFICADO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -694- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -696- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 5) AND (LK-GE0300B-NUM-PARCELA EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 5) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA == 0))
            {

                /*" -697- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -700- MOVE 'GE0300B - VIDA - PARCELA NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - VIDA - PARCELA NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -702- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -704- IF (LK-GE0300B-NUM-ESTRUTURA EQUAL 5) AND (LK-GE0300B-NUM-NOSSO-TITULO EQUAL 0) */

            if ((REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 5) && (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_NOSSO_TITULO == 0))
            {

                /*" -705- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -708- MOVE 'GE0300B - VIDA - TITULO NAO INFORMADO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - VIDA - TITULO NAO INFORMADO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -708- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/

        [StopWatch]
        /*" R1000-INCLUI-ESTRUTURA */
        private void R1000_INCLUI_ESTRUTURA(bool isPerform = false)
        {
            /*" -730- PERFORM R1010-MAX-MOVIMENTO-SAP THRU R1010-EXIT. */

            R1010_MAX_MOVIMENTO_SAP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


            /*" -732- PERFORM R1200-INS-MOVIMENTO-SAP THRU R1200-EXIT. */

            R1200_INS_MOVIMENTO_SAP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/


            /*" -733- IF LK-GE0300B-NUM-ESTRUTURA EQUAL 1 */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 1)
            {

                /*" -735- PERFORM R1020-INS-BOLETO-EMISSAO THRU R1020-EXIT. */

                R1020_INS_BOLETO_EMISSAO(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

            }


            /*" -736- IF LK-GE0300B-NUM-ESTRUTURA EQUAL 2 */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 2)
            {

                /*" -738- PERFORM R1030-INS-BOLETO-RESSARC-SINI THRU R1030-EXIT. */

                R1030_INS_BOLETO_RESSARC_SINI(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_EXIT*/

            }


            /*" -739- IF LK-GE0300B-NUM-ESTRUTURA EQUAL 3 */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 3)
            {

                /*" -741- PERFORM R1040-INS-CHEQUES-SAP THRU R1040-EXIT. */

                R1040_INS_CHEQUES_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_EXIT*/

            }


            /*" -742- IF LK-GE0300B-NUM-ESTRUTURA EQUAL 4 */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 4)
            {

                /*" -744- PERFORM R1050-INS-MOVDEBCE-SAP THRU R1050-EXIT. */

                R1050_INS_MOVDEBCE_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_EXIT*/

            }


            /*" -745- IF LK-GE0300B-NUM-ESTRUTURA EQUAL 5 */

            if (REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ESTRUTURA == 5)
            {

                /*" -747- PERFORM R1060-INS-VIDA-SAP THRU R1060-EXIT. */

                R1060_INS_VIDA_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_EXIT*/

            }


            /*" -749- PERFORM R1300-INS-CONTROLE THRU R1300-EXIT. */

            R1300_INS_CONTROLE(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/


            /*" -756- PERFORM R1400-INS-REGISTRO-SAP THRU R1400-EXIT. */

            R1400_INS_REGISTRO_SAP(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/


            /*" -757- IF LK-GE0300B-CHR-USO-EMPRESA NOT EQUAL SPACES */

            if (!REGISTRO_LINKAGE_GE0300B.LK_GE0300B_CHR_USO_EMPRESA.IsEmpty())
            {

                /*" -757- PERFORM R1070-INS-USO-EMPRESA THRU R1070-EXIT . */

                R1070_INS_USO_EMPRESA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-MAX-MOVIMENTO-SAP */
        private void R1010_MAX_MOVIMENTO_SAP(bool isPerform = false)
        {
            /*" -769- PERFORM R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1 */

            R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1();

            /*" -772- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -773- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -776- MOVE 'GE0300B - ERRO NO MAX DA GE_MOVIMENTO_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO MAX DA GE_MOVIMENTO_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -776- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1010-MAX-MOVIMENTO-SAP-DB-SELECT-1 */
        public void R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1()
        {
            /*" -769- EXEC SQL SELECT VALUE(MAX(NUM_OCORR_MOVTO),0) + 1 INTO :GE099-NUM-OCORR-MOVTO FROM SEGUROS.GE_MOVIMENTO_SAP WITH UR END-EXEC. */

            var r1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1 = new R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1.Execute(r1010_MAX_MOVIMENTO_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE099_NUM_OCORR_MOVTO, GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1020-INS-BOLETO-EMISSAO */
        private void R1020_INS_BOLETO_EMISSAO(bool isPerform = false)
        {
            /*" -785- MOVE GE099-NUM-OCORR-MOVTO TO GE096-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_OCORR_MOVTO);

            /*" -787- MOVE LK-GE0300B-IDE-SISTEMA TO GE096-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA, GE096.DCLGE_BOLETO_EMISSAO.GE096_IDE_SISTEMA);

            /*" -790- MOVE LK-GE0300B-NUM-APOLICE TO GE096-NUM-APOLICE . */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOLICE, GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_APOLICE);

            /*" -793- MOVE LK-GE0300B-NUM-ENDOSSO TO GE096-NUM-ENDOSSO . */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ENDOSSO, GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_ENDOSSO);

            /*" -796- MOVE LK-GE0300B-NUM-PARCELA TO GE096-NUM-PARCELA . */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA, GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_PARCELA);

            /*" -799- MOVE LK-GE0300B-NUM-NOSSO-TITULO TO GE096-NUM-NOSSO-TITULO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_NOSSO_TITULO, GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_NOSSO_TITULO);

            /*" -802- MOVE LK-GE0300B-NUM-OCORR-HISTORICO TO GE096-NUM-OCORR-HISTORICO . */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_OCORR_HISTORICO, GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_OCORR_HISTORICO);

            /*" -820- PERFORM R1020_INS_BOLETO_EMISSAO_DB_INSERT_1 */

            R1020_INS_BOLETO_EMISSAO_DB_INSERT_1();

            /*" -823- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -824- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -827- MOVE 'GE0300B - ERRO NO INSERT DA GE_BOLETO_EMISSAO' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_BOLETO_EMISSAO", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -827- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-INS-BOLETO-EMISSAO-DB-INSERT-1 */
        public void R1020_INS_BOLETO_EMISSAO_DB_INSERT_1()
        {
            /*" -820- EXEC SQL INSERT INTO SEGUROS.GE_BOLETO_EMISSAO ( NUM_OCORR_MOVTO , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_NOSSO_TITULO , NUM_OCORR_HISTORICO, IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES (:GE096-NUM-OCORR-MOVTO, :GE096-NUM-APOLICE, :GE096-NUM-ENDOSSO, :GE096-NUM-PARCELA, :GE096-NUM-NOSSO-TITULO, :GE096-NUM-OCORR-HISTORICO, :GE096-IDE-SISTEMA, CURRENT TIMESTAMP) END-EXEC. */

            var r1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1 = new R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1()
            {
                GE096_NUM_OCORR_MOVTO = GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_OCORR_MOVTO.ToString(),
                GE096_NUM_APOLICE = GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_APOLICE.ToString(),
                GE096_NUM_ENDOSSO = GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_ENDOSSO.ToString(),
                GE096_NUM_PARCELA = GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_PARCELA.ToString(),
                GE096_NUM_NOSSO_TITULO = GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_NOSSO_TITULO.ToString(),
                GE096_NUM_OCORR_HISTORICO = GE096.DCLGE_BOLETO_EMISSAO.GE096_NUM_OCORR_HISTORICO.ToString(),
                GE096_IDE_SISTEMA = GE096.DCLGE_BOLETO_EMISSAO.GE096_IDE_SISTEMA.ToString(),
            };

            R1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1.Execute(r1020_INS_BOLETO_EMISSAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

        [StopWatch]
        /*" R1030-INS-BOLETO-RESSARC-SINI */
        private void R1030_INS_BOLETO_RESSARC_SINI(bool isPerform = false)
        {
            /*" -836- MOVE GE099-NUM-OCORR-MOVTO TO GE098-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_OCORR_MOVTO);

            /*" -838- MOVE LK-GE0300B-IDE-SISTEMA TO GE098-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_IDE_SISTEMA);

            /*" -841- MOVE LK-GE0300B-NUM-APOL-SINISTRO TO GE098-NUM-APOL-SINISTRO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOL_SINISTRO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_APOL_SINISTRO);

            /*" -844- MOVE LK-GE0300B-COD-OPERACAO TO GE098-COD-OPERACAO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_OPERACAO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_COD_OPERACAO);

            /*" -847- MOVE LK-GE0300B-NUM-OCORR-HISTORICO TO GE098-NUM-OCORR-HISTORICO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_OCORR_HISTORICO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_OCORR_HISTORICO);

            /*" -850- MOVE LK-GE0300B-NUM-RESSARC TO GE098-NUM-RESSARC. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_RESSARC, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_RESSARC);

            /*" -853- MOVE LK-GE0300B-SEQ-RESSARC TO GE098-SEQ-RESSARC. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_SEQ_RESSARC, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_SEQ_RESSARC);

            /*" -856- MOVE LK-GE0300B-NUM-PARCELA TO GE098-NUM-PARCELA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_PARCELA);

            /*" -859- MOVE LK-GE0300B-NUM-NOSSO-TITULO TO GE098-NUM-NOSSO-TITULO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_NOSSO_TITULO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_NOSSO_TITULO);

            /*" -862- MOVE LK-GE0300B-NSAS TO GE098-NSAS. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NSAS);

            /*" -886- PERFORM R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1 */

            R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1();

            /*" -889- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -890- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -893- MOVE 'GE0300B - ERRO NO INSERT DA GE_BOLETO_RESSARC_SINI' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_BOLETO_RESSARC_SINI", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -893- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1030-INS-BOLETO-RESSARC-SINI-DB-INSERT-1 */
        public void R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1()
        {
            /*" -886- EXEC SQL INSERT INTO SEGUROS.GE_BOLETO_RESSARC_SINI ( NUM_OCORR_MOVTO , NUM_APOL_SINISTRO , COD_OPERACAO , NUM_OCORR_HISTORICO, NUM_RESSARC , SEQ_RESSARC , NUM_PARCELA , NUM_NOSSO_TITULO , NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES (:GE098-NUM-OCORR-MOVTO , :GE098-NUM-APOL-SINISTRO , :GE098-COD-OPERACAO , :GE098-NUM-OCORR-HISTORICO , :GE098-NUM-RESSARC , :GE098-SEQ-RESSARC , :GE098-NUM-PARCELA , :GE098-NUM-NOSSO-TITULO , :GE098-NSAS , :GE098-IDE-SISTEMA , CURRENT TIMESTAMP) END-EXEC. */

            var r1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1 = new R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1()
            {
                GE098_NUM_OCORR_MOVTO = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_OCORR_MOVTO.ToString(),
                GE098_NUM_APOL_SINISTRO = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_APOL_SINISTRO.ToString(),
                GE098_COD_OPERACAO = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_COD_OPERACAO.ToString(),
                GE098_NUM_OCORR_HISTORICO = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_OCORR_HISTORICO.ToString(),
                GE098_NUM_RESSARC = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_RESSARC.ToString(),
                GE098_SEQ_RESSARC = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_SEQ_RESSARC.ToString(),
                GE098_NUM_PARCELA = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_PARCELA.ToString(),
                GE098_NUM_NOSSO_TITULO = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_NOSSO_TITULO.ToString(),
                GE098_NSAS = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NSAS.ToString(),
                GE098_IDE_SISTEMA = GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_IDE_SISTEMA.ToString(),
            };

            R1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1.Execute(r1030_INS_BOLETO_RESSARC_SINI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1030_EXIT*/

        [StopWatch]
        /*" R1040-INS-CHEQUES-SAP */
        private void R1040_INS_CHEQUES_SAP(bool isPerform = false)
        {
            /*" -902- MOVE GE099-NUM-OCORR-MOVTO TO GE097-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE097.DCLGE_CHEQUE_SAP.GE097_NUM_OCORR_MOVTO);

            /*" -904- MOVE LK-GE0300B-IDE-SISTEMA TO GE097-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA, GE097.DCLGE_CHEQUE_SAP.GE097_IDE_SISTEMA);

            /*" -907- MOVE LK-GE0300B-NUM-CHEQUE-INTERNO TO GE097-NUM-CHEQUE-INTERNO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_CHEQUE_INTERNO, GE097.DCLGE_CHEQUE_SAP.GE097_NUM_CHEQUE_INTERNO);

            /*" -910- MOVE LK-GE0300B-NSAS TO GE097-NSAS. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS, GE097.DCLGE_CHEQUE_SAP.GE097_NSAS);

            /*" -922- PERFORM R1040_INS_CHEQUES_SAP_DB_INSERT_1 */

            R1040_INS_CHEQUES_SAP_DB_INSERT_1();

            /*" -925- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -926- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -929- MOVE 'GE0300B - ERRO NO INSERT DA GE_CHEQUE_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_CHEQUE_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -929- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1040-INS-CHEQUES-SAP-DB-INSERT-1 */
        public void R1040_INS_CHEQUES_SAP_DB_INSERT_1()
        {
            /*" -922- EXEC SQL INSERT INTO SEGUROS.GE_CHEQUE_SAP ( NUM_OCORR_MOVTO , NUM_CHEQUE_INTERNO, NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES (:GE097-NUM-OCORR-MOVTO, :GE097-NUM-CHEQUE-INTERNO, :GE097-NSAS, :GE097-IDE-SISTEMA, CURRENT TIMESTAMP) END-EXEC. */

            var r1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1 = new R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1()
            {
                GE097_NUM_OCORR_MOVTO = GE097.DCLGE_CHEQUE_SAP.GE097_NUM_OCORR_MOVTO.ToString(),
                GE097_NUM_CHEQUE_INTERNO = GE097.DCLGE_CHEQUE_SAP.GE097_NUM_CHEQUE_INTERNO.ToString(),
                GE097_NSAS = GE097.DCLGE_CHEQUE_SAP.GE097_NSAS.ToString(),
                GE097_IDE_SISTEMA = GE097.DCLGE_CHEQUE_SAP.GE097_IDE_SISTEMA.ToString(),
            };

            R1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1.Execute(r1040_INS_CHEQUES_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1040_EXIT*/

        [StopWatch]
        /*" R1050-INS-MOVDEBCE-SAP */
        private void R1050_INS_MOVDEBCE_SAP(bool isPerform = false)
        {
            /*" -938- MOVE GE099-NUM-OCORR-MOVTO TO GE094-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_OCORR_MOVTO);

            /*" -940- MOVE LK-GE0300B-IDE-SISTEMA TO GE094-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA, GE094.DCLGE_MOVDEBCE_SAP.GE094_IDE_SISTEMA);

            /*" -943- MOVE LK-GE0300B-NUM-APOLICE TO GE094-NUM-APOLICE. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_APOLICE, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_APOLICE);

            /*" -946- MOVE LK-GE0300B-NUM-ENDOSSO TO GE094-NUM-ENDOSSO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_ENDOSSO, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_ENDOSSO);

            /*" -949- MOVE LK-GE0300B-NUM-PARCELA TO GE094-NUM-PARCELA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_PARCELA);

            /*" -952- MOVE LK-GE0300B-COD-CONVENIO TO GE094-COD-CONVENIO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_CONVENIO, GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO);

            /*" -963- MOVE LK-GE0300B-NSAS TO GE094-NSAS. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS, GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS);

            /*" -966- MOVE LK-GE0300B-NSAS TO GE094-NSAS. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS, GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS);

            /*" -984- PERFORM R1050_INS_MOVDEBCE_SAP_DB_INSERT_1 */

            R1050_INS_MOVDEBCE_SAP_DB_INSERT_1();

            /*" -987- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -988- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -991- MOVE 'GE0300B - ERRO NO INSERT DA GE_MOVDEBCE_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_MOVDEBCE_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -991- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1050-INS-MOVDEBCE-SAP-DB-INSERT-1 */
        public void R1050_INS_MOVDEBCE_SAP_DB_INSERT_1()
        {
            /*" -984- EXEC SQL INSERT INTO SEGUROS.GE_MOVDEBCE_SAP ( NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_CONVENIO , NSAS , NUM_OCORR_MOVTO , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES (:GE094-NUM-APOLICE , :GE094-NUM-ENDOSSO , :GE094-NUM-PARCELA , :GE094-COD-CONVENIO , :GE094-NSAS , :GE094-NUM-OCORR-MOVTO , :GE094-IDE-SISTEMA , CURRENT TIMESTAMP) END-EXEC. */

            var r1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1 = new R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1()
            {
                GE094_NUM_APOLICE = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_APOLICE.ToString(),
                GE094_NUM_ENDOSSO = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_ENDOSSO.ToString(),
                GE094_NUM_PARCELA = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_PARCELA.ToString(),
                GE094_COD_CONVENIO = GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO.ToString(),
                GE094_NSAS = GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS.ToString(),
                GE094_NUM_OCORR_MOVTO = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_OCORR_MOVTO.ToString(),
                GE094_IDE_SISTEMA = GE094.DCLGE_MOVDEBCE_SAP.GE094_IDE_SISTEMA.ToString(),
            };

            R1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1.Execute(r1050_INS_MOVDEBCE_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_EXIT*/

        [StopWatch]
        /*" R1060-INS-VIDA-SAP */
        private void R1060_INS_VIDA_SAP(bool isPerform = false)
        {
            /*" -1000- MOVE GE099-NUM-OCORR-MOVTO TO GE095-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE095.DCLGE_VIDA_SAP.GE095_NUM_OCORR_MOVTO);

            /*" -1002- MOVE LK-GE0300B-IDE-SISTEMA TO GE095-IDE-SISTEMA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_IDE_SISTEMA, GE095.DCLGE_VIDA_SAP.GE095_IDE_SISTEMA);

            /*" -1005- MOVE LK-GE0300B-NUM-CERTIFICADO TO GE095-NUM-CERTIFICADO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_CERTIFICADO, GE095.DCLGE_VIDA_SAP.GE095_NUM_CERTIFICADO);

            /*" -1008- MOVE LK-GE0300B-NUM-PARCELA TO GE095-NUM-PARCELA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_PARCELA, GE095.DCLGE_VIDA_SAP.GE095_NUM_PARCELA);

            /*" -1011- MOVE LK-GE0300B-NUM-NOSSO-TITULO TO GE095-NUM-NOSSO-TITULO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NUM_NOSSO_TITULO, GE095.DCLGE_VIDA_SAP.GE095_NUM_NOSSO_TITULO);

            /*" -1014- MOVE LK-GE0300B-NSAS TO GE095-NSAS. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_NSAS, GE095.DCLGE_VIDA_SAP.GE095_NSAS);

            /*" -1030- PERFORM R1060_INS_VIDA_SAP_DB_INSERT_1 */

            R1060_INS_VIDA_SAP_DB_INSERT_1();

            /*" -1033- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1034- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -1037- MOVE 'GE0300B - ERRO NO INSERT DA GE_VIDA_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_VIDA_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -1037- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1060-INS-VIDA-SAP-DB-INSERT-1 */
        public void R1060_INS_VIDA_SAP_DB_INSERT_1()
        {
            /*" -1030- EXEC SQL INSERT INTO SEGUROS.GE_VIDA_SAP ( NUM_OCORR_MOVTO , NUM_CERTIFICADO , NUM_PARCELA , NUM_NOSSO_TITULO , NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES (:GE095-NUM-OCORR-MOVTO , :GE095-NUM-CERTIFICADO , :GE095-NUM-PARCELA , :GE095-NUM-NOSSO-TITULO , :GE095-NSAS , :GE095-IDE-SISTEMA , CURRENT TIMESTAMP) END-EXEC. */

            var r1060_INS_VIDA_SAP_DB_INSERT_1_Insert1 = new R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1()
            {
                GE095_NUM_OCORR_MOVTO = GE095.DCLGE_VIDA_SAP.GE095_NUM_OCORR_MOVTO.ToString(),
                GE095_NUM_CERTIFICADO = GE095.DCLGE_VIDA_SAP.GE095_NUM_CERTIFICADO.ToString(),
                GE095_NUM_PARCELA = GE095.DCLGE_VIDA_SAP.GE095_NUM_PARCELA.ToString(),
                GE095_NUM_NOSSO_TITULO = GE095.DCLGE_VIDA_SAP.GE095_NUM_NOSSO_TITULO.ToString(),
                GE095_NSAS = GE095.DCLGE_VIDA_SAP.GE095_NSAS.ToString(),
                GE095_IDE_SISTEMA = GE095.DCLGE_VIDA_SAP.GE095_IDE_SISTEMA.ToString(),
            };

            R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1.Execute(r1060_INS_VIDA_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1060_EXIT*/

        [StopWatch]
        /*" R1070-INS-USO-EMPRESA */
        private void R1070_INS_USO_EMPRESA(bool isPerform = false)
        {
            /*" -1045- MOVE GE099-NUM-OCORR-MOVTO TO GE113-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_NUM_OCORR_MOVTO);

            /*" -1052- MOVE LK-GE0300B-CHR-USO-EMPRESA TO GE113-CHR-USO-EMPRESA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_CHR_USO_EMPRESA, GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA);

            /*" -1060- PERFORM R1070_INS_USO_EMPRESA_DB_INSERT_1 */

            R1070_INS_USO_EMPRESA_DB_INSERT_1();

            /*" -1063- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1064- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -1067- MOVE 'GE0300B - ERRO NO INSERT DA GE_FEBRABAN_USO_EMPRESA' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_FEBRABAN_USO_EMPRESA", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -1067- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1070-INS-USO-EMPRESA-DB-INSERT-1 */
        public void R1070_INS_USO_EMPRESA_DB_INSERT_1()
        {
            /*" -1060- EXEC SQL INSERT INTO SEGUROS.GE_FEBRABAN_USO_EMPRESA ( NUM_OCORR_MOVTO , CHR_USO_EMPRESA , DTH_CADASTRAMENTO ) VALUES (:GE113-NUM-OCORR-MOVTO , :GE113-CHR-USO-EMPRESA , CURRENT TIMESTAMP) END-EXEC. */

            var r1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1 = new R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1()
            {
                GE113_NUM_OCORR_MOVTO = GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_NUM_OCORR_MOVTO.ToString(),
                GE113_CHR_USO_EMPRESA = GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA.ToString(),
            };

            R1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1.Execute(r1070_INS_USO_EMPRESA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1070_EXIT*/

        [StopWatch]
        /*" R1200-INS-MOVIMENTO-SAP */
        private void R1200_INS_MOVIMENTO_SAP(bool isPerform = false)
        {
            /*" -1080- MOVE LK-GE0300B-DATA-MOV-ABERTO TO GE099-DTH-MOVIMENTO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_DATA_MOV_ABERTO, GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO);

            /*" -1082- MOVE LK-GE0300B-REGISTRO(75:8) TO GE099-NOM-PROGRAMA. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO.Substring(75, 8), GE099.DCLGE_MOVIMENTO_SAP.GE099_NOM_PROGRAMA);

            /*" -1092- PERFORM R1200_INS_MOVIMENTO_SAP_DB_INSERT_1 */

            R1200_INS_MOVIMENTO_SAP_DB_INSERT_1();

            /*" -1095- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1096- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -1099- MOVE 'GE0300B - ERRO NO INSERT DA GE_MOVIMENTO_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_MOVIMENTO_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -1100- DISPLAY 'OCORRENCIA MOVTO: ' GE099-NUM-OCORR-MOVTO */
                _.Display($"OCORRENCIA MOVTO: {GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO}");

                /*" -1101- DISPLAY 'DTH MOVIMENTO   : ' GE099-DTH-MOVIMENTO */
                _.Display($"DTH MOVIMENTO   : {GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO}");

                /*" -1102- DISPLAY 'NOM PROGRAMA    : ' GE099-NOM-PROGRAMA */
                _.Display($"NOM PROGRAMA    : {GE099.DCLGE_MOVIMENTO_SAP.GE099_NOM_PROGRAMA}");

                /*" -1102- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-INS-MOVIMENTO-SAP-DB-INSERT-1 */
        public void R1200_INS_MOVIMENTO_SAP_DB_INSERT_1()
        {
            /*" -1092- EXEC SQL INSERT INTO SEGUROS.GE_MOVIMENTO_SAP ( NUM_OCORR_MOVTO , DTH_MOVIMENTO , NOM_PROGRAMA , DTH_CADASTRAMENTO ) VALUES (:GE099-NUM-OCORR-MOVTO , :GE099-DTH-MOVIMENTO, :GE099-NOM-PROGRAMA , CURRENT TIMESTAMP) END-EXEC. */

            var r1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1 = new R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1()
            {
                GE099_NUM_OCORR_MOVTO = GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO.ToString(),
                GE099_DTH_MOVIMENTO = GE099.DCLGE_MOVIMENTO_SAP.GE099_DTH_MOVIMENTO.ToString(),
                GE099_NOM_PROGRAMA = GE099.DCLGE_MOVIMENTO_SAP.GE099_NOM_PROGRAMA.ToString(),
            };

            R1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1.Execute(r1200_INS_MOVIMENTO_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_EXIT*/

        [StopWatch]
        /*" R1300-INS-CONTROLE */
        private void R1300_INS_CONTROLE(bool isPerform = false)
        {
            /*" -1110- INITIALIZE DCLGE-CONTROLE-INTERF-SAP. */
            _.Initialize(
                GE100.DCLGE_CONTROLE_INTERF_SAP
            );

            /*" -1117- MOVE GE099-NUM-OCORR-MOVTO TO GE100-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO);

            /*" -1119- MOVE LK-GE0300B-REGISTRO(108:40) TO GE100-COD-IDLG. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO.Substring(108, 40), GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG);

            /*" -1122- MOVE LK-GE0300B-DATA-MOV-ABERTO TO GE100-DTA-MOVIMENTO-LEGADO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_DATA_MOV_ABERTO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO);

            /*" -1144- PERFORM R1300_INS_CONTROLE_DB_INSERT_1 */

            R1300_INS_CONTROLE_DB_INSERT_1();

            /*" -1147- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1149- DISPLAY 'GE0300B - ERRO NO INSERT DA GE_CONTROLE_INTERF_SAP' */
                _.Display($"GE0300B - ERRO NO INSERT DA GE_CONTROLE_INTERF_SAP");

                /*" -1151- DISPLAY 'GE100-NUM-OCORR-MOVTO..........' GE100-NUM-OCORR-MOVTO */
                _.Display($"GE100-NUM-OCORR-MOVTO..........{GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -1153- DISPLAY 'GE100-COD-IDLG.................' GE100-COD-IDLG */
                _.Display($"GE100-COD-IDLG.................{GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -1155- DISPLAY 'GE100-DTA-MOVIMENTO-LEGADO.....' GE100-DTA-MOVIMENTO-LEGADO */
                _.Display($"GE100-DTA-MOVIMENTO-LEGADO.....{GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO}");

                /*" -1156- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -1159- MOVE 'GE0300B - ERRO NO INSERT DA GE_CONTROLE_INTERF_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_CONTROLE_INTERF_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -1159- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-INS-CONTROLE-DB-INSERT-1 */
        public void R1300_INS_CONTROLE_DB_INSERT_1()
        {
            /*" -1144- EXEC SQL INSERT INTO SEGUROS.GE_CONTROLE_INTERF_SAP ( NUM_OCORR_MOVTO , COD_IDLG , DTA_MOVIMENTO_LEGADO , DTH_GERACAO_LEGADO , DTH_GERACAO_ARQA , COD_IDE_PAGTO_SAP , COD_IDE_RECEBE_SAP , DTH_PROCESSA_ARQG , IND_ACEITE_SAP , DTA_MOVIMENTO_ARQH ) VALUES (:GE100-NUM-OCORR-MOVTO , :GE100-COD-IDLG , :GE100-DTA-MOVIMENTO-LEGADO , CURRENT TIMESTAMP, NULL, NULL, NULL, NULL, NULL, NULL) END-EXEC. */

            var r1300_INS_CONTROLE_DB_INSERT_1_Insert1 = new R1300_INS_CONTROLE_DB_INSERT_1_Insert1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
                GE100_COD_IDLG = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG.ToString(),
                GE100_DTA_MOVIMENTO_LEGADO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_DTA_MOVIMENTO_LEGADO.ToString(),
            };

            R1300_INS_CONTROLE_DB_INSERT_1_Insert1.Execute(r1300_INS_CONTROLE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_EXIT*/

        [StopWatch]
        /*" R1400-INS-REGISTRO-SAP */
        private void R1400_INS_REGISTRO_SAP(bool isPerform = false)
        {
            /*" -1167- MOVE GE099-NUM-OCORR-MOVTO TO GE102-NUM-OCORR-MOVTO. */
            _.Move(GE099.DCLGE_MOVIMENTO_SAP.GE099_NUM_OCORR_MOVTO, GE102.DCLGE_ARQUIVO_SAP.GE102_NUM_OCORR_MOVTO);

            /*" -1169- MOVE GE100-COD-IDLG TO GE102-COD-IDLG. */
            _.Move(GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG, GE102.DCLGE_ARQUIVO_SAP.GE102_COD_IDLG);

            /*" -1172- MOVE LK-GE0300B-DATA-MOV-ABERTO TO GE102-DTH-MOVIMENTO. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_DATA_MOV_ABERTO, GE102.DCLGE_ARQUIVO_SAP.GE102_DTH_MOVIMENTO);

            /*" -1174- MOVE LK-GE0300B-REGISTRO(71:04) TO GE102-COD-ORIGEM. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO.Substring(71, 4), GE102.DCLGE_ARQUIVO_SAP.GE102_COD_ORIGEM);

            /*" -1176- MOVE LK-GE0300B-REGISTRO(75:24) TO GE102-NUM-LOTE-SAP. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO.Substring(75, 24), GE102.DCLGE_ARQUIVO_SAP.GE102_NUM_LOTE_SAP);

            /*" -1177- MOVE ZEROS TO GE102-TXT-REG-SAP-LEN. */
            _.Move(0, GE102.DCLGE_ARQUIVO_SAP.GE102_TXT_REG_SAP.GE102_TXT_REG_SAP_LEN);

            /*" -1180- MOVE ALL '@' TO GE102-TXT-REG-SAP-TEXT. */
            _.MoveAll("@", GE102.DCLGE_ARQUIVO_SAP.GE102_TXT_REG_SAP.GE102_TXT_REG_SAP_TEXT);

            /*" -1182- MOVE 4834 TO GE102-TXT-REG-SAP-LEN. */
            _.Move(4834, GE102.DCLGE_ARQUIVO_SAP.GE102_TXT_REG_SAP.GE102_TXT_REG_SAP_LEN);

            /*" -1184- INSPECT LK-GE0300B-REGISTRO CONVERTING LOW-VALUES TO ' ' . */
            REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO.Value = REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO.Value.Replace("\0", " ");

            /*" -1186- MOVE LK-GE0300B-REGISTRO TO GE102-TXT-REG-SAP-TEXT. */
            _.Move(REGISTRO_LINKAGE_GE0300B.LK_GE0300B_REGISTRO, GE102.DCLGE_ARQUIVO_SAP.GE102_TXT_REG_SAP.GE102_TXT_REG_SAP_TEXT);

            /*" -1189- MOVE '9999-12-31-01.01.01.010101' TO GE102-DTH-CADASTRAMENTO. */
            _.Move("9999-12-31-01.01.01.010101", GE102.DCLGE_ARQUIVO_SAP.GE102_DTH_CADASTRAMENTO);

            /*" -1205- PERFORM R1400_INS_REGISTRO_SAP_DB_INSERT_1 */

            R1400_INS_REGISTRO_SAP_DB_INSERT_1();

            /*" -1208- IF (SQLCODE NOT EQUAL 0) */

            if ((DB.SQLCODE != 0))
            {

                /*" -1209- DISPLAY 'GE102-NUM-OCORR-MOVTO  ' GE102-NUM-OCORR-MOVTO */
                _.Display($"GE102-NUM-OCORR-MOVTO  {GE102.DCLGE_ARQUIVO_SAP.GE102_NUM_OCORR_MOVTO}");

                /*" -1210- DISPLAY 'GE102-COD-IDLG ....... ' GE102-COD-IDLG */
                _.Display($"GE102-COD-IDLG ....... {GE102.DCLGE_ARQUIVO_SAP.GE102_COD_IDLG}");

                /*" -1211- MOVE '1' TO LK-GE0300B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_COD_RETORNO);

                /*" -1214- MOVE 'GE0300B - ERRO NO INSERT DA GE_ARQUIVO_SAP' TO LK-GE0300B-MENSAGEM-RETORNO */
                _.Move("GE0300B - ERRO NO INSERT DA GE_ARQUIVO_SAP", REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO);

                /*" -1214- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1400-INS-REGISTRO-SAP-DB-INSERT-1 */
        public void R1400_INS_REGISTRO_SAP_DB_INSERT_1()
        {
            /*" -1205- EXEC SQL INSERT INTO SEGUROS.GE_ARQUIVO_SAP ( NUM_OCORR_MOVTO , COD_IDLG , DTH_MOVIMENTO , DTH_CADASTRAMENTO, NUM_LOTE_SAP , TXT_REG_SAP , COD_ORIGEM ) VALUES (:GE102-NUM-OCORR-MOVTO , :GE102-COD-IDLG , :GE102-DTH-MOVIMENTO , :GE102-DTH-CADASTRAMENTO, :GE102-NUM-LOTE-SAP , :GE102-TXT-REG-SAP , :GE102-COD-ORIGEM ) END-EXEC. */

            var r1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1 = new R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1()
            {
                GE102_NUM_OCORR_MOVTO = GE102.DCLGE_ARQUIVO_SAP.GE102_NUM_OCORR_MOVTO.ToString(),
                GE102_COD_IDLG = GE102.DCLGE_ARQUIVO_SAP.GE102_COD_IDLG.ToString(),
                GE102_DTH_MOVIMENTO = GE102.DCLGE_ARQUIVO_SAP.GE102_DTH_MOVIMENTO.ToString(),
                GE102_DTH_CADASTRAMENTO = GE102.DCLGE_ARQUIVO_SAP.GE102_DTH_CADASTRAMENTO.ToString(),
                GE102_NUM_LOTE_SAP = GE102.DCLGE_ARQUIVO_SAP.GE102_NUM_LOTE_SAP.ToString(),
                GE102_TXT_REG_SAP = GE102.DCLGE_ARQUIVO_SAP.GE102_TXT_REG_SAP.ToString(),
                GE102_COD_ORIGEM = GE102.DCLGE_ARQUIVO_SAP.GE102_COD_ORIGEM.ToString(),
            };

            R1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1.Execute(r1400_INS_REGISTRO_SAP_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_EXIT*/

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO */
        private void RXXXX_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -1220- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -1229- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -1230- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -1231- DISPLAY '*            SUB-ROTINA GE0300B                  *' */
            _.Display($"*            SUB-ROTINA GE0300B                  *");

            /*" -1232- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -1233- DISPLAY '*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *' */
            _.Display($"*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *");

            /*" -1234- DISPLAY '*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *' */
            _.Display($"*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *");

            /*" -1235- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -1236- DISPLAY '*  CONDICAO ANORMAL DE BANCO                     *' */
            _.Display($"*  CONDICAO ANORMAL DE BANCO                     *");

            /*" -1237- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -1239- DISPLAY '=> ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO' LK-GE0300B-MENSAGEM-RETORNO */
            _.Display($"=> ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO{REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_MENSAGEM_RETORNO}");

            /*" -1240- MOVE SQLCODE TO WSQLCODE LK-GE0300B-SQLCODE */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_SQLCODE);

            /*" -1241- DISPLAY '=> SQLCODE ' LK-GE0300B-SQLCODE. */
            _.Display($"=> SQLCODE {REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_SQLCODE}");

            /*" -1243- DISPLAY '=> FEITO ROLLBACK' */
            _.Display($"=> FEITO ROLLBACK");

            /*" -1245- MOVE SQLCODE TO WSQLCODE LK-GE0300B-SQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE, REGISTRO_LINKAGE_GE0300B.LK_GE0300B_MENSAGEM.LK_GE0300B_SQLCODE);

            /*" -1246- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1248- DISPLAY 'SQLERRMC - ' SQLERRMC */
            _.Display($"SQLERRMC - {DB.SQLERRMC}");

            /*" -1248- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1252- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1252- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}