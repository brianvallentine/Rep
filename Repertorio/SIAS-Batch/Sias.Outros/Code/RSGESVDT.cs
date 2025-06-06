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

namespace Code
{
    public class RSGESVDT
    {
        public bool IsCall { get; set; }

        public RSGESVDT()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      * SISTEMA ................  RSS - RENOVACAO DO SISTEMA DE SEGURO *      */
        /*"      * PROGRAMA ...............  RSGESVDT                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ANALISTA ...............  HERVAL SOUZA                         *      */
        /*"      * PROGRAMADOR ............  HERVAL SOUZA                         *      */
        /*"      * DATA CODIFICACAO .......  Jul/2014                             *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * FUNCAO .................  Testar validade de uma data          *      */
        /*"      *                                                                *      */
        /*"      *                           A data deve ser informada como       *      */
        /*"      *                           ano, mes e dia, separadamente.       *      */
        /*"      *                                                                *      */
        /*"      *                           A rotina devolvera os seguintes      *      */
        /*"      *                       0 - Data OK.                             *      */
        /*"      *                       1 - Data incorreta                       *      */
        /*"      *                       2 - Ano, mes ou dia n�o numerico         *      */
        /*"      *                                                                *      */
        /*"      *                           Se data OK, retorna a data no formato*      */
        /*"      *                           DB2. "AAAA-MM-DD".                   *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                      TIPO        CODIGO        ACESSO   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*" 01  VARIAVEIS-APOIO.*/
        public RSGESVDT_VARIAVEIS_APOIO VARIAVEIS_APOIO { get; set; } = new RSGESVDT_VARIAVEIS_APOIO();
        public class RSGESVDT_VARIAVEIS_APOIO : VarBasis
        {
            /*"  05   WS-ANOX.*/
            public RSGESVDT_WS_ANOX WS_ANOX { get; set; } = new RSGESVDT_WS_ANOX();
            public class RSGESVDT_WS_ANOX : VarBasis
            {
                /*"   10    WS-ANO                     PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05   WS-RESTO                     PIC S9(004)  COMP VALUE +0.*/
            }
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05   WS-PRIMEIRA-VEZ              PIC  X(003)  VALUE 'SIM'.*/
            public StringBasis WS_PRIMEIRA_VEZ { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"SIM");
        }


        public Copies.RSGEWDTA RSGEWDTA { get; set; } = new Copies.RSGEWDTA();
        public Copies.RSGEWVDT RSGEWVDT { get; set; } = new Copies.RSGEWVDT();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(RSGEWVDT RSGEWVDT_P) //PROCEDURE DIVISION USING 
        /*PROCEDURE DIVISION
        LK_RSGEWVDT_ANO
        LK_RSGEWVDT_MES
        LK_RSGEWVDT_DIA
        LK_RSGEWVDT_IND_RETORNO
        LK_RSGEWVDT_OUT_DATA*/
        {
            try
            {
                this.RSGEWVDT = RSGEWVDT_P;

                /*" -0- FLUXCONTROL_PERFORM R0001-INICIO-SECTION */

                R0001_INICIO_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { RSGEWVDT };
            return Result;
        }

        [StopWatch]
        /*" R0001-INICIO-SECTION */
        private void R0001_INICIO_SECTION()
        {
            /*" -83- MOVE FUNCTION CURRENT-DATE TO WS-CURRENT-DATE */
            _.Move(_.CurrentDate(), RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_DATE);

            /*" -83- MOVE FUNCTION WHEN-COMPILED TO WS-WHEN-COMPILED */
            _.Move(_.WhenCompiled(), RSGEWDTA.RSS_WORK_DATAS.WS_WHEN_COMPILED);

            /*" -83- STRING WS-WHEN-ANO '-' WS-WHEN-MES '-' WS-WHEN-DIA ' ' WS-WHEN-HORA ':' WS-WHEN-MIN ':' WS-WHEN-SEG ',' WS-WHEN-DECSEG DELIMITED BY SIZE INTO WS-COMPILED-EDIT */
            #region STRING
            var spl1 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_ANO.GetMoveValues();
            spl1 += "-";
            var spl2 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MES.GetMoveValues();
            spl2 += "-";
            var spl3 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DIA.GetMoveValues();
            spl3 += " ";
            var spl4 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_HORA.GetMoveValues();
            spl4 += ":";
            var spl5 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_MIN.GetMoveValues();
            spl5 += ":";
            var spl6 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_SEG.GetMoveValues();
            spl6 += ",";
            var spl7 = RSGEWDTA.RSS_WORK_DATAS.FILLER.WS_WHEN_DECSEG.GetMoveValues();
            var results8 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7;
            _.Move(results8, RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT);
            #endregion

            /*" -85- STRING WS-CDTE-ANO '-' WS-CDTE-MES '-' WS-CDTE-DIA ' ' WS-CDTE-HORA ':' WS-CDTE-MIN ':' WS-CDTE-SEG ',' WS-CDTE-DECSEG DELIMITED BY SIZE INTO WS-CURRENT-EDIT */
            #region STRING
            var spl8 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_ANO.GetMoveValues();
            spl8 += "-";
            var spl9 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MES.GetMoveValues();
            spl9 += "-";
            var spl10 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DIA.GetMoveValues();
            spl10 += " ";
            var spl11 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_HORA.GetMoveValues();
            spl11 += ":";
            var spl12 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_MIN.GetMoveValues();
            spl12 += ":";
            var spl13 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_SEG.GetMoveValues();
            spl13 += ",";
            var spl14 = RSGEWDTA.RSS_WORK_DATAS.FILLER_0.WS_CDTE_DECSEG.GetMoveValues();
            var results15 = spl8 + spl9 + spl10 + spl11 + spl12 + spl13 + spl14;
            _.Move(results15, RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT);
            #endregion

            /*" -87- IF WS_PRIMEIRA_VEZ = 'SIM' THEN */

            if (VARIAVEIS_APOIO.WS_PRIMEIRA_VEZ == "SIM")
            {

                /*" -88- DISPLAY ' ' */
                _.Display($" ");

                /*" -90- DISPLAY '*========================================================*' */
                _.Display($"*========================================================*");

                /*" -92- DISPLAY '* Programa .....: RSGESVDT- Valida e formata uma d' 'ata.   *' */
                _.Display($"* Programa .....: RSGESVDT- Valida e formata uma data.   *");

                /*" -94- DISPLAY '* Criacao ......: JUL/2014                        ' '       *' */
                _.Display($"* Criacao ......: JUL/2014                               *");

                /*" -96- DISPLAY '* Alteracao.....:                                 ' '       *' */
                _.Display($"* Alteracao.....:                                        *");

                /*" -98- DISPLAY '* Versao........: 01.00                           ' '       *' */
                _.Display($"* Versao........: 01.00                                  *");

                /*" -100- DISPLAY '* Catalogacao...: ' WS-COMPILED-EDIT '                 *' */

                $"* Catalogacao...: {RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT}                 *"
                .Display();

                /*" -102- DISPLAY '* Execucao......: ' WS-CURRENT-EDIT '                 *' */

                $"* Execucao......: {RSGEWDTA.RSS_WORK_DATAS.WS_CURRENT_EDIT}                 *"
                .Display();

                /*" -104- DISPLAY '*========================================================*' */
                _.Display($"*========================================================*");

                /*" -105- DISPLAY ' ' */
                _.Display($" ");

                /*" -107- DISPLAY 'RSGESVDT - CATALOGADO EM:' WS-COMPILED-EDIT */
                _.Display($"RSGESVDT - CATALOGADO EM:{RSGEWDTA.RSS_WORK_DATAS.WS_COMPILED_EDIT}");

                /*" -109- MOVE 'NAO' TO WS_PRIMEIRA_VEZ */
                _.Move("NAO", VARIAVEIS_APOIO.WS_PRIMEIRA_VEZ);

                /*" -111- END-IF. */
            }


            /*" -112- MOVE 1 TO LK-RSGEWVDT-IND-RETORNO. */
            _.Move(1, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

            /*" -116- MOVE SPACES TO LK-RSGEWVDT-OUT-DATA. */
            _.Move("", RSGEWVDT.LK_RSGEWVDT_OUT_DATA);

            /*" -119- IF LK-RSGEWVDT-ANO NOT NUMERIC OR LK-RSGEWVDT-MES NOT NUMERIC OR LK-RSGEWVDT-DIA NOT NUMERIC THEN */

            if (!RSGEWVDT.LK_RSGEWVDT_ANO.IsNumeric() || !RSGEWVDT.LK_RSGEWVDT_MES.IsNumeric() || !RSGEWVDT.LK_RSGEWVDT_DIA.IsNumeric())
            {

                /*" -120- MOVE 2 TO LK-RSGEWVDT-IND-RETORNO */
                _.Move(2, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

                /*" -121- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -125- END-IF. */
            }


            /*" -126- IF LK-RSGEWVDT-ANO = '0000' THEN */

            if (RSGEWVDT.LK_RSGEWVDT_ANO == "0000")
            {

                /*" -127- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -131- END-IF. */
            }


            /*" -133- IF LK-RSGEWVDT-MES < '01' OR LK-RSGEWVDT-MES > '12' THEN */

            if (RSGEWVDT.LK_RSGEWVDT_MES < "01" || RSGEWVDT.LK_RSGEWVDT_MES > "12")
            {

                /*" -134- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -138- END-IF. */
            }


            /*" -140- IF LK-RSGEWVDT-DIA < '01' OR LK-RSGEWVDT-DIA > '31' THEN */

            if (RSGEWVDT.LK_RSGEWVDT_DIA < "01" || RSGEWVDT.LK_RSGEWVDT_DIA > "31")
            {

                /*" -141- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -145- END-IF. */
            }


            /*" -148- IF LK-RSGEWVDT-DIA = '31' AND (LK-RSGEWVDT-MES = '02' OR '04' OR '06' OR '09' OR '11' ) THEN */

            if (RSGEWVDT.LK_RSGEWVDT_DIA == "31" && (RSGEWVDT.LK_RSGEWVDT_MES.In("02", "04", "06", "09", "11")))
            {

                /*" -149- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -153- END-IF. */
            }


            /*" -155- IF LK-RSGEWVDT-DIA = '30' AND LK-RSGEWVDT-MES = '02' THEN */

            if (RSGEWVDT.LK_RSGEWVDT_DIA == "30" && RSGEWVDT.LK_RSGEWVDT_MES == "02")
            {

                /*" -156- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -160- END-IF. */
            }


            /*" -162- IF LK-RSGEWVDT-DIA NOT = '29' OR LK-RSGEWVDT-MES NOT = '02' THEN */

            if (RSGEWVDT.LK_RSGEWVDT_DIA != "29" || RSGEWVDT.LK_RSGEWVDT_MES != "02")
            {

                /*" -163- GO TO R0001-10-DATA-CORRETA */

                R0001_10_DATA_CORRETA(); //GOTO
                return;

                /*" -168- END-IF. */
            }


            /*" -171- MOVE LK-RSGEWVDT-ANO TO WS-ANOX. */
            _.Move(RSGEWVDT.LK_RSGEWVDT_ANO, VARIAVEIS_APOIO.WS_ANOX);

            /*" -172- COMPUTE WS-RESTO = FUNCTION MOD(WS-ANO 400). */
            VARIAVEIS_APOIO.WS_RESTO.Value = (VARIAVEIS_APOIO.WS_ANOX.WS_ANO % 400);

            /*" -173- IF WS-RESTO = 0 */

            if (VARIAVEIS_APOIO.WS_RESTO == 0)
            {

                /*" -174- GO TO R0001-10-DATA-CORRETA */

                R0001_10_DATA_CORRETA(); //GOTO
                return;

                /*" -177- END-IF. */
            }


            /*" -178- COMPUTE WS-RESTO = FUNCTION MOD(WS-ANO 100). */
            VARIAVEIS_APOIO.WS_RESTO.Value = (VARIAVEIS_APOIO.WS_ANOX.WS_ANO % 100);

            /*" -179- IF WS-RESTO = 0 */

            if (VARIAVEIS_APOIO.WS_RESTO == 0)
            {

                /*" -180- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -183- END-IF. */
            }


            /*" -184- COMPUTE WS-RESTO = FUNCTION MOD(WS-ANO 4). */
            VARIAVEIS_APOIO.WS_RESTO.Value = (VARIAVEIS_APOIO.WS_ANOX.WS_ANO % 4);

            /*" -185- IF WS-RESTO NOT = 0 */

            if (VARIAVEIS_APOIO.WS_RESTO != 0)
            {

                /*" -186- GO TO R0001-99-FIM */

                R0001_99_FIM(); //GOTO
                return;

                /*" -186- END-IF. */
            }


            /*" -0- FLUXCONTROL_PERFORM R0001_10_DATA_CORRETA */

            R0001_10_DATA_CORRETA();

        }

        [StopWatch]
        /*" R0001-10-DATA-CORRETA */
        private void R0001_10_DATA_CORRETA(bool isPerform = false)
        {
            /*" -198- STRING LK-RSGEWVDT-ANO '-' LK-RSGEWVDT-MES '-' LK-RSGEWVDT-DIA DELIMITED BY SIZE INTO LK-RSGEWVDT-OUT-DATA. */
            #region STRING
            var spl15 = RSGEWVDT.LK_RSGEWVDT_ANO.GetMoveValues();
            spl15 += "-";
            var spl16 = RSGEWVDT.LK_RSGEWVDT_MES.GetMoveValues();
            spl16 += "-";
            var spl17 = RSGEWVDT.LK_RSGEWVDT_DIA.GetMoveValues();
            var results18 = spl15 + spl16 + spl17;
            _.Move(results18, RSGEWVDT.LK_RSGEWVDT_OUT_DATA);
            #endregion

            /*" -198- MOVE 0 TO LK-RSGEWVDT-IND-RETORNO. */
            _.Move(0, RSGEWVDT.LK_RSGEWVDT_IND_RETORNO);

        }

        [StopWatch]
        /*" R0001-99-FIM */
        private void R0001_99_FIM(bool isPerform = false)
        {
            /*" -204- GOBACK. */

            throw new GoBack();

        }
    }
}