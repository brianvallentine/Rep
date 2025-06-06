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
using Sias.VidaEmpresarial.DB2.VE0031B;

namespace Code
{
    public class VE0031B
    {
        public bool IsCall { get; set; }

        public VE0031B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  VIDA EM GRUPO                      *      */
        /*"      *   PROGRAMA ...............  VE0031B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  MANOEL MESSIAS                     *      */
        /*"      *   PROGRAMADOR ............  MANOEL MESSIAS                     *      */
        /*"      *   DATA CODIFICACAO .......  18/07/2002                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  EXCLUSAO DE SEGURADOS              *      */
        /*"      *                             GERA MOVIMENTO DE CANCELAMENTO DE  *      */
        /*"      *                             SEGURADOS NA TABELA V0MOVIMENTO A  *      */
        /*"      *                             PARTIR DE SOLICITACAO CADASTRADA NA*      */
        /*"      *                             TABELA V0RELATORIOS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 01                                                    *      */
        /*"      *             - CAD 40.043                                       *      */
        /*"      *               CORRECAO DO ABEND SQLCODE = 100 OCORRIDO NA      *      */
        /*"      *               TABELA SEGUROS.FATURAS_CONTROLE                  *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/03/2010 - FAST COMPUTER - MARCO PAIVA                  *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         V1PAR-RAMO-VG       PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PAR-RAMO-AP       PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V1PAR-RAMO-PST      PIC S9(004)      COMP.*/
        public IntBasis V1PAR_RAMO_PST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0COBA-IMPMORNATU   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPMORACID   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPINVPERM   PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-IMPDIT       PIC S9(013)V99   VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0COBA-PRMVG        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77         V0COBA-PRMAP        PIC S9(010)V9(5) VALUE +0 COMP-3.*/
        public DoubleBasis V0COBA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"01           AREA-DE-WORK.*/
        public VE0031B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new VE0031B_AREA_DE_WORK();
        public class VE0031B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WHOST-DT-INICIO            PIC X(010).*/
            public StringBasis WHOST_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05         WACC-LIDOS        PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-LIDOS-REL    PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_LIDOS_REL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WACC-GRAVADOS     PIC  9(006)       VALUE  ZEROS.*/
            public IntBasis WACC_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WS-COD-SUBGRUPO     PIC 9(005)  VALUE ZEROS.*/
            public IntBasis WS_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"  05         WFIM-CSEGURA        PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_CSEGURA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05         WFIM-V0RELATORIOS   PIC X(001)  VALUE SPACES.*/
            public StringBasis WFIM_V0RELATORIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05        WABEND.*/
            public VE0031B_WABEND WABEND { get; set; } = new VE0031B_WABEND();
            public class VE0031B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'VE0031B '.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VE0031B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0001'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0001");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.CONTACOR CONTACOR { get; set; } = new Dclgens.CONTACOR();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.RELATORI RELATORI { get; set; } = new Dclgens.RELATORI();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public VE0031B_CRELAT CRELAT { get; set; } = new VE0031B_CRELAT();
        public VE0031B_CSEGURA CSEGURA { get; set; } = new VE0031B_CSEGURA();
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
            /*" -129- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -132- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -135- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -138- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -139- DISPLAY 'PROGRAMA EM EXECUCAO VE0031B  ' . */
            _.Display($"PROGRAMA EM EXECUCAO VE0031B  ");

            /*" -140- DISPLAY '                              ' . */
            _.Display($"                              ");

            /*" -141- DISPLAY 'VERSAO V.01 40.043 29/03/2010 ' . */
            _.Display($"VERSAO V.01 40.043 29/03/2010 ");

            /*" -142- DISPLAY '                              ' . */
            _.Display($"                              ");

            /*" -144- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -149- PERFORM R0000_00_PRINCIPAL_DB_SELECT_1 */

            R0000_00_PRINCIPAL_DB_SELECT_1();

            /*" -152- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -153- DISPLAY ' ' */
                _.Display($" ");

                /*" -154- DISPLAY 'R0215-00 - ERRO NO ACESSO A V1PARAMRAMO' */
                _.Display($"R0215-00 - ERRO NO ACESSO A V1PARAMRAMO");

                /*" -156- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -158- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -160- PERFORM R0800-00-DECLER-V0RELATORIOS. */

            R0800_00_DECLER_V0RELATORIOS_SECTION();

            /*" -162- PERFORM R0810-00-FETCH-V0RELATORIOS */

            R0810_00_FETCH_V0RELATORIOS_SECTION();

            /*" -163- IF WFIM-V0RELATORIOS NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty())
            {

                /*" -164- DISPLAY 'NENHUMA SOLICITACAO DE CANCELAMENTO CADASTRADA' */
                _.Display($"NENHUMA SOLICITACAO DE CANCELAMENTO CADASTRADA");

                /*" -166- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -169- PERFORM R0850-00-PROCESSA-V0RELATORIOS UNTIL WFIM-V0RELATORIOS NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0RELATORIOS.IsEmpty()))
            {

                R0850_00_PROCESSA_V0RELATORIOS_SECTION();
            }

            /*" -170- DISPLAY 'SEGUROS  LIDAS ............. ' WACC-LIDOS. */
            _.Display($"SEGUROS  LIDAS ............. {AREA_DE_WORK.WACC_LIDOS}");

            /*" -171- DISPLAY 'PROPOSTAS CANC. GERADAS .... ' WACC-GRAVADOS. */
            _.Display($"PROPOSTAS CANC. GERADAS .... {AREA_DE_WORK.WACC_GRAVADOS}");

            /*" -173- DISPLAY 'CANCELAMENTOS LIDOS......... ' WACC-LIDOS-REL. */
            _.Display($"CANCELAMENTOS LIDOS......... {AREA_DE_WORK.WACC_LIDOS_REL}");

            /*" -173- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-DB-SELECT-1 */
        public void R0000_00_PRINCIPAL_DB_SELECT_1()
        {
            /*" -149- EXEC SQL SELECT RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :V1PAR-RAMO-VG, :V1PAR-RAMO-AP, :V1PAR-RAMO-PST FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var r0000_00_PRINCIPAL_DB_SELECT_1_Query1 = new R0000_00_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0000_00_PRINCIPAL_DB_SELECT_1_Query1.Execute(r0000_00_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1PAR_RAMO_VG, V1PAR_RAMO_VG);
                _.Move(executed_1.V1PAR_RAMO_AP, V1PAR_RAMO_AP);
                _.Move(executed_1.V1PAR_RAMO_PST, V1PAR_RAMO_PST);
            }


        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -179- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -180- DISPLAY ' ' */
            _.Display($" ");

            /*" -182- DISPLAY '*--------  VE0031B - FIM NORMAL  --------*' */
            _.Display($"*--------  VE0031B - FIM NORMAL  --------*");

            /*" -182- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -193- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -200- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -204- DISPLAY 'ERRO SELECT SISTEMAS (VG)' */
                _.Display($"ERRO SELECT SISTEMAS (VG)");

                /*" -205- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -207- END-IF. */
            }


            /*" -209- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DT-INICIO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, AREA_DE_WORK.WHOST_DT_INICIO);

            /*" -209- MOVE 01 TO WHOST-DT-INICIO(9:2). */
            _.MoveAtPosition(01, AREA_DE_WORK.WHOST_DT_INICIO, 9, 2);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -200- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

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
        /*" R0800-00-DECLER-V0RELATORIOS-SECTION */
        private void R0800_00_DECLER_V0RELATORIOS_SECTION()
        {
            /*" -221- MOVE '0800' TO WNR-EXEC-SQL. */
            _.Move("0800", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -231- PERFORM R0800_00_DECLER_V0RELATORIOS_DB_DECLARE_1 */

            R0800_00_DECLER_V0RELATORIOS_DB_DECLARE_1();

            /*" -233- PERFORM R0800_00_DECLER_V0RELATORIOS_DB_OPEN_1 */

            R0800_00_DECLER_V0RELATORIOS_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0800-00-DECLER-V0RELATORIOS-DB-DECLARE-1 */
        public void R0800_00_DECLER_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -231- EXEC SQL DECLARE CRELAT CURSOR FOR SELECT DATA_SOLICITACAO, NUM_APOLICE, COD_SUBGRUPO, COD_USUARIO FROM SEGUROS.RELATORIOS WHERE COD_RELATORIO = 'VE0030B' AND COD_USUARIO IN ( 'VA0851B' , 'VE0436B' ) AND SIT_REGISTRO = '2' ORDER BY NUM_APOLICE, COD_SUBGRUPO END-EXEC. */
            CRELAT = new VE0031B_CRELAT(false);
            string GetQuery_CRELAT()
            {
                var query = @$"SELECT DATA_SOLICITACAO
							, 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_USUARIO 
							FROM SEGUROS.RELATORIOS 
							WHERE COD_RELATORIO = 'VE0030B' 
							AND COD_USUARIO IN ( 'VA0851B'
							, 'VE0436B' ) 
							AND SIT_REGISTRO = '2' 
							ORDER BY NUM_APOLICE
							, COD_SUBGRUPO";

                return query;
            }
            CRELAT.GetQueryEvent += GetQuery_CRELAT;

        }

        [StopWatch]
        /*" R0800-00-DECLER-V0RELATORIOS-DB-OPEN-1 */
        public void R0800_00_DECLER_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -233- EXEC SQL OPEN CRELAT END-EXEC. */

            CRELAT.Open();

        }

        [StopWatch]
        /*" R0850-00-PROCESSA-V0RELATORIOS-DB-DECLARE-1 */
        public void R0850_00_PROCESSA_V0RELATORIOS_DB_DECLARE_1()
        {
            /*" -314- EXEC SQL DECLARE CSEGURA CURSOR FOR SELECT NUM_CERTIFICADO, COD_FONTE FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO AND NUM_MATRICULA >= 0 AND TIPO_SEGURADO = '1' AND SIT_REGISTRO = '0' END-EXEC. */
            CSEGURA = new VE0031B_CSEGURA(true);
            string GetQuery_CSEGURA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							COD_FONTE 
							FROM SEGUROS.SEGURADOS_VGAP 
							WHERE NUM_APOLICE = '{SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}' 
							AND COD_SUBGRUPO = '{SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO}' 
							AND NUM_MATRICULA >= 0 
							AND TIPO_SEGURADO = '1' 
							AND SIT_REGISTRO = '0'";

                return query;
            }
            CSEGURA.GetQueryEvent += GetQuery_CSEGURA;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_99_SAIDA*/

        [StopWatch]
        /*" R0810-00-FETCH-V0RELATORIOS-SECTION */
        private void R0810_00_FETCH_V0RELATORIOS_SECTION()
        {
            /*" -245- MOVE '0810' TO WNR-EXEC-SQL. */
            _.Move("0810", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -250- PERFORM R0810_00_FETCH_V0RELATORIOS_DB_FETCH_1 */

            R0810_00_FETCH_V0RELATORIOS_DB_FETCH_1();

            /*" -253- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -254- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -254- PERFORM R0810_00_FETCH_V0RELATORIOS_DB_CLOSE_1 */

                    R0810_00_FETCH_V0RELATORIOS_DB_CLOSE_1();

                    /*" -256- MOVE 'S' TO WFIM-V0RELATORIOS */
                    _.Move("S", AREA_DE_WORK.WFIM_V0RELATORIOS);

                    /*" -257- GO TO R0810-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0810_99_SAIDA*/ //GOTO
                    return;

                    /*" -258- ELSE */
                }
                else
                {


                    /*" -259- DISPLAY 'R0810-00 (ERRO -  FETCH V0RELATORIOS )...' */
                    _.Display($"R0810-00 (ERRO -  FETCH V0RELATORIOS )...");

                    /*" -261- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -264- MOVE RELATORI-COD-SUBGRUPO TO WS-COD-SUBGRUPO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, AREA_DE_WORK.WS_COD_SUBGRUPO);

            /*" -270- DISPLAY '*** VE0031B *** FETCH V0RELAT . ' ' ' RELATORI-NUM-APOLICE ' ' WS-COD-SUBGRUPO ' ' RELATORI-DATA-SOLICITACAO ' ' RELATORI-COD-USUARIO . */

            $"*** VE0031B *** FETCH V0RELAT .  {RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {AREA_DE_WORK.WS_COD_SUBGRUPO} {RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO} {RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO}"
            .Display();

            /*" -270- ADD 1 TO WACC-LIDOS-REL. */
            AREA_DE_WORK.WACC_LIDOS_REL.Value = AREA_DE_WORK.WACC_LIDOS_REL + 1;

        }

        [StopWatch]
        /*" R0810-00-FETCH-V0RELATORIOS-DB-FETCH-1 */
        public void R0810_00_FETCH_V0RELATORIOS_DB_FETCH_1()
        {
            /*" -250- EXEC SQL FETCH CRELAT INTO :RELATORI-DATA-SOLICITACAO, :RELATORI-NUM-APOLICE, :RELATORI-COD-SUBGRUPO, :RELATORI-COD-USUARIO END-EXEC. */

            if (CRELAT.Fetch())
            {
                _.Move(CRELAT.RELATORI_DATA_SOLICITACAO, RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO);
                _.Move(CRELAT.RELATORI_NUM_APOLICE, RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE);
                _.Move(CRELAT.RELATORI_COD_SUBGRUPO, RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO);
                _.Move(CRELAT.RELATORI_COD_USUARIO, RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R0810-00-FETCH-V0RELATORIOS-DB-CLOSE-1 */
        public void R0810_00_FETCH_V0RELATORIOS_DB_CLOSE_1()
        {
            /*" -254- EXEC SQL CLOSE CRELAT END-EXEC */

            CRELAT.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0810_99_SAIDA*/

        [StopWatch]
        /*" R0850-00-PROCESSA-V0RELATORIOS-SECTION */
        private void R0850_00_PROCESSA_V0RELATORIOS_SECTION()
        {
            /*" -282- MOVE '0850' TO WNR-EXEC-SQL. */
            _.Move("0850", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -283- MOVE RELATORI-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -285- MOVE RELATORI-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -291- PERFORM R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1 */

            R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1();

            /*" -294- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -295- DISPLAY 'PROBLEMAS NO SELECT (SUBGVGAP) ... ' */
                _.Display($"PROBLEMAS NO SELECT (SUBGVGAP) ... ");

                /*" -298- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -301- MOVE '0851' TO WNR-EXEC-SQL. */
            _.Move("0851", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -302- MOVE RELATORI-NUM-APOLICE TO SEGURVGA-NUM-APOLICE. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);

            /*" -304- MOVE RELATORI-COD-SUBGRUPO TO SEGURVGA-COD-SUBGRUPO. */
            _.Move(RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);

            /*" -314- PERFORM R0850_00_PROCESSA_V0RELATORIOS_DB_DECLARE_1 */

            R0850_00_PROCESSA_V0RELATORIOS_DB_DECLARE_1();

            /*" -318- DISPLAY '*** VE0031B *** ABRINDO CURSOR ...' . */
            _.Display($"*** VE0031B *** ABRINDO CURSOR ...");

            /*" -320- MOVE '0852' TO WNR-EXEC-SQL. */
            _.Move("0852", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -320- PERFORM R0850_00_PROCESSA_V0RELATORIOS_DB_OPEN_1 */

            R0850_00_PROCESSA_V0RELATORIOS_DB_OPEN_1();

            /*" -323- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -324- DISPLAY 'PROBLEMAS NO OPEN (CSEGURA   ) ... ' */
                _.Display($"PROBLEMAS NO OPEN (CSEGURA   ) ... ");

                /*" -326- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -329- MOVE SEGURVGA-COD-SUBGRUPO TO WS-COD-SUBGRUPO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, AREA_DE_WORK.WS_COD_SUBGRUPO);

            /*" -333- DISPLAY '*** VE0031B *** PROCESSANDO ... ' SEGURVGA-NUM-APOLICE ' ' WS-COD-SUBGRUPO. */

            $"*** VE0031B *** PROCESSANDO ... {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE} {AREA_DE_WORK.WS_COD_SUBGRUPO}"
            .Display();

            /*" -335- PERFORM R0910-00-FETCH-CSEGURA. */

            R0910_00_FETCH_CSEGURA_SECTION();

            /*" -338- IF WFIM-CSEGURA NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_CSEGURA.IsEmpty())
            {

                /*" -340- GO TO R0850-10-NEXT. */

                R0850_10_NEXT(); //GOTO
                return;
            }


            /*" -341- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-CSEGURA NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_CSEGURA.IsEmpty()))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R0850_10_NEXT */

            R0850_10_NEXT();

        }

        [StopWatch]
        /*" R0850-00-PROCESSA-V0RELATORIOS-DB-SELECT-1 */
        public void R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -291- EXEC SQL SELECT PERI_FATURAMENTO INTO :SUBGVGAP-PERI-FATURAMENTO FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO END-EXEC. */

            var r0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1 = new R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
            }


        }

        [StopWatch]
        /*" R0850-00-PROCESSA-V0RELATORIOS-DB-OPEN-1 */
        public void R0850_00_PROCESSA_V0RELATORIOS_DB_OPEN_1()
        {
            /*" -320- EXEC SQL OPEN CSEGURA END-EXEC. */

            CSEGURA.Open();

        }

        [StopWatch]
        /*" R0850-10-NEXT */
        private void R0850_10_NEXT(bool isPerform = false)
        {
            /*" -347- PERFORM R2000-00-UPDATE-V0RELATORIOS. */

            R2000_00_UPDATE_V0RELATORIOS_SECTION();

            /*" -347- PERFORM R0810-00-FETCH-V0RELATORIOS. */

            R0810_00_FETCH_V0RELATORIOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-CSEGURA-SECTION */
        private void R0910_00_FETCH_CSEGURA_SECTION()
        {
            /*" -359- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -361- MOVE ' ' TO WFIM-CSEGURA. */
            _.Move(" ", AREA_DE_WORK.WFIM_CSEGURA);

            /*" -364- PERFORM R0910_00_FETCH_CSEGURA_DB_FETCH_1 */

            R0910_00_FETCH_CSEGURA_DB_FETCH_1();

            /*" -367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -368- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -368- PERFORM R0910_00_FETCH_CSEGURA_DB_CLOSE_1 */

                    R0910_00_FETCH_CSEGURA_DB_CLOSE_1();

                    /*" -370- MOVE 'S' TO WFIM-CSEGURA */
                    _.Move("S", AREA_DE_WORK.WFIM_CSEGURA);

                    /*" -371- GO TO R0910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                    return;

                    /*" -372- ELSE */
                }
                else
                {


                    /*" -373- DISPLAY 'R0910-00 (ERRO -  FETCH CSEGURA   )...' */
                    _.Display($"R0910-00 (ERRO -  FETCH CSEGURA   )...");

                    /*" -375- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -375- ADD 1 TO WACC-LIDOS. */
            AREA_DE_WORK.WACC_LIDOS.Value = AREA_DE_WORK.WACC_LIDOS + 1;

        }

        [StopWatch]
        /*" R0910-00-FETCH-CSEGURA-DB-FETCH-1 */
        public void R0910_00_FETCH_CSEGURA_DB_FETCH_1()
        {
            /*" -364- EXEC SQL FETCH CSEGURA INTO :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-COD-FONTE END-EXEC. */

            if (CSEGURA.Fetch())
            {
                _.Move(CSEGURA.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(CSEGURA.SEGURVGA_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-CSEGURA-DB-CLOSE-1 */
        public void R0910_00_FETCH_CSEGURA_DB_CLOSE_1()
        {
            /*" -368- EXEC SQL CLOSE CSEGURA END-EXEC */

            CSEGURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -386- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -386- PERFORM R6000-00-CANCELA-SEGURO. */

            R6000_00_CANCELA_SEGURO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -390- PERFORM R0910-00-FETCH-CSEGURA. */

            R0910_00_FETCH_CSEGURA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-UPDATE-V0RELATORIOS-SECTION */
        private void R2000_00_UPDATE_V0RELATORIOS_SECTION()
        {
            /*" -402- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -410- PERFORM R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1 */

            R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1();

            /*" -413- IF SQLCODE NOT EQUAL ZEROES AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -417- DISPLAY 'R2000 - PROBLEMA UPDATE V0RELATORIOS...' RELATORI-NUM-APOLICE ' ' RELATORI-COD-SUBGRUPO ' ' SQLCODE */

                $"R2000 - PROBLEMA UPDATE V0RELATORIOS...{RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE} {RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO} {DB.SQLCODE}"
                .Display();

                /*" -417- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-UPDATE-V0RELATORIOS-DB-UPDATE-1 */
        public void R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1()
        {
            /*" -410- EXEC SQL UPDATE SEGUROS.RELATORIOS SET SIT_REGISTRO = '3' WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE AND COD_SUBGRUPO = :RELATORI-COD-SUBGRUPO AND COD_RELATORIO = 'VE0030B' AND COD_USUARIO IN ( 'VA0851B' , 'VE0436B' ) AND SIT_REGISTRO = '2' END-EXEC. */

            var r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1 = new R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1()
            {
                RELATORI_COD_SUBGRUPO = RELATORI.DCLRELATORIOS.RELATORI_COD_SUBGRUPO.ToString(),
                RELATORI_NUM_APOLICE = RELATORI.DCLRELATORIOS.RELATORI_NUM_APOLICE.ToString(),
            };

            R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1.Execute(r2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-SECTION */
        private void R6000_00_CANCELA_SEGURO_SECTION()
        {
            /*" -431- MOVE '6075' TO WNR-EXEC-SQL. */
            _.Move("6075", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -457- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_1 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_1();

            /*" -460- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -461- DISPLAY 'R6000-00 (ERRO - SELECT SEGURADOS_VGAP)' */
                _.Display($"R6000-00 (ERRO - SELECT SEGURADOS_VGAP)");

                /*" -462- DISPLAY 'CERTIF: ' SEGURVGA-NUM-CERTIFICADO */
                _.Display($"CERTIF: {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                /*" -466- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -469- MOVE '6073' TO WNR-EXEC-SQL. */
            _.Move("6073", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -475- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_2 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_2();

            /*" -478- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -480- MOVE '6074' TO WNR-EXEC-SQL */
                _.Move("6074", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -486- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_3 */

                R6000_00_CANCELA_SEGURO_DB_SELECT_3();

                /*" -488- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -495- MOVE WHOST-DT-INICIO TO FATURCON-DATA-REFERENCIA. */
                    _.Move(AREA_DE_WORK.WHOST_DT_INICIO, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
                }

            }


            /*" -498- MOVE '6080' TO WNR-EXEC-SQL. */
            _.Move("6080", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -511- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_4 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_4();

            /*" -514- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -515- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -516- DISPLAY 'R6000-00 (RAMO 93 COD_COBERTURA 11 - VG   )' */
                    _.Display($"R6000-00 (RAMO 93 COD_COBERTURA 11 - VG   )");

                    /*" -517- DISPLAY 'R6000-00 (NAO ENCONTRADA                  )' */
                    _.Display($"R6000-00 (NAO ENCONTRADA                  )");

                    /*" -518- DISPLAY 'R6000-00 (APOLICE = ' SEGURVGA-NUM-APOLICE */
                    _.Display($"R6000-00 (APOLICE = {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                    /*" -521- MOVE ZEROS TO V0COBA-IMPMORNATU V0COBA-PRMVG. */
                    _.Move(0, V0COBA_IMPMORNATU, V0COBA_PRMVG);
                }

            }


            /*" -524- MOVE '6082' TO WNR-EXEC-SQL. */
            _.Move("6082", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -537- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_5 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_5();

            /*" -540- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -543- MOVE 0 TO V0COBA-IMPMORACID V0COBA-PRMAP. */
                _.Move(0, V0COBA_IMPMORACID, V0COBA_PRMAP);
            }


            /*" -546- MOVE '6084' TO WNR-EXEC-SQL. */
            _.Move("6084", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -557- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_6 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_6();

            /*" -560- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -562- MOVE 0 TO V0COBA-IMPINVPERM. */
                _.Move(0, V0COBA_IMPINVPERM);
            }


            /*" -565- MOVE '6086' TO WNR-EXEC-SQL. */
            _.Move("6086", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -576- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_7 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_7();

            /*" -579- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -581- MOVE 0 TO V0COBA-IMPDIT. */
                _.Move(0, V0COBA_IMPDIT);
            }


            /*" -584- MOVE '6998' TO WNR-EXEC-SQL. */
            _.Move("6998", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -593- PERFORM R6000_00_CANCELA_SEGURO_DB_SELECT_8 */

            R6000_00_CANCELA_SEGURO_DB_SELECT_8();

            /*" -596- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -597- MOVE ZEROS TO CONTACOR-COD-AGENCIA */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);

                /*" -598- MOVE ZEROS TO CONTACOR-NUM-CTA-CORRENTE */
                _.Move(0, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);

                /*" -598- MOVE SPACES TO CONTACOR-DAC-CTA-CORRENTE. */
                _.Move("", CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


            /*" -0- FLUXCONTROL_PERFORM R6000_10_LOOP_PROPAUTOM */

            R6000_10_LOOP_PROPAUTOM();

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-1 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_1()
        {
            /*" -457- EXEC SQL SELECT TIPO_INCLUSAO, COD_AGENCIADOR, NUM_ITEM, OCORR_HISTORICO, NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, SIT_REGISTRO, COD_CLIENTE, NUM_MATRICULA, DATA_INIVIGENCIA INTO :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-AGENCIADOR, :SEGURVGA-NUM-ITEM, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-DATA-INIVIGENCIA FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = '1' END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURVGA_TIPO_INCLUSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO);
                _.Move(executed_1.SEGURVGA_COD_AGENCIADOR, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR);
                _.Move(executed_1.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(executed_1.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(executed_1.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(executed_1.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(executed_1.SEGURVGA_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);
                _.Move(executed_1.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(executed_1.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(executed_1.SEGURVGA_NUM_MATRICULA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);
                _.Move(executed_1.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
            }


        }

        [StopWatch]
        /*" R6000-10-LOOP-PROPAUTOM */
        private void R6000_10_LOOP_PROPAUTOM(bool isPerform = false)
        {
            /*" -607- MOVE '6050' TO WNR-EXEC-SQL. */
            _.Move("6050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -612- PERFORM R6000_10_LOOP_PROPAUTOM_DB_SELECT_1 */

            R6000_10_LOOP_PROPAUTOM_DB_SELECT_1();

            /*" -615- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -617- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -620- COMPUTE FONTES-ULT-PROP-AUTOMAT = FONTES-ULT-PROP-AUTOMAT + 1. */
            FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.Value = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT + 1;

            /*" -623- MOVE '6060' TO WNR-EXEC-SQL. */
            _.Move("6060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -628- PERFORM R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1 */

            R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1();

            /*" -631- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -633- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -636- MOVE SUBGVGAP-PERI-FATURAMENTO TO MOVIMVGA-PERI-PAGAMENTO. */
            _.Move(SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -637- IF RELATORI-COD-USUARIO EQUAL 'VA0851B' */

            if (RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO == "VA0851B")
            {

                /*" -638- MOVE 403 TO MOVIMVGA-COD-OPERACAO */
                _.Move(403, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

                /*" -639- ELSE */
            }
            else
            {


                /*" -643- MOVE 401 TO MOVIMVGA-COD-OPERACAO. */
                _.Move(401, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
            }


            /*" -646- MOVE '6999' TO WNR-EXEC-SQL. */
            _.Move("6999", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -798- PERFORM R6000_10_LOOP_PROPAUTOM_DB_INSERT_1 */

            R6000_10_LOOP_PROPAUTOM_DB_INSERT_1();

            /*" -801- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -802- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -803- GO TO R6000-10-LOOP-PROPAUTOM */
                    new Task(() => R6000_10_LOOP_PROPAUTOM()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -804- ELSE */
                }
                else
                {


                    /*" -805- DISPLAY 'R6000-00 (ERRO - INSERT V0MOVIMENTO  )' */
                    _.Display($"R6000-00 (ERRO - INSERT V0MOVIMENTO  )");

                    /*" -808- DISPLAY 'CERTIF: ' SEGURVGA-NUM-CERTIFICADO ' ' 'FONTE:  ' SEGURVGA-COD-FONTE ' ' 'PROPOS: ' FONTES-ULT-PROP-AUTOMAT */

                    $"CERTIF: {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO} FONTE:  {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE} PROPOS: {FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT}"
                    .Display();

                    /*" -810- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -810- ADD 1 TO WACC-GRAVADOS. */
            AREA_DE_WORK.WACC_GRAVADOS.Value = AREA_DE_WORK.WACC_GRAVADOS + 1;

        }

        [StopWatch]
        /*" R6000-10-LOOP-PROPAUTOM-DB-SELECT-1 */
        public void R6000_10_LOOP_PROPAUTOM_DB_SELECT_1()
        {
            /*" -612- EXEC SQL SELECT ULT_PROP_AUTOMAT INTO :FONTES-ULT-PROP-AUTOMAT FROM SEGUROS.FONTES WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1 = new R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1()
            {
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            var executed_1 = R6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1.Execute(r6000_10_LOOP_PROPAUTOM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_ULT_PROP_AUTOMAT, FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT);
            }


        }

        [StopWatch]
        /*" R6000-10-LOOP-PROPAUTOM-DB-UPDATE-1 */
        public void R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1()
        {
            /*" -628- EXEC SQL UPDATE SEGUROS.FONTES SET ULT_PROP_AUTOMAT = :FONTES-ULT-PROP-AUTOMAT, TIMESTAMP = CURRENT TIMESTAMP WHERE COD_FONTE = :SEGURVGA-COD-FONTE END-EXEC. */

            var r6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1 = new R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1()
            {
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
            };

            R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1.Execute(r6000_10_LOOP_PROPAUTOM_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R6000-10-LOOP-PROPAUTOM-DB-INSERT-1 */
        public void R6000_10_LOOP_PROPAUTOM_DB_INSERT_1()
        {
            /*" -798- EXEC SQL INSERT INTO SEGUROS.MOVIMENTO_VGAP ( NUM_APOLICE , COD_SUBGRUPO , COD_FONTE , NUM_PROPOSTA , TIPO_SEGURADO , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_INCLUSAO , COD_CLIENTE , COD_AGENCIADOR , COD_CORRETOR , COD_PLANOVGAP , COD_PLANOAP , FAIXA , AUTOR_AUM_AUTOMAT , TIPO_BENEFICIARIO , PERI_PAGAMENTO , PERI_RENOVACAO , COD_OCUPACAO , ESTADO_CIVIL , IDE_SEXO , COD_PROFISSAO , NATURALIDADE , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , NUM_MATRICULA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE , VAL_SALARIO , TIPO_SALARIO , TIPO_PLANO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , QTD_SAL_MORNATU , QTD_SAL_MORACID , QTD_SAL_INVPERM , TAXA_AP_MORACID , TAXA_AP_INVPERM , TAXA_AP_AMDS , TAXA_AP_DH , TAXA_AP_DIT , TAXA_VG , IMP_MORNATU_ANT , IMP_MORNATU_ATU , IMP_MORACID_ANT , IMP_MORACID_ATU , IMP_INVPERM_ANT , IMP_INVPERM_ATU , IMP_AMDS_ANT , IMP_AMDS_ATU , IMP_DH_ANT , IMP_DH_ATU , IMP_DIT_ANT , IMP_DIT_ATU , PRM_VG_ANT , PRM_VG_ATU , PRM_AP_ANT , PRM_AP_ATU , COD_OPERACAO , DATA_OPERACAO , COD_SUBGRUPO_TRANS , SIT_REGISTRO , COD_USUARIO , DATA_AVERBACAO , DATA_ADMISSAO , DATA_INCLUSAO , DATA_NASCIMENTO , DATA_FATURA , DATA_REFERENCIA , DATA_MOVIMENTO , COD_EMPRESA , LOT_EMP_SEGURADO) VALUES (:SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-COD-FONTE, :FONTES-ULT-PROP-AUTOMAT, '1' , :SEGURVGA-NUM-CERTIFICADO, ' ' , :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-COD-AGENCIADOR, 0, 0, 0, 0, 'S' , 'N' , :MOVIMVGA-PERI-PAGAMENTO, 12, ' ' , ' ' , ' ' , 0, ' ' , 1, 1, 104, :CONTACOR-COD-AGENCIA, ' ' , :SEGURVGA-NUM-MATRICULA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE, 0, ' ' , '1' , 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, :V0COBA-IMPMORNATU, :V0COBA-IMPMORNATU, :V0COBA-IMPMORACID, :V0COBA-IMPMORACID, :V0COBA-IMPINVPERM, :V0COBA-IMPINVPERM, 0, 0, 0, 0, :V0COBA-IMPDIT, :V0COBA-IMPDIT, :V0COBA-PRMVG, :V0COBA-PRMVG, :V0COBA-PRMAP, :V0COBA-PRMAP, :MOVIMVGA-COD-OPERACAO, CURRENT DATE, 0, '1' , :RELATORI-COD-USUARIO, CURRENT DATE, NULL, NULL, NULL, NULL, :FATURCON-DATA-REFERENCIA, :RELATORI-DATA-SOLICITACAO, NULL, NULL) END-EXEC. */

            var r6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1 = new R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_COD_FONTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE.ToString(),
                FONTES_ULT_PROP_AUTOMAT = FONTES.DCLFONTES.FONTES_ULT_PROP_AUTOMAT.ToString(),
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_TIPO_INCLUSAO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO.ToString(),
                SEGURVGA_COD_CLIENTE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE.ToString(),
                SEGURVGA_COD_AGENCIADOR = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_PERI_PAGAMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO.ToString(),
                CONTACOR_COD_AGENCIA = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA.ToString(),
                SEGURVGA_NUM_MATRICULA = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA.ToString(),
                CONTACOR_NUM_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE.ToString(),
                CONTACOR_DAC_CTA_CORRENTE = CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE.ToString(),
                V0COBA_IMPMORNATU = V0COBA_IMPMORNATU.ToString(),
                V0COBA_IMPMORACID = V0COBA_IMPMORACID.ToString(),
                V0COBA_IMPINVPERM = V0COBA_IMPINVPERM.ToString(),
                V0COBA_IMPDIT = V0COBA_IMPDIT.ToString(),
                V0COBA_PRMVG = V0COBA_PRMVG.ToString(),
                V0COBA_PRMAP = V0COBA_PRMAP.ToString(),
                MOVIMVGA_COD_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO.ToString(),
                RELATORI_COD_USUARIO = RELATORI.DCLRELATORIOS.RELATORI_COD_USUARIO.ToString(),
                FATURCON_DATA_REFERENCIA = FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.ToString(),
                RELATORI_DATA_SOLICITACAO = RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.ToString(),
            };

            R6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1.Execute(r6000_10_LOOP_PROPAUTOM_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-2 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_2()
        {
            /*" -475- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = :SEGURVGA-COD-SUBGRUPO END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1()
            {
                SEGURVGA_COD_SUBGRUPO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-3 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_3()
        {
            /*" -486- EXEC SQL SELECT DATA_REFERENCIA INTO :FATURCON-DATA-REFERENCIA FROM SEGUROS.FATURAS_CONTROLE WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND COD_SUBGRUPO = 0 END-EXEC */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1()
            {
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATURCON_DATA_REFERENCIA, FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -822- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -824- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -825- DISPLAY 'ERRO NUMERO ==> ' WNR-EXEC-SQL. */
            _.Display($"ERRO NUMERO ==> {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

            /*" -826- DISPLAY 'LIDOS       ==> ' WACC-LIDOS. */
            _.Display($"LIDOS       ==> {AREA_DE_WORK.WACC_LIDOS}");

            /*" -827- DISPLAY 'CERTIFICADO ==> ' SEGURVGA-NUM-CERTIFICADO */
            _.Display($"CERTIFICADO ==> {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

            /*" -829- DISPLAY 'ITEM        ==> ' SEGURVGA-NUM-ITEM. */
            _.Display($"ITEM        ==> {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM}");

            /*" -829- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -831- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -835- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -835- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-4 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_4()
        {
            /*" -511- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORNATU, :V0COBA-PRMVG FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA = 93 AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 11 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_4_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORNATU, V0COBA_IMPMORNATU);
                _.Move(executed_1.V0COBA_PRMVG, V0COBA_PRMVG);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-5 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_5()
        {
            /*" -537- EXEC SQL SELECT IMP_SEGURADA_IX, PRM_TARIFARIO_IX INTO :V0COBA-IMPMORACID, :V0COBA-PRMAP FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 1 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_5_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPMORACID, V0COBA_IMPMORACID);
                _.Move(executed_1.V0COBA_PRMAP, V0COBA_PRMAP);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-6 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_6()
        {
            /*" -557- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPINVPERM FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 2 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_6_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPINVPERM, V0COBA_IMPINVPERM);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-7 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_7()
        {
            /*" -576- EXEC SQL SELECT IMP_SEGURADA_IX INTO :V0COBA-IMPDIT FROM SEGUROS.APOLICE_COBERTURAS WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ENDOSSO = 0 AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO AND RAMO_COBERTURA IN (81, :V1PAR-RAMO-AP) AND MODALI_COBERTURA = 0 AND COD_COBERTURA = 5 END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
                V1PAR_RAMO_AP = V1PAR_RAMO_AP.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_7_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0COBA_IMPDIT, V0COBA_IMPDIT);
            }


        }

        [StopWatch]
        /*" R6000-00-CANCELA-SEGURO-DB-SELECT-8 */
        public void R6000_00_CANCELA_SEGURO_DB_SELECT_8()
        {
            /*" -593- EXEC SQL SELECT COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :CONTACOR-COD-AGENCIA, :CONTACOR-NUM-CTA-CORRENTE, :CONTACOR-DAC-CTA-CORRENTE FROM SEGUROS.CONTA_CORRENTE WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO END-EXEC. */

            var r6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1 = new R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1.Execute(r6000_00_CANCELA_SEGURO_DB_SELECT_8_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_COD_AGENCIA, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_COD_AGENCIA);
                _.Move(executed_1.CONTACOR_NUM_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_NUM_CTA_CORRENTE);
                _.Move(executed_1.CONTACOR_DAC_CTA_CORRENTE, CONTACOR.DCLCONTA_CORRENTE.CONTACOR_DAC_CTA_CORRENTE);
            }


        }
    }
}