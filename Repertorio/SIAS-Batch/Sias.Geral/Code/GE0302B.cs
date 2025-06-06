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
using Sias.Geral.DB2.GE0302B;

namespace Code
{
    public class GE0302B
    {
        public bool IsCall { get; set; }

        public GE0302B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  GE0302B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JULHO / 2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   SUB-ROTINA DE RECUPERACAO DO CAMPO USO-EMPRESA REGISTRADO    *      */
        /*"      *   NA TABELA GE_FEBRABAN_USO_EMPRESA                            *      */
        /*"      *                                                                *      */
        /*"      * CADMUS - 49.363                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * 05/07/2013 - RILDO - CAD 84045                                 *      */
        /*"      *              AJUSTE NA CONSULTA DO IDLG                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * 24/01/2011 - RETIRAR O DISPLAY DO IDLG INFORMADO               *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * 07/01/2011 - COLOCADO O "FIRST ONLY"                           *      */
        /*"      *                                                                *      */
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
        public GE0302B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GE0302B_AREA_DE_WORK();
        public class GE0302B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05 W-IDLG-SIAS-SINISTRO.*/
            public GE0302B_W_IDLG_SIAS_SINISTRO W_IDLG_SIAS_SINISTRO { get; set; } = new GE0302B_W_IDLG_SIAS_SINISTRO();
            public class GE0302B_W_IDLG_SIAS_SINISTRO : VarBasis
            {
                /*"    10 W-IDLG-SINISTRO               PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 W-IDLG-NUM-APOL-SINISTRO      PIC 9(13) VALUE 0.*/
                public IntBasis W_IDLG_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
                /*"    10 W-IDLG-FILLER-1               PIC X(01) VALUE '|'.*/
                public StringBasis W_IDLG_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-OCORR-HISTORICO        PIC 9(05) VALUE 0.*/
                public IntBasis W_IDLG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)"));
                /*"    10 W-IDLG-FILLER-2               PIC X(01) VALUE '|'.*/
                public StringBasis W_IDLG_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-COD-OPERACAO           PIC 9(04) VALUE 0.*/
                public IntBasis W_IDLG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"    10 W-IDLG-FILLER-3               PIC X(01) VALUE '|'.*/
                public StringBasis W_IDLG_FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-TIPO-MOVIMENTO         PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 W-IDLG-FILLER-4               PIC X(01) VALUE '|'.*/
                public StringBasis W_IDLG_FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-FORMA-PAGAMENTO        PIC X(01) VALUE ' '.*/
                public StringBasis W_IDLG_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
                /*"    10 W-IDLG-FILLER-5               PIC X(01) VALUE '|'.*/
                public StringBasis W_IDLG_FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"|");
                /*"    10 W-IDLG-COMPLEMENTO            PIC X(10).*/
                public StringBasis W_IDLG_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"    10 W-IDLG-COMPLEMENTO-1   REDEFINES  W-IDLG-COMPLEMENTO.*/
                private _REDEF_GE0302B_W_IDLG_COMPLEMENTO_1 _w_idlg_complemento_1 { get; set; }
                public _REDEF_GE0302B_W_IDLG_COMPLEMENTO_1 W_IDLG_COMPLEMENTO_1
                {
                    get { _w_idlg_complemento_1 = new _REDEF_GE0302B_W_IDLG_COMPLEMENTO_1(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); _w_idlg_complemento_1.ValueChanged += () => { _.Move(_w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_1; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_1, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_GE0302B_W_IDLG_COMPLEMENTO_1 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-CHEQUE-INTERNO  PIC 9(10).*/
                    public IntBasis W_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-2   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_GE0302B_W_IDLG_COMPLEMENTO_1()
                    {
                        W_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_GE0302B_W_IDLG_COMPLEMENTO_2 _w_idlg_complemento_2 { get; set; }
                public _REDEF_GE0302B_W_IDLG_COMPLEMENTO_2 W_IDLG_COMPLEMENTO_2
                {
                    get { _w_idlg_complemento_2 = new _REDEF_GE0302B_W_IDLG_COMPLEMENTO_2(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); _w_idlg_complemento_2.ValueChanged += () => { _.Move(_w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_2; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_2, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_GE0302B_W_IDLG_COMPLEMENTO_2 : VarBasis
                {
                    /*"       15 W-IDLG-NSAS                PIC 9(10).*/
                    public IntBasis W_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                    /*"    10 W-IDLG-COMPLEMENTO-3   REDEFINES  W-IDLG-COMPLEMENTO.*/

                    public _REDEF_GE0302B_W_IDLG_COMPLEMENTO_2()
                    {
                        W_IDLG_NSAS.ValueChanged += OnValueChanged;
                    }

                }
                private _REDEF_GE0302B_W_IDLG_COMPLEMENTO_3 _w_idlg_complemento_3 { get; set; }
                public _REDEF_GE0302B_W_IDLG_COMPLEMENTO_3 W_IDLG_COMPLEMENTO_3
                {
                    get { _w_idlg_complemento_3 = new _REDEF_GE0302B_W_IDLG_COMPLEMENTO_3(); _.Move(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3); VarBasis.RedefinePassValue(W_IDLG_COMPLEMENTO, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); _w_idlg_complemento_3.ValueChanged += () => { _.Move(_w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }; return _w_idlg_complemento_3; }
                    set { VarBasis.RedefinePassValue(value, _w_idlg_complemento_3, W_IDLG_COMPLEMENTO); }
                }  //Redefines
                public class _REDEF_GE0302B_W_IDLG_COMPLEMENTO_3 : VarBasis
                {
                    /*"       15 W-IDLG-NUM-ACORDO          PIC 9(05).*/
                    public IntBasis W_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       15 FILLER                     PIC X(01).*/
                    public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       15 W-IDLG-NUM-PARCELA         PIC 9(04).*/
                    public IntBasis W_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"  05 W-LOTE-NUM-SEQUENCIA            PIC 9(09) VALUE 0.*/

                    public _REDEF_GE0302B_W_IDLG_COMPLEMENTO_3()
                    {
                        W_IDLG_NUM_ACORDO.ValueChanged += OnValueChanged;
                        FILLER_0.ValueChanged += OnValueChanged;
                        W_IDLG_NUM_PARCELA.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis W_LOTE_NUM_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"  05       WSTATUS               PIC  9(002)     VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05 W-LOTE.*/
            public GE0302B_W_LOTE W_LOTE { get; set; } = new GE0302B_W_LOTE();
            public class GE0302B_W_LOTE : VarBasis
            {
                /*"    10 W-LOTE-NOME-PROGRAMA          PIC X(08) VALUE 'GE0302B'.*/
                public StringBasis W_LOTE_NOME_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"GE0302B");
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
            public GE0302B_W_DATA_AAAAMMDD W_DATA_AAAAMMDD { get; set; } = new GE0302B_W_DATA_AAAAMMDD();
            public class GE0302B_W_DATA_AAAAMMDD : VarBasis
            {
                /*"     10 W-DATA-AAAAMMDD-AAAA         PIC 9(04) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"     10 W-DATA-AAAAMMDD-MM           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"     10 W-DATA-AAAAMMDD-DD           PIC 9(02) VALUE ZEROS.*/
                public IntBasis W_DATA_AAAAMMDD_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(02)"));
                /*"  05         WHORA-CURR.*/
            }
            public GE0302B_WHORA_CURR WHORA_CURR { get; set; } = new GE0302B_WHORA_CURR();
            public class GE0302B_WHORA_CURR : VarBasis
            {
                /*"    10       WHORA-HH-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-MM-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       WHORA-SS-CURR     PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WHORAS.*/
            }
            public GE0302B_WHORAS WHORAS { get; set; } = new GE0302B_WHORAS();
            public class GE0302B_WHORAS : VarBasis
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
            private _REDEF_GE0302B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_GE0302B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_GE0302B_FILLER_1(); _.Move(WMONTA_DATA, _filler_1); VarBasis.RedefinePassValue(WMONTA_DATA, _filler_1, WMONTA_DATA); _filler_1.ValueChanged += () => { _.Move(_filler_1, WMONTA_DATA); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WMONTA_DATA); }
            }  //Redefines
            public class _REDEF_GE0302B_FILLER_1 : VarBasis
            {
                /*"    10       WDATA-DIA         PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-MES         PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WDATA-ANO         PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05  W-EDICAO                 PIC Z.ZZ9.*/

                public _REDEF_GE0302B_FILLER_1()
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
        public GE0302B_WABEND WABEND { get; set; } = new GE0302B_WABEND();
        public class GE0302B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' GE0302B'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GE0302B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  REGISTRO-LINKAGE-GE0302B.*/
        }
        public GE0302B_REGISTRO_LINKAGE_GE0302B REGISTRO_LINKAGE_GE0302B { get; set; } = new GE0302B_REGISTRO_LINKAGE_GE0302B();
        public class GE0302B_REGISTRO_LINKAGE_GE0302B : VarBasis
        {
            /*"    05 LK-GE0302B-IDLG                    PIC  X(40).*/
            public StringBasis LK_GE0302B_IDLG { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0302B-ACHOU-USO-EMPRESA       PIC  X(03).*/
            public StringBasis LK_GE0302B_ACHOU_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-GE0302B-EH-SINISTRO             PIC  X(03).*/
            public StringBasis LK_GE0302B_EH_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"    05 LK-GE0302B-CHR-USO-EMPRESA         PIC  X(200).*/
            public StringBasis LK_GE0302B_CHR_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
            /*"    05 LK-GE0302B-SICOV-IDENT-CLIENTE     PIC  X(25).*/
            public StringBasis LK_GE0302B_SICOV_IDENT_CLIENTE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"    05 LK-GE0302B-SICOV-USO-EMPRESA       PIC  X(60).*/
            public StringBasis LK_GE0302B_SICOV_USO_EMPRESA { get; set; } = new StringBasis(new PIC("X", "60", "X(60)."), @"");
            /*"    05 LK-GE0302B-SIACC                   PIC  X(40).*/
            public StringBasis LK_GE0302B_SIACC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05 LK-GE0302B-COD-RETORNO             PIC  X(01).*/
            public StringBasis LK_GE0302B_COD_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05 LK-GE0302B-MENSAGEM.*/
            public GE0302B_LK_GE0302B_MENSAGEM LK_GE0302B_MENSAGEM { get; set; } = new GE0302B_LK_GE0302B_MENSAGEM();
            public class GE0302B_LK_GE0302B_MENSAGEM : VarBasis
            {
                /*"       10 LK-GE0302B-SQLCODE              PIC   -ZZ9.*/
                public IntBasis LK_GE0302B_SQLCODE { get; set; } = new IntBasis(new PIC("9", "3", "-ZZ9."));
                /*"       10 FILLER                          PIC  X(01).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"       10 LK-GE0302B-MENSAGEM-RETORNO     PIC  X(75).*/
                public StringBasis LK_GE0302B_MENSAGEM_RETORNO { get; set; } = new StringBasis(new PIC("X", "75", "X(75)."), @"");
            }
        }


        public Dclgens.GE096 GE096 { get; set; } = new Dclgens.GE096();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
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
        public dynamic Execute(GE0302B_REGISTRO_LINKAGE_GE0302B GE0302B_REGISTRO_LINKAGE_GE0302B_P) //PROCEDURE DIVISION USING 
        /*REGISTRO_LINKAGE_GE0302B*/
        {
            try
            {
                this.REGISTRO_LINKAGE_GE0302B = GE0302B_REGISTRO_LINKAGE_GE0302B_P;

                /*" -311- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -313- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -315- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -337- MOVE SPACES TO LK-GE0302B-ACHOU-USO-EMPRESA LK-GE0302B-EH-SINISTRO LK-GE0302B-CHR-USO-EMPRESA LK-GE0302B-SICOV-IDENT-CLIENTE LK-GE0302B-SICOV-USO-EMPRESA LK-GE0302B-SIACC LK-GE0302B-COD-RETORNO LK-GE0302B-MENSAGEM-RETORNO . */
                _.Move("", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_CHR_USO_EMPRESA, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_IDENT_CLIENTE, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_USO_EMPRESA, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SIACC, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                /*" -342- INITIALIZE DCLGE-CONTROLE-INTERF-SAP DCLGE-FEBRABAN-USO-EMPRESA . */
                _.Initialize(
                    GE100.DCLGE_CONTROLE_INTERF_SAP
                    , GE113.DCLGE_FEBRABAN_USO_EMPRESA
                );

                /*" -343- MOVE '0' TO LK-GE0302B-COD-RETORNO */
                _.Move("0", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                /*" -345- MOVE 'EXECUCAO COM SUCESSO' TO LK-GE0302B-MENSAGEM-RETORNO. */
                _.Move("EXECUCAO COM SUCESSO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                /*" -347- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -348- IF LK-GE0302B-IDLG EQUAL SPACES */

                if (REGISTRO_LINKAGE_GE0302B.LK_GE0302B_IDLG.IsEmpty())
                {

                    /*" -349- MOVE '1' TO LK-GE0302B-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                    /*" -352- MOVE 'GE0302B - IDLG NAO INFORMADO' TO LK-GE0302B-MENSAGEM-RETORNO */
                    _.Move("GE0302B - IDLG NAO INFORMADO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                    /*" -356- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -358- MOVE LK-GE0302B-IDLG TO GE100-COD-IDLG. */
                _.Move(REGISTRO_LINKAGE_GE0302B.LK_GE0302B_IDLG, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG);

                /*" -387- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -390- IF SQLCODE EQUAL -811 */

                if (DB.SQLCODE == -811)
                {

                    /*" -391- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -392- DISPLAY '* PROGRAMA GE0302B - BUSCA DO "USO EMPRESA" *' */

                    $"* PROGRAMA GE0302B - BUSCA DO USOEMPRESA *"
                    .Display();

                    /*" -393- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -394- DISPLAY '* FIM ANORMAL. ERRO DE REGRA DE NEGOCIO.       *' */
                    _.Display($"* FIM ANORMAL. ERRO DE REGRA DE NEGOCIO.       *");

                    /*" -395- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -396- DISPLAY '* POR DETERMINACAO DO FERNANCO GONCALVES       *' */
                    _.Display($"* POR DETERMINACAO DO FERNANCO GONCALVES       *");

                    /*" -397- DISPLAY '* SE NA TABELA GE_CONTROLE_INTERF_SAP EXISTIR  *' */
                    _.Display($"* SE NA TABELA GE_CONTROLE_INTERF_SAP EXISTIR  *");

                    /*" -398- DISPLAY '* MAIS DE UMA LINHA COM O MESMO IDLG, DEVERA   *' */
                    _.Display($"* MAIS DE UMA LINHA COM O MESMO IDLG, DEVERA   *");

                    /*" -399- DISPLAY '* SER CONSIDERADO UMA CONDICAO DE ERRO.        *' */
                    _.Display($"* SER CONSIDERADO UMA CONDICAO DE ERRO.        *");

                    /*" -400- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -401- DISPLAY '* PROCURAR: FERNANDO, HEIDER, ROMINA           *' */
                    _.Display($"* PROCURAR: FERNANDO, HEIDER, ROMINA           *");

                    /*" -402- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -403- DISPLAY '* TABELA => GE_CONTROLE_INTERF_SAP ' */
                    _.Display($"* TABELA => GE_CONTROLE_INTERF_SAP ");

                    /*" -404- DISPLAY '* GE100-COD-IDLG => ' GE100-COD-IDLG */
                    _.Display($"* GE100-COD-IDLG => {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                    /*" -405- DISPLAY '*                                              *' */
                    _.Display($"*                                              *");

                    /*" -406- DISPLAY '************************************************' */
                    _.Display($"************************************************");

                    /*" -407- DISPLAY '* IDLG INFORMADO - ' GE100-COD-IDLG */
                    _.Display($"* IDLG INFORMADO - {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                    /*" -408- MOVE '1' TO LK-GE0302B-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                    /*" -411- MOVE 'GE0302B - MAIS DE UMA LINHA PARA O MESMO IDLG' TO LK-GE0302B-MENSAGEM-RETORNO */
                    _.Move("GE0302B - MAIS DE UMA LINHA PARA O MESMO IDLG", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                    /*" -413- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -414- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
                {

                    /*" -416- DISPLAY 'ERRO ACESSO A GE_CONTROLE_INTERF_SAP ' */
                    _.Display($"ERRO ACESSO A GE_CONTROLE_INTERF_SAP ");

                    /*" -418- DISPLAY 'GE100-COD-IDLG.................' GE100-COD-IDLG */
                    _.Display($"GE100-COD-IDLG.................{GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                    /*" -419- MOVE '1' TO LK-GE0302B-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                    /*" -422- MOVE 'GE0302B - ERRO ACESSO A GE_CONTROLE_INTERF_SAP ' TO LK-GE0302B-MENSAGEM-RETORNO */
                    _.Move("GE0302B - ERRO ACESSO A GE_CONTROLE_INTERF_SAP ", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                    /*" -427- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -428- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -429- MOVE 'NAO' TO LK-GE0302B-ACHOU-USO-EMPRESA */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA);

                    /*" -433- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -438- PERFORM Execute_DB_SELECT_2 */

                Execute_DB_SELECT_2();

                /*" -441- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
                {

                    /*" -443- DISPLAY 'ERRO ACESSO A GE_FEBRABAN_USO_EMPRESA' */
                    _.Display($"ERRO ACESSO A GE_FEBRABAN_USO_EMPRESA");

                    /*" -445- DISPLAY 'GE100-COD-IDLG................ ' GE100-COD-IDLG */
                    _.Display($"GE100-COD-IDLG................ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                    /*" -447- DISPLAY 'GE100-NUM-OCORR-MOVTO......... ' GE100-NUM-OCORR-MOVTO */
                    _.Display($"GE100-NUM-OCORR-MOVTO......... {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                    /*" -448- MOVE '1' TO LK-GE0302B-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                    /*" -451- MOVE 'GE0302B - ERRO ACESSO A GE_FEBRABAN_USO_EMPRESA' TO LK-GE0302B-MENSAGEM-RETORNO */
                    _.Move("GE0302B - ERRO ACESSO A GE_FEBRABAN_USO_EMPRESA", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                    /*" -453- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -454- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -455- MOVE 'NAO' TO LK-GE0302B-ACHOU-USO-EMPRESA */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA);

                    /*" -457- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -458- MOVE 'SIM' TO LK-GE0302B-ACHOU-USO-EMPRESA */
                _.Move("SIM", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA);

                /*" -462- MOVE GE113-CHR-USO-EMPRESA TO LK-GE0302B-CHR-USO-EMPRESA. */
                _.Move(GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_CHR_USO_EMPRESA);

                /*" -464- MOVE GE100-COD-IDLG TO W-IDLG-SIAS-SINISTRO */
                _.Move(GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG, AREA_DE_WORK.W_IDLG_SIAS_SINISTRO);

                /*" -470- IF (W-IDLG-SINISTRO NOT EQUAL 'S' ) OR (W-IDLG-FILLER-1 NOT EQUAL '|' ) OR (W-IDLG-FILLER-2 NOT EQUAL '|' ) OR (W-IDLG-FILLER-3 NOT EQUAL '|' ) OR (W-IDLG-FILLER-4 NOT EQUAL '|' ) OR (W-IDLG-FILLER-5 NOT EQUAL '|' ) */

                if ((AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_SINISTRO != "S") || (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FILLER_1 != "|") || (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FILLER_2 != "|") || (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FILLER_3 != "|") || (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FILLER_4 != "|") || (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FILLER_5 != "|"))
                {

                    /*" -471- MOVE 'NAO' TO LK-GE0302B-EH-SINISTRO */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO);

                    /*" -475- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -477- IF (W-IDLG-TIPO-MOVIMENTO NOT EQUAL 'P' ) AND (W-IDLG-TIPO-MOVIMENTO NOT EQUAL 'R' ) */

                if ((AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO != "P") && (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_TIPO_MOVIMENTO != "R"))
                {

                    /*" -478- MOVE 'NAO' TO LK-GE0302B-EH-SINISTRO */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO);

                    /*" -482- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -485- IF (W-IDLG-FORMA-PAGAMENTO NOT EQUAL 1) AND (W-IDLG-FORMA-PAGAMENTO NOT EQUAL 2) AND (W-IDLG-FORMA-PAGAMENTO NOT EQUAL 3) */

                if ((AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO != 1) && (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO != 2) && (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO != 3))
                {

                    /*" -486- MOVE 'NAO' TO LK-GE0302B-EH-SINISTRO */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO);

                    /*" -490- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -491- IF W-IDLG-FORMA-PAGAMENTO EQUAL 1 OR 3 */

                if (AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_FORMA_PAGAMENTO.In("1", "3"))
                {

                    /*" -492- MOVE 'NAO' TO LK-GE0302B-ACHOU-USO-EMPRESA */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA);

                    /*" -494- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -501- IF (W-IDLG-NUM-APOL-SINISTRO NOT NUMERIC) OR (W-IDLG-OCORR-HISTORICO NOT NUMERIC) OR (W-IDLG-COD-OPERACAO NOT NUMERIC) OR (W-IDLG-NUM-CHEQUE-INTERNO NOT NUMERIC) OR (W-IDLG-NSAS NOT NUMERIC) OR (W-IDLG-NUM-ACORDO NOT NUMERIC) OR (W-IDLG-NUM-PARCELA NOT NUMERIC) */

                if ((!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_NUM_APOL_SINISTRO.IsNumeric()) || (!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_OCORR_HISTORICO.IsNumeric()) || (!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COD_OPERACAO.IsNumeric()) || (!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_1.W_IDLG_NUM_CHEQUE_INTERNO.IsNumeric()) || (!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_2.W_IDLG_NSAS.IsNumeric()) || (!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_3.W_IDLG_NUM_ACORDO.IsNumeric()) || (!AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COMPLEMENTO_3.W_IDLG_NUM_PARCELA.IsNumeric()))
                {

                    /*" -502- MOVE 'NAO' TO LK-GE0302B-EH-SINISTRO */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO);

                    /*" -504- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -506- MOVE W-IDLG-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO. */
                _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);

                /*" -508- MOVE W-IDLG-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO. */
                _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);

                /*" -511- MOVE W-IDLG-COD-OPERACAO TO SINISHIS-COD-OPERACAO. */
                _.Move(AREA_DE_WORK.W_IDLG_SIAS_SINISTRO.W_IDLG_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);

                /*" -525- PERFORM Execute_DB_SELECT_3 */

                Execute_DB_SELECT_3();

                /*" -528- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
                {

                    /*" -530- DISPLAY 'ERRO ACESSO A SINISTRO_HISTORICO' */
                    _.Display($"ERRO ACESSO A SINISTRO_HISTORICO");

                    /*" -532- DISPLAY 'GE100-COD-IDLG................ ' GE100-COD-IDLG */
                    _.Display($"GE100-COD-IDLG................ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                    /*" -534- DISPLAY 'GE100-NUM-OCORR-MOVTO......... ' GE100-NUM-OCORR-MOVTO */
                    _.Display($"GE100-NUM-OCORR-MOVTO......... {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                    /*" -535- MOVE SQLCODE TO LK-GE0302B-SQLCODE */
                    _.Move(DB.SQLCODE, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_SQLCODE);

                    /*" -536- DISPLAY 'SQLCODE ....... ' LK-GE0302B-SQLCODE */
                    _.Display($"SQLCODE ....... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_SQLCODE}");

                    /*" -537- DISPLAY 'NUM_APOL_SINISTRO = ' SINISHIS-NUM-APOL-SINISTRO */
                    _.Display($"NUM_APOL_SINISTRO = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO}");

                    /*" -538- DISPLAY 'OCORR_HISTORICO   = ' SINISHIS-OCORR-HISTORICO */
                    _.Display($"OCORR_HISTORICO   = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO}");

                    /*" -539- DISPLAY 'COD_OPERACAO      = ' SINISHIS-COD-OPERACAO */
                    _.Display($"COD_OPERACAO      = {SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO}");

                    /*" -540- MOVE '1' TO LK-GE0302B-COD-RETORNO */
                    _.Move("1", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                    /*" -543- MOVE 'GE0302B - ERRO ACESSO A SINISTRO_HISTORICO' TO LK-GE0302B-MENSAGEM-RETORNO */
                    _.Move("GE0302B - ERRO ACESSO A SINISTRO_HISTORICO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                    /*" -545- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -546- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -547- MOVE 'NAO' TO LK-GE0302B-EH-SINISTRO */
                    _.Move("NAO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO);

                    /*" -553- GO TO RXXXX-ROTINA-RETORNO. */

                    RXXXX_ROTINA_RETORNO(); //GOTO
                    return Result;
                }


                /*" -561- GO TO RXYZ-PULA-SINICHEQ. */

                RXYZ_PULA_SINICHEQ(); //GOTO
                return Result;

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { REGISTRO_LINKAGE_GE0302B, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -387- EXEC SQL SELECT NUM_OCORR_MOVTO INTO :GE100-NUM-OCORR-MOVTO FROM SEGUROS.GE_CONTROLE_INTERF_SAP A WHERE COD_IDLG = :GE100-COD-IDLG AND DTA_MOVIMENTO_LEGADO <> '9999-12-31' AND ( EXISTS (SELECT 1 FROM SEGUROS.GE_MOVDEBCE_SAP B WHERE B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_CHEQUE_SAP C WHERE C.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_BOLETO_RESSARC_SINI D WHERE D.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_VIDA_SAP E WHERE E.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_BOLETO_EMISSAO F WHERE F.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) ) ORDER BY DTA_MOVIMENTO_LEGADO DESC FETCH FIRST 1 ROWS ONLY END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
                GE100_COD_IDLG = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE100_NUM_OCORR_MOVTO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO);
            }


        }

        [StopWatch]
        /*" RXYZ-PULA-SINICHEQ */
        private void RXYZ_PULA_SINICHEQ(bool isPerform = false)
        {
            /*" -600- PERFORM RXYZ_PULA_SINICHEQ_DB_SELECT_1 */

            RXYZ_PULA_SINICHEQ_DB_SELECT_1();

            /*" -603- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -605- DISPLAY 'ERRO ACESSO A GE_MOVDEBCE_SAP' */
                _.Display($"ERRO ACESSO A GE_MOVDEBCE_SAP");

                /*" -607- DISPLAY 'GE100-COD-IDLG................ ' GE100-COD-IDLG */
                _.Display($"GE100-COD-IDLG................ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -609- DISPLAY 'GE100-NUM-OCORR-MOVTO......... ' GE100-NUM-OCORR-MOVTO */
                _.Display($"GE100-NUM-OCORR-MOVTO......... {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -610- MOVE '1' TO LK-GE0302B-COD-RETORNO */
                _.Move("1", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

                /*" -613- MOVE 'GE0302B - ERRO ACESSO A GE_MOVDEBCE_SAP' TO LK-GE0302B-MENSAGEM-RETORNO */
                _.Move("GE0302B - ERRO ACESSO A GE_MOVDEBCE_SAP", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO);

                /*" -615- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -618- IF GE094-COD-CONVENIO EQUAL 600128 OR 600119 OR 600120 OR 600123 OR 43350 OR 921286 */

            if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO.In("600128", "600119", "600120", "600123", "43350", "921286"))
            {

                /*" -619- MOVE 'SIM' TO LK-GE0302B-EH-SINISTRO */
                _.Move("SIM", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO);

                /*" -620- ELSE */
            }
            else
            {


                /*" -622- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -624- IF GE094-COD-CONVENIO EQUAL 600128 OR 600119 OR 600120 OR 600123 */

            if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO.In("600128", "600119", "600120", "600123"))
            {

                /*" -626- MOVE GE113-CHR-USO-EMPRESA(42:25) TO LK-GE0302B-SICOV-IDENT-CLIENTE */
                _.Move(GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA.Substring(42, 25), REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_IDENT_CLIENTE);

                /*" -628- MOVE GE113-CHR-USO-EMPRESA(109:60) TO LK-GE0302B-SICOV-USO-EMPRESA */
                _.Move(GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA.Substring(109, 60), REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_USO_EMPRESA);

                /*" -630- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -631- IF GE094-COD-CONVENIO EQUAL 43350 */

            if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO == 43350)
            {

                /*" -633- MOVE GE113-CHR-USO-EMPRESA(61:40) TO LK-GE0302B-SIACC */
                _.Move(GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA.Substring(61, 40), REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SIACC);

                /*" -635- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -636- IF GE094-COD-CONVENIO EQUAL 921286 */

            if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO == 921286)
            {

                /*" -638- MOVE GE113-CHR-USO-EMPRESA(57:20) TO LK-GE0302B-SIACC */
                _.Move(GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA.Substring(57, 20), REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SIACC);

                /*" -640- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -641- MOVE '0' TO LK-GE0302B-COD-RETORNO */
            _.Move("0", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO);

            /*" -643- MOVE 'EXECUCAO COM SUCESSO' TO LK-GE0302B-MENSAGEM. */
            _.Move("EXECUCAO COM SUCESSO", REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM);

            /*" -643- GOBACK. */

            throw new GoBack();

        }

        [StopWatch]
        /*" RXYZ-PULA-SINICHEQ-DB-SELECT-1 */
        public void RXYZ_PULA_SINICHEQ_DB_SELECT_1()
        {
            /*" -600- EXEC SQL SELECT COD_CONVENIO INTO :GE094-COD-CONVENIO FROM SEGUROS.GE_MOVDEBCE_SAP WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO END-EXEC. */

            var rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 = new RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1.Execute(rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE094_COD_CONVENIO, GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO);
            }


        }

        [StopWatch]
        /*" Execute-DB-SELECT-2 */
        public void Execute_DB_SELECT_2()
        {
            /*" -438- EXEC SQL SELECT CHR_USO_EMPRESA INTO :GE113-CHR-USO-EMPRESA FROM SEGUROS.GE_FEBRABAN_USO_EMPRESA WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO END-EXEC. */

            var execute_DB_SELECT_2_Query1 = new Execute_DB_SELECT_2_Query1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_2_Query1.Execute(execute_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE113_CHR_USO_EMPRESA, GE113.DCLGE_FEBRABAN_USO_EMPRESA.GE113_CHR_USO_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" Execute-DB-SELECT-3 */
        public void Execute_DB_SELECT_3()
        {
            /*" -525- EXEC SQL SELECT NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , VAL_OPERACAO INTO :SINISHIS-NUM-APOL-SINISTRO , :SINISHIS-OCORR-HISTORICO , :SINISHIS-COD-OPERACAO , :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var execute_DB_SELECT_3_Query1 = new Execute_DB_SELECT_3_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_3_Query1.Execute(execute_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -663- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -666- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -667- DISPLAY 'GE0302B - ERRO NO ACESSO SISTEMAS - FI' */
                _.Display($"GE0302B - ERRO NO ACESSO SISTEMAS - FI");

                /*" -667- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -663- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE, CURRENT TIMESTAMP, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-CURRENT-DATE, :HOST-TIMESTAMP, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'FI' WITH UR END-EXEC. */

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

        [StopWatch]
        /*" Execute-DB-SELECT-4 */
        public void Execute_DB_SELECT_4()
        {
            /*" -572- EXEC SQL SELECT NUM_APOL_SINISTRO INTO :SINISHIS-NUM-APOL-SINISTRO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var execute_DB_SELECT_4_Query1 = new Execute_DB_SELECT_4_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = Execute_DB_SELECT_4_Query1.Execute(execute_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO */
        private void RXXXX_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -674- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/

        [StopWatch]
        /*" RYYYY-DISPLAY-RETORNO */
        private void RYYYY_DISPLAY_RETORNO(bool isPerform = false)
        {
            /*" -680- DISPLAY '*' */
            _.Display($"*");

            /*" -681- DISPLAY '* ==> CAMPOS DE RETORNO' */
            _.Display($"* ==> CAMPOS DE RETORNO");

            /*" -682- DISPLAY '*' */
            _.Display($"*");

            /*" -684- DISPLAY 'LK-GE0302B-IDLG ...... ' LK-GE0302B-IDLG */
            _.Display($"LK-GE0302B-IDLG ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_IDLG}");

            /*" -686- DISPLAY 'LK-GE0302B-ACHOU-USO-EMPRESA  ...... ' LK-GE0302B-ACHOU-USO-EMPRESA */
            _.Display($"LK-GE0302B-ACHOU-USO-EMPRESA  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_ACHOU_USO_EMPRESA}");

            /*" -688- DISPLAY 'LK-GE0302B-EH-SINISTRO  ...... ' LK-GE0302B-EH-SINISTRO */
            _.Display($"LK-GE0302B-EH-SINISTRO  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_EH_SINISTRO}");

            /*" -690- DISPLAY 'LK-GE0302B-CHR-USO-EMPRESA  ...... ' LK-GE0302B-CHR-USO-EMPRESA */
            _.Display($"LK-GE0302B-CHR-USO-EMPRESA  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_CHR_USO_EMPRESA}");

            /*" -692- DISPLAY 'LK-GE0302B-SICOV-IDENT-CLIENTE ...... ' LK-GE0302B-SICOV-IDENT-CLIENTE */
            _.Display($"LK-GE0302B-SICOV-IDENT-CLIENTE ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_IDENT_CLIENTE}");

            /*" -694- DISPLAY 'LK-GE0302B-SICOV-USO-EMPRESA  ...... ' LK-GE0302B-SICOV-USO-EMPRESA */
            _.Display($"LK-GE0302B-SICOV-USO-EMPRESA  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SICOV_USO_EMPRESA}");

            /*" -696- DISPLAY 'LK-GE0302B-SIACC  ...... ' LK-GE0302B-SIACC */
            _.Display($"LK-GE0302B-SIACC  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_SIACC}");

            /*" -698- DISPLAY 'LK-GE0302B-COD-RETORNO  ...... ' LK-GE0302B-COD-RETORNO */
            _.Display($"LK-GE0302B-COD-RETORNO  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_COD_RETORNO}");

            /*" -700- DISPLAY 'LK-GE0302B-MENSAGEM  ...... ' LK-GE0302B-MENSAGEM */
            _.Display($"LK-GE0302B-MENSAGEM  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM}");

            /*" -702- DISPLAY 'LK-GE0302B-SQLCODE  ...... ' LK-GE0302B-SQLCODE */
            _.Display($"LK-GE0302B-SQLCODE  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_SQLCODE}");

            /*" -703- DISPLAY 'LK-GE0302B-MENSAGEM-RETORNO  ...... ' LK-GE0302B-MENSAGEM-RETORNO . */
            _.Display($"LK-GE0302B-MENSAGEM-RETORNO  ...... {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RYYYY_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -712- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -713- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -714- DISPLAY '*            SUB-ROTINA GE0302B                  *' */
            _.Display($"*            SUB-ROTINA GE0302B                  *");

            /*" -715- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -716- DISPLAY '*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *' */
            _.Display($"*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *");

            /*" -717- DISPLAY '*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *' */
            _.Display($"*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *");

            /*" -718- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -719- DISPLAY '*  CONDICAO ANORMAL DE BANCO                     *' */
            _.Display($"*  CONDICAO ANORMAL DE BANCO                     *");

            /*" -720- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -722- DISPLAY '=> ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO' LK-GE0302B-MENSAGEM-RETORNO */
            _.Display($"=> ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO{REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_MENSAGEM_RETORNO}");

            /*" -723- DISPLAY '=> SQLCODE ' LK-GE0302B-SQLCODE. */
            _.Display($"=> SQLCODE {REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_SQLCODE}");

            /*" -725- DISPLAY '=> FEITO ROLLBACK' */
            _.Display($"=> FEITO ROLLBACK");

            /*" -727- MOVE SQLCODE TO WSQLCODE LK-GE0302B-SQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE, REGISTRO_LINKAGE_GE0302B.LK_GE0302B_MENSAGEM.LK_GE0302B_SQLCODE);

            /*" -728- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -730- DISPLAY 'SQLERRMC - ' SQLERRMC */
            _.Display($"SQLERRMC - {DB.SQLERRMC}");

            /*" -730- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -734- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -734- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/
    }
}