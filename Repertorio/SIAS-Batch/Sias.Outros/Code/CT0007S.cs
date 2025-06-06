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
    public class CT0007S
    {
        public bool IsCall { get; set; }

        public CT0007S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  CT0007S                            *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  EDILANA                            *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  RECEBE UM NOME E RETORNA SOBRENOME *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  EDILANA                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  MAIO /2010                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01 WS-INDICE                    PIC  9(003) VALUE ZEROS.*/
        public IntBasis WS_INDICE { get; set; } = new IntBasis(new PIC("9", "3", "9(003)"));
        /*"01 WS-GRD-ULT-POS               PIC  9(003).*/
        public IntBasis WS_GRD_ULT_POS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01 WS-GRD-PRM-POS               PIC  9(003).*/
        public IntBasis WS_GRD_PRM_POS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01 WS-AUX-ULT-POS               PIC  9(003).*/
        public IntBasis WS_AUX_ULT_POS { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01 TAM-CAMPO                    PIC  9(003).*/
        public IntBasis TAM_CAMPO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
        /*"01 WS-STRING-NOME               VALUE SPACES.*/
        public CT0007S_WS_STRING_NOME WS_STRING_NOME { get; set; } = new CT0007S_WS_STRING_NOME();
        public class CT0007S_WS_STRING_NOME : VarBasis
        {
            /*"   07 NOME        OCCURS 100    PIC  X(001).*/
            public ListBasis<StringBasis, string> NOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "1", "X(001)."), 100);
            /*"01 WS-STRING-NOMER              VALUE SPACES.*/
        }
        public CT0007S_WS_STRING_NOMER WS_STRING_NOMER { get; set; } = new CT0007S_WS_STRING_NOMER();
        public class CT0007S_WS_STRING_NOMER : VarBasis
        {
            /*"   07 NOMER       OCCURS 40     PIC  X(001).*/
            public ListBasis<StringBasis, string> NOMER { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "1", "X(001)."), 40);
            /*"01  WS-PARAMETROS.*/
        }
        public CT0007S_WS_PARAMETROS WS_PARAMETROS { get; set; } = new CT0007S_WS_PARAMETROS();
        public class CT0007S_WS_PARAMETROS : VarBasis
        {
            /*"    03  WS-NOME                 PIC  X(100).*/
            public StringBasis WS_NOME { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
            /*"    03  WS-SOBRENOME            VALUE SPACES.*/
            public CT0007S_WS_SOBRENOME WS_SOBRENOME { get; set; } = new CT0007S_WS_SOBRENOME();
            public class CT0007S_WS_SOBRENOME : VarBasis
            {
                /*"        07 SOBRENOME OCCURS 40  PIC  X(001).*/
                public ListBasis<StringBasis, string> SOBRENOME { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "1", "X(001)."), 40);
                /*"    03  WS-NOMER                VALUE SPACES.*/
            }
            public CT0007S_WS_NOMER WS_NOMER { get; set; } = new CT0007S_WS_NOMER();
            public class CT0007S_WS_NOMER : VarBasis
            {
                /*"        07 NOMER     OCCURS 40  PIC  X(001).*/
                public ListBasis<StringBasis, string> NOMER_0 { get; set; } = new ListBasis<StringBasis, string>(new PIC("9", "1", "X(001)."), 40);
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(CT0007S_WS_PARAMETROS CT0007S_WS_PARAMETROS_P) //PROCEDURE DIVISION USING 
        /*WS_PARAMETROS*/
        {
            try
            {
                this.WS_PARAMETROS = CT0007S_WS_PARAMETROS_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL-SECTION */

                M_000_000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WS_PARAMETROS };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-SECTION */
        private void M_000_000_PRINCIPAL_SECTION()
        {
            /*" -64- INITIALIZE WS-STRING-NOME. */
            _.Initialize(
                WS_STRING_NOME
            );

            /*" -65- INITIALIZE WS-SOBRENOME. */
            _.Initialize(
                WS_PARAMETROS.WS_SOBRENOME
            );

            /*" -67- MOVE WS-NOME TO WS-STRING-NOME. */
            _.Move(WS_PARAMETROS.WS_NOME, WS_STRING_NOME);

            /*" -68- PERFORM 000-010-CONSISTE-PARM. */

            M_000_010_CONSISTE_PARM_SECTION();

            /*" -69- PERFORM 000-020-BUSCA-SOBRENOME. */

            M_000_020_BUSCA_SOBRENOME_SECTION();

            /*" -70- PERFORM 000-020-MONTA-SOBRENOME. */

            M_000_020_MONTA_SOBRENOME_SECTION();

            /*" -70- PERFORM 000-030-MONTA-NOMER. */

            M_000_030_MONTA_NOMER_SECTION();

        }

        [StopWatch]
        /*" M-000-010-CONSISTE-PARM-SECTION */
        private void M_000_010_CONSISTE_PARM_SECTION()
        {
            /*" -75- IF WS-STRING-NOME EQUAL SPACES */

            if (WS_STRING_NOME.IsEmpty())
            {

                /*" -76- MOVE ' ' TO WS-SOBRENOME */
                _.Move(" ", WS_PARAMETROS.WS_SOBRENOME);

                /*" -76- GO TO 000-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-000-020-BUSCA-SOBRENOME-SECTION */
        private void M_000_020_BUSCA_SOBRENOME_SECTION()
        {
            /*" -81- MOVE 100 TO WS-INDICE. */
            _.Move(100, WS_INDICE);

            /*" -82- IF NOME (WS-INDICE) NOT EQUAL SPACES */

            if (WS_STRING_NOME.NOME[WS_INDICE] != string.Empty)
            {

                /*" -83- MOVE WS-INDICE TO WS-GRD-ULT-POS */
                _.Move(WS_INDICE, WS_GRD_ULT_POS);

                /*" -85- COMPUTE WS-INDICE = WS-INDICE - 1 */
                WS_INDICE.Value = WS_INDICE - 1;

                /*" -86- IF WS-INDICE EQUAL ZEROS */

                if (WS_INDICE == 00)
                {

                    /*" -87- MOVE 1 TO WS-GRD-PRM-POS */
                    _.Move(1, WS_GRD_PRM_POS);

                    /*" -88- GO TO 000-020-MONTA-SOBRENOME */

                    M_000_020_MONTA_SOBRENOME_SECTION(); //GOTO
                    return;

                    /*" -90- END-IF */
                }


                /*" -91- PERFORM UNTIL WS-INDICE EQUAL ZEROS */

                while (!(WS_INDICE == 00))
                {

                    /*" -92- IF NOME(WS-INDICE) EQUAL SPACES */

                    if (WS_STRING_NOME.NOME[WS_INDICE] == string.Empty)
                    {

                        /*" -93- COMPUTE WS-INDICE = WS-INDICE + 1 */
                        WS_INDICE.Value = WS_INDICE + 1;

                        /*" -94- MOVE WS-INDICE TO WS-GRD-PRM-POS */
                        _.Move(WS_INDICE, WS_GRD_PRM_POS);

                        /*" -95- GO TO 000-020-MONTA-SOBRENOME */

                        M_000_020_MONTA_SOBRENOME_SECTION(); //GOTO
                        return;

                        /*" -96- ELSE */
                    }
                    else
                    {


                        /*" -98- COMPUTE WS-INDICE = WS-INDICE - 1 */
                        WS_INDICE.Value = WS_INDICE - 1;

                        /*" -99- IF WS-INDICE EQUAL ZEROS */

                        if (WS_INDICE == 00)
                        {

                            /*" -100- MOVE 1 TO WS-GRD-PRM-POS */
                            _.Move(1, WS_GRD_PRM_POS);

                            /*" -101- GO TO 000-020-MONTA-SOBRENOME */

                            M_000_020_MONTA_SOBRENOME_SECTION(); //GOTO
                            return;

                            /*" -103- END-IF */
                        }


                        /*" -104- END-IF */
                    }


                    /*" -105- END-PERFORM */
                }

                /*" -106- ELSE */
            }
            else
            {


                /*" -107- PERFORM UNTIL WS-INDICE EQUAL ZEROS */

                while (!(WS_INDICE == 00))
                {

                    /*" -108- IF NOME(WS-INDICE) EQUAL SPACES */

                    if (WS_STRING_NOME.NOME[WS_INDICE] == string.Empty)
                    {

                        /*" -109- COMPUTE WS-INDICE = WS-INDICE - 1 */
                        WS_INDICE.Value = WS_INDICE - 1;

                        /*" -110- ELSE */
                    }
                    else
                    {


                        /*" -111- MOVE WS-INDICE TO WS-GRD-ULT-POS */
                        _.Move(WS_INDICE, WS_GRD_ULT_POS);

                        /*" -113- COMPUTE WS-INDICE = WS-INDICE - 1 */
                        WS_INDICE.Value = WS_INDICE - 1;

                        /*" -114- IF WS-INDICE EQUAL ZEROS */

                        if (WS_INDICE == 00)
                        {

                            /*" -115- MOVE 1 TO WS-GRD-PRM-POS */
                            _.Move(1, WS_GRD_PRM_POS);

                            /*" -116- GO TO 000-020-MONTA-SOBRENOME */

                            M_000_020_MONTA_SOBRENOME_SECTION(); //GOTO
                            return;

                            /*" -118- END-IF */
                        }


                        /*" -119- PERFORM UNTIL WS-INDICE EQUAL ZEROS */

                        while (!(WS_INDICE == 00))
                        {

                            /*" -120- IF NOME(WS-INDICE) EQUAL SPACES */

                            if (WS_STRING_NOME.NOME[WS_INDICE] == string.Empty)
                            {

                                /*" -121- COMPUTE WS-INDICE = WS-INDICE + 1 */
                                WS_INDICE.Value = WS_INDICE + 1;

                                /*" -123- MOVE WS-INDICE TO WS-GRD-PRM-POS WS-GRD-PRM-POS */
                                _.Move(WS_INDICE, WS_GRD_PRM_POS, WS_GRD_PRM_POS);

                                /*" -124- GO TO 000-020-MONTA-SOBRENOME */

                                M_000_020_MONTA_SOBRENOME_SECTION(); //GOTO
                                return;

                                /*" -125- ELSE */
                            }
                            else
                            {


                                /*" -127- COMPUTE WS-INDICE = WS-INDICE - 1 */
                                WS_INDICE.Value = WS_INDICE - 1;

                                /*" -128- IF WS-INDICE EQUAL ZEROS */

                                if (WS_INDICE == 00)
                                {

                                    /*" -129- MOVE 1 TO WS-GRD-PRM-POS */
                                    _.Move(1, WS_GRD_PRM_POS);

                                    /*" -130- GO TO 000-020-MONTA-SOBRENOME */

                                    M_000_020_MONTA_SOBRENOME_SECTION(); //GOTO
                                    return;

                                    /*" -132- END-IF */
                                }


                                /*" -133- END-IF */
                            }


                            /*" -134- END-PERFORM */
                        }

                        /*" -135- END-IF */
                    }


                    /*" -136- END-PERFORM */
                }

                /*" -136- END-IF. */
            }


        }

        [StopWatch]
        /*" M-000-020-MONTA-SOBRENOME-SECTION */
        private void M_000_020_MONTA_SOBRENOME_SECTION()
        {
            /*" -141- INITIALIZE WS-SOBRENOME */
            _.Initialize(
                WS_PARAMETROS.WS_SOBRENOME
            );

            /*" -143- MOVE WS-STRING-NOME(WS-GRD-PRM-POS:WS-GRD-ULT-POS) TO WS-SOBRENOME. */
            _.Move(WS_STRING_NOME.Substring(WS_GRD_PRM_POS, WS_GRD_ULT_POS), WS_PARAMETROS.WS_SOBRENOME);

            /*" -144- COMPUTE WS-AUX-ULT-POS = WS-GRD-ULT-POS - WS-GRD-PRM-POS */
            WS_AUX_ULT_POS.Value = WS_GRD_ULT_POS - WS_GRD_PRM_POS;

            /*" -145- COMPUTE WS-AUX-ULT-POS = WS-AUX-ULT-POS + 2 */
            WS_AUX_ULT_POS.Value = WS_AUX_ULT_POS + 2;

            /*" -146- MOVE ' ' TO WS-SOBRENOME(WS-AUX-ULT-POS:40) */
            _.MoveAtPosition(" ", WS_PARAMETROS.WS_SOBRENOME, WS_AUX_ULT_POS, 40);

            /*" -147- IF WS-SOBRENOME EQUAL WS-STRING-NOME */

            if (WS_PARAMETROS.WS_SOBRENOME == WS_STRING_NOME)
            {

                /*" -147- MOVE ' ' TO WS-SOBRENOME. */
                _.Move(" ", WS_PARAMETROS.WS_SOBRENOME);
            }


        }

        [StopWatch]
        /*" M-000-030-MONTA-NOMER-SECTION */
        private void M_000_030_MONTA_NOMER_SECTION()
        {
            /*" -152- INITIALIZE WS-NOMER */
            _.Initialize(
                WS_PARAMETROS.WS_NOMER
            );

            /*" -153- COMPUTE WS-GRD-ULT-POS = WS-GRD-PRM-POS - 1 */
            WS_GRD_ULT_POS.Value = WS_GRD_PRM_POS - 1;

            /*" -154- MOVE 1 TO WS-GRD-PRM-POS */
            _.Move(1, WS_GRD_PRM_POS);

            /*" -156- MOVE WS-STRING-NOME(WS-GRD-PRM-POS:WS-GRD-ULT-POS) TO WS-NOMER. */
            _.Move(WS_STRING_NOME.Substring(WS_GRD_PRM_POS, WS_GRD_ULT_POS), WS_PARAMETROS.WS_NOMER);

            /*" -157- IF WS-SOBRENOME EQUAL SPACES */

            if (WS_PARAMETROS.WS_SOBRENOME.IsEmpty())
            {

                /*" -157- MOVE WS-STRING-NOME TO WS-NOMER. */
                _.Move(WS_STRING_NOME, WS_PARAMETROS.WS_NOMER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/
    }
}