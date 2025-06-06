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
    public class PRODIGCX
    {
        public bool IsCall { get; set; }

        public PRODIGCX()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PRODIGCX                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  TERCIO CARVALHO                    *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CALCULO DE DIGITO VERIFICADOR      *      */
        /*"      *                             PARA MATRICULA CAIXA               *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  24/11/2000.                        *      */
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
        /*"01  LPARM01                     PIC  9(007).*/
        public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
        /*"01  LPARM01-R                   REDEFINES   LPARM01.*/
        private _REDEF_PRODIGCX_LPARM01_R _lparm01_r { get; set; }
        public _REDEF_PRODIGCX_LPARM01_R LPARM01_R
        {
            get { _lparm01_r = new _REDEF_PRODIGCX_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
            set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
        }  //Redefines
        public class _REDEF_PRODIGCX_LPARM01_R : VarBasis
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
            /*"01              LPARM03         PIC  9(001).*/

            public _REDEF_PRODIGCX_LPARM01_R()
            {
                LPARM01_1.ValueChanged += OnValueChanged;
                LPARM01_2.ValueChanged += OnValueChanged;
                LPARM01_3.ValueChanged += OnValueChanged;
                LPARM01_4.ValueChanged += OnValueChanged;
                LPARM01_5.ValueChanged += OnValueChanged;
                LPARM01_6.ValueChanged += OnValueChanged;
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
            /*" -49- IF LPARM01-R NOT NUMERIC */

            if (!LPARM01_R.IsNumeric())
            {

                /*" -51- MOVE ALL '9' TO LPARM01-R LPARM03-R */
                _.MoveAll("9", LPARM01_R, LPARM03_R);

                /*" -53- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -61- COMPUTE WPARM01-AUX = LPARM01-1 * 2 + LPARM01-2 * 3 + LPARM01-3 * 4 + LPARM01-4 * 5 + LPARM01-5 * 6 + LPARM01-6 * 7. */
            WPARM01_AUX.Value = LPARM01_R.LPARM01_1 * 2 + LPARM01_R.LPARM01_2 * 3 + LPARM01_R.LPARM01_3 * 4 + LPARM01_R.LPARM01_4 * 5 + LPARM01_R.LPARM01_5 * 6 + LPARM01_R.LPARM01_6 * 7;

            /*" -64- DIVIDE WPARM01-AUX BY 11 GIVING WQUOCIENTE REMAINDER WRESTO. */
            _.Divide(WPARM01_AUX, 11, WQUOCIENTE, WRESTO);

            /*" -65- IF WRESTO EQUAL 10 */

            if (WRESTO == 10)
            {

                /*" -66- MOVE 0 TO LPARM03 */
                _.Move(0, LPARM03);

                /*" -67- ELSE */
            }
            else
            {


                /*" -67- MOVE WRESTO TO LPARM03. */
                _.Move(WRESTO, LPARM03);
            }


        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -71- GOBACK. */

            throw new GoBack();

        }
    }
}