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
using Sias.Bilhetes.DB2.BI0077B;

namespace Code
{
    public class BI0077B
    {
        public bool IsCall { get; set; }

        public BI0077B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  BILHETE                            *      */
        /*"      *   PROGRAMA ...............  BI0077B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  FAST                               *      */
        /*"      *   PROGRAMADOR ............  FAST                               *      */
        /*"      *   DATA CODIFICACAO .......  22/10/2008                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  PROCESSA MOVIMENTO DE CANCELAMENTO *      */
        /*"      *                             FARMA        - 8108                *      */
        /*"      *                                                                *      */
        /*"      *                             CADMUS 49.166                      *      */
        /*"      *                                                                *      */
        /*"      *--------------------- ALTERACOES -------------------------------*      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOVIMENTO { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis MOVIMENTO
        {
            get
            {
                _.Move(MOVCC_REGISTRO, _MOVIMENTO); VarBasis.RedefinePassValue(MOVCC_REGISTRO, _MOVIMENTO, MOVCC_REGISTRO); return _MOVIMENTO;
            }
        }
        /*"01        MOVCC-REGISTRO.*/
        public BI0077B_MOVCC_REGISTRO MOVCC_REGISTRO { get; set; } = new BI0077B_MOVCC_REGISTRO();
        public class BI0077B_MOVCC_REGISTRO : VarBasis
        {
            /*"  05      MOVCC-NUMSIVPF     PIC  9(014).*/
            public IntBasis MOVCC_NUMSIVPF { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      FILLER             PIC  X(136).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "136", "X(136)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    WSHOST-NUMSIV01           PIC S9(015)     COMP-3.*/
        public IntBasis WSHOST_NUMSIV01 { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01           AREA-DE-WORK.*/
        public BI0077B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new BI0077B_AREA_DE_WORK();
        public class BI0077B_AREA_DE_WORK : VarBasis
        {
            /*"  03         WFIM-MOVIMENTO    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         WTEM-CONVERSI     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WTEM_CONVERSI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  03         LD-ENTRADA        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis LD_ENTRADA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03         NT-BILHETE        PIC  9(007)    VALUE ZEROS.*/
            public IntBasis NT_BILHETE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WABEND.*/
            public BI0077B_WABEND WABEND { get; set; } = new BI0077B_WABEND();
            public class BI0077B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' BI0077B'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI0077B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(004) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD1 = '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '   SQLERRD2 = '.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"  03        WSQLERR.*/
            }
            public BI0077B_WSQLERR WSQLERR { get; set; } = new BI0077B_WSQLERR();
            public class BI0077B_WSQLERR : VarBasis
            {
                /*"    05      FILLER              PIC  X(014) VALUE           ' *** SQLERRMC '.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @" *** SQLERRMC ");
                /*"    05      WSQLERRMC           PIC  X(070) VALUE SPACES.*/
                public StringBasis WSQLERRMC { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CONVERSI CONVERSI { get; set; } = new Dclgens.CONVERSI();
        public Dclgens.BILHETE BILHETE { get; set; } = new Dclgens.BILHETE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVIMENTO_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVIMENTO.SetFile(MOVIMENTO_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -131- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -134- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -137- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -140- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -141- DISPLAY 'PROGRAMA EM EXECUCAO BI0077B  ' */
            _.Display($"PROGRAMA EM EXECUCAO BI0077B  ");

            /*" -142- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -143- DISPLAY 'VERSAO V.00 49.166 22/10/2010 ' */
            _.Display($"VERSAO V.00 49.166 22/10/2010 ");

            /*" -144- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -146- DISPLAY '------------------------------' . */
            _.Display($"------------------------------");

            /*" -148- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -150- PERFORM R0300-00-SELECIONA. */

            R0300_00_SELECIONA_SECTION();

            /*" -150- PERFORM R0350-00-TOTAIS. */

            R0350_00_TOTAIS_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -154- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -158- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -160- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -162- DISPLAY '*** BI0077B - FIM NORMAL ***' . */
            _.Display($"*** BI0077B - FIM NORMAL ***");

            /*" -162- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -173- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -175- OPEN INPUT MOVIMENTO. */
            MOVIMENTO.Open(MOVCC_REGISTRO);

            /*" -175- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -186- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -192- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -195- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -196- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -199- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -201- DISPLAY ' DATA DO PROCESSAMENTO ...............  ' SISTEMAS-DATA-MOV-ABERTO. */
            _.Display($" DATA DO PROCESSAMENTO ...............  {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -201- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -192- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'BI' WITH UR END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-SELECIONA-SECTION */
        private void R0300_00_SELECIONA_SECTION()
        {
            /*" -212- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -214- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", AREA_DE_WORK.WFIM_MOVIMENTO);

            /*" -216- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

            /*" -217- PERFORM R0320-00-PROCESSA-ENTRADA UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0320_00_PROCESSA_ENTRADA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0310-00-LER-ENTRADA-SECTION */
        private void R0310_00_LER_ENTRADA_SECTION()
        {
            /*" -228- MOVE '0310' TO WNR-EXEC-SQL. */
            _.Move("0310", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -228- READ MOVIMENTO AT END */
            try
            {
                MOVIMENTO.Read(() =>
                {

                    /*" -230- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", AREA_DE_WORK.WFIM_MOVIMENTO);

                    /*" -232- GO TO R0310-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MOVIMENTO.Value, MOVCC_REGISTRO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -232- ADD 1 TO LD-ENTRADA. */
            AREA_DE_WORK.LD_ENTRADA.Value = AREA_DE_WORK.LD_ENTRADA + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0310_99_SAIDA*/

        [StopWatch]
        /*" R0320-00-PROCESSA-ENTRADA-SECTION */
        private void R0320_00_PROCESSA_ENTRADA_SECTION()
        {
            /*" -243- MOVE '0320' TO WNR-EXEC-SQL. */
            _.Move("0320", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -245- PERFORM R0330-00-SELECT-CONVERSI */

            R0330_00_SELECT_CONVERSI_SECTION();

            /*" -246- IF WTEM-CONVERSI EQUAL 'N' */

            if (AREA_DE_WORK.WTEM_CONVERSI == "N")
            {

                /*" -248- GO TO R0320-50-LEITURA. */

                R0320_50_LEITURA(); //GOTO
                return;
            }


            /*" -248- PERFORM R0340-00-CANCELA-BILHETE. */

            R0340_00_CANCELA_BILHETE_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0320_50_LEITURA */

            R0320_50_LEITURA();

        }

        [StopWatch]
        /*" R0320-50-LEITURA */
        private void R0320_50_LEITURA(bool isPerform = false)
        {
            /*" -252- PERFORM R0310-00-LER-ENTRADA. */

            R0310_00_LER_ENTRADA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0320_99_SAIDA*/

        [StopWatch]
        /*" R0330-00-SELECT-CONVERSI-SECTION */
        private void R0330_00_SELECT_CONVERSI_SECTION()
        {
            /*" -263- MOVE '0330' TO WNR-EXEC-SQL. */
            _.Move("0330", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -265- MOVE MOVCC-NUMSIVPF TO WSHOST-NUMSIV01. */
            _.Move(MOVCC_REGISTRO.MOVCC_NUMSIVPF, WSHOST_NUMSIV01);

            /*" -267- MOVE 'S' TO WTEM-CONVERSI. */
            _.Move("S", AREA_DE_WORK.WTEM_CONVERSI);

            /*" -274- PERFORM R0330_00_SELECT_CONVERSI_DB_SELECT_1 */

            R0330_00_SELECT_CONVERSI_DB_SELECT_1();

            /*" -277- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -278- MOVE 'N' TO WTEM-CONVERSI */
                _.Move("N", AREA_DE_WORK.WTEM_CONVERSI);

                /*" -278- GO TO R0330-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/ //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0330-00-SELECT-CONVERSI-DB-SELECT-1 */
        public void R0330_00_SELECT_CONVERSI_DB_SELECT_1()
        {
            /*" -274- EXEC SQL SELECT NUM_SICOB INTO :BILHETE-NUM-BILHETE FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :WSHOST-NUMSIV01 WITH UR END-EXEC. */

            var r0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1 = new R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1()
            {
                WSHOST_NUMSIV01 = WSHOST_NUMSIV01.ToString(),
            };

            var executed_1 = R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1.Execute(r0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHETE_NUM_BILHETE, BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0330_99_SAIDA*/

        [StopWatch]
        /*" R0340-00-CANCELA-BILHETE-SECTION */
        private void R0340_00_CANCELA_BILHETE_SECTION()
        {
            /*" -290- MOVE '0340' TO WNR-EXEC-SQL. */
            _.Move("0340", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -299- PERFORM R0340_00_CANCELA_BILHETE_DB_UPDATE_1 */

            R0340_00_CANCELA_BILHETE_DB_UPDATE_1();

            /*" -302- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -304- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -305- ELSE */
                }
                else
                {


                    /*" -308- DISPLAY 'R0340-00 - PROBLEMAS UPDATE (BILHETE)   ' BILHETE-NUM-BILHETE ' ' MOVCC-NUMSIVPF */

                    $"R0340-00 - PROBLEMAS UPDATE (BILHETE)   {BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE} {MOVCC_REGISTRO.MOVCC_NUMSIVPF}"
                    .Display();

                    /*" -309- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -310- END-IF */
                }


                /*" -311- ELSE */
            }
            else
            {


                /*" -312- ADD 1 TO NT-BILHETE */
                AREA_DE_WORK.NT_BILHETE.Value = AREA_DE_WORK.NT_BILHETE + 1;

                /*" -312- END-IF. */
            }


        }

        [StopWatch]
        /*" R0340-00-CANCELA-BILHETE-DB-UPDATE-1 */
        public void R0340_00_CANCELA_BILHETE_DB_UPDATE_1()
        {
            /*" -299- EXEC SQL UPDATE SEGUROS.BILHETE SET SITUACAO = '8' , DATA_CANCELAMENTO = CURRENT DATE, COD_USUARIO = 'BI0077B' , TIMESTAMP = CURRENT TIMESTAMP WHERE NUM_BILHETE = :BILHETE-NUM-BILHETE AND SITUACAO <> '8' END-EXEC. */

            var r0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1 = new R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1()
            {
                BILHETE_NUM_BILHETE = BILHETE.DCLBILHETE.BILHETE_NUM_BILHETE.ToString(),
            };

            R0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1.Execute(r0340_00_CANCELA_BILHETE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0340_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-TOTAIS-SECTION */
        private void R0350_00_TOTAIS_SECTION()
        {
            /*" -323- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -324- DISPLAY ' ' . */
            _.Display($" ");

            /*" -325- DISPLAY ' LIDOS    ENTRADA ...... ' LD-ENTRADA. */
            _.Display($" LIDOS    ENTRADA ...... {AREA_DE_WORK.LD_ENTRADA}");

            /*" -326- DISPLAY ' ' . */
            _.Display($" ");

            /*" -327- DISPLAY ' BILHETES CANCELADOS.... ' NT-BILHETE. */
            _.Display($" BILHETES CANCELADOS.... {AREA_DE_WORK.NT_BILHETE}");

            /*" -327- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -338- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -339- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], AREA_DE_WORK.WABEND.WSQLERRD1);

            /*" -340- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], AREA_DE_WORK.WABEND.WSQLERRD2);

            /*" -342- MOVE SQLERRMC TO WSQLERRMC. */
            _.Move(DB.SQLERRMC, AREA_DE_WORK.WSQLERR.WSQLERRMC);

            /*" -343- DISPLAY WABEND. */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -345- DISPLAY WSQLERR. */
            _.Display(AREA_DE_WORK.WSQLERR);

            /*" -345- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -349- CLOSE MOVIMENTO. */
            MOVIMENTO.Close();

            /*" -351- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -351- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}