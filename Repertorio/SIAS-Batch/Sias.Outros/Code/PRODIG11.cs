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
    public class PRODIG11
    {
        public bool IsCall { get; set; }

        public PRODIG11()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PRODIG11                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  FONSECA                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CALCULO DE DIGITO VERIFICADOR      *      */
        /*"      *                             MODULO 11 PADRAO CEF               *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  03/03/94.                          *      */
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
        /*"01  LPARM01                     PIC  9(018).*/
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "18", "9(018)."));
        /*"01  LPARM01-R                   REDEFINES   LPARM01.*/
        private _REDEF_PRODIG11_LPARM01_R _lparm01_r { get; set; }
        public _REDEF_PRODIG11_LPARM01_R LPARM01_R
        {
            get { _lparm01_r = new _REDEF_PRODIG11_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
            set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
        }  //Redefines
        public class _REDEF_PRODIG11_LPARM01_R : VarBasis
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
            /*"    05          LPARM01-16      PIC  9(001).*/
            public IntBasis LPARM01_16 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-17      PIC  9(001).*/
            public IntBasis LPARM01_17 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    05          LPARM01-18      PIC  9(001).*/
            public IntBasis LPARM01_18 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01              LPARM03         PIC  9(001).*/

            public _REDEF_PRODIG11_LPARM01_R()
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
                LPARM01_16.ValueChanged += OnValueChanged;
                LPARM01_17.ValueChanged += OnValueChanged;
                LPARM01_18.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        /*"01              LPARM03-R       REDEFINES   LPARM03                                PIC  X(001).*/
        private _REDEF_StringBasis _lparm03_r { get; set; }
        public _REDEF_StringBasis LPARM03_R
        {
            get { _lparm03_r = new _REDEF_StringBasis(new PIC("X", "001", "X(001).")); ; _.Move(LPARM03, _lparm03_r); VarBasis.RedefinePassValue(LPARM03, _lparm03_r, LPARM03); _lparm03_r.ValueChanged += () => { _.Move(_lparm03_r, LPARM03); }; return _lparm03_r; }
            set { VarBasis.RedefinePassValue(value, _lparm03_r, LPARM03); }
        }  //Redefines

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(IntBasis LPARM01_P, IntBasis LPARM03_P) //PROCEDURE DIVISION USING 
        /*LPARM01 LPARM03*/
        {
            try
            {
                this.LPARM01.Value = LPARM01_P.Value;
                this.LPARM03.Value = LPARM03_P.Value;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM01, LPARM03 };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -61- IF LPARM01-R NOT NUMERIC */

            if (!LPARM01_R.IsNumeric())
            {

                /*" -63- MOVE ALL '9' TO LPARM01-R LPARM03-R */
                _.MoveAll("9", LPARM01_R, LPARM03_R);

                /*" -65- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -85- COMPUTE WPARM01-AUX = LPARM01-1 * 3 + LPARM01-2 * 2 + LPARM01-3 * 9 + LPARM01-4 * 8 + LPARM01-5 * 7 + LPARM01-6 * 6 + LPARM01-7 * 5 + LPARM01-8 * 4 + LPARM01-9 * 3 + LPARM01-10 * 2 + LPARM01-11 * 9 + LPARM01-12 * 8 + LPARM01-13 * 7 + LPARM01-14 * 6 + LPARM01-15 * 5 + LPARM01-16 * 4 + LPARM01-17 * 3 + LPARM01-18 * 2. */
            WPARM01_AUX.Value = LPARM01_R.LPARM01_1 * 3 + LPARM01_R.LPARM01_2 * 2 + LPARM01_R.LPARM01_3 * 9 + LPARM01_R.LPARM01_4 * 8 + LPARM01_R.LPARM01_5 * 7 + LPARM01_R.LPARM01_6 * 6 + LPARM01_R.LPARM01_7 * 5 + LPARM01_R.LPARM01_8 * 4 + LPARM01_R.LPARM01_9 * 3 + LPARM01_R.LPARM01_10 * 2 + LPARM01_R.LPARM01_11 * 9 + LPARM01_R.LPARM01_12 * 8 + LPARM01_R.LPARM01_13 * 7 + LPARM01_R.LPARM01_14 * 6 + LPARM01_R.LPARM01_15 * 5 + LPARM01_R.LPARM01_16 * 4 + LPARM01_R.LPARM01_17 * 3 + LPARM01_R.LPARM01_18 * 2;

            /*" -88- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(WPARM01_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -89- IF WRESTO EQUAL 1 */

            if (WRESTO == 1)
            {

                /*" -90- MOVE 0 TO LPARM03 */
                _.Move(0, LPARM03);

                /*" -91- ELSE */
            }
            else
            {


                /*" -92- IF WRESTO EQUAL ZEROS */

                if (WRESTO == 00)
                {

                    /*" -93- MOVE 0 TO LPARM03 */
                    _.Move(0, LPARM03);

                    /*" -94- ELSE */
                }
                else
                {


                    /*" -95- SUBTRACT WRESTO FROM 11 GIVING LPARM03. */
                    LPARM03.Value = 11 - WRESTO;
                }

            }


        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -99- GOBACK. */

            throw new GoBack();

        }
    }
}