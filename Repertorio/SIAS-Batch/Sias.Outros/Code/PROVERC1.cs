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
    public class PROVERC1
    {
        public bool IsCall { get; set; }

        public PROVERC1()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *REMARKS                                                                */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROVERC1   (SUBROTINA)             *      */
        /*"      *                                                                *      */
        /*"      *   AMBIENTE................  VM/SP/VM/ESA/COBOL/VS/COBOL2       *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  VERIFICA SE A DATA DO PARAMETRO    *      */
        /*"      *                             E' UM DIA UTIL. SE FOR RETORNA     *      */
        /*"      *                             "S", SENAO "N".                    *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  BUENO                              *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  ENRICO                             *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  DEZEMBRO/92                        *      */
        /*"      *                                                                *      */
        /*"      *   ALTERACOES                                                   *      */
        /*"      *   EM 12.01.1999 POR LIANE P. MOREIRA ...... PROCURE POR LP0199 *      */
        /*"      *                                                                *      */
        /*"      *   . ALTERACAO DO TAMANHO DO ANO NO PARAMETRO DATA1 DE 04       *      */
        /*"      *     POSICOES PARA 02. POIS O ALGORITMO DESTA ROTINA AINDA NAO  *      */
        /*"      *     ESTA PREPARADO PARA DETERMINAR O DIA UTIL COM O ANO DE 04  *      */
        /*"      *     POSICOES. A ROTINA CONTINUA RECEBENDO O ANO COM 04         *      */
        /*"      *     POSICOES E INTERNAMENTE ALTERA PARA 02.                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 24/01/1998.   *      */
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
        public PROVERC1_FILLER_0 FILLER_0 { get; set; } = new PROVERC1_FILLER_0();
        public class PROVERC1_FILLER_0 : VarBasis
        {
            /*"  03            WSOMADI         PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WSOMADI { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDSEM           PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WDSEM { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WX05            PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WX05 { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIAS01         PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS01 { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WQUOCIENTE      PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WQUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WRESTO          PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WDIASREST       PIC S9(005) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIASREST { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
            /*"  03            WANOS           PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WANOS { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WDIAS           PIC S9(007) COMP-3  VALUE  ZEROS*/
            public IntBasis WDIAS { get; set; } = new IntBasis(new PIC("S9", "7", "S9(007)"));
            /*"  03            WS-ANO          PIC  9(004).*/
            public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  03            FILLER          REDEFINES    WS-ANO.*/
            private _REDEF_PROVERC1_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PROVERC1_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PROVERC1_FILLER_1(); _.Move(WS_ANO, _filler_1); VarBasis.RedefinePassValue(WS_ANO, _filler_1, WS_ANO); _filler_1.ValueChanged += () => { _.Move(_filler_1, WS_ANO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WS_ANO); }
            }  //Redefines
            public class _REDEF_PROVERC1_FILLER_1 : VarBasis
            {
                /*"      05        WS-ANO1         PIC  9(002).*/
                public IntBasis WS_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05        WS-ANO2         PIC  9(002).*/
                public IntBasis WS_ANO2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01              FILLER.*/

                public _REDEF_PROVERC1_FILLER_1()
                {
                    WS_ANO1.ValueChanged += OnValueChanged;
                    WS_ANO2.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROVERC1_FILLER_2 FILLER_2 { get; set; } = new PROVERC1_FILLER_2();
        public class PROVERC1_FILLER_2 : VarBasis
        {
            /*"  03            WTB01-DIAS-JULIANO.*/
            public PROVERC1_WTB01_DIAS_JULIANO WTB01_DIAS_JULIANO { get; set; } = new PROVERC1_WTB01_DIAS_JULIANO();
            public class PROVERC1_WTB01_DIAS_JULIANO : VarBasis
            {
                /*"    05          WTB1-1          PIC S9(003) COMP-3  VALUE  ZEROS*/
                public IntBasis WTB1_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05          WTB1-2          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB1_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB1-3          PIC S9(003) COMP-3  VALUE +59.*/
                public IntBasis WTB1_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                /*"    05          WTB1-4          PIC S9(003) COMP-3  VALUE +90.*/
                public IntBasis WTB1_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                /*"    05          WTB1-5          PIC S9(003) COMP-3  VALUE +120.*/
                public IntBasis WTB1_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                /*"    05          WTB1-6          PIC S9(003) COMP-3  VALUE +151.*/
                public IntBasis WTB1_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                /*"    05          WTB1-7          PIC S9(003) COMP-3  VALUE +181.*/
                public IntBasis WTB1_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                /*"    05          WTB1-8          PIC S9(003) COMP-3  VALUE +212.*/
                public IntBasis WTB1_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                /*"    05          WTB1-9          PIC S9(003) COMP-3  VALUE +243.*/
                public IntBasis WTB1_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                /*"    05          WTB1-10         PIC S9(003) COMP-3  VALUE +273.*/
                public IntBasis WTB1_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                /*"    05          WTB1-11         PIC S9(003) COMP-3  VALUE +304.*/
                public IntBasis WTB1_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                /*"    05          WTB1-12         PIC S9(003) COMP-3  VALUE +334.*/
                public IntBasis WTB1_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                /*"  03            FILLER          REDEFINES                WTB01-DIAS-JULIANO.*/
            }
            private _REDEF_PROVERC1_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PROVERC1_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PROVERC1_FILLER_3(); _.Move(WTB01_DIAS_JULIANO, _filler_3); VarBasis.RedefinePassValue(WTB01_DIAS_JULIANO, _filler_3, WTB01_DIAS_JULIANO); _filler_3.ValueChanged += () => { _.Move(_filler_3, WTB01_DIAS_JULIANO); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, WTB01_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROVERC1_FILLER_3 : VarBasis
            {
                /*"    05          WTB01           OCCURS      12                                INDEXED     BY      I01                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB01 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB02-DIAS-MES.*/

                public _REDEF_PROVERC1_FILLER_3()
                {
                    WTB01.ValueChanged += OnValueChanged;
                }

            }
            public PROVERC1_WTB02_DIAS_MES WTB02_DIAS_MES { get; set; } = new PROVERC1_WTB02_DIAS_MES();
            public class PROVERC1_WTB02_DIAS_MES : VarBasis
            {
                /*"    05          WTB2-1          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-2          PIC S9(003) COMP-3  VALUE +28.*/
                public IntBasis WTB2_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +28);
                /*"    05          WTB2-3          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-4          PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-5          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-6          PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-7          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-8          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-9          PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-10         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB2-11         PIC S9(003) COMP-3  VALUE +30.*/
                public IntBasis WTB2_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +30);
                /*"    05          WTB2-12         PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB2_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"  03            FILLER          REDEFINES                WTB02-DIAS-MES.*/
            }
            private _REDEF_PROVERC1_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PROVERC1_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PROVERC1_FILLER_4(); _.Move(WTB02_DIAS_MES, _filler_4); VarBasis.RedefinePassValue(WTB02_DIAS_MES, _filler_4, WTB02_DIAS_MES); _filler_4.ValueChanged += () => { _.Move(_filler_4, WTB02_DIAS_MES); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WTB02_DIAS_MES); }
            }  //Redefines
            public class _REDEF_PROVERC1_FILLER_4 : VarBasis
            {
                /*"    05          WTB02           OCCURS      12                                INDEXED     BY      I02                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB02 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"  03            WTB03-DIAS-JULIANO.*/

                public _REDEF_PROVERC1_FILLER_4()
                {
                    WTB02.ValueChanged += OnValueChanged;
                }

            }
            public PROVERC1_WTB03_DIAS_JULIANO WTB03_DIAS_JULIANO { get; set; } = new PROVERC1_WTB03_DIAS_JULIANO();
            public class PROVERC1_WTB03_DIAS_JULIANO : VarBasis
            {
                /*"    05          WTB3-1          PIC S9(003) COMP-3  VALUE  ZEROS*/
                public IntBasis WTB3_1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05          WTB3-2          PIC S9(003) COMP-3  VALUE +31.*/
                public IntBasis WTB3_2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +31);
                /*"    05          WTB3-3          PIC S9(003) COMP-3  VALUE +59.*/
                public IntBasis WTB3_3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +59);
                /*"    05          WTB3-4          PIC S9(003) COMP-3  VALUE +90.*/
                public IntBasis WTB3_4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +90);
                /*"    05          WTB3-5          PIC S9(003) COMP-3  VALUE +120.*/
                public IntBasis WTB3_5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +120);
                /*"    05          WTB3-6          PIC S9(003) COMP-3  VALUE +151.*/
                public IntBasis WTB3_6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +151);
                /*"    05          WTB3-7          PIC S9(003) COMP-3  VALUE +181.*/
                public IntBasis WTB3_7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +181);
                /*"    05          WTB3-8          PIC S9(003) COMP-3  VALUE +212.*/
                public IntBasis WTB3_8 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +212);
                /*"    05          WTB3-9          PIC S9(003) COMP-3  VALUE +243.*/
                public IntBasis WTB3_9 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +243);
                /*"    05          WTB3-10         PIC S9(003) COMP-3  VALUE +273.*/
                public IntBasis WTB3_10 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +273);
                /*"    05          WTB3-11         PIC S9(003) COMP-3  VALUE +304.*/
                public IntBasis WTB3_11 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +304);
                /*"    05          WTB3-12         PIC S9(003) COMP-3  VALUE +334.*/
                public IntBasis WTB3_12 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"), +334);
                /*"  03            FILLER          REDEFINES                WTB03-DIAS-JULIANO.*/
            }
            private _REDEF_PROVERC1_FILLER_5 _filler_5 { get; set; }
            public _REDEF_PROVERC1_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_PROVERC1_FILLER_5(); _.Move(WTB03_DIAS_JULIANO, _filler_5); VarBasis.RedefinePassValue(WTB03_DIAS_JULIANO, _filler_5, WTB03_DIAS_JULIANO); _filler_5.ValueChanged += () => { _.Move(_filler_5, WTB03_DIAS_JULIANO); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WTB03_DIAS_JULIANO); }
            }  //Redefines
            public class _REDEF_PROVERC1_FILLER_5 : VarBasis
            {
                /*"    05          WTB03           OCCURS      12                                INDEXED     BY      I03                                PIC S9(003) COMP-3.*/
                public ListBasis<IntBasis, Int64> WTB03 { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "3", "S9(003)"), 12);
                /*"01              LPARM.*/

                public _REDEF_PROVERC1_FILLER_5()
                {
                    WTB03.ValueChanged += OnValueChanged;
                }

            }
        }
        public PROVERC1_LPARM LPARM { get; set; } = new PROVERC1_LPARM();
        public class PROVERC1_LPARM : VarBasis
        {
            /*"    03          DATA1.*/
            public PROVERC1_DATA1 DATA1 { get; set; } = new PROVERC1_DATA1();
            public class PROVERC1_DATA1 : VarBasis
            {
                /*"       05       DATA1-DD        PIC  9(002).*/
                public IntBasis DATA1_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA1-MM        PIC  9(002).*/
                public IntBasis DATA1_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       05       DATA1-AA        PIC  9(004).*/
                public IntBasis DATA1_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    03          RESPOSTA        PIC  X(001).*/
            }
            public StringBasis RESPOSTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROVERC1_LPARM PROVERC1_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROVERC1_LPARM_P;

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
            /*" -134- PERFORM 000-010-INICIALIZA-PARAMETROS. */

            M_000_010_INICIALIZA_PARAMETROS_SECTION();

            /*" -135- PERFORM 000-020-CONSISTENCIA-DATA. */

            M_000_020_CONSISTENCIA_DATA_SECTION();

            /*" -136- PERFORM 000-030-CONVERTE-EM-NNNNN-DIAS. */

            M_000_030_CONVERTE_EM_NNNNN_DIAS_SECTION();

            /*" -137- PERFORM 000-045-TESTE-PERIODO-SECULO. */

            M_000_045_TESTE_PERIODO_SECULO_SECTION();

            /*" -138- PERFORM 000-050-VERIFICA-DIA-UTIL. */

            M_000_050_VERIFICA_DIA_UTIL_SECTION();

            /*" -138- PERFORM 000-055-TESTE-PERIODO-SECULO. */

            M_000_055_TESTE_PERIODO_SECULO_SECTION();

        }

        [StopWatch]
        /*" M-000-010-INICIALIZA-PARAMETROS-SECTION */
        private void M_000_010_INICIALIZA_PARAMETROS_SECTION()
        {
            /*" -143- PERFORM 800-000-INICIALIZA-PARAMETROS. */

            M_800_000_INICIALIZA_PARAMETROS_SECTION();

            /*" -143- MOVE DATA1-AA TO WS-ANO. */
            _.Move(LPARM.DATA1.DATA1_AA, FILLER_0.WS_ANO);

        }

        [StopWatch]
        /*" M-000-020-CONSISTENCIA-DATA-SECTION */
        private void M_000_020_CONSISTENCIA_DATA_SECTION()
        {
            /*" -153- IF DATA1 NOT NUMERIC OR DATA1-MM LESS 1 OR DATA1-MM GREATER 12 */

            if (!LPARM.DATA1.IsNumeric() || LPARM.DATA1.DATA1_MM < 1 || LPARM.DATA1.DATA1_MM > 12)
            {

                /*" -154- MOVE ALL '9' TO DATA1 */
                _.MoveAll("9", LPARM.DATA1);

                /*" -155- MOVE '9' TO RESPOSTA */
                _.Move("9", LPARM.RESPOSTA);

                /*" -158- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -160- DIVIDE WS-ANO2 BY 4 GIVING WQUOCIENTE REMAINDER WRESTO */
            _.Divide(FILLER_0.FILLER_1.WS_ANO2, 4, FILLER_0.WQUOCIENTE, FILLER_0.WRESTO);

            /*" -161- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -163- MOVE +29 TO WTB02(2). */
                _.Move(+29, FILLER_2.FILLER_4.WTB02[2]);
            }


            /*" -165- IF DATA1-DD LESS 1 OR DATA1-DD GREATER WTB02(DATA1-MM) */

            if (LPARM.DATA1.DATA1_DD < 1 || LPARM.DATA1.DATA1_DD > FILLER_2.FILLER_4.WTB02[LPARM.DATA1.DATA1_MM])
            {

                /*" -166- MOVE ALL '9' TO DATA1 */
                _.MoveAll("9", LPARM.DATA1);

                /*" -167- MOVE '9' TO RESPOSTA */
                _.Move("9", LPARM.RESPOSTA);

                /*" -167- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-030-CONVERTE-EM-NNNNN-DIAS-SECTION */
        private void M_000_030_CONVERTE_EM_NNNNN_DIAS_SECTION()
        {
            /*" -177- MULTIPLY 365,25 BY WS-ANO2 GIVING WDIAS. */
            _.Multiply(365.25, FILLER_0.FILLER_1.WS_ANO2, FILLER_0.WDIAS);

            /*" -178- IF WRESTO EQUAL ZEROS */

            if (FILLER_0.WRESTO == 00)
            {

                /*" -179- MOVE +29 TO WTB02(2) */
                _.Move(+29, FILLER_2.FILLER_4.WTB02[2]);

                /*" -189- ADD +1 TO WTB01(3) WTB01(4) WTB01(5) WTB01(6) WTB01(7) WTB01(8) WTB01(9) WTB01(10) WTB01(11) WTB01(12) */
                FILLER_2.FILLER_3.WTB01[3].Value = FILLER_2.FILLER_3.WTB01[3] + +1;
                FILLER_2.FILLER_3.WTB01[4].Value = FILLER_2.FILLER_3.WTB01[4] + +1;
                FILLER_2.FILLER_3.WTB01[5].Value = FILLER_2.FILLER_3.WTB01[5] + +1;
                FILLER_2.FILLER_3.WTB01[6].Value = FILLER_2.FILLER_3.WTB01[6] + +1;
                FILLER_2.FILLER_3.WTB01[7].Value = FILLER_2.FILLER_3.WTB01[7] + +1;
                FILLER_2.FILLER_3.WTB01[8].Value = FILLER_2.FILLER_3.WTB01[8] + +1;
                FILLER_2.FILLER_3.WTB01[9].Value = FILLER_2.FILLER_3.WTB01[9] + +1;
                FILLER_2.FILLER_3.WTB01[10].Value = FILLER_2.FILLER_3.WTB01[10] + +1;
                FILLER_2.FILLER_3.WTB01[11].Value = FILLER_2.FILLER_3.WTB01[11] + +1;
                FILLER_2.FILLER_3.WTB01[12].Value = FILLER_2.FILLER_3.WTB01[12] + +1;

                /*" -190- ELSE */
            }
            else
            {


                /*" -192- ADD +1 TO WDIAS. */
                FILLER_0.WDIAS.Value = FILLER_0.WDIAS + +1;
            }


            /*" -193- ADD WTB01(DATA1-MM) DATA1-DD TO WDIAS. */
            FILLER_0.WDIAS.Value = FILLER_0.WDIAS + LPARM.DATA1.DATA1_DD;

        }

        [StopWatch]
        /*" M-000-045-TESTE-PERIODO-SECULO-SECTION */
        private void M_000_045_TESTE_PERIODO_SECULO_SECTION()
        {
            /*" -201- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -202- MOVE ALL '9' TO DATA1 */
                _.MoveAll("9", LPARM.DATA1);

                /*" -203- MOVE '9' TO RESPOSTA */
                _.Move("9", LPARM.RESPOSTA);

                /*" -203- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-050-VERIFICA-DIA-UTIL-SECTION */
        private void M_000_050_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -210- PERFORM 500-000-VERIFICA-DIA-UTIL. */

            M_500_000_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-000-055-TESTE-PERIODO-SECULO-SECTION */
        private void M_000_055_TESTE_PERIODO_SECULO_SECTION()
        {
            /*" -216- IF WDIAS LESS +1 OR WDIAS GREATER +3652500 */

            if (FILLER_0.WDIAS < +1 || FILLER_0.WDIAS > +3652500)
            {

                /*" -217- MOVE ALL '9' TO DATA1 */
                _.MoveAll("9", LPARM.DATA1);

                /*" -218- MOVE '9' TO RESPOSTA */
                _.Move("9", LPARM.RESPOSTA);

                /*" -220- GO TO 900-000-RETORNA. */

                M_900_000_RETORNA_SECTION(); //GOTO
                return;
            }


            /*" -220- GO TO 900-000-RETORNA. */

            M_900_000_RETORNA_SECTION(); //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_SAIDA*/

        [StopWatch]
        /*" M-500-000-VERIFICA-DIA-UTIL-SECTION */
        private void M_500_000_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -240- PERFORM 500-010-CALCULA-DIA-SEMANA. */

            M_500_010_CALCULA_DIA_SEMANA_SECTION();

            /*" -240- PERFORM 500-020-VERIFICA-DIA-UTIL. */

            M_500_020_VERIFICA_DIA_UTIL_SECTION();

        }

        [StopWatch]
        /*" M-500-010-CALCULA-DIA-SEMANA-SECTION */
        private void M_500_010_CALCULA_DIA_SEMANA_SECTION()
        {
            /*" -245- DIVIDE WDIAS BY 7 GIVING WQUOCIENTE REMAINDER WDSEM. */
            _.Divide(FILLER_0.WDIAS, 7, FILLER_0.WQUOCIENTE, FILLER_0.WDSEM);

        }

        [StopWatch]
        /*" M-500-020-VERIFICA-DIA-UTIL-SECTION */
        private void M_500_020_VERIFICA_DIA_UTIL_SECTION()
        {
            /*" -261- IF WDSEM EQUAL 1 OR WDSEM EQUAL 2 */

            if (FILLER_0.WDSEM == 1 || FILLER_0.WDSEM == 2)
            {

                /*" -262- MOVE 'N' TO RESPOSTA */
                _.Move("N", LPARM.RESPOSTA);

                /*" -263- ELSE */
            }
            else
            {


                /*" -263- MOVE 'S' TO RESPOSTA. */
                _.Move("S", LPARM.RESPOSTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_SAIDA*/

        [StopWatch]
        /*" M-800-000-INICIALIZA-PARAMETROS-SECTION */
        private void M_800_000_INICIALIZA_PARAMETROS_SECTION()
        {
            /*" -275- MOVE +0 TO WQUOCIENTE */
            _.Move(+0, FILLER_0.WQUOCIENTE);

            /*" -276- MOVE +0 TO WRESTO */
            _.Move(+0, FILLER_0.WRESTO);

            /*" -277- MOVE +0 TO WDIASREST */
            _.Move(+0, FILLER_0.WDIASREST);

            /*" -278- MOVE +0 TO WANOS */
            _.Move(+0, FILLER_0.WANOS);

            /*" -279- MOVE +0 TO WDIAS */
            _.Move(+0, FILLER_0.WDIAS);

            /*" -280- MOVE +0 TO WDIAS01 */
            _.Move(+0, FILLER_0.WDIAS01);

            /*" -282- MOVE +0 TO WSOMADI */
            _.Move(+0, FILLER_0.WSOMADI);

            /*" -283- MOVE +0 TO WTB1-1 */
            _.Move(+0, FILLER_2.WTB01_DIAS_JULIANO.WTB1_1);

            /*" -284- MOVE +31 TO WTB1-2 */
            _.Move(+31, FILLER_2.WTB01_DIAS_JULIANO.WTB1_2);

            /*" -285- MOVE +59 TO WTB1-3 */
            _.Move(+59, FILLER_2.WTB01_DIAS_JULIANO.WTB1_3);

            /*" -286- MOVE +90 TO WTB1-4 */
            _.Move(+90, FILLER_2.WTB01_DIAS_JULIANO.WTB1_4);

            /*" -287- MOVE +120 TO WTB1-5 */
            _.Move(+120, FILLER_2.WTB01_DIAS_JULIANO.WTB1_5);

            /*" -288- MOVE +151 TO WTB1-6 */
            _.Move(+151, FILLER_2.WTB01_DIAS_JULIANO.WTB1_6);

            /*" -289- MOVE +181 TO WTB1-7 */
            _.Move(+181, FILLER_2.WTB01_DIAS_JULIANO.WTB1_7);

            /*" -290- MOVE +212 TO WTB1-8 */
            _.Move(+212, FILLER_2.WTB01_DIAS_JULIANO.WTB1_8);

            /*" -291- MOVE +243 TO WTB1-9 */
            _.Move(+243, FILLER_2.WTB01_DIAS_JULIANO.WTB1_9);

            /*" -292- MOVE +273 TO WTB1-10 */
            _.Move(+273, FILLER_2.WTB01_DIAS_JULIANO.WTB1_10);

            /*" -293- MOVE +304 TO WTB1-11 */
            _.Move(+304, FILLER_2.WTB01_DIAS_JULIANO.WTB1_11);

            /*" -295- MOVE +334 TO WTB1-12 */
            _.Move(+334, FILLER_2.WTB01_DIAS_JULIANO.WTB1_12);

            /*" -297- MOVE +28 TO WTB2-2 */
            _.Move(+28, FILLER_2.WTB02_DIAS_MES.WTB2_2);

            /*" -298- MOVE +0 TO WTB3-1 */
            _.Move(+0, FILLER_2.WTB03_DIAS_JULIANO.WTB3_1);

            /*" -299- MOVE +31 TO WTB3-2 */
            _.Move(+31, FILLER_2.WTB03_DIAS_JULIANO.WTB3_2);

            /*" -300- MOVE +59 TO WTB3-3 */
            _.Move(+59, FILLER_2.WTB03_DIAS_JULIANO.WTB3_3);

            /*" -301- MOVE +90 TO WTB3-4 */
            _.Move(+90, FILLER_2.WTB03_DIAS_JULIANO.WTB3_4);

            /*" -302- MOVE +120 TO WTB3-5 */
            _.Move(+120, FILLER_2.WTB03_DIAS_JULIANO.WTB3_5);

            /*" -303- MOVE +151 TO WTB3-6 */
            _.Move(+151, FILLER_2.WTB03_DIAS_JULIANO.WTB3_6);

            /*" -304- MOVE +181 TO WTB3-7 */
            _.Move(+181, FILLER_2.WTB03_DIAS_JULIANO.WTB3_7);

            /*" -305- MOVE +212 TO WTB3-8 */
            _.Move(+212, FILLER_2.WTB03_DIAS_JULIANO.WTB3_8);

            /*" -306- MOVE +243 TO WTB3-9 */
            _.Move(+243, FILLER_2.WTB03_DIAS_JULIANO.WTB3_9);

            /*" -307- MOVE +273 TO WTB3-10 */
            _.Move(+273, FILLER_2.WTB03_DIAS_JULIANO.WTB3_10);

            /*" -308- MOVE +304 TO WTB3-11 */
            _.Move(+304, FILLER_2.WTB03_DIAS_JULIANO.WTB3_11);

            /*" -308- MOVE +334 TO WTB3-12. */
            _.Move(+334, FILLER_2.WTB03_DIAS_JULIANO.WTB3_12);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_SAIDA*/

        [StopWatch]
        /*" M-900-000-RETORNA-SECTION */
        private void M_900_000_RETORNA_SECTION()
        {
            /*" -317- GOBACK. */

            throw new GoBack();

        }
    }
}