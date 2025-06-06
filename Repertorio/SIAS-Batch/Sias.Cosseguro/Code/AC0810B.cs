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
using Sias.Cosseguro.DB2.AC0810B;

namespace Code
{
    public class AC0810B
    {
        public bool IsCall { get; set; }

        public AC0810B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------*                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA .......... COSSEGURO CEDIDO                          *      */
        /*"      *   PROGRAMA ......... AC0810B                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ......... GILSON PINTO                              *      */
        /*"      *   PROGRAMADOR ...... WELLINGTON F R C VERAS                    *      */
        /*"      *   DATA CODIFICACAO . SETEMBRO DE 2018                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO . ATUALIZA O CODIGO DE EMPRESA ATRAVES DO COD PRODUTO *      */
        /*"      *          - NO CONTA CORRENTE COSSEGURO CEDIDO DE PREMIOS       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            DCLGEN               ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          SISTEMAS             INPUT   *      */
        /*"      * COSSEGURO_HIST_PRE                COSHISPR             I-O     *      */
        /*"      * ENDOSSOS                          ENDOSSOS             INPUT   *      */
        /*"      * PRODUTO                           PRODUTO              INPUT   *      */
        /*"      * COSSEGURO_PREMIOS                 COSSPREM             OUTPUT  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ARQUIVO                                                ACESSO  *      */
        /*"      *----------------------------------------------------    ------- *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          AREA-DE-WORK.*/
        public AC0810B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0810B_AREA_DE_WORK();
        public class AC0810B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WFIM-COSHISPR       PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_COSHISPR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-COUNT            PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-L-COSHISPR       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_COSHISPR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-U-COSSPREM       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSPREM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-U-COSHISPR       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_COSHISPR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        WS-DATA-ACCEPT.*/
            public AC0810B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new AC0810B_WS_DATA_ACCEPT();
            public class AC0810B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10      WS-ANO-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-MES-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-DIA-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WS-HORA-ACCEPT.*/
            }
            public AC0810B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new AC0810B_WS_HORA_ACCEPT();
            public class AC0810B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10      WS-HOR-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-MIN-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-SEG-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WS-DATA-CURR.*/
            }
            public AC0810B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new AC0810B_WS_DATA_CURR();
            public class AC0810B_WS_DATA_CURR : VarBasis
            {
                /*"    10      WS-DIA-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_DIA_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-MES-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_MES_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-ANO-CURR         PIC  9(004)      VALUE ZEROS.*/
                public IntBasis WS_ANO_CURR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  05        WS-HORA-CURR.*/
            }
            public AC0810B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new AC0810B_WS_HORA_CURR();
            public class AC0810B_WS_HORA_CURR : VarBasis
            {
                /*"    10      WS-HOR-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_HOR_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-MIN-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_MIN_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)      VALUE SPACES.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10      WS-SEG-CURR         PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_SEG_CURR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WDATA-COBOL         PIC  X(021)      VALUE SPACES.*/
            }
            public StringBasis WDATA_COBOL { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"  05        FILLER              REDEFINES        WDATA-COBOL.*/
            private _REDEF_AC0810B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_AC0810B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_AC0810B_FILLER_4(); _.Move(WDATA_COBOL, _filler_4); VarBasis.RedefinePassValue(WDATA_COBOL, _filler_4, WDATA_COBOL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_COBOL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_COBOL); }
            }  //Redefines
            public class _REDEF_AC0810B_FILLER_4 : VarBasis
            {
                /*"    10      DT-ANO              PIC  9(004).*/
                public IntBasis DT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      DT-MES              PIC  9(002).*/
                public IntBasis DT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-DIA              PIC  9(002).*/
                public IntBasis DT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-HORA             PIC  9(002).*/
                public IntBasis DT_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-MIN              PIC  9(002).*/
                public IntBasis DT_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-SEG              PIC  9(002).*/
                public IntBasis DT_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-DECSEG           PIC  9(002).*/
                public IntBasis DT_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-GREEN            PIC  X(001).*/
                public StringBasis DT_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      DT-GHORA            PIC  9(002).*/
                public IntBasis DT_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      DT-GMIN             PIC  9(002).*/
                public IntBasis DT_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        DATA-EDIT           PIC  X(028)      VALUE SPACES.*/

                public _REDEF_AC0810B_FILLER_4()
                {
                    DT_ANO.ValueChanged += OnValueChanged;
                    DT_MES.ValueChanged += OnValueChanged;
                    DT_DIA.ValueChanged += OnValueChanged;
                    DT_HORA.ValueChanged += OnValueChanged;
                    DT_MIN.ValueChanged += OnValueChanged;
                    DT_SEG.ValueChanged += OnValueChanged;
                    DT_DECSEG.ValueChanged += OnValueChanged;
                    DT_GREEN.ValueChanged += OnValueChanged;
                    DT_GHORA.ValueChanged += OnValueChanged;
                    DT_GMIN.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis DATA_EDIT { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
            /*"01          WABEND.*/
        }
        public AC0810B_WABEND WABEND { get; set; } = new AC0810B_WABEND();
        public class AC0810B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)      VALUE           ' AC0810B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0810B  ");
            /*"  05        FILLER              PIC  X(026)      VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(003)      VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05        FILLER              PIC  X(013)      VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.COSHISPR COSHISPR { get; set; } = new Dclgens.COSHISPR();
        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.COSSPREM COSSPREM { get; set; } = new Dclgens.COSSPREM();
        public AC0810B_C01_COSHISPR C01_COSHISPR { get; set; } = new AC0810B_C01_COSHISPR();
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
            /*" -155- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -155- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -157- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -159- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -163- MOVE FUNCTION WHEN-COMPILED TO WDATA-COBOL. */
            _.Move(_.WhenCompiled(), AREA_DE_WORK.WDATA_COBOL);

            /*" -169- STRING DT-ANO '-' DT-MES '-' DT-DIA 'T' DT-HORA ':' DT-MIN ':' DT-SEG ',' DT-DECSEG DT-GREEN DT-GHORA ':' DT-GMIN DELIMITED BY SIZE INTO DATA-EDIT. */
            #region STRING
            var spl1 = AREA_DE_WORK.FILLER_4.DT_ANO.GetMoveValues();
            spl1 += "-";
            var spl2 = AREA_DE_WORK.FILLER_4.DT_MES.GetMoveValues();
            spl2 += "-";
            var spl3 = AREA_DE_WORK.FILLER_4.DT_DIA.GetMoveValues();
            spl3 += "T";
            var spl4 = AREA_DE_WORK.FILLER_4.DT_HORA.GetMoveValues();
            spl4 += ":";
            var spl5 = AREA_DE_WORK.FILLER_4.DT_MIN.GetMoveValues();
            spl5 += ":";
            var spl6 = AREA_DE_WORK.FILLER_4.DT_SEG.GetMoveValues();
            spl6 += ",";
            var spl7 = AREA_DE_WORK.FILLER_4.DT_DECSEG.GetMoveValues();
            var spl8 = AREA_DE_WORK.FILLER_4.DT_GREEN.GetMoveValues();
            var spl9 = AREA_DE_WORK.FILLER_4.DT_GHORA.GetMoveValues();
            spl9 += ":";
            var spl10 = AREA_DE_WORK.FILLER_4.DT_GMIN.GetMoveValues();
            var results11 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7 + spl8 + spl9 + spl10;
            _.Move(results11, AREA_DE_WORK.DATA_EDIT);
            #endregion

            /*" -171- DISPLAY '----------------------------------------------------------' . */
            _.Display($"----------------------------------------------------------");

            /*" -172- DISPLAY '  Programa .....: AC0810B: ATUALIZ. COD EMPR VIDA' . */
            _.Display($"  Programa .....: AC0810B: ATUALIZ. COD EMPR VIDA");

            /*" -173- DISPLAY '  Criacao ......: Setembro de 2018               ' . */
            _.Display($"  Criacao ......: Setembro de 2018               ");

            /*" -174- DISPLAY '  Catalogacao...: ' DATA-EDIT '   ' . */

            $"  Catalogacao...: {AREA_DE_WORK.DATA_EDIT}   "
            .Display();

            /*" -176- DISPLAY '----------------------------------------------------------' . */
            _.Display($"----------------------------------------------------------");

            /*" -178- DISPLAY '  ' . */
            _.Display($"  ");

            /*" -180- MOVE '00/00/0000' TO WS-DATA-CURR. */
            _.Move("00/00/0000", AREA_DE_WORK.WS_DATA_CURR);

            /*" -181- ACCEPT WS-DATA-ACCEPT FROM DATE. */
            _.Move(_.AcceptDate("DATE"), AREA_DE_WORK.WS_DATA_ACCEPT);

            /*" -182- MOVE WS-DIA-ACCEPT TO WS-DIA-CURR. */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_DIA_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_DIA_CURR);

            /*" -183- MOVE WS-MES-ACCEPT TO WS-MES-CURR. */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_MES_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_MES_CURR);

            /*" -184- MOVE WS-ANO-ACCEPT TO WS-ANO-CURR. */
            _.Move(AREA_DE_WORK.WS_DATA_ACCEPT.WS_ANO_ACCEPT, AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR);

            /*" -186- ADD 2000 TO WS-ANO-CURR. */
            AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR.Value = AREA_DE_WORK.WS_DATA_CURR.WS_ANO_CURR + 2000;

            /*" -188- MOVE '00:00:00' TO WS-HORA-CURR. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -189- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -190- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -191- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -193- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -196- DISPLAY 'AC0810B - INICIO DE EXECUCAO (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"AC0810B - INICIO DE EXECUCAO ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

            /*" -198- INITIALIZE DCLCOSSEGURO-PREMIOS. */
            _.Initialize(
                COSSPREM.DCLCOSSEGURO_PREMIOS
            );

            /*" -200- INITIALIZE DCLCOSSEGURO-HIST-PRE. */
            _.Initialize(
                COSHISPR.DCLCOSSEGURO_HIST_PRE
            );

            /*" -202- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -204- PERFORM R0200-00-DECLARE-COSHISPR. */

            R0200_00_DECLARE_COSHISPR_SECTION();

            /*" -206- PERFORM R0300-00-FETCH-COSHISPR. */

            R0300_00_FETCH_COSHISPR_SECTION();

            /*" -207- IF WFIM-COSHISPR NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_COSHISPR.IsEmpty())
            {

                /*" -208- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -209- ELSE */
            }
            else
            {


                /*" -211- PERFORM R0400-00-PROCESSA-REGISTRO UNTIL WFIM-COSHISPR NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_COSHISPR.IsEmpty()))
                {

                    R0400_00_PROCESSA_REGISTRO_SECTION();
                }

                /*" -211- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -216- DISPLAY 'REG. LIDOS NA COSHISPR  - ' AC-L-COSHISPR. */
            _.Display($"REG. LIDOS NA COSHISPR  - {AREA_DE_WORK.AC_L_COSHISPR}");

            /*" -217- DISPLAY 'REG. ALTER NA COSSPREM  - ' AC-U-COSSPREM. */
            _.Display($"REG. ALTER NA COSSPREM  - {AREA_DE_WORK.AC_U_COSSPREM}");

            /*" -219- DISPLAY 'REG. ALTER NA COSHISPR  - ' AC-U-COSHISPR. */
            _.Display($"REG. ALTER NA COSHISPR  - {AREA_DE_WORK.AC_U_COSHISPR}");

            /*" -221- MOVE '00:00:00' TO WS-HORA-CURR. */
            _.Move("00:00:00", AREA_DE_WORK.WS_HORA_CURR);

            /*" -222- ACCEPT WS-HORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

            /*" -223- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

            /*" -224- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

            /*" -226- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR. */
            _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

            /*" -227- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -230- DISPLAY 'AC0810B - FINAL DE EXECUCAO  (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"AC0810B - FINAL DE EXECUCAO  ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

            /*" -232- DISPLAY '*---   AC0810B  -  FIM  NORMAL   ---*' . */
            _.Display($"*---   AC0810B  -  FIM  NORMAL   ---*");

            /*" -234- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -234- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -247- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -253- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -256- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -257- DISPLAY 'R0100 - ERRO NO SELECT DA SISTEMAS' */
                _.Display($"R0100 - ERRO NO SELECT DA SISTEMAS");

                /*" -258- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -259- ELSE */
            }
            else
            {


                /*" -260- DISPLAY 'DATA DO MOVIMENTO - ' SISTEMAS-DATA-MOV-ABERTO */
                _.Display($"DATA DO MOVIMENTO - {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

                /*" -260- END-IF. */
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -253- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'AC' WITH UR END-EXEC. */

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
        /*" R0200-00-DECLARE-COSHISPR-SECTION */
        private void R0200_00_DECLARE_COSHISPR_SECTION()
        {
            /*" -273- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -292- PERFORM R0200_00_DECLARE_COSHISPR_DB_DECLARE_1 */

            R0200_00_DECLARE_COSHISPR_DB_DECLARE_1();

            /*" -294- PERFORM R0200_00_DECLARE_COSHISPR_DB_OPEN_1 */

            R0200_00_DECLARE_COSHISPR_DB_OPEN_1();

            /*" -297- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -298- DISPLAY 'R0200 - ERRO NO DECLARE DA COSSEGURO_HIST_PRE' */
                _.Display($"R0200 - ERRO NO DECLARE DA COSSEGURO_HIST_PRE");

                /*" -299- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -300- ELSE */
            }
            else
            {


                /*" -301- MOVE SPACES TO WFIM-COSHISPR */
                _.Move("", AREA_DE_WORK.WFIM_COSHISPR);

                /*" -301- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-COSHISPR-DB-DECLARE-1 */
        public void R0200_00_DECLARE_COSHISPR_DB_DECLARE_1()
        {
            /*" -292- EXEC SQL DECLARE C01_COSHISPR CURSOR FOR SELECT COD_EMPRESA , COD_CONGENERE , NUM_APOLICE , NUM_ENDOSSO , NUM_PARCELA , OCORR_HISTORICO , COD_OPERACAO , DATA_MOVIMENTO , TIPO_SEGURO FROM SEGUROS.COSSEGURO_HIST_PRE WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO ORDER BY COD_CONGENERE, NUM_APOLICE, NUM_ENDOSSO, NUM_PARCELA, OCORR_HISTORICO WITH UR END-EXEC. */
            C01_COSHISPR = new AC0810B_C01_COSHISPR(true);
            string GetQuery_C01_COSHISPR()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_CONGENERE
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							OCORR_HISTORICO
							, 
							COD_OPERACAO
							, 
							DATA_MOVIMENTO
							, 
							TIPO_SEGURO 
							FROM SEGUROS.COSSEGURO_HIST_PRE 
							WHERE DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY 
							COD_CONGENERE
							, 
							NUM_APOLICE
							, 
							NUM_ENDOSSO
							, 
							NUM_PARCELA
							, 
							OCORR_HISTORICO";

                return query;
            }
            C01_COSHISPR.GetQueryEvent += GetQuery_C01_COSHISPR;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-COSHISPR-DB-OPEN-1 */
        public void R0200_00_DECLARE_COSHISPR_DB_OPEN_1()
        {
            /*" -294- EXEC SQL OPEN C01_COSHISPR END-EXEC. */

            C01_COSHISPR.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-FETCH-COSHISPR-SECTION */
        private void R0300_00_FETCH_COSHISPR_SECTION()
        {
            /*" -314- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -324- PERFORM R0300_00_FETCH_COSHISPR_DB_FETCH_1 */

            R0300_00_FETCH_COSHISPR_DB_FETCH_1();

            /*" -327- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -328- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -329- MOVE 'S' TO WFIM-COSHISPR */
                    _.Move("S", AREA_DE_WORK.WFIM_COSHISPR);

                    /*" -329- PERFORM R0300_00_FETCH_COSHISPR_DB_CLOSE_1 */

                    R0300_00_FETCH_COSHISPR_DB_CLOSE_1();

                    /*" -331- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -332- ELSE */
                }
                else
                {


                    /*" -333- DISPLAY 'R0300 - ERRO NO FETCH DA COSSEGURO_HIST_PRE' */
                    _.Display($"R0300 - ERRO NO FETCH DA COSSEGURO_HIST_PRE");

                    /*" -334- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -335- END-IF */
                }


                /*" -336- ELSE */
            }
            else
            {


                /*" -337- ADD 1 TO AC-COUNT */
                AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + 1;

                /*" -338- ADD 1 TO AC-L-COSHISPR */
                AREA_DE_WORK.AC_L_COSHISPR.Value = AREA_DE_WORK.AC_L_COSHISPR + 1;

                /*" -340- END-IF. */
            }


            /*" -341- IF AC-COUNT > 99999 */

            if (AREA_DE_WORK.AC_COUNT > 99999)
            {

                /*" -342- MOVE ZEROS TO AC-COUNT */
                _.Move(0, AREA_DE_WORK.AC_COUNT);

                /*" -343- ACCEPT WS-HORA-ACCEPT FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

                /*" -344- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
                _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

                /*" -345- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
                _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

                /*" -346- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
                _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

                /*" -348- DISPLAY 'AC0810B - LIDOS NA COSHISPR  (' AC-L-COSHISPR ' - ' WS-HORA-CURR ')' */

                $"AC0810B - LIDOS NA COSHISPR  ({AREA_DE_WORK.AC_L_COSHISPR} - {AREA_DE_WORK.WS_HORA_CURR})"
                .Display();

                /*" -348- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-FETCH-COSHISPR-DB-FETCH-1 */
        public void R0300_00_FETCH_COSHISPR_DB_FETCH_1()
        {
            /*" -324- EXEC SQL FETCH C01_COSHISPR INTO :COSHISPR-COD-EMPRESA , :COSHISPR-COD-CONGENERE , :COSHISPR-NUM-APOLICE , :COSHISPR-NUM-ENDOSSO , :COSHISPR-NUM-PARCELA , :COSHISPR-OCORR-HISTORICO , :COSHISPR-COD-OPERACAO , :COSHISPR-DATA-MOVIMENTO , :COSHISPR-TIPO-SEGURO END-EXEC. */

            if (C01_COSHISPR.Fetch())
            {
                _.Move(C01_COSHISPR.COSHISPR_COD_EMPRESA, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_EMPRESA);
                _.Move(C01_COSHISPR.COSHISPR_COD_CONGENERE, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE);
                _.Move(C01_COSHISPR.COSHISPR_NUM_APOLICE, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE);
                _.Move(C01_COSHISPR.COSHISPR_NUM_ENDOSSO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO);
                _.Move(C01_COSHISPR.COSHISPR_NUM_PARCELA, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA);
                _.Move(C01_COSHISPR.COSHISPR_OCORR_HISTORICO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO);
                _.Move(C01_COSHISPR.COSHISPR_COD_OPERACAO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO);
                _.Move(C01_COSHISPR.COSHISPR_DATA_MOVIMENTO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO);
                _.Move(C01_COSHISPR.COSHISPR_TIPO_SEGURO, COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO);
            }

        }

        [StopWatch]
        /*" R0300-00-FETCH-COSHISPR-DB-CLOSE-1 */
        public void R0300_00_FETCH_COSHISPR_DB_CLOSE_1()
        {
            /*" -329- EXEC SQL CLOSE C01_COSHISPR END-EXEC */

            C01_COSHISPR.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-REGISTRO-SECTION */
        private void R0400_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -361- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -363- MOVE COSHISPR-COD-CONGENERE TO COSSPREM-COD-CONGENERE. */
            _.Move(COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_CONGENERE);

            /*" -365- MOVE COSHISPR-NUM-APOLICE TO COSSPREM-NUM-APOLICE. */
            _.Move(COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_APOLICE);

            /*" -370- PERFORM R0500-00-PROCESSA-APOLICE UNTIL WFIM-COSHISPR NOT EQUAL SPACES OR COSHISPR-COD-CONGENERE NOT EQUAL COSSPREM-COD-CONGENERE OR COSHISPR-NUM-APOLICE NOT EQUAL COSSPREM-NUM-APOLICE. */

            while (!(!AREA_DE_WORK.WFIM_COSHISPR.IsEmpty() || COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE != COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_CONGENERE || COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE != COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_APOLICE))
            {

                R0500_00_PROCESSA_APOLICE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-PROCESSA-APOLICE-SECTION */
        private void R0500_00_PROCESSA_APOLICE_SECTION()
        {
            /*" -382- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -384- PERFORM R0600-00-SELECT-ENDOSSOS. */

            R0600_00_SELECT_ENDOSSOS_SECTION();

            /*" -386- PERFORM R0700-00-SELECT-PRODUTO. */

            R0700_00_SELECT_PRODUTO_SECTION();

            /*" -388- MOVE COSHISPR-NUM-ENDOSSO TO COSSPREM-NUM-ENDOSSO. */
            _.Move(COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO, COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ENDOSSO);

            /*" -395- PERFORM R0800-00-PROCESSA-ENDOSSO UNTIL WFIM-COSHISPR NOT EQUAL SPACES OR COSHISPR-COD-CONGENERE NOT EQUAL COSSPREM-COD-CONGENERE OR COSHISPR-NUM-APOLICE NOT EQUAL COSSPREM-NUM-APOLICE OR COSHISPR-NUM-ENDOSSO NOT EQUAL COSSPREM-NUM-ENDOSSO. */

            while (!(!AREA_DE_WORK.WFIM_COSHISPR.IsEmpty() || COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE != COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_COD_CONGENERE || COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE != COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_APOLICE || COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO != COSSPREM.DCLCOSSEGURO_PREMIOS.COSSPREM_NUM_ENDOSSO))
            {

                R0800_00_PROCESSA_ENDOSSO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-ENDOSSOS-SECTION */
        private void R0600_00_SELECT_ENDOSSOS_SECTION()
        {
            /*" -408- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -423- PERFORM R0600_00_SELECT_ENDOSSOS_DB_SELECT_1 */

            R0600_00_SELECT_ENDOSSOS_DB_SELECT_1();

            /*" -426- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -427- DISPLAY 'R0600 - ERRO NO SELECT DA ENDOSSOS' */
                _.Display($"R0600 - ERRO NO SELECT DA ENDOSSOS");

                /*" -428- DISPLAY 'CONGENERE   - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -429- DISPLAY 'APOLICE     - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -430- DISPLAY 'ENDOSSO     - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -431- DISPLAY 'PARCELA     - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -432- DISPLAY 'TIPO SEGURO - ' COSHISPR-TIPO-SEGURO */
                _.Display($"TIPO SEGURO - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                /*" -433- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -433- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-ENDOSSOS-DB-SELECT-1 */
        public void R0600_00_SELECT_ENDOSSOS_DB_SELECT_1()
        {
            /*" -423- EXEC SQL SELECT NUM_APOLICE, NUM_ENDOSSO, RAMO_EMISSOR, COD_PRODUTO, DATA_EMISSAO INTO :ENDOSSOS-NUM-APOLICE, :ENDOSSOS-NUM-ENDOSSO, :ENDOSSOS-RAMO-EMISSOR, :ENDOSSOS-COD-PRODUTO, :ENDOSSOS-DATA-EMISSAO FROM SEGUROS.ENDOSSOS WHERE NUM_APOLICE = :COSHISPR-NUM-APOLICE AND NUM_ENDOSSO = :COSHISPR-NUM-ENDOSSO WITH UR END-EXEC. */

            var r0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1 = new R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1()
            {
                COSHISPR_NUM_APOLICE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE.ToString(),
                COSHISPR_NUM_ENDOSSO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ENDOSSOS_NUM_APOLICE, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE);
                _.Move(executed_1.ENDOSSOS_NUM_ENDOSSO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO);
                _.Move(executed_1.ENDOSSOS_RAMO_EMISSOR, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_RAMO_EMISSOR);
                _.Move(executed_1.ENDOSSOS_COD_PRODUTO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO);
                _.Move(executed_1.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-SELECT-PRODUTO-SECTION */
        private void R0700_00_SELECT_PRODUTO_SECTION()
        {
            /*" -446- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -454- PERFORM R0700_00_SELECT_PRODUTO_DB_SELECT_1 */

            R0700_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -457- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -458- DISPLAY 'R0700 - ERRO NO SELECT DA PRODUTO' */
                _.Display($"R0700 - ERRO NO SELECT DA PRODUTO");

                /*" -459- DISPLAY 'CONGENERE   - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -460- DISPLAY 'APOLICE     - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -461- DISPLAY 'ENDOSSO     - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -462- DISPLAY 'PARCELA     - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -463- DISPLAY 'TIPO SEGURO - ' COSHISPR-TIPO-SEGURO */
                _.Display($"TIPO SEGURO - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                /*" -464- DISPLAY 'COD PRODUTO - ' ENDOSSOS-COD-PRODUTO */
                _.Display($"COD PRODUTO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO}");

                /*" -465- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -465- END-IF. */
            }


        }

        [StopWatch]
        /*" R0700-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R0700_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -454- EXEC SQL SELECT COD_EMPRESA, COD_PRODUTO INTO :PRODUTO-COD-EMPRESA, :PRODUTO-COD-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :ENDOSSOS-COD-PRODUTO WITH UR END-EXEC. */

            var r0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                ENDOSSOS_COD_PRODUTO = ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r0700_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-PROCESSA-ENDOSSO-SECTION */
        private void R0800_00_PROCESSA_ENDOSSO_SECTION()
        {
            /*" -478- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -480- IF COSHISPR-COD-EMPRESA = PRODUTO-COD-EMPRESA NEXT SENTENCE */

            if (COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_EMPRESA == PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA)
            {

                /*" -481- ELSE */
            }
            else
            {


                /*" -482- IF COSHISPR-COD-OPERACAO < 0200 */

                if (COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO < 0200)
                {

                    /*" -483- PERFORM R0900-00-UPDATE-COSSPREM */

                    R0900_00_UPDATE_COSSPREM_SECTION();

                    /*" -484- END-IF */
                }


                /*" -485- PERFORM R1000-00-UPDATE-COSHISPR */

                R1000_00_UPDATE_COSHISPR_SECTION();

                /*" -489- END-IF. */
            }


            /*" -489- PERFORM R0300-00-FETCH-COSHISPR. */

            R0300_00_FETCH_COSHISPR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-UPDATE-COSSPREM-SECTION */
        private void R0900_00_UPDATE_COSSPREM_SECTION()
        {
            /*" -502- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -511- PERFORM R0900_00_UPDATE_COSSPREM_DB_UPDATE_1 */

            R0900_00_UPDATE_COSSPREM_DB_UPDATE_1();

            /*" -514- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -515- DISPLAY 'R0900 - ERRO NO UPDATE DA COSSEGURO_PREMIOS' */
                _.Display($"R0900 - ERRO NO UPDATE DA COSSEGURO_PREMIOS");

                /*" -516- DISPLAY 'CONGENERE   - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -517- DISPLAY 'APOLICE     - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -518- DISPLAY 'ENDOSSO     - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -519- DISPLAY 'PARCELA     - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -520- DISPLAY 'TIPO SEGURO - ' COSHISPR-TIPO-SEGURO */
                _.Display($"TIPO SEGURO - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                /*" -521- DISPLAY 'COD PRODUTO - ' ENDOSSOS-COD-PRODUTO */
                _.Display($"COD PRODUTO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO}");

                /*" -522- DISPLAY 'COD EMPRESA - ' PRODUTO-COD-EMPRESA */
                _.Display($"COD EMPRESA - {PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA}");

                /*" -523- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -524- ELSE */
            }
            else
            {


                /*" -525- ADD 1 TO AC-U-COSSPREM */
                AREA_DE_WORK.AC_U_COSSPREM.Value = AREA_DE_WORK.AC_U_COSSPREM + 1;

                /*" -525- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-UPDATE-COSSPREM-DB-UPDATE-1 */
        public void R0900_00_UPDATE_COSSPREM_DB_UPDATE_1()
        {
            /*" -511- EXEC SQL UPDATE SEGUROS.COSSEGURO_PREMIOS SET COD_EMPRESA = :PRODUTO-COD-EMPRESA WHERE COD_CONGENERE = :COSHISPR-COD-CONGENERE AND NUM_APOLICE = :COSHISPR-NUM-APOLICE AND NUM_ENDOSSO = :COSHISPR-NUM-ENDOSSO AND NUM_PARCELA = :COSHISPR-NUM-PARCELA AND TIPO_SEGURO = :COSHISPR-TIPO-SEGURO AND COD_EMPRESA = :COSHISPR-COD-EMPRESA END-EXEC. */

            var r0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1 = new R0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1()
            {
                PRODUTO_COD_EMPRESA = PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.ToString(),
                COSHISPR_COD_CONGENERE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE.ToString(),
                COSHISPR_NUM_APOLICE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE.ToString(),
                COSHISPR_NUM_ENDOSSO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO.ToString(),
                COSHISPR_NUM_PARCELA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA.ToString(),
                COSHISPR_TIPO_SEGURO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO.ToString(),
                COSHISPR_COD_EMPRESA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_EMPRESA.ToString(),
            };

            R0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1.Execute(r0900_00_UPDATE_COSSPREM_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-UPDATE-COSHISPR-SECTION */
        private void R1000_00_UPDATE_COSHISPR_SECTION()
        {
            /*" -538- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -550- PERFORM R1000_00_UPDATE_COSHISPR_DB_UPDATE_1 */

            R1000_00_UPDATE_COSHISPR_DB_UPDATE_1();

            /*" -553- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -554- DISPLAY 'R1000 - ERRO NO UPDATE DA COSSEGURO_HIST_PRE' */
                _.Display($"R1000 - ERRO NO UPDATE DA COSSEGURO_HIST_PRE");

                /*" -555- DISPLAY 'CONGENERE   - ' COSHISPR-COD-CONGENERE */
                _.Display($"CONGENERE   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE}");

                /*" -556- DISPLAY 'APOLICE     - ' COSHISPR-NUM-APOLICE */
                _.Display($"APOLICE     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE}");

                /*" -557- DISPLAY 'ENDOSSO     - ' COSHISPR-NUM-ENDOSSO */
                _.Display($"ENDOSSO     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO}");

                /*" -558- DISPLAY 'PARCELA     - ' COSHISPR-NUM-PARCELA */
                _.Display($"PARCELA     - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA}");

                /*" -559- DISPLAY 'OCOR HIST   - ' COSHISPR-OCORR-HISTORICO */
                _.Display($"OCOR HIST   - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO}");

                /*" -560- DISPLAY 'COD OPER    - ' COSHISPR-COD-OPERACAO */
                _.Display($"COD OPER    - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO}");

                /*" -561- DISPLAY 'DATA MOVTO  - ' COSHISPR-DATA-MOVIMENTO */
                _.Display($"DATA MOVTO  - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO}");

                /*" -562- DISPLAY 'TIPO SEGURO - ' COSHISPR-TIPO-SEGURO */
                _.Display($"TIPO SEGURO - {COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO}");

                /*" -563- DISPLAY 'COD PRODUTO - ' ENDOSSOS-COD-PRODUTO */
                _.Display($"COD PRODUTO - {ENDOSSOS.DCLENDOSSOS.ENDOSSOS_COD_PRODUTO}");

                /*" -564- DISPLAY 'COD EMPRESA - ' PRODUTO-COD-EMPRESA */
                _.Display($"COD EMPRESA - {PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA}");

                /*" -565- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -566- ELSE */
            }
            else
            {


                /*" -567- ADD 1 TO AC-U-COSHISPR */
                AREA_DE_WORK.AC_U_COSHISPR.Value = AREA_DE_WORK.AC_U_COSHISPR + 1;

                /*" -567- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-00-UPDATE-COSHISPR-DB-UPDATE-1 */
        public void R1000_00_UPDATE_COSHISPR_DB_UPDATE_1()
        {
            /*" -550- EXEC SQL UPDATE SEGUROS.COSSEGURO_HIST_PRE SET COD_EMPRESA = :PRODUTO-COD-EMPRESA WHERE COD_CONGENERE = :COSHISPR-COD-CONGENERE AND NUM_APOLICE = :COSHISPR-NUM-APOLICE AND NUM_ENDOSSO = :COSHISPR-NUM-ENDOSSO AND NUM_PARCELA = :COSHISPR-NUM-PARCELA AND OCORR_HISTORICO = :COSHISPR-OCORR-HISTORICO AND COD_OPERACAO = :COSHISPR-COD-OPERACAO AND DATA_MOVIMENTO = :COSHISPR-DATA-MOVIMENTO AND TIPO_SEGURO = :COSHISPR-TIPO-SEGURO AND COD_EMPRESA = :COSHISPR-COD-EMPRESA END-EXEC. */

            var r1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1 = new R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1()
            {
                PRODUTO_COD_EMPRESA = PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.ToString(),
                COSHISPR_OCORR_HISTORICO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_OCORR_HISTORICO.ToString(),
                COSHISPR_DATA_MOVIMENTO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_DATA_MOVIMENTO.ToString(),
                COSHISPR_COD_CONGENERE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_CONGENERE.ToString(),
                COSHISPR_COD_OPERACAO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_OPERACAO.ToString(),
                COSHISPR_NUM_APOLICE = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_APOLICE.ToString(),
                COSHISPR_NUM_ENDOSSO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_ENDOSSO.ToString(),
                COSHISPR_NUM_PARCELA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_NUM_PARCELA.ToString(),
                COSHISPR_TIPO_SEGURO = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_TIPO_SEGURO.ToString(),
                COSHISPR_COD_EMPRESA = COSHISPR.DCLCOSSEGURO_HIST_PRE.COSHISPR_COD_EMPRESA.ToString(),
            };

            R1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1.Execute(r1000_00_UPDATE_COSHISPR_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -581- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -582- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -583- DISPLAY '* AC0810B - ATUALIZA CODIGO DE EMPRESA     *' . */
            _.Display($"* AC0810B - ATUALIZA CODIGO DE EMPRESA     *");

            /*" -584- DISPLAY '* -------                     VIDA         *' . */
            _.Display($"* -------                     VIDA         *");

            /*" -585- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -586- DISPLAY '*    NAO HOUVE MOVIMENTACAO NO PERIODO     *' . */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NO PERIODO     *");

            /*" -587- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -587- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -600- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -602- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -602- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -606- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -606- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}