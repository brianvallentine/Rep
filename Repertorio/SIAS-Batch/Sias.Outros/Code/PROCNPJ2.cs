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
    public class PROCNPJ2
    {
        public bool IsCall { get; set; }

        public PROCNPJ2()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *** **************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  PROCNPJ2                           *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  ALCIONE ARAUJO                     *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  VALIDACOES COMPLEMENTARES DE CNPJ. *      */
        /*"      *                             UTILIZADA ANTES DA CHAMADA DA      *      */
        /*"      *                             SUBROTINA PROCGC01.                *      */
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
        /*"V.3.0 * 3.    3.0    12/09/2016   FRANK CARVLAHO.   PERMITIR CNPJ 191  *      */
        /*"V.3.0 *                                             DO BANCO DO BRASIL.*      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"01        LK-LINK-CNPJ            PIC  9(014)   VALUE ZEROS.*/
        public IntBasis LK_LINK_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)"));
        /*"01        FILLER      REDEFINES LK-LINK-CNPJ.*/
        private _REDEF_PROCNPJ2_FILLER_0 _filler_0 { get; set; }
        public _REDEF_PROCNPJ2_FILLER_0 FILLER_0
        {
            get { _filler_0 = new _REDEF_PROCNPJ2_FILLER_0(); _.Move(LK_LINK_CNPJ, _filler_0); VarBasis.RedefinePassValue(LK_LINK_CNPJ, _filler_0, LK_LINK_CNPJ); _filler_0.ValueChanged += () => { _.Move(_filler_0, LK_LINK_CNPJ); }; return _filler_0; }
            set { VarBasis.RedefinePassValue(value, _filler_0, LK_LINK_CNPJ); }
        }  //Redefines
        public class _REDEF_PROCNPJ2_FILLER_0 : VarBasis
        {
            /*"  05      LK-NUM-CNPJ             PIC  9(012).*/
            public IntBasis LK_NUM_CNPJ { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"  05      LK-DV-CNPJ              PIC  9(002).*/
            public IntBasis LK_DV_CNPJ { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"01        LK-CNPJ-INF             PIC  9(014).*/

            public _REDEF_PROCNPJ2_FILLER_0()
            {
                LK_NUM_CNPJ.ValueChanged += OnValueChanged;
                LK_DV_CNPJ.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis LK_CNPJ_INF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
        /*"01        LK-DV-CNPJ-INF          PIC  9(002).*/
        public IntBasis LK_DV_CNPJ_INF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
        /*"01  WS-PROCGC01.*/
        public PROCNPJ2_WS_PROCGC01 WS_PROCGC01 { get; set; } = new PROCNPJ2_WS_PROCGC01();
        public class PROCNPJ2_WS_PROCGC01 : VarBasis
        {
            /*"    03 WS-PROCGC01-01                PIC  9(007).*/
            public IntBasis WS_PROCGC01_01 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"    03 WS-PROCGC01-01-R REDEFINES    WS-PROCGC01-01.*/
            private _REDEF_PROCNPJ2_WS_PROCGC01_01_R _ws_procgc01_01_r { get; set; }
            public _REDEF_PROCNPJ2_WS_PROCGC01_01_R WS_PROCGC01_01_R
            {
                get { _ws_procgc01_01_r = new _REDEF_PROCNPJ2_WS_PROCGC01_01_R(); _.Move(WS_PROCGC01_01, _ws_procgc01_01_r); VarBasis.RedefinePassValue(WS_PROCGC01_01, _ws_procgc01_01_r, WS_PROCGC01_01); _ws_procgc01_01_r.ValueChanged += () => { _.Move(_ws_procgc01_01_r, WS_PROCGC01_01); }; return _ws_procgc01_01_r; }
                set { VarBasis.RedefinePassValue(value, _ws_procgc01_01_r, WS_PROCGC01_01); }
            }  //Redefines
            public class _REDEF_PROCNPJ2_WS_PROCGC01_01_R : VarBasis
            {
                /*"       05 WS-PROCGC01-01-1           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-01-2           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-01-3           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-01-4           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-01-5           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_5 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-01-6           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_6 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-01-7           PIC  9(001).*/
                public IntBasis WS_PROCGC01_01_7 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03 WS-PROCGC01-02                PIC  9(001).*/

                public _REDEF_PROCNPJ2_WS_PROCGC01_01_R()
                {
                    WS_PROCGC01_01_1.ValueChanged += OnValueChanged;
                    WS_PROCGC01_01_2.ValueChanged += OnValueChanged;
                    WS_PROCGC01_01_3.ValueChanged += OnValueChanged;
                    WS_PROCGC01_01_4.ValueChanged += OnValueChanged;
                    WS_PROCGC01_01_5.ValueChanged += OnValueChanged;
                    WS_PROCGC01_01_6.ValueChanged += OnValueChanged;
                    WS_PROCGC01_01_7.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PROCGC01_02 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"    03 WS-PROCGC01-03                PIC  9(004).*/
            public IntBasis WS_PROCGC01_03 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WS-PROCGC01-03-R REDEFINES    WS-PROCGC01-03.*/
            private _REDEF_PROCNPJ2_WS_PROCGC01_03_R _ws_procgc01_03_r { get; set; }
            public _REDEF_PROCNPJ2_WS_PROCGC01_03_R WS_PROCGC01_03_R
            {
                get { _ws_procgc01_03_r = new _REDEF_PROCNPJ2_WS_PROCGC01_03_R(); _.Move(WS_PROCGC01_03, _ws_procgc01_03_r); VarBasis.RedefinePassValue(WS_PROCGC01_03, _ws_procgc01_03_r, WS_PROCGC01_03); _ws_procgc01_03_r.ValueChanged += () => { _.Move(_ws_procgc01_03_r, WS_PROCGC01_03); }; return _ws_procgc01_03_r; }
                set { VarBasis.RedefinePassValue(value, _ws_procgc01_03_r, WS_PROCGC01_03); }
            }  //Redefines
            public class _REDEF_PROCNPJ2_WS_PROCGC01_03_R : VarBasis
            {
                /*"       05 WS-PROCGC01-03-1           PIC  9(001).*/
                public IntBasis WS_PROCGC01_03_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-03-2           PIC  9(001).*/
                public IntBasis WS_PROCGC01_03_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-03-3           PIC  9(001).*/
                public IntBasis WS_PROCGC01_03_3 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-03-4           PIC  9(001).*/
                public IntBasis WS_PROCGC01_03_4 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    03 WS-PROCGC01-04                PIC  9(002).*/

                public _REDEF_PROCNPJ2_WS_PROCGC01_03_R()
                {
                    WS_PROCGC01_03_1.ValueChanged += OnValueChanged;
                    WS_PROCGC01_03_2.ValueChanged += OnValueChanged;
                    WS_PROCGC01_03_3.ValueChanged += OnValueChanged;
                    WS_PROCGC01_03_4.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_PROCGC01_04 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    03 WS-PROCGC01-04-R REDEFINES  WS-PROCGC01-04.*/
            private _REDEF_PROCNPJ2_WS_PROCGC01_04_R _ws_procgc01_04_r { get; set; }
            public _REDEF_PROCNPJ2_WS_PROCGC01_04_R WS_PROCGC01_04_R
            {
                get { _ws_procgc01_04_r = new _REDEF_PROCNPJ2_WS_PROCGC01_04_R(); _.Move(WS_PROCGC01_04, _ws_procgc01_04_r); VarBasis.RedefinePassValue(WS_PROCGC01_04, _ws_procgc01_04_r, WS_PROCGC01_04); _ws_procgc01_04_r.ValueChanged += () => { _.Move(_ws_procgc01_04_r, WS_PROCGC01_04); }; return _ws_procgc01_04_r; }
                set { VarBasis.RedefinePassValue(value, _ws_procgc01_04_r, WS_PROCGC01_04); }
            }  //Redefines
            public class _REDEF_PROCNPJ2_WS_PROCGC01_04_R : VarBasis
            {
                /*"       05 WS-PROCGC01-04-1           PIC  9(001).*/
                public IntBasis WS_PROCGC01_04_1 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       05 WS-PROCGC01-04-2           PIC  9(001).*/
                public IntBasis WS_PROCGC01_04_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"01  WS-PARM01-AUX               PIC S9(003) COMP-3 VALUE ZEROS.*/

                public _REDEF_PROCNPJ2_WS_PROCGC01_04_R()
                {
                    WS_PROCGC01_04_1.ValueChanged += OnValueChanged;
                    WS_PROCGC01_04_2.ValueChanged += OnValueChanged;
                }

            }
        }
        public IntBasis WS_PARM01_AUX { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX1              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX1 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX2              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX2 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX3              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX3 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX4              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX4 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX5              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX5 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX6              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX6 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-PARM01-AUX7              PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_PARM01_AUX7 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-SOMAT-AUX                PIC S9(005) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_SOMAT_AUX { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));
        /*"01  WS-QUOCIENTE                PIC S9(003) COMP-3 VALUE ZEROS.*/
        public IntBasis WS_QUOCIENTE { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01  WS-RESTO                    PIC S9(003) COMP-3.*/
        public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
        /*"01              LPARM.*/
        public PROCNPJ2_LPARM LPARM { get; set; } = new PROCNPJ2_LPARM();
        public class PROCNPJ2_LPARM : VarBasis
        {
            /*"  03            LPARM-FILLER    PIC  X(002).*/
            public StringBasis LPARM_FILLER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  03            LPARM-ENT       PIC  9(014).*/
            public IntBasis LPARM_ENT { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  03            LPARM-SAI       PIC  9(001).*/
            public IntBasis LPARM_SAI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROCNPJ2_LPARM PROCNPJ2_LPARM_P) //PROCEDURE DIVISION USING 
        /*LPARM*/
        {
            try
            {
                this.LPARM = PROCNPJ2_LPARM_P;

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
            /*" -113- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -114- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -115- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -122- IF LPARM-ENT NOT NUMERIC */

            if (!LPARM.LPARM_ENT.IsNumeric())
            {

                /*" -123- MOVE 9 TO LPARM-SAI */
                _.Move(9, LPARM.LPARM_SAI);

                /*" -124- ELSE */
            }
            else
            {


                /*" -157- IF (LPARM-ENT < 100000 AND LPARM-ENT NOT EQUAL 191) OR LPARM-ENT EQUAL 1910000000 OR LPARM-ENT EQUAL 19100000000 OR LPARM-ENT EQUAL 9100000000 OR LPARM-ENT EQUAL 10000000000 OR LPARM-ENT EQUAL 11000000000 OR LPARM-ENT EQUAL 17500000000 OR LPARM-ENT EQUAL 11111111111 OR LPARM-ENT EQUAL 20000000000 OR LPARM-ENT EQUAL 30000000000 OR LPARM-ENT EQUAL 40000000000 OR LPARM-ENT EQUAL 50000000000 OR LPARM-ENT EQUAL 60000000000 OR LPARM-ENT EQUAL 70000000000 OR LPARM-ENT EQUAL 80000000000 OR LPARM-ENT EQUAL 90000000000 OR LPARM-ENT EQUAL 99000000000 OR LPARM-ENT EQUAL 99900000000 OR LPARM-ENT EQUAL 99990000000 OR LPARM-ENT EQUAL 99999000000 OR LPARM-ENT EQUAL 99999964001 OR LPARM-ENT EQUAL 99999999990 OR LPARM-ENT EQUAL 99999999999 OR LPARM-ENT EQUAL 22222222222 OR LPARM-ENT EQUAL 33333333333 OR LPARM-ENT EQUAL 44444444444 OR LPARM-ENT EQUAL 55555555555 OR LPARM-ENT EQUAL 66666666666 OR LPARM-ENT EQUAL 77777777777 OR LPARM-ENT EQUAL 88888888888 OR LPARM-ENT EQUAL 99999999999999 */

                if ((LPARM.LPARM_ENT < 100000 && LPARM.LPARM_ENT != 191) || LPARM.LPARM_ENT == 1910000000 || LPARM.LPARM_ENT == 19100000000 || LPARM.LPARM_ENT == 9100000000 || LPARM.LPARM_ENT == 10000000000 || LPARM.LPARM_ENT == 11000000000 || LPARM.LPARM_ENT == 17500000000 || LPARM.LPARM_ENT == 11111111111 || LPARM.LPARM_ENT == 20000000000 || LPARM.LPARM_ENT == 30000000000 || LPARM.LPARM_ENT == 40000000000 || LPARM.LPARM_ENT == 50000000000 || LPARM.LPARM_ENT == 60000000000 || LPARM.LPARM_ENT == 70000000000 || LPARM.LPARM_ENT == 80000000000 || LPARM.LPARM_ENT == 90000000000 || LPARM.LPARM_ENT == 99000000000 || LPARM.LPARM_ENT == 99900000000 || LPARM.LPARM_ENT == 99990000000 || LPARM.LPARM_ENT == 99999000000 || LPARM.LPARM_ENT == 99999964001 || LPARM.LPARM_ENT == 99999999990 || LPARM.LPARM_ENT == 99999999999 || LPARM.LPARM_ENT == 22222222222 || LPARM.LPARM_ENT == 33333333333 || LPARM.LPARM_ENT == 44444444444 || LPARM.LPARM_ENT == 55555555555 || LPARM.LPARM_ENT == 66666666666 || LPARM.LPARM_ENT == 77777777777 || LPARM.LPARM_ENT == 88888888888 || LPARM.LPARM_ENT == 99999999999999)
                {

                    /*" -158- MOVE 8 TO LPARM-SAI */
                    _.Move(8, LPARM.LPARM_SAI);

                    /*" -159- ELSE */
                }
                else
                {


                    /*" -160- PERFORM P100-TRATA-CNPJ THRU P100-EXIT */

                    P100_TRATA_CNPJ(true);
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: P100_EXIT*/


                    /*" -161- END-IF */
                }


                /*" -165- END-IF. */
            }


            /*" -165- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" P100-TRATA-CNPJ */
        private void P100_TRATA_CNPJ(bool isPerform = false)
        {
            /*" -191- MOVE LPARM-ENT TO LK-LINK-CNPJ LK-CNPJ-INF */
            _.Move(LPARM.LPARM_ENT, LK_LINK_CNPJ, LK_CNPJ_INF);

            /*" -192- MOVE LPARM-ENT TO WS-PROCGC01 */
            _.Move(LPARM.LPARM_ENT, WS_PROCGC01);

            /*" -197- PERFORM P200-CALCULA-PROCGC01 THRU P200-EXIT */

            P200_CALCULA_PROCGC01(true);
            /*Método Suprimido por falta de linha ou apenas EXIT nome: P200_EXIT*/


            /*" -198- IF LPARM-ENT NOT EQUAL WS-PROCGC01 */

            if (LPARM.LPARM_ENT != WS_PROCGC01)
            {

                /*" -199- MOVE 9 TO LPARM-SAI */
                _.Move(9, LPARM.LPARM_SAI);

                /*" -200- ELSE */
            }
            else
            {


                /*" -201- MOVE 0 TO LPARM-SAI */
                _.Move(0, LPARM.LPARM_SAI);

                /*" -206- END-IF */
            }


            /*" -206- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P100_EXIT*/

        [StopWatch]
        /*" P200-CALCULA-PROCGC01 */
        private void P200_CALCULA_PROCGC01(bool isPerform = false)
        {
            /*" -230- COMPUTE WS-PARM01-AUX = WS-PROCGC01-01-1 * 5 + WS-PROCGC01-01-2 * 4 + WS-PROCGC01-01-3 * 3 + WS-PROCGC01-01-4 * 2 + WS-PROCGC01-01-5 * 9 + WS-PROCGC01-01-6 * 8 + WS-PROCGC01-01-7 * 7 + WS-PROCGC01-02 * 6 + WS-PROCGC01-03-1 * 5 + WS-PROCGC01-03-2 * 4 + WS-PROCGC01-03-3 * 3 + WS-PROCGC01-03-4 * 2. */
            WS_PARM01_AUX.Value = WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_1 * 5 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_2 * 4 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_3 * 3 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_4 * 2 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_5 * 9 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_6 * 8 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_7 * 7 + WS_PROCGC01.WS_PROCGC01_02 * 6 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_1 * 5 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_2 * 4 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_3 * 3 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_4 * 2;

            /*" -233- DIVIDE WS-PARM01-AUX BY 11 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
            _.Divide(WS_PARM01_AUX, 11, WS_QUOCIENTE, WS_RESTO);

            /*" -234- IF WS-RESTO EQUAL 1 */

            if (WS_RESTO == 1)
            {

                /*" -235- MOVE 0 TO WS-PROCGC01-04-1 */
                _.Move(0, WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_1);

                /*" -236- ELSE */
            }
            else
            {


                /*" -237- IF WS-RESTO EQUAL ZEROS */

                if (WS_RESTO == 00)
                {

                    /*" -238- MOVE 0 TO WS-PROCGC01-04-1 */
                    _.Move(0, WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_1);

                    /*" -239- ELSE */
                }
                else
                {


                    /*" -242- SUBTRACT WS-RESTO FROM 11 GIVING WS-PROCGC01-04-1. */
                    WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_1.Value = 11 - WS_RESTO;
                }

            }


            /*" -257- COMPUTE WS-PARM01-AUX = WS-PROCGC01-01-1 * 6 + WS-PROCGC01-01-2 * 5 + WS-PROCGC01-01-3 * 4 + WS-PROCGC01-01-4 * 3 + WS-PROCGC01-01-5 * 2 + WS-PROCGC01-01-6 * 9 + WS-PROCGC01-01-7 * 8 + WS-PROCGC01-02 * 7 + WS-PROCGC01-03-1 * 6 + WS-PROCGC01-03-2 * 5 + WS-PROCGC01-03-3 * 4 + WS-PROCGC01-03-4 * 3 + WS-PROCGC01-04-1 * 2. */
            WS_PARM01_AUX.Value = WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_1 * 6 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_2 * 5 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_3 * 4 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_4 * 3 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_5 * 2 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_6 * 9 + WS_PROCGC01.WS_PROCGC01_01_R.WS_PROCGC01_01_7 * 8 + WS_PROCGC01.WS_PROCGC01_02 * 7 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_1 * 6 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_2 * 5 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_3 * 4 + WS_PROCGC01.WS_PROCGC01_03_R.WS_PROCGC01_03_4 * 3 + WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_1 * 2;

            /*" -260- DIVIDE WS-PARM01-AUX BY 11 GIVING WS-QUOCIENTE REMAINDER WS-RESTO */
            _.Divide(WS_PARM01_AUX, 11, WS_QUOCIENTE, WS_RESTO);

            /*" -261- IF WS-RESTO EQUAL 1 */

            if (WS_RESTO == 1)
            {

                /*" -262- MOVE 0 TO WS-PROCGC01-04-2 */
                _.Move(0, WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_2);

                /*" -263- ELSE */
            }
            else
            {


                /*" -264- IF WS-RESTO EQUAL ZEROS */

                if (WS_RESTO == 00)
                {

                    /*" -265- MOVE 0 TO WS-PROCGC01-04-2 */
                    _.Move(0, WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_2);

                    /*" -266- ELSE */
                }
                else
                {


                    /*" -267- SUBTRACT WS-RESTO FROM 11 GIVING WS-PROCGC01-04-2. */
                    WS_PROCGC01.WS_PROCGC01_04_R.WS_PROCGC01_04_2.Value = 11 - WS_RESTO;
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: P200_EXIT*/
    }
}