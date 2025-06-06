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
using Sias.Bilhetes.DB2.BI1630B;

namespace Code
{
    public class BI1630B
    {
        public bool IsCall { get; set; }

        public BI1630B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  BI - BILHETES                      *      */
        /*"      *   PROGRAMA ...............  BI1630B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  CANETTA                            *      */
        /*"      *   PROGRAMADOR ............  CANETTA                            *      */
        /*"      *   DATA CODIFICACAO .......  04/2024                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  TRATAR BILHETES                    *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACOES                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.03  * VERSAO 03 EM 31/07/2024 - JAZZ 575149 - APOIO + FUTURO         *      */
        /*"      *        CORRECAO NO UPDATE DA SEGUROS.NUMERO_OUTROS             *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.03                        CANETTA             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.02  * VERSAO 02 EM 12/07/2024 - JAZZ 575149 - APOIO + FUTURO         *      */
        /*"      *        INSERT/UPDATE CLIENTES_EMAIL                            *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.02                        CANETTA             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.01  * VERSAO 01 EM 05/07/2024 - JAZZ 575149 - APOIO + FUTURO         *      */
        /*"      *        CORRECAO COD-CBO                                        *      */
        /*"      *        CURSOR   (ENV/POB)                                      *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.01                        CANETTA             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.00  * VERSAO XX EM XX/XXXX - JAZZ XXXXXX                             *      */
        /*"      *   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.00                        XXXXXXX             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01           WS-WORKING.*/
        public BI1630B_WS_WORKING WS_WORKING { get; set; } = new BI1630B_WS_WORKING();
        public class BI1630B_WS_WORKING : VarBasis
        {
            /*"  03         AC-CONTADORES.*/
            public BI1630B_AC_CONTADORES AC_CONTADORES { get; set; } = new BI1630B_AC_CONTADORES();
            public class BI1630B_AC_CONTADORES : VarBasis
            {
                /*"    05       AC-PRO-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_PRO_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-BIL-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_BIL_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-RCA-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_RCA_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-PRO-ATU         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_PRO_ATU { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-SAS-ATU         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_SAS_ATU { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-PES-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_PES_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-CLI-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_CLI_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-CLI-GRV         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_CLI_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-END-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_END_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-END-GRV         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_END_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-EMA-LID         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_EMA_LID { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-EMA-ALT         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_EMA_ALT { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-EMA-GRV         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_EMA_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-GED-GRV         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_GED_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-GEC-ALT         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_GEC_ALT { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-GEC-GRV         PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_GEC_GRV { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-PRO-LIB-EMI     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_PRO_LIB_EMI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-ERR-CRI     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_ERR_CRI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-DES-CRI     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_DES_CRI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-EMI-RIS     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_EMI_RIS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-QTD-EMI-SRI     PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_QTD_EMI_SRI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       AC-PF-CBO          PIC S9(005)    VALUE +0  COMP-3.*/
                public IntBasis AC_PF_CBO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"  03         WS-AUXILIARES.*/
            }
            public BI1630B_WS_AUXILIARES WS_AUXILIARES { get; set; } = new BI1630B_WS_AUXILIARES();
            public class BI1630B_WS_AUXILIARES : VarBasis
            {
                /*"    05       WS-SQLCODE         PIC   ---9.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05       WS-SIT-ATU-BIL     PIC  X(003)    VALUE '***'.*/
                public StringBasis WS_SIT_ATU_BIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"***");
                /*"    05       WS-COD-PESSOA      PIC  9(009)    VALUE ZEROS.*/
                public IntBasis WS_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
                /*"    05       WS-COD-ERR-BIL     PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis WS_COD_ERR_BIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-PLA-LID-ANT     PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis WS_PLA_LID_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-PRD-SIA-ANT     PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis WS_PRD_SIA_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-PRD-SIV-ANT     PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis WS_PRD_SIV_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-DAT-LID-ANT     PIC  X(010)    VALUE SPACES.*/
                public StringBasis WS_DAT_LID_ANT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       WS-COD-CLI-ATU     PIC S9(009)    VALUE +0 COMP-3.*/
                public IntBasis WS_COD_CLI_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       WS-OCC-END-ATU     PIC S9(004)    VALUE +0 COMP-3.*/
                public IntBasis WS_OCC_END_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-SEQ-EMA-ATU     PIC S9(004)    VALUE +0 COMP-3.*/
                public IntBasis WS_SEQ_EMA_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-OCC-CMO-ATU     PIC S9(004)    VALUE +0 COMP-3.*/
                public IntBasis WS_OCC_CMO_ATU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-SIT-BIL         PIC  X(001)    VALUE '&'.*/
                public StringBasis WS_SIT_BIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"&");
                /*"    05       WS-SIT-PRO         PIC  X(003)    VALUE '&&&'.*/
                public StringBasis WS_SIT_PRO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"&&&");
                /*"    05       WS-SIT-ENV         PIC  X(001)    VALUE '&'.*/
                public StringBasis WS_SIT_ENV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"&");
                /*"    05       WS-PGM-CALL        PIC  X(008)    VALUE ALL '*'.*/
                public StringBasis WS_PGM_CALL { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"ALL");
                /*"    05       WS-ANO-BASE        PIC S9(004)    VALUE +0  COMP-3.*/
                public IntBasis WS_ANO_BASE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-ANO-NASC        PIC S9(004)    VALUE +0  COMP-3.*/
                public IntBasis WS_ANO_NASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-IDADE           PIC S9(004)    VALUE +0  COMP-3.*/
                public IntBasis WS_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-COD-CRI         PIC  9(005)    VALUE ZEROS.*/
                public IntBasis WS_COD_CRI { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
                /*"    05       VIND-DAT-NAS       PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_DAT_NAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-UF-EXP        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_UF_EXP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL01        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL02        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL03        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL03 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL04        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL04 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL05        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL05 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL06        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL06 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL07        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL07 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL08        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL08 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL09        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL09 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL10        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL10 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL11        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL11 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL12        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL12 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL13        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL13 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL14        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL14 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL15        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL15 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL16        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL16 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL17        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL17 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL18        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL18 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL19        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL19 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL20        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL20 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL21        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL21 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-DATA-PROC-AUX   PIC  X(010)    VALUE SPACES.*/
                public StringBasis WS_DATA_PROC_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       WS-DATA-PROC       PIC  X(010)    VALUE SPACES.*/
                public StringBasis WS_DATA_PROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    05       FILLER  REDEFINES  WS-DATA-PROC.*/
                private _REDEF_BI1630B_FILLER_0 _filler_0 { get; set; }
                public _REDEF_BI1630B_FILLER_0 FILLER_0
                {
                    get { _filler_0 = new _REDEF_BI1630B_FILLER_0(); _.Move(WS_DATA_PROC, _filler_0); VarBasis.RedefinePassValue(WS_DATA_PROC, _filler_0, WS_DATA_PROC); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS_DATA_PROC); }; return _filler_0; }
                    set { VarBasis.RedefinePassValue(value, _filler_0, WS_DATA_PROC); }
                }  //Redefines
                public class _REDEF_BI1630B_FILLER_0 : VarBasis
                {
                    /*"      07     WS-ANO-PROC        PIC  9(004).*/
                    public IntBasis WS_ANO_PROC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-PROC        PIC  9(002).*/
                    public IntBasis WS_MES_PROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-PROC        PIC  9(002).*/
                    public IntBasis WS_DIA_PROC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-AAAAMMDD   PIC  9(008).*/

                    public _REDEF_BI1630B_FILLER_0()
                    {
                        WS_ANO_PROC.ValueChanged += OnValueChanged;
                        FILLER_1.ValueChanged += OnValueChanged;
                        WS_MES_PROC.ValueChanged += OnValueChanged;
                        FILLER_2.ValueChanged += OnValueChanged;
                        WS_DIA_PROC.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WS_DATA_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05       FILLER  REDEFINES  WS-DATA-AAAAMMDD.*/
                private _REDEF_BI1630B_FILLER_3 _filler_3 { get; set; }
                public _REDEF_BI1630B_FILLER_3 FILLER_3
                {
                    get { _filler_3 = new _REDEF_BI1630B_FILLER_3(); _.Move(WS_DATA_AAAAMMDD, _filler_3); VarBasis.RedefinePassValue(WS_DATA_AAAAMMDD, _filler_3, WS_DATA_AAAAMMDD); _filler_3.ValueChanged += () => { _.Move(_filler_3, WS_DATA_AAAAMMDD); }; return _filler_3; }
                    set { VarBasis.RedefinePassValue(value, _filler_3, WS_DATA_AAAAMMDD); }
                }  //Redefines
                public class _REDEF_BI1630B_FILLER_3 : VarBasis
                {
                    /*"      07     WS-ANO-AAAAMMDD    PIC  9(004).*/
                    public IntBasis WS_ANO_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     WS-MES-AAAAMMDD    PIC  9(002).*/
                    public IntBasis WS_MES_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-DIA-AAAAMMDD    PIC  9(002).*/
                    public IntBasis WS_DIA_AAAAMMDD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-DATA-DDMMAAAA   PIC  9(008).*/

                    public _REDEF_BI1630B_FILLER_3()
                    {
                        WS_ANO_AAAAMMDD.ValueChanged += OnValueChanged;
                        WS_MES_AAAAMMDD.ValueChanged += OnValueChanged;
                        WS_DIA_AAAAMMDD.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis WS_DATA_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05       FILLER  REDEFINES  WS-DATA-DDMMAAAA.*/
                private _REDEF_BI1630B_FILLER_4 _filler_4 { get; set; }
                public _REDEF_BI1630B_FILLER_4 FILLER_4
                {
                    get { _filler_4 = new _REDEF_BI1630B_FILLER_4(); _.Move(WS_DATA_DDMMAAAA, _filler_4); VarBasis.RedefinePassValue(WS_DATA_DDMMAAAA, _filler_4, WS_DATA_DDMMAAAA); _filler_4.ValueChanged += () => { _.Move(_filler_4, WS_DATA_DDMMAAAA); }; return _filler_4; }
                    set { VarBasis.RedefinePassValue(value, _filler_4, WS_DATA_DDMMAAAA); }
                }  //Redefines
                public class _REDEF_BI1630B_FILLER_4 : VarBasis
                {
                    /*"      07     WS-DIA-DDMMAAAA    PIC  9(002).*/
                    public IntBasis WS_DIA_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-MES-DDMMAAAA    PIC  9(002).*/
                    public IntBasis WS_MES_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     WS-ANO-DDMMAAAA    PIC  9(004).*/
                    public IntBasis WS_ANO_DDMMAAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"    05       WS-DATA-DB2        PIC  X(010)   VALUE '0000-00-00'*/

                    public _REDEF_BI1630B_FILLER_4()
                    {
                        WS_DIA_DDMMAAAA.ValueChanged += OnValueChanged;
                        WS_MES_DDMMAAAA.ValueChanged += OnValueChanged;
                        WS_ANO_DDMMAAAA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_DATA_DB2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"0000-00-00");
                /*"    05       FILLER  REDEFINES  WS-DATA-DB2.*/
                private _REDEF_BI1630B_FILLER_5 _filler_5 { get; set; }
                public _REDEF_BI1630B_FILLER_5 FILLER_5
                {
                    get { _filler_5 = new _REDEF_BI1630B_FILLER_5(); _.Move(WS_DATA_DB2, _filler_5); VarBasis.RedefinePassValue(WS_DATA_DB2, _filler_5, WS_DATA_DB2); _filler_5.ValueChanged += () => { _.Move(_filler_5, WS_DATA_DB2); }; return _filler_5; }
                    set { VarBasis.RedefinePassValue(value, _filler_5, WS_DATA_DB2); }
                }  //Redefines
                public class _REDEF_BI1630B_FILLER_5 : VarBasis
                {
                    /*"      07     WS-ANO-DB2         PIC  9(004).*/
                    public IntBasis WS_ANO_DB2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-MES-DB2         PIC  9(002).*/
                    public IntBasis WS_MES_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      07     FILLER             PIC  X(001).*/
                    public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"      07     WS-DIA-DB2         PIC  9(002).*/
                    public IntBasis WS_DIA_DB2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05       WS-ORIGEM-PROPOSTA PIC  9(002).*/

                    public _REDEF_BI1630B_FILLER_5()
                    {
                        WS_ANO_DB2.ValueChanged += OnValueChanged;
                        FILLER_6.ValueChanged += OnValueChanged;
                        WS_MES_DB2.ValueChanged += OnValueChanged;
                        FILLER_7.ValueChanged += OnValueChanged;
                        WS_DIA_DB2.ValueChanged += OnValueChanged;
                    }

                }

                public SelectorBasis WS_ORIGEM_PROPOSTA { get; set; } = new SelectorBasis("002")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     ORIGEM-SIGPF                      VALUE 01. */
							new SelectorItemBasis("ORIGEM_SIGPF", "01"),
							/*" 88     ORIIGEM-CAIXA-PREV                VALUE 02. */
							new SelectorItemBasis("ORIIGEM_CAIXA_PREV", "02"),
							/*" 88     ORIGEM-SIGAT                      VALUE 03. */
							new SelectorItemBasis("ORIGEM_SIGAT", "03"),
							/*" 88     ORIGEM-SASSE                      VALUE 04. */
							new SelectorItemBasis("ORIGEM_SASSE", "04"),
							/*" 88     ORIGEM-CAIXA-CAP                  VALUE 05. */
							new SelectorItemBasis("ORIGEM_CAIXA_CAP", "05"),
							/*" 88     ORIGEM-MANUAL                     VALUE 06. */
							new SelectorItemBasis("ORIGEM_MANUAL", "06"),
							/*" 88     ORIGEM-REMOTA                     VALUE 07. */
							new SelectorItemBasis("ORIGEM_REMOTA", "07"),
							/*" 88     ORIGEM-INTRANET                   VALUE 08. */
							new SelectorItemBasis("ORIGEM_INTRANET", "08"),
							/*" 88     ORIGEM-INTERNET                   VALUE 09. */
							new SelectorItemBasis("ORIGEM_INTERNET", "09"),
							/*" 88     ORIGEM-CORRET-VIT                 VALUE 10. */
							new SelectorItemBasis("ORIGEM_CORRET_VIT", "10"),
							/*" 88     ORIGEM-FILIAL                     VALUE 11. */
							new SelectorItemBasis("ORIGEM_FILIAL", "11"),
							/*" 88     ORIGEM-MARSH                      VALUE 12. */
							new SelectorItemBasis("ORIGEM_MARSH", "12"),
							/*" 88     ORIGEM-LOTERICO                   VALUE 13. */
							new SelectorItemBasis("ORIGEM_LOTERICO", "13"),
							/*" 88     ORIGEM-CORRESPOND                 VALUE 14. */
							new SelectorItemBasis("ORIGEM_CORRESPOND", "14"),
							/*" 88     ORIGEM-LOTERICO-SISPL             VALUE 15. */
							new SelectorItemBasis("ORIGEM_LOTERICO_SISPL", "15"),
							/*" 88     ORIGEM-CCA                        VALUE 22. */
							new SelectorItemBasis("ORIGEM_CCA", "22"),
							/*" 88     ORIGEM-SIPEN-CAIXATEM             VALUE 17. */
							new SelectorItemBasis("ORIGEM_SIPEN_CAIXATEM", "17"),
							/*" 88     ORIGEM-ATM                        VALUE 34. */
							new SelectorItemBasis("ORIGEM_ATM", "34")
                }
                };

                /*"    05       WS-NUM-PROPOSTA    PIC 9(014).*/
                public IntBasis WS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
                /*"    05       CANAL  REDEFINES   WS-NUM-PROPOSTA.*/
                private _REDEF_BI1630B_CANAL _canal { get; set; }
                public _REDEF_BI1630B_CANAL CANAL
                {
                    get { _canal = new _REDEF_BI1630B_CANAL(); _.Move(WS_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(WS_NUM_PROPOSTA, _canal, WS_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, WS_NUM_PROPOSTA); }; return _canal; }
                    set { VarBasis.RedefinePassValue(value, _canal, WS_NUM_PROPOSTA); }
                }  //Redefines
                public class _REDEF_BI1630B_CANAL : VarBasis
                {
                    /*"      07     W-CANAL-PROPOSTA   PIC 9(001).*/

                    public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                    {
                        Items = new List<SelectorItemBasis> {
                            /*" 88   CANAL-PAPEL                       VALUE 0. */
							new SelectorItemBasis("CANAL_PAPEL", "0"),
							/*" 88   CANAL-CEF                         VALUE 1. */
							new SelectorItemBasis("CANAL_CEF", "1"),
							/*" 88   CANAL-SASSE                       VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE", "2"),
							/*" 88   CANAL-CORRETOR                    VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88   CANAL-ATM                         VALUE 4. */
							new SelectorItemBasis("CANAL_ATM", "4"),
							/*" 88   CANAL-GITEL                       VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88   CANAL-INTERNET                    VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88   CANAL-INTRANET                    VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
                    };

                    /*"      07     FILLER             PIC  9(013).*/
                    public IntBasis FILLER_8 { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                    /*"  03         INDEXADORES.*/

                    public _REDEF_BI1630B_CANAL()
                    {
                        W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                        FILLER_8.ValueChanged += OnValueChanged;
                    }

                }
            }
            public BI1630B_INDEXADORES INDEXADORES { get; set; } = new BI1630B_INDEXADORES();
            public class BI1630B_INDEXADORES : VarBasis
            {
                /*"    05       IND-ERR            PIC S9(005)    VALUE +0 COMP-3.*/
                public IntBasis IND_ERR { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       IND-AGE            PIC S9(005)    VALUE +0 COMP-3.*/
                public IntBasis IND_AGE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"    05       IND-CBO            PIC S9(005)    VALUE +0 COMP-3.*/
                public IntBasis IND_CBO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
                /*"  03         WS-NIVEIS-88.*/
            }
            public BI1630B_WS_NIVEIS_88 WS_NIVEIS_88 { get; set; } = new BI1630B_WS_NIVEIS_88();
            public class BI1630B_WS_NIVEIS_88 : VarBasis
            {
                /*"    05       N88-FIM-CURSOR-PRO PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_FIM_CURSOR_PRO { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     FIM-CURSOR-PRO                    VALUE     'S'. */
							new SelectorItemBasis("FIM_CURSOR_PRO", "S")
                }
                };

                /*"    05       N88-TEM-BILHETE    PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_TEM_BILHETE { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-BILHETE                       VALUE     'S'. */
							new SelectorItemBasis("TEM_BILHETE", "S")
                }
                };

                /*"    05       N88-FIM-AGENCIA    PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_FIM_AGENCIA { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     FIM-AGENCIA                       VALUE     'S'. */
							new SelectorItemBasis("FIM_AGENCIA", "S")
                }
                };

                /*"    05       N88-FIM-CBO        PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_FIM_CBO { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     FIM-CBO                           VALUE     'S'. */
							new SelectorItemBasis("FIM_CBO", "S")
                }
                };

                /*"    05       N88-RCAPS          PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_RCAPS { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-RCAP                          VALUE     'S'. */
							new SelectorItemBasis("TEM_RCAP", "S")
                }
                };

                /*"    05       N88-ERRO-NORMAL    PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_ERRO_NORMAL { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-ERRO-NORMAL                   VALUE     'S'. */
							new SelectorItemBasis("TEM_ERRO_NORMAL", "S")
                }
                };

                /*"    05       N88-ERRO-CRITICO   PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_ERRO_CRITICO { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-ERRO-CRITICO                  VALUE     'S'. */
							new SelectorItemBasis("TEM_ERRO_CRITICO", "S")
                }
                };

                /*"    05       N88-ACAO-CLI       PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_ACAO_CLI { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     INS-CLIENTE                       VALUE     'I'. */
							new SelectorItemBasis("INS_CLIENTE", "I"),
							/*" 88     ALT-CLIENTE                       VALUE     'A'. */
							new SelectorItemBasis("ALT_CLIENTE", "A")
                }
                };

                /*"    05       N88-CRITICA-VG001  PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_CRITICA_VG001 { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-CRITICA-VG001                 VALUE     'S'. */
							new SelectorItemBasis("TEM_CRITICA_VG001", "S")
                }
                };

                /*"    05       N88-CRITICA-VG009  PIC  X(001)    VALUE     '$'.*/

                public SelectorBasis N88_CRITICA_VG009 { get; set; } = new SelectorBasis("001", "$")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     TEM-CRITICA-VG009                 VALUE     'S'. */
							new SelectorItemBasis("TEM_CRITICA_VG009", "S")
                }
                };

                /*"01           DISPLAY-ABEND.*/
            }
        }
        public BI1630B_DISPLAY_ABEND DISPLAY_ABEND { get; set; } = new BI1630B_DISPLAY_ABEND();
        public class BI1630B_DISPLAY_ABEND : VarBasis
        {
            /*"  03         FILLER             PIC  X(010)    VALUE             'PF0600B  '.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0600B  ");
            /*"  03         FILLER             PIC  X(028)    VALUE             ' *** ERRO  EXEC SQL *** '.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
            /*"  03         FILLER             PIC  X(014)    VALUE             '    SQLCODE = '.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"  03         WSQLCODE           PIC  ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03         FILLER             PIC  X(014)    VALUE             '   SQLERRD1 = '.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"  03         WSQLERRD1          PIC  ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03         FILLER             PIC  X(014)    VALUE             '   SQLERRD2 = '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"  03         WSQLERRD2          PIC  ZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"  03         FILLER             PIC  X(014)    VALUE             '   SQLERRD2 = '.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"  03         LOCALIZA-ABEND-1.*/
            public BI1630B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new BI1630B_LOCALIZA_ABEND_1();
            public class BI1630B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"    05       FILLER             PIC  X(012)    VALUE             'PARAGRAFO = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"    05       PARAGRAFO          PIC  X(040)    VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03         LOCALIZA-ABEND-2.*/
            }
            public BI1630B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new BI1630B_LOCALIZA_ABEND_2();
            public class BI1630B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"    05       FILLER             PIC  X(012)    VALUE             'COMANDO   = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"    05       COMANDO            PIC  X(060)    VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"  03         WSQLERRO.*/
            }
            public BI1630B_WSQLERRO WSQLERRO { get; set; } = new BI1630B_WSQLERRO();
            public class BI1630B_WSQLERRO : VarBasis
            {
                /*"    05       FILLER             PIC  X(014)    VALUE             ' *** SQLERRMC '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05       WSQLERRMC          PIC  X(070)    VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"01           BI0005L-LINKAGE.*/
            }
        }
        public BI1630B_BI0005L_LINKAGE BI0005L_LINKAGE { get; set; } = new BI1630B_BI0005L_LINKAGE();
        public class BI1630B_BI0005L_LINKAGE : VarBasis
        {
            /*"  03         BI0005L-ENTRADA.*/
            public BI1630B_BI0005L_ENTRADA BI0005L_ENTRADA { get; set; } = new BI1630B_BI0005L_ENTRADA();
            public class BI1630B_BI0005L_ENTRADA : VarBasis
            {
                /*"    05       BI0005L-E-COD-PESSOA    PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_E_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  03         BI0005L-SAIDA.*/
            }
            public BI1630B_BI0005L_SAIDA BI0005L_SAIDA { get; set; } = new BI1630B_BI0005L_SAIDA();
            public class BI1630B_BI0005L_SAIDA : VarBasis
            {
                /*"    05       BI0005L-S-NOME-PESSOA   PIC  X(040).*/
                public StringBasis BI0005L_S_NOME_PESSOA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-TIPO-PESSOA   PIC  X(001).*/
                public StringBasis BI0005L_S_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-SIGLA-PESSOA  PIC  X(010).*/
                public StringBasis BI0005L_S_SIGLA_PESSOA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05       BI0005L-S-CPF           PIC S9(011)    COMP-3.*/
                public IntBasis BI0005L_S_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                /*"    05       BI0005L-S-DATA-NASC     PIC  X(010).*/
                public StringBasis BI0005L_S_DATA_NASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05       BI0005L-S-SEXO          PIC  X(001).*/
                public StringBasis BI0005L_S_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-ESTADO-CIVIL  PIC  X(001).*/
                public StringBasis BI0005L_S_ESTADO_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-NUM-IDENT     PIC  X(015).*/
                public StringBasis BI0005L_S_NUM_IDENT { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05       BI0005L-S-ORGAO-EXPED   PIC  X(005).*/
                public StringBasis BI0005L_S_ORGAO_EXPED { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05       BI0005L-S-UF-EXPEDIDORA PIC  X(002).*/
                public StringBasis BI0005L_S_UF_EXPEDIDORA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       BI0005L-S-DATA-EXPED    PIC  X(010).*/
                public StringBasis BI0005L_S_DATA_EXPED { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"    05       BI0005L-S-COD-CBO       PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_S_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       BI0005L-S-TIP-IDE-SIVPF PIC  X(005).*/
                public StringBasis BI0005L_S_TIP_IDE_SIVPF { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05       BI0005L-S-CGC           PIC S9(015)    COMP-3.*/
                public IntBasis BI0005L_S_CGC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"    05       BI0005L-S-NOME-FANTASIA PIC  X(040).*/
                public StringBasis BI0005L_S_NOME_FANTASIA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-ENDERECO-R    PIC  X(040).*/
                public StringBasis BI0005L_S_ENDERECO_R { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-TIPO-ENDER-R  PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_TIPO_ENDER_R { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-COMPL-ENDER-R PIC  X(015).*/
                public StringBasis BI0005L_S_COMPL_ENDER_R { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05       BI0005L-S-BAIRRO-R      PIC  X(020).*/
                public StringBasis BI0005L_S_BAIRRO_R { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-CEP-R         PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_S_CEP_R { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       BI0005L-S-CIDADE-R      PIC  X(020).*/
                public StringBasis BI0005L_S_CIDADE_R { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-SIGLA-UF-R    PIC  X(002).*/
                public StringBasis BI0005L_S_SIGLA_UF_R { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       BI0005L-S-SIT-ENDER-R   PIC  X(001).*/
                public StringBasis BI0005L_S_SIT_ENDER_R { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-OCC-END-R     PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_OCC_END_R { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-ENDERECO-C    PIC  X(040).*/
                public StringBasis BI0005L_S_ENDERECO_C { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-TIPO-ENDER-C  PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_TIPO_ENDER_C { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-COMPL-ENDER-C PIC  X(015).*/
                public StringBasis BI0005L_S_COMPL_ENDER_C { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"    05       BI0005L-S-BAIRRO-C      PIC  X(020).*/
                public StringBasis BI0005L_S_BAIRRO_C { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-CEP-C         PIC S9(009)    COMP-3.*/
                public IntBasis BI0005L_S_CEP_C { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       BI0005L-S-CIDADE-C      PIC  X(020).*/
                public StringBasis BI0005L_S_CIDADE_C { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05       BI0005L-S-SIGLA-UF-C    PIC  X(002).*/
                public StringBasis BI0005L_S_SIGLA_UF_C { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05       BI0005L-S-SIT-ENDER-C   PIC  X(001).*/
                public StringBasis BI0005L_S_SIT_ENDER_C { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-OCC-END-C     PIC S9(004)    COMP-3.*/
                public IntBasis BI0005L_S_OCC_END_C { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       BI0005L-S-EMAIL         PIC  X(040).*/
                public StringBasis BI0005L_S_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"    05       BI0005L-S-SIT-EMAIL     PIC  X(001).*/
                public StringBasis BI0005L_S_SIT_EMAIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05       BI0005L-S-TELEFONE      OCCURS    003       TIMES.*/
                public ListBasis<BI1630B_BI0005L_S_TELEFONE> BI0005L_S_TELEFONE { get; set; } = new ListBasis<BI1630B_BI0005L_S_TELEFONE>(003);
                public class BI1630B_BI0005L_S_TELEFONE : VarBasis
                {
                    /*"      07     BI0005L-S-TIPO-FONE     PIC S9(004)    COMP-3.*/
                    public IntBasis BI0005L_S_TIPO_FONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     BI0005L-S-DDI           PIC S9(004)    COMP-3.*/
                    public IntBasis BI0005L_S_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     BI0005L-S-DDD           PIC S9(004)    COMP-3.*/
                    public IntBasis BI0005L_S_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     BI0005L-S-NUM-FONE      PIC S9(011)    COMP-3.*/
                    public IntBasis BI0005L_S_NUM_FONE { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                    /*"      07     BI0005L-S-SIT-FONE      PIC  X(001).*/
                    public StringBasis BI0005L_S_SIT_FONE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                    /*"    05        BI0005L-S-COD-ERR       PIC S9(004)    COMP-3.*/
                }
                public IntBasis BI0005L_S_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05        BI0005L-S-COD-SQL       PIC   ---9.*/
                public IntBasis BI0005L_S_COD_SQL { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05        BI0005L-S-LIT-ERR       PIC  X(030).*/
                public StringBasis BI0005L_S_LIT_ERR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"01           TABELAS.*/
            }
        }
        public BI1630B_TABELAS TABELAS { get; set; } = new BI1630B_TABELAS();
        public class BI1630B_TABELAS : VarBasis
        {
            /*"  03         TABELA-ERROS.*/
            public BI1630B_TABELA_ERROS TABELA_ERROS { get; set; } = new BI1630B_TABELA_ERROS();
            public class BI1630B_TABELA_ERROS : VarBasis
            {
                /*"    05       TAB-ERROS-ZEROS.*/
                public BI1630B_TAB_ERROS_ZEROS TAB_ERROS_ZEROS { get; set; } = new BI1630B_TAB_ERROS_ZEROS();
                public class BI1630B_TAB_ERROS_ZEROS : VarBasis
                {
                    /*"      07     FILLER             PIC S9(006)    VALUE +0 COMP-3.*/
                    public IntBasis FILLER_18 { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
                    /*"      07     TAB-ERROS-LIMPA.*/
                    public BI1630B_TAB_ERROS_LIMPA TAB_ERROS_LIMPA { get; set; } = new BI1630B_TAB_ERROS_LIMPA();
                    public class BI1630B_TAB_ERROS_LIMPA : VarBasis
                    {
                        /*"        09   TAB-ERROS          OCCURS    050       TIMES.*/
                        public ListBasis<BI1630B_TAB_ERROS> TAB_ERROS { get; set; } = new ListBasis<BI1630B_TAB_ERROS>(050);
                        public class BI1630B_TAB_ERROS : VarBasis
                        {
                            /*"          11 TAB-COD-ERR        PIC S9(006)    COMP-3.*/
                            public IntBasis TAB_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "6", "S9(006)"));
                            /*"  03         TABELA-AGENCIAS.*/
                        }
                    }
                }
            }
            public BI1630B_TABELA_AGENCIAS TABELA_AGENCIAS { get; set; } = new BI1630B_TABELA_AGENCIAS();
            public class BI1630B_TABELA_AGENCIAS : VarBasis
            {
                /*"    05       TAB-AGENCIAS-ZEROS.*/
                public BI1630B_TAB_AGENCIAS_ZEROS TAB_AGENCIAS_ZEROS { get; set; } = new BI1630B_TAB_AGENCIAS_ZEROS();
                public class BI1630B_TAB_AGENCIAS_ZEROS : VarBasis
                {
                    /*"      07     FILLER             PIC S9(004)    VALUE +0 COMP-3.*/
                    public IntBasis FILLER_19 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     FILLER             PIC S9(004)    VALUE +0 COMP-3.*/
                    public IntBasis FILLER_20 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     TAB-AGENCIAS-LIMPA.*/
                    public BI1630B_TAB_AGENCIAS_LIMPA TAB_AGENCIAS_LIMPA { get; set; } = new BI1630B_TAB_AGENCIAS_LIMPA();
                    public class BI1630B_TAB_AGENCIAS_LIMPA : VarBasis
                    {
                        /*"        09   TAB-AGENCIAS       OCCURS    9999      TIMES.*/
                        public ListBasis<BI1630B_TAB_AGENCIAS> TAB_AGENCIAS { get; set; } = new ListBasis<BI1630B_TAB_AGENCIAS>(9999);
                        public class BI1630B_TAB_AGENCIAS : VarBasis
                        {
                            /*"          11 TAB-COD-AGE        PIC S9(004)    COMP-3.*/
                            public IntBasis TAB_COD_AGE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          11 TAB-COD-FON        PIC S9(004)    COMP-3.*/
                            public IntBasis TAB_COD_FON { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"  03         TABELA-CBO.*/
                        }
                    }
                }
            }
            public BI1630B_TABELA_CBO TABELA_CBO { get; set; } = new BI1630B_TABELA_CBO();
            public class BI1630B_TABELA_CBO : VarBasis
            {
                /*"    05       TAB-CBO-ZEROS.*/
                public BI1630B_TAB_CBO_ZEROS TAB_CBO_ZEROS { get; set; } = new BI1630B_TAB_CBO_ZEROS();
                public class BI1630B_TAB_CBO_ZEROS : VarBasis
                {
                    /*"      07     FILLER             PIC S9(004)    VALUE +0 COMP-3.*/
                    public IntBasis FILLER_21 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      07     FILLER             PIC  X(005)    VALUE SPACES.*/
                    public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                    /*"      07     FILLER             PIC  X(020)    VALUE SPACES.*/
                    public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                    /*"      07     TAB-CBO-LIMPA.*/
                    public BI1630B_TAB_CBO_LIMPA TAB_CBO_LIMPA { get; set; } = new BI1630B_TAB_CBO_LIMPA();
                    public class BI1630B_TAB_CBO_LIMPA : VarBasis
                    {
                        /*"        09   TAB-CBO            OCCURS    999       TIMES.*/
                        public ListBasis<BI1630B_TAB_CBO> TAB_CBO { get; set; } = new ListBasis<BI1630B_TAB_CBO>(999);
                        public class BI1630B_TAB_CBO : VarBasis
                        {
                            /*"          11 TAB-COD-CBO        PIC S9(004)    COMP-3.*/
                            public IntBasis TAB_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                            /*"          11 TAB-DES-RES        PIC  X(005).*/
                            public StringBasis TAB_DES_RES { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                            /*"          11 TAB-DES-COM        PIC  X(020).*/
                            public StringBasis TAB_DES_COM { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                        }
                    }
                }
            }
        }


        public Copies.GE0070W GE0070W { get; set; } = new Copies.GE0070W();
        public Copies.GE0071W GE0071W { get; set; } = new Copies.GE0071W();
        public Copies.SPVG001V SPVG001V { get; set; } = new Copies.SPVG001V();
        public Copies.SPVG001W SPVG001W { get; set; } = new Copies.SPVG001W();
        public Copies.SPVG009W SPVG009W { get; set; } = new Copies.SPVG009W();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.NUMOUTRO NUMOUTRO { get; set; } = new Dclgens.NUMOUTRO();
        public Dclgens.GECLIMOV GECLIMOV { get; set; } = new Dclgens.GECLIMOV();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.CLIENTE CLIENTE { get; set; } = new Dclgens.CLIENTE();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.GEDOCCLI GEDOCCLI { get; set; } = new Dclgens.GEDOCCLI();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PLAVAVGA PLAVAVGA { get; set; } = new Dclgens.PLAVAVGA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.CEDENTE CEDENTE { get; set; } = new Dclgens.CEDENTE();
        public Dclgens.COVSICOB COVSICOB { get; set; } = new Dclgens.COVSICOB();
        public Dclgens.PROPSSBI PROPSSBI { get; set; } = new Dclgens.PROPSSBI();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.GETPMOIM GETPMOIM { get; set; } = new Dclgens.GETPMOIM();
        public Dclgens.GE372 GE372 { get; set; } = new Dclgens.GE372();
        public Dclgens.GE085 GE085 { get; set; } = new Dclgens.GE085();
        public Dclgens.PF062 PF062 { get; set; } = new Dclgens.PF062();
        public Dclgens.CBO CBO { get; set; } = new Dclgens.CBO();
        public BI1630B_CUR_AGE CUR_AGE { get; set; } = new BI1630B_CUR_AGE();
        public BI1630B_CUR_CBO CUR_CBO { get; set; } = new BI1630B_CUR_CBO();
        public BI1630B_CUR_PRO CUR_PRO { get; set; } = new BI1630B_CUR_PRO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-00-BI1630B-SECTION */

                M_0000_00_BI1630B_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-00-BI1630B-SECTION */
        private void M_0000_00_BI1630B_SECTION()
        {
            /*" -417- MOVE '0000-00-BI1630B        ' TO PARAGRAFO */
            _.Move("0000-00-BI1630B        ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -418- MOVE '0000' TO COMANDO */
            _.Move("0000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -421- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -424- PERFORM 70000-00-INICIAL THRU 70000-99-SAIDA */

            M_70000_00_INICIAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/


            /*" -428- PERFORM 10000-00-TRATA-PROPOSTAS THRU 10000-99-SAIDA UNTIL FIM-CURSOR-PRO */

            while (!(WS_WORKING.WS_NIVEIS_88.N88_FIM_CURSOR_PRO["FIM_CURSOR_PRO"]))
            {

                M_10000_00_TRATA_PROPOSTAS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

            }

            /*" -431- PERFORM 80000-00-FINAL THRU 80000-99-SAIDA */

            M_80000_00_FINAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_80000_99_SAIDA*/


            /*" -433- GOBACK */

            throw new GoBack();

            /*" -433- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-INICIAL-SECTION */
        private void M_70000_00_INICIAL_SECTION()
        {
            /*" -443- MOVE '70000-00-INICIAL       ' TO PARAGRAFO */
            _.Move("70000-00-INICIAL       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -444- MOVE '70000' TO COMANDO */
            _.Move("70000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -446- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -447- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -451- DISPLAY ' BI1630B - TRATA BILHETES - V.03                 ' */
            _.Display($" BI1630B - TRATA BILHETES - V.03                 ");

            /*" -452- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -458- DISPLAY ' VERSAO DE : ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $" VERSAO DE : FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -459- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -467- DISPLAY ' DATA DE PROCESSAMENTO: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $" DATA DE PROCESSAMENTO: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -468- INITIALIZE DCLSISTEMAS */
            _.Initialize(
                SISTEMAS.DCLSISTEMAS
            );

            /*" -476- PERFORM M_70000_00_INICIAL_DB_SELECT_1 */

            M_70000_00_INICIAL_DB_SELECT_1();

            /*" -479- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -480- DISPLAY ' DATA DE MOVIMENTO: ' WS-DATA-PROC */
                _.Display($" DATA DE MOVIMENTO: {WS_WORKING.WS_AUXILIARES.WS_DATA_PROC}");

                /*" -481- DISPLAY '-------------------------------------------------' */
                _.Display($"-------------------------------------------------");

                /*" -482- ELSE */
            }
            else
            {


                /*" -483- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -484- DISPLAY 'BI1630B - NAO CONSTA REGISTRO SEGUROS.SISTEMAS' */
                    _.Display($"BI1630B - NAO CONSTA REGISTRO SEGUROS.SISTEMAS");

                    /*" -485- DISPLAY 'IDSISTEM =  BI ' */
                    _.Display($"IDSISTEM =  BI ");

                    /*" -486- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -487- ELSE */
                }
                else
                {


                    /*" -488- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -489- DISPLAY 'BI1630B - ERRO NA LEITURA NA SEGUROS.SISTEMAS' */
                    _.Display($"BI1630B - ERRO NA LEITURA NA SEGUROS.SISTEMAS");

                    /*" -490- DISPLAY 'SQLCODE = ' WS-SQLCODE */
                    _.Display($"SQLCODE = {WS_WORKING.WS_AUXILIARES.WS_SQLCODE}");

                    /*" -491- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -492- END-IF */
                }


                /*" -495- END-IF */
            }


            /*" -500- PERFORM M_70000_00_INICIAL_DB_SELECT_2 */

            M_70000_00_INICIAL_DB_SELECT_2();

            /*" -505- DISPLAY 'SEL NUMERO_OUTROS: ' NUM-CLIENTE OF DCLNUMERO-OUTROS '*' SQLCODE */

            $"SEL NUMERO_OUTROS: {NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE}*{DB.SQLCODE}"
            .Display();

            /*" -506- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -508- DISPLAY ' NUMERO CLIENTE : ' NUM-CLIENTE OF DCLNUMERO-OUTROS */
                _.Display($" NUMERO CLIENTE : {NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE}");

                /*" -509- ELSE */
            }
            else
            {


                /*" -510- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -511- DISPLAY '***' */
                _.Display($"***");

                /*" -512- DISPLAY ' 70000-00-INICIAL          ' */
                _.Display($" 70000-00-INICIAL          ");

                /*" -513- DISPLAY ' ERRO SEL NUMERO_OUTROS (' WS-SQLCODE ')' */

                $" ERRO SEL NUMERO_OUTROS ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -514- DISPLAY '***' */
                _.Display($"***");

                /*" -515- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -519- END-IF */
            }


            /*" -529- PERFORM M_70000_00_INICIAL_DB_DECLARE_1 */

            M_70000_00_INICIAL_DB_DECLARE_1();

            /*" -533- MOVE 'CUR-AGE' TO COMANDO */
            _.Move("CUR-AGE", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -533- PERFORM M_70000_00_INICIAL_DB_OPEN_1 */

            M_70000_00_INICIAL_DB_OPEN_1();

            /*" -537- DISPLAY 'OPE CUR-AGE*' SQLCODE */
            _.Display($"OPE CUR-AGE*{DB.SQLCODE}");

            /*" -538- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -539- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -540- DISPLAY '***' */
                _.Display($"***");

                /*" -541- DISPLAY ' 70000-00-INICIAL         ' */
                _.Display($" 70000-00-INICIAL         ");

                /*" -542- DISPLAY ' ERRO OPE CUR-AGE (' WS-SQLCODE ')' */

                $" ERRO OPE CUR-AGE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -543- DISPLAY '***' */
                _.Display($"***");

                /*" -544- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -547- END-IF */
            }


            /*" -548- MOVE TAB-AGENCIAS-ZEROS TO TAB-AGENCIAS-LIMPA */
            _.Move(TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS, TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA);

            /*" -556- PERFORM 71000-00-TRATA-AGENCIAS THRU 71000-99-SAIDA VARYING IND-AGE FROM 001 BY 001 UNTIL IND-AGE GREATER 9999 OR FIM-AGENCIA */

            for (WS_WORKING.INDEXADORES.IND_AGE.Value = 001; !(WS_WORKING.INDEXADORES.IND_AGE > 9999 || WS_WORKING.WS_NIVEIS_88.N88_FIM_AGENCIA["FIM_AGENCIA"]); WS_WORKING.INDEXADORES.IND_AGE.Value += 001)
            {

                M_71000_00_TRATA_AGENCIAS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_71000_99_SAIDA*/

            }

            /*" -562- PERFORM M_70000_00_INICIAL_DB_DECLARE_2 */

            M_70000_00_INICIAL_DB_DECLARE_2();

            /*" -566- MOVE 'CUR-CBO' TO COMANDO */
            _.Move("CUR-CBO", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -566- PERFORM M_70000_00_INICIAL_DB_OPEN_2 */

            M_70000_00_INICIAL_DB_OPEN_2();

            /*" -570- DISPLAY 'OPE CUR-CBO*' SQLCODE */
            _.Display($"OPE CUR-CBO*{DB.SQLCODE}");

            /*" -571- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -572- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -573- DISPLAY '***' */
                _.Display($"***");

                /*" -574- DISPLAY ' 70000-00-INICIAL         ' */
                _.Display($" 70000-00-INICIAL         ");

                /*" -575- DISPLAY ' ERRO OPE CUR-CBO (' WS-SQLCODE ')' */

                $" ERRO OPE CUR-CBO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -576- DISPLAY '***' */
                _.Display($"***");

                /*" -577- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -580- END-IF */
            }


            /*" -581- MOVE TAB-CBO-ZEROS TO TAB-CBO-LIMPA */
            _.Move(TABELAS.TABELA_CBO.TAB_CBO_ZEROS, TABELAS.TABELA_CBO.TAB_CBO_ZEROS.TAB_CBO_LIMPA);

            /*" -588- PERFORM 73000-00-TRATA-CBO THRU 73000-99-SAIDA VARYING IND-CBO FROM 001 BY 001 UNTIL IND-CBO GREATER 999 OR FIM-CBO */

            for (WS_WORKING.INDEXADORES.IND_CBO.Value = 001; !(WS_WORKING.INDEXADORES.IND_CBO > 999 || WS_WORKING.WS_NIVEIS_88.N88_FIM_CBO["FIM_CBO"]); WS_WORKING.INDEXADORES.IND_CBO.Value += 001)
            {

                M_73000_00_TRATA_CBO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_73000_99_SAIDA*/

            }

            /*" -643- PERFORM M_70000_00_INICIAL_DB_DECLARE_3 */

            M_70000_00_INICIAL_DB_DECLARE_3();

            /*" -647- MOVE 'CUR-PRO' TO COMANDO */
            _.Move("CUR-PRO", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -647- PERFORM M_70000_00_INICIAL_DB_OPEN_3 */

            M_70000_00_INICIAL_DB_OPEN_3();

            /*" -651- DISPLAY 'OPE CUR-PRO*' SQLCODE */
            _.Display($"OPE CUR-PRO*{DB.SQLCODE}");

            /*" -652- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -653- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -654- DISPLAY '***' */
                _.Display($"***");

                /*" -655- DISPLAY ' 70000-00-INICIAL         ' */
                _.Display($" 70000-00-INICIAL         ");

                /*" -656- DISPLAY ' ERRO OPE CUR-PRO (' WS-SQLCODE ')' */

                $" ERRO OPE CUR-PRO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -657- DISPLAY '***' */
                _.Display($"***");

                /*" -658- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -660- END-IF */
            }


            /*" -660- . */

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-SELECT-1 */
        public void M_70000_00_INICIAL_DB_SELECT_1()
        {
            /*" -476- EXEC SQL SELECT DATA_MOV_ABERTO , DATA_MOV_ABERTO INTO :WS-DATA-PROC , :WS-DATA-PROC-AUX FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' WITH UR END-EXEC */

            var m_70000_00_INICIAL_DB_SELECT_1_Query1 = new M_70000_00_INICIAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_70000_00_INICIAL_DB_SELECT_1_Query1.Execute(m_70000_00_INICIAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_DATA_PROC, WS_WORKING.WS_AUXILIARES.WS_DATA_PROC);
                _.Move(executed_1.WS_DATA_PROC_AUX, WS_WORKING.WS_AUXILIARES.WS_DATA_PROC_AUX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-DECLARE-1 */
        public void M_70000_00_INICIAL_DB_DECLARE_1()
        {
            /*" -529- EXEC SQL DECLARE CUR-AGE CURSOR FOR SELECT A.COD_AGENCIA , B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A , SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG = B.COD_SUREG AND B.COD_FONTE < 100 ORDER BY A.COD_AGENCIA WITH UR END-EXEC */
            CUR_AGE = new BI1630B_CUR_AGE(false);
            string GetQuery_CUR_AGE()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG = B.COD_SUREG 
							AND B.COD_FONTE < 100 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            CUR_AGE.GetQueryEvent += GetQuery_CUR_AGE;

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-OPEN-1 */
        public void M_70000_00_INICIAL_DB_OPEN_1()
        {
            /*" -533- EXEC SQL OPEN CUR-AGE END-EXEC */

            CUR_AGE.Open();

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-DECLARE-2 */
        public void M_70000_00_INICIAL_DB_DECLARE_2()
        {
            /*" -562- EXEC SQL DECLARE CUR-CBO CURSOR FOR SELECT COD_CBO , DESCR_CBO FROM SEGUROS.CBO ORDER BY COD_CBO WITH UR END-EXEC */
            CUR_CBO = new BI1630B_CUR_CBO(false);
            string GetQuery_CUR_CBO()
            {
                var query = @$"SELECT COD_CBO
							, 
							DESCR_CBO 
							FROM SEGUROS.CBO 
							ORDER BY COD_CBO";

                return query;
            }
            CUR_CBO.GetQueryEvent += GetQuery_CUR_CBO;

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-SELECT-2 */
        public void M_70000_00_INICIAL_DB_SELECT_2()
        {
            /*" -500- EXEC SQL SELECT NUM_CLIENTE INTO :DCLNUMERO-OUTROS.NUM-CLIENTE FROM SEGUROS.NUMERO_OUTROS WITH UR END-EXEC */

            var m_70000_00_INICIAL_DB_SELECT_2_Query1 = new M_70000_00_INICIAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_70000_00_INICIAL_DB_SELECT_2_Query1.Execute(m_70000_00_INICIAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_CLIENTE, NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE);
            }


        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-OPEN-2 */
        public void M_70000_00_INICIAL_DB_OPEN_2()
        {
            /*" -566- EXEC SQL OPEN CUR-CBO END-EXEC */

            CUR_CBO.Open();

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-DECLARE-3 */
        public void M_70000_00_INICIAL_DB_DECLARE_3()
        {
            /*" -643- EXEC SQL DECLARE CUR-PRO CURSOR FOR SELECT B.RENOVACAO_AUTOM , C.NUM_PROPOSTA_SIVPF, C.NUM_IDENTIFICACAO , C.COD_PESSOA , C.NUM_SICOB , C.DATA_PROPOSTA , C.COD_PRODUTO_SIVPF , C.COD_EMPRESA_SIVPF , C.AGECOBR , C.DIA_DEBITO , C.OPCAOPAG , C.AGECTADEB , C.OPRCTADEB , C.NUMCTADEB , C.DIGCTADEB , C.PERC_DESCONTO , C.NRMATRVEN , C.AGECTAVEN , C.OPRCTAVEN , C.NUMCTAVEN , C.DIGCTAVEN , C.CGC_CONVENENTE , C.NOME_CONVENENTE , C.NRMATRCON , C.DTQITBCO , C.VAL_PAGO , C.AGEPGTO , C.VAL_TARIFA , C.VAL_IOF , C.DATA_CREDITO , C.VAL_COMISSAO , C.SIT_PROPOSTA , C.COD_USUARIO , C.CANAL_PROPOSTA , C.NSAS_SIVPF , C.ORIGEM_PROPOSTA , C.TIMESTAMP , C.NSL , C.NSAC_SIVPF , C.NOME_CONJUGE , C.DATA_NASC_CONJUGE , C.PROFISSAO_CONJUGE , C.OPCAO_COBER , C.COD_PLANO , C.FAIXA_RENDA_IND , C.FAIXA_RENDA_FAM FROM SEGUROS.PROP_SASSE_BILHETE B , SEGUROS.PROPOSTA_FIDELIZ C WHERE B.DATA_INCLUSAO IS NULL AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO AND C.SIT_PROPOSTA IN ( 'ENV' , 'POB' ) AND C.COD_PRODUTO_SIVPF = 56 ORDER BY C.NUM_PROPOSTA_SIVPF WITH UR END-EXEC */
            CUR_PRO = new BI1630B_CUR_PRO(false);
            string GetQuery_CUR_PRO()
            {
                var query = @$"SELECT B.RENOVACAO_AUTOM
							, 
							C.NUM_PROPOSTA_SIVPF
							, 
							C.NUM_IDENTIFICACAO
							, 
							C.COD_PESSOA
							, 
							C.NUM_SICOB
							, 
							C.DATA_PROPOSTA
							, 
							C.COD_PRODUTO_SIVPF
							, 
							C.COD_EMPRESA_SIVPF
							, 
							C.AGECOBR
							, 
							C.DIA_DEBITO
							, 
							C.OPCAOPAG
							, 
							C.AGECTADEB
							, 
							C.OPRCTADEB
							, 
							C.NUMCTADEB
							, 
							C.DIGCTADEB
							, 
							C.PERC_DESCONTO
							, 
							C.NRMATRVEN
							, 
							C.AGECTAVEN
							, 
							C.OPRCTAVEN
							, 
							C.NUMCTAVEN
							, 
							C.DIGCTAVEN
							, 
							C.CGC_CONVENENTE
							, 
							C.NOME_CONVENENTE
							, 
							C.NRMATRCON
							, 
							C.DTQITBCO
							, 
							C.VAL_PAGO
							, 
							C.AGEPGTO
							, 
							C.VAL_TARIFA
							, 
							C.VAL_IOF
							, 
							C.DATA_CREDITO
							, 
							C.VAL_COMISSAO
							, 
							C.SIT_PROPOSTA
							, 
							C.COD_USUARIO
							, 
							C.CANAL_PROPOSTA
							, 
							C.NSAS_SIVPF
							, 
							C.ORIGEM_PROPOSTA
							, 
							C.TIMESTAMP
							, 
							C.NSL
							, 
							C.NSAC_SIVPF
							, 
							C.NOME_CONJUGE
							, 
							C.DATA_NASC_CONJUGE
							, 
							C.PROFISSAO_CONJUGE
							, 
							C.OPCAO_COBER
							, 
							C.COD_PLANO
							, 
							C.FAIXA_RENDA_IND
							, 
							C.FAIXA_RENDA_FAM 
							FROM SEGUROS.PROP_SASSE_BILHETE B
							, 
							SEGUROS.PROPOSTA_FIDELIZ C 
							WHERE B.DATA_INCLUSAO IS NULL 
							AND C.NUM_IDENTIFICACAO = B.NUM_IDENTIFICACAO 
							AND C.SIT_PROPOSTA IN ( 'ENV'
							, 'POB' ) 
							AND C.COD_PRODUTO_SIVPF = 56 
							ORDER BY C.NUM_PROPOSTA_SIVPF";

                return query;
            }
            CUR_PRO.GetQueryEvent += GetQuery_CUR_PRO;

        }

        [StopWatch]
        /*" M-71000-00-TRATA-AGENCIAS-SECTION */
        private void M_71000_00_TRATA_AGENCIAS_SECTION()
        {
            /*" -670- MOVE '71000-00-TRATA-AGENCIAS ' TO PARAGRAFO */
            _.Move("71000-00-TRATA-AGENCIAS ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -674- MOVE '71000' TO COMANDO */
            _.Move("71000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -677- PERFORM M_71000_00_TRATA_AGENCIAS_DB_FETCH_1 */

            M_71000_00_TRATA_AGENCIAS_DB_FETCH_1();

            /*" -680- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -682- MOVE COD-AGENCIA OF DCLAGENCIAS-CEF TO TAB-COD-AGE(COD-AGENCIA OF DCLAGENCIAS-CEF) */
                _.Move(AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA, TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA.TAB_AGENCIAS[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_COD_AGE);

                /*" -684- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-COD-FON(COD-AGENCIA OF DCLAGENCIAS-CEF) */
                _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA.TAB_AGENCIAS[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_COD_FON);

                /*" -685- ELSE */
            }
            else
            {


                /*" -686- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -687- MOVE 'S' TO N88-FIM-AGENCIA */
                    _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_FIM_AGENCIA);

                    /*" -687- PERFORM M_71000_00_TRATA_AGENCIAS_DB_CLOSE_1 */

                    M_71000_00_TRATA_AGENCIAS_DB_CLOSE_1();

                    /*" -689- ELSE */
                }
                else
                {


                    /*" -690- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -691- DISPLAY '***' */
                    _.Display($"***");

                    /*" -692- DISPLAY ' 71000-00-TRATA-AGENCIAS ' */
                    _.Display($" 71000-00-TRATA-AGENCIAS ");

                    /*" -693- DISPLAY ' ERRO FET CUR-AGE (' WS-SQLCODE ')' */

                    $" ERRO FET CUR-AGE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -694- DISPLAY '***' */
                    _.Display($"***");

                    /*" -695- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -696- END-IF */
                }


                /*" -698- END-IF */
            }


            /*" -698- . */

        }

        [StopWatch]
        /*" M-71000-00-TRATA-AGENCIAS-DB-FETCH-1 */
        public void M_71000_00_TRATA_AGENCIAS_DB_FETCH_1()
        {
            /*" -677- EXEC SQL FETCH CUR-AGE INTO :DCLAGENCIAS-CEF.COD-AGENCIA , :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC */

            if (CUR_AGE.Fetch())
            {
                _.Move(CUR_AGE.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(CUR_AGE.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" M-71000-00-TRATA-AGENCIAS-DB-CLOSE-1 */
        public void M_71000_00_TRATA_AGENCIAS_DB_CLOSE_1()
        {
            /*" -687- EXEC SQL CLOSE CUR-AGE END-EXEC */

            CUR_AGE.Close();

        }

        [StopWatch]
        /*" M-70000-00-INICIAL-DB-OPEN-3 */
        public void M_70000_00_INICIAL_DB_OPEN_3()
        {
            /*" -647- EXEC SQL OPEN CUR-PRO END-EXEC */

            CUR_PRO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_71000_99_SAIDA*/

        [StopWatch]
        /*" M-73000-00-TRATA-CBO-SECTION */
        private void M_73000_00_TRATA_CBO_SECTION()
        {
            /*" -708- MOVE '73000-00-TRATA-CBO     ' TO PARAGRAFO */
            _.Move("73000-00-TRATA-CBO     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -712- MOVE '73000' TO COMANDO */
            _.Move("73000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -715- PERFORM M_73000_00_TRATA_CBO_DB_FETCH_1 */

            M_73000_00_TRATA_CBO_DB_FETCH_1();

            /*" -718- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -720- IF CBO-COD-CBO GREATER ZEROS AND CBO-COD-CBO LESS 1000 */

                if (CBO.DCLCBO.CBO_COD_CBO > 00 && CBO.DCLCBO.CBO_COD_CBO < 1000)
                {

                    /*" -722- MOVE CBO-COD-CBO TO TAB-COD-CBO(CBO-COD-CBO OF DCLCBO) */
                    _.Move(CBO.DCLCBO.CBO_COD_CBO, TABELAS.TABELA_CBO.TAB_CBO_ZEROS.TAB_CBO_LIMPA.TAB_CBO[CBO.DCLCBO.CBO_COD_CBO].TAB_COD_CBO);

                    /*" -729- MOVE CBO-DESCR-CBO TO TAB-DES-RES(CBO-COD-CBO OF DCLCBO) TAB-DES-COM(CBO-COD-CBO OF DCLCBO) */
                    _.Move(CBO.DCLCBO.CBO_DESCR_CBO, TABELAS.TABELA_CBO.TAB_CBO_ZEROS.TAB_CBO_LIMPA.TAB_CBO[CBO.DCLCBO.CBO_COD_CBO].TAB_DES_RES, TABELAS.TABELA_CBO.TAB_CBO_ZEROS.TAB_CBO_LIMPA.TAB_CBO[CBO.DCLCBO.CBO_COD_CBO].TAB_DES_COM);

                    /*" -730- END-IF */
                }


                /*" -731- ELSE */
            }
            else
            {


                /*" -732- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -733- MOVE 'S' TO N88-FIM-CBO */
                    _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_FIM_CBO);

                    /*" -733- PERFORM M_73000_00_TRATA_CBO_DB_CLOSE_1 */

                    M_73000_00_TRATA_CBO_DB_CLOSE_1();

                    /*" -735- ELSE */
                }
                else
                {


                    /*" -736- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -737- DISPLAY '***' */
                    _.Display($"***");

                    /*" -738- DISPLAY ' 73000-00-TRATA-CBO      ' */
                    _.Display($" 73000-00-TRATA-CBO      ");

                    /*" -739- DISPLAY ' ERRO FET CUR-CBO (' WS-SQLCODE ')' */

                    $" ERRO FET CUR-CBO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -740- DISPLAY '***' */
                    _.Display($"***");

                    /*" -741- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -742- END-IF */
                }


                /*" -744- END-IF */
            }


            /*" -744- . */

        }

        [StopWatch]
        /*" M-73000-00-TRATA-CBO-DB-FETCH-1 */
        public void M_73000_00_TRATA_CBO_DB_FETCH_1()
        {
            /*" -715- EXEC SQL FETCH CUR-CBO INTO :CBO-COD-CBO , :CBO-DESCR-CBO END-EXEC */

            if (CUR_CBO.Fetch())
            {
                _.Move(CUR_CBO.CBO_COD_CBO, CBO.DCLCBO.CBO_COD_CBO);
                _.Move(CUR_CBO.CBO_DESCR_CBO, CBO.DCLCBO.CBO_DESCR_CBO);
            }

        }

        [StopWatch]
        /*" M-73000-00-TRATA-CBO-DB-CLOSE-1 */
        public void M_73000_00_TRATA_CBO_DB_CLOSE_1()
        {
            /*" -733- EXEC SQL CLOSE CUR-CBO END-EXEC */

            CUR_CBO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_73000_99_SAIDA*/

        [StopWatch]
        /*" M-10000-00-TRATA-PROPOSTAS-SECTION */
        private void M_10000_00_TRATA_PROPOSTAS_SECTION()
        {
            /*" -754- MOVE '10000-00-TRATA-PROPOSTAS' TO PARAGRAFO */
            _.Move("10000-00-TRATA-PROPOSTAS", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -755- MOVE '10000' TO COMANDO */
            _.Move("10000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -758- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -805- PERFORM M_10000_00_TRATA_PROPOSTAS_DB_FETCH_1 */

            M_10000_00_TRATA_PROPOSTAS_DB_FETCH_1();

            /*" -807- DISPLAY '==============================================' */
            _.Display($"==============================================");

            /*" -810- DISPLAY 'PROPOSTA LIDA: ' PROPOFID-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"PROPOSTA LIDA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -811- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -812- ADD 001 TO AC-PRO-LID */
                WS_WORKING.AC_CONTADORES.AC_PRO_LID.Value = WS_WORKING.AC_CONTADORES.AC_PRO_LID + 001;

                /*" -813- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO WS-NUM-PROPOSTA */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WS_WORKING.WS_AUXILIARES.WS_NUM_PROPOSTA);

                /*" -814- MOVE TAB-ERROS-ZEROS TO TAB-ERROS-LIMPA */
                _.Move(TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS, TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA);

                /*" -815- MOVE ZEROS TO IND-ERR */
                _.Move(0, WS_WORKING.INDEXADORES.IND_ERR);

                /*" -816- ELSE */
            }
            else
            {


                /*" -817- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -817- PERFORM M_10000_00_TRATA_PROPOSTAS_DB_CLOSE_1 */

                    M_10000_00_TRATA_PROPOSTAS_DB_CLOSE_1();

                    /*" -819- MOVE 'S' TO N88-FIM-CURSOR-PRO */
                    _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_FIM_CURSOR_PRO);

                    /*" -820- GO TO 10000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/ //GOTO
                    return;

                    /*" -821- ELSE */
                }
                else
                {


                    /*" -822- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -823- DISPLAY '***' */
                    _.Display($"***");

                    /*" -824- DISPLAY ' 10000-00-TRATA-PROPOSTAS' */
                    _.Display($" 10000-00-TRATA-PROPOSTAS");

                    /*" -825- DISPLAY ' ERRO FET CUR-PRO (' WS-SQLCODE ')' */

                    $" ERRO FET CUR-PRO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -826- DISPLAY '***' */
                    _.Display($"***");

                    /*" -827- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -828- END-IF */
                }


                /*" -831- END-IF */
            }


            /*" -844- PERFORM M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1 */

            M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1();

            /*" -848- DISPLAY 'SEL BILHETE ' PROPOFID-NUM-SICOB ' SQLCODE: ' SQLCODE */

            $"SEL BILHETE {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -849- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -850- ADD 001 TO AC-BIL-LID */
                WS_WORKING.AC_CONTADORES.AC_BIL_LID.Value = WS_WORKING.AC_CONTADORES.AC_BIL_LID + 001;

                /*" -851- PERFORM 11000-00-ATUALIZA THRU 11000-99-SAIDA */

                M_11000_00_ATUALIZA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_11000_99_SAIDA*/


                /*" -852- GO TO 10000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/ //GOTO
                return;

                /*" -853- ELSE */
            }
            else
            {


                /*" -854- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -855- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -856- DISPLAY '***' */
                    _.Display($"***");

                    /*" -857- DISPLAY ' 10000-00-TRATA-PROPOSTAS  ' */
                    _.Display($" 10000-00-TRATA-PROPOSTAS  ");

                    /*" -858- DISPLAY ' ERRO SEL BILHETE (' WS-SQLCODE ')' */

                    $" ERRO SEL BILHETE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -859- DISPLAY '***' */
                    _.Display($"***");

                    /*" -860- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -863- END-IF */
                }


                /*" -866- PERFORM 13000-00-ACESSA-PESSOA THRU 13000-99-SAIDA */

                M_13000_00_ACESSA_PESSOA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13000_99_SAIDA*/


                /*" -868- PERFORM 15000-00-ACESSA-RCAPS-1 THRU 15000-99-SAIDA */

                M_15000_00_ACESSA_RCAPS_1_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_15000_99_SAIDA*/


                /*" -869- IF PROPOFID-AGECTADEB EQUAL ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB == 00)
                {

                    /*" -870- ADD 001 TO IND-ERR */
                    WS_WORKING.INDEXADORES.IND_ERR.Value = WS_WORKING.INDEXADORES.IND_ERR + 001;

                    /*" -871- MOVE 12201 TO TAB-COD-ERR(IND-ERR) */
                    _.Move(12201, TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR].TAB_COD_ERR);

                    /*" -872- END-IF */
                }


                /*" -873- IF PROPOFID-OPRCTADEB EQUAL ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB == 00)
                {

                    /*" -874- ADD 001 TO IND-ERR */
                    WS_WORKING.INDEXADORES.IND_ERR.Value = WS_WORKING.INDEXADORES.IND_ERR + 001;

                    /*" -875- MOVE 02203 TO TAB-COD-ERR(IND-ERR) */
                    _.Move(02203, TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR].TAB_COD_ERR);

                    /*" -876- END-IF */
                }


                /*" -877- IF PROPOFID-NUMCTADEB EQUAL ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB == 00)
                {

                    /*" -878- ADD 001 TO IND-ERR */
                    WS_WORKING.INDEXADORES.IND_ERR.Value = WS_WORKING.INDEXADORES.IND_ERR + 001;

                    /*" -879- MOVE 02204 TO TAB-COD-ERR(IND-ERR) */
                    _.Move(02204, TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR].TAB_COD_ERR);

                    /*" -882- END-IF */
                }


                /*" -885- PERFORM 17000-00-ACESSA-GE0070S THRU 17000-99-SAIDA */

                M_17000_00_ACESSA_GE0070S_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17000_99_SAIDA*/


                /*" -888- PERFORM 19000-00-TRATA-CLIENTES THRU 19000-99-SAIDA */

                M_19000_00_TRATA_CLIENTES_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_19000_99_SAIDA*/


                /*" -891- PERFORM 1B000-00-TRATA-ENDERECO THRU 1B000-99-SAIDA */

                M_1B000_00_TRATA_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B000_99_SAIDA*/


                /*" -894- PERFORM 1C000-00-TRATA-EMAIL THRU 1C000-99-SAIDA */

                M_1C000_00_TRATA_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C000_99_SAIDA*/


                /*" -897- PERFORM 1D000-00-TRATA-GECLIMOV THRU 1D000-99-SAIDA */

                M_1D000_00_TRATA_GECLIMOV_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1D000_99_SAIDA*/


                /*" -900- PERFORM 1F000-00-INSERT-BILHETE THRU 1F000-99-SAIDA */

                M_1F000_00_INSERT_BILHETE_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1F000_99_SAIDA*/


                /*" -902- MOVE '%' TO N88-ERRO-NORMAL N88-ERRO-CRITICO */
                _.Move("%", WS_WORKING.WS_NIVEIS_88.N88_ERRO_NORMAL, WS_WORKING.WS_NIVEIS_88.N88_ERRO_CRITICO);

                /*" -903- MOVE 001 TO WS-COD-CRI */
                _.Move(001, WS_WORKING.WS_AUXILIARES.WS_COD_CRI);

                /*" -905- PERFORM 1L000-00-CONS-COD-CRITICA THRU 1L000-99-SAIDA */

                M_1L000_00_CONS_COD_CRITICA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1L000_99_SAIDA*/


                /*" -906- IF TEM-CRITICA-VG001 */

                if (WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG001["TEM_CRITICA_VG001"])
                {

                    /*" -907- IF LK-VG001-S-STA-CRITICA NOT EQUAL '6' */

                    if (SPVG001W.LK_VG001_S_STA_CRITICA != "6")
                    {

                        /*" -910- DISPLAY 'BILHETE EM ANALISE DE CRITICA.......: ' PROPOFID-NUM-SICOB ' >> ' LK-VG001-S-STA-CRITICA */

                        $"BILHETE EM ANALISE DE CRITICA.......: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB} >> {SPVG001W.LK_VG001_S_STA_CRITICA}"
                        .Display();

                        /*" -911- ADD 001 TO AC-QTD-ERR-CRI */
                        WS_WORKING.AC_CONTADORES.AC_QTD_ERR_CRI.Value = WS_WORKING.AC_CONTADORES.AC_QTD_ERR_CRI + 001;

                        /*" -912- MOVE 'S' TO N88-ERRO-CRITICO */
                        _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_ERRO_CRITICO);

                        /*" -913- ELSE */
                    }
                    else
                    {


                        /*" -914- DISPLAY 'LIBERADO PARA EMISSAO APOS ANALISE..: ' */
                        _.Display($"LIBERADO PARA EMISSAO APOS ANALISE..: ");

                        /*" -915- ADD 001 TO AC-PRO-LIB-EMI */
                        WS_WORKING.AC_CONTADORES.AC_PRO_LIB_EMI.Value = WS_WORKING.AC_CONTADORES.AC_PRO_LIB_EMI + 001;

                        /*" -916- END-IF */
                    }


                    /*" -917- ELSE */
                }
                else
                {


                    /*" -918- PERFORM 1H000-00-AVALIACAO-RISCO THRU 1H000-99-SAIDA */

                    M_1H000_00_AVALIACAO_RISCO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1H000_99_SAIDA*/


                    /*" -919- PERFORM 1J000-00-GRAVA-RISCO-MOTOR THRU 1J000-99-SAIDA */

                    M_1J000_00_GRAVA_RISCO_MOTOR_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J000_99_SAIDA*/


                    /*" -922- END-IF */
                }


                /*" -925- PERFORM 1N000-00-UPDATE-PROPFID THRU 1N000-99-SAIDA */

                M_1N000_00_UPDATE_PROPFID_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1N000_99_SAIDA*/


                /*" -928- PERFORM 1P000-00-UPDATE-PROPSSBI THRU 1P000-99-SAIDA */

                M_1P000_00_UPDATE_PROPSSBI_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1P000_99_SAIDA*/


                /*" -933- PERFORM 1R000-00-TRATA-ERRO THRU 1R000-99-SAIDA VARYING IND-ERR FROM 001 BY 001 UNTIL IND-ERR GREATER 050 OR TAB-COD-ERR(IND-ERR) EQUAL ZEROS */

                for (WS_WORKING.INDEXADORES.IND_ERR.Value = 001; !(WS_WORKING.INDEXADORES.IND_ERR > 050 || TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR].TAB_COD_ERR == 00); WS_WORKING.INDEXADORES.IND_ERR.Value += 001)
                {

                    M_1R000_00_TRATA_ERRO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1R000_99_SAIDA*/

                }

                /*" -933- . */
            }


        }

        [StopWatch]
        /*" M-10000-00-TRATA-PROPOSTAS-DB-FETCH-1 */
        public void M_10000_00_TRATA_PROPOSTAS_DB_FETCH_1()
        {
            /*" -805- EXEC SQL FETCH CUR-PRO INTO :PROPSSBI-RENOVACAO-AUTOM , :PROPOFID-NUM-PROPOSTA-SIVPF , :PROPOFID-NUM-IDENTIFICACAO , :PROPOFID-COD-PESSOA , :PROPOFID-NUM-SICOB , :PROPOFID-DATA-PROPOSTA , :PROPOFID-COD-PRODUTO-SIVPF , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-AGECOBR , :PROPOFID-DIA-DEBITO , :PROPOFID-OPCAOPAG , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :PROPOFID-PERC-DESCONTO , :PROPOFID-NRMATRVEN , :PROPOFID-AGECTAVEN , :PROPOFID-OPRCTAVEN , :PROPOFID-NUMCTAVEN , :PROPOFID-DIGCTAVEN , :PROPOFID-CGC-CONVENENTE , :PROPOFID-NOME-CONVENENTE , :PROPOFID-NRMATRCON , :PROPOFID-DTQITBCO , :PROPOFID-VAL-PAGO , :PROPOFID-AGEPGTO , :PROPOFID-VAL-TARIFA , :PROPOFID-VAL-IOF , :PROPOFID-DATA-CREDITO , :PROPOFID-VAL-COMISSAO , :PROPOFID-SIT-PROPOSTA , :PROPOFID-COD-USUARIO , :PROPOFID-CANAL-PROPOSTA , :PROPOFID-NSAS-SIVPF , :PROPOFID-ORIGEM-PROPOSTA , :PROPOFID-TIMESTAMP , :PROPOFID-NSL , :PROPOFID-NSAC-SIVPF , :PROPOFID-NOME-CONJUGE :VIND-NULL01 , :PROPOFID-DATA-NASC-CONJUGE :VIND-NULL02 , :PROPOFID-PROFISSAO-CONJUGE :VIND-NULL03 , :PROPOFID-OPCAO-COBER , :PROPOFID-COD-PLANO , :PROPOFID-FAIXA-RENDA-IND :VIND-NULL04 , :PROPOFID-FAIXA-RENDA-FAM :VIND-NULL05 END-EXEC */

            if (CUR_PRO.Fetch())
            {
                _.Move(CUR_PRO.PROPSSBI_RENOVACAO_AUTOM, PROPSSBI.DCLPROP_SASSE_BILHETE.PROPSSBI_RENOVACAO_AUTOM);
                _.Move(CUR_PRO.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
                _.Move(CUR_PRO.PROPOFID_NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);
                _.Move(CUR_PRO.PROPOFID_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);
                _.Move(CUR_PRO.PROPOFID_NUM_SICOB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);
                _.Move(CUR_PRO.PROPOFID_DATA_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);
                _.Move(CUR_PRO.PROPOFID_COD_PRODUTO_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);
                _.Move(CUR_PRO.PROPOFID_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);
                _.Move(CUR_PRO.PROPOFID_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);
                _.Move(CUR_PRO.PROPOFID_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);
                _.Move(CUR_PRO.PROPOFID_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);
                _.Move(CUR_PRO.PROPOFID_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);
                _.Move(CUR_PRO.PROPOFID_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);
                _.Move(CUR_PRO.PROPOFID_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);
                _.Move(CUR_PRO.PROPOFID_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);
                _.Move(CUR_PRO.PROPOFID_PERC_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);
                _.Move(CUR_PRO.PROPOFID_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);
                _.Move(CUR_PRO.PROPOFID_AGECTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);
                _.Move(CUR_PRO.PROPOFID_OPRCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);
                _.Move(CUR_PRO.PROPOFID_NUMCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);
                _.Move(CUR_PRO.PROPOFID_DIGCTAVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);
                _.Move(CUR_PRO.PROPOFID_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);
                _.Move(CUR_PRO.PROPOFID_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);
                _.Move(CUR_PRO.PROPOFID_NRMATRCON, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);
                _.Move(CUR_PRO.PROPOFID_DTQITBCO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);
                _.Move(CUR_PRO.PROPOFID_VAL_PAGO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);
                _.Move(CUR_PRO.PROPOFID_AGEPGTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);
                _.Move(CUR_PRO.PROPOFID_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);
                _.Move(CUR_PRO.PROPOFID_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);
                _.Move(CUR_PRO.PROPOFID_DATA_CREDITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);
                _.Move(CUR_PRO.PROPOFID_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);
                _.Move(CUR_PRO.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(CUR_PRO.PROPOFID_COD_USUARIO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);
                _.Move(CUR_PRO.PROPOFID_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
                _.Move(CUR_PRO.PROPOFID_NSAS_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);
                _.Move(CUR_PRO.PROPOFID_ORIGEM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);
                _.Move(CUR_PRO.PROPOFID_TIMESTAMP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_TIMESTAMP);
                _.Move(CUR_PRO.PROPOFID_NSL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);
                _.Move(CUR_PRO.PROPOFID_NSAC_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);
                _.Move(CUR_PRO.PROPOFID_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);
                _.Move(CUR_PRO.VIND_NULL01, WS_WORKING.WS_AUXILIARES.VIND_NULL01);
                _.Move(CUR_PRO.PROPOFID_DATA_NASC_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);
                _.Move(CUR_PRO.VIND_NULL02, WS_WORKING.WS_AUXILIARES.VIND_NULL02);
                _.Move(CUR_PRO.PROPOFID_PROFISSAO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);
                _.Move(CUR_PRO.VIND_NULL03, WS_WORKING.WS_AUXILIARES.VIND_NULL03);
                _.Move(CUR_PRO.PROPOFID_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);
                _.Move(CUR_PRO.PROPOFID_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);
                _.Move(CUR_PRO.PROPOFID_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);
                _.Move(CUR_PRO.VIND_NULL04, WS_WORKING.WS_AUXILIARES.VIND_NULL04);
                _.Move(CUR_PRO.PROPOFID_FAIXA_RENDA_FAM, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);
                _.Move(CUR_PRO.VIND_NULL05, WS_WORKING.WS_AUXILIARES.VIND_NULL05);
            }

        }

        [StopWatch]
        /*" M-10000-00-TRATA-PROPOSTAS-DB-CLOSE-1 */
        public void M_10000_00_TRATA_PROPOSTAS_DB_CLOSE_1()
        {
            /*" -817- EXEC SQL CLOSE CUR-PRO END-EXEC */

            CUR_PRO.Close();

        }

        [StopWatch]
        /*" M-10000-00-TRATA-PROPOSTAS-DB-SELECT-1 */
        public void M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1()
        {
            /*" -844- EXEC SQL SELECT DATA_QUITACAO , VAL_RCAP , DATA_MOVIMENTO, SITUACAO INTO :BILHETE-DATA-QUITACAO , :BILHETE-VAL-RCAP , :BILHETE-DATA-MOVIMENTO , :BILHETE-SITUACAO FROM SEGUROS.BILHETE WHERE NUM_BILHETE = :PROPOFID-NUM-SICOB AND SITUACAO <> 'R' WITH UR END-EXEC */

            var m_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1 = new M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
            };

            var executed_1 = M_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1.Execute(m_10000_00_TRATA_PROPOSTAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_DATA_QUITACAO, BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO);
                _.Move(executed_1.BILHETE_VAL_RCAP, BILHETE.DCLBILHETE.BILHETE_VAL_RCAP);
                _.Move(executed_1.BILHETE_DATA_MOVIMENTO, BILHETE.DCLBILHETE.BILHETE_DATA_MOVIMENTO);
                _.Move(executed_1.BILHETE_SITUACAO, BILHETE.DCLBILHETE.BILHETE_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

        [StopWatch]
        /*" M-11000-00-ATUALIZA-SECTION */
        private void M_11000_00_ATUALIZA_SECTION()
        {
            /*" -943- MOVE '11000-00-ATUALIZA      ' TO PARAGRAFO */
            _.Move("11000-00-ATUALIZA      ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -944- MOVE '11000' TO COMANDO */
            _.Move("11000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -947- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -948- IF BILHETE-SITUACAO EQUAL '1' */

            if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "1")
            {

                /*" -949- MOVE 'PEN' TO WS-SIT-ATU-BIL */
                _.Move("PEN", WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL);

                /*" -950- ELSE */
            }
            else
            {


                /*" -951- IF BILHETE-SITUACAO EQUAL '2' OR '3' */

                if (BILHETE.DCLBILHETE.BILHETE_SITUACAO.In("2", "3"))
                {

                    /*" -952- MOVE 'POB' TO WS-SIT-ATU-BIL */
                    _.Move("POB", WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL);

                    /*" -953- ELSE */
                }
                else
                {


                    /*" -954- IF BILHETE-SITUACAO EQUAL '9' */

                    if (BILHETE.DCLBILHETE.BILHETE_SITUACAO == "9")
                    {

                        /*" -955- MOVE 'EMT' TO WS-SIT-ATU-BIL */
                        _.Move("EMT", WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL);

                        /*" -956- ELSE */
                    }
                    else
                    {


                        /*" -957- GO TO 11000-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_11000_99_SAIDA*/ //GOTO
                        return;

                        /*" -958- END-IF */
                    }


                    /*" -959- END-IF */
                }


                /*" -961- END-IF */
            }


            /*" -962- IF PROPOFID-SIT-PROPOSTA EQUAL WS-SIT-ATU-BIL */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA == WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL)
            {

                /*" -963- GO TO 11000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_11000_99_SAIDA*/ //GOTO
                return;

                /*" -966- END-IF */
            }


            /*" -967- IF PROPOFID-VAL-PAGO EQUAL ZEROS */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO == 00)
            {

                /*" -968- MOVE BILHETE-VAL-RCAP TO PROPOFID-VAL-PAGO */
                _.Move(BILHETE.DCLBILHETE.BILHETE_VAL_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

                /*" -970- END-IF */
            }


            /*" -972- IF PROPOFID-DTQITBCO EQUAL '0001-01-01' OR '1900-01-01' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.In("0001-01-01", "1900-01-01"))
            {

                /*" -973- MOVE BILHETE-DATA-QUITACAO TO PROPOFID-DTQITBCO */
                _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

                /*" -975- END-IF */
            }


            /*" -977- IF PROPOFID-DTQITBCO EQUAL '0001-01-01' OR '1900-01-01' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.In("0001-01-01", "1900-01-01"))
            {

                /*" -978- MOVE BILHETE-DATA-QUITACAO TO PROPOFID-DATA-CREDITO */
                _.Move(BILHETE.DCLBILHETE.BILHETE_DATA_QUITACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

                /*" -981- END-IF */
            }


            /*" -983- MOVE 'UPD PROPOSTA_FIDELIZ' TO COMANDO */
            _.Move("UPD PROPOSTA_FIDELIZ", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -991- PERFORM M_11000_00_ATUALIZA_DB_UPDATE_1 */

            M_11000_00_ATUALIZA_DB_UPDATE_1();

            /*" -993- DISPLAY 'UPD PROPOSTA_FIDELIZ ' */
            _.Display($"UPD PROPOSTA_FIDELIZ ");

            /*" -997- DISPLAY NUM-PROPOSTA-SIVPF PROPOFID-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"{COVSICOB.DCLCONVERSAO_SICOB.NUM_PROPOSTA_SIVPF}{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -998- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -999- ADD 001 TO AC-PRO-ATU */
                WS_WORKING.AC_CONTADORES.AC_PRO_ATU.Value = WS_WORKING.AC_CONTADORES.AC_PRO_ATU + 001;

                /*" -1000- ELSE */
            }
            else
            {


                /*" -1001- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1002- DISPLAY '***' */
                _.Display($"***");

                /*" -1003- DISPLAY ' 11000-00-ATUALIZA        ' */
                _.Display($" 11000-00-ATUALIZA        ");

                /*" -1004- DISPLAY ' ERRO UPD FIDELIZ (' WS-SQLCODE ')' */

                $" ERRO UPD FIDELIZ ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1005- DISPLAY '***' */
                _.Display($"***");

                /*" -1006- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1009- END-IF */
            }


            /*" -1011- MOVE 'UPDATE' TO COMANDO */
            _.Move("UPDATE", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1015- PERFORM M_11000_00_ATUALIZA_DB_UPDATE_2 */

            M_11000_00_ATUALIZA_DB_UPDATE_2();

            /*" -1020- DISPLAY 'UPD PROP_SASSE_BILHETE(1)' PROPOFID-NUM-IDENTIFICACAO ' SQLCODE: ' SQLCODE */

            $"UPD PROP_SASSE_BILHETE(1){PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1021- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1022- ADD 001 TO AC-SAS-ATU */
                WS_WORKING.AC_CONTADORES.AC_SAS_ATU.Value = WS_WORKING.AC_CONTADORES.AC_SAS_ATU + 001;

                /*" -1023- ELSE */
            }
            else
            {


                /*" -1024- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1025- DISPLAY '***' */
                _.Display($"***");

                /*" -1026- DISPLAY ' 11000-00-ATUALIZA        ' */
                _.Display($" 11000-00-ATUALIZA        ");

                /*" -1027- DISPLAY ' ERRO UPD SASSE_BILHETE (' WS-SQLCODE ')' */

                $" ERRO UPD SASSE_BILHETE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1028- DISPLAY '***' */
                _.Display($"***");

                /*" -1029- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1031- END-IF */
            }


            /*" -1031- . */

        }

        [StopWatch]
        /*" M-11000-00-ATUALIZA-DB-UPDATE-1 */
        public void M_11000_00_ATUALIZA_DB_UPDATE_1()
        {
            /*" -991- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WS-SIT-ATU-BIL , SITUACAO_ENVIO = 'S' , DTQITBCO = :PROPOFID-DTQITBCO , VAL_PAGO = :PROPOFID-VAL-PAGO , DATA_CREDITO = :PROPOFID-DATA-CREDITO WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC */

            var m_11000_00_ATUALIZA_DB_UPDATE_1_Update1 = new M_11000_00_ATUALIZA_DB_UPDATE_1_Update1()
            {
                PROPOFID_DATA_CREDITO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                WS_SIT_ATU_BIL = WS_WORKING.WS_AUXILIARES.WS_SIT_ATU_BIL.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            M_11000_00_ATUALIZA_DB_UPDATE_1_Update1.Execute(m_11000_00_ATUALIZA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_11000_99_SAIDA*/

        [StopWatch]
        /*" M-11000-00-ATUALIZA-DB-UPDATE-2 */
        public void M_11000_00_ATUALIZA_DB_UPDATE_2()
        {
            /*" -1015- EXEC SQL UPDATE SEGUROS.PROP_SASSE_BILHETE SET DATA_INCLUSAO = :WS-DATA-PROC WHERE NUM_IDENTIFICACAO = :PROPOFID-NUM-IDENTIFICACAO END-EXEC */

            var m_11000_00_ATUALIZA_DB_UPDATE_2_Update1 = new M_11000_00_ATUALIZA_DB_UPDATE_2_Update1()
            {
                WS_DATA_PROC = WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
            };

            M_11000_00_ATUALIZA_DB_UPDATE_2_Update1.Execute(m_11000_00_ATUALIZA_DB_UPDATE_2_Update1);

        }

        [StopWatch]
        /*" M-13000-00-ACESSA-PESSOA-SECTION */
        private void M_13000_00_ACESSA_PESSOA_SECTION()
        {
            /*" -1041- MOVE '13000-00-ACESSA-PESSOA      ' TO PARAGRAFO */
            _.Move("13000-00-ACESSA-PESSOA      ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1042- MOVE '13000' TO COMANDO */
            _.Move("13000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1045- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1047- MOVE PROPOFID-COD-PESSOA TO BI0005L-E-COD-PESSOA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA, BI0005L_LINKAGE.BI0005L_ENTRADA.BI0005L_E_COD_PESSOA);

            /*" -1049- CALL 'BI0005S' USING BI0005L-LINKAGE */
            _.Call("BI0005S", BI0005L_LINKAGE);

            /*" -1050- IF BI0005L-S-COD-ERR EQUAL ZEROS */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR == 00)
            {

                /*" -1051- ADD 001 TO AC-PES-LID */
                WS_WORKING.AC_CONTADORES.AC_PES_LID.Value = WS_WORKING.AC_CONTADORES.AC_PES_LID + 001;

                /*" -1052- ELSE */
            }
            else
            {


                /*" -1053- DISPLAY '***' */
                _.Display($"***");

                /*" -1054- DISPLAY ' 13000-00-ACESSA-PESSOA    ' */
                _.Display($" 13000-00-ACESSA-PESSOA    ");

                /*" -1055- DISPLAY ' ERRO ACESSO BI0005S       ' */
                _.Display($" ERRO ACESSO BI0005S       ");

                /*" -1056- DISPLAY ' BI0005L-ERRO: ' BI0005L-S-COD-ERR */
                _.Display($" BI0005L-ERRO: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_ERR}");

                /*" -1057- DISPLAY ' BI0005L-SQL: ' BI0005L-S-COD-SQL */
                _.Display($" BI0005L-SQL: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_SQL}");

                /*" -1058- DISPLAY ' BI0005L-DESCRICAO: ' BI0005L-S-LIT-ERR */
                _.Display($" BI0005L-DESCRICAO: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_LIT_ERR}");

                /*" -1059- DISPLAY '***' */
                _.Display($"***");

                /*" -1060- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1062- END-IF */
            }


            /*" -1062- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_13000_99_SAIDA*/

        [StopWatch]
        /*" M-15000-00-ACESSA-RCAPS-1-SECTION */
        private void M_15000_00_ACESSA_RCAPS_1_SECTION()
        {
            /*" -1072- MOVE '15000-00-ACESSA-RCAPS-1 ' TO PARAGRAFO */
            _.Move("15000-00-ACESSA-RCAPS-1 ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1073- MOVE '15000' TO COMANDO */
            _.Move("15000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1076- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1077- MOVE '@' TO N88-RCAPS */
            _.Move("@", WS_WORKING.WS_NIVEIS_88.N88_RCAPS);

            /*" -1079- IF TAB-COD-FON(PROPOFID-AGECOBR) EQUAL ZEROS OR TAB-COD-FON(PROPOFID-AGECOBR) GREATER 099 */

            if (TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA.TAB_AGENCIAS[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_COD_FON == 00 || TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA.TAB_AGENCIAS[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_COD_FON > 099)
            {

                /*" -1080- MOVE 005 TO RCAPS-COD-FONTE */
                _.Move(005, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

                /*" -1081- ELSE */
            }
            else
            {


                /*" -1082- MOVE TAB-COD-FON(PROPOFID-AGECOBR) TO RCAPS-COD-FONTE */
                _.Move(TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA.TAB_AGENCIAS[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_COD_FON, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);

                /*" -1084- END-IF */
            }


            /*" -1097- PERFORM M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1 */

            M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1();

            /*" -1103- DISPLAY 'SEL RCAPS: ' PROPOFID-NUM-PROPOSTA-SIVPF '/' RCAPS-COD-FONTE OF DCLRCAPS ' SQLCODE: ' SQLCODE */

            $"SEL RCAPS: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}/{RCAPS.DCLRCAPS.RCAPS_COD_FONTE} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1104- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1105- ADD 001 TO AC-RCA-LID */
                WS_WORKING.AC_CONTADORES.AC_RCA_LID.Value = WS_WORKING.AC_CONTADORES.AC_RCA_LID + 001;

                /*" -1106- MOVE 'S' TO N88-RCAPS */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_RCAPS);

                /*" -1107- ELSE */
            }
            else
            {


                /*" -1108- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1109- PERFORM 15100-00-ACESSA-RCAPS-2 THRU 15100-99-SAIDA */

                    M_15100_00_ACESSA_RCAPS_2_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_15100_99_SAIDA*/


                    /*" -1110- ELSE */
                }
                else
                {


                    /*" -1111- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1112- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1113- DISPLAY ' 15000-00-ACESSA-RCAPS   ' */
                    _.Display($" 15000-00-ACESSA-RCAPS   ");

                    /*" -1114- DISPLAY ' ERRO SEL RCAPS (' WS-SQLCODE ')' */

                    $" ERRO SEL RCAPS ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1115- DISPLAY ' PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($" PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1116- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1117- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1118- END-IF */
                }


                /*" -1120- END-IF */
            }


            /*" -1120- . */

        }

        [StopWatch]
        /*" M-15000-00-ACESSA-RCAPS-1-DB-SELECT-1 */
        public void M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1()
        {
            /*" -1097- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP, AGE_COBRANCA INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP, :DCLRCAPS.RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_TITULO = :PROPOFID-NUM-SICOB AND COD_FONTE = :RCAPS-COD-FONTE WITH UR END-EXEC */

            var m_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1 = new M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
            };

            var executed_1 = M_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1.Execute(m_15000_00_ACESSA_RCAPS_1_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_15000_99_SAIDA*/

        [StopWatch]
        /*" M-15100-00-ACESSA-RCAPS-2-SECTION */
        private void M_15100_00_ACESSA_RCAPS_2_SECTION()
        {
            /*" -1130- MOVE '15100-00-ACESSA-RCAPS-2 ' TO PARAGRAFO */
            _.Move("15100-00-ACESSA-RCAPS-2 ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1131- MOVE '15100' TO COMANDO */
            _.Move("15100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1134- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1146- PERFORM M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1 */

            M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1();

            /*" -1151- DISPLAY 'SEL RCAPS: ' PROPOFID-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"SEL RCAPS: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1152- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1153- ADD 001 TO AC-RCA-LID */
                WS_WORKING.AC_CONTADORES.AC_RCA_LID.Value = WS_WORKING.AC_CONTADORES.AC_RCA_LID + 001;

                /*" -1154- MOVE 'S' TO N88-RCAPS */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_RCAPS);

                /*" -1155- ELSE */
            }
            else
            {


                /*" -1156- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1157- ADD 001 TO IND-ERR */
                    WS_WORKING.INDEXADORES.IND_ERR.Value = WS_WORKING.INDEXADORES.IND_ERR + 001;

                    /*" -1158- MOVE 11802 TO TAB-COD-ERR(IND-ERR) */
                    _.Move(11802, TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR].TAB_COD_ERR);

                    /*" -1159- ELSE */
                }
                else
                {


                    /*" -1160- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1161- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1162- DISPLAY ' 15100-00-ACESSA-RCAPS-2 ' */
                    _.Display($" 15100-00-ACESSA-RCAPS-2 ");

                    /*" -1163- DISPLAY ' ERRO SEL RCAPS (' WS-SQLCODE ')' */

                    $" ERRO SEL RCAPS ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1164- DISPLAY ' PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($" PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1165- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1166- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1168- END-IF */
                }


                /*" -1168- . */
            }


        }

        [StopWatch]
        /*" M-15100-00-ACESSA-RCAPS-2-DB-SELECT-1 */
        public void M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1()
        {
            /*" -1146- EXEC SQL SELECT COD_FONTE, NUM_RCAP, VAL_RCAP, AGE_COBRANCA INTO :DCLRCAPS.RCAPS-COD-FONTE, :DCLRCAPS.RCAPS-NUM-RCAP, :DCLRCAPS.RCAPS-VAL-RCAP , :DCLRCAPS.RCAPS-AGE-COBRANCA FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC */

            var m_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1 = new M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1.Execute(m_15100_00_ACESSA_RCAPS_2_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_15100_99_SAIDA*/

        [StopWatch]
        /*" M-17000-00-ACESSA-GE0070S-SECTION */
        private void M_17000_00_ACESSA_GE0070S_SECTION()
        {
            /*" -1178- MOVE '17000-00-ACESSA-GE0070S ' TO PARAGRAFO */
            _.Move("17000-00-ACESSA-GE0070S ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1179- MOVE '17000' TO COMANDO */
            _.Move("17000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1182- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1184- IF (PROPOFID-COD-PRODUTO-SIVPF EQUAL WS-PRD-SIV-ANT AND PROPOFID-COD-PLANO EQUAL WS-PLA-LID-ANT) */

            if ((PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF == WS_WORKING.WS_AUXILIARES.WS_PRD_SIV_ANT && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO == WS_WORKING.WS_AUXILIARES.WS_PLA_LID_ANT))
            {

                /*" -1185- CONTINUE */

                /*" -1186- ELSE */
            }
            else
            {


                /*" -1187- PERFORM 17100-00-OBTER-PRODUTO-SIAS THRU 17100-99-SAIDA */

                M_17100_00_OBTER_PRODUTO_SIAS_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17100_99_SAIDA*/


                /*" -1190- END-IF */
            }


            /*" -1192- IF (PRDSIVPF-COD-PRODUTO EQUAL WS-PRD-SIA-ANT AND PROPOFID-DATA-PROPOSTA EQUAL WS-DAT-LID-ANT) */

            if ((PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO == WS_WORKING.WS_AUXILIARES.WS_PRD_SIA_ANT && PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA == WS_WORKING.WS_AUXILIARES.WS_DAT_LID_ANT))
            {

                /*" -1193- PERFORM 17300-00-OBTER-COBERTURA THRU 17300-99-SAIDA */

                M_17300_00_OBTER_COBERTURA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17300_99_SAIDA*/


                /*" -1194- GO TO 17000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17000_99_SAIDA*/ //GOTO
                return;

                /*" -1195- ELSE */
            }
            else
            {


                /*" -1196- MOVE PRDSIVPF-COD-PRODUTO TO WS-PRD-SIA-ANT */
                _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO, WS_WORKING.WS_AUXILIARES.WS_PRD_SIA_ANT);

                /*" -1197- MOVE PROPOFID-DATA-PROPOSTA TO WS-DAT-LID-ANT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, WS_WORKING.WS_AUXILIARES.WS_DAT_LID_ANT);

                /*" -1200- END-IF */
            }


            /*" -1201- MOVE 'S' TO LK-0070-E-TRACE */
            _.Move("S", GE0070W.LK_0070_E_TRACE);

            /*" -1202- MOVE 'BATCH' TO LK-0070-E-COD-USUARIO */
            _.Move("BATCH", GE0070W.LK_0070_E_COD_USUARIO);

            /*" -1203- MOVE 'BI1630B' TO LK-0070-E-NOM-PROGRAMA */
            _.Move("BI1630B", GE0070W.LK_0070_E_NOM_PROGRAMA);

            /*" -1204- MOVE 001 TO LK-0070-E-ACAO */
            _.Move(001, GE0070W.LK_0070_E_ACAO);

            /*" -1205- MOVE PRDSIVPF-COD-PRODUTO TO LK-0070-I-COD-PRODUTO */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO, GE0070W.LK_0070_I_COD_PRODUTO);

            /*" -1206- MOVE ZEROS TO LK-0070-I-SEQ-PRODUTO-VRS */
            _.Move(0, GE0070W.LK_0070_I_SEQ_PRODUTO_VRS);

            /*" -1208- MOVE PROPOFID-DATA-PROPOSTA TO LK-0070-I-DTA-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA, GE0070W.LK_0070_I_DTA_PROPOSTA);

            /*" -1209- MOVE 'GE0070S' TO WS-PGM-CALL */
            _.Move("GE0070S", WS_WORKING.WS_AUXILIARES.WS_PGM_CALL);

            /*" -1251- CALL WS-PGM-CALL USING LK-0070-E-TRACE LK-0070-E-COD-USUARIO LK-0070-E-NOM-PROGRAMA LK-0070-E-ACAO LK-0070-I-COD-PRODUTO LK-0070-I-SEQ-PRODUTO-VRS LK-0070-I-DTA-PROPOSTA LK-0070-S-DTA-INI-VIGENCIA LK-0070-S-DTA-FIM-VIGENCIA LK-0070-S-IND-FLUXO-PARAM LK-0070-S-COD-PERIOD-VIGENCIA LK-0070-S-QTD-PERIOD-VIGENCIA LK-0070-S-COD-MOEDA LK-0070-S-IND-RENOVA LK-0070-S-IND-RENOVA-AUTOMAT LK-0070-S-QTD-RENOVA-AUTOMAT LK-0070-S-IND-DPS LK-0070-S-IND-REENQUADRA-PREM LK-0070-S-IND-REAJUSTE-PREMIO LK-0070-S-COD-INDICE-REAJUSTE LK-0070-S-COD-PERIOD-REAJUSTE LK-0070-S-COD-INDC-DEVOLUCAO LK-0070-S-PCT-JUROS-DEVOLUCAO LK-0070-S-PCT-MULTA-DEVOLUCAO LK-0070-S-IND-FLUXO-COMISSAO LK-0070-S-IND-ACOPLADO LK-0070-S-IND-FLUXO-SINISTRO LK-0070-S-IND-CONJUGE LK-0070-S-COD-USUARIO LK-0070-S-NOM-PROGRAMA LK-0070-S-DTH-CADASTRAMENTO LK-0070-IND-ERRO LK-0070-MSG-ERRO LK-0070-NOM-TABELA LK-0070-SQLCODE LK-0070-SQLERRMC LK-0070-SQLSTATE */
            _.Call(WS_WORKING.WS_AUXILIARES.WS_PGM_CALL, GE0070W);

            /*" -1253- IF (LK-0070-IND-ERRO EQUAL ZEROS AND LK-0070-S-IND-FLUXO-PARAM EQUAL 'S' ) */

            if ((GE0070W.LK_0070_IND_ERRO == 00 && GE0070W.LK_0070_S_IND_FLUXO_PARAM == "S"))
            {

                /*" -1254- PERFORM 17300-00-OBTER-COBERTURA THRU 17300-99-SAIDA */

                M_17300_00_OBTER_COBERTURA_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17300_99_SAIDA*/


                /*" -1255- ELSE */
            }
            else
            {


                /*" -1256- DISPLAY '***' */
                _.Display($"***");

                /*" -1257- DISPLAY ' 17000-00-ACESSA-GE0070S   ' */
                _.Display($" 17000-00-ACESSA-GE0070S   ");

                /*" -1258- DISPLAY ' CALL GE0070S ' */
                _.Display($" CALL GE0070S ");

                /*" -1259- DISPLAY ' ERRO CALL GE0070S(' LK-0070-IND-ERRO ')' */

                $" ERRO CALL GE0070S({GE0070W.LK_0070_IND_ERRO})"
                .Display();

                /*" -1260- DISPLAY ' LK-0070-E-TRACE  : ' LK-0070-E-TRACE */
                _.Display($" LK-0070-E-TRACE  : {GE0070W.LK_0070_E_TRACE}");

                /*" -1261- DISPLAY ' LK-0070-E-COD-USU: ' LK-0070-E-COD-USUARIO */
                _.Display($" LK-0070-E-COD-USU: {GE0070W.LK_0070_E_COD_USUARIO}");

                /*" -1262- DISPLAY ' LK-0070-E-NOM-PRO: ' LK-0070-E-NOM-PROGRAMA */
                _.Display($" LK-0070-E-NOM-PRO: {GE0070W.LK_0070_E_NOM_PROGRAMA}");

                /*" -1263- DISPLAY ' LK-0070-E-ACAO   : ' LK-0070-E-ACAO */
                _.Display($" LK-0070-E-ACAO   : {GE0070W.LK_0070_E_ACAO}");

                /*" -1264- DISPLAY ' LK-0070-I-COD-PRO: ' LK-0070-I-COD-PRODUTO */
                _.Display($" LK-0070-I-COD-PRO: {GE0070W.LK_0070_I_COD_PRODUTO}");

                /*" -1265- DISPLAY ' LK-0070-I-SEQ-PRO: ' LK-0070-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0070-I-SEQ-PRO: {GE0070W.LK_0070_I_SEQ_PRODUTO_VRS}");

                /*" -1266- DISPLAY ' LK-0070-I-DTA-PRO: ' LK-0070-I-DTA-PROPOSTA */
                _.Display($" LK-0070-I-DTA-PRO: {GE0070W.LK_0070_I_DTA_PROPOSTA}");

                /*" -1267- DISPLAY ' LK-0070-S-IND-FLU: ' LK-0070-S-IND-FLUXO-PARAM */
                _.Display($" LK-0070-S-IND-FLU: {GE0070W.LK_0070_S_IND_FLUXO_PARAM}");

                /*" -1268- DISPLAY '***' */
                _.Display($"***");

                /*" -1269- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1271- END-IF */
            }


            /*" -1271- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17000_99_SAIDA*/

        [StopWatch]
        /*" M-17100-00-OBTER-PRODUTO-SIAS-SECTION */
        private void M_17100_00_OBTER_PRODUTO_SIAS_SECTION()
        {
            /*" -1281- MOVE '17100-00-OBTER-PRODUTO ' TO PARAGRAFO */
            _.Move("17100-00-OBTER-PRODUTO ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1282- MOVE '17100' TO COMANDO */
            _.Move("17100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1285- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1296- PERFORM M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1 */

            M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1();

            /*" -1304- DISPLAY 'SEL PRODUTOS_SIVPF: ' PROPOFID-COD-PRODUTO-SIVPF '/' PROPOFID-COD-PLANO '*' PRDSIVPF-COD-PRODUTO '*' PRDSIVPF-COD-PLANO ' SQLCODE: ' SQLCODE */

            $"SEL PRODUTOS_SIVPF: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF}/{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO}*{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}*{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1305- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1306- MOVE PROPOFID-COD-PRODUTO-SIVPF TO WS-PRD-SIV-ANT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, WS_WORKING.WS_AUXILIARES.WS_PRD_SIV_ANT);

                /*" -1307- MOVE PROPOFID-COD-PLANO TO WS-PLA-LID-ANT */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, WS_WORKING.WS_AUXILIARES.WS_PLA_LID_ANT);

                /*" -1308- ELSE */
            }
            else
            {


                /*" -1309- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1310- DISPLAY '***' */
                _.Display($"***");

                /*" -1311- DISPLAY '17100-00-OBTER-PRODUTO-' */
                _.Display($"17100-00-OBTER-PRODUTO-");

                /*" -1312- DISPLAY ' ERRO SEL PRODUTOS_SIVPF (' WS-SQLCODE ')' */

                $" ERRO SEL PRODUTOS_SIVPF ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1313- DISPLAY ' COD PRODUTO: ' PRDSIVPF-COD-PRODUTO-SIVPF */
                _.Display($" COD PRODUTO: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -1314- DISPLAY ' COD PLANO: ' PRDSIVPF-COD-PLANO */
                _.Display($" COD PLANO: {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO}");

                /*" -1315- DISPLAY '***' */
                _.Display($"***");

                /*" -1316- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1318- END-IF */
            }


            /*" -1318- . */

        }

        [StopWatch]
        /*" M-17100-00-OBTER-PRODUTO-SIAS-DB-SELECT-1 */
        public void M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1()
        {
            /*" -1296- EXEC SQL SELECT VALUE(COD_PRODUTO, 0) , VALUE(COD_PLANO, 0) INTO :PRDSIVPF-COD-PRODUTO , :PRDSIVPF-COD-PLANO FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO_SIVPF = :PROPOFID-COD-PRODUTO-SIVPF AND DTH_FIM_VIGENCIA = '9999-12-31' AND COD_PLANO = :PROPOFID-COD-PLANO WITH UR END-EXEC */

            var m_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1 = new M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1()
            {
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
                PROPOFID_COD_PLANO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO.ToString(),
            };

            var executed_1 = M_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1.Execute(m_17100_00_OBTER_PRODUTO_SIAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_PRODUTO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO);
                _.Move(executed_1.PRDSIVPF_COD_PLANO, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PLANO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17100_99_SAIDA*/

        [StopWatch]
        /*" M-17300-00-OBTER-COBERTURA-SECTION */
        private void M_17300_00_OBTER_COBERTURA_SECTION()
        {
            /*" -1328- MOVE '17300-00-OBTER-COBERTUR' TO PARAGRAFO */
            _.Move("17300-00-OBTER-COBERTUR", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1329- MOVE '17300' TO COMANDO */
            _.Move("17300", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1332- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1333- MOVE 'S' TO LK-0071-E-TRACE */
            _.Move("S", GE0071W.LK_0071_E_TRACE);

            /*" -1334- MOVE 'BATCH' TO LK-0071-E-COD-USUARIO */
            _.Move("BATCH", GE0071W.LK_0071_E_COD_USUARIO);

            /*" -1335- MOVE 'BI1630B' TO LK-0071-E-NOM-PROGRAMA */
            _.Move("BI1630B", GE0071W.LK_0071_E_NOM_PROGRAMA);

            /*" -1336- MOVE 001 TO LK-0071-E-ACAO */
            _.Move(001, GE0071W.LK_0071_E_ACAO);

            /*" -1337- MOVE PRDSIVPF-COD-PRODUTO TO LK-0071-I-COD-PRODUTO */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO, GE0071W.LK_0071_I_COD_PRODUTO);

            /*" -1339- MOVE LK-0070-I-SEQ-PRODUTO-VRS TO LK-0071-I-SEQ-PRODUTO-VRS */
            _.Move(GE0070W.LK_0070_I_SEQ_PRODUTO_VRS, GE0071W.LK_0071_I_SEQ_PRODUTO_VRS);

            /*" -1341- MOVE PROPOFID-OPCAO-COBER TO LK-0071-I-COD-OPC-COBERTURA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER, GE0071W.LK_0071_I_COD_OPC_COBERTURA);

            /*" -1342- MOVE ZEROS TO LK-0071-I-COD-OPC-PLANO */
            _.Move(0, GE0071W.LK_0071_I_COD_OPC_PLANO);

            /*" -1343- MOVE 'N' TO LK-0071-I-IND-CONJUGE */
            _.Move("N", GE0071W.LK_0071_I_IND_CONJUGE);

            /*" -1344- MOVE PROPOFID-DATA-PROPOSTA(1:4) TO WS-ANO-BASE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Substring(1, 4), WS_WORKING.WS_AUXILIARES.WS_ANO_BASE);

            /*" -1345- MOVE BI0005L-S-DATA-NASC(1:4) TO WS-ANO-NASC */
            _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.Substring(1, 4), WS_WORKING.WS_AUXILIARES.WS_ANO_NASC);

            /*" -1346- COMPUTE WS-IDADE = WS-ANO-BASE - WS-ANO-NASC */
            WS_WORKING.WS_AUXILIARES.WS_IDADE.Value = WS_WORKING.WS_AUXILIARES.WS_ANO_BASE - WS_WORKING.WS_AUXILIARES.WS_ANO_NASC;

            /*" -1348- IF BI0005L-S-DATA-NASC(6:5) GREATER PROPOFID-DATA-PROPOSTA(6:5) */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.Substring(6, 5) > PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Substring(6, 5))
            {

                /*" -1349- COMPUTE WS-IDADE = WS-IDADE - 1 */
                WS_WORKING.WS_AUXILIARES.WS_IDADE.Value = WS_WORKING.WS_AUXILIARES.WS_IDADE - 1;

                /*" -1350- END-IF */
            }


            /*" -1351- MOVE WS-IDADE TO LK-0071-I-NUM-IDADE */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_IDADE, GE0071W.LK_0071_I_NUM_IDADE);

            /*" -1354- DISPLAY 'LK-0071-I-NUM-IDADE: ' LK-0071-I-NUM-IDADE */
            _.Display($"LK-0071-I-NUM-IDADE: {GE0071W.LK_0071_I_NUM_IDADE}");

            /*" -1356- MOVE 'GE0071S' TO WS-PGM-CALL */
            _.Move("GE0071S", WS_WORKING.WS_AUXILIARES.WS_PGM_CALL);

            /*" -1388- CALL WS-PGM-CALL USING LK-0071-E-TRACE LK-0071-E-COD-USUARIO LK-0071-E-NOM-PROGRAMA LK-0071-E-ACAO LK-0071-I-COD-PRODUTO LK-0071-I-SEQ-PRODUTO-VRS LK-0071-I-COD-OPC-COBERTURA LK-0071-I-COD-OPC-PLANO LK-0071-I-IND-CONJUGE LK-0071-I-NUM-IDADE LK-0071-S-NUM-IDADE-INI LK-0071-S-NUM-IDADE-FIM LK-0071-S-VLR-INI-PREMIO LK-0071-S-VLR-FIM-PREMIO LK-0071-S-PCT-IOF LK-0071-S-PCT-REENQUADRAMENTO LK-0071-S-IND-PERMIT-VENDA LK-0071-S-VLR-TOTAL-IS LK-0071-S-QTD-OCC LK-0071-S-ARR LK-0071-IND-ERRO LK-0071-MSG-ERRO LK-0071-NOM-TABELA LK-0071-SQLCODE LK-0071-SQLERRMC LK-0071-SQLSTATE */
            _.Call(WS_WORKING.WS_AUXILIARES.WS_PGM_CALL, GE0071W, GE0071W.LK_0071_S_ARR);

            /*" -1389- IF LK-0071-IND-ERRO NOT EQUAL ZEROS */

            if (GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO != 00)
            {

                /*" -1390- DISPLAY '***' */
                _.Display($"***");

                /*" -1391- DISPLAY ' 17300-00-OBTER-COBERTURA  ' */
                _.Display($" 17300-00-OBTER-COBERTURA  ");

                /*" -1392- DISPLAY ' CALL GE0071S ' */
                _.Display($" CALL GE0071S ");

                /*" -1393- DISPLAY ' ERRO CALL GE0071S(' LK-0071-IND-ERRO ')' */

                $" ERRO CALL GE0071S({GE0071W.LK_0071_S_ARR.LK_0071_IND_ERRO})"
                .Display();

                /*" -1394- DISPLAY ' LK-0071-E-TRACE  : ' LK-0071-E-TRACE */
                _.Display($" LK-0071-E-TRACE  : {GE0071W.LK_0071_E_TRACE}");

                /*" -1395- DISPLAY ' LK-0071-E-COD-USU: ' LK-0071-E-COD-USUARIO */
                _.Display($" LK-0071-E-COD-USU: {GE0071W.LK_0071_E_COD_USUARIO}");

                /*" -1396- DISPLAY ' LK-0071-E-NOM-PRO: ' LK-0071-E-NOM-PROGRAMA */
                _.Display($" LK-0071-E-NOM-PRO: {GE0071W.LK_0071_E_NOM_PROGRAMA}");

                /*" -1397- DISPLAY ' LK-0071-E-ACAO   : ' LK-0071-E-ACAO */
                _.Display($" LK-0071-E-ACAO   : {GE0071W.LK_0071_E_ACAO}");

                /*" -1398- DISPLAY ' LK-0071-I-COD-PRO: ' LK-0071-I-COD-PRODUTO */
                _.Display($" LK-0071-I-COD-PRO: {GE0071W.LK_0071_I_COD_PRODUTO}");

                /*" -1399- DISPLAY ' LK-0071-I-SEQ-PRO: ' LK-0071-I-SEQ-PRODUTO-VRS */
                _.Display($" LK-0071-I-SEQ-PRO: {GE0071W.LK_0071_I_SEQ_PRODUTO_VRS}");

                /*" -1400- DISPLAY ' LK-0071-I-COD-OPC: ' LK-0071-I-COD-OPC-COBERTURA */
                _.Display($" LK-0071-I-COD-OPC: {GE0071W.LK_0071_I_COD_OPC_COBERTURA}");

                /*" -1401- DISPLAY ' LK-0071-I-IND-CON: ' LK-0071-I-IND-CONJUGE */
                _.Display($" LK-0071-I-IND-CON: {GE0071W.LK_0071_I_IND_CONJUGE}");

                /*" -1402- DISPLAY ' LK-0071-I-NUM-IDA: ' LK-0071-I-NUM-IDADE */
                _.Display($" LK-0071-I-NUM-IDA: {GE0071W.LK_0071_I_NUM_IDADE}");

                /*" -1403- DISPLAY ' LK-0071-I-COD-OPC: ' LK-0071-I-COD-OPC-PLANO */
                _.Display($" LK-0071-I-COD-OPC: {GE0071W.LK_0071_I_COD_OPC_PLANO}");

                /*" -1404- DISPLAY '***' */
                _.Display($"***");

                /*" -1405- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1407- END-IF */
            }


            /*" -1408- DISPLAY '** NUM-IDADE-INI.......: ' LK-0071-S-NUM-IDADE-INI */
            _.Display($"** NUM-IDADE-INI.......: {GE0071W.LK_0071_S_NUM_IDADE_INI}");

            /*" -1409- DISPLAY '** COD-OPC-PLANO.......: ' LK-0071-I-COD-OPC-PLANO */
            _.Display($"** COD-OPC-PLANO.......: {GE0071W.LK_0071_I_COD_OPC_PLANO}");

            /*" -1410- DISPLAY '** NUM-IDADE-FIM.......: ' LK-0071-S-NUM-IDADE-FIM */
            _.Display($"** NUM-IDADE-FIM.......: {GE0071W.LK_0071_S_NUM_IDADE_FIM}");

            /*" -1411- DISPLAY '** VLR-INI-PREMIO......: ' LK-0071-S-VLR-INI-PREMIO */
            _.Display($"** VLR-INI-PREMIO......: {GE0071W.LK_0071_S_VLR_INI_PREMIO}");

            /*" -1412- DISPLAY '** VLR-FIM-PREMIO......: ' LK-0071-S-VLR-FIM-PREMIO */
            _.Display($"** VLR-FIM-PREMIO......: {GE0071W.LK_0071_S_VLR_FIM_PREMIO}");

            /*" -1413- DISPLAY '**PCT-IOF..............: ' LK-0071-S-PCT-IOF */
            _.Display($"**PCT-IOF..............: {GE0071W.LK_0071_S_PCT_IOF}");

            /*" -1415- DISPLAY '**PCT-REENQUADRAMENTO..: ' LK-0071-S-PCT-REENQUADRAMENTO */
            _.Display($"**PCT-REENQUADRAMENTO..: {GE0071W.LK_0071_S_PCT_REENQUADRAMENTO}");

            /*" -1417- DISPLAY '**IND-PERMIT-VENDA.....: ' LK-0071-S-IND-PERMIT-VENDA */
            _.Display($"**IND-PERMIT-VENDA.....: {GE0071W.LK_0071_S_IND_PERMIT_VENDA}");

            /*" -1418- IF LK-0071-S-IND-PERMIT-VENDA = 'N' */

            if (GE0071W.LK_0071_S_IND_PERMIT_VENDA == "N")
            {

                /*" -1419- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -1420- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -1421- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -1422- DISPLAY '** VENDA NAO PERMITIDA PARA ESTA IDADE **' */
                _.Display($"** VENDA NAO PERMITIDA PARA ESTA IDADE **");

                /*" -1423- END-IF */
            }


            /*" -1425- DISPLAY '** QTD-COBERTURAS......: ' LK-0071-S-QTD-OCC */
            _.Display($"** QTD-COBERTURAS......: {GE0071W.LK_0071_S_QTD_OCC}");

            /*" -1425- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_17300_99_SAIDA*/

        [StopWatch]
        /*" M-19000-00-TRATA-CLIENTES-SECTION */
        private void M_19000_00_TRATA_CLIENTES_SECTION()
        {
            /*" -1435- MOVE '19000-00-TRATA-CLIENTES     ' TO PARAGRAFO */
            _.Move("19000-00-TRATA-CLIENTES     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1436- MOVE '19000' TO COMANDO */
            _.Move("19000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1439- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1447- PERFORM M_19000_00_TRATA_CLIENTES_DB_SELECT_1 */

            M_19000_00_TRATA_CLIENTES_DB_SELECT_1();

            /*" -1454- DISPLAY 'SEL CLIENTES ' BI0005L-S-CPF '/' BI0005L-S-DATA-NASC '/' WS-COD-CLI-ATU '*SQLCODE: ' SQLCODE */

            $"SEL CLIENTES {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC}/{WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1455- IF SQLCODE EQUAL ZEROS OR -811 */

            if (DB.SQLCODE.In("00", "-811"))
            {

                /*" -1456- ADD 001 TO AC-CLI-LID */
                WS_WORKING.AC_CONTADORES.AC_CLI_LID.Value = WS_WORKING.AC_CONTADORES.AC_CLI_LID + 001;

                /*" -1457- MOVE 'A' TO N88-ACAO-CLI */
                _.Move("A", WS_WORKING.WS_NIVEIS_88.N88_ACAO_CLI);

                /*" -1458- ELSE */
            }
            else
            {


                /*" -1459- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1460- MOVE '%' TO N88-ACAO-CLI */
                    _.Move("%", WS_WORKING.WS_NIVEIS_88.N88_ACAO_CLI);

                    /*" -1462- PERFORM 19100-00-INS-CLIENTES THRU 19100-99-SAIDA UNTIL INS-CLIENTE */

                    while (!(WS_WORKING.WS_NIVEIS_88.N88_ACAO_CLI["INS_CLIENTE"]))
                    {

                        M_19100_00_INS_CLIENTES_SECTION();
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_19100_99_SAIDA*/

                    }

                    /*" -1463- PERFORM 19300-00-INS-GE-DOC THRU 19300-99-SAIDA */

                    M_19300_00_INS_GE_DOC_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_19300_99_SAIDA*/


                    /*" -1464- ELSE */
                }
                else
                {


                    /*" -1465- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1466- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1467- DISPLAY ' 19000-00-TRATA-CLIENTES ' */
                    _.Display($" 19000-00-TRATA-CLIENTES ");

                    /*" -1468- DISPLAY ' ERRO SEL CLIENTES (' WS-SQLCODE ')' */

                    $" ERRO SEL CLIENTES ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1469- DISPLAY ' CPF: ' BI0005L-S-CPF */
                    _.Display($" CPF: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF}");

                    /*" -1470- DISPLAY ' NASC: ' BI0005L-S-DATA-NASC */
                    _.Display($" NASC: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC}");

                    /*" -1471- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1472- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1474- END-IF */
                }


                /*" -1474- . */
            }


        }

        [StopWatch]
        /*" M-19000-00-TRATA-CLIENTES-DB-SELECT-1 */
        public void M_19000_00_TRATA_CLIENTES_DB_SELECT_1()
        {
            /*" -1447- EXEC SQL SELECT COD_CLIENTE INTO :WS-COD-CLI-ATU FROM SEGUROS.CLIENTES WHERE CGCCPF = :BI0005L-S-CPF AND DATA_NASCIMENTO = :BI0005L-S-DATA-NASC AND NOME_RAZAO <> ' ' WITH UR END-EXEC */

            var m_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1 = new M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1()
            {
                BI0005L_S_DATA_NASC = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.ToString(),
                BI0005L_S_CPF = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.ToString(),
            };

            var executed_1 = M_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1.Execute(m_19000_00_TRATA_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_CLI_ATU, WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_19000_99_SAIDA*/

        [StopWatch]
        /*" M-19100-00-INS-CLIENTES-SECTION */
        private void M_19100_00_INS_CLIENTES_SECTION()
        {
            /*" -1484- MOVE '19100-00-INS-CLIENTES       ' TO PARAGRAFO */
            _.Move("19100-00-INS-CLIENTES       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1485- MOVE '19100' TO COMANDO */
            _.Move("19100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1488- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1490- ADD 001 TO NUM-CLIENTE OF DCLNUMERO-OUTROS */
            NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.Value = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE + 001;

            /*" -1494- MOVE NUM-CLIENTE OF DCLNUMERO-OUTROS TO WS-COD-CLI-ATU */
            _.Move(NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE, WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU);

            /*" -1530- PERFORM M_19100_00_INS_CLIENTES_DB_INSERT_1 */

            M_19100_00_INS_CLIENTES_DB_INSERT_1();

            /*" -1532- DISPLAY 'INS CLIENTES' */
            _.Display($"INS CLIENTES");

            /*" -1535- DISPLAY 'CLIENTE: ' WS-COD-CLI-ATU '*SQLCODE: ' SQLCODE */

            $"CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1536- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1537- ADD 001 TO AC-CLI-GRV */
                WS_WORKING.AC_CONTADORES.AC_CLI_GRV.Value = WS_WORKING.AC_CONTADORES.AC_CLI_GRV + 001;

                /*" -1538- MOVE 'I' TO N88-ACAO-CLI */
                _.Move("I", WS_WORKING.WS_NIVEIS_88.N88_ACAO_CLI);

                /*" -1539- ELSE */
            }
            else
            {


                /*" -1540- IF SQLCODE NOT EQUAL -803 */

                if (DB.SQLCODE != -803)
                {

                    /*" -1541- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -1542- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1543- DISPLAY ' 19100-00-INS-CLIENTES   ' */
                    _.Display($" 19100-00-INS-CLIENTES   ");

                    /*" -1544- DISPLAY ' ERRO INS CLIENTES (' WS-SQLCODE ')' */

                    $" ERRO INS CLIENTES ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -1545- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                    _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                    /*" -1546- DISPLAY '***' */
                    _.Display($"***");

                    /*" -1547- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1549- END-IF */
                }


                /*" -1549- . */
            }


        }

        [StopWatch]
        /*" M-19100-00-INS-CLIENTES-DB-INSERT-1 */
        public void M_19100_00_INS_CLIENTES_DB_INSERT_1()
        {
            /*" -1530- EXEC SQL INSERT INTO SEGUROS.CLIENTES (COD_CLIENTE, NOME_RAZAO, TIPO_PESSOA, CGCCPF, SIT_REGISTRO, DATA_NASCIMENTO, COD_EMPRESA, COD_PORTE_EMP, COD_NATUREZA_ATIV, COD_RAMO_ATIVIDADE, COD_ATIVIDADE, IDE_SEXO, ESTADO_CIVIL, COD_GRD_GRUPO_CBO, COD_SUBGRUPO_CBO, COD_GRUPO_BASE_CBO, COD_SUBGR_BASE_CBO) VALUES (:WS-COD-CLI-ATU , :BI0005L-S-NOME-PESSOA , 'F' , :BI0005L-S-CPF , '0' , :BI0005L-S-DATA-NASC :VIND-DAT-NAS , 0 , NULL , NULL , NULL , NULL , :BI0005L-S-SEXO , :BI0005L-S-ESTADO-CIVIL , NULL , NULL , NULL , NULL ) END-EXEC */

            var m_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1 = new M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                BI0005L_S_NOME_PESSOA = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA.ToString(),
                BI0005L_S_CPF = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.ToString(),
                BI0005L_S_DATA_NASC = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.ToString(),
                VIND_DAT_NAS = WS_WORKING.WS_AUXILIARES.VIND_DAT_NAS.ToString(),
                BI0005L_S_SEXO = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.ToString(),
                BI0005L_S_ESTADO_CIVIL = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.ToString(),
            };

            M_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1.Execute(m_19100_00_INS_CLIENTES_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_19100_99_SAIDA*/

        [StopWatch]
        /*" M-19300-00-INS-GE-DOC-SECTION */
        private void M_19300_00_INS_GE_DOC_SECTION()
        {
            /*" -1559- MOVE '19300-00-INS-GE-DOC         ' TO PARAGRAFO */
            _.Move("19300-00-INS-GE-DOC         ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1560- MOVE '19300' TO COMANDO */
            _.Move("19300", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1563- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1564- IF BI0005L-S-DATA-EXPED EQUAL SPACES */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_EXPED.IsEmpty())
            {

                /*" -1565- MOVE '0001-01-01' TO BI0005L-S-DATA-EXPED */
                _.Move("0001-01-01", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_EXPED);

                /*" -1566- DISPLAY 'MUDEI A DATA DATA-EXPED PESSSOA-FISICA' */
                _.Display($"MUDEI A DATA DATA-EXPED PESSSOA-FISICA");

                /*" -1568- END-IF */
            }


            /*" -1580- PERFORM M_19300_00_INS_GE_DOC_DB_INSERT_1 */

            M_19300_00_INS_GE_DOC_DB_INSERT_1();

            /*" -1582- DISPLAY 'INS GE_DOC_CLIENTE' */
            _.Display($"INS GE_DOC_CLIENTE");

            /*" -1585- DISPLAY 'CLIENTE: ' WS-COD-CLI-ATU '*SQLCODE: ' SQLCODE */

            $"CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1586- IF SQLCODE EQUAL ZEROS OR -803 */

            if (DB.SQLCODE.In("00", "-803"))
            {

                /*" -1587- ADD 001 TO AC-GED-GRV */
                WS_WORKING.AC_CONTADORES.AC_GED_GRV.Value = WS_WORKING.AC_CONTADORES.AC_GED_GRV + 001;

                /*" -1588- ELSE */
            }
            else
            {


                /*" -1589- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1590- DISPLAY '***' */
                _.Display($"***");

                /*" -1591- DISPLAY ' 19300-00-INS-GE-DOC       ' */
                _.Display($" 19300-00-INS-GE-DOC       ");

                /*" -1592- DISPLAY ' ERRO INS GE_DOC_CLIENTE(' WS-SQLCODE ')' */

                $" ERRO INS GE_DOC_CLIENTE({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1593- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                /*" -1594- DISPLAY ' NUM-IDENT: ' BI0005L-S-NUM-IDENT */
                _.Display($" NUM-IDENT: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NUM_IDENT}");

                /*" -1595- DISPLAY ' ORGAO-EXPED: ' BI0005L-S-ORGAO-EXPED */
                _.Display($" ORGAO-EXPED: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ORGAO_EXPED}");

                /*" -1596- DISPLAY ' DATA-EXPED: ' BI0005L-S-DATA-EXPED */
                _.Display($" DATA-EXPED: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_EXPED}");

                /*" -1597- DISPLAY ' UF-EXPED: ' BI0005L-S-UF-EXPEDIDORA */
                _.Display($" UF-EXPED: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_UF_EXPEDIDORA}");

                /*" -1598- DISPLAY '***' */
                _.Display($"***");

                /*" -1599- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1601- END-IF */
            }


            /*" -1601- . */

        }

        [StopWatch]
        /*" M-19300-00-INS-GE-DOC-DB-INSERT-1 */
        public void M_19300_00_INS_GE_DOC_DB_INSERT_1()
        {
            /*" -1580- EXEC SQL INSERT INTO SEGUROS.GE_DOC_CLIENTE (COD_CLIENTE , COD_IDENTIFICACAO , NOM_ORGAO_EXP , DTH_EXPEDICAO , COD_UF) VALUES (:WS-COD-CLI-ATU , :BI0005L-S-NUM-IDENT , :BI0005L-S-ORGAO-EXPED , :BI0005L-S-DATA-EXPED , :BI0005L-S-UF-EXPEDIDORA :VIND-UF-EXP ) END-EXEC */

            var m_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1 = new M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                BI0005L_S_NUM_IDENT = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NUM_IDENT.ToString(),
                BI0005L_S_ORGAO_EXPED = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ORGAO_EXPED.ToString(),
                BI0005L_S_DATA_EXPED = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_EXPED.ToString(),
                BI0005L_S_UF_EXPEDIDORA = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_UF_EXPEDIDORA.ToString(),
                VIND_UF_EXP = WS_WORKING.WS_AUXILIARES.VIND_UF_EXP.ToString(),
            };

            M_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1.Execute(m_19300_00_INS_GE_DOC_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_19300_99_SAIDA*/

        [StopWatch]
        /*" M-1B000-00-TRATA-ENDERECO-SECTION */
        private void M_1B000_00_TRATA_ENDERECO_SECTION()
        {
            /*" -1611- MOVE '1B000-00-TRATA-ENDERECO     ' TO PARAGRAFO */
            _.Move("1B000-00-TRATA-ENDERECO     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1612- MOVE '1B000' TO COMANDO */
            _.Move("1B000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1615- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1616- IF INS-CLIENTE */

            if (WS_WORKING.WS_NIVEIS_88.N88_ACAO_CLI["INS_CLIENTE"])
            {

                /*" -1617- MOVE ZEROS TO WS-OCC-END-ATU */
                _.Move(0, WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU);

                /*" -1618- PERFORM 1B100-00-INS-ENDERECO THRU 1B100-99-SAIDA */

                M_1B100_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B100_99_SAIDA*/


                /*" -1619- GO TO 1B000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B000_99_SAIDA*/ //GOTO
                return;

                /*" -1622- END-IF */
            }


            /*" -1623- MOVE ZEROS TO WS-OCC-END-ATU */
            _.Move(0, WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU);

            /*" -1629- PERFORM M_1B000_00_TRATA_ENDERECO_DB_SELECT_1 */

            M_1B000_00_TRATA_ENDERECO_DB_SELECT_1();

            /*" -1635- DISPLAY 'MAX ENDERECOS ' WS-COD-CLI-ATU '/' WS-OCC-END-ATU '*SQLCODE: ' SQLCODE */

            $"MAX ENDERECOS {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1636- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1637- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1638- DISPLAY '***' */
                _.Display($"***");

                /*" -1639- DISPLAY ' 1B000-00-TRATA-ENDERECO' */
                _.Display($" 1B000-00-TRATA-ENDERECO");

                /*" -1640- DISPLAY ' ERRO MAX ENDERECO(' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1641- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                /*" -1642- DISPLAY '***' */
                _.Display($"***");

                /*" -1643- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1646- END-IF */
            }


            /*" -1647- IF WS-OCC-END-ATU EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU == 00)
            {

                /*" -1648- PERFORM 1B100-00-INS-ENDERECO THRU 1B100-99-SAIDA */

                M_1B100_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B100_99_SAIDA*/


                /*" -1649- GO TO 1B000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B000_99_SAIDA*/ //GOTO
                return;

                /*" -1652- END-IF */
            }


            /*" -1661- PERFORM M_1B000_00_TRATA_ENDERECO_DB_SELECT_2 */

            M_1B000_00_TRATA_ENDERECO_DB_SELECT_2();

            /*" -1668- DISPLAY 'SEL ENDERECOS ' WS-COD-CLI-ATU '/' WS-OCC-END-ATU '/' ENDERECO-COD-ENDERECO '*SQLCODE: ' SQLCODE */

            $"SEL ENDERECOS {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}/{ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1669- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1670- ADD 001 TO AC-END-LID */
                WS_WORKING.AC_CONTADORES.AC_END_LID.Value = WS_WORKING.AC_CONTADORES.AC_END_LID + 001;

                /*" -1671- ELSE */
            }
            else
            {


                /*" -1672- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1673- DISPLAY '***' */
                _.Display($"***");

                /*" -1674- DISPLAY ' 1B000-00-TRATA-ENDERECO' */
                _.Display($" 1B000-00-TRATA-ENDERECO");

                /*" -1675- DISPLAY ' ERRO SEL ENDERECO(' WS-SQLCODE ')' */

                $" ERRO SEL ENDERECO({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1676- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                /*" -1677- DISPLAY ' OCORREN: ' WS-OCC-END-ATU */
                _.Display($" OCORREN: {WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}");

                /*" -1678- DISPLAY '***' */
                _.Display($"***");

                /*" -1679- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1682- END-IF */
            }


            /*" -1683- IF ENDERECO-CEP NOT EQUAL BI0005L-S-CEP-R */

            if (ENDERECO.DCLENDERECOS.ENDERECO_CEP != BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R)
            {

                /*" -1684- PERFORM 1B100-00-INS-ENDERECO THRU 1B100-99-SAIDA */

                M_1B100_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B100_99_SAIDA*/


                /*" -1686- END-IF */
            }


            /*" -1686- . */

        }

        [StopWatch]
        /*" M-1B000-00-TRATA-ENDERECO-DB-SELECT-1 */
        public void M_1B000_00_TRATA_ENDERECO_DB_SELECT_1()
        {
            /*" -1629- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO), 0) INTO :WS-OCC-END-ATU FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :WS-COD-CLI-ATU WITH UR END-EXEC */

            var m_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1 = new M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
            };

            var executed_1 = M_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1.Execute(m_1B000_00_TRATA_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_OCC_END_ATU, WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B000_99_SAIDA*/

        [StopWatch]
        /*" M-1B000-00-TRATA-ENDERECO-DB-SELECT-2 */
        public void M_1B000_00_TRATA_ENDERECO_DB_SELECT_2()
        {
            /*" -1661- EXEC SQL SELECT CEP , COD_ENDERECO INTO :ENDERECO-CEP , :ENDERECO-COD-ENDERECO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :WS-COD-CLI-ATU AND OCORR_ENDERECO = :WS-OCC-END-ATU WITH UR END-EXEC */

            var m_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1 = new M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_OCC_END_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.ToString(),
            };

            var executed_1 = M_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1.Execute(m_1B000_00_TRATA_ENDERECO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(executed_1.ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
            }


        }

        [StopWatch]
        /*" M-1B100-00-INS-ENDERECO-SECTION */
        private void M_1B100_00_INS_ENDERECO_SECTION()
        {
            /*" -1696- MOVE '1B100-00-INS-ENDERECO       ' TO PARAGRAFO */
            _.Move("1B100-00-INS-ENDERECO       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1697- MOVE '1B100' TO COMANDO */
            _.Move("1B100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1700- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1701- ADD 001 TO WS-OCC-END-ATU */
            WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.Value = WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU + 001;

            /*" -1703- MOVE ZEROS TO ENDERECO-FAX ENDERECO-TELEX */
            _.Move(0, ENDERECO.DCLENDERECOS.ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);

            /*" -1704- MOVE BI0005L-S-DDD(001) TO ENDERECO-DDD */
            _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);

            /*" -1706- MOVE BI0005L-S-NUM-FONE(001) TO ENDERECO-TELEFONE */
            _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_NUM_FONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);

            /*" -1723- PERFORM M_1B100_00_INS_ENDERECO_DB_INSERT_1 */

            M_1B100_00_INS_ENDERECO_DB_INSERT_1();

            /*" -1729- DISPLAY 'INS ENDERECOS ' WS-COD-CLI-ATU '/' WS-OCC-END-ATU ' SQLCODE: ' SQLCODE */

            $"INS ENDERECOS {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1730- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1731- ADD 001 TO AC-END-GRV */
                WS_WORKING.AC_CONTADORES.AC_END_GRV.Value = WS_WORKING.AC_CONTADORES.AC_END_GRV + 001;

                /*" -1732- ELSE */
            }
            else
            {


                /*" -1733- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1734- DISPLAY '***' */
                _.Display($"***");

                /*" -1735- DISPLAY ' 1B100-00-INS-ENDERECO     ' */
                _.Display($" 1B100-00-INS-ENDERECO     ");

                /*" -1736- DISPLAY ' ERRO INS ENDERECO(' WS-SQLCODE ')' */

                $" ERRO INS ENDERECO({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1738- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU '/' WS-OCC-END-ATU */

                $" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}"
                .Display();

                /*" -1739- DISPLAY '***' */
                _.Display($"***");

                /*" -1740- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1742- END-IF */
            }


            /*" -1742- . */

        }

        [StopWatch]
        /*" M-1B100-00-INS-ENDERECO-DB-INSERT-1 */
        public void M_1B100_00_INS_ENDERECO_DB_INSERT_1()
        {
            /*" -1723- EXEC SQL INSERT INTO SEGUROS.ENDERECOS VALUES (:WS-COD-CLI-ATU , 2 , :WS-OCC-END-ATU , :BI0005L-S-ENDERECO-R , :BI0005L-S-BAIRRO-R , :BI0005L-S-CIDADE-R , :BI0005L-S-SIGLA-UF-R , :BI0005L-S-CEP-R , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-FAX , :ENDERECO-TELEX , '0' , NULL , NULL ) END-EXEC */

            var m_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1 = new M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_OCC_END_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.ToString(),
                BI0005L_S_ENDERECO_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R.ToString(),
                BI0005L_S_BAIRRO_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R.ToString(),
                BI0005L_S_CIDADE_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R.ToString(),
                BI0005L_S_SIGLA_UF_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R.ToString(),
                BI0005L_S_CEP_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R.ToString(),
                ENDERECO_DDD = ENDERECO.DCLENDERECOS.ENDERECO_DDD.ToString(),
                ENDERECO_TELEFONE = ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE.ToString(),
                ENDERECO_FAX = ENDERECO.DCLENDERECOS.ENDERECO_FAX.ToString(),
                ENDERECO_TELEX = ENDERECO.DCLENDERECOS.ENDERECO_TELEX.ToString(),
            };

            M_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1.Execute(m_1B100_00_INS_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1B100_99_SAIDA*/

        [StopWatch]
        /*" M-1C000-00-TRATA-EMAIL-SECTION */
        private void M_1C000_00_TRATA_EMAIL_SECTION()
        {
            /*" -1752- MOVE '1C000-00-TRATA-EMAIL        ' TO PARAGRAFO */
            _.Move("1C000-00-TRATA-EMAIL        ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1753- MOVE '1C000' TO COMANDO */
            _.Move("1C000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1756- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1758- MOVE ZEROS TO WS-SEQ-EMA-ATU */
            _.Move(0, WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU);

            /*" -1759- IF INS-CLIENTE */

            if (WS_WORKING.WS_NIVEIS_88.N88_ACAO_CLI["INS_CLIENTE"])
            {

                /*" -1760- PERFORM 1C100-00-INS-EMAIL THRU 1C100-99-SAIDA */

                M_1C100_00_INS_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C100_99_SAIDA*/


                /*" -1761- GO TO 1C000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C000_99_SAIDA*/ //GOTO
                return;

                /*" -1764- END-IF */
            }


            /*" -1770- PERFORM M_1C000_00_TRATA_EMAIL_DB_SELECT_1 */

            M_1C000_00_TRATA_EMAIL_DB_SELECT_1();

            /*" -1776- DISPLAY 'MAX EMAIL ' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU '*SQLCODE: ' SQLCODE */

            $"MAX EMAIL {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1777- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1778- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1779- DISPLAY '***' */
                _.Display($"***");

                /*" -1780- DISPLAY ' 1C000-00-TRATA-EMAIL' */
                _.Display($" 1C000-00-TRATA-EMAIL");

                /*" -1781- DISPLAY ' ERRO MAX CLIENTE_EMAIL(' WS-SQLCODE ')' */

                $" ERRO MAX CLIENTE_EMAIL({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1782- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                /*" -1783- DISPLAY '***' */
                _.Display($"***");

                /*" -1784- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1787- END-IF */
            }


            /*" -1788- IF WS-SEQ-EMA-ATU EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU == 00)
            {

                /*" -1789- PERFORM 1C100-00-INS-EMAIL THRU 1C100-99-SAIDA */

                M_1C100_00_INS_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C100_99_SAIDA*/


                /*" -1790- GO TO 1C000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C000_99_SAIDA*/ //GOTO
                return;

                /*" -1793- END-IF */
            }


            /*" -1800- PERFORM M_1C000_00_TRATA_EMAIL_DB_SELECT_2 */

            M_1C000_00_TRATA_EMAIL_DB_SELECT_2();

            /*" -1807- DISPLAY 'SEL EMAIL' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU '*' CLIENEMA-EMAIL '*SQLCODE: ' SQLCODE */

            $"SEL EMAIL{WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}*{CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1808- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1809- ADD 001 TO AC-EMA-LID */
                WS_WORKING.AC_CONTADORES.AC_EMA_LID.Value = WS_WORKING.AC_CONTADORES.AC_EMA_LID + 001;

                /*" -1810- ELSE */
            }
            else
            {


                /*" -1811- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1812- DISPLAY '***' */
                _.Display($"***");

                /*" -1813- DISPLAY ' 1C000-00-TRATA-EMAIL' */
                _.Display($" 1C000-00-TRATA-EMAIL");

                /*" -1814- DISPLAY ' ERRO SEL CLIENTE_EMAIL(' WS-SQLCODE ')' */

                $" ERRO SEL CLIENTE_EMAIL({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1816- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU */

                $" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}"
                .Display();

                /*" -1817- DISPLAY '***' */
                _.Display($"***");

                /*" -1818- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1821- END-IF */
            }


            /*" -1822- IF CLIENEMA-EMAIL NOT EQUAL BI0005L-S-EMAIL */

            if (CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL != BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL)
            {

                /*" -1823- PERFORM 1C300-00-UPD-EMAIL THRU 1C300-99-SAIDA */

                M_1C300_00_UPD_EMAIL_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C300_99_SAIDA*/


                /*" -1825- END-IF */
            }


            /*" -1825- . */

        }

        [StopWatch]
        /*" M-1C000-00-TRATA-EMAIL-DB-SELECT-1 */
        public void M_1C000_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -1770- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL), 0) INTO :WS-SEQ-EMA-ATU FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :WS-COD-CLI-ATU WITH UR END-EXEC */

            var m_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
            };

            var executed_1 = M_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(m_1C000_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_SEQ_EMA_ATU, WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C000_99_SAIDA*/

        [StopWatch]
        /*" M-1C000-00-TRATA-EMAIL-DB-SELECT-2 */
        public void M_1C000_00_TRATA_EMAIL_DB_SELECT_2()
        {
            /*" -1800- EXEC SQL SELECT EMAIL INTO :CLIENEMA-EMAIL FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = :WS-COD-CLI-ATU AND SEQ_EMAIL = :WS-SEQ-EMA-ATU WITH UR END-EXEC */

            var m_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1 = new M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_SEQ_EMA_ATU = WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.ToString(),
            };

            var executed_1 = M_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1.Execute(m_1C000_00_TRATA_EMAIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
            }


        }

        [StopWatch]
        /*" M-1C100-00-INS-EMAIL-SECTION */
        private void M_1C100_00_INS_EMAIL_SECTION()
        {
            /*" -1835- MOVE '1C100-00-INS-EMAIL          ' TO PARAGRAFO */
            _.Move("1C100-00-INS-EMAIL          ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1836- MOVE '1C100' TO COMANDO */
            _.Move("1C100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1839- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1841- ADD 001 TO WS-SEQ-EMA-ATU */
            WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.Value = WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU + 001;

            /*" -1846- PERFORM M_1C100_00_INS_EMAIL_DB_INSERT_1 */

            M_1C100_00_INS_EMAIL_DB_INSERT_1();

            /*" -1853- DISPLAY 'INS EMAIL' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU '/' BI0005L-S-EMAIL ' SQLCODE: ' SQLCODE */

            $"INS EMAIL{WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1854- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1855- ADD 001 TO AC-EMA-GRV */
                WS_WORKING.AC_CONTADORES.AC_EMA_GRV.Value = WS_WORKING.AC_CONTADORES.AC_EMA_GRV + 001;

                /*" -1856- ELSE */
            }
            else
            {


                /*" -1857- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1858- DISPLAY '***' */
                _.Display($"***");

                /*" -1859- DISPLAY ' 1C100-00-INS-EMAIL        ' */
                _.Display($" 1C100-00-INS-EMAIL        ");

                /*" -1860- DISPLAY ' ERRO INS CLIENTE_EMAIL (' WS-SQLCODE ')' */

                $" ERRO INS CLIENTE_EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1863- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU '/' BI0005L-S-EMAIL */

                $" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL}"
                .Display();

                /*" -1864- DISPLAY '***' */
                _.Display($"***");

                /*" -1865- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1867- END-IF */
            }


            /*" -1867- . */

        }

        [StopWatch]
        /*" M-1C100-00-INS-EMAIL-DB-INSERT-1 */
        public void M_1C100_00_INS_EMAIL_DB_INSERT_1()
        {
            /*" -1846- EXEC SQL INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES (:WS-COD-CLI-ATU , :WS-SEQ-EMA-ATU , :BI0005L-S-EMAIL ) END-EXEC */

            var m_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1 = new M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_SEQ_EMA_ATU = WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.ToString(),
                BI0005L_S_EMAIL = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL.ToString(),
            };

            M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1.Execute(m_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C100_99_SAIDA*/

        [StopWatch]
        /*" M-1C300-00-UPD-EMAIL-SECTION */
        private void M_1C300_00_UPD_EMAIL_SECTION()
        {
            /*" -1877- MOVE '1C300-00-UPD-EMAIL          ' TO PARAGRAFO */
            _.Move("1C300-00-UPD-EMAIL          ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1878- MOVE '1C300' TO COMANDO */
            _.Move("1C300", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1881- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1886- PERFORM M_1C300_00_UPD_EMAIL_DB_UPDATE_1 */

            M_1C300_00_UPD_EMAIL_DB_UPDATE_1();

            /*" -1894- DISPLAY 'UPD CLIENTE_EMAIL  ' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU '/' BI0005L-S-EMAIL ' SQLCODE: ' SQLCODE */

            $"UPD CLIENTE_EMAIL  {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1895- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1896- ADD 001 TO AC-EMA-ALT */
                WS_WORKING.AC_CONTADORES.AC_EMA_ALT.Value = WS_WORKING.AC_CONTADORES.AC_EMA_ALT + 001;

                /*" -1897- ELSE */
            }
            else
            {


                /*" -1898- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1899- DISPLAY '***' */
                _.Display($"***");

                /*" -1900- DISPLAY ' 1C300-00-UPD-EMAIL        ' */
                _.Display($" 1C300-00-UPD-EMAIL        ");

                /*" -1901- DISPLAY ' ERRO UPD CLIENTE_EMAIL (' WS-SQLCODE ')' */

                $" ERRO UPD CLIENTE_EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1904- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU '/' WS-SEQ-EMA-ATU '/' BI0005L-S-EMAIL */

                $" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL}"
                .Display();

                /*" -1905- DISPLAY '***' */
                _.Display($"***");

                /*" -1906- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1908- END-IF */
            }


            /*" -1908- . */

        }

        [StopWatch]
        /*" M-1C300-00-UPD-EMAIL-DB-UPDATE-1 */
        public void M_1C300_00_UPD_EMAIL_DB_UPDATE_1()
        {
            /*" -1886- EXEC SQL UPDATE SEGUROS.CLIENTE_EMAIL SET EMAIL = :BI0005L-S-EMAIL WHERE COD_CLIENTE = :WS-COD-CLI-ATU AND SEQ_EMAIL = :WS-SEQ-EMA-ATU END-EXEC */

            var m_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1 = new M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1()
            {
                BI0005L_S_EMAIL = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_EMAIL.ToString(),
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_SEQ_EMA_ATU = WS_WORKING.WS_AUXILIARES.WS_SEQ_EMA_ATU.ToString(),
            };

            M_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1.Execute(m_1C300_00_UPD_EMAIL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1C300_99_SAIDA*/

        [StopWatch]
        /*" M-1D000-00-TRATA-GECLIMOV-SECTION */
        private void M_1D000_00_TRATA_GECLIMOV_SECTION()
        {
            /*" -1918- MOVE '1D000-00-TRATA-GECLIMOV     ' TO PARAGRAFO */
            _.Move("1D000-00-TRATA-GECLIMOV     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1919- MOVE '1D000' TO COMANDO */
            _.Move("1D000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1922- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1923- MOVE ZEROS TO WS-OCC-CMO-ATU */
            _.Move(0, WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU);

            /*" -1929- PERFORM M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1 */

            M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1();

            /*" -1935- DISPLAY 'MAX GE_CLIENTES_MOVTO ' WS-COD-CLI-ATU '/' WS-OCC-CMO-ATU '*SQLCODE: ' SQLCODE */

            $"MAX GE_CLIENTES_MOVTO {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1936- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1937- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -1938- DISPLAY '***' */
                _.Display($"***");

                /*" -1939- DISPLAY ' 1D000-00-TRATA-GECLIMOV' */
                _.Display($" 1D000-00-TRATA-GECLIMOV");

                /*" -1940- DISPLAY ' ERRO MAX GE_CLIENTES_MOVT(' WS-SQLCODE ')' */

                $" ERRO MAX GE_CLIENTES_MOVT({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1941- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                /*" -1942- DISPLAY '***' */
                _.Display($"***");

                /*" -1943- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1946- END-IF */
            }


            /*" -1947- IF WS-OCC-CMO-ATU EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU == 00)
            {

                /*" -1948- PERFORM 1D100-00-INS-GECLIMOV THRU 1D100-99-SAIDA */

                M_1D100_00_INS_GECLIMOV_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1D100_99_SAIDA*/


                /*" -1949- ELSE */
            }
            else
            {


                /*" -1950- PERFORM 1D300-00-UPD-GECLIMOV THRU 1D300-99-SAIDA */

                M_1D300_00_UPD_GECLIMOV_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1D300_99_SAIDA*/


                /*" -1952- END-IF */
            }


            /*" -1952- . */

        }

        [StopWatch]
        /*" M-1D000-00-TRATA-GECLIMOV-DB-SELECT-1 */
        public void M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1()
        {
            /*" -1929- EXEC SQL SELECT VALUE(MAX(OCORR_HIST), 0) INTO :WS-OCC-CMO-ATU FROM SEGUROS.GE_CLIENTES_MOVTO WHERE COD_CLIENTE = :WS-COD-CLI-ATU WITH UR END-EXEC */

            var m_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1 = new M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
            };

            var executed_1 = M_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1.Execute(m_1D000_00_TRATA_GECLIMOV_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_OCC_CMO_ATU, WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1D000_99_SAIDA*/

        [StopWatch]
        /*" M-1D100-00-INS-GECLIMOV-SECTION */
        private void M_1D100_00_INS_GECLIMOV_SECTION()
        {
            /*" -1962- MOVE '1D100-00-INS-GECLIMOV       ' TO PARAGRAFO */
            _.Move("1D100-00-INS-GECLIMOV       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1963- MOVE '1D100' TO COMANDO */
            _.Move("1D100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1966- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1968- ADD 001 TO WS-OCC-CMO-ATU */
            WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU.Value = WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU + 001;

            /*" -1969- IF BI0005L-S-DDD(001) GREATER ZEROS */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_DDD > 00)
            {

                /*" -1970- MOVE BI0005L-S-DDD(001) TO GECLIMOV-DDD */
                _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);

                /*" -1971- MOVE BI0005L-S-NUM-FONE(001) TO GECLIMOV-TELEFONE */
                _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_NUM_FONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);

                /*" -1972- ELSE */
            }
            else
            {


                /*" -1973- IF BI0005L-S-DDD(002) GREATER ZEROS */

                if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[002].BI0005L_S_DDD > 00)
                {

                    /*" -1974- MOVE BI0005L-S-DDD(002) TO GECLIMOV-DDD */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[002].BI0005L_S_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);

                    /*" -1975- MOVE BI0005L-S-NUM-FONE(002) TO GECLIMOV-TELEFONE */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[002].BI0005L_S_NUM_FONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);

                    /*" -1976- ELSE */
                }
                else
                {


                    /*" -1977- MOVE BI0005L-S-DDD(003) TO GECLIMOV-DDD */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[003].BI0005L_S_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);

                    /*" -1978- MOVE BI0005L-S-NUM-FONE(003) TO GECLIMOV-TELEFONE */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[003].BI0005L_S_NUM_FONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);

                    /*" -1979- END-IF */
                }


                /*" -1980- END-IF */
            }


            /*" -1982- MOVE ZEROS TO GECLIMOV-FAX */
            _.Move(0, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);

            /*" -1984- IF BI0005L-S-ESTADO-CIVIL EQUAL 'S' OR 'C' OR 'V' OR 'D' OR 'O' */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.In("S", "C", "V", "D", "O"))
            {

                /*" -1985- CONTINUE */

                /*" -1986- ELSE */
            }
            else
            {


                /*" -1987- MOVE 'O' TO BI0005L-S-ESTADO-CIVIL */
                _.Move("O", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL);

                /*" -1990- END-IF */
            }


            /*" -2036- PERFORM M_1D100_00_INS_GECLIMOV_DB_INSERT_1 */

            M_1D100_00_INS_GECLIMOV_DB_INSERT_1();

            /*" -2042- DISPLAY 'INS GE_CLIENTES_MOVTO ' WS-COD-CLI-ATU '/' WS-OCC-CMO-ATU '*SQLCODE: ' SQLCODE */

            $"INS GE_CLIENTES_MOVTO {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2043- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2044- ADD 001 TO AC-GEC-GRV */
                WS_WORKING.AC_CONTADORES.AC_GEC_GRV.Value = WS_WORKING.AC_CONTADORES.AC_GEC_GRV + 001;

                /*" -2045- ELSE */
            }
            else
            {


                /*" -2046- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2047- DISPLAY '***' */
                _.Display($"***");

                /*" -2048- DISPLAY ' 1D100-00-INS-GECLIMOV     ' */
                _.Display($" 1D100-00-INS-GECLIMOV     ");

                /*" -2049- DISPLAY ' ERRO INS GE_CLIENTES_MOV (' WS-SQLCODE ')' */

                $" ERRO INS GE_CLIENTES_MOV ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2056- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU '/' WS-OCC-CMO-ATU '*' 'I' '/' WS-DATA-PROC '/' BI0005L-S-NOME-PESSOA '/' BI0005L-S-TIPO-PESSOA '/' BI0005L-S-SEXO '/' */

                $" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU}*I/{WS_WORKING.WS_AUXILIARES.WS_DATA_PROC}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO}/"
                .Display();

                /*" -2062- DISPLAY BI0005L-S-ESTADO-CIVIL '/' WS-OCC-END-ATU '/' BI0005L-S-ENDERECO-R '/' BI0005L-S-BAIRRO-R '/' BI0005L-S-CIDADE-R '/' BI0005L-S-SIGLA-UF-R '/' */

                $"{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL}/{WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R}/"
                .Display();

                /*" -2068- DISPLAY BI0005L-S-CEP-R '/' GECLIMOV-DDD '/' GECLIMOV-TELEFONE '/' GECLIMOV-FAX '/' BI0005L-S-CPF '/' BI0005L-S-DATA-NASC */

                $"{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R}/{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD}/{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE}/{GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF}/{BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC}"
                .Display();

                /*" -2069- DISPLAY '***' */
                _.Display($"***");

                /*" -2070- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2072- END-IF */
            }


            /*" -2072- . */

        }

        [StopWatch]
        /*" M-1D100-00-INS-GECLIMOV-DB-INSERT-1 */
        public void M_1D100_00_INS_GECLIMOV_DB_INSERT_1()
        {
            /*" -2036- EXEC SQL INSERT INTO SEGUROS.GE_CLIENTES_MOVTO (COD_CLIENTE , OCORR_HIST, TIPO_MOVIMENTO , DATA_ULT_MANUTEN , NOME_RAZAO , TIPO_PESSOA , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , CGCCPF , DATA_NASCIMENTO , COD_USUARIO , TIMESTAMP , DES_COMPLEMENTO) VALUES (:WS-COD-CLI-ATU , :WS-OCC-CMO-ATU , 'I' , :WS-DATA-PROC , :BI0005L-S-NOME-PESSOA :VIND-NULL06 , :BI0005L-S-TIPO-PESSOA :VIND-NULL07 , :BI0005L-S-SEXO :VIND-NULL08 , :BI0005L-S-ESTADO-CIVIL :VIND-NULL09 , :WS-OCC-END-ATU :VIND-NULL10 , :BI0005L-S-ENDERECO-R :VIND-NULL11 , :BI0005L-S-BAIRRO-R :VIND-NULL12 , :BI0005L-S-CIDADE-R :VIND-NULL13 , :BI0005L-S-SIGLA-UF-R :VIND-NULL14 , :BI0005L-S-CEP-R :VIND-NULL15 , :GECLIMOV-DDD :VIND-NULL16 , :GECLIMOV-TELEFONE :VIND-NULL17 , :GECLIMOV-FAX :VIND-NULL18 , :BI0005L-S-CPF :VIND-NULL19 , :BI0005L-S-DATA-NASC :VIND-NULL20 , 'BI1630B' , CURRENT TIMESTAMP , NULL ) END-EXEC */

            var m_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1 = new M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1()
            {
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_OCC_CMO_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU.ToString(),
                WS_DATA_PROC = WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.ToString(),
                BI0005L_S_NOME_PESSOA = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA.ToString(),
                VIND_NULL06 = WS_WORKING.WS_AUXILIARES.VIND_NULL06.ToString(),
                BI0005L_S_TIPO_PESSOA = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA.ToString(),
                VIND_NULL07 = WS_WORKING.WS_AUXILIARES.VIND_NULL07.ToString(),
                BI0005L_S_SEXO = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.ToString(),
                VIND_NULL08 = WS_WORKING.WS_AUXILIARES.VIND_NULL08.ToString(),
                BI0005L_S_ESTADO_CIVIL = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.ToString(),
                VIND_NULL09 = WS_WORKING.WS_AUXILIARES.VIND_NULL09.ToString(),
                WS_OCC_END_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.ToString(),
                VIND_NULL10 = WS_WORKING.WS_AUXILIARES.VIND_NULL10.ToString(),
                BI0005L_S_ENDERECO_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R.ToString(),
                VIND_NULL11 = WS_WORKING.WS_AUXILIARES.VIND_NULL11.ToString(),
                BI0005L_S_BAIRRO_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R.ToString(),
                VIND_NULL12 = WS_WORKING.WS_AUXILIARES.VIND_NULL12.ToString(),
                BI0005L_S_CIDADE_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R.ToString(),
                VIND_NULL13 = WS_WORKING.WS_AUXILIARES.VIND_NULL13.ToString(),
                BI0005L_S_SIGLA_UF_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R.ToString(),
                VIND_NULL14 = WS_WORKING.WS_AUXILIARES.VIND_NULL14.ToString(),
                BI0005L_S_CEP_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R.ToString(),
                VIND_NULL15 = WS_WORKING.WS_AUXILIARES.VIND_NULL15.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_NULL16 = WS_WORKING.WS_AUXILIARES.VIND_NULL16.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_NULL17 = WS_WORKING.WS_AUXILIARES.VIND_NULL17.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_NULL18 = WS_WORKING.WS_AUXILIARES.VIND_NULL18.ToString(),
                BI0005L_S_CPF = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.ToString(),
                VIND_NULL19 = WS_WORKING.WS_AUXILIARES.VIND_NULL19.ToString(),
                BI0005L_S_DATA_NASC = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.ToString(),
                VIND_NULL20 = WS_WORKING.WS_AUXILIARES.VIND_NULL20.ToString(),
            };

            M_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1.Execute(m_1D100_00_INS_GECLIMOV_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1D100_99_SAIDA*/

        [StopWatch]
        /*" M-1D300-00-UPD-GECLIMOV-SECTION */
        private void M_1D300_00_UPD_GECLIMOV_SECTION()
        {
            /*" -2082- MOVE '1D300-00-UPD-GECLIMOV       ' TO PARAGRAFO */
            _.Move("1D300-00-UPD-GECLIMOV       ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2083- MOVE '1D300' TO COMANDO */
            _.Move("1D300", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2086- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2090- MOVE ZEROS TO GECLIMOV-DDD GECLIMOV-TELEFONE GECLIMOV-FAX */
            _.Move(0, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX);

            /*" -2091- IF BI0005L-S-DDD(001) GREATER ZEROS */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_DDD > 00)
            {

                /*" -2092- MOVE BI0005L-S-DDD(001) TO GECLIMOV-DDD */
                _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);

                /*" -2093- MOVE BI0005L-S-NUM-FONE(001) TO GECLIMOV-TELEFONE */
                _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[001].BI0005L_S_NUM_FONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);

                /*" -2094- ELSE */
            }
            else
            {


                /*" -2095- IF BI0005L-S-DDD(002) GREATER ZEROS */

                if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[002].BI0005L_S_DDD > 00)
                {

                    /*" -2096- MOVE BI0005L-S-DDD(002) TO GECLIMOV-DDD */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[002].BI0005L_S_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);

                    /*" -2097- MOVE BI0005L-S-NUM-FONE(002) TO GECLIMOV-TELEFONE */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[002].BI0005L_S_NUM_FONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);

                    /*" -2098- ELSE */
                }
                else
                {


                    /*" -2099- MOVE BI0005L-S-DDD(003) TO GECLIMOV-DDD */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[003].BI0005L_S_DDD, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD);

                    /*" -2100- MOVE BI0005L-S-NUM-FONE(003) TO GECLIMOV-TELEFONE */
                    _.Move(BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TELEFONE[003].BI0005L_S_NUM_FONE, GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE);

                    /*" -2101- END-IF */
                }


                /*" -2103- END-IF */
            }


            /*" -2105- IF BI0005L-S-ESTADO-CIVIL EQUAL 'S' OR 'C' OR 'V' OR 'D' OR 'O' */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.In("S", "C", "V", "D", "O"))
            {

                /*" -2106- CONTINUE */

                /*" -2107- ELSE */
            }
            else
            {


                /*" -2108- MOVE 'O' TO BI0005L-S-ESTADO-CIVIL */
                _.Move("O", BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL);

                /*" -2111- END-IF */
            }


            /*" -2135- PERFORM M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1 */

            M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1();

            /*" -2141- DISPLAY 'UPD GE_CLIENTES_MOVTO ' WS-COD-CLI-ATU '/' WS-OCC-CMO-ATU '*SQLCODE: ' SQLCODE */

            $"UPD GE_CLIENTES_MOVTO {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}/{WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2142- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2143- ADD 001 TO AC-GEC-ALT */
                WS_WORKING.AC_CONTADORES.AC_GEC_ALT.Value = WS_WORKING.AC_CONTADORES.AC_GEC_ALT + 001;

                /*" -2144- ELSE */
            }
            else
            {


                /*" -2145- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2146- DISPLAY '***' */
                _.Display($"***");

                /*" -2147- DISPLAY ' 1D300-00-UPD-GECLIMOV     ' */
                _.Display($" 1D300-00-UPD-GECLIMOV     ");

                /*" -2148- DISPLAY ' ERRO UPD GE_CLIENTES_MOV (' WS-SQLCODE ')' */

                $" ERRO UPD GE_CLIENTES_MOV ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2149- DISPLAY ' CLIENTE: ' WS-COD-CLI-ATU */
                _.Display($" CLIENTE: {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

                /*" -2150- DISPLAY '/' WS-OCC-CMO-ATU */
                _.Display($"/{WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU}");

                /*" -2151- DISPLAY '***' */
                _.Display($"***");

                /*" -2152- DISPLAY 'A' */
                _.Display($"A");

                /*" -2153- DISPLAY 'WS-DATA-PROC          : ' WS-DATA-PROC */
                _.Display($"WS-DATA-PROC          : {WS_WORKING.WS_AUXILIARES.WS_DATA_PROC}");

                /*" -2154- DISPLAY 'BI0005L-S-NOME-PESSOA : ' BI0005L-S-NOME-PESSOA */
                _.Display($"BI0005L-S-NOME-PESSOA : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA}");

                /*" -2155- DISPLAY 'BI0005L-S-TIPO-PESSOA : ' BI0005L-S-TIPO-PESSOA */
                _.Display($"BI0005L-S-TIPO-PESSOA : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA}");

                /*" -2156- DISPLAY 'BI0005L-S-SEXO        : ' BI0005L-S-SEXO */
                _.Display($"BI0005L-S-SEXO        : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO}");

                /*" -2157- DISPLAY 'BI0005L-S-ESTADO-CIVIL: ' BI0005L-S-ESTADO-CIVIL */
                _.Display($"BI0005L-S-ESTADO-CIVIL: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL}");

                /*" -2158- DISPLAY 'WS-OCC-END-ATU        : ' WS-OCC-END-ATU */
                _.Display($"WS-OCC-END-ATU        : {WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}");

                /*" -2159- DISPLAY 'BI0005L-S-ENDERECO-R  : ' BI0005L-S-ENDERECO-R */
                _.Display($"BI0005L-S-ENDERECO-R  : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R}");

                /*" -2160- DISPLAY 'BI0005L-S-BAIRRO-R    : ' BI0005L-S-BAIRRO-R */
                _.Display($"BI0005L-S-BAIRRO-R    : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R}");

                /*" -2161- DISPLAY 'BI0005L-S-CIDADE-R    : ' BI0005L-S-CIDADE-R */
                _.Display($"BI0005L-S-CIDADE-R    : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R}");

                /*" -2162- DISPLAY 'BI0005L-S-SIGLA-UF-R  : ' BI0005L-S-SIGLA-UF-R */
                _.Display($"BI0005L-S-SIGLA-UF-R  : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R}");

                /*" -2163- DISPLAY 'BI0005L-S-CEP-R       : ' BI0005L-S-CEP-R */
                _.Display($"BI0005L-S-CEP-R       : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R}");

                /*" -2164- DISPLAY 'GECLIMOV-DDD          : ' GECLIMOV-DDD */
                _.Display($"GECLIMOV-DDD          : {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD}");

                /*" -2165- DISPLAY 'GECLIMOV-TELEFONE     : ' GECLIMOV-TELEFONE */
                _.Display($"GECLIMOV-TELEFONE     : {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE}");

                /*" -2166- DISPLAY 'GECLIMOV-FAX          : ' GECLIMOV-FAX */
                _.Display($"GECLIMOV-FAX          : {GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX}");

                /*" -2167- DISPLAY 'BI0005L-S-CPF         : ' BI0005L-S-CPF */
                _.Display($"BI0005L-S-CPF         : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF}");

                /*" -2168- DISPLAY 'BI0005L-S-DATA-NASC   : ' BI0005L-S-DATA-NASC */
                _.Display($"BI0005L-S-DATA-NASC   : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC}");

                /*" -2169- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2171- END-IF */
            }


            /*" -2171- . */

        }

        [StopWatch]
        /*" M-1D300-00-UPD-GECLIMOV-DB-UPDATE-1 */
        public void M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1()
        {
            /*" -2135- EXEC SQL UPDATE SEGUROS.GE_CLIENTES_MOVTO SET TIPO_MOVIMENTO = 'A' , DATA_ULT_MANUTEN = :WS-DATA-PROC , NOME_RAZAO = :BI0005L-S-NOME-PESSOA :VIND-NULL06, TIPO_PESSOA = :BI0005L-S-TIPO-PESSOA :VIND-NULL07, IDE_SEXO = :BI0005L-S-SEXO :VIND-NULL08, ESTADO_CIVIL = :BI0005L-S-ESTADO-CIVIL :VIND-NULL09, OCORR_ENDERECO = :WS-OCC-END-ATU :VIND-NULL10, ENDERECO = :BI0005L-S-ENDERECO-R :VIND-NULL11, BAIRRO = :BI0005L-S-BAIRRO-R :VIND-NULL12, CIDADE = :BI0005L-S-CIDADE-R :VIND-NULL13, SIGLA_UF = :BI0005L-S-SIGLA-UF-R :VIND-NULL14, CEP = :BI0005L-S-CEP-R :VIND-NULL15, DDD = :GECLIMOV-DDD :VIND-NULL16, TELEFONE = :GECLIMOV-TELEFONE :VIND-NULL17, FAX = :GECLIMOV-FAX :VIND-NULL18, CGCCPF = :BI0005L-S-CPF :VIND-NULL19, DATA_NASCIMENTO = :BI0005L-S-DATA-NASC :VIND-NULL20, COD_USUARIO = 'BI1630B' , TIMESTAMP = CURRENT TIMESTAMP WHERE COD_CLIENTE = :WS-COD-CLI-ATU AND OCORR_HIST = :WS-OCC-CMO-ATU END-EXEC */

            var m_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1 = new M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1()
            {
                BI0005L_S_ESTADO_CIVIL = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.ToString(),
                VIND_NULL09 = WS_WORKING.WS_AUXILIARES.VIND_NULL09.ToString(),
                BI0005L_S_NOME_PESSOA = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_NOME_PESSOA.ToString(),
                VIND_NULL06 = WS_WORKING.WS_AUXILIARES.VIND_NULL06.ToString(),
                BI0005L_S_TIPO_PESSOA = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_TIPO_PESSOA.ToString(),
                VIND_NULL07 = WS_WORKING.WS_AUXILIARES.VIND_NULL07.ToString(),
                BI0005L_S_ENDERECO_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ENDERECO_R.ToString(),
                VIND_NULL11 = WS_WORKING.WS_AUXILIARES.VIND_NULL11.ToString(),
                BI0005L_S_SIGLA_UF_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SIGLA_UF_R.ToString(),
                VIND_NULL14 = WS_WORKING.WS_AUXILIARES.VIND_NULL14.ToString(),
                BI0005L_S_DATA_NASC = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_DATA_NASC.ToString(),
                VIND_NULL20 = WS_WORKING.WS_AUXILIARES.VIND_NULL20.ToString(),
                BI0005L_S_BAIRRO_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_BAIRRO_R.ToString(),
                VIND_NULL12 = WS_WORKING.WS_AUXILIARES.VIND_NULL12.ToString(),
                BI0005L_S_CIDADE_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CIDADE_R.ToString(),
                VIND_NULL13 = WS_WORKING.WS_AUXILIARES.VIND_NULL13.ToString(),
                GECLIMOV_TELEFONE = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_TELEFONE.ToString(),
                VIND_NULL17 = WS_WORKING.WS_AUXILIARES.VIND_NULL17.ToString(),
                BI0005L_S_CEP_R = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CEP_R.ToString(),
                VIND_NULL15 = WS_WORKING.WS_AUXILIARES.VIND_NULL15.ToString(),
                BI0005L_S_SEXO = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.ToString(),
                VIND_NULL08 = WS_WORKING.WS_AUXILIARES.VIND_NULL08.ToString(),
                WS_OCC_END_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.ToString(),
                VIND_NULL10 = WS_WORKING.WS_AUXILIARES.VIND_NULL10.ToString(),
                BI0005L_S_CPF = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_CPF.ToString(),
                VIND_NULL19 = WS_WORKING.WS_AUXILIARES.VIND_NULL19.ToString(),
                GECLIMOV_DDD = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_DDD.ToString(),
                VIND_NULL16 = WS_WORKING.WS_AUXILIARES.VIND_NULL16.ToString(),
                GECLIMOV_FAX = GECLIMOV.DCLGE_CLIENTES_MOVTO.GECLIMOV_FAX.ToString(),
                VIND_NULL18 = WS_WORKING.WS_AUXILIARES.VIND_NULL18.ToString(),
                WS_DATA_PROC = WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.ToString(),
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                WS_OCC_CMO_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_CMO_ATU.ToString(),
            };

            M_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1.Execute(m_1D300_00_UPD_GECLIMOV_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1D300_99_SAIDA*/

        [StopWatch]
        /*" M-1F000-00-INSERT-BILHETE-SECTION */
        private void M_1F000_00_INSERT_BILHETE_SECTION()
        {
            /*" -2181- MOVE '1F000-00-INSERT-BILHETE     ' TO PARAGRAFO */
            _.Move("1F000-00-INSERT-BILHETE     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2182- MOVE '1F000' TO COMANDO */
            _.Move("1F000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2185- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2187- INITIALIZE DCLBILHETE */
            _.Initialize(
                BILHETE.DCLBILHETE
            );

            /*" -2188- IF TEM-ERRO-NORMAL */

            if (WS_WORKING.WS_NIVEIS_88.N88_ERRO_NORMAL["TEM_ERRO_NORMAL"])
            {

                /*" -2190- IF TEM-RCAP */

                if (WS_WORKING.WS_NIVEIS_88.N88_RCAPS["TEM_RCAP"])
                {

                    /*" -2191- MOVE '1' TO WS-SIT-BIL */
                    _.Move("1", WS_WORKING.WS_AUXILIARES.WS_SIT_BIL);

                    /*" -2193- ELSE */
                }
                else
                {


                    /*" -2194- MOVE '3' TO WS-SIT-BIL */
                    _.Move("3", WS_WORKING.WS_AUXILIARES.WS_SIT_BIL);

                    /*" -2195- ELSE */
                }

            }
            else
            {


                /*" -2197- IF TEM-RCAP */

                if (WS_WORKING.WS_NIVEIS_88.N88_RCAPS["TEM_RCAP"])
                {

                    /*" -2198- MOVE '0' TO WS-SIT-BIL */
                    _.Move("0", WS_WORKING.WS_AUXILIARES.WS_SIT_BIL);

                    /*" -2200- ELSE */
                }
                else
                {


                    /*" -2201- MOVE '2' TO WS-SIT-BIL */
                    _.Move("2", WS_WORKING.WS_AUXILIARES.WS_SIT_BIL);

                    /*" -2202- END-IF */
                }


                /*" -2204- END-IF */
            }


            /*" -2206- DISPLAY 'WS-SIT-BIL(1): ' WS-SIT-BIL */
            _.Display($"WS-SIT-BIL(1): {WS_WORKING.WS_AUXILIARES.WS_SIT_BIL}");

            /*" -2207- IF TEM-ERRO-CRITICO */

            if (WS_WORKING.WS_NIVEIS_88.N88_ERRO_CRITICO["TEM_ERRO_CRITICO"])
            {

                /*" -2208- MOVE '1' TO WS-SIT-BIL */
                _.Move("1", WS_WORKING.WS_AUXILIARES.WS_SIT_BIL);

                /*" -2209- DISPLAY 'WS-SIT-BIL(3): ' WS-SIT-BIL */
                _.Display($"WS-SIT-BIL(3): {WS_WORKING.WS_AUXILIARES.WS_SIT_BIL}");

                /*" -2212- END-IF */
            }


            /*" -2214- MOVE TAB-COD-FON(PROPOFID-AGECOBR) TO BILHETE-FONTE */
            _.Move(TABELAS.TABELA_AGENCIAS.TAB_AGENCIAS_ZEROS.TAB_AGENCIAS_LIMPA.TAB_AGENCIAS[PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR].TAB_COD_FON, BILHETE.DCLBILHETE.BILHETE_FONTE);

            /*" -2217- IF BILHETE-FONTE EQUAL ZEROS OR BILHETE-FONTE EQUAL 010 OR BILHETE-FONTE GREATER 099 */

            if (BILHETE.DCLBILHETE.BILHETE_FONTE == 00 || BILHETE.DCLBILHETE.BILHETE_FONTE == 010 || BILHETE.DCLBILHETE.BILHETE_FONTE > 099)
            {

                /*" -2218- MOVE 005 TO BILHETE-FONTE */
                _.Move(005, BILHETE.DCLBILHETE.BILHETE_FONTE);

                /*" -2220- END-IF */
            }


            /*" -2221- DISPLAY 'BI0005L-S-COD-CBO: ' BI0005L-S-COD-CBO */
            _.Display($"BI0005L-S-COD-CBO: {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO}");

            /*" -2222- IF BI0005L-S-COD-CBO EQUAL ZEROS */

            if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO == 00)
            {

                /*" -2223- PERFORM 1F100-00-SEL-PF-CBO THRU 1F100-99-SAIDA */

                M_1F100_00_SEL_PF_CBO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1F100_99_SAIDA*/


                /*" -2224- ELSE */
            }
            else
            {


                /*" -2225- IF BI0005L-S-COD-CBO GREATER 999 */

                if (BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO > 999)
                {

                    /*" -2226- MOVE 999 TO BI0005L-S-COD-CBO */
                    _.Move(999, BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO);

                    /*" -2227- END-IF */
                }


                /*" -2228- DISPLAY 'CBO: ' TAB-DES-COM(BI0005L-S-COD-CBO) */
                _.Display($"CBO: {TABELAS.TABELA_CBO.TAB_CBO_ZEROS.TAB_CBO_LIMPA.TAB_CBO[BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO]}");

                /*" -2230- MOVE TAB-DES-COM(BI0005L-S-COD-CBO) TO BILHETE-PROFISSAO */
                _.Move(TABELAS.TABELA_CBO.TAB_CBO_ZEROS.TAB_CBO_LIMPA.TAB_CBO[BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_COD_CBO].TAB_DES_COM, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);

                /*" -2231- IF BILHETE-PROFISSAO EQUAL SPACES */

                if (BILHETE.DCLBILHETE.BILHETE_PROFISSAO.IsEmpty())
                {

                    /*" -2232- PERFORM 1F100-00-SEL-PF-CBO THRU 1F100-99-SAIDA */

                    M_1F100_00_SEL_PF_CBO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1F100_99_SAIDA*/


                    /*" -2233- END-IF */
                }


                /*" -2235- END-IF */
            }


            /*" -2236- IF PROPOFID-FAIXA-RENDA-IND GREATER '5' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND > "5")
            {

                /*" -2238- MOVE 005 TO BILHETE-BI-FAIXA-RENDA-IND */
                _.Move(005, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);

                /*" -2239- ELSE */
            }
            else
            {


                /*" -2241- MOVE PROPOFID-FAIXA-RENDA-IND TO BILHETE-BI-FAIXA-RENDA-IND */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND);

                /*" -2243- END-IF */
            }


            /*" -2244- IF PROPOFID-FAIXA-RENDA-FAM GREATER '5' */

            if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM > "5")
            {

                /*" -2246- MOVE 005 TO BILHETE-BI-FAIXA-RENDA-FAM */
                _.Move(005, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);

                /*" -2247- ELSE */
            }
            else
            {


                /*" -2249- MOVE PROPOFID-FAIXA-RENDA-FAM TO BILHETE-BI-FAIXA-RENDA-FAM */
                _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM, BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM);

                /*" -2251- END-IF */
            }


            /*" -2252- MOVE 037 TO BILHETE-RAMO */
            _.Move(037, BILHETE.DCLBILHETE.BILHETE_RAMO);

            /*" -2253- MOVE PROPOFID-COD-PLANO TO BILHETE-COD-PRODUTO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO, BILHETE.DCLBILHETE.BILHETE_COD_PRODUTO);

            /*" -2255- MOVE ZEROS TO BILHETE-NUM-APOL-ANTERIOR */
            _.Move(0, BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR);

            /*" -2259- MOVE LK-0071-I-COD-OPC-PLANO TO BILHETE-OPC-COBERTURA */
            _.Move(GE0071W.LK_0071_I_COD_OPC_PLANO, BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA);

            /*" -2330- PERFORM M_1F000_00_INSERT_BILHETE_DB_INSERT_1 */

            M_1F000_00_INSERT_BILHETE_DB_INSERT_1();

            /*" -2335- DISPLAY 'INS BILHETES ' PROPOFID-NUM-SICOB ' SQLCODE: ' SQLCODE */

            $"INS BILHETES {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2336- DISPLAY 'PROPOFID-NUM-SICOB  : ' PROPOFID-NUM-SICOB */
            _.Display($"PROPOFID-NUM-SICOB  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

            /*" -2337- DISPLAY 'BILHETE-FONTE       : ' BILHETE-FONTE */
            _.Display($"BILHETE-FONTE       : {BILHETE.DCLBILHETE.BILHETE_FONTE}");

            /*" -2338- DISPLAY 'PROPOFID-AGECOBR    : ' PROPOFID-AGECOBR */
            _.Display($"PROPOFID-AGECOBR    : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR}");

            /*" -2339- DISPLAY 'PROPOFID-NRMATRVEN  : ' PROPOFID-NRMATRVEN */
            _.Display($"PROPOFID-NRMATRVEN  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN}");

            /*" -2340- DISPLAY 'PROPOFID-AGECTAVEN  : ' PROPOFID-AGECTAVEN */
            _.Display($"PROPOFID-AGECTAVEN  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN}");

            /*" -2341- DISPLAY 'PROPOFID-OPRCTAVEN  : ' PROPOFID-OPRCTAVEN */
            _.Display($"PROPOFID-OPRCTAVEN  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN}");

            /*" -2342- DISPLAY 'PROPOFID-NUMCTAVEN  : ' PROPOFID-NUMCTAVEN */
            _.Display($"PROPOFID-NUMCTAVEN  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN}");

            /*" -2343- DISPLAY 'PROPOFID-DIGCTAVEN  : ' PROPOFID-DIGCTAVEN */
            _.Display($"PROPOFID-DIGCTAVEN  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN}");

            /*" -2344- DISPLAY 'WS-COD-CLI-ATU      : ' WS-COD-CLI-ATU */
            _.Display($"WS-COD-CLI-ATU      : {WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU}");

            /*" -2345- DISPLAY 'BILHETE-PROFISSAO   : ' BILHETE-PROFISSAO */
            _.Display($"BILHETE-PROFISSAO   : {BILHETE.DCLBILHETE.BILHETE_PROFISSAO}");

            /*" -2346- DISPLAY 'BI0005L-S-SEXO      : ' BI0005L-S-SEXO */
            _.Display($"BI0005L-S-SEXO      : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO}");

            /*" -2347- DISPLAY 'BI0005L-S-ESTADO-C  : ' BI0005L-S-ESTADO-CIVIL */
            _.Display($"BI0005L-S-ESTADO-C  : {BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL}");

            /*" -2348- DISPLAY 'WS-OCC-END-ATU      : ' WS-OCC-END-ATU */
            _.Display($"WS-OCC-END-ATU      : {WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU}");

            /*" -2349- DISPLAY 'PROPOFID-AGECTADEB  : ' PROPOFID-AGECTADEB */
            _.Display($"PROPOFID-AGECTADEB  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB}");

            /*" -2350- DISPLAY 'PROPOFID-OPRCTADEB  : ' PROPOFID-OPRCTADEB */
            _.Display($"PROPOFID-OPRCTADEB  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB}");

            /*" -2351- DISPLAY 'PROPOFID-NUMCTADEB  : ' PROPOFID-NUMCTADEB */
            _.Display($"PROPOFID-NUMCTADEB  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB}");

            /*" -2352- DISPLAY 'PROPOFID-DIGCTADEB  : ' PROPOFID-DIGCTADEB */
            _.Display($"PROPOFID-DIGCTADEB  : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB}");

            /*" -2353- DISPLAY 'BILHETE-OPC-COBERTU : ' BILHETE-OPC-COBERTURA */
            _.Display($"BILHETE-OPC-COBERTU : {BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA}");

            /*" -2354- DISPLAY 'PROPOFID-DTQITBCO   : ' PROPOFID-DTQITBCO */
            _.Display($"PROPOFID-DTQITBCO   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

            /*" -2355- DISPLAY 'PROPOFID-VAL-PAGO   : ' PROPOFID-VAL-PAGO */
            _.Display($"PROPOFID-VAL-PAGO   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO}");

            /*" -2356- DISPLAY 'BILHETE-RAMO        : ' BILHETE-RAMO */
            _.Display($"BILHETE-RAMO        : {BILHETE.DCLBILHETE.BILHETE_RAMO}");

            /*" -2357- DISPLAY 'PROPOFID-DTQITBCO   : ' PROPOFID-DTQITBCO */
            _.Display($"PROPOFID-DTQITBCO   : {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO}");

            /*" -2358- DISPLAY 'WS-DATA-PROC        : ' WS-DATA-PROC */
            _.Display($"WS-DATA-PROC        : {WS_WORKING.WS_AUXILIARES.WS_DATA_PROC}");

            /*" -2359- DISPLAY 'BILHETE-NUM-APOL-ANT: ' BILHETE-NUM-APOL-ANTERIOR */
            _.Display($"BILHETE-NUM-APOL-ANT: {BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR}");

            /*" -2360- DISPLAY 'WS-SIT-BIL          : ' WS-SIT-BIL */
            _.Display($"WS-SIT-BIL          : {WS_WORKING.WS_AUXILIARES.WS_SIT_BIL}");

            /*" -2361- DISPLAY 'BILHETE-BI-FAIXA-REI: ' BILHETE-BI-FAIXA-RENDA-IND */
            _.Display($"BILHETE-BI-FAIXA-REI: {BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND}");

            /*" -2362- DISPLAY 'BILHETE-BI-FAIXA-REF: ' BILHETE-BI-FAIXA-RENDA-FAM */
            _.Display($"BILHETE-BI-FAIXA-REF: {BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM}");

            /*" -2364- DISPLAY 'PRDSIVPF-COD-PRODU  : ' PRDSIVPF-COD-PRODUTO */
            _.Display($"PRDSIVPF-COD-PRODU  : {PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO}");

            /*" -2365- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2366- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2367- DISPLAY '***' */
                _.Display($"***");

                /*" -2368- DISPLAY ' 1F000-00-INSERT-BILHETE   ' */
                _.Display($" 1F000-00-INSERT-BILHETE   ");

                /*" -2369- DISPLAY ' ERRO INS BILHETE (' WS-SQLCODE ')' */

                $" ERRO INS BILHETE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2370- DISPLAY ' PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($" PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2371- DISPLAY ' BILHETE: ' PROPOFID-NUM-SICOB */
                _.Display($" BILHETE: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}");

                /*" -2372- DISPLAY '***' */
                _.Display($"***");

                /*" -2373- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2375- END-IF */
            }


            /*" -2375- . */

        }

        [StopWatch]
        /*" M-1F000-00-INSERT-BILHETE-DB-INSERT-1 */
        public void M_1F000_00_INSERT_BILHETE_DB_INSERT_1()
        {
            /*" -2330- EXEC SQL INSERT INTO SEGUROS.BILHETE ( NUM_BILHETE , NUM_APOLICE , FONTE , AGE_COBRANCA , NUM_MATRICULA , COD_AGENCIA , OPERACAO_CONTA , NUM_CONTA , DIG_CONTA , COD_CLIENTE , PROFISSAO , IDE_SEXO , ESTADO_CIVIL , OCORR_ENDERECO , COD_AGENCIA_DEB , OPERACAO_CONTA_DEB , NUM_CONTA_DEB , DIG_CONTA_DEB , OPC_COBERTURA , DATA_QUITACAO , VAL_RCAP , RAMO , DATA_VENDA , DATA_MOVIMENTO , NUM_APOL_ANTERIOR , SITUACAO , TIP_CANCELAMENTO , SIT_SINISTRO , COD_USUARIO , TIMESTAMP , DATA_CANCELAMENTO , BI_FAIXA_RENDA_IND, BI_FAIXA_RENDA_FAM, COD_PRODUTO ) VALUES (:PROPOFID-NUM-SICOB , 0 , :BILHETE-FONTE , :PROPOFID-AGECOBR , :PROPOFID-NRMATRVEN , :PROPOFID-AGECTAVEN , :PROPOFID-OPRCTAVEN , :PROPOFID-NUMCTAVEN , :PROPOFID-DIGCTAVEN , :WS-COD-CLI-ATU , :BILHETE-PROFISSAO , :BI0005L-S-SEXO , :BI0005L-S-ESTADO-CIVIL , :WS-OCC-END-ATU , :PROPOFID-AGECTADEB , :PROPOFID-OPRCTADEB , :PROPOFID-NUMCTADEB , :PROPOFID-DIGCTADEB , :BILHETE-OPC-COBERTURA , :PROPOFID-DTQITBCO , :PROPOFID-VAL-PAGO , :BILHETE-RAMO , :PROPOFID-DTQITBCO , :WS-DATA-PROC , :BILHETE-NUM-APOL-ANTERIOR , :WS-SIT-BIL , '0' , '0' , 'BI1630B' , CURRENT TIMESTAMP , NULL , :BILHETE-BI-FAIXA-RENDA-IND , :BILHETE-BI-FAIXA-RENDA-FAM , :PRDSIVPF-COD-PRODUTO ) END-EXEC */

            var m_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1 = new M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_SICOB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB.ToString(),
                BILHETE_FONTE = BILHETE.DCLBILHETE.BILHETE_FONTE.ToString(),
                PROPOFID_AGECOBR = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR.ToString(),
                PROPOFID_NRMATRVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN.ToString(),
                PROPOFID_AGECTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN.ToString(),
                PROPOFID_OPRCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN.ToString(),
                PROPOFID_NUMCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN.ToString(),
                PROPOFID_DIGCTAVEN = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN.ToString(),
                WS_COD_CLI_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_CLI_ATU.ToString(),
                BILHETE_PROFISSAO = BILHETE.DCLBILHETE.BILHETE_PROFISSAO.ToString(),
                BI0005L_S_SEXO = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_SEXO.ToString(),
                BI0005L_S_ESTADO_CIVIL = BI0005L_LINKAGE.BI0005L_SAIDA.BI0005L_S_ESTADO_CIVIL.ToString(),
                WS_OCC_END_ATU = WS_WORKING.WS_AUXILIARES.WS_OCC_END_ATU.ToString(),
                PROPOFID_AGECTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB.ToString(),
                PROPOFID_OPRCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB.ToString(),
                PROPOFID_NUMCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB.ToString(),
                PROPOFID_DIGCTADEB = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB.ToString(),
                BILHETE_OPC_COBERTURA = BILHETE.DCLBILHETE.BILHETE_OPC_COBERTURA.ToString(),
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
                PROPOFID_VAL_PAGO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO.ToString(),
                BILHETE_RAMO = BILHETE.DCLBILHETE.BILHETE_RAMO.ToString(),
                WS_DATA_PROC = WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.ToString(),
                BILHETE_NUM_APOL_ANTERIOR = BILHETE.DCLBILHETE.BILHETE_NUM_APOL_ANTERIOR.ToString(),
                WS_SIT_BIL = WS_WORKING.WS_AUXILIARES.WS_SIT_BIL.ToString(),
                BILHETE_BI_FAIXA_RENDA_IND = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_IND.ToString(),
                BILHETE_BI_FAIXA_RENDA_FAM = BILHETE.DCLBILHETE.BILHETE_BI_FAIXA_RENDA_FAM.ToString(),
                PRDSIVPF_COD_PRODUTO = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO.ToString(),
            };

            M_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1.Execute(m_1F000_00_INSERT_BILHETE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1F000_99_SAIDA*/

        [StopWatch]
        /*" M-1F100-00-SEL-PF-CBO-SECTION */
        private void M_1F100_00_SEL_PF_CBO_SECTION()
        {
            /*" -2385- MOVE '1F100-00-SEL-PF-CBO         ' TO PARAGRAFO */
            _.Move("1F100-00-SEL-PF-CBO         ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2386- MOVE '1F100' TO COMANDO */
            _.Move("1F100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2389- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2392- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PF062-NUM-PROPOSTA-SIVPF */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF);

            /*" -2398- PERFORM M_1F100_00_SEL_PF_CBO_DB_SELECT_1 */

            M_1F100_00_SEL_PF_CBO_DB_SELECT_1();

            /*" -2403- DISPLAY 'SEL PF_CBO' PF062-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"SEL PF_CBO{PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2404- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2405- ADD 001 TO AC-PF-CBO */
                WS_WORKING.AC_CONTADORES.AC_PF_CBO.Value = WS_WORKING.AC_CONTADORES.AC_PF_CBO + 001;

                /*" -2406- ELSE */
            }
            else
            {


                /*" -2407- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2408- MOVE 'NAO INFORMADA' TO BILHETE-PROFISSAO */
                    _.Move("NAO INFORMADA", BILHETE.DCLBILHETE.BILHETE_PROFISSAO);

                    /*" -2409- ELSE */
                }
                else
                {


                    /*" -2410- MOVE SQLCODE TO WS-SQLCODE */
                    _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                    /*" -2411- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2412- DISPLAY ' 1F100-00-SEL-PF-CBO     ' */
                    _.Display($" 1F100-00-SEL-PF-CBO     ");

                    /*" -2413- DISPLAY ' ERRO SEL PF_CBO (' WS-SQLCODE ')' */

                    $" ERRO SEL PF_CBO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                    .Display();

                    /*" -2414- DISPLAY ' PROPOSTA: ' PF062-NUM-PROPOSTA-SIVPF */
                    _.Display($" PROPOSTA: {PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF}");

                    /*" -2415- DISPLAY '***' */
                    _.Display($"***");

                    /*" -2416- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2417- END-IF */
                }


                /*" -2419- END-IF */
            }


            /*" -2419- . */

        }

        [StopWatch]
        /*" M-1F100-00-SEL-PF-CBO-DB-SELECT-1 */
        public void M_1F100_00_SEL_PF_CBO_DB_SELECT_1()
        {
            /*" -2398- EXEC SQL SELECT DES_CBO INTO :BILHETE-PROFISSAO FROM SEGUROS.PF_CBO WHERE NUM_PROPOSTA_SIVPF = :PF062-NUM-PROPOSTA-SIVPF WITH UR END-EXEC */

            var m_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1 = new M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1()
            {
                PF062_NUM_PROPOSTA_SIVPF = PF062.DCLPF_CBO.PF062_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = M_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1.Execute(m_1F100_00_SEL_PF_CBO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_PROFISSAO, BILHETE.DCLBILHETE.BILHETE_PROFISSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1F100_99_SAIDA*/

        [StopWatch]
        /*" M-1L000-00-CONS-COD-CRITICA-SECTION */
        private void M_1L000_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -2429- MOVE '1L000-00-CONS-COD-CRITICA   ' TO PARAGRAFO */
            _.Move("1L000-00-CONS-COD-CRITICA   ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2430- MOVE '1L000' TO COMANDO */
            _.Move("1L000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2433- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2434- MOVE 'N' TO LK-VG001-TRACE */
            _.Move("N", SPVG001W.LK_VG001_TRACE);

            /*" -2435- MOVE 07 TO LK-VG001-TIPO-ACAO */
            _.Move(07, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2436- MOVE PROPOFID-NUM-SICOB TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2437- MOVE ZEROS TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2438- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2439- MOVE ZEROS TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2440- MOVE WS-COD-CRI TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_COD_CRI, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2441- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2442- MOVE 'BI1630B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI1630B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2443- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2444- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2445- MOVE ZEROS TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(0, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2447- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2449- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2450- IF LK-VG001-IND-ERRO EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO == 00)
            {

                /*" -2451- IF LK-VG001-S-NUM-CERTIFICADO GREATER ZEROS */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 00)
                {

                    /*" -2452- MOVE 'S' TO N88-CRITICA-VG001 */
                    _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG001);

                    /*" -2453- ELSE */
                }
                else
                {


                    /*" -2454- MOVE 'N' TO N88-CRITICA-VG001 */
                    _.Move("N", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG001);

                    /*" -2455- END-IF */
                }


                /*" -2456- ELSE */
            }
            else
            {


                /*" -2457- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2458- DISPLAY '* 1L000-00-CONS-COD-CRITICA                 *' */
                _.Display($"* 1L000-00-CONS-COD-CRITICA                 *");

                /*" -2459- DISPLAY '*   PROBLEMAS CALL SUBROTINA SPBVG001       *' */
                _.Display($"*   PROBLEMAS CALL SUBROTINA SPBVG001       *");

                /*" -2460- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2461- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -2462- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -2463- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -2464- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -2465- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -2466- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -2467- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2468- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2469- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2470- END-IF */
            }


            /*" -2474- DISPLAY 'CERTIFICADO/CRITICA: ' LK-VG001-S-NUM-CERTIFICADO '/' N88-CRITICA-VG001 */

            $"CERTIFICADO/CRITICA: {SPVG001W.LK_VG001_S_NUM_CERTIFICADO}/{WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG001}"
            .Display();

            /*" -2474- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1L000_99_SAIDA*/

        [StopWatch]
        /*" M-1H000-00-AVALIACAO-RISCO-SECTION */
        private void M_1H000_00_AVALIACAO_RISCO_SECTION()
        {
            /*" -2484- MOVE '1H000-00-AVALIACAO-RIS' TO PARAGRAFO */
            _.Move("1H000-00-AVALIACAO-RIS", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2485- MOVE '1H000' TO COMANDO */
            _.Move("1H000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2488- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2489- MOVE '%' TO N88-CRITICA-VG009 */
            _.Move("%", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG009);

            /*" -2490- MOVE 'N' TO LK-VG009-E-TRACE */
            _.Move("N", SPVG009W.LK_VG009_E_TRACE);

            /*" -2492- MOVE 'BI1630B' TO LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA */
            _.Move("BI1630B", SPVG009W.LK_VG009_E_COD_USUARIO, SPVG009W.LK_VG009_E_NOM_PROGRAMA);

            /*" -2493- MOVE 01 TO LK-VG009-E-TIPO-ACAO */
            _.Move(01, SPVG009W.LK_VG009_E_TIPO_ACAO);

            /*" -2495- MOVE PROPOFID-NUM-SICOB TO LK-VG009-E-NUM-PROPOSTA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, SPVG009W.LK_VG009_E_NUM_PROPOSTA);

            /*" -2497- MOVE ZEROS TO LK-VG009-IND-ERRO LK-VG009-SQLCODE */
            _.Move(0, SPVG009W.LK_VG009_IND_ERRO, SPVG009W.LK_VG009_SQLCODE);

            /*" -2501- MOVE SPACES TO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLERRMC */
            _.Move("", SPVG009W.LK_VG009_MSG_ERRO, SPVG009W.LK_VG009_NOM_TABELA, SPVG009W.LK_VG009_SQLERRMC);

            /*" -2503- MOVE 'SPBVG009' TO WS-PGM-CALL */
            _.Move("SPBVG009", WS_WORKING.WS_AUXILIARES.WS_PGM_CALL);

            /*" -2524- CALL WS-PGM-CALL USING LK-VG009-E-TRACE LK-VG009-E-COD-USUARIO LK-VG009-E-NOM-PROGRAMA LK-VG009-E-TIPO-ACAO LK-VG009-E-NUM-PROPOSTA LK-VG009-S-COD-PESSOA LK-VG009-S-SEQ-PESSOA-HIST LK-VG009-S-COD-CLASSIF-RISCO LK-VG009-S-NUM-SCORE-RISCO LK-VG009-S-DTA-CLASSIF-RISCO LK-VG009-S-IND-PEND-APROVACAO LK-VG009-S-IND-DECL-AUTOMATICO LK-VG009-S-IND-ATLZ-FXA-RISCO LK-VG009-IND-ERRO LK-VG009-MSG-ERRO LK-VG009-NOM-TABELA LK-VG009-SQLCODE LK-VG009-SQLERRMC */
            _.Call(WS_WORKING.WS_AUXILIARES.WS_PGM_CALL, SPVG009W);

            /*" -2525- IF LK-VG009-IND-ERRO NOT EQUAL ZEROS AND 001 */

            if (!SPVG009W.LK_VG009_IND_ERRO.In("00", "001"))
            {

                /*" -2526- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2527- DISPLAY '* 1H000-00-AVALIACAO-RISCO                    *' */
                _.Display($"* 1H000-00-AVALIACAO-RISCO                    *");

                /*" -2528- DISPLAY '*   PROBLEMAS CALL SUBROTINA SPBVG009         *' */
                _.Display($"*   PROBLEMAS CALL SUBROTINA SPBVG009         *");

                /*" -2529- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2530- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -2531- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -2532- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -2533- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -2534- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -2535- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -2536- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -2537- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2538- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2539- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2541- END-IF */
            }


            /*" -2542- IF LK-VG009-S-COD-CLASSIF-RISCO EQUAL 004 */

            if (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO == 004)
            {

                /*" -2544- DISPLAY 'DESPREZADO RISCO CRITICO.: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"DESPREZADO RISCO CRITICO.: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -2545- ADD 001 TO AC-QTD-DES-CRI */
                WS_WORKING.AC_CONTADORES.AC_QTD_DES_CRI.Value = WS_WORKING.AC_CONTADORES.AC_QTD_DES_CRI + 001;

                /*" -2547- MOVE 'S' TO N88-CRITICA-VG009 N88-ERRO-CRITICO */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG009, WS_WORKING.WS_NIVEIS_88.N88_ERRO_CRITICO);

                /*" -2550- END-IF */
            }


            /*" -2550- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1H000_99_SAIDA*/

        [StopWatch]
        /*" M-1J000-00-GRAVA-RISCO-MOTOR-SECTION */
        private void M_1J000_00_GRAVA_RISCO_MOTOR_SECTION()
        {
            /*" -2560- MOVE '1J000-00-GRAVA-RISCO-MOTOR  ' TO PARAGRAFO */
            _.Move("1J000-00-GRAVA-RISCO-MOTOR  ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2561- MOVE '1J000' TO COMANDO */
            _.Move("1J000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2563- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2565- MOVE '&' TO N88-CRITICA-VG009 */
            _.Move("&", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG009);

            /*" -2566-  EVALUATE TRUE  */

            /*" -2567-  WHEN LK-VG009-IND-ERRO  EQUAL     ZEROS  */

            /*" -2567- IF LK-VG009-IND-ERRO  EQUAL     ZEROS */

            if (SPVG009W.LK_VG009_IND_ERRO == 00)
            {

                /*" -2569- PERFORM 1J100-00-GRAVA-CLASSIF-RISCO THRU 1J100-99-SAIDA */

                M_1J100_00_GRAVA_CLASSIF_RISCO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J100_99_SAIDA*/


                /*" -2570-  WHEN LK-VG009-IND-ERRO  EQUAL     001  */

                /*" -2570- ELSE IF LK-VG009-IND-ERRO  EQUAL     001 */
            }
            else

            if (SPVG009W.LK_VG009_IND_ERRO == 001)
            {

                /*" -2571- IF LK-VG009-SQLCODE EQUAL 100 */

                if (SPVG009W.LK_VG009_SQLCODE == 100)
                {

                    /*" -2573- PERFORM 1J300-00-GRAVA-EMITE-SEM-RISCO THRU 1J300-99-SAIDA */

                    M_1J300_00_GRAVA_EMITE_SEM_RISCO_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J300_99_SAIDA*/


                    /*" -2574- ELSE */
                }
                else
                {


                    /*" -2575- MOVE 'S' TO N88-CRITICA-VG009 */
                    _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG009);

                    /*" -2576- END-IF */
                }


                /*" -2577-  WHEN OTHER  */

                /*" -2577- ELSE */
            }
            else
            {


                /*" -2578- MOVE 'S' TO N88-CRITICA-VG009 */
                _.Move("S", WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG009);

                /*" -2580-  END-EVALUATE  */

                /*" -2580- END-IF */
            }


            /*" -2581- IF TEM-CRITICA-VG009 */

            if (WS_WORKING.WS_NIVEIS_88.N88_CRITICA_VG009["TEM_CRITICA_VG009"])
            {

                /*" -2582- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2583- DISPLAY '* 1J000-00-GRAVA-RISCO-MOTOR (SPBVG009)       *' */
                _.Display($"* 1J000-00-GRAVA-RISCO-MOTOR (SPBVG009)       *");

                /*" -2584- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2585- DISPLAY '* NUM-PROPOST: ' LK-VG009-E-NUM-PROPOSTA */
                _.Display($"* NUM-PROPOST: {SPVG009W.LK_VG009_E_NUM_PROPOSTA}");

                /*" -2586- DISPLAY '* TIPO-ACAO..: ' LK-VG009-E-TIPO-ACAO */
                _.Display($"* TIPO-ACAO..: {SPVG009W.LK_VG009_E_TIPO_ACAO}");

                /*" -2587- DISPLAY '* IND-ERRO...: ' LK-VG009-IND-ERRO */
                _.Display($"* IND-ERRO...: {SPVG009W.LK_VG009_IND_ERRO}");

                /*" -2588- DISPLAY '* MSG-ERRO...: ' LK-VG009-MSG-ERRO */
                _.Display($"* MSG-ERRO...: {SPVG009W.LK_VG009_MSG_ERRO}");

                /*" -2589- DISPLAY '* NOM-TABELA.: ' LK-VG009-NOM-TABELA */
                _.Display($"* NOM-TABELA.: {SPVG009W.LK_VG009_NOM_TABELA}");

                /*" -2590- DISPLAY '* SQLCODE....: ' LK-VG009-SQLCODE */
                _.Display($"* SQLCODE....: {SPVG009W.LK_VG009_SQLCODE}");

                /*" -2591- DISPLAY '* SQLERRMC...: ' LK-VG009-SQLERRMC */
                _.Display($"* SQLERRMC...: {SPVG009W.LK_VG009_SQLERRMC}");

                /*" -2592- DISPLAY '*---------------------------------------------*' */
                _.Display($"*---------------------------------------------*");

                /*" -2593- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2595- END-IF */
            }


            /*" -2595- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J000_99_SAIDA*/

        [StopWatch]
        /*" M-1J100-00-GRAVA-CLASSIF-RISCO-SECTION */
        private void M_1J100_00_GRAVA_CLASSIF_RISCO_SECTION()
        {
            /*" -2605- MOVE '1J100-00-GRAVA-CLASSIF-RISCO' TO PARAGRAFO */
            _.Move("1J100-00-GRAVA-CLASSIF-RISCO", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2606- MOVE '1J100' TO COMANDO */
            _.Move("1J100", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2608- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2609- MOVE 'S' TO LK-VG001-TRACE */
            _.Move("S", SPVG001W.LK_VG001_TRACE);

            /*" -2610- MOVE 002 TO LK-VG001-TIPO-ACAO */
            _.Move(002, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2611- MOVE PROPOFID-NUM-SICOB TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2612- MOVE ZEROS TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2613- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2614- MOVE ZEROS TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2615- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2616- MOVE 'BI1630B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI1630B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2617- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2618- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2619- MOVE 035 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(035, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2621- MOVE 'CADASTRAMENTO DE AVALIACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("CADASTRAMENTO DE AVALIACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2623- ADD 001 TO AC-QTD-EMI-RIS */
            WS_WORKING.AC_CONTADORES.AC_QTD_EMI_RIS.Value = WS_WORKING.AC_CONTADORES.AC_QTD_EMI_RIS + 001;

            /*" -2625- EVALUATE LK-VG009-S-COD-CLASSIF-RISCO */
            switch (SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO.Value)
            {

                /*" -2626- WHEN  01 */
                case 01:

                    /*" -2628- MOVE 002 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(002, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -2629- WHEN  02 */
                    break;
                case 02:

                    /*" -2631- MOVE 003 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(003, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -2632- WHEN  03 */
                    break;
                case 03:

                    /*" -2634- MOVE 004 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(004, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -2635- WHEN  04 */
                    break;
                case 04:

                    /*" -2636- MOVE 001 TO LK-VG001-COD-MSG-CRITICA */
                    _.Move(001, SPVG001W.LK_VG001_COD_MSG_CRITICA);

                    /*" -2637- WHEN OTHER */
                    break;
                default:

                    /*" -2639- DISPLAY 'ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA' LK-VG009-S-COD-CLASSIF-RISCO */
                    _.Display($"ERRO - CLASSIFICACAO DE RISCO NAO CADASTRADA{SPVG009W.LK_VG009_S_COD_CLASSIF_RISCO}");

                    /*" -2640- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2642- END-EVALUATE */
                    break;
            }


            /*" -2644- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2645- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -2646- IF LK-VG001-IND-ERRO EQUAL 001 */

                if (SPVG001W.LK_VG001_IND_ERRO == 001)
                {

                    /*" -2650- DISPLAY 'ERRO JAH GRAVADO 8550 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8550 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -2651- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2652- ELSE */
                }
                else
                {


                    /*" -2653- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2654- DISPLAY '* 1J100-00-GRAVA-CLASSIF-RISCO              *' */
                    _.Display($"* 1J100-00-GRAVA-CLASSIF-RISCO              *");

                    /*" -2655- DISPLAY '*   PROBLEMAS CALL SUBROTINA SPBVG001       *' */
                    _.Display($"*   PROBLEMAS CALL SUBROTINA SPBVG001       *");

                    /*" -2656- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2657- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -2658- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -2659- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2660- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -2661- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -2662- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -2664- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2665- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2666- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2667- END-IF */
                }


                /*" -2669- END-IF */
            }


            /*" -2669- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J100_99_SAIDA*/

        [StopWatch]
        /*" M-1J300-00-GRAVA-EMITE-SEM-RISCO-SECTION */
        private void M_1J300_00_GRAVA_EMITE_SEM_RISCO_SECTION()
        {
            /*" -2679- MOVE '1J300-00-GRAVA-EMITE-SEM-RIS' TO PARAGRAFO */
            _.Move("1J300-00-GRAVA-EMITE-SEM-RIS", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2680- MOVE '1J300' TO COMANDO */
            _.Move("1J300", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2683- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2684- MOVE 005 TO WS-COD-CRI */
            _.Move(005, WS_WORKING.WS_AUXILIARES.WS_COD_CRI);

            /*" -2686- PERFORM 1J310-00-CONS-COD-CRITICA THRU 1J310-99-SAIDA */

            M_1J310_00_CONS_COD_CRITICA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J310_99_SAIDA*/


            /*" -2687- IF VG001-IND-EXISTE EQUAL 'S' */

            if (SPVG001V.VG001_IND_EXISTE == "S")
            {

                /*" -2688- GO TO 1J300-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J300_99_SAIDA*/ //GOTO
                return;

                /*" -2693- END-IF */
            }


            /*" -2695- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -2696- MOVE 'S' TO LK-VG001-TRACE */
            _.Move("S", SPVG001W.LK_VG001_TRACE);

            /*" -2697- MOVE 002 TO LK-VG001-TIPO-ACAO */
            _.Move(002, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2698- MOVE PROPOFID-NUM-SICOB TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2699- MOVE ZEROS TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2700- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2701- MOVE ZEROS TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2702- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2703- MOVE 'BI1630B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI1630B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2704- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2705- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2706- MOVE 045 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(045, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2707- MOVE 005 TO LK-VG001-COD-MSG-CRITICA */
            _.Move(005, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2709- MOVE 'EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("EMISSAO DE BILHETE SEM CLASSIFICACAO DE RISCO", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2711- ADD 001 TO AC-QTD-EMI-SRI */
            WS_WORKING.AC_CONTADORES.AC_QTD_EMI_SRI.Value = WS_WORKING.AC_CONTADORES.AC_QTD_EMI_SRI + 001;

            /*" -2713- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2714- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -2715- IF LK-VG001-IND-ERRO EQUAL 001 */

                if (SPVG001W.LK_VG001_IND_ERRO == 001)
                {

                    /*" -2719- DISPLAY 'ERRO JAH GRAVADO 8560 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 8560 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -2720- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2721- ELSE */
                }
                else
                {


                    /*" -2722- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2723- DISPLAY '* 1J300-00-GRAVA-EMITE-SEM-RISCO            *' */
                    _.Display($"* 1J300-00-GRAVA-EMITE-SEM-RISCO            *");

                    /*" -2724- DISPLAY '*   PROBLEMAS CALL SUBROTINA SPBVG001       *' */
                    _.Display($"*   PROBLEMAS CALL SUBROTINA SPBVG001       *");

                    /*" -2725- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2726- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -2727- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -2728- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2729- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -2730- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -2731- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -2732- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2733- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2734- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2735- END-IF */
                }


                /*" -2737- END-IF */
            }


            /*" -2737- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J300_99_SAIDA*/

        [StopWatch]
        /*" M-1J310-00-CONS-COD-CRITICA-SECTION */
        private void M_1J310_00_CONS_COD_CRITICA_SECTION()
        {
            /*" -2747- MOVE '1J310-00-CONS-COD-CRITICA   ' TO PARAGRAFO */
            _.Move("1J310-00-CONS-COD-CRITICA   ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2748- MOVE '1J310' TO COMANDO */
            _.Move("1J310", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2751- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2752- MOVE 'S' TO LK-VG001-TRACE */
            _.Move("S", SPVG001W.LK_VG001_TRACE);

            /*" -2753- MOVE 'N' TO VG001-IND-EXISTE */
            _.Move("N", SPVG001V.VG001_IND_EXISTE);

            /*" -2754- MOVE 007 TO LK-VG001-TIPO-ACAO */
            _.Move(007, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2755- MOVE PROPOFID-NUM-SICOB TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2756- MOVE ZEROS TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2757- MOVE SPACES TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2758- MOVE ZEROS TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2759- MOVE WS-COD-CRI TO LK-VG001-COD-MSG-CRITICA */
            _.Move(WS_WORKING.WS_AUXILIARES.WS_COD_CRI, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2760- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2761- MOVE 'BI1630B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI1630B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2762- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2763- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2764- MOVE ZEROS TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(0, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2766- MOVE SPACES TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2768- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2769- IF LK-VG001-IND-ERRO EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO == 00)
            {

                /*" -2770- IF LK-VG001-S-NUM-CERTIFICADO GREATER ZEROS */

                if (SPVG001W.LK_VG001_S_NUM_CERTIFICADO > 00)
                {

                    /*" -2771- MOVE 'S' TO VG001-IND-EXISTE */
                    _.Move("S", SPVG001V.VG001_IND_EXISTE);

                    /*" -2772- ELSE */
                }
                else
                {


                    /*" -2773- MOVE 'N' TO VG001-IND-EXISTE */
                    _.Move("N", SPVG001V.VG001_IND_EXISTE);

                    /*" -2774- END-IF */
                }


                /*" -2775- ELSE */
            }
            else
            {


                /*" -2776- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2777- DISPLAY '* 1J310-00-CONS-COD-CRITICA                 *' */
                _.Display($"* 1J310-00-CONS-COD-CRITICA                 *");

                /*" -2778- DISPLAY '*   PROBLEMAS CALL SUBROTINA SPBVG001       *' */
                _.Display($"*   PROBLEMAS CALL SUBROTINA SPBVG001       *");

                /*" -2779- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2780- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                /*" -2781- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                /*" -2782- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                /*" -2783- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                /*" -2784- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                /*" -2785- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                /*" -2786- DISPLAY '*-------------------------------------------*' */
                _.Display($"*-------------------------------------------*");

                /*" -2787- MOVE 999 TO SQLCODE */
                _.Move(999, DB.SQLCODE);

                /*" -2788- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2790- END-IF */
            }


            /*" -2790- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1J310_99_SAIDA*/

        [StopWatch]
        /*" M-1N000-00-UPDATE-PROPFID-SECTION */
        private void M_1N000_00_UPDATE_PROPFID_SECTION()
        {
            /*" -2800- MOVE '1N000-00-UPDATE-PROPFID     ' TO PARAGRAFO */
            _.Move("1N000-00-UPDATE-PROPFID     ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2801- MOVE '1N000' TO COMANDO */
            _.Move("1N000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2804- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2805- IF TEM-ERRO-NORMAL */

            if (WS_WORKING.WS_NIVEIS_88.N88_ERRO_NORMAL["TEM_ERRO_NORMAL"])
            {

                /*" -2806- MOVE 'S' TO WS-SIT-ENV */
                _.Move("S", WS_WORKING.WS_AUXILIARES.WS_SIT_ENV);

                /*" -2807- IF PROPOFID-NUM-SICOB EQUAL ZEROS */

                if (PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB == 00)
                {

                    /*" -2808- MOVE 'PEN' TO WS-SIT-PRO */
                    _.Move("PEN", WS_WORKING.WS_AUXILIARES.WS_SIT_PRO);

                    /*" -2809- ELSE */
                }
                else
                {


                    /*" -2810- MOVE 'POB' TO WS-SIT-PRO */
                    _.Move("POB", WS_WORKING.WS_AUXILIARES.WS_SIT_PRO);

                    /*" -2811- END-IF */
                }


                /*" -2812- ELSE */
            }
            else
            {


                /*" -2813- MOVE SPACES TO WS-SIT-ENV */
                _.Move("", WS_WORKING.WS_AUXILIARES.WS_SIT_ENV);

                /*" -2814- MOVE 'PAI' TO WS-SIT-PRO */
                _.Move("PAI", WS_WORKING.WS_AUXILIARES.WS_SIT_PRO);

                /*" -2825- END-IF */
            }


            /*" -2831- PERFORM M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1 */

            M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1();

            /*" -2833- DISPLAY 'UPD PROPOSTA_FIDELIZ' */
            _.Display($"UPD PROPOSTA_FIDELIZ");

            /*" -2838- DISPLAY 'PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2840- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2841- DISPLAY '***' */
                _.Display($"***");

                /*" -2842- DISPLAY ' 1N000-00-UPDATE-PROPFID   ' */
                _.Display($" 1N000-00-UPDATE-PROPFID   ");

                /*" -2843- DISPLAY ' ERRO UPD FIDELIZ (' WS-SQLCODE ')' */

                $" ERRO UPD FIDELIZ ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2844- DISPLAY ' PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($" PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -2845- DISPLAY '***' */
                _.Display($"***");

                /*" -2846- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2848- END-IF */
            }


            /*" -2848- . */

        }

        [StopWatch]
        /*" M-1N000-00-UPDATE-PROPFID-DB-UPDATE-1 */
        public void M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1()
        {
            /*" -2831- EXEC SQL UPDATE SEGUROS.PROPOSTA_FIDELIZ SET SIT_PROPOSTA = :WS-SIT-PRO , SITUACAO_ENVIO = :WS-SIT-ENV , COD_USUARIO = 'BI1630B' WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF END-EXEC */

            var m_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 = new M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1()
            {
                WS_SIT_PRO = WS_WORKING.WS_AUXILIARES.WS_SIT_PRO.ToString(),
                WS_SIT_ENV = WS_WORKING.WS_AUXILIARES.WS_SIT_ENV.ToString(),
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            M_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1.Execute(m_1N000_00_UPDATE_PROPFID_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1N000_99_SAIDA*/

        [StopWatch]
        /*" M-1N100-00-INS-HIST-PROP-FID-SECTION */
        private void M_1N100_00_INS_HIST_PROP_FID_SECTION()
        {
            /*" -2858- MOVE '1N100-00-INS-HIST-PROP-FID  ' TO PARAGRAFO */
            _.Move("1N100-00-INS-HIST-PROP-FID  ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2859- MOVE '1P000' TO COMANDO */
            _.Move("1P000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2862- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2873- PERFORM M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1 */

            M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1();

            /*" -2875- DISPLAY 'INS HIST_PROPOSTA_FIDELIZ' */
            _.Display($"INS HIST_PROPOSTA_FIDELIZ");

            /*" -2878- DISPLAY 'PROPOSTA: ' PROPOFID-NUM-PROPOSTA-SIVPF ' SQLCODE: ' SQLCODE */

            $"PROPOSTA: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2880- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2881- DISPLAY '***' */
                _.Display($"***");

                /*" -2882- DISPLAY ' 1N100-00-INS-HIST-PROP-FID' */
                _.Display($" 1N100-00-INS-HIST-PROP-FID");

                /*" -2883- DISPLAY ' ERRO INS HIST_PROP_FIDE(' WS-SQLCODE ')' */

                $" ERRO INS HIST_PROP_FIDE({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2884- DISPLAY ' IDENTIFICACAO: ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($" IDENTIFICACAO: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -2885- DISPLAY '***' */
                _.Display($"***");

                /*" -2886- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2888- END-IF */
            }


            /*" -2888- . */

        }

        [StopWatch]
        /*" M-1N100-00-INS-HIST-PROP-FID-DB-INSERT-1 */
        public void M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1()
        {
            /*" -2873- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES (:PROPOFID-NUM-IDENTIFICACAO , :WS-DATA-PROC , :PROPOFID-NSAC-SIVPF , :PROPOFID-NSL , 'REJ' , 'SUS' , 99 , :PROPOFID-COD-EMPRESA-SIVPF , :PROPOFID-COD-PRODUTO-SIVPF ) END-EXEC */

            var m_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1 = new M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1()
            {
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
                WS_DATA_PROC = WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.ToString(),
                PROPOFID_NSAC_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF.ToString(),
                PROPOFID_NSL = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL.ToString(),
                PROPOFID_COD_EMPRESA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF.ToString(),
                PROPOFID_COD_PRODUTO_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF.ToString(),
            };

            M_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1.Execute(m_1N100_00_INS_HIST_PROP_FID_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1N100_99_SAIDA*/

        [StopWatch]
        /*" M-1P000-00-UPDATE-PROPSSBI-SECTION */
        private void M_1P000_00_UPDATE_PROPSSBI_SECTION()
        {
            /*" -2898- MOVE '1P000-00-UPDATE-PROPSSBI    ' TO PARAGRAFO */
            _.Move("1P000-00-UPDATE-PROPSSBI    ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2899- MOVE '1P000' TO COMANDO */
            _.Move("1P000", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2902- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2907- PERFORM M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1 */

            M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1();

            /*" -2909- DISPLAY 'UPD PROP_SASSE_BILHETE(2)' */
            _.Display($"UPD PROP_SASSE_BILHETE(2)");

            /*" -2912- DISPLAY PROPOFID-NUM-IDENTIFICACAO '*SQLCODE: ' SQLCODE */

            $"{PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}*SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -2913- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2914- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -2915- DISPLAY '***' */
                _.Display($"***");

                /*" -2916- DISPLAY ' 1P000-00-UPDATE-PROPSSBI  ' */
                _.Display($" 1P000-00-UPDATE-PROPSSBI  ");

                /*" -2917- DISPLAY ' ERRO UPD PROP_SASSE_BIL(' WS-SQLCODE ')' */

                $" ERRO UPD PROP_SASSE_BIL({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -2918- DISPLAY ' IDENTIFICACAO: ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($" IDENTIFICACAO: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -2919- DISPLAY '***' */
                _.Display($"***");

                /*" -2920- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -2922- END-IF */
            }


            /*" -2922- . */

        }

        [StopWatch]
        /*" M-1P000-00-UPDATE-PROPSSBI-DB-UPDATE-1 */
        public void M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1()
        {
            /*" -2907- EXEC SQL UPDATE SEGUROS.PROP_SASSE_BILHETE SET DATA_INCLUSAO = :WS-DATA-PROC , COD_USUARIO = 'BI1630B' WHERE NUM_IDENTIFICACAO = :PROPOFID-NUM-IDENTIFICACAO END-EXEC */

            var m_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1 = new M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1()
            {
                WS_DATA_PROC = WS_WORKING.WS_AUXILIARES.WS_DATA_PROC.ToString(),
                PROPOFID_NUM_IDENTIFICACAO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO.ToString(),
            };

            M_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1.Execute(m_1P000_00_UPDATE_PROPSSBI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1P000_99_SAIDA*/

        [StopWatch]
        /*" M-1R000-00-TRATA-ERRO-SECTION */
        private void M_1R000_00_TRATA_ERRO_SECTION()
        {
            /*" -2932- MOVE '1R000-00-TRATA-ERRO    ' TO PARAGRAFO */
            _.Move("1R000-00-TRATA-ERRO    ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2933- MOVE '1R000-' TO COMANDO */
            _.Move("1R000-", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2935- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2936- MOVE 001 TO N88-ERRO-NORMAL */
            _.Move(001, WS_WORKING.WS_NIVEIS_88.N88_ERRO_NORMAL);

            /*" -2939- DISPLAY 'PROPOFID-NUM-SICOB: ' PROPOFID-NUM-SICOB '/' TAB-COD-ERR(IND-ERR) */

            $"PROPOFID-NUM-SICOB: {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB}/{TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR]}"
            .Display();

            /*" -2941- INITIALIZE LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Initialize(
                SPVG001W.LK_VG001_TRACE
                , SPVG001W.LK_VG001_TIPO_ACAO
                , SPVG001W.LK_VG001_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_SEQ_CRITICA
                , SPVG001W.LK_VG001_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_COD_USUARIO
                , SPVG001W.LK_VG001_NOM_PROGRAMA
                , SPVG001W.LK_VG001_STA_CRITICA
                , SPVG001W.LK_VG001_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_NUM_CERTIFICADO
                , SPVG001W.LK_VG001_S_SEQ_CRITICA
                , SPVG001W.LK_VG001_S_IND_TP_PROPOSTA
                , SPVG001W.LK_VG001_S_COD_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_MSG_CRITICA
                , SPVG001W.LK_VG001_S_DES_ABREV_MSG_CRIT
                , SPVG001W.LK_VG001_S_NUM_CPF_CNPJ
                , SPVG001W.LK_VG001_S_NUM_PROPOSTA
                , SPVG001W.LK_VG001_S_VLR_IS
                , SPVG001W.LK_VG001_S_VLR_PREMIO
                , SPVG001W.LK_VG001_S_DTA_OCORRENCIA
                , SPVG001W.LK_VG001_S_DTA_RCAP
                , SPVG001W.LK_VG001_S_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_STA_CRITICA
                , SPVG001W.LK_VG001_S_DES_COMPLEMENTAR
                , SPVG001W.LK_VG001_S_COD_USUARIO
                , SPVG001W.LK_VG001_S_NOM_PROGRAMA
                , SPVG001W.LK_VG001_S_DTH_CADASTRAMENTO
                , SPVG001W.LK_VG001_S_STA_PARA
                , SPVG001W.LK_VG001_IND_ERRO
                , SPVG001W.LK_VG001_MSG_ERRO
                , SPVG001W.LK_VG001_NOM_TABELA
                , SPVG001W.LK_VG001_SQLCODE
                , SPVG001W.LK_VG001_SQLERRMC
            );

            /*" -2942- MOVE 'S' TO LK-VG001-TRACE */
            _.Move("S", SPVG001W.LK_VG001_TRACE);

            /*" -2943- MOVE 02 TO LK-VG001-TIPO-ACAO */
            _.Move(02, SPVG001W.LK_VG001_TIPO_ACAO);

            /*" -2944- MOVE PROPOFID-NUM-SICOB TO LK-VG001-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB, SPVG001W.LK_VG001_NUM_CERTIFICADO);

            /*" -2945- MOVE TAB-COD-ERR(IND-ERR) TO LK-VG001-COD-MSG-CRITICA */
            _.Move(TABELAS.TABELA_ERROS.TAB_ERROS_ZEROS.TAB_ERROS_LIMPA.TAB_ERROS[WS_WORKING.INDEXADORES.IND_ERR].TAB_COD_ERR, SPVG001W.LK_VG001_COD_MSG_CRITICA);

            /*" -2946- MOVE 0 TO LK-VG001-SEQ-CRITICA */
            _.Move(0, SPVG001W.LK_VG001_SEQ_CRITICA);

            /*" -2947- MOVE 'BI' TO LK-VG001-IND-TP-PROPOSTA */
            _.Move("BI", SPVG001W.LK_VG001_IND_TP_PROPOSTA);

            /*" -2948- MOVE 0 TO LK-VG001-NUM-CPF-CNPJ */
            _.Move(0, SPVG001W.LK_VG001_NUM_CPF_CNPJ);

            /*" -2949- MOVE 'BATCH' TO LK-VG001-COD-USUARIO */
            _.Move("BATCH", SPVG001W.LK_VG001_COD_USUARIO);

            /*" -2950- MOVE 'BI1630B' TO LK-VG001-NOM-PROGRAMA */
            _.Move("BI1630B", SPVG001W.LK_VG001_NOM_PROGRAMA);

            /*" -2951- MOVE 'SPBVG001' TO VG001-PROGRAMA */
            _.Move("SPBVG001", SPVG001V.VG001_PROGRAMA);

            /*" -2952- MOVE SPACES TO LK-VG001-STA-CRITICA */
            _.Move("", SPVG001W.LK_VG001_STA_CRITICA);

            /*" -2953- MOVE 50 TO LK-VG001-DES-COMPLEMENTAR-L */
            _.Move(50, SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_L);

            /*" -2956- MOVE 'INSERCAO DE ERRO NA EMISSAO DA PROPOSTA' TO LK-VG001-DES-COMPLEMENTAR-T */
            _.Move("INSERCAO DE ERRO NA EMISSAO DA PROPOSTA", SPVG001W.LK_VG001_DES_COMPLEMENTAR.LK_VG001_DES_COMPLEMENTAR_T);

            /*" -2958- CALL VG001-PROGRAMA USING LK-VG001-TRACE LK-VG001-TIPO-ACAO LK-VG001-NUM-CERTIFICADO LK-VG001-SEQ-CRITICA LK-VG001-IND-TP-PROPOSTA LK-VG001-NUM-CPF-CNPJ LK-VG001-COD-MSG-CRITICA LK-VG001-COD-USUARIO LK-VG001-NOM-PROGRAMA LK-VG001-STA-CRITICA LK-VG001-DES-COMPLEMENTAR LK-VG001-S-NUM-CERTIFICADO LK-VG001-S-SEQ-CRITICA LK-VG001-S-IND-TP-PROPOSTA LK-VG001-S-COD-MSG-CRITICA LK-VG001-S-DES-MSG-CRITICA LK-VG001-S-DES-ABREV-MSG-CRIT LK-VG001-S-NUM-CPF-CNPJ LK-VG001-S-NUM-PROPOSTA LK-VG001-S-VLR-IS LK-VG001-S-VLR-PREMIO LK-VG001-S-DTA-OCORRENCIA LK-VG001-S-DTA-RCAP LK-VG001-S-STA-CRITICA LK-VG001-S-DES-STA-CRITICA LK-VG001-S-DES-COMPLEMENTAR LK-VG001-S-COD-USUARIO LK-VG001-S-NOM-PROGRAMA LK-VG001-S-DTH-CADASTRAMENTO LK-VG001-S-STA-PARA LK-VG001-IND-ERRO LK-VG001-MSG-ERRO LK-VG001-NOM-TABELA LK-VG001-SQLCODE LK-VG001-SQLERRMC */
            _.Call(SPVG001V.VG001_PROGRAMA, SPVG001W);

            /*" -2959- DISPLAY 'RETORNO SPBVG001: ' LK-VG001-IND-ERRO */
            _.Display($"RETORNO SPBVG001: {SPVG001W.LK_VG001_IND_ERRO}");

            /*" -2960- IF LK-VG001-IND-ERRO NOT EQUAL ZEROS */

            if (SPVG001W.LK_VG001_IND_ERRO != 00)
            {

                /*" -2961- IF LK-VG001-IND-ERRO EQUAL 001 */

                if (SPVG001W.LK_VG001_IND_ERRO == 001)
                {

                    /*" -2965- DISPLAY 'ERRO JAH GRAVADO 1900 >> ' LK-VG001-NUM-CERTIFICADO ' >> ' LK-VG001-COD-MSG-CRITICA ' >> ' LK-VG001-IND-ERRO */

                    $"ERRO JAH GRAVADO 1900 >> {SPVG001W.LK_VG001_NUM_CERTIFICADO} >> {SPVG001W.LK_VG001_COD_MSG_CRITICA} >> {SPVG001W.LK_VG001_IND_ERRO}"
                    .Display();

                    /*" -2966- DISPLAY 'MSG-ERRO: ' LK-VG001-MSG-ERRO */
                    _.Display($"MSG-ERRO: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2967- ELSE */
                }
                else
                {


                    /*" -2968- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2969- DISPLAY '* 1R000-00-TRATA-ERRO                       *' */
                    _.Display($"* 1R000-00-TRATA-ERRO                       *");

                    /*" -2970- DISPLAY '*   PROBLEMAS CALL SUBROTINA SPBVG001       *' */
                    _.Display($"*   PROBLEMAS CALL SUBROTINA SPBVG001       *");

                    /*" -2971- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2972- DISPLAY '* NUM-CERTIF..: ' LK-VG001-NUM-CERTIFICADO */
                    _.Display($"* NUM-CERTIF..: {SPVG001W.LK_VG001_NUM_CERTIFICADO}");

                    /*" -2973- DISPLAY '* IND-ERRO....: ' LK-VG001-IND-ERRO */
                    _.Display($"* IND-ERRO....: {SPVG001W.LK_VG001_IND_ERRO}");

                    /*" -2974- DISPLAY '* MSG-ERRO....: ' LK-VG001-MSG-ERRO */
                    _.Display($"* MSG-ERRO....: {SPVG001W.LK_VG001_MSG_ERRO}");

                    /*" -2975- DISPLAY '* NOM-TABELA..: ' LK-VG001-NOM-TABELA */
                    _.Display($"* NOM-TABELA..: {SPVG001W.LK_VG001_NOM_TABELA}");

                    /*" -2976- DISPLAY '* SQLCODE.....: ' LK-VG001-SQLCODE */
                    _.Display($"* SQLCODE.....: {SPVG001W.LK_VG001_SQLCODE}");

                    /*" -2977- DISPLAY '* SQLERRMC....: ' LK-VG001-SQLERRMC */
                    _.Display($"* SQLERRMC....: {SPVG001W.LK_VG001_SQLERRMC}");

                    /*" -2978- DISPLAY '*-------------------------------------------*' */
                    _.Display($"*-------------------------------------------*");

                    /*" -2979- MOVE 999 TO SQLCODE */
                    _.Move(999, DB.SQLCODE);

                    /*" -2980- GO TO 99999-00-ROT-ERRO */

                    M_99999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -2981- END-IF */
                }


                /*" -2983- END-IF */
            }


            /*" -2983- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_1R000_99_SAIDA*/

        [StopWatch]
        /*" M-80000-00-FINAL-SECTION */
        private void M_80000_00_FINAL_SECTION()
        {
            /*" -2993- MOVE '80000-00-FINAL         ' TO PARAGRAFO */
            _.Move("80000-00-FINAL         ", DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2994- MOVE '80000-' TO COMANDO */
            _.Move("80000-", DISPLAY_ABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2999- DISPLAY PARAGRAFO */
            _.Display(DISPLAY_ABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3003- PERFORM M_80000_00_FINAL_DB_UPDATE_1 */

            M_80000_00_FINAL_DB_UPDATE_1();

            /*" -3008- DISPLAY 'UPD NUMERO_OUTROS ' NUM-CLIENTE OF DCLNUMERO-OUTROS ' SQLCODE: ' SQLCODE */

            $"UPD NUMERO_OUTROS {NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -3009- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3010- MOVE SQLCODE TO WS-SQLCODE */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE);

                /*" -3011- DISPLAY '***' */
                _.Display($"***");

                /*" -3012- DISPLAY ' 80000-00-FINAL            ' */
                _.Display($" 80000-00-FINAL            ");

                /*" -3013- DISPLAY ' ERRO UPD NUMERO_OUTROS (' WS-SQLCODE ')' */

                $" ERRO UPD NUMERO_OUTROS ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -3014- DISPLAY ' NUMERO: ' NUM-CLIENTE OF DCLNUMERO-OUTROS */
                _.Display($" NUMERO: {NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE}");

                /*" -3015- DISPLAY '***' */
                _.Display($"***");

                /*" -3016- GO TO 99999-00-ROT-ERRO */

                M_99999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -3019- END-IF */
            }


            /*" -3019- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -3022- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -3024- DISPLAY ' PROPOSTAS LIDAS .........................: ' AC-PRO-LID */
            _.Display($" PROPOSTAS LIDAS .........................: {WS_WORKING.AC_CONTADORES.AC_PRO_LID}");

            /*" -3026- DISPLAY ' BILHETES LIDOS ..........................: ' AC-BIL-LID */
            _.Display($" BILHETES LIDOS ..........................: {WS_WORKING.AC_CONTADORES.AC_BIL_LID}");

            /*" -3028- DISPLAY ' RCAPS LIDOS .............................: ' AC-RCA-LID */
            _.Display($" RCAPS LIDOS .............................: {WS_WORKING.AC_CONTADORES.AC_RCA_LID}");

            /*" -3030- DISPLAY ' PROPOSTAS ALTERADAS .....................: ' AC-PRO-ATU */
            _.Display($" PROPOSTAS ALTERADAS .....................: {WS_WORKING.AC_CONTADORES.AC_PRO_ATU}");

            /*" -3032- DISPLAY ' SASSE ALTERADAS .........................: ' AC-SAS-ATU */
            _.Display($" SASSE ALTERADAS .........................: {WS_WORKING.AC_CONTADORES.AC_SAS_ATU}");

            /*" -3034- DISPLAY ' PESSOA LIDAS ............................: ' AC-PES-LID */
            _.Display($" PESSOA LIDAS ............................: {WS_WORKING.AC_CONTADORES.AC_PES_LID}");

            /*" -3036- DISPLAY ' CLIENTE LIDOS ...........................: ' AC-CLI-LID */
            _.Display($" CLIENTE LIDOS ...........................: {WS_WORKING.AC_CONTADORES.AC_CLI_LID}");

            /*" -3038- DISPLAY ' CLIENTE GRAVADOS ........................: ' AC-CLI-GRV */
            _.Display($" CLIENTE GRAVADOS ........................: {WS_WORKING.AC_CONTADORES.AC_CLI_GRV}");

            /*" -3040- DISPLAY ' CLIENTE ENDERECO LIDOS ..................: ' AC-END-LID */
            _.Display($" CLIENTE ENDERECO LIDOS ..................: {WS_WORKING.AC_CONTADORES.AC_END_LID}");

            /*" -3042- DISPLAY ' CLIENTE ENDERECO GRAVADOS ...............: ' AC-END-GRV */
            _.Display($" CLIENTE ENDERECO GRAVADOS ...............: {WS_WORKING.AC_CONTADORES.AC_END_GRV}");

            /*" -3044- DISPLAY ' CLIENTE EMAIL LIDOS .....................: ' AC-EMA-LID */
            _.Display($" CLIENTE EMAIL LIDOS .....................: {WS_WORKING.AC_CONTADORES.AC_EMA_LID}");

            /*" -3046- DISPLAY ' CLIENTE EMAIL GRAVADOS ..................: ' AC-EMA-GRV */
            _.Display($" CLIENTE EMAIL GRAVADOS ..................: {WS_WORKING.AC_CONTADORES.AC_EMA_GRV}");

            /*" -3048- DISPLAY ' CLIENTE EMAIL ALTERADOS .................: ' AC-EMA-ALT */
            _.Display($" CLIENTE EMAIL ALTERADOS .................: {WS_WORKING.AC_CONTADORES.AC_EMA_ALT}");

            /*" -3050- DISPLAY ' GED     GRAVADOS ........................: ' AC-GED-GRV */
            _.Display($" GED     GRAVADOS ........................: {WS_WORKING.AC_CONTADORES.AC_GED_GRV}");

            /*" -3052- DISPLAY ' GEC     GRAVADOS ........................: ' AC-GEC-GRV */
            _.Display($" GEC     GRAVADOS ........................: {WS_WORKING.AC_CONTADORES.AC_GEC_GRV}");

            /*" -3054- DISPLAY ' GEC     ALTERADOS .......................: ' AC-GEC-ALT */
            _.Display($" GEC     ALTERADOS .......................: {WS_WORKING.AC_CONTADORES.AC_GEC_ALT}");

            /*" -3056- DISPLAY ' PROPOSTAS EMITIDAS ......................: ' AC-PRO-LIB-EMI */
            _.Display($" PROPOSTAS EMITIDAS ......................: {WS_WORKING.AC_CONTADORES.AC_PRO_LIB_EMI}");

            /*" -3058- DISPLAY ' PROPOSTAS ERRO CRITICO ..................: ' AC-QTD-ERR-CRI */
            _.Display($" PROPOSTAS ERRO CRITICO ..................: {WS_WORKING.AC_CONTADORES.AC_QTD_ERR_CRI}");

            /*" -3060- DISPLAY ' PROPOSTAS DESPREZADAS CRITICA ...........: ' AC-QTD-DES-CRI */
            _.Display($" PROPOSTAS DESPREZADAS CRITICA ...........: {WS_WORKING.AC_CONTADORES.AC_QTD_DES_CRI}");

            /*" -3062- DISPLAY ' CBO LIDOS ...............................: ' AC-PF-CBO */
            _.Display($" CBO LIDOS ...............................: {WS_WORKING.AC_CONTADORES.AC_PF_CBO}");

            /*" -3064- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -3064- . */

        }

        [StopWatch]
        /*" M-80000-00-FINAL-DB-UPDATE-1 */
        public void M_80000_00_FINAL_DB_UPDATE_1()
        {
            /*" -3003- EXEC SQL UPDATE SEGUROS.NUMERO_OUTROS SET NUM_CLIENTE = :DCLNUMERO-OUTROS.NUM-CLIENTE WHERE 1 = 1 END-EXEC. */

            var m_80000_00_FINAL_DB_UPDATE_1_Update1 = new M_80000_00_FINAL_DB_UPDATE_1_Update1()
            {
                NUM_CLIENTE = NUMOUTRO.DCLNUMERO_OUTROS.NUM_CLIENTE.ToString(),
            };

            M_80000_00_FINAL_DB_UPDATE_1_Update1.Execute(m_80000_00_FINAL_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_80000_99_SAIDA*/

        [StopWatch]
        /*" M-99999-00-ROT-ERRO-SECTION */
        private void M_99999_00_ROT_ERRO_SECTION()
        {
            /*" -3073- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -3074- DISPLAY ' ************* PROGRAMA  CANCELADO ************* ' */
            _.Display($" ************* PROGRAMA  CANCELADO ************* ");

            /*" -3075- DISPLAY ' *************       ROLLBACK      ************* ' */
            _.Display($" *************       ROLLBACK      ************* ");

            /*" -3076- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -3077- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3078- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, DISPLAY_ABEND.WSQLCODE);

                /*" -3079- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], DISPLAY_ABEND.WSQLERRD1);

                /*" -3080- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], DISPLAY_ABEND.WSQLERRD2);

                /*" -3081- DISPLAY DISPLAY-ABEND */
                _.Display(DISPLAY_ABEND);

                /*" -3082- DISPLAY 'PROPOSTAS LIDAS  = ' */
                _.Display($"PROPOSTAS LIDAS  = ");

                /*" -3084- DISPLAY 'ULTIMO REG. LIDO = ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"ULTIMO REG. LIDO = {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -3086- END-IF */
            }


            /*" -3086- EXEC SQL ROLLBACK WORK END-EXEC */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -3090- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -3092- GOBACK */

            throw new GoBack();

            /*" -3092- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_99999_99_SAIDA*/
    }
}