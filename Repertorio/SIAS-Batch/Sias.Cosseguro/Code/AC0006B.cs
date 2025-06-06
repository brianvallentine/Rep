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
using Sias.Cosseguro.DB2.AC0006B;

namespace Code
{
    public class AC0006B
    {
        public bool IsCall { get; set; }

        public AC0006B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0006B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  GILSON                             *      */
        /*"      *   PROGRAMADOR ............  GILSON                             *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2013                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA OS PERCENTUAIS PROPORCIONAIS  *      */
        /*"      *                             DE COSSEGURO CEDIDO POR RAMO E COD *      */
        /*"      *                             DE COBERTURA E CIA CONGENERE.      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              DCLGEN            ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            SISTEMAS          INPUT    *      */
        /*"      * COSSEGURO HIST PREMIOS              COSHISPR          INPUT    *      */
        /*"      * APOLICES                            APOLICES          INPUT    *      */
        /*"      * HISTORICO PARCELAS                  PARCEHIS          INPUT    *      */
        /*"      * ENDOSSOS                            ENDOSSOS          INPUT    *      */
        /*"      * PARCELAS                            PARCELAS          INPUT    *      */
        /*"      * APOLICE COBERTURAS                  APOLICOB          INPUT    *      */
        /*"      * APOLICE COSSEGURO CEDIDO            APOLCOSS          INPUT    *      */
        /*"      * ENDOS COSSEG COBERTURA              GE397             INPUT    *      */
        /*"      * ENDOS PCT PART COBERTURA            GE398             INPUT    *      */
        /*"      * ENDOS RAMO VLR COSSEGURO            GE399             OUTPUT   *      */
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
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA TRATAR/INCLUIR O ORGAO 300 *      */
        /*"      * 21/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77        WHOST-QTDE-REG        PIC S9(009)      VALUE +0 COMP.*/
        public IntBasis WHOST_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01        AREA-DE-WORK.*/
        public AC0006B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0006B_AREA_DE_WORK();
        public class AC0006B_AREA_DE_WORK : VarBasis
        {
            /*"  05      WFIM-PARCEHIS         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_PARCEHIS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-APOLCOSS         PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_APOLCOSS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WFIM-GE397-GE398      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_GE397_GE398 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      WTEM-PERI-ABERTO      PIC  X(001)      VALUE SPACES.*/
            public StringBasis WTEM_PERI_ABERTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05      AC-L-PARCEHIS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_PARCEHIS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-ENDOSSOS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_ENDOSSOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-APOLCOSS         PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_APOLCOSS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-L-GE397-GE398      PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_L_GE397_GE398 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      AC-I-GE399            PIC  9(007)      VALUE ZEROS.*/
            public IntBasis AC_I_GE399 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  05      WNUM-APOL-ANT         PIC S9(013)      VALUE +0 COMP-3*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05      WNUM-ENDS-ANT         PIC S9(009)      VALUE +0 COMP.*/
            public IntBasis WNUM_ENDS_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05      WCOD-RAMO-ANT         PIC S9(004)      VALUE +0 COMP.*/
            public IntBasis WCOD_RAMO_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05      WIMP-SEGUR-TOT        PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WIMP_SEGUR_TOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-TARIF-TOT        PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_TARIF_TOT { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WIMP-SEGUR-RMO        PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WIMP_SEGUR_RMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-TARIF-RMO        PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_TARIF_RMO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WIMP-SEG-CED-COB      PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WIMP_SEG_CED_COB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-TAR-CED-COB      PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_TAR_CED_COB { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WIMP-SEG-CED-RMO      PIC S9(013)V99   VALUE +0.*/
            public DoubleBasis WIMP_SEG_CED_RMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  05      WPRM-TAR-CED-RMO      PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WPRM_TAR_CED_RMO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WVLR-BASE-COMS        PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WVLR_BASE_COMS { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WVLR-COMCOSG-COB      PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WVLR_COMCOSG_COB { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WVLR-COMCOSG-RMO      PIC S9(010)V9(5) VALUE +0.*/
            public DoubleBasis WVLR_COMCOSG_RMO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
            /*"  05      WPRM-TARIF-AUX        PIC S9(010)V99   VALUE +0.*/
            public DoubleBasis WPRM_TARIF_AUX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99"), 2);
            /*"  05      WCOM-COSEG-AUX        PIC S9(010)V99   VALUE +0.*/
            public DoubleBasis WCOM_COSEG_AUX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99"), 2);
            /*"  05      WPCT-PROP-RMO-IS      PIC S9(004)V9(9) VALUE +0.*/
            public DoubleBasis WPCT_PROP_RMO_IS { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(9)"), 9);
            /*"  05      WPCT-PROP-TOT-IS      PIC S9(004)V9(9) VALUE +0.*/
            public DoubleBasis WPCT_PROP_TOT_IS { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(9)"), 9);
            /*"  05      WPCT-PROP-RMO-PR      PIC S9(004)V9(9) VALUE +0.*/
            public DoubleBasis WPCT_PROP_RMO_PR { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(9)"), 9);
            /*"  05      WPCT-PROP-TOT-PR      PIC S9(004)V9(9) VALUE +0.*/
            public DoubleBasis WPCT_PROP_TOT_PR { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(9)"), 9);
            /*"  05      WPCT-PROP-COM-RMO     PIC S9(004)V9(9) VALUE +0.*/
            public DoubleBasis WPCT_PROP_COM_RMO { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(9)"), 9);
            /*"  05      WPCT-PROP-COM-TOT     PIC S9(004)V9(9) VALUE +0.*/
            public DoubleBasis WPCT_PROP_COM_TOT { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(9)"), 9);
            /*"  05      WDATA-AUX             PIC  X(010)      VALUE SPACES.*/
            public StringBasis WDATA_AUX { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05      WDATA-AUX-R           REDEFINES        WDATA-AUX.*/
            private _REDEF_AC0006B_WDATA_AUX_R _wdata_aux_r { get; set; }
            public _REDEF_AC0006B_WDATA_AUX_R WDATA_AUX_R
            {
                get { _wdata_aux_r = new _REDEF_AC0006B_WDATA_AUX_R(); _.Move(WDATA_AUX, _wdata_aux_r); VarBasis.RedefinePassValue(WDATA_AUX, _wdata_aux_r, WDATA_AUX); _wdata_aux_r.ValueChanged += () => { _.Move(_wdata_aux_r, WDATA_AUX); }; return _wdata_aux_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_aux_r, WDATA_AUX); }
            }  //Redefines
            public class _REDEF_AC0006B_WDATA_AUX_R : VarBasis
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

                public _REDEF_AC0006B_WDATA_AUX_R()
                {
                    WDAT_ANO_AUX.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WDAT_MES_AUX.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDAT_DIA_AUX.ValueChanged += OnValueChanged;
                }

            }
            public AC0006B_WDATA_EDIT WDATA_EDIT { get; set; } = new AC0006B_WDATA_EDIT();
            public class AC0006B_WDATA_EDIT : VarBasis
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
            public AC0006B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0006B_WHORA_ACCEPT();
            public class AC0006B_WHORA_ACCEPT : VarBasis
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
            public AC0006B_WHORA_EDIT WHORA_EDIT { get; set; } = new AC0006B_WHORA_EDIT();
            public class AC0006B_WHORA_EDIT : VarBasis
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
        public AC0006B_WABEND WABEND { get; set; } = new AC0006B_WABEND();
        public class AC0006B_WABEND : VarBasis
        {
            /*"  05      FILLER                PIC  X(009)      VALUE         'AC0006B '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"AC0006B ");
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
        public Dclgens.COSHISPR COSHISPR { get; set; } = new Dclgens.COSHISPR();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PARCEHIS PARCEHIS { get; set; } = new Dclgens.PARCEHIS();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PARCELAS PARCELAS { get; set; } = new Dclgens.PARCELAS();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.APOLCOSS APOLCOSS { get; set; } = new Dclgens.APOLCOSS();
        public Dclgens.GE397 GE397 { get; set; } = new Dclgens.GE397();
        public Dclgens.GE398 GE398 { get; set; } = new Dclgens.GE398();
        public Dclgens.GE399 GE399 { get; set; } = new Dclgens.GE399();
        public AC0006B_C01_PARCEHIS C01_PARCEHIS { get; set; } = new AC0006B_C01_PARCEHIS();
        public AC0006B_C01_APOLCOSS C01_APOLCOSS { get; set; } = new AC0006B_C01_APOLCOSS();
        public AC0006B_COSGCOBER COSGCOBER { get; set; } = new AC0006B_COSGCOBER();
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
            /*" -228- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -229- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -232- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -235- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -243- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -245- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -247- PERFORM R0200-00-CHECA-EXECUCAO. */

            R0200_00_CHECA_EXECUCAO_SECTION();

            /*" -248- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -249- DISPLAY 'AC0006B - DUPLICIDADE DE PROCESSAMENTO' */
                _.Display($"AC0006B - DUPLICIDADE DE PROCESSAMENTO");

                /*" -250- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -254- END-IF. */
            }


            /*" -255- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -256- MOVE WHH-ACCEPT TO WHH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDIT);

            /*" -257- MOVE WMM-ACCEPT TO WMM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDIT);

            /*" -258- MOVE WSS-ACCEPT TO WSS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDIT);

            /*" -260- DISPLAY 'INICIO DECLARE PARCELA HIST - ' WHORA-EDIT. */
            _.Display($"INICIO DECLARE PARCELA HIST - {AREA_DE_WORK.WHORA_EDIT}");

            /*" -262- PERFORM R0500-00-DECLARE-PARCEHIS. */

            R0500_00_DECLARE_PARCEHIS_SECTION();

            /*" -263- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -264- MOVE WHH-ACCEPT TO WHH-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WHH_EDIT);

            /*" -265- MOVE WMM-ACCEPT TO WMM-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WMM_EDIT);

            /*" -266- MOVE WSS-ACCEPT TO WSS-EDIT. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_EDIT.WSS_EDIT);

            /*" -268- DISPLAY 'FINAL  DECLARE PARCELA HIST - ' WHORA-EDIT. */
            _.Display($"FINAL  DECLARE PARCELA HIST - {AREA_DE_WORK.WHORA_EDIT}");

            /*" -270- PERFORM R0600-00-FETCH-PARCEHIS. */

            R0600_00_FETCH_PARCEHIS_SECTION();

            /*" -271- IF WFIM-PARCEHIS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty())
            {

                /*" -272- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -273- ELSE */
            }
            else
            {


                /*" -275- PERFORM R0700-00-PROCESSA-PARCEHIS UNTIL WFIM-PARCEHIS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty()))
                {

                    R0700_00_PROCESSA_PARCEHIS_SECTION();
                }

                /*" -275- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -280- DISPLAY '                             ' . */
            _.Display($"                             ");

            /*" -281- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -282- DISPLAY 'REGISTROS LIDOS      : ' . */
            _.Display($"REGISTROS LIDOS      : ");

            /*" -283- DISPLAY 'PARCELA HISTORICO  - ' AC-L-PARCEHIS. */
            _.Display($"PARCELA HISTORICO  - {AREA_DE_WORK.AC_L_PARCEHIS}");

            /*" -284- DISPLAY 'ENDOSSOS           - ' AC-L-ENDOSSOS. */
            _.Display($"ENDOSSOS           - {AREA_DE_WORK.AC_L_ENDOSSOS}");

            /*" -285- DISPLAY 'APOL COSSEGURADORA - ' AC-L-APOLCOSS. */
            _.Display($"APOL COSSEGURADORA - {AREA_DE_WORK.AC_L_APOLCOSS}");

            /*" -286- DISPLAY 'GE397 JOIN GE398   - ' AC-L-GE397-GE398. */
            _.Display($"GE397 JOIN GE398   - {AREA_DE_WORK.AC_L_GE397_GE398}");

            /*" -287- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -288- DISPLAY 'REGISTROS GRAVADOS   : ' . */
            _.Display($"REGISTROS GRAVADOS   : ");

            /*" -289- DISPLAY 'ENDOS RAMO VLR CSG - ' AC-I-GE399. */
            _.Display($"ENDOS RAMO VLR CSG - {AREA_DE_WORK.AC_I_GE399}");

            /*" -290- DISPLAY '*---------------------------*' . */
            _.Display($"*---------------------------*");

            /*" -292- DISPLAY '                             ' . */
            _.Display($"                             ");

            /*" -294- DISPLAY '*--- AC0006B  -  FIM  NORMAL ---*' . */
            _.Display($"*--- AC0006B  -  FIM  NORMAL ---*");

            /*" -294- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -298- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -298- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -311- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -316- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -319- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -320- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS");

                /*" -321- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -322- ELSE */
            }
            else
            {


                /*" -323- DISPLAY 'DATA DO SISTEMA AC - ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA DO SISTEMA AC - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -323- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -316- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'AC' END-EXEC. */

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
            /*" -336- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", WABEND.WNR_EXEC_SQL);

            /*" -347- PERFORM R0200_00_CHECA_EXECUCAO_DB_SELECT_1 */

            R0200_00_CHECA_EXECUCAO_DB_SELECT_1();

            /*" -350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -351- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -352- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -353- ELSE */
                }
                else
                {


                    /*" -354- DISPLAY 'R0200 - ERRO NO SELECT DA COSSEGURO-HIST-PRE' */
                    _.Display($"R0200 - ERRO NO SELECT DA COSSEGURO-HIST-PRE");

                    /*" -355- DISPLAY 'DT MOVTO - ' SISTEMAS-DATA-MOV-ABERTO */
                    _.Display($"DT MOVTO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                    /*" -356- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -357- END-IF */
                }


                /*" -357- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-CHECA-EXECUCAO-DB-SELECT-1 */
        public void R0200_00_CHECA_EXECUCAO_DB_SELECT_1()
        {
            /*" -347- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.COSSEGURO_HIST_PRE A, SEGUROS.APOLICES B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.TIPO_SEGURO = '1' AND A.COD_OPERACAO < 0600 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPO_SEGURO = A.TIPO_SEGURO AND B.ORGAO_EMISSOR IN (0010,0300) END-EXEC. */

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
            /*" -370- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", WABEND.WNR_EXEC_SQL);

            /*" -393- PERFORM R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1 */

            R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1();

            /*" -395- PERFORM R0500_00_DECLARE_PARCEHIS_DB_OPEN_1 */

            R0500_00_DECLARE_PARCEHIS_DB_OPEN_1();

            /*" -398- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -399- DISPLAY 'R0500 - ERRO NO DECLARE DA PARCELA-HISTORICO' */
                _.Display($"R0500 - ERRO NO DECLARE DA PARCELA-HISTORICO");

                /*" -400- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -401- ELSE */
            }
            else
            {


                /*" -402- MOVE SPACES TO WFIM-PARCEHIS */
                _.Move("", AREA_DE_WORK.WFIM_PARCEHIS);

                /*" -402- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-DECLARE-PARCEHIS-DB-DECLARE-1 */
        public void R0500_00_DECLARE_PARCEHIS_DB_DECLARE_1()
        {
            /*" -393- EXEC SQL DECLARE C01_PARCEHIS CURSOR FOR SELECT A.NUM_APOLICE , A.NUM_ENDOSSO , A.NUM_PARCELA , A.DATA_MOVIMENTO , A.COD_OPERACAO , A.OCORR_HISTORICO FROM SEGUROS.PARCELA_HISTORICO A, SEGUROS.APOLICES B WHERE A.DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO AND A.NUM_PARCELA < 02 AND A.COD_OPERACAO < 0200 AND A.OCORR_HISTORICO = 01 AND B.NUM_APOLICE = A.NUM_APOLICE AND B.TIPO_SEGURO = '1' AND B.ORGAO_EMISSOR IN (0010,0300) AND B.QTD_COSSEGURADORA > 0 AND B.PCT_COSSEGURO_CED = 0 ORDER BY A.NUM_APOLICE, A.NUM_ENDOSSO, A.NUM_PARCELA, A.OCORR_HISTORICO END-EXEC. */
            C01_PARCEHIS = new AC0006B_C01_PARCEHIS(true);
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
							FROM SEGUROS.PARCELA_HISTORICO A
							, 
							SEGUROS.APOLICES B 
							WHERE A.DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							AND A.NUM_PARCELA < 02 
							AND A.COD_OPERACAO < 0200 
							AND A.OCORR_HISTORICO = 01 
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
            /*" -395- EXEC SQL OPEN C01_PARCEHIS END-EXEC. */

            C01_PARCEHIS.Open();

        }

        [StopWatch]
        /*" R1400-00-DECLARE-APOLCOSS-DB-DECLARE-1 */
        public void R1400_00_DECLARE_APOLCOSS_DB_DECLARE_1()
        {
            /*" -767- EXEC SQL DECLARE C01_APOLCOSS CURSOR FOR SELECT NUM_APOLICE, COD_COSSEGURADORA FROM SEGUROS.APOL_COSSEGURADORA WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND DATA_INIVIGENCIA <= :ENDOSSOS-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :ENDOSSOS-DATA-INIVIGENCIA AND PCT_PART_COSSEGURO = 0 AND PCT_COM_COSSEGURO > 0 ORDER BY COD_COSSEGURADORA END-EXEC. */
            C01_APOLCOSS = new AC0006B_C01_APOLCOSS(true);
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
            /*" -415- MOVE '0600' TO WNR-EXEC-SQL. */
            _.Move("0600", WABEND.WNR_EXEC_SQL);

            /*" -422- PERFORM R0600_00_FETCH_PARCEHIS_DB_FETCH_1 */

            R0600_00_FETCH_PARCEHIS_DB_FETCH_1();

            /*" -425- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -426- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -427- MOVE 'S' TO WFIM-PARCEHIS */
                    _.Move("S", AREA_DE_WORK.WFIM_PARCEHIS);

                    /*" -427- PERFORM R0600_00_FETCH_PARCEHIS_DB_CLOSE_1 */

                    R0600_00_FETCH_PARCEHIS_DB_CLOSE_1();

                    /*" -429- ELSE */
                }
                else
                {


                    /*" -430- DISPLAY 'R0600 - ERRO NO FETCH DA PARCELA-HISTORICO' */
                    _.Display($"R0600 - ERRO NO FETCH DA PARCELA-HISTORICO");

                    /*" -431- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -432- END-IF */
                }


                /*" -433- ELSE */
            }
            else
            {


                /*" -434- ADD 1 TO AC-L-PARCEHIS */
                AREA_DE_WORK.AC_L_PARCEHIS.Value = AREA_DE_WORK.AC_L_PARCEHIS + 1;

                /*" -434- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-FETCH-PARCEHIS-DB-FETCH-1 */
        public void R0600_00_FETCH_PARCEHIS_DB_FETCH_1()
        {
            /*" -422- EXEC SQL FETCH C01_PARCEHIS INTO :PARCEHIS-NUM-APOLICE , :PARCEHIS-NUM-ENDOSSO , :PARCEHIS-NUM-PARCELA , :PARCEHIS-DATA-MOVIMENTO, :PARCEHIS-COD-OPERACAO , :PARCEHIS-OCORR-HISTORICO END-EXEC. */

            if (C01_PARCEHIS.Fetch())
            {
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_APOLICE, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE);
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_ENDOSSO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO);
                _.Move(C01_PARCEHIS.PARCEHIS_NUM_PARCELA, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA);
                _.Move(C01_PARCEHIS.PARCEHIS_DATA_MOVIMENTO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO);
                _.Move(C01_PARCEHIS.PARCEHIS_COD_OPERACAO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO);
                _.Move(C01_PARCEHIS.PARCEHIS_OCORR_HISTORICO, PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO);
            }

        }

        [StopWatch]
        /*" R0600-00-FETCH-PARCEHIS-DB-CLOSE-1 */
        public void R0600_00_FETCH_PARCEHIS_DB_CLOSE_1()
        {
            /*" -427- EXEC SQL CLOSE C01_PARCEHIS END-EXEC */

            C01_PARCEHIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-PARCEHIS-SECTION */
        private void R0700_00_PROCESSA_PARCEHIS_SECTION()
        {
            /*" -447- MOVE '0700' TO WNR-EXEC-SQL. */
            _.Move("0700", WABEND.WNR_EXEC_SQL);

            /*" -448- MOVE PARCEHIS-NUM-APOLICE TO WNUM-APOL-ANT. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -453- MOVE PARCEHIS-NUM-ENDOSSO TO WNUM-ENDS-ANT. */
            _.Move(PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO, AREA_DE_WORK.WNUM_ENDS_ANT);

            /*" -455- MOVE ZEROS TO WHOST-QTDE-REG. */
            _.Move(0, WHOST_QTDE_REG);

            /*" -457- PERFORM R0800-00-SELECT-GE397. */

            R0800_00_SELECT_GE397_SECTION();

            /*" -458- IF WHOST-QTDE-REG > ZEROS */

            if (WHOST_QTDE_REG > 00)
            {

                /*" -459- PERFORM R0900-00-SELECT-ENDOSSOS */

                R0900_00_SELECT_ENDOSSOS_SECTION();

                /*" -460- PERFORM R1000-00-TRATA-PERI-ABERTO */

                R1000_00_TRATA_PERI_ABERTO_SECTION();

                /*" -461- IF WTEM-PERI-ABERTO = 'N' */

                if (AREA_DE_WORK.WTEM_PERI_ABERTO == "N")
                {

                    /*" -462- PERFORM R1100-00-PROCESSA-ENDOSSO */

                    R1100_00_PROCESSA_ENDOSSO_SECTION();

                    /*" -463- END-IF */
                }


                /*" -467- END-IF. */
            }


            /*" -470- PERFORM R0600-00-FETCH-PARCEHIS UNTIL WFIM-PARCEHIS NOT EQUAL SPACES OR PARCEHIS-NUM-APOLICE NOT EQUAL WNUM-APOL-ANT OR PARCEHIS-NUM-ENDOSSO NOT EQUAL WNUM-ENDS-ANT. */

            while (!(!AREA_DE_WORK.WFIM_PARCEHIS.IsEmpty() || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE != AREA_DE_WORK.WNUM_APOL_ANT || PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO != AREA_DE_WORK.WNUM_ENDS_ANT))
            {

                R0600_00_FETCH_PARCEHIS_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-SELECT-GE397-SECTION */
        private void R0800_00_SELECT_GE397_SECTION()
        {
            /*" -483- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", WABEND.WNR_EXEC_SQL);

            /*" -489- PERFORM R0800_00_SELECT_GE397_DB_SELECT_1 */

            R0800_00_SELECT_GE397_DB_SELECT_1();

            /*" -492- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -493- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -494- MOVE ZEROS TO WHOST-QTDE-REG */
                    _.Move(0, WHOST_QTDE_REG);

                    /*" -495- ELSE */
                }
                else
                {


                    /*" -496- DISPLAY 'R0800 - ERRO NO SELECT DA GE-ENDOS-COSSEG-COB' */
                    _.Display($"R0800 - ERRO NO SELECT DA GE-ENDOS-COSSEG-COB");

                    /*" -497- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -498- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -499- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -500- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -501- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -502- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -503- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -504- END-IF */
                }


                /*" -504- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-SELECT-GE397-DB-SELECT-1 */
        public void R0800_00_SELECT_GE397_DB_SELECT_1()
        {
            /*" -489- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-QTDE-REG FROM SEGUROS.GE_ENDOS_COSSEG_COBER WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

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
            /*" -517- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WABEND.WNR_EXEC_SQL);

            /*" -545- PERFORM R0900_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0900_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -548- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -549- DISPLAY 'R0900 - ERRO NO SELECT DA ENDOSSOS' */
                _.Display($"R0900 - ERRO NO SELECT DA ENDOSSOS");

                /*" -550- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -551- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -552- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -553- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -554- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -555- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -556- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -557- ELSE */
            }
            else
            {


                /*" -558- ADD 1 TO AC-L-ENDOSSOS */
                AREA_DE_WORK.AC_L_ENDOSSOS.Value = AREA_DE_WORK.AC_L_ENDOSSOS + 1;

                /*" -558- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0900_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -545- EXEC SQL SELECT NUM_APOLICE , NUM_ENDOSSO , RAMO_EMISSOR, COD_PRODUTO , COD_SUBGRUPO, COD_FONTE , DATA_EMISSAO, DATA_INIVIGENCIA, DATA_TERVIGENCIA, COD_MOEDA_IMP, COD_MOEDA_PRM, SIT_REGISTRO INTO :ENDOSSOS-NUM-APOLICE , :ENDOSSOS-NUM-ENDOSSO , :ENDOSSOS-RAMO-EMISSOR, :ENDOSSOS-COD-PRODUTO , :ENDOSSOS-COD-SUBGRUPO, :ENDOSSOS-COD-FONTE , :ENDOSSOS-DATA-EMISSAO, :ENDOSSOS-DATA-INIVIGENCIA, :ENDOSSOS-DATA-TERVIGENCIA, :ENDOSSOS-COD-MOEDA-IMP, :ENDOSSOS-COD-MOEDA-PRM, :ENDOSSOS-SIT-REGISTRO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

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
            /*" -574- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -576- MOVE 'N' TO WTEM-PERI-ABERTO. */
            _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

            /*" -580- IF (ENDOSSOS-NUM-APOLICE = 108208874329 OR 108210933403 OR ENDOSSOS-NUM-APOLICE = 109300000959 OR 109300001670 OR ENDOSSOS-NUM-APOLICE = 109300001819 OR 109300002142 OR ENDOSSOS-NUM-APOLICE = 109300002585 OR 109300002606) */

            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("108208874329", "108210933403") || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("109300000959", "109300001670") || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("109300001819", "109300002142") || ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.In("109300002585", "109300002606")))
            {

                /*" -582- IF (ENDOSSOS-DATA-INIVIGENCIA > '2016-10-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-01-05' ) */

                if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2016-10-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-01-05"))
                {

                    /*" -583- MOVE 'S' TO WTEM-PERI-ABERTO */
                    _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                    /*" -584- ELSE */
                }
                else
                {


                    /*" -585- MOVE 'N' TO WTEM-PERI-ABERTO */
                    _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                    /*" -586- END-IF */
                }


                /*" -587- ELSE */
            }
            else
            {


                /*" -588- IF ENDOSSOS-NUM-APOLICE = 109300002675 */

                if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 109300002675)
                {

                    /*" -590- IF (ENDOSSOS-DATA-INIVIGENCIA > '2016-05-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-01-05' ) */

                    if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2016-05-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-01-05"))
                    {

                        /*" -591- MOVE 'S' TO WTEM-PERI-ABERTO */
                        _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                        /*" -592- ELSE */
                    }
                    else
                    {


                        /*" -593- MOVE 'N' TO WTEM-PERI-ABERTO */
                        _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                        /*" -594- END-IF */
                    }


                    /*" -595- ELSE */
                }
                else
                {


                    /*" -596- IF ENDOSSOS-NUM-APOLICE = 109300002676 */

                    if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 109300002676)
                    {

                        /*" -597- IF ENDOSSOS-DATA-INIVIGENCIA < '2017-05-01' */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-05-01")
                        {

                            /*" -598- MOVE 'S' TO WTEM-PERI-ABERTO */
                            _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                            /*" -599- ELSE */
                        }
                        else
                        {


                            /*" -600- MOVE 'N' TO WTEM-PERI-ABERTO */
                            _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                            /*" -601- END-IF */
                        }


                        /*" -602- ELSE */
                    }
                    else
                    {


                        /*" -603- IF ENDOSSOS-NUM-APOLICE = 109300003432 */

                        if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE == 109300003432)
                        {

                            /*" -607- IF (ENDOSSOS-DATA-INIVIGENCIA > '2015-08-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-01-05' ) OR (ENDOSSOS-DATA-INIVIGENCIA > '2017-08-31' AND ENDOSSOS-DATA-INIVIGENCIA < '2017-11-06' ) */

                            if ((ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2015-08-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-01-05") || (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA > "2017-08-31" && ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA < "2017-11-06"))
                            {

                                /*" -608- MOVE 'S' TO WTEM-PERI-ABERTO */
                                _.Move("S", AREA_DE_WORK.WTEM_PERI_ABERTO);

                                /*" -609- ELSE */
                            }
                            else
                            {


                                /*" -610- MOVE 'N' TO WTEM-PERI-ABERTO */
                                _.Move("N", AREA_DE_WORK.WTEM_PERI_ABERTO);

                                /*" -611- END-IF */
                            }


                            /*" -612- END-IF */
                        }


                        /*" -613- END-IF */
                    }


                    /*" -614- END-IF */
                }


                /*" -614- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-PROCESSA-ENDOSSO-SECTION */
        private void R1100_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -630- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", WABEND.WNR_EXEC_SQL);

            /*" -634- MOVE ZEROS TO PARCELAS-PRM-TARIFARIO-IX PARCELAS-VAL-DESCONTO-IX PARCELAS-ADICIONAL-FRAC-IX. */
            _.Move(0, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);

            /*" -636- PERFORM R1200-00-SELECT-PARCELAS. */

            R1200_00_SELECT_PARCELAS_SECTION();

            /*" -642- COMPUTE WVLR-BASE-COMS = PARCELAS-PRM-TARIFARIO-IX - PARCELAS-VAL-DESCONTO-IX + PARCELAS-ADICIONAL-FRAC-IX. */
            AREA_DE_WORK.WVLR_BASE_COMS.Value = PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX - PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX + PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX;

            /*" -645- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VAR APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -647- PERFORM R1300-00-SELECT-APOLICOB. */

            R1300_00_SELECT_APOLICOB_SECTION();

            /*" -648- MOVE APOLICOB-IMP-SEGURADA-VAR TO WIMP-SEGUR-TOT. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR, AREA_DE_WORK.WIMP_SEGUR_TOT);

            /*" -653- MOVE APOLICOB-PRM-TARIFARIO-VAR TO WPRM-TARIF-TOT. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR, AREA_DE_WORK.WPRM_TARIF_TOT);

            /*" -655- PERFORM R1400-00-DECLARE-APOLCOSS. */

            R1400_00_DECLARE_APOLCOSS_SECTION();

            /*" -657- PERFORM R1500-00-FETCH-APOLCOSS. */

            R1500_00_FETCH_APOLCOSS_SECTION();

            /*" -658- IF WFIM-APOLCOSS = SPACES */

            if (AREA_DE_WORK.WFIM_APOLCOSS.IsEmpty())
            {

                /*" -660- PERFORM R1600-00-PROCESSA-APOLCOSS UNTIL WFIM-APOLCOSS NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_APOLCOSS.IsEmpty()))
                {

                    R1600_00_PROCESSA_APOLCOSS_SECTION();
                }

                /*" -661- ELSE */
            }
            else
            {


                /*" -662- DISPLAY 'R1100 - DISTRIBUICAO DE COSSEGURO INVALIDA' */
                _.Display($"R1100 - DISTRIBUICAO DE COSSEGURO INVALIDA");

                /*" -663- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -664- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -665- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -666- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -667- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -668- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -669- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -670- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -670- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-PARCELAS-SECTION */
        private void R1200_00_SELECT_PARCELAS_SECTION()
        {
            /*" -683- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", WABEND.WNR_EXEC_SQL);

            /*" -693- PERFORM R1200_00_SELECT_PARCELAS_DB_SELECT_1 */

            R1200_00_SELECT_PARCELAS_DB_SELECT_1();

            /*" -696- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -697- DISPLAY 'R1200 - ERRO NO SELECT DA PARCELAS' */
                _.Display($"R1200 - ERRO NO SELECT DA PARCELAS");

                /*" -698- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -699- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -700- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -701- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -702- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -703- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -704- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -705- ELSE */
            }
            else
            {


                /*" -706- MOVE ZEROS TO WVLR-BASE-COMS */
                _.Move(0, AREA_DE_WORK.WVLR_BASE_COMS);

                /*" -706- END-IF. */
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-PARCELAS-DB-SELECT-1 */
        public void R1200_00_SELECT_PARCELAS_DB_SELECT_1()
        {
            /*" -693- EXEC SQL SELECT VALUE(SUM(PRM_TARIFARIO_IX),+0), VALUE(SUM(VAL_DESCONTO_IX),+0), VALUE(SUM(ADICIONAL_FRAC_IX),+0) INTO :PARCELAS-PRM-TARIFARIO-IX, :PARCELAS-VAL-DESCONTO-IX , :PARCELAS-ADICIONAL-FRAC-IX FROM SEGUROS.PARCELAS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO END-EXEC. */

            var r1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1 = new R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_PARCELAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARCELAS_PRM_TARIFARIO_IX, PARCELAS.DCLPARCELAS.PARCELAS_PRM_TARIFARIO_IX);
                _.Move(executed_1.PARCELAS_VAL_DESCONTO_IX, PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX);
                _.Move(executed_1.PARCELAS_ADICIONAL_FRAC_IX, PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-APOLICOB-SECTION */
        private void R1300_00_SELECT_APOLICOB_SECTION()
        {
            /*" -719- MOVE '1300' TO WNR-EXEC-SQL. */
            _.Move("1300", WABEND.WNR_EXEC_SQL);

            /*" -729- PERFORM R1300_00_SELECT_APOLICOB_DB_SELECT_1 */

            R1300_00_SELECT_APOLICOB_DB_SELECT_1();

            /*" -732- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -733- DISPLAY 'R1300 - ERRO NO SELECT DA APOLICE-COBERTURAS' */
                _.Display($"R1300 - ERRO NO SELECT DA APOLICE-COBERTURAS");

                /*" -734- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -735- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -736- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -737- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -738- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -739- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -740- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -741- ELSE */
            }
            else
            {


                /*" -742- MOVE ZEROS TO WIMP-SEGUR-TOT */
                _.Move(0, AREA_DE_WORK.WIMP_SEGUR_TOT);

                /*" -743- MOVE ZEROS TO WPRM-TARIF-TOT */
                _.Move(0, AREA_DE_WORK.WPRM_TARIF_TOT);

                /*" -743- END-IF. */
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-APOLICOB-DB-SELECT-1 */
        public void R1300_00_SELECT_APOLICOB_DB_SELECT_1()
        {
            /*" -729- EXEC SQL SELECT VALUE(SUM(IMP_SEGURADA_VAR),+0), VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :APOLICOB-IMP-SEGURADA-VAR, :APOLICOB-PRM-TARIFARIO-VAR FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :PARCEHIS-NUM-APOLICE AND NUM_ENDOSSO = :PARCEHIS-NUM-ENDOSSO AND NUM_ITEM = 0 AND COD_COBERTURA = 0 END-EXEC. */

            var r1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1 = new R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1()
            {
                PARCEHIS_NUM_APOLICE = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE.ToString(),
                PARCEHIS_NUM_ENDOSSO = PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_APOLICOB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-DECLARE-APOLCOSS-SECTION */
        private void R1400_00_DECLARE_APOLCOSS_SECTION()
        {
            /*" -756- MOVE '1400' TO WNR-EXEC-SQL. */
            _.Move("1400", WABEND.WNR_EXEC_SQL);

            /*" -767- PERFORM R1400_00_DECLARE_APOLCOSS_DB_DECLARE_1 */

            R1400_00_DECLARE_APOLCOSS_DB_DECLARE_1();

            /*" -769- PERFORM R1400_00_DECLARE_APOLCOSS_DB_OPEN_1 */

            R1400_00_DECLARE_APOLCOSS_DB_OPEN_1();

            /*" -772- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -773- DISPLAY 'R1400 - ERRO NO DECLARE DA APOL-COSSSEGURADORA' */
                _.Display($"R1400 - ERRO NO DECLARE DA APOL-COSSSEGURADORA");

                /*" -774- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -775- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -776- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -777- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -778- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -779- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -780- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -781- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -782- ELSE */
            }
            else
            {


                /*" -783- MOVE SPACES TO WFIM-APOLCOSS */
                _.Move("", AREA_DE_WORK.WFIM_APOLCOSS);

                /*" -783- END-IF. */
            }


        }

        [StopWatch]
        /*" R1400-00-DECLARE-APOLCOSS-DB-OPEN-1 */
        public void R1400_00_DECLARE_APOLCOSS_DB_OPEN_1()
        {
            /*" -769- EXEC SQL OPEN C01_APOLCOSS END-EXEC. */

            C01_APOLCOSS.Open();

        }

        [StopWatch]
        /*" R1700-00-DECLARE-GE397-GE398-DB-DECLARE-1 */
        public void R1700_00_DECLARE_GE397_GE398_DB_DECLARE_1()
        {
            /*" -888- EXEC SQL DECLARE COSGCOBER CURSOR FOR SELECT A.NUM_APOLICE, A.NUM_ENDOSSO, A.COD_RAMO_COBER, A.COD_COBERTURA, A.VLR_IMP_SEGUR_VAR, A.VLR_PREMIO_TARIF_VAR, B.COD_COSSEGURADORA, B.PCT_PARTIC_COBER, B.PCT_COMCOS_COBER FROM SEGUROS.GE_ENDOS_COSSEG_COBER A, SEGUROS.GE_ENDOS_PCT_PART_COBER B WHERE A.NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND A.NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND B.NUM_APOLICE = A.NUM_APOLICE AND B.NUM_ENDOSSO = A.NUM_ENDOSSO AND B.COD_RAMO_COBER = A.COD_RAMO_COBER AND B.COD_COBERTURA = A.COD_COBERTURA AND B.COD_COSSEGURADORA = :APOLCOSS-COD-COSSEGURADORA ORDER BY A.COD_RAMO_COBER, A.COD_COBERTURA END-EXEC. */
            COSGCOBER = new AC0006B_COSGCOBER(true);
            string GetQuery_COSGCOBER()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NUM_ENDOSSO
							, 
							A.COD_RAMO_COBER
							, 
							A.COD_COBERTURA
							, 
							A.VLR_IMP_SEGUR_VAR
							, 
							A.VLR_PREMIO_TARIF_VAR
							, 
							B.COD_COSSEGURADORA
							, 
							B.PCT_PARTIC_COBER
							, 
							B.PCT_COMCOS_COBER 
							FROM SEGUROS.GE_ENDOS_COSSEG_COBER A
							, 
							SEGUROS.GE_ENDOS_PCT_PART_COBER B 
							WHERE A.NUM_APOLICE = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE}' 
							AND A.NUM_ENDOSSO = '{ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO}' 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							AND B.NUM_ENDOSSO = A.NUM_ENDOSSO 
							AND B.COD_RAMO_COBER = A.COD_RAMO_COBER 
							AND B.COD_COBERTURA = A.COD_COBERTURA 
							AND B.COD_COSSEGURADORA = '{APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}' 
							ORDER BY 
							A.COD_RAMO_COBER
							, 
							A.COD_COBERTURA";

                return query;
            }
            COSGCOBER.GetQueryEvent += GetQuery_COSGCOBER;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-FETCH-APOLCOSS-SECTION */
        private void R1500_00_FETCH_APOLCOSS_SECTION()
        {
            /*" -796- MOVE '1500' TO WNR-EXEC-SQL. */
            _.Move("1500", WABEND.WNR_EXEC_SQL);

            /*" -799- PERFORM R1500_00_FETCH_APOLCOSS_DB_FETCH_1 */

            R1500_00_FETCH_APOLCOSS_DB_FETCH_1();

            /*" -802- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -803- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -804- MOVE 'S' TO WFIM-APOLCOSS */
                    _.Move("S", AREA_DE_WORK.WFIM_APOLCOSS);

                    /*" -804- PERFORM R1500_00_FETCH_APOLCOSS_DB_CLOSE_1 */

                    R1500_00_FETCH_APOLCOSS_DB_CLOSE_1();

                    /*" -806- ELSE */
                }
                else
                {


                    /*" -807- DISPLAY 'R1500 - ERRO NO FETCH DA APOL-COSSEGURADORA' */
                    _.Display($"R1500 - ERRO NO FETCH DA APOL-COSSEGURADORA");

                    /*" -808- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -809- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -810- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -811- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -812- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -813- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -814- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -815- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -816- END-IF */
                }


                /*" -817- ELSE */
            }
            else
            {


                /*" -818- ADD 1 TO AC-L-APOLCOSS */
                AREA_DE_WORK.AC_L_APOLCOSS.Value = AREA_DE_WORK.AC_L_APOLCOSS + 1;

                /*" -818- END-IF. */
            }


        }

        [StopWatch]
        /*" R1500-00-FETCH-APOLCOSS-DB-FETCH-1 */
        public void R1500_00_FETCH_APOLCOSS_DB_FETCH_1()
        {
            /*" -799- EXEC SQL FETCH C01_APOLCOSS INTO :APOLCOSS-NUM-APOLICE, :APOLCOSS-COD-COSSEGURADORA END-EXEC. */

            if (C01_APOLCOSS.Fetch())
            {
                _.Move(C01_APOLCOSS.APOLCOSS_NUM_APOLICE, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_NUM_APOLICE);
                _.Move(C01_APOLCOSS.APOLCOSS_COD_COSSEGURADORA, APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA);
            }

        }

        [StopWatch]
        /*" R1500-00-FETCH-APOLCOSS-DB-CLOSE-1 */
        public void R1500_00_FETCH_APOLCOSS_DB_CLOSE_1()
        {
            /*" -804- EXEC SQL CLOSE C01_APOLCOSS END-EXEC */

            C01_APOLCOSS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R1600-00-PROCESSA-APOLCOSS-SECTION */
        private void R1600_00_PROCESSA_APOLCOSS_SECTION()
        {
            /*" -831- MOVE '1600' TO WNR-EXEC-SQL. */
            _.Move("1600", WABEND.WNR_EXEC_SQL);

            /*" -833- PERFORM R1700-00-DECLARE-GE397-GE398. */

            R1700_00_DECLARE_GE397_GE398_SECTION();

            /*" -835- PERFORM R1800-00-FETCH-GE397-GE398. */

            R1800_00_FETCH_GE397_GE398_SECTION();

            /*" -836- IF WFIM-GE397-GE398 = SPACES */

            if (AREA_DE_WORK.WFIM_GE397_GE398.IsEmpty())
            {

                /*" -838- PERFORM R2000-00-PROCESSA-PROPORCAO UNTIL WFIM-GE397-GE398 NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_GE397_GE398.IsEmpty()))
                {

                    R2000_00_PROCESSA_PROPORCAO_SECTION();
                }

                /*" -839- ELSE */
            }
            else
            {


                /*" -840- DISPLAY 'R1600 - NAO EXISTE COSSEG CED PARA A CIA CONG' */
                _.Display($"R1600 - NAO EXISTE COSSEG CED PARA A CIA CONG");

                /*" -841- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -842- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -843- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -844- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -845- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -846- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -847- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -848- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -849- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -853- END-IF. */
            }


            /*" -853- PERFORM R1500-00-FETCH-APOLCOSS. */

            R1500_00_FETCH_APOLCOSS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1600_99_SAIDA*/

        [StopWatch]
        /*" R1700-00-DECLARE-GE397-GE398-SECTION */
        private void R1700_00_DECLARE_GE397_GE398_SECTION()
        {
            /*" -866- MOVE '1700' TO WNR-EXEC-SQL. */
            _.Move("1700", WABEND.WNR_EXEC_SQL);

            /*" -888- PERFORM R1700_00_DECLARE_GE397_GE398_DB_DECLARE_1 */

            R1700_00_DECLARE_GE397_GE398_DB_DECLARE_1();

            /*" -890- PERFORM R1700_00_DECLARE_GE397_GE398_DB_OPEN_1 */

            R1700_00_DECLARE_GE397_GE398_DB_OPEN_1();

            /*" -893- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -894- DISPLAY 'R1700 - ERRO NO DECLARE DA GE397-JOIN-GE398' */
                _.Display($"R1700 - ERRO NO DECLARE DA GE397-JOIN-GE398");

                /*" -895- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -896- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -897- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -898- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -899- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -900- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -901- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -902- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -903- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -904- ELSE */
            }
            else
            {


                /*" -905- MOVE SPACES TO WFIM-GE397-GE398 */
                _.Move("", AREA_DE_WORK.WFIM_GE397_GE398);

                /*" -905- END-IF. */
            }


        }

        [StopWatch]
        /*" R1700-00-DECLARE-GE397-GE398-DB-OPEN-1 */
        public void R1700_00_DECLARE_GE397_GE398_DB_OPEN_1()
        {
            /*" -890- EXEC SQL OPEN COSGCOBER END-EXEC. */

            COSGCOBER.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1700_99_SAIDA*/

        [StopWatch]
        /*" R1800-00-FETCH-GE397-GE398-SECTION */
        private void R1800_00_FETCH_GE397_GE398_SECTION()
        {
            /*" -918- MOVE '1800' TO WNR-EXEC-SQL. */
            _.Move("1800", WABEND.WNR_EXEC_SQL);

            /*" -928- PERFORM R1800_00_FETCH_GE397_GE398_DB_FETCH_1 */

            R1800_00_FETCH_GE397_GE398_DB_FETCH_1();

            /*" -931- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -932- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -933- MOVE 'S' TO WFIM-GE397-GE398 */
                    _.Move("S", AREA_DE_WORK.WFIM_GE397_GE398);

                    /*" -933- PERFORM R1800_00_FETCH_GE397_GE398_DB_CLOSE_1 */

                    R1800_00_FETCH_GE397_GE398_DB_CLOSE_1();

                    /*" -935- ELSE */
                }
                else
                {


                    /*" -936- DISPLAY 'R1800 - ERRO NO FETCH DA GE397-JOIN-GE398' */
                    _.Display($"R1800 - ERRO NO FETCH DA GE397-JOIN-GE398");

                    /*" -937- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                    _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                    /*" -938- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                    _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                    /*" -939- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                    _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                    /*" -940- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                    _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                    /*" -941- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                    _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                    /*" -942- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                    _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                    /*" -943- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                    _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                    /*" -944- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                    _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                    /*" -945- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -946- END-IF */
                }


                /*" -947- ELSE */
            }
            else
            {


                /*" -948- ADD 1 TO AC-L-GE397-GE398 */
                AREA_DE_WORK.AC_L_GE397_GE398.Value = AREA_DE_WORK.AC_L_GE397_GE398 + 1;

                /*" -948- END-IF. */
            }


        }

        [StopWatch]
        /*" R1800-00-FETCH-GE397-GE398-DB-FETCH-1 */
        public void R1800_00_FETCH_GE397_GE398_DB_FETCH_1()
        {
            /*" -928- EXEC SQL FETCH COSGCOBER INTO :GE397-NUM-APOLICE, :GE397-NUM-ENDOSSO, :GE397-COD-RAMO-COBER, :GE397-COD-COBERTURA, :GE397-VLR-IMP-SEGUR-VAR, :GE397-VLR-PREMIO-TARIF-VAR, :GE398-COD-COSSEGURADORA, :GE398-PCT-PARTIC-COBER, :GE398-PCT-COMCOS-COBER END-EXEC. */

            if (COSGCOBER.Fetch())
            {
                _.Move(COSGCOBER.GE397_NUM_APOLICE, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NUM_APOLICE);
                _.Move(COSGCOBER.GE397_NUM_ENDOSSO, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_NUM_ENDOSSO);
                _.Move(COSGCOBER.GE397_COD_RAMO_COBER, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER);
                _.Move(COSGCOBER.GE397_COD_COBERTURA, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_COBERTURA);
                _.Move(COSGCOBER.GE397_VLR_IMP_SEGUR_VAR, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_IMP_SEGUR_VAR);
                _.Move(COSGCOBER.GE397_VLR_PREMIO_TARIF_VAR, GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_PREMIO_TARIF_VAR);
                _.Move(COSGCOBER.GE398_COD_COSSEGURADORA, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_COD_COSSEGURADORA);
                _.Move(COSGCOBER.GE398_PCT_PARTIC_COBER, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_PARTIC_COBER);
                _.Move(COSGCOBER.GE398_PCT_COMCOS_COBER, GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_COMCOS_COBER);
            }

        }

        [StopWatch]
        /*" R1800-00-FETCH-GE397-GE398-DB-CLOSE-1 */
        public void R1800_00_FETCH_GE397_GE398_DB_CLOSE_1()
        {
            /*" -933- EXEC SQL CLOSE COSGCOBER END-EXEC */

            COSGCOBER.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1800_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-PROPORCAO-SECTION */
        private void R2000_00_PROCESSA_PROPORCAO_SECTION()
        {
            /*" -964- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -967- MOVE ZEROS TO APOLICOB-IMP-SEGURADA-VAR APOLICOB-PRM-TARIFARIO-VAR. */
            _.Move(0, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);

            /*" -969- PERFORM R2100-00-SELECT-APOLCOB-RMO. */

            R2100_00_SELECT_APOLCOB_RMO_SECTION();

            /*" -970- MOVE APOLICOB-IMP-SEGURADA-VAR TO WIMP-SEGUR-RMO. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR, AREA_DE_WORK.WIMP_SEGUR_RMO);

            /*" -974- MOVE APOLICOB-PRM-TARIFARIO-VAR TO WPRM-TARIF-RMO. */
            _.Move(APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR, AREA_DE_WORK.WPRM_TARIF_RMO);

            /*" -978- MOVE ZEROS TO WIMP-SEG-CED-RMO WPRM-TAR-CED-RMO WVLR-COMCOSG-RMO. */
            _.Move(0, AREA_DE_WORK.WIMP_SEG_CED_RMO, AREA_DE_WORK.WPRM_TAR_CED_RMO, AREA_DE_WORK.WVLR_COMCOSG_RMO);

            /*" -980- MOVE GE397-COD-RAMO-COBER TO WCOD-RAMO-ANT. */
            _.Move(GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER, AREA_DE_WORK.WCOD_RAMO_ANT);

            /*" -987- PERFORM R2200-00-CALCULA-COSG-CEDIDO UNTIL WFIM-GE397-GE398 NOT EQUAL SPACES OR GE397-COD-RAMO-COBER NOT EQUAL WCOD-RAMO-ANT. */

            while (!(!AREA_DE_WORK.WFIM_GE397_GE398.IsEmpty() || GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER != AREA_DE_WORK.WCOD_RAMO_ANT))
            {

                R2200_00_CALCULA_COSG_CEDIDO_SECTION();
            }

            /*" -992- MOVE ZEROS TO WPCT-PROP-RMO-IS WPCT-PROP-TOT-IS WPCT-PROP-RMO-PR WPCT-PROP-TOT-PR. */
            _.Move(0, AREA_DE_WORK.WPCT_PROP_RMO_IS, AREA_DE_WORK.WPCT_PROP_TOT_IS, AREA_DE_WORK.WPCT_PROP_RMO_PR, AREA_DE_WORK.WPCT_PROP_TOT_PR);

            /*" -993- IF WIMP-SEGUR-RMO = ZEROS */

            if (AREA_DE_WORK.WIMP_SEGUR_RMO == 00)
            {

                /*" -994- MOVE ZEROS TO WPCT-PROP-RMO-IS */
                _.Move(0, AREA_DE_WORK.WPCT_PROP_RMO_IS);

                /*" -995- ELSE */
            }
            else
            {


                /*" -999- COMPUTE WPCT-PROP-RMO-IS ROUNDED = (WIMP-SEG-CED-RMO * 100) / WIMP-SEGUR-RMO ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-RMO-IS END-COMPUTE */
                if (AREA_DE_WORK.WIMP_SEGUR_RMO.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCT_PROP_RMO_IS);
                else

                    AREA_DE_WORK.WPCT_PROP_RMO_IS.Value = (AREA_DE_WORK.WIMP_SEG_CED_RMO * 100) / AREA_DE_WORK.WIMP_SEGUR_RMO;

                /*" -1001- END-IF. */
            }


            /*" -1002- IF WIMP-SEGUR-TOT = ZEROS */

            if (AREA_DE_WORK.WIMP_SEGUR_TOT == 00)
            {

                /*" -1003- MOVE ZEROS TO WPCT-PROP-TOT-IS */
                _.Move(0, AREA_DE_WORK.WPCT_PROP_TOT_IS);

                /*" -1004- ELSE */
            }
            else
            {


                /*" -1008- COMPUTE WPCT-PROP-TOT-IS ROUNDED = (WIMP-SEG-CED-RMO * 100) / WIMP-SEGUR-TOT ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-TOT-IS END-COMPUTE */
                if (AREA_DE_WORK.WIMP_SEGUR_TOT.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCT_PROP_TOT_IS);
                else

                    AREA_DE_WORK.WPCT_PROP_TOT_IS.Value = (AREA_DE_WORK.WIMP_SEG_CED_RMO * 100) / AREA_DE_WORK.WIMP_SEGUR_TOT;

                /*" -1010- END-IF. */
            }


            /*" -1011- IF WPRM-TARIF-RMO = ZEROS */

            if (AREA_DE_WORK.WPRM_TARIF_RMO == 00)
            {

                /*" -1012- MOVE ZEROS TO WPCT-PROP-RMO-PR */
                _.Move(0, AREA_DE_WORK.WPCT_PROP_RMO_PR);

                /*" -1013- ELSE */
            }
            else
            {


                /*" -1017- COMPUTE WPCT-PROP-RMO-PR ROUNDED = (WPRM-TAR-CED-RMO * 100) / WPRM-TARIF-RMO ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-RMO-PR END-COMPUTE */
                if (AREA_DE_WORK.WPRM_TARIF_RMO.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCT_PROP_RMO_PR);
                else

                    AREA_DE_WORK.WPCT_PROP_RMO_PR.Value = (AREA_DE_WORK.WPRM_TAR_CED_RMO * 100) / AREA_DE_WORK.WPRM_TARIF_RMO;

                /*" -1019- END-IF. */
            }


            /*" -1020- IF WPRM-TARIF-TOT = ZEROS */

            if (AREA_DE_WORK.WPRM_TARIF_TOT == 00)
            {

                /*" -1021- MOVE ZEROS TO WPCT-PROP-TOT-PR */
                _.Move(0, AREA_DE_WORK.WPCT_PROP_TOT_PR);

                /*" -1022- ELSE */
            }
            else
            {


                /*" -1026- COMPUTE WPCT-PROP-TOT-PR ROUNDED = (WPRM-TAR-CED-RMO * 100) / WPRM-TARIF-TOT ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-TOT-PR END-COMPUTE */
                if (AREA_DE_WORK.WPRM_TARIF_TOT.Value == 0)
                    _.Move(0, AREA_DE_WORK.WPCT_PROP_TOT_PR);
                else

                    AREA_DE_WORK.WPCT_PROP_TOT_PR.Value = (AREA_DE_WORK.WPRM_TAR_CED_RMO * 100) / AREA_DE_WORK.WPRM_TARIF_TOT;

                /*" -1031- END-IF. */
            }


            /*" -1034- MOVE ZEROS TO WPCT-PROP-COM-RMO WPCT-PROP-COM-TOT. */
            _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_RMO, AREA_DE_WORK.WPCT_PROP_COM_TOT);

            /*" -1035- IF WVLR-COMCOSG-RMO = ZEROS */

            if (AREA_DE_WORK.WVLR_COMCOSG_RMO == 00)
            {

                /*" -1036- MOVE ZEROS TO WPCT-PROP-COM-RMO */
                _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_RMO);

                /*" -1037- ELSE */
            }
            else
            {


                /*" -1039- IF PARCELAS-VAL-DESCONTO-IX = ZEROS AND PARCELAS-ADICIONAL-FRAC-IX = ZEROS */

                if (PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX == 00 && PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX == 00)
                {

                    /*" -1043- COMPUTE WPCT-PROP-COM-RMO ROUNDED = (WVLR-COMCOSG-RMO * 100) / WPRM-TARIF-RMO ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-COM-RMO END-COMPUTE */
                    if (AREA_DE_WORK.WPRM_TARIF_RMO.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_RMO);
                    else

                        AREA_DE_WORK.WPCT_PROP_COM_RMO.Value = (AREA_DE_WORK.WVLR_COMCOSG_RMO * 100) / AREA_DE_WORK.WPRM_TARIF_RMO;

                    /*" -1044- ELSE */
                }
                else
                {


                    /*" -1050- COMPUTE WPCT-PROP-COM-RMO ROUNDED = (WVLR-COMCOSG-RMO * 100) / (WVLR-BASE-COMS * (WPRM-TARIF-RMO / WPRM-TARIF-TOT)) ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-COM-RMO END-COMPUTE */
                    if (AREA_DE_WORK.WVLR_BASE_COMS.Value == 0 || AREA_DE_WORK.WPRM_TARIF_RMO.Value == 0 || AREA_DE_WORK.WPRM_TARIF_TOT.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_RMO);
                    else

                        AREA_DE_WORK.WPCT_PROP_COM_RMO.Value = (AREA_DE_WORK.WVLR_COMCOSG_RMO * 100) / (AREA_DE_WORK.WVLR_BASE_COMS * (AREA_DE_WORK.WPRM_TARIF_RMO / AREA_DE_WORK.WPRM_TARIF_TOT));

                    /*" -1051- END-IF */
                }


                /*" -1053- END-IF. */
            }


            /*" -1054- IF WVLR-COMCOSG-RMO = ZEROS */

            if (AREA_DE_WORK.WVLR_COMCOSG_RMO == 00)
            {

                /*" -1055- MOVE ZEROS TO WPCT-PROP-COM-TOT */
                _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_TOT);

                /*" -1056- ELSE */
            }
            else
            {


                /*" -1058- IF PARCELAS-VAL-DESCONTO-IX = ZEROS AND PARCELAS-ADICIONAL-FRAC-IX = ZEROS */

                if (PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX == 00 && PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX == 00)
                {

                    /*" -1062- COMPUTE WPCT-PROP-COM-TOT ROUNDED = (WVLR-COMCOSG-RMO * 100) / WPRM-TARIF-TOT ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-COM-TOT END-COMPUTE */
                    if (AREA_DE_WORK.WPRM_TARIF_TOT.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_TOT);
                    else

                        AREA_DE_WORK.WPCT_PROP_COM_TOT.Value = (AREA_DE_WORK.WVLR_COMCOSG_RMO * 100) / AREA_DE_WORK.WPRM_TARIF_TOT;

                    /*" -1063- ELSE */
                }
                else
                {


                    /*" -1067- COMPUTE WPCT-PROP-COM-TOT ROUNDED = (WVLR-COMCOSG-RMO * 100) / WVLR-BASE-COMS ON SIZE ERROR MOVE ZEROS TO WPCT-PROP-COM-TOT END-COMPUTE */
                    if (AREA_DE_WORK.WVLR_BASE_COMS.Value == 0)
                        _.Move(0, AREA_DE_WORK.WPCT_PROP_COM_TOT);
                    else

                        AREA_DE_WORK.WPCT_PROP_COM_TOT.Value = (AREA_DE_WORK.WVLR_COMCOSG_RMO * 100) / AREA_DE_WORK.WVLR_BASE_COMS;

                    /*" -1068- END-IF */
                }


                /*" -1072- END-IF. */
            }


            /*" -1074- INITIALIZE DCLGE-ENDOS-RAMO-VLR-COSSEG. */
            _.Initialize(
                GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG
            );

            /*" -1075- MOVE ENDOSSOS-NUM-APOLICE TO GE399-NUM-APOLICE. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_APOLICE);

            /*" -1077- MOVE ENDOSSOS-NUM-ENDOSSO TO GE399-NUM-ENDOSSO. */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_ENDOSSO);

            /*" -1079- MOVE WCOD-RAMO-ANT TO GE399-COD-RAMO-COBER. */
            _.Move(AREA_DE_WORK.WCOD_RAMO_ANT, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_RAMO_COBER);

            /*" -1082- MOVE APOLCOSS-COD-COSSEGURADORA TO GE399-COD-COSSEGURADORA. */
            _.Move(APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_COSSEGURADORA);

            /*" -1083- MOVE WIMP-SEG-CED-RMO TO GE399-VLR-IMPSEG-CED-VAR. */
            _.Move(AREA_DE_WORK.WIMP_SEG_CED_RMO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_IMPSEG_CED_VAR);

            /*" -1084- MOVE WPCT-PROP-RMO-IS TO GE399-PCT-PROP-RAMO-IS. */
            _.Move(AREA_DE_WORK.WPCT_PROP_RMO_IS, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_RAMO_IS);

            /*" -1086- MOVE WPCT-PROP-TOT-IS TO GE399-PCT-PROP-TOTAL-IS. */
            _.Move(AREA_DE_WORK.WPCT_PROP_TOT_IS, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_IS);

            /*" -1087- MOVE WPRM-TAR-CED-RMO TO GE399-VLR-PRMTAR-CED-VAR. */
            _.Move(AREA_DE_WORK.WPRM_TAR_CED_RMO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_PRMTAR_CED_VAR);

            /*" -1088- MOVE WPCT-PROP-RMO-PR TO GE399-PCT-PROP-RAMO-PR. */
            _.Move(AREA_DE_WORK.WPCT_PROP_RMO_PR, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_RAMO_PR);

            /*" -1090- MOVE WPCT-PROP-TOT-PR TO GE399-PCT-PROP-TOTAL-PR. */
            _.Move(AREA_DE_WORK.WPCT_PROP_TOT_PR, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_PR);

            /*" -1091- MOVE WVLR-COMCOSG-RMO TO GE399-VLR-COMCOS-RAMO. */
            _.Move(AREA_DE_WORK.WVLR_COMCOSG_RMO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_COMCOS_RAMO);

            /*" -1092- MOVE WPCT-PROP-COM-RMO TO GE399-PCT-PROP-COM-RAMO. */
            _.Move(AREA_DE_WORK.WPCT_PROP_COM_RMO, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_RAMO);

            /*" -1094- MOVE WPCT-PROP-COM-TOT TO GE399-PCT-PROP-COM-TOTAL. */
            _.Move(AREA_DE_WORK.WPCT_PROP_COM_TOT, GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_TOTAL);

            /*" -1098- MOVE 'AC0006B ' TO GE399-NOM-PROGRAMA. */
            _.Move("AC0006B ", GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NOM_PROGRAMA);

            /*" -1098- PERFORM R2500-00-INSERT-GE399. */

            R2500_00_INSERT_GE399_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-APOLCOB-RMO-SECTION */
        private void R2100_00_SELECT_APOLCOB_RMO_SECTION()
        {
            /*" -1111- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WABEND.WNR_EXEC_SQL);

            /*" -1122- PERFORM R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1 */

            R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1();

            /*" -1125- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1126- DISPLAY 'R2100 - ERRO NO SELECT DA APOLICE-COBERTURAS' */
                _.Display($"R2100 - ERRO NO SELECT DA APOLICE-COBERTURAS");

                /*" -1127- DISPLAY 'APOLICE  - ' PARCEHIS-NUM-APOLICE */
                _.Display($"APOLICE  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_APOLICE}");

                /*" -1128- DISPLAY 'ENDOSSO  - ' PARCEHIS-NUM-ENDOSSO */
                _.Display($"ENDOSSO  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_ENDOSSO}");

                /*" -1129- DISPLAY 'PARCELA  - ' PARCEHIS-NUM-PARCELA */
                _.Display($"PARCELA  - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_NUM_PARCELA}");

                /*" -1130- DISPLAY 'DT MOVTO - ' PARCEHIS-DATA-MOVIMENTO */
                _.Display($"DT MOVTO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_DATA_MOVIMENTO}");

                /*" -1131- DISPLAY 'OPERACAO - ' PARCEHIS-COD-OPERACAO */
                _.Display($"OPERACAO - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_COD_OPERACAO}");

                /*" -1132- DISPLAY 'OCR HIST - ' PARCEHIS-OCORR-HISTORICO */
                _.Display($"OCR HIST - {PARCEHIS.DCLPARCELA_HISTORICO.PARCEHIS_OCORR_HISTORICO}");

                /*" -1133- DISPLAY 'INI VIGC - ' ENDOSSOS-DATA-INIVIGENCIA */
                _.Display($"INI VIGC - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA}");

                /*" -1134- DISPLAY 'COD COSG - ' APOLCOSS-COD-COSSEGURADORA */
                _.Display($"COD COSG - {APOLCOSS.DCLAPOL_COSSEGURADORA.APOLCOSS_COD_COSSEGURADORA}");

                /*" -1135- DISPLAY 'RAMO COB - ' GE397-COD-RAMO-COBER */
                _.Display($"RAMO COB - {GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER}");

                /*" -1136- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1137- ELSE */
            }
            else
            {


                /*" -1138- MOVE ZEROS TO WIMP-SEGUR-RMO */
                _.Move(0, AREA_DE_WORK.WIMP_SEGUR_RMO);

                /*" -1139- MOVE ZEROS TO WPRM-TARIF-RMO */
                _.Move(0, AREA_DE_WORK.WPRM_TARIF_RMO);

                /*" -1139- END-IF. */
            }


        }

        [StopWatch]
        /*" R2100-00-SELECT-APOLCOB-RMO-DB-SELECT-1 */
        public void R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1()
        {
            /*" -1122- EXEC SQL SELECT VALUE(SUM(IMP_SEGURADA_VAR),+0), VALUE(SUM(PRM_TARIFARIO_VAR),+0) INTO :APOLICOB-IMP-SEGURADA-VAR, :APOLICOB-PRM-TARIFARIO-VAR FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :ENDOSSOS-NUM-APOLICE AND NUM_ENDOSSO = :ENDOSSOS-NUM-ENDOSSO AND RAMO_COBERTURA = :GE397-COD-RAMO-COBER AND NUM_ITEM = 0 AND COD_COBERTURA = 0 END-EXEC. */

            var r2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1 = new R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_NUM_APOLICE = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.ToString(),
                ENDOSSOS_NUM_ENDOSSO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.ToString(),
                GE397_COD_RAMO_COBER = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_COD_RAMO_COBER.ToString(),
            };

            var executed_1 = R2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_APOLCOB_RMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICOB_IMP_SEGURADA_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_IMP_SEGURADA_VAR);
                _.Move(executed_1.APOLICOB_PRM_TARIFARIO_VAR, APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_PRM_TARIFARIO_VAR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-CALCULA-COSG-CEDIDO-SECTION */
        private void R2200_00_CALCULA_COSG_CEDIDO_SECTION()
        {
            /*" -1155- MOVE '2200' TO WNR-EXEC-SQL. */
            _.Move("2200", WABEND.WNR_EXEC_SQL);

            /*" -1159- MOVE ZEROS TO WPRM-TARIF-AUX WIMP-SEG-CED-COB WPRM-TAR-CED-COB. */
            _.Move(0, AREA_DE_WORK.WPRM_TARIF_AUX, AREA_DE_WORK.WIMP_SEG_CED_COB, AREA_DE_WORK.WPRM_TAR_CED_COB);

            /*" -1162- COMPUTE WIMP-SEG-CED-COB = GE397-VLR-IMP-SEGUR-VAR * GE398-PCT-PARTIC-COBER / 100. */
            AREA_DE_WORK.WIMP_SEG_CED_COB.Value = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_IMP_SEGUR_VAR * GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_PARTIC_COBER / 100f;

            /*" -1164- ADD WIMP-SEG-CED-COB TO WIMP-SEG-CED-RMO. */
            AREA_DE_WORK.WIMP_SEG_CED_RMO.Value = AREA_DE_WORK.WIMP_SEG_CED_RMO + AREA_DE_WORK.WIMP_SEG_CED_COB;

            /*" -1170- COMPUTE WPRM-TAR-CED-COB = GE397-VLR-PREMIO-TARIF-VAR * GE398-PCT-PARTIC-COBER / 100. */
            AREA_DE_WORK.WPRM_TAR_CED_COB.Value = GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_PREMIO_TARIF_VAR * GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_PARTIC_COBER / 100f;

            /*" -1171- IF ENDOSSOS-COD-MOEDA-PRM = 01 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM == 01)
            {

                /*" -1172- COMPUTE WPRM-TARIF-AUX ROUNDED = WPRM-TAR-CED-COB * 1 */
                AREA_DE_WORK.WPRM_TARIF_AUX.Value = AREA_DE_WORK.WPRM_TAR_CED_COB * 1;

                /*" -1173- ADD WPRM-TARIF-AUX TO WPRM-TAR-CED-RMO */
                AREA_DE_WORK.WPRM_TAR_CED_RMO.Value = AREA_DE_WORK.WPRM_TAR_CED_RMO + AREA_DE_WORK.WPRM_TARIF_AUX;

                /*" -1174- ELSE */
            }
            else
            {


                /*" -1175- ADD WPRM-TAR-CED-COB TO WPRM-TAR-CED-RMO */
                AREA_DE_WORK.WPRM_TAR_CED_RMO.Value = AREA_DE_WORK.WPRM_TAR_CED_RMO + AREA_DE_WORK.WPRM_TAR_CED_COB;

                /*" -1180- END-IF. */
            }


            /*" -1183- MOVE ZEROS TO WCOM-COSEG-AUX WVLR-COMCOSG-COB. */
            _.Move(0, AREA_DE_WORK.WCOM_COSEG_AUX, AREA_DE_WORK.WVLR_COMCOSG_COB);

            /*" -1185- IF PARCELAS-VAL-DESCONTO-IX = ZEROS AND PARCELAS-ADICIONAL-FRAC-IX = ZEROS */

            if (PARCELAS.DCLPARCELAS.PARCELAS_VAL_DESCONTO_IX == 00 && PARCELAS.DCLPARCELAS.PARCELAS_ADICIONAL_FRAC_IX == 00)
            {

                /*" -1187- COMPUTE WVLR-COMCOSG-COB = WPRM-TAR-CED-COB * GE398-PCT-COMCOS-COBER / 100 */
                AREA_DE_WORK.WVLR_COMCOSG_COB.Value = AREA_DE_WORK.WPRM_TAR_CED_COB * GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_COMCOS_COBER / 100f;

                /*" -1188- ELSE */
            }
            else
            {


                /*" -1190- IF WPRM-TARIF-TOT = ZEROS AND WVLR-BASE-COMS = ZEROS */

                if (AREA_DE_WORK.WPRM_TARIF_TOT == 00 && AREA_DE_WORK.WVLR_BASE_COMS == 00)
                {

                    /*" -1191- MOVE ZEROS TO WVLR-COMCOSG-COB */
                    _.Move(0, AREA_DE_WORK.WVLR_COMCOSG_COB);

                    /*" -1192- ELSE */
                }
                else
                {


                    /*" -1197- COMPUTE WVLR-COMCOSG-COB = (WVLR-BASE-COMS * (GE397-VLR-PREMIO-TARIF-VAR / WPRM-TARIF-TOT)) * GE398-PCT-COMCOS-COBER / 100 */
                    AREA_DE_WORK.WVLR_COMCOSG_COB.Value = (AREA_DE_WORK.WVLR_BASE_COMS * (GE397.DCLGE_ENDOS_COSSEG_COBER.GE397_VLR_PREMIO_TARIF_VAR / AREA_DE_WORK.WPRM_TARIF_TOT)) * GE398.DCLGE_ENDOS_PCT_PART_COBER.GE398_PCT_COMCOS_COBER / 100f;

                    /*" -1198- END-IF */
                }


                /*" -1203- END-IF. */
            }


            /*" -1204- IF ENDOSSOS-COD-MOEDA-PRM = 01 */

            if (ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_MOEDA_PRM == 01)
            {

                /*" -1205- COMPUTE WCOM-COSEG-AUX ROUNDED = WVLR-COMCOSG-COB * 1 */
                AREA_DE_WORK.WCOM_COSEG_AUX.Value = AREA_DE_WORK.WVLR_COMCOSG_COB * 1;

                /*" -1206- ADD WCOM-COSEG-AUX TO WVLR-COMCOSG-RMO */
                AREA_DE_WORK.WVLR_COMCOSG_RMO.Value = AREA_DE_WORK.WVLR_COMCOSG_RMO + AREA_DE_WORK.WCOM_COSEG_AUX;

                /*" -1207- ELSE */
            }
            else
            {


                /*" -1208- ADD WVLR-COMCOSG-COB TO WVLR-COMCOSG-RMO */
                AREA_DE_WORK.WVLR_COMCOSG_RMO.Value = AREA_DE_WORK.WVLR_COMCOSG_RMO + AREA_DE_WORK.WVLR_COMCOSG_COB;

                /*" -1212- END-IF. */
            }


            /*" -1212- PERFORM R1800-00-FETCH-GE397-GE398. */

            R1800_00_FETCH_GE397_GE398_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-INSERT-GE399-SECTION */
        private void R2500_00_INSERT_GE399_SECTION()
        {
            /*" -1225- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WABEND.WNR_EXEC_SQL);

            /*" -1242- PERFORM R2500_00_INSERT_GE399_DB_INSERT_1 */

            R2500_00_INSERT_GE399_DB_INSERT_1();

            /*" -1245- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1246- DISPLAY 'R2500 - ERRO NO INSERT DA GE-ENDS-RAMO-VLR-COSG' */
                _.Display($"R2500 - ERRO NO INSERT DA GE-ENDS-RAMO-VLR-COSG");

                /*" -1247- DISPLAY 'APOLICE    - ' GE399-NUM-APOLICE */
                _.Display($"APOLICE    - {GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_APOLICE}");

                /*" -1248- DISPLAY 'ENDOSSO    - ' GE399-NUM-ENDOSSO */
                _.Display($"ENDOSSO    - {GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_ENDOSSO}");

                /*" -1249- DISPLAY 'RAMO COBER - ' GE399-COD-RAMO-COBER */
                _.Display($"RAMO COBER - {GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_RAMO_COBER}");

                /*" -1250- DISPLAY 'COD COSSEG - ' GE399-COD-COSSEGURADORA */
                _.Display($"COD COSSEG - {GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_COSSEGURADORA}");

                /*" -1251- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1252- ELSE */
            }
            else
            {


                /*" -1253- ADD 1 TO AC-I-GE399 */
                AREA_DE_WORK.AC_I_GE399.Value = AREA_DE_WORK.AC_I_GE399 + 1;

                /*" -1253- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-INSERT-GE399-DB-INSERT-1 */
        public void R2500_00_INSERT_GE399_DB_INSERT_1()
        {
            /*" -1242- EXEC SQL INSERT INTO SEGUROS.GE_ENDOS_RAMO_VLR_COSSEG VALUES (:GE399-NUM-APOLICE , :GE399-NUM-ENDOSSO , :GE399-COD-RAMO-COBER , :GE399-COD-COSSEGURADORA , :GE399-VLR-IMPSEG-CED-VAR, :GE399-PCT-PROP-RAMO-IS , :GE399-PCT-PROP-TOTAL-IS , :GE399-VLR-PRMTAR-CED-VAR, :GE399-PCT-PROP-RAMO-PR , :GE399-PCT-PROP-TOTAL-PR , :GE399-VLR-COMCOS-RAMO , :GE399-PCT-PROP-COM-RAMO , :GE399-PCT-PROP-COM-TOTAL, :GE399-NOM-PROGRAMA , CURRENT TIMESTAMP) END-EXEC. */

            var r2500_00_INSERT_GE399_DB_INSERT_1_Insert1 = new R2500_00_INSERT_GE399_DB_INSERT_1_Insert1()
            {
                GE399_NUM_APOLICE = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_APOLICE.ToString(),
                GE399_NUM_ENDOSSO = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NUM_ENDOSSO.ToString(),
                GE399_COD_RAMO_COBER = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_RAMO_COBER.ToString(),
                GE399_COD_COSSEGURADORA = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_COD_COSSEGURADORA.ToString(),
                GE399_VLR_IMPSEG_CED_VAR = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_IMPSEG_CED_VAR.ToString(),
                GE399_PCT_PROP_RAMO_IS = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_RAMO_IS.ToString(),
                GE399_PCT_PROP_TOTAL_IS = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_IS.ToString(),
                GE399_VLR_PRMTAR_CED_VAR = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_PRMTAR_CED_VAR.ToString(),
                GE399_PCT_PROP_RAMO_PR = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_RAMO_PR.ToString(),
                GE399_PCT_PROP_TOTAL_PR = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_TOTAL_PR.ToString(),
                GE399_VLR_COMCOS_RAMO = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_VLR_COMCOS_RAMO.ToString(),
                GE399_PCT_PROP_COM_RAMO = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_RAMO.ToString(),
                GE399_PCT_PROP_COM_TOTAL = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_PCT_PROP_COM_TOTAL.ToString(),
                GE399_NOM_PROGRAMA = GE399.DCLGE_ENDOS_RAMO_VLR_COSSEG.GE399_NOM_PROGRAMA.ToString(),
            };

            R2500_00_INSERT_GE399_DB_INSERT_1_Insert1.Execute(r2500_00_INSERT_GE399_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -1266- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-AUX. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WDATA_AUX);

            /*" -1267- MOVE WDAT-DIA-AUX TO WDAT-DIA-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_DIA_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_DIA_EDT);

            /*" -1268- MOVE WDAT-MES-AUX TO WDAT-MES-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_MES_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_MES_EDT);

            /*" -1270- MOVE WDAT-ANO-AUX TO WDAT-ANO-EDT. */
            _.Move(AREA_DE_WORK.WDATA_AUX_R.WDAT_ANO_AUX, AREA_DE_WORK.WDATA_EDIT.WDAT_ANO_EDT);

            /*" -1271- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -1272- DISPLAY '*   AC0006B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0006B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -1273- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -1274- DISPLAY '*             COSSEGURO CEDIDO             *' . */
            _.Display($"*             COSSEGURO CEDIDO             *");

            /*" -1275- DISPLAY '*             --------- ------             *' . */
            _.Display($"*             --------- ------             *");

            /*" -1276- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -1277- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -1279- DISPLAY '*              ' WDATA-EDIT '                    *' . */

            $"*              {AREA_DE_WORK.WDATA_EDIT}                    *"
            .Display();

            /*" -1279- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1294- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1296- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1296- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1300- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1300- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}