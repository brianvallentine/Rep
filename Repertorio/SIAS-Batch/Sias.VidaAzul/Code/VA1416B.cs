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
using Sias.VidaAzul.DB2.VA1416B;

namespace Code
{
    public class VA1416B
    {
        public bool IsCall { get; set; }

        public VA1416B()
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
        /*"      * MOMENTO DO FATURAMENTO DO MULTIPREMIADO PARA AS APOLICES       *      */
        /*"      * FENAM.                                                         *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  14/01/98  *   MESSIAS    *                       *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     02     *  24/06/99  *   TERCIO     * NAO TRATA MAIS POR    *      */
        /*"      *            *            *              * PRODUTO.              *      */
        /*"      *            *            *              *     PROCURE TL9906    *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              05/1998  *      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            V0RELA-DTREFER      PIC  X(10).*/
        public StringBasis V0RELA_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
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
        /*"77            VIND-DIA-FATURA     PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_DIA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-ESTR-COBR      PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_ESTR_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PARC-PRMVG        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PARC-PRMAP        PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  WORK-AREA.*/
        public VA1416B_WORK_AREA WORK_AREA { get; set; } = new VA1416B_WORK_AREA();
        public class VA1416B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public VA1416B_DATA_SQL DATA_SQL { get; set; } = new VA1416B_DATA_SQL();
            public class VA1416B_DATA_SQL : VarBasis
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
            public VA1416B_WHORA_CURR WHORA_CURR { get; set; } = new VA1416B_WHORA_CURR();
            public class VA1416B_WHORA_CURR : VarBasis
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
            public VA1416B_DATA_MAQ DATA_MAQ { get; set; } = new VA1416B_DATA_MAQ();
            public class VA1416B_DATA_MAQ : VarBasis
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
            private _REDEF_VA1416B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VA1416B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VA1416B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VA1416B_WS_TIME_R : VarBasis
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

                public _REDEF_VA1416B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public VA1416B_WS_DATA WS_DATA { get; set; } = new VA1416B_WS_DATA();
            public class VA1416B_WS_DATA : VarBasis
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
            public VA1416B_WS_DTREFER WS_DTREFER { get; set; } = new VA1416B_WS_DTREFER();
            public class VA1416B_WS_DTREFER : VarBasis
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
            /*"    05        DATA-AUX.*/
            public VA1416B_DATA_AUX DATA_AUX { get; set; } = new VA1416B_DATA_AUX();
            public class VA1416B_DATA_AUX : VarBasis
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
            /*"    05        AC-U-HISTCOB        PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_U_HISTCOB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        AC-I-HISTCONTABIL   PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_I_HISTCONTABIL { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"    05        WABEND.*/
            public VA1416B_WABEND WABEND { get; set; } = new VA1416B_WABEND();
            public class VA1416B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA1416B'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA1416B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public VA1416B_CHISTCOB CHISTCOB { get; set; } = new VA1416B_CHISTCOB();
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
            /*" -191- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -194- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -197- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -205- PERFORM R0200-00-SELECT-V0RELATORIOS. */

            R0200_00_SELECT_V0RELATORIOS_SECTION();

            /*" -206- IF WFIM-RELATORIO NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_RELATORIO.IsEmpty())
            {

                /*" -207- DISPLAY '***********   VA1416B   ****************** ' */
                _.Display($"***********   VA1416B   ****************** ");

                /*" -208- DISPLAY 'SOLICITACAO NAO ENCONTRADO NA V0RELATORIOS ' */
                _.Display($"SOLICITACAO NAO ENCONTRADO NA V0RELATORIOS ");

                /*" -209- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -211- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -213- PERFORM R0900-00-DECLARE-V0HISTCOBVA. */

            R0900_00_DECLARE_V0HISTCOBVA_SECTION();

            /*" -215- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

            /*" -216- IF WFIM-HISTCOBVA EQUAL 'S' */

            if (WORK_AREA.WFIM_HISTCOBVA == "S")
            {

                /*" -217- DISPLAY '***********   VA1416B   ****************** ' */
                _.Display($"***********   VA1416B   ****************** ");

                /*" -218- DISPLAY 'NENHUMA LINHA SELECIONADA NA V0HISTCOBVA ' */
                _.Display($"NENHUMA LINHA SELECIONADA NA V0HISTCOBVA ");

                /*" -219- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -221- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -224- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-HISTCOBVA EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_HISTCOBVA == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -224- PERFORM R4000-00-UPDATE-RELATORIO. */

            R4000_00_UPDATE_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -230- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -230- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -233- DISPLAY '** VA1416B - ' */
            _.Display($"** VA1416B - ");

            /*" -234- DISPLAY '** LIDOS V0HISTCOBVA    **' AC-L-HISTCOB */
            _.Display($"** LIDOS V0HISTCOBVA    **{WORK_AREA.AC_L_HISTCOB}");

            /*" -235- DISPLAY '** LIDOS V0PROPOSTAVA   **' AC-L-PROPOSTA */
            _.Display($"** LIDOS V0PROPOSTAVA   **{WORK_AREA.AC_L_PROPOSTA}");

            /*" -236- DISPLAY '** LIDOS V0PARCELVA     **' AC-L-PARCEL */
            _.Display($"** LIDOS V0PARCELVA     **{WORK_AREA.AC_L_PARCEL}");

            /*" -237- DISPLAY '** UPDATE V0HISTCOBVA   **' AC-U-HISTCOB */
            _.Display($"** UPDATE V0HISTCOBVA   **{WORK_AREA.AC_U_HISTCOB}");

            /*" -239- DISPLAY '** INSERT V0HISTCONTABI **' AC-I-HISTCONTABIL */
            _.Display($"** INSERT V0HISTCONTABI **{WORK_AREA.AC_I_HISTCONTABIL}");

            /*" -241- DISPLAY '*** VA1416B - TERMINO NORMAL ***' */
            _.Display($"*** VA1416B - TERMINO NORMAL ***");

            /*" -241- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-SECTION */
        private void R0200_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -254- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -260- PERFORM R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -263- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -264- MOVE 'S' TO WFIM-RELATORIO */
                _.Move("S", WORK_AREA.WFIM_RELATORIO);

                /*" -264- GO TO R0200-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -260- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DTREFER FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA1417B' AND SITUACAO = '0' END-EXEC. */

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
            /*" -277- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -287- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();

            /*" -289- PERFORM R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTCOBVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1()
        {
            /*" -287- EXEC SQL DECLARE CHISTCOB CURSOR FOR SELECT NRCERTIF , NRPARCEL , NRTIT , DTVENCTO , OCORHIST FROM SEGUROS.V0HISTCOBVA WHERE SITUACAO IN ( ' ' , '0' , '5' ) END-EXEC. */
            CHISTCOB = new VA1416B_CHISTCOB(false);
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
            /*" -289- EXEC SQL OPEN CHISTCOB END-EXEC. */

            CHISTCOB.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-SECTION */
        private void R0910_00_FETCH_V0HISTCOBVA_SECTION()
        {
            /*" -302- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -309- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1 */

            R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1();

            /*" -312- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -313- MOVE 'S' TO WFIM-HISTCOBVA */
                _.Move("S", WORK_AREA.WFIM_HISTCOBVA);

                /*" -313- PERFORM R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1 */

                R0910_00_FETCH_V0HISTCOBVA_DB_CLOSE_1();

                /*" -316- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -316- ADD 1 TO AC-L-HISTCOB. */
            WORK_AREA.AC_L_HISTCOB.Value = WORK_AREA.AC_L_HISTCOB + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTCOBVA-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HISTCOBVA_DB_FETCH_1()
        {
            /*" -309- EXEC SQL FETCH CHISTCOB INTO :V0HCOB-NRCERTIF , :V0HCOB-NRPARCEL , :V0HCOB-NRTIT , :V0HCOB-DTVENCTO , :V0HCOB-OCORHIST END-EXEC. */

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
            /*" -313- EXEC SQL CLOSE CHISTCOB END-EXEC */

            CHISTCOB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -329- PERFORM R2000-00-SELECT-V0PROPOSTAVA. */

            R2000_00_SELECT_V0PROPOSTAVA_SECTION();

            /*" -332- IF V0PROP-DIA-FATURA EQUAL 31 AND V0PROP-ESTR-COBR EQUAL 'MULT' NEXT SENTENCE */

            if (V0PROP_DIA_FATURA == 31 && V0PROP_ESTR_COBR == "MULT")
            {

                /*" -333- ELSE */
            }
            else
            {


                /*" -335- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -337- PERFORM R2100-00-SELECT-V0PARCELVA. */

            R2100_00_SELECT_V0PARCELVA_SECTION();

            /*" -338- IF WTEM-PARCELA EQUAL 'N' */

            if (WORK_AREA.WTEM_PARCELA == "N")
            {

                /*" -340- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -342- PERFORM R4100-00-UPDATE-V0HISTCOBVA. */

            R4100_00_UPDATE_V0HISTCOBVA_SECTION();

            /*" -342- PERFORM R4200-00-INSERT-V0HISTCONTA. */

            R4200_00_INSERT_V0HISTCONTA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -346- PERFORM R0910-00-FETCH-V0HISTCOBVA. */

            R0910_00_FETCH_V0HISTCOBVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-SELECT-V0PROPOSTAVA-SECTION */
        private void R2000_00_SELECT_V0PROPOSTAVA_SECTION()
        {
            /*" -359- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -377- PERFORM R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1 */

            R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -381- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -383- DISPLAY 'REGISTRO NAO ENCONTRADO NA V0PROPOSTAVA ' V0HCOB-NRCERTIF */
                    _.Display($"REGISTRO NAO ENCONTRADO NA V0PROPOSTAVA {V0HCOB_NRCERTIF}");

                    /*" -384- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -385- ELSE */
                }
                else
                {


                    /*" -387- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -388- IF VIND-DIA-FATURA LESS 0 */

            if (VIND_DIA_FATURA < 0)
            {

                /*" -390- MOVE ZEROS TO V0PROP-DIA-FATURA. */
                _.Move(0, V0PROP_DIA_FATURA);
            }


            /*" -391- IF VIND-ESTR-COBR LESS 0 */

            if (VIND_ESTR_COBR < 0)
            {

                /*" -393- MOVE ' ' TO V0PROP-ESTR-COBR. */
                _.Move(" ", V0PROP_ESTR_COBR);
            }


            /*" -393- ADD 1 TO AC-L-PROPOSTA. */
            WORK_AREA.AC_L_PROPOSTA.Value = WORK_AREA.AC_L_PROPOSTA + 1;

        }

        [StopWatch]
        /*" R2000-00-SELECT-V0PROPOSTAVA-DB-SELECT-1 */
        public void R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1()
        {
            /*" -377- EXEC SQL SELECT A.FONTE , A.CODPRODU , A.NUM_APOLICE , A.CODSUBES , B.DIA_FATURA , B.ESTR_COBR INTO :V0PROP-FONTE , :V0PROP-CODPRODU , :V0PROP-APOLICE , :V0PROP-CODSUBES , :V0PROP-DIA-FATURA:VIND-DIA-FATURA, :V0PROP-ESTR-COBR:VIND-ESTR-COBR FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0PRODUTOSVG B WHERE A.NRCERTIF = :V0HCOB-NRCERTIF AND B.NUM_APOLICE = A.NUM_APOLICE AND B.CODSUBES = A.CODSUBES END-EXEC */

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
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-SELECT-V0PARCELVA-SECTION */
        private void R2100_00_SELECT_V0PARCELVA_SECTION()
        {
            /*" -405- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -407- MOVE 'S' TO WTEM-PARCELA. */
            _.Move("S", WORK_AREA.WTEM_PARCELA);

            /*" -415- PERFORM R2100_00_SELECT_V0PARCELVA_DB_SELECT_1 */

            R2100_00_SELECT_V0PARCELVA_DB_SELECT_1();

            /*" -418- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -419- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -421- DISPLAY 'REGISTRO NAO ENCONTRADO NA V0PARCELVA ' V0HCOB-NRCERTIF ' ' V0HCOB-NRPARCEL */

                    $"REGISTRO NAO ENCONTRADO NA V0PARCELVA {V0HCOB_NRCERTIF} {V0HCOB_NRPARCEL}"
                    .Display();

                    /*" -422- MOVE 'N' TO WTEM-PARCELA */
                    _.Move("N", WORK_AREA.WTEM_PARCELA);

                    /*" -423- GO TO R2100-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/ //GOTO
                    return;

                    /*" -424- ELSE */
                }
                else
                {


                    /*" -426- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -426- ADD 1 TO AC-L-PARCEL. */
            WORK_AREA.AC_L_PARCEL.Value = WORK_AREA.AC_L_PARCEL + 1;

        }

        [StopWatch]
        /*" R2100-00-SELECT-V0PARCELVA-DB-SELECT-1 */
        public void R2100_00_SELECT_V0PARCELVA_DB_SELECT_1()
        {
            /*" -415- EXEC SQL SELECT PRMVG , PRMAP INTO :V0PARC-PRMVG , :V0PARC-PRMAP FROM SEGUROS.V0PARCELVA WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL END-EXEC */

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
            /*" -439- MOVE '400' TO WNR-EXEC-SQL. */
            _.Move("400", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -444- PERFORM R4000_00_UPDATE_RELATORIO_DB_UPDATE_1 */

            R4000_00_UPDATE_RELATORIO_DB_UPDATE_1();

            /*" -447- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -448- DISPLAY 'PROBLEMAS NO UPDATE V0RELATORIOS ' */
                _.Display($"PROBLEMAS NO UPDATE V0RELATORIOS ");

                /*" -448- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R4000-00-UPDATE-RELATORIO-DB-UPDATE-1 */
        public void R4000_00_UPDATE_RELATORIO_DB_UPDATE_1()
        {
            /*" -444- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' WHERE CODRELAT = 'VA1417B' AND SITUACAO = '0' END-EXEC */

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
            /*" -461- MOVE '410' TO WNR-EXEC-SQL. */
            _.Move("410", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -463- COMPUTE V0HCOB-OCORHIST = V0HCOB-OCORHIST + 1 */
            V0HCOB_OCORHIST.Value = V0HCOB_OCORHIST + 1;

            /*" -469- PERFORM R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1 */

            R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1();

            /*" -472- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -474- DISPLAY 'PROBLEMAS NO UPDATE V0HISTCOBVA  ' SQLCODE ' ' V0HCOB-NRCERTIF ' ' V0HCOB-NRPARCEL ' ' V0HCOB-NRTIT */

                $"PROBLEMAS NO UPDATE V0HISTCOBVA  {DB.SQLCODE} {V0HCOB_NRCERTIF} {V0HCOB_NRPARCEL} {V0HCOB_NRTIT}"
                .Display();

                /*" -476- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -476- ADD 1 TO AC-U-HISTCOB. */
            WORK_AREA.AC_U_HISTCOB.Value = WORK_AREA.AC_U_HISTCOB + 1;

        }

        [StopWatch]
        /*" R4100-00-UPDATE-V0HISTCOBVA-DB-UPDATE-1 */
        public void R4100_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1()
        {
            /*" -469- EXEC SQL UPDATE SEGUROS.V0HISTCOBVA SET OCORHIST = :V0HCOB-OCORHIST WHERE NRCERTIF = :V0HCOB-NRCERTIF AND NRPARCEL = :V0HCOB-NRPARCEL AND NRTIT = :V0HCOB-NRTIT END-EXEC */

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
            /*" -489- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -506- PERFORM R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1 */

            R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1();

            /*" -509- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -511- DISPLAY 'PROBLEMAS NO INSERT V0HISTCONTABILVA ' SQLCODE ' ' V0HCOB-NRCERTIF ' ' V0HCOB-NRPARCEL ' ' V0HCOB-NRTIT */

                $"PROBLEMAS NO INSERT V0HISTCONTABILVA {DB.SQLCODE} {V0HCOB_NRCERTIF} {V0HCOB_NRPARCEL} {V0HCOB_NRTIT}"
                .Display();

                /*" -513- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -513- ADD 1 TO AC-I-HISTCONTABIL. */
            WORK_AREA.AC_I_HISTCONTABIL.Value = WORK_AREA.AC_I_HISTCONTABIL + 1;

        }

        [StopWatch]
        /*" R4200-00-INSERT-V0HISTCONTA-DB-INSERT-1 */
        public void R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1()
        {
            /*" -506- EXEC SQL INSERT INTO SEGUROS.V0HISTCONTABILVA VALUES (:V0HCOB-NRCERTIF , :V0HCOB-NRPARCEL , :V0HCOB-NRTIT , :V0HCOB-OCORHIST , :V0PROP-APOLICE , :V0PROP-CODSUBES , :V0PROP-FONTE , 0 , :V0PARC-PRMVG , :V0PARC-PRMAP , :V0HCOB-DTVENCTO , ' ' , 1000 , CURRENT TIMESTAMP, :V0RELA-DTREFER) END-EXEC */

            var r4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1 = new R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1()
            {
                V0HCOB_NRCERTIF = V0HCOB_NRCERTIF.ToString(),
                V0HCOB_NRPARCEL = V0HCOB_NRPARCEL.ToString(),
                V0HCOB_NRTIT = V0HCOB_NRTIT.ToString(),
                V0HCOB_OCORHIST = V0HCOB_OCORHIST.ToString(),
                V0PROP_APOLICE = V0PROP_APOLICE.ToString(),
                V0PROP_CODSUBES = V0PROP_CODSUBES.ToString(),
                V0PROP_FONTE = V0PROP_FONTE.ToString(),
                V0PARC_PRMVG = V0PARC_PRMVG.ToString(),
                V0PARC_PRMAP = V0PARC_PRMAP.ToString(),
                V0HCOB_DTVENCTO = V0HCOB_DTVENCTO.ToString(),
                V0RELA_DTREFER = V0RELA_DTREFER.ToString(),
            };

            R4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1.Execute(r4200_00_INSERT_V0HISTCONTA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4200_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -527- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -529- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -529- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -531- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -534- DISPLAY 'NRCERTIF ' V0HCOB-NRCERTIF */
            _.Display($"NRCERTIF {V0HCOB_NRCERTIF}");

            /*" -535- DISPLAY 'NRPARCEL ' V0HCOB-NRPARCEL */
            _.Display($"NRPARCEL {V0HCOB_NRPARCEL}");

            /*" -537- DISPLAY 'NRTIT    ' V0HCOB-NRTIT */
            _.Display($"NRTIT    {V0HCOB_NRTIT}");

            /*" -539- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -539- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}