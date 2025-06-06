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
    public class PROALN01
    {
        public bool IsCall { get; set; }

        public PROALN01()
        {
            AppSettings.Load();
        }

        #region VARIABLES

        /*"01          AREAS-DE-WORK.*/
        public PROALN01_AREAS_DE_WORK AREAS_DE_WORK { get; set; } = new PROALN01_AREAS_DE_WORK();
        public class PROALN01_AREAS_DE_WORK : VarBasis
        {
            /*"    03      LINHA01.*/
            public PROALN01_LINHA01 LINHA01 { get; set; } = new PROALN01_LINHA01();
            public class PROALN01_LINHA01 : VarBasis
            {
                /*"      05    LET01               PIC  X(001)   OCCURS  132 TIMES.*/
                public ListBasis<StringBasis, string> LET01 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 132);
                /*"    03      LINHA02.*/
            }
            public PROALN01_LINHA02 LINHA02 { get; set; } = new PROALN01_LINHA02();
            public class PROALN01_LINHA02 : VarBasis
            {
                /*"      05    LET02               PIC  X(001)   OCCURS  132 TIMES.*/
                public ListBasis<StringBasis, string> LET02 { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(001)"), 132);
                /*"    03      IND01               PIC S9(003)   COMP-3  VALUE 0.*/
            }
            public IntBasis IND01 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    03      IND02               PIC S9(003)   COMP-3  VALUE 0.*/
            public IntBasis IND02 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"    03      IND03               PIC S9(003)   COMP-3  VALUE 0.*/
            public IntBasis IND03 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"01          AREA-DE-LINK.*/
        }
        public PROALN01_AREA_DE_LINK AREA_DE_LINK { get; set; } = new PROALN01_AREA_DE_LINK();
        public class PROALN01_AREA_DE_LINK : VarBasis
        {
            /*"    03      RCCODE              PIC S9(004)   COMP.*/
            public IntBasis RCCODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      TAMANHO             PIC S9(004)   COMP.*/
            public IntBasis TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    03      LINHA               PIC  X(132).*/
            public StringBasis LINHA { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(PROALN01_AREA_DE_LINK PROALN01_AREA_DE_LINK_P) //PROCEDURE DIVISION USING 
        /*AREA_DE_LINK*/
        {
            try
            {
                this.AREA_DE_LINK = PROALN01_AREA_DE_LINK_P;

                /*" -0- FLUXCONTROL_PERFORM M-000-00-PRINCIPAL */

                M_000_00_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { AREA_DE_LINK };
            return Result;
        }

        [StopWatch]
        /*" M-000-00-PRINCIPAL */
        private void M_000_00_PRINCIPAL(bool isPerform = false)
        {
            /*" -36- MOVE LINHA TO LINHA01. */
            _.Move(AREA_DE_LINK.LINHA, AREAS_DE_WORK.LINHA01);

            /*" -38- MOVE SPACES TO LINHA02. */
            _.Move("", AREAS_DE_WORK.LINHA02);

            /*" -46- PERFORM M-010-00-ACHA-LETRA THRU 010-99-EXIT VARYING IND01 FROM 1 BY 1 UNTIL IND01 EQUAL 132 OR LET01(IND01) NOT EQUAL SPACES. */

            for (AREAS_DE_WORK.IND01.Value = 1; !(AREAS_DE_WORK.IND01 == 132 || AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND01] != string.Empty); AREAS_DE_WORK.IND01.Value += 1)
            {
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_00_ACHA_LETRA*/

                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_99_EXIT*/

            }

            /*" -47- MOVE LET01(IND01) TO LET02(1). */
            _.Move(AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND01], AREAS_DE_WORK.LINHA02.LET02[1]);

            /*" -48- MOVE 1 TO IND02. */
            _.Move(1, AREAS_DE_WORK.IND02);

            /*" -50- ADD 1 TO IND01. */
            AREAS_DE_WORK.IND01.Value = AREAS_DE_WORK.IND01 + 1;

            /*" -56- PERFORM 020-00-ALINHA THRU 020-99-EXIT VARYING IND01 FROM IND01 BY 1 UNTIL IND01 EQUAL 132. */

            for (AREAS_DE_WORK.IND01.Value = AREAS_DE_WORK.IND01; !(AREAS_DE_WORK.IND01 == 132); AREAS_DE_WORK.IND01.Value += 1)
            {

                M_020_00_ALINHA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_99_EXIT*/

            }

            /*" -63- PERFORM 030-00-CONTA THRU 030-99-EXIT VARYING IND02 FROM TAMANHO BY -1 UNTIL IND02 EQUAL ZEROS OR LET02(IND02) NOT EQUAL SPACES. */

            for (AREAS_DE_WORK.IND02.Value = AREA_DE_LINK.TAMANHO; !(AREAS_DE_WORK.IND02 == 00 || AREAS_DE_WORK.LINHA02.LET02[AREAS_DE_WORK.IND02] != string.Empty); AREAS_DE_WORK.IND02.Value += -1)
            {
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_00_CONTA*/

                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_99_EXIT*/

            }

            /*" -64- COMPUTE IND01 = (TAMANHO - IND02) / 2 + 1. */
            AREAS_DE_WORK.IND01.Value = (AREA_DE_LINK.TAMANHO - AREAS_DE_WORK.IND02) / 2 + 1;

            /*" -65- MOVE IND01 TO IND02. */
            _.Move(AREAS_DE_WORK.IND01, AREAS_DE_WORK.IND02);

            /*" -66- MOVE LINHA02 TO LINHA01. */
            _.Move(AREAS_DE_WORK.LINHA02, AREAS_DE_WORK.LINHA01);

            /*" -68- MOVE SPACES TO LINHA02. */
            _.Move("", AREAS_DE_WORK.LINHA02);

            /*" -75- PERFORM 040-00-CENTRALIZA THRU 040-99-EXIT VARYING IND01 FROM 1 BY 1 UNTIL IND02 EQUAL TAMANHO. */

            for (AREAS_DE_WORK.IND01.Value = 1; !(AREAS_DE_WORK.IND02 == AREA_DE_LINK.TAMANHO); AREAS_DE_WORK.IND01.Value += 1)
            {

                M_040_00_CENTRALIZA(true);
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_99_EXIT*/

            }

            /*" -78- MOVE LINHA02 TO LINHA. */
            _.Move(AREAS_DE_WORK.LINHA02, AREA_DE_LINK.LINHA);

            /*" -78- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_00_ACHA_LETRA*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_99_EXIT*/

        [StopWatch]
        /*" M-020-00-ALINHA */
        private void M_020_00_ALINHA(bool isPerform = false)
        {
            /*" -88- IF LET01(IND01) NOT EQUAL SPACES */

            if (AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND01] != string.Empty)
            {

                /*" -89- ADD 1 TO IND02 */
                AREAS_DE_WORK.IND02.Value = AREAS_DE_WORK.IND02 + 1;

                /*" -90- MOVE LET01(IND01) TO LET02(IND02) */
                _.Move(AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND01], AREAS_DE_WORK.LINHA02.LET02[AREAS_DE_WORK.IND02]);

                /*" -91- ELSE */
            }
            else
            {


                /*" -92- IF LET01(IND03) NOT EQUAL SPACES */

                if (AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND03] != string.Empty)
                {

                    /*" -93- ADD 1 TO IND02 */
                    AREAS_DE_WORK.IND02.Value = AREAS_DE_WORK.IND02 + 1;

                    /*" -94- MOVE LET01(IND01) TO LET02(IND02). */
                    _.Move(AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND01], AREAS_DE_WORK.LINHA02.LET02[AREAS_DE_WORK.IND02]);
                }

            }


            /*" -94- MOVE IND01 TO IND03. */
            _.Move(AREAS_DE_WORK.IND01, AREAS_DE_WORK.IND03);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_99_EXIT*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_00_CONTA*/
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_99_EXIT*/

        [StopWatch]
        /*" M-040-00-CENTRALIZA */
        private void M_040_00_CENTRALIZA(bool isPerform = false)
        {
            /*" -106- MOVE LET01(IND01) TO LET02(IND02). */
            _.Move(AREAS_DE_WORK.LINHA01.LET01[AREAS_DE_WORK.IND01], AREAS_DE_WORK.LINHA02.LET02[AREAS_DE_WORK.IND02]);

            /*" -106- ADD 1 TO IND02. */
            AREAS_DE_WORK.IND02.Value = AREAS_DE_WORK.IND02 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_040_99_EXIT*/
    }
}