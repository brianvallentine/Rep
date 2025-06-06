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
using Sias.VidaEmGrupo.DB2.VG0032B;

namespace Code
{
    public class VG0032B
    {
        public bool IsCall { get; set; }

        public VG0032B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *              *** CANCELAMENTO ***                              *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  LE TABELA SEGURADOS_VGAP           *      */
        /*"      *                             E ATUALIZA SITUACAO DE CANCELAMEN- *      */
        /*"      *                             TO NA PROPOSTAS_VA.                *      */
        /*"      *                                                                *      */
        /*"      *   ANALISTA ...............  FREDERICO/MESSIAS                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0032B                            *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  JULHO/2001                         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO:  25/07/08   WELLINGTON VERAS (POLITEC)              *      */
        /*"      *    PROJETO FGV                                                 *      */
        /*"      *                INIBIR COMANDO DISPLAY    WV0708                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"  03            WSQLCODE3           PIC S9(009) COMP.*/
        public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"  03            AC-GRAVA            PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_GRAVA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03            AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"  03            WFIM-MOVIMENTO      PIC  X(001) VALUE 'N'.*/
        public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
        /*"  03        WABEND.*/
        public VG0032B_WABEND WABEND { get; set; } = new VG0032B_WABEND();
        public class VG0032B_WABEND : VarBasis
        {
            /*"    05      FILLER              PIC  X(010) VALUE           ' VG0032B'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0032B");
            /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
            /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
            /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
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


        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public VG0032B_TMOVIMENTO TMOVIMENTO { get; set; } = new VG0032B_TMOVIMENTO();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -96- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -98- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -100- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -105- PERFORM 090-000-CURSOR-V1MOVIMENTO. */

            M_090_000_CURSOR_V1MOVIMENTO_SECTION();

            /*" -107- PERFORM 121-000-FETCH-V1MOVIMENTO. */

            M_121_000_FETCH_V1MOVIMENTO_SECTION();

            /*" -109- IF WFIM-MOVIMENTO = 'N' */

            if (WFIM_MOVIMENTO == "N")
            {

                /*" -111- PERFORM 120-000-PROC-MOVIMENTO UNTIL WFIM-MOVIMENTO = 'S' */

                while (!(WFIM_MOVIMENTO == "S"))
                {

                    M_120_000_PROC_MOVIMENTO_SECTION();
                }

                /*" -112- ELSE */
            }
            else
            {


                /*" -115- DISPLAY '*** VG0032B *** NAO HOUVE MOVIMENTO' . */
                _.Display($"*** VG0032B *** NAO HOUVE MOVIMENTO");
            }


            /*" -115- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-SECTION */
        private void M_090_000_CURSOR_V1MOVIMENTO_SECTION()
        {
            /*" -131- MOVE '090-000-CURSOR-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("090-000-CURSOR-V1MOVIMENTO", WABEND.PARAGRAFO);

            /*" -133- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -145- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1();

            /*" -149- PERFORM M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1 */

            M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1();

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-DECLARE-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_DECLARE_1()
        {
            /*" -145- EXEC SQL DECLARE TMOVIMENTO CURSOR FOR SELECT A.NUM_CERTIFICADO, B.SIT_REGISTRO FROM SEGUROS.SEGURADOS_VGAP A, SEGUROS.PROPOSTAS_VA B WHERE A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND A.TIPO_SEGURADO = '1' AND A.SIT_REGISTRO = '2' AND B.SIT_REGISTRO <> '4' END-EXEC. */
            TMOVIMENTO = new VG0032B_TMOVIMENTO(false);
            string GetQuery_TMOVIMENTO()
            {
                var query = @$"SELECT 
							A.NUM_CERTIFICADO
							, 
							B.SIT_REGISTRO 
							FROM SEGUROS.SEGURADOS_VGAP A
							, 
							SEGUROS.PROPOSTAS_VA B 
							WHERE 
							A.NUM_CERTIFICADO = B.NUM_CERTIFICADO AND 
							A.TIPO_SEGURADO = '1' AND 
							A.SIT_REGISTRO = '2' AND 
							B.SIT_REGISTRO <> '4'";

                return query;
            }
            TMOVIMENTO.GetQueryEvent += GetQuery_TMOVIMENTO;

        }

        [StopWatch]
        /*" M-090-000-CURSOR-V1MOVIMENTO-DB-OPEN-1 */
        public void M_090_000_CURSOR_V1MOVIMENTO_DB_OPEN_1()
        {
            /*" -149- EXEC SQL OPEN TMOVIMENTO END-EXEC. */

            TMOVIMENTO.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_090_999_EXIT*/

        [StopWatch]
        /*" M-120-000-PROC-MOVIMENTO-SECTION */
        private void M_120_000_PROC_MOVIMENTO_SECTION()
        {
            /*" -171- MOVE '120-000-PROC-MOVIMENTO' TO PARAGRAFO. */
            _.Move("120-000-PROC-MOVIMENTO", WABEND.PARAGRAFO);

            /*" -171- PERFORM 420-000-UPDATE-V0PROPOSTAVA. */

            M_420_000_UPDATE_V0PROPOSTAVA_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_120_900_NEXT */

            M_120_900_NEXT();

        }

        [StopWatch]
        /*" M-120-900-NEXT */
        private void M_120_900_NEXT(bool isPerform = false)
        {
            /*" -175- PERFORM 121-000-FETCH-V1MOVIMENTO. */

            M_121_000_FETCH_V1MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-121-000-FETCH-V1MOVIMENTO-SECTION */
        private void M_121_000_FETCH_V1MOVIMENTO_SECTION()
        {
            /*" -193- MOVE '121-000-FETCH-V1MOVIMENTO' TO PARAGRAFO */
            _.Move("121-000-FETCH-V1MOVIMENTO", WABEND.PARAGRAFO);

            /*" -196- MOVE '121' TO WNR-EXEC-SQL. */
            _.Move("121", WABEND.WNR_EXEC_SQL);

            /*" -201- PERFORM M_121_000_FETCH_V1MOVIMENTO_DB_FETCH_1 */

            M_121_000_FETCH_V1MOVIMENTO_DB_FETCH_1();

            /*" -204- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -205- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -206- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", WFIM_MOVIMENTO);

                    /*" -206- PERFORM M_121_000_FETCH_V1MOVIMENTO_DB_CLOSE_1 */

                    M_121_000_FETCH_V1MOVIMENTO_DB_CLOSE_1();

                    /*" -208- ELSE */
                }
                else
                {


                    /*" -209- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -210- ELSE */
                }

            }
            else
            {


                /*" -210- ADD 1 TO AC-LIDOS. */
                AC_LIDOS.Value = AC_LIDOS + 1;
            }


        }

        [StopWatch]
        /*" M-121-000-FETCH-V1MOVIMENTO-DB-FETCH-1 */
        public void M_121_000_FETCH_V1MOVIMENTO_DB_FETCH_1()
        {
            /*" -201- EXEC SQL FETCH TMOVIMENTO INTO :SEGURVGA-NUM-CERTIFICADO, :PROPOVA-SIT-REGISTRO END-EXEC. */

            if (TMOVIMENTO.Fetch())
            {
                _.Move(TMOVIMENTO.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(TMOVIMENTO.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" M-121-000-FETCH-V1MOVIMENTO-DB-CLOSE-1 */
        public void M_121_000_FETCH_V1MOVIMENTO_DB_CLOSE_1()
        {
            /*" -206- EXEC SQL CLOSE TMOVIMENTO END-EXEC */

            TMOVIMENTO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_121_999_EXIT*/

        [StopWatch]
        /*" M-420-000-UPDATE-V0PROPOSTAVA-SECTION */
        private void M_420_000_UPDATE_V0PROPOSTAVA_SECTION()
        {
            /*" -226- MOVE '420-000-UPDATE-V0PROPOSTAVA' TO PARAGRAFO */
            _.Move("420-000-UPDATE-V0PROPOSTAVA", WABEND.PARAGRAFO);

            /*" -228- MOVE '420' TO WNR-EXEC-SQL. */
            _.Move("420", WABEND.WNR_EXEC_SQL);

            /*" -234- PERFORM M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1 */

            M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1();

            /*" -237- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -238- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -240- DISPLAY 'VG0032B - ERRO UPDATE PROPOSTAVA    ' SEGURVGA-NUM-CERTIFICADO */
                    _.Display($"VG0032B - ERRO UPDATE PROPOSTAVA    {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

                    /*" -241- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO(); //GOTO
                    return;

                    /*" -242- END-IF */
                }


                /*" -243- ELSE */
            }
            else
            {


                /*" -243- ADD 1 TO AC-GRAVA. */
                AC_GRAVA.Value = AC_GRAVA + 1;
            }


        }

        [StopWatch]
        /*" M-420-000-UPDATE-V0PROPOSTAVA-DB-UPDATE-1 */
        public void M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1()
        {
            /*" -234- EXEC SQL UPDATE SEGUROS.PROPOSTAS_VA SET SIT_REGISTRO = '4' , COD_USUARIO = 'VG0032B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO END-EXEC. */

            var m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 = new M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
            };

            M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1.Execute(m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_420_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -257- EXEC SQL COMMIT WORK END-EXEC */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -260- DISPLAY 'LIDOS SEGURADOS_VGAP     . ' AC-LIDOS */
            _.Display($"LIDOS SEGURADOS_VGAP     . {AC_LIDOS}");

            /*" -261- DISPLAY 'ATUALIZADOS PROPOSTAS_VA . ' AC-GRAVA */
            _.Display($"ATUALIZADOS PROPOSTAS_VA . {AC_GRAVA}");

            /*" -262- DISPLAY 'FIM NORMAL      **** VG0032B ****' . */
            _.Display($"FIM NORMAL      **** VG0032B ****");

            /*" -263- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -263- GOBACK. */

            throw new GoBack();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO */
        private void M_999_999_ROT_ERRO(bool isPerform = false)
        {
            /*" -277- DISPLAY ' CERTIF ' SEGURVGA-NUM-CERTIFICADO. */
            _.Display($" CERTIF {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO}");

            /*" -278- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -279- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.WSQLCODE);

                /*" -280- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], WABEND.WSQLCODE1);

                /*" -281- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], WABEND.WSQLCODE2);

                /*" -282- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, WSQLCODE3);

                /*" -284- DISPLAY WABEND. */
                _.Display(WABEND);
            }


            /*" -286- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -290- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -293- MOVE 9 TO RETURN-CODE */
            _.Move(9, RETURN_CODE);

            /*" -293- GOBACK. */

            throw new GoBack();

        }
    }
}