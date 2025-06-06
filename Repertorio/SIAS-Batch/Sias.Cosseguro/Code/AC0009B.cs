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
using Sias.Cosseguro.DB2.AC0009B;

namespace Code
{
    public class AC0009B
    {
        public bool IsCall { get; set; }

        public AC0009B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0009B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2013                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................- GERA O CONTA CORRENTE DE COSSEGURO *      */
        /*"      *                             CEDIDO DE PREMIOS PARA OS DOCTOS   *      */
        /*"      *                             COM PERCENTUAL DIFERENCIADO POR    *      */
        /*"      *                             RAMO E CODIGO DE COBERTURA         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              DCLGEN            ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            SISTEMAS          INPUT    *      */
        /*"      * APOLICES                            APOLICES          INPUT    *      */
        /*"      * HISTORICO PARCELAS                  PARCEHIS          INPUT    *      */
        /*"      * ENDOS COSSEG COBERTURA              GE397             INPUT    *      */
        /*"      * ENDOSSOS                            ENDOSSOS          INPUT    *      */
        /*"      * APOLICE COSSEGURO CEDIDO            APOLCOSS          INPUT    *      */
        /*"      * NR ORDEM COSSEGURO CEDIDO           ORDEMCOS          INPUT    *      */
        /*"      * ENDOS RAMO VLR COSSEGURO            GE399             INPUT    *      */
        /*"      * PARCELAS                            PARCELAS          INPUT    *      */
        /*"      * COSSEGURO PREMIOS                   COSSPREM          INPUT    *      */
        /*"      * COSSEGURO HIST PREMIOS              COSHISPR          INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS MOVIMENTOS DAS APOLICES DE VIDA      *      */
        /*"      *              REFERENTES AOS PERIODOS PARA OS QUAIS NAO TIVERAM *      */
        /*"      *              A DISTRIBUICAO DE CEDIDO PARA A PREVISUL          *      */
        /*"      * 05/01/2017 - GILSON PINTO DA SILVA             CADMUS - 146005 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS MOVIMENTOS DA APOLICE 109300002676   *      */
        /*"      *              REFERENTE AO PERIODO PARA O QUAL NAO HOUVE A      *      */
        /*"      *              DISTRIBUICAO DE CEDIDO PARA A PREVISUL            *      */
        /*"      * 11/05/2017 - GILSON PINTO DA SILVA             CADMUS - 146335 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESPREZAR OS MOVIMENTOS DA APOLICE DE VIDA        *      */
        /*"      *              109300003432 NO PERIODO PARA O QUAL NAO TEVE A    *      */
        /*"      *              DISTRIBUICAO DE CEDIDO PARA A PREVISUL            *      */
        /*"      * 13/11/2017 - GILSON PINTO DA SILVA             CADMUS - 146335 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 03/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA TRATAR/INCLUIR O ORGAO 300 *      */
        /*"      * 21/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77        VIND-DAT-QTBC         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_DAT_QTBC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-COD-EMPR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-OCR-HIST         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_OCR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-SIT-FINC         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-SIT-LIBR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        VIND-NUM-OCOR         PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        WHOST-QTDE-REG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77        WHOST-OCORHIST        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis WHOST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77        WHOST-SIT-REGT        PIC  X(001)      VALUE SPACES.*/
        public StringBasis WHOST_SIT_REGT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01        TABL-COSSEG-CED.*/
        public AC0009B_TABL_COSSEG_CED TABL_COSSEG_CED { get; set; } = new AC0009B_TABL_COSSEG_CED();
        public class AC0009B_TABL_COSSEG_CED : VarBasis
        {
            /*"  05      TAB-COSGCED           OCCURS  30  TIMES.*/
            public ListBasis<AC0009B_TAB_COSGCED> TAB_COSGCED { get; set; } = new ListBasis<AC0009B_TAB_COSGCED>(30);
            public class AC0009B_TAB_COSGCED : VarBasis
            {
                /*"    10    WCOD-CSG              PIC  9(004).*/
                public IntBasis WCOD_CSG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    WNUM-ORD              PIC  9(015).*/
                public IntBasis WNUM_ORD { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10    WPCT-CED              PIC  9(004)V9(9).*/
                public DoubleBasis WPCT_CED { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
                /*"    10    WPCT-COM              PIC  9(004)V9(9).*/
                public DoubleBasis WPCT_COM { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)."), 9);
                /*"01        AREA-DE-WORK.*/
            }
        }
        public AC0009B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0009B_AREA_DE_WORK();
        public class AC0009B_AREA_DE_WORK : VarBasis
        {
            /*"  05      WFIM-PARCEHIS         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_PARCEHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-APOLCOSS         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_APOLCOSS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WTEM-PERI-ABERTO      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_PERI_ABERTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-PARCEHIS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-ENDOSSOS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-APOLCOSS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_APOLCOSS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-ORDEMCOS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_ORDEMCOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-GE399            PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_GE399 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-PARCELAS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_PARCELAS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-COSSPREM         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_COSSPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-I-COSSPREM         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_COSSPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-I-COSHISPR         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_COSHISPR { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-U-COSSPREM         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSPREM { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      WIND                  PIC  9(002)      VALUE ZEROS.*/
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05      WNUM-APOL-ANT         PIC S9(013)      VALUE +0 COMP-3*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05      WNUM-ENDS-ANT         PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WNUM_ENDS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      WNUM-PARC-ANT         PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis WNUM_PARC_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      WCOD-OPER             PIC  9(004)      VALUE ZEROS.*/
            public IntBasis WCOD_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      WCOD-OPER-R           REDEFINES        WCOD-OPER.*/
            private _REDEF_AC0009B_WCOD_OPER_R _wcod_oper_r { get; set; }
            public _REDEF_AC0009B_WCOD_OPER_R WCOD_OPER_R
            {
                get { _wcod_oper_r = new _REDEF_AC0009B_WCOD_OPER_R(); _.Move(WCOD_OPER, _wcod_oper_r); VarBasis.RedefinePassValue(WCOD_OPER, _wcod_oper_r, WCOD_OPER); _wcod_oper_r.ValueChanged += () => { _.Move(_wcod_oper_r, WCOD_OPER); }; return _wcod_oper_r; }
                set { VarBasis.RedefinePassValue(value, _wcod_oper_r, WCOD_OPER); }
            }  //Redefines
            public class _REDEF_AC0009B_WCOD_OPER_R : VarBasis
            {
                /*"    10    WTIP-OPER             PIC  9(002).*/
                public IntBasis WTIP_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    WSEQ-OPER             PIC  9(002).*/
                public IntBasis WSEQ_OPER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WCOD-CSG-AUX          PIC  9(004)      VALUE ZEROS.*/

                public _REDEF_AC0009B_WCOD_OPER_R()
                {
                    WTIP_OPER.ValueChanged += OnValueChanged;
                    WSEQ_OPER.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WCOD_CSG_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05      WNUM-ORD-AUX          PIC  9(015)      VALUE ZEROS.*/
            public IntBasis WNUM_ORD_AUX { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05      WPCT-CED-AUX          PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCT_CED_AUX { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05      WPCT-COM-AUX          PIC  9(004)V9(9) VALUE ZEROS.*/
            public DoubleBasis WPCT_COM_AUX { get; set; } = new DoubleBasis(new PIC("9", "4", "9(004)V9(9)"), 9);
            /*"  05      WPRM-TARF             PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WPRM_TARF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-TARF-IX          PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_TARF_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WVLR-DESC             PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WVLR_DESC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WVLR-DESC-IX          PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WVLR_DESC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WPRM-LIQD             PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WPRM_LIQD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-LIQD-IX          PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_LIQD_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WVLR-ADIC             PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WVLR_ADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WVLR-ADIC-IX          PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WVLR_ADIC_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WCOM-COSG             PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WCOM_COSG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WCOM-COSG-IX          PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WCOM_COSG_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WPRM-TOTL             PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WPRM_TOTL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-TOTL-IX          PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_TOTL_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WDATA-AUX             PIC  X(010)      VALUE SPACES.*/
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-AUX-R           REDEFINES        WDATA-AUX.*/
            private _REDEF_AC0009B_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_AC0009B_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_AC0009B_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_AC0009B_WDATA_AUX_R : VarBasis
            {
                /*"    10    WDAT-ANO-AUX          PIC  9(004).*/
                public IntBasis WDAT_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-MES-AUX          PIC  9(002).*/
                public IntBasis WDAT_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10    FILLER                PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10    WDAT-DIA-AUX          PIC  9(002).*/
                public IntBasis WDAT_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05      WDATA-EDIT.*/

                public _REDEF_AC0009B_WDATA_AUX_R()
                {
                    WDAT_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WDAT_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public AC0009B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0009B_WDATA_EDIT();
            public class AC0009B_WDATA_EDIT : VarBasis
            {
                /*"    10    WDAT-DIA-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_DIA_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-MES-EDT          PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WDAT_MES_EDT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10    WDAT-ANO-EDT          PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WDAT_ANO_EDT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05      WHORA-ACCEPT.*/
            }
            public AC0009B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0009B_WHORA_ACCEPT();
            public class AC0009B_WHORA_ACCEPT : VarBasis
            {
                /*"    10    WHH-ACCEPT            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WMM-ACCEPT            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WSS-ACCEPT            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    WCC-ACCEPT            PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05      WHORA-EDIT.*/
            }
            public AC0009B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0009B_WHORA_EDIT();
            public class AC0009B_WHORA_EDIT : VarBasis
            {
                /*"    10    WHH-EDIT              PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WHH_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10    WMM-EDIT              PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WMM_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10    FILLER                PIC  X(001)      VALUE ':'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10    WSS-EDIT              PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WSS_EDIT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"01        WABEND.*/
            }
        }
        public AC0009B_WABEND WABEND { get; set; } = new AC0009B_WABEND();
        public class AC0009B_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(009)      VALUE         'AC0009B '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AC0009B ");
            /*"  05      FILLER                PIC  X(035)      VALUE         ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"  05      WNR-EXEC-SQL          PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05      FILLER                PIC  X(013)      VALUE         ' *** SQLCODE '.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05      WSQLCODE              PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.GE397 GE397 { get; set; } = new Dclgens.GE397();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.ORDEMCOS ORDEMCOS { get; set; } = new Dclgens.ORDEMCOS();
        public Dclgens.GE399 GE399 { get; set; } = new Dclgens.GE399();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.COSSPREM COSSPREM { get; set; } = new Dclgens.COSSPREM();
        public Dclgens.COSHISPR COSHISPR { get; set; } = new Dclgens.COSHISPR();
        public AC0009B_C01_PARCEHIS C01_PARCEHIS { get; set; } = new AC0009B_C01_PARCEHIS();
        public AC0009B_C01_APOLCOSS C01_APOLCOSS { get; set; } = new AC0009B_C01_APOLCOSS();
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
            /*" -268- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -269- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -272- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -275- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -283- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -285- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -287- PERFORM R0200-00-CHECA-EXECUCAO. */

            R0200_00_CHECA_EXECUCAO_SECTION();

            /*" -288- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -289- DISPLAY 'AC0009B - DUPLICIDADE DE PROCESSAMENTO' */
                _.Display($"AC0009B - DUPLICIDADE DE PROCESSAMENTO");

                /*" -290- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -294- END-IF. */
            }


            /*" -295- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -296- MOVE WHH-ACCEPT TO WHH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDIT);

            /*" -297- MOVE WMM-ACCEPT TO WMM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDIT);

            /*" -298- MOVE WSS-ACCEPT TO WSS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDIT);

            /*" -300- DISPLAY 'INICIO DECLARE PARCELA HIST - ' WHORA-EDIT. */
            _.Display($"INICIO DECLARE PARCELA HIST - {AREA_DE_WORK.WHORA_EDIT}");

            /*" -302- PERFORM R0500-00-DECLARE-PARCEHIS. */

            R0500_00_DECLARE_PARCEHIS_SECTION();

            /*" -303- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -304- MOVE WHH-ACCEPT TO WHH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDIT);

            /*" -305- MOVE WMM-ACCEPT TO WMM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDIT);

            /*" -306- MOVE WSS-ACCEPT TO WSS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDIT);

            /*" -308- DISPLAY 'FINAL  DECLARE PARCELA HIST - ' WHORA-EDIT. */
            _.Display($"FINAL  DECLARE PARCELA HIST - {AREA_DE_WORK.WHORA_EDIT}");

            /*" -310- PERFORM R0600-00-FETCH-PARCEHIS. */

            R0600_00_FETCH_PARCEHIS_SECTION();

            /*" -311- IF WFIM-PARCEHIS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty())
            {

                /*" -312- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -313- ELSE */
            }
            else
            {


                /*" -315- PERFORM R0700-00-PROCESSA-PARCEHIS UNTIL WFIM-PARCEHIS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty()))
                {

                    R0700_00_PROCESSA_PARCEHIS_SECTION();
                }

                /*" -315- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -322- DISPLAY '                       ' . */
            _.Display($"                       ");

            /*" -323- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -324- DISPLAY 'REGISTROS LIDOS      : ' . */
            _.Display($"REGISTROS LIDOS      : ");

            /*" -325- DISPLAY 'PARCELA HISTORICO  - ' AC-L-PARCEHIS. */
            _.Display($"PARCELA HISTORICO  - {AREA_DE_WORK.AC_L_PARCEHIS}");

            /*" -326- DISPLAY 'ENDOSSOS           - ' AC-L-ENDOSSOS. */
            _.Display($"ENDOSSOS           - {AREA_DE_WORK.AC_L_ENDOSSOS}");

            /*" -327- DISPLAY 'APOL COSSEGURADORA - ' AC-L-APOLCOSS. */
            _.Display($"APOL COSSEGURADORA - {AREA_DE_WORK.AC_L_APOLCOSS}");

            /*" -328- DISPLAY 'NUM ORDEM COSG CED - ' AC-L-ORDEMCOS. */
            _.Display($"NUM ORDEM COSG CED - {AREA_DE_WORK.AC_L_ORDEMCOS}");

            /*" -329- DISPLAY 'ENDOS RAMO COSSEG  - ' AC-L-GE399. */
            _.Display($"ENDOS RAMO COSSEG  - {AREA_DE_WORK.AC_L_GE399}");

            /*" -330- DISPLAY 'PARCELAS           - ' AC-L-PARCELAS. */
            _.Display($"PARCELAS           - {AREA_DE_WORK.AC_L_PARCELAS}");

            /*" -331- DISPLAY 'COSSEGURO PREMIOS  - ' AC-L-COSSPREM. */
            _.Display($"COSSEGURO PREMIOS  - {AREA_DE_WORK.AC_L_COSSPREM}");

            /*" -332- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -333- DISPLAY 'REGISTROS GRAVADOS   : ' . */
            _.Display($"REGISTROS GRAVADOS   : ");

            /*" -334- DISPLAY 'COSSEGURO PREMIOS  - ' AC-I-COSSPREM. */
            _.Display($"COSSEGURO PREMIOS  - {AREA_DE_WORK.AC_I_COSSPREM}");

            /*" -335- DISPLAY 'COSSEG HIST PREMIO - ' AC-I-COSHISPR. */
            _.Display($"COSSEG HIST PREMIO - {AREA_DE_WORK.AC_I_COSHISPR}");

            /*" -336- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -337- DISPLAY 'REGISTROS ALTERADOS  : ' . */
            _.Display($"REGISTROS ALTERADOS  : ");

            /*" -338- DISPLAY 'COSSEGURO PREMIOS  - ' AC-U-COSSPREM. */
            _.Display($"COSSEGURO PREMIOS  - {AREA_DE_WORK.AC_U_COSSPREM}");

            /*" -339- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -341- DISPLAY '                       ' . */
            _.Display($"                       ");

            /*" -343- DISPLAY '*--- AC0009B  -  FIM  NORMAL ---*' . */
            _.Display($"*--- AC0009B  -  FIM  NORMAL ---*");

            /*" -343- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -347- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -347- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -360- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -365- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -368- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -369- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS");

                /*" -370- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -371- ELSE */
            }
            else
            {


                /*" -372- DISPLAY 'DATA DO SISTEMA AC - ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA DO SISTEMA AC - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -372- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -365- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'AC' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-SECTION */
        private void R0200_00_CHECA_EXECUCAO_SECTION()
        {
            /*" -385- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -396- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -399- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -400- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -401- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -402- ELSE */
                }
                else
                {


                    /*" -403- DISPLAY 'R0200 - ERRO NO SELECT DA COSSEGURO-HIST-PRE' */
                    _.Display($"R0200 - ERRO NO SELECT DA COSSEGURO-HIST-PRE");

                    /*" -404- DISPLAY 'DT MOVTO - ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"DT MOVTO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -405- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -406- END-IF */
                }


                /*" -406- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -396- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.COSSEGURO_HIST_PRE A, SEGUROS.APOLICES B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.TIPO_SEGURO = '1' AND A.COD_OPERACAO < 0600 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPO_SEGURO = A.TIPO_SEGURO AND B.ORGAO_EMISSOR IN (0010,0300) END-EXEC. */

            var r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1 = new R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
            };

            var executed_1 = R0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1.Execute(r0200_00_CHECA_EXECUCAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_REG, WHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-DECLARE-PARCEHIS-SECTION */
        private void R0500_00_DECLARE_PARCEHIS_SECTION()
        {
            /*" -419- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -446- PERFORM R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1 */

            R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1();

            /*" -448- PERFORM R0500_00_DECLARE_PARCEHIS_DB_OPEN_1 */

            R0500_00_DECLARE_PARCEHIS_DB_OPEN_1();

            /*" -451- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -452- DISPLAY 'R0500 - ERRO NO DECLARE DA PARCELA-HISTORICO' */
                _.Display($"R0500 - ERRO NO DECLARE DA PARCELA-HISTORICO");

                /*" -453- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -454- ELSE */
            }
            else
            {


                /*" -455- MOVE SPACES TO WFIM-PARCEHIS */
                _.Move("", AREA_DE_WORK.WFIM_PARCEHIS);

                /*" -455- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-PARCEHIS-DB-DECLARE-1 */
        public void R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1()
        {
            /*" -446- EXEC SQL DECLARE C01_PARCEHIS CURSOR FOR SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.DATA_MOVIMENTO , A.COD_OPERACAO , A.OCORR_HISTORICO , A.PRM_TARIFARIO , A.VAL_DESCONTO , A.ADICIONAL_FRACIO, A.DATA_QUITACAO , A.COD_EMPRESA , B.TIPO_SEGURO FROM SEGUROS.PARCELA_HISTORICO A, SEGUROS.APOLICES B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.COD_OPERACAO < 0900 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPO_SEGURO = '1' AND B.ORGAO_EMISSOR IN (0010,0300) AND B.QTD_COSSEGURADORA > 0 AND B.PCT_COSSEGURO_CED = 0 ORDER BY A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO END-EXEC. */
            C01_PARCEHIS = new AC0009B_C01_PARCEHIS(true);
            string GetQuery_C01_PARCEHIS()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.DATA_MOVIMENTO
							, 
							A.COD_OPERACAO
							, 
							A.OCORR_HISTORICO
							, 
							A.PRM_TARIFARIO
							, 
							A.VAL_DESCONTO
							, 
							A.ADICIONAL_FRACIO
							, 
							A.DATA_QUITACAO
							, 
							A.COD_EMPRESA
							, 
							B.TIPO_SEGURO 
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.APOLICES B 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.COD_OPERACAO < 0900 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.TIPO_SEGURO = '1' 
							AND B.ORGAO_EMISSOR IN (0010
							,0300) 
							AND B.QTD_COSSEGURADORA > 0 
							AND B.PCT_COSSEGURO_CED = 0 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.NUM_PARCELA
							, 
							A.OCORR_HISTORICO";

                return query;
            }
            C01_PARCEHIS.GetQueryEvent += GetQuery_C01_PARCEHIS;

        }

        [StopWatch]
        /*" R0500-00-DECLARE-PARCEHIS-DB-OPEN-1 */
        public void R0500_00_DECLARE_PARCEHIS_DB_OPEN_1()
        {
            /*" -448- EXEC SQL OPEN C01_PARCEHIS END-EXEC. */

            C01_PARCEHIS.Open();

        }

        [StopWatch]
        /*" R1300-00-DECLARE-APOLCOSS-DB-DECLARE-1 */
        public void R1300_00_DECLARE_APOLCOSS_DB_DECLARE_1()
        {
            /*" -747- EXEC SQL DECLARE C01_APOLCOSS CURSOR FOR SELECT NUM_APOLICE , COD_COSSEGURADORA FROM SEGUROS.APOL_COSSEGURADORA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA AND PCT_PART_COSSEGURO = 0 AND PCT_COM_COSSEGURO > 0 ORDER BY COD_COSSEGURADORA END-EXEC. */
            C01_APOLCOSS = new AC0009B_C01_APOLCOSS(true);
            string GetQuery_C01_APOLCOSS()
            {
                var query = @$"SELECT NUM_APOLICE
							, 
							COD_COSSEGURADORA 
							FROM SEGUROS.APOL_COSSEGURADORA 
							WHERE NUM_APOLICE = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}' 
							AND DATA_INIVIGENCIA <= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							AND DATA_TERVIGENCIA >= '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}' 
							AND PCT_PART_COSSEGURO = 0 
							AND PCT_COM_COSSEGURO > 0 
							ORDER BY 
							COD_COSSEGURADORA";

                return query;
            }
            C01_APOLCOSS.GetQueryEvent += GetQuery_C01_APOLCOSS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-FETCH-PARCEHIS-SECTION */
        private void R0600_00_FETCH_PARCEHIS_SECTION()
        {
            /*" -468- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -481- PERFORM R0600_00_FETCH_PARCEHIS_DB_FETCH_1 */

            R0600_00_FETCH_PARCEHIS_DB_FETCH_1();

            /*" -484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -485- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -486- MOVE 'S' TO WFIM-PARCEHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_PARCEHIS);

                    /*" -486- PERFORM R0600_00_FETCH_PARCEHIS_DB_CLOSE_1 */

                    R0600_00_FETCH_PARCEHIS_DB_CLOSE_1();

                    /*" -488- ELSE */
                }
                else
                {


                    /*" -489- DISPLAY 'R0600 - ERRO NO FETCH DA PARCELA-HISTORICO' */
                    _.Display($"R0600 - ERRO NO FETCH DA PARCELA-HISTORICO");

                    /*" -490- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -491- END-IF */
                }


                /*" -492- ELSE */
            }
            else
            {


                /*" -493- ADD 1 TO AC-L-PARCEHIS */
                AREA_DE_WORK.AC_L_PARCEHIS.Value = AREA_DE_WORK.AC_L_PARCEHIS + 1;

                /*" -493- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-FETCH-PARCEHIS-DB-FETCH-1 */
        public void R0600_00_FETCH_PARCEHIS_DB_FETCH_1()
        {
            /*" -481- EXEC SQL FETCH C01_PARCEHIS INTO :PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DATA-MOVIMENTO , :PARCEHIS-COD-OPERACAO , :PARCEHIS-OCORR-HISTORICO , :PARCEHIS-PRM-TARIFARIO , :PARCEHIS-VAL-DESCONTO , :PARCEHIS-ADICIONAL-FRACIO, :PARCEHIS-DATA-QUITACAO:VIND-DAT-QTBC, :PARCEHIS-COD-EMPRESA:VIND-COD-EMPR, :APOLICES-TIPO-SEGURO END-EXEC. */

            if (C01_PARCEHIS.Fetch())
            {
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C01_PARCEHIS.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
                _.Move(C01_PARCEHIS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(C01_PARCEHIS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
                _.Move(C01_PARCEHIS.PARCEHIS_PRM_TARIFARIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO);
                _.Move(C01_PARCEHIS.PARCEHIS_VAL_DESCONTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO);
                _.Move(C01_PARCEHIS.PARCEHIS_ADICIONAL_FRACIO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO);
                _.Move(C01_PARCEHIS.PARCEHIS_DATA_QUITACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO);
                _.Move(C01_PARCEHIS.VIND_DAT_QTBC, VIND_DAT_QTBC);
                _.Move(C01_PARCEHIS.PARCEHIS_COD_EMPRESA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_EMPRESA);
                _.Move(C01_PARCEHIS.VIND_COD_EMPR, VIND_COD_EMPR);
                _.Move(C01_PARCEHIS.APOLICES_TIPO_SEGURO, APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO);
            }

        }

        [StopWatch]
        /*" R0600-00-FETCH-PARCEHIS-DB-CLOSE-1 */
        public void R0600_00_FETCH_PARCEHIS_DB_CLOSE_1()
        {
            /*" -486- EXEC SQL CLOSE C01_PARCEHIS END-EXEC */

            C01_PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-PARCEHIS-SECTION */
        private void R0700_00_PROCESSA_PARCEHIS_SECTION()
        {
            /*" -506- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -507- MOVE PARCEHIS-NUM-APOLICE TO WNUM-APOL-ANT. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -512- MOVE PARCEHIS-NUM-ENDOSSO TO WNUM-ENDS-ANT. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, AREA_DE_WORK.WNUM_ENDS_ANT);

            /*" -514- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -516- PERFORM R0800-00-SELECT-GE397. */

            R0800_00_SELECT_GE397_SECTION();

            /*" -517- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -518- PERFORM R0900-00-SELECT-ENDOSSOS */

                R0900_00_SELECT_ENDOSSOS_SECTION();

                /*" -519- PERFORM R1000-00-TRATA-PERI-ABERTO */

                R1000_00_TRATA_PERI_ABERTO_SECTION();

                /*" -520- IF WTEM-PERI-ABERTO = 'N' */

                if (AREA_DE_WORK.WTEM_PERI_ABERTO == "N")
                {

                    /*" -521- PERFORM R1100-00-PROCESSA-ENDOSSO */

                    R1100_00_PROCESSA_ENDOSSO_SECTION();

                    /*" -522- ELSE */
                }
                else
                {


                    /*" -526- PERFORM R0600-00-FETCH-PARCEHIS UNTIL WFIM-PARCEHIS NOT EQUAL SPACES OR PARCEHIS-NUM-APOLICE NOT EQUAL WNUM-APOL-ANT OR PARCEHIS-NUM-ENDOSSO NOT EQUAL WNUM-ENDS-ANT */

                    while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WNUM_APOL_ANT || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WNUM_ENDS_ANT))
                    {

                        R0600_00_FETCH_PARCEHIS_SECTION();
                    }

                    /*" -527- END-IF */
                }


                /*" -528- ELSE */
            }
            else
            {


                /*" -532- PERFORM R0600-00-FETCH-PARCEHIS UNTIL WFIM-PARCEHIS NOT EQUAL SPACES OR PARCEHIS-NUM-APOLICE NOT EQUAL WNUM-APOL-ANT OR PARCEHIS-NUM-ENDOSSO NOT EQUAL WNUM-ENDS-ANT */

                while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WNUM_APOL_ANT || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WNUM_ENDS_ANT))
                {

                    R0600_00_FETCH_PARCEHIS_SECTION();
                }

                /*" -532- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-GE397-SECTION */
        private void R0800_00_SELECT_GE397_SECTION()
        {
            /*" -545- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -551- PERFORM R0800_00_SELECT_GE397_DB_SELECT_1 */

            R0800_00_SELECT_GE397_DB_SELECT_1();

            /*" -554- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -555- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -556- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -557- ELSE */
                }
                else
                {


                    /*" -558- DISPLAY 'R0800 - ERRO NO SELECT DA GE-ENDOS-COSG-COBER' */
                    _.Display($"R0800 - ERRO NO SELECT DA GE-ENDOS-COSG-COBER");

                    /*" -559- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -560- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -561- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -562- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -563- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -564- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -565- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -566- END-IF */
                }


                /*" -566- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-GE397-DB-SELECT-1 */
        public void R0800_00_SELECT_GE397_DB_SELECT_1()
        {
            /*" -551- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.GE_ENDOS_COSSEG_COBER WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

            var r0800_00_SELECT_GE397_DB_SELECT_1_Query1 = new R0800_00_SELECT_GE397_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0800_00_SELECT_GE397_DB_SELECT_1_Query1.Execute(r0800_00_SELECT_GE397_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_REG, WHOST_QTDE_REG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-SELECT-ENDOSSOS-SECTION */
        private void R0900_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -579- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -609- PERFORM R0900_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0900_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -612- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -613- DISPLAY 'R0900 - ERRO NO SELECT DA ENDOSSOS' */
                _.Display($"R0900 - ERRO NO SELECT DA ENDOSSOS");

                /*" -614- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -615- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -616- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -617- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -618- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -619- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -620- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -621- ELSE */
            }
            else
            {


                /*" -622- ADD 1 TO AC-L-ENDOSSOS */
                AREA_DE_WORK.AC_L_ENDOSSOS.Value = AREA_DE_WORK.AC_L_ENDOSSOS + 1;

                /*" -622- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0900_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -609- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , RAMO_EMISSOR, COD_PRODUTO , COD_SUBGRUPO, COD_FONTE , DATA_EMISSAO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, QTD_PARCELAS , COD_MOEDA_IMP, COD_MOEDA_PRM, SIT_REGISTRO INTO :ENDOSSOS-NUM-APOLICE, :ENDOSSOS-NUM-ENDOSSO, :ENDOSSOS-RAMO-EMISSOR, :ENDOSSOS-COD-PRODUTO, :ENDOSSOS-COD-SUBGRUPO, :ENDOSSOS-COD-FONTE, :ENDOSSOS-DATA-EMISSAO, :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-QTD-PARCELAS, :ENDOSSOS-COD-MOEDA-IMP, :ENDOSSOS-COD-MOEDA-PRM, :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

            var r0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0900_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_COD_SUBGRUPO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_SUBGRUPO);
                _.Move(executed_1.ENDOSSOS_COD_FONTE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_FONTE);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(executed_1.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(executed_1.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(executed_1.ENDOSSOS_QTD_PARCELAS, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_QTD_PARCELAS);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_IMP, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_IMP);
                _.Move(executed_1.ENDOSSOS_COD_MOEDA_PRM, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM);
                _.Move(executed_1.ENDOSSOS_SIT_REGISTRO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_SIT_REGISTRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-TRATA-PERI-ABERTO-SECTION */
        private void R1000_00_TRATA_PERI_ABERTO_SECTION()
        {
            /*" -638- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -640- MOVE 'N' TO WTEM-PERI-ABERTO. */
            _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

            /*" -644- IF (ENDOSSOS-NUM-APOLICE = 108208874329 OR 108210933403 OR ENDOSSOS-NUM-APOLICE = 109300000959 OR 109300001670 OR ENDOSSOS-NUM-APOLICE = 109300001819 OR 109300002142 OR ENDOSSOS-NUM-APOLICE = 109300002585 OR 109300002606) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("108208874329", "108210933403") || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("109300000959", "109300001670") || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("109300001819", "109300002142") || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("109300002585", "109300002606")))
            {

                /*" -646- IF (ENDOSSOS-DATA-INIVIGENCIA > '2016-10-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-01-05' ) */

                if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2016-10-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-01-05"))
                {

                    /*" -647- MOVE 'S' TO WTEM-PERI-ABERTO */
                    _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                    /*" -648- ELSE */
                }
                else
                {


                    /*" -649- MOVE 'N' TO WTEM-PERI-ABERTO */
                    _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                    /*" -650- END-IF */
                }


                /*" -651- ELSE */
            }
            else
            {


                /*" -652- IF ENDOSSOS-NUM-APOLICE = 109300002675 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 109300002675)
                {

                    /*" -654- IF (ENDOSSOS-DATA-INIVIGENCIA > '2016-05-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-01-05' ) */

                    if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2016-05-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-01-05"))
                    {

                        /*" -655- MOVE 'S' TO WTEM-PERI-ABERTO */
                        _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                        /*" -656- ELSE */
                    }
                    else
                    {


                        /*" -657- MOVE 'N' TO WTEM-PERI-ABERTO */
                        _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                        /*" -658- END-IF */
                    }


                    /*" -659- ELSE */
                }
                else
                {


                    /*" -660- IF ENDOSSOS-NUM-APOLICE = 109300002676 */

                    if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 109300002676)
                    {

                        /*" -661- IF ENDOSSOS-DATA-INIVIGENCIA < '2017-05-01' */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-05-01")
                        {

                            /*" -662- MOVE 'S' TO WTEM-PERI-ABERTO */
                            _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                            /*" -663- ELSE */
                        }
                        else
                        {


                            /*" -664- MOVE 'N' TO WTEM-PERI-ABERTO */
                            _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                            /*" -665- END-IF */
                        }


                        /*" -666- ELSE */
                    }
                    else
                    {


                        /*" -667- IF ENDOSSOS-NUM-APOLICE = 109300003432 */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 109300003432)
                        {

                            /*" -671- IF (ENDOSSOS-DATA-INIVIGENCIA > '2015-08-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-01-05' ) OR (ENDOSSOS-DATA-INIVIGENCIA > '2017-08-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-11-06' ) */

                            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2015-08-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-01-05") || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2017-08-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-11-06"))
                            {

                                /*" -672- MOVE 'S' TO WTEM-PERI-ABERTO */
                                _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                                /*" -673- ELSE */
                            }
                            else
                            {


                                /*" -674- MOVE 'N' TO WTEM-PERI-ABERTO */
                                _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                                /*" -675- END-IF */
                            }


                            /*" -676- END-IF */
                        }


                        /*" -677- END-IF */
                    }


                    /*" -678- END-IF */
                }


                /*" -678- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-ENDOSSO-SECTION */
        private void R1100_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -694- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -696- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -698- INITIALIZE TABL-COSSEG-CED. */
            _.Initialize(
                TABL_COSSEG_CED
            );

            /*" -700- PERFORM R1300-00-DECLARE-APOLCOSS. */

            R1300_00_DECLARE_APOLCOSS_SECTION();

            /*" -702- PERFORM R1400-00-FETCH-APOLCOSS. */

            R1400_00_FETCH_APOLCOSS_SECTION();

            /*" -703- IF WFIM-APOLCOSS = SPACES */

            if (AREA_DE_WORK.WFIM_APOLCOSS.IsEmpty())
            {

                /*" -705- PERFORM R1500-00-PROCESSA-APOLCOSS UNTIL WFIM-APOLCOSS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_APOLCOSS.IsEmpty()))
                {

                    R1500_00_PROCESSA_APOLCOSS_SECTION();
                }

                /*" -706- ELSE */
            }
            else
            {


                /*" -707- DISPLAY 'R1100 - DISTRIBUICAO DE COSSEGURO INVALIDA' */
                _.Display($"R1100 - DISTRIBUICAO DE COSSEGURO INVALIDA");

                /*" -708- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -709- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -710- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -711- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -712- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -713- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -714- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -715- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -720- END-IF. */
            }


            /*" -723- PERFORM R1800-00-PROCESSA-DOCUMENTO UNTIL WFIM-PARCEHIS NOT EQUAL SPACES OR PARCEHIS-NUM-APOLICE NOT EQUAL WNUM-APOL-ANT OR PARCEHIS-NUM-ENDOSSO NOT EQUAL WNUM-ENDS-ANT. */

            while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WNUM_APOL_ANT || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WNUM_ENDS_ANT))
            {

                R1800_00_PROCESSA_DOCUMENTO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-DECLARE-APOLCOSS-SECTION */
        private void R1300_00_DECLARE_APOLCOSS_SECTION()
        {
            /*" -736- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -747- PERFORM R1300_00_DECLARE_APOLCOSS_DB_DECLARE_1 */

            R1300_00_DECLARE_APOLCOSS_DB_DECLARE_1();

            /*" -749- PERFORM R1300_00_DECLARE_APOLCOSS_DB_OPEN_1 */

            R1300_00_DECLARE_APOLCOSS_DB_OPEN_1();

            /*" -752- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -753- DISPLAY 'R1300 - ERRO NO DECLARE DA APOL-COSSSEGURADORA' */
                _.Display($"R1300 - ERRO NO DECLARE DA APOL-COSSSEGURADORA");

                /*" -754- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -755- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -756- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -757- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -758- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -759- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -760- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -761- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -762- ELSE */
            }
            else
            {


                /*" -763- MOVE SPACES TO WFIM-APOLCOSS */
                _.Move("", AREA_DE_WORK.WFIM_APOLCOSS);

                /*" -763- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-DECLARE-APOLCOSS-DB-OPEN-1 */
        public void R1300_00_DECLARE_APOLCOSS_DB_OPEN_1()
        {
            /*" -749- EXEC SQL OPEN C01_APOLCOSS END-EXEC. */

            C01_APOLCOSS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-FETCH-APOLCOSS-SECTION */
        private void R1400_00_FETCH_APOLCOSS_SECTION()
        {
            /*" -776- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -779- PERFORM R1400_00_FETCH_APOLCOSS_DB_FETCH_1 */

            R1400_00_FETCH_APOLCOSS_DB_FETCH_1();

            /*" -782- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -783- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -784- MOVE 'S' TO WFIM-APOLCOSS */
                    _.Move("S", AREA_DE_WORK.WFIM_APOLCOSS);

                    /*" -784- PERFORM R1400_00_FETCH_APOLCOSS_DB_CLOSE_1 */

                    R1400_00_FETCH_APOLCOSS_DB_CLOSE_1();

                    /*" -786- ELSE */
                }
                else
                {


                    /*" -787- DISPLAY 'R1400 - ERRO NO FETCH DA APOL-COSSEGURADORA' */
                    _.Display($"R1400 - ERRO NO FETCH DA APOL-COSSEGURADORA");

                    /*" -788- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -789- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -790- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -791- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -792- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -793- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -794- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -795- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -796- END-IF */
                }


                /*" -797- ELSE */
            }
            else
            {


                /*" -798- ADD 1 TO AC-L-APOLCOSS */
                AREA_DE_WORK.AC_L_APOLCOSS.Value = AREA_DE_WORK.AC_L_APOLCOSS + 1;

                /*" -798- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-FETCH-APOLCOSS-DB-FETCH-1 */
        public void R1400_00_FETCH_APOLCOSS_DB_FETCH_1()
        {
            /*" -779- EXEC SQL FETCH C01_APOLCOSS INTO :APOLCOSS-NUM-APOLICE , :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            if (C01_APOLCOSS.Fetch())
            {
                _.Move(C01_APOLCOSS.APOLCOSS_NUM_APOLICE, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_NUM_APOLICE);
                _.Move(C01_APOLCOSS.APOLCOSS_COD_COSSEGURADORA, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA);
            }

        }

        [StopWatch]
        /*" R1400-00-FETCH-APOLCOSS-DB-CLOSE-1 */
        public void R1400_00_FETCH_APOLCOSS_DB_CLOSE_1()
        {
            /*" -784- EXEC SQL CLOSE C01_APOLCOSS END-EXEC */

            C01_APOLCOSS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PROCESSA-APOLCOSS-SECTION */
        private void R1500_00_PROCESSA_APOLCOSS_SECTION()
        {
            /*" -814- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -815- IF APOLCOSS-COD-COSSEGURADORA = 5631 */

            if (APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA == 5631)
            {

                /*" -816- DISPLAY 'R1500- DISTRIBUICAO DE COSSEGURO INVALIDA' */
                _.Display($"R1500- DISTRIBUICAO DE COSSEGURO INVALIDA");

                /*" -817- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -818- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -819- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -820- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -821- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -822- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -823- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -824- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -825- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -830- END-IF. */
            }


            /*" -835- PERFORM R1600-00-SELECT-ORDEMCOS. */

            R1600_00_SELECT_ORDEMCOS_SECTION();

            /*" -840- MOVE ZEROS TO GE399-VLR-PRMTAR-CED-VAR GE399-PCT-PROP-TOTAL-PR GE399-VLR-COMCOS-RAMO GE399-PCT-PROP-COM-TOTAL. */
            _.Move(0, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_PRMTAR_CED_VAR, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_PR, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_COMCOS_RAMO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_TOTAL);

            /*" -845- PERFORM R1700-00-SELECT-GE399. */

            R1700_00_SELECT_GE399_SECTION();

            /*" -847- ADD 1 TO WIND. */
            AREA_DE_WORK.WIND.Value = AREA_DE_WORK.WIND + 1;

            /*" -848- IF WIND > 30 */

            if (AREA_DE_WORK.WIND > 30)
            {

                /*" -849- DISPLAY 'R1500 - NR. DE CONGENERES PARTICIPANTES DA ' */
                _.Display($"R1500 - NR. DE CONGENERES PARTICIPANTES DA ");

                /*" -850- DISPLAY 'APOLICE MAIOR QUE OCORRENCIAS DA TABELA INTERNA' */
                _.Display($"APOLICE MAIOR QUE OCORRENCIAS DA TABELA INTERNA");

                /*" -851- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -852- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -853- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -854- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -855- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -856- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -857- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -858- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -859- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -861- END-IF. */
            }


            /*" -862- MOVE APOLCOSS-COD-COSSEGURADORA TO WCOD-CSG (WIND). */
            _.Move(APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA, TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WCOD_CSG);

            /*" -863- MOVE ORDEMCOS-ORDEM-CEDIDO TO WNUM-ORD (WIND). */
            _.Move(ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO, TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WNUM_ORD);

            /*" -864- MOVE GE399-PCT-PROP-TOTAL-PR TO WPCT-CED (WIND). */
            _.Move(GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_PR, TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WPCT_CED);

            /*" -868- MOVE GE399-PCT-PROP-COM-TOTAL TO WPCT-COM (WIND). */
            _.Move(GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_TOTAL, TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WPCT_COM);

            /*" -868- PERFORM R1400-00-FETCH-APOLCOSS. */

            R1400_00_FETCH_APOLCOSS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-SELECT-ORDEMCOS-SECTION */
        private void R1600_00_SELECT_ORDEMCOS_SECTION()
        {
            /*" -881- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -894- PERFORM R1600_00_SELECT_ORDEMCOS_DB_SELECT_1 */

            R1600_00_SELECT_ORDEMCOS_DB_SELECT_1();

            /*" -897- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -898- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -899- MOVE ZEROS TO ORDEMCOS-ORDEM-CEDIDO */
                    _.Move(0, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);

                    /*" -900- DISPLAY 'R1600 - DOCUMENTO NAO POSSUI NUM ORDEM CEDIDO' */
                    _.Display($"R1600 - DOCUMENTO NAO POSSUI NUM ORDEM CEDIDO");

                    /*" -901- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -902- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -903- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -904- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -905- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -906- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -907- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -908- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                    _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                    /*" -909- ELSE */
                }
                else
                {


                    /*" -910- DISPLAY 'R1600 - ERRO NO SELECT DA ORDEM-COSSEGCED' */
                    _.Display($"R1600 - ERRO NO SELECT DA ORDEM-COSSEGCED");

                    /*" -911- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -912- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -913- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -914- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -915- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -916- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -917- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -918- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                    _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                    /*" -919- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -920- END-IF */
                }


                /*" -921- ELSE */
            }
            else
            {


                /*" -922- ADD 1 TO AC-L-ORDEMCOS */
                AREA_DE_WORK.AC_L_ORDEMCOS.Value = AREA_DE_WORK.AC_L_ORDEMCOS + 1;

                /*" -922- END-IF. */
            }


        }

        [StopWatch]
        /*" R1600-00-SELECT-ORDEMCOS-DB-SELECT-1 */
        public void R1600_00_SELECT_ORDEMCOS_DB_SELECT_1()
        {
            /*" -894- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, COD_COSSEGURADORA, ORDEM_CEDIDO INTO :ORDEMCOS-NUM-APOLICE, :ORDEMCOS-NUM-ENDOSSO, :ORDEMCOS-COD-COSSEGURADORA, :ORDEMCOS-ORDEM-CEDIDO FROM SEGUROS.ORDEM_COSSEGCED WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND COD_COSSEGURADORA = :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            var r1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1 = new R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1()
            {
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1.Execute(r1600_00_SELECT_ORDEMCOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ORDEMCOS_NUM_APOLICE, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_APOLICE);
                _.Move(executed_1.ORDEMCOS_NUM_ENDOSSO, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_NUM_ENDOSSO);
                _.Move(executed_1.ORDEMCOS_COD_COSSEGURADORA, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_COD_COSSEGURADORA);
                _.Move(executed_1.ORDEMCOS_ORDEM_CEDIDO, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-SELECT-GE399-SECTION */
        private void R1700_00_SELECT_GE399_SECTION()
        {
            /*" -935- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -948- PERFORM R1700_00_SELECT_GE399_DB_SELECT_1 */

            R1700_00_SELECT_GE399_DB_SELECT_1();

            /*" -951- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -952- DISPLAY 'R1700 - ERRO NO SELECT DA GE-ENDOS-RAMO-VLR-CSG' */
                _.Display($"R1700 - ERRO NO SELECT DA GE-ENDOS-RAMO-VLR-CSG");

                /*" -953- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -954- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -955- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -956- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -957- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -958- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -959- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -960- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -961- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -962- ELSE */
            }
            else
            {


                /*" -963- ADD 1 TO AC-L-GE399 */
                AREA_DE_WORK.AC_L_GE399.Value = AREA_DE_WORK.AC_L_GE399 + 1;

                /*" -963- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-SELECT-GE399-DB-SELECT-1 */
        public void R1700_00_SELECT_GE399_DB_SELECT_1()
        {
            /*" -948- EXEC SQL SELECT VALUE(SUM(VLR_PRMTAR_CED_VAR),+0), VALUE(SUM(PCT_PROP_TOTAL_PR),+0), VALUE(SUM(VLR_COMCOS_RAMO),+0), VALUE(SUM(PCT_PROP_COM_TOTAL),+0) INTO :GE399-VLR-PRMTAR-CED-VAR, :GE399-PCT-PROP-TOTAL-PR, :GE399-VLR-COMCOS-RAMO, :GE399-PCT-PROP-COM-TOTAL FROM SEGUROS.GE_ENDOS_RAMO_VLR_COSSEG WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND COD_COSSEGURADORA = :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            var r1700_00_SELECT_GE399_DB_SELECT_1_Query1 = new R1700_00_SELECT_GE399_DB_SELECT_1_Query1()
            {
                APOLCOSS_COD_COSSEGURADORA = APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA.ToString(),
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1700_00_SELECT_GE399_DB_SELECT_1_Query1.Execute(r1700_00_SELECT_GE399_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GE399_VLR_PRMTAR_CED_VAR, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_PRMTAR_CED_VAR);
                _.Move(executed_1.GE399_PCT_PROP_TOTAL_PR, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_PR);
                _.Move(executed_1.GE399_VLR_COMCOS_RAMO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_COMCOS_RAMO);
                _.Move(executed_1.GE399_PCT_PROP_COM_TOTAL, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_TOTAL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-PROCESSA-DOCUMENTO-SECTION */
        private void R1800_00_PROCESSA_DOCUMENTO_SECTION()
        {
            /*" -979- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -980- IF ENDOSSOS-COD-MOEDA-PRM = 01 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM == 01)
            {

                /*" -981- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX */
                _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);

                /*" -982- MOVE ZEROS TO PARCELAS-VAL-DESCONTO-IX */
                _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);

                /*" -983- MOVE ZEROS TO PARCELAS-ADICIONAL-FRAC-IX */
                _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);

                /*" -984- ELSE */
            }
            else
            {


                /*" -985- PERFORM R1900-00-SELECT-PARCELAS */

                R1900_00_SELECT_PARCELAS_SECTION();

                /*" -990- END-IF. */
            }


            /*" -992- MOVE PARCEHIS-NUM-PARCELA TO WNUM-PARC-ANT. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, AREA_DE_WORK.WNUM_PARC_ANT);

            /*" -996- PERFORM R2000-00-PROCESSA-PARCELA UNTIL WFIM-PARCEHIS NOT EQUAL SPACES OR PARCEHIS-NUM-APOLICE NOT EQUAL WNUM-APOL-ANT OR PARCEHIS-NUM-ENDOSSO NOT EQUAL WNUM-ENDS-ANT OR PARCEHIS-NUM-PARCELA NOT EQUAL WNUM-PARC-ANT. */

            while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WNUM_APOL_ANT || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WNUM_ENDS_ANT || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA != AREA_DE_WORK.WNUM_PARC_ANT))
            {

                R2000_00_PROCESSA_PARCELA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R1900-00-SELECT-PARCELAS-SECTION */
        private void R1900_00_SELECT_PARCELAS_SECTION()
        {
            /*" -1009- MOVE '1900' TO WNR-EXEC-SQL. */
            _.Move("1900", WABEND.WNR_EXEC_SQL);

            /*" -1026- PERFORM R1900_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1900_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -1029- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1030- DISPLAY 'R1900 - ERRO NO SELECT DA PARCELAS' */
                _.Display($"R1900 - ERRO NO SELECT DA PARCELAS");

                /*" -1031- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1032- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1033- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1034- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -1035- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -1036- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -1037- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1038- ELSE */
            }
            else
            {


                /*" -1039- ADD 1 TO AC-L-PARCELAS */
                AREA_DE_WORK.AC_L_PARCELAS.Value = AREA_DE_WORK.AC_L_PARCELAS + 1;

                /*" -1039- END-IF. */
            }


        }

        [StopWatch]
        /*" R1900-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1900_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -1026- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , PRM_TARIFARIO_IX, VAL_DESCONTO_IX , ADICIONAL_FRAC_IX INTO :PARCELAS-NUM-APOLICE , :PARCELAS-NUM-ENDOSSO , :PARCELAS-NUM-PARCELA , :PARCELAS-PRM-TARIFARIO-IX, :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-ADICIONAL-FRAC-IX FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_PARCELA = :PARCEHIS-NUM-PARCELA END-EXEC. */

            var r1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
                PARCEHIS_NUM_PARCELA = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA.ToString(),
            };

            var executed_1 = R1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1900_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_NUM_APOLICE, PARCELAS.DCLPARCELAS.PARCELAS_NUM_APOLICE);
                _.Move(executed_1.PARCELAS_NUM_ENDOSSO, PARCELAS.DCLPARCELAS.PARCELAS_NUM_ENDOSSO);
                _.Move(executed_1.PARCELAS_NUM_PARCELA, PARCELAS.DCLPARCELAS.PARCELAS_NUM_PARCELA);
                _.Move(executed_1.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);
                _.Move(executed_1.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);
                _.Move(executed_1.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1900_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-PARCELA-SECTION */
        private void R2000_00_PROCESSA_PARCELA_SECTION()
        {
            /*" -1052- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -1054- MOVE ZEROS TO WIND. */
            _.Move(0, AREA_DE_WORK.WIND);

            /*" -1061- PERFORM R2200-00-PROCESSA-COSSEG-CED VARYING WIND FROM 1 BY 1 UNTIL WIND > 30 OR WCOD-CSG (WIND) = ZEROS. */

            for (AREA_DE_WORK.WIND.Value = 1; !(AREA_DE_WORK.WIND > 30 || TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WCOD_CSG == 00); AREA_DE_WORK.WIND.Value += 1)
            {

                R2200_00_PROCESSA_COSSEG_CED_SECTION();
            }

            /*" -1061- PERFORM R0600-00-FETCH-PARCEHIS. */

            R0600_00_FETCH_PARCEHIS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-COSSEG-CED-SECTION */
        private void R2200_00_PROCESSA_COSSEG_CED_SECTION()
        {
            /*" -1077- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1078- MOVE WCOD-CSG (WIND) TO WCOD-CSG-AUX. */
            _.Move(TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WCOD_CSG, AREA_DE_WORK.WCOD_CSG_AUX);

            /*" -1079- MOVE WNUM-ORD (WIND) TO WNUM-ORD-AUX. */
            _.Move(TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WNUM_ORD, AREA_DE_WORK.WNUM_ORD_AUX);

            /*" -1080- MOVE WPCT-CED (WIND) TO WPCT-CED-AUX. */
            _.Move(TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WPCT_CED, AREA_DE_WORK.WPCT_CED_AUX);

            /*" -1085- MOVE WPCT-COM (WIND) TO WPCT-COM-AUX. */
            _.Move(TABL_COSSEG_CED.TAB_COSGCED[AREA_DE_WORK.WIND].WPCT_COM, AREA_DE_WORK.WPCT_COM_AUX);

            /*" -1090- PERFORM R2300-00-CALCULA-COSG-CED. */

            R2300_00_CALCULA_COSG_CED_SECTION();

            /*" -1092- MOVE PARCEHIS-COD-OPERACAO TO WCOD-OPER. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO, AREA_DE_WORK.WCOD_OPER);

            /*" -1093- IF WTIP-OPER = 01 */

            if (AREA_DE_WORK.WCOD_OPER_R.WTIP_OPER == 01)
            {

                /*" -1094- PERFORM R2500-00-MONTA-COSSPREM */

                R2500_00_MONTA_COSSPREM_SECTION();

                /*" -1095- PERFORM R2600-00-INSERT-COSSPREM */

                R2600_00_INSERT_COSSPREM_SECTION();

                /*" -1096- PERFORM R2700-00-MONTA-COSHISPR */

                R2700_00_MONTA_COSHISPR_SECTION();

                /*" -1097- PERFORM R2800-00-INSERT-COSHISPR */

                R2800_00_INSERT_COSHISPR_SECTION();

                /*" -1098- ELSE */
            }
            else
            {


                /*" -1099- PERFORM R2700-00-MONTA-COSHISPR */

                R2700_00_MONTA_COSHISPR_SECTION();

                /*" -1100- PERFORM R2800-00-INSERT-COSHISPR */

                R2800_00_INSERT_COSHISPR_SECTION();

                /*" -1101- PERFORM R3100-00-MONTA-SITUACAO */

                R3100_00_MONTA_SITUACAO_SECTION();

                /*" -1102- PERFORM R3200-00-UPDATE-COSSPREM */

                R3200_00_UPDATE_COSSPREM_SECTION();

                /*" -1102- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-CALCULA-COSG-CED-SECTION */
        private void R2300_00_CALCULA_COSG_CED_SECTION()
        {
            /*" -1115- MOVE '2300' TO WNR-EXEC-SQL. */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -1122- MOVE ZEROS TO WPRM-TARF WVLR-DESC WPRM-LIQD WVLR-ADIC WCOM-COSG WPRM-TOTL. */
            _.Move(0, AREA_DE_WORK.WPRM_TARF, AREA_DE_WORK.WVLR_DESC, AREA_DE_WORK.WPRM_LIQD, AREA_DE_WORK.WVLR_ADIC, AREA_DE_WORK.WCOM_COSG, AREA_DE_WORK.WPRM_TOTL);

            /*" -1131- MOVE ZEROS TO WPRM-TARF-IX WVLR-DESC-IX WPRM-LIQD-IX WVLR-ADIC-IX WCOM-COSG-IX WPRM-TOTL-IX. */
            _.Move(0, AREA_DE_WORK.WPRM_TARF_IX, AREA_DE_WORK.WVLR_DESC_IX, AREA_DE_WORK.WPRM_LIQD_IX, AREA_DE_WORK.WVLR_ADIC_IX, AREA_DE_WORK.WCOM_COSG_IX, AREA_DE_WORK.WPRM_TOTL_IX);

            /*" -1134- COMPUTE WPRM-TARF ROUNDED = PARCEHIS-PRM-TARIFARIO * WPCT-CED-AUX / 100. */
            AREA_DE_WORK.WPRM_TARF.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO * AREA_DE_WORK.WPCT_CED_AUX / 100f;

            /*" -1137- COMPUTE WVLR-DESC ROUNDED = PARCEHIS-VAL-DESCONTO * WPCT-CED-AUX / 100. */
            AREA_DE_WORK.WVLR_DESC.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO * AREA_DE_WORK.WPCT_CED_AUX / 100f;

            /*" -1139- COMPUTE WPRM-LIQD = WPRM-TARF - WVLR-DESC. */
            AREA_DE_WORK.WPRM_LIQD.Value = AREA_DE_WORK.WPRM_TARF - AREA_DE_WORK.WVLR_DESC;

            /*" -1142- COMPUTE WVLR-ADIC ROUNDED = PARCEHIS-ADICIONAL-FRACIO * WPCT-CED-AUX / 100. */
            AREA_DE_WORK.WVLR_ADIC.Value = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO * AREA_DE_WORK.WPCT_CED_AUX / 100f;

            /*" -1147- COMPUTE WCOM-COSG ROUNDED = (PARCEHIS-PRM-TARIFARIO - PARCEHIS-VAL-DESCONTO + PARCEHIS-ADICIONAL-FRACIO) * WPCT-COM-AUX / 100. */
            AREA_DE_WORK.WCOM_COSG.Value = (PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_PRM_TARIFARIO - PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_VAL_DESCONTO + PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_ADICIONAL_FRACIO) * AREA_DE_WORK.WPCT_COM_AUX / 100f;

            /*" -1153- COMPUTE WPRM-TOTL = (WPRM-LIQD + WVLR-ADIC) - WCOM-COSG. */
            AREA_DE_WORK.WPRM_TOTL.Value = (AREA_DE_WORK.WPRM_LIQD + AREA_DE_WORK.WVLR_ADIC) - AREA_DE_WORK.WCOM_COSG;

            /*" -1155- IF ENDOSSOS-COD-MOEDA-PRM = 01 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM == 01)
            {

                /*" -1156- MOVE WPRM-TARF TO WPRM-TARF-IX */
                _.Move(AREA_DE_WORK.WPRM_TARF, AREA_DE_WORK.WPRM_TARF_IX);

                /*" -1157- MOVE WVLR-DESC TO WVLR-DESC-IX */
                _.Move(AREA_DE_WORK.WVLR_DESC, AREA_DE_WORK.WVLR_DESC_IX);

                /*" -1158- MOVE WPRM-LIQD TO WPRM-LIQD-IX */
                _.Move(AREA_DE_WORK.WPRM_LIQD, AREA_DE_WORK.WPRM_LIQD_IX);

                /*" -1159- MOVE WVLR-ADIC TO WVLR-ADIC-IX */
                _.Move(AREA_DE_WORK.WVLR_ADIC, AREA_DE_WORK.WVLR_ADIC_IX);

                /*" -1160- MOVE WCOM-COSG TO WCOM-COSG-IX */
                _.Move(AREA_DE_WORK.WCOM_COSG, AREA_DE_WORK.WCOM_COSG_IX);

                /*" -1162- MOVE WPRM-TOTL TO WPRM-TOTL-IX */
                _.Move(AREA_DE_WORK.WPRM_TOTL, AREA_DE_WORK.WPRM_TOTL_IX);

                /*" -1164- ELSE */
            }
            else
            {


                /*" -1167- COMPUTE WPRM-TARF-IX ROUNDED = PARCELAS-PRM-TARIFARIO-IX * WPCT-CED-AUX / 100 */
                AREA_DE_WORK.WPRM_TARF_IX.Value = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX * AREA_DE_WORK.WPCT_CED_AUX / 100f;

                /*" -1170- COMPUTE WVLR-DESC-IX ROUNDED = PARCELAS-VAL-DESCONTO-IX * WPCT-CED-AUX / 100 */
                AREA_DE_WORK.WVLR_DESC_IX.Value = PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX * AREA_DE_WORK.WPCT_CED_AUX / 100f;

                /*" -1173- COMPUTE WPRM-LIQD-IX = WPRM-TARF-IX - WVLR-DESC-IX */
                AREA_DE_WORK.WPRM_LIQD_IX.Value = AREA_DE_WORK.WPRM_TARF_IX - AREA_DE_WORK.WVLR_DESC_IX;

                /*" -1176- COMPUTE WVLR-ADIC-IX ROUNDED = PARCELAS-ADICIONAL-FRAC-IX * WPCT-CED-AUX / 100 */
                AREA_DE_WORK.WVLR_ADIC_IX.Value = PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX * AREA_DE_WORK.WPCT_CED_AUX / 100f;

                /*" -1182- COMPUTE WCOM-COSG-IX ROUNDED = (PARCELAS-PRM-TARIFARIO-IX - PARCELAS-VAL-DESCONTO-IX + PARCELAS-ADICIONAL-FRAC-IX) * WPCT-COM-AUX / 100 */
                AREA_DE_WORK.WCOM_COSG_IX.Value = (PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX - PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX + PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX) * AREA_DE_WORK.WPCT_COM_AUX / 100f;

                /*" -1186- COMPUTE WPRM-TOTL-IX = (WPRM-LIQD-IX + WVLR-ADIC-IX) - WCOM-COSG-IX */
                AREA_DE_WORK.WPRM_TOTL_IX.Value = (AREA_DE_WORK.WPRM_LIQD_IX + AREA_DE_WORK.WVLR_ADIC_IX) - AREA_DE_WORK.WCOM_COSG_IX;

                /*" -1186- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-MONTA-COSSPREM-SECTION */
        private void R2500_00_MONTA_COSSPREM_SECTION()
        {
            /*" -1199- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1202- INITIALIZE DCLCOSSEGURO-PREMIOS. */
            _.Initialize(
                COSSPREM.DCLCOSSEGURO_PREMIOS
            );

            /*" -1207- MOVE ZEROS TO COSSPREM-COD-EMPRESA */
            _.Move(0, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_EMPRESA);

            /*" -1209- MOVE APOLICES-TIPO-SEGURO TO COSSPREM-TIPO-SEGURO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_TIPO_SEGURO);

            /*" -1210- MOVE WCOD-CSG-AUX TO COSSPREM-COD-CONGENERE. */
            _.Move(AREA_DE_WORK.WCOD_CSG_AUX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_CONGENERE);

            /*" -1212- MOVE WNUM-ORD-AUX TO COSSPREM-NUM-ORDEM. */
            _.Move(AREA_DE_WORK.WNUM_ORD_AUX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ORDEM);

            /*" -1213- MOVE PARCEHIS-NUM-APOLICE TO COSSPREM-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_APOLICE);

            /*" -1214- MOVE PARCEHIS-NUM-ENDOSSO TO COSSPREM-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ENDOSSO);

            /*" -1216- MOVE PARCEHIS-NUM-PARCELA TO COSSPREM-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_PARCELA);

            /*" -1217- MOVE WPRM-TARF-IX TO COSSPREM-PRM-TARIFARIO-IX. */
            _.Move(AREA_DE_WORK.WPRM_TARF_IX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_PRM_TARIFARIO_IX);

            /*" -1218- MOVE WVLR-DESC-IX TO COSSPREM-VAL-DESCONTO-IX. */
            _.Move(AREA_DE_WORK.WVLR_DESC_IX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_VAL_DESCONTO_IX);

            /*" -1219- MOVE WPRM-LIQD-IX TO COSSPREM-PRM-LIQUIDO-IX. */
            _.Move(AREA_DE_WORK.WPRM_LIQD_IX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_PRM_LIQUIDO_IX);

            /*" -1220- MOVE WVLR-ADIC-IX TO COSSPREM-ADIC-FRACIO-IX. */
            _.Move(AREA_DE_WORK.WVLR_ADIC_IX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_ADIC_FRACIO_IX);

            /*" -1221- MOVE WCOM-COSG-IX TO COSSPREM-VAL-COMISSAO-IX. */
            _.Move(AREA_DE_WORK.WCOM_COSG_IX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_VAL_COMISSAO_IX);

            /*" -1223- MOVE WPRM-TOTL-IX TO COSSPREM-PRM-TOTAL-IX. */
            _.Move(AREA_DE_WORK.WPRM_TOTL_IX, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_PRM_TOTAL_IX);

            /*" -1224- MOVE '0' TO COSSPREM-SIT-REGISTRO. */
            _.Move("0", COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_SIT_REGISTRO);

            /*" -1226- MOVE '0' TO COSSPREM-SIT-CONGENERE. */
            _.Move("0", COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_SIT_CONGENERE);

            /*" -1227- MOVE 01 TO COSSPREM-OCORR-HISTORICO. */
            _.Move(01, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_OCORR_HISTORICO);

            /*" -1227- MOVE +1 TO VIND-OCR-HIST. */
            _.Move(+1, VIND_OCR_HIST);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-INSERT-COSSPREM-SECTION */
        private void R2600_00_INSERT_COSSPREM_SECTION()
        {
            /*" -1240- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WABEND.WNR_EXEC_SQL);

            /*" -1259- PERFORM R2600_00_INSERT_COSSPREM_DB_INSERT_1 */

            R2600_00_INSERT_COSSPREM_DB_INSERT_1();

            /*" -1262- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1263- DISPLAY 'R2600 - ERRO NO INSERT DA COSSSEGURO-PREMIOS' */
                _.Display($"R2600 - ERRO NO INSERT DA COSSSEGURO-PREMIOS");

                /*" -1264- DISPLAY 'TIP SEGUR - ' COSSPREM-TIPO-SEGURO */
                _.Display($"TIP SEGUR - {COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_TIPO_SEGURO}");

                /*" -1265- DISPLAY 'CONGENERE - ' COSSPREM-COD-CONGENERE */
                _.Display($"CONGENERE - {COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_CONGENERE}");

                /*" -1266- DISPLAY 'NUM ORDEM - ' COSSPREM-NUM-ORDEM */
                _.Display($"NUM ORDEM - {COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ORDEM}");

                /*" -1267- DISPLAY 'APOLICE   - ' COSSPREM-NUM-APOLICE */
                _.Display($"APOLICE   - {COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_APOLICE}");

                /*" -1268- DISPLAY 'ENDOSSO   - ' COSSPREM-NUM-ENDOSSO */
                _.Display($"ENDOSSO   - {COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ENDOSSO}");

                /*" -1269- DISPLAY 'PARCELA   - ' COSSPREM-NUM-PARCELA */
                _.Display($"PARCELA   - {COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_PARCELA}");

                /*" -1270- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1271- ELSE */
            }
            else
            {


                /*" -1272- ADD 1 TO AC-I-COSSPREM */
                AREA_DE_WORK.AC_I_COSSPREM.Value = AREA_DE_WORK.AC_I_COSSPREM + 1;

                /*" -1272- END-IF. */
            }


        }

        [StopWatch]
        /*" R2600-00-INSERT-COSSPREM-DB-INSERT-1 */
        public void R2600_00_INSERT_COSSPREM_DB_INSERT_1()
        {
            /*" -1259- EXEC SQL INSERT INTO SEGUROS.COSSEGURO_PREMIOS VALUES (:COSSPREM-COD-EMPRESA , :COSSPREM-TIPO-SEGURO , :COSSPREM-COD-CONGENERE , :COSSPREM-NUM-ORDEM , :COSSPREM-NUM-APOLICE , :COSSPREM-NUM-ENDOSSO , :COSSPREM-NUM-PARCELA , :COSSPREM-PRM-TARIFARIO-IX, :COSSPREM-VAL-DESCONTO-IX , :COSSPREM-PRM-LIQUIDO-IX , :COSSPREM-ADIC-FRACIO-IX , :COSSPREM-VAL-COMISSAO-IX , :COSSPREM-PRM-TOTAL-IX , :COSSPREM-SIT-REGISTRO , :COSSPREM-SIT-CONGENERE , CURRENT TIMESTAMP , :COSSPREM-OCORR-HISTORICO:VIND-OCR-HIST) END-EXEC. */

            var r2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1 = new R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1()
            {
                COSSPREM_COD_EMPRESA = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_EMPRESA.ToString(),
                COSSPREM_TIPO_SEGURO = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_TIPO_SEGURO.ToString(),
                COSSPREM_COD_CONGENERE = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_CONGENERE.ToString(),
                COSSPREM_NUM_ORDEM = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ORDEM.ToString(),
                COSSPREM_NUM_APOLICE = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_APOLICE.ToString(),
                COSSPREM_NUM_ENDOSSO = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ENDOSSO.ToString(),
                COSSPREM_NUM_PARCELA = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_PARCELA.ToString(),
                COSSPREM_PRM_TARIFARIO_IX = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_PRM_TARIFARIO_IX.ToString(),
                COSSPREM_VAL_DESCONTO_IX = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_VAL_DESCONTO_IX.ToString(),
                COSSPREM_PRM_LIQUIDO_IX = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_PRM_LIQUIDO_IX.ToString(),
                COSSPREM_ADIC_FRACIO_IX = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_ADIC_FRACIO_IX.ToString(),
                COSSPREM_VAL_COMISSAO_IX = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_VAL_COMISSAO_IX.ToString(),
                COSSPREM_PRM_TOTAL_IX = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_PRM_TOTAL_IX.ToString(),
                COSSPREM_SIT_REGISTRO = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_SIT_REGISTRO.ToString(),
                COSSPREM_SIT_CONGENERE = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_SIT_CONGENERE.ToString(),
                COSSPREM_OCORR_HISTORICO = COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_OCORR_HISTORICO.ToString(),
                VIND_OCR_HIST = VIND_OCR_HIST.ToString(),
            };

            R2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1.Execute(r2600_00_INSERT_COSSPREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-MONTA-COSHISPR-SECTION */
        private void R2700_00_MONTA_COSHISPR_SECTION()
        {
            /*" -1285- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WABEND.WNR_EXEC_SQL);

            /*" -1288- INITIALIZE DCLCOSSEGURO-HIST-PRE. */
            _.Initialize(
                COSHISPR.DCLCOSSEGURO_HIST_PRE
            );

            /*" -1293- MOVE ZEROS TO COSHISPR-COD-EMPRESA */
            _.Move(0, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_EMPRESA);

            /*" -1295- MOVE WCOD-CSG-AUX TO COSHISPR-COD-CONGENERE. */
            _.Move(AREA_DE_WORK.WCOD_CSG_AUX, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE);

            /*" -1296- MOVE PARCEHIS-NUM-APOLICE TO COSHISPR-NUM-APOLICE. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE);

            /*" -1297- MOVE PARCEHIS-NUM-ENDOSSO TO COSHISPR-NUM-ENDOSSO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO);

            /*" -1303- MOVE PARCEHIS-NUM-PARCELA TO COSHISPR-NUM-PARCELA. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA);

            /*" -1305- MOVE WNUM-ORD-AUX TO ORDEMCOS-ORDEM-CEDIDO. */
            _.Move(AREA_DE_WORK.WNUM_ORD_AUX, ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO);

            /*" -1306- IF WTIP-OPER = 01 */

            if (AREA_DE_WORK.WCOD_OPER_R.WTIP_OPER == 01)
            {

                /*" -1307- MOVE ZEROS TO WHOST-OCORHIST */
                _.Move(0, WHOST_OCORHIST);

                /*" -1308- ELSE */
            }
            else
            {


                /*" -1309- PERFORM R3000-00-SELECT-COSSPREM */

                R3000_00_SELECT_COSSPREM_SECTION();

                /*" -1311- END-IF. */
            }


            /*" -1313- COMPUTE WHOST-OCORHIST = WHOST-OCORHIST + 1. */
            WHOST_OCORHIST.Value = WHOST_OCORHIST + 1;

            /*" -1315- MOVE WHOST-OCORHIST TO COSHISPR-OCORR-HISTORICO. */
            _.Move(WHOST_OCORHIST, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO);

            /*" -1316- MOVE PARCEHIS-COD-OPERACAO TO COSHISPR-COD-OPERACAO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO);

            /*" -1318- MOVE PARCEHIS-DATA-MOVIMENTO TO COSHISPR-DATA-MOVIMENTO. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO);

            /*" -1320- MOVE APOLICES-TIPO-SEGURO TO COSHISPR-TIPO-SEGURO. */
            _.Move(APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO);

            /*" -1321- MOVE WPRM-TARF TO COSHISPR-PRM-TARIFARIO. */
            _.Move(AREA_DE_WORK.WPRM_TARF, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_PRM_TARIFARIO);

            /*" -1322- MOVE WVLR-DESC TO COSHISPR-VAL-DESCONTO. */
            _.Move(AREA_DE_WORK.WVLR_DESC, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_VAL_DESCONTO);

            /*" -1323- MOVE WPRM-LIQD TO COSHISPR-PRM-LIQUIDO. */
            _.Move(AREA_DE_WORK.WPRM_LIQD, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_PRM_LIQUIDO);

            /*" -1324- MOVE WVLR-ADIC TO COSHISPR-ADIC-FRACIONAMENTO. */
            _.Move(AREA_DE_WORK.WVLR_ADIC, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_ADIC_FRACIONAMENTO);

            /*" -1325- MOVE WCOM-COSG TO COSHISPR-VAL-COMISSAO. */
            _.Move(AREA_DE_WORK.WCOM_COSG, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_VAL_COMISSAO);

            /*" -1327- MOVE WPRM-TOTL TO COSHISPR-PRM-TOTAL. */
            _.Move(AREA_DE_WORK.WPRM_TOTL, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_PRM_TOTAL);

            /*" -1328- IF VIND-DAT-QTBC < ZEROS */

            if (VIND_DAT_QTBC < 00)
            {

                /*" -1329- MOVE SPACES TO COSHISPR-DATA-QUITACAO */
                _.Move("", COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_QUITACAO);

                /*" -1330- ELSE */
            }
            else
            {


                /*" -1331- MOVE PARCEHIS-DATA-QUITACAO TO COSHISPR-DATA-QUITACAO */
                _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_QUITACAO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_QUITACAO);

                /*" -1333- END-IF. */
            }


            /*" -1334- MOVE '0' TO COSHISPR-SIT-FINANCEIRA. */
            _.Move("0", COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_SIT_FINANCEIRA);

            /*" -1336- MOVE +1 TO VIND-SIT-FINC. */
            _.Move(+1, VIND_SIT_FINC);

            /*" -1337- MOVE '0' TO COSHISPR-SIT-LIBRECUP. */
            _.Move("0", COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_SIT_LIBRECUP);

            /*" -1339- MOVE +1 TO VIND-SIT-LIBR. */
            _.Move(+1, VIND_SIT_LIBR);

            /*" -1340- MOVE WHOST-OCORHIST TO COSHISPR-NUM-OCORRENCIA. */
            _.Move(WHOST_OCORHIST, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_OCORRENCIA);

            /*" -1340- MOVE +1 TO VIND-NUM-OCOR. */
            _.Move(+1, VIND_NUM_OCOR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-INSERT-COSHISPR-SECTION */
        private void R2800_00_INSERT_COSHISPR_SECTION()
        {
            /*" -1353- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WABEND.WNR_EXEC_SQL);

            /*" -1375- PERFORM R2800_00_INSERT_COSHISPR_DB_INSERT_1 */

            R2800_00_INSERT_COSHISPR_DB_INSERT_1();

            /*" -1378- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1379- DISPLAY 'R2800 - ERRO NO INSERT DA COSSSEGURO-HIST-PRE' */
                _.Display($"R2800 - ERRO NO INSERT DA COSSSEGURO-HIST-PRE");

                /*" -1380- DISPLAY 'TIP SEGUR - ' COSHISPR-TIPO-SEGURO */
                _.Display($"TIP SEGUR - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                /*" -1381- DISPLAY 'CONGENERE - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -1382- DISPLAY 'APOLICE   - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -1383- DISPLAY 'ENDOSSO   - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -1384- DISPLAY 'PARCELA   - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -1385- DISPLAY 'OCOR HIST - ' COSHISPR-OCORR-HISTORICO */
                _.Display($"OCOR HIST - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO}");

                /*" -1386- DISPLAY 'OPERACAO  - ' COSHISPR-COD-OPERACAO */
                _.Display($"OPERACAO  - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO}");

                /*" -1387- DISPLAY 'DT MOVTO  - ' COSHISPR-DATA-MOVIMENTO */
                _.Display($"DT MOVTO  - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO}");

                /*" -1388- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1389- ELSE */
            }
            else
            {


                /*" -1390- ADD 1 TO AC-I-COSHISPR */
                AREA_DE_WORK.AC_I_COSHISPR.Value = AREA_DE_WORK.AC_I_COSHISPR + 1;

                /*" -1390- END-IF. */
            }


        }

        [StopWatch]
        /*" R2800-00-INSERT-COSHISPR-DB-INSERT-1 */
        public void R2800_00_INSERT_COSHISPR_DB_INSERT_1()
        {
            /*" -1375- EXEC SQL INSERT INTO SEGUROS.COSSEGURO_HIST_PRE VALUES (:COSHISPR-COD-EMPRESA , :COSHISPR-COD-CONGENERE , :COSHISPR-NUM-APOLICE , :COSHISPR-NUM-ENDOSSO , :COSHISPR-NUM-PARCELA , :COSHISPR-OCORR-HISTORICO , :COSHISPR-COD-OPERACAO , :COSHISPR-DATA-MOVIMENTO , :COSHISPR-TIPO-SEGURO , :COSHISPR-PRM-TARIFARIO , :COSHISPR-VAL-DESCONTO , :COSHISPR-PRM-LIQUIDO , :COSHISPR-ADIC-FRACIONAMENTO, :COSHISPR-VAL-COMISSAO , :COSHISPR-PRM-TOTAL , CURRENT TIMESTAMP , :COSHISPR-DATA-QUITACAO:VIND-DAT-QTBC, :COSHISPR-SIT-FINANCEIRA:VIND-SIT-FINC, :COSHISPR-SIT-LIBRECUP:VIND-SIT-LIBR, :COSHISPR-NUM-OCORRENCIA:VIND-NUM-OCOR) END-EXEC. */

            var r2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1 = new R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1()
            {
                COSHISPR_COD_EMPRESA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_EMPRESA.ToString(),
                COSHISPR_COD_CONGENERE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE.ToString(),
                COSHISPR_NUM_APOLICE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE.ToString(),
                COSHISPR_NUM_ENDOSSO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO.ToString(),
                COSHISPR_NUM_PARCELA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA.ToString(),
                COSHISPR_OCORR_HISTORICO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO.ToString(),
                COSHISPR_COD_OPERACAO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO.ToString(),
                COSHISPR_DATA_MOVIMENTO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO.ToString(),
                COSHISPR_TIPO_SEGURO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO.ToString(),
                COSHISPR_PRM_TARIFARIO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_PRM_TARIFARIO.ToString(),
                COSHISPR_VAL_DESCONTO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_VAL_DESCONTO.ToString(),
                COSHISPR_PRM_LIQUIDO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_PRM_LIQUIDO.ToString(),
                COSHISPR_ADIC_FRACIONAMENTO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_ADIC_FRACIONAMENTO.ToString(),
                COSHISPR_VAL_COMISSAO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_VAL_COMISSAO.ToString(),
                COSHISPR_PRM_TOTAL = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_PRM_TOTAL.ToString(),
                COSHISPR_DATA_QUITACAO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_QUITACAO.ToString(),
                VIND_DAT_QTBC = VIND_DAT_QTBC.ToString(),
                COSHISPR_SIT_FINANCEIRA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_SIT_FINANCEIRA.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                COSHISPR_SIT_LIBRECUP = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                COSHISPR_NUM_OCORRENCIA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_OCORRENCIA.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1.Execute(r2800_00_INSERT_COSHISPR_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R3000-00-SELECT-COSSPREM-SECTION */
        private void R3000_00_SELECT_COSSPREM_SECTION()
        {
            /*" -1403- MOVE '3000' TO WNR-EXEC-SQL. */
            _.Move("3000", WABEND.WNR_EXEC_SQL);

            /*" -1413- PERFORM R3000_00_SELECT_COSSPREM_DB_SELECT_1 */

            R3000_00_SELECT_COSSPREM_DB_SELECT_1();

            /*" -1416- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1417- DISPLAY 'R3000 - ERRO NO SELECT DA COSSSEGURO-PREMIOS' */
                _.Display($"R3000 - ERRO NO SELECT DA COSSSEGURO-PREMIOS");

                /*" -1418- DISPLAY 'TIP SEGUR - ' APOLICES-TIPO-SEGURO */
                _.Display($"TIP SEGUR - {APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO}");

                /*" -1419- DISPLAY 'CONGENERE - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -1420- DISPLAY 'NUM ORDEM - ' ORDEMCOS-ORDEM-CEDIDO */
                _.Display($"NUM ORDEM - {ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO}");

                /*" -1421- DISPLAY 'APOLICE   - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -1422- DISPLAY 'ENDOSSO   - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -1423- DISPLAY 'PARCELA   - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -1424- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1425- ELSE */
            }
            else
            {


                /*" -1426- ADD 1 TO AC-L-COSSPREM */
                AREA_DE_WORK.AC_L_COSSPREM.Value = AREA_DE_WORK.AC_L_COSSPREM + 1;

                /*" -1426- END-IF. */
            }


        }

        [StopWatch]
        /*" R3000-00-SELECT-COSSPREM-DB-SELECT-1 */
        public void R3000_00_SELECT_COSSPREM_DB_SELECT_1()
        {
            /*" -1413- EXEC SQL SELECT OCORR_HISTORICO INTO :WHOST-OCORHIST FROM SEGUROS.COSSEGURO_PREMIOS WHERE TIPO_SEGURO = :APOLICES-TIPO-SEGURO AND COD_CONGENERE = :COSHISPR-COD-CONGENERE AND NUM_ORDEM = :ORDEMCOS-ORDEM-CEDIDO AND NUM_APOLICE = :COSHISPR-NUM-APOLICE AND NUM_ENDOSSO = :COSHISPR-NUM-ENDOSSO AND NUM_PARCELA = :COSHISPR-NUM-PARCELA END-EXEC. */

            var r3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1 = new R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1()
            {
                COSHISPR_COD_CONGENERE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE.ToString(),
                ORDEMCOS_ORDEM_CEDIDO = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO.ToString(),
                APOLICES_TIPO_SEGURO = APOLICES.DCLAPOLICES.APOLICES_TIPO_SEGURO.ToString(),
                COSHISPR_NUM_APOLICE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE.ToString(),
                COSHISPR_NUM_ENDOSSO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO.ToString(),
                COSHISPR_NUM_PARCELA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA.ToString(),
            };

            var executed_1 = R3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1.Execute(r3000_00_SELECT_COSSPREM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_OCORHIST, WHOST_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-MONTA-SITUACAO-SECTION */
        private void R3100_00_MONTA_SITUACAO_SECTION()
        {
            /*" -1441- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WABEND.WNR_EXEC_SQL);

            /*" -1442- IF WTIP-OPER = 02 */

            if (AREA_DE_WORK.WCOD_OPER_R.WTIP_OPER == 02)
            {

                /*" -1443- MOVE '1' TO WHOST-SIT-REGT */
                _.Move("1", WHOST_SIT_REGT);

                /*" -1444- ELSE */
            }
            else
            {


                /*" -1445- IF WTIP-OPER = 03 OR 05 OR 08 */

                if (AREA_DE_WORK.WCOD_OPER_R.WTIP_OPER.In("03", "05", "08"))
                {

                    /*" -1446- MOVE '0' TO WHOST-SIT-REGT */
                    _.Move("0", WHOST_SIT_REGT);

                    /*" -1447- ELSE */
                }
                else
                {


                    /*" -1448- IF WTIP-OPER = 04 */

                    if (AREA_DE_WORK.WCOD_OPER_R.WTIP_OPER == 04)
                    {

                        /*" -1449- MOVE '2' TO WHOST-SIT-REGT */
                        _.Move("2", WHOST_SIT_REGT);

                        /*" -1450- ELSE */
                    }
                    else
                    {


                        /*" -1451- DISPLAY 'R3100 - TIPO OPERACAO NAO PREVISTA' */
                        _.Display($"R3100 - TIPO OPERACAO NAO PREVISTA");

                        /*" -1452- DISPLAY 'TIP SEGUR - ' COSHISPR-TIPO-SEGURO */
                        _.Display($"TIP SEGUR - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                        /*" -1453- DISPLAY 'CONGENERE - ' COSHISPR-COD-CONGENERE */
                        _.Display($"CONGENERE - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                        /*" -1454- DISPLAY 'APOLICE   - ' COSHISPR-NUM-APOLICE */
                        _.Display($"APOLICE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                        /*" -1455- DISPLAY 'ENDOSSO   - ' COSHISPR-NUM-ENDOSSO */
                        _.Display($"ENDOSSO   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                        /*" -1456- DISPLAY 'PARCELA   - ' COSHISPR-NUM-PARCELA */
                        _.Display($"PARCELA   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                        /*" -1457- DISPLAY 'OCR HIST  - ' COSHISPR-OCORR-HISTORICO */
                        _.Display($"OCR HIST  - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO}");

                        /*" -1458- DISPLAY 'OPERACAO  - ' COSHISPR-COD-OPERACAO */
                        _.Display($"OPERACAO  - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO}");

                        /*" -1459- DISPLAY 'DT MOVTO  - ' COSHISPR-DATA-MOVIMENTO */
                        _.Display($"DT MOVTO  - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO}");

                        /*" -1460- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1461- END-IF */
                    }


                    /*" -1462- END-IF */
                }


                /*" -1462- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-UPDATE-COSSPREM-SECTION */
        private void R3200_00_UPDATE_COSSPREM_SECTION()
        {
            /*" -1475- MOVE '3200' TO WNR-EXEC-SQL. */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -1486- PERFORM R3200_00_UPDATE_COSSPREM_DB_UPDATE_1 */

            R3200_00_UPDATE_COSSPREM_DB_UPDATE_1();

            /*" -1489- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1490- DISPLAY 'R3200 - ERRO NO SELECT DA COSSSEGURO-PREMIOS' */
                _.Display($"R3200 - ERRO NO SELECT DA COSSSEGURO-PREMIOS");

                /*" -1491- DISPLAY 'TIP SEGUR - ' COSHISPR-TIPO-SEGURO */
                _.Display($"TIP SEGUR - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                /*" -1492- DISPLAY 'CONGENERE - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -1493- DISPLAY 'NUM ORDEM - ' ORDEMCOS-ORDEM-CEDIDO */
                _.Display($"NUM ORDEM - {ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO}");

                /*" -1494- DISPLAY 'APOLICE   - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -1495- DISPLAY 'ENDOSSO   - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -1496- DISPLAY 'PARCELA   - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -1497- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1498- ELSE */
            }
            else
            {


                /*" -1499- ADD 1 TO AC-U-COSSPREM */
                AREA_DE_WORK.AC_U_COSSPREM.Value = AREA_DE_WORK.AC_U_COSSPREM + 1;

                /*" -1499- END-IF. */
            }


        }

        [StopWatch]
        /*" R3200-00-UPDATE-COSSPREM-DB-UPDATE-1 */
        public void R3200_00_UPDATE_COSSPREM_DB_UPDATE_1()
        {
            /*" -1486- EXEC SQL UPDATE SEGUROS.COSSEGURO_PREMIOS SET SIT_REGISTRO = :WHOST-SIT-REGT, OCORR_HISTORICO = :WHOST-OCORHIST, TIMESTAMP = CURRENT TIMESTAMP WHERE TIPO_SEGURO = :COSHISPR-TIPO-SEGURO AND COD_CONGENERE = :COSHISPR-COD-CONGENERE AND NUM_ORDEM = :ORDEMCOS-ORDEM-CEDIDO AND NUM_APOLICE = :COSHISPR-NUM-APOLICE AND NUM_ENDOSSO = :COSHISPR-NUM-ENDOSSO AND NUM_PARCELA = :COSHISPR-NUM-PARCELA END-EXEC. */

            var r3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1 = new R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1()
            {
                WHOST_SIT_REGT = WHOST_SIT_REGT.ToString(),
                WHOST_OCORHIST = WHOST_OCORHIST.ToString(),
                COSHISPR_COD_CONGENERE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE.ToString(),
                ORDEMCOS_ORDEM_CEDIDO = ORDEMCOS.DCLORDEM_COSSEGCED.ORDEMCOS_ORDEM_CEDIDO.ToString(),
                COSHISPR_TIPO_SEGURO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO.ToString(),
                COSHISPR_NUM_APOLICE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE.ToString(),
                COSHISPR_NUM_ENDOSSO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO.ToString(),
                COSHISPR_NUM_PARCELA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA.ToString(),
            };

            R3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1.Execute(r3200_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1512- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-AUX. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_AUX);

            /*" -1513- MOVE WDAT-DIA-AUX TO WDAT-DIA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_DIA_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

            /*" -1514- MOVE WDAT-MES-AUX TO WDAT-MES-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_MES_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

            /*" -1516- MOVE WDAT-ANO-AUX TO WDAT-ANO-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_ANO_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

            /*" -1517- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1518- DISPLAY '*   AC0009B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0009B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -1519- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -1520- DISPLAY '*             COSSEGURO CEDIDO             *' . */
            _.Display($"*             COSSEGURO CEDIDO             *");

            /*" -1521- DISPLAY '*             --------- ------             *' . */
            _.Display($"*             --------- ------             *");

            /*" -1522- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1523- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1525- DISPLAY '*              ' WDATA-EDIT '                    *' . */

            $"*              {AREA_DE_WORK.WDATA_EDIT}                    *"
            .Display();

            /*" -1525- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1540- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1542- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1542- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1546- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1546- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}