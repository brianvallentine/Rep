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
    public class PROCPF01
    {
        public bool IsCall { get; set; }

        public PROCPF01()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROCPF01                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ROGERIO                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CALCULA O DIGITO VERIFICADOR PELO  *      */
        /*"      *                             MODULO 11.                         *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  LAERTE                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  OUTUBRO/1990                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"77              WSOMAT-AUX      PIC S9(005) COMP-3  VALUE  +0.*/
        public IntBasis WSOMAT_AUX { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"77              WQUOCIENTE      PIC S9(003) COMP-3  VALUE  +0.*/
        public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"77              WRESTO          PIC S9(003) COMP-3  VALUE  +0.*/
        public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01              LPARM.*/
        public PROCPF01_LPARM LPARM { get; set; } = new PROCPF01_LPARM();
        public class PROCPF01_LPARM : VarBasis
        {
            /*"  03            LPARM01         PIC  9(009).*/
            public IntBasis LPARM01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  03            LPARM01-R       REDEFINES   LPARM01.*/
            private _REDEF_PROCPF01_LPARM01_R _lparm01_r { get; set; }
            public _REDEF_PROCPF01_LPARM01_R LPARM01_R
            {
                get { _lparm01_r = new _REDEF_PROCPF01_LPARM01_R(); _.Move(LPARM01, _lparm01_r); VarBasis.RedefinePassValue(LPARM01, _lparm01_r, LPARM01); _lparm01_r.ValueChanged += () => { _.Move(_lparm01_r, LPARM01); }; return _lparm01_r; }
                set { VarBasis.RedefinePassValue(value, _lparm01_r, LPARM01); }
            }  //Redefines
            public class _REDEF_PROCPF01_LPARM01_R : VarBasis
            {
                /*"      05        LPARM01-1       PIC  9(001).*/
                public IntBasis LPARM01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-2       PIC  9(001).*/
                public IntBasis LPARM01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-3       PIC  9(001).*/
                public IntBasis LPARM01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-4       PIC  9(001).*/
                public IntBasis LPARM01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-5       PIC  9(001).*/
                public IntBasis LPARM01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-6       PIC  9(001).*/
                public IntBasis LPARM01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-7       PIC  9(001).*/
                public IntBasis LPARM01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-8       PIC  9(001).*/
                public IntBasis LPARM01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM01-9       PIC  9(001).*/
                public IntBasis LPARM01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03            LPARM02         PIC  9(002).*/

                public _REDEF_PROCPF01_LPARM01_R()
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
                }

            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03            LPARM02-R       REDEFINES   LPARM02.*/
            private _REDEF_PROCPF01_LPARM02_R _lparm02_r { get; set; }
            public _REDEF_PROCPF01_LPARM02_R LPARM02_R
            {
                get { _lparm02_r = new _REDEF_PROCPF01_LPARM02_R(); _.Move(LPARM02, _lparm02_r); VarBasis.RedefinePassValue(LPARM02, _lparm02_r, LPARM02); _lparm02_r.ValueChanged += () => { _.Move(_lparm02_r, LPARM02); }; return _lparm02_r; }
                set { VarBasis.RedefinePassValue(value, _lparm02_r, LPARM02); }
            }  //Redefines
            public class _REDEF_PROCPF01_LPARM02_R : VarBasis
            {
                /*"      05        LPARM02-1       PIC  9(001).*/
                public IntBasis LPARM02_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      05        LPARM02-2       PIC  9(001).*/
                public IntBasis LPARM02_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));

                public _REDEF_PROCPF01_LPARM02_R()
                {
                    LPARM02_1.ValueChanged += OnValueChanged;
                    LPARM02_2.ValueChanged += OnValueChanged;
                }

            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROCPF01_LPARM PROCPF01_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROCPF01_LPARM_P;

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
            /*" -68- IF LPARM01 NOT NUMERIC */

            if (!LPARM.LPARM01.IsNumeric())
            {

                /*" -70- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -72- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -84- COMPUTE WSOMAT-AUX = LPARM01-1 * 10 + LPARM01-2 * 9 + LPARM01-3 * 8 + LPARM01-4 * 7 + LPARM01-5 * 6 + LPARM01-6 * 5 + LPARM01-7 * 4 + LPARM01-8 * 3 + LPARM01-9 * 2 */
            WSOMAT_AUX.Value = LPARM.LPARM01_R.LPARM01_1 * 10 + LPARM.LPARM01_R.LPARM01_2 * 9 + LPARM.LPARM01_R.LPARM01_3 * 8 + LPARM.LPARM01_R.LPARM01_4 * 7 + LPARM.LPARM01_R.LPARM01_5 * 6 + LPARM.LPARM01_R.LPARM01_6 * 5 + LPARM.LPARM01_R.LPARM01_7 * 4 + LPARM.LPARM01_R.LPARM01_8 * 3 + LPARM.LPARM01_R.LPARM01_9 * 2;

            /*" -86- COMPUTE WQUOCIENTE = WSOMAT-AUX / 11 */
            WQUOCIENTE.Value = WSOMAT_AUX / 11;

            /*" -89- COMPUTE WRESTO = WSOMAT-AUX - (WQUOCIENTE * 11) */
            WRESTO.Value = WSOMAT_AUX - (WQUOCIENTE * 11);

            /*" -90- IF WRESTO EQUAL 1 */

            if (WRESTO == 1)
            {

                /*" -91- MOVE 0 TO LPARM02-1 */
                _.Move(0, LPARM.LPARM02_R.LPARM02_1);

                /*" -92- ELSE */
            }
            else
            {


                /*" -93- IF WRESTO EQUAL ZEROS */

                if (WRESTO == 00)
                {

                    /*" -94- MOVE 0 TO LPARM02-1 */
                    _.Move(0, LPARM.LPARM02_R.LPARM02_1);

                    /*" -95- ELSE */
                }
                else
                {


                    /*" -98- SUBTRACT WRESTO FROM 11 GIVING LPARM02-1. */
                    LPARM.LPARM02_R.LPARM02_1.Value = 11 - WRESTO;
                }

            }


            /*" -110- COMPUTE WSOMAT-AUX = LPARM01-1 * 11 + LPARM01-2 * 10 + LPARM01-3 * 9 + LPARM01-4 * 8 + LPARM01-5 * 7 + LPARM01-6 * 6 + LPARM01-7 * 5 + LPARM01-8 * 4 + LPARM01-9 * 3 + LPARM02-1 * 2 */
            WSOMAT_AUX.Value = LPARM.LPARM01_R.LPARM01_1 * 11 + LPARM.LPARM01_R.LPARM01_2 * 10 + LPARM.LPARM01_R.LPARM01_3 * 9 + LPARM.LPARM01_R.LPARM01_4 * 8 + LPARM.LPARM01_R.LPARM01_5 * 7 + LPARM.LPARM01_R.LPARM01_6 * 6 + LPARM.LPARM01_R.LPARM01_7 * 5 + LPARM.LPARM01_R.LPARM01_8 * 4 + LPARM.LPARM01_R.LPARM01_9 * 3 + LPARM.LPARM02_R.LPARM02_1 * 2;

            /*" -112- COMPUTE WQUOCIENTE = WSOMAT-AUX / 11 */
            WQUOCIENTE.Value = WSOMAT_AUX / 11;

            /*" -115- COMPUTE WRESTO = WSOMAT-AUX - (WQUOCIENTE * 11) */
            WRESTO.Value = WSOMAT_AUX - (WQUOCIENTE * 11);

            /*" -116- IF WRESTO EQUAL 1 */

            if (WRESTO == 1)
            {

                /*" -117- MOVE 0 TO LPARM02-2 */
                _.Move(0, LPARM.LPARM02_R.LPARM02_2);

                /*" -118- ELSE */
            }
            else
            {


                /*" -119- IF WRESTO EQUAL ZEROS */

                if (WRESTO == 00)
                {

                    /*" -120- MOVE 0 TO LPARM02-2 */
                    _.Move(0, LPARM.LPARM02_R.LPARM02_2);

                    /*" -121- ELSE */
                }
                else
                {


                    /*" -122- SUBTRACT WRESTO FROM 11 GIVING LPARM02-2. */
                    LPARM.LPARM02_R.LPARM02_2.Value = 11 - WRESTO;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -125- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}