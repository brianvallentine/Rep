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
    public class PROCONC1
    {
        public bool IsCall { get; set; }

        public PROCONC1()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROCONC1                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ROGERIO                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  CONSISTE A DATA FORNECIDA NO       *      */
        /*"      *                             FORMATO DDMMAAAA.                  *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  LAERTE                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  OUTUBRO/1990                       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 24/01/1998.   *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01              FILLER.*/
        public PROCONC1_FILLER_0 FILLER_0 { get; set; } = new PROCONC1_FILLER_0();
        public class PROCONC1_FILLER_0 : VarBasis
        {
            /*"  03            WQUOCIENTE      PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WRESTO          PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"01              FILLER.*/
        }
        public PROCONC1_FILLER_1 FILLER_1 { get; set; } = new PROCONC1_FILLER_1();
        public class PROCONC1_FILLER_1 : VarBasis
        {
            /*"  03            WTB01-DIAS-MES.*/
            public PROCONC1_WTB01_DIAS_MES WTB01_DIAS_MES { get; set; } = new PROCONC1_WTB01_DIAS_MES();
            public class PROCONC1_WTB01_DIAS_MES : VarBasis
            {
                /*"    05          WTB01-01        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_01 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-02        PIC S9(003) COMP-3  VALUE +28.*/
                public IntBasis WTB01_02 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +28);
                /*"    05          WTB01-03        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_03 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-04        PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB01_04 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB01-05        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_05 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-06        PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB01_06 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB01-07        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_07 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-08        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_08 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-09        PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB01_09 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB01-10        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-11        PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB01_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB01-12        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"  03            FILLER          REDEFINES                WTB01-DIAS-MES.*/
            }
            private _REDEF_PROCONC1_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PROCONC1_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PROCONC1_FILLER_2(); _.Move(WTB01_DIAS_MES, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_MES, _filler_2, WTB01_DIAS_MES); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_MES); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PROCONC1_FILLER_2 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              LPARM01.*/

                public _REDEF_PROCONC1_FILLER_2()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROCONC1_LPARM01 LPARM01 { get; set; } = new PROCONC1_LPARM01();
        public class PROCONC1_LPARM01 : VarBasis
        {
            /*"  03            LPARM01-DD      PIC  9(002).*/
            public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03            LPARM01-MM      PIC  9(002).*/
            public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  03            LPARM01-AA      PIC  9(004).*/
            public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03            LPARM02         PIC  9(001).*/
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROCONC1_LPARM01 PROCONC1_LPARM01_P) //PROCEDURE DIVISION USING 
        /*LPARM01*/
        {
            try
            {
                this.LPARM01 = PROCONC1_LPARM01_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM01 };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -88- MOVE ZEROS TO WQUOCIENTE */
            _.Move(0, FILLER_0.WQUOCIENTE);

            /*" -90- MOVE ZEROS TO WRESTO */
            _.Move(0, FILLER_0.WRESTO);

            /*" -91- MOVE +31 TO WTB01-01. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_01);

            /*" -92- MOVE +28 TO WTB01-02. */
            _.Move(+28, FILLER_1.WTB01_DIAS_MES.WTB01_02);

            /*" -93- MOVE +31 TO WTB01-03. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_03);

            /*" -94- MOVE +30 TO WTB01-04. */
            _.Move(+30, FILLER_1.WTB01_DIAS_MES.WTB01_04);

            /*" -95- MOVE +31 TO WTB01-05. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_05);

            /*" -96- MOVE +30 TO WTB01-06. */
            _.Move(+30, FILLER_1.WTB01_DIAS_MES.WTB01_06);

            /*" -97- MOVE +31 TO WTB01-07. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_07);

            /*" -98- MOVE +31 TO WTB01-08. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_08);

            /*" -99- MOVE +30 TO WTB01-09. */
            _.Move(+30, FILLER_1.WTB01_DIAS_MES.WTB01_09);

            /*" -100- MOVE +31 TO WTB01-10. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_10);

            /*" -101- MOVE +30 TO WTB01-11. */
            _.Move(+30, FILLER_1.WTB01_DIAS_MES.WTB01_11);

            /*" -106- MOVE +31 TO WTB01-12. */
            _.Move(+31, FILLER_1.WTB01_DIAS_MES.WTB01_12);

            /*" -107- MOVE 0 TO LPARM02. */
            _.Move(0, LPARM01.LPARM02);

            /*" -108- IF LPARM01 NOT NUMERIC */

            if (!LPARM01.IsNumeric())
            {

                /*" -109- MOVE 1 TO LPARM02 */
                _.Move(1, LPARM01.LPARM02);

                /*" -110- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -112- IF LPARM01-MM LESS 1 OR LPARM01-MM GREATER 12 */

            if (LPARM01.LPARM01_MM < 1 || LPARM01.LPARM01_MM > 12)
            {

                /*" -113- MOVE 1 TO LPARM02 */
                _.Move(1, LPARM01.LPARM02);

                /*" -114- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -115- IF LPARM01-AA LESS 1 */

            if (LPARM01.LPARM01_AA < 1)
            {

                /*" -116- MOVE 1 TO LPARM02 */
                _.Move(1, LPARM01.LPARM02);

                /*" -118- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -120- DIVIDE LPARM01-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM01.LPARM01_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -121- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -122- MOVE +29 TO WTB01(2). */
                _.Move(+29, FILLER_1.FILLER_2.WTB01[2]);
            }


            /*" -124- IF LPARM01-DD LESS 1 OR LPARM01-DD GREATER WTB01(LPARM01-MM) */

            if (LPARM01.LPARM01_DD < 1 || LPARM01.LPARM01_DD > FILLER_1.FILLER_2.WTB01[LPARM01.LPARM01_MM])
            {

                /*" -124- MOVE 1 TO LPARM02. */
                _.Move(1, LPARM01.LPARM02);
            }


            /*" -0- FLUXCONTROL_PERFORM M_000_900_FIM */

            M_000_900_FIM();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -126- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}