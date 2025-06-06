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
using Sias.Sinistro.DB2.SISAP03B;

namespace Code
{
    public class SISAP03B
    {
        public bool IsCall { get; set; }

        public SISAP03B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO/FINANCEIRO                *      */
        /*"      *   PROGRAMA ...............  SISAP03B                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  HEIDER COELHO                      *      */
        /*"      *   DATA CODIFICACAO .......  JULHO / 2010                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO:                                                      *      */
        /*"      *   SUB-ROTINA PARA IDENTIFICAR SE O IDLG ENVIADO AO SAP         *      */
        /*"      *   EH DE SINISTRO + AS INFORMA��ES PARA ACESSO A CHEQUES_EMITIDO*      */
        /*"      *   E MOVTO_DEBITOCC_CEF                                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   HISTORICO DE ALTERACAO                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  * 03/07/2013 - RILDO                                             *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * 07/01/2011 - RETIRAR O ACESSO A SI_SINI_CHEQUE                 *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * 07/01/2011 - COLOCADO O "FIRST ONLY"                           *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
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
        public SISAP03B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SISAP03B_AREA_DE_WORK();
        public class SISAP03B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WSL-SQLCODE       PIC  ZZZ9-.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "5", "ZZZ9-."));
            /*"01          WABEND.*/
        }
        public SISAP03B_WABEND WABEND { get; set; } = new SISAP03B_WABEND();
        public class SISAP03B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)     VALUE           ' SISAP03B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SISAP03B");
            /*"  05        FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"01  LK-IDLG-REGISTRO-SINISTRO.*/
        }
        public SISAP03B_LK_IDLG_REGISTRO_SINISTRO LK_IDLG_REGISTRO_SINISTRO { get; set; } = new SISAP03B_LK_IDLG_REGISTRO_SINISTRO();
        public class SISAP03B_LK_IDLG_REGISTRO_SINISTRO : VarBasis
        {
            /*"    03 LK-IDLG-DADOS-ENTRADA.*/
            public SISAP03B_LK_IDLG_DADOS_ENTRADA LK_IDLG_DADOS_ENTRADA { get; set; } = new SISAP03B_LK_IDLG_DADOS_ENTRADA();
            public class SISAP03B_LK_IDLG_DADOS_ENTRADA : VarBasis
            {
                /*"    05 LK-IDLG-CODIGO-SINISTRO          PIC X(40).*/
                public StringBasis LK_IDLG_CODIGO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05 LK-IDLG-SIAS-SINISTRO  REDEFINES  LK-IDLG-CODIGO-SINISTRO*/
                private _REDEF_SISAP03B_LK_IDLG_SIAS_SINISTRO _lk_idlg_sias_sinistro { get; set; }
                public _REDEF_SISAP03B_LK_IDLG_SIAS_SINISTRO LK_IDLG_SIAS_SINISTRO
                {
                    get { _lk_idlg_sias_sinistro = new _REDEF_SISAP03B_LK_IDLG_SIAS_SINISTRO(); _.Move(LK_IDLG_CODIGO_SINISTRO, _lk_idlg_sias_sinistro); VarBasis.RedefinePassValue(LK_IDLG_CODIGO_SINISTRO, _lk_idlg_sias_sinistro, LK_IDLG_CODIGO_SINISTRO); _lk_idlg_sias_sinistro.ValueChanged += () => { _.Move(_lk_idlg_sias_sinistro, LK_IDLG_CODIGO_SINISTRO); }; return _lk_idlg_sias_sinistro; }
                    set { VarBasis.RedefinePassValue(value, _lk_idlg_sias_sinistro, LK_IDLG_CODIGO_SINISTRO); }
                }  //Redefines
                public class _REDEF_SISAP03B_LK_IDLG_SIAS_SINISTRO : VarBasis
                {
                    /*"       10 LK-IDLG-SINISTRO              PIC X(01).*/
                    public StringBasis LK_IDLG_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-NUM-APOL-SINISTRO     PIC 9(13).*/
                    public IntBasis LK_IDLG_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                    /*"       10 LK-IDLG-FILLER-1              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-OCORR-HISTORICO       PIC 9(05).*/
                    public IntBasis LK_IDLG_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                    /*"       10 LK-IDLG-FILLER-2              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-COD-OPERACAO          PIC 9(04).*/
                    public IntBasis LK_IDLG_COD_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                    /*"       10 LK-IDLG-FILLER-3              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-TIPO-MOVIMENTO        PIC X(01).*/
                    public StringBasis LK_IDLG_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FILLER-4              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FORMA-PAGAMENTO       PIC X(01).*/
                    public StringBasis LK_IDLG_FORMA_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-FILLER-5              PIC X(01).*/
                    public StringBasis LK_IDLG_FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                    /*"       10 LK-IDLG-COMPLEMENTO           PIC X(10).*/
                    public StringBasis LK_IDLG_COMPLEMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                    /*"       10 LK-IDLG-COMPLEMENTO-1  REDEFINES  LK-IDLG-COMPLEMENTO.*/
                    private _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_1 _lk_idlg_complemento_1 { get; set; }
                    public _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_1 LK_IDLG_COMPLEMENTO_1
                    {
                        get { _lk_idlg_complemento_1 = new _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_1(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_1); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_1.ValueChanged += () => { _.Move(_lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_1; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_1, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_1 : VarBasis
                    {
                        /*"          15 LK-IDLG-NUM-CHEQUE-INTERNO PIC 9(10).*/
                        public IntBasis LK_IDLG_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                        /*"       10 LK-IDLG-COMPLEMENTO-2  REDEFINES  LK-IDLG-COMPLEMENTO.*/

                        public _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_1()
                        {
                            LK_IDLG_NUM_CHEQUE_INTERNO.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_2 _lk_idlg_complemento_2 { get; set; }
                    public _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_2 LK_IDLG_COMPLEMENTO_2
                    {
                        get { _lk_idlg_complemento_2 = new _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_2(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_2); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_2.ValueChanged += () => { _.Move(_lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_2; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_2, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_2 : VarBasis
                    {
                        /*"          15 LK-IDLG-NSAS               PIC 9(10).*/
                        public IntBasis LK_IDLG_NSAS { get; set; } = new IntBasis(new PIC("9", "10", "9(10)."));
                        /*"       10 LK-IDLG-COMPLEMENTO-3  REDEFINES  LK-IDLG-COMPLEMENTO.*/

                        public _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_2()
                        {
                            LK_IDLG_NSAS.ValueChanged += OnValueChanged;
                        }

                    }
                    private _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_3 _lk_idlg_complemento_3 { get; set; }
                    public _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_3 LK_IDLG_COMPLEMENTO_3
                    {
                        get { _lk_idlg_complemento_3 = new _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_3(); _.Move(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_3); VarBasis.RedefinePassValue(LK_IDLG_COMPLEMENTO, _lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); _lk_idlg_complemento_3.ValueChanged += () => { _.Move(_lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); }; return _lk_idlg_complemento_3; }
                        set { VarBasis.RedefinePassValue(value, _lk_idlg_complemento_3, LK_IDLG_COMPLEMENTO); }
                    }  //Redefines
                    public class _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_3 : VarBasis
                    {
                        /*"          15 LK-IDLG-NUM-ACORDO         PIC 9(05).*/
                        public IntBasis LK_IDLG_NUM_ACORDO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
                        /*"          15 FILLER                     PIC X(01).*/
                        public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                        /*"          15 LK-IDLG-NUM-PARCELA        PIC 9(04).*/
                        public IntBasis LK_IDLG_NUM_PARCELA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                        /*"    03 LK-IDLG-DADOS-RETORNO.*/

                        public _REDEF_SISAP03B_LK_IDLG_COMPLEMENTO_3()
                        {
                            LK_IDLG_NUM_ACORDO.ValueChanged += OnValueChanged;
                            FILLER_3.ValueChanged += OnValueChanged;
                            LK_IDLG_NUM_PARCELA.ValueChanged += OnValueChanged;
                        }

                    }

                    public _REDEF_SISAP03B_LK_IDLG_SIAS_SINISTRO()
                    {
                        LK_IDLG_SINISTRO.ValueChanged += OnValueChanged;
                        LK_IDLG_NUM_APOL_SINISTRO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_1.ValueChanged += OnValueChanged;
                        LK_IDLG_OCORR_HISTORICO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_2.ValueChanged += OnValueChanged;
                        LK_IDLG_COD_OPERACAO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_3.ValueChanged += OnValueChanged;
                        LK_IDLG_TIPO_MOVIMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_4.ValueChanged += OnValueChanged;
                        LK_IDLG_FORMA_PAGAMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_FILLER_5.ValueChanged += OnValueChanged;
                        LK_IDLG_COMPLEMENTO.ValueChanged += OnValueChanged;
                        LK_IDLG_COMPLEMENTO_1.ValueChanged += OnValueChanged;
                    }

                }
                public SISAP03B_LK_IDLG_DADOS_RETORNO LK_IDLG_DADOS_RETORNO { get; set; } = new SISAP03B_LK_IDLG_DADOS_RETORNO();
                public class SISAP03B_LK_IDLG_DADOS_RETORNO : VarBasis
                {
                    /*"    05 LK-IDLG-RET-EH-SINISTRO       PIC  X(03).*/
                    public StringBasis LK_IDLG_RET_EH_SINISTRO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
                    /*"    05 LK-IDLG-RET-NUM-APOL-SINISTRO PIC S9(13) COMP-3.*/
                    public IntBasis LK_IDLG_RET_NUM_APOL_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"    05 LK-IDLG-RET-OCORR-HISTORICO   PIC S9(04) COMP  .*/
                    public IntBasis LK_IDLG_RET_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"    05 LK-IDLG-RET-COD-OPERACAO      PIC S9(04) COMP  .*/
                    public IntBasis LK_IDLG_RET_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"    05 LK-IDLG-RET-COD-PAGA-RECEBE   PIC  9(02).*/
                    public IntBasis LK_IDLG_RET_COD_PAGA_RECEBE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"    05 LK-IDLG-RET-COD-PAGA-TEXTO    PIC  X(50).*/
                    public StringBasis LK_IDLG_RET_COD_PAGA_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                    /*"    05 LK-IDLG-RET-COD-FINANC        PIC  9(02).*/
                    public IntBasis LK_IDLG_RET_COD_FINANC { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"    05 LK-IDLG-RET-COD-FINANC-TEXTO  PIC  X(50).*/
                    public StringBasis LK_IDLG_RET_COD_FINANC_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                    /*"    05 LK-IDLG-RET-LAYOUT            PIC  9(02).*/
                    public IntBasis LK_IDLG_RET_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                    /*"    05 LK-IDLG-RET-LAYOUT-TEXTO      PIC  X(50).*/
                    public StringBasis LK_IDLG_RET_LAYOUT_TEXTO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                    /*"    05 LK-IDLG-RET-NUM-OCORR-MOVTO   PIC S9(09) COMP  .*/
                    public IntBasis LK_IDLG_RET_NUM_OCORR_MOVTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"    05 LK-IDLG-RET-IDE-SISTEMA       PIC  X(02).*/
                    public StringBasis LK_IDLG_RET_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"    05 LK-IDLG-RET-MOVDEB-NUM-APOLICE                                     PIC S9(13) COMP-3.*/
                    public IntBasis LK_IDLG_RET_MOVDEB_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"    05 LK-IDLG-RET-MOVDEB-NUM-ENDOSSO                                     PIC S9(04) COMP  .*/
                    public IntBasis LK_IDLG_RET_MOVDEB_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"    05 LK-IDLG-RET-MOVDEB-PARCELA                                     PIC S9(04) COMP  .*/
                    public IntBasis LK_IDLG_RET_MOVDEB_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"    05 LK-IDLG-RET-MOVDEB-CONVENIO                                     PIC S9(09) COMP  .*/
                    public IntBasis LK_IDLG_RET_MOVDEB_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"    05 LK-IDLG-RET-MOVDEB-NSAS-ENVIO                                     PIC S9(04) COMP  .*/
                    public IntBasis LK_IDLG_RET_MOVDEB_NSAS_ENVIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
                    /*"    05 LK-IDLG-RET-MOVDEB-NUM-REQUISI                                     PIC S9(13) COMP-3.*/
                    public IntBasis LK_IDLG_RET_MOVDEB_NUM_REQUISI { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"    05 LK-IDLG-RET-CHQ-CHQINT                                     PIC S9(13) COMP-3.*/
                    public IntBasis LK_IDLG_RET_CHQ_CHQINT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
                    /*"    05 LK-IDLG-RET-RESSARC-NUM-ACORDO                                     PIC S9(09) COMP  .*/
                    public IntBasis LK_IDLG_RET_RESSARC_NUM_ACORDO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"    05 LK-IDLG-RET-RESSARC-PARCELA                                     PIC S9(09) COMP  .*/
                    public IntBasis LK_IDLG_RET_RESSARC_PARCELA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
                    /*"    05 LK-IDLG-RET-CODIGO-RETORNO    PIC X(01)        .*/
                    public StringBasis LK_IDLG_RET_CODIGO_RETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
                    /*"    05 LK-IDLG-RET-MENSAGEM          PIC X(80)        .*/
                    public StringBasis LK_IDLG_RET_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "80", "X(80)"), @"");
                }
            }
        }


        public Dclgens.GE096 GE096 { get; set; } = new Dclgens.GE096();
        public Dclgens.GE098 GE098 { get; set; } = new Dclgens.GE098();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.SISINCHE SISINCHE { get; set; } = new Dclgens.SISINCHE();
        public Dclgens.GE097 GE097 { get; set; } = new Dclgens.GE097();
        public Dclgens.GE094 GE094 { get; set; } = new Dclgens.GE094();
        public Dclgens.GE095 GE095 { get; set; } = new Dclgens.GE095();
        public Dclgens.GE099 GE099 { get; set; } = new Dclgens.GE099();
        public Dclgens.GE100 GE100 { get; set; } = new Dclgens.GE100();
        public Dclgens.GE102 GE102 { get; set; } = new Dclgens.GE102();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(SISAP03B_LK_IDLG_REGISTRO_SINISTRO SISAP03B_LK_IDLG_REGISTRO_SINISTRO_P) //PROCEDURE DIVISION USING 
        /*LK_IDLG_REGISTRO_SINISTRO*/
        {
            try
            {
                this.LK_IDLG_REGISTRO_SINISTRO = SISAP03B_LK_IDLG_REGISTRO_SINISTRO_P;

                /*" -293- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -295- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -297- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -309- INITIALIZE DCLGE-MOVDEBCE-SAP DCLGE-VIDA-SAP DCLGE-BOLETO-EMISSAO DCLGE-CHEQUE-SAP DCLGE-BOLETO-RESSARC-SINI DCLGE-MOVIMENTO-SAP DCLGE-CONTROLE-INTERF-SAP DCLGE-ARQUIVO-SAP LK-IDLG-DADOS-RETORNO. */
                _.Initialize(
                    GE094.DCLGE_MOVDEBCE_SAP
                    , GE095.DCLGE_VIDA_SAP
                    , GE096.DCLGE_BOLETO_EMISSAO
                    , GE097.DCLGE_CHEQUE_SAP
                    , GE098.DCLGE_BOLETO_RESSARC_SINI
                    , GE099.DCLGE_MOVIMENTO_SAP
                    , GE100.DCLGE_CONTROLE_INTERF_SAP
                    , GE102.DCLGE_ARQUIVO_SAP
                    , LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO
                );

                /*" -310- MOVE '0' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("0", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -316- MOVE 'EXECUCAO COM SUCESSO' TO LK-IDLG-RET-MENSAGEM. */
                _.Move("EXECUCAO COM SUCESSO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -318- PERFORM R0010-SELECT-SISTEMAS THRU R0010-EXIT. */

                R0010_SELECT_SISTEMAS(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_EXIT*/


                /*" -320- PERFORM R0020-CRITICA-LINKAGE THRU R0020-EXIT. */

                R0020_CRITICA_LINKAGE(true);

                RXYZ_PULA_SINICHEQ(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/


                /*" -321- MOVE '0' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("0", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -325- MOVE 'EXECUCAO COM SUCESSO' TO LK-IDLG-RET-MENSAGEM. */
                _.Move("EXECUCAO COM SUCESSO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -325- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LK_IDLG_REGISTRO_SINISTRO, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS */
        private void R0010_SELECT_SISTEMAS(bool isPerform = false)
        {
            /*" -346- PERFORM R0010_SELECT_SISTEMAS_DB_SELECT_1 */

            R0010_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -349- IF SQLCODE NOT = 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -350- DISPLAY 'SISAP03B - ERRO NO ACESSO SISTEMAS - SI' */
                _.Display($"SISAP03B - ERRO NO ACESSO SISTEMAS - SI");

                /*" -350- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0010-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0010_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -346- EXEC SQL SELECT DATA_MOV_ABERTO, DATULT_PROCESSAMEN, CURRENT DATE, CURRENT TIMESTAMP, CURRENT TIME INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATULT-PROCESSAMEN, :HOST-CURRENT-DATE, :HOST-TIMESTAMP, :HOST-CURRENT-TIME FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' WITH UR END-EXEC. */

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
            /*" -357- IF LK-IDLG-DADOS-ENTRADA EQUAL SPACES */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.IsEmpty())
            {

                /*" -358- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -361- MOVE 'SISAP03B - DADOS DE ENTRADA NAO INFORMADO' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - DADOS DE ENTRADA NAO INFORMADO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -363- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -369- IF (LK-IDLG-SINISTRO NOT EQUAL 'S' ) OR (LK-IDLG-FILLER-1 NOT EQUAL '|' ) OR (LK-IDLG-FILLER-2 NOT EQUAL '|' ) OR (LK-IDLG-FILLER-3 NOT EQUAL '|' ) OR (LK-IDLG-FILLER-4 NOT EQUAL '|' ) OR (LK-IDLG-FILLER-5 NOT EQUAL '|' ) */

            if ((LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_SINISTRO != "S") || (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FILLER_1 != "|") || (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FILLER_2 != "|") || (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FILLER_3 != "|") || (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FILLER_4 != "|") || (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FILLER_5 != "|"))
            {

                /*" -370- MOVE 'NAO' TO LK-IDLG-RET-EH-SINISTRO */
                _.Move("NAO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO);

                /*" -374- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -376- IF (LK-IDLG-TIPO-MOVIMENTO NOT EQUAL 'P' ) AND (LK-IDLG-TIPO-MOVIMENTO NOT EQUAL 'R' ) */

            if ((LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_TIPO_MOVIMENTO != "P") && (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_TIPO_MOVIMENTO != "R"))
            {

                /*" -377- MOVE 'NAO' TO LK-IDLG-RET-EH-SINISTRO */
                _.Move("NAO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO);

                /*" -381- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -384- IF (LK-IDLG-FORMA-PAGAMENTO NOT EQUAL 1) AND (LK-IDLG-FORMA-PAGAMENTO NOT EQUAL 2) AND (LK-IDLG-FORMA-PAGAMENTO NOT EQUAL 3) */

            if ((LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FORMA_PAGAMENTO != 1) && (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FORMA_PAGAMENTO != 2) && (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FORMA_PAGAMENTO != 3))
            {

                /*" -385- MOVE 'NAO' TO LK-IDLG-RET-EH-SINISTRO */
                _.Move("NAO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO);

                /*" -387- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -394- IF (LK-IDLG-NUM-APOL-SINISTRO NOT NUMERIC) OR (LK-IDLG-OCORR-HISTORICO NOT NUMERIC) OR (LK-IDLG-COD-OPERACAO NOT NUMERIC) OR (LK-IDLG-NUM-CHEQUE-INTERNO NOT NUMERIC) OR (LK-IDLG-NSAS NOT NUMERIC) OR (LK-IDLG-NUM-ACORDO NOT NUMERIC) OR (LK-IDLG-NUM-PARCELA NOT NUMERIC) */

            if ((!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_NUM_APOL_SINISTRO.IsNumeric()) || (!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_OCORR_HISTORICO.IsNumeric()) || (!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_COD_OPERACAO.IsNumeric()) || (!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_COMPLEMENTO_1.LK_IDLG_NUM_CHEQUE_INTERNO.IsNumeric()) || (!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_COMPLEMENTO_2.LK_IDLG_NSAS.IsNumeric()) || (!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_COMPLEMENTO_3.LK_IDLG_NUM_ACORDO.IsNumeric()) || (!LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_COMPLEMENTO_3.LK_IDLG_NUM_PARCELA.IsNumeric()))
            {

                /*" -395- MOVE 'NAO' TO LK-IDLG-RET-EH-SINISTRO */
                _.Move("NAO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO);

                /*" -397- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -399- MOVE LK-IDLG-NUM-APOL-SINISTRO TO SINISHIS-NUM-APOL-SINISTRO LK-IDLG-RET-NUM-APOL-SINISTRO */
            _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_NUM_APOL_SINISTRO);

            /*" -401- MOVE LK-IDLG-OCORR-HISTORICO TO SINISHIS-OCORR-HISTORICO LK-IDLG-RET-OCORR-HISTORICO */
            _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_OCORR_HISTORICO);

            /*" -404- MOVE LK-IDLG-COD-OPERACAO TO SINISHIS-COD-OPERACAO LK-IDLG-RET-COD-OPERACAO */
            _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_OPERACAO);

            /*" -418- PERFORM R0020_CRITICA_LINKAGE_DB_SELECT_1 */

            R0020_CRITICA_LINKAGE_DB_SELECT_1();

            /*" -421- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -422- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -425- MOVE 'SISAP03B - ERRO NO ACESSO SINISTRO_HISTORICO' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - ERRO NO ACESSO SINISTRO_HISTORICO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -427- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -428- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -429- MOVE 'NAO' TO LK-IDLG-RET-EH-SINISTRO */
                _.Move("NAO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO);

                /*" -436- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -448- GO TO RXYZ-PULA-SINICHEQ. */

            RXYZ_PULA_SINICHEQ(); //GOTO
            return;


        }

        [StopWatch]
        /*" R0020-CRITICA-LINKAGE-DB-SELECT-1 */
        public void R0020_CRITICA_LINKAGE_DB_SELECT_1()
        {
            /*" -418- EXEC SQL SELECT NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO , VAL_OPERACAO INTO :SINISHIS-NUM-APOL-SINISTRO , :SINISHIS-OCORR-HISTORICO , :SINISHIS-COD-OPERACAO , :SINISHIS-VAL-OPERACAO FROM SEGUROS.SINISTRO_HISTORICO WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r0020_CRITICA_LINKAGE_DB_SELECT_1_Query1 = new R0020_CRITICA_LINKAGE_DB_SELECT_1_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R0020_CRITICA_LINKAGE_DB_SELECT_1_Query1.Execute(r0020_CRITICA_LINKAGE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
                _.Move(executed_1.SINISHIS_VAL_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_VAL_OPERACAO);
            }


        }

        [StopWatch]
        /*" RXYZ-PULA-SINICHEQ */
        private void RXYZ_PULA_SINICHEQ(bool isPerform = false)
        {
            /*" -481- MOVE 'SIM' TO LK-IDLG-RET-EH-SINISTRO */
            _.Move("SIM", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO);

            /*" -482- IF LK-IDLG-TIPO-MOVIMENTO EQUAL 'P' */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_TIPO_MOVIMENTO == "P")
            {

                /*" -483- MOVE 1 TO LK-IDLG-RET-COD-PAGA-RECEBE */
                _.Move(1, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_PAGA_RECEBE);

                /*" -484- MOVE 'PAGAMENTO' TO LK-IDLG-RET-COD-PAGA-TEXTO. */
                _.Move("PAGAMENTO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_PAGA_TEXTO);
            }


            /*" -485- IF LK-IDLG-TIPO-MOVIMENTO EQUAL 'R' */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_TIPO_MOVIMENTO == "R")
            {

                /*" -486- MOVE 2 TO LK-IDLG-RET-COD-PAGA-RECEBE */
                _.Move(2, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_PAGA_RECEBE);

                /*" -488- MOVE 'RECEBIMENTO' TO LK-IDLG-RET-COD-PAGA-TEXTO. */
                _.Move("RECEBIMENTO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_PAGA_TEXTO);
            }


            /*" -490- MOVE LK-IDLG-CODIGO-SINISTRO TO GE100-COD-IDLG . */
            _.Move(LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_CODIGO_SINISTRO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG);

            /*" -520- PERFORM RXYZ_PULA_SINICHEQ_DB_SELECT_1 */

            RXYZ_PULA_SINICHEQ_DB_SELECT_1();

            /*" -523- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -524- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -525- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -526- DISPLAY '* ERRO DE ACESSO NA ROTINA SISAP03B            *' */
                _.Display($"* ERRO DE ACESSO NA ROTINA SISAP03B            *");

                /*" -527- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -528- DISPLAY '* TABELA: GE_CONTROLE_INTERF_SAP               *' */
                _.Display($"* TABELA: GE_CONTROLE_INTERF_SAP               *");

                /*" -529- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -530- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -531- DISPLAY '* SQLCODE ....... ' WSL-SQLCODE */
                _.Display($"* SQLCODE ....... {AREA_DE_WORK.WSL_SQLCODE}");

                /*" -532- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -533- DISPLAY '* IDLG DE ACESSO: ' GE100-COD-IDLG */
                _.Display($"* IDLG DE ACESSO: {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -534- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -535- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -536- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -539- MOVE 'SISAP03B - ERRO NO ACESSO GE_CONTROLE_INTERF_SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - ERRO NO ACESSO GE_CONTROLE_INTERF_SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -541- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -542- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -543- MOVE '2' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("2", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -546- MOVE 'SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE CONTROLE SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE CONTROLE SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -552- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -562- MOVE GE100-NUM-OCORR-MOVTO TO LK-IDLG-RET-NUM-OCORR-MOVTO */
            _.Move(GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_NUM_OCORR_MOVTO);

            /*" -563- IF LK-IDLG-FORMA-PAGAMENTO EQUAL 1 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FORMA_PAGAMENTO == 1)
            {

                /*" -564- MOVE 1 TO LK-IDLG-RET-COD-FINANC */
                _.Move(1, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC);

                /*" -566- MOVE 'EM CHEQUE (PAPEL)' TO LK-IDLG-RET-COD-FINANC-TEXTO */
                _.Move("EM CHEQUE (PAPEL)", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC_TEXTO);

                /*" -567- PERFORM R1010-LE-CHEQUES-SAP THRU R1010-EXIT */

                R1010_LE_CHEQUES_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/


                /*" -568- MOVE GE097-IDE-SISTEMA TO LK-IDLG-RET-IDE-SISTEMA */
                _.Move(GE097.DCLGE_CHEQUE_SAP.GE097_IDE_SISTEMA, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_IDE_SISTEMA);

                /*" -569- MOVE GE097-NUM-CHEQUE-INTERNO TO LK-IDLG-RET-CHQ-CHQINT */
                _.Move(GE097.DCLGE_CHEQUE_SAP.GE097_NUM_CHEQUE_INTERNO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CHQ_CHQINT);

                /*" -573- GO TO R0020-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/ //GOTO
                return;
            }


            /*" -574- IF LK-IDLG-FORMA-PAGAMENTO EQUAL 2 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FORMA_PAGAMENTO == 2)
            {

                /*" -575- MOVE 2 TO LK-IDLG-RET-COD-FINANC */
                _.Move(2, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC);

                /*" -577- MOVE 'CONTA CORRENTE (CREDITO OU DEBITO)' TO LK-IDLG-RET-COD-FINANC-TEXTO */
                _.Move("CONTA CORRENTE (CREDITO OU DEBITO)", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC_TEXTO);

                /*" -578- PERFORM R1020-LE-MOVDEBCC-SAP THRU R1020-EXIT */

                R1020_LE_MOVDEBCC_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/


                /*" -580- MOVE GE094-IDE-SISTEMA TO LK-IDLG-RET-IDE-SISTEMA */
                _.Move(GE094.DCLGE_MOVDEBCE_SAP.GE094_IDE_SISTEMA, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_IDE_SISTEMA);

                /*" -582- MOVE GE094-NUM-APOLICE TO LK-IDLG-RET-MOVDEB-NUM-APOLICE */
                _.Move(GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_APOLICE, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NUM_APOLICE);

                /*" -584- MOVE GE094-NUM-ENDOSSO TO LK-IDLG-RET-MOVDEB-NUM-ENDOSSO */
                _.Move(GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_ENDOSSO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NUM_ENDOSSO);

                /*" -586- MOVE GE094-NUM-PARCELA TO LK-IDLG-RET-MOVDEB-PARCELA */
                _.Move(GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_PARCELA, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_PARCELA);

                /*" -588- MOVE GE094-NSAS TO LK-IDLG-RET-MOVDEB-NSAS-ENVIO */
                _.Move(GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NSAS_ENVIO);

                /*" -590- MOVE GE094-COD-CONVENIO TO LK-IDLG-RET-MOVDEB-CONVENIO */
                _.Move(GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_CONVENIO);

                /*" -592- MOVE MOVDEBCE-NUM-REQUISICAO TO LK-IDLG-RET-MOVDEB-NUM-REQUISI */
                _.Move(MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NUM_REQUISI);

                /*" -594- IF GE094-COD-CONVENIO EQUAL 600128 OR 600119 OR 600120 OR 600123 */

                if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO.In("600128", "600119", "600120", "600123"))
                {

                    /*" -595- MOVE 1 TO LK-IDLG-RET-LAYOUT */
                    _.Move(1, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT);

                    /*" -597- MOVE 'SICOV CAIXA' TO LK-IDLG-RET-LAYOUT-TEXTO */
                    _.Move("SICOV CAIXA", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT_TEXTO);

                    /*" -598- ELSE */
                }
                else
                {


                    /*" -599- IF GE094-COD-CONVENIO EQUAL 43350 */

                    if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO == 43350)
                    {

                        /*" -600- MOVE 2 TO LK-IDLG-RET-LAYOUT */
                        _.Move(2, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT);

                        /*" -602- MOVE 'SIACC CAIXA' TO LK-IDLG-RET-LAYOUT-TEXTO */
                        _.Move("SIACC CAIXA", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT_TEXTO);

                        /*" -603- ELSE */
                    }
                    else
                    {


                        /*" -604- IF GE094-COD-CONVENIO EQUAL 921286 */

                        if (GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO == 921286)
                        {

                            /*" -605- MOVE 3 TO LK-IDLG-RET-LAYOUT */
                            _.Move(3, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT);

                            /*" -607- MOVE 'CONVENIO BANCO DO BRASIL' TO LK-IDLG-RET-LAYOUT-TEXTO */
                            _.Move("CONVENIO BANCO DO BRASIL", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT_TEXTO);

                            /*" -608- ELSE */
                        }
                        else
                        {


                            /*" -609- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                            _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                            /*" -612- MOVE 'SISAP03B - CONVENIO NAO PREVISO PARA SINISTRO' TO LK-IDLG-RET-MENSAGEM */
                            _.Move("SISAP03B - CONVENIO NAO PREVISO PARA SINISTRO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                            /*" -614- GO TO RXXXX-ROTINA-RETORNO. */

                            RXXXX_ROTINA_RETORNO(); //GOTO
                            return;
                        }

                    }

                }

            }


            /*" -615- IF LK-IDLG-FORMA-PAGAMENTO EQUAL 3 */

            if (LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_SIAS_SINISTRO.LK_IDLG_FORMA_PAGAMENTO == 3)
            {

                /*" -616- MOVE 3 TO LK-IDLG-RET-COD-FINANC */
                _.Move(3, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC);

                /*" -618- MOVE 'BOLETO BANCARIO' TO LK-IDLG-RET-COD-FINANC-TEXTO */
                _.Move("BOLETO BANCARIO", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC_TEXTO);

                /*" -619- PERFORM R1000-LE-RESSARCIMENTO-SAP THRU R1000-EXIT */

                R1000_LE_RESSARCIMENTO_SAP(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/


                /*" -621- MOVE GE098-IDE-SISTEMA TO LK-IDLG-RET-IDE-SISTEMA */
                _.Move(GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_IDE_SISTEMA, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_IDE_SISTEMA);

                /*" -623- MOVE GE098-NUM-RESSARC TO LK-IDLG-RET-RESSARC-NUM-ACORDO */
                _.Move(GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_RESSARC, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_RESSARC_NUM_ACORDO);

                /*" -625- MOVE GE098-NUM-PARCELA TO LK-IDLG-RET-RESSARC-PARCELA */
                _.Move(GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_PARCELA, LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_RESSARC_PARCELA);

                /*" -625- GO TO R0020-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" RXYZ-PULA-SINICHEQ-DB-SELECT-1 */
        public void RXYZ_PULA_SINICHEQ_DB_SELECT_1()
        {
            /*" -520- EXEC SQL SELECT NUM_OCORR_MOVTO INTO :GE100-NUM-OCORR-MOVTO FROM SEGUROS.GE_CONTROLE_INTERF_SAP A WHERE A.COD_IDLG = :GE100-COD-IDLG AND A.DTA_MOVIMENTO_LEGADO <> '9999-12-31' AND ( EXISTS (SELECT 1 FROM SEGUROS.GE_MOVDEBCE_SAP B WHERE B.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_CHEQUE_SAP C WHERE C.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_BOLETO_RESSARC_SINI D WHERE D.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_VIDA_SAP E WHERE E.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) OR EXISTS (SELECT 1 FROM SEGUROS.GE_BOLETO_EMISSAO F WHERE F.NUM_OCORR_MOVTO = A.NUM_OCORR_MOVTO ) ) ORDER BY A.DTA_MOVIMENTO_LEGADO DESC FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1 = new RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1()
            {
                GE100_COD_IDLG = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG.ToString(),
            };

            var executed_1 = RXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1.Execute(rXYZ_PULA_SINICHEQ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE100_NUM_OCORR_MOVTO, GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO);
            }


        }

        [StopWatch]
        /*" R0020-CRITICA-LINKAGE-DB-SELECT-2 */
        public void R0020_CRITICA_LINKAGE_DB_SELECT_2()
        {
            /*" -464- EXEC SQL SELECT NUM_APOL_SINISTRO , OCORR_HISTORICO , COD_OPERACAO INTO :SINISHIS-NUM-APOL-SINISTRO , :SINISHIS-OCORR-HISTORICO , :SINISHIS-COD-OPERACAO FROM SEGUROS.SI_SINI_CHEQUE WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO AND OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO AND COD_OPERACAO = :SINISHIS-COD-OPERACAO END-EXEC. */

            var r0020_CRITICA_LINKAGE_DB_SELECT_2_Query1 = new R0020_CRITICA_LINKAGE_DB_SELECT_2_Query1()
            {
                SINISHIS_NUM_APOL_SINISTRO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO.ToString(),
                SINISHIS_OCORR_HISTORICO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO.ToString(),
                SINISHIS_COD_OPERACAO = SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO.ToString(),
            };

            var executed_1 = R0020_CRITICA_LINKAGE_DB_SELECT_2_Query1.Execute(r0020_CRITICA_LINKAGE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(executed_1.SINISHIS_OCORR_HISTORICO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_OCORR_HISTORICO);
                _.Move(executed_1.SINISHIS_COD_OPERACAO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_OPERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_EXIT*/

        [StopWatch]
        /*" R1000-LE-RESSARCIMENTO-SAP */
        private void R1000_LE_RESSARCIMENTO_SAP(bool isPerform = false)
        {
            /*" -658- PERFORM R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1 */

            R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1();

            /*" -661- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -662- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -663- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -664- DISPLAY '* ERRO DE ACESSO NA ROTINA SISAP03B            *' */
                _.Display($"* ERRO DE ACESSO NA ROTINA SISAP03B            *");

                /*" -665- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -666- DISPLAY '* TABELA: GE_BOLETO_RESSARC_SINI               *' */
                _.Display($"* TABELA: GE_BOLETO_RESSARC_SINI               *");

                /*" -667- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -668- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -669- DISPLAY '* SQLCODE ....... ' WSL-SQLCODE */
                _.Display($"* SQLCODE ....... {AREA_DE_WORK.WSL_SQLCODE}");

                /*" -670- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -671- DISPLAY '* IDLG ............ ' GE100-COD-IDLG */
                _.Display($"* IDLG ............ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -672- DISPLAY '* NUM_OCORR_MOVTO.. ' GE100-NUM-OCORR-MOVTO */
                _.Display($"* NUM_OCORR_MOVTO.. {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -673- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -674- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -675- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -678- MOVE 'SISAP03B - ERRO NO ACESSO GE_BOLETO_RESSARC_SINI' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - ERRO NO ACESSO GE_BOLETO_RESSARC_SINI", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -680- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -681- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -682- MOVE '2' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("2", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -685- MOVE 'SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE BOLETO SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE BOLETO SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -685- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1000-LE-RESSARCIMENTO-SAP-DB-SELECT-1 */
        public void R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1()
        {
            /*" -658- EXEC SQL SELECT NUM_OCORR_MOVTO , NUM_APOL_SINISTRO , COD_OPERACAO , NUM_OCORR_HISTORICO, NUM_RESSARC , SEQ_RESSARC , NUM_PARCELA , NUM_NOSSO_TITULO , NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO INTO :GE098-NUM-OCORR-MOVTO , :GE098-NUM-APOL-SINISTRO , :GE098-COD-OPERACAO , :GE098-NUM-OCORR-HISTORICO , :GE098-NUM-RESSARC , :GE098-SEQ-RESSARC , :GE098-NUM-PARCELA , :GE098-NUM-NOSSO-TITULO , :GE098-NSAS , :GE098-IDE-SISTEMA , :GE098-DTH-CADASTRAMENTO FROM SEGUROS.GE_BOLETO_RESSARC_SINI WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO END-EXEC. */

            var r1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1 = new R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1.Execute(r1000_LE_RESSARCIMENTO_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE098_NUM_OCORR_MOVTO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE098_NUM_APOL_SINISTRO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_APOL_SINISTRO);
                _.Move(executed_1.GE098_COD_OPERACAO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_COD_OPERACAO);
                _.Move(executed_1.GE098_NUM_OCORR_HISTORICO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_OCORR_HISTORICO);
                _.Move(executed_1.GE098_NUM_RESSARC, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_RESSARC);
                _.Move(executed_1.GE098_SEQ_RESSARC, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_SEQ_RESSARC);
                _.Move(executed_1.GE098_NUM_PARCELA, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_PARCELA);
                _.Move(executed_1.GE098_NUM_NOSSO_TITULO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NUM_NOSSO_TITULO);
                _.Move(executed_1.GE098_NSAS, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_NSAS);
                _.Move(executed_1.GE098_IDE_SISTEMA, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_IDE_SISTEMA);
                _.Move(executed_1.GE098_DTH_CADASTRAMENTO, GE098.DCLGE_BOLETO_RESSARC_SINI.GE098_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_EXIT*/

        [StopWatch]
        /*" R1010-LE-CHEQUES-SAP */
        private void R1010_LE_CHEQUES_SAP(bool isPerform = false)
        {
            /*" -706- PERFORM R1010_LE_CHEQUES_SAP_DB_SELECT_1 */

            R1010_LE_CHEQUES_SAP_DB_SELECT_1();

            /*" -709- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -710- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -711- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -712- DISPLAY '* ERRO DE ACESSO NA ROTINA SISAP03B            *' */
                _.Display($"* ERRO DE ACESSO NA ROTINA SISAP03B            *");

                /*" -713- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -714- DISPLAY '* TABELA: GE_CHEQUE_SAP                        *' */
                _.Display($"* TABELA: GE_CHEQUE_SAP                        *");

                /*" -715- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -716- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -717- DISPLAY '* SQLCODE ....... ' WSL-SQLCODE */
                _.Display($"* SQLCODE ....... {AREA_DE_WORK.WSL_SQLCODE}");

                /*" -718- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -719- DISPLAY '* IDLG ............ ' GE100-COD-IDLG */
                _.Display($"* IDLG ............ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -720- DISPLAY '* NUM_OCORR_MOVTO.. ' GE100-NUM-OCORR-MOVTO */
                _.Display($"* NUM_OCORR_MOVTO.. {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -721- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -722- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -723- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -726- MOVE 'SISAP03B - ERRO NO ACESSO GE_CHEQUE_SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - ERRO NO ACESSO GE_CHEQUE_SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -728- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -729- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -730- MOVE '2' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("2", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -733- MOVE 'SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE CHEQUES SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE CHEQUES SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -733- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1010-LE-CHEQUES-SAP-DB-SELECT-1 */
        public void R1010_LE_CHEQUES_SAP_DB_SELECT_1()
        {
            /*" -706- EXEC SQL SELECT NUM_OCORR_MOVTO , NUM_CHEQUE_INTERNO, NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO INTO :GE097-NUM-OCORR-MOVTO, :GE097-NUM-CHEQUE-INTERNO, :GE097-NSAS, :GE097-IDE-SISTEMA, :GE097-DTH-CADASTRAMENTO FROM SEGUROS.GE_CHEQUE_SAP WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO END-EXEC. */

            var r1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1 = new R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1.Execute(r1010_LE_CHEQUES_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE097_NUM_OCORR_MOVTO, GE097.DCLGE_CHEQUE_SAP.GE097_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE097_NUM_CHEQUE_INTERNO, GE097.DCLGE_CHEQUE_SAP.GE097_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.GE097_NSAS, GE097.DCLGE_CHEQUE_SAP.GE097_NSAS);
                _.Move(executed_1.GE097_IDE_SISTEMA, GE097.DCLGE_CHEQUE_SAP.GE097_IDE_SISTEMA);
                _.Move(executed_1.GE097_DTH_CADASTRAMENTO, GE097.DCLGE_CHEQUE_SAP.GE097_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_EXIT*/

        [StopWatch]
        /*" R1020-LE-MOVDEBCC-SAP */
        private void R1020_LE_MOVDEBCC_SAP(bool isPerform = false)
        {
            /*" -760- PERFORM R1020_LE_MOVDEBCC_SAP_DB_SELECT_1 */

            R1020_LE_MOVDEBCC_SAP_DB_SELECT_1();

            /*" -763- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -764- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -765- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -766- DISPLAY '* ERRO DE ACESSO NA ROTINA SISAP03B            *' */
                _.Display($"* ERRO DE ACESSO NA ROTINA SISAP03B            *");

                /*" -767- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -768- DISPLAY '* TABELA: GE_MOVDEBCE_SAP                      *' */
                _.Display($"* TABELA: GE_MOVDEBCE_SAP                      *");

                /*" -769- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -770- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -771- DISPLAY '* SQLCODE ....... ' WSL-SQLCODE */
                _.Display($"* SQLCODE ....... {AREA_DE_WORK.WSL_SQLCODE}");

                /*" -772- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -773- DISPLAY '* IDLG ............ ' GE100-COD-IDLG */
                _.Display($"* IDLG ............ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -774- DISPLAY '* NUM_OCORR_MOVTO.. ' GE100-NUM-OCORR-MOVTO */
                _.Display($"* NUM_OCORR_MOVTO.. {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -775- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -776- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -777- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -780- MOVE 'SISAP03B - ERRO NO ACESSO GE_MOVDEBCE_SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - ERRO NO ACESSO GE_MOVDEBCE_SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -782- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -783- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -784- MOVE '2' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("2", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -787- MOVE 'SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE MOVDECC SAP' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE MOVDECC SAP", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -789- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


            /*" -800- PERFORM R1020_LE_MOVDEBCC_SAP_DB_SELECT_2 */

            R1020_LE_MOVDEBCC_SAP_DB_SELECT_2();

            /*" -803- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -804- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -805- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -806- DISPLAY '* ERRO DE ACESSO NA ROTINA SISAP03B            *' */
                _.Display($"* ERRO DE ACESSO NA ROTINA SISAP03B            *");

                /*" -807- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -808- DISPLAY '* TABELA: MOVTO_DEBITOCC_CEF                   *' */
                _.Display($"* TABELA: MOVTO_DEBITOCC_CEF                   *");

                /*" -809- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -810- MOVE SQLCODE TO WSL-SQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

                /*" -811- DISPLAY '* SQLCODE ....... ' WSL-SQLCODE */
                _.Display($"* SQLCODE ....... {AREA_DE_WORK.WSL_SQLCODE}");

                /*" -812- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -813- DISPLAY '* IDLG ............ ' GE100-COD-IDLG */
                _.Display($"* IDLG ............ {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_COD_IDLG}");

                /*" -814- DISPLAY '* NUM_OCORR_MOVTO.. ' GE100-NUM-OCORR-MOVTO */
                _.Display($"* NUM_OCORR_MOVTO.. {GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO}");

                /*" -815- DISPLAY '* NUM_APOLICE...... ' GE094-NUM-APOLICE */
                _.Display($"* NUM_APOLICE...... {GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_APOLICE}");

                /*" -816- DISPLAY '* NUM_ENDOSSO...... ' GE094-NUM-ENDOSSO */
                _.Display($"* NUM_ENDOSSO...... {GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_ENDOSSO}");

                /*" -817- DISPLAY '* NUM_PARCELA...... ' GE094-NUM-PARCELA */
                _.Display($"* NUM_PARCELA...... {GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_PARCELA}");

                /*" -818- DISPLAY '* COD_CONVENIO..... ' GE094-COD-CONVENIO */
                _.Display($"* COD_CONVENIO..... {GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO}");

                /*" -819- DISPLAY '* NSAS............. ' GE094-NSAS */
                _.Display($"* NSAS............. {GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS}");

                /*" -820- DISPLAY '*                                              *' */
                _.Display($"*                                              *");

                /*" -821- DISPLAY '************************************************' */
                _.Display($"************************************************");

                /*" -822- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -825- MOVE 'SISAP03B - ERRO NO ACESSO MOVTO_DEBITOCC_CEF' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - ERRO NO ACESSO MOVTO_DEBITOCC_CEF", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -827- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO(); //GOTO
                return;
            }


            /*" -828- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -829- MOVE '2' TO LK-IDLG-RET-CODIGO-RETORNO */
                _.Move("2", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

                /*" -832- MOVE 'SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE MOVDECC SIAS' TO LK-IDLG-RET-MENSAGEM */
                _.Move("SISAP03B - IDLG NAO ENCONTRADO NA ESTRUTURA DE MOVDECC SIAS", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

                /*" -832- GO TO RXXXX-ROTINA-RETORNO. */

                RXXXX_ROTINA_RETORNO(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-LE-MOVDEBCC-SAP-DB-SELECT-1 */
        public void R1020_LE_MOVDEBCC_SAP_DB_SELECT_1()
        {
            /*" -760- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , COD_CONVENIO , NSAS , NUM_OCORR_MOVTO , IDE_SISTEMA , DTH_CADASTRAMENTO INTO :GE094-NUM-APOLICE , :GE094-NUM-ENDOSSO , :GE094-NUM-PARCELA , :GE094-COD-CONVENIO , :GE094-NSAS , :GE094-NUM-OCORR-MOVTO , :GE094-IDE-SISTEMA , :GE094-DTH-CADASTRAMENTO FROM SEGUROS.GE_MOVDEBCE_SAP WHERE NUM_OCORR_MOVTO = :GE100-NUM-OCORR-MOVTO END-EXEC. */

            var r1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1 = new R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1()
            {
                GE100_NUM_OCORR_MOVTO = GE100.DCLGE_CONTROLE_INTERF_SAP.GE100_NUM_OCORR_MOVTO.ToString(),
            };

            var executed_1 = R1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1.Execute(r1020_LE_MOVDEBCC_SAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE094_NUM_APOLICE, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_APOLICE);
                _.Move(executed_1.GE094_NUM_ENDOSSO, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_ENDOSSO);
                _.Move(executed_1.GE094_NUM_PARCELA, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_PARCELA);
                _.Move(executed_1.GE094_COD_CONVENIO, GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO);
                _.Move(executed_1.GE094_NSAS, GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS);
                _.Move(executed_1.GE094_NUM_OCORR_MOVTO, GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_OCORR_MOVTO);
                _.Move(executed_1.GE094_IDE_SISTEMA, GE094.DCLGE_MOVDEBCE_SAP.GE094_IDE_SISTEMA);
                _.Move(executed_1.GE094_DTH_CADASTRAMENTO, GE094.DCLGE_MOVDEBCE_SAP.GE094_DTH_CADASTRAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_EXIT*/

        [StopWatch]
        /*" R1020-LE-MOVDEBCC-SAP-DB-SELECT-2 */
        public void R1020_LE_MOVDEBCC_SAP_DB_SELECT_2()
        {
            /*" -800- EXEC SQL SELECT NUM_REQUISICAO INTO :MOVDEBCE-NUM-REQUISICAO FROM SEGUROS.MOVTO_DEBITOCC_CEF WHERE NUM_APOLICE = :GE094-NUM-APOLICE AND NUM_ENDOSSO = :GE094-NUM-ENDOSSO AND NUM_PARCELA = :GE094-NUM-PARCELA AND COD_CONVENIO = :GE094-COD-CONVENIO AND NSAS = :GE094-NSAS END-EXEC. */

            var r1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1 = new R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1()
            {
                GE094_COD_CONVENIO = GE094.DCLGE_MOVDEBCE_SAP.GE094_COD_CONVENIO.ToString(),
                GE094_NUM_APOLICE = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_APOLICE.ToString(),
                GE094_NUM_ENDOSSO = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_ENDOSSO.ToString(),
                GE094_NUM_PARCELA = GE094.DCLGE_MOVDEBCE_SAP.GE094_NUM_PARCELA.ToString(),
                GE094_NSAS = GE094.DCLGE_MOVDEBCE_SAP.GE094_NSAS.ToString(),
            };

            var executed_1 = R1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1.Execute(r1020_LE_MOVDEBCC_SAP_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVDEBCE_NUM_REQUISICAO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO);
            }


        }

        [StopWatch]
        /*" RXXXX-ROTINA-RETORNO */
        private void RXXXX_ROTINA_RETORNO(bool isPerform = false)
        {
            /*" -840- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: RXXXX_EXIT*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -849- DISPLAY '**************************************************' */
            _.Display($"**************************************************");

            /*" -850- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -851- DISPLAY '*            SUB-ROTINA SISAP03B                  *' */
            _.Display($"*            SUB-ROTINA SISAP03B                  *");

            /*" -852- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -853- DISPLAY '*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *' */
            _.Display($"*  ROTINA DE GRAVACAO DAS TABELAS DE CONTROLE DE *");

            /*" -854- DISPLAY '*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *' */
            _.Display($"*  INTERFACE DOS SISTEMAS LEGADOS COM O SAP      *");

            /*" -855- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -856- DISPLAY '*  CONDICAO ANORMAL DE BANCO                     *' */
            _.Display($"*  CONDICAO ANORMAL DE BANCO                     *");

            /*" -858- DISPLAY '*                                                *' */
            _.Display($"*                                                *");

            /*" -859- MOVE '1' TO LK-IDLG-RET-CODIGO-RETORNO */
            _.Move("1", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO);

            /*" -861- MOVE 'INDISPONIBILIDADE DO BANCO OU PGM' TO LK-IDLG-RET-MENSAGEM */
            _.Move("INDISPONIBILIDADE DO BANCO OU PGM", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM);

            /*" -864- DISPLAY '=> ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO ' LK-IDLG-RET-MENSAGEM */
            _.Display($"=> ERRO OCORRIDO - RETORNO PELA ROTINA DE ERRO {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM}");

            /*" -865- MOVE SQLCODE TO WSL-SQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WSL_SQLCODE);

            /*" -867- DISPLAY '=> SQLCODE ' WSL-SQLCODE. */
            _.Display($"=> SQLCODE {AREA_DE_WORK.WSL_SQLCODE}");

            /*" -868- DISPLAY '=> **************************** <=' */
            _.Display($"=> **************************** <=");

            /*" -869- DISPLAY '=> FEITO ROLLBACK E STOP RUN    <=' */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_EXIT*/

        [StopWatch]
        /*" R100000-DISPLAY-RETORNO */
        private void R100000_DISPLAY_RETORNO(bool isPerform = false)
        {
            /*" -887- DISPLAY 'DADOS DE RETORNO' */
            _.Display($"DADOS DE RETORNO");

            /*" -895- DISPLAY 'LK-IDLG-DADOS-RETORNO ....... ' LK-IDLG-DADOS-RETORNO. */
            _.Display($"LK-IDLG-DADOS-RETORNO ....... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO}");

            /*" -900- DISPLAY 'LK-IDLG-RET-EH-SINISTRO ..... ' LK-IDLG-RET-EH-SINISTRO */
            _.Display($"LK-IDLG-RET-EH-SINISTRO ..... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_EH_SINISTRO}");

            /*" -902- DISPLAY 'LK-IDLG-RET-NUM-APOL-SINISTRO ..... ' LK-IDLG-RET-NUM-APOL-SINISTRO */
            _.Display($"LK-IDLG-RET-NUM-APOL-SINISTRO ..... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_NUM_APOL_SINISTRO}");

            /*" -904- DISPLAY 'LK-IDLG-RET-OCORR-HISTORICO ....... ' LK-IDLG-RET-OCORR-HISTORICO */
            _.Display($"LK-IDLG-RET-OCORR-HISTORICO ....... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_OCORR_HISTORICO}");

            /*" -912- DISPLAY 'LK-IDLG-RET-COD-OPERACAO .......... ' LK-IDLG-RET-COD-OPERACAO */
            _.Display($"LK-IDLG-RET-COD-OPERACAO .......... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_OPERACAO}");

            /*" -914- DISPLAY 'LK-IDLG-RET-COD-PAGA-RECEBE ....... ' LK-IDLG-RET-COD-PAGA-RECEBE */
            _.Display($"LK-IDLG-RET-COD-PAGA-RECEBE ....... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_PAGA_RECEBE}");

            /*" -923- DISPLAY 'LK-IDLG-RET-COD-PAGA-TEXTO ........ ' LK-IDLG-RET-COD-PAGA-TEXTO */
            _.Display($"LK-IDLG-RET-COD-PAGA-TEXTO ........ {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_PAGA_TEXTO}");

            /*" -925- DISPLAY 'LK-IDLG-RET-COD-FINANC ............ ' LK-IDLG-RET-COD-FINANC */
            _.Display($"LK-IDLG-RET-COD-FINANC ............ {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC}");

            /*" -937- DISPLAY 'LK-IDLG-RET-COD-FINANC-TEXTO ...... ' LK-IDLG-RET-COD-FINANC-TEXTO */
            _.Display($"LK-IDLG-RET-COD-FINANC-TEXTO ...... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_COD_FINANC_TEXTO}");

            /*" -939- DISPLAY 'LK-IDLG-RET-LAYOUT ................ ' LK-IDLG-RET-LAYOUT */
            _.Display($"LK-IDLG-RET-LAYOUT ................ {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT}");

            /*" -944- DISPLAY 'LK-IDLG-RET-LAYOUT-TEXTO........... ' LK-IDLG-RET-LAYOUT-TEXTO */
            _.Display($"LK-IDLG-RET-LAYOUT-TEXTO........... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_LAYOUT_TEXTO}");

            /*" -946- DISPLAY 'LK-IDLG-RET-NUM-OCORR-MOVTO ....... ' LK-IDLG-RET-NUM-OCORR-MOVTO */
            _.Display($"LK-IDLG-RET-NUM-OCORR-MOVTO ....... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_NUM_OCORR_MOVTO}");

            /*" -951- DISPLAY 'LK-IDLG-RET-IDE-SISTEMA ........... ' LK-IDLG-RET-IDE-SISTEMA */
            _.Display($"LK-IDLG-RET-IDE-SISTEMA ........... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_IDE_SISTEMA}");

            /*" -953- DISPLAY 'LK-IDLG-RET-MOVDEB-NUM-APOLICE .... ' LK-IDLG-RET-MOVDEB-NUM-APOLICE */
            _.Display($"LK-IDLG-RET-MOVDEB-NUM-APOLICE .... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NUM_APOLICE}");

            /*" -955- DISPLAY 'LK-IDLG-RET-MOVDEB-NUM-ENDOSSO  ... ' LK-IDLG-RET-MOVDEB-NUM-ENDOSSO */
            _.Display($"LK-IDLG-RET-MOVDEB-NUM-ENDOSSO  ... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NUM_ENDOSSO}");

            /*" -957- DISPLAY 'LK-IDLG-RET-MOVDEB-PARCELA  ....... ' LK-IDLG-RET-MOVDEB-PARCELA */
            _.Display($"LK-IDLG-RET-MOVDEB-PARCELA  ....... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_PARCELA}");

            /*" -959- DISPLAY 'LK-IDLG-RET-MOVDEB-CONVENIO  ...... ' LK-IDLG-RET-MOVDEB-CONVENIO */
            _.Display($"LK-IDLG-RET-MOVDEB-CONVENIO  ...... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_CONVENIO}");

            /*" -961- DISPLAY 'LK-IDLG-RET-MOVDEB-NSAS-ENVIO  .... ' LK-IDLG-RET-MOVDEB-NSAS-ENVIO */
            _.Display($"LK-IDLG-RET-MOVDEB-NSAS-ENVIO  .... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NSAS_ENVIO}");

            /*" -966- DISPLAY 'LK-IDLG-RET-MOVDEB-NUM-REQUISI  ... ' LK-IDLG-RET-MOVDEB-NUM-REQUISI */
            _.Display($"LK-IDLG-RET-MOVDEB-NUM-REQUISI  ... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MOVDEB_NUM_REQUISI}");

            /*" -971- DISPLAY 'LK-IDLG-RET-CHQ-CHQINT ............ ' LK-IDLG-RET-CHQ-CHQINT */
            _.Display($"LK-IDLG-RET-CHQ-CHQINT ............ {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CHQ_CHQINT}");

            /*" -973- DISPLAY 'LK-IDLG-RET-RESSARC-NUM-ACORDO .... ' LK-IDLG-RET-RESSARC-NUM-ACORDO */
            _.Display($"LK-IDLG-RET-RESSARC-NUM-ACORDO .... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_RESSARC_NUM_ACORDO}");

            /*" -978- DISPLAY 'LK-IDLG-RET-RESSARC-PARCELA ....... ' LK-IDLG-RET-RESSARC-PARCELA */
            _.Display($"LK-IDLG-RET-RESSARC-PARCELA ....... {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_RESSARC_PARCELA}");

            /*" -980- DISPLAY 'LK-IDLG-RET-CODIGO-RETORNO ........ ' LK-IDLG-RET-CODIGO-RETORNO */
            _.Display($"LK-IDLG-RET-CODIGO-RETORNO ........ {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_CODIGO_RETORNO}");

            /*" -981- DISPLAY 'LK-IDLG-RET-MENSAGEM .............. ' LK-IDLG-RET-MENSAGEM . */
            _.Display($"LK-IDLG-RET-MENSAGEM .............. {LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA.LK_IDLG_DADOS_RETORNO.LK_IDLG_RET_MENSAGEM}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R100000_EXIT*/

        [StopWatch]
        /*" R20000-SIMULACAO-EXECUCAO */
        private void R20000_SIMULACAO_EXECUCAO(bool isPerform = false)
        {
            /*" -986- MOVE ALL '?' TO LK-IDLG-DADOS-ENTRADA. */
            _.MoveAll("?", LK_IDLG_REGISTRO_SINISTRO.LK_IDLG_DADOS_ENTRADA);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R20000_EXIT*/
    }
}