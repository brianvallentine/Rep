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
using Sias.Loterico.DB2.LT3214S;

namespace Code
{
    public class LT3214S
    {
        public bool IsCall { get; set; }

        public LT3214S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------------------------------------      */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  LOTERICOS                          *      */
        /*"      *   PROGRAMA ...............  LT3214S                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JOSE G OLIVEIRA                    *      */
        /*"      *   DATA CODIFICACAO .......  MAR/2021.                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  LER A TABELA LT_PREMIO             *      */
        /*"      *                             A PARTIR DE DADOS INFORMADOS       *      */
        /*"      *                             ANUAL/TRIENAL/QUINQUENAL           *      */
        /*"      *                             RENOVACAO 2021                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *-----------------------------------------------------------------      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 WS-VERSAO                          PIC  X(120) VALUE        'LT3214S-VERSAO: V01-21032021 1307HS-JAZZ 248622/624'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"LT3214S-VERSAO: V01-21032021 1307HS-JAZZ 248622/624");
        /*"01              LPARM.*/
        public LT3214S_LPARM LPARM { get; set; } = new LT3214S_LPARM();
        public class LT3214S_LPARM : VarBasis
        {
            /*"   03          LPARM01.*/
            public LT3214S_LPARM01 LPARM01 { get; set; } = new LT3214S_LPARM01();
            public class LT3214S_LPARM01 : VarBasis
            {
                /*"      05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05       LPARM01-AA      PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          LPARM02         PIC S9(005)      COMP-3.*/
                public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    03          LPARM03.*/
                public LT3214S_LPARM03 LPARM03 { get; set; } = new LT3214S_LPARM03();
                public class LT3214S_LPARM03 : VarBasis
                {
                    /*"      05       LPARM03-DD      PIC  9(002).*/
                    public IntBasis LPARM03_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      05       LPARM03-MM      PIC  9(002).*/
                    public IntBasis LPARM03_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      05       LPARM03-AA      PIC  9(004).*/
                    public IntBasis LPARM03_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"01 WS-AREA-TRABALHO.*/
                }
            }
        }
        public LT3214S_WS_AREA_TRABALHO WS_AREA_TRABALHO { get; set; } = new LT3214S_WS_AREA_TRABALHO();
        public class LT3214S_WS_AREA_TRABALHO : VarBasis
        {
            /*"   05 WS-CURRENT-DATE.*/
            public LT3214S_WS_CURRENT_DATE WS_CURRENT_DATE { get; set; } = new LT3214S_WS_CURRENT_DATE();
            public class LT3214S_WS_CURRENT_DATE : VarBasis
            {
                /*"     10 WS-CUR-DATE              PIC X(16) VALUE SPACES.*/
                public StringBasis WS_CUR_DATE { get; set; } = new StringBasis(new PIC("X", "16", "X(16)"), @"");
                /*"     10 WS-CUR-DATE-R REDEFINES WS-CUR-DATE.*/
                private _REDEF_LT3214S_WS_CUR_DATE_R _ws_cur_date_r { get; set; }
                public _REDEF_LT3214S_WS_CUR_DATE_R WS_CUR_DATE_R
                {
                    get { _ws_cur_date_r = new _REDEF_LT3214S_WS_CUR_DATE_R(); _.Move(WS_CUR_DATE, _ws_cur_date_r); VarBasis.RedefinePassValue(WS_CUR_DATE, _ws_cur_date_r, WS_CUR_DATE); _ws_cur_date_r.ValueChanged += () => { _.Move(_ws_cur_date_r, WS_CUR_DATE); }; return _ws_cur_date_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_cur_date_r, WS_CUR_DATE); }
                }  //Redefines
                public class _REDEF_LT3214S_WS_CUR_DATE_R : VarBasis
                {
                    /*"        15 WS-DT-TODAY           PIC 9(08).*/
                    public IntBasis WS_DT_TODAY { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                    /*"        15 WS-HR-TODAY           PIC 9(06).*/
                    public IntBasis WS_HR_TODAY { get; set; } = new IntBasis(new PIC("9", "6", "9(06)."));
                    /*"        15 WS-FILLER             PIC X(02).*/
                    public StringBasis WS_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                    /*"   05 WS-IND-TIPO-ENDOSSO           PIC S9(04) COMP.*/

                    public _REDEF_LT3214S_WS_CUR_DATE_R()
                    {
                        WS_DT_TODAY.ValueChanged += OnValueChanged;
                        WS_HR_TODAY.ValueChanged += OnValueChanged;
                        WS_FILLER.ValueChanged += OnValueChanged;
                    }

                }
            }
            public IntBasis WS_IND_TIPO_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-SQLCODE                    PIC -ZZZ999.*/
            public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "6", "-ZZZ999."));
            /*"   05 WS-QT-REG                     PIC S9(01) COMP VALUE 0.*/
            public IntBasis WS_QT_REG { get; set; } = new IntBasis(new PIC("S9", "1", "S9(01)"));
            /*"   05 WS-NM-PROGRAMA                PIC X(07) VALUE SPACES.*/
            public StringBasis WS_NM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"");
            /*"   05 WS-EXISTE-EQUIP-SEG           PIC X(01) VALUE SPACES.*/
            public StringBasis WS_EXISTE_EQUIP_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"");
            /*"   05 HOST-COUNT                    PIC S9(04) COMP.*/
            public IntBasis HOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-MAX-IND-TIPO-VIG           PIC S9(04) COMP.*/
            public IntBasis WS_MAX_IND_TIPO_VIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 HOST-DATA-INI                 PIC X(10).*/
            public StringBasis HOST_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 HOST-DATA-FIM                 PIC X(10).*/
            public StringBasis HOST_DATA_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 WS-EXISTE-DESC-SEM-SINI-INF   PIC S9(04) COMP VALUE 0.*/
            public IntBasis WS_EXISTE_DESC_SEM_SINI_INF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-EXISTE-DESC-SEM-SINI       PIC S9(04) COMP VALUE 0.*/
            public IntBasis WS_EXISTE_DESC_SEM_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS1                           PIC S9(04) COMP VALUE 0.*/
            public IntBasis WS1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS3                           PIC S9(04) COMP VALUE 0.*/
            public IntBasis WS3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"   05 WS-COD-LOTERICO               PIC S9(10) COMP-3.*/
            public IntBasis WS_COD_LOTERICO { get; set; } = new IntBasis(new PIC("S9", "10", "S9(10)"));
            /*"   05 WS-DTINIVIG-APOLICE           PIC  X(10).*/
            public StringBasis WS_DTINIVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 WS-DTTERVIG-APOLICE           PIC  X(10).*/
            public StringBasis WS_DTTERVIG_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 V0SIST-DTMOVABE               PIC  X(10).*/
            public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05 WFIM-PREMIO                   PIC  X(03) VALUE SPACES.*/
            public StringBasis WFIM_PREMIO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
            /*"   05 WS-GERAR-BOL-VIG1              PIC S9(4) USAGE COMP.*/
            public IntBasis WS_GERAR_BOL_VIG1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"   05 WS-GERAR-BOL-VIG2              PIC S9(4) USAGE COMP.*/
            public IntBasis WS_GERAR_BOL_VIG2 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"   05 WS-GERAR-BOL-VIG3              PIC S9(4) USAGE COMP.*/
            public IntBasis WS_GERAR_BOL_VIG3 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"   05       TABELA-MOV-RCAP-GERAR.*/
            public LT3214S_TABELA_MOV_RCAP_GERAR TABELA_MOV_RCAP_GERAR { get; set; } = new LT3214S_TABELA_MOV_RCAP_GERAR();
            public class LT3214S_TABELA_MOV_RCAP_GERAR : VarBasis
            {
                /*"      10   FILLER             PIC  X(004)  VALUE '9900'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"9900");
                /*"      10   FILLER             PIC  X(004)  VALUE '9900'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"9900");
                /*"      10   FILLER             PIC  X(004)  VALUE '9900'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"9900");
                /*"      10   FILLER             PIC  X(004)  VALUE '9900'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"9900");
                /*"      10   FILLER             PIC  X(004)  VALUE '9900'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"9900");
                /*"   05  TABELA-MOV-RCAP-GERAR-R REDEFINES TABELA-MOV-RCAP-GERAR.*/
            }
            private _REDEF_LT3214S_TABELA_MOV_RCAP_GERAR_R _tabela_mov_rcap_gerar_r { get; set; }
            public _REDEF_LT3214S_TABELA_MOV_RCAP_GERAR_R TABELA_MOV_RCAP_GERAR_R
            {
                get { _tabela_mov_rcap_gerar_r = new _REDEF_LT3214S_TABELA_MOV_RCAP_GERAR_R(); _.Move(TABELA_MOV_RCAP_GERAR, _tabela_mov_rcap_gerar_r); VarBasis.RedefinePassValue(TABELA_MOV_RCAP_GERAR, _tabela_mov_rcap_gerar_r, TABELA_MOV_RCAP_GERAR); _tabela_mov_rcap_gerar_r.ValueChanged += () => { _.Move(_tabela_mov_rcap_gerar_r, TABELA_MOV_RCAP_GERAR); }; return _tabela_mov_rcap_gerar_r; }
                set { VarBasis.RedefinePassValue(value, _tabela_mov_rcap_gerar_r, TABELA_MOV_RCAP_GERAR); }
            }  //Redefines
            public class _REDEF_LT3214S_TABELA_MOV_RCAP_GERAR_R : VarBasis
            {
                /*"      10 TAB-MOV-RCAP-GERAR  OCCURS 5 TIMES.*/
                public ListBasis<LT3214S_TAB_MOV_RCAP_GERAR> TAB_MOV_RCAP_GERAR { get; set; } = new ListBasis<LT3214S_TAB_MOV_RCAP_GERAR>(5);
                public class LT3214S_TAB_MOV_RCAP_GERAR : VarBasis
                {
                    /*"         15 TB-MOV-RCAP-GERAR       PIC  9(002).*/
                    public IntBasis TB_MOV_RCAP_GERAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"         15 TB-TIPO-ENDOSSO-GERAR   PIC  9(002).*/
                    public IntBasis TB_TIPO_ENDOSSO_GERAR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"   05       WS-QTDIAS-VIGENCIA   PIC S9(004)  COMP.*/

                    public LT3214S_TAB_MOV_RCAP_GERAR()
                    {
                        TB_MOV_RCAP_GERAR.ValueChanged += OnValueChanged;
                        TB_TIPO_ENDOSSO_GERAR.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_LT3214S_TABELA_MOV_RCAP_GERAR_R()
                {
                    TAB_MOV_RCAP_GERAR.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_QTDIAS_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-QTDIAS-DECORRIDOS PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_DECORRIDOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       WS-QTDIAS-DECORRER   PIC S9(004)  COMP.*/
            public IntBasis WS_QTDIAS_DECORRER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05       V0APO-NUM-APOLICE    PIC S9(013)  COMP-3 VALUE +0.*/
            public IntBasis V0APO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"   05  WS-FATOR-AGRAV              PIC 9(03)V9(06).*/
            public DoubleBasis WS_FATOR_AGRAV { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(06)."), 6);
            /*"   05  WS-FATOR-AGRAV-TAXA-08      PIC 9(03)V9(06).*/
            public DoubleBasis WS_FATOR_AGRAV_TAXA_08 { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(06)."), 6);
            /*"   05       VIND-NUM-TITULO      PIC S9(004)  COMP VALUE +0.*/
            public IntBasis VIND_NUM_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05  WS-NUMERO-LOTERICO  PIC  9(009)  VALUE ZEROS.*/
            public IntBasis WS_NUMERO_LOTERICO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"   05  FILLER REDEFINES WS-NUMERO-LOTERICO.*/
            private _REDEF_LT3214S_FILLER_5 _filler_5 { get; set; }
            public _REDEF_LT3214S_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_LT3214S_FILLER_5(); _.Move(WS_NUMERO_LOTERICO, _filler_5); VarBasis.RedefinePassValue(WS_NUMERO_LOTERICO, _filler_5, WS_NUMERO_LOTERICO); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_NUMERO_LOTERICO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WS_NUMERO_LOTERICO); }
            }  //Redefines
            public class _REDEF_LT3214S_FILLER_5 : VarBasis
            {
                /*"     10 WS-NUM-LOTERICO    PIC  9(008).*/
                public IntBasis WS_NUM_LOTERICO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"     10 WS-DV-LOTERICO     PIC  9(001).*/
                public IntBasis WS_DV_LOTERICO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"   05  WS-CGCCPF-X                PIC  X(15).*/

                public _REDEF_LT3214S_FILLER_5()
                {
                    WS_NUM_LOTERICO.ValueChanged += OnValueChanged;
                    WS_DV_LOTERICO.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_CGCCPF_X { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
            /*"   05  WS-CGCCPF-NUM REDEFINES WS-CGCCPF-X                                 PIC  9(15).*/
            private _REDEF_IntBasis _ws_cgccpf_num { get; set; }
            public _REDEF_IntBasis WS_CGCCPF_NUM
            {
                get { _ws_cgccpf_num = new _REDEF_IntBasis(new PIC("9", "15", "9(15).")); ; _.Move(WS_CGCCPF_X, _ws_cgccpf_num); VarBasis.RedefinePassValue(WS_CGCCPF_X, _ws_cgccpf_num, WS_CGCCPF_X); _ws_cgccpf_num.ValueChanged += () => { _.Move(_ws_cgccpf_num, WS_CGCCPF_X); }; return _ws_cgccpf_num; }
                set { VarBasis.RedefinePassValue(value, _ws_cgccpf_num, WS_CGCCPF_X); }
            }  //Redefines
            /*"   05       WS-VALOR         PIC 9(010)V9(2)      VALUE ZEROS.*/
            public DoubleBasis WS_VALOR { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V9(2)"), 2);
            /*"   05       WS-VALOR-S       PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-VALOR1-S      PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR1_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-VALOR2-S      PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR2_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-VALOR3-S      PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR3_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-VALOR4-S      PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR4_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-VALOR5-S      PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR5_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-VALOR6-S      PIC ZZZ.ZZ9,99-     VALUE ZEROS.*/
            public DoubleBasis WS_VALOR6_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99-"), 3);
            /*"   05       WS-PCT1-S        PIC ZZ9,9999-      VALUE ZEROS.*/
            public DoubleBasis WS_PCT1_S { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9999-"), 5);
            /*"   05       WS-PCT1-S1       PIC ZZ9,9999-      VALUE ZEROS.*/
            public DoubleBasis WS_PCT1_S1 { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9999-"), 5);
            /*"   05       WS-INDICE-S      PIC ZZ9            VALUE ZEROS.*/
            public IntBasis WS_INDICE_S { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9"));
            /*"   05       WS-VALOR-PREMIO             PIC S9(008)V9(6)  COMP-3*/
            public DoubleBasis WS_VALOR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(6)"), 6);
            /*"   05       WS-FATOR                    PIC S9(003)V9(6)  COMP-3*/
            public DoubleBasis WS_FATOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05       WS-FATOR-S                  PIC ZZ9,999999.*/
            public DoubleBasis WS_FATOR_S { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V999999."), 6);
            /*"   05       WS-TAXA-BASE-S              PIC ZZ9,999999999.*/
            public DoubleBasis WS_TAXA_BASE_S { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V999999999."), 9);
            /*"   05       WS-TAXA-S                   PIC ZZ9,999999999.*/
            public DoubleBasis WS_TAXA_S { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V999999999."), 9);
            /*"   05       WS-TAXA-S1                  PIC ZZ9,999999999.*/
            public DoubleBasis WS_TAXA_S1 { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V999999999."), 9);
            /*"   05       WS-PREMIO-S                 PIC ZZZ.ZZ9,99.*/
            public DoubleBasis WS_PREMIO_S { get; set; } = new DoubleBasis(new PIC("9", "6", "ZZZ.ZZ9V99."), 2);
            /*"   05       WS-LT3214-PCT-PLURI         PIC S9(003)V9(4)  COMP-3*/
            public DoubleBasis WS_LT3214_PCT_PLURI { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(4)"), 4);
            /*"   05       WS-LT3214-PCT-PLURI-S       PIC ZZ9,9999.*/
            public DoubleBasis WS_LT3214_PCT_PLURI_S { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V9999."), 4);
            /*"   05       WS-VLR-ADIC-COBER-S         PIC ZZ.ZZ9,99.*/
            public DoubleBasis WS_VLR_ADIC_COBER_S { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
            /*"   05       WS-VLR-ADIC-COBER-S1        PIC ZZ.ZZ9,99.*/
            public DoubleBasis WS_VLR_ADIC_COBER_S1 { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
            /*"   05       WS-IOF-S1                   PIC ZZ.ZZ9,99.*/
            public DoubleBasis WS_IOF_S1 { get; set; } = new DoubleBasis(new PIC("9", "5", "ZZ.ZZ9V99."), 2);
            /*"   05       WS-LT3214-QTD-DIAS-PLURI    PIC S9(004) COMP.*/
            public IntBasis WS_LT3214_QTD_DIAS_PLURI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05      WS-DESC-AGRUP-S       PIC ZZZZ.ZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_DESC_AGRUP_S { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-"), 3);
            /*"   05      WS-DESC-EXP-S         PIC ZZZZ.ZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_DESC_EXP_S { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-"), 3);
            /*"   05      WS-DESC-FIDEL-S       PIC ZZZZ.ZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_DESC_FIDEL_S { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-"), 3);
            /*"   05      WS-DESC-COFRE-S       PIC ZZZZ.ZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_DESC_COFRE_S { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-"), 3);
            /*"   05      WS-DESC-BLINDAGEM-S   PIC ZZZZ.ZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_DESC_BLINDAGEM_S { get; set; } = new DoubleBasis(new PIC("9", "7", "ZZZZ.ZZ9V99-"), 3);
            /*"   05      WS-PCT-DESC-AGRUP-S     PIC ZZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_PCT_DESC_AGRUP_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99-"), 3);
            /*"   05      WS-PCT-DESC-EXP-S       PIC ZZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_PCT_DESC_EXP_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99-"), 3);
            /*"   05      WS-PCT-DESC-FIDEL-S     PIC ZZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_PCT_DESC_FIDEL_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99-"), 3);
            /*"   05      WS-PCT-DESC-COFRE-S     PIC ZZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_PCT_DESC_COFRE_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99-"), 3);
            /*"   05      WS-PCT-DESC-BLINDAGEM-S PIC ZZZ9,99- VALUE ZEROS.*/
            public DoubleBasis WS_PCT_DESC_BLINDAGEM_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V99-"), 3);
            /*"   05      WS-PCT-IOF-S    PIC    ZZZ9,9999.*/
            public DoubleBasis WS_PCT_IOF_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V9999."), 4);
            /*"   05      WS-COEF1-S      PIC    ZZZ9,9999.*/
            public DoubleBasis WS_COEF1_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V9999."), 4);
            /*"   05      WS-COEFN-S      PIC    ZZZ9,9999.*/
            public DoubleBasis WS_COEFN_S { get; set; } = new DoubleBasis(new PIC("9", "4", "ZZZ9V9999."), 4);
            /*"   05       WS-PCT-PRM-ANUAL            PIC S9(003)V99 COMP-3.*/
            public DoubleBasis WS_PCT_PRM_ANUAL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"   05       WS-PCT-PRM-DECORRIDO        PIC S9(003)V99 COMP-3.*/
            public DoubleBasis WS_PCT_PRM_DECORRIDO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
            /*"   05       WS-TOTAL-DESCONTO           PIC S9(007)V99 COMP-3.*/
            public DoubleBasis WS_TOTAL_DESCONTO { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V99"), 2);
            /*"   05       WS-50PCT-SUBTOTAL           PIC S9(007)V99 COMP-3.*/
            public DoubleBasis WS_50PCT_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V99"), 2);
            /*"   05       WS-70PCT-SUBTOTAL           PIC S9(007)V99 COMP-3.*/
            public DoubleBasis WS_70PCT_SUBTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "7", "S9(007)V99"), 2);
            /*"   05       WS-PCT-DESC-TOTAL           PIC S9(008)V99 COMP-3                                                VALUE ZEROS.*/
            public DoubleBasis WS_PCT_DESC_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V99"), 2);
            /*"   05       WS-PCT-DESC-ARRED           PIC S9(008)  COMP-3                                                     VALUE ZEROS*/
            public IntBasis WS_PCT_DESC_ARRED { get; set; } = new IntBasis(new PIC("S9", "8", "S9(008)"));
            /*"   05  WS-PCT-COBERTURA           PIC S9(003)V9(9)  COMP-3.*/
            public DoubleBasis WS_PCT_COBERTURA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
            /*"   05  WS-PCT-DESC-COB-ADIC       PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_DESC_COB_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05  WS-PCT-DESC-EXP            PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_DESC_EXP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05  WS-PCT-DESC-FIDEL          PIC S9(003)V9(6)  COMP-3.*/
            public DoubleBasis WS_PCT_DESC_FIDEL { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
            /*"   05  WS-PCT-IOF           PIC S9(008)V9(6)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_PCT_IOF { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(6)"), 6);
            /*"   05  WS-CUSTO-APOLICE     PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_CUSTO_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-VLR-TAXA-ADESAO   PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_TAXA_ADESAO { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-TAXA              PIC S9(003)V9(9)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_TAXA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(9)"), 9);
            /*"   05  WS-DISPLAY           PIC  X(003) VALUE 'S'.*/
            public StringBasis WS_DISPLAY { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"S");
            /*"   05  WS-VLR-ADIC-COBER    PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_ADIC_COBER { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-VLR-MIN-SAP       PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_MIN_SAP { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05  WS-VLR-MIN-PRMLIQ    PIC S9(008)V9(2)  COMP-3 VALUE +0.*/
            public DoubleBasis WS_VLR_MIN_PRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(008)V9(2)"), 2);
            /*"   05         WS-DATE.*/
            public LT3214S_WS_DATE WS_DATE { get; set; } = new LT3214S_WS_DATE();
            public class LT3214S_WS_DATE : VarBasis
            {
                /*"     10       WS-AA-DATE         PIC  9(02).*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10       WS-MM-DATE         PIC  9(02).*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10       WS-DD-DATE         PIC  9(02).*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05      WS-DATA-PRI-DTVENC-DEBITO        PIC X(10).*/
            }
            public StringBasis WS_DATA_PRI_DTVENC_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05      WS-DATA-SEG-DTVENC-DEBITO        PIC X(10).*/
            public StringBasis WS_DATA_SEG_DTVENC_DEBITO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05      WS-DATA-PROM-BOLETO              PIC X(10).*/
            public StringBasis WS_DATA_PROM_BOLETO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05      WS-DATA-MAX-PROM-BOLETO          PIC X(10).*/
            public StringBasis WS_DATA_MAX_PROM_BOLETO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05      WS-DATA-VENC-BOLETO-CALC  PIC X(10).*/
            public StringBasis WS_DATA_VENC_BOLETO_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05      WS-DATA-VENC-DEBITO-CALC  PIC X(10).*/
            public StringBasis WS_DATA_VENC_DEBITO_CALC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DATA-SQL-AUX               PIC X(10).*/
            public StringBasis WS_DATA_SQL_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DATA-SQL-AUX-R REDEFINES WS-DATA-SQL-AUX .*/
            private _REDEF_LT3214S_WS_DATA_SQL_AUX_R _ws_data_sql_aux_r { get; set; }
            public _REDEF_LT3214S_WS_DATA_SQL_AUX_R WS_DATA_SQL_AUX_R
            {
                get { _ws_data_sql_aux_r = new _REDEF_LT3214S_WS_DATA_SQL_AUX_R(); _.Move(WS_DATA_SQL_AUX, _ws_data_sql_aux_r); VarBasis.RedefinePassValue(WS_DATA_SQL_AUX, _ws_data_sql_aux_r, WS_DATA_SQL_AUX); _ws_data_sql_aux_r.ValueChanged += () => { _.Move(_ws_data_sql_aux_r, WS_DATA_SQL_AUX); }; return _ws_data_sql_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sql_aux_r, WS_DATA_SQL_AUX); }
            }  //Redefines
            public class _REDEF_LT3214S_WS_DATA_SQL_AUX_R : VarBasis
            {
                /*"     10     WS-ANO-SQL-AUX                PIC 9(04).*/
                public IntBasis WS_ANO_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"     10     FILLER                        PIC X(01).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-MES-SQL-AUX                PIC 9(02).*/
                public IntBasis WS_MES_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"     10     FILLER                        PIC X(01).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
                /*"     10     WS-DIA-SQL-AUX                PIC 9(02).*/
                public IntBasis WS_DIA_SQL_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"   05       WS-DATA-DB2.*/

                public _REDEF_LT3214S_WS_DATA_SQL_AUX_R()
                {
                    WS_ANO_SQL_AUX.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WS_MES_SQL_AUX.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WS_DIA_SQL_AUX.ValueChanged += OnValueChanged;
                }

            }
            public LT3214S_WS_DATA_DB2 WS_DATA_DB2 { get; set; } = new LT3214S_WS_DATA_DB2();
            public class LT3214S_WS_DATA_DB2 : VarBasis
            {
                /*"     10     WS-ANO-DB2       PIC  9(004)          VALUE ZEROS.*/
                public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"     10     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-MES-DB2       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"     10     FILLER           PIC  X(001)          VALUE '-'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"     10     WS-DIA-DB2       PIC  9(002)          VALUE ZEROS.*/
                public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"   05       WS-DATA-SQL      PIC  X(010)          VALUE SPACE.*/
            }
            public StringBasis WS_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"   05       WS-DATA-SQL-R REDEFINES WS-DATA-SQL.*/
            private _REDEF_LT3214S_WS_DATA_SQL_R _ws_data_sql_r { get; set; }
            public _REDEF_LT3214S_WS_DATA_SQL_R WS_DATA_SQL_R
            {
                get { _ws_data_sql_r = new _REDEF_LT3214S_WS_DATA_SQL_R(); _.Move(WS_DATA_SQL, _ws_data_sql_r); VarBasis.RedefinePassValue(WS_DATA_SQL, _ws_data_sql_r, WS_DATA_SQL); _ws_data_sql_r.ValueChanged += () => { _.Move(_ws_data_sql_r, WS_DATA_SQL); }; return _ws_data_sql_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_sql_r, WS_DATA_SQL); }
            }  //Redefines
            public class _REDEF_LT3214S_WS_DATA_SQL_R : VarBasis
            {
                /*"     10     WS-ANO-SQL       PIC  9(004).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10     FILLER           PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10     WS-MES-SQL       PIC  9(002).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10     FILLER           PIC  X(001).*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10     WS-DIA-SQL       PIC  9(002).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05       WS-ERRO                  PIC   9(04).*/

                public _REDEF_LT3214S_WS_DATA_SQL_R()
                {
                    WS_ANO_SQL.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WS_MES_SQL.ValueChanged += OnValueChanged;
                    FILLER_11.ValueChanged += OnValueChanged;
                    WS_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WS-QTD-PARCELAS               PIC   9(04).*/
            public IntBasis WS_QTD_PARCELAS { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WS-QTD-PARCELAS-SALVA         PIC   9(04).*/
            public IntBasis WS_QTD_PARCELAS_SALVA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WS-IND-VIGENCIA-PLURI-SALVA   PIC   9(04).*/
            public IntBasis WS_IND_VIGENCIA_PLURI_SALVA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"   05       WS-DTINIVIG-PROPOSTA-SALVA    PIC   X(10).*/
            public StringBasis WS_DTINIVIG_PROPOSTA_SALVA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WS-DTTERVIG-PROPOSTA-SALVA    PIC   X(10).*/
            public StringBasis WS_DTTERVIG_PROPOSTA_SALVA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   05       WTOTAL-PREMIO-BRUTO      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_BRUTO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-PREMIO-LIQNP      PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_PREMIO_LIQNP { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-JURO-1P           PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_JURO_1P { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-JURO              PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_JURO { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WTOTAL-IOF               PIC   9(009)V99.*/
            public DoubleBasis WTOTAL_IOF { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IOF-PRIM              PIC   9(009)V99.*/
            public DoubleBasis WS_IOF_PRIM { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IOF-OUTR              PIC   9(009)V99.*/
            public DoubleBasis WS_IOF_OUTR { get; set; } = new DoubleBasis(new PIC("9", "9", "9(009)V99."), 2);
            /*"   05       WS-IE1                   PIC   9(006) VALUE 0.*/
            public IntBasis WS_IE1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IE2                   PIC   9(006) VALUE 0.*/
            public IntBasis WS_IE2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IE3                   PIC   9(006) VALUE 0.*/
            public IntBasis WS_IE3 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IND                   PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IND1                  PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND1 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-IND2                  PIC   9(006) VALUE 0.*/
            public IntBasis WS_IND2 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"   05       WS-ORDEM                 PIC   9(006) VALUE 1.*/
            public IntBasis WS_ORDEM { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 1);
            /*"   05       WS-INDICE                PIC   9(006) VALUE 1.*/
            public IntBasis WS_INDICE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 1);
            /*"   05       WS-HOUVE-ALTERACAO       PIC X(003) VALUE SPACES.*/
            public StringBasis WS_HOUVE_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05       WS-ANO-RENOVACAO         PIC   X(004) VALUE ' '.*/
            public StringBasis WS_ANO_RENOVACAO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
            /*"   05 TAB-IMPSEG-SALVA   COMP-3.*/
            public LT3214S_TAB_IMPSEG_SALVA TAB_IMPSEG_SALVA { get; set; } = new LT3214S_TAB_IMPSEG_SALVA();
            public class LT3214S_TAB_IMPSEG_SALVA : VarBasis
            {
                /*"     10 TB-IMPSEG-SALVA PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_IMPSEG_SALVA { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05 TAB-PREMIO-LIQ   COMP-3.*/
            }
            public LT3214S_TAB_PREMIO_LIQ TAB_PREMIO_LIQ { get; set; } = new LT3214S_TAB_PREMIO_LIQ();
            public class LT3214S_TAB_PREMIO_LIQ : VarBasis
            {
                /*"     10 TB-PREMIO-LIQ  PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_PREMIO_LIQ { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05 TAB-PREMIO-LIQ-1PCL   COMP-3.*/
            }
            public LT3214S_TAB_PREMIO_LIQ_1PCL TAB_PREMIO_LIQ_1PCL { get; set; } = new LT3214S_TAB_PREMIO_LIQ_1PCL();
            public class LT3214S_TAB_PREMIO_LIQ_1PCL : VarBasis
            {
                /*"     10 TB-PREMIO-LIQ-1PCL PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_PREMIO_LIQ_1PCL { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05 TAB-IOF       COMP-3.*/
            }
            public LT3214S_TAB_IOF TAB_IOF { get; set; } = new LT3214S_TAB_IOF();
            public class LT3214S_TAB_IOF : VarBasis
            {
                /*"     10 TB-IOF       PIC S9(08)V99 COMP-3 OCCURS 20 TIMES.*/
                public ListBasis<DoubleBasis, double> TB_IOF { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "8", "S9(08)V99"), 20);
                /*"   05     TABELA-ORDEM-COBER.*/
            }
            public LT3214S_TABELA_ORDEM_COBER TABELA_ORDEM_COBER { get; set; } = new LT3214S_TABELA_ORDEM_COBER();
            public class LT3214S_TABELA_ORDEM_COBER : VarBasis
            {
                /*"    07     TAB-ORDEM-COBER.*/
                public LT3214S_TAB_ORDEM_COBER TAB_ORDEM_COBER { get; set; } = new LT3214S_TAB_ORDEM_COBER();
                public class LT3214S_TAB_ORDEM_COBER : VarBasis
                {
                    /*"     10   FILLER             PIC  9(002)  VALUE 7.*/
                    public IntBasis FILLER_12 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 7);
                    /*"     10   FILLER             PIC  9(002)  VALUE 8.*/
                    public IntBasis FILLER_13 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 8);
                    /*"     10   FILLER             PIC  9(002)  VALUE 9.*/
                    public IntBasis FILLER_14 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 9);
                    /*"     10   FILLER             PIC  9(002)  VALUE 3.*/
                    public IntBasis FILLER_15 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 3);
                    /*"     10   FILLER             PIC  9(002)  VALUE 6.*/
                    public IntBasis FILLER_16 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 6);
                    /*"     10   FILLER             PIC  9(002)  VALUE 10.*/
                    public IntBasis FILLER_17 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 10);
                    /*"     10   FILLER             PIC  9(002)  VALUE 11.*/
                    public IntBasis FILLER_18 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 11);
                    /*"     10   FILLER             PIC  9(002)  VALUE 12.*/
                    public IntBasis FILLER_19 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 12);
                    /*"     10   FILLER             PIC  9(002)  VALUE 13.*/
                    public IntBasis FILLER_20 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 13);
                    /*"     10   FILLER             PIC  9(002)  VALUE 14.*/
                    public IntBasis FILLER_21 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 14);
                    /*"     10   FILLER             PIC  9(002)  VALUE 15.*/
                    public IntBasis FILLER_22 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 15);
                    /*"     10   FILLER             PIC  9(002)  VALUE 16.*/
                    public IntBasis FILLER_23 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 16);
                    /*"     10   FILLER             PIC  9(002)  VALUE 17.*/
                    public IntBasis FILLER_24 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 17);
                    /*"     10   FILLER             PIC  9(002)  VALUE 18.*/
                    public IntBasis FILLER_25 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 18);
                    /*"     10   FILLER             PIC  9(002)  VALUE 19.*/
                    public IntBasis FILLER_26 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                    /*"    07     TAB-ORDEM-COBER-R   REDEFINES          TAB-ORDEM-COBER.*/
                }
                private _REDEF_LT3214S_TAB_ORDEM_COBER_R _tab_ordem_cober_r { get; set; }
                public _REDEF_LT3214S_TAB_ORDEM_COBER_R TAB_ORDEM_COBER_R
                {
                    get { _tab_ordem_cober_r = new _REDEF_LT3214S_TAB_ORDEM_COBER_R(); _.Move(TAB_ORDEM_COBER, _tab_ordem_cober_r); VarBasis.RedefinePassValue(TAB_ORDEM_COBER, _tab_ordem_cober_r, TAB_ORDEM_COBER); _tab_ordem_cober_r.ValueChanged += () => { _.Move(_tab_ordem_cober_r, TAB_ORDEM_COBER); }; return _tab_ordem_cober_r; }
                    set { VarBasis.RedefinePassValue(value, _tab_ordem_cober_r, TAB_ORDEM_COBER); }
                }  //Redefines
                public class _REDEF_LT3214S_TAB_ORDEM_COBER_R : VarBasis
                {
                    /*"     10   TB-ORDEM-COBER   OCCURS 15 TIMES PIC  9(002).*/
                    public ListBasis<IntBasis, Int64> TB_ORDEM_COBER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "2", "9(002)."), 15);
                    /*"   05 TABELA-DESCONTOS.*/

                    public _REDEF_LT3214S_TAB_ORDEM_COBER_R()
                    {
                        TB_ORDEM_COBER.ValueChanged += OnValueChanged;
                    }

                }
            }
            public LT3214S_TABELA_DESCONTOS TABELA_DESCONTOS { get; set; } = new LT3214S_TABELA_DESCONTOS();
            public class LT3214S_TABELA_DESCONTOS : VarBasis
            {
                /*"     10 TB-DESCONTOS   OCCURS 20 TIMES.*/
                public ListBasis<LT3214S_TB_DESCONTOS> TB_DESCONTOS { get; set; } = new ListBasis<LT3214S_TB_DESCONTOS>(20);
                public class LT3214S_TB_DESCONTOS : VarBasis
                {
                    /*"       15 TB-COD-DESCONTO           PIC  9(004).*/
                    public IntBasis TB_COD_DESCONTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       15 TB-IND-TIPO-DESCONTO      PIC  9(004).*/
                    public IntBasis TB_IND_TIPO_DESCONTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       15 TB-STA-DESCONTO           PIC  9(004).*/
                    public IntBasis TB_STA_DESCONTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"       15 TB-PCT-DESCONTO           PIC  9(005)V999.*/
                    public DoubleBasis TB_PCT_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "5", "9(005)V999."), 3);
                    /*"       15 TB-VLR-BASE-CALCULO       PIC  9(010)V99.*/
                    public DoubleBasis TB_VLR_BASE_CALCULO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                    /*"       15 TB-VLR-DESCONTO           PIC  9(010)V99.*/
                    public DoubleBasis TB_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                    /*"   05            WABEND.*/
                }
            }
            public LT3214S_WABEND WABEND { get; set; } = new LT3214S_WABEND();
            public class LT3214S_WABEND : VarBasis
            {
                /*"    10          FILLER           PIC  X(008)      VALUE               'LT3214S '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LT3214S ");
                /*"    10          FILLER           PIC  X(025)      VALUE               '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10          WNR-EXEC-SQL     PIC  X(004)      VALUE   '0000'*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10          FILLER           PIC  X(013)      VALUE               ' *** SQLCODE '.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10          WSQLCODE         PIC  ZZZZZ999-   VALUE    ZEROS*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Copies.LBLT3214 LBLT3214 { get; set; } = new Copies.LBLT3214();
        public Dclgens.LTMVPRCO LTMVPRCO { get; set; } = new Dclgens.LTMVPRCO();
        public Dclgens.LTMVPROP LTMVPROP { get; set; } = new Dclgens.LTMVPROP();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.LT028 LT028 { get; set; } = new Dclgens.LT028();
        public Dclgens.LT029 LT029 { get; set; } = new Dclgens.LT029();
        public LT3214S_CPREMIO CPREMIO { get; set; } = new LT3214S_CPREMIO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(LBLT3214_LT3214_AREA_PARAMETROS LBLT3214_LT3214_AREA_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*LT3214_AREA_PARAMETROS*/
        {
            try
            {
                this.LBLT3214.LT3214_AREA_PARAMETROS = LBLT3214_LT3214_AREA_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LBLT3214.LT3214_AREA_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -344- PERFORM R0100-00-CRITICA-PARAMETROS */

            R0100_00_CRITICA_PARAMETROS_SECTION();

            /*" -346- PERFORM R0900-00-DECLARE-PREMIOS */

            R0900_00_DECLARE_PREMIOS_SECTION();

            /*" -349- PERFORM R1000-00-PROCESSAR-REGISTRO UNTIL WFIM-PREMIO NOT EQUAL SPACES */

            while (!(!WS_AREA_TRABALHO.WFIM_PREMIO.IsEmpty()))
            {

                R1000_00_PROCESSAR_REGISTRO_SECTION();
            }

            /*" -350- PERFORM R9000-00-ROT-RETORNO */

            R9000_00_ROT_RETORNO_SECTION();

            /*" -350- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-CRITICA-PARAMETROS-SECTION */
        private void R0100_00_CRITICA_PARAMETROS_SECTION()
        {
            /*" -361- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), WS_AREA_TRABALHO.WS_CURRENT_DATE);

            /*" -363- MOVE '1001-01-01' TO WS-DATA-DB2 */
            _.Move("1001-01-01", WS_AREA_TRABALHO.WS_DATA_DB2);

            /*" -364- ACCEPT WS-DATE FROM DATE */
            _.Move(_.AcceptDate("DATE"), WS_AREA_TRABALHO.WS_DATE);

            /*" -365- MOVE WS-DD-DATE TO WS-DIA-DB2 */
            _.Move(WS_AREA_TRABALHO.WS_DATE.WS_DD_DATE, WS_AREA_TRABALHO.WS_DATA_DB2.WS_DIA_DB2);

            /*" -366- MOVE WS-MM-DATE TO WS-MES-DB2 */
            _.Move(WS_AREA_TRABALHO.WS_DATE.WS_MM_DATE, WS_AREA_TRABALHO.WS_DATA_DB2.WS_MES_DB2);

            /*" -367- MOVE WS-AA-DATE TO WS-ANO-DB2 */
            _.Move(WS_AREA_TRABALHO.WS_DATE.WS_AA_DATE, WS_AREA_TRABALHO.WS_DATA_DB2.WS_ANO_DB2);

            /*" -369- ADD 2000 TO WS-ANO-DB2 */
            WS_AREA_TRABALHO.WS_DATA_DB2.WS_ANO_DB2.Value = WS_AREA_TRABALHO.WS_DATA_DB2.WS_ANO_DB2 + 2000;

            /*" -375- PERFORM R0100_00_CRITICA_PARAMETROS_DB_SELECT_1 */

            R0100_00_CRITICA_PARAMETROS_DB_SELECT_1();

            /*" -378- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -379- DISPLAY 'LT3214-ERRO ACESSO V0SISTEMA' */
                _.Display($"LT3214-ERRO ACESSO V0SISTEMA");

                /*" -380- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -382- END-IF */
            }


            /*" -384- MOVE V0SIST-DTMOVABE TO WS-DATA-SQL */
            _.Move(WS_AREA_TRABALHO.V0SIST_DTMOVABE, WS_AREA_TRABALHO.WS_DATA_SQL);

            /*" -385- IF WS-DISPLAY EQUAL 'S' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "S")
            {

                /*" -387- DISPLAY 'LT3214S-R0100-DATA CORRENTE:' WS-DT-TODAY ' ' WS-HR-TODAY */

                $"LT3214S-R0100-DATA CORRENTE:{WS_AREA_TRABALHO.WS_CURRENT_DATE.WS_CUR_DATE_R.WS_DT_TODAY} {WS_AREA_TRABALHO.WS_CURRENT_DATE.WS_CUR_DATE_R.WS_HR_TODAY}"
                .Display();

                /*" -389- DISPLAY WS-VERSAO ' DATA-SISTEMA:' WS-DATA-SQL */

                $"{WS_VERSAO} DATA-SISTEMA:{WS_AREA_TRABALHO.WS_DATA_SQL}"
                .Display();

                /*" -390- DISPLAY ' LOT :' LT3214-COD-LOTERICO */
                _.Display($" LOT :{LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_LOTERICO}");

                /*" -391- DISPLAY ' SEQ:' LT3214-SEQ-PROPOSTA */
                _.Display($" SEQ:{LBLT3214.LT3214_AREA_PARAMETROS.LT3214_SEQ_PROPOSTA}");

                /*" -393- END-IF */
            }


            /*" -395- MOVE 0 TO WS-ERRO LT3214-COD-RETORNO */
            _.Move(0, WS_AREA_TRABALHO.WS_ERRO, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO);

            /*" -397- MOVE SPACES TO LT3214-MSG-RETORNO */
            _.Move("", LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

            /*" -398- IF LT3214-COD-LOTERICO EQUAL ZEROS */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_LOTERICO == 00)
            {

                /*" -400- MOVE '  LT3214S-COD LOTERICO INVALIDO ' TO LT3214-MSG-RETORNO */
                _.Move("  LT3214S-COD LOTERICO INVALIDO ", LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -401- MOVE 100 TO LT3214-COD-RETORNO */
                _.Move(100, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO);

                /*" -402- DISPLAY LT3214-MSG-RETORNO */
                _.Display(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -403- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -405- END-IF */
            }


            /*" -406- IF LT3214-SEQ-PROPOSTA EQUAL ZEROS */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_SEQ_PROPOSTA == 00)
            {

                /*" -408- MOVE '  LT3214S-SEQ-PROPOSTA  INVALIDO ' TO LT3214-MSG-RETORNO */
                _.Move("  LT3214S-SEQ-PROPOSTA  INVALIDO ", LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -409- MOVE 100 TO LT3214-COD-RETORNO */
                _.Move(100, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO);

                /*" -410- DISPLAY LT3214-MSG-RETORNO */
                _.Display(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -411- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -413- END-IF */
            }


            /*" -414- IF LT3214-NUM-PROPOSTA-SIM EQUAL ZEROS */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_NUM_PROPOSTA_SIM == 00)
            {

                /*" -416- MOVE ' LT3214-NUM-PROPOSTA-SIM  INVALIDO ' TO LT3214-MSG-RETORNO */
                _.Move(" LT3214-NUM-PROPOSTA-SIM  INVALIDO ", LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -417- MOVE 100 TO LT3214-COD-RETORNO */
                _.Move(100, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO);

                /*" -418- DISPLAY LT3214-MSG-RETORNO */
                _.Display(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -419- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -421- END-IF */
            }


            /*" -422- IF LT3214-HORA-MOVIMENTO EQUAL SPACES */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_HORA_MOVIMENTO.IsEmpty())
            {

                /*" -424- MOVE ' LT3214-HORA-MOVIMENTO INVALIDA ' TO LT3214-MSG-RETORNO */
                _.Move(" LT3214-HORA-MOVIMENTO INVALIDA ", LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -425- MOVE 100 TO LT3214-COD-RETORNO */
                _.Move(100, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO);

                /*" -426- DISPLAY LT3214-MSG-RETORNO */
                _.Display(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -427- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -429- END-IF */
            }


            /*" -430- MOVE LT3214-DATA-MOVIMENTO TO WS-DATA-SQL-AUX */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_DATA_MOVIMENTO, WS_AREA_TRABALHO.WS_DATA_SQL_AUX);

            /*" -431- PERFORM R0140-CRITICA-DATA-SQL */

            R0140_CRITICA_DATA_SQL_SECTION();

            /*" -432- IF WS-ERRO > ZEROS */

            if (WS_AREA_TRABALHO.WS_ERRO > 00)
            {

                /*" -434- MOVE ' LT3214-DATA-MOVIMENTO-INVALIDA ' TO LT3214-MSG-RETORNO */
                _.Move(" LT3214-DATA-MOVIMENTO-INVALIDA ", LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -435- MOVE 100 TO LT3214-COD-RETORNO */
                _.Move(100, LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO);

                /*" -436- DISPLAY LT3214-MSG-RETORNO */
                _.Display(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO);

                /*" -437- GO TO R0100-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;

                /*" -439- END-IF */
            }


            /*" -440- IF LT3214-COD-RETORNO GREATER ZEROS */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO > 00)
            {

                /*" -441- PERFORM R9000-00-ROT-RETORNO */

                R9000_00_ROT_RETORNO_SECTION();

                /*" -442- END-IF */
            }


            /*" -442- . */

        }

        [StopWatch]
        /*" R0100-00-CRITICA-PARAMETROS-DB-SELECT-1 */
        public void R0100_00_CRITICA_PARAMETROS_DB_SELECT_1()
        {
            /*" -375- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'LT' WITH UR END-EXEC. */

            var r0100_00_CRITICA_PARAMETROS_DB_SELECT_1_Query1 = new R0100_00_CRITICA_PARAMETROS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_CRITICA_PARAMETROS_DB_SELECT_1_Query1.Execute(r0100_00_CRITICA_PARAMETROS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, WS_AREA_TRABALHO.V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-INICIALIZAR-VARIAVEIS-SECTION */
        private void R0120_00_INICIALIZAR_VARIAVEIS_SECTION()
        {
            /*" -451- DISPLAY 'R0120-INICIALIZANDO VARIAVEIS...' */
            _.Display($"R0120-INICIALIZANDO VARIAVEIS...");

            /*" -453- MOVE SPACES TO WFIM-PREMIO */
            _.Move("", WS_AREA_TRABALHO.WFIM_PREMIO);

            /*" -453- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0140-CRITICA-DATA-SQL-SECTION */
        private void R0140_CRITICA_DATA_SQL_SECTION()
        {
            /*" -465- MOVE 0 TO WS-ERRO. */
            _.Move(0, WS_AREA_TRABALHO.WS_ERRO);

            /*" -471- IF WS-ANO-SQL-AUX LESS THAN 1900 OR WS-ANO-SQL-AUX GREATER 3000 OR WS-MES-SQL-AUX LESS THAN 1 OR WS-MES-SQL-AUX GREATER 12 OR WS-DIA-SQL-AUX LESS THAN 1 OR WS-DIA-SQL-AUX GREATER 31 */

            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX < 1900 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX > 3000 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX < 1 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX > 12 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX < 1 || WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 31)
            {

                /*" -472- MOVE 1 TO WS-ERRO */
                _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                /*" -473- ELSE */
            }
            else
            {


                /*" -474- IF WS-MES-SQL-AUX EQUAL 4 OR 6 OR 9 OR 11 */

                if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX.In("4", "6", "9", "11"))
                {

                    /*" -475- IF WS-DIA-SQL-AUX GREATER 30 */

                    if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 30)
                    {

                        /*" -476- MOVE 1 TO WS-ERRO */
                        _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                        /*" -478- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -479- ELSE */
                    }

                }
                else
                {


                    /*" -480- IF WS-MES-SQL-AUX EQUAL 2 */

                    if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_MES_SQL_AUX == 2)
                    {

                        /*" -482- DIVIDE WS-ANO-SQL-AUX BY 4 GIVING WS-IND REMAINDER WS-IND1 */
                        _.Divide(WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_ANO_SQL_AUX, 4, WS_AREA_TRABALHO.WS_IND, WS_AREA_TRABALHO.WS_IND1);

                        /*" -483- IF WS-IND1 GREATER ZEROS */

                        if (WS_AREA_TRABALHO.WS_IND1 > 00)
                        {

                            /*" -484- IF WS-DIA-SQL-AUX GREATER 28 */

                            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 28)
                            {

                                /*" -485- MOVE 1 TO WS-ERRO */
                                _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                                /*" -487- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -488- ELSE */
                            }

                        }
                        else
                        {


                            /*" -489- IF WS-DIA-SQL-AUX GREATER 29 */

                            if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 29)
                            {

                                /*" -490- MOVE 1 TO WS-ERRO */
                                _.Move(1, WS_AREA_TRABALHO.WS_ERRO);

                                /*" -492- ELSE NEXT SENTENCE */
                            }
                            else
                            {


                                /*" -493- ELSE */
                            }

                        }

                    }
                    else
                    {


                        /*" -494- IF WS-DIA-SQL-AUX GREATER 31 */

                        if (WS_AREA_TRABALHO.WS_DATA_SQL_AUX_R.WS_DIA_SQL_AUX > 31)
                        {

                            /*" -494- MOVE 1 TO WS-ERRO. */
                            _.Move(1, WS_AREA_TRABALHO.WS_ERRO);
                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0140_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PREMIOS-SECTION */
        private void R0900_00_DECLARE_PREMIOS_SECTION()
        {
            /*" -504- MOVE '0900' TO WNR-EXEC-SQL */
            _.Move("0900", WS_AREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -506- PERFORM R0120-00-INICIALIZAR-VARIAVEIS */

            R0120_00_INICIALIZAR_VARIAVEIS_SECTION();

            /*" -511- INITIALIZE DCLLT-PREMIO REPLACING NUMERIC BY ZEROS ALPHANUMERIC BY SPACES */
            _.Initialize(
                LT028.DCLLT_PREMIO
            );

            /*" -512- MOVE LT3214-COD-LOTERICO TO LTMVPROP-COD-EXT-SEGURADO */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_LOTERICO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO);

            /*" -513- MOVE LT3214-NUM-PROPOSTA-SIM TO LTMVPROP-NUM-PROPOSTA-SIM */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_NUM_PROPOSTA_SIM, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA_SIM);

            /*" -514- MOVE LT3214-SEQ-PROPOSTA TO LTMVPROP-SEQ-PROPOSTA */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_SEQ_PROPOSTA, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA);

            /*" -515- MOVE LT3214-DATA-MOVIMENTO TO LTMVPROP-DATA-MOVIMENTO */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_DATA_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO);

            /*" -517- MOVE LT3214-HORA-MOVIMENTO TO LTMVPROP-HORA-MOVIMENTO */
            _.Move(LBLT3214.LT3214_AREA_PARAMETROS.LT3214_HORA_MOVIMENTO, LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO);

            /*" -563- PERFORM R0900_00_DECLARE_PREMIOS_DB_DECLARE_1 */

            R0900_00_DECLARE_PREMIOS_DB_DECLARE_1();

            /*" -566- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -567- DISPLAY 'R0900-ERRO CONSULTAR LT_PREMIO' */
                _.Display($"R0900-ERRO CONSULTAR LT_PREMIO");

                /*" -568- DISPLAY 'COD-CLIENTE : ' LTMVPROP-COD-EXT-SEGURADO */
                _.Display($"COD-CLIENTE : {LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}");

                /*" -569- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -571- END-IF */
            }


            /*" -571- PERFORM R0900_00_DECLARE_PREMIOS_DB_OPEN_1 */

            R0900_00_DECLARE_PREMIOS_DB_OPEN_1();

            /*" -574- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -575- DISPLAY 'R0900 - ERRO OPEN CURSOR CPREMIO..' */
                _.Display($"R0900 - ERRO OPEN CURSOR CPREMIO..");

                /*" -576- DISPLAY 'COD-LOT:' LTMVPROP-COD-EXT-SEGURADO */
                _.Display($"COD-LOT:{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}");

                /*" -577- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -579- END-IF */
            }


            /*" -581- DISPLAY 'R0900-VOU PARA O FETCH WFIM:' WFIM-PREMIO */
            _.Display($"R0900-VOU PARA O FETCH WFIM:{WS_AREA_TRABALHO.WFIM_PREMIO}");

            /*" -583- PERFORM R0950-FETCH-PREMIOS */

            R0950_FETCH_PREMIOS_SECTION();

            /*" -584- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -585- DISPLAY 'R0900-ERRO FETCH LT_PREMIO' */
                _.Display($"R0900-ERRO FETCH LT_PREMIO");

                /*" -586- DISPLAY 'COD-LOT:' LTMVPROP-COD-EXT-SEGURADO */
                _.Display($"COD-LOT:{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}");

                /*" -587- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -588- END-IF */
            }


            /*" -588- . */

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PREMIOS-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PREMIOS_DB_DECLARE_1()
        {
            /*" -563- EXEC SQL DECLARE CPREMIO CURSOR FOR SELECT B.NUM_PROPOSTA_SIM , B.IND_TIPO_VIGENCIA , B.DTA_INI_VIGENCIA , B.DTA_FIM_VIGENCIA , B.IND_FORMA_COBRANCA_SEG , B.IND_FORMA_PGTO_PRIM_PARC , B.IND_FORMA_PGTO_DEM_PARC , B.VLR_PRIM_PARCELA , B.VLR_DEMAIS_PARCELAS , B.DTA_VENC_PRIM_PARCELA , B.DIA_VENC_DEMAIS_PARCELAS , B.QTD_PARCELA , B.VLR_IOF_PRIM_PARCELA , B.VLR_IOF_DEMAIS_PARCELAS , B.VLR_DESCONTO_FIDELIDADE , B.VLR_DESCONTO_COB_ADIC , B.VLR_DESCONTO_RENOVACAO , B.VLR_DESCONTO_EXPERIENCIA , B.VLR_DESCONTO_COFRE_INT , B.VLR_DESCONTO_BLINDAGEM , B.VLR_DESCONTO_PLURIANUAL , B.VLR_PREMIO_TARIFARIO , B.VLR_DESCONTO_TOTAL , VALUE(B.VLR_PREMIO_LIQUIDO,0) , VALUE(B.VLR_ADICIONAL_FRACIONA,0) , VALUE(B.VLR_CUSTO_EMISSAO,0) , VALUE(B.VLR_IOF,0) , VALUE(B.VLR_PREMIO_TOTAL,0) , VALUE(B.QTD_DIAS_VIGENCIA,0) , VALUE(B.VLR_PREMIO_LIQ_PRIM_PARC,0) , VALUE(B.VLR_ADICIONAL_PRIM_PARC,0) , VALUE(B.VLR_PREMIO_LIQ_DEM_PARC,0) , VALUE(B.VLR_ADICIONAL_DEM_PARC,0) FROM SEGUROS.LT_MOV_PROPOSTA A ,SEGUROS.LT_PREMIO B WHERE A.COD_EXT_SEGURADO = :LTMVPROP-COD-EXT-SEGURADO AND A.SEQ_PROPOSTA = :LTMVPROP-SEQ-PROPOSTA AND A.DATA_MOVIMENTO = :LTMVPROP-DATA-MOVIMENTO AND A.HORA_MOVIMENTO = :LTMVPROP-HORA-MOVIMENTO AND A.NUM_PROPOSTA_SIM = :LTMVPROP-NUM-PROPOSTA-SIM AND A.NUM_PROPOSTA_SIM = B.NUM_PROPOSTA_SIM ORDER BY B.IND_TIPO_VIGENCIA WITH UR END-EXEC */
            CPREMIO = new LT3214S_CPREMIO(true);
            string GetQuery_CPREMIO()
            {
                var query = @$"SELECT 
							B.NUM_PROPOSTA_SIM 
							, B.IND_TIPO_VIGENCIA 
							, B.DTA_INI_VIGENCIA 
							, B.DTA_FIM_VIGENCIA 
							, B.IND_FORMA_COBRANCA_SEG 
							, B.IND_FORMA_PGTO_PRIM_PARC 
							, B.IND_FORMA_PGTO_DEM_PARC 
							, B.VLR_PRIM_PARCELA 
							, B.VLR_DEMAIS_PARCELAS 
							, B.DTA_VENC_PRIM_PARCELA 
							, B.DIA_VENC_DEMAIS_PARCELAS 
							, B.QTD_PARCELA 
							, B.VLR_IOF_PRIM_PARCELA 
							, B.VLR_IOF_DEMAIS_PARCELAS 
							, B.VLR_DESCONTO_FIDELIDADE 
							, B.VLR_DESCONTO_COB_ADIC 
							, B.VLR_DESCONTO_RENOVACAO 
							, B.VLR_DESCONTO_EXPERIENCIA 
							, B.VLR_DESCONTO_COFRE_INT 
							, B.VLR_DESCONTO_BLINDAGEM 
							, B.VLR_DESCONTO_PLURIANUAL 
							, B.VLR_PREMIO_TARIFARIO 
							, B.VLR_DESCONTO_TOTAL 
							, VALUE(B.VLR_PREMIO_LIQUIDO
							,0) 
							, VALUE(B.VLR_ADICIONAL_FRACIONA
							,0) 
							, VALUE(B.VLR_CUSTO_EMISSAO
							,0) 
							, VALUE(B.VLR_IOF
							,0) 
							, VALUE(B.VLR_PREMIO_TOTAL
							,0) 
							, VALUE(B.QTD_DIAS_VIGENCIA
							,0) 
							, VALUE(B.VLR_PREMIO_LIQ_PRIM_PARC
							,0) 
							, VALUE(B.VLR_ADICIONAL_PRIM_PARC
							,0) 
							, VALUE(B.VLR_PREMIO_LIQ_DEM_PARC
							,0) 
							, VALUE(B.VLR_ADICIONAL_DEM_PARC
							,0) 
							FROM SEGUROS.LT_MOV_PROPOSTA A 
							,SEGUROS.LT_PREMIO B 
							WHERE A.COD_EXT_SEGURADO = '{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}' 
							AND A.SEQ_PROPOSTA = '{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_SEQ_PROPOSTA}' 
							AND A.DATA_MOVIMENTO = '{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO}' 
							AND A.HORA_MOVIMENTO = '{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO}' 
							AND A.NUM_PROPOSTA_SIM = '{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_NUM_PROPOSTA_SIM}' 
							AND A.NUM_PROPOSTA_SIM = B.NUM_PROPOSTA_SIM 
							ORDER BY B.IND_TIPO_VIGENCIA";

                return query;
            }
            CPREMIO.GetQueryEvent += GetQuery_CPREMIO;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PREMIOS-DB-OPEN-1 */
        public void R0900_00_DECLARE_PREMIOS_DB_OPEN_1()
        {
            /*" -571- EXEC SQL OPEN CPREMIO END-EXEC */

            CPREMIO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0950-FETCH-PREMIOS-SECTION */
        private void R0950_FETCH_PREMIOS_SECTION()
        {
            /*" -596- MOVE '0950' TO WNR-EXEC-SQL. */
            _.Move("0950", WS_AREA_TRABALHO.WABEND.WNR_EXEC_SQL);

            /*" -599- DISPLAY 'R0950-INICIO COD-LOT:' LTMVPROP-COD-EXT-SEGURADO 'WFIM:' WFIM-PREMIO */

            $"R0950-INICIO COD-LOT:{LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_COD_EXT_SEGURADO}WFIM:{WS_AREA_TRABALHO.WFIM_PREMIO}"
            .Display();

            /*" -634- PERFORM R0950_FETCH_PREMIOS_DB_FETCH_1 */

            R0950_FETCH_PREMIOS_DB_FETCH_1();

            /*" -637- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -638- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -638- PERFORM R0950_FETCH_PREMIOS_DB_CLOSE_1 */

                    R0950_FETCH_PREMIOS_DB_CLOSE_1();

                    /*" -640- MOVE 'S' TO WFIM-PREMIO */
                    _.Move("S", WS_AREA_TRABALHO.WFIM_PREMIO);

                    /*" -641- DISPLAY 'R0950-FIM NORMAL' */
                    _.Display($"R0950-FIM NORMAL");

                    /*" -642- GO TO R0950-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/ //GOTO
                    return;

                    /*" -643- ELSE */
                }
                else
                {


                    /*" -644- DISPLAY 'ERRO FETCH LT_PREMIO' */
                    _.Display($"ERRO FETCH LT_PREMIO");

                    /*" -645- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -646- END-IF */
                }


                /*" -647- END-IF */
            }


            /*" -647- . */

        }

        [StopWatch]
        /*" R0950-FETCH-PREMIOS-DB-FETCH-1 */
        public void R0950_FETCH_PREMIOS_DB_FETCH_1()
        {
            /*" -634- EXEC SQL FETCH CPREMIO INTO :LT028-NUM-PROPOSTA-SIM ,:LT028-IND-TIPO-VIGENCIA ,:LT028-DTA-INI-VIGENCIA ,:LT028-DTA-FIM-VIGENCIA ,:LT028-IND-FORMA-COBRANCA-SEG ,:LT028-IND-FORMA-PGTO-PRIM-PARC ,:LT028-IND-FORMA-PGTO-DEM-PARC ,:LT028-VLR-PRIM-PARCELA ,:LT028-VLR-DEMAIS-PARCELAS ,:LT028-DTA-VENC-PRIM-PARCELA ,:LT028-DIA-VENC-DEMAIS-PARCELAS ,:LT028-QTD-PARCELA ,:LT028-VLR-IOF-PRIM-PARCELA ,:LT028-VLR-IOF-DEMAIS-PARCELAS ,:LT028-VLR-DESCONTO-FIDELIDADE ,:LT028-VLR-DESCONTO-COB-ADIC ,:LT028-VLR-DESCONTO-RENOVACAO ,:LT028-VLR-DESCONTO-EXPERIENCIA ,:LT028-VLR-DESCONTO-COFRE-INT ,:LT028-VLR-DESCONTO-BLINDAGEM ,:LT028-VLR-DESCONTO-PLURIANUAL ,:LT028-VLR-PREMIO-TARIFARIO ,:LT028-VLR-DESCONTO-TOTAL ,:LT028-VLR-PREMIO-LIQUIDO ,:LT028-VLR-ADICIONAL-FRACIONA ,:LT028-VLR-CUSTO-EMISSAO ,:LT028-VLR-IOF ,:LT028-VLR-PREMIO-TOTAL ,:LT028-QTD-DIAS-VIGENCIA ,:LT028-VLR-PREMIO-LIQ-PRIM-PARC ,:LT028-VLR-ADICIONAL-PRIM-PARC ,:LT028-VLR-PREMIO-LIQ-DEM-PARC ,:LT028-VLR-ADICIONAL-DEM-PARC END-EXEC. */

            if (CPREMIO.Fetch())
            {
                _.Move(CPREMIO.LT028_NUM_PROPOSTA_SIM, LT028.DCLLT_PREMIO.LT028_NUM_PROPOSTA_SIM);
                _.Move(CPREMIO.LT028_IND_TIPO_VIGENCIA, LT028.DCLLT_PREMIO.LT028_IND_TIPO_VIGENCIA);
                _.Move(CPREMIO.LT028_DTA_INI_VIGENCIA, LT028.DCLLT_PREMIO.LT028_DTA_INI_VIGENCIA);
                _.Move(CPREMIO.LT028_DTA_FIM_VIGENCIA, LT028.DCLLT_PREMIO.LT028_DTA_FIM_VIGENCIA);
                _.Move(CPREMIO.LT028_IND_FORMA_COBRANCA_SEG, LT028.DCLLT_PREMIO.LT028_IND_FORMA_COBRANCA_SEG);
                _.Move(CPREMIO.LT028_IND_FORMA_PGTO_PRIM_PARC, LT028.DCLLT_PREMIO.LT028_IND_FORMA_PGTO_PRIM_PARC);
                _.Move(CPREMIO.LT028_IND_FORMA_PGTO_DEM_PARC, LT028.DCLLT_PREMIO.LT028_IND_FORMA_PGTO_DEM_PARC);
                _.Move(CPREMIO.LT028_VLR_PRIM_PARCELA, LT028.DCLLT_PREMIO.LT028_VLR_PRIM_PARCELA);
                _.Move(CPREMIO.LT028_VLR_DEMAIS_PARCELAS, LT028.DCLLT_PREMIO.LT028_VLR_DEMAIS_PARCELAS);
                _.Move(CPREMIO.LT028_DTA_VENC_PRIM_PARCELA, LT028.DCLLT_PREMIO.LT028_DTA_VENC_PRIM_PARCELA);
                _.Move(CPREMIO.LT028_DIA_VENC_DEMAIS_PARCELAS, LT028.DCLLT_PREMIO.LT028_DIA_VENC_DEMAIS_PARCELAS);
                _.Move(CPREMIO.LT028_QTD_PARCELA, LT028.DCLLT_PREMIO.LT028_QTD_PARCELA);
                _.Move(CPREMIO.LT028_VLR_IOF_PRIM_PARCELA, LT028.DCLLT_PREMIO.LT028_VLR_IOF_PRIM_PARCELA);
                _.Move(CPREMIO.LT028_VLR_IOF_DEMAIS_PARCELAS, LT028.DCLLT_PREMIO.LT028_VLR_IOF_DEMAIS_PARCELAS);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_FIDELIDADE, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_FIDELIDADE);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_COB_ADIC, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_COB_ADIC);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_RENOVACAO, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_RENOVACAO);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_EXPERIENCIA, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_EXPERIENCIA);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_COFRE_INT, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_COFRE_INT);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_BLINDAGEM, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_BLINDAGEM);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_PLURIANUAL, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_PLURIANUAL);
                _.Move(CPREMIO.LT028_VLR_PREMIO_TARIFARIO, LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_TARIFARIO);
                _.Move(CPREMIO.LT028_VLR_DESCONTO_TOTAL, LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_TOTAL);
                _.Move(CPREMIO.LT028_VLR_PREMIO_LIQUIDO, LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQUIDO);
                _.Move(CPREMIO.LT028_VLR_ADICIONAL_FRACIONA, LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_FRACIONA);
                _.Move(CPREMIO.LT028_VLR_CUSTO_EMISSAO, LT028.DCLLT_PREMIO.LT028_VLR_CUSTO_EMISSAO);
                _.Move(CPREMIO.LT028_VLR_IOF, LT028.DCLLT_PREMIO.LT028_VLR_IOF);
                _.Move(CPREMIO.LT028_VLR_PREMIO_TOTAL, LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_TOTAL);
                _.Move(CPREMIO.LT028_QTD_DIAS_VIGENCIA, LT028.DCLLT_PREMIO.LT028_QTD_DIAS_VIGENCIA);
                _.Move(CPREMIO.LT028_VLR_PREMIO_LIQ_PRIM_PARC, LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_PRIM_PARC);
                _.Move(CPREMIO.LT028_VLR_ADICIONAL_PRIM_PARC, LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_PRIM_PARC);
                _.Move(CPREMIO.LT028_VLR_PREMIO_LIQ_DEM_PARC, LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_DEM_PARC);
                _.Move(CPREMIO.LT028_VLR_ADICIONAL_DEM_PARC, LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_DEM_PARC);
            }

        }

        [StopWatch]
        /*" R0950-FETCH-PREMIOS-DB-CLOSE-1 */
        public void R0950_FETCH_PREMIOS_DB_CLOSE_1()
        {
            /*" -638- EXEC SQL CLOSE CPREMIO END-EXEC */

            CPREMIO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSAR-REGISTRO-SECTION */
        private void R1000_00_PROCESSAR_REGISTRO_SECTION()
        {
            /*" -659- DISPLAY 'LT3214-R1000-PROCESSANDO' ' LOT:' LT3214-COD-LOTERICO ' PRO:' LT3214-NUM-PROPOSTA-SIM ' VIG:' LT3214-IND-TIPO-VIGENCIA */

            $"LT3214-R1000-PROCESSANDO LOT:{LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_LOTERICO} PRO:{LBLT3214.LT3214_AREA_PARAMETROS.LT3214_NUM_PROPOSTA_SIM} VIG:{LBLT3214.LT3214_AREA_PARAMETROS.LT3214_IND_TIPO_VIGENCIA}"
            .Display();

            /*" -661- PERFORM R1200-00-MONTAR-REGISTRO */

            R1200_00_MONTAR_REGISTRO_SECTION();

            /*" -662- PERFORM R0950-FETCH-PREMIOS */

            R0950_FETCH_PREMIOS_SECTION();

            /*" -662- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-MONTAR-REGISTRO-SECTION */
        private void R1200_00_MONTAR_REGISTRO_SECTION()
        {
            /*" -672- MOVE LT028-IND-TIPO-VIGENCIA TO WS1 */
            _.Move(LT028.DCLLT_PREMIO.LT028_IND_TIPO_VIGENCIA, WS_AREA_TRABALHO.WS1);

            /*" -675- MOVE LT028-NUM-PROPOSTA-SIM TO LT3214-NUM-PROP-SIM(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_NUM_PROPOSTA_SIM, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_NUM_PROP_SIM);

            /*" -678- MOVE LT028-IND-TIPO-VIGENCIA TO LT3214-IND-TIPO-VIG(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_IND_TIPO_VIGENCIA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_IND_TIPO_VIG);

            /*" -681- MOVE LT028-DTA-INI-VIGENCIA TO LT3214-DTA-INI-VIGENCIA(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_DTA_INI_VIGENCIA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DTA_INI_VIGENCIA);

            /*" -684- MOVE LT028-DTA-FIM-VIGENCIA TO LT3214-DTA-FIM-VIGENCIA(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_DTA_FIM_VIGENCIA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DTA_FIM_VIGENCIA);

            /*" -687- MOVE LT028-IND-FORMA-COBRANCA-SEG TO LT3214-IND-FCOB-SEG(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_IND_FORMA_COBRANCA_SEG, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_IND_FCOB_SEG);

            /*" -690- MOVE LT028-IND-FORMA-PGTO-PRIM-PARC TO LT3214-IND-FPG-PRIM-PCL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_IND_FORMA_PGTO_PRIM_PARC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_IND_FPG_PRIM_PCL);

            /*" -693- MOVE LT028-IND-FORMA-PGTO-DEM-PARC TO LT3214-IND-FPG-DEM-PCL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_IND_FORMA_PGTO_DEM_PARC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_IND_FPG_DEM_PCL);

            /*" -696- MOVE LT028-DTA-VENC-PRIM-PARCELA TO LT3214-DTA-VENC-PRIM-PCL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_DTA_VENC_PRIM_PARCELA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DTA_VENC_PRIM_PCL);

            /*" -699- MOVE LT028-DIA-VENC-DEMAIS-PARCELAS TO LT3214-DIA-VENC-DEM-PCL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_DIA_VENC_DEMAIS_PARCELAS, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DIA_VENC_DEM_PCL);

            /*" -704- MOVE LT028-QTD-PARCELA TO LT3214-QTD-PARCELAS(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_QTD_PARCELA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_QTD_PARCELAS);

            /*" -705- IF LT028-VLR-PREMIO-LIQ-PRIM-PARC = 0 */

            if (LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_PRIM_PARC == 0)
            {

                /*" -707- COMPUTE LT028-VLR-PREMIO-LIQ-PRIM-PARC = LT028-VLR-PRIM-PARCELA - LT028-VLR-IOF-PRIM-PARCELA */
                LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_PRIM_PARC.Value = LT028.DCLLT_PREMIO.LT028_VLR_PRIM_PARCELA - LT028.DCLLT_PREMIO.LT028_VLR_IOF_PRIM_PARCELA;

                /*" -708- MOVE 0 TO LT028-VLR-ADICIONAL-PRIM-PARC */
                _.Move(0, LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_PRIM_PARC);

                /*" -710- END-IF */
            }


            /*" -711- IF LT028-VLR-PREMIO-LIQ-DEM-PARC = 0 */

            if (LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_DEM_PARC == 0)
            {

                /*" -713- COMPUTE LT028-VLR-PREMIO-LIQ-DEM-PARC = LT028-VLR-DEMAIS-PARCELAS - LT028-VLR-IOF-DEMAIS-PARCELAS */
                LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_DEM_PARC.Value = LT028.DCLLT_PREMIO.LT028_VLR_DEMAIS_PARCELAS - LT028.DCLLT_PREMIO.LT028_VLR_IOF_DEMAIS_PARCELAS;

                /*" -714- MOVE 0 TO LT028-VLR-ADICIONAL-DEM-PARC */
                _.Move(0, LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_DEM_PARC);

                /*" -718- END-IF */
            }


            /*" -721- MOVE LT028-VLR-PRIM-PARCELA TO LT3214-VL-PREMIO-PCL1(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_PRIM_PARCELA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_PREMIO_PCL1);

            /*" -724- MOVE LT028-VLR-PREMIO-LIQ-PRIM-PARC TO LT3214-VL-PREMIO-LIQ-PCL1(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_PRIM_PARC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_PREMIO_LIQ_PCL1);

            /*" -727- MOVE LT028-VLR-IOF-PRIM-PARCELA TO LT3214-VL-IOF-PCL1(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_IOF_PRIM_PARCELA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_IOF_PCL1);

            /*" -731- MOVE LT028-VLR-ADICIONAL-PRIM-PARC TO LT3214-VL-ADICIONAL-PCL1(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_PRIM_PARC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_ADICIONAL_PCL1);

            /*" -734- MOVE LT028-VLR-DEMAIS-PARCELAS TO LT3214-VL-PREMIO-PCLN(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DEMAIS_PARCELAS, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_PREMIO_PCLN);

            /*" -737- MOVE LT028-VLR-PREMIO-LIQ-DEM-PARC TO LT3214-VL-PREMIO-LIQ-PCLN(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQ_DEM_PARC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_PREMIO_LIQ_PCLN);

            /*" -740- MOVE LT028-VLR-IOF-DEMAIS-PARCELAS TO LT3214-VL-IOF-PCLN(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_IOF_DEMAIS_PARCELAS, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_IOF_PCLN);

            /*" -744- MOVE LT028-VLR-ADICIONAL-DEM-PARC TO LT3214-VL-ADICIONAL-PCLN(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_DEM_PARC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_ADICIONAL_PCLN);

            /*" -747- MOVE LT028-VLR-DESCONTO-FIDELIDADE TO LT3214-DESC-FIDEL (WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_FIDELIDADE, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DESC_FIDEL);

            /*" -750- MOVE LT028-VLR-DESCONTO-COB-ADIC TO LT3214-DESC-AGRUP(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_COB_ADIC, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DESC_AGRUP);

            /*" -753- MOVE LT028-VLR-DESCONTO-RENOVACAO TO LT3214-DESC-FIDEL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_RENOVACAO, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DESC_FIDEL);

            /*" -756- MOVE LT028-VLR-DESCONTO-EXPERIENCIA TO LT3214-DESC-EXP(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_EXPERIENCIA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DESC_EXP);

            /*" -759- MOVE LT028-VLR-DESCONTO-COFRE-INT TO LT3214-DESC-COFRE(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_COFRE_INT, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DESC_COFRE);

            /*" -763- MOVE LT028-VLR-DESCONTO-BLINDAGEM TO LT3214-DESC-BLINDAGEM(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_BLINDAGEM, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_DESC_BLINDAGEM);

            /*" -766- MOVE LT028-VLR-PREMIO-TARIFARIO TO LT3214-VL-SUBTOTAL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_TARIFARIO, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_SUBTOTAL);

            /*" -769- MOVE LT028-VLR-DESCONTO-TOTAL TO LT3214-VL-DESCONTO(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_DESCONTO_TOTAL, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_DESCONTO);

            /*" -772- MOVE LT028-VLR-PREMIO-LIQUIDO TO LT3214-VL-PREMIO-LIQ(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_LIQUIDO, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_PREMIO_LIQ);

            /*" -775- MOVE LT028-VLR-ADICIONAL-FRACIONA TO LT3214-VL-ADICIONAL (WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_ADICIONAL_FRACIONA, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_ADICIONAL);

            /*" -778- MOVE LT028-VLR-CUSTO-EMISSAO TO LT3214-VL-CUSTO-EMISSAO(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_CUSTO_EMISSAO, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_CUSTO_EMISSAO);

            /*" -780- MOVE LT028-VLR-IOF TO LT3214-VL-IOF(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_IOF, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_IOF);

            /*" -783- MOVE LT028-VLR-PREMIO-TOTAL TO LT3214-VL-PREMIO-TOTAL(WS1) */
            _.Move(LT028.DCLLT_PREMIO.LT028_VLR_PREMIO_TOTAL, LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1].LT3214_VL_PREMIO_TOTAL);

            /*" -784- IF WS-DISPLAY = 'S' */

            if (WS_AREA_TRABALHO.WS_DISPLAY == "S")
            {

                /*" -785- DISPLAY '   ' */
                _.Display($"   ");

                /*" -789- DISPLAY 'LT3214-PREMIO RETORNO LOT:' LT3214-COD-LOTERICO ' VIGENCIA:' WS1 */

                $"LT3214-PREMIO RETORNO LOT:{LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_LOTERICO} VIGENCIA:{WS_AREA_TRABALHO.WS1}"
                .Display();

                /*" -790- DISPLAY ' ---- PARCELA 1 ----------------------' */
                _.Display($" ---- PARCELA 1 ----------------------");

                /*" -794- DISPLAY ' PCL1:' LT3214-VL-PREMIO-PCL1(WS1) ' PLIQ1:' LT3214-VL-PREMIO-LIQ-PCL1(WS1) ' IOF1:' LT3214-VL-IOF-PCL1(WS1) ' ADIC1:' LT3214-VL-ADICIONAL-PCL1(WS1) */

                $" PCL1:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} PLIQ1:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} IOF1:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} ADIC1:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]}"
                .Display();

                /*" -795- DISPLAY ' ---- PARCELA N ----------------------' */
                _.Display($" ---- PARCELA N ----------------------");

                /*" -799- DISPLAY ' PCLN:' LT3214-VL-PREMIO-PCLN(WS1) ' PLIQN:' LT3214-VL-PREMIO-LIQ-PCLN(WS1) ' IOFN:' LT3214-VL-IOF-PCLN(WS1) ' ADICN:' LT3214-VL-ADICIONAL-PCLN(WS1) */

                $" PCLN:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} PLIQN:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} IOFN:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} ADICN:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]}"
                .Display();

                /*" -800- DISPLAY ' ----  VALOR TOTAL --------------------' */
                _.Display($" ----  VALOR TOTAL --------------------");

                /*" -807- DISPLAY ' PTARIF:' LT3214-VL-SUBTOTAL(WS1) ' DESC:' LT3214-VL-DESCONTO(WS1) ' PLIQ:' LT3214-VL-PREMIO-LIQ(WS1) ' ADIC:' LT3214-VL-ADICIONAL (WS1) ' CUSEM:' LT3214-VL-CUSTO-EMISSAO(WS1) ' IOF:' LT3214-VL-IOF(WS1) ' PRMT:' LT3214-VL-PREMIO-TOTAL(WS1) */

                $" PTARIF:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} DESC:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} PLIQ:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} ADIC:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} CUSEM:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} IOF:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]} PRMT:{LBLT3214.LT3214_AREA_PARAMETROS.TABELA_VALORES_RETORNO.TABELA_VALORES_RET[WS_AREA_TRABALHO.WS1]}"
                .Display();

                /*" -808- END-IF */
            }


            /*" -808- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-ROT-RETORNO-SECTION */
        private void R9000_00_ROT_RETORNO_SECTION()
        {
            /*" -817- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_AREA_TRABALHO.WABEND.WSQLCODE);

            /*" -818- IF LT3214-COD-RETORNO GREATER ZEROS */

            if (LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO > 00)
            {

                /*" -822- DISPLAY 'LT3214S-R9000-ERRO:' ' COD-ERRO=' LT3214-COD-RETORNO ' MSG-ERRO=' LT3214-MSG-RETORNO ' SQLCODE =' WSQLCODE */

                $"LT3214S-R9000-ERRO: COD-ERRO={LBLT3214.LT3214_AREA_PARAMETROS.LT3214_COD_RETORNO} MSG-ERRO={LBLT3214.LT3214_AREA_PARAMETROS.LT3214_MSG_RETORNO} SQLCODE ={WS_AREA_TRABALHO.WABEND.WSQLCODE}"
                .Display();

                /*" -824- END-IF */
            }


            /*" -824- GOBACK . */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -834- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_AREA_TRABALHO.WABEND.WSQLCODE);

            /*" -837- DISPLAY WABEND */
            _.Display(WS_AREA_TRABALHO.WABEND);

            /*" -837- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -839- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -843- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -843- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}