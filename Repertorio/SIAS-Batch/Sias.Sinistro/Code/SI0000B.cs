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
using Sias.Sinistro.DB2.SI0000B;

namespace Code
{
    public class SI0000B
    {
        public bool IsCall { get; set; }

        public SI0000B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0000B                             *      */
        /*"      *   ANALISTA ............... BARAN / HEIDER                      *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... NOVEMBRO/95                         *      */
        /*"      *   FUNCAO ................. APENAS DAR DISPLAY DA DATA DO       *      */
        /*"      *                            SISTEMA (V0SISTEMA.DTMOVABE)        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                             VIEW              ACESSO    *      */
        /*"      * SISTEMAS                           V0SISTEMA         INPUT     *      */
        /*"      *                                                                *      */
        /*"      * CONVERSAO ANO 2000              CONSEDA4              03/1998  *      */
        /*"      *                                                                *      */
        /*"      * REVISAO - ANO 2000              CONSEDA4           06/06/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         V1SIST-DTMOVABE     PIC  X(010)     VALUE SPACES.*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01           AREA-DE-WORK.*/
        public SI0000B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI0000B_AREA_DE_WORK();
        public class SI0000B_AREA_DE_WORK : VarBasis
        {
            /*"  05  WSL-SQLCODE       PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        WABEND.*/
            public SI0000B_WABEND WABEND { get; set; } = new SI0000B_WABEND();
            public class SI0000B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' SI0000B'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0000B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(010) VALUE           'SQLCODE = '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            }
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -134- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

                /*" -135- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -138- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -141- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -153- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -157- IF (SQLCODE NOT EQUAL ZEROS) AND (SQLCODE NOT EQUAL 100) */

                if ((DB.SQLCODE != 00) && (DB.SQLCODE != 100))
                {

                    /*" -158- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -160- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -161- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -162- DISPLAY 'ERRO ACESSO V1SISTEMA' */
                    _.Display($"ERRO ACESSO V1SISTEMA");

                    /*" -164- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return Result;
                }


                /*" -165- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -166- DISPLAY '*  DATA DA V0SISTEMA (SI) PARA PROCES.  *' */
                _.Display($"*  DATA DA V0SISTEMA (SI) PARA PROCES.  *");

                /*" -167- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -168- DISPLAY ' ' */
                _.Display($" ");

                /*" -169- DISPLAY 'DTMOVABE => ' V1SIST-DTMOVABE. */
                _.Display($"DTMOVABE => {V1SIST_DTMOVABE}");

                /*" -170- DISPLAY ' ' */
                _.Display($" ");

                /*" -172- DISPLAY ' ' */
                _.Display($" ");

                /*" -173- DISPLAY '*****************************************' */
                _.Display($"*****************************************");

                /*" -174- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -175- DISPLAY '*      ==>     SI0000B      <==         *' */
                _.Display($"*      ==>     SI0000B      <==         *");

                /*" -176- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -177- DISPLAY '*      ==>  TERMINO NORMAL  <==         *' */
                _.Display($"*      ==>  TERMINO NORMAL  <==         *");

                /*" -178- DISPLAY '*                                       *' */
                _.Display($"*                                       *");

                /*" -180- DISPLAY '*****************************************' . */
                _.Display($"*****************************************");

                /*" -181- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -181- STOP RUN. */

                throw new GoBack();   // => STOP RUN.

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" Execute-DB-SELECT-1 */
        public void Execute_DB_SELECT_1()
        {
            /*" -153- EXEC SQL SELECT DTMOVABE INTO :V1SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -190- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -191- DISPLAY ' ' */
                _.Display($" ");

                /*" -192- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -193- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0000B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0000B  *");

                /*" -194- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -195- DISPLAY ' ' */
                _.Display($" ");

                /*" -196- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {AREA_DE_WORK.WABEND.WNR_EXEC_SQL}");

                /*" -197- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

                /*" -198- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLCODE1);

                /*" -199- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLCODE2);

                /*" -200- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, AREA_DE_WORK.WSQLCODE3);

                /*" -202- DISPLAY WABEND. */
                _.Display(AREA_DE_WORK.WABEND);
            }


            /*" -202- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -203- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -205- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -205- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}