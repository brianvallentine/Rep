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
using Sias.VidaEmGrupo.DB2.VG0015B;

namespace Code
{
    public class VG0015B
    {
        public bool IsCall { get; set; }

        public VG0015B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *---------------------------------------                                */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VG - SIAS                          *      */
        /*"      *   PROGRAMA ................ VG0015B                            *      */
        /*"      *   Esse programa ir� PEDIR A RENOVA��O DE T�TULOS - que ficam de*      */
        /*"      *   fora dos pedidos dos programas (que fazem a renova��o)              */
        /*"      *   por alguma falha.                                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  RAUL BASILI ROTTA                  *      */
        /*"      *   DESENVOLVEDOR ..........  RAUL BASILI ROTTA                  *      */
        /*"      *   DATA CODIFICACAO .......  25/03/2024                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  Realiazar o pedido de RENOVA��O    *      */
        /*"      *                             para colocar no STA_ACOPLADO = 3          */
        /*"      *                             na tabela de VG_ACOPLADO.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            DCLGEN               ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          SISTEMAS             INPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 04/10/2024 RAUL ROTTA        V.01   Ajuste na query de bilhetes*      */
        /*"      *                                     para levar em conta o      *      */
        /*"      *                                     endosso ZERO, al�m da      *      */
        /*"      *                                     SITUACAO = 9.              *      */
        /*"      * 25/03/2024 RAUL ROTTA        V.00   DESENVOLVIMENTO            *      */
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
        public VG0015B_WHOST_DT WHOST_DT { get; set; } = new VG0015B_WHOST_DT();
        public class VG0015B_WHOST_DT : VarBasis
        {
            /*"  05   WHOST-DT-INI             PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DT_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05   WHOST-DT-FIM             PIC  X(010)  VALUE SPACES.*/
            public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"01  WS-DATAS.*/
        }
        public VG0015B_WS_DATAS WS_DATAS { get; set; } = new VG0015B_WS_DATAS();
        public class VG0015B_WS_DATAS : VarBasis
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
        public VG0015B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VG0015B_AREA_DE_WORK();
        public class VG0015B_AREA_DE_WORK : VarBasis
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
            /*"  05      AC-G-VG0015B         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_G_VG0015B { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
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
            private _REDEF_VG0015B_WS_COD_DOC_PARCEIRO_R _ws_cod_doc_parceiro_r { get; set; }
            public _REDEF_VG0015B_WS_COD_DOC_PARCEIRO_R WS_COD_DOC_PARCEIRO_R
            {
                get { _ws_cod_doc_parceiro_r = new _REDEF_VG0015B_WS_COD_DOC_PARCEIRO_R(); _.Move(WS_COD_DOC_PARCEIRO, _ws_cod_doc_parceiro_r); VarBasis.RedefinePassValue(WS_COD_DOC_PARCEIRO, _ws_cod_doc_parceiro_r, WS_COD_DOC_PARCEIRO); _ws_cod_doc_parceiro_r.ValueChanged += () => { _.Move(_ws_cod_doc_parceiro_r, WS_COD_DOC_PARCEIRO); }; return _ws_cod_doc_parceiro_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cod_doc_parceiro_r, WS_COD_DOC_PARCEIRO); }
            }  //Redefines
            public class _REDEF_VG0015B_WS_COD_DOC_PARCEIRO_R : VarBasis
            {
                /*"    10    WS-COD-DOC-PARCEIRO-N PIC  9(015).*/
                public IntBasis WS_COD_DOC_PARCEIRO_N { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"  05      WDATA-REFER           PIC  X(010)      VALUE SPACES.*/

                public _REDEF_VG0015B_WS_COD_DOC_PARCEIRO_R()
                {
                    WS_COD_DOC_PARCEIRO_N.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-REF-R           REDEFINES        WDATA-REFER.*/
            private _REDEF_VG0015B_WDATA_REF_R _wdata_ref_r { get; set; }
            public _REDEF_VG0015B_WDATA_REF_R WDATA_REF_R
            {
                get { _wdata_ref_r = new _REDEF_VG0015B_WDATA_REF_R(); _.Move(WDATA_REFER, _wdata_ref_r); VarBasis.RedefinePassValue(WDATA_REFER, _wdata_ref_r, WDATA_REFER); _wdata_ref_r.ValueChanged += () => { _.Move(_wdata_ref_r, WDATA_REFER); }; return _wdata_ref_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_ref_r, WDATA_REFER); }
            }  //Redefines
            public class _REDEF_VG0015B_WDATA_REF_R : VarBasis
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

                public _REDEF_VG0015B_WDATA_REF_R()
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
            private _REDEF_VG0015B_WDATA_CURR_R _wdata_curr_r { get; set; }
            public _REDEF_VG0015B_WDATA_CURR_R WDATA_CURR_R
            {
                get { _wdata_curr_r = new _REDEF_VG0015B_WDATA_CURR_R(); _.Move(WDATA_CURR, _wdata_curr_r); VarBasis.RedefinePassValue(WDATA_CURR, _wdata_curr_r, WDATA_CURR); _wdata_curr_r.ValueChanged += () => { _.Move(_wdata_curr_r, WDATA_CURR); }; return _wdata_curr_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_curr_r, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_VG0015B_WDATA_CURR_R : VarBasis
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

                public _REDEF_VG0015B_WDATA_CURR_R()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public VG0015B_WDATA_EDIT WDATA_EDIT { get; set; } = new VG0015B_WDATA_EDIT();
            public class VG0015B_WDATA_EDIT : VarBasis
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
            public VG0015B_WHORA_CURR WHORA_CURR { get; set; } = new VG0015B_WHORA_CURR();
            public class VG0015B_WHORA_CURR : VarBasis
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
            public VG0015B_WHORA_EDIT WHORA_EDIT { get; set; } = new VG0015B_WHORA_EDIT();
            public class VG0015B_WHORA_EDIT : VarBasis
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
            public VG0015B_WS_EDIT WS_EDIT { get; set; } = new VG0015B_WS_EDIT();
            public class VG0015B_WS_EDIT : VarBasis
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
            public VG0015B_WS_ERRO WS_ERRO { get; set; } = new VG0015B_WS_ERRO();
            public class VG0015B_WS_ERRO : VarBasis
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
        public VG0015B_WABEND WABEND { get; set; } = new VG0015B_WABEND();
        public class VG0015B_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(010)      VALUE         ' VG0015B'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0015B");
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
        public Dclgens.COMFEDCA COMFEDCA { get; set; } = new Dclgens.COMFEDCA();
        public VG0015B_ACOPLADO ACOPLADO { get; set; } = new VG0015B_ACOPLADO();
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
            /*" -255- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -256- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -259- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -262- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -284- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -285- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -286- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -287- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -292- DISPLAY 'INICIO VG0015B            ' WHORA-EDIT. */
            _.Display($"INICIO VG0015B            {AREA_DE_WORK.WHORA_EDIT}");

            /*" -293- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -294- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -295- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -296- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -298- DISPLAY 'INICIO DECLARE            ' WHORA-EDIT. */
            _.Display($"INICIO DECLARE            {AREA_DE_WORK.WHORA_EDIT}");

            /*" -300- PERFORM R0400-00-DECLARE-ACOPLADO. */

            R0400_00_DECLARE_ACOPLADO_SECTION();

            /*" -301- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -302- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -303- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -304- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -306- DISPLAY 'FINAL DECLARE             ' WHORA-EDIT. */
            _.Display($"FINAL DECLARE             {AREA_DE_WORK.WHORA_EDIT}");

            /*" -308- PERFORM R0500-00-FETCH-ACOPLADO. */

            R0500_00_FETCH_ACOPLADO_SECTION();

            /*" -310- DISPLAY 'WFIM-RELATORIO..: ' WFIM-RELATORIO */
            _.Display($"WFIM-RELATORIO..: {AREA_DE_WORK.WFIM_RELATORIO}");

            /*" -311- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_RELATORIO.IsEmpty())
            {

                /*" -312- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -313- GO TO R0000-90-FINALIZA */

                R0000_90_FINALIZA(); //GOTO
                return;

                /*" -315- END-IF. */
            }


            /*" -318- PERFORM R0600-PROCESSA-ACOPLADO UNTIL WFIM-RELATORIO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_RELATORIO.IsEmpty()))
            {

                R0600_PROCESSA_ACOPLADO_SECTION();
            }

            /*" -319- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -320- MOVE WHORA-HH-CURR TO WHORA-HH-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDT);

            /*" -321- MOVE WHORA-MM-CURR TO WHORA-MM-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDT);

            /*" -322- MOVE WHORA-SS-CURR TO WHORA-SS-EDT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDT);

            /*" -322- DISPLAY 'FINAL  VG0015B         ' WHORA-EDIT. */
            _.Display($"FINAL  VG0015B         {AREA_DE_WORK.WHORA_EDIT}");

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -328- DISPLAY 'QTDE. DE REGISTROS ' . */
            _.Display($"QTDE. DE REGISTROS ");

            /*" -332- DISPLAY 'LIDOS para garavar VG_ACOPLADOS_TITULO   - ' AC-L-RELATORI. */
            _.Display($"LIDOS para garavar VG_ACOPLADOS_TITULO   - {AREA_DE_WORK.AC_L_RELATORI}");

            /*" -334- DISPLAY '*--- VG0015B  -  FIM  NORMAL ---*' . */
            _.Display($"*--- VG0015B  -  FIM  NORMAL ---*");

            /*" -334- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -338- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -338- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-DECLARE-ACOPLADO-SECTION */
        private void R0400_00_DECLARE_ACOPLADO_SECTION()
        {
            /*" -348- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WABEND.WNR_EXEC_SQL);

            /*" -398- INITIALIZE DCLVG-ACOPLADO-TITULO DCLCOMUNIC-FED-CAP-VA WFIM-RELATORIO LK-VG013-TRACE LK-VG013-SISTEMA-CHAMADOR LK-VG013-CANAL LK-VG013-ORIGEM LK-VG013-COD-USUARIO LK-VG013-TIPO-ACAO LK-VG013-IDE-SISTEMA LK-VG013-NUM-CERTIFICADO LK-VG013-COD-PRODUTO LK-VG013-COD-PLANO LK-VG013-QTD-TITULO LK-VG013-VLR-TITULO LK-VG013-COD-EMPRESA-CAP LK-VG013-COD-RETORNO-API LK-VG013-DES-ERRO LK-VG013-DES-ACAO WS-NUM-CERTIFICADO WS-COD-DOC-PARCEIRO-P WS-COD-PRODUTO WS-COD-PLANO WS-NUM-SERIE WS-NUM-TITULO WS-STA-TITULO WS-COD-SUB-TITULO WS-DTH-ATIVACAO WS-DTA-CADUCACAO WS-DTH-CRIACAO WS-DTA-FIM-VIGENCIA WS-DTA-INI-SORTEIO WS-DTA-INI-VIGENCIA WS-DTA-SUSPENSAO WS-COD-DV WS-VLR-MENSALIDADE WS-NUM-MOD-PLANO WS-DES-COMBINACAO WS-IDE-SISTEMA */
            _.Initialize(
                VG136.DCLVG_ACOPLADO_TITULO
                , COMFEDCA.DCLCOMUNIC_FED_CAP_VA
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

            /*" -505- PERFORM R0400_00_DECLARE_ACOPLADO_DB_DECLARE_1 */

            R0400_00_DECLARE_ACOPLADO_DB_DECLARE_1();

            /*" -507- PERFORM R0400_00_DECLARE_ACOPLADO_DB_OPEN_1 */

            R0400_00_DECLARE_ACOPLADO_DB_OPEN_1();

            /*" -510- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -511- DISPLAY 'R0400 - ERRO NO R0400-00-DECLARE-ACOPLADO' */
                _.Display($"R0400 - ERRO NO R0400-00-DECLARE-ACOPLADO");

                /*" -512- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                /*" -513- DISPLAY 'SQLCODE: ' WS-SQLCODE */
                _.Display($"SQLCODE: {WABEND.WS_SQLCODE}");

                /*" -514- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -515- ELSE */
            }
            else
            {


                /*" -516- MOVE SPACES TO WFIM-RELATORIO */
                _.Move("", AREA_DE_WORK.WFIM_RELATORIO);

                /*" -516- END-IF. */
            }


        }

        [StopWatch]
        /*" R0400-00-DECLARE-ACOPLADO-DB-DECLARE-1 */
        public void R0400_00_DECLARE_ACOPLADO_DB_DECLARE_1()
        {
            /*" -505- EXEC SQL DECLARE ACOPLADO CURSOR FOR SELECT A.NUM_CERTIFICADO , A.COD_PRODUTO , A.COD_PLANO , A.VLR_TITULO FROM SEGUROS.VG_ACOPLADO A WHERE A.IDE_SISTEMA = 'VG' AND A.NUM_CERTIFICADO > 0 AND A.STA_ACOPLADO = 7 AND A.COD_PLANO > 800 AND A.COD_PRODUTO > 0 AND EXISTS ( SELECT * FROM SEGUROS.PROPOSTAS_VA C WHERE C.NUM_CERTIFICADO = A.NUM_CERTIFICADO AND C.SIT_REGISTRO IN ( '3' , '6' ) FETCH FIRST 1 ROWS ONLY ) UNION SELECT A.NUM_CERTIFICADO , A.COD_PRODUTO , A.COD_PLANO , A.VLR_TITULO FROM SEGUROS.VG_ACOPLADO A WHERE A.IDE_SISTEMA = 'VG' AND A.NUM_CERTIFICADO > 0 AND A.STA_ACOPLADO = 7 AND A.COD_PLANO > 800 AND A.COD_PRODUTO > 0 AND EXISTS ( SELECT 1 FROM SEGUROS.BILHETE BIL , SEGUROS.ENDOSSOS EDS WHERE BIL.NUM_BILHETE = A.NUM_CERTIFICADO AND BIL.SITUACAO = '9' and EDS.NUM_APOLICE = BIL.NUM_APOLICE aND EDS.COD_PRODUTO = A.COD_PRODUTO AND EDS.NUM_ENDOSSO = 0 AND EDS.DATA_TERVIGENCIA >= CURRENT DATE fetch first 1 rows only ) WITH UR END-EXEC. */
            ACOPLADO = new VG0015B_ACOPLADO(false);
            string GetQuery_ACOPLADO()
            {
                var query = @$"SELECT A.NUM_CERTIFICADO 
							, A.COD_PRODUTO 
							, A.COD_PLANO 
							, A.VLR_TITULO 
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
							AND C.SIT_REGISTRO IN 
							( '3'
							, '6' ) 
							FETCH FIRST 1 ROWS ONLY 
							) 
							UNION 
							SELECT A.NUM_CERTIFICADO 
							, A.COD_PRODUTO 
							, A.COD_PLANO 
							, A.VLR_TITULO 
							FROM SEGUROS.VG_ACOPLADO A 
							WHERE A.IDE_SISTEMA = 'VG' 
							AND A.NUM_CERTIFICADO > 0 
							AND A.STA_ACOPLADO = 7 
							AND A.COD_PLANO > 800 
							AND A.COD_PRODUTO > 0 
							AND EXISTS ( SELECT 1 
							FROM SEGUROS.BILHETE BIL 
							, SEGUROS.ENDOSSOS EDS 
							WHERE BIL.NUM_BILHETE = 
							A.NUM_CERTIFICADO 
							AND BIL.SITUACAO = '9' 
							and EDS.NUM_APOLICE = BIL.NUM_APOLICE 
							aND EDS.COD_PRODUTO = A.COD_PRODUTO 
							AND EDS.NUM_ENDOSSO = 0 
							AND EDS.DATA_TERVIGENCIA >= CURRENT DATE 
							fetch first 1 rows only 
							)";

                return query;
            }
            ACOPLADO.GetQueryEvent += GetQuery_ACOPLADO;

        }

        [StopWatch]
        /*" R0400-00-DECLARE-ACOPLADO-DB-OPEN-1 */
        public void R0400_00_DECLARE_ACOPLADO_DB_OPEN_1()
        {
            /*" -507- EXEC SQL OPEN ACOPLADO END-EXEC. */

            ACOPLADO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-FETCH-ACOPLADO-SECTION */
        private void R0500_00_FETCH_ACOPLADO_SECTION()
        {
            /*" -530- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -537- PERFORM R0500_00_FETCH_ACOPLADO_DB_FETCH_1 */

            R0500_00_FETCH_ACOPLADO_DB_FETCH_1();

            /*" -540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -541- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -542- MOVE 'S' TO WFIM-RELATORIO */
                    _.Move("S", AREA_DE_WORK.WFIM_RELATORIO);

                    /*" -542- PERFORM R0500_00_FETCH_ACOPLADO_DB_CLOSE_1 */

                    R0500_00_FETCH_ACOPLADO_DB_CLOSE_1();

                    /*" -544- GO TO R0500-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                    return;

                    /*" -545- ELSE */
                }
                else
                {


                    /*" -546- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                    /*" -547- MOVE SQLERRMC TO WS-SQLERRMC */
                    _.Move(DB.SQLERRMC, WABEND.WS_SQLERRMC);

                    /*" -549- DISPLAY '*------------------------------------------------*' */
                    _.Display($"*------------------------------------------------*");

                    /*" -550- DISPLAY '                         ' */
                    _.Display($"                         ");

                    /*" -551- DISPLAY 'R0500 - ERRO NO FETCH R0500-00-FETCH-ACOPLADO' */
                    _.Display($"R0500 - ERRO NO FETCH R0500-00-FETCH-ACOPLADO");

                    /*" -552- DISPLAY 'SQLCODE:  ' WS-SQLCODE */
                    _.Display($"SQLCODE:  {WABEND.WS_SQLCODE}");

                    /*" -554- DISPLAY 'SQLERRMC: ' WS-SQLERRMC '*------------------------------------------------*' */

                    $"SQLERRMC: {WABEND.WS_SQLERRMC}*------------------------------------------------*"
                    .Display();

                    /*" -555- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -556- END-IF */
                }


                /*" -558- END-IF. */
            }


            /*" -558- ADD 1 TO AC-L-RELATORI. */
            AREA_DE_WORK.AC_L_RELATORI.Value = AREA_DE_WORK.AC_L_RELATORI + 1;

        }

        [StopWatch]
        /*" R0500-00-FETCH-ACOPLADO-DB-FETCH-1 */
        public void R0500_00_FETCH_ACOPLADO_DB_FETCH_1()
        {
            /*" -537- EXEC SQL FETCH ACOPLADO INTO :WS-COD-DOC-PARCEIRO-P , :WS-COD-PRODUTO, :WS-COD-PLANO, :VG135-VLR-TITULO END-EXEC. */

            if (ACOPLADO.Fetch())
            {
                _.Move(ACOPLADO.WS_COD_DOC_PARCEIRO_P, AREA_DE_WORK.WS_COD_DOC_PARCEIRO_P);
                _.Move(ACOPLADO.WS_COD_PRODUTO, AREA_DE_WORK.WS_COD_PRODUTO);
                _.Move(ACOPLADO.WS_COD_PLANO, AREA_DE_WORK.WS_COD_PLANO);
                _.Move(ACOPLADO.VG135_VLR_TITULO, VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO);
            }

        }

        [StopWatch]
        /*" R0500-00-FETCH-ACOPLADO-DB-CLOSE-1 */
        public void R0500_00_FETCH_ACOPLADO_DB_CLOSE_1()
        {
            /*" -542- EXEC SQL CLOSE ACOPLADO END-EXEC */

            ACOPLADO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-PROCESSA-ACOPLADO-SECTION */
        private void R0600_PROCESSA_ACOPLADO_SECTION()
        {
            /*" -576- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -578- IF AC-L-RELATORI GREATER 0 */

            if (AREA_DE_WORK.AC_L_RELATORI > 0)
            {

                /*" -582- PERFORM R0600_PROCESSA_ACOPLADO_DB_SELECT_1 */

                R0600_PROCESSA_ACOPLADO_DB_SELECT_1();

                /*" -588- MOVE WS-COD-DOC-PARCEIRO-P TO LK-VG013-NUM-CERTIFICADO WS-NUM-CERTIFICADO COMFEDCA-NUM-CERTIFICADO */
                _.Move(AREA_DE_WORK.WS_COD_DOC_PARCEIRO_P, SPVG013W.LK_VG013_NUM_CERTIFICADO, AREA_DE_WORK.WS_NUM_CERTIFICADO, COMFEDCA.DCLCOMUNIC_FED_CAP_VA.COMFEDCA_NUM_CERTIFICADO);

                /*" -589- MOVE WS-COD-PRODUTO TO LK-VG013-COD-PRODUTO */
                _.Move(AREA_DE_WORK.WS_COD_PRODUTO, SPVG013W.LK_VG013_COD_PRODUTO);

                /*" -590- MOVE WS-COD-PLANO TO LK-VG013-COD-PLANO */
                _.Move(AREA_DE_WORK.WS_COD_PLANO, SPVG013W.LK_VG013_COD_PLANO);

                /*" -594- MOVE VG135-VLR-TITULO TO LK-VG013-VLR-TITULO */
                _.Move(VG135.DCLVG_ACOPLADO.VG135_VLR_TITULO, SPVG013W.LK_VG013_VLR_TITULO);

                /*" -595- MOVE 'N' TO LK-VG013-TRACE */
                _.Move("N", SPVG013W.LK_VG013_TRACE);

                /*" -596- MOVE 'SIAS - VG0015B' TO LK-VG013-SISTEMA-CHAMADOR */
                _.Move("SIAS - VG0015B", SPVG013W.LK_VG013_SISTEMA_CHAMADOR);

                /*" -597- MOVE 0 TO LK-VG013-CANAL */
                _.Move(0, SPVG013W.LK_VG013_CANAL);

                /*" -599- MOVE 0 TO LK-VG013-ORIGEM */
                _.Move(0, SPVG013W.LK_VG013_ORIGEM);

                /*" -600- MOVE 'VG' TO LK-VG013-IDE-SISTEMA */
                _.Move("VG", SPVG013W.LK_VG013_IDE_SISTEMA);

                /*" -602- MOVE 'VG0015B' TO LK-VG013-COD-USUARIO */
                _.Move("VG0015B", SPVG013W.LK_VG013_COD_USUARIO);

                /*" -633- MOVE 02 TO LK-VG013-TIPO-ACAO */
                _.Move(02, SPVG013W.LK_VG013_TIPO_ACAO);

                /*" -654- INITIALIZE H-OUT-COD-RETORNO H-OUT-COD-RETORNO-SQL H-OUT-MENSAGEM H-OUT-SQLERRMC H-OUT-SQLSTATE */
                _.Initialize(
                    LBHCT002.H_OUT_COD_RETORNO
                    , LBHCT002.H_OUT_COD_RETORNO_SQL
                    , LBHCT002.H_OUT_MENSAGEM
                    , LBHCT002.H_OUT_SQLERRMC
                    , LBHCT002.H_OUT_SQLSTATE
                );

                /*" -655- PERFORM R0610-GRAVA-VG-ACOPLADO */

                R0610_GRAVA_VG_ACOPLADO_SECTION();

                /*" -657- PERFORM R0700-00-INSERT-COMFEDCA */

                R0700_00_INSERT_COMFEDCA_SECTION();

                /*" -657- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0600_90_LE_REGISTRO */

            R0600_90_LE_REGISTRO();

        }

        [StopWatch]
        /*" R0600-PROCESSA-ACOPLADO-DB-SELECT-1 */
        public void R0600_PROCESSA_ACOPLADO_DB_SELECT_1()
        {
            /*" -582- EXEC SQL SELECT CHAR(CURRENT TIMESTAMP) INTO :WS-CURRENT-TIMESTAMP FROM SYSIBM.SYSDUMMY1 END-EXEC */

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
            /*" -663- PERFORM R0500-00-FETCH-ACOPLADO. */

            R0500_00_FETCH_ACOPLADO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0610-GRAVA-VG-ACOPLADO-SECTION */
        private void R0610_GRAVA_VG_ACOPLADO_SECTION()
        {
            /*" -677- MOVE '0610' TO WNR-EXEC-SQL. */
            _.Move("0610", WABEND.WNR_EXEC_SQL);

            /*" -703- CALL 'SPBVG013' USING LK-VG013-TRACE ,LK-VG013-SISTEMA-CHAMADOR ,LK-VG013-CANAL ,LK-VG013-ORIGEM ,LK-VG013-COD-USUARIO ,LK-VG013-TIPO-ACAO ,LK-VG013-IDE-SISTEMA ,LK-VG013-NUM-CERTIFICADO ,LK-VG013-COD-PRODUTO ,LK-VG013-COD-PLANO ,LK-VG013-QTD-TITULO ,LK-VG013-VLR-TITULO ,LK-VG013-COD-EMPRESA-CAP ,LK-VG013-COD-RETORNO-API ,LK-VG013-DES-ERRO ,LK-VG013-DES-ACAO ,H-OUT-COD-RETORNO ,H-OUT-COD-RETORNO-SQL ,H-OUT-MENSAGEM ,H-OUT-SQLERRMC ,H-OUT-SQLSTATE */
            _.Call("SPBVG013", SPVG013W, LBHCT002);

            /*" -704-  EVALUATE H-OUT-COD-RETORNO  */

            /*" -705-  WHEN ZEROS  */

            /*" -705- IF   H-OUT-COD-RETORNO EQUALS  ZEROS */

            if (LBHCT002.H_OUT_COD_RETORNO == 00)
            {

                /*" -706- MOVE 00 TO RETURN-CODE */
                _.Move(00, RETURN_CODE);

                /*" -707-  WHEN OTHER  */

                /*" -707- ELSE */
            }
            else
            {


                /*" -708- MOVE LK-VG013-NUM-CERTIFICADO TO WS-BIGINT(1) */
                _.Move(SPVG013W.LK_VG013_NUM_CERTIFICADO, AREA_DE_WORK.WS_EDIT.WS_BIGINT[1]);

                /*" -709- MOVE LK-VG013-COD-PRODUTO TO WS-SMALLINT(1) */
                _.Move(SPVG013W.LK_VG013_COD_PRODUTO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[1]);

                /*" -712- MOVE LK-VG013-COD-PLANO TO WS-SMALLINT(2) */
                _.Move(SPVG013W.LK_VG013_COD_PLANO, AREA_DE_WORK.WS_EDIT.WS_SMALLINT[2]);

                /*" -713- MOVE H-OUT-COD-RETORNO-SQL TO WS-SQLCODE */
                _.Move(LBHCT002.H_OUT_COD_RETORNO_SQL, WABEND.WS_SQLCODE);

                /*" -716- MOVE H-OUT-SQLERRMC TO WS-SQLERRMC */
                _.Move(LBHCT002.H_OUT_SQLERRMC, WABEND.WS_SQLERRMC);

                /*" -728- STRING WNR-EXEC-SQL ' - ERRO NA CHAMADA DA SPBVG013.' '< MENSAGEM.:   ' H-OUT-MENSAGEM ' > ' '< SQLCODE.:    ' WS-SQLCODE ' > ' '< SQLERRMC.:   ' WS-SQLERRMC ' > ' '< SQLSTATE.:   ' H-OUT-SQLSTATE ' > ' '<CERTIFICADO= ' WS-BIGINT(1) '>' '<PRODUTO= ' WS-SMALLINT(1) '>' '<PLANO= ' WS-SMALLINT(2) '>' DELIMITED BY SIZE INTO WS-MENSAGEM */
                #region STRING
                var spl1 = WABEND.WNR_EXEC_SQL.GetMoveValues();
                spl1 += " - ERRO NA CHAMADA DA SPBVG013.";
                spl1 += "< MENSAGEM.: ";
                var spl2 = LBHCT002.H_OUT_MENSAGEM.GetMoveValues();
                spl2 += " > ";
                spl2 += "< SQLCODE.: ";
                var spl3 = WABEND.WS_SQLCODE.GetMoveValues();
                spl3 += " > ";
                spl3 += "< SQLERRMC.: ";
                var spl4 = WABEND.WS_SQLERRMC.GetMoveValues();
                spl4 += " > ";
                spl4 += "< SQLSTATE.: ";
                var spl5 = LBHCT002.H_OUT_SQLSTATE.GetMoveValues();
                spl5 += " > ";
                spl5 += "<CERTIFICADO= ";
                var spl6 = AREA_DE_WORK.WS_EDIT.WS_BIGINT[1].GetMoveValues();
                spl6 += ">";
                spl6 += "<PRODUTO= ";
                var spl7 = AREA_DE_WORK.WS_EDIT.WS_SMALLINT[1].GetMoveValues();
                spl7 += ">";
                spl7 += "<PLANO= ";
                var spl8 = AREA_DE_WORK.WS_EDIT.WS_SMALLINT[2].GetMoveValues();
                spl8 += ">";
                var results9 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7 + spl8;
                _.Move(results9, AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);
                #endregion

                /*" -729- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -730- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -732-  END-EVALUATE  */

                /*" -732- END-IF */
            }


            /*" -732- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0610_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-INSERT-COMFEDCA-SECTION */
        private void R0700_00_INSERT_COMFEDCA_SECTION()
        {
            /*" -744- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -755- PERFORM R0700_00_INSERT_COMFEDCA_DB_INSERT_1 */

            R0700_00_INSERT_COMFEDCA_DB_INSERT_1();

            /*" -758- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -759- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

                /*" -760- MOVE SQLERRMC TO WS-SQLERRMC */
                _.Move(DB.SQLERRMC, WABEND.WS_SQLERRMC);

                /*" -762- DISPLAY '*------------------------------------------------*' */
                _.Display($"*------------------------------------------------*");

                /*" -763- DISPLAY '                         ' */
                _.Display($"                         ");

                /*" -764- DISPLAY 'R0700 - ERRO NO INSERT DA COMFEDCA' */
                _.Display($"R0700 - ERRO NO INSERT DA COMFEDCA");

                /*" -765- DISPLAY 'CERTIFICADO ' WS-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {AREA_DE_WORK.WS_NUM_CERTIFICADO}");

                /*" -766- DISPLAY 'SQLCODE:  ' WS-SQLCODE */
                _.Display($"SQLCODE:  {WABEND.WS_SQLCODE}");

                /*" -768- DISPLAY 'SQLERRMC: ' WS-SQLERRMC */
                _.Display($"SQLERRMC: {WABEND.WS_SQLERRMC}");

                /*" -769- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -770- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -770- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-INSERT-COMFEDCA-DB-INSERT-1 */
        public void R0700_00_INSERT_COMFEDCA_DB_INSERT_1()
        {
            /*" -755- EXEC SQL INSERT INTO SEGUROS.COMUNIC_FED_CAP_VA ( NUM_CERTIFICADO, SITUACAO , DATA_MOVIMENTO , TIMESTAMP ) VALUES (:WS-NUM-CERTIFICADO, 'R' , CURRENT DATE , CURRENT TIMESTAMP ) END-EXEC. */

            var r0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1 = new R0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1()
            {
                WS_NUM_CERTIFICADO = AREA_DE_WORK.WS_NUM_CERTIFICADO.ToString(),
            };

            R0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1.Execute(r0700_00_INSERT_COMFEDCA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -783- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -784- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -785- DISPLAY '*   VG0015B - VG    SIAS                  *' . */
            _.Display($"*   VG0015B - VG    SIAS                  *");

            /*" -786- DISPLAY '*   -------   ------ -----------           *' . */
            _.Display($"*   -------   ------ -----------           *");

            /*" -787- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -788- DISPLAY '*   NAO HOUVE ACOPLADOS PARA ATUALIZAR.    *' . */
            _.Display($"*   NAO HOUVE ACOPLADOS PARA ATUALIZAR.    *");

            /*" -789- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -789- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -805- MOVE SQLCODE TO WS-SQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WS_SQLCODE);

            /*" -806- DISPLAY WS-MENSAGEM. */
            _.Display(AREA_DE_WORK.WS_ERRO.WS_MENSAGEM);

            /*" -808- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -808- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -812- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -812- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}