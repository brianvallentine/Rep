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
    public class PROSOMC1
    {
        public bool IsCall { get; set; }

        public PROSOMC1()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROSOMC1                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ROGERIO                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  DADA UMA DATA E UM NUMERO DE DIAS  *      */
        /*"      *                             A SEREM SOMADOS A ESTA DATA, O PRO-*      */
        /*"      *                             GRAMA CALCULARA A DATA RESULTANTE. *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  LAERTE                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  OUTUBRO/1990                       *      */
        /*"      *                                                                *      */
        /*"      *   CONVERSAO PARA O ANO 2000.    EDUARDO. 09/12/1997.           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I02 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis I03 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01              FILLER.*/
        public PROSOMC1_FILLER_0 FILLER_0 { get; set; } = new PROSOMC1_FILLER_0();
        public class PROSOMC1_FILLER_0 : VarBasis
        {
            /*"  03            WQUOCIENTE      PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WRESTO          PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WDIASREST       PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIASREST { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WANOS           PIC S9(015) COMP-3  VALUE  ZEROS*/
            public IntBasis WANOS { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03            WDIAS           PIC S9(015) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"01              FILLER.*/
        }
        public PROSOMC1_FILLER_1 FILLER_1 { get; set; } = new PROSOMC1_FILLER_1();
        public class PROSOMC1_FILLER_1 : VarBasis
        {
            /*"  03            WTB01-DIAS-JULIANO.*/
            public PROSOMC1_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PROSOMC1_WTB01_DIAS_JULIANO();
            public class PROSOMC1_WTB01_DIAS_JULIANO : VarBasis
            {
                /*"    05          WTB01-1         PIC S9(003) COMP-3  VALUE  ZEROS*/
                public IntBasis WTB01_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05          WTB01-2         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB01_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB01-3         PIC S9(003) COMP-3  VALUE +59.*/
                public IntBasis WTB01_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                /*"    05          WTB01-4         PIC S9(003) COMP-3  VALUE +90.*/
                public IntBasis WTB01_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                /*"    05          WTB01-5         PIC S9(003) COMP-3  VALUE +120.*/
                public IntBasis WTB01_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                /*"    05          WTB01-6         PIC S9(003) COMP-3  VALUE +151.*/
                public IntBasis WTB01_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                /*"    05          WTB01-7         PIC S9(003) COMP-3  VALUE +181.*/
                public IntBasis WTB01_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                /*"    05          WTB01-8         PIC S9(003) COMP-3  VALUE +212.*/
                public IntBasis WTB01_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                /*"    05          WTB01-9         PIC S9(003) COMP-3  VALUE +243.*/
                public IntBasis WTB01_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                /*"    05          WTB01-10        PIC S9(003) COMP-3  VALUE +273.*/
                public IntBasis WTB01_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                /*"    05          WTB01-11        PIC S9(003) COMP-3  VALUE +304.*/
                public IntBasis WTB01_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                /*"    05          WTB01-12        PIC S9(003) COMP-3  VALUE +334.*/
                public IntBasis WTB01_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                /*"  03            FILLER          REDEFINES                WTB01-DIAS-JULIANO.*/
            }
            private _REDEF_PROSOMC1_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PROSOMC1_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PROSOMC1_FILLER_2(); _.Move(WTB01_DIAS_JULIANO, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_2, WTB01_DIAS_JULIANO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_JULIANO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROSOMC1_FILLER_2 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB02-DIAS-MES.*/

                public _REDEF_PROSOMC1_FILLER_2()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
            public PROSOMC1_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PROSOMC1_WTB02_DIAS_MES();
            public class PROSOMC1_WTB02_DIAS_MES : VarBasis
            {
                /*"    05          WTB02-1         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB02-2         PIC S9(003) COMP-3  VALUE +28.*/
                public IntBasis WTB02_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +28);
                /*"    05          WTB02-3         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB02-4         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB02_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB02-5         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB02-6         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB02_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB02-7         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB02-8         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB02-9         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB02_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB02-10        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB02-11        PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB02_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB02-12        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB02_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"  03            FILLER          REDEFINES                WTB02-DIAS-MES.*/
            }
            private _REDEF_PROSOMC1_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PROSOMC1_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PROSOMC1_FILLER_3(); _.Move(WTB02_DIAS_MES, _filler_3); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_3, WTB02_DIAS_MES); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB02_DIAS_MES); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WTB02_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PROSOMC1_FILLER_3 : VarBasis
            {
                /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB03-DIAS-JULIANO.*/

                public _REDEF_PROSOMC1_FILLER_3()
                {
                    WTB02.ValueChanged += OnValueChanged;
                }

            }
            public PROSOMC1_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PROSOMC1_WTB03_DIAS_JULIANO();
            public class PROSOMC1_WTB03_DIAS_JULIANO : VarBasis
            {
                /*"    05          WTB03-1         PIC S9(003) COMP-3  VALUE  ZEROS*/
                public IntBasis WTB03_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05          WTB03-2         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB03_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB03-3         PIC S9(003) COMP-3  VALUE +59.*/
                public IntBasis WTB03_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                /*"    05          WTB03-4         PIC S9(003) COMP-3  VALUE +90.*/
                public IntBasis WTB03_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                /*"    05          WTB03-5         PIC S9(003) COMP-3  VALUE +120.*/
                public IntBasis WTB03_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                /*"    05          WTB03-6         PIC S9(003) COMP-3  VALUE +151.*/
                public IntBasis WTB03_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                /*"    05          WTB03-7         PIC S9(003) COMP-3  VALUE +181.*/
                public IntBasis WTB03_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                /*"    05          WTB03-8         PIC S9(003) COMP-3  VALUE +212.*/
                public IntBasis WTB03_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                /*"    05          WTB03-9         PIC S9(003) COMP-3  VALUE +243.*/
                public IntBasis WTB03_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                /*"    05          WTB03-10        PIC S9(003) COMP-3  VALUE +273.*/
                public IntBasis WTB03_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                /*"    05          WTB03-11        PIC S9(003) COMP-3  VALUE +304.*/
                public IntBasis WTB03_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                /*"    05          WTB03-12        PIC S9(003) COMP-3  VALUE +334.*/
                public IntBasis WTB03_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                /*"  03            FILLER          REDEFINES                WTB03-DIAS-JULIANO.*/
            }
            private _REDEF_PROSOMC1_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PROSOMC1_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PROSOMC1_FILLER_4(); _.Move(WTB03_DIAS_JULIANO, _filler_4); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_4, WTB03_DIAS_JULIANO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB03_DIAS_JULIANO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTB03_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROSOMC1_FILLER_4 : VarBasis
            {
                /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              LPARM.*/

                public _REDEF_PROSOMC1_FILLER_4()
                {
                    WTB03.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROSOMC1_LPARM LPARM { get; set; } = new PROSOMC1_LPARM();
        public class PROSOMC1_LPARM : VarBasis
        {
            /*"  03          LPARM01.*/
            public PROSOMC1_LPARM01 LPARM01 { get; set; } = new PROSOMC1_LPARM01();
            public class PROSOMC1_LPARM01 : VarBasis
            {
                /*"     05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     05       LPARM01-AA      PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  03          LPARM02         PIC S9(005)      COMP-3.*/
            }
            public IntBasis LPARM02 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03          LPARM03.*/
            public PROSOMC1_LPARM03 LPARM03 { get; set; } = new PROSOMC1_LPARM03();
            public class PROSOMC1_LPARM03 : VarBasis
            {
                /*"     05       LPARM03-DD      PIC  9(002).*/
                public IntBasis LPARM03_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     05       LPARM03-MM      PIC  9(002).*/
                public IntBasis LPARM03_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"     05       LPARM03-AA      PIC  9(004).*/
                public IntBasis LPARM03_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROSOMC1_LPARM PROSOMC1_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROSOMC1_LPARM_P;

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
            /*" -141- MOVE 0 TO WTB01-1 */
            _.Move(0, FILLER_1.WTB01_DIAS_JULIANO.WTB01_1);

            /*" -142- MOVE +31 TO WTB01-2 */
            _.Move(+31, FILLER_1.WTB01_DIAS_JULIANO.WTB01_2);

            /*" -143- MOVE +59 TO WTB01-3 */
            _.Move(+59, FILLER_1.WTB01_DIAS_JULIANO.WTB01_3);

            /*" -144- MOVE +90 TO WTB01-4 */
            _.Move(+90, FILLER_1.WTB01_DIAS_JULIANO.WTB01_4);

            /*" -145- MOVE +120 TO WTB01-5 */
            _.Move(+120, FILLER_1.WTB01_DIAS_JULIANO.WTB01_5);

            /*" -146- MOVE +151 TO WTB01-6 */
            _.Move(+151, FILLER_1.WTB01_DIAS_JULIANO.WTB01_6);

            /*" -147- MOVE +181 TO WTB01-7 */
            _.Move(+181, FILLER_1.WTB01_DIAS_JULIANO.WTB01_7);

            /*" -148- MOVE +212 TO WTB01-8 */
            _.Move(+212, FILLER_1.WTB01_DIAS_JULIANO.WTB01_8);

            /*" -149- MOVE +243 TO WTB01-9 */
            _.Move(+243, FILLER_1.WTB01_DIAS_JULIANO.WTB01_9);

            /*" -150- MOVE +273 TO WTB01-10 */
            _.Move(+273, FILLER_1.WTB01_DIAS_JULIANO.WTB01_10);

            /*" -151- MOVE +304 TO WTB01-11 */
            _.Move(+304, FILLER_1.WTB01_DIAS_JULIANO.WTB01_11);

            /*" -153- MOVE +334 TO WTB01-12 */
            _.Move(+334, FILLER_1.WTB01_DIAS_JULIANO.WTB01_12);

            /*" -154- MOVE 0 TO WTB03-1 */
            _.Move(0, FILLER_1.WTB03_DIAS_JULIANO.WTB03_1);

            /*" -155- MOVE +31 TO WTB03-2 */
            _.Move(+31, FILLER_1.WTB03_DIAS_JULIANO.WTB03_2);

            /*" -156- MOVE +59 TO WTB03-3 */
            _.Move(+59, FILLER_1.WTB03_DIAS_JULIANO.WTB03_3);

            /*" -157- MOVE +90 TO WTB03-4 */
            _.Move(+90, FILLER_1.WTB03_DIAS_JULIANO.WTB03_4);

            /*" -158- MOVE +120 TO WTB03-5 */
            _.Move(+120, FILLER_1.WTB03_DIAS_JULIANO.WTB03_5);

            /*" -159- MOVE +151 TO WTB03-6 */
            _.Move(+151, FILLER_1.WTB03_DIAS_JULIANO.WTB03_6);

            /*" -160- MOVE +181 TO WTB03-7 */
            _.Move(+181, FILLER_1.WTB03_DIAS_JULIANO.WTB03_7);

            /*" -161- MOVE +212 TO WTB03-8 */
            _.Move(+212, FILLER_1.WTB03_DIAS_JULIANO.WTB03_8);

            /*" -162- MOVE +243 TO WTB03-9 */
            _.Move(+243, FILLER_1.WTB03_DIAS_JULIANO.WTB03_9);

            /*" -163- MOVE +273 TO WTB03-10 */
            _.Move(+273, FILLER_1.WTB03_DIAS_JULIANO.WTB03_10);

            /*" -164- MOVE +304 TO WTB03-11 */
            _.Move(+304, FILLER_1.WTB03_DIAS_JULIANO.WTB03_11);

            /*" -166- MOVE +334 TO WTB03-12 */
            _.Move(+334, FILLER_1.WTB03_DIAS_JULIANO.WTB03_12);

            /*" -166- MOVE +28 TO WTB02-2. */
            _.Move(+28, FILLER_1.WTB02_DIAS_MES.WTB02_2);

            /*" -0- FLUXCONTROL_PERFORM M_000_010_CONSISTE_PARAMETROS */

            M_000_010_CONSISTE_PARAMETROS();

        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARAMETROS */
        private void M_000_010_CONSISTE_PARAMETROS(bool isPerform = false)
        {
            /*" -173- IF LPARM01 NOT NUMERIC OR LPARM02 NOT NUMERIC OR LPARM01-MM LESS 1 OR LPARM01-MM GREATER 12 */

            if (!LPARM.LPARM01.IsNumeric() || !LPARM.LPARM02.IsNumeric() || LPARM.LPARM01.LPARM01_MM < 1 || LPARM.LPARM01.LPARM01_MM > 12)
            {

                /*" -176- MOVE ALL '9' TO LPARM01 LPARM02 LPARM03 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02, LPARM.LPARM03);

                /*" -178- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -180- DIVIDE LPARM01-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.LPARM01.LPARM01_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -181- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -182- MOVE +29 TO WTB02(2). */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);
            }


            /*" -184- IF LPARM01-DD LESS 1 OR LPARM01-DD GREATER WTB02(LPARM01-MM) */

            if (LPARM.LPARM01.LPARM01_DD < 1 || LPARM.LPARM01.LPARM01_DD > FILLER_1.FILLER_3.WTB02[LPARM.LPARM01.LPARM01_MM])
            {

                /*" -187- MOVE ALL '9' TO LPARM01 LPARM02 LPARM03 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02, LPARM.LPARM03);

                /*" -188- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -188- PERFORM 000-030-CONVERTE-EM-DIAS. */

            M_000_030_CONVERTE_EM_DIAS(true);

        }

        [StopWatch]
        /*" M-000-030-CONVERTE-EM-DIAS */
        private void M_000_030_CONVERTE_EM_DIAS(bool isPerform = false)
        {
            /*" -192- MULTIPLY 365,25 BY LPARM01-AA GIVING WDIAS. */
            _.Multiply(365.25, LPARM.LPARM01.LPARM01_AA, FILLER_0.WDIAS);

            /*" -193- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -194- MOVE +29 TO WTB02(2) */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);

                /*" -204- ADD +1 TO WTB01(3) WTB01(4) WTB01(5) WTB01(6) WTB01(7) WTB01(8) WTB01(9) WTB01(10) WTB01(11) WTB01(12) */
                FILLER_1.FILLER_2.WTB01[3].Value = FILLER_1.FILLER_2.WTB01[3] + +1;
                FILLER_1.FILLER_2.WTB01[4].Value = FILLER_1.FILLER_2.WTB01[4] + +1;
                FILLER_1.FILLER_2.WTB01[5].Value = FILLER_1.FILLER_2.WTB01[5] + +1;
                FILLER_1.FILLER_2.WTB01[6].Value = FILLER_1.FILLER_2.WTB01[6] + +1;
                FILLER_1.FILLER_2.WTB01[7].Value = FILLER_1.FILLER_2.WTB01[7] + +1;
                FILLER_1.FILLER_2.WTB01[8].Value = FILLER_1.FILLER_2.WTB01[8] + +1;
                FILLER_1.FILLER_2.WTB01[9].Value = FILLER_1.FILLER_2.WTB01[9] + +1;
                FILLER_1.FILLER_2.WTB01[10].Value = FILLER_1.FILLER_2.WTB01[10] + +1;
                FILLER_1.FILLER_2.WTB01[11].Value = FILLER_1.FILLER_2.WTB01[11] + +1;
                FILLER_1.FILLER_2.WTB01[12].Value = FILLER_1.FILLER_2.WTB01[12] + +1;

                /*" -205- ELSE */
            }
            else
            {


                /*" -207- ADD +1 TO WDIAS. */
                FILLER_0.WDIAS.Value = FILLER_0.WDIAS + +1;
            }


            /*" -210- ADD WTB01(LPARM01-MM) LPARM01-DD LPARM02 TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + LPARM.LPARM02;

            /*" -210- PERFORM 000-050-TESTA-PERIODO. */

            M_000_050_TESTA_PERIODO(true);

        }

        [StopWatch]
        /*" M-000-050-TESTA-PERIODO */
        private void M_000_050_TESTA_PERIODO(bool isPerform = false)
        {
            /*" -214- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -217- MOVE ALL '9' TO LPARM01 LPARM02 LPARM03 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02, LPARM.LPARM03);

                /*" -218- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -218- PERFORM 000-070-CONVERTE-EM-DATA. */

            M_000_070_CONVERTE_EM_DATA(true);

        }

        [StopWatch]
        /*" M-000-070-CONVERTE-EM-DATA */
        private void M_000_070_CONVERTE_EM_DATA(bool isPerform = false)
        {
            /*" -223- DIVIDE WDIAS BY 365,25 GIVING WANOS REMAINDER WDIASREST */
            _.Divide(FILLER_0.WDIAS, 365.25, FILLER_0.WANOS, FILLER_0.WDIASREST);

            /*" -224- IF WDIASREST EQUAL ZEROS */

            if (FILLER_0.WDIASREST == 00)
            {

                /*" -226- SUBTRACT 1 FROM WANOS GIVING LPARM03-AA */
                LPARM.LPARM03.LPARM03_AA.Value = FILLER_0.WANOS - 1;

                /*" -227- MOVE 12 TO LPARM03-MM */
                _.Move(12, LPARM.LPARM03.LPARM03_MM);

                /*" -228- MOVE 31 TO LPARM03-DD */
                _.Move(31, LPARM.LPARM03.LPARM03_DD);

                /*" -229- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -231- MOVE WANOS TO LPARM03-AA. */
            _.Move(FILLER_0.WANOS, LPARM.LPARM03.LPARM03_AA);

            /*" -234- DIVIDE LPARM03-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.LPARM03.LPARM03_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -235- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -246- ADD +1 TO WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12). */
                FILLER_1.FILLER_4.WTB03[3].Value = FILLER_1.FILLER_4.WTB03[3] + +1;
                FILLER_1.FILLER_4.WTB03[4].Value = FILLER_1.FILLER_4.WTB03[4] + +1;
                FILLER_1.FILLER_4.WTB03[5].Value = FILLER_1.FILLER_4.WTB03[5] + +1;
                FILLER_1.FILLER_4.WTB03[6].Value = FILLER_1.FILLER_4.WTB03[6] + +1;
                FILLER_1.FILLER_4.WTB03[7].Value = FILLER_1.FILLER_4.WTB03[7] + +1;
                FILLER_1.FILLER_4.WTB03[8].Value = FILLER_1.FILLER_4.WTB03[8] + +1;
                FILLER_1.FILLER_4.WTB03[9].Value = FILLER_1.FILLER_4.WTB03[9] + +1;
                FILLER_1.FILLER_4.WTB03[10].Value = FILLER_1.FILLER_4.WTB03[10] + +1;
                FILLER_1.FILLER_4.WTB03[11].Value = FILLER_1.FILLER_4.WTB03[11] + +1;
                FILLER_1.FILLER_4.WTB03[12].Value = FILLER_1.FILLER_4.WTB03[12] + +1;
            }


            /*" -247- SET I03 TO 1. */
            I03.Value = 1;

            /*" -248- SEARCH WTB03 AT END */
            void SearchAtEnd0()
            {

                /*" -249- MOVE 12 TO LPARM03-MM */
                _.Move(12, LPARM.LPARM03.LPARM03_MM);

                /*" -251- SUBTRACT WTB03 (12) FROM WDIASREST GIVING LPARM03-DD */
                LPARM.LPARM03.LPARM03_DD.Value = FILLER_0.WDIASREST - FILLER_1.FILLER_4.WTB03[12];

                /*" -253- WHEN WTB03 (I03) NOT LESS WDIASREST */
            };

            var mustSearchAtEnd0 = true;
            for (; I03 < FILLER_1.FILLER_4.WTB03.Items.Count; I03.Value++)
            {

                if (FILLER_1.FILLER_4.WTB03[I03] >= FILLER_0.WDIASREST)
                {

                    mustSearchAtEnd0 = false;

                    /*" -254- SET I03 DOWN BY 1 */
                    I03.Value -= 1;

                    /*" -255- SET LPARM03-MM TO I03 */
                    LPARM.LPARM03.LPARM03_MM.Value = I03;

                    /*" -257- SUBTRACT WTB03 (I03) FROM WDIASREST GIVING LPARM03-DD */
                    LPARM.LPARM03.LPARM03_DD.Value = FILLER_0.WDIASREST - FILLER_1.FILLER_4.WTB03[I03];

                    /*" -257- END-SEARCH. */
                    break;
                }
            }

            if (mustSearchAtEnd0)
                SearchAtEnd0();

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -259- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}