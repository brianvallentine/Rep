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
    public class PROTIT01
    {
        public bool IsCall { get; set; }

        public PROTIT01()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROTIT01                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CALCULO DE DIGITO VERIFICADOR      *      */
        /*"      *                             PADRAO SICOB                       *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  28/08/95                           *      */
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
        public PROTIT01_LPARM01X LPARM01X { get; set; } = new PROTIT01_LPARM01X();
        public class PROTIT01_LPARM01X : VarBasis
        {
            /*"  03            LPARM01         PIC  9(010).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "10", "9(010)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_PROTIT01_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_PROTIT01_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_PROTIT01_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_PROTIT01_LPARM01_R : VarBasis
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
                /*"  03            LPARM01-D1      PIC  9(001).*/

                public _REDEF_PROTIT01_LPARM01_R()
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
                }

            }
            public IntBasis LPARM01_D1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  03            LPARM01-RC      PIC S9(004) COMP.*/
            public IntBasis LPARM01_RC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROTIT01_LPARM01X PROTIT01_LPARM01X_P) //PROCEDURE DIVISION USING 
        /*LPARM01X*/
        {
            try
            {
                this.LPARM01X = PROTIT01_LPARM01X_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM01X };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -53- IF LPARM01 NOT NUMERIC */

            if (!LPARM01X.LPARM01.IsNumeric())
            {

                /*" -54- MOVE +9 TO LPARM01-RC */
                _.Move(+9, LPARM01X.LPARM01_RC);

                /*" -74- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -85- COMPUTE WPARM01-AUX = LPARM01-1 * 3 + LPARM01-2 * 2 + LPARM01-3 * 9 + LPARM01-4 * 8 + LPARM01-5 * 7 + LPARM01-6 * 6 + LPARM01-7 * 5 + LPARM01-8 * 4 + LPARM01-9 * 3 + LPARM01-10 * 2. */
            WPARM01_AUX.Value = LPARM01X.LPARM01_R.LPARM01_1 * 3 + LPARM01X.LPARM01_R.LPARM01_2 * 2 + LPARM01X.LPARM01_R.LPARM01_3 * 9 + LPARM01X.LPARM01_R.LPARM01_4 * 8 + LPARM01X.LPARM01_R.LPARM01_5 * 7 + LPARM01X.LPARM01_R.LPARM01_6 * 6 + LPARM01X.LPARM01_R.LPARM01_7 * 5 + LPARM01X.LPARM01_R.LPARM01_8 * 4 + LPARM01X.LPARM01_R.LPARM01_9 * 3 + LPARM01X.LPARM01_R.LPARM01_10 * 2;

            /*" -88- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(WPARM01_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -89- IF WRESTO EQUAL ZEROS */

            if (WRESTO == 00)
            {

                /*" -90- MOVE 0 TO LPARM01-D1 */
                _.Move(0, LPARM01X.LPARM01_D1);

                /*" -91- ELSE */
            }
            else
            {


                /*" -94- SUBTRACT WRESTO FROM 11 GIVING LPARM01-D1. */
                LPARM01X.LPARM01_D1.Value = 11 - WRESTO;
            }


            /*" -94- MOVE +0 TO LPARM01-RC. */
            _.Move(+0, LPARM01X.LPARM01_RC);

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -98- GOBACK. */

            throw new GoBack();

        }
    }
}