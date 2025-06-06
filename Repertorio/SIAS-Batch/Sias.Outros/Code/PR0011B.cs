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
using Sias.Outros.DB2.PR0011B;

namespace Code
{
    public class PR0011B
    {
        public bool IsCall { get; set; }

        public PR0011B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *  ***************************************************************      */
        /*"      *  *                                                             *      */
        /*"      *  *     SISTEMA............. CONTROLE DE PROCESSOS              *      */
        /*"      *  *     PROGRAMA............ PR0011B                            *      */
        /*"      *  *     ANALISTA/PROGRAMADOR PROCAS                             *      */
        /*"      *  *                                                             *      */
        /*"      *  *     TABELAS............. FONTES PRODUTORAS    (TGEFONTE)    *      */
        /*"      *  *                          RAMOS/MODALIDADES    (TGERAMO)     *      */
        /*"      *  *                          SISTEMAS             (TSISTEMA)    *      */
        /*"      *  *                                                             *      */
        /*"      *  *     FUNCAO.............. EMITE ESTATISTICA DIARIA DE        *      */
        /*"      *  *                          PROPOSTAS PRE-CADASTRADAS          *      */
        /*"      *  *                                                             *      */
        /*"      *  ***************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ===============================================================*      */
        /*"      * CONVERSAO PARA O ANO 2000:                                     *      */
        /*"      * KINKAS (CONSEDA3 EM 05/06/1998)                                *      */
        /*"      * ===============================================================*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _RPR0011B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RPR0011B
        {
            get
            {
                _.Move(REG_PR0011B, _RPR0011B); VarBasis.RedefinePassValue(REG_PR0011B, _RPR0011B, REG_PR0011B); return _RPR0011B;
            }
        }
        /*"01              REG-PR0011B.*/
        public PR0011B_REG_PR0011B REG_PR0011B { get; set; } = new PR0011B_REG_PR0011B();
        public class PR0011B_REG_PR0011B : VarBasis
        {
            /*"  05            REG-LINHA             PIC  X(132).*/
            public StringBasis REG_LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77              V1EMPRESA-COD-EMP       PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              V1EMPRESA-NOM-EMP       PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77          V1SISTEM-DTMOVABE       PIC  X(010).*/
        public StringBasis V1SISTEM_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1SIST-DTCURRENT        PIC  X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V1ACOMPR-FONTE          PIC S9(004)       COMP.*/
        public IntBasis V1ACOMPR_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1ACOMPR-NRPROPOS       PIC S9(009)       COMP.*/
        public IntBasis V1ACOMPR_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1CONTPR-RAMO           PIC S9(004)       COMP.*/
        public IntBasis V1CONTPR_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1FONTES-FONTE          PIC S9(004)       COMP.*/
        public IntBasis V1FONTES_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1FONTES-NOMEFTE        PIC  X(040).*/
        public StringBasis V1FONTES_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01              AREA-DE-WORK.*/
        public PR0011B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new PR0011B_AREA_DE_WORK();
        public class PR0011B_AREA_DE_WORK : VarBasis
        {
            /*"  05            FILLER          PIC  X(035)    VALUE                'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"  05            WSTATUS         PIC  X(002)   VALUE   ZEROS.*/
            public StringBasis WSTATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05            WZEROS          PIC S9(003)   VALUE  +0  COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05            WRESTO          PIC S9(003)   VALUE  +0  COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05            WFIM-V1SISTEMA  PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            AC-LINHAS       PIC S9(002)   VALUE  +80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +80);
            /*"  05            AC-PAGINA       PIC S9(006)   VALUE   ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  05            AC-INC-F        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_INC_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-AUT-F        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_AUT_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-TRA-F        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_TRA_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-VID-F        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_VID_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-OUT-F        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_OUT_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-TOT-F        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_TOT_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-INC-G        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_INC_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-AUT-G        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_AUT_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-TRA-G        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_TRA_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-VID-G        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_VID_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-OUT-G        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_OUT_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05            AC-TOT-G        PIC S9(009)   VALUE  +0  COMP-3.*/
            public IntBasis AC_TOT_G { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05         WDATA-CURRENT     PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURRENT.*/
            private _REDEF_PR0011B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PR0011B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PR0011B_FILLER_1(); _.Move(WDATA_CURRENT, _filler_1); VarBasis.RedefinePassValue(WDATA_CURRENT, _filler_1, WDATA_CURRENT); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_CURRENT); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_CURRENT); }
            }  //Redefines
            public class _REDEF_PR0011B_FILLER_1 : VarBasis
            {
                /*"    10       WDATA-CURR-ANO    PIC  9(004).*/
                public IntBasis WDATA_CURR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-CURR-MES    PIC  9(002).*/
                public IntBasis WDATA_CURR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDATA-CURR-DIA    PIC  9(002).*/
                public IntBasis WDATA_CURR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            WS-DATE.*/

                public _REDEF_PR0011B_FILLER_1()
                {
                    WDATA_CURR_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_CURR_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_CURR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public PR0011B_WS_DATE WS_DATE { get; set; } = new PR0011B_WS_DATE();
            public class PR0011B_WS_DATE : VarBasis
            {
                /*"    10          WS-AA-DATE          PIC  9(004) VALUE ZEROS.*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          WS-MM-DATE          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-DD-DATE          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WS-TIME.*/
            }
            public PR0011B_WS_TIME WS_TIME { get; set; } = new PR0011B_WS_TIME();
            public class PR0011B_WS_TIME : VarBasis
            {
                /*"    10          WS-HH-TIME          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_HH_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-MM-TIME          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_MM_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-SS-TIME          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_SS_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-CC-TIME          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_CC_TIME { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WDATA-CABEC.*/
            }
            public PR0011B_WDATA_CABEC WDATA_CABEC { get; set; } = new PR0011B_WDATA_CABEC();
            public class PR0011B_WDATA_CABEC : VarBasis
            {
                /*"    10          WDATA-DD-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          WDATA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          WDATA-AA-CABEC      PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05            WHORA-CABEC.*/
            }
            public PR0011B_WHORA_CABEC WHORA_CABEC { get; set; } = new PR0011B_WHORA_CABEC();
            public class PR0011B_WHORA_CABEC : VarBasis
            {
                /*"    10          WHORA-HH-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_HH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER              PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10          WHORA-MM-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER              PIC  X(001) VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10          WHORA-SS-CABEC      PIC  9(002) VALUE ZEROS.*/
                public IntBasis WHORA_SS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WDATA-REL           PIC  X(010) VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05            FILLER              REDEFINES   WDATA-REL.*/
            private _REDEF_PR0011B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PR0011B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PR0011B_FILLER_8(); _.Move(WDATA_REL, _filler_8); VarBasis.RedefinePassValue(WDATA_REL, _filler_8, WDATA_REL); _filler_8.ValueChanged += () => { _.Move(_filler_8, WDATA_REL); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WDATA_REL); }
            }  //Redefines
            public class _REDEF_PR0011B_FILLER_8 : VarBasis
            {
                /*"    10          WDAT-REL-ANO        PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10          FILLER              PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10          FILLER              PIC  X(001).*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10          WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            WDAT-REL-LIT.*/

                public _REDEF_PR0011B_FILLER_8()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_9.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_10.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public PR0011B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new PR0011B_WDAT_REL_LIT();
            public class PR0011B_WDAT_REL_LIT : VarBasis
            {
                /*"    10          WDAT-LIT-DIA        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          WDAT-LIT-MES        PIC  9(002) VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10          WDAT-LIT-ANO        PIC  9(004) VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05            CH-CHAVE-ATU.*/
            }
            public PR0011B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new PR0011B_CH_CHAVE_ATU();
            public class PR0011B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10          CH-FONTE-ATU     PIC  X(004)   VALUE LOW-VALUES.*/
                public StringBasis CH_FONTE_ATU { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"S");
                /*"    10          CH-FONTE-ATUR    REDEFINES     CH-FONTE-ATU                                 PIC  9(003).*/
                private _REDEF_IntBasis _ch_fonte_atur { get; set; }
                public _REDEF_IntBasis CH_FONTE_ATUR
                {
                    get { _ch_fonte_atur = new _REDEF_IntBasis(new PIC("9", "003", "9(003).")); ; _.Move(CH_FONTE_ATU, _ch_fonte_atur); VarBasis.RedefinePassValue(CH_FONTE_ATU, _ch_fonte_atur, CH_FONTE_ATU); _ch_fonte_atur.ValueChanged += () => { _.Move(_ch_fonte_atur, CH_FONTE_ATU); }; return _ch_fonte_atur; }
                    set { VarBasis.RedefinePassValue(value, _ch_fonte_atur, CH_FONTE_ATU); }
                }  //Redefines
                /*"  05            CH-CHAVE-ANT.*/
            }
            public PR0011B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new PR0011B_CH_CHAVE_ANT();
            public class PR0011B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10          CH-FONTE-ANT     PIC  X(004)   VALUE LOW-VALUES.*/
                public StringBasis CH_FONTE_ANT { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"S");
                /*"    10          CH-FONTE-ANTR    REDEFINES     CH-FONTE-ANT                                 PIC  9(003).*/
                private _REDEF_IntBasis _ch_fonte_antr { get; set; }
                public _REDEF_IntBasis CH_FONTE_ANTR
                {
                    get { _ch_fonte_antr = new _REDEF_IntBasis(new PIC("9", "003", "9(003).")); ; _.Move(CH_FONTE_ANT, _ch_fonte_antr); VarBasis.RedefinePassValue(CH_FONTE_ANT, _ch_fonte_antr, CH_FONTE_ANT); _ch_fonte_antr.ValueChanged += () => { _.Move(_ch_fonte_antr, CH_FONTE_ANT); }; return _ch_fonte_antr; }
                    set { VarBasis.RedefinePassValue(value, _ch_fonte_antr, CH_FONTE_ANT); }
                }  //Redefines
                /*"  03            LC01.*/
            }
            public PR0011B_LC01 LC01 { get; set; } = new PR0011B_LC01();
            public class PR0011B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO  PIC  X(007) VALUE 'PR0011B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PR0011B");
                /*"    05          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    05          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public PR0011B_LC02 LC02 { get; set; } = new PR0011B_LC02();
            public class PR0011B_LC02 : VarBasis
            {
                /*"    05          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public PR0011B_LC03 LC03 { get; set; } = new PR0011B_LC03();
            public class PR0011B_LC03 : VarBasis
            {
                /*"    05          FILLER          PIC  X(035) VALUE  SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    05          FILLER          PIC  X(048) VALUE               'ESTATISTICA DIARIA DE PROPOSTAS PRE-CADASTRADAS'*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"ESTATISTICA DIARIA DE PROPOSTAS PRE-CADASTRADAS");
                /*"    05          LC03-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05          FILLER          PIC  X(024) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    05          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public PR0011B_LC04 LC04 { get; set; } = new PR0011B_LC04();
            public class PR0011B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(046) VALUE  ALL '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"ALL");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(083) VALUE  ALL '-'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"ALL");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  05            LC05.*/
            }
            public PR0011B_LC05 LC05 { get; set; } = new PR0011B_LC05();
            public class PR0011B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10          FILLER          PIC  X(046) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10          FILLER          PIC  X(035) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"    10          FILLER          PIC  X(048) VALUE               'R  A  M  O  S'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"R  A  M  O  S");
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05            LC06.*/
            }
            public PR0011B_LC06 LC06 { get; set; } = new PR0011B_LC06();
            public class PR0011B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10          FILLER          PIC  X(046) VALUE               ' FONTE PRODUTORA'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @" FONTE PRODUTORA");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(084) VALUE               '-------------+-------------+-------------+-------               '------+-------------+-------------+'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)"), @"-------------+-------------+-------------+-------               ");
                /*"  05            LC07.*/
            }
            public PR0011B_LC07 LC07 { get; set; } = new PR0011B_LC07();
            public class PR0011B_LC07 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10          FILLER          PIC  X(046) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"    10          FILLER          PIC  X(084) VALUE               '   INCENDIO  I AUTOMOVEIS  I TRANSPORTES I    VID               'A     I   OUTROS    I TOTAL GERAL I'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)"), @"   INCENDIO  I AUTOMOVEIS  I TRANSPORTES I    VID               ");
                /*"  05            LC08.*/
            }
            public PR0011B_LC08 LC08 { get; set; } = new PR0011B_LC08();
            public class PR0011B_LC08 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(046) VALUE  ALL '-'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"ALL");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(084) VALUE               '-------------+-------------+-------------+-------               '------+-------------+-------------+'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)"), @"-------------+-------------+-------------+-------               ");
                /*"  05            LD01.*/
            }
            public PR0011B_LD01 LD01 { get; set; } = new PR0011B_LD01();
            public class PR0011B_LD01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(002) VALUE 'I'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"I");
                /*"    10          LD01-FONTE      PIC  9(003) VALUE  ZEROS.*/
                public IntBasis LD01_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NOMEFTE    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LD01_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10          FILLER          PIC  X(003) VALUE ' I'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" I");
                /*"    10          LD01-INC        PIC  ZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_INC { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(004) VALUE '  I'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"  I");
                /*"    10          LD01-AUT        PIC  ZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_AUT { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(004) VALUE '  I'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"  I");
                /*"    10          LD01-TRA        PIC  ZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_TRA { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(004) VALUE '  I'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"  I");
                /*"    10          LD01-VID        PIC  ZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_VID { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(004) VALUE '  I'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"  I");
                /*"    10          LD01-OUT        PIC  ZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_OUT { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(004) VALUE '  I'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"  I");
                /*"    10          LD01-TOT        PIC  ZZ.ZZZ.ZZ9.*/
                public IntBasis LD01_TOT { get; set; } = new IntBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9."));
                /*"    10          FILLER          PIC  X(003) VALUE '  I'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"  I");
                /*"  05        WABEND.*/
            }
            public PR0011B_WABEND WABEND { get; set; } = new PR0011B_WABEND();
            public class PR0011B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' PR0011B'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PR0011B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public PR0011B_LK_LINK LK_LINK { get; set; } = new PR0011B_LK_LINK();
        public class PR0011B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public PR0011B_V1ACOMPROP V1ACOMPROP { get; set; } = new PR0011B_V1ACOMPROP();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RPR0011B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RPR0011B.SetFile(RPR0011B_FILE_NAME_P);

                /*" -335- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -336- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -339- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

                /*" -342- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -342- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -351- PERFORM R0500-00-SELECT-V1SISTEMA */

            R0500_00_SELECT_V1SISTEMA_SECTION();

            /*" -352- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -354- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -356- PERFORM R0015-00-CABECALHOS */

            R0015_00_CABECALHOS_SECTION();

            /*" -358- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -360- PERFORM R0900-00-DECLARE-V1ACOMPRO */

            R0900_00_DECLARE_V1ACOMPRO_SECTION();

            /*" -362- PERFORM R0910-00-FETCH-V1ACOMPRO */

            R0910_00_FETCH_V1ACOMPRO_SECTION();

            /*" -365- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL CH-CHAVE-ATU EQUAL HIGH-VALUES */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -366- IF AC-PAGINA NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_PAGINA != 00)
            {

                /*" -368- PERFORM R4000-00-IMPRESSAO-GERAL. */

                R4000_00_IMPRESSAO_GERAL_SECTION();
            }


            /*" -368- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -374- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -376- DISPLAY 'PR0011B - FIM NORMAL' */
            _.Display($"PR0011B - FIM NORMAL");

            /*" -376- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-CABECALHOS-SECTION */
        private void R0015_00_CABECALHOS_SECTION()
        {
            /*" -390- MOVE '015' TO WNR-EXEC-SQL. */
            _.Move("015", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -391- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -392- MOVE WS-DD-DATE TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WS_DATE.WS_DD_DATE, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -393- MOVE WS-MM-DATE TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WS_DATE.WS_MM_DATE, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -394- MOVE WS-AA-DATE TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WS_DATE.WS_AA_DATE, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -395- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -396- MOVE WS-HH-TIME TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -397- MOVE WS-MM-TIME TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -398- MOVE WS-SS-TIME TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -400- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -404- PERFORM R0015_00_CABECALHOS_DB_SELECT_1 */

            R0015_00_CABECALHOS_DB_SELECT_1();

            /*" -407- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -409- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -410- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -411- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -412- ELSE */
            }
            else
            {


                /*" -413- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -413- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0015-00-CABECALHOS-DB-SELECT-1 */
        public void R0015_00_CABECALHOS_DB_SELECT_1()
        {
            /*" -404- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var r0015_00_CABECALHOS_DB_SELECT_1_Query1 = new R0015_00_CABECALHOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0015_00_CABECALHOS_DB_SELECT_1_Query1.Execute(r0015_00_CABECALHOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1EMPRESA_NOM_EMP, V1EMPRESA_NOM_EMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_EXIT*/

        [StopWatch]
        /*" R0500-00-SELECT-V1SISTEMA-SECTION */
        private void R0500_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -426- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -432- PERFORM R0500_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0500_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -435- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -437- DISPLAY 'PR0011B - SISTEMA CONTROLE DE PROCESSOS NAO E 'STA CADASTRADO' */

                $"PR0011B - SISTEMA CONTROLE DE PROCESSOS NAO E STACADASTRADO"
                .Display();

                /*" -438- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                /*" -440- GO TO R0500-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/ //GOTO
                return;
            }


            /*" -441- MOVE V1SIST-DTCURRENT TO WDATA-CURRENT */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURRENT);

            /*" -442- MOVE WDATA-CURR-DIA TO WS-DD-DATE */
            _.Move(AREA_DE_WORK.FILLER_1.WDATA_CURR_DIA, AREA_DE_WORK.WS_DATE.WS_DD_DATE);

            /*" -443- MOVE WDATA-CURR-MES TO WS-MM-DATE */
            _.Move(AREA_DE_WORK.FILLER_1.WDATA_CURR_MES, AREA_DE_WORK.WS_DATE.WS_MM_DATE);

            /*" -444- MOVE WDATA-CURR-ANO TO WS-AA-DATE. */
            _.Move(AREA_DE_WORK.FILLER_1.WDATA_CURR_ANO, AREA_DE_WORK.WS_DATE.WS_AA_DATE);

            /*" -445- MOVE V1SISTEM-DTMOVABE TO WDATA-REL */
            _.Move(V1SISTEM_DTMOVABE, AREA_DE_WORK.WDATA_REL);

            /*" -446- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_DIA, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -447- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_MES, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -448- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(AREA_DE_WORK.FILLER_8.WDAT_REL_ANO, AREA_DE_WORK.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -448- MOVE WDAT-REL-LIT TO LC03-DATA. */
            _.Move(AREA_DE_WORK.WDAT_REL_LIT, AREA_DE_WORK.LC03.LC03_DATA);

        }

        [StopWatch]
        /*" R0500-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0500_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -432- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V1SISTEM-DTMOVABE, :V1SIST-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'PR' END-EXEC. */

            var r0500_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0500_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0500_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SISTEM_DTMOVABE, V1SISTEM_DTMOVABE);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1ACOMPRO-SECTION */
        private void R0900_00_DECLARE_V1ACOMPRO_SECTION()
        {
            /*" -461- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -468- PERFORM R0900_00_DECLARE_V1ACOMPRO_DB_DECLARE_1 */

            R0900_00_DECLARE_V1ACOMPRO_DB_DECLARE_1();

            /*" -470- PERFORM R0900_00_DECLARE_V1ACOMPRO_DB_OPEN_1 */

            R0900_00_DECLARE_V1ACOMPRO_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1ACOMPRO-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1ACOMPRO_DB_DECLARE_1()
        {
            /*" -468- EXEC SQL DECLARE V1ACOMPROP CURSOR FOR SELECT FONTE, NRPROPOS FROM SEGUROS.V1ACOMPROP WHERE DATOPR = :V1SISTEM-DTMOVABE AND OCORHIST = 1 ORDER BY FONTE END-EXEC. */
            V1ACOMPROP = new PR0011B_V1ACOMPROP(true);
            string GetQuery_V1ACOMPROP()
            {
                var query = @$"SELECT FONTE
							, 
							NRPROPOS 
							FROM SEGUROS.V1ACOMPROP 
							WHERE DATOPR = '{V1SISTEM_DTMOVABE}' 
							AND OCORHIST = 1 
							ORDER BY FONTE";

                return query;
            }
            V1ACOMPROP.GetQueryEvent += GetQuery_V1ACOMPROP;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1ACOMPRO-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1ACOMPRO_DB_OPEN_1()
        {
            /*" -470- EXEC SQL OPEN V1ACOMPROP END-EXEC. */

            V1ACOMPROP.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1ACOMPRO-SECTION */
        private void R0910_00_FETCH_V1ACOMPRO_SECTION()
        {
            /*" -483- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -486- PERFORM R0910_00_FETCH_V1ACOMPRO_DB_FETCH_1 */

            R0910_00_FETCH_V1ACOMPRO_DB_FETCH_1();

            /*" -489- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -490- MOVE HIGH-VALUES TO CH-CHAVE-ATU */

                AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues = true;

                /*" -490- PERFORM R0910_00_FETCH_V1ACOMPRO_DB_CLOSE_1 */

                R0910_00_FETCH_V1ACOMPRO_DB_CLOSE_1();

                /*" -492- GO TO R0910-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;

                /*" -494- END-IF. */
            }


            /*" -494- MOVE V1ACOMPR-FONTE TO CH-FONTE-ATU. */
            _.Move(V1ACOMPR_FONTE, AREA_DE_WORK.CH_CHAVE_ATU.CH_FONTE_ATU);

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1ACOMPRO-DB-FETCH-1 */
        public void R0910_00_FETCH_V1ACOMPRO_DB_FETCH_1()
        {
            /*" -486- EXEC SQL FETCH V1ACOMPROP INTO :V1ACOMPR-FONTE, :V1ACOMPR-NRPROPOS END-EXEC. */

            if (V1ACOMPROP.Fetch())
            {
                _.Move(V1ACOMPROP.V1ACOMPR_FONTE, V1ACOMPR_FONTE);
                _.Move(V1ACOMPROP.V1ACOMPR_NRPROPOS, V1ACOMPR_NRPROPOS);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1ACOMPRO-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1ACOMPRO_DB_CLOSE_1()
        {
            /*" -490- EXEC SQL CLOSE V1ACOMPROP END-EXEC */

            V1ACOMPROP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -507- MOVE CH-FONTE-ATU TO CH-FONTE-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_FONTE_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_FONTE_ANT);

            /*" -509- PERFORM R5000-00-SELECT-V1FONTES */

            R5000_00_SELECT_V1FONTES_SECTION();

            /*" -510- MOVE CH-FONTE-ATU TO LD01-FONTE */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_FONTE_ATU, AREA_DE_WORK.LD01.LD01_FONTE);

            /*" -512- MOVE V1FONTES-NOMEFTE TO LD01-NOMEFTE */
            _.Move(V1FONTES_NOMEFTE, AREA_DE_WORK.LD01.LD01_NOMEFTE);

            /*" -516- PERFORM R1100-00-PROCESSA-RAMOS UNTIL CH-FONTE-ATU NOT EQUAL CH-FONTE-ANT OR CH-CHAVE-ATU NOT EQUAL HIGH-VALUES */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.CH_FONTE_ATU != AREA_DE_WORK.CH_CHAVE_ANT.CH_FONTE_ANT || AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues))
            {

                R1100_00_PROCESSA_RAMOS_SECTION();
            }

            /*" -516- PERFORM R3000-00-IMPRESSAO-FONTE. */

            R3000_00_IMPRESSAO_FONTE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-RAMOS-SECTION */
        private void R1100_00_PROCESSA_RAMOS_SECTION()
        {
            /*" -529- PERFORM R1200-00-SELECT-V1CONTPROP */

            R1200_00_SELECT_V1CONTPROP_SECTION();

            /*" -530- IF V1CONTPR-RAMO EQUAL 11 OR 41 */

            if (V1CONTPR_RAMO.In("11", "41"))
            {

                /*" -531- ADD 1 TO AC-INC-F */
                AREA_DE_WORK.AC_INC_F.Value = AREA_DE_WORK.AC_INC_F + 1;

                /*" -532- ELSE */
            }
            else
            {


                /*" -533- IF V1CONTPR-RAMO EQUAL 31 OR 53 */

                if (V1CONTPR_RAMO.In("31", "53"))
                {

                    /*" -534- ADD 1 TO AC-AUT-F */
                    AREA_DE_WORK.AC_AUT_F.Value = AREA_DE_WORK.AC_AUT_F + 1;

                    /*" -535- ELSE */
                }
                else
                {


                    /*" -538- IF V1CONTPR-RAMO EQUAL 21 OR 22 OR 54 OR 55 OR 56 */

                    if (V1CONTPR_RAMO.In("21", "22", "54", "55", "56"))
                    {

                        /*" -539- ADD 1 TO AC-TRA-F */
                        AREA_DE_WORK.AC_TRA_F.Value = AREA_DE_WORK.AC_TRA_F + 1;

                        /*" -540- ELSE */
                    }
                    else
                    {


                        /*" -543- IF V1CONTPR-RAMO EQUAL 80 OR 81 OR 82 OR 83 OR 93 OR 97 */

                        if (V1CONTPR_RAMO.In("80", "81", "82", "83", "93", "97"))
                        {

                            /*" -544- ADD 1 TO AC-VID-F */
                            AREA_DE_WORK.AC_VID_F.Value = AREA_DE_WORK.AC_VID_F + 1;

                            /*" -545- ELSE */
                        }
                        else
                        {


                            /*" -547- ADD 1 TO AC-OUT-F. */
                            AREA_DE_WORK.AC_OUT_F.Value = AREA_DE_WORK.AC_OUT_F + 1;
                        }

                    }

                }

            }


            /*" -549- ADD 1 TO AC-TOT-F */
            AREA_DE_WORK.AC_TOT_F.Value = AREA_DE_WORK.AC_TOT_F + 1;

            /*" -549- PERFORM R0910-00-FETCH-V1ACOMPRO. */

            R0910_00_FETCH_V1ACOMPRO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V1CONTPROP-SECTION */
        private void R1200_00_SELECT_V1CONTPROP_SECTION()
        {
            /*" -562- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -568- PERFORM R1200_00_SELECT_V1CONTPROP_DB_SELECT_1 */

            R1200_00_SELECT_V1CONTPROP_DB_SELECT_1();

            /*" -571- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -574- DISPLAY 'PR0011B-NAO EXISTE DOCUMENTO CORRESPONDENTE NA 'V1CONTPROP = ' V1ACOMPR-FONTE V1ACOMPR-NRPROPOS. */

                $"PR0011B-NAO EXISTE DOCUMENTO CORRESPONDENTE NA V1CONTPROP={V1ACOMPR_FONTE}{V1ACOMPR_NRPROPOS}"
                .Display();
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V1CONTPROP-DB-SELECT-1 */
        public void R1200_00_SELECT_V1CONTPROP_DB_SELECT_1()
        {
            /*" -568- EXEC SQL SELECT RAMO INTO :V1CONTPR-RAMO FROM SEGUROS.V1CONTPROP WHERE FONTE = :V1ACOMPR-FONTE AND NRPROPOS = :V1ACOMPR-NRPROPOS END-EXEC. */

            var r1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1 = new R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1()
            {
                V1ACOMPR_NRPROPOS = V1ACOMPR_NRPROPOS.ToString(),
                V1ACOMPR_FONTE = V1ACOMPR_FONTE.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V1CONTPROP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1CONTPR_RAMO, V1CONTPR_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CABECALHOS-SECTION */
        private void R2000_00_CABECALHOS_SECTION()
        {
            /*" -586- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -587- MOVE AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -589- MOVE ZEROS TO AC-LINHAS */
            _.Move(0, AREA_DE_WORK.AC_LINHAS);

            /*" -590- WRITE REG-PR0011B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -591- WRITE REG-PR0011B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -592- WRITE REG-PR0011B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -593- WRITE REG-PR0011B FROM LC04 AFTER 2 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -594- WRITE REG-PR0011B FROM LC05 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -595- WRITE REG-PR0011B FROM LC06 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -596- WRITE REG-PR0011B FROM LC07 */
            _.Move(AREA_DE_WORK.LC07.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -596- WRITE REG-PR0011B FROM LC08. */
            _.Move(AREA_DE_WORK.LC08.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-IMPRESSAO-FONTE-SECTION */
        private void R3000_00_IMPRESSAO_FONTE_SECTION()
        {
            /*" -608- ADD AC-INC-F TO AC-INC-G */
            AREA_DE_WORK.AC_INC_G.Value = AREA_DE_WORK.AC_INC_G + AREA_DE_WORK.AC_INC_F;

            /*" -609- ADD AC-AUT-F TO AC-AUT-G */
            AREA_DE_WORK.AC_AUT_G.Value = AREA_DE_WORK.AC_AUT_G + AREA_DE_WORK.AC_AUT_F;

            /*" -610- ADD AC-TRA-F TO AC-TRA-G */
            AREA_DE_WORK.AC_TRA_G.Value = AREA_DE_WORK.AC_TRA_G + AREA_DE_WORK.AC_TRA_F;

            /*" -611- ADD AC-VID-F TO AC-VID-G */
            AREA_DE_WORK.AC_VID_G.Value = AREA_DE_WORK.AC_VID_G + AREA_DE_WORK.AC_VID_F;

            /*" -612- ADD AC-OUT-F TO AC-OUT-G */
            AREA_DE_WORK.AC_OUT_G.Value = AREA_DE_WORK.AC_OUT_G + AREA_DE_WORK.AC_OUT_F;

            /*" -614- ADD AC-TOT-F TO AC-TOT-G */
            AREA_DE_WORK.AC_TOT_G.Value = AREA_DE_WORK.AC_TOT_G + AREA_DE_WORK.AC_TOT_F;

            /*" -615- MOVE AC-INC-F TO LD01-INC */
            _.Move(AREA_DE_WORK.AC_INC_F, AREA_DE_WORK.LD01.LD01_INC);

            /*" -616- MOVE AC-AUT-F TO LD01-AUT */
            _.Move(AREA_DE_WORK.AC_AUT_F, AREA_DE_WORK.LD01.LD01_AUT);

            /*" -617- MOVE AC-TRA-F TO LD01-TRA */
            _.Move(AREA_DE_WORK.AC_TRA_F, AREA_DE_WORK.LD01.LD01_TRA);

            /*" -618- MOVE AC-VID-F TO LD01-VID */
            _.Move(AREA_DE_WORK.AC_VID_F, AREA_DE_WORK.LD01.LD01_VID);

            /*" -619- MOVE AC-OUT-F TO LD01-OUT */
            _.Move(AREA_DE_WORK.AC_OUT_F, AREA_DE_WORK.LD01.LD01_OUT);

            /*" -621- MOVE AC-TOT-F TO LD01-TOT */
            _.Move(AREA_DE_WORK.AC_TOT_F, AREA_DE_WORK.LD01.LD01_TOT);

            /*" -628- MOVE ZEROS TO AC-INC-F AC-AUT-F AC-TRA-F AC-VID-F AC-OUT-F AC-TOT-F */
            _.Move(0, AREA_DE_WORK.AC_INC_F, AREA_DE_WORK.AC_AUT_F, AREA_DE_WORK.AC_TRA_F, AREA_DE_WORK.AC_VID_F, AREA_DE_WORK.AC_OUT_F, AREA_DE_WORK.AC_TOT_F);

            /*" -629- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -630- IF AC-LINHAS GREATER 58 */

            if (AREA_DE_WORK.AC_LINHAS > 58)
            {

                /*" -632- PERFORM R2000-00-CABECALHOS. */

                R2000_00_CABECALHOS_SECTION();
            }


            /*" -632- WRITE REG-PR0011B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-IMPRESSAO-GERAL-SECTION */
        private void R4000_00_IMPRESSAO_GERAL_SECTION()
        {
            /*" -644- MOVE '999' TO LD01-FONTE */
            _.Move("999", AREA_DE_WORK.LD01.LD01_FONTE);

            /*" -646- MOVE 'G E R A L' TO LD01-NOMEFTE */
            _.Move("G E R A L", AREA_DE_WORK.LD01.LD01_NOMEFTE);

            /*" -647- MOVE AC-INC-G TO LD01-INC */
            _.Move(AREA_DE_WORK.AC_INC_G, AREA_DE_WORK.LD01.LD01_INC);

            /*" -648- MOVE AC-AUT-G TO LD01-AUT */
            _.Move(AREA_DE_WORK.AC_AUT_G, AREA_DE_WORK.LD01.LD01_AUT);

            /*" -649- MOVE AC-TRA-G TO LD01-TRA */
            _.Move(AREA_DE_WORK.AC_TRA_G, AREA_DE_WORK.LD01.LD01_TRA);

            /*" -650- MOVE AC-VID-G TO LD01-VID */
            _.Move(AREA_DE_WORK.AC_VID_G, AREA_DE_WORK.LD01.LD01_VID);

            /*" -651- MOVE AC-OUT-G TO LD01-OUT */
            _.Move(AREA_DE_WORK.AC_OUT_G, AREA_DE_WORK.LD01.LD01_OUT);

            /*" -653- MOVE AC-TOT-G TO LD01-TOT */
            _.Move(AREA_DE_WORK.AC_TOT_G, AREA_DE_WORK.LD01.LD01_TOT);

            /*" -654- ADD 1 TO AC-LINHAS */
            AREA_DE_WORK.AC_LINHAS.Value = AREA_DE_WORK.AC_LINHAS + 1;

            /*" -655- IF AC-LINHAS GREATER 58 */

            if (AREA_DE_WORK.AC_LINHAS > 58)
            {

                /*" -657- PERFORM R2000-00-CABECALHOS. */

                R2000_00_CABECALHOS_SECTION();
            }


            /*" -659- WRITE REG-PR0011B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

            /*" -659- WRITE REG-PR0011B FROM LC08. */
            _.Move(AREA_DE_WORK.LC08.GetMoveValues(), REG_PR0011B);

            RPR0011B.Write(REG_PR0011B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-SELECT-V1FONTES-SECTION */
        private void R5000_00_SELECT_V1FONTES_SECTION()
        {
            /*" -672- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -677- PERFORM R5000_00_SELECT_V1FONTES_DB_SELECT_1 */

            R5000_00_SELECT_V1FONTES_DB_SELECT_1();

            /*" -680- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -682- DISPLAY 'PR0011B-FONTE NAO CADASTRADA' ' = ' V1ACOMPR-FONTE */

                $"PR0011B-FONTE NAO CADASTRADA = {V1ACOMPR_FONTE}"
                .Display();

                /*" -682- MOVE SPACES TO V1FONTES-NOMEFTE. */
                _.Move("", V1FONTES_NOMEFTE);
            }


        }

        [StopWatch]
        /*" R5000-00-SELECT-V1FONTES-DB-SELECT-1 */
        public void R5000_00_SELECT_V1FONTES_DB_SELECT_1()
        {
            /*" -677- EXEC SQL SELECT NOMEFTE INTO :V1FONTES-NOMEFTE FROM SEGUROS.V1FONTE WHERE FONTE = :V1ACOMPR-FONTE END-EXEC. */

            var r5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1 = new R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1()
            {
                V1ACOMPR_FONTE = V1ACOMPR_FONTE.ToString(),
            };

            var executed_1 = R5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1.Execute(r5000_00_SELECT_V1FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1FONTES_NOMEFTE, V1FONTES_NOMEFTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -693- OPEN OUTPUT RPR0011B. */
            RPR0011B.Open(REG_PR0011B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -704- CLOSE RPR0011B. */
            RPR0011B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -719- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -721- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -723- CLOSE RPR0011B */
            RPR0011B.Close();

            /*" -723- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -725- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}