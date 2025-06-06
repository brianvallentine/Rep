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
using Sias.Outros.DB2.CS1164B;

namespace Code
{
    public class CS1164B
    {
        public bool IsCall { get; set; }

        public CS1164B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  CONVENIO SULAMERICA                *      */
        /*"      *   PROGRAMA ...............  CS1164B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  BRSEG                              *      */
        /*"      *   PROGRAMADOR ............  BRSEG (VANDO)                      *      */
        /*"      *   DATA CODIFICACAO .......  MAIO / 2011                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA RELATORIO A SER ENVIADO A SUL *      */
        /*"      *                             AMERICA COM AS PROPOSTAS CADASTRA- *      */
        /*"      *                             DAS NO SIAS SEM PAGAMENTO A MAIS   *      */
        /*"      *                             DE 10 DIAS (RCAP NAO PAGO)         *      */
        /*"      *                            (COPIA DO PROGRAMA CV0260B)         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA/ARQUIVOS                                       ACESSO   *      */
        /*"      * ----------------------------------------------------- -------- *      */
        /*"      * SISTEMAS                                              INPUT    *      */
        /*"      * EMPRESAS                                              INPUT    *      */
        /*"      * PROPOSTAS                                             INPUT    *      */
        /*"      * PROPOSTA_AUTO                                         INPUT    *      */
        /*"      * RCAPS                                                 INPUT    *      */
        /*"      * REL. COM AS PROPOSTAS PENDENTES DE PAGTO (CS1164B1)   OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.02  * JAZZ 225440 - TRATAR CONGENERE NOVA                            *      */
        /*"      *             - ALTERADO PARA OBTER A CONGENERE NA DATA DO       *      */
        /*"      *               PROCESSAMENTO                                    *      */
        /*"      * EM 14/01/2020 - OLIVEIRA                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CS1164B1 { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis CS1164B1
        {
            get
            {
                _.Move(REG_CS1164B1, _CS1164B1); VarBasis.RedefinePassValue(REG_CS1164B1, _CS1164B1, REG_CS1164B1); return _CS1164B1;
            }
        }
        /*"01         REG-CS1164B1         PIC  X(132).*/
        public StringBasis REG_CS1164B1 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WHOST-DATA-10DIAS            PIC X(010) VALUE SPACES.*/
        public StringBasis WHOST_DATA_10DIAS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77 AC-LIDOS                     PIC 9(015) VALUE ZEROS.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"77 AC-IMPRESSOS                 PIC 9(015) VALUE ZEROS.*/
        public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
        /*"77 AC-LINHAS                    PIC 9(002) VALUE 99.*/
        public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 99);
        /*"77 AC-PAGINAS                   PIC 9(006) VALUE ZEROS.*/
        public IntBasis AC_PAGINAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"77 WS-FIM-CURS01                PIC X(001) VALUE 'N'.*/
        public StringBasis WS_FIM_CURS01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"77 WSL-SQLCODE                  PIC 9(009) VALUE ZEROS.*/
        public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"77 WS-COD-CONGENERE             PIC S9(004) VALUE +0   COMP.*/
        public IntBasis WS_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WS-VERSAO                  PIC  X(120) VALUE     'PROG.CS1164B - VERSAO 02 - TRATAR CONGENERE     '  - JAZZ 225440'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.CS1164B - VERSAO 02 - TRATAR CONGENERE     ");
        /*"01          AREA-DE-WORK.*/
        public CS1164B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CS1164B_AREA_DE_WORK();
        public class CS1164B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WDATA-CURR          PIC  X(010)      VALUE  SPACES.*/
            public StringBasis WDATA_CURR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        FILLER              REDEFINES        WDATA-CURR.*/
            private _REDEF_CS1164B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_CS1164B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_CS1164B_FILLER_0(); _.Move(WDATA_CURR, _filler_0); VarBasis.RedefinePassValue(WDATA_CURR, _filler_0, WDATA_CURR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WDATA_CURR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WDATA_CURR); }
            }  //Redefines
            public class _REDEF_CS1164B_FILLER_0 : VarBasis
            {
                /*"    10      WDATA-AA-CURR       PIC  9(004).*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-MM-CURR       PIC  9(002).*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-DD-CURR       PIC  9(002).*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-EDIT.*/

                public _REDEF_CS1164B_FILLER_0()
                {
                    WDATA_AA_CURR.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_MM_CURR.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDATA_DD_CURR.ValueChanged += OnValueChanged;
                }

            }
            public CS1164B_WDATA_EDIT WDATA_EDIT { get; set; } = new CS1164B_WDATA_EDIT();
            public class CS1164B_WDATA_EDIT : VarBasis
            {
                /*"    10      WDATA-DD-EDIT       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WDATA_DD_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE  '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDATA-MM-EDIT       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WDATA_MM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE  '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDATA-AA-EDIT       PIC  9(004)      VALUE  ZEROS.*/
                public IntBasis WDATA_AA_EDIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WHORA-CURR.*/
            }
            public CS1164B_WHORA_CURR WHORA_CURR { get; set; } = new CS1164B_WHORA_CURR();
            public class CS1164B_WHORA_CURR : VarBasis
            {
                /*"    10      WHORA-HH-CURR       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WHORA-MM-CURR       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WHORA-SS-CURR       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WHORA-CC-CURR       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WHORA-EDIT.*/
            }
            public CS1164B_WHORA_EDIT WHORA_EDIT { get; set; } = new CS1164B_WHORA_EDIT();
            public class CS1164B_WHORA_EDIT : VarBasis
            {
                /*"    10      WHORA-HH-EDIT       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_HH_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE  '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10      WHORA-MM-EDIT       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_MM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE  '.'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10      WHORA-SS-EDIT       PIC  9(002)      VALUE  ZEROS.*/
                public IntBasis WHORA_SS_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WDATA-AUX           PIC  X(010).*/
            }
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05        WDATA-AUX-R         REDEFINES        WDATA-AUX.*/
            private _REDEF_CS1164B_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_CS1164B_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_CS1164B_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_CS1164B_WDATA_AUX_R : VarBasis
            {
                /*"    10      WDAT-AUX-SSAA       PIC  9(004).*/
                public IntBasis WDAT_AUX_SSAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WDAT-AUX-SSAA-R     REDEFINES        WDAT-AUX-SSAA.*/
                private _REDEF_CS1164B_WDAT_AUX_SSAA_R _wdat_aux_ssaa_r { get; set; }
                public _REDEF_CS1164B_WDAT_AUX_SSAA_R WDAT_AUX_SSAA_R
                {
                    get { _wdat_aux_ssaa_r = new _REDEF_CS1164B_WDAT_AUX_SSAA_R(); _.Move(WDAT_AUX_SSAA, _wdat_aux_ssaa_r); VarBasis.RedefinePassValue(WDAT_AUX_SSAA, _wdat_aux_ssaa_r, WDAT_AUX_SSAA); _wdat_aux_ssaa_r.ValueChanged += () => { _.Move(_wdat_aux_ssaa_r, WDAT_AUX_SSAA); }; return _wdat_aux_ssaa_r; }
                    set { VarBasis.RedefinePassValue(value, _wdat_aux_ssaa_r, WDAT_AUX_SSAA); }
                }  //Redefines
                public class _REDEF_CS1164B_WDAT_AUX_SSAA_R : VarBasis
                {
                    /*"      15    WDAT-AUX-SEC        PIC  9(002).*/
                    public IntBasis WDAT_AUX_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    WDAT-AUX-ANO        PIC  9(002).*/
                    public IntBasis WDAT_AUX_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10      WDAT-TRACO-1        PIC  X(001).*/

                    public _REDEF_CS1164B_WDAT_AUX_SSAA_R()
                    {
                        WDAT_AUX_SEC.ValueChanged += OnValueChanged;
                        WDAT_AUX_ANO.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WDAT_TRACO_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-AUX-MES        PIC  9(002).*/
                public IntBasis WDAT_AUX_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDAT-TRACO-2        PIC  X(001).*/
                public StringBasis WDAT_TRACO_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-AUX-DIA        PIC  9(002).*/
                public IntBasis WDAT_AUX_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          AREA-DE-RELATORIO.*/

                public _REDEF_CS1164B_WDATA_AUX_R()
                {
                    WDAT_AUX_SSAA.ValueChanged += OnValueChanged;
                    WDAT_AUX_SSAA_R.ValueChanged += OnValueChanged;
                }

            }
        }
        public CS1164B_AREA_DE_RELATORIO AREA_DE_RELATORIO { get; set; } = new CS1164B_AREA_DE_RELATORIO();
        public class CS1164B_AREA_DE_RELATORIO : VarBasis
        {
            /*"  05        LC01.*/
            public CS1164B_LC01 LC01 { get; set; } = new CS1164B_LC01();
            public class CS1164B_LC01 : VarBasis
            {
                /*"    10      FILLER              PIC  X(001) VALUE      '*'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10      FILLER              PIC  X(130) VALUE ALL  '-'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
                /*"    10      FILLER              PIC  X(001) VALUE      '*'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05        LC02.*/
            }
            public CS1164B_LC02 LC02 { get; set; } = new CS1164B_LC02();
            public class CS1164B_LC02 : VarBasis
            {
                /*"    10      FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(008) VALUE 'CS1164B1'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"CS1164B1");
                /*"    10      FILLER              PIC  X(036) VALUE  SPACES.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "36", "X(036)"), @"");
                /*"    10      LC02-EMPRESA        PIC  X(040) VALUE  SPACES.*/
                public StringBasis LC02_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10      FILLER              PIC  X(025) VALUE  SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
                /*"    10      FILLER              PIC  X(008) VALUE 'PAGINA :'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PAGINA :");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LC02-PAGINA         PIC  ZZZ.ZZ9.*/
                public IntBasis LC02_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "ZZZ.ZZ9."));
                /*"    10      FILLER              PIC  X(004) VALUE  SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10      FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05        LC03.*/
            }
            public CS1164B_LC03 LC03 { get; set; } = new CS1164B_LC03();
            public class CS1164B_LC03 : VarBasis
            {
                /*"    10      FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10      FILLER              PIC  X(112) VALUE  SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"");
                /*"    10      FILLER              PIC  X(006) VALUE 'DATA :'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"DATA :");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LC03-DATA           PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC03_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05        LC04.*/
            }
            public CS1164B_LC04 LC04 { get; set; } = new CS1164B_LC04();
            public class CS1164B_LC04 : VarBasis
            {
                /*"    10      FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10      FILLER              PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10      FILLER              PIC  X(071) VALUE       'RELACAO DAS PROPOSTAS VENDIDAS SEM PAGAMENTO A MAIS DE 10       ' (DEZ) DIAS - '.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "71", "X(071)"), @"RELACAO DAS PROPOSTAS VENDIDAS SEM PAGAMENTO A MAIS DE 10       ");
                /*"    10      LC04-DTMOVTO        PIC  X(010) VALUE  SPACES.*/
                public StringBasis LC04_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      FILLER              PIC  X(016) VALUE  SPACES.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    10      FILLER              PIC  X(006) VALUE 'HORA :'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"HORA :");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LC04-HORA           PIC  X(008) VALUE  SPACES.*/
                public StringBasis LC04_HORA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10      FILLER              PIC  X(003) VALUE  SPACES.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10      FILLER              PIC  X(001) VALUE '*'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05        LC05.*/
            }
            public CS1164B_LC05 LC05 { get; set; } = new CS1164B_LC05();
            public class CS1164B_LC05 : VarBasis
            {
                /*"    10      FILLER              PIC  X(001) VALUE  '*'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"    10      FILLER              PIC  X(049) VALUE  SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"");
                /*"    10      FILLER              PIC  X(033) VALUE           'CONTROLE DA SEGURADORA SULAMERICA'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"CONTROLE DA SEGURADORA SULAMERICA");
                /*"    10      FILLER              PIC  X(048) VALUE  SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"    10      FILLER              PIC  X(001) VALUE  '*'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"*");
                /*"  05        LC06.*/
            }
            public CS1164B_LC06 LC06 { get; set; } = new CS1164B_LC06();
            public class CS1164B_LC06 : VarBasis
            {
                /*"    10      FILLER              PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10      FILLER              PIC  X(014) VALUE           'PROPOSTA CONV.'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"PROPOSTA CONV.");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(005) VALUE           'FONTE'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"FONTE");
                /*"    10      FILLER              PIC  X(003) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10      FILLER              PIC  X(008) VALUE           'PROPOSTA'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"PROPOSTA");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(014) VALUE           '     RCAP     '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"     RCAP     ");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(018) VALUE           'DATA CADASTRAMENTO'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"DATA CADASTRAMENTO");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(018) VALUE           'INICIO DE VIGENCIA'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"INICIO DE VIGENCIA");
                /*"    10      FILLER              PIC  X(001) VALUE  SPACES.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      FILLER              PIC  X(019) VALUE           'TERMINO DE VIGENCIA'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"TERMINO DE VIGENCIA");
                /*"    10      FILLER              PIC  X(016) VALUE  SPACES.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"  05        LD01.*/
            }
            public CS1164B_LD01 LD01 { get; set; } = new CS1164B_LD01();
            public class CS1164B_LD01 : VarBasis
            {
                /*"    10      FILLER              PIC  X(015) VALUE  SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10      LD01-NUM-PROP-CONV  PIC  ZZZZZZZZZZZZZ9.*/
                public IntBasis LD01_NUM_PROP_CONV { get; set; } = new IntBasis(new PIC("9", "14", "ZZZZZZZZZZZZZ9."));
                /*"    10      FILLER              PIC  X(002) VALUE  SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10      LD01-COD-FONTE      PIC  ZZ9.*/
                public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "3", "ZZ9."));
                /*"    10      FILLER              PIC  X(003) VALUE  SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10      LD01-NUM-PROPOSTA   PIC  ZZZZZZZ9.*/
                public IntBasis LD01_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZZZ9."));
                /*"    10      FILLER              PIC  X(004) VALUE  SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10      LD01-NUM-RCAP       PIC  ZZZZZZZZZ9.*/
                public IntBasis LD01_NUM_RCAP { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZZZZ9."));
                /*"    10      FILLER              PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10      LD01-DATA-CADASTR   PIC  X(010) VALUE  SPACES.*/
                public StringBasis LD01_DATA_CADASTR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      FILLER              PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10      LD01-INI-VIGENCIA   PIC  X(010) VALUE  SPACES.*/
                public StringBasis LD01_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      FILLER              PIC  X(008) VALUE  SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10      LD01-FIM-VIGENCIA   PIC  X(010) VALUE  SPACES.*/
                public StringBasis LD01_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"01          LK-LINK.*/
            }
        }
        public CS1164B_LK_LINK LK_LINK { get; set; } = new CS1164B_LK_LINK();
        public class CS1164B_LK_LINK : VarBasis
        {
            /*"  05        LK-RTCODE           PIC  S9(004)   VALUE +0   COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05        LK-TAMANHO          PIC  S9(004)   VALUE +40  COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05        LK-TITULO           PIC   X(132)   VALUE  SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01          WABEND.*/
        }
        public CS1164B_WABEND WABEND { get; set; } = new CS1164B_WABEND();
        public class CS1164B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(007)      VALUE 'CS1164B'*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"CS1164B");
            /*"  05        FILLER              PIC  X(035)      VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)      VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-   VALUE  ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Copies.LBCS0701 LBCS0701 { get; set; } = new Copies.LBCS0701();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.EMPRESAS EMPRESAS { get; set; } = new Dclgens.EMPRESAS();
        public Dclgens.PROPOSTA PROPOSTA { get; set; } = new Dclgens.PROPOSTA();
        public Dclgens.PROPOAUT PROPOAUT { get; set; } = new Dclgens.PROPOAUT();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();

        public CS1164B_CURS01 CURS01 { get; set; } = new CS1164B_CURS01(true);
        string GetQuery_CURS01()
        {
            var query = @$"SELECT A.COD_FONTE
							, A.NUM_PROPOSTA
							, A.NUM_RCAP
							, A.DATA_CADASTRAMENTO
							, A.DATA_INIVIGENCIA
							, A.DATA_TERVIGENCIA
							, B.NUM_PROPOSTA_CONV
							FROM SEGUROS.PROPOSTAS A
							, SEGUROS.PROPOSTA_AUTO B WHERE A.COD_FONTE = B.COD_FONTE AND A.NUM_PROPOSTA = B.NUM_PROPOSTA AND A.DATA_CADASTRAMENTO <= '{WHOST_DATA_10DIAS}' AND B.NUM_PROPOSTA_CONV > 0 AND A.NUM_RCAP > 0 AND A.SIT_REGISTRO <> '*' AND B.COD_CONGENERE IN (5118
							,'{WS_COD_CONGENERE}') AND NOT EXISTS
							(SELECT  C.NUM_RCAP
							FROM SEGUROS.RCAPS C WHERE C.NUM_RCAP = A.NUM_RCAP) ORDER BY A.DATA_CADASTRAMENTO DESC
							, B.NUM_PROPOSTA_CONV";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CS1164B1_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CS1164B1.SetFile(CS1164B1_FILE_NAME_P);
                InitializeGetQuery();

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            CURS01.GetQueryEvent += GetQuery_CURS01;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -314- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -315- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -318- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -321- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -324- DISPLAY '                               ' */
            _.Display($"                               ");

            /*" -325- DISPLAY WS-VERSAO */
            _.Display(WS_VERSAO);

            /*" -327- DISPLAY 'CS1164B - Inicio de Execucao   ' */
            _.Display($"CS1164B - Inicio de Execucao   ");

            /*" -329- PERFORM R1000-00-INICIALIZA. */

            R1000_00_INICIALIZA_SECTION();

            /*" -332- PERFORM R2000-00-PROCESSA UNTIL WS-FIM-CURS01 EQUAL 'S' . */

            while (!(WS_FIM_CURS01 == "S"))
            {

                R2000_00_PROCESSA_SECTION();
            }

            /*" -334- PERFORM R3000-00-FINALIZA. */

            R3000_00_FINALIZA_SECTION();

            /*" -334- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R1000-00-INICIALIZA-SECTION */
        private void R1000_00_INICIALIZA_SECTION()
        {
            /*" -344- OPEN OUTPUT CS1164B1. */
            CS1164B1.Open(REG_CS1164B1);

            /*" -347- PERFORM R1100-00-SELECT-SISTEMAS. */

            R1100_00_SELECT_SISTEMAS_SECTION();

            /*" -349- PERFORM R1130-00-SELECT-CONGENERE. */

            R1130_00_SELECT_CONGENERE_SECTION();

            /*" -351- PERFORM R1200-00-SELECT-EMPRESAS. */

            R1200_00_SELECT_EMPRESAS_SECTION();

            /*" -353- PERFORM R1300-00-OPEN-CURS01. */

            R1300_00_OPEN_CURS01_SECTION();

            /*" -355- PERFORM R1400-00-FETCH-CURS01. */

            R1400_00_FETCH_CURS01_SECTION();

            /*" -356- IF WS-FIM-CURS01 EQUAL 'S' */

            if (WS_FIM_CURS01 == "S")
            {

                /*" -356- PERFORM R3100-00-ENCERRA-SEM-MOVTO. */

                R3100_00_ENCERRA_SEM_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-SISTEMAS-SECTION */
        private void R1100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -369- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -376- PERFORM R1100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R1100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -379- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -380- DISPLAY 'R1100 - ERRO NO SELECT DA SISTEMAS - CV' */
                _.Display($"R1100 - ERRO NO SELECT DA SISTEMAS - CV");

                /*" -381- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -382- END-IF */
            }


            /*" -382- . */

        }

        [StopWatch]
        /*" R1100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R1100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -376- EXEC SQL SELECT DATA_MOV_ABERTO, (DATA_MOV_ABERTO - 10 DAYS) INTO :SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-10DIAS FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CV' END-EXEC. */

            var r1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_10DIAS, WHOST_DATA_10DIAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1130-00-SELECT-CONGENERE-SECTION */
        private void R1130_00_SELECT_CONGENERE_SECTION()
        {
            /*" -392- MOVE 'R1130' TO WNR-EXEC-SQL. */
            _.Move("R1130", WABEND.WNR_EXEC_SQL);

            /*" -393- MOVE '02' TO CS0701S-OPERACAO */
            _.Move("02", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO);

            /*" -394- MOVE 1 TO CS0701S-COD-PARAM */
            _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM);

            /*" -395- MOVE 'AUTO' TO CS0701S-CLASSE-PARAM */
            _.Move("AUTO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_CLASSE_PARAM);

            /*" -396- MOVE 'AU' TO CS0701S-COD-SISTEMA */
            _.Move("AU", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_SISTEMA);

            /*" -397- MOVE 0 TO CS0701S-COD-PRODUTO */
            _.Move(0, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PRODUTO);

            /*" -399- MOVE SISTEMAS-DATA-MOV-ABERTO TO CS0701S-DATA-INIVIGENCIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA);

            /*" -401- CALL 'CS0701S' USING CS0701S-AREA-PARAMETROS */
            _.Call("CS0701S", LBCS0701.CS0701S_AREA_PARAMETROS);

            /*" -403- IF CS0701S-COD-RETORNO > 0 OR CS0701S-TB-VALOR-INT(1) = 0 */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO > 0 || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[1].CS0701S_TB_VALOR_INT == 0)
            {

                /*" -404- DISPLAY ' COD=' CS0701S-COD-RETORNO */
                _.Display($" COD={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO}");

                /*" -405- DISPLAY ' MSG=' CS0701S-MSG-RETORNO */
                _.Display($" MSG={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO}");

                /*" -406- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -408- END-IF */
            }


            /*" -409- MOVE CS0701S-TB-VALOR-INT(1) TO WS-COD-CONGENERE */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[1].CS0701S_TB_VALOR_INT, WS_COD_CONGENERE);

            /*" -411- DISPLAY 'R1130-00-COD-CONGENERE:' WS-COD-CONGENERE ' DATA-CONGENERE:' CS0701S-DATA-INIVIGENCIA */

            $"R1130-00-COD-CONGENERE:{WS_COD_CONGENERE} DATA-CONGENERE:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA}"
            .Display();

            /*" -411- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1130_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-EMPRESAS-SECTION */
        private void R1200_00_SELECT_EMPRESAS_SECTION()
        {
            /*" -422- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -427- PERFORM R1200_00_SELECT_EMPRESAS_DB_SELECT_1 */

            R1200_00_SELECT_EMPRESAS_DB_SELECT_1();

            /*" -430- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -431- DISPLAY 'R1200 - ERRO NO SELECT DA EMPRESAS' */
                _.Display($"R1200 - ERRO NO SELECT DA EMPRESAS");

                /*" -433- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -435- MOVE EMPRESAS-NOME-EMPRESA TO LK-TITULO. */
            _.Move(EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -437- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -438- IF LK-RTCODE = ZEROS */

            if (LK_LINK.LK_RTCODE == 00)
            {

                /*" -439- MOVE LK-TITULO TO LC02-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, AREA_DE_RELATORIO.LC02.LC02_EMPRESA);

                /*" -440- ELSE */
            }
            else
            {


                /*" -441- DISPLAY 'R1200 - ERRO NO CALL DA SUBROTINA PROALN01' */
                _.Display($"R1200 - ERRO NO CALL DA SUBROTINA PROALN01");

                /*" -443- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -444- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-CURR. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_CURR);

            /*" -445- MOVE WDATA-DD-CURR TO WDATA-DD-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDIT);

            /*" -446- MOVE WDATA-MM-CURR TO WDATA-MM-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDIT);

            /*" -447- MOVE WDATA-AA-CURR TO WDATA-AA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDIT);

            /*" -449- MOVE WDATA-EDIT TO LC03-DATA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, AREA_DE_RELATORIO.LC03.LC03_DATA);

            /*" -450- MOVE WHOST-DATA-10DIAS TO WDATA-CURR. */
            _.Move(WHOST_DATA_10DIAS, AREA_DE_WORK.WDATA_CURR);

            /*" -451- MOVE WDATA-DD-CURR TO WDATA-DD-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDIT);

            /*" -452- MOVE WDATA-MM-CURR TO WDATA-MM-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDIT);

            /*" -453- MOVE WDATA-AA-CURR TO WDATA-AA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDIT);

            /*" -455- MOVE WDATA-EDIT TO LC04-DTMOVTO. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, AREA_DE_RELATORIO.LC04.LC04_DTMOVTO);

            /*" -456- ACCEPT WHORA-CURR FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_CURR);

            /*" -457- MOVE WHORA-HH-CURR TO WHORA-HH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_HH_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_HH_EDIT);

            /*" -458- MOVE WHORA-MM-CURR TO WHORA-MM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_MM_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_MM_EDIT);

            /*" -459- MOVE WHORA-SS-CURR TO WHORA-SS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_CURR.WHORA_SS_CURR, AREA_DE_WORK.WHORA_EDIT.WHORA_SS_EDIT);

            /*" -459- MOVE WHORA-EDIT TO LC04-HORA. */
            _.Move(AREA_DE_WORK.WHORA_EDIT, AREA_DE_RELATORIO.LC04.LC04_HORA);

        }

        [StopWatch]
        /*" R1200-00-SELECT-EMPRESAS-DB-SELECT-1 */
        public void R1200_00_SELECT_EMPRESAS_DB_SELECT_1()
        {
            /*" -427- EXEC SQL SELECT NOME_EMPRESA INTO :EMPRESAS-NOME-EMPRESA FROM SEGUROS.EMPRESAS WHERE COD_EMPRESA = 0 END-EXEC. */

            var r1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1 = new R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_EMPRESAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMPRESAS_NOME_EMPRESA, EMPRESAS.DCLEMPRESAS.EMPRESAS_NOME_EMPRESA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-OPEN-CURS01-SECTION */
        private void R1300_00_OPEN_CURS01_SECTION()
        {
            /*" -472- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -472- PERFORM R1300_00_OPEN_CURS01_DB_OPEN_1 */

            R1300_00_OPEN_CURS01_DB_OPEN_1();

            /*" -475- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -476- DISPLAY 'R1300 - ERRO NO OPEN DO CURS01' */
                _.Display($"R1300 - ERRO NO OPEN DO CURS01");

                /*" -476- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-OPEN-CURS01-DB-OPEN-1 */
        public void R1300_00_OPEN_CURS01_DB_OPEN_1()
        {
            /*" -472- EXEC SQL OPEN CURS01 END-EXEC. */

            CURS01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-FETCH-CURS01-SECTION */
        private void R1400_00_FETCH_CURS01_SECTION()
        {
            /*" -487- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -496- PERFORM R1400_00_FETCH_CURS01_DB_FETCH_1 */

            R1400_00_FETCH_CURS01_DB_FETCH_1();

            /*" -499- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -500- IF SQLCODE EQUAL +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -501- MOVE 'S' TO WS-FIM-CURS01 */
                    _.Move("S", WS_FIM_CURS01);

                    /*" -501- PERFORM R1400_00_FETCH_CURS01_DB_CLOSE_1 */

                    R1400_00_FETCH_CURS01_DB_CLOSE_1();

                    /*" -503- ELSE */
                }
                else
                {


                    /*" -504- DISPLAY 'R1400 - ERRO NO FETCH DO CURS01' */
                    _.Display($"R1400 - ERRO NO FETCH DO CURS01");

                    /*" -505- DISPLAY 'WHOST-DATA-10DIAS = ' WHOST-DATA-10DIAS */
                    _.Display($"WHOST-DATA-10DIAS = {WHOST_DATA_10DIAS}");

                    /*" -506- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -507- END-IF */
                }


                /*" -508- ELSE */
            }
            else
            {


                /*" -508- ADD 1 TO AC-LIDOS. */
                AC_LIDOS.Value = AC_LIDOS + 1;
            }


        }

        [StopWatch]
        /*" R1400-00-FETCH-CURS01-DB-FETCH-1 */
        public void R1400_00_FETCH_CURS01_DB_FETCH_1()
        {
            /*" -496- EXEC SQL FETCH CURS01 INTO :PROPOSTA-COD-FONTE, :PROPOSTA-NUM-PROPOSTA, :PROPOSTA-NUM-RCAP, :PROPOSTA-DATA-CADASTRAMENTO, :PROPOSTA-DATA-INIVIGENCIA, :PROPOSTA-DATA-TERVIGENCIA, :PROPOAUT-NUM-PROPOSTA-CONV END-EXEC. */

            if (CURS01.Fetch())
            {
                _.Move(CURS01.PROPOSTA_COD_FONTE, PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE);
                _.Move(CURS01.PROPOSTA_NUM_PROPOSTA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA);
                _.Move(CURS01.PROPOSTA_NUM_RCAP, PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_RCAP);
                _.Move(CURS01.PROPOSTA_DATA_CADASTRAMENTO, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_CADASTRAMENTO);
                _.Move(CURS01.PROPOSTA_DATA_INIVIGENCIA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA);
                _.Move(CURS01.PROPOSTA_DATA_TERVIGENCIA, PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_TERVIGENCIA);
                _.Move(CURS01.PROPOAUT_NUM_PROPOSTA_CONV, PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV);
            }

        }

        [StopWatch]
        /*" R1400-00-FETCH-CURS01-DB-CLOSE-1 */
        public void R1400_00_FETCH_CURS01_DB_CLOSE_1()
        {
            /*" -501- EXEC SQL CLOSE CURS01 END-EXEC */

            CURS01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-SECTION */
        private void R2000_00_PROCESSA_SECTION()
        {
            /*" -521- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -523- MOVE PROPOAUT-NUM-PROPOSTA-CONV TO LD01-NUM-PROP-CONV. */
            _.Move(PROPOAUT.DCLPROPOSTA_AUTO.PROPOAUT_NUM_PROPOSTA_CONV, AREA_DE_RELATORIO.LD01.LD01_NUM_PROP_CONV);

            /*" -525- MOVE PROPOSTA-COD-FONTE TO LD01-COD-FONTE. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_COD_FONTE, AREA_DE_RELATORIO.LD01.LD01_COD_FONTE);

            /*" -527- MOVE PROPOSTA-NUM-PROPOSTA TO LD01-NUM-PROPOSTA. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_PROPOSTA, AREA_DE_RELATORIO.LD01.LD01_NUM_PROPOSTA);

            /*" -529- MOVE PROPOSTA-NUM-RCAP TO LD01-NUM-RCAP. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_NUM_RCAP, AREA_DE_RELATORIO.LD01.LD01_NUM_RCAP);

            /*" -531- MOVE PROPOSTA-DATA-CADASTRAMENTO TO WDATA-CURR. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_CADASTRAMENTO, AREA_DE_WORK.WDATA_CURR);

            /*" -532- MOVE WDATA-DD-CURR TO WDATA-DD-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDIT);

            /*" -533- MOVE WDATA-MM-CURR TO WDATA-MM-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDIT);

            /*" -534- MOVE WDATA-AA-CURR TO WDATA-AA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDIT);

            /*" -536- MOVE WDATA-EDIT TO LD01-DATA-CADASTR. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, AREA_DE_RELATORIO.LD01.LD01_DATA_CADASTR);

            /*" -537- MOVE PROPOSTA-DATA-INIVIGENCIA TO WDATA-CURR. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_INIVIGENCIA, AREA_DE_WORK.WDATA_CURR);

            /*" -538- MOVE WDATA-DD-CURR TO WDATA-DD-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDIT);

            /*" -539- MOVE WDATA-MM-CURR TO WDATA-MM-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDIT);

            /*" -540- MOVE WDATA-AA-CURR TO WDATA-AA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDIT);

            /*" -542- MOVE WDATA-EDIT TO LD01-INI-VIGENCIA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, AREA_DE_RELATORIO.LD01.LD01_INI_VIGENCIA);

            /*" -543- MOVE PROPOSTA-DATA-TERVIGENCIA TO WDATA-CURR. */
            _.Move(PROPOSTA.DCLPROPOSTAS.PROPOSTA_DATA_TERVIGENCIA, AREA_DE_WORK.WDATA_CURR);

            /*" -544- MOVE WDATA-DD-CURR TO WDATA-DD-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_DD_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_DD_EDIT);

            /*" -545- MOVE WDATA-MM-CURR TO WDATA-MM-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_MM_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_MM_EDIT);

            /*" -546- MOVE WDATA-AA-CURR TO WDATA-AA-EDIT. */
            _.Move(AREA_DE_WORK.FILLER_0.WDATA_AA_CURR, AREA_DE_WORK.WDATA_EDIT.WDATA_AA_EDIT);

            /*" -548- MOVE WDATA-EDIT TO LD01-FIM-VIGENCIA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, AREA_DE_RELATORIO.LD01.LD01_FIM_VIGENCIA);

            /*" -550- PERFORM R2100-00-IMPRIME. */

            R2100_00_IMPRIME_SECTION();

            /*" -550- PERFORM R1400-00-FETCH-CURS01. */

            R1400_00_FETCH_CURS01_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-IMPRIME-SECTION */
        private void R2100_00_IMPRIME_SECTION()
        {
            /*" -562- IF AC-LINHAS > 60 */

            if (AC_LINHAS > 60)
            {

                /*" -564- PERFORM R2200-00-CABECALHO. */

                R2200_00_CABECALHO_SECTION();
            }


            /*" -566- WRITE REG-CS1164B1 FROM LD01 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LD01.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -567- ADD 1 TO AC-LINHAS AC-IMPRESSOS. */
            AC_LINHAS.Value = AC_LINHAS + 1;
            AC_IMPRESSOS.Value = AC_IMPRESSOS + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-CABECALHO-SECTION */
        private void R2200_00_CABECALHO_SECTION()
        {
            /*" -579- ADD 1 TO AC-PAGINAS. */
            AC_PAGINAS.Value = AC_PAGINAS + 1;

            /*" -581- MOVE AC-PAGINAS TO LC02-PAGINA. */
            _.Move(AC_PAGINAS, AREA_DE_RELATORIO.LC02.LC02_PAGINA);

            /*" -583- MOVE ZEROS TO AC-LINHAS. */
            _.Move(0, AC_LINHAS);

            /*" -584- WRITE REG-CS1164B1 FROM LC01 AFTER PAGE. */
            _.Move(AREA_DE_RELATORIO.LC01.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -585- WRITE REG-CS1164B1 FROM LC02 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC02.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -586- WRITE REG-CS1164B1 FROM LC03 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC03.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -587- WRITE REG-CS1164B1 FROM LC01 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC01.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -588- WRITE REG-CS1164B1 FROM LC04 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC04.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -589- WRITE REG-CS1164B1 FROM LC05 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC05.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -590- WRITE REG-CS1164B1 FROM LC01 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC01.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -591- WRITE REG-CS1164B1 FROM LC06 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC06.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -593- WRITE REG-CS1164B1 FROM LC01 AFTER 1. */
            _.Move(AREA_DE_RELATORIO.LC01.GetMoveValues(), REG_CS1164B1);

            CS1164B1.Write(REG_CS1164B1.GetMoveValues().ToString());

            /*" -593- MOVE 9 TO AC-LINHAS. */
            _.Move(9, AC_LINHAS);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-FINALIZA-SECTION */
        private void R3000_00_FINALIZA_SECTION()
        {
            /*" -606- CLOSE CS1164B1. */
            CS1164B1.Close();

            /*" -607- DISPLAY ' ' . */
            _.Display($" ");

            /*" -608- DISPLAY '*--------*      DATAS APURADAS     *--------*' . */
            _.Display($"*--------*      DATAS APURADAS     *--------*");

            /*" -610- DISPLAY 'DATA DE MOVIMENTO           = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA DE MOVIMENTO           = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -612- DISPLAY 'DATA DE MOVIMENTO - 10 DIAS = ' WHOST-DATA-10DIAS. */
            _.Display($"DATA DE MOVIMENTO - 10 DIAS = {WHOST_DATA_10DIAS}");

            /*" -614- DISPLAY '*-------------------------------------------*' */
            _.Display($"*-------------------------------------------*");

            /*" -615- DISPLAY ' ' . */
            _.Display($" ");

            /*" -616- DISPLAY '*--------*   TOTAIS DE CONTROLE    *--------*' . */
            _.Display($"*--------*   TOTAIS DE CONTROLE    *--------*");

            /*" -618- DISPLAY 'REG LIDOS                   = ' AC-LIDOS. */
            _.Display($"REG LIDOS                   = {AC_LIDOS}");

            /*" -620- DISPLAY 'REG IMPRESSOS               = ' AC-IMPRESSOS. */
            _.Display($"REG IMPRESSOS               = {AC_IMPRESSOS}");

            /*" -622- DISPLAY '*-------------------------------------------*' */
            _.Display($"*-------------------------------------------*");

            /*" -624- DISPLAY '*---   CS1164B  -  FIM NORMAL   ---*' . */
            _.Display($"*---   CS1164B  -  FIM NORMAL   ---*");

            /*" -624- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -628- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -628- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R3100_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -645- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -646- DISPLAY '*-------------------------------------------*' . */
            _.Display($"*-------------------------------------------*");

            /*" -647- DISPLAY '*                                           *' . */
            _.Display($"*                                           *");

            /*" -648- DISPLAY '* CS1164B - RELATORIO DE PROPOSTAS VENDIDAS *' . */
            _.Display($"* CS1164B - RELATORIO DE PROPOSTAS VENDIDAS *");

            /*" -649- DISPLAY '*             NAO PAGAS A MAIS DE 10 DIAS   *' . */
            _.Display($"*             NAO PAGAS A MAIS DE 10 DIAS   *");

            /*" -650- DISPLAY '* -------   ------------------------------- *' . */
            _.Display($"* -------   ------------------------------- *");

            /*" -651- DISPLAY '*                                           *' . */
            _.Display($"*                                           *");

            /*" -652- DISPLAY '*      NAO HOUVE MOVIMENTACAO NO DIA        *' . */
            _.Display($"*      NAO HOUVE MOVIMENTACAO NO DIA        *");

            /*" -653- DISPLAY '*                                           *' . */
            _.Display($"*                                           *");

            /*" -653- DISPLAY '*-------------------------------------------*' . */
            _.Display($"*-------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -668- CLOSE CS1164B1. */
            CS1164B1.Close();

            /*" -670- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -672- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -672- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -676- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -676- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}