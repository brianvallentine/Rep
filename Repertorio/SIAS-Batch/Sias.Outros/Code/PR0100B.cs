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
using Sias.Outros.DB2.PR0100B;

namespace Code
{
    public class PR0100B
    {
        public bool IsCall { get; set; }

        public PR0100B()
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
        /*"      *  *     PROGRAMA............ PR0100B                            *      */
        /*"      *  *     ANALISTA/PROGRAMADOR PROCAS                             *      */
        /*"      *  *                                                             *      */
        /*"      *  *     TABELAS............. FONTES PRODUTORAS    (TGEFONTE)    *      */
        /*"      *  *                          RAMOS/MODALIDADES    (TGERAMO)     *      */
        /*"      *  *                          SISTEMAS             (TSISTEMA)    *      */
        /*"      *  *                                                             *      */
        /*"      *  *     FUNCAO.............. EMITE RELACAO DE OPERACOES         *      */
        /*"      *  *                          CADASTRADAS - PROPOSTAS E          *      */
        /*"      *  *                          SINISTROS                          *      */
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

        public FileBasis _RPR0100B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RPR0100B
        {
            get
            {
                _.Move(REG_PR0100B, _RPR0100B); VarBasis.RedefinePassValue(REG_PR0100B, _RPR0100B, REG_PR0100B); return _RPR0100B;
            }
        }
        /*"01              REG-PR0100B.*/
        public PR0100B_REG_PR0100B REG_PR0100B { get; set; } = new PR0100B_REG_PR0100B();
        public class PR0100B_REG_PR0100B : VarBasis
        {
            /*"  05            REG-LINHA             PIC  X(132).*/
            public StringBasis REG_LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis IX1 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis IX2 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77              V1EMPRESA-COD-EMP       PIC S9(004)       COMP.*/
        public IntBasis V1EMPRESA_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              V1EMPRESA-NOM-EMP       PIC  X(040).*/
        public StringBasis V1EMPRESA_NOM_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77              V1RELATO-IDSISTEM       PIC X(002).*/
        public StringBasis V1RELATO_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77              V1RELATO-CODRELAT       PIC X(008).*/
        public StringBasis V1RELATO_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77              V1RELATO-SITUACAO       PIC X(001).*/
        public StringBasis V1RELATO_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77              V1SIST-DTCURRENT        PIC X(010).*/
        public StringBasis V1SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77              TCODOPER-OPERACAO       PIC S9(004)    COMP.*/
        public IntBasis TCODOPER_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              TCODOPER-DESOPR         PIC X(040).*/
        public StringBasis TCODOPER_DESOPR { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77              TCODOPER-TIPROC         PIC X(001).*/
        public StringBasis TCODOPER_TIPROC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77              TCODOPER-ARENVOLV       PIC X(001).*/
        public StringBasis TCODOPER_ARENVOLV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01              AREA-DE-WORK.*/
        public PR0100B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new PR0100B_AREA_DE_WORK();
        public class PR0100B_AREA_DE_WORK : VarBasis
        {
            /*"  05            FILLER          PIC  X(035)    VALUE                'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"  05            WSTATUS         PIC  X(002)   VALUE   ZEROS.*/
            public StringBasis WSTATUS { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05            WZEROS          PIC S9(003)   VALUE  +0  COMP-3.*/
            public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05            WRESTO          PIC S9(003)   VALUE  +0  COMP-3.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05            AC-OCORRENCIAS  PIC  9(001)   VALUE   ZEROS.*/
            public IntBasis AC_OCORRENCIAS { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"  05            WCH-MONTATIT    PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WCH_MONTATIT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-V1RELATO   PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_V1RELATO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WFIM-TABELA     PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WFIM_TABELA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WTEM1           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WTEM1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WTEM2           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WTEM2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WTEM3           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WTEM3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WTEM4           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WTEM4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WTEM5           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WTEM5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            WTEM6           PIC  X(001)   VALUE   SPACES.*/
            public StringBasis WTEM6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05            AC-LINHAS       PIC S9(002)   VALUE  +80.*/
            public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("S9", "2", "S9(002)"), +80);
            /*"  05            AC-PAGINA       PIC S9(006)   VALUE   ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
            /*"  05         WDATA-CURRENT     PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         FILLER            REDEFINES      WDATA-CURRENT.*/
            private _REDEF_PR0100B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PR0100B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PR0100B_FILLER_1(); _.Move(WDATA_CURRENT, _filler_1); VarBasis.RedefinePassValue(WDATA_CURRENT, _filler_1, WDATA_CURRENT); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_CURRENT); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_CURRENT); }
            }  //Redefines
            public class _REDEF_PR0100B_FILLER_1 : VarBasis
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

                public _REDEF_PR0100B_FILLER_1()
                {
                    WDATA_CURR_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_CURR_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDATA_CURR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public PR0100B_WS_DATE WS_DATE { get; set; } = new PR0100B_WS_DATE();
            public class PR0100B_WS_DATE : VarBasis
            {
                /*"    10          WS-AA-DATE          PIC  9(004) VALUE ZEROS.*/
                public IntBasis WS_AA_DATE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          WS-MM-DATE          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_MM_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10          WS-DD-DATE          PIC  9(002) VALUE ZEROS.*/
                public IntBasis WS_DD_DATE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05            WS-TIME.*/
            }
            public PR0100B_WS_TIME WS_TIME { get; set; } = new PR0100B_WS_TIME();
            public class PR0100B_WS_TIME : VarBasis
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
            public PR0100B_WDATA_CABEC WDATA_CABEC { get; set; } = new PR0100B_WDATA_CABEC();
            public class PR0100B_WDATA_CABEC : VarBasis
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
            public PR0100B_WHORA_CABEC WHORA_CABEC { get; set; } = new PR0100B_WHORA_CABEC();
            public class PR0100B_WHORA_CABEC : VarBasis
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
                /*"  05            CH-CHAVE-ATU.*/
            }
            public PR0100B_CH_CHAVE_ATU CH_CHAVE_ATU { get; set; } = new PR0100B_CH_CHAVE_ATU();
            public class PR0100B_CH_CHAVE_ATU : VarBasis
            {
                /*"    10          CH-TIPRO-ATU     PIC  X(001)   VALUE LOW-VALUES.*/
                public StringBasis CH_TIPRO_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
                /*"    10          CH-ARENV-ATU     PIC  X(001)   VALUE LOW-VALUES.*/
                public StringBasis CH_ARENV_ATU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
                /*"  05            CH-CHAVE-ANT.*/
            }
            public PR0100B_CH_CHAVE_ANT CH_CHAVE_ANT { get; set; } = new PR0100B_CH_CHAVE_ANT();
            public class PR0100B_CH_CHAVE_ANT : VarBasis
            {
                /*"    10          CH-TIPRO-ANT     PIC  X(001)   VALUE LOW-VALUES.*/
                public StringBasis CH_TIPRO_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
                /*"    10          CH-ARENV-ANT     PIC  X(001)   VALUE LOW-VALUES.*/
                public StringBasis CH_ARENV_ANT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"S");
                /*"  03            LC01.*/
            }
            public PR0100B_LC01 LC01 { get; set; } = new PR0100B_LC01();
            public class PR0100B_LC01 : VarBasis
            {
                /*"    05          LC01-RELATORIO  PIC  X(007) VALUE 'PR0100B'.*/
                public StringBasis LC01_RELATORIO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"PR0100B");
                /*"    05          FILLER          PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    05          LC01-EMPRESA    PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC01_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER          PIC  X(034) VALUE  SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"");
                /*"    05          FILLER          PIC  X(011) VALUE 'PAGINA'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
                /*"    05          LC01-PAGINA     PIC  ZZZ9.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"  03            LC02.*/
            }
            public PR0100B_LC02 LC02 { get; set; } = new PR0100B_LC02();
            public class PR0100B_LC02 : VarBasis
            {
                /*"    05          FILLER          PIC  X(117) VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "117", "X(117)"), @"");
                /*"    05          FILLER          PIC  X(005) VALUE 'DATA'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA");
                /*"    05          LC02-DATA       PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC02_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"  03            LC03.*/
            }
            public PR0100B_LC03 LC03 { get; set; } = new PR0100B_LC03();
            public class PR0100B_LC03 : VarBasis
            {
                /*"    05          FILLER          PIC  X(040) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05          FILLER          PIC  X(077) VALUE               '      RELACAO DE OPERACOES CADASTRADAS'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "77", "X(077)"), @"      RELACAO DE OPERACOES CADASTRADAS");
                /*"    05          FILLER          PIC  X(007) VALUE 'HORA'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA");
                /*"    05          LC03-HORA       PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC03_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05            LC04.*/
            }
            public PR0100B_LC04 LC04 { get; set; } = new PR0100B_LC04();
            public class PR0100B_LC04 : VarBasis
            {
                /*"    10          FILLER          PIC  X(058) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "58", "X(058)"), @"");
                /*"    10          LC04-OPERACAO   PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_OPERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10          FILLER          PIC  X(064) VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "64", "X(064)"), @"");
                /*"  05            LC05.*/
            }
            public PR0100B_LC05 LC05 { get; set; } = new PR0100B_LC05();
            public class PR0100B_LC05 : VarBasis
            {
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(043) VALUE  ALL '-'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"ALL");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(043) VALUE  ALL '-'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "43", "X(043)"), @"ALL");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"    10          FILLER          PIC  X(042) VALUE  ALL '-'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"ALL");
                /*"    10          FILLER          PIC  X(001) VALUE '+'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"+");
                /*"  05            LC06.*/
            }
            public PR0100B_LC06 LC06 { get; set; } = new PR0100B_LC06();
            public class PR0100B_LC06 : VarBasis
            {
                /*"    10          FILLER          PIC  X(015) VALUE 'I'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"I");
                /*"    10          LC06-AREA1      PIC  X(014) VALUE  SPACES.*/
                public StringBasis LC06_AREA1 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10          FILLER          PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10          FILLER          PIC  X(015) VALUE 'I'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"I");
                /*"    10          LC06-AREA2      PIC  X(014) VALUE  SPACES.*/
                public StringBasis LC06_AREA2 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10          FILLER          PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10          FILLER          PIC  X(015) VALUE 'I'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"I");
                /*"    10          LC06-AREA3      PIC  X(014) VALUE  SPACES.*/
                public StringBasis LC06_AREA3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10          FILLER          PIC  X(014) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05            LD01.*/
            }
            public PR0100B_LD01 LD01 { get; set; } = new PR0100B_LD01();
            public class PR0100B_LD01 : VarBasis
            {
                /*"    10          FILLER          PIC  X(002) VALUE 'I'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"I");
                /*"    10          LD01-CODOPER1   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LD01_CODOPER1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          LD01-CODOPER1R  REDEFINES   LD01-CODOPER1                                PIC  X(004).*/
                private _REDEF_StringBasis _ld01_codoper1r { get; set; }
                public _REDEF_StringBasis LD01_CODOPER1R
                {
                    get { _ld01_codoper1r = new _REDEF_StringBasis(new PIC("X", "004", "X(004).")); ; _.Move(LD01_CODOPER1, _ld01_codoper1r); VarBasis.RedefinePassValue(LD01_CODOPER1, _ld01_codoper1r, LD01_CODOPER1); _ld01_codoper1r.ValueChanged += () => { _.Move(_ld01_codoper1r, LD01_CODOPER1); }; return _ld01_codoper1r; }
                    set { VarBasis.RedefinePassValue(value, _ld01_codoper1r, LD01_CODOPER1); }
                }  //Redefines
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NOMOPER1   PIC  X(036) VALUE  SPACES.*/
                public StringBasis LD01_NOMOPER1 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          FILLER          PIC  X(003) VALUE ' I'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" I");
                /*"    10          LD01-CODOPER2   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LD01_CODOPER2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          LD01-CODOPER2R  REDEFINES   LD01-CODOPER2                                PIC  X(004).*/
                private _REDEF_StringBasis _ld01_codoper2r { get; set; }
                public _REDEF_StringBasis LD01_CODOPER2R
                {
                    get { _ld01_codoper2r = new _REDEF_StringBasis(new PIC("X", "004", "X(004).")); ; _.Move(LD01_CODOPER2, _ld01_codoper2r); VarBasis.RedefinePassValue(LD01_CODOPER2, _ld01_codoper2r, LD01_CODOPER2); _ld01_codoper2r.ValueChanged += () => { _.Move(_ld01_codoper2r, LD01_CODOPER2); }; return _ld01_codoper2r; }
                    set { VarBasis.RedefinePassValue(value, _ld01_codoper2r, LD01_CODOPER2); }
                }  //Redefines
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NOMOPER2   PIC  X(036) VALUE  SPACES.*/
                public StringBasis LD01_NOMOPER2 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          FILLER          PIC  X(003) VALUE ' I'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" I");
                /*"    10          LD01-CODOPER3   PIC  9(004) VALUE  ZEROS.*/
                public IntBasis LD01_CODOPER3 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          LD01-CODOPER3R  REDEFINES   LD01-CODOPER3                                PIC  X(004).*/
                private _REDEF_StringBasis _ld01_codoper3r { get; set; }
                public _REDEF_StringBasis LD01_CODOPER3R
                {
                    get { _ld01_codoper3r = new _REDEF_StringBasis(new PIC("X", "004", "X(004).")); ; _.Move(LD01_CODOPER3, _ld01_codoper3r); VarBasis.RedefinePassValue(LD01_CODOPER3, _ld01_codoper3r, LD01_CODOPER3); _ld01_codoper3r.ValueChanged += () => { _.Move(_ld01_codoper3r, LD01_CODOPER3); }; return _ld01_codoper3r; }
                    set { VarBasis.RedefinePassValue(value, _ld01_codoper3r, LD01_CODOPER3); }
                }  //Redefines
                /*"    10          FILLER          PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          LD01-NOMOPER3   PIC  X(036) VALUE  SPACES.*/
                public StringBasis LD01_NOMOPER3 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          FILLER          PIC  X(001) VALUE 'I'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"I");
                /*"  05            TBOPER-MAS1.*/
            }
            public PR0100B_TBOPER_MAS1 TBOPER_MAS1 { get; set; } = new PR0100B_TBOPER_MAS1();
            public class PR0100B_TBOPER_MAS1 : VarBasis
            {
                /*"    10          FILLER            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis FILLER_39 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER            PIC  X(036)    VALUE SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10          TB-OPER1.*/
                public PR0100B_TB_OPER1 TB_OPER1 { get; set; } = new PR0100B_TB_OPER1();
                public class PR0100B_TB_OPER1 : VarBasis
                {
                    /*"      15        TB-OPERA          OCCURS         50                                  INDEXED  BY    IX1.*/
                    public ListBasis<PR0100B_TB_OPERA> TB_OPERA { get; set; } = new ListBasis<PR0100B_TB_OPERA>(50);
                    public class PR0100B_TB_OPERA : VarBasis
                    {
                        /*"        20      TB-CODOPE1        PIC  9(004).*/
                        public IntBasis TB_CODOPE1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"        20      TB-NOMOPE1        PIC  X(036).*/
                        public StringBasis TB_NOMOPE1 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
                        /*"        20      TB-ARENVO1        PIC  X(001).*/
                        public StringBasis TB_ARENVO1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"  05            TBOPER-MAS2.*/
                    }
                }
            }
            public PR0100B_TBOPER_MAS2 TBOPER_MAS2 { get; set; } = new PR0100B_TBOPER_MAS2();
            public class PR0100B_TBOPER_MAS2 : VarBasis
            {
                /*"    10          FILLER            PIC  9(004)    VALUE ZEROS.*/
                public IntBasis FILLER_42 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10          FILLER            PIC  X(036)    VALUE SPACES.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10          TB-OPER2.*/
                public PR0100B_TB_OPER2 TB_OPER2 { get; set; } = new PR0100B_TB_OPER2();
                public class PR0100B_TB_OPER2 : VarBasis
                {
                    /*"      15        TB-OPERA          OCCURS         150                                  INDEXED  BY    IX2.*/
                    public ListBasis<PR0100B_TB_OPERA_0> TB_OPERA_0 { get; set; } = new ListBasis<PR0100B_TB_OPERA_0>(150);
                    public class PR0100B_TB_OPERA_0 : VarBasis
                    {
                        /*"        20      TB-CODOPE2        PIC  9(004).*/
                        public IntBasis TB_CODOPE2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                        /*"        20      TB-NOMOPE2        PIC  X(036).*/
                        public StringBasis TB_NOMOPE2 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)."), @"");
                        /*"  05        WABEND.*/
                    }
                }
            }
            public PR0100B_WABEND WABEND { get; set; } = new PR0100B_WABEND();
            public class PR0100B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' PR0100B'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" PR0100B");
                /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01          LK-LINK.*/
            }
        }
        public PR0100B_LK_LINK LK_LINK { get; set; } = new PR0100B_LK_LINK();
        public class PR0100B_LK_LINK : VarBasis
        {
            /*"  03        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  03        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
        }


        public PR0100B_V1CODOPER V1CODOPER { get; set; } = new PR0100B_V1CODOPER();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RPR0100B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RPR0100B.SetFile(RPR0100B_FILE_NAME_P);

                /*" -321- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -322- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -325- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

                /*" -328- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -328- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

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
            /*" -337- PERFORM R0500-00-SELECT-V1RELATO */

            R0500_00_SELECT_V1RELATO_SECTION();

            /*" -338- IF WFIM-V1RELATO NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V1RELATO.IsEmpty())
            {

                /*" -340- GO TO R0000-90-ENCERRA. */

                R0000_90_ENCERRA(); //GOTO
                return;
            }


            /*" -342- PERFORM R0015-00-CABECALHOS */

            R0015_00_CABECALHOS_SECTION();

            /*" -344- PERFORM R8000-00-OPEN-ARQUIVOS */

            R8000_00_OPEN_ARQUIVOS_SECTION();

            /*" -346- PERFORM R0900-00-DECLARE-V1CODOPER */

            R0900_00_DECLARE_V1CODOPER_SECTION();

            /*" -348- PERFORM R0910-00-FETCH-V1CODOPER */

            R0910_00_FETCH_V1CODOPER_SECTION();

            /*" -351- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL CH-CHAVE-ATU EQUAL HIGH-VALUES */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -353- PERFORM R7000-00-DELETE-V1RELATO */

            R7000_00_DELETE_V1RELATO_SECTION();

            /*" -353- PERFORM R9000-00-CLOSE-ARQUIVOS. */

            R9000_00_CLOSE_ARQUIVOS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_ENCERRA */

            R0000_90_ENCERRA();

        }

        [StopWatch]
        /*" R0000-90-ENCERRA */
        private void R0000_90_ENCERRA(bool isPerform = false)
        {
            /*" -359- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -361- DISPLAY 'PR0100B - FIM NORMAL' */
            _.Display($"PR0100B - FIM NORMAL");

            /*" -361- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-CABECALHOS-SECTION */
        private void R0015_00_CABECALHOS_SECTION()
        {
            /*" -374- ACCEPT WS-TIME FROM TIME */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_TIME);

            /*" -375- MOVE WS-DD-DATE TO WDATA-DD-CABEC */
            _.Move(AREA_DE_WORK.WS_DATE.WS_DD_DATE, AREA_DE_WORK.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -376- MOVE WS-MM-DATE TO WDATA-MM-CABEC */
            _.Move(AREA_DE_WORK.WS_DATE.WS_MM_DATE, AREA_DE_WORK.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -377- MOVE WS-AA-DATE TO WDATA-AA-CABEC */
            _.Move(AREA_DE_WORK.WS_DATE.WS_AA_DATE, AREA_DE_WORK.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -378- MOVE WDATA-CABEC TO LC02-DATA */
            _.Move(AREA_DE_WORK.WDATA_CABEC, AREA_DE_WORK.LC02.LC02_DATA);

            /*" -379- MOVE WS-HH-TIME TO WHORA-HH-CABEC */
            _.Move(AREA_DE_WORK.WS_TIME.WS_HH_TIME, AREA_DE_WORK.WHORA_CABEC.WHORA_HH_CABEC);

            /*" -380- MOVE WS-MM-TIME TO WHORA-MM-CABEC */
            _.Move(AREA_DE_WORK.WS_TIME.WS_MM_TIME, AREA_DE_WORK.WHORA_CABEC.WHORA_MM_CABEC);

            /*" -381- MOVE WS-SS-TIME TO WHORA-SS-CABEC */
            _.Move(AREA_DE_WORK.WS_TIME.WS_SS_TIME, AREA_DE_WORK.WHORA_CABEC.WHORA_SS_CABEC);

            /*" -383- MOVE WHORA-CABEC TO LC03-HORA */
            _.Move(AREA_DE_WORK.WHORA_CABEC, AREA_DE_WORK.LC03.LC03_HORA);

            /*" -387- PERFORM R0015_00_CABECALHOS_DB_SELECT_1 */

            R0015_00_CABECALHOS_DB_SELECT_1();

            /*" -390- MOVE V1EMPRESA-NOM-EMP TO LK-TITULO */
            _.Move(V1EMPRESA_NOM_EMP, LK_LINK.LK_TITULO);

            /*" -392- CALL 'PROALN01' USING LK-LINK */
            _.Call("PROALN01", LK_LINK);

            /*" -393- IF LK-RTCODE EQUAL ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -394- MOVE LK-TITULO TO LC01-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_WORK.LC01.LC01_EMPRESA);

                /*" -395- ELSE */
            }
            else
            {


                /*" -396- DISPLAY 'PROBLEMA CALL V1EMPRESA' */
                _.Display($"PROBLEMA CALL V1EMPRESA");

                /*" -396- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


        }

        [StopWatch]
        /*" R0015-00-CABECALHOS-DB-SELECT-1 */
        public void R0015_00_CABECALHOS_DB_SELECT_1()
        {
            /*" -387- EXEC SQL SELECT NOME_EMPRESA INTO :V1EMPRESA-NOM-EMP FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

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
        /*" R0500-00-SELECT-V1RELATO-SECTION */
        private void R0500_00_SELECT_V1RELATO_SECTION()
        {
            /*" -409- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -421- PERFORM R0500_00_SELECT_V1RELATO_DB_SELECT_1 */

            R0500_00_SELECT_V1RELATO_DB_SELECT_1();

            /*" -424- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -425- DISPLAY 'PR0100B - NAO HOVE PEDIDO DE EMISSAO' */
                _.Display($"PR0100B - NAO HOVE PEDIDO DE EMISSAO");

                /*" -427- MOVE 'S' TO WFIM-V1RELATO. */
                _.Move("S", AREA_DE_WORK.WFIM_V1RELATO);
            }


            /*" -428- MOVE V1SIST-DTCURRENT TO WDATA-CURRENT */
            _.Move(V1SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURRENT);

            /*" -429- MOVE WDATA-CURR-DIA TO WS-DD-DATE */
            _.Move(AREA_DE_WORK.FILLER_1.WDATA_CURR_DIA, AREA_DE_WORK.WS_DATE.WS_DD_DATE);

            /*" -430- MOVE WDATA-CURR-MES TO WS-MM-DATE */
            _.Move(AREA_DE_WORK.FILLER_1.WDATA_CURR_MES, AREA_DE_WORK.WS_DATE.WS_MM_DATE);

            /*" -430- MOVE WDATA-CURR-ANO TO WS-AA-DATE. */
            _.Move(AREA_DE_WORK.FILLER_1.WDATA_CURR_ANO, AREA_DE_WORK.WS_DATE.WS_AA_DATE);

        }

        [StopWatch]
        /*" R0500-00-SELECT-V1RELATO-DB-SELECT-1 */
        public void R0500_00_SELECT_V1RELATO_DB_SELECT_1()
        {
            /*" -421- EXEC SQL SELECT IDSISTEM, CODRELAT, SITUACAO, CURRENT DATE INTO :V1RELATO-IDSISTEM, :V1RELATO-CODRELAT, :V1RELATO-SITUACAO, :V1SIST-DTCURRENT FROM SEGUROS.V1RELATORIOS WHERE IDSISTEM = 'PR' AND CODRELAT = 'PR0100B1' END-EXEC. */

            var r0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1 = new R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_V1RELATO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1RELATO_IDSISTEM, V1RELATO_IDSISTEM);
                _.Move(executed_1.V1RELATO_CODRELAT, V1RELATO_CODRELAT);
                _.Move(executed_1.V1RELATO_SITUACAO, V1RELATO_SITUACAO);
                _.Move(executed_1.V1SIST_DTCURRENT, V1SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V1CODOPER-SECTION */
        private void R0900_00_DECLARE_V1CODOPER_SECTION()
        {
            /*" -443- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -451- PERFORM R0900_00_DECLARE_V1CODOPER_DB_DECLARE_1 */

            R0900_00_DECLARE_V1CODOPER_DB_DECLARE_1();

            /*" -453- PERFORM R0900_00_DECLARE_V1CODOPER_DB_OPEN_1 */

            R0900_00_DECLARE_V1CODOPER_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1CODOPER-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V1CODOPER_DB_DECLARE_1()
        {
            /*" -451- EXEC SQL DECLARE V1CODOPER CURSOR FOR SELECT OPERACAO, DESOPR, TIPROC, ARENVOLV FROM SEGUROS.V1CODOPER WHERE SITUACAO �= '2' ORDER BY TIPROC, ARENVOLV, OPERACAO END-EXEC. */
            V1CODOPER = new PR0100B_V1CODOPER(false);
            string GetQuery_V1CODOPER()
            {
                var query = @$"SELECT OPERACAO
							, 
							DESOPR
							, 
							TIPROC
							, 
							ARENVOLV 
							FROM SEGUROS.V1CODOPER 
							WHERE SITUACAO �= '2' 
							ORDER BY TIPROC
							, ARENVOLV
							, OPERACAO";

                return query;
            }
            V1CODOPER.GetQueryEvent += GetQuery_V1CODOPER;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V1CODOPER-DB-OPEN-1 */
        public void R0900_00_DECLARE_V1CODOPER_DB_OPEN_1()
        {
            /*" -453- EXEC SQL OPEN V1CODOPER END-EXEC. */

            V1CODOPER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V1CODOPER-SECTION */
        private void R0910_00_FETCH_V1CODOPER_SECTION()
        {
            /*" -466- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -471- PERFORM R0910_00_FETCH_V1CODOPER_DB_FETCH_1 */

            R0910_00_FETCH_V1CODOPER_DB_FETCH_1();

            /*" -474- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -475- MOVE HIGH-VALUES TO CH-CHAVE-ATU */

                AREA_DE_WORK.CH_CHAVE_ATU.IsHighValues = true;

                /*" -475- PERFORM R0910_00_FETCH_V1CODOPER_DB_CLOSE_1 */

                R0910_00_FETCH_V1CODOPER_DB_CLOSE_1();

                /*" -478- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -479- MOVE TCODOPER-TIPROC TO CH-TIPRO-ATU */
            _.Move(TCODOPER_TIPROC, AREA_DE_WORK.CH_CHAVE_ATU.CH_TIPRO_ATU);

            /*" -479- MOVE TCODOPER-ARENVOLV TO CH-ARENV-ATU. */
            _.Move(TCODOPER_ARENVOLV, AREA_DE_WORK.CH_CHAVE_ATU.CH_ARENV_ATU);

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1CODOPER-DB-FETCH-1 */
        public void R0910_00_FETCH_V1CODOPER_DB_FETCH_1()
        {
            /*" -471- EXEC SQL FETCH V1CODOPER INTO :TCODOPER-OPERACAO, :TCODOPER-DESOPR, :TCODOPER-TIPROC, :TCODOPER-ARENVOLV END-EXEC. */

            if (V1CODOPER.Fetch())
            {
                _.Move(V1CODOPER.TCODOPER_OPERACAO, TCODOPER_OPERACAO);
                _.Move(V1CODOPER.TCODOPER_DESOPR, TCODOPER_DESOPR);
                _.Move(V1CODOPER.TCODOPER_TIPROC, TCODOPER_TIPROC);
                _.Move(V1CODOPER.TCODOPER_ARENVOLV, TCODOPER_ARENVOLV);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V1CODOPER-DB-CLOSE-1 */
        public void R0910_00_FETCH_V1CODOPER_DB_CLOSE_1()
        {
            /*" -475- EXEC SQL CLOSE V1CODOPER END-EXEC */

            V1CODOPER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -492- MOVE CH-TIPRO-ATU TO CH-TIPRO-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU.CH_TIPRO_ATU, AREA_DE_WORK.CH_CHAVE_ANT.CH_TIPRO_ANT);

            /*" -493- PERFORM R1100-00-PROCESSA-TIPROC UNTIL CH-TIPRO-ATU NOT EQUAL CH-TIPRO-ANT. */

            while (!(AREA_DE_WORK.CH_CHAVE_ATU.CH_TIPRO_ATU != AREA_DE_WORK.CH_CHAVE_ANT.CH_TIPRO_ANT))
            {

                R1100_00_PROCESSA_TIPROC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-TIPROC-SECTION */
        private void R1100_00_PROCESSA_TIPROC_SECTION()
        {
            /*" -505- MOVE TBOPER-MAS2 TO TB-OPER2 */
            _.Move(AREA_DE_WORK.TBOPER_MAS2, AREA_DE_WORK.TBOPER_MAS2.TB_OPER2);

            /*" -507- SET IX2 TO WZEROS. */
            IX2.Value = AREA_DE_WORK.WZEROS;

            /*" -509- MOVE ZEROS TO AC-OCORRENCIAS */
            _.Move(0, AREA_DE_WORK.AC_OCORRENCIAS);

            /*" -513- PERFORM R1200-00-PROCESSA-ARENVOLV UNTIL (AC-OCORRENCIAS GREATER 2) OR (CH-TIPRO-ATU NOT EQUAL CH-TIPRO-ANT) */

            while (!((AREA_DE_WORK.AC_OCORRENCIAS > 2) || (AREA_DE_WORK.CH_CHAVE_ATU.CH_TIPRO_ATU != AREA_DE_WORK.CH_CHAVE_ANT.CH_TIPRO_ANT)))
            {

                R1200_00_PROCESSA_ARENVOLV_SECTION();
            }

            /*" -515- PERFORM R2000-00-CABECALHOS */

            R2000_00_CABECALHOS_SECTION();

            /*" -517- PERFORM R4000-00-DESCARREGA-IMPRESS */

            R4000_00_DESCARREGA_IMPRESS_SECTION();

            /*" -517- SET IX2 TO WZEROS. */
            IX2.Value = AREA_DE_WORK.WZEROS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-ARENVOLV-SECTION */
        private void R1200_00_PROCESSA_ARENVOLV_SECTION()
        {
            /*" -529- MOVE TBOPER-MAS1 TO TB-OPER1 */
            _.Move(AREA_DE_WORK.TBOPER_MAS1, AREA_DE_WORK.TBOPER_MAS1.TB_OPER1);

            /*" -531- SET IX1 TO WZEROS. */
            IX1.Value = AREA_DE_WORK.WZEROS;

            /*" -533- MOVE CH-CHAVE-ATU TO CH-CHAVE-ANT */
            _.Move(AREA_DE_WORK.CH_CHAVE_ATU, AREA_DE_WORK.CH_CHAVE_ANT);

            /*" -535- MOVE SPACES TO WCH-MONTATIT */
            _.Move("", AREA_DE_WORK.WCH_MONTATIT);

            /*" -539- PERFORM R1300-00-PROCESSA-OPERACAO UNTIL (CH-CHAVE-ATU NOT EQUAL CH-CHAVE-ANT) OR (IX1 GREATER +50) */

            while (!((AREA_DE_WORK.CH_CHAVE_ATU != AREA_DE_WORK.CH_CHAVE_ANT) || (IX1 > +50)))
            {

                R1300_00_PROCESSA_OPERACAO_SECTION();
            }

            /*" -541- ADD 1 TO AC-OCORRENCIAS */
            AREA_DE_WORK.AC_OCORRENCIAS.Value = AREA_DE_WORK.AC_OCORRENCIAS + 1;

            /*" -541- PERFORM R3000-00-MONTA-LINHAS-TAB. */

            R3000_00_MONTA_LINHAS_TAB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-PROCESSA-OPERACAO-SECTION */
        private void R1300_00_PROCESSA_OPERACAO_SECTION()
        {
            /*" -553- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -554- IF IX1 GREATER +50 */

            if (IX1 > +50)
            {

                /*" -556- GO TO R1300-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/ //GOTO
                return;
            }


            /*" -557- MOVE TCODOPER-OPERACAO TO TB-CODOPE1 (IX1) */
            _.Move(TCODOPER_OPERACAO, AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_CODOPE1);

            /*" -558- MOVE TCODOPER-DESOPR TO TB-NOMOPE1 (IX1) */
            _.Move(TCODOPER_DESOPR, AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_NOMOPE1);

            /*" -560- MOVE TCODOPER-ARENVOLV TO TB-ARENVO1 (IX1) */
            _.Move(TCODOPER_ARENVOLV, AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1);

            /*" -560- PERFORM R0910-00-FETCH-V1CODOPER. */

            R0910_00_FETCH_V1CODOPER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-CABECALHOS-SECTION */
        private void R2000_00_CABECALHOS_SECTION()
        {
            /*" -572- ADD 1 TO AC-PAGINA */
            AREA_DE_WORK.AC_PAGINA.Value = AREA_DE_WORK.AC_PAGINA + 1;

            /*" -574- MOVE AC-PAGINA TO LC01-PAGINA */
            _.Move(AREA_DE_WORK.AC_PAGINA, AREA_DE_WORK.LC01.LC01_PAGINA);

            /*" -575- IF CH-TIPRO-ANT EQUAL '1' */

            if (AREA_DE_WORK.CH_CHAVE_ANT.CH_TIPRO_ANT == "1")
            {

                /*" -576- MOVE 'PROPOSTAS' TO LC04-OPERACAO */
                _.Move("PROPOSTAS", AREA_DE_WORK.LC04.LC04_OPERACAO);

                /*" -577- ELSE */
            }
            else
            {


                /*" -579- MOVE 'SINISTROS' TO LC04-OPERACAO. */
                _.Move("SINISTROS", AREA_DE_WORK.LC04.LC04_OPERACAO);
            }


            /*" -580- WRITE REG-PR0100B FROM LC01 AFTER PAGE */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -581- WRITE REG-PR0100B FROM LC02 */
            _.Move(AREA_DE_WORK.LC02.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -582- WRITE REG-PR0100B FROM LC03 */
            _.Move(AREA_DE_WORK.LC03.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -583- WRITE REG-PR0100B FROM LC04 */
            _.Move(AREA_DE_WORK.LC04.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -584- WRITE REG-PR0100B FROM LC05 AFTER 2 */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -585- WRITE REG-PR0100B FROM LC06 */
            _.Move(AREA_DE_WORK.LC06.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -585- WRITE REG-PR0100B FROM LC05. */
            _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-MONTA-LINHAS-TAB-SECTION */
        private void R3000_00_MONTA_LINHAS_TAB_SECTION()
        {
            /*" -596- SET IX1 TO WZEROS. */
            IX1.Value = AREA_DE_WORK.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM R3000_10_LOOP */

            R3000_10_LOOP();

        }

        [StopWatch]
        /*" R3000-10-LOOP */
        private void R3000_10_LOOP(bool isPerform = false)
        {
            /*" -601- SET IX1 UP BY +1 */
            IX1.Value += +1;

            /*" -602- IF IX1 GREATER +50 */

            if (IX1 > +50)
            {

                /*" -604- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -605- SET IX2 UP BY +1 */
            IX2.Value += +1;

            /*" -606- IF IX2 GREATER +150 */

            if (IX2 > +150)
            {

                /*" -607- MOVE +5 TO AC-OCORRENCIAS */
                _.Move(+5, AREA_DE_WORK.AC_OCORRENCIAS);

                /*" -609- GO TO R3000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -610- MOVE TB-CODOPE1(IX1) TO TB-CODOPE2 (IX2) */
            _.Move(AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_CODOPE1, AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2].TB_CODOPE2);

            /*" -612- MOVE TB-NOMOPE1(IX1) TO TB-NOMOPE2 (IX2) */
            _.Move(AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_NOMOPE1, AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2].TB_NOMOPE2);

            /*" -613- IF WCH-MONTATIT EQUAL SPACES */

            if (AREA_DE_WORK.WCH_MONTATIT.IsEmpty())
            {

                /*" -615- PERFORM R3100-00-MONTA-TITULO. */

                R3100_00_MONTA_TITULO_SECTION();
            }


            /*" -615- GO TO R3000-10-LOOP. */
            new Task(() => R3000_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-MONTA-TITULO-SECTION */
        private void R3100_00_MONTA_TITULO_SECTION()
        {
            /*" -628- MOVE '*' TO WCH-MONTATIT */
            _.Move("*", AREA_DE_WORK.WCH_MONTATIT);

            /*" -629- IF AC-OCORRENCIAS EQUAL 1 */

            if (AREA_DE_WORK.AC_OCORRENCIAS == 1)
            {

                /*" -630- IF TB-ARENVO1(IX1) EQUAL '1' */

                if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "1")
                {

                    /*" -631- MOVE '   VISTORIA   ' TO LC06-AREA1 */
                    _.Move("   VISTORIA   ", AREA_DE_WORK.LC06.LC06_AREA1);

                    /*" -632- ELSE */
                }
                else
                {


                    /*" -633- IF TB-ARENVO1(IX1) EQUAL '2' */

                    if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "2")
                    {

                        /*" -634- MOVE '   TECNICA    ' TO LC06-AREA1 */
                        _.Move("   TECNICA    ", AREA_DE_WORK.LC06.LC06_AREA1);

                        /*" -635- ELSE */
                    }
                    else
                    {


                        /*" -636- IF TB-ARENVO1(IX1) EQUAL '3' */

                        if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "3")
                        {

                            /*" -637- MOVE '  COMERCIAL   ' TO LC06-AREA1 */
                            _.Move("  COMERCIAL   ", AREA_DE_WORK.LC06.LC06_AREA1);

                            /*" -638- ELSE */
                        }
                        else
                        {


                            /*" -639- IF TB-ARENVO1(IX1) EQUAL '4' */

                            if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "4")
                            {

                                /*" -640- MOVE 'ADMINISTRATIVA' TO LC06-AREA1 */
                                _.Move("ADMINISTRATIVA", AREA_DE_WORK.LC06.LC06_AREA1);

                                /*" -641- ELSE */
                            }
                            else
                            {


                                /*" -642- IF TB-ARENVO1(IX1) EQUAL '5' */

                                if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "5")
                                {

                                    /*" -643- MOVE '  FINANCEIRA  ' TO LC06-AREA1 */
                                    _.Move("  FINANCEIRA  ", AREA_DE_WORK.LC06.LC06_AREA1);

                                    /*" -644- ELSE */
                                }
                                else
                                {


                                    /*" -646- IF TB-ARENVO1(IX1) EQUAL '6' OR TB-ARENVO1(IX1) EQUAL '9' */

                                    if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "6" || AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "9")
                                    {

                                        /*" -647- MOVE '    OUTROS    ' TO LC06-AREA1 */
                                        _.Move("    OUTROS    ", AREA_DE_WORK.LC06.LC06_AREA1);

                                        /*" -648- ELSE */
                                    }
                                    else
                                    {


                                        /*" -649- DISPLAY 'TIPO DE AREA INVALIDO ' TB-ARENVO1(IX1) */
                                        _.Display($"TIPO DE AREA INVALIDO {AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1]}");

                                        /*" -650- STOP RUN */

                                        throw new GoBack();   // => STOP RUN.

                                        /*" -651- ELSE */
                                    }

                                }

                            }

                        }

                    }

                }

            }
            else
            {


                /*" -652- IF AC-OCORRENCIAS EQUAL 2 */

                if (AREA_DE_WORK.AC_OCORRENCIAS == 2)
                {

                    /*" -653- IF TB-ARENVO1(IX1) EQUAL '1' */

                    if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "1")
                    {

                        /*" -654- MOVE '   VISTORIA   ' TO LC06-AREA2 */
                        _.Move("   VISTORIA   ", AREA_DE_WORK.LC06.LC06_AREA2);

                        /*" -655- ELSE */
                    }
                    else
                    {


                        /*" -656- IF TB-ARENVO1(IX1) EQUAL '2' */

                        if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "2")
                        {

                            /*" -657- MOVE '   TECNICA    ' TO LC06-AREA2 */
                            _.Move("   TECNICA    ", AREA_DE_WORK.LC06.LC06_AREA2);

                            /*" -658- ELSE */
                        }
                        else
                        {


                            /*" -659- IF TB-ARENVO1(IX1) EQUAL '3' */

                            if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "3")
                            {

                                /*" -660- MOVE '  COMERCIAL   ' TO LC06-AREA2 */
                                _.Move("  COMERCIAL   ", AREA_DE_WORK.LC06.LC06_AREA2);

                                /*" -661- ELSE */
                            }
                            else
                            {


                                /*" -662- IF TB-ARENVO1(IX1) EQUAL '4' */

                                if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "4")
                                {

                                    /*" -663- MOVE 'ADMINISTRATIVA' TO LC06-AREA2 */
                                    _.Move("ADMINISTRATIVA", AREA_DE_WORK.LC06.LC06_AREA2);

                                    /*" -664- ELSE */
                                }
                                else
                                {


                                    /*" -665- IF TB-ARENVO1(IX1) EQUAL '5' */

                                    if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "5")
                                    {

                                        /*" -666- MOVE '  FINANCEIRA  ' TO LC06-AREA2 */
                                        _.Move("  FINANCEIRA  ", AREA_DE_WORK.LC06.LC06_AREA2);

                                        /*" -667- ELSE */
                                    }
                                    else
                                    {


                                        /*" -669- IF TB-ARENVO1(IX1) EQUAL '6' OR TB-ARENVO1(IX1) EQUAL '9' */

                                        if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "6" || AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "9")
                                        {

                                            /*" -670- MOVE '    OUTROS    ' TO LC06-AREA2 */
                                            _.Move("    OUTROS    ", AREA_DE_WORK.LC06.LC06_AREA2);

                                            /*" -671- ELSE */
                                        }
                                        else
                                        {


                                            /*" -672- DISPLAY 'TIPO DE AREA INVALIDO ' TB-ARENVO1(IX1) */
                                            _.Display($"TIPO DE AREA INVALIDO {AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1]}");

                                            /*" -673- STOP RUN */

                                            throw new GoBack();   // => STOP RUN.

                                            /*" -674- ELSE */
                                        }

                                    }

                                }

                            }

                        }

                    }

                }
                else
                {


                    /*" -675- IF AC-OCORRENCIAS EQUAL 3 */

                    if (AREA_DE_WORK.AC_OCORRENCIAS == 3)
                    {

                        /*" -676- IF TB-ARENVO1(IX1) EQUAL '1' */

                        if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "1")
                        {

                            /*" -677- MOVE '   VISTORIA   ' TO LC06-AREA3 */
                            _.Move("   VISTORIA   ", AREA_DE_WORK.LC06.LC06_AREA3);

                            /*" -678- ELSE */
                        }
                        else
                        {


                            /*" -679- IF TB-ARENVO1(IX1) EQUAL '2' */

                            if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "2")
                            {

                                /*" -680- MOVE '   TECNICA    ' TO LC06-AREA3 */
                                _.Move("   TECNICA    ", AREA_DE_WORK.LC06.LC06_AREA3);

                                /*" -681- ELSE */
                            }
                            else
                            {


                                /*" -682- IF TB-ARENVO1(IX1) EQUAL '3' */

                                if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "3")
                                {

                                    /*" -683- MOVE '  COMERCIAL   ' TO LC06-AREA3 */
                                    _.Move("  COMERCIAL   ", AREA_DE_WORK.LC06.LC06_AREA3);

                                    /*" -684- ELSE */
                                }
                                else
                                {


                                    /*" -685- IF TB-ARENVO1(IX1) EQUAL '4' */

                                    if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "4")
                                    {

                                        /*" -686- MOVE 'ADMINISTRATIVA' TO LC06-AREA3 */
                                        _.Move("ADMINISTRATIVA", AREA_DE_WORK.LC06.LC06_AREA3);

                                        /*" -687- ELSE */
                                    }
                                    else
                                    {


                                        /*" -688- IF TB-ARENVO1(IX1) EQUAL '5' */

                                        if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "5")
                                        {

                                            /*" -689- MOVE '  FINANCEIRA  ' TO LC06-AREA3 */
                                            _.Move("  FINANCEIRA  ", AREA_DE_WORK.LC06.LC06_AREA3);

                                            /*" -690- ELSE */
                                        }
                                        else
                                        {


                                            /*" -692- IF TB-ARENVO1(IX1) EQUAL '6' OR TB-ARENVO1(IX1) EQUAL '9' */

                                            if (AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "6" || AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1].TB_ARENVO1 == "9")
                                            {

                                                /*" -693- MOVE '    OUTROS    ' TO LC06-AREA3 */
                                                _.Move("    OUTROS    ", AREA_DE_WORK.LC06.LC06_AREA3);

                                                /*" -694- ELSE */
                                            }
                                            else
                                            {


                                                /*" -695- DISPLAY 'TIPO DE AREA INVALIDO ' TB-ARENVO1(IX1) */
                                                _.Display($"TIPO DE AREA INVALIDO {AREA_DE_WORK.TBOPER_MAS1.TB_OPER1.TB_OPERA[IX1]}");

                                                /*" -695- STOP RUN. */

                                                throw new GoBack();   // => STOP RUN.
                                            }

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-DESCARREGA-IMPRESS-SECTION */
        private void R4000_00_DESCARREGA_IMPRESS_SECTION()
        {
            /*" -706- SET IX2 TO WZEROS. */
            IX2.Value = AREA_DE_WORK.WZEROS;

            /*" -0- FLUXCONTROL_PERFORM R4000_10_LOOP */

            R4000_10_LOOP();

        }

        [StopWatch]
        /*" R4000-10-LOOP */
        private void R4000_10_LOOP(bool isPerform = false)
        {
            /*" -711- SET IX2 UP BY +1 */
            IX2.Value += +1;

            /*" -712- IF IX2 GREATER +50 */

            if (IX2 > +50)
            {

                /*" -713- WRITE REG-PR0100B FROM LC05 */
                _.Move(AREA_DE_WORK.LC05.GetMoveValues(), REG_PR0100B);

                RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

                /*" -715- GO TO R4000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -716- IF TB-CODOPE2(IX2) EQUAL ZEROS */

            if (AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2].TB_CODOPE2 == 00)
            {

                /*" -717- MOVE SPACES TO LD01-CODOPER1R */
                _.Move("", AREA_DE_WORK.LD01.LD01_CODOPER1R);

                /*" -718- MOVE SPACES TO LD01-NOMOPER1 */
                _.Move("", AREA_DE_WORK.LD01.LD01_NOMOPER1);

                /*" -719- ELSE */
            }
            else
            {


                /*" -720- MOVE TB-CODOPE2(IX2) TO LD01-CODOPER1R */
                _.Move(AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2].TB_CODOPE2, AREA_DE_WORK.LD01.LD01_CODOPER1R);

                /*" -722- MOVE TB-NOMOPE2(IX2) TO LD01-NOMOPER1. */
                _.Move(AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2].TB_NOMOPE2, AREA_DE_WORK.LD01.LD01_NOMOPER1);
            }


            /*" -723- IF TB-CODOPE2(IX2 + 50) EQUAL ZEROS */

            if (AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2 + 50].TB_CODOPE2 == 00)
            {

                /*" -724- MOVE SPACES TO LD01-CODOPER2R */
                _.Move("", AREA_DE_WORK.LD01.LD01_CODOPER2R);

                /*" -725- MOVE SPACES TO LD01-NOMOPER2 */
                _.Move("", AREA_DE_WORK.LD01.LD01_NOMOPER2);

                /*" -726- ELSE */
            }
            else
            {


                /*" -727- MOVE TB-CODOPE2(IX2 + 50) TO LD01-CODOPER2R */
                _.Move(AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2 + 50].TB_CODOPE2, AREA_DE_WORK.LD01.LD01_CODOPER2R);

                /*" -729- MOVE TB-NOMOPE2(IX2 + 50) TO LD01-NOMOPER2. */
                _.Move(AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2 + 50].TB_NOMOPE2, AREA_DE_WORK.LD01.LD01_NOMOPER2);
            }


            /*" -730- IF TB-CODOPE2(IX2 + 100) EQUAL ZEROS */

            if (AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2 + 100].TB_CODOPE2 == 00)
            {

                /*" -731- MOVE SPACES TO LD01-CODOPER3R */
                _.Move("", AREA_DE_WORK.LD01.LD01_CODOPER3R);

                /*" -732- MOVE SPACES TO LD01-NOMOPER3 */
                _.Move("", AREA_DE_WORK.LD01.LD01_NOMOPER3);

                /*" -733- ELSE */
            }
            else
            {


                /*" -734- MOVE TB-CODOPE2(IX2 + 100) TO LD01-CODOPER3R */
                _.Move(AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2 + 100].TB_CODOPE2, AREA_DE_WORK.LD01.LD01_CODOPER3R);

                /*" -736- MOVE TB-NOMOPE2(IX2 + 100) TO LD01-NOMOPER3. */
                _.Move(AREA_DE_WORK.TBOPER_MAS2.TB_OPER2.TB_OPERA_0[IX2 + 100].TB_NOMOPE2, AREA_DE_WORK.LD01.LD01_NOMOPER3);
            }


            /*" -738- WRITE REG-PR0100B FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_PR0100B);

            RPR0100B.Write(REG_PR0100B.GetMoveValues().ToString());

            /*" -738- GO TO R4000-10-LOOP. */
            new Task(() => R4000_10_LOOP()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R7000-00-DELETE-V1RELATO-SECTION */
        private void R7000_00_DELETE_V1RELATO_SECTION()
        {
            /*" -753- MOVE '700' TO WNR-EXEC-SQL */
            _.Move("700", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -756- PERFORM R7000_00_DELETE_V1RELATO_DB_DELETE_1 */

            R7000_00_DELETE_V1RELATO_DB_DELETE_1();

            /*" -759- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -762- DISPLAY 'ERRO DELETE V1RELATO..' ' ' V1RELATO-IDSISTEM ' ' V1RELATO-CODRELAT */

                $"ERRO DELETE V1RELATO.. {V1RELATO_IDSISTEM} {V1RELATO_CODRELAT}"
                .Display();

                /*" -762- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R7000-00-DELETE-V1RELATO-DB-DELETE-1 */
        public void R7000_00_DELETE_V1RELATO_DB_DELETE_1()
        {
            /*" -756- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'PR' AND CODRELAT = 'PR0100B1' END-EXEC. */

            var r7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1 = new R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1()
            {
            };

            R7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1.Execute(r7000_00_DELETE_V1RELATO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7000_99_SAIDA*/

        [StopWatch]
        /*" R8000-00-OPEN-ARQUIVOS-SECTION */
        private void R8000_00_OPEN_ARQUIVOS_SECTION()
        {
            /*" -773- OPEN OUTPUT RPR0100B. */
            RPR0100B.Open(REG_PR0100B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R9000-00-CLOSE-ARQUIVOS-SECTION */
        private void R9000_00_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -784- CLOSE RPR0100B. */
            RPR0100B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -799- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -801- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -803- CLOSE RPR0100B */
            RPR0100B.Close();

            /*" -803- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -805- EXEC SQL ROLLBACK WORK RELEASE END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}