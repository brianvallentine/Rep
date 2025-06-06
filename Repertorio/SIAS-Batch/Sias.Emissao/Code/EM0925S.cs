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
    public class EM0925S
    {
        public bool IsCall { get; set; }

        public EM0925S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  EM0925S                            *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  EDUARDO                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  DADAS DUAS DATAS, UMA DE INICIO E  *      */
        /*"      *                             OUTRA DE TERMINO CALCULAR A QTDADE *      */
        /*"      *                             DE MESES A DECORRER ENTRE AS MESMAS*      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  EDUARDO                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  DEZEMBRO/1999                      *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      * 10/11/2000  CONVERSAO PARA PROCESSAMENTO BATCH EDU(PRODEXTER)  *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01              FILLER.*/
        public EM0925S_FILLER_0 FILLER_0 { get; set; } = new EM0925S_FILLER_0();
        public class EM0925S_FILLER_0 : VarBasis
        {
            /*"  03            WDATA-INV-INI   PIC  9(008).*/
            public IntBasis WDATA_INV_INI { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  03            FILLER          REDEFINES WDATA-INV-INI.*/
            private _REDEF_EM0925S_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM0925S_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM0925S_FILLER_1(); _.Move(WDATA_INV_INI, _filler_1); VarBasis.RedefinePassValue(WDATA_INV_INI, _filler_1, WDATA_INV_INI); _filler_1.ValueChanged += () => { _.Move(_filler_1, WDATA_INV_INI); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WDATA_INV_INI); }
            }  //Redefines
            public class _REDEF_EM0925S_FILLER_1 : VarBasis
            {
                /*"   05           WDATA-INI-ANO   PIC  9(004).*/
                public IntBasis WDATA_INI_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05           WDATA-INI-MES   PIC  9(002).*/
                public IntBasis WDATA_INI_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05           WDATA-INI-DIA   PIC  9(002).*/
                public IntBasis WDATA_INI_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WDATA-INV-FIM   PIC  9(008).*/

                public _REDEF_EM0925S_FILLER_1()
                {
                    WDATA_INI_ANO.ValueChanged += OnValueChanged;
                    WDATA_INI_MES.ValueChanged += OnValueChanged;
                    WDATA_INI_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WDATA_INV_FIM { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"  03            FILLER          REDEFINES WDATA-INV-FIM.*/
            private _REDEF_EM0925S_FILLER_2 _filler_2 { get; set; }
            public _REDEF_EM0925S_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_EM0925S_FILLER_2(); _.Move(WDATA_INV_FIM, _filler_2); VarBasis.RedefinePassValue(WDATA_INV_FIM, _filler_2, WDATA_INV_FIM); _filler_2.ValueChanged += () => { _.Move(_filler_2, WDATA_INV_FIM); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WDATA_INV_FIM); }
            }  //Redefines
            public class _REDEF_EM0925S_FILLER_2 : VarBasis
            {
                /*"   05           WDATA-FIM-ANO   PIC  9(004).*/
                public IntBasis WDATA_FIM_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"   05           WDATA-FIM-MES   PIC  9(002).*/
                public IntBasis WDATA_FIM_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   05           WDATA-FIM-DIA   PIC  9(002).*/
                public IntBasis WDATA_FIM_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01              LPARM.*/

                public _REDEF_EM0925S_FILLER_2()
                {
                    WDATA_FIM_ANO.ValueChanged += OnValueChanged;
                    WDATA_FIM_MES.ValueChanged += OnValueChanged;
                    WDATA_FIM_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM0925S_LPARM LPARM { get; set; } = new EM0925S_LPARM();
        public class EM0925S_LPARM : VarBasis
        {
            /*"    03          LPARM01.*/
            public EM0925S_LPARM01 LPARM01 { get; set; } = new EM0925S_LPARM01();
            public class EM0925S_LPARM01 : VarBasis
            {
                /*"       05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       LPARM01-AA      PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          LPARM02.*/
            }
            public EM0925S_LPARM02 LPARM02 { get; set; } = new EM0925S_LPARM02();
            public class EM0925S_LPARM02 : VarBasis
            {
                /*"       05       LPARM02-DD      PIC  9(002).*/
                public IntBasis LPARM02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       LPARM02-MM      PIC  9(002).*/
                public IntBasis LPARM02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       LPARM02-AA      PIC  9(004).*/
                public IntBasis LPARM02_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          LPARM03         PIC S9(005)      COMP-3.*/
            }
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(EM0925S_LPARM EM0925S_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = EM0925S_LPARM_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -82- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM M_000_010_CONSISTE_PARM01 */

            M_000_010_CONSISTE_PARM01();

        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARM01 */
        private void M_000_010_CONSISTE_PARM01(bool isPerform = false)
        {
            /*" -84- IF LPARM01 NOT NUMERIC */

            if (!LPARM.LPARM01.IsNumeric())
            {

                /*" -86- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -87- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -88- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -90- IF LPARM01-MM LESS 1 OR LPARM01-MM GREATER 12 */

            if (LPARM.LPARM01.LPARM01_MM < 1 || LPARM.LPARM01.LPARM01_MM > 12)
            {

                /*" -92- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -93- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -93- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARM02 */
        private void M_000_010_CONSISTE_PARM02(bool isPerform = false)
        {
            /*" -97- IF LPARM02 NOT NUMERIC */

            if (!LPARM.LPARM02.IsNumeric())
            {

                /*" -99- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -100- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -101- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -103- IF LPARM02-MM LESS 1 OR LPARM02-MM GREATER 12 */

            if (LPARM.LPARM02.LPARM02_MM < 1 || LPARM.LPARM02.LPARM02_MM > 12)
            {

                /*" -105- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -106- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -106- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARM03 */
        private void M_000_010_CONSISTE_PARM03(bool isPerform = false)
        {
            /*" -109- MOVE ZEROS TO LPARM03. */
            _.Move(0, LPARM.LPARM03);

        }

        [StopWatch]
        /*" M-000-030-INVERTE-DATAS */
        private void M_000_030_INVERTE_DATAS(bool isPerform = false)
        {
            /*" -114- MOVE LPARM01-AA TO WDATA-INI-ANO. */
            _.Move(LPARM.LPARM01.LPARM01_AA, FILLER_0.FILLER_1.WDATA_INI_ANO);

            /*" -115- MOVE LPARM01-MM TO WDATA-INI-MES. */
            _.Move(LPARM.LPARM01.LPARM01_MM, FILLER_0.FILLER_1.WDATA_INI_MES);

            /*" -117- MOVE LPARM01-DD TO WDATA-INI-DIA. */
            _.Move(LPARM.LPARM01.LPARM01_DD, FILLER_0.FILLER_1.WDATA_INI_DIA);

            /*" -118- MOVE LPARM02-AA TO WDATA-FIM-ANO. */
            _.Move(LPARM.LPARM02.LPARM02_AA, FILLER_0.FILLER_2.WDATA_FIM_ANO);

            /*" -119- MOVE LPARM02-MM TO WDATA-FIM-MES. */
            _.Move(LPARM.LPARM02.LPARM02_MM, FILLER_0.FILLER_2.WDATA_FIM_MES);

            /*" -119- MOVE LPARM02-DD TO WDATA-FIM-DIA. */
            _.Move(LPARM.LPARM02.LPARM02_DD, FILLER_0.FILLER_2.WDATA_FIM_DIA);

        }

        [StopWatch]
        /*" M-000-030-CALCULA-MESES */
        private void M_000_030_CALCULA_MESES(bool isPerform = false)
        {
            /*" -123- IF WDATA-INV-INI GREATER WDATA-INV-FIM */

            if (FILLER_0.WDATA_INV_INI > FILLER_0.WDATA_INV_FIM)
            {

                /*" -125- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -127- ADD 1 TO LPARM03. */
            LPARM.LPARM03.Value = LPARM.LPARM03 + 1;

            /*" -128- ADD 1 TO WDATA-INI-MES. */
            FILLER_0.FILLER_1.WDATA_INI_MES.Value = FILLER_0.FILLER_1.WDATA_INI_MES + 1;

            /*" -129- IF WDATA-INI-MES GREATER 12 */

            if (FILLER_0.FILLER_1.WDATA_INI_MES > 12)
            {

                /*" -130- MOVE 1 TO WDATA-INI-MES */
                _.Move(1, FILLER_0.FILLER_1.WDATA_INI_MES);

                /*" -132- ADD 1 TO WDATA-INI-ANO. */
                FILLER_0.FILLER_1.WDATA_INI_ANO.Value = FILLER_0.FILLER_1.WDATA_INI_ANO + 1;
            }


            /*" -132- GO TO 000-030-CALCULA-MESES. */
            new Task(() => M_000_030_CALCULA_MESES()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -136- ADD 1 TO LPARM03. */
            LPARM.LPARM03.Value = LPARM.LPARM03 + 1;

            /*" -136- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}