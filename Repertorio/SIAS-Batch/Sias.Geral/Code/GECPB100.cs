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
using Sias.Geral.DB2.GECPB100;

namespace Code
{
    public class GECPB100
    {
        public bool IsCall { get; set; }

        public GECPB100()
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
        /*"      *   PROGRAMA .............. GECPB100                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA .............. JOSE RENATO                          *      */
        /*"      *   PROGRAMADOR ........... JOSE RENATO                          *      */
        /*"      *   DATA CODIFICACAO ...... ABRIL/2020                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO ................ GERAR RELATORIO PARA ACOMPANHAMENTO  *      */
        /*"      *                           DIARIO DO MCP.                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                      H I S T O R I C O                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *    DATA    ANALISTA  VERSAO  OBJETIVO                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 16/04/2020 J.RENATO   V.00   IMPLANTACAO                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 11/05/2020 J.RENATO   V.01   AJUSTA DESCRICAO CURSORES - 245051*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 25/05/2020 J.RENATO   V.02   RETIRA CURSOR 03.         - 245854*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 26/08/2020 J.RENATO   V.03   INCLUI COD-EMPRESA.       - 256169*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 05/07/2021 J.RENATO   V.04   ALTERA QUERY CURSOR C06.  - 296705*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 08/08/2022 J.RENATO   V.05   INCLUI COLUNA COD-ORIGEM DA TABELA*      */
        /*"      *                              GE_CONTROL_ARQ_G_SAP.     - 414514*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 10/05/2023 GILSON P.  V.06   INCLUI COLUNA COD-MODULO-SAP NAS  *      */
        /*"      *                              TABELAS COMO NULO TODA VEZ QUE A  *      */
        /*"      *                              COLUNA NUM_NSA_SAP FOR NULO       *      */
        /*"      *       GE_SOLICITA_AP_CA_SAP_HIST(GE537),                       *      */
        /*"      *       GE_DETALHE_ARQ_H_SAP(GE540),                             *      */
        /*"      *       GE_CONTROL_ARQ_H_SAP(GE541),                             *      */
        /*"      *       GE_DET_ARQ_H_RETORNO_SAP(GE577)                 - 480539 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 31/08/2023 CARLOS AAA V.07   AJUSTE EM RELA��O AO ITEM ANTERIOR*      */
        /*"      * CAMD                                                                  */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        /*"      * 04/12/2023 CARLOS AAA V.08  GERAR UM ARQUIVO POR TIPOLOGIA     *      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _CPB100S1 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CPB100S1
        {
            get
            {
                _.Move(REG_CPB100S1, _CPB100S1); VarBasis.RedefinePassValue(REG_CPB100S1, _CPB100S1, REG_CPB100S1); return _CPB100S1;
            }
        }
        public FileBasis _CP100T01 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T01
        {
            get
            {
                _.Move(REG_CP100T01, _CP100T01); VarBasis.RedefinePassValue(REG_CP100T01, _CP100T01, REG_CP100T01); return _CP100T01;
            }
        }
        public FileBasis _CP100T02 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T02
        {
            get
            {
                _.Move(REG_CP100T02, _CP100T02); VarBasis.RedefinePassValue(REG_CP100T02, _CP100T02, REG_CP100T02); return _CP100T02;
            }
        }
        public FileBasis _CP100T03 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T03
        {
            get
            {
                _.Move(REG_CP100T03, _CP100T03); VarBasis.RedefinePassValue(REG_CP100T03, _CP100T03, REG_CP100T03); return _CP100T03;
            }
        }
        public FileBasis _CP100T04 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T04
        {
            get
            {
                _.Move(REG_CP100T04, _CP100T04); VarBasis.RedefinePassValue(REG_CP100T04, _CP100T04, REG_CP100T04); return _CP100T04;
            }
        }
        public FileBasis _CP100T05 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T05
        {
            get
            {
                _.Move(REG_CP100T05, _CP100T05); VarBasis.RedefinePassValue(REG_CP100T05, _CP100T05, REG_CP100T05); return _CP100T05;
            }
        }
        public FileBasis _CP100T67 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T67
        {
            get
            {
                _.Move(REG_CP100T67, _CP100T67); VarBasis.RedefinePassValue(REG_CP100T67, _CP100T67, REG_CP100T67); return _CP100T67;
            }
        }
        public FileBasis _CP100T08 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T08
        {
            get
            {
                _.Move(REG_CP100T08, _CP100T08); VarBasis.RedefinePassValue(REG_CP100T08, _CP100T08, REG_CP100T08); return _CP100T08;
            }
        }
        public FileBasis _CP100T09 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T09
        {
            get
            {
                _.Move(REG_CP100T09, _CP100T09); VarBasis.RedefinePassValue(REG_CP100T09, _CP100T09, REG_CP100T09); return _CP100T09;
            }
        }
        public FileBasis _CP100T10 { get; set; } = new FileBasis(new PIC("X", "299", "X(299)"));

        public FileBasis CP100T10
        {
            get
            {
                _.Move(REG_CP100T10, _CP100T10); VarBasis.RedefinePassValue(REG_CP100T10, _CP100T10, REG_CP100T10); return _CP100T10;
            }
        }
        /*"01        REG-CPB100S1        PIC  X(299).*/
        public StringBasis REG_CPB100S1 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T01        PIC  X(299).*/
        public StringBasis REG_CP100T01 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T02        PIC  X(299).*/
        public StringBasis REG_CP100T02 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T03        PIC  X(299).*/
        public StringBasis REG_CP100T03 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T04        PIC  X(299).*/
        public StringBasis REG_CP100T04 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T05        PIC  X(299).*/
        public StringBasis REG_CP100T05 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T67        PIC  X(299).*/
        public StringBasis REG_CP100T67 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T08        PIC  X(299).*/
        public StringBasis REG_CP100T08 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T09        PIC  X(299).*/
        public StringBasis REG_CP100T09 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");
        /*"01        REG-CP100T10        PIC  X(299).*/
        public StringBasis REG_CP100T10 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77        WHOST-DIA-REFER       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_DIA_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        WHOST-DIA-INICIAL     PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_DIA_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        WHOST-DIA-FINAL       PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_DIA_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01        AREA-DE-WORK.*/
        public GECPB100_AREA_DE_WORK AREA_DE_WORK { get; set; } = new GECPB100_AREA_DE_WORK();
        public class GECPB100_AREA_DE_WORK : VarBasis
        {
            /*"  05      WSTATUS               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT01               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT01 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT02               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT03               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT03 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT04               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT04 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT05               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT05 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT67               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT67 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT08               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT08 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT09               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT09 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSTAT10               PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WSTAT10 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WSL-SQLCODE           PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      WFIM-C01              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C02              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C03              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C04              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C05              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C06              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C08              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C09              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C10              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C11              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-C12              PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_C12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-C01              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C02              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C03              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C03 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C04              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C04 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C05              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C05 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C06              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C06 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C08              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C08 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C09              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C09 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C10              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C10 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C11              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C11 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-L-C12              PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_C12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      AC-G-CPB100S1         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_G_CPB100S1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      C01-COD-TIPO-OCOR     PIC  X(018)      VALUE SPACES.*/
            public StringBasis C01_COD_TIPO_OCOR { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            /*"  05      C01-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C01_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C02-STA-CONSUMO       PIC  X(009)      VALUE SPACES.*/
            public StringBasis C02_STA_CONSUMO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
            /*"  05      C02-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C02_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C04-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C04_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C06-STA-CONSUMO       PIC  X(027)      VALUE SPACES.*/
            public StringBasis C06_STA_CONSUMO { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
            /*"  05      C06-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C06_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C08-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C08_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C09-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C09_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C10-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C10_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      C12-QTD               PIC S9(009) COMP VALUE ZEROS.*/
            public IntBasis C12_QTD { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      GDA-QTD               PIC  9(009)      VALUE ZEROS.*/
            public IntBasis GDA_QTD { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      GDA-NUM-IDLG          PIC  9(018)      VALUE ZEROS.*/
            public IntBasis GDA_NUM_IDLG { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
            /*"  05      GDA-NUM-NSA-SAP       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis GDA_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      GDA-SEQ-REGISTRO      PIC  9(009)      VALUE ZEROS.*/
            public IntBasis GDA_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05      VIND-COD-ORIGEM       PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_COD_ORIGEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      VIND-NUM-IDLG         PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      VIND-COD-LOTE-G       PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_COD_LOTE_G { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      VIND-COD-LOTE-A       PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_COD_LOTE_A { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      VIND-NUM-NSA-SAP      PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      VIND-SEQ-REGISTRO     PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      VIND-DES-MSG-ERRO     PIC S9(004) COMP VALUE ZEROS.*/
            public IntBasis VIND_DES_MSG_ERRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      WS-DTA-MOV-ABERTO     PIC X(10).*/
            public StringBasis WS_DTA_MOV_ABERTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"  05      FILLER                REDEFINES   WS-DTA-MOV-ABERTO.*/
            private _REDEF_GECPB100_FILLER_0 _filler_0 { get; set; }
            public _REDEF_GECPB100_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_GECPB100_FILLER_0(); _.Move(WS_DTA_MOV_ABERTO, _filler_0); VarBasis.RedefinePassValue(WS_DTA_MOV_ABERTO, _filler_0, WS_DTA_MOV_ABERTO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_DTA_MOV_ABERTO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS_DTA_MOV_ABERTO); }
            }  //Redefines
            public class _REDEF_GECPB100_FILLER_0 : VarBasis
            {
                /*"    10    WS-ANO-MOV            PIC 9(04).*/
                public IntBasis WS_ANO_MOV { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    10    FILLER                PIC X.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                /*"    10    WS-MES-MOV            PIC 9(02).*/
                public IntBasis WS_MES_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    10    FILLER                PIC X.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X."), @"");
                /*"    10    WS-DIA-MOV            PIC 9(02).*/
                public IntBasis WS_DIA_MOV { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"  05      WDATA-EDIT.*/

                public _REDEF_GECPB100_FILLER_0()
                {
                    WS_ANO_MOV.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WS_MES_MOV.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WS_DIA_MOV.ValueChanged += OnValueChanged;
                }

            }
            public GECPB100_WDATA_EDIT WDATA_EDIT { get; set; } = new GECPB100_WDATA_EDIT();
            public class GECPB100_WDATA_EDIT : VarBasis
            {
                /*"    10    WDAT-DIA-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-MES-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-ANO-EDT          PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDAT_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WDATA-AUX             PIC  X(010)      VALUE SPACES.*/
            }
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-AUX-R           REDEFINES        WDATA-AUX.*/
            private _REDEF_GECPB100_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_GECPB100_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_GECPB100_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_GECPB100_WDATA_AUX_R : VarBasis
            {
                /*"    10    WDAT-ANO-AUX          PIC  9(004).*/
                public IntBasis WDAT_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-MES-AUX          PIC  9(002).*/
                public IntBasis WDAT_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-DIA-AUX          PIC  9(002).*/
                public IntBasis WDAT_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-CURR.*/

                public _REDEF_GECPB100_WDATA_AUX_R()
                {
                    WDAT_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                    WDAT_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public GECPB100_WDATA_CURR WDATA_CURR { get; set; } = new GECPB100_WDATA_CURR();
            public class GECPB100_WDATA_CURR : VarBasis
            {
                /*"    10    WDATA-AA-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_AA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WDATA-MM-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WDATA-DD-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDATA_DD_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WHORA-CURR.*/
            }
            public GECPB100_WHORA_CURR WHORA_CURR { get; set; } = new GECPB100_WHORA_CURR();
            public class GECPB100_WHORA_CURR : VarBasis
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
            public GECPB100_WHORA_EDIT WHORA_EDIT { get; set; } = new GECPB100_WHORA_EDIT();
            public class GECPB100_WHORA_EDIT : VarBasis
            {
                /*"    10    WHORA-HH-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_HH_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-MM-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_MM_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '.'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @".");
                /*"    10    WHORA-SS-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHORA_SS_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WS-TIMESTAMP          PIC  X(026)      VALUE SPACES.*/
            }
            public StringBasis WS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
            /*"01  DES-RETORNO.*/
        }
        public GECPB100_DES_RETORNO DES_RETORNO { get; set; } = new GECPB100_DES_RETORNO();
        public class GECPB100_DES_RETORNO : VarBasis
        {
            /*"    49 ARQ-H-LEN        PIC S9(4) USAGE COMP.*/
            public IntBasis ARQ_H_LEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
            /*"    49 ARQ-H-TEXT       PIC X(220).*/
            public StringBasis ARQ_H_TEXT { get; set; } = new StringBasis(new PIC("X", "220", "X(220)."), @"");
            /*"01        WS-ARQUIVO.*/
        }
        public GECPB100_WS_ARQUIVO WS_ARQUIVO { get; set; } = new GECPB100_WS_ARQUIVO();
        public class GECPB100_WS_ARQUIVO : VarBasis
        {
            /*"  05      LCSPA.*/
            public GECPB100_LCSPA LCSPA { get; set; } = new GECPB100_LCSPA();
            public class GECPB100_LCSPA : VarBasis
            {
                /*"    10    FILLER                PIC  X(299)      VALUE SPACES.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)"), @"");
                /*"  05      LCHIF.*/
            }
            public GECPB100_LCHIF LCHIF { get; set; } = new GECPB100_LCHIF();
            public class GECPB100_LCHIF : VarBasis
            {
                /*"    10    FILLER                PIC  X(299)      VALUE ALL '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "299", "X(299)"), @"ALL");
                /*"  05      LCTIT.*/
            }
            public GECPB100_LCTIT LCTIT { get; set; } = new GECPB100_LCTIT();
            public class GECPB100_LCTIT : VarBasis
            {
                /*"    10    FILLER                PIC  X(006)      VALUE SPACES.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10    FILLER                PIC  X(051)      VALUE          'RELATORIO DE MONITORAMENTO DO MCP REFERENTE AO DIA '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"RELATORIO DE MONITORAMENTO DO MCP REFERENTE AO DIA ");
                /*"    10    LCTIT-DATA            PIC  X(010)      VALUE SPACES.*/
                public StringBasis LCTIT_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(013)      VALUE          ' - GERADO EM '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" - GERADO EM ");
                /*"    10    LCTIT-TIMESTAMP       PIC  X(026)      VALUE SPACES.*/
                public StringBasis LCTIT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    10    FILLER                PIC  X(193)      VALUE SPACES.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "193", "X(193)"), @"");
                /*"  05      LC1-C01.*/
            }
            public GECPB100_LC1_C01 LC1_C01 { get; set; } = new GECPB100_LC1_C01();
            public class GECPB100_LC1_C01 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(051)      VALUE          'LEVANTAMENTO DO MOVIMENTO OCORRIDO NOS ULTIMOS DIAS'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"LEVANTAMENTO DO MOVIMENTO OCORRIDO NOS ULTIMOS DIAS");
                /*"    10    FILLER                PIC  X(233)      VALUE SPACES.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "233", "X(233)"), @"");
                /*"  05      LC2-C01.*/
            }
            public GECPB100_LC2_C01 LC2_C01 { get; set; } = new GECPB100_LC2_C01();
            public class GECPB100_LC2_C01 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA");
                /*"    10    FILLER                PIC  X(011)      VALUE          'COD-ORIGEM '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-ORIGEM ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-ORIGEM'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-ORIGEM");
                /*"    10    FILLER                PIC  X(014)      VALUE          'DTA-MOVIMENTO '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"DTA-MOVIMENTO ");
                /*"    10    FILLER                PIC  X(019)      VALUE          'TIPO-MOVIMENTO     '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"TIPO-MOVIMENTO     ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"    10    FILLER                PIC  X(154)      VALUE SPACES.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "154", "X(154)"), @"");
                /*"  05      LC3-C01.*/
            }
            public GECPB100_LC3_C01 LC3_C01 { get; set; } = new GECPB100_LC3_C01();
            public class GECPB100_LC3_C01 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(011)      VALUE          '---------- '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"---------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(014)      VALUE          '------------- '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"------------- ");
                /*"    10    FILLER                PIC  X(019)      VALUE          '------------------ '.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"------------------ ");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"    10    FILLER                PIC  X(154)      VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "154", "X(154)"), @"");
                /*"  05      LC1-C02.*/
            }
            public GECPB100_LC1_C02 LC1_C02 { get; set; } = new GECPB100_LC1_C02();
            public class GECPB100_LC1_C02 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(084)      VALUE          'RETORNOS INDEVIDOS DE ARQ-H / MAIS DE UM RETORNO P/ O          'MESMO IDLG NOS ULTIMOS 30 DIAS'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "84", "X(084)"), @"RETORNOS INDEVIDOS DE ARQ-H / MAIS DE UM RETORNO P/ O          ");
                /*"    10    FILLER                PIC  X(200)      VALUE SPACES.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "200", "X(200)"), @"");
                /*"  05      LC2-C02.*/
            }
            public GECPB100_LC2_C02 LC2_C02 { get; set; } = new GECPB100_LC2_C02();
            public class GECPB100_LC2_C02 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA           '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA           ");
                /*"    10    FILLER                PIC  X(019)      VALUE          'IDLG-MCP           '.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"IDLG-MCP           ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'IDLG-SAP                                 '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"IDLG-SAP                                 ");
                /*"    10    FILLER                PIC  X(012)      VALUE          'NUM-NSA-SAP '.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"NUM-NSA-SAP ");
                /*"    10    FILLER                PIC  X(013)      VALUE          'SEQ-REGISTRO '.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SEQ-REGISTRO ");
                /*"    10    FILLER                PIC  X(012)      VALUE          'DTA-ARQUIVO '.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"DTA-ARQUIVO ");
                /*"    10    FILLER                PIC  X(012)      VALUE          'STA-CONSUMO '.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"STA-CONSUMO ");
                /*"    10    FILLER                PIC  X(018)      VALUE          'COD-RETORNO-ARQ-H '.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"COD-RETORNO-ARQ-H ");
                /*"    10    FILLER                PIC  X(112)      VALUE          'DES-RETORNO-ARQ-H '.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"DES-RETORNO-ARQ-H ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"  05      LC3-C02.*/
            }
            public GECPB100_LC3_C02 LC3_C02 { get; set; } = new GECPB100_LC3_C02();
            public class GECPB100_LC3_C02 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(019)      VALUE          '------------------ '.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"------------------ ");
                /*"    10    FILLER                PIC  X(041)      VALUE          '---------------------------------------- '.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"---------------------------------------- ");
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(013)      VALUE          '------------ '.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"------------ ");
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(018)      VALUE          '----------------- '.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"----------------- ");
                /*"    10    FILLER                PIC  X(112)      VALUE ALL '-'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "112", "X(112)"), @"ALL");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"  05      LC1-C04.*/
            }
            public GECPB100_LC1_C04 LC1_C04 { get; set; } = new GECPB100_LC1_C04();
            public class GECPB100_LC1_C04 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(046)      VALUE          'SOLICITACAO DE PAGAMENTO OU COBRANCA SEM ARQ-A'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "46", "X(046)"), @"SOLICITACAO DE PAGAMENTO OU COBRANCA SEM ARQ-A");
                /*"    10    FILLER                PIC  X(238)      VALUE SPACES.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "238", "X(238)"), @"");
                /*"  05      LC2-C04.*/
            }
            public GECPB100_LC2_C04 LC2_C04 { get; set; } = new GECPB100_LC2_C04();
            public class GECPB100_LC2_C04 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA '.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA ");
                /*"    10    FILLER                PIC  X(014)      VALUE          'DTA-MOVIMENTO '.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"DTA-MOVIMENTO ");
                /*"    10    FILLER                PIC  X(011)      VALUE          'COD-ORIGEM '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-ORIGEM ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-ORIGEM '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-ORIGEM ");
                /*"    10    FILLER                PIC  X(031)      VALUE          'NOM-PROGRAMA                   '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"NOM-PROGRAMA                   ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"    10    FILLER                PIC  X(142)      VALUE SPACES.*/
                public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "142", "X(142)"), @"");
                /*"  05      LC3-C04.*/
            }
            public GECPB100_LC3_C04 LC3_C04 { get; set; } = new GECPB100_LC3_C04();
            public class GECPB100_LC3_C04 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(014)      VALUE          '------------- '.*/
                public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"------------- ");
                /*"    10    FILLER                PIC  X(011)      VALUE          '---------- '.*/
                public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"---------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(031)      VALUE          '------------------------------ '.*/
                public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @"------------------------------ ");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"    10    FILLER                PIC  X(142)      VALUE SPACES.*/
                public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "142", "X(142)"), @"");
                /*"  05      LC1-C05.*/
            }
            public GECPB100_LC1_C05 LC1_C05 { get; set; } = new GECPB100_LC1_C05();
            public class GECPB100_LC1_C05 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(017)      VALUE          'ARQ-A  SEM  ARQ-G'.*/
                public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"ARQ-A  SEM  ARQ-G");
                /*"    10    FILLER                PIC  X(267)      VALUE SPACES.*/
                public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "267", "X(267)"), @"");
                /*"  05      LC2-C05.*/
            }
            public GECPB100_LC2_C05 LC2_C05 { get; set; } = new GECPB100_LC2_C05();
            public class GECPB100_LC2_C05 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA '.*/
                public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA ");
                /*"    10    FILLER                PIC  X(025)      VALUE          'COD-LOTE-A               '.*/
                public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COD-LOTE-A               ");
                /*"    10    FILLER                PIC  X(050)      VALUE          'NOM-EXTERNO-ARQUIVO                               '.*/
                public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NOM-EXTERNO-ARQUIVO                               ");
                /*"    10    FILLER                PIC  X(171)      VALUE SPACES.*/
                public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "171", "X(171)"), @"");
                /*"  05      LC3-C05.*/
            }
            public GECPB100_LC3_C05 LC3_C05 { get; set; } = new GECPB100_LC3_C05();
            public class GECPB100_LC3_C05 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(025)      VALUE          '------------------------ '.*/
                public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"------------------------ ");
                /*"    10    FILLER                PIC  X(050)      VALUE          '------------------------------------------------- '.*/
                public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"------------------------------------------------- ");
                /*"    10    FILLER                PIC  X(171)      VALUE SPACES.*/
                public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "171", "X(171)"), @"");
                /*"  05      LC1-C06.*/
            }
            public GECPB100_LC1_C06 LC1_C06 { get; set; } = new GECPB100_LC1_C06();
            public class GECPB100_LC1_C06 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(049)      VALUE          'ULTIMO DIA COM REJEICAO DO SAP INFORMADA NO ARQ-G'.*/
                public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "49", "X(049)"), @"ULTIMO DIA COM REJEICAO DO SAP INFORMADA NO ARQ-G");
                /*"    10    FILLER                PIC  X(235)      VALUE SPACES.*/
                public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "235", "X(235)"), @"");
                /*"  05      LC2-C06.*/
            }
            public GECPB100_LC2_C06 LC2_C06 { get; set; } = new GECPB100_LC2_C06();
            public class GECPB100_LC2_C06 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA'.*/
                public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA");
                /*"    10    FILLER                PIC  X(007)      VALUE          'ORIGEM '.*/
                public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"ORIGEM ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-ORIGEM '.*/
                public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-ORIGEM ");
                /*"    10    FILLER                PIC  X(025)      VALUE          'LOTE                     '.*/
                public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"LOTE                     ");
                /*"    10    FILLER                PIC  X(028)      VALUE          'STA-CONSUMO                 '.*/
                public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"STA-CONSUMO                 ");
                /*"    10    FILLER                PIC  X(012)      VALUE          'DES-MSG-ERRO'.*/
                public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"DES-MSG-ERRO");
                /*"    10    FILLER                PIC  X(075)      VALUE SPACES.*/
                public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "75", "X(075)"), @"");
                /*"    10    FILLER                PIC  X(051)      VALUE          'NOM-EXTERNO-ARQUIVO                                '.*/
                public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NOM-EXTERNO-ARQUIVO                                ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"  05      LC3-C06.*/
            }
            public GECPB100_LC3_C06 LC3_C06 { get; set; } = new GECPB100_LC3_C06();
            public class GECPB100_LC3_C06 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(007)      VALUE          '------ '.*/
                public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"------ ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(025)      VALUE          '------------------------ '.*/
                public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"------------------------ ");
                /*"    10    FILLER                PIC  X(028)      VALUE          '--------------------------- '.*/
                public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"--------------------------- ");
                /*"    10    FILLER                PIC  X(012)      VALUE          '------------'.*/
                public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"------------");
                /*"    10    FILLER                PIC  X(074)      VALUE ALL '-'.*/
                public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "74", "X(074)"), @"ALL");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    FILLER                PIC  X(051)      VALUE          '-------------------------------------------------- '.*/
                public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"-------------------------------------------------- ");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"  05      LC1-C08.*/
            }
            public GECPB100_LC1_C08 LC1_C08 { get; set; } = new GECPB100_LC1_C08();
            public class GECPB100_LC1_C08 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(102)      VALUE          'ARQ-G COM COBRANCAS OU PAGAMENTOS ACATADOS PELO SAP          'SEM RETORNO DE ARQ-H (FORMA DIFERENTE DE CHEQUE)'.*/
                public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "102", "X(102)"), @"ARQ-G COM COBRANCAS OU PAGAMENTOS ACATADOS PELO SAP          ");
                /*"    10    FILLER                PIC  X(182)      VALUE SPACES.*/
                public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "182", "X(182)"), @"");
                /*"  05      LC2-C08.*/
            }
            public GECPB100_LC2_C08 LC2_C08 { get; set; } = new GECPB100_LC2_C08();
            public class GECPB100_LC2_C08 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA'.*/
                public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA");
                /*"    10    FILLER                PIC  X(025)      VALUE          'COD-LOTE-G               '.*/
                public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COD-LOTE-G               ");
                /*"    10    FILLER                PIC  X(011)      VALUE          'COD-ORIGEM '.*/
                public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-ORIGEM ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-LOTE-G               '.*/
                public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-LOTE-G               ");
                /*"    10    FILLER                PIC  X(017)      VALUE          'DTA-COBRAR-PAGAR '.*/
                public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DTA-COBRAR-PAGAR ");
                /*"    10    FILLER                PIC  X(051)      VALUE          'NOM-EXTERNO-ARQUIVO                                '.*/
                public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NOM-EXTERNO-ARQUIVO                                ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"    10    FILLER                PIC  X(094)      VALUE SPACES.*/
                public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "94", "X(094)"), @"");
                /*"  05      LC3-C08.*/
            }
            public GECPB100_LC3_C08 LC3_C08 { get; set; } = new GECPB100_LC3_C08();
            public class GECPB100_LC3_C08 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(025)      VALUE          '------------------------ '.*/
                public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"------------------------ ");
                /*"    10    FILLER                PIC  X(011)      VALUE          '---------- '.*/
                public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"---------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(017)      VALUE          '---------------- '.*/
                public StringBasis FILLER_132 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"---------------- ");
                /*"    10    FILLER                PIC  X(051)      VALUE          '-------------------------------------------------- '.*/
                public StringBasis FILLER_133 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"-------------------------------------------------- ");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_134 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"    10    FILLER                PIC  X(094)      VALUE SPACES.*/
                public StringBasis FILLER_135 { get; set; } = new StringBasis(new PIC("X", "94", "X(094)"), @"");
                /*"  05      LC1-C09.*/
            }
            public GECPB100_LC1_C09 LC1_C09 { get; set; } = new GECPB100_LC1_C09();
            public class GECPB100_LC1_C09 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_136 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(102)      VALUE          'ARQ-G COM COBRANCAS OU PAGAMENTOS ACATADOS PELO SAP          'SEM RETORNO DE ARQ-H (FORMA CHEQUE)             '.*/
                public StringBasis FILLER_137 { get; set; } = new StringBasis(new PIC("X", "102", "X(102)"), @"ARQ-G COM COBRANCAS OU PAGAMENTOS ACATADOS PELO SAP          ");
                /*"    10    FILLER                PIC  X(182)      VALUE SPACES.*/
                public StringBasis FILLER_138 { get; set; } = new StringBasis(new PIC("X", "182", "X(182)"), @"");
                /*"  05      LC2-C09.*/
            }
            public GECPB100_LC2_C09 LC2_C09 { get; set; } = new GECPB100_LC2_C09();
            public class GECPB100_LC2_C09 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_139 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA '.*/
                public StringBasis FILLER_140 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA ");
                /*"    10    FILLER                PIC  X(025)      VALUE          'COD-LOTE-A               '.*/
                public StringBasis FILLER_141 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COD-LOTE-A               ");
                /*"    10    FILLER                PIC  X(011)      VALUE          'COD-ORIGEM '.*/
                public StringBasis FILLER_142 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-ORIGEM ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-ORIGEM'.*/
                public StringBasis FILLER_143 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-ORIGEM");
                /*"    10    FILLER                PIC  X(017)      VALUE          'DTA-COBRAR-PAGAR '.*/
                public StringBasis FILLER_144 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"DTA-COBRAR-PAGAR ");
                /*"    10    FILLER                PIC  X(051)      VALUE          'NOM-EXTERNO-ARQUIVO                                '.*/
                public StringBasis FILLER_145 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NOM-EXTERNO-ARQUIVO                                ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_146 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"    10    FILLER                PIC  X(094)      VALUE SPACES.*/
                public StringBasis FILLER_147 { get; set; } = new StringBasis(new PIC("X", "94", "X(094)"), @"");
                /*"  05      LC3-C09.*/
            }
            public GECPB100_LC3_C09 LC3_C09 { get; set; } = new GECPB100_LC3_C09();
            public class GECPB100_LC3_C09 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_148 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_149 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(025)      VALUE          '------------------------ '.*/
                public StringBasis FILLER_150 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"------------------------ ");
                /*"    10    FILLER                PIC  X(011)      VALUE          '---------- '.*/
                public StringBasis FILLER_151 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"---------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_152 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(017)      VALUE          '---------------- '.*/
                public StringBasis FILLER_153 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"---------------- ");
                /*"    10    FILLER                PIC  X(051)      VALUE          '-------------------------------------------------- '.*/
                public StringBasis FILLER_154 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"-------------------------------------------------- ");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_155 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"    10    FILLER                PIC  X(094)      VALUE SPACES.*/
                public StringBasis FILLER_156 { get; set; } = new StringBasis(new PIC("X", "94", "X(094)"), @"");
                /*"  05      LC1-C10.*/
            }
            public GECPB100_LC1_C10 LC1_C10 { get; set; } = new GECPB100_LC1_C10();
            public class GECPB100_LC1_C10 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_157 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(070)      VALUE          'RETORNO DE ARQ-H SEM CONSUMO PELO SOLICITANTE DO PAGAM          'ENTO OU COBRANCA'.*/
                public StringBasis FILLER_158 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"RETORNO DE ARQ-H SEM CONSUMO PELO SOLICITANTE DO PAGAM          ");
                /*"    10    FILLER                PIC  X(214)      VALUE SPACES.*/
                public StringBasis FILLER_159 { get; set; } = new StringBasis(new PIC("X", "214", "X(214)"), @"");
                /*"  05      LC2-C10.*/
            }
            public GECPB100_LC2_C10 LC2_C10 { get; set; } = new GECPB100_LC2_C10();
            public class GECPB100_LC2_C10 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          'COD-EMPRESA '.*/
                public StringBasis FILLER_160 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-EMPRESA ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-EMPRESA '.*/
                public StringBasis FILLER_161 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-EMPRESA ");
                /*"    10    FILLER                PIC  X(011)      VALUE          'COD-ORIGEM '.*/
                public StringBasis FILLER_162 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-ORIGEM ");
                /*"    10    FILLER                PIC  X(041)      VALUE          'DES-ORIGEM '.*/
                public StringBasis FILLER_163 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"DES-ORIGEM ");
                /*"    10    FILLER                PIC  X(014)      VALUE          'DTA-MOVIMENTO '.*/
                public StringBasis FILLER_164 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"DTA-MOVIMENTO ");
                /*"    10    FILLER                PIC  X(018)      VALUE          'COD-TIPO-REGISTRO '.*/
                public StringBasis FILLER_165 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"COD-TIPO-REGISTRO ");
                /*"    10    FILLER                PIC  X(018)      VALUE          'COD-RETORNO-ARQ-H '.*/
                public StringBasis FILLER_166 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"COD-RETORNO-ARQ-H ");
                /*"    10    FILLER                PIC  X(137)      VALUE          'DES-RETORNO-ARQ-H '.*/
                public StringBasis FILLER_167 { get; set; } = new StringBasis(new PIC("X", "137", "X(137)"), @"DES-RETORNO-ARQ-H ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_168 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"  05      LC3-C10.*/
            }
            public GECPB100_LC3_C10 LC3_C10 { get; set; } = new GECPB100_LC3_C10();
            public class GECPB100_LC3_C10 : VarBasis
            {
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_169 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_170 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(011)      VALUE          '---------- '.*/
                public StringBasis FILLER_171 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"---------- ");
                /*"    10    FILLER                PIC  X(041)      VALUE ALL '-'.*/
                public StringBasis FILLER_172 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"ALL");
                /*"    10    FILLER                PIC  X(014)      VALUE          '------------- '.*/
                public StringBasis FILLER_173 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"------------- ");
                /*"    10    FILLER                PIC  X(018)      VALUE          '----------------- '.*/
                public StringBasis FILLER_174 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"----------------- ");
                /*"    10    FILLER                PIC  X(018)      VALUE          '----------------- '.*/
                public StringBasis FILLER_175 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"----------------- ");
                /*"    10    FILLER                PIC  X(137)      VALUE ALL '-'.*/
                public StringBasis FILLER_176 { get; set; } = new StringBasis(new PIC("X", "137", "X(137)"), @"ALL");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_177 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"  05      LC1-C11.*/
            }
            public GECPB100_LC1_C11 LC1_C11 { get; set; } = new GECPB100_LC1_C11();
            public class GECPB100_LC1_C11 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_178 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(015)      VALUE          'ARQ-H REJEITADO'.*/
                public StringBasis FILLER_179 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"ARQ-H REJEITADO");
                /*"    10    FILLER                PIC  X(269)      VALUE SPACES.*/
                public StringBasis FILLER_180 { get; set; } = new StringBasis(new PIC("X", "269", "X(269)"), @"");
                /*"  05      LC2-C11.*/
            }
            public GECPB100_LC2_C11 LC2_C11 { get; set; } = new GECPB100_LC2_C11();
            public class GECPB100_LC2_C11 : VarBasis
            {
                /*"    10    FILLER                PIC  X(051)      VALUE          'NOM-EXTERNO-ARQUIVO                                '.*/
                public StringBasis FILLER_181 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NOM-EXTERNO-ARQUIVO                                ");
                /*"    10    FILLER                PIC  X(012)      VALUE          'NUM-NSA-SAP '.*/
                public StringBasis FILLER_182 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"NUM-NSA-SAP ");
                /*"    10    FILLER                PIC  X(013)      VALUE          'SEQ-REGISTRO '.*/
                public StringBasis FILLER_183 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"SEQ-REGISTRO ");
                /*"    10    FILLER                PIC  X(051)      VALUE          'DES-REJEICAO                                       '.*/
                public StringBasis FILLER_184 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"DES-REJEICAO                                       ");
                /*"    10    FILLER                PIC  X(050)      VALUE SPACES.*/
                public StringBasis FILLER_185 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(013)      VALUE          'STA-REJEICAO '.*/
                public StringBasis FILLER_186 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"STA-REJEICAO ");
                /*"    10    FILLER                PIC  X(026)      VALUE          'DTH-ATUALIZACAO'.*/
                public StringBasis FILLER_187 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"DTH-ATUALIZACAO");
                /*"    10    FILLER                PIC  X(083)      VALUE SPACES.*/
                public StringBasis FILLER_188 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"");
                /*"  05      LC3-C11.*/
            }
            public GECPB100_LC3_C11 LC3_C11 { get; set; } = new GECPB100_LC3_C11();
            public class GECPB100_LC3_C11 : VarBasis
            {
                /*"    10    FILLER                PIC  X(051)      VALUE          '-------------------------------------------------- '.*/
                public StringBasis FILLER_189 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"-------------------------------------------------- ");
                /*"    10    FILLER                PIC  X(012)      VALUE          '----------- '.*/
                public StringBasis FILLER_190 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"----------- ");
                /*"    10    FILLER                PIC  X(013)      VALUE          '------------ '.*/
                public StringBasis FILLER_191 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"------------ ");
                /*"    10    FILLER                PIC  X(100)      VALUE ALL '-'.*/
                public StringBasis FILLER_192 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"ALL");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_193 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    FILLER                PIC  X(013)      VALUE          '------------ '.*/
                public StringBasis FILLER_194 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"------------ ");
                /*"    10    FILLER                PIC  X(026)      VALUE          '------------------------- '.*/
                public StringBasis FILLER_195 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"------------------------- ");
                /*"    10    FILLER                PIC  X(083)      VALUE SPACES.*/
                public StringBasis FILLER_196 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"");
                /*"  05      LC1-C12.*/
            }
            public GECPB100_LC1_C12 LC1_C12 { get; set; } = new GECPB100_LC1_C12();
            public class GECPB100_LC1_C12 : VarBasis
            {
                /*"    10    FILLER                PIC  X(015)      VALUE SPACES.*/
                public StringBasis FILLER_197 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"    10    FILLER                PIC  X(048)      VALUE          'TODOS OS ARQUIVOS DE ARQ-H QUE FORAM PROCESSADOS'.*/
                public StringBasis FILLER_198 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"TODOS OS ARQUIVOS DE ARQ-H QUE FORAM PROCESSADOS");
                /*"    10    FILLER                PIC  X(236)      VALUE SPACES.*/
                public StringBasis FILLER_199 { get; set; } = new StringBasis(new PIC("X", "236", "X(236)"), @"");
                /*"  05      LC2-C12.*/
            }
            public GECPB100_LC2_C12 LC2_C12 { get; set; } = new GECPB100_LC2_C12();
            public class GECPB100_LC2_C12 : VarBasis
            {
                /*"    10    FILLER                PIC  X(016)      VALUE          'DTA-GERACAO-ARQ '.*/
                public StringBasis FILLER_200 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"DTA-GERACAO-ARQ ");
                /*"    10    FILLER                PIC  X(007)      VALUE          ' QUANT.'.*/
                public StringBasis FILLER_201 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" QUANT.");
                /*"    10    FILLER                PIC  X(276)      VALUE SPACES.*/
                public StringBasis FILLER_202 { get; set; } = new StringBasis(new PIC("X", "276", "X(276)"), @"");
                /*"  05      LC3-C12.*/
            }
            public GECPB100_LC3_C12 LC3_C12 { get; set; } = new GECPB100_LC3_C12();
            public class GECPB100_LC3_C12 : VarBasis
            {
                /*"    10    FILLER                PIC  X(016)      VALUE          '--------------- '.*/
                public StringBasis FILLER_203 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"--------------- ");
                /*"    10    FILLER                PIC  X(007)      VALUE          '-------'.*/
                public StringBasis FILLER_204 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"-------");
                /*"    10    FILLER                PIC  X(276)      VALUE SPACES.*/
                public StringBasis FILLER_205 { get; set; } = new StringBasis(new PIC("X", "276", "X(276)"), @"");
                /*"  05      LD-SEM-OCOR.*/
            }
            public GECPB100_LD_SEM_OCOR LD_SEM_OCOR { get; set; } = new GECPB100_LD_SEM_OCOR();
            public class GECPB100_LD_SEM_OCOR : VarBasis
            {
                /*"    10    FILLER                PIC  X(019)      VALUE SPACES.*/
                public StringBasis FILLER_206 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"");
                /*"    10    FILLER                PIC  X(041)      VALUE          '*****     NAO HOUVE OCORRENCIAS     *****'.*/
                public StringBasis FILLER_207 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"*****     NAO HOUVE OCORRENCIAS     *****");
                /*"    10    FILLER                PIC  X(239)      VALUE SPACES.*/
                public StringBasis FILLER_208 { get; set; } = new StringBasis(new PIC("X", "239", "X(239)"), @"");
                /*"  05      LDC01.*/
            }
            public GECPB100_LDC01 LDC01 { get; set; } = new GECPB100_LDC01();
            public class GECPB100_LDC01 : VarBasis
            {
                /*"    10    LDC01-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC01_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_209 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC01-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC01_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_210 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC01-COD-ORIGEM      PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC01_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_211 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC01-DES-ORIGEM      PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC01_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_212 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC01-DTA-MOV         PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC01_DTA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(004)      VALUE SPACES.*/
                public StringBasis FILLER_213 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    LDC01-TIP-MOV         PIC  X(018)      VALUE SPACES.*/
                public StringBasis LDC01_TIP_MOV { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_214 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC01-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC01_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10    FILLER                PIC  X(154)      VALUE SPACES.*/
                public StringBasis FILLER_215 { get; set; } = new StringBasis(new PIC("X", "154", "X(154)"), @"");
                /*"  05      LDC02.*/
            }
            public GECPB100_LDC02 LDC02 { get; set; } = new GECPB100_LDC02();
            public class GECPB100_LDC02 : VarBasis
            {
                /*"    10    LDC02-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC02_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_216 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC02-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC02_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_217 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC02-IDLG-MCP        PIC  9(018)      VALUE ZEROS.*/
                public IntBasis LDC02_IDLG_MCP { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_218 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC02-IDLG-SAP        PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC02_IDLG_SAP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_219 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC02-NUM-NSA-SAP     PIC  ZZZZZZZZ9.*/
                public IntBasis LDC02_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10    FILLER                PIC  X(003)      VALUE SPACES.*/
                public StringBasis FILLER_220 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    LDC02-SEQ-REGISTRO    PIC  ZZZZZZZZ9.*/
                public IntBasis LDC02_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10    FILLER                PIC  X(004)      VALUE SPACES.*/
                public StringBasis FILLER_221 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    LDC02-DTA-ARQUIVO     PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC02_DTA_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(002)      VALUE SPACES.*/
                public StringBasis FILLER_222 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10    LDC02-STA-CONSUMO     PIC  X(009)      VALUE SPACES.*/
                public StringBasis LDC02_STA_CONSUMO { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10    FILLER                PIC  X(003)      VALUE SPACES.*/
                public StringBasis FILLER_223 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    LDC02-COD-RET-ARQ-H   PIC  X(006)      VALUE SPACES.*/
                public StringBasis LDC02_COD_RET_ARQ_H { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10    FILLER                PIC  X(012)      VALUE SPACES.*/
                public StringBasis FILLER_224 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10    LDC02-DES-RETORNO-ARQ-H PIC  X(111)      VALUE SPACES.*/
                public StringBasis LDC02_DES_RETORNO_ARQ_H { get; set; } = new StringBasis(new PIC("X", "111", "X(111)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_225 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC02-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC02_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"  05      LDC04.*/
            }
            public GECPB100_LDC04 LDC04 { get; set; } = new GECPB100_LDC04();
            public class GECPB100_LDC04 : VarBasis
            {
                /*"    10    LDC04-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC04_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_226 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC04-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC04_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_227 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC04-DTA-MOV         PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC04_DTA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(004)      VALUE SPACES.*/
                public StringBasis FILLER_228 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    LDC04-COD-ORIGEM      PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC04_COD_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_229 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC04-DES-ORIGEM      PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC04_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_230 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC04-NOM-PROGRAMA    PIC  X(030)      VALUE SPACES.*/
                public StringBasis LDC04_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_231 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC04-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC04_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10    FILLER                PIC  X(142)      VALUE SPACES.*/
                public StringBasis FILLER_232 { get; set; } = new StringBasis(new PIC("X", "142", "X(142)"), @"");
                /*"  05      LDC05.*/
            }
            public GECPB100_LDC05 LDC05 { get; set; } = new GECPB100_LDC05();
            public class GECPB100_LDC05 : VarBasis
            {
                /*"    10    LDC05-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC05_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_233 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC05-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC05_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_234 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC05-COD-LOTE-A      PIC  X(024)      VALUE SPACES.*/
                public StringBasis LDC05_COD_LOTE_A { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_235 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC05-NOM-EXT-ARQ     PIC  X(050)      VALUE SPACES.*/
                public StringBasis LDC05_NOM_EXT_ARQ { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(171)      VALUE SPACES.*/
                public StringBasis FILLER_236 { get; set; } = new StringBasis(new PIC("X", "171", "X(171)"), @"");
                /*"  05      LDC06.*/
            }
            public GECPB100_LDC06 LDC06 { get; set; } = new GECPB100_LDC06();
            public class GECPB100_LDC06 : VarBasis
            {
                /*"    10    LDC06-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC06_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_237 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC06-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC06_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_238 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC06-ORIGEM          PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC06_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(003)      VALUE SPACES.*/
                public StringBasis FILLER_239 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    LDC06-DES-ORIGEM      PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC06_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_240 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC06-LOTE            PIC  X(024)      VALUE SPACES.*/
                public StringBasis LDC06_LOTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_241 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC06-STA-CONSUMO     PIC  X(027)      VALUE SPACES.*/
                public StringBasis LDC06_STA_CONSUMO { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_242 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC06-DES-MSG-ERRO    PIC  X(086)      VALUE SPACES.*/
                public StringBasis LDC06_DES_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "86", "X(086)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_243 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC06-NOM-EXT-ARQ     PIC  X(050)      VALUE SPACES.*/
                public StringBasis LDC06_NOM_EXT_ARQ { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_244 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC06-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC06_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"  05      LDC08.*/
            }
            public GECPB100_LDC08 LDC08 { get; set; } = new GECPB100_LDC08();
            public class GECPB100_LDC08 : VarBasis
            {
                /*"    10    LDC08-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC08_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_245 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC08-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC08_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_246 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC08-LOTE            PIC  X(024)      VALUE SPACES.*/
                public StringBasis LDC08_LOTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_247 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC08-ORIGEM          PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC08_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_248 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC08-DES-ORIGEM      PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC08_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_249 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC08-DTA-COBRAR      PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC08_DTA_COBRAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_250 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC08-NOM-EXT-ARQ     PIC  X(050)      VALUE SPACES.*/
                public StringBasis LDC08_NOM_EXT_ARQ { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_251 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC08-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC08_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10    FILLER                PIC  X(094)      VALUE SPACES.*/
                public StringBasis FILLER_252 { get; set; } = new StringBasis(new PIC("X", "94", "X(094)"), @"");
                /*"  05      LDC09.*/
            }
            public GECPB100_LDC09 LDC09 { get; set; } = new GECPB100_LDC09();
            public class GECPB100_LDC09 : VarBasis
            {
                /*"    10    LDC09-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC09_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_253 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC09-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC09_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_254 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC09-LOTE            PIC  X(024)      VALUE SPACES.*/
                public StringBasis LDC09_LOTE { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_255 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC09-ORIGEM          PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC09_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_256 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC09-DES-ORIGEM      PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC09_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_257 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC09-DTA-COBRAR      PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC09_DTA_COBRAR { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_258 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC09-NOM-EXT-ARQ     PIC  X(050)      VALUE SPACES.*/
                public StringBasis LDC09_NOM_EXT_ARQ { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_259 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC09-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC09_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10    FILLER                PIC  X(094)      VALUE SPACES.*/
                public StringBasis FILLER_260 { get; set; } = new StringBasis(new PIC("X", "94", "X(094)"), @"");
                /*"  05      LDC10.*/
            }
            public GECPB100_LDC10 LDC10 { get; set; } = new GECPB100_LDC10();
            public class GECPB100_LDC10 : VarBasis
            {
                /*"    10    LDC10-COD-EMPRESA     PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC10_COD_EMPRESA { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(008)      VALUE SPACES.*/
                public StringBasis FILLER_261 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10    LDC10-DES-EMPRESA     PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC10_DES_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_262 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC10-ORIGEM          PIC  X(004)      VALUE SPACES.*/
                public StringBasis LDC10_ORIGEM { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    FILLER                PIC  X(007)      VALUE SPACES.*/
                public StringBasis FILLER_263 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10    LDC10-DES-ORIGEM      PIC  X(040)      VALUE SPACES.*/
                public StringBasis LDC10_DES_ORIGEM { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_264 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC10-DTA-MOV         PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC10_DTA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(004)      VALUE SPACES.*/
                public StringBasis FILLER_265 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    LDC10-COD-TIP-REG     PIC  X(002)      VALUE SPACES.*/
                public StringBasis LDC10_COD_TIP_REG { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10    FILLER                PIC  X(016)      VALUE SPACES.*/
                public StringBasis FILLER_266 { get; set; } = new StringBasis(new PIC("X", "16", "X(016)"), @"");
                /*"    10    LDC10-COD-TIP-RET     PIC  X(006)      VALUE SPACES.*/
                public StringBasis LDC10_COD_TIP_RET { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10    FILLER                PIC  X(012)      VALUE SPACES.*/
                public StringBasis FILLER_267 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10    LDC10-DES-TIP-RET     PIC  X(136)      VALUE SPACES.*/
                public StringBasis LDC10_DES_TIP_RET { get; set; } = new StringBasis(new PIC("X", "136", "X(136)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_268 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC10-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC10_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"  05      LDC11.*/
            }
            public GECPB100_LDC11 LDC11 { get; set; } = new GECPB100_LDC11();
            public class GECPB100_LDC11 : VarBasis
            {
                /*"    10    LDC11-NOM-EXT-ARQ     PIC  X(050)      VALUE SPACES.*/
                public StringBasis LDC11_NOM_EXT_ARQ { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_269 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC11-NUM-NSA-SAP     PIC  ZZZZZZZZ9.*/
                public IntBasis LDC11_NUM_NSA_SAP { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10    FILLER                PIC  X(003)      VALUE SPACES.*/
                public StringBasis FILLER_270 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10    LDC11-SEQ-REGISTRO    PIC  ZZZZZZZZ9.*/
                public IntBasis LDC11_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"    10    FILLER                PIC  X(004)      VALUE SPACES.*/
                public StringBasis FILLER_271 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10    LDC11-DES-REJ         PIC  X(100)      VALUE SPACES.*/
                public StringBasis LDC11_DES_REJ { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_272 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC11-STA-REJ         PIC  X(012)      VALUE SPACES.*/
                public StringBasis LDC11_STA_REJ { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
                /*"    10    FILLER                PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_273 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10    LDC11-DTH-ATU         PIC  X(026)      VALUE SPACES.*/
                public StringBasis LDC11_DTH_ATU { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
                /*"    10    FILLER                PIC  X(083)      VALUE SPACES.*/
                public StringBasis FILLER_274 { get; set; } = new StringBasis(new PIC("X", "83", "X(083)"), @"");
                /*"  05      LDC12.*/
            }
            public GECPB100_LDC12 LDC12 { get; set; } = new GECPB100_LDC12();
            public class GECPB100_LDC12 : VarBasis
            {
                /*"    10    LDC12-DTA-GERA-ARQ    PIC  X(010)      VALUE SPACES.*/
                public StringBasis LDC12_DTA_GERA_ARQ { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10    FILLER                PIC  X(006)      VALUE SPACES.*/
                public StringBasis FILLER_275 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10    LDC12-QTD             PIC  ZZZZZZ9.*/
                public IntBasis LDC12_QTD { get; set; } = new IntBasis(new PIC("9", "7", "ZZZZZZ9."));
                /*"    10    FILLER                PIC  X(276)      VALUE SPACES.*/
                public StringBasis FILLER_276 { get; set; } = new StringBasis(new PIC("X", "276", "X(276)"), @"");
                /*"01        LK-LINK.*/
            }
        }
        public GECPB100_LK_LINK LK_LINK { get; set; } = new GECPB100_LK_LINK();
        public class GECPB100_LK_LINK : VarBasis
        {
            /*"  05      LK-RTCODE             PIC S9(004)      VALUE +0  COMP.*/
            public IntBasis LK_RTCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      LK-TAMANHO            PIC S9(004)      VALUE +40 COMP.*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"  05      LK-TITULO             PIC  X(132)      VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"01        WABEND.*/
        }
        public GECPB100_WABEND WABEND { get; set; } = new GECPB100_WABEND();
        public class GECPB100_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(010)      VALUE         ' GECPB100'.*/
            public StringBasis FILLER_277 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" GECPB100");
            /*"  05      FILLER                PIC  X(026)      VALUE         ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_278 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05      WNR-EXEC-SQL          PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER                PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_279 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
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
        public Dclgens.GE562 GE562 { get; set; } = new Dclgens.GE562();
        public Dclgens.GE577 GE577 { get; set; } = new Dclgens.GE577();
        public Dclgens.GE597 GE597 { get; set; } = new Dclgens.GE597();
        public Dclgens.GE576 GE576 { get; set; } = new Dclgens.GE576();
        public Dclgens.GE538 GE538 { get; set; } = new Dclgens.GE538();

        public GECPB100_C01 C01 { get; set; } = new GECPB100_C01(false);
        string GetQuery_C01()
        {
            var query = @$"SELECT B.COD_EMPRESA
							, T.DES_EMPRESA
							, B.COD_ORIGEM
							, T.DES_ORIGEM
							, A.DTA_MOVIMENTO
							, CASE A.COD_TIPO_OCOR WHEN 'S' THEN '1-SOLICITA��O' WHEN 'A' THEN '2-ARQ-A GERADO' WHEN 'G' THEN '3-RETORNO DE ARQ-G' WHEN 'CG' THEN '4-CONSUMO DE ARQ-G' WHEN 'H' THEN '5-RETORNO DE ARQ-H' WHEN 'CH' THEN '6-CONSUMO DE ARQ-H' ELSE A.COD_TIPO_OCOR END AS TIPO_MOVIMENTO
							, COUNT(*) AS QTD
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_SOLICITACAO_AP_CA_SAP B
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							, X.COD_ORIGEM
							,X.DES_ORIGEM
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE A.DTA_MOVIMENTO > CURRENT DATE - 10 DAYS AND VALUE(A.NUM_IDLG
							, 0) > 0 AND A.NUM_IDLG = B.NUM_IDLG AND T.COD_EMPRESA = B.COD_EMPRESA AND T.COD_ORIGEM = B.COD_ORIGEM GROUP BY B.COD_EMPRESA
							, T.DES_EMPRESA
							, B.COD_ORIGEM
							, T.DES_ORIGEM
							, A.DTA_MOVIMENTO
							, A.COD_TIPO_OCOR ORDER BY 1
							,2
							,3
							,4
							,5
							,6";

            return query;
        }


        public GECPB100_C02 C02 { get; set; } = new GECPB100_C02(false);
        string GetQuery_C02()
        {
            var query = @$"SELECT A1.COD_EMPRESA
							, T1.DES_EMPRESA
							, T.NUM_IDLG AS IDLG_MCP
							, A1.COD_ID_PAGAM_COBR AS IDLG_SAP
							, A1.NUM_NSA_SAP
							, A1.SEQ_REGISTRO
							, C1.DTA_GERACAO_ARQ AS DTA_ARQUIVO
							, CASE A1.STA_CONSUMO_SOLICITANTE WHEN 'P' THEN 'PENDENTE' WHEN 'C' THEN 'CONSUMIDO' ELSE A1.STA_CONSUMO_SOLICITANTE END AS STA_CONSUMO
							, B1.COD_RETORNO_ARQ_H
							, D1.DES_RETORNO_ARQ_H
							, T.QTD
							FROM SIUS.GE_DETALHE_ARQ_H_SAP A1
							, SIUS.GE_DET_ARQ_H_RETORNO_SAP B1
							, SIUS.GE_CONTROL_ARQ_H_SAP C1
							, SIUS.GE_RETORNO_ARQ_H_SAP D1
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T1
							,
							(SELECT  A.NUM_IDLG
							, COUNT(*) AS QTD
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_DET_ARQ_H_RETORNO_SAP B WHERE A.COD_TIPO_OCOR = 'H' AND A.DTA_MOVIMENTO > CURRENT DATE - 30 DAYS AND VALUE(A.NUM_IDLG
							, 0) > 0 AND B.NUM_NSA_SAP = A.NUM_NSA_SAP AND B.SEQ_REGISTRO = A.SEQ_REGISTRO AND B.COD_RETORNO_ARQ_H NOT IN ('1I'
							,'BD'
							,'B2') AND B.COD_MODULO_SAP = A.COD_MODULO_SAP GROUP BY A.NUM_IDLG HAVING COUNT(*) > 1) T WHERE B1.NUM_NSA_SAP = A1.NUM_NSA_SAP AND B1.SEQ_REGISTRO = A1.SEQ_REGISTRO AND B1.COD_RETORNO_ARQ_H NOT IN ('1I'
							,'BD'
							,'B2') AND B1.COD_MODULO_SAP = A1.COD_MODULO_SAP AND C1.NUM_NSA_SAP = A1.NUM_NSA_SAP AND C1.COD_MODULO_SAP = A1.COD_MODULO_SAP AND T.NUM_IDLG = A1.NUM_IDLG AND T1.COD_EMPRESA = A1.COD_EMPRESA AND D1.COD_RETORNO_ARQ_H = B1.COD_RETORNO_ARQ_H AND D1.IND_TIPO_RETORNO = B1.IND_TIPO_RETORNO ORDER BY 1
							,2
							,3
							,4
							,5
							,6
							,7
							,8";

            return query;
        }


        public GECPB100_C04 C04 { get; set; } = new GECPB100_C04(false);
        string GetQuery_C04()
        {
            var query = @$"SELECT B.COD_EMPRESA
							, T.DES_EMPRESA
							, A.DTA_MOVIMENTO
							, A.COD_ORIGEM
							, T.DES_ORIGEM
							, A.NOM_PROGRAMA
							, COUNT(*) AS QTD
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_SOLICITACAO_AP_CA_SAP B
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							, X.COD_ORIGEM
							,X.DES_ORIGEM
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE A.NUM_IDLG = B.NUM_IDLG AND A.DTA_MOVIMENTO > CURRENT DATE - 10 DAYS AND A.COD_TIPO_OCOR = 'S' AND NOT EXISTS
							(SELECT  *
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST C WHERE C.NUM_IDLG = A.NUM_IDLG AND C.COD_TIPO_OCOR = 'A' AND C.DTA_MOVIMENTO >= A.DTA_MOVIMENTO) AND T.COD_EMPRESA = B.COD_EMPRESA AND T.COD_ORIGEM = A.COD_ORIGEM GROUP BY B.COD_EMPRESA
							, T.DES_EMPRESA
							, A.DTA_MOVIMENTO
							, A.COD_ORIGEM
							, T.DES_ORIGEM
							, A.NOM_PROGRAMA ORDER BY 1
							,2
							,3
							,4
							,5
							,6";

            return query;
        }


        public GECPB100_C05 C05 { get; set; } = new GECPB100_C05(false);
        string GetQuery_C05()
        {
            var query = @$"SELECT DISTINCT C.COD_EMPRESA
							, T.DES_EMPRESA
							, B.COD_LOTE_A
							, B.NOM_EXTERNO_ARQUIVO
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_CONTROL_ARQ_A_SAP B
							, SIUS.GE_SOLICITACAO_AP_CA_SAP C
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE A.NUM_IDLG = C.NUM_IDLG AND A.DTA_MOVIMENTO > CURRENT DATE - 10 DAYS AND A.COD_TIPO_OCOR = 'A' AND A.COD_LOTE_A = B.COD_LOTE_A AND A.COD_ORIGEM = B.COD_ORIGEM AND T.COD_EMPRESA = C.COD_EMPRESA AND A.COD_LOTE_A =
							(SELECT  MAX(D.COD_LOTE_A)
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST D WHERE D.SEQ_AP_CA_SAP_HIST = A.SEQ_AP_CA_SAP_HIST) AND NOT EXISTS
							(SELECT  *
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST E WHERE E.SEQ_AP_CA_SAP_HIST = A.SEQ_AP_CA_SAP_HIST AND E.COD_TIPO_OCOR = 'G' AND E.COD_LOTE_G = A.COD_LOTE_A) ORDER BY 1
							, 2
							, 3";

            return query;
        }


        public GECPB100_C06 C06 { get; set; } = new GECPB100_C06(true);
        string GetQuery_C06()
        {
            var query = @$"SELECT B.COD_EMPRESA
							, T.DES_EMPRESA
							, G.COD_ORIGEM AS ORIGEM
							, T.DES_ORIGEM
							, G.COD_LOTE_G AS LOTE
							, CASE G.STA_CONSUMO_SOLICITANTE WHEN 'P' THEN 'PENDENTE DE RECUPERACAO' WHEN 'C' THEN 'RECUPERADO PELO SOLICITANTE' ELSE G.STA_CONSUMO_SOLICITANTE END AS STA_CONSUMO
							, GE.DES_MSG_ERRO
							, GC.NOM_EXTERNO_ARQUIVO
							, COUNT(*) AS QTD
							FROM SIUS.GE_DETALHE_ARQ_G_SAP G
							, SIUS.GE_DET_ARQ_G_SAP_ERRO GE
							, SIUS.GE_CONTROL_ARQ_G_SAP GC
							, SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_SOLICITACAO_AP_CA_SAP B
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							, X.COD_ORIGEM
							,X.DES_ORIGEM
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE G.STA_PROCESSAMENTO = '2' AND GE.COD_LOTE_G = G.COD_LOTE_G AND GE.COD_ORIGEM = G.COD_ORIGEM AND GE.SEQ_REGISTRO_LOTE_G = G.SEQ_REGISTRO_LOTE_G AND GC.COD_LOTE_G = G.COD_LOTE_G AND GC.COD_ORIGEM = G.COD_ORIGEM AND G.COD_LOTE_G = A.COD_LOTE_G AND G.COD_ORIGEM = A.COD_ORIGEM AND G.SEQ_REGISTRO_LOTE_G = A.SEQ_REGISTRO_LOTE_G AND A.NUM_IDLG = B.NUM_IDLG AND A.DTA_MOVIMENTO = '{GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_ULT_MOV_ABERTO}' AND A.COD_TIPO_OCOR = 'G' AND T.COD_EMPRESA = B.COD_EMPRESA AND T.COD_ORIGEM = G.COD_ORIGEM GROUP BY B.COD_EMPRESA
							, T.DES_EMPRESA
							, G.COD_ORIGEM
							, T.DES_ORIGEM
							, G.COD_LOTE_G
							, G.STA_CONSUMO_SOLICITANTE
							, GE.DES_MSG_ERRO
							, GC.NOM_EXTERNO_ARQUIVO";

            return query;
        }


        public GECPB100_C08 C08 { get; set; } = new GECPB100_C08(false);
        string GetQuery_C08()
        {
            var query = @$"SELECT F.COD_EMPRESA
							, T.DES_EMPRESA
							, A.COD_LOTE_G
							, A.COD_ORIGEM
							, T.DES_ORIGEM
							, E.DTA_COBRAR_PAGAR
							, D.NOM_EXTERNO_ARQUIVO
							, COUNT(*) AS QTD
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_DETALHE_ARQ_G_SAP C
							, SIUS.GE_CONTROL_ARQ_G_SAP D
							, SIUS.GE_FORMA_COBRA_PAGA_SAP E
							, SIUS.GE_SOLICITACAO_AP_CA_SAP F
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							, X.COD_ORIGEM
							,X.DES_ORIGEM
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE A.DTA_MOVIMENTO > CURRENT DATE - 30 DAYS AND A.DTA_MOVIMENTO < CURRENT DATE - 04 DAYS AND A.COD_TIPO_OCOR = 'G' AND VALUE(A.NUM_IDLG
							,0) > 0 AND C.COD_LOTE_G = A.COD_LOTE_G AND C.COD_ORIGEM = A.COD_ORIGEM AND C.SEQ_REGISTRO_LOTE_G = A.SEQ_REGISTRO_LOTE_G AND C.STA_PROCESSAMENTO = '1' AND A.COD_LOTE_G = D.COD_LOTE_G AND A.COD_ORIGEM = D.COD_ORIGEM AND E.NUM_IDLG = A.NUM_IDLG AND F.NUM_IDLG = A.NUM_IDLG AND E.COD_FORMA <> 'C' AND E.DTA_COBRAR_PAGAR < CURRENT DATE - 04 DAYS AND A.COD_ORIGEM NOT IN ('Q200'
							,'X200') AND T.COD_EMPRESA = F.COD_EMPRESA AND T.COD_ORIGEM = A.COD_ORIGEM AND NOT EXISTS
							(SELECT  *
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST H1
							, SIUS.GE_DET_ARQ_H_RETORNO_SAP R WHERE H1.SEQ_AP_CA_SAP_HIST = A.SEQ_AP_CA_SAP_HIST AND H1.COD_TIPO_OCOR = 'H' AND R.NUM_NSA_SAP = VALUE(H1.NUM_NSA_SAP
							,0) AND R.SEQ_REGISTRO = VALUE(H1.SEQ_REGISTRO
							,0) AND R.COD_RETORNO_ARQ_H <> 'BD' AND R.COD_MODULO_SAP = VALUE(H1.COD_MODULO_SAP
							,' ')) GROUP BY F.COD_EMPRESA
							, T.DES_EMPRESA
							, A.COD_LOTE_G
							, A.COD_ORIGEM
							, T.DES_ORIGEM
							, E.DTA_COBRAR_PAGAR
							, D.NOM_EXTERNO_ARQUIVO";

            return query;
        }


        public GECPB100_C09 C09 { get; set; } = new GECPB100_C09(false);
        string GetQuery_C09()
        {
            var query = @$"SELECT G.COD_EMPRESA
							, T.DES_EMPRESA
							, H.COD_LOTE_A
							, H.COD_ORIGEM
							, T.DES_ORIGEM
							, F.DTA_COBRAR_PAGAR
							, C.NOM_EXTERNO_ARQUIVO
							, COUNT(*)
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST H
							, SIUS.GE_DETALHE_ARQ_G_SAP D
							, SIUS.GE_CONTROL_ARQ_G_SAP C
							, SIUS.GE_FORMA_COBRA_PAGA_SAP F
							, SIUS.GE_SOLICITACAO_AP_CA_SAP G
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							, X.COD_ORIGEM
							,X.DES_ORIGEM
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE H.COD_TIPO_OCOR = 'G' AND H.DTA_MOVIMENTO > CURRENT DATE - 30 DAYS AND H.DTA_MOVIMENTO < CURRENT DATE - 04 DAYS AND D.COD_LOTE_G = H.COD_LOTE_G AND D.COD_ORIGEM = H.COD_ORIGEM AND D.SEQ_REGISTRO_LOTE_G = H.SEQ_REGISTRO_LOTE_G AND D.STA_PROCESSAMENTO = '1' AND C.COD_LOTE_G = H.COD_LOTE_G AND C.COD_ORIGEM = H.COD_ORIGEM AND F.NUM_IDLG = H.NUM_IDLG AND G.NUM_IDLG = H.NUM_IDLG AND F.COD_FORMA = 'C' AND F.DTA_COBRAR_PAGAR < CURRENT DATE - 04 DAYS AND T.COD_EMPRESA = G.COD_EMPRESA AND T.COD_ORIGEM = H.COD_ORIGEM AND NOT EXISTS
							(SELECT  *
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST H1
							, SIUS.GE_DET_ARQ_H_RETORNO_SAP R WHERE H1.SEQ_AP_CA_SAP_HIST = H.SEQ_AP_CA_SAP_HIST AND H1.COD_TIPO_OCOR = 'H' AND R.NUM_NSA_SAP = VALUE(H1.NUM_NSA_SAP
							,0) AND R.SEQ_REGISTRO = VALUE(H1.SEQ_REGISTRO
							,0) AND R.COD_RETORNO_ARQ_H IN ('00'
							,'1C') AND R.COD_MODULO_SAP = VALUE(H1.COD_MODULO_SAP
							,' ')) GROUP BY G.COD_EMPRESA
							, T.DES_EMPRESA
							, H.COD_LOTE_A
							, H.COD_ORIGEM
							, T.DES_ORIGEM
							, F.DTA_COBRAR_PAGAR
							, C.NOM_EXTERNO_ARQUIVO ORDER BY 1
							, 2
							, 3
							, 4
							, 5
							, 6
							, 7";

            return query;
        }


        public GECPB100_C10 C10 { get; set; } = new GECPB100_C10(false);
        string GetQuery_C10()
        {
            var query = @$"SELECT D.COD_EMPRESA
							, T.DES_EMPRESA
							, A.COD_ORIGEM
							, T.DES_ORIGEM
							, A.DTA_MOVIMENTO
							, B.COD_TIPO_REGISTRO
							, C.COD_RETORNO_ARQ_H
							, E.DES_RETORNO_ARQ_H
							, COUNT(*)
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST A
							, SIUS.GE_DETALHE_ARQ_H_SAP B
							, SIUS.GE_DET_ARQ_H_RETORNO_SAP C
							, SIUS.GE_SOLICITACAO_AP_CA_SAP D
							, SIUS.GE_RETORNO_ARQ_H_SAP E
							,
							(SELECT  DISTINCT X.COD_EMPRESA
							,X.DES_EMPRESA
							, X.COD_ORIGEM
							,X.DES_ORIGEM
							FROM SIUS.GE_EVENTO_AP_CA_SAP X) T WHERE A.COD_TIPO_OCOR = 'H' AND A.DTA_MOVIMENTO > CURRENT DATE - 30 DAYS AND B.NUM_NSA_SAP = A.NUM_NSA_SAP AND B.SEQ_REGISTRO = A.SEQ_REGISTRO AND B.COD_MODULO_SAP = A.COD_MODULO_SAP AND C.NUM_NSA_SAP = B.NUM_NSA_SAP AND C.SEQ_REGISTRO = B.SEQ_REGISTRO AND C.COD_RETORNO_ARQ_H NOT IN ('BD'
							,'1I') AND C.COD_MODULO_SAP = B.COD_MODULO_SAP AND D.NUM_IDLG = A.NUM_IDLG AND T.COD_EMPRESA = D.COD_EMPRESA AND T.COD_ORIGEM = A.COD_ORIGEM AND E.IND_TIPO_RETORNO = C.IND_TIPO_RETORNO AND E.COD_RETORNO_ARQ_H = C.COD_RETORNO_ARQ_H AND NOT EXISTS
							(SELECT  *
							FROM SIUS.GE_SOLICITA_AP_CA_SAP_HIST H WHERE H.NUM_NSA_SAP = A.NUM_NSA_SAP AND H.SEQ_REGISTRO = A.SEQ_REGISTRO AND H.COD_TIPO_OCOR = 'CH' AND H.COD_MODULO_SAP = A.COD_MODULO_SAP) GROUP BY D.COD_EMPRESA
							, T.DES_EMPRESA
							, A.COD_ORIGEM
							, T.DES_ORIGEM
							, A.DTA_MOVIMENTO
							, B.COD_TIPO_REGISTRO
							, C.COD_RETORNO_ARQ_H
							, E.DES_RETORNO_ARQ_H";

            return query;
        }


        public GECPB100_C11 C11 { get; set; } = new GECPB100_C11(false);
        string GetQuery_C11()
        {
            var query = @$"SELECT NOM_EXTERNO_ARQUIVO
							, NUM_NSA_SAP
							, SEQ_REGISTRO
							, LTRIM(DES_REJEICAO)
							, STA_REJEICAO
							, DTH_ATUALIZACAO
							FROM SIUS.GE_ARQ_H_SAP_REJEITADO WHERE DATE(DTH_ATUALIZACAO) > CURRENT DATE - 10 DAYS";

            return query;
        }


        public GECPB100_C12 C12 { get; set; } = new GECPB100_C12(false);
        string GetQuery_C12()
        {
            var query = @$"SELECT DTA_GERACAO_ARQ
							, COUNT(*) AS QTD
							FROM SIUS.GE_CONTROL_ARQ_H_SAP WHERE DTA_GERACAO_ARQ > CURRENT DATE - 10 DAYS GROUP BY DTA_GERACAO_ARQ";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string CPB100S1_FILE_NAME_P, string CP100T01_FILE_NAME_P, string CP100T02_FILE_NAME_P, string CP100T03_FILE_NAME_P, string CP100T04_FILE_NAME_P, string CP100T05_FILE_NAME_P, string CP100T67_FILE_NAME_P, string CP100T08_FILE_NAME_P, string CP100T09_FILE_NAME_P, string CP100T10_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                CPB100S1.SetFile(CPB100S1_FILE_NAME_P);
                CP100T01.SetFile(CP100T01_FILE_NAME_P);
                CP100T02.SetFile(CP100T02_FILE_NAME_P);
                CP100T03.SetFile(CP100T03_FILE_NAME_P);
                CP100T04.SetFile(CP100T04_FILE_NAME_P);
                CP100T05.SetFile(CP100T05_FILE_NAME_P);
                CP100T67.SetFile(CP100T67_FILE_NAME_P);
                CP100T08.SetFile(CP100T08_FILE_NAME_P);
                CP100T09.SetFile(CP100T09_FILE_NAME_P);
                CP100T10.SetFile(CP100T10_FILE_NAME_P);
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
            C04.GetQueryEvent += GetQuery_C04;
            C05.GetQueryEvent += GetQuery_C05;
            C06.GetQueryEvent += GetQuery_C06;
            C08.GetQueryEvent += GetQuery_C08;
            C09.GetQueryEvent += GetQuery_C09;
            C10.GetQueryEvent += GetQuery_C10;
            C11.GetQueryEvent += GetQuery_C11;
            C12.GetQueryEvent += GetQuery_C12;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -1490- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -1491- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1494- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1497- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -1507- DISPLAY 'GECPB100 - INICIO PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"GECPB100 - INICIO PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1508- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1509- DISPLAY 'GECPB100 - VERSAO V.06' . */
            _.Display($"GECPB100 - VERSAO V.06");

            /*" -1511- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1512- OPEN OUTPUT CPB100S1. */
            CPB100S1.Open(REG_CPB100S1, AREA_DE_WORK.WSTATUS);

            /*" -1513- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -1514- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CPB100S1' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CPB100S1");

                /*" -1515- DISPLAY 'STATUS  - ' WSTATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTATUS}");

                /*" -1516- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1518- END-IF. */
            }


            /*" -1519- OPEN OUTPUT CP100T01. */
            CP100T01.Open(REG_CP100T01, AREA_DE_WORK.WSTAT01);

            /*" -1520- IF WSTAT01 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT01 != 00)
            {

                /*" -1521- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T01' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T01");

                /*" -1522- DISPLAY 'STATUS  - ' WSTAT01 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT01}");

                /*" -1523- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1524- END-IF. */
            }


            /*" -1525- OPEN OUTPUT CP100T02. */
            CP100T02.Open(REG_CP100T02, AREA_DE_WORK.WSTAT02);

            /*" -1526- IF WSTAT02 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT02 != 00)
            {

                /*" -1527- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T02' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T02");

                /*" -1528- DISPLAY 'STATUS  - ' WSTAT02 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT02}");

                /*" -1529- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1530- END-IF. */
            }


            /*" -1531- OPEN OUTPUT CP100T03. */
            CP100T03.Open(REG_CP100T03, AREA_DE_WORK.WSTAT03);

            /*" -1532- IF WSTAT03 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT03 != 00)
            {

                /*" -1533- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T03' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T03");

                /*" -1534- DISPLAY 'STATUS  - ' WSTAT03 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT03}");

                /*" -1535- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1536- END-IF. */
            }


            /*" -1537- OPEN OUTPUT CP100T04. */
            CP100T04.Open(REG_CP100T04, AREA_DE_WORK.WSTAT04);

            /*" -1538- IF WSTAT04 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT04 != 00)
            {

                /*" -1539- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T04' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T04");

                /*" -1540- DISPLAY 'STATUS  - ' WSTAT04 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT04}");

                /*" -1541- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1542- END-IF. */
            }


            /*" -1543- OPEN OUTPUT CP100T05. */
            CP100T05.Open(REG_CP100T05, AREA_DE_WORK.WSTAT05);

            /*" -1544- IF WSTAT05 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT05 != 00)
            {

                /*" -1545- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T05' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T05");

                /*" -1546- DISPLAY 'STATUS  - ' WSTAT05 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT05}");

                /*" -1547- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1548- END-IF. */
            }


            /*" -1549- OPEN OUTPUT CP100T67. */
            CP100T67.Open(REG_CP100T67, AREA_DE_WORK.WSTAT67);

            /*" -1550- IF WSTAT67 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT67 != 00)
            {

                /*" -1551- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T67' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T67");

                /*" -1552- DISPLAY 'STATUS  - ' WSTAT67 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT67}");

                /*" -1553- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1554- END-IF. */
            }


            /*" -1555- OPEN OUTPUT CP100T08. */
            CP100T08.Open(REG_CP100T08, AREA_DE_WORK.WSTAT08);

            /*" -1556- IF WSTAT08 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT08 != 00)
            {

                /*" -1557- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T08' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T08");

                /*" -1558- DISPLAY 'STATUS  - ' WSTAT08 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT08}");

                /*" -1559- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1560- END-IF. */
            }


            /*" -1561- OPEN OUTPUT CP100T09. */
            CP100T09.Open(REG_CP100T09, AREA_DE_WORK.WSTAT09);

            /*" -1562- IF WSTAT09 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT09 != 00)
            {

                /*" -1563- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T09' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T09");

                /*" -1564- DISPLAY 'STATUS  - ' WSTAT09 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT09}");

                /*" -1565- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1566- END-IF. */
            }


            /*" -1567- OPEN OUTPUT CP100T10. */
            CP100T10.Open(REG_CP100T10, AREA_DE_WORK.WSTAT10);

            /*" -1568- IF WSTAT10 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT10 != 00)
            {

                /*" -1569- DISPLAY 'R0000 - ERRO NO OPEN DO ARQUIVO CP100T10' */
                _.Display($"R0000 - ERRO NO OPEN DO ARQUIVO CP100T10");

                /*" -1570- DISPLAY 'STATUS  - ' WSTAT10 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT10}");

                /*" -1571- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1574- END-IF. */
            }


            /*" -1583- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -1586- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1587- DISPLAY 'R0000 - ERRO NO SELECT GE_PROCESSA_SUB_SISTEMA' */
                _.Display($"R0000 - ERRO NO SELECT GE_PROCESSA_SUB_SISTEMA");

                /*" -1588- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1590- END-IF. */
            }


            /*" -1592- MOVE GE501-DTA-MOV-ABERTO TO WS-DTA-MOV-ABERTO. */
            _.Move(GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_MOV_ABERTO, AREA_DE_WORK.WS_DTA_MOV_ABERTO);

            /*" -1593- MOVE WS-DIA-MOV TO WDAT-DIA-EDT. */
            _.Move(AREA_DE_WORK.FILLER_0.WS_DIA_MOV, AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

            /*" -1594- MOVE WS-MES-MOV TO WDAT-MES-EDT. */
            _.Move(AREA_DE_WORK.FILLER_0.WS_MES_MOV, AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

            /*" -1595- MOVE WS-ANO-MOV TO WDAT-ANO-EDT. */
            _.Move(AREA_DE_WORK.FILLER_0.WS_ANO_MOV, AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

            /*" -1597- MOVE WDATA-EDIT TO LCTIT-DATA. */
            _.Move(AREA_DE_WORK.WDATA_EDIT, WS_ARQUIVO.LCTIT.LCTIT_DATA);

            /*" -1598- DISPLAY 'DTA-MOV-ABERTO     = ' GE501-DTA-MOV-ABERTO. */
            _.Display($"DTA-MOV-ABERTO     = {GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_MOV_ABERTO}");

            /*" -1600- DISPLAY 'DTA-ULT-MOV-ABERTO = ' GE501-DTA-ULT-MOV-ABERTO. */
            _.Display($"DTA-ULT-MOV-ABERTO = {GE501.DCLGE_PROCESSA_SUB_SISTEMA.GE501_DTA_ULT_MOV_ABERTO}");

            /*" -1602- PERFORM R0000_00_PRINCIPAL_DB_SET_1 */

            R0000_00_PRINCIPAL_DB_SET_1();

            /*" -1605- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1606- DISPLAY 'R0000 - ERRO NO SET CURRENT TIMESTAMP' */
                _.Display($"R0000 - ERRO NO SET CURRENT TIMESTAMP");

                /*" -1607- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1609- END-IF. */
            }


            /*" -1618- STRING WS-TIMESTAMP(09:02) '/' WS-TIMESTAMP(06:02) '/' WS-TIMESTAMP(01:04) ' ' WS-TIMESTAMP(12:02) ':' WS-TIMESTAMP(15:02) ':' WS-TIMESTAMP(18:02) DELIMITED BY SIZE INTO LCTIT-TIMESTAMP. */
            #region STRING
            var spl1 = AREA_DE_WORK.WS_TIMESTAMP.Substring(09, 02).GetMoveValues();
            spl1 += "/";
            var spl2 = AREA_DE_WORK.WS_TIMESTAMP.Substring(06, 02).GetMoveValues();
            spl2 += "/";
            var spl3 = AREA_DE_WORK.WS_TIMESTAMP.Substring(01, 04).GetMoveValues();
            spl3 += " ";
            var spl4 = AREA_DE_WORK.WS_TIMESTAMP.Substring(12, 02).GetMoveValues();
            spl4 += ":";
            var spl5 = AREA_DE_WORK.WS_TIMESTAMP.Substring(15, 02).GetMoveValues();
            spl5 += ":";
            var spl6 = AREA_DE_WORK.WS_TIMESTAMP.Substring(18, 02).GetMoveValues();
            var results7 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6;
            _.Move(results7, WS_ARQUIVO.LCTIT.LCTIT_TIMESTAMP);
            #endregion

            /*" -1620- PERFORM R0010-00-TRATA-CURSOR01. */

            R0010_00_TRATA_CURSOR01_SECTION();

            /*" -1625- DISPLAY 'CURSOR01 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR01 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1627- PERFORM R0020-00-TRATA-CURSOR02. */

            R0020_00_TRATA_CURSOR02_SECTION();

            /*" -1632- DISPLAY 'CURSOR02 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR02 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1634- PERFORM R0040-00-TRATA-CURSOR04. */

            R0040_00_TRATA_CURSOR04_SECTION();

            /*" -1639- DISPLAY 'CURSOR04 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR04 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1641- PERFORM R0050-00-TRATA-CURSOR05. */

            R0050_00_TRATA_CURSOR05_SECTION();

            /*" -1646- DISPLAY 'CURSOR05 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR05 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1648- PERFORM R0060-00-TRATA-CURSOR06. */

            R0060_00_TRATA_CURSOR06_SECTION();

            /*" -1653- DISPLAY 'CURSOR06 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR06 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1655- PERFORM R0080-00-TRATA-CURSOR08. */

            R0080_00_TRATA_CURSOR08_SECTION();

            /*" -1660- DISPLAY 'CURSOR08 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR08 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1662- PERFORM R0090-00-TRATA-CURSOR09. */

            R0090_00_TRATA_CURSOR09_SECTION();

            /*" -1667- DISPLAY 'CURSOR09 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR09 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1669- PERFORM R0100-00-TRATA-CURSOR10. */

            R0100_00_TRATA_CURSOR10_SECTION();

            /*" -1674- DISPLAY 'CURSOR10 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR10 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1676- PERFORM R0110-00-TRATA-CURSOR11. */

            R0110_00_TRATA_CURSOR11_SECTION();

            /*" -1681- DISPLAY 'CURSOR11 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"CURSOR11 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1683- PERFORM R0120-00-TRATA-CURSOR12. */

            R0120_00_TRATA_CURSOR12_SECTION();

            /*" -1686- DISPLAY 'CURSOR12 - FIM PROCESS. EM: ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"CURSOR12 - FIM PROCESS. EM: {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -1583- EXEC SQL SELECT DTA_MOV_ABERTO, DTA_ULT_MOV_ABERTO INTO :GE501-DTA-MOV-ABERTO, :GE501-DTA-ULT-MOV-ABERTO FROM SIUS.GE_PROCESSA_SUB_SISTEMA WHERE COD_IDE_SISTEMA = 'GE' AND COD_SUB_SISTEMA = 'CP' WITH UR END-EXEC. */

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
        /*" R0000-00-PRINCIPAL-DB-SET-1 */
        public void R0000_00_PRINCIPAL_DB_SET_1()
        {
            /*" -1602- EXEC SQL SET :WS-TIMESTAMP = CURRENT TIMESTAMP END-EXEC. */
            _.Move(_.CurrentDate(), AREA_DE_WORK.WS_TIMESTAMP);

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -1692- CLOSE CPB100S1. */
            CPB100S1.Close();

            /*" -1693- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -1694- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CPB100S1' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CPB100S1");

                /*" -1695- DISPLAY 'STATUS  - ' WSTATUS */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTATUS}");

                /*" -1696- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1698- END-IF. */
            }


            /*" -1699- CLOSE CP100T01. */
            CP100T01.Close();

            /*" -1700- IF WSTAT01 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT01 != 00)
            {

                /*" -1701- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T01' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T01");

                /*" -1702- DISPLAY 'STATUS  - ' WSTAT01 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT01}");

                /*" -1703- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1704- END-IF. */
            }


            /*" -1705- CLOSE CP100T02. */
            CP100T02.Close();

            /*" -1706- IF WSTAT02 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT02 != 00)
            {

                /*" -1707- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T02' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T02");

                /*" -1708- DISPLAY 'STATUS  - ' WSTAT02 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT02}");

                /*" -1709- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1710- END-IF. */
            }


            /*" -1711- CLOSE CP100T03. */
            CP100T03.Close();

            /*" -1712- IF WSTAT03 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT03 != 00)
            {

                /*" -1713- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T03' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T03");

                /*" -1714- DISPLAY 'STATUS  - ' WSTAT03 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT03}");

                /*" -1715- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1716- END-IF. */
            }


            /*" -1717- CLOSE CP100T04. */
            CP100T04.Close();

            /*" -1718- IF WSTAT04 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT04 != 00)
            {

                /*" -1719- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T04' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T04");

                /*" -1720- DISPLAY 'STATUS  - ' WSTAT04 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT04}");

                /*" -1721- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1722- END-IF. */
            }


            /*" -1723- CLOSE CP100T05. */
            CP100T05.Close();

            /*" -1724- IF WSTAT05 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT05 != 00)
            {

                /*" -1725- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T05' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T05");

                /*" -1726- DISPLAY 'STATUS  - ' WSTAT05 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT05}");

                /*" -1727- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1728- END-IF. */
            }


            /*" -1729- CLOSE CP100T67. */
            CP100T67.Close();

            /*" -1730- IF WSTAT67 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT67 != 00)
            {

                /*" -1731- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T67' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T67");

                /*" -1732- DISPLAY 'STATUS  - ' WSTAT67 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT67}");

                /*" -1733- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1734- END-IF. */
            }


            /*" -1735- CLOSE CP100T08. */
            CP100T08.Close();

            /*" -1736- IF WSTAT08 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT08 != 00)
            {

                /*" -1737- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T08' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T08");

                /*" -1738- DISPLAY 'STATUS  - ' WSTAT08 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT08}");

                /*" -1739- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1740- END-IF. */
            }


            /*" -1741- CLOSE CP100T09. */
            CP100T09.Close();

            /*" -1742- IF WSTAT09 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT09 != 00)
            {

                /*" -1743- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T09' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T09");

                /*" -1744- DISPLAY 'STATUS  - ' WSTAT09 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT09}");

                /*" -1745- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1746- END-IF. */
            }


            /*" -1747- CLOSE CP100T10. */
            CP100T10.Close();

            /*" -1748- IF WSTAT10 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTAT10 != 00)
            {

                /*" -1749- DISPLAY 'R0000 - ERRO NO CLOSE DO ARQUIVO CP100T10' */
                _.Display($"R0000 - ERRO NO CLOSE DO ARQUIVO CP100T10");

                /*" -1750- DISPLAY 'STATUS  - ' WSTAT10 */
                _.Display($"STATUS  - {AREA_DE_WORK.WSTAT10}");

                /*" -1751- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1753- END-IF. */
            }


            /*" -1754- DISPLAY 'QTDE. DE REGISTROS     ' . */
            _.Display($"QTDE. DE REGISTROS     ");

            /*" -1755- DISPLAY 'LIDOS CURSOR C01   -   ' AC-L-C01. */
            _.Display($"LIDOS CURSOR C01   -   {AREA_DE_WORK.AC_L_C01}");

            /*" -1756- DISPLAY 'LIDOS CURSOR C02   -   ' AC-L-C02. */
            _.Display($"LIDOS CURSOR C02   -   {AREA_DE_WORK.AC_L_C02}");

            /*" -1757- DISPLAY 'LIDOS CURSOR C04   -   ' AC-L-C04. */
            _.Display($"LIDOS CURSOR C04   -   {AREA_DE_WORK.AC_L_C04}");

            /*" -1758- DISPLAY 'LIDOS CURSOR C05   -   ' AC-L-C05. */
            _.Display($"LIDOS CURSOR C05   -   {AREA_DE_WORK.AC_L_C05}");

            /*" -1759- DISPLAY 'LIDOS CURSOR C06   -   ' AC-L-C06. */
            _.Display($"LIDOS CURSOR C06   -   {AREA_DE_WORK.AC_L_C06}");

            /*" -1760- DISPLAY 'LIDOS CURSOR C08   -   ' AC-L-C08. */
            _.Display($"LIDOS CURSOR C08   -   {AREA_DE_WORK.AC_L_C08}");

            /*" -1761- DISPLAY 'LIDOS CURSOR C09   -   ' AC-L-C09. */
            _.Display($"LIDOS CURSOR C09   -   {AREA_DE_WORK.AC_L_C09}");

            /*" -1762- DISPLAY 'LIDOS CURSOR C10   -   ' AC-L-C10. */
            _.Display($"LIDOS CURSOR C10   -   {AREA_DE_WORK.AC_L_C10}");

            /*" -1763- DISPLAY 'LIDOS CURSOR C11   -   ' AC-L-C11. */
            _.Display($"LIDOS CURSOR C11   -   {AREA_DE_WORK.AC_L_C11}");

            /*" -1764- DISPLAY 'LIDOS CURSOR C12   -   ' AC-L-C12. */
            _.Display($"LIDOS CURSOR C12   -   {AREA_DE_WORK.AC_L_C12}");

            /*" -1766- DISPLAY 'GRAVD NO CPB100S1  -   ' AC-G-CPB100S1. */
            _.Display($"GRAVD NO CPB100S1  -   {AREA_DE_WORK.AC_G_CPB100S1}");

            /*" -1774- DISPLAY 'GECPB100 - FINAL DE PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"GECPB100 - FINAL DE PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -1775- DISPLAY '   ' . */
            _.Display($"   ");

            /*" -1777- DISPLAY '*--- GECPB100  -  FIM  NORMAL ---*' . */
            _.Display($"*--- GECPB100  -  FIM  NORMAL ---*");

            /*" -1779- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1779- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-TRATA-CURSOR01-SECTION */
        private void R0010_00_TRATA_CURSOR01_SECTION()
        {
            /*" -1791- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WABEND.WNR_EXEC_SQL);

            /*" -1793- PERFORM R0010_00_TRATA_CURSOR01_DB_OPEN_1 */

            R0010_00_TRATA_CURSOR01_DB_OPEN_1();

            /*" -1796- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1797- DISPLAY 'R0010 - ERRO NO OPEN DO CURSOR C01' */
                _.Display($"R0010 - ERRO NO OPEN DO CURSOR C01");

                /*" -1798- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1800- END-IF. */
            }


            /*" -1802- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -1804- PERFORM R0016-00-GRAVA-LC-C01. */

            R0016_00_GRAVA_LC_C01_SECTION();

            /*" -1806- PERFORM R0015-00-FETCH-C01. */

            R0015_00_FETCH_C01_SECTION();

            /*" -1807- PERFORM UNTIL WFIM-C01 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C01 == "S"))
            {

                /*" -1808- MOVE GE536-COD-EMPRESA TO LDC01-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC01.LDC01_COD_EMPRESA);

                /*" -1809- MOVE GE538-DES-EMPRESA TO LDC01-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC01.LDC01_DES_EMPRESA);

                /*" -1810- MOVE GE537-COD-ORIGEM TO LDC01-COD-ORIGEM */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM, WS_ARQUIVO.LDC01.LDC01_COD_ORIGEM);

                /*" -1811- MOVE GE538-DES-ORIGEM TO LDC01-DES-ORIGEM */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM, WS_ARQUIVO.LDC01.LDC01_DES_ORIGEM);

                /*" -1812- MOVE GE537-DTA-MOVIMENTO TO LDC01-DTA-MOV */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO, WS_ARQUIVO.LDC01.LDC01_DTA_MOV);

                /*" -1813- MOVE C01-COD-TIPO-OCOR TO LDC01-TIP-MOV */
                _.Move(AREA_DE_WORK.C01_COD_TIPO_OCOR, WS_ARQUIVO.LDC01.LDC01_TIP_MOV);

                /*" -1814- MOVE C01-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C01_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -1815- MOVE GDA-QTD TO LDC01-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC01.LDC01_QTD);

                /*" -1816- WRITE REG-CPB100S1 FROM LDC01 */
                _.Move(WS_ARQUIVO.LDC01.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -1817- WRITE REG-CP100T01 FROM LDC01 */
                _.Move(WS_ARQUIVO.LDC01.GetMoveValues(), REG_CP100T01);

                CP100T01.Write(REG_CP100T01.GetMoveValues().ToString());

                /*" -1818- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -1819- PERFORM R0015-00-FETCH-C01 */

                R0015_00_FETCH_C01_SECTION();

                /*" -1821- END-PERFORM. */
            }

            /*" -1822- IF AC-L-C01 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C01 == 00)
            {

                /*" -1823- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -1824- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -1825- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -1825- END-IF. */
            }


        }

        [StopWatch]
        /*" R0010-00-TRATA-CURSOR01-DB-OPEN-1 */
        public void R0010_00_TRATA_CURSOR01_DB_OPEN_1()
        {
            /*" -1793- EXEC SQL OPEN C01 END-EXEC. */

            C01.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0015-00-FETCH-C01-SECTION */
        private void R0015_00_FETCH_C01_SECTION()
        {
            /*" -1837- MOVE '0015' TO WNR-EXEC-SQL. */
            _.Move("0015", WABEND.WNR_EXEC_SQL);

            /*" -1845- PERFORM R0015_00_FETCH_C01_DB_FETCH_1 */

            R0015_00_FETCH_C01_DB_FETCH_1();

            /*" -1848- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1849- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1850- MOVE 'S' TO WFIM-C01 */
                    _.Move("S", AREA_DE_WORK.WFIM_C01);

                    /*" -1850- PERFORM R0015_00_FETCH_C01_DB_CLOSE_1 */

                    R0015_00_FETCH_C01_DB_CLOSE_1();

                    /*" -1852- GO TO R0015-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/ //GOTO
                    return;

                    /*" -1853- ELSE */
                }
                else
                {


                    /*" -1854- DISPLAY 'R0015 - ERRO NO FETCH DO CURSOR01' */
                    _.Display($"R0015 - ERRO NO FETCH DO CURSOR01");

                    /*" -1855- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1856- END-IF */
                }


                /*" -1857- ELSE */
            }
            else
            {


                /*" -1858- ADD 1 TO AC-L-C01 */
                AREA_DE_WORK.AC_L_C01.Value = AREA_DE_WORK.AC_L_C01 + 1;

                /*" -1860- END-IF. */
            }


            /*" -1861- IF VIND-COD-ORIGEM EQUAL -1 */

            if (AREA_DE_WORK.VIND_COD_ORIGEM == -1)
            {

                /*" -1862- MOVE SPACES TO GE537-COD-ORIGEM */
                _.Move("", GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);

                /*" -1862- END-IF. */
            }


        }

        [StopWatch]
        /*" R0015-00-FETCH-C01-DB-FETCH-1 */
        public void R0015_00_FETCH_C01_DB_FETCH_1()
        {
            /*" -1845- EXEC SQL FETCH C01 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE537-COD-ORIGEM :VIND-COD-ORIGEM ,:GE538-DES-ORIGEM ,:GE537-DTA-MOVIMENTO ,:C01-COD-TIPO-OCOR ,:C01-QTD END-EXEC. */

            if (C01.Fetch())
            {
                _.Move(C01.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C01.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C01.GE537_COD_ORIGEM, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);
                _.Move(C01.VIND_COD_ORIGEM, AREA_DE_WORK.VIND_COD_ORIGEM);
                _.Move(C01.GE538_DES_ORIGEM, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM);
                _.Move(C01.GE537_DTA_MOVIMENTO, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO);
                _.Move(C01.C01_COD_TIPO_OCOR, AREA_DE_WORK.C01_COD_TIPO_OCOR);
                _.Move(C01.C01_QTD, AREA_DE_WORK.C01_QTD);
            }

        }

        [StopWatch]
        /*" R0015-00-FETCH-C01-DB-CLOSE-1 */
        public void R0015_00_FETCH_C01_DB_CLOSE_1()
        {
            /*" -1850- EXEC SQL CLOSE C01 END-EXEC */

            C01.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0015_99_SAIDA*/

        [StopWatch]
        /*" R0016-00-GRAVA-LC-C01-SECTION */
        private void R0016_00_GRAVA_LC_C01_SECTION()
        {
            /*" -1874- MOVE '0016' TO WNR-EXEC-SQL. */
            _.Move("0016", WABEND.WNR_EXEC_SQL);

            /*" -1875- WRITE REG-CPB100S1 FROM LC1-C01. */
            _.Move(WS_ARQUIVO.LC1_C01.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1876- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1877- WRITE REG-CPB100S1 FROM LC2-C01. */
            _.Move(WS_ARQUIVO.LC2_C01.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1878- WRITE REG-CP100T01 FROM LC2-C01. */
            _.Move(WS_ARQUIVO.LC2_C01.GetMoveValues(), REG_CP100T01);

            CP100T01.Write(REG_CP100T01.GetMoveValues().ToString());

            /*" -1879- WRITE REG-CPB100S1 FROM LC3-C01. */
            _.Move(WS_ARQUIVO.LC3_C01.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1879- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0016_99_SAIDA*/

        [StopWatch]
        /*" R0020-00-TRATA-CURSOR02-SECTION */
        private void R0020_00_TRATA_CURSOR02_SECTION()
        {
            /*" -1891- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", WABEND.WNR_EXEC_SQL);

            /*" -1893- PERFORM R0020_00_TRATA_CURSOR02_DB_OPEN_1 */

            R0020_00_TRATA_CURSOR02_DB_OPEN_1();

            /*" -1896- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1897- DISPLAY 'R0020 - ERRO NO OPEN DO CURSOR C02' */
                _.Display($"R0020 - ERRO NO OPEN DO CURSOR C02");

                /*" -1898- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1900- END-IF. */
            }


            /*" -1902- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -1904- PERFORM R0026-00-GRAVA-LC-C02. */

            R0026_00_GRAVA_LC_C02_SECTION();

            /*" -1906- PERFORM R0025-00-FETCH-C02. */

            R0025_00_FETCH_C02_SECTION();

            /*" -1907- PERFORM UNTIL WFIM-C02 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C02 == "S"))
            {

                /*" -1908- MOVE GE540-COD-EMPRESA TO LDC02-COD-EMPRESA */
                _.Move(GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_COD_EMPRESA, WS_ARQUIVO.LDC02.LDC02_COD_EMPRESA);

                /*" -1909- MOVE GE538-DES-EMPRESA TO LDC02-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC02.LDC02_DES_EMPRESA);

                /*" -1910- MOVE GE537-NUM-IDLG TO GDA-NUM-IDLG */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG, AREA_DE_WORK.GDA_NUM_IDLG);

                /*" -1911- MOVE GDA-NUM-IDLG TO LDC02-IDLG-MCP */
                _.Move(AREA_DE_WORK.GDA_NUM_IDLG, WS_ARQUIVO.LDC02.LDC02_IDLG_MCP);

                /*" -1912- MOVE GE540-COD-ID-PAGAM-COBR TO LDC02-IDLG-SAP */
                _.Move(GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_COD_ID_PAGAM_COBR, WS_ARQUIVO.LDC02.LDC02_IDLG_SAP);

                /*" -1913- MOVE GE540-NUM-NSA-SAP TO GDA-NUM-NSA-SAP */
                _.Move(GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_NUM_NSA_SAP, AREA_DE_WORK.GDA_NUM_NSA_SAP);

                /*" -1914- MOVE GDA-NUM-NSA-SAP TO LDC02-NUM-NSA-SAP */
                _.Move(AREA_DE_WORK.GDA_NUM_NSA_SAP, WS_ARQUIVO.LDC02.LDC02_NUM_NSA_SAP);

                /*" -1915- MOVE GE540-SEQ-REGISTRO TO GDA-SEQ-REGISTRO */
                _.Move(GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_SEQ_REGISTRO, AREA_DE_WORK.GDA_SEQ_REGISTRO);

                /*" -1916- MOVE GDA-SEQ-REGISTRO TO LDC02-SEQ-REGISTRO */
                _.Move(AREA_DE_WORK.GDA_SEQ_REGISTRO, WS_ARQUIVO.LDC02.LDC02_SEQ_REGISTRO);

                /*" -1917- MOVE GE541-DTA-GERACAO-ARQ TO LDC02-DTA-ARQUIVO */
                _.Move(GE541.DCLGE_CONTROL_ARQ_H_SAP.GE541_DTA_GERACAO_ARQ, WS_ARQUIVO.LDC02.LDC02_DTA_ARQUIVO);

                /*" -1918- MOVE C02-STA-CONSUMO TO LDC02-STA-CONSUMO */
                _.Move(AREA_DE_WORK.C02_STA_CONSUMO, WS_ARQUIVO.LDC02.LDC02_STA_CONSUMO);

                /*" -1919- MOVE GE577-COD-RETORNO-ARQ-H TO LDC02-COD-RET-ARQ-H */
                _.Move(GE577.DCLGE_DET_ARQ_H_RETORNO_SAP.GE577_COD_RETORNO_ARQ_H, WS_ARQUIVO.LDC02.LDC02_COD_RET_ARQ_H);

                /*" -1920- MOVE GE576-DES-RETORNO-ARQ-H TO DES-RETORNO */
                _.Move(GE576.DCLGE_RETORNO_ARQ_H_SAP.GE576_DES_RETORNO_ARQ_H, DES_RETORNO);

                /*" -1921- MOVE ARQ-H-TEXT(1:ARQ-H-LEN) TO LDC02-DES-RETORNO-ARQ-H */
                _.Move(DES_RETORNO.ARQ_H_TEXT.Substring(1, DES_RETORNO.ARQ_H_LEN), WS_ARQUIVO.LDC02.LDC02_DES_RETORNO_ARQ_H);

                /*" -1922- MOVE C02-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C02_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -1923- MOVE GDA-QTD TO LDC02-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC02.LDC02_QTD);

                /*" -1924- WRITE REG-CPB100S1 FROM LDC02 */
                _.Move(WS_ARQUIVO.LDC02.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -1925- WRITE REG-CP100T02 FROM LDC02 */
                _.Move(WS_ARQUIVO.LDC02.GetMoveValues(), REG_CP100T02);

                CP100T02.Write(REG_CP100T02.GetMoveValues().ToString());

                /*" -1926- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -1927- PERFORM R0025-00-FETCH-C02 */

                R0025_00_FETCH_C02_SECTION();

                /*" -1929- END-PERFORM. */
            }

            /*" -1930- IF AC-L-C02 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C02 == 00)
            {

                /*" -1931- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -1932- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -1933- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -1933- END-IF. */
            }


        }

        [StopWatch]
        /*" R0020-00-TRATA-CURSOR02-DB-OPEN-1 */
        public void R0020_00_TRATA_CURSOR02_DB_OPEN_1()
        {
            /*" -1893- EXEC SQL OPEN C02 END-EXEC. */

            C02.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0025-00-FETCH-C02-SECTION */
        private void R0025_00_FETCH_C02_SECTION()
        {
            /*" -1945- MOVE '0025' TO WNR-EXEC-SQL. */
            _.Move("0025", WABEND.WNR_EXEC_SQL);

            /*" -1957- PERFORM R0025_00_FETCH_C02_DB_FETCH_1 */

            R0025_00_FETCH_C02_DB_FETCH_1();

            /*" -1960- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1961- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1962- MOVE 'S' TO WFIM-C02 */
                    _.Move("S", AREA_DE_WORK.WFIM_C02);

                    /*" -1962- PERFORM R0025_00_FETCH_C02_DB_CLOSE_1 */

                    R0025_00_FETCH_C02_DB_CLOSE_1();

                    /*" -1964- GO TO R0025-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0025_99_SAIDA*/ //GOTO
                    return;

                    /*" -1965- ELSE */
                }
                else
                {


                    /*" -1966- DISPLAY 'R0025 - ERRO NO FETCH DO CURSOR02' */
                    _.Display($"R0025 - ERRO NO FETCH DO CURSOR02");

                    /*" -1967- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1968- END-IF */
                }


                /*" -1969- ELSE */
            }
            else
            {


                /*" -1970- ADD 1 TO AC-L-C02 */
                AREA_DE_WORK.AC_L_C02.Value = AREA_DE_WORK.AC_L_C02 + 1;

                /*" -1972- END-IF. */
            }


            /*" -1973- IF VIND-NUM-IDLG EQUAL -1 */

            if (AREA_DE_WORK.VIND_NUM_IDLG == -1)
            {

                /*" -1974- MOVE ZEROS TO GE537-NUM-IDLG */
                _.Move(0, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG);

                /*" -1974- END-IF. */
            }


        }

        [StopWatch]
        /*" R0025-00-FETCH-C02-DB-FETCH-1 */
        public void R0025_00_FETCH_C02_DB_FETCH_1()
        {
            /*" -1957- EXEC SQL FETCH C02 INTO :GE540-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE537-NUM-IDLG :VIND-NUM-IDLG ,:GE540-COD-ID-PAGAM-COBR ,:GE540-NUM-NSA-SAP ,:GE540-SEQ-REGISTRO ,:GE541-DTA-GERACAO-ARQ ,:C02-STA-CONSUMO ,:GE577-COD-RETORNO-ARQ-H ,:GE576-DES-RETORNO-ARQ-H ,:C02-QTD END-EXEC. */

            if (C02.Fetch())
            {
                _.Move(C02.GE540_COD_EMPRESA, GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_COD_EMPRESA);
                _.Move(C02.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C02.GE537_NUM_IDLG, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NUM_IDLG);
                _.Move(C02.VIND_NUM_IDLG, AREA_DE_WORK.VIND_NUM_IDLG);
                _.Move(C02.GE540_COD_ID_PAGAM_COBR, GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_COD_ID_PAGAM_COBR);
                _.Move(C02.GE540_NUM_NSA_SAP, GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_NUM_NSA_SAP);
                _.Move(C02.GE540_SEQ_REGISTRO, GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_SEQ_REGISTRO);
                _.Move(C02.GE541_DTA_GERACAO_ARQ, GE541.DCLGE_CONTROL_ARQ_H_SAP.GE541_DTA_GERACAO_ARQ);
                _.Move(C02.C02_STA_CONSUMO, AREA_DE_WORK.C02_STA_CONSUMO);
                _.Move(C02.GE577_COD_RETORNO_ARQ_H, GE577.DCLGE_DET_ARQ_H_RETORNO_SAP.GE577_COD_RETORNO_ARQ_H);
                _.Move(C02.GE576_DES_RETORNO_ARQ_H, GE576.DCLGE_RETORNO_ARQ_H_SAP.GE576_DES_RETORNO_ARQ_H);
                _.Move(C02.C02_QTD, AREA_DE_WORK.C02_QTD);
            }

        }

        [StopWatch]
        /*" R0025-00-FETCH-C02-DB-CLOSE-1 */
        public void R0025_00_FETCH_C02_DB_CLOSE_1()
        {
            /*" -1962- EXEC SQL CLOSE C02 END-EXEC */

            C02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0025_99_SAIDA*/

        [StopWatch]
        /*" R0026-00-GRAVA-LC-C02-SECTION */
        private void R0026_00_GRAVA_LC_C02_SECTION()
        {
            /*" -1986- MOVE '0026' TO WNR-EXEC-SQL. */
            _.Move("0026", WABEND.WNR_EXEC_SQL);

            /*" -1987- WRITE REG-CPB100S1 FROM LC1-C02. */
            _.Move(WS_ARQUIVO.LC1_C02.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1988- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1989- WRITE REG-CPB100S1 FROM LC2-C02. */
            _.Move(WS_ARQUIVO.LC2_C02.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1990- WRITE REG-CP100T02 FROM LC2-C02. */
            _.Move(WS_ARQUIVO.LC2_C02.GetMoveValues(), REG_CP100T02);

            CP100T02.Write(REG_CP100T02.GetMoveValues().ToString());

            /*" -1992- WRITE REG-CPB100S1 FROM LC3-C02. */
            _.Move(WS_ARQUIVO.LC3_C02.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -1992- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0026_99_SAIDA*/

        [StopWatch]
        /*" R0040-00-TRATA-CURSOR04-SECTION */
        private void R0040_00_TRATA_CURSOR04_SECTION()
        {
            /*" -2004- MOVE '0040' TO WNR-EXEC-SQL. */
            _.Move("0040", WABEND.WNR_EXEC_SQL);

            /*" -2006- PERFORM R0040_00_TRATA_CURSOR04_DB_OPEN_1 */

            R0040_00_TRATA_CURSOR04_DB_OPEN_1();

            /*" -2009- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2010- DISPLAY 'R0040 - ERRO NO OPEN DO CURSOR C04' */
                _.Display($"R0040 - ERRO NO OPEN DO CURSOR C04");

                /*" -2011- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2013- END-IF. */
            }


            /*" -2015- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2017- PERFORM R0046-00-GRAVA-LC-C04. */

            R0046_00_GRAVA_LC_C04_SECTION();

            /*" -2019- PERFORM R0045-00-FETCH-C04. */

            R0045_00_FETCH_C04_SECTION();

            /*" -2020- PERFORM UNTIL WFIM-C04 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C04 == "S"))
            {

                /*" -2021- MOVE GE536-COD-EMPRESA TO LDC04-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC04.LDC04_COD_EMPRESA);

                /*" -2022- MOVE GE538-DES-EMPRESA TO LDC04-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC04.LDC04_DES_EMPRESA);

                /*" -2023- MOVE GE537-DTA-MOVIMENTO TO LDC04-DTA-MOV */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO, WS_ARQUIVO.LDC04.LDC04_DTA_MOV);

                /*" -2024- MOVE GE537-COD-ORIGEM TO LDC04-COD-ORIGEM */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM, WS_ARQUIVO.LDC04.LDC04_COD_ORIGEM);

                /*" -2025- MOVE GE538-DES-ORIGEM TO LDC04-DES-ORIGEM */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM, WS_ARQUIVO.LDC04.LDC04_DES_ORIGEM);

                /*" -2026- MOVE GE537-NOM-PROGRAMA TO LDC04-NOM-PROGRAMA */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NOM_PROGRAMA, WS_ARQUIVO.LDC04.LDC04_NOM_PROGRAMA);

                /*" -2027- MOVE C04-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C04_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -2028- MOVE GDA-QTD TO LDC04-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC04.LDC04_QTD);

                /*" -2029- WRITE REG-CPB100S1 FROM LDC04 */
                _.Move(WS_ARQUIVO.LDC04.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2030- WRITE REG-CP100T03 FROM LDC04 */
                _.Move(WS_ARQUIVO.LDC04.GetMoveValues(), REG_CP100T03);

                CP100T03.Write(REG_CP100T03.GetMoveValues().ToString());

                /*" -2031- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2032- PERFORM R0045-00-FETCH-C04 */

                R0045_00_FETCH_C04_SECTION();

                /*" -2034- END-PERFORM. */
            }

            /*" -2035- IF AC-L-C04 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C04 == 00)
            {

                /*" -2036- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2037- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2038- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2038- END-IF. */
            }


        }

        [StopWatch]
        /*" R0040-00-TRATA-CURSOR04-DB-OPEN-1 */
        public void R0040_00_TRATA_CURSOR04_DB_OPEN_1()
        {
            /*" -2006- EXEC SQL OPEN C04 END-EXEC. */

            C04.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_99_SAIDA*/

        [StopWatch]
        /*" R0045-00-FETCH-C04-SECTION */
        private void R0045_00_FETCH_C04_SECTION()
        {
            /*" -2050- MOVE '0045' TO WNR-EXEC-SQL. */
            _.Move("0045", WABEND.WNR_EXEC_SQL);

            /*" -2058- PERFORM R0045_00_FETCH_C04_DB_FETCH_1 */

            R0045_00_FETCH_C04_DB_FETCH_1();

            /*" -2061- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2062- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2063- MOVE 'S' TO WFIM-C04 */
                    _.Move("S", AREA_DE_WORK.WFIM_C04);

                    /*" -2063- PERFORM R0045_00_FETCH_C04_DB_CLOSE_1 */

                    R0045_00_FETCH_C04_DB_CLOSE_1();

                    /*" -2065- GO TO R0045-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0045_99_SAIDA*/ //GOTO
                    return;

                    /*" -2066- ELSE */
                }
                else
                {


                    /*" -2067- DISPLAY 'R0045 - ERRO NO FETCH DO CURSOR04' */
                    _.Display($"R0045 - ERRO NO FETCH DO CURSOR04");

                    /*" -2068- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2069- END-IF */
                }


                /*" -2070- ELSE */
            }
            else
            {


                /*" -2071- ADD 1 TO AC-L-C04 */
                AREA_DE_WORK.AC_L_C04.Value = AREA_DE_WORK.AC_L_C04 + 1;

                /*" -2073- END-IF. */
            }


            /*" -2074- IF VIND-COD-ORIGEM EQUAL -1 */

            if (AREA_DE_WORK.VIND_COD_ORIGEM == -1)
            {

                /*" -2075- MOVE SPACES TO GE537-COD-ORIGEM */
                _.Move("", GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);

                /*" -2075- END-IF. */
            }


        }

        [StopWatch]
        /*" R0045-00-FETCH-C04-DB-FETCH-1 */
        public void R0045_00_FETCH_C04_DB_FETCH_1()
        {
            /*" -2058- EXEC SQL FETCH C04 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE537-DTA-MOVIMENTO ,:GE537-COD-ORIGEM :VIND-COD-ORIGEM ,:GE538-DES-ORIGEM ,:GE537-NOM-PROGRAMA ,:C04-QTD END-EXEC. */

            if (C04.Fetch())
            {
                _.Move(C04.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C04.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C04.GE537_DTA_MOVIMENTO, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO);
                _.Move(C04.GE537_COD_ORIGEM, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);
                _.Move(C04.VIND_COD_ORIGEM, AREA_DE_WORK.VIND_COD_ORIGEM);
                _.Move(C04.GE538_DES_ORIGEM, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM);
                _.Move(C04.GE537_NOM_PROGRAMA, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_NOM_PROGRAMA);
                _.Move(C04.C04_QTD, AREA_DE_WORK.C04_QTD);
            }

        }

        [StopWatch]
        /*" R0045-00-FETCH-C04-DB-CLOSE-1 */
        public void R0045_00_FETCH_C04_DB_CLOSE_1()
        {
            /*" -2063- EXEC SQL CLOSE C04 END-EXEC */

            C04.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0045_99_SAIDA*/

        [StopWatch]
        /*" R0046-00-GRAVA-LC-C04-SECTION */
        private void R0046_00_GRAVA_LC_C04_SECTION()
        {
            /*" -2087- MOVE '0046' TO WNR-EXEC-SQL. */
            _.Move("0046", WABEND.WNR_EXEC_SQL);

            /*" -2088- WRITE REG-CPB100S1 FROM LC1-C04. */
            _.Move(WS_ARQUIVO.LC1_C04.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2089- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2090- WRITE REG-CPB100S1 FROM LC2-C04. */
            _.Move(WS_ARQUIVO.LC2_C04.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2091- WRITE REG-CP100T03 FROM LC2-C04. */
            _.Move(WS_ARQUIVO.LC2_C04.GetMoveValues(), REG_CP100T03);

            CP100T03.Write(REG_CP100T03.GetMoveValues().ToString());

            /*" -2093- WRITE REG-CPB100S1 FROM LC3-C04. */
            _.Move(WS_ARQUIVO.LC3_C04.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2093- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0046_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-TRATA-CURSOR05-SECTION */
        private void R0050_00_TRATA_CURSOR05_SECTION()
        {
            /*" -2105- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WABEND.WNR_EXEC_SQL);

            /*" -2107- PERFORM R0050_00_TRATA_CURSOR05_DB_OPEN_1 */

            R0050_00_TRATA_CURSOR05_DB_OPEN_1();

            /*" -2110- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2111- DISPLAY 'R0050 - ERRO NO OPEN DO CURSOR C05' */
                _.Display($"R0050 - ERRO NO OPEN DO CURSOR C05");

                /*" -2112- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2114- END-IF. */
            }


            /*" -2116- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2118- PERFORM R0056-00-GRAVA-LC-C05. */

            R0056_00_GRAVA_LC_C05_SECTION();

            /*" -2120- PERFORM R0055-00-FETCH-C05. */

            R0055_00_FETCH_C05_SECTION();

            /*" -2121- PERFORM UNTIL WFIM-C05 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C05 == "S"))
            {

                /*" -2122- MOVE GE536-COD-EMPRESA TO LDC05-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC05.LDC05_COD_EMPRESA);

                /*" -2123- MOVE GE538-DES-EMPRESA TO LDC05-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC05.LDC05_DES_EMPRESA);

                /*" -2124- MOVE GE554-COD-LOTE-A TO LDC05-COD-LOTE-A */
                _.Move(GE554.DCLGE_CONTROL_ARQ_A_SAP.GE554_COD_LOTE_A, WS_ARQUIVO.LDC05.LDC05_COD_LOTE_A);

                /*" -2125- MOVE GE554-NOM-EXTERNO-ARQUIVO TO LDC05-NOM-EXT-ARQ */
                _.Move(GE554.DCLGE_CONTROL_ARQ_A_SAP.GE554_NOM_EXTERNO_ARQUIVO, WS_ARQUIVO.LDC05.LDC05_NOM_EXT_ARQ);

                /*" -2126- WRITE REG-CPB100S1 FROM LDC05 */
                _.Move(WS_ARQUIVO.LDC05.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2127- WRITE REG-CP100T04 FROM LDC05 */
                _.Move(WS_ARQUIVO.LDC05.GetMoveValues(), REG_CP100T04);

                CP100T04.Write(REG_CP100T04.GetMoveValues().ToString());

                /*" -2128- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2129- PERFORM R0055-00-FETCH-C05 */

                R0055_00_FETCH_C05_SECTION();

                /*" -2131- END-PERFORM. */
            }

            /*" -2132- IF AC-L-C05 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C05 == 00)
            {

                /*" -2133- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2134- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2135- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2135- END-IF. */
            }


        }

        [StopWatch]
        /*" R0050-00-TRATA-CURSOR05-DB-OPEN-1 */
        public void R0050_00_TRATA_CURSOR05_DB_OPEN_1()
        {
            /*" -2107- EXEC SQL OPEN C05 END-EXEC. */

            C05.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0055-00-FETCH-C05-SECTION */
        private void R0055_00_FETCH_C05_SECTION()
        {
            /*" -2147- MOVE '0055' TO WNR-EXEC-SQL. */
            _.Move("0055", WABEND.WNR_EXEC_SQL);

            /*" -2152- PERFORM R0055_00_FETCH_C05_DB_FETCH_1 */

            R0055_00_FETCH_C05_DB_FETCH_1();

            /*" -2155- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2156- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2157- MOVE 'S' TO WFIM-C05 */
                    _.Move("S", AREA_DE_WORK.WFIM_C05);

                    /*" -2157- PERFORM R0055_00_FETCH_C05_DB_CLOSE_1 */

                    R0055_00_FETCH_C05_DB_CLOSE_1();

                    /*" -2159- GO TO R0055-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_99_SAIDA*/ //GOTO
                    return;

                    /*" -2160- ELSE */
                }
                else
                {


                    /*" -2161- DISPLAY 'R0055 - ERRO NO FETCH DO CURSOR05' */
                    _.Display($"R0055 - ERRO NO FETCH DO CURSOR05");

                    /*" -2162- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2163- END-IF */
                }


                /*" -2164- ELSE */
            }
            else
            {


                /*" -2165- ADD 1 TO AC-L-C05 */
                AREA_DE_WORK.AC_L_C05.Value = AREA_DE_WORK.AC_L_C05 + 1;

                /*" -2165- END-IF. */
            }


        }

        [StopWatch]
        /*" R0055-00-FETCH-C05-DB-FETCH-1 */
        public void R0055_00_FETCH_C05_DB_FETCH_1()
        {
            /*" -2152- EXEC SQL FETCH C05 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE554-COD-LOTE-A ,:GE554-NOM-EXTERNO-ARQUIVO END-EXEC. */

            if (C05.Fetch())
            {
                _.Move(C05.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C05.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C05.GE554_COD_LOTE_A, GE554.DCLGE_CONTROL_ARQ_A_SAP.GE554_COD_LOTE_A);
                _.Move(C05.GE554_NOM_EXTERNO_ARQUIVO, GE554.DCLGE_CONTROL_ARQ_A_SAP.GE554_NOM_EXTERNO_ARQUIVO);
            }

        }

        [StopWatch]
        /*" R0055-00-FETCH-C05-DB-CLOSE-1 */
        public void R0055_00_FETCH_C05_DB_CLOSE_1()
        {
            /*" -2157- EXEC SQL CLOSE C05 END-EXEC */

            C05.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0055_99_SAIDA*/

        [StopWatch]
        /*" R0056-00-GRAVA-LC-C05-SECTION */
        private void R0056_00_GRAVA_LC_C05_SECTION()
        {
            /*" -2177- MOVE '0056' TO WNR-EXEC-SQL. */
            _.Move("0056", WABEND.WNR_EXEC_SQL);

            /*" -2178- WRITE REG-CPB100S1 FROM LC1-C05. */
            _.Move(WS_ARQUIVO.LC1_C05.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2179- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2180- WRITE REG-CPB100S1 FROM LC2-C05. */
            _.Move(WS_ARQUIVO.LC2_C05.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2181- WRITE REG-CP100T04 FROM LC2-C05. */
            _.Move(WS_ARQUIVO.LC2_C05.GetMoveValues(), REG_CP100T04);

            CP100T04.Write(REG_CP100T04.GetMoveValues().ToString());

            /*" -2183- WRITE REG-CPB100S1 FROM LC3-C05. */
            _.Move(WS_ARQUIVO.LC3_C05.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2183- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0056_99_SAIDA*/

        [StopWatch]
        /*" R0060-00-TRATA-CURSOR06-SECTION */
        private void R0060_00_TRATA_CURSOR06_SECTION()
        {
            /*" -2195- MOVE '0060' TO WNR-EXEC-SQL. */
            _.Move("0060", WABEND.WNR_EXEC_SQL);

            /*" -2197- PERFORM R0060_00_TRATA_CURSOR06_DB_OPEN_1 */

            R0060_00_TRATA_CURSOR06_DB_OPEN_1();

            /*" -2200- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2201- DISPLAY 'R0060 - ERRO NO OPEN DO CURSOR C06' */
                _.Display($"R0060 - ERRO NO OPEN DO CURSOR C06");

                /*" -2202- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2204- END-IF. */
            }


            /*" -2206- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2208- PERFORM R0066-00-GRAVA-LC-C06. */

            R0066_00_GRAVA_LC_C06_SECTION();

            /*" -2210- PERFORM R0065-00-FETCH-C06. */

            R0065_00_FETCH_C06_SECTION();

            /*" -2211- PERFORM UNTIL WFIM-C06 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C06 == "S"))
            {

                /*" -2212- MOVE GE536-COD-EMPRESA TO LDC06-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC06.LDC06_COD_EMPRESA);

                /*" -2213- MOVE GE538-DES-EMPRESA TO LDC06-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC06.LDC06_DES_EMPRESA);

                /*" -2214- MOVE GE551-COD-ORIGEM TO LDC06-ORIGEM */
                _.Move(GE551.DCLGE_DETALHE_ARQ_G_SAP.GE551_COD_ORIGEM, WS_ARQUIVO.LDC06.LDC06_ORIGEM);

                /*" -2215- MOVE GE538-DES-ORIGEM TO LDC06-DES-ORIGEM */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM, WS_ARQUIVO.LDC06.LDC06_DES_ORIGEM);

                /*" -2216- MOVE GE551-COD-LOTE-G TO LDC06-LOTE */
                _.Move(GE551.DCLGE_DETALHE_ARQ_G_SAP.GE551_COD_LOTE_G, WS_ARQUIVO.LDC06.LDC06_LOTE);

                /*" -2217- MOVE C06-STA-CONSUMO TO LDC06-STA-CONSUMO */
                _.Move(AREA_DE_WORK.C06_STA_CONSUMO, WS_ARQUIVO.LDC06.LDC06_STA_CONSUMO);

                /*" -2218- MOVE SPACES TO LDC06-DES-MSG-ERRO */
                _.Move("", WS_ARQUIVO.LDC06.LDC06_DES_MSG_ERRO);

                /*" -2219- MOVE GE562-DES-MSG-ERRO-TEXT TO LDC06-DES-MSG-ERRO */
                _.Move(GE562.DCLGE_DET_ARQ_G_SAP_ERRO.GE562_DES_MSG_ERRO.GE562_DES_MSG_ERRO_TEXT, WS_ARQUIVO.LDC06.LDC06_DES_MSG_ERRO);

                /*" -2220- MOVE GE552-NOM-EXTERNO-ARQUIVO TO LDC06-NOM-EXT-ARQ */
                _.Move(GE552.DCLGE_CONTROL_ARQ_G_SAP.GE552_NOM_EXTERNO_ARQUIVO, WS_ARQUIVO.LDC06.LDC06_NOM_EXT_ARQ);

                /*" -2221- MOVE C06-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C06_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -2222- MOVE GDA-QTD TO LDC06-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC06.LDC06_QTD);

                /*" -2223- WRITE REG-CPB100S1 FROM LDC06 */
                _.Move(WS_ARQUIVO.LDC06.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2224- WRITE REG-CP100T05 FROM LDC06 */
                _.Move(WS_ARQUIVO.LDC06.GetMoveValues(), REG_CP100T05);

                CP100T05.Write(REG_CP100T05.GetMoveValues().ToString());

                /*" -2225- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2226- PERFORM R0065-00-FETCH-C06 */

                R0065_00_FETCH_C06_SECTION();

                /*" -2228- END-PERFORM. */
            }

            /*" -2229- IF AC-L-C06 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C06 == 00)
            {

                /*" -2230- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2231- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2232- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2232- END-IF. */
            }


        }

        [StopWatch]
        /*" R0060-00-TRATA-CURSOR06-DB-OPEN-1 */
        public void R0060_00_TRATA_CURSOR06_DB_OPEN_1()
        {
            /*" -2197- EXEC SQL OPEN C06 END-EXEC. */

            C06.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0060_99_SAIDA*/

        [StopWatch]
        /*" R0065-00-FETCH-C06-SECTION */
        private void R0065_00_FETCH_C06_SECTION()
        {
            /*" -2244- MOVE '0065' TO WNR-EXEC-SQL. */
            _.Move("0065", WABEND.WNR_EXEC_SQL);

            /*" -2246- MOVE SPACES TO GE562-DES-MSG-ERRO-TEXT. */
            _.Move("", GE562.DCLGE_DET_ARQ_G_SAP_ERRO.GE562_DES_MSG_ERRO.GE562_DES_MSG_ERRO_TEXT);

            /*" -2256- PERFORM R0065_00_FETCH_C06_DB_FETCH_1 */

            R0065_00_FETCH_C06_DB_FETCH_1();

            /*" -2259- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2260- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2261- MOVE 'S' TO WFIM-C06 */
                    _.Move("S", AREA_DE_WORK.WFIM_C06);

                    /*" -2261- PERFORM R0065_00_FETCH_C06_DB_CLOSE_1 */

                    R0065_00_FETCH_C06_DB_CLOSE_1();

                    /*" -2263- GO TO R0065-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/ //GOTO
                    return;

                    /*" -2264- ELSE */
                }
                else
                {


                    /*" -2265- DISPLAY 'R0065 - ERRO NO FETCH DO CURSOR06' */
                    _.Display($"R0065 - ERRO NO FETCH DO CURSOR06");

                    /*" -2266- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2267- END-IF */
                }


                /*" -2268- ELSE */
            }
            else
            {


                /*" -2269- ADD 1 TO AC-L-C06 */
                AREA_DE_WORK.AC_L_C06.Value = AREA_DE_WORK.AC_L_C06 + 1;

                /*" -2271- END-IF. */
            }


            /*" -2272- IF VIND-DES-MSG-ERRO EQUAL -1 */

            if (AREA_DE_WORK.VIND_DES_MSG_ERRO == -1)
            {

                /*" -2273- MOVE SPACES TO GE562-DES-MSG-ERRO */
                _.Move("", GE562.DCLGE_DET_ARQ_G_SAP_ERRO.GE562_DES_MSG_ERRO);

                /*" -2273- END-IF. */
            }


        }

        [StopWatch]
        /*" R0065-00-FETCH-C06-DB-FETCH-1 */
        public void R0065_00_FETCH_C06_DB_FETCH_1()
        {
            /*" -2256- EXEC SQL FETCH C06 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE551-COD-ORIGEM ,:GE538-DES-ORIGEM ,:GE551-COD-LOTE-G ,:C06-STA-CONSUMO ,:GE562-DES-MSG-ERRO :VIND-DES-MSG-ERRO ,:GE552-NOM-EXTERNO-ARQUIVO ,:C06-QTD END-EXEC. */

            if (C06.Fetch())
            {
                _.Move(C06.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C06.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C06.GE551_COD_ORIGEM, GE551.DCLGE_DETALHE_ARQ_G_SAP.GE551_COD_ORIGEM);
                _.Move(C06.GE538_DES_ORIGEM, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM);
                _.Move(C06.GE551_COD_LOTE_G, GE551.DCLGE_DETALHE_ARQ_G_SAP.GE551_COD_LOTE_G);
                _.Move(C06.C06_STA_CONSUMO, AREA_DE_WORK.C06_STA_CONSUMO);
                _.Move(C06.GE562_DES_MSG_ERRO, GE562.DCLGE_DET_ARQ_G_SAP_ERRO.GE562_DES_MSG_ERRO);
                _.Move(C06.VIND_DES_MSG_ERRO, AREA_DE_WORK.VIND_DES_MSG_ERRO);
                _.Move(C06.GE552_NOM_EXTERNO_ARQUIVO, GE552.DCLGE_CONTROL_ARQ_G_SAP.GE552_NOM_EXTERNO_ARQUIVO);
                _.Move(C06.C06_QTD, AREA_DE_WORK.C06_QTD);
            }

        }

        [StopWatch]
        /*" R0065-00-FETCH-C06-DB-CLOSE-1 */
        public void R0065_00_FETCH_C06_DB_CLOSE_1()
        {
            /*" -2261- EXEC SQL CLOSE C06 END-EXEC */

            C06.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0065_99_SAIDA*/

        [StopWatch]
        /*" R0066-00-GRAVA-LC-C06-SECTION */
        private void R0066_00_GRAVA_LC_C06_SECTION()
        {
            /*" -2285- MOVE '0066' TO WNR-EXEC-SQL. */
            _.Move("0066", WABEND.WNR_EXEC_SQL);

            /*" -2286- WRITE REG-CPB100S1 FROM LC1-C06. */
            _.Move(WS_ARQUIVO.LC1_C06.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2287- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2288- WRITE REG-CPB100S1 FROM LC2-C06. */
            _.Move(WS_ARQUIVO.LC2_C06.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2289- WRITE REG-CP100T05 FROM LC2-C06. */
            _.Move(WS_ARQUIVO.LC2_C06.GetMoveValues(), REG_CP100T05);

            CP100T05.Write(REG_CP100T05.GetMoveValues().ToString());

            /*" -2291- WRITE REG-CPB100S1 FROM LC3-C06. */
            _.Move(WS_ARQUIVO.LC3_C06.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2291- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0066_99_SAIDA*/

        [StopWatch]
        /*" R0080-00-TRATA-CURSOR08-SECTION */
        private void R0080_00_TRATA_CURSOR08_SECTION()
        {
            /*" -2303- MOVE '0080' TO WNR-EXEC-SQL. */
            _.Move("0080", WABEND.WNR_EXEC_SQL);

            /*" -2305- PERFORM R0080_00_TRATA_CURSOR08_DB_OPEN_1 */

            R0080_00_TRATA_CURSOR08_DB_OPEN_1();

            /*" -2308- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2309- DISPLAY 'R0080 - ERRO NO OPEN DO CURSOR C08' */
                _.Display($"R0080 - ERRO NO OPEN DO CURSOR C08");

                /*" -2310- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2312- END-IF. */
            }


            /*" -2314- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2316- PERFORM R0086-00-GRAVA-LC-C08. */

            R0086_00_GRAVA_LC_C08_SECTION();

            /*" -2318- PERFORM R0085-00-FETCH-C08. */

            R0085_00_FETCH_C08_SECTION();

            /*" -2319- PERFORM UNTIL WFIM-C08 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C08 == "S"))
            {

                /*" -2320- MOVE GE536-COD-EMPRESA TO LDC08-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC08.LDC08_COD_EMPRESA);

                /*" -2321- MOVE GE538-DES-EMPRESA TO LDC08-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC08.LDC08_DES_EMPRESA);

                /*" -2322- MOVE GE537-COD-LOTE-G TO LDC08-LOTE */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_G, WS_ARQUIVO.LDC08.LDC08_LOTE);

                /*" -2323- MOVE GE537-COD-ORIGEM TO LDC08-ORIGEM */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM, WS_ARQUIVO.LDC08.LDC08_ORIGEM);

                /*" -2324- MOVE GE538-DES-ORIGEM TO LDC08-DES-ORIGEM */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM, WS_ARQUIVO.LDC08.LDC08_DES_ORIGEM);

                /*" -2325- MOVE GE547-DTA-COBRAR-PAGAR TO LDC08-DTA-COBRAR */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR, WS_ARQUIVO.LDC08.LDC08_DTA_COBRAR);

                /*" -2326- MOVE GE552-NOM-EXTERNO-ARQUIVO TO LDC08-NOM-EXT-ARQ */
                _.Move(GE552.DCLGE_CONTROL_ARQ_G_SAP.GE552_NOM_EXTERNO_ARQUIVO, WS_ARQUIVO.LDC08.LDC08_NOM_EXT_ARQ);

                /*" -2327- MOVE C08-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C08_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -2328- MOVE GDA-QTD TO LDC08-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC08.LDC08_QTD);

                /*" -2329- WRITE REG-CPB100S1 FROM LDC08 */
                _.Move(WS_ARQUIVO.LDC08.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2330- WRITE REG-CP100T67 FROM LDC08 */
                _.Move(WS_ARQUIVO.LDC08.GetMoveValues(), REG_CP100T67);

                CP100T67.Write(REG_CP100T67.GetMoveValues().ToString());

                /*" -2331- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2332- PERFORM R0085-00-FETCH-C08 */

                R0085_00_FETCH_C08_SECTION();

                /*" -2334- END-PERFORM. */
            }

            /*" -2335- IF AC-L-C08 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C08 == 00)
            {

                /*" -2336- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2337- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2338- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2338- END-IF. */
            }


        }

        [StopWatch]
        /*" R0080-00-TRATA-CURSOR08-DB-OPEN-1 */
        public void R0080_00_TRATA_CURSOR08_DB_OPEN_1()
        {
            /*" -2305- EXEC SQL OPEN C08 END-EXEC. */

            C08.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_99_SAIDA*/

        [StopWatch]
        /*" R0085-00-FETCH-C08-SECTION */
        private void R0085_00_FETCH_C08_SECTION()
        {
            /*" -2350- MOVE '0085' TO WNR-EXEC-SQL. */
            _.Move("0085", WABEND.WNR_EXEC_SQL);

            /*" -2359- PERFORM R0085_00_FETCH_C08_DB_FETCH_1 */

            R0085_00_FETCH_C08_DB_FETCH_1();

            /*" -2362- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2363- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2364- MOVE 'S' TO WFIM-C08 */
                    _.Move("S", AREA_DE_WORK.WFIM_C08);

                    /*" -2364- PERFORM R0085_00_FETCH_C08_DB_CLOSE_1 */

                    R0085_00_FETCH_C08_DB_CLOSE_1();

                    /*" -2366- GO TO R0085-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_99_SAIDA*/ //GOTO
                    return;

                    /*" -2367- ELSE */
                }
                else
                {


                    /*" -2368- DISPLAY 'R0085 - ERRO NO FETCH DO CURSOR08' */
                    _.Display($"R0085 - ERRO NO FETCH DO CURSOR08");

                    /*" -2369- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2370- END-IF */
                }


                /*" -2371- ELSE */
            }
            else
            {


                /*" -2372- ADD 1 TO AC-L-C08 */
                AREA_DE_WORK.AC_L_C08.Value = AREA_DE_WORK.AC_L_C08 + 1;

                /*" -2374- END-IF. */
            }


            /*" -2375- IF VIND-COD-LOTE-G EQUAL -1 */

            if (AREA_DE_WORK.VIND_COD_LOTE_G == -1)
            {

                /*" -2376- MOVE SPACES TO GE537-COD-LOTE-G */
                _.Move("", GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_G);

                /*" -2378- END-IF. */
            }


            /*" -2379- IF VIND-COD-ORIGEM EQUAL -1 */

            if (AREA_DE_WORK.VIND_COD_ORIGEM == -1)
            {

                /*" -2380- MOVE SPACES TO GE537-COD-ORIGEM */
                _.Move("", GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);

                /*" -2380- END-IF. */
            }


        }

        [StopWatch]
        /*" R0085-00-FETCH-C08-DB-FETCH-1 */
        public void R0085_00_FETCH_C08_DB_FETCH_1()
        {
            /*" -2359- EXEC SQL FETCH C08 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE537-COD-LOTE-G :VIND-COD-LOTE-G ,:GE537-COD-ORIGEM :VIND-COD-ORIGEM ,:GE538-DES-ORIGEM ,:GE547-DTA-COBRAR-PAGAR ,:GE552-NOM-EXTERNO-ARQUIVO ,:C08-QTD END-EXEC. */

            if (C08.Fetch())
            {
                _.Move(C08.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C08.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C08.GE537_COD_LOTE_G, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_G);
                _.Move(C08.VIND_COD_LOTE_G, AREA_DE_WORK.VIND_COD_LOTE_G);
                _.Move(C08.GE537_COD_ORIGEM, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);
                _.Move(C08.VIND_COD_ORIGEM, AREA_DE_WORK.VIND_COD_ORIGEM);
                _.Move(C08.GE538_DES_ORIGEM, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM);
                _.Move(C08.GE547_DTA_COBRAR_PAGAR, GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR);
                _.Move(C08.GE552_NOM_EXTERNO_ARQUIVO, GE552.DCLGE_CONTROL_ARQ_G_SAP.GE552_NOM_EXTERNO_ARQUIVO);
                _.Move(C08.C08_QTD, AREA_DE_WORK.C08_QTD);
            }

        }

        [StopWatch]
        /*" R0085-00-FETCH-C08-DB-CLOSE-1 */
        public void R0085_00_FETCH_C08_DB_CLOSE_1()
        {
            /*" -2364- EXEC SQL CLOSE C08 END-EXEC */

            C08.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_99_SAIDA*/

        [StopWatch]
        /*" R0086-00-GRAVA-LC-C08-SECTION */
        private void R0086_00_GRAVA_LC_C08_SECTION()
        {
            /*" -2392- MOVE '0086' TO WNR-EXEC-SQL. */
            _.Move("0086", WABEND.WNR_EXEC_SQL);

            /*" -2393- WRITE REG-CPB100S1 FROM LC1-C08. */
            _.Move(WS_ARQUIVO.LC1_C08.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2394- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2395- WRITE REG-CPB100S1 FROM LC2-C08. */
            _.Move(WS_ARQUIVO.LC2_C08.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2396- WRITE REG-CP100T67 FROM LC2-C08. */
            _.Move(WS_ARQUIVO.LC2_C08.GetMoveValues(), REG_CP100T67);

            CP100T67.Write(REG_CP100T67.GetMoveValues().ToString());

            /*" -2398- WRITE REG-CPB100S1 FROM LC3-C08. */
            _.Move(WS_ARQUIVO.LC3_C08.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2398- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0086_99_SAIDA*/

        [StopWatch]
        /*" R0090-00-TRATA-CURSOR09-SECTION */
        private void R0090_00_TRATA_CURSOR09_SECTION()
        {
            /*" -2410- MOVE '0090' TO WNR-EXEC-SQL. */
            _.Move("0090", WABEND.WNR_EXEC_SQL);

            /*" -2412- PERFORM R0090_00_TRATA_CURSOR09_DB_OPEN_1 */

            R0090_00_TRATA_CURSOR09_DB_OPEN_1();

            /*" -2415- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2416- DISPLAY 'R0090 - ERRO NO OPEN DO CURSOR C09' */
                _.Display($"R0090 - ERRO NO OPEN DO CURSOR C09");

                /*" -2417- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2419- END-IF. */
            }


            /*" -2421- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2423- PERFORM R0096-00-GRAVA-LC-C09. */

            R0096_00_GRAVA_LC_C09_SECTION();

            /*" -2425- PERFORM R0095-00-FETCH-C09. */

            R0095_00_FETCH_C09_SECTION();

            /*" -2426- PERFORM UNTIL WFIM-C09 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C09 == "S"))
            {

                /*" -2427- MOVE GE536-COD-EMPRESA TO LDC09-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC09.LDC09_COD_EMPRESA);

                /*" -2428- MOVE GE538-DES-EMPRESA TO LDC09-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC09.LDC09_DES_EMPRESA);

                /*" -2429- MOVE GE537-COD-LOTE-A TO LDC09-LOTE */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_A, WS_ARQUIVO.LDC09.LDC09_LOTE);

                /*" -2430- MOVE GE537-COD-ORIGEM TO LDC09-ORIGEM */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM, WS_ARQUIVO.LDC09.LDC09_ORIGEM);

                /*" -2431- MOVE GE538-DES-ORIGEM TO LDC09-DES-ORIGEM */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM, WS_ARQUIVO.LDC09.LDC09_DES_ORIGEM);

                /*" -2432- MOVE GE547-DTA-COBRAR-PAGAR TO LDC09-DTA-COBRAR */
                _.Move(GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR, WS_ARQUIVO.LDC09.LDC09_DTA_COBRAR);

                /*" -2433- MOVE GE552-NOM-EXTERNO-ARQUIVO TO LDC09-NOM-EXT-ARQ */
                _.Move(GE552.DCLGE_CONTROL_ARQ_G_SAP.GE552_NOM_EXTERNO_ARQUIVO, WS_ARQUIVO.LDC09.LDC09_NOM_EXT_ARQ);

                /*" -2434- MOVE C09-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C09_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -2435- MOVE GDA-QTD TO LDC09-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC09.LDC09_QTD);

                /*" -2436- WRITE REG-CPB100S1 FROM LDC09 */
                _.Move(WS_ARQUIVO.LDC09.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2437- WRITE REG-CP100T67 FROM LDC09 */
                _.Move(WS_ARQUIVO.LDC09.GetMoveValues(), REG_CP100T67);

                CP100T67.Write(REG_CP100T67.GetMoveValues().ToString());

                /*" -2438- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2439- PERFORM R0095-00-FETCH-C09 */

                R0095_00_FETCH_C09_SECTION();

                /*" -2441- END-PERFORM. */
            }

            /*" -2442- IF AC-L-C09 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C09 == 00)
            {

                /*" -2443- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2444- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2445- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2445- END-IF. */
            }


        }

        [StopWatch]
        /*" R0090-00-TRATA-CURSOR09-DB-OPEN-1 */
        public void R0090_00_TRATA_CURSOR09_DB_OPEN_1()
        {
            /*" -2412- EXEC SQL OPEN C09 END-EXEC. */

            C09.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0090_99_SAIDA*/

        [StopWatch]
        /*" R0095-00-FETCH-C09-SECTION */
        private void R0095_00_FETCH_C09_SECTION()
        {
            /*" -2457- MOVE '0095' TO WNR-EXEC-SQL. */
            _.Move("0095", WABEND.WNR_EXEC_SQL);

            /*" -2466- PERFORM R0095_00_FETCH_C09_DB_FETCH_1 */

            R0095_00_FETCH_C09_DB_FETCH_1();

            /*" -2469- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2470- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2471- MOVE 'S' TO WFIM-C09 */
                    _.Move("S", AREA_DE_WORK.WFIM_C09);

                    /*" -2471- PERFORM R0095_00_FETCH_C09_DB_CLOSE_1 */

                    R0095_00_FETCH_C09_DB_CLOSE_1();

                    /*" -2473- GO TO R0095-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0095_99_SAIDA*/ //GOTO
                    return;

                    /*" -2474- ELSE */
                }
                else
                {


                    /*" -2475- DISPLAY 'R0095 - ERRO NO FETCH DO CURSOR09' */
                    _.Display($"R0095 - ERRO NO FETCH DO CURSOR09");

                    /*" -2476- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2477- END-IF */
                }


                /*" -2478- ELSE */
            }
            else
            {


                /*" -2479- ADD 1 TO AC-L-C09 */
                AREA_DE_WORK.AC_L_C09.Value = AREA_DE_WORK.AC_L_C09 + 1;

                /*" -2481- END-IF. */
            }


            /*" -2482- IF VIND-COD-LOTE-A EQUAL -1 */

            if (AREA_DE_WORK.VIND_COD_LOTE_A == -1)
            {

                /*" -2483- MOVE SPACES TO GE537-COD-LOTE-A */
                _.Move("", GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_A);

                /*" -2483- END-IF. */
            }


        }

        [StopWatch]
        /*" R0095-00-FETCH-C09-DB-FETCH-1 */
        public void R0095_00_FETCH_C09_DB_FETCH_1()
        {
            /*" -2466- EXEC SQL FETCH C09 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE537-COD-LOTE-A :VIND-COD-LOTE-A ,:GE537-COD-ORIGEM :VIND-COD-ORIGEM ,:GE538-DES-ORIGEM ,:GE547-DTA-COBRAR-PAGAR ,:GE552-NOM-EXTERNO-ARQUIVO ,:C09-QTD END-EXEC. */

            if (C09.Fetch())
            {
                _.Move(C09.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C09.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C09.GE537_COD_LOTE_A, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_LOTE_A);
                _.Move(C09.VIND_COD_LOTE_A, AREA_DE_WORK.VIND_COD_LOTE_A);
                _.Move(C09.GE537_COD_ORIGEM, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);
                _.Move(C09.VIND_COD_ORIGEM, AREA_DE_WORK.VIND_COD_ORIGEM);
                _.Move(C09.GE538_DES_ORIGEM, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM);
                _.Move(C09.GE547_DTA_COBRAR_PAGAR, GE547.DCLGE_FORMA_COBRA_PAGA_SAP.GE547_DTA_COBRAR_PAGAR);
                _.Move(C09.GE552_NOM_EXTERNO_ARQUIVO, GE552.DCLGE_CONTROL_ARQ_G_SAP.GE552_NOM_EXTERNO_ARQUIVO);
                _.Move(C09.C09_QTD, AREA_DE_WORK.C09_QTD);
            }

        }

        [StopWatch]
        /*" R0095-00-FETCH-C09-DB-CLOSE-1 */
        public void R0095_00_FETCH_C09_DB_CLOSE_1()
        {
            /*" -2471- EXEC SQL CLOSE C09 END-EXEC */

            C09.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0095_99_SAIDA*/

        [StopWatch]
        /*" R0096-00-GRAVA-LC-C09-SECTION */
        private void R0096_00_GRAVA_LC_C09_SECTION()
        {
            /*" -2495- MOVE '0096' TO WNR-EXEC-SQL. */
            _.Move("0096", WABEND.WNR_EXEC_SQL);

            /*" -2496- WRITE REG-CPB100S1 FROM LC1-C09. */
            _.Move(WS_ARQUIVO.LC1_C09.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2497- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2498- WRITE REG-CPB100S1 FROM LC2-C09. */
            _.Move(WS_ARQUIVO.LC2_C09.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2500- WRITE REG-CPB100S1 FROM LC3-C09. */
            _.Move(WS_ARQUIVO.LC3_C09.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2500- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0096_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-TRATA-CURSOR10-SECTION */
        private void R0100_00_TRATA_CURSOR10_SECTION()
        {
            /*" -2512- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -2514- PERFORM R0100_00_TRATA_CURSOR10_DB_OPEN_1 */

            R0100_00_TRATA_CURSOR10_DB_OPEN_1();

            /*" -2517- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2518- DISPLAY 'R0100 - ERRO NO OPEN DO CURSOR C10' */
                _.Display($"R0100 - ERRO NO OPEN DO CURSOR C10");

                /*" -2519- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2521- END-IF. */
            }


            /*" -2523- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2525- PERFORM R0106-00-GRAVA-LC-C10. */

            R0106_00_GRAVA_LC_C10_SECTION();

            /*" -2527- PERFORM R0105-00-FETCH-C10. */

            R0105_00_FETCH_C10_SECTION();

            /*" -2528- PERFORM UNTIL WFIM-C10 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C10 == "S"))
            {

                /*" -2529- MOVE GE536-COD-EMPRESA TO LDC10-COD-EMPRESA */
                _.Move(GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA, WS_ARQUIVO.LDC10.LDC10_COD_EMPRESA);

                /*" -2530- MOVE GE538-DES-EMPRESA TO LDC10-DES-EMPRESA */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA, WS_ARQUIVO.LDC10.LDC10_DES_EMPRESA);

                /*" -2531- MOVE GE537-COD-ORIGEM TO LDC10-ORIGEM */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM, WS_ARQUIVO.LDC10.LDC10_ORIGEM);

                /*" -2532- MOVE GE538-DES-ORIGEM TO LDC10-DES-ORIGEM */
                _.Move(GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM, WS_ARQUIVO.LDC10.LDC10_DES_ORIGEM);

                /*" -2533- MOVE GE537-DTA-MOVIMENTO TO LDC10-DTA-MOV */
                _.Move(GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO, WS_ARQUIVO.LDC10.LDC10_DTA_MOV);

                /*" -2534- MOVE GE540-COD-TIPO-REGISTRO TO LDC10-COD-TIP-REG */
                _.Move(GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_COD_TIPO_REGISTRO, WS_ARQUIVO.LDC10.LDC10_COD_TIP_REG);

                /*" -2535- MOVE GE577-COD-RETORNO-ARQ-H TO LDC10-COD-TIP-RET */
                _.Move(GE577.DCLGE_DET_ARQ_H_RETORNO_SAP.GE577_COD_RETORNO_ARQ_H, WS_ARQUIVO.LDC10.LDC10_COD_TIP_RET);

                /*" -2536- MOVE GE576-DES-RETORNO-ARQ-H TO DES-RETORNO */
                _.Move(GE576.DCLGE_RETORNO_ARQ_H_SAP.GE576_DES_RETORNO_ARQ_H, DES_RETORNO);

                /*" -2537- MOVE ARQ-H-TEXT(1:ARQ-H-LEN) TO LDC10-DES-TIP-RET */
                _.Move(DES_RETORNO.ARQ_H_TEXT.Substring(1, DES_RETORNO.ARQ_H_LEN), WS_ARQUIVO.LDC10.LDC10_DES_TIP_RET);

                /*" -2538- MOVE C10-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C10_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -2539- MOVE GDA-QTD TO LDC10-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC10.LDC10_QTD);

                /*" -2540- WRITE REG-CPB100S1 FROM LDC10 */
                _.Move(WS_ARQUIVO.LDC10.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2541- WRITE REG-CP100T08 FROM LDC10 */
                _.Move(WS_ARQUIVO.LDC10.GetMoveValues(), REG_CP100T08);

                CP100T08.Write(REG_CP100T08.GetMoveValues().ToString());

                /*" -2542- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2543- PERFORM R0105-00-FETCH-C10 */

                R0105_00_FETCH_C10_SECTION();

                /*" -2545- END-PERFORM. */
            }

            /*" -2546- IF AC-L-C10 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C10 == 00)
            {

                /*" -2547- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2548- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2549- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2549- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-TRATA-CURSOR10-DB-OPEN-1 */
        public void R0100_00_TRATA_CURSOR10_DB_OPEN_1()
        {
            /*" -2514- EXEC SQL OPEN C10 END-EXEC. */

            C10.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0105-00-FETCH-C10-SECTION */
        private void R0105_00_FETCH_C10_SECTION()
        {
            /*" -2561- MOVE '0105' TO WNR-EXEC-SQL. */
            _.Move("0105", WABEND.WNR_EXEC_SQL);

            /*" -2571- PERFORM R0105_00_FETCH_C10_DB_FETCH_1 */

            R0105_00_FETCH_C10_DB_FETCH_1();

            /*" -2574- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2575- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2576- MOVE 'S' TO WFIM-C10 */
                    _.Move("S", AREA_DE_WORK.WFIM_C10);

                    /*" -2576- PERFORM R0105_00_FETCH_C10_DB_CLOSE_1 */

                    R0105_00_FETCH_C10_DB_CLOSE_1();

                    /*" -2578- GO TO R0105-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_99_SAIDA*/ //GOTO
                    return;

                    /*" -2579- ELSE */
                }
                else
                {


                    /*" -2580- DISPLAY 'R0105 - ERRO NO FETCH DO CURSOR10' */
                    _.Display($"R0105 - ERRO NO FETCH DO CURSOR10");

                    /*" -2581- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2582- END-IF */
                }


                /*" -2583- ELSE */
            }
            else
            {


                /*" -2584- ADD 1 TO AC-L-C10 */
                AREA_DE_WORK.AC_L_C10.Value = AREA_DE_WORK.AC_L_C10 + 1;

                /*" -2586- END-IF. */
            }


            /*" -2587- IF VIND-COD-ORIGEM EQUAL -1 */

            if (AREA_DE_WORK.VIND_COD_ORIGEM == -1)
            {

                /*" -2588- MOVE SPACES TO GE537-COD-ORIGEM */
                _.Move("", GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);

                /*" -2588- END-IF. */
            }


        }

        [StopWatch]
        /*" R0105-00-FETCH-C10-DB-FETCH-1 */
        public void R0105_00_FETCH_C10_DB_FETCH_1()
        {
            /*" -2571- EXEC SQL FETCH C10 INTO :GE536-COD-EMPRESA ,:GE538-DES-EMPRESA ,:GE537-COD-ORIGEM :VIND-COD-ORIGEM ,:GE538-DES-ORIGEM ,:GE537-DTA-MOVIMENTO ,:GE540-COD-TIPO-REGISTRO ,:GE577-COD-RETORNO-ARQ-H ,:GE576-DES-RETORNO-ARQ-H ,:C10-QTD END-EXEC. */

            if (C10.Fetch())
            {
                _.Move(C10.GE536_COD_EMPRESA, GE536.DCLGE_SOLICITACAO_AP_CA_SAP.GE536_COD_EMPRESA);
                _.Move(C10.GE538_DES_EMPRESA, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_EMPRESA);
                _.Move(C10.GE537_COD_ORIGEM, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_COD_ORIGEM);
                _.Move(C10.VIND_COD_ORIGEM, AREA_DE_WORK.VIND_COD_ORIGEM);
                _.Move(C10.GE538_DES_ORIGEM, GE538.DCLGE_EVENTO_AP_CA_SAP.GE538_DES_ORIGEM);
                _.Move(C10.GE537_DTA_MOVIMENTO, GE537.DCLGE_SOLICITA_AP_CA_SAP_HIST.GE537_DTA_MOVIMENTO);
                _.Move(C10.GE540_COD_TIPO_REGISTRO, GE540.DCLGE_DETALHE_ARQ_H_SAP.GE540_COD_TIPO_REGISTRO);
                _.Move(C10.GE577_COD_RETORNO_ARQ_H, GE577.DCLGE_DET_ARQ_H_RETORNO_SAP.GE577_COD_RETORNO_ARQ_H);
                _.Move(C10.GE576_DES_RETORNO_ARQ_H, GE576.DCLGE_RETORNO_ARQ_H_SAP.GE576_DES_RETORNO_ARQ_H);
                _.Move(C10.C10_QTD, AREA_DE_WORK.C10_QTD);
            }

        }

        [StopWatch]
        /*" R0105-00-FETCH-C10-DB-CLOSE-1 */
        public void R0105_00_FETCH_C10_DB_CLOSE_1()
        {
            /*" -2576- EXEC SQL CLOSE C10 END-EXEC */

            C10.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0105_99_SAIDA*/

        [StopWatch]
        /*" R0106-00-GRAVA-LC-C10-SECTION */
        private void R0106_00_GRAVA_LC_C10_SECTION()
        {
            /*" -2600- MOVE '0106' TO WNR-EXEC-SQL. */
            _.Move("0106", WABEND.WNR_EXEC_SQL);

            /*" -2601- WRITE REG-CPB100S1 FROM LC1-C10. */
            _.Move(WS_ARQUIVO.LC1_C10.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2602- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2603- WRITE REG-CPB100S1 FROM LC2-C10. */
            _.Move(WS_ARQUIVO.LC2_C10.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2604- WRITE REG-CP100T08 FROM LC2-C10. */
            _.Move(WS_ARQUIVO.LC2_C10.GetMoveValues(), REG_CP100T08);

            CP100T08.Write(REG_CP100T08.GetMoveValues().ToString());

            /*" -2606- WRITE REG-CPB100S1 FROM LC3-C10. */
            _.Move(WS_ARQUIVO.LC3_C10.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2606- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0106_99_SAIDA*/

        [StopWatch]
        /*" R0110-00-TRATA-CURSOR11-SECTION */
        private void R0110_00_TRATA_CURSOR11_SECTION()
        {
            /*" -2618- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", WABEND.WNR_EXEC_SQL);

            /*" -2620- PERFORM R0110_00_TRATA_CURSOR11_DB_OPEN_1 */

            R0110_00_TRATA_CURSOR11_DB_OPEN_1();

            /*" -2623- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2624- DISPLAY 'R0110 - ERRO NO OPEN DO CURSOR C11' */
                _.Display($"R0110 - ERRO NO OPEN DO CURSOR C11");

                /*" -2625- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2627- END-IF. */
            }


            /*" -2629- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2631- PERFORM R0116-00-GRAVA-LC-C11. */

            R0116_00_GRAVA_LC_C11_SECTION();

            /*" -2633- PERFORM R0115-00-FETCH-C11. */

            R0115_00_FETCH_C11_SECTION();

            /*" -2634- PERFORM UNTIL WFIM-C11 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C11 == "S"))
            {

                /*" -2635- MOVE GE597-NOM-EXTERNO-ARQUIVO TO LDC11-NOM-EXT-ARQ */
                _.Move(GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_NOM_EXTERNO_ARQUIVO, WS_ARQUIVO.LDC11.LDC11_NOM_EXT_ARQ);

                /*" -2636- MOVE GE597-NUM-NSA-SAP TO GDA-NUM-NSA-SAP */
                _.Move(GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_NUM_NSA_SAP, AREA_DE_WORK.GDA_NUM_NSA_SAP);

                /*" -2637- MOVE GDA-NUM-NSA-SAP TO LDC11-NUM-NSA-SAP */
                _.Move(AREA_DE_WORK.GDA_NUM_NSA_SAP, WS_ARQUIVO.LDC11.LDC11_NUM_NSA_SAP);

                /*" -2638- MOVE GE597-SEQ-REGISTRO TO GDA-SEQ-REGISTRO */
                _.Move(GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_SEQ_REGISTRO, AREA_DE_WORK.GDA_SEQ_REGISTRO);

                /*" -2639- MOVE GDA-SEQ-REGISTRO TO LDC11-SEQ-REGISTRO */
                _.Move(AREA_DE_WORK.GDA_SEQ_REGISTRO, WS_ARQUIVO.LDC11.LDC11_SEQ_REGISTRO);

                /*" -2640- MOVE GE597-DES-REJEICAO-TEXT TO LDC11-DES-REJ */
                _.Move(GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_DES_REJEICAO.GE597_DES_REJEICAO_TEXT, WS_ARQUIVO.LDC11.LDC11_DES_REJ);

                /*" -2641- MOVE GE597-STA-REJEICAO TO LDC11-STA-REJ */
                _.Move(GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_STA_REJEICAO, WS_ARQUIVO.LDC11.LDC11_STA_REJ);

                /*" -2642- MOVE GE597-DTH-ATUALIZACAO TO LDC11-DTH-ATU */
                _.Move(GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_DTH_ATUALIZACAO, WS_ARQUIVO.LDC11.LDC11_DTH_ATU);

                /*" -2643- WRITE REG-CPB100S1 FROM LDC11 */
                _.Move(WS_ARQUIVO.LDC11.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2644- WRITE REG-CP100T09 FROM LDC11 */
                _.Move(WS_ARQUIVO.LDC11.GetMoveValues(), REG_CP100T09);

                CP100T09.Write(REG_CP100T09.GetMoveValues().ToString());

                /*" -2645- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2646- PERFORM R0115-00-FETCH-C11 */

                R0115_00_FETCH_C11_SECTION();

                /*" -2648- END-PERFORM. */
            }

            /*" -2649- IF AC-L-C11 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C11 == 00)
            {

                /*" -2650- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2651- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2652- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2652- END-IF. */
            }


        }

        [StopWatch]
        /*" R0110-00-TRATA-CURSOR11-DB-OPEN-1 */
        public void R0110_00_TRATA_CURSOR11_DB_OPEN_1()
        {
            /*" -2620- EXEC SQL OPEN C11 END-EXEC. */

            C11.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_99_SAIDA*/

        [StopWatch]
        /*" R0115-00-FETCH-C11-SECTION */
        private void R0115_00_FETCH_C11_SECTION()
        {
            /*" -2664- MOVE '0115' TO WNR-EXEC-SQL. */
            _.Move("0115", WABEND.WNR_EXEC_SQL);

            /*" -2666- MOVE SPACES TO GE597-DES-REJEICAO-TEXT. */
            _.Move("", GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_DES_REJEICAO.GE597_DES_REJEICAO_TEXT);

            /*" -2673- PERFORM R0115_00_FETCH_C11_DB_FETCH_1 */

            R0115_00_FETCH_C11_DB_FETCH_1();

            /*" -2676- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2677- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2678- MOVE 'S' TO WFIM-C11 */
                    _.Move("S", AREA_DE_WORK.WFIM_C11);

                    /*" -2678- PERFORM R0115_00_FETCH_C11_DB_CLOSE_1 */

                    R0115_00_FETCH_C11_DB_CLOSE_1();

                    /*" -2680- GO TO R0115-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_99_SAIDA*/ //GOTO
                    return;

                    /*" -2681- ELSE */
                }
                else
                {


                    /*" -2682- DISPLAY 'R0115 - ERRO NO FETCH DO CURSOR11' */
                    _.Display($"R0115 - ERRO NO FETCH DO CURSOR11");

                    /*" -2683- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2684- END-IF */
                }


                /*" -2685- ELSE */
            }
            else
            {


                /*" -2686- ADD 1 TO AC-L-C11 */
                AREA_DE_WORK.AC_L_C11.Value = AREA_DE_WORK.AC_L_C11 + 1;

                /*" -2688- END-IF. */
            }


            /*" -2689- IF VIND-NUM-NSA-SAP EQUAL -1 */

            if (AREA_DE_WORK.VIND_NUM_NSA_SAP == -1)
            {

                /*" -2690- MOVE ZEROS TO GE597-NUM-NSA-SAP */
                _.Move(0, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_NUM_NSA_SAP);

                /*" -2692- END-IF. */
            }


            /*" -2693- IF VIND-SEQ-REGISTRO EQUAL -1 */

            if (AREA_DE_WORK.VIND_SEQ_REGISTRO == -1)
            {

                /*" -2694- MOVE ZEROS TO GE597-SEQ-REGISTRO */
                _.Move(0, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_SEQ_REGISTRO);

                /*" -2694- END-IF. */
            }


        }

        [StopWatch]
        /*" R0115-00-FETCH-C11-DB-FETCH-1 */
        public void R0115_00_FETCH_C11_DB_FETCH_1()
        {
            /*" -2673- EXEC SQL FETCH C11 INTO :GE597-NOM-EXTERNO-ARQUIVO ,:GE597-NUM-NSA-SAP :VIND-NUM-NSA-SAP ,:GE597-SEQ-REGISTRO :VIND-SEQ-REGISTRO ,:GE597-DES-REJEICAO ,:GE597-STA-REJEICAO ,:GE597-DTH-ATUALIZACAO END-EXEC. */

            if (C11.Fetch())
            {
                _.Move(C11.GE597_NOM_EXTERNO_ARQUIVO, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_NOM_EXTERNO_ARQUIVO);
                _.Move(C11.GE597_NUM_NSA_SAP, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_NUM_NSA_SAP);
                _.Move(C11.VIND_NUM_NSA_SAP, AREA_DE_WORK.VIND_NUM_NSA_SAP);
                _.Move(C11.GE597_SEQ_REGISTRO, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_SEQ_REGISTRO);
                _.Move(C11.VIND_SEQ_REGISTRO, AREA_DE_WORK.VIND_SEQ_REGISTRO);
                _.Move(C11.GE597_DES_REJEICAO, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_DES_REJEICAO);
                _.Move(C11.GE597_STA_REJEICAO, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_STA_REJEICAO);
                _.Move(C11.GE597_DTH_ATUALIZACAO, GE597.DCLGE_ARQ_H_SAP_REJEITADO.GE597_DTH_ATUALIZACAO);
            }

        }

        [StopWatch]
        /*" R0115-00-FETCH-C11-DB-CLOSE-1 */
        public void R0115_00_FETCH_C11_DB_CLOSE_1()
        {
            /*" -2678- EXEC SQL CLOSE C11 END-EXEC */

            C11.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0115_99_SAIDA*/

        [StopWatch]
        /*" R0116-00-GRAVA-LC-C11-SECTION */
        private void R0116_00_GRAVA_LC_C11_SECTION()
        {
            /*" -2706- MOVE '0116' TO WNR-EXEC-SQL. */
            _.Move("0116", WABEND.WNR_EXEC_SQL);

            /*" -2707- WRITE REG-CPB100S1 FROM LC1-C11. */
            _.Move(WS_ARQUIVO.LC1_C11.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2708- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2709- WRITE REG-CPB100S1 FROM LC2-C11. */
            _.Move(WS_ARQUIVO.LC2_C11.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2710- WRITE REG-CP100T09 FROM LC2-C11. */
            _.Move(WS_ARQUIVO.LC2_C11.GetMoveValues(), REG_CP100T09);

            CP100T09.Write(REG_CP100T09.GetMoveValues().ToString());

            /*" -2712- WRITE REG-CPB100S1 FROM LC3-C11. */
            _.Move(WS_ARQUIVO.LC3_C11.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2712- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0116_99_SAIDA*/

        [StopWatch]
        /*" R0120-00-TRATA-CURSOR12-SECTION */
        private void R0120_00_TRATA_CURSOR12_SECTION()
        {
            /*" -2724- MOVE '0120' TO WNR-EXEC-SQL. */
            _.Move("0120", WABEND.WNR_EXEC_SQL);

            /*" -2726- PERFORM R0120_00_TRATA_CURSOR12_DB_OPEN_1 */

            R0120_00_TRATA_CURSOR12_DB_OPEN_1();

            /*" -2729- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2730- DISPLAY 'R0120 - ERRO NO OPEN DO CURSOR C12' */
                _.Display($"R0120 - ERRO NO OPEN DO CURSOR C12");

                /*" -2731- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2733- END-IF. */
            }


            /*" -2735- PERFORM R3000-00-GRAVA-LCTIT. */

            R3000_00_GRAVA_LCTIT_SECTION();

            /*" -2737- PERFORM R0126-00-GRAVA-LC-C12. */

            R0126_00_GRAVA_LC_C12_SECTION();

            /*" -2739- PERFORM R0125-00-FETCH-C12. */

            R0125_00_FETCH_C12_SECTION();

            /*" -2740- PERFORM UNTIL WFIM-C12 EQUAL 'S' */

            while (!(AREA_DE_WORK.WFIM_C12 == "S"))
            {

                /*" -2741- MOVE GE541-DTA-GERACAO-ARQ TO LDC12-DTA-GERA-ARQ */
                _.Move(GE541.DCLGE_CONTROL_ARQ_H_SAP.GE541_DTA_GERACAO_ARQ, WS_ARQUIVO.LDC12.LDC12_DTA_GERA_ARQ);

                /*" -2742- MOVE C12-QTD TO GDA-QTD */
                _.Move(AREA_DE_WORK.C12_QTD, AREA_DE_WORK.GDA_QTD);

                /*" -2743- MOVE GDA-QTD TO LDC12-QTD */
                _.Move(AREA_DE_WORK.GDA_QTD, WS_ARQUIVO.LDC12.LDC12_QTD);

                /*" -2744- WRITE REG-CPB100S1 FROM LDC12 */
                _.Move(WS_ARQUIVO.LDC12.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2745- WRITE REG-CP100T10 FROM LDC12 */
                _.Move(WS_ARQUIVO.LDC12.GetMoveValues(), REG_CP100T10);

                CP100T10.Write(REG_CP100T10.GetMoveValues().ToString());

                /*" -2746- ADD 1 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 1;

                /*" -2747- PERFORM R0125-00-FETCH-C12 */

                R0125_00_FETCH_C12_SECTION();

                /*" -2749- END-PERFORM. */
            }

            /*" -2750- IF AC-L-C12 EQUAL ZEROS */

            if (AREA_DE_WORK.AC_L_C12 == 00)
            {

                /*" -2751- WRITE REG-CPB100S1 FROM LCSPA */
                _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2752- WRITE REG-CPB100S1 FROM LD-SEM-OCOR */
                _.Move(WS_ARQUIVO.LD_SEM_OCOR.GetMoveValues(), REG_CPB100S1);

                CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                /*" -2753- ADD 2 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 2;

                /*" -2753- END-IF. */
            }


        }

        [StopWatch]
        /*" R0120-00-TRATA-CURSOR12-DB-OPEN-1 */
        public void R0120_00_TRATA_CURSOR12_DB_OPEN_1()
        {
            /*" -2726- EXEC SQL OPEN C12 END-EXEC. */

            C12.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0120_99_SAIDA*/

        [StopWatch]
        /*" R0125-00-FETCH-C12-SECTION */
        private void R0125_00_FETCH_C12_SECTION()
        {
            /*" -2765- MOVE '0125' TO WNR-EXEC-SQL. */
            _.Move("0125", WABEND.WNR_EXEC_SQL);

            /*" -2768- PERFORM R0125_00_FETCH_C12_DB_FETCH_1 */

            R0125_00_FETCH_C12_DB_FETCH_1();

            /*" -2771- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2772- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2773- MOVE 'S' TO WFIM-C12 */
                    _.Move("S", AREA_DE_WORK.WFIM_C12);

                    /*" -2773- PERFORM R0125_00_FETCH_C12_DB_CLOSE_1 */

                    R0125_00_FETCH_C12_DB_CLOSE_1();

                    /*" -2775- GO TO R0125-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_99_SAIDA*/ //GOTO
                    return;

                    /*" -2776- ELSE */
                }
                else
                {


                    /*" -2777- DISPLAY 'R0125 - ERRO NO FETCH DO CURSOR12' */
                    _.Display($"R0125 - ERRO NO FETCH DO CURSOR12");

                    /*" -2778- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2779- END-IF */
                }


                /*" -2780- ELSE */
            }
            else
            {


                /*" -2781- ADD 1 TO AC-L-C12 */
                AREA_DE_WORK.AC_L_C12.Value = AREA_DE_WORK.AC_L_C12 + 1;

                /*" -2781- END-IF. */
            }


        }

        [StopWatch]
        /*" R0125-00-FETCH-C12-DB-FETCH-1 */
        public void R0125_00_FETCH_C12_DB_FETCH_1()
        {
            /*" -2768- EXEC SQL FETCH C12 INTO :GE541-DTA-GERACAO-ARQ, :C12-QTD END-EXEC. */

            if (C12.Fetch())
            {
                _.Move(C12.GE541_DTA_GERACAO_ARQ, GE541.DCLGE_CONTROL_ARQ_H_SAP.GE541_DTA_GERACAO_ARQ);
                _.Move(C12.C12_QTD, AREA_DE_WORK.C12_QTD);
            }

        }

        [StopWatch]
        /*" R0125-00-FETCH-C12-DB-CLOSE-1 */
        public void R0125_00_FETCH_C12_DB_CLOSE_1()
        {
            /*" -2773- EXEC SQL CLOSE C12 END-EXEC */

            C12.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0125_99_SAIDA*/

        [StopWatch]
        /*" R0126-00-GRAVA-LC-C12-SECTION */
        private void R0126_00_GRAVA_LC_C12_SECTION()
        {
            /*" -2793- MOVE '0126' TO WNR-EXEC-SQL. */
            _.Move("0126", WABEND.WNR_EXEC_SQL);

            /*" -2794- WRITE REG-CPB100S1 FROM LC1-C12. */
            _.Move(WS_ARQUIVO.LC1_C12.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2795- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2796- WRITE REG-CPB100S1 FROM LC2-C12. */
            _.Move(WS_ARQUIVO.LC2_C12.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2797- WRITE REG-CP100T10 FROM LC2-C12. */
            _.Move(WS_ARQUIVO.LC2_C12.GetMoveValues(), REG_CP100T10);

            CP100T10.Write(REG_CP100T10.GetMoveValues().ToString());

            /*" -2799- WRITE REG-CPB100S1 FROM LC3-C12. */
            _.Move(WS_ARQUIVO.LC3_C12.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2799- ADD 4 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 4;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0126_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-GRAVA-LCTIT-SECTION */
        private void R3000_00_GRAVA_LCTIT_SECTION()
        {
            /*" -2811- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -2812- IF AC-G-CPB100S1 NOT EQUAL ZEROS */

            if (AREA_DE_WORK.AC_G_CPB100S1 != 00)
            {

                /*" -2813- PERFORM 15 TIMES */

                for (int i = 0; i < 15; i++)
                {

                    /*" -2814- WRITE REG-CPB100S1 FROM LCSPA */
                    _.Move(WS_ARQUIVO.LCSPA.GetMoveValues(), REG_CPB100S1);

                    CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

                    /*" -2815- END-PERFORM */
                }

                /*" -2816- ADD 15 TO AC-G-CPB100S1 */
                AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 15;

                /*" -2818- END-IF. */
            }


            /*" -2819- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2820- WRITE REG-CPB100S1 FROM LCTIT. */
            _.Move(WS_ARQUIVO.LCTIT.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2822- WRITE REG-CPB100S1 FROM LCHIF. */
            _.Move(WS_ARQUIVO.LCHIF.GetMoveValues(), REG_CPB100S1);

            CPB100S1.Write(REG_CPB100S1.GetMoveValues().ToString());

            /*" -2822- ADD 3 TO AC-G-CPB100S1. */
            AREA_DE_WORK.AC_G_CPB100S1.Value = AREA_DE_WORK.AC_G_CPB100S1 + 3;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2838- CLOSE CPB100S1 CP100T01 CP100T02 CP100T03 CP100T04 CP100T05 CP100T67 CP100T08 CP100T09 CP100T10. */
            CPB100S1.Close();
            CP100T01.Close();
            CP100T02.Close();
            CP100T03.Close();
            CP100T04.Close();
            CP100T05.Close();
            CP100T67.Close();
            CP100T08.Close();
            CP100T09.Close();
            CP100T10.Close();

            /*" -2840- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -2842- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -2844- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2844- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}