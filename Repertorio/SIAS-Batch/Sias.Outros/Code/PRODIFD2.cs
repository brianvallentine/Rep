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
    public class PRODIFD2
    {
        public bool IsCall { get; set; }

        public PRODIFD2()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PRODIF1                            *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  DADAS DUAS DATAS NO FORMATO        *      */
        /*"      *                             ISO (AAAA-MM-DD)                   *      */
        /*"      *                             DE ONDE SERAO OBTIDOS UM TERCEIRO  *      */
        /*"      *                             VALOR QUE SERA A DIFERENCA EM DIAS *      */
        /*"      *                             DA PRIMEIRA PARA A SEGUNDA DATA.   *      */
        /*"      *   PROGRAMADOR ............  HEIER COELHO                       *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  OUTUBRO/1990                       *      */
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
        public PRODIFD2_FILLER_0 FILLER_0 { get; set; } = new PRODIFD2_FILLER_0();
        public class PRODIFD2_FILLER_0 : VarBasis
        {
            /*"  03            WQUOCIENTE      PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WRESTO          PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDIASREST       PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIASREST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WANOS           PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WANOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDIAS01         PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS01 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WDIAS02         PIC S9(009) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS02 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03            WPARM03         PIC ++++++++9.*/
            public IntBasis WPARM03 { get; set; } = new IntBasis(new PIC("9", "1", "++++++++9."));
            /*"01              FILLER.*/
        }
        public PRODIFD2_FILLER_1 FILLER_1 { get; set; } = new PRODIFD2_FILLER_1();
        public class PRODIFD2_FILLER_1 : VarBasis
        {
            /*"  03            WTB01-DIAS-JULIANO.*/
            public PRODIFD2_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PRODIFD2_WTB01_DIAS_JULIANO();
            public class PRODIFD2_WTB01_DIAS_JULIANO : VarBasis
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
            private _REDEF_PRODIFD2_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PRODIFD2_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PRODIFD2_FILLER_2(); _.Move(WTB01_DIAS_JULIANO, _filler_2); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_2, WTB01_DIAS_JULIANO); _filler_2.ValueChanged += () => { _.Move(_filler_2, WTB01_DIAS_JULIANO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, WTB01_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PRODIFD2_FILLER_2 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB02-DIAS-MES.*/

                public _REDEF_PRODIFD2_FILLER_2()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
            public PRODIFD2_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PRODIFD2_WTB02_DIAS_MES();
            public class PRODIFD2_WTB02_DIAS_MES : VarBasis
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
            private _REDEF_PRODIFD2_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PRODIFD2_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PRODIFD2_FILLER_3(); _.Move(WTB02_DIAS_MES, _filler_3); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_3, WTB02_DIAS_MES); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB02_DIAS_MES); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WTB02_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PRODIFD2_FILLER_3 : VarBasis
            {
                /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB03-DIAS-JULIANO.*/

                public _REDEF_PRODIFD2_FILLER_3()
                {
                    WTB02.ValueChanged += OnValueChanged;
                }

            }
            public PRODIFD2_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PRODIFD2_WTB03_DIAS_JULIANO();
            public class PRODIFD2_WTB03_DIAS_JULIANO : VarBasis
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
            private _REDEF_PRODIFD2_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PRODIFD2_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PRODIFD2_FILLER_4(); _.Move(WTB03_DIAS_JULIANO, _filler_4); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_4, WTB03_DIAS_JULIANO); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB03_DIAS_JULIANO); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTB03_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PRODIFD2_FILLER_4 : VarBasis
            {
                /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB04-DIAS-MES.*/

                public _REDEF_PRODIFD2_FILLER_4()
                {
                    WTB03.ValueChanged += OnValueChanged;
                }

            }
            public PRODIFD2_WTB04_DIAS_MES WTB04_DIAS_MES { get; set; } = new PRODIFD2_WTB04_DIAS_MES();
            public class PRODIFD2_WTB04_DIAS_MES : VarBasis
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
            private _REDEF_PRODIFD2_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PRODIFD2_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PRODIFD2_FILLER_5(); _.Move(WTB04_DIAS_MES, _filler_5); VarBasis.RedefinePassValue(WTB04_DIAS_MES, _filler_5, WTB04_DIAS_MES); _filler_5.ValueChanged += () => { _.Move(_filler_5, WTB04_DIAS_MES); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WTB04_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PRODIFD2_FILLER_5 : VarBasis
            {
                /*"    05          WTB04           OCCURS      12                                INDEXED     BY      I04                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB04 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              LPARM.*/

                public _REDEF_PRODIFD2_FILLER_5()
                {
                    WTB04.ValueChanged += OnValueChanged;
                }

            }
        }
        public PRODIFD2_LPARM LPARM { get; set; } = new PRODIFD2_LPARM();
        public class PRODIFD2_LPARM : VarBasis
        {
            /*"    03          LPARM01.*/
            public PRODIFD2_LPARM01 LPARM01 { get; set; } = new PRODIFD2_LPARM01();
            public class PRODIFD2_LPARM01 : VarBasis
            {
                /*"       05       LPARM01-AAAA    PIC  9(004).*/
                public IntBasis LPARM01_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05       FILLER          PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05       LPARM01-MM      PIC  9(002).*/
                public IntBasis LPARM01_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       FILLER          PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05       LPARM01-DD      PIC  9(002).*/
                public IntBasis LPARM01_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03          LPARM02.*/
            }
            public PRODIFD2_LPARM02 LPARM02 { get; set; } = new PRODIFD2_LPARM02();
            public class PRODIFD2_LPARM02 : VarBasis
            {
                /*"       05       LPARM02-AAAA    PIC  9(004).*/
                public IntBasis LPARM02_AAAA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       05       FILLER          PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05       LPARM02-MM      PIC  9(002).*/
                public IntBasis LPARM02_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       FILLER          PIC  X(001).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"       05       LPARM02-DD      PIC  9(002).*/
                public IntBasis LPARM02_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    03          LPARM03         PIC S9(009)      COMP-3.*/
            }
            public IntBasis LPARM03 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    03          IND-RETORNO     PIC  9(001).*/
            public IntBasis IND_RETORNO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    03          MENSAGEM        PIC  X(070).*/
            public StringBasis MENSAGEM { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PRODIFD2_LPARM PRODIFD2_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PRODIFD2_LPARM_P;

                /*" -161- MOVE 0 TO WTB01-1. */
                _.Move(0, FILLER_1.WTB01_DIAS_JULIANO.WTB01_1);

                /*" -162- MOVE +31 TO WTB01-2. */
                _.Move(+31, FILLER_1.WTB01_DIAS_JULIANO.WTB01_2);

                /*" -163- MOVE +59 TO WTB01-3. */
                _.Move(+59, FILLER_1.WTB01_DIAS_JULIANO.WTB01_3);

                /*" -164- MOVE +90 TO WTB01-4. */
                _.Move(+90, FILLER_1.WTB01_DIAS_JULIANO.WTB01_4);

                /*" -165- MOVE +120 TO WTB01-5. */
                _.Move(+120, FILLER_1.WTB01_DIAS_JULIANO.WTB01_5);

                /*" -166- MOVE +151 TO WTB01-6. */
                _.Move(+151, FILLER_1.WTB01_DIAS_JULIANO.WTB01_6);

                /*" -167- MOVE +181 TO WTB01-7. */
                _.Move(+181, FILLER_1.WTB01_DIAS_JULIANO.WTB01_7);

                /*" -168- MOVE +212 TO WTB01-8. */
                _.Move(+212, FILLER_1.WTB01_DIAS_JULIANO.WTB01_8);

                /*" -169- MOVE +243 TO WTB01-9. */
                _.Move(+243, FILLER_1.WTB01_DIAS_JULIANO.WTB01_9);

                /*" -170- MOVE +273 TO WTB01-10. */
                _.Move(+273, FILLER_1.WTB01_DIAS_JULIANO.WTB01_10);

                /*" -171- MOVE +304 TO WTB01-11. */
                _.Move(+304, FILLER_1.WTB01_DIAS_JULIANO.WTB01_11);

                /*" -173- MOVE +334 TO WTB01-12. */
                _.Move(+334, FILLER_1.WTB01_DIAS_JULIANO.WTB01_12);

                /*" -174- MOVE 0 TO WTB03-1. */
                _.Move(0, FILLER_1.WTB03_DIAS_JULIANO.WTB03_1);

                /*" -175- MOVE +31 TO WTB03-2. */
                _.Move(+31, FILLER_1.WTB03_DIAS_JULIANO.WTB03_2);

                /*" -176- MOVE +59 TO WTB03-3. */
                _.Move(+59, FILLER_1.WTB03_DIAS_JULIANO.WTB03_3);

                /*" -177- MOVE +90 TO WTB03-4. */
                _.Move(+90, FILLER_1.WTB03_DIAS_JULIANO.WTB03_4);

                /*" -178- MOVE +120 TO WTB03-5. */
                _.Move(+120, FILLER_1.WTB03_DIAS_JULIANO.WTB03_5);

                /*" -179- MOVE +151 TO WTB03-6. */
                _.Move(+151, FILLER_1.WTB03_DIAS_JULIANO.WTB03_6);

                /*" -180- MOVE +181 TO WTB03-7. */
                _.Move(+181, FILLER_1.WTB03_DIAS_JULIANO.WTB03_7);

                /*" -181- MOVE +212 TO WTB03-8. */
                _.Move(+212, FILLER_1.WTB03_DIAS_JULIANO.WTB03_8);

                /*" -182- MOVE +243 TO WTB03-9. */
                _.Move(+243, FILLER_1.WTB03_DIAS_JULIANO.WTB03_9);

                /*" -183- MOVE +273 TO WTB03-10. */
                _.Move(+273, FILLER_1.WTB03_DIAS_JULIANO.WTB03_10);

                /*" -184- MOVE +304 TO WTB03-11. */
                _.Move(+304, FILLER_1.WTB03_DIAS_JULIANO.WTB03_11);

                /*" -186- MOVE +334 TO WTB03-12. */
                _.Move(+334, FILLER_1.WTB03_DIAS_JULIANO.WTB03_12);

                /*" -187- MOVE +28 TO WTB02-2. */
                _.Move(+28, FILLER_1.WTB02_DIAS_MES.WTB02_2);

                /*" -187- MOVE +28 TO WTB04-2. */
                _.Move(+28, FILLER_1.WTB04_DIAS_MES.WTB04_2);

                /*" -187- FLUXCONTROL_PERFORM M-000-010-CONSISTE-PARM01 */

                M_000_010_CONSISTE_PARM01();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM };
            return Result;
        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARM01 */
        private void M_000_010_CONSISTE_PARM01(bool isPerform = false)
        {
            /*" -194- IF LPARM01-AAAA NOT NUMERIC OR LPARM01-MM NOT NUMERIC OR LPARM01-DD NOT NUMERIC */

            if (!LPARM.LPARM01.LPARM01_AAAA.IsNumeric() || !LPARM.LPARM01.LPARM01_MM.IsNumeric() || !LPARM.LPARM01.LPARM01_DD.IsNumeric())
            {

                /*" -195- MOVE 9 TO IND-RETORNO */
                _.Move(9, LPARM.IND_RETORNO);

                /*" -196- MOVE 'CAMPOS NAO NUMERICOS' TO MENSAGEM */
                _.Move("CAMPOS NAO NUMERICOS", LPARM.MENSAGEM);

                /*" -197- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -199- IF LPARM01-MM LESS 1 OR LPARM01-MM GREATER 12 */

            if (LPARM.LPARM01.LPARM01_MM < 1 || LPARM.LPARM01.LPARM01_MM > 12)
            {

                /*" -200- MOVE 9 TO IND-RETORNO */
                _.Move(9, LPARM.IND_RETORNO);

                /*" -201- MOVE 'MES INVALIDO' TO MENSAGEM */
                _.Move("MES INVALIDO", LPARM.MENSAGEM);

                /*" -203- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -206- DIVIDE LPARM01-AAAA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.LPARM01.LPARM01_AAAA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -207- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -208- MOVE +29 TO WTB02(2). */
                _.Move(+29, FILLER_1.FILLER_3.WTB02[2]);
            }


            /*" -210- IF LPARM01-DD LESS 1 OR LPARM01-DD GREATER WTB02(LPARM01-MM) */

            if (LPARM.LPARM01.LPARM01_DD < 1 || LPARM.LPARM01.LPARM01_DD > FILLER_1.FILLER_3.WTB02[LPARM.LPARM01.LPARM01_MM])
            {

                /*" -211- MOVE 9 TO IND-RETORNO */
                _.Move(9, LPARM.IND_RETORNO);

                /*" -212- MOVE 'DIA INVALIDO' TO MENSAGEM */
                _.Move("DIA INVALIDO", LPARM.MENSAGEM);

                /*" -212- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-030-CONVERTE-PARM01-DIAS */
        private void M_000_030_CONVERTE_PARM01_DIAS(bool isPerform = false)
        {
            /*" -219- MULTIPLY 365,25 BY LPARM01-AAAA GIVING WDIAS01. */
            _.Multiply(365.25, LPARM.LPARM01.LPARM01_AAAA, FILLER_0.WDIAS01);

            /*" -220- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -230- ADD +1 TO WTB01(3) WTB01(4) WTB01(5) WTB01(6) WTB01(7) WTB01(8) WTB01(9) WTB01(10) WTB01(11) WTB01(12) */
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

                /*" -231- ELSE */
            }
            else
            {


                /*" -233- ADD +1 TO WDIAS01. */
                FILLER_0.WDIAS01.Value = FILLER_0.WDIAS01 + +1;
            }


            /*" -234- ADD WTB01(LPARM01-MM) LPARM01-DD TO WDIAS01. */
            FILLER_0.WDIAS01.Value = FILLER_0.WDIAS01 + LPARM.LPARM01.LPARM01_DD;

        }

        [StopWatch]
        /*" M-000-050-CONSISTE-PARM02 */
        private void M_000_050_CONSISTE_PARM02(bool isPerform = false)
        {
            /*" -242- IF LPARM02-AAAA NOT NUMERIC OR LPARM02-MM NOT NUMERIC OR LPARM02-DD NOT NUMERIC */

            if (!LPARM.LPARM02.LPARM02_AAAA.IsNumeric() || !LPARM.LPARM02.LPARM02_MM.IsNumeric() || !LPARM.LPARM02.LPARM02_DD.IsNumeric())
            {

                /*" -243- MOVE 9 TO IND-RETORNO */
                _.Move(9, LPARM.IND_RETORNO);

                /*" -244- MOVE 'CAMPOS NAO NUMERICO' TO MENSAGEM */
                _.Move("CAMPOS NAO NUMERICO", LPARM.MENSAGEM);

                /*" -245- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -247- IF LPARM02-MM LESS 1 OR LPARM02-MM GREATER 12 */

            if (LPARM.LPARM02.LPARM02_MM < 1 || LPARM.LPARM02.LPARM02_MM > 12)
            {

                /*" -248- MOVE 9 TO IND-RETORNO */
                _.Move(9, LPARM.IND_RETORNO);

                /*" -249- MOVE 'MES INVALIDO' TO MENSAGEM */
                _.Move("MES INVALIDO", LPARM.MENSAGEM);

                /*" -251- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


            /*" -254- DIVIDE LPARM02-AAAA BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(LPARM.LPARM02.LPARM02_AAAA, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -255- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -257- MOVE +29 TO WTB04(2). */
                _.Move(+29, FILLER_1.FILLER_5.WTB04[2]);
            }


            /*" -259- IF LPARM02-DD LESS 1 OR LPARM02-DD GREATER WTB04(LPARM02-MM) */

            if (LPARM.LPARM02.LPARM02_DD < 1 || LPARM.LPARM02.LPARM02_DD > FILLER_1.FILLER_5.WTB04[LPARM.LPARM02.LPARM02_MM])
            {

                /*" -260- MOVE 9 TO IND-RETORNO */
                _.Move(9, LPARM.IND_RETORNO);

                /*" -261- MOVE 'DIA INVALIDO' TO MENSAGEM */
                _.Move("DIA INVALIDO", LPARM.MENSAGEM);

                /*" -261- GO TO 000-900-FIM. */

                M_000_900_FIM(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-070-CONVERTE-PARM02-DIAS */
        private void M_000_070_CONVERTE_PARM02_DIAS(bool isPerform = false)
        {
            /*" -268- MULTIPLY 365,25 BY LPARM02-AAAA GIVING WDIAS02. */
            _.Multiply(365.25, LPARM.LPARM02.LPARM02_AAAA, FILLER_0.WDIAS02);

            /*" -269- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -279- ADD +1 TO WTB03(3) WTB03(4) WTB03(5) WTB03(6) WTB03(7) WTB03(8) WTB03(9) WTB03(10) WTB03(11) WTB03(12) */
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

                /*" -280- ELSE */
            }
            else
            {


                /*" -282- ADD +1 TO WDIAS02. */
                FILLER_0.WDIAS02.Value = FILLER_0.WDIAS02 + +1;
            }


            /*" -283- ADD WTB03(LPARM02-MM) LPARM02-DD TO WDIAS02. */
            FILLER_0.WDIAS02.Value = FILLER_0.WDIAS02 + LPARM.LPARM02.LPARM02_DD;

        }

        [StopWatch]
        /*" M-000-090-CALC-DIFER */
        private void M_000_090_CALC_DIFER(bool isPerform = false)
        {
            /*" -289- SUBTRACT WDIAS02 FROM WDIAS01 GIVING LPARM03. */
            LPARM.LPARM03.Value = FILLER_0.WDIAS01 - FILLER_0.WDIAS02;

            /*" -289- MOVE LPARM03 TO WPARM03. */
            _.Move(LPARM.LPARM03, FILLER_0.WPARM03);

        }

        [StopWatch]
        /*" M-000-900-FIM */
        private void M_000_900_FIM(bool isPerform = false)
        {
            /*" -293- GOBACK. */

            throw new GoBack();

        }
    }
}