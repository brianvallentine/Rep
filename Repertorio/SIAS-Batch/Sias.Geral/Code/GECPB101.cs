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
using Sias.Geral.DB2.GECPB101;

namespace Code
{
    public class GECPB101
    {
        public bool IsCall { get; set; }

        public GECPB101()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *------------------------------------*                                  */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ............... MCP - MODULO DE INTERFACE DE COBRANCA*      */
        /*"      *                                 E PAGAMENTO.                   *      */
        /*"      *   PROGRAMA .............. GECPB101                             *      */
        /*"      *   COMPILACAO ............ CB2                                  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA .............. CARLOS A DE A ALVES                  *      */
        /*"      *   PROGRAMADOR ........... CARLOS A DE A ALVES                  *      */
        /*"      *   DATA CODIFICACAO ...... JUNHO-2022                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................ GERAR ARQUIVO COM A MOVIMENTACAO DIA *      */
        /*"      *                           NO MCP REFERENTE AOS PAGAMENTOS DE   *      */
        /*"      *                           SINISTROS DO SIAS IMPLEMENTADOS PELO *      */
        /*"      *                           PROJETO DESCONFORMIDADE SIAS         *      */
        /*"      *                           E DISPONIBILIZAR EM PASTA DO SERVIDOR*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      H I S T O R I C O                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    DATA    ANALISTA  VERSAO  OBJETIVO                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 14/06/2022 CARLOS A  V0      IMPLANTACAO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 18/05/2023 GILSON    V1      INCLUIR A COLUNA COD_MODULO_SAP   *      */
        /*"      *                              NAS TABELAS E ATUALIZAR COMO NULO *      */
        /*"      *                              TODA VEZ QUE A COLUNA NUM_NSA_SAP *      */
        /*"      *                              FOR NULO                          *      */
        /*"      *      GE_SOLICITA_AP_CA_SAP_HIST (GE537),                       *      */
        /*"      *      GE_DET_ARQ_H_RETORNO_SAP (GE577)                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CPB101S1 { get; set; } = new FileBasis(new PIC("X", "404", "X(404)"));

        public FileBasis CPB101S1
        {
            get
            {
                _.Move(REG_CPB101S1, _CPB101S1); VarBasis.RedefinePassValue(REG_CPB101S1, _CPB101S1, REG_CPB101S1); return _CPB101S1;
            }
        }
        public FileBasis _CPB101S2 { get; set; } = new FileBasis(new PIC("X", "218", "X(218)"));

        public FileBasis CPB101S2
        {
            get
            {
                _.Move(REG_CPB101S2, _CPB101S2); VarBasis.RedefinePassValue(REG_CPB101S2, _CPB101S2, REG_CPB101S2); return _CPB101S2;
            }
        }
        /*"01        REG-CPB101S1        PIC  X(404).*/
        public StringBasis REG_CPB101S1 { get; set; } = new StringBasis(new PIC("X", "404", "X(404)."), @"");
        /*"01        REG-CPB101S2        PIC  X(218).*/
        public StringBasis REG_CPB101S2 { get; set; } = new StringBasis(new PIC("X", "218", "X(218)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WS-HOST-DTA-LOTE           PIC  X(010)      VALUE SPACES.*/
        public StringBasis WS_HOST_DTA_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77 WS-HOST-DES-FORMA          PIC  X(030)      VALUE SPACES.*/
        public StringBasis WS_HOST_DES_FORMA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
        /*"77 WS-HOST-DES-TIPO-MOV       PIC  X(020)      VALUE SPACES.*/
        public StringBasis WS_HOST_DES_TIPO_MOV { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
        /*"77 WS-HOST-DES-STA-PROCES     PIC  X(012)      VALUE SPACES.*/
        public StringBasis WS_HOST_DES_STA_PROCES { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
        /*"01        AREA-DE-WORK.*/
        public GECPB101_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GECPB101_AREA_DE_WORK();
        public class GECPB101_AREA_DE_WORK : VarBasis
        {
            /*"  05      WSTATUS               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSL-SQLCODE           PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WFIM-C01              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-C01              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-G-CPB101S1         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_G_CPB101S1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WFIM-C02              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-C02              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-G-CPB101S2         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_G_CPB101S2 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WDATA-EDIT.*/
            public GECPB101_WDATA_EDIT WDATA_EDIT { get; set; } = new GECPB101_WDATA_EDIT();
            public class GECPB101_WDATA_EDIT : VarBasis
            {
                /*"    10    WDAT-DIA-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-MES-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-ANO-EDT          PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDAT_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WDATA-AUX             PIC  X(010)      VALUE SPACES.*/
            }
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-AUX-R           REDEFINES        WDATA-AUX.*/
            private _REDEF_GECPB101_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_GECPB101_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_GECPB101_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_GECPB101_WDATA_AUX_R : VarBasis
            {
                /*"    10    WDAT-ANO-AUX          PIC  9(004).*/
                public IntBasis WDAT_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-MES-AUX          PIC  9(002).*/
                public IntBasis WDAT_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-DIA-AUX          PIC  9(002).*/
                public IntBasis WDAT_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-CURR.*/

                public _REDEF_GECPB101_WDATA_AUX_R()
                {
                    WDAT_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public GECPB101_WDATA_CURR WDATA_CURR { get; set; } = new GECPB101_WDATA_CURR();
            public class GECPB101_WDATA_CURR : VarBasis
            {
                /*"    10    WDATA-AA-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WDATA-MM-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WDATA-DD-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WHORA-CURR.*/
            }
            public GECPB101_WHORA_CURR WHORA_CURR { get; set; } = new GECPB101_WHORA_CURR();
            public class GECPB101_WHORA_CURR : VarBasis
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
            public GECPB101_WHORA_EDIT WHORA_EDIT { get; set; } = new GECPB101_WHORA_EDIT();
            public class GECPB101_WHORA_EDIT : VarBasis
            {
                /*"    10    WHORA-HH-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-MM-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-SS-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WS-TIMESTAMP          PIC  X(026)      VALUE SPACES.*/
            }
            public StringBasis WS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"  05      WS-COD-IDLG           PIC  X(021)      VALUE SPACES.*/
            public StringBasis WS_COD_IDLG { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"  05      WS-COD-IDLG-R         REDEFINES        WS-COD-IDLG.*/
            private _REDEF_GECPB101_WS_COD_IDLG_R _ws_cod_idlg_r { get; set; }
            public _REDEF_GECPB101_WS_COD_IDLG_R WS_COD_IDLG_R
            {
                get { _ws_cod_idlg_r = new _REDEF_GECPB101_WS_COD_IDLG_R(); _.Move(WS_COD_IDLG, _ws_cod_idlg_r); VarBasis.RedefinePassValue(WS_COD_IDLG, _ws_cod_idlg_r, WS_COD_IDLG); _ws_cod_idlg_r.ValueChanged += () => { _.Move(_ws_cod_idlg_r, WS_COD_IDLG); }; return _ws_cod_idlg_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cod_idlg_r, WS_COD_IDLG); }
            }  //Redefines
            public class _REDEF_GECPB101_WS_COD_IDLG_R : VarBasis
            {
                /*"    10    WS-COD-IDLG-MCP       PIC  X(003).*/
                public StringBasis WS_COD_IDLG_MCP { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"    10    WS-NUM-IDLG           PIC  9(018).*/
                public IntBasis WS_NUM_IDLG { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
                /*"01  DES-RETORNO.*/

                public _REDEF_GECPB101_WS_COD_IDLG_R()
                {
                    WS_COD_IDLG_MCP.ValueChanged += OnValueChanged;
                    WS_NUM_IDLG.ValueChanged += OnValueChanged;
                }

            }
        }
        public GECPB101_DES_RETORNO DES_RETORNO { get; set; } = new GECPB101_DES_RETORNO();
        public class GECPB101_DES_RETORNO : VarBasis
        {
            /*"    49 ARQ-H-LEN                PIC S9(004)      USAGE COMP.*/
            public IntBasis ARQ_H_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    49 ARQ-H-TEXT               PIC  X(220).*/
            public StringBasis ARQ_H_TEXT { get; set; } = new StringBasis(new PIC("X", "220", "X(220)."), @"");
            /*"01        WS-ARQ-CPB101S1.*/
        }
        public GECPB101_WS_ARQ_CPB101S1 WS_ARQ_CPB101S1 { get; set; } = new GECPB101_WS_ARQ_CPB101S1();
        public class GECPB101_WS_ARQ_CPB101S1 : VarBasis
        {
            /*"  05      WS-ARQ-CAB-CPB101S1.*/
            public GECPB101_WS_ARQ_CAB_CPB101S1 WS_ARQ_CAB_CPB101S1 { get; set; } = new GECPB101_WS_ARQ_CAB_CPB101S1();
            public class GECPB101_WS_ARQ_CAB_CPB101S1 : VarBasis
            {
                /*"    10    FILLER                PIC  X(010)      VALUE          'DTA-LOTE  '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTA_LOTE  ");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(006)      VALUE          'ORIGEM'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ORIGEM");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(010)      VALUE          'EVENTO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"EVENTO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(021)      VALUE          'IDLG'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"IDLG");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(018)      VALUE          '          SINISTRO'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"          SINISTRO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(018)      VALUE          '           APOLICE'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"           APOLICE");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(040)      VALUE          'CHAVE-NEGOCIO'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"CHAVE_NEGOCIO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(020)      VALUE          '           VLR-PAGAR'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"           VLR_PAGAR");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(013)      VALUE          'DTA-MOVIMENTO'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"DTA_MOVIMENTO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(010)      VALUE          'DTA-PAGAR '.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTA_PAGAR ");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(030)      VALUE          'FORMA-PAGAR'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"FORMA_PAGAR");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(020)      VALUE          'TIPO-MOVIMENTO'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"TIPO_MOVIMENTO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(012)      VALUE          'RETORNO-SAP'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"RETORNO_SAP");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(009)      VALUE          'COD-ARQ-H'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COD_ARQ_H");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(050)      VALUE          'DES-ARQ-H'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"DES_ARQ_H");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(050)      VALUE          'NOM-EXTERNO-ARQ-A'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOM_EXTERNO_ARQ_A");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(050)      VALUE          'NOM-EXTERNO-ARQ-H'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOM_EXTERNO_ARQ_H");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      WS-ARQ-DET-CPB101S1.*/
            }
            public GECPB101_WS_ARQ_DET_CPB101S1 WS_ARQ_DET_CPB101S1 { get; set; } = new GECPB101_WS_ARQ_DET_CPB101S1();
            public class GECPB101_WS_ARQ_DET_CPB101S1 : VarBasis
            {
                /*"    10    DET-DTA-LOTE          PIC  X(010)      VALUE SPACES.*/
                public StringBasis DET_DTA_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-ORIGEM            PIC  X(004)      VALUE SPACES.*/
                public StringBasis DET_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(002)      VALUE SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-EVENTO            PIC  X(010)      VALUE SPACES.*/
                public StringBasis DET_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-IDLG              PIC  X(021)      VALUE SPACES.*/
                public StringBasis DET_IDLG { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-SINISTRO          PIC  ZZZZZ9999999999999.*/
                public IntBasis DET_SINISTRO { get; set; } = new IntBasis(new PIC("9", "18", "ZZZZZ9999999999999."));
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-APOLICE           PIC  ZZZZZ9999999999999.*/
                public IntBasis DET_APOLICE { get; set; } = new IntBasis(new PIC("9", "18", "ZZZZZ9999999999999."));
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-CHAVE-NEGOCIO     PIC  X(040)      VALUE SPACES.*/
                public StringBasis DET_CHAVE_NEGOCIO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-VLR-PAGAR         PIC  ----------------9,99.*/
                public DoubleBasis DET_VLR_PAGAR { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-DTA-MOVIMENTO     PIC  X(010)      VALUE SPACES.*/
                public StringBasis DET_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(003)      VALUE SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-DTA-PAGAR         PIC  X(010)      VALUE SPACES.*/
                public StringBasis DET_DTA_PAGAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-FORMA             PIC  X(030)      VALUE SPACES.*/
                public StringBasis DET_FORMA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-TIPO-MOVIMENTO    PIC  X(020)      VALUE SPACES.*/
                public StringBasis DET_TIPO_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-RETORNO-SAP       PIC  X(012)      VALUE SPACES.*/
                public StringBasis DET_RETORNO_SAP { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-COD-ARQ-H         PIC  X(006)      VALUE SPACES.*/
                public StringBasis DET_COD_ARQ_H { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10    FILLER                PIC  X(003)      VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-DES-ARQ-H         PIC  X(050)      VALUE SPACES.*/
                public StringBasis DET_DES_ARQ_H { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-NOM-ARQ-A         PIC  X(050)      VALUE SPACES.*/
                public StringBasis DET_NOM_ARQ_A { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DET-NOM-ARQ-H         PIC  X(050)      VALUE SPACES.*/
                public StringBasis DET_NOM_ARQ_H { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"01        WS-ARQ-CPB101S2.*/
            }
        }
        public GECPB101_WS_ARQ_CPB101S2 WS_ARQ_CPB101S2 { get; set; } = new GECPB101_WS_ARQ_CPB101S2();
        public class GECPB101_WS_ARQ_CPB101S2 : VarBasis
        {
            /*"  05      WS-ARQ-CAB-CPB101S2.*/
            public GECPB101_WS_ARQ_CAB_CPB101S2 WS_ARQ_CAB_CPB101S2 { get; set; } = new GECPB101_WS_ARQ_CAB_CPB101S2();
            public class GECPB101_WS_ARQ_CAB_CPB101S2 : VarBasis
            {
                /*"    10    FILLER                PIC  X(010)      VALUE          'DTA-LOTE  '.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTA_LOTE  ");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(006)      VALUE          'ORIGEM'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"ORIGEM");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(010)      VALUE          'EVENTO'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"EVENTO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(024)      VALUE          'COD-LOTE-ARQ-A'.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"COD_LOTE_ARQ_A");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(021)      VALUE          'IDLG'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"IDLG");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(018)      VALUE          '          SINISTRO'.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"          SINISTRO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(018)      VALUE          '           APOLICE'.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"           APOLICE");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(040)      VALUE          'CHAVE-NEGOCIO'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"CHAVE_NEGOCIO");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(020)      VALUE          '           VLR-PAGAR'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"           VLR_PAGAR");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(010)      VALUE          'DTA-PAGAR '.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"DTA_PAGAR ");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    FILLER                PIC  X(030)      VALUE          'FORMA-PAGAR'.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"FORMA_PAGAR");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"  05      WS-ARQ-DET-CPB101S2.*/
            }
            public GECPB101_WS_ARQ_DET_CPB101S2 WS_ARQ_DET_CPB101S2 { get; set; } = new GECPB101_WS_ARQ_DET_CPB101S2();
            public class GECPB101_WS_ARQ_DET_CPB101S2 : VarBasis
            {
                /*"    10    DETS2-DTA-LOTE        PIC  X(010)      VALUE SPACES.*/
                public StringBasis DETS2_DTA_LOTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-ORIGEM          PIC  X(004)      VALUE SPACES.*/
                public StringBasis DETS2_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(002)      VALUE SPACES.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-EVENTO          PIC  X(010)      VALUE SPACES.*/
                public StringBasis DETS2_EVENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-COD-LOTE-A      PIC  X(024)      VALUE SPACES.*/
                public StringBasis DETS2_COD_LOTE_A { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-IDLG            PIC  X(021)      VALUE SPACES.*/
                public StringBasis DETS2_IDLG { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-SINISTRO        PIC  ZZZZZ9999999999999.*/
                public IntBasis DETS2_SINISTRO { get; set; } = new IntBasis(new PIC("9", "18", "ZZZZZ9999999999999."));
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-APOLICE         PIC  ZZZZZ9999999999999.*/
                public IntBasis DETS2_APOLICE { get; set; } = new IntBasis(new PIC("9", "18", "ZZZZZ9999999999999."));
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-CHAVE-NEGOCIO   PIC  X(040)      VALUE SPACES.*/
                public StringBasis DETS2_CHAVE_NEGOCIO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-VLR-PAGAR       PIC  ----------------9,99.*/
                public DoubleBasis DETS2_VLR_PAGAR { get; set; } = new DoubleBasis(new PIC("9", "17", "----------------9V99."), 2);
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-DTA-PAGAR       PIC  X(010)      VALUE SPACES.*/
                public StringBasis DETS2_DTA_PAGAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"    10    DETS2-FORMA           PIC  X(030)      VALUE SPACES.*/
                public StringBasis DETS2_FORMA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE ';'.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
                /*"01        LK-LINK.*/
            }
        }
        public GECPB101_LK_LINK LK_LINK { get; set; } = new GECPB101_LK_LINK();
        public class GECPB101_LK_LINK : VarBasis
        {
            /*"  05      LK-RTCODE             PIC S9(004)      VALUE +0  COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      LK-TAMANHO            PIC S9(004)      VALUE +40 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05      LK-TITULO             PIC  X(132)      VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01        WABEND.*/
        }
        public GECPB101_WABEND WABEND { get; set; } = new GECPB101_WABEND();
        public class GECPB101_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(010)      VALUE         ' GECPB101'.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GECPB101");
            /*"  05      FILLER                PIC  X(026)      VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL          PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER                PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE              PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.GE501 GE501 { get; set; } = new Dclgens.GE501();
        public Dclgens.GE536 GE536 { get; set; } = new Dclgens.GE536();
        public Dclgens.GE537 GE537 { get; set; } = new Dclgens.GE537();
        public Dclgens.GE540 GE540 { get; set; } = new Dclgens.GE540();
        public Dclgens.GE541 GE541 { get; set; } = new Dclgens.GE541();
        public Dclgens.GE547 GE547 { get; set; } = new Dclgens.GE547();
        public Dclgens.GE551 GE551 { get; set; } = new Dclgens.GE551();
        public Dclgens.GE552 GE552 { get; set; } = new Dclgens.GE552();
        public Dclgens.GE554 GE554 { get; set; } = new Dclgens.GE554();
        public Dclgens.GE577 GE577 { get; set; } = new Dclgens.GE577();
        public Dclgens.GE576 GE576 { get; set; } = new Dclgens.GE576();
        public Dclgens.GE543 GE543 { get; set; } = new Dclgens.GE543();

        public GECPB101_C01 C01 { get; set; } = new GECPB101_C01(true);
        string GetQuery_C01()
        {
            var query = @$"SELECT T.DTA_MOVIMENTO
							, C.COD_ORIGEM
							, C.COD_EVENTO
							, A.NUM_IDLG
							, B.NUM_SINISTRO
							, B.NUM_APOLICE
							, C.COD_CHAVE_NEGOCIO
							, D.VLR_COBRAR_PAGAR
							, A.DTA_MOVIMENTO
							, D.DTA_COBRAR_PAGAR
							, CASE D.COD_FORMA WHEN 'S' THEN D.COD_FORMA||'-CRED CONTA (VIA SIACC)' WHEN 'I' THEN D.COD_FORMA||'-CRED C.(SICOV LOTERICO)' WHEN '0' THEN D.COD_FORMA||'-CRED C.OUTROS' WHEN 'B' THEN D.COD_FORMA||'-BOLETO BANC' WHEN 'C' THEN D.COD_FORMA||'-CHEQUE' WHEN 'O' THEN D.COD_FORMA||'-OP ELETRO (SIVAT)' WHEN 'G' THEN D.COD_FORMA||'-OP ELET S/SUMARIZACAO' WHEN 'T' THEN D.COD_FORMA||'-BORDERO MANUAL(S/EMIS.CHEQ)' WHEN 'J' THEN D.COD_FORMA||'-BORD MANU(PAG. JUDIC.)' WHEN 'F' THEN D.COD_FORMA||'-SANTANDER' ELSE D.COD_FORMA||'-NAO IDENTIFICADO' END
							, CASE A.COD_TIPO_OCOR WHEN 'S' THEN '1-SOLICITACAO SIAS' WHEN 'A' THEN '2-ARQ-A GERADO' WHEN 'G' THEN '3-RETORNO DE ARQ-G' WHEN 'CG' THEN '4-CONSUMO DE ARQ-G' WHEN 'H' THEN '5-RETORNO DE ARQ-H' WHEN 'CH' THEN '6-CONSUMO DE ARQ-H' ELSE A.COD_TIPO_OCOR END
							, CASE VALUE(G.STA_PROCESSAMENTO
							,' ' ) WHEN '1' THEN 'SAP_ACATOU' WHEN ' ' THEN ' ' ELSE 'SAP_REJEITOU' END
							, VALUE(H1.COD_RETORNO_ARQ_H
							,' ')
							, VALUE(H2.DES_RETORNO_ARQ_H
							,' ')
							, VALUE(H3.NOM_EXTERNO_ARQUIVO
							,' ')
							, VALUE(A1.NOM_EXTERNO_ARQUIVO
							, ' ')
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							LEFT JOIN SIUS.GE_CONTROL_ARQ_A_SAP A1 ON A1.COD_LOTE_A = A.COD_LOTE_A AND A1.COD_ORIGEM = A.COD_ORIGEM
							LEFT JOIN SIUS.GE_DET_ARQ_H_RETORNO_SAP H1 ON H1.NUM_NSA_SAP=A.NUM_NSA_SAP AND H1.SEQ_REGISTRO=A.SEQ_REGISTRO AND H1.COD_MODULO_SAP=A.COD_MODULO_SAP
							LEFT JOIN SIUS.GE_RETORNO_ARQ_H_SAP H2 ON H2.IND_TIPO_RETORNO = H1.IND_TIPO_RETORNO AND H2.COD_RETORNO_ARQ_h = H1.COD_RETORNO_ARQ_H
							LEFT JOIN SIUS.GE_CONTROL_ARQ_H_SAP H3 ON H3.NUM_NSA_SAP=A.NUM_NSA_SAP
							LEFT JOIN SIUS.GE_DETALHE_ARQ_G_SAP G ON G.COD_LOTE_G = A.COD_LOTE_G AND G.COD_ORIGEM = A.COD_ORIGEM AND G.SEQ_REGISTRO_LOTE_G=A.SEQ_REGISTRO_LOTE_G
							, SIUS.GE_SINISTRO_AP_CA_SAP B
							, SIUS.GE_SOLICITACAO_AP_CA_SAP C
							, SIUS.GE_FORMA_COBRA_PAGA_SAP D
							,
							(SELECT  X.NUM_IDLG
							,X.DTA_MOVIMENTO
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST X WHERE X.COD_ORIGEM IN ('S100'
							,'S101'
							,'S104'
							,'S109'
							,'S110') AND VALUE(X.NUM_IDLG
							,0)>0 AND X.COD_TIPO_OCOR='S') T WHERE A.COD_ORIGEM IN ('S100'
							,'S101'
							,'S104'
							,'S109'
							,'S110') AND VALUE(A.NUM_IDLG
							,0) > 0 AND A.DTA_MOVIMENTO = '{GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_ULT_MOV_ABERTO}' AND B.NUM_IDLG=A.NUM_IDLG AND C.NUM_IDLG=A.NUM_IDLG AND D.NUM_IDLG=A.NUM_IDLG AND T.NUM_IDLG=A.NUM_IDLG ORDER BY 1
							,4
							,9
							,12";

            return query;
        }


        public GECPB101_C02 C02 { get; set; } = new GECPB101_C02(false);
        string GetQuery_C02()
        {
            var query = @$"SELECT T.DTA_MOVIMENTO
							, C.COD_ORIGEM
							, C.COD_EVENTO
							, A.COD_LOTE_A
							, A.NUM_IDLG
							, B.NUM_SINISTRO
							, B.NUM_APOLICE
							, C.COD_CHAVE_NEGOCIO
							, D.VLR_COBRAR_PAGAR
							, D.DTA_COBRAR_PAGAR
							, CASE D.COD_FORMA WHEN 'S' THEN D.COD_FORMA||'-CRED CONTA (VIA SIACC)' WHEN 'I' THEN D.COD_FORMA||'-CRED C.(SICOV LOTERICO)' WHEN '0' THEN D.COD_FORMA||'-CRED C.OUTROS' WHEN 'B' THEN D.COD_FORMA||'-BOLETO BANC' WHEN 'C' THEN D.COD_FORMA||'-CHEQUE' WHEN 'O' THEN D.COD_FORMA||'-OP ELETRO (SIVAT)' WHEN 'G' THEN D.COD_FORMA||'-OP ELET S/SUMARIZACAO' WHEN 'T' THEN D.COD_FORMA||'-BORDERO MANUAL(S/EMIS.CHEQ)' WHEN 'J' THEN D.COD_FORMA||'-BORD MANU(PAG. JUDIC.)' WHEN 'F' THEN D.COD_FORMA||'-SANTANDER' ELSE D.COD_FORMA||'-NAO IDENTIFICADO' END
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_SINISTRO_AP_CA_SAP B
							, SIUS.GE_SOLICITACAO_AP_CA_SAP C
							, SIUS.GE_FORMA_COBRA_PAGA_SAP D
							,
							(SELECT  X.NUM_IDLG
							,X.DTA_MOVIMENTO
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST X WHERE X.COD_ORIGEM IN ('S100'
							,'S101'
							,'S104'
							,'S109'
							,'S110') AND VALUE(X.NUM_IDLG
							,0)>0 AND X.COD_TIPO_OCOR='S') T WHERE A.COD_ORIGEM IN ('S100'
							,'S101'
							,'S104'
							,'S109'
							,'S110') AND VALUE(A.NUM_IDLG
							,0) > 0 AND A.COD_TIPO_OCOR = 'A' AND B.NUM_IDLG = A.NUM_IDLG AND C.NUM_IDLG = A.NUM_IDLG AND D.NUM_IDLG = A.NUM_IDLG AND T.NUM_IDLG = A.NUM_IDLG AND NOT EXISTS
							(SELECT  E.NUM_IDLG
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST E
							, SIUS.GE_DET_ARQ_H_RETORNO_SAP F WHERE E.NUM_IDLG = A.NUM_IDLG AND E.COD_TIPO_OCOR = 'H' AND F.NUM_NSA_SAP = E.NUM_NSA_SAP AND F.SEQ_REGISTRO = E.SEQ_REGISTRO AND F.COD_RETORNO_ARQ_H NOT IN ('1I'
							,'BD') AND F.COD_MODULO_SAP = E.COD_MODULO_SAP) ORDER BY 1
							,4
							,5
							,10";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CPB101S1_FILE_NAME_P, string CPB101S2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CPB101S1.SetFile(CPB101S1_FILE_NAME_P);
                CPB101S2.SetFile(CPB101S2_FILE_NAME_P);
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
            C01.GetQueryEvent += GetQuery_C01;
            C02.GetQueryEvent += GetQuery_C02;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -622- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -623- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -626- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -629- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -639- DISPLAY 'GECPB101 - INICIO PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"GECPB101 - INICIO PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -640- DISPLAY ' ' . */
            _.Display($" ");

            /*" -641- DISPLAY 'GECPB101 - VERSAO V.01' . */
            _.Display($"GECPB101 - VERSAO V.01");

            /*" -643- DISPLAY ' ' . */
            _.Display($" ");

            /*" -645- OPEN OUTPUT CPB101S1. */
            CPB101S1.Open(REG_CPB101S1, AREA_DE_WORK.WSTATUS);

            /*" -646- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -647- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CPB101S1' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CPB101S1");

                /*" -648- DISPLAY 'STATUS  - ' WSTATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTATUS}");

                /*" -649- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -651- END-IF. */
            }


            /*" -653- OPEN OUTPUT CPB101S2. */
            CPB101S2.Open(REG_CPB101S2, AREA_DE_WORK.WSTATUS);

            /*" -654- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -655- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CPB101S2' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CPB101S2");

                /*" -656- DISPLAY 'STATUS  - ' WSTATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTATUS}");

                /*" -657- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -659- END-IF. */
            }


            /*" -668- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -671- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -672- DISPLAY 'R0000 - ERRO NO SELECT GE_PROCESSA_SUB_SISTEMA' */
                _.Display($"R0000 - ERRO NO SELECT GE_PROCESSA_SUB_SISTEMA");

                /*" -673- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -675- END-IF. */
            }


            /*" -676- DISPLAY 'DTA-MOV-ABERTO     = ' GE501-DTA-MOV-ABERTO. */
            _.Display($"DTA-MOV-ABERTO     = {GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_MOV_ABERTO}");

            /*" -678- DISPLAY 'DTA-ULT-MOV-ABERTO = ' GE501-DTA-ULT-MOV-ABERTO. */
            _.Display($"DTA-ULT-MOV-ABERTO = {GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_ULT_MOV_ABERTO}");

            /*" -680- PERFORM R0010-00-TRATA-CURSOR01. */

            R0010_00_TRATA_CURSOR01_SECTION();

            /*" -680- PERFORM R0020-00-TRATA-CURSOR02. */

            R0020_00_TRATA_CURSOR02_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -668- EXEC SQL SELECT DTA_MOV_ABERTO, DTA_ULT_MOV_ABERTO INTO :GE501-DTA-MOV-ABERTO, :GE501-DTA-ULT-MOV-ABERTO FROM SIUS.GE_PROCESSA_SUB_SISTEMA WHERE COD_IDE_SISTEMA = 'GE' AND COD_SUB_SISTEMA = 'CP' WITH UR END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE501_DTA_MOV_ABERTO, GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_MOV_ABERTO);
                _.Move(executed_1.GE501_DTA_ULT_MOV_ABERTO, GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_ULT_MOV_ABERTO);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -686- CLOSE CPB101S1. */
            CPB101S1.Close();

            /*" -687- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -688- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CPB101S1' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CPB101S1");

                /*" -689- DISPLAY 'STATUS  - ' WSTATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTATUS}");

                /*" -690- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -692- END-IF. */
            }


            /*" -694- CLOSE CPB101S2. */
            CPB101S2.Close();

            /*" -695- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -696- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CPB101S2' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CPB101S2");

                /*" -697- DISPLAY 'STATUS  - ' WSTATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTATUS}");

                /*" -698- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -700- END-IF. */
            }


            /*" -701- DISPLAY 'QTDE. DE REGISTROS     ' . */
            _.Display($"QTDE. DE REGISTROS     ");

            /*" -702- DISPLAY 'LIDOS CURSOR C01   -   ' AC-L-C01. */
            _.Display($"LIDOS CURSOR C01   -   {AREA_DE_WORK.AC_L_C01}");

            /*" -703- DISPLAY 'GRAVD NO CPB101S1  -   ' AC-G-CPB101S1. */
            _.Display($"GRAVD NO CPB101S1  -   {AREA_DE_WORK.AC_G_CPB101S1}");

            /*" -704- DISPLAY 'LIDOS CURSOR C02   -   ' AC-L-C02. */
            _.Display($"LIDOS CURSOR C02   -   {AREA_DE_WORK.AC_L_C02}");

            /*" -706- DISPLAY 'GRAVD NO CPB101S2  -   ' AC-G-CPB101S2. */
            _.Display($"GRAVD NO CPB101S2  -   {AREA_DE_WORK.AC_G_CPB101S2}");

            /*" -714- DISPLAY 'GECPB101 - FINAL DE PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"GECPB101 - FINAL DE PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -715- DISPLAY '   ' . */
            _.Display($"   ");

            /*" -717- DISPLAY '*--- GECPB101  -  FIM  NORMAL ---*' . */
            _.Display($"*--- GECPB101  -  FIM  NORMAL ---*");

            /*" -719- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -719- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-TRATA-CURSOR01-SECTION */
        private void R0010_00_TRATA_CURSOR01_SECTION()
        {
            /*" -731- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WABEND.WNR_EXEC_SQL);

            /*" -733- PERFORM R0010_00_TRATA_CURSOR01_DB_OPEN_1 */

            R0010_00_TRATA_CURSOR01_DB_OPEN_1();

            /*" -736- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -737- DISPLAY 'R0010 - ERRO NO OPEN DO CURSOR C01' */
                _.Display($"R0010 - ERRO NO OPEN DO CURSOR C01");

                /*" -738- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -740- END-IF. */
            }


            /*" -742- WRITE REG-CPB101S1 FROM WS-ARQ-CAB-CPB101S1. */
            _.Move(WS_ARQ_CPB101S1.WS_ARQ_CAB_CPB101S1.GetMoveValues(), REG_CPB101S1);

            CPB101S1.Write(REG_CPB101S1.GetMoveValues().ToString());

            /*" -744- PERFORM R0015-00-FETCH-C01. */

            R0015_00_FETCH_C01_SECTION();

            /*" -745- PERFORM UNTIL WFIM-C01 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C01 == "S"))
            {

                /*" -746- MOVE WS-HOST-DTA-LOTE(9:2) TO WDAT-DIA-EDT */
                _.Move(WS_HOST_DTA_LOTE.Substring(9, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

                /*" -747- MOVE WS-HOST-DTA-LOTE(6:2) TO WDAT-MES-EDT */
                _.Move(WS_HOST_DTA_LOTE.Substring(6, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

                /*" -748- MOVE WS-HOST-DTA-LOTE(1:4) TO WDAT-ANO-EDT */
                _.Move(WS_HOST_DTA_LOTE.Substring(1, 4), AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

                /*" -749- MOVE WDATA-EDIT TO DET-DTA-LOTE */
                _.Move(AREA_DE_WORK.WDATA_EDIT, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_DTA_LOTE);

                /*" -750- MOVE GE536-COD-ORIGEM TO DET-ORIGEM */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_ORIGEM, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_ORIGEM);

                /*" -751- MOVE GE536-COD-EVENTO TO DET-EVENTO */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EVENTO, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_EVENTO);

                /*" -752- MOVE 'MCP' TO WS-COD-IDLG-MCP */
                _.Move("MCP", AREA_DE_WORK.WS_COD_IDLG_R.WS_COD_IDLG_MCP);

                /*" -753- MOVE GE537-NUM-IDLG TO WS-NUM-IDLG */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG, AREA_DE_WORK.WS_COD_IDLG_R.WS_NUM_IDLG);

                /*" -754- MOVE WS-COD-IDLG TO DET-IDLG */
                _.Move(AREA_DE_WORK.WS_COD_IDLG, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_IDLG);

                /*" -755- MOVE GE543-NUM-SINISTRO TO DET-SINISTRO */
                _.Move(GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_SINISTRO, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_SINISTRO);

                /*" -756- MOVE GE543-NUM-APOLICE TO DET-APOLICE */
                _.Move(GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_APOLICE, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_APOLICE);

                /*" -757- MOVE GE536-COD-CHAVE-NEGOCIO TO DET-CHAVE-NEGOCIO */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_CHAVE_NEGOCIO, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_CHAVE_NEGOCIO);

                /*" -758- MOVE GE547-VLR-COBRAR-PAGAR TO DET-VLR-PAGAR */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_VLR_COBRAR_PAGAR, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_VLR_PAGAR);

                /*" -759- MOVE GE537-DTA-MOVIMENTO(9:2) TO WDAT-DIA-EDT */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO.Substring(9, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

                /*" -760- MOVE GE537-DTA-MOVIMENTO(6:2) TO WDAT-MES-EDT */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO.Substring(6, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

                /*" -761- MOVE GE537-DTA-MOVIMENTO(1:4) TO WDAT-ANO-EDT */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO.Substring(1, 4), AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

                /*" -762- MOVE WDATA-EDIT TO DET-DTA-MOVIMENTO */
                _.Move(AREA_DE_WORK.WDATA_EDIT, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_DTA_MOVIMENTO);

                /*" -763- MOVE GE547-DTA-COBRAR-PAGAR(9:2) TO WDAT-DIA-EDT */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR.Substring(9, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

                /*" -764- MOVE GE547-DTA-COBRAR-PAGAR(6:2) TO WDAT-MES-EDT */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR.Substring(6, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

                /*" -765- MOVE GE547-DTA-COBRAR-PAGAR(1:4) TO WDAT-ANO-EDT */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR.Substring(1, 4), AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

                /*" -766- MOVE WDATA-EDIT TO DET-DTA-PAGAR */
                _.Move(AREA_DE_WORK.WDATA_EDIT, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_DTA_PAGAR);

                /*" -767- MOVE WS-HOST-DES-FORMA TO DET-FORMA */
                _.Move(WS_HOST_DES_FORMA, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_FORMA);

                /*" -768- MOVE WS-HOST-DES-TIPO-MOV TO DET-TIPO-MOVIMENTO */
                _.Move(WS_HOST_DES_TIPO_MOV, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_TIPO_MOVIMENTO);

                /*" -769- MOVE WS-HOST-DES-STA-PROCES TO DET-RETORNO-SAP */
                _.Move(WS_HOST_DES_STA_PROCES, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_RETORNO_SAP);

                /*" -771- MOVE GE577-COD-RETORNO-ARQ-H TO DET-COD-ARQ-H */
                _.Move(GE577.DCLGE_DET_ARQ_H_RETORNO_SAP.GE577_COD_RETORNO_ARQ_H, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_COD_ARQ_H);

                /*" -772- MOVE GE576-DES-RETORNO-ARQ-H TO DES-RETORNO */
                _.Move(GE576.DCLGE_RETORNO_ARQ_H_SAP.GE576_DES_RETORNO_ARQ_H, DES_RETORNO);

                /*" -774- MOVE ARQ-H-TEXT(1:ARQ-H-LEN) TO DET-DES-ARQ-H */
                _.Move(DES_RETORNO.ARQ_H_TEXT.Substring(1, DES_RETORNO.ARQ_H_LEN), WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_DES_ARQ_H);

                /*" -775- MOVE GE541-NOM-EXTERNO-ARQUIVO TO DET-NOM-ARQ-H */
                _.Move(GE541.DCLGE_CONTROL_ARQ_H_SAP.GE541_NOM_EXTERNO_ARQUIVO, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_NOM_ARQ_H);

                /*" -777- MOVE GE554-NOM-EXTERNO-ARQUIVO TO DET-NOM-ARQ-A */
                _.Move(GE554.DCLGE_CONTROL_ARQ_A_SAP.GE554_NOM_EXTERNO_ARQUIVO, WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.DET_NOM_ARQ_A);

                /*" -778- WRITE REG-CPB101S1 FROM WS-ARQ-DET-CPB101S1 */
                _.Move(WS_ARQ_CPB101S1.WS_ARQ_DET_CPB101S1.GetMoveValues(), REG_CPB101S1);

                CPB101S1.Write(REG_CPB101S1.GetMoveValues().ToString());

                /*" -779- ADD 1 TO AC-G-CPB101S1 */
                AREA_DE_WORK.AC_G_CPB101S1.Value = AREA_DE_WORK.AC_G_CPB101S1 + 1;

                /*" -780- PERFORM R0015-00-FETCH-C01 */

                R0015_00_FETCH_C01_SECTION();

                /*" -780- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0010-00-TRATA-CURSOR01-DB-OPEN-1 */
        public void R0010_00_TRATA_CURSOR01_DB_OPEN_1()
        {
            /*" -733- EXEC SQL OPEN C01 END-EXEC. */

            C01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-FETCH-C01-SECTION */
        private void R0015_00_FETCH_C01_SECTION()
        {
            /*" -792- MOVE '0015' TO WNR-EXEC-SQL. */
            _.Move("0015", WABEND.WNR_EXEC_SQL);

            /*" -810- PERFORM R0015_00_FETCH_C01_DB_FETCH_1 */

            R0015_00_FETCH_C01_DB_FETCH_1();

            /*" -813- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -814- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -815- MOVE 'S' TO WFIM-C01 */
                    _.Move("S", AREA_DE_WORK.WFIM_C01);

                    /*" -815- PERFORM R0015_00_FETCH_C01_DB_CLOSE_1 */

                    R0015_00_FETCH_C01_DB_CLOSE_1();

                    /*" -817- GO TO R0015-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/ //GOTO
                    return;

                    /*" -818- ELSE */
                }
                else
                {


                    /*" -819- DISPLAY 'R0015 - ERRO NO FETCH DO CURSOR01' */
                    _.Display($"R0015 - ERRO NO FETCH DO CURSOR01");

                    /*" -820- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -821- END-IF */
                }


                /*" -822- ELSE */
            }
            else
            {


                /*" -823- ADD 1 TO AC-L-C01 */
                AREA_DE_WORK.AC_L_C01.Value = AREA_DE_WORK.AC_L_C01 + 1;

                /*" -823- END-IF. */
            }


        }

        [StopWatch]
        /*" R0015-00-FETCH-C01-DB-FETCH-1 */
        public void R0015_00_FETCH_C01_DB_FETCH_1()
        {
            /*" -810- EXEC SQL FETCH C01 INTO :WS-HOST-DTA-LOTE ,:GE536-COD-ORIGEM ,:GE536-COD-EVENTO ,:GE537-NUM-IDLG ,:GE543-NUM-SINISTRO ,:GE543-NUM-APOLICE ,:GE536-COD-CHAVE-NEGOCIO ,:GE547-VLR-COBRAR-PAGAR ,:GE537-DTA-MOVIMENTO ,:GE547-DTA-COBRAR-PAGAR ,:WS-HOST-DES-FORMA ,:WS-HOST-DES-TIPO-MOV ,:WS-HOST-DES-STA-PROCES ,:GE577-COD-RETORNO-ARQ-H ,:GE576-DES-RETORNO-ARQ-H ,:GE541-NOM-EXTERNO-ARQUIVO ,:GE554-NOM-EXTERNO-ARQUIVO END-EXEC. */

            if (C01.Fetch())
            {
                _.Move(C01.WS_HOST_DTA_LOTE, WS_HOST_DTA_LOTE);
                _.Move(C01.GE536_COD_ORIGEM, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_ORIGEM);
                _.Move(C01.GE536_COD_EVENTO, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EVENTO);
                _.Move(C01.GE537_NUM_IDLG, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG);
                _.Move(C01.GE543_NUM_SINISTRO, GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_SINISTRO);
                _.Move(C01.GE543_NUM_APOLICE, GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_APOLICE);
                _.Move(C01.GE536_COD_CHAVE_NEGOCIO, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_CHAVE_NEGOCIO);
                _.Move(C01.GE547_VLR_COBRAR_PAGAR, GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_VLR_COBRAR_PAGAR);
                _.Move(C01.GE537_DTA_MOVIMENTO, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO);
                _.Move(C01.GE547_DTA_COBRAR_PAGAR, GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR);
                _.Move(C01.WS_HOST_DES_FORMA, WS_HOST_DES_FORMA);
                _.Move(C01.WS_HOST_DES_TIPO_MOV, WS_HOST_DES_TIPO_MOV);
                _.Move(C01.WS_HOST_DES_STA_PROCES, WS_HOST_DES_STA_PROCES);
                _.Move(C01.GE577_COD_RETORNO_ARQ_H, GE577.DCLGE_DET_ARQ_H_RETORNO_SAP.GE577_COD_RETORNO_ARQ_H);
                _.Move(C01.GE576_DES_RETORNO_ARQ_H, GE576.DCLGE_RETORNO_ARQ_H_SAP.GE576_DES_RETORNO_ARQ_H);
                _.Move(C01.GE541_NOM_EXTERNO_ARQUIVO, GE541.DCLGE_CONTROL_ARQ_H_SAP.GE541_NOM_EXTERNO_ARQUIVO);
                _.Move(C01.GE554_NOM_EXTERNO_ARQUIVO, GE554.DCLGE_CONTROL_ARQ_A_SAP.GE554_NOM_EXTERNO_ARQUIVO);
            }

        }

        [StopWatch]
        /*" R0015-00-FETCH-C01-DB-CLOSE-1 */
        public void R0015_00_FETCH_C01_DB_CLOSE_1()
        {
            /*" -815- EXEC SQL CLOSE C01 END-EXEC */

            C01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-TRATA-CURSOR02-SECTION */
        private void R0020_00_TRATA_CURSOR02_SECTION()
        {
            /*" -835- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", WABEND.WNR_EXEC_SQL);

            /*" -837- PERFORM R0020_00_TRATA_CURSOR02_DB_OPEN_1 */

            R0020_00_TRATA_CURSOR02_DB_OPEN_1();

            /*" -840- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -841- DISPLAY 'R0020 - ERRO NO OPEN DO CURSOR C02' */
                _.Display($"R0020 - ERRO NO OPEN DO CURSOR C02");

                /*" -842- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -844- END-IF. */
            }


            /*" -846- WRITE REG-CPB101S2 FROM WS-ARQ-CAB-CPB101S2. */
            _.Move(WS_ARQ_CPB101S2.WS_ARQ_CAB_CPB101S2.GetMoveValues(), REG_CPB101S2);

            CPB101S2.Write(REG_CPB101S2.GetMoveValues().ToString());

            /*" -848- PERFORM R0025-00-FETCH-C02. */

            R0025_00_FETCH_C02_SECTION();

            /*" -849- PERFORM UNTIL WFIM-C02 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C02 == "S"))
            {

                /*" -850- MOVE WS-HOST-DTA-LOTE(9:2) TO WDAT-DIA-EDT */
                _.Move(WS_HOST_DTA_LOTE.Substring(9, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

                /*" -851- MOVE WS-HOST-DTA-LOTE(6:2) TO WDAT-MES-EDT */
                _.Move(WS_HOST_DTA_LOTE.Substring(6, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

                /*" -852- MOVE WS-HOST-DTA-LOTE(1:4) TO WDAT-ANO-EDT */
                _.Move(WS_HOST_DTA_LOTE.Substring(1, 4), AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

                /*" -853- MOVE WDATA-EDIT TO DETS2-DTA-LOTE */
                _.Move(AREA_DE_WORK.WDATA_EDIT, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_DTA_LOTE);

                /*" -854- MOVE GE536-COD-ORIGEM TO DETS2-ORIGEM */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_ORIGEM, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_ORIGEM);

                /*" -855- MOVE GE536-COD-EVENTO TO DETS2-EVENTO */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EVENTO, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_EVENTO);

                /*" -856- MOVE GE537-COD-LOTE-A TO DETS2-COD-LOTE-A */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_A, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_COD_LOTE_A);

                /*" -857- MOVE 'MCP' TO WS-COD-IDLG-MCP */
                _.Move("MCP", AREA_DE_WORK.WS_COD_IDLG_R.WS_COD_IDLG_MCP);

                /*" -858- MOVE GE537-NUM-IDLG TO WS-NUM-IDLG */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG, AREA_DE_WORK.WS_COD_IDLG_R.WS_NUM_IDLG);

                /*" -859- MOVE WS-COD-IDLG TO DETS2-IDLG */
                _.Move(AREA_DE_WORK.WS_COD_IDLG, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_IDLG);

                /*" -860- MOVE GE543-NUM-SINISTRO TO DETS2-SINISTRO */
                _.Move(GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_SINISTRO, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_SINISTRO);

                /*" -861- MOVE GE543-NUM-APOLICE TO DETS2-APOLICE */
                _.Move(GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_APOLICE, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_APOLICE);

                /*" -862- MOVE GE536-COD-CHAVE-NEGOCIO TO DETS2-CHAVE-NEGOCIO */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_CHAVE_NEGOCIO, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_CHAVE_NEGOCIO);

                /*" -863- MOVE GE547-VLR-COBRAR-PAGAR TO DETS2-VLR-PAGAR */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_VLR_COBRAR_PAGAR, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_VLR_PAGAR);

                /*" -864- MOVE GE547-DTA-COBRAR-PAGAR(9:2) TO WDAT-DIA-EDT */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR.Substring(9, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

                /*" -865- MOVE GE547-DTA-COBRAR-PAGAR(6:2) TO WDAT-MES-EDT */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR.Substring(6, 2), AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

                /*" -866- MOVE GE547-DTA-COBRAR-PAGAR(1:4) TO WDAT-ANO-EDT */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR.Substring(1, 4), AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

                /*" -867- MOVE WDATA-EDIT TO DETS2-DTA-PAGAR */
                _.Move(AREA_DE_WORK.WDATA_EDIT, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_DTA_PAGAR);

                /*" -869- MOVE WS-HOST-DES-FORMA TO DETS2-FORMA */
                _.Move(WS_HOST_DES_FORMA, WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.DETS2_FORMA);

                /*" -870- WRITE REG-CPB101S2 FROM WS-ARQ-DET-CPB101S2 */
                _.Move(WS_ARQ_CPB101S2.WS_ARQ_DET_CPB101S2.GetMoveValues(), REG_CPB101S2);

                CPB101S2.Write(REG_CPB101S2.GetMoveValues().ToString());

                /*" -871- ADD 1 TO AC-G-CPB101S2 */
                AREA_DE_WORK.AC_G_CPB101S2.Value = AREA_DE_WORK.AC_G_CPB101S2 + 1;

                /*" -872- PERFORM R0025-00-FETCH-C02 */

                R0025_00_FETCH_C02_SECTION();

                /*" -872- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" R0020-00-TRATA-CURSOR02-DB-OPEN-1 */
        public void R0020_00_TRATA_CURSOR02_DB_OPEN_1()
        {
            /*" -837- EXEC SQL OPEN C02 END-EXEC. */

            C02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0025-00-FETCH-C02-SECTION */
        private void R0025_00_FETCH_C02_SECTION()
        {
            /*" -884- MOVE '0025' TO WNR-EXEC-SQL. */
            _.Move("0025", WABEND.WNR_EXEC_SQL);

            /*" -896- PERFORM R0025_00_FETCH_C02_DB_FETCH_1 */

            R0025_00_FETCH_C02_DB_FETCH_1();

            /*" -899- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -900- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -901- MOVE 'S' TO WFIM-C02 */
                    _.Move("S", AREA_DE_WORK.WFIM_C02);

                    /*" -901- PERFORM R0025_00_FETCH_C02_DB_CLOSE_1 */

                    R0025_00_FETCH_C02_DB_CLOSE_1();

                    /*" -903- GO TO R0025-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0025_99_SAIDA*/ //GOTO
                    return;

                    /*" -904- ELSE */
                }
                else
                {


                    /*" -905- DISPLAY 'R0025 - ERRO NO FETCH DO CURSOR02' */
                    _.Display($"R0025 - ERRO NO FETCH DO CURSOR02");

                    /*" -906- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -907- END-IF */
                }


                /*" -908- ELSE */
            }
            else
            {


                /*" -909- ADD 1 TO AC-L-C02 */
                AREA_DE_WORK.AC_L_C02.Value = AREA_DE_WORK.AC_L_C02 + 1;

                /*" -909- END-IF. */
            }


        }

        [StopWatch]
        /*" R0025-00-FETCH-C02-DB-FETCH-1 */
        public void R0025_00_FETCH_C02_DB_FETCH_1()
        {
            /*" -896- EXEC SQL FETCH C02 INTO :WS-HOST-DTA-LOTE ,:GE536-COD-ORIGEM ,:GE536-COD-EVENTO ,:GE537-COD-LOTE-A ,:GE537-NUM-IDLG ,:GE543-NUM-SINISTRO ,:GE543-NUM-APOLICE ,:GE536-COD-CHAVE-NEGOCIO ,:GE547-VLR-COBRAR-PAGAR ,:GE547-DTA-COBRAR-PAGAR ,:WS-HOST-DES-FORMA END-EXEC. */

            if (C02.Fetch())
            {
                _.Move(C02.WS_HOST_DTA_LOTE, WS_HOST_DTA_LOTE);
                _.Move(C02.GE536_COD_ORIGEM, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_ORIGEM);
                _.Move(C02.GE536_COD_EVENTO, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EVENTO);
                _.Move(C02.GE537_COD_LOTE_A, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_A);
                _.Move(C02.GE537_NUM_IDLG, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG);
                _.Move(C02.GE543_NUM_SINISTRO, GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_SINISTRO);
                _.Move(C02.GE543_NUM_APOLICE, GE543.DCLGE_SINISTRO_AP_CA_SAP.GE543_NUM_APOLICE);
                _.Move(C02.GE536_COD_CHAVE_NEGOCIO, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_CHAVE_NEGOCIO);
                _.Move(C02.GE547_VLR_COBRAR_PAGAR, GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_VLR_COBRAR_PAGAR);
                _.Move(C02.GE547_DTA_COBRAR_PAGAR, GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR);
                _.Move(C02.WS_HOST_DES_FORMA, WS_HOST_DES_FORMA);
            }

        }

        [StopWatch]
        /*" R0025-00-FETCH-C02-DB-CLOSE-1 */
        public void R0025_00_FETCH_C02_DB_CLOSE_1()
        {
            /*" -901- EXEC SQL CLOSE C02 END-EXEC */

            C02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0025_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -923- CLOSE CPB101S1 CPB101S2. */
            CPB101S1.Close();
            CPB101S2.Close();

            /*" -925- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -927- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -929- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -929- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}