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
    public class PRODIFC1
    {
        public bool IsCall { get; set; }

        public PRODIFC1()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PRODIFC1                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ROGERIO                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  DADAS DUAS DATAS NO FORMATO DDMMAA *      */
        /*"      *                             DE ONDE SERAO OBTIDOS UM TERCEIRO  *      */
        /*"      *                             VALOR QUE SERA A DIFERENCA EM DIAS *      */
        /*"      *                             DA PRIMEIRA PARA A SEGUNDA DATA.   *      */
        /*"      *   PROGRAMADOR ............  LAERTE                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  OUTUBRO/1990                       *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ===============================================================*      */
        /*"      * CONVERSAO PARA O ANO 2000:                                     *      */
        /*"      * KINKAS (CONSEDA6 EM 11/02/1998)                                *      */
        /*"      * ===============================================================*      */
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
        /*"*/
        public IntBasis I04 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01              FILLER.*/
        public PRODIFC1_FILLER_0 FILLER_0 { get; set; } = new PRODIFC1_FILLER_0();
        public class PRODIFC1_FILLER_0 : VarBasis
        {
            /*"  03            WQUOCIENTE      PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WRESTO          PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WDIASREST       PIC S9(003) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIASREST { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  03            WANOS           PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WANOS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIAS01         PIC S9(015) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03            WDIAS02         PIC S9(015) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS02 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  03            WPARM03         PIC +++++9.*/
            public IntBasis WPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "+++++9."));
            /*"01              FILLER.*/
        }
        public PRODIFC1_FILLER_1 FILLER_1 { get; set; } = new PRODIFC1_FILLER_1();
        public class PRODIFC1_FILLER_1 : VarBasis
        {
            /*"  03            WTB01-DIAS-JULIANO.*/
            public PRODIFC1_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PRODIFC1_WTB01_DIAS_JULIANO();
            public class PRODIFC1_WTB01_DIAS_JULIANO : VarBasis
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
            private _REDEF_PRODIFC1_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PRODIFC1_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PRODIFC1_FILLER_2(); _.Move(WTB01_DIAS_JULIANO, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_2, WTB01_DIAS_JULIANO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_JULIANO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PRODIFC1_FILLER_2 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB02-DIAS-MES.*/

                public _REDEF_PRODIFC1_FILLER_2()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
            public PRODIFC1_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PRODIFC1_WTB02_DIAS_MES();
            public class PRODIFC1_WTB02_DIAS_MES : VarBasis
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
            private _REDEF_PRODIFC1_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PRODIFC1_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PRODIFC1_FILLER_3(); _.Move(WTB02_DIAS_MES, _filler_3); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_3, WTB02_DIAS_MES); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB02_DIAS_MES); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WTB02_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PRODIFC1_FILLER_3 : VarBasis
            {
                /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB03-DIAS-JULIANO.*/

                public _REDEF_PRODIFC1_FILLER_3()
                {
                    WTB02.ValueChanged += OnValueChanged;
                }

            }
            public PRODIFC1_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PRODIFC1_WTB03_DIAS_JULIANO();
            public class PRODIFC1_WTB03_DIAS_JULIANO : VarBasis
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
            private _REDEF_PRODIFC1_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PRODIFC1_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PRODIFC1_FILLER_4(); _.Move(WTB03_DIAS_JULIANO, _filler_4); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_4, WTB03_DIAS_JULIANO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB03_DIAS_JULIANO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTB03_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PRODIFC1_FILLER_4 : VarBasis
            {
                /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB04-DIAS-MES.*/

                public _REDEF_PRODIFC1_FILLER_4()
                {
                    WTB03.ValueChanged += OnValueChanged;
                }

            }
            public PRODIFC1_WTB04_DIAS_MES WTB04_DIAS_MES { get; set; } = new PRODIFC1_WTB04_DIAS_MES();
            public class PRODIFC1_WTB04_DIAS_MES : VarBasis
            {
                /*"    05          WTB04-1         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB04-2         PIC S9(003) COMP-3  VALUE +28.*/
                public IntBasis WTB04_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +28);
                /*"    05          WTB04-3         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB04-4         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB04_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB04-5         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB04-6         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB04_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB04-7         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB04-8         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB04-9         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB04_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB04-10        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB04-11        PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB04_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB04-12        PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB04_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"  03            FILLER          REDEFINES                WTB04-DIAS-MES.*/
            }
            private _REDEF_PRODIFC1_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PRODIFC1_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PRODIFC1_FILLER_5(); _.Move(WTB04_DIAS_MES, _filler_5); VarBasis.RedefinePassValue(WTB04_DIAS_MES, _filler_5, WTB04_DIAS_MES); _filler_5.ValueChanged += () => { _.Move(_filler_5, WTB04_DIAS_MES); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WTB04_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PRODIFC1_FILLER_5 : VarBasis
            {
                /*"    05          WTB04           OCCURS      12                                INDEXED     BY      I04                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB04 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              LPARM.*/

                public _REDEF_PRODIFC1_FILLER_5()
                {
                    WTB04.ValueChanged += OnValueChanged;
                }

            }
        }
        public PRODIFC1_LPARM LPARM { get; set; } = new PRODIFC1_LPARM();
        public class PRODIFC1_LPARM : VarBasis
        {
            /*"    03          LPARM01.*/
            public PRODIFC1_LPARM01 LPARM01 { get; set; } = new PRODIFC1_LPARM01();
            public class PRODIFC1_LPARM01 : VarBasis
            {
                /*"       05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       LPARM01-AA      PIC  9(004).*/
                public IntBasis LPARM01_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          LPARM02.*/
            }
            public PRODIFC1_LPARM02 LPARM02 { get; set; } = new PRODIFC1_LPARM02();
            public class PRODIFC1_LPARM02 : VarBasis
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
        public dynamic Execute(PRODIFC1_LPARM PRODIFC1_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PRODIFC1_LPARM_P;

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
            /*" -168- MOVE 0 TO WTB01-1. */
            _.Move(0, FILLER_1.WTB01_DIAS_JULIANO.WTB01_1);

            /*" -169- MOVE +31 TO WTB01-2. */
            _.Move(+31, FILLER_1.WTB01_DIAS_JULIANO.WTB01_2);

            /*" -170- MOVE +59 TO WTB01-3. */
            _.Move(+59, FILLER_1.WTB01_DIAS_JULIANO.WTB01_3);

            /*" -171- MOVE +90 TO WTB01-4. */
            _.Move(+90, FILLER_1.WTB01_DIAS_JULIANO.WTB01_4);

            /*" -172- MOVE +120 TO WTB01-5. */
            _.Move(+120, FILLER_1.WTB01_DIAS_JULIANO.WTB01_5);

            /*" -173- MOVE +151 TO WTB01-6. */
            _.Move(+151, FILLER_1.WTB01_DIAS_JULIANO.WTB01_6);

            /*" -174- MOVE +181 TO WTB01-7. */
            _.Move(+181, FILLER_1.WTB01_DIAS_JULIANO.WTB01_7);

            /*" -175- MOVE +212 TO WTB01-8. */
            _.Move(+212, FILLER_1.WTB01_DIAS_JULIANO.WTB01_8);

            /*" -176- MOVE +243 TO WTB01-9. */
            _.Move(+243, FILLER_1.WTB01_DIAS_JULIANO.WTB01_9);

            /*" -177- MOVE +273 TO WTB01-10. */
            _.Move(+273, FILLER_1.WTB01_DIAS_JULIANO.WTB01_10);

            /*" -178- MOVE +304 TO WTB01-11. */
            _.Move(+304, FILLER_1.WTB01_DIAS_JULIANO.WTB01_11);

            /*" -180- MOVE +334 TO WTB01-12. */
            _.Move(+334, FILLER_1.WTB01_DIAS_JULIANO.WTB01_12);

            /*" -181- MOVE 0 TO WTB03-1. */
            _.Move(0, FILLER_1.WTB03_DIAS_JULIANO.WTB03_1);

            /*" -182- MOVE +31 TO WTB03-2. */
            _.Move(+31, FILLER_1.WTB03_DIAS_JULIANO.WTB03_2);

            /*" -183- MOVE +59 TO WTB03-3. */
            _.Move(+59, FILLER_1.WTB03_DIAS_JULIANO.WTB03_3);

            /*" -184- MOVE +90 TO WTB03-4. */
            _.Move(+90, FILLER_1.WTB03_DIAS_JULIANO.WTB03_4);

            /*" -185- MOVE +120 TO WTB03-5. */
            _.Move(+120, FILLER_1.WTB03_DIAS_JULIANO.WTB03_5);

            /*" -186- MOVE +151 TO WTB03-6. */
            _.Move(+151, FILLER_1.WTB03_DIAS_JULIANO.WTB03_6);

            /*" -187- MOVE +181 TO WTB03-7. */
            _.Move(+181, FILLER_1.WTB03_DIAS_JULIANO.WTB03_7);

            /*" -188- MOVE +212 TO WTB03-8. */
            _.Move(+212, FILLER_1.WTB03_DIAS_JULIANO.WTB03_8);

            /*" -189- MOVE +243 TO WTB03-9. */
            _.Move(+243, FILLER_1.WTB03_DIAS_JULIANO.WTB03_9);

            /*" -190- MOVE +273 TO WTB03-10. */
            _.Move(+273, FILLER_1.WTB03_DIAS_JULIANO.WTB03_10);

            /*" -191- MOVE +304 TO WTB03-11. */
            _.Move(+304, FILLER_1.WTB03_DIAS_JULIANO.WTB03_11);

            /*" -193- MOVE +334 TO WTB03-12. */
            _.Move(+334, FILLER_1.WTB03_DIAS_JULIANO.WTB03_12);

            /*" -194- MOVE +28 TO WTB02-2. */
            _.Move(+28, FILLER_1.WTB02_DIAS_MES.WTB02_2);

            /*" -194- MOVE +28 TO WTB04-2. */
            _.Move(+28, FILLER_1.WTB04_DIAS_MES.WTB04_2);

            /*" -0- FLUXCONTROL_PERFORM M_000_010_CONSISTE_PARM01 */

            M_000_010_CONSISTE_PARM01();

        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARM01 */
        private void M_000_010_CONSISTE_PARM01(bool isPerform = false)
        {
            /*" -198- IF LPARM01 NOT NUMERIC */

            if (!LPARM.LPARM01.IsNumeric())
            {

                /*" -200- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -201- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -202- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -204- IF LPARM01-MM LESS 1 OR LPARM01-MM GREATER 12 */

            if (LPARM.LPARM01.LPARM01_MM < 1 || LPARM.LPARM01.LPARM01_MM > 12)
            {

                /*" -206- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -207- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -209- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -211- DIVIDE LPARM01-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.LPARM01.LPARM01_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -212- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -213- MOVE +29 TO WTB02(2). */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);
            }


            /*" -215- IF LPARM01-DD LESS 1 OR LPARM01-DD GREATER WTB02(LPARM01-MM) */

            if (LPARM.LPARM01.LPARM01_DD < 1 || LPARM.LPARM01.LPARM01_DD > FILLER_1.FILLER_3.WTB02[LPARM.LPARM01.LPARM01_MM])
            {

                /*" -217- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -218- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -218- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-030-CONVERTE-PARM01-DIAS */
        private void M_000_030_CONVERTE_PARM01_DIAS(bool isPerform = false)
        {
            /*" -222- MULTIPLY 365,25 BY LPARM01-AA GIVING WDIAS01. */
            _.Multiply(365.25, LPARM.LPARM01.LPARM01_AA, FILLER_0.WDIAS01);

            /*" -223- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -233- ADD +1 TO WTB01(3) WTB01(4) WTB01(5) WTB01(6) WTB01(7) WTB01(8) WTB01(9) WTB01(10) WTB01(11) WTB01(12) */
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

                /*" -234- ELSE */
            }
            else
            {


                /*" -236- ADD +1 TO WDIAS01. */
                FILLER_0.WDIAS01.Value = FILLER_0.WDIAS01 + +1;
            }


            /*" -237- ADD WTB01(LPARM01-MM) LPARM01-DD TO WDIAS01. */
            FILLER_0.WDIAS01.Value = FILLER_0.WDIAS01 + LPARM.LPARM01.LPARM01_DD;

        }

        [StopWatch]
        /*" M-000-050-CONSISTE-PARM02 */
        private void M_000_050_CONSISTE_PARM02(bool isPerform = false)
        {
            /*" -241- IF LPARM02 NOT NUMERIC */

            if (!LPARM.LPARM02.IsNumeric())
            {

                /*" -243- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -244- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -245- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -247- IF LPARM02-MM LESS 1 OR LPARM02-MM GREATER 12 */

            if (LPARM.LPARM02.LPARM02_MM < 1 || LPARM.LPARM02.LPARM02_MM > 12)
            {

                /*" -249- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -250- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -252- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -254- DIVIDE LPARM02-AA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.LPARM02.LPARM02_AA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -255- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -256- MOVE +29 TO WTB04(2). */
                _.Move(+29, FILLER_1.FILLER_5.WTB04[2]);
            }


            /*" -258- IF LPARM02-DD LESS 1 OR LPARM02-DD GREATER WTB04(LPARM02-MM) */

            if (LPARM.LPARM02.LPARM02_DD < 1 || LPARM.LPARM02.LPARM02_DD > FILLER_1.FILLER_5.WTB04[LPARM.LPARM02.LPARM02_MM])
            {

                /*" -260- MOVE ALL '9' TO LPARM01 LPARM02 */
                _.MoveAll("9", LPARM.LPARM01, LPARM.LPARM02);

                /*" -261- MOVE 999999 TO LPARM03 */
                _.Move(999999, LPARM.LPARM03);

                /*" -261- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-070-CONVERTE-PARM02-DIAS */
        private void M_000_070_CONVERTE_PARM02_DIAS(bool isPerform = false)
        {
            /*" -265- MULTIPLY 365,25 BY LPARM02-AA GIVING WDIAS02. */
            _.Multiply(365.25, LPARM.LPARM02.LPARM02_AA, FILLER_0.WDIAS02);

            /*" -266- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -276- ADD +1 TO WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12) */
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

                /*" -277- ELSE */
            }
            else
            {


                /*" -279- ADD +1 TO WDIAS02. */
                FILLER_0.WDIAS02.Value = FILLER_0.WDIAS02 + +1;
            }


            /*" -280- ADD WTB03(LPARM02-MM) LPARM02-DD TO WDIAS02. */
            FILLER_0.WDIAS02.Value = FILLER_0.WDIAS02 + LPARM.LPARM02.LPARM02_DD;

        }

        [StopWatch]
        /*" M-000-090-CALC-DIFER */
        private void M_000_090_CALC_DIFER(bool isPerform = false)
        {
            /*" -285- SUBTRACT WDIAS02 FROM WDIAS01 GIVING LPARM03. */
            LPARM.LPARM03.Value = FILLER_0.WDIAS01 - FILLER_0.WDIAS02;

            /*" -285- MOVE LPARM03 TO WPARM03. */
            _.Move(LPARM.LPARM03, FILLER_0.WPARM03);

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -287- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}