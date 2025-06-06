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
using Sias.VidaEmGrupo.DB2.VG0016B;

namespace Code
{
    public class VG0016B
    {
        public bool IsCall { get; set; }

        public VG0016B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *---------------------------------------                                */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VG - SIAS                          *      */
        /*"      *   PROGRAMA ................ VG0016B                            *      */
        /*"      *   Esse programa ir� VOLTAR Certificados/Bilhetes que est�o            */
        /*"      *   com STA_ACOPLADO = 7 (aguardando pedido de renova��o) para          */
        /*"      *   Sta_Acoplado = 9 , quando esses estiverem Cancelados.               */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  RAUL BASILI ROTTA                  *      */
        /*"      *   DESENVOLVEDOR ..........  RAUL BASILI ROTTA                  *      */
        /*"      *   DATA CODIFICACAO .......  27/03/2024                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  Voltar o Aguardando pedido de             */
        /*"      *                             RENOVA��O                          *      */
        /*"      *                             para STA_ACOPLADO = 9                     */
        /*"      *                             na tabela de VG_ACOPLADO.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            DCLGEN               ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          SISTEMAS             INPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 27/03/2024 RAUL ROTTA        V.00   DESENVOLVIMENTO            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   WHOST-DTCURRENT            PIC  X(010)  VALUE SPACES.*/
        public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77   WHOST-DIA-REFER            PIC S9(004)  VALUE +0 COMP.*/
        public IntBasis WHOST_DIA_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01   WHOST-DT.*/
        public VG0016B_WHOST_DT WHOST_DT { get; set; } = new VG0016B_WHOST_DT();
        public class VG0016B_WHOST_DT : VarBasis
        {
            /*"  05   WHOST-DT-INI             PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05   WHOST-DT-FIM             PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  WS-DATAS.*/
        }
        public VG0016B_WS_DATAS WS_DATAS { get; set; } = new VG0016B_WS_DATAS();
        public class VG0016B_WS_DATAS : VarBasis
        {
            /*"   05 WS-C-DATE-CURRENT              PIC  X(014) VALUE SPACES.*/
            public StringBasis WS_C_DATE_CURRENT { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
            /*"   05 WS-C-DATE-COMPILED             PIC  X(014) VALUE SPACES.*/
            public StringBasis WS_C_DATE_COMPILED { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
            /*"   05 WS-CURRENT-TIMESTAMP           PIC  X(026) VALUE SPACES.*/
            public StringBasis WS_CURRENT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"01     WS-CALL                  PIC  X(008) VALUE SPACES.*/
        }
        public StringBasis WS_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01        AREA-DE-WORK.*/
        public VG0016B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0016B_AREA_DE_WORK();
        public class VG0016B_AREA_DE_WORK : VarBasis
        {
            /*"  05      WSTATUS               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSL-SQLCODE           PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WFIM-RELATORIO         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-RELATORIO-DT-PF   PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_RELATORIO_DT_PF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WS-ORIGEM-CANCELAMENTO PIC  X(030)      VALUE SPACES.*/
            public StringBasis WS_ORIGEM_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"  05      WS-DIF-CONT           PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WS_DIF_CONT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-COUNT              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-COUNT-DT-NASC-PF   PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_COUNT_DT_NASC_PF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-RELATORI         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_RELATORI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-UPDATES          PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_UPDATES { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-INSERT-HIST      PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_INSERT_HIST { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-G-VG0016B         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_G_VG0016B { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WS-DTH-CANCELAMENTO   PIC  X(010)      VALUE SPACES.*/
            public StringBasis WS_DTH_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WS-COD-DOC-PARCEIRO-P PIC S9(18) USAGE COMP                                                 VALUE ZEROS.*/
            public IntBasis WS_COD_DOC_PARCEIRO_P { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
            /*"  05      WS-NUM-CERTIFICADO    PIC S9(15)V USAGE COMP-3                                                 VALUE ZEROS.*/
            public DoubleBasis WS_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
            /*"  05 WS-COD-PRODUTO             PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis WS_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 WS-COD-PLANO               PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis WS_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 WS-NUM-SERIE               PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis WS_NUM_SERIE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 WS-NUM-TITULO              PIC S9(09) COMP VALUE ZEROS.*/
            public IntBasis WS_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
            /*"  05 WS-STA-TITULO              PIC  X(03)      VALUE SPACES.*/
            public StringBasis WS_STA_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 WS-COD-SUB-TITULO          PIC  X(03)      VALUE SPACES.*/
            public StringBasis WS_COD_SUB_TITULO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"  05 WS-DTH-ATIVACAO            PIC  X(26)      VALUE SPACES.*/
            public StringBasis WS_DTH_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
            /*"  05 WS-DTA-CADUCACAO           PIC  X(10)      VALUE SPACES.*/
            public StringBasis WS_DTA_CADUCACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 WS-DTH-CRIACAO             PIC  X(26)      VALUE SPACES.*/
            public StringBasis WS_DTH_CRIACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)"), @"");
            /*"  05 WS-DTA-FIM-VIGENCIA        PIC  X(10)      VALUE SPACES.*/
            public StringBasis WS_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 WS-DTA-INI-SORTEIO         PIC  X(10)      VALUE SPACES.*/
            public StringBasis WS_DTA_INI_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 WS-DTA-INI-VIGENCIA        PIC  X(10)      VALUE SPACES.*/
            public StringBasis WS_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 WS-DTA-SUSPENSAO           PIC  X(10)      VALUE SPACES.*/
            public StringBasis WS_DTA_SUSPENSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"  05 WS-COD-DV                  PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis WS_COD_DV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 WS-VLR-MENSALIDADE         PIC S9(8)V9(2) USAGE COMP-3.*/
            public DoubleBasis WS_VLR_MENSALIDADE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
            /*"  05 WS-NUM-MOD-PLANO           PIC S9(04) COMP VALUE ZEROS.*/
            public IntBasis WS_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05 WS-DES-COMBINACAO          PIC  X(20)      VALUE SPACES.*/
            public StringBasis WS_DES_COMBINACAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)"), @"");
            /*"  05 WS-IDE-SISTEMA             PIC  X(02)      VALUE SPACES.*/
            public StringBasis WS_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"");
            /*"  05      WS-COD-DOC-PARCEIRO   PIC  X(015)      VALUE SPACES.*/
            public StringBasis WS_COD_DOC_PARCEIRO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  05      WS-COD-DOC-PARCEIRO-R REDEFINES   WS-COD-DOC-PARCEIRO.*/
            private _REDEF_VG0016B_WS_COD_DOC_PARCEIRO_R _ws_cod_doc_parceiro_r { get; set; }
            public _REDEF_VG0016B_WS_COD_DOC_PARCEIRO_R WS_COD_DOC_PARCEIRO_R
            {
                get { _ws_cod_doc_parceiro_r = new _REDEF_VG0016B_WS_COD_DOC_PARCEIRO_R(); _.Move(WS_COD_DOC_PARCEIRO, _ws_cod_doc_parceiro_r); VarBasis.RedefinePassValue(WS_COD_DOC_PARCEIRO, _ws_cod_doc_parceiro_r, WS_COD_DOC_PARCEIRO); _ws_cod_doc_parceiro_r.ValueChanged += () => { _.Move(_ws_cod_doc_parceiro_r, WS_COD_DOC_PARCEIRO); }; return _ws_cod_doc_parceiro_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cod_doc_parceiro_r, WS_COD_DOC_PARCEIRO); }
            }  //Redefines
            public class _REDEF_VG0016B_WS_COD_DOC_PARCEIRO_R : VarBasis
            {
                /*"    10    WS-COD-DOC-PARCEIRO-N PIC  9(015).*/
                public IntBasis WS_COD_DOC_PARCEIRO_N { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"  05      WDATA-REFER           PIC  X(010)      VALUE SPACES.*/

                public _REDEF_VG0016B_WS_COD_DOC_PARCEIRO_R()
                {
                    WS_COD_DOC_PARCEIRO_N.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-REF-R           REDEFINES        WDATA-REFER.*/
            private _REDEF_VG0016B_WDATA_REF_R _wdata_ref_r { get; set; }
            public _REDEF_VG0016B_WDATA_REF_R WDATA_REF_R
            {
                get { _wdata_ref_r = new _REDEF_VG0016B_WDATA_REF_R(); _.Move(WDATA_REFER, _wdata_ref_r); VarBasis.RedefinePassValue(WDATA_REFER, _wdata_ref_r, WDATA_REFER); _wdata_ref_r.ValueChanged += () => { _.Move(_wdata_ref_r, WDATA_REFER); }; return _wdata_ref_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_ref_r, WDATA_REFER); }
            }  //Redefines
            public class _REDEF_VG0016B_WDATA_REF_R : VarBasis
            {
                /*"    10    WDAT-ANO-REF          PIC  9(004).*/
                public IntBasis WDAT_ANO_REF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-MES-REF          PIC  9(002).*/
                public IntBasis WDAT_MES_REF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-DIA-REF          PIC  9(002).*/
                public IntBasis WDAT_DIA_REF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-CURR            PIC  X(010)      VALUE SPACES.*/

                public _REDEF_VG0016B_WDATA_REF_R()
                {
                    WDAT_ANO_REF.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WDAT_MES_REF.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_DIA_REF.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-CURR-R          REDEFINES        WDATA-CURR.*/
            private _REDEF_VG0016B_WDATA_CURR_R _wdata_curr_r { get; set; }
            public _REDEF_VG0016B_WDATA_CURR_R WDATA_CURR_R
            {
                get { _wdata_curr_r = new _REDEF_VG0016B_WDATA_CURR_R(); _.Move(WDATA_CURR, _wdata_curr_r); VarBasis.RedefinePassValue(WDATA_CURR, _wdata_curr_r, WDATA_CURR); _wdata_curr_r.ValueChanged += () => { _.Move(_wdata_curr_r, WDATA_CURR); }; return _wdata_curr_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_curr_r, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_VG0016B_WDATA_CURR_R : VarBasis
            {
                /*"    10    WDATA-AA-CURR         PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-MM-CURR         PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDATA-DD-CURR         PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-EDIT.*/

                public _REDEF_VG0016B_WDATA_CURR_R()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public VG0016B_WDATA_EDIT WDATA_EDIT { get; set; } = new VG0016B_WDATA_EDIT();
            public class VG0016B_WDATA_EDIT : VarBasis
            {
                /*"    10    WDAT-DIA-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-MES-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-ANO-EDT          PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDAT_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WHORA-CURR.*/
            }
            public VG0016B_WHORA_CURR WHORA_CURR { get; set; } = new VG0016B_WHORA_CURR();
            public class VG0016B_WHORA_CURR : VarBasis
            {
                /*"    10    WHORA-HH-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-MM-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-SS-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WHORA-CC-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WHORA-EDIT.*/
            }
            public VG0016B_WHORA_EDIT WHORA_EDIT { get; set; } = new VG0016B_WHORA_EDIT();
            public class VG0016B_WHORA_EDIT : VarBasis
            {
                /*"    10    WHORA-HH-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-MM-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-SS-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05  WS-EDIT.*/
            }
            public VG0016B_WS_EDIT WS_EDIT { get; set; } = new VG0016B_WS_EDIT();
            public class VG0016B_WS_EDIT : VarBasis
            {
                /*"   10 WS-SMALLINT                    PIC ZZ.ZZ9- OCCURS 20 TIMES*/
                public ListBasis<IntBasis, Int64> WS_SMALLINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "6", "ZZ.ZZ9-"), 20);
                /*"   10 WS-INTEGER                     PIC Z.ZZZ.ZZZ.ZZ9-                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "11", "Z.ZZZ.ZZZ.ZZ9-"), 5);
                /*"   10 WS-BIGINT                      PIC 99999999999999                                                 OCCURS 5 TIMES.*/
                public ListBasis<IntBasis, Int64> WS_BIGINT { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "14", "99999999999999"), 5);
                /*"   10 WS-DECIMAL                     PIC ZZZZZZZZZZ9,999999                                                 OCCURS 10 TIMES*/
                public ListBasis<DoubleBasis, double> WS_DECIMAL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "11", "ZZZZZZZZZZ9V999999"), 10);
                /*"   10 WS-TAXA                        PIC 9,99999-                                                 OCCURS 5 TIMES.*/
                public ListBasis<DoubleBasis, double> WS_TAXA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("9", "1", "9V99999-"), 5);
                /*"  05  WS-ERRO.*/
            }
            public VG0016B_WS_ERRO WS_ERRO { get; set; } = new VG0016B_WS_ERRO();
            public class VG0016B_WS_ERRO : VarBasis
            {
                /*"   10 WS-SECTION                     PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SECTION { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-SQLSTATE                    PIC  X(005) VALUE SPACES.*/
                public StringBasis WS_SQLSTATE { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"   10 WS-MENSAGEM                    PIC  X(255) VALUE SPACES.*/
                public StringBasis WS_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "255", "X(255)"), @"");
                /*"   10 WS-TABELA                      PIC  X(050) VALUE SPACES.*/
                public StringBasis WS_TABELA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"   10 WS-IND-ERRO                    PIC  9(001) VALUE 0.*/
                public IntBasis WS_IND_ERRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"01        WABEND.*/
            }
        }
        public VG0016B_WABEND WABEND { get; set; } = new VG0016B_WABEND();
        public class VG0016B_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(010)      VALUE         ' VG0016B'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0016B");
            /*"  05      FILLER                PIC  X(026)      VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL          PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER                PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WS-SQLCODE            PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            /*"  05      WS-SQLERRMC           PIC  X(40)       VALUE SPACES.*/
            public StringBasis WS_SQLERRMC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
        }


        public Copies.SPVG014W SPVG014W { get; set; } = new Copies.SPVG014W();
        public Copies.SPVG013W SPVG013W { get; set; } = new Copies.SPVG013W();
        public Copies.LBHCT002 LBHCT002 { get; set; } = new Copies.LBHCT002();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.VG135 VG135 { get; set; } = new Dclgens.VG135();
        public Dclgens.VG137 VG137 { get; set; } = new Dclgens.VG137();
        public Dclgens.VG139 VG139 { get; set; } = new Dclgens.VG139();
        public Dclgens.VG136 VG136 { get; set; } = new Dclgens.VG136();
        public Dclgens.VG140 VG140 { get; set; } = new Dclgens.VG140();
        public VG0016B_ACOPLADO ACOPLADO { get; set; } = new VG0016B_ACOPLADO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -248- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -249- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -252- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -255- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -277- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -278- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -279- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -280- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -285- DISPLAY 'INICIO VG0016B            ' WHORA-EDIT. */
            _.Display($"INICIO VG0016B            {AREA_DE_WORK.WHORA_EDIT}");

            /*" -286- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -287- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -288- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -289- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -291- DISPLAY 'INICIO DECLARE            ' WHORA-EDIT. */
            _.Display($"INICIO DECLARE            {AREA_DE_WORK.WHORA_EDIT}");

            /*" -293- PERFORM R0400-00-DECLARE-ACOPLADO. */

            R0400_00_DECLARE_ACOPLADO_SECTION();

            /*" -294- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -295- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -296- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -297- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -299- DISPLAY 'FINAL DECLARE             ' WHORA-EDIT. */
            _.Display($"FINAL DECLARE             {AREA_DE_WORK.WHORA_EDIT}");

            /*" -301- PERFORM R0500-00-FETCH-ACOPLADO. */

            R0500_00_FETCH_ACOPLADO_SECTION();

            /*" -303- DISPLAY 'WFIM-RELATORIO..: ' WFIM-RELATORIO */
            _.Display($"WFIM-RELATORIO..: {AREA_DE_WORK.WFIM_RELATORIO}");

            /*" -304- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_RELATORIO.IsEmpty())
            {

                /*" -305- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -306- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -308- END-IF. */
            }


            /*" -311- PERFORM R0600-PROCESSA-ACOPLADO UNTIL WFIM-RELATORIO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_RELATORIO.IsEmpty()))
            {

                R0600_PROCESSA_ACOPLADO_SECTION();
            }

            /*" -312- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -313- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -314- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -315- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -315- DISPLAY 'FINAL  VG0016B         ' WHORA-EDIT. */
            _.Display($"FINAL  VG0016B         {AREA_DE_WORK.WHORA_EDIT}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -321- DISPLAY 'QTDE. DE REGISTROS ' . */
            _.Display($"QTDE. DE REGISTROS ");

            /*" -325- DISPLAY 'LIDOS para garavar VG_ACOPLADOS_TITULO   - ' AC-L-RELATORI. */
            _.Display($"LIDOS para garavar VG_ACOPLADOS_TITULO   - {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -327- DISPLAY '*--- VG0016B  -  FIM  NORMAL ---*' . */
            _.Display($"*--- VG0016B  -  FIM  NORMAL ---*");

            /*" -327- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -331- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -331- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-ACOPLADO-SECTION */
        private void R0400_00_DECLARE_ACOPLADO_SECTION()
        {
            /*" -341- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -390- INITIALIZE DCLVG-ACOPLADO-TITULO WFIM-RELATORIO LK-VG013-TRACE LK-VG013-SISTEMA-CHAMADOR LK-VG013-CANAL LK-VG013-ORIGEM LK-VG013-COD-USUARIO LK-VG013-TIPO-ACAO LK-VG013-IDE-SISTEMA LK-VG013-NUM-CERTIFICADO LK-VG013-COD-PRODUTO LK-VG013-COD-PLANO LK-VG013-QTD-TITULO LK-VG013-VLR-TITULO LK-VG013-COD-EMPRESA-CAP LK-VG013-COD-RETORNO-API LK-VG013-DES-ERRO LK-VG013-DES-ACAO WS-NUM-CERTIFICADO WS-COD-DOC-PARCEIRO-P WS-COD-PRODUTO WS-COD-PLANO WS-NUM-SERIE WS-NUM-TITULO WS-STA-TITULO WS-COD-SUB-TITULO WS-DTH-ATIVACAO WS-DTA-CADUCACAO WS-DTH-CRIACAO WS-DTA-FIM-VIGENCIA WS-DTA-INI-SORTEIO WS-DTA-INI-VIGENCIA WS-DTA-SUSPENSAO WS-COD-DV WS-VLR-MENSALIDADE WS-NUM-MOD-PLANO WS-DES-COMBINACAO WS-IDE-SISTEMA */
            _.Initialize(
                VG136.DCLVG_ACOPLADO_TITULO
                , AREA_DE_WORK.WFIM_RELATORIO
                , SPVG013W.LK_VG013_TRACE
                , SPVG013W.LK_VG013_SISTEMA_CHAMADOR
                , SPVG013W.LK_VG013_CANAL
                , SPVG013W.LK_VG013_ORIGEM
                , SPVG013W.LK_VG013_COD_USUARIO
                , SPVG013W.LK_VG013_TIPO_ACAO
                , SPVG013W.LK_VG013_IDE_SISTEMA
                , SPVG013W.LK_VG013_NUM_CERTIFICADO
                , SPVG013W.LK_VG013_COD_PRODUTO
                , SPVG013W.LK_VG013_COD_PLANO
                , SPVG013W.LK_VG013_QTD_TITULO
                , SPVG013W.LK_VG013_VLR_TITULO
                , SPVG013W.LK_VG013_COD_EMPRESA_CAP
                , SPVG013W.LK_VG013_COD_RETORNO_API
                , SPVG013W.LK_VG013_DES_ERRO
                , SPVG013W.LK_VG013_DES_ACAO
                , AREA_DE_WORK.WS_NUM_CERTIFICADO
                , AREA_DE_WORK.WS_COD_DOC_PARCEIRO_P
                , AREA_DE_WORK.WS_COD_PRODUTO
                , AREA_DE_WORK.WS_COD_PLANO
                , AREA_DE_WORK.WS_NUM_SERIE
                , AREA_DE_WORK.WS_NUM_TITULO
                , AREA_DE_WORK.WS_STA_TITULO
                , AREA_DE_WORK.WS_COD_SUB_TITULO
                , AREA_DE_WORK.WS_DTH_ATIVACAO
                , AREA_DE_WORK.WS_DTA_CADUCACAO
                , AREA_DE_WORK.WS_DTH_CRIACAO
                , AREA_DE_WORK.WS_DTA_FIM_VIGENCIA
                , AREA_DE_WORK.WS_DTA_INI_SORTEIO
                , AREA_DE_WORK.WS_DTA_INI_VIGENCIA
                , AREA_DE_WORK.WS_DTA_SUSPENSAO
                , AREA_DE_WORK.WS_COD_DV
                , AREA_DE_WORK.WS_VLR_MENSALIDADE
                , AREA_DE_WORK.WS_NUM_MOD_PLANO
                , AREA_DE_WORK.WS_DES_COMBINACAO
                , AREA_DE_WORK.WS_IDE_SISTEMA
            );

            /*" -483- PERFORM R0400_00_DECLARE_ACOPLADO_DB_DECLARE_1 */

            R0400_00_DECLARE_ACOPLADO_DB_DECLARE_1();

            /*" -485- PERFORM R0400_00_DECLARE_ACOPLADO_DB_OPEN_1 */

            R0400_00_DECLARE_ACOPLADO_DB_OPEN_1();

            /*" -488- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -489- DISPLAY 'R0400 - ERRO NO R0400-00-DECLARE-ACOPLADO' */
                _.Display($"R0400 - ERRO NO R0400-00-DECLARE-ACOPLADO");

                /*" -490- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                /*" -491- DISPLAY 'SQLCODE: ' WS-SQLCODE */
                _.Display($"SQLCODE: {WABEND.WS_SQLCODE}");

                /*" -492- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -493- ELSE */
            }
            else
            {


                /*" -494- MOVE SPACES TO WFIM-RELATORIO */
                _.Move("", AREA_DE_WORK.WFIM_RELATORIO);

                /*" -494- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-ACOPLADO-DB-DECLARE-1 */
        public void R0400_00_DECLARE_ACOPLADO_DB_DECLARE_1()
        {
            /*" -483- EXEC SQL DECLARE ACOPLADO CURSOR FOR SELECT A.IDE_SISTEMA , A.NUM_CERTIFICADO , A.COD_PRODUTO , A.COD_PLANO FROM SEGUROS.VG_ACOPLADO A WHERE A.IDE_SISTEMA = 'VG' AND A.NUM_CERTIFICADO > 0 AND A.STA_ACOPLADO = 7 AND A.COD_PLANO > 800 AND A.COD_PRODUTO > 0 AND EXISTS ( SELECT * FROM SEGUROS.PROPOSTAS_VA C WHERE C.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.SIT_REGISTRO NOT IN ( '3' , '6' ) FETCH FIRST 1 ROWS ONLY ) UNION SELECT A.IDE_SISTEMA , A.NUM_CERTIFICADO , A.COD_PRODUTO , A.COD_PLANO FROM SEGUROS.VG_ACOPLADO A WHERE A.IDE_SISTEMA = 'VG' AND A.NUM_CERTIFICADO > 0 AND A.STA_ACOPLADO = 7 AND A.COD_PLANO > 800 AND A.COD_PRODUTO > 0 AND EXISTS ( SELECT * FROM SEGUROS.BILHETE C WHERE C.NUM_BILHETE = A.NUM_CERTIFICADO AND C.SITUACAO <> '9' FETCH FIRST 1 ROWS ONLY ) UNION SELECT A.IDE_SISTEMA , A.NUM_CERTIFICADO , A.COD_PRODUTO , A.COD_PLANO FROM SEGUROS.VG_ACOPLADO A , SEGUROS.VG_ACOPLADO_TITULO B WHERE A.IDE_SISTEMA = 'SZ' AND A.NUM_CERTIFICADO > 0 AND A.STA_ACOPLADO = 7 AND A.COD_PLANO > 800 AND A.COD_PRODUTO > 0 AND A.COD_PLANO = B.COD_PLANO AND A.COD_PRODUTO = B.COD_PRODUTO AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.IDE_SISTEMA = B.IDE_SISTEMA and B.num_titulo = (select max(C.num_titulo) FROM SEGUROS.VG_ACOPLADO_TITULO C where C.NUM_CERTIFICADO = B.NUM_CERTIFICADO and C.COD_plano = B.COD_plano and C.cod_PRODUTO = B.cod_PRODUTO ) and B.num_serie = (select max(d.num_serie) FROM SEGUROS.VG_ACOPLADO_TITULO d where d.NUM_CERTIFICADO = B.NUM_CERTIFICADO and d.COD_plano = B.COD_plano and d.cod_PRODUTO = B.cod_PRODUTO and d.num_titulo = B.num_titulo ) AND EXISTS ( SELECT * FROM SEGUROS.SZ_CONTR_TERC SZ012 , SEGUROS.SZ_OBJ_ACOPLADO_CAP SZ029 WHERE SZ012.NUM_CONTRATO = SZ029.NUM_CONTRATO AND SZ029.NUM_PROP_TITULO = A.NUM_CERTIFICADO AND SZ029.NUM_PLANO = A.COD_PLANO AND SZ029.NUM_SERIE = B.NUM_SERIE AND SZ029.NUM_TITULO = B.NUM_TITULO AND SZ012.STA_CONTRATO_TERC <> 'A' FETCH FIRST 1 ROWS ONLY ) WITH UR END-EXEC. */
            ACOPLADO = new VG0016B_ACOPLADO(false);
            string GetQuery_ACOPLADO()
            {
                var query = @$"SELECT A.IDE_SISTEMA 
							, A.NUM_CERTIFICADO 
							, A.COD_PRODUTO 
							, A.COD_PLANO 
							FROM SEGUROS.VG_ACOPLADO A 
							WHERE A.IDE_SISTEMA = 'VG' 
							AND A.NUM_CERTIFICADO > 0 
							AND A.STA_ACOPLADO = 7 
							AND A.COD_PLANO > 800 
							AND A.COD_PRODUTO > 0 
							AND EXISTS ( SELECT * 
							FROM SEGUROS.PROPOSTAS_VA C 
							WHERE C.NUM_CERTIFICADO = 
							A.NUM_CERTIFICADO 
							AND C.SIT_REGISTRO NOT IN 
							( '3'
							, '6' ) 
							FETCH FIRST 1 ROWS ONLY 
							) 
							UNION 
							SELECT A.IDE_SISTEMA 
							, A.NUM_CERTIFICADO 
							, A.COD_PRODUTO 
							, A.COD_PLANO 
							FROM SEGUROS.VG_ACOPLADO A 
							WHERE A.IDE_SISTEMA = 'VG' 
							AND A.NUM_CERTIFICADO > 0 
							AND A.STA_ACOPLADO = 7 
							AND A.COD_PLANO > 800 
							AND A.COD_PRODUTO > 0 
							AND EXISTS ( SELECT * 
							FROM SEGUROS.BILHETE C 
							WHERE C.NUM_BILHETE = 
							A.NUM_CERTIFICADO 
							AND C.SITUACAO <> '9' 
							FETCH FIRST 1 ROWS ONLY 
							) 
							UNION 
							SELECT A.IDE_SISTEMA 
							, A.NUM_CERTIFICADO 
							, A.COD_PRODUTO 
							, A.COD_PLANO 
							FROM SEGUROS.VG_ACOPLADO A 
							, SEGUROS.VG_ACOPLADO_TITULO B 
							WHERE A.IDE_SISTEMA = 'SZ' 
							AND A.NUM_CERTIFICADO > 0 
							AND A.STA_ACOPLADO = 7 
							AND A.COD_PLANO > 800 
							AND A.COD_PRODUTO > 0 
							AND A.COD_PLANO = B.COD_PLANO 
							AND A.COD_PRODUTO = B.COD_PRODUTO 
							AND A.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							AND A.IDE_SISTEMA = B.IDE_SISTEMA 
							and B.num_titulo = 
							(select max(C.num_titulo) 
							FROM SEGUROS.VG_ACOPLADO_TITULO C 
							where C.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							and C.COD_plano = B.COD_plano 
							and C.cod_PRODUTO = B.cod_PRODUTO 
							) 
							and B.num_serie = 
							(select max(d.num_serie) 
							FROM SEGUROS.VG_ACOPLADO_TITULO d 
							where d.NUM_CERTIFICADO = B.NUM_CERTIFICADO 
							and d.COD_plano = B.COD_plano 
							and d.cod_PRODUTO = B.cod_PRODUTO 
							and d.num_titulo = B.num_titulo 
							) 
							AND EXISTS ( SELECT * 
							FROM SEGUROS.SZ_CONTR_TERC SZ012 
							, SEGUROS.SZ_OBJ_ACOPLADO_CAP SZ029 
							WHERE SZ012.NUM_CONTRATO = 
							SZ029.NUM_CONTRATO 
							AND SZ029.NUM_PROP_TITULO = 
							A.NUM_CERTIFICADO 
							AND SZ029.NUM_PLANO = A.COD_PLANO 
							AND SZ029.NUM_SERIE = B.NUM_SERIE 
							AND SZ029.NUM_TITULO = B.NUM_TITULO 
							AND SZ012.STA_CONTRATO_TERC <> 'A' 
							FETCH FIRST 1 ROWS ONLY 
							)";

                return query;
            }
            ACOPLADO.GetQueryEvent += GetQuery_ACOPLADO;

        }

        [StopWatch]
        /*" R0400-00-DECLARE-ACOPLADO-DB-OPEN-1 */
        public void R0400_00_DECLARE_ACOPLADO_DB_OPEN_1()
        {
            /*" -485- EXEC SQL OPEN ACOPLADO END-EXEC. */

            ACOPLADO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-FETCH-ACOPLADO-SECTION */
        private void R0500_00_FETCH_ACOPLADO_SECTION()
        {
            /*" -508- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -514- PERFORM R0500_00_FETCH_ACOPLADO_DB_FETCH_1 */

            R0500_00_FETCH_ACOPLADO_DB_FETCH_1();

            /*" -517- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -518- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -519- MOVE 'S' TO WFIM-RELATORIO */
                    _.Move("S", AREA_DE_WORK.WFIM_RELATORIO);

                    /*" -519- PERFORM R0500_00_FETCH_ACOPLADO_DB_CLOSE_1 */

                    R0500_00_FETCH_ACOPLADO_DB_CLOSE_1();

                    /*" -521- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -522- ELSE */
                }
                else
                {


                    /*" -523- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                    /*" -524- MOVE SQLERRMC TO WS-SQLERRMC */
                    _.Move(DB.SQLERRMC, WABEND.WS_SQLERRMC);

                    /*" -526- DISPLAY '*------------------------------------------------*' */
                    _.Display($"*------------------------------------------------*");

                    /*" -527- DISPLAY '                         ' */
                    _.Display($"                         ");

                    /*" -528- DISPLAY 'R0500 - ERRO NO FETCH R0500-00-FETCH-ACOPLADO' */
                    _.Display($"R0500 - ERRO NO FETCH R0500-00-FETCH-ACOPLADO");

                    /*" -529- DISPLAY 'SQLCODE:  ' WS-SQLCODE */
                    _.Display($"SQLCODE:  {WABEND.WS_SQLCODE}");

                    /*" -531- DISPLAY 'SQLERRMC: ' WS-SQLERRMC '*------------------------------------------------*' */

                    $"SQLERRMC: {WABEND.WS_SQLERRMC}*------------------------------------------------*"
                    .Display();

                    /*" -532- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -533- END-IF */
                }


                /*" -535- END-IF. */
            }


            /*" -535- ADD 1 TO AC-L-RELATORI. */
            AREA_DE_WORK.AC_L_RELATORI.Value = AREA_DE_WORK.AC_L_RELATORI + 1;

        }

        [StopWatch]
        /*" R0500-00-FETCH-ACOPLADO-DB-FETCH-1 */
        public void R0500_00_FETCH_ACOPLADO_DB_FETCH_1()
        {
            /*" -514- EXEC SQL FETCH ACOPLADO INTO :WS-IDE-SISTEMA, :WS-COD-DOC-PARCEIRO-P , :WS-COD-PRODUTO, :WS-COD-PLANO END-EXEC. */

            if (ACOPLADO.Fetch())
            {
                _.Move(ACOPLADO.WS_IDE_SISTEMA, AREA_DE_WORK.WS_IDE_SISTEMA);
                _.Move(ACOPLADO.WS_COD_DOC_PARCEIRO_P, AREA_DE_WORK.WS_COD_DOC_PARCEIRO_P);
                _.Move(ACOPLADO.WS_COD_PRODUTO, AREA_DE_WORK.WS_COD_PRODUTO);
                _.Move(ACOPLADO.WS_COD_PLANO, AREA_DE_WORK.WS_COD_PLANO);
            }

        }

        [StopWatch]
        /*" R0500-00-FETCH-ACOPLADO-DB-CLOSE-1 */
        public void R0500_00_FETCH_ACOPLADO_DB_CLOSE_1()
        {
            /*" -519- EXEC SQL CLOSE ACOPLADO END-EXEC */

            ACOPLADO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-PROCESSA-ACOPLADO-SECTION */
        private void R0600_PROCESSA_ACOPLADO_SECTION()
        {
            /*" -553- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -555- IF AC-L-RELATORI GREATER 0 */

            if (AREA_DE_WORK.AC_L_RELATORI > 0)
            {

                /*" -559- PERFORM R0600_PROCESSA_ACOPLADO_DB_SELECT_1 */

                R0600_PROCESSA_ACOPLADO_DB_SELECT_1();

                /*" -562- MOVE WS-IDE-SISTEMA TO VG135-IDE-SISTEMA */
                _.Move(AREA_DE_WORK.WS_IDE_SISTEMA, VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA);

                /*" -563- MOVE WS-COD-DOC-PARCEIRO-P TO VG135-NUM-CERTIFICADO */
                _.Move(AREA_DE_WORK.WS_COD_DOC_PARCEIRO_P, VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO);

                /*" -564- MOVE WS-COD-PRODUTO TO VG135-COD-PRODUTO */
                _.Move(AREA_DE_WORK.WS_COD_PRODUTO, VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO);

                /*" -567- MOVE WS-COD-PLANO TO VG135-COD-PLANO */
                _.Move(AREA_DE_WORK.WS_COD_PLANO, VG135.DCLVG_ACOPLADO.VG135_COD_PLANO);

                /*" -574- INITIALIZE H-OUT-COD-RETORNO H-OUT-COD-RETORNO-SQL H-OUT-MENSAGEM H-OUT-SQLERRMC H-OUT-SQLSTATE */
                _.Initialize(
                    LBHCT002.H_OUT_COD_RETORNO
                    , LBHCT002.H_OUT_COD_RETORNO_SQL
                    , LBHCT002.H_OUT_MENSAGEM
                    , LBHCT002.H_OUT_SQLERRMC
                    , LBHCT002.H_OUT_SQLSTATE
                );

                /*" -576- PERFORM R0610-ATUALIZA-VG-ACOPLADO */

                R0610_ATUALIZA_VG_ACOPLADO_SECTION();

                /*" -576- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0600_90_LE_REGISTRO */

            R0600_90_LE_REGISTRO();

        }

        [StopWatch]
        /*" R0600-PROCESSA-ACOPLADO-DB-SELECT-1 */
        public void R0600_PROCESSA_ACOPLADO_DB_SELECT_1()
        {
            /*" -559- EXEC SQL SELECT CHAR(CURRENT TIMESTAMP) INTO :WS-CURRENT-TIMESTAMP FROM SYSIBM.SYSDUMMY1 END-EXEC */

            var r0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1 = new R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1.Execute(r0600_PROCESSA_ACOPLADO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_CURRENT_TIMESTAMP, WS_DATAS.WS_CURRENT_TIMESTAMP);
            }


        }

        [StopWatch]
        /*" R0600-90-LE-REGISTRO */
        private void R0600_90_LE_REGISTRO(bool isPerform = false)
        {
            /*" -582- PERFORM R0500-00-FETCH-ACOPLADO. */

            R0500_00_FETCH_ACOPLADO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-ATUALIZA-VG-ACOPLADO-SECTION */
        private void R0610_ATUALIZA_VG_ACOPLADO_SECTION()
        {
            /*" -596- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", WABEND.WNR_EXEC_SQL);

            /*" -608- PERFORM R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1 */

            R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1();

            /*" -611-  EVALUATE SQLCODE  */

            /*" -612-  WHEN ZEROS  */

            /*" -612- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -613- CONTINUE */

                /*" -614-  WHEN OTHER  */

                /*" -614- ELSE */
            }
            else
            {


                /*" -615- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, AREA_DE_WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -616- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -617- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -624- STRING WNR-EXEC-SQL ' - ERRO NO INSERT SEGUROS.VG_ACOPLADO.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WABEND.WNR_EXEC_SQL.GetMoveValues();
                spl1 += " - ERRO NO INSERT SEGUROS.VG_ACOPLADO.";
                spl1 += "<CERTIFICADO= ";
                var spl2 = AREA_DE_WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl2 += ">";
                spl2 += "<PRODUTO= ";
                var spl3 = AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl3 += ">";
                spl3 += "<PLANO= ";
                var spl4 = AREA_DE_WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl4 += ">";
                var results5 = spl1 + spl2 + spl3 + spl4;
                _.Move(results5, AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -625- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                /*" -626- DISPLAY 'SQLCODE: ' WS-SQLCODE */
                _.Display($"SQLCODE: {WABEND.WS_SQLCODE}");

                /*" -627- DISPLAY WS-MENSAGEM */
                _.Display(AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);

                /*" -628- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -630-  END-EVALUATE  */

                /*" -630- END-IF */
            }


            /*" -653- PERFORM R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1 */

            R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1();

            /*" -656-  EVALUATE SQLCODE  */

            /*" -657-  WHEN ZEROS  */

            /*" -658-  WHEN -803  */

            /*" -658- IF   SQLCODE EQUALS ZEROS OR  -803 */

            if (DB.SQLCODE.In("00", "-803"))
            {

                /*" -659- CONTINUE */

                /*" -660-  WHEN OTHER  */

                /*" -660- ELSE */
            }
            else
            {


                /*" -661- MOVE VG135-NUM-CERTIFICADO TO WS-BIGINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO, AREA_DE_WORK.WS_EDIT.WS_BIGINT[01]);

                /*" -662- MOVE VG135-COD-PRODUTO TO WS-SMALLINT(01) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01]);

                /*" -663- MOVE VG135-COD-PLANO TO WS-SMALLINT(02) */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_COD_PLANO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[02]);

                /*" -670- STRING WNR-EXEC-SQL ' - ERRO NO INSERT SEGUROS.VG_ACOPLADO_HIST.' '<CERTIFICADO= ' WS-BIGINT(01) '>' '<PRODUTO= ' WS-SMALLINT(01) '>' '<PLANO= ' WS-SMALLINT(02) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl5 = WABEND.WNR_EXEC_SQL.GetMoveValues();
                spl5 += " - ERRO NO INSERT SEGUROS.VG_ACOPLADO_HIST.";
                spl5 += "<CERTIFICADO= ";
                var spl6 = AREA_DE_WORK.WS_EDIT.WS_BIGINT[01].GetMoveValues();
                spl6 += ">";
                spl6 += "<PRODUTO= ";
                var spl7 = AREA_DE_WORK.WS_EDIT.WS_SMALLINT[01].GetMoveValues();
                spl7 += ">";
                spl7 += "<PLANO= ";
                var spl8 = AREA_DE_WORK.WS_EDIT.WS_SMALLINT[02].GetMoveValues();
                spl8 += ">";
                var results9 = spl5 + spl6 + spl7 + spl8;
                _.Move(results9, AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -671- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                /*" -672- DISPLAY 'SQLCODE: ' WS-SQLCODE */
                _.Display($"SQLCODE: {WABEND.WS_SQLCODE}");

                /*" -673- DISPLAY WS-MENSAGEM */
                _.Display(AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);

                /*" -674- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -676-  END-EVALUATE  */

                /*" -676- END-IF */
            }


            /*" -676- . */

        }

        [StopWatch]
        /*" R0610-ATUALIZA-VG-ACOPLADO-DB-UPDATE-1 */
        public void R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1()
        {
            /*" -608- EXEC SQL UPDATE SEGUROS.VG_ACOPLADO SET STA_ACOPLADO = 9 , COD_USUARIO = 'VG0016B' , NOM_PROGRAMA = 'INATIVO' , DTH_CADASTRAMENTO = CURRENT TIMESTAMP WHERE IDE_SISTEMA = :VG135-IDE-SISTEMA AND NUM_CERTIFICADO = :VG135-NUM-CERTIFICADO AND COD_PRODUTO = :VG135-COD-PRODUTO AND COD_PLANO = :VG135-COD-PLANO AND STA_ACOPLADO = 7 END-EXEC */

            var r0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1 = new R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1()
            {
                VG135_NUM_CERTIFICADO = VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO.ToString(),
                VG135_IDE_SISTEMA = VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA.ToString(),
                VG135_COD_PRODUTO = VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO.ToString(),
                VG135_COD_PLANO = VG135.DCLVG_ACOPLADO.VG135_COD_PLANO.ToString(),
            };

            R0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1.Execute(r0610_ATUALIZA_VG_ACOPLADO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R0610-ATUALIZA-VG-ACOPLADO-DB-INSERT-1 */
        public void R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1()
        {
            /*" -653- EXEC SQL INSERT INTO SEGUROS.VG_ACOPLADO_HIST SELECT IDE_SISTEMA , NUM_CERTIFICADO , COD_PRODUTO , COD_PLANO , DTH_CADASTRAMENTO , DTA_MOVIMENTO , STA_ACOPLADO , COD_EMPRESA_CAP , QTD_TITULO , VLR_TITULO , COD_USUARIO , NOM_PROGRAMA FROM SEGUROS.VG_ACOPLADO WHERE IDE_SISTEMA = :VG135-IDE-SISTEMA AND NUM_CERTIFICADO = :VG135-NUM-CERTIFICADO AND COD_PRODUTO = :VG135-COD-PRODUTO AND COD_PLANO = :VG135-COD-PLANO AND STA_ACOPLADO = 9 AND COD_USUARIO = 'VG0016B' AND NOM_PROGRAMA = 'INATIVO' END-EXEC */

            var r0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1 = new R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1()
            {
                VG135_IDE_SISTEMA = VG135.DCLVG_ACOPLADO.VG135_IDE_SISTEMA.ToString(),
                VG135_NUM_CERTIFICADO = VG135.DCLVG_ACOPLADO.VG135_NUM_CERTIFICADO.ToString(),
                VG135_COD_PRODUTO = VG135.DCLVG_ACOPLADO.VG135_COD_PRODUTO.ToString(),
                VG135_COD_PLANO = VG135.DCLVG_ACOPLADO.VG135_COD_PLANO.ToString(),
            };

            R0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1.Execute(r0610_ATUALIZA_VG_ACOPLADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -691- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -692- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -693- DISPLAY '*   VG0016B - VG    SIAS                  *' . */
            _.Display($"*   VG0016B - VG    SIAS                  *");

            /*" -694- DISPLAY '*   -------   ------ -----------           *' . */
            _.Display($"*   -------   ------ -----------           *");

            /*" -695- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -696- DISPLAY '*   NAO HOUVE ACOPLADOS PARA ATUALIZAR.    *' . */
            _.Display($"*   NAO HOUVE ACOPLADOS PARA ATUALIZAR.    *");

            /*" -697- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -697- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -713- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

            /*" -714- DISPLAY WS-MENSAGEM. */
            _.Display(AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);

            /*" -716- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -716- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -720- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -720- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}