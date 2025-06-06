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
    public class PROM1101
    {
        public bool IsCall { get; set; }

        public PROM1101()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROM1101                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ROGERIO                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  DADO UM NUMERO DE ATE 8 DIGITOS A  *      */
        /*"      *                             ROTINA DEVERA RETORNAR O DIGITO    *      */
        /*"      *                             VERIFICADOR PELO MODULO 11.        *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  LAERTE                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  OUTUBRO/1990                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77              WPARM01-AUX     PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WPARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              WQUOCIENTE      PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77              WRESTO          PIC S9(004) COMP-3  VALUE  ZEROS*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01              LPARM01X.*/
        public PROM1101_LPARM01X LPARM01X { get; set; } = new PROM1101_LPARM01X();
        public class PROM1101_LPARM01X : VarBasis
        {
            /*"  03            LPARM01         PIC  9(015).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_PROM1101_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_PROM1101_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_PROM1101_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_PROM1101_LPARM01_R : VarBasis
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

                public _REDEF_PROM1101_LPARM01_R()
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
        public dynamic Execute(PROM1101_LPARM01X PROM1101_LPARM01X_P) //PROCEDURE DIVISION USING 
        /*LPARM01X*/
        {
            try
            {
                this.LPARM01X = PROM1101_LPARM01X_P;

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


            /*" -105- COMPUTE WPARM01-AUX = LPARM01-1 * 8 + LPARM01-2 * 7 + LPARM01-3 * 6 + LPARM01-4 * 5 + LPARM01-5 * 4 + LPARM01-6 * 3 + LPARM01-7 * 2 + LPARM01-8 * 9 + LPARM01-9 * 8 + LPARM01-10 * 7 + LPARM01-11 * 6 + LPARM01-12 * 5 + LPARM01-13 * 4 + LPARM01-14 * 3 + LPARM01-15 * 2. */
            WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_1 * 8 + LPARM01X.LPARM01_R.LPARM01_2 * 7 + LPARM01X.LPARM01_R.LPARM01_3 * 6 + LPARM01X.LPARM01_R.LPARM01_4 * 5 + LPARM01X.LPARM01_R.LPARM01_5 * 4 + LPARM01X.LPARM01_R.LPARM01_6 * 3 + LPARM01X.LPARM01_R.LPARM01_7 * 2 + LPARM01X.LPARM01_R.LPARM01_8 * 9 + LPARM01X.LPARM01_R.LPARM01_9 * 8 + LPARM01X.LPARM01_R.LPARM01_10 * 7 + LPARM01X.LPARM01_R.LPARM01_11 * 6 + LPARM01X.LPARM01_R.LPARM01_12 * 5 + LPARM01X.LPARM01_R.LPARM01_13 * 4 + LPARM01X.LPARM01_R.LPARM01_14 * 3 + LPARM01X.LPARM01_R.LPARM01_15 * 2;

            /*" -108- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(WPARM01_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -109- IF WRESTO EQUAL 1 */

            if (WRESTO == 1)
            {

                /*" -110- MOVE 0 TO LPARM03 */
                _.Move(0, LPARM01X.LPARM03);

                /*" -111- ELSE */
            }
            else
            {


                /*" -112- IF WRESTO EQUAL ZEROS */

                if (WRESTO == 00)
                {

                    /*" -113- MOVE 1 TO LPARM03 */
                    _.Move(1, LPARM01X.LPARM03);

                    /*" -114- ELSE */
                }
                else
                {


                    /*" -115- SUBTRACT WRESTO FROM 11 GIVING LPARM03. */
                    LPARM01X.LPARM03.Value = 11 - WRESTO;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -117- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}