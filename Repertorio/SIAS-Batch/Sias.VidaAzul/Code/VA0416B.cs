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
using Sias.VidaAzul.DB2.VA0416B;

namespace Code
{
    public class VA0416B
    {
        public bool IsCall { get; set; }

        public VA0416B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   INCLUI NA V0HISTCONTABILVA TODAS AS PARCELAS PENDENTES NO    *      */
        /*"      * MOMENTO DO FATURAMENTO DO MULTIPREMIADO EXCETO PARA SAUDE      *      */
        /*"      * E APOLICES FENAM.                                              *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  06/08/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0808                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *     06     *  18/06/02  * M MESSIAS    * ZERA OS ENDOSSOS PEN  *      */
        /*"      *            *            *              * DENTES ANTES DE GERAR *      */
        /*"      *            *            *              * UMA NOVA PENDENCIA.   *      */
        /*"      *            *            *              * SO PARA EMPRE OU ESPEC*      */
        /*"      *            *            *              *   .      (MM0602)     *      */
        /*"      *------------*------------*--------------*-----------------------*      */
        /*"      *     05     *  19/02/02  * M MESSIAS    * O DIA DE FATURA FOI PA*      */
        /*"      *            *            *              * DRONIZADO PARA O DIA  *      */
        /*"      *            *            *              * 31.      (MM0202)     *      */
        /*"      *------------*------------*--------------*-----------------------*      */
        /*"      *     04     *  17/09/99  * LUIZ CARLOS  * SOH GERA O PENDENTE SE*      */
        /*"      *            *            *              * A PARCELA JAH ESTIVER *      */
        /*"      *            *            *              * VENCIDA. (LC0917)     *      */
        /*"      *------------*------------*--------------*-----------------------*      */
        /*"      *     03     *  24/06/99  * TERCIO       * NAO UTILIZA MAIS      *      */
        /*"      *            *            *              * CODIGO DE PRODUTO.    *      */
        /*"      *            *            *              *      PROCURE TL9906   *      */
        /*"      *------------*------------*--------------*-----------------------*      */
        /*"      *     02     *    /05/98  * CONSEDA4     * CONVERSAO ANO 2000    *      */
        /*"      *------------*------------*--------------*-----------------------*      */
        /*"      *     01     *  14/01/98  * MESSIAS      *                       *      */
        /*"      *------------*------------*--------------*-----------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            V0RELA-DTREFER      PIC  X(10).*/
        public StringBasis V0RELA_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            SISTEMA-DTMOVABE    PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            SISTEMA-CURRDATE    PIC  X(010).*/
        public StringBasis SISTEMA_CURRDATE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77            V0HCTB-NRENDOS      PIC S9(09) COMP VALUE +0.*/
        public IntBasis V0HCTB_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0HCOB-NRCERTIF     PIC S9(15) COMP-3.*/
        public IntBasis V0HCOB_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0HCOB-NRPARCEL     PIC S9(04) COMP.*/
        public IntBasis V0HCOB_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0HCOB-NRTIT        PIC S9(13) COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0HCOB-DTVENCTO     PIC  X(10).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0HCOB-OCORHIST     PIC S9(04) COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-FONTE        PIC S9(04) COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-CODPRODU     PIC S9(04) COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-APOLICE      PIC S9(13) COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PROP-CODSUBES     PIC S9(04) COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-DIA-FATURA   PIC S9(04) COMP.*/
        public IntBasis V0PROP_DIA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-ESTR-COBR    PIC  X(10).*/
        public StringBasis V0PROP_ESTR_COBR { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-ORIG-PRODU   PIC  X(10).*/
        public StringBasis V0PROP_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            VIND-DIA-FATURA     PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_DIA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-ESTR-COBR      PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-ORIG-PRODU     PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_ORIG_PRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PARC-PRMVG        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PARC-PRMAP        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WORK-AREA.*/
        public VA0416B_WORK_AREA WORK_AREA { get; set; } = new VA0416B_WORK_AREA();
        public class VA0416B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA0416B_DATA_SQL DATA_SQL { get; set; } = new VA0416B_DATA_SQL();
            public class VA0416B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WHORA-CURR.*/
            }
            public VA0416B_WHORA_CURR WHORA_CURR { get; set; } = new VA0416B_WHORA_CURR();
            public class VA0416B_WHORA_CURR : VarBasis
            {
                /*"      10      WHORA-HH-CURR       PIC  9(002).*/
                public IntBasis WHORA_HH_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-MM-CURR       PIC  9(002).*/
                public IntBasis WHORA_MM_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-SS-CURR       PIC  9(002).*/
                public IntBasis WHORA_SS_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WHORA-CC-CURR       PIC  9(002).*/
                public IntBasis WHORA_CC_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-MAQ.*/
            }
            public VA0416B_DATA_MAQ DATA_MAQ { get; set; } = new VA0416B_DATA_MAQ();
            public class VA0416B_DATA_MAQ : VarBasis
            {
                /*"      10      MES                 PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DIA                 PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      ANO                 PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WIND                PIC  9(002).*/
            }
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05        WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_VA0416B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VA0416B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VA0416B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VA0416B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA.*/

                public _REDEF_VA0416B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public VA0416B_WS_DATA WS_DATA { get; set; } = new VA0416B_WS_DATA();
            public class VA0416B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR1             PIC  X(001).*/
                public StringBasis WS_BAR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR2             PIC  X(001).*/
                public StringBasis WS_BAR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DTREFER.*/
            }
            public VA0416B_WS_DTREFER WS_DTREFER { get; set; } = new VA0416B_WS_DTREFER();
            public class VA0416B_WS_DTREFER : VarBasis
            {
                /*"      10      WS-AAREFER          PIC  9(004).*/
                public IntBasis WS_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MMREFER          PIC  9(002).*/
                public IntBasis WS_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DDREFER          PIC  9(002).*/
                public IntBasis WS_DDREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WFIM-HISTCOBVA    PIC   X(01)  VALUE  ' '.*/
            }
            public StringBasis WFIM_HISTCOBVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SISTEMA        PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-RELATORIO      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_RELATORIO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WTEM-PARCELA        PIC   X(01)  VALUE  ' '.*/
            public StringBasis WTEM_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WTEM-PROPOSTA       PIC   X(01)  VALUE  ' '.*/
            public StringBasis WTEM_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        DATA-AUX.*/
            public VA0416B_DATA_AUX DATA_AUX { get; set; } = new VA0416B_DATA_AUX();
            public class VA0416B_DATA_AUX : VarBasis
            {
                /*"      10      DIA-AUX             PIC  9(002).*/
                public IntBasis DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      MES-AUX             PIC  9(002).*/
                public IntBasis MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      ANO-AUX             PIC  9(004).*/
                public IntBasis ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        AC-L-HISTCOB        PIC  9(007) VALUE ZEROS.*/
            }
            public IntBasis AC_L_HISTCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-L-PROPOSTA       PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_L_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-L-PARCEL         PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_L_PARCEL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-L-HISTCTB        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_L_HISTCTB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-U-HISTCOB        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-U-HISTCTB        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTCTB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-I-HISTCONTABIL   PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCONTABIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        WABEND.*/
            public VA0416B_WABEND WABEND { get; set; } = new VA0416B_WABEND();
            public class VA0416B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA0416B'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA0416B");
                /*"      10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public VA0416B_CHISTCOB CHISTCOB { get; set; } = new VA0416B_CHISTCOB();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -226- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -232- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -233- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -241- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -243- PERFORM R0200-00-SELECT-V0RELATORIOS. */

            R0200_00_SELECT_V0RELATORIOS_SECTION();

            /*" -244- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_RELATORIO.IsEmpty())
            {

                /*" -245- DISPLAY '***********   VA0416B   ****************** ' */
                _.Display($"***********   VA0416B   ****************** ");

                /*" -246- DISPLAY 'SOLICITACAO NAO ENCONTRADO NA V0RELATORIOS ' */
                _.Display($"SOLICITACAO NAO ENCONTRADO NA V0RELATORIOS ");

                /*" -247- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -249- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -251- PERFORM R0900-00-DECLARE-V0HISTCOBVA. */

            R0900_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -253- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -254- IF WFIM-HISTCOBVA EQUAL 'S' */

            if (WORK_AREA.WFIM_HISTCOBVA == "S")
            {

                /*" -255- DISPLAY '***********   VA0416B   ****************** ' */
                _.Display($"***********   VA0416B   ****************** ");

                /*" -256- DISPLAY 'NENHUMA LINHA SELECIONADA NA V0HISTCOBVA ' */
                _.Display($"NENHUMA LINHA SELECIONADA NA V0HISTCOBVA ");

                /*" -257- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -259- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -262- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-HISTCOBVA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_HISTCOBVA == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -262- PERFORM R4000-00-UPDATE-RELATORIO. */

            R4000_00_UPDATE_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -268- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -268- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -271- DISPLAY '** VA0416B - ' */
            _.Display($"** VA0416B - ");

            /*" -272- DISPLAY '** LIDOS V0HISTCOBVA    **' AC-L-HISTCOB */
            _.Display($"** LIDOS V0HISTCOBVA    **{WORK_AREA.AC_L_HISTCOB}");

            /*" -273- DISPLAY '** LIDOS V0PROPOSTAVA   **' AC-L-PROPOSTA */
            _.Display($"** LIDOS V0PROPOSTAVA   **{WORK_AREA.AC_L_PROPOSTA}");

            /*" -274- DISPLAY '** LIDOS V0PARCELVA     **' AC-L-PARCEL */
            _.Display($"** LIDOS V0PARCELVA     **{WORK_AREA.AC_L_PARCEL}");

            /*" -275- DISPLAY '** UPDATE V0HISTCOBVA   **' AC-U-HISTCOB */
            _.Display($"** UPDATE V0HISTCOBVA   **{WORK_AREA.AC_U_HISTCOB}");

            /*" -277- DISPLAY '** INSERT V0HISTCONTABI **' AC-I-HISTCONTABIL */
            _.Display($"** INSERT V0HISTCONTABI **{WORK_AREA.AC_I_HISTCONTABIL}");

            /*" -279- DISPLAY '*** VA0416B - TERMINO NORMAL ***' */
            _.Display($"*** VA0416B - TERMINO NORMAL ***");

            /*" -279- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -292- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -299- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -302- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -304- DISPLAY 'REGISTRO NAO ENCONTRADO NA V0SISTEMA..  ' SQLCODE */
                _.Display($"REGISTRO NAO ENCONTRADO NA V0SISTEMA..  {DB.SQLCODE}");

                /*" -304- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -299- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SISTEMA-DTMOVABE, :SISTEMA-CURRDATE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_CURRDATE, SISTEMA_CURRDATE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-SECTION */
        private void R0200_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -315- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -321- PERFORM R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -324- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -325- MOVE 'S' TO WFIM-RELATORIO */
                _.Move("S", WORK_AREA.WFIM_RELATORIO);

                /*" -325- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -321- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DTREFER FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA0417B' AND SITUACAO = '0' END-EXEC. */

            var r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DTREFER, V0RELA_DTREFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-SECTION */
        private void R0900_00_DECLARE_V0HISTCOBVA_SECTION()
        {
            /*" -338- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -348- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -350- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -348- EXEC SQL DECLARE CHISTCOB CURSOR FOR SELECT NRCERTIF , NRPARCEL , NRTIT , DTVENCTO , OCORHIST FROM SEGUROS.V0HISTCOBVA WHERE SITUACAO IN ( ' ' , '0' , '5' ) END-EXEC. */
            CHISTCOB = new VA0416B_CHISTCOB(false);
            string GetQuery_CHISTCOB()
            {
                var query = @$"SELECT 
							NRCERTIF
							, 
							NRPARCEL
							, 
							NRTIT
							, 
							DTVENCTO
							, 
							OCORHIST 
							FROM SEGUROS.V0HISTCOBVA 
							WHERE SITUACAO IN ( ' '
							, '0'
							, '5' )";

                return query;
            }
            CHISTCOB.GetQueryEvent += GetQuery_CHISTCOB;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1()
        {
            /*" -350- EXEC SQL OPEN CHISTCOB END-EXEC. */

            CHISTCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0910_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -363- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -370- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -373- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -374- MOVE 'S' TO WFIM-HISTCOBVA */
                _.Move("S", WORK_AREA.WFIM_HISTCOBVA);

                /*" -374- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -377- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -377- ADD 1 TO AC-L-HISTCOB. */
            WORK_AREA.AC_L_HISTCOB.Value = WORK_AREA.AC_L_HISTCOB + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -370- EXEC SQL FETCH CHISTCOB INTO :V0HCOB-NRCERTIF , :V0HCOB-NRPARCEL , :V0HCOB-NRTIT , :V0HCOB-DTVENCTO , :V0HCOB-OCORHIST END-EXEC. */

            if (CHISTCOB.Fetch())
            {
                _.Move(CHISTCOB.V0HCOB_NRCERTIF, V0HCOB_NRCERTIF);
                _.Move(CHISTCOB.V0HCOB_NRPARCEL, V0HCOB_NRPARCEL);
                _.Move(CHISTCOB.V0HCOB_NRTIT, V0HCOB_NRTIT);
                _.Move(CHISTCOB.V0HCOB_DTVENCTO, V0HCOB_DTVENCTO);
                _.Move(CHISTCOB.V0HCOB_OCORHIST, V0HCOB_OCORHIST);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1()
        {
            /*" -374- EXEC SQL CLOSE CHISTCOB END-EXEC */

            CHISTCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -390- MOVE 'S' TO WTEM-PROPOSTA. */
            _.Move("S", WORK_AREA.WTEM_PROPOSTA);

            /*" -392- PERFORM R2000-00-SELECT-V0PROPOSTAVA. */

            R2000_00_SELECT_V0PROPOSTAVA_SECTION();

            /*" -393- IF WTEM-PROPOSTA EQUAL 'N' */

            if (WORK_AREA.WTEM_PROPOSTA == "N")
            {

                /*" -396- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -399- IF V0PROP-DIA-FATURA EQUAL 31 AND V0PROP-ESTR-COBR EQUAL 'MULT' NEXT SENTENCE */

            if (V0PROP_DIA_FATURA == 31 && V0PROP_ESTR_COBR == "MULT")
            {

                /*" -400- ELSE */
            }
            else
            {


                /*" -402- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -404- PERFORM R2100-00-SELECT-V0PARCELVA. */

            R2100_00_SELECT_V0PARCELVA_SECTION();

            /*" -405- IF WTEM-PARCELA EQUAL 'N' */

            if (WORK_AREA.WTEM_PARCELA == "N")
            {

                /*" -409- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -410- IF V0HCOB-DTVENCTO LESS SISTEMA-CURRDATE */

            if (V0HCOB_DTVENCTO < SISTEMA_CURRDATE)
            {

                /*" -412- IF V0PROP-ORIG-PRODU EQUAL 'EMPRE' OR 'ESPEC' */

                if (V0PROP_ORIG_PRODU.In("EMPRE", "ESPEC"))
                {

                    /*" -413- PERFORM R4300-00-BUSCA-ENDOSSO */

                    R4300_00_BUSCA_ENDOSSO_SECTION();

                    /*" -415- IF V0HCTB-NRENDOS EQUAL ZEROES NEXT SENTENCE */

                    if (V0HCTB_NRENDOS == 00)
                    {

                        /*" -416- ELSE */
                    }
                    else
                    {


                        /*" -417- PERFORM R4400-00-ATUALIZA */

                        R4400_00_ATUALIZA_SECTION();

                        /*" -418- ELSE */
                    }

                }
                else
                {


                    /*" -420- MOVE ZEROES TO V0HCTB-NRENDOS. */
                    _.Move(0, V0HCTB_NRENDOS);
                }

            }


            /*" -421- IF V0HCOB-DTVENCTO LESS SISTEMA-CURRDATE */

            if (V0HCOB_DTVENCTO < SISTEMA_CURRDATE)
            {

                /*" -422- PERFORM R4100-00-UPDATE-V0HISTCOBVA */

                R4100_00_UPDATE_V0HISTCOBVA_SECTION();

                /*" -422- PERFORM R4200-00-INSERT-V0HISTCONTA. */

                R4200_00_INSERT_V0HISTCONTA_SECTION();
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -426- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-V0PROPOSTAVA-SECTION */
        private void R2000_00_SELECT_V0PROPOSTAVA_SECTION()
        {
            /*" -439- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -459- PERFORM R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1 */

            R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1();

            /*" -462- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -465- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -466- MOVE 'N' TO WTEM-PROPOSTA */
                    _.Move("N", WORK_AREA.WTEM_PROPOSTA);

                    /*" -467- GO TO R2000-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/ //GOTO
                    return;

                    /*" -468- ELSE */
                }
                else
                {


                    /*" -470- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -471- IF VIND-DIA-FATURA LESS 0 */

            if (VIND_DIA_FATURA < 0)
            {

                /*" -473- MOVE ZEROS TO V0PROP-DIA-FATURA. */
                _.Move(0, V0PROP_DIA_FATURA);
            }


            /*" -474- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -476- MOVE ZEROS TO V0PROP-ESTR-COBR. */
                _.Move(0, V0PROP_ESTR_COBR);
            }


            /*" -477- IF VIND-ORIG-PRODU LESS 0 */

            if (VIND_ORIG_PRODU < 0)
            {

                /*" -479- MOVE ZEROS TO V0PROP-ORIG-PRODU. */
                _.Move(0, V0PROP_ORIG_PRODU);
            }


            /*" -479- ADD 1 TO AC-L-PROPOSTA. */
            WORK_AREA.AC_L_PROPOSTA.Value = WORK_AREA.AC_L_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R2000-00-SELECT-V0PROPOSTAVA-DB-SELECT-1 */
        public void R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1()
        {
            /*" -459- EXEC SQL SELECT A.FONTE , A.CODPRODU , A.NUM_APOLICE , A.CODSUBES , B.DIA_FATURA , B.ESTR_COBR , B.ORIG_PRODU INTO :V0PROP-FONTE , :V0PROP-CODPRODU , :V0PROP-APOLICE , :V0PROP-CODSUBES , :V0PROP-DIA-FATURA:VIND-DIA-FATURA, :V0PROP-ESTR-COBR:VIND-ESTR-COBR, :V0PROP-ORIG-PRODU:VIND-ORIG-PRODU FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCOB-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC */

            var r2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 = new R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
            };

            var executed_1 = R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1.Execute(r2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PROP_FONTE, V0PROP_FONTE);
                _.Move(executed_1.V0PROP_CODPRODU, V0PROP_CODPRODU);
                _.Move(executed_1.V0PROP_APOLICE, V0PROP_APOLICE);
                _.Move(executed_1.V0PROP_CODSUBES, V0PROP_CODSUBES);
                _.Move(executed_1.V0PROP_DIA_FATURA, V0PROP_DIA_FATURA);
                _.Move(executed_1.VIND_DIA_FATURA, VIND_DIA_FATURA);
                _.Move(executed_1.V0PROP_ESTR_COBR, V0PROP_ESTR_COBR);
                _.Move(executed_1.VIND_ESTR_COBR, VIND_ESTR_COBR);
                _.Move(executed_1.V0PROP_ORIG_PRODU, V0PROP_ORIG_PRODU);
                _.Move(executed_1.VIND_ORIG_PRODU, VIND_ORIG_PRODU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V0PARCELVA-SECTION */
        private void R2100_00_SELECT_V0PARCELVA_SECTION()
        {
            /*" -491- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -493- MOVE 'S' TO WTEM-PARCELA. */
            _.Move("S", WORK_AREA.WTEM_PARCELA);

            /*" -501- PERFORM R2100_00_SELECT_V0PARCELVA_DB_SELECT_1 */

            R2100_00_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -504- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -507- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -508- MOVE 'N' TO WTEM-PARCELA */
                    _.Move("N", WORK_AREA.WTEM_PARCELA);

                    /*" -509- GO TO R2100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;

                    /*" -510- ELSE */
                }
                else
                {


                    /*" -512- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -512- ADD 1 TO AC-L-PARCEL. */
            WORK_AREA.AC_L_PARCEL.Value = WORK_AREA.AC_L_PARCEL + 1;

        }

        [StopWatch]
        /*" R2100-00-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void R2100_00_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -501- EXEC SQL SELECT PRMVG , PRMAP INTO :V0PARC-PRMVG , :V0PARC-PRMAP FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL END-EXEC */

            var r2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1 = new R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
            };

            var executed_1 = R2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1.Execute(r2100_00_SELECT_V0PARCELVA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0PARC_PRMVG, V0PARC_PRMVG);
                _.Move(executed_1.V0PARC_PRMAP, V0PARC_PRMAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-SECTION */
        private void R4000_00_UPDATE_RELATORIO_SECTION()
        {
            /*" -525- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -530- PERFORM R4000_00_UPDATE_RELATORIO_DB_UPDATE_1 */

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -533- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -534- DISPLAY 'PROBLEMAS NO UPDATE V0RELATORIOS ' */
                _.Display($"PROBLEMAS NO UPDATE V0RELATORIOS ");

                /*" -534- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R4000_00_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -530- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'VA0417B' AND SITUACAO = '0' END-EXEC */

            var r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 = new R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1()
            {
            };

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1.Execute(r4000_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-UPDATE-V0HISTCOBVA-SECTION */
        private void R4100_00_UPDATE_V0HISTCOBVA_SECTION()
        {
            /*" -547- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -549- COMPUTE V0HCOB-OCORHIST = V0HCOB-OCORHIST + 1 */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -555- PERFORM R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -558- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -560- DISPLAY 'PROBLEMAS NO UPDATE V0HISTCOBVA  ' SQLCODE ' ' V0HCOB-NRCERTIF ' ' V0HCOB-NRPARCEL ' ' V0HCOB-NRTIT */

                $"PROBLEMAS NO UPDATE V0HISTCOBVA  {DB.SQLCODE} {V0HCOB_NRCERTIF} {V0HCOB_NRPARCEL} {V0HCOB_NRTIT}"
                .Display();

                /*" -562- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -562- ADD 1 TO AC-U-HISTCOB. */
            WORK_AREA.AC_U_HISTCOB.Value = WORK_AREA.AC_U_HISTCOB + 1;

        }

        [StopWatch]
        /*" R4100-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -555- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET OCORHIST = :V0HCOB-OCORHIST WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1 = new R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1()
            {
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1.Execute(r4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R4200-00-INSERT-V0HISTCONTA-SECTION */
        private void R4200_00_INSERT_V0HISTCONTA_SECTION()
        {
            /*" -575- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -593- PERFORM R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1 */

            R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1();

            /*" -596- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -599- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -600- GO TO R4200-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/ //GOTO
                    return;

                    /*" -601- ELSE */
                }
                else
                {


                    /*" -603- DISPLAY 'PROBLEMAS NO INSERT V0HISTCONTABILVA ' SQLCODE ' ' V0HCOB-NRCERTIF ' ' V0HCOB-NRPARCEL ' ' V0HCOB-NRTIT */

                    $"PROBLEMAS NO INSERT V0HISTCONTABILVA {DB.SQLCODE} {V0HCOB_NRCERTIF} {V0HCOB_NRPARCEL} {V0HCOB_NRTIT}"
                    .Display();

                    /*" -605- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -605- ADD 1 TO AC-I-HISTCONTABIL. */
            WORK_AREA.AC_I_HISTCONTABIL.Value = WORK_AREA.AC_I_HISTCONTABIL + 1;

        }

        [StopWatch]
        /*" R4200-00-INSERT-V0HISTCONTA-DB-INSERT-1 */
        public void R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1()
        {
            /*" -593- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCOB-NRCERTIF , :V0HCOB-NRPARCEL , :V0HCOB-NRTIT , :V0HCOB-OCORHIST , :V0PROP-APOLICE , :V0PROP-CODSUBES , :V0PROP-FONTE , :V0HCTB-NRENDOS , :V0PARC-PRMVG , :V0PARC-PRMAP , :V0HCOB-DTVENCTO , ' ' , 1000 , CURRENT TIMESTAMP, :V0RELA-DTREFER) END-EXEC */

            var r4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1 = new R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0PROP_APOLICE = V0PROP_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0HCTB_NRENDOS = V0HCTB_NRENDOS.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0RELA_DTREFER = V0RELA_DTREFER.ToString(),
            };

            R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1.Execute(r4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R4300-00-BUSCA-ENDOSSO-SECTION */
        private void R4300_00_BUSCA_ENDOSSO_SECTION()
        {
            /*" -618- MOVE '430' TO WNR-EXEC-SQL. */
            _.Move("430", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -626- PERFORM R4300_00_BUSCA_ENDOSSO_DB_SELECT_1 */

            R4300_00_BUSCA_ENDOSSO_DB_SELECT_1();

            /*" -629- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -630- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -634- MOVE ZEROS TO V0HCTB-NRENDOS */
                    _.Move(0, V0HCTB_NRENDOS);

                    /*" -635- GO TO R4300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/ //GOTO
                    return;

                    /*" -636- ELSE */
                }
                else
                {


                    /*" -638- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -638- ADD 1 TO AC-L-HISTCTB. */
            WORK_AREA.AC_L_HISTCTB.Value = WORK_AREA.AC_L_HISTCTB + 1;

        }

        [StopWatch]
        /*" R4300-00-BUSCA-ENDOSSO-DB-SELECT-1 */
        public void R4300_00_BUSCA_ENDOSSO_DB_SELECT_1()
        {
            /*" -626- EXEC SQL SELECT NRENDOS INTO :V0HCTB-NRENDOS FROM SEGUROS.V0HISTCONTABILVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND NRTIT = :V0HCOB-NRTIT AND OCOORHIST = :V0HCOB-OCORHIST END-EXEC */

            var r4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1 = new R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            var executed_1 = R4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1.Execute(r4300_00_BUSCA_ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0HCTB_NRENDOS, V0HCTB_NRENDOS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4300_99_SAIDA*/

        [StopWatch]
        /*" R4400-00-ATUALIZA-SECTION */
        private void R4400_00_ATUALIZA_SECTION()
        {
            /*" -651- MOVE '440' TO WNR-EXEC-SQL. */
            _.Move("440", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -657- PERFORM R4400_00_ATUALIZA_DB_UPDATE_1 */

            R4400_00_ATUALIZA_DB_UPDATE_1();

            /*" -660- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -663- DISPLAY 'PROBLEMAS NO UPDATE V0HISTCONTABILVA ' SQLCODE ' ' V0HCOB-NRCERTIF ' ' V0HCOB-NRPARCEL ' ' V0HCOB-NRTIT */

                $"PROBLEMAS NO UPDATE V0HISTCONTABILVA {DB.SQLCODE} {V0HCOB_NRCERTIF} {V0HCOB_NRPARCEL} {V0HCOB_NRTIT}"
                .Display();

                /*" -665- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -665- ADD 1 TO AC-U-HISTCTB. */
            WORK_AREA.AC_U_HISTCTB.Value = WORK_AREA.AC_U_HISTCTB + 1;

        }

        [StopWatch]
        /*" R4400-00-ATUALIZA-DB-UPDATE-1 */
        public void R4400_00_ATUALIZA_DB_UPDATE_1()
        {
            /*" -657- EXEC SQL UPDATE SEGUROS.V0HISTCONTABILVA SET NRENDOS = 0 WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

            var r4400_00_ATUALIZA_DB_UPDATE_1_Update1 = new R4400_00_ATUALIZA_DB_UPDATE_1_Update1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
            };

            R4400_00_ATUALIZA_DB_UPDATE_1_Update1.Execute(r4400_00_ATUALIZA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4400_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -678- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -680- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -680- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -682- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -685- DISPLAY 'NRCERTIF ' V0HCOB-NRCERTIF */
            _.Display($"NRCERTIF {V0HCOB_NRCERTIF}");

            /*" -686- DISPLAY 'NRPARCEL ' V0HCOB-NRPARCEL */
            _.Display($"NRPARCEL {V0HCOB_NRPARCEL}");

            /*" -688- DISPLAY 'NRTIT    ' V0HCOB-NRTIT */
            _.Display($"NRTIT    {V0HCOB_NRTIT}");

            /*" -690- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -690- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}