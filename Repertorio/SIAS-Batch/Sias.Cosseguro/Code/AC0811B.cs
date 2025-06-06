using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Dclgens;
using Sias.Cosseguro.DB2.AC0811B;

namespace Code
{
    public class AC0811B
    {
        public bool IsCall { get; set; }

        public AC0811B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------------------*                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA .......... COSSEGURO CEDIDO                          *      */
        /*"      *   PROGRAMA ......... AC0811B                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ......... GILSON PINTO                              *      */
        /*"      *   PROGRAMADOR ...... WELLINGTON F R C VERAS                    *      */
        /*"      *   DATA CODIFICACAO . SETEMBRO DE 2018                          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO . ATUALIZA O CODIGO DE EMPRESA ATRAVES DO COD PRODUTO *      */
        /*"      *          - NO CONTA CORRENTE COSSEGURO CEDIDO DE SINISTROS     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            VIEW                 ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          SISTEMAS             INPUT   *      */
        /*"      * COSSEGURO_HIST_SIN                COSHISSI             I-O     *      */
        /*"      * SINISTRO_MESTRE                   SINISMES             INPUT   *      */
        /*"      * PRODUTO                           PRODUTO              INPUT   *      */
        /*"      * COSSEGURO_SINISTRO                COSSESIN             OUTPUT  *      */
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
        public AC0811B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0811B_AREA_DE_WORK();
        public class AC0811B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WFIM-COSHISSI       PIC  X(001)      VALUE SPACES.*/
            public StringBasis WFIM_COSHISSI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        AC-COUNT            PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_COUNT { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-L-COSHISSI       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_L_COSHISSI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-U-COSSESIN       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_COSSESIN { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        AC-U-COSHISSI       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis AC_U_COSHISSI { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        WS-DATA-ACCEPT.*/
            public AC0811B_WS_DATA_ACCEPT WS_DATA_ACCEPT { get; set; } = new AC0811B_WS_DATA_ACCEPT();
            public class AC0811B_WS_DATA_ACCEPT : VarBasis
            {
                /*"    10      WS-ANO-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_ANO_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-MES-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_MES_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-DIA-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_DIA_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WS-HORA-ACCEPT.*/
            }
            public AC0811B_WS_HORA_ACCEPT WS_HORA_ACCEPT { get; set; } = new AC0811B_WS_HORA_ACCEPT();
            public class AC0811B_WS_HORA_ACCEPT : VarBasis
            {
                /*"    10      WS-HOR-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_HOR_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-MIN-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_MIN_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WS-SEG-ACCEPT       PIC  9(002)      VALUE ZEROS.*/
                public IntBasis WS_SEG_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05        WS-DATA-CURR.*/
            }
            public AC0811B_WS_DATA_CURR WS_DATA_CURR { get; set; } = new AC0811B_WS_DATA_CURR();
            public class AC0811B_WS_DATA_CURR : VarBasis
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
            public AC0811B_WS_HORA_CURR WS_HORA_CURR { get; set; } = new AC0811B_WS_HORA_CURR();
            public class AC0811B_WS_HORA_CURR : VarBasis
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
            private _REDEF_AC0811B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_AC0811B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_AC0811B_FILLER_4(); _.Move(WDATA_COBOL, _filler_4); VarBasis.RedefinePassValue(WDATA_COBOL, _filler_4, WDATA_COBOL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_COBOL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_COBOL); }
            }  //Redefines
            public class _REDEF_AC0811B_FILLER_4 : VarBasis
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

                public _REDEF_AC0811B_FILLER_4()
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
        public AC0811B_WABEND WABEND { get; set; } = new AC0811B_WABEND();
        public class AC0811B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)      VALUE           ' AC0811B  '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0811B  ");
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
        public Dclgens.COSHISSI COSHISSI { get; set; } = new Dclgens.COSHISSI();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.COSSESIN COSSESIN { get; set; } = new Dclgens.COSSESIN();
        public AC0811B_C01_COSHISSI C01_COSHISSI { get; set; } = new AC0811B_C01_COSHISSI();
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

            /*" -172- DISPLAY '  Programa .....: AC0811B: ATUALIZ. COD EMPR VIDA' . */
            _.Display($"  Programa .....: AC0811B: ATUALIZ. COD EMPR VIDA");

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

            /*" -196- DISPLAY 'AC0811B - INICIO DE EXECUCAO (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"AC0811B - INICIO DE EXECUCAO ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

            /*" -198- INITIALIZE DCLCOSSEGURO-SINISTRO. */
            _.Initialize(
                COSSESIN.DCLCOSSEGURO_SINISTRO
            );

            /*" -200- INITIALIZE DCLCOSSEGURO-HIST-SIN. */
            _.Initialize(
                COSHISSI.DCLCOSSEGURO_HIST_SIN
            );

            /*" -202- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -204- PERFORM R0200-00-DECLARE-COSHISSI. */

            R0200_00_DECLARE_COSHISSI_SECTION();

            /*" -206- PERFORM R0300-00-FETCH-COSHISSI. */

            R0300_00_FETCH_COSHISSI_SECTION();

            /*" -207- IF WFIM-COSHISSI NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_COSHISSI.IsEmpty())
            {

                /*" -208- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -209- ELSE */
            }
            else
            {


                /*" -211- PERFORM R0400-00-PROCESSA-REGISTRO UNTIL WFIM-COSHISSI NOT EQUAL SPACES */

                while (!(!AREA_DE_WORK.WFIM_COSHISSI.IsEmpty()))
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
            /*" -216- DISPLAY 'REG. LIDOS NA COSHISSI  - ' AC-L-COSHISSI. */
            _.Display($"REG. LIDOS NA COSHISSI  - {AREA_DE_WORK.AC_L_COSHISSI}");

            /*" -217- DISPLAY 'REG. ALTER NA COSSESIN  - ' AC-U-COSSESIN. */
            _.Display($"REG. ALTER NA COSSESIN  - {AREA_DE_WORK.AC_U_COSSESIN}");

            /*" -219- DISPLAY 'REG. ALTER NA COSHISSI  - ' AC-U-COSHISSI. */
            _.Display($"REG. ALTER NA COSHISSI  - {AREA_DE_WORK.AC_U_COSHISSI}");

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

            /*" -230- DISPLAY 'AC0811B - FINAL DE EXECUCAO  (' WS-DATA-CURR ' - ' WS-HORA-CURR ')' . */

            $"AC0811B - FINAL DE EXECUCAO  ({AREA_DE_WORK.WS_DATA_CURR} - {AREA_DE_WORK.WS_HORA_CURR})"
            .Display();

            /*" -232- DISPLAY '*---   AC0811B  -  FIM  NORMAL   ---*' . */
            _.Display($"*---   AC0811B  -  FIM  NORMAL   ---*");

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
        /*" R0200-00-DECLARE-COSHISSI-SECTION */
        private void R0200_00_DECLARE_COSHISSI_SECTION()
        {
            /*" -273- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -290- PERFORM R0200_00_DECLARE_COSHISSI_DB_DECLARE_1 */

            R0200_00_DECLARE_COSHISSI_DB_DECLARE_1();

            /*" -292- PERFORM R0200_00_DECLARE_COSHISSI_DB_OPEN_1 */

            R0200_00_DECLARE_COSHISSI_DB_OPEN_1();

            /*" -295- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -296- DISPLAY 'R0200 - ERRO NO DECLARE DA COSSEGURO_HIST_SIN' */
                _.Display($"R0200 - ERRO NO DECLARE DA COSSEGURO_HIST_SIN");

                /*" -297- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -298- ELSE */
            }
            else
            {


                /*" -299- MOVE SPACES TO WFIM-COSHISSI */
                _.Move("", AREA_DE_WORK.WFIM_COSHISSI);

                /*" -299- END-IF. */
            }


        }

        [StopWatch]
        /*" R0200-00-DECLARE-COSHISSI-DB-DECLARE-1 */
        public void R0200_00_DECLARE_COSHISSI_DB_DECLARE_1()
        {
            /*" -290- EXEC SQL DECLARE C01_COSHISSI CURSOR FOR SELECT COD_EMPRESA, COD_CONGENERE, NUM_SINISTRO, DATA_MOVIMENTO, OCORR_HISTORICO, COD_OPERACAO, TIPO_SEGURO FROM SEGUROS.COSSEGURO_HIST_SIN WHERE DATA_MOVIMENTO = :SISTEMAS-DATA-MOV-ABERTO ORDER BY COD_CONGENERE, NUM_SINISTRO, DATA_MOVIMENTO, OCORR_HISTORICO, COD_OPERACAO WITH UR END-EXEC. */
            C01_COSHISSI = new AC0811B_C01_COSHISSI(true);
            string GetQuery_C01_COSHISSI()
            {
                var query = @$"SELECT COD_EMPRESA
							, 
							COD_CONGENERE
							, 
							NUM_SINISTRO
							, 
							DATA_MOVIMENTO
							, 
							OCORR_HISTORICO
							, 
							COD_OPERACAO
							, 
							TIPO_SEGURO 
							FROM SEGUROS.COSSEGURO_HIST_SIN 
							WHERE DATA_MOVIMENTO = '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' 
							ORDER BY 
							COD_CONGENERE
							, 
							NUM_SINISTRO
							, 
							DATA_MOVIMENTO
							, 
							OCORR_HISTORICO
							, 
							COD_OPERACAO";

                return query;
            }
            C01_COSHISSI.GetQueryEvent += GetQuery_C01_COSHISSI;

        }

        [StopWatch]
        /*" R0200-00-DECLARE-COSHISSI-DB-OPEN-1 */
        public void R0200_00_DECLARE_COSHISSI_DB_OPEN_1()
        {
            /*" -292- EXEC SQL OPEN C01_COSHISSI END-EXEC. */

            C01_COSHISSI.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-FETCH-COSHISSI-SECTION */
        private void R0300_00_FETCH_COSHISSI_SECTION()
        {
            /*" -312- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -320- PERFORM R0300_00_FETCH_COSHISSI_DB_FETCH_1 */

            R0300_00_FETCH_COSHISSI_DB_FETCH_1();

            /*" -323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -324- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -325- MOVE 'S' TO WFIM-COSHISSI */
                    _.Move("S", AREA_DE_WORK.WFIM_COSHISSI);

                    /*" -325- PERFORM R0300_00_FETCH_COSHISSI_DB_CLOSE_1 */

                    R0300_00_FETCH_COSHISSI_DB_CLOSE_1();

                    /*" -327- GO TO R0300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;

                    /*" -328- ELSE */
                }
                else
                {


                    /*" -329- DISPLAY 'R0300 - ERRO NO FETCH DA COSSEGURO_HIST_SIN' */
                    _.Display($"R0300 - ERRO NO FETCH DA COSSEGURO_HIST_SIN");

                    /*" -330- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -331- END-IF */
                }


                /*" -332- ELSE */
            }
            else
            {


                /*" -333- ADD 1 TO AC-COUNT */
                AREA_DE_WORK.AC_COUNT.Value = AREA_DE_WORK.AC_COUNT + 1;

                /*" -334- ADD 1 TO AC-L-COSHISSI */
                AREA_DE_WORK.AC_L_COSHISSI.Value = AREA_DE_WORK.AC_L_COSHISSI + 1;

                /*" -336- END-IF. */
            }


            /*" -337- IF AC-COUNT > 99999 */

            if (AREA_DE_WORK.AC_COUNT > 99999)
            {

                /*" -338- MOVE ZEROS TO AC-COUNT */
                _.Move(0, AREA_DE_WORK.AC_COUNT);

                /*" -339- ACCEPT WS-HORA-ACCEPT FROM TIME */
                _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WS_HORA_ACCEPT);

                /*" -340- MOVE WS-HOR-ACCEPT TO WS-HOR-CURR */
                _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_HOR_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_HOR_CURR);

                /*" -341- MOVE WS-MIN-ACCEPT TO WS-MIN-CURR */
                _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_MIN_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_MIN_CURR);

                /*" -342- MOVE WS-SEG-ACCEPT TO WS-SEG-CURR */
                _.Move(AREA_DE_WORK.WS_HORA_ACCEPT.WS_SEG_ACCEPT, AREA_DE_WORK.WS_HORA_CURR.WS_SEG_CURR);

                /*" -344- DISPLAY 'AC0811B - LIDOS NA COSHISSI  (' AC-L-COSHISSI ' - ' WS-HORA-CURR ')' */

                $"AC0811B - LIDOS NA COSHISSI  ({AREA_DE_WORK.AC_L_COSHISSI} - {AREA_DE_WORK.WS_HORA_CURR})"
                .Display();

                /*" -344- END-IF. */
            }


        }

        [StopWatch]
        /*" R0300-00-FETCH-COSHISSI-DB-FETCH-1 */
        public void R0300_00_FETCH_COSHISSI_DB_FETCH_1()
        {
            /*" -320- EXEC SQL FETCH C01_COSHISSI INTO :COSHISSI-COD-EMPRESA, :COSHISSI-COD-CONGENERE, :COSHISSI-NUM-SINISTRO, :COSHISSI-DATA-MOVIMENTO, :COSHISSI-OCORR-HISTORICO, :COSHISSI-COD-OPERACAO, :COSHISSI-TIPO-SEGURO END-EXEC. */

            if (C01_COSHISSI.Fetch())
            {
                _.Move(C01_COSHISSI.COSHISSI_COD_EMPRESA, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_EMPRESA);
                _.Move(C01_COSHISSI.COSHISSI_COD_CONGENERE, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE);
                _.Move(C01_COSHISSI.COSHISSI_NUM_SINISTRO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO);
                _.Move(C01_COSHISSI.COSHISSI_DATA_MOVIMENTO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO);
                _.Move(C01_COSHISSI.COSHISSI_OCORR_HISTORICO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO);
                _.Move(C01_COSHISSI.COSHISSI_COD_OPERACAO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO);
                _.Move(C01_COSHISSI.COSHISSI_TIPO_SEGURO, COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO);
            }

        }

        [StopWatch]
        /*" R0300-00-FETCH-COSHISSI-DB-CLOSE-1 */
        public void R0300_00_FETCH_COSHISSI_DB_CLOSE_1()
        {
            /*" -325- EXEC SQL CLOSE C01_COSHISSI END-EXEC */

            C01_COSHISSI.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-PROCESSA-REGISTRO-SECTION */
        private void R0400_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -357- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -359- PERFORM R0500-00-SELECT-SINISMES. */

            R0500_00_SELECT_SINISMES_SECTION();

            /*" -361- PERFORM R0600-00-SELECT-PRODUTO. */

            R0600_00_SELECT_PRODUTO_SECTION();

            /*" -363- MOVE COSHISSI-COD-CONGENERE TO COSSESIN-COD-CONGENERE. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE, COSSESIN.DCLCOSSEGURO_SINISTRO.COSSESIN_COD_CONGENERE);

            /*" -365- MOVE COSHISSI-NUM-SINISTRO TO COSSESIN-NUM-SINISTRO. */
            _.Move(COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO, COSSESIN.DCLCOSSEGURO_SINISTRO.COSSESIN_NUM_SINISTRO);

            /*" -370- PERFORM R0700-00-PROCESSA-NR-SINISTRO UNTIL WFIM-COSHISSI NOT EQUAL SPACES OR COSHISSI-COD-CONGENERE NOT EQUAL COSSESIN-COD-CONGENERE OR COSHISSI-NUM-SINISTRO NOT EQUAL COSSESIN-NUM-SINISTRO. */

            while (!(!AREA_DE_WORK.WFIM_COSHISSI.IsEmpty() || COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE != COSSESIN.DCLCOSSEGURO_SINISTRO.COSSESIN_COD_CONGENERE || COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO != COSSESIN.DCLCOSSEGURO_SINISTRO.COSSESIN_NUM_SINISTRO))
            {

                R0700_00_PROCESSA_NR_SINISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-SELECT-SINISMES-SECTION */
        private void R0500_00_SELECT_SINISMES_SECTION()
        {
            /*" -382- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -390- PERFORM R0500_00_SELECT_SINISMES_DB_SELECT_1 */

            R0500_00_SELECT_SINISMES_DB_SELECT_1();

            /*" -393- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -394- DISPLAY 'R0500 - ERRO NO SELECT DA SINISTRO_MESTRE' */
                _.Display($"R0500 - ERRO NO SELECT DA SINISTRO_MESTRE");

                /*" -395- DISPLAY 'CONGENERE - ' COSHISSI-COD-CONGENERE */
                _.Display($"CONGENERE - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE}");

                /*" -396- DISPLAY 'SINISTRO  - ' COSHISSI-NUM-SINISTRO */
                _.Display($"SINISTRO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -397- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -397- END-IF. */
            }


        }

        [StopWatch]
        /*" R0500-00-SELECT-SINISMES-DB-SELECT-1 */
        public void R0500_00_SELECT_SINISMES_DB_SELECT_1()
        {
            /*" -390- EXEC SQL SELECT NUM_APOLICE, COD_PRODUTO INTO :SINISMES-NUM-APOLICE, :SINISMES-COD-PRODUTO FROM SEGUROS.SINISTRO_MESTRE WHERE NUM_APOL_SINISTRO = :COSHISSI-NUM-SINISTRO WITH UR END-EXEC. */

            var r0500_00_SELECT_SINISMES_DB_SELECT_1_Query1 = new R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1()
            {
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
            };

            var executed_1 = R0500_00_SELECT_SINISMES_DB_SELECT_1_Query1.Execute(r0500_00_SELECT_SINISMES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(executed_1.SINISMES_COD_PRODUTO, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0600-00-SELECT-PRODUTO-SECTION */
        private void R0600_00_SELECT_PRODUTO_SECTION()
        {
            /*" -410- MOVE '060' TO WNR-EXEC-SQL. */
            _.Move("060", WABEND.WNR_EXEC_SQL);

            /*" -418- PERFORM R0600_00_SELECT_PRODUTO_DB_SELECT_1 */

            R0600_00_SELECT_PRODUTO_DB_SELECT_1();

            /*" -421- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -422- DISPLAY 'R0600 - ERRO NO SELECT DA PRODUTO' */
                _.Display($"R0600 - ERRO NO SELECT DA PRODUTO");

                /*" -423- DISPLAY 'CONGENERE - ' COSHISSI-COD-CONGENERE */
                _.Display($"CONGENERE - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE}");

                /*" -424- DISPLAY 'SINISTRO  - ' COSHISSI-NUM-SINISTRO */
                _.Display($"SINISTRO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -425- DISPLAY 'APOLICE   - ' SINISMES-NUM-APOLICE */
                _.Display($"APOLICE   - {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -426- DISPLAY 'COD PRODU - ' SINISMES-COD-PRODUTO */
                _.Display($"COD PRODU - {SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO}");

                /*" -427- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -427- END-IF. */
            }


        }

        [StopWatch]
        /*" R0600-00-SELECT-PRODUTO-DB-SELECT-1 */
        public void R0600_00_SELECT_PRODUTO_DB_SELECT_1()
        {
            /*" -418- EXEC SQL SELECT COD_EMPRESA, COD_PRODUTO INTO :PRODUTO-COD-EMPRESA, :PRODUTO-COD-PRODUTO FROM SEGUROS.PRODUTO WHERE COD_PRODUTO = :SINISMES-COD-PRODUTO WITH UR END-EXEC. */

            var r0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1 = new R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1()
            {
                SINISMES_COD_PRODUTO = SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_PRODUTO.ToString(),
            };

            var executed_1 = R0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1.Execute(r0600_00_SELECT_PRODUTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUTO_COD_EMPRESA, PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA);
                _.Move(executed_1.PRODUTO_COD_PRODUTO, PRODUTO.DCLPRODUTO.PRODUTO_COD_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_99_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROCESSA-NR-SINISTRO-SECTION */
        private void R0700_00_PROCESSA_NR_SINISTRO_SECTION()
        {
            /*" -440- MOVE '070' TO WNR-EXEC-SQL. */
            _.Move("070", WABEND.WNR_EXEC_SQL);

            /*" -442- IF COSHISSI-COD-EMPRESA = PRODUTO-COD-EMPRESA NEXT SENTENCE */

            if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_EMPRESA == PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA)
            {

                /*" -443- ELSE */
            }
            else
            {


                /*" -444- IF COSHISSI-COD-OPERACAO = 0101 */

                if (COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO == 0101)
                {

                    /*" -445- PERFORM R0800-00-UPDATE-COSSESIN */

                    R0800_00_UPDATE_COSSESIN_SECTION();

                    /*" -446- END-IF */
                }


                /*" -447- PERFORM R0900-00-UPDATE-COSHISSI */

                R0900_00_UPDATE_COSHISSI_SECTION();

                /*" -451- END-IF. */
            }


            /*" -451- PERFORM R0300-00-FETCH-COSHISSI. */

            R0300_00_FETCH_COSHISSI_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_99_SAIDA*/

        [StopWatch]
        /*" R0800-00-UPDATE-COSSESIN-SECTION */
        private void R0800_00_UPDATE_COSSESIN_SECTION()
        {
            /*" -464- MOVE '080' TO WNR-EXEC-SQL. */
            _.Move("080", WABEND.WNR_EXEC_SQL);

            /*" -471- PERFORM R0800_00_UPDATE_COSSESIN_DB_UPDATE_1 */

            R0800_00_UPDATE_COSSESIN_DB_UPDATE_1();

            /*" -474- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -475- DISPLAY 'R0800 - ERRO NO UPDATE DA COSSEGURO_SINISTRO' */
                _.Display($"R0800 - ERRO NO UPDATE DA COSSEGURO_SINISTRO");

                /*" -476- DISPLAY 'CONGENERE    - ' COSHISSI-COD-CONGENERE */
                _.Display($"CONGENERE    - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE}");

                /*" -477- DISPLAY 'NUM SINISTRO - ' COSHISSI-NUM-SINISTRO */
                _.Display($"NUM SINISTRO - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -478- DISPLAY 'TIPO SEGURO  - ' COSHISSI-TIPO-SEGURO */
                _.Display($"TIPO SEGURO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO}");

                /*" -479- DISPLAY 'NUM APOLICE  - ' SINISMES-NUM-APOLICE */
                _.Display($"NUM APOLICE  - {SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE}");

                /*" -480- DISPLAY 'COD EMPRESA  - ' PRODUTO-COD-EMPRESA */
                _.Display($"COD EMPRESA  - {PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA}");

                /*" -481- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -482- ELSE */
            }
            else
            {


                /*" -483- ADD 1 TO AC-U-COSSESIN */
                AREA_DE_WORK.AC_U_COSSESIN.Value = AREA_DE_WORK.AC_U_COSSESIN + 1;

                /*" -483- END-IF. */
            }


        }

        [StopWatch]
        /*" R0800-00-UPDATE-COSSESIN-DB-UPDATE-1 */
        public void R0800_00_UPDATE_COSSESIN_DB_UPDATE_1()
        {
            /*" -471- EXEC SQL UPDATE SEGUROS.COSSEGURO_SINISTRO SET COD_EMPRESA = :PRODUTO-COD-EMPRESA WHERE COD_CONGENERE = :COSHISSI-COD-CONGENERE AND NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND TIPO_SEGURO = :COSHISSI-TIPO-SEGURO AND COD_EMPRESA = :COSHISSI-COD-EMPRESA END-EXEC. */

            var r0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1 = new R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1()
            {
                PRODUTO_COD_EMPRESA = PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.ToString(),
                COSHISSI_COD_CONGENERE = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE.ToString(),
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                COSHISSI_TIPO_SEGURO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO.ToString(),
                COSHISSI_COD_EMPRESA = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_EMPRESA.ToString(),
            };

            R0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1.Execute(r0800_00_UPDATE_COSSESIN_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-UPDATE-COSHISSI-SECTION */
        private void R0900_00_UPDATE_COSHISSI_SECTION()
        {
            /*" -496- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -506- PERFORM R0900_00_UPDATE_COSHISSI_DB_UPDATE_1 */

            R0900_00_UPDATE_COSHISSI_DB_UPDATE_1();

            /*" -509- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -510- DISPLAY 'R0900 - ERRO NO UPDATE DA COSSEGURO_HIST_SIN' */
                _.Display($"R0900 - ERRO NO UPDATE DA COSSEGURO_HIST_SIN");

                /*" -511- DISPLAY 'CONGENERE   - ' COSHISSI-COD-CONGENERE */
                _.Display($"CONGENERE   - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE}");

                /*" -512- DISPLAY 'SINISTRO    - ' COSHISSI-NUM-SINISTRO */
                _.Display($"SINISTRO    - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO}");

                /*" -513- DISPLAY 'DATA MOVTO  - ' COSHISSI-DATA-MOVIMENTO */
                _.Display($"DATA MOVTO  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO}");

                /*" -514- DISPLAY 'OCORR HIST  - ' COSHISSI-OCORR-HISTORICO */
                _.Display($"OCORR HIST  - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO}");

                /*" -515- DISPLAY 'OPERACAO    - ' COSHISSI-COD-OPERACAO */
                _.Display($"OPERACAO    - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO}");

                /*" -516- DISPLAY 'TIPO SEGURO - ' COSHISSI-TIPO-SEGURO */
                _.Display($"TIPO SEGURO - {COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO}");

                /*" -517- DISPLAY 'COD EMPRESA - ' PRODUTO-COD-EMPRESA */
                _.Display($"COD EMPRESA - {PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA}");

                /*" -518- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -519- ELSE */
            }
            else
            {


                /*" -520- ADD 1 TO AC-U-COSHISSI */
                AREA_DE_WORK.AC_U_COSHISSI.Value = AREA_DE_WORK.AC_U_COSHISSI + 1;

                /*" -520- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-UPDATE-COSHISSI-DB-UPDATE-1 */
        public void R0900_00_UPDATE_COSHISSI_DB_UPDATE_1()
        {
            /*" -506- EXEC SQL UPDATE SEGUROS.COSSEGURO_HIST_SIN SET COD_EMPRESA = :PRODUTO-COD-EMPRESA WHERE COD_CONGENERE = :COSHISSI-COD-CONGENERE AND NUM_SINISTRO = :COSHISSI-NUM-SINISTRO AND DATA_MOVIMENTO = :COSHISSI-DATA-MOVIMENTO AND OCORR_HISTORICO = :COSHISSI-OCORR-HISTORICO AND COD_OPERACAO = :COSHISSI-COD-OPERACAO AND TIPO_SEGURO = :COSHISSI-TIPO-SEGURO AND COD_EMPRESA = :COSHISSI-COD-EMPRESA END-EXEC. */

            var r0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1 = new R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1()
            {
                PRODUTO_COD_EMPRESA = PRODUTO.DCLPRODUTO.PRODUTO_COD_EMPRESA.ToString(),
                COSHISSI_OCORR_HISTORICO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_OCORR_HISTORICO.ToString(),
                COSHISSI_DATA_MOVIMENTO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_DATA_MOVIMENTO.ToString(),
                COSHISSI_COD_CONGENERE = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_CONGENERE.ToString(),
                COSHISSI_NUM_SINISTRO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_NUM_SINISTRO.ToString(),
                COSHISSI_COD_OPERACAO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_OPERACAO.ToString(),
                COSHISSI_TIPO_SEGURO = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_TIPO_SEGURO.ToString(),
                COSHISSI_COD_EMPRESA = COSHISSI.DCLCOSSEGURO_HIST_SIN.COSHISSI_COD_EMPRESA.ToString(),
            };

            R0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1.Execute(r0900_00_UPDATE_COSHISSI_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -534- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -535- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -536- DISPLAY '* AC0811B - ATUALIZA CODIGO DE EMPRESA     *' . */
            _.Display($"* AC0811B - ATUALIZA CODIGO DE EMPRESA     *");

            /*" -537- DISPLAY '* -------                     VIDA         *' . */
            _.Display($"* -------                     VIDA         *");

            /*" -538- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -539- DISPLAY '*    NAO HOUVE MOVIMENTACAO NO PERIODO     *' . */
            _.Display($"*    NAO HOUVE MOVIMENTACAO NO PERIODO     *");

            /*" -540- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -540- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -553- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -555- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -555- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -559- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -559- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}