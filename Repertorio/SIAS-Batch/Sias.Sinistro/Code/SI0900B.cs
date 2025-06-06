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
using Sias.Sinistro.DB2.SI0900B;

namespace Code
{
    public class SI0900B
    {
        public bool IsCall { get; set; }

        public SI0900B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................ SINISTRO                            *      */
        /*"      *   PROGRAMA ............... SI0900B                             *      */
        /*"      *   ANALISTA ............... HEIDER                              *      */
        /*"      *   PROGRAMADOR ............ HEIDER                              *      */
        /*"      *   DATA CODIFICACAO ....... JUNHO / 98                          *      */
        /*"      *   FUNCAO ................. AO FINAL DA ROTINA PRINCIPAL DO     *      */
        /*"      *          SISTEMA DE SINISTRO (SID02), GRAVA NA V0SISTEMA A     *      */
        /*"      *          COLUNA DTULTPCS (DATA DO ULTIMO PROCESSAMENTO), A     *      */
        /*"      *          SER UTILIZADA NA SELECAO DOS RECIBOS DE SINISTRO.     *      */
        /*"      *                                                                *      */
        /*"      * RECONVERSAO ANO 2000            CONSEDA4           11/09/1998  *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*" 77 V0SISTEMA-DTMOVABE          PIC X(10).*/
        public StringBasis V0SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*" 77 V0SISTEMA-DTULTPCS          PIC X(10).*/
        public StringBasis V0SISTEMA_DTULTPCS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03        WABEND.*/
        public SI0900B_WABEND WABEND { get; set; } = new SI0900B_WABEND();
        public class SI0900B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' SI0900B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" SI0900B");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05      FILLER              PIC  X(011) VALUE           'SQLCODE = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"SQLCODE = ");
            /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
            /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
            /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
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

                /*" -85- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -86- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -87- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -91- MOVE '001' TO WNR-EXEC-SQL. */
                _.Move("001", WABEND.WNR_EXEC_SQL);

                /*" -96- PERFORM Execute_DB_SELECT_1 */

                Execute_DB_SELECT_1();

                /*" -99- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -100- DISPLAY 'PROBLEMAS SELECT V0SISTEMA............' */
                    _.Display($"PROBLEMAS SELECT V0SISTEMA............");

                    /*" -102- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -104- MOVE V0SISTEMA-DTMOVABE TO V0SISTEMA-DTULTPCS. */
                _.Move(V0SISTEMA_DTMOVABE, V0SISTEMA_DTULTPCS);

                /*" -106- MOVE '002' TO WNR-EXEC-SQL. */
                _.Move("002", WABEND.WNR_EXEC_SQL);

                /*" -110- PERFORM Execute_DB_UPDATE_1 */

                Execute_DB_UPDATE_1();

                /*" -113- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -114- DISPLAY 'PROBLEMAS UPDATE V0SISTEMA............' */
                    _.Display($"PROBLEMAS UPDATE V0SISTEMA............");

                    /*" -116- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO(); //GOTO
                    return Result;
                }


                /*" -117- DISPLAY '**************************************************' . */
                _.Display($"**************************************************");

                /*" -118- DISPLAY '*    DATAS DA V0SISTEMA APOS O TERMINO DA SID02  *' . */
                _.Display($"*    DATAS DA V0SISTEMA APOS O TERMINO DA SID02  *");

                /*" -119- DISPLAY '**************************************************' . */
                _.Display($"**************************************************");

                /*" -120- DISPLAY 'SISTEMA DE SINISTRO = SI' */
                _.Display($"SISTEMA DE SINISTRO = SI");

                /*" -121- DISPLAY 'DATA DO PROCESSAMENTO        = ' V0SISTEMA-DTMOVABE. */
                _.Display($"DATA DO PROCESSAMENTO        = {V0SISTEMA_DTMOVABE}");

                /*" -123- DISPLAY 'DATA DO ULTIMO PROCESSAMENTO = ' V0SISTEMA-DTULTPCS. */
                _.Display($"DATA DO ULTIMO PROCESSAMENTO = {V0SISTEMA_DTULTPCS}");

                /*" -124- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -125- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -126- DISPLAY '//      ==> TERMINO NORMAL <==                //' */
                _.Display($"//      ==> TERMINO NORMAL <==                //");

                /*" -127- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -128- DISPLAY '//      PROGRAMA =>  SI0900B                  //' */
                _.Display($"//      PROGRAMA =>  SI0900B                  //");

                /*" -129- DISPLAY '//                                            //' */
                _.Display($"//                                            //");

                /*" -131- DISPLAY '////////////////////////////////////////////////' */
                _.Display($"////////////////////////////////////////////////");

                /*" -132- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -132- STOP RUN. */

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
            /*" -96- EXEC SQL SELECT DTMOVABE INTO :V0SISTEMA-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'SI' END-EXEC. */

            var execute_DB_SELECT_1_Query1 = new Execute_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = Execute_DB_SELECT_1_Query1.Execute(execute_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SISTEMA_DTMOVABE, V0SISTEMA_DTMOVABE);
            }


        }

        [StopWatch]
        /*" Execute-DB-UPDATE-1 */
        public void Execute_DB_UPDATE_1()
        {
            /*" -110- EXEC SQL UPDATE SEGUROS.V0SISTEMA SET DTULTPCS = :V0SISTEMA-DTULTPCS WHERE IDSISTEM = 'SI' END-EXEC. */

            var execute_DB_UPDATE_1_Update1 = new Execute_DB_UPDATE_1_Update1()
            {
                V0SISTEMA_DTULTPCS = V0SISTEMA_DTULTPCS.ToString(),
            };

            Execute_DB_UPDATE_1_Update1.Execute(execute_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO */
        private void R9999_00_ROT_ERRO(bool isPerform = false)
        {
            /*" -141- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -142- DISPLAY ' ' */
                _.Display($" ");

                /*" -143- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -144- DISPLAY '*  TERMINO ANORMAL DO PROGRAMA SI0900B  *' */
                _.Display($"*  TERMINO ANORMAL DO PROGRAMA SI0900B  *");

                /*" -145- DISPLAY '*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*' */
                _.Display($"*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*");

                /*" -146- DISPLAY ' ' */
                _.Display($" ");

                /*" -147- DISPLAY '==> SEQUENCIAL DE ACESSO COM ERRO = ' WNR-EXEC-SQL */
                _.Display($"==> SEQUENCIAL DE ACESSO COM ERRO = {WABEND.WNR_EXEC_SQL}");

                /*" -148- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -149- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -150- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -151- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -153- DISPLAY WABEND. */
                _.Display(WABEND);
            }


            /*" -153- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -154- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -156- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -156- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}