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
    public class PROCPF02
    {
        public bool IsCall { get; set; }

        public PROCPF02()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-----------------------------------                                    */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROCPF02                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ALCIONE ARAUJO                     *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  VALIDACOES COMPLEMENTARES DE CPF.  *      */
        /*"      *                             UTILIZADA ANTES DA CHAMADA DA      *      */
        /*"      *                             SUBROTINA PROCPF01.                *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  ALCIONE ARAUJO                     *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  JULHO/2009                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * NO   VERSAO    DATA       PROGRAMADOR           ALTERACAO      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 1.    1.0    01/07/2009   ALCIONE ALMEIDA.                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 2.    2.0    10/12/2009   PATRICIA SALES.                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 3.    3.0    08/03/2017   FRANK CARVALHO. - CADMUS 147.155     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 4.    4.0    21/09/2017   GILSON P. SILVA - CADMUS 154.264     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"01      LK-LINK-CPF               PIC  9(011)   VALUE ZEROS.*/
        public IntBasis LK_LINK_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"01      FILLER                    REDEFINES     LK-LINK-CPF.*/
        private _REDEF_PROCPF02_FILLER_0 _filler_0 { get; set; }
        public _REDEF_PROCPF02_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_PROCPF02_FILLER_0(); _.Move(LK_LINK_CPF, _filler_0); VarBasis.RedefinePassValue(LK_LINK_CPF, _filler_0, LK_LINK_CPF); _filler_0.ValueChanged += () => { _.Move(_filler_0, LK_LINK_CPF); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, LK_LINK_CPF); }
        }  //Redefines
        public class _REDEF_PROCPF02_FILLER_0 : VarBasis
        {
            /*"  05    LK-NUM-CPF                PIC  9(009).*/
            public IntBasis LK_NUM_CPF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05    LK-DV-CPF                 PIC  9(002).*/
            public IntBasis LK_DV_CPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01      LK-CPF-INF                PIC  9(011).*/

            public _REDEF_PROCPF02_FILLER_0()
            {
                LK_NUM_CPF.ValueChanged += OnValueChanged;
                LK_DV_CPF.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LK_CPF_INF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
        /*"01      LK-DV-CPF-INF             PIC  9(002).*/
        public IntBasis LK_DV_CPF_INF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01      WS-PROCPF01.*/
        public PROCPF02_WS_PROCPF01 WS_PROCPF01 { get; set; } = new PROCPF02_WS_PROCPF01();
        public class PROCPF02_WS_PROCPF01 : VarBasis
        {
            /*"  05    WS-PROCPF01-01            PIC  9(009).*/
            public IntBasis WS_PROCPF01_01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"  05    WS-PROCPF01-01-R          REDEFINES     WS-PROCPF01-01.*/
            private _REDEF_PROCPF02_WS_PROCPF01_01_R _ws_procpf01_01_r { get; set; }
            public _REDEF_PROCPF02_WS_PROCPF01_01_R WS_PROCPF01_01_R
            {
                get { _ws_procpf01_01_r = new _REDEF_PROCPF02_WS_PROCPF01_01_R(); _.Move(WS_PROCPF01_01, _ws_procpf01_01_r); VarBasis.RedefinePassValue(WS_PROCPF01_01, _ws_procpf01_01_r, WS_PROCPF01_01); _ws_procpf01_01_r.ValueChanged += () => { _.Move(_ws_procpf01_01_r, WS_PROCPF01_01); }; return _ws_procpf01_01_r; }
                set { VarBasis.RedefinePassValue(value, _ws_procpf01_01_r, WS_PROCPF01_01); }
            }  //Redefines
            public class _REDEF_PROCPF02_WS_PROCPF01_01_R : VarBasis
            {
                /*"    10  WS-PROCPF01-01-1          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-2          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-3          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-4          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-5          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-6          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-7          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-8          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_8 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-01-9          PIC  9(001).*/
                public IntBasis WS_PROCPF01_01_9 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  05    WS-PROCPF01-02            PIC  9(002).*/

                public _REDEF_PROCPF02_WS_PROCPF01_01_R()
                {
                    WS_PROCPF01_01_1.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_2.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_3.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_4.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_5.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_6.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_7.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_8.ValueChanged += OnValueChanged;
                    WS_PROCPF01_01_9.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PROCPF01_02 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05    WS-PROCPF01-02-R          REDEFINES     WS-PROCPF01-02.*/
            private _REDEF_PROCPF02_WS_PROCPF01_02_R _ws_procpf01_02_r { get; set; }
            public _REDEF_PROCPF02_WS_PROCPF01_02_R WS_PROCPF01_02_R
            {
                get { _ws_procpf01_02_r = new _REDEF_PROCPF02_WS_PROCPF01_02_R(); _.Move(WS_PROCPF01_02, _ws_procpf01_02_r); VarBasis.RedefinePassValue(WS_PROCPF01_02, _ws_procpf01_02_r, WS_PROCPF01_02); _ws_procpf01_02_r.ValueChanged += () => { _.Move(_ws_procpf01_02_r, WS_PROCPF01_02); }; return _ws_procpf01_02_r; }
                set { VarBasis.RedefinePassValue(value, _ws_procpf01_02_r, WS_PROCPF01_02); }
            }  //Redefines
            public class _REDEF_PROCPF02_WS_PROCPF01_02_R : VarBasis
            {
                /*"    10  WS-PROCPF01-02-1          PIC  9(001).*/
                public IntBasis WS_PROCPF01_02_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    10  WS-PROCPF01-02-2          PIC  9(001).*/
                public IntBasis WS_PROCPF01_02_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01      WS-PARM01-AUX             PIC S9(003)   COMP-3 VALUE +0.*/

                public _REDEF_PROCPF02_WS_PROCPF01_02_R()
                {
                    WS_PROCPF01_02_1.ValueChanged += OnValueChanged;
                    WS_PROCPF01_02_2.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_PARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX1            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX2            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX3            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX4            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX5            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX6            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-PARM01-AUX7            PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_PARM01_AUX7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-SOMAT-AUX              PIC S9(005)   COMP-3 VALUE +0.*/
        public IntBasis WS_SOMAT_AUX { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"01      WS-QUOCIENTE              PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      WS-RESTO                  PIC S9(003)   COMP-3 VALUE +0.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01      LPARM.*/
        public PROCPF02_LPARM LPARM { get; set; } = new PROCPF02_LPARM();
        public class PROCPF02_LPARM : VarBasis
        {
            /*"  05    LPARM-FILLER              PIC  X(002).*/
            public StringBasis LPARM_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05    LPARM-ENT                 PIC  9(011).*/
            public IntBasis LPARM_ENT { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05    LPARM-SAI                 PIC  9(001).*/
            public IntBasis LPARM_SAI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROCPF02_LPARM PROCPF02_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROCPF02_LPARM_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { LPARM };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -145- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -146- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -147- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -158- IF LPARM-ENT NOT NUMERIC */

            if (!LPARM.LPARM_ENT.IsNumeric())
            {

                /*" -159- MOVE 9 TO LPARM-SAI */
                _.Move(9, LPARM.LPARM_SAI);

                /*" -165- ELSE */
            }
            else
            {


                /*" -196- IF LPARM-ENT < 10000 OR LPARM-ENT EQUAL 1910000000 OR LPARM-ENT EQUAL 19100000000 OR LPARM-ENT EQUAL 9100000000 OR LPARM-ENT EQUAL 10000000000 OR LPARM-ENT EQUAL 11000000000 OR LPARM-ENT EQUAL 17500000000 OR LPARM-ENT EQUAL 11111111111 OR LPARM-ENT EQUAL 20000000000 OR LPARM-ENT EQUAL 30000000000 OR LPARM-ENT EQUAL 40000000000 OR LPARM-ENT EQUAL 50000000000 OR LPARM-ENT EQUAL 60000000000 OR LPARM-ENT EQUAL 70000000000 OR LPARM-ENT EQUAL 80000000000 OR LPARM-ENT EQUAL 90000000000 OR LPARM-ENT EQUAL 99000000000 OR LPARM-ENT EQUAL 99900000000 OR LPARM-ENT EQUAL 99990000000 OR LPARM-ENT EQUAL 99999000000 OR LPARM-ENT EQUAL 99999964001 OR LPARM-ENT EQUAL 99999999990 OR LPARM-ENT EQUAL 99999999999 OR LPARM-ENT EQUAL 22222222222 OR LPARM-ENT EQUAL 33333333333 OR LPARM-ENT EQUAL 44444444444 OR LPARM-ENT EQUAL 55555555555 OR LPARM-ENT EQUAL 66666666666 OR LPARM-ENT EQUAL 77777777777 OR LPARM-ENT EQUAL 88888888888 OR LPARM-ENT EQUAL 99999999999999 */

                if (LPARM.LPARM_ENT < 10000 || LPARM.LPARM_ENT == 1910000000 || LPARM.LPARM_ENT == 19100000000 || LPARM.LPARM_ENT == 9100000000 || LPARM.LPARM_ENT == 10000000000 || LPARM.LPARM_ENT == 11000000000 || LPARM.LPARM_ENT == 17500000000 || LPARM.LPARM_ENT == 11111111111 || LPARM.LPARM_ENT == 20000000000 || LPARM.LPARM_ENT == 30000000000 || LPARM.LPARM_ENT == 40000000000 || LPARM.LPARM_ENT == 50000000000 || LPARM.LPARM_ENT == 60000000000 || LPARM.LPARM_ENT == 70000000000 || LPARM.LPARM_ENT == 80000000000 || LPARM.LPARM_ENT == 90000000000 || LPARM.LPARM_ENT == 99000000000 || LPARM.LPARM_ENT == 99900000000 || LPARM.LPARM_ENT == 99990000000 || LPARM.LPARM_ENT == 99999000000 || LPARM.LPARM_ENT == 99999964001 || LPARM.LPARM_ENT == 99999999990 || LPARM.LPARM_ENT == 99999999999 || LPARM.LPARM_ENT == 22222222222 || LPARM.LPARM_ENT == 33333333333 || LPARM.LPARM_ENT == 44444444444 || LPARM.LPARM_ENT == 55555555555 || LPARM.LPARM_ENT == 66666666666 || LPARM.LPARM_ENT == 77777777777 || LPARM.LPARM_ENT == 88888888888 || LPARM.LPARM_ENT == 99999999999999)
                {

                    /*" -197- MOVE 8 TO LPARM-SAI */
                    _.Move(8, LPARM.LPARM_SAI);

                    /*" -198- ELSE */
                }
                else
                {


                    /*" -199- PERFORM P100-TRATA-CPF THRU P100-EXIT */

                    P100_TRATA_CPF(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P100_EXIT*/


                    /*" -200- END-IF */
                }


                /*" -208- END-IF. */
            }


            /*" -208- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" P100-TRATA-CPF */
        private void P100_TRATA_CPF(bool isPerform = false)
        {
            /*" -241- MOVE LPARM-ENT TO WS-PROCPF01. */
            _.Move(LPARM.LPARM_ENT, WS_PROCPF01);

            /*" -251- PERFORM P200-CALCULA-PROCPF01 THRU P200-EXIT. */

            P200_CALCULA_PROCPF01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P200_EXIT*/


            /*" -252- IF LPARM-ENT NOT EQUAL WS-PROCPF01 */

            if (LPARM.LPARM_ENT != WS_PROCPF01)
            {

                /*" -253- MOVE 9 TO LPARM-SAI */
                _.Move(9, LPARM.LPARM_SAI);

                /*" -254- ELSE */
            }
            else
            {


                /*" -255- MOVE 0 TO LPARM-SAI */
                _.Move(0, LPARM.LPARM_SAI);

                /*" -255- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P100_EXIT*/

        [StopWatch]
        /*" P200-CALCULA-PROCPF01 */
        private void P200_CALCULA_PROCPF01(bool isPerform = false)
        {
            /*" -280- COMPUTE WS-SOMAT-AUX = WS-PROCPF01-01-1 * 10 + WS-PROCPF01-01-2 * 9 + WS-PROCPF01-01-3 * 8 + WS-PROCPF01-01-4 * 7 + WS-PROCPF01-01-5 * 6 + WS-PROCPF01-01-6 * 5 + WS-PROCPF01-01-7 * 4 + WS-PROCPF01-01-8 * 3 + WS-PROCPF01-01-9 * 2. */
            WS_SOMAT_AUX.Value = WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_1 * 10 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_2 * 9 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_3 * 8 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_4 * 7 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_5 * 6 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_6 * 5 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_7 * 4 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_8 * 3 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_9 * 2;

            /*" -282- COMPUTE WS-QUOCIENTE = WS-SOMAT-AUX / 11. */
            WS_QUOCIENTE.Value = WS_SOMAT_AUX / 11;

            /*" -284- MOVE ZEROS TO WS-RESTO. */
            _.Move(0, WS_RESTO);

            /*" -286- COMPUTE WS-RESTO = WS-SOMAT-AUX - (WS-QUOCIENTE * 11). */
            WS_RESTO.Value = WS_SOMAT_AUX - (WS_QUOCIENTE * 11);

            /*" -287- IF WS-RESTO EQUAL 1 */

            if (WS_RESTO == 1)
            {

                /*" -288- MOVE 0 TO WS-PROCPF01-02-1 */
                _.Move(0, WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_1);

                /*" -289- ELSE */
            }
            else
            {


                /*" -290- IF WS-RESTO EQUAL 0 */

                if (WS_RESTO == 0)
                {

                    /*" -291- MOVE 0 TO WS-PROCPF01-02-1 */
                    _.Move(0, WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_1);

                    /*" -292- ELSE */
                }
                else
                {


                    /*" -294- SUBTRACT WS-RESTO FROM 11 GIVING WS-PROCPF01-02-1. */
                    WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_1.Value = 11 - WS_RESTO;
                }

            }


            /*" -306- COMPUTE WS-SOMAT-AUX = WS-PROCPF01-01-1 * 11 + WS-PROCPF01-01-2 * 10 + WS-PROCPF01-01-3 * 9 + WS-PROCPF01-01-4 * 8 + WS-PROCPF01-01-5 * 7 + WS-PROCPF01-01-6 * 6 + WS-PROCPF01-01-7 * 5 + WS-PROCPF01-01-8 * 4 + WS-PROCPF01-01-9 * 3 + WS-PROCPF01-02-1 * 2. */
            WS_SOMAT_AUX.Value = WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_1 * 11 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_2 * 10 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_3 * 9 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_4 * 8 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_5 * 7 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_6 * 6 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_7 * 5 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_8 * 4 + WS_PROCPF01.WS_PROCPF01_01_R.WS_PROCPF01_01_9 * 3 + WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_1 * 2;

            /*" -308- COMPUTE WS-QUOCIENTE = WS-SOMAT-AUX / 11. */
            WS_QUOCIENTE.Value = WS_SOMAT_AUX / 11;

            /*" -310- COMPUTE WS-RESTO = WS-SOMAT-AUX - (WS-QUOCIENTE * 11). */
            WS_RESTO.Value = WS_SOMAT_AUX - (WS_QUOCIENTE * 11);

            /*" -311- IF WS-RESTO EQUAL 1 */

            if (WS_RESTO == 1)
            {

                /*" -312- MOVE 0 TO WS-PROCPF01-02-2 */
                _.Move(0, WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_2);

                /*" -313- ELSE */
            }
            else
            {


                /*" -314- IF WS-RESTO EQUAL ZEROS */

                if (WS_RESTO == 00)
                {

                    /*" -315- MOVE 0 TO WS-PROCPF01-02-2 */
                    _.Move(0, WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_2);

                    /*" -316- ELSE */
                }
                else
                {


                    /*" -316- SUBTRACT WS-RESTO FROM 11 GIVING WS-PROCPF01-02-2. */
                    WS_PROCPF01.WS_PROCPF01_02_R.WS_PROCPF01_02_2.Value = 11 - WS_RESTO;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P200_EXIT*/
    }
}