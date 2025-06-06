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
using Sias.Outros.DB2.CS1301B;

namespace Code
{
    public class CS1301B
    {
        public bool IsCall { get; set; }

        public CS1301B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------                                        */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ CONVENIO SULAMERICA                 *      */
        /*"      *   PROGRAMA ............... CS1301B                             *      */
        /*"      *   ANALISTA ............... COREON                              *      */
        /*"      *   PROGRAMADOR ............ COREON                              *      */
        /*"      *   DEMANDA ................ CADMUS 67181 - SAC 1188             *      */
        /*"      *   DATA CODIFICACAO ....... MARCO/2012                          *      */
        /*"      *   FUNCAO ................. GERAR RELATORIO SEMANAL DE PARCELAS *      */
        /*"      *                            BAIXADAS ( RCAP )  COM DIFERENCA DE *      */
        /*"      *                            PREMIO.                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                           DCLGEN               ACESSO   *      */
        /*"      * ----------------------------------------------------- -------- *      */
        /*"      * SISTEMAS                         SISTEMAS             INPUT    *      */
        /*"      * RELATORIOS                       RELATORI             I/O      *      */
        /*"      * ENDOSSOS                         ENDOSSOS             INPUT    *      */
        /*"      * PARCELA_HISTORICO                PARCEHIS             INPUT    *      */
        /*"      * APOLICE_AUTO                     APOLIAUT             INPUT    *      */
        /*"      * CLIENTES                         CLIENTES             INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA           DATA     DESCRICAO                          *      */
        /*"      * COREON          19/03/2012  DESENVOLVIMENTO                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.01  * JAZZ 225440 - TRATAR CONGENERE NOVA                            *      */
        /*"      *             - ALTERADO PARA OBTER A CONGENERE NA DATA DO       *      */
        /*"      *               PROCESSAMENTO                                    *      */
        /*"      * EM 14/01/2020 - OLIVEIRA                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CS1301BO { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis CS1301BO
        {
            get
            {
                _.Move(REG_CS1301BO, _CS1301BO); VarBasis.RedefinePassValue(REG_CS1301BO, _CS1301BO, REG_CS1301BO); return _CS1301BO;
            }
        }
        /*"01        REG-CS1301BO          PIC X(200).*/
        public StringBasis REG_CS1301BO { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          WHOST-DTCURRENT       PIC  X(010)    VALUE  SPACES.*/
        public StringBasis WHOST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          SISTEMAS-DATA-MOV-1D  PIC  X(010)    VALUE  SPACES.*/
        public StringBasis SISTEMAS_DATA_MOV_1D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          SISTEMAS-DATA-MOV-6D  PIC  X(010)    VALUE  SPACES.*/
        public StringBasis SISTEMAS_DATA_MOV_6D { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          RELATORI-PROX-INICIAL PIC  X(010)    VALUE  SPACES.*/
        public StringBasis RELATORI_PROX_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          RELATORI-PROX-FINAL   PIC  X(010)    VALUE  SPACES.*/
        public StringBasis RELATORI_PROX_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          PARCEHIS-DIFERENCA1   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis PARCEHIS_DIFERENCA1 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          PARCEHIS-DIFERENCA2   PIC S9(013)V99 VALUE +0 COMP-3*/
        public DoubleBasis PARCEHIS_DIFERENCA2 { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          WS-COD-CONGENERE      PIC S9(004)    VALUE +0   COMP*/
        public IntBasis WS_COD_CONGENERE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77 WS-VERSAO                  PIC  X(120) VALUE     'PROG.CS1301B - VERSAO 01 - TRATAR CONGENERE     '  - JAZZ 225440'.*/
        public StringBasis WS_VERSAO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)"), @"PROG.CS1301B - VERSAO 01 - TRATAR CONGENERE     ");
        /*"01          AREA-DE-WORK.*/
        public CS1301B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new CS1301B_AREA_DE_WORK();
        public class CS1301B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WS-STATUS           PIC  9(002)    VALUE  ZEROS.*/
            public IntBasis WS_STATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05        WFIM-PARCELAS       PIC  X(001)    VALUE  SPACES.*/
            public StringBasis WFIM_PARCELAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WS-CT-LIDOS         PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-CT-GRAVA         PIC  9(007)    VALUE  ZEROS.*/
            public IntBasis WS_CT_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05        WS-DATA-AUX         PIC  X(010)    VALUE  SPACES.*/
            public StringBasis WS_DATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WS-DATA-AUX-R       REDEFINES      WS-DATA-AUX.*/
            private _REDEF_CS1301B_WS_DATA_AUX_R _ws_data_aux_r { get; set; }
            public _REDEF_CS1301B_WS_DATA_AUX_R WS_DATA_AUX_R
            {
                get { _ws_data_aux_r = new _REDEF_CS1301B_WS_DATA_AUX_R(); _.Move(WS_DATA_AUX, _ws_data_aux_r); VarBasis.RedefinePassValue(WS_DATA_AUX, _ws_data_aux_r, WS_DATA_AUX); _ws_data_aux_r.ValueChanged += () => { _.Move(_ws_data_aux_r, WS_DATA_AUX); }; return _ws_data_aux_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_aux_r, WS_DATA_AUX); }
            }  //Redefines
            public class _REDEF_CS1301B_WS_DATA_AUX_R : VarBasis
            {
                /*"    10      WS-ANO-AUX          PIC  9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-MES-AUX          PIC  9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-DIA-AUX          PIC  9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-DATA-EDIT        PIC  X(010)    VALUE  SPACES.*/

                public _REDEF_CS1301B_WS_DATA_AUX_R()
                {
                    WS_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WS_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DATA_EDIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WS-DATA-EDIT-R      REDEFINES      WS-DATA-EDIT.*/
            private _REDEF_CS1301B_WS_DATA_EDIT_R _ws_data_edit_r { get; set; }
            public _REDEF_CS1301B_WS_DATA_EDIT_R WS_DATA_EDIT_R
            {
                get { _ws_data_edit_r = new _REDEF_CS1301B_WS_DATA_EDIT_R(); _.Move(WS_DATA_EDIT, _ws_data_edit_r); VarBasis.RedefinePassValue(WS_DATA_EDIT, _ws_data_edit_r, WS_DATA_EDIT); _ws_data_edit_r.ValueChanged += () => { _.Move(_ws_data_edit_r, WS_DATA_EDIT); }; return _ws_data_edit_r; }
                set { VarBasis.RedefinePassValue(value, _ws_data_edit_r, WS_DATA_EDIT); }
            }  //Redefines
            public class _REDEF_CS1301B_WS_DATA_EDIT_R : VarBasis
            {
                /*"    10      WS-DIA-EDIT         PIC  9(002).*/
                public IntBasis WS_DIA_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-MES-EDIT         PIC  9(002).*/
                public IntBasis WS_MES_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-ANO-EDIT         PIC  9(004).*/
                public IntBasis WS_ANO_EDIT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05        WS-HORA-ACCEPT.*/

                public _REDEF_CS1301B_WS_DATA_EDIT_R()
                {
                    WS_DIA_EDIT.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_MES_EDIT.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WS_ANO_EDIT.ValueChanged += OnValueChanged;
                }

            }
            public CS1301B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new CS1301B_WS_HORA_ACCEPT();
            public class CS1301B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10      WS-HOR-ACCEPT       PIC  9(002).*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-MIN-ACCEPT       PIC  9(002).*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-SEG-ACCEPT       PIC  9(002).*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WS-CSS-ACCEPT       PIC  9(002).*/
                public IntBasis WS_CSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-HORA-EDIT        PIC  X(008)    VALUE  SPACES.*/
            }
            public StringBasis WS_HORA_EDIT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05        WS-HORA-EDIT-R      REDEFINES      WS-HORA-EDIT.*/
            private _REDEF_CS1301B_WS_HORA_EDIT_R _ws_hora_edit_r { get; set; }
            public _REDEF_CS1301B_WS_HORA_EDIT_R WS_HORA_EDIT_R
            {
                get { _ws_hora_edit_r = new _REDEF_CS1301B_WS_HORA_EDIT_R(); _.Move(WS_HORA_EDIT, _ws_hora_edit_r); VarBasis.RedefinePassValue(WS_HORA_EDIT, _ws_hora_edit_r, WS_HORA_EDIT); _ws_hora_edit_r.ValueChanged += () => { _.Move(_ws_hora_edit_r, WS_HORA_EDIT); }; return _ws_hora_edit_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_edit_r, WS_HORA_EDIT); }
            }  //Redefines
            public class _REDEF_CS1301B_WS_HORA_EDIT_R : VarBasis
            {
                /*"    10      WS-HOR-EDIT         PIC  9(002).*/
                public IntBasis WS_HOR_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-MIN-EDIT         PIC  9(002).*/
                public IntBasis WS_MIN_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WS-SEG-EDIT         PIC  9(002).*/
                public IntBasis WS_SEG_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WS-DATA-CURR.*/

                public _REDEF_CS1301B_WS_HORA_EDIT_R()
                {
                    WS_HOR_EDIT.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                    WS_MIN_EDIT.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WS_SEG_EDIT.ValueChanged += OnValueChanged;
                }

            }
            public CS1301B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new CS1301B_WS_DATA_CURR();
            public class CS1301B_WS_DATA_CURR : VarBasis
            {
                /*"    10      WS-DIA-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-MES-CURR         PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)    VALUE  SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-ANO-CURR         PIC  9(004)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WS-DATA-ACCEPT.*/
            }
            public CS1301B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new CS1301B_WS_DATA_ACCEPT();
            public class CS1301B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10      WS-ANO-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-MES-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-DIA-ACCEPT       PIC  9(002)    VALUE  ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        LC01.*/
            }
            public CS1301B_LC01 LC01 { get; set; } = new CS1301B_LC01();
            public class CS1301B_LC01 : VarBasis
            {
                /*"    10      FILLER              PIC  X(104)    VALUE           'CPF/CNPJ;APOLICE;ENDOSSO;PARCELA;EMISSAO;RCAP;PROPOST           'A CONVENIO;VENCIMENTO;QUITACAO;VALOR RCAP;PREMIO TO'*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "104", "X(104)"), @"CPF/CNPJ;APOLICE;ENDOSSO;PARCELA;EMISSAO;RCAP;PROPOST           ");
                /*"    10      FILLER              PIC  X(096)    VALUE           'TAL;PREMIO PAGO;PREMIO TOTAL - PREMIO PAGO;VALOR RCAP           ' - PREMIO PAGO;'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "96", "X(096)"), @"TAL;PREMIO PAGO;PREMIO TOTAL - PREMIO PAGO;VALOR RCAP           ");
                /*"  05        LD01.*/
            }
            public CS1301B_LD01 LD01 { get; set; } = new CS1301B_LD01();
            public class CS1301B_LD01 : VarBasis
            {
                /*"    10      LD01-CGCCPF         PIC  9(015)    VALUE ZEROS.*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    10      LD01-SEP01          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-APOLICE        PIC  9(013)    VALUE ZEROS.*/
                public IntBasis LD01_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
                /*"    10      LD01-SEP02          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-ENDOSSO        PIC  9(006)    VALUE ZEROS.*/
                public IntBasis LD01_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
                /*"    10      LD01-SEP03          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-PARCELA        PIC  9(002)    VALUE ZEROS.*/
                public IntBasis LD01_PARCELA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      LD01-SEP04          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-EMISSAO        PIC  X(010)    VALUE SPACES.*/
                public StringBasis LD01_EMISSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      LD01-SEP05          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-RCAP           PIC  9(011)    VALUE ZEROS.*/
                public IntBasis LD01_RCAP { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
                /*"    10      LD01-SEP06          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-PROPCONV       PIC  9(015)    VALUE ZEROS.*/
                public IntBasis LD01_PROPCONV { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
                /*"    10      LD01-SEP07          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-VENCIMENTO     PIC  X(010)    VALUE ZEROS.*/
                public StringBasis LD01_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      LD01-SEP08          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-QUITACAO       PIC  X(010)    VALUE ZEROS.*/
                public StringBasis LD01_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10      LD01-SEP09          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-VLR-RCAP       PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VLR_RCAP { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10      LD01-SEP10          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-VLR-PRM        PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VLR_PRM { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10      LD01-SEP11          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-VLR-PRM-PAG    PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_VLR_PRM_PAG { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10      LD01-SEP12          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-DIFER1         PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_DIFER1 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10      LD01-SEP13          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      LD01-DIFER2         PIC  ZZ.ZZZ.ZZ9,99-.*/
                public DoubleBasis LD01_DIFER2 { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99-."), 3);
                /*"    10      LD01-SEP14          PIC  X(001)    VALUE SPACES.*/
                public StringBasis LD01_SEP14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"01          WABEND.*/
            }
        }
        public CS1301B_WABEND WABEND { get; set; } = new CS1301B_WABEND();
        public class CS1301B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC X(010) VALUE           ' CS1301B'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" CS1301B");
            /*"  05        FILLER              PIC X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC X(005) VALUE '00000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"00000");
            /*"  05        FILLER              PIC X(013) VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"01          WSQLERRO.*/
        }
        public CS1301B_WSQLERRO WSQLERRO { get; set; } = new CS1301B_WSQLERRO();
        public class CS1301B_WSQLERRO : VarBasis
        {
            /*"  05        FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
            /*"  05        WSQLERRMC           PIC  X(070) VALUE SPACES.*/
            public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        }


        public Copies.LBCS0701 LBCS0701 { get; set; } = new Copies.LBCS0701();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.APOLIAUT APOLIAUT { get; set; } = new Dclgens.APOLIAUT();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public CS1301B_PARCELAS PARCELAS { get; set; } = new CS1301B_PARCELAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CS1301BO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CS1301BO.SetFile(CS1301BO_FILE_NAME_P);

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

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -230- MOVE 'R0000' TO WNR-EXEC-SQL. */
            _.Move("R0000", WABEND.WNR_EXEC_SQL);

            /*" -231- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -234- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -237- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -241- MOVE '00/00/0000' TO WS-DATA-EDIT. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDIT);

            /*" -242- MOVE WHOST-DTCURRENT TO WS-DATA-AUX. */
            _.Move(WHOST_DTCURRENT, AREA_DE_WORK.WS_DATA_AUX);

            /*" -243- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -244- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -246- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -248- MOVE '00:00:00' TO WS-HORA-EDIT. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_EDIT);

            /*" -249- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -250- MOVE WS-HOR-ACCEPT TO WS-HOR-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_HOR_EDIT);

            /*" -251- MOVE WS-MIN-ACCEPT TO WS-MIN-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_MIN_EDIT);

            /*" -253- MOVE WS-SEG-ACCEPT TO WS-SEG-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_SEG_EDIT);

            /*" -254- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -255- DISPLAY WS-VERSAO */
            _.Display(WS_VERSAO);

            /*" -258- DISPLAY 'CS1301B - Inicio de Execucao - ' WS-DATA-EDIT ' - ' WS-HORA-EDIT. */

            $"CS1301B - Inicio de Execucao - {AREA_DE_WORK.WS_DATA_EDIT} - {AREA_DE_WORK.WS_HORA_EDIT}"
            .Display();

            /*" -260- OPEN OUTPUT CS1301BO. */
            CS1301BO.Open(REG_CS1301BO);

            /*" -262- WRITE REG-CS1301BO FROM LC01. */
            _.Move(AREA_DE_WORK.LC01.GetMoveValues(), REG_CS1301BO);

            CS1301BO.Write(REG_CS1301BO.GetMoveValues().ToString());

            /*" -263- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -264- PERFORM R0130-00-SELECT-CONGENERE. */

            R0130_00_SELECT_CONGENERE_SECTION();

            /*" -266- PERFORM R0200-00-SELECT-RELATORI */

            R0200_00_SELECT_RELATORI_SECTION();

            /*" -267- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -268- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -269- DISPLAY '|   CS1301B  - Resultado Processo   |' . */
            _.Display($"|   CS1301B  - Resultado Processo   |");

            /*" -271- DISPLAY '+-----------------------------------+' . */
            _.Display($"+-----------------------------------+");

            /*" -272- DISPLAY '|                                   |' */
            _.Display($"|                                   |");

            /*" -274- DISPLAY '| Data Sistema CS ..... ' SISTEMAS-DATA-MOV-ABERTO '  |' */

            $"| Data Sistema CS ..... {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}  |"
            .Display();

            /*" -276- DISPLAY '| Data Solicitacao .... ' RELATORI-DATA-SOLICITACAO '  |' */

            $"| Data Solicitacao .... {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO}  |"
            .Display();

            /*" -278- DISPLAY '| Data Referencia ..... ' RELATORI-DATA-REFERENCIA '  |' */

            $"| Data Referencia ..... {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}  |"
            .Display();

            /*" -279- DISPLAY '|                                   |' */
            _.Display($"|                                   |");

            /*" -281- DISPLAY '| Periodo: ' RELATORI-DATA-REFERENCIA ' a ' SISTEMAS-DATA-MOV-1D '  |' */

            $"| Periodo: {RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA} a {SISTEMAS_DATA_MOV_1D}  |"
            .Display();

            /*" -282- DISPLAY '|                                   |' */
            _.Display($"|                                   |");

            /*" -285- DISPLAY '| Proximo: ' SISTEMAS-DATA-MOV-ABERTO ' a ' SISTEMAS-DATA-MOV-6D '  |' */

            $"| Proximo: {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO} a {SISTEMAS_DATA_MOV_6D}  |"
            .Display();

            /*" -287- PERFORM R1000-00-PROCESSO-PRINCIPAL */

            R1000_00_PROCESSO_PRINCIPAL_SECTION();

            /*" -289- PERFORM R0210-00-UPDATE-RELATORI */

            R0210_00_UPDATE_RELATORI_SECTION();

            /*" -290- MOVE '00/00/0000' TO WS-DATA-EDIT. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDIT);

            /*" -291- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-AUX. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_AUX);

            /*" -292- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -293- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -295- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -296- MOVE '00/00/0000' TO WS-DATA-EDIT. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_EDIT);

            /*" -297- MOVE SISTEMAS-DATA-MOV-ABERTO TO WS-DATA-AUX. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WS_DATA_AUX);

            /*" -298- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -299- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -301- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -302- MOVE WHOST-DTCURRENT TO WS-DATA-AUX. */
            _.Move(WHOST_DTCURRENT, AREA_DE_WORK.WS_DATA_AUX);

            /*" -303- MOVE WS-DIA-AUX TO WS-DIA-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -304- MOVE WS-MES-AUX TO WS-MES-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -306- MOVE WS-ANO-AUX TO WS-ANO-EDIT. */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -307- MOVE '00:00:00' TO WS-HORA-EDIT. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_EDIT);

            /*" -308- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -309- MOVE WS-HOR-ACCEPT TO WS-HOR-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_HOR_EDIT);

            /*" -310- MOVE WS-MIN-ACCEPT TO WS-MIN-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_MIN_EDIT);

            /*" -312- MOVE WS-SEG-ACCEPT TO WS-SEG-EDIT. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_EDIT_R.WS_SEG_EDIT);

            /*" -313- DISPLAY '|                                   |' */
            _.Display($"|                                   |");

            /*" -314- DISPLAY '| Parcelas Lidas ......... ' WS-CT-LIDOS '  |' */

            $"| Parcelas Lidas ......... {AREA_DE_WORK.WS_CT_LIDOS}  |"
            .Display();

            /*" -315- DISPLAY '| Registros Impressos .... ' WS-CT-GRAVA '  |' */

            $"| Registros Impressos .... {AREA_DE_WORK.WS_CT_GRAVA}  |"
            .Display();

            /*" -316- DISPLAY '|                                   |' */
            _.Display($"|                                   |");

            /*" -318- DISPLAY '+-----------------------------------+' */
            _.Display($"+-----------------------------------+");

            /*" -319- DISPLAY '                               ' . */
            _.Display($"                               ");

            /*" -322- DISPLAY 'CS1301B - Final de execucao  - ' WS-DATA-EDIT ' - ' WS-HORA-EDIT. */

            $"CS1301B - Final de execucao  - {AREA_DE_WORK.WS_DATA_EDIT} - {AREA_DE_WORK.WS_HORA_EDIT}"
            .Display();

            /*" -324- CLOSE CS1301BO. */
            CS1301BO.Close();

            /*" -324- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -329- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -329- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -340- MOVE 'R0100' TO WNR-EXEC-SQL. */
            _.Move("R0100", WABEND.WNR_EXEC_SQL);

            /*" -351- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -354- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -355- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS (CS)' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS (CS)");

                /*" -355- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -351- EXEC SQL SELECT DATA_MOV_ABERTO , (DATA_MOV_ABERTO + 6 DAYS) , (DATA_MOV_ABERTO - 1 DAY) , CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO , :SISTEMAS-DATA-MOV-6D , :SISTEMAS-DATA-MOV-1D , :WHOST-DTCURRENT FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'CS' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOV_6D, SISTEMAS_DATA_MOV_6D);
                _.Move(executed_1.SISTEMAS_DATA_MOV_1D, SISTEMAS_DATA_MOV_1D);
                _.Move(executed_1.WHOST_DTCURRENT, WHOST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0130-00-SELECT-CONGENERE-SECTION */
        private void R0130_00_SELECT_CONGENERE_SECTION()
        {
            /*" -365- MOVE 'R0130' TO WNR-EXEC-SQL. */
            _.Move("R0130", WABEND.WNR_EXEC_SQL);

            /*" -366- MOVE '02' TO CS0701S-OPERACAO */
            _.Move("02", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_OPERACAO);

            /*" -367- MOVE 1 TO CS0701S-COD-PARAM */
            _.Move(1, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PARAM);

            /*" -368- MOVE 'AUTO' TO CS0701S-CLASSE-PARAM */
            _.Move("AUTO", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_CLASSE_PARAM);

            /*" -369- MOVE 'AU' TO CS0701S-COD-SISTEMA */
            _.Move("AU", LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_SISTEMA);

            /*" -370- MOVE 0 TO CS0701S-COD-PRODUTO */
            _.Move(0, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_PRODUTO);

            /*" -372- MOVE SISTEMAS-DATA-MOV-ABERTO TO CS0701S-DATA-INIVIGENCIA */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA);

            /*" -374- CALL 'CS0701S' USING CS0701S-AREA-PARAMETROS */
            _.Call("CS0701S", LBCS0701.CS0701S_AREA_PARAMETROS);

            /*" -376- IF CS0701S-COD-RETORNO > 0 OR CS0701S-TB-VALOR-INT(1) = 0 */

            if (LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO > 0 || LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[1].CS0701S_TB_VALOR_INT == 0)
            {

                /*" -377- DISPLAY ' COD=' CS0701S-COD-RETORNO */
                _.Display($" COD={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_COD_RETORNO}");

                /*" -378- DISPLAY ' MSG=' CS0701S-MSG-RETORNO */
                _.Display($" MSG={LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_MSG_RETORNO}");

                /*" -379- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -381- END-IF */
            }


            /*" -382- MOVE CS0701S-TB-VALOR-INT(1) TO WS-COD-CONGENERE */
            _.Move(LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_TABELA_SAIDA.CS0701S_TAB_SAIDA[1].CS0701S_TB_VALOR_INT, WS_COD_CONGENERE);

            /*" -384- DISPLAY 'R0130-00-COD-CONGENERE:' WS-COD-CONGENERE ' DATA-CONGENERE:' CS0701S-DATA-INIVIGENCIA */

            $"R0130-00-COD-CONGENERE:{WS_COD_CONGENERE} DATA-CONGENERE:{LBCS0701.CS0701S_AREA_PARAMETROS.CS0701S_DATA_INIVIGENCIA}"
            .Display();

            /*" -384- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-RELATORI-SECTION */
        private void R0200_00_SELECT_RELATORI_SECTION()
        {
            /*" -397- MOVE 'R0200' TO WNR-EXEC-SQL. */
            _.Move("R0200", WABEND.WNR_EXEC_SQL);

            /*" -412- PERFORM R0200_00_SELECT_RELATORI_DB_SELECT_1 */

            R0200_00_SELECT_RELATORI_DB_SELECT_1();

            /*" -415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -416- DISPLAY 'R0200 - ERRO NO SELECT DA RELATORI' */
                _.Display($"R0200 - ERRO NO SELECT DA RELATORI");

                /*" -416- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-RELATORI-DB-SELECT-1 */
        public void R0200_00_SELECT_RELATORI_DB_SELECT_1()
        {
            /*" -412- EXEC SQL SELECT DATA_SOLICITACAO , DATA_REFERENCIA , PERI_INICIAL , PERI_FINAL , (PERI_INICIAL + 7 DAYS), (PERI_FINAL + 7 DAYS) INTO :RELATORI-DATA-SOLICITACAO , :RELATORI-DATA-REFERENCIA , :RELATORI-PERI-INICIAL , :RELATORI-PERI-FINAL , :RELATORI-PROX-INICIAL , :RELATORI-PROX-FINAL FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'CS1301B1' END-EXEC. */

            var r0200_00_SELECT_RELATORI_DB_SELECT_1_Query1 = new R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_RELATORI_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_RELATORI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(executed_1.RELATORI_DATA_REFERENCIA, RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA);
                _.Move(executed_1.RELATORI_PERI_INICIAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL);
                _.Move(executed_1.RELATORI_PERI_FINAL, RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL);
                _.Move(executed_1.RELATORI_PROX_INICIAL, RELATORI_PROX_INICIAL);
                _.Move(executed_1.RELATORI_PROX_FINAL, RELATORI_PROX_FINAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0210-00-UPDATE-RELATORI-SECTION */
        private void R0210_00_UPDATE_RELATORI_SECTION()
        {
            /*" -430- MOVE 'R0210' TO WNR-EXEC-SQL. */
            _.Move("R0210", WABEND.WNR_EXEC_SQL);

            /*" -437- PERFORM R0210_00_UPDATE_RELATORI_DB_UPDATE_1 */

            R0210_00_UPDATE_RELATORI_DB_UPDATE_1();

            /*" -440- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -441- DISPLAY 'R0210 - ERRO NO UPDATE DA RELATORIOS' */
                _.Display($"R0210 - ERRO NO UPDATE DA RELATORIOS");

                /*" -441- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0210-00-UPDATE-RELATORI-DB-UPDATE-1 */
        public void R0210_00_UPDATE_RELATORI_DB_UPDATE_1()
        {
            /*" -437- EXEC SQL UPDATE SEGUROS.RELATORIOS SET DATA_SOLICITACAO = :SISTEMAS-DATA-MOV-ABERTO, DATA_REFERENCIA = :SISTEMAS-DATA-MOV-ABERTO, PERI_INICIAL = :RELATORI-PROX-INICIAL, PERI_FINAL = :RELATORI-PROX-FINAL WHERE COD_RELATORIO = 'CS1301B1' END-EXEC. */

            var r0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 = new R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                RELATORI_PROX_INICIAL = RELATORI_PROX_INICIAL.ToString(),
                RELATORI_PROX_FINAL = RELATORI_PROX_FINAL.ToString(),
            };

            R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1.Execute(r0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSO-PRINCIPAL-SECTION */
        private void R1000_00_PROCESSO_PRINCIPAL_SECTION()
        {
            /*" -455- MOVE 'R1000' TO WNR-EXEC-SQL. */
            _.Move("R1000", WABEND.WNR_EXEC_SQL);

            /*" -456- MOVE SPACES TO WFIM-PARCELAS */
            _.Move("", AREA_DE_WORK.WFIM_PARCELAS);

            /*" -457- PERFORM R1100-00-DECLARE-PARCELAS */

            R1100_00_DECLARE_PARCELAS_SECTION();

            /*" -458- PERFORM R1110-00-FETCH-PARCELAS */

            R1110_00_FETCH_PARCELAS_SECTION();

            /*" -459- PERFORM R1200-00-PROCESSA-PARCELAS UNTIL WFIM-PARCELAS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_PARCELAS.IsEmpty()))
            {

                R1200_00_PROCESSA_PARCELAS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-DECLARE-PARCELAS-SECTION */
        private void R1100_00_DECLARE_PARCELAS_SECTION()
        {
            /*" -473- MOVE 'R1100' TO WNR-EXEC-SQL. */
            _.Move("R1100", WABEND.WNR_EXEC_SQL);

            /*" -516- PERFORM R1100_00_DECLARE_PARCELAS_DB_DECLARE_1 */

            R1100_00_DECLARE_PARCELAS_DB_DECLARE_1();

            /*" -518- PERFORM R1100_00_DECLARE_PARCELAS_DB_OPEN_1 */

            R1100_00_DECLARE_PARCELAS_DB_OPEN_1();

            /*" -520- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -521- DISPLAY 'R1100 - ERRO NO DECLARE PARCELAS' */
                _.Display($"R1100 - ERRO NO DECLARE PARCELAS");

                /*" -521- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-DECLARE-PARCELAS-DB-DECLARE-1 */
        public void R1100_00_DECLARE_PARCELAS_DB_DECLARE_1()
        {
            /*" -516- EXEC SQL DECLARE PARCELAS CURSOR FOR SELECT T4.CGCCPF, T1.NUM_APOLICE , T1.NUM_ENDOSSO, T2.NUM_PARCELA, T1.DATA_EMISSAO, T1.NUM_RCAP, T3.NUM_PROPOSTA_CONV, T2.DATA_VENCIMENTO, T2.DATA_QUITACAO, T1.VAL_RCAP, T2.PRM_TOTAL, T2.VAL_OPERACAO, (T2.PRM_TOTAL - T2.VAL_OPERACAO), (T1.VAL_RCAP - T2.VAL_OPERACAO) FROM SEGUROS.ENDOSSOS T1, SEGUROS.PARCELA_HISTORICO T2, SEGUROS.APOLICE_AUTO T3, SEGUROS.CLIENTES T4 WHERE T1.NUM_APOLICE = T2.NUM_APOLICE AND T1.NUM_APOLICE = T3.NUM_APOLICE AND T1.NUM_ENDOSSO = T2.NUM_ENDOSSO AND T1.NUM_ENDOSSO = T3.NUM_ENDOSSO AND T3.NUM_ITEM = ( SELECT MAX(T5.NUM_ITEM) FROM SEGUROS.APOLICE_AUTO T5 WHERE T5.NUM_APOLICE = T3.NUM_APOLICE AND T5.NUM_ENDOSSO = T3.NUM_ENDOSSO ) AND T1.NUM_RCAP > 0 AND T2.NUM_PARCELA IN (0, 1) AND T2.PRM_TOTAL > 0 AND T2.PRM_TOTAL <> T2.VAL_OPERACAO AND T3.COD_CONGENERE IN (5118, :WS-COD-CONGENERE) AND T2.COD_OPERACAO BETWEEN 200 AND 299 AND T3.COD_CLIENTE = T4.COD_CLIENTE AND T2.DATA_MOVIMENTO >= :RELATORI-DATA-REFERENCIA AND T2.DATA_MOVIMENTO < :SISTEMAS-DATA-MOV-ABERTO ORDER BY T1.NUM_APOLICE , T1.NUM_ENDOSSO , T2.NUM_PARCELA END-EXEC. */
            PARCELAS = new CS1301B_PARCELAS(true);
            string GetQuery_PARCELAS()
            {
                var query = @$"SELECT T4.CGCCPF
							, 
							T1.NUM_APOLICE
							, 
							T1.NUM_ENDOSSO
							, 
							T2.NUM_PARCELA
							, 
							T1.DATA_EMISSAO
							, 
							T1.NUM_RCAP
							, 
							T3.NUM_PROPOSTA_CONV
							, 
							T2.DATA_VENCIMENTO
							, 
							T2.DATA_QUITACAO
							, 
							T1.VAL_RCAP
							, 
							T2.PRM_TOTAL
							, 
							T2.VAL_OPERACAO
							, 
							(T2.PRM_TOTAL - T2.VAL_OPERACAO)
							, 
							(T1.VAL_RCAP - T2.VAL_OPERACAO) 
							FROM SEGUROS.ENDOSSOS T1
							, 
							SEGUROS.PARCELA_HISTORICO T2
							, 
							SEGUROS.APOLICE_AUTO T3
							, 
							SEGUROS.CLIENTES T4 
							WHERE T1.NUM_APOLICE = T2.NUM_APOLICE 
							AND T1.NUM_APOLICE = T3.NUM_APOLICE 
							AND T1.NUM_ENDOSSO = T2.NUM_ENDOSSO 
							AND T1.NUM_ENDOSSO = T3.NUM_ENDOSSO 
							AND T3.NUM_ITEM = 
							( SELECT MAX(T5.NUM_ITEM) 
							FROM SEGUROS.APOLICE_AUTO T5 
							WHERE T5.NUM_APOLICE = T3.NUM_APOLICE 
							AND T5.NUM_ENDOSSO = T3.NUM_ENDOSSO ) 
							AND T1.NUM_RCAP > 0 
							AND T2.NUM_PARCELA IN (0
							, 1) 
							AND T2.PRM_TOTAL > 0 
							AND T2.PRM_TOTAL <> T2.VAL_OPERACAO 
							AND T3.COD_CONGENERE IN (5118
							, '{WS_COD_CONGENERE}') 
							AND T2.COD_OPERACAO BETWEEN 200 AND 299 
							AND T3.COD_CLIENTE = T4.COD_CLIENTE 
							AND T2.DATA_MOVIMENTO >= '{RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA}' 
							AND T2.DATA_MOVIMENTO < '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY T1.NUM_APOLICE
							, 
							T1.NUM_ENDOSSO
							, 
							T2.NUM_PARCELA";

                return query;
            }
            PARCELAS.GetQueryEvent += GetQuery_PARCELAS;

        }

        [StopWatch]
        /*" R1100-00-DECLARE-PARCELAS-DB-OPEN-1 */
        public void R1100_00_DECLARE_PARCELAS_DB_OPEN_1()
        {
            /*" -518- EXEC SQL OPEN PARCELAS END-EXEC. */

            PARCELAS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1110-00-FETCH-PARCELAS-SECTION */
        private void R1110_00_FETCH_PARCELAS_SECTION()
        {
            /*" -535- MOVE 'R1110' TO WNR-EXEC-SQL. */
            _.Move("R1110", WABEND.WNR_EXEC_SQL);

            /*" -550- PERFORM R1110_00_FETCH_PARCELAS_DB_FETCH_1 */

            R1110_00_FETCH_PARCELAS_DB_FETCH_1();

            /*" -553- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -554- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -555- MOVE 'S' TO WFIM-PARCELAS */
                    _.Move("S", AREA_DE_WORK.WFIM_PARCELAS);

                    /*" -555- PERFORM R1110_00_FETCH_PARCELAS_DB_CLOSE_1 */

                    R1110_00_FETCH_PARCELAS_DB_CLOSE_1();

                    /*" -557- ELSE */
                }
                else
                {


                    /*" -558- DISPLAY 'R1110 - ERRO NO FETCH CURSOR PARCELAS' */
                    _.Display($"R1110 - ERRO NO FETCH CURSOR PARCELAS");

                    /*" -559- DISPLAY 'APOLICE  - ' ENDOSSOS-NUM-APOLICE */
                    _.Display($"APOLICE  - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}");

                    /*" -560- DISPLAY 'ENDOSSO  - ' ENDOSSOS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}");

                    /*" -561- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -562- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -563- ELSE */
                }

            }
            else
            {


                /*" -563- ADD 1 TO WS-CT-LIDOS. */
                AREA_DE_WORK.WS_CT_LIDOS.Value = AREA_DE_WORK.WS_CT_LIDOS + 1;
            }


        }

        [StopWatch]
        /*" R1110-00-FETCH-PARCELAS-DB-FETCH-1 */
        public void R1110_00_FETCH_PARCELAS_DB_FETCH_1()
        {
            /*" -550- EXEC SQL FETCH PARCELAS INTO :CLIENTES-CGCCPF, :ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO, :PARCEHIS-NUM-PARCELA, :ENDOSSOS-DATA-EMISSAO, :ENDOSSOS-NUM-RCAP, :APOLIAUT-NUM-PROPOSTA-CONV, :PARCEHIS-DATA-VENCIMENTO, :PARCEHIS-DATA-QUITACAO, :ENDOSSOS-VAL-RCAP, :PARCEHIS-PRM-TOTAL, :PARCEHIS-VAL-OPERACAO, :PARCEHIS-DIFERENCA1, :PARCEHIS-DIFERENCA2 END-EXEC. */

            if (PARCELAS.Fetch())
            {
                _.Move(PARCELAS.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(PARCELAS.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(PARCELAS.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(PARCELAS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(PARCELAS.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(PARCELAS.ENDOSSOS_NUM_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP);
                _.Move(PARCELAS.APOLIAUT_NUM_PROPOSTA_CONV, APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV);
                _.Move(PARCELAS.PARCEHIS_DATA_VENCIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO);
                _.Move(PARCELAS.PARCEHIS_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);
                _.Move(PARCELAS.ENDOSSOS_VAL_RCAP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP);
                _.Move(PARCELAS.PARCEHIS_PRM_TOTAL, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL);
                _.Move(PARCELAS.PARCEHIS_VAL_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO);
                _.Move(PARCELAS.PARCEHIS_DIFERENCA1, PARCEHIS_DIFERENCA1);
                _.Move(PARCELAS.PARCEHIS_DIFERENCA2, PARCEHIS_DIFERENCA2);
            }

        }

        [StopWatch]
        /*" R1110-00-FETCH-PARCELAS-DB-CLOSE-1 */
        public void R1110_00_FETCH_PARCELAS_DB_CLOSE_1()
        {
            /*" -555- EXEC SQL CLOSE PARCELAS END-EXEC */

            PARCELAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1110_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-PROCESSA-PARCELAS-SECTION */
        private void R1200_00_PROCESSA_PARCELAS_SECTION()
        {
            /*" -577- MOVE 'R1200' TO WNR-EXEC-SQL. */
            _.Move("R1200", WABEND.WNR_EXEC_SQL);

            /*" -578- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, AREA_DE_WORK.LD01.LD01_CGCCPF);

            /*" -579- MOVE ENDOSSOS-NUM-APOLICE TO LD01-APOLICE */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, AREA_DE_WORK.LD01.LD01_APOLICE);

            /*" -580- MOVE ENDOSSOS-NUM-ENDOSSO TO LD01-ENDOSSO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, AREA_DE_WORK.LD01.LD01_ENDOSSO);

            /*" -581- MOVE PARCEHIS-NUM-PARCELA TO LD01-PARCELA */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, AREA_DE_WORK.LD01.LD01_PARCELA);

            /*" -582- MOVE ENDOSSOS-DATA-EMISSAO TO WS-DATA-AUX */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, AREA_DE_WORK.WS_DATA_AUX);

            /*" -583- MOVE WS-DIA-AUX TO WS-DIA-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -584- MOVE WS-MES-AUX TO WS-MES-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -585- MOVE WS-ANO-AUX TO WS-ANO-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -587- MOVE WS-DATA-EDIT TO LD01-EMISSAO */
            _.Move(AREA_DE_WORK.WS_DATA_EDIT, AREA_DE_WORK.LD01.LD01_EMISSAO);

            /*" -588- MOVE ENDOSSOS-NUM-RCAP TO LD01-RCAP */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_RCAP, AREA_DE_WORK.LD01.LD01_RCAP);

            /*" -591- MOVE APOLIAUT-NUM-PROPOSTA-CONV TO LD01-PROPCONV */
            _.Move(APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_NUM_PROPOSTA_CONV, AREA_DE_WORK.LD01.LD01_PROPCONV);

            /*" -592- MOVE PARCEHIS-DATA-VENCIMENTO TO WS-DATA-AUX */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_VENCIMENTO, AREA_DE_WORK.WS_DATA_AUX);

            /*" -593- MOVE WS-DIA-AUX TO WS-DIA-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -594- MOVE WS-MES-AUX TO WS-MES-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -595- MOVE WS-ANO-AUX TO WS-ANO-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -597- MOVE WS-DATA-EDIT TO LD01-VENCIMENTO */
            _.Move(AREA_DE_WORK.WS_DATA_EDIT, AREA_DE_WORK.LD01.LD01_VENCIMENTO);

            /*" -598- MOVE PARCEHIS-DATA-QUITACAO TO WS-DATA-AUX */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO, AREA_DE_WORK.WS_DATA_AUX);

            /*" -599- MOVE WS-DIA-AUX TO WS-DIA-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_DIA_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_DIA_EDIT);

            /*" -600- MOVE WS-MES-AUX TO WS-MES-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_MES_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_MES_EDIT);

            /*" -601- MOVE WS-ANO-AUX TO WS-ANO-EDIT */
            _.Move(AREA_DE_WORK.WS_DATA_AUX_R.WS_ANO_AUX, AREA_DE_WORK.WS_DATA_EDIT_R.WS_ANO_EDIT);

            /*" -603- MOVE WS-DATA-EDIT TO LD01-QUITACAO */
            _.Move(AREA_DE_WORK.WS_DATA_EDIT, AREA_DE_WORK.LD01.LD01_QUITACAO);

            /*" -604- MOVE ENDOSSOS-VAL-RCAP TO LD01-VLR-RCAP */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_VAL_RCAP, AREA_DE_WORK.LD01.LD01_VLR_RCAP);

            /*" -605- MOVE PARCEHIS-PRM-TOTAL TO LD01-VLR-PRM */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TOTAL, AREA_DE_WORK.LD01.LD01_VLR_PRM);

            /*" -606- MOVE PARCEHIS-VAL-OPERACAO TO LD01-VLR-PRM-PAG */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_OPERACAO, AREA_DE_WORK.LD01.LD01_VLR_PRM_PAG);

            /*" -607- MOVE PARCEHIS-DIFERENCA1 TO LD01-DIFER1 */
            _.Move(PARCEHIS_DIFERENCA1, AREA_DE_WORK.LD01.LD01_DIFER1);

            /*" -609- MOVE PARCEHIS-DIFERENCA2 TO LD01-DIFER2 */
            _.Move(PARCEHIS_DIFERENCA2, AREA_DE_WORK.LD01.LD01_DIFER2);

            /*" -611- PERFORM R2000-00-GRAVA-CS1301BO */

            R2000_00_GRAVA_CS1301BO_SECTION();

            /*" -611- PERFORM R1110-00-FETCH-PARCELAS. */

            R1110_00_FETCH_PARCELAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GRAVA-CS1301BO-SECTION */
        private void R2000_00_GRAVA_CS1301BO_SECTION()
        {
            /*" -625- MOVE 'R2000' TO WNR-EXEC-SQL. */
            _.Move("R2000", WABEND.WNR_EXEC_SQL);

            /*" -633- MOVE ';' TO LD01-SEP01 LD01-SEP02 LD01-SEP03 LD01-SEP04 LD01-SEP05 LD01-SEP06 LD01-SEP07 LD01-SEP08 LD01-SEP09 LD01-SEP10 LD01-SEP11 LD01-SEP12 LD01-SEP13. */
            _.Move(";", AREA_DE_WORK.LD01.LD01_SEP01, AREA_DE_WORK.LD01.LD01_SEP02, AREA_DE_WORK.LD01.LD01_SEP03, AREA_DE_WORK.LD01.LD01_SEP04, AREA_DE_WORK.LD01.LD01_SEP05, AREA_DE_WORK.LD01.LD01_SEP06, AREA_DE_WORK.LD01.LD01_SEP07, AREA_DE_WORK.LD01.LD01_SEP08, AREA_DE_WORK.LD01.LD01_SEP09, AREA_DE_WORK.LD01.LD01_SEP10, AREA_DE_WORK.LD01.LD01_SEP11, AREA_DE_WORK.LD01.LD01_SEP12, AREA_DE_WORK.LD01.LD01_SEP13);

            /*" -634- WRITE REG-CS1301BO FROM LD01. */
            _.Move(AREA_DE_WORK.LD01.GetMoveValues(), REG_CS1301BO);

            CS1301BO.Write(REG_CS1301BO.GetMoveValues().ToString());

            /*" -636- MOVE SPACES TO LD01. */
            _.Move("", AREA_DE_WORK.LD01);

            /*" -636- ADD 1 TO WS-CT-GRAVA. */
            AREA_DE_WORK.WS_CT_GRAVA.Value = AREA_DE_WORK.WS_CT_GRAVA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -651- CLOSE CS1301BO. */
            CS1301BO.Close();

            /*" -652- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -654- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, WSQLERRO.WSQLERRMC);

            /*" -655- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -657- DISPLAY WSQLERRO. */
            _.Display(WSQLERRO);

            /*" -657- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -661- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -661- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}