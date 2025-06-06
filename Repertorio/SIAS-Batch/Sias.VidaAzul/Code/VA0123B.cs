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
using Sias.VidaAzul.DB2.VA0123B;

namespace Code
{
    public class VA0123B
    {
        public bool IsCall { get; set; }

        public VA0123B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SIAS                                *      */
        /*"      *   PROGRAMA ............... VA0123B                             *      */
        /*"      *   SOLICITACAO ............ CADMUS - 34.386                     *      */
        /*"      *   PROGRAMADOR ............ EDIVALDO GOMES                      *      */
        /*"      *   DATA CODIFICACAO ....... JANEIRO 2010                        *      */
        /*"      *   FUNCAO ................. MIGRAR PLANO PARA PRODUTOS DE       *      */
        /*"      *                            PAGAMENTO ANTECIPADO P. FISICA.     *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                       ALTERACOES                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 28 - D 575149 T 584822                                *      */
        /*"      *             - ACERTAR INSERT'S NA HIS_COBER_PROPOST  E         *      */
        /*"      *             V0COBERPROPVA                                      *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/04/2024 - HUSNI ALI HUSNI                              *      */
        /*"      *                                            PROCURE POR V.28    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 27 - 523901 - AJUSTES -803 NO INSERT DA TABELA      *        */
        /*"      *                        COBER_HIST_VIDAZUL                      *      */
        /*"      *                                                                *      */
        /*"      *   BRICE HO - DATA: 27/08/2023  PROCURE: V.27                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.26  *   VERSAO 26 - 470252 - CORRECAO EMERGENCIAL S/DEMANDA          *      */
        /*"V.26  *               CORRECAO MIGRACAO COM MATRIZ                     *      */
        /*"      *                                                                *      */
        /*"      *   CANETTA - DATA: 03/03/2023  PROCURE: V.26                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.25  *   VERSAO 25 - 459700 - CAMPANHA DE DESCONTO BLACK FRIDAY       *      */
        /*"      *                       (CALCULO DE PREMIO COM DESCONTO (MATRIZ) *      */
        /*"      *                                                                *      */
        /*"      *   CANETTA - DATA: 08/11/2022  PROCURE: V.25                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.24  *   VERSAO 24 - 434866 - CONTRATOS RENOVADOS SUBGRUPO INCORRETO  *      */
        /*"      *                                                                *      */
        /*"      *   CANETTA - DATA: 13/10/2022  PROCURE: V.24                    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   DEMAIS HISTORICOS VIDE FINAL DO PROGRAMA                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  SISTEMAS-DATA-MOV-ABERTO-01    PIC   X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMAS-DATA-MOV-ABERTO-30    PIC   X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_30 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  SISTEMAS-DATA-MOV-ABERTO-40    PIC   X(010).*/
        public StringBasis SISTEMAS_DATA_MOV_ABERTO_40 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  HISCOBPR-DATA-INIVIG-1         PIC   X(010).*/
        public StringBasis HISCOBPR_DATA_INIVIG_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-DATA-MOV-ABERTO             PIC   X(010).*/
        public StringBasis WS_DATA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-DATA-MOV-ABERTO-1           PIC   X(010).*/
        public StringBasis WS_DATA_MOV_ABERTO_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WS-SUBSCRICAO-DINAMICA         PIC   X(001) VALUE 'N'.*/
        public StringBasis WS_SUBSCRICAO_DINAMICA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"01  PROPOVA-OCORR-HISTORICO1       PIC  S9(004) COMP VALUE +0.*/
        public IntBasis PROPOVA_OCORR_HISTORICO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  PARCEVID-NUM-PARCELA1          PIC  S9(004) COMP VALUE +0.*/
        public IntBasis PARCEVID_NUM_PARCELA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  SEGURVGA-OCORR-HISTORICO1      PIC  S9(004) COMP VALUE +0.*/
        public IntBasis SEGURVGA_OCORR_HISTORICO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-TEM-OPCPAGVI                PIC   X(001) VALUE SPACES.*/
        public StringBasis WS_TEM_OPCPAGVI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WS-TEM-SUBGVGAP                PIC   X(001) VALUE SPACES.*/
        public StringBasis WS_TEM_SUBGVGAP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01  WHOST-COUNT-COBER              PIC  S9(009) COMP VALUE +0.*/
        public IntBasis WHOST_COUNT_COBER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  WHOST-HORA-OPERACAO            PIC   X(008).*/
        public StringBasis WHOST_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01  WDT-NASC-NLL                   PIC  S9(004) COMP VALUE +0.*/
        public IntBasis WDT_NASC_NLL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WHOST-NRTITULO                 PIC  S9(013) COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRTITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  WHOST-COD-CONVENIO             PIC  S9(004) COMP VALUE +0.*/
        public IntBasis WHOST_COD_CONVENIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  WS-NUM-CERTIFICADO             PIC  S9(015) COMP-3 VALUE +0.*/
        public IntBasis WS_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01  WS-NUM-PARCELA                 PIC  S9(004) COMP VALUE +0.*/
        public IntBasis WS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-AGEDEB                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_AGEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-OPEDEB                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_OPEDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CTADEB                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_CTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DIGDEB                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DIGDEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NUMCAR                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_NUMCAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTENV                     PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DTENV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTRET                     PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DTRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CODRET                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NREQ                      PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_NREQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-SEQUEN                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_SEQUEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-NLOTE                     PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_NLOTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-DTCRED                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_DTCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-STATUS                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_STATUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLCRED                    PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_VLCRED { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-RET-SUBSCRICAO            PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_RET_SUBSCRICAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-PCT-AGRAVO                PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_PCT_AGRAVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-VLR-PRM-SEM-AGR           PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_VLR_PRM_SEM_AGR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  VIND-CCRE                      PIC  S9(004) COMP VALUE +0.*/
        public IntBasis VIND_CCRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  W-TITULO                       PIC  S9(013) VALUE +0 COMP-3.*/
        public IntBasis W_TITULO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01  W-NUMR-TITULO                  PIC   9(011)   VALUE ZEROS.*/
        public IntBasis W_NUMR_TITULO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"01  FILLER                         REDEFINES    W-NUMR-TITULO.*/
        private _REDEF_VA0123B_FILLER_0 _filler_0 { get; set; }
        public _REDEF_VA0123B_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_VA0123B_FILLER_0(); _.Move(W_NUMR_TITULO, _filler_0); VarBasis.RedefinePassValue(W_NUMR_TITULO, _filler_0, W_NUMR_TITULO); _filler_0.ValueChanged += () => { _.Move(_filler_0, W_NUMR_TITULO); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, W_NUMR_TITULO); }
        }  //Redefines
        public class _REDEF_VA0123B_FILLER_0 : VarBasis
        {
            /*"  05    WTITL-SEQUENCIA            PIC   9(010).*/
            public IntBasis WTITL_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05    WTITL-DIGITO               PIC   9(001).*/
            public IntBasis WTITL_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  W-PERC-FX-ETARIA               PIC  S9(003)V9999.*/

            public _REDEF_VA0123B_FILLER_0()
            {
                WTITL_SEQUENCIA.ValueChanged += OnValueChanged;
                WTITL_DIGITO.ValueChanged += OnValueChanged;
            }

        }
        public DoubleBasis W_PERC_FX_ETARIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999."), 4);
        /*"01  W-PERC-AGRAVO                  PIC  S9(003)V9999.*/
        public DoubleBasis W_PERC_AGRAVO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999."), 4);
        /*"01  WS-PER-DESC                    PIC  S9(003)V9999.*/
        public DoubleBasis WS_PER_DESC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999."), 4);
        /*"01  COBERP-VLPREMIO-ATU            PIC  S9(013)V99 COMP-3.*/
        public DoubleBasis COBERP_VLPREMIO_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  COBERP-PRMVG-ATU               PIC  S9(013)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMVG_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  COBERP-PRMAP-ATU               PIC  S9(013)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMAP_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  COBERP-PRMDIT-ATU              PIC  S9(013)V99 COMP-3.*/
        public DoubleBasis COBERP_PRMDIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-VLR-DESC                    PIC  S9(013)V99 COMP-3.*/
        public DoubleBasis WS_VLR_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WS-PER-EDT-001                 PIC  ---9,9999.*/
        public DoubleBasis WS_PER_EDT_001 { get; set; } = new DoubleBasis(new PIC("9", "4", "---9V9999."), 4);
        /*"01  WS-VLR-EDT-001                 PIC  -----9,99.*/
        public DoubleBasis WS_VLR_EDT_001 { get; set; } = new DoubleBasis(new PIC("9", "6", "-----9V99."), 2);
        /*"01  WS-VLR-EDT-002                 PIC  -----9,99.*/
        public DoubleBasis WS_VLR_EDT_002 { get; set; } = new DoubleBasis(new PIC("9", "6", "-----9V99."), 2);
        /*"01  WS-VLR-EDT-003                 PIC  -----9,99.*/
        public DoubleBasis WS_VLR_EDT_003 { get; set; } = new DoubleBasis(new PIC("9", "6", "-----9V99."), 2);
        /*"01  WS-VLR-EDT-004                 PIC  -----9,99.*/
        public DoubleBasis WS_VLR_EDT_004 { get; set; } = new DoubleBasis(new PIC("9", "6", "-----9V99."), 2);
        /*"01             DPARM01X.*/
        public VA0123B_DPARM01X DPARM01X { get; set; } = new VA0123B_DPARM01X();
        public class VA0123B_DPARM01X : VarBasis
        {
            /*"  05           DPARM01           PIC  9(010).*/
            public IntBasis DPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  05           DPARM01-R         REDEFINES   DPARM01.*/
            private _REDEF_VA0123B_DPARM01_R _dparm01_r { get; set; }
            public _REDEF_VA0123B_DPARM01_R DPARM01_R
            {
                get { _dparm01_r = new _REDEF_VA0123B_DPARM01_R(); _.Move(DPARM01, _dparm01_r); VarBasis.RedefinePassValue(DPARM01, _dparm01_r, DPARM01); _dparm01_r.ValueChanged += () => { _.Move(_dparm01_r, DPARM01); }; return _dparm01_r; }
                set { VarBasis.RedefinePassValue(value, _dparm01_r, DPARM01); }
            }  //Redefines
            public class _REDEF_VA0123B_DPARM01_R : VarBasis
            {
                /*"    10         DPARM01-1         PIC  9(001).*/
                public IntBasis DPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-2         PIC  9(001).*/
                public IntBasis DPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-3         PIC  9(001).*/
                public IntBasis DPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-4         PIC  9(001).*/
                public IntBasis DPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-5         PIC  9(001).*/
                public IntBasis DPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-6         PIC  9(001).*/
                public IntBasis DPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-7         PIC  9(001).*/
                public IntBasis DPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-8         PIC  9(001).*/
                public IntBasis DPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-9         PIC  9(001).*/
                public IntBasis DPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10         DPARM01-10        PIC  9(001).*/
                public IntBasis DPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05           DPARM01-D1        PIC  9(001).*/

                public _REDEF_VA0123B_DPARM01_R()
                {
                    DPARM01_1.ValueChanged += OnValueChanged;
                    DPARM01_2.ValueChanged += OnValueChanged;
                    DPARM01_3.ValueChanged += OnValueChanged;
                    DPARM01_4.ValueChanged += OnValueChanged;
                    DPARM01_5.ValueChanged += OnValueChanged;
                    DPARM01_6.ValueChanged += OnValueChanged;
                    DPARM01_7.ValueChanged += OnValueChanged;
                    DPARM01_8.ValueChanged += OnValueChanged;
                    DPARM01_9.ValueChanged += OnValueChanged;
                    DPARM01_10.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05           DPARM01-RC        PIC S9(004) COMP VALUE +0.*/
            public IntBasis DPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  AREA-DE-WORK.*/
        }
        public VA0123B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VA0123B_AREA_DE_WORK();
        public class VA0123B_AREA_DE_WORK : VarBasis
        {
            /*"    05  WTEM-PLAVAVGA              PIC   X(001)  VALUE SPACES.*/
            public StringBasis WTEM_PLAVAVGA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  WFIM-CURS01                PIC   X(003)  VALUE SPACES.*/
            public StringBasis WFIM_CURS01 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WFIM-CURS02                PIC   X(003)  VALUE SPACES.*/
            public StringBasis WFIM_CURS02 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  AC-LIDOS                   PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-PROC                    PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_PROC { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-CONTA                   PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-DESPR                   PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_DESPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-DESPR-SEGURVGA          PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_DESPR_SEGURVGA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-DESPR-SEGURHIS          PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_DESPR_SEGURHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-DESPR-OPCPAGVI          PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_DESPR_OPCPAGVI { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-DESPR-SUBGVGAP          PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_DESPR_SUBGVGAP { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  AC-DESPR-PLAVAVGA          PIC   9(007)  VALUE ZEROS.*/
            public IntBasis AC_DESPR_PLAVAVGA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05  WS-TIME                    PIC   X(008)  VALUE ZEROS.*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"    05  WS-CHAVE-ATU               VALUE SPACES.*/
            public VA0123B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VA0123B_WS_CHAVE_ATU();
            public class VA0123B_WS_CHAVE_ATU : VarBasis
            {
                /*"     10 WS-ATU-NUM-APOLICE         PIC   9(013).*/
                public IntBasis WS_ATU_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"     10 WS-ATU-COD-SUBGRUPO        PIC   9(005).*/
                public IntBasis WS_ATU_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05  WS-CHAVE-ANT               VALUE SPACES.*/
            }
            public VA0123B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VA0123B_WS_CHAVE_ANT();
            public class VA0123B_WS_CHAVE_ANT : VarBasis
            {
                /*"     10 WS-ANT-NUM-APOLICE         PIC   9(013).*/
                public IntBasis WS_ANT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"     10 WS-ANT-COD-SUBGRUPO        PIC   9(005).*/
                public IntBasis WS_ANT_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05  WS-DATA-NASCIMENTO         VALUE SPACES.*/
            }
            public VA0123B_WS_DATA_NASCIMENTO WS_DATA_NASCIMENTO { get; set; } = new VA0123B_WS_DATA_NASCIMENTO();
            public class VA0123B_WS_DATA_NASCIMENTO : VarBasis
            {
                /*"     10 WS-ANO-NASC                PIC   9(004).*/
                public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                     PIC   X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-MES-NASC                PIC   9(002).*/
                public IntBasis WS_MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                     PIC   X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-DIA-NASC                PIC   9(002).*/
                public IntBasis WS_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-DATA-SISTEMA            VALUE SPACES.*/
            }
            public VA0123B_WS_DATA_SISTEMA WS_DATA_SISTEMA { get; set; } = new VA0123B_WS_DATA_SISTEMA();
            public class VA0123B_WS_DATA_SISTEMA : VarBasis
            {
                /*"     10 WS-ANO-SIST                PIC   9(004).*/
                public IntBasis WS_ANO_SIST { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"     10 FILLER                     PIC   X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-MES-SIST                PIC   9(002).*/
                public IntBasis WS_MES_SIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                     PIC   X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-DIA-SIST                PIC   9(002).*/
                public IntBasis WS_DIA_SIST { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  WS-HORA-OPERACAO           VALUE SPACES.*/
            }
            public VA0123B_WS_HORA_OPERACAO WS_HORA_OPERACAO { get; set; } = new VA0123B_WS_HORA_OPERACAO();
            public class VA0123B_WS_HORA_OPERACAO : VarBasis
            {
                /*"     10 WS-HOR-OPER                PIC   9(002).*/
                public IntBasis WS_HOR_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                     PIC   X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-MIN-OPER                PIC   9(002).*/
                public IntBasis WS_MIN_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     10 FILLER                     PIC   X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"     10 WS-SEG-OPER                PIC   9(002).*/
                public IntBasis WS_SEG_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WABEND.*/
                public VA0123B_WABEND WABEND { get; set; } = new VA0123B_WABEND();
                public class VA0123B_WABEND : VarBasis
                {
                    /*"    10      FILLER              PIC  X(010)     VALUE           ' VA0123B'.*/
                }
            }
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0123B");
            /*"    10      FILLER              PIC  X(026)     VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"    10      WNR-EXEC-SQL        PIC  X(004)     VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"    10      FILLER              PIC  X(013)     VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"    10      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.SEGURHIS SEGURHIS { get; set; } = new Dclgens.SEGURHIS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.CONVEVG CONVEVG { get; set; } = new Dclgens.CONVEVG();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.BANCOS BANCOS { get; set; } = new Dclgens.BANCOS();
        public Dclgens.MOVDEBCE MOVDEBCE { get; set; } = new Dclgens.MOVDEBCE();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.PARCEVID PARCEVID { get; set; } = new Dclgens.PARCEVID();
        public Dclgens.GE406 GE406 { get; set; } = new Dclgens.GE406();
        public Dclgens.JVBKINCL JVBKINCL { get; set; } = new Dclgens.JVBKINCL();
        public Dclgens.VG130 VG130 { get; set; } = new Dclgens.VG130();

        public VA0123B_CURS01 CURS01 { get; set; } = new VA0123B_CURS01(true);
        string GetQuery_CURS01()
        {
            var query = @$"SELECT NUM_APOLICE
							, COD_SUBGRUPO
							, NUM_CERTIFICADO
							, COD_CLIENTE
							, OCORR_HISTORICO
							, DATA_QUITACAO
							, DTPROXVEN
							, NUM_PARCELA
							, OPCAO_COBERTURA
							FROM SEGUROS.PROPOSTAS_VA WHERE DTPROXVEN BETWEEN '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' AND '{SISTEMAS_DATA_MOV_ABERTO_40}' AND SIT_REGISTRO = '3' AND STA_ANTECIPACAO = 'S' AND STA_MUDANCA_PLANO IS NULL AND COD_PRODUTO NOT IN (9343
							, 8209
							,'{JVBKINCL.JV_PRODUTOS.JVPRD9343}'
							, '{JVBKINCL.JV_PRODUTOS.JVPRD8209}') ORDER BY NUM_APOLICE
							, COD_SUBGRUPO";

            return query;
        }


        public VA0123B_CURS02 CURS02 { get; set; } = new VA0123B_CURS02(true);
        string GetQuery_CURS02()
        {
            var query = @$"SELECT NUM_APOLICE
							, NUM_ENDOSSO
							, NUM_ITEM
							, RAMO_COBERTURA
							, COD_COBERTURA
							, MODALI_COBERTURA
							, OCORR_HISTORICO
							, IMP_SEGURADA_IX
							, PRM_TARIFARIO_IX
							, IMP_SEGURADA_VAR
							, PRM_TARIFARIO_VAR
							, PCT_COBERTURA
							, FATOR_MULTIPLICA
							FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = '{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}' AND NUM_ITEM = '{SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}' AND OCORR_HISTORICO = '{SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}'";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                InitializeGetQuery();

                /*" -312- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -313- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -314- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -319- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -320- DISPLAY ' VA0123B - MIGRA PLANO ANTECIPADO PARA MENSAL    ' */
                _.Display($" VA0123B - MIGRA PLANO ANTECIPADO PARA MENSAL    ");

                /*" -321- DISPLAY '                                                 ' */
                _.Display($"                                                 ");

                /*" -322- DISPLAY 'VERSAO 28 ' FUNCTION WHEN-COMPILED ' - 575149     ' */

                $"VERSAO 28 FUNCTION{_.WhenCompiled()} - 575149     "
                .Display();

                /*" -323- DISPLAY '                                                 ' */
                _.Display($"                                                 ");

                /*" -330- DISPLAY 'INICIOU PROCESSAMENTO EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

                $"INICIOU PROCESSAMENTO EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
                .Display();

                /*" -331- DISPLAY '                                                 ' */
                _.Display($"                                                 ");

                /*" -333- DISPLAY '-------------------------------------------------' . */
                _.Display($"-------------------------------------------------");

                /*" -335- PERFORM R0005-00-UPDATE-ESTOQUE. */

                R0005_00_UPDATE_ESTOQUE_SECTION();

                /*" -337- PERFORM R0010-00-PROCESSO-INICIO. */

                R0010_00_PROCESSO_INICIO_SECTION();

                /*" -340- PERFORM R1000-00-PROCESSA-CURS01 UNTIL WFIM-CURS01 EQUAL 'SIM' . */

                while (!(AREA_DE_WORK.WFIM_CURS01 == "SIM"))
                {

                    R1000_00_PROCESSA_CURS01_SECTION();
                }

                /*" -342- PERFORM R9000-00-FINALIZA. */

                R9000_00_FINALIZA_SECTION();

                /*" -342- GOBACK. */

                throw new GoBack();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        public void InitializeGetQuery()
        {
            CURS01.GetQueryEvent += GetQuery_CURS01;
            CURS02.GetQueryEvent += GetQuery_CURS02;
        }

        [StopWatch]
        /*" R0005-00-UPDATE-ESTOQUE-SECTION */
        private void R0005_00_UPDATE_ESTOQUE_SECTION()
        {
            /*" -352- MOVE '0005' TO WNR-EXEC-SQL. */
            _.Move("0005", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -353- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -354- DISPLAY ' ' */
            _.Display($" ");

            /*" -355- DISPLAY 'INICIANDO A ATUALIZACAO DA BASE PARA O MOVIMENTO' */
            _.Display($"INICIANDO A ATUALIZACAO DA BASE PARA O MOVIMENTO");

            /*" -356- DISPLAY 'ANTERIOR A PUBLICACAO DO VA0123B' */
            _.Display($"ANTERIOR A PUBLICACAO DO VA0123B");

            /*" -358- DISPLAY ' ' */
            _.Display($" ");

            /*" -382- PERFORM R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1 */

            R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1();

            /*" -385- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -387- DISPLAY 'ERRO NO UPDATE OPCAO_PAG_VIDAZUL PARA ESTOQUE - 01' */
                _.Display($"ERRO NO UPDATE OPCAO_PAG_VIDAZUL PARA ESTOQUE - 01");

                /*" -388- DISPLAY ' ' */
                _.Display($" ");

                /*" -389- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -392- END-IF. */
            }


            /*" -416- PERFORM R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2 */

            R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2();

            /*" -419- IF (SQLCODE NOT EQUAL 0) AND (SQLCODE NOT EQUAL 100) */

            if ((DB.SQLCODE != 0) && (DB.SQLCODE != 100))
            {

                /*" -421- DISPLAY 'ERRO NO UPDATE OPCAO_PAG_VIDAZUL PARA ESTOQUE - 02' */
                _.Display($"ERRO NO UPDATE OPCAO_PAG_VIDAZUL PARA ESTOQUE - 02");

                /*" -422- DISPLAY ' ' */
                _.Display($" ");

                /*" -423- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -423- END-IF. */
            }


        }

        [StopWatch]
        /*" R0005-00-UPDATE-ESTOQUE-DB-UPDATE-1 */
        public void R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1()
        {
            /*" -382- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL C SET OPCAO_PAGAMENTO = '1' WHERE C.OPCAO_PAGAMENTO = '3' AND C.DATA_TERVIGENCIA = '9999-12-31' AND C.OPE_CONTA_DEBITO = 1 AND (C.COD_AGENCIA_DEBITO IS NOT NULL OR C.COD_AGENCIA_DEBITO <> 0) AND (C. NUM_CONTA_DEBITO IS NOT NULL OR C. NUM_CONTA_DEBITO <> 0) AND (C.DIG_CONTA_DEBITO IS NOT NULL OR C.DIG_CONTA_DEBITO <> 0) AND C.NUM_CERTIFICADO IN (SELECT B.NUM_CERTIFICADO FROM SEGUROS.APOLICES A , SEGUROS.SEGURADOS_VGAP B WHERE A.NUM_APOLICE IN ( 0109300002005 , 0109300002008 , 109300002741 ) AND A.COD_PRODUTO = 9328 AND B.NUM_APOLICE = A.NUM_APOLICE ) END-EXEC. */

            var r0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1 = new R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1()
            {
            };

            R0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1.Execute(r0005_00_UPDATE_ESTOQUE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_99_SAIDA*/

        [StopWatch]
        /*" R0005-00-UPDATE-ESTOQUE-DB-UPDATE-2 */
        public void R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2()
        {
            /*" -416- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL C SET OPCAO_PAGAMENTO = '2' WHERE C.OPCAO_PAGAMENTO = '3' AND C.DATA_TERVIGENCIA = '9999-12-31' AND C.OPE_CONTA_DEBITO = 13 AND (C.COD_AGENCIA_DEBITO IS NOT NULL OR C.COD_AGENCIA_DEBITO <> 0) AND (C. NUM_CONTA_DEBITO IS NOT NULL OR C. NUM_CONTA_DEBITO <> 0) AND (C.DIG_CONTA_DEBITO IS NOT NULL OR C.DIG_CONTA_DEBITO <> 0) AND C.NUM_CERTIFICADO IN (SELECT B.NUM_CERTIFICADO FROM SEGUROS.APOLICES A , SEGUROS.SEGURADOS_VGAP B WHERE A.NUM_APOLICE IN ( 0109300002005 , 0109300002008 , 109300002741 ) AND A.COD_PRODUTO = 9328 AND B.NUM_APOLICE = A.NUM_APOLICE ) END-EXEC. */

            var r0005_00_UPDATE_ESTOQUE_DB_UPDATE_2_Update1 = new R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2_Update1()
            {
            };

            R0005_00_UPDATE_ESTOQUE_DB_UPDATE_2_Update1.Execute(r0005_00_UPDATE_ESTOQUE_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R0010-00-PROCESSO-INICIO-SECTION */
        private void R0010_00_PROCESSO_INICIO_SECTION()
        {
            /*" -433- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -435- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -437- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -439- PERFORM R0110-00-SELECT-RELATORI. */

            R0110_00_SELECT_RELATORI_SECTION();

            /*" -441- PERFORM R0300-00-OPEN-CURS01. */

            R0300_00_OPEN_CURS01_SECTION();

            /*" -441- PERFORM R0400-00-FETCH-CURS01. */

            R0400_00_FETCH_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -451- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -453- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -469- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -472- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -473- DISPLAY 'ERRO SELECT SISTEMAS (VA)' */
                _.Display($"ERRO SELECT SISTEMAS (VA)");

                /*" -474- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -476- END-IF. */
            }


            /*" -477- DISPLAY 'DTMOVABE    = ' WS-DATA-MOV-ABERTO */
            _.Display($"DTMOVABE    = {WS_DATA_MOV_ABERTO}");

            /*" -478- DISPLAY 'DTMOVABE-1  = ' WS-DATA-MOV-ABERTO-1 */
            _.Display($"DTMOVABE-1  = {WS_DATA_MOV_ABERTO_1}");

            /*" -479- DISPLAY 'DTMOVABE+30 = ' SISTEMAS-DATA-MOV-ABERTO-30 */
            _.Display($"DTMOVABE+30 = {SISTEMAS_DATA_MOV_ABERTO_30}");

            /*" -480- DISPLAY 'DTMOVABE+40 = ' SISTEMAS-DATA-MOV-ABERTO-40 */
            _.Display($"DTMOVABE+40 = {SISTEMAS_DATA_MOV_ABERTO_40}");

            /*" -481- DISPLAY ' ' . */
            _.Display($" ");

            /*" -482- MOVE WS-DATA-MOV-ABERTO TO SISTEMAS-DATA-MOV-ABERTO */
            _.Move(WS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

            /*" -484- MOVE WS-DATA-MOV-ABERTO-1 TO SISTEMAS-DATA-MOV-ABERTO-01 */
            _.Move(WS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_01);

            /*" -487- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-SISTEMA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_SISTEMA);

            /*" -490- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -491- MOVE WS-TIME(1:2) TO WS-HOR-OPER */
            _.Move(AREA_DE_WORK.WS_TIME.Substring(1, 2), AREA_DE_WORK.WS_HORA_OPERACAO.WS_HOR_OPER);

            /*" -492- MOVE WS-TIME(3:2) TO WS-MIN-OPER */
            _.Move(AREA_DE_WORK.WS_TIME.Substring(3, 2), AREA_DE_WORK.WS_HORA_OPERACAO.WS_MIN_OPER);

            /*" -493- MOVE WS-TIME(5:2) TO WS-SEG-OPER */
            _.Move(AREA_DE_WORK.WS_TIME.Substring(5, 2), AREA_DE_WORK.WS_HORA_OPERACAO.WS_SEG_OPER);

            /*" -494- MOVE WS-HORA-OPERACAO TO WHOST-HORA-OPERACAO. */
            _.Move(AREA_DE_WORK.WS_HORA_OPERACAO, WHOST_HORA_OPERACAO);

            /*" -496- MOVE ':' TO WHOST-HORA-OPERACAO(3:1) */
            _.MoveAtPosition(":", WHOST_HORA_OPERACAO, 3, 1);

            /*" -497- MOVE ':' TO WHOST-HORA-OPERACAO(6:1). */
            _.MoveAtPosition(":", WHOST_HORA_OPERACAO, 6, 1);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -469- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO - 01 DAYS, DATA_MOV_ABERTO + 30 DAYS, DATA_MOV_ABERTO + 40 DAYS INTO :WS-DATA-MOV-ABERTO, :WS-DATA-MOV-ABERTO-1, :SISTEMAS-DATA-MOV-ABERTO-30, :SISTEMAS-DATA-MOV-ABERTO-40 FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VA' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_MOV_ABERTO, WS_DATA_MOV_ABERTO);
                _.Move(executed_1.WS_DATA_MOV_ABERTO_1, WS_DATA_MOV_ABERTO_1);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_30, SISTEMAS_DATA_MOV_ABERTO_30);
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO_40, SISTEMAS_DATA_MOV_ABERTO_40);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-SELECT-RELATORI-SECTION */
        private void R0110_00_SELECT_RELATORI_SECTION()
        {
            /*" -507- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -509- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -517- PERFORM R0110_00_SELECT_RELATORI_DB_SELECT_1 */

            R0110_00_SELECT_RELATORI_DB_SELECT_1();

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY 'ERRO SELECT RELATORIOS   ' */
                _.Display($"ERRO SELECT RELATORIOS   ");

                /*" -522- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -524- END-IF. */
            }


            /*" -525- DISPLAY 'RELATORI-DATA-REFERENCIA = ' RELATORI-DATA-REFERENCIA. */
            _.Display($"RELATORI-DATA-REFERENCIA = {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}");

        }

        [StopWatch]
        /*" R0110-00-SELECT-RELATORI-DB-SELECT-1 */
        public void R0110_00_SELECT_RELATORI_DB_SELECT_1()
        {
            /*" -517- EXEC SQL SELECT DATA_REFERENCIA INTO :RELATORI-DATA-REFERENCIA FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VA0123B' WITH UR END-EXEC. */

            var r0110_00_SELECT_RELATORI_DB_SELECT_1_Query1 = new R0110_00_SELECT_RELATORI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0110_00_SELECT_RELATORI_DB_SELECT_1_Query1.Execute(r0110_00_SELECT_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-OPEN-CURS01-SECTION */
        private void R0300_00_OPEN_CURS01_SECTION()
        {
            /*" -535- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -537- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -537- PERFORM R0300_00_OPEN_CURS01_DB_OPEN_1 */

            R0300_00_OPEN_CURS01_DB_OPEN_1();

            /*" -540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -541- DISPLAY 'ERRO OPEN CURS01' */
                _.Display($"ERRO OPEN CURS01");

                /*" -542- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -542- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-OPEN-CURS01-DB-OPEN-1 */
        public void R0300_00_OPEN_CURS01_DB_OPEN_1()
        {
            /*" -537- EXEC SQL OPEN CURS01 END-EXEC. */

            CURS01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-SECTION */
        private void R0400_00_FETCH_CURS01_SECTION()
        {
            /*" -552- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -554- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -564- PERFORM R0400_00_FETCH_CURS01_DB_FETCH_1 */

            R0400_00_FETCH_CURS01_DB_FETCH_1();

            /*" -567- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -568- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -569- MOVE 'SIM' TO WFIM-CURS01 */
                    _.Move("SIM", AREA_DE_WORK.WFIM_CURS01);

                    /*" -569- PERFORM R0400_00_FETCH_CURS01_DB_CLOSE_1 */

                    R0400_00_FETCH_CURS01_DB_CLOSE_1();

                    /*" -571- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -572- ELSE */
                }
                else
                {


                    /*" -573- DISPLAY 'ERRO FETCH CURS01' */
                    _.Display($"ERRO FETCH CURS01");

                    /*" -574- DISPLAY 'NUM APOLICE......' PROPOVA-NUM-APOLICE */
                    _.Display($"NUM APOLICE......{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -575- DISPLAY 'COD SUBGRUPO.....' PROPOVA-COD-SUBGRUPO */
                    _.Display($"COD SUBGRUPO.....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}");

                    /*" -576- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -578- END-IF. */
                }

            }


            /*" -581- ADD 1 TO AC-LIDOS AC-CONTA. */
            AREA_DE_WORK.AC_LIDOS.Value = AREA_DE_WORK.AC_LIDOS + 1;
            AREA_DE_WORK.AC_CONTA.Value = AREA_DE_WORK.AC_CONTA + 1;

            /*" -582- IF AC-CONTA > 999 */

            if (AREA_DE_WORK.AC_CONTA > 999)
            {

                /*" -583- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

                /*" -584- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AREA_DE_WORK.AC_CONTA);

                /*" -588- DISPLAY 'LIDOS PROPOVA ..... ' AC-LIDOS ' ' WS-TIME ' ' PROPOVA-NUM-CERTIFICADO */

                $"LIDOS PROPOVA ..... {AREA_DE_WORK.AC_LIDOS} {AREA_DE_WORK.WS_TIME} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -590- END-IF. */
            }


            /*" -593- MOVE PROPOVA-NUM-APOLICE TO WS-ATU-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, AREA_DE_WORK.WS_CHAVE_ATU.WS_ATU_NUM_APOLICE);

            /*" -594- MOVE PROPOVA-COD-SUBGRUPO TO WS-ATU-COD-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, AREA_DE_WORK.WS_CHAVE_ATU.WS_ATU_COD_SUBGRUPO);

        }

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-DB-FETCH-1 */
        public void R0400_00_FETCH_CURS01_DB_FETCH_1()
        {
            /*" -564- EXEC SQL FETCH CURS01 INTO :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-COD-CLIENTE, :PROPOVA-OCORR-HISTORICO, :PROPOVA-DATA-QUITACAO, :PROPOVA-DTPROXVEN, :PROPOVA-NUM-PARCELA, :PROPOVA-OPCAO-COBERTURA END-EXEC. */

            if (CURS01.Fetch())
            {
                _.Move(CURS01.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(CURS01.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(CURS01.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(CURS01.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(CURS01.PROPOVA_OCORR_HISTORICO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO);
                _.Move(CURS01.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(CURS01.PROPOVA_DTPROXVEN, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN);
                _.Move(CURS01.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(CURS01.PROPOVA_OPCAO_COBERTURA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA);
            }

        }

        [StopWatch]
        /*" R0400-00-FETCH-CURS01-DB-CLOSE-1 */
        public void R0400_00_FETCH_CURS01_DB_CLOSE_1()
        {
            /*" -569- EXEC SQL CLOSE CURS01 END-EXEC */

            CURS01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-CURS01-SECTION */
        private void R1000_00_PROCESSA_CURS01_SECTION()
        {
            /*" -604- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -607- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -608- DISPLAY '*** CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
            _.Display($"*** CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -610- PERFORM R1200-00-SELECT-HISCOBPR. */

            R1200_00_SELECT_HISCOBPR_SECTION();

            /*" -611- IF (HISCOBPR-DATA-INIVIGENCIA > WS-DATA-MOV-ABERTO) */

            if ((HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA > WS_DATA_MOV_ABERTO))
            {

                /*" -613- MOVE HISCOBPR-DATA-INIVIGENCIA TO SISTEMAS-DATA-MOV-ABERTO */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

                /*" -615- MOVE HISCOBPR-DATA-INIVIG-1 TO SISTEMAS-DATA-MOV-ABERTO-01 */
                _.Move(HISCOBPR_DATA_INIVIG_1, SISTEMAS_DATA_MOV_ABERTO_01);

                /*" -616- ELSE */
            }
            else
            {


                /*" -618- MOVE WS-DATA-MOV-ABERTO TO SISTEMAS-DATA-MOV-ABERTO */
                _.Move(WS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);

                /*" -620- MOVE WS-DATA-MOV-ABERTO-1 TO SISTEMAS-DATA-MOV-ABERTO-01 */
                _.Move(WS_DATA_MOV_ABERTO_1, SISTEMAS_DATA_MOV_ABERTO_01);

                /*" -622- END-IF. */
            }


            /*" -624- PERFORM R1010-00-SELECT-SEGURVGA. */

            R1010_00_SELECT_SEGURVGA_SECTION();

            /*" -625- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -626- DISPLAY 'SAI 01' */
                _.Display($"SAI 01");

                /*" -628- ADD 1 TO AC-DESPR-SEGURVGA AC-DESPR */
                AREA_DE_WORK.AC_DESPR_SEGURVGA.Value = AREA_DE_WORK.AC_DESPR_SEGURVGA + 1;
                AREA_DE_WORK.AC_DESPR.Value = AREA_DE_WORK.AC_DESPR + 1;

                /*" -629- GO TO R1000-10-LER-OUTRO */

                R1000_10_LER_OUTRO(); //GOTO
                return;

                /*" -632- END-IF. */
            }


            /*" -634- PERFORM R1020-00-SELECT-SEGURHIS. */

            R1020_00_SELECT_SEGURHIS_SECTION();

            /*" -635- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -636- DISPLAY 'SAI 02' */
                _.Display($"SAI 02");

                /*" -638- ADD 1 TO AC-DESPR-SEGURHIS AC-DESPR */
                AREA_DE_WORK.AC_DESPR_SEGURHIS.Value = AREA_DE_WORK.AC_DESPR_SEGURHIS + 1;
                AREA_DE_WORK.AC_DESPR.Value = AREA_DE_WORK.AC_DESPR + 1;

                /*" -639- GO TO R1000-10-LER-OUTRO */

                R1000_10_LER_OUTRO(); //GOTO
                return;

                /*" -641- END-IF. */
            }


            /*" -643- PERFORM R1450-00-SELECT-OPCPAGVI. */

            R1450_00_SELECT_OPCPAGVI_SECTION();

            /*" -644- IF WS-TEM-OPCPAGVI EQUAL 'N' */

            if (WS_TEM_OPCPAGVI == "N")
            {

                /*" -645- DISPLAY 'SAI 03' */
                _.Display($"SAI 03");

                /*" -647- ADD 1 TO AC-DESPR-OPCPAGVI AC-DESPR */
                AREA_DE_WORK.AC_DESPR_OPCPAGVI.Value = AREA_DE_WORK.AC_DESPR_OPCPAGVI + 1;
                AREA_DE_WORK.AC_DESPR.Value = AREA_DE_WORK.AC_DESPR + 1;

                /*" -648- GO TO R1000-10-LER-OUTRO */

                R1000_10_LER_OUTRO(); //GOTO
                return;

                /*" -650- END-IF. */
            }


            /*" -652- IF WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT */

            if (AREA_DE_WORK.WS_CHAVE_ATU != AREA_DE_WORK.WS_CHAVE_ANT)
            {

                /*" -657- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(AREA_DE_WORK.WS_CHAVE_ATU, AREA_DE_WORK.WS_CHAVE_ANT);

                /*" -660- PERFORM R1100-00-SELECT-SUBGVGAP */

                R1100_00_SELECT_SUBGVGAP_SECTION();

                /*" -661- PERFORM R1110-00-SEL-PLANO-SUBGRUPO */

                R1110_00_SEL_PLANO_SUBGRUPO_SECTION();

                /*" -662- IF WS-TEM-SUBGVGAP EQUAL 'N' */

                if (WS_TEM_SUBGVGAP == "N")
                {

                    /*" -663- DISPLAY 'SAI 04' */
                    _.Display($"SAI 04");

                    /*" -665- ADD 1 TO AC-DESPR-SUBGVGAP AC-DESPR */
                    AREA_DE_WORK.AC_DESPR_SUBGVGAP.Value = AREA_DE_WORK.AC_DESPR_SUBGVGAP + 1;
                    AREA_DE_WORK.AC_DESPR.Value = AREA_DE_WORK.AC_DESPR + 1;

                    /*" -666- GO TO R1000-10-LER-OUTRO */

                    R1000_10_LER_OUTRO(); //GOTO
                    return;

                    /*" -669- END-IF */
                }


                /*" -670- PERFORM R1120-00-SELECT-PRODUVG */

                R1120_00_SELECT_PRODUVG_SECTION();

                /*" -674- END-IF. */
            }


            /*" -678- PERFORM R1300-00-SELECT-CLIENTES. */

            R1300_00_SELECT_CLIENTES_SECTION();

            /*" -681- MOVE CLIENTES-DATA-NASCIMENTO TO WS-DATA-NASCIMENTO. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO, AREA_DE_WORK.WS_DATA_NASCIMENTO);

            /*" -684- SUBTRACT WS-ANO-NASC FROM WS-ANO-SIST GIVING PROPOVA-IDADE. */
            PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.Value = AREA_DE_WORK.WS_DATA_SISTEMA.WS_ANO_SIST - AREA_DE_WORK.WS_DATA_NASCIMENTO.WS_ANO_NASC;

            /*" -686- IF CLIENTES-DATA-NASCIMENTO(6:5) > SISTEMAS-DATA-MOV-ABERTO(6:5) */

            if (CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Substring(6, 5) > SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 5))
            {

                /*" -690- SUBTRACT 1 FROM PROPOVA-IDADE. */
                PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.Value = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE - 1;
            }


            /*" -691- MOVE 'S' TO WTEM-PLAVAVGA. */
            _.Move("S", AREA_DE_WORK.WTEM_PLAVAVGA);

            /*" -693- PERFORM R1400-00-SELECT-PLAVAVGA. */

            R1400_00_SELECT_PLAVAVGA_SECTION();

            /*" -694- IF WTEM-PLAVAVGA NOT EQUAL 'S' */

            if (AREA_DE_WORK.WTEM_PLAVAVGA != "S")
            {

                /*" -696- ADD 1 TO AC-DESPR-PLAVAVGA AC-DESPR */
                AREA_DE_WORK.AC_DESPR_PLAVAVGA.Value = AREA_DE_WORK.AC_DESPR_PLAVAVGA + 1;
                AREA_DE_WORK.AC_DESPR.Value = AREA_DE_WORK.AC_DESPR + 1;

                /*" -697- DISPLAY 'NAO ENCONTRADO PLANOS_VA_VGAP' */
                _.Display($"NAO ENCONTRADO PLANOS_VA_VGAP");

                /*" -698- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -699- DISPLAY 'APOLICE       ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -700- DISPLAY 'SUBGRUPO      ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO      {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -701- DISPLAY 'OPCAO_COBER   ' HISCOBPR-OPCAO-COBERTURA */
                _.Display($"OPCAO_COBER   {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA}");

                /*" -702- DISPLAY 'IDADE         ' PROPOVA-IDADE */
                _.Display($"IDADE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

                /*" -703- DISPLAY 'PERIPGTO      ' PRODUVG-PERI-PAGAMENTO */
                _.Display($"PERIPGTO      {PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}");

                /*" -704- GO TO R1000-10-LER-OUTRO */

                R1000_10_LER_OUTRO(); //GOTO
                return;

                /*" -708- END-IF. */
            }


            /*" -709- MOVE 'N' TO WS-SUBSCRICAO-DINAMICA */
            _.Move("N", WS_SUBSCRICAO_DINAMICA);

            /*" -713- PERFORM R1405-00-VALIDA-AGRAVO */

            R1405_00_VALIDA_AGRAVO_SECTION();

            /*" -722- PERFORM R1410-00-VALIDA-PREMIO. */

            R1410_00_VALIDA_PREMIO_SECTION();

            /*" -723- PERFORM R1460-00-SELECT-OPCPAGVI. */

            R1460_00_SELECT_OPCPAGVI_SECTION();

            /*" -724- IF WS-TEM-OPCPAGVI EQUAL 'S' */

            if (WS_TEM_OPCPAGVI == "S")
            {

                /*" -725- DISPLAY 'SAI 05' */
                _.Display($"SAI 05");

                /*" -727- ADD 1 TO AC-DESPR-OPCPAGVI AC-DESPR */
                AREA_DE_WORK.AC_DESPR_OPCPAGVI.Value = AREA_DE_WORK.AC_DESPR_OPCPAGVI + 1;
                AREA_DE_WORK.AC_DESPR.Value = AREA_DE_WORK.AC_DESPR + 1;

                /*" -728- GO TO R1000-10-LER-OUTRO */

                R1000_10_LER_OUTRO(); //GOTO
                return;

                /*" -730- END-IF. */
            }


            /*" -731- PERFORM R1500-00-INSERT-OPCPAGVI. */

            R1500_00_INSERT_OPCPAGVI_SECTION();

            /*" -735- PERFORM R1510-00-UPDATE-OPCPAGVI. */

            R1510_00_UPDATE_OPCPAGVI_SECTION();

            /*" -737- MOVE PROPOVA-OCORR-HISTORICO TO PROPOVA-OCORR-HISTORICO1 */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCORR_HISTORICO, PROPOVA_OCORR_HISTORICO1);

            /*" -740- ADD 1 TO PROPOVA-OCORR-HISTORICO1 */
            PROPOVA_OCORR_HISTORICO1.Value = PROPOVA_OCORR_HISTORICO1 + 1;

            /*" -741- PERFORM R1600-00-INSERT-HISCOBPR. */

            R1600_00_INSERT_HISCOBPR_SECTION();

            /*" -742- PERFORM R1610-00-UPDATE-HISCOBPR. */

            R1610_00_UPDATE_HISCOBPR_SECTION();

            /*" -743- PERFORM R1620-00-INSERT-PARCEVID. */

            R1620_00_INSERT_PARCEVID_SECTION();

            /*" -745- PERFORM R1630-00-INSERT-COBHISVI. */

            R1630_00_INSERT_COBHISVI_SECTION();

            /*" -746- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' OR '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2", "5"))
            {

                /*" -747- MOVE 0 TO VIND-NUMCAR */
                _.Move(0, VIND_NUMCAR);

                /*" -748- MOVE 0 TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -749- PERFORM R1640-00-INSERT-HISLANCT */

                R1640_00_INSERT_HISLANCT_SECTION();

                /*" -751- END-IF. */
            }


            /*" -752- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == "5")
            {

                /*" -753- PERFORM R1650-00-DEBITO-CARTAO */

                R1650_00_DEBITO_CARTAO_SECTION();

                /*" -757- END-IF. */
            }


            /*" -764- PERFORM R1700-00-UPDATE-PROPOVA. */

            R1700_00_UPDATE_PROPOVA_SECTION();

            /*" -771- PERFORM R1750-00-INSERT-RELATO-PF10. */

            R1750_00_INSERT_RELATO_PF10_SECTION();

            /*" -773- MOVE SEGURVGA-OCORR-HISTORICO TO SEGURVGA-OCORR-HISTORICO1 */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, SEGURVGA_OCORR_HISTORICO1);

            /*" -776- ADD 1 TO SEGURVGA-OCORR-HISTORICO1 */
            SEGURVGA_OCORR_HISTORICO1.Value = SEGURVGA_OCORR_HISTORICO1 + 1;

            /*" -781- PERFORM R1800-00-UPDATE-SEGURVGA. */

            R1800_00_UPDATE_SEGURVGA_SECTION();

            /*" -785- PERFORM R1900-00-INSERT-SEGURHIS. */

            R1900_00_INSERT_SEGURHIS_SECTION();

            /*" -786- MOVE 'NAO' TO WFIM-CURS02 */
            _.Move("NAO", AREA_DE_WORK.WFIM_CURS02);

            /*" -787- PERFORM R2900-00-OPEN-CURS02 */

            R2900_00_OPEN_CURS02_SECTION();

            /*" -788- PERFORM R2910-00-FETCH-CURS02 */

            R2910_00_FETCH_CURS02_SECTION();

            /*" -791- PERFORM R3000-00-PROCESSA-CURS02 UNTIL WFIM-CURS02 EQUAL 'SIM' */

            while (!(AREA_DE_WORK.WFIM_CURS02 == "SIM"))
            {

                R3000_00_PROCESSA_CURS02_SECTION();
            }

            /*" -791- ADD 1 TO AC-PROC. */
            AREA_DE_WORK.AC_PROC.Value = AREA_DE_WORK.AC_PROC + 1;

            /*" -0- FLUXCONTROL_PERFORM R1000_10_LER_OUTRO */

            R1000_10_LER_OUTRO();

        }

        [StopWatch]
        /*" R1000-10-LER-OUTRO */
        private void R1000_10_LER_OUTRO(bool isPerform = false)
        {
            /*" -795- PERFORM R0400-00-FETCH-CURS01. */

            R0400_00_FETCH_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-SECTION */
        private void R1010_00_SELECT_SEGURVGA_SECTION()
        {
            /*" -805- MOVE '1010' TO WNR-EXEC-SQL. */
            _.Move("1010", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -807- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -809- INITIALIZE DCLSEGURADOS-VGAP */
            _.Initialize(
                SEGURVGA.DCLSEGURADOS_VGAP
            );

            /*" -818- PERFORM R1010_00_SELECT_SEGURVGA_DB_SELECT_1 */

            R1010_00_SELECT_SEGURVGA_DB_SELECT_1();

            /*" -821- IF SQLCODE NOT EQUAL ZERO AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -822- DISPLAY 'ERRO NO SELECT SEGURADOS_VGAP' */
                _.Display($"ERRO NO SELECT SEGURADOS_VGAP");

                /*" -823- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -824- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -824- END-IF. */
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-SEGURVGA-DB-SELECT-1 */
        public void R1010_00_SELECT_SEGURVGA_DB_SELECT_1()
        {
            /*" -818- EXEC SQL SELECT OCORR_HISTORICO , NUM_ITEM INTO :SEGURVGA-OCORR-HISTORICO , :SEGURVGA-NUM-ITEM FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' WITH UR END-EXEC. */

            var r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1 = new R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_SEGURVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-SEGURHIS-SECTION */
        private void R1020_00_SELECT_SEGURHIS_SECTION()
        {
            /*" -834- MOVE '1020' TO WNR-EXEC-SQL. */
            _.Move("1020", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -836- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -838- INITIALIZE DCLSEGURADOSVGAP-HIST */
            _.Initialize(
                SEGURHIS.DCLSEGURADOSVGAP_HIST
            );

            /*" -839- DISPLAY 'NUM-CERTIFICADO = ' PROPOVA-NUM-CERTIFICADO */
            _.Display($"NUM-CERTIFICADO = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -840- DISPLAY 'NUM-APOLICE     = ' PROPOVA-NUM-APOLICE */
            _.Display($"NUM-APOLICE     = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

            /*" -842- DISPLAY 'NUM-ITEM        = ' SEGURVGA-NUM-ITEM */
            _.Display($"NUM-ITEM        = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

            /*" -850- PERFORM R1020_00_SELECT_SEGURHIS_DB_SELECT_1 */

            R1020_00_SELECT_SEGURHIS_DB_SELECT_1();

            /*" -853- IF SQLCODE NOT EQUAL ZERO AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -854- DISPLAY 'ERRO NO SELECT SEGURADOSVGAP_HIST' */
                _.Display($"ERRO NO SELECT SEGURADOSVGAP_HIST");

                /*" -855- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -856- DISPLAY 'ITEM       -> ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM       -> {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -857- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -857- END-IF. */
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-SEGURHIS-DB-SELECT-1 */
        public void R1020_00_SELECT_SEGURHIS_DB_SELECT_1()
        {
            /*" -850- EXEC SQL SELECT DATA_MOVIMENTO INTO :SEGURHIS-DATA-MOVIMENTO FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND COD_OPERACAO = 202 WITH UR END-EXEC. */

            var r1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1 = new R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_SEGURHIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURHIS_DATA_MOVIMENTO, SEGURHIS.DCLSEGURADOSVGAP_HIST.SEGURHIS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SUBGVGAP-SECTION */
        private void R1100_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -867- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -869- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -871- INITIALIZE DCLSUBGRUPOS-VGAP. */
            _.Initialize(
                SUBGVGAP.DCLSUBGRUPOS_VGAP
            );

            /*" -878- PERFORM R1100_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R1100_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -881- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -882- DISPLAY 'ERRO NO SELECT SUBGRUPOS-VGAP' */
                _.Display($"ERRO NO SELECT SUBGRUPOS-VGAP");

                /*" -883- DISPLAY 'CLIENTE ----> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CLIENTE ----> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -884- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -884- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R1100_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -878- EXEC SQL SELECT OPCAO_CONJUGE INTO :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO WITH UR END-EXEC. */

            var r1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-SEL-PLANO-SUBGRUPO-SECTION */
        private void R1110_00_SEL_PLANO_SUBGRUPO_SECTION()
        {
            /*" -894- MOVE '1110' TO WNR-EXEC-SQL. */
            _.Move("1110", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -895- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -900- MOVE 'S' TO WS-TEM-SUBGVGAP. */
            _.Move("S", WS_TEM_SUBGVGAP);

            /*" -914- PERFORM R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1 */

            R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1();

            /*" -918- DISPLAY '# ' PROPOVA-NUM-CERTIFICADO '*' OPCPAGVI-PERI-PAGAMENTO */

            $"# {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}*{OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO}"
            .Display();

            /*" -925- DISPLAY '% ' PROPOVA-OPCAO-COBERTURA '/' OPCPAGVI-PERI-PAGAMENTO '/' PROPOVA-NUM-APOLICE '/' PROPOVA-COD-SUBGRUPO '*' VG130-COD-TIPO-ASSISTENCIA '*' VG130-IND-OPCAO-CONJUGE '*' VG130-STA-REGISTRO */

            $"% {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA}/{OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}*{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}*{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE}*{VG130.DCLVG_PLANO_SUBGRUPO.VG130_STA_REGISTRO}"
            .Display();

            /*" -927- IF SQLCODE EQUAL ZEROS AND VG130-STA-REGISTRO EQUAL '0' */

            if (DB.SQLCODE == 00 && VG130.DCLVG_PLANO_SUBGRUPO.VG130_STA_REGISTRO == "0")
            {

                /*" -928- MOVE 001 TO PRODUVG-PERI-PAGAMENTO */
                _.Move(001, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);

                /*" -929- ELSE */
            }
            else
            {


                /*" -930- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -931- PERFORM R1111-00-SELECT-SUBGVGAP */

                    R1111_00_SELECT_SUBGVGAP_SECTION();

                    /*" -932- GO TO R1110-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/ //GOTO
                    return;

                    /*" -933- ELSE */
                }
                else
                {


                    /*" -934- DISPLAY 'ERRO NO SEL VG_PLANO_SUBGRUPO - 1' */
                    _.Display($"ERRO NO SEL VG_PLANO_SUBGRUPO - 1");

                    /*" -940- DISPLAY PROPOVA-NUM-CERTIFICADO '/' PROPOVA-OPCAO-COBERTURA '/' PRODUVG-PERI-PAGAMENTO '/' PROPOVA-NUM-APOLICE '/' PROPOVA-COD-SUBGRUPO '*' VG130-STA-REGISTRO ' <<==' */

                    $"{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA}/{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO}*{VG130.DCLVG_PLANO_SUBGRUPO.VG130_STA_REGISTRO} <<=="
                    .Display();

                    /*" -941- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -942- END-IF */
                }


                /*" -947- END-IF */
            }


            /*" -961- PERFORM R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2 */

            R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2();

            /*" -969- DISPLAY '$ ' PROPOVA-OPCAO-COBERTURA '/' PRODUVG-PERI-PAGAMENTO '/' VG130-IND-OPCAO-CONJUGE '/' VG130-COD-TIPO-ASSISTENCIA '/' PROPOVA-NUM-APOLICE '*' SUBGVGAP-COD-SUBGRUPO */

            $"$ {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA}/{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}*{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
            .Display();

            /*" -970- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -971- DISPLAY 'ERRO NO SEL VG_PLANO_SUBGRUPO - 2' */
                _.Display($"ERRO NO SEL VG_PLANO_SUBGRUPO - 2");

                /*" -976- DISPLAY PROPOVA-NUM-CERTIFICADO '/' PROPOVA-OPCAO-COBERTURA '/' PRODUVG-PERI-PAGAMENTO '/' VG130-COD-TIPO-ASSISTENCIA '/' PROPOVA-NUM-APOLICE */

                $"{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA}/{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}/{VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA}/{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}"
                .Display();

                /*" -977- MOVE 'N' TO WS-TEM-SUBGVGAP */
                _.Move("N", WS_TEM_SUBGVGAP);

                /*" -979- END-IF */
            }


            /*" -979- . */

        }

        [StopWatch]
        /*" R1110-00-SEL-PLANO-SUBGRUPO-DB-SELECT-1 */
        public void R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1()
        {
            /*" -914- EXEC SQL SELECT IND_OPCAO_CONJUGE , COD_TIPO_ASSISTENCIA , STA_REGISTRO INTO :VG130-IND-OPCAO-CONJUGE , :VG130-COD-TIPO-ASSISTENCIA , :VG130-STA-REGISTRO FROM SEGUROS.VG_PLANO_SUBGRUPO WHERE COD_EMPRESA_SIVPF = 001 AND COD_OPCAO_COBER = :PROPOVA-OPCAO-COBERTURA AND IND_PERIOD_PGTO = :OPCPAGVI-PERI-PAGAMENTO AND NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO WITH UR END-EXEC */

            var r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1 = new R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1()
            {
                PROPOVA_OPCAO_COBERTURA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA.ToString(),
                OPCPAGVI_PERI_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1.Execute(r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VG130_IND_OPCAO_CONJUGE, VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE);
                _.Move(executed_1.VG130_COD_TIPO_ASSISTENCIA, VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA);
                _.Move(executed_1.VG130_STA_REGISTRO, VG130.DCLVG_PLANO_SUBGRUPO.VG130_STA_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-SEL-PLANO-SUBGRUPO-DB-SELECT-2 */
        public void R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2()
        {
            /*" -961- EXEC SQL SELECT COD_SUBGRUPO INTO :SUBGVGAP-COD-SUBGRUPO FROM SEGUROS.VG_PLANO_SUBGRUPO WHERE COD_EMPRESA_SIVPF = 001 AND COD_OPCAO_COBER = :PROPOVA-OPCAO-COBERTURA AND IND_PERIOD_PGTO = :PRODUVG-PERI-PAGAMENTO AND IND_OPCAO_CONJUGE = :VG130-IND-OPCAO-CONJUGE AND COD_TIPO_ASSISTENCIA = :VG130-COD-TIPO-ASSISTENCIA AND NUM_APOLICE = :PROPOVA-NUM-APOLICE AND STA_REGISTRO = '0' WITH UR END-EXEC. */

            var r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1 = new R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1()
            {
                VG130_COD_TIPO_ASSISTENCIA = VG130.DCLVG_PLANO_SUBGRUPO.VG130_COD_TIPO_ASSISTENCIA.ToString(),
                PROPOVA_OPCAO_COBERTURA = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OPCAO_COBERTURA.ToString(),
                VG130_IND_OPCAO_CONJUGE = VG130.DCLVG_PLANO_SUBGRUPO.VG130_IND_OPCAO_CONJUGE.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1.Execute(r1110_00_SEL_PLANO_SUBGRUPO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);
            }


        }

        [StopWatch]
        /*" R1111-00-SELECT-SUBGVGAP-SECTION */
        private void R1111_00_SELECT_SUBGVGAP_SECTION()
        {
            /*" -988- MOVE '1111' TO WNR-EXEC-SQL. */
            _.Move("1111", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -989- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -991- MOVE 'S' TO WS-TEM-SUBGVGAP. */
            _.Move("S", WS_TEM_SUBGVGAP);

            /*" -996- MOVE 01 TO PRODUVG-PERI-PAGAMENTO */
            _.Move(01, PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO);

            /*" -1007- PERFORM R1111_00_SELECT_SUBGVGAP_DB_SELECT_1 */

            R1111_00_SELECT_SUBGVGAP_DB_SELECT_1();

            /*" -1014- DISPLAY '& ' PROPOVA-NUM-APOLICE '/' SUBGVGAP-OPCAO-CONJUGE '/' PRODUVG-PERI-PAGAMENTO '*' SUBGVGAP-COD-SUBGRUPO */

            $"& {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}/{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE}/{PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}*{SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}"
            .Display();

            /*" -1015- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1016- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1017- MOVE 'N' TO WS-TEM-SUBGVGAP */
                    _.Move("N", WS_TEM_SUBGVGAP);

                    /*" -1018- GO TO R1111-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R1111_99_SAIDA*/ //GOTO
                    return;

                    /*" -1019- ELSE */
                }
                else
                {


                    /*" -1020- DISPLAY 'ERRO NO SELECT SUBGRUPOS-VGAP 1A' */
                    _.Display($"ERRO NO SELECT SUBGRUPOS-VGAP 1A");

                    /*" -1021- DISPLAY 'CERTIFICADO -> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO -> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1022- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1023- END-IF */
                }


                /*" -1025- END-IF. */
            }


            /*" -1026- IF SUBGVGAP-COD-SUBGRUPO EQUAL ZEROS */

            if (SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO == 00)
            {

                /*" -1027- DISPLAY 'ERRO NO SELECT SUBGRUPOS-VGAP 2A' */
                _.Display($"ERRO NO SELECT SUBGRUPOS-VGAP 2A");

                /*" -1028- DISPLAY 'CERTIFICADO -> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO -> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1029- MOVE 'N' TO WS-TEM-SUBGVGAP */
                _.Move("N", WS_TEM_SUBGVGAP);

                /*" -1029- END-IF. */
            }


        }

        [StopWatch]
        /*" R1111-00-SELECT-SUBGVGAP-DB-SELECT-1 */
        public void R1111_00_SELECT_SUBGVGAP_DB_SELECT_1()
        {
            /*" -1007- EXEC SQL SELECT VALUE(MAX(A.COD_SUBGRUPO),0) INTO :SUBGVGAP-COD-SUBGRUPO FROM SEGUROS.SUBGRUPOS_VGAP A, SEGUROS.PRODUTOS_VG B WHERE A.NUM_APOLICE = :PROPOVA-NUM-APOLICE AND A.OPCAO_CONJUGE = :SUBGVGAP-OPCAO-CONJUGE AND B.NUM_APOLICE = A.NUM_APOLICE AND B.COD_SUBGRUPO = A.COD_SUBGRUPO AND B.PERI_PAGAMENTO = :PRODUVG-PERI-PAGAMENTO WITH UR END-EXEC. */

            var r1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1 = new R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1()
            {
                SUBGVGAP_OPCAO_CONJUGE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1.Execute(r1111_00_SELECT_SUBGVGAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1111_99_SAIDA*/

        [StopWatch]
        /*" R1120-00-SELECT-PRODUVG-SECTION */
        private void R1120_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1039- MOVE '1120' TO WNR-EXEC-SQL. */
            _.Move("1120", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1041- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1048- PERFORM R1120_00_SELECT_PRODUVG_DB_SELECT_1 */

            R1120_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1051- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1052- DISPLAY 'ERRO NO SELECT PRODUTOS_VG' */
                _.Display($"ERRO NO SELECT PRODUTOS_VG");

                /*" -1053- DISPLAY 'CERTIFICADO -> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO -> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1054- DISPLAY 'APOLICE        ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE        {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -1055- DISPLAY 'SUBGRUPO       ' SUBGVGAP-COD-SUBGRUPO */
                _.Display($"SUBGRUPO       {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                /*" -1056- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1056- END-IF. */
            }


        }

        [StopWatch]
        /*" R1120-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R1120_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1048- EXEC SQL SELECT COD_PRODUTO INTO :PRODUVG-COD-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var r1120_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R1120_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1120_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r1120_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_COD_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1120_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-HISCOBPR-SECTION */
        private void R1200_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1066- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1068- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1085- PERFORM R1200_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R1200_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1088- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1089- DISPLAY 'ERRO NO SELECT HIS_COBER_PROPOST' */
                _.Display($"ERRO NO SELECT HIS_COBER_PROPOST");

                /*" -1090- DISPLAY 'CERTIFICADO -> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO -> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1091- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1091- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R1200_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1085- EXEC SQL SELECT OPCAO_COBERTURA , VLPREMIO , PRMVG , PRMAP , DATA_INIVIGENCIA, DATA_INIVIGENCIA - 1 DAY INTO :HISCOBPR-OPCAO-COBERTURA , :HISCOBPR-VLPREMIO , :HISCOBPR-PRMVG , :HISCOBPR-PRMAP , :HISCOBPR-DATA-INIVIGENCIA, :HISCOBPR-DATA-INIVIG-1 FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_OPCAO_COBERTURA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA);
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_PRMVG, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG);
                _.Move(executed_1.HISCOBPR_PRMAP, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP);
                _.Move(executed_1.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(executed_1.HISCOBPR_DATA_INIVIG_1, HISCOBPR_DATA_INIVIG_1);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-SECTION */
        private void R1300_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1101- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1103- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1105- INITIALIZE DCLCLIENTES. */
            _.Initialize(
                CLIENTES.DCLCLIENTES
            );

            /*" -1113- PERFORM R1300_00_SELECT_CLIENTES_DB_SELECT_1 */

            R1300_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1116- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1117- DISPLAY 'ERRO NO SELECT CLIENTES' */
                _.Display($"ERRO NO SELECT CLIENTES");

                /*" -1118- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1119- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1121- END-IF. */
            }


            /*" -1122- IF WDT-NASC-NLL LESS +0 */

            if (WDT_NASC_NLL < +0)
            {

                /*" -1124- MOVE '0001-01-01' TO CLIENTES-DATA-NASCIMENTO */
                _.Move("0001-01-01", CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);

                /*" -1124- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R1300_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1113- EXEC SQL SELECT CGCCPF , DATA_NASCIMENTO INTO :CLIENTES-CGCCPF , :CLIENTES-DATA-NASCIMENTO:WDT-NASC-NLL FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :PROPOVA-COD-CLIENTE WITH UR END-EXEC. */

            var r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_CLIENTE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.WDT_NASC_NLL, WDT_NASC_NLL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-PLAVAVGA-SECTION */
        private void R1400_00_SELECT_PLAVAVGA_SECTION()
        {
            /*" -1134- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1136- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1138- INITIALIZE DCLPLANOS-VA-VGAP */
            _.Initialize(
                PLAVAVGA.DCLPLANOS_VA_VGAP
            );

            /*" -1172- PERFORM R1400_00_SELECT_PLAVAVGA_DB_SELECT_1 */

            R1400_00_SELECT_PLAVAVGA_DB_SELECT_1();

            /*" -1175- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1176- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1177- PERFORM R1401-00-SELECT-PLAVAVGA */

                    R1401_00_SELECT_PLAVAVGA_SECTION();

                    /*" -1178- ELSE */
                }
                else
                {


                    /*" -1179- DISPLAY 'ERRO NO SELECT PLANOS_VA_VGAP' */
                    _.Display($"ERRO NO SELECT PLANOS_VA_VGAP");

                    /*" -1180- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1181- DISPLAY 'APOLICE       ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -1182- DISPLAY 'SUBGRUPO      ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO      {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -1183- DISPLAY 'OPCAO_COBER   ' HISCOBPR-OPCAO-COBERTURA */
                    _.Display($"OPCAO_COBER   {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA}");

                    /*" -1184- DISPLAY 'IDADE         ' PROPOVA-IDADE */
                    _.Display($"IDADE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

                    /*" -1185- DISPLAY 'PERIPGTO      ' PRODUVG-PERI-PAGAMENTO */
                    _.Display($"PERIPGTO      {PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}");

                    /*" -1186- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1187- END-IF */
                }


                /*" -1187- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-PLAVAVGA-DB-SELECT-1 */
        public void R1400_00_SELECT_PLAVAVGA_DB_SELECT_1()
        {
            /*" -1172- EXEC SQL SELECT IMPMORNATU , IMPMORACID , VLPREMIOTOT , PRMVG , PRMAP , FAIXA , QTTITCAP , VLTITCAP , VLCUSTCAP , PCT_FAIXA_ETARIA INTO :PLAVAVGA-IMPMORNATU , :PLAVAVGA-IMPMORACID , :PLAVAVGA-VLPREMIOTOT , :PLAVAVGA-PRMVG , :PLAVAVGA-PRMAP , :PLAVAVGA-FAIXA , :PLAVAVGA-QTTITCAP , :PLAVAVGA-VLTITCAP , :PLAVAVGA-VLCUSTCAP , :PLAVAVGA-PCT-FAIXA-ETARIA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND CODSUBES = :SUBGVGAP-COD-SUBGRUPO AND OPCAO_COBER = :HISCOBPR-OPCAO-COBERTURA AND IDADE_INICIAL <= :PROPOVA-IDADE AND IDADE_FINAL >= :PROPOVA-IDADE AND PERIPGTO = :PRODUVG-PERI-PAGAMENTO AND DTINIVIG <= :PROPOVA-DATA-QUITACAO AND DTTERVIG >= :PROPOVA-DATA-QUITACAO WITH UR END-EXEC. */

            var r1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1 = new R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1()
            {
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                PROPOVA_DATA_QUITACAO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_IDADE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.ToString(),
            };

            var executed_1 = R1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_IMPMORNATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU);
                _.Move(executed_1.PLAVAVGA_IMPMORACID, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
                _.Move(executed_1.PLAVAVGA_PRMVG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG);
                _.Move(executed_1.PLAVAVGA_PRMAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP);
                _.Move(executed_1.PLAVAVGA_FAIXA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA);
                _.Move(executed_1.PLAVAVGA_QTTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_QTTITCAP);
                _.Move(executed_1.PLAVAVGA_VLTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLTITCAP);
                _.Move(executed_1.PLAVAVGA_VLCUSTCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCAP);
                _.Move(executed_1.PLAVAVGA_PCT_FAIXA_ETARIA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1401-00-SELECT-PLAVAVGA-SECTION */
        private void R1401_00_SELECT_PLAVAVGA_SECTION()
        {
            /*" -1197- MOVE '1401' TO WNR-EXEC-SQL. */
            _.Move("1401", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1199- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1200- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -1201- DISPLAY 'APOLICE       ' PROPOVA-NUM-APOLICE */
            _.Display($"APOLICE       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

            /*" -1202- DISPLAY 'SUBGRUPO      ' SUBGVGAP-COD-SUBGRUPO */
            _.Display($"SUBGRUPO      {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

            /*" -1203- DISPLAY 'OPCAO_COBER   ' HISCOBPR-OPCAO-COBERTURA */
            _.Display($"OPCAO_COBER   {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA}");

            /*" -1204- DISPLAY 'IDADE         ' PROPOVA-IDADE */
            _.Display($"IDADE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

            /*" -1206- DISPLAY 'PERIPGTO      ' PRODUVG-PERI-PAGAMENTO */
            _.Display($"PERIPGTO      {PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}");

            /*" -1239- PERFORM R1401_00_SELECT_PLAVAVGA_DB_SELECT_1 */

            R1401_00_SELECT_PLAVAVGA_DB_SELECT_1();

            /*" -1242- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1243- MOVE 'N' TO WTEM-PLAVAVGA */
                _.Move("N", AREA_DE_WORK.WTEM_PLAVAVGA);

                /*" -1244- ELSE */
            }
            else
            {


                /*" -1245- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1246- DISPLAY 'ERRO NO SELECT PLANOS_VA_VGAP' */
                    _.Display($"ERRO NO SELECT PLANOS_VA_VGAP");

                    /*" -1247- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1248- DISPLAY 'APOLICE       ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -1249- DISPLAY 'SUBGRUPO      ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO      {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -1250- DISPLAY 'OPCAO_COBER   ' HISCOBPR-OPCAO-COBERTURA */
                    _.Display($"OPCAO_COBER   {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA}");

                    /*" -1251- DISPLAY 'IDADE         ' PROPOVA-IDADE */
                    _.Display($"IDADE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

                    /*" -1252- DISPLAY 'PERIPGTO      ' PRODUVG-PERI-PAGAMENTO */
                    _.Display($"PERIPGTO      {PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}");

                    /*" -1253- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1253- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1401-00-SELECT-PLAVAVGA-DB-SELECT-1 */
        public void R1401_00_SELECT_PLAVAVGA_DB_SELECT_1()
        {
            /*" -1239- EXEC SQL SELECT IMPMORNATU , IMPMORACID , VLPREMIOTOT , PRMVG , PRMAP , FAIXA , QTTITCAP , VLTITCAP , VLCUSTCAP , PCT_FAIXA_ETARIA INTO :PLAVAVGA-IMPMORNATU , :PLAVAVGA-IMPMORACID , :PLAVAVGA-VLPREMIOTOT , :PLAVAVGA-PRMVG , :PLAVAVGA-PRMAP , :PLAVAVGA-FAIXA , :PLAVAVGA-QTTITCAP , :PLAVAVGA-VLTITCAP , :PLAVAVGA-VLCUSTCAP , :PLAVAVGA-PCT-FAIXA-ETARIA FROM SEGUROS.PLANOS_VA_VGAP WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND CODSUBES = :SUBGVGAP-COD-SUBGRUPO AND OPCAO_COBER = :HISCOBPR-OPCAO-COBERTURA AND IDADE_INICIAL <= :PROPOVA-IDADE AND IDADE_FINAL >= :PROPOVA-IDADE AND PERIPGTO = :PRODUVG-PERI-PAGAMENTO AND DTTERVIG = '9999-12-31' WITH UR END-EXEC. */

            var r1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1 = new R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1()
            {
                HISCOBPR_OPCAO_COBERTURA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                PROPOVA_IDADE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE.ToString(),
            };

            var executed_1 = R1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1.Execute(r1401_00_SELECT_PLAVAVGA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PLAVAVGA_IMPMORNATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU);
                _.Move(executed_1.PLAVAVGA_IMPMORACID, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID);
                _.Move(executed_1.PLAVAVGA_VLPREMIOTOT, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);
                _.Move(executed_1.PLAVAVGA_PRMVG, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG);
                _.Move(executed_1.PLAVAVGA_PRMAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP);
                _.Move(executed_1.PLAVAVGA_FAIXA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA);
                _.Move(executed_1.PLAVAVGA_QTTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_QTTITCAP);
                _.Move(executed_1.PLAVAVGA_VLTITCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLTITCAP);
                _.Move(executed_1.PLAVAVGA_VLCUSTCAP, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCAP);
                _.Move(executed_1.PLAVAVGA_PCT_FAIXA_ETARIA, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1401_99_SAIDA*/

        [StopWatch]
        /*" R1405-00-VALIDA-AGRAVO-SECTION */
        private void R1405_00_VALIDA_AGRAVO_SECTION()
        {
            /*" -1263- MOVE '1405' TO WNR-EXEC-SQL. */
            _.Move("1405", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1268- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1281- PERFORM R1405_00_VALIDA_AGRAVO_DB_SELECT_1 */

            R1405_00_VALIDA_AGRAVO_DB_SELECT_1();

            /*" -1284- IF VIND-RET-SUBSCRICAO LESS ZEROS */

            if (VIND_RET_SUBSCRICAO < 00)
            {

                /*" -1285- MOVE SPACES TO GE406-IND-RET-SUBSCRICAO */
                _.Move("", GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO);

                /*" -1286- END-IF */
            }


            /*" -1287- IF VIND-PCT-AGRAVO LESS ZEROS */

            if (VIND_PCT_AGRAVO < 00)
            {

                /*" -1288- MOVE ZEROS TO GE406-PCT-AGRAVO */
                _.Move(0, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO);

                /*" -1289- END-IF */
            }


            /*" -1290- IF VIND-VLR-PRM-SEM-AGR LESS ZEROS */

            if (VIND_VLR_PRM_SEM_AGR < 00)
            {

                /*" -1291- MOVE ZEROS TO GE406-VLR-PRM-SEM-AGR */
                _.Move(0, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR);

                /*" -1293- END-IF */
            }


            /*" -1294-  EVALUATE SQLCODE  */

            /*" -1295-  WHEN ZEROS  */

            /*" -1295- IF   SQLCODE EQUALS  ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1296- PERFORM R1406-00-ATUALIZA-PREMIO */

                R1406_00_ATUALIZA_PREMIO_SECTION();

                /*" -1297-  WHEN +100  */

                /*" -1297- ELSE IF   SQLCODE EQUALS  +100 */
            }
            else

            if (DB.SQLCODE == +100)
            {

                /*" -1298- CONTINUE */

                /*" -1299-  WHEN OTHER  */

                /*" -1299- ELSE */
            }
            else
            {


                /*" -1300- DISPLAY 'PROBLEMAS NO SELECT GE_RETENCAO_PROP' */
                _.Display($"PROBLEMAS NO SELECT GE_RETENCAO_PROP");

                /*" -1301- DISPLAY ' NUMERO PROPOSTA....... ' PROPOVA-NUM-CERTIFICADO */
                _.Display($" NUMERO PROPOSTA....... {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1302- DISPLAY ' SQLCODE............... ' SQLCODE */
                _.Display($" SQLCODE............... {DB.SQLCODE}");

                /*" -1303- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1305-  END-EVALUATE  */

                /*" -1305- END-IF */
            }


            /*" -1305- . */

        }

        [StopWatch]
        /*" R1405-00-VALIDA-AGRAVO-DB-SELECT-1 */
        public void R1405_00_VALIDA_AGRAVO_DB_SELECT_1()
        {
            /*" -1281- EXEC SQL SELECT IND_SERV_CONSULTA , IND_RET_SUBSCRICAO , PCT_AGRAVO , VLR_PRM_SEM_AGR INTO :GE406-IND-SERV-CONSULTA , :GE406-IND-RET-SUBSCRICAO :VIND-RET-SUBSCRICAO , :GE406-PCT-AGRAVO :VIND-PCT-AGRAVO , :GE406-VLR-PRM-SEM-AGR :VIND-VLR-PRM-SEM-AGR FROM SEGUROS.GE_RETENCAO_PROPOSTA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND IND_PROCESSAMENTO = 'D' AND COD_USUARIO = 'VA0600B' END-EXEC */

            var r1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1 = new R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1.Execute(r1405_00_VALIDA_AGRAVO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE406_IND_SERV_CONSULTA, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA);
                _.Move(executed_1.GE406_IND_RET_SUBSCRICAO, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO);
                _.Move(executed_1.VIND_RET_SUBSCRICAO, VIND_RET_SUBSCRICAO);
                _.Move(executed_1.GE406_PCT_AGRAVO, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO);
                _.Move(executed_1.VIND_PCT_AGRAVO, VIND_PCT_AGRAVO);
                _.Move(executed_1.GE406_VLR_PRM_SEM_AGR, GE406.DCLGE_RETENCAO_PROPOSTA.GE406_VLR_PRM_SEM_AGR);
                _.Move(executed_1.VIND_VLR_PRM_SEM_AGR, VIND_VLR_PRM_SEM_AGR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1405_99_SAIDA*/

        [StopWatch]
        /*" R1406-00-ATUALIZA-PREMIO-SECTION */
        private void R1406_00_ATUALIZA_PREMIO_SECTION()
        {
            /*" -1316- MOVE '1406' TO WNR-EXEC-SQL. */
            _.Move("1406", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1318- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1319- IF GE406-IND-SERV-CONSULTA EQUAL 3 */

            if (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA == 3)
            {

                /*" -1320- PERFORM R1407-00-ATUALIZA-MATRIZ */

                R1407_00_ATUALIZA_MATRIZ_SECTION();

                /*" -1321- ELSE */
            }
            else
            {


                /*" -1322- PERFORM R1408-00-ATUALIZA-SUBSCRICAO */

                R1408_00_ATUALIZA_SUBSCRICAO_SECTION();

                /*" -1324- END-IF */
            }


            /*" -1324- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1406_99_SAIDA*/

        [StopWatch]
        /*" R1407-00-ATUALIZA-MATRIZ-SECTION */
        private void R1407_00_ATUALIZA_MATRIZ_SECTION()
        {
            /*" -1336- MOVE '1407' TO WNR-EXEC-SQL. */
            _.Move("1407", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1340- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1341- IF GE406-IND-RET-SUBSCRICAO EQUAL '1' OR '2' */

            if (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO.In("1", "2"))
            {

                /*" -1342- IF GE406-IND-RET-SUBSCRICAO EQUAL '1' */

                if (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO == "1")
                {

                    /*" -1343- MOVE GE406-PCT-AGRAVO TO WS-PER-EDT-001 */
                    _.Move(GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO, WS_PER_EDT_001);

                    /*" -1345- COMPUTE WS-PER-DESC = (GE406-PCT-AGRAVO / 100) */
                    WS_PER_DESC.Value = (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO / 100f);

                    /*" -1346- MOVE PLAVAVGA-PRMVG TO WS-VLR-EDT-001 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, WS_VLR_EDT_001);

                    /*" -1347- MOVE ZEROS TO WS-VLR-EDT-002 */
                    _.Move(0, WS_VLR_EDT_002);

                    /*" -1348- IF PLAVAVGA-PRMVG GREATER ZEROS */

                    if (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG > 00)
                    {

                        /*" -1350- COMPUTE WS-VLR-DESC = (PLAVAVGA-PRMVG * WS-PER-DESC) */
                        WS_VLR_DESC.Value = (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG * WS_PER_DESC);

                        /*" -1352- COMPUTE PLAVAVGA-PRMVG = (PLAVAVGA-PRMVG - WS-VLR-DESC) */
                        PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG.Value = (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG - WS_VLR_DESC);

                        /*" -1353- MOVE PLAVAVGA-PRMVG TO WS-VLR-EDT-002 */
                        _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, WS_VLR_EDT_002);

                        /*" -1354- END-IF */
                    }


                    /*" -1355- MOVE PLAVAVGA-PRMAP TO WS-VLR-EDT-003 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, WS_VLR_EDT_003);

                    /*" -1356- MOVE ZEROS TO WS-VLR-EDT-004 */
                    _.Move(0, WS_VLR_EDT_004);

                    /*" -1357- IF PLAVAVGA-PRMAP GREATER ZEROS */

                    if (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP > 00)
                    {

                        /*" -1359- COMPUTE WS-VLR-DESC = (PLAVAVGA-PRMAP * WS-PER-DESC) */
                        WS_VLR_DESC.Value = (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP * WS_PER_DESC);

                        /*" -1361- COMPUTE PLAVAVGA-PRMAP = (PLAVAVGA-PRMAP - WS-VLR-DESC) */
                        PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP.Value = (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP - WS_VLR_DESC);

                        /*" -1362- END-IF */
                    }


                    /*" -1363- MOVE PLAVAVGA-PRMAP TO WS-VLR-EDT-003 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, WS_VLR_EDT_003);

                    /*" -1365- COMPUTE PLAVAVGA-VLPREMIOTOT = PLAVAVGA-PRMVG + PLAVAVGA-PRMAP */
                    PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG + PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP;

                    /*" -1372- DISPLAY '@1 ' PROPOVA-NUM-CERTIFICADO '/' GE406-IND-SERV-CONSULTA '/1/' WS-PER-EDT-001 '/' WS-VLR-EDT-001 '*' WS-VLR-EDT-002 '/' WS-VLR-EDT-003 '*' WS-VLR-EDT-004 */

                    $"@1 {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA}/1/{WS_PER_EDT_001}/{WS_VLR_EDT_001}*{WS_VLR_EDT_002}/{WS_VLR_EDT_003}*{WS_VLR_EDT_004}"
                    .Display();

                    /*" -1373- END-IF */
                }


                /*" -1374- IF GE406-IND-RET-SUBSCRICAO EQUAL '2' */

                if (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO == "2")
                {

                    /*" -1375- MOVE GE406-PCT-AGRAVO TO WS-PER-EDT-001 */
                    _.Move(GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO, WS_PER_EDT_001);

                    /*" -1376- COMPUTE GE406-PCT-AGRAVO = GE406-PCT-AGRAVO / 100 */
                    GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO.Value = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO / 100f;

                    /*" -1377- COMPUTE W-PERC-AGRAVO = GE406-PCT-AGRAVO + 1 */
                    W_PERC_AGRAVO.Value = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO + 1;

                    /*" -1378- MOVE PLAVAVGA-PRMVG TO WS-VLR-EDT-001 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, WS_VLR_EDT_001);

                    /*" -1380- COMPUTE PLAVAVGA-PRMVG ROUNDED = PLAVAVGA-PRMVG * W-PERC-AGRAVO */
                    PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG * W_PERC_AGRAVO;

                    /*" -1381- MOVE PLAVAVGA-PRMVG TO WS-VLR-EDT-002 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, WS_VLR_EDT_002);

                    /*" -1382- MOVE PLAVAVGA-PRMAP TO WS-VLR-EDT-003 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, WS_VLR_EDT_003);

                    /*" -1384- COMPUTE PLAVAVGA-PRMAP ROUNDED = PLAVAVGA-PRMAP * W-PERC-AGRAVO */
                    PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP * W_PERC_AGRAVO;

                    /*" -1385- MOVE PLAVAVGA-PRMAP TO WS-VLR-EDT-004 */
                    _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, WS_VLR_EDT_004);

                    /*" -1387- COMPUTE PLAVAVGA-VLPREMIOTOT = PLAVAVGA-PRMVG + PLAVAVGA-PRMAP */
                    PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG + PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP;

                    /*" -1394- DISPLAY '@2 ' PROPOVA-NUM-CERTIFICADO '/' GE406-IND-SERV-CONSULTA '/2/' WS-PER-EDT-001 '/' WS-VLR-EDT-001 '*' WS-VLR-EDT-002 '/' WS-VLR-EDT-003 '*' WS-VLR-EDT-004 */

                    $"@2 {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA}/2/{WS_PER_EDT_001}/{WS_VLR_EDT_001}*{WS_VLR_EDT_002}/{WS_VLR_EDT_003}*{WS_VLR_EDT_004}"
                    .Display();

                    /*" -1395- END-IF */
                }


                /*" -1397- END-IF */
            }


            /*" -1397- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1407_99_SAIDA*/

        [StopWatch]
        /*" R1408-00-ATUALIZA-SUBSCRICAO-SECTION */
        private void R1408_00_ATUALIZA_SUBSCRICAO_SECTION()
        {
            /*" -1407- MOVE '1408' TO WNR-EXEC-SQL. */
            _.Move("1408", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1414- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1415- IF GE406-IND-RET-SUBSCRICAO EQUAL '1' */

            if (GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_RET_SUBSCRICAO == "1")
            {

                /*" -1416- MOVE GE406-PCT-AGRAVO TO WS-PER-EDT-001 */
                _.Move(GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO, WS_PER_EDT_001);

                /*" -1417- COMPUTE GE406-PCT-AGRAVO = GE406-PCT-AGRAVO / 100 */
                GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO.Value = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO / 100f;

                /*" -1418- COMPUTE W-PERC-AGRAVO = GE406-PCT-AGRAVO + 1 */
                W_PERC_AGRAVO.Value = GE406.DCLGE_RETENCAO_PROPOSTA.GE406_PCT_AGRAVO + 1;

                /*" -1419- MOVE PLAVAVGA-PRMVG TO WS-VLR-EDT-001 */
                _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, WS_VLR_EDT_001);

                /*" -1421- COMPUTE PLAVAVGA-PRMVG ROUNDED = PLAVAVGA-PRMVG * W-PERC-AGRAVO */
                PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG * W_PERC_AGRAVO;

                /*" -1422- MOVE PLAVAVGA-PRMVG TO WS-VLR-EDT-002 */
                _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG, WS_VLR_EDT_002);

                /*" -1423- MOVE PLAVAVGA-PRMAP TO WS-VLR-EDT-003 */
                _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, WS_VLR_EDT_003);

                /*" -1425- COMPUTE PLAVAVGA-PRMAP ROUNDED = PLAVAVGA-PRMAP * W-PERC-AGRAVO */
                PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP * W_PERC_AGRAVO;

                /*" -1426- MOVE PLAVAVGA-PRMAP TO WS-VLR-EDT-004 */
                _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP, WS_VLR_EDT_004);

                /*" -1428- COMPUTE PLAVAVGA-VLPREMIOTOT = PLAVAVGA-PRMVG + PLAVAVGA-PRMAP */
                PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG + PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP;

                /*" -1435- DISPLAY '> ' PROPOVA-NUM-CERTIFICADO '/' GE406-IND-SERV-CONSULTA '/1/' WS-PER-EDT-001 '/' WS-VLR-EDT-001 '*' WS-VLR-EDT-002 '/' WS-VLR-EDT-003 '*' WS-VLR-EDT-004 */

                $"> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}/{GE406.DCLGE_RETENCAO_PROPOSTA.GE406_IND_SERV_CONSULTA}/1/{WS_PER_EDT_001}/{WS_VLR_EDT_001}*{WS_VLR_EDT_002}/{WS_VLR_EDT_003}*{WS_VLR_EDT_004}"
                .Display();

                /*" -1437- END-IF */
            }


            /*" -1437- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1408_99_SAIDA*/

        [StopWatch]
        /*" R1410-00-VALIDA-PREMIO-SECTION */
        private void R1410_00_VALIDA_PREMIO_SECTION()
        {
            /*" -1446- MOVE '1410' TO WNR-EXEC-SQL. */
            _.Move("1410", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1452- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1453- IF PLAVAVGA-VLPREMIOTOT EQUAL ZEROS */

            if (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT == 00)
            {

                /*" -1454- IF PLAVAVGA-PCT-FAIXA-ETARIA EQUAL ZEROS */

                if (PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA == 00)
                {

                    /*" -1455- DISPLAY 'ERRO - PERC. CORRECAO DE FAIXA ETARIA ZERADO' */
                    _.Display($"ERRO - PERC. CORRECAO DE FAIXA ETARIA ZERADO");

                    /*" -1456- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1457- DISPLAY 'APOLICE       ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE       {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -1458- DISPLAY 'SUBGRUPO      ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"SUBGRUPO      {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -1459- DISPLAY 'OPCAO_COBER   ' HISCOBPR-OPCAO-COBERTURA */
                    _.Display($"OPCAO_COBER   {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OPCAO_COBERTURA}");

                    /*" -1460- DISPLAY 'IDADE         ' PROPOVA-IDADE */
                    _.Display($"IDADE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_IDADE}");

                    /*" -1461- DISPLAY 'PERIPGTO      ' PRODUVG-PERI-PAGAMENTO */
                    _.Display($"PERIPGTO      {PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO}");

                    /*" -1462- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1463- ELSE */
                }
                else
                {


                    /*" -1466- COMPUTE PLAVAVGA-PCT-FAIXA-ETARIA = PLAVAVGA-PCT-FAIXA-ETARIA / 100 */
                    PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA / 100f;

                    /*" -1469- COMPUTE W-PERC-FX-ETARIA = PLAVAVGA-PCT-FAIXA-ETARIA + 1 */
                    W_PERC_FX_ETARIA.Value = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PCT_FAIXA_ETARIA + 1;

                    /*" -1471- COMPUTE COBERP-PRMVG-ATU ROUNDED = (HISCOBPR-PRMVG * W-PERC-FX-ETARIA) / 12 */
                    COBERP_PRMVG_ATU.Value = (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMVG * W_PERC_FX_ETARIA) / 12f;

                    /*" -1474- COMPUTE COBERP-PRMAP-ATU ROUNDED = (HISCOBPR-PRMAP * W-PERC-FX-ETARIA) / 12 */
                    COBERP_PRMAP_ATU.Value = (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_PRMAP * W_PERC_FX_ETARIA) / 12f;

                    /*" -1477- COMPUTE COBERP-VLPREMIO-ATU = COBERP-PRMVG-ATU + COBERP-PRMAP-ATU */
                    COBERP_VLPREMIO_ATU.Value = COBERP_PRMVG_ATU + COBERP_PRMAP_ATU;

                    /*" -1478- MOVE COBERP-VLPREMIO-ATU TO PLAVAVGA-VLPREMIOTOT */
                    _.Move(COBERP_VLPREMIO_ATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT);

                    /*" -1479- MOVE COBERP-PRMVG-ATU TO PLAVAVGA-PRMVG */
                    _.Move(COBERP_PRMVG_ATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG);

                    /*" -1481- MOVE COBERP-PRMAP-ATU TO PLAVAVGA-PRMAP */
                    _.Move(COBERP_PRMAP_ATU, PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP);

                    /*" -1482- END-IF */
                }


                /*" -1482- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1410_99_SAIDA*/

        [StopWatch]
        /*" R1450-00-SELECT-OPCPAGVI-SECTION */
        private void R1450_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -1492- MOVE '1450' TO WNR-EXEC-SQL. */
            _.Move("1450", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1494- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1496- MOVE 'S' TO WS-TEM-OPCPAGVI. */
            _.Move("S", WS_TEM_OPCPAGVI);

            /*" -1517- PERFORM R1450_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1450_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -1520- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1521- DISPLAY 'ERRO NO SELECT OPCAO_PAG_VIDAZUL' */
                _.Display($"ERRO NO SELECT OPCAO_PAG_VIDAZUL");

                /*" -1522- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1523- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1525- END-IF. */
            }


            /*" -1526- IF VIND-AGEDEB LESS +0 */

            if (VIND_AGEDEB < +0)
            {

                /*" -1531- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO OPCPAGVI-OPE-CONTA-DEBITO OPCPAGVI-NUM-CONTA-DEBITO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -1533- END-IF. */
            }


            /*" -1535- IF VIND-NUMCAR LESS +0 OR OPCPAGVI-NUM-CARTAO-CREDITO NOT NUMERIC */

            if (VIND_NUMCAR < +0 || !OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.IsNumeric())
            {

                /*" -1537- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -1539- END-IF. */
            }


            /*" -1540- IF OPCPAGVI-PERI-PAGAMENTO NOT EQUAL 12 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO != 12)
            {

                /*" -1541- MOVE 'N' TO WS-TEM-OPCPAGVI */
                _.Move("N", WS_TEM_OPCPAGVI);

                /*" -1541- END-IF. */
            }


        }

        [StopWatch]
        /*" R1450-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R1450_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -1517- EXEC SQL SELECT OPCAO_PAGAMENTO ,VALUE(COD_AGENCIA_DEBITO,0) ,VALUE(OPE_CONTA_DEBITO,0) ,VALUE(NUM_CONTA_DEBITO,0) ,VALUE(DIG_CONTA_DEBITO,0) ,NUM_CARTAO_CREDITO ,PERI_PAGAMENTO INTO :OPCPAGVI-OPCAO-PAGAMENTO, :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGEDEB, :OPCPAGVI-OPE-CONTA-DEBITO :VIND-OPEDEB, :OPCPAGVI-NUM-CONTA-DEBITO :VIND-CTADEB, :OPCPAGVI-DIG-CONTA-DEBITO :VIND-DIGDEB, :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUMCAR, :OPCPAGVI-PERI-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' WITH UR END-EXEC. */

            var r1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r1450_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGEDEB, VIND_AGEDEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPEDEB, VIND_OPEDEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_CTADEB, VIND_CTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGDEB, VIND_DIGDEB);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_NUMCAR, VIND_NUMCAR);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1450_99_SAIDA*/

        [StopWatch]
        /*" R1460-00-SELECT-OPCPAGVI-SECTION */
        private void R1460_00_SELECT_OPCPAGVI_SECTION()
        {
            /*" -1551- MOVE '1460' TO WNR-EXEC-SQL. */
            _.Move("1460", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1552- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1554- MOVE 'N' TO WS-TEM-OPCPAGVI. */
            _.Move("N", WS_TEM_OPCPAGVI);

            /*" -1561- PERFORM R1460_00_SELECT_OPCPAGVI_DB_SELECT_1 */

            R1460_00_SELECT_OPCPAGVI_DB_SELECT_1();

            /*" -1564- DISPLAY 'NUM_CERTIFICADO.....' PROPOVA-NUM-CERTIFICADO */
            _.Display($"NUM_CERTIFICADO.....{PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

            /*" -1565- DISPLAY 'DATA_INIVIGENCIA....' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA_INIVIGENCIA....{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -1567- DISPLAY 'SQLCODE.....' SQLCODE */
            _.Display($"SQLCODE.....{DB.SQLCODE}");

            /*" -1568- IF SQLCODE EQUAL ZERO */

            if (DB.SQLCODE == 00)
            {

                /*" -1569- MOVE 'S' TO WS-TEM-OPCPAGVI */
                _.Move("S", WS_TEM_OPCPAGVI);

                /*" -1570- ELSE */
            }
            else
            {


                /*" -1571- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1572- CONTINUE */

                    /*" -1573- ELSE */
                }
                else
                {


                    /*" -1574- DISPLAY 'ERRO NO SELECT OPCAO_PAG_VIDAZUL 2' */
                    _.Display($"ERRO NO SELECT OPCAO_PAG_VIDAZUL 2");

                    /*" -1575- DISPLAY 'CERTIFICADO: ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO: {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1576- DISPLAY 'INIVIGENCIA: ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"INIVIGENCIA: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -1577- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1577- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R1460-00-SELECT-OPCPAGVI-DB-SELECT-1 */
        public void R1460_00_SELECT_OPCPAGVI_DB_SELECT_1()
        {
            /*" -1561- EXEC SQL SELECT OPCAO_PAGAMENTO INTO :OPCPAGVI-OPCAO-PAGAMENTO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_INIVIGENCIA = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */

            var r1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1 = new R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1.Execute(r1460_00_SELECT_OPCPAGVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1460_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-INSERT-OPCPAGVI-SECTION */
        private void R1500_00_INSERT_OPCPAGVI_SECTION()
        {
            /*" -1587- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1591- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1597- IF (OPCPAGVI-OPCAO-PAGAMENTO EQUAL 3) AND (OPCPAGVI-COD-AGENCIA-DEBITO NOT EQUAL 0) AND (OPCPAGVI-OPE-CONTA-DEBITO NOT EQUAL 0) AND (OPCPAGVI-NUM-CONTA-DEBITO NOT EQUAL 0) AND (OPCPAGVI-DIG-CONTA-DEBITO NOT EQUAL 0) */

            if ((OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 3) && (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO != 0) && (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO != 0) && (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO != 0) && (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO != 0))
            {

                /*" -1598- IF OPCPAGVI-OPE-CONTA-DEBITO EQUAL 01 */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO == 01)
                {

                    /*" -1599- MOVE '1' TO OPCPAGVI-OPCAO-PAGAMENTO */
                    _.Move("1", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                    /*" -1601- END-IF */
                }


                /*" -1602- IF OPCPAGVI-OPE-CONTA-DEBITO EQUAL 13 */

                if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO == 13)
                {

                    /*" -1603- MOVE '2' TO OPCPAGVI-OPCAO-PAGAMENTO */
                    _.Move("2", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                    /*" -1604- END-IF */
                }


                /*" -1606- END-IF. */
            }


            /*" -1623- PERFORM R1500_00_INSERT_OPCPAGVI_DB_INSERT_1 */

            R1500_00_INSERT_OPCPAGVI_DB_INSERT_1();

            /*" -1626- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1627- DISPLAY 'ERRO NO INSERT OPCAO_PAG_VIDAZUL' */
                _.Display($"ERRO NO INSERT OPCAO_PAG_VIDAZUL");

                /*" -1628- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1629- DISPLAY 'INIVIGENCIA-> ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"INIVIGENCIA-> {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -1630- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1630- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-INSERT-OPCPAGVI-DB-INSERT-1 */
        public void R1500_00_INSERT_OPCPAGVI_DB_INSERT_1()
        {
            /*" -1623- EXEC SQL INSERT INTO SEGUROS.OPCAO_PAG_VIDAZUL SELECT NUM_CERTIFICADO, :SISTEMAS-DATA-MOV-ABERTO AS DATA_INIVIGENCIA, '9998-12-31' AS DATA_TERVIGENCIA, :OPCPAGVI-OPCAO-PAGAMENTO, :PRODUVG-PERI-PAGAMENTO AS PERI_PAGAMENTO, DIA_DEBITO AS DIA_DEBITO, 'VA0123B' COD_USUARIO, CURRENT TIMESTAMP, COD_AGENCIA_DEBITO, OPE_CONTA_DEBITO, NUM_CONTA_DEBITO, DIG_CONTA_DEBITO, NUM_CARTAO_CREDITO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1 = new R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                OPCPAGVI_OPCAO_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1.Execute(r1500_00_INSERT_OPCPAGVI_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-UPDATE-OPCPAGVI-SECTION */
        private void R1510_00_UPDATE_OPCPAGVI_SECTION()
        {
            /*" -1640- MOVE '1510' TO WNR-EXEC-SQL. */
            _.Move("1510", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1642- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1647- PERFORM R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1 */

            R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1();

            /*" -1650- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1651- DISPLAY 'ERRO NO UPDATE OPCAO_PAG_VIDAZUL 1' */
                _.Display($"ERRO NO UPDATE OPCAO_PAG_VIDAZUL 1");

                /*" -1652- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1653- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1655- END-IF. */
            }


            /*" -1656- MOVE '1511' TO WNR-EXEC-SQL. */
            _.Move("1511", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1658- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1663- PERFORM R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2 */

            R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2();

            /*" -1666- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1667- DISPLAY 'ERRO NO UPDATE OPCAO_PAG_VIDAZUL 2' */
                _.Display($"ERRO NO UPDATE OPCAO_PAG_VIDAZUL 2");

                /*" -1668- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1669- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1669- END-IF. */
            }


        }

        [StopWatch]
        /*" R1510-00-UPDATE-OPCPAGVI-DB-UPDATE-1 */
        public void R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1()
        {
            /*" -1647- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET DATA_TERVIGENCIA = :SISTEMAS-DATA-MOV-ABERTO-01 WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1 = new R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO_01 = SISTEMAS_DATA_MOV_ABERTO_01.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1.Execute(r1510_00_UPDATE_OPCPAGVI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1510_99_SAIDA*/

        [StopWatch]
        /*" R1510-00-UPDATE-OPCPAGVI-DB-UPDATE-2 */
        public void R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2()
        {
            /*" -1663- EXEC SQL UPDATE SEGUROS.OPCAO_PAG_VIDAZUL SET DATA_TERVIGENCIA = '9999-12-31' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9998-12-31' END-EXEC. */

            var r1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1 = new R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1.Execute(r1510_00_UPDATE_OPCPAGVI_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1600-00-INSERT-HISCOBPR-SECTION */
        private void R1600_00_INSERT_HISCOBPR_SECTION()
        {
            /*" -1679- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1681- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1748- PERFORM R1600_00_INSERT_HISCOBPR_DB_INSERT_1 */

            R1600_00_INSERT_HISCOBPR_DB_INSERT_1();

            /*" -1751- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1752- DISPLAY 'ERRO NO INSERT HIS_COBER_PROPOST' */
                _.Display($"ERRO NO INSERT HIS_COBER_PROPOST");

                /*" -1753- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1754- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1754- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-INSERT-HISCOBPR-DB-INSERT-1 */
        public void R1600_00_INSERT_HISCOBPR_DB_INSERT_1()
        {
            /*" -1748- EXEC SQL INSERT INTO SEGUROS.HIS_COBER_PROPOST (NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMPSEGUR , QUANT_VIDAS , IMPSEGIND , COD_OPERACAO , OPCAO_COBERTURA , IMP_MORNATU , IMPMORACID , IMPINVPERM , IMPAMDS , IMPDH , IMPDIT , VLPREMIO , PRMVG , PRMAP , QTDE_TIT_CAPITALIZ, VAL_TIT_CAPITALIZ , VAL_CUSTO_CAPITALI, IMPSEGCDG , VLCUSTCDG , COD_USUARIO , TIMESTAMP , IMPSEGAUXF , VLCUSTAUXF , PRMDIT , QTMDIT) SELECT NUM_CERTIFICADO, :PROPOVA-OCORR-HISTORICO1 OCORR_HISTORICO, :SISTEMAS-DATA-MOV-ABERTO DATA_INIVIGENCIA, '9998-12-31' DATA_TERVIGENCIA, IMPSEGUR, QUANT_VIDAS, IMPSEGIND, COD_OPERACAO, OPCAO_COBERTURA, IMP_MORNATU, IMPMORACID, IMPINVPERM, IMPAMDS, IMPDH, IMPDIT, :PLAVAVGA-VLPREMIOTOT VLPREMIO, :PLAVAVGA-PRMVG PRMVG, :PLAVAVGA-PRMAP PRMAP, :PLAVAVGA-QTTITCAP QTDE_TIT_CAPITALIZ, :PLAVAVGA-VLTITCAP VAL_TIT_CAPITALIZ, :PLAVAVGA-VLCUSTCAP VAL_CUSTO_CAPITALI, IMPSEGCDG, VLCUSTCDG, 'VA0123B' COD_USUARIO, CURRENT TIMESTAMP, IMPSEGAUXF, VLCUSTAUXF, PRMDIT, QTMDIT FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1 = new R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1()
            {
                PROPOVA_OCORR_HISTORICO1 = PROPOVA_OCORR_HISTORICO1.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                PLAVAVGA_VLPREMIOTOT = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.ToString(),
                PLAVAVGA_PRMVG = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG.ToString(),
                PLAVAVGA_PRMAP = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP.ToString(),
                PLAVAVGA_QTTITCAP = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_QTTITCAP.ToString(),
                PLAVAVGA_VLTITCAP = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLTITCAP.ToString(),
                PLAVAVGA_VLCUSTCAP = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLCUSTCAP.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1.Execute(r1600_00_INSERT_HISCOBPR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-UPDATE-HISCOBPR-SECTION */
        private void R1610_00_UPDATE_HISCOBPR_SECTION()
        {
            /*" -1764- MOVE '1610' TO WNR-EXEC-SQL. */
            _.Move("1610", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1766- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1771- PERFORM R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1 */

            R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1();

            /*" -1774- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1775- DISPLAY 'ERRO NO UPDATE HIS_COBER_PROPOST 1' */
                _.Display($"ERRO NO UPDATE HIS_COBER_PROPOST 1");

                /*" -1776- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1777- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1779- END-IF. */
            }


            /*" -1780- MOVE '1611' TO WNR-EXEC-SQL. */
            _.Move("1611", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1782- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1787- PERFORM R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2 */

            R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2();

            /*" -1790- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1791- DISPLAY 'ERRO NO UPDATE HIS_COBER_PROPOST 2' */
                _.Display($"ERRO NO UPDATE HIS_COBER_PROPOST 2");

                /*" -1792- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1793- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1793- END-IF. */
            }


        }

        [StopWatch]
        /*" R1610-00-UPDATE-HISCOBPR-DB-UPDATE-1 */
        public void R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1()
        {
            /*" -1771- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = :SISTEMAS-DATA-MOV-ABERTO-01 WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1 = new R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO_01 = SISTEMAS_DATA_MOV_ABERTO_01.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1.Execute(r1610_00_UPDATE_HISCOBPR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1610_99_SAIDA*/

        [StopWatch]
        /*" R1610-00-UPDATE-HISCOBPR-DB-UPDATE-2 */
        public void R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2()
        {
            /*" -1787- EXEC SQL UPDATE SEGUROS.HIS_COBER_PROPOST SET DATA_TERVIGENCIA = '9999-12-31' WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9998-12-31' END-EXEC. */

            var r1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1 = new R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1.Execute(r1610_00_UPDATE_HISCOBPR_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1615-00-MAX-PARCEVID-SECTION */
        private void R1615_00_MAX_PARCEVID_SECTION()
        {
            /*" -1803- MOVE '1615' TO WNR-EXEC-SQL. */
            _.Move("1615", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1805- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1810- PERFORM R1615_00_MAX_PARCEVID_DB_SELECT_1 */

            R1615_00_MAX_PARCEVID_DB_SELECT_1();

            /*" -1813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1814- DISPLAY 'VA0123B - ERRO SELECT MAX PARCEVID' */
                _.Display($"VA0123B - ERRO SELECT MAX PARCEVID");

                /*" -1816- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1817- IF PARCEVID-NUM-PARCELA EQUAL ZEROS */

            if (PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA == 00)
            {

                /*" -1818- MOVE 1 TO PARCEVID-NUM-PARCELA */
                _.Move(1, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);

                /*" -1820- END-IF. */
            }


            /*" -1822- MOVE PARCEVID-NUM-PARCELA TO PARCEVID-NUM-PARCELA1. */
            _.Move(PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA, PARCEVID_NUM_PARCELA1);

            /*" -1822- ADD 1 TO PARCEVID-NUM-PARCELA1. */
            PARCEVID_NUM_PARCELA1.Value = PARCEVID_NUM_PARCELA1 + 1;

        }

        [StopWatch]
        /*" R1615-00-MAX-PARCEVID-DB-SELECT-1 */
        public void R1615_00_MAX_PARCEVID_DB_SELECT_1()
        {
            /*" -1810- EXEC SQL SELECT VALUE(MAX(NUM_PARCELA),0) INTO :PARCEVID-NUM-PARCELA FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1615_00_MAX_PARCEVID_DB_SELECT_1_Query1 = new R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R1615_00_MAX_PARCEVID_DB_SELECT_1_Query1.Execute(r1615_00_MAX_PARCEVID_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCEVID_NUM_PARCELA, PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1615_99_SAIDA*/

        [StopWatch]
        /*" R1620-00-INSERT-PARCEVID-SECTION */
        private void R1620_00_INSERT_PARCEVID_SECTION()
        {
            /*" -1832- MOVE '1620' TO WNR-EXEC-SQL. */
            _.Move("1620", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1834- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1836- PERFORM R1615-00-MAX-PARCEVID. */

            R1615_00_MAX_PARCEVID_SECTION();

            /*" -1854- PERFORM R1620_00_INSERT_PARCEVID_DB_INSERT_1 */

            R1620_00_INSERT_PARCEVID_DB_INSERT_1();

            /*" -1857- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1858- DISPLAY 'ERRO NO INSERT PARCELAS_VIDAZUL ' */
                _.Display($"ERRO NO INSERT PARCELAS_VIDAZUL ");

                /*" -1859- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -1860- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1860- END-IF. */
            }


        }

        [StopWatch]
        /*" R1620-00-INSERT-PARCEVID-DB-INSERT-1 */
        public void R1620_00_INSERT_PARCEVID_DB_INSERT_1()
        {
            /*" -1854- EXEC SQL INSERT INTO SEGUROS.PARCELAS_VIDAZUL SELECT NUM_CERTIFICADO , :PARCEVID-NUM-PARCELA1 NUM_PARCELA , :PROPOVA-DTPROXVEN DATA_VENCIMENTO, :PLAVAVGA-PRMVG PREMIO_VG, :PLAVAVGA-PRMAP PREMIO_AP, VLMULTA , :OPCPAGVI-OPCAO-PAGAMENTO OPCAO_PAGAMENTO, ' ' SIT_REGISTRO, 1 OCORR_HISTORICO, CURRENT TIMESTAMP FROM SEGUROS.PARCELAS_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA END-EXEC. */

            var r1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1 = new R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1()
            {
                PARCEVID_NUM_PARCELA1 = PARCEVID_NUM_PARCELA1.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PLAVAVGA_PRMVG = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMVG.ToString(),
                PLAVAVGA_PRMAP = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_PRMAP.ToString(),
                OPCPAGVI_OPCAO_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            R1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1.Execute(r1620_00_INSERT_PARCEVID_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1620_99_SAIDA*/

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-SECTION */
        private void R1630_00_INSERT_COBHISVI_SECTION()
        {
            /*" -1870- MOVE '1630' TO WNR-EXEC-SQL. */
            _.Move("1630", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1872- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -1875- DISPLAY 'OPCPAGVI-OPCAO-PAGAMENTO = ' OPCPAGVI-OPCAO-PAGAMENTO */
            _.Display($"OPCPAGVI-OPCAO-PAGAMENTO = {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO}");

            /*" -1877- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' OR '5' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2", "5"))
            {

                /*" -1879- MOVE '0' TO COBHISVI-SIT-REGISTRO */
                _.Move("0", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                /*" -1883- PERFORM R1630_00_INSERT_COBHISVI_DB_UPDATE_1 */

                R1630_00_INSERT_COBHISVI_DB_UPDATE_1();

                /*" -1886- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1887- DISPLAY 'ERRO NO UPDATE CEDENTE            ' */
                    _.Display($"ERRO NO UPDATE CEDENTE            ");

                    /*" -1888- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1889- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1891- END-IF */
                }


                /*" -1892- MOVE '1631' TO WNR-EXEC-SQL */
                _.Move("1631", AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -1894- DISPLAY WNR-EXEC-SQL */
                _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -1900- PERFORM R1630_00_INSERT_COBHISVI_DB_SELECT_1 */

                R1630_00_INSERT_COBHISVI_DB_SELECT_1();

                /*" -1903- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1904- DISPLAY 'ERRO NO SELECT CEDENTE            ' */
                    _.Display($"ERRO NO SELECT CEDENTE            ");

                    /*" -1905- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1906- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1907- END-IF */
                }


                /*" -1908- MOVE CEDENTE-NUM-TITULO TO WHOST-NRTITULO */
                _.Move(CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO, WHOST_NRTITULO);

                /*" -1910- ELSE */
            }
            else
            {


                /*" -1912- MOVE '5' TO COBHISVI-SIT-REGISTRO */
                _.Move("5", COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO);

                /*" -1913- MOVE '1632' TO WNR-EXEC-SQL */
                _.Move("1632", AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -1915- DISPLAY WNR-EXEC-SQL */
                _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -1921- PERFORM R1630_00_INSERT_COBHISVI_DB_SELECT_2 */

                R1630_00_INSERT_COBHISVI_DB_SELECT_2();

                /*" -1924- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1925- DISPLAY 'ERRO NO SELECT BANCOS             ' */
                    _.Display($"ERRO NO SELECT BANCOS             ");

                    /*" -1926- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1927- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1929- END-IF */
                }


                /*" -1932- DISPLAY 'NUM-TITULO LIDO = ' BANCOS-NUM-TITULO */
                _.Display($"NUM-TITULO LIDO = {BANCOS.DCLBANCOS.BANCOS_NUM_TITULO}");

                /*" -1933- MOVE BANCOS-NUM-TITULO TO W-NUMR-TITULO */
                _.Move(BANCOS.DCLBANCOS.BANCOS_NUM_TITULO, W_NUMR_TITULO);

                /*" -1934- ADD 1 TO WTITL-SEQUENCIA */
                FILLER_0.WTITL_SEQUENCIA.Value = FILLER_0.WTITL_SEQUENCIA + 1;

                /*" -1936- MOVE WTITL-SEQUENCIA TO DPARM01 */
                _.Move(FILLER_0.WTITL_SEQUENCIA, DPARM01X.DPARM01);

                /*" -1938- CALL 'PROTIT01' USING DPARM01X */
                _.Call("PROTIT01", DPARM01X);

                /*" -1939- IF DPARM01-RC NOT EQUAL +0 */

                if (DPARM01X.DPARM01_RC != +0)
                {

                    /*" -1940- DISPLAY 'ERRO CHAMADA PROTIT01' */
                    _.Display($"ERRO CHAMADA PROTIT01");

                    /*" -1941- DISPLAY 'CERTIFICADO     ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO     {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1942- DISPLAY 'AREA            ' DPARM01X */
                    _.Display($"AREA            {DPARM01X}");

                    /*" -1943- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1945- END-IF */
                }


                /*" -1947- MOVE DPARM01-D1 TO WTITL-DIGITO */
                _.Move(DPARM01X.DPARM01_D1, FILLER_0.WTITL_DIGITO);

                /*" -1949- MOVE W-NUMR-TITULO TO BANCOS-NUM-TITULO */
                _.Move(W_NUMR_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);

                /*" -1951- MOVE W-NUMR-TITULO TO WHOST-NRTITULO */
                _.Move(W_NUMR_TITULO, WHOST_NRTITULO);

                /*" -1952- MOVE '1633' TO WNR-EXEC-SQL */
                _.Move("1633", AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -1954- DISPLAY WNR-EXEC-SQL */
                _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -1956- DISPLAY 'NUM-TITULO NOVO = ' BANCOS-NUM-TITULO */
                _.Display($"NUM-TITULO NOVO = {BANCOS.DCLBANCOS.BANCOS_NUM_TITULO}");

                /*" -1960- PERFORM R1630_00_INSERT_COBHISVI_DB_UPDATE_2 */

                R1630_00_INSERT_COBHISVI_DB_UPDATE_2();

                /*" -1963- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -1964- DISPLAY 'ERRO NO UPDATE BANCOS             ' */
                    _.Display($"ERRO NO UPDATE BANCOS             ");

                    /*" -1965- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -1966- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1968- END-IF */
                }


                /*" -1973- END-IF. */
            }


            /*" -1980- PERFORM R1630_00_INSERT_COBHISVI_DB_SELECT_3 */

            R1630_00_INSERT_COBHISVI_DB_SELECT_3();

            /*" -1983- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1984- DISPLAY 'ERRO SELECT COBER_HIST_VIDAZUL' */
                _.Display($"ERRO SELECT COBER_HIST_VIDAZUL");

                /*" -1985- DISPLAY 'NUM_TITULO...... ' WHOST-NRTITULO */
                _.Display($"NUM_TITULO...... {WHOST_NRTITULO}");

                /*" -1986- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1988- END-IF. */
            }


            /*" -1989- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1990- DISPLAY 'TITULO JA EXISTE ' WHOST-NRTITULO */
                _.Display($"TITULO JA EXISTE {WHOST_NRTITULO}");

                /*" -1991- DISPLAY 'CERTIFICADO..... ' WS-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO..... {WS_NUM_CERTIFICADO}");

                /*" -1992- DISPLAY 'PARCELA......... ' WS-NUM-PARCELA */
                _.Display($"PARCELA......... {WS_NUM_PARCELA}");

                /*" -1993- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1995- END-IF. */
            }


            /*" -2015- PERFORM R1630_00_INSERT_COBHISVI_DB_INSERT_1 */

            R1630_00_INSERT_COBHISVI_DB_INSERT_1();

            /*" -2018- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2019- DISPLAY 'ERRO NO INSERT COBER_HIST_VIDAZUL ' */
                _.Display($"ERRO NO INSERT COBER_HIST_VIDAZUL ");

                /*" -2020- DISPLAY 'CERTIFICADO    = ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO    = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2021- DISPLAY 'NUM-PARCELA    = ' PARCEVID-NUM-PARCELA */
                _.Display($"NUM-PARCELA    = {PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA}");

                /*" -2022- DISPLAY 'NUM-PARCELA1   = ' PARCEVID-NUM-PARCELA1 */
                _.Display($"NUM-PARCELA1   = {PARCEVID_NUM_PARCELA1}");

                /*" -2023- DISPLAY 'WHOST-NRTITULO = ' WHOST-NRTITULO */
                _.Display($"WHOST-NRTITULO = {WHOST_NRTITULO}");

                /*" -2024- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2024- END-IF. */
            }


        }

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-DB-UPDATE-1 */
        public void R1630_00_INSERT_COBHISVI_DB_UPDATE_1()
        {
            /*" -1883- EXEC SQL UPDATE SEGUROS.CEDENTE SET NUM_TITULO = NUM_TITULO + 1 WHERE COD_CEDENTE = 36 END-EXEC */

            var r1630_00_INSERT_COBHISVI_DB_UPDATE_1_Update1 = new R1630_00_INSERT_COBHISVI_DB_UPDATE_1_Update1()
            {
            };

            R1630_00_INSERT_COBHISVI_DB_UPDATE_1_Update1.Execute(r1630_00_INSERT_COBHISVI_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-DB-SELECT-1 */
        public void R1630_00_INSERT_COBHISVI_DB_SELECT_1()
        {
            /*" -1900- EXEC SQL SELECT NUM_TITULO INTO :CEDENTE-NUM-TITULO FROM SEGUROS.CEDENTE WHERE COD_CEDENTE = 36 WITH UR END-EXEC */

            var r1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1 = new R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1.Execute(r1630_00_INSERT_COBHISVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEDENTE_NUM_TITULO, CEDENTE.DCLCEDENTE.CEDENTE_NUM_TITULO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1630_99_SAIDA*/

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-DB-SELECT-2 */
        public void R1630_00_INSERT_COBHISVI_DB_SELECT_2()
        {
            /*" -1921- EXEC SQL SELECT NUM_TITULO INTO :BANCOS-NUM-TITULO FROM SEGUROS.BANCOS WHERE COD_BANCO = 104 WITH UR END-EXEC */

            var r1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1 = new R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1.Execute(r1630_00_INSERT_COBHISVI_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BANCOS_NUM_TITULO, BANCOS.DCLBANCOS.BANCOS_NUM_TITULO);
            }


        }

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-DB-UPDATE-2 */
        public void R1630_00_INSERT_COBHISVI_DB_UPDATE_2()
        {
            /*" -1960- EXEC SQL UPDATE SEGUROS.BANCOS SET NUM_TITULO = :BANCOS-NUM-TITULO WHERE COD_BANCO = 104 END-EXEC */

            var r1630_00_INSERT_COBHISVI_DB_UPDATE_2_Update1 = new R1630_00_INSERT_COBHISVI_DB_UPDATE_2_Update1()
            {
                BANCOS_NUM_TITULO = BANCOS.DCLBANCOS.BANCOS_NUM_TITULO.ToString(),
            };

            R1630_00_INSERT_COBHISVI_DB_UPDATE_2_Update1.Execute(r1630_00_INSERT_COBHISVI_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-DB-INSERT-1 */
        public void R1630_00_INSERT_COBHISVI_DB_INSERT_1()
        {
            /*" -2015- EXEC SQL INSERT INTO SEGUROS.COBER_HIST_VIDAZUL SELECT NUM_CERTIFICADO , :PARCEVID-NUM-PARCELA1 NUM_PARCELA , :WHOST-NRTITULO NUM_TITULO , :PROPOVA-DTPROXVEN DATA_VENCIMENTO , :PLAVAVGA-VLPREMIOTOT PRM_TOTAL , :OPCPAGVI-OPCAO-PAGAMENTO OPCAO_PAGAMENTO , :COBHISVI-SIT-REGISTRO SIT_REGISTRO , 0 COD_OPERACAO , 0 OCORR_HISTORICO , 0 COD_DEVOLUCAO , 0 BCO_AVISO , 0 AGE_AVISO , 0 NUM_AVISO_CREDITO , 0 NUM_TITULO_COMP FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_PARCELA = :PARCEVID-NUM-PARCELA END-EXEC. */

            var r1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1 = new R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1()
            {
                PARCEVID_NUM_PARCELA1 = PARCEVID_NUM_PARCELA1.ToString(),
                WHOST_NRTITULO = WHOST_NRTITULO.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PLAVAVGA_VLPREMIOTOT = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.ToString(),
                OPCPAGVI_OPCAO_PAGAMENTO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.ToString(),
                COBHISVI_SIT_REGISTRO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_SIT_REGISTRO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA = PARCEVID.DCLPARCELAS_VIDAZUL.PARCEVID_NUM_PARCELA.ToString(),
            };

            R1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1.Execute(r1630_00_INSERT_COBHISVI_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1640-00-INSERT-HISLANCT-SECTION */
        private void R1640_00_INSERT_HISLANCT_SECTION()
        {
            /*" -2034- MOVE '1640' TO WNR-EXEC-SQL. */
            _.Move("1640", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2036- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2045- PERFORM R1640_00_INSERT_HISLANCT_DB_SELECT_1 */

            R1640_00_INSERT_HISLANCT_DB_SELECT_1();

            /*" -2048- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2049- DISPLAY 'ERRO NO SELECT CONVENIOS_VG       ' */
                _.Display($"ERRO NO SELECT CONVENIOS_VG       ");

                /*" -2050- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2051- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2052- END-IF. */
            }


            /*" -2053- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL '1' OR '2' */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2055- MOVE CONVEVG-COD-SEGURO TO WHOST-COD-CONVENIO */
                _.Move(CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO, WHOST_COD_CONVENIO);

                /*" -2056- ELSE */
            }
            else
            {


                /*" -2058- MOVE CONVEVG-COD-CONV-CARTAO TO WHOST-COD-CONVENIO */
                _.Move(CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO, WHOST_COD_CONVENIO);

                /*" -2060- END-IF. */
            }


            /*" -2061- MOVE '1641' TO WNR-EXEC-SQL. */
            _.Move("1641", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2063- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2107- PERFORM R1640_00_INSERT_HISLANCT_DB_INSERT_1 */

            R1640_00_INSERT_HISLANCT_DB_INSERT_1();

            /*" -2110- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2111- DISPLAY 'ERRO NO INSERT V0HISTCONTAVA ' */
                _.Display($"ERRO NO INSERT V0HISTCONTAVA ");

                /*" -2112- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2113- DISPLAY 'PARCELA-----> ' PARCEVID-NUM-PARCELA1 */
                _.Display($"PARCELA-----> {PARCEVID_NUM_PARCELA1}");

                /*" -2114- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2114- END-IF. */
            }


        }

        [StopWatch]
        /*" R1640-00-INSERT-HISLANCT-DB-SELECT-1 */
        public void R1640_00_INSERT_HISLANCT_DB_SELECT_1()
        {
            /*" -2045- EXEC SQL SELECT COD_SEGURO, COD_CONV_CARTAO INTO :CONVEVG-COD-SEGURO, :CONVEVG-COD-CONV-CARTAO FROM SEGUROS.CONVENIOS_VG WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND CODSUBES = :PROPOVA-COD-SUBGRUPO WITH UR END-EXEC. */

            var r1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1 = new R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1()
            {
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1.Execute(r1640_00_INSERT_HISLANCT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONVEVG_COD_SEGURO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_SEGURO);
                _.Move(executed_1.CONVEVG_COD_CONV_CARTAO, CONVEVG.DCLCONVENIOS_VG.CONVEVG_COD_CONV_CARTAO);
            }


        }

        [StopWatch]
        /*" R1640-00-INSERT-HISLANCT-DB-INSERT-1 */
        public void R1640_00_INSERT_HISLANCT_DB_INSERT_1()
        {
            /*" -2107- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTAVA (NRCERTIF , NRPARCEL , OCORRHISTCTA , AGECTADEB , OPRCTADEB , NUMCTADEB , DIGCTADEB , DTVENCTO , VLPRMTOT , SITUACAO , TIPLANC , TIMESTAMP , OCORHIST , CODCONV , NSAS , NSL , NSAC , CODRET , CODUSU , NUM_CARTAO_CREDITO) VALUES (:PROPOVA-NUM-CERTIFICADO, :PARCEVID-NUM-PARCELA1, 1, :OPCPAGVI-COD-AGENCIA-DEBITO, :OPCPAGVI-OPE-CONTA-DEBITO, :OPCPAGVI-NUM-CONTA-DEBITO, :OPCPAGVI-DIG-CONTA-DEBITO, :PROPOVA-DTPROXVEN , :PLAVAVGA-VLPREMIOTOT, '0' , '1' , CURRENT TIMESTAMP, 0, :WHOST-COD-CONVENIO, NULL, NULL, NULL, NULL, 'VA0123B' , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-NUMCAR) END-EXEC. */

            var r1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1 = new R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PARCEVID_NUM_PARCELA1 = PARCEVID_NUM_PARCELA1.ToString(),
                OPCPAGVI_COD_AGENCIA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO.ToString(),
                OPCPAGVI_OPE_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO.ToString(),
                OPCPAGVI_NUM_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO.ToString(),
                OPCPAGVI_DIG_CONTA_DEBITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO.ToString(),
                PROPOVA_DTPROXVEN = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN.ToString(),
                PLAVAVGA_VLPREMIOTOT = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.ToString(),
                WHOST_COD_CONVENIO = WHOST_COD_CONVENIO.ToString(),
                OPCPAGVI_NUM_CARTAO_CREDITO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.ToString(),
                VIND_NUMCAR = VIND_NUMCAR.ToString(),
            };

            R1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1.Execute(r1640_00_INSERT_HISLANCT_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R1630-00-INSERT-COBHISVI-DB-SELECT-3 */
        public void R1630_00_INSERT_COBHISVI_DB_SELECT_3()
        {
            /*" -1980- EXEC SQL SELECT NUM_CERTIFICADO , NUM_PARCELA INTO :WS-NUM-CERTIFICADO , :WS-NUM-PARCELA FROM SEGUROS.COBER_HIST_VIDAZUL WHERE NUM_TITULO = :WHOST-NRTITULO END-EXEC. */

            var r1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1 = new R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1()
            {
                WHOST_NRTITULO = WHOST_NRTITULO.ToString(),
            };

            var executed_1 = R1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1.Execute(r1630_00_INSERT_COBHISVI_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_NUM_CERTIFICADO, WS_NUM_CERTIFICADO);
                _.Move(executed_1.WS_NUM_PARCELA, WS_NUM_PARCELA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1640_99_SAIDA*/

        [StopWatch]
        /*" R1650-00-DEBITO-CARTAO-SECTION */
        private void R1650_00_DEBITO_CARTAO_SECTION()
        {
            /*" -2124- MOVE '1650' TO WNR-EXEC-SQL. */
            _.Move("1650", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2126- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2128- MOVE 152 TO MOVDEBCE-DIG-CONTA-DEB. */
            _.Move(152, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB);

            /*" -2130- IF PRODUVG-COD-PRODUTO EQUAL 9320 OR JVPRD9320 */

            if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.In("9320", JVBKINCL.JV_PRODUTOS.JVPRD9320.ToString()))
            {

                /*" -2131- MOVE 0005 TO MOVDEBCE-OPER-CONTA-DEB */
                _.Move(0005, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                /*" -2132- ELSE */
            }
            else
            {


                /*" -2133- IF PRODUVG-COD-PRODUTO EQUAL 9703 */

                if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 9703)
                {

                    /*" -2134- MOVE 0006 TO MOVDEBCE-OPER-CONTA-DEB */
                    _.Move(0006, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                    /*" -2135- ELSE */
                }
                else
                {


                    /*" -2136- IF PRODUVG-COD-PRODUTO EQUAL 9318 */

                    if (PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO == 9318)
                    {

                        /*" -2137- MOVE 0008 TO MOVDEBCE-OPER-CONTA-DEB */
                        _.Move(0008, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);

                        /*" -2138- ELSE */
                    }
                    else
                    {


                        /*" -2140- MOVE 0005 TO MOVDEBCE-OPER-CONTA-DEB. */
                        _.Move(0005, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB);
                    }

                }

            }


            /*" -2141- MOVE 0 TO MOVDEBCE-COD-EMPRESA */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA);

            /*" -2142- MOVE WHOST-NRTITULO TO MOVDEBCE-NUM-APOLICE */
            _.Move(WHOST_NRTITULO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE);

            /*" -2143- MOVE 0 TO MOVDEBCE-NUM-ENDOSSO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO);

            /*" -2146- MOVE PARCEVID-NUM-PARCELA1 TO MOVDEBCE-NUM-PARCELA */
            _.Move(PARCEVID_NUM_PARCELA1, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA);

            /*" -2147- MOVE ' ' TO MOVDEBCE-SITUACAO-COBRANCA */
            _.Move(" ", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA);

            /*" -2149- MOVE PROPOVA-DTPROXVEN TO MOVDEBCE-DATA-VENCIMENTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DTPROXVEN, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO);

            /*" -2151- MOVE PLAVAVGA-VLPREMIOTOT TO MOVDEBCE-VALOR-DEBITO */
            _.Move(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO);

            /*" -2153- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVDEBCE-DATA-MOVIMENTO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO);

            /*" -2154- MOVE 0 TO MOVDEBCE-DIA-DEBITO */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO);

            /*" -2155- MOVE 0 TO MOVDEBCE-COD-AGENCIA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB);

            /*" -2156- MOVE 0 TO MOVDEBCE-NUM-CONTA-DEB */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB);

            /*" -2157- MOVE 9020 TO MOVDEBCE-COD-CONVENIO */
            _.Move(9020, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO);

            /*" -2158- MOVE ZEROES TO MOVDEBCE-NSAS */
            _.Move(0, MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS);

            /*" -2163- MOVE 'VA0123B' TO MOVDEBCE-COD-USUARIO */
            _.Move("VA0123B", MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO);

            /*" -2175- MOVE -1 TO VIND-DTENV VIND-DTRET VIND-CODRET VIND-NREQ VIND-SEQUEN VIND-NLOTE VIND-DTCRED VIND-STATUS VIND-VLCRED VIND-CCRE. */
            _.Move(-1, VIND_DTENV, VIND_DTRET, VIND_CODRET, VIND_NREQ, VIND_SEQUEN, VIND_NLOTE, VIND_DTCRED, VIND_STATUS, VIND_VLCRED, VIND_CCRE);

            /*" -2233- PERFORM R1650_00_DEBITO_CARTAO_DB_INSERT_1 */

            R1650_00_DEBITO_CARTAO_DB_INSERT_1();

            /*" -2236- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2237- DISPLAY 'ERRO NO INSERT MOVTO_DEBITOCC_CEF' */
                _.Display($"ERRO NO INSERT MOVTO_DEBITOCC_CEF");

                /*" -2238- DISPLAY 'APOLICE-> ' MOVDEBCE-NUM-APOLICE */
                _.Display($"APOLICE-> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE}");

                /*" -2239- DISPLAY 'ENDOSSO-> ' MOVDEBCE-NUM-ENDOSSO */
                _.Display($"ENDOSSO-> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO}");

                /*" -2240- DISPLAY 'PARCELA-> ' MOVDEBCE-NUM-PARCELA */
                _.Display($"PARCELA-> {MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA}");

                /*" -2241- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2241- END-IF. */
            }


        }

        [StopWatch]
        /*" R1650-00-DEBITO-CARTAO-DB-INSERT-1 */
        public void R1650_00_DEBITO_CARTAO_DB_INSERT_1()
        {
            /*" -2233- EXEC SQL INSERT INTO SEGUROS.MOVTO_DEBITOCC_CEF ( COD_EMPRESA , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , SITUACAO_COBRANCA , DATA_VENCIMENTO , VALOR_DEBITO , DATA_MOVIMENTO , TIMESTAMP , DIA_DEBITO , COD_AGENCIA_DEB , OPER_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , COD_CONVENIO , DATA_ENVIO , DATA_RETORNO , COD_RETORNO_CEF , NSAS , COD_USUARIO , NUM_REQUISICAO , NUM_CARTAO , SEQUENCIA , NUM_LOTE , DTCREDITO , STATUS_CARTAO , VLR_CREDITO ) VALUES ( :MOVDEBCE-COD-EMPRESA , :MOVDEBCE-NUM-APOLICE , :MOVDEBCE-NUM-ENDOSSO , :MOVDEBCE-NUM-PARCELA , :MOVDEBCE-SITUACAO-COBRANCA , :MOVDEBCE-DATA-VENCIMENTO , :MOVDEBCE-VALOR-DEBITO , :MOVDEBCE-DATA-MOVIMENTO , CURRENT TIMESTAMP , :MOVDEBCE-DIA-DEBITO , :MOVDEBCE-COD-AGENCIA-DEB , :MOVDEBCE-OPER-CONTA-DEB , :MOVDEBCE-NUM-CONTA-DEB , :MOVDEBCE-DIG-CONTA-DEB , :MOVDEBCE-COD-CONVENIO , :MOVDEBCE-DATA-ENVIO:VIND-DTENV , :MOVDEBCE-DATA-RETORNO:VIND-DTRET , :MOVDEBCE-COD-RETORNO-CEF:VIND-CODRET , :MOVDEBCE-NSAS , :MOVDEBCE-COD-USUARIO , :MOVDEBCE-NUM-REQUISICAO:VIND-NREQ , :MOVDEBCE-NUM-CARTAO:VIND-CCRE , :MOVDEBCE-SEQUENCIA:VIND-SEQUEN , :MOVDEBCE-NUM-LOTE:VIND-NLOTE , :MOVDEBCE-DTCREDITO:VIND-DTCRED , :MOVDEBCE-STATUS-CARTAO:VIND-STATUS , :MOVDEBCE-VLR-CREDITO:VIND-VLCRED ) END-EXEC. */

            var r1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1 = new R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1()
            {
                MOVDEBCE_COD_EMPRESA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_EMPRESA.ToString(),
                MOVDEBCE_NUM_APOLICE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_APOLICE.ToString(),
                MOVDEBCE_NUM_ENDOSSO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_ENDOSSO.ToString(),
                MOVDEBCE_NUM_PARCELA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_PARCELA.ToString(),
                MOVDEBCE_SITUACAO_COBRANCA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SITUACAO_COBRANCA.ToString(),
                MOVDEBCE_DATA_VENCIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_VENCIMENTO.ToString(),
                MOVDEBCE_VALOR_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VALOR_DEBITO.ToString(),
                MOVDEBCE_DATA_MOVIMENTO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_MOVIMENTO.ToString(),
                MOVDEBCE_DIA_DEBITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIA_DEBITO.ToString(),
                MOVDEBCE_COD_AGENCIA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_AGENCIA_DEB.ToString(),
                MOVDEBCE_OPER_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_OPER_CONTA_DEB.ToString(),
                MOVDEBCE_NUM_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CONTA_DEB.ToString(),
                MOVDEBCE_DIG_CONTA_DEB = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DIG_CONTA_DEB.ToString(),
                MOVDEBCE_COD_CONVENIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_CONVENIO.ToString(),
                MOVDEBCE_DATA_ENVIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_ENVIO.ToString(),
                VIND_DTENV = VIND_DTENV.ToString(),
                MOVDEBCE_DATA_RETORNO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DATA_RETORNO.ToString(),
                VIND_DTRET = VIND_DTRET.ToString(),
                MOVDEBCE_COD_RETORNO_CEF = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_RETORNO_CEF.ToString(),
                VIND_CODRET = VIND_CODRET.ToString(),
                MOVDEBCE_NSAS = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NSAS.ToString(),
                MOVDEBCE_COD_USUARIO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_COD_USUARIO.ToString(),
                MOVDEBCE_NUM_REQUISICAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_REQUISICAO.ToString(),
                VIND_NREQ = VIND_NREQ.ToString(),
                MOVDEBCE_NUM_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_CARTAO.ToString(),
                VIND_CCRE = VIND_CCRE.ToString(),
                MOVDEBCE_SEQUENCIA = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_SEQUENCIA.ToString(),
                VIND_SEQUEN = VIND_SEQUEN.ToString(),
                MOVDEBCE_NUM_LOTE = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_NUM_LOTE.ToString(),
                VIND_NLOTE = VIND_NLOTE.ToString(),
                MOVDEBCE_DTCREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_DTCREDITO.ToString(),
                VIND_DTCRED = VIND_DTCRED.ToString(),
                MOVDEBCE_STATUS_CARTAO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_STATUS_CARTAO.ToString(),
                VIND_STATUS = VIND_STATUS.ToString(),
                MOVDEBCE_VLR_CREDITO = MOVDEBCE.DCLMOVTO_DEBITOCC_CEF.MOVDEBCE_VLR_CREDITO.ToString(),
                VIND_VLCRED = VIND_VLCRED.ToString(),
            };

            R1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1.Execute(r1650_00_DEBITO_CARTAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1650_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-UPDATE-PROPOVA-SECTION */
        private void R1700_00_UPDATE_PROPOVA_SECTION()
        {
            /*" -2251- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2253- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2268- PERFORM R1700_00_UPDATE_PROPOVA_DB_UPDATE_1 */

            R1700_00_UPDATE_PROPOVA_DB_UPDATE_1();

            /*" -2271- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2272- DISPLAY 'ERRO NO UPDATE PROPOSTAS_VA' */
                _.Display($"ERRO NO UPDATE PROPOSTAS_VA");

                /*" -2273- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2274- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2274- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-UPDATE-PROPOVA-DB-UPDATE-1 */
        public void R1700_00_UPDATE_PROPOVA_DB_UPDATE_1()
        {
            /*" -2268- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET OCORR_HISTORICO = :PROPOVA-OCORR-HISTORICO1, COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO, COD_PRODUTO = :PRODUVG-COD-PRODUTO, NUM_PARCELA = :PARCEVID-NUM-PARCELA1, DATA_VENCIMENTO = DTPROXVEN, DTPROXVEN = DTPROXVEN + 1 MONTH, STA_MUDANCA_PLANO = 'S' , STA_ANTECIPACAO = 'N' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1 = new R1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1()
            {
                PROPOVA_OCORR_HISTORICO1 = PROPOVA_OCORR_HISTORICO1.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                PARCEVID_NUM_PARCELA1 = PARCEVID_NUM_PARCELA1.ToString(),
                PRODUVG_COD_PRODUTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_PRODUTO.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1.Execute(r1700_00_UPDATE_PROPOVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1750-00-INSERT-RELATO-PF10-SECTION */
        private void R1750_00_INSERT_RELATO_PF10_SECTION()
        {
            /*" -2285- MOVE '1750' TO WNR-EXEC-SQL. */
            _.Move("1750", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2287- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2289- INITIALIZE DCLRELATORIOS. */
            _.Initialize(
                RELATORI.DCLRELATORIOS
            );

            /*" -2290- MOVE 1 TO RELATORI-NUM-COPIAS. */
            _.Move(1, RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS);

            /*" -2291- MOVE 'VA' TO RELATORI-IDE-SISTEMA. */
            _.Move("VA", RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA);

            /*" -2292- MOVE 'VA0123B' TO RELATORI-COD-USUARIO. */
            _.Move("VA0123B", RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);

            /*" -2293- MOVE '1' TO RELATORI-SIT-REGISTRO. */
            _.Move("1", RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO);

            /*" -2294- MOVE 'VLNXA' TO RELATORI-COD-RELATORIO. */
            _.Move("VLNXA", RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO);

            /*" -2298- MOVE SISTEMAS-DATA-MOV-ABERTO TO RELATORI-DATA-SOLICITACAO RELATORI-PERI-INICIAL RELATORI-PERI-FINAL RELATORI-DATA-REFERENCIA. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -2299- MOVE PROPOVA-NUM-APOLICE TO RELATORI-NUM-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);

            /*" -2300- MOVE SUBGVGAP-COD-SUBGRUPO TO RELATORI-COD-SUBGRUPO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);

            /*" -2302- MOVE PROPOVA-NUM-CERTIFICADO TO RELATORI-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO);

            /*" -2391- PERFORM R1750_00_INSERT_RELATO_PF10_DB_INSERT_1 */

            R1750_00_INSERT_RELATO_PF10_DB_INSERT_1();

            /*" -2394- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2395- DISPLAY 'VA0123B - ERRO NO R1750-00-INSERT-RELATO-PF10' */
                _.Display($"VA0123B - ERRO NO R1750-00-INSERT-RELATO-PF10");

                /*" -2396- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2397- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2397- END-IF. */
            }


        }

        [StopWatch]
        /*" R1750-00-INSERT-RELATO-PF10-DB-INSERT-1 */
        public void R1750_00_INSERT_RELATO_PF10_DB_INSERT_1()
        {
            /*" -2391- EXEC SQL INSERT INTO SEGUROS.RELATORIOS ( COD_USUARIO , DATA_SOLICITACAO , IDE_SISTEMA , COD_RELATORIO , NUM_COPIAS , QUANTIDADE , PERI_INICIAL , PERI_FINAL , DATA_REFERENCIA , MES_REFERENCIA , ANO_REFERENCIA , ORGAO_EMISSOR , COD_FONTE , COD_PRODUTOR , RAMO_EMISSOR , COD_MODALIDADE , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , NUM_CERTIFICADO , NUM_TITULO , COD_SUBGRUPO , COD_OPERACAO , COD_PLANO , OCORR_HISTORICO , NUM_APOL_LIDER , ENDOS_LIDER , NUM_PARC_LIDER , NUM_SINISTRO , NUM_SINI_LIDER , NUM_ORDEM , COD_MOEDA , TIPO_CORRECAO , SIT_REGISTRO , IND_PREV_DEFINIT , IND_ANAL_RESUMO , COD_EMPRESA , PERI_RENOVACAO , PCT_AUMENTO , TIMESTAMP ) VALUES ( :RELATORI-COD-USUARIO , :RELATORI-DATA-SOLICITACAO , :RELATORI-IDE-SISTEMA , :RELATORI-COD-RELATORIO , :RELATORI-NUM-COPIAS , :RELATORI-QUANTIDADE , :RELATORI-PERI-INICIAL , :RELATORI-PERI-FINAL , :RELATORI-DATA-REFERENCIA , :RELATORI-MES-REFERENCIA , :RELATORI-ANO-REFERENCIA , :RELATORI-ORGAO-EMISSOR , :RELATORI-COD-FONTE , :RELATORI-COD-PRODUTOR , :RELATORI-RAMO-EMISSOR , :RELATORI-COD-MODALIDADE , :RELATORI-COD-CONGENERE , :RELATORI-NUM-APOLICE , :RELATORI-NUM-ENDOSSO , :RELATORI-NUM-PARCELA , :RELATORI-NUM-CERTIFICADO , :RELATORI-NUM-TITULO , :RELATORI-COD-SUBGRUPO , :RELATORI-COD-OPERACAO , :RELATORI-COD-PLANO , :RELATORI-OCORR-HISTORICO , :RELATORI-NUM-APOL-LIDER , :RELATORI-ENDOS-LIDER , :RELATORI-NUM-PARC-LIDER , :RELATORI-NUM-SINISTRO , :RELATORI-NUM-SINI-LIDER , :RELATORI-NUM-ORDEM , :RELATORI-COD-MOEDA , :RELATORI-TIPO-CORRECAO , :RELATORI-SIT-REGISTRO , :RELATORI-IND-PREV-DEFINIT , :RELATORI-IND-ANAL-RESUMO , :RELATORI-COD-EMPRESA , :RELATORI-PERI-RENOVACAO , :RELATORI-PCT-AUMENTO , CURRENT TIMESTAMP ) END-EXEC. */

            var r1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1 = new R1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1()
            {
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
                RELATORI_IDE_SISTEMA = RELATORI.DCLRELATORIOS.RELATORI_IDE_SISTEMA.ToString(),
                RELATORI_COD_RELATORIO = RELATORI.DCLRELATORIOS.RELATORI_COD_RELATORIO.ToString(),
                RELATORI_NUM_COPIAS = RELATORI.DCLRELATORIOS.RELATORI_NUM_COPIAS.ToString(),
                RELATORI_QUANTIDADE = RELATORI.DCLRELATORIOS.RELATORI_QUANTIDADE.ToString(),
                RELATORI_PERI_INICIAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.ToString(),
                RELATORI_PERI_FINAL = RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.ToString(),
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
                RELATORI_MES_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_MES_REFERENCIA.ToString(),
                RELATORI_ANO_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_ANO_REFERENCIA.ToString(),
                RELATORI_ORGAO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_ORGAO_EMISSOR.ToString(),
                RELATORI_COD_FONTE = RELATORI.DCLRELATORIOS.RELATORI_COD_FONTE.ToString(),
                RELATORI_COD_PRODUTOR = RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.ToString(),
                RELATORI_RAMO_EMISSOR = RELATORI.DCLRELATORIOS.RELATORI_RAMO_EMISSOR.ToString(),
                RELATORI_COD_MODALIDADE = RELATORI.DCLRELATORIOS.RELATORI_COD_MODALIDADE.ToString(),
                RELATORI_COD_CONGENERE = RELATORI.DCLRELATORIOS.RELATORI_COD_CONGENERE.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
                RELATORI_NUM_ENDOSSO = RELATORI.DCLRELATORIOS.RELATORI_NUM_ENDOSSO.ToString(),
                RELATORI_NUM_PARCELA = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARCELA.ToString(),
                RELATORI_NUM_CERTIFICADO = RELATORI.DCLRELATORIOS.RELATORI_NUM_CERTIFICADO.ToString(),
                RELATORI_NUM_TITULO = RELATORI.DCLRELATORIOS.RELATORI_NUM_TITULO.ToString(),
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_COD_OPERACAO = RELATORI.DCLRELATORIOS.RELATORI_COD_OPERACAO.ToString(),
                RELATORI_COD_PLANO = RELATORI.DCLRELATORIOS.RELATORI_COD_PLANO.ToString(),
                RELATORI_OCORR_HISTORICO = RELATORI.DCLRELATORIOS.RELATORI_OCORR_HISTORICO.ToString(),
                RELATORI_NUM_APOL_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOL_LIDER.ToString(),
                RELATORI_ENDOS_LIDER = RELATORI.DCLRELATORIOS.RELATORI_ENDOS_LIDER.ToString(),
                RELATORI_NUM_PARC_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_PARC_LIDER.ToString(),
                RELATORI_NUM_SINISTRO = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINISTRO.ToString(),
                RELATORI_NUM_SINI_LIDER = RELATORI.DCLRELATORIOS.RELATORI_NUM_SINI_LIDER.ToString(),
                RELATORI_NUM_ORDEM = RELATORI.DCLRELATORIOS.RELATORI_NUM_ORDEM.ToString(),
                RELATORI_COD_MOEDA = RELATORI.DCLRELATORIOS.RELATORI_COD_MOEDA.ToString(),
                RELATORI_TIPO_CORRECAO = RELATORI.DCLRELATORIOS.RELATORI_TIPO_CORRECAO.ToString(),
                RELATORI_SIT_REGISTRO = RELATORI.DCLRELATORIOS.RELATORI_SIT_REGISTRO.ToString(),
                RELATORI_IND_PREV_DEFINIT = RELATORI.DCLRELATORIOS.RELATORI_IND_PREV_DEFINIT.ToString(),
                RELATORI_IND_ANAL_RESUMO = RELATORI.DCLRELATORIOS.RELATORI_IND_ANAL_RESUMO.ToString(),
                RELATORI_COD_EMPRESA = RELATORI.DCLRELATORIOS.RELATORI_COD_EMPRESA.ToString(),
                RELATORI_PERI_RENOVACAO = RELATORI.DCLRELATORIOS.RELATORI_PERI_RENOVACAO.ToString(),
                RELATORI_PCT_AUMENTO = RELATORI.DCLRELATORIOS.RELATORI_PCT_AUMENTO.ToString(),
            };

            R1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1.Execute(r1750_00_INSERT_RELATO_PF10_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1750_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-UPDATE-SEGURVGA-SECTION */
        private void R1800_00_UPDATE_SEGURVGA_SECTION()
        {
            /*" -2408- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2410- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2418- PERFORM R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1 */

            R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1();

            /*" -2421- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2422- DISPLAY 'ERRO NO UPDATE SEGURADOS_VGAP' */
                _.Display($"ERRO NO UPDATE SEGURADOS_VGAP");

                /*" -2423- DISPLAY 'CERTIFICADO-> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO-> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2424- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2424- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-UPDATE-SEGURVGA-DB-UPDATE-1 */
        public void R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1()
        {
            /*" -2418- EXEC SQL UPDATE SEGUROS.SEGURADOS_VGAP SET OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO1, COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO, PERI_PAGAMENTO = :PRODUVG-PERI-PAGAMENTO, FAIXA = :PLAVAVGA-FAIXA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO END-EXEC. */

            var r1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1 = new R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1()
            {
                SEGURVGA_OCORR_HISTORICO1 = SEGURVGA_OCORR_HISTORICO1.ToString(),
                PRODUVG_PERI_PAGAMENTO = PRODUVG.DCLPRODUTOS_VG.PRODUVG_PERI_PAGAMENTO.ToString(),
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                PLAVAVGA_FAIXA = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_FAIXA.ToString(),
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            R1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1.Execute(r1800_00_UPDATE_SEGURVGA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-INSERT-SEGURHIS-SECTION */
        private void R1900_00_INSERT_SEGURHIS_SECTION()
        {
            /*" -2434- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2436- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2455- PERFORM R1900_00_INSERT_SEGURHIS_DB_INSERT_1 */

            R1900_00_INSERT_SEGURHIS_DB_INSERT_1();

            /*" -2458- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2459- DISPLAY 'ERRO NO INSERT SEGURADOSVGAP_HIST' */
                _.Display($"ERRO NO INSERT SEGURADOSVGAP_HIST");

                /*" -2460- DISPLAY 'CERTIFICADO --> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2461- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2461- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-INSERT-SEGURHIS-DB-INSERT-1 */
        public void R1900_00_INSERT_SEGURHIS_DB_INSERT_1()
        {
            /*" -2455- EXEC SQL INSERT INTO SEGUROS.SEGURADOSVGAP_HIST SELECT NUM_APOLICE, :SUBGVGAP-COD-SUBGRUPO COD_SUBGRUPO, NUM_ITEM, 202 COD_OPERACAO, :SISTEMAS-DATA-MOV-ABERTO DATA_OPERACAO, :WHOST-HORA-OPERACAO HORA_OPERACAO, :SISTEMAS-DATA-MOV-ABERTO DATA_MOVIMENTO, :SEGURVGA-OCORR-HISTORICO1 OCORR_HISTORICO, COD_SUBGRUPO_TRANS, :SISTEMAS-DATA-MOV-ABERTO DATA_REFERENCIA, 'VA0123B' COD_USUARIO, COD_EMPRESA, COD_MOEDA_IMP, COD_MOEDA_PRM FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO END-EXEC. */

            var r1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1 = new R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                WHOST_HORA_OPERACAO = WHOST_HORA_OPERACAO.ToString(),
                SEGURVGA_OCORR_HISTORICO1 = SEGURVGA_OCORR_HISTORICO1.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
            };

            R1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1.Execute(r1900_00_INSERT_SEGURHIS_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R1910-00-SELECT-APOLICOB-SECTION */
        private void R1910_00_SELECT_APOLICOB_SECTION()
        {
            /*" -2471- MOVE '1910' TO WNR-EXEC-SQL. */
            _.Move("1910", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2473- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2475- MOVE ZEROS TO WHOST-COUNT-COBER. */
            _.Move(0, WHOST_COUNT_COBER);

            /*" -2482- PERFORM R1910_00_SELECT_APOLICOB_DB_SELECT_1 */

            R1910_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -2485- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2486- DISPLAY 'ERRO NO SELECT APOLICE_COBERTURAS' */
                _.Display($"ERRO NO SELECT APOLICE_COBERTURAS");

                /*" -2487- DISPLAY 'CERTIFICADO --> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2488- DISPLAY 'APOLICE         ' PROPOVA-NUM-APOLICE */
                _.Display($"APOLICE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -2489- DISPLAY 'ITEM            ' SEGURVGA-NUM-ITEM */
                _.Display($"ITEM            {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                /*" -2490- DISPLAY 'OCORHIST        ' SEGURVGA-OCORR-HISTORICO */
                _.Display($"OCORHIST        {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                /*" -2491- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2491- END-IF. */
            }


        }

        [StopWatch]
        /*" R1910-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R1910_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -2482- EXEC SQL SELECT COUNT(*) INTO :WHOST-COUNT-COBER FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO END-EXEC. */

            var r1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r1910_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT_COBER, WHOST_COUNT_COBER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1910_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-UPDATE-RELATORI-SECTION */
        private void R2200_00_UPDATE_RELATORI_SECTION()
        {
            /*" -2501- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2503- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2506- MOVE SISTEMAS-DATA-MOV-ABERTO-30 TO RELATORI-DATA-REFERENCIA. */
            _.Move(SISTEMAS_DATA_MOV_ABERTO_30, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);

            /*" -2510- PERFORM R2200_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R2200_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -2513- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2514- DISPLAY 'ERRO SELECT REALTORIOS   ' */
                _.Display($"ERRO SELECT REALTORIOS   ");

                /*" -2515- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2515- END-IF. */
            }


        }

        [StopWatch]
        /*" R2200-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R2200_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -2510- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_REFERENCIA = :RELATORI-DATA-REFERENCIA WHERE COD_RELATORIO = 'VA0123B' END-EXEC. */

            var r2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                RELATORI_DATA_REFERENCIA = RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.ToString(),
            };

            R2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r2200_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2900-00-OPEN-CURS02-SECTION */
        private void R2900_00_OPEN_CURS02_SECTION()
        {
            /*" -2525- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2527- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2527- PERFORM R2900_00_OPEN_CURS02_DB_OPEN_1 */

            R2900_00_OPEN_CURS02_DB_OPEN_1();

            /*" -2530- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2531- DISPLAY 'ERRO OPEN CURS02' */
                _.Display($"ERRO OPEN CURS02");

                /*" -2532- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2532- END-IF. */
            }


        }

        [StopWatch]
        /*" R2900-00-OPEN-CURS02-DB-OPEN-1 */
        public void R2900_00_OPEN_CURS02_DB_OPEN_1()
        {
            /*" -2527- EXEC SQL OPEN CURS02 END-EXEC. */

            CURS02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-00-FETCH-CURS02-SECTION */
        private void R2910_00_FETCH_CURS02_SECTION()
        {
            /*" -2542- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2544- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2558- PERFORM R2910_00_FETCH_CURS02_DB_FETCH_1 */

            R2910_00_FETCH_CURS02_DB_FETCH_1();

            /*" -2561- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2562- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2563- MOVE 'SIM' TO WFIM-CURS02 */
                    _.Move("SIM", AREA_DE_WORK.WFIM_CURS02);

                    /*" -2563- PERFORM R2910_00_FETCH_CURS02_DB_CLOSE_1 */

                    R2910_00_FETCH_CURS02_DB_CLOSE_1();

                    /*" -2565- GO TO R2910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/ //GOTO
                    return;

                    /*" -2566- ELSE */
                }
                else
                {


                    /*" -2567- DISPLAY 'ERRO FETCH CURS02' */
                    _.Display($"ERRO FETCH CURS02");

                    /*" -2568- DISPLAY 'CERTIFICADO --> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2569- DISPLAY 'APOLICE         ' PROPOVA-NUM-APOLICE */
                    _.Display($"APOLICE         {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                    /*" -2570- DISPLAY 'ITEM            ' SEGURVGA-NUM-ITEM */
                    _.Display($"ITEM            {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

                    /*" -2571- DISPLAY 'OCORHIST        ' SEGURVGA-OCORR-HISTORICO */
                    _.Display($"OCORHIST        {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO}");

                    /*" -2572- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2572- END-IF. */
                }

            }


        }

        [StopWatch]
        /*" R2910-00-FETCH-CURS02-DB-FETCH-1 */
        public void R2910_00_FETCH_CURS02_DB_FETCH_1()
        {
            /*" -2558- EXEC SQL FETCH CURS02 INTO :APOLICOB-NUM-APOLICE, :APOLICOB-NUM-ENDOSSO, :APOLICOB-NUM-ITEM, :APOLICOB-RAMO-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-MODALI-COBERTURA, :APOLICOB-OCORR-HISTORICO , :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-IMP-SEGURADA-VAR, :APOLICOB-PRM-TARIFARIO-VAR, :APOLICOB-PCT-COBERTURA, :APOLICOB-FATOR-MULTIPLICA END-EXEC. */

            if (CURS02.Fetch())
            {
                _.Move(CURS02.APOLICOB_NUM_APOLICE, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE);
                _.Move(CURS02.APOLICOB_NUM_ENDOSSO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO);
                _.Move(CURS02.APOLICOB_NUM_ITEM, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM);
                _.Move(CURS02.APOLICOB_RAMO_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA);
                _.Move(CURS02.APOLICOB_COD_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA);
                _.Move(CURS02.APOLICOB_MODALI_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA);
                _.Move(CURS02.APOLICOB_OCORR_HISTORICO, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO);
                _.Move(CURS02.APOLICOB_IMP_SEGURADA_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX);
                _.Move(CURS02.APOLICOB_PRM_TARIFARIO_IX, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX);
                _.Move(CURS02.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(CURS02.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
                _.Move(CURS02.APOLICOB_PCT_COBERTURA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA);
                _.Move(CURS02.APOLICOB_FATOR_MULTIPLICA, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA);
            }

        }

        [StopWatch]
        /*" R2910-00-FETCH-CURS02-DB-CLOSE-1 */
        public void R2910_00_FETCH_CURS02_DB_CLOSE_1()
        {
            /*" -2563- EXEC SQL CLOSE CURS02 END-EXEC */

            CURS02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-PROCESSA-CURS02-SECTION */
        private void R3000_00_PROCESSA_CURS02_SECTION()
        {
            /*" -2583- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2587- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2589- PERFORM R3100-00-INSERT-APOLICOB. */

            R3100_00_INSERT_APOLICOB_SECTION();

            /*" -2589- PERFORM R3200-00-UPDATE-APOLICOB. */

            R3200_00_UPDATE_APOLICOB_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LER_OUTRO */

            R3000_10_LER_OUTRO();

        }

        [StopWatch]
        /*" R3000-10-LER-OUTRO */
        private void R3000_10_LER_OUTRO(bool isPerform = false)
        {
            /*" -2593- PERFORM R2910-00-FETCH-CURS02. */

            R2910_00_FETCH_CURS02_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-APOLICOB-SECTION */
        private void R3100_00_INSERT_APOLICOB_SECTION()
        {
            /*" -2688- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2690- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2692- IF APOLICOB-IMP-SEGURADA-IX EQUAL PLAVAVGA-IMPMORNATU OR PLAVAVGA-IMPMORACID */

            if (APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.In(PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU.ToString(), PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID.ToString()))
            {

                /*" -2693- DISPLAY 'INSERT APOLICE_COBERTURAS VLR IGUAL' */
                _.Display($"INSERT APOLICE_COBERTURAS VLR IGUAL");

                /*" -2694- DISPLAY 'VALOR APOLICE IGUAL: ' APOLICOB-IMP-SEGURADA-IX */
                _.Display($"VALOR APOLICE IGUAL: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX}");

                /*" -2695- DISPLAY 'VALOR PLANO IGUAL: ' PLAVAVGA-IMPMORNATU */
                _.Display($"VALOR PLANO IGUAL: {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU}");

                /*" -2696- DISPLAY 'VALOR PLANO2 IGUAL: ' PLAVAVGA-IMPMORACID */
                _.Display($"VALOR PLANO2 IGUAL: {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID}");

                /*" -2697- DISPLAY 'APOL: ' APOLICOB-NUM-APOLICE */
                _.Display($"APOL: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -2698- DISPLAY 'ENDO: ' APOLICOB-NUM-ENDOSSO */
                _.Display($"ENDO: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -2699- DISPLAY 'ITEM: ' APOLICOB-NUM-ITEM */
                _.Display($"ITEM: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                /*" -2700- DISPLAY 'OCORR: ' SEGURVGA-OCORR-HISTORICO1 */
                _.Display($"OCORR: {SEGURVGA_OCORR_HISTORICO1}");

                /*" -2701- DISPLAY 'RAMO: ' APOLICOB-RAMO-COBERTURA */
                _.Display($"RAMO: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -2702- DISPLAY 'MODALI: ' APOLICOB-MODALI-COBERTURA */
                _.Display($"MODALI: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA}");

                /*" -2703- DISPLAY 'COD COBER: ' APOLICOB-COD-COBERTURA */
                _.Display($"COD COBER: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -2704- DISPLAY 'IMP IX: ' APOLICOB-IMP-SEGURADA-IX */
                _.Display($"IMP IX: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX}");

                /*" -2705- DISPLAY 'VLPRE: ' PLAVAVGA-VLPREMIOTOT */
                _.Display($"VLPRE: {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT}");

                /*" -2706- DISPLAY 'PCT COBER: ' APOLICOB-PCT-COBERTURA */
                _.Display($"PCT COBER: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA}");

                /*" -2707- DISPLAY 'FATOR: ' APOLICOB-FATOR-MULTIPLICA */
                _.Display($"FATOR: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA}");

                /*" -2709- DISPLAY 'DATA: ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -2747- PERFORM R3100_00_INSERT_APOLICOB_DB_INSERT_1 */

                R3100_00_INSERT_APOLICOB_DB_INSERT_1();

                /*" -2749- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -2750- DISPLAY 'ERRO NO INSERT APOLICE_COBERTURAS 1' */
                    _.Display($"ERRO NO INSERT APOLICE_COBERTURAS 1");

                    /*" -2751- DISPLAY 'CERTIFICADO --> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2752- DISPLAY 'APOLICE         ' APOLICOB-NUM-APOLICE */
                    _.Display($"APOLICE         {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                    /*" -2753- DISPLAY 'ENDOSSO         ' APOLICOB-NUM-ENDOSSO */
                    _.Display($"ENDOSSO         {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                    /*" -2754- DISPLAY 'ITEM            ' APOLICOB-NUM-ITEM */
                    _.Display($"ITEM            {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                    /*" -2755- DISPLAY 'RAMO            ' APOLICOB-RAMO-COBERTURA */
                    _.Display($"RAMO            {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                    /*" -2756- DISPLAY 'COD_COBERTURA   ' APOLICOB-COD-COBERTURA */
                    _.Display($"COD_COBERTURA   {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                    /*" -2757- DISPLAY 'MODALI_COBER    ' APOLICOB-MODALI-COBERTURA */
                    _.Display($"MODALI_COBER    {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA}");

                    /*" -2758- DISPLAY 'OCORHIST        ' APOLICOB-OCORR-HISTORICO */
                    _.Display($"OCORHIST        {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO}");

                    /*" -2759- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2760- END-IF */
                }


                /*" -2761- ELSE */
            }
            else
            {


                /*" -2762- MOVE '3101' TO WNR-EXEC-SQL */
                _.Move("3101", AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -2763- DISPLAY WNR-EXEC-SQL */
                _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

                /*" -2764- DISPLAY 'INSERT APOLICE_COBERTURAS VLR DIFERENTE' */
                _.Display($"INSERT APOLICE_COBERTURAS VLR DIFERENTE");

                /*" -2765- DISPLAY 'VALOR APOLICE DIF: ' APOLICOB-IMP-SEGURADA-IX */
                _.Display($"VALOR APOLICE DIF: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX}");

                /*" -2766- DISPLAY 'VALOR PLANO DIF: ' PLAVAVGA-IMPMORNATU */
                _.Display($"VALOR PLANO DIF: {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORNATU}");

                /*" -2767- DISPLAY 'VALOR PLANO2 DIF: ' PLAVAVGA-IMPMORACID */
                _.Display($"VALOR PLANO2 DIF: {PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_IMPMORACID}");

                /*" -2768- DISPLAY 'APOL: ' APOLICOB-NUM-APOLICE */
                _.Display($"APOL: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -2769- DISPLAY 'ENDO: ' APOLICOB-NUM-ENDOSSO */
                _.Display($"ENDO: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -2770- DISPLAY 'ITEM: ' APOLICOB-NUM-ITEM */
                _.Display($"ITEM: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                /*" -2771- DISPLAY 'OCORR: ' SEGURVGA-OCORR-HISTORICO1 */
                _.Display($"OCORR: {SEGURVGA_OCORR_HISTORICO1}");

                /*" -2772- DISPLAY 'RAMO: ' APOLICOB-RAMO-COBERTURA */
                _.Display($"RAMO: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -2773- DISPLAY 'MODALI: ' APOLICOB-MODALI-COBERTURA */
                _.Display($"MODALI: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA}");

                /*" -2774- DISPLAY 'COD COBER: ' APOLICOB-COD-COBERTURA */
                _.Display($"COD COBER: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -2775- DISPLAY 'IMP IX: ' APOLICOB-IMP-SEGURADA-IX */
                _.Display($"IMP IX: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX}");

                /*" -2776- DISPLAY 'VLPRE: ' APOLICOB-PRM-TARIFARIO-IX */
                _.Display($"VLPRE: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX}");

                /*" -2777- DISPLAY 'IMP VAR: ' APOLICOB-IMP-SEGURADA-VAR */
                _.Display($"IMP VAR: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR}");

                /*" -2778- DISPLAY 'PRM VAR: ' APOLICOB-PRM-TARIFARIO-VAR */
                _.Display($"PRM VAR: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR}");

                /*" -2779- DISPLAY 'PCT COBER: ' APOLICOB-PCT-COBERTURA */
                _.Display($"PCT COBER: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA}");

                /*" -2780- DISPLAY 'FATOR: ' APOLICOB-FATOR-MULTIPLICA */
                _.Display($"FATOR: {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA}");

                /*" -2781- DISPLAY 'DATA: ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -2819- PERFORM R3100_00_INSERT_APOLICOB_DB_INSERT_2 */

                R3100_00_INSERT_APOLICOB_DB_INSERT_2();

                /*" -2821- IF SQLCODE NOT EQUAL ZERO */

                if (DB.SQLCODE != 00)
                {

                    /*" -2822- DISPLAY 'ERRO NO INSERT APOLICE_COBERTURAS 2' */
                    _.Display($"ERRO NO INSERT APOLICE_COBERTURAS 2");

                    /*" -2823- DISPLAY 'CERTIFICADO --> ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"CERTIFICADO --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2824- DISPLAY 'APOLICE         ' APOLICOB-NUM-APOLICE */
                    _.Display($"APOLICE         {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                    /*" -2825- DISPLAY 'ENDOSSO         ' APOLICOB-NUM-ENDOSSO */
                    _.Display($"ENDOSSO         {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                    /*" -2826- DISPLAY 'ITEM            ' APOLICOB-NUM-ITEM */
                    _.Display($"ITEM            {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                    /*" -2827- DISPLAY 'RAMO            ' APOLICOB-RAMO-COBERTURA */
                    _.Display($"RAMO            {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                    /*" -2828- DISPLAY 'COD_COBERTURA   ' APOLICOB-COD-COBERTURA */
                    _.Display($"COD_COBERTURA   {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                    /*" -2829- DISPLAY 'MODALI_COBER    ' APOLICOB-MODALI-COBERTURA */
                    _.Display($"MODALI_COBER    {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA}");

                    /*" -2830- DISPLAY 'OCORHIST        ' APOLICOB-OCORR-HISTORICO */
                    _.Display($"OCORHIST        {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO}");

                    /*" -2831- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2832- END-IF */
                }


                /*" -2832- END-IF. */
            }


        }

        [StopWatch]
        /*" R3100-00-INSERT-APOLICOB-DB-INSERT-1 */
        public void R3100_00_INSERT_APOLICOB_DB_INSERT_1()
        {
            /*" -2747- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, OCORR_HISTORICO, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, IMP_SEGURADA_VAR, PRM_TARIFARIO_VAR, PCT_COBERTURA, FATOR_MULTIPLICA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, COD_EMPRESA, TIMESTAMP, SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE , :APOLICOB-NUM-ENDOSSO , :APOLICOB-NUM-ITEM , :SEGURVGA-OCORR-HISTORICO1, :APOLICOB-RAMO-COBERTURA, :APOLICOB-MODALI-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-IMP-SEGURADA-IX, :PLAVAVGA-VLPREMIOTOT, :APOLICOB-IMP-SEGURADA-IX, :PLAVAVGA-VLPREMIOTOT, :APOLICOB-PCT-COBERTURA, :APOLICOB-FATOR-MULTIPLICA, :SISTEMAS-DATA-MOV-ABERTO , '9999-12-31' , NULL, CURRENT TIMESTAMP, ' ' ) END-EXEC */

            var r3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1 = new R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                SEGURVGA_OCORR_HISTORICO1 = SEGURVGA_OCORR_HISTORICO1.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                PLAVAVGA_VLPREMIOTOT = PLAVAVGA.DCLPLANOS_VA_VGAP.PLAVAVGA_VLPREMIOTOT.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1.Execute(r3100_00_INSERT_APOLICOB_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-INSERT-APOLICOB-DB-INSERT-2 */
        public void R3100_00_INSERT_APOLICOB_DB_INSERT_2()
        {
            /*" -2819- EXEC SQL INSERT INTO SEGUROS.APOLICE_COBERTURAS (NUM_APOLICE, NUM_ENDOSSO, NUM_ITEM, OCORR_HISTORICO, RAMO_COBERTURA, MODALI_COBERTURA, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, IMP_SEGURADA_VAR, PRM_TARIFARIO_VAR, PCT_COBERTURA, FATOR_MULTIPLICA, DATA_INIVIGENCIA, DATA_TERVIGENCIA, COD_EMPRESA, TIMESTAMP, SIT_REGISTRO) VALUES (:APOLICOB-NUM-APOLICE , :APOLICOB-NUM-ENDOSSO , :APOLICOB-NUM-ITEM , :SEGURVGA-OCORR-HISTORICO1, :APOLICOB-RAMO-COBERTURA, :APOLICOB-MODALI-COBERTURA, :APOLICOB-COD-COBERTURA, :APOLICOB-IMP-SEGURADA-IX, :APOLICOB-PRM-TARIFARIO-IX, :APOLICOB-IMP-SEGURADA-VAR, :APOLICOB-PRM-TARIFARIO-VAR, :APOLICOB-PCT-COBERTURA, :APOLICOB-FATOR-MULTIPLICA, :SISTEMAS-DATA-MOV-ABERTO , '9999-12-31' , NULL, CURRENT TIMESTAMP, ' ' ) END-EXEC */

            var r3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1 = new R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1()
            {
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
                SEGURVGA_OCORR_HISTORICO1 = SEGURVGA_OCORR_HISTORICO1.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_IMP_SEGURADA_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_IX.ToString(),
                APOLICOB_PRM_TARIFARIO_IX = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_IX.ToString(),
                APOLICOB_IMP_SEGURADA_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR.ToString(),
                APOLICOB_PRM_TARIFARIO_VAR = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR.ToString(),
                APOLICOB_PCT_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PCT_COBERTURA.ToString(),
                APOLICOB_FATOR_MULTIPLICA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_FATOR_MULTIPLICA.ToString(),
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            R3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1.Execute(r3100_00_INSERT_APOLICOB_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R3200-00-UPDATE-APOLICOB-SECTION */
        private void R3200_00_UPDATE_APOLICOB_SECTION()
        {
            /*" -2842- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2844- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2854- PERFORM R3200_00_UPDATE_APOLICOB_DB_UPDATE_1 */

            R3200_00_UPDATE_APOLICOB_DB_UPDATE_1();

            /*" -2857- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -2858- DISPLAY 'ERRO NO UPDATE APOLICE_COBERTURAS' */
                _.Display($"ERRO NO UPDATE APOLICE_COBERTURAS");

                /*" -2859- DISPLAY 'CERTIFICADO --> ' PROPOVA-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO --> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                /*" -2860- DISPLAY 'APOLICE         ' APOLICOB-NUM-APOLICE */
                _.Display($"APOLICE         {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE}");

                /*" -2861- DISPLAY 'ENDOSSO         ' APOLICOB-NUM-ENDOSSO */
                _.Display($"ENDOSSO         {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO}");

                /*" -2862- DISPLAY 'ITEM            ' APOLICOB-NUM-ITEM */
                _.Display($"ITEM            {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM}");

                /*" -2863- DISPLAY 'RAMO            ' APOLICOB-RAMO-COBERTURA */
                _.Display($"RAMO            {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA}");

                /*" -2864- DISPLAY 'COD_COBERTURA   ' APOLICOB-COD-COBERTURA */
                _.Display($"COD_COBERTURA   {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA}");

                /*" -2865- DISPLAY 'MODALI_COBER    ' APOLICOB-MODALI-COBERTURA */
                _.Display($"MODALI_COBER    {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA}");

                /*" -2866- DISPLAY 'OCORHIST        ' APOLICOB-OCORR-HISTORICO */
                _.Display($"OCORHIST        {APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO}");

                /*" -2867- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2867- END-IF. */
            }


        }

        [StopWatch]
        /*" R3200-00-UPDATE-APOLICOB-DB-UPDATE-1 */
        public void R3200_00_UPDATE_APOLICOB_DB_UPDATE_1()
        {
            /*" -2854- EXEC SQL UPDATE SEGUROS.APOLICE_COBERTURAS SET DATA_TERVIGENCIA = :SISTEMAS-DATA-MOV-ABERTO-01 WHERE NUM_APOLICE = :APOLICOB-NUM-APOLICE AND NUM_ENDOSSO = :APOLICOB-NUM-ENDOSSO AND NUM_ITEM = :APOLICOB-NUM-ITEM AND RAMO_COBERTURA = :APOLICOB-RAMO-COBERTURA AND COD_COBERTURA = :APOLICOB-COD-COBERTURA AND MODALI_COBERTURA = :APOLICOB-MODALI-COBERTURA AND OCORR_HISTORICO = :APOLICOB-OCORR-HISTORICO END-EXEC. */

            var r3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO_01 = SISTEMAS_DATA_MOV_ABERTO_01.ToString(),
                APOLICOB_MODALI_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_MODALI_COBERTURA.ToString(),
                APOLICOB_OCORR_HISTORICO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_OCORR_HISTORICO.ToString(),
                APOLICOB_RAMO_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_RAMO_COBERTURA.ToString(),
                APOLICOB_COD_COBERTURA = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_COD_COBERTURA.ToString(),
                APOLICOB_NUM_APOLICE = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_APOLICE.ToString(),
                APOLICOB_NUM_ENDOSSO = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ENDOSSO.ToString(),
                APOLICOB_NUM_ITEM = APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_NUM_ITEM.ToString(),
            };

            R3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_APOLICOB_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-FINALIZA-SECTION */
        private void R9000_00_FINALIZA_SECTION()
        {
            /*" -2877- MOVE '9000' TO WNR-EXEC-SQL. */
            _.Move("9000", AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2879- DISPLAY WNR-EXEC-SQL */
            _.Display(AREA_DE_WORK.WNR_EXEC_SQL);

            /*" -2880- DISPLAY ' ' . */
            _.Display($" ");

            /*" -2881- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -2882- DISPLAY '*      TERMINO NORMAL DO PROGRAMA VA0123B    *' . */
            _.Display($"*      TERMINO NORMAL DO PROGRAMA VA0123B    *");

            /*" -2883- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -2884- DISPLAY '* TOTAL DE REGISTROS LIDOS    : ' AC-LIDOS. */
            _.Display($"* TOTAL DE REGISTROS LIDOS    : {AREA_DE_WORK.AC_LIDOS}");

            /*" -2885- DISPLAY '* TOTAL DE PROCESSADOS        : ' AC-PROC. */
            _.Display($"* TOTAL DE PROCESSADOS        : {AREA_DE_WORK.AC_PROC}");

            /*" -2886- DISPLAY '* TOTAL DE DESPREZADOS        : ' AC-DESPR. */
            _.Display($"* TOTAL DE DESPREZADOS        : {AREA_DE_WORK.AC_DESPR}");

            /*" -2887- DISPLAY '* ... SEGURVGA                : ' AC-DESPR-SEGURVGA */
            _.Display($"* ... SEGURVGA                : {AREA_DE_WORK.AC_DESPR_SEGURVGA}");

            /*" -2888- DISPLAY '* ... SEGURHIS                : ' AC-DESPR-SEGURHIS */
            _.Display($"* ... SEGURHIS                : {AREA_DE_WORK.AC_DESPR_SEGURHIS}");

            /*" -2889- DISPLAY '* ... OPCPAGVI                : ' AC-DESPR-OPCPAGVI */
            _.Display($"* ... OPCPAGVI                : {AREA_DE_WORK.AC_DESPR_OPCPAGVI}");

            /*" -2890- DISPLAY '* ... SUBGVGAP                : ' AC-DESPR-SUBGVGAP */
            _.Display($"* ... SUBGVGAP                : {AREA_DE_WORK.AC_DESPR_SUBGVGAP}");

            /*" -2891- DISPLAY '* ... PLAVAVGA                : ' AC-DESPR-PLAVAVGA */
            _.Display($"* ... PLAVAVGA                : {AREA_DE_WORK.AC_DESPR_PLAVAVGA}");

            /*" -2893- DISPLAY '**********************************************' . */
            _.Display($"**********************************************");

            /*" -2895- PERFORM R2200-00-UPDATE-RELATORI. */

            R2200_00_UPDATE_RELATORI_SECTION();

            /*" -2895- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2910- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE);

            /*" -2912- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WS_HORA_OPERACAO.WABEND);

            /*" -2912- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2916- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2916- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}