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
    public class PROM1102
    {
        public bool IsCall { get; set; }

        public PROM1102()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROM1102                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  PROCASEG (KATIA)                   *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CALCULO DE DIGITO ATE 15 POS.      *      */
        /*"      *                             ROTINA DEVERA RETORNAR O DIGITO    *      */
        /*"      *                             VERIFICADOR PELO MODULO 10.        *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  KATIA                              *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  JANEIRO/1996                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01  CAMPOS-WORK.*/
        public PROM1102_CAMPOS_WORK CAMPOS_WORK { get; set; } = new PROM1102_CAMPOS_WORK();
        public class PROM1102_CAMPOS_WORK : VarBasis
        {
            /*"    05         WPARM01-AUX     PIC  9(002).*/
            public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05         WPARM01-AUXR    REDEFINES   WPARM01-AUX.*/
            private _REDEF_PROM1102_WPARM01_AUXR _wparm01_auxr { get; set; }
            public _REDEF_PROM1102_WPARM01_AUXR WPARM01_AUXR
            {
                get { _wparm01_auxr = new _REDEF_PROM1102_WPARM01_AUXR(); _.Move(WPARM01_AUX, _wparm01_auxr); VarBasis.RedefinePassValue(WPARM01_AUX, _wparm01_auxr, WPARM01_AUX); _wparm01_auxr.ValueChanged += () => { _.Move(_wparm01_auxr, WPARM01_AUX); }; return _wparm01_auxr; }
                set { VarBasis.RedefinePassValue(value, _wparm01_auxr, WPARM01_AUX); }
            }  //Redefines
            public class _REDEF_PROM1102_WPARM01_AUXR : VarBasis
            {
                /*"        10     WPARM01-AUX1    PIC  9(001).*/
                public IntBasis WPARM01_AUX1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"        10     WPARM01-AUX2    PIC  9(001).*/
                public IntBasis WPARM01_AUX2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05         WQUOCIENTE      PIC S9(004) COMP-3  VALUE  ZEROS.*/

                public _REDEF_PROM1102_WPARM01_AUXR()
                {
                    WPARM01_AUX1.ValueChanged += OnValueChanged;
                    WPARM01_AUX2.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         WRESTO          PIC S9(004) COMP-3  VALUE  ZEROS.*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         WCOMPARA        PIC S9(004) COMP-3  VALUE  ZEROS.*/
            public IntBasis WCOMPARA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         WPARM01-TOTAL   PIC S9(004) COMP-3  VALUE  ZEROS.*/
            public IntBasis WPARM01_TOTAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05         WPARM01-TOT     PIC S9(004) COMP-3  VALUE  ZEROS.*/
            public IntBasis WPARM01_TOT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01              LPARM01X.*/
        }
        public PROM1102_LPARM01X LPARM01X { get; set; } = new PROM1102_LPARM01X();
        public class PROM1102_LPARM01X : VarBasis
        {
            /*"  03            LPARM01         PIC  9(015).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_PROM1102_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_PROM1102_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_PROM1102_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_PROM1102_LPARM01_R : VarBasis
            {
                /*"    05          LPARM01-1       PIC  9(001).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-2       PIC  9(001).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-3       PIC  9(001).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-4       PIC  9(001).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-5       PIC  9(001).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-6       PIC  9(001).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-7       PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-8       PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-9       PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-10      PIC  9(001).*/
                public IntBasis LPARM01_10 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-11      PIC  9(001).*/
                public IntBasis LPARM01_11 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-12      PIC  9(001).*/
                public IntBasis LPARM01_12 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-13      PIC  9(001).*/
                public IntBasis LPARM01_13 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-14      PIC  9(001).*/
                public IntBasis LPARM01_14 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05          LPARM01-15      PIC  9(001).*/
                public IntBasis LPARM01_15 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03            LPARM02         PIC S9(004) COMP.*/

                public _REDEF_PROM1102_LPARM01_R()
                {
                    LPARM01_1.ValueChanged += OnValueChanged;
                    LPARM01_2.ValueChanged += OnValueChanged;
                    LPARM01_3.ValueChanged += OnValueChanged;
                    LPARM01_4.ValueChanged += OnValueChanged;
                    LPARM01_5.ValueChanged += OnValueChanged;
                    LPARM01_6.ValueChanged += OnValueChanged;
                    LPARM01_7.ValueChanged += OnValueChanged;
                    LPARM01_8.ValueChanged += OnValueChanged;
                    LPARM01_9.ValueChanged += OnValueChanged;
                    LPARM01_10.ValueChanged += OnValueChanged;
                    LPARM01_11.ValueChanged += OnValueChanged;
                    LPARM01_12.ValueChanged += OnValueChanged;
                    LPARM01_13.ValueChanged += OnValueChanged;
                    LPARM01_14.ValueChanged += OnValueChanged;
                    LPARM01_15.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03            LPARM03         PIC  9(001).*/
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03            LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
            private _REDEF_StringBasis _lparm03_r { get; set; }
            public _REDEF_StringBasis LPARM03_R
            {
                get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
                set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
            }  //Redefines
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROM1102_LPARM01X PROM1102_LPARM01X_P) //PROCEDURE DIVISION USING 
        /*LPARM01X*/
        {
            try
            {
                this.LPARM01X = PROM1102_LPARM01X_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM01X };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -83- IF LPARM01 NOT NUMERIC */

            if (!LPARM01X.LPARM01.IsNumeric())
            {

                /*" -86- MOVE ALL '9' TO LPARM01 LPARM02 LPARM03 */
                _.MoveAll("9", LPARM01X.LPARM01, LPARM01X.LPARM02, LPARM01X.LPARM03);

                /*" -88- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -90- COMPUTE WPARM01-AUX = LPARM01-1 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_1 * 2;

            /*" -92- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -94- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -96- COMPUTE WPARM01-AUX = LPARM01-2 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_2 * 1;

            /*" -98- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -100- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -102- COMPUTE WPARM01-AUX = LPARM01-3 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_3 * 2;

            /*" -104- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -106- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -108- COMPUTE WPARM01-AUX = LPARM01-4 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_4 * 1;

            /*" -110- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -112- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -114- COMPUTE WPARM01-AUX = LPARM01-5 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_5 * 2;

            /*" -116- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -118- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -120- COMPUTE WPARM01-AUX = LPARM01-6 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_6 * 1;

            /*" -122- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -124- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -126- COMPUTE WPARM01-AUX = LPARM01-7 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_7 * 2;

            /*" -128- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -130- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -132- COMPUTE WPARM01-AUX = LPARM01-8 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_8 * 1;

            /*" -134- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -136- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -138- COMPUTE WPARM01-AUX = LPARM01-9 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_9 * 2;

            /*" -140- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -142- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -144- COMPUTE WPARM01-AUX = LPARM01-10 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_10 * 1;

            /*" -146- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -148- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -150- COMPUTE WPARM01-AUX = LPARM01-11 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_11 * 2;

            /*" -152- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -154- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -156- COMPUTE WPARM01-AUX = LPARM01-12 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_12 * 1;

            /*" -158- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -160- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -162- COMPUTE WPARM01-AUX = LPARM01-13 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_13 * 2;

            /*" -164- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -166- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -168- COMPUTE WPARM01-AUX = LPARM01-14 * 1. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_14 * 1;

            /*" -170- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -172- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -174- COMPUTE WPARM01-AUX = LPARM01-15 * 2. */
            CAMPOS_WORK.WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -176- COMPUTE WPARM01-TOT = WPARM01-AUX1 + WPARM01-AUX2. */
            CAMPOS_WORK.WPARM01_TOT.Value = CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX1 + CAMPOS_WORK.WPARM01_AUXR.WPARM01_AUX2;

            /*" -178- COMPUTE WPARM01-TOTAL = WPARM01-TOTAL + WPARM01-TOT. */
            CAMPOS_WORK.WPARM01_TOTAL.Value = CAMPOS_WORK.WPARM01_TOTAL + CAMPOS_WORK.WPARM01_TOT;

            /*" -181- DIVIDE WPARM01-TOTAL BY 10 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(CAMPOS_WORK.WPARM01_TOTAL, 10, CAMPOS_WORK.WQUOCIENTE, CAMPOS_WORK.WRESTO);

            /*" -184- SUBTRACT WRESTO FROM 10 GIVING WCOMPARA. */
            CAMPOS_WORK.WCOMPARA.Value = 10 - CAMPOS_WORK.WRESTO;

            /*" -185- IF WCOMPARA EQUAL 10 */

            if (CAMPOS_WORK.WCOMPARA == 10)
            {

                /*" -186- MOVE ZEROS TO LPARM03 */
                _.Move(0, LPARM01X.LPARM03);

                /*" -187- ELSE */
            }
            else
            {


                /*" -187- MOVE WCOMPARA TO LPARM03. */
                _.Move(CAMPOS_WORK.WCOMPARA, LPARM01X.LPARM03);
            }


            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -190- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}